using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.View.storage
{
    /// <summary>
    /// Interaction logic for uc_itemsExport.xaml
    /// </summary>
    public partial class uc_itemsExport : UserControl
    {
        private static uc_itemsExport _instance;
        public static uc_itemsExport Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_itemsExport();
                return _instance;
            }
        }
        public uc_itemsExport()
        {
            InitializeComponent();
        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        Branch branchModel = new Branch();
        IEnumerable<Branch> branches;

        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;

        Invoice invoice = new Invoice();
        List<ItemTransfer> invoiceItems;
        static private string _ProcessType = "im"; // import

        static private int _SequenceNum = 0;
        static private int _Count = 0;
        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        static private string _BarcodeStr = "";
        static private object _Sender;
        static private string _SelectedProcess = "";
        static private int _SelectedBranch = -1;

        Category categoryModel = new Category();
        Category category = new Category();

        IEnumerable<Category> categories;
        IEnumerable<Category> categoriesQuery;
        int? categoryParentId = 0;
        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;
        IEnumerable<Item> itemsQuery;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;
        //tglItemState
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void translate()
        {
            ////////////////////////////////----Order----/////////////////////////////////
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");



        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.KeyDown -= HandleKeyPress;
          
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.KeyDown += HandleKeyPress;

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", assembly: Assembly.GetExecutingAssembly());
                grid_ucItemsExport.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucItemsExport.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            catigoriesAndItemsView.ucItemsExport = this;
            configureProcessType();
            await RefrishBranches();
            await RefrishItems();


        }
        async Task RefrishBranches()
        {
            branches = await branchModel.GetBranchesActive("all");
            cb_branch.ItemsSource = branches;
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
        }
        async Task RefrishItems()
        {
            items = await itemModel.GetAllItems();
        }
        private void configureProcessType()
        {
            var processList = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trImport"), Value = "im" },
            new { Text = MainWindow.resourcemanager.GetString("trExport"), Value = "ex"},
             };

            cb_processType.DisplayMemberPath = "Text";
            cb_processType.SelectedValuePath = "Value";
            cb_processType.ItemsSource = processList;
            cb_processType.SelectedIndex = 0;
        }
        async Task fillBarcodeList()
        {
            barcodesList = await itemUnitModel.Getall();
        }
        // read item from barcode
        private async void HandleKeyPress(object sender, KeyEventArgs e)
        {
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 50)
            {
                _BarcodeStr = "";
            }

            string digit = "";
            // record keystroke & timestamp 
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                //digit pressed!         
                digit = e.Key.ToString().Substring(1);
                // = "1" when D1 is pressed
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                digit = e.Key.ToString().Substring(6); // = "1" when NumPad1 is pressed
            }
            else if (e.Key >= Key.A && e.Key <= Key.Z)
                digit = e.Key.ToString();
            else if (e.Key == Key.OemMinus)
            {
                digit = "-";
            }
            _BarcodeStr += digit;
            _lastKeystroke = DateTime.Now;
            // process barcode

            if (e.Key.ToString() == "Return" && _BarcodeStr != "")
            {
                await dealWithBarcode(_BarcodeStr);
                e.Handled = true;
            }
            _Sender = null;
            _BarcodeStr = "";

        }
        private async Task dealWithBarcode(string barcode)
        {
                tb_barcode.Text = barcode;
                // get item matches barcode
                if (barcodesList != null)
                {
                    ItemUnit unit1 = barcodesList.ToList().Find(c => c.barcode == tb_barcode.Text.Trim());

                    // get item matches the barcode
                    if (unit1 != null)
                    {
                        int itemId = (int)unit1.itemId;
                        if (unit1.itemId != 0)
                        {
                            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId).FirstOrDefault());

                            if (index == -1)//item doesn't exist in bill
                            {
                                // get item units
                                itemUnits = await itemUnitModel.GetItemUnits(itemId);
                                //get item from list
                                item = items.ToList().Find(i => i.itemId == itemId);

                                int count = 1;
                                _Count++;
                                //decimal price = 0;
                                // if (unit1.price != null)
                                    //   price = (decimal)unit1.price;
                                //decimal total = count * price;
                                //decimal tax = (decimal)(count * item.taxes);
                                addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count);
                            }
                            else // item exist prevoiusly in list
                            {
                                billDetails[index].Count++;
                                _Count++;
                            }
                        refrishBillDetails();
                        }
                    }
                    else
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorItemNotFoundToolTip"), animation: ToasterAnimation.FadeIn);
                    }
                }
            tb_barcode.Clear();
        }
        private void addRowToBill(string itemName, int itemId, string unitName, int itemUnitId, int count)
        {
            // increase sequence for each read
            _SequenceNum++;

            billDetails.Add(new BillDetails()
            {
                ID = _SequenceNum,
                Product = item.name,
                itemId = item.itemId,
                Unit = unitName,
                itemUnitId = itemUnitId,
                Count = count,
            });
            refrishBillDetails();
        }
        void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;

            tb_count.Text = _Count.ToString();
        }
        #region bill



        public class Bill
        {
            public int Id { get; set; }
            public int Total { get; set; }

        }
        public class BillDetails
        {
            public int ID { get; set; }
            public int itemId { get; set; }
            public int itemUnitId { get; set; }
            public string Product { get; set; }
            public string Unit { get; set; }
            public int Count { get; set; }
            public decimal Price { get; set; }
            public decimal Total { get; set; }
            public decimal Tax { get; set; }
        }
        #endregion

        #region Button In DataGrid
        void deleteRowFromOrderItems(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
                    int index = dg_billDetails.SelectedIndex;

                    // remove item from bill
                    billDetails.RemoveAt(index);

                    ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
                    data.Remove(row);

                    // calculate new total
                    //refreshTotalValue();
                }
            _SequenceNum = 0;
            for (int i = 0; i < billDetails.Count; i++)
            {
                _SequenceNum++;
                billDetails[i].ID = _SequenceNum;
            }
            refrishBillDetails();
        }
        #endregion
      
        private void Tgl_orderDropDown_Checked(object sender, RoutedEventArgs e)
        {
            //grid_order.Visibility = Visibility.Visible;
        }
        private void Tgl_orderDropDown_Unchecked(object sender, RoutedEventArgs e)
        {
            //grid_order.Visibility = Visibility.Collapsed;
        }


        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_orders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ordersWait_Click(object sender, RoutedEventArgs e)
        {

        }
        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            if (name == "TextBox")
            {
            }
            else if (name == "ComboBox")
            {
            }
            else
            {

            }
        }
        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;

            //if (dg_billDetails.SelectedIndex != -1)
            //    billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
        }

        private void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            //items

            Window.GetWindow(this).Opacity = 0.2;
            wd_items w = new wd_items();
            w.CardType = "purchase";
            w.ShowDialog();
            if (w.isActive)
            {
                ////// this is ItemId
                //w.selectedItem
                // MessageBox.Show(w.selectedItem.ToString());
                ChangeItemIdEvent(w.selectedItem);
            }

            Window.GetWindow(this).Opacity = 1;
        }
        #region Get Id By Click  Y

        public async void ChangeCategoryIdEvent(int categoryId)
        {

        }


        public async void ChangeItemIdEvent(int itemId)
        {
            if (items != null) item = items.ToList().Find(c => c.itemId == itemId);

            if (item != null)
            {
                this.DataContext = item;

                // get item units
                itemUnits = await itemUnitModel.GetItemUnits(item.itemId);
                // search for default unit for purchase
                var defaultPurUnit = itemUnits.ToList().Find(c => c.defaultPurchase == 1);
                if (defaultPurUnit != null)
                {
                    // create new row in bill details data grid
                    addRowToBill(item.name, itemId, defaultPurUnit.mainUnit, defaultPurUnit.itemUnitId, 1);

                    _Count++;
                    refrishBillDetails();
                }
            }
        }

        #endregion
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;

            else
                e.Handled = true;
        }
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

        }
        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
                    int index = dg_billDetails.SelectedIndex;
                    // calculate new sum
                    _Count -= row.Count;

                    // remove item from bill
                    billDetails.RemoveAt(index);

                    ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
                    data.Remove(row);

                    tb_count.Text = _Count.ToString();
                }
            for (int i = 0; i < billDetails.Count; i++)
            {
                _SequenceNum++;
                billDetails[i].ID = _SequenceNum;
            }
            refrishBillDetails();

        }
        #endregion

        private void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_draft_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            invoice.invType = cb_processType.SelectedValue.ToString();
            if (cb_branch.SelectedIndex != -1)
                invoice.branchId = (int)cb_branch.SelectedValue;
            invoice.createUserId = MainWindow.userID;
            invoice.updateUserId = MainWindow.userID;

            // save invoice in DB
            int invoiceId = int.Parse(await invoice.saveInvoice(invoice));
            if (invoiceId != 0)
            {
                invoiceItems = new List<ItemTransfer>();
                ItemTransfer itemT;
                for (int i = 0; i < billDetails.Count; i++)
                {
                    itemT = new ItemTransfer();

                    itemT.invoiceId = invoiceId;
                    itemT.quantity = billDetails[i].Count;
                    itemT.price = billDetails[i].Price;
                    itemT.itemUnitId = billDetails[i].itemUnitId;
                    itemT.createUserId = MainWindow.userID;

                    invoiceItems.Add(itemT);
                }
                await invoice.saveInvoiceItems(invoiceItems, invoiceId);
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
            }
            else
            {
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 100 && cb_branch.SelectedIndex != -1)
            {
                _SelectedBranch = (int)cb_branch.SelectedValue;
            }
            else
            {
                cb_branch.SelectedValue = _SelectedBranch;
            }
        }

        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
            var columnName = e.Column.Header.ToString();

            BillDetails row = e.Row.Item as BillDetails;
            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == row.itemUnitId).FirstOrDefault());

            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds < 100)
            {
                if (columnName == MainWindow.resourcemanager.GetString("trAmount"))
                    t.Text = billDetails[index].Count.ToString();
            }
            else
            {
                int oldCount = 0;
                int newCount = 0;

                //"tb_amont"
                if (columnName == MainWindow.resourcemanager.GetString("trAmount"))
                    newCount = int.Parse(t.Text);
                else
                    newCount = row.Count;

                oldCount = row.Count;

                _Count -= oldCount;
                _Count += newCount;


                //  refresh count text box
                tb_count.Text = _Count.ToString();

                // update item in billdetails           
                billDetails[index].Count = (int)newCount;
            }
        }

        private void Cb_processType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 100 && cb_processType.SelectedIndex != -1)
            {
                _SelectedProcess = (string)cb_processType.SelectedValue;
            }
            else
            {
                cb_processType.SelectedValue = _SelectedProcess;
            }
        }
    }
}

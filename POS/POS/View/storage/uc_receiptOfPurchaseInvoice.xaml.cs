using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    /// Interaction logic for uc_receiptOfPurchaseInvoice.xaml
    /// </summary>
    public partial class uc_receiptOfPurchaseInvoice : UserControl
    {
        string reciptPermission = "reciptOfInvoice_recipt";
        string returnPermission = "reciptOfInvoice_return";
        string reportsPermission = "reciptOfInvoice_reports";
        private static uc_receiptOfPurchaseInvoice _instance;
        public static uc_receiptOfPurchaseInvoice Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_receiptOfPurchaseInvoice();
                return _instance;
            }
        }
        public uc_receiptOfPurchaseInvoice()
        {
            InitializeComponent();
        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        Category categoryModel = new Category();
        Category category = new Category();
        Item itemModel = new Item();
        Item item = new Item();

        Invoice invoiceModel = new Invoice();
        Invoice invoice = new Invoice();

        List<ItemTransfer> invoiceItems;
        List<ItemTransfer> mainInvoiceItems;
        ItemLocation itemLocationModel = new ItemLocation();

        Agent agentModel = new Agent();
        IEnumerable<Agent> vendors;

        Branch branchModel = new Branch();
        IEnumerable<Branch> branches;
        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        static private string _BarcodeStr = "";
        static private object _Sender;
        //for bill details
        static private int _SequenceNum = 0;
        static private string _InvoiceType = "pbd"; // purchase bounce draft
        static private decimal _Count = 0;
        //tglItemState
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////
            //txt_invoiceHeader.Text = MainWindow.resourcemanager.GetString("trInvoice");


            //dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            //dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            //dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");
            //txt_saveButton.Text = MainWindow.resourcemanager.GetString("trSave");
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.KeyDown += HandleKeyPress;

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucPayInvoice.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucPayInvoice.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            tb_barcode.Focus();
            await RefrishVendors();
            //await RefrishBranches();
            #region datagridChange
            CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
            ((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
            #endregion
        }
        //async Task RefrishBranches()
        //{
        //    branches = await branchModel.GetBranchesActive("all");
        //}
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.KeyDown -= HandleKeyPress;
            if (billDetails.Count > 0)
            {
                #region Accept
                MainWindow.mainWindow.Opacity = 0.2;
                wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                //w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                w.contentText = "Do you want save pay invoice in drafts?";
                w.ShowDialog();
                MainWindow.mainWindow.Opacity = 1;
                #endregion
                if (w.isOk)
                    Btn_newDraft_Click(null, null);
                else
                    clearInvoice();
            }
        }
        #region bill


        private class Bill
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
        }
        #endregion
        async Task RefrishVendors()
        {
            vendors = await agentModel.GetAgentsActive("v");
        }
        private async void HandleKeyPress(object sender, KeyEventArgs e) 
            {
            if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
            {
                switch (e.Key)
                {
                    case Key.P:
                        //handle D key
                        //MessageBox.Show("You want Print");
                        //btn_printInvoice_Click(null, null);
                        break;
                    case Key.S:
                        //handle X key
                        //MessageBox.Show("You want Save");
                        Btn_save_Click(null, null);
                        break;
                }
            }



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
                if (_Sender != null)
                {
                    DatePicker dt = _Sender as DatePicker;
                    TextBox tb = _Sender as TextBox;
                    if (tb != null)
                    {
                        if (tb.Name == "tb_invoiceNumber" || tb.Name == "tb_note" || tb.Name == "tb_discount" || tb.Name == "tb_barcode")// remove barcode from text box
                        {
                            string tbString = tb.Text;
                            string newStr = "";
                            int startIndex = tbString.IndexOf(_BarcodeStr);
                            if (startIndex != -1)
                                newStr = tbString.Remove(startIndex, _BarcodeStr.Length);

                            tb.Text = newStr;
                        }
                    }
                }
                tb_barcode.Text = _BarcodeStr;
                _BarcodeStr = "";

                e.Handled = true;
            }
            _Sender = null;
        }
        private async Task dealWithBarcode(string barcode)
        {
            int codeindex = barcode.IndexOf("-");
            string prefix = "";
            if (codeindex >= 0)
                prefix = barcode.Substring(0, codeindex);
            prefix = prefix.ToLower();
            barcode = barcode.ToLower();
            switch (prefix)
            {
                case "pi":// this barcode for invoice
                    Btn_newDraft_Click(null, null);
                    invoice = await invoiceModel.GetInvoicesByNum(barcode,MainWindow.branchID.Value);
                    _InvoiceType = invoice.invType;
                    if (_InvoiceType.Equals("p") || _InvoiceType.Equals("pw"))
                    {
                        // set title to bill
                        if (_InvoiceType == "p")
                        {
                            txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                            brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                            _InvoiceType = "pbd";
                        }
                        else if (_InvoiceType == "pw")
                        {
                            txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseBill");
                            _InvoiceType = "p";
                             brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                           

                        await fillInvoiceInputs(invoice);
                    }
                    break;
                case "pb":// this barcode for bounce invoice
                    Btn_newDraft_Click(null, null);
                    invoice = await invoiceModel.GetInvoicesByNum(barcode,MainWindow.branchID.Value);
                    _InvoiceType = invoice.invType;
                   if (_InvoiceType == "pbd")
                    {
                        txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                        brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                    }
                   
                    break;

                default: // if barcode for item
                         // get item matches barcode
                    //if (barcodesList != null)
                    //{
                    //    ItemUnit unit1 = barcodesList.ToList().Find(c => c.barcode == tb_barcode.Text.Trim());

                    //    // get item matches the barcode
                    //    if (unit1 != null)
                    //    {
                    //        int itemId = (int)unit1.itemId;
                    //        if (unit1.itemId != 0)
                    //        {
                    //            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId).FirstOrDefault());

                    //            if (index == -1)//item doesn't exist in bill
                    //            {
                    //                // get item units
                    //                itemUnits = await itemUnitModel.GetItemUnits(itemId);
                    //                //get item from list
                    //                item = items.ToList().Find(i => i.itemId == itemId);

                    //                int count = 1;
                    //                decimal price = 0; //?????
                    //                decimal total = count * price;
                    //                addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count, price, total);
                    //            }
                    //            else // item exist prevoiusly in list
                    //            {
                    //                billDetails[index].Count++;
                    //                billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;

                    //                _Sum += billDetails[index].Price;

                    //            }
                    //            refreshTotalValue();
                    //            refrishBillDetails();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorItemNotFoundToolTip"), animation: ToasterAnimation.FadeIn);
                    //    }
                    //}
                    break;
            }

            tb_barcode.Clear();
        }
        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
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
                   // refreshTotalValue();
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


        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
        private void Tgl_returnInvoiceDropDown_Checked(object sender, RoutedEventArgs e)
        {
            //grid_returnInvoice.Visibility = Visibility.Visible;
        }
        private void Tgl_returnInvoiceDropDown_Unchecked(object sender, RoutedEventArgs e)
        {
            //grid_returnInvoice.Visibility = Visibility.Collapsed;
        }
        private async void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {
            if (billDetails.Count > 0)
            {
                await returnInvoice("pbd");
            }
            clearInvoice();

            // set title to bill
            txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
            // orange #FFA926 red #D22A17
            brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
        }

        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;

            wd_invoice w = new wd_invoice();

            // sale invoices
            w.invoiceType = "pbd";
            w.branchId = MainWindow.branchID.Value;

            w.title = MainWindow.resourcemanager.GetString("trDrafts");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    this.DataContext = invoice;
                    mainInvoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceMainId.Value);
                    _InvoiceType = invoice.invType;
                    // set title to bill
                    txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                    // orange #FFA926 red #D22A17
                    brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                    await fillInvoiceInputs(invoice);
                }
            }
            Window.GetWindow(this).Opacity = 1;
        }

        private async void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(returnPermission, MainWindow.groupObjects, "one"))
            {
                Window.GetWindow(this).Opacity = 0.2;

            wd_invoice w = new wd_invoice();

            // sale invoices
            w.invoiceType = "p";
            w.branchId = MainWindow.branchID.Value;

            w.title = MainWindow.resourcemanager.GetString("trPurchaseInvoices");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    this.DataContext = invoice;

                    _InvoiceType = "pbd";
                    // set title to bill
                    txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                    // orange #FFA926 red #D22A17
                    brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                    await fillInvoiceInputs(invoice);
                    mainInvoiceItems = invoiceItems;
                }
            }
            Window.GetWindow(this).Opacity = 1;
        } else
            Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
		}


    private void Dg_invoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tb_search_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_IsActive_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_IsActive_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
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
        private void clearInvoice()
        {
            _SequenceNum = 0;
            _Count = 0;
            _InvoiceType = "pbd";
            invoice = new Invoice();
            tb_branch.Clear();
            billDetails.Clear();
            tb_count.Text = "";
            refrishBillDetails();
            inputEditable();
        }
        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;

            if (dg_billDetails.SelectedIndex != -1)
                billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
        }
        private void Cbm_unitItemDetails_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //billDetails
            if (billDetails.Count == 1)
            {
                var cmb = sender as ComboBox;
                cmb.SelectedValue = (int)billDetails[0].itemUnitId;
            }
        }
        private void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //billDetails
            int count = 0;
            foreach (var item in billDetails)
            {
                if (dg_billDetails.Items.Count != 0)
                {
                    if (dg_billDetails.Items.Count > 1)
                    {
                        var cell = DataGridHelper.GetCell(dg_billDetails, count, 3);
                        if (cell != null)
                        {
                            var cp = (ContentPresenter)cell.Content;
                            var combo = (ComboBox)cp.ContentTemplate.FindName("cbm_unitItemDetails", cp);
                            //var combo = (combo)cell.Content;
                            combo.SelectedValue = (int)item.itemUnitId;
                            count++;
                        }
                    }

                }
            }

        }
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
        private void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            //items

            Window.GetWindow(this).Opacity = 0.2;
            wd_items w = new wd_items();
            w.CardType = "purchase";
            w.ShowDialog();
            if (w.isActive)
            {
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
           
        }


        #endregion

        

        private async void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reciptPermission, MainWindow.groupObjects, "one"))
            {
                Window.GetWindow(this).Opacity = 0.2;

            wd_invoice w = new wd_invoice();

            // sale invoices
            w.invoiceType = "pw";
            w.branchId = MainWindow.branchID.Value;

            w.title = MainWindow.resourcemanager.GetString("trPurchaseInvoices");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    this.DataContext = invoice;

                    _InvoiceType = invoice.invType;

                    // set title to bill
                    txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
                    // orange #FFA926 red #D22A17
                    brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                    await fillInvoiceInputs(invoice);
                }
            }
            Window.GetWindow(this).Opacity = 1;
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private async Task fillInvoiceInputs(Invoice invoice)
        {
            tb_branch.Text = invoice.branchName;
           
            // build invoice details grid
            await buildInvoiceDetails(invoice.invoiceId);
            inputEditable();
        }
        private async Task buildInvoiceDetails(int invoiceId)
        {
            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
            // build invoice details grid
            _SequenceNum = 0;
            billDetails.Clear();
            _Count = 0;
            foreach (ItemTransfer itemT in invoiceItems)
            {
                _SequenceNum++;
                _Count += (int)itemT.quantity;
                decimal total = (decimal)(itemT.price * itemT.quantity);
                billDetails.Add(new BillDetails()
                {
                    ID = _SequenceNum,
                    Product = itemT.itemName,
                    itemId = (int)itemT.itemId,
                    Unit = itemT.itemUnitId.ToString(),
                    itemUnitId = (int)itemT.itemUnitId,
                    Count = (int)itemT.quantity,
                    Price = (decimal)itemT.price,
                    Total = total,
                });
            }

            tb_count.Text = _Count.ToString();
            tb_barcode.Focus();

            refrishBillDetails();
        }
        void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;
        }
        private void inputEditable()
        {
            if (_InvoiceType == "pw") // wait purchase invoice
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                //cb_vendor.IsEnabled = false;
                //dp_desrvedDate.IsEnabled = false;
                //dp_invoiceDate.IsEnabled = false;
                //tb_note.IsEnabled = false;
                //tb_barcode.IsEnabled = false;
                //cb_branch.IsEnabled = false;
                //tb_discount.IsEnabled = false;
                //cb_typeDiscount.IsEnabled = false;
                //btn_save.IsEnabled = true;
                //btn_updateVendor.IsEnabled = false;
            }
            else if (_InvoiceType == "pbd")
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                dg_billDetails.Columns[4].IsReadOnly = false; //make count editable
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
                long newCount = 0;

                //"tb_amont"
                if (columnName == MainWindow.resourcemanager.GetString("trAmount"))
                    newCount = int.Parse(t.Text);
                else
                    newCount = row.Count;

                oldCount = row.Count;

                if (_InvoiceType == "pbd")
                {
                    ItemTransfer item = mainInvoiceItems.ToList().Find(i => i.itemUnitId == row.itemUnitId);
                    if (newCount > item.quantity)
                    {
                        // return old value 
                        t.Text = item.quantity.ToString();

                        newCount = (long)item.quantity;
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
                    }
                }
                _Count -= oldCount;
                _Count += newCount;
                tb_count.Text = _Count.ToString();

                // update item in billdetails           
                billDetails[index].Count = (int)newCount;
            }
        }

        private void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (billDetails.Count > 0)
            {
                if (_InvoiceType == "pw") //p  wait purchase invoice
                    await receiptInvoice();
                else if (_InvoiceType == "pbd")
                    await returnInvoice("pbw");
               
            }
            clearInvoice();
        }

        private async Task returnInvoice(string type)
        {
            if (invoice.invType == "p" && (_InvoiceType == "pbd" || _InvoiceType == "pbw"))
            {
                invoice.invoiceMainId = invoice.invoiceId;
                invoice.invoiceId = 0;
                invoice.branchId = invoice.branchCreatorId;
                invoice.branchCreatorId = MainWindow.branchID.Value;
                invoice.posId = MainWindow.posID.Value;

                string invoiceNum = await invoice.generateInvNumber("pb");
                invoice.invNumber = invoiceNum;
            }
            invoice.invType = type;
            invoice.createUserId = MainWindow.userID.Value;
            decimal total = 0;
            // calculate total and totalnet
            for (int i = 0; i < billDetails.Count; i++)
            {
                total += (decimal)billDetails[i].Price * (decimal)billDetails[i].Count;
            }
            invoice.total = total;
            invoice.taxtype = 2;
            decimal taxValue = SectionData.calcPercentage(total, (decimal)invoice.tax);
            invoice.totalNet = total + taxValue;
            invoice.paid = 0;
            invoice.deserved = invoice.totalNet;
            

            string res = await invoice.saveInvoice(invoice);
            if(res != "0")
            {
                int invoiceId = int.Parse(res);
                decimal returnValue = 0;
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                // add invoice items
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

                    returnValue += (decimal)itemT.price * (decimal)itemT.quantity;
                    invoiceItems.Add(itemT);
                }
                await invoiceModel.saveInvoiceItems(invoiceItems, invoiceId);
               
                //if (type == "pb")
                //{
                //    // cach transfer model
                //    CashTransfer cashTrasnfer = new CashTransfer();
                //    cashTrasnfer.transType = "d"; //deposit
                //    cashTrasnfer.posId = MainWindow.posID;
                //    cashTrasnfer.agentId = invoice.agentId;
                //    cashTrasnfer.invId = invoiceId;
                //    cashTrasnfer.transNum = SectionData.generateNumber('d', "v").ToString();
                //    cashTrasnfer.cash = returnValue;
                //    cashTrasnfer.side = "v"; // vendor
                //                             //cashTrasnfer.PaymentType
                //    cashTrasnfer.createUserId = MainWindow.userID;

                //    await cashTrasnfer.Save(cashTrasnfer); //add cash transfer

                //    Agent vendor = vendors.ToList().Find(b => b.agentId == invoice.agentId);
                //    decimal balance = 0;
                //    if (vendor != null)
                //        balance = (decimal)vendor.balance;
                //    await agentModel.updateBalance((int)invoice.agentId, balance);//update balance
                //}
            }
            else
            {
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }

        }
        private async Task receiptInvoice()
        {
            invoice.invType = "p";
            invoice.updateUserId = MainWindow.userID.Value;
           await invoiceModel.saveInvoice(invoice);
            await itemLocationModel.recieptInvoice(invoiceItems, MainWindow.branchID.Value,MainWindow.userID.Value); // increase item quantity in DB
        }
        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
    }
}

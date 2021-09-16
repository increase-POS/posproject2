using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using System.Windows.Threading;

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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this);
            }
        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        Category categoryModel = new Category();
        Category category = new Category();
        Item itemModel = new Item();
        Item item = new Item();

        Invoice invoiceModel = new Invoice();
        Invoice invoice = new Invoice();
        List<Invoice> invoices;
        List<ItemTransfer> invoiceItems;
        List<ItemTransfer> mainInvoiceItems;
        ItemLocation itemLocationModel = new ItemLocation();

        Agent agentModel = new Agent();
        IEnumerable<Agent> vendors;

        //Branch branchModel = new Branch();
       // IEnumerable<Branch> branches;
        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        static private string _BarcodeStr = "";
        static private object _Sender;
        //for bill details
        static private int _SequenceNum = 0;
        static private int _invoiceId;
        static private string _InvoiceType = "pbw"; // purchase bounce wait
        static private decimal _Count = 0;
        //tglItemState
        private static DispatcherTimer timer;
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////

            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trQuantity");

            txt_invoices.Text = MainWindow.resourcemanager.GetString("trInvoices");
            txt_returnInvoice.Text = MainWindow.resourcemanager.GetString("trReturnInvoices");

            tt_error_previous.Content = MainWindow.resourcemanager.GetString("trPrevious");
            tt_error_next.Content = MainWindow.resourcemanager.GetString("trNext");

        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                MainWindow.mainWindow.KeyDown += HandleKeyPress;

                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }

                translate();
                tb_barcode.Focus();
                setNotifications();
                setTimer();
                await RefrishVendors();
                //await RefrishBranches();
                #region datagridChange
                CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
                ((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
                #endregion
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #region notifications
        private void setTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        async void timer_Tick(object sendert, EventArgs et)
        {
            try
            {
                if (sendert != null)
                    SectionData.StartAwait(grid_main);
                refreshInvoiceNotification();
                refreshReturnNotification();
                if (sendert != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sendert != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void setNotifications()
        {
             refreshInvoiceNotification();
             refreshReturnNotification();
        }
        private async void refreshInvoiceNotification()
        {
            string invoiceType = "pw"; 
            int invoiceCount = await invoice.GetCountBranchInvoices(invoiceType,0, MainWindow.branchID.Value);
            if (invoice.invType == "pw")
                invoiceCount--;

            int previouseCount = 0;
            if (md_invoiceCount.Badge != null && md_invoiceCount.Badge.ToString() != "") previouseCount = int.Parse(md_invoiceCount.Badge.ToString());
            if (invoiceCount != previouseCount)
            {
                if (invoiceCount > 9)
                {
                    invoiceCount = 9;
                    md_invoiceCount.Badge = "+" + invoiceCount.ToString();
                }
                else if (invoiceCount == 0) md_invoiceCount.Badge = "";
                else
                    md_invoiceCount.Badge = invoiceCount.ToString();
            }
        }
        private async void refreshReturnNotification()
        {
            string invoiceType = "pbw";
            int returnsCount = await invoice.GetCountBranchInvoices(invoiceType,0, MainWindow.branchID.Value);
            if (invoice.invType == "pbw")
                returnsCount--;

            int previouseCount = 0;
            if (md_returnsCount.Badge != null && md_returnsCount.Badge.ToString() != "") previouseCount = int.Parse(md_returnsCount.Badge.ToString());

            if (returnsCount != previouseCount)
            {
                if (returnsCount > 9)
                {
                    returnsCount = 9;
                    md_returnsCount.Badge = "+" + returnsCount.ToString();
                }
                else if (returnsCount == 0) md_returnsCount.Badge = "";
                else
                    md_returnsCount.Badge = returnsCount.ToString();
            }
        }
       
        #endregion
        
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                MainWindow.mainWindow.KeyDown -= HandleKeyPress;
                clearInvoice();

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #region bill

        public class BillDetails
        {
            public int ID { get; set; }
            public int itemId { get; set; }
            public int itemUnitId { get; set; }
            public string Product { get; set; }
            public string UnitName { get; set; }
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
                {
                    switch (e.Key)
                    {
                        case Key.P:
                            //handle D key
                            //btn_printInvoice_Click(null, null);
                            break;
                        case Key.S:
                            //handle X key
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
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
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
                    clearInvoice();
                    invoice = await invoiceModel.GetInvoicesByNum(barcode, MainWindow.branchID.Value);
                    _InvoiceType = invoice.invType;
                    if (_InvoiceType.Equals("p") || _InvoiceType.Equals("pw"))
                    {
                        // set title to bill
                        if (_InvoiceType == "p")
                        {
                            txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                            brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                            _InvoiceType = "pbw";
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
                    clearInvoice();
                    invoice = await invoiceModel.GetInvoicesByNum(barcode, MainWindow.branchID.Value);
                    _InvoiceType = invoice.invType;
                    if (_InvoiceType == "pbw")
                    {
                        txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                        brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                    }

                    break;

                default:
                    break;
            }

            tb_barcode.Clear();
        }
        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

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
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion



        private async void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(returnPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;

                    wd_invoice w = new wd_invoice();

                    // sale invoices
                    string invoiceType = "pbw";
                    w.invoiceType = invoiceType;
                    w.invoiceStatus = "return";
                    w.branchId = MainWindow.branchID.Value;

                    w.title = MainWindow.resourcemanager.GetString("trReturnInvoices");

                    if (w.ShowDialog() == true)
                    {
                        if (w.invoice != null)
                        {
                            invoice = w.invoice;
                            _invoiceId = invoice.invoiceId;
                            _InvoiceType = invoice.invType;
                            setNotifications();
                            // set title to bill
                            txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                            btn_save.Content = MainWindow.resourcemanager.GetString("trReturn");
                            // orange #FFA926 red #D22A17
                            brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                            await fillInvoiceInputs(invoice);
                            mainInvoiceItems = invoiceItems;
                            invoices = await invoice.getBranchInvoices(invoiceType, 0, MainWindow.branchID.Value);
                            navigateBtnActivate();
                        }
                    }
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }



        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void clearInvoice()
        {
          
            _SequenceNum = 0;
            _Count = 0;
            _InvoiceType = "pbw";
            invoice = new Invoice();
            txt_branch.Text = "";
            txt_invNumber.Text = "";
            billDetails.Clear();
            tb_count.Text = "";
            refrishBillDetails();
            inputEditable();
            btn_next.Visibility = Visibility.Collapsed;
            btn_previous.Visibility = Visibility.Collapsed;
        }
        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var cmb = sender as ComboBox;

                if (dg_billDetails.SelectedIndex != -1 && cmb != null)
                    billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Cbm_unitItemDetails_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                //billDetails
                if (billDetails.Count == 1)
                {
                    var cmb = sender as ComboBox;
                    cmb.SelectedValue = (int)billDetails[0].itemUnitId;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

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

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                SectionData.InputJustNumber(ref textBox);
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
                if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                    e.Handled = false;

                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

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
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

         
        #region Get Id By Click  Y

        public   void ChangeCategoryIdEvent(int categoryId)
        {
            
        }
         
        public   void ChangeItemIdEvent(int itemId)
        {
           
        }
         
        #endregion
         
        private async void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(reciptPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;

                    wd_invoice w = new wd_invoice();

                    // sale invoices
                    string invoiceType = "pw";
                    w.invoiceType = invoiceType;
                    w.branchId = MainWindow.branchID.Value;

                    w.title = MainWindow.resourcemanager.GetString("trInvoices");

                    if (w.ShowDialog() == true)
                    {
                        if (w.invoice != null)
                        {
                            invoice = w.invoice;

                            _InvoiceType = invoice.invType;
                            _invoiceId = invoice.invoiceId;
                            setNotifications();
                            // set title to bill
                            txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
                            btn_save.Content = MainWindow.resourcemanager.GetString("trStoreBtn");

                            // orange #FFA926 red #D22A17
                            brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                            await fillInvoiceInputs(invoice);
                            invoices = await invoice.getBranchInvoices(invoiceType,0, MainWindow.branchID.Value);
                            navigateBtnActivate();
                        }
                    }
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async Task fillInvoiceInputs(Invoice invoice)
        {
            txt_branch.Text = invoice.branchName;
            txt_invNumber.Text = invoice.invNumber;

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
                    UnitName = itemT.unitName,
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
                 
            }
            else if (_InvoiceType == "pbw")
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column visible
                dg_billDetails.Columns[4].IsReadOnly = true; //make count editable
            }
            btn_next.Visibility = Visibility.Visible;
            btn_previous.Visibility = Visibility.Visible;
        }

        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
                var columnName = e.Column.Header.ToString();

                BillDetails row = e.Row.Item as BillDetails;
                int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == row.itemUnitId).FirstOrDefault());

                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds < 100)
                {
                    if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
                        t.Text = billDetails[index].Count.ToString();
                }
                else
                {
                    int oldCount = 0;
                    long newCount = 0;

                    //"tb_amont"
                    if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
                        newCount = int.Parse(t.Text);
                    else
                        newCount = row.Count;

                    oldCount = row.Count;

                    if (_InvoiceType == "pbw")
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
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (billDetails.Count > 0)
                {
                    if (_InvoiceType == "pw") //p  wait purchase invoice
                        await receiptInvoice();
                    else if (_InvoiceType == "pbw")
                        await returnInvoice("pb");
                }

                //clearInvoice();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async Task returnInvoice(string type)
        {

            invoiceItems = new List<ItemTransfer>();
            ItemTransfer itemT;
            decimal returnValue = 0;
            for (int i = 0; i < billDetails.Count; i++)
            {
                itemT = new ItemTransfer();

                // itemT.invoiceId = invoiceId;
                itemT.itemName = billDetails[i].Product;
                itemT.itemId = billDetails[i].itemId;
                itemT.unitName = billDetails[i].Unit;
                itemT.quantity = billDetails[i].Count;
                itemT.price = billDetails[i].Price;
                itemT.itemUnitId = billDetails[i].itemUnitId;
                itemT.createUserId = MainWindow.userID;

                returnValue += (decimal)itemT.price * (decimal)itemT.quantity;
                invoiceItems.Add(itemT);
            }

            Window.GetWindow(this).Opacity = 0.2;
            wd_transItemsLocation w;
            w = new wd_transItemsLocation();
            w.orderList = invoiceItems;
            if (w.ShowDialog() == true)
            {
                if (w.selectedItemsLocations != null)
                {
                    List<ItemLocation> itemsLocations = w.selectedItemsLocations;
                    List<ItemLocation> readyItemsLoc = new List<ItemLocation>();

                    for (int i = 0; i < itemsLocations.Count; i++)
                    {
                        if (itemsLocations[i].isSelected == true)
                            readyItemsLoc.Add(itemsLocations[i]);
                    }

                    invoice.invType = type;
                    invoice.updateUserId = MainWindow.userID.Value;
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

                    int invoiceId = int.Parse(await invoiceModel.saveInvoice(invoiceModel));
                    if (invoiceId != 0)
                    {
                        await invoice.recordPosCashTransfer(invoice, "pb");
                        await invoice.recordCashTransfer(invoice, "pb");
                        await invoiceModel.saveInvoiceItems(invoiceItems, invoiceId);

                        #region notification Object
                        Notification not = new Notification()
                        {
                            title = "trExceedMinLimitAlertTilte",
                            ncontent = "trExceedMinLimitAlertContent",
                            msgType = "alert",
                            createDate = DateTime.Now,
                            updateDate = DateTime.Now,
                            createUserId = MainWindow.userID.Value,
                            updateUserId = MainWindow.userID.Value,
                        };
                        #endregion
                        for (int i = 0; i < readyItemsLoc.Count; i++)
                        {
                            int itemLocId = readyItemsLoc[i].itemsLocId;
                            int quantity = (int)readyItemsLoc[i].quantity;
                            await itemLocationModel.decreaseItemLocationQuantity(itemLocId, quantity, MainWindow.userID.Value, "storageAlerts_minMaxItem", not);
                        }
                        refreshReturnNotification();
                        clearInvoice();
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                        Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
            }
            Window.GetWindow(this).Opacity = 1;

             
        }
        private async Task receiptInvoice()
        {
            #region notification Object
            Notification not = new Notification()
            {
                title = "trExceedMaxLimitAlertTilte",
                ncontent = "trExceedMaxLimitAlertContent",
                msgType = "alert",
                createDate = DateTime.Now,
                updateDate = DateTime.Now,
                createUserId = MainWindow.userID.Value,
                updateUserId = MainWindow.userID.Value,
            };
            #endregion
            invoice.invType = "p";
            invoice.updateUserId = MainWindow.userID.Value;
            await invoiceModel.saveInvoice(invoice);
            await itemLocationModel.recieptInvoice(invoiceItems, MainWindow.branchID.Value, MainWindow.userID.Value, "storageAlerts_minMaxItem", not); // increase item quantity in DB
             refreshInvoiceNotification();
            clearInvoice();
        }


        private void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (invoiceItems != null)
                    {
                        Thread t1 = new Thread(() =>
                        {
                            printReceipt();
                        });
                        t1.Start();
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void printReceipt()
        {

            BuildReport();

            this.Dispatcher.Invoke(() =>
            {
                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
            });
        }

        private void pdfReceipt()
        {
            BuildReport();

            this.Dispatcher.Invoke(() =>
            {
                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
                }
            });
        }
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();
            //ReceiptPurchase
            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
               addpath = @"\Reports\Store\Ar\ArReceiptPurchaseReport.rdlc";//////??????????
            }
            else
                addpath = @"\Reports\Store\En\ReceiptPurchaseReport.rdlc";/////////////?????????????
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.ReceiptPurchaseReport(invoiceItems, rep, reppath, paramarr);/////??????????????
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    if (invoiceItems != null)
                    {
                        Window.GetWindow(this).Opacity = 0.2;
                    /////////////////////
                    string pdfpath = "";
                    pdfpath = @"\Thumb\report\temp.pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                    BuildReport();
                    LocalReportExtensions.ExportToPDF(rep, pdfpath);
                    ///////////////////
                    wd_previewPdf w = new wd_previewPdf();
                    w.pdfPath = pdfpath;
                    if (!string.IsNullOrEmpty(w.pdfPath))
                    {
                        w.ShowDialog();
                        w.wb_pdfWebViewer.Dispose();
                    }
                    Window.GetWindow(this).Opacity = 1;
                    //////////////////////////////////////
                    }
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (invoiceItems !=null)
                    {
                        Thread t1 = new Thread(() =>
                    {
                        pdfReceipt();
                    });
                        t1.Start();
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #region navigation buttons
        private void navigateBtnActivate()
        {
            int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
            if (index == invoices.Count - 1)
                btn_next.IsEnabled = false;
            else
                btn_next.IsEnabled = true;

            if (index == 0)
                btn_previous.IsEnabled = false;
            else
                btn_previous.IsEnabled = true;
        }
        private async void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
            index++;
            clearInvoice();
            invoice = invoices[index];
            _InvoiceType = invoice.invType;
            _invoiceId = invoice.invoiceId;
            navigateBtnActivate();
            await fillInvoiceInputs(invoice);
        }
        private async void Btn_previous_Click(object sender, RoutedEventArgs e)
        {
            int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
            index--;
            clearInvoice();
            invoice = invoices[index];
            _InvoiceType = invoice.invType;
            _invoiceId = invoice.invoiceId;
            navigateBtnActivate();
            await fillInvoiceInputs(invoice);
        }
        #endregion

    }
}

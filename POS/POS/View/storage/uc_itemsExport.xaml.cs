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
    /// Interaction logic for uc_itemsExport.xaml
    /// </summary>
    public partial class uc_itemsExport : UserControl
    {
        string importPermission = "importExport_import";
        string exportPermission = "importExport_export";
        string reportsPermission = "importExport_reports";
        string packagePermission = "importExport_package";
        string unitConversionPermission = "importExport_unitConversion";
        string initializeShortagePermission = "importExport_initializeShortage";
        string deliveryPermission = "salesOrders_delivery";
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
        Branch branchModel = new Branch();
       // IEnumerable<Branch> branches;

        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;

        ItemLocation itemLocationModel = new ItemLocation();
        Invoice invoice = new Invoice();
        Invoice generatedInvoice = new Invoice();
        List<Invoice> invoices;
        List<ItemTransfer> invoiceItems;
        List<ItemTransfer> mainInvoiceItems;

        User userModel = new User();
        List<User> users;
        ShippingCompanies companyModel = new ShippingCompanies();
        List<ShippingCompanies> companies;
        public List<Control> controls;
        static private string _ProcessType = "imd"; //draft import

        static private int _SequenceNum = 0;
        static private int _Count = 0;
        static private int _invoiceId;
        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        static private string _BarcodeStr = "";
        static private string _SelectedProcess = "";
        static private int _SelectedBranch = -1;
        bool _IsFocused = false;
        static private int _SelectedCompany = -1;
        static private int _SelectedUser = -1;
        static private decimal _DeliveryCost = 0;

        private static DispatcherTimer timer;
        Pos pos = new Pos();

        Category categoryModel = new Category();
        Category category = new Category();

        //IEnumerable<Category> categories;
        //IEnumerable<Category> categoriesQuery;
        //int? categoryParentId = 0;
        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;
        //IEnumerable<Item> itemsQuery;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;
        //tglItemState
        bool isClose = false;
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
            ////////////////////////////////----Order----/////////////////////////////////
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trQuantity");

            txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trItemsImport/Export");
            tt_error_previous.Content = MainWindow.resourcemanager.GetString("trPrevious");
            tt_error_next.Content = MainWindow.resourcemanager.GetString("trNext");


        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                MainWindow.mainWindow.KeyDown -= HandleKeyPress;

                if (billDetails.Count > 0 && (_ProcessType == "imd" || _ProcessType == "exd"))
                {
                    #region Accept
                    MainWindow.mainWindow.Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    //w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                    w.contentText = "Do you want save sale invoice in drafts?";
                    w.ShowDialog();
                    MainWindow.mainWindow.Opacity = 1;
                    #endregion
                    if (w.isOk || isClose == true)
                        Btn_newDraft_Click(null, null);
                    else
                        clearProcess();
                }
                else
                    clearProcess();
                timer.Stop();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                //SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                MainWindow.mainWindow.KeyDown += HandleKeyPress;
                MainWindow.mainWindow.Closing += ParentWin_Closing;

                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", assembly: Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }

                translate();
                catigoriesAndItemsView.ucItemsExport = this;
                setNotifications();
                setTimer();
                configureProcessType();
                pos = await pos.getById(MainWindow.posID.Value);
                branchModel = await branchModel.getBranchById(MainWindow.branchID.Value);
                await SectionData.fillWithoutCurrent(cb_branch, MainWindow.branchID.Value);
                //await RefrishBranches();
                await RefrishItems();
                //await fillShippingCompanies();
                //await fillUsers();
                await fillBarcodeList();
                //List all the UIElement in the VisualTree
                controls = new List<Control>();
                FindControl(this.grid_main, controls);
                #region datagridChange
                //CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
                //((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
                #endregion


                #region Permision


                if (MainWindow.groupObject.HasPermissionAction(exportPermission, MainWindow.groupObjects, "one"))
                    md_orderWaitCount.Visibility = Visibility.Visible;
                else
                    md_orderWaitCount.Visibility = Visibility.Collapsed;

                if (MainWindow.groupObject.HasPermissionAction(initializeShortagePermission, MainWindow.groupObjects, "one"))
                {
                    btn_shortageInvoice.Visibility = Visibility.Visible;
                    bdr_shortageInvoice.Visibility = Visibility.Visible;
                }
                else
                {
                    btn_shortageInvoice.Visibility = Visibility.Collapsed;
                    bdr_shortageInvoice.Visibility = Visibility.Collapsed;
                }

                if (MainWindow.groupObject.HasPermissionAction(packagePermission, MainWindow.groupObjects, "one"))
                    btn_package.Visibility = Visibility.Visible;
                else
                    btn_package.Visibility = Visibility.Collapsed;

                if (MainWindow.groupObject.HasPermissionAction(unitConversionPermission, MainWindow.groupObjects, "one"))
                    btn_unitConversion.Visibility = Visibility.Visible;
                else
                    btn_unitConversion.Visibility = Visibility.Collapsed;

                if (!MainWindow.groupObject.HasPermissionAction(packagePermission, MainWindow.groupObjects, "one")
                    && !MainWindow.groupObject.HasPermissionAction(unitConversionPermission, MainWindow.groupObjects, "one"))
                    bdr_package_converter.Visibility = Visibility.Collapsed;
                

                #endregion

                if (sender != null)
                    SectionData.EndAwait(grid_main);
                tb_barcode.Focus();
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void ParentWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isClose = true;
            UserControl_Unloaded(this, null);
        }
        public void FindControl(DependencyObject root, List<Control> controls)
        {
            controls.Clear();
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var control = current as Control;
                if (control != null && control.IsTabStop)
                {
                    controls.Add(control);
                }
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    if (child != null)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }
        #region timer to refresh notifications
        private void setTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        async   void timer_Tick(object sendert, EventArgs et)
        {
            try
            {
                setNotifications();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        #region notifications
        private async void setNotifications()
        {
            try
            {
                refreshDraftNotification();
             refreshOrderWaitNotification();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void refreshDraftNotification()
        {
            string invoiceType = "imd ,exd";
            int duration = 2;
            int draftCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);
            if (invoice.invType == "imd" || invoice.invType == "exd")
                draftCount--;

            int previouseCount = 0;
            if (md_draftsCount.Badge != null && md_draftsCount.Badge.ToString() != "") previouseCount = int.Parse(md_draftsCount.Badge.ToString());

            if (draftCount != previouseCount)
            {
                if (draftCount > 9)
                {
                    draftCount = 9;
                    md_draftsCount.Badge = "+" + draftCount.ToString();
                }
                else if (draftCount == 0) md_draftsCount.Badge = "";
                else
                    md_draftsCount.Badge = draftCount.ToString();
            }
        }
        private async void refreshOrderWaitNotification()
        {
            try
            {
                string invoiceType = "exw";

                int waitedOrdersCount = await invoice.GetCountBranchInvoices(invoiceType, 0, MainWindow.branchID.Value);
                if (invoice.invType == "exw")
                    waitedOrdersCount--;

                int previouseCount = 0;
                if (md_orderWaitCount.Badge != null && md_orderWaitCount.Badge.ToString() != "") previouseCount = int.Parse(md_orderWaitCount.Badge.ToString());

                if (waitedOrdersCount != previouseCount)
                {
                    if (waitedOrdersCount > 9)
                    {
                        waitedOrdersCount = 9;
                        md_orderWaitCount.Badge = "+" + waitedOrdersCount.ToString();
                    }
                    else if (waitedOrdersCount == 0) md_orderWaitCount.Badge = "";
                    else
                        md_orderWaitCount.Badge = waitedOrdersCount.ToString();
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        #endregion

        async Task RefrishItems()
        {
            items = await itemModel.GetAllItems();
        }
        private async Task fillUsers()
        {
            users = await userModel.getBranchSalesMan(MainWindow.branchID.Value, deliveryPermission);
            //cb_user.ItemsSource = users;
            //cb_user.DisplayMemberPath = "name";
            //cb_user.SelectedValuePath = "userId";
        }
        private async Task fillShippingCompanies()
        {
            companies = await companyModel.Get();
            //cb_company.ItemsSource = companies;
            //cb_company.DisplayMemberPath = "name";
            //cb_company.SelectedValuePath = "shippingCompanyId";
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
            try
            {
                if (!_IsFocused)
                {
                    Control c = CheckActiveControl();
                    if (c == null)
                        tb_barcode.Focus();
                    _IsFocused = true;
                }
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
                {
                    switch (e.Key)
                    {
                        case Key.P:
                            //handle P key
                            Btn_printInvoice_Click(null, null);
                            break;
                        case Key.S:
                            //handle S key
                            Btn_save_Click(null, null);
                            break;
                        case Key.I:
                            //handle S key
                            Btn_items_Click(null, null);
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
                    e.Handled = true;
                }
                _BarcodeStr = "";
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
        public Control CheckActiveControl()
        {
            for (int i = 0; i < controls.Count; i++)
            {
                Control c = controls[i];
                if (c.IsFocused)
                {
                    return c;
                }
            }
            return null;
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
        private async void Tb_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (e.Key == Key.Return)
                {
                    string barcode = "";
                    if (_BarcodeStr.Length < 13)
                    {
                        barcode = tb_barcode.Text;
                        await dealWithBarcode(barcode);
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

        }
        bool firstTimeForDatagrid = true;
        async void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;
            if (firstTimeForDatagrid)
            {
                await Task.Delay(1000);
                dg_billDetails.Items.Refresh();
                firstTimeForDatagrid = false;
            }
            DataGrid_CollectionChanged(dg_billDetails, null);
            tb_count.Text = _Count.ToString();
        }
        void refrishDataGridItems()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;
            dg_billDetails.Items.Refresh();
            DataGrid_CollectionChanged(dg_billDetails, null);

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
            public int OrderId { get; set; }
        }
        #endregion

        #region Button In DataGrid
        void deleteRowFromOrderItems(object sender, RoutedEventArgs e)
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
                        //refreshTotalValue();
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





        private async void Btn_orders_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

                if ((
                       MainWindow.groupObject.HasPermissionAction(importPermission, MainWindow.groupObjects, "one")
                       || SectionData.isAdminPermision()
                       ) &&
                     (
                     MainWindow.groupObject.HasPermissionAction(exportPermission, MainWindow.groupObjects, "one")
                     || SectionData.isAdminPermision()
                     ))
                    w.invoiceType = "im ,ex";
                else if (MainWindow.groupObject.HasPermissionAction(importPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                    w.invoiceType = "im";
                else if (MainWindow.groupObject.HasPermissionAction(exportPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                    w.invoiceType = "ex";



                w.condition = "order";
                w.title = MainWindow.resourcemanager.GetString("trOrders");
                w.branchId = MainWindow.branchID.Value;

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;
                        _ProcessType = invoice.invType;
                        _invoiceId = invoice.invoiceId;
                        setNotifications();
                        await fillOrderInputs(invoice);
                        if (_ProcessType == "im")// set title to bill
                        {
                            //  mainInvoiceItems = invoiceItems;

                        }
                        else if (_ProcessType == "ex")
                        {
                            //   mainInvoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceMainId.Value);

                        }
                        invoices = await invoice.getBranchInvoices(w.invoiceType, 0, MainWindow.branchID.Value);
                        navigateBtnActivate();
                    }
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

        private async void Btn_ordersWait_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(exportPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_invoice w = new wd_invoice();

                    w.invoiceType = "exw";
                    w.title = MainWindow.resourcemanager.GetString("trOrders");
                    w.branchId = MainWindow.branchID.Value;

                    if (w.ShowDialog() == true)
                    {
                        if (w.invoice != null)
                        {
                            invoice = w.invoice;
                            _ProcessType = invoice.invType;
                            _invoiceId = invoice.invoiceId;
                            setNotifications();
                            await fillOrderInputs(invoice);
                            invoices = await invoice.getBranchInvoices(w.invoiceType, 0,MainWindow.branchID.Value);
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
        private void Btn_package_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(packagePermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_generatePackage w = new wd_generatePackage();

                    if (w.ShowDialog() == true)
                    {

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
        private void Btn_unitConversion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(unitConversionPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_unitConversion w = new wd_unitConversion();
                    if (w.ShowDialog() == true)
                    {

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
                if (name == "ComboBox")
                {
                    if ((sender as ComboBox).Name == "cb_branch")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private async void Btn_items_Click(object sender, RoutedEventArgs e)
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
                    // ChangeItemIdEvent(w.selectedItem);
                    for (int i = 0; i < w.selectedItems.Count; i++)
                    {
                        int itemId = w.selectedItems[i];
                        await ChangeItemIdEvent(itemId);
                    }
                refrishBillDetails();
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

        public void ChangeCategoryIdEvent(int categoryId)
        {

        }


        public async Task ChangeItemIdEvent(int itemId)
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

                    //_Count++;
                    //refrishBillDetails();
                }
                else
                {
                    addRowToBill(item.name, itemId, null, 0, 1);
                }
                _Count++;
            }
        }

        #endregion
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

        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);

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
                //refrishBillDetails();

                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion

        private async void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (billDetails.Count != 0)
                {
                    await saveDraft();
                    setNotifications();
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
        private void clearProcess()
        {
            _Count = 0;
            _SequenceNum = 0;
            _SelectedBranch = -1;
            _DeliveryCost = 0;
            _SelectedProcess = "imd";
            _ProcessType = "imd";
            invoice = new Invoice();
            generatedInvoice = new Invoice();
            tb_barcode.Clear();
            cb_branch.SelectedIndex = -1;
            billDetails.Clear();

            SectionData.clearComboBoxValidate(cb_branch, p_errorBranch);
            refrishBillDetails();
            inputEditable();
            btn_next.Visibility = Visibility.Collapsed;
            btn_previous.Visibility = Visibility.Collapsed;
        }
        private async Task saveDraft()
        {
            int invoiceId;
            invoiceItems = new List<ItemTransfer>();
            ItemTransfer itemT;
            for (int i = 0; i < billDetails.Count; i++)
            {
                itemT = new ItemTransfer();

                itemT.quantity = billDetails[i].Count;
                itemT.price = billDetails[i].Price;
                itemT.itemUnitId = billDetails[i].itemUnitId;
                itemT.createUserId = MainWindow.userID;
                itemT.invoiceId = billDetails[i].OrderId;

                invoiceItems.Add(itemT);
            }
            switch (_ProcessType)
            {
                case "imd":// add or edit import order then add export order
                           // import order
                    invoice.invType = _ProcessType;
                    invoice.branchId = MainWindow.branchID.Value;
                    invoice.createUserId = MainWindow.userID;
                    invoice.updateUserId = MainWindow.userID;
                    if (invoice.invNumber == null)
                        invoice.invNumber = await invoice.generateInvNumber("im",branchModel.code, MainWindow.branchID.Value);
                    // save invoice in DB
                    invoiceId = await invoice.saveInvoice(invoice);
                    if (invoiceId != 0)
                    {
                        // expot order
                        if (invoice.invoiceId == 0) // create new export order
                        {
                            invoice = new Invoice();
                            invoice.invType = "exi";
                            invoice.invoiceMainId = invoiceId;
                            if (cb_branch.SelectedIndex != -1)
                                invoice.branchId = (int)cb_branch.SelectedValue;
                            invoice.invNumber = await invoice.generateInvNumber("ex", branchModel.code, MainWindow.branchID.Value);
                            invoice.createUserId = MainWindow.userID;
                        }
                        else // edit exit export order
                        {
                            invoice = await invoice.getgeneratedInvoice(invoiceId);
                            if (cb_branch.SelectedIndex != -1)
                                invoice.branchId = (int)cb_branch.SelectedValue;
                            invoice.updateUserId = MainWindow.userID;
                        }
                        int exportId = await invoice.saveInvoice(invoice);

                        // add order details                      
                        await invoice.saveInvoiceItems(invoiceItems, invoiceId);
                        await invoice.saveInvoiceItems(invoiceItems, exportId);

                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                        Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    break;
                case "exd":// add or edit export order then add import order
                           // import order
                    invoice.invType = _ProcessType;
                    invoice.branchId = MainWindow.branchID.Value;
                    invoice.createUserId = MainWindow.userID;
                    invoice.updateUserId = MainWindow.userID;
                    if (invoice.invNumber == null)
                        invoice.invNumber = await invoice.generateInvNumber("ex", branchModel.code, MainWindow.branchID.Value);
                    // save invoice in DB
                    invoiceId = await invoice.saveInvoice(invoice);

                    if (invoiceId != 0)
                    {
                        // import order
                        if (invoice.invoiceId == 0) // create new export order
                        {
                            invoice = new Invoice();
                            invoice.invType = "imi";
                            invoice.invoiceMainId = invoiceId;
                            if (cb_branch.SelectedIndex != -1)
                                invoice.branchId = (int)cb_branch.SelectedValue;
                            invoice.invNumber = await invoice.generateInvNumber("im", branchModel.code, MainWindow.branchID.Value);
                            invoice.createUserId = MainWindow.userID;
                        }
                        else // edit exit export order
                        {
                            invoice = await invoice.getgeneratedInvoice(invoiceId);
                            if (cb_branch.SelectedIndex != -1)
                                invoice.branchId = (int)cb_branch.SelectedValue;
                            invoice.updateUserId = MainWindow.userID;
                        }
                        int importId = await invoice.saveInvoice(invoice);

                        // add order details
                        await invoice.saveInvoiceItems(invoiceItems, invoiceId);
                        await invoice.saveInvoiceItems(invoiceItems, importId);

                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                        Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    break;
            }
            clearProcess();
        }

        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();
                string  invoiceType = "imd ,exd";
                int duration = 2;
                w.invoiceType = invoiceType;
                w.userId = MainWindow.userLogin.userId;
                w.duration = duration; // view drafts which updated during 2 last days 
                w.title = MainWindow.resourcemanager.GetString("trDrafts");
                // w.branchId = MainWindow.branchID.Value;

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;
                        _ProcessType = invoice.invType;
                        _invoiceId = invoice.invoiceId;
                        setNotifications();
                        await fillOrderInputs(invoice);
                        if (_ProcessType == "imd")// set title to bill
                        {
                            //  mainInvoiceItems = invoiceItems;

                        }
                        else if (_ProcessType == "exd")
                        {
                            //   mainInvoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceMainId.Value);

                        }
                        invoices = await invoice.GetInvoicesByCreator(invoiceType, MainWindow.userLogin.userId, duration);
                        navigateBtnActivate();
                    }
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
        private async Task fillOrderInputs(Invoice invoice)
        {
            if (invoice.invoiceMainId == null)
                generatedInvoice = await invoice.getgeneratedInvoice(invoice.invoiceId);
            else
                generatedInvoice = await invoice.getById((int)invoice.invoiceMainId);
            _Count = invoice.itemsCount.Value;
            tb_count.Text = _Count.ToString();

            cb_branch.SelectedValue = generatedInvoice.branchId;
            switch (_ProcessType)
            {
                case "imd":
                case "im":
                case "imw":
                    cb_processType.SelectedIndex = 0;
                    cb_processType.SelectedValue = "im";
                    break;
                case "exd":
                case "ex":
                case "exw":
                    cb_processType.SelectedIndex = 1;
                    cb_processType.SelectedValue = "ex";
                    break;
            }

            // build invoice details grid
            await buildInvoiceDetails();

            inputEditable();
        }
        private async Task buildInvoiceDetails()
        {
            //get invoice items
            invoiceItems = await invoice.GetInvoicesItems(invoice.invoiceId);
            // build invoice details grid
            _SequenceNum = 0;
            billDetails.Clear();
            foreach (ItemTransfer itemT in invoiceItems)
            {
                _SequenceNum++;
                decimal total = (decimal)(itemT.price * itemT.quantity);
                int orderId = 0;
                if (itemT.invoiceId != null)
                    orderId = (int)itemT.invoiceId;
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
                    OrderId = orderId,
                });
            }
            tb_barcode.Focus();

            refrishBillDetails();
        }
        private void inputEditable()
        {
            if (invoice.invoiceId == 0)
                cb_processType.IsEnabled = true;
            else
                cb_processType.IsEnabled = false;

            if (_ProcessType == "imd" || _ProcessType == "exd") // return invoice
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete hidden
                dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                cb_processType.IsEnabled = true;
                cb_branch.IsEnabled = true;
                tb_barcode.IsEnabled = true;
                btn_save.IsEnabled = true;
            }
            else if (_ProcessType == "im" || _ProcessType == "ex")
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete hidden
                dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                cb_branch.IsEnabled = false;
                tb_barcode.IsEnabled = false;
                btn_save.IsEnabled = false;

            }
            else if (_ProcessType == "imw")
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete hidden
                dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                cb_branch.IsEnabled = false;
                tb_barcode.IsEnabled = false;
                btn_save.IsEnabled = true;
            }
            else if (_ProcessType == "exw")
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete hidden
                dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                cb_branch.IsEnabled = false;
                tb_barcode.IsEnabled = false;
                btn_save.IsEnabled = true;
            }
            btn_next.Visibility = Visibility.Visible;
            btn_previous.Visibility = Visibility.Visible;
        }
        private async Task save()
        {
            int invoiceId;
            invoiceItems = new List<ItemTransfer>();
            ItemTransfer itemT;
            for (int i = 0; i < billDetails.Count; i++)
            {
                itemT = new ItemTransfer();

                itemT.quantity = billDetails[i].Count;
                itemT.price = billDetails[i].Price;
                itemT.itemUnitId = billDetails[i].itemUnitId;
                itemT.createUserId = MainWindow.userID;
                itemT.invoiceId = billDetails[i].OrderId;
                invoiceItems.Add(itemT);
            }
            switch (_ProcessType)
            {
                case "imd":// add or edit import order then add export order
                           // import order
                    invoice.invType = "im";
                    invoice.branchId = MainWindow.branchID.Value;
                    invoice.posId = MainWindow.posID.Value;
                    invoice.createUserId = MainWindow.userID;
                    invoice.updateUserId = MainWindow.userID;
                    if (invoice.invNumber == null)
                        invoice.invNumber = await invoice.generateInvNumber("im", branchModel.code, MainWindow.branchID.Value);
                    // save invoice in DB
                    invoiceId = await invoice.saveInvoice(invoice);
                    if (invoiceId != 0)
                    {
                        #region notification Object
                        Notification not = new Notification()
                        {
                            title = "trExportAlertTilte",
                            ncontent = "trExportAlertContent",
                            msgType = "alert",
                            createUserId = MainWindow.userID.Value,
                            updateUserId = MainWindow.userID.Value,
                        };
                       await not.save(not, (int) cb_branch.SelectedValue, "storageAlerts_ImpExp", cb_branch.Text);
                        #endregion
                        // expot order
                        if (invoice.invoiceId == 0) // create new export order
                        {
                            invoice = new Invoice();
                            invoice.invType = "exw";
                            invoice.invoiceMainId = invoiceId;
                            if (cb_branch.SelectedIndex != -1)
                                invoice.branchId = (int)cb_branch.SelectedValue;
                            invoice.invNumber = await invoice.generateInvNumber("ex", branchModel.code, MainWindow.branchID.Value);
                            invoice.createUserId = MainWindow.userID;
                        }
                        else // edit exit export order
                        {
                            invoice = await invoice.getgeneratedInvoice(invoiceId);
                            invoice.invType = "exw";
                            if (cb_branch.SelectedIndex != -1)
                                invoice.branchId = (int)cb_branch.SelectedValue;
                            invoice.updateUserId = MainWindow.userID;
                        }
                        int exportId = await invoice.saveInvoice(invoice);

                        // add order details                      
                        await invoice.saveInvoiceItems(invoiceItems, invoiceId);
                        await invoice.saveInvoiceItems(invoiceItems, exportId);

                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                        Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    break;
                case "exd":// add or edit export order then add import order
                           // import order
                    invoice.invType = "ex";
                    invoice.branchId = MainWindow.branchID.Value;
                    invoice.posId = MainWindow.posID.Value;
                    invoice.createUserId = MainWindow.userID;
                    invoice.updateUserId = MainWindow.userID;
                    if (invoice.invNumber == null)
                        invoice.invNumber = await invoice.generateInvNumber("ex", branchModel.code, MainWindow.branchID.Value);
                    // save invoice in DB
                    invoiceId = await invoice.saveInvoice(invoice);

                    if (invoiceId != 0)
                    {
                        // import order
                        if (invoice.invoiceId == 0) // create new export order
                        {
                            invoice = new Invoice();
                            invoice.invType = "im";
                            invoice.invoiceMainId = invoiceId;
                            if (cb_branch.SelectedIndex != -1)
                                invoice.branchId = (int)cb_branch.SelectedValue;
                            invoice.invNumber = await invoice.generateInvNumber("im", branchModel.code, MainWindow.branchID.Value);
                            invoice.createUserId = MainWindow.userID;
                        }
                        else // edit exit export order
                        {
                            invoice = await invoice.getgeneratedInvoice(invoiceId);
                            invoice.invType = "im";
                            if (cb_branch.SelectedIndex != -1)
                                invoice.branchId = (int)cb_branch.SelectedValue;
                            invoice.updateUserId = MainWindow.userID;
                        }
                        int importId = await invoice.saveInvoice(invoice);

                        // add order details
                        await invoice.saveInvoiceItems(invoiceItems, invoiceId);
                        await invoice.saveInvoiceItems(invoiceItems, importId);

                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                        Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    break;
                case "exw":
                    invoice.invType = "ex";
                    invoice.updateUserId = MainWindow.userID;
                    // save invoice in DB
                    invoiceId = await invoice.saveInvoice(invoice);
                    if (invoiceId != 0)
                    {
                        await invoice.saveInvoiceItems(invoiceItems, invoiceId);
                        await invoice.saveInvoiceItems(invoiceItems, invoice.invoiceMainId.Value);
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                    {
                        Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                    break;
            }
            clearProcess();
        }
        private async Task<bool> validateOrder()
        {
            bool valid = true;
            if (cb_branch.SelectedIndex == -1 || billDetails.Count == 0)
                valid = false;

            valid = await checkItemsAmounts();
            if (billDetails.Count == 0)
                clearProcess();
            else
                if (!SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, MainWindow.resourcemanager.GetString("trEmptyBranchToolTip")))
                exp_store.IsExpanded = true;

            return valid;
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (
                        ((_ProcessType == "im" || _ProcessType == "imd")
                        && (MainWindow.groupObject.HasPermissionAction(importPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision()))
                        ||
                        ((_ProcessType == "ex" || _ProcessType == "exd")
                        && (MainWindow.groupObject.HasPermissionAction(exportPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision()))
                        )
                {
                    bool valid = await validateOrder();
                    if (valid)
                    {
                        wd_transItemsLocation w;
                        switch (_ProcessType)
                        {
                            case "exw":
                            case "exd":
                                Window.GetWindow(this).Opacity = 0.2;
                                w = new wd_transItemsLocation();
                                List<ItemTransfer> orderList = new List<ItemTransfer>();
                            List<int> ordersIds = new List<int>();
                                foreach (BillDetails d in billDetails)
                                {
                                    if (d.Count == 0)
                                    {
                                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorQuantIsZeroToolTip"), animation: ToasterAnimation.FadeIn);
                                        if (sender != null)
                                            SectionData.EndAwait(grid_main);
                                        return;
                                    }
                                    else
                                    {
                                        orderList.Add(new ItemTransfer()
                                        {
                                            itemName = d.Product,
                                            itemId = d.itemId,
                                            unitName = d.Unit,
                                            itemUnitId = d.itemUnitId,
                                            quantity = d.Count,
                                            invoiceId = d.OrderId,
                                        });
                                        ordersIds.Add(d.OrderId);
                                    }
                                }
                                w.orderList = orderList;
                                if (w.ShowDialog() == true)
                                {
                                    if (w.selectedItemsLocations != null)
                                    {
                                        List<ItemLocation> itemsLocations = w.selectedItemsLocations;
                                        List<ItemLocation> readyItemsLoc = new List<ItemLocation>();

                                        // _ProcessType ="ex";
                                        for (int i = 0; i < itemsLocations.Count; i++)
                                        {
                                            if (itemsLocations[i].isSelected == true)
                                                readyItemsLoc.Add(itemsLocations[i]);
                                        }
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
                                    await itemLocationModel.recieptOrder(readyItemsLoc,orderList, (int)cb_branch.SelectedValue, MainWindow.userID.Value, "storageAlerts_minMaxItem", not);
                                        await save();
                                    }
                                }
                                Window.GetWindow(this).Opacity = 1;
                                break;
                            case "emw":
                                //process transfer items
                                await save();
                                break;
                            default:
                                await save();
                                break;
                        }
                        setNotifications();

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

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);

                TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
                var columnName = e.Column.Header.ToString();

                BillDetails row = e.Row.Item as BillDetails;
                int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == row.itemUnitId && p.OrderId == row.OrderId).FirstOrDefault());

                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds < 100)
                {
                    if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
                        t.Text = billDetails[index].Count.ToString();
                }
                else
                {
                    int availableAmount = 0;

                    int oldCount = 0;
                    if (!t.Text.Equals(""))
                        oldCount = int.Parse(t.Text);
                    else
                        oldCount = 0;
                    int newCount = 0;
                    //"tb_amont"
                    if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
                    {
                        if (_ProcessType == "exd")
                        {
                            availableAmount = await getAvailableAmount(row.itemId, row.itemUnitId, MainWindow.branchID.Value, row.ID);
                            if (availableAmount < oldCount)
                            {

                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableToolTip"), animation: ToasterAnimation.FadeIn);
                                newCount = newCount + availableAmount;
                                t.Text = availableAmount.ToString();
                            }
                            else
                            {
                                if (!t.Text.Equals(""))
                                    newCount = int.Parse(t.Text);
                                else
                                    newCount = 0;
                                if (newCount < 0)
                                {
                                    newCount = 0;
                                    t.Text = "0";
                                }
                            }
                        }
                        else
                        {
                            if (!t.Text.Equals(""))
                                newCount = int.Parse(t.Text);
                            else
                                newCount = 0;
                        }
                    }
                    else
                        newCount = row.Count;

                    if (row.OrderId != 0)
                    {
                        ItemTransfer item = mainInvoiceItems.ToList().Find(i => i.itemUnitId == row.itemUnitId && i.invoiceId == row.OrderId);
                        if (newCount > item.quantity)
                        {
                            // return old value 
                            t.Text = item.quantity.ToString();

                            newCount = (int)item.quantity;
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
                        }
                    }
                  

                    _Count -= oldCount;
                    _Count += newCount;

                    //  refresh count text box
                    tb_count.Text = _Count.ToString();

                    // update item in billdetails           
                    billDetails[index].Count = (int)newCount;
                    if (invoiceItems != null)
                        invoiceItems[index].quantity = (int)newCount;
                }
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                //refrishDataGridItems();

            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async Task<int> getAvailableAmount(int itemId, int itemUnitId, int branchId, int ID)
        {
            // var itemUnits = await itemUnitModel.GetItemUnits(itemId);
            var itemUnits = MainWindow.InvoiceGlobalItemUnitsList.Where(a => a.itemId == item.itemId).ToList();
            int availableAmount = await itemLocationModel.getAmountInBranch(itemUnitId, branchId);
            var smallUnits = await itemUnitModel.getSmallItemUnits(itemId, itemUnitId);
            foreach (ItemUnit u in itemUnits)
            {
                var isInBill = billDetails.ToList().Find(x => x.itemUnitId == (int)u.itemUnitId && x.ID != ID); // unit exist in invoice
                if (isInBill != null)
                {
                    var isSmall = smallUnits.Find(x => x.itemUnitId == (int)u.itemUnitId);
                    int unitValue = 0;

                    int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == u.itemUnitId).FirstOrDefault());
                    int quantity = billDetails[index].Count;
                    if (itemUnitId == u.itemUnitId)
                    { }
                    else if (isSmall != null) // from-unit is bigger than to-unit
                    {
                        unitValue = await itemUnitModel.largeToSmallUnitQuan(itemUnitId, u.itemUnitId);
                        quantity = quantity / unitValue;
                    }
                    else
                    {
                        unitValue = await itemUnitModel.smallToLargeUnit(itemUnitId, u.itemUnitId);

                        if (unitValue != 0)
                        {
                            quantity = quantity * unitValue;
                        }
                    }
                    availableAmount -= quantity;
                }
            }
            return availableAmount;
        }
        private void Cb_processType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_processType.SelectedIndex != -1)
                {
                    _SelectedProcess = (string)cb_processType.SelectedValue;
                    if (invoice.invoiceId == 0)
                        _ProcessType = cb_processType.SelectedValue + "d";
                    if (cb_processType.SelectedValue.ToString() == "im")
                        btn_save.Content = MainWindow.resourcemanager.GetString("trImport");
                    else if (cb_processType.SelectedValue.ToString() == "ex")
                    {
                        btn_save.Content = MainWindow.resourcemanager.GetString("trExport");
                        ereaseQuantity();
                    }
                }
                else
                {
                    cb_processType.SelectedValue = _SelectedProcess;
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
        private async Task<Boolean> checkItemsAmounts()
        {
            Boolean available = true;
            for (int i = 0; i < billDetails.Count; i++)
            {
                int availableAmount = await itemLocationModel.getAmountInBranch(billDetails[i].itemUnitId, MainWindow.branchID.Value);
                if (availableAmount < billDetails[i].Count)
                {
                    available = false;
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableFromToolTip") + " " + billDetails[i].Product, animation: ToasterAnimation.FadeIn);
                    return available;
                }
            }
            return available;
        }
        private void ereaseQuantity()
        {
            foreach(BillDetails b in billDetails)
            {
                b.Count = 0;
            }
            refrishDataGridItems();
        }

        private void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    /////////////////////////////////////
                    ///  
                    if (invoiceItems!=null)
                    {
                        Thread t1 = new Thread(() =>
                    {
                        printExport();
                    });
                    t1.Start();
                }
                    //////////////////////////////////////
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

        private void printExport()
        {
            BuildReport();

            this.Dispatcher.Invoke(() =>
            {
                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
            });
        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (invoiceItems!=null)
                    {
                        Thread t1 = new Thread(() =>
                    {
                        pdfExport();
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

        private void pdfExport()
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
        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    if (invoiceItems!=null)
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
                }
                    //////////////////////////////////////
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

        private void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();
         
            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {//ItemsExport
                addpath = @"\Reports\Store\Ar\ArItemsExportReport.rdlc";
            }
            else
                addpath = @"\Reports\Store\En\ItemsExportReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.ItemsExportReport(invoiceItems, rep, reppath, paramarr);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();
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
                            DataGridCell cell = null;
                            try
                            {
                                cell = DataGridHelper.GetCell(dg_billDetails, count, 3);
                            }
                            catch
                            { }
                            if (cell != null)
                            {
                                var cp = (ContentPresenter)cell.Content;
                                var combo = (ComboBox)cp.ContentTemplate.FindName("cbm_unitItemDetails", cp);
                                //var combo = (combo)cell.Content;
                                combo.SelectedValue = (int)item.itemUnitId;
                            }
                        }
                    }
                                count++;
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
            clearProcess();
            invoice = invoices[index];
            _ProcessType = invoice.invType;
            _invoiceId = invoice.invoiceId;
            navigateBtnActivate();
            await fillOrderInputs(invoice);
        }
        private async void Btn_previous_Click(object sender, RoutedEventArgs e)
        {
            int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
            index--;
            clearProcess();
            invoice = invoices[index];
            _ProcessType = invoice.invType;
            _invoiceId = invoice.invoiceId;
            navigateBtnActivate();
            await fillOrderInputs(invoice);
        }
        #endregion

        private async void Btn_shortageInvoice_Click(object sender, RoutedEventArgs e)
        {
            if(invoice.invoiceId != 0)
                clearProcess();
            cb_processType.SelectedIndex = 0;
            cb_processType.IsEnabled = false;
            await buildShortageInvoiceDetails();
        }
        private async Task buildShortageInvoiceDetails()
        {
            //get invoice items
            invoiceItems = await invoice.getShortageItems(MainWindow.branchID.Value);
            mainInvoiceItems = invoiceItems;
            // build invoice details grid
            _SequenceNum = 0;
            billDetails.Clear();
            foreach (ItemTransfer itemT in invoiceItems)
            {
                _SequenceNum++;
                decimal total = (decimal)(itemT.price * itemT.quantity);
                billDetails.Add(new BillDetails()
                {
                    ID = _SequenceNum,
                    Product = itemT.itemName,
                    itemId = (int)itemT.itemId,
                    Unit = itemT.itemUnitId.ToString(),
                    itemUnitId = (int)itemT.itemUnitId,
                    Count = (int)itemT.quantity,
                    OrderId = (int)itemT.invoiceId,
                    Price = decimal.Parse(SectionData.DecTostring((decimal)itemT.price)),
                    Total = total,
                });
            }

            tb_barcode.Focus();

            refrishBillDetails();
        }
        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            try
            {
                var Sender = sender as Expander;

                foreach (var control in FindControls.FindVisualChildren<Expander>(this))
                {

                    var expander = control as Expander;
                    if (expander.Tag != null && Sender.Tag != null)
                        if (expander.Tag.ToString() != Sender.Tag.ToString())
                            expander.IsExpanded = false;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        //private void Cb_company_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (sender != null)
        //            SectionData.StartAwait(grid_main);

        //        TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
        //        if (elapsed.TotalMilliseconds > 100 && cb_company.SelectedIndex != -1)
        //        {
        //            _SelectedCompany = (int)cb_company.SelectedValue;
        //            companyModel = companies.Find(c => c.shippingCompanyId == (int)cb_company.SelectedValue);
        //            _DeliveryCost = (decimal)companyModel.deliveryCost;
        //           // refreshTotalValue();

        //            if (companyModel.deliveryType == "local")
        //            {
        //                cb_user.Visibility = Visibility.Visible;
        //            }
        //            else
        //            {
        //                cb_user.SelectedIndex = -1;
        //                cb_user.Visibility = Visibility.Collapsed;
        //            }
        //        }
        //        else if (cb_company.SelectedIndex == -1)
        //        {
        //            cb_company.SelectedItem = "";
        //        }
        //        else
        //            cb_company.SelectedValue = _SelectedCompany;

        //        if (sender != null)
        //            SectionData.EndAwait(grid_main);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (sender != null)
        //            SectionData.EndAwait(grid_main);
        //        SectionData.ExceptionMessage(ex, this);
        //    }
        //}
        private void Cb_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_customer.SelectedIndex != -1)
                {
                    _SelectedUser = (int)cb_user.SelectedValue;
                }
                else if (cb_customer.SelectedIndex == -1)
                    cb_user.SelectedItem = "";
                else
                {
                    cb_user.SelectedValue = _SelectedUser;
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
            */
        }

        private void Dg_billDetails_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _IsFocused = true;
        }
    }
}

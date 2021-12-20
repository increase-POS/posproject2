﻿using netoaster;
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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static POS.View.uc_categorie;
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.Globalization;
using System.Net.Mail;
using System.Windows.Threading;
using System.Threading;

namespace POS.View.purchases
{
    /// <summary>
    /// Interaction logic for uc_purchaseOrder.xaml
    /// </summary>
    public partial class uc_purchaseOrder : UserControl
    {
        private static uc_purchaseOrder _instance;
        public static uc_purchaseOrder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_purchaseOrder();
                return _instance;
            }
        }
        public uc_purchaseOrder()
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

       
        string createPermission = "purchaseOrder_create";
        string reportsPermission = "purchaseOrder_reports";
        string sendEmailPermission = "purchaseOrder_sendEmail";
        string initializeShortagePermission = "purchaseOrder_initializeShortage";

        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
       
        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;
        ItemLocation itemLocationModel = new ItemLocation();

        Branch branchModel = new Branch();
        //IEnumerable<Branch> branches;

        Agent agentModel = new Agent();
        IEnumerable<Agent> vendors;

        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;
        
        Invoice invoiceModel = new Invoice();
        public Invoice invoice = new Invoice();
        List<Invoice> invoices;
        List<ItemTransfer> invoiceItems;
        List<ItemTransfer> mainInvoiceItems;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        public List<Control> controls;
        #region for notifications
        private static DispatcherTimer timer;
        public static bool isFromReport = false;
        public static bool archived = false;
        int _DraftCount = 0;
        int _OrdersCount = 0;
        int _DocCount = 0;
        #endregion
        #region //to handle barcode characters
        static private int _SelectedVendor = -1;
        bool _IsFocused = false;
        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        static private string _BarcodeStr = "";
        static private object _Sender;
        #endregion      
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;

        //for bill details
        static private int _SequenceNum = 0;
        static private int _invoiceId;
        static private decimal _Sum = 0;
        static public string _InvoiceType = "pod"; // purchase order draft
        static private decimal _Count = 0;
        // for report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        //bool isClose = false;
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
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trQTR");

            txt_shortageInvoice.Text = MainWindow.resourcemanager.GetString("trLack");
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaceOrder");
            txt_vendor.Text = MainWindow.resourcemanager.GetString("trVendor");
            tb_count.Text = MainWindow.resourcemanager.GetString("trCount:");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_barcode, MainWindow.resourcemanager.GetString("trBarcodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendor, MainWindow.resourcemanager.GetString("trVendorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            txt_items.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_drafts.Text = MainWindow.resourcemanager.GetString("trOrders");
            txt_newDraft.Text = MainWindow.resourcemanager.GetString("trNew");
            txt_purchaseOrder.Text = MainWindow.resourcemanager.GetString("trReady");
            txt_emailMessage.Text = MainWindow.resourcemanager.GetString("trSendEmail");
            txt_preview.Text = MainWindow.resourcemanager.GetString("trPreview");
            txt_pdf.Text = MainWindow.resourcemanager.GetString("trPdfBtn");
            txt_printInvoice.Text = MainWindow.resourcemanager.GetString("trPrint");
            txt_invoiceImages.Text = MainWindow.resourcemanager.GetString("trImages");

            tt_error_previous.Content = MainWindow.resourcemanager.GetString("trPrevious");
            tt_error_next.Content = MainWindow.resourcemanager.GetString("trNext");

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                MainWindow.mainWindow.KeyDown -= HandleKeyPress;

                saveBeforeExit();               
                timer.Stop();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
        }
        private async Task<bool> saveBeforeExit()
        {
            int invioceId = 0;
            bool succssess = false;
            if (billDetails.Count > 0 && _InvoiceType == "pod")
            {
                #region Accept
                MainWindow.mainWindow.Opacity = 0.2;
                wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                w.contentText = MainWindow.resourcemanager.GetString("trSaveOrderNotification");

                w.ShowDialog();
                MainWindow.mainWindow.Opacity = 1;
                #endregion
                if (w.isOk  )
                {
                    bool valid = validateItemUnits();
                    if (billDetails.Count > 0 && valid)
                    {
                      invioceId = await addInvoice(_InvoiceType);
                        succssess = true;
                    }
                    //else if (billDetails.Count == 0)
                    //{
                    //    clearInvoice();
                    //}
                }
                else
                {
                    clearInvoice();
                    refreshDraftNotification();
                    succssess = true;
                }
            }
            else
            {
               clearInvoice();
                refreshDraftNotification();
                succssess = true;
            }
            return succssess;
        }
        private async void Btn_purchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                Window.GetWindow(this).Opacity = 0.2;
                saveBeforeExit();
                wd_invoice w = new wd_invoice();
                string invoiceType = "po";
                int duration = 1;
                w.invoiceType = invoiceType;
                w.userId = MainWindow.userLogin.userId;
                w.branchCreatorId = MainWindow.loginBranch.branchId;
                w.duration = duration; // view purchase orders which created during  last one day 
                w.fromOrder = true;
                w.condition = "orders";
                w.title = MainWindow.resourcemanager.GetString("trOrders");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;
                        _InvoiceType = invoice.invType;
                        _invoiceId = invoice.invoiceId;
                        isFromReport = false;
                        archived = false;
                        // notifications
                        refreshNotification();
                        refreshDocCount(invoice.invoiceId);

                        await fillInvoiceInputs(invoice);

                        mainInvoiceItems = invoiceItems;
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaceOrder");
                        invoices = await invoice.getUnHandeldOrders(invoiceType,MainWindow.branchID.Value,0,duration, MainWindow.userID.Value);
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
        #region loading

        List<keyValueBool> loadingList;


        async void loading_RefrishItems()
        {
            try
            {
                await RefrishItems();

            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_RefrishItems"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_refrishVendors()
        {
            try
            {
                await RefrishVendors();

            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_refrishVendors"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_fillBarcodeList()
        {
            try
            {
                await fillBarcodeList();

            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_fillBarcodeList"))
                {
                    item.value = true;
                    break;
                }
            }
        }


        #endregion
        public async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.mainWindow.Closing += ParentWin_Closing;
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                // for pagination
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
                setTimer();

                #region loading
                loadingList = new List<keyValueBool>();
                bool isDone = true;
                loadingList.Add(new keyValueBool { key = "loading_RefrishItems", value = false });
                loadingList.Add(new keyValueBool { key = "loading_refrishVendors", value = false });
                loadingList.Add(new keyValueBool { key = "loading_fillBarcodeList", value = false });

                loading_RefrishItems();
                loading_refrishVendors();
                loading_fillBarcodeList();
                do
                {
                    isDone = true;
                    foreach (var item in loadingList)
                    {
                        if (item.value == false)
                        {
                            isDone = false;
                            break;
                        }
                    }
                    if (!isDone)
                    {
                        await Task.Delay(0500);
                    }
                }
                while (!isDone);
                #endregion


                //await RefrishItems();
                //await RefrishVendors();
                //await fillBarcodeList();
                refreshNotification();
                refreshLackNotification();
                //List all the UIElement in the VisualTree
                controls = new List<Control>();
                FindControl(this.grid_main, controls);
                // branchModel = await branchModel.getBranchById(MainWindow.branchID.Value);              
                #region datagridChange
                //CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
                //((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
                #endregion

                #region Permision
                 

                //if (MainWindow.groupObject.HasPermissionAction(sendEmailPermission, MainWindow.groupObjects, "one"))
                //{
                //    btn_emailMessage.Visibility = Visibility.Visible;
                //    bdr_emailMessage.Visibility = Visibility.Visible;
                //}
                //else
                //{
                //    btn_emailMessage.Visibility = Visibility.Collapsed;
                //    bdr_emailMessage.Visibility = Visibility.Collapsed;
                //}


                if (MainWindow.groupObject.HasPermissionAction(initializeShortagePermission, MainWindow.groupObjects, "one"))
                {
                    btn_shortageInvoice.Visibility = Visibility.Visible;
                    bdr_shortageInvoice.Visibility = Visibility.Visible;
                    md_shortage.Visibility = Visibility.Visible;
                }
                else
                {
                    btn_shortageInvoice.Visibility = Visibility.Collapsed;
                    bdr_shortageInvoice.Visibility = Visibility.Collapsed;
                    md_shortage.Visibility = Visibility.Collapsed;
                }

                #endregion
                #region print - pdf - send email
                btn_printInvoice.Visibility = Visibility.Collapsed;
                btn_pdf.Visibility = Visibility.Collapsed;
                btn_emailMessage.Visibility = Visibility.Collapsed;
                bdr_emailMessage.Visibility = Visibility.Collapsed;
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
            //isClose = true;
            //UserControl_Unloaded(this, null);
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
            public string invType { get; set; }
        }

        #endregion
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
                        _Sum -= row.Total;

                        // remove item from bill
                        billDetails.RemoveAt(index);

                        ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
                        data.Remove(row);

                        // calculate new total
                        refreshTotalValue();
                    }
                _SequenceNum = 0;
                _Sum = 0;
                for (int i = 0; i < billDetails.Count; i++)
                {
                    _SequenceNum++;
                    _Sum += billDetails[i].Total;
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

        #region timer to refresh notifications
        private void setTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += timer_Tick;
            timer.Start();
        }
         void timer_Tick(object sendert, EventArgs et)
        {
            try
            {
                if (invoice.invoiceId != 0)
            {
                    refreshOrdersNotification();
                refreshDocCount(invoice.invoiceId);
                   
                    refreshLackNotification();
            }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        #region notification
        private void refreshNotification()
        {
            refreshDraftNotification();
            refreshOrdersNotification();
        }
        private async void refreshDraftNotification()
        {
            string invoiceType = "pod";
            int duration = 2;
            try
            {
                int draftCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);
                if (invoice != null && invoice.invType == "pod" && !isFromReport)
                    draftCount--;

                if (draftCount != _DraftCount)
                {
                    if (draftCount > 9)
                    {
                        md_draft.Badge = "+9";
                    }
                    else if (draftCount == 0) md_draft.Badge = "";
                    else
                        md_draft.Badge = draftCount.ToString();
                }
                _DraftCount = draftCount;
            }
            catch { }
        }
        private async void refreshOrdersNotification()
        {
            string invoiceType = "po";
            int duration = 1;
            try
            {
                int orderCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);
                if (invoice != null && invoice.invType == "po" && !isFromReport)
                    orderCount--;

                if (orderCount != _OrdersCount)
                {
                    if (orderCount > 9)
                    {
                        md_order.Badge = "+9";
                    }
                    else if (orderCount == 0) md_order.Badge = "";
                    else
                        md_order.Badge = orderCount.ToString();
                }
                _OrdersCount = orderCount;
            }
            catch { }
        }
        private async Task refreshLackNotification()
        {
            string isThereLack = await invoice.isThereLack(MainWindow.branchID.Value);
            if (isThereLack == "yes")
                md_shortage.Badge = "!";
            else
                md_shortage.Badge = "";
        }
        private async void refreshDocCount(int invoiceId)
        {
            DocImage doc = new DocImage();
            int docCount = await doc.GetDocCount("Invoices", invoiceId);

            if (docCount != _DocCount)
            {
                if (docCount > 9)
                    md_docImage.Badge = "+9";
                else if (docCount == 0) md_docImage.Badge = "";
                else
                    md_docImage.Badge = docCount.ToString();
            }
            _DocCount = docCount;
        }
        #endregion
        private void Btn_updateVendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (cb_vendor.SelectedIndex != -1)
                {
                    Window.GetWindow(this).Opacity = 0.2;

                    //if (((( ).Parent as Grid).Parent as UserControl) != null)
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_updateVendor w = new wd_updateVendor();
                    //// pass agent id to update windows
                    w.agent.agentId = (int)cb_vendor.SelectedValue;
                    //w.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00178DD2"));
                    w.ShowDialog();


                    Window.GetWindow(this).Opacity = 1;
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
        #region Categor and Item
        #region Refrish Y
        /// <summary>
        /// Category
        /// </summary>
        /// <returns></returns>
        //async Task<IEnumerable<Category>> RefrishCategories()
        //{
        //    categories = await categoryModel.GetAllCategories();
        //    return categories;
        //}
        async Task RefrishVendors()
        {
            vendors = await agentModel.GetAgentsActive("v");
            cb_vendor.ItemsSource = vendors;
            cb_vendor.DisplayMemberPath = "name";
            cb_vendor.SelectedValuePath = "agentId";
        }
        async Task RefrishItems()
        {
            items = await itemModel.GetAllItems();
        }
        async Task fillBarcodeList()
        {
            barcodesList = await itemUnitModel.getAllBarcodes();
        }
        #endregion
        #region Get Id By Click  Y

        public void ChangeCategoryIdEvent(int categoryId)
        {
        }
        public async Task ChangeItemIdEvent(int itemId)
        {
            item = items.ToList().Find(c => c.itemId == itemId);

            if (item != null)
            {
                this.DataContext = item;

                // get item units
               // itemUnits = await itemUnitModel.GetItemUnits(item.itemId);
                itemUnits = MainWindow.InvoiceGlobalItemUnitsList.Where(a => a.itemId == item.itemId).ToList();
                // search for default unit for purchase
                var defaultPurUnit = itemUnits.ToList().Find(c => c.defaultPurchase == 1);
                if (defaultPurUnit != null)
                {
                    int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == defaultPurUnit.itemUnitId && p.OrderId == 0).FirstOrDefault());
                    if (index == -1)//item doesn't exist in bill
                    {
                        // create new row in bill details data grid
                          addRowToBill(item.name, itemId, defaultPurUnit.mainUnit, defaultPurUnit.itemUnitId, 1, 0, 0);
                    }
                    else // item exist prevoiusly in list
                    {
                        billDetails[index].Count++;
                        billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;


                        _Count += billDetails[index].Count;
                        _Sum += billDetails[index].Price;
                    }
                    //refreshTotalValue();
                    //refrishBillDetails();
                }
                else
                {
                      addRowToBill(item.name, itemId, null, 0, 1, 0, 0);
                    //refrishBillDetails();
                }
            }
            tb_total.Text = _Count.ToString();
        }

        #endregion



        #endregion


        #region validation
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
                    if ((sender as ComboBox).Name == "cb_vendor")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip");
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        #region save invoice

        private async Task<int> addInvoice(string invType)
        {           
            if (invType == "po" && invoice.invType != "po")
                invoice.invNumber = await invoice.generateInvNumber(invType, MainWindow.loginBranch.code, MainWindow.branchID.Value);
            else if ((invType == "pod") && (invoice.invoiceId == 0 || invoice.invType =="po"))
                invoice.invNumber = await invoice.generateInvNumber("pod", MainWindow.loginBranch.code, MainWindow.branchID.Value);

            invoice.branchCreatorId = MainWindow.branchID.Value;
            invoice.branchId = MainWindow.branchID.Value;
            invoice.posId = MainWindow.posID.Value;

            invoice.invType = invType;
            invoice.total = 0;
            invoice.totalNet = 0;

            if (cb_vendor.SelectedIndex != -1)
                invoice.agentId = (int)cb_vendor.SelectedValue;

            invoice.notes = tb_note.Text;
            invoice.taxtype = 2;
            invoice.createUserId = MainWindow.userID;
            invoice.updateUserId = MainWindow.userID;
            byte isApproved = 0;
            if (tgl_ActiveOffer.IsChecked == true)
                isApproved = 1;
            else
                isApproved = 0;
            invoice.isApproved = isApproved;
            // save invoice in DB
            int invoiceId = await invoiceModel.saveInvoice(invoice);
            invoice.invoiceId = invoiceId;
            if (invoiceId > 0)
            {
                // add invoice details
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
                await invoiceModel.saveInvoiceItems(invoiceItems, invoiceId);
                
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
            }
            else
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            clearInvoice();
       
            return invoiceId;
        }
        private bool validateInvoiceValues()
        {
            bool valid = true;
            if (!SectionData.validateEmptyComboBox(cb_vendor, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip"))
                exp_vendor.IsExpanded = true;
            if (billDetails.Count == 0)
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trAddInvoiceWithoutItems"), animation: ToasterAnimation.FadeIn);

            if (cb_vendor.SelectedIndex != -1 && billDetails.Count > 0)
                valid = true;
            else
                valid = false;
            if (valid)
                valid = validateItemUnits();
            return valid;
        }
        private void Tgl_ActiveOffer_Checked(object sender, RoutedEventArgs e)
        {
            if (tgl_ActiveOffer.IsFocused)
            {
                #region Accept
                if (cb_vendor.SelectedIndex != -1)
                {
                    MainWindow.mainWindow.Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    w.contentText = MainWindow.resourcemanager.GetString("trApproveOrderNotification");

                    w.ShowDialog();
                    if (!w.isOk)
                    {
                        tgl_ActiveOffer.IsChecked = false;
                        _InvoiceType = "pod";
                    }
                    else
                    {
                        _InvoiceType = "po";
                        btn_save.Content = MainWindow.resourcemanager.GetString("trSubmit");
                    }                  
                    MainWindow.mainWindow.Opacity = 1;

                }
                #endregion
                else
                {
                    tgl_ActiveOffer.IsChecked = false;
                    exp_vendor.IsExpanded = true;
                    SectionData.validateEmptyComboBox(cb_vendor, p_errorVendor, tt_errorVendor, "trEmptyVendorToolTip");
                }
                inputEditable();

                if (tgl_ActiveOffer.IsChecked == true)
                {
                    dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                }
                else
                {
                    dg_billDetails.Columns[3].IsReadOnly = false; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                }
                refrishDataGridItems();
            }
        }
        private void Tgl_ActiveOffer_Unchecked(object sender, RoutedEventArgs e)
        {
            _InvoiceType = "pod";
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
            if (tgl_ActiveOffer.IsChecked == true)
            {
                dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
            }
            else
            {
                dg_billDetails.Columns[3].IsReadOnly = false; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
            }
            inputEditable();
            refrishDataGridItems();
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                        //check mandatory inputs
                        bool valid = validateInvoiceValues();
                        if (valid)
                        {
                        await addInvoice(_InvoiceType); // po: purchase order
                        refreshNotification();
                           // clearInvoice();
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
        private bool validateItemUnits()
        {
            bool valid = true;
            for (int i = 0; i < billDetails.Count; i++)
            {
                if (billDetails[i].itemUnitId == 0)
                {
                    valid = false;
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trItemWithNoUnit"), animation: ToasterAnimation.FadeIn);

                    return valid;
                }
            }
            return valid;
        }
        private async void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                bool valid = validateItemUnits();
                if (billDetails.Count > 0 && valid)
                {
                    await addInvoice(_InvoiceType);
                    refreshNotification();
                }
                else if (billDetails.Count == 0)
                {
                    clearInvoice();
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
        private void clearInvoice()
        {
            _Sum = 0;
            _Count = 0;
            txt_invNumber.Text = "";
            _SequenceNum = 0;
            _SelectedVendor = -1;
            _InvoiceType = "pod"; // purchase order draft
            invoice = new Invoice();
            tb_barcode.Clear();
            cb_vendor.SelectedIndex = -1;
            cb_vendor.SelectedItem = "";
            tb_note.Clear();
            billDetails.Clear();
            tb_total.Text = "";
            btn_updateVendor.IsEnabled = false;
            md_docImage.Badge = "";
            isFromReport = false;
            archived = false;
            tgl_ActiveOffer.IsChecked = false;
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseOrder");
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

            refrishBillDetails();
            inputEditable();
            btn_next.Visibility = Visibility.Collapsed;
            btn_previous.Visibility = Visibility.Collapsed;
        }
        #endregion
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
               bool res = await saveBeforeExit();
                while (!res) { }
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();
                
                // purchase drafts and purchase bounce drafts
                string invoiceType = "pod";
                int duration = 2;
                w.invoiceType = invoiceType;
                w.userId = MainWindow.userLogin.userId;
                w.duration = duration; // view drafts which created during 2 last days 
                w.fromOrder = true;
                w.title = MainWindow.resourcemanager.GetString("trDrafts");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;
                        _InvoiceType = invoice.invType;
                        _invoiceId = invoice.invoiceId;
                        isFromReport = false;
                        archived = false;
                        // notifications
                        refreshNotification();
                        refreshDocCount(invoice.invoiceId);
                        await fillInvoiceInputs(invoice);

                        mainInvoiceItems = invoiceItems;
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaceOrderDraft");
                        invoices = await invoice.GetInvoicesByCreator(invoiceType, MainWindow.userID.Value, duration);
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
        private async void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

                // purchase invoices
                w.invoiceType = "p , pw";
                w.userId = MainWindow.userLogin.userId;
                w.duration = 1; // view drafts which created during 1 last days 

                w.title = MainWindow.resourcemanager.GetString("trPurchaseInvoices");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;

                        this.DataContext = invoice;

                        _InvoiceType = invoice.invType;
                        // set title to bill
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
                        brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        await fillInvoiceInputs(invoice);

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
        public async Task fillInvoiceInputs(Invoice invoice)
        {
            txt_invNumber.Text = invoice.invNumber.ToString();
            cb_vendor.SelectedValue = invoice.agentId;
            tb_note.Text = invoice.notes;
            if (invoice.isApproved == 1)
                tgl_ActiveOffer.IsChecked = true;
            else
                tgl_ActiveOffer.IsChecked = false;
            await buildInvoiceDetails();
            inputEditable();
        }

        private async Task buildInvoiceDetails()
        {
            //get invoice items
            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
            // build invoice details grid
            _SequenceNum = 0;
            billDetails.Clear();
            foreach (ItemTransfer itemT in invoiceItems)
            {
                _Count += (int)itemT.quantity;
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
                invType = invoice.invType,
                });
            }
            tb_total.Text = _Count.ToString();

            tb_barcode.Focus();

            refrishBillDetails();
        }
        private void inputEditable()
        {
            if (_InvoiceType == "pod")
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                dg_billDetails.Columns[3].IsReadOnly = false; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                cb_vendor.IsEnabled = true;
                tb_note.IsEnabled = true;
                tb_barcode.IsEnabled = true;
                btn_clear.IsEnabled = true;
                tgl_ActiveOffer.IsEnabled = true;
                btn_save.IsEnabled = true;
            }
            else if (_InvoiceType == "po") // purchase order
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                cb_vendor.IsEnabled = false;
                tb_note.IsEnabled = false;
                tb_barcode.IsEnabled = false;
                btn_clear.IsEnabled = false;
                tgl_ActiveOffer.IsEnabled = true;
                btn_save.IsEnabled = true;
            }
            else if(archived) //come from reports
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                cb_vendor.IsEnabled = false;
                tb_note.IsEnabled = false;
                tb_barcode.IsEnabled = false;
                tgl_ActiveOffer.IsEnabled = false;
                btn_clear.IsEnabled = false;
                btn_save.IsEnabled = false;
            }
            if (_InvoiceType.Equals("po"))
            {
                #region print - pdf - send email
                btn_printInvoice.Visibility = Visibility.Visible;
                btn_pdf.Visibility = Visibility.Visible;
                if (MainWindow.groupObject.HasPermissionAction(sendEmailPermission, MainWindow.groupObjects, "one"))
                {
                    btn_emailMessage.Visibility = Visibility.Visible;
                    bdr_emailMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    btn_emailMessage.Visibility = Visibility.Collapsed;
                    bdr_emailMessage.Visibility = Visibility.Collapsed;
                }
                #endregion
            }
            else
            {
                #region print - pdf - send email
                btn_printInvoice.Visibility = Visibility.Collapsed;
                btn_pdf.Visibility = Visibility.Collapsed;
                btn_emailMessage.Visibility = Visibility.Collapsed;
                bdr_emailMessage.Visibility = Visibility.Collapsed;
                #endregion
            }
            if (!isFromReport)
            {
                btn_next.Visibility = Visibility.Visible;
                btn_previous.Visibility = Visibility.Visible;
            }
        }
        private async void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (invoice != null && invoice.invoiceId != 0)
                    {
                        Window.GetWindow(this).Opacity = 0.2;

                        wd_uploadImage w = new wd_uploadImage();

                        w.tableName = "invoices";
                        w.tableId = invoice.invoiceId;
                        w.docNum = invoice.invNumber;
                        w.ShowDialog();
                        refreshDocCount(invoice.invoiceId);
                        Window.GetWindow(this).Opacity = 1;
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trChooseInvoiceToolTip"), animation: ToasterAnimation.FadeIn);



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

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

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
                        Count = (int)itemT.quantity,
                        Price = (decimal)itemT.price,
                        Total = total,
                invType = invoice.invType,
                    });
                }
                tb_barcode.Focus();

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

        

        private void Cb_vendor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                cb_vendor.ItemsSource = vendors.Where(x => x.name.Contains(cb_vendor.Text));
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Cb_vendor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_vendor.SelectedIndex != -1)
                {
                    _SelectedVendor = (int)cb_vendor.SelectedValue;
                }
                else
                {
                    cb_vendor.SelectedValue = _SelectedVendor;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Tb_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _Sender = sender;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void refreshTotalValue()
        {
            decimal total = _Sum;
            decimal taxValue = 0;
            decimal taxInputVal = 0;
            if (total != 0)
                taxValue = SectionData.calcPercentage(total, taxInputVal);

            ////tb_sum.Text = _Sum.ToString();
            //if (_Sum != 0)
            //    tb_sum.Text = SectionData.DecTostring(_Sum);
            //else
            //    tb_sum.Text = "0";

        }


        #region billdetails
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
            tb_total.Text = _Count.ToString();
            ////tb_sum.Text = _Sum.ToString();
            //if (_Sum != 0)
            //    tb_sum.Text = SectionData.DecTostring(_Sum);
            //else
            //    tb_sum.Text = "0";

        }
        void refrishDataGridItems()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;
            dg_billDetails.Items.Refresh();
            DataGrid_CollectionChanged(dg_billDetails, null);
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
                            //handle D key
                             btn_printInvoice_Click(null, null);
                            break;
                        case Key.S:
                            //handle X key
                             Btn_save_Click(btn_save, null);
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
                        if (dt != null)
                        {
                            if (dt.Name == "dp_desrvedDate" || dt.Name == "dp_invoiceDate")
                                _BarcodeStr = _BarcodeStr.Substring(1);
                        }
                        else if (tb != null)
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
                    _IsFocused = false;
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
                case "po":// this barcode for invoice               
                    Btn_newDraft_Click(null, null);
                    invoice = await invoiceModel.GetInvoicesByNum(barcode);
                    _InvoiceType = invoice.invType;
                    if (_InvoiceType.Equals("po") || _InvoiceType.Equals("pod"))
                    {
                        // set title to bill
                        if (_InvoiceType == "pod")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaceOrderDraft");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        else if (_InvoiceType == "po")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trOrders");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                      
                        await fillInvoiceInputs(invoice);
                    }
                    break;

                default: // if barcode for item
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
                                int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId && p.OrderId == 0).FirstOrDefault());

                                if (index == -1)//item doesn't exist in bill
                                {
                                    // get item units
                                    itemUnits = await itemUnitModel.GetItemUnits(itemId);

                                    //get item from list
                                    item = items.ToList().Find(i => i.itemId == itemId);

                                    int count = 1;
                                    decimal price = 0; //?????
                                    decimal total = count * price;
                                    addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count, price, total);
                                }
                                else // item exist prevoiusly in list
                                {
                                    billDetails[index].Count++;
                                    billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;

                                    _Sum += billDetails[index].Price;

                                }
                                refreshTotalValue();
                                refrishBillDetails();
                            }
                        }
                        else
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorItemNotFoundToolTip"), animation: ToasterAnimation.FadeIn);
                        }
                    }
                    break;
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

        private  void addRowToBill(string itemName, int itemId, string unitName, int itemUnitId, int count, decimal price, decimal total)
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
                Count = 1,
                Price = price,
                Total = total,
                invType = invoice.invType,
            });
            _Count++;
            _Sum += total;
        }
        #endregion billdetails

        private void Cbm_unitItemDetails_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                //billDetails
                var cmb = sender as ComboBox;
                cmb.SelectedValue = (int)billDetails[0].itemUnitId;

                if (    tgl_ActiveOffer.IsChecked == true)
                    cmb.IsEnabled = false;
                else
                    cmb.IsEnabled = true;

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var cmb = sender as ComboBox;

                if (dg_billDetails.SelectedIndex != -1 && cmb.SelectedValue != null)
                {
                    billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
                    if (     tgl_ActiveOffer.IsChecked == true)
                        cmb.IsEnabled = false;
                    else
                        cmb.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
                //return;
            }
        }
        private void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
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

                                if (  tgl_ActiveOffer.IsChecked == true)
                                    combo.IsEnabled = false;
                                else
                                    combo.IsEnabled = true;
                            }
                        }
                    }
                    count++;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Dg_billDetails_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

            //if (dg_billDetails.SelectedIndex != -1)
            //    if (billDetails[dg_billDetails.SelectedIndex].OrderId != 0)
            //        e.Cancel = true;

             
            if (dg_billDetails.SelectedIndex != -1)
                if ( tgl_ActiveOffer.IsChecked == true)
                    e.Cancel = true;
        }


        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
                    if (columnName == MainWindow.resourcemanager.GetString("trQTR"))
                        t.Text = billDetails[index].Count.ToString();
                }
                else
                {
                    int oldCount = 0;
                    long newCount = 0;

                    //"tb_amont"
                    if (columnName == MainWindow.resourcemanager.GetString("trQTR"))
                        newCount = int.Parse(t.Text);
                    else
                        newCount = row.Count;
                    if (newCount < 0)
                    {
                        newCount = 0;
                        t.Text = "0";
                    }

                    oldCount = row.Count;

                    if (_InvoiceType == "pbd" || _InvoiceType == "pbw")
                    {
                        ItemTransfer item = mainInvoiceItems.ToList().Find(i => i.itemUnitId == row.itemUnitId && i.invoiceId == row.OrderId);
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
                    tb_total.Text = _Count.ToString();


                    // update item in billdetails           
                    billDetails[index].Count = (int)newCount;

                //refrishDataGridItems();
                }
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

        private void moveControlToBarcode(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                DatePicker dt = sender as DatePicker;
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds < 100)
                {
                    tb_barcode.Focus();
                    HandleKeyPress(sender, e);
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

        public async Task<string> SavePurOrderpdf()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();
            string pdfpath = "";

            //

            if (invoice.invoiceId > 0)
            {
                pdfpath = @"\Thumb\report\File.pdf";
                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                string reppath = reportclass.GetpayInvoiceRdlcpath(invoice);
                invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                if (invoice.agentId != null)
                {
                    Agent agentinv = new Agent();
                    agentinv = vendors.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                    invoice.agentCode = agentinv.code;
                    //new lines
                    invoice.agentName = agentinv.name;
                    invoice.agentCompany = agentinv.company;
                }
                else
                {

                    invoice.agentCode = "-";
                    //new lines
                    invoice.agentName = "-";
                    invoice.agentCompany = "-";
                }

                invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                Branch branch = new Branch();
                branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                if (branch.branchId > 0)
                {
                    invoice.branchName = branch.name;
                }

                User employ = new User();
                employ = await employ.getUserById((int)invoice.updateUserId);
                invoice.uuserName = employ.name;
                invoice.uuserLast = employ.lastname;

                ReportCls.checkLang();

                clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);
                paramarr = reportclass.fillPurInvReport(invoice, paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();

                LocalReportExtensions.ExportToPDF(rep, pdfpath);

            }

            return pdfpath;
        }
        //print
        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Thread t1 = new Thread(() =>
                    {
                        pdfPurInvoice();
                    });
                    t1.Start();
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


        private async void btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Thread t1 = new Thread(() =>
                    {
                        printPurInvoice();
                    });
                    t1.Start();
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

        public async void printPurInvoice()
        {
            if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
                               || invoice.invType == "sbd" || invoice.invType == "pbd"
                               || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
            {
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintDraftInvoice"), animation: ToasterAnimation.FadeIn);
            }
            else
            {
                ReportCls rr = new ReportCls();

                List<ReportParameter> paramarr = new List<ReportParameter>();

                string reppath = reportclass.GetpayInvoiceRdlcpath(invoice);
                if (invoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                    Agent agentinv = new Agent();
                    agentinv = vendors.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                    User employ = new User();
                    employ = await employ.getUserById((int)invoice.updateUserId);
                    invoice.uuserName = employ.name;
                    invoice.uuserLast = employ.lastname;

                    invoice.agentCode = agentinv.code;
                    //new lines
                    invoice.agentName = agentinv.name;
                    invoice.agentCompany = agentinv.company;

                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        invoice.branchName = branch.name;
                    }


                    ReportCls.checkLang();

                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillPurInvReport(invoice, paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();

                    this.Dispatcher.Invoke(() =>
                    {

                        LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.pur_copy_count));
                    });
                }
            }
        }
        public async void pdfPurInvoice()
        {
            if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
               || invoice.invType == "sbd" || invoice.invType == "pbd"
               || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
            {
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintDraftInvoice"), animation: ToasterAnimation.FadeIn);
            }
            else
            {

                List<ReportParameter> paramarr = new List<ReportParameter>();


                string reppath = reportclass.GetpayInvoiceRdlcpath(invoice);
                if (invoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                    Agent agentinv = new Agent();
                    agentinv = vendors.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                    invoice.agentCode = agentinv.code;
                    //new lines
                    invoice.agentName = agentinv.name;
                    invoice.agentCompany = agentinv.company;

                    User employ = new User();
                    employ = await employ.getUserById((int)invoice.updateUserId);
                    invoice.uuserName = employ.name;
                    invoice.uuserLast = employ.lastname;


                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        invoice.branchName = branch.name;
                    }


                    ReportCls.checkLang();

                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillPurInvReport(invoice, paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();
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
                    ////// w.selectedItem this is ItemId
                    for (int i = 0; i < w.selectedItems.Count; i++)
                    {
                        int itemId = w.selectedItems[i];
                        await ChangeItemIdEvent(itemId);
                    }
                    refreshTotalValue();
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

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

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


        private void Tb_barcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _Sender = sender;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    if (invoice.invoiceId > 0)
                    {
                        Window.GetWindow(this).Opacity = 0.2;

                        List<ReportParameter> paramarr = new List<ReportParameter>();
                        string pdfpath;

                        pdfpath = @"\Thumb\report\temp.pdf";
                        pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                        string reppath = reportclass.GetpayInvoiceRdlcpath(invoice);
                        if (invoice.invoiceId > 0)
                        {
                            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                            if (invoice.agentId != null)
                            {
                                Agent agentinv = new Agent();
                                agentinv = vendors.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                                invoice.agentCode = agentinv.code;
                                //new lines
                                invoice.agentName = agentinv.name;
                                invoice.agentCompany = agentinv.company;
                            }
                            else
                            {
                                invoice.agentCode = "-";
                                //new lines
                                invoice.agentName = "-";
                                invoice.agentCompany = "-";
                            }

                            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                            Branch branch = new Branch();
                            branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                            if (branch.branchId > 0)
                            {
                                invoice.branchName = branch.name;
                            }

                            User employ = new User();
                            employ = await employ.getUserById((int)invoice.updateUserId);
                            invoice.uuserName = employ.name;
                            invoice.uuserLast = employ.lastname;

                            ReportCls.checkLang();
                           
                            clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                            clsReports.setReportLanguage(paramarr);
                            clsReports.Header(paramarr);
                            paramarr = reportclass.fillPurInvReport(invoice, paramarr);

                            rep.SetParameters(paramarr);
                            rep.Refresh();

                            LocalReportExtensions.ExportToPDF(rep, pdfpath);
                        }

                        wd_previewPdf w = new wd_previewPdf();
                        w.pdfPath = pdfpath;
                        if (!string.IsNullOrEmpty(w.pdfPath))
                        {
                            w.ShowDialog();
                            w.wb_pdfWebViewer.Dispose();
                        }
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: "", animation: ToasterAnimation.FadeIn);
                        Window.GetWindow(this).Opacity = 1;
                    }
                    else
                    {
                        Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trSaveInvoiceToPreview"), animation: ToasterAnimation.FadeIn);
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

        private async void Btn_emailMessage_Click(object sender, RoutedEventArgs e)
        {//email
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    /////////////////////////////
                    Thread t1 = new Thread(() =>
                    {
                        sendPurEmail();
                    });
                    t1.Start();
                    /////////////////////////////
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
        public async void sendPurEmail()
        {
            SysEmails email = new SysEmails();
            EmailClass mailtosend = new EmailClass();
            email = await email.GetByBranchIdandSide((int)MainWindow.branchID, "purchase");
            Agent toAgent = new Agent();
            toAgent = vendors.Where(x => x.agentId == invoice.agentId).FirstOrDefault();
            //  int? itemcount = invoiceItems.Count();
            if (email.emailId == 0)
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoEmailForThisDept"), animation: ToasterAnimation.FadeIn);
            else
            {
                if (invoice.invoiceId == 0)
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trThereIsNoOrderToSen"), animation: ToasterAnimation.FadeIn);
                else
                {
                    if (invoiceItems == null || invoiceItems.Count() == 0)
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trThereIsNoItemsToSend"), animation: ToasterAnimation.FadeIn);
                    else
                    {
                        if (toAgent.email.Trim() == "")
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTheVendorHasNoEmail"), animation: ToasterAnimation.FadeIn);
                        else
                        {
                            SetValues setvmodel = new SetValues();

                            string pdfpath = await SavePurOrderpdf();
                            mailtosend.AddAttachTolist(pdfpath);
                            List<SetValues> setvlist = new List<SetValues>();
                            setvlist = await setvmodel.GetBySetName("pur_order_email_temp");

                            mailtosend = mailtosend.fillOrderTempData(invoice, invoiceItems, email, toAgent, setvlist);
                            this.Dispatcher.Invoke(new Action(() =>
                            {
                                string msg = mailtosend.Sendmail();
                                if (msg == "Failure sending mail.")
                                {
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoConnection"), animation: ToasterAnimation.FadeIn);
                                }
                                else if (msg == "mailsent")
                                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailSent"), animation: ToasterAnimation.FadeIn);
                                else
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailNotSent"), animation: ToasterAnimation.FadeIn);
                            }));

                        }
                    }
                }
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
            _invoiceId = invoice.invoiceId;
            _InvoiceType = invoice.invType;
            navigateBtnActivate();
            await fillInvoiceInputs(invoice);
        }
        #endregion

        private async void Btn_shortageInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (invoice.invoiceId != 0)
                clearInvoice();
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
                invType = invoice.invType,
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

        private void Dg_billDetails_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _IsFocused = true;
        }

       
    }
}

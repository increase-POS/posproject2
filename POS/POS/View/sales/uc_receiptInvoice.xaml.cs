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
using System.Windows.Threading;
using System.Threading;
using System.Windows.Resources;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_receiptInvoice.xaml
    /// </summary>
    public partial class uc_receiptInvoice : UserControl
    {
        string invoicePermission = "reciptInvoice_invoice";
        string returnPermission = "reciptInvoice_return";
        string paymentsPermission = "reciptInvoice_payments";
        string executeOrderPermission = "reciptInvoice_executeOrder";
        string quotationPermission = "reciptInvoice_quotation";
        string sendEmailPermission = "reciptInvoice_sendEmail";

        private static uc_receiptInvoice _instance;
        public static uc_receiptInvoice Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_receiptInvoice();
                return _instance;
            }
        }
        public uc_receiptInvoice()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;
        Card cardModel = new Card();
        IEnumerable<Card> cards;
        Agent agentModel = new Agent();
        IEnumerable<Agent> customers;
        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;
        Invoice invoiceModel = new Invoice();
        List<Invoice> invoices;
        public Invoice invoice = new Invoice();
        Coupon couponModel = new Coupon();
        IEnumerable<Coupon> coupons;
        List<CouponInvoice> selectedCoupons = new List<CouponInvoice>();
        Branch branchModel = new Branch();
        Pos posModel = new Pos();
        Pos pos;
        List<ItemTransfer> invoiceItems;
        List<ItemTransfer> mainInvoiceItems;
        CashTransfer cashTransfer = new CashTransfer();
        ItemLocation itemLocationModel = new ItemLocation();
        ShippingCompanies companyModel = new ShippingCompanies();
        List<ShippingCompanies> companies;
        User userModel = new User();
        List<User> users;
        private static DispatcherTimer timer;
        #region//to handle barcode characters
        static private int _SelectedCustomer = -1;
        static private int _SelectedDiscountType = -1;
        static private string _SelectedPaymentType = "cash";
        static private int _SelectedCard = -1;
        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        static private string _BarcodeStr = "";
        static private object _Sender;
        #endregion

        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;

        //for bill details
        static private int _SequenceNum = 0;
        static private int _invoiceId;
        static private decimal _Sum = 0;
        static private decimal _Tax = 0;
        static private decimal _Discount = 0;
        static private decimal _DeliveryCost = 0;
        static public string _InvoiceType = "sd"; // sale draft

        // for report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public static int width;
        public static int itemscount;
        public static int height;
        Invoice prInvoice = new Invoice();
        int prinvoiceId;
        #region bill

        public class BillDetails
        {
            public int ID { get; set; }
            public int itemId { get; set; }
            public int itemUnitId { get; set; }
            public int? offerId { get; set; }
            public string Product { get; set; }
            public string Unit { get; set; }
            public int Count { get; set; }
            public decimal Price { get; set; }
            public decimal Total { get; set; }
            public decimal Tax { get; set; }
            public List<string> serialList { get; set; }
            public bool valid { get; set; }
            public string type { get; set; }
        }

        #endregion

        private void translate()
        {
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trQuantity");
            dg_billDetails.Columns[5].Header = MainWindow.resourcemanager.GetString("trPrice");
            dg_billDetails.Columns[6].Header = MainWindow.resourcemanager.GetString("trAmount");

            txt_tax.Text = MainWindow.resourcemanager.GetString("trTax");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal");
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
            //txt_barcode.Text = MainWindow.resourcemanager.GetString("trBarcode");
            txt_coupon.Text = MainWindow.resourcemanager.GetString("trCoupon");
            txt_customer.Text = MainWindow.resourcemanager.GetString("trCustomer");
            txt_delivery.Text = MainWindow.resourcemanager.GetString("trDelivery");
            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_totalDescount.Text = MainWindow.resourcemanager.GetString("trDiscount");


            txt_printInvoice.Text = MainWindow.resourcemanager.GetString("trPrint");
            txt_preview.Text = MainWindow.resourcemanager.GetString("trPreview");
            txt_invoiceImages.Text = MainWindow.resourcemanager.GetString("trImages");
            txt_items.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_drafts.Text = MainWindow.resourcemanager.GetString("trDrafts");
            txt_newDraft.Text = MainWindow.resourcemanager.GetString("trNew");
            txt_emailMessage.Text = MainWindow.resourcemanager.GetString("trSendEmail");
            txt_payments.Text = MainWindow.resourcemanager.GetString("trReceived");
            txt_returnInvoice.Text = MainWindow.resourcemanager.GetString("trReturn");
            txt_quotations.Text = MainWindow.resourcemanager.GetString("trQuotations");
            txt_ordersWait.Text = MainWindow.resourcemanager.GetString("trOrders");
            txt_invoices.Text = MainWindow.resourcemanager.GetString("trInvoices");

            tt_error_previous.Content = MainWindow.resourcemanager.GetString("trPrevious");
            tt_error_next.Content = MainWindow.resourcemanager.GetString("trNext");
            txt_cardTitle.Text = MainWindow.resourcemanager.GetString("tr_Card") + ":";
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_barcode, MainWindow.resourcemanager.GetString("trBarcodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_coupon, MainWindow.resourcemanager.GetString("trCoponHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trCustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_company, MainWindow.resourcemanager.GetString("trCompanyHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_user, MainWindow.resourcemanager.GetString("trUserHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentProcessTypeHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_card, MainWindow.resourcemanager.GetString("trCardHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_processNum, MainWindow.resourcemanager.GetString("trProcessNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_typeDiscount, MainWindow.resourcemanager.GetString("trDiscountTypeHint"));

            btn_save.Content = MainWindow.resourcemanager.GetString("trPay");
        }

        private async void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.KeyDown -= HandleKeyPress;
                saveBeforeExit();
                //if (billDetails.Count > 0 &&( _InvoiceType == "sd" || _InvoiceType == "sbd"))
                //{
                //    #region Accept
                //    MainWindow.mainWindow.Opacity = 0.2;
                //    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                //    w.contentText = MainWindow.resourcemanager.GetString("trSaveInvoiceNotification");

                //    w.ShowDialog();
                //    MainWindow.mainWindow.Opacity = 1;
                //    #endregion
                //    if (w.isOk)
                //        Btn_newDraft_Click(null, null);
                //    else
                //        await clearInvoice();
                //}
                //else
                //    await clearInvoice();
                timer.Stop();
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
        private async void saveBeforeExit()
        {
            if (billDetails.Count > 0 && (_InvoiceType == "sd" || _InvoiceType == "sbd"))
            {
                #region Accept
                MainWindow.mainWindow.Opacity = 0.2;
                wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                w.contentText = MainWindow.resourcemanager.GetString("trSaveInvoiceNotification");

                w.ShowDialog();
                MainWindow.mainWindow.Opacity = 1;
                #endregion
                if (w.isOk)
                    Btn_newDraft_Click(null, null);
                else
                {
                    await clearInvoice();
                    setNotifications();
                }
            }
            else
            {
                await clearInvoice();
                setNotifications();
            }
        }
        public async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);
                MainWindow.mainWindow.KeyDown += HandleKeyPress;
                tb_moneyIcon.Text = MainWindow.Currency;
                tb_moneyIconTotal.Text = MainWindow.Currency;

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

                tb_moneyIcon.Text = MainWindow.Currency;
                tb_moneyIconDis.Text = MainWindow.Currency;
                translate();

                catigoriesAndItemsView.ucReceiptInvoice = this;
                 tb_barcode.Focus();
                pos = await posModel.getPosById(MainWindow.posID.Value);
                configurProcessType();
                configureDiscountType();
                setNotifications();
                setTimer();
                await RefrishItems();
                await RefrishCustomers();
                await fillBarcodeList();
                await fillCouponsList();
                await fillShippingCompanies();
                await fillUsers();
                #region fill card combo
                cards = await cardModel.GetAll();
                //cb_card.ItemsSource = cards;
                //cb_card.DisplayMemberPath = "name";
                //cb_card.SelectedValuePath = "cardId";
                //cb_card.SelectedIndex = -1;
                InitializeCardsPic(cards);

                #endregion
                #region Style Date
                SectionData.defaultDatePickerStyle(dp_desrvedDate);
                #endregion
                //tb_taxValue.Text = MainWindow.tax.ToString();
                if (MainWindow.tax == 0)
                    sp_tax.Visibility = Visibility.Collapsed;
                else
                {
                    tb_taxValue.Text = SectionData.DecTostring(MainWindow.tax);
                    sp_tax.Visibility = Visibility.Visible;
                }
               
                #region datagridChange
                //CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
                //((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
                #endregion

                #region Permision

                if (MainWindow.groupObject.HasPermissionAction(returnPermission, MainWindow.groupObjects, "one"))
                    btn_returnInvoice.Visibility = Visibility.Visible;
                else
                    btn_returnInvoice.Visibility = Visibility.Collapsed;

                if (MainWindow.groupObject.HasPermissionAction(paymentsPermission, MainWindow.groupObjects, "one"))
                {
                    md_payments.Visibility = Visibility.Visible;
                    bdr_payments.Visibility = Visibility.Visible;
                }
                else
                {
                    md_payments.Visibility = Visibility.Collapsed;
                    bdr_payments.Visibility = Visibility.Collapsed;
                }

                if (MainWindow.groupObject.HasPermissionAction(executeOrderPermission, MainWindow.groupObjects, "one"))
                    md_ordersWait.Visibility = Visibility.Visible;
                else
                    md_ordersWait.Visibility = Visibility.Collapsed;

                if (MainWindow.groupObject.HasPermissionAction(quotationPermission, MainWindow.groupObjects, "one"))
                    md_quotations.Visibility = Visibility.Visible;
                else
                    md_quotations.Visibility = Visibility.Collapsed;

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

        #region timer to refresh notifications
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
                //if (sendert != null)
                //    SectionData.StartAwait(grid_main);
                await refreshOrdersWaitNotification();
                await refreshQuotationNotification();
                if (invoice.invoiceId != 0)
                {
                    await refreshDocCount(invoice.invoiceId);
                    if (_InvoiceType == "s" || _InvoiceType == "sb")
                        await refreshPaymentsNotification(invoice.invoiceId);
                }
                //if (sendert != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sendert != null)
                    //SectionData.EndAwait(grid_main);
                    SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        #region notifications
        private async void setNotifications()
        {
            try
            {
                await refreshDraftNotification();
                await refreshOrdersWaitNotification();
                await refreshQuotationNotification();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async Task refreshDraftNotification()
        {
            string invoiceType = "sd ,sbd";
            int duration = 2;
            int draftCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);
            if ((_InvoiceType == "sd" || _InvoiceType == "sbd") && invoice.invoiceId != 0)
                draftCount--;

            int previouseCount = 0;
            if (md_draft.Badge != null && md_draft.Badge.ToString() != "") previouseCount = int.Parse(md_draft.Badge.ToString());

            if (draftCount != previouseCount)
            {
                if (draftCount > 9)
                {
                    draftCount = 9;
                    md_draft.Badge = "+" + draftCount.ToString();
                }
                else if (draftCount == 0) md_draft.Badge = "";
                else
                    md_draft.Badge = draftCount.ToString();
            }
        }
        private async Task refreshOrdersWaitNotification()
        {
            string invoiceType = "or";
            int ordersCount = await invoice.GetCountUnHandeledOrders(invoiceType, 0, MainWindow.branchID.Value);
            if (_InvoiceType == "or" && invoice.invoiceId != 0)
                ordersCount--;

            int previouseCount = 0;
            if (md_ordersWait.Badge != null && md_ordersWait.Badge.ToString() != "") previouseCount = int.Parse(md_ordersWait.Badge.ToString());

            if (ordersCount != previouseCount)
            {
                if (ordersCount > 9)
                {
                    ordersCount = 9;
                    md_ordersWait.Badge = "+" + ordersCount.ToString();
                }
                else if (ordersCount == 0) md_ordersWait.Badge = "";
                else
                    md_ordersWait.Badge = ordersCount.ToString();
            }
        }
        private async Task refreshQuotationNotification()
        {
            string invoiceType = "q";
            int ordersCount = await invoice.GetCountUnHandeledOrders(invoiceType, MainWindow.branchID.Value);
            if (_InvoiceType == "q" && invoice.invoiceId != 0)
                ordersCount--;

            int previouseCount = 0;
            if (md_quotations.Badge != null && md_quotations.Badge.ToString() != "") previouseCount = int.Parse(md_quotations.Badge.ToString());

            if (ordersCount != previouseCount)
            {
                if (ordersCount > 9)
                {
                    ordersCount = 9;
                    md_quotations.Badge = "+" + ordersCount.ToString();
                }
                else if (ordersCount == 0) md_quotations.Badge = "";
                else
                    md_quotations.Badge = ordersCount.ToString();
            }
        }
        private async Task refreshDocCount(int invoiceId)
        {
            DocImage doc = new DocImage();
            int docCount = await doc.GetDocCount("Invoices", invoiceId);

            int previouseCount = 0;
            if (md_docImage.Badge != null && md_docImage.Badge.ToString() != "") previouseCount = int.Parse(md_docImage.Badge.ToString());

            if (docCount != previouseCount)
            {
                if (docCount > 9)
                {
                    docCount = 9;
                    md_docImage.Badge = "+" + docCount.ToString();
                }
                else if (docCount == 0) md_docImage.Badge = "";
                else
                    md_docImage.Badge = docCount.ToString();
            }
        }
        private async Task refreshPaymentsNotification(int invoiceId)
        {
            int paymentsCount = await cashTransfer.GetCashCount(invoice.invoiceId);
            int previouseCount = 0;
            if (md_payments.Badge != null && md_payments.Badge.ToString() != "") previouseCount = int.Parse(md_payments.Badge.ToString());

            if (paymentsCount != previouseCount)
            {
                if (paymentsCount > 9)
                {
                    paymentsCount = 9;
                    md_payments.Badge = "+" + paymentsCount.ToString();
                }
                else if (paymentsCount == 0) md_payments.Badge = "";
                else
                    md_payments.Badge = paymentsCount.ToString();
            }

        }
        #endregion
        async Task RefrishCustomers()
        {
            customers = await agentModel.GetAgentsActive("c");
            cb_customer.ItemsSource = customers;
            cb_customer.DisplayMemberPath = "name";
            cb_customer.SelectedValuePath = "agentId";
        }
        async Task RefrishItems()
        {
            items = await itemModel.GetAllItems();
        }
        async Task fillBarcodeList()
        {
            barcodesList = await itemUnitModel.Getall();
        }
        async Task fillCouponsList()
        {
            coupons = await couponModel.GetEffictiveCoupons();

            cb_coupon.DisplayMemberPath = "name";
            cb_coupon.SelectedValuePath = "cId";
            cb_coupon.ItemsSource = coupons;
        }
        private void configurProcessType()
        {
            cb_paymentProcessType.DisplayMemberPath = "Text";
            cb_paymentProcessType.SelectedValuePath = "Value";
            if (_InvoiceType.Equals("sbd"))
            {
                var typelist = new[] {
                 new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
                new { Text = MainWindow.resourcemanager.GetString("trCredit") , Value = "balance" },
                };
                cb_paymentProcessType.ItemsSource = typelist;
            }
            else
            {
                var typelist = new[] {
                new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
                new { Text = MainWindow.resourcemanager.GetString("trCredit") , Value = "balance" },
                new { Text = MainWindow.resourcemanager.GetString("trCreditCard") , Value = "card" },
                 };

                cb_paymentProcessType.ItemsSource = typelist;
            }
            cb_paymentProcessType.SelectedIndex = 0;
        }
        private void configureDiscountType()
        {
            var dislist = new[] {
            new { Text = "", Value = -1 },
            new { Text = MainWindow.resourcemanager.GetString("trValueDiscount"), Value = 1 },
            new { Text = MainWindow.resourcemanager.GetString("trPercentageDiscount"), Value = 2 },
             };

            cb_typeDiscount.DisplayMemberPath = "Text";
            cb_typeDiscount.SelectedValuePath = "Value";
            cb_typeDiscount.ItemsSource = dislist;
            cb_typeDiscount.SelectedIndex = 0;
        }
        private async Task fillShippingCompanies()
        {
            companies = await companyModel.Get();
            cb_company.ItemsSource = companies;
            cb_company.DisplayMemberPath = "name";
            cb_company.SelectedValuePath = "shippingCompanyId";
        }
        private async Task fillUsers()
        {
            users = await userModel.GetUsersActive();
            cb_user.ItemsSource = users;
            cb_user.DisplayMemberPath = "name";
            cb_user.SelectedValuePath = "userId";
        }
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
                        // calculate new sum
                        _Sum -= row.Total;
                        _Tax -= row.Tax;

                        // remove item from bill
                        billDetails.RemoveAt(index);

                        ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
                        data.Remove(row);

                        // calculate new total
                        refreshTotalValue();
                    }
                _SequenceNum = 0;
                _Sum = 0;
                _Tax = 0;
                for (int i = 0; i < billDetails.Count; i++)
                {
                    _SequenceNum++;
                    _Sum += billDetails[i].Total;
                    _Tax += billDetails[i].Tax;
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

        private void Btn_updateCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (cb_customer.SelectedIndex != -1)
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_updateVendor w = new wd_updateVendor();
                    //// pass agent id to update windows
                    w.agent.agentId = (int)cb_customer.SelectedValue;
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
        #region Get Id By Click  Y
        public async Task ChangeItemIdEvent(int itemId)
        {
            if (items != null) item = items.ToList().Find(c => c.itemId == itemId);

            if (item != null)
            {
                this.DataContext = item;

                // get item units
                itemUnits = await itemUnitModel.GetItemUnits(item.itemId);
                // search for default unit for purchase
                var defaultsaleUnit = itemUnits.ToList().Find(c => c.defaultSale == 1);
                if (defaultsaleUnit != null)
                {
                    decimal itemTax = 0;
                    if (item.taxes != null)
                        itemTax = (decimal)item.taxes;
                    decimal price = (decimal)defaultsaleUnit.price + SectionData.calcPercentage((decimal)defaultsaleUnit.price, itemTax);
                    await addItemToBill(itemId, defaultsaleUnit.itemUnitId, defaultsaleUnit.mainUnit, price, false);

                }
                else
                {
                    bool valid = true;
                    if (item.type == "sn")
                        valid = false;
                    int? offerId;
                    if (item.offerId != null)
                        offerId = (int)item.offerId;
                    else
                        offerId = null;
                    addRowToBill(item.name, itemId, null, 0, 1, 0, 0, (decimal)item.taxes, item.type, valid,offerId);
                }
            }
        }
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
        private async Task<bool> validateInvoiceValues()
        {
            bool valid;
            bool available = true;
            SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

            // validate empty values
            if (cb_paymentProcessType.SelectedIndex != -1)
            {
                switch (cb_paymentProcessType.SelectedIndex)
                {
                    case 0:
                        SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        break;
                    case 1:
                        {
                            SectionData.validateEmptyComboBox(cb_customer, p_errorCustomer, tt_errorCustomer, "trEmptyCustomerToolTip");
                            exp_customer.IsExpanded = true;
                            break;
                        }
                    case 2:
                        SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        SectionData.validateEmptyTextBox(tb_processNum, p_errorProcessNum, tt_errorProcessNum, "trEmptyProcessNumToolTip");
                        SectionData.validateEmptyTextBlock(txt_card, p_errorCard, tt_errorCard, "trSelectCreditCard");
                        break;
                }
            }

            // check amount
            if (_InvoiceType == "sd" || _InvoiceType == "or")
                available = await checkItemsAmounts();
            // validate items serials
            foreach (BillDetails item in billDetails)
            {
                if (item.valid == false)
                {
                    valid = false;
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorNoSerialToolTip"), animation: ToasterAnimation.FadeIn);

                    return valid;
                }
            }
            #region validate sales man
            //com
            SectionData.clearComboBoxValidate(cb_user, p_errorUser);
            if (companyModel.deliveryType == "local" && cb_user.SelectedIndex == -1)
            {
                valid = false;
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trSelectTheDeliveryMan"), animation: ToasterAnimation.FadeIn);
                SectionData.validateEmptyComboBox(cb_user, p_errorUser, tt_errorUser, "trSelectTheDeliveryMan");

                return valid;
            }
            #endregion
            if (billDetails.Count > 0 && available && ((cb_paymentProcessType.SelectedIndex == 1 && cb_customer.SelectedIndex != -1)
            || (cb_paymentProcessType.SelectedIndex == 0)
            || (cb_paymentProcessType.SelectedIndex == 2 && !tb_processNum.Text.Equals("") && _SelectedCard != -1)))
                valid = true;
            else
                valid = false;
            if (valid == true)
                valid = validateItemUnits();

            if (valid)
            {
                if (cb_paymentProcessType.SelectedIndex == 1 && (companyModel == null || companyModel.deliveryType != "com"))
                {
                    int agentId = (int)cb_customer.SelectedValue;
                    Agent customer = customers.ToList().Find(b => b.agentId == agentId && b.isLimited == true);
                    if (customer != null)
                    {
                        float customerBalance = customer.balance;
                        decimal remain = 0;
                        if (customer.balanceType == 0)
                        {
                            remain = decimal.Parse(tb_total.Text) - (decimal)customerBalance;
                        }
                        else
                            remain = (decimal)customer.balance + decimal.Parse(tb_total.Text);

                        if (remain > customer.maxDeserve)
                        {
                            valid = false;
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorMaxDeservedExceeded"), animation: ToasterAnimation.FadeIn);
                        }
                    }
                    else
                    {
                        valid = false;
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorMaxDeservedExceeded"), animation: ToasterAnimation.FadeIn);
                    }
                }
            }
            return valid;
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

        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_processNum")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorProcessNum, tt_errorProcessNum, "trEmptyProcessNumToolTip");
                }
                if (name == "ComboBox")
                {
                    if ((sender as ComboBox).Name == "cb_customer")
                    {
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCustomer, tt_errorCustomer, "trEmptyCustomerToolTip");
                        exp_customer.IsExpanded = true;

                    }
                    if ((sender as ComboBox).Name == "cb_paymentProcessType")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                    
                }
                if (name == "TextBlock")
                {
                   
                   if ((sender as TextBlock).Name == "txt_card")
                        SectionData.validateEmptyTextBlock((TextBlock)sender, p_errorCard, tt_errorCard, "trSelectCreditCard");
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        #region save invoice
        private async Task saveSaleInvoice(string invType)
        {
            await addInvoice(invType);
            if (invoice.invoiceId != 0)
            {
                await saveOrderStatus(invoice.invoiceId, "pr"); // under processing
                await saveOrderStatus(invoice.invoiceId, "ex"); // under excution
                if (cb_company.SelectedIndex == -1)
                    await saveOrderStatus(invoice.invoiceId, "rc"); // recieved
            }
        }
        private async Task saveOrder(string invType)
        {
            await addInvoice(invType);
            if (invoice.invoiceId != 0)
            {
                #region notification Object
                Notification not = new Notification()
                {
                    title = "trDeliverOrderAlertTilte",
                    ncontent = "trDeliverOrderAlertContent",
                    msgType = "alert",
                    createUserId = MainWindow.userID.Value,
                    updateUserId = MainWindow.userID.Value,
                };
                Branch branch = new Branch();
                branch = await branch.getBranchById(MainWindow.branchID.Value);
                await not.Save(not, MainWindow.branchID.Value, "saleAlerts_shippingUser", branch.name, (int)invoice.shipUserId);
                #endregion
                await saveOrderStatus(invoice.invoiceId, "ex");
            }
        }
        private async Task saveOrderStatus(int invoiceId, string status)
        {
            invoiceStatus st = new invoiceStatus();
            st.status = status;
            st.invoiceId = invoiceId;
            st.createUserId = MainWindow.userLogin.userId;
            st.isActive = 1;
            await invoice.saveOrderStatus(st);
        }
        private async Task addInvoice(string invType)
        {
            if ((invoice.invType == "s" && (invType == "sb" || invType == "sbd")) || _InvoiceType == "or" || _InvoiceType == "q") // invoice is sale and will be bounce sale  or sale bounce draft  , save another invoice in db
            {
                invoice.invoiceMainId = invoice.invoiceId;
                invoice.invoiceId = 0;
                if (invType == "sb")
                    invoice.invNumber = await invoice.generateInvNumber("sb");
                else if (invType == "sbd")
                    invoice.invNumber = await invoice.generateInvNumber("sbd");
                else if (_InvoiceType == "or" || _InvoiceType == "q")
                    invoice.invNumber = await invoice.generateInvNumber("si");
            }
            // build invoice NUM 
            else if ((invoice.invNumber == null && invType == "s") || (invoice.invType == "sd" && invType == "s"))
            {
                invoice.invNumber = await invoice.generateInvNumber("si");
                invoice.branchId = MainWindow.branchID.Value;
            }
            else if (invoice.invType == "sbd" && invType == "sb") // convert invoicce from draft bounce to bounce
                invoice.invNumber = await invoice.generateInvNumber("sb");
            else if (invType == "sd" && invoice.invoiceId == 0)
                invoice.invNumber = await invoice.generateInvNumber("sd");
            if (invoice.branchCreatorId == 0 || invoice.branchCreatorId == null)
            {
                invoice.branchCreatorId = MainWindow.branchID.Value;
                invoice.posId = MainWindow.posID.Value;
            }

            if (invoice.invType != "s" || invoice.invoiceId == 0)
            {
                invoice.posId = MainWindow.posID;
                invoice.discountValue = _Discount;
                invoice.discountType = "1";
                if (cb_typeDiscount.SelectedIndex != -1)
                    invoice.manualDiscountType = cb_typeDiscount.SelectedValue.ToString();
                if (tb_discount.Text != "")
                    invoice.manualDiscountValue = decimal.Parse(tb_discount.Text);
                invoice.total = _Sum;
                invoice.totalNet = decimal.Parse(tb_total.Text);

                if (cb_customer.SelectedIndex != -1)
                    invoice.agentId = (int)cb_customer.SelectedValue;


                invoice.deservedDate = dp_desrvedDate.SelectedDate;
                invoice.notes = tb_note.Text;

                if (tb_taxValue.Text != "")
                    invoice.tax = decimal.Parse(tb_taxValue.Text);
                else
                    invoice.tax = 0;

                if (cb_company.SelectedIndex != -1)
                    invoice.shippingCompanyId = (int)cb_company.SelectedValue;
                if (cb_user.SelectedIndex != -1)
                    invoice.shipUserId = (int)cb_user.SelectedValue;

                invoice.paid = 0;
                invoice.deserved = invoice.totalNet;
                invoice.createUserId = MainWindow.userID;
                invoice.updateUserId = MainWindow.userID;



                invoice.invType = invType;

                // save invoice in DB
                int invoiceId = int.Parse(await invoiceModel.saveInvoice(invoice));
                invoice.invoiceId = invoiceId;
                prinvoiceId = invoiceId;
                if (invoiceId == -1)// إظهار رسالة الترقية
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpgrade"), animation: ToasterAnimation.FadeIn);
                else if (invoiceId == 0) // an error occure
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                else
                {
                    // add invoice details
                    invoiceItems = new List<ItemTransfer>();
                    ItemTransfer itemT;
                    for (int i = 0; i < billDetails.Count; i++)
                    {
                        itemT = new ItemTransfer();
                        itemT.invoiceId = 0;
                        itemT.quantity = billDetails[i].Count;
                        itemT.price = billDetails[i].Price;
                        itemT.itemUnitId = billDetails[i].itemUnitId;
                        itemT.offerId = billDetails[i].offerId;
                        string serialNum = "";
                        if (billDetails[i].serialList != null)
                        {
                            List<string> lst = billDetails[i].serialList.ToList();
                            for (int j = 0; j < lst.Count; j++)
                            {
                                serialNum += lst[j];
                                if (j != lst.Count - 1)
                                    serialNum += ",";
                            }
                        }
                        itemT.itemSerial = serialNum;
                        itemT.createUserId = MainWindow.userID;

                        invoiceItems.Add(itemT);
                    }
                    await invoiceModel.saveInvoiceItems(invoiceItems, invoiceId);

                    // edit vendor balance , add cach transfer
                    if (invType == "s")
                    {
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
                        await itemLocationModel.decreaseAmounts(invoiceItems, MainWindow.branchID.Value, MainWindow.userID.Value, "storageAlerts_minMaxItem", not); // update item quantity in DB
                        await invoice.recordPosCashTransfer(invoice, "si");                                                                                                         //if (paid > 0)
                                                                                                                                                                                    //{
                        switch (cb_paymentProcessType.SelectedIndex)
                        {
                            case 0:// cash: update pos balance
                                pos.balance += invoice.totalNet;
                                await pos.savePos(pos);
                                // cach transfer model
                                CashTransfer cashTrasnfer = new CashTransfer();
                                cashTrasnfer.transType = "d"; //deposit
                                cashTrasnfer.posId = MainWindow.posID;
                                cashTrasnfer.agentId = invoice.agentId;
                                cashTrasnfer.invId = invoiceId;
                                cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("dc");
                                cashTrasnfer.cash = invoice.totalNet;
                                cashTrasnfer.side = "c"; // customer
                                cashTrasnfer.processType = cb_paymentProcessType.SelectedValue.ToString();
                                if (cb_paymentProcessType.SelectedValue.ToString().Equals("card"))
                                {
                                    cashTrasnfer.cardId = _SelectedCard;
                                    cashTrasnfer.docNum = tb_processNum.Text;
                                }
                                cashTrasnfer.createUserId = MainWindow.userID;
                                await cashTrasnfer.Save(cashTrasnfer); //add cash transfer  
                                break;
                            case 1:// balance: update customer balance
                                if (cb_company.SelectedIndex != -1 && companyModel.deliveryType.Equals("com"))
                                    await invoice.recordCompanyCashTransfer(invoice, "si");
                                else
                                    await invoice.recordCashTransfer(invoice, "si");
                                break;
                        }
                    }
                    else if (invType == "sb")
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
                        await itemLocationModel.recieptInvoice(invoiceItems, MainWindow.branchID.Value, MainWindow.userID.Value, "storageAlerts_minMaxItem", not); // update item quantity in DB
                        await invoice.recordPosCashTransfer(invoice, "sb");
                        switch (cb_paymentProcessType.SelectedIndex)
                        {
                            case 0:
                            case 2: // cash:card: update pos balance

                                pos.balance -= invoice.totalNet;
                                await pos.savePos(pos);
                                // cach transfer model
                                CashTransfer cashTrasnfer = new CashTransfer();
                                cashTrasnfer.transType = "p"; //pull
                                cashTrasnfer.posId = MainWindow.posID;
                                cashTrasnfer.agentId = invoice.agentId;
                                cashTrasnfer.invId = invoiceId;
                                cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("pc");
                                cashTrasnfer.cash = invoice.totalNet;
                                cashTrasnfer.side = "c"; // customer
                                cashTrasnfer.processType = cb_paymentProcessType.SelectedValue.ToString();
                                if (cb_paymentProcessType.SelectedValue.ToString().Equals("card"))
                                {
                                    cashTrasnfer.cardId = _SelectedCard;
                                    cashTrasnfer.docNum = tb_processNum.Text;
                                }
                                //  cashTrasnfer
                                cashTrasnfer.createUserId = MainWindow.userID;
                                await cashTrasnfer.Save(cashTrasnfer); //add cash transfer    
                                break;
                            case 1:// balance: update customer balance
                                await invoice.recordCashTransfer(invoice, "sb");
                                break;
                        }

                        //update items quantity
                    }

                    #region save coupns on invoice
                    //CouponInvoice invCoupon;
                    //invCouponList.Clear();
                    foreach (CouponInvoice ci in selectedCoupons)
                    {
                        ci.InvoiceId = invoiceId;
                        ci.createUserId = MainWindow.userID;
                    }
                    await invoiceModel.saveInvoiceCoupons(selectedCoupons, invoiceId, invoice.invType);
                    #endregion
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                }

                // }
            }
        }

        //bool logInProcessing = true;
        //void awaitSaveBtn(bool isAwait)
        //{
        //    if (isAwait == true)
        //    {
        //        btn_save.IsEnabled = false;
        //        wait_saveBtn.Visibility = Visibility.Visible;
        //        wait_saveBtn.IsIndeterminate = true;
        //    }
        //    else
        //    {
        //        btn_save.IsEnabled = true;
        //        wait_saveBtn.Visibility = Visibility.Collapsed;
        //        wait_saveBtn.IsIndeterminate = false;
        //    }
        //}
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (((MainWindow.groupObject.HasPermissionAction(invoicePermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                        &&
                        (invoice.invType == "sd" || invoice.invType == "s"))
                        || (invoice.invType != "sd" && invoice.invType != "s"))
                {
                    //if (logInProcessing)
                    //{
                    //    logInProcessing = false;
                    //awaitSaveBtn(true);
                    //check mandatory inputs
                    bool valid = await validateInvoiceValues();

                    if (valid)
                    {

                        if (_InvoiceType == "sbd") //sbd means sale bounse draft
                        {
                            await addInvoice("sb"); // sb means sale bounce
                            await clearInvoice();
                            await refreshDraftNotification();
                        }
                        else if (_InvoiceType == "or")
                        {
                            await saveOrder("s");
                            await clearInvoice();
                            await refreshOrdersWaitNotification();
                        }
                        else//s  sale invoice
                        {
                            await saveSaleInvoice("s");
                            await clearInvoice();
                            await refreshDraftNotification();
                        }

                        //thread  + purchases
                        if (invoice.invType == "s")
                        {

                            if (MainWindow.print_on_save_sale == "1")
                            {
                                // printInvoice();
                                Thread t1 = new Thread(() =>
                                {
                                    printInvoice();
                                });
                                t1.Start();
                            }
                            if (MainWindow.email_on_save_sale == "1")
                            {
                                //sendsaleEmail();
                                Thread t1 = new Thread(() =>
                                {
                                    sendsaleEmail();
                                });
                                t1.Start();
                            }
                        }
                        prinvoiceId = 0;
                    }
                    //awaitSaveBtn(false);
                    //logInProcessing = true;
                    //}
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
            for (int i = 0; i < billDetails.Count; i++)
            {
                if (billDetails[i].itemUnitId == 0)
                {
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trItemWithNoUnit"), animation: ToasterAnimation.FadeIn);
                    return false;
                }
                if(billDetails[i].Count == 0)
                {
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trItemWithNoCount"), animation: ToasterAnimation.FadeIn);
                    return false;
                }
            }
            return true;
        }
        private async void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (billDetails.Count > 0 && (_InvoiceType == "sd" || _InvoiceType == "sbd"))
                {
                    Boolean available = true;
                    if (_InvoiceType == "sd")
                        available = await checkItemsAmounts();
                    bool valid = validateItemUnits();
                    if (billDetails.Count > 0 && available && valid)
                    {
                        await addInvoice(_InvoiceType);
                        // await refreshDraftNotification();
                        await clearInvoice();
                        setNotifications();
                    }
                    else if (billDetails.Count == 0)
                    {
                        _InvoiceType = "sd";
                        await clearInvoice();
                    }

                }
                else
                {
                    await clearInvoice();
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
        private async Task clearInvoice()
        {
            _Sum = 0;
            _Tax = 0;
            _Discount = 0;
            _DeliveryCost = 0;
            _SequenceNum = 0;
            txt_invNumber.Text = "";
            _SelectedCustomer = -1;
            _SelectedDiscountType = 0;
            _SelectedPaymentType = "cash";
            _SelectedCard = -1;
            _InvoiceType = "sd";
            invoice = new Invoice();
            selectedCoupons.Clear();
            tb_barcode.Clear();
            cb_customer.SelectedIndex = -1;
            cb_customer.SelectedItem = "";
            dp_desrvedDate.Text = "";
            tb_note.Clear();
            billDetails.Clear();
            tb_total.Text = "0";
            tb_sum.Text = "0";
            tb_discount.Clear();
            cb_typeDiscount.SelectedIndex = 0;
            _SelectedCard = -1;
            cb_company.SelectedIndex = -1;
            cb_user.SelectedIndex = -1;
            tb_processNum.Clear();
            cb_paymentProcessType.SelectedIndex = 0;
            cb_paymentProcessType.IsEnabled = true;
            lst_coupons.Items.Clear();
            //tb_discountCoupon.Text = "0";
            md_docImage.Badge = "";
            md_payments.Badge = "";
            gd_card.Visibility = Visibility.Collapsed;
            btn_deleteInvoice.Visibility = Visibility.Collapsed;
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
            btn_save.Content = MainWindow.resourcemanager.GetString("trPay");
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearTextBlockValidate(txt_card, p_errorCard);
            SectionData.clearComboBoxValidate(cb_user, p_errorUser);
            SectionData.clearValidate(tb_processNum, p_errorProcessNum);
            refrishBillDetails();
            tb_barcode.Focus();
            inputEditable();
            //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
            btn_next.Visibility = Visibility.Collapsed;
            btn_previous.Visibility = Visibility.Collapsed;
            await fillCouponsList();
        }
        #endregion
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();
                string invoiceType = "sd ,sbd";
                int duration = 2;
                w.invoiceType = invoiceType; //sales draft invoices , sales bounce drafts
                w.userId = MainWindow.userLogin.userId;
                w.duration = duration; // view drafts which updated during 2 last days 
                w.title = MainWindow.resourcemanager.GetString("trDrafts");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;
                        _InvoiceType = invoice.invType;
                        _invoiceId = invoice.invoiceId;
                        // notifications
                        md_payments.Badge = "";
                        setNotifications();
                        await refreshDocCount(invoice.invoiceId);

                        await fillInvoiceInputs(invoice);
                        invoices = await invoice.GetInvoicesByCreator(invoiceType, MainWindow.userID.Value, duration);
                        navigateBtnActivate();

                        // set title to bill
                        if (_InvoiceType == "sd")
                        {
                            mainInvoiceItems = invoiceItems;
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesDraft");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;
                            btn_save.Content = MainWindow.resourcemanager.GetString("trReturn");
                            //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                        }
                        if (_InvoiceType == "sbd")
                        {
                            mainInvoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceMainId.Value);
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                            btn_save.Content = MainWindow.resourcemanager.GetString("trPay");
                            //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        // orange #FFA926 red #D22A17
                        txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                        btn_save.Content = MainWindow.resourcemanager.GetString("trPay");
                        //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));


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
        private async Task getInvoiceCoupons(int invoiceId)
        {
            lst_coupons.Items.Clear();
            if (_InvoiceType != "sd")
                selectedCoupons = await invoiceModel.GetInvoiceCoupons(invoiceId);
            else
                selectedCoupons = await invoiceModel.getOriginalCoupons(invoiceId);
            foreach (CouponInvoice invCoupon in selectedCoupons)
            {
                lst_coupons.Items.Add(invCoupon.couponCode);
            }
        }
        private async void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                saveBeforeExit();
                Window.GetWindow(this).Opacity = 0.2;

                wd_invoice w = new wd_invoice();

                // sale invoices
                string invoiceType = "s , sb";
                int duration = 1;
                w.invoiceType = invoiceType;
                // w.branchCreatorId = MainWindow.branchID.Value;
                w.userId = MainWindow.userLogin.userId;
                w.duration = duration; // view drafts which updated during 1 last days 

                w.title = MainWindow.resourcemanager.GetString("trInvoices");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;

                        _InvoiceType = invoice.invType;
                        _invoiceId = invoice.invoiceId;

                        // set title to bill
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
                        txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                        btn_save.Content = MainWindow.resourcemanager.GetString("trPay");
                        // orange #FFA926 red #D22A17
                        //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        //txt_totalDescount.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                        //txt_total.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;


                        await fillInvoiceInputs(invoice);
                        invoices = await invoice.GetInvoicesByCreator(invoiceType, MainWindow.userID.Value, duration);
                        navigateBtnActivate();

                        mainInvoiceItems = invoiceItems;
                        setNotifications();
                        await refreshDocCount(invoice.invoiceId);
                        await refreshPaymentsNotification(invoice.invoiceId);
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
                if (MainWindow.groupObject.HasPermissionAction(executeOrderPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    saveBeforeExit();
                    Window.GetWindow(this).Opacity = 0.2;

                    wd_invoice w = new wd_invoice();

                    // sale invoices
                    string invoiceType = "or";
                    w.invoiceType = invoiceType;
                    w.condition = "orders";
                    w.branchId = MainWindow.branchID.Value;
                    w.title = MainWindow.resourcemanager.GetString("trOrders");

                    if (w.ShowDialog() == true)
                    {
                        if (w.invoice != null)
                        {
                            invoice = w.invoice;
                            _invoiceId = invoice.invoiceId;
                            _InvoiceType = invoice.invType;
                            //notifications
                            setNotifications();
                            await refreshDocCount(invoice.invoiceId);
                            md_payments.Badge = "";

                            // set title to bill
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSaleOrder");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                            btn_save.Content = MainWindow.resourcemanager.GetString("trPay");
                            // orange #FFA926 red #D22A17
                            //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                            //txt_totalDescount.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                            //txt_total.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                            await fillInvoiceInputs(invoice);
                            invoices = await invoice.getUnHandeldOrders(invoiceType, 0, MainWindow.branchID.Value);
                            navigateBtnActivate();

                            mainInvoiceItems = invoiceItems;
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
        public async Task fillInvoiceInputs(Invoice invoice)
        {
            configurProcessType();
            if (invoice.total != null)
                _Sum = (decimal)invoice.total;
            else
                _Sum = 0;
            txt_invNumber.Text = invoice.invNumber.ToString();
            if (invoice.tax != null)
            {
                _Tax = (decimal)invoice.tax;
                //tb_taxValue.Text = invoice.tax.ToString();
                tb_taxValue.Text = SectionData.DecTostring(MainWindow.tax);

                //_Discount = (decimal) invoice.discountValue;
                //if (invoice.discountValue != 0 && invoice.discountValue != null)
                //    tb_discountCoupon.Text = SectionData.DecTostring(invoice.discountValue);
                //else
                //    tb_discountCoupon.Text = "0";
            }
            if (_InvoiceType == "sbd")
            {
                _Tax = 0;
                //tb_taxValue.Text = _Tax.ToString();
                if (_Tax != 0)
                    tb_taxValue.Text = SectionData.DecTostring(_Tax);
                else
                    tb_taxValue.Text = "0";

                //tb_discountCoupon.Text = "0";
            }
            cb_customer.SelectedValue = invoice.agentId;
            dp_desrvedDate.Text = invoice.deservedDate.ToString();
            if (invoice.totalNet != null)
            {
                //tb_total.Text = Math.Round((double)invoice.totalNet, 2).ToString();
                if ((decimal)invoice.totalNet != 0 && invoice.totalNet != null)
                    tb_total.Text = SectionData.DecTostring((decimal)invoice.totalNet);
                else
                    tb_total.Text = "0";
            }
            cb_company.SelectedValue = invoice.shippingCompanyId;
            cb_user.SelectedValue = invoice.shipUserId;
            tb_note.Text = invoice.notes;
            //tb_sum.Text = invoice.total.ToString();
            if (invoice.total != 0 && invoice.total != null)
                tb_sum.Text = SectionData.DecTostring(invoice.total);
            else tb_sum.Text = "0";

            //tb_discount.Text = invoice.manualDiscountValue.ToString();
            if (invoice.manualDiscountValue != 0)
                tb_discount.Text = SectionData.DecTostring(invoice.manualDiscountValue);
            else
                tb_discount.Text = "0";
            if (invoice.manualDiscountType == "1")
                cb_typeDiscount.SelectedIndex = 1;
            else if (invoice.manualDiscountType == "2")
                cb_typeDiscount.SelectedIndex = 2;
            else
                cb_typeDiscount.SelectedIndex = 0;

            tb_barcode.Clear();
            tb_barcode.Focus();

            if (invoice.invType == "s")//get payment information          
            {
                CashTransfer cashTrasnfer = new CashTransfer();// cach transfer model
                cashTrasnfer = await cashTrasnfer.GetByInvId(invoice.invoiceId);
                cb_paymentProcessType.SelectedValue = cashTrasnfer.processType;
                switch (cashTrasnfer.processType)
                {
                    case "cash":
                    case "balance":
                        gd_card.Visibility = Visibility.Collapsed;
                       _SelectedCard = -1;
                        txt_card.Text = "";
                        tb_processNum.Clear();
                        break;
                    case "card":
                        gd_card.Visibility = Visibility.Visible;
                        _SelectedCard = cashTrasnfer.cardId.Value;
                        tb_processNum.Text = cashTrasnfer.docNum;
                        break;
                }
            }
            else if (invoice.invType == "or")
            {
                cb_paymentProcessType.SelectedValue = "balance";
            }
            //if (_InvoiceType != "sbd" && _InvoiceType != "sd")
            await getInvoiceCoupons(invoice.invoiceId);
            // build invoice details grid
            await buildInvoiceDetails(invoice.invoiceId);
            inputEditable();
            refreshTotalValue();
        }
        private async void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(returnPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    saveBeforeExit();
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_invoice w = new wd_invoice();
                    w.title = MainWindow.resourcemanager.GetString("trReturn");
                    w.branchCreatorId = MainWindow.branchID.Value;
                    // sales invoices
                    string invoiceType = "s";
                    w.invoiceType = invoiceType; // invoice type to view in grid
                    if (w.ShowDialog() == true)
                    {
                        if (w.invoice != null)
                        {
                            _InvoiceType = "sbd";
                            invoice = w.invoice;
                            _invoiceId = invoice.invoiceId;

                            //this.DataContext = invoice;
                            await fillInvoiceInputs(invoice);
                            invoices = await invoice.getBranchInvoices(invoiceType, MainWindow.branchID.Value);
                            navigateBtnActivate();
                            mainInvoiceItems = invoiceItems;
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesReturnInvoice");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;
                            btn_save.Content = MainWindow.resourcemanager.GetString("trReturn");
                            // orange #FFA926 red #D22A17
                            //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                            //txt_totalDescount.Foreground = Application.Current.Resources["mediumRed"] as SolidColorBrush;
                            //txt_total.Foreground = Application.Current.Resources["mediumRed"] as SolidColorBrush;

                            md_payments.Badge = "";
                            setNotifications();
                            await refreshDocCount(invoice.invoiceId);
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
        private async Task buildInvoiceDetails(int invoiceId)
        {
            //get invoice items
            invoiceItems = await invoiceModel.GetInvoicesItems(invoiceId);
            // build invoice details grid
            _SequenceNum = 0;
            billDetails.Clear();
            foreach (ItemTransfer itemT in invoiceItems)
            {
                _SequenceNum++;
                bool isValid = true;
                decimal total = (decimal)(itemT.price * itemT.quantity);
                List<string> serialNumLst = new List<string>();
                if (itemT.itemSerial != "")
                {
                    string[] serialsArray = itemT.itemSerial.Split(',');
                    foreach (string s in serialsArray)
                        serialNumLst.Add(s.Trim());
                }
                if (itemT.itemType == "sn" && serialNumLst.Count < itemT.quantity && (_InvoiceType == "sd" || _InvoiceType == "q" || _InvoiceType == "spd"))
                    isValid = false;

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
                    serialList = serialNumLst,
                    type = itemT.itemType,
                    valid = isValid,
                    offerId = itemT.offerId,
                });
            }

            tb_barcode.Focus();

            refrishBillDetails();
        }
        private void inputEditable()
        {
            switch (_InvoiceType)
            {
                case "sbd": // sales bounce draft invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                    dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                    dg_billDetails.Columns[5].IsReadOnly = false; //make price writable
                    cb_customer.IsEnabled = false;
                    dp_desrvedDate.IsEnabled = false;
                    tb_note.IsEnabled = false;
                    tb_barcode.IsEnabled = false;
                    //tb_discountCoupon.IsEnabled = false;
                    btn_save.IsEnabled = true;
                    bdr_paymentDetails.IsEnabled = true;
                    cb_paymentProcessType.IsEnabled = true;
                    dkp_cards.IsEnabled = false;
                    cb_company.IsEnabled = false;
                    cb_user.IsEnabled = false;
                    tb_processNum.IsEnabled = false;
                    cb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
                    tb_discount.IsEnabled = false;
                    cb_typeDiscount.IsEnabled = false;
                    btn_deleteInvoice.Visibility = Visibility.Collapsed;
                    break;
                case "sd": // sales draft invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                    dg_billDetails.Columns[3].IsReadOnly = false;
                    dg_billDetails.Columns[4].IsReadOnly = false;
                    dg_billDetails.Columns[5].IsReadOnly = true; //make price readonly
                    cb_customer.IsEnabled = true;
                    dp_desrvedDate.IsEnabled = true;
                    tb_note.IsEnabled = true;
                    tb_barcode.IsEnabled = true;
                    //tb_discountCoupon.IsEnabled = true;
                    btn_save.IsEnabled = true;
                    bdr_paymentDetails.IsEnabled = true;
                    dkp_cards.IsEnabled = true;
                    cb_company.IsEnabled = true;
                    cb_user.IsEnabled = true;
                    tb_processNum.IsEnabled = true;
                    cb_coupon.IsEnabled = true;
                    btn_clearCoupon.IsEnabled = true;
                    btn_deleteInvoice.Visibility = Visibility.Collapsed;
                    if (cb_company.SelectedIndex != -1)
                    {
                        cb_paymentProcessType.IsEnabled = false;
                        cb_paymentProcessType.SelectedIndex = 1;
                    }
                    else
                    {
                        cb_paymentProcessType.IsEnabled = true;
                    }
                    tb_discount.IsEnabled = true;
                    cb_typeDiscount.IsEnabled = true;
                    break;
                case "or": //sales order
                    dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                    dg_billDetails.Columns[3].IsReadOnly = false;
                    dg_billDetails.Columns[4].IsReadOnly = false;
                    dg_billDetails.Columns[5].IsReadOnly = true; //make price readonly
                    cb_customer.IsEnabled = false;
                    dp_desrvedDate.IsEnabled = true;
                    tb_note.IsEnabled = true;
                    tb_barcode.IsEnabled = true;
                    //tb_discountCoupon.IsEnabled = true;
                    btn_save.IsEnabled = true;
                    bdr_paymentDetails.IsEnabled = true;
                    dkp_cards.IsEnabled = true;
                    cb_company.IsEnabled = true;
                    cb_user.IsEnabled = true;
                    tb_processNum.IsEnabled = true;
                    cb_coupon.IsEnabled = true;
                    btn_clearCoupon.IsEnabled = true;
                    btn_deleteInvoice.Visibility = Visibility.Visible;
                    if (cb_company.SelectedIndex != -1)
                    {
                        cb_paymentProcessType.IsEnabled = false;
                        cb_paymentProcessType.SelectedIndex = 1;
                    }
                    else
                    {
                        cb_paymentProcessType.IsEnabled = true;
                    }
                    tb_discount.IsEnabled = true;
                    cb_typeDiscount.IsEnabled = true;
                    break;
                case "s": //sales invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                    dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                    dg_billDetails.Columns[5].IsReadOnly = true; //make price read only
                    cb_customer.IsEnabled = false;
                    dp_desrvedDate.IsEnabled = false;
                    tb_note.IsEnabled = false;
                    tb_barcode.IsEnabled = false;
                    //tb_discountCoupon.IsEnabled = false;
                    btn_save.IsEnabled = false;
                    bdr_paymentDetails.IsEnabled = false;
                    cb_paymentProcessType.IsEnabled = false;
                    dkp_cards.IsEnabled = false;
                    cb_company.IsEnabled = false;
                    cb_user.IsEnabled = false;
                    tb_processNum.IsEnabled = false;
                    cb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
                    btn_deleteInvoice.Visibility = Visibility.Collapsed;
                    tb_discount.IsEnabled = false;
                    cb_typeDiscount.IsEnabled = false;
                    break;
                case "q": //qoutation invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                    dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                    dg_billDetails.Columns[5].IsReadOnly = true; //make price read only
                    cb_customer.IsEnabled = false;
                    dp_desrvedDate.IsEnabled = true;
                    tb_note.IsEnabled = false;
                    tb_barcode.IsEnabled = false;
                    //tb_discountCoupon.IsEnabled = false;
                    btn_save.IsEnabled = true;
                    bdr_paymentDetails.IsEnabled = true;
                    cb_paymentProcessType.IsEnabled = false;
                    dkp_cards.IsEnabled = false;
                    cb_company.IsEnabled = false;
                    cb_user.IsEnabled = false;
                    tb_processNum.IsEnabled = false;
                    cb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
                    btn_deleteInvoice.Visibility = Visibility.Collapsed;
                    if (cb_company.SelectedIndex != -1)
                    {
                        cb_paymentProcessType.IsEnabled = false;
                        cb_paymentProcessType.SelectedIndex = 1;
                    }
                    else
                    {
                        cb_paymentProcessType.IsEnabled = true;
                    }
                    tb_discount.IsEnabled = false;
                    cb_typeDiscount.IsEnabled = false;
                    break;
            }
            btn_next.Visibility = Visibility.Visible;
            btn_previous.Visibility = Visibility.Visible;
        }
        private async void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (invoice != null && invoice.invoiceId != 0)
                {
                    Window.GetWindow(this).Opacity = 0.2;

                    wd_uploadImage w = new wd_uploadImage();

                    w.tableName = "invoices";
                    w.tableId = invoice.invoiceId;
                    w.docNum = invoice.invNumber;
                    w.ShowDialog();
                    await refreshDocCount(invoice.invoiceId);
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trChooseInvoiceToolTip"), animation: ToasterAnimation.FadeIn);
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

        private void Cb_customer_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                cb_customer.ItemsSource = customers.Where(x => x.name.Contains(cb_customer.Text));
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_customer.SelectedIndex != -1)
                {
                    _SelectedCustomer = (int)cb_customer.SelectedValue;

                }
                else
                {
                    cb_customer.SelectedValue = _SelectedCustomer;
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
        private void tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                _Sender = sender;
                refreshTotalValue();
                e.Handled = true;
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
        private void refreshTotalValue()
        {
            _Discount = 0;
            decimal totalDiscount = 0;
            decimal manualDiscount = 0;
            if (_Sum > 0)
            {
                #region calculate discount value 
                foreach (CouponInvoice coupon in selectedCoupons)
                {
                    string discountType = coupon.discountType.ToString();
                    decimal discountValue = (decimal)coupon.discountValue;
                    if (discountType == "2")
                        discountValue = SectionData.calcPercentage(_Sum, discountValue);
                    _Discount += discountValue;
                }
                //tb_discountCoupon.Text = _Discount.ToString();
                //if (_Discount != 0)
                //    tb_discountCoupon.Text = SectionData.DecTostring(_Discount);
                //else
                //    tb_discountCoupon.Text = "0";
                #endregion
                #region manaula discount           
                if (cb_typeDiscount.SelectedIndex != -1 && cb_typeDiscount.SelectedIndex != 0 && tb_discount.Text != "")
                {
                    int manualDisType = cb_typeDiscount.SelectedIndex;
                    manualDiscount = decimal.Parse(tb_discount.Text);
                    if (manualDisType == 2)
                        manualDiscount = SectionData.calcPercentage(_Sum, manualDiscount);
                }
                #endregion
                totalDiscount = _Discount + manualDiscount;
            }
            decimal taxValue = _Tax;
            decimal total = _Sum -totalDiscount  + _DeliveryCost;
            //if (MainWindow.isInvTax == 1)
            //{
            taxValue = SectionData.calcPercentage(total, (decimal)MainWindow.tax);
            //}
            //else
            //    tb_taxValue.Text = _Tax.ToString();
            total += taxValue;
            //tb_sum.Text = _Sum.ToString();
            if (_Sum != 0)
                tb_sum.Text = SectionData.DecTostring(_Sum);
            else
                tb_sum.Text = "0";
            //tb_total.Text = Math.Round(total, 2).ToString();
            if (total != 0)
                tb_total.Text = SectionData.DecTostring(total);
            else
                tb_total.Text = "0";

            if (totalDiscount != 0)
                tb_totalDescount.Text = SectionData.DecTostring(totalDiscount);
            else
                tb_totalDescount.Text = "0";

        }
        #region billdetails

        bool firstTimeForDatagrid = true;
        async void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            //if (billDetails.Count == 1)
            //{
            //    BillDetails bd = new BillDetails();
            //    billDetails.Add(bd);
            //    dg_billDetails.ItemsSource = billDetails;
            //    billDetails.Remove(bd);
            //}
            //else
                dg_billDetails.ItemsSource = billDetails;
            if (firstTimeForDatagrid)
            {
                await Task.Delay(1000);
                dg_billDetails.Items.Refresh();
                firstTimeForDatagrid = false;
            }
            //dg_billDetails.Items.Refresh();
            DataGrid_CollectionChanged(dg_billDetails, null);


            //tb_sum.Text = _Sum.ToString();
            //if (_Sum != 0)
            //    tb_sum.Text = SectionData.DecTostring(_Sum);
            //else
            //    tb_sum.Text = "0";
            //if (MainWindow.isInvTax == 0)
            //{
            //tb_taxValue.Text = _Tax.ToString();
            //if (_Tax != 0)
            //    tb_taxValue.Text = SectionData.DecTostring(_Tax);
            //else
            //    tb_taxValue.Text = "0";
            //}
        }
        void refrishDataGridItems()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;
            dg_billDetails.Items.Refresh();
        }

        // read item from barcode
        private async void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
                {
                //tb_barcode.Focus();
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 80)
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

               if (e.Key.ToString() == "Return" && _BarcodeStr != "" && (_InvoiceType == "sd" || _InvoiceType == "or" || _InvoiceType =="q"))
                {
                    await dealWithBarcode(_BarcodeStr);
                    if (_Sender != null) //clear barcode from inputs
                    {
                        DatePicker dt = _Sender as DatePicker;
                        TextBox tb = _Sender as TextBox;
                        if (dt != null)
                        {
                            if (dt.Name == "dp_desrvedDate")
                                _BarcodeStr = _BarcodeStr.Substring(1);
                        }
                        else if (tb != null)
                        {
                            if (tb.Name == "tb_processNum" || tb.Name == "tb_note" || tb.Name == "tb_discount")// remove barcode from text box
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
                    _BarcodeStr = "";
                    e.Handled = true;
                }
                _Sender = null;
                //_BarcodeStr = "";
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
                case "si":// this barcode for invoice

                    Btn_newDraft_Click(null, null);
                    invoice = await invoiceModel.GetInvoicesByNum(barcode);
                    _InvoiceType = invoice.invType;
                    if (_InvoiceType.Equals("sd") || _InvoiceType.Equals("s") || _InvoiceType.Equals("sbd") || _InvoiceType.Equals("sb"))
                    {
                        // set title to bill
                        if (_InvoiceType == "sd")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesDraft");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                            btn_save.Content = MainWindow.resourcemanager.GetString("trPay");
                            //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        else if (_InvoiceType == "s")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                            btn_save.Content = MainWindow.resourcemanager.GetString("trPay");
                            //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        else if (_InvoiceType == "sbd")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesReturnDraft");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;
                            btn_save.Content = MainWindow.resourcemanager.GetString("trReturn");
                            //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                        }
                        else if (_InvoiceType == "sb")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesReturnInvoice");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;
                            btn_save.Content = MainWindow.resourcemanager.GetString("trReturn");
                            // orange #FFA926 red #D22A17
                            //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                        }

                        await fillInvoiceInputs(invoice);
                    }
                    break;
                case "cop":// this barcode for coupon
                    {
                        // await fillCouponsList();
                        couponModel = coupons.ToList().Find(c => c.barcode == barcode);
                        var exist = selectedCoupons.Find(c => c.couponId == couponModel.cId);
                        if (couponModel != null && exist == null)
                        {
                            if (couponModel.remainQ > 0 && couponModel.endDate >= DateTime.Now && couponModel.startDate <= DateTime.Now && _Sum >= couponModel.invMin && _Sum <= couponModel.invMax)
                            {
                                CouponInvoice ci = new CouponInvoice();
                                ci.couponId = couponModel.cId;
                                ci.discountType = couponModel.discountType;
                                ci.discountValue = couponModel.discountValue;

                                lst_coupons.Items.Add(couponModel.code);
                                selectedCoupons.Add(ci);
                                refreshTotalValue();
                            }
                            else if (couponModel.remainQ == 0)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponQuantity"), animation: ToasterAnimation.FadeIn);
                            else if (couponModel.endDate < DateTime.Now)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponExpire"), animation: ToasterAnimation.FadeIn);
                            else if (couponModel.startDate > DateTime.Now)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponNotActive"), animation: ToasterAnimation.FadeIn);
                            else if (_Sum < couponModel.invMin)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorMinInvToolTip"), animation: ToasterAnimation.FadeIn);
                            else if (_Sum > couponModel.invMax)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorMaxInvToolTip"), animation: ToasterAnimation.FadeIn);
                        }
                        else
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponExist"), animation: ToasterAnimation.FadeIn);
                        }
                        cb_coupon.SelectedIndex = -1;
                        cb_coupon.SelectedItem = "";
                    }
                    break;
                case "cus":// this barcode for customer
                    break;
                default: // if barcode for item
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
                                await addItemToBill(itemId, unit1.itemUnitId, unit1.mainUnit, (decimal)unit1.price, false);
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
        private async Task addItemToBill(int itemId, int itemUnitId, string unitName, decimal price, bool valid)
        {
            item = items.ToList().Find(i => i.itemId == itemId);
            bool isValid = true;


            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == itemUnitId).FirstOrDefault());
            if (item.type == "sn")
            {
                isValid = false;
            }
            if (index == -1)//item doesn't exist in bill
            {
                // get item units
                itemUnits = await itemUnitModel.GetItemUnits(itemId);



                int count = 1;
                decimal total = count * price;
                decimal tax = (decimal)(count * item.taxes);
                int offerId = 0;
                if (item.offerId != null)
                    offerId = (int)item.offerId;
                addRowToBill(item.name, item.itemId, unitName, itemUnitId, count, price, total, tax, item.type, isValid,offerId);
            }
            else // item exist prevoiusly in list
            {
                decimal itemTax = 0;
                if (item.taxes != null)
                    itemTax = (decimal)item.taxes;
                billDetails[index].Count++;
                billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;
                billDetails[index].Tax = (decimal)(billDetails[index].Count * itemTax);
                billDetails[index].valid = isValid;

                _Sum += billDetails[index].Price;
                _Tax += billDetails[index].Tax;

            }

            //refreshTotalValue();
            //refrishBillDetails();
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
                    //if (_BarcodeStr != "" && _BarcodeStr.Length != 1)
                    //    barcode = _BarcodeStr;
                    //else
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

        private void addRowToBill(string itemName, int itemId, string unitName, int itemUnitId, int count, decimal price, decimal total, decimal tax, string type, bool valid,int? offerId, List<string> serialList = null)
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
                Tax = tax,
                type = type,
                valid = valid,
                offerId = offerId,
            });
            _Sum += total;
            _Tax += tax;

        }
        #endregion billdetails
        private async void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                var cmb = sender as ComboBox;
                TextBlock tb;
                if (dg_billDetails.SelectedIndex != -1 && cmb != null)
                {
                    int itemUnitId = (int)cmb.SelectedValue;
                    billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;

                    #region Dina
                    //var unit = itemUnits.ToList().Find(x => x.itemUnitId == (int)cmb.SelectedValue);
                    var unit = await itemUnitModel.GetById((int)cmb.SelectedValue);
                    //int availableAmount = await itemLocationModel.getAmountInBranch(itemUnitId, MainWindow.branchID.Value);
                    int availableAmount = await getAvailableAmount(billDetails[dg_billDetails.SelectedIndex].itemId, itemUnitId, MainWindow.branchID.Value, billDetails[dg_billDetails.SelectedIndex].ID);


                    int oldCount = 0;
                    long newCount = 0;
                    decimal oldPrice = 0;
                    decimal itemTax = 0;
                    if (item.taxes != null)
                        itemTax = (decimal)item.taxes;
                    decimal price = (decimal)unit.price + SectionData.calcPercentage((decimal)unit.price, itemTax);

                    // decimal newPrice = (decimal)unit.price;
                    decimal newPrice = price;

                    //"tb_amont"


                    oldCount = billDetails[dg_billDetails.SelectedIndex].Count;
                    oldPrice = billDetails[dg_billDetails.SelectedIndex].Price;

                    if (availableAmount < oldCount)
                    //if (availableAmount <= 0)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableToolTip"), animation: ToasterAnimation.FadeIn);
                        newCount = newCount + availableAmount;
                        tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[dg_billDetails.SelectedIndex]) as TextBlock;
                        tb.Text = availableAmount.ToString();
                    }
                    else
                    {
                        // newCount = oldCount;
                        tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[dg_billDetails.SelectedIndex]) as TextBlock;
                        newCount = int.Parse(tb.Text);
                    }

                    // old total for changed item
                    decimal total = oldPrice * oldCount;
                    _Sum -= total;


                    // new total for changed item
                    total = newCount * newPrice;
                    _Sum += total;
                    // old tax for changed item
                    decimal tax = (decimal)itemTax * oldCount;
                    _Tax -= tax;
                    // new tax for changed item
                    tax = (decimal)itemTax * newCount;
                    _Tax += tax;

                    //refresh total cell
                    tb = dg_billDetails.Columns[6].GetCellContent(dg_billDetails.Items[dg_billDetails.SelectedIndex]) as TextBlock;
                    tb.Text = total.ToString();

                    //  refresh sum and total text box
                    refreshTotalValue();

                    // update item in billdetails           
                    billDetails[dg_billDetails.SelectedIndex].Count = (int)newCount;
                    billDetails[dg_billDetails.SelectedIndex].Price = newPrice;
                    billDetails[dg_billDetails.SelectedIndex].Total = total;
                    refrishBillDetails();
                    #endregion
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
                            {}
                           
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
                //if (ex.HResult != -2146233079)
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Dg_billDetails_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (_InvoiceType == "sbd"  || _InvoiceType == "sd" || _InvoiceType == "or" || _InvoiceType == "q")
                e.Cancel = false;
            else if (  _InvoiceType == "s" || _InvoiceType == "sb")
                e.Cancel = true;
        }
     
        #region
        public DataGridCell GetDataGridCell(DataGridCellInfo cellInfo)
        {
            var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
            if (cellContent != null)
                return (DataGridCell)cellContent.Parent;

            return null;
        }
        #endregion
        #region
        static DataGridCell TryToFindGridCell(DataGrid grid, DataGridCellInfo cellInfo)
        {
            DataGridCell result = null;
            DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(cellInfo.Item);
            if (row != null)
            {
                int columnIndex = grid.Columns.IndexOf(cellInfo.Column);
                if (columnIndex > -1)
                {
                    DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
                    result = presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridCell;
                }
            }
            return result;
        }

        static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        #endregion

        private async void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                TextBlock tb;
                TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
                var columnName = e.Column.Header.ToString();

                BillDetails row = e.Row.Item as BillDetails;
                int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == row.itemUnitId).FirstOrDefault());

                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds < 100)
                {
                    if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
                        t.Text = billDetails[index].Count.ToString();
                    else if (columnName == MainWindow.resourcemanager.GetString("trPrice"))
                        t.Text = billDetails[index].Price.ToString();
                }
                else
                {
                    int oldCount = 0;
                    long newCount = 0;
                    decimal oldPrice = 0;
                    decimal newPrice = 0;

                    //"tb_amont"
                    if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
                    {
                        newCount = int.Parse(t.Text);
                        if (row.type == "sn")
                            billDetails[index].valid = false;
                    }
                    else
                        newCount = row.Count;

                    oldCount = row.Count;

                    if (_InvoiceType == "sbd")
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
                    else
                    {
                        int availableAmount = await getAvailableAmount(row.itemId, row.itemUnitId, MainWindow.branchID.Value, row.ID);
                        if (availableAmount < newCount)
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableToolTip"), animation: ToasterAnimation.FadeIn);
                            //newCount = newCount + availableAmount;
                            newCount = availableAmount;
                            tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[index]) as TextBlock;
                            tb.Text = newCount.ToString();
                            row.Count = (int)newCount;
                        }
                    }

                    if (columnName == MainWindow.resourcemanager.GetString("trPrice"))
                        newPrice = decimal.Parse(t.Text);
                    else
                        newPrice = row.Price;

                    oldPrice = row.Price;

                    // old total for changed item
                    decimal total = oldPrice * oldCount;
                    _Sum -= total;


                    // new total for changed item
                    total = newCount * newPrice;
                    _Sum += total;

                    decimal itemTax = 0;
                    if (item.taxes != null)
                        itemTax = (decimal)item.taxes;
                    // old tax for changed item
                    decimal tax = (decimal)itemTax * oldCount;
                    _Tax -= tax;
                    // new tax for changed item
                    tax = (decimal)itemTax * newCount;
                    _Tax += tax;

                    //refresh total cell
                    tb = dg_billDetails.Columns[6].GetCellContent(dg_billDetails.Items[index]) as TextBlock;
                    tb.Text = total.ToString();

                    //  refresh sum and total text box
                    refreshTotalValue();

                    // update item in billdetails           
                    billDetails[index].Count = (int)newCount;
                    billDetails[index].Price = newPrice;
                    billDetails[index].Total = total;

                }
                //dg_billDetails.CancelEdit();
                //dg_billDetails.CancelEdit();
                //dg_billDetails.Items.Refresh();

                //dg_billDetails.CommitEdit();
                //dg_billDetails.Items.Refresh();
                refrishDataGridItems();
                //refrishBillDetails();
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
        private async Task<int> getAvailableAmount(int itemId, int itemUnitId, int branchId, int ID)
        {
            var itemUnits = await itemUnitModel.GetItemUnits(itemId);
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
        private void Dp_date_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                _Sender = sender;
                moveControlToBarcode(sender, e);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void moveControlToBarcode(object sender, KeyEventArgs e)
        {
            try
            {
                DatePicker dt = sender as DatePicker;
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds < 100)
                {
                    tb_barcode.Focus();
                    HandleKeyPress(sender, e);
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        //
        public async Task<string> SaveSalepdf()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();
            string pdfpath = "";

            //
            if (prInvoice.invType == "pd" || prInvoice.invType == "sd" || prInvoice.invType == "qd"
                                       || prInvoice.invType == "sbd" || prInvoice.invType == "pbd"
                                       || prInvoice.invType == "ord" || prInvoice.invType == "imd" || prInvoice.invType == "exd")
            {
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintDraftInvoice"), animation: ToasterAnimation.FadeIn);
            }
            else
            {


                if (prInvoice.invoiceId > 0)
                {
                    ////////////////////////
                    string folderpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath) + @"\Thumb\report\";
                    ReportCls.clearFolder(folderpath);

                    pdfpath = @"\Thumb\report\File" + DateTime.Now.ToFileTime().ToString() + ".pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                    User employ = new User();
                    employ = await userModel.getUserById((int)prInvoice.updateUserId);
                    prInvoice.uuserName = employ.name;
                    prInvoice.uuserLast = employ.lastname;

                    if (prInvoice.agentId != null)
                    {
                        Agent agentinv = new Agent();
                        agentinv = customers.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();


                        prInvoice.agentCode = agentinv.code;
                        //new lines
                        prInvoice.agentName = agentinv.name;
                        prInvoice.agentCompany = agentinv.company;
                    }
                    else
                    {
                        prInvoice.agentCode = "-";
                        prInvoice.agentName = "-";
                        prInvoice.agentCompany = "-";
                    }
                    string reppath = reportclass.GetreceiptInvoiceRdlcpath(prInvoice, 0);
                    ReportCls.checkLang();
                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)prInvoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        prInvoice.branchName = branch.name;
                    }

                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillSaleInvReport(prInvoice, paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();

                    LocalReportExtensions.ExportToPDF(rep, pdfpath);

                }

            }
            return pdfpath;
        }

        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                /////////////////////////////////////
                Thread t1 = new Thread(() =>
                {
                    pdfPurInvoice();
                });
                t1.Start();
                //////////////////////////////////////
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

        public async void pdfPurInvoice()
        {
            if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
                         || invoice.invType == "sbd" || invoice.invType == "pbd"
                         || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
            {
                this.Dispatcher.Invoke(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintDraftInvoice"), animation: ToasterAnimation.FadeIn);
                });
            }
            else
            {

                List<ReportParameter> paramarr = new List<ReportParameter>();


                if (invoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);

                    User employ = new User();
                    employ = await userModel.getUserById((int)invoice.updateUserId);
                    invoice.uuserName = employ.name;
                    invoice.uuserLast = employ.lastname;

                    if (invoice.agentId != null)
                    {
                        Agent agentinv = new Agent();
                        agentinv = customers.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                        invoice.agentCode = agentinv.code;
                        //new lines
                        invoice.agentName = agentinv.name;
                        invoice.agentCompany = agentinv.company;
                    }
                    else
                    {
                        invoice.agentCode = "-";
                        invoice.agentName = "-";
                        invoice.agentCompany = "-";
                    }
                    string reppath = reportclass.GetreceiptInvoiceRdlcpath(invoice, 0);
                    ReportCls.checkLang();
                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        invoice.branchName = branch.name;
                    }
                    foreach (var i in invoiceItems)
                    {
                        i.price = decimal.Parse(SectionData.DecTostring(i.price));
                    }
                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillSaleInvReport(invoice, paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();

                    saveFileDialog.Filter = "PDF|*.pdf;";
                    this.Dispatcher.Invoke(() =>
                    {
                        if (saveFileDialog.ShowDialog() == true)
                        {

                            string filepath = saveFileDialog.FileName;

                            LocalReportExtensions.ExportToPDF(rep, filepath);
                        }
                    });

                }

            }
        }

        public async void printInvoice()
        {

            prInvoice = new Invoice();
            if (prinvoiceId != 0)
                prInvoice = await invoiceModel.GetById(prinvoiceId);
            else
                prInvoice = await invoiceModel.GetById(invoice.invoiceId);

            if (prInvoice.invType == "pd" || prInvoice.invType == "sd" || prInvoice.invType == "qd"
                || prInvoice.invType == "sbd" || prInvoice.invType == "pbd"
                || prInvoice.invType == "ord" || prInvoice.invType == "imd" || prInvoice.invType == "exd")
            {
                this.Dispatcher.Invoke(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintDraftInvoice"), animation: ToasterAnimation.FadeIn);
                });
                }
            else
            {

                List<ReportParameter> paramarr = new List<ReportParameter>();

                if (prInvoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(prInvoice.invoiceId);
                    itemscount = invoiceItems.Count();
                    string reppath = reportclass.GetreceiptInvoiceRdlcpath(prInvoice);

                    User employ = new User();
                    employ = await userModel.getUserById((int)prInvoice.updateUserId);
                    prInvoice.uuserName = employ.name;
                    prInvoice.uuserLast = employ.lastname;
                    if (prInvoice.agentId != null)
                    {
                        Agent agentinv = new Agent();

                        agentinv = customers.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();

                        prInvoice.agentCode = agentinv.code;
                        //new lines
                        prInvoice.agentName = agentinv.name;
                        prInvoice.agentCompany = agentinv.company;

                    }
                    else
                    {
                        prInvoice.agentCode = "-";
                        prInvoice.agentName = "-";
                        prInvoice.agentCompany = "-";
                    }
                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)prInvoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        prInvoice.branchName = branch.name;
                    }

                    ReportCls.checkLang();

                    foreach (var i in invoiceItems)
                    {
                        i.price = decimal.Parse(SectionData.DecTostring(i.price));
                    }
                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);

                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillSaleInvReport(prInvoice, paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();

                    this.Dispatcher.Invoke(() =>
                    {
                        if (MainWindow.salePaperSize == "A4")
                        {
                            LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.sale_printer_name, short.Parse(MainWindow.sale_copy_count));
                        }
                        else
                        {
                            LocalReportExtensions.customPrintToPrinter(rep, MainWindow.sale_printer_name, short.Parse(MainWindow.sale_copy_count), width, height);

                        }
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintEmptyInvoice"), animation: ToasterAnimation.FadeIn);
                    });
                }
            }
        }
        private async void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                ////////////////
                Thread t1 = new Thread(() =>
                {
                    printInvoice();
                });
                t1.Start();
                /////////////////


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

        private async void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                if (invoice.invoiceId > 0)
                {
                    Window.GetWindow(this).Opacity = 0.2;

                    List<ReportParameter> paramarr = new List<ReportParameter>();
                    string pdfpath = "";

                    ////////////////////////
                    string folderpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath) + @"\Thumb\report\";
                    ReportCls.clearFolder(folderpath);

                    pdfpath = @"\Thumb\report\Temp" + DateTime.Now.ToFileTime().ToString() + ".pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                    //////////////////////////////////

                    if (invoice.invoiceId > 0)
                    {
                        invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                        itemscount = invoiceItems.Count();
                        string reppath = reportclass.GetreceiptInvoiceRdlcpath(invoice);

                        User employ = new User();
                        employ = await userModel.getUserById((int)invoice.updateUserId);
                        invoice.uuserName = employ.name;
                        invoice.uuserLast = employ.lastname;

                        invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                        if (invoice.agentId != null)
                        {
                            Agent agentinv = new Agent();
                            agentinv = customers.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                            invoice.agentCode = agentinv.code;
                            //new lines
                            invoice.agentName = agentinv.name;
                            invoice.agentCompany = agentinv.company;
                        }
                        else
                        {
                            invoice.agentCode = "-";
                            invoice.agentName = "-";
                            invoice.agentCompany = "-";
                        }
                        //branch name
                        Branch branch = new Branch();
                        branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                        if (branch.branchId > 0)
                        {
                            invoice.branchName = branch.name;
                        }

                        invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                        ReportCls.checkLang();
                        foreach (var i in invoiceItems)
                        {
                            i.price = decimal.Parse(SectionData.DecTostring(i.price));
                        }
                        clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                        clsReports.setReportLanguage(paramarr);
                        clsReports.Header(paramarr);
                        paramarr = reportclass.fillSaleInvReport(invoice, paramarr);

                        rep.SetParameters(paramarr);
                        rep.Refresh();

                        if (invoice.invType == "s" && MainWindow.salePaperSize!= "A4")
                        {
                            LocalReportExtensions.customExportToPDF(rep, pdfpath, width, height);
                        }
                        else
                        {
                            LocalReportExtensions.ExportToPDF(rep, pdfpath);
                        }
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
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trSaveInvoiceToPreview"), animation: ToasterAnimation.FadeIn);
                }
                #endregion

                #region
                //Window.GetWindow(this).Opacity = 0.2;
                ///////////////////////
                //string pdfpath = "";
                //pdfpath = @"\Thumb\report\temp.pdf";
                //pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                //BuildReport();
                //LocalReportExtensions.ExportToPDF(rep, pdfpath);
                /////////////////////
                //wd_previewPdf w = new wd_previewPdf();
                //w.pdfPath = pdfpath;
                //if (!string.IsNullOrEmpty(w.pdfPath))
                //{
                //    w.ShowDialog();
                //    w.wb_pdfWebViewer.Dispose();
                //}
                //Window.GetWindow(this).Opacity = 1;
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

        public void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Sale\Ar\PackageReport.rdlc";
            }
            else
                addpath = @"\Reports\Sale\En\PackageReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();
        }
        public async void sendsaleEmail()
        {
            //
            if ((prinvoiceId > 0) || (invoice.invoiceId > 0))
            {
                prInvoice = new Invoice();
                if (prinvoiceId != 0)
                    prInvoice = await invoiceModel.GetById(prinvoiceId);
                else
                    prInvoice = await invoiceModel.GetById(invoice.invoiceId);

                if (prInvoice.invType == "pd" || prInvoice.invType == "sd" || prInvoice.invType == "qd"
                || prInvoice.invType == "sbd" || prInvoice.invType == "pbd"
                || prInvoice.invType == "ord" || prInvoice.invType == "imd" || prInvoice.invType == "exd")
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trCanNotSendDraftInvoice"), animation: ToasterAnimation.FadeIn);
                    });
                }
                else
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(prInvoice.invoiceId);
                    SysEmails email = new SysEmails();
                    EmailClass mailtosend = new EmailClass();
                    email = await email.GetByBranchIdandSide((int)MainWindow.branchID, "mg");
                    Agent toAgent = new Agent();
                    toAgent = customers.Where(x => x.agentId == prInvoice.agentId).FirstOrDefault();
                    if (toAgent == null)
                    {
                        //edit warning message to customer
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTheVendorHasNoEmail"), animation: ToasterAnimation.FadeIn);

                    }
                    else
                    {
                        //  int? itemcount = invoiceItems.Count();
                        if (email.emailId == 0)
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoEmailForThisDept"), animation: ToasterAnimation.FadeIn);
                        else
                        {
                            if (prInvoice.invoiceId == 0)
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

                                        List<SetValues> setvlist = new List<SetValues>();
                                        if (prInvoice.invType == "s")
                                        {
                                            setvlist = await setvmodel.GetBySetName("sale_email_temp");
                                        }
                                        else if (prInvoice.invType == "or")
                                        {
                                            setvlist = await setvmodel.GetBySetName("sale_order_email_temp");
                                        }
                                        else if (prInvoice.invType == "q")
                                        {
                                            setvlist = await setvmodel.GetBySetName("quotation_email_temp");
                                        }
                                        else
                                        {
                                            setvlist = await setvmodel.GetBySetName("sale_email_temp");
                                        }

                                        mailtosend = mailtosend.fillSaleTempData(prInvoice, invoiceItems, email, toAgent, setvlist);
                                        string pdfpath = await SaveSalepdf();

                                        mailtosend.AddAttachTolist(pdfpath);
                                        string msg = "";
                                        this.Dispatcher.Invoke(() =>
                                        {
                                            msg = mailtosend.Sendmail();// temp comment
                                            if (msg == "Failure sending mail.")
                                            {
                                                // msg = "No Internet connection";

                                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoInternetConnection"), animation: ToasterAnimation.FadeIn);
                                            }
                                            else if (msg == "mailsent")
                                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailSent"), animation: ToasterAnimation.FadeIn);
                                            else
                                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailNotSent"), animation: ToasterAnimation.FadeIn);
                                        });

                                    }
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trThereIsNoItemsToSend"), animation: ToasterAnimation.FadeIn);
                });
            }


            //
        }
        private async void Btn_emailMessage_Click(object sender, RoutedEventArgs e)
        {//email
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(sendEmailPermission, MainWindow.groupObjects, "one"))
                {

                    //await sendsaleEmail();
                    ////
                    Thread t1 = new Thread(() =>
                    {
                        sendsaleEmail();
                    });
                    t1.Start();
                    ////
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

        //
        private async void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            try
            { //items

                if (sender != null)
                    SectionData.StartAwait(grid_main);
                Window.GetWindow(this).Opacity = 0.2;
                wd_items w = new wd_items();
                w.CardType = "sales";
                w.ShowDialog();
                if (w.isActive)
                {
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

        private async void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                await clearInvoice();
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

        private async void Btn_quotations_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(quotationPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    saveBeforeExit();
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_invoice w = new wd_invoice();

                    // sale invoices
                    string invoiceType = "q";
                    w.invoiceType = invoiceType;
                    w.condition = "orders";
                    w.branchCreatorId = MainWindow.branchID.Value;
                    w.title = MainWindow.resourcemanager.GetString("trQuotations");

                    if (w.ShowDialog() == true)
                    {
                        if (w.invoice != null)
                        {
                            invoice = w.invoice;
                            //notifications
                            setNotifications();
                            md_payments.Badge = "";
                            await refreshDocCount(invoice.invoiceId);

                            _InvoiceType = invoice.invType;
                            _invoiceId = invoice.invoiceId;
                            // set title to bill
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trQuotations");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                            btn_save.Content = MainWindow.resourcemanager.GetString("trPay");
                            // orange #FFA926 red #D22A17
                            //brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                            await fillInvoiceInputs(invoice);
                            invoices = await invoice.getUnHandeldOrders(invoiceType, MainWindow.branchID.Value, 0);
                            navigateBtnActivate();

                            mainInvoiceItems = invoiceItems;


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

        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_paymentProcessType.SelectedIndex != -1)
                {
                    _SelectedPaymentType = cb_paymentProcessType.SelectedValue.ToString();
                }
                else
                {
                    cb_paymentProcessType.SelectedValue = _SelectedPaymentType;
                }

                switch (cb_paymentProcessType.SelectedIndex)
                {
                    case 0://cash
                        gd_card.Visibility = Visibility.Collapsed;
                        tb_processNum.Clear();
                        //cb_card.SelectedIndex = -1;
                        _SelectedCard = -1;
                        txt_card.Text = "";
                        dp_desrvedDate.IsEnabled = false;
                        SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        SectionData.clearValidate(tb_processNum, p_errorCard);
                        break;
                    case 1:// balance
                        gd_card.Visibility = Visibility.Collapsed;
                        dp_desrvedDate.IsEnabled = true;
                        tb_processNum.Clear();
                        //cb_card.SelectedIndex = -1;
                        _SelectedCard = -1;
                        txt_card.Text = "";
                        //SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                        SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        SectionData.clearValidate(tb_processNum, p_errorCard);
                        break;
                    case 2://card
                        dp_desrvedDate.IsEnabled = false;
                        gd_card.Visibility = Visibility.Visible;
                        SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        break;
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
        void InitializeCardsPic(IEnumerable<Card> cards)
        {
            #region cardImageLoad
            dkp_cards.Children.Clear();
            int userCount = 0;
            foreach (var item in cards)
            {
                    #region Button
                    Button button = new Button();
                    button.DataContext = item.name;
                    button.Tag = item.cardId;
                    button.Padding = new Thickness(0, 0, 0, 0);
                    button.Margin = new Thickness(2.5, 5, 2.5, 5);
                    button.Background = null;
                    button.BorderBrush = null;
                    button.Height = 35;
                    button.Width = 35;
                    button.Click += card_Click;
                    //Grid.SetColumn(button, 4);
                    #region grid
                    Grid grid = new Grid();
                    #region 
                    Ellipse ellipse = new Ellipse();
                    //ellipse.Margin = new Thickness(-5, 0, -5, 0);
                    ellipse.StrokeThickness = 1;
                    ellipse.Stroke = Application.Current.Resources["MainColorOrange"] as SolidColorBrush;
                    ellipse.Height = 35;
                    ellipse.Width = 35;
                    ellipse.FlowDirection = FlowDirection.LeftToRight;
                    ellipse.ToolTip = item.name;
                    userImageLoad(ellipse, item.image);
                    Grid.SetColumn(ellipse, userCount);
                    grid.Children.Add(ellipse);
                    #endregion
                    #endregion
                    button.Content = grid;
                    #endregion
                    dkp_cards.Children.Add(button);
               
            }
            #endregion
        }
        void card_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _SelectedCard = int.Parse(button.Tag.ToString());
            txt_card.Text = button.DataContext.ToString();
            //MessageBox.Show("Hey you Click me! I'm Card: " + _SelectedCard);
        }
        ImageBrush brush = new ImageBrush();
        async void userImageLoad(Ellipse ellipse, string image)
        {
            try
            {
                if (!string.IsNullOrEmpty(image))
                {
                    clearImg(ellipse);

                    byte[] imageBuffer = await cardModel.downloadImage(image); // read this as BLOB from your DB
                    var bitmapImage = new BitmapImage();
                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    ellipse.Fill = new ImageBrush(bitmapImage);
                }
                else
                {
                    clearImg(ellipse);
                }
            }
            catch
            {
                clearImg(ellipse);
            }
        }
        private void clearImg(Ellipse ellipse)
        {
            Uri resourceUri = new Uri("pic/no-image-icon-90x90.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            ellipse.Fill = brush;
        }
        private void PreventSpaces(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_clearCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                _SelectedCustomer = -1;
                cb_customer.SelectedIndex = -1;
                dp_desrvedDate.SelectedDate = null;
                tb_note.Clear();

                //btn_updateCustomer.IsEnabled = false;
                SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
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

        //private void Cb_card_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
        //        if (elapsed.TotalMilliseconds > 100 && cb_card.SelectedIndex != -1)
        //        {
        //            _SelectedCard = (int)cb_card.SelectedValue;
        //        }
        //        else
        //        {
        //            cb_card.SelectedValue = _SelectedCard;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SectionData.ExceptionMessage(ex, this);
        //    }
        //}

        private async void Tb_coupon_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (e.Key == Key.Return)
                {
                    string s = _BarcodeStr;
                    couponModel = coupons.ToList().Find(c => c.code == cb_coupon.Text || c.barcode == cb_coupon.Text);
                    if (couponModel != null)
                    {
                        s = couponModel.barcode;
                        await dealWithBarcode(s);
                    }
                    cb_coupon.SelectedIndex = -1;
                    cb_coupon.SelectedItem = "";
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

        private void Btn_clearCoupon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                _Discount = 0;
                selectedCoupons.Clear();
                lst_coupons.Items.Clear();
                cb_coupon.SelectedIndex = -1;
                cb_coupon.SelectedItem = "";
                refreshTotalValue();
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



        private void Cb_company_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (cb_company.SelectedIndex != -1)
                {
                    companyModel = companies.Find(c => c.shippingCompanyId == (int)cb_company.SelectedValue);
                    _DeliveryCost = (decimal)companyModel.deliveryCost;
                    refreshTotalValue();

                    cb_paymentProcessType.SelectedIndex = 1; // balance
                    cb_paymentProcessType.IsEnabled = false;
                    if (companyModel.deliveryType == "local")
                    {
                        cb_user.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        cb_user.SelectedIndex = -1;
                        cb_user.Visibility = Visibility.Collapsed;
                        p_errorUser.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    cb_user.Visibility = Visibility.Collapsed;
                    p_errorUser.Visibility = Visibility.Collapsed;
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




        private void Btn_payments_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (invoice != null && invoice.invoiceId != 0)
                {
                    if (MainWindow.groupObject.HasPermissionAction(paymentsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                    {
                        Window.GetWindow(this).Opacity = 0.2;
                        wd_cashTransfer w = new wd_cashTransfer();

                        w.invId = invoice.invoiceId;
                        w.title = MainWindow.resourcemanager.GetString("trReceived");

                        w.ShowDialog();

                        Window.GetWindow(this).Opacity = 1;
                    }
                    else
                        Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
        private void serialItemsRow(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
                int itemId = row.itemId;
                item = items.ToList().Find(i => i.itemId == itemId);
                if (item.type == "sn")
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_serialNum w = new wd_serialNum();
                    w.itemCount = row.Count;
                    w.serialList = row.serialList;
                    w.valid = row.valid;
                    if (w.ShowDialog() == true)
                    {
                        if (w.serialList != null)
                        {
                            List<string> serialNumList = w.serialList;
                            row.serialList = w.serialList.ToList();
                            row.valid = w.valid;
                            refrishBillDetails();
                        }
                    }
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
        private void Cb_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                #region
                //com
                SectionData.clearComboBoxValidate(cb_user, p_errorUser);
                if (companyModel.deliveryType == "local" && cb_user.SelectedIndex == -1)
                {
                    //valid = false;
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trSelectTheDeliveryMan"), animation: ToasterAnimation.FadeIn);
                    SectionData.validateEmptyComboBox(cb_user, p_errorUser, tt_errorUser, "trSelectTheDeliveryMan");

                    //return valid;
                }
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

        private async void Cb_coupon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                string s = _BarcodeStr;
                if (cb_coupon.SelectedIndex != -1)
                {
                    couponModel = coupons.ToList().Find(c => c.cId == (int)cb_coupon.SelectedValue);
                    if (couponModel != null)
                    {
                        s = couponModel.barcode;
                        await dealWithBarcode(s);
                    }
                    cb_coupon.SelectedIndex = -1;
                    cb_coupon.SelectedItem = "";
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

        private void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_typeDiscount.SelectedIndex != -1)
                {
                    _SelectedDiscountType = (int)cb_typeDiscount.SelectedValue;
                    refreshTotalValue();
                }
                else
                {
                    cb_typeDiscount.SelectedValue = _SelectedDiscountType;
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
            index++;
            invoice = invoices[index];
            _invoiceId = invoice.invoiceId;
            navigateBtnActivate();
            await fillInvoiceInputs(invoice);
        }

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

        private async void Btn_previous_Click(object sender, RoutedEventArgs e)
        {
            int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
            index--;
            invoice = invoices[index];
            _invoiceId = invoice.invoiceId;
            navigateBtnActivate();
            await fillInvoiceInputs(invoice);
        }

        private async void Btn_deleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (invoice.invoiceId != 0)
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                    {
                        string res = await invoice.deleteOrder(invoice.invoiceId);
                        if (res.Equals("1"))
                        {
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopDelete"), animation: ToasterAnimation.FadeIn);

                            await clearInvoice();
                            await refreshDraftNotification();
                        }
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
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

        private void Exp_payment_Expanded(object sender, RoutedEventArgs e)
        {

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

        private void Tb_EnglishDigit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only english and digits
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
        }
    }
}

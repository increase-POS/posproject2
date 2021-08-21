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
                SectionData.ExceptionMessage(ex,this);
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
        public Invoice invoice = new Invoice();
        Coupon couponModel = new Coupon();
        IEnumerable<Coupon> coupons;
        List<CouponInvoice> selectedCoupons = new List<CouponInvoice>();
        Branch branchModel = new Branch();
        IEnumerable<Branch> branches;
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
        static private decimal _Sum = 0;
        static private decimal _Tax = 0;
        static private decimal _Discount = 0;
        static private decimal _DeliveryCost = 0;
        static public string _InvoiceType = "sd"; // sale draft

        // for report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        #region bill
       
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

            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_tax.Text = MainWindow.resourcemanager.GetString("trTax");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal");
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSaleOrder");
            txt_barcode.Text = MainWindow.resourcemanager.GetString("trBarcode");
            txt_coupon.Text = MainWindow.resourcemanager.GetString("trCoupon");
            txt_customer.Text = MainWindow.resourcemanager.GetString("trCustomer");
            txt_delivery.Text = MainWindow.resourcemanager.GetString("trDelivery");


            txt_printInvoice.Text = MainWindow.resourcemanager.GetString("trPrint");
            txt_preview.Text = MainWindow.resourcemanager.GetString("trPreview");
            txt_invoiceImages.Text = MainWindow.resourcemanager.GetString("trImages");
            txt_items.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_drafts.Text = MainWindow.resourcemanager.GetString("trDrafts");
            txt_newDraft.Text = MainWindow.resourcemanager.GetString("trNewDraft");
            txt_emailMessage.Text = MainWindow.resourcemanager.GetString("trSendEmail");
            txt_payments.Text = MainWindow.resourcemanager.GetString("trReceived");
            txt_returnInvoice.Text = MainWindow.resourcemanager.GetString("trReturn");
            txt_quotations.Text = MainWindow.resourcemanager.GetString("trQuotations");
            txt_ordersWait.Text = MainWindow.resourcemanager.GetString("trOrders");
            txt_invoices.Text = MainWindow.resourcemanager.GetString("trInvoices");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_barcode, MainWindow.resourcemanager.GetString("trBarcodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_coupon, MainWindow.resourcemanager.GetString("trCoponHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trCustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_company, MainWindow.resourcemanager.GetString("trCompanyHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_user, MainWindow.resourcemanager.GetString("trUserHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentProcessTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_card, MainWindow.resourcemanager.GetString("trCardHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_processNum, MainWindow.resourcemanager.GetString("trProcessNumHint"));

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");



        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.KeyDown -= HandleKeyPress;
                if (billDetails.Count > 0 && _InvoiceType == "sd")
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
                        clearInvoice();
                }
                else
                    clearInvoice();
                timer.Stop();
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        public async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                 if (sender != null)
                    SectionData.StartAwait(grid_main);
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

                translate();
               
                catigoriesAndItemsView.ucReceiptInvoice = this;

                pos = await posModel.getPosById(MainWindow.posID.Value);
                configurProcessType();
                setNotifications();
                await RefrishItems();
                await RefrishCustomers();
                await fillBarcodeList();
                await fillCouponsList();
                await fillShippingCompanies();
                await fillUsers();
                setTimer();
                #region fill card combo
                cards = await cardModel.GetAll();
                cb_card.ItemsSource = cards;
                cb_card.DisplayMemberPath = "name";
                cb_card.SelectedValuePath = "cardId";
                cb_card.SelectedIndex = -1;
                #endregion
                #region Style Date
                SectionData.defaultDatePickerStyle(dp_desrvedDate);
                #endregion
                if (MainWindow.isInvTax == 1)
                    tb_taxValue.Text = MainWindow.tax.ToString();
                tb_barcode.Focus();
                #region datagridChange
                CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
                ((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
                #endregion

                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                   if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                if (sendert != null)
                    SectionData.StartAwait(grid_main);
                refreshOrdersWaitNotification();
                refreshQuotationNotification();
                if (invoice.invoiceId != 0)
                {
                    refreshDocCount(invoice.invoiceId);
                    if (_InvoiceType == "s" || _InvoiceType == "sb")
                        refreshPaymentsNotification(invoice.invoiceId);
                }
                if (sendert != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sendert != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sendert);
            }
        }
        #endregion
        #region notifications
        private void setNotifications()
        {
            refreshDraftNotification();
            refreshOrdersWaitNotification();
            refreshQuotationNotification();
        }
        private async void refreshDraftNotification()
        {
            string invoiceType = "sd ,sbd";
            int duration = 2;
            int draftCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);

            int previouseCount = 0;
            if(md_draft.Badge != null && md_draft.Badge.ToString() != "") previouseCount = int.Parse(md_draft.Badge.ToString());

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
        private async void refreshOrdersWaitNotification()
        {
            string invoiceType = "or";
            int ordersCount = await invoice.GetCountBranchInvoices(invoiceType,0, MainWindow.branchID.Value);

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
        private async void refreshQuotationNotification()
        {
            string invoiceType = "q";
            int ordersCount = await invoice.GetCountBranchInvoices(invoiceType, MainWindow.branchID.Value);

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
        private async void refreshDocCount(int invoiceId)
        {
            DocImage doc = new DocImage();
            int docCount = await doc.GetDocCount("Invoices", invoiceId);

            int previouseCount = 0;
            if (md_docImage.Badge != null && md_docImage.Badge != "") previouseCount = int.Parse(md_docImage.Badge.ToString());

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
        private async void refreshPaymentsNotification(int invoiceId)
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
            coupons = await couponModel.GetCouponsAsync();
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
                SectionData.ExceptionMessage(ex,this,sender);
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    await addItemToBill(itemId, defaultsaleUnit.itemUnitId, defaultsaleUnit.mainUnit, (decimal)defaultsaleUnit.price, false);
                     
                }
                else
                {
                    bool valid = true;
                    if (item.type == "sn")
                        valid = false;
                    await addRowToBill(item.name, itemId, null, 0, 1, 0, 0, (decimal)item.taxes, item.type, valid);
                    refreshTotalValue();
                    refrishBillDetails();
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
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }
        private async Task<bool> validateInvoiceValues()
        {
            bool valid;
            bool available = true;
            SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

            if (cb_paymentProcessType.SelectedIndex != -1)
            {
                switch (cb_paymentProcessType.SelectedIndex)
                {
                    case 0:
                        SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        break;
                    case 1:
                        SectionData.validateEmptyComboBox(cb_customer, p_errorCustomer, tt_errorCustomer, "trEmptyCustomerToolTip");
                        break;
                    case 2:
                        SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        SectionData.validateEmptyTextBox(tb_processNum, p_errorProcessNum, tt_errorProcessNum, "trEmptyProcessNumToolTip");
                        SectionData.validateEmptyComboBox(cb_card, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
                        break;
                }
            }

            if (_InvoiceType == "sd" || _InvoiceType == "or")
                available = await checkItemsAmounts();
            foreach (BillDetails item in billDetails)
            {
                if (item.valid == false)
                {
                    valid = false;
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorNoSerialToolTip"), animation: ToasterAnimation.FadeIn);

                    return valid;
                }
            }
            #region
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
            || (cb_paymentProcessType.SelectedIndex == 2 && !tb_processNum.Text.Equals("") && cb_card.SelectedIndex != -1)))
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
                    Agent customer = customers.ToList().Find(b => b.agentId == agentId);
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
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCustomer, tt_errorCustomer, "trEmptyCustomerToolTip");
                    if ((sender as ComboBox).Name == "cb_paymentProcessType")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                    if ((sender as ComboBox).Name == "cb_card")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
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
                await saveOrderStatus(invoice.invoiceId, "ex");
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
            if (invoice.invType == "s" && (invType == "sb" || invType == "sbd")) // invoice is sale and will be bounce sale  or sale bounce draft  , save another invoice in db
            {
                invoice.invoiceMainId = invoice.invoiceId;
                invoice.invoiceId = 0;
                invoice.invNumber = await invoice.generateInvNumber("sb");
            }
            if (invoice.branchCreatorId == 0 || invoice.branchCreatorId == null)
            {
                invoice.branchCreatorId = MainWindow.branchID.Value;
                invoice.posId = MainWindow.posID.Value;
            }
            if (invoice.invType != "s" || invoice.invoiceId == 0)
            {
                invoice.posId = MainWindow.posID;
                if (!tb_discount.Text.Equals(""))
                    invoice.discountValue = decimal.Parse(tb_discount.Text);
                invoice.discountType = "1";

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

                // build invoice NUM 
                if (invoice.invNumber == null || invoice.invType == "or" || invoice.invType == "q")
                {
                    invoice.invNumber = await invoice.generateInvNumber("si");
                }

                invoice.invType = invType;

                // save invoice in DB
                int invoiceId = int.Parse(await invoiceModel.saveInvoice(invoice));
                invoice.invoiceId = invoiceId;

                if (invoiceId != 0)
                {
                    // add invoice details
                    invoiceItems = new List<ItemTransfer>();
                    ItemTransfer itemT;
                    for (int i = 0; i < billDetails.Count; i++)
                    {
                        itemT = new ItemTransfer();

                        itemT.invoiceId = invoiceId;
                        itemT.quantity = billDetails[i].Count;
                        itemT.price = billDetails[i].Price;
                        itemT.itemUnitId = billDetails[i].itemUnitId;
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
                        await itemLocationModel.decreaseAmounts(invoiceItems, MainWindow.branchID.Value, MainWindow.userID.Value); // update item quantity in DB
                        await invoice.recordPosCashTransfer(invoice,"si");                                                                                                         //if (paid > 0)
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
                                    cashTrasnfer.cardId = Convert.ToInt32(cb_card.SelectedValue);
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
                        await itemLocationModel.recieptInvoice(invoiceItems, MainWindow.branchID.Value, MainWindow.userID.Value); // update item quantity in DB
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
                                    cashTrasnfer.cardId = Convert.ToInt32(cb_card.SelectedValue);
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
                else
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                // }
            }

        }

        bool logInProcessing = true;
        void awaitSaveBtn(bool isAwait)
        {
            if (isAwait == true)
            {
                btn_save.IsEnabled = false;
                wait_saveBtn.Visibility = Visibility.Visible;
                wait_saveBtn.IsIndeterminate = true;
            }
            else
            {
                btn_save.IsEnabled = true;
                wait_saveBtn.Visibility = Visibility.Collapsed;
                wait_saveBtn.IsIndeterminate = false;
            }


        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            if (sender != null)
                    SectionData.StartAwait(grid_main);
                if ((
(MainWindow.groupObject.HasPermissionAction(invoicePermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
&&
(invoice.invType == "sd" || invoice.invType == "s"))
|| (invoice.invType != "sd" && invoice.invType != "s"))
                {
                    if (logInProcessing)
                    {
                        logInProcessing = false;
                        awaitSaveBtn(true);
                        //check mandatory inputs
                        bool valid = await validateInvoiceValues();

                        if (valid)
                        {

                            if (_InvoiceType == "sbd") //sbd means sale bounse draft
                                await addInvoice("sb"); // sb means sale bounce
                            else if (_InvoiceType == "or")
                            {
                                await saveOrder("s");
                                refreshOrdersWaitNotification();
                            }
                            else//s  sale invoice
                            {
                                await saveSaleInvoice("s");
                                refreshDraftNotification();
                            }
                            clearInvoice();
                        }
                        awaitSaveBtn(false);
                        logInProcessing = true;
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                Boolean available = true;
                if (_InvoiceType == "sd")
                    available = await checkItemsAmounts();
                bool valid = validateItemUnits();
                if (billDetails.Count > 0 && available && valid)
                {
                    await addInvoice(_InvoiceType);
                    refreshDraftNotification();
                    clearInvoice();
                }
                else if (billDetails.Count == 0)
                {
                    _InvoiceType = "sd";
                    clearInvoice();
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void clearInvoice()
        {
            _Sum = 0;
            _Tax = 0;
            _Discount = 0;
            _DeliveryCost = 0;
            _SequenceNum = 0;
            txt_invNumber.Text = "";
            _SelectedCustomer = -1;
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
            txt_discount.Text = "0";
            billDetails.Clear();
            tb_total.Text = "0";
            tb_sum.Text = "0";
            if (MainWindow.isInvTax == 1)
                tb_taxValue.Text = MainWindow.tax.ToString();
            else
                tb_taxValue.Text = "0";
            cb_card.SelectedIndex = -1;
            cb_company.SelectedIndex = -1;
            cb_user.SelectedIndex = -1;
            tb_processNum.Clear();
            cb_paymentProcessType.SelectedIndex = 0;
            cb_paymentProcessType.IsEnabled = true;
            lst_coupons.Items.Clear();
            tb_discount.Text = "0";
            md_docImage.Badge = "";
            md_payments.Badge = "";
            //btn_updateCustomer.IsEnabled = false;
            gd_card.Visibility = Visibility.Collapsed;
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorCard);
            SectionData.clearComboBoxValidate(cb_user, p_errorUser);
            SectionData.clearValidate(tb_processNum, p_errorProcessNum);
            refrishBillDetails();
            tb_barcode.Focus();
            inputEditable();
            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
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

                w.invoiceType = "sd ,sbd"; //sales draft invoices , sales bounce drafts
                w.userId = MainWindow.userLogin.userId;
                w.duration = 2; // view drafts which updated during 2 last days 
                w.title = MainWindow.resourcemanager.GetString("trDrafts");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;
                        _InvoiceType = invoice.invType;
                        md_payments.Badge = "";

                        refreshDocCount(invoice.invoiceId);
                        await fillInvoiceInputs(invoice);

                        // set title to bill
                        if (_InvoiceType == "sd")
                        {
                            mainInvoiceItems = invoiceItems;
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesDraft");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                        }
                        if (_InvoiceType == "sbd")
                        {
                            mainInvoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceMainId.Value);
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        // orange #FFA926 red #D22A17
                        brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));


                    }
                }
                Window.GetWindow(this).Opacity = 1;
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private async Task getInvoiceCoupons(int invoiceId)
        {
            if (_InvoiceType != "sd")
                selectedCoupons = await invoiceModel.getOriginalCoupons(invoiceId);
            else
                selectedCoupons = await invoiceModel.GetInvoiceCoupons(invoiceId);
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
                Window.GetWindow(this).Opacity = 0.2;

                wd_invoice w = new wd_invoice();

                // sale invoices
                w.invoiceType = "s , sb";
                // w.branchCreatorId = MainWindow.branchID.Value;
                w.userId = MainWindow.userLogin.userId;
                w.duration = 1; // view drafts which updated during 1 last days 

                w.title = MainWindow.resourcemanager.GetString("trSalesInvoices");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;
                        this.DataContext = invoice;

                        _InvoiceType = invoice.invType;
                       
                        // set title to bill
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
                        // orange #FFA926 red #D22A17
                        brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        await fillInvoiceInputs(invoice);
                        mainInvoiceItems = invoiceItems;

                        refreshDocCount(invoice.invoiceId);
                        refreshPaymentsNotification(invoice.invoiceId);
                    }
                }
                Window.GetWindow(this).Opacity = 1;
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    Window.GetWindow(this).Opacity = 0.2;

                    wd_invoice w = new wd_invoice();

                    // sale invoices
                    w.invoiceType = "or";
                    w.branchId = MainWindow.branchID.Value;
                    w.title = MainWindow.resourcemanager.GetString("trOrders");

                    if (w.ShowDialog() == true)
                    {
                        if (w.invoice != null)
                        {
                            invoice = w.invoice;
                            this.DataContext = invoice;

                            _InvoiceType = invoice.invType;
                           
                            // set title to bill
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSaleOrder");
                            // orange #FFA926 red #D22A17
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                            await fillInvoiceInputs(invoice);
                            mainInvoiceItems = invoiceItems;
                            refreshDocCount(invoice.invoiceId);
                            md_payments.Badge = "";
                        }
                    }
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        public async Task fillInvoiceInputs(Invoice invoice)
        {
            configurProcessType();

            _Sum = (decimal)invoice.total;
            txt_invNumber.Text = invoice.invNumber.ToString();
            if (invoice.tax != null)
            {
                _Tax = (decimal)invoice.tax;
                tb_taxValue.Text = invoice.tax.ToString();
                tb_discount.Text = invoice.discountValue.ToString();
            }
            if (_InvoiceType == "sbd" || _InvoiceType == "sd")
            {
                _Tax = 0;
                tb_taxValue.Text = _Tax.ToString();
                tb_discount.Text = "0";
            }
            cb_customer.SelectedValue = invoice.agentId;
            dp_desrvedDate.Text = invoice.deservedDate.ToString();
            if (invoice.totalNet != null)
                tb_total.Text = Math.Round((double)invoice.totalNet, 2).ToString();

            cb_company.SelectedValue = invoice.shippingCompanyId;
            cb_user.SelectedValue = invoice.shipUserId;
            tb_note.Text = invoice.notes;
            tb_sum.Text = invoice.total.ToString();

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
                        cb_card.SelectedIndex = -1;
                        tb_processNum.Clear();
                        break;
                    case "card":
                        gd_card.Visibility = Visibility.Visible;
                        cb_card.SelectedValue = cashTrasnfer.cardId.Value;
                        tb_processNum.Text = cashTrasnfer.docNum;
                        break;
                }
            }
            else if (invoice.invType == "or")
            {
                cb_paymentProcessType.SelectedValue = "balance";
            }
            if (_InvoiceType != "sbd" && _InvoiceType != "sd")
                await getInvoiceCoupons(invoice.invoiceId);
            // build invoice details grid
            await buildInvoiceDetails(invoice.invoiceId);
            inputEditable();

        }
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
                    w.title = MainWindow.resourcemanager.GetString("trInvoices");
                    w.branchCreatorId = MainWindow.branchID.Value;
                    // sales invoices
                    w.invoiceType = "s"; // invoice type to view in grid
                    if (w.ShowDialog() == true)
                    {
                        if (w.invoice != null)
                        {
                            _InvoiceType = "sbd";
                            invoice = w.invoice;

                            this.DataContext = invoice;
                            await fillInvoiceInputs(invoice);
                            mainInvoiceItems = invoiceItems;
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesReturnInvoice");
                            // orange #FFA926 red #D22A17
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                            md_payments.Badge = "";
                            refreshDocCount(invoice.invoiceId);

                        }
                    }
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    tb_discount.IsEnabled = false;
                    btn_save.IsEnabled = true;
                    cb_paymentProcessType.IsEnabled = true;
                    cb_card.IsEnabled = false;
                    cb_company.IsEnabled = false;
                    cb_user.IsEnabled = false;
                    tb_processNum.IsEnabled = false;
                    tb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
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
                    tb_discount.IsEnabled = true;
                    btn_save.IsEnabled = true;
                    cb_card.IsEnabled = true;
                    cb_company.IsEnabled = true;
                    cb_user.IsEnabled = true;
                    tb_processNum.IsEnabled = true;
                    tb_coupon.IsEnabled = true;
                    btn_clearCoupon.IsEnabled = true;
                    if (cb_company.SelectedIndex != -1)
                    {
                        cb_paymentProcessType.IsEnabled = false;
                        cb_paymentProcessType.SelectedIndex = 1;
                    }
                    else
                    {
                        cb_paymentProcessType.IsEnabled = true;
                    }
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
                    tb_discount.IsEnabled = true;
                    btn_save.IsEnabled = true;
                    cb_card.IsEnabled = true;
                    cb_company.IsEnabled = true;
                    cb_user.IsEnabled = true;
                    tb_processNum.IsEnabled = true;
                    tb_coupon.IsEnabled = true;
                    btn_clearCoupon.IsEnabled = true;
                    if (cb_company.SelectedIndex != -1)
                    {
                        cb_paymentProcessType.IsEnabled = false;
                        cb_paymentProcessType.SelectedIndex = 1;
                    }
                    else
                    {
                        cb_paymentProcessType.IsEnabled = true;
                    }

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
                    tb_discount.IsEnabled = false;
                    btn_save.IsEnabled = false;
                    cb_paymentProcessType.IsEnabled = false;
                    cb_card.IsEnabled = false;
                    cb_company.IsEnabled = false;
                    cb_user.IsEnabled = false;
                    tb_processNum.IsEnabled = false;
                    tb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
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
                    tb_discount.IsEnabled = false;
                    btn_save.IsEnabled = true;
                    cb_paymentProcessType.IsEnabled = false;
                    cb_card.IsEnabled = false;
                    cb_company.IsEnabled = false;
                    cb_user.IsEnabled = false;
                    tb_processNum.IsEnabled = false;
                    tb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
                    if (cb_company.SelectedIndex != -1)
                    {
                        cb_paymentProcessType.IsEnabled = false;
                        cb_paymentProcessType.SelectedIndex = 1;
                    }
                    else
                    {
                        cb_paymentProcessType.IsEnabled = true;
                    }
                    break;
            }
        }
        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
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
                    refreshDocCount(invoice.invoiceId);
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trChooseInvoiceToolTip"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                SectionData.ExceptionMessage(ex,this,sender);
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
                //if (cb_customer.SelectedIndex != -1)
                //    btn_updateCustomer.IsEnabled = true;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
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
                SectionData.ExceptionMessage(ex,this,sender);
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void refreshTotalValue()
        {
            #region calculate discount value
            _Discount = 0;
            foreach (CouponInvoice coupon in selectedCoupons)
            {
                string discountType = coupon.discountType.ToString();
                decimal discountValue = (decimal)coupon.discountValue;
                if (discountType == "2")
                    discountValue = SectionData.calcPercentage(_Sum, discountValue);
                _Discount += discountValue;
            }
            tb_discount.Text = _Discount.ToString();
            #endregion
            decimal taxValue = _Tax;
            decimal total = _Sum - _Discount + _DeliveryCost;
            if (MainWindow.isInvTax == 1)
            {
                taxValue = SectionData.calcPercentage(total, (decimal)MainWindow.tax);
            }
            else
                tb_taxValue.Text = _Tax.ToString();
            total += taxValue;
            tb_sum.Text = _Sum.ToString();
            tb_total.Text = Math.Round(total, 2).ToString();
        }
        #region billdetails

        void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            if (billDetails.Count == 1)
            {
                BillDetails bd = new BillDetails();
                billDetails.Add(bd);
                dg_billDetails.ItemsSource = billDetails;
                billDetails.Remove(bd);
            }
            else
                dg_billDetails.ItemsSource = billDetails;

            tb_sum.Text = _Sum.ToString();
            if (MainWindow.isInvTax == 0)
                tb_taxValue.Text = _Tax.ToString();
        }


        // read item from barcode
        private async void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
            if (sender != null)
                    SectionData.StartAwait(grid_main);
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
                            if (tb.Name == "tb_processNum" || tb.Name == "tb_note")// remove barcode from text box
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

                    e.Handled = true;
                }
                _Sender = null;
                _BarcodeStr = "";

                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        else if (_InvoiceType == "s")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        else if (_InvoiceType == "sbd")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesReturnDraft");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                        }
                        else if (_InvoiceType == "sb")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesReturnInvoice");
                            // orange #FFA926 red #D22A17
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                        }

                        await fillInvoiceInputs(invoice);
                    }
                    break;
                case "cop":// this barcode for coupon
                    {
                        await fillCouponsList();
                        couponModel = coupons.ToList().Find(c => c.barcode == barcode);
                        var exist = selectedCoupons.Find(c => c.couponId == couponModel.cId);
                        if (couponModel != null && exist == null)
                        {
                            if (couponModel.remainQ > 0 && couponModel.endDate >= DateTime.Now && couponModel.startDate <= DateTime.Now)
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

                        }
                        else
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponExist"), animation: ToasterAnimation.FadeIn);
                        }
                        tb_coupon.Clear();
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
                await addRowToBill(item.name, item.itemId, unitName, itemUnitId, count, price, total, tax, item.type, isValid);
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

            refreshTotalValue();
            refrishBillDetails();
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async Task addRowToBill(string itemName, int itemId, string unitName, int itemUnitId, int count, decimal price, decimal total, decimal tax, string type, bool valid, List<string> serialList = null)
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
                //serialList =  serialList.ToList(),
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
                    //var unit = itemUnits.ToList().Find(x => x.itemUnitId == (int)cmb.SelectedValue);
                    var unit = await itemUnitModel.GetById((int)cmb.SelectedValue);
                    int availableAmount = await itemLocationModel.getAmountInBranch(itemUnitId, MainWindow.branchID.Value);

                    int oldCount = 0;
                    long newCount = 0;
                    decimal oldPrice = 0;
                    decimal newPrice = (decimal)unit.price;

                    //"tb_amont"
                    tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[dg_billDetails.SelectedIndex]) as TextBlock;
                    tb.Text = availableAmount.ToString();

                    oldCount = billDetails[dg_billDetails.SelectedIndex].Count;
                    oldPrice = billDetails[dg_billDetails.SelectedIndex].Price;

                    if (availableAmount < oldCount)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableToolTip"), animation: ToasterAnimation.FadeIn);
                        newCount = availableAmount;
                        tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[dg_billDetails.SelectedIndex]) as TextBlock;
                        tb.Text = availableAmount.ToString();
                    }
                    else
                        newCount = oldCount;

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
                    tb = dg_billDetails.Columns[6].GetCellContent(dg_billDetails.Items[dg_billDetails.SelectedIndex]) as TextBlock;
                    tb.Text = total.ToString();

                    //  refresh sum and total text box
                    refreshTotalValue();

                    // update item in billdetails           
                    billDetails[dg_billDetails.SelectedIndex].Count = (int)newCount;
                    billDetails[dg_billDetails.SelectedIndex].Price = newPrice;
                    billDetails[dg_billDetails.SelectedIndex].Total = total;
                    refrishBillDetails();
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                SectionData.ExceptionMessage(ex,this,sender);
            }
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

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
                        int availableAmount = await itemLocationModel.getAmountInBranch(row.itemUnitId, MainWindow.branchID.Value);
                        if (availableAmount < newCount)
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableToolTip"), animation: ToasterAnimation.FadeIn);
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
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
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
                SectionData.ExceptionMessage(ex,this,sender);
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
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        public async Task<string> SaveSalepdf()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();
            string pdfpath = "";

            //
            if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
                                       || invoice.invType == "sbd" || invoice.invType == "pbd"
                                       || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
            {
                MessageBox.Show("can not print Draft Invoice");
            }
            else
            {
                //  ReportCls rr = new ReportCls();
                // MessageBox.Show(rr.GetLogoImagePath());



                if (invoice.invoiceId > 0)
                {
                    pdfpath = @"\Thumb\report\File.pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);

                    User employ = new User();
                    employ = await userModel.getUserById((int)invoice.updateUserId);
                    invoice.uuserName = employ.name;
                    invoice.uuserLast = employ.lastname;
                    //  agentinv = customers.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                    //  invoice.agentCode = agentinv.code;
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
                    string reppath = reportclass.GetreceiptInvoiceRdlcpath(invoice);
                    ReportCls.checkLang();
                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        invoice.branchName = branch.name;
                    }

                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillSaleInvReport(invoice, paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();

                    LocalReportExtensions.ExportToPDF(rep, pdfpath);

                }

            }
            return pdfpath;
        }
        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

            try
            {
            if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
                             || invoice.invType == "sbd" || invoice.invType == "pbd"
                             || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
                {
                    MessageBox.Show("can not print Draft Invoice");
                }
                else
                {
                    //  ReportCls rr = new ReportCls();
                    // MessageBox.Show(rr.GetLogoImagePath());

                    List<ReportParameter> paramarr = new List<ReportParameter>();


                    if (invoice.invoiceId > 0)
                    {
                        invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);

                        User employ = new User();
                        employ = await userModel.getUserById((int)invoice.updateUserId);
                        invoice.uuserName = employ.name;
                        invoice.uuserLast = employ.lastname;
                        //  agentinv = customers.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                        //  invoice.agentCode = agentinv.code;
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
                        string reppath = reportclass.GetreceiptInvoiceRdlcpath(invoice);
                        ReportCls.checkLang();
                        Branch branch = new Branch();
                        branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                        if (branch.branchId > 0)
                        {
                            invoice.branchName = branch.name;
                        }

                        clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                        clsReports.setReportLanguage(paramarr);
                        clsReports.Header(paramarr);
                        paramarr = reportclass.fillSaleInvReport(invoice, paramarr);

                        rep.SetParameters(paramarr);
                        rep.Refresh();

                        saveFileDialog.Filter = "PDF|*.pdf;";

                        if (saveFileDialog.ShowDialog() == true)
                        {

                            string filepath = saveFileDialog.FileName;
                            LocalReportExtensions.ExportToPDF(rep, filepath);
                        }
                    }

                }

                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
                    || invoice.invType == "sbd" || invoice.invType == "pbd"
                    || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
                {
                    MessageBox.Show("can not print Draft Invoice");
                }
                else
                {
                    //  ReportCls rr = new ReportCls();
                    // MessageBox.Show(rr.GetLogoImagePath());

                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string reppath = reportclass.GetreceiptInvoiceRdlcpath(invoice);
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
                        paramarr = reportclass.fillSaleInvReport(invoice, paramarr);

                        rep.SetParameters(paramarr);
                        rep.Refresh();

                        LocalReportExtensions.PrintToPrinter(rep);
                    }
                    else
                    {
                        MessageBox.Show("can not print Empty Invoice");
                    }
                }

                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (invoice.invoiceId > 0)
                {
                    Window.GetWindow(this).Opacity = 0.2;
                  
                    List<ReportParameter> paramarr = new List<ReportParameter>();
                    string pdfpath;

                    //
                    pdfpath = @"\Thumb\report\temp.pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                    string reppath = reportclass.GetreceiptInvoiceRdlcpath(invoice);
                    if (invoice.invoiceId > 0)
                    {


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

                        clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                        clsReports.setReportLanguage(paramarr);
                        clsReports.Header(paramarr);
                        paramarr = reportclass.fillSaleInvReport(invoice, paramarr);

                        rep.SetParameters(paramarr);
                        rep.Refresh();

                        LocalReportExtensions.ExportToPDF(rep, pdfpath);



                    }

                  

                    wd_previewPdf w = new wd_previewPdf();
                    w.pdfPath = pdfpath;
                    if (!string.IsNullOrEmpty(w.pdfPath))
                    {
                        w.ShowDialog();
                        //delete file
                        /*
                        if (File.Exists(pdfpath))
                        { File.Delete(pdfpath);}
                        */
                        //  ClosePDF();
                        w.wb_pdfWebViewer.Dispose();


                    }
                    else
                        Toaster.ShowError(Window.GetWindow(this), message: "", animation: ToasterAnimation.FadeIn);
                    Window.GetWindow(this).Opacity = 1;
                }       
                else
                {
                    //MessageBox.Show("save the invoice to preview");
                    MessageBox.Show(MainWindow.resourcemanager.GetString("trSaveInvoiceToPreview"));
                }

                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }


        private async void Btn_emailMessage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(sendEmailPermission, MainWindow.groupObjects, "one"))
                {
                    if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
                    || invoice.invType == "sbd" || invoice.invType == "pbd"
                    || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
                    {
                        MessageBox.Show("can not send Draft Invoice");
                    }
                    else
                    {
                        SysEmails email = new SysEmails();
                        EmailClass mailtosend = new EmailClass();
                        email = await email.GetByBranchIdandSide((int)MainWindow.branchID, "mg");
                        Agent toAgent = new Agent();
                        toAgent = customers.Where(x => x.agentId == invoice.agentId).FirstOrDefault();
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


                                            List<SetValues> setvlist = new List<SetValues>();
                                            if (invoice.invType == "s")
                                            {
                                                setvlist = await setvmodel.GetBySetName("sale_email_temp");
                                            }
                                            else if (invoice.invType == "or")
                                            {
                                                setvlist = await setvmodel.GetBySetName("sale_order_email_temp");
                                            }
                                            else if (invoice.invType == "q")
                                            {
                                                setvlist = await setvmodel.GetBySetName("quotation_email_temp");
                                            }
                                            else
                                            {
                                                setvlist = await setvmodel.GetBySetName("sale_email_temp");
                                            }
                                            mailtosend = mailtosend.fillSaleTempData(invoice, invoiceItems, email, toAgent, setvlist);
                                            string pdfpath = await SaveSalepdf();
                                            mailtosend.AddAttachTolist(pdfpath);
                                            string msg = "";
                                            msg = mailtosend.Sendmail();// temp comment
                                            if (msg == "Failure sending mail.")
                                            {
                                                // msg = "No Internet connection";
                                                //  MessageBox.Show("");
                                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoInternetConnection"), animation: ToasterAnimation.FadeIn);
                                            }
                                            else if (msg == "mailsent")
                                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailSent"), animation: ToasterAnimation.FadeIn);
                                            else
                                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailNotSent"), animation: ToasterAnimation.FadeIn);


                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

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
                        MainWindow.mainWindow.StartAwait();
                        int itemId = w.selectedItems[i];
                        await ChangeItemIdEvent(itemId);
                        MainWindow.mainWindow.EndAwait();
                    }
                }

                Window.GetWindow(this).Opacity = 1;
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_invoice w = new wd_invoice();

                    // sale invoices
                    w.invoiceType = "q";
                    w.branchCreatorId = MainWindow.branchID.Value;
                    w.title = MainWindow.resourcemanager.GetString("trQuotations");

                    if (w.ShowDialog() == true)
                    {
                        if (w.invoice != null)
                        {
                            invoice = w.invoice;
                            this.DataContext = invoice;

                            _InvoiceType = invoice.invType;
                            // set title to bill
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trQuotations");
                            // orange #FFA926 red #D22A17
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                            await fillInvoiceInputs(invoice);
                            mainInvoiceItems = invoiceItems;
                            md_payments.Badge = "";
                            refreshDocCount(invoice.invoiceId);

                        }
                    }
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                        cb_card.SelectedIndex = -1;
                        SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                        break;
                    case 1:// balance
                        gd_card.Visibility = Visibility.Collapsed;
                        tb_processNum.Clear();
                        cb_card.SelectedIndex = -1;
                        SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                        break;
                    case 2://card
                        gd_card.Visibility = Visibility.Visible;
                        SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        break;
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void PreventSpaces(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Cb_card_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_card.SelectedIndex != -1)
                {
                    _SelectedCard = (int)cb_card.SelectedValue;
                }
                else
                {
                    cb_card.SelectedValue = _SelectedCard;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private async void Tb_coupon_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
            if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (e.Key == Key.Return)
                {
                    string s = _BarcodeStr;
                    couponModel = coupons.ToList().Find(c => c.code == tb_coupon.Text || c.barcode == tb_coupon.Text);
                    if (couponModel != null)
                    {
                        s = couponModel.barcode;
                        await dealWithBarcode(s);
                    }
                    tb_coupon.Clear();
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                tb_coupon.Clear();
                refreshTotalValue();
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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

                        w.ShowDialog();

                        Window.GetWindow(this).Opacity = 1;
                    }
                    else
                        Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

    
    }
}

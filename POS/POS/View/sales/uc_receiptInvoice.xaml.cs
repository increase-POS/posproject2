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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_receiptInvoice.xaml
    /// </summary>
    public partial class uc_receiptInvoice : UserControl
    {
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
            InitializeComponent();          
        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;

        Card cardModel = new Card();
        IEnumerable<Card> cards;
        // IEnumerable<Item> itemsQuery;

        //Branch branchModel = new Branch();
        //Branch branch;

        Agent agentModel = new Agent();
        IEnumerable<Agent> customers;

        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;

        Invoice invoiceModel = new Invoice();
        Invoice invoice = new Invoice();

        Coupon couponModel = new Coupon();
        IEnumerable<Coupon> coupons;
        List<CouponInvoice> selectedCoupons = new List<CouponInvoice>();

        Pos posModel = new Pos();
        Pos pos;
        List<ItemTransfer> invoiceItems;
        List<ItemTransfer> mainInvoiceItems;

        ItemLocation itemLocationModel = new ItemLocation();

        ShippingCompanies companyModel = new ShippingCompanies();
        List<ShippingCompanies> companies;
        User userModel = new User();
        List<User> users;

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
        static private string _InvoiceType = "sd"; // sale draft

        // for report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
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

        private void translate()
        {
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");
            dg_billDetails.Columns[5].Header = MainWindow.resourcemanager.GetString("trPrice");
            dg_billDetails.Columns[6].Header = MainWindow.resourcemanager.GetString("trTotal");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_tax.Text = MainWindow.resourcemanager.GetString("trTax");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal:");
            //btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            //btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdfBtn");
            

            ////////////////////////////////----Customer----/////////////////////////////////

            txt_customer.Text = MainWindow.resourcemanager.GetString("trCustomer");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trCustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");



        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.KeyDown -= HandleKeyPress;
            if (billDetails.Count > 0)
            {
                #region Accept
                MainWindow.mainWindow.Opacity = 0.2;
            wd_acceptCancelPopup w = new wd_acceptCancelPopup();
            //w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
            w.contentText = "Do you want save sale invoice in drafts?";
            w.ShowDialog();
            MainWindow.mainWindow.Opacity = 1;
            #endregion
            if (w.isOk)
                Btn_newDraft_Click(null, null);
            else
                clearInvoice();
        }
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            MainWindow.mainWindow.KeyDown += HandleKeyPress;

            //var window = Window.GetWindow(this);
            //window.KeyDown -= HandleKeyPress;
            //window.KeyDown += HandleKeyPress;

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucReceiptInvoice.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucReceiptInvoice.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            catigoriesAndItemsView.ucReceiptInvoice = this;

            pos = await posModel.getPosById(MainWindow.posID.Value);

            configurProcessType();
            await RefrishItems();
            await RefrishCustomers();
            await fillBarcodeList();
            await fillCouponsList();
            await fillShippingCompanies();
            await fillUsers();

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

            if(MainWindow.isInvTax == 1)
                tb_taxValue.Text = MainWindow.tax.ToString();
            tb_barcode.Focus();
            #region datagridChange
            CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
            ((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
            #endregion
        }

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
            if ( _InvoiceType.Equals("sbd"))
            {
                var typelist = new[] {
                 new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
                new { Text = MainWindow.resourcemanager.GetString("trBalance") , Value = "balance" },
                };
                cb_paymentProcessType.ItemsSource = typelist;
            }
            else
            {
                var typelist = new[] {
                new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
                new { Text = MainWindow.resourcemanager.GetString("trBalance") , Value = "balance" },
                new { Text = MainWindow.resourcemanager.GetString("trCreditCard") , Value = "card" },
                 };

                cb_paymentProcessType.ItemsSource = typelist;
            }
        }
        private async Task fillShippingCompanies()
        {
            companies = await companyModel.Get();
            cb_company.ItemsSource = companies;
            cb_company.DisplayMemberPath = "name";
            cb_company.SelectedValuePath = "shippingCompanyId";

            //companyModel = companies.Find(c => c.shippingCompanyId == (int)cb_company.SelectedValue);
            //if (companyModel.deliveryType == "local")
            //{
            //    cb_user.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    cb_user.Visibility = Visibility.Collapsed;
            //}
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
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
        }
        #endregion

        private void Btn_updateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (cb_customer.SelectedIndex != -1)
            {
                Window.GetWindow(this).Opacity = 0.2;

                //if ((((this.Parent as Grid).Parent as Grid).Parent as UserControl) != null)
                //((((this.Parent as Grid).Parent as Grid).Parent as Grid).Parent as UserControl).Opacity = 0.2;
                wd_updateVendor w = new wd_updateVendor();
                //// pass agent id to update windows
                w.agent.agentId = (int)cb_customer.SelectedValue;
                //w.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00178DD2"));
                w.ShowDialog();


                Window.GetWindow(this).Opacity = 1;
            }
        }
        #region Get Id By Click  Y
        public async void ChangeItemIdEvent(int itemId)
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
                    // create new row in bill details data grid
                    addRowToBill(item.name, itemId, defaultsaleUnit.mainUnit, defaultsaleUnit.itemUnitId, 1, (decimal)defaultsaleUnit.price, (decimal)defaultsaleUnit.price, itemTax);

                    refreshTotalValue();
                    refrishBillDetails();
                }
            }
        }
        #endregion

        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region validation
        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;

            else
                e.Handled = true;
        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void validateInvoiceValues()
        {
            SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

            if (cb_paymentProcessType.SelectedIndex != -1)
            {
                switch (cb_paymentProcessType.SelectedIndex)
                {
                    case 0:
                        SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        break;
                    case 1:
                        SectionData.validateEmptyComboBox(cb_customer, p_errorCustomer, tt_errorCustomer,"trEmptyCustomerToolTip");
                        break;
                    case 2:
                        SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        SectionData.validateEmptyTextBox(tb_processNum, p_errorProcessNum, tt_errorProcessNum, "trEmptyProcessNumToolTip");
                        SectionData.validateEmptyComboBox(cb_card, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
                        break;
                }
            }
        }
        private async Task<Boolean> checkItemsAmounts()
        {
            Boolean available = true;
            for(int i=0; i< billDetails.Count; i++)
            {
                int availableAmount = await itemLocationModel.getAmountInBranch(billDetails[i].itemUnitId,MainWindow.branchID.Value);
                if(availableAmount < billDetails[i].Count)
                {
                    available = false;
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableFromToolTip") +" " + billDetails[i].Product, animation: ToasterAnimation.FadeIn);
                    return available;
                }
            }
            return available;
        }

        private void input_LostFocus(object sender, RoutedEventArgs e)
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
            //else
            //{
            //    if ((sender as DatePicker).Name == "dp_desrvedDate")
            //        SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorDesrvedDate, tt_errorDesrvedDate, "trErrorEmptyDeservedDate");
            //}
        }
        #endregion
        #region save invoice

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
                invoice.createUserId = MainWindow.userID;
                invoice.updateUserId = MainWindow.userID;

                // build invoice NUM like si-storCode-posCode-sequence exp: 123_PI_2
                if (invoice.invNumber == null || invoice.invType == "or")
                {
                    invoice.invNumber = await invoice.generateInvNumber("si");
                }
              
                decimal balance = 0;
                decimal paid = 0;
                decimal deserved = (decimal) invoice.totalNet ;
                if (invType == "s")
                {
                    switch (cb_paymentProcessType.SelectedIndex)
                    {
                        case 0://cash
                            paid = (decimal)invoice.totalNet;
                            deserved = 0;
                            balance = (decimal)invoice.totalNet;
                            break;
                        case 1:// balance
                               // calculate deserved and paid (compare customer balance with totalNet) 
                            Agent customer = customers.ToList().Find(b => b.agentId == invoice.agentId);
                            if (customer != null)
                                balance = (decimal)customer.balance;
                            if (balance >= invoice.totalNet)
                            {
                                paid = (decimal)invoice.totalNet;
                                deserved = 0;
                                balance = (decimal)(balance - invoice.totalNet);
                            }
                            else
                            {
                                paid = balance;
                                deserved = (decimal)(invoice.totalNet - balance);
                                balance = 0;
                            }
                            break;
                        case 2://card
                            paid = (decimal)invoice.totalNet;
                            deserved = 0;
                            break;
                    }
                }
                else if (invType == "sb")
                {                 
                    paid = (decimal)invoice.totalNet;
                    deserved = 0;
                    balance = (decimal)invoice.totalNet;
 
                    invoice.paid = paid;
                    invoice.deserved = deserved;    
                }
                invoice.invType = invType;
                // save invoice in DB
                int invoiceId = int.Parse(await invoiceModel.saveInvoice(invoice));

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
                        itemT.createUserId = MainWindow.userID;

                        invoiceItems.Add(itemT);
                    }
                    await invoiceModel.saveInvoiceItems(invoiceItems, invoiceId);
                    
                    // edit vendor balance , add cach transfer
                    if (invType == "s")
                    {
                       await itemLocationModel.decreaseAmounts(invoiceItems,MainWindow.branchID.Value); // update item quantity in DB
                        if (paid > 0)
                        {
                            switch (cb_paymentProcessType.SelectedIndex)
                            {

                                case 0:// cash: update pos balance

                                    pos.balance += balance;
                                    await pos.savePos(pos);
                                    break;
                                case 1:// balance: update customer balance

                                    await agentModel.updateBalance((int)invoice.agentId, balance);//update customer balance
                                    break;
                            }

                            // cach transfer model
                            CashTransfer cashTrasnfer = new CashTransfer();
                            cashTrasnfer.transType = "d"; //deposit
                            cashTrasnfer.posId = MainWindow.posID;
                            cashTrasnfer.agentId = invoice.agentId;
                            cashTrasnfer.invId = invoiceId;
                            cashTrasnfer.transNum = SectionData.generateNumber('d', "c").ToString();
                            cashTrasnfer.cash = paid;
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
                        }

                        //update items quantity
                    }
                    else if (invType == "sb")
                    {
                       await itemLocationModel.recieptInvoice(invoiceItems,MainWindow.branchID.Value,MainWindow.userID.Value); // update item quantity in DB
                        if (paid > 0)
                        {
                            switch (cb_paymentProcessType.SelectedIndex)
                            {
                                case 0:
                                case 2: // cash:card: update pos balance
                                    
                                    pos.balance -= balance;
                                    await pos.savePos(pos);
                                    break;
                                case 1:// balance: update customer balance
                                    Agent customer = customers.ToList().Find(b => b.agentId == invoice.agentId);
                                    if (customer != null)
                                        balance = (decimal)customer.balance + balance;
                                    await agentModel.updateBalance((int)invoice.agentId, balance);//update customer balance
                                    break;
                            }

                            // cach transfer model
                            CashTransfer cashTrasnfer = new CashTransfer();
                            cashTrasnfer.transType = "p"; //pull
                            cashTrasnfer.posId = MainWindow.posID;
                            cashTrasnfer.agentId = invoice.agentId;
                            cashTrasnfer.invId = invoiceId;
                            cashTrasnfer.transNum = SectionData.generateNumber('p', "c").ToString();
                            cashTrasnfer.cash = paid;
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
                    await invoiceModel.saveInvoiceCoupons(selectedCoupons, invoiceId,invoice.invType);
                    #endregion
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                }
                else
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
   
            }
            clearInvoice();
        }
        //private async Task<string> generateInvNumber(string invoiceCode)
        //{
        //    string storeCode = "";
        //    string posCode = "";
        //    if (pos != null)
        //    {
        //        storeCode = pos.branchCode;
        //        posCode = pos.code;
        //    }
        //    int sequence = await invoiceModel.GetLastNumOfInv(invoiceCode);
        //    sequence++;

        //    string invoiceNum = invoiceCode + "-" + storeCode + "-" + posCode + "-" + sequence.ToString();
        //    return invoiceNum;
        //}
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            //check mandatory inputs
            validateInvoiceValues();
            Boolean available = true;
            if(_InvoiceType == "sd")
                available =  await checkItemsAmounts();

            if ( billDetails.Count > 0 && available && ((cb_paymentProcessType.SelectedIndex == 1 && cb_customer.SelectedIndex != -1) 
                                            || (cb_paymentProcessType.SelectedIndex == 0)
                                            || (cb_paymentProcessType.SelectedIndex == 2 && !tb_processNum.Text.Equals("") && cb_card.SelectedIndex != -1)))
            {
                if (_InvoiceType == "sbd") //pbd means sale bounse draft
                    await addInvoice("sb"); // pb means sale bounce
                else//s  sale invoice
                    await addInvoice("s");

                if (invoice.invoiceId == 0) clearInvoice();
            }
        }
        private async void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {
            //check mandatory inputs
            //validateInvoiceValues();
            Boolean available = true;
            if (_InvoiceType == "sd")
                available = await checkItemsAmounts();
            if (billDetails.Count > 0 && available )
            {
                await addInvoice(_InvoiceType);
            }
            else if(billDetails.Count == 0)
            {
                _InvoiceType = "sd";
                clearInvoice();     
            }
        }
        private void clearInvoice()
        {
            _Sum = 0;
            _Tax = 0;
            _Discount = 0;
            _DeliveryCost = 0;
            _SequenceNum = 0;
            _SelectedCustomer = -1;
            _SelectedPaymentType = "cash";
            _SelectedCard = -1;
            _InvoiceType = "sd";
            invoice = new Invoice();
            selectedCoupons.Clear();
            tb_barcode.Clear();
            cb_customer.SelectedIndex = -1;
            cb_customer.SelectedItem = "";
           // cb_typeDiscount.SelectedIndex = 0;
            dp_desrvedDate.Text = "";
            tb_note.Clear();
            txt_discount.Text="";
            billDetails.Clear();
            tb_total.Text = "";
            tb_sum.Text = null;
            if (MainWindow.isInvTax == 1)
                tb_taxValue.Text = MainWindow.tax.ToString();
            else
                tb_taxValue.Text = "0";
            cb_card.SelectedIndex = -1;
            cb_company.SelectedIndex = -1;
            cb_user.SelectedIndex = -1;
            tb_processNum.Clear();
            cb_paymentProcessType.SelectedIndex = 0;
            lst_coupons.Items.Clear();
            tb_discount.Text = "0";
            btn_updateCustomer.IsEnabled = false;
            gd_card.Visibility = Visibility.Collapsed;
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
            SectionData.clearComboBoxValidate(cb_paymentProcessType,p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card,p_errorCard);
            SectionData.clearValidate(tb_processNum,p_errorProcessNum);
            refrishBillDetails();
            tb_barcode.Focus();
            inputEditable();
            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
        }
        #endregion
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            w.invoiceType = "sd ,sbd"; //sales draft invoices , sales bounce drafts
            w.userId = MainWindow.userLogin.userId;

            w.title = MainWindow.resourcemanager.GetString("trDrafts");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    _InvoiceType = invoice.invType;

                    await fillInvoiceInputs(invoice);
                    // set title to bill
                    if (_InvoiceType == "sd")
                    {
                        mainInvoiceItems = invoiceItems;
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");
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
            Window.GetWindow(this).Opacity = 0.2;
            
            wd_invoice w = new wd_invoice();

            // sale invoices
            w.invoiceType = "s";
            w.branchCreatorId = MainWindow.branchID.Value;
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
                }
            }
            Window.GetWindow(this).Opacity = 1;
        }
        private async Task fillInvoiceInputs(Invoice invoice)
        {
            configurProcessType();

            _Sum = (decimal)invoice.total;
            if (invoice.tax != null)
            {
                _Tax = (decimal)invoice.tax;
                tb_taxValue.Text = invoice.tax.ToString();
                tb_discount.Text = invoice.discountValue.ToString();
            }
            if (_InvoiceType == "sbd" || _InvoiceType == "sd")
            {
                _Tax = 0;
                tb_taxValue.Text = _Tax.ToString() ;
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
            else if(invoice.invType == "or")
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
            Window.GetWindow(this).Opacity = 0.2;
            wd_invoice w = new wd_invoice();
            w.title = MainWindow.resourcemanager.GetString("trPurchaseInvoices");
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
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                    // orange #FFA926 red #D22A17
                    brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                }
            }
            Window.GetWindow(this).Opacity = 1;
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

            tb_barcode.Focus();

            refrishBillDetails();
        }
        private void inputEditable()
        {
            switch (_InvoiceType) {
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
                    btn_updateCustomer.IsEnabled = false;
                    cb_paymentProcessType.IsEnabled = true;
                    cb_card.IsEnabled = false;
                    cb_company.IsEnabled = false;
                    cb_user.IsEnabled = false;
                    tb_processNum.IsEnabled = false;
                    tb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
                    break;
                case "sd": // sales draft invoice
                case "or": //sales order
                    dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                    dg_billDetails.Columns[3].IsReadOnly = false;
                    dg_billDetails.Columns[4].IsReadOnly = false;
                    dg_billDetails.Columns[5].IsReadOnly = false; //make price writable
                    cb_customer.IsEnabled = true;
                    dp_desrvedDate.IsEnabled = true;
                    tb_note.IsEnabled = true;
                    tb_barcode.IsEnabled = true;
                    tb_discount.IsEnabled = true;
                    btn_save.IsEnabled = true;
                    btn_updateCustomer.IsEnabled = true;
                    cb_paymentProcessType.IsEnabled = true;
                    cb_card.IsEnabled = true;
                    cb_company.IsEnabled = true;
                    cb_user.IsEnabled = true;
                    tb_processNum.IsEnabled = true;
                    tb_coupon.IsEnabled = true;
                    btn_clearCoupon.IsEnabled = true;
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
                    btn_updateCustomer.IsEnabled = false;
                    cb_paymentProcessType.IsEnabled = false;
                    cb_card.IsEnabled = false;
                    cb_company.IsEnabled = false;
                    cb_user.IsEnabled = false;
                    tb_processNum.IsEnabled = false;
                    tb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
                    break;
        }
        }
        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
            if (invoice != null && invoice.invoiceId != 0)
            {
                Window.GetWindow(this).Opacity = 0.2;

                wd_uploadImage w = new wd_uploadImage();

                w.tableName = "invoices";
                w.tableId = invoice.invoiceId;
                w.docNum = invoice.invNumber;
                w.ShowDialog();
                Window.GetWindow(this).Opacity =1;
            }
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trChooseInvoiceToolTip"), animation: ToasterAnimation.FadeIn);
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void Btn_pay_Click(object sender, RoutedEventArgs e)
        {
            //  btn_vendor_Click(null, null);
        }

        private void Cb_customer_KeyUp(object sender, KeyEventArgs e)
        {
            //ComboBox cbm = sender as ComboBox;
            //SectionData.searchInComboBox(cbm);
            cb_customer.ItemsSource = customers.Where(x => x.name.Contains(cb_customer.Text));
        }


        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            if (cb_customer.SelectedIndex != -1)
                btn_updateCustomer.IsEnabled = true;
        }
        private void Tb_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Sender = sender;
        }
        private void tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Sender = sender;
            refreshTotalValue();
            e.Handled = true;
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
            if (MainWindow.isInvTax == 1)
            {
                taxValue = SectionData.calcPercentage(_Sum, (decimal)MainWindow.tax);
            }
            else
                tb_taxValue.Text = _Tax.ToString();
            decimal total = _Sum - _Discount + taxValue + _DeliveryCost;

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
            else if (e.Key >= Key.A && e.Key <= Key.Z )
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
                        if (tb.Name == "tb_processNum" || tb.Name == "tb_note" )// remove barcode from text box
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
                

                //string prefix = _BarcodeStr.Substring(0, _BarcodeStr.IndexOf("-"));
                //switch (prefix)
                //{
                //    case "si":// this barcode for invoice
                //    case "pi":
                //        break;
                //    case "cop":// this barcode for coupon
                //        break;
                //    case "cus":// this barcode for customer
                //        break;
                //    default: // if barcode for item
                //        tb_barcode.Text = _BarcodeStr;
                //        // get item matches barcode
                //        if (barcodesList != null)
                //        {
                //            ItemUnit unit1 = barcodesList.ToList().Find(c => c.barcode == tb_barcode.Text.Trim());

                //            // get item matches the barcode
                //            if (unit1 != null)
                //            {
                //                int itemId = (int)unit1.itemId;
                //                if (unit1.itemId != 0)
                //                {
                //                    int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId).FirstOrDefault());

                //                    if (index == -1)//item doesn't exist in bill
                //                    {
                //                        // get item units
                //                        itemUnits = await itemUnitModel.GetItemUnits(itemId);
                //                        //get item from list
                //                        item = items.ToList().Find(i => i.itemId == itemId);

                //                        int count = 1;
                //                        decimal price = 0;
                //                        if (unit1.price != null)
                //                            price = (decimal)unit1.price;
                //                        decimal total = count * price;
                //                        decimal tax = (decimal)(count * item.taxes);
                //                        addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count, price, total, tax);
                //                    }
                //                    else // item exist prevoiusly in list
                //                    {
                //                        decimal itemTax = 0;
                //                        if (item.taxes != null)
                //                            itemTax = (decimal)item.taxes;
                //                        billDetails[index].Count++;
                //                        billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;
                //                        billDetails[index].Tax = (decimal)(billDetails[index].Count * itemTax);

                //                        _Sum += billDetails[index].Price;
                //                        _Tax += billDetails[index].Tax;

                //                    }
                //                    refreshTotalValue();
                //                    refrishBillDetails();
                //                }
                //            }
                //            else
                //            {
                //                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorItemNotFoundToolTip"), animation: ToasterAnimation.FadeIn);
                //            }
                //        }
                //        break;
                //}

                e.Handled = true;
            }
            _Sender = null;
            _BarcodeStr = "";

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
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        else if (_InvoiceType == "s")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        else if (_InvoiceType == "sbd")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                        }
                        else if (_InvoiceType == "sb")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
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
                        var exist = selectedCoupons.Find(c=> c.couponId == couponModel.cId);
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
                            else if(couponModel.endDate < DateTime.Now)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponExpire"), animation: ToasterAnimation.FadeIn);
                            else if(couponModel.startDate > DateTime.Now)
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
                                int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId).FirstOrDefault());

                                if (index == -1)//item doesn't exist in bill
                                {
                                    // get item units
                                    itemUnits = await itemUnitModel.GetItemUnits(itemId);
                                    //get item from list
                                    item = items.ToList().Find(i => i.itemId == itemId);

                                    int count = 1;
                                    decimal price = 0;
                                    if (unit1.price != null)
                                        price = (decimal)unit1.price;
                                    decimal total = count * price;
                                    decimal tax = (decimal)(count * item.taxes);
                                    addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count, price, total, tax);
                                }
                                else // item exist prevoiusly in list
                                {
                                    decimal itemTax = 0;
                                    if (item.taxes != null)
                                        itemTax = (decimal)item.taxes;
                                    billDetails[index].Count++;
                                    billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;
                                    billDetails[index].Tax = (decimal)(billDetails[index].Count * itemTax);

                                    _Sum += billDetails[index].Price;
                                    _Tax += billDetails[index].Tax;

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

                //if (barcodesList != null && _BarcodeStr.Length <= 13) //_BarcodeStr == "" barcode not from barcode reader
                //{
                //    ItemUnit unit1 = barcodesList.ToList().Find(c => c.barcode == tb_barcode.Text);

                //    // get item matches the barcode
                //    if (unit1 != null)
                //    {
                //        int itemId = (int)unit1.itemId;
                //        if (unit1.itemId != 0)
                //        {
                //            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId).FirstOrDefault());
                //            //item doesn't exist in bill
                //            if (index == -1)
                //            {
                //                // get item units
                //                itemUnits = await itemUnitModel.GetItemUnits(itemId);
                //                //get item from list
                //                item = items.ToList().Find(i => i.itemId == itemId);

                //                int count = 1;
                //                decimal price = 0; //?????
                //                decimal total = count * price;
                //                decimal tax = (decimal)(count * item.taxes);
                //                addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count, price, total, tax);
                //            }
                //            else // item exist prevoiusly in list
                //            {
                //                billDetails[index].Count++;
                //                billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;

                //                _Sum += billDetails[index].Price;
                //                decimal itemTax = 0;
                //                if (item.taxes != null)
                //                    itemTax = (decimal)item.taxes;
                //                _Tax += (decimal)itemTax;
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
               // e.Handled = true;
            }
            
        }

        private void addRowToBill(string itemName, int itemId, string unitName, int itemUnitId, int count, decimal price, decimal total, decimal tax)
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
            });
            _Sum += total;
            _Tax += tax;
        }
        #endregion billdetails
        private async void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;
            TextBlock tb;
            if (dg_billDetails.SelectedIndex != -1)
            {
                int itemUnitId = (int)cmb.SelectedValue;
            billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
                var unit = itemUnits.ToList().Find(x=> x.itemUnitId == (int)cmb.SelectedValue);
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
                //if (_InvoiceType == "sbd")
                //{
                //    ItemTransfer item = invoiceItems.ToList().Find(i => i.itemUnitId == row.itemUnitId);
                //    if (newCount > item.quantity)
                //    {
                //        // return old value 
                //        t.Text = item.quantity.ToString();

                //        newCount = (long)item.quantity;
                //        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
                //    }
                //}

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
        }
        private void Cbm_unitItemDetails_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //billDetails
            if (billDetails.Count == 1)
            {
                var cmb = sender as ComboBox;
                cmb.SelectedValue = (int)billDetails[0].itemUnitId;
            }
           
            //MessageBox.Show("Hello");
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

        private async void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBlock tb;
            TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
            var columnName = e.Column.Header.ToString();

            BillDetails row = e.Row.Item as BillDetails;
            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == row.itemUnitId).FirstOrDefault());

            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds < 100)
            {
                if (columnName == MainWindow.resourcemanager.GetString("trAmount"))
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
                if (columnName == MainWindow.resourcemanager.GetString("trAmount"))
                    newCount = int.Parse(t.Text);
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
        }

        private void Dp_date_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            _Sender = sender;
            moveControlToBarcode(sender, e);
        }
        private void moveControlToBarcode(object sender, KeyEventArgs e)
        {
            DatePicker dt = sender as DatePicker;
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds < 100)
            {
                tb_barcode.Focus();
                HandleKeyPress(sender, e);
            }
        }
        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
                string addpath = @"\Reports\Sale\En\InvPurReport.rdlc";
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                if (invoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                    rep.ReportPath = reppath;
                    rep.DataSources.Clear();
                    rep.DataSources.Add(new ReportDataSource("DataSetItemTransfer", invoiceItems));
                    rep.EnableExternalImages = true;


                    // rep.DataSources.Add(new ReportDataSource("DataSetItemTransfer", data));
                    ReportParameter[] paramarr = new ReportParameter[14];

                    paramarr[0] = new ReportParameter("Title", "Purshase Invoice");
                    paramarr[1] = new ReportParameter("lang", MainWindow.lang);
                    paramarr[2] = new ReportParameter("invNumber", invoice.invNumber);
                    paramarr[3] = new ReportParameter("invoiceId", invoice.invoiceId.ToString());
                    paramarr[4] = new ReportParameter("invDate", reportclass.DateToString(invoice.invDate));
                    paramarr[5] = new ReportParameter("invTime", reportclass.TimeToString(invoice.invTime));
                    //paramarr[6] = new ReportParameter("vendorInvNum", invoice.vendorInvNum.ToString());
                    paramarr[6] = new ReportParameter("total", reportclass.DecTostring(invoice.total));
                    paramarr[7] = new ReportParameter("discountValue", reportclass.DecTostring(invoice.discountValue));
                    paramarr[8] = new ReportParameter("totalNet", reportclass.DecTostring(invoice.totalNet));
                    paramarr[9] = new ReportParameter("paid", reportclass.DecTostring(invoice.paid));
                    paramarr[10] = new ReportParameter("deserved", reportclass.DecTostring(invoice.deserved));
                    paramarr[11] = new ReportParameter("deservedDate", invoice.deservedDate.ToString());
                    paramarr[12] = new ReportParameter("tax", "0");
                    paramarr[13] = new ReportParameter("barcodeimage", "file:\\" + reportclass.BarcodeToImage(invoice.invNumber.ToString(), "invnum"));
                    //paramarr[14] = new ReportParameter("companyName", "Increase");
                    //paramarr[15] = new ReportParameter("storeName", "Bonni");
                    //paramarr[16] = new ReportParameter("cashName", "Mohammad Bonni");
                    //paramarr[17] = new ReportParameter("Notes", "Hello");
                    //paramarr[18] = new ReportParameter("Address", "Aleppo");
                    //  MessageBox.Show(reportclass.DecTostring(invoice.paid) + "des="+ invoice.deserved.ToString());

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

        private void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            //items

            Window.GetWindow(this).Opacity = 0.2;
            wd_items w = new wd_items();
            w.CardType = "sales";
            w.ShowDialog();
            if (w.isActive)
            {
                ////// w.selectedItem this is ItemId
                ChangeItemIdEvent(w.selectedItem);
            }

            Window.GetWindow(this).Opacity = 1;
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            clearInvoice();
        }

        private async void Btn_quotations_Click(object sender, RoutedEventArgs e)
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
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
                    // orange #FFA926 red #D22A17
                    brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                    await fillInvoiceInputs(invoice);
                    mainInvoiceItems = invoiceItems;
                }
            }
            Window.GetWindow(this).Opacity = 1;
        }
        private async void Btn_orders_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            // sale orders
            w.invoiceType = "or";
            w.branchCreatorId = MainWindow.branchID.Value;
            w.title = MainWindow.resourcemanager.GetString("trSalesInvoices");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    this.DataContext = invoice;

                    _InvoiceType = invoice.invType;
                    // set title to bill
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trOrders");
                    // orange #FFA926 red #D22A17
                    brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                    await fillInvoiceInputs(invoice);
                    mainInvoiceItems = invoiceItems;
                }
            }
            Window.GetWindow(this).Opacity = 1;
        }
        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
        }
        private void PreventSpaces(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Btn_clearCustomer_Click(object sender, RoutedEventArgs e)
        {
            _SelectedCustomer = -1;
            cb_customer.SelectedIndex = -1;
            dp_desrvedDate.SelectedDate = null;
            tb_note.Clear();

            btn_updateCustomer.IsEnabled = false;
            SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
        }

        private void Cb_card_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private async void Tb_coupon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
               string s= _BarcodeStr;
                couponModel = coupons.ToList().Find(c => c.code == tb_coupon.Text || c.barcode == tb_coupon.Text);
                if(couponModel != null)
                {
                    s = couponModel.barcode;
                   await dealWithBarcode(s);
                    //CouponInvoice ci = new CouponInvoice();
                    //ci.couponId = couponModel.cId;
                    //ci.discountType = byte.Parse( couponModel.discountType);
                    //ci.discountValue = couponModel.discountValue;

                    //lst_coupons.Items.Add(couponModel.code);
                    //selectedCoupons.Add(ci);
                    //refreshTotalValue();
                }
                tb_coupon.Clear();
            }
        }

        private void Btn_clearCoupon_Click(object sender, RoutedEventArgs e)
        {
            _Discount = 0;
            selectedCoupons.Clear();
            lst_coupons.Items.Clear();
            tb_coupon.Clear();
            refreshTotalValue();
        }

        private void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {

        } 

        private void Cb_company_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_company.SelectedIndex != -1)
            {
                companyModel = companies.Find(c => c.shippingCompanyId == (int)cb_company.SelectedValue);
                _DeliveryCost = (decimal)companyModel.deliveryCost;
                refreshTotalValue();

                if (companyModel.deliveryType == "local")
                {
                    cb_user.Visibility = Visibility.Visible;
                }
                else
                {
                    cb_user.SelectedIndex = -1;
                    cb_user.Visibility = Visibility.Collapsed;
                }
            }
            else
                cb_user.Visibility = Visibility.Collapsed;
        }

        private void Cb_company_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}

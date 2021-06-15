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

        Branch branchModel = new Branch();
        IEnumerable<Branch> branches;

        Agent agentModel = new Agent();
        IEnumerable<Agent> customers;

        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;

        Invoice invoiceModel = new Invoice();
        Invoice invoice = new Invoice();

        Pos posModel = new Pos();
        List<ItemTransfer> invoiceItems;

        #region//to handle barcode characters
        static private int _SelectedCustomer = -1;
        static private int _SelectedDiscountType = -1;
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
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown -= HandleKeyPress;
            window.KeyDown += HandleKeyPress;

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

            await RefrishItems();
            configureDiscountType();
            await RefrishCustomers();
            await fillBarcodeList();

            #region fill payment type
            var typelist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
            new { Text = MainWindow.resourcemanager.GetString("trBalance") , Value = "balance" },
            new { Text = MainWindow.resourcemanager.GetString("trCreditCard") , Value = "card" },
             };
            cb_paymentProcessType.DisplayMemberPath = "Text";
            cb_paymentProcessType.SelectedValuePath = "Value";
            cb_paymentProcessType.ItemsSource = typelist;
            #endregion

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
            barcodesList = await itemUnitModel.getAllBarcodes();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
            refrishBillDetails();
        }
        #endregion

        private void Btn_updateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (cb_customer.SelectedIndex != -1)
            {
                // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;

                //if ((((this.Parent as Grid).Parent as Grid).Parent as UserControl) != null)
                //((((this.Parent as Grid).Parent as Grid).Parent as Grid).Parent as UserControl).Opacity = 0.2;
                wd_updateVendor w = new wd_updateVendor();
                //// pass agent id to update windows
                w.agent.agentId = (int)cb_customer.SelectedValue;
                //w.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00178DD2"));
                w.ShowDialog();


                // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
            }
        }
        #region Get Id By Click  Y
        public async void ChangeItemIdEvent(int itemId)
        {
            item = items.ToList().Find(c => c.itemId == itemId);

            if (item != null)
            {
                this.DataContext = item;

                // get item units
                itemUnits = await itemUnitModel.GetItemUnits(item.itemId);
                // search for default unit for purchase
                var defaultsaleUnit = itemUnits.ToList().Find(c => c.defaultSale == 1);
                if (defaultsaleUnit != null)
                {
                    // create new row in bill details data grid
                    addRowToBill(item.name, itemId, defaultsaleUnit.mainUnit, defaultsaleUnit.itemUnitId, 1, (decimal)defaultsaleUnit.price, (decimal)defaultsaleUnit.price);

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

        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            //if (name == "TextBox")
            //{
            //    if ((sender as TextBox).Name == "tb_invoiceNumber")
            //        SectionData.validateEmptyTextBox((TextBox)sender, p_errorInvoiceNumber, tt_errorInvoiceNumber, "trErrorEmptyInvNumToolTip");
            //}
            if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_customer")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCustomer, tt_errorCustomer, "trEmptyCustomerToolTip");
            //    if ((sender as ComboBox).Name == "cb_vendor")
            //        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip");
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
            }
            if (invoice.invType != "s" || invoice.invoiceId == 0)
            {
                invoice.invType = invType;
                if (!tb_discount.Text.Equals(""))
                    invoice.discountValue = decimal.Parse(tb_discount.Text);

                if (cb_typeDiscount.SelectedIndex != -1)
                    invoice.discountType = cb_typeDiscount.SelectedValue.ToString();

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

                invoice.createUserId = MainWindow.userID;
                invoice.updateUserId = MainWindow.userID;

                // build invoice NUM like storCode_PI_sequence exp: 123_PI_2
                if (invoice.invNumber == null)
                {
                    //Branch store = branches.ToList().Find(b => b.branchId == invoice.branchId);
                    string storeCode = "";
                    //if (store != null)
                        //storeCode = store.code;

                    string invoiceCode = "SI";
                    int sequence = await invoiceModel.GetLastNumOfInv("SI");
                    sequence++;

                    string invoiceNum = storeCode + "_" + invoiceCode + "_" + sequence.ToString();
                    invoice.invNumber = invoiceNum;
                }

                // calculate deserved and paid (compare vendor balance with totalNet)  
                Agent customer = customers.ToList().Find(b => b.agentId == invoice.agentId);
                decimal balance = 0;
                decimal paid = 0;
                decimal deserved = 0;
                if (invType == "s" )
                {
                    switch (cb_paymentProcessType.SelectedIndex)
                    {
                        case 0://cash
                            paid = (decimal)invoice.totalNet;
                            deserved = 0;
                            balance = (decimal)invoice.totalNet;
                            break;
                        case 1:// balance
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
                     
                    invoice.paid = paid;
                    invoice.deserved = deserved;
                }

                // save invoice in DB
                int invoiceId = int.Parse(await invoiceModel.saveInvoice(invoice));

                if (invoiceId != 0)
                {
                    // edit vendor balance , add cach transfer
                    if (invType == "s" && paid > 0)
                    {
                        switch (cb_paymentProcessType.SelectedIndex)
                        {
                            
                            case 0:// cash: update pos balance
                                Pos pos = await posModel.getPosById(MainWindow.posID.Value);
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
                        cashTrasnfer.transNum = SectionData.generateNumber('d', "v").ToString();
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

                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                }
                else
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);


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
            }
            clearInvoice();
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            //check mandatory inputs
            validateInvoiceValues();

            if ( billDetails.Count > 0 && ((cb_paymentProcessType.SelectedIndex == 1 && cb_customer.SelectedIndex != -1) 
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
            validateInvoiceValues();

            if (billDetails.Count > 0)
            {
                await addInvoice(_InvoiceType);

            }
            _InvoiceType = "sd";
            inputEditable();
            clearInvoice();
        }
        private void clearInvoice()
        {
            _Sum = 0;
            _SequenceNum = 0;
            _SelectedCustomer = -1;
            _InvoiceType = "sd";
            invoice = new Invoice();
            tb_barcode.Clear();
            //cb_branch.SelectedIndex = -1;
            cb_customer.SelectedIndex = -1;
            cb_customer.SelectedItem = "";
            cb_typeDiscount.SelectedIndex = 0;
            dp_desrvedDate.Text = "";
            tb_note.Clear();
            tb_discount.Clear();
            billDetails.Clear();
            tb_total.Text = "";
            tb_sum.Text = null;
            tb_taxValue.Text = MainWindow.tax.ToString();

            btn_updateCustomer.IsEnabled = false;
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseBill");
            refrishBillDetails();
        }
        #endregion
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            w.invoiceType = "sd ,sbd"; //sales draft invoices , sales bounce drafts


            w.title = MainWindow.resourcemanager.GetString("trDrafts");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    //this.DataContext = invoice;

                    _InvoiceType = invoice.invType;
                    // set title to bill
                    if (_InvoiceType == "sd")
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");
                    if (_InvoiceType == "sbd")
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");

                    fillInvoiceInputs(invoice);

                    //get invoice items
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);

                    // build invoice details grid
                    buildInvoiceDetails(invoiceItems);
                    inputEditable();
                }
            }
            //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
        }
        private async void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {
            // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            // sale invoices
            w.invoiceType = "s";

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

                    fillInvoiceInputs(invoice);

                    //get invoice items
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);

                    // build invoice details grid
                    buildInvoiceDetails(invoiceItems);
                    inputEditable();
                }
            }
            //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
        }
        private void fillInvoiceInputs(Invoice invoice)
        {
            _Sum = (decimal)invoice.total;

           // cb_paymentProcessType.SelectedValue = invoice.
            cb_customer.SelectedValue = invoice.agentId;
            dp_desrvedDate.Text = invoice.deservedDate.ToString();           
            tb_total.Text = Math.Round((double)invoice.totalNet, 2).ToString();
            tb_taxValue.Text = invoice.tax.ToString();
            tb_note.Text = invoice.notes;
            tb_sum.Text = invoice.total.ToString();
            tb_discount.Text = invoice.discountValue.ToString();

            if (invoice.discountType == "1")
                cb_typeDiscount.SelectedIndex = 1;
            else if (invoice.discountType == "2")
                cb_typeDiscount.SelectedIndex = 2;
            else
                cb_typeDiscount.SelectedIndex = 0;
        }
        private async void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {
            // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            wd_invoice w = new wd_invoice();


            w.title = MainWindow.resourcemanager.GetString("trPurchaseInvoices");

            // sales invoices
            w.invoiceType = "s"; // invoice type to view in grid
            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    _InvoiceType = "sbd";
                    invoice = w.invoice;

                    this.DataContext = invoice;

                    fillInvoiceInputs(invoice);

                    //get invoice items
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);

                    // build invoice details grid
                    buildInvoiceDetails(invoiceItems);

                    inputEditable();
                }
            }
            // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
        }
        private void buildInvoiceDetails(List<ItemTransfer> invoiceItems)
        {
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
            if (_InvoiceType == "sbd") // return sale bounce draft
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                dg_billDetails.Columns[5].IsReadOnly = true; //make price read only
                dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                cb_customer.IsEnabled = false;
                dp_desrvedDate.IsEnabled = false;
               // dp_invoiceDate.IsEnabled = false;
                tb_note.IsEnabled = false;
                tb_barcode.IsEnabled = false;
               // cb_branch.IsEnabled = false;
                tb_discount.IsEnabled = false;
                cb_typeDiscount.IsEnabled = false;
                btn_save.IsEnabled = true;
                btn_updateCustomer.IsEnabled = false;
            }
            else if (_InvoiceType == "sd")
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                dg_billDetails.Columns[5].IsReadOnly = false;
                dg_billDetails.Columns[3].IsReadOnly = false;
                dg_billDetails.Columns[4].IsReadOnly = false;
                cb_customer.IsEnabled = true;
                dp_desrvedDate.IsEnabled = true;
               // dp_invoiceDate.IsEnabled = true;
                tb_note.IsEnabled = true;
                tb_barcode.IsEnabled = true;
               // cb_branch.IsEnabled = true;
                tb_discount.IsEnabled = true;
                cb_typeDiscount.IsEnabled = true;
                btn_save.IsEnabled = true;
                btn_updateCustomer.IsEnabled = true;
            }
            else if (_InvoiceType == "s")
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                dg_billDetails.Columns[5].IsReadOnly = true; //make price read only
                dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                cb_customer.IsEnabled = false;
                dp_desrvedDate.IsEnabled = false;
               // dp_invoiceDate.IsEnabled = false;
                tb_note.IsEnabled = false;
                tb_barcode.IsEnabled = false;
               // cb_branch.IsEnabled = false;
                tb_discount.IsEnabled = false;
                cb_typeDiscount.IsEnabled = false;
                btn_save.IsEnabled = false;
                btn_updateCustomer.IsEnabled = false;
            }
        }
        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
            if (invoice != null && invoice.invoiceId != 0)
            {
                //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;

                wd_uploadImage w = new wd_uploadImage();

                w.tableName = "invoices";
                w.tableId = invoice.invoiceId;
                w.docNum = invoice.invNumber;
                w.ShowDialog();
                // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity =1;
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
            ComboBox cbm = sender as ComboBox;
            //SectionData.searchInComboBox(cbm);
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
        private void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        private void tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Sender = sender;
            refreshTotalValue();
            e.Handled = true;
        }
        private void refreshTotalValue()
        {
            decimal discountValue = 0;
            if (tb_discount.Text != "." && !tb_discount.Text.Equals(""))
                discountValue = decimal.Parse(tb_discount.Text);

            if (cb_typeDiscount.SelectedIndex != -1 && int.Parse(cb_typeDiscount.SelectedValue.ToString()) == 2) // discount type is rate
            {
                discountValue = SectionData.calcPercentage(_Sum, discountValue);
            }

            decimal total = _Sum - discountValue;
            decimal taxValue = 0;
            decimal taxInputVal = 0;
            if (!tb_taxValue.Text.Equals(""))
                taxInputVal = decimal.Parse(tb_taxValue.Text);
            if (total != 0)
                taxValue = SectionData.calcPercentage(total, taxInputVal);

            tb_sum.Text = _Sum.ToString();
            total = total - taxValue;
            tb_total.Text = Math.Round(total, 2).ToString();
        }
        #region billdetails

        void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;

            tb_sum.Text = _Sum.ToString();
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
            _BarcodeStr += digit;
            _lastKeystroke = DateTime.Now;
            // process barcode

            if (e.Key.ToString() == "Return" && _BarcodeStr != "")
            {
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
                        if (tb.Name == "tb_invoiceNumber" || tb.Name == "tb_note" || tb.Name == "tb_discount")// remove barcode from text box
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
                e.Handled = true;
            }
            _Sender = null;
        }
        private async void Tb_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (barcodesList != null && _BarcodeStr.Length < 13) //_BarcodeStr == "" barcode not from barcode reader
                {
                    ItemUnit unit1 = barcodesList.ToList().Find(c => c.barcode == tb_barcode.Text);

                    // get item matches the barcode
                    if (unit1 != null)
                    {
                        int itemId = (int)unit1.itemId;
                        if (unit1.itemId != 0)
                        {
                            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId).FirstOrDefault());
                            //item doesn't exist in bill
                            if (index == -1)
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
            }
        }

        private void addRowToBill(string itemName, int itemId, string unitName, int itemUnitId, int count, decimal price, decimal total)
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
            });
            _Sum += total;
        }
        #endregion billdetails


        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;

            if (dg_billDetails.SelectedIndex != -1)
                billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
        }


        private void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //MessageBox.Show("I'm Here in _CollectionChanged");

            //billDetails
            int count = 0;
            foreach (var item in billDetails)
            {
                if (dg_billDetails.Items.Count != 0)
                {
                    if (dg_billDetails.Items.Count == 1)
                    {

                        var comboBoxlist = FindControls.FindVisualChildren<ComboBox>(dg_billDetails).ToArray();
                        //comboBoxlist[0].SelectedValue = (int)item.itemUnitId;
                        for (int i = 0; i < comboBoxlist.Count(); i++)
                        {
                            if (comboBoxlist[i].Name.ToString() == "cbm_unitItemDetails")
                            {
                                MessageBox.Show("I'm Here");
                            }

                        }

                        //List<ComboBox> comboBoxlist = new List<ComboBox>();
                        //// Find all elements
                        //StaticClass.FindChildGroup<ComboBox>(dg_billDetails, "cbm_unitItemDetails", ref comboBoxlist);


                        //foreach (CheckBox c in checkBoxlist)
                        //{
                        //    if (c.IsChecked)
                        //    {
                        //        //do whatever you want
                        //    }
                        //}
                        //comboBoxlist[0].SelectedValue = (int)item.itemUnitId;

                        /*
                            (dg_billDetails.Items[0] as BillDetails).itemUnitId = (int)item.itemUnitId;
                     var allCells =    dg_billDetails.SelectedCells;
                        
                        foreach (var c in allCells)
                        {
                            MessageBox.Show("HelloWorld!");

                           //MessageBox.Show(c.Column)
                        }
                        //var cp = (ContentPresenter)cell.Content;
                        //var combo = (ComboBox)cp.ContentTemplate.FindName("cbm_unitItemDetails", cp);
                        //combo.SelectedValue = (int)item.itemUnitId;

                        //cbm_unitItemDetails.allcell
                        //cbm_unitItemDetails.se
                        */
                    }
                    else if (dg_billDetails.Items.Count != 1)
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
                    ItemTransfer item = invoiceItems.ToList().Find(i => i.itemUnitId == row.itemUnitId);
                    if (newCount > item.quantity)
                    {
                        // return old value 
                        t.Text = item.quantity.ToString();

                        newCount = (long)item.quantity;
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
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

                //refresh total cell
                TextBlock tb = dg_billDetails.Columns[6].GetCellContent(dg_billDetails.Items[index]) as TextBlock;
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
            try
            {
                string addpath = @"\Reports\InvPurReport.rdlc";
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                if (invoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                    rep.ReportPath = reppath;
                    rep.DataSources.Clear();
                    rep.DataSources.Add(new ReportDataSource("DataSetItemTransfer", invoiceItems));
                    rep.EnableExternalImages = true;


                    // rep.DataSources.Add(new ReportDataSource("DataSetItemTransfer", data));
                    ReportParameter[] paramarr = new ReportParameter[15];

                    paramarr[0] = new ReportParameter("Title", "Purshase Invoice");
                    paramarr[12] = new ReportParameter("lang", MainWindow.lang);
                    paramarr[1] = new ReportParameter("invNumber", invoice.invNumber);
                    paramarr[2] = new ReportParameter("invoiceId", invoice.invoiceId.ToString());
                    paramarr[3] = new ReportParameter("invDate", reportclass.DateToString(invoice.invDate));
                    paramarr[4] = new ReportParameter("invTime", reportclass.TimeToString(invoice.invTime));
                    paramarr[5] = new ReportParameter("vendorInvNum", invoice.vendorInvNum.ToString());
                    paramarr[6] = new ReportParameter("total", reportclass.DecTostring(invoice.total));
                    paramarr[7] = new ReportParameter("discountValue", reportclass.DecTostring(invoice.discountValue));
                    paramarr[8] = new ReportParameter("totalNet", reportclass.DecTostring(invoice.totalNet));
                    paramarr[9] = new ReportParameter("paid", reportclass.DecTostring(invoice.paid));
                    paramarr[10] = new ReportParameter("deserved", reportclass.DecTostring(invoice.deserved));
                    paramarr[11] = new ReportParameter("deservedDate", invoice.deservedDate.ToString());
                    paramarr[14] = new ReportParameter("tax", "0");
                    paramarr[13] = new ReportParameter("barcodeimage", "file:\\" + reportclass.BarcodeToImage(invoice.invNumber.ToString(), "invnum"));
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
            catch { }
        }

        private void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            //items

            Window.GetWindow(this).Opacity = 0.2;
            wd_items w = new wd_items();
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

        private void Btn_quotations_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
    }
}

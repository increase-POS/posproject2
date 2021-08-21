using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
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

namespace POS.View.accounts
{
    /// <summary>
    /// Interaction logic for uc_orderAccounts.xaml
    /// </summary>
    public partial class uc_orderAccounts : UserControl
    {
        string createPermission = "ordersAccounting_create";
        string reportsPermission = "ordersAccounting_reports";
        private static uc_orderAccounts _instance;
        public static uc_orderAccounts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_orderAccounts();
                return _instance;
            }
        }
        public uc_orderAccounts()
        {
            InitializeComponent();
        }
        CashTransfer cashModel = new CashTransfer();
        Invoice invoiceModel = new Invoice();
        Branch branchModel = new Branch();
        CashTransfer cashtrans = new CashTransfer();
        Invoice invoice = new Invoice();

        Bonds bondModel = new Bonds();
        Card cardModel = new Card();
        Agent agentModel = new Agent();
        User userModel = new User();
        Pos posModel = new Pos();
        IEnumerable<Agent> agents;
        IEnumerable<Agent> customers;
        IEnumerable<User> users;
        IEnumerable<Card> cards;
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashesQueryExcel;
        IEnumerable<Invoice> invoiceQuery;
        IEnumerable<Invoice> invoiceQueryExcel;
        IEnumerable<CashTransfer> cashes;
        IEnumerable<Invoice> invoices;
        IEnumerable<Branch> branches;
        int agentId, userId;
        string searchText = "";
        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {//confirm

        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load

            //SectionData.fillBranches(cb_branch, "bs");/////permissions

            #region fill branch combo1
            branches = await branchModel.GetBranchesActive("b");
            cb_branch.ItemsSource = branches;
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
            cb_branch.SelectedValue = MainWindow.branchID.Value;
            cb_branch.IsEnabled = false;////////////permissions
            #endregion

            #region translate
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucOrderAccounts.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucOrderAccounts.FlowDirection = FlowDirection.RightToLeft;
            }
            translate();
            #endregion

            #region Style Date
            /////////////////////////////////////////////////////////////
            SectionData.defaultDatePickerStyle(dp_startSearchDate);
            SectionData.defaultDatePickerStyle(dp_endSearchDate);
            /////////////////////////////////////////////////////////////
            #endregion

            dp_endSearchDate.SelectedDate = DateTime.Now;
            dp_startSearchDate.SelectedDate = DateTime.Now;

            dp_startSearchDate.SelectedDateChanged += this.dp_SelectedStartDateChanged;
            dp_endSearchDate.SelectedDateChanged += this.dp_SelectedEndDateChanged;

            btn_image.IsEnabled = false;

            #region fill process type
            var typelist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trCredit")    , Value = "balance" },
            new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
            new { Text = MainWindow.resourcemanager.GetString("trDocument")   , Value = "doc" },
            new { Text = MainWindow.resourcemanager.GetString("trCheque")     , Value = "cheque" },
            new { Text = MainWindow.resourcemanager.GetString("trCreditCard") , Value = "card" }
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

            #region fill agent combo
            List<Agent> agents = new List<Agent>();
            List<Agent> customers = new List<Agent>();
            customers = await agentModel.GetAgentsActive("c");
            agents = await agentModel.GetAgentsActive("v");
            agents.AddRange(customers);
            //foreach(var a in agents)
            //{
            //    if (a.type == "v")
            //        a.name = MainWindow.resourcemanager.GetString("trVendor")+ " " + a.name;
            //    else if(a.type == "c")
            //        a.name = MainWindow.resourcemanager.GetString("trCustomer")+ " " + a.name;
            //}
            //cb_customer.ItemsSource = agents;
            cb_customer.ItemsSource = customers;
            cb_customer.DisplayMemberPath = "name";
            cb_customer.SelectedValuePath = "agentId";
            cb_customer.SelectedIndex = -1;
            #endregion

            #region fill salesman combo
            users = await userModel.GetUsersActive();
            cb_salesMan.ItemsSource = users;
            cb_salesMan.DisplayMemberPath = "username";
            cb_salesMan.SelectedValuePath = "userId";
            cb_salesMan.SelectedIndex = -1;
            #endregion

            #region fill status combo
            var statuslist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trInDelivery")  , Value = "rc" },
            new { Text = MainWindow.resourcemanager.GetString("trDelivered")   , Value = "tr" }
             };
            cb_state.DisplayMemberPath = "Text";
            cb_state.SelectedValuePath = "Value";
            cb_state.ItemsSource = statuslist;
            #endregion


            await RefreshInvoiceList();
            Tb_search_TextChanged(null, null);

        }
        private async void dp_SelectedEndDateChanged(object sender, SelectionChangedEventArgs e)
        {
            await RefreshInvoiceList();
            Tb_search_TextChanged(null, null);
        }
        private async void dp_SelectedStartDateChanged(object sender, SelectionChangedEventArgs e)
        {
            await RefreshInvoiceList();
            Tb_search_TextChanged(null, null);
        }
        private void translate()
        {
            txt_order.Text = MainWindow.resourcemanager.GetString("trOrders");
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trTransaferDetails");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trBranchHint"));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_invoiceNum, MainWindow.resourcemanager.GetString("trInvoiceNumberHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNum, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_docDate, MainWindow.resourcemanager.GetString("trDocDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNumCheque, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNumCard, MainWindow.resourcemanager.GetString("trProcessNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_docDateCheque, MainWindow.resourcemanager.GetString("trDocDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_card, MainWindow.resourcemanager.GetString("trCardHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_salesMan, MainWindow.resourcemanager.GetString("trSalesManHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trVendor/CustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trCustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_startSearchDate, MainWindow.resourcemanager.GetString("trSartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_endSearchDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_state, MainWindow.resourcemanager.GetString("trStateHint"));

            //dg_orderAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_orderAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            dg_orderAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trSalesMan");
            dg_orderAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trCustomer");
            dg_orderAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trCashTooltip");
            dg_orderAccounts.Columns[4].Header = MainWindow.resourcemanager.GetString("trState");

            tt_code.Content = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            tt_paymentType.Content = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            tt_docNum.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            tt_docDate.Content = MainWindow.resourcemanager.GetString("trDocDateTooltip");
            tt_docNumCheque.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            tt_docDateCheque.Content = MainWindow.resourcemanager.GetString("trDocDateTooltip");
            tt_docNumCard.Content = MainWindow.resourcemanager.GetString("trProcessNumTooltip");
            tt_card.Content = MainWindow.resourcemanager.GetString("trCardTooltip");
            tt_cash.Content = MainWindow.resourcemanager.GetString("trCashTooltip");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_startDate.Content = MainWindow.resourcemanager.GetString("trSartDate");
            tt_endDate.Content = MainWindow.resourcemanager.GetString("trEndDate");
            tt_state.Content = MainWindow.resourcemanager.GetString("trState");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            tt_startDate.Content = MainWindow.resourcemanager.GetString("trStartDate");
            tt_endDate.Content = MainWindow.resourcemanager.GetString("trEndDate");
            //tt_salesMan.Content = MainWindow.resourcemanager.GetString("trSalesMan");
            tt_customer.Content = MainWindow.resourcemanager.GetString("trVendor/Customer");
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
            btn_image.Content = MainWindow.resourcemanager.GetString("trImage");
            btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            btn_printInvoice.Content = MainWindow.resourcemanager.GetString("trPrint");
            btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trSave");
        }
        private void Dg_orderAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorpaymentProcessType);
            TextBox tbDocDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
            //SectionData.clearValidate(tbDocDate, p_errorDocDate);
            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_cash, p_errorCash);

            if (dg_orderAccounts.SelectedIndex != -1)
            {
                invoice = dg_orderAccounts.SelectedItem as Invoice;
                this.DataContext = cashtrans;

                if (invoice != null)
                {
                    if (invoice.status == "tr")
                        btn_save.IsEnabled = false;
                    else
                        btn_save.IsEnabled = true;
                    tb_cash.IsEnabled = true;

                    btn_image.IsEnabled = true;

                    //cb_paymentProcessType.SelectedValue = invoice.processType;

                    //cb_card.SelectedValue = cashtrans.cardId;

                    tb_invoiceNum.Text = invoice.invNumber;
                    agentId = invoice.agentId.Value;
                    userId = invoice.shipUserId.Value;

                    if (cb_paymentProcessType.SelectedIndex == 0)
                    {
                        tb_cash.Text = invoice.deserved.ToString();
                        tb_cash.IsEnabled = false;
                    }
                    else
                    {
                        tb_cash.IsEnabled = true;
                        tb_cash.Clear();
                    }
                }
            }
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            if (invoices is null)
                await RefreshInvoiceList();
            this.Dispatcher.Invoke(() =>
            {
                searchText = tb_search.Text.ToLower();
                invoiceQuery = invoices.Where(s => (s.invNumber.ToLower().Contains(searchText)
                || s.shipUserName.ToLower().Contains(searchText)
                || s.agentName.ToLower().Contains(searchText)
                || s.totalNet.ToString().ToLower().Contains(searchText)
                || s.status.ToLower().Contains(searchText)
                )
                && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                );

            });

            invoiceQueryExcel = invoiceQuery;
            RefreshInvoiceView();
        }
        private async Task<string> saveBond(string num, decimal ammount, Nullable<DateTime> date, string type)
        {
            Bonds bond = new Bonds();
            bond.number = num;
            bond.amount = ammount;
            bond.deserveDate = date;
            bond.type = type;
            bond.isRecieved = 0;
            bond.createUserId = MainWindow.userID.Value;

            string s = await bondModel.Save(bond);

            return s;
        }

        private async void calcBalance(decimal ammount)
        {
            string s = "";
            //increase pos balance
            Pos pos = await posModel.getPosById(MainWindow.posID.Value);
            //MessageBox.Show(pos.balance.ToString());
            pos.balance += ammount;

            s = await pos.savePos(pos);
        }
        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

        }
        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

        }
        private async void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
         /////////////////////////
            cb_paymentProcessType.IsEnabled = true;
            cb_card.IsEnabled = true;
            tb_docNum.IsEnabled = true;
            dp_docDate.IsEnabled = true;
            tb_docNumCheque.IsEnabled = true;
            tb_docNumCard.IsEnabled = true;
            dp_docDateCheque.IsEnabled = true;
            tb_cash.IsEnabled = true;
            tb_note.IsEnabled = true;

            btn_image.IsEnabled = false;
            /////////////////////////
            ///
            if (grid_doc.IsVisible)
            {
                TextBox tbDocDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                SectionData.clearValidate(tbDocDate, p_errorDocDate);
                dp_docDate.SelectedDate = null;
                tb_docNum.Clear();
                SectionData.clearValidate(tb_docNum, p_errorDocNum);
            }
            if (grid_cheque.IsVisible)
            {
                tb_docNumCheque.Clear();
                dp_docDateCheque.SelectedDate = null;
                // TextBox tbDocDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);
                // SectionData.clearValidate(tbDocDateCheque, p_errorDocDate);
                SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
            }
            cb_card.Visibility = Visibility.Collapsed;
            cb_paymentProcessType.SelectedIndex = -1;
            tb_cash.Clear();
            tb_note.Clear();
            tb_docNumCard.Clear();
            tb_docNum.Clear();
            tb_docNumCheque.Clear();
            tb_invoiceNum.Text = "";
            tb_cash.IsReadOnly = false;
            grid_doc.Visibility = Visibility.Collapsed;
            tb_docNumCard.Visibility = Visibility.Collapsed;
            grid_cheque.Visibility = Visibility.Collapsed;
            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorCard);
            SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);

        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
            {
                try
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Thread t1 = new Thread(FN_ExportToExcel);
                        t1.SetApartmentState(ApartmentState.STA);
                        t1.Start();
                    });
                }
                catch (Exception ex)
                {
                    SectionData.ExceptionMessage(ex, this, sender);
                }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        void FN_ExportToExcel()
        {
            var QueryExcel = invoiceQuery.AsEnumerable().Select(x => new
            {
                InvoiceNumber = x.invNumber,
                SalesMan = x.shipUserName,
                Customer = x.agentName,
                Cash = x.totalNet,
                Status = x.status
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trSalesMan");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trCustomer");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trCashTooltip");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trState");

            ExportToExcel.Export(DTForExcel);

        }
        private void Btn_image_Click(object sender, RoutedEventArgs e)
        {//image
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one"))
            {



                if (cashtrans != null || cashtrans.cashTransId != 0)
                {
                    //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;

                    wd_uploadImage w = new wd_uploadImage();

                    w.tableName = "invoices";
                    w.tableId = invoice.invoiceId;
                    w.docNum = invoice.invNumber;
                    w.ShowDialog();
                    // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity =1;
                }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            await RefreshInvoiceList();
            Tb_search_TextChanged(null, null);
        }

        async Task<IEnumerable<Invoice>> RefreshInvoiceList()
        {
            invoices = await invoiceModel.getOrdersForPay(Convert.ToInt32(cb_branch.SelectedValue));
            return invoices;

        }

        void RefreshInvoiceView()
        {
            dg_orderAccounts.ItemsSource = invoiceQuery;
            txt_count.Text = invoiceQuery.Count().ToString();
        }
        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }
        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_cash")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
                else if ((sender as TextBox).Name == "tb_docNum")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocNum, tt_errorDocNum, "trEmptyDocNumToolTip");
                else if ((sender as TextBox).Name == "tb_docNumCheque")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocNumCheque, tt_errorDocNumCheque, "trEmptyDocNumToolTip");
                else if ((sender as TextBox).Name == "tb_docNumCard")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocCard, tt_errorDocCard, "trEmptyProcessNumToolTip");
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_paymentProcessType")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                else if ((sender as ComboBox).Name == "cb_card")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
            }
            else if (name == "DatePicker")
            {
                if ((sender as DatePicker).Name == "dp_docDate")
                    SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorDocDate, tt_errorDocDate, "trEmptyDocDateToolTip");
                if ((sender as DatePicker).Name == "dp_docDateCheque")
                    SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorDocDateCheque, tt_errorDocDateCheque, "trEmptyDocDateToolTip");
            }
        }
        private void PreventSpaces(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void Tb_docNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only int
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Tb_cash_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only decimal
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
            var txb = sender as TextBox;
            if ((sender as TextBox).Name == "tb_cash")
                SectionData.InputJustNumber(ref txb);
        }

        string processType = "";
        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//type selection
            switch (cb_paymentProcessType.SelectedIndex)
            {
                case 0://balance
                    grid_doc.Visibility = Visibility.Collapsed;
                    grid_cheque.Visibility = Visibility.Collapsed;
                    cb_card.Visibility = Visibility.Collapsed;
                    tb_docNumCard.Visibility = Visibility.Collapsed;
                    SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    SectionData.clearValidate(tb_docNumCheque, p_errorDocNum);
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    if (grid_doc.IsVisible)
                    {
                        TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                        SectionData.clearValidate(dpDate, p_errorDocDate);
                    }
                    if (grid_cheque.IsVisible)
                    {
                        TextBox dpDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);
                        SectionData.clearValidate(dpDateCheque, p_errorDocNumCheque);
                    }
                    if (invoice != null)
                    {
                        tb_cash.Text = invoice.deserved.ToString();
                        tb_cash.IsEnabled = false;
                    }
                    processType = "1";
                    break;

                case 1://cash
                    grid_doc.Visibility = Visibility.Collapsed;
                    grid_cheque.Visibility = Visibility.Collapsed;
                    cb_card.Visibility = Visibility.Collapsed;
                    tb_docNumCard.Visibility = Visibility.Collapsed;
                    SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    SectionData.clearValidate(tb_docNumCheque, p_errorDocNum);
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    if (grid_doc.IsVisible)
                    {
                        TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                        SectionData.clearValidate(dpDate, p_errorDocDate);
                    }
                    if (grid_cheque.IsVisible)
                    {
                        TextBox dpDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);
                        SectionData.clearValidate(dpDateCheque, p_errorDocNumCheque);
                    }
                    tb_cash.IsEnabled = true;
                    tb_cash.Clear();
                    SectionData.clearValidate(tb_cash, p_errorCash);
                    processType = "0";
                    break;

                case 2://doc
                    grid_doc.Visibility = Visibility.Visible;
                    grid_cheque.Visibility = Visibility.Collapsed;
                    cb_card.Visibility = Visibility.Collapsed;
                    tb_docNumCard.Visibility = Visibility.Collapsed;
                    SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                    SectionData.clearValidate(tb_docNumCheque, p_errorDocNum);
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    if (grid_cheque.IsVisible)
                    {
                        TextBox dpDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);
                        SectionData.clearValidate(dpDateCheque, p_errorDocNumCheque);
                    }
                    tb_cash.IsEnabled = true;
                    tb_cash.Clear();
                    SectionData.clearValidate(tb_cash, p_errorCash);
                    processType = "0";
                    break;

                case 3://cheque
                    grid_doc.Visibility = Visibility.Collapsed;
                    grid_cheque.Visibility = Visibility.Visible;
                    cb_card.Visibility = Visibility.Collapsed;
                    tb_docNumCard.Visibility = Visibility.Collapsed;
                    SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    if (grid_doc.IsVisible)
                    {
                        TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                        SectionData.clearValidate(dpDate, p_errorDocDate);
                    }
                    tb_cash.IsEnabled = true;
                    tb_cash.Clear();
                    SectionData.clearValidate(tb_cash, p_errorCash);
                    processType = "0";
                    break;

                case 4://card
                    grid_doc.Visibility = Visibility.Collapsed;
                    grid_cheque.Visibility = Visibility.Collapsed;
                    cb_card.Visibility = Visibility.Visible;
                    tb_docNumCard.Visibility = Visibility.Visible;
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    SectionData.clearValidate(tb_docNumCheque, p_errorDocNum);
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    if (grid_doc.IsVisible)
                    {
                        TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                        SectionData.clearValidate(dpDate, p_errorDocDate);
                    }
                    if (grid_cheque.IsVisible)
                    {
                        TextBox dpDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);
                        SectionData.clearValidate(dpDateCheque, p_errorDocNumCheque);
                    }
                    tb_cash.IsEnabled = true;
                    tb_cash.Clear();
                    SectionData.clearValidate(tb_cash, p_errorCash);
                    processType = "0";
                    break;
            }

        }

        private async void fillCustomers()
        {
            agents = await agentModel.GetAgentsActive("c");
            cb_customer.ItemsSource = agents;
            cb_customer.DisplayMemberPath = "name";
            cb_customer.SelectedValuePath = "agentId";
            cb_salesMan.SelectedIndex = -1;
        }
        private async void fillUsers()
        {
            users = await userModel.GetUsersActive();

            cb_salesMan.ItemsSource = users;
            cb_salesMan.DisplayMemberPath = "username";
            cb_salesMan.SelectedValuePath = "userId";
            cb_salesMan.SelectedIndex = -1;
        }
        private async void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one"))
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Cb_salesMan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select salesman
            invoiceQuery = invoiceQuery.Where(u => u.shipUserId == Convert.ToInt32(cb_salesMan.SelectedValue));
            invoiceQueryExcel = invoiceQuery;
            RefreshInvoiceView();
        }

        private async void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select agent
            invoiceQuery = invoiceQuery.Where(c => c.agentId == Convert.ToInt32(cb_customer.SelectedValue));
            invoiceQueryExcel = invoiceQuery;
            RefreshInvoiceView();
        }

        private async void Cb_state_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select state
            invoiceQuery = invoiceQuery.Where(s => s.status == cb_state.SelectedValue.ToString());
            invoiceQueryExcel = invoiceQuery;
            RefreshInvoiceView();
        }

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select branch

            //invoiceQuery = invoiceQuery.Where(u => u.branchId == Convert.ToInt32(cb_branch.SelectedValue));
            //invoiceQueryExcel = invoiceQuery;
            //RefreshInvoiceView();
        }



        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one"))
            {
                #region validate
                //chk empty cash
                bool acceptedAmmount = true;

                if (tb_cash.Text.Equals(""))
                    SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
                else
                {
                    decimal ammount = decimal.Parse(tb_cash.Text);

                    if (ammount == 0)
                    {
                        acceptedAmmount = false;
                        SectionData.showTextBoxValidate(tb_cash, p_errorCash, tt_errorCash, "trZeroAmmount");
                    }
                    else if (ammount > invoice.deserved)
                    {
                        acceptedAmmount = false;
                        SectionData.showTextBoxValidate(tb_cash, p_errorCash, tt_errorCash, "trGreaterAmmount");
                    }
                }
                //chk empty doc num
                if (grid_doc.IsVisible)
                {
                    TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                    SectionData.validateEmptyTextBox(tb_docNum, p_errorDocNum, tt_errorDocNum, "trEmptyDocNumToolTip");
                    SectionData.validateEmptyTextBox(dpDate, p_errorDocDate, tt_errorDocDate, "trEmptyDocDateToolTip");
                }
                else
                {
                }

                //chk empty cheque num
                if (grid_cheque.IsVisible)
                {
                    SectionData.validateEmptyTextBox(tb_docNumCheque, p_errorDocNumCheque, tt_errorDocNumCheque, "trEmptyDocNumToolTip");
                }
                else
                {
                }
                //chk empty process num
                if (tb_docNumCard.IsVisible)
                {
                    SectionData.validateEmptyTextBox(tb_docNumCard, p_errorDocCard, tt_errorDocCard, "trEmptyProcessNumToolTip");
                }
                else
                {
                    SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                }
                //chk empty payment type
                SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

                //chk empty card 
                if (cb_card.IsVisible)
                    SectionData.validateEmptyComboBox(cb_card, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
                else
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);

                #endregion

                if ((!tb_cash.Text.Equals("")) && (!cb_paymentProcessType.Text.Equals("")) &&
                 (((grid_cheque.IsVisible) && (!tb_docNumCheque.Text.Equals(""))) || (!grid_cheque.IsVisible)) &&
                 (((grid_doc.IsVisible) && (!dp_docDate.Text.Equals("")) && (!tb_docNum.Text.Equals(""))) || (!dp_docDate.IsVisible)) &&
                 (((tb_docNumCard.IsVisible) && (!tb_docNumCard.Text.Equals(""))) || (!tb_docNumCard.IsVisible)) &&
                 (((cb_card.IsVisible) && (!cb_card.Text.Equals(""))) || (!cb_card.IsVisible)) &&
                    acceptedAmmount
                 )
                {
                    CashTransfer cash = new CashTransfer();

                    cash.transType = "d";
                    cash.posId = MainWindow.posID.Value;
                    cash.transNum = await cashModel.generateCashNumber(cash.transType + "c");
                    cash.cash = decimal.Parse(tb_cash.Text);
                    cash.notes = tb_note.Text;
                    cash.createUserId = MainWindow.userID;
                    cash.side = "c";
                    cash.processType = cb_paymentProcessType.SelectedValue.ToString();

                    cash.agentId = agentId;

                    cash.userId = userId;

                    if (cb_paymentProcessType.SelectedValue.ToString().Equals("card"))
                    {
                        cash.cardId = Convert.ToInt32(cb_card.SelectedValue);
                        cash.docNum = tb_docNumCard.Text;
                    }
                    if (cb_paymentProcessType.SelectedValue.ToString().Equals("doc"))
                        cash.docNum = await cashModel.generateDocNumber("pbnd");

                    if (cb_paymentProcessType.SelectedValue.ToString().Equals("cheque"))
                        cash.docNum = tb_docNumCheque.Text;

                    if (cb_paymentProcessType.SelectedValue.ToString().Equals("doc"))
                    {
                        string res = await saveBond(cash.docNum, cash.cash.Value, dp_docDate.SelectedDate.Value, "d");
                        cash.bondId = int.Parse(res);
                    }

                    string s = await cashModel.payOrderInvoice(invoice.invoiceId, invoice.invStatusId, cash.cash.Value, processType, cash);
                    // MessageBox.Show(s);
                    if (!s.Equals(""))
                    {
                        if (cb_paymentProcessType.SelectedValue.ToString().Equals("cash"))
                            calcBalance(decimal.Parse(tb_cash.Text));

                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                        Btn_clear_Click(null, null);

                        await RefreshInvoiceList();
                        Tb_search_TextChanged(null, null);
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath;
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    addpath = @"\Reports\Account\Ar\ArOrderAccReport.rdlc";
                }
                else addpath = @"\Reports\Account\EN\OrderAccReport.rdlc";
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.orderReport(invoiceQuery, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();
                LocalReportExtensions.PrintToPrinter(rep);
            }

            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath;
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    addpath = @"\Reports\Account\Ar\ArOrderAccReport.rdlc";
                }
                else addpath = @"\Reports\Account\EN\OrderAccReport.rdlc";
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.orderReport(invoiceQuery, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);

                rep.Refresh();

                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
                }
            }

            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

    }
}

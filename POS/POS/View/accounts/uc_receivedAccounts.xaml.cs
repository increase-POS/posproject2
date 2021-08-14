using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;

namespace POS.View.accounts
{
    /// <summary>
    /// Interaction logic for uc_receivedAccounts.xaml
    /// </summary>
    public partial class uc_receivedAccounts : UserControl
    {
        private static uc_receivedAccounts _instance;
        CashTransfer cashModel = new CashTransfer();
        CashTransfer cashtrans = new CashTransfer();
        Bonds bondModel = new Bonds();
        Card cardModel = new Card();
        Agent agentModel = new Agent();
        User userModel = new User();
        ShippingCompanies shCompanyModel = new ShippingCompanies();
        Pos posModel = new Pos();
        IEnumerable<Agent> agents;
        IEnumerable<User> users;
        IEnumerable<ShippingCompanies> shCompanies;
        IEnumerable<Card> cards;
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashesQueryExcel;
        IEnumerable<CashTransfer> cashes;

        public List<Invoice> invoicesLst = new List<Invoice>();
        //print
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        string searchText = "";
        string  createPermission = "received_create";
        string reportsPermission = "received_reports";
        public static uc_receivedAccounts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_receivedAccounts();
                return _instance;
            }
        }
        public uc_receivedAccounts()
        {
            InitializeComponent();
        }
        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {//confirm

        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load

            #region translate
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucReceivedAccounts.FlowDirection = FlowDirection.LeftToRight;

            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucReceivedAccounts.FlowDirection = FlowDirection.RightToLeft;

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

            btn_invoices.IsEnabled = false;

            dp_startSearchDate.SelectedDateChanged += this.dp_SelectedStartDateChanged;
            dp_endSearchDate.SelectedDateChanged += this.dp_SelectedEndDateChanged;

            #region fill deposit from combo
            var depositlist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trVendor")                 , Value = "v" },
            new { Text = MainWindow.resourcemanager.GetString("trCustomer")               , Value = "c" },
            new { Text = MainWindow.resourcemanager.GetString("trUser")                   , Value = "u" },
            new { Text = MainWindow.resourcemanager.GetString("trAdministrativeDeposit")  , Value = "m" },
            new { Text = MainWindow.resourcemanager.GetString("trShippingCompanies")      , Value = "sh" }
             };
            cb_depositFrom.DisplayMemberPath = "Text";
            cb_depositFrom.SelectedValuePath = "Value";
            cb_depositFrom.ItemsSource = depositlist;
            #endregion

            fillVendors();

            fillCustomers();

            fillUsers();

            fillShippingCompanies();

            #region fill process type
            var typelist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
            new { Text = MainWindow.resourcemanager.GetString("trDocument")   , Value = "doc" },
            new { Text = MainWindow.resourcemanager.GetString("trCheque")     , Value = "cheque" },
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

            btn_image.IsEnabled = false;

            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }
        private async void dp_SelectedEndDateChanged(object sender, SelectionChangedEventArgs e)
        {
            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }
        private async void dp_SelectedStartDateChanged(object sender, SelectionChangedEventArgs e)
        {
            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }
        private void translate()
        {
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trTransaferDetails");
            txt_received.Text = MainWindow.resourcemanager.GetString("trReceived");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositFrom, MainWindow.resourcemanager.GetString("trDepositFromHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorV, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorC, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorU, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorSh, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNum, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_docDate, MainWindow.resourcemanager.GetString("trDocDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNumCheque, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNumCard, MainWindow.resourcemanager.GetString("trProcessNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_docDateCheque, MainWindow.resourcemanager.GetString("trDocDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_card, MainWindow.resourcemanager.GetString("trCardHint"));

            dg_receivedAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            //dg_receivedAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trDepositTo");
            dg_receivedAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trDepositor");
            dg_receivedAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            dg_receivedAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

            tt_code.Content = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            tt_depositFrom.Content = MainWindow.resourcemanager.GetString("trDepositTo");
            tt_depositorV.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            tt_depositorC.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            tt_depositorU.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            tt_depositorSh.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            tt_paymentType.Content = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            tt_docNum.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            tt_docDate.Content = MainWindow.resourcemanager.GetString("trDocDateTooltip");
            tt_docNumCheque.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            tt_docDateCheque.Content = MainWindow.resourcemanager.GetString("trDocDateTooltip");
            tt_card.Content = MainWindow.resourcemanager.GetString("trCardTooltip");
            tt_cash.Content = MainWindow.resourcemanager.GetString("trCashTooltip");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_docDate.Content = MainWindow.resourcemanager.GetString("trDocDateTooltip");
            tt_docNumCard.Content = MainWindow.resourcemanager.GetString("trProcessNumTooltip");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            tt_startDate.Content = MainWindow.resourcemanager.GetString("trStartDate");
            tt_endDate.Content = MainWindow.resourcemanager.GetString("trEndDate");

            btn_add.Content = MainWindow.resourcemanager.GetString("trSave");
            //btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            //btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            btn_image.Content = MainWindow.resourcemanager.GetString("trImage");
            btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            btn_printInvoice.Content = MainWindow.resourcemanager.GetString("trPrint");
            btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdf");

        }
        private void Dg_receivedAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            SectionData.clearComboBoxValidate(cb_depositFrom, p_errorDepositFrom);
            SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorSh, p_errordepositor);

            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorpaymentProcessType);
            TextBox tbDocDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
            //SectionData.clearValidate(tbDocDate, p_errorDocDate);
            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_cash, p_errorCash);

            if (dg_receivedAccounts.SelectedIndex != -1)
            {
                cashtrans = dg_receivedAccounts.SelectedItem as CashTransfer;
                this.DataContext = cashtrans;
                if (cashtrans != null)
                {
                    btn_image.IsEnabled = true;
                    ///////////////////////////
                    btn_add.IsEnabled = false;
                    cb_depositFrom.IsEnabled = false;
                    cb_depositorV.IsEnabled = false;
                    cb_depositorC.IsEnabled = false;
                    cb_depositorU.IsEnabled = false;
                    cb_depositorSh.IsEnabled = false;
                    btn_invoices.IsEnabled = false;
                    cb_paymentProcessType.IsEnabled = false;
                    cb_card.IsEnabled = false;
                    tb_docNum.IsEnabled = false;
                    dp_docDate.IsEnabled = false;
                    tb_docNumCheque.IsEnabled = false;
                    tb_docNumCard.IsEnabled = false;
                    dp_docDateCheque.IsEnabled = false;
                    tb_cash.IsEnabled = false;
                    tb_note.IsEnabled = false;
                    //////////////////////////
                    tb_transNum.Text = cashtrans.transNum;

                    cb_depositFrom.SelectedValue = cashtrans.side;

                    switch (cb_depositFrom.SelectedValue.ToString())
                    {
                        case "v":
                            cb_depositorV.SelectedValue = cashtrans.agentId.Value;
                            break;
                        case "c":
                            cb_depositorC.SelectedValue = cashtrans.agentId.Value;
                            break;
                        case "u":
                            cb_depositorU.SelectedValue = cashtrans.userId.Value;
                            break;
                        case "sh":
                            cb_depositorSh.SelectedValue = cashtrans.shippingCompanyId.Value;
                            break;
                        case "m":
                            break;
                    }

                    cb_paymentProcessType.SelectedValue = cashtrans.processType;

                    cb_card.SelectedValue = cashtrans.cardId;

                }
            }
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            if (cashes is null)
                await RefreshCashesList();
            this.Dispatcher.Invoke(() =>
            {
                searchText = tb_search.Text.ToLower();
                cashesQuery = cashes.Where(s => (s.transNum.ToLower().Contains(searchText)
                || s.cash.ToString().ToLower().Contains(searchText)
                )
                && (s.side == "v" || s.side == "c" || s.side == "u" ||  s.side == "m" || s.side == "sh")
                && s.transType == "d" 
                && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                );

            });

            cashesQueryExcel = cashesQuery;
            RefreshCashView();
        }
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//save
            string s = "0" , s1 = "";

            #region validate
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {
            
            //chk empty cash
            SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");

            //chk empty doc num
            if (grid_doc.IsVisible)
            {
                TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);

                SectionData.validateEmptyTextBox(tb_docNum, p_errorDocNum, tt_errorDocNum, "trEmptyDocNumToolTip");
                SectionData.validateEmptyTextBox(dpDate, p_errorDocDate, tt_errorDocDate, "trEmptyDocDateToolTip");
            }
            else
            {
                //TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);

                //SectionData.clearValidate(tb_docNum, p_errorDocNum);
                //SectionData.clearValidate(dpDate, p_errorDocNum);
            }

            //chk empty cheque num
            if (grid_cheque.IsVisible)
            {
                //TextBox dpDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);

                SectionData.validateEmptyTextBox(tb_docNumCheque, p_errorDocNumCheque, tt_errorDocNumCheque, "trEmptyDocNumToolTip");
                //SectionData.validateEmptyTextBox(dpDateCheque, p_errorDocDateCheque, tt_errorDocDateCheque, "trEmptyDocDateToolTip");
            }
            else
            {
                //TextBox dpDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);

                //SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                //SectionData.clearValidate(dpDateCheque, p_errorDocNum);
            }
                //chk empty process num
                if (tb_docNumCard.IsVisible)
                {
                    SectionData.validateEmptyTextBox(tb_docNumCard, p_errorDocCard, tt_docNumCard, "trEmptyProcessNumToolTip");
                }
                else
                {
                    SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                }
                //chk empty deposit from
                SectionData.validateEmptyComboBox(cb_depositFrom, p_errorDepositFrom, tt_errorDepositFrom, "trErrorEmptyDepositFromToolTip");

            //chk empty depositor
            if (cb_depositorV.IsVisible)
                SectionData.validateEmptyComboBox(cb_depositorV, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
            else
                SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
            if (cb_depositorC.IsVisible)
                SectionData.validateEmptyComboBox(cb_depositorC, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
            else
                SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
            if (cb_depositorU.IsVisible)
                SectionData.validateEmptyComboBox(cb_depositorU, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
            else
                SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                if (cb_depositorSh.IsVisible)
                    SectionData.validateEmptyComboBox(cb_depositorSh, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                else
                    SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);

            //chk empty payment type
            SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

            //chk empty card 
            if (cb_card.IsVisible)
                SectionData.validateEmptyComboBox(cb_card, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
            else
                SectionData.clearComboBoxValidate(cb_card, p_errorCard);
            #endregion

            if ((!tb_cash.Text.Equals("")) && (!cb_depositFrom.Text.Equals("")) && (!cb_paymentProcessType.Text.Equals("")) &&
                (((cb_depositorV.IsVisible) && (!cb_depositorV.Text.Equals(""))) || (!cb_depositorV.IsVisible)) &&
                (((cb_depositorC.IsVisible) && (!cb_depositorC.Text.Equals(""))) || (!cb_depositorC.IsVisible)) &&
                (((cb_depositorU.IsVisible) && (!cb_depositorU.Text.Equals(""))) || (!cb_depositorU.IsVisible)) &&
                (((cb_depositorSh.IsVisible) && (!cb_depositorSh.Text.Equals(""))) || (!cb_depositorSh.IsVisible)) &&
                (((grid_cheque.IsVisible) && (!tb_docNumCheque.Text.Equals(""))) || (!grid_cheque.IsVisible)) &&
                (((grid_doc.IsVisible) && (!dp_docDate.Text.Equals("")) && (!tb_docNum.Text.Equals(""))) || (!dp_docDate.IsVisible)) &&
                (((tb_docNumCard.IsVisible) && (!tb_docNumCard.Text.Equals(""))) || (!tb_docNumCard.IsVisible)) &&
                (((cb_card.IsVisible) && (!cb_card.Text.Equals(""))) || (!cb_card.IsVisible))
                )
            {
                string depositor = cb_depositFrom.SelectedValue.ToString();
                int agentid = 0;

                CashTransfer cash = new CashTransfer();

                cash.transType = "d";
                cash.posId = MainWindow.posID.Value;
                //cash.transNum = await SectionData.generateNumber('d', cb_depositFrom.SelectedValue.ToString());
                cash.transNum = await cashModel.generateCashNumber(cash.transType + cb_depositFrom.SelectedValue.ToString());
                cash.cash = decimal.Parse(tb_cash.Text);
                cash.notes = tb_note.Text;
                cash.createUserId = MainWindow.userID;
                cash.side = cb_depositFrom.SelectedValue.ToString();
                //cash.docNum = tb_docNum.Text;
                cash.processType = cb_paymentProcessType.SelectedValue.ToString();

                if (cb_depositorV.IsVisible)
                { cash.agentId = Convert.ToInt32(cb_depositorV.SelectedValue); agentid = Convert.ToInt32(cb_depositorV.SelectedValue); }

                if (cb_depositorC.IsVisible)
                { cash.agentId = Convert.ToInt32(cb_depositorC.SelectedValue); agentid = Convert.ToInt32(cb_depositorC.SelectedValue); }

                if (cb_depositorU.IsVisible)
                    cash.userId = Convert.ToInt32(cb_depositorU.SelectedValue);

                if (cb_depositorSh.IsVisible)
                    cash.shippingCompanyId = Convert.ToInt32(cb_depositorSh.SelectedValue);

                if (cb_paymentProcessType.SelectedValue.ToString().Equals("card"))
                {
                    cash.cardId = Convert.ToInt32(cb_card.SelectedValue);
                    cash.docNum = tb_docNumCard.Text;
                }

                if (cb_paymentProcessType.SelectedValue.ToString().Equals("doc"))
                    cash.docNum = tb_docNum.Text;

                if (cb_paymentProcessType.SelectedValue.ToString().Equals("cheque"))
                    cash.docNum = tb_docNumCheque.Text;

                if (cb_paymentProcessType.SelectedValue.ToString().Equals("doc"))
                {
                    string res = await saveBond(cash.docNum, cash.cash.Value, dp_docDate.SelectedDate.Value, "d");
                    cash.bondId = int.Parse(res);
                }

                if (cb_depositorV.IsVisible || cb_depositorC.IsVisible)
                {
                    if (tb_cash.IsReadOnly)
                        s1 = await cashModel.PayListOfInvoices(cash.agentId.Value, invoicesLst, "feed", cash); 
                    else
                        s1 = await cashModel.PayByAmmount(cash.agentId.Value, decimal.Parse(tb_cash.Text), "feed", cash);
                }
                else if (cb_depositorU.IsVisible)
                {
                    if (tb_cash.IsReadOnly)
                        s1 = await cashModel.PayUserListOfInvoices(cash.userId.Value, invoicesLst, "feed", cash);
                    else
                        s1 = await cashModel.PayUserByAmmount(cash.userId.Value, decimal.Parse(tb_cash.Text), "feed", cash);
                }
                else if (cb_depositorSh.IsVisible)
                {
                    if (tb_cash.IsReadOnly)
                        s1 = await cashModel.PayShippingCompanyListOfInvoices(cash.shippingCompanyId.Value, invoicesLst, "feed", cash);
                    else
                        s1 = await cashModel.payShippingCompanyByAmount(cash.shippingCompanyId.Value, decimal.Parse(tb_cash.Text), "feed", cash);
                }
                else
                s = await cashModel.Save(cash);

                if ((!s.Equals("0")) || (!s1.Equals("")) || (s1.Equals("-1")))
                {
                    if (cb_paymentProcessType.SelectedValue.ToString().Equals("cash"))
                        calcBalance(cash.cash.Value, depositor, agentid);

                    //if(cb_depositorU.IsVisible)
                    //        calcUserBalance(Convert.ToSingle(cash.cash.Value), cash.userId.Value);

                    //if (cb_depositorSh.IsVisible)
                    //    calcShippingComBalance(cash.cash.Value, cash.shippingCompanyId.Value);

                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);

                    await RefreshCashesList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

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

        private async void calcBalance(decimal ammount , string depositor , int agentid)
        {
            string s = "";
            //increase pos balance
            Pos pos = await posModel.getPosById(MainWindow.posID.Value);
            //MessageBox.Show(pos.balance.ToString());
            pos.balance += ammount;
           
            s = await pos.savePos(pos);
        }

        private async void calcUserBalance(float value, int userId)
        {//balance for user
            User user = await userModel.getUserById(userId);

            if(user.balanceType == 0)
                user.balance += value;
            else
            {
                if (value > user.balance)
                {
                    value -= user.balance;
                    user.balance = value;
                    user.balanceType = 0;
                }
                else
                    user.balance -= value;
            }

            string s = await userModel.saveUser(user);

        }

        private async void calcShippingComBalance(decimal value, int shippingcompanyId)
        {//balance for shipping company
            ShippingCompanies shCom = await shCompanyModel.GetByID(shippingcompanyId);

            if (shCom.balanceType == 0)
                shCom.balance += value;
            else
            {
                if (value > shCom.balance)
                {
                    value -= shCom.balance;
                    shCom.balance = value;
                    shCom.balanceType = 0;
                }
                else
                    shCom.balance -= value;
            }
            string s = await shCompanyModel.Save(shCom);

        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

        }

        private async void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            //tb_transNum.Text = await SectionData.generateNumber('d', cb_depositFrom.SelectedValue.ToString());
            /////////////////////////
            btn_add.IsEnabled = true;
            btn_invoices.Visibility = Visibility.Collapsed;
            cb_depositFrom.IsEnabled = true;
            cb_depositorV.IsEnabled = true;
            cb_depositorC.IsEnabled = true;
            cb_depositorU.IsEnabled = true;
            cb_depositorSh.IsEnabled = true;
            btn_invoices.IsEnabled = true;
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
            cb_depositFrom.SelectedIndex = -1;
            cb_depositorV.Visibility = Visibility.Collapsed;
            cb_depositorC.Visibility = Visibility.Collapsed ;
            cb_depositorU.Visibility = Visibility.Collapsed;
            cb_depositorSh.Visibility = Visibility.Collapsed;
            cb_card.Visibility = Visibility.Collapsed;
            cb_paymentProcessType.SelectedIndex = -1;
            tb_cash.Clear();
            tb_note.Clear();
            tb_docNumCard.Clear();
            tb_docNum.Clear();
            tb_docNumCheque.Clear();
            tb_transNum.Text = "";
            tb_cash.IsReadOnly = false;
            grid_doc.Visibility = Visibility.Collapsed;
            tb_docNumCard.Visibility = Visibility.Collapsed;
            grid_cheque.Visibility = Visibility.Collapsed;
            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearComboBoxValidate(cb_depositFrom , p_errorDepositFrom);
            SectionData.clearComboBoxValidate(cb_depositorV,    p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorSh, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card , p_errorCard);
            SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
            SectionData.clearValidate(tb_docNum , p_errorDocNum);
            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {
           
                this.Dispatcher.Invoke(() =>
                {
                    Thread t1 = new Thread(FN_ExportToExcel);
                    t1.SetApartmentState(ApartmentState.STA);
                    t1.Start();
                });
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        void FN_ExportToExcel()
        {
            var QueryExcel = cashesQueryExcel.AsEnumerable().Select(x => new
            {
                TransNum = x.transNum,
                DepositFrom = x.side,
                Depositor = x.agentName,
                OpperationType = x.processType,
                Cash = x.cash
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trDepositFrom");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trDepositor");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trCashTooltip");

            ExportToExcel.Export(DTForExcel);

        }


        private void Btn_image_Click(object sender, RoutedEventArgs e)
        {//image
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {
                if (cashtrans != null || cashtrans.cashTransId != 0)
            {
                //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;

                wd_uploadImage w = new wd_uploadImage();

                w.tableName = "cashTransfer";
                w.tableId = cashtrans.cashTransId;
                w.docNum = cashtrans.docNum;
                w.ShowDialog();
                // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity =1;
            }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }


        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }

        async Task<IEnumerable<CashTransfer>> RefreshCashesList()
        {
            cashes = await cashModel.GetCashTransferAsync("d", "all");
            cashes = cashes.Where(x => x.processType != "balance");
            //cashes = cashes.Where(c => !(c.agentId == null && c.userId == null && c.shippingCompanyId == null));
            return cashes;
        }

        void RefreshCashView()
        {
            dg_receivedAccounts.ItemsSource = cashesQuery;
            txt_count.Text = cashesQuery.Count().ToString();
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
                if ((sender as ComboBox).Name == "cb_depositFrom")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorDepositFrom, tt_errorDepositFrom, "trErrorEmptyDepositFromToolTip");
                else if ((sender as ComboBox).Name == "cb_depositorV")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                else if ((sender as ComboBox).Name == "cb_depositorC")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                else if ((sender as ComboBox).Name == "cb_depositorU")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                else if ((sender as ComboBox).Name == "cb_depositorSh")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                else if ((sender as ComboBox).Name == "cb_paymentProcessType")
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

        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//type selection
            switch (cb_paymentProcessType.SelectedIndex)
            {
                case 0://cash
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
                    break;

                case 1://doc
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
                    break;

                case 2://cheque
                    grid_doc.Visibility    = Visibility.Collapsed;
                    grid_cheque.Visibility = Visibility.Visible;
                    cb_card.Visibility     = Visibility.Collapsed;
                    tb_docNumCard.Visibility = Visibility.Collapsed;
                    SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    if (grid_doc.IsVisible)
                    {
                        TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                        SectionData.clearValidate(dpDate, p_errorDocDate);
                    }
                    break;

                case 3://card
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
                    break;
            }

        }

        private void Cb_depositFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//deposit selection
            btn_invoices.IsEnabled = false;
            switch (cb_depositFrom.SelectedIndex)
            {
                case 0://vendor
                    cb_depositorV.SelectedIndex = -1;
                    cb_depositorV.Visibility  = Visibility.Visible;
                    cb_depositorC.Visibility  = Visibility.Collapsed;
                    btn_invoices.Visibility   = Visibility.Visible;
                    cb_depositorU.Visibility  = Visibility.Collapsed;
                    cb_depositorSh.Visibility = Visibility.Collapsed;
                    break;
                case 1://customer
                    cb_depositorC.SelectedIndex = -1;
                    cb_depositorV.Visibility = Visibility.Collapsed;
                    cb_depositorC.Visibility = Visibility.Visible;
                    btn_invoices.Visibility  = Visibility.Visible;
                    cb_depositorU.Visibility = Visibility.Collapsed;
                    cb_depositorSh.Visibility = Visibility.Collapsed;
                    break;
                case 2://user
                    cb_depositorU.SelectedIndex = -1;
                    cb_depositorV.Visibility = Visibility.Collapsed;
                    cb_depositorC.Visibility = Visibility.Collapsed;
                    btn_invoices.Visibility = Visibility.Visible;
                    cb_depositorU.Visibility = Visibility.Visible;
                    cb_depositorSh.Visibility = Visibility.Collapsed;
                    break;
                case 3://other
                    cb_depositorV.Visibility = Visibility.Collapsed;
                    cb_depositorC.Visibility = Visibility.Collapsed;
                    btn_invoices.Visibility = Visibility.Collapsed;
                    cb_depositorU.Visibility = Visibility.Collapsed;
                    cb_depositorSh.Visibility = Visibility.Collapsed;
                    SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                    SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                    SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                    SectionData.clearComboBoxValidate(cb_depositorSh, p_errordepositor);
                    cb_depositorV.Text = "";
                    cb_depositorC.Text = "";
                    cb_depositorU.Text = "";
                    cb_depositorSh.Text = "";
                    break;
                case 4://shipping company
                    cb_depositorU.SelectedIndex = -1;
                    cb_depositorV.Visibility  = Visibility.Collapsed;
                    cb_depositorC.Visibility  = Visibility.Collapsed;
                    btn_invoices.Visibility   = Visibility.Visible;
                    cb_depositorU.Visibility  = Visibility.Collapsed;
                    cb_depositorSh.Visibility = Visibility.Visible;
                    break;
            }
        }

        private async void fillVendors()
        {
            agents = await agentModel.GetAgentsActive("v");

            cb_depositorV.ItemsSource = agents;
            cb_depositorV.DisplayMemberPath = "name";
            cb_depositorV.SelectedValuePath = "agentId";
            //cb_recipient.SelectedIndex = -1;
        }

        private async void fillCustomers()
        {
            agents = await agentModel.GetAgentsActive("c");

            cb_depositorC.ItemsSource = agents;
            cb_depositorC.DisplayMemberPath = "name";
            cb_depositorC.SelectedValuePath = "agentId";
            //cb_recipient.SelectedIndex = -1;
        }

        private async void fillUsers()
        {
            users = await userModel.GetUsersActive();

            cb_depositorU.ItemsSource = users;
            cb_depositorU.DisplayMemberPath = "username";
            cb_depositorU.SelectedValuePath = "userId";
            //cb_recipient.SelectedIndex = -1;
        }

        private async void fillShippingCompanies()
        {
            shCompanies = await shCompanyModel.Get();

            cb_depositorSh.ItemsSource = shCompanies;
            cb_depositorSh.DisplayMemberPath = "name";
            cb_depositorSh.SelectedValuePath = "shippingCompanyId";
            //cb_recipient.SelectedIndex = -1;
        }

        private  void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {

                if (cashtrans.cashTransId > 0)
                {
                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\Account\Ar\ArReciveReport.rdlc";
                    }
                    else
                    {
                        addpath = @"\Reports\Account\En\ReciveReport.rdlc";
                    }

                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                    //    int cashId = Int32.Parse(s);
                    //MessageBox.Show(s);
                    rep.ReportPath = reppath;
                    rep.DataSources.Clear();
                    rep.EnableExternalImages = true;
                    rep.SetParameters(reportclass.fillPayReport(cashtrans));

                    rep.Refresh();
                    try
                    {
                     LocalReportExtensions.PrintToPrinter(rep);
                    }
                    catch
                    {

                    }
                   
                }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }


        private void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {//invoices
            invoicesLst.Clear();

            Window.GetWindow(this).Opacity = 0.2;
            wd_invoicesList w = new wd_invoicesList();

            w.agentId = 0; w.userId = 0; w.shippingCompanyId = 0;

            if (cb_depositFrom.SelectedValue == "v")
                w.agentId = Convert.ToInt32(cb_depositorV.SelectedValue);
            else if (cb_depositFrom.SelectedValue == "c")
                w.agentId = Convert.ToInt32(cb_depositorC.SelectedValue);
            else if (cb_depositFrom.SelectedValue == "u")
                w.userId = Convert.ToInt32(cb_depositorU.SelectedValue);
            else if (cb_depositFrom.SelectedValue == "sh")
                w.shippingCompanyId = Convert.ToInt32(cb_depositorSh.SelectedValue);

            w.invType = "feed";

            w.ShowDialog();
            if (w.isActive)
            {
                tb_cash.Text = w.sum.ToString();
                tb_cash.IsReadOnly = true;
                invoicesLst.AddRange(w.selectedInvoices);
            }

            Window.GetWindow(this).Opacity = 1;
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    //

                    Window.GetWindow(this).Opacity = 0.2;



                    string pdfpath;
                    pdfpath = @"\Thumb\report\temp.pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                    //
                    if (cashtrans.cashTransId > 0)
                    {
                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Account\Ar\ArReciveReport.rdlc";
                        }
                        else
                        {
                            addpath = @"\Reports\Account\En\ReciveReport.rdlc";
                        }

                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                        //    int cashId = Int32.Parse(s);
                        //MessageBox.Show(s);
                        rep.ReportPath = reppath;
                        rep.DataSources.Clear();
                        rep.EnableExternalImages = true;
                        rep.SetParameters(reportclass.fillPayReport(cashtrans));

                        rep.Refresh();

                        LocalReportExtensions.ExportToPDF(rep, pdfpath);
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



                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
            }catch{

            }
            }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {

                    if (cashtrans.cashTransId > 0)
                    {
                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Account\Ar\ArReciveReport.rdlc";
                        }
                        else
                        {
                            addpath = @"\Reports\Account\En\ReciveReport.rdlc";
                        }

                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                        //    int cashId = Int32.Parse(s);
                        //MessageBox.Show(s);
                        rep.ReportPath = reppath;
                        rep.DataSources.Clear();
                        rep.EnableExternalImages = true;
                        rep.SetParameters(reportclass.fillPayReport(cashtrans));

                        rep.Refresh();

                        saveFileDialog.Filter = "PDF|*.pdf;";

                        if (saveFileDialog.ShowDialog() == true)
                        {
                            string filepath = saveFileDialog.FileName;
                            try { LocalReportExtensions.ExportToPDF(rep, filepath); }
                            catch { }

                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

            }
            catch
            {

            }
           }

        private void Cb_depositorV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cb_depositorV.SelectedIndex != -1) && (cb_depositorV.IsEnabled))
                btn_invoices.IsEnabled = true;
            else
                btn_invoices.IsEnabled = false;
        }

        private void Cb_depositorC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cb_depositorC.SelectedIndex != -1) && (cb_depositorC.IsEnabled))
                btn_invoices.IsEnabled = true;
            else
                btn_invoices.IsEnabled = false;
        }

        private void Cb_depositorU_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cb_depositorU.SelectedIndex != -1) && (cb_depositorU.IsEnabled))
                btn_invoices.IsEnabled = true;
            else
                btn_invoices.IsEnabled = false;
        }

        private void Cb_depositorSh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cb_depositorSh.SelectedIndex != -1) && (cb_depositorSh.IsEnabled))
                btn_invoices.IsEnabled = true;
            else
                btn_invoices.IsEnabled = false;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //string s = await cashModel.generateCashNumber("pv");
            //MessageBox.Show(s);

            await cashModel.generateCashNumber("pv");

        }

        private void Tb_EnglishDigit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only english and digits
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;

        }
    }
}

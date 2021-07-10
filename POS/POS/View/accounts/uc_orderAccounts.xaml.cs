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

namespace POS.View.accounts
{
    /// <summary>
    /// Interaction logic for uc_orderAccounts.xaml
    /// </summary>
    public partial class uc_orderAccounts : UserControl
    {
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
        CashTransfer cashtrans = new CashTransfer();
        Bonds bondModel = new Bonds();
        Card cardModel = new Card();
        Agent agentModel = new Agent();
        User userModel = new User();
        Pos posModel = new Pos();
        IEnumerable<Agent> agents;
        IEnumerable<User> users;
        IEnumerable<Card> cards;
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashesQueryExcel;
        IEnumerable<CashTransfer> cashes;
        string searchText = "";
        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {//confirm

        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load

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

            translate();

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
            //txt_received.Text = MainWindow.resourcemanager.GetString("trReceived");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNum, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_docDate, MainWindow.resourcemanager.GetString("trDocDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNumCheque, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_docDateCheque, MainWindow.resourcemanager.GetString("trDocDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_card, MainWindow.resourcemanager.GetString("trCardHint"));

            dg_orderAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            //dg_orderAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trDepositTo");
            dg_orderAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trRecepient");
            dg_orderAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            dg_orderAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

            tt_code.Content = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            
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

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            tt_startDate.Content = MainWindow.resourcemanager.GetString("trStartDate");
            tt_endDate.Content = MainWindow.resourcemanager.GetString("trEndDate");

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
            //btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            //btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            btn_image.Content = MainWindow.resourcemanager.GetString("trImage");
            btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            btn_printInvoice.Content = MainWindow.resourcemanager.GetString("trPrint");
            btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdf");

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
                cashtrans = dg_orderAccounts.SelectedItem as CashTransfer;
                this.DataContext = cashtrans;
                if (cashtrans != null)
                {
                    // MessageBox.Show(cashtrans.cashTransId.ToString() + "-" + cashtrans.bondId.ToString());

                    btn_save.IsEnabled = false;

                   
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
                && (s.side == "v" || s.side == "c" || s.side == "u" || s.side == "m")
                && s.transType == "d"
                && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                );

            });

            cashesQueryExcel = cashesQuery;
            RefreshCashView();
        }
        private async void saveBond(string num, decimal ammount, Nullable<DateTime> date, string type, int? cashId)
        {
            Bonds bond = new Bonds();
            bond.number = num;
            bond.amount = ammount;
            bond.deserveDate = date;
            bond.type = type;
            bond.isRecieved = 0;
            bond.createUserId = MainWindow.userID.Value;
            bond.cashTransId = cashId;

            string s = await bondModel.Save(bond);

            if (!s.Equals("0"))
            {
                //MessageBox.Show(s);
                //MessageBox.Show(cashId.Value.ToString());
                CashTransfer c = await cashModel.GetByID(cashId.Value);

                c.bondId = int.Parse(s);

                string x = await cashModel.Save(c);

                //MessageBox.Show(c.bondId.ToString());
            }
            //    MessageBox.Show("ok");
            //else MessageBox.Show("error");
        }
        private async void calcBalance(decimal ammount, string depositor, int agentid)
        {
            string s = "";
            //increase pos balance
            Pos pos = await posModel.getPosById(MainWindow.posID.Value);
            //MessageBox.Show(pos.balance.ToString());
            pos.balance += ammount;

            s = await pos.savePos(pos);

            if (s.Equals("Pos Is Updated Successfully"))
            {
                //decrease depositor balance if agent
                if ((depositor.Equals("v")) || (depositor.Equals("c")))
                {
                    Agent agent = await agentModel.getAgentById(agentid);

                    agent.balance = agent.balance - Convert.ToSingle(ammount);

                    s = await agent.saveAgent(agent);

                    // if (!s.Equals("0")) MessageBox.Show(agent.balance.ToString());
                }
            }
        }
        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

        }
        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

        }
        private async void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            btn_save.IsEnabled = true;
            cb_card.SelectedIndex = -1;
            cb_paymentProcessType.SelectedIndex = -1;
            tb_cash.Clear();
            tb_note.Clear();
            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorCard);

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

        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });
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
        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }
        async Task<IEnumerable<CashTransfer>> RefreshCashesList()
        {
            cashes = await cashModel.GetCashTransferAsync("d", "all");
            cashes = cashes.Where(x => x.processType != "balance");
            return cashes;
        }
        void RefreshCashView()
        {
            dg_orderAccounts.ItemsSource = cashesQuery;
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
            }
            else if (name == "ComboBox")
            {
               if ((sender as ComboBox).Name == "cb_paymentProcessType")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                else if ((sender as ComboBox).Name == "cb_card")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCard, tt_errorCard, "trErrorEmptyCardToolTip");
            }
            else if (name == "DatePicker")
            {
                if ((sender as DatePicker).Name == "dp_docDate")
                    SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorDocDate, tt_errorDocDate, "trErrorEmptyDocDateToolTip");
                if ((sender as DatePicker).Name == "dp_docDateCheque")
                    SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorDocDateCheque, tt_errorDocDateCheque, "trErrorEmptyDocDateToolTip");
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
        }
        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//type selection
            switch (cb_paymentProcessType.SelectedIndex)
            {
                case 0://cash
                    grid_doc.Visibility = Visibility.Collapsed;
                    grid_cheque.Visibility = Visibility.Collapsed;
                    cb_card.Visibility = Visibility.Collapsed;
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
                    SectionData.clearValidate(tb_docNumCheque, p_errorDocNum);
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    if (grid_cheque.IsVisible)
                    {
                        TextBox dpDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);
                        SectionData.clearValidate(dpDateCheque, p_errorDocNumCheque);
                    }
                    break;

                case 2://cheque
                    grid_doc.Visibility = Visibility.Collapsed;
                    grid_cheque.Visibility = Visibility.Visible;
                    cb_card.Visibility = Visibility.Collapsed;
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
            Agent ag = new Agent();
            ag = await ag.getAgentById(119);
            MessageBox.Show(ag.balance.ToString() + " " + ag.address);
            ag.balance = 5000;
            ag.address = "halabb";
            string msg = await ag.saveAgent(ag);
            MessageBox.Show(ag.balance.ToString() + " " + ag.address);
            MessageBox.Show(msg);
        }
        private void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cb_salesMan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cb_state_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for uc_paymentsAccounts.xaml
    /// </summary>
    public partial class uc_paymentsAccounts : UserControl
    {
        Agent agentModel = new Agent();
        User userModel   = new User();
        Card cardModel = new Card();
        Pos posModel = new Pos();
        CashTransfer cashModel = new CashTransfer();
        CashTransfer cashtrans = new CashTransfer();

        IEnumerable<Agent> agents;
        IEnumerable<User> users;
        IEnumerable<Card> cards;
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashesQueryExcel;

        IEnumerable<CashTransfer> cashes;

        string searchText = "";

        private static uc_paymentsAccounts _instance;
        public static uc_paymentsAccounts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_paymentsAccounts();
                return _instance;
            }
        }
        public uc_paymentsAccounts()
        {
            InitializeComponent();
        }

        private void translate()
        {
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trTransaferDetails");
            txt_Payments.Text = MainWindow.resourcemanager.GetString("trPayments");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositTo, MainWindow.resourcemanager.GetString("trDepositToHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_recipientV, MainWindow.resourcemanager.GetString("trRecipientHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_recipientC, MainWindow.resourcemanager.GetString("trRecipientHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_recipientU, MainWindow.resourcemanager.GetString("trRecipientHint"));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_card, MainWindow.resourcemanager.GetString("trCardHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNum, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            dg_paymentsAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_paymentsAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trDepositTo");
            dg_paymentsAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trRecepient");
            dg_paymentsAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            dg_paymentsAccounts.Columns[4].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

            tt_depositTo.Content = MainWindow.resourcemanager.GetString("trDepositTo");
            tt_recepientV.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            tt_recepientC.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            tt_recepientU.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");

            tt_paymentType.Content = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            tt_docNum.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            tt_card.Content = MainWindow.resourcemanager.GetString("trCardTooltip");
            tt_cash.Content = MainWindow.resourcemanager.GetString("trCashTooltip");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");

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

        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {//confirm

        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucPaymentsAccounts.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucPaymentsAccounts.FlowDirection = FlowDirection.RightToLeft;
            }

            #region Style Date
            /////////////////////////////////////////////////////////////
            dp_startSearchDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_startSearchDate.Template.FindName("PART_TextBox", dp_startSearchDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_startSearchDate.Background;
                    textBox1.BorderThickness = dp_startSearchDate.BorderThickness;
                }
            };
            /////////////////////////////////////////////////////////////
            dp_endSearchDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_endSearchDate.Template.FindName("PART_TextBox", dp_endSearchDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_endSearchDate.Background;
                    textBox1.BorderThickness = dp_endSearchDate.BorderThickness;
                }
            };
            /////////////////////////////////////////////////////////////
            #endregion

            dp_endSearchDate.SelectedDate = DateTime.Now;
            dp_startSearchDate.SelectedDate = DateTime.Now;

            #region fill deposit to combo
            var depositlist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trVendor")     , Value = "v" },
            new { Text = MainWindow.resourcemanager.GetString("trCustomer")   , Value = "c" },
            new { Text = MainWindow.resourcemanager.GetString("trUser")       , Value = "u" },
            new { Text = MainWindow.resourcemanager.GetString("trSalary")     , Value = "s" },
            new { Text = MainWindow.resourcemanager.GetString("trGeneralExpenses")     , Value = "e" },
            new { Text = MainWindow.resourcemanager.GetString("trAdministrativePull")  , Value = "m" }
             };
            cb_depositTo.DisplayMemberPath = "Text";
            cb_depositTo.SelectedValuePath = "Value";
            cb_depositTo.ItemsSource = depositlist;
            #endregion

            fillVendors();

            fillCustomers();

            fillUsers();

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

            dp_startSearchDate.SelectedDateChanged += this.dp_SelectedStartDateChanged;
            dp_endSearchDate.SelectedDateChanged += this.dp_SelectedEndDateChanged;

            translate();

            //dg_paymentsAccounts.ItemsSource = await cashModel.GetCashTransferAsync("p", "v");
            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }

        private async void dp_SelectedStartDateChanged(object sender, SelectionChangedEventArgs e)
        {
            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }

        private async void dp_SelectedEndDateChanged(object sender, SelectionChangedEventArgs e)
        {
            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }

        private async void Dg_paymentsAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearComboBoxValidate(cb_depositTo, p_errorDepositTo);
            SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
            SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
            SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorCard);

            if (dg_paymentsAccounts.SelectedIndex != -1)
            {
                cashtrans = dg_paymentsAccounts.SelectedItem as CashTransfer;
                this.DataContext = cashtrans;

                if (cashtrans != null)
                {
                    cb_depositTo.SelectedValue = cashtrans.side;

                    //MessageBox.Show(cashtrans.agentId.ToString() + " - " + cashtrans.userId.ToString());
                    //txt_recipient.Text = cashtrans.agentId.ToString() + " - " + cashtrans.userId.ToString();
                    //MessageBox.Show(cashtrans.processType);

                    switch (cb_depositTo.SelectedValue.ToString())
                    {
                        case "v":
                            cb_recipientV.SelectedValue = cashtrans.agentId.Value;
                            cb_recipientC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                            cb_recipientU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                            break;
                        case "c":
                            cb_recipientC.SelectedValue = cashtrans.agentId.Value;
                            cb_recipientV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                            cb_recipientU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                            break;
                        case "u":
                        case "s":
                            cb_recipientU.SelectedValue = cashtrans.userId.Value;
                            cb_recipientV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                            cb_recipientC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                            break;
                        case "e":
                        case "m":
                            cb_recipientV.Visibility = Visibility.Collapsed;  SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                            cb_recipientC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                            cb_recipientU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
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
                searchText = tb_search.Text;
                cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                || s.cash.ToString().Contains(searchText)
                )
                && (s.side == "v" || s.side == "c" || s.side == "u" || s.side == "s" || s.side == "e" || s.side == "m")
                && s.transType == "p"
                && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                );
               
            });

            cashesQueryExcel = cashesQuery;
            RefreshCashView();
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//save
            //chk empty cash
            SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
            
            //chk empty doc num
            if(tb_docNum.IsEnabled)
                SectionData.validateEmptyTextBox(tb_docNum, p_errorDocNum, tt_errorDocNum, "trEmptyDocNumToolTip");  
            else
                SectionData.clearValidate(tb_docNum, p_errorDocNum);  
            
            //chk empty deposit to
            SectionData.validateEmptyComboBox(cb_depositTo, p_errorDepositTo, tt_errorDepositTo, "trErrorEmptyDepositToToolTip");
            
            //chk empty recipient
            if(cb_recipientV.IsVisible)
                SectionData.validateEmptyComboBox(cb_recipientV, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
            else
                SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
            if (cb_recipientC.IsVisible)
                SectionData.validateEmptyComboBox(cb_recipientC, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
            else
                SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
            if (cb_recipientU.IsVisible)
                SectionData.validateEmptyComboBox(cb_recipientU, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
            else
                SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
            //chk empty payment type
            SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

            //chk empty card 
            if (cb_card.IsVisible)
                SectionData.validateEmptyComboBox(cb_card, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
            else
                SectionData.clearComboBoxValidate(cb_card, p_errorCard);

            if ( (!tb_cash.Text.Equals("")) && (!cb_depositTo.Text.Equals(""))  && (!cb_paymentProcessType.Text.Equals("")) && 
                 (((cb_recipientV.IsVisible) && (!cb_recipientV.Text.Equals(""))) || (!cb_recipientV.IsVisible)) &&
                 (((cb_recipientC.IsVisible) && (!cb_recipientC.Text.Equals(""))) || (!cb_recipientC.IsVisible)) &&
                 (((cb_recipientU.IsVisible) && (!cb_recipientU.Text.Equals(""))) || (!cb_recipientU.IsVisible)) &&
                 (((tb_docNum.IsVisible) && (!tb_docNum.Text.Equals(""))) || (!tb_docNum.IsVisible)) &&
                 (((cb_card.IsVisible) && (!cb_card.Text.Equals(""))) || (!cb_card.IsVisible))
                 )
            {
                string recipient = cb_depositTo.SelectedValue.ToString();
                int agentid = 0;

                CashTransfer cash = new CashTransfer();

                cash.transType = "p";
                cash.posId = MainWindow.posID.Value;
                cash.transNum = await SectionData.generateNumber('p', cb_depositTo.SelectedValue.ToString());
                cash.cash = decimal.Parse(tb_cash.Text);
                cash.notes = tb_note.Text;
                cash.createUserId = MainWindow.userID;
                cash.side = cb_depositTo.SelectedValue.ToString();
                //cash.docNum = tb_docNum.Text;
                cash.processType = cb_paymentProcessType.SelectedValue.ToString();

                if (cb_recipientV.IsVisible)
                { cash.agentId = Convert.ToInt32(cb_recipientV.SelectedValue); agentid = Convert.ToInt32(cb_recipientV.SelectedValue); }

                if (cb_recipientC.IsVisible)
                { cash.agentId = Convert.ToInt32(cb_recipientC.SelectedValue); agentid = Convert.ToInt32(cb_recipientC.SelectedValue); }

                if (cb_recipientU.IsVisible)
                    cash.userId = Convert.ToInt32(cb_recipientU.SelectedValue);

                if (cb_paymentProcessType.SelectedValue.ToString().Equals("card"))
                    cash.cardId = Convert.ToInt32(cb_card.SelectedValue);

                if ((cb_paymentProcessType.SelectedValue.ToString().Equals("doc")) || (cb_paymentProcessType.SelectedValue.ToString().Equals("cheque")))
                    cash.docNum = tb_docNum.Text;

                string s = await cashModel.Save(cash);

                if (!s.Equals("0"))
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);

                    calcBalance(cash.cash.Value, recipient, agentid);

                    //dg_paymentsAccounts.ItemsSource = await cashModel.GetCashTransferAsync("p", "v");
                    await RefreshCashesList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }

        private async void calcBalance(decimal ammount, string recipient, int agentid)
        {
            string s = "";
            //increase pos balance
            Pos pos = await posModel.getPosById(MainWindow.posID.Value);

            if (cb_paymentProcessType.SelectedValue == "cash")
                pos.balance -= ammount;
            pos.balanceAll -= ammount;

            s = await pos.savePos(pos);

            if (s.Equals("Pos Is Updated Successfully"))
            {

                //decrease depositor balance if agent
                if ((recipient.Equals("v")) || (recipient.Equals("c")))
                {
                    Agent agent = await agentModel.getAgentById(agentid);

                    agent.balance = agent.balance + Convert.ToSingle(ammount);

                    s = await agent.saveAgent(agent);
                   
                    if (!s.Equals("0")) MessageBox.Show(agent.balance.ToString());
                }
            }
        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
          
        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_transNum.Text = "";
            cb_depositTo.SelectedIndex = -1;
            //cb_recipient.SelectedIndex = -1;
            cb_paymentProcessType.SelectedIndex = -1;
            cb_card.SelectedIndex = -1;
            tb_docNum.Clear();
            tb_cash.Clear();
            tb_note.Clear();
            cb_recipientV.Visibility = Visibility.Collapsed;
            cb_recipientC.Visibility = Visibility.Collapsed;
            cb_recipientU.Visibility = Visibility.Collapsed;

            tb_docNum.IsEnabled = true;

            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearComboBoxValidate(cb_depositTo, p_errorDepositTo);
            SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
            SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
            SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorCard);
        }

        async Task<IEnumerable<CashTransfer>> RefreshCashesList()
        {
            cashes = await cashModel.GetCashTransferAsync("p", "all");
            return cashes;
        }

        void RefreshCashView()
        {
            dg_paymentsAccounts.ItemsSource = cashesQuery;
            txt_count.Text = cashesQuery.Count().ToString();
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            this.Dispatcher.Invoke(() =>
            {
                //await Task.Run(FN_ExportToExcel);
                //var result = await SimLongRunningProcessAsync();
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });
           
        }

        private async Task<string> SimLongRunningProcessAsync()
        {
            await Task.Delay(2000);
            return "Success";
        }

        void FN_ExportToExcel()
        {
            var QueryExcel = cashesQueryExcel.AsEnumerable().Select(x => new
            {
                TransNum = x.transNum,
                DepositTo = x.side,
                Recipient = x.agentName,
                OpperationType = x.processType,
                Cash = x.cash
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trDepositTo");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trRecepient");
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

        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//type selection
            switch(cb_paymentProcessType.SelectedIndex)
            {
                case 0://cash
                    tb_docNum.Visibility = Visibility.Collapsed; tb_docNum.Clear();
                    cb_card.Visibility = Visibility.Collapsed;   cb_card.SelectedIndex = -1;
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    SectionData.clearComboBoxValidate(cb_card , p_errorCard);
                    break;

                case 1://doc

                case 2://cheque
                    tb_docNum.Visibility = Visibility.Visible;
                    cb_card.Visibility = Visibility.Collapsed; cb_card.SelectedIndex = -1;
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    break;

                case 3://card
                    tb_docNum.Visibility = Visibility.Collapsed; tb_docNum.Clear();
                    cb_card.Visibility = Visibility.Visible ;
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    break;
            }
        }

        private void Cb_depositTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//deposit selection
            switch(cb_depositTo.SelectedIndex)
            {
                case 0:
                    cb_recipientV.Visibility = Visibility.Visible;
                    cb_recipientC.Visibility = Visibility.Collapsed;
                    cb_recipientU.Visibility = Visibility.Collapsed;
                    SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                    SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                    break;
                case 1:
                    cb_recipientV.Visibility = Visibility.Collapsed;
                    cb_recipientC.Visibility = Visibility.Visible;
                    cb_recipientU.Visibility = Visibility.Collapsed;
                    SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                    SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                    break;
                case 2:  
                case 3:
                    cb_recipientV.Visibility = Visibility.Collapsed;
                    cb_recipientC.Visibility = Visibility.Collapsed;
                    cb_recipientU.Visibility = Visibility.Visible;
                    SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                    SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                    break;
                case 4: 
                case 5:
                    cb_recipientV.Visibility = Visibility.Collapsed;
                    cb_recipientC.Visibility = Visibility.Collapsed;
                    cb_recipientU.Visibility = Visibility.Collapsed;
                    cb_recipientV.Text = ""; cb_recipientC.Text = ""; cb_recipientU.Text = "";
                    SectionData.clearComboBoxValidate(cb_recipientV , p_errorRecipient);
                    SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                    SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);

                    break;
            }
        }

        private async void fillVendors()
        {
            agents = await agentModel.GetAgentsActive("v");

            cb_recipientV.ItemsSource = agents;
            cb_recipientV.DisplayMemberPath = "name";
            cb_recipientV.SelectedValuePath = "agentId";
            //cb_recipient.SelectedIndex = -1;
        }

        private async void fillCustomers()
        {
            agents = await agentModel.GetAgentsActive("c");

            cb_recipientC.ItemsSource = agents;
            cb_recipientC.DisplayMemberPath = "name";
            cb_recipientC.SelectedValuePath = "agentId";
            //cb_recipient.SelectedIndex = -1;
        }

        private async void fillUsers()
        {
            users = await userModel.GetUsersActive();

            cb_recipientU.ItemsSource = users;
            cb_recipientU.DisplayMemberPath = "username";
            cb_recipientU.SelectedValuePath = "userId";
            //cb_recipient.SelectedIndex = -1;
        }

        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
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
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocNum, tt_errorDocNum , "trEmptyDocNumToolTip");
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_depositTo")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorDepositTo, tt_errorDepositTo, "trErrorEmptyDepositToToolTip");
                else if ((sender as ComboBox).Name == "cb_recipientV")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
                else if ((sender as ComboBox).Name == "cb_recipientC")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
                else if ((sender as ComboBox).Name == "cb_recipientU")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
                else if ((sender as ComboBox).Name == "cb_paymentProcessType")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                else if ((sender as ComboBox).Name == "cb_card")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
            }
        }

        private void PreventSpaces(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_cash_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only decimal
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void Tb_docNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only int
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    
    }
}

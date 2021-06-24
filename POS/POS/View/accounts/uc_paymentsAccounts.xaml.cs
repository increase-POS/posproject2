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
    /// Interaction logic for uc_paymentsAccounts.xaml
    /// </summary>
    public partial class uc_paymentsAccounts : UserControl
    {
        Agent agentModel = new Agent();
        User userModel = new User();
        Card cardModel = new Card();
        Bonds bondModel = new Bonds();
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
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        string s = "0";
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
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNumCheque, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_docDate, MainWindow.resourcemanager.GetString("trDocDateHint"));
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
            tt_docDate.Content = MainWindow.resourcemanager.GetString("trDocDateTooltip");
            tt_docNumCheque.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
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
            btn_print_pay.Content = MainWindow.resourcemanager.GetString("trPrint");
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
            //dp_docDate.SelectedDate = DateTime.Now;

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
            if (grid_document.IsVisible)
            {
                TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                SectionData.clearValidate(dpDate, p_errorDocDate);
            }
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
                    MessageBox.Show(cashtrans.cashTransId.ToString()+"-"+ cashtrans.bondId.ToString());

                    cb_depositTo.SelectedValue = cashtrans.side;
                    btn_add.IsEnabled = false;

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
                            cb_recipientV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                            cb_recipientC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                            cb_recipientU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                            break;
                    }

                    cb_paymentProcessType.SelectedValue = cashtrans.processType;

                    cb_card.SelectedValue = cashtrans.cardId;

                    dp_docDate.SelectedDate = cashtrans.bondDeserveDate;
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

            //chk empty doc date
            TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);

            if (grid_document.IsVisible)
            {

                //SectionData.validateEmptyTextBox(tb_docNum, p_errorDocNum, tt_errorDocNum, "trEmptyDocNumToolTip");
                SectionData.validateEmptyTextBox(dpDate, p_errorDocDate, tt_errorDocDate, "trEmptyDocDateToolTip");
            }
            else
            {
                //SectionData.clearValidate(tb_docNum, p_errorDocNum);
                //SectionData.clearValidate(dpDate, p_errorDocNum);
            }

            //chk empty doc num
            if (grid_cheque.IsVisible)
            {
                SectionData.validateEmptyTextBox(tb_docNumCheque, p_errorDocNumCheque, tt_errorDocNum, "trEmptyDocNumToolTip");
                //SectionData.validateEmptyTextBox(dpDate, p_errorDocDate, tt_errorDocDate, "trEmptyDocDateToolTip");
            }
            else
            {
                SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                //SectionData.clearValidate(dpDate, p_errorDocNum);
            }

            //chk empty deposit to
            SectionData.validateEmptyComboBox(cb_depositTo, p_errorDepositTo, tt_errorDepositTo, "trErrorEmptyDepositToToolTip");

            //chk empty recipient
            if (cb_recipientV.IsVisible)
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

            //chk enough money
            if ((!tb_cash.Text.Equals("")) && (!await chkEnoughBalance(decimal.Parse(tb_cash.Text))))
                SectionData.showTextBoxValidate(tb_cash, p_errorCash, tt_errorCash, "trPopNotEnoughBalance");

            //chk empty card 
            if (cb_card.IsVisible)
                SectionData.validateEmptyComboBox(cb_card, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
            else
                SectionData.clearComboBoxValidate(cb_card, p_errorCard);

            if ((!tb_cash.Text.Equals("")) && (!cb_depositTo.Text.Equals("")) && (!cb_paymentProcessType.Text.Equals("")) &&
                 (((cb_recipientV.IsVisible) && (!cb_recipientV.Text.Equals(""))) || (!cb_recipientV.IsVisible)) &&
                 (((cb_recipientC.IsVisible) && (!cb_recipientC.Text.Equals(""))) || (!cb_recipientC.IsVisible)) &&
                 (((cb_recipientU.IsVisible) && (!cb_recipientU.Text.Equals(""))) || (!cb_recipientU.IsVisible)) &&
                 (((tb_docNumCheque.IsVisible) && (!tb_docNumCheque.Text.Equals(""))) || (!tb_docNumCheque.IsVisible)) &&
                 (((dp_docDate.IsVisible) && (!dp_docDate.Text.Equals(""))) || (!dp_docDate.IsVisible)) &&
                 (((cb_card.IsVisible) && (!cb_card.Text.Equals(""))) || (!cb_card.IsVisible)) &&
                 await chkEnoughBalance(decimal.Parse(tb_cash.Text))
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

                cash.processType = cb_paymentProcessType.SelectedValue.ToString();

                if (cb_recipientV.IsVisible)
                { cash.agentId = Convert.ToInt32(cb_recipientV.SelectedValue); agentid = Convert.ToInt32(cb_recipientV.SelectedValue); }

                if (cb_recipientC.IsVisible)
                { cash.agentId = Convert.ToInt32(cb_recipientC.SelectedValue); agentid = Convert.ToInt32(cb_recipientC.SelectedValue); }

                if (cb_recipientU.IsVisible)
                    cash.userId = Convert.ToInt32(cb_recipientU.SelectedValue);

                if (cb_paymentProcessType.SelectedValue.ToString().Equals("card"))
                    cash.cardId = Convert.ToInt32(cb_card.SelectedValue);

                if (cb_paymentProcessType.SelectedValue.ToString().Equals("doc"))
                    cash.docNum = await SectionData.generateNumberBond('p', "bnd");

                if (cb_paymentProcessType.SelectedValue.ToString().Equals("cheque"))
                    cash.docNum = tb_docNumCheque.Text;

                s = await cashModel.Save(cash);

                if (!s.Equals("0"))
                {
                    //MessageBox.Show(s);
                    calcBalance(cash.cash.Value, recipient, agentid);

                    if (cb_paymentProcessType.SelectedValue.ToString().Equals("doc"))
                        saveBond(cash.docNum, cash.cash.Value, dp_docDate.SelectedDate.Value, "p", int.Parse(s));

                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);


                    await RefreshCashesList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }

        }

        private async Task<bool> chkEnoughBalance(decimal ammount)
        {
            Pos pos = await posModel.getPosById(MainWindow.posID.Value);

            if (pos.balance.Value >= ammount)
            { return true; }
            else { return false; }
           
        }
        

        private async void saveBond(string num, decimal ammount, Nullable <DateTime> date, string type , int? cashId)
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
           
            if(!s.Equals("0"))
            {
                //MessageBox.Show(s);
                CashTransfer c = await cashModel.GetByID(cashId.Value);

                c.bondId = int.Parse(s);

                string x = await cashModel.Save(c);
            }

        }

        private async void calcBalance(decimal ammount, string recipient, int agentid)
        {
            string s = "";
            //increase pos balance
            Pos pos = await posModel.getPosById(MainWindow.posID.Value);

            pos.balance -= ammount;

            s = await pos.savePos(pos);
            if (s.Equals("Pos Is Updated Successfully"))
            {
                //MessageBox.Show(pos.balance.ToString());
                //decrease depositor balance if agent
                if ((recipient.Equals("v")) || (recipient.Equals("c")))
                {
                    Agent agent = await agentModel.getAgentById(agentid);
                    //MessageBox.Show(agent.balance.ToString());
                    agent.balance = agent.balance + Convert.ToSingle(ammount);

                    s = await agent.saveAgent(agent);

                    //if (!s.Equals("0")) MessageBox.Show(agent.balance.ToString());
                }
            }
           

        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
          
        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
        }

        private async void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            btn_add.IsEnabled = true;
            //tb_transNum.Text = await SectionData.generateNumber('p', cb_depositTo.SelectedValue.ToString());
            cb_depositTo.SelectedIndex = -1;
            //cb_recipient.SelectedIndex = -1;
            cb_paymentProcessType.SelectedIndex = -1;
            cb_card.SelectedIndex = -1;
            tb_docNum.Clear();
            tb_docNumCheque.Clear();
            dp_docDate.SelectedDate = null;
            tb_cash.Clear();
            tb_note.Clear();
            cb_recipientV.Visibility = Visibility.Collapsed;
            cb_recipientC.Visibility = Visibility.Collapsed;
            cb_recipientU.Visibility = Visibility.Collapsed;

            grid_document.Visibility = Visibility.Collapsed ;

            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_cash, p_errorCash);
            if (grid_document.IsVisible)
            {
                TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                SectionData.clearValidate(dpDate, p_errorDocNum);

            }
            SectionData.clearValidate(tb_docNum, p_errorDocNum);
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
        
            foreach (CashTransfer cashItem in cashes)
            {
                if (cashItem.agentId > 0)
                {
                    cashItem.reciveName = cashItem.agentName;
                }
                else
                {
                    cashItem.reciveName = cashItem.usersName + " " + cashItem.usersLName;
                }
             
            }

            return cashes;
            
        }

        void RefreshCashView()
        {
            dg_paymentsAccounts.ItemsSource = cashesQuery;
            txt_count.Text = cashesQuery.Count().ToString();
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            //this.Dispatcher.Invoke(() =>
            //{
                //await Task.Run(FN_ExportToExcel);
                //var result = await SimLongRunningProcessAsync();
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            //});
           
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
            TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
            TextBox dpDateCheque = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDateCheque);


            switch (cb_paymentProcessType.SelectedIndex)
            {

                case 0://cash
                    grid_document.Visibility = Visibility.Collapsed; tb_docNum.Clear();dp_docDate.SelectedDate = null;
                    grid_cheque.Visibility = Visibility.Collapsed; tb_docNumCheque.Clear(); dp_docDateCheque.SelectedDate = null;
                    cb_card.Visibility = Visibility.Collapsed;   cb_card.SelectedIndex = -1;
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    //SectionData.clearValidate(dpDate, p_errorDocDate);
                    SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                    //SectionData.clearValidate(dpDateCheque, p_errorDocDateCheque);
                    SectionData.clearComboBoxValidate(cb_card , p_errorCard);
                    break;

                case 1://doc
                    grid_document.Visibility = Visibility.Visible;
                    grid_cheque.Visibility = Visibility.Collapsed; tb_docNumCheque.Clear(); dp_docDateCheque.SelectedDate = null;
                    cb_card.Visibility = Visibility.Collapsed; cb_card.SelectedIndex = -1;
                    SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                    //SectionData.clearValidate(dpDateCheque, p_errorDocDateCheque);
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    break;
                case 2://cheque
                    grid_cheque.Visibility = Visibility.Visible;
                    grid_document.Visibility = Visibility.Collapsed; tb_docNum.Clear(); dp_docDate.SelectedDate = null;
                    cb_card.Visibility = Visibility.Collapsed; cb_card.SelectedIndex = -1;
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    //SectionData.clearValidate(dpDate, p_errorDocDate);
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    break;
                   
                case 3://card
                    grid_document.Visibility = Visibility.Collapsed; tb_docNum.Clear(); dp_docDate.SelectedDate = null;
                    grid_cheque.Visibility = Visibility.Collapsed; tb_docNum.Clear(); dp_docDate.SelectedDate = null;
                    cb_card.Visibility = Visibility.Visible ;
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    //SectionData.clearValidate(dpDate, p_errorDocDate);
                    SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                    //SectionData.clearValidate(dpDateCheque, p_errorDocDateCheque);
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
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocNum, tt_errorDocNum , "trEmptyDocDateToolTip");
                ///////////date
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

        private void Btn_pdf1_Click(object sender, RoutedEventArgs e)
        {
      
        }

        private  void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {if(cashtrans.cashTransId > 0 )
            {

            string addpath = @"\Reports\PayReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                int cashId = Int32.Parse(s);
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

        private void Btn_print_pay_Click(object sender, RoutedEventArgs e)
        {
            if (cashtrans.cashTransId > 0)
            {

                string addpath = @"\Reports\PayReport.rdlc";
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                int cashId = Int32.Parse(s);
                //MessageBox.Show(s);
                rep.ReportPath = reppath;
                rep.DataSources.Clear();
                rep.EnableExternalImages = true;
                rep.SetParameters(reportclass.fillPayReport(cashtrans));
                
                rep.Refresh();

                LocalReportExtensions.PrintToPrinter(rep);
            }
        }

        private async void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
            //Pos p = await posModel.getPosById(53);

            //p.balance = 100000;

            //await posModel.savePos(p);
            Bonds bond = new Bonds();
            bond.number = "xxx";
            bond.amount = 1000;
            bond.deserveDate = dp_docDate.SelectedDate.Value;
            bond.type = "p";
            bond.isRecieved = 0;
            bond.createUserId = MainWindow.userID.Value;
            bond.cashTransId = 127;

            string s = await bondModel.Save(bond);
            MessageBox.Show(s.ToString());
            //saveBond("xxx", 1000 , dp_docDate.SelectedDate.Value, "p", 127);

        }
    }
}

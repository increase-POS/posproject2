using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
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
        CashTransfer cashModel = new CashTransfer();
        CashTransfer cashtrans = new CashTransfer();
        IEnumerable<Agent> agents;
        IEnumerable<User> users;
        IEnumerable<CashTransfer> cashesQuery;
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
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_recipient, MainWindow.resourcemanager.GetString("trRecipientHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNum, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            dg_paymentsAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_paymentsAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trPosTooltip");
            dg_paymentsAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trOpperationTypeToolTip");
            dg_paymentsAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

            tt_depositTo.Content = MainWindow.resourcemanager.GetString("trDepositTo");
            tt_recepient.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            tt_paymentType.Content = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            tt_docNum.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
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

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            btn_image.Content = MainWindow.resourcemanager.GetString("trImage");
            btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            btn_printInvoice.Content = MainWindow.resourcemanager.GetString("trPrint");
            btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdf");

        }

        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {//confirm

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
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

            #region fill deposit to combo/////////???????????????
            var depositlist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trVendor")     , Value = "v" },
            new { Text = MainWindow.resourcemanager.GetString("trCustomer")   , Value = "c" },
            new { Text = MainWindow.resourcemanager.GetString("trUser")       , Value = "u" },
            new { Text = MainWindow.resourcemanager.GetString("trSalary")     , Value = "3" },///????
            new { Text = MainWindow.resourcemanager.GetString("trGeneralExpenses")     , Value = "4" },///????
            new { Text = MainWindow.resourcemanager.GetString("trAdministrativePull")  , Value = "5" }////????
             };
            cb_depositTo.DisplayMemberPath = "Text";
            cb_depositTo.SelectedValuePath = "Value";
            cb_depositTo.ItemsSource = depositlist;
            #endregion

            #region fill process type//////??????????????
            var typelist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trCash"), Value = "0" },
            new { Text = MainWindow.resourcemanager.GetString("trDocument")   , Value = "1" },
            new { Text = MainWindow.resourcemanager.GetString("trCheque")     , Value = "2" },
            new { Text = MainWindow.resourcemanager.GetString("trCreditCard") , Value = "3" },
             };
            cb_paymentProcessType.DisplayMemberPath = "Text";
            cb_paymentProcessType.SelectedValuePath = "Value";
            cb_paymentProcessType.ItemsSource = typelist;
            #endregion


            translate();
        }

        private void Dg_paymentsAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection

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
                //|| s.bankName.Contains(searchText)
                //|| s.docNum.Contains(searchText)////?????because of empty values
                )
                && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                );
            });
            RefreshCashView();
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
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
            if(cb_recipient.IsEnabled)
                SectionData.validateEmptyComboBox(cb_recipient, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
            else
            { SectionData.clearComboBoxValidate(cb_recipient, p_errorRecipient);  }
            //chk empty payment type
            SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

            if ( (!tb_cash.Text.Equals("")) && (!cb_depositTo.Text.Equals("")) && (!cb_paymentProcessType.Text.Equals("")) && 
                 (((cb_recipient.IsEnabled) && (!cb_recipient.Text.Equals(""))) || (!cb_recipient.IsEnabled)) &&
                 (((tb_docNum.IsEnabled) && (!tb_docNum.Text.Equals(""))) || (!tb_docNum.IsEnabled)) )
            {
                CashTransfer cash = new CashTransfer();
                cash.transType = "d";
                cash.posId = MainWindow.posID.Value;
                cash.transNum = await SectionData.generateNumber('d', cb_depositTo.SelectedValue.ToString());/////?????
                cash.cash = decimal.Parse(tb_cash.Text);
                cash.notes = tb_note.Text;
                cash.createUserId = MainWindow.userID;
                cash.side = cb_depositTo.SelectedValue.ToString();/////??????
                cash.docNum = tb_docNum.Text;
                /*
        public Nullable<int> userId { get; set; }/////?????
        public Nullable<int> agentId { get; set; }////????
        public Nullable<int> invId { get; set; }////????
        public Nullable<int> posIdCreator { get; set; }/////???
        public Nullable<byte> isConfirm { get; set; }/////?????
        public Nullable<int> cashTransIdSource { get; set; }/////????
        public string opSideNum { get; set; }/////????
        public string docName { get; set; }/////?????
        public string docImage { get; set; }///???
        public Nullable<int> bankId { get; set; }/////??

                 */

                string s = await cashModel.Save(cash);

                if (!s.Equals("0"))
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);

                    await RefreshCashesList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            //chk empty cash
            SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
            //chk empty doc num
            if (tb_docNum.IsEnabled)
                SectionData.validateEmptyTextBox(tb_docNum, p_errorDocNum, tt_errorDocNum, "trEmptyDocNumToolTip");
            else
                SectionData.clearValidate(tb_docNum, p_errorDocNum);
            //chk empty deposit to
            SectionData.validateEmptyComboBox(cb_depositTo, p_errorDepositTo, tt_errorDepositTo, "trErrorEmptyDepositToToolTip");
            //chk empty recipient
            if (cb_recipient.IsEnabled)
                SectionData.validateEmptyComboBox(cb_recipient, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
            else
            { SectionData.clearComboBoxValidate(cb_recipient, p_errorRecipient); }
            //chk empty payment type
            SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

            if ((!tb_cash.Text.Equals("")) && (!cb_depositTo.Text.Equals("")) && (!cb_paymentProcessType.Text.Equals("")) &&
                 (((cb_recipient.IsEnabled) && (!cb_recipient.Text.Equals(""))) || (!cb_recipient.IsEnabled)) &&
                 (((tb_docNum.IsEnabled) && (!tb_docNum.Text.Equals(""))) || (!tb_docNum.IsEnabled)))
            {
                CashTransfer cash = new CashTransfer();
                cash.transType = "d";
                cash.posId = MainWindow.posID.Value;
                cash.transNum = await SectionData.generateNumber('d', cb_depositTo.SelectedValue.ToString());/////?????
                cash.cash = decimal.Parse(tb_cash.Text);
                cash.notes = tb_note.Text;
                cash.createUserId = MainWindow.userID;
                cash.side = cb_depositTo.SelectedValue.ToString();/////??????
                cash.docNum = tb_docNum.Text;
                /*
        public Nullable<int> userId { get; set; }/////?????
        public Nullable<int> agentId { get; set; }////????
        public Nullable<int> invId { get; set; }////????
        public Nullable<int> posIdCreator { get; set; }/////???
        public Nullable<byte> isConfirm { get; set; }/////?????
        public Nullable<int> cashTransIdSource { get; set; }/////????
        public string opSideNum { get; set; }/////????
        public string docName { get; set; }/////?????
        public string docImage { get; set; }///???
        public Nullable<int> bankId { get; set; }/////??

                 */

                string s = await cashModel.Save(cash);

                if (!s.Equals("0"))
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);

                    await RefreshCashesList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if (cashtrans.cashTransId != 0)
            {////////method for delete cash//////?????????????????????????????????
                //string b = await cashModel.deletePosTrans(cashtrans.cashTransId);

                //if (b == "1")
                //{
                //    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopDelete"), animation: ToasterAnimation.FadeIn);
                //    //clear textBoxs
                //    Btn_clear_Click(sender, e);
                //}
                //else if (b == "0")
                //    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopCanNotDeleteRequest"), animation: ToasterAnimation.FadeIn);
                //else
                //    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                //await RefreshCashesList();
                //Tb_search_TextChanged(null, null);
            }
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_transNum.Text = "";
            cb_depositTo.SelectedIndex = -1;
            cb_recipient.SelectedIndex = -1;
            cb_paymentProcessType.SelectedIndex = -1;
            tb_docNum.Clear();
            tb_cash.Clear();
            tb_note.Clear();
            cb_recipient.IsEnabled = true;
            tb_docNum.IsEnabled = true;

            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearComboBoxValidate(cb_depositTo, p_errorDepositTo);
            SectionData.clearComboBoxValidate(cb_recipient, p_errorRecipient);
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);

        }

        async Task<IEnumerable<CashTransfer>> RefreshCashesList()
        {
            cashes = await cashModel.GetCashTransferAsync("d", "bn");///////??????????????
            return cashes;
        }

        void RefreshCashView()
        {
            dg_paymentsAccounts.ItemsSource = cashesQuery;
            txt_count.Text = cashesQuery.Count().ToString();
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export

        }

        private void Btn_image_Click(object sender, RoutedEventArgs e)
        {//image

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
                case 0:
                case 3: tb_docNum.IsEnabled = false; SectionData.clearValidate(tb_docNum , p_errorDocNum);
                    break;
                case 1:
                case 2: tb_docNum.IsEnabled = true;
                    break;
            }
        }

        private void Cb_depositTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//deposit selection
            switch(cb_depositTo.SelectedIndex)
            {
                case 0: cb_recipient.IsEnabled = true; fillVendors(); break;
                case 1: cb_recipient.IsEnabled = true; fillCustomers(); break;
                case 2:  
                case 3: cb_recipient.IsEnabled = true; fillUsers();
                    break;
                case 4: 
                case 5:cb_recipient.IsEnabled = false; cb_recipient.SelectedIndex = -1; SectionData.clearComboBoxValidate(cb_recipient , p_errorRecipient);
                    break;
            }
        }

        private async void fillVendors()
        {
            agents = await agentModel.GetAgentsActive("v");

            cb_recipient.ItemsSource = agents;
            cb_recipient.DisplayMemberPath = "name";
            cb_recipient.SelectedValuePath = "agentId";
            cb_recipient.SelectedIndex = -1;
        }

        private async void fillCustomers()
        {
            agents = await agentModel.GetAgentsActive("c");

            cb_recipient.ItemsSource = agents;
            cb_recipient.DisplayMemberPath = "name";
            cb_recipient.SelectedValuePath = "agentId";
            cb_recipient.SelectedIndex = -1;
        }

        private async void fillUsers()
        {
            users = await userModel.GetUsersActive();

            cb_recipient.ItemsSource = users;
            cb_recipient.DisplayMemberPath = "name";
            cb_recipient.SelectedValuePath = "userId";
            cb_recipient.SelectedIndex = -1;
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
                else if ((sender as ComboBox).Name == "cb_recipient")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
                else if ((sender as ComboBox).Name == "cb_paymentProcessType")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
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

using netoaster;
using POS.Classes;
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
    /// Interaction logic for uc_banksAccounts.xaml
    /// </summary>
    public partial class uc_banksAccounts : UserControl
    {
        CashTransfer cashtrans = new CashTransfer();
        CashTransfer cashModel = new CashTransfer();
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashes;
        string searchText = "";

        User userModel = new User();
        IEnumerable<User> users;

        Branch branchModel = new Branch();
        IEnumerable<Branch> branches;

        Bank bankModel = new Bank();
        IEnumerable<Bank> banksQuery;
        IEnumerable<Bank> banks;

        BrushConverter bc = new BrushConverter();

        private static uc_banksAccounts _instance;
        public static uc_banksAccounts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_banksAccounts();
                return _instance;
            }
        }

        public uc_banksAccounts()
        {
            InitializeComponent();
        }

        private void translate()
        {
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trTransaferDetails");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_depositNumber, MainWindow.resourcemanager.GetString("trDepositeNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_opperationType, MainWindow.resourcemanager.GetString("trOpperationTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_user, MainWindow.resourcemanager.GetString("trUserHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_bank, MainWindow.resourcemanager.GetString("trBankHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            if (cb_opperationType.SelectedValue == "d")
                btn_add.Content = MainWindow.resourcemanager.GetString("trDeposit");
            else
                btn_add.Content = MainWindow.resourcemanager.GetString("trPull");

            dg_bankAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_bankAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trBank");
            dg_bankAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trDepositeNumTooltip");
            dg_bankAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trCash");

            tt_opperationType.Content = MainWindow.resourcemanager.GetString("trOpperationTypeToolTip");
            tt_user.Content = MainWindow.resourcemanager.GetString("trUser");
            tt_bank.Content = MainWindow.resourcemanager.GetString("trBank");
            tt_cash.Content = MainWindow.resourcemanager.GetString("trCashTooltip");
            tt_user.Content = MainWindow.resourcemanager.GetString("trUser");
            tt_DepREcNum.Content = MainWindow.resourcemanager.GetString("trDepositeNumTooltip");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

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

            btn_add.IsEnabled = true;
            dp_endSearchDate.SelectedDate = DateTime.Now;
            dp_startSearchDate.SelectedDate = DateTime.Now;

            #region fill operation type
            var dislist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trDeposit"), Value = "d" },
            new { Text = MainWindow.resourcemanager.GetString("trPull"), Value = "p" },
             };

            cb_opperationType.DisplayMemberPath = "Text";
            cb_opperationType.SelectedValuePath = "Value";
            cb_opperationType.ItemsSource = dislist;
            #endregion

            #region fill users combo
            users = await userModel.GetUsersActive();
            cb_user.ItemsSource = users;
            cb_user.DisplayMemberPath = "username";
            cb_user.SelectedValuePath = "userId";
            cb_user.SelectedIndex = -1;
            #endregion

            #region fill banks combo
            banks = await bankModel.GetBanksAsync();
            banksQuery = banks.Where(s => s.isActive == 1);
            cb_bank.ItemsSource = banksQuery;
            cb_bank.DisplayMemberPath = "name";
            cb_bank.SelectedValuePath = "bankId";
            cb_bank.SelectedIndex = -1;
            #endregion

            #region translate

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucBankAccounts.FlowDirection = FlowDirection.LeftToRight;

            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucBankAccounts.FlowDirection = FlowDirection.RightToLeft;

            }

            translate();
            #endregion

            #region Style Date
            /////////////////////////////////////////////////////////////
            SectionData.defaultDatePickerStyle(dp_startSearchDate);
            SectionData.defaultDatePickerStyle(dp_endSearchDate);
            /////////////////////////////////////////////////////////////
            #endregion

            //#region prevent editting on date and time
            //TextBox tbStartDate = (TextBox)dp_startSearchDate.Template.FindName("PART_TextBox", dp_startSearchDate);
            //tbStartDate.IsReadOnly = true;
            //TextBox tbEndDate = (TextBox)dp_endSearchDate.Template.FindName("PART_TextBox", dp_endSearchDate);
            //tbEndDate.IsReadOnly = true;
            //#endregion

            dg_bankAccounts.ItemsSource = await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }

        private async void Dg_bankAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            btn_add.IsEnabled = false;
            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearValidate(tb_depositNumber, p_errorDepositNumber);
            SectionData.clearComboBoxValidate(cb_opperationType, p_errorOpperationType);
            SectionData.clearComboBoxValidate(cb_user, p_errorUser);
            SectionData.clearComboBoxValidate(cb_bank, p_errorBank);
            if (dg_bankAccounts.SelectedIndex != -1)
            {
                cashtrans = dg_bankAccounts.SelectedItem as CashTransfer;
                this.DataContext = cashtrans;

                if (cashtrans != null)
                {
                    cb_opperationType.SelectedValue = cashtrans.transType;
                    cb_user.SelectedValue = cashtrans.userId;
                    cb_bank.SelectedValue = cashtrans.bankId;

                }
            }
        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            if (cashes is null)
                await RefreshCashesList();
            searchText = tb_search.Text;
            cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText))
            //|| s.docNum.Contains(searchText)
            //&& (s.createDate >= dp_startSearchDate.SelectedDate && s.createDate <= dp_endSearchDate.SelectedDate)
                );
            RefreshCashView();
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//save
            //chk empty cash
            SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
            //chk empty deposite number
            SectionData.validateEmptyTextBox(tb_depositNumber, p_errorDepositNumber, tt_errorDepositNumber, "trEmptyDepositNumberToolTip");
            //chk empty dicount type
            SectionData.validateEmptyComboBox(cb_opperationType, p_errorOpperationType, tt_errorOpperationType, "trErrorEmptyOpperationTypeToolTip");
            //chk empty user
            SectionData.validateEmptyComboBox(cb_user, p_errorUser, tt_errorUser, "trErrorEmptyUserToolTip");
            //chk empty bank
            SectionData.validateEmptyComboBox(cb_bank, p_errorBank, tt_errorBank, "trErrorEmptyBankToolTip");

            if ((!tb_cash.Text.Equals("")) && (!tb_depositNumber.Text.Equals("")) &&
                (!cb_opperationType.Text.Equals("")) && (!cb_user.Text.Equals("")) &&
                (!cb_bank.Text.Equals("")))
             {

                CashTransfer cash = new CashTransfer();
                cash.transType = cb_opperationType.SelectedValue.ToString();
                cash.posIdCreator = MainWindow.posID.Value;
                cash.userId = Convert.ToInt32(cb_user.SelectedValue);
                //cash.transNum = await generateNumber();
                cash.transNum = await SectionData.generateNumber(Convert.ToChar(cb_opperationType.SelectedValue), "bn");
                cash.cash = decimal.Parse(tb_cash.Text);
                cash.createUserId = MainWindow.userID.Value;
                cash.notes = tb_note.Text;
                cash.posId = MainWindow.posID.Value;///////////?????????????
                cash.side = "bn";
                cash.bankId = Convert.ToInt32(cb_bank.SelectedValue);
                cash.docNum = tb_depositNumber.Text;

                string s = await cashModel.Save(cash);
              
                if (!s.Equals("0"))
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);

                    dg_bankAccounts.ItemsSource = await RefreshCashesList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            btn_add.IsEnabled = true;

            tb_cash.Clear();
            tb_depositNumber.Clear();
            cb_opperationType.SelectedIndex = -1;
            cb_bank.SelectedIndex = -1;
            cb_user.SelectedIndex = -1;
            tb_note.Clear();

            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearValidate(tb_depositNumber, p_errorDepositNumber);
            SectionData.clearComboBoxValidate(cb_opperationType, p_errorOpperationType);
            SectionData.clearComboBoxValidate(cb_user, p_errorUser);
            SectionData.clearComboBoxValidate(cb_bank, p_errorBank);

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
            var QueryExcel = cashesQuery.AsEnumerable().Select(x => new
            {
                Tranfer_Number = x.transNum,
                Bank = x.bankId,
                DipRecNum = x.docNum,
                Cash = x.cash
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trTransferNum");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trBank");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trDepositeReceiptNum");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trCash");

            ExportToExcel.Export(DTForExcel);
        }

        private void Btn_image_Click(object sender, RoutedEventArgs e)
        {//image

        }

        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }

        private void PreventSpaces(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_cash_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { //only decimal
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;

            else
                e.Handled = true;

        }

        private void Tb_depositNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only int
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        //private async Task<string> generateNumber()
        //{
        //    Branch b = new Branch();
        //    b = await branchModel.getBranchById(MainWindow.branchID.Value);
        //    string str1 = b.code;

        //    string str2 = "";
        //    if (Convert.ToChar(cb_opperationType.SelectedValue) == 'd') str2 = "db";
        //    else str2 = "pb";

        //    string str3 = "";
        //    CashTransfer c = new CashTransfer();
        //    cashes = await cashModel.GetCashTransferAsync(Convert.ToString(cb_opperationType.SelectedValue), "bn");
        //    str3 = cashes.Count().ToString();

        //    return str1 + str2 + str3;
        //}

        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_cash")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
                else if ((sender as TextBox).Name == "tb_depositNumber")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDepositNumber, tt_errorDepositNumber, "trEmptyDepositeNumberToolTip");
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_opperationType")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorOpperationType, tt_errorOpperationType, "trErrorEmptyOpperationTypeToolTip");
                else if ((sender as ComboBox).Name == "cb_user")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorUser, tt_errorUser, "trErrorEmptyUserToolTip");
                else if ((sender as ComboBox).Name == "cb_bank")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorBank, tt_errorBank, "trErrorEmptyBankToolTip");
            }
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

        async Task<IEnumerable<CashTransfer>> RefreshCashesList()
        {
            cashes = await cashModel.GetCashTransferAsync("all","bn");
            //MessageBox.Show(cashes.Count().ToString());
            return cashes;
        }
        void RefreshCashView()
        {
            dg_bankAccounts.ItemsSource = cashesQuery;
            txt_count.Text = cashesQuery.Count().ToString();
        }

        private void OnlyInt(object sender, TextCompositionEventArgs e)
        {
            //only int
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void Cb_opperationType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_opperationType.SelectedValue == "d")
                btn_add.Content = MainWindow.resourcemanager.GetString("trDeposit");
            else
                btn_add.Content = MainWindow.resourcemanager.GetString("trPull");
        }
    }
}

﻿using netoaster;
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
    /// Interaction logic for uc_receivedAccounts.xaml
    /// </summary>
    public partial class uc_receivedAccounts : UserControl
    {
        private static uc_receivedAccounts _instance;

        CashTransfer cashModel = new CashTransfer();
        CashTransfer cashtrans = new CashTransfer();

        Agent agentModel = new Agent();
        User userModel = new User();

        IEnumerable<Agent> agents;
        IEnumerable<User> users;

        IEnumerable<Card> cards;
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashesQueryExcel;
        IEnumerable<CashTransfer> cashes;

        string searchText = "";
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

            #region fill deposit from combo
            var depositlist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trVendor")     , Value = "v" },
            new { Text = MainWindow.resourcemanager.GetString("trCustomer")   , Value = "c" },
            new { Text = MainWindow.resourcemanager.GetString("trUser")       , Value = "u" },
            new { Text = MainWindow.resourcemanager.GetString("trAdministrativeDeposit")  , Value = "m" }
             };
            cb_depositFrom.DisplayMemberPath = "Text";
            cb_depositFrom.SelectedValuePath = "Value";
            cb_depositFrom.ItemsSource = depositlist;
            #endregion

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
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositFrom, MainWindow.resourcemanager.GetString("trDepositFromHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositor, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNum, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_card, MainWindow.resourcemanager.GetString("trCard"));

            dg_receivedAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_receivedAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trDepositTo");
            dg_receivedAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trRecepient");
            dg_receivedAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            //dg_receivedAccounts.Columns[4].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

            //tt_depositTo.Content = MainWindow.resourcemanager.GetString("trDepositTo");
            //tt_recepient.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            //tt_paymentType.Content = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            //tt_docNum.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            //tt_card.Content = MainWindow.resourcemanager.GetString("trCardTooltip");
            //tt_cash.Content = MainWindow.resourcemanager.GetString("trCashTooltip");
            //tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            //tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");

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
            SectionData.clearComboBoxValidate(cb_depositor, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorpaymentProcessType);
            TextBox tbDocDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
            SectionData.clearValidate(tbDocDate, p_errorDocDate);
            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_cash, p_errorCash);

            if (dg_receivedAccounts.SelectedIndex != -1)
            {
                cashtrans = dg_receivedAccounts.SelectedItem as CashTransfer;
                this.DataContext = cashtrans;

                if (cashtrans != null)
                {
                    cb_depositFrom.SelectedValue = cashtrans.side;

                    MessageBox.Show(cashtrans.agentId.ToString() + " - " + cashtrans.userId.ToString());

                    switch (cb_depositFrom.SelectedValue.ToString())
                    {
                        case "v":
                        case "c":
                            cb_depositor.SelectedValue = cashtrans.agentId.Value;
                            break;
                        case "u":
                            cb_depositor.SelectedValue = cashtrans.userId.Value;
                            break;
                        case "m":
                            cb_depositor.IsEnabled = false;
                            cb_depositor.Text = "";
                            SectionData.clearComboBoxValidate(cb_depositor, p_errordepositor);
                            break;
                    }

                    cb_paymentProcessType.SelectedValue = cashtrans.processType;

                    //cb_card.SelectedValue = cashtrans.cardId;

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
                && (s.side == "v" || s.side == "c" || s.side == "u" ||  s.side == "m")
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
         //chk empty cash
            SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");

            //chk empty doc num
            if (tb_docNum.IsEnabled)
                SectionData.validateEmptyTextBox(tb_docNum, p_errorDocNum, tt_errorDocNum, "trEmptyDocNumToolTip");
            else
                SectionData.clearValidate(tb_docNum, p_errorDocNum);

            //chk empty deposit from
            SectionData.validateEmptyComboBox(cb_depositFrom, p_errorDepositFrom, tt_errorDepositFrom, "trErrorEmptyDepositFRomToolTip");

            //chk empty depositor
            if (cb_depositor.IsEnabled)
                SectionData.validateEmptyComboBox(cb_depositor, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
            else
                SectionData.clearComboBoxValidate(cb_depositor, p_errordepositor);

            //chk empty payment type
            SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

            //chk empty card 
            if (cb_card.IsEnabled)
                SectionData.validateEmptyComboBox(cb_card, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
            else
                SectionData.clearComboBoxValidate(cb_card, p_errorCard);

            if ((!tb_cash.Text.Equals("")) && (!cb_depositFrom.Text.Equals("")) && (!cb_paymentProcessType.Text.Equals("")) &&
                 (((cb_depositor.IsEnabled) && (!cb_depositor.Text.Equals(""))) || (!cb_depositor.IsEnabled)) &&
                 (((tb_docNum.IsEnabled) && (!tb_docNum.Text.Equals(""))) || (!tb_docNum.IsEnabled)) 
                 &&
                 (((cb_card.IsEnabled) && (!cb_card.Text.Equals(""))) || (!cb_card.IsEnabled))
                 )
            {
                CashTransfer cash = new CashTransfer();
                cash.transType = "d";
                cash.posId = MainWindow.posID.Value;
                cash.transNum = await SectionData.generateNumber('d', cb_depositFrom.SelectedValue.ToString());
                cash.cash = decimal.Parse(tb_cash.Text);
                cash.notes = tb_note.Text;
                cash.createUserId = MainWindow.userID;
                cash.side = cb_depositFrom.SelectedValue.ToString();
                cash.docNum = tb_docNum.Text;
                cash.processType = cb_paymentProcessType.SelectedValue.ToString();

                if ((cb_depositFrom.SelectedValue == "v") || (cb_depositFrom.SelectedValue == "c"))
                    cash.agentId = Convert.ToInt32(cb_depositor.SelectedValue);

                if (cb_depositFrom.SelectedValue == "u") 
                    cash.userId = Convert.ToInt32(cb_depositor.SelectedValue);

                if (cb_paymentProcessType.SelectedValue.ToString().Equals("card"))
                    cash.cardId = Convert.ToInt32(cb_card.SelectedValue);

                string s = await cashModel.Save(cash);

                if (!s.Equals("0"))
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);

                    //decimal ammount = cash.cash.Value;
                    //if (cash.transType.Equals("p")) ammount *= -1;
                    //calcBalance(ammount);

                    //dg_receivedAccounts.ItemsSource = await cashModel.GetCashTransferAsync("d", "v");
                    await RefreshCashesList();
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
            cb_depositFrom.SelectedIndex = -1;
            cb_depositor.SelectedIndex = -1;
            cb_paymentProcessType.SelectedIndex = -1;
            dp_docDate.SelectedDate = null;
            tb_docNum.Clear();
            tb_cash.Clear();
            tb_note.Clear();

            SectionData.clearComboBoxValidate(cb_depositFrom , p_errorDepositFrom);
            SectionData.clearComboBoxValidate(cb_depositor,    p_errordepositor);
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            TextBox tbDocDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
            SectionData.clearValidate(tbDocDate, p_errorDocDate);
            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_cash, p_errorCash);

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
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_depositFrom")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorDepositFrom, tt_errorDepositFrom, "trErrorEmptyDepositFromToolTip");
                else if ((sender as ComboBox).Name == "cb_depositor")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                else if ((sender as ComboBox).Name == "cb_paymentProcessType")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                //else if (name == "DatePicker")
                //{
                //    if ((sender as DatePicker).Name == "dp_docDate")
                //        SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorDocDate, tt_errorStartDate, "trErrorEmptyStartDateToolTip");
                //}
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
                    //tb_docNum.IsEnabled = false; tb_docNum.Clear();
                    //dp_docDate.IsEnabled = false; dp_docDate.SelectedDate = null;
                    tb_docNum.Visibility = Visibility.Collapsed;
                    dp_docDate.Visibility = Visibility.Collapsed;
                    //cb_card.IsEnabled = false; cb_card.SelectedIndex = -1;
                    cb_card.Visibility = Visibility.Collapsed;
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    break;

                case 1://doc

                case 2://cheque
                    //tb_docNum.IsEnabled = true; dp_docDate.IsEnabled = true;
                    tb_docNum.Visibility = Visibility.Visible; dp_docDate.Visibility = Visibility.Visible; ;
                    //cb_card.IsEnabled = false; cb_card.SelectedIndex = -1;
                    cb_card.Visibility = Visibility.Collapsed;
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    break;

                case 3://card
                    //tb_docNum.IsEnabled = false; tb_docNum.Clear();
                    tb_docNum.Visibility = Visibility.Collapsed;
                    dp_docDate.Visibility = Visibility.Collapsed;
                    //cb_card.IsEnabled = true;
                    cb_card.Visibility = Visibility.Visible;
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                    break;
            }

        }

        private void Cb_depositFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//deposit selection
            switch (cb_depositFrom.SelectedIndex)
            {
                case 0: cb_depositor.Visibility = Visibility.Visible;  fillVendors(); break;
                case 1: cb_depositor.Visibility = Visibility.Visible; fillCustomers(); break;
                case 2: cb_depositor.Visibility = Visibility.Visible; fillUsers(); break;
                case 3:
                    cb_depositor.Visibility = Visibility.Collapsed;
                    SectionData.clearComboBoxValidate(cb_depositor, p_errordepositor);
                        cb_depositor.Text = "";
                    break;
            }
        }

        private async void fillVendors()
        {
            agents = await agentModel.GetAgentsActive("v");

            cb_depositor.ItemsSource = agents;
            cb_depositor.DisplayMemberPath = "name";
            cb_depositor.SelectedValuePath = "agentId";
            //cb_recipient.SelectedIndex = -1;
        }

        private async void fillCustomers()
        {
            agents = await agentModel.GetAgentsActive("c");

            cb_depositor.ItemsSource = agents;
            cb_depositor.DisplayMemberPath = "name";
            cb_depositor.SelectedValuePath = "agentId";
            //cb_recipient.SelectedIndex = -1;
        }

        private async void fillUsers()
        {
            users = await userModel.GetUsersActive();

            cb_depositor.ItemsSource = users;
            cb_depositor.DisplayMemberPath = "name";
            cb_depositor.SelectedValuePath = "userId";
            //cb_recipient.SelectedIndex = -1;
        }
    }
}

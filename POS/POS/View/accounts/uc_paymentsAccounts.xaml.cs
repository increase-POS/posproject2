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
        ShippingCompanies shCompanyModel = new ShippingCompanies();
        Card cardModel = new Card();
        Bonds bondModel = new Bonds();
        Pos posModel = new Pos();
        CashTransfer cashModel = new CashTransfer();
        CashTransfer cashtrans = new CashTransfer();

        IEnumerable<Agent> agents;
        IEnumerable<User> users;
        IEnumerable<ShippingCompanies> shCompanies;
        IEnumerable<Card> cards;
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashesQueryExcel;

        IEnumerable<CashTransfer> cashes;

        string searchText = "";
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        public List<Invoice> invoicesLst = new List<Invoice>();

        string  createPermission = "payments_create";
        string reportsPermission = "payments_reports";
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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
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
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_recipientSh, MainWindow.resourcemanager.GetString("trRecipientHint"));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_card, MainWindow.resourcemanager.GetString("trCardHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNum, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNumCheque, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNumCard, MainWindow.resourcemanager.GetString("trProcessNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_docDate, MainWindow.resourcemanager.GetString("trDocDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            dg_paymentsAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_paymentsAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trRecepient");
            dg_paymentsAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            dg_paymentsAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

            //tt_depositTo.Content = MainWindow.resourcemanager.GetString("trDepositTo");
            //tt_recepientV.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            //tt_recepientC.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            //tt_recepientU.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            //tt_recepientSh.Content = MainWindow.resourcemanager.GetString("trShippingCompany");

            //tt_paymentType.Content = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            //tt_docNum.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            //tt_docDate.Content = MainWindow.resourcemanager.GetString("trDocDateTooltip");
            //tt_docNumCheque.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            //tt_docNumCard.Content = MainWindow.resourcemanager.GetString("trProcessNumTooltip");

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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                #region translate
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
            translate();
            #endregion

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
                new { Text = MainWindow.resourcemanager.GetString("trAdministrativePull")  , Value = "m" },
                new { Text = MainWindow.resourcemanager.GetString("trShippingCompanies")  , Value = "sh" }
                 };
                cb_depositTo.DisplayMemberPath = "Text";
                cb_depositTo.SelectedValuePath = "Value";
                cb_depositTo.ItemsSource = depositlist;
                #endregion

                await fillVendors();

                await fillCustomers();

                await fillUsers();

                await fillShippingCompanies();

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

                btn_image.IsEnabled = false;

                await RefreshCashesList();
                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async void dp_SelectedStartDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                await RefreshCashesList();
                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async void dp_SelectedEndDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                await RefreshCashesList();
                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private  void Dg_paymentsAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

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
                SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
                SectionData.clearComboBoxValidate(cb_card, p_errorCard);

                if (dg_paymentsAccounts.SelectedIndex != -1)
                {
                    cashtrans = dg_paymentsAccounts.SelectedItem as CashTransfer;
                    this.DataContext = cashtrans;

                    if (cashtrans != null)
                    {
                        btn_image.IsEnabled = true;

                        cb_depositTo.SelectedValue = cashtrans.side;
                        ///////////////////////////
                        btn_add.IsEnabled = false;
                        cb_depositTo.IsEnabled = false;
                        cb_recipientV.IsEnabled = false;
                        cb_recipientC.IsEnabled = false;
                        cb_recipientU.IsEnabled = false;
                        cb_recipientSh.IsEnabled = false;
                        cb_paymentProcessType.IsEnabled = false;
                        tb_docNum.IsEnabled = false;
                        dp_docDate.IsEnabled = false;
                        tb_docNumCheque.IsEnabled = false;
                        dp_docDateCheque.IsEnabled = false;
                        tb_docNumCard.IsEnabled = false;
                        cb_card.IsEnabled = false;
                        tb_cash.IsEnabled = false;
                        tb_note.IsEnabled = false;
                        /////////////////////////
                        switch (cb_depositTo.SelectedValue.ToString())
                        {
                            case "v":
                                cb_recipientV.SelectedIndex = -1;
                                cb_recipientV.SelectedValue = cashtrans.agentId.Value;
                                cb_recipientC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                                cb_recipientU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                                cb_recipientSh.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                                break;
                            case "c":
                                cb_recipientC.SelectedIndex = -1;
                                cb_recipientC.SelectedValue = cashtrans.agentId.Value;
                                cb_recipientV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                                cb_recipientU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                                cb_recipientSh.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                                break;
                            case "u":
                            case "s":
                                cb_recipientU.SelectedIndex = -1;
                                cb_recipientU.SelectedValue = cashtrans.userId.Value;
                                cb_recipientV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                                cb_recipientC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                                cb_recipientSh.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                                break;
                            case "sh":
                                cb_recipientSh.SelectedIndex = -1;
                                cb_recipientSh.SelectedValue = cashtrans.shippingCompanyId.Value;
                                cb_recipientC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                                cb_recipientV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                                cb_recipientU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                                break;
                            case "e":
                            case "m":
                                cb_recipientV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                                cb_recipientC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                                cb_recipientU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                                cb_recipientSh.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                                break;
                        }

                        tb_transNum.Text = cashtrans.transNum;

                        cb_paymentProcessType.SelectedValue = cashtrans.processType;

                        cb_card.SelectedValue = cashtrans.cardId;

                        dp_docDate.SelectedDate = cashtrans.bondDeserveDate;
                    }
                }

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                if (cashes is null)
                await RefreshCashesList();

                this.Dispatcher.Invoke(() =>
                {
                    searchText = tb_search.Text.ToLower();
                    cashesQuery = cashes.Where(s => (s.transNum.ToLower().Contains(searchText)
                    || s.cash.ToString().ToLower().Contains(searchText)
                    )
                    && (s.side == "v" || s.side == "c" || s.side == "u" || s.side == "s" || s.side == "e" || s.side == "m" || s.side == "sh")
                    && s.transType == "p" 
                    && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                    && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                    );

                });

                cashesQueryExcel = cashesQuery;
                RefreshCashView();

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        string s = "0", s1 = "false";
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);
                s = "0"; s1 = "";
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region validate
                    //chk empty cash
                    SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");

                    //chk empty doc date
                    TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);

                    if (grid_document.IsVisible)
                    {
                        SectionData.validateEmptyTextBox(dpDate, p_errorDocDate, tt_errorDocDate, "trEmptyDocDateToolTip");
                    }
                    else
                    {
                 
                    }
                    //chk empty doc num
                    if (grid_cheque.IsVisible)
                    {
                        SectionData.validateEmptyTextBox(tb_docNumCheque, p_errorDocNumCheque, tt_errorDocNumCheque, "trEmptyDocNumToolTip");
                    }
                    else
                    {
                        SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                    }
                    //chk empty process num
                    if (tb_docNumCard.IsVisible)
                    {
                        SectionData.validateEmptyTextBox(tb_docNumCard, p_errorDocCard, tt_docNumCard , "trEmptyProcessNumToolTip");
                    }
                    else
                    {
                        SectionData.clearValidate(tb_docNumCard , p_errorDocCard);
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

                    if (cb_recipientSh.IsVisible)
                        SectionData.validateEmptyComboBox(cb_recipientSh, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
                    else
                        SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);

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
                    //chk enough money
                    bool enoughMoney = true;
                    if ((!cb_paymentProcessType.Text.Equals("")) && (cb_paymentProcessType.SelectedValue.ToString().Equals("cash")) &&
                        (!await chkEnoughBalance(decimal.Parse(tb_cash.Text))))
                    {
                        enoughMoney = false;
                        SectionData.showTextBoxValidate(tb_cash, p_errorCash , tt_errorCash, "trPopNotEnoughBalance");
                    }
                    #endregion

                    #region save

                    if ((!tb_cash.Text.Equals("")) && (!cb_depositTo.Text.Equals("")) && (!cb_paymentProcessType.Text.Equals("")) &&
                         (((cb_recipientV.IsVisible) && (!cb_recipientV.Text.Equals(""))) || (!cb_recipientV.IsVisible)) &&
                         (((cb_recipientC.IsVisible) && (!cb_recipientC.Text.Equals(""))) || (!cb_recipientC.IsVisible)) &&
                         (((cb_recipientU.IsVisible) && (!cb_recipientU.Text.Equals(""))) || (!cb_recipientU.IsVisible)) &&
                         (((cb_recipientSh.IsVisible) && (!cb_recipientSh.Text.Equals(""))) || (!cb_recipientSh.IsVisible)) &&
                         (((tb_docNumCheque.IsVisible) && (!tb_docNumCheque.Text.Equals(""))) || (!tb_docNumCheque.IsVisible)) &&
                         (((dp_docDate.IsVisible) && (!dp_docDate.Text.Equals(""))) || (!dp_docDate.IsVisible)) &&
                         (((cb_card.IsVisible) && (!cb_card.Text.Equals(""))) || (!cb_card.IsVisible)) &&
                         (((tb_docNumCard.IsVisible) && (!tb_docNumCard.Text.Equals(""))) || (!tb_docNumCard.IsVisible)) &&
                          enoughMoney
                         )
                    {
                        string recipient = cb_depositTo.SelectedValue.ToString();
                        int agentid = 0;

                        CashTransfer cash = new CashTransfer();

                        cash.transType = "p";
                        cash.posId = MainWindow.posID.Value;
                        cash.transNum = await cashModel.generateCashNumber(cash.transType+ cb_depositTo.SelectedValue.ToString());
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

                        if (cb_recipientSh.IsVisible)
                            cash.shippingCompanyId = Convert.ToInt32(cb_recipientSh.SelectedValue);

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
                            string res = await saveBond(cash.docNum, cash.cash.Value, dp_docDate.SelectedDate.Value, "p");
                            cash.bondId = int.Parse(res);
                        }
                        if (cb_recipientV.IsVisible || cb_recipientC.IsVisible)
                        {
                            if (tb_cash.IsReadOnly)
                                s1 = await cashModel.PayListOfInvoices(cash.agentId.Value, invoicesLst, "pay", cash);
                            else
                                s1 = await cashModel.PayByAmmount(cash.agentId.Value, decimal.Parse(tb_cash.Text), "pay", cash);
                        }
                        else
                            s = await cashModel.Save(cash);

                        if ((!s.Equals("0")) || (!s1.Equals("")) || (s1.Equals("-1")))
                        {
                            if(cb_paymentProcessType.SelectedValue.ToString().Equals("cash"))
                              await  calcBalance(cash.cash.Value, recipient, agentid);

                            if ((cb_recipientU.IsVisible) && (cash.side == "u"))
                                await calcUserBalance(Convert.ToSingle(cash.cash.Value), cash.userId.Value);

                            if (cb_recipientSh.IsVisible)
                                await calcShippingComBalance(cash.cash.Value, cash.shippingCompanyId.Value);

                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                            Btn_clear_Click(null, null);

                            await RefreshCashesList();
                            Tb_search_TextChanged(null, null);
                        }
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);


                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async Task<bool> chkEnoughBalance(decimal ammount)
        {
            Pos pos = await posModel.getPosById(MainWindow.posID.Value);
            if (pos.balance.Value >= ammount)
            { return true; }
            else { return false; }
        }

        private async Task<string> saveBond(string num, decimal ammount, Nullable <DateTime> date, string type)
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

        private async Task calcBalance(decimal ammount, string recipient, int agentid)
        {//balance for pos
            int s = 0;
            //increase pos balance
            Pos pos = await posModel.getPosById(MainWindow.posID.Value);

            pos.balance -= ammount;

            s = await pos.savePos(pos);
        }

        private async Task calcUserBalance(float value, int userId)
        {//balance for user
            User user = await userModel.getUserById(userId);

            if (user.balanceType == 0)
            {
                if (value > user.balance)
                {
                    value -= user.balance;
                    user.balance = value;
                    user.balanceType = 1;
                }
                else
                    user.balance -= value;
            }
            else
            {
                user.balance += value;
            }

            string s = await userModel.saveUser(user);
        }

        private async Task calcShippingComBalance(decimal value, int shippingcompanyId)
        {//balance for shipping company
            ShippingCompanies shCom = await shCompanyModel.GetByID(shippingcompanyId);

            if (shCom.balanceType == 0)
            {
                if (value > shCom.balance)
                {
                    value -= shCom.balance;
                    shCom.balance = value;
                    shCom.balanceType = 1;
                }
                else
                    shCom.balance -= value;
            }
            else
            {
                shCom.balance += value;
            }

            string s = await shCompanyModel.Save(shCom);
        }

        private  void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
          
        }

        private  void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
        }

        private  void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                btn_image.IsEnabled = false;
                btn_add.IsEnabled = true;
                btn_invoices.Visibility = Visibility.Collapsed;
                btn_invoices.IsEnabled = false;
                tb_cash.IsReadOnly = false;
                tb_transNum.Text = "";
                cb_depositTo.SelectedIndex = -1;
                cb_paymentProcessType.SelectedIndex = -1;
                cb_card.SelectedIndex = -1;
                cb_card.Visibility = Visibility.Collapsed;
                tb_docNum.Clear();
                tb_docNumCheque.Clear();
                tb_docNumCard.Clear();
                dp_docDate.SelectedDate = null;
                tb_cash.Clear();
                tb_note.Clear();
                cb_recipientV.Visibility = Visibility.Collapsed;
                cb_recipientC.Visibility = Visibility.Collapsed;
                cb_recipientU.Visibility = Visibility.Collapsed;
                cb_recipientSh.Visibility = Visibility.Collapsed;
                if (grid_document.IsVisible)
                {
                    TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                    SectionData.clearValidate(dpDate, p_errorDocDate);
                }
                grid_document.Visibility = Visibility.Collapsed ;
                grid_cheque.Visibility = Visibility.Collapsed;
                SectionData.clearValidate(tb_docNum, p_errorDocNum);
                SectionData.clearValidate(tb_cash, p_errorCash);
                SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                SectionData.clearComboBoxValidate(cb_depositTo, p_errorDepositTo);
                SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
                SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                ///////////////////////////
                btn_add.IsEnabled = true;
                cb_depositTo.IsEnabled = true;
                cb_recipientV.IsEnabled = true;
                cb_recipientC.IsEnabled = true;
                cb_recipientU.IsEnabled = true;
                cb_recipientSh.IsEnabled = true;
                cb_paymentProcessType.IsEnabled = true;
                tb_docNum.IsEnabled = true;
                dp_docDate.IsEnabled = true;
                tb_docNumCheque.IsEnabled = true;
                tb_docNumCard.IsEnabled = true;
                dp_docDateCheque.IsEnabled = true;
                cb_card.IsEnabled = true;
                tb_cash.IsEnabled = true;
                tb_note.IsEnabled = true;
                /////////////////////////
                if (sender != null)
                SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        async Task<IEnumerable<CashTransfer>> RefreshCashesList()
        {
            cashes = await cashModel.GetCashTransferAsync("p", "all");
            cashes = cashes.Where(x => x.processType != "balance");
            return cashes;
            
        }

        void RefreshCashView()
        {
            dg_paymentsAccounts.ItemsSource = cashesQuery;
            cashes = cashes.Where(x => x.processType != "balance");
            txt_count.Text = cashesQuery.Count().ToString();
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Thread t1 = new Thread(() =>
                    {
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Account\Ar\ArPayAccReport.rdlc";
                        }
                        else addpath = @"\Reports\Account\EN\PayAccReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        ReportCls.checkLang();

                        clsReports.bankAccReport(cashesQuery, rep, reppath);
                        clsReports.setReportLanguage(paramarr);
                        clsReports.Header(paramarr);

                        rep.SetParameters(paramarr);

                        rep.Refresh();
                        this.Dispatcher.Invoke(() =>
                        {
                            saveFileDialog.Filter = "EXCEL|*.xls;";
                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string filepath = saveFileDialog.FileName;
                                LocalReportExtensions.ExportToExcel(rep, filepath);
                            }
                        });


                    });
                    t1.Start();
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
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
            try
            {
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (cashtrans != null || cashtrans.cashTransId != 0)
                    {
                        wd_uploadImage w = new wd_uploadImage();

                        w.tableName = "cashTransfer";
                        w.tableId = cashtrans.cashTransId;
                        w.docNum = cashtrans.docNum;
                        w.ShowDialog();
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }


        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                await RefreshCashesList();
               Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//type selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                TextBox dpDateCheque = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDateCheque);

                switch (cb_paymentProcessType.SelectedIndex)
                {

                    case 0://cash
                        grid_document.Visibility = Visibility.Collapsed;
                        tb_docNum.Clear();
                        dp_docDate.SelectedDate = null;
                        grid_cheque.Visibility = Visibility.Collapsed;
                        tb_docNumCheque.Clear();
                        dp_docDateCheque.SelectedDate = null;
                        cb_card.Visibility = Visibility.Collapsed;
                        cb_card.SelectedIndex = -1;
                        tb_docNumCard.Visibility = Visibility.Collapsed;
                        SectionData.clearValidate(tb_docNum, p_errorDocNum);
                        SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                        SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                        SectionData.clearComboBoxValidate(cb_card , p_errorCard);
                        break;

                    case 1://doc
                        grid_document.Visibility = Visibility.Visible;
                        grid_cheque.Visibility = Visibility.Collapsed;
                        tb_docNumCheque.Clear();
                        dp_docDateCheque.SelectedDate = null;
                        cb_card.Visibility = Visibility.Collapsed;
                        cb_card.SelectedIndex = -1;
                        tb_docNumCard.Visibility = Visibility.Collapsed;
                        SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                        SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                        SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                        break;

                    case 2://cheque
                        grid_cheque.Visibility = Visibility.Visible;
                        grid_document.Visibility = Visibility.Collapsed;
                        tb_docNum.Clear();
                        dp_docDate.SelectedDate = null;
                        cb_card.Visibility = Visibility.Collapsed;
                        cb_card.SelectedIndex = -1;
                        tb_docNumCard.Visibility = Visibility.Collapsed;
                        SectionData.clearValidate(tb_docNum, p_errorDocNum);
                        SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                        SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                        break;
                   
                    case 3://card
                        grid_document.Visibility = Visibility.Collapsed;
                        tb_docNum.Clear();
                        dp_docDate.SelectedDate = null;
                        grid_cheque.Visibility = Visibility.Collapsed;
                        tb_docNum.Clear();
                        dp_docDate.SelectedDate = null;
                        cb_card.Visibility = Visibility.Visible ;
                        tb_docNumCard.Visibility = Visibility.Visible;
                        SectionData.clearValidate(tb_docNum, p_errorDocNum);
                        SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                        break;
                }
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Cb_depositTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//deposit selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                switch (cb_depositTo.SelectedIndex)
                {
                    case 0://vendor
                        cb_recipientV.SelectedIndex = -1;
                        cb_recipientV.Visibility = Visibility.Visible;
                        btn_invoices.Visibility = Visibility.Visible;
                        btn_invoices.IsEnabled = false;
                        cb_recipientC.Visibility = Visibility.Collapsed;
                        cb_recipientU.Visibility = Visibility.Collapsed;
                        cb_recipientSh.Visibility = Visibility.Collapsed;
                        SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                        break;
                    case 1://customer
                        cb_recipientC.SelectedIndex = -1;
                        cb_recipientV.Visibility = Visibility.Collapsed;
                        btn_invoices.Visibility = Visibility.Visible;
                        btn_invoices.IsEnabled = false;
                        cb_recipientC.Visibility = Visibility.Visible;
                        cb_recipientU.Visibility = Visibility.Collapsed;
                        cb_recipientSh.Visibility = Visibility.Collapsed;
                        SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                        break;
                    case 2://user
                        cb_recipientU.SelectedIndex = -1;
                        cb_recipientV.Visibility = Visibility.Collapsed;
                        btn_invoices.Visibility = Visibility.Collapsed;
                        btn_invoices.IsEnabled = false;
                        cb_recipientC.Visibility = Visibility.Collapsed;
                        cb_recipientU.Visibility = Visibility.Visible;
                        cb_recipientSh.Visibility = Visibility.Collapsed;
                        SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                        break;
                    case 3://salary
                        cb_recipientU.SelectedIndex = -1;
                        cb_recipientV.Visibility = Visibility.Collapsed;
                        btn_invoices.Visibility = Visibility.Collapsed;
                        btn_invoices.IsEnabled = false;
                        cb_recipientC.Visibility = Visibility.Collapsed;
                        cb_recipientU.Visibility = Visibility.Visible;
                        cb_recipientSh.Visibility = Visibility.Collapsed;
                        SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                        break;
                    case 4: //general expenses
                    case 5://administrative pull
                        cb_recipientV.Visibility = Visibility.Collapsed;
                        btn_invoices.Visibility = Visibility.Collapsed;
                        btn_invoices.IsEnabled = false;
                        cb_recipientC.Visibility = Visibility.Collapsed;
                        cb_recipientU.Visibility = Visibility.Collapsed;
                        cb_recipientSh.Visibility = Visibility.Collapsed;
                        cb_recipientV.Text = ""; cb_recipientC.Text = ""; cb_recipientU.Text = ""; cb_recipientSh.Text = "";
                        SectionData.clearComboBoxValidate(cb_recipientV , p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientSh, p_errorRecipient);
                        break;
                    case 6://shipping company
                        cb_recipientSh.SelectedIndex = -1;
                        cb_recipientV.Visibility = Visibility.Collapsed;
                        btn_invoices.Visibility = Visibility.Collapsed;
                        btn_invoices.IsEnabled = false;
                        cb_recipientC.Visibility = Visibility.Collapsed;
                        cb_recipientU.Visibility = Visibility.Collapsed;
                        cb_recipientSh.Visibility = Visibility.Visible;
                        SectionData.clearComboBoxValidate(cb_recipientV, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientC, p_errorRecipient);
                        SectionData.clearComboBoxValidate(cb_recipientU, p_errorRecipient);
                        break;
                }

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async Task fillVendors()
        {
            agents = await agentModel.GetAgentsActive("v");

            cb_recipientV.ItemsSource = agents;
            cb_recipientV.DisplayMemberPath = "name";
            cb_recipientV.SelectedValuePath = "agentId";
        }

        private async Task fillCustomers()
        {
            agents = await agentModel.GetAgentsActive("c");

            cb_recipientC.ItemsSource = agents;
            cb_recipientC.DisplayMemberPath = "name";
            cb_recipientC.SelectedValuePath = "agentId";
        }

        private async Task fillUsers()
        {
            users = await userModel.GetUsersActive();

            cb_recipientU.ItemsSource = users;
            cb_recipientU.DisplayMemberPath = "username";
            cb_recipientU.SelectedValuePath = "userId";
        }

        private async Task fillShippingCompanies()
        {
            shCompanies = await shCompanyModel.Get();

            cb_recipientSh.ItemsSource = shCompanies;
            cb_recipientSh.DisplayMemberPath = "name";
            cb_recipientSh.SelectedValuePath = "shippingCompanyId";
        }

        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
                var txb = sender as TextBox;
                if ((sender as TextBox).Name == "tb_cash")
                    SectionData.InputJustNumber(ref txb);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            { 
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_cash")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
                else if ((sender as TextBox).Name == "tb_docNum")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocNum, tt_errorDocNum, "trEmptyDocNumToolTip");
                else if ((sender as TextBox).Name == "tb_docNumCard")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocCard, tt_errorDocCard, "trEmptyProcessNumToolTip");
                else if ((sender as TextBox).Name == "tb_docNumCheque")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocNumCheque, tt_errorDocNumCheque, "trEmptyDocNumToolTip");

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
                else if ((sender as ComboBox).Name == "cb_recipientSh")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
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
         
        private  void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (cashtrans.cashTransId > 0)
                    {
                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Account\Ar\ArPayReport.rdlc";
                        }
                        else
                        {
                            addpath = @"\Reports\Account\En\PayReport.rdlc";
                        }

                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                        int cashId = Int32.Parse(s);
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
                    Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }


        private void Btn_print_pay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (cashtrans.cashTransId > 0)
                     {
                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Account\Ar\ArPayReport.rdlc";
                        }
                        else
                        {
                            addpath = @"\Reports\Account\En\PayReport.rdlc";
                        }

                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                        int cashId = Int32.Parse(s);
                        rep.ReportPath = reppath;
                        rep.DataSources.Clear();
                        rep.EnableExternalImages = true;
                        rep.SetParameters(reportclass.fillPayReport(cashtrans));
                
                        rep.Refresh();

                        LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
                    }
                } else
                Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private  void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;

                    string pdfpath;
                    pdfpath = @"\Thumb\report\temp.pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                    if (cashtrans.cashTransId > 0)
                    {
                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Account\Ar\ArPayReport.rdlc";
                        }
                        else
                        {
                            addpath = @"\Reports\Account\En\PayReport.rdlc";
                        }

                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
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
                    Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
       
        private void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {//invoices
            try
            {
                invoicesLst.Clear();
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoicesList w = new wd_invoicesList();

                if (cb_depositTo.SelectedValue.ToString() == "v")
                    w.agentId = Convert.ToInt32(cb_recipientV.SelectedValue);
                else if (cb_depositTo.SelectedValue.ToString() == "c")
                    w.agentId = Convert.ToInt32(cb_recipientC.SelectedValue);

                w.invType = "pay";

                w.ShowDialog();
                if (w.isActive)
                {
                    tb_cash.Text = w.sum.ToString();
                    tb_cash.IsReadOnly = true;
                    invoicesLst.AddRange(w.selectedInvoices);
                }
                Window.GetWindow(this).Opacity = 1;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_salaries_Click(object sender, RoutedEventArgs e)
        {//salaries

        }

        private void Cb_recipientV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((cb_recipientV.SelectedIndex != -1) && (cb_recipientV.IsEnabled))
                    btn_invoices.IsEnabled = true;
                else
                    btn_invoices.IsEnabled = false;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }

        }



        private void Tb_EnglishDigit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only english and digits
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
        }

        private void Cb_recipientC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((cb_recipientC.SelectedIndex != -1) && (cb_recipientC.IsEnabled))
                    btn_invoices.IsEnabled = true;
                else
                    btn_invoices.IsEnabled = false;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath;
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    addpath = @"\Reports\Account\Ar\ArPayAccReport.rdlc";
                }
                else addpath = @"\Reports\Account\EN\PayAccReport.rdlc";
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.bankAccReport(cashesQuery, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();
                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_preview1_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            string pdfpath = "";

            List<ReportParameter> paramarr = new List<ReportParameter>();


            //
            pdfpath = @"\Thumb\report\temp.pdf";
            pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

            string addpath = "";
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Account\Ar\ArPayAccReport.rdlc";
            }
            else addpath = @"\Reports\Account\EN\PayAccReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.bankAccReport(cashesQuery, rep, reppath);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();

            LocalReportExtensions.ExportToPDF(rep, pdfpath);
            wd_previewPdf w = new wd_previewPdf();
            w.pdfPath = pdfpath;
            if (!string.IsNullOrEmpty(w.pdfPath))
            {
                w.ShowDialog();
                w.wb_pdfWebViewer.Dispose();


            }
            Window.GetWindow(this).Opacity = 1;
        }

        private void Btn_pdf1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucPaymentsAccounts);

                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath;
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    addpath = @"\Reports\Account\Ar\ArPayAccReport.rdlc";
                }
                else addpath = @"\Reports\Account\EN\PayAccReport.rdlc";
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.bankAccReport(cashesQuery, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);
                clsReports.bankdg(paramarr);

                rep.SetParameters(paramarr);

                rep.Refresh();

                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
                }

                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucPaymentsAccounts);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
    }
}

        
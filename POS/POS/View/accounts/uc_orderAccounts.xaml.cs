using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using netoaster;
using POS.Classes;
using POS.View.sectionData.Charts;
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
        string BranchesPermission = "ordersAccounting_allBranches";
        
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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
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
        //IEnumerable<CashTransfer> cashesQuery;
        //IEnumerable<CashTransfer> cashesQueryExcel;
        IEnumerable<Invoice> invoiceQuery;
        IEnumerable<Invoice> invoiceQueryExcel;
        //IEnumerable<CashTransfer> cashes;
        IEnumerable<Invoice> invoices;
        IEnumerable<Branch> branches;
        int agentId, userId;
        string searchText = "";
        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {//confirm

        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);

                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                //SectionData.fillBranches(cb_branch, "bs");/////permissions

                #region fill branch combo1
                try
                {
                    branches = await branchModel.GetBranchesActive("b");
                    cb_branch.ItemsSource = branches;
                    cb_branch.DisplayMemberPath = "name";
                    cb_branch.SelectedValuePath = "branchId";
                    cb_branch.SelectedValue = MainWindow.branchID.Value;
                    if (MainWindow.groupObject.HasPermissionAction(BranchesPermission, MainWindow.groupObjects, "one"))
                        cb_branch.IsEnabled = true;
                    else
                        cb_branch.IsEnabled = false;
                }
                catch { }
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

                btn_save.IsEnabled = false;

                #region fill process type
                var typelist = new[] {
                new { Text = MainWindow.resourcemanager.GetString("trCredit")    , Value = "balance" },
                new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
                new { Text = MainWindow.resourcemanager.GetString("trDocument")   , Value = "doc" },
                new { Text = MainWindow.resourcemanager.GetString("trCheque")     , Value = "cheque" },
                new { Text = MainWindow.resourcemanager.GetString("trAnotherPaymentMethods") , Value = "card" }
                 };
                cb_paymentProcessType.DisplayMemberPath = "Text";
                cb_paymentProcessType.SelectedValuePath = "Value";
                cb_paymentProcessType.ItemsSource = typelist;
                #endregion

                #region fill card combo
                try
                {
                    cards = await cardModel.GetAll();
                    cb_card.ItemsSource = cards;
                    cb_card.DisplayMemberPath = "name";
                    cb_card.SelectedValuePath = "cardId";
                    cb_card.SelectedIndex = -1;
                }
                catch { }
                #endregion

                #region fill agent combo
                List<Agent> agents = new List<Agent>();
                List<Agent> customers = new List<Agent>();
                try
                {
                    customers = await agentModel.GetAgentsActive("c");
                    agents = await agentModel.GetAgentsActive("v");
                    agents.AddRange(customers);

                    cb_customer.ItemsSource = customers;
                    cb_customer.DisplayMemberPath = "name";
                    cb_customer.SelectedValuePath = "agentId";
                    cb_customer.SelectedIndex = -1;
                }
                catch { }
                #endregion

                #region fill salesman combo
                try
                {
                    users = await userModel.GetUsersActive();
                    cb_salesMan.ItemsSource = users;
                    cb_salesMan.DisplayMemberPath = "username";
                    cb_salesMan.SelectedValuePath = "userId";
                    cb_salesMan.SelectedIndex = -1;
                }
                catch { }
                #endregion

                #region fill status combo
                var statuslist = new[] {
                new { Text = MainWindow.resourcemanager.GetString("trDelivered")  , Value = "rc" },
                new { Text = MainWindow.resourcemanager.GetString("trInDelivery")   , Value = "tr" }
                 };
                cb_state.DisplayMemberPath = "Text";
                cb_state.SelectedValuePath = "Value";
                cb_state.ItemsSource = statuslist;
                #endregion

                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void dp_SelectedEndDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);

                await RefreshInvoiceList();
                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void dp_SelectedStartDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);

                await RefreshInvoiceList();
               Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
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
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trCustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_startSearchDate, MainWindow.resourcemanager.GetString("trSartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_endSearchDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_state, MainWindow.resourcemanager.GetString("trStateHint"));

            dg_orderAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            dg_orderAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trSalesMan");
            dg_orderAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trCustomer");
            dg_orderAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trDate");
            dg_orderAccounts.Columns[4].Header = MainWindow.resourcemanager.GetString("trCashTooltip");
            dg_orderAccounts.Columns[5].Header = MainWindow.resourcemanager.GetString("trState");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            tt_startDate.Content = MainWindow.resourcemanager.GetString("trStartDate");
            tt_endDate.Content = MainWindow.resourcemanager.GetString("trEndDate");
            tt_customer.Content = MainWindow.resourcemanager.GetString("trVendor/Customer");
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
            btn_image.Content = MainWindow.resourcemanager.GetString("trImage");
            btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            btn_printInvoice.Content = MainWindow.resourcemanager.GetString("trPrint");
            btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdfBtn");
            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trSave");
        }
        private void Dg_orderAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);

                #region clear validate
                SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorpaymentProcessType);
            TextBox tbDocDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
            SectionData.clearValidate(tb_docNum, p_errorDocNum);
            SectionData.clearValidate(tb_cash, p_errorCash);
            #endregion

                if (dg_orderAccounts.SelectedIndex != -1)
                {
                    invoice = dg_orderAccounts.SelectedItem as Invoice;
                    this.DataContext = cashtrans;

                    if (invoice != null)
                    {
                        

                        tb_cash.IsEnabled = true;

                        btn_image.IsEnabled = true;

                        tb_invoiceNum.Text = invoice.invNumber;

                        agentId = invoice.agentId.Value;
                       
                        userId = invoice.shipUserId.Value;

                        tb_cash.Text = SectionData.DecTostring(cashtrans.cash);

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




                        if (invoice.status == "rc")
                        {

                            btn_save.IsEnabled = false;
                            tb_cash.IsEnabled = false;
                            cb_paymentProcessType.IsEnabled = false;
                            tb_note.IsEnabled = false;
                            SectionData.clearValidate(tb_cash, p_errorCash);

                        }
                        else
                        {
                            btn_save.IsEnabled = true;
                            tb_cash.IsEnabled = true;
                            cb_paymentProcessType.IsEnabled = true;
                            tb_note.IsEnabled = true;

                        }
                    }
                    else
                    {
                        btn_save.IsEnabled = false;
                        btn_image.IsEnabled = false;
                    }
                }
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);

                try
                { 
                if (invoices is null)
                    await RefreshInvoiceList();

                    if (chb_all.IsChecked == false)
                    {
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
                    }
                    else
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            searchText = tb_search.Text.ToLower();
                            invoiceQuery = invoices.Where(s => (s.invNumber.ToLower().Contains(searchText)
                            || s.shipUserName.ToLower().Contains(searchText)
                            || s.agentName.ToLower().Contains(searchText)
                            || s.totalNet.ToString().ToLower().Contains(searchText)
                            || s.status.ToLower().Contains(searchText)
                            )
                            );

                        });
                    }

                    invoiceQueryExcel = invoiceQuery.ToList();
                RefreshInvoiceView();
                }
                catch { }

                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async Task<int> saveBond(string num, decimal ammount, Nullable<DateTime> date, string type)
        {
            Bonds bond = new Bonds();
            bond.number = num;
            bond.amount = ammount;
            bond.deserveDate = date;
            bond.type = type;
            bond.isRecieved = 0;
            bond.createUserId = MainWindow.userID.Value;

            int s = await bondModel.Save(bond);

            return s;
        }

        private async Task calcBalance(decimal ammount)
        {
            int s = 0;
            //increase pos balance
            Pos pos = await posModel.getById(MainWindow.posID.Value);
            pos.balance += ammount;

            s = await pos.save(pos);
        }
        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

        }
        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

        }
        private  void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            //try
            //{
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);
                //////////////////////
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
            //    if (sender != null)
            //        SectionData.EndAwait(grid_ucOrderAccounts);
            //}
            //catch (Exception ex)
            //{
            //    if (sender != null)
            //        SectionData.EndAwait(grid_ucOrderAccounts);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//excel
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
                {
                    #region
                    Thread t1 = new Thread(() =>
                    {
                        BuildReport();
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
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
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
            try
            { 
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one"))
                {
                    if (cashtrans != null || cashtrans.cashTransId != 0)
                    {
                        wd_uploadImage w = new wd_uploadImage();

                        w.tableName = "invoices";
                        w.tableId = invoice.invoiceId;
                        w.docNum = invoice.invNumber;
                        w.ShowDialog();
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);

                await RefreshInvoiceList();
                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
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
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
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
                SectionData.ExceptionMessage(ex, this);
            }
        }

        string processType = "";
        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//type selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);
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

                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async Task fillCustomers()
        {
            agents = await agentModel.GetAgentsActive("c");
            cb_customer.ItemsSource = agents;
            cb_customer.DisplayMemberPath = "name";
            cb_customer.SelectedValuePath = "agentId";
            cb_salesMan.SelectedIndex = -1;
        }
        private async Task fillUsers()
        {
            users = await userModel.GetUsersActive();

            cb_salesMan.ItemsSource = users;
            cb_salesMan.DisplayMemberPath = "username";
            cb_salesMan.SelectedValuePath = "userId";
            cb_salesMan.SelectedIndex = -1;
        }
        private   void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
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

        private   void Cb_salesMan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select salesman
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);

                invoiceQuery = invoiceQuery.Where(u => u.shipUserId == Convert.ToInt32(cb_salesMan.SelectedValue));
                invoiceQueryExcel = invoiceQuery;
                RefreshInvoiceView();

                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private  void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select agent
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);

                invoiceQuery = invoiceQuery.Where(c => c.agentId == Convert.ToInt32(cb_customer.SelectedValue));
                invoiceQueryExcel = invoiceQuery;
                RefreshInvoiceView();

                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private  void Cb_state_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select state
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);

                invoiceQuery = invoiceQuery.Where(s => s.status == cb_state.SelectedValue.ToString());
                invoiceQueryExcel = invoiceQuery;
                RefreshInvoiceView();

                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select branch
        }

        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);

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

                    #region save

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
                            int res = await saveBond(cash.docNum, cash.cash.Value, dp_docDate.SelectedDate.Value, "d");
                            cash.bondId = res;
                        }

                       int s = await cashModel.payOrderInvoice(invoice.invoiceId, invoice.invStatusId, cash.cash.Value, processType, cash);

                    if (!s.Equals(0))
                    {
                        if (cb_paymentProcessType.SelectedValue.ToString().Equals("cash"))
                            await calcBalance(decimal.Parse(tb_cash.Text));

                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                        Btn_clear_Click(null, null);

                        await RefreshInvoiceList();
                        Tb_search_TextChanged(null, null);
                    }
                    else
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                    }
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        public void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Account\Ar\ArOrderAccReport.rdlc";
            }
            else addpath = @"\Reports\Account\En\OrderAccReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            //clsReports.orderReport(invoiceQuery, rep, reppath);
            clsReports.orderReport(invoiceQuery, rep, reppath, paramarr);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);
            rep.Refresh();

        }

        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    BuildReport();
                    LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
                        #endregion
                    }
                    else
                        Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                    if (sender != null)
                        SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_preview1_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);
                /////////////////////
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    string pdfpath = "";

                 
                    //
                    pdfpath = @"\Thumb\report\temp.pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                    BuildReport();

                    LocalReportExtensions.ExportToPDF(rep, pdfpath);
                    wd_previewPdf w = new wd_previewPdf();
                    w.pdfPath = pdfpath;
                    if (!string.IsNullOrEmpty(w.pdfPath))
                    {
                        w.ShowDialog();
                        w.wb_pdfWebViewer.Dispose();
                    }
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                /////////////////////
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_pieChart_Click(object sender, RoutedEventArgs e)
        {//pie
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);
                /////////////////////
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    win_lvc win = new win_lvc(invoiceQuery, 7);
                    win.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                /////////////////////
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucOrderAccounts);
                /////////////////////
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    BuildReport();

                    saveFileDialog.Filter = "PDF|*.pdf;";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filepath = saveFileDialog.FileName;
                        LocalReportExtensions.ExportToPDF(rep, filepath);
                    }
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                /////////////////////
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucOrderAccounts);
                SectionData.ExceptionMessage(ex, this);
            }

        }
        private async void Chb_all_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                dp_startSearchDate.IsEnabled =
            dp_endSearchDate.IsEnabled = false;
                Btn_refresh_Click(btn_refresh, null);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Chb_all_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                dp_startSearchDate.IsEnabled =
                dp_endSearchDate.IsEnabled = true;

                Btn_refresh_Click(btn_refresh, null);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
    }
}

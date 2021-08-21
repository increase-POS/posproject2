﻿using Microsoft.Reporting.WinForms;
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
    /// Interaction logic for uc_bonds.xaml
    /// </summary>
    public partial class uc_bonds : UserControl
    {
        Card cardModel = new Card();
        IEnumerable<Card> cards;

        Bonds bondModel = new Bonds();
        IEnumerable<Bonds> bonds;
        Bonds bond = new Bonds();

        Agent agentModel = new Agent();
        User userModel = new User();

        IEnumerable<Agent> agents;
        IEnumerable<User> users;
        IEnumerable<CashTransfer> cashes;
        IEnumerable<CashTransfer> cashQuery;
        IEnumerable<Bonds> bondsQuery;
        IEnumerable<Bonds> bondsQueryExcel;
        string searchText = "";

        CashTransfer cashModel = new CashTransfer();

        string createPermission = "bonds_create";
        string reportsPermission = "bonds_reports";
        private static uc_bonds _instance;
        byte tgl_bondState;
        public static uc_bonds Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_bonds();
                return _instance;
            }
        }
        public uc_bonds()
        {
            InitializeComponent();
        }

        private async void Dg_bonds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            SectionData.clearValidate(tb_number, p_errorNumber);
            SectionData.clearValidate(tb_amount, p_errorAmount);

            SectionData.clearValidate(tb_depositor, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorCard);
            TextBox tbDocDate = (TextBox)dp_deservecDate.Template.FindName("PART_TextBox", dp_deservecDate);
            SectionData.clearValidate(tbDocDate, p_errorDocDate);

            if (dg_bonds.SelectedIndex != -1)
            {
                bond = dg_bonds.SelectedItem as Bonds;
                this.DataContext = bond;

                if (bond != null)
                {
                    btn_image.IsEnabled = true;

                    tb_number.Text = bond.number;

                    if (bond.isRecieved == 1)
                    {
                        btn_pay.Content = MainWindow.resourcemanager.GetString("trPaid");
                        btn_pay.IsEnabled = false;
                    }
                    else
                    {
                        btn_pay.Content = MainWindow.resourcemanager.GetString("trPay");
                        btn_pay.IsEnabled = true;
                    }

                    if (bond.ctside.Equals("v"))
                    {
                        cb_depositorV.SelectedValue = bond.ctagentId.Value;
                        cb_depositorV.Visibility = Visibility.Visible;
                        tb_depositor.Visibility = Visibility.Collapsed; SectionData.clearValidate(tb_depositor, p_errordepositor);
                        cb_depositorC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                        cb_depositorU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                    }
                    else if (bond.ctside.Equals("c"))
                    {
                        cb_depositorC.Visibility = Visibility.Visible;
                        cb_depositorC.SelectedValue = bond.ctagentId.Value;
                        tb_depositor.Visibility = Visibility.Collapsed; SectionData.clearValidate(tb_depositor, p_errordepositor);
                        cb_depositorV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                        cb_depositorU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                    }
                    else if (bond.ctside.Equals("u"))
                    {
                        cb_depositorU.SelectedValue = bond.ctuserId.Value;
                        cb_depositorU.Visibility = Visibility.Visible;
                        tb_depositor.Visibility = Visibility.Collapsed; SectionData.clearValidate(tb_depositor, p_errordepositor);
                        cb_depositorV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                        cb_depositorC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                    }
                    else
                    {
                        tb_depositor.Visibility = Visibility.Visible;

                        cb_depositorV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                        cb_depositorC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                        cb_depositorU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);

                        switch (bond.ctside)
                        {
                            case "s": tb_depositor.Text = MainWindow.resourcemanager.GetString("trSalary"); break;
                            case "e": tb_depositor.Text = MainWindow.resourcemanager.GetString("trGeneralExpenses"); break;
                            case "m":
                                if (bond.cttransType == "p")
                                    tb_depositor.Text = MainWindow.resourcemanager.GetString("trAdministrativePull");
                                else if (bond.cttransType == "d")
                                    tb_depositor.Text = MainWindow.resourcemanager.GetString("trAdministrativeDeposit");
                                break;

                        }

                    }
                    if (bond.isRecieved == 1)
                    {
                        var query = await cashModel.GetCashTransferAsync("all", "bnd");
                        CashTransfer ca = new CashTransfer();
                        ca = query.Where(c => c.bondId == bond.bondId).FirstOrDefault();
                        cb_paymentProcessType.SelectedValue = ca.processType;
                        if (cb_paymentProcessType.SelectedValue.ToString().Equals("card"))
                            cb_card.SelectedValue = ca.cardId;
                    }
                    else
                    {
                        cb_paymentProcessType.SelectedIndex = -1;
                        cb_card.SelectedIndex = -1;
                        cb_card.Visibility = Visibility.Collapsed;
                    }

                }

            }
        }

        private async void Btn_pay_Click(object sender, RoutedEventArgs e)
        {//pay
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {
                #region validate
                //chk empty payment type
                SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                //chk empty card 
                if (cb_card.IsVisible)
                    SectionData.validateEmptyComboBox(cb_card, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
                else
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                //chk empty payment type
                SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                //chk enough money
                bool enoughMoney = true;
                if ((!cb_paymentProcessType.Text.Equals("")) && (cb_paymentProcessType.SelectedValue.ToString().Equals("cash")) &&
                    (bond.type.Equals("p")) && (!await chkEnoughBalance(decimal.Parse(tb_amount.Text))))
                {
                    enoughMoney = false;
                    SectionData.showTextBoxValidate(tb_amount, p_errorAmount, tt_errorAmount, "trPopNotEnoughBalance");
                }
                #endregion

                if ((!cb_paymentProcessType.Text.Equals("")) &&
                    (((cb_card.IsVisible) && (!cb_card.Text.Equals(""))) || (!cb_card.IsVisible)) &&
                    enoughMoney)
                {
                    //update bond
                    //bond.deserveDate = dp_deservecDate.SelectedDate.Value;
                    bond.isRecieved = 1;

                    string s = await bondModel.Save(bond);

                    if (!s.Equals("0"))
                    {
                        //save new cashtransfer
                        CashTransfer cash = new CashTransfer();

                        cash.transType = bond.type;
                        cash.posId = MainWindow.posID.Value;
                        //cash.transNum = await SectionData.generateNumber(char.Parse(bond.type), "bnd");
                        cash.transNum = await cashModel.generateDocNumber(bond.type + "bnd");
                        cash.cash = decimal.Parse(tb_amount.Text);
                        cash.notes = tb_note.Text;
                        cash.createUserId = MainWindow.userID;
                        cash.side = "bnd";
                        cash.docNum = tb_number.Text;
                        cash.processType = cb_paymentProcessType.SelectedValue.ToString();
                        cash.bondId = bond.bondId;

                        if (cb_depositorV.IsVisible)
                            cash.agentId = Convert.ToInt32(cb_depositorV.SelectedValue);

                        if (cb_depositorC.IsVisible)
                            cash.agentId = Convert.ToInt32(cb_depositorC.SelectedValue);

                        if (cb_depositorU.IsVisible)
                            cash.userId = Convert.ToInt32(cb_depositorU.SelectedValue);

                        if (cb_paymentProcessType.SelectedValue.ToString().Equals("card"))
                            cash.cardId = Convert.ToInt32(cb_card.SelectedValue);

                        s = await cashModel.Save(cash);

                        if (!s.Equals("0"))
                        {
                            if (cb_paymentProcessType.SelectedValue.ToString().Equals("cash"))
                                calcBalance(bond.type, cash.cash.Value);

                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);

                            Btn_clear_Click(null, null);

                            await RefreshBondsList();
                            Tb_search_TextChanged(null, null);
                        }
                        //else
                        //    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        Pos posModel = new Pos();
        private async void calcBalance(string _type, decimal ammount)
        {//balance for pos
            string s = "";
            //increase pos balance
            Pos pos = await posModel.getPosById(MainWindow.posID.Value);
            if (_type.Equals("p"))
                pos.balance -= ammount;
            else
                pos.balance += ammount;

            s = await pos.savePos(pos);
        }

        private async Task<bool> chkEnoughBalance(decimal ammount)
        {
            Pos pos = await posModel.getPosById(MainWindow.posID.Value);
            if (pos.balance.Value >= ammount)
            { return true; }
            else { return false; }

        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            if (bonds is null)
                await RefreshBondsList();
            //this.Dispatcher.Invoke(() =>
            //{
            searchText = tb_search.Text.ToLower();

            bondsQuery = bonds.Where(s => (
            s.number.ToLower().Contains(searchText)
            ||
            s.amount.ToString().ToLower().Contains(searchText)
            || s.type.ToString().ToLower().Contains(searchText)
            )
            && s.updateDate.Value.Date >= sDate
            && s.updateDate.Value.Date <= eDate
            //&& s.deserveDate.Value.Date >= sDate
            //&& s.deserveDate.Value.Date <= eDate
            && s.isRecieved == tgl_bondState
            );

            //});

            bondsQueryExcel = bondsQuery;
            RefreshBondView();

        }

        private async void Tgl_isRecieved_Unchecked(object sender, RoutedEventArgs e)
        {//unreceived
            if (bonds is null)
                await RefreshBondsList();
            tgl_bondState = 0;
            Tb_search_TextChanged(null, null);
        }

        private async void Tgl_isRecieved_Checked(object sender, RoutedEventArgs e)
        {//received
            if (bonds is null)
                await RefreshBondsList();
            tgl_bondState = 1;
            Tb_search_TextChanged(null, null);
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            RefreshBondsList();
            Tb_search_TextChanged(null, null);
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
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_number.Text = "";
            tb_amount.Clear();
            tb_note.Clear();
            btn_image.IsEnabled = false;

            cb_depositorV.SelectedIndex = -1;
            cb_depositorC.SelectedIndex = -1;
            cb_depositorU.SelectedIndex = -1;
            cb_paymentProcessType.SelectedIndex = -1;
            cb_card.SelectedIndex = -1;
            dp_deservecDate.SelectedDate = null;

            cb_depositorV.Visibility = Visibility.Collapsed;
            cb_depositorC.Visibility = Visibility.Collapsed;
            cb_depositorU.Visibility = Visibility.Collapsed;

            SectionData.clearValidate(tb_number, p_errorNumber);
            SectionData.clearValidate(tb_amount, p_errorAmount);

            SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
            SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
            SectionData.clearComboBoxValidate(cb_card, p_errorCard);
            TextBox tbDocDate = (TextBox)dp_deservecDate.Template.FindName("PART_TextBox", dp_deservecDate);
            SectionData.clearValidate(tbDocDate, p_errorDocDate);
        }
        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {

            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_paymentProcessType")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                else if ((sender as ComboBox).Name == "cb_card")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
            }
        }


        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
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
            var QueryExcel = bondsQueryExcel.AsEnumerable().Select(x => new
            {
                TransNum = x.number,
                Ammount = x.amount,
                Recipient = x.type,
                Notes = x.notes
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trCash");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trRecepient");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);


        }
        private void PreventSpaces(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Btn_image_Click(object sender, RoutedEventArgs e)
        {//image
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {



                if (bonds != null || bond.bondId != 0)
                {
                    //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;

                    wd_uploadImage w = new wd_uploadImage();

                    w.tableName = "bondes";
                    w.tableId = bond.bondId;
                    w.docNum = bond.number;
                    w.ShowDialog();
                    // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity =1;
                }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load

            #region translate
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucBonds.FlowDirection = FlowDirection.LeftToRight;

            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucBonds.FlowDirection = FlowDirection.RightToLeft;

            }
            translate();
            #endregion

            fillVendors();

            fillCustomers();

            fillUsers();

            cb_depositorV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
            cb_depositorC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
            cb_depositorU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);

            #region fill process type
            var typelist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
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

            dp_endSearchDate.SelectedDate = DateTime.Now;
            dp_startSearchDate.SelectedDate = DateTime.Now;

            sDate = dp_startSearchDate.SelectedDate.Value;
            eDate = dp_endSearchDate.SelectedDate.Value;

            dp_startSearchDate.SelectedDateChanged += this.dp_SelectedStartDateChanged;
            dp_endSearchDate.SelectedDateChanged += this.dp_SelectedEndDateChanged;

            //TextBox dpDate = (TextBox)dp_deservecDate.Template.FindName("PART_TextBox", dp_deservecDate);
            //dpDate.IsReadOnly = true;

            btn_pay.IsEnabled = false;
            btn_image.IsEnabled = false;

            await RefreshBondsList();
            Tb_search_TextChanged(null, null);

        }

        private async void dp_SelectedEndDateChanged(object sender, SelectionChangedEventArgs e)
        {
            eDate = dp_endSearchDate.SelectedDate.Value;

            await RefreshBondsList();
            Tb_search_TextChanged(null, null);
        }
        DateTime sDate, eDate;
        private async void dp_SelectedStartDateChanged(object sender, SelectionChangedEventArgs e)
        {
            sDate = dp_startSearchDate.SelectedDate.Value;

            await RefreshBondsList();
            Tb_search_TextChanged(null, null);
        }

        private void translate()
        {
            txt_bonds.Text = MainWindow.resourcemanager.GetString("trBonds");
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            txt_isRecieved.Text = MainWindow.resourcemanager.GetString("trReceivedToggle");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_number, MainWindow.resourcemanager.GetString("trDocNumTooltip"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorV, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorC, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorU, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_amount, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_deservecDate, MainWindow.resourcemanager.GetString("trDocDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_card, MainWindow.resourcemanager.GetString("trCardHint"));

            dg_bonds.Columns[0].Header = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            //dg_bonds.Columns[1].Header = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            dg_bonds.Columns[1].Header = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            dg_bonds.Columns[2].Header = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            dg_bonds.Columns[3].Header = MainWindow.resourcemanager.GetString("trCashTooltip");
            dg_bonds.Columns[4].Header = MainWindow.resourcemanager.GetString("trDocDateTooltip");

            tt_number.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            tt_depositorV.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            tt_depositorC.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            tt_depositorU.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            tt_paymentType.Content = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            tt_card.Content = MainWindow.resourcemanager.GetString("trCardTooltip");
            tt_amount.Content = MainWindow.resourcemanager.GetString("trCashTooltip");
            tt_deserveDate.Content = MainWindow.resourcemanager.GetString("trDocDateTooltip");
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

            btn_pay.Content = MainWindow.resourcemanager.GetString("trPay");
            btn_image.Content = MainWindow.resourcemanager.GetString("trImage");
            btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            btn_printInvoice.Content = MainWindow.resourcemanager.GetString("trPrint");
            btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdf");
        }

        void RefreshBondView()
        {
            dg_bonds.ItemsSource = bondsQuery;
            txt_count.Text = bondsQuery.Count().ToString();
        }
        async Task<IEnumerable<Bonds>> RefreshBondsList()
        {
            bonds = await bondModel.GetAll();
            return bonds;
        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf

        }

        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//type selection
            TextBox dpDate = (TextBox)dp_deservecDate.Template.FindName("PART_TextBox", dp_deservecDate);

            switch (cb_paymentProcessType.SelectedIndex)
            {

                case 0://cash
                    cb_card.Visibility = Visibility.Collapsed; cb_card.SelectedIndex = -1;
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    break;

                case 1://cheque
                    cb_card.Visibility = Visibility.Collapsed; cb_card.SelectedIndex = -1;
                    SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                    break;

                case 2://card
                    cb_card.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {//print
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {


            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private async void fillVendors()
        {
            agents = await agentModel.GetAgentsActive("v");

            cb_depositorV.ItemsSource = agents;
            cb_depositorV.DisplayMemberPath = "name";
            cb_depositorV.SelectedValuePath = "agentId";
        }

        private async void fillCustomers()
        {
            agents = await agentModel.GetAgentsActive("c");

            cb_depositorC.ItemsSource = agents;
            cb_depositorC.DisplayMemberPath = "name";
            cb_depositorC.SelectedValuePath = "agentId";
        }



        private async void fillUsers()
        {
            users = await userModel.GetUsersActive();

            cb_depositorU.ItemsSource = users;
            cb_depositorU.DisplayMemberPath = "username";
            cb_depositorU.SelectedValuePath = "userId";
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath;
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    addpath = @"\Reports\Account\Ar\ArBondAccReport.rdlc";
                }
                else addpath = @"\Reports\Account\EN\BondAccReport.rdlc";
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.bondsReport(bondsQuery, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();
                LocalReportExtensions.PrintToPrinter(rep);
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    List<ReportParameter> paramarr = new List<ReportParameter>();
                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\Account\Ar\ArBondAccReport.rdlc";
                    }
                    else addpath = @"\Reports\Account\EN\BondAccReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                    ReportCls.checkLang();
                    clsReports.bondsReport(bondsQuery, rep, reppath);
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

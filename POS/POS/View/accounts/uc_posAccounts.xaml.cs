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
    /// Interaction logic for uc_posAccounts.xaml
    /// </summary>
    public partial class uc_posAccounts : UserControl
    {
        private static uc_posAccounts _instance;

        Pos posModel = new Pos();
        IEnumerable<Pos> poss;
        CashTransfer cashtrans = new CashTransfer();
        CashTransfer cashModel = new CashTransfer();
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashes;
        IEnumerable<CashTransfer> cashesSearch;
        string searchText = "";
        CashTransfer cashtrans2 = new CashTransfer();
        CashTransfer cashtrans3 = new CashTransfer();
        IEnumerable<CashTransfer> cashes2;
        string basicsPermission = "posAccounting_basics";
        string transAdminPermission = "posAccounting_transAdmin";
        public static uc_posAccounts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_posAccounts();
                return _instance;
            }
        }
        public uc_posAccounts()
        {
            InitializeComponent();
        }
        private void translate()
        {
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trTransaferDetails");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            txt_posAccounts.Text = MainWindow.resourcemanager.GetString("trPosAccounts");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos1, MainWindow.resourcemanager.GetString("trFromPosHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos2, MainWindow.resourcemanager.GetString("trToPosHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_state, MainWindow.resourcemanager.GetString("trStateHint"));

            dg_posAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_posAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trFromPos");
            dg_posAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trToPos");
            dg_posAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trOpperationTypeToolTip");
            dg_posAccounts.Columns[4].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

            tt_Pos1.Content = MainWindow.resourcemanager.GetString("trFromPos");
            tt_Pos2.Content = MainWindow.resourcemanager.GetString("trToPos");
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
            tt_state.Content = MainWindow.resourcemanager.GetString("trStateToolTip");

            btn_confirm.Content = MainWindow.resourcemanager.GetString("trConfirm");
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load

            #region translate
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucposAccounts.FlowDirection = FlowDirection.LeftToRight;

            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucposAccounts.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            #endregion

            #region Style Date
            /////////////////////////////////////////////////////////////
            SectionData.defaultDatePickerStyle(dp_startSearchDate);
            SectionData.defaultDatePickerStyle(dp_endSearchDate);
            /////////////////////////////////////////////////////////////
            #endregion

            dp_startSearchDate.SelectedDate = DateTime.Now.Date;
            dp_endSearchDate.SelectedDate = DateTime.Now.Date;

            dp_startSearchDate.SelectedDateChanged += this.dp_SelectedStartDateChanged;
            dp_endSearchDate.SelectedDateChanged += this.dp_SelectedEndDateChanged;

            #region fill pos combo1
            poss = await posModel.GetPosAsync();
            cb_pos1.ItemsSource = poss;
            cb_pos1.DisplayMemberPath = "name";
            cb_pos1.SelectedValuePath = "posId";
            cb_pos1.SelectedIndex = -1;
            #endregion

            #region fill pos combo2
            poss = await posModel.GetPosAsync();
            cb_pos2.ItemsSource = poss;
            cb_pos2.DisplayMemberPath = "name";
            cb_pos2.SelectedValuePath = "posId";
            cb_pos2.SelectedIndex = -1;
            #endregion

            #region fill operation state
            var dislist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trUnConfirmed"), Value = "0" },
            new { Text = MainWindow.resourcemanager.GetString("trWaiting")    , Value = "1" },
            new { Text = MainWindow.resourcemanager.GetString("trConfirmed")  , Value = "2" },
             };
            cb_state.DisplayMemberPath = "Text";
            cb_state.SelectedValuePath = "Value";
            cb_state.ItemsSource = dislist;
            #endregion

            //dg_posAccounts.ItemsSource = await cashModel.GetCashTransferAsync("all", "p");
            this.Dispatcher.Invoke(() =>
            {
                Tb_search_TextChanged(null, null);
            });
            //await RefreshCashesList();
            //Tb_search_TextChanged(null, null);

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
        private async void Dg_posAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearComboBoxValidate(cb_pos1, p_errorPos1);
            SectionData.clearComboBoxValidate(cb_pos2, p_errorPos2);

            if (dg_posAccounts.SelectedIndex != -1)
            {
                cashtrans = dg_posAccounts.SelectedItem as CashTransfer;
                this.DataContext = cashtrans;

                if (cashtrans != null)
                {
                    //creator pos is login pos
                    if(cashtrans.posIdCreator == MainWindow.posID.Value)
                    {
                        btn_update.IsEnabled = true;
                        btn_delete.IsEnabled = true;
                    }
                    else
                    {
                        btn_update.IsEnabled = false;
                        btn_delete.IsEnabled = false;
                    }
                    //login pos is operation pos
                    if (cashtrans.posId == MainWindow.posID.Value)
                    {
                        if (cashtrans.isConfirm != 1)
                        { btn_confirm.Content = MainWindow.resourcemanager.GetString("trConfirm") ; btn_confirm.IsEnabled = true; }
                        else
                        { btn_confirm.Content = MainWindow.resourcemanager.GetString("trIsConfirmed"); btn_confirm.IsEnabled = false; }
                    }
                    else
                    {
                      
                        btn_confirm.IsEnabled = false;
                        if (cashtrans.isConfirm != 1)
                             btn_confirm.Content = MainWindow.resourcemanager.GetString("trConfirm");
                        else
                             btn_confirm.Content = MainWindow.resourcemanager.GetString("trIsConfirmed");
                    }

                    #region get two pos
                  
                    cashes2 = await cashModel.GetbySourcId("p", cashtrans.cashTransId);
                    //to insure that the pull operation is in cashtrans2 
                    if (cashtrans.transType == "p")
                    {
                        cashtrans2 = cashes2.ToList()[0] as CashTransfer;
                        cashtrans3 = cashes2.ToList()[1] as CashTransfer;
                    }
                    else if (cashtrans.transType == "d")
                    {
                        cashtrans2 = cashes2.ToList()[1] as CashTransfer;
                        cashtrans3 = cashes2.ToList()[0] as CashTransfer;
                    }
                   
                    cb_pos1.SelectedValue = cashtrans2.posId;
                    cb_pos2.SelectedValue = cashtrans3.posId;
                    #endregion
                }
            }
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show"))
            {
                if (cashes is null)
                    await RefreshCashesList();
                searchText = tb_search.Text;

                switch (cb_state.Text)
                {
                    case "غير مؤكدة"://inconfirmed
                        cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                         || s.transType.Contains(searchText)
                         || s.cash.ToString().Contains(searchText)
                         || s.posName.Contains(searchText)
                         )
                        && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                        && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                        && s.posId == MainWindow.posID.Value
                        && s.isConfirm == 0
                        );
                        break;
                    case "بانتظار التأكيد"://waiting
                        cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                        || s.transType.Contains(searchText)
                        || s.cash.ToString().Contains(searchText)
                        || s.posName.Contains(searchText)
                        )
                        && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                        && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                        && s.posId == MainWindow.posID.Value
                        && s.isConfirm == 1
                        //&& another is not confirmed 
                        && s.isConfirm2 == 0
                        );
                        break;
                    case "مؤكدة"://confirmed
                        cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                        || s.transType.Contains(searchText)
                        || s.cash.ToString().Contains(searchText)
                        || s.posName.Contains(searchText)
                        )
                        && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                        && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                        && s.posId == MainWindow.posID.Value
                        && s.isConfirm == 1
                        //&& another is confirmed
                        && s.isConfirm2 == 1
                        );
                        break;
                    default://no select
                        cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                        || s.transType.Contains(searchText)
                        || s.cash.ToString().Contains(searchText)
                        || s.posName.Contains(searchText)
                        )
                       && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                       && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                       );
                        break;
                }
                RefreshCashView();
                txt_count.Text = cashesQuery.Count().ToString();
            }
        }
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add"))
            {

             //chk empty cash
             SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
            //chk empty pos1
            SectionData.validateEmptyComboBox(cb_pos1, p_errorPos1, tt_errorPos1, "trErrorEmptyFromPosToolTip");
            //chk empty pos2
            SectionData.validateEmptyComboBox(cb_pos2, p_errorPos2, tt_errorPos2, "trErrorEmptyToPosToolTip");
            //chk if 2 pos is the same
            bool isSame = false;
            if (cb_pos1.SelectedIndex == cb_pos2.SelectedIndex)
                isSame = true;
            if ((cb_pos1.SelectedIndex != -1) && (cb_pos2.SelectedIndex != -1) && (cb_pos1.SelectedIndex == cb_pos2.SelectedIndex))
            {
                SectionData.showComboBoxValidate(cb_pos1, p_errorPos1, tt_errorPos1, "trErrorSamePos");
                SectionData.showComboBoxValidate(cb_pos2, p_errorPos2, tt_errorPos2, "trErrorSamePos");
            }

            if ((!tb_cash.Text.Equals("")) && (!cb_pos1.Text.Equals("")) && (!cb_pos2.Text.Equals("")) && !isSame && !validTransAdmin())
            {
                //first operation
                CashTransfer cash1 = new CashTransfer();

                cash1.transType = "p";//pull
                //cash1.transNum = await SectionData.generateNumber('p', "p");//first parameter is pull , second is pos
                cash1.transNum = await cashModel.generateCashNumber("pp");
                cash1.cash = decimal.Parse(tb_cash.Text);
                cash1.createUserId = MainWindow.userID.Value;
                cash1.notes = tb_note.Text;
                cash1.posIdCreator = MainWindow.posID.Value;
                if (Convert.ToInt32(cb_pos1.SelectedValue) == MainWindow.posID)
                    cash1.isConfirm = 1;
                else cash1.isConfirm = 0;
                cash1.side = "p";//pos
                cash1.posId = Convert.ToInt32(cb_pos1.SelectedValue);

                string s1 = await cashModel.Save(cash1);

                if (!s1.Equals("0"))
                {
                    //second operation
                    CashTransfer cash2 = new CashTransfer();

                    cash2.transType = "d";//deposite
                    cash2.transNum = await SectionData.generateNumber('p', "p");//first parameter is deposit , second is pos
                    cash2.cash = decimal.Parse(tb_cash.Text);
                    cash2.createUserId = MainWindow.userID.Value;
                    cash2.posIdCreator = MainWindow.posID.Value;
                    if (Convert.ToInt32(cb_pos2.SelectedValue) == MainWindow.posID)
                        cash2.isConfirm = 1;
                    else cash2.isConfirm = 0;
                    cash2.side = "p";//pos
                    cash2.posId = Convert.ToInt32(cb_pos2.SelectedValue);
                    cash2.cashTransIdSource = int.Parse(s1);//id from first operation

                    string s2 = await cashModel.Save(cash2);

                    if (!s2.Equals("0"))
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
        }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update"))
            {
                //chk empty cash
                SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
            //chk empty user
            SectionData.validateEmptyComboBox(cb_pos1, p_errorPos1, tt_errorPos1, "trErrorEmptyFromPosToolTip");
            //chk empty bank
            SectionData.validateEmptyComboBox(cb_pos2, p_errorPos2, tt_errorPos2, "trErrorEmptyToPosToolTip");
            //chk if 2 pos is the same
            bool isSame = false;
            if (cb_pos1.SelectedIndex == cb_pos2.SelectedIndex)
                isSame = true;
            if ((cb_pos1.SelectedIndex != -1) && (cb_pos2.SelectedIndex != -1) && (cb_pos1.SelectedIndex == cb_pos2.SelectedIndex))
            {
                SectionData.showComboBoxValidate(cb_pos1, p_errorPos1, tt_errorPos1, "trErrorSamePos");
                SectionData.showComboBoxValidate(cb_pos2, p_errorPos2, tt_errorPos2, "trErrorSamePos");
            }
            if ((!tb_cash.Text.Equals("")) && (!cb_pos1.Text.Equals("")) && (!cb_pos2.Text.Equals("")) && !isSame)
            {
                //first operation (pull)
                cashtrans2.cash = decimal.Parse(tb_cash.Text);
                cashtrans2.notes = tb_note.Text;
                cashtrans2.posId = Convert.ToInt32(cb_pos1.SelectedValue);

                string s1 = await cashModel.Save(cashtrans2);

                if (!s1.Equals("0"))
                {
                    //second operation (deposit)
                    cashtrans3.cash = decimal.Parse(tb_cash.Text);
                    cashtrans3.posId = Convert.ToInt32(cb_pos2.SelectedValue);
                    cashtrans3.notes = tb_note.Text;

                    string s2 = await cashModel.Save(cashtrans3);

                    if (!s2.Equals("0"))
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);

                        await RefreshCashesList();
                        Tb_search_TextChanged(null, null);
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
            }
        }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete"))
            {
                if (cashtrans.cashTransId != 0)
            {
                #region
                Window.GetWindow(this).Opacity = 0.2;
                wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;
                #endregion
                if (w.isOk)
                {
                    string b = await cashModel.deletePosTrans(cashtrans.cashTransId);

                    if (b == "1")
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopDelete"), animation: ToasterAnimation.FadeIn);
                        //clear textBoxs
                        Btn_clear_Click(sender, e);
                    }
                    else if (b == "0")
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopCanNotDeleteRequest"), animation: ToasterAnimation.FadeIn);
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    await RefreshCashesList();
                    Tb_search_TextChanged(null, null);
                }
            }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private async void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {//confirm
            if (cashtrans.cashTransId != 0)
            {
                //if another operation not confirmed then just confirm this
                ////if another operation is confirmed then chk balance before confirm
                bool confirm = false;
                if (cashtrans2.cashTransId == cashtrans.cashTransId)//chk which record is selected
                { if (cashtrans3.isConfirm == 0) confirm = false; else confirm = true; }
                else//chk which record is selected
                { if (cashtrans2.isConfirm == 0) confirm = false; else confirm = true; }

                if (!confirm) confirmOpr();
                else
                {
                    Pos pos = await posModel.getPosById(cashtrans2.posId.Value);
                    //there is enough balance
                    if (pos.balance > cashtrans2.cash)
                    {
                        string s = await cashModel.MovePosCash(cashtrans2.cashTransId, MainWindow.userID.Value);

                        if (s.Equals("transdone"))//tras done so confirm
                            confirmOpr();
                        else//error then do not confirm
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    }
                    //there is not enough balance
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopNotEnoughBalance"), animation: ToasterAnimation.FadeIn);
                }
            }
        }
        private async void confirmOpr()
        {
            cashtrans.isConfirm = 1;
            string s = await cashModel.Save(cashtrans);
            if (!s.Equals("0"))
            {
                await RefreshCashesList();
                Tb_search_TextChanged(null, null);

                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopConfirm"), animation: ToasterAnimation.FadeIn);

                btn_confirm.Content = MainWindow.resourcemanager.GetString("trIsConfirmed");
                btn_confirm.IsEnabled = false;
            }
            }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            txt_transNum.Text = "";
            tb_cash.Clear();
            cb_pos1.SelectedIndex = -1;
            cb_pos2.SelectedIndex = -1;
            tb_note.Clear();
            
            btn_add.IsEnabled = true;
            btn_update.IsEnabled = true;
            btn_delete.IsEnabled = true;
            btn_confirm.IsEnabled = false;

            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearComboBoxValidate(cb_pos1, p_errorPos1);
            SectionData.clearComboBoxValidate(cb_pos2, p_errorPos2);
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report"))
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
        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show"))
            {
                await RefreshCashesList();
                Tb_search_TextChanged(null, null);
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        async Task<IEnumerable<CashTransfer>> RefreshCashesList()
        {
            cashes = await cashModel.GetCashTransferAsync("all", "p");
            return cashes;
        }
        void RefreshCashView()
        {
            dg_posAccounts.ItemsSource = cashesQuery;
            txt_count.Text = cashesQuery.Count().ToString();
        }
        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_cash")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_pos1")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorPos1, tt_errorPos1, "trErrorEmptyPosToolTip");
                else if ((sender as ComboBox).Name == "cb_pos2")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorPos2, tt_errorPos2, "trErrorEmptyPosToolTip");
            }
        }
        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }
        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
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
       
        void FN_ExportToExcel()
        {
            var QueryExcel = cashesQuery.AsEnumerable().Select(x => new
            {
                TransNum = x.transNum,
                PosFromName = x.posName,
                PosToName   = x.pos2Name,
                OpperationType = x.transType,
                Cash = x.cash
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trFromPos");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trToPos");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trOpperationTypeToolTip");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trCashTooltip");

            ExportToExcel.Export(DTForExcel);
        }
        private async void Cb_state_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
        }
        private async void Cb_pos1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//pos1selection
            //cb_pos2.IsEnabled = true;
            //MessageBox.Show(cb_pos1.SelectedValue.ToString());
            //fillPos2();
            //#region fill pos combo2
            ////var poss1 = cb_pos1.ItemsSource as List<Pos>;
            //var poss1 = await posModel.GetPosAsync();
            ////Pos pos = new Pos();
            ////pos = cb_pos1.SelectedValue as Pos;
            //if (cb_pos1.SelectedIndex != -1)
            //{
            //    poss1.RemoveAt(cb_pos1.SelectedIndex);
            //    cb_pos2.IsEnabled = true;
            //    cb_pos2.ItemsSource = poss1;
            //    cb_pos2.DisplayMemberPath = "name";
            //    cb_pos2.SelectedValuePath = "posId";
            //}
            //else
            //{
            //    cb_pos2.ItemsSource = null;
            //    cb_pos2.IsEnabled = false;
            //}
            //#endregion

                
        }
        bool validTransAdmin()
        {
            if (!MainWindow.groupObject.HasPermissionAction(transAdminPermission, MainWindow.groupObjects, "one"))
                if (cb_pos1.SelectedValue != null && cb_pos2.SelectedValue != null)
                    if (int.Parse(cb_pos1.SelectedValue.ToString()) != MainWindow.posID
                        && int.Parse(cb_pos2.SelectedValue.ToString()) != MainWindow.posID)
                    {
                        Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                        return false;
                    }
                        return true;
        }
        private void Cb_pos2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

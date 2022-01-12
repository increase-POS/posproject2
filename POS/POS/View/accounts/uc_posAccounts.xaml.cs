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
    /// Interaction logic for uc_posAccounts.xaml
    /// </summary>
    public partial class uc_posAccounts : UserControl
    {
        private static uc_posAccounts _instance;

        Pos posModel = new Pos();
        Branch branchModel = new Branch();
        IEnumerable<Pos> poss;
        IEnumerable<Branch> branches;
        CashTransfer cashtrans = new CashTransfer();
        CashTransfer cashModel = new CashTransfer();
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashesQueryExcel;
        IEnumerable<CashTransfer> cashes;
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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }
        private void translate()
        {
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trTransaferDetails");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            txt_posAccounts.Text = MainWindow.resourcemanager.GetString("trTransfers");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos1, MainWindow.resourcemanager.GetString("trFromPosHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos2, MainWindow.resourcemanager.GetString("trToPosHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_state, MainWindow.resourcemanager.GetString("trStateHint"));

            dg_posAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_posAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trFromPos");
            dg_posAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trToPos");
            dg_posAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trOpperationTypeToolTip");
            dg_posAccounts.Columns[4].Header = MainWindow.resourcemanager.GetString("trDate");
            dg_posAccounts.Columns[5].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);

                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

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

                try
                {
                    poss = await posModel.Get();
                }
                catch { }

                //SectionData.fillBranches(cb_fromBranch, "bs");
                //cb_fromBranch.SelectedValue = MainWindow.branchID.Value;
                //SectionData.fillBranches(cb_toBranch, "bs");
                //cb_toBranch.SelectedValue = MainWindow.branchID.Value;


                if (!MainWindow.groupObject.HasPermissionAction(transAdminPermission, MainWindow.groupObjects, "one"))
                {
                    cb_fromBranch.IsEnabled = false;////////////permissions
                    cb_toBranch.IsEnabled = false;/////////////permissions
                }

                #region fill branch combo1
                try
                {
                    branches = await branchModel.GetBranchesActive("b");
                    cb_fromBranch.ItemsSource = branches;
                    cb_fromBranch.DisplayMemberPath = "name";
                    cb_fromBranch.SelectedValuePath = "branchId";
                    cb_fromBranch.SelectedValue = MainWindow.branchID.Value;
                }
                catch { }
                #endregion

                #region fill branch combo2
                try
                {
                    cb_toBranch.ItemsSource = branches;
                    cb_toBranch.DisplayMemberPath = "name";
                    cb_toBranch.SelectedValuePath = "branchId";
                }
                catch { }
                #endregion

                #region fill operation state
                var dislist = new[] {
                new { Text = MainWindow.resourcemanager.GetString("trUnConfirmed")  , Value = "0" },
                new { Text = MainWindow.resourcemanager.GetString("trWaiting")      , Value = "1" },
                new { Text = MainWindow.resourcemanager.GetString("trConfirmed")    , Value = "2" },
                new { Text = MainWindow.resourcemanager.GetString("trCreatedOper")  , Value = "3" }
                 };
                cb_state.DisplayMemberPath = "Text";
                cb_state.SelectedValuePath = "Value";
                cb_state.ItemsSource = dislist;
                cb_state.SelectedIndex = 0;
                #endregion

                //this.Dispatcher.Invoke(() =>
                //{
                Tb_search_TextChanged(null, null);
                //});

                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void dp_SelectedEndDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                await RefreshCashesList();
                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void dp_SelectedStartDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                await RefreshCashesList();
                Tb_search_TextChanged(null, null);
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Dg_posAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);

                SectionData.clearValidate(tb_cash, p_errorCash);
                SectionData.clearComboBoxValidate(cb_pos1, p_errorPos1);
                SectionData.clearComboBoxValidate(cb_pos2, p_errorPos2);

                if (dg_posAccounts.SelectedIndex != -1)
                {
                    cashtrans = dg_posAccounts.SelectedItem as CashTransfer;
                    this.DataContext = cashtrans;

                    if (cashtrans != null)
                    {
                        tb_cash.Text = SectionData.DecTostring(cashtrans.cash);

                        //creator pos is login pos
                        if (cashtrans.posIdCreator == MainWindow.posID.Value)
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
                            { btn_confirm.Content = MainWindow.resourcemanager.GetString("trConfirm"); btn_confirm.IsEnabled = true; }
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

                        cb_fromBranch.SelectedValue = (MainWindow.posList.Where(x => x.posId == cashtrans2.posId).FirstOrDefault() as Pos).branchId;
                        cb_pos1.SelectedValue = cashtrans2.posId;

                        cb_toBranch.SelectedValue = (MainWindow.posList.Where(x => x.posId == cashtrans3.posId).FirstOrDefault() as Pos).branchId;
                        cb_pos2.SelectedValue = cashtrans3.posId;



                        if ((cashtrans2.isConfirm == 1) && (cashtrans3.isConfirm == 1))
                            btn_update.IsEnabled = false;
                        //else
                        //    btn_update.IsEnabled = true;
                        #endregion
                    }
                }
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    try
                    {
                        if (cashes is null)
                            await RefreshCashesList();
                        searchText = tb_search.Text;
                        if (chb_all.IsChecked == false)
                        {
                            switch (Convert.ToInt32(cb_state.SelectedValue))
                            {
                                case 0://inconfirmed
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
                                case 1://waiting
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
                                case 2://confirmed
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
                                case 3://created by me
                                    cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                                    || s.transType.Contains(searchText)
                                    || s.cash.ToString().Contains(searchText)
                                    || s.posName.Contains(searchText)
                                    )
                                    && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                                    && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                                    && s.posIdCreator == MainWindow.posID.Value
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
                        }
                        else
                        {
                            switch (Convert.ToInt32(cb_state.SelectedValue))
                            {
                                case 0://inconfirmed
                                    cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                                     || s.transType.Contains(searchText)
                                     || s.cash.ToString().Contains(searchText)
                                     || s.posName.Contains(searchText)
                                     )
                                    && s.posId == MainWindow.posID.Value
                                    && s.isConfirm == 0
                                    );
                                    break;
                                case 1://waiting
                                    cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                                    || s.transType.Contains(searchText)
                                    || s.cash.ToString().Contains(searchText)
                                    || s.posName.Contains(searchText)
                                    )
                                    && s.posId == MainWindow.posID.Value
                                    && s.isConfirm == 1
                                    //&& another is not confirmed 
                                    && s.isConfirm2 == 0
                                    );
                                    break;
                                case 2://confirmed
                                    cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                                    || s.transType.Contains(searchText)
                                    || s.cash.ToString().Contains(searchText)
                                    || s.posName.Contains(searchText)
                                    )
                                    && s.posId == MainWindow.posID.Value
                                    && s.isConfirm == 1
                                    //&& another is confirmed
                                    && s.isConfirm2 == 1
                                    );
                                    break;
                                case 3://created by me
                                    cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                                    || s.transType.Contains(searchText)
                                    || s.cash.ToString().Contains(searchText)
                                    || s.posName.Contains(searchText)
                                    )
                                    && s.posIdCreator == MainWindow.posID.Value
                                    );
                                    break;
                                default://no select
                                    cashesQuery = cashes.Where(s => (s.transNum.Contains(searchText)
                                    || s.transType.Contains(searchText)
                                    || s.cash.ToString().Contains(searchText)
                                    || s.posName.Contains(searchText)
                                    )
                                   );
                                    break;
                            }
                        }

                        RefreshCashView();
                        cashesQueryExcel = cashesQuery.ToList();
                        txt_count.Text = cashesQuery.Count().ToString();
                    }
                    catch { }
                }
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {

                    #region validate
                    //chk empty cash
                    SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
                    //chk empty pos1
                    SectionData.validateEmptyComboBox(cb_pos1, p_errorPos1, tt_errorPos1, "trErrorEmptyFromPosToolTip");
                    //chk empty pos2
                    SectionData.validateEmptyComboBox(cb_pos2, p_errorPos2, tt_errorPos2, "trErrorEmptyToPosToolTip");
                    //chk if 2 pos is the same
                    bool isSame = false;
                    if (cb_pos1.SelectedValue == cb_pos2.SelectedValue)
                        isSame = true;
                    if ((cb_pos1.SelectedIndex != -1) && (cb_pos2.SelectedIndex != -1) && (cb_pos1.SelectedValue == cb_pos2.SelectedValue))
                    {
                        SectionData.showComboBoxValidate(cb_pos1, p_errorPos1, tt_errorPos1, "trErrorSamePos");
                        SectionData.showComboBoxValidate(cb_pos2, p_errorPos2, tt_errorPos2, "trErrorSamePos");
                    }

                    #endregion

                    #region add

                    if ((!tb_cash.Text.Equals("")) && (!cb_pos1.Text.Equals("")) && (!cb_pos2.Text.Equals("")) && !isSame /*&& !validTransAdmin()*/)
                    {
                        Pos pos = await posModel.getById(Convert.ToInt32(cb_pos1.SelectedValue));
                        if (pos.balance < decimal.Parse(tb_cash.Text))
                        { Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopNotEnoughBalance"), animation: ToasterAnimation.FadeIn); }
                        else
                        {
                            //first operation
                            CashTransfer cash1 = new CashTransfer();

                            cash1.transType = "p";//pull
                            cash1.transNum = await cashModel.generateCashNumber(cash1.transType + "p");
                            cash1.cash = decimal.Parse(tb_cash.Text);
                            cash1.createUserId = MainWindow.userID.Value;
                            cash1.notes = tb_note.Text;
                            cash1.posIdCreator = MainWindow.posID.Value;
                            if (Convert.ToInt32(cb_pos1.SelectedValue) == MainWindow.posID)
                                cash1.isConfirm = 1;
                            else cash1.isConfirm = 0;
                            cash1.side = "p";//pos
                            cash1.posId = Convert.ToInt32(cb_pos1.SelectedValue);

                            int s1 = await cashModel.Save(cash1);

                            if (!s1.Equals(0))
                            {
                                //second operation
                                CashTransfer cash2 = new CashTransfer();

                                cash2.transType = "d";//deposite
                                cash2.transNum = await cashModel.generateCashNumber(cash2.transType + "p");
                                cash2.cash = decimal.Parse(tb_cash.Text);
                                cash2.createUserId = MainWindow.userID.Value;
                                cash2.posIdCreator = MainWindow.posID.Value;
                                if (Convert.ToInt32(cb_pos2.SelectedValue) == MainWindow.posID)
                                    cash2.isConfirm = 1;
                                else cash2.isConfirm = 0;
                                cash2.side = "p";//pos
                                cash2.posId = Convert.ToInt32(cb_pos2.SelectedValue);
                                cash2.cashTransIdSource = s1;//id from first operation

                                int s2 = await cashModel.Save(cash2);

                                if (!s2.Equals(0))
                                {
                                    #region notification Object
                                    int pos1 = 0;
                                    int pos2 = 0;
                                    if ((int)cb_pos1.SelectedValue != MainWindow.posID.Value)
                                        pos1 = (int)cb_pos1.SelectedValue;
                                    if ((int)cb_pos2.SelectedValue != MainWindow.posID.Value)
                                        pos2 = (int)cb_pos2.SelectedValue;
                                    Notification not = new Notification()
                                    {
                                        title = "trTransferAlertTilte",
                                        ncontent = "trTransferAlertContent",
                                        msgType = "alert",
                                        createUserId = MainWindow.userID.Value,
                                        updateUserId = MainWindow.userID.Value,
                                    };
                                    if (pos1 != 0)
                                        await not.save(not, (int)cb_pos1.SelectedValue, "accountsAlerts_transfers", cb_pos2.Text, 0, pos1);
                                    if (pos2 != 0)
                                        await not.save(not, (int)cb_pos2.SelectedValue, "accountsAlerts_transfers", cb_pos1.Text, 0, pos2);

                                    #endregion

                                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                                    Btn_clear_Click(null, null);

                                    await RefreshCashesList();
                                    Tb_search_TextChanged(null, null);
                                }
                                else
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                            }
                        }
                        #endregion
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update"))
                {

                    #region validate
                    //chk empty cash
                    SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
                    //chk empty user
                    SectionData.validateEmptyComboBox(cb_pos1, p_errorPos1, tt_errorPos1, "trErrorEmptyFromPosToolTip");
                    //chk empty bank
                    SectionData.validateEmptyComboBox(cb_pos2, p_errorPos2, tt_errorPos2, "trErrorEmptyToPosToolTip");
                    //chk if 2 pos is the same
                    bool isSame = false;
                    if (cb_pos1.SelectedValue == cb_pos2.SelectedValue)
                        isSame = true;
                    if ((cb_pos1.SelectedIndex != -1) && (cb_pos2.SelectedIndex != -1) && (cb_pos1.SelectedValue == cb_pos2.SelectedValue))
                    {
                        SectionData.showComboBoxValidate(cb_pos1, p_errorPos1, tt_errorPos1, "trErrorSamePos");
                        SectionData.showComboBoxValidate(cb_pos2, p_errorPos2, tt_errorPos2, "trErrorSamePos");
                    }
                    #endregion

                    #region update
                    if ((!tb_cash.Text.Equals("")) && (!cb_pos1.Text.Equals("")) && (!cb_pos2.Text.Equals("")) && !isSame)
                    {
                        //first operation (pull)
                        cashtrans2.cash = decimal.Parse(tb_cash.Text);
                        cashtrans2.notes = tb_note.Text;
                        cashtrans2.posId = Convert.ToInt32(cb_pos1.SelectedValue);

                        int s1 = await cashModel.Save(cashtrans2);

                        if (!s1.Equals(0))
                        {
                            //second operation (deposit)
                            cashtrans3.cash = decimal.Parse(tb_cash.Text);
                            cashtrans3.posId = Convert.ToInt32(cb_pos2.SelectedValue);
                            cashtrans3.notes = tb_note.Text;

                            int s2 = await cashModel.Save(cashtrans3);

                            if (!s2.Equals(0))
                            {
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);

                                await RefreshCashesList();
                                Tb_search_TextChanged(null, null);
                            }
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                        }
                    }
                    #endregion

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete") || SectionData.isAdminPermision())
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
                            int b = await cashModel.deletePosTrans(cashtrans.cashTransId);

                            if (b == 1)
                            {
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopDelete"), animation: ToasterAnimation.FadeIn);
                                //clear textBoxs
                                Btn_clear_Click(sender, e);
                            }
                            else if (b == 0)
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
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {//confirm
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                if (cashtrans.cashTransId != 0)
                {
                    //if another operation not confirmed then just confirm this
                    ////if another operation is confirmed then chk balance before confirm
                    bool confirm = false;
                    if (cashtrans2.cashTransId == cashtrans.cashTransId)//chk which record is selected
                    { if (cashtrans3.isConfirm == 0) confirm = false; else confirm = true; }
                    else//chk which record is selected
                    { if (cashtrans2.isConfirm == 0) confirm = false; else confirm = true; }

                    if (!confirm) await confirmOpr();
                    else
                    {
                        Pos pos = await posModel.getById(cashtrans2.posId.Value);
                        //there is enough balance
                        if (pos.balance >= cashtrans2.cash)
                        {
                            cashtrans2.isConfirm = 1;
                            int s = await cashModel.Save(cashtrans2);
                            s = await cashModel.MovePosCash(cashtrans2.cashTransId, MainWindow.userID.Value);
                            //   if (s.Equals("transdone"))//tras done so confirm
                            if (s.Equals(1))//tras done so confirm
                                await confirmOpr();
                            else//error then do not confirm
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                        }
                        //there is not enough balance
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopNotEnoughBalance"), animation: ToasterAnimation.FadeIn);
                    }
                }
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async Task confirmOpr()
        {
            cashtrans.isConfirm = 1;
            int s = await cashModel.Save(cashtrans);
            if (!s.Equals(0))
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
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
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    #region
                    Thread t1 = new Thread(() =>
                    {
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Account\Ar\ArPosAccReport.rdlc";
                        }
                        else addpath = @"\Reports\Account\En\PosAccReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        ReportCls.checkLang();

                        clsReports.posAccReport(cashesQuery, rep, reppath, paramarr);
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
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    await RefreshCashesList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task<IEnumerable<CashTransfer>> RefreshCashesList()
        {
            cashes = await cashModel.GetCashTransferForPosAsync("all", "p");
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
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorPos1, tt_errorPos1, "trErrorEmptyFromPosToolTip");
                else if ((sender as ComboBox).Name == "cb_pos2")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorPos2, tt_errorPos2, "trErrorEmptyToPosToolTip");
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
                SectionData.ExceptionMessage(ex, this);
            }
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
                PosToName = x.pos2Name,
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);

                await RefreshCashesList();
                Tb_search_TextChanged(null, null);
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_pos1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//pos1selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                int bToId = Convert.ToInt32(cb_toBranch.SelectedValue);
                int pFromId = Convert.ToInt32(cb_pos1.SelectedValue);
                var toPos = poss.Where(p => p.branchId == bToId && p.posId != pFromId);
                cb_pos2.ItemsSource = toPos;
                cb_pos2.DisplayMemberPath = "name";
                cb_pos2.SelectedValuePath = "posId";
                cb_pos2.SelectedIndex = -1;

                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_pos2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cb_fromBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//fill pos1
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);

                int bFromId = Convert.ToInt32(cb_fromBranch.SelectedValue);
                var fromPos = poss.Where(p => p.branchId == bFromId);
                cb_pos1.ItemsSource = fromPos;
                cb_pos1.DisplayMemberPath = "name";
                cb_pos1.SelectedValuePath = "posId";
                cb_pos1.SelectedIndex = -1;

                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_toBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { //fill pos combo2
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);

                int bToId = Convert.ToInt32(cb_toBranch.SelectedValue);
                int pFromId = Convert.ToInt32(cb_pos1.SelectedValue);
                var toPos = poss.Where(p => p.branchId == bToId && p.posId != pFromId);
                cb_pos2.ItemsSource = toPos;
                cb_pos2.DisplayMemberPath = "name";
                cb_pos2.SelectedValuePath = "posId";
                cb_pos2.SelectedIndex = -1;

                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                if (name == "ComboBox")
                {
                    if ((sender as ComboBox).Name == "cb_fromBranch")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorFromBranch, tt_errorFromBranch, "trEmptyBranchToolTip");
                    if ((sender as ComboBox).Name == "cb_toBranch")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorToBranch, tt_errorToBranch, "trEmptyBranchToolTip");
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void Button_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    #region
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\Account\Ar\ArPosAccReport.rdlc";
                    }
                    else addpath = @"\Reports\Account\En\PosAccReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.posAccReport(cashesQuery, rep, reppath, paramarr);
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
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    #region
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\Account\Ar\ArPosAccReport.rdlc";
                    }
                    else addpath = @"\Reports\Account\En\PosAccReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.posAccReport(cashesQuery, rep, reppath, paramarr);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();
                    LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    #region
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
                        addpath = @"\Reports\Account\Ar\ArPosAccReport.rdlc";
                    }
                    else addpath = @"\Reports\Account\En\PosAccReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.posAccReport(cashesQuery, rep, reppath, paramarr);
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
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_pieChart_Click(object sender, RoutedEventArgs e)
        {//pie
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucposAccounts);
                /////////////////////
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    //cashesQueryExcel = cashesQuery.ToList();
                    win_lvc win = new win_lvc(cashesQuery, 8);
                    win.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                /////////////////////
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucposAccounts);
                SectionData.ExceptionMessage(ex, this);
            }

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
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

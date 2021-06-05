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
        string searchText = "";

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

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos1, MainWindow.resourcemanager.GetString("trFromPosHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos2, MainWindow.resourcemanager.GetString("trToPosHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_state, MainWindow.resourcemanager.GetString("trStateHint"));

            dg_posAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_posAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trPosTooltip");
            dg_posAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trOpperationTypeToolTip");
            dg_posAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

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

            btn_confirm.Content = MainWindow.resourcemanager.GetString("trConfirm");
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

        }
        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {

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

            #region fill pos combo1
            poss = await posModel.GetPosAsync();
            cb_pos1.ItemsSource = poss;
            cb_pos1.DisplayMemberPath = "name";
            cb_pos1.SelectedValuePath = "posId";
            cb_pos1.SelectedIndex = -1;
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

            dg_posAccounts.ItemsSource = await cashModel.GetCashTransferAsync("all", "p");
            //dg_posAccounts.ItemsSource = await RefreshCashesList();
            //Tb_search_TextChanged(null, null);

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
                    if (cashtrans.posId == MainWindow.posID.Value)
                    {
                        btn_add.IsEnabled = true;
                        btn_update.IsEnabled = true;
                        btn_delete.IsEnabled = true;
                        btn_confirm.IsEnabled = false;
                    }
                    else
                    {
                        btn_add.IsEnabled = false;
                        btn_update.IsEnabled = false;
                        btn_delete.IsEnabled = false;
                        btn_confirm.IsEnabled = true;
                    }
                    CashTransfer cashtrans2 = new CashTransfer();
                    CashTransfer cashtrans3 = new CashTransfer();

                    IEnumerable<CashTransfer> cashes2;
                    cashes2 = await cashModel.GetbySourcId("p", cashtrans.cashTransId);
                    cashtrans2 = cashes2.ToList()[0] as CashTransfer;
                    cashtrans3 = cashes2.ToList()[1] as CashTransfer;

                    MessageBox.Show(cashtrans2.transNum.ToString() + " " + cashtrans3.transNum.ToString());

                    cb_pos1.SelectedValue = cashtrans2.posId;
                    cb_pos2.SelectedValue = cashtrans3.posId;

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
            );
            RefreshCashView();
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            //chk empty cash
            SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
            //chk empty user
            SectionData.validateEmptyComboBox(cb_pos1, p_errorPos1, tt_errorPos1, "trErrorEmptyFromPosToolTip");
            //chk empty bank
            SectionData.validateEmptyComboBox(cb_pos2, p_errorPos2, tt_errorPos2, "trErrorEmptyToPosToolTip");

            if ((!tb_cash.Text.Equals("")) && (!cb_pos1.Text.Equals("")) && (!cb_pos2.Text.Equals("")))
            {
                //first operation
                CashTransfer cash1 = new CashTransfer();

                cash1.transType = "p";//pull
                cash1.transNum = await SectionData.generateNumber('p',"p");//first parameter is pull , second is pos
                cash1.cash = decimal.Parse(tb_cash.Text);
                cash1.createUserId = MainWindow.userID.Value;
                cash1.notes = tb_note.Text;
                cash1.posIdCreator = MainWindow.posID.Value;
                cash1.isConfirm = 0;
                cash1.side = "p";//pos
                cash1.posId = Convert.ToInt32(cb_pos1.SelectedValue);

                string s1 = await cashModel.Save(cash1);

                if (!s1.Equals("0"))
                {
                    //second operation
                    CashTransfer cash2 = new CashTransfer();

                    cash2.transType = "d";//deposite
                    cash2.transNum = await SectionData.generateNumber('d', "p");//first parameter is deposit , second is pos
                    cash2.cash = decimal.Parse(tb_cash.Text);
                    cash2.createUserId = MainWindow.userID.Value;
                    cash2.posIdCreator = MainWindow.posID.Value;
                    cash2.isConfirm = 0;
                    cash2.side = "p";//pos
                    cash2.posId = Convert.ToInt32(cb_pos2.SelectedValue);
                    cash2.cashTransIdSource = int.Parse(s1);//id from first operation

                    string s2 = await cashModel.Save(cash2);

                    if (!s2.Equals("0"))
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                        Btn_clear_Click(null, null);

                        dg_posAccounts.ItemsSource = await cashModel.GetCashTransferAsync("all", "p");
                        ////dg_posAccounts.ItemsSource = await RefreshCashesList();
                        ////Tb_search_TextChanged(null, null);
                        ///
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
            }
       }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            //chk empty cash
            SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
            //chk empty user
            SectionData.validateEmptyComboBox(cb_pos1, p_errorPos1, tt_errorPos1, "trErrorEmptyFromPosToolTip");
            //chk empty bank
            SectionData.validateEmptyComboBox(cb_pos2, p_errorPos2, tt_errorPos2, "trErrorEmptyToPosToolTip");

            if ((!tb_cash.Text.Equals("")) && (!cb_pos1.Text.Equals("")) && (!cb_pos2.Text.Equals("")))
            {
                ////first operation
                //cashtrans.cash = decimal.Parse(tb_cash.Text);
                //cashtrans.notes = tb_note.Text;
                //cashtrans.posIdCreator = MainWindow.posID.Value;
                //cashtrans.posId = Convert.ToInt32(cb_pos1.SelectedValue);

                ////second operation
                ////cash2.posIdCreator = MainWindow.posID.Value;
                ////cash2.posId = Convert.ToInt32(cb_pos2.SelectedValue);
                ////cash2.cashTransIdSource = int.Parse(s1);//id from first operation

                //string s = await cashModel.Save(cashtrans);

                //if (!s.Equals("0"))
                //{
                //    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);

                //    dg_posAccounts.ItemsSource = await cashModel.GetCashTransferAsync("all", "p");
                //    ////dg_posAccounts.ItemsSource = await RefreshCashesList();
                //    ////Tb_search_TextChanged(null, null);
                //}
                //else
                //    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_cash.Clear();
            cb_pos1.SelectedIndex = -1;
            cb_pos2.SelectedIndex = -1;
            tb_note.Clear();

            SectionData.clearValidate(tb_cash, p_errorCash);
            SectionData.clearComboBoxValidate(cb_pos1, p_errorPos1);
            SectionData.clearComboBoxValidate(cb_pos2, p_errorPos2);
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export

        }

        private void Tgl_IsReceived_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_IsReceived_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            await RefreshCashesList();
            Tb_search_TextChanged(null, null);
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

        private async void Cb_pos1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_pos2.IsEnabled = true;

            #region fill pos combo2
            var poss1 = cb_pos1.ItemsSource as List<Pos>;
            poss1.Remove(cb_pos1.SelectedItem as Pos);
            cb_pos2.ItemsSource = poss1;
            cb_pos2.DisplayMemberPath = "name";
            cb_pos2.SelectedValuePath = "posId";
            cb_pos2.SelectedIndex = -1;
            #endregion

        }
    }
}

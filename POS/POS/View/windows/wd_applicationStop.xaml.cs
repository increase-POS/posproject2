using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_applicationStop.xaml
    /// </summary>
    public partial class wd_applicationStop : Window
    {
        public wd_applicationStop()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }
        BrushConverter bc = new BrushConverter();
        Pos posModel = new Pos();
        IEnumerable<Pos> poss;
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashes;
        CashTransfer cashModel = new CashTransfer();
        bool isAdmin;
        string status = "";
        public int settingsPoSId = 0;
        public int userId;
        bool flag = false;
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_changePassword);

                txt_moneyIcon.Text = MainWindow.Currency;

                #region translate

                if (winLogIn.lang.Equals("en"))
                {
                     grid_changePassword.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                     grid_changePassword.FlowDirection = FlowDirection.RightToLeft;
                }

                translate();
                #endregion

                await fillPosInfo();
                await fillPos();
                isAdmin = SectionData.isAdminPermision();
                if (sender != null)
                    SectionData.EndAwait(grid_changePassword);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_changePassword);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async Task fillPos()
        {

            poss = await posModel.Get();
            var pos = poss.Where(p => p.branchId == MainWindow.branchID && p.posId != MainWindow.posID);
            cb_pos.ItemsSource = pos;
            cb_pos.DisplayMemberPath = "name";
            cb_pos.SelectedValuePath = "posId";
            cb_pos.SelectedIndex = -1;
        }
        private async Task fillPosInfo()
        {
            await MainWindow.refreshBalance();
            cashes = await cashModel.GetCashTransfer("d", "p");
            cashesQuery = cashes.Where(s => 
                                s.isConfirm == 0 && s.posId == MainWindow.posID.Value).ToList();

            if (cashesQuery.Count() == 0)
            {
                txt_balanceState.Text = MainWindow.resourcemanager.GetString("trAvailable");
                btn_save.IsEnabled = true;
            }
            else
            {
                txt_balanceState.Text = MainWindow.resourcemanager.GetString("trWaiting");
                btn_save.IsEnabled = false;
            }

            if (MainWindow.posLogIn.balance != 0)
                txt_cashValue.Text = SectionData.DecTostring(MainWindow.posLogIn.balance);
            else
                txt_cashValue.Text = "0";

            status = MainWindow.posLogIn.boxState;
            if (MainWindow.posLogIn.boxState == "c")
            {
                //yasin
                txt_balanceState.Text = MainWindow.resourcemanager.GetString("trUnavailable");
                txt_stateValue.Text = MainWindow.resourcemanager.GetString("trClosed");
                txt_stateValue.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush; ;
                tgl_isClose.IsChecked = false;
                btn_save.IsEnabled = false;
                cb_pos.IsEnabled = false;

            }
            else
            {
                //yasin
                txt_stateValue.Text = MainWindow.resourcemanager.GetString("trOpen");
                txt_stateValue.Foreground = Application.Current.Resources["mediumGreen"] as SolidColorBrush; ;
                tgl_isClose.IsChecked = true;
                cb_pos.IsEnabled = true;

            }
        }
        private void translate()
        {
            txt_title.Text = winLogIn.resourcemanager.GetString("trDailyClosing");
            txt_cash.Text = winLogIn.resourcemanager.GetString("trCash");
            txt_boxState.Text = winLogIn.resourcemanager.GetString("trBoxState");
            txt_cashBalance.Text = winLogIn.resourcemanager.GetString("trCashBalance");
            txt_transfer.Text = winLogIn.resourcemanager.GetString("trTransfer");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos, winLogIn.resourcemanager.GetString("trPosHint"));

            tt_pos.Content = winLogIn.resourcemanager.GetString("trPosTooltip");
            btn_save.Content = MainWindow.resourcemanager.GetString("trTransfer");
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    Btn_save_Click(null, null);
                }
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }
         private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_changePassword);
                if (cashesQuery.Count() > 0)
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trCantDoProcess"), animation: ToasterAnimation.FadeIn);
                else
                { 
                    bool valid = validate();
                    if (valid)
                    {
                        await transfer();
                        await fillPosInfo();
                    }
                }
                
                if (sender != null)
                    SectionData.EndAwait(grid_changePassword);

            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_changePassword);
                SectionData.ExceptionMessage(ex, this);
            }

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                cb_pos.SelectedIndex = -1;
                e.Cancel = true;
                this.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
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
        private void validateEmpty(string name, object sender)
        {
            if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_pos")
                    validateEmptyComboBox((ComboBox)sender, p_errorPos, tt_errorPos, "trErrorEmptyPosToolTip");
            }
        }
         private void validateEmptyComboBox(ComboBox cb, Path p_error, ToolTip tt_error, string tr)
        {
            if (cb.SelectedIndex == -1)
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = winLogIn.resourcemanager.GetString(tr);
                cb.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                cb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;
            }
        }

        private async void Tgl_isClose_Checked(object sender, RoutedEventArgs e)
        {
            if (flag)
                return;

            flag = true;
            ToggleButton cb = sender as ToggleButton;
            if (cb.IsFocused == true)
            {
                #region Accept
                wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxConfirm");
                w.ShowDialog();
                
                #endregion
                if (w.isOk)
                {
                    status = "o";

                    await openCloseBox(status);                   
                    await fillPosInfo();
                }
                else
                    tgl_isClose.IsChecked = false;

            }
            flag = false;
        }

        private async void Tgl_isClose_Unchecked(object sender, RoutedEventArgs e)
        {
            if (flag)
                return;
            flag = true;
            ToggleButton cb = sender as ToggleButton;
            if (cb.IsFocused == true)
            {
                if (cashesQuery.Count() > 0)
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trCantDoProcess"), animation: ToasterAnimation.FadeIn);
                    tgl_isClose.IsChecked = true;
                }
                else
                {
                    #region Accept
                    //this.Visibility = Visibility.Collapsed;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxConfirm");
                    w.ShowDialog();
                    #endregion
                    if (w.isOk)
                    {
                        status = "c";

                        await openCloseBox(status);
                        await fillPosInfo();
                    }
                    else
                        tgl_isClose.IsChecked = true;
                    //this.Visibility = Visibility.Visible;
                }
            }
            flag = false;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                //SectionData.ExceptionMessage(ex, this);
            }
        }
        #region open - close - validate
        private async Task openCloseBox(string status)
        {
            CashTransfer cashTransfer = new CashTransfer();
            cashTransfer.processType = "box";
            cashTransfer.transType = status;
            cashTransfer.cash = MainWindow.posLogIn.balance;
            cashTransfer.createUserId = MainWindow.userID.Value;
            cashTransfer.posId = (int)MainWindow.posID;
            int res = await posModel.updateBoxState((int)MainWindow.posID,status,Convert.ToInt32(isAdmin),MainWindow.userLogin.userId,cashTransfer);
            if (res > 0)
            {
                await MainWindow.refreshBalance();
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
            }
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

        }
        private async Task transfer()
        {
            //add cash transfer
            CashTransfer cash1 = new CashTransfer();

            cash1.transType = "p";//pull
            cash1.transNum = await cash1.generateCashNumber(cash1.transType + "p");
            cash1.cash = MainWindow.posLogIn.balance;
            cash1.createUserId = MainWindow.userID.Value;
            cash1.posIdCreator = MainWindow.posID.Value;
            cash1.isConfirm = 1;
            cash1.side = "p";//pos
            cash1.posId = Convert.ToInt32(MainWindow.posID.Value);

            int s1 = await cash1.Save(cash1);

            if (!s1.Equals(0))
            {
                //second operation
                CashTransfer cash2 = new CashTransfer();

                cash2.transType = "d";//deposite
                cash2.transNum = await cash2.generateCashNumber(cash2.transType + "p");
                cash2.cash = MainWindow.posLogIn.balance;
                cash2.createUserId = MainWindow.userID.Value;
                cash2.posIdCreator = MainWindow.posID.Value;
                cash2.isConfirm = 0;
                cash2.side = "p";//pos
                cash2.posId = Convert.ToInt32(cb_pos.SelectedValue);
                cash2.cashTransIdSource = s1;//id from first operation

                int s2 = await cash2.Save(cash2);
                if(s2 > 0)
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
        }
        }
        private Boolean validate()
        {
            if(MainWindow.posLogIn.balance == 0)
            {
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trZeroBalance"), animation: ToasterAnimation.FadeIn);
                return false;
            }
            SectionData.validateEmptyComboBox(cb_pos, p_errorPos, tt_errorPos, "trErrorEmptyPosToolTip");
            if (cb_pos.SelectedIndex == -1)
                return false;
            return true;
        }
        #endregion
    }
}

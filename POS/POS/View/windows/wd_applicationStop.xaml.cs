using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        public int settingsPoSId = 0;
        public int userId;
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
            txt_cashValue.Text = MainWindow.posLogIn.balance.ToString();
            if(MainWindow.posLogIn.boxState == "c")
            {
                btn_save.Content = MainWindow.resourcemanager.GetString("trOpen");
                tgl_isClose.IsEnabled = false;
                cb_pos.Visibility = Visibility.Collapsed;

                cashes = await cashModel.GetCashTransfer("d", "p");
                cashesQuery = cashes.Where(s => s.posIdCreator == MainWindow.posID.Value
                                    && s.isConfirm == 0).ToList();

            }
            else
            {
                tgl_isClose.IsEnabled = true;
                btn_save.Content = MainWindow.resourcemanager.GetString("trClose");

            }
        }
        private void translate()
        {
            txt_title.Text = winLogIn.resourcemanager.GetString("trDailyClosing");
            txt_isClose.Text = winLogIn.resourcemanager.GetString("trCashTransfer");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos, winLogIn.resourcemanager.GetString("trPosHint"));

            tt_pos.Content = winLogIn.resourcemanager.GetString("trPosTooltip");
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
                if(MainWindow.posLogIn.boxState == "c") // status is closed and we want to open the box
                {
                    if(cashesQuery.Count() > 0)
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trCantOpenBox"), animation: ToasterAnimation.FadeIn);
                    else//open box
                    await openBox();
                }
                else //status is open and we want to close the box
                {
                    if (tgl_isClose.IsChecked == true)// close with cash transfer to pos
                    {
                        bool valid = validate();
                        if (valid)
                        {
                            await closeWithTransfer();
                        }
                    }
                    else
                        await closeBox();
                }

                this.Close();
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

        private void Tgl_isClose_Checked(object sender, RoutedEventArgs e)
        {
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
            cb_pos.Visibility = Visibility.Visible;
        }

        private void Tgl_isClose_Unchecked(object sender, RoutedEventArgs e)
        {
            btn_save.Content = MainWindow.resourcemanager.GetString("trClose");
            cb_pos.Visibility = Visibility.Collapsed;
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
        private async Task openBox()
        {
            CashTransfer cashTransfer = new CashTransfer();
            cashTransfer.processType = "box";
            cashTransfer.transType = "o";
            cashTransfer.cash = MainWindow.posLogIn.balance;
            cashTransfer.createUserId = MainWindow.userID.Value;
            int res = await posModel.updateBoxState((int)MainWindow.posID,"o",Convert.ToInt32(isAdmin),MainWindow.userLogin.userId,cashTransfer);
        }
        private async Task closeBox()
        {
            CashTransfer cashTransfer = new CashTransfer();
            cashTransfer.processType = "box";
            cashTransfer.transType = "c";
            cashTransfer.cash = MainWindow.posLogIn.balance;
            cashTransfer.createUserId = MainWindow.userID.Value;
            int res = await posModel.updateBoxState((int)MainWindow.posID,"c",Convert.ToInt32(isAdmin),MainWindow.userLogin.userId,cashTransfer);
        }

        private async Task closeWithTransfer()
        {
            await closeBox();
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

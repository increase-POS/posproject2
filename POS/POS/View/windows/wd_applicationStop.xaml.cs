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

                await fillPos();

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
            var pos = poss.Where(p => p.branchId == MainWindow.branchID);
            cb_pos.ItemsSource = pos;
            cb_pos.DisplayMemberPath = "name";
            cb_pos.SelectedValuePath = "posId";
            cb_pos.SelectedIndex = -1;
        }
        private void translate()
        {

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos, winLogIn.resourcemanager.GetString("trPosHint"));

            btn_save.Content = winLogIn.resourcemanager.GetString("trSave");
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
         private void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_changePassword);

               
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

        }

        private void Tgl_isClose_Unchecked(object sender, RoutedEventArgs e)
        {

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
    }
}

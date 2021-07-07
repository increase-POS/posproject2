using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
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
    /// Interaction logic for wd_changePassword.xaml
    /// </summary>
    public partial class wd_changePassword : Window
    {
        public wd_changePassword()
        {
            InitializeComponent();
        }

        BrushConverter bc = new BrushConverter();
        public int userID = 0;
        User userModel = new User();

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region translate

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_changePassword.FlowDirection = FlowDirection.LeftToRight;

            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_changePassword.FlowDirection = FlowDirection.RightToLeft;

            }

            translate();
            #endregion
        }

        private void translate()
        {
           



        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_oldPassword_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_oldPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Pb_oldPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_newPassword_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_newPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Pb_newPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_confirmPassword_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_confirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Pb_confirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void P_showOldPassword_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void P_showOldPassword_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void P_showNewPassword_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void P_showNewPassword_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void P_showConfirmPassword_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void P_showConfirmPassword_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

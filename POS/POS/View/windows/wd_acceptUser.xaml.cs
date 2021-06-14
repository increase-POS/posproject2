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
    /// Interaction logic for wd_acceptUser.xaml
    /// </summary>
    public partial class wd_acceptUser : Window
    {
        public wd_acceptUser()
        {
            InitializeComponent();
        }
        BrushConverter bc = new BrushConverter();
        public bool isOk { get; set; }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            isOk = false;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public int userID = 0;
        User userModel = new User();
        IEnumerable<User> users;
        private void Btn_confirmation_Click(object sender, RoutedEventArgs e)
        {
            chkUser();
            if (isOk)
                this.Close();
            else
            {
                SectionData.showPasswordValidate(pb_password, p_errorPassword, tt_errorPassword, "trErrorPasswordToolTip");
                p_showPassword.Visibility = Visibility.Collapsed;
            }
        }

        private async void chkUser()
        {
            string password = Md5Encription.MD5Hash("Inc-m" + pb_password.Password);

            User user = await userModel.getUserById(userID);

            if ((tb_userName.Text.Equals(user.username)) && (password.Equals(user.password)))
                isOk = true;
            else
                isOk = false;

        }

        private void P_showPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_password.Text = pb_password.Password;
            tb_password.Visibility = Visibility.Visible;
            pb_password.Visibility = Visibility.Collapsed;
        }
        private void P_showPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_password.Visibility = Visibility.Collapsed;
            pb_password.Visibility = Visibility.Visible;
        }
        private void Tb_userName_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_userName, p_errorUserName, tt_errorUserName, "trEmptyUserNameToolTip");
        }

        private void Tb_userName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_userName, p_errorUserName, tt_errorUserName, "trEmptyUserNameToolTip");
        }
        private void Tb_password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pb_password.Password.Equals(""))
            {
                p_errorPassword.Visibility = Visibility.Visible;
                tt_errorPassword.Content = MainWindow.resourcemanager.GetString("trEmptyPasswordToolTip");
                pb_password.Background = (Brush)bc.ConvertFrom("#15FF0000");
                p_showPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                pb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_errorPassword.Visibility = Visibility.Collapsed;
                p_showPassword.Visibility = Visibility.Visible;
            }
        }

        private void Tb_password_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.clearValidate(tb_password, p_errorPassword);
        }

        private void Pb_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SectionData.clearPasswordValidate(pb_password, p_errorPassword);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

                DragMove();
            }
            catch (Exception)
            {

               
            }
        }
    }
}

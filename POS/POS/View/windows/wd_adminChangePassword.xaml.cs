using netoaster;
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
    /// Interaction logic for wd_adminChangePassword.xaml
    /// </summary>
    public partial class wd_adminChangePassword : Window
    {
        public wd_adminChangePassword()
        {
            InitializeComponent();
        }
        BrushConverter bc = new BrushConverter();
        public int userID = 0;
        User userModel = new User();
        User user = new User();

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {//load

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

            fillUsers();
        }

        private async void fillUsers()
        {
            List<User> users =  await userModel.GetUsersActive();

            cb_user.ItemsSource = users;
            cb_user.DisplayMemberPath = "username";
            cb_user.SelectedValuePath = "userId";
        }

        private void translate()
        {
            txt_title.Text = MainWindow.resourcemanager.GetString("trChangePassword");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_user, MainWindow.resourcemanager.GetString("trUserHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(pb_password, MainWindow.resourcemanager.GetString("trPasswordHint"));
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
            tt_user.Content = MainWindow.resourcemanager.GetString("trUser");
            tt_password.Content = MainWindow.resourcemanager.GetString("trPassword");
            tt_showPassword.Content = MainWindow.resourcemanager.GetString("trShowPassword");
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }

        private bool chkPasswordLength(string password)
        {
            bool b = false;
            if (password.Length < 6)
                b = true;
            return b;
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            bool wrongPasswordLength = false;
            //chk empty user
            SectionData.validateEmptyComboBox(cb_user , p_errorUser , tt_errorUser , "trEmptyUser");
            //chk empty password
            if (pb_password.Password.Equals(""))
                SectionData.showPasswordValidate(pb_password, p_errorPassword, tt_errorPassword, "trEmptyPasswordToolTip");
            else
            {
                //chk password length
                wrongPasswordLength = chkPasswordLength(pb_password.Password);
                if (wrongPasswordLength)
                    SectionData.showPasswordValidate(pb_password, p_errorPassword, tt_errorPassword, "trErrorPasswordLengthToolTip");
                else
                    SectionData.clearPasswordValidate(pb_password, p_errorPassword);
            }

            if ((!cb_user.Text.Equals("")) &&(!pb_password.Password.Equals("")) && (!wrongPasswordLength))
            {
                if (user != null)
                {
                    string password = Md5Encription.MD5Hash("Inc-m" + pb_password.Password);

                    user.password = password ;
                    string s = await userModel.saveUser(user);
                    //MessageBox.Show(s);
                    if (!s.Equals("0"))
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopPasswordChanged"), animation: ToasterAnimation.FadeIn);
                        await Task.Delay(2000);
                        this.Close();
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
            }
        }
      
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cb_user.SelectedIndex = -1;
            pb_password.Clear();
            tb_password.Clear();
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
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

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }

        private void Tb_validateEmptyTextChange(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }

        private void validateEmpty(string name, object sender)
        {
            if (name == "PasswordBox")
            {
                if ((sender as PasswordBox).Name == "pb_password")
                    if (((PasswordBox)sender).Password.Equals(""))
                        SectionData.showPasswordValidate((PasswordBox)sender, p_errorPassword, tt_errorPassword, "trEmptyPasswordToolTip");
                    else
                        SectionData.clearPasswordValidate((PasswordBox)sender , p_errorPassword);
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_user")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorUser, tt_errorUser, "trEmptyUser");
            }
        }

        private async void Cb_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select user
            user = await userModel.getUserById(Convert.ToInt32(cb_user.SelectedValue));
            //pb_password.Password = user.password;
        }
    }
}

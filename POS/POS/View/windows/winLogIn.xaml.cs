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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for winLogIn.xaml
    /// </summary>
    public partial class winLogIn : Window
    {
        public winLogIn()
        {
            InitializeComponent();
        }

        ResourceManager resourcemanager;
        string lang = "ar";

        User userModel = new User();
        User user = new User();
        IEnumerable<User> usersQuery;
        IEnumerable<User> users;

        UsersLogs userLogsModel = new UsersLogs();
        UsersLogs userLog = new UsersLogs();
        IEnumerable<UsersLogs> userLogsQuery;
        IEnumerable<UsersLogs> usersLogs;

        public BrushConverter bc = new BrushConverter();
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) { try { DragMove(); } catch (Exception) { } }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //bdrLogIn.RenderTransform = Animations.borderAnimation(-100, bdrLogIn, true);

            if (lang.Equals("en"))
            {
                resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_logs.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_logs.FlowDirection = FlowDirection.RightToLeft;
            }
            if (Properties.Settings.Default.userName != string.Empty)
            {
                txtUserName.Text = Properties.Settings.Default.userName;
                cbxRemmemberMe.IsChecked = true;

            }
            else
            {
                txtUserName.Clear();
                cbxRemmemberMe.IsChecked = false;

            }
            if(txtUserName.Text.Equals(""))
                Keyboard.Focus(txtUserName);
            else
                Keyboard.Focus(txtPassword);

            translate();
        }

        private void translate()
        {
            cbxRemmemberMe.Content = resourcemanager.GetString("trRememberMe");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txtUserName, resourcemanager.GetString("trUserName"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txtPassword, resourcemanager.GetString("trPassword"));
            txt_logIn.Text = resourcemanager.GetString("trLogIn");
            txt_close.Text = resourcemanager.GetString("trClose");
        }

        //internal static User userLogin;
        private async void btnLogIn_Click(object sender, RoutedEventArgs e)
        {//login
            clearValidate(txtUserName , p_errorUserName);
            clearPasswordValidate(txtPassword, p_errorPassword);

            users = await userModel.GetUsersActive();
            string password = Md5Encription.MD5Hash("Inc-m" + txtPassword.Password);
            string userName = txtUserName.Text;
            //check if user is exist
            if (users.Any(i => i.username.Equals(userName)))
            {
                //get user info
                user = users.Where(i => i.username == txtUserName.Text).FirstOrDefault<User>();
                if (user.password.Equals(password))
                {
                    //send user info to main window
                    MainWindow.userID = user.userId;
                    MainWindow.userLogin = user;
                    //make user online
                    user.isOnline = 1;
                    user.isActive = 1;
                    string s = await userModel.saveUser(user);
                   
                    //create lognin record
                    UsersLogs userLog = new UsersLogs();
                    userLog.posId = 53;
                    userLog.userId = user.userId;
                    string str = await userLogsModel.Save(userLog);
                    
                    if(!str.Equals("0"))
                        MainWindow.userLogInID = int.Parse(str);

                    ////open main window and close this window
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                    showPasswordValidate(txtPassword, p_errorPassword, tt_errorPassword, "trWrongPassword");
            }
            else
                showTextBoxValidate(txtUserName, p_errorUserName, tt_errorUserName, "trUserNotFound");
        }

        private  void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnLogIn_Click(null, null);
            }
        }

        private void CbxRemmemberMe_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.userName = txtUserName.Text;
            Properties.Settings.Default.Save();
        }

        private void CbxRemmemberMe_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.userName = "";
            Properties.Settings.Default.Save();
        }

        public void showTextBoxValidate(TextBox tb, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = resourcemanager.GetString(tr);
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }

        public void showPasswordValidate(PasswordBox tb, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = resourcemanager.GetString(tr);
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }

        public void clearValidate(TextBox tb, Path p_error)
        {
            tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            p_error.Visibility = Visibility.Collapsed;
        }

        public void clearPasswordValidate(PasswordBox pb, Path p_error)
        {
            pb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            p_error.Visibility = Visibility.Collapsed;
        }

        private void TxtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            clearValidate(txtUserName , p_errorUserName);
        }

        private void TxtUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            clearValidate(txtUserName, p_errorUserName);
        }

        private void TxtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            clearPasswordValidate(txtPassword , p_errorPassword);
        }

        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            clearPasswordValidate(txtPassword, p_errorPassword);
        }
    }
}

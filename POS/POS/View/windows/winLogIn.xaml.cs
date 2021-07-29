using POS.Classes;
using POS.View.Settings;
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
        string lang ;

        User userModel = new User();
        User user = new User();
        IEnumerable<User> usersQuery;
        IEnumerable<User> users;

        UsersLogs userLogsModel = new UsersLogs();
        UsersLogs userLog = new UsersLogs();

        public BrushConverter bc = new BrushConverter();
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) { try { DragMove(); } catch (Exception) { } }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        UserSetValues usLanguage = new UserSetValues();
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
         //bdrLogIn.RenderTransform = Animations.borderAnimation(-100, bdrLogIn, true);

            //get user default language
            //var person = (from p in db.People
            //              join e in db.EmailAddresses
            //              on p.BusinessEntityID equals e.BusinessEntityID
            //              where p.FirstName == "KEN"
            //              select new
            //              {
            //                  ID = p.BusinessEntityID,
            //                  FirstName = p.FirstName,
            //                  MiddleName = p.MiddleName,
            //                  LastName = p.LastName,
            //                  EmailID = e.EmailAddress1
            //              }).ToList();
            if (Properties.Settings.Default.userName != string.Empty)
            {
                txtUserName.Text = Properties.Settings.Default.userName;
                txtPassword.Password = Properties.Settings.Default.password;
                lang = Properties.Settings.Default.Lang;
                cbxRemmemberMe.IsChecked = true;
               
            }
            else
            {
                txtUserName.Clear();
                txtPassword.Clear();
                lang = "en";
                cbxRemmemberMe.IsChecked = false;
            }

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
          
            if (txtUserName.Text.Equals(""))
                Keyboard.Focus(txtUserName);
            else
                Keyboard.Focus(txtPassword);

            translate();
        }

        private async Task<string> getUserLanguage(int userId)
        {
            //users = await userModel.GetUsersActive();
            //if (users.Any(i => i.username.Equals(Properties.Settings.Default.userName)))
            //    user = users.Where(i => i.username == Properties.Settings.Default.userName).FirstOrDefault<User>();
            SettingCls setModel = new SettingCls();
            SettingCls set = new SettingCls();
            SetValues valueModel = new SetValues();
            List<SetValues> languages = new List<SetValues>();
            UserSetValues usValueModel = new UserSetValues();
            var lanSettings = await setModel.GetAll();
            set = lanSettings.Where(l => l.name == "language").FirstOrDefault<SettingCls>();

            var lanValues = await valueModel.GetAll();
            languages = lanValues.Where(vl => vl.settingId == set.settingId).ToList<SetValues>();

            List<UserSetValues> usValues = new List<UserSetValues>();
            usValues = await usValueModel.GetAll();
            if (usValues.Count > 0)
            {
                var curUserValues = usValues.Where(c => c.userId == userId);

                if (curUserValues.Count() > 0)
                {
                    foreach (var l in curUserValues)
                        if (languages.Any(c => c.valId == l.valId))
                        {
                            usLanguage = l;
                        }

                    var lan = await valueModel.GetByID(usLanguage.valId.Value);
                    return lan.value;
                }
                else return "en";
            }
            else return "en";
        }

        private void translate()
        {
            cbxRemmemberMe.Content = resourcemanager.GetString("trRememberMe");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txtUserName, resourcemanager.GetString("trUserName"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txtPassword, resourcemanager.GetString("trPassword"));
            txt_logIn.Text = resourcemanager.GetString("trLogIn");
            txt_close.Text = resourcemanager.GetString("trClose");
        }
        bool logInProcessing = true;
        void awaitSaveBtn(bool isAwait)
        {
            if (isAwait == true)
            {
                this.prg_awaitRing.IsActive = true;
                this.grid_logs.IsEnabled = false;
                this.grid_logs.Opacity = 0.6;

                //btnLogIn.IsEnabled = false;
                //wait_saveBtn.Visibility = Visibility.Visible;
                //wait_saveBtn.IsIndeterminate = true;
            }
            else
            {

                this.prg_awaitRing.IsActive = false;
                this.grid_logs.IsEnabled = true;
                this.grid_logs.Opacity = 1;

                //btnLogIn.IsEnabled = true;
                //wait_saveBtn.Visibility = Visibility.Collapsed;
                //wait_saveBtn.IsIndeterminate = false;
            }


        }
        private async void btnLogIn_Click(object sender, RoutedEventArgs e)
        {//login
            if (logInProcessing)
            {


                logInProcessing = false;
                awaitSaveBtn(true);
                clearValidate(txtUserName, p_errorUserName);
                clearPasswordValidate(txtPassword, p_errorPassword);
                string password = Md5Encription.MD5Hash("Inc-m" + txtPassword.Password);
                string userName = txtUserName.Text;
                //check if user is exist
                users = await userModel.GetUsersActive();
                if (users.Any(i => i.username.Equals(userName)))
                {
                    //get user info
                    user = users.Where(i => i.username == txtUserName.Text).FirstOrDefault<User>();
                    if (user.password.Equals(password))
                    {
                        //send user info to main window
                        MainWindow.userID = user.userId;
                        MainWindow.userLogin = user;

                        MainWindow.lang = await getUserLanguage(user.userId);
                        lang = MainWindow.lang;
                        //make user online
                        user.isOnline = 1;
                        //  user.isActive = 1;

                        //checkother
                        string str1 = await userLogsModel.checkOtherUser((int)MainWindow.userID);

                        string s = await userModel.saveUser(user);

                        //create lognin record
                        UsersLogs userLog = new UsersLogs();
                        userLog.posId = MainWindow.posID;
                        Pos posmodel = new Pos();
                        posmodel = await posmodel.getPosById((int)MainWindow.posID);
                        MainWindow.branchID = posmodel.branchId;
                        userLog.userId = user.userId;
                        string str = await userLogsModel.Save(userLog);

                        if (!str.Equals("0"))
                            MainWindow.userLogInID = int.Parse(str);

                        //remember me
                        if (cbxRemmemberMe.IsChecked.Value)
                        {
                            Properties.Settings.Default.userName = txtUserName.Text;
                            Properties.Settings.Default.password = txtPassword.Password;
                            Properties.Settings.Default.Lang = lang;
                        }
                        else
                        {
                            Properties.Settings.Default.userName = "";
                            Properties.Settings.Default.password = "";
                            Properties.Settings.Default.Lang = "";
                        }
                        Properties.Settings.Default.Save();

                        //open main window and close this window
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else
                        showPasswordValidate(txtPassword, p_errorPassword, tt_errorPassword, "trWrongPassword");
                }
                else
                    showTextBoxValidate(txtUserName, p_errorUserName, tt_errorUserName, "trUserNotFound");
                awaitSaveBtn(false);
                logInProcessing = true;
            }
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
           
        }

        private void CbxRemmemberMe_Unchecked(object sender, RoutedEventArgs e)
        {
           
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

        private void P_showPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            txtShowPassword.Text = txtPassword.Password;
            txtShowPassword.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Collapsed;
        }

        private void P_showPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            txtShowPassword.Visibility = Visibility.Collapsed;
            txtPassword.Visibility = Visibility.Visible;
        }
    }
}

﻿using POS.Classes;
using POS.View.Settings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
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
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        public static ResourceManager resourcemanager;
        public static string lang;
        public static string menuIsOpen;

        User userModel = new User();
        User user = new User();
        //IEnumerable<User> usersQuery;
        IEnumerable<User> users;

        UsersLogs userLogsModel = new UsersLogs();
        UsersLogs userLog = new UsersLogs();

        public BrushConverter bc = new BrushConverter();
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            { }
        }

        private   void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        UserSetValues usLanguage = new UserSetValues();
        UserSetValues usMenu = new UserSetValues();
        private   void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                bdrLogIn.RenderTransform = Animations.borderAnimation(-100, bdrLogIn, true);

                if (Properties.Settings.Default.userName != string.Empty)
                {
                    txtUserName.Text = Properties.Settings.Default.userName;
                    txtPassword.Password = Properties.Settings.Default.password;
                    lang = Properties.Settings.Default.Lang;
                    menuIsOpen = Properties.Settings.Default.menuIsOpen;
                    cbxRemmemberMe.IsChecked = true;

                }
                else
                {
                    txtUserName.Clear();
                    txtPassword.Clear();
                    lang = "en";
                    menuIsOpen = "close";
                    cbxRemmemberMe.IsChecked = false;
                }

                if (lang.Equals("en"))
                {
                    resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                    bdr_imageAr.Visibility = Visibility.Hidden;
                    bdr_image.Visibility = Visibility.Visible;
                }
                else
                {
                    resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                    bdr_imageAr.Visibility = Visibility.Visible;
                    bdr_image.Visibility = Visibility.Hidden;

                }

                if (txtUserName.Text.Equals(""))
                    Keyboard.Focus(txtUserName);
                else
                    Keyboard.Focus(txtPassword);

                translate();

                #region Arabic Number
                CultureInfo ci = CultureInfo.CreateSpecificCulture(Thread.CurrentThread.CurrentCulture.Name);
                ci.NumberFormat.DigitSubstitution = DigitShapes.Context;
                Thread.CurrentThread.CurrentCulture = ci;
                #endregion

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        List<UserSetValues> usValues = new List<UserSetValues>();
        private async Task<string> getUserLanguage(int userId)
        {
            SettingCls setModel = new SettingCls();
            SettingCls set = new SettingCls();
            SetValues valueModel = new SetValues();
            List<SetValues> languages = new List<SetValues>();
            UserSetValues usValueModel = new UserSetValues();
            var lanSettings = await setModel.GetAll();
            set = lanSettings.Where(l => l.name == "language").FirstOrDefault<SettingCls>();
            var lanValues = await valueModel.GetAll();

            if (lanValues.Count > 0)
            {
                languages = lanValues.Where(vl => vl.settingId == set.settingId).ToList<SetValues>();

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
        bool logInProcessing = false;
       
        private async void btnLogIn_Click(object sender, RoutedEventArgs e)
        {//login
            try
            {
                if (!logInProcessing)
                {
                    logInProcessing = true;
                    if (sender != null)
                        SectionData.StartAwait(grid_main);

                
                    //awaitSaveBtn(true);
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

                            try
                            {
                                MainWindow.lang = await getUserLanguage(user.userId);
                                lang = MainWindow.lang;
                            }
                            catch
                            {
                                MainWindow.lang = "en";
                                lang = MainWindow.lang;
                            }
                            string m = await SectionData.getUserMenuIsOpen(user.userId);
                            if (!m.Equals("-1"))
                                MainWindow.menuIsOpen = m;
                            else
                                MainWindow.menuIsOpen = "close";
                            menuIsOpen = MainWindow.menuIsOpen;
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
                                Properties.Settings.Default.menuIsOpen = menuIsOpen;
                            }
                            else
                            {
                                Properties.Settings.Default.userName = "";
                                Properties.Settings.Default.password = "";
                                Properties.Settings.Default.Lang = "";
                                Properties.Settings.Default.menuIsOpen = "";
                            }
                            Properties.Settings.Default.Save();
                           
                            //Window.GetWindow(this).Opacity = 1;
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
                    //awaitSaveBtn(false);
                    
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                logInProcessing = false;
            }
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                logInProcessing = false;
                SectionData.ExceptionMessage(ex, this);
            }
        }
        static SettingCls setModel = new SettingCls();
        static SetValues valueModel = new SetValues();
        static UserSetValues uSetValueModel = new UserSetValues();
        static SettingCls set = new SettingCls();
        static List<SetValues> pos = new List<SetValues>();
        //int settingsPosId = 0;

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);

                if (e.Key == Key.Return)
                {
                    btnLogIn_Click(btnLogIn, null);
                }
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
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
            try
            {
                clearValidate(txtUserName, p_errorUserName);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void TxtUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                clearValidate(txtUserName, p_errorUserName);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void TxtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                clearPasswordValidate(txtPassword, p_errorPassword);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                clearPasswordValidate(txtPassword, p_errorPassword);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void P_showPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                txtShowPassword.Text = txtPassword.Password;
                txtShowPassword.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void P_showPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                txtShowPassword.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
    }
}

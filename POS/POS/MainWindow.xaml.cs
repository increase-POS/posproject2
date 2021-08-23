﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using netoaster;
using POS.Classes;
using POS.View;
using POS.View.accounts;
using POS.View.reports;
using POS.View.Settings;
using POS.View.windows;
using WPFTabTip;

namespace POS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static ResourceManager resourcemanager;
        public static ResourceManager resourcemanagerreport;
        bool menuState = false;
        //ToolTip="{Binding Properties.Settings.Default.Lang}"
        public static string lang;
        public static string Reportlang = "en";
        public static string companyName;
        public static string Email;
        public static string Fax;
        public static string Mobile;
        public static string Address;
        public static CountryCode Region;
        public static string Currency;
        public static string Phone;
        internal static int? userID;
        internal static User userLogin;
        internal static int? userLogInID;
        internal static int? posID = 2;
        //مخزن الجميلية الرئيسي
        internal static int? branchID = 2;
        //مخزن الجميلية الفرقان
        //internal static int? branchID = 12;
        bool isHome = false;
        internal static int? isInvTax = 1;
        internal static decimal? tax = 2;
        internal static string dateFormat;
        internal static decimal? StorageCost = 100;
        public static int Idletime = 5;
        public static int threadtime = 5;
        public static string menuIsOpen = "close";

        static public GroupObject groupObject = new GroupObject();
        static public List<GroupObject> groupObjects = new List<GroupObject>();
        static SettingCls setModel = new SettingCls();
        static SetValues valueModel = new SetValues();
        static int nameId, addressId, emailId, mobileId, phoneId, faxId, logoId, taxId;
        public static string logoImage;
        ImageBrush myBrush = new ImageBrush();
        NotificationUser notificationUser = new NotificationUser();

        public static DispatcherTimer timer;
        DispatcherTimer idletimer;//  logout timer
        DispatcherTimer threadtimer;//  repeat timer for check other login
        DispatcherTimer notTimer;//  repeat timer for notifications

        static public MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();

            mainWindow = this;
            windowFlowDirection();

        }

        async void windowFlowDirection()
        {
            #region translate
            if (lang.Equals("en"))
            {
                resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_mainWindow.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_mainWindow.FlowDirection = FlowDirection.RightToLeft;
            }
            #endregion
        }

        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            StartAwait();
            grid_mainWindow.IsEnabled = false;

            //MessageBox.Show(MainWindow.lang +"-"+ MainWindow.Region.name +"-"+ MainWindow.Currency+"-"+MainWindow.tax +"-");
            //MessageBox.Show(MainWindow.lang + "-" + MainWindow.Region.name + "-" + MainWindow.Currency + "-" + MainWindow.tax + "-" + MainWindow.dateFormat);

            //MessageBox.Show(MainWindow.posID.ToString()+"-"+MainWindow.branchID.ToString());

            #region bonni
#pragma warning disable CS0436 // Type conflicts with imported type
            TabTipAutomation.IgnoreHardwareKeyboard = HardwareKeyboardIgnoreOptions.IgnoreAll;
#pragma warning restore CS0436 // Type conflicts with imported type
#pragma warning disable CS0436 // Type conflicts with imported type
#pragma warning restore CS0436 // Type conflicts with imported type
#pragma warning disable CS0436 // Type conflicts with imported type
            TabTipAutomation.ExceptionCatched += TabTipAutomationOnTest;
#pragma warning restore CS0436 // Type conflicts with imported type
            this.Height = SystemParameters.MaximizedPrimaryScreenHeight;
            //this.Width = SystemParameters.MaximizedPrimaryScreenHeight;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            // idle timer
            idletimer = new DispatcherTimer();
            idletimer.Interval = TimeSpan.FromMinutes(Idletime);
            idletimer.Tick += timer_Idle;
            idletimer.Start();


            //thread
            threadtimer = new DispatcherTimer();
            threadtimer.Interval = TimeSpan.FromSeconds(threadtime);
            threadtimer.Tick += timer_Thread;
            threadtimer.Start();




            #endregion

            #region get default System info


            tax = decimal.Parse(await getDefaultTax());

            dateFormat = await getDefaultDateForm();

            CountryCode c = await getDefaultRegion();
            Region = c;
            Currency = c.currency;

            StorageCost = decimal.Parse(await getDefaultStorageCost());

            List<SettingCls> settingsCls = await setModel.GetAll();
            List<SetValues> settingsValues = await valueModel.GetAll();

            SettingCls set = new SettingCls();
            SetValues setV = new SetValues();
            //get company name
            List<char> charsToRemove = new List<char>() { '@', '_', ',', '.', '-' };

            set = settingsCls.Where(s => s.name == "com_name").FirstOrDefault<SettingCls>();
            nameId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == nameId).FirstOrDefault();
            if (setV != null)
                companyName = setV.value;
            //get company address
            set = settingsCls.Where(s => s.name == "com_address").FirstOrDefault<SettingCls>();
            addressId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == addressId).FirstOrDefault();
            if (setV != null)
                Address = setV.value;
            //get company email
            set = settingsCls.Where(s => s.name == "com_email").FirstOrDefault<SettingCls>();
            emailId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == emailId).FirstOrDefault();
            if (setV != null)
                Email = setV.value;
            //get company mobile
            set = settingsCls.Where(s => s.name == "com_mobile").FirstOrDefault<SettingCls>();
            mobileId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == mobileId).FirstOrDefault();
            if (setV != null)
            {
                charsToRemove.ForEach(x => setV.value = setV.value.Replace(x.ToString(), String.Empty));
                Mobile = setV.value;
            }
            //get company phone
            set = settingsCls.Where(s => s.name == "com_phone").FirstOrDefault<SettingCls>();
            phoneId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == phoneId).FirstOrDefault();
            if (setV != null)
            {
                charsToRemove.ForEach(x => setV.value = setV.value.Replace(x.ToString(), String.Empty));
                Phone = setV.value;
            }
            //get company fax
            set = settingsCls.Where(s => s.name == "com_fax").FirstOrDefault<SettingCls>();
            faxId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == faxId).FirstOrDefault();
            if (setV != null)
            {
                charsToRemove.ForEach(x => setV.value = setV.value.Replace(x.ToString(), String.Empty));
                Fax = setV.value;
            }
            //get company logo
            set = settingsCls.Where(s => s.name == "com_logo").FirstOrDefault<SettingCls>();
            logoId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == logoId).FirstOrDefault();
            if (setV != null)
            {
                logoImage = setV.value;
                await setV.getImg(logoImage);
            }
            #endregion

            translate();

            #region user personal info
            txt_userName.Text = userLogin.name;
            txt_userJob.Text = userLogin.job;

            try
            {
                if (!string.IsNullOrEmpty(userLogin.image))
                {
                    byte[] imageBuffer = await userModel.downloadImage(userLogin.image); // read this as BLOB from your DB

                    var bitmapImage = new BitmapImage();

                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }

                    img_userLogin.Fill = new ImageBrush(bitmapImage);
                }
                else
                {
                    clearImg();
                }
            }
            catch
            {
                clearImg();
            }
            #endregion

            #region 

            groupObjects = await groupObject.GetUserpermission(userLogin.userId);

            #endregion

            //#region
            //Pos pos = new Pos();
            //pos = await pos.getPosById((int)posID);
            //txt_posLogin.Text = pos.code;
            ///////////////////////////////////////////
            //Branch branch = new Branch();
            // branch = await branch.getBranchById((int)MainWindow.branchID);
            //txt_branchLogin.Text = branch.name;
            //#endregion
            BTN_Home_Click(null, null);
            grid_mainWindow.IsEnabled = true;
            EndAwait();
            btn_reports.Visibility = Visibility.Visible;


        }
        void permission()
        {
            if (!SectionData.isAdminPermision())
                foreach (Button button in FindControls.FindVisualChildren<Button>(this))
                {
                    //if (path.Name == "path_" + button.Tag)
                    //{
                    //    //MessageBox.Show("Hey i'm in " + "path_" + button.Tag);
                    //    path.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
                    //    break;
                    //}
                    if (button.Tag != null)
                        if (MainWindow.groupObject.HasPermission(button.Tag.ToString(), MainWindow.groupObjects))
                            button.Visibility = Visibility.Visible;
                        else button.Visibility = Visibility.Collapsed;
                }
            //if (MainWindow.groupObject.HasPermission(btn_sectionData.Tag.ToString(), MainWindow.groupObjects))
            //    btn_sectionData.Visibility = Visibility.Visible;
            //else btn_sectionData.Visibility = Visibility.Collapsed;

            //if (MainWindow.groupObject.HasPermission(btn_sectionData.Tag.ToString(), MainWindow.groupObjects))
            //    btn_sectionData.Visibility = Visibility.Visible;
            //else btn_sectionData.Visibility = Visibility.Collapsed;

            //if (MainWindow.groupObject.HasPermission(btn_sectionData.Tag.ToString(), MainWindow.groupObjects))
            //    btn_sectionData.Visibility = Visibility.Visible;
            //else btn_sectionData.Visibility = Visibility.Collapsed;

            //if (MainWindow.groupObject.HasPermission(btn_sectionData.Tag.ToString(), MainWindow.groupObjects))
            //    btn_sectionData.Visibility = Visibility.Visible;
            //else btn_sectionData.Visibility = Visibility.Collapsed;

            //if (MainWindow.groupObject.HasPermission(btn_sectionData.Tag.ToString(), MainWindow.groupObjects))
            //    btn_sectionData.Visibility = Visibility.Visible;
            //else btn_sectionData.Visibility = Visibility.Collapsed;

            //if (MainWindow.groupObject.HasPermission(btn_sectionData.Tag.ToString(), MainWindow.groupObjects))
            //    btn_sectionData.Visibility = Visibility.Visible;
            //else btn_sectionData.Visibility = Visibility.Collapsed;

            //if (MainWindow.groupObject.HasPermission(btn_sectionData.Tag.ToString(), MainWindow.groupObjects))
            //    btn_sectionData.Visibility = Visibility.Visible;
            //else btn_sectionData.Visibility = Visibility.Collapsed;

            //if (MainWindow.groupObject.HasPermission(btn_sectionData.Tag.ToString(), MainWindow.groupObjects))
            //    btn_sectionData.Visibility = Visibility.Visible;
            //else btn_sectionData.Visibility = Visibility.Collapsed;
        }

        #region notifications
        private void setTimer()
        {
            notTimer = new DispatcherTimer();
            notTimer.Interval = TimeSpan.FromSeconds(30);
            notTimer.Tick += notTimer_Tick;
            notTimer.Start();
        }
        private void notTimer_Tick(object sendert, EventArgs et)
        {
            try
            {
                if (sendert != null)
                    SectionData.StartAwait(grid_main);
                setNotifications();
                if (sendert != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sendert != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sendert);
            }
        }
        private void setNotifications()
        {
            refreshNotificationCount();
        }
        private async void refreshNotificationCount()
        {
            int notCount = await notificationUser.GetCountByUserId(userID.Value);

            int previouseCount = 0;
            if (md_notificationCount.Badge != null && md_notificationCount.Badge.ToString() != "") previouseCount = int.Parse(md_notificationCount.Badge.ToString());

            if (notCount != previouseCount)
            {
                if (notCount > 9)
                {
                    notCount = 9;
                    md_notificationCount.Badge = "+" + notCount.ToString();
                }
                else if (notCount == 0) md_notificationCount.Badge = "";
                else
                    md_notificationCount.Badge = notCount.ToString();
            }
        }
        #endregion
        void timer_Idle(object sender, EventArgs e)
        {
            if (IdleClass.IdleTime.Minutes >= Idletime)
            {

                BTN_logOut_Click(null, null);
                idletimer.Stop();
            }

        }
        async void timer_Thread(object sendert, EventArgs et)
        {

            //  User thruser = new User();
            UsersLogs thrlog = new UsersLogs();
            try
            {
                thrlog = await thrlog.GetByID((int)userLogInID);
                //grid_mainWindow.IsEnabled = true;
                //EndAwait();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
                //grid_mainWindow.IsEnabled = false;
                //StartAwait();
            }

            if (thrlog.sOutDate != null)
            {
                BTN_logOut_Click(null, null);
                threadtimer.Stop();

            }

        }
        public void StartAwait()
        {
            MainWindow.mainWindow.prg_awaitRing.IsActive = true;
            MainWindow.mainWindow.grid_main.IsEnabled = false;
            MainWindow.mainWindow.grid_main.Opacity = 0.6;
        }
        public void EndAwait()
        {
            MainWindow.mainWindow.prg_awaitRing.IsActive = false;
            MainWindow.mainWindow.grid_main.IsEnabled = true;
            MainWindow.mainWindow.grid_main.Opacity = 1;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToShortTimeString();
            txtDate.Text = DateTime.Now.ToShortDateString();
        }
        private void TabTipAutomationOnTest(Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
        private static List<string> QueryWmiKeyboards()
        {
            using (var searcher = new ManagementObjectSearcher(new SelectQuery("Win32_Keyboard")))
            using (var result = searcher.Get())
            {
                return result
                    .Cast<ManagementBaseObject>()
                    .SelectMany(keyboard =>
                        keyboard.Properties
                            .Cast<PropertyData>()
                            .Where(k => k.Name == "Description")
                            .Select(k => k.Value as string))
                    .ToList();
            }
        }
        void FN_tooltipVisibility(Button btn)
        {
            ToolTip T = btn.ToolTip as ToolTip;
            if (T.Visibility == Visibility.Visible)
                T.Visibility = Visibility.Hidden;
            else T.Visibility = Visibility.Visible;
        }
        private void BTN_logOut_Click(object sender, RoutedEventArgs e)
        {
            close();
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        }
        async void close()
        {
            //log out
            //update lognin record
            await updateLogninRecord();
            timer.Stop();
            idletimer.Stop();
            threadtimer.Stop();
        }
        private void BTN_Close_Click(object sender, RoutedEventArgs e)
        {
            close();
            Application.Current.Shutdown();
        }
        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);
        //    this.RemoveLogicalChild(this.Content);    // since protected method
        //}

        private void BTN_Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        void colorTextRefreash(TextBlock txt)
        {
            txt_home.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_catalog.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_storage.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_purchases.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_sales.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_sales.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_accounting.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_reports.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_sectiondata.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_settings.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));

            txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8E8E8"));
        }
        void fn_ColorIconRefreash(Path p)
        {
            path_iconSettings.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconSectionData.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconReports.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconAccounts.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconSales.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconPurchases.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconStorage.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconCatalog.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconHome.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));

            p.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8E8E8"));
        }
        public void translate()
        {
            tt_menu.Content = resourcemanager.GetString("trMenu");
            tt_home.Content = resourcemanager.GetString("trHome");
            txt_home.Text = resourcemanager.GetString("trHome");
            tt_catalog.Content = resourcemanager.GetString("trCatalog");
            txt_catalog.Text = resourcemanager.GetString("trCatalog");
            tt_storage.Content = resourcemanager.GetString("trStore");
            txt_storage.Text = resourcemanager.GetString("trStore");
            tt_purchase.Content = resourcemanager.GetString("trPurchases");
            txt_purchases.Text = resourcemanager.GetString("trPurchases");
            tt_sales.Content = resourcemanager.GetString("trSales");
            txt_sales.Text = resourcemanager.GetString("trSales");
            tt_accounts.Content = resourcemanager.GetString("trAccounting");
            txt_accounting.Text = resourcemanager.GetString("trAccounting");
            tt_reports.Content = resourcemanager.GetString("trReports");
            txt_reports.Text = resourcemanager.GetString("trReports");
            tt_sectionData.Content = resourcemanager.GetString("trSectionData");
            txt_sectiondata.Text = resourcemanager.GetString("trSectionData");
            tt_settings.Content = resourcemanager.GetString("trSettings");
            txt_settings.Text = resourcemanager.GetString("trSettings");

            mi_changePassword.Header = resourcemanager.GetString("trChangePassword");
            BTN_logOut.Header = resourcemanager.GetString("trLogOut");
        }

        //فتح
        private async void BTN_Menu_Click(object sender, RoutedEventArgs e)
        {
            if (!menuState)
            {
                Storyboard sb = this.FindResource("Storyboard1") as Storyboard;
                sb.Begin();
                menuState = true;
            }
            else
            {
                Storyboard sb = this.FindResource("Storyboard2") as Storyboard;
                sb.Begin();
                menuState = false;
            }


            #region tooltipVisibility
            FN_tooltipVisibility(BTN_menu);
            FN_tooltipVisibility(BTN_home);
            FN_tooltipVisibility(btn_catalog);
            FN_tooltipVisibility(btn_storage);
            FN_tooltipVisibility(btn_purchase);
            FN_tooltipVisibility(btn_sales);
            FN_tooltipVisibility(btn_reports);
            FN_tooltipVisibility(btn_accounts);
            FN_tooltipVisibility(btn_sectionData);
            FN_tooltipVisibility(btn_settings);
            #endregion


        }

        //async Task<double> DoCount()
        //{
        //    return await Task<double>.Run(() =>
        //    {
        //        double d = 0;

        //        for (d = 0; d < 150000000; d++)
        //        {

        //        }
        //        return d;
        //    });
        //}

        void fn_pathOpenCollapsed()
        {
            path_openCatalog.Visibility = Visibility.Collapsed;
            path_openStorage.Visibility = Visibility.Collapsed;
            path_openPurchases.Visibility = Visibility.Collapsed;
            path_openSales.Visibility = Visibility.Collapsed;
            path_openReports.Visibility = Visibility.Collapsed;
            path_openSectionData.Visibility = Visibility.Collapsed;
            path_openSettings.Visibility = Visibility.Collapsed;
            path_openHome.Visibility = Visibility.Collapsed;
            path_openAccount.Visibility = Visibility.Collapsed;


        }

        void FN_pathVisible(Path p)
        {
            fn_pathOpenCollapsed();
            p.Visibility = Visibility.Visible;
        }


        private void BTN_Home_Click(object sender, RoutedEventArgs e)
        {

            colorTextRefreash(txt_home);
            FN_pathVisible(path_openHome);
            fn_ColorIconRefreash(path_iconHome);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_home.Instance);
            if (isHome)
            {
                uc_home.Instance.timerAnimation();
                isHome = false;
            }
            //else
            //    grid_main.Children.Add(uc_home.Instance);

            //uc_home uc = new uc_home();
            //grid_main.Children.Add(uc);

        }


        private void btn_Keyboard_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Keyboard_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Keyboard_Click(object sender, RoutedEventArgs e)
        {
            if (TabTip.Close())
            {
#pragma warning disable CS0436 // Type conflicts with imported type
                TabTip.OpenUndockedAndStartPoolingForClosedEvent();
#pragma warning restore CS0436 // Type conflicts with imported type
            }


        }

        User userModel = new User();
        UsersLogs userLogsModel = new UsersLogs();

        async Task<bool> updateLogninRecord()
        {
            //update lognin record
            UsersLogs userLog = new UsersLogs();
            userLog = await userLogsModel.GetByID(userLogInID.Value);

            await userLogsModel.Save(userLog);

            //update user record
            userLogin.isOnline = 0;
            await userModel.saveUser(userLogin);


            return true;
        }

        private void BTN_SectionData_Click(object sender, RoutedEventArgs e)
        {
            // BranchStore branchStore = new BranchStore();
            //var lst = branchStore.GetByBranchIdtable(2);
            //if (MainWindow.groupObject.HasPermission(BTN_sectionData.Tag.ToString(), MainWindow.groupObjects))
            //{
            colorTextRefreash(txt_sectiondata);
            FN_pathVisible(path_openSectionData);
            fn_ColorIconRefreash(path_iconSectionData);
            grid_main.Children.Clear();
            grid_main.Children.Add(UC_SectionData.Instance);
            //UC_SectionData uc = new UC_SectionData();
            //grid_main.Children.Add(uc);
            isHome = true;
            Button button = sender as Button;
            initializationMainTrack(button.Tag.ToString(), 0);
            //}
            //else
            //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        public void initializationMainTrack(string tag, int level)
        {
            //sp_mainTrack.Children.Clear();

            if (level == 0)
            {
                txt_secondLevelTrack.Visibility = Visibility.Collapsed;
                #region  mainWindow
                if (tag == "catalog")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trCatalog");
                else if (tag == "storage")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trStore");
                else if (tag == "purchase")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trPurchases");
                else if (tag == "sales")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trSales");
                else if (tag == "accounts")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trAccounting");
                else if (tag == "reports")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trReports");
                else if (tag == "sectionData")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trSectionData");
                else if (tag == "settings")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trSettings");
                #endregion
            }
            else if (level == 1)
            {
                txt_secondLevelTrack.Visibility = Visibility.Visible;
                #region  storage
                if (tag == "locations")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trLocation");
                else if (tag == "section")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trSection");
                else if (tag == "reciptOfInvoice")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trInvoice");
                else if (tag == "itemsStorage")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStorage");
                else if (tag == "importExport")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trMovements");
                else if (tag == "itemsDestroy")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trDestructive");
                else if (tag == "shortage")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trShortage");
                else if (tag == "inventory")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStocktaking");
                else if (tag == "storageStatistic")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStatistic");
                #endregion
                #region  Account
                else if (tag == "posAccounting")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPOS");
                else if (tag == "payments")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPayments");
                else if (tag == "received")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trReceived");
                else if (tag == "bonds")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trBonds");
                else if (tag == "banksAccounting")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trBanks");
                else if (tag == "ordersAccounting")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trOrders");
                else if (tag == "subscriptions")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trSubscriptions");
                else if (tag == "accountsStatistic")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStatistic");
                #endregion
                #region  catalog
                else if (tag == "categories")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trCategories");
                else if (tag == "item")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trItems");
                else if (tag == "properties")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trProperties");
                else if (tag == "units")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trUnits");
                else if (tag == "storageCost")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStorageCost");
                #endregion
                #region  purchase
                if (tag == "payInvoice")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trInvoice");
                else if (tag == "purchaseOrder")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trOrders");
                else if (tag == "purchaseStatistic")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStatistic");
                #endregion
                #region  sales
                if (tag == "reciptInvoice")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trInvoice");
                else if (tag == "coupon")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trCoupon");
                else if (tag == "offer")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trOffer");
                else if (tag == "package")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPackage");
                else if (tag == "quotation")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trQuotations");
                else if (tag == "salesOrders")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trOrders");
                else if (tag == "medals")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trMedals");
                else if (tag == "membership")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trMembership");
                else if (tag == "salesStatistic")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStatistic");
                #endregion
                #region  sectionData
                if (tag == "suppliers")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trSuppliers");
                else if (tag == "customers")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trCustomers");
                else if (tag == "users")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trUsers");
                else if (tag == "branches")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trBranches");
                else if (tag == "stores")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStores");
                else if (tag == "pos")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPOS");
                else if (tag == "banks")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trBanks");
                else if (tag == "cards")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trCard");
                else if (tag == "shippingCompany")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trShippingCompanies");
                #endregion
                #region  settings
                if (tag == "general")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trGeneral");
                else if (tag == "reportsSettings")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trReports");
                else if (tag == "permissions")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPermission");
                else if (tag == "emailsSetting")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trEmail");
                else if (tag == "emailTemplates")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trEmailTemplates");
                #endregion
            }
        }
        void initializationMainTrackChildren(string text)
        {
            var titleText = new TextBlock();
            titleText.Text = "> " + text;
            titleText.FontSize = 14;
            titleText.FontWeight = FontWeights.Regular;
            titleText.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            titleText.Margin = new Thickness(2.5, 1, 2.5, 1);
            sp_mainTrack.Children.Add(titleText);
        }
        private void BTN_catalog_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_catalog);
            FN_pathVisible(path_openCatalog);
            fn_ColorIconRefreash(path_iconCatalog);
            grid_main.Children.Clear();
            grid_main.Children.Add(UC_catalog.Instance);
            isHome = true;

            Button button = sender as Button;
            initializationMainTrack(button.Tag.ToString(), 0);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Mi_changePassword_Click(object sender, RoutedEventArgs e)
        {//change password
            Window.GetWindow(this).Opacity = 0.2;
            wd_changePassword w = new wd_changePassword();
            w.ShowDialog();
            Window.GetWindow(this).Opacity = 1;

            userLogin = await userModel.getUserById(w.userID);
        }


        async Task<string> getDefaultStorageCost()
        {
            SetValues v = await uc_general.getDefaultCost();
            if (v != null)
                return v.value;
            else
                return "";
        }

        async Task<string> getDefaultLanguage()
        {
            UserSetValues v = await uc_general.getDefaultLanguage();
            SetValues sVModel = new SetValues();
            SetValues sValue = new SetValues();
            sValue = await sVModel.GetByID(v.valId.Value);
            if (sValue != null)
                return sValue.value;
            else
                return "";
        }

        async Task<string> getDefaultTax()
        {
            SetValues v = await uc_general.getDefaultTax();
            if (v != null)
                return v.value;
            else
                return "";
        }

        async Task<string> getDefaultDateForm()
        {
            SetValues v = await uc_general.getDefaultDateForm();
            if (v != null)
                return v.value;
            else
                return "";
        }

        async Task<CountryCode> getDefaultRegion()
        {
            CountryCode c = await uc_general.getDefaultRegion();
            if (c != null)
                return c;
            else
                return null;
        }

        private void Mi_more_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_notifications_Click(object sender, RoutedEventArgs e)
        {
            if (bdrMain.Visibility == Visibility.Collapsed)
            {
                bdrMain.Visibility = Visibility.Visible;
                bdrMain.RenderTransform = Animations.borderAnimation(-25, bdrMain, true);
            }
            else
            {
                bdrMain.Visibility = Visibility.Collapsed;
            }
        }


        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            bdr_showAll.Visibility = Visibility.Visible;
            
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            bdr_showAll.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bdrMain.Visibility = Visibility.Collapsed;
        }

        

        private void clearImg()
        {
            Uri resourceUri = new Uri("pic/no-image-icon-90x90.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            myBrush.ImageSource = temp;
            img_userLogin.Fill = myBrush;

        }

        public void BTN_purchases_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_purchases);
            FN_pathVisible(path_openPurchases);
            fn_ColorIconRefreash(path_iconPurchases);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_purchases.Instance);
            //grid_main.Children.Add(uc_payInvoice.Instance);
            //uc_purchases uc = new uc_purchases();
            //grid_main.Children.Add(uc);
            isHome = true;
            Button button = sender as Button;
            initializationMainTrack(button.Tag.ToString(), 0);
        }

        public void BTN_sales_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_sales);
            FN_pathVisible(path_openSales);
            fn_ColorIconRefreash(path_iconSales);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_sales.Instance);
            //uc_sales uc = new uc_sales();
            //grid_main.Children.Add(uc);
            isHome = true;
            Button button = sender as Button;
            initializationMainTrack(button.Tag.ToString(), 0);
        }

        private void BTN_accounts_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_accounting);
            FN_pathVisible(path_openAccount);
            fn_ColorIconRefreash(path_iconAccounts);

            grid_main.Children.Clear();
            grid_main.Children.Add(uc_accounts.Instance);
            //uc_accounts uc = new uc_accounts();
            //grid_main.Children.Add(uc);
            isHome = true;
            Button button = sender as Button;
            initializationMainTrack(button.Tag.ToString(), 0);
        }

        private void BTN_reports_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_reports);
            FN_pathVisible(path_openReports);
            fn_ColorIconRefreash(path_iconReports);
            isHome = true;
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_reports.Instance);
            Button button = sender as Button;
            initializationMainTrack(button.Tag.ToString(), 0);
        }

        public void BTN_settings_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_settings);
            FN_pathVisible(path_openSettings);
            fn_ColorIconRefreash(path_iconSettings);
            isHome = true;
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_settings.Instance);
            Button button = sender as Button;
            initializationMainTrack(button.Tag.ToString(), 0);
        }

        private void BTN_storage_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            initializationMainTrack(button.Tag.ToString(), 0);
            colorTextRefreash(txt_storage);
            FN_pathVisible(path_openStorage);
            fn_ColorIconRefreash(path_iconStorage);
            grid_main.Children.Clear();
            grid_main.Children.Add(View.uc_storage.Instance);
            //uc_storage uc = new uc_storage();
            //grid_main.Children.Add(uc);
            isHome = true;

        }
    }
}

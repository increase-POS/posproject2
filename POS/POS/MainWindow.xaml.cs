using System;
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
using POS.Classes;
using POS.View;
using POS.View.accounts;
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
        bool menuState = false;

        public static string lang = "ar";
        public static string Reportlang = "ar";
        public static string companyName = "Increse";
        public static string Email = "m7mdbonni@gmail.com";
        public static string Fax = "0215232233";
        public static string Mobile = "+963967376542";
        public static string Address = "Aleppo";
        internal static int? userID ;
        internal static User userLogin;
        internal static int? userLogInID;
        internal static int? posID = 53;
        internal static int? branchID = 18;
        bool isHome = false;
        internal static int? isInvTax = 1;
        internal static decimal? tax = 2;
        /// <summary>
        /// //////// relative screen test
        /// </summary>



        public static double mainUcWidth, mainUcHeight, gridFormWidth, gridFormHeight,
            windowHeight, windowWidth, ucControlFormSectionWidth, ucControlFormSectionHeight,
            ucControlViewSectionWidth, ucControlViewSectionHeight;
        private void generateResponsiveVariables()
        {
            // MainWindow Size
            windowHeight = this.Height;
            windowWidth = this.Width;
            // uc_****  Size in the window
            mainUcHeight = windowHeight - 63;
            mainUcWidth = windowWidth - 75;
            // Form section Size
            ucControlFormSectionWidth = (mainUcWidth / 3) - 20;
            ucControlFormSectionHeight = mainUcHeight - 20;
            // View section Size { dataGrid + Cards + Searsh}
            ucControlViewSectionWidth = ((mainUcWidth / 3) * 2) - 20;
            ucControlViewSectionHeight = mainUcHeight - 20;

        }

        /// <summary>
        /// ////////
        /// </summary>

        DispatcherTimer timer;
        static public MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();
            //MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            //MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            generateResponsiveVariables();
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


            mainWindow = this;
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

        private void BTN_Close_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            System.Windows.Application.Current.Shutdown();
        }

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
        private void translate()
        {
            tt_menu.Content = resourcemanager.GetString("trMenu");
            tt_home.Content = resourcemanager.GetString("trHome");
            txt_home.Text = resourcemanager.GetString("trHome");
            tt_catalog.Content = resourcemanager.GetString("trCatalog");
            txt_catalog.Text = resourcemanager.GetString("trCatalog");
            tt_storage.Content = resourcemanager.GetString("trStorage");
            txt_storage.Text = resourcemanager.GetString("trStorage");
            tt_purchases.Content = resourcemanager.GetString("trPurchases");
            txt_purchases.Text = resourcemanager.GetString("trPurchases");
            tt_sales.Content = resourcemanager.GetString("trSales");
            txt_sales.Text = resourcemanager.GetString("trSales");
            tt_accounting.Content = resourcemanager.GetString("trAccounting");
            txt_accounting.Text = resourcemanager.GetString("trAccounting");
            tt_reports.Content = resourcemanager.GetString("trReports");
            txt_reports.Text = resourcemanager.GetString("trReports");
            tt_sectiondata.Content = resourcemanager.GetString("trSectionData");
            txt_sectiondata.Text = resourcemanager.GetString("trSectionData");
            tt_settings.Content = resourcemanager.GetString("trSettings");
            txt_settings.Text = resourcemanager.GetString("trSettings");
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
            FN_tooltipVisibility(BTN_catalog);
            FN_tooltipVisibility(BTN_storage);
            FN_tooltipVisibility(BTN_purchases);
            FN_tooltipVisibility(BTN_sales);
            FN_tooltipVisibility(BTN_reports);
            FN_tooltipVisibility(BTN_accounts);
            FN_tooltipVisibility(BTN_sectionData);
            FN_tooltipVisibility(BTN_settings);
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
     
        private async void BTN_logOut_Click(object sender, RoutedEventArgs e)
        {//log out
            //update lognin record
            UsersLogs userLog = new UsersLogs();
            userLog = await userLogsModel.GetByID(userLogInID.Value);
            await userLogsModel.Save(userLog);

            //update user record
            userLogin.isOnline = 0;
            userLogin.isActive = 1;
            await userModel.saveUser(userLogin);

            //open login window and close this window
            winLogIn log = new winLogIn();
            log.Show();
            this.Close();
        }

        private void BTN_SectionData_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_sectiondata);
            FN_pathVisible(path_openSectionData);
            fn_ColorIconRefreash(path_iconSectionData);
            grid_main.Children.Clear();
            grid_main.Children.Add(UC_SectionData.Instance);
            //UC_SectionData uc = new UC_SectionData();
            //grid_main.Children.Add(uc);
            isHome = true;


        }

        private void BTN_catalog_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_catalog);
            FN_pathVisible(path_openCatalog);
            fn_ColorIconRefreash(path_iconCatalog);
            grid_main.Children.Clear();
            grid_main.Children.Add(UC_catalog.Instance);
            //UC_catalog uc = new UC_catalog();
            //grid_main.Children.Add(uc);
            isHome = true;

        }
        ImageBrush myBrush = new ImageBrush();
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            //translate
            if (lang.Equals("en"))
            { resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_mainWindow.FlowDirection = FlowDirection.LeftToRight; }
            else
            { resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_mainWindow.FlowDirection = FlowDirection.RightToLeft; }
            translate();
            //user info
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
            BTN_Home_Click(null, null);
        }

        private void clearImg()
        {
            Uri resourceUri = new Uri("pic/no-image-icon-90x90.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            myBrush.ImageSource = temp;
            img_userLogin.Fill = myBrush;

        }

        private void BTN_purchases_Click(object sender, RoutedEventArgs e)
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

        }

        private void BTN_sales_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_sales);
            FN_pathVisible(path_openSales);
            fn_ColorIconRefreash(path_iconSales);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_sales.Instance);
            //uc_sales uc = new uc_sales();
            //grid_main.Children.Add(uc);
            isHome = true;

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

        }

        private void BTN_reports_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_reports);
            FN_pathVisible(path_openReports);
            fn_ColorIconRefreash(path_iconReports);
            isHome = true;

        }

        private void BTN_settings_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_settings);
            FN_pathVisible(path_openSettings);
            fn_ColorIconRefreash(path_iconSettings);
            isHome = true;
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_settings.Instance);
        }

        private void BTN_storage_Click(object sender, RoutedEventArgs e)
        {
            colorTextRefreash(txt_storage);
            FN_pathVisible(path_openStorage);
            fn_ColorIconRefreash(path_iconStorage);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_storage.Instance);
            //uc_storage uc = new uc_storage();
            //grid_main.Children.Add(uc);
            isHome = true;

        }
    }
}

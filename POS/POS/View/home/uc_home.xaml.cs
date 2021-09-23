using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_home.xaml
    /// </summary>
    public partial class uc_home : UserControl
    {
        int x;
        int y;
        int z;
        int value_items;
        int value_purchase;
        int value_sales;
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer1 = new DispatcherTimer();
        private static uc_home _instance;
        public static uc_home Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_home();
                return _instance;
            }
        }
       
        public uc_home()
        {
            InitializeComponent();
            timerAnimation();
        }
        int NumberDaysInMonth { get; set; }
        DispatcherTimer threadtimer;
        public static int secondTimer10 = 10;
        public static int secondTimer30 = 30;
        int SkipBestSeller = 0;
        int SkipIUStorage = 0;
        bool firstLoad = true;
        string branchesPermission = "dashboard_branches";
        Dash dash = new Dash();
        User user = new User();
        //List<User> users = new List<User>();
        ImageBrush brush = new ImageBrush();
        
        public List<BestSeller> listBestSeller { get; set; }
        public List<TotalPurSale> listMonthlyInvoice { get; set; }
        public List<IUStorage> listIUStorage { get; set; }
        public List<ItemUnit> IUList = new List<ItemUnit>();
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await SectionData.fillBranchesWithAll(cb_branch);
            cb_branch.SelectedValue = MainWindow.branchID;
            if (MainWindow.groupObject.HasPermissionAction(branchesPermission, MainWindow.groupObjects, "one"))
            cb_branch.IsEnabled = true;
            else cb_branch.IsEnabled = false;


            SkipBestSeller = 0;
            SkipIUStorage = 0;
            firstLoad = true;
            //await BestSeller();
            //paginationBestSeller(listBestSeller, Skip);

            #region Purchase and Sales
            /*
            double[] ArrayS = new double[30];
            double[] ArrayP = new double[30];
            string[] ArrayCount = new string[30];
            Random rnd = new Random();

            for (int i = 0; i < 30; i++)
            {
                ArrayS[i] = rnd.Next(1800, 2500);
                ArrayP[i] = rnd.Next(1500, int.Parse(ArrayS[i].ToString()));
                ArrayCount[i] = i.ToString();
            }
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "المبيعات",
                    Values = ArrayS.AsChartValues()
                },
                 new LineSeries
                {
                    Title = "المشتريات",
                    Values = ArrayP.AsChartValues()
                }
            };


            Labels = ArrayCount;
            YFormatter = value => value.ToString("C");
            DataContext = this;
            */
            #endregion
            #region user online 
            //SeriesCollection seriesUser = new SeriesCollection();
            //seriesUser.Add(
            //     new PieSeries
            //     {
            //         Values = new ChartValues<int> { 5 },
            //         Title = "",
            //         DataLabels = false,
            //         Fill = Application.Current.Resources["mediumGreen"] as SolidColorBrush
            //     }
            // );
            //seriesUser.Add(
            //     new PieSeries
            //     {
            //         Values = new ChartValues<int> { 15 - 5 },
            //         Title = "",
            //         DataLabels = false,
            //         Fill = Application.Current.Resources["MainColorlightGrey"] as SolidColorBrush
            //     }
            // );
            //pch_userOnline.Series = seriesUser;

            //#region userImageLoad
            //grid_userImages.Children.Clear();
            //users = await user.GetUsersActive();
            //int userCount = 0;
            //foreach (var item in users)
            //{
            //    if (userCount > 4)
            //    {
            //        Grid grid = new Grid();
            //        grid.Margin = new Thickness(-5, 0, -5, 0);
            //        Grid.SetColumn(grid, 4);
            //        #region rectangle
            //        Rectangle rectangle = new Rectangle();
            //        rectangle.Fill = Application.Current.Resources["Orange"] as SolidColorBrush;
            //        rectangle.RadiusX = 90;
            //        rectangle.RadiusY = 90;
            //        rectangle.Height = 40;
            //        rectangle.Width = 40;
            //        rectangle.StrokeThickness = 1;
            //        rectangle.Stroke = Application.Current.Resources["White"] as SolidColorBrush; ;
            //        grid.Children.Add(rectangle);
            //        #endregion
            //        #region rectangle
            //        TextBlock textBlock = new TextBlock();
            //        textBlock.Text = "+"+ (users.Count() - 4).ToString();
            //        textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            //        textBlock.VerticalAlignment = VerticalAlignment.Center;
            //        textBlock.FontWeight = FontWeights.Bold;
            //        textBlock.Foreground = Application.Current.Resources["White"] as SolidColorBrush;
            //        grid.Children.Add(textBlock);
            //        #endregion
            //        grid_userImages.Children.Add(grid);
            //        break;
            //    }
            //    else
            //    {
            //        Ellipse ellipse = new Ellipse();
            //        ellipse.Margin = new Thickness(-5, 0, -5, 0);
            //        ellipse.StrokeThickness = 1;
            //        ellipse.Stroke = Application.Current.Resources["White"] as SolidColorBrush;
            //        ellipse.Height = 40;
            //        ellipse.Width = 40;
            //        ellipse.FlowDirection = FlowDirection.LeftToRight;
            //        ellipse.ToolTip = item.username;
            //        userImageLoad(ellipse, item.image);
            //        Grid.SetColumn(ellipse, userCount);
            //        grid_userImages.Children.Add(ellipse);
            //        userCount++;
            //    }
            //}
            //#endregion
            #endregion
            #region Branch 
            /*
            SeriesCollection seriesBranch = new SeriesCollection();
            seriesBranch.Add(
                 new PieSeries
                 {
                     Values = new ChartValues<int> { 2 },
                     Title = "",
                     DataLabels = false,
                     Fill = Application.Current.Resources["mediumGreen"] as SolidColorBrush
                 }
             );
            seriesBranch.Add(
                 new PieSeries
                 {
                     Values = new ChartValues<int> { 10 - 2 },
                     Title = "",
                     DataLabels = false,
                     Fill = Application.Current.Resources["MainColorlightGrey"] as SolidColorBrush
                 }
             );
            pch_branch.Series = seriesBranch;
            */
            #endregion
            #region DailyPurchaseInvoice
            /*SeriesCollection seriesDailyPurchaseInvoice = new SeriesCollection();
            seriesDailyPurchaseInvoice.Add(
                 new PieSeries
                 {
                     Values = new ChartValues<int> { 43 },
                     Title = "",
                     DataLabels = false,
                     Fill = Application.Current.Resources["mediumGreen"] as SolidColorBrush
                 }
             );
            seriesDailyPurchaseInvoice.Add(
                 new PieSeries
                 {
                     Values = new ChartValues<int> { 1165 - 43 },
                     Title = "",
                     DataLabels = false,
                     Fill = Application.Current.Resources["MainColorlightGrey"] as SolidColorBrush
                 }
             );
            pch_dailyPurchaseInvoice.Series = seriesDailyPurchaseInvoice;
           */
            #endregion
            #region DailySalesInvoice
            /*SeriesCollection seriesDailySalesInvoice = new SeriesCollection();
            seriesDailySalesInvoice.Add(
                 new PieSeries
                 {
                     Values = new ChartValues<int> { 257 },
                     Title = "",
                     DataLabels = false,
                     Fill = Application.Current.Resources["mediumGreen"] as SolidColorBrush
                 }
             );
            seriesDailySalesInvoice.Add(
                 new PieSeries
                 {
                     Values = new ChartValues<int> { 7258 - 257 },
                     Title = "",
                     DataLabels = false,
                     Fill = Application.Current.Resources["MainColorlightGrey"] as SolidColorBrush
                 }
             );
            pch_dailySalesInvoice.Series = seriesDailySalesInvoice;
            */
            #endregion


            refrishIUList(MainWindow.itemUnitsUsers);




            CalculateNumberDaysInMonth calculate = new CalculateNumberDaysInMonth();
            NumberDaysInMonth = calculate.getdays(DateTime.Now);
            //thread 30
            threadtimer = new DispatcherTimer();
            threadtimer.Interval = TimeSpan.FromSeconds(secondTimer30);
            threadtimer.Tick += timer_Thread30;
            threadtimer.Start();
            ////////////////////
            /// //thread 10
            threadtimer = new DispatcherTimer();
            threadtimer.Interval = TimeSpan.FromSeconds(secondTimer10);
            threadtimer.Tick += timer_Thread10;
            threadtimer.Start();
            ////////////////////
            await refreshView();

        }
        void timer_Thread30(object sendert, EventArgs et)
        {
            try
            {
                refreshView();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void timer_Thread10(object sendert, EventArgs et)
        {
            try
            {
                #region BestSeller
                if (!firstLoad)
                {
                    if (listBestSeller.Count < 4 || SkipBestSeller == 2)
                        SkipBestSeller = 0;
                    else if (listBestSeller.Count < 7 && SkipBestSeller < 1)
                        SkipBestSeller++;
                    else if (listBestSeller.Count < 10 && SkipBestSeller < 2)
                        SkipBestSeller++;
                }
                paginationBestSeller(listBestSeller, SkipBestSeller);
                #endregion
                #region IUStorage
                if (!firstLoad)
                    if (listIUStorage.Count < 4 || SkipIUStorage == 2)
                        SkipIUStorage = 0;
                    else if (listIUStorage.Count < 7 && SkipIUStorage < 1)
                        SkipIUStorage++;
                    else if (listIUStorage.Count < 10 && SkipIUStorage < 2)
                        SkipIUStorage++;
                paginationIUStorage(listIUStorage, SkipIUStorage);
                #endregion

                firstLoad = false;

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task refreshView()
        {
            await AllSalPur();
            await CountMonthlySalPur();
            await DailySalPur();
            await AgentCount();
            await UserOnline();
            await BranchOnline();
            #region BestSeller
            await BestSeller();
        //    if (!firstLoad)
        //    {
        //        if (listBestSeller.Count < 4 || Skip == 2)
        //            Skip = 0;
        //        else if (listBestSeller.Count < 7 && Skip < 1)
        //            Skip++;
        //        else if (listBestSeller.Count < 10 && Skip < 2)
        //            Skip++;
        //}
            paginationBestSeller(listBestSeller, SkipBestSeller);
            //firstLoad = false;
            #endregion
            #region IUStorage
            await IUStorage();
            paginationIUStorage(listIUStorage, SkipIUStorage);
            #endregion
            await UserOnlinePic();
            await AmountMonthlySalPur();






            this.DataContext = new Dash();
            this.DataContext = dash;

        }
        async Task AllSalPur()
        {
            try
            {
                List<InvoiceCount> listSalPur = await dash.Getdashsalpur();
                if (cb_branch.SelectedValue != null)
                    if ((int)cb_branch.SelectedValue == 0)
                    {
                        dash.countAllPurchase = listSalPur.Sum(x => x.purCount).ToString();
                        dash.countAllSalesValue = listSalPur.Sum(x => x.saleCount).ToString();
                    }
                    else
                    {
                        var newSalPur = listSalPur.Where(s => s.branchCreatorId == (int)cb_branch.SelectedValue).FirstOrDefault();
                        if (newSalPur != null)
                        {
                            dash.countAllPurchase = newSalPur.purCount.ToString();
                            dash.countAllSalesValue = newSalPur.saleCount.ToString();
                        }
                        else
                            dash.countAllPurchase = dash.countAllSalesValue = "0";
                    }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task CountMonthlySalPur()
        {
            try
            {
                List<TotalPurSale> listSalPur = await dash.GetTotalPurSale();
                if (cb_branch.SelectedValue != null)
                    if ((int)cb_branch.SelectedValue == 0)
                    {
                        dash.countMonthlyPurchase = listSalPur.Sum(x => x.countPur).ToString();
                        dash.countMonthlySales = listSalPur.Sum(x => x.countSale).ToString();
                    }
                    else
                    {
                        var newSalPur = listSalPur.Where(s => s.branchCreatorId == (int)cb_branch.SelectedValue).FirstOrDefault();
                        if (newSalPur != null)
                        {
                            dash.countMonthlyPurchase = newSalPur.countPur.ToString();
                            dash.countMonthlySales = newSalPur.countSale.ToString();
                        }
                        else
                            dash.countMonthlyPurchase = dash.countMonthlySales = "0";
                    }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task DailySalPur()
        {
            try
            {
                List<InvoiceCount> listSalPur = await dash.GetdashsalpurDay();
                if (cb_branch.SelectedValue != null)
                    if ((int)cb_branch.SelectedValue == 0)
                    {
                        dash.countDailyPurchase = listSalPur.Sum(x => x.purCount).ToString();
                        dash.countDailySales = listSalPur.Sum(x => x.saleCount).ToString();
                    }
                    else
                    {
                        var newSalPur = listSalPur.Where(s => s.branchCreatorId == (int)cb_branch.SelectedValue).FirstOrDefault();
                        if (newSalPur != null)
                        {
                            dash.countDailyPurchase = newSalPur.purCount.ToString();
                            dash.countDailySales = newSalPur.saleCount.ToString();
                        }
                        else
                            dash.countDailyPurchase = dash.countDailySales = "0";
                    }
                InitializePieChart(pch_dailyPurchaseInvoice,
                    int.Parse(dash.countDailyPurchase),
                    (int.Parse(dash.countDailyPurchase) + int.Parse(dash.countMonthlyPurchase)));

                InitializePieChart(pch_dailySalesInvoice,
                    int.Parse(dash.countDailySales),
                    (int.Parse(dash.countDailySales) + int.Parse(dash.countMonthlySales)));
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task AgentCount()
        {
            try
            {
                List<AgentsCount> listAgentCount = await dash.GetAgentCount();
                var newAgentCount = listAgentCount.FirstOrDefault();
                        if (newAgentCount != null)
                        {
                            dash.customerCount = newAgentCount.customerCount.ToString();
                            dash.vendorCount = newAgentCount.vendorCount.ToString();
                        }
                        else
                        {
                            dash.customerCount = dash.vendorCount = "0";
                        }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task UserOnline()
        {
            try
            {
                List<UserOnlineCount> listUserOnline = await dash.Getuseronline();
                    if (cb_branch.SelectedValue != null)
                    if ((int)cb_branch.SelectedValue == 0)
                    {
                        dash.userOnline = listUserOnline.Sum(x => x.userOnlineCount).ToString();
                        dash.userOffline = listUserOnline.Sum(x => x.offlineUsers).ToString();
                    }
                    else
                    {
                    var newUserOnline = listUserOnline.Where(s => s.branchId == (int)cb_branch.SelectedValue).FirstOrDefault();
                        if (newUserOnline != null)
                        {
                            dash.userOnline = newUserOnline.userOnlineCount.ToString();
                            dash.userOffline = newUserOnline.offlineUsers.ToString();
                        }
                        else
                            dash.userOnline = dash.userOffline = "0";
                    }
                    InitializePieChart(pch_userOnline, 
                    int.Parse(dash.userOnline),
                    (int.Parse(dash.userOnline) + int.Parse(dash.userOffline)));
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task UserOnlinePic()
        {
            try
            {
                dash.listUserOnline = await dash.GetuseronlineInfo();
                if (cb_branch.SelectedValue != null)
                    if ((int)cb_branch.SelectedValue == 0)
                    {
                        InitializeUserOnlinePic(dash.listUserOnline);
                    }
                    else
                    {
                        List<userOnlineInfo> newUserOnline = dash.listUserOnline.Where(s => s.branchId == (int)cb_branch.SelectedValue).ToList();
                        if (newUserOnline != null && newUserOnline.Count != 0)
                        {
                        InitializeUserOnlinePic(newUserOnline);
                        }
                        else
                            InitializeNoUserOnlinePic();
                    }
                InitializePieChart(pch_userOnline,
                int.Parse(dash.userOnline),
                (int.Parse(dash.userOnline) + int.Parse(dash.userOffline)));
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void InitializeUserOnlinePic(List<userOnlineInfo> users)
        {
            #region userImageLoad
            grid_userImages.Children.Clear();
            int userCount = 0;
            foreach (var item in users)
            {
                if (userCount > 4)
                //if (true)
                {
                    #region Button
                    Button button = new Button();
                    button.Padding =  new Thickness(0,0,0,0);
                    button.Margin = new Thickness(-5, 0, -5, 0);
                    button.Background = null;
                    button.BorderBrush = null;
                    button.Height = 40;
                    button.Width = 40;
                    button.Click += userOnlineListWindow;
                    Grid.SetColumn(button, 4);
                    #region grid
                    Grid grid = new Grid();
                    //grid.Margin = new Thickness(-5, 0, -5, 0);
                    //Grid.SetColumn(grid, 4);
                    #region rectangle
                    Rectangle rectangle = new Rectangle();
                    rectangle.Fill = Application.Current.Resources["Orange"] as SolidColorBrush;
                    rectangle.RadiusX = 90;
                    rectangle.RadiusY = 90;
                    rectangle.Height = 40;
                    rectangle.Width = 40;
                    rectangle.StrokeThickness = 1;
                    rectangle.Stroke = Application.Current.Resources["White"] as SolidColorBrush; ;
                    grid.Children.Add(rectangle);
                    #endregion
                    #region Text
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = "+" + (users.Count() - 4).ToString();
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock.VerticalAlignment = VerticalAlignment.Center;
                    textBlock.FontWeight = FontWeights.Bold;
                    textBlock.Foreground = Application.Current.Resources["White"] as SolidColorBrush;
                    grid.Children.Add(textBlock);
                    #endregion
                    #endregion
                    button.Content = grid;
                    #endregion


                    grid_userImages.Children.Add(button);
                    break;
                }
                else
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Margin = new Thickness(-5, 0, -5, 0);
                    ellipse.StrokeThickness = 1;
                    ellipse.Stroke = Application.Current.Resources["White"] as SolidColorBrush;
                    ellipse.Height = 40;
                    ellipse.Width = 40;
                    ellipse.FlowDirection = FlowDirection.LeftToRight;
                    ellipse.ToolTip = item.userName;
                    userImageLoad(ellipse, item.image);
                    Grid.SetColumn(ellipse, userCount);
                    grid_userImages.Children.Add(ellipse);
                    userCount++;
                }
            }
            #endregion
        }
        void InitializeNoUserOnlinePic()
        {
            grid_userImages.Children.Clear();
            Grid grid = new Grid();
            grid.Margin = new Thickness(-5, 0, -5, 0);
            Grid.SetColumn(grid, 4);
            #region rectangle
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = Application.Current.Resources["Orange"] as SolidColorBrush;
            rectangle.RadiusX = 90;
            rectangle.RadiusY = 90;
            rectangle.Height = 40;
            rectangle.Width = 40;
            rectangle.StrokeThickness = 1;
            rectangle.Stroke = Application.Current.Resources["White"] as SolidColorBrush; ;
            grid.Children.Add(rectangle);
            #endregion
            #region rectangle
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "0";
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.FontWeight = FontWeights.Bold;
            textBlock.Foreground = Application.Current.Resources["White"] as SolidColorBrush;
            grid.Children.Add(textBlock);
            #endregion
            grid_userImages.Children.Add(grid);
        }
        async Task BranchOnline()
        {
            try
            {
                List<BranchOnlineCount> listBranchOnline = await dash.GetBrachonline();
                var newBranchOnline = listBranchOnline.FirstOrDefault();
                if (newBranchOnline != null)
                {
                    dash.branchOnline = newBranchOnline.branchOnline.ToString();
                    dash.branchOffline = newBranchOnline.branchOffline.ToString();
                }
                else
                    dash.branchOnline = dash.branchOffline  = "0";
                InitializePieChart(pch_branch,
                    int.Parse(dash.branchOnline),
                    (int.Parse(dash.branchOnline) + int.Parse(dash.branchOffline)));
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void userOnlineListWindow(object sender, RoutedEventArgs e)
        {
            
                 Window.GetWindow(this).Opacity = 0.2;
            wd_usersOnline w = new wd_usersOnline();
            w.usersOnline = dash.listUserOnline;
            w.ShowDialog();
            Window.GetWindow(this).Opacity = 1;
        }

        #region BestSeller
        async Task BestSeller()
        {
            try
            {
                List<BestSeller> listAllBestSeller = await dash.Getbestseller();
                if (cb_branch.SelectedValue != null)
                    if ((int)cb_branch.SelectedValue == 0)
                    {
                        listBestSeller = listAllBestSeller.GroupBy(x => new { x.itemName, x.unitName }).Select(s => new BestSeller
                        {
                            itemName = s.FirstOrDefault().itemName,
                            unitName = s.FirstOrDefault().unitName,
                            quantity = s.Sum(g => g.quantity),
                            //subTotal = s.Sum(g => g.subTotal),
                        }).ToList();
                        //paginationBestSeller(dash.listBestSeller);
                    }
                    else
                    {
                        listBestSeller = listAllBestSeller.Where(s => s.branchCreatorId == (int)cb_branch.SelectedValue).ToList();
                        if (listBestSeller != null)
                        {
                            listBestSeller = listBestSeller.GroupBy(x => new { x.itemName, x.unitName }).Select(s => new BestSeller
                            {
                                itemName = s.FirstOrDefault().itemName,
                                unitName = s.FirstOrDefault().unitName,
                                quantity = s.Sum(g => g.quantity),
                                //subTotal = s.Sum(g => g.subTotal),
                            }).ToList();
                            //paginationBestSeller(dash.listBestSeller);
                        }
                        else
                            listBestSeller =new List<BestSeller>();
                    }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void paginationBestSeller(List<BestSeller> listBestSeller, int skip )
        {
            grid_bestSeller.Children.Clear();
            int order = (skip*3)+1;
            int row = 1;
            listBestSeller = listBestSeller.Skip(skip * 3).Take(3).ToList();
            foreach (var item in listBestSeller)
            {
                InitializeBestSellerRow(order.ToString(), item.itemName + "-" + item.unitName,
                  item.quantity.ToString(), row);
                order++;
                row += 2;
            }

            #region Border
            #region   firstBorder 
            var firstBorder = new Border();
            firstBorder.Margin = new Thickness(10, 2.5, 10, 2.5);
            firstBorder.Height = 1;
            firstBorder.BorderThickness = new Thickness(0, 0, 0, 0);
            firstBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#C2F3E8"));
            Grid.SetRow(firstBorder, 2);
            Grid.SetColumnSpan(firstBorder, 7);
            #endregion
            #region   firstBorder 
            var secondBorder = new Border();
            secondBorder.Margin = new Thickness(10, 2.5, 10, 2.5);
            secondBorder.Height = 1;
            secondBorder.BorderThickness = new Thickness(0, 0, 0, 0);
            secondBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#C2F3E8"));
            Grid.SetRow(secondBorder, 4);
            Grid.SetColumnSpan(secondBorder, 7);
            #endregion
            grid_bestSeller.Children.Add(firstBorder);
            grid_bestSeller.Children.Add(secondBorder);
            #endregion


        }
        void InitializeBestSellerRow(string No,string item, string count, int row )
        {
            #region   itemNo
            var itemNo = new TextBlock();
            itemNo.Text = "#" + No;
            itemNo.Tag = "itemTitle";
            itemNo.VerticalAlignment = VerticalAlignment.Center;
            itemNo.HorizontalAlignment = HorizontalAlignment.Center;
            itemNo.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D75B8"));
            itemNo.FontSize = 16;
            itemNo.Margin = new Thickness(2.5, 1, 2.5, 1);
            Grid.SetRow(itemNo, row);
            Grid.SetColumn(itemNo, 0);
            #endregion
            #region   itemTitle
            var itemTitle = new TextBlock();
            itemTitle.Text = "Item:";
            itemTitle.Tag = "itemTitle";
            itemTitle.VerticalAlignment = VerticalAlignment.Center;
            itemTitle.HorizontalAlignment = HorizontalAlignment.Center;
            itemTitle.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#707070"));
            itemTitle.FontSize = 16;
            itemTitle.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(itemTitle, row);
            Grid.SetColumn(itemTitle, 1);
            #endregion
            #region   itemName
            var itemName = new TextBlock();
            itemName.Text = item;
            itemName.Tag = "itemName";
            itemName.VerticalAlignment = VerticalAlignment.Center;
            itemName.HorizontalAlignment = HorizontalAlignment.Left;
            itemName.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#707070"));
            itemName.FontSize = 16;
            itemName.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(itemName, row);
            Grid.SetColumn(itemName, 2);
            #endregion
            #region   countTitle
            var countTitle = new TextBlock();
            countTitle.Text = "Count:";
            countTitle.Tag = "countTitle";
            countTitle.VerticalAlignment = VerticalAlignment.Center;
            countTitle.HorizontalAlignment = HorizontalAlignment.Center;
            countTitle.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#707070"));
            countTitle.FontSize = 16;
            countTitle.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(countTitle, row);
            Grid.SetColumn(countTitle, 3);
            #endregion
            #region   countItem
            var countItem = new TextBlock();
            countItem.Text = count;
            countItem.Tag = "itemName";
            countItem.VerticalAlignment = VerticalAlignment.Center;
            countItem.HorizontalAlignment = HorizontalAlignment.Left;
            countItem.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D75B8"));
            countItem.FontSize = 16;
            countItem.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(countItem, row);
            Grid.SetColumn(countItem, 4);
            #endregion
            /*
            #region   amountTitle
            var amountTitle = new TextBlock();
            amountTitle.Text = "Amount:";
            amountTitle.Tag = "amountTitle";
            amountTitle.VerticalAlignment = VerticalAlignment.Center;
            amountTitle.HorizontalAlignment = HorizontalAlignment.Center;
            amountTitle.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#707070"));
            amountTitle.FontSize = 16;
            amountTitle.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(amountTitle, row);
            Grid.SetColumn(amountTitle, 5);
            #endregion
            #region amountStackPanel
            var amountStackPanel = new StackPanel();
            amountStackPanel.Orientation = Orientation.Horizontal;
            amountStackPanel.VerticalAlignment = VerticalAlignment.Center;
            amountStackPanel.HorizontalAlignment = HorizontalAlignment.Right;
            amountStackPanel.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(amountStackPanel, row);
            Grid.SetColumn(amountStackPanel, 6);
            #region   amountValue
            var amountValue = new TextBlock();
            amountValue.Text = amount;
            amountValue.FontSize = 16;
            amountValue.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#008A1C"));
            amountTitle.Margin = new Thickness(0, 0, 5, 0);
            #endregion
            #region   amountSympol
            var amountSympol = new TextBlock();
            amountSympol.Text = "$";
            amountSympol.FontSize = 16;
            amountSympol.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#008A1C"));
            #endregion
            amountStackPanel.Children.Add(amountValue);
            amountStackPanel.Children.Add(amountSympol);
            #endregion
             */
            grid_bestSeller.Children.Add(itemNo);
            grid_bestSeller.Children.Add(itemTitle);
            grid_bestSeller.Children.Add(itemName);
            grid_bestSeller.Children.Add(countTitle);
            grid_bestSeller.Children.Add(countItem);
            //grid_bestSeller.Children.Add(amountTitle);
            //grid_bestSeller.Children.Add(amountStackPanel);
        }
        #endregion
        #region IUStorage
        private void Btn_storageSetting_Click(object sender, RoutedEventArgs e)
        {//settings
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //items
                //if (MainWindow.groupObject.HasPermissionAction(itemsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                //{
                //    SectionData.clearValidate(tb_code, p_errorCode);

                    Window.GetWindow(this).Opacity = 0.2;

                    wd_itemsUnitList w = new wd_itemsUnitList();
                    w.itemId = 0;
                    w.itemUnitId = 0;
                    w.CallerName = "IUList";
                    //w.selectedItemUnits = MainWindow.itemUnitsUsers;
                    w.ShowDialog();
                    if (w.isActive)
                    {
                      MainWindow.itemUnitsUsers =  w.selectedItemUnits;
                    refrishIUList(MainWindow.itemUnitsUsers);
                    refreshView();
                    }

                    Window.GetWindow(this).Opacity = 1;
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
        void refrishIUList(List<ItemUnitUser> itemUnitsUsers)
        {
            try
            {
                IUList.Clear();
            foreach (var item in itemUnitsUsers)
            {
                var itemUnit = new ItemUnit();
                itemUnit.itemUnitId = item.itemUnitId.Value;
                IUList.Add(itemUnit);
            }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task IUStorage()
        {
            try
            {
                List<IUStorage> listAllIUStorage = await dash.GetIUStorage(IUList);
                if (cb_branch.SelectedValue != null)
                    if ((int)cb_branch.SelectedValue == 0)
                    {
                        listIUStorage = listAllIUStorage.GroupBy(x => new { x.itemName, x.unitName }).Select(s => new IUStorage
                        {
                            itemName = s.FirstOrDefault().itemName,
                            unitName = s.FirstOrDefault().unitName,
                            quantity = s.Sum(g => g.quantity),
                            //subTotal = s.Sum(g => g.subTotal),
                        }).ToList();
                        //paginationIUStorage(dash.listIUStorage);
                    }
                    else
                    {
                        listIUStorage = listAllIUStorage.Where(s => s.branchId == (int)cb_branch.SelectedValue).ToList();
                        if (listIUStorage != null)
                        {
                            listIUStorage = listIUStorage.GroupBy(x => new { x.itemName, x.unitName }).Select(s => new IUStorage
                            {
                                itemName = s.FirstOrDefault().itemName,
                                unitName = s.FirstOrDefault().unitName,
                                quantity = s.Sum(g => g.quantity),
                                //subTotal = s.Sum(g => g.subTotal),
                            }).ToList();
                            //paginationIUStorage(dash.listIUStorage);
                        }
                        else
                            listIUStorage = new List<IUStorage>();
                    }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void paginationIUStorage(List<IUStorage> listIUStorage, int skip = 0)
        {
            grid_IUStorage.Children.Clear();
            int order = (skip * 3) + 1;
            int row = 1;
            listIUStorage = listIUStorage.Skip(skip * 3).Take(3).ToList();
            foreach (var item in listIUStorage)
            {
                InitializeIUStorageRow(order.ToString(), item.itemName + "-" + item.unitName,
                  item.quantity.ToString(), row);
                order++;
                row += 2;
            }

            #region Border
            #region   firstBorder 
            var firstBorder = new Border();
            firstBorder.Margin = new Thickness(10, 2.5, 10, 2.5);
            firstBorder.Height = 1;
            firstBorder.BorderThickness = new Thickness(0, 0, 0, 0);
            firstBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#BC80EF"));
            Grid.SetRow(firstBorder, 2);
            Grid.SetColumnSpan(firstBorder, 7);
            #endregion
            #region   firstBorder 
            var secondBorder = new Border();
            secondBorder.Margin = new Thickness(10, 2.5, 10, 2.5);
            secondBorder.Height = 1;
            secondBorder.BorderThickness = new Thickness(0, 0, 0, 0);
            secondBorder.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#BC80EF"));
            Grid.SetRow(secondBorder, 4);
            Grid.SetColumnSpan(secondBorder, 7);
            #endregion
            grid_IUStorage.Children.Add(firstBorder);
            grid_IUStorage.Children.Add(secondBorder);
            #endregion


        }
        void InitializeIUStorageRow(string No, string item, string count, int row)
        {
            #region   itemNo
            var itemNo = new TextBlock();
            itemNo.Text = "#" + No;
            itemNo.Tag = "itemTitle";
            itemNo.VerticalAlignment = VerticalAlignment.Center;
            itemNo.HorizontalAlignment = HorizontalAlignment.Center;
            itemNo.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D75B8"));
            itemNo.FontSize = 16;
            itemNo.Margin = new Thickness(2.5, 1, 2.5, 1);
            Grid.SetRow(itemNo, row);
            Grid.SetColumn(itemNo, 0);
            #endregion
            #region   itemTitle
            var itemTitle = new TextBlock();
            itemTitle.Text = "Item:";
            itemTitle.Tag = "itemTitle";
            itemTitle.VerticalAlignment = VerticalAlignment.Center;
            itemTitle.HorizontalAlignment = HorizontalAlignment.Center;
            itemTitle.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#707070"));
            itemTitle.FontSize = 16;
            itemTitle.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(itemTitle, row);
            Grid.SetColumn(itemTitle, 1);
            #endregion
            #region   itemName
            var itemName = new TextBlock();
            itemName.Text = item;
            itemName.Tag = "itemName";
            itemName.VerticalAlignment = VerticalAlignment.Center;
            itemName.HorizontalAlignment = HorizontalAlignment.Left;
            itemName.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#707070"));
            itemName.FontSize = 16;
            itemName.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(itemName, row);
            Grid.SetColumn(itemName, 2);
            #endregion
            #region   countTitle
            var countTitle = new TextBlock();
            countTitle.Text = "Count:";
            countTitle.Tag = "countTitle";
            countTitle.VerticalAlignment = VerticalAlignment.Center;
            countTitle.HorizontalAlignment = HorizontalAlignment.Center;
            countTitle.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#707070"));
            countTitle.FontSize = 16;
            countTitle.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(countTitle, row);
            Grid.SetColumn(countTitle, 3);
            #endregion
            #region   countItem
            var countItem = new TextBlock();
            countItem.Text = count;
            countItem.Tag = "itemName";
            countItem.VerticalAlignment = VerticalAlignment.Center;
            countItem.HorizontalAlignment = HorizontalAlignment.Left;
            countItem.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1D75B8"));
            countItem.FontSize = 16;
            countItem.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(countItem, row);
            Grid.SetColumn(countItem, 4);
            #endregion
            /*
            #region   amountTitle
            var amountTitle = new TextBlock();
            amountTitle.Text = "Amount:";
            amountTitle.Tag = "amountTitle";
            amountTitle.VerticalAlignment = VerticalAlignment.Center;
            amountTitle.HorizontalAlignment = HorizontalAlignment.Center;
            amountTitle.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#707070"));
            amountTitle.FontSize = 16;
            amountTitle.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(amountTitle, row);
            Grid.SetColumn(amountTitle, 5);
            #endregion
            #region amountStackPanel
            var amountStackPanel = new StackPanel();
            amountStackPanel.Orientation = Orientation.Horizontal;
            amountStackPanel.VerticalAlignment = VerticalAlignment.Center;
            amountStackPanel.HorizontalAlignment = HorizontalAlignment.Right;
            amountStackPanel.Margin = new Thickness(5, 1, 5, 1);
            Grid.SetRow(amountStackPanel, row);
            Grid.SetColumn(amountStackPanel, 6);
            #region   amountValue
            var amountValue = new TextBlock();
            amountValue.Text = amount;
            amountValue.FontSize = 16;
            amountValue.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#008A1C"));
            amountTitle.Margin = new Thickness(0, 0, 5, 0);
            #endregion
            #region   amountSympol
            var amountSympol = new TextBlock();
            amountSympol.Text = "$";
            amountSympol.FontSize = 16;
            amountSympol.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#008A1C"));
            #endregion
            amountStackPanel.Children.Add(amountValue);
            amountStackPanel.Children.Add(amountSympol);
            #endregion
             */
            grid_IUStorage.Children.Add(itemNo);
            grid_IUStorage.Children.Add(itemTitle);
            grid_IUStorage.Children.Add(itemName);
            grid_IUStorage.Children.Add(countTitle);
            grid_IUStorage.Children.Add(countItem);
            //grid_IUStorage.Children.Add(amountTitle);
            //grid_IUStorage.Children.Add(amountStackPanel);
        }
        #endregion

        async Task AmountMonthlySalPur()
        {
            try
            {
                double[] ArrayS = new double[NumberDaysInMonth];
                double[] ArrayP = new double[NumberDaysInMonth];
                string[] ArrayCount = new string[NumberDaysInMonth];
                List<TotalPurSale> listAllBestSeller = await dash.GetTotalPurSale();
                if (cb_branch.SelectedValue != null)
                    if ((int)cb_branch.SelectedValue == 0)
                    {
                        listMonthlyInvoice = listAllBestSeller.GroupBy(x => new { x.day }).Select(s => new TotalPurSale
                        {
                            branchCreatorId = s.FirstOrDefault().branchCreatorId,
                            branchCreatorName = s.FirstOrDefault().branchCreatorName,
                            day = s.FirstOrDefault().day,
                            totalPur = s.Sum(g => g.totalPur),
                            totalSale = s.Sum(g => g.totalSale),
                            countPur = s.Sum(g => g.countPur),
                            countSale = s.Sum(g => g.countSale)
                        }).ToList();
                    }
                    else
                    {
                        listMonthlyInvoice = listAllBestSeller.Where(s => s.branchCreatorId == (int)cb_branch.SelectedValue).ToList();
                        if (listMonthlyInvoice != null)
                        {
                            listMonthlyInvoice = listMonthlyInvoice.GroupBy(x => new { x.day }).Select(s => new TotalPurSale
                            {
                                branchCreatorId = s.FirstOrDefault().branchCreatorId,
                                branchCreatorName = s.FirstOrDefault().branchCreatorName,
                                day = s.FirstOrDefault().day,
                                totalPur = s.Sum(g => g.totalPur),
                                totalSale = s.Sum(g => g.totalSale),
                                countPur = s.Sum(g => g.countPur),
                                countSale = s.Sum(g => g.countSale)
                            }).ToList();
                        }
                        else
                            listMonthlyInvoice = new List<TotalPurSale>();
                    }

                int count = 0;
                foreach (var item in listMonthlyInvoice)
                {
                    ArrayS[count] = double.Parse(item.totalPur.ToString());
                    ArrayP[count] = double.Parse(item.totalSale.ToString()) ;
                    ArrayCount[count] = count.ToString();
                    count++;
                }
                dash.SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "المبيعات",
                    Values = ArrayS.AsChartValues()
                },
                 new LineSeries
                {
                    Title = "المشتريات",
                    Values = ArrayP.AsChartValues()
                }
            };

                axs_AxisY.Title = "الإجمالي";
                axs_AxisX.Title = "اليوم";
                dash.Labels = ArrayCount;
                dash.YFormatter = value => value.ToString("C");
                //DataContext = this;


            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
           
        }
        void InitializePieChart(PieChart pieChart ,int partial=0, int all=0)
        {
            SeriesCollection series = new SeriesCollection();
            series.Add(
                 new PieSeries
                 {
                     Values = new ChartValues<int> { partial },
                     Title = "",
                     DataLabels = false,
                     Fill = Application.Current.Resources["mediumGreen"] as SolidColorBrush
                 }
             );
            series.Add(
                 new PieSeries
                 {
                     Values = new ChartValues<int> { all - partial },
                     Title = "",
                     DataLabels = false,
                     Fill = Application.Current.Resources["MainColorlightGrey"] as SolidColorBrush
                 }
             );
            pieChart.Series = series;
        }
        async void userImageLoad(Ellipse ellipse, string image)
        {
            try
            {
                if (!string.IsNullOrEmpty(image))
                {
                    clearImg(ellipse);

                    byte[] imageBuffer = await user.downloadImage(image); // read this as BLOB from your DB
                    var bitmapImage = new BitmapImage();
                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    ellipse.Fill = new ImageBrush(bitmapImage);
                }
                else
                {
                    clearImg(ellipse);
                }
            }
            catch
            {
                clearImg(ellipse);
            }
        }
        private void clearImg(Ellipse ellipse)
        {
            Uri resourceUri = new Uri("pic/no-image-icon-90x90.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            ellipse.Fill = brush;
        }
        public void timerAnimation()
        {
            x = 1000;
            y = 2000;
            z = 3000;
            //value_items = Convert.ToInt32(tb_items.Text);
            //value_purchase = Convert.ToInt32(tb_purchase.Text);
            //value_sales = Convert.ToInt32(tb_sales.Text);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {


            x += 86;
            y += 74;
            z += 65;

            //tb_items.Text = x.ToString();
            //tb_purchase.Text = x.ToString();
            //tb_sales.Text = x.ToString();
            if (x >= 5000)
            {
                //tb_items.Text = Convert.ToString(value_items);
                //tb_purchase.Text = Convert.ToString(value_purchase);
                //tb_sales.Text = Convert.ToString(value_sales);
                timer.Stop();
            }
        }
        private void UserControl_TouchLeave(object sender, TouchEventArgs e)
        {
            MessageBox.Show("hey i'm here in TouchLeave");
        }
        private async void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                SectionData.StartAwait(grid_main);

            await refreshView();
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

        
    }
}

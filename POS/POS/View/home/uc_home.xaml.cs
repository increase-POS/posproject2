using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using POS.Classes;
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
        string branchesPermission = "dashboard_branches";
        Dash dash = new Dash();
        User user = new User();
        List<User> users = new List<User>();
        ImageBrush brush = new ImageBrush();
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await SectionData.fillBranchesWithAll(cb_branch);
            cb_branch.SelectedValue = MainWindow.branchID;
            if (MainWindow.groupObject.HasPermissionAction(branchesPermission, MainWindow.groupObjects, "one"))
            cb_branch.IsEnabled = true;
            else cb_branch.IsEnabled = false;


            #region Purchase and Sales
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

            #endregion
            #region user online 
            SeriesCollection seriesUser = new SeriesCollection();
            seriesUser.Add(
                 new PieSeries
                 {
                     Values = new ChartValues<int> { 5 },
                     Title = "",
                     DataLabels = false,
                     Fill = Application.Current.Resources["mediumGreen"] as SolidColorBrush
                 }
             );
            seriesUser.Add(
                 new PieSeries
                 {
                     Values = new ChartValues<int> { 15 - 5 },
                     Title = "",
                     DataLabels = false,
                     Fill = Application.Current.Resources["MainColorlightGrey"] as SolidColorBrush
                 }
             );
            pch_userOnline.Series = seriesUser;

            #region userImageLoad
            grid_userImages.Children.Clear();
            users = await user.GetUsersActive();
            int userCount = 0;
            foreach (var item in users)
            {
                if (userCount > 4)
                {
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
                    textBlock.Text = "+"+ (users.Count() - 4).ToString();
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock.VerticalAlignment = VerticalAlignment.Center;
                    textBlock.FontWeight = FontWeights.Bold;
                    textBlock.Foreground = Application.Current.Resources["White"] as SolidColorBrush;
                    grid.Children.Add(textBlock);
                    #endregion
                    grid_userImages.Children.Add(grid);
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
                    ellipse.ToolTip = item.username;
                    userImageLoad(ellipse, item.image);
                    Grid.SetColumn(ellipse, userCount);
                    grid_userImages.Children.Add(ellipse);
                    userCount++;
                }
            }
            #endregion
            #endregion
            #region Branch 
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
            #endregion
            #region DailyPurchaseInvoice
            SeriesCollection seriesDailyPurchaseInvoice = new SeriesCollection();
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
            #endregion
            #region DailySalesInvoice
            SeriesCollection seriesDailySalesInvoice = new SeriesCollection();
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
            #endregion


           await refreshView();

        }
       async Task refreshView()
        {
           await AllSalPur();
            await AgentCount();
            await UserOnline();
            await BranchOnline();





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

using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
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

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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
    }
}

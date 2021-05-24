using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_home.xaml
    /// </summary>
    public partial class uc_home : UserControl
    {
        public uc_home()
        {
            InitializeComponent();
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            #region
            double[] ArrayS = new double[30];
            double[] ArrayP = new double[30];
            string[] ArrayCount = new string[30];
            Random rnd = new Random();

            for (int i = 0; i < 30; i++)
            {
                ArrayS[i] = rnd.Next(1800, 2500);
                ArrayP[i] = rnd.Next(1500,int.Parse(ArrayS[i].ToString()) );
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

        }
    }
}

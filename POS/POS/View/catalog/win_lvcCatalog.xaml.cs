using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace POS.View.catalog
{
    /// <summary>
    /// Interaction logic for win_lvcCatalog.xaml
    /// </summary>
    public partial class win_lvcCatalog : Window
    {
        IEnumerable<Category> categoriesQuery;
        IEnumerable<Item> itemsQuery;
        List<double> chartList;
        List<double> PiechartList;
        List<double> ColumnchartList;
        int catalog;
        string label;

        public SeriesCollection SeriesCollection { get; set; }
        Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        public win_lvcCatalog(IEnumerable<Category> _categoriesQuery, int _catalog)
        {
            InitializeComponent();
            categoriesQuery = _categoriesQuery;
            catalog = _catalog;
        }
        public win_lvcCatalog(IEnumerable<Item> _itemsQuery, int _catalog)
        {
            InitializeComponent();
            itemsQuery = _itemsQuery;
            catalog = _catalog;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chartList = new List<double>();
            PiechartList = new List<double>();
            ColumnchartList = new List<double>();
            fillDates();
            cb_cmbChartType.SelectedIndex = 0;
        }

        public void fillDates()
        {
            dpEndDate.SelectedDate = DateTime.Now;
            dpStrtDate.SelectedDate = dpEndDate.SelectedDate.Value.AddYears(-1);
        }

        private void Button_Click(object sender, RoutedEventArgs e) { this.Close(); }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) { try { DragMove(); } catch (Exception) { } }

        public void fillChart()
        {
            chartList.Clear();
            MyAxis.Labels = new List<string>();
            int startYear = dpStrtDate.SelectedDate.Value.Year;
            int endYear = dpEndDate.SelectedDate.Value.Year;
            int startMonth = dpStrtDate.SelectedDate.Value.Month;
            int endMonth = dpEndDate.SelectedDate.Value.Month;
            if (rdoMonth.IsChecked == true)
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    for (int month = startMonth; month <= 12; month++)
                    {
                        var firstOfThisMonth = new DateTime(year, month, dpStrtDate.SelectedDate.Value.Day);
                        var firstOfNextMonth = firstOfThisMonth.AddMonths(1);

                        if (catalog == 1)
                        {
                            var Draw = categoriesQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            chartList.Add(Draw);
                            label = "Categories count";
                        }
                        else
                        {
                            var Draw = itemsQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            chartList.Add(Draw);
                            label = "Items count";
                        }
                        MyAxis.Separator.Step = 2;
                        MyAxis.Labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + "/" + year);
                        if (year == dpEndDate.SelectedDate.Value.Year && month == dpEndDate.SelectedDate.Value.Month)
                        {
                            break;
                        }
                        if (month == 12)
                        {
                            startMonth = 1;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    var firstOfThisYear = new DateTime(year, 1, dpStrtDate.SelectedDate.Value.Month);
                    var firstOfNextMYear = firstOfThisYear.AddYears(1);
                    if (catalog == 1)
                    {
                        var Draw = categoriesQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        chartList.Add(Draw);

                        label = "Categories count";
                    }

                    else
                    {
                        var Draw = itemsQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        chartList.Add(Draw);
                        label = "Items count";
                    }
                    MyAxis.Separator.Step = 1;
                    MyAxis.Labels.Add(year.ToString());
                }
            }
            SeriesCollection = new SeriesCollection
           {
                 new LineSeries
               {
                        Title = label,
                   Values = chartList.AsChartValues()
               },
           };
            grid1.Children.Clear();
            grid1.Children.Add(charts);
            DataContext = this;

        }

        public void fillPieChart()
        {
            PiechartList.Clear();
            SeriesCollection piechartData = new SeriesCollection();
            List<string> titles = new List<string>();
            int startYear = dpStrtDate.SelectedDate.Value.Year;
            int endYear = dpEndDate.SelectedDate.Value.Year;
            int startMonth = dpStrtDate.SelectedDate.Value.Month;
            int endMonth = dpEndDate.SelectedDate.Value.Month;
            if (rdoMonth.IsChecked == true)
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    for (int month = startMonth; month <= 12; month++)
                    {
                        var firstOfThisMonth = new DateTime(year, month, dpStrtDate.SelectedDate.Value.Day);
                        var firstOfNextMonth = firstOfThisMonth.AddMonths(1);
                        if (catalog == 1)
                        {
                            var Draw = categoriesQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            PiechartList.Add(Draw);
                            label = "Categories count";
                        }
                        else
                        {
                            var Draw = itemsQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            PiechartList.Add(Draw);
                            label = "Items count";
                        }
                        titles.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + "/" + year);
                        if (year == dpEndDate.SelectedDate.Value.Year && month == dpEndDate.SelectedDate.Value.Month)
                        {
                            break;
                        }
                        if (month == 12)
                        {
                            startMonth = 1;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    var firstOfThisYear = new DateTime(year, 1, dpStrtDate.SelectedDate.Value.Month);
                    var firstOfNextMYear = firstOfThisYear.AddYears(1);
                    if (catalog == 1)
                    {
                        var Draw = categoriesQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        PiechartList.Add(Draw);
                        label = "Categories count";
                    }
                    else
                    {
                        var Draw = itemsQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        PiechartList.Add(Draw);
                        label = "Items count";
                    }
                    titles.Add(year.ToString());
                }
            }
            for (int i = 0; i < PiechartList.Count(); i++)
            {
                List<double> final = new List<double>();
                List<string> lable = new List<string>();
                final.Add(PiechartList.ToList().Skip(i).FirstOrDefault());
                piechartData.Add(
                  new PieSeries
                  {
                      Values = final.AsChartValues(),
                      Title = titles.ToList().Skip(i).FirstOrDefault().ToString(),
                      DataLabels = true,
                  }
              );
            }
            pieChart.Series = piechartData;
        }

        public void fillColumnChart()
        {
            ColumnchartList.Clear();
            SeriesCollection columnchartData = new SeriesCollection();
            List<string> titles = new List<string>();
            int startYear = dpStrtDate.SelectedDate.Value.Year;
            int endYear = dpEndDate.SelectedDate.Value.Year;
            int startMonth = dpStrtDate.SelectedDate.Value.Month;
            int endMonth = dpEndDate.SelectedDate.Value.Month;
            if (rdoMonth.IsChecked == true)
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    for (int month = startMonth; month <= 12; month++)
                    {
                        var firstOfThisMonth = new DateTime(year, month, dpStrtDate.SelectedDate.Value.Day);
                        var firstOfNextMonth = firstOfThisMonth.AddMonths(1);
                        if (catalog == 1)
                        {
                            var Draw = categoriesQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            ColumnchartList.Add(Draw);
                            label = "Categories count";
                        }
                        else
                        {
                            var Draw = itemsQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            ColumnchartList.Add(Draw);
                            label = "Items count";
                        }
                        titles.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + "/" + year);
                        if (year == dpEndDate.SelectedDate.Value.Year && month == dpEndDate.SelectedDate.Value.Month)
                        {
                            break;
                        }
                        if (month == 12)
                        {
                            startMonth = 1;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    var firstOfThisYear = new DateTime(year, 1, dpStrtDate.SelectedDate.Value.Month);
                    var firstOfNextMYear = firstOfThisYear.AddYears(1);
                    if (catalog == 1)
                    {
                        var Draw = categoriesQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        ColumnchartList.Add(Draw);
                        label = "Categories count";
                    }
                    else
                    {
                        var Draw = itemsQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        ColumnchartList.Add(Draw);
                        label = "Items count";
                    }
                    titles.Add(year.ToString());
                }
            }
            for (int i = 0; i < ColumnchartList.Count(); i++)
            {
                List<double> final = new List<double>();
                List<string> lable = new List<string>();
                final.Add(ColumnchartList.ToList().Skip(i).FirstOrDefault());
                columnchartData.Add(
                  new ColumnSeries
                  {
                      Values = final.AsChartValues(),
                      Title = titles.ToList().Skip(i).FirstOrDefault().ToString(),
                      DataLabels = true,
                  }
              );
            }
            columnChart.Series = columnchartData;
        }

        private void dpStrtDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (dpEndDate.SelectedDate.Value.Year - dpStrtDate.SelectedDate.Value.Year > 1)
            {
                rdoYear.IsChecked = true;
                fillSelectedChart();
            }
            else
            {
                fillSelectedChart();
            }
        }

        private void dpEndDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (dpEndDate.SelectedDate.Value.Year - dpStrtDate.SelectedDate.Value.Year > 1)
            {
                rdoYear.IsChecked = true;
                fillSelectedChart();
            }
            else
            {
                fillSelectedChart();
            }
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e) { cb_cmbChartType.SelectedIndex = 0; rdoMonth.IsChecked = true; fillDates(); fillSelectedChart(); }

        private void rdoYear_Click(object sender, RoutedEventArgs e)
        {
            if (dpEndDate.SelectedDate.Value.Year - dpStrtDate.SelectedDate.Value.Year > 1)
            {
                rdoYear.IsChecked = true;
                fillSelectedChart();
            }
            else
            {
                fillSelectedChart();
            }
        }

        private void rdoMonth_Click(object sender, RoutedEventArgs e)
        {
            if (dpEndDate.SelectedDate.Value.Year - dpStrtDate.SelectedDate.Value.Year > 1)
            {
                rdoYear.IsChecked = true;
                fillSelectedChart();
            }
            else
            {
                fillSelectedChart();
            }
        }

        private void cb_cmbChartType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_cmbChartType.SelectedIndex == 0)
            {
                grid1.Visibility = Visibility.Visible;
                grd_pieChart.Visibility = Visibility.Hidden;
                grd_columnChart.Visibility = Visibility.Hidden;
                fillSelectedChart();
            }
            else if (cb_cmbChartType.SelectedIndex == 1)
            {
                grid1.Visibility = Visibility.Hidden;
                grd_pieChart.Visibility = Visibility.Visible;
                grd_columnChart.Visibility = Visibility.Hidden;
                fillSelectedChart();
            }
            else if (cb_cmbChartType.SelectedIndex == 2)
            {
                grid1.Visibility = Visibility.Hidden;
                grd_pieChart.Visibility = Visibility.Hidden;
                grd_columnChart.Visibility = Visibility.Visible;
                fillSelectedChart();
            }

        }

        private void fillSelectedChart()
        {
            if (cb_cmbChartType.SelectedIndex == 0)
            {
                fillChart();
            }
            else if (cb_cmbChartType.SelectedIndex == 1)
            {
                fillPieChart();
            }
            else if (cb_cmbChartType.SelectedIndex == 2)
            {
                fillColumnChart();
            }
        }

    }
}
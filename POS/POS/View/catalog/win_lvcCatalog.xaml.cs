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
        int catalog;
        string label;

        public SeriesCollection SeriesCollection { get; set; }
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
            fillDates();
            fillChart();
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

            private void dpStrtDate_CalendarClosed(object sender, RoutedEventArgs e)
            {
                if (dpEndDate.SelectedDate.Value.Year - dpStrtDate.SelectedDate.Value.Year > 1)
                {
                    rdoYear.IsChecked = true;
                    fillChart();
                }
                else fillChart();
            }

            private void dpEndDate_CalendarClosed(object sender, RoutedEventArgs e)
            {
                if (dpEndDate.SelectedDate.Value.Year - dpStrtDate.SelectedDate.Value.Year > 1)
                {
                    rdoYear.IsChecked = true;
                    fillChart();
                }
                else fillChart();
            }

            private void btn_refresh_Click(object sender, RoutedEventArgs e) { rdoMonth.IsChecked = true; fillDates(); fillChart(); }

            private void rdoYear_Click(object sender, RoutedEventArgs e)
            {
                if (dpEndDate.SelectedDate.Value.Year - dpStrtDate.SelectedDate.Value.Year > 1)
                {
                    rdoYear.IsChecked = true;
                    fillChart();
                }
                else fillChart();
            }

            private void rdoMonth_Click(object sender, RoutedEventArgs e)
            {
                if (dpEndDate.SelectedDate.Value.Year - dpStrtDate.SelectedDate.Value.Year > 1)
                {
                    rdoYear.IsChecked = true;
                    fillChart();
                }
                else fillChart();
            }

        }
    }
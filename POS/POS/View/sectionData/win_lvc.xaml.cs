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

namespace POS.View.sectionData.Charts
{
    /// <summary>
    /// Interaction logic for lvcVendor.xaml
    /// </summary>
    public partial class win_lvc : Window
    {
        IEnumerable<Agent> agentsQuery;
        IEnumerable<Bank> banksQuery;
        IEnumerable<User> usersQuery;
        IEnumerable<Branch> branchesQuery;
        IEnumerable<Pos> possQuery;
        IEnumerable<Card> cardsQuery;
        List<double> chartList;
        int sectionDate;
        bool isSameList;
        string label;

        public SeriesCollection SeriesCollection { get; set; }

        public win_lvc(IEnumerable<Agent> _agentsQuery, int _sectionDate, bool _isSameList)
        {
            InitializeComponent();
            agentsQuery = _agentsQuery;
            sectionDate = _sectionDate;
            isSameList = _isSameList;
        }

        public win_lvc(IEnumerable<Bank> _banksQuery, int _sectionDate)
        {
            InitializeComponent();
            banksQuery = _banksQuery;
            sectionDate = _sectionDate;
        }

        public win_lvc(IEnumerable<User> _usersQuery, int _sectionDate)
        {
            InitializeComponent();
           usersQuery = _usersQuery;
            sectionDate = _sectionDate;
        }

        public win_lvc(IEnumerable<Branch> _branchesQuery, int _sectionDate, bool _isSameList)
        {
            InitializeComponent();
            branchesQuery = _branchesQuery;
            sectionDate = _sectionDate;
            isSameList = _isSameList;
        }

        public win_lvc(IEnumerable<Pos> _possQuery, int _sectionDate)
        {
            InitializeComponent();
            possQuery = _possQuery;
            sectionDate = _sectionDate;
        }

        public win_lvc(IEnumerable<Card> _cardsQuery, int _sectionDate)
        {
            InitializeComponent();
            cardsQuery = _cardsQuery;
            sectionDate = _sectionDate;
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
                        if (sectionDate == 1)
                        {
                            var Draw = agentsQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            chartList.Add(Draw);
                            if (isSameList)
                            {
                                label = "Customers count";
                            }
                            else label = "Vendors count";
                        }
                        else if (sectionDate == 2)
                        {
                            var Draw = banksQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            chartList.Add(Draw);
                            label = "Banks count";
                        }
                        else if (sectionDate == 3)
                        {
                            var Draw = usersQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            chartList.Add(Draw);
                            label = "Users count";
                        }
                        else if (sectionDate == 4)
                        {
                            var Draw = branchesQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            chartList.Add(Draw);
                            if (isSameList)
                            {
                                label = "Branches count";
                            }
                            else label = "Stores count";
                        }
                        else if (sectionDate == 5)
                        {
                            var Draw = possQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            chartList.Add(Draw);
                            label = "Pos count";
                        }
                        else
                        {
                            var Draw = cardsQuery.ToList().Where(c => c.createDate > firstOfThisMonth && c.createDate <= firstOfNextMonth).Count();
                            chartList.Add(Draw);
                            label = "Cards count";
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
                    if (sectionDate == 1)
                    {
                        var Draw = agentsQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        chartList.Add(Draw);
                        if (isSameList)
                        {
                            label = "Customers count";
                        }
                        else label = "Vendors count";
                    }
                    else if (sectionDate == 2)
                    {
                        var Draw = banksQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        chartList.Add(Draw);
                        label = "Banks count";
                    }
                    else if (sectionDate == 3)
                    {
                        var Draw = usersQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        chartList.Add(Draw);
                        label = "Users count";
                    }
                    else if (sectionDate == 4)
                    {
                        var Draw = branchesQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        chartList.Add(Draw);
                        if (isSameList)
                        {
                            label = "Branches count";
                        }
                        else label = "Stores count";
                    }
                    else if (sectionDate == 5)
                    {
                        var Draw = possQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        chartList.Add(Draw);
                        label = "Pos count";
                    }
                    else 
                    {
                        var Draw = cardsQuery.ToList().Where(c => c.createDate > firstOfThisYear && c.createDate <= firstOfNextMYear).Count();
                        chartList.Add(Draw);
                        label = "Cards count";
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

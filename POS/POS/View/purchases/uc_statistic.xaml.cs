using LiveCharts;
using LiveCharts.Wpf;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

using LiveCharts.Helpers;
using POS.View.windows;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Resources;
using System.Reflection;

namespace POS.View.purchases
{

    /// <summary>
    /// Interaction logic for uc_statistic.xaml
    /// </summary>
    public partial class uc_statistic : UserControl
    {
        List<Invoice> Invoices;
        List<Invoice> columnChartList;
        List<Invoice> rowChartInvoice;
        Statistics statisticModel = new Statistics();

        //for combo
        Branch temp = new Branch();
        List<Branch> Branches;
        Branch branchModel = new Branch();

        List<Invoice> poss = new List<Invoice>();

        Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        ObservableCollection<int> m = new ObservableCollection<int>();

        public string[] Labels { get; set; }
        public string[] Formatter { get; set; }

        private static uc_statistic _instance;
        public static uc_statistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_statistic();
                return _instance;
            }
        }
        public uc_statistic()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load

            #region translate
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_statistic.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_statistic.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            #endregion

            Invoices = await statisticModel.GetPurinvwithCount();
            Branches = await branchModel.GetAllWithoutMain("b");
            columnChartList = await statisticModel.GetPurinv();
            rowChartInvoice = await statisticModel.GetPurinv();
            fillComboBranches();
            chk_invoice.IsChecked = true;
            chk_posInvoice.IsChecked = true;
            chk_vendorsInvoice.IsChecked = true;
            chk_usersInvoice.IsChecked = true;
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
        }

        private void translate()
        {
            chk_invoice.Content = MainWindow.resourcemanager.GetString("trInvoice");
            chk_return.Content = MainWindow.resourcemanager.GetString("trReturnInvoice");
            chk_drafs.Content = MainWindow.resourcemanager.GetString("trDrafts");
            chk_allBranches.Content = MainWindow.resourcemanager.GetString("trAllBranches");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_startDate , MainWindow.resourcemanager.GetString("trStartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_endDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branches, MainWindow.resourcemanager.GetString("trBranchesHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dt_startTime, MainWindow.resourcemanager.GetString("trStartTime"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dt_endTime, MainWindow.resourcemanager.GetString("trEndTime"));

            dgInvoice.Columns[0].Header = MainWindow.resourcemanager.GetString("trNo.");
            dgInvoice.Columns[1].Header = MainWindow.resourcemanager.GetString("trType");
            dgInvoice.Columns[2].Header = MainWindow.resourcemanager.GetString("trDiscountType");
            dgInvoice.Columns[3].Header = MainWindow.resourcemanager.GetString("trDiscountValue");
            dgInvoice.Columns[4].Header = MainWindow.resourcemanager.GetString("trTotal");
            dgInvoice.Columns[5].Header = MainWindow.resourcemanager.GetString("trTax");
            dgInvoice.Columns[6].Header = MainWindow.resourcemanager.GetString("trTheCount");
            dgInvoice.Columns[7].Header = MainWindow.resourcemanager.GetString("trBranch");
            dgInvoice.Columns[8].Header = MainWindow.resourcemanager.GetString("trPos");
            dgInvoice.Columns[9].Header = MainWindow.resourcemanager.GetString("trVendor");
            dgInvoice.Columns[10].Header = MainWindow.resourcemanager.GetString("trUser");
            dgInvoice.Columns[11].Header = MainWindow.resourcemanager.GetString("trItem");

            tt_branch.Content = MainWindow.resourcemanager.GetString("trBranch");
            tt_pos.Content = MainWindow.resourcemanager.GetString("trPOS");
            tt_vendors.Content = MainWindow.resourcemanager.GetString("trVendors");
            tt_users.Content = MainWindow.resourcemanager.GetString("trUsers");
            tt_items.Content = MainWindow.resourcemanager.GetString("trItems");

            tt_settings.Content = MainWindow.resourcemanager.GetString("trSettings");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

        }

        #region Branch

        #region Branches Functions
        //        private async void fillDgBranches()
        //        {
        //            var temp = cb_branches.SelectedItem as Branch;
        //            Branches = await statisticModel.GetinvInBranch();
        //            //fillDatesBranches();
        //            var dgData = Invoices.Where(x => ((chk_drafs.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false) || (chk_return.IsChecked == true ? (x.invType == "pb") : false) || (chk_invoice.IsChecked == true ? (x.invType == "p") : false)) && (cb_branches.SelectedItem != null ? m.Contains((int)x.branchId) : true) &&
        //(dp_startDate.SelectedDate != null ? x.invDate >= dp_startDate.SelectedDate : true) && (dp_endDate.SelectedDate != null ? x.invDate <= dp_endDate.SelectedDate : true) &&
        //(dt_startTime.SelectedTime != null ? x.invDate >= dt_startTime.SelectedTime : true) && (dt_endTime.SelectedTime != null ? x.invDate <= dt_endTime.SelectedTime : true)
        //&& (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
        //|| x.discountType.Contains(txt_search.Text) || x.branchName.Contains(txt_search.Text)) : true))
        //;
        //            dgInvoice.ItemsSource = dgData;
        //        }
        private async void fillDgPos(CheckBox chkInvoice,CheckBox chkReturn,CheckBox chkDraft,ComboBox comboBox,CheckBox all,DatePicker startDate,DatePicker endDate,TimePicker startTime, TimePicker endTime,TextBox search)
        {
            fillDatesBranches(startDate,endDate,startTime,endTime);
            var temp = cb_branches.SelectedItem as Branch;
            Branches = await statisticModel.GetinvInBranch();
       
            var dgData = Invoices.Where(x => ((chkDraft.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false) || (chkReturn.IsChecked == true ? (x.invType == "pb") : false) || (chkInvoice.IsChecked == true ? (x.invType == "p") : false)) && (comboBox.SelectedItem != null ? m.Contains((int)x.branchId) : true) &&
(startDate.SelectedDate != null ? x.invDate >= startDate.SelectedDate : true) && (endDate.SelectedDate != null ? x.invDate <= endDate.SelectedDate : true) &&
(startTime.SelectedTime != null ? x.invDate >= startTime.SelectedTime : true) && (endTime.SelectedTime != null ? x.invDate <= endTime.SelectedTime : true)
&& (search.Text != null ? (x.invNumber.Contains(search.Text) || x.invType.Contains(search.Text)
|| x.discountType.Contains(search.Text) || x.branchName.Contains(search.Text)) : true))
;
            dgInvoice.ItemsSource = dgData;
        }
        private void fillDatesBranches(DatePicker startDate,DatePicker endDate,TimePicker startTime,TimePicker endTime)
        {
            if (startDate.SelectedDate != null && startTime.SelectedTime != null)
            {
                string x = startDate.SelectedDate.Value.Date.ToShortDateString();
                string y = startTime.SelectedTime.Value.ToShortTimeString();
                string resultStartTime = x + " " + y;
                startTime.SelectedTime = DateTime.Parse(resultStartTime);
                startDate.SelectedDate = DateTime.Parse(resultStartTime);
            }
            if (endDate.SelectedDate != null && endTime.SelectedTime != null)
            {
                string x = endDate.SelectedDate.Value.Date.ToShortDateString();
                string y = endTime.SelectedTime.Value.ToShortTimeString();
                string resultEndTime = x + " " + y;
                endTime.SelectedTime = DateTime.Parse(resultEndTime);
                endDate.SelectedDate = DateTime.Parse(resultEndTime);
            }
        }

        private void fillComboBranches()
        {
            cb_branches.SelectedValuePath = "branchId";
            cb_branches.DisplayMemberPath = "name";
            cb_branches.ItemsSource = Branches;
        }

        private async void fillPieChartBranches()
        {
            //fillDatesBranches();
            var temp = cb_branches.SelectedItem as Branch;
            Branches = await statisticModel.GetinvInBranch();
            var count = Branches.ToList().Count();
            var result = Invoices.Where(x => ((chk_drafs.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false) || (chk_return.IsChecked == true ? (x.invType == "pb") : false) || (chk_invoice.IsChecked == true ? (x.invType == "p") : false)) && (cb_branches.SelectedItem != null ? m.Contains((int)x.branchId) : true) &&
        (dp_startDate.SelectedDate != null ? x.invDate >= dp_startDate.SelectedDate : true) && (dp_endDate.SelectedDate != null ? x.invDate <= dp_endDate.SelectedDate : true) &&
         (dt_startTime.SelectedTime != null ? x.invDate >= dt_startTime.SelectedTime : true) && (dt_endTime.SelectedTime != null ? x.invDate <= dt_endTime.SelectedTime : true)
         && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.branchName.Contains(txt_search.Text)) : true)
         ).GroupBy(s => s.branchId).Select(s => new { branchId = s.Key, count = s.Count() }
         );


            IEnumerable<Branch> drawBranch = Branches.ToList();
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < result.Count(); i++)
            {
                List<int> c = new List<int>();
                List<string> titles = new List<string>();
                List<string> lable = new List<string>();
                c.Add(result.ToList().Skip(i).FirstOrDefault().count);
                //titles.Add(result.ToList().Skip(i).FirstOrDefault().Name.ToString());
                piechartData.Add(
                  new PieSeries
                  {
                      Values = c.AsChartValues(),
                      Title = titles.FirstOrDefault(),
                      DataLabels = true,
                  }

              );
            }
            chart1.Series = piechartData;
        }
       
        private async void fillRowChart()
        {
            //fillDatesBranches();
            var temp = cb_branches.SelectedItem as Branch;
            Branches = await statisticModel.GetinvInBranch();
            var count = Branches.ToList().Count();

            var result = rowChartInvoice.Where(x => ((x.invType == "pb") || (x.invType == "p")) && (cb_branches.SelectedItem != null ? m.Contains((int)x.branchId) : true) &&
        (dp_startDate.SelectedDate != null ? x.invDate >= dp_startDate.SelectedDate : true) && (dp_endDate.SelectedDate != null ? x.invDate <= dp_endDate.SelectedDate : true) &&
         (dt_startTime.SelectedTime != null ? x.invDate >= dt_startTime.SelectedTime : true) && (dt_endTime.SelectedTime != null ? x.invDate <= dt_endTime.SelectedTime : true)
         && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.branchName.Contains(txt_search.Text)) : true)).GroupBy(s => s.branchId).Select(s => new { branchId = s.Key, totalP = s.Where(x => x.invType == "p").Sum(x => x.totalNet), totalPb = s.Where(x => x.invType == "pb").Sum(x => x.totalNet) }
         );
            var resultTotal = result.Select(x => new { x.branchId, total = x.totalP - x.totalPb }).ToList();

            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            for (int i = 0; i < result.Count(); i++)
            {
                purchase.Add(decimal.Parse(result.ToList().Skip(i).FirstOrDefault().totalP.ToString()));
                returns.Add(decimal.Parse(result.ToList().Skip(i).FirstOrDefault().totalPb.ToString()));
                sub.Add(decimal.Parse(resultTotal.ToList().Skip(i).FirstOrDefault().total.ToString()));
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = purchase.AsChartValues(),
              //Fill = Brushes.Transparent
          });
            rowChartData.Add(
         new LineSeries
         {
             Values = returns.AsChartValues(),
             //Fill = Brushes.Transparent
         });
            rowChartData.Add(
        new LineSeries
        {
            Values = sub.AsChartValues(),
            //Fill = Brushes.Transparent

        });
            DataContext = this;
            rowChart.Series = rowChartData;

        }

        private async void fillColumnChart()
        {
            //fillDatesBranches();
            var temp = cb_branches.SelectedItem as Branch;
            Branches = await statisticModel.GetinvInBranch();
            var count = Branches.ToList().Count();

            var result = columnChartList.Where(x => ((chk_drafs.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false) || (chk_return.IsChecked == true ? (x.invType == "pb") : false) || (chk_invoice.IsChecked == true ? (x.invType == "p") : false)) && (cb_branches.SelectedItem != null ? m.Contains((int)x.branchId) : true) &&
        (dp_startDate.SelectedDate != null ? x.invDate >= dp_startDate.SelectedDate : true) && (dp_endDate.SelectedDate != null ? x.invDate <= dp_endDate.SelectedDate : true) &&
         (dt_startTime.SelectedTime != null ? x.invDate >= dt_startTime.SelectedTime : true) && (dt_endTime.SelectedTime != null ? x.invDate <= dt_endTime.SelectedTime : true)
         && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.branchName.Contains(txt_search.Text)) : true)
         ).GroupBy(s => s.branchId).Select(s => new { branchId = s.Key, countP = s.Where(x => x.invType == "p").Count(), countPb = s.Where(x => x.invType == "pb").Count(), countD = s.Where(x => x.invType == "pd" || x.invType == "pbd").Count() }
         );
            #region

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();
            List<int> cD = new List<int>();
            List<string> titles = new List<string>()
            {
                //"مشتريات","مرتجع","هامش"
                MainWindow.resourcemanager.GetString("trPurchases") , MainWindow.resourcemanager.GetString("trReturned"),MainWindow.resourcemanager.GetString("trDraft")
            };
            for (int i = 0; i < result.Count(); i++)
            {
                cP.Add(result.ToList().Skip(i).FirstOrDefault().countP);
                cPb.Add(result.ToList().Skip(i).FirstOrDefault().countPb);
                cD.Add(result.ToList().Skip(i).FirstOrDefault().countD);
            }

            //3 فوق بعض
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cP.AsChartValues(),
                Title = titles[0],
                DataLabels = true,
            });
            columnChartData.Add(
           new StackedColumnSeries
           {
               Values = cPb.AsChartValues(),
               Title = titles[1],
               DataLabels = true,
           });
            columnChartData.Add(
           new StackedColumnSeries
           {
               Values = cD.AsChartValues(),
               Title = titles[2],
               DataLabels = true,
           });
            #endregion
            DataContext = this;
            cartesianChart.Series = columnChartData;
        }
        #endregion

        #region Branches Events
        private void btn_branch_Click(object sender, RoutedEventArgs e)
        {
            paint();
            col_branch.Visibility = Visibility.Visible;
            bdr_branch.Background = Brushes.White;
            path_branch.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_branch.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_branch.IsEnabled = false;
            btn_branch.Opacity = 1;
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
        }

        private void chk_invoice_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_return_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs,cb_branches , chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_drafs_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_invoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_return_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_drafs_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();

            var temp = cb_branches.SelectedItem as Branch;

            if (temp != null)
            {
                if (stk_tags.Children.Count < 5)
                {
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = temp.name,
                        Name = "btn" + temp.branchId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteClick;
                    stk_tags.Children.Add(b);
                    m.Add(temp.branchId);
                    fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
                }
            }
        }

        private void Chip_OnDeleteClick(object sender, RoutedEventArgs e)
        {
            var temp = cb_branches.SelectedItem as Branch;
            var currentChip = (Chip)sender;
            stk_tags.Children.Remove(currentChip);

            m.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (m.Count == 0)
            {
                cb_branches.SelectedItem = null;
            }
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
        }

        private void dp_startDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dp_endDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dp_endTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dt_startTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_allBranches_Click(object sender, RoutedEventArgs e)
        {
            if (cb_branches.IsEnabled == true)
            {
                cb_branches.SelectedItem = null;
                cb_branches.IsEnabled = false;
                stk_tags.Children.Clear();
            }
            else
            {
                cb_branches.IsEnabled = true;
            }
            m.Clear();
            fillDgPos(chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }
        #endregion

        #endregion

        private void btn_pos_Click(object sender, RoutedEventArgs e)
        {
            paint();
            col_pos.Visibility = Visibility.Visible;
            bdr_pos.Background = Brushes.White;
            path_pos.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_pos.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_pos.IsEnabled = false;
            btn_pos.Opacity = 1;
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft,cb_pos,chk_allPos,dp_posStartDate,dp_posEndDate,dt_posStartTime,dt_posEndTime,txt_search);
        }

        private void btn_vendors_Click(object sender, RoutedEventArgs e)
        {
            paint();
            col_vendor.Visibility = Visibility.Visible;
            bdr_vendors.Background = Brushes.White;
            path_vendors.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_vendors.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_vendors.IsEnabled = false;
            btn_vendors.Opacity = 1;
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void btn_users_Click(object sender, RoutedEventArgs e)
        {
            paint();
            col_user.Visibility = Visibility.Visible;
            bdr_users.Background = Brushes.White;
            path_users.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_users.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_users.IsEnabled = false;
            btn_users.Opacity = 1;
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void btn_items_Click(object sender, RoutedEventArgs e)
        {
            paint();
            col_item.Visibility = Visibility.Visible;
            bdr_items.Background = Brushes.White;
            path_items.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_items.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_items.IsEnabled = false;
            btn_items.Opacity = 1;
        }

        public void paint()
        {
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            bdr_branch.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_pos.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_vendors.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_users.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_items.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_branch.Fill = Brushes.White;
            path_pos.Fill = Brushes.White;
            path_vendors.Fill = Brushes.White;
            path_users.Fill = Brushes.White;
            path_items.Fill = Brushes.White;

            grid_branch.Visibility = Visibility.Hidden;
            grid_pos.Visibility = Visibility.Hidden;
            grid_vendors.Visibility = Visibility.Hidden;
            grid_users.Visibility = Visibility.Hidden;
            grid_items.Visibility = Visibility.Hidden;

            col_branch.Visibility = Visibility.Collapsed;
            col_item.Visibility = Visibility.Collapsed;
            col_pos.Visibility = Visibility.Collapsed;
            col_user.Visibility = Visibility.Collapsed;
            col_vendor.Visibility = Visibility.Collapsed;
        }

        private void isEnabledButtons()
        {
            btn_branch.IsEnabled = true;
            btn_pos.IsEnabled = true;
            btn_vendors.IsEnabled = true;
            btn_users.IsEnabled = true;
            btn_items.IsEnabled = true;
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            if (grid_branch.Visibility==Visibility.Visible)
            {
                cb_branches.SelectedItem = null;
                chk_drafs.IsChecked = false;
                chk_return.IsChecked = false;
                chk_invoice.IsChecked = true;
                dp_endDate.SelectedDate = null;
                dp_startDate.SelectedDate = null;
                dt_startTime.SelectedTime = null;
                dt_endTime.SelectedTime = null;
                chk_allBranches.IsChecked = false;
                cb_branches.IsEnabled = true;
            }

            else if (grid_pos.Visibility == Visibility.Visible)
            {
                cb_pos.SelectedItem = null;
                chk_posDraft.IsChecked = false;
                chk_posReturn.IsChecked = false;
                chk_posInvoice.IsChecked = true;
                dp_posEndDate.SelectedDate = null;
                dp_posStartDate.SelectedDate = null;
                dt_posStartTime.SelectedTime = null;
                dt_posEndTime.SelectedTime = null;
                chk_allPos.IsChecked = false;
                cb_pos.IsEnabled = true;
            }

            else if (grid_vendors.Visibility == Visibility.Visible)
            {
                cb_vendors.SelectedItem = null;
                chk_vendorsDraft.IsChecked = false;
                chk_vendorsReturn.IsChecked = false;
                chk_vendorsInvoice.IsChecked = true;
                dp_vendorsEndDate.SelectedDate = null;
                dp_vendorsStartDate.SelectedDate = null;
                dt_vendorsStartTime.SelectedTime = null;
                dt_vendorsEndTime.SelectedTime = null;
                chk_allVendors.IsChecked = false;
                cb_vendors.IsEnabled = true;
            }

            else if (grid_users.Visibility == Visibility.Visible)
            {
                cb_users.SelectedItem = null;
                chk_usersDraft.IsChecked = false;
                chk_usersReturn.IsChecked = false;
                chk_usersInvoice.IsChecked = true;
                dp_usersEndDate.SelectedDate = null;
                dp_usersStartDate.SelectedDate = null;
                dt_usersStartTime.SelectedTime = null;
                dt_usersEndTime.SelectedTime = null;
                chk_allUsers.IsChecked = false;
                cb_users.IsEnabled = true;
            }


            txt_search.Text = "";
            stk_tags.Children.Clear();
            fillColumnChart();
            fillRowChart();
            fillPieChartBranches();
        }

        private void chk_posReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_posDrafs_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dp_posEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dp_posStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void cb_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_allPos_Click(object sender, RoutedEventArgs e)
        {
            if (cb_pos.IsEnabled == true)
            {
                cb_pos.SelectedItem = null;
                cb_pos.IsEnabled = false;
                stk_tags.Children.Clear();
            }
            else
            {
                cb_pos.IsEnabled = true;
            }
            m.Clear();
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dt_posEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dt_posStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_posInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_posReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_posDrafs_Unchecked_1(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_posDrafs_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_vendorsInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_vendorsInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_vendorsReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_vendorsReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_vendorsDraft_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_vendorsDraft_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dp_vendorsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_startDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dp_vendorsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void cb_vendors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_allVendors_Click(object sender, RoutedEventArgs e)
        {
            if (cb_vendors.IsEnabled == true)
            {
                cb_vendors.SelectedItem = null;
                cb_vendors.IsEnabled = false;
                stk_tags.Children.Clear();
            }
            else
            {
                cb_vendors.IsEnabled = true;
            }
            m.Clear();
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dt_vendorsStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dt_vendorsEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_usersInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_usersInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_usersReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_usersReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_usersDraft_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_usersDraft_Unchecked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dp_usersStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dp_usersEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void cb_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void chk_allUsers_Click(object sender, RoutedEventArgs e)
        {
            if (cb_users.IsEnabled == true)
            {
                cb_users.SelectedItem = null;
                cb_users.IsEnabled = false;
                stk_tags.Children.Clear();
            }
            else
            {
                cb_users.IsEnabled = true;
            }
            m.Clear();
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dt_usersEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void dt_usersStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillDgPos(chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartBranches();
            fillColumnChart();
            fillRowChart();
        }

        #region settings
        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {
            List<string> Headers = new List<string>();
            List<string> Headers1 = new List<string>();
            foreach (var item in dgInvoice.Columns)
            {
                Headers.Add(item.Header.ToString());
            }

            winControlPanel win = new winControlPanel(Headers);

            if (win.ShowDialog() == false)
            {
                Headers1.Clear();
                Headers1.AddRange(win.newHeaderResult);
            }
            for (int i = 0; i < Headers1.Count; i++)
            {
                if (dgInvoice.Columns[i].Header.ToString() == Headers1[i])
                {
                    dgInvoice.Columns[i].Visibility = Visibility.Visible;
                }
                else
                    dgInvoice.Columns[i].Visibility = Visibility.Hidden;
            }

        }
        #endregion

        private void chk_posInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillDgPos(chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void dp_vendorsEndDate_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            fillDgPos(chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_pos, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }
    }
}


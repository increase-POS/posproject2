using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using POS.Classes;
using POS.View.windows;
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

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for uc_accountClosing.xaml
    /// </summary>
    public partial class uc_accountClosing : UserControl
    {
        IEnumerable<POSOpenCloseModel> closings;
        IEnumerable<POSOpenCloseModel> closingTemp = null;
        Statistics statisticsModel = new Statistics();
        string searchText = "";

        private static uc_accountClosing _instance;

        public static uc_accountClosing Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_accountClosing();
                return _instance;
            }
        }
        public uc_accountClosing()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            //try
            //{
            //    if (sender != null)
            //        SectionData.StartAwait(grid_main);

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }
                translate();
                #endregion

                txt_search.Text = "";

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_closing.Tag.ToString());

                chk_closingBranches.IsChecked = true;
                //Chk_closingBranches_Checked(chk_closingBranches , null);

            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }

        #region methods
        private async void callSearch(object sender)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await Search();

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
        void fillBranches()
        {
            var iulist = closings.GroupBy(g => g.branchId).Select(g => new { branchId = g.FirstOrDefault().branchId, branchName = g.FirstOrDefault().branchName }).ToList();
            cb_closingBranches.SelectedValuePath = "branchId";
            cb_closingBranches.DisplayMemberPath = "branchName";
            cb_closingBranches.ItemsSource = iulist;
        }
        private void translate()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_closingStartDate, MainWindow.resourcemanager.GetString("trDaily")+" "+ MainWindow.resourcemanager.GetString("trStartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_closingEndDate, MainWindow.resourcemanager.GetString("trDaily") + " " + MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_closingBranches, MainWindow.resourcemanager.GetString("trBranchHint"));

            chk_closingBranches.Content = MainWindow.resourcemanager.GetString("trAll");

            tt_closing.Content = MainWindow.resourcemanager.GetString("trItems");

            col_Num.Header = MainWindow.resourcemanager.GetString("trNum");
            col_pos.Header = MainWindow.resourcemanager.GetString("trPOS");
            col_openDate.Header = MainWindow.resourcemanager.GetString("trOpenDate");
            col_openCash.Header = MainWindow.resourcemanager.GetString("trOpenCash");
            col_closeDate.Header = MainWindow.resourcemanager.GetString("trCloseDate");
            col_closeCash.Header = MainWindow.resourcemanager.GetString("trCloseCash");
            col_operation.Header = MainWindow.resourcemanager.GetString("trOperations");

            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            
            
        }
        async Task Search()
        {
            if (closings is null)
                await RefreshClosingList();

            searchText = txt_search.Text.ToLower();
          
            closingTemp = closings.Where(t => 
            (  t.transNum.ToLower().Contains(searchText)
            || t.posName.ToLower().Contains(searchText)
            )
            &&
            //closing start date
            (dp_closingStartDate.SelectedDate != null ? t.updateDate >= dp_closingStartDate.SelectedDate : true)
            &&
            //closing end date
            (dp_closingEndDate.SelectedDate != null ? t.updateDate <= dp_closingEndDate.SelectedDate : true)
            &&
            //branchID
            (cb_closingBranches.SelectedIndex != -1 ? t.branchId == Convert.ToInt32(cb_closingBranches.SelectedValue) : true)
            );

            RefreshClosingView();
            fillBranches();
            fillColumnChart();
            fillPieChart();
        }

        private void RefreshClosingView()
        {
            dgClosing.ItemsSource = closingTemp;
            txt_count.Text = closingTemp.Count().ToString();

        }


        async Task<IEnumerable<POSOpenCloseModel>> RefreshClosingList()
        {
            closings = await statisticsModel.GetPosCashOpenClose(MainWindow.branchID.Value, MainWindow.userID.Value);
            return closings;
        }

        #endregion

        #region charts

        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            IEnumerable<int> x = null;
            IEnumerable<decimal> cashes = null;

            titles.Clear();

            var titleTemp = closingTemp.GroupBy(m => m.branchName);
            titles.AddRange(titleTemp.Select(jj => jj.Key));
            var result = closingTemp.GroupBy(s => s.branchId)
                        .Select(
                            g => new
                            {
                                branchId = g.Key,
                                //cash = g.Sum(s => s.cash),
                                cash = g.LastOrDefault().cash,
                                count = g.Count()
                            });
            cashes = result.Select(m => decimal.Parse(SectionData.DecTostring(m.cash.Value)));

            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < cashes.Count(); i++)
            {
                List<decimal> final = new List<decimal>();
                List<string> lable = new List<string>();
                final.Add(cashes.ToList().Skip(i).FirstOrDefault());
                piechartData.Add(
                  new PieSeries
                  {
                      Values = final.AsChartValues(),
                      Title = titles.Skip(i).FirstOrDefault(),
                      DataLabels = true,
                  }
              );
            }
            chart1.Series = piechartData;
        }

        private void fillRowChart()
        {

        }

        private void fillColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            List<decimal> cashes = new List<decimal>();

            var result = closingTemp.GroupBy(s => s.posId).Select(s => new
            {
                posId = s.Key,
                cash = s.LastOrDefault().cash
            });

            var tempName = closingTemp.GroupBy(s => s.posName + "/" + s.branchName).Select(s => new
            {
                posName = s.Key
            });
            names.AddRange(tempName.Select(nn => nn.posName));

            cashes.AddRange(result.Select(nn => decimal.Parse(SectionData.DecTostring(nn.cash.Value))));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> cS = new List<decimal>();

            List<string> titles = new List<string>()
            {
               MainWindow.resourcemanager.GetString("trCloseCash")
            };
            int x = 6;
            if (names.Count() <= 6) x = names.Count();

            for (int i = 0; i < x; i++)
            {
                cS.Add(cashes.ToList().Skip(i).FirstOrDefault());
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            if (names.Count() > 6)
            {
                decimal balanceSum = 0;
                for (int i = 6; i < names.Count(); i++)
                    balanceSum = balanceSum + cashes.ToList().Skip(i).FirstOrDefault();

                if (balanceSum != 0)
                    cS.Add(balanceSum);

                axcolumn.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
            }

            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cS.AsChartValues(),
                Title = titles[0],
                DataLabels = true,
            });

            DataContext = this;
            cartesianChart.Series = columnChartData;
        }

        #endregion

        #region events
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {//unload
            GC.Collect();
        }

        private async void Cb_closingBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select branch
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await Search();

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

        private void Dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {//select date
            callSearch(sender);
        }

        private void Txt_search_SelectionChanged(object sender, RoutedEventArgs e)
        {//search
            callSearch(sender);
        }

        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                txt_search.Text = "";
                searchText = "";
                await Search();

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
        private async void Chk_closingBranches_Checked(object sender, RoutedEventArgs e)
        {//select all branches
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_closingBranches.SelectedIndex = -1;
                cb_closingBranches.IsEnabled = false;
                await Search();

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

        private async void Chk_closingBranches_Unchecked(object sender, RoutedEventArgs e)
        {//unselect all branches
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_closingBranches.IsEnabled = true;

                await Search();

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
        #endregion

        #region reports
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf

        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//excel

        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview

        }
        #endregion

        #region dataGrid events
        private void moveRowinDatagrid(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                    if (vis is DataGridRow)
                    {
                        POSOpenCloseModel row = (POSOpenCloseModel)dgClosing.SelectedItems[0];

                        Window.GetWindow(this).Opacity = 0.2;
                        wd_transBetweenOpenClose w = new wd_transBetweenOpenClose();
                        w.openCashTransID = row.openCashTransId.Value;
                        w.closeCashTransID = row.cashTransId;
                        w.ShowDialog();
                        Window.GetWindow(this).Opacity = 1;

                    }

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
        int cashTransID = 0, openCashTransID = 0;
        private void printRowinDatagrid(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                    if (vis is DataGridRow)
                    {
                        POSOpenCloseModel row = (POSOpenCloseModel)dgClosing.SelectedItems[0];
                        cashTransID = row.cashTransId;
                        openCashTransID = row.openCashTransId.Value;
                    }

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

        private void pdfRowinDatagrid(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                    if (vis is DataGridRow)
                    {
                        POSOpenCloseModel row = (POSOpenCloseModel)dgClosing.SelectedItems[0];
                        cashTransID = row.cashTransId;
                        openCashTransID = row.openCashTransId.Value;
                    }

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

        private void previewRowinDatagrid(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                    if (vis is DataGridRow)
                    {
                        POSOpenCloseModel row = (POSOpenCloseModel)dgClosing.SelectedItems[0];
                        cashTransID = row.cashTransId;
                        openCashTransID = row.openCashTransId.Value;
                    }

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

      

        private void excelRowinDatagrid(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                    if (vis is DataGridRow)
                    {
                        POSOpenCloseModel row = (POSOpenCloseModel)dgClosing.SelectedItems[0];
                        cashTransID = row.cashTransId;
                        openCashTransID = row.openCashTransId.Value;
                    }

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
        #endregion
    }
}

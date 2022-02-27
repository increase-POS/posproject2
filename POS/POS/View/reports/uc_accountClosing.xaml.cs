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
                    //MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    //MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
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
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_closingStartDate, MainWindow.resourcemanager.GetString("trStartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_closingEndDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_closingBranches, MainWindow.resourcemanager.GetString("trBranchHint"));

            chk_closingBranches.Content = MainWindow.resourcemanager.GetString("trAll");

            tt_closing.Content = MainWindow.resourcemanager.GetString("trItems");

            col_Num.Header = MainWindow.resourcemanager.GetString("trNum");
            col_pos.Header = MainWindow.resourcemanager.GetString("trPOS");
            col_openDate.Header = MainWindow.resourcemanager.GetString("trOpenDate");/////add
            col_openCash.Header = MainWindow.resourcemanager.GetString("trOpenCash");/////add
            col_closeDate.Header = MainWindow.resourcemanager.GetString("trCloseDate");////add
            col_closeCash.Header = MainWindow.resourcemanager.GetString("trCloseCash");/////add
            col_operation.Header = MainWindow.resourcemanager.GetString("trOperations");////add
           
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
            //start date
            (dp_closingStartDate.SelectedDate != null ? t.updateDate >= dp_closingStartDate.SelectedDate : true)
            &&
            //end date
            (dp_closingEndDate.SelectedDate != null ? t.updateDate <= dp_closingEndDate.SelectedDate : true)
            &&
            //branchID
            (cb_closingBranches.SelectedIndex != -1 ? t.branchId == Convert.ToInt32(cb_closingBranches.SelectedValue) : true)
            );

            RefreshClosingView();
            fillBranches();
            fillColumnChart();
            fillRowChart();
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

        private void fillRowChart()
        {
          //  int endYear = DateTime.Now.Year;
          //  int startYear = endYear - 1;
          //  int startMonth = DateTime.Now.Month;
          //  int endMonth = startMonth;
          //  if (dp_startDate.SelectedDate != null && dp_endDate.SelectedDate != null)
          //  {
          //      startYear = dp_startDate.SelectedDate.Value.Year;
          //      endYear = dp_endDate.SelectedDate.Value.Year;
          //      startMonth = dp_startDate.SelectedDate.Value.Month;
          //      endMonth = dp_endDate.SelectedDate.Value.Month;
          //  }

          //  MyAxis.Labels = new List<string>();
          //  List<string> names = new List<string>();
          //  List<CashTransferSts> resultList = new List<CashTransferSts>();

          //  SeriesCollection rowChartData = new SeriesCollection();

          //  var tempName = taxTemp.GroupBy(s => new { s.branchId }).Select(s => new
          //  {
          //      Name = s.FirstOrDefault().updateDate,
          //  });
          //  names.AddRange(tempName.Select(nn => nn.Name.ToString()));
          //  string title = "";
          //  if (selectedTab == 0)
          //      title = MainWindow.resourcemanager.GetString("trTax") + " / " + MainWindow.resourcemanager.GetString("trInvoice");
          //  else if (selectedTab == 1)
          //      title = MainWindow.resourcemanager.GetString("trTax") + " / " + MainWindow.resourcemanager.GetString("trItems");

          //  List<string> lable = new List<string>();
          //  SeriesCollection columnChartData = new SeriesCollection();
          //  List<decimal> taxLst = new List<decimal>();

          //  if (endYear - startYear <= 1)
          //  {
          //      for (int year = startYear; year <= endYear; year++)
          //      {
          //          for (int month = startMonth; month <= 12; month++)
          //          {
          //              var firstOfThisMonth = new DateTime(year, month, 1);
          //              var firstOfNextMonth = firstOfThisMonth.AddMonths(1);
          //              if (selectedTab == 0)
          //              {
          //                  var drawTax = taxTemp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth).Select(c => c.invTaxVal.Value).Sum();

          //                  taxLst.Add(drawTax);
          //              }
          //              if (selectedTab == 1)
          //              {
          //                  var drawTax = taxTemp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth).Select(c => c.itemUnitTaxwithQTY.Value).Sum();

          //                  taxLst.Add(drawTax);
          //              }
          //              MyAxis.Labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + "/" + year);

          //              if (year == endYear && month == endMonth)
          //              {
          //                  break;
          //              }
          //              if (month == 12)
          //              {
          //                  startMonth = 1;
          //                  break;
          //              }
          //          }
          //      }
          //  }
          //  else
          //  {
          //      for (int year = startYear; year <= endYear; year++)
          //      {
          //          var firstOfThisYear = new DateTime(year, 1, 1);
          //          var firstOfNextMYear = firstOfThisYear.AddYears(1);
          //          if (selectedTab == 0)
          //          {
          //              var drawTax = taxTemp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear).Select(c => c.invTaxVal.Value).Sum();
          //              taxLst.Add(drawTax);
          //          }
          //          if (selectedTab == 1)
          //          {
          //              var drawTax = taxTemp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear).Select(c => c.itemUnitTaxwithQTY.Value).Sum();
          //              taxLst.Add(drawTax);
          //          }
          //          MyAxis.Labels.Add(year.ToString());
          //      }
          //  }
          //  rowChartData.Add(
          //new LineSeries
          //{
          //    Values = taxLst.AsChartValues(),
          //    Title = title
          //}); ;

          //  DataContext = this;
          //  rowChart.Series = rowChartData;
        }

        private void fillColumnChart()
        {
            //axcolumn.Labels = new List<string>();
            //List<string> names = new List<string>();
            //List<ItemTransferInvoiceTax> resultList = new List<ItemTransferInvoiceTax>();
            //string title = "";

            //#region group data by selected tab
            //if (selectedTab == 0)
            //{
            //    title = MainWindow.resourcemanager.GetString("trTax") + " / " + MainWindow.resourcemanager.GetString("trInvoice");
            //}
            //else if (selectedTab == 1)
            //{
            //    title = MainWindow.resourcemanager.GetString("trTax") + " / " + MainWindow.resourcemanager.GetString("trItems");
            //}
            //#endregion

            //List<string> lable = new List<string>();
            //SeriesCollection columnChartData = new SeriesCollection();
            //List<decimal> tax = new List<decimal>();

            //if ((chk_allBranches.IsChecked == false) && (cb_branches.SelectedIndex != -1))
            //{
            //    if (selectedTab == 0)
            //        tax.Add(taxTemp.Select(b => b.invTaxVal.Value).Sum());
            //    if (selectedTab == 1)
            //        tax.Add(taxTemp.Select(b => b.itemUnitTaxwithQTY.Value).Sum());

            //    names.AddRange(taxTemp.Where(nn => nn.branchId == (int)cb_branches.SelectedValue).Select(nn => nn.branchName));
            //    axcolumn.Labels.Add(names.ToList().Skip(0).FirstOrDefault());

            //    columnChartData.Add(
            //      new StackedColumnSeries
            //      {
            //          Values = tax.AsChartValues(),
            //          DataLabels = true,
            //          Title = title
            //      });

            //}
            //else
            //{
            //    int count = 0;
            //    if (selectedTab == 0)
            //    {
            //        var temp = taxTemp.GroupBy(t => t.branchId).Select(t => new
            //        {
            //            invTaxVal = t.Sum(p => decimal.Parse(SectionData.DecTostring(p.invTaxVal))),
            //            branchName = t.FirstOrDefault().branchName
            //        });
            //        names.AddRange(temp.Select(nn => nn.branchName));
            //        tax.AddRange(temp.Select(nn => nn.invTaxVal));
            //        count = names.Count();
            //    }
            //    if (selectedTab == 1)
            //    {
            //        var temp = taxTemp.GroupBy(t => t.branchId).Select(t => new
            //        {
            //            itemUnitTaxwithQTY = t.Sum(p => decimal.Parse(SectionData.DecTostring(p.itemUnitTaxwithQTY))),
            //            branchName = t.FirstOrDefault().branchName
            //        });
            //        names.AddRange(temp.Select(nn => nn.branchName));
            //        tax.AddRange(temp.Select(nn => nn.itemUnitTaxwithQTY));
            //        count = names.Count();
            //    }

            //    List<decimal> cS = new List<decimal>();

            //    List<string> titles = new List<string>()
            //    {
            //       title
            //    };
            //    int x = 6;
            //    if (count <= 6) x = count;
            //    for (int i = 0; i < x; i++)
            //    {
            //        cS.Add(tax.ToList().Skip(i).FirstOrDefault());
            //        axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            //    }

            //    if (count > 6)
            //    {
            //        decimal taxSum = 0;
            //        for (int i = 6; i < count; i++)
            //        {
            //            taxSum = taxSum + tax.ToList().Skip(i).FirstOrDefault();
            //        }
            //        if (!((taxSum == 0)))
            //        {
            //            cS.Add(taxSum);

            //            axcolumn.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
            //        }
            //    }
            //    columnChartData.Add(
            //    new StackedColumnSeries
            //    {
            //        Values = cS.AsChartValues(),
            //        Title = titles[0],
            //        DataLabels = true,
            //    });
            //}
            //DataContext = this;
            //cartesianChart.Series = columnChartData;
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

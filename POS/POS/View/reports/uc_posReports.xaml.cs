using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using static POS.Classes.Statistics;

namespace POS.View.reports
{
    public partial class uc_posReports : UserControl
    {
        Statistics statisticModel = new Statistics();
        List<CashTransferSts> list;

        List<branchFromCombo> fromBranches = new List<branchFromCombo>();
        List<branchToCombo> toBranches = new List<branchToCombo>();

        List<posFromCombo> fromPos;
        List<posToCombo> toPos;

        IEnumerable<AccountantCombo> accCombo;

        private static uc_posReports _instance;
        public static uc_posReports Instance
        {
            get
            {
                if (_instance == null) _instance = new uc_posReports();
                return _instance;
            }
        }
        public uc_posReports()
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                list = await statisticModel.GetPosTrans();

                fromBranches = statisticModel.getFromCombo(list);
                toBranches = statisticModel.getToCombo(list);

                fromPos = statisticModel.getFromPosCombo(list);
                toPos = statisticModel.getToPosCombo(list);
                accCombo = list.GroupBy(g => g.updateUserAcc).Select(g => new AccountantCombo { Accountant = g.FirstOrDefault().updateUserAcc }).ToList();

                chk_twoWay.IsChecked = false;
                chk_twoWay.IsEnabled = false;
                fillComboBranches();
                fillComboFromPos();
                fillComboToPos();
                fillAccCombo();

                chk_allFromBranch.IsChecked = true;
                chk_allToBranch.IsChecked = true;
                chk_allFromPos.IsChecked = true;
                chk_allToPos.IsChecked = true;
                chk_allAccountant.IsChecked = true;

                fillEvents();

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_payments.Tag.ToString());

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

        List<CashTransferSts> posLst;
        private List<CashTransferSts> fillList()
        {
            var result = list
          .Where(s =>
          //start date
          (dp_StartDate.SelectedDate    != null  ? s.updateDate  >= dp_StartDate.SelectedDate : true)
          &&
          //end date
          (dp_EndDate.SelectedDate      != null ? s.updateDate <= dp_EndDate.SelectedDate : true)
          &&
          //fromBranch
          ( cb_formBranch.SelectedIndex != -1 ? s.frombranchId  == Convert.ToInt32(cb_formBranch.SelectedValue) : true)
          &&
          //toBranch
          ( cb_toBranch.SelectedIndex != -1   ? s.tobranchId    == Convert.ToInt32(cb_toBranch.SelectedValue)   : true)
          &&
          //accountant
          (cb_Accountant.SelectedIndex != -1 ? s.updateUserAcc == cb_Accountant.SelectedValue.ToString() : true)
          &&
          //twoWay
          (
          chk_twoWay.IsChecked == true ?
              //fromPos
              (cb_formPos.SelectedIndex != -1 ? s.fromposId == Convert.ToInt32(cb_formPos.SelectedValue) || s.toposId == Convert.ToInt32(cb_formPos.SelectedValue) : true)
              &&
              //toPos
              (cb_toPos.SelectedIndex != -1 ? s.toposId == Convert.ToInt32(cb_toPos.SelectedValue) || s.fromposId == Convert.ToInt32(cb_toPos.SelectedValue) : true)
         :
              //fromPos
              (cb_formPos.SelectedIndex != -1 ? s.fromposId == Convert.ToInt32(cb_formPos.SelectedValue) : true)
              &&
              //toPos
              (cb_toPos.SelectedIndex != -1 ? s.toposId == Convert.ToInt32(cb_toPos.SelectedValue) : true)
          )
          );
            posLst = result.ToList();
            return result.ToList();
        }
        private void fillComboBranches()
        {
            cb_formBranch.SelectedValuePath = "BranchFromId";
            cb_formBranch.DisplayMemberPath = "BranchFromName";
            cb_formBranch.ItemsSource = fromBranches;

            cb_toBranch.SelectedValuePath = "BranchToId";
            cb_toBranch.DisplayMemberPath = "BranchToName";
            cb_toBranch.ItemsSource = toBranches;
        }
        private void fillComboFromPos()
        {
            cb_formPos.SelectedValuePath = "PosFromId";
            cb_formPos.DisplayMemberPath = "PosFromName";
            cb_formPos.ItemsSource = fromPos;
            if (cb_formBranch.SelectedItem != null)
            {
                var temp = cb_formBranch.SelectedItem as branchFromCombo;
                cb_formPos.ItemsSource = fromPos.Where(x => x.BranchId == temp.BranchFromId);
            }
        }
        private void fillComboToPos()
        {
            cb_toPos.SelectedValuePath = "PosToId";
            cb_toPos.DisplayMemberPath = "PosToName";
            cb_toPos.ItemsSource = toPos;
            if (cb_toBranch.SelectedItem != null)
            {
                var temp = cb_toBranch.SelectedItem as branchToCombo;
                cb_toPos.ItemsSource = toPos.Where(x => x.BranchId == temp.BranchToId);
            }
        }

        private void fillAccCombo()
        {
            cb_Accountant.SelectedValuePath = "Accountant";
            cb_Accountant.DisplayMemberPath = "Accountant";
            cb_Accountant.ItemsSource = accCombo;
        }

        IEnumerable<CashTransferSts> temp = null;
        private void fillEvents()
        {
            temp = fillList();
            dgPayments.ItemsSource = temp;
            txt_count.Text = temp.Count().ToString();
            fillColumnChart();
            //fillPieChart();
            //fillRowChart();
        }

        private void Cb_formBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillComboFromPos();
                fillEvents();
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

        private void Chk_allFromBranch_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_formBranch.IsEnabled = false;
                cb_formBranch.SelectedItem = null;

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

        private void Chk_allFromBranch_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_formBranch.IsEnabled = true;
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

        private void Chk_allToBranch_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_toBranch.IsEnabled = false;
                cb_toBranch.SelectedItem = null;

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

        private void Chk_allToBranch_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_toBranch.IsEnabled = true;

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

        private void Cb_formPos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if(cb_formPos.SelectedItem != null)
                    chk_twoWay.IsEnabled = true;

                fillEvents();

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

        private void Chk_allFromPos_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_formPos.IsEnabled = false;
                cb_formPos.SelectedItem = null;

                if (cb_toPos.SelectedItem == null)
                    chk_twoWay.IsEnabled = false;

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

        private void Chk_allFromPos_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_formPos.IsEnabled = true;

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

        private void Chk_allToPos_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_toPos.IsEnabled = false;
                cb_toPos.SelectedItem = null;
                if (cb_formPos.SelectedItem == null)
                    chk_twoWay.IsEnabled = false;

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

        private void Chk_allToPos_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_toPos.IsEnabled = true;

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

        private void Cb_toBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillComboToPos();
               
                fillEvents();

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

        private void Cb_toPos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (cb_toPos.SelectedItem != null)
                    chk_twoWay.IsEnabled = true;

                fillEvents();

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

        private void Dp_EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillEvents();
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

        private void Dp_StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillEvents();
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

        private void Cb_Accountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillEvents();

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

        private void Chk_allAccountant_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_Accountant.IsEnabled = false;
                cb_Accountant.SelectedItem = null;

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

        private void Chk_allAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_Accountant.IsEnabled = true;

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

        private void Chk_twoWay_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillEvents();

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

        private void Chk_twoWay_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillEvents();
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

        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            List<int> resultList = new List<int>();
            titles.Clear();
            //var temp = fillList();
            var temp = posLst;
            var result = temp
                .GroupBy(s => new { s.transType })
                .Select(s => new CashTransferSts
                {
                    processTypeCount = s.Count(),
                    processType = s.FirstOrDefault().transType,
                });
            resultList = result.Select(m => m.processTypeCount).ToList();
            titles = result.Select(m => m.processType).ToList();
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < resultList.Count(); i++)
            {
                List<int> final = new List<int>();
                List<string> lable = new List<string>();

                final.Add(resultList.Skip(i).FirstOrDefault());
                lable = titles;
                piechartData.Add(
                  new PieSeries
                  {
                      Values = final.AsChartValues(),
                      Title = lable.Skip(i).FirstOrDefault(),
                      DataLabels = true,
                  }
              );

            }
            chart1.Series = piechartData;
        }

        private void fillColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();

            //var temp = fillList();
            var temp = posLst;

            var res = temp.GroupBy(x => new { x.fromposId }).Select(x => new CashTransferSts
            {
                transType = "p",
                posId = x.FirstOrDefault().fromposId,
                posName = x.FirstOrDefault().fromposName + "/" + x.FirstOrDefault().frombranchName,
                cash = x.Sum(g => g.cash)
            });
            var res1 = temp.GroupBy(x => new { x.toposId }).Select(x => new CashTransferSts
            {
                transType = "d",
                posId = x.FirstOrDefault().toposId,
                posName = x.FirstOrDefault().toposName + "/" + x.FirstOrDefault().tobranchName,
                cash = x.Sum(g => g.cash)
            });
           
            List<CashTransferSts> result = new List<CashTransferSts>();

            result.AddRange(res.ToList());

            if (chk_twoWay.IsChecked == true)
                result.AddRange(res1.ToList());

            var finalResult = result.GroupBy(x => new { x.posId }).Select(x => new CashTransferSts
            {
                transType = x.FirstOrDefault().transType,
                posId = x.FirstOrDefault().posId,
                posName = x.FirstOrDefault().posName,
                depositSum = x.Where(g => g.transType == "d").Sum(g => (decimal)g.cash),
                pullSum    = x.Where(g => g.transType == "p").Sum(g => (decimal)g.cash)
            });
            var tempName = finalResult.Select(s => new
            {
                itemName = s.posName,
            });
            names.AddRange(tempName.Select(nn => nn.itemName));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> cP = new List<decimal>();
            List<decimal> cPb = new List<decimal>();

            int xCount = 6;

            if (names.Count() <= 6)
                xCount = names.Count();

            for (int i = 0; i < xCount; i++)
            {
                cP.Add(finalResult.ToList().Skip(i).FirstOrDefault().depositSum);
                cPb.Add(finalResult.ToList().Skip(i).FirstOrDefault().pullSum);
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            if (names.Count() > 6)
            {
                decimal depositSum = 0, pullSum = 0;
                for (int i = 6; i < names.Count(); i++)
                {
                    depositSum = depositSum + finalResult.ToList().Skip(i).FirstOrDefault().depositSum;
                    pullSum = pullSum + finalResult.ToList().Skip(i).FirstOrDefault().pullSum;
                }
                if (!((depositSum == 0) && (pullSum == 0)))
                {
                    cP.Add(depositSum);
                    cPb.Add(pullSum);

                    axcolumn.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
                }
            }

            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cP.AsChartValues(),
                DataLabels = true,
                Title = MainWindow.resourcemanager.GetString("trDeposit")
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPb.AsChartValues(),
                DataLabels = true,
                Title = MainWindow.resourcemanager.GetString("trPull")
            });

            DataContext = this;
            cartesianChart.Series = columnChartData;
        }

        private void fillRowChart()
        {
            int endYear = DateTime.Now.Year;
            int startYear = endYear - 1;
            int startMonth = DateTime.Now.Month;
            int endMonth = startMonth;
            if (dp_StartDate.SelectedDate != null && dp_EndDate.SelectedDate != null)
            {
                startYear = dp_StartDate.SelectedDate.Value.Year;
                endYear = dp_EndDate.SelectedDate.Value.Year;
                startMonth = dp_StartDate.SelectedDate.Value.Month;
                endMonth = dp_EndDate.SelectedDate.Value.Month;
            }

            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            List<CashTransferSts> resultList = new List<CashTransferSts>();

            //var temp = fillList();
            var temp = posLst;

            SeriesCollection rowChartData = new SeriesCollection();

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> pull = new List<decimal>();
            List<decimal> deposit = new List<decimal>();

            if (endYear - startYear <= 1)
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    for (int month = startMonth; month <= 12; month++)
                    {
                        var firstOfThisMonth = new DateTime(year, month, 1);
                        var firstOfNextMonth = firstOfThisMonth.AddMonths(1);
                        var drawPull = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.transType == "p").Sum(c => c.cash);
                        var drawDeposit= temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.transType == "d").Sum(c => c.cash);
                        pull.Add((decimal)drawPull);
                        deposit.Add((decimal)drawDeposit);

                        MyAxis.Labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + "/" + year);

                        if (year == endYear && month == endMonth)
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
                    var firstOfThisYear = new DateTime(year, 1, 1);
                    var firstOfNextMYear = firstOfThisYear.AddYears(1);
                    var drawPull = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.transType == "p").Sum(c => c.cash.Value);
                    var drawDeposit= temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.transType == "d").Sum(c => c.cash.Value);
                    pull.Add(drawPull);
                    deposit.Add(drawDeposit);
                    MyAxis.Labels.Add(year.ToString());
                }
            }
            rowChartData.Add(
          new LineSeries
          {
              Values = pull.AsChartValues(),
              Title = MainWindow.resourcemanager.GetString("trPull")
          }); 
            rowChartData.Add(
         new LineSeries
         {
             Values = deposit.AsChartValues(),
             Title = MainWindow.resourcemanager.GetString("trDeposit")
         });

            DataContext = this;
            rowChart.Series = rowChartData;
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_formBranch.SelectedItem = null;
                cb_toBranch.SelectedItem = null;
                cb_formPos.SelectedItem = null;
                cb_toPos.SelectedItem = null;
                cb_Accountant.SelectedItem = null;
                chk_allFromBranch.IsChecked = true;
                chk_allToBranch.IsChecked = true;
                chk_allFromPos.IsChecked = true;
                chk_allToPos.IsChecked = true;
                chk_allAccountant.IsChecked = true;
                chk_twoWay.IsChecked = false;
                dp_StartDate.SelectedDate = null;
                dp_EndDate.SelectedDate = null;
                txt_search.Text = "";

                fillEvents();

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

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //dgPayments.ItemsSource = fillList()
                dgPayments.ItemsSource = posLst
                                            .Where(obj => (
                                            obj.transNum.Contains(txt_search.Text) ||
                                            obj.frombranchName.Contains(txt_search.Text) ||
                                            obj.tobranchName.Contains(txt_search.Text) ||
                                            obj.fromposName.Contains(txt_search.Text) ||
                                            obj.toposName.Contains(txt_search.Text) ||
                                            obj.updateUserAcc.Contains(txt_search.Text)
                                            ));

                txt_count.Text = dgPayments.Items.Count.ToString();

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
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath = "";
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\StatisticReport\Accounts\Pos\Ar\ArPos.rdlc";
            }
            else
            {
                addpath = @"\Reports\StatisticReport\Accounts\Pos\En\Pos.rdlc";
            }
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.cashTransferStsPos(temp, rep, reppath, paramarr);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();
        }
            private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                BuildReport();

                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
                }
                #endregion

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

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                BuildReport();
                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));

                #endregion

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

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//excel
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                Thread t1 = new Thread(() =>
            {
              

                BuildReport();
                this.Dispatcher.Invoke(() =>
                {
                    saveFileDialog.Filter = "EXCEL|*.xls;";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filepath = saveFileDialog.FileName;
                        LocalReportExtensions.ExportToExcel(rep, filepath);
                    }
                });


            });
                t1.Start();
                #endregion

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

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                Window.GetWindow(this).Opacity = 0.2;
                string pdfpath = "";

               

                pdfpath = @"\Thumb\report\temp.pdf";
                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                BuildReport();

                LocalReportExtensions.ExportToPDF(rep, pdfpath);
                wd_previewPdf w = new wd_previewPdf();
                w.pdfPath = pdfpath;
                if (!string.IsNullOrEmpty(w.pdfPath))
                {
                    w.ShowDialog();
                    w.wb_pdfWebViewer.Dispose();
                }
                Window.GetWindow(this).Opacity = 1;
                #endregion

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

        private void Btn_payments_Click(object sender, RoutedEventArgs e)
        {
            SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

        }
    }
}

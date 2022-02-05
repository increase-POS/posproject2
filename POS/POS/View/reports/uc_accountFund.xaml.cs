﻿using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using POS.Classes;
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
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.Threading;
using POS.View.windows;
using System.Resources;
using System.Reflection;
using static POS.Classes.Statistics;

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for uc_accountFund.xaml
    /// </summary>
    public partial class uc_accountFund : UserControl
    {
        IEnumerable<BalanceSTS> balances;
        Statistics statisticsModel = new Statistics();
        IEnumerable<BalanceSTS> balancesQuery;
        IEnumerable<BalanceSTS> balancesQueryExcel;
        string searchText = "";
        //int selectedTab = 0;
        //prin & pdf
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        private static uc_accountFund _instance;

        public static uc_accountFund Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_accountFund();
                return _instance;
            }
        }

        public uc_accountFund()
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

        private  void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);

                #region translate
                if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_main.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_main.FlowDirection = FlowDirection.RightToLeft;
            }
            translate();
            #endregion

                chk_allBranches.IsChecked = true;
                chk_allPos.IsChecked = true;
            
                //await Search();

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_branch.Tag.ToString());

                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        async Task Search()
        {

            if (balances is null)
                await RefreshBalanceSTSList();

            searchText = txt_search.Text.ToLower();
            balancesQuery = balances
                .Where(s =>
            (
            s.branchName.ToLower().Contains(searchText)
            ||
            s.posName.ToString().ToLower().Contains(searchText)
            )
            &&
            //branchID
            (cb_branches.SelectedIndex != -1 ? s.branchId == Convert.ToInt32(cb_branches.SelectedValue) : true)
            &&
            //posID
            (cb_pos.SelectedIndex != -1 ? s.posId == Convert.ToInt32(cb_pos.SelectedValue) : true)
            );

            balancesQueryExcel = balancesQuery.ToList();
            RefreshBalancesView();
            fillBranches();
            fillColumnChart();
            fillPieChart();

        }

        void RefreshBalancesView()
        {
            dgFund.ItemsSource = balancesQuery;
            txt_count.Text = balancesQuery.Count().ToString();
            decimal total = balancesQuery.Select(b => b.balance.Value).Sum();
            tb_total.Text = SectionData.DecTostring(total);
        }
        async Task<IEnumerable<BalanceSTS>> RefreshBalanceSTSList()
        {
            balances = await statisticsModel.GetBalance(MainWindow.branchID.Value, MainWindow.userID.Value);
            return balances;

        }

        private void translate()
        {
            tt_branch.Content = MainWindow.resourcemanager.GetString("trBranches");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tt_branch, MainWindow.resourcemanager.GetString("trBranches"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branches, MainWindow.resourcemanager.GetString("trBranch"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos, MainWindow.resourcemanager.GetString("trPOS"));

            chk_allBranches.Content = MainWindow.resourcemanager.GetString("trAll");
            chk_allPos.Content = MainWindow.resourcemanager.GetString("trAll");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");

            col_branchName.Header = MainWindow.resourcemanager.GetString("trBranch");
            col_posName.Header = MainWindow.resourcemanager.GetString("trPOS");
            col_posBalance.Header = MainWindow.resourcemanager.GetString("trBalance");

            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal");
        }

        private void fillBranches()
        {
            cb_branches.SelectedValuePath = "branchId";
            cb_branches.DisplayMemberPath = "branchName";
            cb_branches.ItemsSource = balances.Select(i => new { i.branchName, i.branchId }).Distinct();
        }

        private void fillPos(int bID)
        {
            cb_pos.SelectedValuePath = "posId";
            cb_pos.DisplayMemberPath = "posName";
            cb_pos.ItemsSource = balances.Where(b => b.branchId == bID)
                                                         .Select(i => new {
                                                             i.posName,
                                                             i.posId
                                                         }).Distinct();

        }

        private void fillColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            List<decimal> balances = new List<decimal>();
         
            //var temp = balancesQuery;
            var result = balancesQuery.GroupBy(s => s.posId).Select(s => new
            {
                posId = s.Key,
            });
           
            var tempName = balancesQuery.GroupBy(s => s.posName+"/"+s.branchName).Select(s => new
            {
                posName = s.Key
            });
            names.AddRange(tempName.Select(nn => nn.posName));

            var tempBalance = balancesQuery.GroupBy(s => s.balance).Select(s => new
            {
                balance = s.Key
            });
            balances.AddRange(tempBalance.Select(nn => decimal.Parse(SectionData.DecTostring(nn.balance.Value))));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> cS = new List<decimal>();

            List<string> titles = new List<string>()
            {
               MainWindow.resourcemanager.GetString("tr_Balance")
            };
            int x = 6;
            if (names.Count() <= 6) x = names.Count();

            for (int i = 0; i < x; i++)
            {
                cS.Add(balances.ToList().Skip(i).FirstOrDefault());
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            if (names.Count() > 6)
            {
                decimal balanceSum = 0;
                for (int i = 6 ; i < names.Count(); i++)
                    balanceSum = balanceSum + balances.ToList().Skip(i).FirstOrDefault();

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

        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            IEnumerable<int> x = null;
            IEnumerable<decimal> balances = null;

            titles.Clear();

            //var temp = balancesQuery;
            var titleTemp = balancesQuery.GroupBy(m => m.branchName);
            titles.AddRange(titleTemp.Select(jj => jj.Key));
            var result = balancesQuery.GroupBy(s => s.branchId)
                        .Select(
                            g => new
                            {
                                branchId = g.Key,
                                balance = g.Sum(s => s.balance),
                                count = g.Count()
                            });
            balances = result.Select(m => decimal.Parse(SectionData.DecTostring(m.balance.Value)));

            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < balances.Count(); i++)
            {
                List<decimal> final = new List<decimal>();
                List<string> lable = new List<string>();
                final.Add(balances.ToList().Skip(i).FirstOrDefault());
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

        private async void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select branch
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await Search();
                fillPos(Convert.ToInt32(cb_branches.SelectedValue));

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

        private async void Chk_allBranches_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_branches.SelectedIndex = -1;
                cb_branches.IsEnabled = false;

                //await Search();
                chk_allPos.IsChecked = true;

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

        private async void Chk_allBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_branches.IsEnabled = true;

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

        private async void Cb_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select pos
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

        private async void Chk_allPos_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_pos.SelectedIndex = -1;
                cb_pos.IsEnabled = false;

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

        private async void Chk_allPos_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_pos.IsEnabled = true;

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

        private void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath = "";
            string firstTitle = "fund";
            string secondTitle = "";
            string subTitle = "";
            string Title = "";

            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\StatisticReport\Accounts\Fund\Ar\ArFund.rdlc";

            }
            else
            {
                //english
                addpath = @"\Reports\StatisticReport\Accounts\Fund\En\Fund.rdlc";
            }

            secondTitle = "branch";
            subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
            Title = MainWindow.resourcemanagerreport.GetString("trAccounting") + " / " + subTitle;
            paramarr.Add(new ReportParameter("trTitle", Title));

            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();
            //  getpuritemcount
            paramarr.Add(new ReportParameter("totalBalance", tb_total.Text));
          
            clsReports.FundStsReport(balancesQuery, rep, reppath, paramarr);
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
                List<ItemTransferInvoice> query = new List<ItemTransferInvoice>();

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
                List<ItemTransferInvoice> query = new List<ItemTransferInvoice>();

                #region
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

        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await RefreshBalanceSTSList();
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
      
        private async void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
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

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}

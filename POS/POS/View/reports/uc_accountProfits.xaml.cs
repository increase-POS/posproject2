﻿using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
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
    /// Interaction logic for uc_accountProfits.xaml
    /// </summary>
    public partial class uc_accountProfits : UserControl
    {
        IEnumerable<ItemUnitInvoiceProfit> profits;
        Statistics statisticsModel = new Statistics();
        IEnumerable<ItemUnitInvoiceProfit> profitsQuery;
        IEnumerable<ItemUnitInvoiceProfit> profitsQueryExcel;
        string searchText = "";
        int selectedTab = 0;
        //prin & pdf
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private static uc_accountProfits _instance;

        public static uc_accountProfits Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_accountProfits();
                return _instance;
            }
        }
        public uc_accountProfits()
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

            ////////invoice button//////////??????????????????????????
            //hideAllColumns();

            //col_invNum.Visibility = Visibility.Visible;
            //col_invType.Visibility = Visibility.Visible;
            //col_invTotal.Visibility = Visibility.Visible;
            //col_branch.Visibility = Visibility.Visible;
            //col_pos.Visibility = Visibility.Visible;
            //col_invoiceProfit.Visibility = Visibility.Visible;

            //await Search();

            //SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_invoice.Tag.ToString());
            Btn_invoice_Click(null , null);
            /////////////////////////////?????????????????????????????????

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

        private void translate()
        {
           
        }

        async Task<IEnumerable<ItemUnitInvoiceProfit>> RefreshItemUnitInvoiceProfit()
        {
            profits = await statisticsModel.GetProfit(MainWindow.branchID.Value, MainWindow.userID.Value);
            return profits;
        }

        IEnumerable<ItemUnitInvoiceProfit> profitsTemp = null;
        async Task Search()
        {
            if (profits is null)
                await RefreshItemUnitInvoiceProfit();

            searchText = txt_search.Text.ToLower();
          
            profitsTemp = profits.Where(p =>
            (dp_startDate.SelectedDate != null ? p.updateDate >= dp_startDate.SelectedDate : true)
            &&
            //end date
            (dp_endDate.SelectedDate != null ? p.updateDate <= dp_endDate.SelectedDate : true)
            );

            if (selectedTab == 0)
                profitsTemp = profits.GroupBy(s => s.invoiceId).SelectMany(inv => inv.Take(1)).ToList();
               
            else
                profitsTemp = profits.GroupBy(s => s.ITitemUnitId).SelectMany(inv => inv.Take(1)).ToList();

            profitsQuery = profitsTemp
            .Where(s =>
            (
            s.invNumber.ToLower().Contains(searchText)
            ||
            s.totalNet.ToString().ToLower().Contains(searchText)
            )
            &&
            //branchID/itemID
            (
                (selectedTab == 0 ? cb_branches.SelectedIndex != -1 ? s.branchCreatorId == Convert.ToInt32(cb_branches.SelectedValue) : true
                :
                cb_branches.SelectedIndex != -1 ? s.ITitemId == Convert.ToInt32(cb_branches.SelectedValue) : true)
            )
            &&
            //posID/unitID
            (
                (selectedTab == 0 ? cb_pos.SelectedIndex != -1 ? s.posId == Convert.ToInt32(cb_pos.SelectedValue) : true
                :
                cb_pos.SelectedIndex != -1 ? s.ITunitId == Convert.ToInt32(cb_pos.SelectedValue) : true)
                )
            );

            var profitsSum = profitsQuery.GroupBy(s => s.invoiceId).Select(g => new {
                invoiceId = g.FirstOrDefault().invoiceId,
                invoiceProfit = g.Sum(p => p.itemunitProfit)
            }).ToList();
            foreach (var i in profitsSum)
            {
                profitsQuery.Select(x => x.invoiceProfit = (i.invoiceId == x.invoiceId) ? i.invoiceProfit : x.invoiceProfit);
            }

            profitsQueryExcel = profitsQuery.ToList();
            RefreshProfitsView();
            fillCombo1();
            fillColumnChart();
            fillPieChart();
            fillRowChart();
        }

        void RefreshProfitsView()
        {
            dgFund.ItemsSource = profitsQuery;
            txt_count.Text = profitsQuery.Count().ToString();
            //decimal total = profitsQuery.Select(b => b.balance.Value).Sum();
            //tb_total.Text = SectionData.DecTostring(total);
        }

        private void fillCombo1()
        {
            if (selectedTab == 0)
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branches, MainWindow.resourcemanager.GetString("trBranchHint"));
                cb_branches.SelectedValuePath = "branchCreatorId";
                cb_branches.DisplayMemberPath = "branchCreatorName";
                cb_branches.ItemsSource = profits.GroupBy(g=>g.branchCreatorId).Select(i => new { i.FirstOrDefault(). branchCreatorName, i.FirstOrDefault().branchCreatorId });
            }
            else if(selectedTab == 1)
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branches, MainWindow.resourcemanager.GetString("trItemHint"));
                cb_branches.SelectedValuePath = "ITitemId";
                cb_branches.DisplayMemberPath = "ITitemName";
                cb_branches.ItemsSource = profits.GroupBy(g => g.ITitemId).Select(i => new { i.FirstOrDefault().ITitemId, i.FirstOrDefault().ITitemName });
            }
        }

        private void fillCombo2(int bID)
        {
            if(selectedTab == 0)
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos, MainWindow.resourcemanager.GetString("trPosHint"));
                cb_pos.SelectedValuePath = "posId";
                cb_pos.DisplayMemberPath = "posName";
                cb_pos.ItemsSource = profits.Where(b => b.branchId == bID).GroupBy(g => g.posId).Select(i => new {
                                                                                  i.FirstOrDefault().posId , i.FirstOrDefault().posName });
            }
            else if(selectedTab == 1)
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos, MainWindow.resourcemanager.GetString("trUnitHint"));
                cb_pos.SelectedValuePath = "ITunitId";
                cb_pos.DisplayMemberPath = "ITunitName";
                cb_pos.ItemsSource = profits.Where(b => b.ITitemId == bID).GroupBy(g => g.ITunitId).Select(i => new {
                                                                                  i.FirstOrDefault().ITunitId, i.FirstOrDefault().ITunitName});
            }

        }
        private async void Btn_invoice_Click(object sender, RoutedEventArgs e)
        {//invoices
         //try
         //{
         //    if (sender != null)
         //        SectionData.StartAwait(grid_main);

            hideAllColumns();
            //SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
            selectedTab = 0;

            col_invNum.Visibility = Visibility.Visible;
            col_invType.Visibility = Visibility.Visible;
            col_invTotal.Visibility = Visibility.Visible;
            col_branch.Visibility = Visibility.Visible;
            col_pos.Visibility = Visibility.Visible;
            col_invoiceProfit.Visibility = Visibility.Visible;

            txt_search.Text = "";
           
            path_item.Fill = Brushes.White;
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
            ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_invoice);
            path_invoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            await Search();

            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //}
            //    catch (Exception ex)
            //    {
            //        if (sender != null)
            //            SectionData.EndAwait(grid_main);
            //        SectionData.ExceptionMessage(ex, this);
            //}
        }

        private async void Btn_item_Click(object sender, RoutedEventArgs e)
        {//items
         //try
         //{
         //    if (sender != null)
         //        SectionData.StartAwait(grid_main);

            hideAllColumns();
            SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
            selectedTab = 1;
            col_itemName.Visibility = Visibility.Visible;
            col_unitName.Visibility = Visibility.Visible;
            col_quantity.Visibility = Visibility.Visible;
            col_itemProfit.Visibility = Visibility.Visible;

            txt_search.Text = "";
            path_invoice.Fill = Brushes.White;
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
            ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_item);
            path_item.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            await Search();

            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //}
            //    catch (Exception ex)
            //    {
            //        if (sender != null)
            //            SectionData.EndAwait(grid_main);
            //        SectionData.ExceptionMessage(ex, this);
            //}
        }

        private void hideAllColumns()
        {
            col_itemName.Visibility = Visibility.Collapsed;
            col_unitName.Visibility = Visibility.Collapsed;
            col_quantity.Visibility = Visibility.Collapsed;
            col_invNum.Visibility = Visibility.Collapsed;
            col_invType.Visibility = Visibility.Collapsed;
            col_invTotal.Visibility = Visibility.Collapsed;
            col_branch.Visibility = Visibility.Collapsed;
            col_pos.Visibility = Visibility.Collapsed;
            col_invoiceProfit.Visibility = Visibility.Collapsed;
            col_itemProfit.Visibility = Visibility.Collapsed;
        }
        private async void Chk_allBranches_Checked(object sender, RoutedEventArgs e)
        {//select all branches
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_branches.SelectedIndex = -1;
                cb_branches.IsEnabled = false;
                
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

        private async void Chk_allBranches_Unchecked(object sender, RoutedEventArgs e)
        {//unselect all branches
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

        private async void Chk_allPos_Checked(object sender, RoutedEventArgs e)
        {//select all pos
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
        {//unselect all pos
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

        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
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
        private async void RefreshView_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {//change selection
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

        private async void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select branch
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await Search();
                fillCombo2(Convert.ToInt32(cb_branches.SelectedValue));

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

      
        private void BuildReport()
        {
            //List<ReportParameter> paramarr = new List<ReportParameter>();

            //string addpath;
            //bool isArabic = ReportCls.checkLang();
            //if (isArabic)
            //{
            //    addpath = @"\Reports\StatisticReport\Sale\Daily\Ar\dailySale.rdlc";
            //    //Reports\StatisticReport\Sale\Daily\Ar
            //}
            //else
            //    addpath = @"\Reports\StatisticReport\Sale\Daily\En\dailySale.rdlc";
            //string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            //ReportCls.checkLang();

            //clsReports.SaledailyReport(profitsQuery, rep, reppath, paramarr);
            //clsReports.setReportLanguage(paramarr);
            //clsReports.Header(paramarr);

            //rep.SetParameters(paramarr);

            //rep.Refresh();
        }

        private void fillColumnChart()
        {
            //axcolumn.Labels = new List<string>();
            //List<string> names = new List<string>();
            //IEnumerable<int> x = null;

            //var temp = balancesQuery;
            //var result = temp.GroupBy(s => s.branchId).Select(s => new
            //{
            //    branchCreatorId = s.Key,
            //    countS = s.Count(),
            //});
            //x = result.Select(m => m.countS);

            //var tempName = temp.GroupBy(s => s.branchName).Select(s => new
            //{
            //    branchName = s.Key
            //});
            //names.AddRange(tempName.Select(nn => nn.branchName));

            //List<string> lable = new List<string>();
            //SeriesCollection columnChartData = new SeriesCollection();
            //List<int> cS = new List<int>();

            //List<string> titles = new List<string>()
            //{
            //   MainWindow.resourcemanager.GetString("tr_Balance")
            //};
            //for (int i = 0; i < x.Count(); i++)
            //{
            //    cS.Add(x.ToList().Skip(i).FirstOrDefault());
            //    axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            //}

            //columnChartData.Add(
            //new StackedColumnSeries
            //{
            //    Values = cS.AsChartValues(),
            //    Title = titles[0],
            //    DataLabels = true,
            //});

            //DataContext = this;
            //cartesianChart.Series = columnChartData;
        }

        private void fillPieChart()
        {
            //List<string> titles = new List<string>();
            //IEnumerable<int> x = null;

            //titles.Clear();
            //var temp = balancesQuery;
            //var titleTemp = temp.GroupBy(m => m.branchName);
            //titles.AddRange(titleTemp.Select(jj => jj.Key));
            //var result = temp.GroupBy(s => s.branchId).Select(s => new { branchCreatorId = s.Key, count = s.Count() });
            //x = result.Select(m => m.count);

            //SeriesCollection piechartData = new SeriesCollection();
            //for (int i = 0; i < x.Count(); i++)
            //{
            //    List<int> final = new List<int>();
            //    List<string> lable = new List<string>();
            //    final.Add(x.ToList().Skip(i).FirstOrDefault());
            //    piechartData.Add(
            //      new PieSeries
            //      {
            //          Values = final.AsChartValues(),
            //          Title = titles.Skip(i).FirstOrDefault(),
            //          DataLabels = true,
            //      }
            //  );
            //}
            //chart1.Series = piechartData;
        }

        private void fillRowChart()
        {
            //    MyAxis.Labels = new List<string>();
            //    List<string> names = new List<string>();
            //    IEnumerable<decimal> pTemp = null;
            //    IEnumerable<decimal> pbTemp = null;
            //    IEnumerable<decimal> resultTemp = null;

            //    var temp = balancesQuery;
            //    var result = temp.GroupBy(s => s.branchId).Select(s => new
            //    {
            //        branchCreatorId = s.Key,
            //        totalS = s.Sum(x => x.balance)
            //    }
            //    );
            //    var resultTotal = result.Select(x => new { x.branchCreatorId, total = x.totalS - x.totalSb }).ToList();
            //    pTemp = result.Select(x => (decimal)x.totalS);

            //    resultTemp = result.Select(x => (decimal)x.totalS);
            //    var tempName = temp.GroupBy(s => s.branchCreatorName).Select(s => new
            //    {
            //        uUserName = s.Key
            //    });
            //    names.AddRange(tempName.Select(nn => nn.uUserName));
            //    //}

            //    SeriesCollection rowChartData = new SeriesCollection();
            //    List<decimal> purchase = new List<decimal>();
            //    List<decimal> returns = new List<decimal>();
            //    List<decimal> sub = new List<decimal>();
            //    List<string> titles = new List<string>()
            //    {
            //                 "اجمالي المبيعات","اجمالي المرتجع","صافي المبيعات"
            //    };
            //    for (int i = 0; i < pbTemp.Count(); i++)
            //    {
            //        purchase.Add(pTemp.ToList().Skip(i).FirstOrDefault());
            //        returns.Add(pbTemp.ToList().Skip(i).FirstOrDefault());
            //        sub.Add(resultTemp.ToList().Skip(i).FirstOrDefault());
            //        MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            //    }

            //    rowChartData.Add(
            //  new LineSeries
            //  {
            //      Values = purchase.AsChartValues(),
            //      Title = titles[0]
            //  }); ;
            //    rowChartData.Add(
            // new LineSeries
            // {
            //     Values = returns.AsChartValues(),
            //     Title = titles[1]
            // });
            //    rowChartData.Add(
            //new LineSeries
            //{
            //    Values = sub.AsChartValues(),
            //    Title = titles[2]

            //});
            //    DataContext = this;
            //    rowChart.Series = rowChartData;
        }

      
    }
}

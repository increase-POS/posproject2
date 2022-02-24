﻿using LiveCharts;
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
    /// Interaction logic for us_saleTax.xaml
    /// </summary>
    public partial class us_saleTax : UserControl
    {
       
        IEnumerable<ItemTransferInvoiceTax> taxes;
        IEnumerable<ItemTransferInvoiceTax> taxTemp = null;
        //IEnumerable<ItemTransferInvoiceTax> taxQuery;
        //IEnumerable<ItemTransferInvoiceTax> taxQueryExcel;
        Statistics statisticsModel = new Statistics();
        string searchText = "";
        int selectedTab = 0;

        private static us_saleTax _instance;

        public static us_saleTax Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new us_saleTax();
                return _instance;
            }
        }
        public us_saleTax()
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


                txt_search.Text = "";

                if (!MainWindow.invoiceTax_bool.Value)
                {
                    bdr_invoice.Visibility = Visibility.Collapsed;
                    bdr_item.Margin = new Thickness(10, 5, 0, -1);
                    bdr_item.Visibility = Visibility.Visible;
                    Btn_item_Click(btn_item, null);
                }
                else if (!MainWindow.itemsTax_bool.Value)
                {
                    bdr_invoice.Visibility = Visibility.Visible;
                    bdr_item.Visibility = Visibility.Collapsed;
                    bdr_item.Margin = new Thickness(0, 5, 0, -1);
                    Btn_invoice_Click(btn_invoice, null);
                }
                else
                {
                    bdr_invoice.Visibility = Visibility.Visible;
                    bdr_item.Visibility = Visibility.Visible;
                    bdr_item.Margin = new Thickness(0, 5, 0, -1);
                    Btn_invoice_Click(btn_invoice, null);
                }

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_invoice.Tag.ToString());

                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    //if (sender != null)
            //    //    SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }

        #region methods
        void fillBranches()
        {
            var iulist = taxTemp.GroupBy(g => g.branchId).Select(g => new { branchId = g.FirstOrDefault().branchId, branchName = g.FirstOrDefault().branchName }).ToList();
            cb_branches.SelectedValuePath = "branchId";
            cb_branches.DisplayMemberPath = "branchName";
            cb_branches.ItemsSource = iulist;
        }

        async Task Search()
        {
            if (taxes is null)
                await RefreshTaxList();

            searchText = txt_search.Text.ToLower();

            if(selectedTab == 0)
                taxTemp = taxes.GroupBy(t => t.invoiceId).SelectMany(inv => inv.Take(1)).ToList();
            else
                taxTemp = taxes;

            taxTemp = taxTemp.Where(t =>
            //start date
            (dp_startDate.SelectedDate != null ? t.updateDate >= dp_startDate.SelectedDate : true)
            &&
            //end date
            (dp_endDate.SelectedDate != null ? t.updateDate <= dp_endDate.SelectedDate : true)
            &&
            //branchID
            (cb_branches.SelectedIndex != -1 ? t.branchId == Convert.ToInt32(cb_branches.SelectedValue) : true)
            );
           
            RefreshTaxView();
            fillBranches();
            fillColumnChart();
            fillRowChart();
        }

        private void RefreshTaxView()
        {
            dgTax.ItemsSource = taxTemp;
            txt_count.Text = taxTemp.Count().ToString();

            decimal total = 0;

            if(selectedTab == 0)
                total = taxTemp.Select(b => b.invTaxVal.Value).Sum();
            else
                total = taxTemp.Select(b => b.itemUnitTaxwithQTY.Value).Sum();

            tb_total.Text = SectionData.DecTostring(total);
        }

      
        async Task<IEnumerable<ItemTransferInvoiceTax>> RefreshTaxList()
        {
            taxes = await statisticsModel.GetInvItemTax(MainWindow.branchID.Value, MainWindow.userID.Value);
            return taxes;
        }
        private void translate()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_startDate, MainWindow.resourcemanager.GetString("trStartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_endDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));

            chk_allBranches.Content = MainWindow.resourcemanager.GetString("trAll");

            tt_invoice.Content = MainWindow.resourcemanager.GetString("trInvoices");
            tt_item.Content = MainWindow.resourcemanager.GetString("trItems");
            ////////////////////////////////grid//////////////////////////////////////
            col_invNum.Header = MainWindow.resourcemanager.GetString("trNum");
            col_Date.Header = MainWindow.resourcemanager.GetString("trDate");
            col_branch.Header = MainWindow.resourcemanager.GetString("trBranch");
            ////invoice
            col_invQuantity.Header = MainWindow.resourcemanager.GetString("trQTR");
            col_invTotal.Header = MainWindow.resourcemanager.GetString("trTotal");
            col_taxOnInvoice.Header = MainWindow.resourcemanager.GetString("trTaxValue");
            col_invTaxPercent.Header = MainWindow.resourcemanager.GetString("trTaxPercentage");
            col_totalNet.Header = MainWindow.resourcemanager.GetString("trTotalInvoice");
            ////item
            col_itemunitName.Header = MainWindow.resourcemanager.GetString("trItemUnit");
            col_taxOnItems.Header = MainWindow.resourcemanager.GetString("trOnItem");
            col_price.Header = MainWindow.resourcemanager.GetString("trPrice");
            col_itemsQuantity.Header = MainWindow.resourcemanager.GetString("trQTR");
            col_taxOnItems.Header = MainWindow.resourcemanager.GetString("trTaxValue");
            col_itemTaxPercent.Header = MainWindow.resourcemanager.GetString("trTaxPercentage");
            col_itemsTotal.Header = MainWindow.resourcemanager.GetString("trTotal");
            col_totalNetItem.Header = MainWindow.resourcemanager.GetString("trTotalInvoice");
            //////////////////////////////////////////////////////////////////////////

            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

            txt_total.Text = MainWindow.resourcemanager.GetString("trTotalTax");
        }

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
        private void hideAllColumns()
        {
            for (int i = 3; i < dgTax.Columns.Count; i++)
                dgTax.Columns[i].Visibility = Visibility.Hidden;
        }

        #endregion

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {//unload
            GC.Collect();
        }

        private async void Btn_invoice_Click(object sender, RoutedEventArgs e)
        {//invoice
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                
                hideAllColumns();
                selectedTab = 0;
                tb_total.Text = "";

                col_invQuantity.Visibility = Visibility.Visible;
                col_invTotal.Visibility = Visibility.Visible;
                col_taxOnInvoice.Visibility = Visibility.Visible;
                col_invTaxPercent.Visibility = Visibility.Visible;
                col_totalNet.Visibility = Visibility.Visible;

                txt_search.Text = "";

                path_item.Fill = Brushes.White;
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_invoice);
                path_invoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                chk_allBranches.IsChecked = true;
                Chk_allBranches_Checked(chk_allBranches,null);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

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
        private async void Btn_item_Click(object sender, RoutedEventArgs e)
        {//items
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                hideAllColumns();
                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

                selectedTab = 1;
                tb_total.Text = "";

                chk_allBranches.IsChecked = true;
                Chk_allBranches_Checked(chk_allBranches, null);

                col_itemunitName.Visibility = Visibility.Visible;
                col_taxOnItems.Visibility = Visibility.Visible;
                col_totalNet.Visibility = Visibility.Collapsed;
                col_price.Visibility = Visibility.Visible;
                col_itemsQuantity.Visibility = Visibility.Visible;
                col_taxOnItems.Visibility = Visibility.Visible;
                col_itemTaxPercent.Visibility = Visibility.Visible;
                col_itemsTotal.Visibility = Visibility.Visible;
                col_totalNetItem.Visibility = Visibility.Visible;

                txt_search.Text = "";
                path_invoice.Fill = Brushes.White;
                bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_item);
                path_item.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

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
        {//select all branches
            //try
            //{
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);

                cb_branches.SelectedIndex = -1;
                cb_branches.IsEnabled = false;
                await Search();

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

        private void RefreshView_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {//change selection
            callSearch(sender);
        }

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            callSearch(sender);
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            callSearch(sender);
        }

        
        #region charts

        private void fillRowChart()
        {
            #region old
            //MyAxis.Labels = new List<string>();
            //List<string> names = new List<string>();
            //List<int> ids = new List<int>();
            //List<int> otherIds = new List<int>();

            //List<ItemUnitInvoiceProfit> resultList = new List<ItemUnitInvoiceProfit>();
            //SeriesCollection rowChartData = new SeriesCollection();

            //var tempName = taxTemp.GroupBy(s => new { s.branchId }).Select(s => new
            //{
            //    id = s.Key,
            //    name = s.FirstOrDefault().branchName
            //});
            //names.AddRange(tempName.Select(nn => nn.name.ToString()));
            //ids.AddRange(tempName.Select(mm => mm.id.branchId.Value));

            ////LineSeries[] ls = new LineSeries[names.Count];
            //int x = 6;
            //if (names.Count() < 6) x = names.Count();
            //for (int i = 0; i < x; i++)
            //{
            //    drawPoints(names[i], ids[i], rowChartData, 'n', otherIds);
            //}
            ////others
            //if (names.Count() > 6)
            //{
            //    for (int i = names.Count - x; i < names.Count; i++)
            //        otherIds.Add(ids[i]);
            //    drawPoints(MainWindow.resourcemanager.GetString("trOthers"), 0, rowChartData, 'o', otherIds);
            //}
            ////rowChartData.AddRange(ls);
            //DataContext = this;
            //rowChart.Series = rowChartData;
            #endregion
            int endYear = DateTime.Now.Year;
            int startYear = endYear - 1;
            int startMonth = DateTime.Now.Month;
            int endMonth = startMonth;
            if (dp_startDate.SelectedDate != null && dp_endDate.SelectedDate != null)
            {
                startYear = dp_startDate.SelectedDate.Value.Year;
                endYear = dp_endDate.SelectedDate.Value.Year;
                startMonth = dp_startDate.SelectedDate.Value.Month;
                endMonth = dp_endDate.SelectedDate.Value.Month;
            }

            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            List<CashTransferSts> resultList = new List<CashTransferSts>();

            SeriesCollection rowChartData = new SeriesCollection();

            var tempName = taxTemp.GroupBy(s => new { s.branchId }).Select(s => new
            {
                Name = s.FirstOrDefault().updateDate,
            });
            names.AddRange(tempName.Select(nn => nn.Name.ToString()));
            string title = "";
            if (selectedTab == 0)
                title = MainWindow.resourcemanager.GetString("trInvoice");
            else if(selectedTab == 1)
               title = MainWindow.resourcemanager.GetString("trItems");

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> taxLst = new List<decimal>();

            if (endYear - startYear <= 1)
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    for (int month = startMonth; month <= 12; month++)
                    {
                        var firstOfThisMonth = new DateTime(year, month, 1);
                        var firstOfNextMonth = firstOfThisMonth.AddMonths(1);
                        if (selectedTab == 0)
                        {
                            var drawTax = taxTemp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth).Select(c => c.invTaxVal.Value).Sum();

                            taxLst.Add(drawTax);
                        }
                        if (selectedTab == 1)
                        {
                            var drawTax = taxTemp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth).Select(c => c.itemUnitTaxwithQTY.Value).Sum();

                            taxLst.Add(drawTax);
                        }
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
                    if (selectedTab == 0)
                    {
                        var drawTax = taxTemp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear).Select(c => c.invTaxVal.Value).Sum();
                        taxLst.Add(drawTax);
                    }
                    if (selectedTab == 1)
                    {
                        var drawTax = taxTemp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear).Select(c => c.itemUnitTaxwithQTY.Value).Sum();
                        taxLst.Add(drawTax);
                    }
                    MyAxis.Labels.Add(year.ToString());
                }
            }
            rowChartData.Add(
          new LineSeries
          {
              Values = taxLst.AsChartValues(),
              Title = title
          }); ;
        
            DataContext = this;
            rowChart.Series = rowChartData;
        }

        private void fillColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            List<ItemTransferInvoiceTax> resultList = new List<ItemTransferInvoiceTax>();
            string title = "";
            #region group data by selected tab
            if (selectedTab == 0)
            {
                title = MainWindow.resourcemanager.GetString("trInvoice");
                //resultList = taxTemp.GroupBy(x => x.invoiceId).Select(x => new ItemTransferInvoiceTax
                //{
                //    invTaxVal = x.Sum(g => (decimal)g.invTaxVal),
                //}
                //).ToList();

            }
            else if (selectedTab == 1)
            {
                title = MainWindow.resourcemanager.GetString("trItems");
                
                //resultList = taxTemp.GroupBy(x => x.ITitemsTransId).Select(x => new ItemTransferInvoiceTax
                //{
                //    itemUnitTaxwithQTY = x.Sum(g => (decimal)g.itemUnitTaxwithQTY),
                //}
                //).ToList();

            }

            #endregion

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> tax = new List<decimal>();

            //for (int i = 0; i < resultList.Count(); i++)
            //{
            //    if(selectedTab == 0)
            //        tax.Add(resultList.ToList().Skip(i).FirstOrDefault().invTaxVal.Value);
            //    //else if(selectedTab == 1)
            //    //    tax.Add(resultList.ToList().Skip(i).FirstOrDefault().itemUnitTaxwithQTY.Value);
            //}
            if (selectedTab == 0)
                tax.Add(taxTemp.Select(b => b.invTaxVal.Value).Sum());
            if (selectedTab == 1)
                tax.Add(taxTemp.Select(b => b.itemUnitTaxwithQTY.Value).Sum());
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = tax.AsChartValues(),
                DataLabels = true,
                Title = title
            });
         
            DataContext = this;
            cartesianChart.Series = columnChartData;

        }
       
        #endregion

        #region reports
        //prin & pdf
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        private void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath;

            string firstTitle = "accountProfits";
            string secondTitle = "";
            string subTitle = "";
            string Title = "";

            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\StatisticReport\Accounts\Profit\Ar\Profit.rdlc";
                secondTitle = "invoice";

                //Reports\StatisticReport\Sale\Daily\Ar
            }
            else
            {
                addpath = @"\Reports\StatisticReport\Accounts\Profit\En\Profit.rdlc";
                secondTitle = "invoice";
            }

            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();
            subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
            Title = MainWindow.resourcemanagerreport.GetString("trAccounting") + " / " + subTitle;
            paramarr.Add(new ReportParameter("trTitle", Title));

            // IEnumerable<ItemUnitInvoiceProfit>
            //clsReports.ProfitReport(profitsQuery, rep, reppath, paramarr);
            paramarr.Add(new ReportParameter("totalBalance", tb_total.Text));

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

        #endregion

       
    }
}

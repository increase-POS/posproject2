using LiveCharts;
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

    public partial class us_dailySalesStatistic : UserControl
    {

        IEnumerable<ItemTransferInvoice> itemTrasferInvoices;
        Statistics statisticsModel = new Statistics();
        IEnumerable<ItemTransferInvoice> itemTrasferInvoicesQuery;
        IEnumerable<ItemTransferInvoice> itemTrasferInvoicesQueryExcel;
        string searchText = "";
        int selectedTab = 0;
        //prin & pdf
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        private static us_dailySalesStatistic _instance;
       
        public static us_dailySalesStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new us_dailySalesStatistic();
                return _instance;
            }
        }

        public us_dailySalesStatistic()
        {
            InitializeComponent();
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

                dp_invoiceDate.SelectedDate = DateTime.Now;
                chk_invoice.IsChecked = true;
                chk_return.IsChecked = true;
                chk_drafs.IsChecked = true;
                chk_allBranches.IsChecked = true;
                chk_allPos.IsChecked = true;

                await RefreshItemTransferInvoiceList();
                await Search();

            SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_invoice.Tag.ToString());

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

        async Task<IEnumerable<ItemTransferInvoice>> RefreshItemTransferInvoiceList()
        {
            itemTrasferInvoices = await statisticsModel.Getdailyinvoice(MainWindow.branchID.Value , MainWindow.userID.Value, dp_invoiceDate.SelectedDate.Value.Date);
            return itemTrasferInvoices;

        }

        async Task Search()
        {

            if (itemTrasferInvoices is null)
                await RefreshItemTransferInvoiceList();

            searchText = txt_search.Text.ToLower();
            itemTrasferInvoicesQuery = itemTrasferInvoices
                .Where(s => 
            (
            s.invNumber.ToLower().Contains(searchText)
            || 
            s.tax.ToString().ToLower().Contains(searchText)
            )
            &&
            (//invType
                //(chk_invoice.IsChecked == true ? s.invType == "s"  : false)
                //||
                //(chk_return.IsChecked  == true ? s.invType == "sb" : false)
                //||
                //(chk_drafs.IsChecked   == true ? s.invType == "sd" : false)
                (
                    selectedTab == 0 //invoice
                    ?
                    (chk_invoice.IsChecked == true ? s.invType == "s" : false)
                    ||
                    (chk_return.IsChecked == true ? s.invType == "sb" : false)
                    ||
                    (chk_drafs.IsChecked == true ? s.invType == "sd" : false)
                    : false
                )
                ||
                (
                    selectedTab == 1 //order
                    ?
                    (chk_invoice.IsChecked == true ? s.invType == "or" : false)
                    ||
                    (chk_return.IsChecked == true ? s.invType == "sbd" : false)/////????
                    ||
                    (chk_drafs.IsChecked == true ? s.invType == "ord" : false)
                    : false
                )
                ||
                (
                    selectedTab == 2 //quotation
                    ?
                    (chk_invoice.IsChecked == true ? s.invType == "q" : false)
                    ||
                    (chk_return.IsChecked == true ? s.invType == "sbd" : false)/////????
                    ||
                    (chk_drafs.IsChecked == true ? s.invType == "qd" : false)
                    : false
                )
            )
            &&
            //branchID
            (cb_branches.SelectedIndex != -1 ? s.branchCreatorId == Convert.ToInt32(cb_branches.SelectedValue) : true)
            &&
            //posID
            (cb_pos.SelectedIndex != -1 ? s.posId == Convert.ToInt32(cb_pos.SelectedValue) : true)
            );

            itemTrasferInvoicesQueryExcel = itemTrasferInvoicesQuery.ToList();
            RefreshIemTrasferInvoicesView();
            fillBranches();
            fillColumnChart();
            fillPieChart();
            fillRowChart();
        }

        void RefreshIemTrasferInvoicesView()
        {
            dgInvoice.ItemsSource = itemTrasferInvoicesQuery;
            txt_count.Text = itemTrasferInvoicesQuery.Count().ToString();
        }

        private void fillBranches()
        {
            cb_branches.SelectedValuePath = "branchCreatorId";
            cb_branches.DisplayMemberPath = "branchCreatorName";
            cb_branches.ItemsSource = itemTrasferInvoices.Select(i => new { i.branchCreatorName, i.branchCreatorId }).Distinct();
        }
        private async void Btn_Invoice_Click(object sender, RoutedEventArgs e)
        {//invoice tab
            //try
            //{
            //    if (sender != null)
            //        SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                selectedTab = 0;
                txt_search.Text = "";
                chk_return.Visibility = Visibility.Visible;
                //chk_return.IsChecked = false;
                path_order.Fill = Brushes.White;
                path_quotation.Fill = Brushes.White;
                bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_invoice);
                path_invoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                //ReportsHelp.showTabControlGrid(grid_father, grid_invoice);
                //ReportsHelp.isEnabledButtons(grid_tabControl, btn_invoice);

                await RefreshItemTransferInvoiceList();
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
        private async void Btn_order_Click(object sender, RoutedEventArgs e)
        {//order tab
            //try
            //{
            //    if (sender != null)
            //        SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

                selectedTab = 1;
                txt_search.Text = "";
                chk_return.Visibility = Visibility.Collapsed;
                chk_return.IsChecked = false;
                path_invoice.Fill = Brushes.White;
                path_quotation.Fill = Brushes.White;
                bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_order);
                path_order.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                //ReportsHelp.showTabControlGrid(grid_father, grid_order);
                //ReportsHelp.isEnabledButtons(grid_tabControl, btn_order);

                await RefreshItemTransferInvoiceList();
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
        private async void Btn_quotation_Click(object sender, RoutedEventArgs e)
        {//quotation tab
            //try
            //{
            //    if (sender != null)
            //        SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

                selectedTab = 2;
                txt_search.Text = "";
                chk_return.Visibility = Visibility.Collapsed;
                chk_return.IsChecked = false;
                path_invoice.Fill = Brushes.White;
                path_order.Fill = Brushes.White;
                bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_quotation);
                path_quotation.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                //ReportsHelp.showTabControlGrid(grid_father, grid_quotation);
                //ReportsHelp.isEnabledButtons(grid_tabControl, btn_quotation);

                await RefreshItemTransferInvoiceList();
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
        private async void RefreshView_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await RefreshItemTransferInvoiceList();
                await Search();
                fillBranches();

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
        private async void RefreshViewCheckbox(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await RefreshItemTransferInvoiceList();
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
        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            IEnumerable<int> x = null;
            //if (selectedTab == 0)
            //{
            titles.Clear();
            var temp = itemTrasferInvoicesQuery;
            var titleTemp = temp.GroupBy(m => m.branchCreatorName);
            titles.AddRange(titleTemp.Select(jj => jj.Key));
            var result = temp.GroupBy(s => s.branchCreatorId).Select(s => new { branchCreatorId = s.Key, count = s.Count() });
            x = result.Select(m => m.count);
            //}
           
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < x.Count(); i++)
            {
                List<int> final = new List<int>();
                List<string> lable = new List<string>();
                final.Add(x.ToList().Skip(i).FirstOrDefault());
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

        private void fillColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<int> x = null;
            IEnumerable<int> y = null;
            IEnumerable<int> z = null;
            //if (selectedTab == 0)
            //{
            var temp = itemTrasferInvoicesQuery;
            var result = temp.GroupBy(s => s.branchCreatorId).Select(s => new
            {
                branchCreatorId = s.Key,
                countS  = s.Where(m =>  m.invType == "s").Count(),
                countSb = s.Where(m => m.invType == "sb").Count(),
                countSd = s.Where(m =>  m.invType == "sd").Count()
            });
            x = result.Select(m => m.countS);
            y = result.Select(m => m.countSb);
            z = result.Select(m => m.countSd);
            var tempName = temp.GroupBy(s => s.branchCreatorName).Select(s => new
            {
                uUserName = s.Key
            });
            names.AddRange(tempName.Select(nn => nn.uUserName));
            //}
        
            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cS = new List<int>();
            List<int> cSb = new List<int>();
            List<int> cSd = new List<int>();
            List<string> titles = new List<string>()
            {
                "مبيعات","مرتجع","مسودة"
            };
            for (int i = 0; i < x.Count(); i++)
            {
                cS.Add(x.ToList().Skip(i).FirstOrDefault());
                cSb.Add(y.ToList().Skip(i).FirstOrDefault());
                cSd.Add(z.ToList().Skip(i).FirstOrDefault());
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            //3 فوق بعض
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cS.AsChartValues(),
                Title = titles[0],
                DataLabels = true,
            });
            columnChartData.Add(
           new StackedColumnSeries
           {
               Values = cSb.AsChartValues(),
               Title = titles[1],
               DataLabels = true,
           });
            columnChartData.Add(
           new StackedColumnSeries
           {
               Values = cSd.AsChartValues(),
               Title = titles[2],
               DataLabels = true,
           });

            DataContext = this;
            cartesianChart.Series = columnChartData;
        }

        private void fillRowChart()
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<decimal> pTemp = null;
            IEnumerable<decimal> pbTemp = null;
            IEnumerable<decimal> resultTemp = null;

            //if (selectedTab == 0)
            //{
            var temp = itemTrasferInvoicesQuery;
            var result = temp.GroupBy(s => s.branchCreatorId).Select(s => new
            {
                branchCreatorId = s.Key,
                totalS = s.Where(x => x.invType == "s").Sum(x => x.totalNet),
                totalSb = s.Where(x => x.invType == "sb").Sum(x => x.totalNet)
            }
            );
            var resultTotal = result.Select(x => new { x.branchCreatorId, total = x.totalS - x.totalSb }).ToList();
            pTemp = result.Select(x => (decimal)x.totalS);
            pbTemp = result.Select(x => (decimal)x.totalSb);
            resultTemp = result.Select(x => (decimal)x.totalS);
            var tempName = temp.GroupBy(s => s.branchCreatorName).Select(s => new
            {
                uUserName = s.Key
            });
            names.AddRange(tempName.Select(nn => nn.uUserName));
            //}
         
            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            List<string> titles = new List<string>()
            {
                         "اجمالي المبيعات","اجمالي المرتجع","صافي المبيعات"
            };
            for (int i = 0; i < pbTemp.Count(); i++)
            {
                purchase.Add(pTemp.ToList().Skip(i).FirstOrDefault());
                returns.Add(pbTemp.ToList().Skip(i).FirstOrDefault());
                sub.Add(resultTemp.ToList().Skip(i).FirstOrDefault());
                MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = purchase.AsChartValues(),
              Title = titles[0]
          }); ;
            rowChartData.Add(
         new LineSeries
         {
             Values = returns.AsChartValues(),
             Title = titles[1]
         });
            rowChartData.Add(
        new LineSeries
        {
            Values = sub.AsChartValues(),
            Title = titles[2]

        });
            DataContext = this;
            rowChart.Series = rowChartData;
        }

        private void chk_allBranches_Click(object sender, RoutedEventArgs e)
        {
           
        }
        int branchID = 0;
        private async void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await RefreshItemTransferInvoiceList();
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

        private void fillPos(int bID)
        {////////////////???????????????????????????????????
            cb_pos.SelectedValuePath = "posId";
            cb_pos.DisplayMemberPath = "posName";
            cb_pos.ItemsSource = itemTrasferInvoicesQuery.Where(t => t.branchCreatorId == bID)
                                                         .Select(i => i.posName).Distinct();
           
            //List<CashTransferSts> list;
            //list = await statisticsModel.GetPosTrans();
            //fromPos = statisticsModel.getFromPosCombo(list);
            //cb_pos.SelectedValuePath = "PosFromId";
            //cb_pos.DisplayMemberPath = "PosFromName";
            //cb_pos.ItemsSource = fromPos;
            //if (cb_branches.SelectedItem != null)
            //{
            //    var temp = cb_branches.SelectedItem as branchFromCombo;
            //    cb_formPos.ItemsSource = cb_pos.Where(x => x.BranchId == temp.BranchFromId);
            //}
        }

        private void BuildReport()
        {
            //List<ReportParameter> paramarr = new List<ReportParameter>();

            //string addpath = "";
            //bool isArabic = ReportCls.checkLang();
            //if (isArabic)
            //{
            //    addpath = @"\Reports\StatisticReport\Purchase\Ar\ArPurItemSts.rdlc";
            //}
            //else
            //{
            //    //english
            //    addpath = @"\Reports\StatisticReport\Purchase\En\EnPurItemSts.rdlc";
            //}

            //string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            //ReportCls.checkLang();
            ////  getpuritemcount
            //clsReports.PurOrderStsReport(itemTrasferInvoicesQuery, rep, reppath, paramarr);

            //clsReports.setReportLanguage(paramarr);
            //clsReports.Header(paramarr);

            //rep.SetParameters(paramarr);

            //rep.Refresh();
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

        private async void Chk_allBranches_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_branches.SelectedIndex = -1;
                cb_branches.IsEnabled = false;
                await RefreshItemTransferInvoiceList();
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
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_branches.IsEnabled = true;

                await RefreshItemTransferInvoiceList();
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

                await RefreshItemTransferInvoiceList();
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

                await RefreshItemTransferInvoiceList();
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

                await RefreshItemTransferInvoiceList();
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
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await RefreshItemTransferInvoiceList();
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
    }
}

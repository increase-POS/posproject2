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
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.IO;
using netoaster;
using System.Threading;
using POS.View.sales;
using POS.View.windows;
using System.Resources;
using System.Reflection;

namespace POS.View.sales
{
    public partial class uc_salesStatistic : UserControl
    {
        private int selectedTab = 0;

        private Statistics statisticModel = new Statistics();

        private List<ItemTransferInvoice> itemTransferInvoices = new List<ItemTransferInvoice>();
        IEnumerable<ItemTransferInvoice> itemTransferQuery;
        private static uc_salesStatistic _instance;

        public static uc_salesStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_salesStatistic();
                return _instance;
            }
        }
        // report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public uc_salesStatistic()
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

                itemTransferInvoices = await statisticModel.GetUserdailyinvoice((int)MainWindow.branchID, (int)MainWindow.userID);

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
                dp_orderDate.SelectedDate = DateTime.Now;
                dp_quotationDate.SelectedDate = DateTime.Now;

                chk_invoice.IsChecked = true;
                chk_orderInvoice.IsChecked = true;
                chk_quotationInvoice.IsChecked = true;
                itemTransferQuery= fillList();

                if (MainWindow.tax == 0)
                    col_tax.Visibility = Visibility.Hidden;

                dgInvoice.ItemsSource = itemTransferQuery;

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

        private void translate()
        {
            tt_invoice.Content = MainWindow.resourcemanager.GetString("trInvoices");
            tt_order.Content = MainWindow.resourcemanager.GetString("trOrders");
            tt_quotation.Content = MainWindow.resourcemanager.GetString("trQuotations");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_invoiceDate, MainWindow.resourcemanager.GetString("trDate"));

            chk_invoice.Content = MainWindow.resourcemanager.GetString("tr_Invoice");
            chk_return.Content = MainWindow.resourcemanager.GetString("trReturn");
            chk_drafs.Content = MainWindow.resourcemanager.GetString("trDraft");

            chk_orderInvoice.Content = MainWindow.resourcemanager.GetString("trOrder");
            chk_orderSaved.Content = MainWindow.resourcemanager.GetString("trSaved");
            chk_orderDraft.Content = MainWindow.resourcemanager.GetString("trDraft");

            chk_quotationInvoice.Content = MainWindow.resourcemanager.GetString("trQuotation");
            chk_quotationSaved.Content = MainWindow.resourcemanager.GetString("trSaved");
            chk_quotationDraft.Content = MainWindow.resourcemanager.GetString("trDraft");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");

            col_No.Header = MainWindow.resourcemanager.GetString("trNum");
            col_type.Header = MainWindow.resourcemanager.GetString("trType");
            col_branch.Header = MainWindow.resourcemanager.GetString("trBranch");
            col_pos.Header = MainWindow.resourcemanager.GetString("trPOS");
            col_discount.Header = MainWindow.resourcemanager.GetString("trDiscount");
            col_tax.Header = MainWindow.resourcemanager.GetString("trTax");
            col_totalNet.Header = MainWindow.resourcemanager.GetString("trTotal");

            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

        }

        private void fillEvents()
        {
            itemTransferQuery = fillList();
            if (MainWindow.tax == 0)
                col_tax.Visibility = Visibility.Hidden;
            dgInvoice.ItemsSource = itemTransferQuery;
            fillColumnChart();
            fillRowChart();
            fillPieChart();
        }
        //List<ItemTransferInvoice> tempLst;
        private List<ItemTransferInvoice> fillList()
        {
            var temp = itemTransferInvoices.Where(obj => obj.updateUserId == MainWindow.userID);
            if (selectedTab == 0)
            {
                temp = temp.Where(obj =>
                     ((chk_invoice.IsChecked == true ? obj.invType == "s" : false) || (chk_return.IsChecked == true ? obj.invType == "sb" : false) || (chk_drafs.IsChecked == true ? obj.invType == "spd" || obj.invType == "sd" : false))
                  && (dp_invoiceDate.SelectedDate != null ? obj.updateDate.Value.Date.ToShortDateString() == dp_invoiceDate.SelectedDate.Value.Date.ToShortDateString() : true)
                );
            }
            if (selectedTab == 1)
            {
                temp = temp.Where(obj => 
                            ((chk_orderInvoice.IsChecked == true ? obj.invType == "or" : false) || (chk_orderSaved.IsChecked == true ? obj.invType == "ors" : false) || (chk_orderDraft.IsChecked == true ? obj.invType == "ord" : false))
                         && (dp_orderDate.SelectedDate != null ? obj.updateDate.Value.Date.ToShortDateString() == dp_orderDate.SelectedDate.Value.Date.ToShortDateString() : true)
                         );
            }
            else if (selectedTab == 2)
            {
                temp = temp.Where(obj =>
                          ((chk_quotationInvoice.IsChecked == true ? obj.invType == "q" : false) || (chk_quotationSaved.IsChecked == true ? obj.invType == "qs" : false) || (chk_quotationDraft.IsChecked == true ? obj.invType == "qd" : false))
                       && (dp_orderDate.SelectedDate != null ? obj.updateDate.Value.Date.ToShortDateString() == dp_orderDate.SelectedDate.Value.Date.ToShortDateString() : true)
                       );
            }
            itemTransferQuery = temp.ToList();
            return temp.ToList();
        }

        private void Btn_Invoice_Click(object sender, RoutedEventArgs e)
        {//invoice
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                selectedTab = 0;
                txt_search.Text = "";

                path_order.Fill = Brushes.White;
                path_quotation.Fill = Brushes.White;
                bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_invoice);
                path_invoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                ReportsHelp.showTabControlGrid(grid_father, grid_invoice);
                ReportsHelp.isEnabledButtons(grid_tabControl, btn_invoice);

                fillEvents();
                rowToHide.Height = rowToShow.Height;

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

        private void Btn_order_Click(object sender, RoutedEventArgs e)
        {//order
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                selectedTab = 1;
                txt_search.Text = "";

                path_invoice.Fill = Brushes.White;
                path_quotation.Fill = Brushes.White;
                bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_order);
                path_order.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                ReportsHelp.showTabControlGrid(grid_father, grid_order);
                ReportsHelp.isEnabledButtons(grid_tabControl, btn_order);

                fillEvents();
                rowToHide.Height = new GridLength(0);

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

        private void Btn_quotation_Click(object sender, RoutedEventArgs e)
        {//quotation
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                selectedTab = 2;
                txt_search.Text = "";

                path_invoice.Fill = Brushes.White;
                path_order.Fill = Brushes.White;
                bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_quotation);
                path_quotation.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                ReportsHelp.showTabControlGrid(grid_father, grid_quotation);
                ReportsHelp.isEnabledButtons(grid_tabControl, btn_quotation);

                fillEvents();
                rowToHide.Height = new GridLength(0);

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

        private void fillEventsCall(object sender)
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
        private void chk_Checked(object sender, RoutedEventArgs e)
        {
            fillEventsCall(sender);
        }

        private void Dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEventsCall(sender);
        }

        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            IEnumerable<int> x = null;

            var temp = itemTransferQuery;

            var titleTemp = temp.GroupBy(m => m.cUserAccName);
    
            var result = temp.GroupBy(s =>new { s.updateUserId ,s.cUserAccName}).Select(s => new
            {
                updateUserId = s.FirstOrDefault().updateUserId,
                cUserAccName = s.FirstOrDefault().cUserAccName,
                count = s.Count()
            });
            x = result.Select(m => m.count);
          
            SeriesCollection piechartData = new SeriesCollection();

            int xCount = 0;
            if (x.Count() <= 6) xCount = x.Count();
            else xCount = 6;
            for (int i = 0; i < xCount; i++)
            {
                List<int> final = new List<int>();
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
            if (x.Count() > 6)
            {
                for (int i = 6; i < x.Count(); i++)
                {
                    List<int> final = new List<int>();
                    List<string> lable = new List<string>();

                    final.Add(x.ToList().Skip(i).FirstOrDefault());
                    if (final.Count > 0)
                        piechartData.Add(
                          new PieSeries
                          {
                              Values = final.AsChartValues(),
                              Title = MainWindow.resourcemanager.GetString("trOthers"),
                              DataLabels = true,
                          }
                  );
                }
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

            string trChk1 = "", trChk2 = "", condition1 = "", condition2 = "", condition3 = "" , condition4 = "";

            if (selectedTab == 0)
            { trChk1 = "tr_Sales"; trChk2 = "trReturned"; condition1 = "s";  condition2 = "sb";  condition3 = "sd"; condition4 = "sbd"; }
            else if (selectedTab == 1)
            { trChk1 = "trOrder"; trChk2 = "trSaved";     condition1 = "or"; condition2 = "ors"; condition3 = "ord"; condition4 = "ord"; }
            else if (selectedTab == 2)
            { trChk1 = "trQuotation"; trChk2 = "trSaved"; condition1 = "q";  condition2 = "qs";  condition3 = "qd"; condition4 = "qd"; }


            var temp = itemTransferQuery;
            var result = temp.GroupBy(s => s.updateUserId).Select(s => new
            {
                updateUserId = s.Key,
                countP  = s.Where(m => m.invType == condition1).Count(),
                countPb = s.Where(m => m.invType == condition2).Count(),
                countD  = s.Where(m => m.invType == condition3 || m.invType == condition4).Count()

            });
          
            x = result.Select(m => m.countP);
            y = result.Select(m => m.countPb);
            z = result.Select(m => m.countD);
            var tempName = temp.GroupBy(s => s.uUserAccName).Select(s => new
            {
                uUserName = s.Key
            });
            names.AddRange(tempName.Select(nn => nn.uUserName));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();
            List<int> cD = new List<int>();
            List<string> titles = new List<string>()
            {
                MainWindow.resourcemanager.GetString(trChk1),
                MainWindow.resourcemanager.GetString(trChk2),
                MainWindow.resourcemanager.GetString("trDraft")
            };
            int xCount = 0;
            if (x.Count() <= 6) xCount = x.Count();
            else xCount = 6;
            for (int i = 0; i < xCount; i++)
            {
                cP.Add(x.ToList().Skip(i).FirstOrDefault());
                cPb.Add(y.ToList().Skip(i).FirstOrDefault());
                cD.Add(z.ToList().Skip(i).FirstOrDefault());
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            if(x.Count() > 6)
            {
                int cPSum = 0, cPbSum = 0, cDSum = 0;
                for (int i = 6; i < x.Count() ; i++)
                {
                    cPSum = cPSum +x.ToList().Skip(i).FirstOrDefault();
                    cPbSum = cPbSum + y.ToList().Skip(i).FirstOrDefault();
                    cDSum = cDSum + z.ToList().Skip(i).FirstOrDefault();
                }
                if(!((cPSum == 0)&&(cPbSum == 0)&&(cDSum == 0)))
                {
                    cP.Add(cPSum);
                    cPb.Add(cPbSum);
                    cD.Add(cDSum);
                    axcolumn.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
                }
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

            var temp = itemTransferQuery;
            var result = temp.GroupBy(s => s.updateUserId).Select(s => new
            {
                updateUserId = s.Key,
                totalP = s.Where(x => x.invType == "s").Sum(x => x.totalNet),
                totalPb = s.Where(x => x.invType == "sb").Sum(x => x.totalNet)
            }
         );
           
            var resultTotal = result.Select(x => new { x.updateUserId, total = x.totalP - x.totalPb }).ToList();
            pTemp = result.Select(x => (decimal)x.totalP);
            pbTemp = result.Select(x => (decimal)x.totalPb);
            resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
            var tempName = temp.GroupBy(s => s.uUserAccName).Select(s => new
            {
                uUserName = s.Key
            });
            names.AddRange(tempName.Select(nn => nn.uUserName));

            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            List<string> titles = new List<string>()
            {
                MainWindow.resourcemanager.GetString("trNetSales"),
                MainWindow.resourcemanager.GetString("trTotalReturn"),
                MainWindow.resourcemanager.GetString("trTotalSales")
            };
            for (int i = 0; i < pTemp.Count(); i++)
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
          });
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
        public void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Sale\Ar\dailySale.rdlc";
            }
            else
                addpath = @"\Reports\Sale\En\dailySale.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.SaledailyReport(itemTransferQuery, rep, reppath, paramarr);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();
        }
        public void pdfdaily()
        {

            BuildReport();

            this.Dispatcher.Invoke(() =>
            {
                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
                }
            });
        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                //{
                    /////////////////////////////////////
                    Thread t1 = new Thread(() =>
                    {
                        pdfdaily();
                    });
                    t1.Start();
                    //////////////////////////////////////
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
        public void printDaily()
        {
            BuildReport();

            this.Dispatcher.Invoke(() =>
            {
                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
            });
        }
        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                //{
                    /////////////////////////////////////
                    Thread t1 = new Thread(() =>
                    {
                        printDaily();
                    });
                    t1.Start();
                    //////////////////////////////////////

                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

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

        public void ExcelDaily()
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
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                //{
                    Thread t1 = new Thread(() =>
                    {
                        ExcelDaily();

                    });
                    t1.Start();
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                //{
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    /////////////////////
                    string pdfpath = "";
                    pdfpath = @"\Thumb\report\temp.pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                    BuildReport();
                    LocalReportExtensions.ExportToPDF(rep, pdfpath);
                    ///////////////////
                    wd_previewPdf w = new wd_previewPdf();
                    w.pdfPath = pdfpath;
                    if (!string.IsNullOrEmpty(w.pdfPath))
                    {
                        w.ShowDialog();
                        w.wb_pdfWebViewer.Dispose();
                    }
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
        Invoice invoice;
        private async void DgInvoice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main); //invoiceId
                invoice = new Invoice();
                if (dgInvoice.SelectedIndex != -1)
                {
                    ItemTransferInvoice item = dgInvoice.SelectedItem as ItemTransferInvoice;
                    if (item.invoiceId > 0)
                    {
                        invoice = await invoice.GetByInvoiceId(item.invoiceId);
                        MainWindow.mainWindow.BTN_sales_Click(MainWindow.mainWindow.btn_sales, null);
                        uc_sales.Instance.Btn_receiptInvoice_Click(uc_sales.Instance.btn_reciptInvoice, null);
                        uc_receiptInvoice.Instance.UserControl_Loaded(null, null);
                        uc_receiptInvoice._InvoiceType = invoice.invType;
                        uc_receiptInvoice.Instance.invoice = invoice;
                        await uc_receiptInvoice.Instance.fillInvoiceInputs(invoice);
                    }
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

       
    }
}

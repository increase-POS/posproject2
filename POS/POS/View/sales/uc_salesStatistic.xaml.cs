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
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.IO;
using netoaster;
using System.Threading;
using POS.View.sales;
using POS.View.windows;

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
        {
            //load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                itemTransferInvoices = await statisticModel.GetUserdailyinvoice((int)MainWindow.branchID, (int)MainWindow.userID);

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

        private void fillInvoiceEvents()
        {
            itemTransferQuery = fillList();
            if (MainWindow.tax == 0)
                col_tax.Visibility = Visibility.Hidden;
            dgInvoice.ItemsSource = itemTransferQuery;
            fillColumnChart();
            fillRowChart();
            fillPieChart();
        }

        private void fillOrderEvents()
        {
            itemTransferQuery = fillList();
            if (MainWindow.tax == 0)
                col_tax.Visibility = Visibility.Hidden;
            dgInvoice.ItemsSource = itemTransferQuery;
            fillColumnChart();
            fillRowChart();
            fillPieChart();
        }

        private void fillQuotationEvents()
        {
            itemTransferQuery = fillList();
            if (MainWindow.tax == 0)
                col_tax.Visibility = Visibility.Hidden;
            dgInvoice.ItemsSource = itemTransferQuery;
            fillColumnChart();
            fillRowChart();
            fillPieChart();
        }

        private List<ItemTransferInvoice> fillList()
        {
            var temp = itemTransferInvoices.Where(obj => (
            obj.updateUserId == MainWindow.userID
              && ((chk_invoice.IsChecked == true ? obj.invType == "s" : false) || (chk_return.IsChecked == true ? obj.invType == "sb" : false) || (chk_invoice.IsChecked == true ? obj.invType == "spd" || obj.invType == "sd" : false))
                   && (dp_invoiceDate.SelectedDate != null ? obj.updateDate.Value.Date.ToShortDateString() == dp_invoiceDate.SelectedDate.Value.Date.ToShortDateString() : true)
                )
                );
            if (selectedTab == 1)
            {
                temp = itemTransferInvoices.Where(obj => (obj.updateUserId == MainWindow.userID
                         && ((chk_orderInvoice.IsChecked == true ? obj.invType == "or" : false) || (chk_orderDraft.IsChecked == true ? obj.invType == "ord" : false))
                                   && (dp_orderDate.SelectedDate != null ? obj.updateDate.Value.Date.ToShortDateString() == dp_orderDate.SelectedDate.Value.Date.ToShortDateString() : true)
                                )
                                );
            }
            else if (selectedTab == 2)
            {
                temp = itemTransferInvoices.Where(obj => (obj.updateUserId == MainWindow.userID
                                                    && ((chk_orderInvoice.IsChecked == true ? obj.invType == "q" : false) || (chk_orderDraft.IsChecked == true ? obj.invType == "qd" : false))
                                   && (dp_orderDate.SelectedDate != null ? obj.updateDate.Value.Date.ToShortDateString() == dp_orderDate.SelectedDate.Value.Date.ToShortDateString() : true))
                                           );
            }
            return temp.ToList();
        }

        private void Btn_Invoice_Click(object sender, RoutedEventArgs e)
        {
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
                fillInvoiceEvents();

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
        {
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
                fillOrderEvents();

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
        {
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
                fillQuotationEvents();

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

        private void Chk_orderInvoice_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillOrderEvents();

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

        private void Chk_orderInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillOrderEvents();

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

        private void Chk_orderReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillOrderEvents();
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

        private void Chk_orderReturn_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillOrderEvents();
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

        private void Chk_orderDraft_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillOrderEvents();
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

        private void Chk_orderDraft_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillOrderEvents();

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

        private void Dp_orderDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillOrderEvents();

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

        private void Dp_quotationDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillQuotationEvents();

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

        private void Chk_quotationInvoice_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillQuotationEvents();

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

        private void Chk_quotationInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillQuotationEvents();

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

        private void Chk_quotationReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillQuotationEvents();

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

        private void Chk_quotationReturn_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillQuotationEvents();

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

        private void Chk_quotationDraft_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillQuotationEvents();

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

        private void Chk_quotationDraft_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillQuotationEvents();

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

        private void chk_invoice_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillInvoiceEvents();

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

        private void chk_invoice_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillInvoiceEvents();

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

        private void chk_return_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillInvoiceEvents();

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

        private void chk_return_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillInvoiceEvents();

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

        private void chk_drafs_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillInvoiceEvents();

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

        private void chk_drafs_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillInvoiceEvents();

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

        private void Dp_invoiceDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillInvoiceEvents();

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
      
            var temp =  itemTransferInvoices.Where(obj => (
         
               ((chk_invoice.IsChecked == true ? obj.invType == "s" : false) || (chk_return.IsChecked == true ? obj.invType == "sb" : false) || (chk_invoice.IsChecked == true ? obj.invType == "spd" || obj.invType == "sd" : false))
                   && (dp_invoiceDate.SelectedDate != null ? obj.updateDate.Value.Date.ToShortDateString() == dp_invoiceDate.SelectedDate.Value.Date.ToShortDateString() : true)
                )
                );
            if (selectedTab == 1)
            {
                temp = itemTransferInvoices.Where(obj => (
                          ((chk_orderInvoice.IsChecked == true ? obj.invType == "or" : false) || (chk_orderDraft.IsChecked == true ? obj.invType == "ord" : false))
                                   && (dp_orderDate.SelectedDate != null ? obj.updateDate.Value.Date.ToShortDateString() == dp_orderDate.SelectedDate.Value.Date.ToShortDateString() : true)
                                )
                                );
            }
            else if (selectedTab == 2)
            {
                temp = itemTransferInvoices.Where(obj => (
                                                     ((chk_orderInvoice.IsChecked == true ? obj.invType == "q" : false) || (chk_orderDraft.IsChecked == true ? obj.invType == "qd" : false))
                                   && (dp_orderDate.SelectedDate != null ? obj.updateDate.Value.Date.ToShortDateString() == dp_orderDate.SelectedDate.Value.Date.ToShortDateString() : true))
                                           );
            };
            var titleTemp = temp.GroupBy(m => m.cUserAccName);
    
            var result = temp.GroupBy(s =>new { s.updateUserId ,s.cUserAccName}).Select(s => new
            {
                updateUserId = s.FirstOrDefault().updateUserId,
                cUserAccName = s.FirstOrDefault().cUserAccName,
                count = s.Count()
            });
            x = result.Select(m => m.count);
            int final1 = 0;
            int final = 0;


            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < x.Count(); i++)
            {

                List<string> lable = new List<string>();
                if (result.Select(obj => obj.updateUserId).Skip(i).FirstOrDefault() == MainWindow.userID)
                {
                    final = x.ToList().Skip(i).FirstOrDefault();
                    titles.Add(result.Select(jj => jj.cUserAccName).Skip(i).FirstOrDefault());
                }
                else
                {
                    final1 += x.ToList().Skip(i).FirstOrDefault();
                    titles.Add("Others");
                }
            }
          
            List<int> final2 = new List<int>();
            final2.Add(final);
            final2.Add(final1);
            for (int i = 0; i < 2; i++)
            {
                List<int> final3 = new List<int>();
                final3.Add(final2.Skip(i).FirstOrDefault());
                piechartData.Add(
                  new PieSeries
                  {
                      Values = final3.AsChartValues(),
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

            var temp = fillList();
            var result = temp.GroupBy(s => s.updateUserId).Select(s => new
            {
                updateUserId = s.Key,
                countP = s.Where(m => m.invType == "s").Count(),
                countPb = s.Where(m => m.invType == "sb").Count(),
                countD = s.Where(m => m.invType == "sd" || m.invType == "sbd").Count()

            });
            if (selectedTab == 1)
            {
                result = temp.GroupBy(s => s.updateUserId).Select(s => new
                {
                    updateUserId = s.Key,
                    countP = s.Where(m => m.invType == "or").Count(),
                    countPb = 0,
                    countD = s.Where(m => m.invType == "ord").Count()

                });
            }
            else if (selectedTab == 2)
            {
                result = temp.GroupBy(s => s.updateUserId).Select(s => new
                {
                    updateUserId = s.Key,
                    countP = s.Where(m => m.invType == "q").Count(),
                    countPb = 0,
                    countD = s.Where(m => m.invType == "qd").Count()

                });
            }

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
                "مبيعات","مرتجع","مسودة"
            };
            for (int i = 0; i < x.Count(); i++)
            {
                cP.Add(x.ToList().Skip(i).FirstOrDefault());
                cPb.Add(y.ToList().Skip(i).FirstOrDefault());
                cD.Add(z.ToList().Skip(i).FirstOrDefault());
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
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
            var temp = fillList();
            var result = temp.GroupBy(s => s.updateUserId).Select(s => new
            {
                updateUserId = s.Key,
                totalP = s.Where(x => x.invType == "s").Sum(x => x.totalNet),
                totalPb = s.Where(x => x.invType == "sb").Sum(x => x.totalNet)
            }
         );
            if (selectedTab == 1)
            {
                result = temp.GroupBy(s => s.updateUserId).Select(s => new
                {
                    updateUserId = s.Key,
                    totalP = s.Where(x => x.invType == "or").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "ord").Sum(x => x.totalNet)
                });
            }
            else if (selectedTab == 2)
            {
                result = temp.GroupBy(s => s.updateUserId).Select(s => new
                {
                    updateUserId = s.Key,
                    totalP = s.Where(x => x.invType == "q").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "qd").Sum(x => x.totalNet)
                });
            }
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
                "اجمالي المبيعات","اجمالي المرتجع","صافي المبيعات"
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

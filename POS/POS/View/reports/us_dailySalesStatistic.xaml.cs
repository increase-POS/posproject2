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

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for us_dailySalesStatistic.xaml
    /// </summary>
    public partial class us_dailySalesStatistic : UserControl
    {
         

        private int selectedTab = 0;

        private Statistics statisticModel = new Statistics();

        private List<ItemTransferInvoice> itemTransferInvoices = new List<ItemTransferInvoice>();

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
        {
            itemTransferInvoices = await statisticModel.GetUserdailyinvoice();

            dp_invoiceDate.SelectedDate = DateTime.Now;
            dp_orderDate.SelectedDate = DateTime.Now;
            dp_quotationDate.SelectedDate = DateTime.Now;

            chk_invoice.IsChecked = true;
            chk_orderInvoice.IsChecked = true;
            chk_quotationInvoice.IsChecked = true;

            dgInvoice.ItemsSource = fillList();
        }

        private void FillEvents()
        {
            dgInvoice.ItemsSource = fillList();
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
            selectedTab = 0;
            txt_search.Text = "";
            path_order.Fill = Brushes.White;
            path_quotation.Fill = Brushes.White;
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
            ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_invoice);
            path_invoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            ReportsHelp.showTabControlGrid(grid_father, grid_invoice);
            ReportsHelp.isEnabledButtons(grid_tabControl, btn_invoice);
            FillEvents();
        }
        private void Btn_order_Click(object sender, RoutedEventArgs e)
        {
            selectedTab = 1;
            txt_search.Text = "";
            path_invoice.Fill = Brushes.White;
            path_quotation.Fill = Brushes.White;
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
            ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_order);
            path_order.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            ReportsHelp.showTabControlGrid(grid_father, grid_order);
            ReportsHelp.isEnabledButtons(grid_tabControl, btn_order);
            FillEvents();
        }
        private void Btn_quotation_Click(object sender, RoutedEventArgs e)
        {
            selectedTab = 2;
            txt_search.Text = "";
            path_invoice.Fill = Brushes.White;
            path_order.Fill = Brushes.White;
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
            ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_quotation);
            path_quotation.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            ReportsHelp.showTabControlGrid(grid_father, grid_quotation);
            ReportsHelp.isEnabledButtons(grid_tabControl, btn_quotation);
            FillEvents();
        }
        private void RefreshView_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FillEvents();
        }
        private void RefreshViewCheckbox(object sender, RoutedEventArgs e)
        {
            FillEvents();
        }
        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            IEnumerable<int> x = null;

            var temp = itemTransferInvoices.Where(obj => (

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

            var result = temp.GroupBy(s => new { s.updateUserId, s.cUserAccName }).Select(s => new
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

        private void chk_allBranches_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (sender != null)
            //        SectionData.StartAwait(grid_main); if (cb_branches.IsEnabled == true)
            //    {
            //        cb_branches.SelectedItem = null;
            //        cb_branches.IsEnabled = false;
            //        for (int i = 0; i < comboBrachTemp.Count; i++)
            //        {
            //            dynamicComboBranches.Add(comboBrachTemp.Skip(i).FirstOrDefault());
            //        }
            //        comboBrachTemp.Clear();
            //        stk_tagsBranches.Children.Clear();
            //        selectedBranchId.Clear();

            //    }
            //    else
            //    {
            //        cb_branches.IsEnabled = true;
            //    }
            //    fillBranchEvent();
            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this, sender);
            //}
        }
        public void fillBranchEvent()
        {
            //itemTransfers = fillList(Invoices, chk_invoice, chk_return, chk_drafs, dp_startDate, dp_endDate, dt_startTime, dt_endTime).Where(j => (selectedBranchId.Count != 0 ? selectedBranchId.Contains((int)j.branchCreatorId) : true));
            //dgInvoice.ItemsSource = itemTransfers;
            //fillPieChart(cb_branches, selectedBranchId);
            //fillColumnChart(cb_branches, selectedBranchId);
            //fillRowChart(cb_branches, selectedBranchId);
        }

        private void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    if (sender != null)
            //        SectionData.StartAwait(grid_main); if (cb_branches.SelectedItem != null)
            //    {
            //        if (stk_tagsBranches.Children.Count < 5)
            //        {
            //            selectedBranch = cb_branches.SelectedItem as Branch;
            //            var b = new MaterialDesignThemes.Wpf.Chip()
            //            {
            //                Content = selectedBranch.name,
            //                Name = "btn" + selectedBranch.branchId.ToString(),
            //                IsDeletable = true,
            //                Margin = new Thickness(5, 0, 5, 0)
            //            };
            //            b.DeleteClick += Chip_OnDeleteClick;
            //            stk_tagsBranches.Children.Add(b);
            //            comboBrachTemp.Add(selectedBranch);
            //            selectedBranchId.Add(selectedBranch.branchId);
            //            dynamicComboBranches.Remove(selectedBranch);
            //            fillBranchEvent();
            //        }
            //    }
            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this, sender);
            //}
        }

    }
}

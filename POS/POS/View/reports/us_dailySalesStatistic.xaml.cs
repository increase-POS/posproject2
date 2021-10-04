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
            //itemTrasferInvoicesQuery = itemTrasferInvoices;
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
                &&
                (chk_invoice.IsChecked == true ? s.invType == "s" : false)
                ||
                (chk_return.IsChecked == true ? s.invType == "sb" : false)
                ||
                (chk_drafs.IsChecked == true ? s.invType == "sd" : false)
                )
                ||
                (
                selectedTab == 1 //order
                &&
                (chk_invoice.IsChecked == true ? s.invType == "or" : false)
                ||
                (chk_return.IsChecked == true ? s.invType == "sbd" : false)/////????
                ||
                (chk_drafs.IsChecked == true ? s.invType == "ord" : false)
                )
                ||
                (
                selectedTab == 1 //quotation
                &&
                (chk_invoice.IsChecked == true ? s.invType == "or" : false)
                ||
                (chk_return.IsChecked == true ? s.invType == "sbd" : false)/////????
                ||
                (chk_drafs.IsChecked == true ? s.invType == "ord" : false)
                )
            )
            &&
            //branchID
            (cb_branches.SelectedIndex != -1 ? s.branchCreatorId == Convert.ToInt32(cb_branches.SelectedValue) : true)
            //&&
            //posID
            //(cb_branches.SelectedIndex != -1 ? s.branchCreatorId == Convert.ToInt32(cb_branches.SelectedValue) : true)
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
                chk_return.IsEnabled = true;
                //path_order.Fill = Brushes.White;
                //path_quotation.Fill = Brushes.White;
                //bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
                //ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_invoice);
                //path_invoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
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
                //path_invoice.Fill = Brushes.White;
                //path_quotation.Fill = Brushes.White;
                //bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
                //ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_order);
                //path_order.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
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
                //path_invoice.Fill = Brushes.White;
                //path_order.Fill = Brushes.White;
                //bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
                //ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_quotation);
                //path_quotation.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
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
        private void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             RefreshView_SelectedDateChanged(null, null);
            //fillPos(Convert.ToInt32(cb_branches.SelectedValue));
        }

        private void fillPos(int bID)
        {
            cb_branches.SelectedValuePath = "posId";
            cb_branches.DisplayMemberPath = "posName";
            cb_branches.ItemsSource = itemTrasferInvoices.Where(t => t.branchCreatorId == bID)
                                                         .Select(i => i.posName).Distinct();
        }

        private void BuildReport()
        {
           
        }
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Chk_allBranches_Checked(object sender, RoutedEventArgs e)
        {
            cb_branches.SelectedIndex = -1;
            cb_branches.IsEnabled = false;
        }

        private void Chk_allBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_branches.IsEnabled = true;
        }

        private void Chk_allPos_Checked(object sender, RoutedEventArgs e)
        {
            cb_pos.SelectedIndex = -1;
            cb_pos.IsEnabled = false;
        }

        private void Chk_allPos_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_pos.IsEnabled = true;
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
    }
}

using LiveCharts;
using LiveCharts.Wpf;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using LiveCharts.Helpers;
using POS.View.windows;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using static POS.Classes.Statistics;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.IO;
using System.Threading;

namespace POS.View.reports
{

    public partial class uc_destroied : UserControl
    {
        List<ItemTransferInvoice> Destroied;

        Statistics statisticModel = new Statistics();

        List<Branch> comboBranches;

        Branch branchModel = new Branch();

        List<DestroiedCombo> comboDestroiedItemmsUnits;

        IEnumerable<ItemTransferInvoice> temp = null;

        private static uc_storageReports _instance;
        public static uc_storageReports Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_storageReports();
                return _instance;
            }
        }

        public uc_destroied()
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

                Destroied = await statisticModel.GetDesItems((int)MainWindow.branchID, (int)MainWindow.userID);

                comboBranches = await branchModel.GetAllWithoutMain("all");

                fillComboBranches(cb_destroiedBranch);

                Btn_destroied_Click(btn_destroied , null);

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

        public void paint()
        {
            grid_detroied.Visibility = Visibility.Visible;

            bdr_destroied.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_destroied.Fill = Brushes.White;
        }

       
        private void fillComboBranches(ComboBox cb)
        {
            cb.SelectedValuePath = "branchId";
            cb.DisplayMemberPath = "name";
            cb.ItemsSource = comboBranches;
        }

        private void hideAllColumn()
        {
            col_branch.Visibility = Visibility.Hidden;
            col_item.Visibility = Visibility.Hidden;
            col_unit.Visibility = Visibility.Hidden;
            col_locationSection.Visibility = Visibility.Hidden;
            col_quantity.Visibility = Visibility.Hidden;
            col_startDate.Visibility = Visibility.Hidden;
            col_endDate.Visibility = Visibility.Hidden;
            col_Min.Visibility = Visibility.Hidden;
            col_Max.Visibility = Visibility.Hidden;
            col_stockCost.Visibility = Visibility.Hidden;

            col_location.Visibility = Visibility.Hidden;
            col_section.Visibility = Visibility.Hidden;
            col_itemUnits.Visibility = Visibility.Hidden;

            col_invNumber.Visibility = Visibility.Hidden;
            col_invType.Visibility = Visibility.Hidden;
            col_invTypeNumber.Visibility = Visibility.Hidden;
            col_agentType.Visibility = Visibility.Hidden;
            col_agent.Visibility = Visibility.Hidden;
            col_agentTypeAgent.Visibility = Visibility.Hidden;
            col_MaxCollect.Visibility = Visibility.Hidden;
            col_MinCollect.Visibility = Visibility.Hidden;
            col_branchFrom.Visibility = Visibility.Hidden;
            col_branchTo.Visibility = Visibility.Hidden;

            col_stockTakeNum.Visibility = Visibility.Hidden;
            col_stockTakingCoastType.Visibility = Visibility.Hidden;
            col_stockTakingDate.Visibility = Visibility.Hidden;
            col_diffPercentage.Visibility = Visibility.Hidden;
            col_itemCountAr.Visibility = Visibility.Hidden;
            col_DestroyedCount.Visibility = Visibility.Hidden;

            col_destroiedNumber.Visibility = Visibility.Hidden;
            col_destroiedDate.Visibility = Visibility.Hidden;
            col_destroiedItemsUnits.Visibility = Visibility.Hidden;
            col_destroiedReason.Visibility = Visibility.Hidden;
            col_destroiedAmount.Visibility = Visibility.Hidden;
        }

        private void fillDestroidEvents()
        {
            temp = fillListDestroied(cb_destroiedBranch, cb_destroiedItemsUnits, dp_destroiedStartDate, dp_destroiedEndDate);
            dgStock.ItemsSource = temp;
            txt_count.Text = temp.Count().ToString();
            fillDestroyColumnChart();
            fillDestroyRowChart();
            fillDestroyPieChart();
        }

        private void fillComboItemsUnits()
        {
            var temp = cb_destroiedBranch.SelectedItem as Branch;
            cb_destroiedItemsUnits.SelectedValuePath = "ItemsUnitsId";
            cb_destroiedItemsUnits.DisplayMemberPath = "ItemsUnits";
            if (temp == null)
            {
                cb_destroiedItemsUnits.ItemsSource = comboDestroiedItemmsUnits
                    .GroupBy(x => x.ItemsUnitsId)
                    .Select(g => new DestroiedCombo
                    {
                        ItemsUnits = g.FirstOrDefault().ItemsUnits,
                        BranchId = g.FirstOrDefault().BranchId,
                        ItemsUnitsId = g.FirstOrDefault().ItemsUnitsId
                    }).ToList();
            }
            else
            {
                cb_destroiedItemsUnits.ItemsSource = comboDestroiedItemmsUnits
                   .Where(x => x.BranchId == temp.branchId)
                    .GroupBy(x => x.ItemsUnitsId)
                    .Select(g => new DestroiedCombo
                    {
                        ItemsUnits = g.FirstOrDefault().ItemsUnits,
                        BranchId = g.FirstOrDefault().BranchId,
                        ItemsUnitsId = g.FirstOrDefault().ItemsUnitsId
                    }).ToList();
            }
        }

        private IEnumerable<ItemTransferInvoice> fillListDestroied(ComboBox branch, ComboBox cb, DatePicker startDate, DatePicker endDate)
        {
            var selectedBranch = branch.SelectedItem as Branch;
            var selectedType = cb.SelectedItem as DestroiedCombo;
            var result = Destroied.Where(x => (

                         (branch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                        && (cb.SelectedItem != null ? (x.itemUnitId == selectedType.ItemsUnitsId) : true)
                        && (startDate.SelectedDate != null ? (x.IupdateDate >= startDate.SelectedDate) : true)
                        && (endDate.SelectedDate != null ? (x.IupdateDate <= endDate.SelectedDate) : true)
          ));
            return result;
        }

        private void Cb_destroiedBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillComboItemsUnits();
                fillDestroidEvents();

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

        private void Chk_destroiedAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_destroiedBranch.IsEnabled = true;

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

        private void Chk_destroiedAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_destroiedBranch.SelectedItem = null;
                cb_destroiedBranch.IsEnabled = false;

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

                fillDestroidEvents();

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
        private void Chk_destroiedAllItemsUnits_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_destroiedItemsUnits.SelectedItem = null;
                cb_destroiedItemsUnits.IsEnabled = false;

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

        private void Chk_destroiedAllItemsUnits_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_destroiedItemsUnits.IsEnabled = true;

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

        private void fillDestroyRowChart()
        {
            List<long> cP = new List<long>();

            MyAxis.Labels = new List<string>();

            List<string> names = new List<string>();

            var temp = fillListDestroied(cb_destroiedBranch, cb_destroiedItemsUnits, dp_destroiedStartDate, dp_destroiedEndDate);

            var result = temp.GroupBy(s => new { s.itemUnitId }).Select(s => new ItemTransferInvoice
            {
                branchId = s.FirstOrDefault().branchId,
                branchName = s.FirstOrDefault().branchName,
                quantity = s.Sum(x => x.quantity),
                ItemUnits = s.FirstOrDefault().ItemUnits,
                itemUnitId = s.FirstOrDefault().itemUnitId,
                itemName = s.FirstOrDefault().itemName,
                unitName = s.FirstOrDefault().unitName
            });
            var tempName = result.GroupBy(s => new { s.itemUnitId }).Select(s => new
            {
                itemName = s.FirstOrDefault().itemName + s.FirstOrDefault().unitName,
            });
            names.AddRange(tempName.Select(nn => nn.itemName));
            for (int i = 0; i < result.Count(); i++)
            {
                cP.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().quantity.ToString()));
                MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            SeriesCollection rowChartData = new SeriesCollection();

            rowChartData.Add(
             new LineSeries
             {
                 Values = cP.AsChartValues(),

                 DataLabels = true,
             });
            DataContext = this;
            rowChart.Series = rowChartData;

        }

        private void fillDestroyColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();

            var temp = fillListDestroied(cb_destroiedBranch, cb_destroiedItemsUnits, dp_destroiedStartDate, dp_destroiedEndDate);

            var result = temp.GroupBy(s => new { s.branchId }).Select(s => new ItemTransferInvoice
            {
                branchId = s.FirstOrDefault().branchId,
                branchName = s.FirstOrDefault().branchName,
                quantity = s.Sum(x => x.quantity),
            });

            var tempName = result.GroupBy(s => new { s.branchId }).Select(s => new
            {
                itemName = s.FirstOrDefault().branchName,
            });
            names.AddRange(tempName.Select(nn => nn.itemName));

            SeriesCollection columnChartData = new SeriesCollection();
            List<long> cPa = new List<long>();

            int xCount = 6;
            if (result.Count() <= 6) xCount = result.Count();

            for (int i = 0; i < xCount; i++)
            {
                cPa.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().quantity.ToString()));
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            if(result.Count() > 6)
            {
                long c = 0;
                for(int i = 6; i < result.Count(); i++)
                {
                    c = c + long.Parse(result.ToList().Skip(i).FirstOrDefault().quantity.ToString());
                }
                if(c != 0)
                {
                    cPa.Add(c);
                    axcolumn.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
                }
            }
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPa.AsChartValues(),
                DataLabels = true,
                Title = MainWindow.resourcemanager.GetString("trAmount")
            }); 


            DataContext = this;
            cartesianChart.Series = columnChartData;
        }

        private void fillDestroyPieChart()
        {
            List<string> titles = new List<string>();
            List<long> cP = new List<long>();

            titles.Clear();
            var temp = fillListDestroied(cb_destroiedBranch, cb_destroiedItemsUnits, dp_destroiedStartDate, dp_destroiedEndDate);

            var result = temp.GroupBy(s => new { s.itemUnitId }).Select(s => new ItemTransferInvoice
            {
                branchId = s.FirstOrDefault().branchId,
                branchName = s.FirstOrDefault().branchName,
                quantity = s.Sum(x => x.quantity),
                ItemUnits = s.FirstOrDefault().ItemUnits,
                itemUnitId = s.FirstOrDefault().itemUnitId,
                itemName = s.FirstOrDefault().itemName,
                unitName = s.FirstOrDefault().unitName
            });
            var tempName = result.GroupBy(s => new { s.itemUnitId }).Select(s => new
            {
                itemName = s.FirstOrDefault().itemName + s.FirstOrDefault().unitName,
            });
            titles.AddRange(tempName.Select(nn => nn.itemName));
            cP = result.Select(m => (long)m.quantity).ToList();
            int count = cP.Count();
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < count; i++)
            {
                List<decimal> final = new List<decimal>();
                List<string> lable = new List<string>();
                if (i < 5)
                {
                    final.Add(cP.Max());
                    lable.Add(titles.Skip(i).FirstOrDefault());
                    piechartData.Add(
                      new PieSeries
                      {
                          Values = final.AsChartValues(),
                          Title = lable.FirstOrDefault(),
                          DataLabels = true,
                      }
                  );
                    cP.Remove(cP.Max());
                }
                else
                {
                    final.Add(cP.Sum());
                    piechartData.Add(
                      new PieSeries
                      {
                          Values = final.AsChartValues(),
                          Title = MainWindow.resourcemanager.GetString("trOthers"),
                          DataLabels = true,
                      }
                  );
                    break;
                }

            }
            chart1.Series = piechartData;
        }

        private void Btn_destroied_Click(object sender, RoutedEventArgs e)
        {//destroid

            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                comboDestroiedItemmsUnits = statisticModel.getDestroiedCombo(Destroied);
                txt_search.Text = "";

                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_destroied);
                path_destroied.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                hideAllColumn();
                //show columns
                col_branch.Visibility = Visibility.Visible;
                col_destroiedItemsUnits.Visibility = Visibility.Visible;
                col_destroiedNumber.Visibility = Visibility.Visible;
                col_destroiedDate.Visibility = Visibility.Visible;
                col_destroiedReason.Visibility = Visibility.Visible;
                col_destroiedAmount.Visibility = Visibility.Visible;

                chk_destroiedAllBranches.IsChecked = true;
                chk_destroiedAllItemsUnits.IsChecked = true;

                fillDestroidEvents();

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
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath = "";
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Destructive\Ar\ArDes.rdlc";
                }
                else
                {
                    addpath = @"\Reports\StatisticReport\Storage\Destructive\En\Des.rdlc";
                }
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();
               
                clsReports.itemTransferInvoiceDestroied(temp, rep, reppath, paramarr);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);

                rep.Refresh();

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
                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath = "";
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Destructive\Ar\ArDes.rdlc";
                }
                else
                {
                    addpath = @"\Reports\StatisticReport\Storage\Destructive\En\Des.rdlc";
                }
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.itemTransferInvoiceDestroied(temp, rep, reppath, paramarr);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();
                LocalReportExtensions.PrintToPrinter(rep);
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
                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath = "";
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                addpath = @"\Reports\StatisticReport\Storage\Destructive\Ar\ArDes.rdlc";
                }
                else
                {
                addpath = @"\Reports\StatisticReport\Storage\Destructive\En\Des.rdlc";
                }
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                    clsReports.itemTransferInvoiceDestroied(temp, rep, reppath, paramarr);
                    clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);

                rep.Refresh();
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

                List<ReportParameter> paramarr = new List<ReportParameter>();

                pdfpath = @"\Thumb\report\temp.pdf";
                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                string addpath;
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Destructive\Ar\ArDes.rdlc";
                }
                else
                {
                    addpath = @"\Reports\StatisticReport\Storage\Destructive\En\Des.rdlc";
                }
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.itemTransferInvoiceDestroied(temp, rep, reppath, paramarr);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);

                rep.Refresh();

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

        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEventsCall(sender);
        }

        private void Dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEventsCall(sender);
        }

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            //try
            //{
            //    if (sender != null)
            //        SectionData.StartAwait(grid_main);

            //    var temp = fillListDestroied(cb_destroiedBranch, cb_destroiedItemsUnits, dp_destroiedStartDate, dp_destroiedEndDate);
            //dgStock.ItemsSource = temp.Where(obj => (
            ////obj.importBranch.ToLower().Contains(txt_search.Text) 
            ////||
            //obj.invNumber.ToLower().Contains(txt_search.Text)
            //||
            //obj.userdestroy.ToLower().Contains(txt_search.Text)||
            //obj.ItemUnits.ToLower().Contains(txt_search.Text) ||
            //obj.causeDestroy.ToLower().Contains(txt_search.Text)||
            //obj.quantity.ToString().ToLower().Contains(txt_search.Text)
            //)) ;

            //    txt_count.Text = dgStock.Items.Count.ToString();

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

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                txt_search.Text = "";

                cb_destroiedBranch.SelectedItem = null;
                cb_destroiedItemsUnits.SelectedItem = null;

                chk_destroiedAllBranches.IsChecked = true;
                chk_destroiedAllItemsUnits.IsChecked = true;

                dp_destroiedStartDate.SelectedDate = null;
                dp_destroiedEndDate.SelectedDate = null;

                fillListDestroied(cb_destroiedBranch, cb_destroiedItemsUnits, dp_destroiedStartDate, dp_destroiedEndDate);

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

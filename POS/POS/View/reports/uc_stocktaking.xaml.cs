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
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.Threading;
using System.Resources;
using System.Reflection;

namespace POS.View.reports
{
    public partial class uc_stocktaking : UserControl
    {
        //charts
        IEnumerable<InventoryClass> archiveCount;

        List<InventoryClass> inventory;

        List<ItemTransferInvoice> falls;

        private int selectedStocktakingTab = 0;
        List<ShortFalls> comboShortFalls;

        Statistics statisticModel = new Statistics();

        List<Branch> comboBranches;

        // report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        IEnumerable<InventoryClass> RepInventory;
        IEnumerable<ItemTransferInvoice> RepItemtrans;

        private static uc_stocktaking _instance;
        public static uc_stocktaking Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_stocktaking();
                return _instance;
            }
        }

        public uc_stocktaking()
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

                inventory = await statisticModel.GetInventory((int)MainWindow.branchID, (int)MainWindow.userID);

                falls = await statisticModel.GetFallsItems((int)MainWindow.branchID, (int)MainWindow.userID);

                fillComboArchivedTypeType();

                comboShortFalls = statisticModel.getshortFalls(falls);

                Btn_archives_Click(btn_archives, null);

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
            tt_archives.Content = MainWindow.resourcemanager.GetString("trArchives");
            tt_shortfalls.Content = MainWindow.resourcemanager.GetString("trShortages");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_stocktakingArchivedBranch, MainWindow.resourcemanager.GetString("trBranch/StoreHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_stocktakingArchivedType, MainWindow.resourcemanager.GetString("trArchive") + "...");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_stocktakingFalseBranch, MainWindow.resourcemanager.GetString("trBranch/StoreHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_stocktakingFalseType, MainWindow.resourcemanager.GetString("trItemUnit") + "...");

            chk_stocktakingArchivedAllBranches.Content = MainWindow.resourcemanager.GetString("trAll");
            chk_stocktakingArchivedAllTypes.Content = MainWindow.resourcemanager.GetString("trAll");
            chk_stocktakingFalseAllBranches.Content = MainWindow.resourcemanager.GetString("trAll");
            chk_stocktakingFalseAllTypes.Content = MainWindow.resourcemanager.GetString("trAll");


            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_stocktakingArchivedEndDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_stocktakingArchivedStartDate, MainWindow.resourcemanager.GetString("trStartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_stocktakingFalseEndDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_stocktakingFalseStartDate, MainWindow.resourcemanager.GetString("trStartDateHint"));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");

            col_branch.Header = MainWindow.resourcemanager.GetString("trBranch");
            col_itemUnits.Header = MainWindow.resourcemanager.GetString("trItemUnit");
            col_stockTakeNum.Header = MainWindow.resourcemanager.GetString("trNo");
            col_stockTakingCoastType.Header = MainWindow.resourcemanager.GetString("trType");
            col_stockTakingDate.Header = MainWindow.resourcemanager.GetString("trDate");
            col_diffPercentage.Header = MainWindow.resourcemanager.GetString("trDiffrencePercentage");
            col_itemCountAr.Header = MainWindow.resourcemanager.GetString("trItemsCount");
            col_DestroyedCount.Header = MainWindow.resourcemanager.GetString("trDestroyedCount");
            col_destroiedReason.Header = MainWindow.resourcemanager.GetString("trReason");
          
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

        }

        private void hideAllColumn()
        {
            grid_stocktakingArchived.Visibility = Visibility.Hidden;
            grid_stocktakingShortfalse.Visibility = Visibility.Hidden;
            col_branch.Visibility = Visibility.Hidden;
            col_itemUnits.Visibility = Visibility.Hidden;
            col_stockTakeNum.Visibility = Visibility.Hidden;
            col_stockTakingCoastType.Visibility = Visibility.Hidden;
            col_stockTakingDate.Visibility = Visibility.Hidden;
            col_diffPercentage.Visibility = Visibility.Hidden;
            col_itemCountAr.Visibility = Visibility.Hidden;
            col_DestroyedCount.Visibility = Visibility.Hidden;
            col_destroiedReason.Visibility = Visibility.Hidden;
        }
        IEnumerable<ItemTransferInvoice> shortFallsLst;
        private IEnumerable<ItemTransferInvoice> fillListshortFalls(ComboBox branch, ComboBox cb, DatePicker startDate, DatePicker endDate)
        {
            var selectedBranch = branch.SelectedItem as Branch;
            var selectedType1 = cb.SelectedItem as DestroiedCombo;
            var result = falls.Where(x => (

                         (branch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                        && (cb.SelectedItem != null ? (x.itemUnitId == selectedType1.ItemsUnitsId) : true)
                        && (dp_stocktakingFalseStartDate.SelectedDate != null ? (x.IupdateDate >= startDate.SelectedDate) : true)
                        && (dp_stocktakingFalseEndDate.SelectedDate != null ? (x.IupdateDate <= endDate.SelectedDate) : true)
          ));
            shortFallsLst = result;
            return result;
        }

        public void paintStockTakingChilds()
        {
            //bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            grid_stocktakingArchived.Visibility = Visibility.Hidden;
            grid_stocktakingShortfalse.Visibility = Visibility.Hidden;

            bdr_archives.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_shortfalls.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_archives.Foreground = Brushes.White;
            path_shortfalls.Fill = Brushes.White;
        }

        private void fillComboArchivedTypeType()
        {
            var dislist = new[] {
                new { Text = MainWindow.resourcemanager.GetString("trArchived")     , Value = "a" },
                new { Text = MainWindow.resourcemanager.GetString("trDraft")        , Value = "d" },
                new { Text = MainWindow.resourcemanager.GetString("trSaved")        , Value = "n" }
                 };
            cb_stocktakingArchivedType.SelectedValuePath = "Value";
            cb_stocktakingArchivedType.DisplayMemberPath = "Text";
            cb_stocktakingArchivedType.ItemsSource = dislist;
        }

        IEnumerable<InventoryClass> stockTakingLst;
        private IEnumerable<InventoryClass> fillListStockTaking(ComboBox branch, ComboBox cb, DatePicker startDate, DatePicker endDate)
        {
            var selectedBranch = branch.SelectedItem as Branch;
            var selectedType = cb.SelectedItem as StocktakingArchivesTypeCombo;
     
            var result = inventory.Where(x => (
                           (branch.SelectedItem != null ? (x.branchId        == selectedBranch.branchId) : true)
                        && (cb.SelectedItem     != null ? (x.inventoryType   == cb_stocktakingArchivedType.SelectedValue.ToString()) : true)
                        && (dp_stocktakingArchivedStartDate.SelectedDate != null ? (x.inventoryDate >= startDate.SelectedDate) : true)
                        && (dp_stocktakingArchivedEndDate.SelectedDate != null ? (x.inventoryDate <= endDate.SelectedDate) : true)
          ));
            stockTakingLst = result;
            return result;
        }

        private void fillSocktakingEvents()
        {
            RepInventory = fillListStockTaking(cb_stocktakingArchivedBranch, cb_stocktakingArchivedType, dp_stocktakingArchivedStartDate, dp_stocktakingArchivedEndDate);
            dgStock.ItemsSource = RepInventory;
            txt_count.Text = dgStock.Items.Count.ToString();

            fillStocktakingColumnChart();
            fillStocktakingPieChart();
        }

        private void fillSocktakingEventsCall(object sender)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillSocktakingEvents();

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
            fillSocktakingEventsCall(sender);
        }

        private void Chk_stocktakingArchivedAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_stocktakingArchivedBranch.SelectedItem = null;
                cb_stocktakingArchivedBranch.IsEnabled = false;

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

        private void Chk_stocktakingArchivedAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_stocktakingArchivedBranch.IsEnabled = true;

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

        private void Chk_stocktakingArchivedAllTypes_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_stocktakingArchivedType.SelectedItem = null;
                cb_stocktakingArchivedType.IsEnabled = false;

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

        private void Chk_stocktakingArchivedAllTypes_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_stocktakingArchivedType.IsEnabled = true;

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

        private void fillComboItemsUnitsFalls()
        {
            var temp = cb_stocktakingFalseBranch.SelectedItem as Branch;

            cb_stocktakingFalseType.SelectedValuePath = "ItemsUnitsId";
            cb_stocktakingFalseType.DisplayMemberPath = "ItemsUnits";
            if (temp == null)
            {
                cb_stocktakingFalseType.ItemsSource = comboShortFalls
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
                cb_stocktakingFalseType.ItemsSource = comboShortFalls
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


        private void Chk_stocktakingFalseAllTypes_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillShortFallsEvents();

                cb_stocktakingFalseType.SelectedIndex = -1;
                cb_stocktakingFalseType.IsEnabled = false;

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

        private void Chk_stocktakingFalseAllTypes_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillShortFallsEvents();

                cb_stocktakingFalseType.IsEnabled = true;

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

        private void fillShortFallsEventsCall(object sender)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillShortFallsEvents();

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
        
        private void Chk_stocktakingFalseAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillShortFallsEvents();
                cb_stocktakingFalseBranch.IsEnabled = true;

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

        private void Chk_stocktakingFalseAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillShortFallsEvents();

                cb_stocktakingFalseBranch.SelectedIndex = -1;
                cb_stocktakingFalseBranch.IsEnabled = false;

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

        private void Cb_stocktakingFalseBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillComboItemsUnitsFalls();
                fillShortFallsEvents();

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

        private void fillStocktakingRowChart()
        {
            #region
            //List<int> cP = new List<int>();

            //MyAxis.Labels = new List<string>();

            //List<string> names = new List<string>();

            //var temp = fillListStockTaking(cb_stocktakingArchivedBranch, cb_stocktakingArchivedType, dp_stocktakingArchivedStartDate, dp_stocktakingFalseEndDate);

            //for (int month = 1; month <= 12; month++)
            //{
            //    var firstOfThisMonth = new DateTime(DateTime.Now.Year, month, 1);
            //    var firstOfNextMonth = firstOfThisMonth.AddMonths(1);

            //    var draw = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth).Select(c => c.amount.Value).Sum();
            //    cP.Add(draw);

            //    MyAxis.Labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month));
            //}

            //List<string> lable = new List<string>();
            //SeriesCollection rowChartData = new SeriesCollection();

            //rowChartData.Add(
            // new LineSeries
            // {
            //     Values = cP.AsChartValues(),

            //     DataLabels = true,
            // });
            //DataContext = this;
            //rowChart.Series = rowChartData;
            #endregion
        }

        private void fillStocktakingColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();

            //var temp = fillListStockTaking(cb_stocktakingArchivedBranch, cb_stocktakingArchivedType, dp_stocktakingArchivedStartDate, dp_stocktakingArchivedEndDate);

            //var result = temp.GroupBy(s => new { s.inventoryId }).Select(s => new InventoryClass
            var result = stockTakingLst.GroupBy(s => new { s.inventoryId }).Select(s => new InventoryClass
            {
                branchId = s.FirstOrDefault().branchId,
                branchName = s.FirstOrDefault().branchName,
                inventoryId = s.FirstOrDefault().inventoryId,
                inventoryType = s.FirstOrDefault().inventoryType
            });
            archiveCount = result.GroupBy(x => x.branchId).Select(x => new InventoryClass
            {
                branchId = x.FirstOrDefault().branchId,
                inventoryType = x.FirstOrDefault().inventoryType,
                branchName = x.FirstOrDefault().branchName,
                aCount = x.Where(g => g.inventoryType == "a").Count(),
                nCount = x.Where(g => g.inventoryType == "n").Count(),
                dCount = x.Where(g => g.inventoryType == "d").Count(),
                inventoryId = x.FirstOrDefault().inventoryId
            }
            );

            var tempName = result.GroupBy(s => new { s.branchId }).Select(s => new
            {
                itemName = s.FirstOrDefault().branchName,
            });
            names.AddRange(tempName.Select(nn => nn.itemName));
        
            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cPa = new List<int>();
            List<int> cPn = new List<int>();
            List<int> cPd = new List<int>();

            int xCount = 6;
            if (archiveCount.Count() <= 6)
                xCount = archiveCount.Count();

            for (int i = 0; i < xCount; i++)
            {
                cPa.Add(archiveCount.ToList().Skip(i).FirstOrDefault().aCount);
                cPn.Add(archiveCount.ToList().Skip(i).FirstOrDefault().nCount);
                cPd.Add(archiveCount.ToList().Skip(i).FirstOrDefault().dCount);
               
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            if (archiveCount.Count() > 6)
            {
                int cPaSum = 0, cPnSum = 0, cPdSum = 0 ;
                for (int i = 6; i < archiveCount.Count(); i++)
                {
                    cPaSum = cPaSum + archiveCount.ToList().Skip(i).FirstOrDefault().aCount;
                    cPnSum = cPnSum + archiveCount.ToList().Skip(i).FirstOrDefault().nCount;
                    cPdSum = cPdSum + archiveCount.ToList().Skip(i).FirstOrDefault().dCount;
                   
                }
                if (!((cPaSum == 0) && (cPnSum == 0) && (cPdSum == 0) ))
                {
                    cPa.Add(cPaSum);
                    cPn.Add(cPnSum);
                    cPd.Add(cPdSum);

                    axcolumn.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
                }
            }
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPa.AsChartValues(),
                DataLabels = true,
                Title = MainWindow.resourcemanager.GetString("trArchived")
            }) ;
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPn.AsChartValues(),
                DataLabels = true,
                Title = MainWindow.resourcemanager.GetString("trSaved")
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPd.AsChartValues(),
                DataLabels = true,
                Title = MainWindow.resourcemanager.GetString("trDraft")
            });

            DataContext = this;
            cartesianChart.Series = columnChartData;
        }

        private void fillStocktakingPieChart()
        {
            List<string> titles = new List<string>();
            List<int> x = new List<int>();
            int d;
            int n;
            int a;
            titles.Clear();
            //var temp = fillListStockTaking(cb_stocktakingArchivedBranch, cb_stocktakingArchivedType, dp_stocktakingArchivedStartDate, dp_stocktakingArchivedEndDate);
            //var result = temp.GroupBy(s => new { s.inventoryId }).Select(s => new InventoryClass
            var result = stockTakingLst.GroupBy(s => new { s.inventoryId }).Select(s => new InventoryClass
            {
                branchId = s.FirstOrDefault().branchId,
                branchName = s.FirstOrDefault().branchName,
                inventoryId = s.FirstOrDefault().inventoryId,
                inventoryType = s.FirstOrDefault().inventoryType
            });

            d = result.Where(m => m.inventoryType == "d").Count();
            n = result.Where(m => m.inventoryType == "n").Count();
            a = result.Where(m => m.inventoryType == "a").Count();
            x.Add(d);
            x.Add(n);
            x.Add(a);
            titles.Add(MainWindow.resourcemanager.GetString("trDraft"));
            titles.Add(MainWindow.resourcemanager.GetString("trSaved"));
            titles.Add(MainWindow.resourcemanager.GetString("trArchived"));
            SeriesCollection piechartData = new SeriesCollection();

            for (int i = 0; i < x.Count() ; i++)
            {
                List<decimal> final = new List<decimal>();
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

        private void fillFalsRowChart()
        {
            #region
            //List<long> cP = new List<long>();

            //MyAxis.Labels = new List<string>();

            //List<string> names = new List<string>();

            //var temp = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

            //var result = temp.GroupBy(s => new { s.itemUnitId }).Select(s => new ItemTransferInvoice
            //{
            //    branchId = s.FirstOrDefault().branchId,
            //    branchName = s.FirstOrDefault().branchName,
            //    //shortfalls = s.Sum(x => x.shortfalls),
            //    ItemUnits = s.FirstOrDefault().ItemUnits,
            //    itemUnitId = s.FirstOrDefault().itemUnitId,
            //    itemName = s.FirstOrDefault().itemName,
            //    unitName = s.FirstOrDefault().unitName
            //});
            //var tempName = result.GroupBy(s => new { s.itemUnitId }).Select(s => new
            //{
            //    itemName = s.FirstOrDefault().itemName + s.FirstOrDefault().unitName,
            //});
            //names.AddRange(tempName.Select(nn => nn.itemName));
            //for (int i = 0; i < result.Count(); i++)
            //{
            //    //cP.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().shortfalls.ToString()));
            //    MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            //}
            //SeriesCollection rowChartData = new SeriesCollection();

            //rowChartData.Add(
            // new LineSeries
            // {
            //     Values = cP.AsChartValues(),

            //     DataLabels = true,
            // });
            //DataContext = this;
            //rowChart.Series = rowChartData;
            #endregion
        }

        private void fillFalsColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();


            //var temp = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

            //var result = temp.GroupBy(s => new { s.branchId }).Select(s => new InventoryClass
            var result = shortFallsLst.GroupBy(s => new { s.branchId }).Select(s => new InventoryClass
            {
                branchId = s.FirstOrDefault().branchId,
                branchName = s.FirstOrDefault().branchName,
                //shortfalls = s.FirstOrDefault().itemUnitId
                aCount = s.Where(g => g.inventoryType == "n").Count()
            });

            var tempName = result.GroupBy(s => new { s.branchId }).Select(s => new
            {
                itemName = s.FirstOrDefault().branchName,
            });
            names.AddRange(tempName.Select(nn => nn.itemName));

            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cPa = new List<int>();

            int xCount = 6;
            if (result.Count() <= 6)
                xCount = result.Count();
            for (int i = 0; i < xCount; i++)
            {
                cPa.Add(result.ToList().Skip(i).FirstOrDefault().aCount);
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            if(xCount > 6)
            {
                int c = 0;
                for (int i = 6; i < result.Count(); i++)
                {
                    c = c + result.ToList().Skip(i).FirstOrDefault().aCount;
                }
                if (c != 0)
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

        private void fillFalsPieChart()
        {
            List<string> titles = new List<string>();
            List<long> cP = new List<long>();

            titles.Clear();
            //var temp = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

            //var result = temp.GroupBy(s => new { s.itemUnitId }).Select(s => new InventoryClass
            var result = shortFallsLst.GroupBy(s => new { s.itemUnitId }).Select(s => new InventoryClass
            {
                branchId = s.FirstOrDefault().branchId,
                branchName = s.FirstOrDefault().branchName,
                shortfalls = s.Where(g => g.inventoryType == "n").Count(),
                ItemUnits = s.FirstOrDefault().ItemUnits,
                itemUnitId = s.FirstOrDefault().itemUnitId.Value,
                itemName = s.FirstOrDefault().itemName,
                unitName = s.FirstOrDefault().unitName
            });
            var tempName = result.GroupBy(s => new { s.itemUnitId }).Select(s => new
            {
                itemName = s.FirstOrDefault().itemName + s.FirstOrDefault().unitName,
            });
            titles.AddRange(tempName.Select(nn => nn.itemName));
            for (int i = 0; i < result.Count(); i++)
            {
                cP.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().shortfalls.ToString()));
            }
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < cP.Count(); i++)
            {
                List<decimal> final = new List<decimal>();
                List<string> lable = new List<string>();
                final.Add(cP.ToList().Skip(i).FirstOrDefault());
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


        private void fillShortFallsEvents()
        {
            RepItemtrans=  fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);
            dgStock.ItemsSource = RepItemtrans;
            txt_count.Text = dgStock.Items.Count.ToString();

            fillFalsColumnChart();
            fillFalsPieChart();
        }

        private async void Btn_archives_Click(object sender, RoutedEventArgs e)
        {//archives
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

                selectedStocktakingTab = 0;
                txt_search.Text = "";

                paintStockTakingChilds();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_archives);
                path_archives.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                hideAllColumn();
                grid_stocktakingArchived.Visibility = Visibility.Visible;
                col_stockTakeNum.Visibility = Visibility.Visible;
                col_stockTakingCoastType.Visibility = Visibility.Visible;
                col_stockTakingDate.Visibility = Visibility.Visible;
                col_branch.Visibility = Visibility.Visible;
                col_diffPercentage.Visibility = Visibility.Visible;
                col_itemCountAr.Visibility = Visibility.Visible;
                col_DestroyedCount.Visibility = Visibility.Visible;

                chk_stocktakingArchivedAllBranches.IsChecked = true;
                chk_stocktakingArchivedAllTypes.IsChecked = true;

                //fillComboBranches(cb_stocktakingArchivedBranch);
                await SectionData.fillBranchesWithoutMain(cb_stocktakingArchivedBranch);

                fillSocktakingEvents();

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

        private async void Btn_shortfalls_Click(object sender, RoutedEventArgs e)
        {//shortfalls
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

                selectedStocktakingTab = 1;
                txt_search.Text = "";

                paintStockTakingChilds();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_shortfalls);
                path_shortfalls.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                hideAllColumn();
                grid_stocktakingShortfalse.Visibility = Visibility.Visible;
                col_stockTakeNum.Visibility = Visibility.Visible;
                col_stockTakingCoastType.Visibility = Visibility.Visible;
                col_stockTakingDate.Visibility = Visibility.Visible;
                col_branch.Visibility = Visibility.Visible;
                col_itemCountAr.Visibility = Visibility.Visible;
                col_itemUnits.Visibility = Visibility.Visible;
                col_destroiedReason.Visibility = Visibility.Visible;

                chk_stocktakingFalseAllBranches.IsChecked = true;
                chk_stocktakingFalseAllTypes.IsChecked = true;

                //fillComboBranches(cb_stocktakingFalseBranch);
                await SectionData.fillBranchesWithoutMain(cb_stocktakingFalseBranch);
                fillComboItemsUnitsFalls();

                fillShortFallsEvents();

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
            string firstTitle = "stocktaking";
            string secondTitle = "";
            string subTitle = "";
            string Title = "";

            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                // //StatisticReport\Storage\Stocktaking
                if (selectedStocktakingTab == 0)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Stocktaking\Ar\ArArchives.rdlc";
                    secondTitle = "archives";
                }
                else if (selectedStocktakingTab == 1)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Stocktaking\Ar\ArShortfalls.rdlc";
                    secondTitle = "shortfalls";
                }
            }
            else
            {
                if (selectedStocktakingTab == 0)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Stocktaking\En\Archives.rdlc";
                    secondTitle = "archives";
                }
                else if (selectedStocktakingTab == 1)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Stocktaking\En\Shortfalls.rdlc";
                    secondTitle = "shortfalls";
                }
            }
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
            Title = MainWindow.resourcemanagerreport.GetString("trStorageReport") + " / " + subTitle;
            paramarr.Add(new ReportParameter("trTitle", Title));

            if (selectedStocktakingTab == 0)
            {
                 clsReports.StocktakingArchivesReport(RepInventory , rep, reppath, paramarr);
            }
            else if (selectedStocktakingTab == 1)
            {
                clsReports.StocktakingShortfallsReport(RepItemtrans, rep, reppath, paramarr);
            }
            
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//excel
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //Thread t1 = new Thread(() =>
                //{
                    ExcelStocktaking();
                //});
                //t1.Start();

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

        private void ExcelStocktaking()
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

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                /////////////////////////////////////
                Thread t1 = new Thread(() =>
                {
                    printStocktaking();
                });
                t1.Start();
                //////////////////////////////////////

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

        private void printStocktaking()
        {
            BuildReport();

            this.Dispatcher.Invoke(() =>
            {
                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
            });
        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                /////////////////////////////////////
              //  Thread t1 = new Thread(() =>
              //  {
                   pdfStocktaking();
              //  });
              //  t1.Start();
                //////////////////////////////////////

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

        private void pdfStocktaking()
        {
            BuildReport();

            //this.Dispatcher.Invoke(() =>
            //{
                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
                }
          //  });
        }

        private void Dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillSocktakingEventsCall(sender);
        }

        private void CbF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillShortFallsEventsCall(sender);
        }

        private void DpFe_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillShortFallsEventsCall(sender);
        }

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (selectedStocktakingTab == 0)
                    dgStock.ItemsSource = stockTakingLst
                        .Where(obj => (
                    obj.branchName != null ? obj.branchName.ToLower().Contains(txt_search.Text) : true
                    //||
                    //obj.ItemUnits.ToLower().Contains(txt_search.Text)
                    ||
                    obj.inventoryNum != null ? obj.inventoryNum.ToString().ToLower().Contains(txt_search.Text) : true
                    //||
                    //obj.diffPercentage != null ? obj.diffPercentage.ToString().ToLower().Contains(txt_search.Text) : true
                    //||
                    //obj.itemCount != null      ? obj.itemCount.ToString().ToLower().Contains(txt_search.Text)      : true
                    // ||
                    //obj.DestroyedCount != null ? obj.DestroyedCount.ToString().ToLower().Contains(txt_search.Text) : true
                    ));

                else if(selectedStocktakingTab == 1)
                    dgStock.ItemsSource = shortFallsLst
                        .Where(obj => (
                    obj.branchName != null ? obj.branchName.ToLower().Contains(txt_search.Text) : true
                    ||
                    obj.ItemUnits != null ? obj.ItemUnits.ToLower().Contains(txt_search.Text) : true
                    ||
                    obj.inventoryNum != null ? obj.inventoryNum.ToString().ToLower().Contains(txt_search.Text)  : true
                    //||
                    //obj.causeFalls.ToString().ToLower().Contains(txt_search.Text)
                    //||
                    //obj.itemCount.ToString().ToLower().Contains(txt_search.Text)
                    ));
                txt_count.Text = dgStock.Items.Count.ToString();


                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                //SectionData.ExceptionMessage(ex, this);
            }

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            if (selectedStocktakingTab == 0) Btn_archives_Click(btn_archives, null);
            else if (selectedStocktakingTab == 1) Btn_shortfalls_Click(btn_shortfalls , null);

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}

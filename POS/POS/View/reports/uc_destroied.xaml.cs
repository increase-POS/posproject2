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

namespace POS.View.reports
{

    public partial class uc_destroied : UserControl
    {
        private int selectedFatherTab = 0;
        List<Storage> storages;

        List<ItemTransferInvoice> itemsTransfer;
        List<ItemTransferInvoice> itemsInternalTransfer;

        IEnumerable<ItemTransferInvoice> agentsCount;
        IEnumerable<ItemTransferInvoice> invTypeCount;
        IEnumerable<ItemTransferInvoice> invCount;

        IEnumerable<InventoryClass> archiveCount;

        List<InventoryClass> inventory;
        List<InventoryClass> falls;
        List<ItemTransferInvoice> Destroied;

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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.StartAwait();
            try
            {
                inventory = await statisticModel.GetInventory();
                falls = await statisticModel.GetInventoryItems();
                Destroied = await statisticModel.GetDesItems();
                storages = await statisticModel.GetStorage();
                itemsTransfer = await statisticModel.GetExternalMov();
                itemsInternalTransfer = await statisticModel.GetInternalMov();
                comboBranches = await branchModel.GetAllWithoutMain("all");
            }
            catch (Exception)
            {
                MessageBox.Show("No Internat Connection");
            }

            MainWindow.mainWindow.EndAwait();
            comboItems = statisticModel.getItemCombo(storages);
            comboUnits = statisticModel.getUnitCombo(storages);
            comboSection = statisticModel.getSectionCombo(storages);
            comboLocation = statisticModel.getLocationCombo(storages);

            comboExternalItemsItems = statisticModel.getExternalItemCombo(itemsTransfer);
            comboExternalItemsUnits = statisticModel.getExternalUnitCombo(itemsTransfer);
            comboInternalItemsItems = statisticModel.getExternalItemCombo(itemsInternalTransfer);
            comboInternalItemsUnits = statisticModel.getExternalUnitCombo(itemsInternalTransfer);
            comboInternalOperatorType = statisticModel.getTypeCompo(itemsInternalTransfer);
            comboInternalOperatorOperator = statisticModel.getOperatroCompo(itemsInternalTransfer);

            comboExternalAgentsAgentsType = statisticModel.GetExternalAgentTypeCombos(itemsTransfer);
            comboExternalAgentsAgents = statisticModel.GetExternalAgentCombos(itemsTransfer);
            comboExternalInvType = statisticModel.GetExternalInvoiceTypeCombos(itemsTransfer);
            comboExternalInvoiceInvoice = statisticModel.GetExternalInvoiceCombos(itemsTransfer);

            comboDestroiedItemmsUnits = statisticModel.getDestroiedCombo(Destroied);
            selectedFatherTab = 4;
            txt_search.Text = "";
            paint();
            grid_detroied.Visibility = Visibility.Visible;
            bdr_destroied.Background = Brushes.White;
            path_destroied.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            fillComboBranches(cb_destroiedBranch);
            isEnabledButtons();
            hideAllColumn();
            fillDestroidEvents();
            col_branch.Visibility = Visibility.Visible;
            col_destroiedItemsUnits.Visibility = Visibility.Visible;
            col_destroiedNumber.Visibility = Visibility.Visible;
            col_destroiedDate.Visibility = Visibility.Visible;
            col_destroiedReason.Visibility = Visibility.Visible;
            col_destroiedAmount.Visibility = Visibility.Visible;

        }


        public uc_destroied()
        {
            InitializeComponent();
        }

      
        public void paint()
        {

            grid_detroied.Visibility = Visibility.Visible;

            bdr_destroied.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_destroied.Fill = Brushes.White;
        }

 








        /*11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111*/
        private int selectedStockTab = 0;
        IEnumerable<itemCombo> comboItems;
        IEnumerable<unitCombo> comboUnits;
        IEnumerable<sectionCombo> comboSection;
        IEnumerable<locationCombo> comboLocation;

        private void fillComboItems(ComboBox cbBranches, ComboBox cbItems)
        {
            var temp = cbBranches.SelectedItem as Branch;
            cbItems.SelectedValuePath = "ItemId";
            cbItems.DisplayMemberPath = "ItemName";
            if (temp == null)
            {
                cbItems.ItemsSource = comboItems
                    .GroupBy(x => x.ItemId)
                    .Select(g => new itemCombo
                    {
                        ItemId = g.FirstOrDefault().ItemId,
                        ItemName = g.FirstOrDefault().ItemName,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
            else
            {
                cbItems.ItemsSource = comboItems
                    .Where(x => x.BranchId == temp.branchId)
                    .GroupBy(x => x.ItemId)
                    .Select(g => new itemCombo
                    {
                        ItemId = g.FirstOrDefault().ItemId,
                        ItemName = g.FirstOrDefault().ItemName,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }

        private void fillComboUnits(ComboBox cbItems, ComboBox cbUnits)
        {
            var temp = cbItems.SelectedItem as itemCombo;
            cbUnits.SelectedValuePath = "UnitId";
            cbUnits.DisplayMemberPath = "UnitName";
            if (temp == null)
            {
                cbUnits.ItemsSource = comboUnits
                    .GroupBy(x => x.UnitId)
                    .Select(g => new unitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
            else
            {
                cbUnits.ItemsSource = comboUnits
                    .Where(x => x.ItemId == temp.ItemId && x.BranchId == temp.BranchId)
                    .GroupBy(x => x.UnitId)
                    .Select(g => new unitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    }); ;
            }
        }










        /*2222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222*/
        private int selectedExternalTab = 0;
        List<ExternalitemCombo> comboExternalItemsItems;
        List<ExternalUnitCombo> comboExternalItemsUnits;
        List<AgentTypeCombo> comboExternalAgentsAgentsType;
        List<AgentCombo> comboExternalAgentsAgents;
        List<InvTypeCombo> comboExternalInvType;
        List<InvCombo> comboExternalInvoiceInvoice;









       

    




        /*******************************************************************************************************************************************************/
        Statistics statisticModel = new Statistics();

        List<Branch> comboBranches;
        Branch branchModel = new Branch();
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
        /************************************************************************************************************************************/

        List<ExternalitemCombo> comboInternalItemsItems;
        List<ExternalUnitCombo> comboInternalItemsUnits;
        List<internalTypeCombo> comboInternalOperatorType;
        List<internalOperatorCombo> comboInternalOperatorOperator;

        private void isEnabledButtons()
        {
            btn_destroied.IsEnabled = true;
        }

        /************************************اتلاف*************************************/
        List<DestroiedCombo> comboDestroiedItemmsUnits;

        private void fillDestroidEvents()
        {
            dgStock.ItemsSource = fillListDestroied(cb_destroiedBranch, cb_destroiedItemsUnits, dp_destroiedStartDate, dp_destroiedEndDate);
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
            fillComboItemsUnits();
            fillDestroidEvents();
        }

        private void Chk_destroiedAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_destroiedBranch.IsEnabled = true;
        }

        private void Chk_destroiedAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            cb_destroiedBranch.SelectedItem = null;
            cb_destroiedBranch.IsEnabled = false;
        }

        private void Cb_destroiedItemsUnits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDestroidEvents();
        }

        private void Chk_destroiedAllItemsUnits_Checked(object sender, RoutedEventArgs e)
        {
            cb_destroiedItemsUnits.SelectedItem = null;
            cb_destroiedItemsUnits.IsEnabled = false;
        }

        private void Chk_destroiedAllItemsUnits_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_destroiedItemsUnits.IsEnabled = true;
        }

        private void Dp_destroiedEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDestroidEvents();
        }

        private void Dp_destroiedStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDestroidEvents();
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



            for (int i = 0; i < result.Count(); i++)
            {
                cPa.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().quantity.ToString()));
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPa.AsChartValues(),
                DataLabels = true,
                Title = "Amount"
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
                          Title = "Others",
                          DataLabels = true,
                      }
                  );
                    break;
                }

            }
            chart1.Series = piechartData;
        }

        private void Btn_destroied_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    public partial class uc_stocktaking : UserControl
    {
        private int selectedFatherTab = 0;
        List<Storage> storages;

        List<ItemTransferInvoice> itemsTransfer;
        List<ItemTransferInvoice> itemsInternalTransfer;

        //IEnumerable<ItemTransferInvoice> agentsCount;
        //IEnumerable<ItemTransferInvoice> invTypeCount;
        //IEnumerable<ItemTransferInvoice> invCount;

        IEnumerable<InventoryClass> archiveCount;

        List<InventoryClass> inventory;
        List<ItemTransferInvoice> falls;
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                inventory = await statisticModel.GetInventory();
                falls = await statisticModel.GetFallsItems();
                Destroied = await statisticModel.GetDesItems();
                storages = await statisticModel.GetStorage();
                itemsTransfer = await statisticModel.GetExternalMov();
                itemsInternalTransfer = await statisticModel.GetInternalMov();
                comboBranches = await branchModel.GetAllWithoutMain("all");


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

                cbStockType = statisticModel.getStocktakingArchivesTypeCombo(inventory);
                comboShortFalls = statisticModel.getshortFalls(falls);


                hideAllColumn();
                col_stockTakeNum.Visibility = Visibility.Visible;
                col_stockTakingCoastType.Visibility = Visibility.Visible;
                col_stockTakingDate.Visibility = Visibility.Visible;
                col_branch.Visibility = Visibility.Visible;
                col_diffPercentage.Visibility = Visibility.Visible;
                col_itemCountAr.Visibility = Visibility.Visible;
                col_DestroyedCount.Visibility = Visibility.Visible;

                fillComboBranches(cb_stocktakingArchivedBranch);
                fillSocktakingEvents();

                fillSocktakingEvents();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
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

        public void paint()
        {

        }

        private void isEnabledButtons()
        {
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
        private void showSelectedTabColumn()
        {
            hideAllColumn();
            if (selectedFatherTab == 0)
            {
                if (selectedStockTab == 0)
                {
                    hideAllColumn();
                    col_branch.Visibility = Visibility.Visible;
                    col_item.Visibility = Visibility.Visible;
                    col_unit.Visibility = Visibility.Visible;
                    col_quantity.Visibility = Visibility.Visible;
                    col_locationSection.Visibility = Visibility.Visible;
                    col_startDate.Visibility = Visibility.Visible;
                    col_endDate.Visibility = Visibility.Visible;
                    col_Min.Visibility = Visibility.Visible;
                    col_Max.Visibility = Visibility.Visible;
                    col_stockCost.Visibility = Visibility.Visible;
                }
                else if (selectedStockTab == 1)
                {
                    hideAllColumn();
                    col_branch.Visibility = Visibility.Visible;
                    col_section.Visibility = Visibility.Visible;
                    col_location.Visibility = Visibility.Visible;
                    col_quantity.Visibility = Visibility.Visible;
                    col_itemUnits.Visibility = Visibility.Visible;
                    col_startDate.Visibility = Visibility.Visible;
                    col_endDate.Visibility = Visibility.Visible;
                    col_Min.Visibility = Visibility.Visible;
                    col_Max.Visibility = Visibility.Visible;
                    col_stockCost.Visibility = Visibility.Visible;
                }
                else if (selectedStockTab == 2)
                {
                    hideAllColumn();
                    col_branch.Visibility = Visibility.Visible;
                    col_item.Visibility = Visibility.Visible;
                    col_unit.Visibility = Visibility.Visible;
                    col_quantity.Visibility = Visibility.Visible;
                    col_MinCollect.Visibility = Visibility.Visible;
                    col_MaxCollect.Visibility = Visibility.Visible;
                }

            }
            else if (selectedFatherTab == 1)
            {
                if (selectedExternalTab == 0)
                {
                    hideAllColumn();
                    col_branch.Visibility = Visibility.Visible;
                    col_item.Visibility = Visibility.Visible;
                    col_unit.Visibility = Visibility.Visible;
                    col_quantity.Visibility = Visibility.Visible;
                    col_agentTypeAgent.Visibility = Visibility.Visible;
                    col_invTypeNumber.Visibility = Visibility.Visible;
                }
                else if (selectedExternalTab == 1)
                {
                    hideAllColumn();
                    col_branch.Visibility = Visibility.Visible;
                    col_itemUnits.Visibility = Visibility.Visible;
                    col_agent.Visibility = Visibility.Visible;
                    col_quantity.Visibility = Visibility.Visible;
                    col_agentType.Visibility = Visibility.Visible;
                    col_invTypeNumber.Visibility = Visibility.Visible;
                }
                else if (selectedExternalTab == 2)
                {
                    hideAllColumn();
                    col_branch.Visibility = Visibility.Visible;
                    col_invType.Visibility = Visibility.Visible;
                    col_invNumber.Visibility = Visibility.Visible;
                    col_quantity.Visibility = Visibility.Visible;
                    col_agentTypeAgent.Visibility = Visibility.Visible;
                    col_itemUnits.Visibility = Visibility.Visible;
                }
            }


        }

        /************************************************************************************************************************************/


        List<ExternalitemCombo> comboInternalItemsItems;
        List<ExternalUnitCombo> comboInternalItemsUnits;
        List<internalTypeCombo> comboInternalOperatorType;
        List<internalOperatorCombo> comboInternalOperatorOperator;





        /*44444444444444444444444444444444444444444444444444444444444444444444444444444444444444444*/
        private int selectedStocktakingTab = 0;
        List<StocktakingArchivesTypeCombo> cbStockType;
        List<ShortFalls> comboShortFalls;
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
            return result;
        }





        public void paintStockTakingChilds()
        {
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            grid_stocktakingArchived.Visibility = Visibility.Hidden;
            grid_stocktakingShortfalse.Visibility = Visibility.Hidden;

            bdr_archives.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_shortfalls.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_archives.Foreground = Brushes.White;
            path_shortfalls.Fill = Brushes.White;
        }

        private void fillComboArchivedTypeType()
        {
            var temp = cb_stocktakingArchivedBranch.SelectedItem as Branch;
            cb_stocktakingArchivedType.SelectedValuePath = "InventoryType";
            cb_stocktakingArchivedType.DisplayMemberPath = "InventoryType";
            if (temp == null)
            {
                cb_stocktakingArchivedType.ItemsSource = cbStockType
                    .GroupBy(x => x.InventoryType)
                    .Select(g => new StocktakingArchivesTypeCombo
                    {
                        InventoryType = g.FirstOrDefault().InventoryType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
            else
            {
                cb_stocktakingArchivedType.ItemsSource = cbStockType
                    .Where(x => x.BranchId == temp.branchId)
                    .GroupBy(x => x.InventoryType)
                    .Select(g => new StocktakingArchivesTypeCombo
                    {
                        InventoryType = g.FirstOrDefault().InventoryType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }
        private IEnumerable<InventoryClass> fillListStockTaking(ComboBox branch, ComboBox cb, DatePicker startDate, DatePicker endDate)
        {
            var selectedBranch = branch.SelectedItem as Branch;
            var selectedType = cb.SelectedItem as StocktakingArchivesTypeCombo;
            var result = inventory.Where(x => (

                         (branch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                        && (cb.SelectedItem != null ? (x.inventoryType == selectedType.InventoryType) : true)
                        && (dp_stocktakingArchivedStartDate.SelectedDate != null ? (x.inventoryDate >= startDate.SelectedDate) : true)
                        && (dp_stocktakingArchivedEndDate.SelectedDate != null ? (x.inventoryDate <= endDate.SelectedDate) : true)
          ));
            return result;
        }
        private void fillSocktakingEvents()
        {
            dgStock.ItemsSource = fillListStockTaking(cb_stocktakingArchivedBranch, cb_stocktakingArchivedType, dp_stocktakingArchivedStartDate, dp_stocktakingArchivedEndDate);
            fillStocktakingColumnChart();
            fillStocktakingPieChart();
            fillStocktakingRowChart();
        }


        private void Cb_stocktakingArchivedBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
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
                SectionData.ExceptionMessage(ex, this, sender);
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Cb_stocktakingArchivedType_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
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
                SectionData.ExceptionMessage(ex, this, sender);
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Dp_stocktakingArchivedEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Dp_stocktakingArchivedStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
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




        private void Dp_stocktakingFalseStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Dp_stocktakingFalseEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Chk_stocktakingFalseAllTypes_Checked(object sender, RoutedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Chk_stocktakingFalseAllTypes_Unchecked(object sender, RoutedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Cb_stocktakingFalseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Chk_stocktakingFalseAllBranches_Unchecked(object sender, RoutedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Chk_stocktakingFalseAllBranches_Checked(object sender, RoutedEventArgs e)
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
                SectionData.ExceptionMessage(ex, this, sender);
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private IEnumerable<InventoryClass> fillListStockTakingRowChart(ComboBox branch, ComboBox cb, DateTime startDate, DateTime endDate)
        {
            var selectedBranch = branch.SelectedItem as Branch;
            var selectedType = cb.SelectedItem as StocktakingArchivesTypeCombo;
            var result = inventory.Where(x => (

                         (branch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                        && (cb.SelectedItem != null ? (x.inventoryType == selectedType.InventoryType) : true)
                        && ((x.inventoryDate >= startDate))
                        && ((x.inventoryDate <= endDate))
          ));
            return result;
        }

        private void fillStocktakingRowChart()
        {
            List<int> cP = new List<int>();

            MyAxis.Labels = new List<string>();

            List<string> names = new List<string>();

            for (int month = 1; month <= 12; month++)
            {
                var firstOfThisMonth = new DateTime(DateTime.Now.Year, month, 1);
                var firstOfNextMonth = firstOfThisMonth.AddMonths(1);

                var Draw = fillListStockTakingRowChart(cb_stocktakingArchivedBranch, cb_stocktakingArchivedType, firstOfThisMonth, firstOfNextMonth).Count();
                cP.Add(Draw);
                MyAxis.Labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month));
            }

            List<string> lable = new List<string>();
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

        private void fillStocktakingColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();

            var temp = fillListStockTaking(cb_stocktakingArchivedBranch, cb_stocktakingArchivedType, dp_stocktakingArchivedStartDate, dp_stocktakingArchivedEndDate);
            if (selectedStocktakingTab == 1)
            {
                temp = fillListStockTaking(cb_stocktakingArchivedBranch, cb_stocktakingArchivedType, dp_stocktakingArchivedStartDate, dp_stocktakingArchivedEndDate);
            }

            var result = temp.GroupBy(s => new { s.inventoryId }).Select(s => new InventoryClass
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


            for (int i = 0; i < archiveCount.Count(); i++)
            {
                cPa.Add(archiveCount.ToList().Skip(i).FirstOrDefault().aCount);
                cPn.Add(archiveCount.ToList().Skip(i).FirstOrDefault().nCount);
                cPd.Add(archiveCount.ToList().Skip(i).FirstOrDefault().dCount);
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPa.AsChartValues(),
                DataLabels = true,
                Title = "Archived"
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPn.AsChartValues(),
                DataLabels = true,
                Title = "Normal"
            });
            columnChartData.Add(
new StackedColumnSeries
{
    Values = cPd.AsChartValues(),
    DataLabels = true,
    Title = "Drafts"
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
            var temp = fillListStockTaking(cb_stocktakingArchivedBranch, cb_stocktakingArchivedType, dp_stocktakingArchivedStartDate, dp_stocktakingArchivedEndDate);
            if (selectedStocktakingTab == 1)
            {
                temp = fillListStockTaking(cb_stocktakingArchivedBranch, cb_stocktakingArchivedType, dp_stocktakingArchivedStartDate, dp_stocktakingArchivedEndDate);
            }
            var result = temp.GroupBy(s => new { s.inventoryId }).Select(s => new InventoryClass
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
            titles.Add("Drafts");
            titles.Add("Normal");
            titles.Add("Archives");
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < x.Count(); i++)
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
            fillStocktakingRowChart();
        }






        /************************************اتلاف*************************************/


        private IEnumerable<ItemTransferInvoice> fillListDestroied(ComboBox branch, ComboBox cb, DatePicker startDate, DatePicker endDate)
        {
            var selectedBranch = branch.SelectedItem as Branch;
            var selectedType = cb.SelectedItem as DestroiedCombo;
            var result = Destroied.Where(x => (

                         (branch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                        && (cb.SelectedItem != null ? (x.itemUnitId == selectedType.ItemsUnitsId) : true)
                        && (dp_stocktakingFalseStartDate.SelectedDate != null ? (x.IupdateDate >= startDate.SelectedDate) : true)
                        && (dp_stocktakingFalseEndDate.SelectedDate != null ? (x.IupdateDate <= endDate.SelectedDate) : true)
          ));
            return result;
        }






        //private void fillFalsRowChart()
        //{
        //    List<long> cP = new List<long>();

        //    MyAxis.Labels = new List<string>();

        //    List<string> names = new List<string>();

        //    var temp = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

        //    var result = temp.GroupBy(s => new { s.itemUnitId }).Select(s => new InventoryClass
        //    {
        //        branchId = s.FirstOrDefault().branchId,
        //        branchName = s.FirstOrDefault().branchName,
        //        shortfalls = s.Sum(x => x.shortfalls),
        //        ItemUnits = s.FirstOrDefault().ItemUnits,
        //        itemUnitId = s.FirstOrDefault().itemUnitId,
        //        itemName = s.FirstOrDefault().itemName,
        //        unitName = s.FirstOrDefault().unitName
        //    });
        //    var tempName = result.GroupBy(s => new { s.itemUnitId }).Select(s => new
        //    {
        //        itemName = s.FirstOrDefault().itemName + s.FirstOrDefault().unitName,
        //    });
        //    names.AddRange(tempName.Select(nn => nn.itemName));
        //    for (int i = 0; i < result.Count(); i++)
        //    {
        //        cP.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().shortfalls.ToString()));
        //        MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
        //    }
        //    SeriesCollection rowChartData = new SeriesCollection();

        //    rowChartData.Add(
        //     new LineSeries
        //     {
        //         Values = cP.AsChartValues(),

        //         DataLabels = true,
        //     });
        //    DataContext = this;
        //    rowChart.Series = rowChartData;

        //}

        //private void fillFalsColumnChart()
        //{
        //    axcolumn.Labels = new List<string>();
        //    List<string> names = new List<string>();


        //    var temp = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

        //    var result = temp.GroupBy(s => new { s.branchId }).Select(s => new InventoryClass
        //    {
        //        branchId = s.FirstOrDefault().branchId,
        //        branchName = s.FirstOrDefault().branchName,
        //        shortfalls = s.Sum(x => x.shortfalls),
        //    });

        //    var tempName = result.GroupBy(s => new { s.branchId }).Select(s => new
        //    {
        //        itemName = s.FirstOrDefault().branchName,
        //    });
        //    names.AddRange(tempName.Select(nn => nn.itemName));

        //    SeriesCollection columnChartData = new SeriesCollection();
        //    List<long> cPa = new List<long>();



        //    for (int i = 0; i < result.Count(); i++)
        //    {
        //        cPa.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().shortfalls.ToString()));
        //        axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
        //    }

        //    columnChartData.Add(
        //    new StackedColumnSeries
        //    {
        //        Values = cPa.AsChartValues(),
        //        DataLabels = true,
        //        Title = "Amount"
        //    });


        //    DataContext = this;
        //    cartesianChart.Series = columnChartData;
        //}

        //private void fillFalsPieChart()
        //{
        //    List<string> titles = new List<string>();
        //    List<long> cP = new List<long>();

        //    titles.Clear();
        //    var temp = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

        //    var result = temp.GroupBy(s => new { s.itemUnitId }).Select(s => new InventoryClass
        //    {
        //        branchId = s.FirstOrDefault().branchId,
        //        branchName = s.FirstOrDefault().branchName,
        //        shortfalls = s.Sum(x => x.shortfalls),
        //        ItemUnits = s.FirstOrDefault().ItemUnits,
        //        itemUnitId = s.FirstOrDefault().itemUnitId,
        //        itemName = s.FirstOrDefault().itemName,
        //        unitName = s.FirstOrDefault().unitName
        //    });
        //    var tempName = result.GroupBy(s => new { s.itemUnitId }).Select(s => new
        //    {
        //        itemName = s.FirstOrDefault().itemName + s.FirstOrDefault().unitName,
        //    });
        //    titles.AddRange(tempName.Select(nn => nn.itemName));
        //    for (int i = 0; i < result.Count(); i++)
        //    {
        //        cP.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().shortfalls.ToString()));
        //        MyAxis.Labels.Add(titles.ToList().Skip(i).FirstOrDefault());
        //    }
        //    SeriesCollection piechartData = new SeriesCollection();
        //    for (int i = 0; i < cP.Count(); i++)
        //    {
        //        List<decimal> final = new List<decimal>();
        //        List<string> lable = new List<string>();
        //        final.Add(cP.ToList().Skip(i).FirstOrDefault());
        //        piechartData.Add(
        //          new PieSeries
        //          {
        //              Values = final.AsChartValues(),
        //              Title = titles.Skip(i).FirstOrDefault(),
        //              DataLabels = true,
        //          }
        //      );
        //    }
        //    chart1.Series = piechartData;
        //}


        private void fillShortFallsEvents()
        {
            dgStock.ItemsSource = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

            //fillFalsColumnChart();
            //fillFalsRowChart();
            //fillFalsPieChart();
        }

        private void Btn_archives_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                selectedStocktakingTab = 0;
                txt_search.Text = "";
                paintStockTakingChilds();
                grid_stocktakingArchived.Visibility = Visibility.Visible;
                bdr_archives.Background = Brushes.White;
                path_archives.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                hideAllColumn();
                col_stockTakeNum.Visibility = Visibility.Visible;
                col_stockTakingCoastType.Visibility = Visibility.Visible;
                col_stockTakingDate.Visibility = Visibility.Visible;
                col_branch.Visibility = Visibility.Visible;
                col_diffPercentage.Visibility = Visibility.Visible;
                col_itemCountAr.Visibility = Visibility.Visible;
                col_DestroyedCount.Visibility = Visibility.Visible;

                fillComboBranches(cb_stocktakingArchivedBranch);
                fillSocktakingEvents();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_shortfalls_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                selectedStocktakingTab = 1;
                txt_search.Text = "";
                paintStockTakingChilds();
                grid_stocktakingShortfalse.Visibility = Visibility.Visible;
                bdr_shortfalls.Background = Brushes.White;
                path_shortfalls.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                hideAllColumn();
                col_stockTakeNum.Visibility = Visibility.Visible;
                col_stockTakingCoastType.Visibility = Visibility.Visible;
                col_stockTakingDate.Visibility = Visibility.Visible;
                col_branch.Visibility = Visibility.Visible;
                col_itemCountAr.Visibility = Visibility.Visible;
                col_itemUnits.Visibility = Visibility.Visible;
                col_destroiedReason.Visibility = Visibility.Visible;

                fillComboBranches(cb_stocktakingFalseBranch);
                fillShortFallsEvents();
                fillComboItemsUnitsFalls();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

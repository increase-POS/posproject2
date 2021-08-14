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
    public partial class uc_internal : UserControl
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

            showSelectedTabColumn();
            fillComboInternalItemsItems();
            fillComboBranches(cb_internalItemsFromBranches);
            fillComboBranches(cb_internalItemsToBranches);
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            fillInternalColumnChart();
        }

        private void Btn_item_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public uc_internal()
        {
            InitializeComponent();
        }


        public void paintInternalChilds()
        {
           
        }
        private void isEnabledButtonsInternal()
        {
            btn_item.IsEnabled = true;
            btn_operator.IsEnabled = true;
        }
        public void paint()
        {
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            grid_internalItems.Visibility = Visibility.Hidden;
            grid_internalOperater.Visibility = Visibility.Hidden;

            bdr_item.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_operator.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_item.Fill = Brushes.White;
            path_operator.Fill = Brushes.White;
        }


        private void isEnabledButtons()
        {
          
        }
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
        /*Show dg columns*/
        #region
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
         
                if (selectedTab == 0)
                {
                    hideAllColumn();
                    col_branchFrom.Visibility = Visibility.Visible;
                    col_branchTo.Visibility = Visibility.Visible;
                    col_item.Visibility = Visibility.Visible;
                    col_unit.Visibility = Visibility.Visible;
                    col_quantity.Visibility = Visibility.Visible;
                    col_invTypeNumber.Visibility = Visibility.Visible;

                }
                else if (selectedTab == 1)
                {
                    hideAllColumn();
                    col_branch.Visibility = Visibility.Visible;
                    col_item.Visibility = Visibility.Visible;
                    col_unit.Visibility = Visibility.Visible;
                    col_quantity.Visibility = Visibility.Visible;
                    col_invTypeNumber.Visibility = Visibility.Visible;
                }

            #endregion

        }
        /************************************************************************************************************************************/
        private int selectedTab = 0;

       
        private void btn_internalItems_Click(object sender, RoutedEventArgs e)
        {

            selectedTab = 0;
            txt_search.Text = "";
            paint();
            isEnabledButtonsInternal();
            //fillComboBranches(cb_branchesLocation);
            btn_item.IsEnabled = false;
            btn_item.Opacity = 1;
            grid_internalItems.Visibility = Visibility.Visible;
            path_item.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_item.Background = Brushes.White;
            fillComboBranches(cb_internalItemsFromBranches);
            fillComboBranches(cb_internalItemsToBranches);
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            showSelectedTabColumn();
            fillInternalColumnChart();
        }

        private void btn_internalOperator_Click(object sender, RoutedEventArgs e)
        {
            selectedTab = 1;
            txt_search.Text = "";
            paint();
            isEnabledButtonsInternal();
            //fillComboBranches(cb_branchesLocation);
            btn_operator.IsEnabled = false;
            btn_operator.Opacity = 1;
            grid_internalOperater.Visibility = Visibility.Visible;
            path_operator.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_operator.Background = Brushes.White;
            //showSelectedTabColumn();
            fillComboBranches(cb_internalOperaterFromBranches);
            fillComboInternalOperatorType();

            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            showSelectedTabColumn();
            fillInternalColumnChart();
        }



        private void cb_internalItemsItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillComboInternalItemsUnits();
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            fillInternalColumnChart();
        }

        private void chk_internalItemsAllItems_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            cb_internalItemsItems.IsEnabled = false;
            fillInternalColumnChart();
            cb_internalItemsItems.SelectedItem = null;
        }

        private void chk_internalItemsAllItems_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            cb_internalItemsItems.IsEnabled = true;
            fillInternalColumnChart();
        }

        private void cb_internalItemsUnits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            fillInternalColumnChart();
        }

        private void chk_internalItemsAllUnits_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            cb_internalItemsUnits.IsEnabled = false;
            cb_internalItemsUnits.SelectedItem = null;
            fillInternalColumnChart();
        }

        private void chk_internalItemsAllUnits_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            cb_internalItemsUnits.IsEnabled = true;
            fillInternalColumnChart();
        }

        private void cb_internalItemsFromBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            fillInternalColumnChart();
        }

        private void cb_internalItemsToBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            fillInternalColumnChart();
        }

        private void chk_internalItemsFromAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            cb_internalItemsFromBranches.IsEnabled = false;
            cb_internalItemsFromBranches.SelectedItem = null;
            fillInternalColumnChart();
        }

        private void chk_internalItemsFromAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            cb_internalItemsFromBranches.IsEnabled = true;
            fillInternalColumnChart();
        }

        private void chk_internalItemsToAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            cb_internalItemsToBranches.IsEnabled = false;
            cb_internalItemsToBranches.SelectedItem = null;
            fillInternalColumnChart();
        }

        private void chk_internalItemsToAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_internalItemsToBranches.IsEnabled = true;
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            fillInternalColumnChart();
        }

        private void dp_internalItemsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            fillInternalColumnChart();
        }

        private void dp_InternalItemsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            fillInternalColumnChart();
        }










        private void cb_internalOperaterFromBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            fillInternalColumnChart();
        }

        private void chk_internalOperaterFromAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            cb_internalOperaterFromBranches.IsEnabled = false;
            cb_internalOperaterFromBranches.SelectedItem = null;
            fillInternalColumnChart();
        }

        private void chk_internalOperaterFromAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            cb_internalOperaterFromBranches.IsEnabled = true;
            fillInternalColumnChart();

        }

        private void cb_internalOperaterToBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            fillInternalColumnChart();
        }

        private void chk_internalOperaterToAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            fillInternalColumnChart();
        }

        private void chk_internalOperaterToAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            fillInternalColumnChart();
        }

        private void cb_internalOperaterType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            fillInternalColumnChart();
        }

        private void chk_internalOperatorAllTypes_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            cb_internalOperaterType.IsEnabled = false;
            cb_internalOperaterType.SelectedItem = null;
            fillInternalColumnChart();
        }

        private void chk_internalOperatorAllTypes_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            cb_internalOperaterType.IsEnabled = true;
            fillInternalColumnChart();
        }

        private void cb_internalOperatorOperators_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            fillInternalColumnChart();
        }

        private void chk_internalOperatorAllOperators_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            fillInternalColumnChart();
        }

        private void chk_internalOperatorAllOperators_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            fillInternalColumnChart();
        }

        private void dp_InternalOperatorEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            fillInternalColumnChart();
        }

        private void dp_internalOperatorStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            fillInternalColumnChart();
        }

        List<ExternalitemCombo> comboInternalItemsItems;
        List<ExternalUnitCombo> comboInternalItemsUnits;
        List<internalTypeCombo> comboInternalOperatorType;
        List<internalOperatorCombo> comboInternalOperatorOperator;

     


        private void fillComboInternalItemsItems()
        {
            cb_internalItemsItems.SelectedValuePath = "ItemId";
            cb_internalItemsItems.DisplayMemberPath = "ItemName";
            cb_internalItemsItems.ItemsSource = comboInternalItemsItems.GroupBy(x => x.ItemId).Select(x => new ExternalitemCombo
            {
                ItemId = x.FirstOrDefault().ItemId,
                BranchId = x.FirstOrDefault().BranchId,
                ItemName = x.FirstOrDefault().ItemName
            }
            );
        }

        private void fillComboInternalItemsUnits()
        {
            var temp = cb_internalItemsItems.SelectedItem as ExternalitemCombo;

            cb_internalItemsUnits.SelectedValuePath = "UnitId";
            cb_internalItemsUnits.DisplayMemberPath = "UnitName";

            if (temp != null)
            {
                cb_internalItemsUnits.ItemsSource = comboInternalItemsUnits
                     .Where(x => x.ItemId == temp.ItemId)
                    .GroupBy(x => x.UnitId)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
            else
            {
                cb_internalItemsUnits.ItemsSource = comboInternalItemsUnits
                    .GroupBy(x => x.UnitId)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
        }

        private void fillComboInternalOperatorType()
        {
            cb_internalOperaterType.SelectedValuePath = "InvType";
            cb_internalOperaterType.DisplayMemberPath = "InvType";
            cb_internalOperaterType.ItemsSource = comboInternalOperatorType.Where(x => x.InvType == "im" || x.InvType == "ex").GroupBy(x => x.InvType).Select(g => new internalTypeCombo
            {
                InvType = g.FirstOrDefault().InvType
            });
        }

        private IEnumerable<ItemTransferInvoice> fillListInternal(IEnumerable<ItemTransferInvoice> itemsTransfer, ComboBox comboFromBranch, ComboBox comboToBranch, ComboBox Items, ComboBox unit, DatePicker startDate, DatePicker endDate, CheckBox chkAllFromBranches, CheckBox chkAllToBranches, CheckBox chkAllItems, CheckBox chkAllUnits, CheckBox towWays)
        {
            var selectedFromBranch = comboFromBranch.SelectedItem as Branch;


            if (selectedTab == 0)
            {

                var selectedToBranch = comboToBranch.SelectedItem as Branch;
                var selectedItem = Items.SelectedItem as ExternalitemCombo;
                var selectedUnit = unit.SelectedItem as ExternalUnitCombo;
                var result = itemsTransfer.Where(x => (

                         (comboFromBranch.SelectedItem != null ? (x.exportBranchId == selectedFromBranch.branchId) : true)
                        && (comboToBranch.SelectedItem != null ? (x.importBranchId == selectedToBranch.branchId) : true)
                        && (Items.SelectedItem != null ? (x.itemId == selectedItem.ItemId) : true)
                        && (unit.SelectedItem != null ? (x.unitId == selectedUnit.UnitId) : true)
                        && (dp_internalItemsStartDate.SelectedDate != null ? (x.IupdateDate >= startDate.SelectedDate) : true)
                        && (dp_InternalItemsEndDate.SelectedDate != null ? (x.IupdateDate <= endDate.SelectedDate) : true)
                        && (towWays.IsChecked == false ? (x.invType == "ex") : true)

          ));
                return result;
            }

            else if (selectedTab == 1)
            {
                var selectedToBranch = comboToBranch.SelectedItem as internalTypeCombo;
                var result = itemsTransfer.Where(x => (

                                       (comboFromBranch.SelectedItem != null ? (x.branchId == selectedFromBranch.branchId) : true)
                                      && (comboToBranch.SelectedItem != null ? (x.invType == selectedToBranch.InvType) : true)

                                      && (dp_internalItemsStartDate.SelectedDate != null ? (x.IupdateDate >= startDate.SelectedDate) : true)
                                      && (dp_InternalItemsEndDate.SelectedDate != null ? (x.IupdateDate <= endDate.SelectedDate) : true)

                        ));
                return result;
            }
            return null;

        }

        private void Chk_internalItemsTwoWay_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            fillInternalColumnChart();
        }

        private void Chk_internalItemsTwoWay_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            fillInternalColumnChart();
        }
        private void fillInternalRowChart()
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            List<int> pTemp = new List<int>();
            List<int> sTemp = new List<int>();
            List<int> pbTemp = new List<int>();
            List<int> sbTemp = new List<int>();


            var temp = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            if (selectedTab == 1)
            {
                temp = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            }

            var result = temp.GroupBy(x => new { x.branchId, x.invoiceId }).Select(x => new ItemTransferInvoice
            {
                invType = x.FirstOrDefault().invType,
                branchId = x.FirstOrDefault().branchId
            });

            invCount = result.GroupBy(x => x.branchId).Select(x => new ItemTransferInvoice
            {
                PCount = x.Where(g => g.invType == "p").Count(),
                SCount = x.Where(g => g.invType == "s").Count(),
                PbCount = x.Where(g => g.invType == "pb").Count(),
                SbCount = x.Where(g => g.invType == "sb").Count()
            });




            for (int i = 0; i < agentsCount.Count(); i++)
            {
                pTemp.Add(invCount.ToList().Skip(i).FirstOrDefault().PCount);
                pbTemp.Add(invCount.ToList().Skip(i).FirstOrDefault().PbCount);
                sTemp.Add(invCount.ToList().Skip(i).FirstOrDefault().SCount);
                sbTemp.Add(invCount.ToList().Skip(i).FirstOrDefault().SbCount);
            }
            var tempName = temp.GroupBy(s => new { s.branchId, s.invType }).Select(s => new
            {
                locationName = s.FirstOrDefault().branchName
            });
            names.AddRange(tempName.Select(nn => nn.locationName));

            SeriesCollection rowChartData = new SeriesCollection();
            for (int i = 0; i < pTemp.Count(); i++)
            {
                MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = pTemp.AsChartValues(),
              Title = "Purchase"

          });
            rowChartData.Add(
      new LineSeries
      {
          Values = pbTemp.AsChartValues(),
          Title = "Purchase Returns"

      });
            rowChartData.Add(
      new LineSeries
      {
          Values = sTemp.AsChartValues(),
          Title = "Sale"

      });
            rowChartData.Add(
      new LineSeries
      {
          Values = sbTemp.AsChartValues(),
          Title = "Sale Returns"

      });
            rowChart.Series = rowChartData;
            DataContext = this;
        }

        private void fillInternalColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();

            var temp = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            if (selectedTab == 1)
            {
                temp = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            }

            var res = temp.GroupBy(x => new { x.branchId, x.invNumber }).Select(x => new ItemTransferInvoice
            {
                invType = x.FirstOrDefault().invType,
                branchId = x.FirstOrDefault().branchId,
                branchName = x.FirstOrDefault().branchName
            });
            invTypeCount = res.GroupBy(x => x.branchId).Select(x => new ItemTransferInvoice
            {
                ImportCount = x.Where(g => g.invType == "im").Count(),
                ExportCount = x.Where(g => g.invType == "ex").Count()
            }
            );

            var tempName = res.GroupBy(s => new { s.branchId }).Select(s => new
            {
                itemName = s.FirstOrDefault().branchName,
            });
            names.AddRange(tempName.Select(nn => nn.itemName));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();


            for (int i = 0; i < invTypeCount.Count(); i++)
            {
                cP.Add(invTypeCount.ToList().Skip(i).FirstOrDefault().ExportCount);
                cPb.Add(invTypeCount.ToList().Skip(i).FirstOrDefault().ImportCount);
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cP.AsChartValues(),
                DataLabels = true,
                Title = "Export"
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPb.AsChartValues(),
                DataLabels = true,
                Title = "Import"
            });

            DataContext = this;
            cartesianChart.Series = columnChartData;
            fillInternalPieChart();
        }

        private void fillInternalPieChart()
        {
            List<string> titles = new List<string>();
            List<string> titles1 = new List<string>();
            List<decimal> x = new List<decimal>();
            titles.Clear();
            var temp = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            if (selectedTab == 1)
            {
                temp = fillListInternal(itemsInternalTransfer, cb_internalOperaterFromBranches, cb_internalOperaterType, null, null, dp_internalOperatorStartDate, dp_InternalOperatorEndDate, null, null, null, null, null);
            }

            var titleTemp = temp.GroupBy(m => new { m.itemId, m.unitId }).Select(m => new
            {
                agentName = m.FirstOrDefault().itemName + "\n" + m.FirstOrDefault().unitName
            });

            titles.AddRange(titleTemp.Select(jj => jj.agentName));
            var result = temp
                .GroupBy(s => new { s.itemId, s.unitId })
                .Select(s => new ItemTransferInvoice
                {
                    itemId = s.FirstOrDefault().itemId,
                    unitId = s.FirstOrDefault().unitId,
                    quantity = s.Sum(g => g.quantity),
                    itemName = s.FirstOrDefault().itemName,
                    unitName = s.FirstOrDefault().unitName,
                }).OrderByDescending(s => s.quantity);
            if (selectedTab == 0)
            {
                if (chk_internalItemsTwoWay.IsChecked == true)
                {
                    x = result.Select(m => (decimal)m.quantity / 2).ToList();

                }
                else
                {
                    x = result.Select(m => (decimal)m.quantity).ToList();

                }
            }
            else if (selectedTab == 1)
            {
                if (cb_internalOperaterFromBranches.SelectedItem != null)
                {
                    x = result.Select(m => (decimal)m.quantity).ToList();

                }
                else
                {
                    x = result.Select(m => (decimal)m.quantity / 2).ToList();

                }
            }
            titles = result.Select(m => m.itemName).ToList();
            titles1 = result.Select(m => m.unitName).ToList();
            int count = x.Count();
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < count; i++)
            {
                List<decimal> final = new List<decimal>();
                List<string> lable = new List<string>();
                if (i < 5)
                {
                    final.Add(x.Max());
                    lable.Add(titles.Skip(i).FirstOrDefault() + titles1.Skip(i).FirstOrDefault());
                    piechartData.Add(
                      new PieSeries
                      {
                          Values = final.AsChartValues(),
                          Title = lable.FirstOrDefault(),
                          DataLabels = true,
                      }
                  );
                    x.Remove(x.Max());
                }
                else
                {
                    final.Add(x.Sum());
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






    } }
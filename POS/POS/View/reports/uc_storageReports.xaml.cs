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
    public partial class uc_storageReports : UserControl
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

            cbStockType = statisticModel.getStocktakingArchivesTypeCombo(inventory);
            comboDestroiedItemmsUnits = statisticModel.getDestroiedCombo(Destroied);

            fillComboBranches(cb_branchesItem);
            fillComboItems(cb_branchesItem, cb_itemsItem);
            fillComboUnits(cb_itemsItem, cb_unitsItem);
            fillComboSection();
            fillComboLoaction();
            fillComboItems(cb_branchesCollect, cb_itemsCollect);
            fillComboUnits(cb_itemsCollect, cb_unitsCollect);

            fillComboExternalAgentsAgentsType();
            fillComboExternalInvType();
            fillComboExternalAgentsAgents();
            fillComboExternalInvoiceInvoice();
            fillComboExternalAgentsAgents();
            fillComboExternalAgentsAgentsType();

            chk_externalAgentsIn.IsChecked = true;
            chk_externalItemsIn.IsChecked = true;
            chk_externalAgentsOut.IsChecked = true;
            chk_externalItemsOut.IsChecked = true;
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            fillPieChart();
            fillColumnChart();

        }


        public uc_storageReports()
        {
            InitializeComponent();
        }

        #region



        public void paintExternlaChilds()
        {
            bdrMainExternal.RenderTransform = Animations.borderAnimation(50, bdrMainExternal, true);

            grid_externalItems.Visibility = Visibility.Hidden;
            grid_externalAgents.Visibility = Visibility.Hidden;
            grid_externalInvoices.Visibility = Visibility.Hidden;

            txt_externalItems.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            txt_externalAgents.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            txt_externalInvoices.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_externalItems.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_externalAgents.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_externalInvoices.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
        }

        /*Paint father tab control*/
        #region
        public void paint()
        {
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            grid_stock.Visibility = Visibility.Hidden;
            grid_external.Visibility = Visibility.Hidden;
            grid_internal.Visibility = Visibility.Hidden;
            grid_stocktaking.Visibility = Visibility.Hidden;
            grid_detroied.Visibility = Visibility.Hidden;

            bdr_stock.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_external.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_internal.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_stocktaking.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_destroied.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_stock.Fill = Brushes.White;
            path_external.Fill = Brushes.White;
            path_internal.Fill = Brushes.White;
            path_stocktaking.Fill = Brushes.White;
            path_destroied.Fill = Brushes.White;
        }
        #endregion

        /*Enabled childs buttons*/
        #region


        private void isEnabledButtonsExternal()
        {
            btn_externalItems.IsEnabled = true;
            btn_externalAgents.IsEnabled = true;
            btn_externalInvoices.IsEnabled = true;
        }
        #endregion

        /*Enabled father buttons*/
        #region
        private void isEnabledButtons()
        {
            btn_stock.IsEnabled = true;
            btn_external.IsEnabled = true;
            btn_internal.IsEnabled = true;
            btn_stocktaking.IsEnabled = true;
        }
        #endregion

        /*Father tab control buttons*/
        #region


        private void btn_external_Click(object sender, RoutedEventArgs e)
        {
            selectedFatherTab = 1;
            txt_search.Text = "";
            paint();
            grid_external.Visibility = Visibility.Visible;
            bdr_external.Background = Brushes.White;
            path_external.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            isEnabledButtons();
            btn_external.IsEnabled = false;
            btn_external.Opacity = 1;
            fillComboBranches(cb_externalItemsBranches);
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            showSelectedTabColumn();
            fillExternalPieChart();
        }
        #endregion

        /*Stock tab control buttons*/
        #region

        #endregion

        /*External tab control buttons*/
        #region
        private void btn_externalItems_Click(object sender, RoutedEventArgs e)
        {
            selectedExternalTab = 0;
            txt_search.Text = "";
            paintExternlaChilds();
            isEnabledButtonsExternal();
            btn_externalItems.IsEnabled = false;
            btn_externalItems.Opacity = 1;
            grid_externalItems.Visibility = Visibility.Visible;
            txt_externalItems.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_externalItems.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            fillComboBranches(cb_externalItemsBranches);
            showSelectedTabColumn();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);

        }

        private void btn_externalAgents_Click(object sender, RoutedEventArgs e)
        {
            selectedExternalTab = 1;
            txt_search.Text = "";
            paintExternlaChilds();
            isEnabledButtonsExternal();
            btn_externalAgents.IsEnabled = false;
            btn_externalAgents.Opacity = 1;
            grid_externalAgents.Visibility = Visibility.Visible;
            txt_externalAgents.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_externalAgents.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            fillComboBranches(cb_externalAgentsBranches);
            showSelectedTabColumn();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);

        }

        private void btn_externalInvoices_Click(object sender, RoutedEventArgs e)
        {
            selectedExternalTab = 2;
            txt_search.Text = "";
            paintExternlaChilds();
            isEnabledButtonsExternal();
            btn_externalInvoices.IsEnabled = false;
            btn_externalInvoices.Opacity = 1;
            grid_externalInvoices.Visibility = Visibility.Visible;
            txt_externalInvoices.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_externalInvoices.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            fillComboBranches(cb_externalInvoicesBranches);
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null)
            .GroupBy(x => new { x.branchId, x.invoiceId })
                          .Select(s => new ItemTransferInvoice
                          {
                              branchId = s.FirstOrDefault().branchId,
                              branchName = s.FirstOrDefault().branchName,
                              AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                              ItemUnits = s.FirstOrDefault().ItemUnits
                            ,
                              invNumber = s.FirstOrDefault().invNumber,
                              invType = s.FirstOrDefault().invType,
                              quantity = s.FirstOrDefault().quantity
                          });
            showSelectedTabColumn();

        }
        #endregion



        #endregion

        /*Events*/
        #region



        /*External events*/
        #region










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

        private void fillComboSection()
        {
            var temp = cb_branchesLocation.SelectedItem as Branch;
            cb_sectionsLocation.SelectedValuePath = "SectionId";
            cb_sectionsLocation.DisplayMemberPath = "SectionName";
            var result = comboSection;
            if (temp == null)
            {
                cb_sectionsLocation.ItemsSource = result.GroupBy(x => x.SectionId)
                   .Select(g => new sectionCombo { SectionId = g.FirstOrDefault().SectionId, SectionName = g.FirstOrDefault().SectionName, BranchId = g.FirstOrDefault().BranchId }).ToList();
            }
            else
            {
                cb_sectionsLocation.ItemsSource = result.Where(x => x.BranchId == temp.branchId).GroupBy(x => x.SectionId)
                   .Select(g => new sectionCombo { SectionId = g.FirstOrDefault().SectionId, SectionName = g.FirstOrDefault().SectionName, BranchId = g.FirstOrDefault().BranchId }).ToList();
            }

        }

        private void fillComboLoaction()
        {
            var temp = cb_sectionsLocation.SelectedItem as sectionCombo;
            cb_locationsLocation.SelectedValuePath = "locationId";
            cb_locationsLocation.DisplayMemberPath = "LocationName";
            if (temp == null)
            {
                cb_locationsLocation.ItemsSource = comboLocation.GroupBy(x => x.LocationId)
                    .Select(g => new locationCombo { LocationId = g.FirstOrDefault().LocationId, LocationName = g.FirstOrDefault().LocationName, SectionId = g.FirstOrDefault().SectionId }).ToList();
            }
            else
            {
                cb_locationsLocation.ItemsSource = comboLocation.Where(x => x.SectionId == temp.SectionId && x.BranchId == temp.BranchId).GroupBy(x => x.LocationId)
                    .Select(g => new locationCombo { LocationId = g.FirstOrDefault().LocationId, LocationName = g.FirstOrDefault().LocationName, SectionId = g.FirstOrDefault().SectionId }); ;
            }
        }

        private IEnumerable<Storage> fillList(IEnumerable<Storage> storages, ComboBox comboBranch, ComboBox comboItem, ComboBox comboUnit, DatePicker startDate, DatePicker endDate, CheckBox chkAllBranches, CheckBox chkAllItems, CheckBox chkAllUnits, CheckBox expireDate)
        {
            var selectedBranch = comboBranch.SelectedItem as Branch;
            var selectedItem = comboItem.SelectedItem as itemCombo;
            var selectedUnit = comboUnit.SelectedItem as unitCombo;
            var selectedSection = comboItem.SelectedItem as sectionCombo;
            var selectedLocation = comboUnit.SelectedItem as locationCombo;
            int selected = selectedStockTab;
            var result = storages.Where(x => (
            (selectedStockTab != 1 ? (
                     (expireDate != null ? ((chk_expireDateItem.IsChecked == true ? (x.endDate != null) : true)
                    && (startDate.SelectedDate != null ? (x.startDate >= startDate.SelectedDate) : true)
                    && (endDate.SelectedDate != null ? (x.endDate <= endDate.SelectedDate) : true)) : true)
                    && (comboBranch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                    && (comboItem.SelectedItem != null ? (x.itemId == selectedItem.ItemId) : true)
                    && (comboUnit.SelectedItem != null ? (x.unitId == selectedUnit.UnitId) : true))
                    :
                    (expireDate.IsChecked == true ? (x.endDate != null) : true)
                    && (comboBranch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                    && (comboItem.SelectedItem != null ? (x.sectionId == selectedSection.SectionId) : true)
                    && (comboUnit.SelectedItem != null ? (x.locationId == selectedLocation.LocationId) : true)
                    && (startDate.SelectedDate != null ? (x.startDate >= startDate.SelectedDate) : true)
                    && (endDate.SelectedDate != null ? (x.endDate <= endDate.SelectedDate) : true))
            )
            );
            return result;
        }

        /*Stock events*/
        #region

        /*By items events*/
        #region
        private void cb_branchesItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_itemsItem.IsEnabled = true;
            chk_allItemsItem.IsEnabled = true;
            cb_unitsItem.IsEnabled = false;
            cb_unitsItem.SelectedItem = null;
            chk_allUnitsItem.IsEnabled = false;
            fillComboItems(cb_branchesItem, cb_itemsItem);
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            fillPieChart();
        }

        private void cb_itemsItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_unitsItem.IsEnabled = true;
            chk_allUnitsItem.IsEnabled = true;
            fillComboUnits(cb_itemsItem, cb_unitsItem);
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            fillPieChart();
        }

        private void cb_unitsItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            fillPieChart();
        }

        private void chk_allBranchesItem_Checked(object sender, RoutedEventArgs e)
        {
            cb_branchesItem.IsEnabled = false;
            cb_branchesItem.SelectedItem = null;
            cb_itemsItem.IsEnabled = true;
            chk_allItemsItem.IsEnabled = true;
            cb_itemsItem.SelectedItem = null;
        }

        private void chk_allBranchesItem_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_itemsItem.IsEnabled = false;
            cb_branchesItem.IsEnabled = true;

            chk_allUnitsItem.IsEnabled = false;
            chk_allItemsItem.IsEnabled = false;

            chk_allUnitsItem.IsChecked = false;
            chk_allItemsItem.IsChecked = false;
        }

        private void chk_allItemsItem_Checked(object sender, RoutedEventArgs e)
        {
            cb_itemsItem.IsEnabled = false;

            cb_unitsItem.IsEnabled = true;
            chk_allUnitsItem.IsEnabled = true;
            cb_itemsItem.SelectedItem = null;
        }

        private void chk_allItemsItem_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_itemsItem.IsEnabled = true;
            cb_unitsItem.IsEnabled = false;
            cb_unitsItem.SelectedItem = null;
            chk_allUnitsItem.IsEnabled = false;
            chk_allUnitsItem.IsChecked = false;
        }

        private void chk_allUnitsItem_Checked(object sender, RoutedEventArgs e)
        {
            cb_unitsItem.IsEnabled = false;
            cb_unitsItem.SelectedItem = null;
        }

        private void chk_allUnitsItem_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_unitsItem.IsEnabled = true;
        }

        private void chk_expireDateItem_Checked(object sender, RoutedEventArgs e)
        {
            dp_endDateItem.IsEnabled = true;
            dp_startDateItem.IsEnabled = true;
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            fillPieChart();
        }

        private void chk_expireDateItem_Unchecked(object sender, RoutedEventArgs e)
        {
            dp_endDateItem.IsEnabled = false;
            dp_startDateItem.IsEnabled = false;
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            fillPieChart();
        }

        private void dp_startDateItem_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            fillPieChart();
        }

        private void dp_endDateItem_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            fillPieChart();
        }
        #endregion


        /*By locations events*/
        #region
        private void cb_branchesLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_sectionsLocation.IsEnabled = true;
            chk_allSectionsLocation.IsEnabled = true;
            cb_locationsLocation.IsEnabled = false;
            cb_locationsLocation.SelectedItem = null;
            chk_allLocationsLocation.IsEnabled = false;
            fillComboSection();
            dgStock.ItemsSource = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            fillPieChart();
        }

        private void cb_sectionsLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_locationsLocation.IsEnabled = true;
            chk_allLocationsLocation.IsEnabled = true;
            fillComboLoaction();
            dgStock.ItemsSource = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            fillPieChart();
        }

        private void cb_locationsLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            fillPieChart();
        }

        private void chk_allBranchesLocation_Checked(object sender, RoutedEventArgs e)
        {
            cb_branchesLocation.IsEnabled = false;
            cb_branchesLocation.SelectedItem = null;
            cb_sectionsLocation.IsEnabled = true;
            chk_allSectionsLocation.IsEnabled = true;
            cb_sectionsLocation.SelectedItem = null;
        }

        private void chk_allBranchesLocation_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_sectionsLocation.IsEnabled = false;
            cb_branchesLocation.IsEnabled = true;
            chk_allLocationsLocation.IsEnabled = false;
            chk_allSectionsLocation.IsEnabled = false;
            chk_allLocationsLocation.IsChecked = false;
            chk_allSectionsLocation.IsChecked = false;
        }

        private void chk_allSectionsLocation_Checked(object sender, RoutedEventArgs e)
        {
            cb_sectionsLocation.IsEnabled = false;
            cb_locationsLocation.IsEnabled = true;
            chk_allLocationsLocation.IsEnabled = true;
            cb_sectionsLocation.SelectedItem = null;
        }

        private void chk_allSectionsLocation_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_sectionsLocation.IsEnabled = true;
            cb_locationsLocation.IsEnabled = false;
            cb_locationsLocation.SelectedItem = null;
            chk_allSectionsLocation.IsEnabled = false;
            chk_allLocationsLocation.IsEnabled = false;
            chk_allSectionsLocation.IsChecked = false;
        }

        private void chk_allLocationsLocation_Checked(object sender, RoutedEventArgs e)
        {
            cb_locationsLocation.IsEnabled = false;
            cb_locationsLocation.SelectedItem = null;
        }

        private void chk_allLocationsLocation_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_locationsLocation.IsEnabled = true;
        }

        private void chk_expireDateLocation_Checked(object sender, RoutedEventArgs e)
        {
            dp_endDateLocation.IsEnabled = true;
            dp_startDateLocation.IsEnabled = true;
            dgStock.ItemsSource = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            fillPieChart();
        }

        private void chk_expireDateLocation_Unchecked(object sender, RoutedEventArgs e)
        {
            dp_endDateLocation.IsEnabled = false;
            dp_startDateLocation.IsEnabled = false;
            dgStock.ItemsSource = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            fillPieChart();
        }

        private void dp_endDateLocation_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            fillPieChart();
        }

        private void dp_startDateLocation_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            fillPieChart();
        }
        #endregion

        /*Collect events*/
        #region
        private void cb_branchesCollect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_itemsCollect.IsEnabled = true;
            chk_allItemsCollect.IsEnabled = true;
            cb_unitsCollect.IsEnabled = false;
            cb_unitsCollect.SelectedItem = null;
            chk_allUnitsCollect.IsEnabled = false;
            fillComboItems(cb_branchesCollect, cb_itemsCollect);
            dgStock.ItemsSource = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null)
                .GroupBy(x => new { x.branchId, x.itemUnitId })
                          .Select(s => new Storage
                          {
                              branchId = s.FirstOrDefault().branchId,
                              branchName = s.FirstOrDefault().branchName,
                              storeCost = s.FirstOrDefault().storeCost,
                              itemUnitId = s.FirstOrDefault().itemUnitId,
                              ItemUnits = s.FirstOrDefault().ItemUnits
                          ,
                              itemId = s.FirstOrDefault().itemId,
                              itemName = s.FirstOrDefault().itemName,
                              unitId = s.FirstOrDefault().unitId,
                              unitName = s.FirstOrDefault().unitName,
                              quantity = s.Sum(g => g.quantity),
                              minUnitName = s.FirstOrDefault().minUnitName + s.FirstOrDefault().min,
                              maxUnitName = s.FirstOrDefault().maxUnitName + s.FirstOrDefault().max
                          });
            fillPieChart();
        }

        private void cb_itemsCollect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_unitsCollect.IsEnabled = true;
            chk_allUnitsCollect.IsEnabled = true;
            fillComboUnits(cb_itemsCollect, cb_unitsCollect);
            dgStock.ItemsSource = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null).GroupBy(x => new { x.branchId, x.itemUnitId })
                          .Select(s => new Storage
                          {
                              branchId = s.FirstOrDefault().branchId,
                              branchName = s.FirstOrDefault().branchName,
                              storeCost = s.FirstOrDefault().storeCost,
                              itemUnitId = s.FirstOrDefault().itemUnitId,
                              ItemUnits = s.FirstOrDefault().ItemUnits
                          ,
                              itemId = s.FirstOrDefault().itemId,
                              itemName = s.FirstOrDefault().itemName,
                              unitId = s.FirstOrDefault().unitId,
                              unitName = s.FirstOrDefault().unitName,
                              quantity = s.Sum(g => g.quantity),
                              minUnitName = s.FirstOrDefault().minUnitName + s.FirstOrDefault().min,
                              maxUnitName = s.FirstOrDefault().maxUnitName + s.FirstOrDefault().max
                          });
            fillPieChart();
        }

        private void cb_unitsCollect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null).GroupBy(x => new { x.branchId, x.itemUnitId })
                          .Select(s => new Storage
                          {
                              branchId = s.FirstOrDefault().branchId,
                              branchName = s.FirstOrDefault().branchName,
                              storeCost = s.FirstOrDefault().storeCost,
                              itemUnitId = s.FirstOrDefault().itemUnitId,
                              ItemUnits = s.FirstOrDefault().ItemUnits
                          ,
                              itemId = s.FirstOrDefault().itemId,
                              itemName = s.FirstOrDefault().itemName,
                              unitId = s.FirstOrDefault().unitId,
                              unitName = s.FirstOrDefault().unitName,
                              quantity = s.Sum(g => g.quantity),
                              minUnitName = s.FirstOrDefault().minUnitName + s.FirstOrDefault().min,
                              maxUnitName = s.FirstOrDefault().maxUnitName + s.FirstOrDefault().max
                          });
            fillPieChart();
        }

        private void chk_allBranchesCollect_Checked(object sender, RoutedEventArgs e)
        {
            cb_branchesCollect.IsEnabled = false;
            cb_branchesCollect.SelectedItem = null;
            cb_itemsCollect.IsEnabled = true;
            chk_allItemsCollect.IsEnabled = true;
            cb_itemsCollect.SelectedItem = null;
        }

        private void chk_allBranchesCollect_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_itemsCollect.IsEnabled = false;
            cb_branchesCollect.IsEnabled = true;
            chk_allUnitsCollect.IsEnabled = false;
            chk_allItemsCollect.IsEnabled = false;
            chk_allUnitsCollect.IsChecked = false;
            chk_allItemsCollect.IsChecked = false;
        }

        private void chk_allItemsCollect_Checked(object sender, RoutedEventArgs e)
        {
            cb_itemsCollect.IsEnabled = false;
            cb_unitsCollect.IsEnabled = true;
            chk_allUnitsCollect.IsEnabled = true;
            cb_itemsCollect.SelectedItem = null;
        }

        private void chk_allItemsCollect_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_itemsCollect.IsEnabled = true;
            cb_unitsCollect.IsEnabled = false;
            cb_unitsCollect.SelectedItem = null;
            chk_allUnitsCollect.IsEnabled = false;
            chk_allUnitsCollect.IsChecked = false;
        }

        private void chk_allUnitsCollect_Checked(object sender, RoutedEventArgs e)
        {
            cb_unitsCollect.IsEnabled = false;
            cb_unitsCollect.SelectedItem = null;
        }

        private void chk_allUnitsCollect_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_unitsCollect.IsEnabled = true;
        }
        #endregion
        #endregion


        private void btn_byItem_Click(object sender, RoutedEventArgs e)
        {
            selectedStockTab = 0;
            txt_search.Text = "";
            paintStockChilds();
            isEnabledButtonsStock();
            btn_byItem.IsEnabled = false;
            btn_byItem.Opacity = 1;
            grid_byItem.Visibility = Visibility.Visible;
            txt_byItem.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_byItem.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            showSelectedTabColumn();
            fillPieChart();
        }

        private void btn_location_Click(object sender, RoutedEventArgs e)
        {
            selectedStockTab = 1;
            txt_search.Text = "";
            paintStockChilds();
            isEnabledButtonsStock();
            fillComboBranches(cb_branchesLocation);
            btn_location.IsEnabled = false;
            btn_location.Opacity = 1;
            grid_byLocation.Visibility = Visibility.Visible;
            txt_location.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_location.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            showSelectedTabColumn();

            dgStock.ItemsSource = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            fillPieChart();
        }

        private void btn_collect_Click(object sender, RoutedEventArgs e)
        {
            selectedStockTab = 2;
            txt_search.Text = "";
            paintStockChilds();
            isEnabledButtonsStock();
            fillComboBranches(cb_branchesCollect);
            btn_collect.IsEnabled = false;
            btn_collect.Opacity = 1;
            grid_collect.Visibility = Visibility.Visible;
            txt_collect.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_collect.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            showSelectedTabColumn();


            dgStock.ItemsSource = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null).GroupBy(x => new { x.branchId, x.itemUnitId })
                .Select(s => new Storage
                {
                    branchId = s.FirstOrDefault().branchId,
                    branchName = s.FirstOrDefault().branchName,
                    storeCost = s.FirstOrDefault().storeCost,
                    itemUnitId = s.FirstOrDefault().itemUnitId,
                    ItemUnits = s.FirstOrDefault().ItemUnits
                ,
                    itemId = s.FirstOrDefault().itemId,
                    itemName = s.FirstOrDefault().itemName,
                    unitId = s.FirstOrDefault().unitId,
                    unitName = s.FirstOrDefault().unitName,
                    quantity = s.Sum(g => g.quantity),
                    minUnitName = s.FirstOrDefault().minUnitName + s.FirstOrDefault().min,
                    maxUnitName = s.FirstOrDefault().maxUnitName + s.FirstOrDefault().max
                });
            fillPieChart();
        }

        private void btn_stock_Click(object sender, RoutedEventArgs e)
        {
            selectedFatherTab = 0;
            txt_search.Text = "";
            paint();
            grid_stock.Visibility = Visibility.Visible;
            bdr_stock.Background = Brushes.White;
            path_stock.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            isEnabledButtons();
            fillComboBranches(cb_branchesItem);
            btn_stock.IsEnabled = false;
            btn_stock.Opacity = 1;
            showSelectedTabColumn();
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            fillPieChart();
        }

        private void isEnabledButtonsStock()
        {
            btn_byItem.IsEnabled = true;
            btn_location.IsEnabled = true;
            btn_collect.IsEnabled = true;
        }

        public void paintStockChilds()
        {
            bdrMainStock.RenderTransform = Animations.borderAnimation(50, bdrMainStock, true);

            grid_byItem.Visibility = Visibility.Hidden;
            grid_byLocation.Visibility = Visibility.Hidden;
            grid_collect.Visibility = Visibility.Hidden;

            txt_byItem.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            txt_location.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            txt_collect.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_byItem.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_location.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_collect.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
        }

        private void fillRowChart()
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<decimal> pTemp = null;

            var temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);

            if (selectedStockTab == 1)
            {
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            }

            if (selectedStockTab == 2)
            {
                temp = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null);
            }

            var result = temp.GroupBy(s => new { s.sectionId, s.locationId }).Select(s => new
            {
                itemId = s.FirstOrDefault().itemId,
                quantity = s.Sum(g => g.quantity)
            }
        );
            var resultTotal = result.Select(x => new { x.itemId, total = x.quantity }).ToList();
            pTemp = result.Select(x => (decimal)x.quantity);

            var tempName = temp.GroupBy(s => new { s.locationId, s.Secname }).Select(s => new
            {
                locationName = s.FirstOrDefault().branchName + "\n" + s.FirstOrDefault().Secname + " - " + s.FirstOrDefault().x + s.FirstOrDefault().y + s.FirstOrDefault().z
            });
            names.AddRange(tempName.Select(nn => nn.locationName));

            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            for (int i = 0; i < pTemp.Count(); i++)
            {
                purchase.Add(pTemp.ToList().Skip(i).FirstOrDefault());
                MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = purchase.AsChartValues(),
              Title = "Items Quantity"

          });
            DataContext = this;
            rowChart.Series = rowChartData;
        }

        private void fillColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();

            var temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);

            if (selectedStockTab == 1)
            {
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            }
            if (selectedStockTab == 2)
            {
                temp = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null);
            }

            var result = temp.GroupBy(s => new { s.itemId, s.unitId }).Select(s => new Storage
            {
                branchId = s.FirstOrDefault().branchId,
                itemId = s.FirstOrDefault().itemId,
                unitId = s.FirstOrDefault().unitId,
                quantity = s.Sum(g => g.quantity)
            });
            var cc = result.Select(m => new { m.itemId, m.quantity, m.unitId });

            var tempName = temp.GroupBy(s => new { s.itemName, s.unitName }).Select(s => new
            {
                itemName = s.FirstOrDefault().itemName,
                unitName = s.FirstOrDefault().unitName
            });
            names.AddRange(tempName.Select(nn => nn.itemName + " - " + nn.unitName));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> cP = new List<decimal>();
            List<decimal> cPb = new List<decimal>();
            List<decimal> cD = new List<decimal>();


            for (int i = 0; i < cc.Count(); i++)
            {
                cP.Add(cc.ToList().Select(jj => (decimal)jj.quantity).Skip(i).FirstOrDefault());
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cP.AsChartValues(),
                Title = "Items Quantity",
                DataLabels = true,
            });
            DataContext = this;
            cartesianChart.Series = columnChartData;
            fillRowChart();
        }





        /*2222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222*/
        private int selectedExternalTab = 0;
        List<ExternalitemCombo> comboExternalItemsItems;
        List<ExternalUnitCombo> comboExternalItemsUnits;
        List<AgentTypeCombo> comboExternalAgentsAgentsType;
        List<AgentCombo> comboExternalAgentsAgents;
        List<InvTypeCombo> comboExternalInvType;
        List<InvCombo> comboExternalInvoiceInvoice;


        private void fillComboExternalItemsItems()
        {
            var temp = cb_externalItemsBranches.SelectedItem as Branch;
            cb_externalItemsItems.SelectedValuePath = "ItemId";
            cb_externalItemsItems.DisplayMemberPath = "ItemName";
            if (temp == null)
            {
                cb_externalItemsItems.ItemsSource = comboExternalItemsItems
                    .GroupBy(x => x.ItemId)
                    .Select(g => new ExternalitemCombo
                    {
                        ItemId = g.FirstOrDefault().ItemId,
                        ItemName = g.FirstOrDefault().ItemName,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
            else
            {
                cb_externalItemsItems.ItemsSource = comboExternalItemsItems
                    .Where(x => x.BranchId == temp.branchId)
                    .GroupBy(x => x.ItemId)
                    .Select(g => new ExternalitemCombo
                    {
                        ItemId = g.FirstOrDefault().ItemId,
                        ItemName = g.FirstOrDefault().ItemName,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }

        private void fillComboExternalItemsUnits()
        {
            var temp = cb_externalItemsItems.SelectedItem as ExternalitemCombo;
            var temp1 = cb_externalItemsBranches.SelectedItem as Branch;

            cb_externalItemsUnits.SelectedValuePath = "UnitId";
            cb_externalItemsUnits.DisplayMemberPath = "UnitName";
            if (temp == null && temp1 == null)
            {
                cb_externalItemsUnits.ItemsSource = comboExternalItemsUnits
                    .GroupBy(x => x.UnitId)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
            else if (temp != null && temp1 == null)
            {
                cb_externalItemsUnits.ItemsSource = comboExternalItemsUnits
                     .Where(x => x.ItemId == temp.ItemId)
                    .GroupBy(x => x.UnitId)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
            else if (temp == null && temp1 != null)
            {
                cb_externalItemsUnits.ItemsSource = comboExternalItemsUnits
                     .Where(x => x.BranchId == temp1.branchId)
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
                cb_externalItemsUnits.ItemsSource = comboExternalItemsUnits
                    .Where(x => x.ItemId == temp.ItemId && x.BranchId == temp1.branchId)
                    .GroupBy(x => x.UnitId)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
        }

        private void fillComboExternalAgentsAgentsType()
        {
            var temp = cb_externalAgentsBranches.SelectedItem as Branch;
            cb_externalAgentsAgentsType.SelectedValuePath = "AgentId";
            cb_externalAgentsAgentsType.DisplayMemberPath = "AgentType";
            if (temp == null)
            {
                cb_externalAgentsAgentsType.ItemsSource = comboExternalAgentsAgentsType
                    .GroupBy(x => x.AgentType)
                    .Select(g => new AgentTypeCombo
                    {
                        AgentType = g.FirstOrDefault().AgentType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
            else
            {
                cb_externalAgentsAgentsType.ItemsSource = comboExternalAgentsAgentsType
                    .Where(x => x.BranchId == temp.branchId)
                    .GroupBy(x => x.AgentType)
                    .Select(g => new AgentTypeCombo
                    {
                        AgentType = g.FirstOrDefault().AgentType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }

        private void fillComboExternalAgentsAgents()
        {
            var temp = cb_externalAgentsAgentsType.SelectedItem as AgentTypeCombo;
            var temp1 = cb_externalAgentsBranches.SelectedItem as Branch;
            cb_externalAgentsCustomer.SelectedValuePath = "AgentId";
            cb_externalAgentsCustomer.DisplayMemberPath = "AgentName";
            if (temp == null)
            {
                cb_externalAgentsCustomer.ItemsSource = comboExternalAgentsAgents
                    .GroupBy(x => x.AgentId)
                    .Select(g => new AgentCombo
                    {
                        AgentId = g.FirstOrDefault().AgentId,
                        AgentName = g.FirstOrDefault().AgentName,
                        BranchId = g.FirstOrDefault().BranchId,
                        AgentType = g.FirstOrDefault().AgentType
                    }).ToList();
            }
            else if (temp != null && temp1 == null)
            {
                cb_externalAgentsCustomer.ItemsSource = comboExternalAgentsAgents
                        .Where(x => x.AgentType == temp.AgentType)
                    .GroupBy(x => x.AgentId)
                    .Select(g => new AgentCombo
                    {
                        AgentId = g.FirstOrDefault().AgentId,
                        AgentName = g.FirstOrDefault().AgentName,
                        BranchId = g.FirstOrDefault().BranchId,
                        AgentType = g.FirstOrDefault().AgentType
                    }).ToList();
            }
            else if (temp == null && temp1 != null)
            {
                cb_externalAgentsCustomer.ItemsSource = comboExternalAgentsAgents
                        .Where(x => x.BranchId == temp1.branchId)
                    .GroupBy(x => x.AgentId)
                    .Select(g => new AgentCombo
                    {
                        AgentId = g.FirstOrDefault().AgentId,
                        AgentName = g.FirstOrDefault().AgentName,
                        BranchId = g.FirstOrDefault().BranchId,
                        AgentType = g.FirstOrDefault().AgentType
                    }).ToList();
            }
            else
            {
                cb_externalAgentsCustomer.ItemsSource = comboExternalAgentsAgents
                         .Where(x => x.AgentType == temp.AgentType && x.BranchId == temp1.branchId)
                    .GroupBy(x => x.AgentId)
                    .Select(g => new AgentCombo
                    {
                        AgentId = g.FirstOrDefault().AgentId,
                        AgentName = g.FirstOrDefault().AgentName,
                        BranchId = g.FirstOrDefault().BranchId,
                        AgentType = g.FirstOrDefault().AgentType
                    }).ToList();
            }

        }

        private void fillComboExternalInvType()
        {
            var temp = cb_externalInvoicesBranches.SelectedItem as Branch;
            cb_externalInvoicesInvoiceType.SelectedValuePath = "InvoiceId";
            cb_externalInvoicesInvoiceType.DisplayMemberPath = "InvoiceType";
            if (temp == null)
            {
                cb_externalInvoicesInvoiceType.ItemsSource = comboExternalInvType
                    .GroupBy(x => x.InvoiceType)
                    .Select(g => new InvTypeCombo
                    {
                        InvoiceType = g.FirstOrDefault().InvoiceType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
            else
            {
                cb_externalInvoicesInvoiceType.ItemsSource = comboExternalInvType
                    .Where(x => x.BranchId == temp.branchId)
                    .GroupBy(x => x.InvoiceType)
                    .Select(g => new InvTypeCombo
                    {
                        InvoiceType = g.FirstOrDefault().InvoiceType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }

        private void fillComboExternalInvoiceInvoice()
        {
            var temp = cb_externalInvoicesInvoiceType.SelectedItem as InvTypeCombo;
            var temp1 = cb_externalInvoicesBranches.SelectedItem as Branch;
            cb_externalInvoicesInvoice.SelectedValuePath = "InvoiceId";
            cb_externalInvoicesInvoice.DisplayMemberPath = "InvoiceNumber";
            if (temp == null && temp1 == null)
            {
                cb_externalInvoicesInvoice.ItemsSource = comboExternalInvoiceInvoice
                    .GroupBy(x => x.InvoiceId)
                    .Select(g => new InvCombo
                    {
                        InvoiceId = g.FirstOrDefault().InvoiceId,
                        InvoiceNumber = g.FirstOrDefault().InvoiceNumber,
                        BranchId = g.FirstOrDefault().BranchId,
                        InvoiceType = g.FirstOrDefault().InvoiceType
                    }).ToList();
            }
            else if (temp != null && temp1 == null)
            {
                cb_externalInvoicesInvoice.ItemsSource = comboExternalInvoiceInvoice
                      .Where(x => x.InvoiceType == temp.InvoiceType)
                    .GroupBy(x => x.InvoiceId)
                    .Select(g => new InvCombo
                    {
                        InvoiceId = g.FirstOrDefault().InvoiceId,
                        InvoiceNumber = g.FirstOrDefault().InvoiceNumber,
                        BranchId = g.FirstOrDefault().BranchId,
                        InvoiceType = g.FirstOrDefault().InvoiceType
                    }).ToList();
            }
            else if (temp == null && temp1 != null)
            {
                cb_externalInvoicesInvoice.ItemsSource = comboExternalInvoiceInvoice
                      .Where(x => x.BranchId == temp1.branchId)
                    .GroupBy(x => x.InvoiceId)
                    .Select(g => new InvCombo
                    {
                        InvoiceId = g.FirstOrDefault().InvoiceId,
                        InvoiceNumber = g.FirstOrDefault().InvoiceNumber,
                        BranchId = g.FirstOrDefault().BranchId,
                        InvoiceType = g.FirstOrDefault().InvoiceType
                    }).ToList();
            }
            else
            {
                cb_externalInvoicesInvoice.ItemsSource = comboExternalInvoiceInvoice
                    .Where(x => x.InvoiceType == temp.InvoiceType && x.BranchId == temp1.branchId)
                     .GroupBy(x => x.InvoiceId)
                    .Select(g => new InvCombo
                    {
                        InvoiceId = g.FirstOrDefault().InvoiceId,
                        InvoiceNumber = g.FirstOrDefault().InvoiceNumber,
                        BranchId = g.FirstOrDefault().BranchId,
                        InvoiceType = g.FirstOrDefault().InvoiceType
                    }).ToList();
            }
        }

        private IEnumerable<ItemTransferInvoice> fillList(IEnumerable<ItemTransferInvoice> itemsTransfer, ComboBox comboBranch, ComboBox comboItem, ComboBox comboUnit, DatePicker startDate, DatePicker endDate, CheckBox chkAllBranches, CheckBox chkAllItems, CheckBox chkAllUnits, CheckBox chkIn, CheckBox chkOut)
        {
            var selectedBranch = comboBranch.SelectedItem as Branch;
            var selectedItem = comboItem.SelectedItem as ExternalitemCombo;
            var selectedUnit = comboUnit.SelectedItem as ExternalUnitCombo;
            var selectedAgentType = comboItem.SelectedItem as AgentTypeCombo;
            var selectedAgent = comboUnit.SelectedItem as AgentCombo;
            var selectedInvoiceType = comboItem.SelectedItem as InvTypeCombo;
            var selectedInvoice = comboUnit.SelectedItem as InvCombo;

            var result = itemsTransfer.Where(x => (
                  (selectedExternalTab == 0 ? (
                            ((chkIn.IsChecked == true ? (x.invType == "p") || (x.invType == "sb") : false)
                            || (chkOut.IsChecked == true ? (x.invType == "s") || (x.invType == "pb") : false))
                          && (comboBranch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                          && (comboItem.SelectedItem != null ? (x.itemId == selectedItem.ItemId) : true)
                          && (comboUnit.SelectedItem != null ? (x.unitId == selectedUnit.UnitId) : true)
                          && (dp_externalItemsStartDate.SelectedDate != null ? (x.OstartDate >= startDate.SelectedDate) : true)
                          && (dp_externalItemsEndDate.SelectedDate != null ? (x.OendDate <= endDate.SelectedDate) : true)
                          )
                          : true
                          )
                          && (selectedExternalTab == 1 ? (
                           ((chkIn.IsChecked == true ? (x.invType == "p") || (x.invType == "sb") : false)
                            || (chkOut.IsChecked == true ? (x.invType == "s") || (x.invType == "pb") : false))
                          && (comboBranch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                          && (comboItem.SelectedItem != null ? (x.agentType == selectedAgentType.AgentType) : true)
                          && (comboUnit.SelectedItem != null ? (x.agentId == selectedAgent.AgentId) : true)

                          )
                          : true
                          )
                          && (selectedExternalTab == 2 ? (
                            (comboBranch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                          && (comboItem.SelectedItem != null ? (x.invType == selectedInvoiceType.InvoiceType) : true)
                          && (comboUnit.SelectedItem != null ? (x.invoiceId == selectedInvoice.InvoiceId) : true)

                          )
                          : true
                          )
            ));

            return result;
        }

        #region
        /*Items events*/
        #region
        private void cb_externalItemsBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_externalItemsItems.IsEnabled = true;
            chk_externalItemsAllItems.IsEnabled = true;
            fillComboExternalItemsItems();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void chk_externalItemsAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            cb_externalItemsBranches.IsEnabled = false;
            cb_externalItemsBranches.SelectedItem = null;
            cb_externalItemsItems.IsEnabled = true;
            chk_externalItemsAllItems.IsEnabled = true;
            fillComboExternalItemsItems();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void chk_externalItemsAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_externalItemsBranches.IsEnabled = true;
            cb_externalItemsItems.IsEnabled = false;
            cb_externalItemsItems.SelectedItem = null;
            chk_externalItemsAllItems.IsEnabled = false;
            chk_externalItemsAllItems.IsChecked = false;
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void chk_externalItemsIn_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void chk_externalItemsIn_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void chk_externalItemsOut_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void chk_externalItemsOut_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void dp_externalItemsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void dp_externalItemsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void cb_externalItemsItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_externalItemsUnits.IsEnabled = true;
            chk_externalItemsAllUnits.IsEnabled = true;
            fillComboExternalItemsUnits();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void chk_externalItemsAllItems_Checked(object sender, RoutedEventArgs e)
        {
            cb_externalItemsItems.IsEnabled = false;
            cb_externalItemsItems.SelectedItem = null;
            cb_externalItemsUnits.IsEnabled = true;
            chk_externalItemsAllUnits.IsEnabled = true;
            fillComboExternalItemsUnits();
        }

        private void chk_externalItemsAllItems_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_externalItemsItems.IsEnabled = true;
            cb_externalItemsUnits.IsEnabled = false;
            cb_externalItemsUnits.SelectedItem = null;
            chk_externalItemsAllUnits.IsEnabled = false;
            chk_externalItemsAllUnits.IsChecked = false;
        }

        private void cb_externalItemsUnits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            fillExternalPieChart();
        }

        private void chk_externalItemsAllUnits_Checked(object sender, RoutedEventArgs e)
        {
            cb_externalItemsUnits.IsEnabled = false;
            cb_externalItemsUnits.SelectedItem = null;
        }

        private void chk_externalItemsAllUnits_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_externalItemsUnits.IsEnabled = true;
        }
        #endregion

        /*Agents events*/
        #region
        private void cb_externalAgentsBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_externalAgentsAgentsType.IsEnabled = true;
            chk_externalAgentsAllAgentsType.IsEnabled = true;
            fillComboExternalAgentsAgentsType();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            fillExternalPieChart();
        }

        private void cb_externalAgentsAgentsType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_externalAgentsCustomer.IsEnabled = true;
            chk_externalAgentsAllCustomers.IsEnabled = true;
            fillComboExternalAgentsAgents();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            fillExternalPieChart();
        }

        private void cb_externalAgentsCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            fillExternalPieChart();
        }

        private void chk_externalAgentsAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            cb_externalAgentsBranches.IsEnabled = false;
            cb_externalAgentsBranches.SelectedItem = null;
            cb_externalAgentsAgentsType.IsEnabled = true;
            chk_externalAgentsAllAgentsType.IsEnabled = true;
            fillComboExternalAgentsAgentsType();
        }

        private void chk_externalAgentsAllAgentsType_Checked(object sender, RoutedEventArgs e)
        {
            cb_externalAgentsAgentsType.IsEnabled = false;
            cb_externalAgentsAgentsType.SelectedItem = null;
            cb_externalAgentsCustomer.IsEnabled = true;
            chk_externalAgentsAllCustomers.IsEnabled = true;
            fillComboExternalAgentsAgents();
        }

        private void chk_externalAgentsAllCustomers_Checked(object sender, RoutedEventArgs e)
        {
            cb_externalAgentsCustomer.IsEnabled = false;
            cb_externalAgentsCustomer.SelectedItem = null;
        }

        private void chk_externalAgentsAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_externalAgentsBranches.IsEnabled = true;
            cb_externalAgentsAgentsType.IsEnabled = false;
            cb_externalAgentsAgentsType.SelectedItem = null;
            chk_externalAgentsAllAgentsType.IsEnabled = false;
            chk_externalAgentsAllAgentsType.IsChecked = false;
        }

        private void chk_externalAgentsAllAgentsType_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_externalAgentsAgentsType.IsEnabled = true;
            cb_externalAgentsCustomer.IsEnabled = false;
            cb_externalAgentsCustomer.SelectedItem = null;
            chk_externalAgentsAllCustomers.IsEnabled = false;
            chk_externalAgentsAllCustomers.IsChecked = false;
        }

        private void chk_externalAgentsAllCustomers_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_externalAgentsCustomer.IsEnabled = true;
        }

        private void chk_externalAgentsIn_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            fillExternalPieChart();
        }

        private void chk_externalAgentsIn_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            fillExternalPieChart();
        }

        private void chk_externalAgentsOut_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            fillExternalPieChart();
        }

        private void chk_externalAgentsOut_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            fillExternalPieChart();
        }

        private void dp_externalAgentsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            fillExternalPieChart();
        }

        private void dp_externalAgentsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            fillExternalPieChart();
        }

        #endregion

        /*Invoices events*/
        #region
        private void cb_externalInvoicesBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_externalInvoicesInvoiceType.IsEnabled = true;
            chk_externalInvoicesAllInvoicesType.IsEnabled = true;
            fillComboExternalInvType();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                          .Select(s => new ItemTransferInvoice
                          {
                              branchId = s.FirstOrDefault().branchId,
                              branchName = s.FirstOrDefault().branchName,
                              AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                              ItemUnits = s.FirstOrDefault().ItemUnits
                            ,
                              invNumber = s.FirstOrDefault().invNumber,
                              invType = s.FirstOrDefault().invType,
                              quantity = s.FirstOrDefault().quantity
                          }); ;
            fillExternalPieChart();
        }

        private void chk_externalInvoicesAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            cb_externalInvoicesBranches.IsEnabled = false;
            cb_externalInvoicesBranches.SelectedItem = null;
            cb_externalInvoicesInvoiceType.IsEnabled = true;
            chk_externalInvoicesAllInvoicesType.IsEnabled = true;
            fillComboExternalInvType();

        }

        private void chk_externalInvoicesAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_externalInvoicesBranches.IsEnabled = true;
            cb_externalInvoicesInvoiceType.IsEnabled = false;
            cb_externalInvoicesInvoiceType.SelectedItem = null;
            chk_externalInvoicesAllInvoicesType.IsEnabled = false;
            chk_externalInvoicesAllInvoicesType.IsChecked = false;
        }

        private void dp_externalInvoicesEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                          .Select(s => new ItemTransferInvoice
                          {
                              branchId = s.FirstOrDefault().branchId,
                              branchName = s.FirstOrDefault().branchName,
                              AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                              ItemUnits = s.FirstOrDefault().ItemUnits
                            ,
                              invNumber = s.FirstOrDefault().invNumber,
                              invType = s.FirstOrDefault().invType,
                              quantity = s.FirstOrDefault().quantity
                          }); ;
            fillExternalPieChart();
        }

        private void dp_externalInvoicesStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                          .Select(s => new ItemTransferInvoice
                          {
                              branchId = s.FirstOrDefault().branchId,
                              branchName = s.FirstOrDefault().branchName,
                              AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                              ItemUnits = s.FirstOrDefault().ItemUnits
                            ,
                              invNumber = s.FirstOrDefault().invNumber,
                              invType = s.FirstOrDefault().invType,
                              quantity = s.FirstOrDefault().quantity
                          }); ;
            fillExternalPieChart();
        }

        private void cb_externalInvoicesInvoiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_externalInvoicesInvoice.IsEnabled = true;
            chk_externalInvoicesALlInvoice.IsEnabled = true;
            fillComboExternalInvoiceInvoice();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                          .Select(s => new ItemTransferInvoice
                          {
                              branchId = s.FirstOrDefault().branchId,
                              branchName = s.FirstOrDefault().branchName,
                              AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                              ItemUnits = s.FirstOrDefault().ItemUnits
                            ,
                              invNumber = s.FirstOrDefault().invNumber,
                              invType = s.FirstOrDefault().invType,
                              quantity = s.FirstOrDefault().quantity
                          }); ;
            fillExternalPieChart();
        }

        private void chk_externalInvoicesAllInvoicesType_Checked(object sender, RoutedEventArgs e)
        {
            cb_externalInvoicesInvoiceType.IsEnabled = false;
            cb_externalInvoicesInvoiceType.SelectedItem = null;
            cb_externalInvoicesInvoice.IsEnabled = true;
            chk_externalInvoicesALlInvoice.IsEnabled = true;
            fillComboExternalInvoiceInvoice();
        }

        private void chk_externalInvoicesAllInvoicesType_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_externalInvoicesInvoiceType.IsEnabled = true;
            cb_externalInvoicesInvoice.IsEnabled = false;
            cb_externalInvoicesInvoice.SelectedItem = null;
            chk_externalInvoicesALlInvoice.IsEnabled = false;
            chk_externalInvoicesALlInvoice.IsChecked = false;
        }

        private void cb_externalInvoicesInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                          .Select(s => new ItemTransferInvoice
                          {
                              branchId = s.FirstOrDefault().branchId,
                              branchName = s.FirstOrDefault().branchName,
                              AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                              ItemUnits = s.FirstOrDefault().ItemUnits
                            ,
                              invNumber = s.FirstOrDefault().invNumber,
                              invType = s.FirstOrDefault().invType,
                              quantity = s.FirstOrDefault().quantity
                          }); ;
            fillExternalPieChart();

        }

        private void chk_externalInvoicesALlInvoice_Checked(object sender, RoutedEventArgs e)
        {
            cb_externalInvoicesInvoice.IsEnabled = false;
            cb_externalInvoicesInvoice.SelectedItem = null;
        }

        private void chk_externalInvoicesALlInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_externalInvoicesInvoice.IsEnabled = true;
        }


        #endregion
        #endregion

        private void fillExternalRowChart()
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            List<int> pTemp = new List<int>();
            List<int> sTemp = new List<int>();
            List<int> pbTemp = new List<int>();
            List<int> sbTemp = new List<int>();


            var temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            if (selectedExternalTab == 1)
            {
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            }
            else if (selectedExternalTab == 2)
            {
                temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);
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

        private void fillExternalColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();

            var temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);

            if (selectedExternalTab == 1)
            {
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            }
            else if (selectedExternalTab == 2)
            {
                temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);
            }

            var res = temp.GroupBy(x => new { x.branchId, x.agentId }).Select(x => new ItemTransferInvoice
            {
                agentId = x.FirstOrDefault().agentId,
                branchId = x.FirstOrDefault().branchId,
                agentType = x.FirstOrDefault().agentType,
                branchName = x.FirstOrDefault().branchName
            });
            agentsCount = res.GroupBy(x => x.branchId).Select(x => new ItemTransferInvoice
            {
                VenCount = x.Where(g => g.agentType == "v").Count(),
                CusCount = x.Where(g => g.agentType == "c").Count()
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


            for (int i = 0; i < agentsCount.Count(); i++)
            {
                cP.Add(agentsCount.ToList().Skip(i).FirstOrDefault().VenCount);
                cPb.Add(agentsCount.ToList().Skip(i).FirstOrDefault().CusCount);
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cP.AsChartValues(),
                DataLabels = true,
                Title = "Vendor"
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPb.AsChartValues(),
                DataLabels = true,
                Title = "Customer"
            });

            DataContext = this;
            cartesianChart.Series = columnChartData;
            fillExternalRowChart();
        }

        private void fillExternalPieChart()
        {
            List<string> titles = new List<string>();
            List<string> titles1 = new List<string>();
            List<decimal> x = new List<decimal>();
            titles.Clear();
            titles1.Clear();
            var temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            if (selectedExternalTab == 1)
            {
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            }
            else if (selectedExternalTab == 2)
            {
                temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);
            }

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
            x = result.Select(m => (decimal)m.quantity).ToList();
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
            fillExternalColumnChart();
        }



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

            else if (selectedFatherTab == 2)
            {
                if (selectedInternalTab == 0)
                {
                    hideAllColumn();
                    col_branchFrom.Visibility = Visibility.Visible;
                    col_branchTo.Visibility = Visibility.Visible;
                    col_item.Visibility = Visibility.Visible;
                    col_unit.Visibility = Visibility.Visible;
                    col_quantity.Visibility = Visibility.Visible;
                    col_invTypeNumber.Visibility = Visibility.Visible;

                }
                else if (selectedInternalTab == 1)
                {
                    hideAllColumn();
                    col_branch.Visibility = Visibility.Visible;
                    col_item.Visibility = Visibility.Visible;
                    col_unit.Visibility = Visibility.Visible;
                    col_quantity.Visibility = Visibility.Visible;
                    col_invTypeNumber.Visibility = Visibility.Visible;
                }

            }
            #endregion

        }
        /************************************************************************************************************************************/
        private int selectedInternalTab = 0;

        public void paintInternalChilds()
        {
            bdrMainInternal.RenderTransform = Animations.borderAnimation(50, bdrMainInternal, true);

            grid_internalItems.Visibility = Visibility.Hidden;
            grid_internalOperater.Visibility = Visibility.Hidden;

            txt_internalItems.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            txt_internalOperator.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_internalItems.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_internalOperator.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
        }
        private void isEnabledButtonsInternal()
        {
            btn_internalItems.IsEnabled = true;
            btn_internalOperator.IsEnabled = true;
        }
        private void btn_internalItems_Click(object sender, RoutedEventArgs e)
        {
            selectedInternalTab = 0;
            txt_search.Text = "";
            paintInternalChilds();
            isEnabledButtonsInternal();
            //fillComboBranches(cb_branchesLocation);
            btn_internalItems.IsEnabled = false;
            btn_internalItems.Opacity = 1;
            grid_internalItems.Visibility = Visibility.Visible;
            txt_internalItems.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_internalItems.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            //showSelectedTabColumn();
            fillComboBranches(cb_internalItemsFromBranches);
            fillComboBranches(cb_internalItemsToBranches);
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            showSelectedTabColumn();
            fillInternalColumnChart();
        }

        private void btn_internalOperator_Click(object sender, RoutedEventArgs e)
        {
            selectedInternalTab = 1;
            txt_search.Text = "";
            paintInternalChilds();
            isEnabledButtonsInternal();
            //fillComboBranches(cb_branchesLocation);
            btn_internalOperator.IsEnabled = false;
            btn_internalOperator.Opacity = 1;
            grid_internalOperater.Visibility = Visibility.Visible;
            txt_internalOperator.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_internalOperator.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            //showSelectedTabColumn();
            fillComboBranches(cb_internalOperaterFromBranches);
            fillComboInternalOperatorType();

            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
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

        private void btn_internal_Click(object sender, RoutedEventArgs e)
        {
            selectedFatherTab = 2;
            txt_search.Text = "";
            paint();
            grid_internal.Visibility = Visibility.Visible;
            bdr_internal.Background = Brushes.White;
            path_internal.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            isEnabledButtons();
            btn_internal.IsEnabled = false;
            btn_internal.Opacity = 1;
            fillComboBranches(cb_internalItemsFromBranches);
            fillComboBranches(cb_internalItemsToBranches);
            fillComboInternalItemsItems();
            fillComboInternalItemsUnits();
            dgStock.ItemsSource = fillListInternal(itemsInternalTransfer, cb_internalItemsFromBranches, cb_internalItemsToBranches, cb_internalItemsItems, cb_internalItemsUnits, dp_internalItemsStartDate, dp_InternalItemsEndDate, chk_internalItemsFromAllBranches, chk_internalItemsToAllBranches, chk_internalItemsAllItems, chk_internalItemsAllUnits, chk_internalItemsTwoWay);
            showSelectedTabColumn();
            fillInternalColumnChart();
        }
        private void Btn_stocktaking_Click(object sender, RoutedEventArgs e)
        {
            selectedFatherTab = 3;
            txt_search.Text = "";
            paint();
            grid_stocktaking.Visibility = Visibility.Visible;
            bdr_stocktaking.Background = Brushes.White;
            path_stocktaking.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            isEnabledButtons();
            fillComboBranches(cb_stocktakingArchivedBranch);
            fillComboArchivedTypeType();
            btn_stocktaking.IsEnabled = false;
            btn_stocktaking.Opacity = 1;
            hideAllColumn();
            col_stockTakeNum.Visibility = Visibility.Visible;
            col_stockTakingCoastType.Visibility = Visibility.Visible;
            col_stockTakingDate.Visibility = Visibility.Visible;
            col_branch.Visibility = Visibility.Visible;
            col_diffPercentage.Visibility = Visibility.Visible;
            col_itemCountAr.Visibility = Visibility.Visible;
            col_DestroyedCount.Visibility = Visibility.Visible;

            fillSocktakingEvents();
        }
        private void Btn_destroied_Click(object sender, RoutedEventArgs e)
        {
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


            if (selectedInternalTab == 0)
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

            else if (selectedInternalTab == 1)
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
            if (selectedInternalTab == 1)
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
            if (selectedInternalTab == 1)
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
            if (selectedInternalTab == 1)
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
            if (selectedInternalTab == 0)
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
            else if (selectedInternalTab == 1)
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


        /*44444444444444444444444444444444444444444444444444444444444444444444444444444444444444444*/
        private int selectedStocktakingTab = 0;
        List<StocktakingArchivesTypeCombo> cbStockType;
        List<ShortFalls> comboShortFalls;
        private IEnumerable<InventoryClass> fillListshortFalls(ComboBox branch, ComboBox cb, DatePicker startDate, DatePicker endDate)
        {
            var selectedBranch = branch.SelectedItem as Branch;
            var selectedType1 = cb.SelectedItem as DestroiedCombo;
            var result = falls.Where(x => (

                         (branch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                        && (cb.SelectedItem != null ? (x.itemUnitId == selectedType1.ItemsUnitsId) : true)
                        && (dp_stocktakingFalseStartDate.SelectedDate != null ? (x.updateDate >= startDate.SelectedDate) : true)
                        && (dp_stocktakingFalseEndDate.SelectedDate != null ? (x.updateDate <= endDate.SelectedDate) : true)
          ));
            return result;
        }



        private void Btn_stocktakeArchived_Click(object sender, RoutedEventArgs e)
        {
            selectedStocktakingTab = 0;
            txt_search.Text = "";
            paintStockTakingChilds();
            grid_stocktakingArchived.Visibility = Visibility.Visible;
            txt_stocktakeArchived.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_stocktakeArchived.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
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
        }
        private void Btn_stocktakeShortfalse_Click(object sender, RoutedEventArgs e)
        {
            selectedStocktakingTab = 1;
            txt_search.Text = "";
            paintStockTakingChilds();
            grid_stocktakingShortfalse.Visibility = Visibility.Visible;
            txt_stocktakeShortfalse.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_stocktakeShortfalse.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));

            hideAllColumn();
            col_stockTakeNum.Visibility = Visibility.Visible;
            col_stockTakingCoastType.Visibility = Visibility.Visible;
            col_stockTakingDate.Visibility = Visibility.Visible;
            col_branch.Visibility = Visibility.Visible;
            col_itemCountAr.Visibility = Visibility.Visible;
            col_itemUnits.Visibility = Visibility.Visible;

            fillComboBranches(cb_stocktakingFalseBranch);
            fillShortFallsEvents();
            fillComboItemsUnitsFalls();
        }
        public void paintStockTakingChilds()
        {
            bdrMainStocktake.RenderTransform = Animations.borderAnimation(50, bdrMainStocktake, true);

            grid_stocktakingArchived.Visibility = Visibility.Hidden;
            grid_stocktakingShortfalse.Visibility = Visibility.Hidden;

            txt_stocktakeArchived.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            txt_stocktakeShortfalse.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_stocktakeArchived.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_stocktakeShortfalse.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
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
            fillSocktakingEvents();
        }

        private void Chk_stocktakingArchivedAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            cb_stocktakingArchivedBranch.SelectedItem = null;
            cb_stocktakingArchivedBranch.IsEnabled = false;
        }

        private void Chk_stocktakingArchivedAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_stocktakingArchivedBranch.IsEnabled = true;
        }

        private void Cb_stocktakingArchivedType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillSocktakingEvents();
        }

        private void Chk_stocktakingArchivedAllTypes_Checked(object sender, RoutedEventArgs e)
        {
            cb_stocktakingArchivedType.SelectedItem = null;
            cb_stocktakingArchivedType.IsEnabled = false;
        }

        private void Chk_stocktakingArchivedAllTypes_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_stocktakingArchivedType.IsEnabled = true;
        }

        private void Dp_stocktakingArchivedEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillSocktakingEvents();
        }

        private void Dp_stocktakingArchivedStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillSocktakingEvents();
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
            fillShortFallsEvents();
        }

        private void Dp_stocktakingFalseEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillShortFallsEvents();
        }

        private void Chk_stocktakingFalseAllTypes_Checked(object sender, RoutedEventArgs e)
        {
            fillShortFallsEvents();
        }

        private void Chk_stocktakingFalseAllTypes_Unchecked(object sender, RoutedEventArgs e)
        {
            fillShortFallsEvents();
        }

        private void Cb_stocktakingFalseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillShortFallsEvents();
        }

        private void Chk_stocktakingFalseAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            fillShortFallsEvents();

        }

        private void Chk_stocktakingFalseAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            fillShortFallsEvents();
        }

        private void Cb_stocktakingFalseBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillComboItemsUnitsFalls();
            fillShortFallsEvents();
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
                        && (dp_stocktakingFalseStartDate.SelectedDate != null ? (x.IupdateDate >= startDate.SelectedDate) : true)
                        && (dp_stocktakingFalseEndDate.SelectedDate != null ? (x.IupdateDate <= endDate.SelectedDate) : true)
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
        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            List<decimal> x = new List<decimal>();
            titles.Clear();

            var temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);

            if (selectedStockTab == 1)
            {
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
            }
            if (selectedStockTab == 2)
            {
                temp = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null);
            }

            var titleTemp = temp.GroupBy(m => m.branchName);
            titles.AddRange(titleTemp.Select(jj => jj.Key));
            var result = temp.GroupBy(s => s.branchId).Select(s => new Storage
            {
                branchId = s.FirstOrDefault().branchId,
                quantity = s.Sum(g => g.quantity),
                branchName = s.FirstOrDefault().branchName,
            }).OrderByDescending(s => s.quantity);
            x = result.Select(m => (decimal)m.quantity).ToList();
            int count = x.Count();
            titles = result.Select(m => m.branchName).ToList();
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < count; i++)
            {
                List<decimal> final = new List<decimal>();
                List<string> lable = new List<string>();
                if (i < 5)
                {
                    final.Add(x.Max());
                    lable.Add(titles.Skip(i).FirstOrDefault());
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
            fillColumnChart();
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




        private void fillFalsRowChart()
        {
            List<long> cP = new List<long>();

            MyAxis.Labels = new List<string>();

            List<string> names = new List<string>();

            var temp = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

            var result = temp.GroupBy(s => new { s.itemUnitId }).Select(s => new InventoryClass
            {
                branchId = s.FirstOrDefault().branchId,
                branchName = s.FirstOrDefault().branchName,
                shortfalls = s.Sum(x => x.shortfalls),
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
                cP.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().shortfalls.ToString()));
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

        private void fillFalsColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();


            var temp = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

            var result = temp.GroupBy(s => new { s.branchId }).Select(s => new InventoryClass
            {
                branchId = s.FirstOrDefault().branchId,
                branchName = s.FirstOrDefault().branchName,
                shortfalls = s.Sum(x => x.shortfalls),
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
                cPa.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().shortfalls.ToString()));
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

        private void fillFalsPieChart()
        {
            List<string> titles = new List<string>();
            List<long> cP = new List<long>();

            titles.Clear();
            var temp = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

            var result = temp.GroupBy(s => new { s.itemUnitId }).Select(s => new InventoryClass
            {
                branchId = s.FirstOrDefault().branchId,
                branchName = s.FirstOrDefault().branchName,
                shortfalls = s.Sum(x => x.shortfalls),
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
            for (int i = 0; i < result.Count(); i++)
            {
                cP.Add(long.Parse(result.ToList().Skip(i).FirstOrDefault().shortfalls.ToString()));
                MyAxis.Labels.Add(titles.ToList().Skip(i).FirstOrDefault());
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
            dgStock.ItemsSource = fillListshortFalls(cb_stocktakingFalseBranch, cb_stocktakingFalseType, dp_stocktakingFalseStartDate, dp_stocktakingFalseEndDate);

            fillFalsColumnChart();
            fillFalsRowChart();
            fillFalsPieChart();
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}


#endregion
#endregion
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

namespace POS.View.reports
{
    public partial class uc_storageReports : UserControl
    {
        private int selectedFatherTab = 0;
        List<Storage> storages;
        List<ItemTransferInvoice> itemsTransfer;

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
            storages = await statisticModel.GetStorage();
            itemsTransfer = await statisticModel.GetExternalMov();
            comboBranches = await branchModel.GetAllWithoutMain("all");
            comboItems = statisticModel.getItemCombo(storages);
            comboUnits = statisticModel.getUnitCombo(storages);
            comboSection = statisticModel.getSectionCombo(storages);
            comboLocation = statisticModel.getLocationCombo(storages);

            comboExternalItemsItems = statisticModel.getExternalItemCombo(itemsTransfer);
            comboExternalItemsUnits = statisticModel.getExternalUnitCombo(itemsTransfer);

            comboExternalAgentsAgentsType = statisticModel.GetExternalAgentTypeCombos(itemsTransfer);
            comboExternalAgentsAgents = statisticModel.GetExternalAgentCombos(itemsTransfer);
            comboExternalInvType = statisticModel.GetExternalInvoiceTypeCombos(itemsTransfer);
            comboExternalInvoiceInvoice = statisticModel.GetExternalInvoiceCombos(itemsTransfer);

            fillComboBranches(cb_branchesItem);
            fillComboItems(cb_branchesItem, cb_itemsItem);
            fillComboUnits(cb_itemsItem, cb_unitsItem);
            fillComboSection();
            fillComboLoaction();
            fillComboItems(cb_branchesCollect, cb_itemsCollect);
            fillComboUnits(cb_itemsCollect, cb_unitsCollect);
            dgStock.ItemsSource = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
            fillPieChart();
            fillColumnChart();
            fillComboExternalAgentsAgentsType();
            fillComboExternalInvType();
            fillComboExternalAgentsAgents();
            fillComboExternalInvoiceInvoice();
            fillComboExternalAgentsAgents();
            fillComboExternalAgentsAgentsType();
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

            bdr_stock.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_external.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_stock.Fill = Brushes.White;
            path_external.Fill = Brushes.White;
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
            btn_stock.IsEnabled = false;
            btn_stock.Opacity = 1;
            showSelectedTabColumn();
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
                DataLabels = true,
            });
            DataContext = this;
            cartesianChart.Series = columnChartData;
            fillRowChart();
        }

        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            IEnumerable<decimal> x = null;
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
            var result = temp.GroupBy(s => s.branchId).Select(s => new Storage { branchId = s.FirstOrDefault().branchId, quantity = s.Sum(g => g.quantity) });
            x = result.Select(m => (decimal)m.quantity);

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
            fillColumnChart();
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
            cb_externalItemsUnits.SelectedValuePath = "UnitId";
            cb_externalItemsUnits.DisplayMemberPath = "UnitName";
            if (temp == null)
            {
                cb_externalItemsUnits.ItemsSource = comboExternalItemsUnits
                    .GroupBy(x => x.UnitName)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
            else
            {
                cb_externalItemsUnits.ItemsSource = comboUnits
                    .Where(x => x.ItemId == temp.ItemId && x.BranchId == temp.BranchId)
                    .GroupBy(x => x.UnitId)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    }); ;
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
                        AgentId = g.FirstOrDefault().AgentId,
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
                        AgentId = g.FirstOrDefault().AgentId,
                        AgentType = g.FirstOrDefault().AgentType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }

        private void fillComboExternalAgentsAgents()
        {
            var temp = cb_externalAgentsAgentsType.SelectedItem as AgentTypeCombo;
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


            else
            {
                cb_externalAgentsCustomer.ItemsSource = comboExternalAgentsAgents
                         .Where(x => x.AgentId == temp.AgentId && x.BranchId == temp.BranchId)
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
            var temp = cb_externalItemsBranches.SelectedItem as Branch;
            cb_externalInvoicesInvoiceType.SelectedValuePath = "InvoiceId";
            cb_externalInvoicesInvoiceType.DisplayMemberPath = "InvoiceType";
            if (temp == null)
            {
                cb_externalInvoicesInvoiceType.ItemsSource = comboExternalInvType
                    .GroupBy(x => x.InvoiceType)
                    .Select(g => new InvTypeCombo
                    {
                        InvoiceId = g.FirstOrDefault().InvoiceId,
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
                        InvoiceId = g.FirstOrDefault().InvoiceId,
                        InvoiceType = g.FirstOrDefault().InvoiceType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }

        private void fillComboExternalInvoiceInvoice()
        {
            var temp = cb_externalInvoicesInvoiceType.SelectedItem as InvTypeCombo;
            cb_externalInvoicesInvoice.SelectedValuePath = "InvoiceId";
            cb_externalInvoicesInvoice.DisplayMemberPath = "InvoiceNumber";
            if (temp == null)
            {
                cb_externalInvoicesInvoice.ItemsSource = comboExternalInvoiceInvoice
                    .GroupBy(x => x.InvoiceId)
                    .Select(g => new InvCombo
                    {
                        InvoiceId = (int)g.FirstOrDefault().InvoiceId,
                        InvoiceNumber = g.FirstOrDefault().InvoiceNumber,
                        BranchId = (int)g.FirstOrDefault().BranchId,
                        InvoiceType = g.FirstOrDefault().InvoiceType
                    }).ToList();
            }
            else
            {
                cb_externalInvoicesInvoice.ItemsSource = comboExternalInvoiceInvoice
                    .Where(x => x.InvoiceType == temp.InvoiceType && x.BranchId == temp.BranchId)
                     .GroupBy(x => x.InvoiceId)
                    .Select(g => new InvCombo
                    {
                        InvoiceId = (int)g.FirstOrDefault().InvoiceId,
                        InvoiceNumber = g.FirstOrDefault().InvoiceNumber,
                        BranchId = (int)g.FirstOrDefault().BranchId,
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
                            (chkIn.IsChecked == true ? (x.invType == "p") || (x.invType == "sb") : true)
                            && (chkOut.IsChecked == true ? (x.invType == "s") || (x.invType == "pb") : true)
                          && (comboBranch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                          && (comboItem.SelectedItem != null ? (x.ITitemId == selectedItem.ItemId) : true)
                          && (comboUnit.SelectedItem != null ? (x.ITunitId == selectedUnit.UnitId) : true)

                          )
                          : true
                          )
                          && (selectedExternalTab == 1 ? (
                           (comboBranch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
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
        }

        private void chk_externalItemsAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            cb_externalItemsBranches.IsEnabled = false;
            cb_externalItemsBranches.SelectedItem = null;
            cb_externalItemsItems.IsEnabled = true;
            chk_externalItemsAllItems.IsEnabled = true;
            fillComboExternalItemsItems();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
        }

        private void chk_externalItemsAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_externalItemsBranches.IsEnabled = true;
            cb_externalItemsItems.IsEnabled = false;
            cb_externalItemsItems.SelectedItem = null;
            chk_externalItemsAllItems.IsEnabled = false;
            chk_externalItemsAllItems.IsChecked = false;
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);

        }

        private void chk_externalItemsIn_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
        }

        private void chk_externalItemsIn_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
        }

        private void chk_externalItemsOut_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
        }

        private void chk_externalItemsOut_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
        }

        private void dp_externalItemsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
        }

        private void dp_externalItemsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
        }

        private void cb_externalItemsItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_externalItemsUnits.IsEnabled = true;
            chk_externalItemsAllUnits.IsEnabled = true;
            fillComboExternalItemsUnits();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);

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

        }

        private void cb_externalAgentsAgentsType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_externalAgentsCustomer.IsEnabled = true;
            chk_externalAgentsAllCustomers.IsEnabled = true;
            fillComboExternalAgentsAgents();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);

        }

        private void cb_externalAgentsCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);

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

        }

        private void chk_externalAgentsIn_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);

        }

        private void chk_externalAgentsOut_Checked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);

        }

        private void chk_externalAgentsOut_Unchecked(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);

        }

        private void dp_externalAgentsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);

        }

        private void dp_externalAgentsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
        }

        #endregion

        /*Invoices events*/
        #region
        private void cb_externalInvoicesBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_externalInvoicesInvoiceType.IsEnabled = true;
            chk_externalInvoicesAllInvoicesType.IsEnabled = true;
            fillComboExternalInvType();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);
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
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);
        }

        private void dp_externalInvoicesStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);
        }

        private void cb_externalInvoicesInvoiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_externalInvoicesInvoice.IsEnabled = true;
            chk_externalInvoicesALlInvoice.IsEnabled = true;
            fillComboExternalInvoiceInvoice();
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);
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
            dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);

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
            IEnumerable<decimal> pTemp = null;

            var temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            if (selectedExternalTab == 1)
            {

            }
            else if (selectedExternalTab == 2)
            {

            }

            var result = temp.GroupBy(s => new { s.branchId, s.invType }).Select(s => new
            {
                invType = s.FirstOrDefault().invType,
                branchId = s.FirstOrDefault().branchId,
                quantity = s.Count()
            }
        );
            pTemp = result.Select(x => (decimal)x.quantity);

            var tempName = temp.GroupBy(s => new { s.branchId, s.invType }).Select(s => new
            {
                locationName = s.FirstOrDefault().invType + "\n" + s.FirstOrDefault().branchName
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

            }
            else if (selectedExternalTab == 2)
            {

            }

            var result = temp.GroupBy(s => new { s.itemId, s.unitId }).Select(s => new ItemTransferInvoice
            {
                branchId = (int)s.FirstOrDefault().branchId,
                itemId = (int)s.FirstOrDefault().itemId,
                unitId = (int)s.FirstOrDefault().unitId,
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
                DataLabels = true,
            });
            DataContext = this;
            cartesianChart.Series = columnChartData;
            fillExternalRowChart();
        }

        private void fillExternalPieChart()
        {
            List<string> titles = new List<string>();
            IEnumerable<decimal> x = null;
            titles.Clear();
            var temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            if (selectedExternalTab == 1)
            {

            }
            else if (selectedExternalTab == 2)
            {

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
                    quantity = s.Sum(g => g.quantity)
                });
            x = result.Select(m => (decimal)m.quantity);

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
        private void showAllColumn()
        {
            col_branch.Visibility = Visibility.Visible;
            col_item.Visibility = Visibility.Visible;
            col_unit.Visibility = Visibility.Visible;
            col_locationSection.Visibility = Visibility.Visible;
            col_quantity.Visibility = Visibility.Visible;
            col_startDate.Visibility = Visibility.Visible;
            col_endDate.Visibility = Visibility.Visible;
            col_Min.Visibility = Visibility.Visible;
            col_Max.Visibility = Visibility.Visible;
            col_stockCost.Visibility = Visibility.Visible;

            col_location.Visibility = Visibility.Visible;
            col_section.Visibility = Visibility.Visible;
            col_itemUnits.Visibility = Visibility.Visible;

            col_invNumber.Visibility = Visibility.Visible;
            col_invType.Visibility = Visibility.Visible;
            col_invTypeNumber.Visibility = Visibility.Visible;
            col_agentType.Visibility = Visibility.Visible;
            col_agent.Visibility = Visibility.Visible;
            col_agentTypeAgent.Visibility = Visibility.Visible;
            col_MaxCollect.Visibility = Visibility.Visible;
            col_MaxCollect.Visibility = Visibility.Visible;
        }
        private void showSelectedTabColumn()
        {
            showAllColumn();
            if (selectedFatherTab == 0)
            {
                if (selectedStockTab == 0)
                {
                    col_itemUnits.Visibility = Visibility.Hidden;
                    col_section.Visibility = Visibility.Hidden;
                    col_location.Visibility = Visibility.Hidden;
                    col_invNumber.Visibility = Visibility.Hidden;
                    col_invType.Visibility = Visibility.Hidden;
                    col_invTypeNumber.Visibility = Visibility.Hidden;
                    col_agentType.Visibility = Visibility.Hidden;
                    col_agent.Visibility = Visibility.Hidden;
                    col_agentTypeAgent.Visibility = Visibility.Hidden;
                    col_MaxCollect.Visibility = Visibility.Hidden;
                    col_MinCollect.Visibility = Visibility.Hidden;
                }
                else if (selectedStockTab == 1)
                {
                    showAllColumn();
                    col_item.Visibility = Visibility.Hidden;
                    col_unit.Visibility = Visibility.Hidden;
                    col_locationSection.Visibility = Visibility.Hidden;

                    col_invNumber.Visibility = Visibility.Hidden;
                    col_invType.Visibility = Visibility.Hidden;
                    col_invTypeNumber.Visibility = Visibility.Hidden;
                    col_agentType.Visibility = Visibility.Hidden;
                    col_agent.Visibility = Visibility.Hidden;
                    col_agentTypeAgent.Visibility = Visibility.Hidden;
                    col_MaxCollect.Visibility = Visibility.Hidden;
                    col_MinCollect.Visibility = Visibility.Hidden;
                }
                else if (selectedStockTab == 2)
                {
                    col_endDate.Visibility = Visibility.Hidden;
                    col_startDate.Visibility = Visibility.Hidden;
                    col_locationSection.Visibility = Visibility.Hidden;
                    col_location.Visibility = Visibility.Hidden;
                    col_section.Visibility = Visibility.Hidden;
                    col_stockCost.Visibility = Visibility.Hidden;
                    col_itemUnits.Visibility = Visibility.Hidden;
                    col_invNumber.Visibility = Visibility.Hidden;
                    col_invType.Visibility = Visibility.Hidden;
                    col_invTypeNumber.Visibility = Visibility.Hidden;
                    col_agentType.Visibility = Visibility.Hidden;
                    col_agent.Visibility = Visibility.Hidden;
                    col_agentTypeAgent.Visibility = Visibility.Hidden;
                    col_Min.Visibility = Visibility.Hidden;
                    col_Max.Visibility = Visibility.Hidden;

                }

            }
            else if (selectedFatherTab == 1)
            {
                if (selectedExternalTab == 0)
                {
                    col_locationSection.Visibility = Visibility.Hidden;
                    col_location.Visibility = Visibility.Hidden;
                    col_section.Visibility = Visibility.Hidden;
                    col_startDate.Visibility = Visibility.Hidden;
                    col_endDate.Visibility = Visibility.Hidden;
                    col_Min.Visibility = Visibility.Hidden;
                    col_Max.Visibility = Visibility.Hidden;
                    col_stockCost.Visibility = Visibility.Hidden;
                    col_itemUnits.Visibility = Visibility.Hidden;
                    col_invType.Visibility = Visibility.Hidden;
                    col_invNumber.Visibility = Visibility.Hidden;
                    col_agentType.Visibility = Visibility.Hidden;
                    col_agent.Visibility = Visibility.Hidden;
                    col_MaxCollect.Visibility = Visibility.Hidden;
                    col_MinCollect.Visibility = Visibility.Hidden;
                }
                else if (selectedExternalTab == 1)
                {
                    col_locationSection.Visibility = Visibility.Hidden;
                    col_location.Visibility = Visibility.Hidden;
                    col_section.Visibility = Visibility.Hidden;
                    col_startDate.Visibility = Visibility.Hidden;
                    col_endDate.Visibility = Visibility.Hidden;
                    col_Min.Visibility = Visibility.Hidden;
                    col_Max.Visibility = Visibility.Hidden;
                    col_stockCost.Visibility = Visibility.Hidden;
                    col_invType.Visibility = Visibility.Hidden;
                    col_invNumber.Visibility = Visibility.Hidden;
                    col_agentTypeAgent.Visibility = Visibility.Hidden;
                    col_item.Visibility = Visibility.Hidden;
                    col_unit.Visibility = Visibility.Hidden;
                    col_MaxCollect.Visibility = Visibility.Hidden;
                    col_MinCollect.Visibility = Visibility.Hidden;
                }
                else if (selectedExternalTab == 2)
                {
                    col_locationSection.Visibility = Visibility.Hidden;
                    col_location.Visibility = Visibility.Hidden;
                    col_section.Visibility = Visibility.Hidden;
                    col_startDate.Visibility = Visibility.Hidden;
                    col_endDate.Visibility = Visibility.Hidden;
                    col_Min.Visibility = Visibility.Hidden;
                    col_Max.Visibility = Visibility.Hidden;
                    col_stockCost.Visibility = Visibility.Hidden;
                    col_invTypeNumber.Visibility = Visibility.Hidden;
                    col_agentType.Visibility = Visibility.Hidden;
                    col_agent.Visibility = Visibility.Hidden;
                    col_item.Visibility = Visibility.Hidden;
                    col_unit.Visibility = Visibility.Hidden;
                    col_MaxCollect.Visibility = Visibility.Hidden;
                    col_MinCollect.Visibility = Visibility.Hidden;
                }
            }
            #endregion

        }
    }
}


#endregion
#endregion
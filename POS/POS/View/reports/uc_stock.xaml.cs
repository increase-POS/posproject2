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
    public partial class uc_stock : UserControl
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                inventory = await statisticModel.GetInventory();
                falls = await statisticModel.GetInventoryItems();
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



                fillComboBranches(cb_branchesItem);
                fillComboItems(cb_branchesItem, cb_itemsItem);
                fillComboUnits(cb_itemsItem, cb_unitsItem);
                fillComboSection();
                fillComboLoaction();
                fillComboItems(cb_branchesCollect, cb_itemsCollect);
                fillComboUnits(cb_itemsCollect, cb_unitsCollect);


                temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
                dgStock.ItemsSource = temp;
                fillPieChart();

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

        public uc_stock()
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
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            grid_byItem.Visibility = Visibility.Hidden;
            grid_byLocation.Visibility = Visibility.Hidden;
            grid_collect.Visibility = Visibility.Hidden;


            bdr_item.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_location.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_collect.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));


            path_item.Fill = Brushes.White;
            path_location.Fill = Brushes.White;
            path_collect.Fill = Brushes.White;

        }



        private void isEnabledButtons()
        {
            btn_item.IsEnabled = true;
            btn_location.IsEnabled = true;
            btn_collect.IsEnabled = true;

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


        private void cb_branchesItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_itemsItem.IsEnabled = true;
                chk_allItemsItem.IsEnabled = true;
                cb_unitsItem.IsEnabled = false;
                cb_unitsItem.SelectedItem = null;
                chk_allUnitsItem.IsEnabled = false;
                fillComboItems(cb_branchesItem, cb_itemsItem);
                temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void cb_itemsItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_unitsItem.IsEnabled = true;
                chk_allUnitsItem.IsEnabled = true;
                fillComboUnits(cb_itemsItem, cb_unitsItem);
                temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void cb_unitsItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void chk_allBranchesItem_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_branchesItem.IsEnabled = false;
                cb_branchesItem.SelectedItem = null;
                cb_itemsItem.IsEnabled = true;
                chk_allItemsItem.IsEnabled = true;
                cb_itemsItem.SelectedItem = null;
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

        private void chk_allBranchesItem_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_itemsItem.IsEnabled = false;
                cb_branchesItem.IsEnabled = true;

                chk_allUnitsItem.IsEnabled = false;
                chk_allItemsItem.IsEnabled = false;

                chk_allUnitsItem.IsChecked = false;
                chk_allItemsItem.IsChecked = false;
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

        private void chk_allItemsItem_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_itemsItem.IsEnabled = false;

                cb_unitsItem.IsEnabled = true;
                chk_allUnitsItem.IsEnabled = true;
                cb_itemsItem.SelectedItem = null;
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

        private void chk_allItemsItem_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_itemsItem.IsEnabled = true;
                cb_unitsItem.IsEnabled = false;
                cb_unitsItem.SelectedItem = null;
                chk_allUnitsItem.IsEnabled = false;
                chk_allUnitsItem.IsChecked = false;
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

        private void chk_allUnitsItem_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_unitsItem.IsEnabled = false;
                cb_unitsItem.SelectedItem = null;
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

        private void chk_allUnitsItem_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_unitsItem.IsEnabled = true;
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

        private void chk_expireDateItem_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                dp_endDateItem.IsEnabled = true;
                dp_startDateItem.IsEnabled = true;
                temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void chk_expireDateItem_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                dp_endDateItem.IsEnabled = false;
                dp_startDateItem.IsEnabled = false;
                temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void dp_startDateItem_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void dp_endDateItem_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void cb_branchesLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_sectionsLocation.IsEnabled = true;
                chk_allSectionsLocation.IsEnabled = true;
                cb_locationsLocation.IsEnabled = false;
                cb_locationsLocation.SelectedItem = null;
                chk_allLocationsLocation.IsEnabled = false;
                fillComboSection();
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void cb_sectionsLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_locationsLocation.IsEnabled = true;
                chk_allLocationsLocation.IsEnabled = true;
                fillComboLoaction();
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void cb_locationsLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void chk_allBranchesLocation_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_branchesLocation.IsEnabled = false;
                cb_branchesLocation.SelectedItem = null;
                cb_sectionsLocation.IsEnabled = true;
                chk_allSectionsLocation.IsEnabled = true;
                cb_sectionsLocation.SelectedItem = null;
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

        private void chk_allBranchesLocation_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_sectionsLocation.IsEnabled = false;
                cb_branchesLocation.IsEnabled = true;
                chk_allLocationsLocation.IsEnabled = false;
                chk_allSectionsLocation.IsEnabled = false;
                chk_allLocationsLocation.IsChecked = false;
                chk_allSectionsLocation.IsChecked = false;
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

        private void chk_allSectionsLocation_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_sectionsLocation.IsEnabled = false;
                cb_locationsLocation.IsEnabled = true;
                chk_allLocationsLocation.IsEnabled = true;
                cb_sectionsLocation.SelectedItem = null;
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

        private void chk_allSectionsLocation_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_sectionsLocation.IsEnabled = true;
                cb_locationsLocation.IsEnabled = false;
                cb_locationsLocation.SelectedItem = null;
                chk_allSectionsLocation.IsEnabled = false;
                chk_allLocationsLocation.IsEnabled = false;
                chk_allSectionsLocation.IsChecked = false;
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

        private void chk_allLocationsLocation_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_locationsLocation.IsEnabled = false;
                cb_locationsLocation.SelectedItem = null;
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

        private void chk_allLocationsLocation_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_locationsLocation.IsEnabled = true;
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

        private void chk_expireDateLocation_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                dp_endDateLocation.IsEnabled = true;
                dp_startDateLocation.IsEnabled = true;
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void chk_expireDateLocation_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                dp_endDateLocation.IsEnabled = false;
                dp_startDateLocation.IsEnabled = false;
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void dp_endDateLocation_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void dp_startDateLocation_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void cb_branchesCollect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_itemsCollect.IsEnabled = true;
                chk_allItemsCollect.IsEnabled = true;
                cb_unitsCollect.IsEnabled = false;
                cb_unitsCollect.SelectedItem = null;
                chk_allUnitsCollect.IsEnabled = false;
                fillComboItems(cb_branchesCollect, cb_itemsCollect);
                temp = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null)
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
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void cb_itemsCollect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_unitsCollect.IsEnabled = true;
                chk_allUnitsCollect.IsEnabled = true;
                fillComboUnits(cb_itemsCollect, cb_unitsCollect);
                temp = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null).GroupBy(x => new { x.branchId, x.itemUnitId })
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
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void cb_unitsCollect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null).GroupBy(x => new { x.branchId, x.itemUnitId })
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
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void chk_allBranchesCollect_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_branchesCollect.IsEnabled = false;
                cb_branchesCollect.SelectedItem = null;
                cb_itemsCollect.IsEnabled = true;
                chk_allItemsCollect.IsEnabled = true;
                cb_itemsCollect.SelectedItem = null;
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

        private void chk_allBranchesCollect_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_itemsCollect.IsEnabled = false;
                cb_branchesCollect.IsEnabled = true;
                chk_allUnitsCollect.IsEnabled = false;
                chk_allItemsCollect.IsEnabled = false;
                chk_allUnitsCollect.IsChecked = false;
                chk_allItemsCollect.IsChecked = false;
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

        private void chk_allItemsCollect_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_itemsCollect.IsEnabled = false;
                cb_unitsCollect.IsEnabled = true;
                chk_allUnitsCollect.IsEnabled = true;
                cb_itemsCollect.SelectedItem = null;
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

        private void chk_allItemsCollect_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_itemsCollect.IsEnabled = true;
                cb_unitsCollect.IsEnabled = false;
                cb_unitsCollect.SelectedItem = null;
                chk_allUnitsCollect.IsEnabled = false;
                chk_allUnitsCollect.IsChecked = false;
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

        private void chk_allUnitsCollect_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_unitsCollect.IsEnabled = false;
                cb_unitsCollect.SelectedItem = null;
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

        private void chk_allUnitsCollect_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_unitsCollect.IsEnabled = true;
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

        IEnumerable<Storage> temp = null;
        private void Btn_item_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                selectedStockTab = 0;
                txt_search.Text = "";
                paint();
                isEnabledButtonsStock();
                btn_item.IsEnabled = false;
                btn_item.Opacity = 1;
                grid_byItem.Visibility = Visibility.Visible;
                path_item.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                bdr_item.Background = Brushes.White;

                temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);
                dgStock.ItemsSource = temp;
                showSelectedTabColumn();
                fillPieChart();
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

        private void btn_location_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                selectedStockTab = 1;
                txt_search.Text = "";
                paint();
                isEnabledButtonsStock();
                fillComboBranches(cb_branchesLocation);
                btn_location.IsEnabled = false;
                btn_location.Opacity = 1;
                grid_byLocation.Visibility = Visibility.Visible;
                path_location.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                bdr_location.Background = Brushes.White;
                showSelectedTabColumn();


                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);
                dgStock.ItemsSource = temp;
                fillPieChart();
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

        private void btn_collect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                selectedStockTab = 2;
                txt_search.Text = "";
                paint();
                isEnabledButtonsStock();
                fillComboBranches(cb_branchesCollect);
                btn_collect.IsEnabled = false;
                btn_collect.Opacity = 1;
                grid_collect.Visibility = Visibility.Visible;
                path_collect.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                bdr_collect.Background = Brushes.White;
                showSelectedTabColumn();


                temp = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null).GroupBy(x => new { x.branchId, x.itemUnitId })
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
                dgStock.ItemsSource = temp;
                fillPieChart();
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


        private void isEnabledButtonsStock()
        {
            btn_item.IsEnabled = true;
            btn_location.IsEnabled = true;
            btn_collect.IsEnabled = true;
        }

        public void paintStockChilds()
        {

        }

        private void fillRowChart(IEnumerable<Storage> List)
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<decimal> pTemp = null;

            temp = List;

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

        private void fillColumnChart(IEnumerable<Storage> List)
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();

            temp = List;

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
            fillRowChart(temp);
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


        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (selectedStockTab == 0)
                {
                    temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem)
                        .Where(s => (s.branchName.Contains(txt_search.Text) ||
           s.itemName.Contains(txt_search.Text) ||
           s.unitName.Contains(txt_search.Text) ||
           s.Secname.Contains(txt_search.Text) ||
           s.LoactionName.Contains(txt_search.Text)
           ));
                    dgStock.ItemsSource = temp;
                }
                else if (selectedStockTab == 1)
                {

                    temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation, chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation)

                   .Where(s => (s.branchName.Contains(txt_search.Text) ||
      s.itemName.Contains(txt_search.Text) ||
      s.unitName.Contains(txt_search.Text) ||
      s.Secname.Contains(txt_search.Text) ||
      s.LoactionName.Contains(txt_search.Text)
      ));
                    dgStock.ItemsSource = temp;
                }


                else
                {
                    temp = fillList(storages, cb_branchesCollect, cb_itemsCollect, cb_unitsCollect, null, null, chk_allBranchesCollect, chk_allItemsCollect, chk_allUnitsCollect, null).GroupBy(x => new { x.branchId, x.itemUnitId })
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
                   })
                       .Where(s => (s.branchName.Contains(txt_search.Text) ||
           s.itemName.Contains(txt_search.Text) ||
           s.unitName.Contains(txt_search.Text)

           ));
                    dgStock.ItemsSource = temp;
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

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                txt_search.Text = "";
                if (selectedStockTab == 0)
                {
                    cb_branchesItem.SelectedItem = null;
                    cb_itemsItem.SelectedItem = null;
                    cb_unitsItem.SelectedItem = null;
                    chk_allBranchesItem.IsChecked = false;
                    chk_allItemsItem.IsChecked = false;
                    chk_allUnitsItem.IsChecked = false;
                    chk_expireDateItem.IsChecked = false;
                    dp_endDateItem.SelectedDate = null;
                    dp_startDateItem.SelectedDate = null;
                }
                else if (selectedStockTab == 1)
                {
                    cb_branchesLocation.SelectedItem = null;
                    cb_locationsLocation.SelectedItem = null;
                    cb_sectionsLocation.SelectedItem = null;
                    chk_allBranchesLocation.IsChecked = false;
                    chk_allLocationsLocation.IsChecked = false;
                    chk_allSectionsLocation.IsChecked = false;
                    chk_expireDateLocation.IsChecked = false;
                    dp_endDateLocation.SelectedDate = null;
                    dp_startDateLocation.SelectedDate = null;
                }
                else
                {
                    cb_branchesCollect.SelectedItem = null;
                    cb_itemsCollect.SelectedItem = null;
                    cb_unitsCollect.SelectedItem = null;
                    chk_allBranchesCollect.IsChecked = false;
                    chk_allItemsCollect.IsChecked = false;
                    chk_allUnitsCollect.IsChecked = false;
                    chk_expireDateCollect.IsChecked = false;
                    dp_endDateCollect.SelectedDate = null;
                    dp_startDateCollect.SelectedDate = null;
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
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath = "";
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    if (selectedStockTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArItem.rdlc";
                    }
                    else if (selectedStockTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArLocation.rdlc";
                    }
                    else if (selectedStockTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArCollect.rdlc";
                    }
                }
                else
                {
                    if (selectedStockTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\En\Item.rdlc";
                    }
                    else if (selectedStockTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\En\Location.rdlc";
                    }
                    else if (selectedStockTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\En\Collect.rdlc";
                    }
                }
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.storage(temp, rep, reppath);
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
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath = "";
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    if (selectedStockTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArItem.rdlc";
                    }
                    else if (selectedStockTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArLocation.rdlc";
                    }
                    else if (selectedStockTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArCollect.rdlc";
                    }
                }
                else
                {
                    if (selectedStockTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\En\Item.rdlc";
                    }
                    else if (selectedStockTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\En\Location.rdlc";
                    }
                    else if (selectedStockTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\En\Collect.rdlc";
                    }
                }
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.storage(temp, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();
                LocalReportExtensions.PrintToPrinter(rep);

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
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                Thread t1 = new Thread(() =>
{
    List<ReportParameter> paramarr = new List<ReportParameter>();

    string addpath = "";
    bool isArabic = ReportCls.checkLang();
    if (isArabic)
    {
        if (selectedStockTab == 0)
        {
            addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArItem.rdlc";
        }
        else if (selectedStockTab == 1)
        {
            addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArLocation.rdlc";
        }
        else if (selectedStockTab == 2)
        {
            addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArCollect.rdlc";
        }
    }
    else
    {
        if (selectedStockTab == 0)
        {
            addpath = @"\Reports\StatisticReport\Storage\Stock\En\Item.rdlc";
        }
        else if (selectedStockTab == 1)
        {
            addpath = @"\Reports\StatisticReport\Storage\Stock\En\Location.rdlc";
        }
        else if (selectedStockTab == 2)
        {
            addpath = @"\Reports\StatisticReport\Storage\Stock\En\Collect.rdlc";
        }
    }
    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

    ReportCls.checkLang();

    clsReports.storage(temp, rep, reppath);
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
                Window.GetWindow(this).Opacity = 0.2;
                string pdfpath = "";

                List<ReportParameter> paramarr = new List<ReportParameter>();


                //
                pdfpath = @"\Thumb\report\temp.pdf";
                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                string addpath = "";
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    if (selectedStockTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArItem.rdlc";
                    }
                    else if (selectedStockTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArLocation.rdlc";
                    }
                    else if (selectedStockTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArCollect.rdlc";
                    }
                }
                else
                {
                    if (selectedStockTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\En\Item.rdlc";
                    }
                    else if (selectedStockTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\En\Location.rdlc";
                    }
                    else if (selectedStockTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\Stock\En\Collect.rdlc";
                    }
                }
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.storage(temp, rep, reppath);
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
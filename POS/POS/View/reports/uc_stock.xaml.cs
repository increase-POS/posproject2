﻿using LiveCharts;
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
using System.Reflection;
using System.Resources;

namespace POS.View.reports
{
    public partial class uc_stock : UserControl
    {
        List<Storage> storages;

        IEnumerable<Storage> storeLst;

        Statistics statisticModel = new Statistics();

        List<Branch> comboBranches;
        Branch branchModel = new Branch();

        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

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

                storages = await statisticModel.GetStorage((int)MainWindow.branchID, (int)MainWindow.userID);

                comboItems = statisticModel.getItemCombo(storages);
                comboUnits = statisticModel.getUnitCombo(storages);
                comboSection = statisticModel.getSectionCombo(storages);
                comboLocation = statisticModel.getLocationCombo(storages);

                chk_allBranchesItem.IsChecked = true;
                chk_allBranchesLocation.IsChecked = true;
                chk_allBranchesCollect.IsChecked = true;

                chk_allItemsItem.IsChecked = true;
                chk_allSectionsLocation.IsChecked = true;
                chk_allItemsCollect.IsChecked = true;

                chk_allUnitsItem.IsChecked = true;
                chk_allLocationsLocation.IsChecked = true;
                chk_allUnitsCollect.IsChecked = true;

                Btn_item_Click(btn_item, null);

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
            tt_item.Content = MainWindow.resourcemanager.GetString("trItems");
            tt_location.Content = MainWindow.resourcemanager.GetString("trLocations");
            tt_collect.Content = MainWindow.resourcemanager.GetString("trCollect");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branchesItem, MainWindow.resourcemanager.GetString("trBranch/StoreHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_itemsItem, MainWindow.resourcemanager.GetString("trItemHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_unitsItem, MainWindow.resourcemanager.GetString("trUnitHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_startDateItem, MainWindow.resourcemanager.GetString("trStartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_endDateItem, MainWindow.resourcemanager.GetString("trEndDateHint"));

            chk_expireDateItem.Content = MainWindow.resourcemanager.GetString("trAll");
            chk_allBranchesItem.Content = MainWindow.resourcemanager.GetString("trAll");
            chk_allItemsItem.Content = MainWindow.resourcemanager.GetString("trAll");
            chk_allUnitsItem.Content = MainWindow.resourcemanager.GetString("trAll");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");

            col_branch.Header = MainWindow.resourcemanager.GetString("trBranch");
            col_section.Header = MainWindow.resourcemanager.GetString("trSection");
            col_location.Header = MainWindow.resourcemanager.GetString("trLocation");
            col_itemUnits.Header = MainWindow.resourcemanager.GetString("trItemUnit");
            col_item.Header = MainWindow.resourcemanager.GetString("trItem");
            col_unit.Header = MainWindow.resourcemanager.GetString("trUnit");
            col_locationSection.Header = MainWindow.resourcemanager.GetString("trSectionLocation");
            col_startDate.Header = MainWindow.resourcemanager.GetString("trStartDate");
            col_endDate.Header = MainWindow.resourcemanager.GetString("trEndDate");
            col_Min.Header = MainWindow.resourcemanager.GetString("trMin");//??
            col_Max.Header = MainWindow.resourcemanager.GetString("trMax");//??
            col_MinCollect.Header = MainWindow.resourcemanager.GetString("trMinCollect");//??
            col_MaxCollect.Header = MainWindow.resourcemanager.GetString("trMaxCollect");//??
            col_stockCost.Header = MainWindow.resourcemanager.GetString("trCost");
            col_quantity.Header = MainWindow.resourcemanager.GetString("trQTR");

            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

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
            //bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

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
            storeLst = result;
            return result;
        }


        private void cb_branchesItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillComboItems(cb_branchesItem, cb_itemsItem);
                chk_allItemsItem.IsChecked = true;
                chk_allItemsItem.IsEnabled = true;

                fillEvents();

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

                chk_allUnitsItem.IsEnabled = true;
                chk_allUnitsItem.IsChecked = true;
                fillComboUnits(cb_itemsItem, cb_unitsItem);

                fillEvents();

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

                cb_branchesItem.IsEnabled = true;

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

                fillEvents();

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

                fillEvents();

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

                chk_allSectionsLocation.IsEnabled = true;
                chk_allSectionsLocation.IsChecked = true;
                fillComboSection();

                fillEvents();

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

                chk_allLocationsLocation.IsEnabled = true;
                chk_allLocationsLocation.IsChecked = true;
                fillComboLoaction();

                fillEvents();

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

                cb_branchesLocation.IsEnabled = true;

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

                fillEvents();

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

                fillEvents();

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

                chk_allItemsCollect.IsEnabled = true;
                chk_allItemsCollect.IsChecked = true;
                fillComboItems(cb_branchesCollect, cb_itemsCollect);
                fillEvents();

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

                chk_allUnitsCollect.IsEnabled = true;
                chk_allUnitsCollect.IsChecked = true;
                fillComboUnits(cb_itemsCollect, cb_unitsCollect);

                fillEvents();

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

                cb_branchesCollect.IsEnabled = true;

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

        private void fillEventsCall(object sender)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillEvents();

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

        private  void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEventsCall(sender);
        }
        IEnumerable<Storage> temp = null;
        private async void Btn_item_Click(object sender, RoutedEventArgs e)
        {//items
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

                //fillComboBranches(cb_branchesItem);
                await SectionData.fillBranchesWithoutMain(cb_branchesItem);
                chk_allBranchesItem.IsChecked = true;

                selectedStockTab = 0;
                txt_search.Text = "";

                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_item);
                grid_byItem.Visibility = Visibility.Visible;
                path_item.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                fillEvents();

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

        private async void btn_location_Click(object sender, RoutedEventArgs e)
        {//location
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                selectedStockTab = 1;
                txt_search.Text = "";

                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_location);
                grid_byLocation.Visibility = Visibility.Visible;
                path_location.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                //fillComboBranches(cb_branchesLocation);
                await SectionData.fillBranchesWithoutMain(cb_branchesLocation);
                chk_allBranchesLocation.IsChecked = true;

                fillEvents();

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

        private async void btn_collect_Click(object sender, RoutedEventArgs e)
        {//collect
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

                selectedStockTab = 2;
                txt_search.Text = "";

                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_collect);
                grid_collect.Visibility = Visibility.Visible;
                path_collect.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                //fillComboBranches(cb_branchesCollect);
                await SectionData.fillBranchesWithoutMain(cb_branchesCollect);

                showSelectedTabColumn();

                fillEvents();
                

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

        private void fillEvents()
        {
            if (selectedStockTab == 0)
                temp = fillList(storages, cb_branchesItem, cb_itemsItem, cb_unitsItem, dp_startDateItem, dp_endDateItem, chk_allBranchesItem, chk_allItemsItem, chk_allUnitsItem, chk_expireDateItem);

            else if (selectedStockTab == 1)
                temp = fillList(storages, cb_branchesLocation, cb_sectionsLocation, cb_locationsLocation, dp_startDateLocation, dp_endDateLocation, chk_allBranchesLocation,chk_allSectionsLocation, chk_allLocationsLocation, chk_expireDateLocation);

            else if(selectedStockTab == 2)
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
                   });
            }

            dgStock.ItemsSource = temp;

            txt_count.Text = dgStock.Items.Count.ToString();

            showSelectedTabColumn();

            fillColumnChart();
            fillPieChart();
            fillRowChart();
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
                Title = MainWindow.resourcemanager.GetString("trQuantity"),
                DataLabels = true,
            });
            DataContext = this;
            cartesianChart.Series = columnChartData;
            fillRowChart(temp);
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
            col_MaxCollect.Visibility = Visibility.Hidden;
            col_MinCollect.Visibility = Visibility.Hidden;
            
        }
        private void showSelectedTabColumn()
        {
            hideAllColumn();

            if (selectedStockTab == 0)
            {
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
                col_branch.Visibility = Visibility.Visible;
                col_item.Visibility = Visibility.Visible;
                col_unit.Visibility = Visibility.Visible;
                col_quantity.Visibility = Visibility.Visible;
                col_MinCollect.Visibility = Visibility.Visible;
                col_MaxCollect.Visibility = Visibility.Visible;
            }

        }

        private void fillRowChart()
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<decimal> pTemp = null;

            var result = storeLst.GroupBy(s => new { s.sectionId, s.locationId }).Select(s => new
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
            int xCount = 6;
            if (pTemp.Count() <= 6) xCount = pTemp.Count();
            for (int i = 0; i < xCount; i++)
            {
                purchase.Add(pTemp.ToList().Skip(i).FirstOrDefault());
                MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            if(pTemp.Count() > 6)
            {
                decimal d = 0;
                for (int i = 6; i < pTemp.Count(); i++)
                {
                    d = d + pTemp.ToList().Skip(i).FirstOrDefault();
                }
                if(d != 0)
                {
                    purchase.Add(d);
                    MyAxis.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
                }
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = purchase.AsChartValues(),
              Title = MainWindow.resourcemanager.GetString("trQuantity")

          });
            DataContext = this;
            rowChart.Series = rowChartData;
        }

        private void fillColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();

            var result = storeLst.GroupBy(s => new { s.itemId, s.unitId }).Select(s => new Storage
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

            int xCount = 6;
            if (cc.Count() <= 6) xCount = cc.Count();
            for (int i = 0; i < xCount; i++)
            {
                cP.Add(cc.ToList().Select(jj => (decimal)jj.quantity).Skip(i).FirstOrDefault());
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            if(cc.Count() > 6)
            {
                decimal d = 0;
                for (int i = 6 ; i < cc.Count(); i++)
                {
                    d = d + cc.ToList().Select(jj => (decimal)jj.quantity).Skip(i).FirstOrDefault();
                }
                if(d != 0)
                {
                    cP.Add(d);
                    axcolumn.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
                }
            }
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cP.AsChartValues(),
                Title = MainWindow.resourcemanager.GetString("trQuantity"),
                DataLabels = true,
            });
            DataContext = this;
            cartesianChart.Series = columnChartData;
        }

        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            List<decimal> x = new List<decimal>();
            titles.Clear();

            var titleTemp = storeLst.GroupBy(m => m.branchName);

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
                          Title = MainWindow.resourcemanager.GetString("trOthers"),
                          DataLabels = true,
                      }
                  );
                    break;
                }

            }
            chart1.Series = piechartData;
        }


        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (selectedStockTab == 0)
                {
                    temp = storeLst
                        .Where(s => (s.branchName.Contains(txt_search.Text) ||
                       s.itemName.Contains(txt_search.Text) ||
                       s.unitName.Contains(txt_search.Text) ||
                       s.Secname.Contains(txt_search.Text) ||
                       s.LoactionName.Contains(txt_search.Text)
                       ));
                    dgStock.ItemsSource = temp;
                    txt_count.Text = dgStock.Items.Count.ToString();
                }
                else if (selectedStockTab == 1)
                {

                    temp = storeLst

                      .Where(s => (s.branchName.Contains(txt_search.Text) ||
                      s.itemName.Contains(txt_search.Text) ||
                      s.unitName.Contains(txt_search.Text) ||
                      s.Secname.Contains(txt_search.Text) ||
                      s.LoactionName.Contains(txt_search.Text)
                      ));
                    dgStock.ItemsSource = temp;
                    txt_count.Text = dgStock.Items.Count.ToString();
                }


                else
                {
                    temp = storeLst
                       .Where(s => (s.branchName.Contains(txt_search.Text) ||
           s.itemName.Contains(txt_search.Text) ||
           s.unitName.Contains(txt_search.Text)

           ));
                    dgStock.ItemsSource = temp;
                    storeLst = temp;
                    txt_count.Text = dgStock.Items.Count.ToString();
                    fillColumnChart();
                    fillPieChart();
                    fillRowChart();
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
        {//refresh
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
                    chk_allBranchesItem.IsChecked = true;
                    chk_expireDateItem.IsChecked = false;
                    dp_endDateItem.SelectedDate = null;
                    dp_startDateItem.SelectedDate = null;
                }
                else if (selectedStockTab == 1)
                {
                    cb_branchesLocation.SelectedItem = null;
                    cb_locationsLocation.SelectedItem = null;
                    cb_sectionsLocation.SelectedItem = null;
                    chk_allBranchesLocation.IsChecked = true;
                    chk_expireDateLocation.IsChecked = false;
                    dp_endDateLocation.SelectedDate = null;
                    dp_startDateLocation.SelectedDate = null;
                }
                else
                {
                    cb_branchesCollect.SelectedItem = null;
                    cb_itemsCollect.SelectedItem = null;
                    cb_unitsCollect.SelectedItem = null;
                    chk_allBranchesCollect.IsChecked = true;
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
      
        public void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath = "";
            string firstTitle = "stock";
            string secondTitle = "";
            string subTitle = "";
            string Title = "";
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                if (selectedStockTab == 0)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArItem.rdlc";
                    secondTitle = "items";
                }
                else if (selectedStockTab == 1)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArLocation.rdlc";
                    secondTitle = "location";
                }
                else if (selectedStockTab == 2)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Stock\Ar\ArCollect.rdlc";
                    secondTitle = "collect";
                }
            }
            else
            {
                if (selectedStockTab == 0)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Stock\En\Item.rdlc";
                    secondTitle = "items";
                }
                else if (selectedStockTab == 1)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Stock\En\Location.rdlc";
                    secondTitle = "location";
                }
                else if (selectedStockTab == 2)
                {
                    addpath = @"\Reports\StatisticReport\Storage\Stock\En\Collect.rdlc";
                    secondTitle = "collect";
                }
            }
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();
            subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
            Title = MainWindow.resourcemanagerreport.GetString("trStorageReport") + " / " + subTitle;
            paramarr.Add(new ReportParameter("trTitle", Title));

            clsReports.storageStock(temp, rep, reppath, paramarr);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();

        }
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region

                BuildReport();
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
                BuildReport();
                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
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

         

                pdfpath = @"\Thumb\report\temp.pdf";
                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                BuildReport();

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

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}
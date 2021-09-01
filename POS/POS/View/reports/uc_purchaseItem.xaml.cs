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
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.Threading;
using POS.View.purchases;
using System.Globalization;

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for uc_purchaseItem.xaml
    /// </summary>
    public partial class uc_purchaseItem : UserControl
    { //prin & pdf
        private int selectedTab = 0;
        Statistics statisticModel = new Statistics();
        List<ItemTransferInvoice> Items;
        List<ItemTransferInvoice> rowChartItems;

        //for combo boxes
        /*************************/
        Branch selectedBranch;
        ItemUnitCombo selectedItem;

        List<Branch> comboBranches;
        List<ItemUnitCombo> itemUnitCombos;

        ObservableCollection<Branch> comboBrachTemp = new ObservableCollection<Branch>();
        ObservableCollection<ItemUnitCombo> comboItemTemp = new ObservableCollection<ItemUnitCombo>();

        ObservableCollection<Branch> dynamicComboBranches;
        ObservableCollection<ItemUnitCombo> dynamicComboItem;

        Branch branchModel = new Branch();
        Item itemModel = new Item();
        /*************************/

        ObservableCollection<int> selectedBranchId = new ObservableCollection<int>();

        ObservableCollection<int> selectedItemId = new ObservableCollection<int>();
        public uc_purchaseItem()
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
        {
            Items = await statisticModel.GetPuritem();
            rowChartItems = await statisticModel.GetPuritem();

            comboBranches = await branchModel.GetAllWithoutMain("b");

            itemUnitCombos = statisticModel.GetIUComboList(Items);

            dynamicComboBranches = new ObservableCollection<Branch>(comboBranches);
            dynamicComboItem = new ObservableCollection<ItemUnitCombo>(itemUnitCombos);

            fillComboBranches(cb_collect);
            fillComboItemsBranches(cb_ItemsBranches);
            fillComboItems();

            chk_itemInvoice.IsChecked = true;

        }

        private void fillComboBranches(ComboBox cb)
        {
            cb.SelectedValuePath = "branchId";
            cb.DisplayMemberPath = "name";
            cb.ItemsSource = dynamicComboBranches;
        }
        private void fillComboItemsBranches(ComboBox cb)
        {
            cb.SelectedValuePath = "branchId";
            cb.DisplayMemberPath = "name";
            cb.ItemsSource = comboBranches;
        }

        private void fillComboItems()
        {
            cb_Items.SelectedValuePath = "itemUnitId";
            cb_Items.DisplayMemberPath = "itemUnitName";
            cb_Items.ItemsSource = dynamicComboItem;
        }

        public void fillItemsEvent()
        {
            dgInvoice.ItemsSource = fillList(Items, cb_ItemsBranches, cb_Items, chk_itemInvoice, chk_itemReturn, dp_ItemStartDate, dp_ItemEndDate)
                .Where(j => (selectedItemId.Count != 0 ? selectedItemId.Contains((int)j.ITitemUnitId) : true));
            fillPieChart(cb_Items, selectedItemId);
            fillColumnChart(cb_Items, selectedItemId);
            fillRowChart(cb_Items, selectedItemId);
        }

        public void fillCollectEvent()
        {
            dgInvoice.ItemsSource = fillCollectListBranch(Items, dp_collectStartDate, dp_collectEndDate)
                .Where(j => (selectedBranchId.Count != 0 ? selectedBranchId.Contains((int)j.branchCreatorId) : true));
            fillPieChartCollect(cb_collect, selectedBranchId);
            fillColumnChartCollect(cb_collect, selectedBranchId);
            fillRowChartCollect(cb_collect, selectedBranchId);
        }

        public void fillCollectEventAll()
        {
            dgInvoice.ItemsSource = fillCollectListAll(Items, dp_collectStartDate, dp_collectEndDate);
            fillPieChartCollect(cb_collect, selectedBranchId);
            fillColumnChartCollect(cb_collect, selectedBranchId);
            fillRowChartCollect(cb_collect, selectedBranchId);
        }

        private void btn_items_Click(object sender, RoutedEventArgs e)
        {
            selectedTab = 0;
            txt_search.Text = "";
            ReportsHelp.showSelectedStack(grid_stacks, stk_tagsItems);
            path_collect.Fill = Brushes.White;
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);
            ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_items);
            path_items.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            ReportsHelp.showTabControlGrid(grid_father, grid_items);
            ReportsHelp.isEnabledButtons(grid_tabControl, btn_items);
            ReportsHelp.hideAllColumns(dgInvoice);
            col_number.Visibility = Visibility.Visible;
            col_branch.Visibility = Visibility.Visible;
            col_item.Visibility = Visibility.Visible;
            col_unit.Visibility = Visibility.Visible;
            col_itQuantity.Visibility = Visibility.Visible;
            col_price.Visibility = Visibility.Visible;
            col_total.Visibility = Visibility.Visible;

            fillItemsEvent();
        }

        private void Btn_collect_Click(object sender, RoutedEventArgs e)
        {
            selectedTab = 1;
            txt_search.Text = "";

            path_items.Fill = Brushes.White;
            path_collect.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            ReportsHelp.showSelectedStack(grid_stacks, stk_tagsBranches);
            ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_collect);
            ReportsHelp.showTabControlGrid(grid_father, grid_collect);
            ReportsHelp.isEnabledButtons(grid_tabControl, btn_collect);
            ReportsHelp.hideAllColumns(dgInvoice);

            col_branch.Visibility = Visibility.Visible;
            col_item.Visibility = Visibility.Visible;
            col_unit.Visibility = Visibility.Visible;
            col_itQuantity.Visibility = Visibility.Visible;
            col_invCount.Visibility = Visibility.Visible;
            col_avg.Visibility = Visibility.Visible;

            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
            else
            {
                fillCollectEvent();
            }
        }

        #region Items Events
        private void Chip_OnDeleteItemClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            stk_tagsItems.Children.Remove(currentChip);
            var m = comboItemTemp.Where(j => j.itemUnitId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
            dynamicComboItem.Add(m.FirstOrDefault());
            selectedItemId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedItemId.Count == 0)
            {
                cb_Items.SelectedItem = null;
            }
            fillItemsEvent();

        }

        private void cb_Items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_Items.SelectedItem != null)
            {
                if (stk_tagsItems.Children.Count < 5)
                {
                    selectedItem = cb_Items.SelectedItem as ItemUnitCombo;
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = selectedItem.itemUnitName,
                        Name = "btn" + selectedItem.itemUnitId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteItemClick;
                    stk_tagsItems.Children.Add(b);
                    comboItemTemp.Add(selectedItem);
                    selectedItemId.Add(selectedItem.itemUnitId);
                    dynamicComboItem.Remove(selectedItem);
                    fillItemsEvent();
                }
            }
        }

        private void chk_allItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main); if (cb_Items.IsEnabled == true)
                {
                    cb_Items.SelectedItem = null;
                    cb_Items.IsEnabled = false;
                    for (int i = 0; i < comboItemTemp.Count; i++)
                    {
                        dynamicComboItem.Add(comboItemTemp.Skip(i).FirstOrDefault());
                    }
                    comboItemTemp.Clear();
                    stk_tagsItems.Children.Clear();
                    selectedItemId.Clear();
                }
                else
                {
                    cb_Items.IsEnabled = true;
                }

                fillItemsEvent();
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

        private void chk_itemInvoice_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillItemsEvent();
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

        private void chk_itemInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillItemsEvent();
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

        private void chk_itemReturn_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillItemsEvent();
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

        private void chk_itemReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main); fillItemsEvent();
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

        private void chk_itemDrafs_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillItemsEvent();
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

        private void chk_itemDrafs_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main); fillItemsEvent();
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

        private void dp_ItemEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main); fillItemsEvent();
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

        private void dp_ItemStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main); fillItemsEvent();
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

        private void dt_ItemEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillItemsEvent();
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

        private void dt_itemStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillItemsEvent();
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

        private void Cb_ItemsBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillItemsEvent();
        }

        private void Chk_allBranchesItem_Checked(object sender, RoutedEventArgs e)
        {
            cb_ItemsBranches.SelectedItem = null;
            cb_ItemsBranches.IsEnabled = false;
        }

        private void Chk_allBranchesItem_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_ItemsBranches.IsEnabled = true;
        }

        private void Chk_allItems_Checked(object sender, RoutedEventArgs e)
        {
            cb_Items.SelectedItem = null;
            cb_Items.IsEnabled = false;
            for (int i = 0; i < comboItemTemp.Count; i++)
            {
                dynamicComboItem.Add(comboItemTemp.Skip(i).FirstOrDefault());
            }
            comboItemTemp.Clear();
            stk_tagsItems.Children.Clear();
            selectedItemId.Clear();
            fillItemsEvent();
        }

        private void Chk_allItems_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_Items.IsEnabled = true;
            fillItemsEvent();
        }
        #endregion

    

        #region Collect Events
        private void Chk_collectInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }

        private void Chk_collectInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }

        private void Chk_collectReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }

        private void Chk_collectReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }

        private void Chk_collectDrafs_Unchecked(object sender, RoutedEventArgs e)
        {
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }

        private void Chk_collectDrafs_Checked(object sender, RoutedEventArgs e)
        {
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }

        private void Dp_collectEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }

        private void Dp_collectStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }

        private void Chip_OnDeleteBranchClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            stk_tagsBranches.Children.Remove(currentChip);
            var m = comboBrachTemp.Where(j => j.branchId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
            dynamicComboBranches.Add(m.FirstOrDefault());
            selectedBranchId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedBranchId.Count == 0)
            {
                cb_collect.SelectedItem = null;
            }
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }

        private void Cb_collect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_collect.SelectedItem != null)
            {
                if (stk_tagsBranches.Children.Count < 5)
                {
                    selectedBranch = cb_collect.SelectedItem as Branch;
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = selectedBranch.name,
                        Name = "btn" + selectedBranch.branchId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteBranchClick;
                    stk_tagsBranches.Children.Add(b);
                    comboBrachTemp.Add(selectedBranch);
                    selectedBranchId.Add(selectedBranch.branchId);
                    dynamicComboBranches.Remove(selectedBranch);
                    fillCollectEvent();
                }
            }
        }

        private void Chk_allcollect_Checked(object sender, RoutedEventArgs e)
        {
            cb_collect.SelectedItem = null;
            cb_collect.IsEnabled = false;
            for (int i = 0; i < comboBrachTemp.Count; i++)
            {
                dynamicComboBranches.Add(comboBrachTemp.Skip(i).FirstOrDefault());
            }
            comboBrachTemp.Clear();
            stk_tagsBranches.Children.Clear();
            selectedBranchId.Clear();
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }

        private void Chk_allcollect_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_collect.IsEnabled = true;
            fillCollectEvent();
            if (stk_tagsBranches.Children.Count == 0)
            {
                fillCollectEventAll();
            }
        }
        #endregion

        #region fillLists
        private List<ItemTransferInvoice> fillList(IEnumerable<ItemTransferInvoice> Invoices, ComboBox cbBranch, ComboBox cbitem, CheckBox chkInvoice, CheckBox chkReturn, DatePicker startDate, DatePicker endDate)
        {
            var selectedBranch = cbBranch.SelectedItem as Branch;
            var selectedItemUnit = cbitem.SelectedItem as ItemUnitCombo;

            var result = Invoices.Where(x => (

           ((chkReturn.IsChecked == true ? (x.invType == "pb") : false) || (chkInvoice.IsChecked == true ? (x.invType == "p") : false))
                      && (cbBranch.SelectedItem != null ? x.branchCreatorId == selectedBranch.branchId : true)
                      && (cb_Items.SelectedItem != null ? x.itemUnitId == selectedItemUnit.itemUnitId : true)
                      && (startDate.SelectedDate != null ? x.invDate >= startDate.SelectedDate : true)
                      && (endDate.SelectedDate != null ? x.invDate <= endDate.SelectedDate : true)));

            return result.ToList();
        }

        private IEnumerable<ItemTransferInvoice> fillRowChartList(IEnumerable<ItemTransferInvoice> Invoices, CheckBox chkInvoice, CheckBox chkReturn, CheckBox chkDraft, DatePicker startDate, DatePicker endDate, TimePicker startTime, TimePicker endTime)
        {
            var result = Invoices.Where(x => (
                         (startDate.SelectedDate != null ? x.invDate >= startDate.SelectedDate : true)
                        && (endDate.SelectedDate != null ? x.invDate <= endDate.SelectedDate : true)));

            return result;
        }

        private List<ItemTransferInvoice> fillCollectListBranch(IEnumerable<ItemTransferInvoice> Invoices, DatePicker startDate, DatePicker endDate)
        {

            var temp = Invoices
                .Where(x =>
                 (startDate.SelectedDate != null ? x.IupdateDate >= startDate.SelectedDate : true)
                && (endDate.SelectedDate != null ? x.IupdateDate <= endDate.SelectedDate : true))
                .GroupBy(obj => new
                {
                    obj.branchCreatorId,
                    obj.ITitemUnitId
                }).Select(obj => new ItemTransferInvoice
                {
                    branchCreatorId = obj.FirstOrDefault().branchCreatorId,
                    branchCreatorName = obj.FirstOrDefault().branchCreatorName,
                    itemUnitId = obj.FirstOrDefault().itemUnitId,
                    ItemUnits = obj.FirstOrDefault().ItemUnits,
                    invoiceId = obj.FirstOrDefault().invoiceId,
                    ITquantity = obj.Sum(x => x.ITquantity),
                    ITitemName = obj.FirstOrDefault().ITitemName,
                    ITitemId = obj.FirstOrDefault().ITitemId,
                    ITunitName = obj.FirstOrDefault().ITunitName,
                    ITunitId = obj.FirstOrDefault().ITunitId,
                    ITupdateDate = obj.FirstOrDefault().ITupdateDate,
                    itemAvg = obj.Average(x => x.ITquantity),
                    count = obj.Count()
                }).OrderByDescending(obj => obj.ITquantity);
            return temp.ToList();
        }

        private List<ItemTransferInvoice> fillCollectListAll(IEnumerable<ItemTransferInvoice> Invoices, DatePicker startDate, DatePicker endDate)
        {
            var temp = Invoices
                .Where(x =>
                 (startDate.SelectedDate != null ? x.IupdateDate >= startDate.SelectedDate : true)
                && (endDate.SelectedDate != null ? x.IupdateDate <= endDate.SelectedDate : true))
                .GroupBy(obj => new
                {
                    obj.ITitemUnitId
                }).Select(obj => new ItemTransferInvoice
                {
                    branchCreatorId = obj.FirstOrDefault().branchCreatorId,
                    branchCreatorName = "All Branches",
                    itemUnitId = obj.FirstOrDefault().itemUnitId,
                    ItemUnits = obj.FirstOrDefault().ItemUnits,
                    invoiceId = obj.FirstOrDefault().invoiceId,
                    ITquantity = obj.Sum(x => x.ITquantity),
                    ITitemName = obj.FirstOrDefault().ITitemName,
                    ITitemId = obj.FirstOrDefault().ITitemId,
                    ITunitName = obj.FirstOrDefault().ITunitName,
                    ITunitId = obj.FirstOrDefault().ITunitId,
                    itemAvg = obj.Average(x => x.ITquantity),
                    ITupdateDate = obj.FirstOrDefault().ITupdateDate,
                    count = obj.Count()
                }).OrderByDescending(obj => obj.ITquantity);
            return temp.ToList();
        }
        #endregion

        #region General Events
        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void fillPieChartCollect(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            List<string> titles = new List<string>();
            List<long> x = new List<long>();
            titles.Clear();
            var temp = fillCollectListAll(Items, dp_collectStartDate, dp_collectEndDate);
            if (stk_tagsBranches.Children.Count > 0)
            {
                temp = fillCollectListBranch(Items, dp_collectStartDate, dp_collectEndDate)
                 .Where(j => (selectedBranchId.Count != 0 ? selectedBranchId.Contains((int)j.branchCreatorId) : true)).ToList();
            }
            var titleTemp = temp.Select(obj => obj.ITitemUnitName1);
            //var titleTemp = temp.GroupBy(m => m.ITitemName);
            titles.AddRange(titleTemp);
            x = temp.Select(m => (long)m.ITquantity).ToList();
            int count = x.Count();
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < count; i++)
            {
                List<long> final = new List<long>();
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
        }

        private void fillColumnChartCollect(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            List<int> x = new List<int>();

            var temp = fillCollectListAll(Items, dp_collectStartDate, dp_collectEndDate);
            if (stk_tagsBranches.Children.Count > 0)
            {
                temp = fillCollectListBranch(Items, dp_collectStartDate, dp_collectEndDate)
                 .Where(j => (selectedBranchId.Count != 0 ? selectedBranchId.Contains((int)j.branchCreatorId) : true)).ToList();
            }

            x = temp.Select(m => m.count).ToList();
            var tempName = temp.OrderByDescending(obj => obj.count).Select(obj => obj.ITitemUnitName1);
            names.AddRange(tempName);

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();
            List<int> cD = new List<int>();
            List<string> titles = new List<string>()
            {
               "Invoices"
            };
            int count = x.Count();
            for (int i = 0; i < count; i++)
            {
                if (i < 5)
                {
                    cP.Add(x.Max());
                    x.Remove(x.Max());
                }
                else
                {
                    cP.Add(x.Sum());
                    break;
                }
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());

            }
            axcolumn.Labels.Add("Others");
            //3 فوق بعض
            columnChartData.Add(
            new ColumnSeries
            {
                Values = cP.AsChartValues(),
                Title = titles[0],
                DataLabels = true,
            });

            DataContext = this;
            cartesianChart.Series = columnChartData;
        }

        private void fillRowChartCollect(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            int endYear = DateTime.Now.Year;
            int startYear = endYear - 1;
            int startMonth = DateTime.Now.Month;
            int endMonth = startMonth;
            if (dp_collectStartDate.SelectedDate != null && dp_collectEndDate.SelectedDate != null)
            {
                startYear = dp_collectStartDate.SelectedDate.Value.Year;
                endYear = dp_collectEndDate.SelectedDate.Value.Year;
                startMonth = dp_collectStartDate.SelectedDate.Value.Month;
                endMonth = dp_collectEndDate.SelectedDate.Value.Month;
            }
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            List<CashTransferSts> resultList = new List<CashTransferSts>();

            var temp = fillCollectListAll(Items, dp_collectStartDate, dp_collectEndDate);
            if (stk_tagsBranches.Children.Count > 0)
            {
                temp = fillCollectListBranch(Items, dp_collectStartDate, dp_collectEndDate)
                 .Where(j => (selectedBranchId.Count != 0 ? selectedBranchId.Contains((int)j.branchCreatorId) : true)).ToList();
            }

            SeriesCollection rowChartData = new SeriesCollection();
            var tempName = temp.Select(s => s.IupdateDate);
            names.Add("x");

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<long> cash = new List<long>();


            if (endYear - startYear <= 1)
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    for (int month = startMonth; month <= 12; month++)
                    {
                        var firstOfThisMonth = new DateTime(year, month, 1);
                        var firstOfNextMonth = firstOfThisMonth.AddMonths(1);
                        var drawCash = temp.ToList().Where(c => c.ITupdateDate > firstOfThisMonth && c.ITupdateDate <= firstOfNextMonth).Sum(obj => (long)obj.ITquantity);
                        cash.Add(drawCash);
                        MyAxis.Labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + "/" + year);

                        if (year == endYear && month == endMonth)
                        {
                            break;
                        }
                        if (month == 12)
                        {
                            startMonth = 1;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    var firstOfThisYear = new DateTime(year, 1, 1);
                    var firstOfNextMYear = firstOfThisYear.AddYears(1);
                    var drawCash = temp.ToList().Where(c => c.ITupdateDate > firstOfThisYear && c.ITupdateDate <= firstOfNextMYear).Sum(obj => (long)obj.ITquantity);
                    cash.Add(drawCash);
                    MyAxis.Labels.Add(year.ToString());
                }
            }
            rowChartData.Add(
          new LineSeries
          {
              Values = cash.AsChartValues(),
              Title = "Quantity"
          }); ;

            DataContext = this;
            rowChart.Series = rowChartData;
        }

        #region Charts
        private void fillPieChart(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            List<string> titles = new List<string>();
            List<int> x  =new List<int>();
            titles.Clear();

            var temp = fillList(Items, cb_ItemsBranches, cb_Items, chk_itemInvoice, chk_itemReturn, dp_ItemStartDate, dp_ItemEndDate)
             .Where(j => (selectedItemId.Count != 0 ? selectedItemId.Contains((int)j.ITitemUnitId) : true));
            var titleTemp = temp.GroupBy(jj => jj.ITitemUnitId)
             .Select(g => new ItemUnitCombo
             {
                 itemUnitId = (int)g.FirstOrDefault().ITitemUnitId,
                 itemUnitName = g.FirstOrDefault().ITitemName + "-" + g.FirstOrDefault().ITunitName
             }).ToList();
            //var titleTemp = temp.GroupBy(m => m.ITitemName);
            titles.AddRange(titleTemp.Select(jj => jj.itemUnitName));
            var result = temp.GroupBy(s => s.ITitemUnitId).Select(s => new
            {
                ITitemUnitId = s.Key,
                count = s.Count()
            });
            x = result.Select(m => m.count).ToList();
            int count = x.Count();
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < count; i++)
            {
                List<long> final = new List<long>();
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
        }

        private void fillColumnChart(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            List<int> x =new List <int>();
            IEnumerable<int> y = null;

            var temp = fillList(Items, cb_ItemsBranches, cb_Items, chk_itemInvoice, chk_itemReturn, dp_ItemStartDate, dp_ItemEndDate)
                   .Where(j => (selectedItemId.Count != 0 ? selectedItemId.Contains((int)j.ITitemUnitId) : true));
            var result = temp.GroupBy(s => s.ITitemUnitId).Select(s => new
            {
                ITitemUnitId = s.Key,
                countP = s.Where(m => m.invType == "p").Count(),
                countPb = s.Where(m => m.invType == "pb").Count(),

            });
            x = result.Select(m => m.countP).ToList();
            y = result.Select(m => m.countPb);
            var tempName = temp.GroupBy(jj => jj.ITitemUnitId)
             .Select(g => new ItemUnitCombo { itemUnitId = (int)g.FirstOrDefault().ITitemUnitId, itemUnitName = g.FirstOrDefault().ITitemName + "-" + g.FirstOrDefault().ITunitName }).ToList();
            names.AddRange(tempName.Select(nn => nn.itemUnitName));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();
            List<int> cD = new List<int>();
            List<string> titles = new List<string>()
            {
                "مبيعات","مرتجع","مسودة"
            };
            int count = x.Count();
            for (int i = 0; i < count; i++)
            {
                if (i < 5)
                {
                    cP.Add(x.Max());
                    x.Remove(x.Max());
                }
                else
                {
                    cP.Add(x.Sum());
                    break;
                }
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());

            }
            axcolumn.Labels.Add("Others");

            //3 فوق بعض
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cP.AsChartValues(),
                Title = titles[0],
                DataLabels = true,
            });
            columnChartData.Add(
           new StackedColumnSeries
           {
               Values = cPb.AsChartValues(),
               Title = titles[1],
               DataLabels = true,
           });


            DataContext = this;
            cartesianChart.Series = columnChartData;
        }

        private void fillRowChart(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<decimal> pTemp = null;
            IEnumerable<decimal> pbTemp = null;
            IEnumerable<decimal> resultTemp = null;



            var temp = fillRowChartList(Items, chk_itemInvoice, chk_itemReturn, chk_itemDrafs, dp_ItemStartDate, dp_ItemEndDate, dt_itemStartTime, dt_ItemEndTime);
            temp = temp.Where(j => (selectedItemId.Count != 0 ? stackedButton.Contains((int)j.ITitemUnitId) : true));
            var result = temp.GroupBy(s => s.ITitemUnitId).Select(s => new
            {
                ITitemUnitId = s.Key,
                totalP = s.Where(x => x.invType == "p").Sum(x => x.totalNet),
                totalPb = s.Where(x => x.invType == "pb").Sum(x => x.totalNet),

            }
         );
            var resultTotal = result.Select(x => new { x.ITitemUnitId, total = x.totalP - x.totalPb }).ToList();
            pTemp = result.Select(x => (decimal)x.totalP);
            pbTemp = result.Select(x => (decimal)x.totalPb);
            resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
            var tempName = temp.GroupBy(jj => jj.ITitemUnitId)
             .Select(g => new ItemUnitCombo { itemUnitId = (int)g.FirstOrDefault().ITitemUnitId, itemUnitName = g.FirstOrDefault().ITitemName + "-" + g.FirstOrDefault().ITunitName }).ToList();
            names.AddRange(tempName.Select(nn => nn.itemUnitName));
            /********************************************************************************/


            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            List<string> titles = new List<string>()
            {
                "اجمالي المبيعات","اجمالي المرتجع","صافي المبيعات"
            };
            for (int i = 0; i < pTemp.Count(); i++)
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
          });
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
        #endregion


    }
}



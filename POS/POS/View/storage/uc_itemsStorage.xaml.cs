﻿using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static POS.View.storage.uc_receiptOfPurchaseInvoice;

namespace POS.View.storage
{
    /// <summary>
    /// Interaction logic for uc_itemsStorage.xaml
    /// </summary>
    public partial class uc_itemsStorage : UserControl
    {
        private static uc_itemsStorage _instance;

        ItemLocation itemLocation = new ItemLocation();
        IEnumerable<ItemLocation> itemLocationList;

        Classes.Section sectionModel = new Classes.Section();
        IEnumerable<Classes.Section> sections;

        Location locationModel = new Location();
        IEnumerable<Location> locations;
        public static uc_itemsStorage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_itemsStorage();
                return _instance;
            }
        }
        public uc_itemsStorage()
        {
            InitializeComponent();
            //if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1440)
            //{
            //    txt_deleteButton.Visibility = Visibility.Visible;
            //    txt_addButton.Visibility = Visibility.Visible;
            //    txt_updateButton.Visibility = Visibility.Visible;
            //    txt_add_Icon.Visibility = Visibility.Visible;
            //    txt_update_Icon.Visibility = Visibility.Visible;
            //    txt_delete_Icon.Visibility = Visibility.Visible;
            //}
            //else if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1360)
            //{
            //    txt_add_Icon.Visibility = Visibility.Collapsed;
            //    txt_update_Icon.Visibility = Visibility.Collapsed;
            //    txt_delete_Icon.Visibility = Visibility.Collapsed;
            //    txt_deleteButton.Visibility = Visibility.Visible;
            //    txt_addButton.Visibility = Visibility.Visible;
            //    txt_updateButton.Visibility = Visibility.Visible;

            //}
            //else
            //{
            //    txt_deleteButton.Visibility = Visibility.Collapsed;
            //    txt_addButton.Visibility = Visibility.Collapsed;
            //    txt_updateButton.Visibility = Visibility.Collapsed;
            //    txt_add_Icon.Visibility = Visibility.Visible;
            //    txt_update_Icon.Visibility = Visibility.Visible;
            //    txt_delete_Icon.Visibility = Visibility.Visible;

            //}
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucItemsStorage.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucItemsStorage.FlowDirection = FlowDirection.RightToLeft;
            }
            //#region bill
            //List<Bill> items = new List<Bill>();
            //items.Add(new Bill() { Id = 336554944, Total = 255 });
            //items.Add(new Bill() { Id = 336545142, Total = 260 });
            //items.Add(new Bill() { Id = 336556165, Total = 1200 });
            //items.Add(new Bill() { Id = 336551515, Total = 150 });
            //items.Add(new Bill() { Id = 336555162, Total = 840 });
            //items.Add(new Bill() { Id = 336558897, Total = 325 });
            //dg_invoice.ItemsSource = items;
            //billDetails = LoadCollectionData();
            //dg_billDetails.ItemsSource = billDetails;
            //#endregion
            translate();
            // await refreshItemsLocations();
            // await refreshFreeZoneItemsLocations();
            await fillSections();
            #region Style Date
            dp_startDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_startDate.Template.FindName("PART_TextBox", dp_startDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_startDate.Background;
                    textBox1.BorderThickness = dp_startDate.BorderThickness;
                }
            };
            dp_endDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_endDate.Template.FindName("PART_TextBox", dp_endDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_endDate.Background;
                    textBox1.BorderThickness = dp_endDate.BorderThickness;
                }
            };

            #endregion
        }

        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////
            //txt_invoiceToggle.Text = MainWindow.resourcemanager.GetString("trInvoice");
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_InvoicenName, MainWindow.resourcemanager.GetString("trInvoiceHint"));

            //dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            //dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            //dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");
            //dg_invoice.Columns[0].Header = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            //txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            //txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            //txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            //tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            //tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            //tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

        }
        private async Task refreshItemsLocations()
        {
            itemLocationList = await itemLocation.get(MainWindow.branchID.Value);
            dg_itemsStorage.ItemsSource = itemLocationList;
        }
        private async Task refreshFreeZoneItemsLocations()
        {
            itemLocationList = await itemLocation.GetFreeZoneItems(MainWindow.branchID.Value);
            dg_itemsStorage.ItemsSource = itemLocationList;
        }
        private async Task refreshLocations()
        {
            if (cb_section.SelectedIndex != -1)
            {
                locations = await locationModel.getLocsBySectionId((int)cb_section.SelectedValue);
                cb_XYZ.ItemsSource = locations;
                cb_XYZ.SelectedValuePath = "locationId";
                cb_XYZ.DisplayMemberPath = "name";
            }
        }
        private async Task fillSections()
        {
            sections = await sectionModel.getBranchSections(MainWindow.branchID.Value);
            cb_section.ItemsSource = sections.ToList();
            cb_section.SelectedValuePath = "sectionId";
            cb_section.DisplayMemberPath = "name";
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tb_search_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private async void Tgl_IsActive_Checked(object sender, RoutedEventArgs e)
        {
            await refreshItemsLocations();
            
            clearInputs();
        }

        private async void Tgl_IsActive_Unchecked(object sender, RoutedEventArgs e)
        {
           await refreshFreeZoneItemsLocations();
         
            clearInputs();
        }

        //private void Tgl_invoiceDropDown_Checked(object sender, RoutedEventArgs e)
        //{
        //    grid_invoice.Visibility = Visibility.Visible;
        //}
        //private void Tgl_invoiceDropDown_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    grid_invoice.Visibility = Visibility.Collapsed;
        //}
        //void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        //{
        //    for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
        //        if (vis is DataGridRow)
        //        {
        //            BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
        //            ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
        //            data.Remove(row);
        //        }

        //}
      
        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            dg_collapsed.IsEnabled = false;
            dg_collapsed.Opacity = 0.2;



        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            dg_collapsed.IsEnabled = true;
            dg_collapsed.Opacity = 1;

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }
        private void validateMandatoryInputs()
        {
            SectionData.validateEmptyTextBox(tb_quantity, p_errorQuantity, tt_errorQuantity, "trEmptyQuantityToolTip");
            SectionData.validateEmptyTextBox(tb_storeCost, p_errorQuantity, tt_errorQuantity, "trEmptyStoreCost");
            SectionData.validateEmptyComboBox(cb_section, p_errorSection, tt_errorSection, "trEmptySectionToolTip");
            SectionData.validateEmptyComboBox(cb_XYZ, p_errorXYZ, tt_errorXYZ, "trErrorEmptyLocationToolTip");
            if(itemLocation.itemType.Equals("d"))
            {
                SectionData.showDatePickerValidate(dp_startDate,p_errorStartDate,tt_errorStartDate, "trEmptyStartDateToolTip");
                SectionData.showDatePickerValidate(dp_endDate,p_errorEndDate,tt_errorEndDate, "trEmptyEndDateToolTip");
            }
        }
        private async void Btn_transfer_Click(object sender, RoutedEventArgs e)
        {
            if (dg_itemsStorage.SelectedIndex != -1)
            {
                validateMandatoryInputs();
                if (itemLocation != null &&
                    !tb_quantity.Text.Equals("") && !tb_storeCost.Text.Equals("") && cb_section.SelectedIndex != -1
                    && cb_XYZ.SelectedIndex != -1 && (!itemLocation.itemType.Equals("d") ||
                    (itemLocation.itemType.Equals("d") && dp_startDate.SelectedDate != null && dp_endDate.SelectedDate != null)))
                {
                    int oldLocationId = (int)itemLocation.locationId;
                    int newLocationId = (int)cb_XYZ.SelectedValue;
                    if (oldLocationId != newLocationId)
                    {
                    int quantity = int.Parse(tb_quantity.Text);
                    ItemLocation newLocation = new ItemLocation();
                    newLocation.itemUnitId = itemLocation.itemUnitId;
                    newLocation.locationId = newLocationId;
                    newLocation.quantity = quantity;
                    newLocation.startDate = dp_startDate.SelectedDate;
                    newLocation.endDate = dp_endDate.SelectedDate;
                    newLocation.storeCost = int.Parse(tb_storeCost.Text);
                    newLocation.note = tb_notes.Text;
                    newLocation.updateUserId = MainWindow.userID.Value;
                    newLocation.createUserId = MainWindow.userID.Value;
                    //newLocation.storeCost 
                    bool res = await itemLocation.trasnferItem(itemLocation.itemsLocId, newLocation);
                    if (res)
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    }
                    else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    if (tgl_IsActive.IsChecked == true)
                        await refreshItemsLocations();
                    else
                        await refreshFreeZoneItemsLocations();

                    clearInputs();
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTranseToSameLocation"), animation: ToasterAnimation.FadeIn);
                    
                }
            }
        }
        private async void Cb_section_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await refreshLocations();
        }

        private async void Dg_itemsStorage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_itemsStorage.SelectedIndex != -1)
            {
                clearInputs();

                itemLocation = dg_itemsStorage.SelectedItem as ItemLocation;
                this.DataContext = itemLocation;
                dp_startDate.SelectedDate = itemLocation.startDate;
                dp_endDate.SelectedDate = itemLocation.endDate;
                if (itemLocation.itemType.Equals("d"))
                    gd_date.Visibility = Visibility.Visible;
                else
                    gd_date.Visibility = Visibility.Collapsed;
                if (tgl_IsActive.IsChecked == true)
                {
                    tb_itemName.IsReadOnly = true;
                    dp_endDate.IsEnabled = false;
                    dp_startDate.IsEnabled = false;
                    cb_section.SelectedValue = itemLocation.sectionId;
                    await refreshLocations();
                    cb_XYZ.SelectedValue = itemLocation.locationId;
                }
                else
                {
                    dp_endDate.IsEnabled = true;
                    dp_startDate.IsEnabled = true;
                    cb_section.SelectedIndex = -1;
                    cb_XYZ.SelectedIndex = -1;
                }

            }
        }

        private void Tb_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(itemLocation != null && !tb_quantity.Text.Equals(""))
            {
                if(int.Parse(tb_quantity.Text) > itemLocation.quantity)
                {
                    tb_quantity.Text = itemLocation.quantity.ToString();
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
                }
            }
        }
        private void clearInputs()
        {
            tb_itemName.Clear();
            tb_quantity.Clear();
            cb_section.SelectedIndex = -1;
            cb_XYZ.SelectedIndex = -1;
            dp_startDate.SelectedDate = null;
            dp_startDate.Text = "";
            dp_endDate.SelectedDate = null;
            dp_endDate.Text = "";
            tb_notes.Clear();
            itemLocation = new ItemLocation();
            gd_date.Visibility = Visibility.Collapsed;

            SectionData.clearComboBoxValidate(cb_section,p_errorSection);
            SectionData.clearComboBoxValidate(cb_XYZ,p_errorXYZ);
            SectionData.clearValidate(tb_quantity,p_errorQuantity);
            if (gd_date.Visibility == Visibility.Visible)
            {
                TextBox tbStartDate = (TextBox)dp_startDate.Template.FindName("PART_TextBox", dp_startDate);
                SectionData.clearValidate(tbStartDate, p_errorStartDate);
                TextBox tbEndDate = (TextBox)dp_endDate.Template.FindName("PART_TextBox", dp_endDate);
                SectionData.clearValidate(tbEndDate, p_errorEndDate);
            }
        }

        private void Dp_date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dp_endDate.SelectedDate != null && dp_startDate.SelectedDate != null)
            {
                if(dp_endDate.SelectedDate < dp_startDate.SelectedDate)
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorStartBeforEndToolTip"), animation: ToasterAnimation.FadeIn);
            }
        }
        //private void clearValidity()
        //{
        //    SectionData.clearComboBoxValidate(cb_section, p_errorSection);
        //    SectionData.clearComboBoxValidate(cb_XYZ, p_errorXYZ);
        //    SectionData.clearValidate(tb_quantity, p_errorQuantity);
        //    if (gd_date.Visibility == Visibility.Visible)
        //    {
        //        TextBox tbStartDate = (TextBox)dp_startDate.Template.FindName("PART_TextBox", dp_startDate);
        //        SectionData.clearValidate(tbStartDate, p_errorStartDate);
        //        TextBox tbEndDate = (TextBox)dp_endDate.Template.FindName("PART_TextBox", dp_endDate);
        //        SectionData.clearValidate(tbEndDate, p_errorEndDate);
        //    }
        //}
        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_quantity")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorQuantity, tt_errorQuantity, "trEmptyQuantityToolTip");  
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_section")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorSection, tt_errorSection, "trEmptySectionToolTip");
                else if ((sender as ComboBox).Name == "cb_XYZ")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorXYZ, tt_errorXYZ, "trErrorEmptyLocationToolTip");
            }
            else if (name == "DatePicker")
            {
                if ((sender as DatePicker).Name == "dp_startDate")
                    SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorStartDate, tt_errorStartDate, "trEmptyStartDateToolTip");
                else if ((sender as DatePicker).Name == "dp_endDate")
                    SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorEndDate, tt_errorEndDate, "trEmptyEndDateToolTip");
            }
        }

        private void Tb_storageCost_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
    }
}

using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        IEnumerable<ItemLocation> itemLocationListQuery;

        Classes.Section sectionModel = new Classes.Section();
        IEnumerable<Classes.Section> sections;

        Location locationModel = new Location();
        IEnumerable<Location> locations;
        string searchText = "";
        string transferPermission = "itemsStorage_transfer";
        string reportsPermission = "itemsStorage_reports";
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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this);
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                 
                    if (sender != null)
                        SectionData.StartAwait(grid_main);


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
                 
                Tb_search_TextChanged(null, null);

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
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //if (itemLocationList is null)
                if (tgl_IsActive.IsChecked == true)
                {
                    await refreshItemsLocations();
                    clearInputs();
                }
                else
                {
                    await refreshFreeZoneItemsLocations();
                    clearInputs();
                }


                searchText = tb_search.Text.ToLower();


                itemLocationListQuery = itemLocationList.Where(s => (s.itemName.ToLower().Contains(searchText) ||
                s.unitName.ToLower().Contains(searchText) ||
                s.section.ToLower().Contains(searchText) ||
                s.location.ToLower().Contains(searchText)));
                dg_itemsStorage.ItemsSource = itemLocationListQuery;
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
        private void Tgl_IsActive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                Tb_search_TextChanged(null, null);
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

        private async void Tgl_IsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                Tb_search_TextChanged(null, null);
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
        private async Task refreshItemsLocations()
        {
            itemLocationList = await itemLocation.get(MainWindow.branchID.Value);
        }
        private async Task refreshFreeZoneItemsLocations()
        {
            itemLocationList = await itemLocation.GetFreeZoneItems(MainWindow.branchID.Value);
        }
        private void translate()
        {


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
            try
            {

                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Thread t1 = new Thread(() =>
                    {
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Store\Ar\ArStorageReport.rdlc";
                        }
                        else addpath = @"\Reports\Store\EN\StorageReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        ReportCls.checkLang();

                        clsReports.itemLocation(itemLocationListQuery, rep, reppath);
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
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                Tb_search_TextChanged(null, null);
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

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            try
            {

                dg_collapsed.IsEnabled = false;
                dg_collapsed.Opacity = 0.2;



            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            try
            {

                dg_collapsed.IsEnabled = true;
                dg_collapsed.Opacity = 1;

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }


        private void validateMandatoryInputs()
        {
            SectionData.validateEmptyTextBox(tb_quantity, p_errorQuantity, tt_errorQuantity, "trEmptyQuantityToolTip");
            SectionData.validateEmptyComboBox(cb_section, p_errorSection, tt_errorSection, "trEmptySectionToolTip");
            SectionData.validateEmptyComboBox(cb_XYZ, p_errorXYZ, tt_errorXYZ, "trErrorEmptyLocationToolTip");
            if (itemLocation.itemType.Equals("d"))
            {
                SectionData.showDatePickerValidate(dp_startDate, p_errorStartDate, tt_errorStartDate, "trEmptyStartDateToolTip");
                SectionData.showDatePickerValidate(dp_endDate, p_errorEndDate, tt_errorEndDate, "trEmptyEndDateToolTip");
            }
        }
        private async void Btn_transfer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(transferPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (dg_itemsStorage.SelectedIndex != -1)
                    {
                        validateMandatoryInputs();
                        if (itemLocation != null &&
                            !tb_quantity.Text.Equals("") && cb_section.SelectedIndex != -1
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
                            Tb_search_TextChanged(null, null);
                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
        private async void Cb_section_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if (sender != null)
                    SectionData.StartAwait(grid_main);
                await refreshLocations();
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

        private async void Dg_itemsStorage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if (sender != null)
                    SectionData.StartAwait(grid_main);
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

        private void Tb_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                if (itemLocation != null && !tb_quantity.Text.Equals(""))
                {
                    if (int.Parse(tb_quantity.Text) > itemLocation.quantity)
                    {
                        tb_quantity.Text = itemLocation.quantity.ToString();
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
                    }
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
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

            SectionData.clearComboBoxValidate(cb_section, p_errorSection);
            SectionData.clearComboBoxValidate(cb_XYZ, p_errorXYZ);
            SectionData.clearValidate(tb_quantity, p_errorQuantity);
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
            try
            {

                if (dp_endDate.SelectedDate != null && dp_startDate.SelectedDate != null)
                {
                    if (dp_endDate.SelectedDate < dp_startDate.SelectedDate)
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorStartBeforEndToolTip"), animation: ToasterAnimation.FadeIn);
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
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

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\Store\Ar\ArStorageReport.rdlc";
                    }
                    else addpath = @"\Reports\Store\EN\StorageReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.itemLocation(itemLocationListQuery, rep, reppath);
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
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\Store\Ar\ArStorageReport.rdlc";
                    }
                    else addpath = @"\Reports\Store\EN\StorageReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.itemLocation(itemLocationListQuery, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();
                    LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
            Window.GetWindow(this).Opacity = 0.2;
            string pdfpath = "";

            List<ReportParameter> paramarr = new List<ReportParameter>();


            //
            pdfpath = @"\Thumb\report\temp.pdf";
            pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Store\Ar\ArStorageReport.rdlc";
            }
            else addpath = @"\Reports\Store\EN\StorageReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.itemLocation(itemLocationListQuery, rep, reppath);
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
        }
    }
}

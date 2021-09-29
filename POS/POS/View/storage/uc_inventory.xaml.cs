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
using System.Windows.Threading;

namespace POS.View.storage
{
    /// <summary>
    /// Interaction logic for uc_inventory.xaml
    /// </summary>
    public partial class uc_inventory : UserControl
    {
        private static uc_inventory _instance;
        List<ItemLocation> itemsLocations;
        ItemLocation itemLocationModel = new ItemLocation();
        InventoryItemLocation invItemModel = new InventoryItemLocation();
        List<InventoryItemLocation> invItemsLocations = new List<InventoryItemLocation>();

        Inventory inventory = new Inventory();
        private static DispatcherTimer timer;
        bool firstTimeForDatagrid = true;

        string _InventoryType = "d";
        string createInventoryPermission = "inventory_create";
        string archivingPermission = "inventory_archiving";
        string reportsPermission = "inventory_reports";

        private static int _ShortageAmount = 0;
        private static int _DestroyAmount = 0;
        public static uc_inventory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_inventory();
                return _instance;
            }
        }

        public uc_inventory()
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
        private async void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                if (_InventoryType.Equals("d") && invItemsLocations.Count > 0)
                {
                    #region Accept
                    MainWindow.mainWindow.Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    //w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                    w.contentText = "Do you want save pay invoice in drafts?";
                    w.ShowDialog();
                    MainWindow.mainWindow.Opacity = 1;
                    #endregion
                    if (w.isOk)
                        await addInventory("d"); // d:draft        
                }
                clearInventory();
                timer.Stop();
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
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", assembly: Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }
                setTimer();

                translate();
                //await fillInventoryDetails();
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
            ////////////////////////////////----Inventory----/////////////////////////////////
            dg_items.Columns[0].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_items.Columns[1].Header = MainWindow.resourcemanager.GetString("trSectionLocation");
            dg_items.Columns[2].Header = MainWindow.resourcemanager.GetString("trItemUnit");
            dg_items.Columns[3].Header = MainWindow.resourcemanager.GetString("trRealAmount");
            dg_items.Columns[4].Header = MainWindow.resourcemanager.GetString("trInventoryAmount");
            dg_items.Columns[5].Header = MainWindow.resourcemanager.GetString("trDestoryCount");

            txt_inventoryDetails.Text = MainWindow.resourcemanager.GetString("trStocktakingDetails");
            txt_titleDataGrid.Text = MainWindow.resourcemanager.GetString("trStocktakingItems");
            //btn_archive.Content = MainWindow.resourcemanager.GetString("trArchive");
            btn_archive.Content = MainWindow.resourcemanager.GetString("trSave");

            bdr_archive.Background = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
            txt_newDraft.Text = MainWindow.resourcemanager.GetString("trNew");
            txt_drafts.Text = MainWindow.resourcemanager.GetString("trDraft");
            txt_inventory.Text = MainWindow.resourcemanager.GetString("trInventory");
            txt_printInvoice.Text = MainWindow.resourcemanager.GetString("trPrint");
            txt_preview.Text = MainWindow.resourcemanager.GetString("trPreview");
            txt_invoiceImages.Text = MainWindow.resourcemanager.GetString("trImages");
            txt_shortageTitle.Text = MainWindow.resourcemanager.GetString("trShortages");
            txt_destroyTitle.Text = MainWindow.resourcemanager.GetString("trDestructives");
        }
        #region timer to refresh notifications
        private void setTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private async void timer_Tick(object sendert, EventArgs et)
        {
            try
            {

                if (inventory.inventoryId != 0)
                {
                    await refreshDocCount(inventory.inventoryId);
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        private async Task refreshDocCount(int inventoryId)
        {
            DocImage doc = new DocImage();
            int docCount = await doc.GetDocCount("Inventory", inventoryId);

            int previouseCount = 0;
            if (md_docImage.Badge != null && md_docImage.Badge.ToString() != "") previouseCount = int.Parse(md_docImage.Badge.ToString());

            if (docCount > 9)
            {
                docCount = 9;
                md_docImage.Badge = "+" + docCount.ToString();
            }
            else if (docCount == 0) md_docImage.Badge = "";
            else
                md_docImage.Badge = docCount.ToString();
        }
        private async Task fillItemLocations()
        {
            int sequence = 0;
            invItemsLocations.Clear();

            inventory = await inventory.getByBranch("d", MainWindow.branchID.Value);
            if (inventory.inventoryId == 0)// there is no draft in branch
            {
                itemsLocations = await itemLocationModel.getAll(MainWindow.branchID.Value);

                foreach (ItemLocation il in itemsLocations)
                {
                    sequence++;
                    InventoryItemLocation iil = new InventoryItemLocation();
                    iil.sequence = sequence;
                    iil.itemName = il.itemName;
                    iil.section = il.section;
                    iil.location = il.location;
                    iil.unitName = il.unitName;
                    iil.quantity = (int)il.quantity;
                    iil.itemLocationId = il.itemsLocId;
                    iil.isDestroyed = false;
                    iil.isFalls = false;
                    iil.amountDestroyed = 0;
                    iil.amount = 0;
                    iil.createUserId = MainWindow.userLogin.userId;

                    invItemsLocations.Add(iil);
                }
                await inputEditable();
                dg_items.ItemsSource = invItemsLocations.ToList();
                if (firstTimeForDatagrid)
                {
                    await Task.Delay(1000);
                    dg_items.Items.Refresh();
                    firstTimeForDatagrid = false;
                }
            }
            else
            {
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trDraftExist"), animation: ToasterAnimation.FadeIn);

            }
        }
        private async Task fillInventoryDetails()
        {
            int sequence = 0;
            invItemsLocations.Clear();
            itemsLocations = await itemLocationModel.getAll(MainWindow.branchID.Value);

            if (_InventoryType == "d")
                inventory = await inventory.getByBranch("d", MainWindow.branchID.Value);
            if (inventory.inventoryId == 0)// there is no draft in branch
            {
                foreach (ItemLocation il in itemsLocations)
                {
                    sequence++;
                    InventoryItemLocation iil = new InventoryItemLocation();
                    iil.sequence = sequence;
                    iil.itemName = il.itemName;
                    iil.section = il.section;
                    iil.location = il.location;
                    iil.unitName = il.unitName;
                    iil.quantity = (int)il.quantity;
                    iil.itemLocationId = il.itemsLocId;
                    iil.isDestroyed = false;
                    iil.isFalls = false;
                    iil.amountDestroyed = 0;
                    iil.amount = 0;
                    iil.createUserId = MainWindow.userLogin.userId;

                    invItemsLocations.Add(iil);
                }
            }
            else
            {
                txt_inventoryNum.Text = inventory.num;
                txt_inventoryDate.Text = inventory.createDate.ToString();
                invItemsLocations = await invItemModel.GetAll(inventory.inventoryId);
            }
            await inputEditable();
            dg_items.ItemsSource = invItemsLocations.ToList();
            if (firstTimeForDatagrid)
            {
                await Task.Delay(1000);
                dg_items.Items.Refresh();
                firstTimeForDatagrid = false;
            }
        }
        private async Task inputEditable()
        {
            if (_InventoryType == "d") // draft
            {
                dg_items.Columns[4].IsReadOnly = false;
                dg_items.Columns[5].IsReadOnly = false;
                btn_archive.IsEnabled = true;
                btn_deleteInventory.Visibility = Visibility.Collapsed;
                btn_archive.Content = MainWindow.resourcemanager.GetString("trSave");
                bdr_archive.Background = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
            }
            else if (_InventoryType == "n") // normal saved
            {
                dg_items.Columns[4].IsReadOnly = true;
                dg_items.Columns[5].IsReadOnly = true;
                btn_archive.Content = MainWindow.resourcemanager.GetString("trArchive");
                bdr_archive.Background = Application.Current.Resources["mediumRed"] as SolidColorBrush;
                if(SectionData.isAdminPermision())
                btn_deleteInventory.Visibility = Visibility.Visible;
                bool shortageManipulated = await inventory.shortageIsManipulated(inventory.inventoryId);
                if (shortageManipulated)
                    btn_archive.IsEnabled = true;
                else
                    btn_archive.IsEnabled = false;

            }
        }
        private void Dg_items_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                TextBox t = new TextBox();
                ItemLocation row = e.Row.Item as ItemLocation;
                var index = e.Row.GetIndex();
                if (dg_items.SelectedIndex != -1 && index < itemsLocations.Count)
                {
                    var columnName = e.Column.Header.ToString();
                    t = e.EditingElement as TextBox;
                    if (t != null && columnName == MainWindow.resourcemanager.GetString("trDestoryCount"))
                    {
                        int destroyCount = int.Parse(t.Text);
                        //int oldCount = e.Row.Item.
                        int newCount = int.Parse(t.Text);
                        if (destroyCount > itemsLocations[index].quantity)
                        {
                            
                            t.Text = "0";
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorDistroyMoreQuanToolTip"), animation: ToasterAnimation.FadeIn);
                        }
                        _DestroyAmount += newCount;
                        refreshDestroyAmount();
                    }
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
        private static void refreshDestroyAmount()
        {

        }
        private async void clearInventory()
        {
            _InventoryType = "d";
            inventory = new Inventory();
            txt_inventoryDate.Text = "";
            txt_inventoryNum.Text = "";
            md_docImage.Badge = "";
            invItemsLocations.Clear();
            txt_titleDataGrid.Text = MainWindow.resourcemanager.GetString("trInventoryDraft");
            dg_items.ItemsSource = null;
            btn_deleteInventory.Visibility = Visibility.Collapsed;
            await inputEditable();
        }
        private async Task addInventory(string invType)
        {
            if (inventory.inventoryId == 0)
            {
                inventory.branchId = MainWindow.branchID.Value;
                inventory.posId = MainWindow.posID.Value;
                inventory.createUserId = MainWindow.userLogin.userId;
            }
            if (invType == "n")
                inventory.num = await inventory.generateInvNumber("in");
            inventory.inventoryType = invType;
            inventory.updateUserId = MainWindow.userLogin.userId;

            int inventoryId = await inventory.Save(inventory);

            if (inventoryId != 0)
            {
                // add inventory details
                string res = await invItemModel.Save(invItemsLocations, inventoryId);
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                clearInventory();
            }
            else
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
        }
        private async void Btn_newInventory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //if (inventory.inventoryId != 0 && inventory != null)
                //{
                if (!_InventoryType.Equals("n") && invItemsLocations.Count > 0)
                {
                    await addInventory("d"); // d:draft
                    clearInventory();
                }
                else
                    //}
                    await fillItemLocations();
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
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                inventory = await inventory.getByBranch("d", MainWindow.branchID.Value);
                if (inventory.inventoryId == 0)
                {
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoDraft"), animation: ToasterAnimation.FadeIn);

                }
                else
                {
                    txt_titleDataGrid.Text = MainWindow.resourcemanager.GetString("trInventoryDraft");
                    _InventoryType = "d";
                    await refreshDocCount(inventory.inventoryId);
                    await fillInventoryDetails();
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
        private async void Btn_Inventory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (_InventoryType.Equals("d") && invItemsLocations.Count > 0)
                {
                    await addInventory("d"); // d:draft
                }
                inventory = await inventory.getByBranch("n", MainWindow.branchID.Value);
                if (inventory.inventoryId == 0)
                {
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoInventory"), animation: ToasterAnimation.FadeIn);

                }
                else
                {
                    txt_titleDataGrid.Text = MainWindow.resourcemanager.GetString("trStocktaking");
                    _InventoryType = "n";
                    await refreshDocCount(inventory.inventoryId);
                    await fillInventoryDetails();
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
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(createInventoryPermission, MainWindow.groupObjects, "one"))
                {
                    var inv = await inventory.getByBranch("n", MainWindow.branchID.Value);
                    if (inv.inventoryId == 0)
                        await addInventory("n"); // n:normal
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trWarningOneInventory"), animation: ToasterAnimation.FadeIn);
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
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_archive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(archivingPermission, MainWindow.groupObjects, "one") || MainWindow.groupObject.HasPermissionAction(createInventoryPermission, MainWindow.groupObjects, "one"))
                {
                    if (_InventoryType == "n")
                        await addInventory("a"); // a:archived
                    else if (_InventoryType == "d")
                    {
                        var inv = await inventory.getByBranch("n", MainWindow.branchID.Value);
                        if (inv.inventoryId == 0)
                            await addInventory("n"); // n:normal
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trWarningOneInventory"), animation: ToasterAnimation.FadeIn);
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
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
                {
                    if (invItemsLocations != null)
                    {
                        Thread t1 = new Thread(() =>
                        {
                            pdfInventory();
                        });
                        t1.Start();
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
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void pdfInventory()
        {
            BuildReport();

            this.Dispatcher.Invoke(() =>
            {
                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
                }
            });
        }

        private void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
                {
                    /////////////////////////////////////
                    if (invItemsLocations != null)
                    {
                        Thread t1 = new Thread(() =>
                        {
                            printInventory();
                        });
                        t1.Start();
                    }
                    //////////////////////////////////////
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
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void printInventory()
        {
            BuildReport();

            this.Dispatcher.Invoke(() =>
            {
                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
            });
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
                {
                    #region
                    if(invItemsLocations != null)
                    { 
                        Window.GetWindow(this).Opacity = 0.2;
                        /////////////////////
                        string pdfpath = "";
                        pdfpath = @"\Thumb\report\temp.pdf";
                        pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                        BuildReport();
                        LocalReportExtensions.ExportToPDF(rep, pdfpath);
                        ///////////////////
                        wd_previewPdf w = new wd_previewPdf();
                        w.pdfPath = pdfpath;
                        if (!string.IsNullOrEmpty(w.pdfPath))
                        {
                            w.ShowDialog();
                            w.wb_pdfWebViewer.Dispose();
                        }
                        Window.GetWindow(this).Opacity = 1;
                        //////////////////////////////////////
                    }
                    #endregion
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
                SectionData.ExceptionMessage(ex, this);
            }
        }
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Store\Ar\ArInventory.rdlc";//////////??????????
            }
            else
                addpath = @"\Reports\Store\En\Inventory.rdlc";/////////???????????
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.inventoryReport(invItemsLocations, rep, reppath, paramarr);////////////?????
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();
        }

        private async void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (inventory != null && inventory.inventoryId != 0)
                {
                    Window.GetWindow(this).Opacity = 0.2;

                    wd_uploadImage w = new wd_uploadImage();

                    w.tableName = "Inventory";
                    w.tableId = inventory.inventoryId;
                    w.docNum = inventory.num;
                    w.ShowDialog();
                    await refreshDocCount(inventory.inventoryId);
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trChooseInvoiceToolTip"), animation: ToasterAnimation.FadeIn);
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

        private async void Btn_deleteInventory_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (inventory.inventoryId != 0)
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                    {
                        //string res = await inventory.deleteInventory(inventory.inventoryId,MainWindow.userID.Value,false);
                        //if (res.Equals("1"))
                        //{
                        //    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopDelete"), animation: ToasterAnimation.FadeIn);

                        //    clearInventory();
                        //}
                        //else
                        //    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
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
    }
}

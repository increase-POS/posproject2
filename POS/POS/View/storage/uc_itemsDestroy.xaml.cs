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
    /// Interaction logic for uc_itemsDestroy.xaml
    /// </summary>
    public partial class uc_itemsDestroy : UserControl
    {
        string destroyPermission = "itemsDestroy_destroy";
        string reportsPermission = "itemsDestroy_reports";
        private static uc_itemsDestroy _instance;
        public static uc_itemsDestroy Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_itemsDestroy();
                return _instance;
            }
        }
        public uc_itemsDestroy()
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
        Category categoryModel = new Category();
        Category category = new Category();
        //IEnumerable<Category> categories;
        InventoryItemLocation invItemLocModel = new InventoryItemLocation();
        InventoryItemLocation invItemLoc = new InventoryItemLocation();
        ItemLocation itemLocationModel = new ItemLocation();
        Invoice invoiceModel = new Invoice();
        Branch branchModel = new Branch();
        IEnumerable<InventoryItemLocation> inventoriesItems;
        User userModel = new User();
        List<User> users;

        //int? categoryParentId = 0;
        private string _ItemType = "";
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;
        private static int _serialCount = 0;
        string searchText = "";
        IEnumerable<InventoryItemLocation> invItemsQuery;
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

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

                await refreshDestroyDetails();
                await fillItemCombo();
                await fillUsers();
                branchModel = await branchModel.getBranchById(MainWindow.branchID.Value);
                Tb_search_TextChanged(null, null);
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
        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
               await  refreshDestroyDetails();
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
        IEnumerable<Item> items;
        // item object
        Item item = new Item();
        ItemUnit itemUnit = new ItemUnit();
        private async Task fillUsers()
        {
            users = await userModel.GetUsersActive();
            var user = new User();
            user.userId = 0;
            user.name = "---";
            users.Insert(0, user);
            cb_user.ItemsSource = users;
            cb_user.DisplayMemberPath = "name";
            cb_user.SelectedValuePath = "userId";
        }
        private async void Cb_item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                if (cb_item.SelectedValue != null && cb_item.SelectedIndex != -1)
                    if (int.Parse(cb_item.SelectedValue.ToString()) != -1)
                    {
                        var list = await itemUnit.GetItemUnits(int.Parse(cb_item.SelectedValue.ToString()));
                        cb_unit.ItemsSource = list;
                        cb_unit.SelectedValuePath = "itemUnitId";
                        cb_unit.DisplayMemberPath = "mainUnit";
                        cb_unit.SelectedIndex = 0;
                        int itemId = (int)cb_item.SelectedValue;
                        Item item = items.ToList().Find(x => x.itemId == itemId);
                        _ItemType = item.type;
                        if (item.type == "sn")
                        {
                            grid_serial.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            grid_serial.Visibility = Visibility.Collapsed;
                        }

                    }
                Btn_clearSerial_Click(null, null);
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

        async Task<IEnumerable<Item>> RefrishItems()
        {
             items = await item.GetItemsWichHasUnits();
             return items;
        }
        private async Task fillItemCombo()
        {
            if (items is null)
                await RefrishItems();
            cb_item.ItemsSource = items.ToList();
            cb_item.SelectedValuePath = "itemId";
            cb_item.DisplayMemberPath = "name";
        }

        private void translate()
        {
            txt_itemsDestroyHeader.Text = MainWindow.resourcemanager.GetString("trDestructiveItem");
            txt_destroy.Text = MainWindow.resourcemanager.GetString("trDestructionInfo");
            txt_manually.Text = MainWindow.resourcemanager.GetString("trManually");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_itemUnit, MainWindow.resourcemanager.GetString("trItem")+"...");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_amount, MainWindow.resourcemanager.GetString("trAmount") + "...");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_user, MainWindow.resourcemanager.GetString("trUser")+"...");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_reasonOfDestroy, MainWindow.resourcemanager.GetString("trReason") + "...");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNote") + "...");

            btn_destroy.Content = MainWindow.resourcemanager.GetString("trDestroy");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");

            dg_itemDestroy.Columns[0].Header = MainWindow.resourcemanager.GetString("trNo.");
            dg_itemDestroy.Columns[1].Header = MainWindow.resourcemanager.GetString("trDate");
            dg_itemDestroy.Columns[2].Header = MainWindow.resourcemanager.GetString("trSection")+"-"+ MainWindow.resourcemanager.GetString("trLocation");
            dg_itemDestroy.Columns[3].Header = MainWindow.resourcemanager.GetString("trItem") + "-" + MainWindow.resourcemanager.GetString("trUnit");
            dg_itemDestroy.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");

            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
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
                SectionData.ExceptionMessage(ex, this);
            }
        }


        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export to excel
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    if (invItemsQuery != null)
                    {
                    //    Thread t1 = new Thread(() =>
                    //{
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Store\Ar\ArDestroyReport.rdlc";
                        }
                        else addpath = @"\Reports\Store\EN\DestroyReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        ReportCls.checkLang();

                        clsReports.invItem(invItemsQuery, rep, reppath, paramarr);
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
                    //});
                    //    t1.Start();
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

        private void FN_ExportToExcel()
        {
            var QueryExcel = invItemsQuery.AsEnumerable().Select(x => new
            {
                InventoryNumber = x.inventoryNum,
                Date = x.inventoryDate,
                SectionLocation = x.section + "-" + x.location,
                ItemUnit = x.itemName + "-" + x.unitName,
                Ammount = x.amount
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trInventoryNum");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trInventoryDate");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trSectionLocation");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trItemUnit");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trAmount");

            ExportToExcel.Export(DTForExcel);
        }
        #endregion
        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_reasonOfDestroy")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorReasonOfDestroy, tt_errorReasonOfDestroy, "trEmptyReasonToolTip");
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private bool validateDistroy()
        {
            bool valid = true;
            SectionData.validateEmptyTextBox(tb_reasonOfDestroy, p_errorReasonOfDestroy, tt_errorReasonOfDestroy, "trEmptyReasonToolTip");
            if (tb_reasonOfDestroy.Text.Equals(""))
            {
                valid = false;
                return valid;
            }
            if (invItemLoc == null || invItemLoc.id == 0)
            {
                SectionData.validateEmptyComboBox(cb_item, p_errorItem, tt_errorItem, "trEmptyItemToolTip");
                SectionData.validateEmptyComboBox(cb_unit, p_errorUnit, tt_errorUnit, "trErrorEmptyUnitToolTip");
                if (cb_item.SelectedIndex == -1 || cb_unit.SelectedIndex == -1)
                {
                    valid = false;
                    return valid;
                }
            }
            if (int.Parse(tb_amount.Text) < lst_serials.Items.Count)
            {
                valid = false;
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorSerialMoreItemCountToolTip"), animation: ToasterAnimation.FadeIn);
            }
            return valid;
        }
        private async void Btn_destroy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(destroyPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    bool valid = validateDistroy();
                    if (valid)
                    {
                        int itemUnitId = 0;
                        int itemId = 0;
                        int invoiceId = 0;
                        string serialNum = "";
                        if (invItemLoc.id != 0)
                        {
                            itemUnitId = invItemLoc.itemUnitId;
                            itemId = invItemLoc.itemId;
                        }
                        else
                        {
                            itemUnitId = (int)cb_unit.SelectedValue;
                            itemId = (int)cb_item.SelectedValue;
                        }
                        if (_ItemType == "sn")
                            serialNum = tb_serialNum.Text;
                        invItemLoc.cause = tb_reasonOfDestroy.Text;
                        invItemLoc.notes = tb_notes.Text;
                        if (lst_serials.Items.Count > 0)
                        {
                            for (int j = 0; j < lst_serials.Items.Count; j++)
                            {
                                serialNum += lst_serials.Items[j];
                                if (j != lst_serials.Items.Count - 1)
                                    serialNum += ",";
                            }
                        }
                        // decimal price = await invoiceModel.GetAvgItemPrice(itemUnitId, itemId);
                        decimal price = 0;
                        decimal total = 0;

                        #region invoice Object
                        invoiceModel.invNumber = await invoiceModel.generateInvNumber("ds", branchModel.code, MainWindow.branchID.Value);
                        invoiceModel.branchCreatorId = MainWindow.branchID.Value;
                        invoiceModel.posId = MainWindow.posID.Value;
                        invoiceModel.createUserId = MainWindow.userID.Value;
                        invoiceModel.invType = "d"; // destroy                      
                        invoiceModel.paid = 0;
                        invoiceModel.deserved = invoiceModel.totalNet;
                        invoiceModel.notes = tb_notes.Text;
                        if (cb_user.SelectedIndex != -1 && cb_user.SelectedIndex != 0)
                            invoiceModel.userId = (int)cb_user.SelectedValue;
                        #endregion
                        List<ItemTransfer> orderList = new List<ItemTransfer>();
                        #region notification Object
                        Notification not = new Notification()
                        {
                            title = "trExceedMinLimitAlertTilte",
                            ncontent = "trExceedMinLimitAlertContent",
                            msgType = "alert",
                            createDate = DateTime.Now,
                            updateDate = DateTime.Now,
                            createUserId = MainWindow.userID.Value,
                            updateUserId = MainWindow.userID.Value,
                        };
                        #endregion
                        if (invItemLoc.id != 0)
                        {
                            price = (decimal)invItemLoc.avgPurchasePrice;
                            total = price * int.Parse(tb_amount.Text);
                            invoiceModel.total = total;
                            invoiceModel.totalNet = total;
                            //int amount = await itemLocationModel.getAmountByItemLocId((int)invItemLoc.itemLocationId);
                            //if (amount >= invItemLoc.amountDestroyed)
                            //{
                            orderList.Add(new ItemTransfer()
                                {
                                    itemName = invItemLoc.itemName,
                                    itemId = invItemLoc.itemId,
                                    unitName = invItemLoc.unitName,
                                    itemUnitId = invItemLoc.itemUnitId,
                                    quantity = invItemLoc.amountDestroyed,
                                    itemSerial = serialNum,
                                    price = price,
                                    invoiceId =0,
                                    inventoryItemLocId = invItemLoc.id,
                                    createUserId = MainWindow.userID,
                                });
                                invoiceId = await invoiceModel.saveInvoice(invoiceModel);
                                if (invoiceId != 0)
                                {
                                    invoiceModel.invoiceId = invoiceId;
                                    await invoiceModel.saveInvoiceItems(orderList, invoiceId);
                                    await invItemLoc.distroyItem(invItemLoc);
                                    if (cb_user.SelectedIndex != -1 && cb_user.SelectedIndex != 0)
                                        await recordCash(invoiceModel);
                                   
                                    await itemLocationModel.decreaseItemLocationQuantity((int)invItemLoc.itemLocationId, (int)invItemLoc.amountDestroyed, MainWindow.userID.Value, "storageAlerts_minMaxItem", not);
                                    await refreshDestroyDetails();
                                    Btn_clear_Click(null, null);
                                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                                }
                                else
                                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                            //}
                            //else
                            //{
                            //    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trDestroyAmountMoreExist"), animation: ToasterAnimation.FadeIn);
                            //}
                        }
                        else
                        {
                           var avgPrice = items.Where(x => x.itemId == (int)cb_item.SelectedValue).Select(x => x.avgPurchasePrice).Single();
                            if (avgPrice != null)
                                price = (decimal)avgPrice;
                            total = price * int.Parse(tb_amount.Text);
                            invoiceModel.total = total;
                            invoiceModel.totalNet = total;
                            orderList.Add(new ItemTransfer()
                            {
                                itemName = cb_item.SelectedItem.ToString(),
                                itemId = (int)cb_item.SelectedValue,
                                unitName = cb_unit.SelectedItem.ToString(),
                                itemUnitId = (int)cb_unit.SelectedValue,
                                quantity = long.Parse(tb_amount.Text),
                                itemSerial = serialNum,
                                price = price,
                                cause = tb_reasonOfDestroy.Text,
                                invoiceId=0,
                                createUserId = MainWindow.userID,
                            });
                            // اتلاف عنصر يدوياً بدون جرد
                            Window.GetWindow(this).Opacity = 0.2;
                            wd_transItemsLocation w;
                            w = new wd_transItemsLocation();
                            w.orderList = orderList;
                            if (w.ShowDialog() == true)
                            {
                                if (w.selectedItemsLocations != null)
                                {
                                    List<ItemLocation> itemsLocations = w.selectedItemsLocations;
                                    List<ItemLocation> readyItemsLoc = new List<ItemLocation>();

                                    // _ProcessType ="ex";
                                    for (int i = 0; i < itemsLocations.Count; i++)
                                    {
                                        if (itemsLocations[i].isSelected == true)
                                            readyItemsLoc.Add(itemsLocations[i]);
                                    }

                                    invoiceId = await invoiceModel.saveInvoice(invoiceModel);
                                    if (invoiceId != 0)
                                    {
                                        await invoiceModel.saveInvoiceItems(orderList, invoiceId);
                                        for (int i = 0; i < readyItemsLoc.Count; i++)
                                        {
                                            int itemLocId = readyItemsLoc[i].itemsLocId;
                                            int quantity = (int)readyItemsLoc[i].quantity;
                                            await itemLocationModel.decreaseItemLocationQuantity(itemLocId, quantity, MainWindow.userID.Value, "storageAlerts_minMaxItem", not);
                                        }
                                        Btn_clear_Click(null, null);
                                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                                    }
                                    else
                                        Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                                }
                            }
                            Window.GetWindow(this).Opacity = 1;
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
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private async Task refreshDestroyDetails()
        {
            dg_itemDestroy.ItemsSource = null;
            inventoriesItems = await invItemLocModel.GetItemToDestroy(MainWindow.branchID.Value);
            dg_itemDestroy.ItemsSource = inventoriesItems.ToList();
        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (inventoriesItems is null)
                    await RefreshinvItemList();
                searchText = tb_search.Text.ToLower();
                invItemsQuery = inventoriesItems.Where(s => (s.inventoryNum.ToLower().Contains(searchText)
                || s.section.ToLower().Contains(searchText)
                || s.location.ToLower().Contains(searchText)
                || s.itemName.ToLower().Contains(searchText)
                || s.unitName.ToLower().Contains(searchText)
                || s.amount.ToString().ToLower().Contains(searchText)
                )
                //&& s.isActive == tgl_offerState
                );
                RefreshinvItemView();
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

        async Task<IEnumerable<InventoryItemLocation>> RefreshinvItemList()
        {
             inventoriesItems = await invItemLocModel.GetItemToDestroy(MainWindow.branchID.Value);
             return inventoriesItems;
        }
        void RefreshinvItemView()
        {
            dg_itemDestroy.ItemsSource = invItemsQuery;
            txt_count.Text = invItemsQuery.Count().ToString();
        }

        private void Dg_itemDestroy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (dg_itemDestroy.SelectedItem != null)
                {
                    invItemLoc = dg_itemDestroy.SelectedItem as InventoryItemLocation;
                    tb_itemUnit.Visibility = Visibility.Visible;
                    grid_itemUnit.Visibility = Visibility.Collapsed;
                    if (invItemLoc.itemType == "sn")
                        grid_serial.Visibility = Visibility.Visible;
                    tb_amount.IsEnabled = false;
                    this.DataContext = invItemLoc;
                    tgl_manually.IsChecked = false;
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

        private void Btn_pieChart_Click(object sender, RoutedEventArgs e)
        {//pie
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (invItemsQuery != null)
                    {
                        Window.GetWindow(this).Opacity = 0.2;
                        win_Storagelvc win = new win_Storagelvc(invItemsQuery, 1);
                        win.ShowDialog();
                        Window.GetWindow(this).Opacity = 1;
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


        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                SectionData.InputJustNumber(ref textBox);
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_item_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                cb_item.ItemsSource = items.Where(x => x.name.Contains(cb_item.Text));
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            if (invItemLoc != null)
                invItemLoc.id = 0;
            _ItemType = "";
            DataContext = new InventoryItemLocation();
            cb_item.SelectedIndex =
            cb_unit.SelectedIndex = -1;
            grid_serial.Visibility = Visibility.Collapsed;
            tb_notes.Clear();
            tb_reasonOfDestroy.Clear();
            tb_notes.Clear();
            invoiceModel = new Invoice();
        }
        private void Tgl_IsActive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                Btn_clear_Click(null, null);

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

        private void Tgl_IsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                dg_itemDestroy.SelectedItem = null;
                Btn_clear_Click(null, null);
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

        private void Btn_clearSerial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _serialCount = 0;
                lst_serials.Items.Clear();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        void tglManuallyChecking()
        {
            if (tgl_manually.IsChecked == true)
            {
                tb_itemUnit.Visibility = Visibility.Collapsed;
                grid_itemUnit.Visibility = Visibility.Visible;
                tb_amount.IsEnabled = true;
            }
            else
            {
                tb_itemUnit.Visibility = Visibility.Visible;
                grid_itemUnit.Visibility = Visibility.Collapsed;
            }
            grid_serial.Visibility = Visibility.Collapsed;

            Btn_clear_Click(null, null);
        }
        private void Tgl_manually_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                tglManuallyChecking();
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

        private void Tgl_manually_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                tglManuallyChecking();
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

        private void Tb_serialNum_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (e.Key == Key.Return && !tb_amount.Text.Equals(""))
                {
                    string s = tb_serialNum.Text;
                    int itemCount = int.Parse(tb_amount.Text);

                    if (!s.Equals(""))
                    {
                        int found = lst_serials.Items.IndexOf(s);

                        if (_serialCount == itemCount)
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trWarningItemCountIs:") + " " + itemCount, animation: ToasterAnimation.FadeIn);
                        }
                        else if (found == -1)
                        {
                            lst_serials.Items.Add(tb_serialNum.Text);
                            _serialCount++;
                        }
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trWarningSerialExists"), animation: ToasterAnimation.FadeIn);
                    }
                    tb_serialNum.Clear();
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
        private async Task recordCash(Invoice invoice)
        {
            User user = new User();
            float newBalance = 0;
            user = await user.getUserById((int)cb_user.SelectedValue);

            CashTransfer cashTrasnfer = new CashTransfer();
            cashTrasnfer.posId = MainWindow.posID;
            cashTrasnfer.userId = (int)cb_user.SelectedValue;
            cashTrasnfer.invId = invoice.invoiceId;
            cashTrasnfer.createUserId = invoice.createUserId;
            cashTrasnfer.processType = "balance";
            cashTrasnfer.side = "u"; // user
            cashTrasnfer.transType = "d"; //deposit
            cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("du");

            if (user.balanceType == 0)
            {
                if (invoice.totalNet <= (decimal)user.balance)
                {
                    invoice.paid = invoice.totalNet;
                    invoice.deserved = 0;
                    newBalance = user.balance - (float)invoice.totalNet;
                    user.balance = newBalance;
                }
                else
                {
                    invoice.paid = (decimal)user.balance;
                    invoice.deserved = invoice.totalNet - (decimal)user.balance;
                    newBalance = (float)invoice.totalNet - user.balance;
                    user.balance = newBalance;
                    user.balanceType = 1;
                }

                cashTrasnfer.cash = invoice.paid;

                await invoice.saveInvoice(invoice);
                await cashTrasnfer.Save(cashTrasnfer); //add cash transfer
                await user.save(user);
            }
            else if (user.balanceType == 1)
            {
                newBalance = user.balance + (float)invoice.totalNet;
                user.balance = newBalance;
                await user.save(user);
            }
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                Btn_clear_Click(null, null);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                //SectionData.ExceptionMessage(ex, this);
            }
        }
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    if (invItemsQuery != null)
                    {
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Store\Ar\ArDestroyReport.rdlc";
                        }
                        else addpath = @"\Reports\Store\EN\DestroyReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        ReportCls.checkLang();

                        clsReports.invItem(invItemsQuery, rep, reppath, paramarr);
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

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    if (invItemsQuery != null)
                    {
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Store\Ar\ArDestroyReport.rdlc";
                        }
                        else addpath = @"\Reports\Store\EN\DestroyReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        ReportCls.checkLang();

                        clsReports.invItem(invItemsQuery, rep, reppath, paramarr);
                        clsReports.setReportLanguage(paramarr);
                        clsReports.Header(paramarr);

                        rep.SetParameters(paramarr);
                        rep.Refresh();
                        LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
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
        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    if (invItemsQuery != null)
                    {
                        Window.GetWindow(this).Opacity = 0.2;
                        string pdfpath = "";

                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        pdfpath = @"\Thumb\report\temp.pdf";
                        pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Store\Ar\ArDestroyReport.rdlc";
                        }
                        else addpath = @"\Reports\Store\EN\DestroyReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        ReportCls.checkLang();

                        clsReports.invItem(invItemsQuery, rep, reppath, paramarr);
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

        
    }
}

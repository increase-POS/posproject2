using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
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

namespace POS.View.storage
{
    /// <summary>
    /// Interaction logic for uc_itemsShortage.xaml
    /// </summary>
    public partial class uc_itemsShortage : UserControl
    {
        private static uc_itemsShortage _instance;
        public static uc_itemsShortage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_itemsShortage();
                return _instance;
            }
        }
        public uc_itemsShortage()
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
        string savePermission = "shortage_save";
        string reportsPermission = "shortage_reports";


        InventoryItemLocation invItemLocModel = new InventoryItemLocation();
        InventoryItemLocation invItemLoc = new InventoryItemLocation();
        ItemLocation itemLocationModel = new ItemLocation();
        Invoice invoiceModel = new Invoice();
        Branch branchModel = new Branch();
        Inventory inventory;
        IEnumerable<InventoryItemLocation> inventoriesItems;
        User userModel = new User();
        List<User> users;

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
                await refreshShortageDetails();
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
        IEnumerable<Item> items;
        // item object
        Item item = new Item();
        ItemUnit itemUnit = new ItemUnit();
        async Task<IEnumerable<Item>> RefrishItems()
        {
            items = await item.GetItemsWichHasUnits();
            return items;
        }

        private void translate()
        {

            ////////////////////////////////----Grid----/////////////////////////////////
            dg_itemShortage.Columns[0].Header = MainWindow.resourcemanager.GetString("trInventoryNum");
            dg_itemShortage.Columns[1].Header = MainWindow.resourcemanager.GetString("trDate");
            dg_itemShortage.Columns[2].Header = MainWindow.resourcemanager.GetString("trSectionLocation");
            dg_itemShortage.Columns[3].Header = MainWindow.resourcemanager.GetString("trItemUnit");
            dg_itemShortage.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");

            txt_itemsShortageHeader.Text = MainWindow.resourcemanager.GetString("trItemShortage");
            txt_shortage.Text = MainWindow.resourcemanager.GetString("trShortage");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_itemUnit, MainWindow.resourcemanager.GetString("trItemHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_amount, MainWindow.resourcemanager.GetString("trAmountShortageedHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_user, MainWindow.resourcemanager.GetString("trUserHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_reasonOfShortage, MainWindow.resourcemanager.GetString("trReasonOfShortageHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");

            btn_shortage.Content = MainWindow.resourcemanager.GetString("trShortage");
            btn_refresh.ToolTip = MainWindow.resourcemanager.GetString("trRefresh");

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
        {//excel
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    if (invItemsQuery != null)
                    {
                        Thread t1 = new Thread(() =>
                    {
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Store\Ar\ArShortageReport.rdlc";
                        }
                        else addpath = @"\Reports\Store\EN\ShortageReport.rdlc";
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
                    });
                        t1.Start();
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
                    if ((sender as TextBox).Name == "tb_reasonOfShortage")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorReasonOfShortage, tt_errorReasonOfShortage, "trEmptyReasonToolTip");
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
            SectionData.validateEmptyTextBox(tb_reasonOfShortage, p_errorReasonOfShortage, tt_errorReasonOfShortage, "trEmptyReasonToolTip");
            if (tb_reasonOfShortage.Text.Equals(""))
            {
                valid = false;
                return valid;
            }

            if (int.Parse(tb_amount.Text) < lst_serials.Items.Count)
            {
                valid = false;
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorSerialMoreItemCountToolTip"), animation: ToasterAnimation.FadeIn);
            }
            return valid;
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
        private async void Btn_shortage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(savePermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (invItemLoc.id != 0)
                    {
                        bool valid = validateDistroy();
                        if (valid)
                        {
                            int itemUnitId = 0;
                            int itemId = 0;
                            int invoiceId = 0;
                            string serialNum = "";

                            itemUnitId = invItemLoc.itemUnitId;
                            itemId = invItemLoc.itemId;
                            invItemLoc.notes = tb_notes.Text;
                            invItemLoc.fallCause = tb_reasonOfShortage.Text;
                            #region add invoice

                            decimal price = await invoiceModel.GetAvgItemPrice(itemUnitId, itemId);
                            price = Math.Round(price, 2);
                            decimal total = price * int.Parse(tb_amount.Text);

                            invoiceModel.invNumber = await invoiceModel.generateInvNumber("sh", branchModel.code, MainWindow.branchID.Value);
                            invoiceModel.branchCreatorId = MainWindow.branchID.Value;
                            invoiceModel.posId = MainWindow.posID.Value;
                            invoiceModel.createUserId = MainWindow.userID.Value;
                            invoiceModel.invType = "sh"; // shortage
                            invoiceModel.total = total;
                            invoiceModel.totalNet = total;
                            invoiceModel.paid = 0;
                            invoiceModel.deserved = invoiceModel.totalNet;
                            invoiceModel.notes = tb_notes.Text;
                            
                            if (cb_user.SelectedIndex != -1 && cb_user.SelectedIndex != 0)
                                invoiceModel.userId = (int)cb_user.SelectedValue;
                            #endregion

                            List<ItemTransfer> orderList = new List<ItemTransfer>();
                            int amount = await itemLocationModel.getAmountByItemLocId((int)invItemLoc.itemLocationId);
                            if (amount >= invItemLoc.amount)
                            {
                                if (_ItemType == "sn")
                                    serialNum = tb_serialNum.Text;

                                if (lst_serials.Items.Count > 0)
                                {
                                    for (int j = 0; j < lst_serials.Items.Count; j++)
                                    {
                                        serialNum += lst_serials.Items[j];
                                        if (j != lst_serials.Items.Count - 1)
                                            serialNum += ",";
                                    }
                                }

                                orderList.Add(new ItemTransfer()
                                {
                                    itemName = invItemLoc.itemName,
                                    itemId = invItemLoc.itemId,
                                    unitName = invItemLoc.unitName,
                                    itemUnitId = invItemLoc.itemUnitId,
                                    quantity = invItemLoc.amount,
                                    itemSerial = serialNum,
                                    price = price,
                                    invoiceId = 0,
                                    inventoryItemLocId = invItemLoc.id,
                                    createUserId = MainWindow.userID,
                                });
                                invoiceId = int.Parse(await invoiceModel.saveInvoice(invoiceModel));
                                if (invoiceId != 0)
                                {
                                    invoiceModel.invoiceId = invoiceId;
                                    await invoiceModel.saveInvoiceItems(orderList, invoiceId);
                                    await invItemLoc.fallItem(invItemLoc);
                                    if (cb_user.SelectedIndex != -1 && cb_user.SelectedIndex != 0)
                                        await recordCash(invoiceModel);
                                    await refreshShortageDetails();
                                    Btn_clear_Click(null, null);
                                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                                }
                                else
                                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                            }
                            else
                            {
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trShortageAmountMoreExist"), animation: ToasterAnimation.FadeIn);
                            }
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

        private async Task refreshShortageDetails()
        {
            inventoriesItems = await invItemLocModel.GetShortageItem(MainWindow.branchID.Value);
            dg_itemShortage.ItemsSource = inventoriesItems;
        }
        async Task<IEnumerable<InventoryItemLocation>> RefreshinvItemList()
        {
            inventoriesItems = await invItemLocModel.GetShortageItem(MainWindow.branchID.Value);
            return inventoriesItems;
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //search       

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

        void RefreshinvItemView()
        {
            dg_itemShortage.ItemsSource = invItemsQuery;
            txt_count.Text = invItemsQuery.Count().ToString();
        }
        private void Dg_itemShortage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (dg_itemShortage.SelectedItem != null)
                {
                    invItemLoc = dg_itemShortage.SelectedItem as InventoryItemLocation;
                    tb_itemUnit.Visibility = Visibility.Visible;
                    if (invItemLoc.itemType == "sn")
                        grid_serial.Visibility = Visibility.Visible;
                    tb_amount.IsEnabled = false;
                    this.DataContext = invItemLoc;
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


        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (invItemLoc != null)
                    invItemLoc.id = 0;
                _ItemType = "";
                cb_user.SelectedIndex = -1;
                DataContext = new InventoryItemLocation();
                grid_serial.Visibility = Visibility.Collapsed;
                tb_notes.Clear();
                tb_reasonOfShortage.Clear();
                tb_notes.Clear();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
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


                dg_itemShortage.SelectedItem = null;
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
                SectionData.ExceptionMessage(ex, this);
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
                            addpath = @"\Reports\Store\Ar\ArShortageReport.rdlc";
                        }
                        else addpath = @"\Reports\Store\EN\ShortageReport.rdlc";
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
                            addpath = @"\Reports\Store\Ar\ArShortageReport.rdlc";
                        }
                        else addpath = @"\Reports\Store\EN\ShortageReport.rdlc";
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
                            addpath = @"\Reports\Store\Ar\ArShortageReport.rdlc";
                        }
                        else addpath = @"\Reports\Store\EN\ShortageReport.rdlc";
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

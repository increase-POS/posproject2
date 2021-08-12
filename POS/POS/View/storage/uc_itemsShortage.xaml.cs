using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
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
            InitializeComponent();
        }
        string savePermission = "shortage_save";
        string reportsPermission = "shortage_reports";
        
       
        InventoryItemLocation invItemLocModel = new InventoryItemLocation();
        InventoryItemLocation invItemLoc = new InventoryItemLocation();
        ItemLocation itemLocationModel = new ItemLocation();
        Invoice invoiceModel = new Invoice();
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

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucItemsShortage.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucItemsShortage.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            await refreshShortageDetails();
            await fillUsers();

            //for excel
            //await RefreshinvItemList();
            Tb_search_TextChanged(null, null);
        }
        private async Task fillUsers()
        {
            users = await userModel.GetUsersActive();
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
            MainWindow.mainWindow.StartAwait();
            items = await item.GetItemsWichHasUnits();

            MainWindow.mainWindow.EndAwait();
            return items;
        }
      
        private void translate()
        {
            txt_itemsShortageHeader.Text = MainWindow.resourcemanager.GetString("trItemShortage");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_itemUnit, MainWindow.resourcemanager.GetString("trItemUnitHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_amount, MainWindow.resourcemanager.GetString("trAmountHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_user, MainWindow.resourcemanager.GetString("trUserHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_reasonOfShortage, MainWindow.resourcemanager.GetString("trReasonOfShortageHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));

            dg_itemShortage.Columns[0].Header = MainWindow.resourcemanager.GetString("trInventoryNum");
            dg_itemShortage.Columns[1].Header = MainWindow.resourcemanager.GetString("trDate");
            dg_itemShortage.Columns[2].Header = MainWindow.resourcemanager.GetString("trSectionLocation");
            dg_itemShortage.Columns[3].Header = MainWindow.resourcemanager.GetString("trItemUnit");
            dg_itemShortage.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");

            tt_itemUnit.Content = MainWindow.resourcemanager.GetString("trItemUnit");
            tt_amount.Content = MainWindow.resourcemanager.GetString("trAmount");
            tt_user.Content = MainWindow.resourcemanager.GetString("trUser");
            tt_reasonOfShortage.Content = MainWindow.resourcemanager.GetString("trReasonOfShortage");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

            btn_shortage.Content = MainWindow.resourcemanager.GetString("trShortage");

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export to excel
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {

                this.Dispatcher.Invoke(() =>
                {
                    Thread t1 = new Thread(FN_ExportToExcel);
                    t1.SetApartmentState(ApartmentState.STA);
                    t1.Start();
                });
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
            string name = sender.GetType().Name;
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_reasonOfShortage")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorReasonOfShortage, tt_errorReasonOfShortage, "trEmptyReasonToolTip");
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
            //if (invItemLoc == null || invItemLoc.id == 0)
            //{
            //    SectionData.validateEmptyComboBox(cb_item, p_errorItem, tt_errorItem, "trEmptyItemToolTip");
            //    SectionData.validateEmptyComboBox(cb_unit, p_errorUnit, tt_errorUnit, "trErrorEmptyUnitToolTip");
            //    if (cb_item.SelectedIndex == -1 || cb_unit.SelectedIndex == -1)
            //    {
            //        valid = false;
            //        return valid;
            //    }
            //}
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
                await user.saveUser(user);
            }
            else if (user.balanceType == 1)
            {
                newBalance = user.balance + (float)invoice.totalNet;
                user.balance = newBalance;
                await user.saveUser(user);
            }
        }
        private async void Btn_shortage_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(savePermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
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

                    invoiceModel.invNumber = await invoiceModel.generateInvNumber("sh");
                    invoiceModel.branchCreatorId = MainWindow.branchID.Value;
                    invoiceModel.posId = MainWindow.posID.Value;
                    invoiceModel.createUserId = MainWindow.userID.Value;
                    invoiceModel.invType = "sh"; // shortage
                    invoiceModel.total = total;
                    invoiceModel.totalNet = total;
                    invoiceModel.paid = 0;
                    invoiceModel.deserved = invoiceModel.totalNet;
                    invoiceModel.notes = tb_notes.Text;
                    if (cb_user.SelectedIndex != -1)
                        invoiceModel.userId = (int)cb_user.SelectedValue;
                        #endregion

                    //    #region add shortage inventory
                    //    inventory = new Inventory();
                    //inventory.inventoryType = "sh";
                    //inventory.num = await inventory.generateInvNumber("sh");
                    //inventory.mainInventoryId = invItemLoc.inventoryId;
                    //inventory.branchId = MainWindow.branchID.Value;
                    //inventory.createUserId = MainWindow.userID.Value;
                    //inventory.posId = MainWindow.posID.Value;
                    //int invId = await inventory.Save(inventory);
                    //if (invId != 0)
                    //{
                    //    List<InventoryItemLocation> invItemsLocations = new List<InventoryItemLocation>();
                    //    invItemLocModel = new InventoryItemLocation();
                    //    invItemLocModel.amount = invItemLoc.amount;
                    //    invItemLocModel.itemUnitId = invItemLoc.itemUnitId;
                    //    invItemLocModel.itemLocationId = invItemLoc.itemLocationId;
                    //    invItemLocModel.inventoryId = invId;
                    //    invItemLocModel.createUserId = MainWindow.userID.Value;
                    //    invItemLocModel.fallCause = tb_reasonOfShortage.Text;
                        
                        
                    //    invItemsLocations.Add(invItemLocModel);

                    //    string res = await invItemLocModel.Save(invItemsLocations, invId);
                    //}
                    //#endregion
                    if (invItemLoc.id != 0)
                    {
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
                                inventoryItemLocId = invItemLoc.id,
                                createUserId = MainWindow.userID,
                            });
                            invoiceId = int.Parse(await invoiceModel.saveInvoice(invoiceModel));
                            if (invoiceId != 0)
                            {
                                invoiceModel.invoiceId = invoiceId;
                                await invoiceModel.saveInvoiceItems(orderList, invoiceId);
                                await invItemLoc.fallItem(invItemLoc);
                                if (cb_user.SelectedIndex != -1)
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
          
        }
        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            await refreshShortageDetails();
            await fillUsers();
            Tb_search_TextChanged(null, null);

        }
        private async Task refreshShortageDetails()
        {
            inventoriesItems = await invItemLocModel.GetShortageItem(MainWindow.branchID.Value);
            dg_itemShortage.ItemsSource = inventoriesItems;
        }
        async Task<IEnumerable<InventoryItemLocation>> RefreshinvItemList()
        {
            MainWindow.mainWindow.StartAwait();
            inventoriesItems = await invItemLocModel.GetShortageItem(MainWindow.branchID.Value);
            MainWindow.mainWindow.EndAwait();
            return inventoriesItems;
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search       

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
        }
        /*
        async Task<IEnumerable<InventoryItemLocation>> RefreshinvItemList()
        {
            MainWindow.mainWindow.StartAwait();
            inventoriesItems = await invItemLocModel.GetItemShortage(MainWindow.branchID.Value);
            MainWindow.mainWindow.EndAwait();
            return inventoriesItems;
        }
        */
        void RefreshinvItemView()
        {
            dg_itemShortage.ItemsSource = invItemsQuery;
            txt_count.Text = invItemsQuery.Count().ToString();
        }
        private void Dg_itemShortage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_itemShortage.SelectedItem != null)
            {
                invItemLoc = dg_itemShortage.SelectedItem as InventoryItemLocation;
                tb_itemUnit.Visibility = Visibility.Visible;
                if (invItemLoc.itemType == "sn")
                    grid_serial.Visibility = Visibility.Visible;
                tb_amount.IsEnabled = false;
                this.DataContext = invItemLoc;
            }
        }
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private void Btn_pieChart_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private void btn_shortage_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void Cb_itemUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Cb_itemUnit_KeyUp(object sender, KeyEventArgs e)
        {
            //cb_itemUnit.ItemsSource = items.Where(x => x.name.Contains(cb_itemUnit.Text));
        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {

            if (invItemLoc != null)
                invItemLoc.id = 0;
            _ItemType = "";
            DataContext = new InventoryItemLocation();
            grid_serial.Visibility = Visibility.Collapsed;
            tb_notes.Clear();
            tb_reasonOfShortage.Clear();
            tb_notes.Clear();
        }
        private void Tgl_IsActive_Checked(object sender, RoutedEventArgs e)
        {
            Btn_clear_Click(null, null);

        }

        private void Tgl_IsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            dg_itemShortage.SelectedItem = null;
            Btn_clear_Click(null, null);
        }
        private void Btn_clearSerial_Click(object sender, RoutedEventArgs e)
        {
            _serialCount = 0;
            lst_serials.Items.Clear();
        }
        
        private void Tb_serialNum_KeyDown(object sender, KeyEventArgs e)
        {
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
        }

        private void Tb_amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txb = sender as TextBox;
            if ((sender as TextBox).Name == "tb_amount")
                SectionData.InputJustNumber(ref txb);
        }
    }
}

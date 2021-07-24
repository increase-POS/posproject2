using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            InitializeComponent();
        }
        Category categoryModel = new Category();
        Category category = new Category();
        IEnumerable<Category> categories;
        InventoryItemLocation invItemLoc = new InventoryItemLocation();
        ItemLocation itemLocationModel = new ItemLocation();
        Invoice invoiceModel = new Invoice();
        IEnumerable<InventoryItemLocation> inventoriesItems;
        int? categoryParentId = 0;


        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;


        private async  void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucItemsDestroy.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucItemsDestroy.FlowDirection = FlowDirection.RightToLeft;
            }
           
            translate();
            await refreshDestroyDetails();
            fillItemCombo();
            //Txb_searchitems_TextChanged(null, null);
        }
        IEnumerable<Item> items;
        // item object
        Item item = new Item();
        ItemUnit itemUnit = new ItemUnit();
        private async void Cb_item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_item.SelectedValue != null)
                if (int.Parse(cb_item.SelectedValue.ToString()) != -1)
                { 
            var list = await itemUnit.GetItemUnits(int.Parse(cb_item.SelectedValue.ToString()));
            cb_unit.ItemsSource = list;
            cb_unit.SelectedValue = "unitId";
            cb_unit.DisplayMemberPath = "mainUnit";
            cb_unit.SelectedIndex = 0;
                }
        }

        async Task<IEnumerable<Item>> RefrishItems()
        {
            MainWindow.mainWindow.StartAwait();
            items = await item.GetAllItems();
            items = items.Where(x => x.isActive == 1);
            MainWindow.mainWindow.EndAwait();
            return items;
        }
        private async void fillItemCombo()
        {
            if (items is null)
                await RefrishItems();
            var listCa = items.Where(x => x.isActive == 1).ToList();
            cb_item.ItemsSource = listCa;
            cb_item.SelectedValuePath = "itemId";
            cb_item.DisplayMemberPath = "name";
        }

        private void translate()
        {


        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

      
        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        #endregion

        private bool validateDistroy()
        {
            bool valid = true;
            if (tb_reasonOfDestroy.Text.Equals(""))
                valid = false;
            return valid;
        }
        private async void Btn_destroy_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(destroyPermission, MainWindow.groupObjects, "one"))
            {
                bool valid = validateDistroy();
            if(invItemLoc.id != 0 && valid)
            {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_transItemsLocation w;
                    w = new wd_transItemsLocation();
                    decimal price = await invoiceModel.GetAvgItemPrice(invItemLoc.itemUnitId, invItemLoc.itemId); 
                    List<ItemTransfer> orderList = new List<ItemTransfer>();
                    orderList.Add(new ItemTransfer()
                    {
                        itemName = invItemLoc.itemName,
                        itemId = invItemLoc.itemId,
                        unitName = invItemLoc.unitName,
                        itemUnitId = invItemLoc.itemUnitId,
                        quantity = invItemLoc.quantity,
                        price = price,
                    }) ;

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

                            invoiceModel.invNumber = await invoiceModel.generateInvNumber("ds");
                            invoiceModel.branchCreatorId = MainWindow.branchID.Value;
                            invoiceModel.posId = MainWindow.posID.Value;
                            invoiceModel.createUserId = MainWindow.userID.Value;
                            invoiceModel.invType = "d"; // destroy
                            //  invoiceModel.total = ;
                            // invoiceModel.totalNet = ;
                            invoiceModel.paid = 0;
                            invoiceModel.deserved = invoiceModel.totalNet;
                            invoiceModel.notes = tb_notes.Text;

                            int invoiceId = int.Parse( await invoiceModel.saveInvoice(invoiceModel));
                            if (invoiceId != 0)
                            {
                                await invoiceModel.saveInvoiceItems(orderList, invoiceId);
                                await itemLocationModel.destroyItem(readyItemsLoc, MainWindow.userID.Value);
                            }
                           // await save();
                        }
                    }
                    Window.GetWindow(this).Opacity = 1;
                    await invItemLoc.distroyItem(invItemLoc);
                await refreshDestroyDetails();
            }
            else
            {
                // اتلاف عنصر يدوياً بدون جرد
            }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }
        private async Task refreshDestroyDetails()
        {
            inventoriesItems = await invItemLoc.GetItemToDestroy(MainWindow.branchID.Value);
            dg_itemDestroy.ItemsSource = inventoriesItems;
        }
        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            if (name == "TextBox")
            {
            }
            else if (name == "ComboBox")
            {
            }
            else
            {

            }
        }

        private void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Dg_itemDestroy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            invItemLoc = dg_itemDestroy.SelectedItem as InventoryItemLocation;
            tb_itemUnit.Visibility = Visibility.Visible;
            grid_itemUnit.Visibility = Visibility.Collapsed;
            this.DataContext = invItemLoc;
            
        }

        private void Tgl_IsActive_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_IsActive_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private void Btn_pieChart_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private void btn_destroy_Click_1(object sender, RoutedEventArgs e)
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

        private void Cb_item_KeyUp(object sender, KeyEventArgs e)
        {
            cb_item.ItemsSource = items.Where(x => x.name.Contains(cb_item.Text));
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            tb_itemUnit.Visibility = Visibility.Collapsed;
            grid_itemUnit.Visibility = Visibility.Visible ;
            if (invItemLoc!= null)
            invItemLoc.id = 0;
            DataContext = new InventoryItemLocation();
            cb_item.SelectedIndex =
            cb_unit.SelectedIndex = -1;
        }
    } 
}

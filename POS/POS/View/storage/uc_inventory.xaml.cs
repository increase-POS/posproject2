using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
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

        string _InventoryType = "d";
        string createInventoryPermission = "inventory_createInventory";
        string archivingPermission = "inventory_archiving";
        string reportsPermission = "inventory_reports";
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
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", assembly: Assembly.GetExecutingAssembly());
                grid_ucItemsExport.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucItemsExport.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            await fillInventoryDetails();
        }
        private void translate()
        {
            ////////////////////////////////----Order----/////////////////////////////////
            dg_items.Columns[0].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_items.Columns[1].Header = MainWindow.resourcemanager.GetString("trSectionLocation");
            dg_items.Columns[2].Header = MainWindow.resourcemanager.GetString("trItemUnit");
            dg_items.Columns[3].Header = MainWindow.resourcemanager.GetString("trRealAmount");
            dg_items.Columns[4].Header = MainWindow.resourcemanager.GetString("trInventoryAmount");
            dg_items.Columns[5].Header = MainWindow.resourcemanager.GetString("trDestoryCount");
        }
        private async Task fillInventoryDetails()
        {
            int sequence = 0;
            invItemsLocations.Clear();
            if (inventory.inventoryId == 0)
            {
                string num = await inventory.generateInvNumber("in", MainWindow.posID.Value);
                txt_inventoryNum.Text = num;
                txt_inventoryDate.Text = DateTime.Now.ToString();
                itemsLocations = await itemLocationModel.get(MainWindow.branchID.Value);
                foreach(ItemLocation il in itemsLocations)
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
            inputEditable();
            dg_items.ItemsSource = invItemsLocations.ToList();
        }
        private void inputEditable()
        {
            if (_InventoryType == "d") // draft
            {
                dg_items.Columns[4].IsReadOnly = false; 
                dg_items.Columns[5].IsReadOnly = false;            
                btn_save.IsEnabled = true;
            }
            else if (_InventoryType == "n") // normal saved
            {
                dg_items.Columns[4].IsReadOnly = true; 
                dg_items.Columns[5].IsReadOnly = true; 
                btn_save.IsEnabled = false;
            }
        }
            private void Dg_items_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBox t = new TextBox();
            ItemLocation row = e.Row.Item as ItemLocation;
            var index = e.Row.GetIndex();
            if (dg_items.SelectedIndex != -1 && index < itemsLocations.Count)
            {
                var columnName = e.Column.Header.ToString();
                t = e.EditingElement as TextBox;
                if (t != null &&  columnName == MainWindow.resourcemanager.GetString("trDestoryCount"))
                {
                    int destroyCount = int.Parse(t.Text);
                    if (destroyCount > itemsLocations[index].quantity)
                    {
                        t.Text = "0";
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorDistroyMoreQuanToolTip"), animation: ToasterAnimation.FadeIn);
                    }

                }
            }
        }
        private async Task clearInventory()
        {
            _InventoryType = "d";
            string num = await inventory.generateInvNumber("in", MainWindow.posID.Value);
            inventory = new Inventory();
            txt_inventoryDate.Text = DateTime.Now.ToString();
            txt_inventoryNum.Text = num;
            inputEditable();
           await fillInventoryDetails();
        }
        private async Task addInventory(string invType)
        {
            if(inventory.inventoryId == 0)
            {
                inventory.num = txt_inventoryNum.Text;
                inventory.branchId = MainWindow.branchID.Value;
                inventory.posId = MainWindow.posID.Value;
                inventory.createUserId = MainWindow.userLogin.userId;
            }           
            inventory.inventoryType = invType;            
            inventory.updateUserId = MainWindow.userLogin.userId;

            int inventoryId = await inventory.Save(inventory);

            if(inventoryId != 0)
            {
                // add inventory details
                string res =  await invItemModel.Save(invItemsLocations,inventoryId);
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
               await clearInventory();
            }
            else
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
        }
        private async void Btn_newInventory_Click(object sender, RoutedEventArgs e)
        {
            if (!_InventoryType.Equals("n"))
                await addInventory("d"); // d:draft
            else
                await clearInventory();
        }
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_inventory w = new wd_inventory();

            w.inventoryType = "d";
            w.userId = MainWindow.userLogin.userId;

            w.title = MainWindow.resourcemanager.GetString("trDrafts");

            if (w.ShowDialog() == true)
            {
                if (w.inventory != null)
                {
                    inventory = w.inventory;
                    _InventoryType = "d";
                    await fillInventoryDetails();
                }
            }
            Window.GetWindow(this).Opacity = 1;
        }
        private async void Btn_Inventory_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_inventory w = new wd_inventory();

            w.inventoryType = "n";
            w.branchId = MainWindow.branchID.Value;
            w.title = MainWindow.resourcemanager.GetString("trDrafts");

            if (w.ShowDialog() == true)
            {
                if (w.inventory != null)
                {
                    _InventoryType = "n";
                    inventory = w.inventory;
                    await fillInventoryDetails();  
                }
            }
            Window.GetWindow(this).Opacity = 1;
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(createInventoryPermission, MainWindow.groupObjects, "one"))
                await addInventory("n"); // n:normal
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private async void Btn_archive_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(archivingPermission, MainWindow.groupObjects, "one"))
                await addInventory("a"); // a:archived
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private void Btn_Images_Click(object sender, RoutedEventArgs e)
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
        private void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
            {

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one"))
                {

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
    }
}

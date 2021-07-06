using POS.Classes;
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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_inventory.xaml
    /// </summary>
    public partial class wd_inventory : Window
    {
        public wd_inventory()
        {
            InitializeComponent();
        }
        public Inventory inventory = new Inventory();
        IEnumerable<Inventory> inventories;
        public int branchId { get; set; }
        public int userId { get; set; }
        public string inventoryType { get; set; }
        /// <summary>
        /// for filtering inventory type
        /// </summary>
        public string title { get; set; }
        private void Btn_select_Click(object sender, RoutedEventArgs e)
        {

            inventory = dg_Inventory.SelectedItem as Inventory;
            DialogResult = true;
            this.Close();

        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_select_Click(null, null);
            }
        }
        private void Txb_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucInventory.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucInventory.FlowDirection = FlowDirection.RightToLeft;
            }
            txt_title.Text = title;
            await refreshInventories();

        }
        private async Task refreshInventories()
        {
            if (userId != 0)/// to display draft invoices
                inventories = await inventory.GetByCreator(inventoryType, userId);
            else if (branchId != 0)
                inventories = await inventory.getByBranch(inventoryType, branchId);
            //else if (condition == "" || condition == null)
            //    invoices = await invoice.GetInvoicesByType(invoiceType, branchId);
            //else // get export/ import orders
            //    invoices = await invoice.GetOrderByType(invoiceType, branchId);


            dg_Inventory.ItemsSource = inventories.ToList();
        }

        private void Dg_Inventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            inventory = dg_Inventory.SelectedItem as Inventory;
        }
        private void Dg_Inventory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_select_Click(null, null);
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {

            // DialogResult = true;
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }
    }
}

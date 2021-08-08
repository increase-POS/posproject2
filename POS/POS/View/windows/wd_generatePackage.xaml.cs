using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using netoaster;
using POS.Classes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_generatePackage.xaml
    /// </summary>
    public partial class wd_generatePackage : Window
    {
        public wd_generatePackage()
        {
            InitializeComponent();
        }
        IEnumerable<Item> items;
        Item item = new Item();
        IEnumerable<Location> locations;
        Location location = new Location();
        ItemLocation itemLocation = new ItemLocation();
        Package package = new Package();
        List<Package> packages;
        private void Cb_item_KeyUp(object sender, KeyEventArgs e)
        {
            cb_item.ItemsSource = items.Where(x => x.name.Contains(cb_item.Text));
        }
        private async void fillItemCombo()
        {
            items = await item.GetItemsByType("p");     // return items with type = package     
            cb_item.ItemsSource = items;
            cb_item.SelectedValuePath = "itemId";
            cb_item.DisplayMemberPath = "name";
        }
        private async void fillLocationCombo()
        {
            locations = await location.GetLocsByBranchId(MainWindow.branchID.Value);      
            cb_location.ItemsSource = locations;
            cb_location.SelectedValuePath = "locationId";
            cb_location.DisplayMemberPath = "name";
        }
        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_quantity, p_errorQuantity, tt_errorQuantity, "trEmptyQuantityToolTip");

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private async void tb_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_quantity, p_errorQuantity, tt_errorQuantity, "trEmptyQuantityToolTip");
            bool validQan = await checkAmount();

        }
        private async Task<bool> checkAmount()
        {
            bool valid = true;
            int quantity = int.Parse(tb_quantity.Text);
            if(cb_item.SelectedIndex != -1 && quantity > 0)
            {
                ItemUnit itemUnit = new ItemUnit();
                List< ItemUnit> itemUnits = new List<ItemUnit>();
                itemUnits = await itemUnit.GetItemUnits((int)cb_item.SelectedValue);
                int itemUnitId = itemUnits[0].itemUnitId;

                packages = await package.GetChildsByParentId(itemUnitId);
                foreach(Package p in packages)
                {
                    int branchQuantity = 0;
                    int itemQuanP = p.quantity;
                    itemUnitId = (int)p.childIUId;
                    int requireQuan = itemQuanP * quantity;

                    if (cb_location.SelectedIndex == -1)
                        branchQuantity = await itemLocation.getUnitAmount(itemUnitId, MainWindow.branchID.Value);
                    else
                        branchQuantity = await itemLocation.getAmountInLocation(itemUnitId,MainWindow.branchID.Value,(int) cb_location.SelectedValue);

                    if (requireQuan > branchQuantity)
                    {
                        valid = false;                      
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorItemAmntNotAvailableToolTip")+" "+p.childIUId, animation: ToasterAnimation.FadeIn);
                        return valid;
                    }

                }
            }
            return valid;
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }
        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
            }

            translate();
            fillItemCombo();
            fillLocationCombo();
        }
        private void translate()
        {


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

        private async void Cb_location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cb_location.SelectedIndex != -1)
            {
               await checkAmount();
            }
        }
    }
}

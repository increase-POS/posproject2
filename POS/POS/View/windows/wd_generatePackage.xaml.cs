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
        private static int _PackageParentId;
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
            var txb = sender as TextBox;
            if ((sender as TextBox).Name == "tb_quantity")
                SectionData.InputJustNumber(ref txb);

        }
        private async Task<bool> checkAmount()
        {
            bool valid = true;
            int quantity = 0;
            if(!tb_quantity.Text.Equals(""))
                quantity= int.Parse(tb_quantity.Text);
            if(cb_item.SelectedIndex != -1 && quantity > 0)
            {
                ItemUnit itemUnit = new ItemUnit();
                List< ItemUnit> itemUnits = new List<ItemUnit>();
                itemUnits = await itemUnit.GetItemUnits((int)cb_item.SelectedValue);
                _PackageParentId = itemUnits[0].itemUnitId;
                int itemUnitId = 0;
                packages = await package.GetChildsByParentId(_PackageParentId);
                foreach(Package p in packages)
                {
                    int branchQuantity = 0;
                    int itemQuanP = p.quantity;
                    itemUnitId = (int)p.childIUId;
                    int requireQuan = itemQuanP * quantity;

                   // if (cb_location.SelectedIndex == -1)
                        branchQuantity = await itemLocation.getUnitAmount(itemUnitId, MainWindow.branchID.Value);
                    //else
                     //  branchQuantity = await itemLocation.getAmountInLocation(itemUnitId,MainWindow.branchID.Value,(int) cb_location.SelectedValue);

                    if (requireQuan > branchQuantity)
                    {
                        valid = false;
                        tb_quantity.Text = "0";
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorItemAmntNotAvailableToolTip")+" "+p.citemName, animation: ToasterAnimation.FadeIn);
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
        private bool validateInputs()
        {
            bool valid = true;
            SectionData.validateEmptyTextBox(tb_quantity, p_errorQuantity, tt_errorQuantity, "trEmptyQuantityToolTip");
            SectionData.validateEmptyComboBox(cb_item, p_errorParentItem, tt_errorParentItem, "trErrorEmptyItemToolTip");
            SectionData.validateEmptyComboBox(cb_location, p_errorLocation, tt_errorLocation, "trErrorEmptyLocationToolTip");
            if (tb_quantity.Text.Equals("") || cb_item.SelectedIndex == -1 || cb_location.SelectedIndex == -1)
            {
                valid = false;
                return valid;
            }
            if(int.Parse(tb_quantity.Text) == 0)
            {
                valid = false;
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorQuantIsZeroToolTip"), animation: ToasterAnimation.FadeIn);

            }
            return valid;
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            // bool valid =  await checkAmount();
            bool valid = validateInputs();
            if(valid)
            {
                int quantity = int.Parse(tb_quantity.Text);
                bool res = await itemLocation.generatePackage(_PackageParentId,quantity,(int)cb_location.SelectedValue,MainWindow.branchID.Value, MainWindow.userID.Value);
                if (res)
                {
                    clearGenerateInputs();
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                }
                else
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }
        private void clearGenerateInputs()
        {
            cb_item.SelectedIndex = -1;
            _PackageParentId = 0;
            cb_location.SelectedIndex = -1;
            cb_location.Text = "";
            tb_quantity.Clear();
            
            SectionData.clearValidate(tb_quantity, p_errorQuantity);
            SectionData.clearComboBoxValidate(cb_item, p_errorParentItem);
            SectionData.clearComboBoxValidate(cb_location, p_errorLocation);
            
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SectionData.StartAwait(grid_mainGrid);
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
            SectionData.EndAwait(grid_mainGrid,this);
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

        private async void Cb_item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           await checkAmount();
        }
    }
}

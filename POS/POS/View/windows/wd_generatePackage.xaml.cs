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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
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
            try
            { 
                cb_item.ItemsSource = items.Where(x => x.name.Contains(cb_item.Text));
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }

        }
        private async Task fillItemCombo()
        {
            items = await item.GetItemsByType("p");     // return items with type = package     
            cb_item.ItemsSource = items;
            cb_item.SelectedValuePath = "itemId";
            cb_item.DisplayMemberPath = "name";
        }
        private async Task fillLocationCombo()
        {
            locations = await location.GetLocsByBranchId(MainWindow.branchID.Value);      
            cb_location.ItemsSource = locations;
            cb_location.SelectedValuePath = "locationId";
            cb_location.DisplayMemberPath = "name";
        }
        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            { 
                SectionData.validateEmptyTextBox(tb_quantity, p_errorQuantity, tt_errorQuantity, "trEmptyQuantityToolTip");
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private async void tb_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_generatePackage);

                SectionData.validateEmptyTextBox(tb_quantity, p_errorQuantity, tt_errorQuantity, "trEmptyQuantityToolTip");
                bool validQan = await checkAmount();
                var txb = sender as TextBox;
                if ((sender as TextBox).Name == "tb_quantity")
                    SectionData.InputJustNumber(ref txb);

                if (sender != null)
                    SectionData.EndAwait(grid_generatePackage);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_generatePackage);
                SectionData.ExceptionMessage(ex, this);
            }

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

                    //branchQuantity = await itemLocation.getUnitAmount(itemUnitId, MainWindow.branchID.Value);
                    branchQuantity = await itemLocation.getAmountInBranch(itemUnitId, MainWindow.branchID.Value);

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
            try
            {
                if (e.Key == Key.Return)
                {
                    Btn_save_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_generatePackage);

                bool valid = validateInputs();
            if(valid)
            {
                int quantity = int.Parse(tb_quantity.Text);
                int res = await itemLocation.generatePackage(_PackageParentId,quantity,(int)cb_location.SelectedValue,MainWindow.branchID.Value, MainWindow.userID.Value);
                if (res > 0)
                {
                    clearGenerateInputs();
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                }
                else
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
                if (sender != null)
                    SectionData.EndAwait(grid_generatePackage);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_generatePackage);
                SectionData.ExceptionMessage(ex, this);
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
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_generatePackage);

                #region translate
                if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
            }

            translate();
                #endregion

                await fillItemCombo();
                await fillLocationCombo();

                if (sender != null)
                    SectionData.EndAwait(grid_generatePackage);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_generatePackage);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void translate()
        {
            txt_title.Text = MainWindow.resourcemanager.GetString("trPackage");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_item, MainWindow.resourcemanager.GetString("trItemHint")); 
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_location, MainWindow.resourcemanager.GetString("trLocationHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_quantity, MainWindow.resourcemanager.GetString("trQuantityHint"));
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Cb_location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_generatePackage);
                if (cb_location.SelectedIndex != -1)
                {
                   await checkAmount();
                }
                if (sender != null)
                    SectionData.EndAwait(grid_generatePackage);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_generatePackage);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Cb_item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_generatePackage);

                await checkAmount();

                if (sender != null)
                    SectionData.EndAwait(grid_generatePackage);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_generatePackage);
                SectionData.ExceptionMessage(ex, this);
            }
        }
    }
}

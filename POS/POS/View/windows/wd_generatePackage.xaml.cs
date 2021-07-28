using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool isActive;
        IEnumerable<Item> items;
        Item item;
        private void Cb_item_KeyUp(object sender, KeyEventArgs e)
        {
            cb_item.ItemsSource = items.Where(x => x.name.Contains(cb_item.Text));
        }
        private async void fillParentItemCombo()
        {
            //إنشاء إجراء من API يعيد فقط الحزم
            items = await item.GetAllItems();
            var listCa = items.Where(x => x.isActive == 1 ).ToList();
            cb_item.ItemsSource = listCa;
            cb_item.SelectedValuePath = "itemId";
            cb_item.DisplayMemberPath = "name";
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
        private void tb_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_quantity, p_errorQuantity, tt_errorQuantity, "trEmptyQuantityToolTip");
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
            isActive = true;
            this.Close();
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
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

        
    }
}

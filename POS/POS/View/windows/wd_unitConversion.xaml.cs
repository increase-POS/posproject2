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
    /// Interaction logic for wd_unitConversion.xaml
    /// </summary>
    public partial class wd_unitConversion : Window
    {
        public wd_unitConversion()
        {
            InitializeComponent();
        }
        public bool isActive;
        IEnumerable<Item> items;
        Item item;
        ItemUnit itemUnit = new ItemUnit();
        private void Cb_item_KeyUp(object sender, KeyEventArgs e)
        {
            cb_item.ItemsSource = items.Where(x => x.name.Contains(cb_item.Text));
        }
        private async void fillParentItemCombo()
        {
            //إنشاء إجراء من API يعيد فقط الحزم
            items = await item.GetAllItems();
            var listCa = items.Where(x => x.isActive == 1).ToList();
            cb_item.ItemsSource = listCa;
            cb_item.SelectedValuePath = "itemId";
            cb_item.DisplayMemberPath = "name";
        }

        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }
        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_fromQuantity")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorFromQuantity, tt_errorFromQuantity, "trEmptyCashToolTip");
            }
            else if (name == "ComboBox")
            {
                //  if ((sender as ComboBox).Name == "cb_depositTo")
                //      SectionData.validateEmptyComboBox((ComboBox)sender, p_errorDepositTo, tt_errorDepositTo, "trErrorEmptyDepositToToolTip");
                //  else if ((sender as ComboBox).Name == "cb_recipientV")
                //      SectionData.validateEmptyComboBox((ComboBox)sender, p_errorRecipient, tt_errorRecipient, "trErrorEmptyRecipientToolTip");
                //}
            }
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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

        private async void Cb_item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = await itemUnit.GetItemUnits(int.Parse(cb_item.SelectedValue.ToString()));

            cb_fromUnit.ItemsSource = list;
            cb_fromUnit.SelectedValuePath = "itemUnitId";
            cb_fromUnit.DisplayMemberPath = "mainUnit";
            cb_fromUnit.SelectedIndex = 0;


            cb_toUnit.ItemsSource = list;
            cb_toUnit.SelectedValuePath = "itemUnitId";
            cb_toUnit.DisplayMemberPath = "mainUnit";
            cb_toUnit.SelectedIndex = 0;
        }
    }
}

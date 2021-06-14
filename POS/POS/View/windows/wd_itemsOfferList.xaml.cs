using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for wd_itemsOfferList.xaml
    /// </summary>
    public partial class wd_itemsOfferList : Window
    {
        public wd_itemsOfferList()
        {
            InitializeComponent();
        }
        public bool isActive;

        ItemUnit itemUnit = new ItemUnit();
        List<ItemUnit> allItems = new List<ItemUnit>();
        public List<ItemUnit> selectedItems = new List<ItemUnit>();
        Item itemModel = new Item();
        public string txtItemSearch;
        /// <summary>
        /// Selcted Items if selectedItems Have Items At the beginning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // للتعديل 
            //allItems = (await itemModel.GetAllItems()).Where(x => x.isActive == 1).ToList();

            foreach (var itemUnit in selectedItems)
            {
                allItems.Remove(itemUnit);

            }
            selectedItems.AddRange(selectedItems);


            dg_allItems.ItemsSource = allItems;
            dg_selectedItems.ItemsSource = selectedItems;



            dg_allItems.SelectedValuePath = "itemId";
            dg_selectedItems.SelectedValuePath = "itemId";
            dg_allItems.DisplayMemberPath = "name";
            dg_selectedItems.DisplayMemberPath = "name";
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
        private void Dg_allItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Btn_selectedItem_Click(null, null);

        }
        private void Dg_selectedItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_unSelectedItem_Click(null, null);

        }
        private async void Btn_selectedAll_Click(object sender, RoutedEventArgs e)
        {
            // للتعديل 
            //selectedItems = (await itemModel.GetAllItems()).Where(x => x.isActive == 1).ToList();
            allItems.Clear();
            dg_allItems.ItemsSource = allItems;
            dg_selectedItems.ItemsSource = selectedItems;
            dg_allItems.Items.Refresh();
            dg_selectedItems.Items.Refresh();
        }
        private void Btn_selectedItem_Click(object sender, RoutedEventArgs e)
        {
            itemUnit = dg_allItems.SelectedItem as ItemUnit;
            if (itemUnit != null)
            {
                allItems.Remove(itemUnit);
                selectedItems.Add(itemUnit);
                dg_allItems.ItemsSource = allItems;
                dg_selectedItems.ItemsSource = selectedItems;
                dg_allItems.Items.Refresh();
                dg_selectedItems.Items.Refresh();
            }

        }
        private void Btn_unSelectedItem_Click(object sender, RoutedEventArgs e)
        {

            itemUnit = dg_selectedItems.SelectedItem as ItemUnit;
            if (itemUnit != null)
            {
                selectedItems.Remove(itemUnit);
                allItems.Add(itemUnit);

                dg_allItems.ItemsSource = allItems;
                dg_allItems.Items.Refresh();
                dg_selectedItems.ItemsSource = selectedItems;
                dg_selectedItems.Items.Refresh();
            }
        }
        private async void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {
            // للتعديل 
            //allItems = (await itemModel.GetAllItems()).Where(x => x.isActive == 1).ToList();
            selectedItems.Clear();
            dg_allItems.ItemsSource = allItems;
            dg_allItems.Items.Refresh();
            dg_selectedItems.ItemsSource = selectedItems;
            dg_selectedItems.Items.Refresh();

        }
        private void Txb_searchitems_TextChanged(object sender, TextChangedEventArgs e)
        {
 


            txtItemSearch = txb_searchitems.Text.ToLower();
            // للتعديل 
            //dg_allItems.ItemsSource = allItems.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
            //x.name.ToLower().Contains(txtItemSearch) ||
            //x.details.ToLower().Contains(txtItemSearch)
            //) && x.isActive == 1);
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

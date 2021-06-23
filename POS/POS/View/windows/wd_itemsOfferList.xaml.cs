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

        ItemUnit itemUnitOffer = new ItemUnit();
        List<ItemUnit> allItems = new List<ItemUnit>();
        public List<ItemUnit> selectedItems = new List<ItemUnit>();
        ItemUnit itemModel = new ItemUnit();
        public string txtItemSearch;
        /// <summary>
        /// Selcted Items if selectedItems Have Items At the beginning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            allItems = await itemModel.Getall();
            //foreach (var itemUnit in selectedItems)
            //{
            //    allItems.Remove(itemUnit);
            //}
            foreach (var itemUnit in allItems)
            {
                MessageBox.Show(itemUnit.itemName);
            }
            selectedItems.AddRange(selectedItems);
            
            dg_allItems.ItemsSource = allItems;
            dg_allItems.SelectedValuePath = "itemUnitId";
            dg_allItems.DisplayMemberPath = "itemName";

            dg_selectedItems.ItemsSource = selectedItems;
            dg_selectedItems.SelectedValuePath = "itemId";
            dg_selectedItems.DisplayMemberPath = "name";
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
            itemUnitOffer = dg_allItems.SelectedItem as ItemUnit;
            if (itemUnitOffer != null)
            {
                //allItems.Remove(itemUnit);
                //selectedItems.Add(itemUnit);
                dg_allItems.ItemsSource = allItems;
                dg_selectedItems.ItemsSource = selectedItems;
                dg_allItems.Items.Refresh();
                dg_selectedItems.Items.Refresh();
            }

        }
        private void Btn_unSelectedItem_Click(object sender, RoutedEventArgs e)
        {

            itemUnitOffer = dg_selectedItems.SelectedItem as ItemUnit;
            if (itemUnitOffer != null)
            {
                //selectedItems.Remove(itemUnit);
                allItems.Add(itemUnitOffer);

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

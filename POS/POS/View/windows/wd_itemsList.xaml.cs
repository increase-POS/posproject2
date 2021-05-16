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
    /// Interaction logic for wd_itemsList.xaml
    /// </summary>
    public partial class wd_itemsList : Window
    {
        public wd_itemsList()
        {
            InitializeComponent();
        }
        public bool isActive;
        Item item = new Item();
        List<Item> allItems = new List<Item>();
        public List<Item> selectedItems = new List<Item>();
        Item itemModel = new Item();
        /// <summary>
        /// Selcted Items if selectedItems Have Items At the beginning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            allItems = await itemModel.GetAllItems();

            foreach (var item in selectedItems)
            {
                allItems.Remove(item);

            }
            selectedItems.AddRange(selectedItems);


            lst_allItems.ItemsSource = allItems;
            lst_selectedItems.ItemsSource = selectedItems;



            lst_allItems.SelectedValuePath = "itemId";
            lst_selectedItems.SelectedValuePath = "itemId";
            lst_allItems.DisplayMemberPath = "name";
            lst_selectedItems.DisplayMemberPath = "name";
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

        private void Lst_allItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            item = lst_allItems.SelectedItem as Item;
            allItems.Remove(item);
            selectedItems.Add(item);
            lst_allItems.ItemsSource = allItems;
            lst_selectedItems.ItemsSource = selectedItems;
            lst_allItems.Items.Refresh();
            lst_selectedItems.Items.Refresh();

        }

        private void Lst_selectedItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            item = lst_selectedItems.SelectedItem as Item;
            selectedItems.Remove(item);
            allItems.Add(item);
            lst_allItems.ItemsSource = allItems;
            lst_allItems.Items.Refresh();
            lst_selectedItems.ItemsSource = selectedItems;
            lst_selectedItems.Items.Refresh();
        }

        

        private void Btn_selectedItem_Click(object sender, RoutedEventArgs e)
        {
            Lst_allItems_MouseDoubleClick(null, null);
        }

        private async void Btn_selectedAll_Click(object sender, RoutedEventArgs e)
        {
            allItems = await itemModel.GetAllItems();
            lst_selectedItems.ItemsSource = allItems;
            lst_allItems.ItemsSource = null;
        }

        private  void Btn_unSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            Lst_selectedItems_MouseDoubleClick(null, null);
        }

        private async void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {
            allItems = await itemModel.GetAllItems();
            lst_allItems.ItemsSource = allItems;
            lst_selectedItems.ItemsSource = null;

        }

       
        
    }
}

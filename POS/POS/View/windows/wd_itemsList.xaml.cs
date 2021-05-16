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
        Item item = new Item();
        List<Item> allItems = new List<Item>();
        List<Item> selectedItems = new List<Item>();
        Item itemModel = new Item();
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            allItems = await itemModel.GetAllItems();
            lst_allItems.ItemsSource = allItems;
            lst_allItems.SelectedValuePath = "itemId";
            lst_selectedItems.SelectedValuePath = "itemId";
            lst_allItems.DisplayMemberPath = "name";
            lst_selectedItems.DisplayMemberPath = "name";
        }
      
        void ok()
        {
            //ArrayPerson = new int[lst_selectedItems.Items.Count];

            //for (int i = 0; i < lst_selectedItems.Items.Count; i++)
            //{
            //    lst_selectedItems.SelectedIndex = i;
            //    ArrayPerson[i] = (int)lst_selectedItems.SelectedValue;
            //}
            //this.Close();
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void Lst_allItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            item = lst_allItems.SelectedItem as Item;
            allItems.Remove(item);
            selectedItems.Add(item);
            lst_allItems.ItemsSource = allItems;
            lst_selectedItems.ItemsSource = selectedItems;
        }

        private void Lst_selectedItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            item = lst_allItems.SelectedItem as Item;
            allItems.Add(item);
            selectedItems.Remove(item);
            lst_allItems.ItemsSource = allItems;
            lst_selectedItems.ItemsSource = selectedItems;
        }
    }
}

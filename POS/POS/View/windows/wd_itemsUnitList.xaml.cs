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
    /// Interaction logic for wd_itemsUnitList.xaml
    /// </summary>
    public partial class wd_itemsUnitList : Window
    {
        public int itemId = 0;

        public bool isActive;
        public wd_itemsUnitList()
        {
            InitializeComponent();
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_offerList.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_offerList.FlowDirection = FlowDirection.RightToLeft; }

            translat();
        }

        private void translat()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_searchitems, MainWindow.resourcemanager.GetString("trSearchHint"));

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

            dg_allItems.Columns[0].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_selectedItems.Columns[0].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_selectedItems.Columns[1].Header = MainWindow.resourcemanager.GetString("trQuantity");

            txt_title.Text = MainWindow.resourcemanager.GetString("trItem");
            txt_items.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_selectedItems.Text = MainWindow.resourcemanager.GetString("trSelectedItems");

            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_selectAllItem.Content = MainWindow.resourcemanager.GetString("trSelectAllItems");
            tt_unselectAllItem.Content = MainWindow.resourcemanager.GetString("trUnSelectAllItems");
            tt_selectItem.Content = MainWindow.resourcemanager.GetString("trSelectOneItem");
            tt_unselectItem.Content = MainWindow.resourcemanager.GetString("trUnSelectOneItem");

        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Txb_searchitems_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Dg_allItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Btn_selectedAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_selectedItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_unSelectedItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Dg_allItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Dg_selectedItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Dg_selectedItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

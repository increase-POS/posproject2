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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.View.storage
{
    /// <summary>
    /// Interaction logic for uc_inventory.xaml
    /// </summary>
    public partial class uc_inventory : UserControl
    {
        private static uc_inventory _instance;
        public static uc_inventory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_inventory();
                return _instance;
            }
        }

        public uc_inventory()
        {
            InitializeComponent();
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dg_items_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void Btn_newInventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Inventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Images_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

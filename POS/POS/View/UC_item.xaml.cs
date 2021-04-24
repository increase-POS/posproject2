using POS.Classes;
using POS.controlTemplate;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using static POS.View.uc_categorie;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_item.xaml
    /// </summary>
    public partial class UC_item : UserControl
    {

        public UC_item()
        {
            InitializeComponent();
        }
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            catigoriesAndItemsView.ucCategorieItem = this;

            #region Generate catigorie
            catigoriesAndItemsView.gridCatigories = Grid_categorie;
            Categorie categorie = new Categorie();
            catigoriesAndItemsView.FN_refrishCatalogCard(categorie.getCategories());
            #endregion


            #region Generate catigorieItems
            catigoriesAndItemsView.gridCatigorieItems = Grid_CategorieItem;
            CategorieItem CategorieItem = new CategorieItem();
            catigoriesAndItemsView.FN_refrishCatalogItem(CategorieItem.getCategorieItems());
            #endregion
        }

        public void testChangeCategorieIdEvent()
        {
            MessageBox.Show("Hello World!! CategorieId");
        }
        public void testChangeCategorieItemsIdEvent()
        {
            MessageBox.Show("Hello World!!  CategorieItems Id");
        }

        
        private void Btn_itemData_Click(object sender, RoutedEventArgs e)
        {
             grid_barcode.Visibility = grid_properties.Visibility = Visibility.Collapsed;
            grid_itemData.Visibility = Visibility.Visible;
            btn_barcodeTab.BorderBrush = brd_propertiesTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_itemDataTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_barcode_Click(object sender, RoutedEventArgs e)
        {
            grid_itemData.Visibility   = grid_properties.Visibility = Visibility.Collapsed;
            grid_barcode.Visibility = Visibility.Visible;
            brd_itemDataTab.BorderBrush = brd_propertiesTab.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            btn_barcodeTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        } 

        private void Btn_properties_Click(object sender, RoutedEventArgs e)
        {
            grid_itemData.Visibility = grid_barcode.Visibility = Visibility.Collapsed;
            grid_properties.Visibility = Visibility.Visible;
            btn_barcodeTab.BorderBrush = brd_itemDataTab.BorderBrush =  (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_propertiesTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

         //0Normal Item
         //1Have Expiration date
         //2Have Serial number
         //3Service
         //4Package items
        private void CB_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (CB_type.SelectedIndex == 1)
            {
                grid_serial.Visibility = Visibility.Collapsed;
                grid_expirationDate.Visibility = Visibility.Visible;
            }
            else if (CB_type.SelectedIndex == 2)
            {
                grid_expirationDate.Visibility = Visibility.Collapsed;
                grid_serial.Visibility = Visibility.Visible;

            }

            if (CB_type.SelectedIndex == 3)
            {
                grid_service.Visibility = Visibility.Visible;
                line_topService.Visibility = Visibility.Collapsed;
            } else
            {
                grid_service.Visibility = Visibility.Collapsed;
                line_topService.Visibility = Visibility.Visible;
            }


        }

        
    }
}

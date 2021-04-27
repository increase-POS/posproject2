using POS.Classes;
using POS.controlTemplate;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        private void translate()
        {
            txt_itemData.Text = MainWindow.resourcemanager.GetString("trItemData");
            txt_properties.Text = MainWindow.resourcemanager.GetString("trProperties");
            txt_barcode.Text = MainWindow.resourcemanager.GetString("trBarcode");

            //MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trPamentMethodHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_details, MainWindow.resourcemanager.GetString("trDetailsHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trCode"));


            txt_secondaryInformation.Text = MainWindow.resourcemanager.GetString("trSecondaryInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_parentItem, MainWindow.resourcemanager.GetString("trSelectParentItemHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_categorie, MainWindow.resourcemanager.GetString("trSelectCategorieHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_itemType, MainWindow.resourcemanager.GetString("trSelectItemTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_taxes, MainWindow.resourcemanager.GetString("trTaxesHint"));


            txt_minAndMax.Text = MainWindow.resourcemanager.GetString("trMinAndMaxOfItem");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_min, MainWindow.resourcemanager.GetString("trMinHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_max, MainWindow.resourcemanager.GetString("trMaxHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_minUnit, MainWindow.resourcemanager.GetString("trSelectUnitHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_maxUnit, MainWindow.resourcemanager.GetString("trSelectUnitHint"));

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            ///////////////////////////Barcode
            txt_unit.Text = MainWindow.resourcemanager.GetString("trUnit");
            dg_unit.Columns[0].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_unit.Columns[1].Header = MainWindow.resourcemanager.GetString("trCountUnit");
            dg_unit.Columns[2].Header = MainWindow.resourcemanager.GetString("trSmallUnit");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_selectUnit, MainWindow.resourcemanager.GetString("trSelectUnitHint"));
            txt_isDefaultPurchases.Text = MainWindow.resourcemanager.GetString("trIsDefaultPurchases");
            tb_isDefaultSales.Text = MainWindow.resourcemanager.GetString("trIsDefaultSales");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_Count, MainWindow.resourcemanager.GetString("trCountHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_unit, MainWindow.resourcemanager.GetString("trUnitHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_price, MainWindow.resourcemanager.GetString("trPriceHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_barcode, MainWindow.resourcemanager.GetString("trBarcodeHint"));

            btn_addBarcode.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_updateBarcode.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_deleteBarcode.Content = MainWindow.resourcemanager.GetString("trDelete");
            btn_clearProperties.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            ///////////////////////////Properties
            txt_propertie.Text = MainWindow.resourcemanager.GetString("trProperties");
            dg_properties.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_properties.Columns[1].Header = MainWindow.resourcemanager.GetString("trValue");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_selectProperties, MainWindow.resourcemanager.GetString("trSelectProperties"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_value, MainWindow.resourcemanager.GetString("trValueHint"));

            btn_addProperties.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_updateProperties.Content = MainWindow.resourcemanager.GetString("trDelete");
            btn_clearPropertiess.ToolTip = MainWindow.resourcemanager.GetString("trClear");


        }

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


            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucItem.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucItem.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

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
            brd_barcodeTab.BorderBrush = brd_propertiesTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_itemDataTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_barcode_Click(object sender, RoutedEventArgs e)
        {
            grid_itemData.Visibility   = grid_properties.Visibility = Visibility.Collapsed;
            grid_barcode.Visibility = Visibility.Visible;
            brd_itemDataTab.BorderBrush = brd_propertiesTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_barcodeTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        } 

        private void Btn_properties_Click(object sender, RoutedEventArgs e)
        {
            grid_itemData.Visibility = grid_barcode.Visibility = Visibility.Collapsed;
            grid_properties.Visibility = Visibility.Visible;
            brd_barcodeTab.BorderBrush = brd_itemDataTab.BorderBrush =  (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_propertiesTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

         //0Normal Item
         //1Have Expiration date
         //2Have Serial number
         //3Service
         //4Package items
        private void CB_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           if (cb_itemType.SelectedIndex == 2)
            {
                grid_service.Visibility = Visibility.Collapsed;
                grid_serial.Visibility = Visibility.Visible;
                line_topService.Visibility = Visibility.Collapsed;


            }
            else if(cb_itemType.SelectedIndex == 3)
            {
                grid_serial.Visibility = Visibility.Collapsed;
                grid_service.Visibility = Visibility.Visible;
                line_topService.Visibility = Visibility.Collapsed;
            }
            else
            {
                grid_serial.Visibility = Visibility.Collapsed;
                grid_service.Visibility = Visibility.Collapsed;
                line_topService.Visibility = Visibility.Visible;
            }

           


        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            
            tb_taxes.Text = "";
            tb_min.Text = "";
            tb_max.Text = "";
            tb_code.Text = "";
            tb_name.Text = "";
            cb_categorie.Text = "";
            cb_itemType.Text = "";
            cb_parentItem.Text = "";

            tb_details.Text = "";
            cb_maxUnit.Text = "";
            cb_minUnit.Text = "";
        }

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_code_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_code.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_code.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorCode.Visibility = Visibility.Collapsed;
                tt_errorCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_code.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_code.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorCode.Visibility = Visibility.Collapsed;
                tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        //private void Cb_parentItem_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    var bc = new BrushConverter();

        //    if (cb_parentItem.Text.Equals(""))
        //    {
        //        p_errorParentItem.Visibility = Visibility.Visible;
        //        tt_errorParentItem.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
        //        cb_parentItem.Background = (Brush)bc.ConvertFrom("#15FF0000");
        //    }
        //    else
        //    {
        //        p_errorParentItem.Visibility = Visibility.Collapsed;
        //        cb_parentItem.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        //    }
        //}


        private void Cb_categorie_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (cb_categorie.Text.Equals(""))
            {
                p_errorCategorie.Visibility = Visibility.Visible;
                tt_categorie.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_categorie.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorCategorie.Visibility = Visibility.Collapsed;
                cb_categorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Tb_min_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_min.Text.Equals(""))
            {
                p_errorMin.Visibility = Visibility.Visible;
                tt_errorMin.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_min.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorMin.Visibility = Visibility.Collapsed;
                tb_min.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_max_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_max.Text.Equals(""))
            {
                p_errorMax.Visibility = Visibility.Visible;
                tt_errorMax.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_max.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorMax.Visibility = Visibility.Collapsed;
                tb_max.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_taxes_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_taxes.Text.Equals(""))
            {
                p_errorTaxes.Visibility = Visibility.Visible;
                tt_errorTaxes.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_taxes.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorTaxes.Visibility = Visibility.Collapsed;
                tb_taxes.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }
    }
}

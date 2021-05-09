using client_app.Classes;
using POS.Classes;
using POS.controlTemplate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public int ItemId;

        Item itemModel = new Item();
        Category categoryModel = new Category();
        Unit unitModel = new Unit();
        Property propertyModel = new Property();
        PropertiesItems propItemsModel = new PropertiesItems();
        ItemsProp itemsPropModel = new ItemsProp();
        Serial serialModel = new Serial();
        ItemUnit itemUnitModel = new ItemUnit();

        // item object
        Item item = new Item();
        //item property value object
        ItemsProp itemProp = new ItemsProp();
        // serial object
        Serial serial = new Serial();
        // item unit object
        ItemUnit itemUnit = new ItemUnit();

        string selectedType = "" ;

        int selectedCategoryId = 0 , selectedMinUnitId = 0 , selectedMaxUnitId = 0;

        List<int> categoryIds = new List<int>();
        List<string> categoryNames = new List<string>();
        List<Property> properties;
        List<Category> categories;
        List<PropertiesItems> propItems;
        List<Unit> units;
        List<ItemsProp> itemsProp;
        List<Serial> itemSerials;
        List<ItemUnit> itemUnits;
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
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_count, MainWindow.resourcemanager.GetString("trCountHint"));
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

        private void Btn_ItemsInCards_Click(object sender, RoutedEventArgs e)
        {
            grid_itemsDatagrid.Visibility = Visibility.Collapsed;
            grid_ItemsCard.Visibility = Visibility.Visible;
        }

        private void Btn_ItemsInGrid_Click(object sender, RoutedEventArgs e)
        {
            grid_ItemsCard.Visibility = Visibility.Collapsed;
            grid_itemsDatagrid.Visibility = Visibility.Visible;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            catigoriesAndItemsView.ucCategorieItem = this;

            #region Generate catigorie
            catigoriesAndItemsView.gridCatigories = Grid_categorie;
            //Categorie categorie = new Categorie();
            //catigoriesAndItemsView.FN_refrishCatalogCard(categorie.getCategories());
            #endregion


            #region Generate catigorieItems
            catigoriesAndItemsView.gridCatigorieItems = Grid_CategorieItem;
            //CategorieItem CategorieItem = new CategorieItem();
            //catigoriesAndItemsView.FN_refrishCatalogItem(CategorieItem.getCategorieItems(), MainWindow.lang, "sale");
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
            fillCategories();           
            fillUnits();
            fillProperties();

            var items = await itemModel.GetAllItems();
            dg_items.ItemsSource = items;
            // fill parent items
            cb_parentItem.ItemsSource = items.ToList();
            cb_parentItem.SelectedValuePath = "itemId";
            cb_parentItem.DisplayMemberPath = "name";

            cb_parentItem.SelectedIndex = -1;
            cb_categorie.SelectedIndex = -1;
            cb_itemType.SelectedIndex = 0;
            cb_minUnit.SelectedIndex = 0;
            cb_maxUnit.SelectedIndex = 0;
        }

        
        private void Btn_itemData_Click(object sender, RoutedEventArgs e)
        {
            dg_barcode.Visibility = grid_properties.Visibility = Visibility.Collapsed;
            grid_itemData.Visibility = Visibility.Visible;
            brd_barcodeTab.BorderBrush = brd_propertiesTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_itemDataTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_barcode_Click(object sender, RoutedEventArgs e)
        {
            grid_itemData.Visibility   = grid_properties.Visibility = Visibility.Collapsed;
            dg_barcode.Visibility = Visibility.Visible;
            brd_itemDataTab.BorderBrush = brd_propertiesTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_barcodeTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        } 

        private void Btn_properties_Click(object sender, RoutedEventArgs e)
        {
            grid_itemData.Visibility = dg_barcode.Visibility = Visibility.Collapsed;
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

            switch (cb_itemType.SelectedIndex)
            {
                case 0: selectedType = "n"; break;
                case 1: selectedType = "d"; break;
                case 2: selectedType = "sn"; break;
                case 3: selectedType = "sr"; break;
                case 4: selectedType = "p"; break;
            }



        }

        // add item with basic information 
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            Nullable<int> categoryId = null;
            if (cb_categorie.SelectedIndex != -1)
                categoryId = (int)cb_categorie.SelectedValue;

            Nullable<int> parentId = null;
            if (cb_parentItem.SelectedIndex != -1)
                parentId = (int)cb_parentItem.SelectedValue;

            int min = 0;
            int max = 0;
            decimal taxes = 0;
           
            if (tb_min.Text != "")
                min = int.Parse(tb_min.Text);
            if (tb_max.Text != "")
                max = int.Parse(tb_max.Text);
            if (tb_taxes.Text != "")
                taxes = decimal.Parse(tb_taxes.Text);

            Nullable<int> minUnitId = null;
            if (cb_minUnit.SelectedIndex != -1)
                minUnitId = units[cb_minUnit.SelectedIndex].unitId;

            Nullable<int> maxUnitId = null;
            if (cb_maxUnit.SelectedIndex != -1)
                maxUnitId = units[cb_maxUnit.SelectedIndex].unitId;

            item.code = tb_code.Text;
            item.name = tb_name.Text;
            item.details = tb_details.Text;
            item.type = selectedType;
            item.image = "";
            item.taxes = taxes;
            item.isActive = 1;
            item.min = min;
            item.max = max;
            item.categoryId = categoryId;
            item.parentId = parentId;
            item.createUserId = MainWindow.userID;
            item.updateUserId = MainWindow.userID;
            item.minUnitId = minUnitId;
            item.maxUnitId = maxUnitId;

           string res = await itemModel.saveItem(item);
            if (res.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

            var items = await itemModel.GetAllItems();
            dg_items.ItemsSource = items;
            
            btn_clear_Click(sender, e);

        }

        //update item
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            Nullable<int> categoryId = null;
            if (cb_categorie.SelectedIndex != -1)
                categoryId = (int)cb_categorie.SelectedValue;

            Nullable<int> parentId = null;
            if (cb_parentItem.SelectedIndex != -1)
                parentId = (int)cb_parentItem.SelectedValue;

            int min = 0;
            int max = 0;
            decimal taxes = 0;

            if (tb_min.Text != "")
                min = int.Parse(tb_min.Text);
            if (tb_max.Text != "")
                max = int.Parse(tb_max.Text);
            if (tb_taxes.Text != "")
                taxes = decimal.Parse(tb_taxes.Text);

            Nullable<int> minUnitId = null;
            if (cb_minUnit.SelectedIndex != -1)
                minUnitId = units[cb_minUnit.SelectedIndex].unitId;

            Nullable<int> maxUnitId = null;
            if (cb_maxUnit.SelectedIndex != -1)
                maxUnitId = units[cb_maxUnit.SelectedIndex].unitId;

            item.itemId = item.itemId;
            item.code = tb_code.Text;
            item.name = tb_name.Text;
            item.details = tb_details.Text;
            item.type = selectedType;
            item.image = "";
            item.taxes = taxes;
            item.min = min;
            item.max = max;
            item.categoryId = categoryId;
            item.parentId = parentId;
            item.updateUserId = MainWindow.userID;
            item.minUnitId = minUnitId;
            item.maxUnitId = maxUnitId;
            // };

            string res = await itemModel.saveItem(item);
            if (res.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

            var items = await itemModel.GetAllItems();
            dg_items.ItemsSource = items;
        }

        #region barcode
        //*****************************************8
        // add barcode to item
        async void Btn_addBarcode_Click(object sender, RoutedEventArgs e)
        {
            Nullable<int> unitId = null;
            if (cb_selectUnit.SelectedIndex != -1)
                unitId = units[cb_selectUnit.SelectedIndex].unitId;

            short defaultBurchase = 0;
            if (tbtn_isDefaultPurchases.IsChecked == true)
                defaultBurchase = 1;

            short defaultSale = 0;
            if (tbtn_isDefaultSales.IsChecked == true)
                defaultSale = 1;

            decimal unitValue = 0;
            if (tb_count.Text != "")
                unitValue = decimal.Parse(tb_count.Text);

            Nullable<int> smallUnitId = null;
            if (cb_unit.SelectedIndex != -1)
                smallUnitId = units[cb_unit.SelectedIndex].unitId;

            decimal price = 0;
            if (tb_price.Text != "")
                price = decimal.Parse(tb_price.Text);

            string barcode = tb_barcode.Text;

            itemUnit.itemId = item.itemId;
            itemUnit.unitId = unitId;
            itemUnit.unitValue = unitValue;
            itemUnit.subUnitId = smallUnitId;
            itemUnit.defaultSale = defaultSale;
            itemUnit.defaultPurchase = defaultBurchase;
            itemUnit.price = price;
            itemUnit.barcode = barcode;
            itemUnit.createUserId = MainWindow.userID;

            string res = await itemUnit.saveItemUnit(itemUnit);
            if (res.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

            refreshItemUnitsGrid(item.itemId);
            Btn_unitClear(sender,e);
        }
        //**********************************************
        //**************update barcode******************
        async void Btn_updateBarcode_Click(object sender, RoutedEventArgs e)
        {
            Nullable<int> unitId = null;
            if (cb_selectUnit.SelectedIndex != -1)
                unitId = units[cb_selectUnit.SelectedIndex].unitId;

            short defaultBurchase = 0;
            if (tbtn_isDefaultPurchases.IsChecked == true)
                defaultBurchase = 1;

            short defaultSale = 0;
            if (tbtn_isDefaultSales.IsChecked == true)
                defaultSale = 1;

            decimal unitValue = 0;
            if (tb_count.Text != "")
                unitValue = decimal.Parse(tb_count.Text);

            Nullable<int> smallUnitId = null;
            if (cb_unit.SelectedIndex != -1)
                smallUnitId = units[cb_unit.SelectedIndex].unitId;

            decimal price = 0;
            if (tb_price.Text != "")
                price = decimal.Parse(tb_price.Text);

            string barcode = tb_barcode.Text;

            itemUnit.itemId = item.itemId;
            itemUnit.unitId = unitId;
            itemUnit.unitValue = unitValue;
            itemUnit.subUnitId = smallUnitId;
            itemUnit.defaultSale = defaultSale;
            itemUnit.defaultPurchase = defaultBurchase;
            itemUnit.price = price;
            itemUnit.barcode = barcode;
            itemUnit.createUserId = MainWindow.userID;

            string res = await itemUnit.saveItemUnit(itemUnit);
            if (res.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

            refreshItemUnitsGrid(item.itemId);
        }
        //**********************************************
        //**************delete barcode******************
        async void Btn_deleteBarcode_Click(object sender, RoutedEventArgs e)
        {
            if (itemUnit.itemUnitId != 0)
            {
                Boolean res = await itemUnit.Delete(itemUnit.itemUnitId);

                if (res) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopDelete"));
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                refreshItemUnitsGrid(item.itemId);
            }
        }
        #endregion barcode
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if ((!item.canDelete) && (item.isActive == 0))
                activate();
            else
            {
                string popupContent = "";
                if (item.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                if ((!item.canDelete) && (item.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");
                int userId = (int)MainWindow.userID;
                Boolean res = await itemModel.deleteItem(item.itemId,userId, item.canDelete);

                if (res) SectionData.popUpResponse("", popupContent);
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            }

            var items = await itemModel.GetAllItems();
            dg_items.ItemsSource = items;

           // tb_search_TextChanged(null, null);

            //clear textBoxs
            btn_clear_Click(sender, e);

        }
        private async void activate()
        {//activate

            item.isActive = 1;

            string s = await itemModel.saveItem(item);

            if (s.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

        }
        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_code.Text = "";
            tb_name.Text = "";
            tb_details.Text = "";
            cb_parentItem.SelectedIndex = -1;
            cb_categorie.SelectedIndex = -1;
            cb_itemType.SelectedIndex = -1;
            tb_taxes.Text = "";
            tb_min.Text = "";
            tb_max.Text = "";
            cb_minUnit.SelectedIndex = -1;
            cb_maxUnit.SelectedIndex = -1;
            item = new Item();
        }
        private void btn_clearPropertiesClick(object sender, RoutedEventArgs e)
        {
            cb_selectProperties.SelectedIndex = -1;
            cb_value.SelectedIndex = -1;
            tb_serial.Text = "";
            itemProp = new ItemsProp();
        }
        private void Btn_unitClear(object sender, RoutedEventArgs e)
        {
            cb_selectUnit.SelectedIndex = -1;
            tbtn_isDefaultPurchases.IsChecked = false;
            tbtn_isDefaultSales.IsChecked = false;
            tb_count.Text = "";
            cb_unit.SelectedIndex = -1;
            tb_price.Text = "";
            tb_barcode.Text = "";

            itemUnit = new ItemUnit();
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

        private void Cb_categorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selectedCategoryId = categoryIds[cb_categorie.SelectedIndex];
        }

       

        DataGrid dt = new DataGrid();
        async void fillCategories()
        {
            categories = await categoryModel.GetAllCategories();
            cb_categorie.ItemsSource = categories.ToList();
            cb_categorie.SelectedValuePath = "categoryId";
            cb_categorie.DisplayMemberPath = "name";
        }
        List<int> unitIds = new List<int>();
        List<string> unitNames = new List<string>();
        private async void fillUnits()
        {
            units = await unitModel.GetUnitsAsync();
            cb_minUnit.ItemsSource = units.ToList();
            cb_minUnit.SelectedValuePath = "unitId";
            cb_minUnit.DisplayMemberPath = "name";

            cb_maxUnit.ItemsSource = units.ToList();
            cb_maxUnit.SelectedValuePath = "unitId";
            cb_maxUnit.DisplayMemberPath = "name";

            cb_selectUnit.ItemsSource = units.ToList();
            cb_selectUnit.SelectedValuePath = "unitId";
            cb_selectUnit.DisplayMemberPath = "name";

            cb_unit.ItemsSource = units.ToList();
            cb_unit.SelectedValuePath = "unitId";
            cb_unit.DisplayMemberPath = "name";
        }
        async void fillProperties()
        {
             properties = await propertyModel.getProperty();
            cb_selectProperties.ItemsSource = properties.ToList();
            cb_selectProperties.SelectedValuePath = "propertyId";
            cb_selectProperties.DisplayMemberPath = "name";
        }

        private void Cb_minUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // selectedMinUnitId  = unitIds[cb_minUnit.SelectedIndex];
        }

        private void Cb_maxUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selectedMaxUnitId = unitIds[cb_maxUnit.SelectedIndex];
        }

        async void Btn_addProperties_Click(object sender, RoutedEventArgs e)
        {
            if (cb_value.SelectedValue != null && item.itemId >0)
            {
                int propertyItemId = propItems[cb_value.SelectedIndex].propertyItemId;
                int itemId = (int) item.itemId;

                // check if property assigned previously to item
                Boolean exist = itemsProp.Any(x => x.propertyItemId == propertyItemId && x.itemId == itemId);

                if (!exist)
                {
                    ItemsProp itemspropObj = new ItemsProp();
                    itemspropObj.propertyItemId = propItems[cb_value.SelectedIndex].propertyItemId;
                    itemspropObj.itemId = itemId;
                    itemspropObj.updateUserId = MainWindow.userID;
                    itemspropObj.createUserId = MainWindow.userID;

                    Boolean res = await itemsPropModel.Save(itemspropObj);
                    if (res) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd"));
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                    refreshPropertiesGrid(itemId);
                }
                cb_value.SelectedIndex = -1;
                cb_selectProperties.SelectedIndex = -1;
            }
        }
        // add serial to item
        async void Btn_addSerial_Click(object sender, RoutedEventArgs e)
        {
            if (tb_serial.Text != "")
            {
                Boolean exist = false;
                if (itemSerials != null)
                    exist = itemSerials.Any(x => x.serialNum == tb_serial.Text && x.itemId == item.itemId);

                if (!exist)
                {
                    Serial serial = new Serial();
                    serial.serialNum = tb_serial.Text;
                    serial.itemId = item.itemId;
                    serial.isActive = 1;

                    Boolean res = await serialModel.saveSerial(serial);

                    if (res) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd"));
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                    // refresh  serials grid
                    refreshSerials(item.itemId);
                }
                tb_serial.Clear();
            }
        }

        async void refreshSerials(int itemId)
        {
            // get all item serials
            itemSerials = await serialModel.GetItemSerials(itemId);
            dg_serials.ItemsSource = itemSerials;
        }

        async void refreshPropertiesGrid(int itemId)
        {
            itemsProp = await itemsPropModel.Get(item.itemId);
            dg_properties.ItemsSource = itemsProp.ToList();
        }
        async void refreshItemUnitsGrid(int itemId)
        {
            itemUnits = await itemUnitModel.GetItemUnits(itemId);
            dg_unit.ItemsSource = itemUnits.ToList();
        }
        async void Btn_deleteProperties_Click(object sender, RoutedEventArgs e)
        {
            if (itemProp.itemPropId != 0)
            {
                int propertyItemId = (int)itemProp.propertyItemId;
                int itemId = item.itemId;

                Boolean res = await itemsPropModel.Delete(itemProp.itemPropId);

                if (res) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopDelete"));
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                refreshPropertiesGrid(item.itemId); 
            }
        }
        async void Btn_deleteSerial_Click(object sender, RoutedEventArgs e)
        {
            if (serial.serialId != 0)
            {
                Boolean res = await serialModel.delete(serial.serialId);

                if (res) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopDelete"));
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                refreshSerials(item.itemId);
            }
        }

        async void Cb_selectProperties_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_selectProperties.SelectedIndex != -1)
            {
                int propertyId = properties[cb_selectProperties.SelectedIndex].propertyId;
                propItems = await propertyModel.GetPropertyValues(propertyId);
                cb_value.ItemsSource = propItems.ToList();
                cb_value.SelectedValuePath = "propertyItemId";
                cb_value.DisplayMemberPath = "propertyItemName";
            }
        }

        

        async void dg_itemsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
          //  tt_errorParentCategorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            
            if (dg_items.SelectedIndex != -1)
            {
                item = dg_items.SelectedItem as Item;
                this.DataContext = item;

                refreshPropertiesGrid(item.itemId);
                refreshSerials(item.itemId);
                refreshItemUnitsGrid(item.itemId);

            }
            if (item != null)
            {
                if (item.parentId != null && item.parentId != 0)
                {
                    cb_parentItem.SelectedValue = (int)item.parentId;
                }
                else
                    cb_parentItem.SelectedValue = -1;

                if (item.categoryId != null)
                {
                    cb_categorie.SelectedValue = (int)item.categoryId;
                }
                else
                    cb_categorie.SelectedValue = -1;
              
                if (item.type != null)
                {
                    cb_itemType.SelectedValue = item.type;
                    switch (item.type){
                        case "n": cb_itemType.SelectedIndex = 0; break;
                        case "d": cb_itemType.SelectedIndex = 1; break;
                        case "sn":cb_itemType.SelectedIndex = 2; break;
                        case "sr": cb_itemType.SelectedIndex = 3; break;
                        case "p": cb_itemType.SelectedIndex = 4; break;
                    }
                }
                else
                    cb_itemType.SelectedValue = -1;

                tb_min.Text = item.min.ToString();
                tb_max.Text = item.max.ToString();
               
                if (item.minUnitId != null)
                    cb_minUnit.SelectedValue = (int) item.minUnitId;
                else
                    cb_minUnit.SelectedValue = -1;

                if (item.maxUnitId != null)
                    cb_maxUnit.SelectedValue = (int)item.maxUnitId;
                else
                    cb_minUnit.SelectedValue = -1;

                if (item.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else
                {
                    if (item.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                    else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
                }

            }
        }

        private void dg_unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_unit.SelectedIndex != -1)
            {
                itemUnit = dg_unit.SelectedItem as ItemUnit;

                if (itemUnit.unitId != null)
                    cb_selectUnit.SelectedValue = (int)itemUnit.unitId;
                else
                    cb_selectUnit.SelectedValue = -1;
        
                if (itemUnit.smallUnit != null)
                    cb_unit.SelectedValue = (int)itemUnit.subUnitId;
                else
                    cb_unit.SelectedValue = -1;

                if (itemUnit.defaultPurchase == 1)
                    tbtn_isDefaultPurchases.IsChecked = true;
                else tbtn_isDefaultPurchases.IsChecked = false;

                if (itemUnit.defaultSale == 1)
                    tbtn_isDefaultSales.IsChecked = true;
                else tbtn_isDefaultSales.IsChecked = false;

                tb_count.Text = itemUnit.unitValue.ToString();
                tb_price.Text = itemUnit.price.ToString();
                tb_barcode.Text = itemUnit.barcode;
            }
        }
        private void dg_propertiesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_properties.SelectedIndex != -1)
            {
                itemProp = dg_properties.SelectedItem as ItemsProp;
            }
        }
        private void dg_serials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_serials.SelectedIndex != -1)
            {
                serial = dg_serials.SelectedItem as Serial;
            }
        }
        private async void Cb_parentItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item parentItem = new Item();
            int parentId = 0;
            if(cb_parentItem.SelectedIndex != -1 && item.itemId ==0 )
            {
                parentItem = await itemModel.GetItemByID((int)cb_parentItem.SelectedValue);
                parentId = parentItem.itemId;

                if (parentItem.categoryId != null)
                    cb_categorie.SelectedValue = (int)parentItem.categoryId;
                if (parentItem.type != null)
                {
                    //cb_itemType.SelectedValue = parentItem.type;
                    switch (parentItem.type)
                    {
                        case "n": cb_itemType.SelectedIndex = 0; break;
                        case "d": cb_itemType.SelectedIndex = 1; break;
                        case "sn": cb_itemType.SelectedIndex = 2; break;
                        case "sr": cb_itemType.SelectedIndex = 3; break;
                        case "p": cb_itemType.SelectedIndex = 4; break;
                    }
                }
                tb_taxes.Text = parentItem.taxes.ToString();
                tb_min.Text = parentItem.min.ToString();
                tb_max.Text = parentItem.max.ToString();

                if (parentItem.minUnitId != null)
                    cb_minUnit.SelectedValue = (int)parentItem.minUnitId;

                if (parentItem.maxUnitId != null)
                    cb_maxUnit.SelectedValue = (int)parentItem.maxUnitId;
            }
       }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;

            else
                e.Handled = true;
        }
        private void tb_upperLimit_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

    }
}

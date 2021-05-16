using POS.Classes;
using POS.controlTemplate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.IO;
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
        Service serviceModel = new Service();
        IEnumerable<Category> categoriesQuery;
        IEnumerable<Item> items;
        IEnumerable<Item> itemsQuery;
        Category category = new Category();
        // item object
        Item item = new Item();
        //item property value object
        ItemsProp itemProp = new ItemsProp();
        // serial object
        Serial serial = new Serial();
        // item unit object
        ItemUnit itemUnit = new ItemUnit();
        // service object
        Service service = new Service();
        string selectedType = "" ;


        DataGrid dt = new DataGrid();

        List<int> categoryIds = new List<int>();
        List<string> categoryNames = new List<string>();
        List<Property> properties;
        List<Category> categories;
        List<PropertiesItems> propItems;
        List<Unit> units;
        List<ItemsProp> itemsProp;
        List<Serial> itemSerials;
        List<ItemUnit> itemUnits;
        List<Service> services;
        List<string> barcodesList;
        public byte tglCategoryState = 1;
        public byte tglItemState;
        int? categoryParentId = 0;
        public string txtItemSearch;

        List<int> unitIds = new List<int>();
        List<string> unitNames = new List<string>();

        static private int _InternalCounter = 0;
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

       

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            catigoriesAndItemsView.ucItem = this;


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
            await RefrishItems();
            await RefrishCategories();
            RefrishCategoriesCard();
            Txb_searchitems_TextChanged(null, null);


            translate();
            fillCategories();           
            fillUnits();
            fillProperties();
            fillBarcodeList();

            //items = await itemModel.GetAllItems();
            //dg_items.ItemsSource = items;
            // fill parent items
            cb_parentItem.ItemsSource = items.ToList();
            cb_parentItem.SelectedValuePath = "itemId";
            cb_parentItem.DisplayMemberPath = "name";

            cb_parentItem.SelectedIndex = -1;
            cb_categorie.SelectedIndex = -1;
            cb_itemType.SelectedIndex = 0;
            cb_minUnit.SelectedIndex = 0;
            cb_maxUnit.SelectedIndex = 0;
            generateBarcode("",true);
        }

        private void generateBarcode(string barcodeString, Boolean defaultBarcode)
        {
            if(barcodeString == "" && defaultBarcode)
            {
                barcodeString = generateRandomBarcode();
                if (barcodesList != null)
                {
                    Boolean exist = barcodesList.Any(x => barcodeString.Contains(x));
                    if (exist == true)
                        barcodeString = generateRandomBarcode();
                }
                tb_barcode.Text += barcodeString;
            }
            //tb_barcode.Text += barcodeString;
            // create encoding object
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

            if (barcodeString != "")
            {
                System.Drawing.Bitmap serial_bitmap = (System.Drawing.Bitmap)barcode.Draw(barcodeString, 60);
                System.Drawing.ImageConverter ic = new System.Drawing.ImageConverter();
                //generate bitmap
                img_barcode.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(serial_bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            else
                img_barcode.Source = null;
        }

        static public string generateRandomBarcode()
        {
            var now = DateTime.Now;

            var days = (int)(now - new DateTime(2000, 1, 1)).TotalDays;
            var seconds = (int)(now - DateTime.Today).TotalSeconds;

            var counter = _InternalCounter++ % 100;

            return days.ToString("00000") + seconds.ToString("00000") + counter.ToString("00");
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

       
        #region add update delete 
        // add item with basic information 
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            //check mandatory values
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
            if (cb_categorie.SelectedIndex == -1)
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
            if (cb_itemType.SelectedIndex == -1)
            {
                p_errorType.Visibility = Visibility.Visible;
                tt_errorType.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_itemType.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorType.Visibility = Visibility.Collapsed;
                cb_itemType.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (cb_minUnit.SelectedIndex == -1)
            {
                p_errorMinUnit.Visibility = Visibility.Visible;
                tt_errorMinUnit.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_minUnit.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorMinUnit.Visibility = Visibility.Collapsed;
                cb_minUnit.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (cb_maxUnit.SelectedIndex == -1)
            {
                p_errorMaxUnit.Visibility = Visibility.Visible;
                tt_errorMaxUnit.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_maxUnit.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorMaxUnit.Visibility = Visibility.Collapsed;
                cb_maxUnit.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
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
            if (!tb_code.Text.Equals("") && !tb_name.Text.Equals("") && cb_categorie.SelectedIndex != -1 && cb_itemType.SelectedIndex != -1
                && cb_minUnit.SelectedIndex != -1 && cb_maxUnit.SelectedIndex != -1 && !tb_min.Text.Equals("") && !tb_max.Text.Equals(""))
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

                //var items = await itemModel.GetAllItems();
                //dg_items.ItemsSource = items;
                await RefrishItems();
                Txb_searchitems_TextChanged(null, null);
                btn_clear_Click(sender, e);
            }

        }

        //update item
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            //check mandatory values
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
            if (cb_categorie.SelectedIndex == -1)
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
            if (cb_itemType.SelectedIndex == -1)
            {
                p_errorType.Visibility = Visibility.Visible;
                tt_errorType.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_itemType.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorType.Visibility = Visibility.Collapsed;
                cb_itemType.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (cb_minUnit.SelectedIndex == -1)
            {
                p_errorMinUnit.Visibility = Visibility.Visible;
                tt_errorMinUnit.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_minUnit.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorMinUnit.Visibility = Visibility.Collapsed;
                cb_minUnit.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (cb_maxUnit.SelectedIndex == -1)
            {
                p_errorMaxUnit.Visibility = Visibility.Visible;
                tt_errorMaxUnit.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_maxUnit.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorMaxUnit.Visibility = Visibility.Collapsed;
                cb_maxUnit.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
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
            if (!tb_code.Text.Equals("") && !tb_name.Text.Equals("") && cb_categorie.SelectedIndex != -1 && cb_itemType.SelectedIndex != -1
                && cb_minUnit.SelectedIndex != -1 && cb_maxUnit.SelectedIndex != -1 && !tb_min.Text.Equals("") && !tb_max.Text.Equals(""))
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

                await RefrishItems();
                Txb_searchitems_TextChanged(null,null);
                //var items = await itemModel.GetAllItems();
                //dg_items.ItemsSource = items;
            }
        }
        async void Btn_deleteService_Click(object sender, RoutedEventArgs e)
        {
            if (service.costId != 0)
            {
                Boolean res = await serviceModel.delete(service.costId);

                if (res) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopDelete"));
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                refreshServicesGrid(item.itemId);

                tb_serviceName.Clear();
                tb_costVal.Clear();
            }
        }
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
                Boolean res = await itemModel.deleteItem(item.itemId, userId, item.canDelete);

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

        async void Btn_addProperties_Click(object sender, RoutedEventArgs e)
        {
            if (cb_value.SelectedValue == null)
            {
                p_errorValue.Visibility = Visibility.Visible;
                tt_errorValue.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorValue.Visibility = Visibility.Collapsed;
            }
            if (cb_value.SelectedValue != null && item.itemId > 0)
            {
                int propertyItemId = propItems[cb_value.SelectedIndex].propertyItemId;
                int itemId = (int)item.itemId;

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
        // add service to item
        async void Btn_addService_Click(object sender, RoutedEventArgs e)
        {
            if (tb_serviceName.Text.Equals(""))
            {
                p_errorServiceName.Visibility = Visibility.Visible;
                tt_errorServiceName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorServiceName.Visibility = Visibility.Collapsed;
            }
            if (tb_costVal.Text.Equals(""))
            {
                p_errorCostVal.Visibility = Visibility.Visible;
                tt_errorCostVal.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorCostVal.Visibility = Visibility.Collapsed;
            }
            if (!tb_serviceName.Text.Equals("") && !tb_costVal.Text.Equals(""))
            {
                service = new Service();
                service.name = tb_serviceName.Text;
                service.itemId = item.itemId;
                service.costVal = decimal.Parse(tb_costVal.Text);
                service.createUserId = MainWindow.userID;
                service.updateUserId = MainWindow.userID;

                Boolean res = await serviceModel.saveService(service);
                if (res) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd"));
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                refreshServicesGrid(item.itemId);

                tb_serviceName.Clear();
                tb_costVal.Clear();
            }
        }
        // add serial to item
        async void Btn_addSerial_Click(object sender, RoutedEventArgs e)
        {
            if (tb_serial.Text.Equals(""))
            {
                p_errorSerial.Visibility = Visibility.Visible;
                tt_errorSerial.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorSerial.Visibility = Visibility.Collapsed;
            }
            if (!tb_serial.Text.Equals(""))
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
                Boolean final = false;
                if (serial.isActive == 1)
                    final = true;
                Boolean res = await serialModel.delete(serial.serialId, (int)MainWindow.userID, final);

                if (res) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopDelete"));
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                refreshSerials(item.itemId);
            }
        }
        async void Btn_updateService_Click(object sender, RoutedEventArgs e)
        {
            if (tb_serviceName.Text.Equals(""))
            {
                p_errorServiceName.Visibility = Visibility.Visible;
                tt_errorServiceName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorServiceName.Visibility = Visibility.Collapsed;
            }
            if (tb_costVal.Text.Equals(""))
            {
                p_errorCostVal.Visibility = Visibility.Visible;
                tt_errorCostVal.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorCostVal.Visibility = Visibility.Collapsed;
            }
            if (!tb_serviceName.Text.Equals("") && !tb_costVal.Text.Equals("") && item != null)
            {
                service.name = tb_serviceName.Text;
                service.costVal = decimal.Parse(tb_costVal.Text);
                service.updateUserId = MainWindow.userID;
                Boolean res = await serviceModel.saveService(service);
                if (res) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                refreshServicesGrid(item.itemId);
            }
        }


        #endregion

        #region barcode
        //*****************************************8
        // add barcode to item
        async void Btn_addBarcode_Click(object sender, RoutedEventArgs e)
        {
            //check mandatory values
            var bc = new BrushConverter();
            if (cb_selectUnit.SelectedIndex == -1)
            {
                p_errorSelectUnit.Visibility = Visibility.Visible;
                tt_errorSelectUnit.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_selectUnit.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorSelectUnit.Visibility = Visibility.Collapsed;
                cb_selectUnit.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (tb_count.Text.Equals(""))
            {
                p_errorCount.Visibility = Visibility.Visible;
                tt_errorCount.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_count.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorCount.Visibility = Visibility.Collapsed;
                tb_count.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (cb_unit.SelectedIndex == -1)
            {
                p_errorUnit.Visibility = Visibility.Visible;
                tt_errorUnit.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_unit.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorUnit.Visibility = Visibility.Collapsed;
                cb_unit.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (tb_price.Text.Equals(""))
            {
                p_errorPrice.Visibility = Visibility.Visible;
                tt_errorPrice.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_price.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorPrice.Visibility = Visibility.Collapsed;
                tb_price.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (tb_barcode.Text.Equals(""))
            {
                p_errorBarcode.Visibility = Visibility.Visible;
                tt_errorBarcode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_barcode.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorBarcode.Visibility = Visibility.Collapsed;
                tb_barcode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (cb_selectUnit.SelectedIndex != -1 && !tb_count.Text.Equals("") && cb_unit.SelectedIndex != -1 && !tb_price.Text.Equals("") && !tb_barcode.Text.Equals(""))
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
                Btn_unitClear(sender, e);
            }
        }
        //**********************************************
        //**************update barcode******************
        async void Btn_updateBarcode_Click(object sender, RoutedEventArgs e)
        {
            //check mandatory values
            var bc = new BrushConverter();
            if (tb_count.Text.Equals(""))
            {
                p_errorCount.Visibility = Visibility.Visible;
                tt_errorCount.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_count.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorCount.Visibility = Visibility.Collapsed;
                tb_count.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (cb_unit.SelectedIndex == -1)
            {
                p_errorUnit.Visibility = Visibility.Visible;
                tt_errorUnit.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_unit.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorUnit.Visibility = Visibility.Collapsed;
                cb_unit.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (tb_price.Text.Equals(""))
            {
                p_errorPrice.Visibility = Visibility.Visible;
                tt_errorPrice.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_price.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorPrice.Visibility = Visibility.Collapsed;
                tb_price.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (tb_barcode.Text.Equals(""))
            {
                p_errorBarcode.Visibility = Visibility.Visible;
                tt_errorBarcode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_barcode.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorBarcode.Visibility = Visibility.Collapsed;
                tb_barcode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            if (cb_selectUnit.SelectedIndex != -1 && !tb_count.Text.Equals("") && cb_unit.SelectedIndex != -1 && !tb_price.Text.Equals("") && !tb_barcode.Text.Equals(""))
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


        private void tb_barcode_Generate(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string barCode = "";
            if (e.Key.ToString() == "Return" && !tb.Text.Equals(""))
                barCode = tb_barcode.Text;

            generateBarcode(barCode, false);
        }
        private void tb_barcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string barCode = "";
            if (!tb.Text.Equals(""))
                barCode = tb_barcode.Text;

            generateBarcode(barCode, false);
        }
        #endregion barcode

        #region validate
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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion


        #region fill
         void fillCategories()
        {
            //categories = await categoryModel.GetAllCategories();
            cb_categorie.ItemsSource = categories.ToList();
            cb_categorie.SelectedValuePath = "categoryId";
            cb_categorie.DisplayMemberPath = "name";
        }
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
        async void fillBarcodeList()
        {
            barcodesList = await itemUnitModel.getAllBarcodes();
        }

        #endregion





        #region refresh

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_code.Clear();
            tb_name.Clear();
            tb_details.Clear();
            cb_parentItem.SelectedIndex = -1;
            cb_categorie.SelectedIndex = -1;
            cb_itemType.SelectedIndex = -1;
            tb_taxes.Clear();
            tb_min.Clear();
            tb_max.Clear();
            cb_minUnit.SelectedIndex = -1;
            cb_maxUnit.SelectedIndex = -1;
            item = new Item();
        }
        private void btn_clearPropertiesClick(object sender, RoutedEventArgs e)
        {
            cb_selectProperties.SelectedIndex = -1;
            cb_value.SelectedIndex = -1;
            tb_serial.Text = "";
            tb_serial.Clear();
            tb_serviceName.Clear();
            tb_costVal.Clear();
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

            itemUnit = new ItemUnit();
            // set random barcode on image
            generateBarcode("", true);
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
        async void refreshServicesGrid(int itemId)
        {
            services = await serviceModel.GetItemServices(item.itemId);
            dg_service.ItemsSource = services.ToList();
        }
        #endregion

      

      



        /*
        private void dg_itemsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            
            if (dg_items.SelectedIndex != -1)
            {
                item = dg_items.SelectedItem as Item;
                this.DataContext = item;

                refreshPropertiesGrid(item.itemId);
                refreshSerials(item.itemId);
                refreshItemUnitsGrid(item.itemId);
                refreshServicesGrid(item.itemId);

            }
            if (item != null)
            {
                tb_code.Text = item.code;
                tb_name.Text = item.name;
                tb_details.Text = item.details;
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

                tb_taxes.Text = item.taxes.ToString();
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
        */

        #region SelectionChanged
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

                generateBarcode(itemUnit.barcode, false);
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
            p_errorSerial.Visibility = Visibility.Collapsed;

            var bc = new BrushConverter();
            tb_serial.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_serials.SelectedIndex != -1)
            {
                serial = dg_serials.SelectedItem as Serial;
            }
        }
        private void dg_services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorServiceName.Visibility = Visibility.Collapsed;
            p_errorCostVal.Visibility = Visibility.Collapsed;

            var bc = new BrushConverter();
            tb_serviceName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_costVal.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            if (dg_service.SelectedIndex != -1)
            {
                service = dg_service.SelectedItem as Service;
                tb_serviceName.Text = service.name;
                tb_costVal.Text = service.costVal.ToString();
            }
        }
        private async void Cb_parentItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item parentItem = new Item();
            int parentId = 0;
            if (cb_parentItem.SelectedIndex != -1 && item.itemId == 0)
            {
                parentItem = await itemModel.GetItemByID((int)cb_parentItem.SelectedValue);
                parentId = parentItem.itemId;

                if (parentItem.categoryId != null)
                    cb_categorie.SelectedValue = (int)parentItem.categoryId;
                if (parentItem.type != null)
                {
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
        async void Cb_categorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category cat = new Category();
            if (cb_parentItem.SelectedIndex == -1 && cb_categorie.SelectedIndex != -1)
            {
                int catId = (int)cb_categorie.SelectedValue;
                cat = await categoryModel.GetCategoryByID(catId);
                tb_taxes.Text = cat.taxes.ToString();
            }
        }
        private void CB_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_itemType.SelectedIndex == 2)
            {
                grid_service.Visibility = Visibility.Collapsed;
                grid_serial.Visibility = Visibility.Visible;
                line_topService.Visibility = Visibility.Collapsed;


            }
            else if (cb_itemType.SelectedIndex == 3)
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
        #endregion












        #region Categor and Item
        #region Refrish Y
        /// <summary>
        /// Category
        /// </summary>
        /// <returns></returns>
        async Task<IEnumerable<Category>> RefrishCategories()
        {
            categories = await categoryModel.GetAllCategories();
            return categories;
        }
        async void RefrishCategoriesCard()
        {
            if (categories is null)
                await RefrishCategories();
            categoriesQuery = categories.Where(x => x.isActive == tglCategoryState && x.parentId == categoryParentId);
            catigoriesAndItemsView.gridCatigories = grid_categoryCards;
            catigoriesAndItemsView.FN_refrishCatalogCard(categoriesQuery.ToList(), -1);
        }
        /// <summary>
        /// Item
        /// </summary>
        /// <returns></returns>

        async Task<IEnumerable<Item>> RefrishItems()
        {
            if(category.categoryId == 0)
                items = await itemModel.GetAllItems();
            else items = await itemModel.GetItemsInCategoryAndSub(category.categoryId);
            return items;
        }

        void RefrishItemsDatagrid(IEnumerable<Item> _items)
        {
            dg_items.ItemsSource = _items;
        }

        void RefrishItemsCard(IEnumerable<Item> _items)
        {

            catigoriesAndItemsView.gridCatigorieItems = grid_itemContainerCard;
            catigoriesAndItemsView.FN_refrishCatalogItem(_items.ToList(), "en", "purchase");
        }
        #endregion
        #region Get Id By Click  Y
        private void dg_items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_items.SelectedIndex != -1)
            {
                item = dg_items.SelectedItem as Item;
                this.DataContext = item;

                refreshPropertiesGrid(item.itemId);
                refreshSerials(item.itemId);
                refreshItemUnitsGrid(item.itemId);
                refreshServicesGrid(item.itemId);

            }
            if (item != null)
            {
                tb_code.Text = item.code;
                tb_name.Text = item.name;
                tb_details.Text = item.details;
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
                    switch (item.type)
                    {
                        case "n": cb_itemType.SelectedIndex = 0; break;
                        case "d": cb_itemType.SelectedIndex = 1; break;
                        case "sn": cb_itemType.SelectedIndex = 2; break;
                        case "sr": cb_itemType.SelectedIndex = 3; break;
                        case "p": cb_itemType.SelectedIndex = 4; break;
                    }
                }
                else
                    cb_itemType.SelectedValue = -1;

                tb_taxes.Text = item.taxes.ToString();
                tb_min.Text = item.min.ToString();
                tb_max.Text = item.max.ToString();

                if (item.minUnitId != null)
                    cb_minUnit.SelectedValue = (int)item.minUnitId;
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
        public async void ChangeCategoryIdEvent(int categoryId)
        {
            category = categories.ToList().Find(c => c.categoryId == categoryId);

            if (categories.Where(x =>
            x.isActive == tglCategoryState && x.parentId == category.categoryId).Count() != 0)
            {
                categoryParentId = category.categoryId;
                RefrishCategoriesCard();
            }
           
            generateTrack(categoryId);
            await RefrishItems();
            Txb_searchitems_TextChanged(null, null);
        }

        public void ChangeItemIdEvent(int itemId)
        {

            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            item = items.ToList().Find(c => c.itemId == itemId);
            if (item != null)
            {
                this.DataContext = item;


                refreshPropertiesGrid(item.itemId);
                refreshSerials(item.itemId);
                refreshItemUnitsGrid(item.itemId);
                refreshServicesGrid(item.itemId);

                tb_code.Text = item.code;
                tb_name.Text = item.name;
                tb_details.Text = item.details;
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
                    switch (item.type)
                    {
                        case "n": cb_itemType.SelectedIndex = 0; break;
                        case "d": cb_itemType.SelectedIndex = 1; break;
                        case "sn": cb_itemType.SelectedIndex = 2; break;
                        case "sr": cb_itemType.SelectedIndex = 3; break;
                        case "p": cb_itemType.SelectedIndex = 4; break;
                    }
                }
                else
                    cb_itemType.SelectedValue = -1;

                tb_taxes.Text = item.taxes.ToString();
                tb_min.Text = item.min.ToString();
                tb_max.Text = item.max.ToString();

                if (item.minUnitId != null)
                    cb_minUnit.SelectedValue = (int)item.minUnitId;
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
       
        #endregion
        #region Toggle Button Y
        /// <summary>
        /// Category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        /*
        private void Tgl_categoryIsActive_Checked(object sender, RoutedEventArgs e)
        {
            tglCategoryState = 1;
            RefrishCategoriesCard();



        }
        private void Tgl_categorIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            tglCategoryState = 0;
            RefrishCategoriesCard();
        }
        */
        /// <summary>
        /// Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tgl_itemIsActive_Checked(object sender, RoutedEventArgs e)
        {
            //if (categories is null)
            //    await RefrishCategories();
            tglItemState = 1;
            //tgl_categoryCardIsActive.IsChecked =
            //    tgl_categoryDatagridIsActive.IsChecked = true;
            Txb_searchitems_TextChanged(null, null);


        }
        private void Tgl_itemIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            //if (categories is null)
            //    await RefrishCategories();
            //categoriesQuery = categories.Where(x => x.isActive == 0);
            tglItemState = 0;
            //tgl_categoryCardIsActive.IsChecked =
            //    tgl_categoryDatagridIsActive.IsChecked = false;
            Txb_searchitems_TextChanged(null, null);
        }
        #endregion
        #region Switch Card/DataGrid Y

        private void Btn_itemsInCards_Click(object sender, RoutedEventArgs e)
        {
            grid_itemsDatagrid.Visibility = Visibility.Collapsed;
            grid_itemCards.Visibility = Visibility.Visible;
            path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_itemsInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

            tgl_itemIsActive.IsChecked = (tglItemState == 1) ? true : false;
            Txb_searchitems_TextChanged(null, null);

        }

        private void Btn_itemsInGrid_Click(object sender, RoutedEventArgs e)
        {
            grid_itemCards.Visibility = Visibility.Collapsed;
            grid_itemsDatagrid.Visibility = Visibility.Visible;
            path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

            tgl_itemIsActive.IsChecked = (tglItemState == 1) ? true : false;
            Txb_searchitems_TextChanged(null, null);
        }
        #endregion
        #region Search Y



        /// <summary>
        /// Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Txb_searchitems_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (items is null)
                await RefrishItems();
            txtItemSearch = txb_searchitems.Text.ToLower();
            itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
            x.name.ToLower().Contains(txtItemSearch) ||
            x.details.ToLower().Contains(txtItemSearch)
            ) && x.isActive == tglItemState);
            RefrishItemsDatagrid(itemsQuery);
            pageIndex = 1;
            paginationSetting(itemsQuery);
        }

        #endregion
        #region Pagination Y
        public int pageIndex = 1;
        private void Tb_pageNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            itemsQuery = items.Where(x => x.isActive == tglItemState);

            if (tb_pageNumberSearch.Text.Equals("") || int.Parse(tb_pageNumberSearch.Text) <= 0)
            {
                pageIndex = 1;
            }
            else if (((itemsQuery.Count() - 1) / 9) + 1 < int.Parse(tb_pageNumberSearch.Text))
            {
                pageIndex = ((itemsQuery.Count() - 1) / 9) + 1;
            }
            else
            {
                pageIndex = int.Parse(tb_pageNumberSearch.Text);
            }
            //pageIndex = tb_pageNumberSearch.Text.Equals("") ? 1 : int.Parse(tb_pageNumberSearch.Text);
            paginationSetting();
        }
        void pageNumberActive(Button btn, int indexContent)
        {
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            btn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Content = indexContent.ToString();
            //pageIndex = indexContent;
        }
        void pageNumberDisActive(Button btn, int indexContent)
        {
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#DFDFDF"));
            btn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#686868"));
            btn.Content = indexContent.ToString();

        }
        async void paginationSetting(IEnumerable<Item> _items = null)
        {
            if (_items is null)
            {
                if (items is null)
                {

                    await RefrishItems();
                    _items = items;
                }
                else
                    _items = items;
            }

            
            _items = _items.Where(x => x.isActive == tglItemState);
            if (2 >= ((_items.Count() - 1) / 9))
            {
                if (pageIndex == 1)
                {
                    pageNumberActive(btn_prevPage, 1);
                    pageNumberDisActive(btn_activePage, 2);
                    pageNumberDisActive(btn_nextPage, 3);
                }
                else if (pageIndex == 2)
                {
                    pageNumberDisActive(btn_prevPage, 1);
                    pageNumberActive(btn_activePage, 2);
                    pageNumberDisActive(btn_nextPage, 3);
                }
                else
                {
                    pageNumberDisActive(btn_prevPage, 1);
                    pageNumberDisActive(btn_activePage, 2);
                    pageNumberActive(btn_nextPage, 3);
                }
                if (0 >= ((_items.Count() - 1) / 9))
                {
                    btn_activePage.IsEnabled = false;
                }
                if (1 >= ((_items.Count() - 1) / 9))
                {
                    btn_nextPage.IsEnabled = false;
                }
                btn_firstPage.IsEnabled = false;
                btn_lastPage.IsEnabled = false;
            }
            else if (pageIndex == 1)
            {
                btn_firstPage.IsEnabled = false;
                btn_lastPage.IsEnabled = true;
                pageNumberActive(btn_prevPage, pageIndex);
                pageNumberDisActive(btn_activePage, pageIndex + 1);
                pageNumberDisActive(btn_nextPage, pageIndex + 2);
            }
            else if (pageIndex == 2)
            {
                pageNumberDisActive(btn_prevPage, 1);
                pageNumberActive(btn_activePage, 2);
                pageNumberDisActive(btn_nextPage, 3);
            }
            /////prev last
            else if (pageIndex == ((_items.Count() - 1) / 9))
            {
                btn_lastPage.IsEnabled = false;
                btn_firstPage.IsEnabled = true;

                pageNumberDisActive(btn_prevPage, pageIndex - 1);
                pageNumberActive(btn_activePage, pageIndex);
                pageNumberDisActive(btn_nextPage, pageIndex + 1);

            }
            ///// last
            else if ((pageIndex - 1) >= ((_items.Count() - 1) / 9))
            {
                btn_lastPage.IsEnabled = false;
                btn_firstPage.IsEnabled = true;

                pageNumberDisActive(btn_prevPage, pageIndex - 2);
                pageNumberDisActive(btn_activePage, pageIndex - 1);
                pageNumberActive(btn_nextPage, pageIndex);

            }
            else
            {
                pageNumberDisActive(btn_prevPage, pageIndex - 1);
                pageNumberActive(btn_activePage, pageIndex);
                pageNumberDisActive(btn_nextPage, pageIndex + 1);
                btn_lastPage.IsEnabled = true;
                btn_firstPage.IsEnabled = true;

            }
             if (0 < ((_items.Count() - 1) / 9))
                {
                    btn_activePage.IsEnabled = true;
                }
                if (1 < ((_items.Count() - 1) / 9))
                {
                    btn_nextPage.IsEnabled = true;
                }
            if (2 < ((_items.Count() - 1) / 9))
            {
                btn_firstPage.IsEnabled = true;
                btn_lastPage.IsEnabled = true;
            }
               
            itemsQuery = _items.Skip((pageIndex - 1) * 9).Take(9);
            RefrishItemsCard(itemsQuery);
            //RefrishItemCard(items.Skip(pageIndex - 1 * 9).Take(9));
        }


        private void Btn_firstPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            paginationSetting();
        }

        private void Btn_prevPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_prevPage.Content.ToString());
            paginationSetting();
        }

        private void Btn_activePage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_activePage.Content.ToString());
            paginationSetting();
        }

        private void Btn_nextPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_nextPage.Content.ToString());
            paginationSetting();
        }

        private void Btn_lastPage_Click(object sender, RoutedEventArgs e)
        {
            
            itemsQuery = items.Where(x => x.isActive == tglItemState);
            pageIndex = ((itemsQuery.Count() - 1) / 9) + 1;
            paginationSetting();
        }
        #endregion

        #region categoryPathControl Y

        async void generateTrack(int categorypaPathId)
        {
            grid_categoryControlPath.Children.Clear();
            IEnumerable<Category> categoriesPath = await
            categoryModel.GetCategoryTreeByID(categorypaPathId);

            int count = 0;
            foreach (var item in categoriesPath.Reverse())
            {
                if (categories.Where(x => x.parentId == item.categoryId).Count() != 0)
                {
                    Button b = new Button();
                    b.Content = " > " + item.name + " ";
                    b.Padding = new Thickness(0);
                    b.Margin = new Thickness(0);
                    b.Background = null;
                    b.BorderThickness = new Thickness(0);
                    b.FontFamily = Application.Current.Resources["Font-cairo-light"] as FontFamily;
                    b.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6e6e6e"));
                    b.FontSize = 14;
                    Grid.SetColumn(b, count);
                    b.DataContext = item;
                    b.Name = "category" + item.categoryId;
                    b.Tag = item.categoryId;
                    b.Click += new RoutedEventHandler(getCategoryIdFromPath);
                    count++;
                    grid_categoryControlPath.Children.Add(b);
                }
            }


        }
        private async void getCategoryIdFromPath(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (!string.IsNullOrEmpty(b.Tag.ToString()))
            {
                generateTrack(int.Parse(b.Tag.ToString()));
                categoryParentId = int.Parse(b.Tag.ToString());
                RefrishCategoriesCard();


                category.categoryId = int.Parse(b.Tag.ToString());

            }
            await RefrishItems();
            Txb_searchitems_TextChanged(null, null);

        }
        private async void Btn_getAllCategory_Click(object sender, RoutedEventArgs e)
        {
            categoryParentId = 0;
            RefrishCategoriesCard();
            grid_categoryControlPath.Children.Clear();
            category.categoryId = 0;
            await RefrishItems();
            Txb_searchitems_TextChanged(null, null);
        }

        #endregion
        #endregion

    }
}

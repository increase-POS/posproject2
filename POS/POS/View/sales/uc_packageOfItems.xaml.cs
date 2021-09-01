using POS.Classes;
using netoaster;
using POS.controlTemplate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
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
using Microsoft.Win32;
using System.Windows.Resources;
using System.Threading;
using System.Windows.Media.Animation;
using Zen.Barcode;
using POS.View.windows;
namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_packageOfItems.xaml
    /// </summary>
    public partial class uc_packageOfItems : UserControl
    {
        string basicsPermission = "package_basics";
        string itemsPermission = "package_items";
        private static uc_packageOfItems _instance;
        public static uc_packageOfItems Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_packageOfItems();
                return _instance;
            }
        }
        public uc_packageOfItems()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this);
            }
        }

        Category categoryModel = new Category();
        List<Category> categories;
        static private int _InternalCounter = 0;
        List<ItemUnit> barcodesList;
        ItemUnit itemUnitModel = new ItemUnit();

        // item object
        Item item = new Item();
        // item unit object
        ItemUnit itemUnit = new ItemUnit();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        Item itemModel = new Item();
        Unit unitModel = new Unit();
        Property propertyModel = new Property();
        PropertiesItems propItemsModel = new PropertiesItems();
        ItemsProp itemsPropModel = new ItemsProp();
        Serial serialModel = new Serial();
        Service serviceModel = new Service();
        IEnumerable<Category> categoriesQuery;
        IEnumerable<Item> items;
        IEnumerable<Item> itemsQuery;
        Category category = new Category();
        // item object
        //item property value object
        ItemsProp itemProp = new ItemsProp();
        // serial object
        Serial serial = new Serial();
        // item unit object
        // service object
        Service service = new Service();
        //string selectedType = "";

        ImageBrush brush = new ImageBrush();

        DataGrid dt = new DataGrid();

        List<int> categoryIds = new List<int>();
        List<string> categoryNames = new List<string>();
        //List<Property> properties;
        //List<PropertiesItems> propItems;
        List<Unit> units = new List<Unit>();
        //List<ItemsProp> itemsProp;
        //List<Serial> itemSerials;
        List<ItemUnit> itemUnits;
        //List<Service> services;
        public byte tglCategoryState = 1;
        public byte tglItemState;
        int? categoryParentId = 0;
        public string txtItemSearch;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();

        List<int> unitIds = new List<int>();
        List<string> unitNames = new List<string>();

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);
                btn_items.IsEnabled = false;

                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
                catigoriesAndItemsView.ucPackageOfItems = this;

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }
                translate();
                #endregion

                await fillCategories();

                generateBarcode();

                await fillBarcodeList();

                tb_code.Focus();
                SectionData.clearValidate(tb_code, p_errorCode);

                units = await unitModel.GetUnitsAsync();
                var uQuery = units.Where(u => u.name == "package").FirstOrDefault();
                unitpackageId = uQuery.unitId;

                await RefrishCategoriesCard();
                Txb_searchitems_TextChanged(null, null);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task fillBarcodeList()
        {
            barcodesList = await itemUnitModel.getAllBarcodes();
        }
        private void generateBarcode(string barcodeString = "")
        {
            if (barcodeString == "")
            {
                barcodeString = generateRandomBarcode();
                if (barcodesList != null)
                {
                    ItemUnit unit1 = barcodesList.ToList().Find(c => c.barcode == barcodeString);
                    if (unit1 != null)
                        barcodeString = generateRandomBarcode();
                }
                tb_barcode.Text = barcodeString;
            }
            tb_barcode.Text = barcodeString;
            // create encoding object
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

            System.Drawing.Bitmap serial_bitmap = (System.Drawing.Bitmap)barcode.Draw(barcodeString, 60);
            System.Drawing.ImageConverter ic = new System.Drawing.ImageConverter();
            //generate bitmap
            img_barcode.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(serial_bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //clear
                btn_items.IsEnabled = false;

                tb_code.Clear();
                tb_name.Clear();
                tb_details.Clear();
                cb_categorie.SelectedIndex = -1;
                tb_taxes.Clear();
                item = new Item();
                tb_price.Clear();
                // set random barcode on image
                generateBarcode();
                //itemUnit = new ItemUnit();

                SectionData.clearValidate(tb_code, p_errorCode);
                SectionData.clearValidate(tb_name, p_errorName);
                SectionData.clearComboBoxValidate(cb_categorie, p_errorCategorie);
                SectionData.clearValidate(tb_taxes, p_errorTaxes);
                SectionData.clearValidate(tb_price, p_errorPrice);

                clearImg();

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void clearImg()
        {
            //clear img
            Uri resourceUri = new Uri("pic/no-image-icon-125x125.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            img_item.Background = brush;
        }

        static public string generateRandomBarcode()
        {
            var now = DateTime.Now;

            var days = (int)(now - new DateTime(2000, 1, 1)).TotalDays;
            var seconds = (int)(now - DateTime.Today).TotalSeconds;

            var counter = _InternalCounter++ % 100;

            return days.ToString("00000") + seconds.ToString("00000") + counter.ToString("00");
        }
        async Task fillCategories()
        {
            categories = await categoryModel.GetAllCategories(MainWindow.userID.Value);
            cb_categorie.ItemsSource = categories.ToList();
            cb_categorie.SelectedValuePath = "categoryId";
            cb_categorie.DisplayMemberPath = "name";
        }

        private void translate()
        {
            txt_package.Text = MainWindow.resourcemanager.GetString("trPackage");
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_searchitems, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_details, MainWindow.resourcemanager.GetString("trDetailsHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trCode"));

            txt_secondaryInformation.Text = MainWindow.resourcemanager.GetString("trSecondaryInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_categorie, MainWindow.resourcemanager.GetString("trSelectCategorieHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_taxes, MainWindow.resourcemanager.GetString("trTaxesHint"));

            txt_barcode.Text = MainWindow.resourcemanager.GetString("trBarCode");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_price, MainWindow.resourcemanager.GetString("trPrice"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_barcode, MainWindow.resourcemanager.GetString("trBarcodeHint"));

            btn_items.Content = MainWindow.resourcemanager.GetString("trItems");
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

            txt_active.Text = MainWindow.resourcemanager.GetString("trActive");

            dg_items.Columns[0].Header = MainWindow.resourcemanager.GetString("trCode");
            dg_items.Columns[1].Header = MainWindow.resourcemanager.GetString("trName");
            dg_items.Columns[2].Header = MainWindow.resourcemanager.GetString("trDetails");
            dg_items.Columns[3].Header = MainWindow.resourcemanager.GetString("trCategorie");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_code.Content = MainWindow.resourcemanager.GetString("trCode");
            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_details.Content = MainWindow.resourcemanager.GetString("trDetails");
            tt_category.Content = MainWindow.resourcemanager.GetString("trCategorie");
            tt_tax.Content = MainWindow.resourcemanager.GetString("trTax");
            tt_price.Content = MainWindow.resourcemanager.GetString("trPrice");
            tt_barCode.Content = MainWindow.resourcemanager.GetString("trBarcode");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            tt_grid.Content = MainWindow.resourcemanager.GetString("trViewGrid");
            tt_items.Content = MainWindow.resourcemanager.GetString("trViewItems");
        }

        private void tb_barcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                string barCode = tb_barcode.Text;
                generateBarcode(barCode);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void tb_upperLimit_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void tb_barcode_Generate(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (e.Key.ToString() == "Return")
                {
                    string barCode = tb_barcode.Text;
                    generateBarcode(barCode);
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {

                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        #region Categor and Item

        #region Refrish Y
        /// <summary>
        /// Category
        /// </summary>
        /// <returns></returns>
        async Task<IEnumerable<Category>> RefrishCategories()
        {
            categories = await categoryModel.GetAllCategories(MainWindow.userID.Value);
            return categories;
        }

        async Task RefrishCategoriesCard()
        {
            if (categories is null)
                await RefrishCategories();
            categoriesQuery = categories.Where(x => x.isActive == tglCategoryState && x.parentId == categoryParentId);
            catigoriesAndItemsView.gridCatigories = grid_categoryCards;
            generateCoulmnCategoriesGrid(categoriesQuery.Count());
            catigoriesAndItemsView.FN_refrishCatalogCard(categoriesQuery.ToList(), -1);
        }

        void generateCoulmnCategoriesGrid(int column)
        {
            #region
            grid_categoryCards.ColumnDefinitions.Clear();
            ColumnDefinition[] cd = new ColumnDefinition[column];
            for (int i = 0; i < column; i++)
            {
                cd[i] = new ColumnDefinition();
                cd[i].Width = new GridLength(110, GridUnitType.Pixel);
                grid_categoryCards.ColumnDefinitions.Add(cd[i]);
            }
            #endregion
        }
        /// <summary>
        /// Item
        /// </summary>
        /// <returns></returns>
        Package packageModel = new Package();
        async Task<IEnumerable<Item>> RefrishItems()
        {
            if (category.categoryId == 0)
                items = await packageModel.GetPackages();
            else items = await itemModel.GetItemsInCategoryAndSub(category.categoryId);
            items = items.Where(x => x.type == "p");
            return items;
        }

        void RefrishItemsDatagrid(IEnumerable<Item> _items)
        {
            dg_items.ItemsSource = _items;
        }


        void RefrishItemsCard(IEnumerable<Item> _items)
        {
            grid_itemContainerCard.Children.Clear();
            catigoriesAndItemsView.gridCatigorieItems = grid_itemContainerCard;
            catigoriesAndItemsView.FN_refrishCatalogItem(_items.ToList(), "en", "purchase");
        }
        private void Grid_containerCard_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion

        #region Get Id By Click  Y
        int itemUnitId = 0;
        private async void dg_items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //selection
                if (dg_items.SelectedIndex != -1)
                {
                    item = dg_items.SelectedItem as Item;
                    this.DataContext = item;
                }
                if (item != null)
                {
                    btn_items.IsEnabled = true;
                    cb_categorie.SelectedValue = item.categoryId;
                    List<ItemUnit> itemUnits = new List<ItemUnit>();
                    itemUnits = await itemUnitModel.Getall();
                    var uQuery = itemUnits.Where(iu => iu.itemId == item.itemId && iu.unitId == unitpackageId).FirstOrDefault();
                    if (uQuery != null)
                    {
                        itemUnitId = uQuery.itemUnitId;
                        tb_price.Text = uQuery.price.ToString();
                        tb_barcode.Text = uQuery.barcode;
                    }
                    else
                    {
                        tb_price.Text = "";
                        tb_barcode.Text = "";
                    }
                    getImg();
                }
                //tb_barcode.Focus();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void getImg()
        {
            if (string.IsNullOrEmpty(item.image))
            {
                SectionData.clearImg(img_item);
            }
            else
            {
                byte[] imageBuffer = await itemModel.downloadImage(item.image); // read this as BLOB from your DB

                var bitmapImage = new BitmapImage();
                if (imageBuffer != null)
                {
                    using (var memoryStream = new MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }

                    img_item.Background = new ImageBrush(bitmapImage);
                }
                // configure trmporary path
                string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string tmpPath = System.IO.Path.Combine(dir, Global.TMPItemsFolder);
                tmpPath = System.IO.Path.Combine(tmpPath, item.image);
                openFileDialog.FileName = tmpPath;
            }

        }
        public async Task ChangeCategoryIdEvent(int categoryId)
        {
            category = categories.ToList().Find(c => c.categoryId == categoryId);

            if (categories.Where(x =>
            x.isActive == tglCategoryState && x.parentId == category.categoryId).Count() != 0)
            {
                categoryParentId = category.categoryId;
                await RefrishCategoriesCard();
            }
            tb_barcode.Focus();

            await generateTrack(categoryId);
            await RefrishItems();
            Txb_searchitems_TextChanged(null, null);
        }

        public async Task ChangeItemIdEvent(int itemId)
        {//change id
            item = items.ToList().Find(c => c.itemId == itemId);
            if (item != null)
            {
                this.DataContext = item;
                btn_items.IsEnabled = true;
                cb_categorie.SelectedValue = item.categoryId;
                List<ItemUnit> itemUnits = new List<ItemUnit>();
                itemUnits = await itemUnitModel.Getall();
                var uQuery = itemUnits.Where(iu => iu.itemId == itemId && iu.unitId == unitpackageId).FirstOrDefault();
                if (uQuery != null)
                {
                    itemUnitId = uQuery.itemUnitId;
                    tb_price.Text = uQuery.price.ToString();
                    tb_barcode.Text = uQuery.barcode;
                }
                else
                {
                    tb_price.Text = "";
                    tb_barcode.Text = "";
                }
                getImg();
            }
        }

        #endregion

        #region Toggle Button Y

        /// <summary>
        /// Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tgl_itemIsActive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                tglItemState = 1;
               
                Txb_searchitems_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Tgl_itemIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender != null)
                    SectionData.StartAwait(grid_main);

                tglItemState = 0;
                
                Txb_searchitems_TextChanged(null, null);
                tb_barcode.Focus();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion

        #region Switch Card/DataGrid Y

        private void Btn_itemsInCards_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                grid_itemsDatagrid.Visibility = Visibility.Collapsed;
                grid_itemCards.Visibility = Visibility.Visible;
                path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
                path_itemsInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

                tgl_itemIsActive.IsChecked = (tglItemState == 1) ? true : false;
                Txb_searchitems_TextChanged(null, null);
                tb_barcode.Focus();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_itemsInGrid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                grid_itemCards.Visibility = Visibility.Collapsed;
                grid_itemsDatagrid.Visibility = Visibility.Visible;
                path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
                path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

                tgl_itemIsActive.IsChecked = (tglItemState == 1) ? true : false;
                Txb_searchitems_TextChanged(null, null);
                tb_barcode.Focus();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
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
             try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //search
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    if (items is null)
                        await RefrishItems();
                    txtItemSearch = txb_searchitems.Text.ToLower();
                    pageIndex = 1;

                    #region
                    itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
                    x.name.ToLower().Contains(txtItemSearch) ||
                    x.details.ToLower().Contains(txtItemSearch)
                    ) && x.isActive == tglItemState);
                    txt_count.Text = itemsQuery.Count().ToString();
                    if (btns is null)
                        btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
                    RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
                    #endregion
                    RefrishItemsDatagrid(itemsQuery);
                    //tb_barcode.Focus();
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        #endregion

        #region Pagination Y
        Pagination pagination = new Pagination();
        Button[] btns;
        public int pageIndex = 1;

        private void Tb_pageNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                itemsQuery = items.Where(x => x.isActive == tglItemState);

                if (tb_pageNumberSearch.Text.Equals(""))
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

                #region
                itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
                x.name.ToLower().Contains(txtItemSearch) ||
                x.details.ToLower().Contains(txtItemSearch)
                ) && x.isActive == tglItemState);
                txt_count.Text = itemsQuery.Count().ToString();
                RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
                #endregion
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void Btn_firstPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                pageIndex = 1;
                #region
                itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
                x.name.ToLower().Contains(txtItemSearch) ||
                x.details.ToLower().Contains(txtItemSearch)
                ) && x.isActive == tglItemState);
                txt_count.Text = itemsQuery.Count().ToString();
                RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
                #endregion
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_prevPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                pageIndex = int.Parse(btn_prevPage.Content.ToString());
                #region
                itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
                x.name.ToLower().Contains(txtItemSearch) ||
                x.details.ToLower().Contains(txtItemSearch)
                ) && x.isActive == tglItemState);
                txt_count.Text = itemsQuery.Count().ToString();
                RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
                #endregion
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_activePage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                pageIndex = int.Parse(btn_activePage.Content.ToString());
                #region
                itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
                x.name.ToLower().Contains(txtItemSearch) ||
                x.details.ToLower().Contains(txtItemSearch)
                ) && x.isActive == tglItemState);
                txt_count.Text = itemsQuery.Count().ToString();
                RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
                #endregion
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_nextPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                pageIndex = int.Parse(btn_nextPage.Content.ToString());
                #region
                itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
                x.name.ToLower().Contains(txtItemSearch) ||
                x.details.ToLower().Contains(txtItemSearch)
                ) && x.isActive == tglItemState);
                txt_count.Text = itemsQuery.Count().ToString();
                RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
                #endregion
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_lastPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                itemsQuery = items.Where(x => x.isActive == tglCategoryState);
                pageIndex = ((itemsQuery.Count() - 1) / 9) + 1;
                #region
                itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
                x.name.ToLower().Contains(txtItemSearch) ||
                x.details.ToLower().Contains(txtItemSearch)
                ) && x.isActive == tglItemState);
                txt_count.Text = itemsQuery.Count().ToString();
                RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
                #endregion
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion

        #region categoryPathControl Y

        async Task generateTrack(int categorypaPathId)
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
            tb_barcode.Focus();

        }
        private async void getCategoryIdFromPath(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                 Button b = (Button)sender;
                if (!string.IsNullOrEmpty(b.Tag.ToString()))
                {
                    await generateTrack(int.Parse(b.Tag.ToString()));
                    categoryParentId = int.Parse(b.Tag.ToString());
                    await RefrishCategoriesCard();
                    category.categoryId = int.Parse(b.Tag.ToString());
                }
                tb_barcode.Focus();
                await RefrishItems();
                Txb_searchitems_TextChanged(null, null);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_getAllCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                categoryParentId = 0;
                await RefrishCategoriesCard();
                grid_categoryControlPath.Children.Clear();
                category.categoryId = 0;
                await RefrishItems();
                Txb_searchitems_TextChanged(null, null);
                tb_barcode.Focus();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion

        #endregion
        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //excel
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    this.Dispatcher.Invoke(() =>
                {
                    Thread t1 = new Thread(FN_ExportToExcel);
                    t1.SetApartmentState(ApartmentState.STA);
                    t1.Start();
                });
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }



        private void FN_ExportToExcel()
        {
            var QueryExcel = itemsQuery.AsEnumerable().Select(x => new
            {
                Code = x.code,
                Name = x.name,
                Details = x.details,
                Categoty = x.categoryName
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trCode");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trDetails");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trCategorie");

            ExportToExcel.Export(DTForExcel);
        }
        #endregion

        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //refresh
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {

                    await RefrishItems();
                    Txb_searchitems_TextChanged(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            try
            {

                string name = sender.GetType().Name;
                validateEmpty(name, sender);
                var txb = sender as TextBox;
                if ((sender as TextBox).Name == "tb_taxes" || (sender as TextBox).Name == "tb_price")
                    SectionData.InputJustNumber(ref txb);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Tb_PreventSpaces(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void validateEmpty(string name, object sender)
        {
            try
            {
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_code")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
                    else if ((sender as TextBox).Name == "tb_name")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //else if ((sender as TextBox).Name == "tb_taxes")
                    //    SectionData.validateEmptyTextBox((TextBox)sender, p_errorTaxes, tt_errorTaxes, "trEmptyTax");
                    else if ((sender as TextBox).Name == "tb_price")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorPrice, tt_errorPrice, "trEmptyPrice");
                }
                else if (name == "ComboBox")
                {
                    if ((sender as ComboBox).Name == "cb_categorie")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCategorie, tt_errorCategorie, "trErrorEmptyCategoryToolTip");
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Tb_decimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                //decimal
                var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
                if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                    e.Handled = false;

                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Tb_EnglishAndDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                //only english and digits
                Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
                if (!regex.IsMatch(e.Text))
                    e.Handled = true;

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        int unitpackageId = 0;
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //add
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                    validateEmptyEntries();

                    Boolean codeAvailable = await checkCodeAvailabiltiy(tb_code.Text);

                    decimal tax = 0;
                    if (tb_taxes.Text != "")
                        tax = decimal.Parse(tb_taxes.Text);

                    decimal price = 0;
                    if (tb_price.Text != "")
                        price = decimal.Parse(tb_price.Text);

                    if ((!tb_code.Text.Equals("")) && (!tb_name.Text.Equals("")) && (!cb_categorie.Text.Equals("")) &&
                        //(!tb_taxes.Text.Equals("")) && 
                        (!tb_price.Text.Equals("")) &&
                        codeAvailable)
                    {
                        //item record
                        item = new Item();
                        item.code = tb_code.Text;
                        item.name = tb_name.Text;
                        item.details = tb_details.Text;
                        item.type = "p";
                        item.image = "";
                        item.taxes = tax;
                        item.isActive = 1;
                        item.categoryId = Convert.ToInt32(cb_categorie.SelectedValue);
                        item.createUserId = MainWindow.userID;

                        string res = await itemModel.saveItem(item);
                        if (!res.Equals("0"))
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                        int itemId = int.Parse(res);

                        if (openFileDialog.FileName != "")
                        {
                            await itemModel.uploadImage(openFileDialog.FileName, Md5Encription.MD5Hash("Inc-m" + itemId.ToString()), itemId);
                            openFileDialog.FileName = "";
                        }

                        //itemunit record
                        itemUnit = new ItemUnit();
                        itemUnit.itemId = itemId;
                        itemUnit.unitId = unitpackageId;
                        itemUnit.price = price;
                        itemUnit.defaultSale = 1;
                        itemUnit.barcode = tb_barcode.Text;
                        itemUnit.createUserId = MainWindow.userID;

                        string s = await itemUnitModel.saveItemUnit(itemUnit);

                        await RefrishItems();
                        Txb_searchitems_TextChanged(null, null);
                        btn_clear_Click(null, null);
                    }

                    tb_code.Focus();
                    SectionData.clearValidate(tb_code, p_errorCode);

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //update
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update") || SectionData.isAdminPermision())
                {
                    validateEmptyEntries();

                    Boolean codeAvailable = await checkCodeAvailabiltiy(tb_code.Text);

                    decimal tax = 0;
                    if (tb_taxes.Text != "")
                        tax = decimal.Parse(tb_taxes.Text);

                    decimal price = 0;
                    if (tb_price.Text != "")
                        price = decimal.Parse(tb_price.Text);

                    if ((!tb_code.Text.Equals("")) && (!tb_name.Text.Equals("")) && (!cb_categorie.Text.Equals("")) &&
                        //(!tb_taxes.Text.Equals("")) && 
                        (!tb_price.Text.Equals("")) &&
                        codeAvailable)
                    {
                        item.code = tb_code.Text;
                        item.name = tb_name.Text;
                        item.details = tb_details.Text;
                        item.type = "p";
                        item.image = "";
                        item.taxes = tax;
                        item.isActive = 1;
                        item.categoryId = Convert.ToInt32(cb_categorie.SelectedValue);
                        item.createUserId = MainWindow.userID;

                        string res = await itemModel.saveItem(item);
                        if (!res.Equals("0"))
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                        int itemId = int.Parse(res);

                        if (openFileDialog.FileName != "")
                        {
                            await itemModel.uploadImage(openFileDialog.FileName, Md5Encription.MD5Hash("Inc-m" + itemId.ToString()), itemId);
                            openFileDialog.FileName = "";
                        }

                        List<ItemUnit> itemUnits = new List<ItemUnit>();
                        itemUnits = await itemUnitModel.Getall();
                        var uQuery = itemUnits.Where(iu => iu.itemId == itemId && iu.unitId == unitpackageId).FirstOrDefault();
                        int itemUnitId = 0;
                        if (uQuery != null)
                            itemUnitId = uQuery.itemUnitId;

                        //itemunit record
                        itemUnit.itemUnitId = itemUnitId;
                        itemUnit.itemId = itemId;
                        itemUnit.unitId = unitpackageId;
                        itemUnit.price = price;
                        itemUnit.barcode = tb_barcode.Text;
                        itemUnit.createUserId = MainWindow.userID;

                        string s = await itemUnitModel.saveItemUnit(itemUnit);

                        await RefrishItems();
                        Txb_searchitems_TextChanged(null, null);
                    }

                    tb_code.Focus();
                    SectionData.clearValidate(tb_code, p_errorCode);

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //delete
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete") || SectionData.isAdminPermision())
                {
                    if (item.itemId != 0)
                    {
                        if ((!item.canDelete) && (item.isActive == 0))
                        {
                            #region
                            Window.GetWindow(this).Opacity = 0.2;
                            wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                            w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                            w.ShowDialog();
                            Window.GetWindow(this).Opacity = 1;
                            #endregion
                            if (w.isOk)
                                await activate();
                        }
                        else
                        {
                            #region
                            Window.GetWindow(this).Opacity = 0.2;
                            wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                            if (item.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                            if (!item.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                            w.ShowDialog();
                            Window.GetWindow(this).Opacity = 1;
                            #endregion
                            if (w.isOk)
                            {
                                string popupContent = "";
                                if (item.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                                if ((!item.canDelete) && (item.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                                bool b = await itemModel.deleteItem(item.itemId, MainWindow.userID.Value, item.canDelete);

                                if (b)
                                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopDelete"), animation: ToasterAnimation.FadeIn);

                                else
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                            }
                        }

                        await RefrishItems();
                        Txb_searchitems_TextChanged(null, null);
                    }
                    //clear textBoxs
                    btn_clear_Click(null, null);
                    tb_code.Focus();
                    SectionData.clearValidate(tb_code, p_errorCode);

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async Task activate()
        {//activate
            item.isActive = 1;

            string s = await itemModel.saveItem(item);

            if (!s.Equals("0"))
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefrishItems();
            Txb_searchitems_TextChanged(null, null);
        }

        private async Task<Boolean> checkCodeAvailabiltiy(string code)
        {
            List<Item> items = await itemModel.GetAllItems();

            if (items != null)
                if (items.Any(i => i.code == code && i.itemId != item.itemId))
                {
                    SectionData.validateDuplicateCode(tb_code, p_errorCode, tt_errorCode, "trDuplicateCodeToolTip");
                    return false;
                }
                else
                {
                    SectionData.clearValidate(tb_code, p_errorCode);
                    return true;
                }
            else
            {
                SectionData.clearValidate(tb_code, p_errorCode);
                return true;
            }

        }

        private void validateEmptyEntries()
        {
            //chk empty code
            SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
            //chk empty name 
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty category
            SectionData.validateEmptyComboBox(cb_categorie, p_errorCategorie, tt_errorCategorie, "trErrorEmptyCategoryToolTip");
            //chk empty tax
            //SectionData.validateEmptyTextBox(tb_taxes, p_errorTaxes, tt_errorTaxes, "trEmptyTax");
            //chk empty price
            SectionData.validateEmptyTextBox(tb_price, p_errorPrice, tt_errorPrice, "trEmptyPrice");
        }

        private void Img_item_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //select image
                openFileDialog.Filter = "Images|*.png;*.jpg;*.bmp;*.jpeg;*.jfif";
                if (openFileDialog.ShowDialog() == true)
                {
                    brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                    img_item.Background = brush;
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private   void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //items
                if (MainWindow.groupObject.HasPermissionAction(itemsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    SectionData.clearValidate(tb_code, p_errorCode);

                    Window.GetWindow(this).Opacity = 0.2;

                    wd_itemsUnitList w = new wd_itemsUnitList();

                    w.itemId = item.itemId;
                    w.itemUnitId = itemUnitId;
                    w.ShowDialog();
                    if (w.isActive)
                    {

                    }

                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    List<Item> pkg = await packageModel.GetPackages();
                    MessageBox.Show(pkg.Count.ToString());
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {


                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_pieChart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
         
        }
    }
}

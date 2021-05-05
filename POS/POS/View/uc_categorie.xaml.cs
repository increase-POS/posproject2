using client_app.Classes;
using POS.Classes;
using POS.controlTemplate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_categorie.xaml
    /// </summary>
    public partial class uc_categorie : UserControl
    {
        public int CategorieId;
        Category categoryModel = new Category();
        Item itemModel = new Item();
        IEnumerable<Category> categories;
        IEnumerable<Category> categoriesQuery;
        IEnumerable<Item> items;
        IEnumerable<Item> itemsQuery;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        int selectedItemId = 0;
        public uc_categorie()
        {
            InitializeComponent();
        }
        private async void fillCategories()
        {
            if (categories is null)
                await RefrishCategory();
            cb_parentCategorie.ItemsSource = categories.ToList();
            cb_parentCategorie.SelectedValuePath = "categoryId";
            cb_parentCategorie.DisplayMemberPath = "name";

        }
        private void translate()
        {
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_categoryCode, MainWindow.resourcemanager.GetString("trCodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_details, MainWindow.resourcemanager.GetString("trDetailsHint"));
            txt_secondaryInformation.Text = MainWindow.resourcemanager.GetString("trSecondaryInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_parentCategorie, MainWindow.resourcemanager.GetString("trParentCategorieHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_taxes, MainWindow.resourcemanager.GetString("trTaxesHint"));
         // MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_categorie, MainWindow.resourcemanager.GetString("trCategorie"));
            txt_categorie.Text = MainWindow.resourcemanager.GetString("trCategorie");

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
           
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            catigoriesAndItemsView.ucCategorie = this;
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucCategorie.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucCategorie.FlowDirection = FlowDirection.RightToLeft;
            }
            translate();

            #region Generate catigory and item Y
            //catigoriesAndItemsView.gridCatigories = Grid_categorie;
            //catigoriesAndItemsView.gridCatigorieItems = Grid_CategorieItem;
            //await RefrishCategory();
            //RefrishCategoryCard(categories);
            //await RefrishItem();
            //RefrishItemCardAndDatagrid(items);
            #endregion
            fillCategories();
            //pageIndex = 1;
            //paginationSetting();

        }
        private void Cb_parentCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  selectedItemId = [cb_parentCategorie.SelectedIndex];


        }
        private void DG_Items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorParentCategorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            Category category = new Category();

            if (DG_Items.SelectedIndex != -1)
            {
                category = DG_Items.SelectedItem as Category;
                this.DataContext = category;
            }
            if (category != null)
            {
                if (category.categoryId != 0)
                {
                    CategorieId = category.categoryId;
                }


            }
        }
        #region Refrish Y
        async Task<bool> RefrishCategory()
        {
            categories = await categoryModel.GetAllCategories();
            return true;
        }
        void   RefrishCategoryCard(IEnumerable<Category> _categories)
        {
            catigoriesAndItemsView.gridCatigories = Grid_categorie;
            catigoriesAndItemsView.FN_refrishCatalogCard(_categories.ToList());
        }
        async Task<bool> RefrishItem()
        {
            items = await itemModel.GetAllItems();
            return true;
        }
        void RefrishItemDatagrid(IEnumerable<Item> _items )
        {
            DG_Items.ItemsSource = _items;
        }
        void RefrishItemCard(IEnumerable<Item> _items )
        {
            catigoriesAndItemsView.gridCatigorieItems = Grid_CategorieItem;
            catigoriesAndItemsView.FN_refrishCatalogItem(_items.ToList(), MainWindow.lang, "sale");
        }
        #endregion
        #region Get Id By Click  Y
        public void ChangeCategorieIdEvent(int categoryId)
        {
            //////////////
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorParentCategorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            //////////////

            this.DataContext = categories.ToList().Find(c => c.categoryId == categoryId);

        }
        public void testChangeCategorieItemsIdEvent()
        {
            MessageBox.Show("Hello World!!  CategorieItems Id");
        }
        #endregion
        #region Catalog Y
        /*  public class Categorie
        {
            public int categoryId;
            public string name;
            public string image;

            public List<Categorie> getCategories()
            {
                List<Categorie> categories = new List<Categorie>();
                categories.Add(new Categorie()
                {
                    categoryId = 1,
                    name = "barcode-printer",
                    image = "/pic/barcode-printer/barcode-printer.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 2,
                    name = "BarcodeReader",
                    image = "/pic/BarcodeReader/datalogic-barcode-scanner4.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 3,
                    name = "CashDrawer",
                    image = "/pic/CashDrawer/cash-drawer6.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 4,
                    name = "POS",
                    image = "/pic/POS/POZONE-POS2.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 5,
                    name = "Programs",
                    image = "/pic/Programs/laundry-casheir-program.png"

                });



                categories.Add(new Categorie()
                {
                    categoryId = 6,
                    name = "barcode-printer",
                    image = "/pic/barcode-printer/barcode-printer.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 7,
                    name = "BarcodeReader",
                    image = "/pic/BarcodeReader/datalogic-barcode-scanner4.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 8,
                    name = "CashDrawer",
                    image = "/pic/CashDrawer/cash-drawer6.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 9,
                    name = "POS",
                    image = "/pic/POS/POZONE-POS2.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 10,
                    name = "Programs",
                    image = "/pic/Programs/laundry-casheir-program.png"

                });

                return categories;
            }

        }
        */
        #endregion
        #region  Catalog Items Y
        /*
    public class CategorieItem
    {
        public int CategorieItemsId;
        public string title;
        public string subtitle;
        public string price;
        public string New;
        public string isOffer;
        public string image;

        public List<CategorieItem> getCategorieItems()
        {
            List<CategorieItem> CategorieItems = new List<CategorieItem>();
            //Collapsed
            //    Visible
            CategorieItems.Add(new CategorieItem()
            {
                CategorieItemsId = 1,
                title = "ThermalPrinters",
                subtitle = "EPSON-thermal-printer",
                price = "1050$",
                New = "Visible",
                isOffer = "Collapsed",
                image = "/pic/ThermalPrinters/EPSON-thermal-printer.png"
            });
            CategorieItems.Add(new CategorieItem()
            {
                CategorieItemsId = 2,
                title = "ThermalPrinters",
                subtitle = "EPSON-thermal-printer2",
                price = "350$",
                New = "Collapsed",
                isOffer = "Collapsed",
                image = "/pic/ThermalPrinters/EPSON-thermal-printer2.png"
            });
            CategorieItems.Add(new CategorieItem()
            {
                CategorieItemsId = 3,
                title = "ThermalPrinters",
                subtitle = "EPSON-thermal-printer3",
                price = "650$",
                New = "Visible",
                isOffer = "Visible",
                image = "/pic/ThermalPrinters/EPSON-thermal-printer3.png"
            });
            CategorieItems.Add(new CategorieItem()
            {
                CategorieItemsId = 4,
                title = "ThermalPrinters",
                subtitle = "EPSON-thermal-printer4",
                price = "120$",
                New = "Visible",
                isOffer = "Collapsed",
                image = "/pic/ThermalPrinters/EPSON-thermal-printer4.png"
            });
            CategorieItems.Add(new CategorieItem()
            {
                CategorieItemsId = 5,
                title = "ThermalPrinters",
                subtitle = "POZONE-PP610-USB",
                price = "240$",
                New = "Collapsed",
                isOffer = "Visible",
                image = "/pic/ThermalPrinters/POZONE-PP610-USB.png"
            });
            CategorieItems.Add(new CategorieItem()
            {
                CategorieItemsId = 6,
                title = "ThermalPrinters",
                subtitle = "POZONE-thermal-printer",
                price = "995$",
                New = "Collapsed",
                isOffer = "Collapsed",
                image = "/pic/ThermalPrinters/POZONE-thermal-printer.png"
            });
            CategorieItems.Add(new CategorieItem()
            {
                CategorieItemsId = 7,
                title = "ThermalPrinters",
                subtitle = "rio-thermal-printer",
                price = "335$",
                New = "Collapsed",
                isOffer = "Collapsed",
                image = "/pic/ThermalPrinters/rio-thermal-printer.png"
            });
            CategorieItems.Add(new CategorieItem()
            {
                CategorieItemsId = 8,
                title = "ThermalPrinters",
                subtitle = "Sewoo-thermal-printer",
                price = "799$",
                New = "Collapsed",
                isOffer = "Visible",
                image = "/pic/ThermalPrinters/Sewoo-thermal-printer.png"
            });
            CategorieItems.Add(new CategorieItem()
            {
                CategorieItemsId = 9,
                title = "ThermalPrinters",
                subtitle = "Zebra-ZD200D",
                price = "1250$",
                New = "Visible",
                isOffer = "Visible",
                image = "/pic/ThermalPrinters/Zebra-ZD200D.png"
            });

            return CategorieItems;
        }
    }
    */
        #endregion
        #region

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_categoryCode_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_categoryCode.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_categoryCode.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                tt_errorCode.Visibility = Visibility.Collapsed;
                tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_categoryCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_categoryCode.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_categoryCode.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                tt_errorCode.Visibility = Visibility.Collapsed;
                tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion
        #region Add - Update - Delete _ Clear
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {


            Category category = new Category
            {

                categoryCode = tb_categoryCode.Text,
                name = tb_name.Text,
                details = tb_details.Text,
                image = "",
                taxes = decimal.Parse(tb_taxes.Text),
                parentId = selectedItemId,
                // balance = 0,
                //balance      = decimal.Parse(tb_balance.Text),
                //branchId     = 1 ,
                // branchId = selectedBranchId,
                createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 2,
                updateUserId = 2,
                isActive = 1
            };

            await categoryModel.saveCategory(category);

            var Categories = await categoryModel.GetAllCategories();
            DG_Items.ItemsSource = Categories;

        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            //update
            Category category = new Category
            {
                categoryId = CategorieId,
                categoryCode = tb_categoryCode.Text,
                name = tb_name.Text,
                details = tb_details.Text,
                image = "",
                taxes = decimal.Parse(tb_taxes.Text),
                parentId = selectedItemId,
                createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 2,
                updateUserId = 2,
                isActive = 1
            };


            await categoryModel.saveCategory(category);

            var categories = await categoryModel.GetAllCategories();
            DG_Items.ItemsSource = categories;
        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            // p_errorName.Visibility = Visibility.Collapsed;
            // var bc = new BrushConverter();
            //  tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_name.Text = "";
            tb_taxes.Text = "";
            tb_details.Text = "";
            tb_categoryCode.Text = "";
            cb_parentCategorie.Text = "";
        }
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            //delete
            await categoryModel.deleteCategory(CategorieId);

            var categories = await categoryModel.GetAllCategories();
            DG_Items.ItemsSource = categories;

            //clear textBoxs
            // Btn_clear_Click(sender, e);
        }

        #endregion
        #region Toggle Button Y

        private async void Tgl_categoryIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (categories is null)
                await RefrishCategory();
            categoriesQuery = categories.Where(x => x.isActive == 1);
            RefrishCategoryCard(categoriesQuery);

        }
        private async void Tgl_categoryIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (categories is null)
                await RefrishCategory();
            categoriesQuery = categories.Where(x => x.isActive == 0);
            RefrishCategoryCard(categoriesQuery);
        }
        private async void Tgl_itemDatagridIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (items is null)
                await RefrishItem();
            itemsQuery = items.Where(x => x.isActive == 1);
            //RefrishItemDatagrid(itemsQuery);
            Txb_searchItemsDatagrid_TextChanged(null, null);



        }
        private async void Tgl_itemDatagridIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (items is null)
                await RefrishItem();
            itemsQuery = items.Where(x => x.isActive == 0);
            //RefrishItemDatagrid(itemsQuery);
            Txb_searchItemsDatagrid_TextChanged(null, null);
        }

        private async void Tgl_itemCardIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (items is null)
                await RefrishItem();
            Txb_searchItemsCard_TextChanged(null, null);

        }
        private async void Tgl_itemCardIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (items is null)
                await RefrishItem();
            itemsQuery = items.Where(x => x.isActive == 0);
            //RefrishItemCard(itemsQuery);
            Txb_searchItemsCard_TextChanged(null, null);
        }

        #endregion
        #region Switch Card/DataGrid Y

        private void Btn_ItemsInCards_Click(object sender, RoutedEventArgs e)
        {
            grid_itemsDatagrid.Visibility = Visibility.Collapsed;
            grid_ItemsCard.Visibility = Visibility.Visible;
            path_ItemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_ItemsInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
        }

        private void Btn_ItemsInGrid_Click(object sender, RoutedEventArgs e)
        {
            grid_ItemsCard.Visibility = Visibility.Collapsed;
            grid_itemsDatagrid.Visibility = Visibility.Visible;
            path_ItemsInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_ItemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
        }
        #endregion
        #region Search Y
        private async void Txb_searchItemsDatagrid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (items is null)
                await RefrishItem();
            byte b = 0;
            if (tgl_itemDatagridIsActive.IsChecked == true)
                b = 1;
            else b = 0; 
            itemsQuery = items.Where(x =>( x.code.Contains(txb_searchItemsDatagrid.Text) ||
            x.name.Contains(txb_searchItemsDatagrid.Text) ||
            x.details.Contains(txb_searchItemsDatagrid.Text)
            ) && x.isActive == b);
            RefrishItemDatagrid(itemsQuery);
            //DG_Items.ItemsSource = itemsQuery;
        }
        private async void Txb_searchItemsCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (items is null)
                await RefrishItem();
            byte b = 0;
            if (tgl_itemCardIsActive.IsChecked == true)
                b = 1;
            else b = 0;
            itemsQuery = items.Where(x => (x.code.Contains(txb_searchItemsCard.Text) ||
            x.name.Contains(txb_searchItemsCard.Text) ||
            x.details.Contains(txb_searchItemsCard.Text)
            ) && x.isActive == b);
            //RefrishItemCard(itemsQuery);
            pageIndex = 1;
            paginationSetting(itemsQuery);
        }
        #endregion
        #region Pagination Y
        public int pageIndex = 1;
        private void Tb_pageNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            byte b = 0;
            if (tgl_itemCardIsActive.IsChecked == true)
                b = 1;
            else b = 0;
            itemsQuery = items.Where(x => x.isActive == b);

            if (tb_pageNumberSearch.Text.Equals(""))
            {
                pageIndex = 1;
            }
            else  if(((itemsQuery.Count() - 1) / 9) + 1 < int.Parse(tb_pageNumberSearch.Text))
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
        void    pageNumberActive( Button btn , int indexContent)
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
        async void paginationSetting(IEnumerable<Item> _items= null)
        {
            if (_items is null)
            {
                if (items is null)
                {
                    await RefrishItem();
                    _items = items;
                }
                else
                    _items = items;
            }

            byte b = 0;
            if (tgl_itemCardIsActive.IsChecked == true)
                b = 1;
            else b = 0;
            _items = _items.Where(x => x.isActive == b);
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

            itemsQuery = _items.Skip((pageIndex - 1 )* 9).Take(9);
            RefrishItemCard(itemsQuery);
            //RefrishItemCard(items.Skip(pageIndex - 1 * 9).Take(9));
        }
         
         
        private void Btn_firstPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex =1;
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
            byte b = 0;
            if (tgl_itemCardIsActive.IsChecked == true)
                b = 1;
            else b = 0;
            itemsQuery = items.Where(x => x.isActive == b);
            pageIndex = ((itemsQuery.Count() - 1) / 9) + 1;
            paginationSetting();
        }
        #endregion

       
    }
}

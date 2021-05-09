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
using System.Threading;
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
        //public int _categorieId;
        Category categoryModel = new Category();
        Category category = new Category();
        int? categoryParentId = 0;
        IEnumerable<Category> categories;
        IEnumerable<Category> categoriesQuery;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        int? parentCategorieSelctedValue;
        public byte tglCategoryState;
        public string txtCategorySearch;

        public uc_categorie()
        {
            InitializeComponent();
        }
        private async void fillCategories()
        {
            if (categories is null)
                await RefrishCategories();
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
            fillCategories();

        }
        private void Cb_parentCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_parentCategorie.SelectedValue != null)
            {
                parentCategorieSelctedValue = int.Parse(cb_parentCategorie.SelectedValue.ToString());
            }

        }
      
       
      
     
        #region

       
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
                p_errorCode.Visibility = Visibility.Collapsed;
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
            decimal tax;
            if (string.IsNullOrEmpty(tb_taxes.Text))
                tax = 0;
            else tax = decimal.Parse(tb_taxes.Text);

            Category category = new Category
            {

                categoryCode = tb_categoryCode.Text,
                name = tb_name.Text,
                details = tb_details.Text,
                image = "/pic/no-image-icon-125x125.png",
                taxes = tax,
                parentId = parentCategorieSelctedValue,
                //createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                //updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 2,
                updateUserId = 2,
                isActive = 1
            };

            await categoryModel.saveCategory(category);

            //var Categories = await categoryModel.GetAllCategories();
            //dg_categories.ItemsSource = Categories;
            await RefrishCategories();
            Txb_searchcategories_TextChanged(null, null);
        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            //update
            decimal tax;
            if (string.IsNullOrEmpty(tb_taxes.Text))
                tax = 0;
            else tax = decimal.Parse(tb_taxes.Text);

            //Category category = new Category
            //{
            //category.categoryId = _categorieId;
            category.categoryCode = tb_categoryCode.Text;
            category.name = tb_name.Text;
            category.details = tb_details.Text;
            category.image = "/pic/no-image-icon-125x125.png";
            category.taxes = tax;
            category.parentId = parentCategorieSelctedValue;
            //createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
            //updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
            //createUserId = 2,
            category.updateUserId = 4;
            //isActive = 1
            //};


            await categoryModel.saveCategory(category);

            //var categories = await categoryModel.GetAllCategories();
            //dg_categories.ItemsSource = categories;
            await RefrishCategories();
            Txb_searchcategories_TextChanged(null, null);
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
            await categoryModel.deleteCategory(category.categoryId, MainWindow.userID);

            //var categories = await categoryModel.GetAllCategories();
            //dg_categories.ItemsSource = categories;

            //clear textBoxs
            // Btn_clear_Click(sender, e);
            Btn_clear_Click(null, null);
            await RefrishCategories();
            Txb_searchcategories_TextChanged(null, null);

        }

        #endregion

      
        #region Categor and Item

        #region Refrish Y
        async Task<IEnumerable<Category>> RefrishCategories()
        {
            categories = await categoryModel.GetAllCategories();
            return categories;
        }

       
        void RefrishCategoriesDatagrid(IEnumerable<Category> _categories)
        {
            dg_categories.ItemsSource = _categories;
        }
        
        void RefrishCategoriesCard(IEnumerable<Category> _categories)
        {
            //catigoriesAndItemsView.gridCatigorieItems = grid_itemCard;
            //catigoriesAndItemsView.FN_refrishCatalogItem(_items.ToList(), MainWindow.lang, "sale");

            catigoriesAndItemsView.gridCatigories = grid_categorieContainerCard;
            catigoriesAndItemsView.FN_refrishCatalogCard(_categories.ToList(),5);
        }
        #endregion
        #region Get Id By Click  Y
        private void dg_categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorParentCategorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");


            if (dg_categories.SelectedIndex != -1)
            {
                category = dg_categories.SelectedItem as Category;
                this.DataContext = category;
                cb_parentCategorie.SelectedValue = category.parentId;
            }
            //if (category != null)
            //{
            //    if (category.categoryId != 0)
            //    {
            //        _categorieId = category.categoryId;
            //    }
            //}

            categoryParentId = category.categoryId;
            Txb_searchcategories_TextChanged(null, null);
        }
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
            //_categorieId = categoryId;
             category = categories.ToList().Find(c => c.categoryId == categoryId);
            this.DataContext = category;
            cb_parentCategorie.SelectedValue = category.parentId;

            if (categories.Where(x => (x.categoryCode.Contains(txtCategorySearch) ||
             x.name.Contains(txtCategorySearch) ||
             x.details.Contains(txtCategorySearch)
             ) && x.isActive == tglCategoryState && x.parentId == category.categoryId).Count() != 0)
            categoryParentId = category.categoryId;


            Txb_searchcategories_TextChanged(null, null);
        }
        //public void testChangeCategorieItemsIdEvent()
        //{
        //    MessageBox.Show("Hello World!!  CategorieItems Id");
        //}
        #endregion
        #region Toggle Button Y
        
        private  void Tgl_categoryIsActive_Checked(object sender, RoutedEventArgs e)
        {
            //if (categories is null)
            //    await RefrishCategories();
            tglCategoryState = 1;
            //tgl_categoryCardIsActive.IsChecked =
            //    tgl_categoryDatagridIsActive.IsChecked = true;
            Txb_searchcategories_TextChanged(null, null);


        }
        private  void Tgl_categorIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            //if (categories is null)
            //    await RefrishCategories();
            //categoriesQuery = categories.Where(x => x.isActive == 0);
            tglCategoryState = 0;
            //tgl_categoryCardIsActive.IsChecked =
            //    tgl_categoryDatagridIsActive.IsChecked = false;
            Txb_searchcategories_TextChanged(null, null);
        }
        #endregion
        #region Switch Card/DataGrid Y

        private void Btn_categoriesInCards_Click(object sender, RoutedEventArgs e)
        {
            grid_categoriesDatagrid.Visibility = Visibility.Collapsed;
            grid_categoryCards.Visibility = Visibility.Visible;
            path_categoriesInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_categoriesInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

            tgl_categoryIsActive.IsChecked =  (tglCategoryState == 1)? true:false;
            Txb_searchcategories_TextChanged(null, null);

        }

        private void Btn_categoriesInGrid_Click(object sender, RoutedEventArgs e)
        {
            grid_categoryCards.Visibility = Visibility.Collapsed;
            grid_categoriesDatagrid.Visibility = Visibility.Visible;
            path_categoriesInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_categoriesInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

            tgl_categoryIsActive.IsChecked = (tglCategoryState == 1) ? true : false;
            Txb_searchcategories_TextChanged(null, null);
        }
        #endregion
        #region Search Y
        private async void Txb_searchcategories_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (categories is null)
                await RefrishCategories();
            txtCategorySearch = txb_searchcategories.Text;
            //categoriesQuery = new List<Category>();
            /*
            if(categories.Where(x => (x.categoryCode.Contains(txtCategorySearch) ||
            x.name.Contains(txtCategorySearch) ||
            x.details.Contains(txtCategorySearch)
            ) && x.isActive == tglCategoryState && x.parentId == categoryParentId).Count() == 0)
            {
                categoriesQuery = categories.Where(x => (x.categoryCode.Contains(txtCategorySearch) ||
            x.name.Contains(txtCategorySearch) ||
            x.details.Contains(txtCategorySearch)
            ) && x.isActive == tglCategoryState && x.parentId == categoryParentId);
            }
            else
            {
                categoriesQuery = categories.Where(x => (x.categoryCode.Contains(txtCategorySearch) ||
            x.name.Contains(txtCategorySearch) ||
            x.details.Contains(txtCategorySearch)
            ) && x.isActive == tglCategoryState && x.parentId == categoryParentId);
            }
            */
            categoriesQuery = categories.Where(x => (x.categoryCode.Contains(txtCategorySearch) ||
            x.name.Contains(txtCategorySearch) ||
            x.details.Contains(txtCategorySearch)
            ) && x.isActive == tglCategoryState && x.parentId == categoryParentId);
            txt_Count.Text = categoriesQuery.Count().ToString();
            RefrishCategoriesDatagrid(categoriesQuery);
            paginationSetting(categoriesQuery);
        }
        /*
        private async void Txb_searchcategoriesDatagrid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (categories is null)
                await RefrishCategories();
            
            categoriesQuery = categories.Where(x => (x.categoryCode.Contains(txb_searchcategoriesDatagrid.Text) ||
            x.name.Contains(txb_searchcategoriesDatagrid.Text) ||
            x.details.Contains(txb_searchcategoriesDatagrid.Text)
            ) && x.isActive == tglCategoryState);
            RefrishCategoriesDatagrid(categoriesQuery);
        }
        private async void Txb_searchcategoriesCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (categories is null)
                await RefrishCategories();
            
            categoriesQuery = categories.Where(x => (x.categoryCode.Contains(txb_searchcategoriesCard.Text) ||
            x.name.Contains(txb_searchcategoriesCard.Text) ||
            x.details.Contains(txb_searchcategoriesCard.Text)
            ) && x.isActive == tglCategoryState);
            pageIndex = 1;
            paginationSetting(categoriesQuery);

        }
        */
        #endregion
        #region Pagination Y
        public int pageIndex = 1;
        private void Tb_pageNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            categoriesQuery = categories.Where(x => x.isActive ==tglCategoryState);

            if (tb_pageNumberSearch.Text.Equals(""))
            {
                pageIndex = 1;
            }
            else if (((categoriesQuery.Count() - 1) / 20) + 1 < int.Parse(tb_pageNumberSearch.Text))
            {
                pageIndex = ((categoriesQuery.Count() - 1) / 20) + 1;
            }
            else
            {
                pageIndex = int.Parse(tb_pageNumberSearch.Text);
            }
            paginationSetting();
        }
        void pageNumberActive(Button btn, int indexContent)
        {
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            btn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Content = indexContent.ToString();
        }
        void pageNumberDisActive(Button btn, int indexContent)
        {
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#DFDFDF"));
            btn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#686868"));
            btn.Content = indexContent.ToString();

        }
        async void paginationSetting(IEnumerable<Category> _categories = null)
        {
            if (_categories is null)
            {
                if (categories is null)
                {
                    await RefrishCategories();
                    _categories = categories;
                }
                else
                    _categories = categories;
            }

            
            _categories = _categories.Where(x => x.isActive == tglCategoryState);
            if (2 >= ((_categories.Count() - 1) / 20))
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
                if (0 >= ((_categories.Count() - 1) / 20))
                {
                    btn_activePage.IsEnabled = false;
                    btn_nextPage.IsEnabled = false;
                } 
                else if (1 >= ((_categories.Count() - 1) / 20))
                {
                    btn_activePage.IsEnabled = true;
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
            else if (pageIndex == ((_categories.Count() - 1) / 20))
            {
                btn_lastPage.IsEnabled = false;
                btn_firstPage.IsEnabled = true;

                pageNumberDisActive(btn_prevPage, pageIndex - 1);
                pageNumberActive(btn_activePage, pageIndex);
                pageNumberDisActive(btn_nextPage, pageIndex + 1);

            }
            ///// last
            else if ((pageIndex - 1) >= ((_categories.Count() - 1) / 20))
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

            categoriesQuery = _categories.Skip((pageIndex - 1) * 20).Take(20);
            RefrishCategoriesCard(categoriesQuery);
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
             
            categoriesQuery = categories.Where(x => x.isActive ==tglCategoryState);
            pageIndex = ((categoriesQuery.Count() - 1) / 20) + 1;
            paginationSetting();
        }
        #endregion
        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });
        }
        void FN_ExportToExcel()
        {

            var QueryExcel = categoriesQuery.AsEnumerable().Select(x => new
            {
                Code = x.categoryCode,
                Name = x.name,
                Details = x.details,
                parentId = x.parentId,
                Taxes = x.taxes,

            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trCodeHint");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trNameHint");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trDetailsHint");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trParentCategorieHint");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trTaxesHint");


            ExportToExcel.Export(DTForExcel);

        }
        #endregion
        #endregion
        #region categoryPathControl Y

        void generateTrack(List<Category> listCategory)
        {
           
            int count = 0;
            //TestLestCategory[0] = TestLestCategory[0];
            foreach (var item in listCategory)
            {
                Button b = new Button();
                b.Content = " > " + item.name + " ";
                b.Padding = new Thickness(0);
                b.Margin = new Thickness(0);
                b.Background =null;
                b.BorderThickness = new Thickness(0);
                if (count + 1 == listCategory.Count)
                    b.FontFamily = Application.Current.Resources["Font-cairo-bold"] as FontFamily;
                else b.FontFamily = Application.Current.Resources["Font-cairo-light"] as FontFamily;
                b.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6e6e6e")); 
                //b.FontWeight = FontWeights.Bold;
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

        private void getCategoryIdFromPath(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            //if (sender != null)
                MessageBox.Show("Name: " + b.Name + " \\Tag: " + b.Tag + "");


            //categoryParentId = "ParentID"
            
        }

        private void Btn_getAllCategory_Click(object sender, RoutedEventArgs e)
        {
            categoryParentId = 0;
            Txb_searchcategories_TextChanged(null, null);


            List<Category> TestLestCategory = new List<Category>();
            TestLestCategory.Add(new Category()
            {
                categoryId = 23,
                parentId = 0,
                //name = "Electronics"
                name = "إلكترونيات"
            });
            TestLestCategory.Add(new Category()
            {
                categoryId = 28,
                parentId = 23,
                //name = "Programs"
                name = "برامج"
            });
            TestLestCategory.Add(new Category()
            {
                categoryId = 56,
                parentId = 28,
                //name = "Pos"
                name = "نقاط مبيعات"
            });
            generateTrack(TestLestCategory);
        }

        #endregion
    }
}

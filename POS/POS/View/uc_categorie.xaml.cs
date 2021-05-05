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
        IEnumerable<Category> categories;
        IEnumerable<Category> categoriesQuery;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        int selectedItemId = 0;
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
            //  selectedItemId = [cb_parentCategorie.SelectedIndex];


        }
        private void dg_categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorParentCategorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            Category category = new Category();

            if (dg_categories.SelectedIndex != -1)
            {
                category = dg_categories.SelectedItem as Category;
                this.DataContext = category;
            }
            if (category != null)
            {
                if (category.categoryId != 0)
                {
                    CategorieId = category.categoryId;

                    //cb_parentCategorie.ItemsSource = categories.ToList();
                    //cb_parentCategorie.SelectedValuePath = "categoryId";
                    //cb_parentCategorie.DisplayMemberPath = "name";
                    cb_parentCategorie.SelectedItem = category.categoryId;

                    int countCenter = 0;
                    foreach (Category item in cb_parentCategorie.Items)
                    {
                        if (item.parentId == category.categoryId)
                        {
                            cb_parentCategorie.SelectedIndex = countCenter;
                            break;
                        }
                        countCenter++;
                    }

                }


            }
        }
       
      
     
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
            dg_categories.ItemsSource = Categories;

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
            dg_categories.ItemsSource = categories;
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
            dg_categories.ItemsSource = categories;

            //clear textBoxs
            // Btn_clear_Click(sender, e);
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
        #region Toggle Button Y
     
        private async void Tgl_categoryDatagridIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (categories is null)
                await RefrishCategories();
            categoriesQuery = categories.Where(x => x.isActive == 1);
            Txb_searchcategoriesDatagrid_TextChanged(null, null);



        }
        private async void Tgl_categoryDatagridIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (categories is null)
                await RefrishCategories();
            categoriesQuery = categories.Where(x => x.isActive == 0);
            Txb_searchcategoriesDatagrid_TextChanged(null, null);
        }
        private async void Tgl_categoryCardIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (categories is null)
                await RefrishCategories();
            Txb_searchcategoriesCard_TextChanged(null, null);

        }
        private async void Tgl_categoryCardIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (categories is null)
                await RefrishCategories();
            categoriesQuery = categories.Where(x => x.isActive == 0);
            Txb_searchcategoriesCard_TextChanged(null, null);
        }
        #endregion
        #region Switch Card/DataGrid Y

        private void Btn_categoriesInCards_Click(object sender, RoutedEventArgs e)
        {
            grid_categoriesDatagrid.Visibility = Visibility.Collapsed;
            grid_categoryCards.Visibility = Visibility.Visible;
            path_categoriesInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_categoriesInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
        }

        private void Btn_categoriesInGrid_Click(object sender, RoutedEventArgs e)
        {
            grid_categoryCards.Visibility = Visibility.Collapsed;
            grid_categoriesDatagrid.Visibility = Visibility.Visible;
            path_categoriesInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_categoriesInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
        }
        #endregion
        #region Search Y
        private async void Txb_searchcategoriesDatagrid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (categories is null)
                await RefrishCategories();
            byte b = 0;
            if (tgl_categoryDatagridIsActive.IsChecked == true)
                b = 1;
            else b = 0;
            categoriesQuery = categories.Where(x => (x.categoryCode.Contains(txb_searchcategoriesDatagrid.Text) ||
            x.name.Contains(txb_searchcategoriesDatagrid.Text) ||
            x.details.Contains(txb_searchcategoriesDatagrid.Text)
            ) && x.isActive == b);
            RefrishCategoriesDatagrid(categoriesQuery);
        }
        private async void Txb_searchcategoriesCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (categories is null)
                await RefrishCategories();
            byte b = 0;
            if (tgl_categoryCardIsActive.IsChecked == true)
                b = 1;
            else b = 0;
            categoriesQuery = categories.Where(x => (x.categoryCode.Contains(txb_searchcategoriesCard.Text) ||
            x.name.Contains(txb_searchcategoriesCard.Text) ||
            x.details.Contains(txb_searchcategoriesCard.Text)
            ) && x.isActive == b);
            pageIndex = 1;
            paginationSetting(categoriesQuery);
        }
        #endregion
        #region Pagination Y
        public int pageIndex = 1;
        private void Tb_pageNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            byte b = 0;
            if (tgl_categoryCardIsActive.IsChecked == true)
                b = 1;
            else b = 0;
            categoriesQuery = categories.Where(x => x.isActive == b);

            if (tb_pageNumberSearch.Text.Equals(""))
            {
                pageIndex = 1;
            }
            else if (((categoriesQuery.Count() - 1) / 15) + 1 < int.Parse(tb_pageNumberSearch.Text))
            {
                pageIndex = ((categoriesQuery.Count() - 1) / 15) + 1;
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

            byte b = 0;
            if (tgl_categoryCardIsActive.IsChecked == true)
                b = 1;
            else b = 0;
            _categories = _categories.Where(x => x.isActive == b);
            if (2 >= ((_categories.Count() - 1) / 15))
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
                if (0 >= ((_categories.Count() - 1) / 15))
                {
                    btn_activePage.IsEnabled = false;
                }
                if (1 >= ((_categories.Count() - 1) / 15))
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
            else if (pageIndex == ((_categories.Count() - 1) / 15))
            {
                btn_lastPage.IsEnabled = false;
                btn_firstPage.IsEnabled = true;

                pageNumberDisActive(btn_prevPage, pageIndex - 1);
                pageNumberActive(btn_activePage, pageIndex);
                pageNumberDisActive(btn_nextPage, pageIndex + 1);

            }
            ///// last
            else if ((pageIndex - 1) >= ((_categories.Count() - 1) / 15))
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

            categoriesQuery = _categories.Skip((pageIndex - 1) * 15).Take(15);
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
            byte b = 0;
            if (tgl_categoryCardIsActive.IsChecked == true)
                b = 1;
            else b = 0;
            categoriesQuery = categories.Where(x => x.isActive == b);
            pageIndex = ((categoriesQuery.Count() - 1) / 15) + 1;
            paginationSetting();
        }
        #endregion
        #endregion

    }
}

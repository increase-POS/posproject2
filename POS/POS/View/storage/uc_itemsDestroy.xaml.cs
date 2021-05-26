using POS.Classes;
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

namespace POS.View.storage
{
    /// <summary>
    /// Interaction logic for uc_itemsDestroy.xaml
    /// </summary>
    public partial class uc_itemsDestroy : UserControl
    {
        private static uc_itemsDestroy _instance;
        public static uc_itemsDestroy Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_itemsDestroy();
                return _instance;
            }
        }
        public uc_itemsDestroy()
        {
            InitializeComponent();
        }
        Category categoryModel = new Category();
        Category category = new Category();
        IEnumerable<Category> categories;
        IEnumerable<Category> categoriesQuery;
        int? categoryParentId = 0;
        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;
        IEnumerable<Item> itemsQuery;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // for pagination
            btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            catigoriesAndItemsView.ucItemsDestroy = this;


            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucItemsDestroy.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucItemsDestroy.FlowDirection = FlowDirection.RightToLeft;
            }
           
            translate();

           
        }

        private void translate()
        {


        }





        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

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
            if (category.categoryId == 0)
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



            if (dg_items.SelectedIndex != -1)
            {
                item = dg_items.SelectedItem as Item;
                this.DataContext = item;



            }
            if (item != null)
            {

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


            item = items.ToList().Find(c => c.itemId == itemId);
            if (item != null)
            {
                this.DataContext = item;


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

            Txb_searchitems_TextChanged(null, null);

        }

        private void Btn_itemsInGrid_Click(object sender, RoutedEventArgs e)
        {
            grid_itemCards.Visibility = Visibility.Collapsed;
            grid_itemsDatagrid.Visibility = Visibility.Visible;
            path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

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
            pageIndex = 1;

            #region
            itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
            x.name.ToLower().Contains(txtItemSearch) ||
            x.details.ToLower().Contains(txtItemSearch)
            ) && x.isActive == tglItemState);
            txt_count.Text = itemsQuery.Count().ToString();
            RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
            #endregion
            RefrishItemsDatagrid(itemsQuery);

        }

        #endregion
        #region Pagination Y
        Pagination pagination = new Pagination();
        Button[] btns;
        public int pageIndex = 1;

        private void Tb_pageNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

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
        }

        private void Btn_firstPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            #region
            itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
            x.name.ToLower().Contains(txtItemSearch) ||
            x.details.ToLower().Contains(txtItemSearch)
            ) && x.isActive == tglItemState);
            txt_count.Text = itemsQuery.Count().ToString();
            RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_prevPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_prevPage.Content.ToString());
            #region
            itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
            x.name.ToLower().Contains(txtItemSearch) ||
            x.details.ToLower().Contains(txtItemSearch)
            ) && x.isActive == tglItemState);
            txt_count.Text = itemsQuery.Count().ToString();
            RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_activePage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_activePage.Content.ToString());
            #region
            itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
            x.name.ToLower().Contains(txtItemSearch) ||
            x.details.ToLower().Contains(txtItemSearch)
            ) && x.isActive == tglItemState);
            txt_count.Text = itemsQuery.Count().ToString();
            RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_nextPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_nextPage.Content.ToString());
            #region
            itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
            x.name.ToLower().Contains(txtItemSearch) ||
            x.details.ToLower().Contains(txtItemSearch)
            ) && x.isActive == tglItemState);
            txt_count.Text = itemsQuery.Count().ToString();
            RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_lastPage_Click(object sender, RoutedEventArgs e)
        {
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
        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void Btn_destroy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

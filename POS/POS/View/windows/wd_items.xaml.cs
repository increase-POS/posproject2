using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using POS.Classes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_items.xaml
    /// </summary>
    public partial class wd_items : Window
    {
        public wd_items()
        {
            InitializeComponent();
        }
        /// <summary>
        /// item is select
        /// </summary>
        /// 
        public string CardType { get; set; }
        public int selectedItem { get; set; }
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


        List<int> categoryIds = new List<int>();
        List<string> categoryNames = new List<string>();
        List<Category> categories;
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        int? categoryParentId = 0;
        public string txtItemSearch;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();



        public bool isActive;
        /// <summary>
        /// Selcted Items if selectedItems Have Items At the beginning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // for pagination onTop Always
            btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            //CreateGridCardContainer();
            catigoriesAndItemsView.wdItems = this;


            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucItems.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucItems.FlowDirection = FlowDirection.RightToLeft;
            }
            await RefrishItems();
            await RefrishCategories();
            RefrishCategoriesCard();
            Txb_searchitems_TextChanged(null, null);
        }
        private void translate()
        {

            


        }
        
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            this.Close();
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
                cd[i].Width = new GridLength(85, GridUnitType.Pixel);
                grid_categoryCards.ColumnDefinitions.Add(cd[i]);
            }
            #endregion
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
            grid_itemContainerCard.Children.Clear();
            catigoriesAndItemsView.gridCatigorieItems = grid_itemContainerCard;
            catigoriesAndItemsView.FN_refrishCatalogItem(_items.ToList(), "en", CardType);
        }
        #endregion
        #region Get Id By Click  Y
        private void dg_items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           

            if (dg_items.SelectedIndex != -1)
            {
                item = dg_items.SelectedItem as Item;
                selectedItem = item.itemId;
                isActive = true;
                this.Close();

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
            selectedItem = itemId;
            isActive = true;
            this.Close();
        }

        #endregion
        #region Grid Definition
        /*
        ColumnDefinition[] c;
        RowDefinition[] r;
        Grid gridItemContainerCard = new Grid();
        int[] count;
        void CreateGridCardContainer()
        {
            gridItemContainerCard.Name = "grid_itemContainerCard";
            gridItemContainerCard.Background = null;
            Grid.SetColumnSpan(gridItemContainerCard, 2);
            count = CatigoriesAndItemsView.itemsRowColumnCount(1, 3);
            c = new ColumnDefinition[count[1]];
            for (int i = 0; i < count[1]; i++)
            {
                //ColumnDefinition c1 = new ColumnDefinition();
                c[i] = new ColumnDefinition();
                c[i].Width = new GridLength(1, GridUnitType.Star);
                gridItemContainerCard.ColumnDefinitions.Add(c[i]);
            }
            r = new RowDefinition[count[0]];
            for (int i = 0; i < count[0]; i++)
            {
                r[i] = new RowDefinition();
                r[i].Height = new GridLength(1, GridUnitType.Star);
                gridItemContainerCard.RowDefinitions.Add(r[i]);
            }


            grid_itemContainerCard.Children.Clear();
            grid_itemContainerCard.Children.Add(gridItemContainerCard);
        }
        */
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
            //txt_count.Text = itemsQuery.Count().ToString();
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
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
            //txt_count.Text = itemsQuery.Count().ToString();
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
            //txt_count.Text = itemsQuery.Count().ToString();
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
            //txt_count.Text = itemsQuery.Count().ToString();
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
            //txt_count.Text = itemsQuery.Count().ToString();
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
            //txt_count.Text = itemsQuery.Count().ToString();
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
            //txt_count.Text = itemsQuery.Count().ToString();
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

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }
    }
}

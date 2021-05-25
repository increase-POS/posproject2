using Microsoft.Win32;
using netoaster;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_categorie.xaml
    /// </summary>
    public partial class uc_categorie : UserControl
    {
        //public int _categorieId;
        //public int categoryPathId = 0;
        Category categoryModel = new Category();
        Category category = new Category();
        int? categoryParentId = 0;
        IEnumerable<Category> categories;
        IEnumerable<Category> categoriesQuery;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
       

        int parentCategorieSelctedValue = 0;
        public byte tglCategoryState;
        public string txtCategorySearch;

        OpenFileDialog openFileDialog = new OpenFileDialog();

        ImageBrush brush = new ImageBrush();

        BrushConverter bc = new BrushConverter();

        string img_fileName = "pic/no-image-icon-125x125.png";

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

            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_code.Content = MainWindow.resourcemanager.GetString("trCode");
            tt_details.Content = MainWindow.resourcemanager.GetString("trDetails");
            tt_parentCategory.Content = MainWindow.resourcemanager.GetString("trParentCategory");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_taxes.Content = MainWindow.resourcemanager.GetString("trTax");
            tt_grid.Content = MainWindow.resourcemanager.GetString("trViewGrid");
            tt_items.Content = MainWindow.resourcemanager.GetString("trViewItems");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

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

            Keyboard.Focus(tb_categoryCode);

            fillCategories();

            btns = new Button[]  { btn_firstPage,btn_prevPage ,btn_activePage,btn_nextPage,btn_lastPage };

            //this.Dispatcher.Invoke(() =>
            //{
            //    Txb_searchcategories_TextChanged(null, null);
            //});

        }
        private void Cb_parentCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_parentCategorie.SelectedValue != null)
                parentCategorieSelctedValue = int.Parse(cb_parentCategorie.SelectedValue.ToString());
            else
                parentCategorieSelctedValue = 0;

        }
      
        #region

       
        private void Tb_categoryCode_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_categoryCode, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
        }

        private void Tb_categoryCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_categoryCode, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");

        }

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion
        #region Add - Update - Delete _ Clear
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            category.categoryId = 0;
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty code
            SectionData.validateEmptyTextBox(tb_categoryCode, p_errorName, tt_errorName, "trEmptyCodeToolTip");
            decimal tax;
            if (string.IsNullOrEmpty(tb_taxes.Text))
                tax = 0;
            else tax = decimal.Parse(tb_taxes.Text);

            if ((!tb_name.Text.Equals("")) && (!tb_categoryCode.Text.Equals("")))
            {
                category.categoryCode = tb_categoryCode.Text;
                category.name = tb_name.Text;
                category.details = tb_details.Text;
                category.taxes = tax;
                category.parentId = parentCategorieSelctedValue;
                category.createUserId = MainWindow.userID;
                category.updateUserId = MainWindow.userID;
                category.isActive = 1;

                string s = await categoryModel.saveCategory(category);

                if (!s.Equals("0"))  //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null);  
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                int categoryId = int.Parse(s);
                await categoryModel.uploadImage(img_fileName, Md5Encription.MD5Hash("Inc-m" + categoryId.ToString()), categoryId);

                await RefrishCategories();
                Txb_searchcategories_TextChanged(null, null);
            }

          
        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty code
            SectionData.validateEmptyTextBox(tb_categoryCode, p_errorName, tt_errorName, "trEmptyCodeToolTip");
            decimal tax;
            if (string.IsNullOrEmpty(tb_taxes.Text))
                tax = 0;
            else tax = decimal.Parse(tb_taxes.Text);

            if ((!tb_name.Text.Equals("")) && (!tb_categoryCode.Text.Equals("")))
            {
                category.categoryCode = tb_categoryCode.Text;
                category.name = tb_name.Text;
                category.details = tb_details.Text;
                category.taxes = tax;
                category.parentId = parentCategorieSelctedValue;
                category.updateUserId = MainWindow.userID ;

                string s = await categoryModel.saveCategory(category);

                if (!s.Equals("0")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate")); 
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                int categoryId = int.Parse(s);
                await categoryModel.uploadImage(img_fileName, Md5Encription.MD5Hash("Inc-m" + categoryId.ToString()), categoryId);

                await RefrishCategories();
                Txb_searchcategories_TextChanged(null, null);
            }

        
        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_name.Clear();
            tb_taxes.Clear();
            tb_details.Clear();
            tb_categoryCode.Clear();
            cb_parentCategorie.SelectedIndex = -1;
            //clear img
            Uri resourceUri = new Uri("pic/no-image-icon-125x125.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            img_category.Background = brush;

            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;

            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if (category.categoryId != 0)
            {
                if ((!category.canDelete) && (category.isActive == 0))
                    activate();
                else
                {
                    string popupContent = "";
                    if (category.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                    if ((!category.canDelete) && (category.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                    bool b = await categoryModel.deleteCategory(category.categoryId, MainWindow.userID.Value, category.canDelete);

                    if (b) //SectionData.popUpResponse("", popupContent);
                Toaster.ShowWarning(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                    else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }

                await RefrishCategories();
                Txb_searchcategories_TextChanged(null, null);
            }
            //clear textBoxs
            Btn_clear_Click(sender, e);

        }

        private async void activate()
        {//activate
            category.isActive = 1;

            string s = await categoryModel.saveCategory(category);

            if (!s.Equals("0")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

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
        int datagridSelectedItemId;
        private async void dg_categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_categories.SelectedItem as Category == null || dg_categories.SelectedIndex == -1)
                return;
            if (datagridSelectedItemId == (dg_categories.SelectedItem as Category).categoryId)
                    return;
           
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorParentCategorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_categories.SelectedIndex != -1)
            {
                category = dg_categories.SelectedItem as Category;
                datagridSelectedItemId = (dg_categories.SelectedItem as Category).categoryId;
                this.DataContext = category;
                cb_parentCategorie.SelectedValue = category.parentId;

                //await Img.getImg(category.image , "category");
                getImg();

                #region delete
                if (category.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else
                {
                    if (category.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                    else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
                }
                #endregion 
            }
            if (categories.Where(x => (x.categoryCode.Contains(txtCategorySearch) ||
                                    x.name.Contains(txtCategorySearch) ||
                                    x.details.Contains(txtCategorySearch)
                                    ) && x.isActive == tglCategoryState && x.parentId == category.categoryId).Count() != 0)
            {
                categoryParentId = category.categoryId;
                Txb_searchcategories_TextChanged(null, null);
            }
            //grid_categoryControlPath.Children.Clear();
            generateTrack(category.categoryId);

        }

        public async void ChangeCategorieIdEvent(int categoryId)
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
            {
                categoryParentId = category.categoryId;
                Txb_searchcategories_TextChanged(null, null);
            }

            generateTrack(category.categoryId);

            //await Img.getImg(category.image , "category");
            getImg();

            #region delete
            if (category.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

            else
            {
                if (category.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
            }
            #endregion
        }

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
        {//search
            if (categories is null)
                await RefrishCategories();
            txtCategorySearch = txb_searchcategories.Text.ToLower();
            
            categoriesQuery = categories.Where(x => (x.categoryCode.ToLower().Contains(txtCategorySearch) ||
            x.name.ToLower().Contains(txtCategorySearch) ||
            x.details.ToLower().Contains(txtCategorySearch)
            ) && x.isActive == tglCategoryState && x.parentId == categoryParentId);
            txt_Count.Text = categoriesQuery.Count().ToString();

            
            RefrishCategoriesDatagrid(categoriesQuery);

            RefrishCategoriesCard(pagination.refrishPagination(categoriesQuery , pageIndex, btns));
        }
        #endregion
        #region Pagination Y

        public int pageIndex = 1;
        Pagination pagination = new Pagination();
        Button[] btns;
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

            #region
            categoriesQuery = categories.Where(x => (x.categoryCode.ToLower().Contains(txtCategorySearch) ||
             x.name.ToLower().Contains(txtCategorySearch) ||
             x.details.ToLower().Contains(txtCategorySearch)
             ) && x.isActive == tglCategoryState && x.parentId == categoryParentId);
            txt_Count.Text = categoriesQuery.Count().ToString();
            RefrishCategoriesCard(pagination.refrishPagination(categoriesQuery, pageIndex, btns));
            #endregion
        }


        private void Btn_firstPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            #region
            categoriesQuery = categories.Where(x => (x.categoryCode.ToLower().Contains(txtCategorySearch) ||
             x.name.ToLower().Contains(txtCategorySearch) ||
             x.details.ToLower().Contains(txtCategorySearch)
             ) && x.isActive == tglCategoryState && x.parentId == categoryParentId);
            txt_Count.Text = categoriesQuery.Count().ToString();
            RefrishCategoriesCard(pagination.refrishPagination(categoriesQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_prevPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_prevPage.Content.ToString());
            #region
            categoriesQuery = categories.Where(x => (x.categoryCode.ToLower().Contains(txtCategorySearch) ||
             x.name.ToLower().Contains(txtCategorySearch) ||
             x.details.ToLower().Contains(txtCategorySearch)
             ) && x.isActive == tglCategoryState && x.parentId == categoryParentId);
            txt_Count.Text = categoriesQuery.Count().ToString();
            RefrishCategoriesCard(pagination.refrishPagination(categoriesQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_activePage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_activePage.Content.ToString());
            #region
            categoriesQuery = categories.Where(x => (x.categoryCode.ToLower().Contains(txtCategorySearch) ||
             x.name.ToLower().Contains(txtCategorySearch) ||
             x.details.ToLower().Contains(txtCategorySearch)
             ) && x.isActive == tglCategoryState && x.parentId == categoryParentId);
            txt_Count.Text = categoriesQuery.Count().ToString();
            RefrishCategoriesCard(pagination.refrishPagination(categoriesQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_nextPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_nextPage.Content.ToString());
            #region
            categoriesQuery = categories.Where(x => (x.categoryCode.ToLower().Contains(txtCategorySearch) ||
             x.name.ToLower().Contains(txtCategorySearch) ||
             x.details.ToLower().Contains(txtCategorySearch)
             ) && x.isActive == tglCategoryState && x.parentId == categoryParentId);
            txt_Count.Text = categoriesQuery.Count().ToString();
            RefrishCategoriesCard(pagination.refrishPagination(categoriesQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_lastPage_Click(object sender, RoutedEventArgs e)
        {
            categoriesQuery = categories.Where(x => x.isActive ==tglCategoryState);
            pageIndex = ((categoriesQuery.Count() - 1) / 20) + 1;
            #region
            categoriesQuery = categories.Where(x => (x.categoryCode.ToLower().Contains(txtCategorySearch) ||
             x.name.ToLower().Contains(txtCategorySearch) ||
             x.details.ToLower().Contains(txtCategorySearch)
             ) && x.isActive == tglCategoryState && x.parentId == categoryParentId);
            txt_Count.Text = categoriesQuery.Count().ToString();
            RefrishCategoriesCard(pagination.refrishPagination(categoriesQuery, pageIndex, btns));
            #endregion
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
                    //if (count + 1 == categoriesPath.Count())
                    //    b.FontFamily = Application.Current.Resources["Font-cairo-bold"] as FontFamily;
                    //else
                    b.FontFamily = Application.Current.Resources["Font-cairo-light"] as FontFamily;
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
            
            /*
            List<Button> listBtn = new List<Button>();


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
                    //if (count + 1 == categoriesPath.Count())
                    //    b.FontFamily = Application.Current.Resources["Font-cairo-bold"] as FontFamily;
                    //else
                    b.FontFamily = Application.Current.Resources["Font-cairo-light"] as FontFamily;
                    b.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6e6e6e"));
                    //b.FontWeight = FontWeights.Bold;
                    b.FontSize = 14;
                    Grid.SetColumn(b, count);
                    b.DataContext = item;
                    b.Name = "category" + item.categoryId;
                    b.Tag = item.categoryId;
                    b.Click += new RoutedEventHandler(getCategoryIdFromPath);
                    count++;
                    listBtn.Add(b);
                }
            }
            grid_categoryControlPath.Children.Clear();
            foreach (var item in listBtn)
            {
                grid_categoryControlPath.Children.Add(item);
            }
          */


            
        }
        private void getCategoryIdFromPath(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            
            if (!string.IsNullOrEmpty(b.Tag.ToString()))
            generateTrack(int.Parse( b.Tag.ToString() ));

            if (categories.Where(x => (x.categoryCode.Contains(txtCategorySearch) ||
             x.name.Contains(txtCategorySearch) ||
             x.details.Contains(txtCategorySearch)
             ) && x.isActive == tglCategoryState && x.parentId == int.Parse(b.Tag.ToString()) ).Count() != 0)
            {
                categoryParentId = int.Parse(b.Tag.ToString());
                Txb_searchcategories_TextChanged(null, null);

            }
            datagridSelectedItemId = 0;
        }

        private void Btn_getAllCategory_Click(object sender, RoutedEventArgs e)
        {
            categoryParentId = 0;
            Txb_searchcategories_TextChanged(null, null);
            grid_categoryControlPath.Children.Clear();

          
        }

        #endregion

        #endregion

        private void Img_calegorieImg_Click(object sender, RoutedEventArgs e)
        {//select image
            openFileDialog.Filter = "Images|*.png;*.jpg;*.bmp;*.jpeg;*.jfif";
            if (openFileDialog.ShowDialog() == true)
            {
                brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                img_fileName = openFileDialog.FileName;
                img_category.Background = brush;
            }
        }

        private async void getImg()
        {
            try
            {
                if (string.IsNullOrEmpty(category.image))
                {
                    Uri resourceUri = new Uri("pic/no-image-icon-125x125.png", UriKind.Relative);
                    StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                    brush.ImageSource = temp;

                    img_category.Background = brush;

                }
                else
                {
                    byte[] imageBuffer = await categoryModel.downloadImage(category.image); // read this as BLOB from your DB

                    var bitmapImage = new BitmapImage();
                   
                    using (var memoryStream = new MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    img_category.Background = new ImageBrush(bitmapImage);
                 
            }
            }
            catch { }
        }

        private  void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            RefrishCategories();
            
        }
    }
}

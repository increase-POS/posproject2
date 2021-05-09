using client_app.Classes;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static POS.View.uc_categorie;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_payInvoice.xaml
    /// </summary>
    public partial class uc_payInvoice : UserControl
    {
        ObservableCollection<BillDetails> billDetails =     new ObservableCollection<BillDetails>();

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
        int? parentCategorieSelctedValue;
        public byte tglCategoryState;
        public byte tglItemState;
        public string txtItemSearch;
        //tglItemState
        public uc_payInvoice()
        {
            InitializeComponent();

            #region bill
            List<Bill> items = new List<Bill>();
            items.Add(new Bill() { Id = 336554944, Total = 255 });
            items.Add(new Bill() { Id = 336545142, Total = 260 });
            items.Add(new Bill() { Id = 336556165, Total = 1200 });
            items.Add(new Bill() { Id = 336551515, Total = 150 });
            items.Add(new Bill() { Id = 336555162, Total = 840 });
            items.Add(new Bill() { Id = 336558897, Total = 325 });
            dg_draft.ItemsSource = items;
            dg_invoice.ItemsSource = items;
            billDetails = LoadCollectionData();
            dg_billDetails.ItemsSource = billDetails;
            #endregion
            

        }
       

        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////
            txt_invoiceHeader.Text = MainWindow.resourcemanager.GetString("trInvoice");
            txt_returnInvoice.Text = MainWindow.resourcemanager.GetString("trReturnInvoice");
            txt_invoiceToggle.Text = MainWindow.resourcemanager.GetString("trInvoice");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_InvoicenName, MainWindow.resourcemanager.GetString("trInvoiceHint"));

            txt_draft.Text = MainWindow.resourcemanager.GetString("trDraft");
            txt_draftToggle.Text = MainWindow.resourcemanager.GetString("trDraft");
            txt_invoice.Text = MainWindow.resourcemanager.GetString("trInvoice");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trBranchHint"));
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trAmount");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trPrice");
            dg_billDetails.Columns[5].Header = MainWindow.resourcemanager.GetString("trTotal");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_tax.Text = MainWindow.resourcemanager.GetString("trTax");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal:");
            btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdfBtn");
            btn_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            btn_cash.Content = MainWindow.resourcemanager.GetString("trCash");
            btn_creditcard.Content = MainWindow.resourcemanager.GetString("trCreditCard");
            dg_invoice.Columns[0].Header = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            dg_invoice.Columns[1].Header = MainWindow.resourcemanager.GetString("trTotal");

            dg_draft.Columns[0].Header = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            dg_draft.Columns[1].Header = MainWindow.resourcemanager.GetString("trTotal");

            ////////////////////////////////----vendor----/////////////////////////////////

            txt_vendorHeader.Text = MainWindow.resourcemanager.GetString("trVendor");
            txt_vendor.Text = MainWindow.resourcemanager.GetString("trVendor");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendor, MainWindow.resourcemanager.GetString("trVendorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_paid, MainWindow.resourcemanager.GetString("trPaidHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_deserved, MainWindow.resourcemanager.GetString("trDeservedHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            txt_vendorIvoiceDetails.Text = MainWindow.resourcemanager.GetString("trVendorInvoiceDetails");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_invoiceNumber, MainWindow.resourcemanager.GetString("trInvoiceNumberHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_invoiceDate, MainWindow.resourcemanager.GetString("trInvoiceDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucPayInvoice.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucPayInvoice.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

            catigoriesAndItemsView.ucPayInvoice = this;
            #region Generate catigorie
            //catigoriesAndItemsView.gridCatigories = Grid_categorie;
            //Categorie categorie = new Categorie();
            //catigoriesAndItemsView.FN_refrishCatalogCard(categorie.getCategories());
            #endregion
            #region Generate catigorieItems
            //catigoriesAndItemsView.gridCatigorieItems = Grid_CategorieItem;
            //CategorieItem CategorieItem = new CategorieItem();
            //catigoriesAndItemsView.FN_refrishCatalogItem(CategorieItem.getCategorieItems(),MainWindow.lang,"");
            #endregion

            #region Style Date
            dp_desrvedDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_desrvedDate.Template.FindName("PART_TextBox", dp_desrvedDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_desrvedDate.Background;
                    textBox1.BorderThickness = dp_desrvedDate.BorderThickness;
                }
            };

            #endregion
            grid_vendor.Visibility = Visibility.Collapsed;



        }
        #region bill



        public class Bill
        {
            public int Id { get; set; }
            public int Total { get; set; }

        }
        public class BillDetails
        {
            public int ID { get; set; }
            public string Product { get; set; }
            public int Count { get; set; }
            public int Price { get; set; }
            public int Total { get; set; }
        }
        private ObservableCollection<BillDetails> LoadCollectionData()
        {
            ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
            billDetails.Add(new BillDetails()
            {
                ID = 101,
                Product = "Watch",
                Count = 2,
                Price = 1200,
                Total = 2400
            });
            billDetails.Add(new BillDetails()
            {
                ID = 201,
                Product = "Cocacola",
                Count = 5,
                Price = 200,
                Total = 1000
            });
            billDetails.Add(new BillDetails()
            {
                ID = 244,
                Product = "CarToy",
                Count = 1,
                Price = 300,
                Total = 300
            });
            billDetails.Add(new BillDetails()
            {
                ID = 244,
                Product = "CarToy",
                Count = 1,
                Price = 300,
                Total = 300
            });
            billDetails.Add(new BillDetails()
            {
                ID = 244,
                Product = "CarToy",
                Count = 1,
                Price = 300,
                Total = 300
            });
            billDetails.Add(new BillDetails()
            {
                ID = 244,
                Product = "CarToy",
                Count = 1,
                Price = 300,
                Total = 300
            });


            return billDetails;
        }
        #endregion
        #region Tab
        private void btn_payInvoice_Click(object sender, RoutedEventArgs e)
        {
            grid_vendor.Visibility   = Visibility.Collapsed;
            grid_payinvoice.Visibility = Visibility.Visible;
            brd_vendorTab.BorderBrush =  (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_payInvoiceTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_vendor_Click(object sender, RoutedEventArgs e)
        {
            grid_payinvoice.Visibility = Visibility.Collapsed;
            grid_vendor.Visibility = Visibility.Visible;
            brd_payInvoiceTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_vendorTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }


        #endregion
        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
                    ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
                    data.Remove(row);
                }

        }
        #endregion
        private void Tgl_draftDropDown_Checked(object sender, RoutedEventArgs e)
        {
            dg_draft.Visibility = Visibility.Visible;
        }
        private void Tgl_draftDropDown_Unchecked(object sender, RoutedEventArgs e)
        {
            dg_draft.Visibility = Visibility.Collapsed;
        }
        private void Tgl_ReturnInvoiceDropDown_Checked(object sender, RoutedEventArgs e)
        {
            grid_returnInvoice.Visibility = Visibility.Visible;
        }
        private void Tgl_ReturnInvoiceDropDown_Unchecked(object sender, RoutedEventArgs e)
        {
            grid_returnInvoice.Visibility = Visibility.Collapsed;
        }
       

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

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

        /// <summary>
        /// Item
        /// </summary>
        /// <returns></returns>

        async Task<IEnumerable<Item>> RefrishItems()
        {
            items = await itemModel.GetAllItems();
            return items;
        }

        void RefrishItemsDatagrid(IEnumerable<Item> _items)
        {
            dg_items.ItemsSource = _items;
        }

        void RefrishItemsCard(IEnumerable<Item> _items)
        {

            catigoriesAndItemsView.gridCatigorieItems = grid_itemContainerCard;
            catigoriesAndItemsView.FN_refrishCatalogItem(_items.ToList(),"en", "purchase");
        }
        #endregion
        #region Get Id By Click  Y
        private void dg_items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorParentCategorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            */

            if (dg_items.SelectedIndex != -1)
            {
                item = dg_items.SelectedItem as Item;
                //this.DataContext = category;
            }


            

            
        }
        public void ChangeCategoryIdEvent(int categoryId)
        {
            //////////////
            ///
            /*
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorParentCategorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            */
            //////////////
            //_categorieId = categoryId;
            category = categories.ToList().Find(c => c.categoryId == categoryId);
            //this.DataContext = category;
            //cb_parentCategorie.SelectedValue = category.parentId;

            if (categories.Where(x => (x.categoryCode.Contains(txtItemSearch) ||
             x.name.Contains(txtItemSearch) ||
             x.details.Contains(txtItemSearch)
             ) && x.isActive == tglItemState && x.parentId == category.categoryId).Count() != 0)
                categoryParentId = category.categoryId;

            MessageBox.Show("add event Here");
            //Txb_searchcategories_TextChanged(null, null);
        }

        public void ChangeItemIdEvent(int categoryId)
        {
            //////////////
            ///
            /*
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorParentCategorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            */
            //////////////

            //_categorieId = categoryId;
            //category = categories.ToList().Find(c => c.categoryId == categoryId);
            //this.DataContext = category;
            //cb_parentCategorie.SelectedValue = category.parentId;

            //if (categories.Where(x => (x.categoryCode.Contains(txtItemSearch) ||
            // x.name.Contains(txtItemSearch) ||
            // x.details.Contains(txtItemSearch)
            // ) && x.isActive == tglItemState && x.parentId == category.categoryId).Count() != 0)
            //    categoryParentId = category.categoryId;


            //Txb_searchcategories_TextChanged(null, null);
            MessageBox.Show("I'm in ChangeItemIdEvent");
        }
        //public void testChangeCategorieItemsIdEvent()
        //{
        //    MessageBox.Show("Hello World!!  CategorieItems Id");
        //}
        #endregion
        #region Toggle Button Y
            /// <summary>
            /// Category
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void Tgl_categoryIsActive_Checked(object sender, RoutedEventArgs e)
        {
            tglCategoryState = 1;
            Txb_searchcategories_TextChanged(null, null);


        }
        private void Tgl_categorIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            tglCategoryState = 0;
            Txb_searchcategories_TextChanged(null, null);
        }
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
        private async void Txb_searchitems_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (items is null)
                await RefrishItems();
            txtItemSearch = txb_searchitems.Text.ToLower();
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
            itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
            x.name.ToLower().Contains(txtItemSearch) ||
            x.details.ToLower().Contains(txtItemSearch)
            ) && x.isActive == tglItemState );
            //txt_Count.Text = categoriesQuery.Count().ToString();
            RefrishItemsDatagrid(itemsQuery);
            paginationSetting(itemsQuery);
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

            itemsQuery = items.Where(x => x.isActive == tglItemState);

            if (tb_pageNumberSearch.Text.Equals(""))
            {
                pageIndex = 1;
            }
            else if (((itemsQuery.Count() - 1) / 20) + 1 < int.Parse(tb_pageNumberSearch.Text))
            {
                pageIndex = ((itemsQuery.Count() - 1) / 20) + 1;
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
            if (2 >= ((_items.Count() - 1) / 20))
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
                if (0 >= ((_items.Count() - 1) / 20))
                {
                    btn_activePage.IsEnabled = false;
                    btn_nextPage.IsEnabled = false;
                }
                else if (1 >= ((_items.Count() - 1) / 20))
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
            else if (pageIndex == ((_items.Count() - 1) / 20))
            {
                btn_lastPage.IsEnabled = false;
                btn_firstPage.IsEnabled = true;

                pageNumberDisActive(btn_prevPage, pageIndex - 1);
                pageNumberActive(btn_activePage, pageIndex);
                pageNumberDisActive(btn_nextPage, pageIndex + 1);

            }
            ///// last
            else if ((pageIndex - 1) >= ((_items.Count() - 1) / 20))
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

            itemsQuery = _items.Skip((pageIndex - 1) * 20).Take(20);
            RefrishItemsCard(itemsQuery);
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
            pageIndex = ((itemsQuery.Count() - 1) / 20) + 1;
            paginationSetting();
        }
        #endregion
        /*
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
        */
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
                b.Background = null;
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
            Txb_searchitems_TextChanged(null, null);


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
        #endregion
    }
}

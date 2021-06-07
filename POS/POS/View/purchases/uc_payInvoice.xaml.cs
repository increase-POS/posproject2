﻿using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static POS.View.uc_categorie;
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.Globalization;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_payInvoice.xaml
    /// </summary>
    public partial class uc_payInvoice : UserControl
    {
        private static uc_payInvoice _instance;
        public static uc_payInvoice Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_payInvoice();
                return _instance;
            }
        }
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

            #endregion
            

        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        //Category categoryModel = new Category();
        //Category category = new Category();
        //IEnumerable<Category> categories;
        //IEnumerable<Category> categoriesQuery;
        //int? categoryParentId = 0;

        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;
        IEnumerable<Item> itemsQuery;

        Branch branchModel = new Branch();
        IEnumerable<Branch> branches;

        Agent agentModel = new Agent();
        IEnumerable<Agent> vendors;

        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;

        Invoice invoiceModel = new Invoice();
        Invoice invoice = new Invoice();

        List<ItemTransfer> invoiceItems;
        Bill bill;

        //to handle barcode characters
        static int _SelectedBranch = -1;

        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        int? parentCategorieSelctedValue;
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;

        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        List<char> _barcode = new List<char>(10);
        static private string _BarcodeStr = "";
        static private int _SequenceNum = 0;
        static private decimal _Sum = 0;
        static private int _OrginalCount;
        static private string _InvoiceType = "pd";

        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////
            //txt_invoiceHeader.Text = MainWindow.resourcemanager.GetString("trInvoice");
            //txt_invoice.Text = MainWindow.resourcemanager.GetString("trInvoice");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trBranchHint"));
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");
            dg_billDetails.Columns[5].Header = MainWindow.resourcemanager.GetString("trPrice");
            dg_billDetails.Columns[6].Header = MainWindow.resourcemanager.GetString("trTotal");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal");
            //btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            //btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdfBtn");
            //btn_printInvoice.Content = MainWindow.resourcemanager.GetString("trPrint");

            ////////////////////////////////----vendor----/////////////////////////////////

            txt_vendor.Text = MainWindow.resourcemanager.GetString("trVendor");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendor, MainWindow.resourcemanager.GetString("trVendorHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_paid, MainWindow.resourcemanager.GetString("trPaidHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_deserved, MainWindow.resourcemanager.GetString("trDeservedHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            txt_vendorIvoiceDetails.Text = MainWindow.resourcemanager.GetString("trVendorInvoiceDetails");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_invoiceNumber, MainWindow.resourcemanager.GetString("trInvoiceNumberHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_invoiceDate, MainWindow.resourcemanager.GetString("trInvoiceDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // for pagination
            //btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };

            var window = Window.GetWindow(this);
            window.KeyDown -= HandleKeyPress;
            window.KeyDown += HandleKeyPress;

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
            await RefrishItems();
            //await RefrishCategories();
            //RefrishCategoriesCard();
            //Txb_searchitems_TextChanged(null, null);
            configureDiscountType();
            await RefrishBranches();
            await RefrishVendors();
            await fillBarcodeList();

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
            //grid_vendor.Visibility = Visibility.Collapsed;
            //tb_sum.Text = _Sum.ToString();
            tb_barcode.Focus();
            #region datagridChange
            CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
            ((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
            #endregion


            SectionData.defaultDatePickerStyle(dp_desrvedDate);
            SectionData.defaultDatePickerStyle(dp_invoiceDate);
        }
        
        private void configureDiscountType()
        {
            var dislist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trValueDiscount"), Value = "1" },
            new { Text = MainWindow.resourcemanager.GetString("trPercentageDiscount"), Value = "2" },
             };

            cb_typeDiscount.DisplayMemberPath = "Text";
            cb_typeDiscount.SelectedValuePath = "Value";
            cb_typeDiscount.ItemsSource = dislist;
            cb_typeDiscount.SelectedIndex = 0;
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
            public int itemId { get; set; }
            public int itemUnitId { get; set; }
            public string Product { get; set; }
            public string Unit { get; set; }
            public int Count { get; set; }
            public decimal Price { get; set; }
            public decimal Total { get; set; }
        }

        #endregion
        #region Tab
       /*
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

        */
        #endregion
        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
                    int index = dg_billDetails.SelectedIndex;
                    // calculate new sum
                    _Sum -= row.Total;

                    // remove item from bill
                    billDetails.RemoveAt(index);

                    ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
                    data.Remove(row);
                  
                    // calculate new total
                    refreshTotalValue();
                }
            _SequenceNum = 0;
            _Sum = 0;
            for(int i = 0; i < billDetails.Count; i++)
            {
                _SequenceNum++;
                _Sum += billDetails[i].Total;
                billDetails[i].ID = _SequenceNum;
            }
            refrishBillDetails();

        }
        #endregion

        
        private void Btn_updateVendor_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;

             
            Window.GetWindow(this).Opacity = 0.2;
            wd_updateVendor w = new wd_updateVendor();
            //// pass agent id to update windows
            w.agent.agentId = 22;
             
            w.ShowDialog();


            Window.GetWindow(this).Opacity = 1;
        }
        #region Categor and Item
        #region Refrish Y
        /// <summary>
        /// Category
        /// </summary>
        /// <returns></returns>
        //async Task<IEnumerable<Category>> RefrishCategories()
        //{
        //    categories = await categoryModel.GetAllCategories();
        //    return categories;
        //}
        async Task RefrishVendors()
        {
            vendors = await agentModel.GetAgentsActive("v");
            cb_vendor.ItemsSource = vendors;
            cb_vendor.DisplayMemberPath = "name";
            cb_vendor.SelectedValuePath = "agentId";
        }
        async Task RefrishBranches()
        {
            branches = await branchModel.GetBranchesActive("all");
            cb_branch.ItemsSource = branches;
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
        }
        async Task RefrishItems()
        {
            items = await itemModel.GetAllItems();
        }
        async Task fillBarcodeList()
        {
            barcodesList = await itemUnitModel.getAllBarcodes();
        }

        //async void RefrishCategoriesCard()
        //{
        //    if (categories is null)
        //        await RefrishCategories();
        //    categoriesQuery = categories.Where(x => x.isActive == tglCategoryState && x.parentId == categoryParentId);
        //    catigoriesAndItemsView.gridCatigories = grid_categoryCards;
        //    catigoriesAndItemsView.FN_refrishCatalogCard(categoriesQuery.ToList(), -1);
        //}
        /// <summary>
        /// Item
        /// </summary>
        /// <returns></returns>



        //void RefrishItemsDatagrid(IEnumerable<Item> _items)
        //{
        //    dg_items.ItemsSource = _items;
        //}

        //void RefrishItemsCard(IEnumerable<Item> _items)
        //{

        //    catigoriesAndItemsView.gridCatigorieItems = grid_itemContainerCard;
        //    catigoriesAndItemsView.FN_refrishCatalogItem(_items.ToList(), "en", "purchase");
        //}



        #endregion
        #region Get Id By Click  Y

        public async void ChangeCategoryIdEvent(int categoryId)
        {
            //    category = categories.ToList().Find(c => c.categoryId == categoryId);

            //    if (categories.Where(x =>
            //    x.isActive == tglCategoryState && x.parentId == category.categoryId).Count() != 0)
            //    {
            //        categoryParentId = category.categoryId;
            //        RefrishCategoriesCard();
            //    }

            //    generateTrack(categoryId);
            //    await RefrishItems();
            //    Txb_searchitems_TextChanged(null, null);
        }


        public async void ChangeItemIdEvent(int itemId)
        {
            item = items.ToList().Find(c => c.itemId == itemId);

            //check if item exist in bill details
            int index = billDetails.IndexOf(billDetails.Where(p => p.itemId == itemId).FirstOrDefault());

            if (item != null && index == -1)
            {
                this.DataContext = item;

                // get item units
                itemUnits = await itemUnitModel.GetItemUnits(item.itemId);
                // search for default unit for purchase
                var defaultPurUnit = itemUnits.ToList().Find(c => c.defaultPurchase == 1);
                if (defaultPurUnit != null)
                {
                    // create new row in bill details data grid
                    addRowToBill(item.name, itemId, defaultPurUnit.mainUnit, defaultPurUnit.itemUnitId , 1,0,0);

                    refreshTotalValue();
                    refrishBillDetails();

                }
            }
        }
        
        #endregion
        //#region Toggle Button Y
        ///// <summary>
        ///// Category
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// 
        ///*
        //private void Tgl_categoryIsActive_Checked(object sender, RoutedEventArgs e)
        //{
        //    tglCategoryState = 1;
        //    RefrishCategoriesCard();



        //}
        //private void Tgl_categorIsActive_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    tglCategoryState = 0;
        //    RefrishCategoriesCard();
        //}
        //*/
        ///// <summary>
        ///// Item
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Tgl_itemIsActive_Checked(object sender, RoutedEventArgs e)
        //{
        //    //if (categories is null)
        //    //    await RefrishCategories();
        //    tglItemState = 1;
        //    //tgl_categoryCardIsActive.IsChecked =
        //    //    tgl_categoryDatagridIsActive.IsChecked = true;
        //    Txb_searchitems_TextChanged(null, null);


        //}
        //private void Tgl_itemIsActive_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    //if (categories is null)
        //    //    await RefrishCategories();
        //    //categoriesQuery = categories.Where(x => x.isActive == 0);
        //    tglItemState = 0;
        //    //tgl_categoryCardIsActive.IsChecked =
        //    //    tgl_categoryDatagridIsActive.IsChecked = false;
        //    Txb_searchitems_TextChanged(null, null);
        //}
        //#endregion
        //#region Switch Card/DataGrid Y

        //private void Btn_itemsInCards_Click(object sender, RoutedEventArgs e)
        //{
        //    grid_itemsDatagrid.Visibility = Visibility.Collapsed;
        //    grid_itemCards.Visibility = Visibility.Visible;
        //    path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        //    path_itemsInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

        //    Txb_searchitems_TextChanged(null, null);

        //}

        //private void Btn_itemsInGrid_Click(object sender, RoutedEventArgs e)
        //{
        //    grid_itemCards.Visibility = Visibility.Collapsed;
        //    grid_itemsDatagrid.Visibility = Visibility.Visible;
        //    path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        //    path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

        //    Txb_searchitems_TextChanged(null, null);
        //}
        //#endregion
        //#region Search Y



        ///// <summary>
        ///// Item
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void Txb_searchitems_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (items is null)
        //        await RefrishItems();
        //    txtItemSearch = txb_searchitems.Text.ToLower();
        //    pageIndex = 1;

        //    #region
        //    itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
        //    x.name.ToLower().Contains(txtItemSearch) ||
        //    x.details.ToLower().Contains(txtItemSearch)
        //    ) && x.isActive == tglItemState);
        //    txt_count.Text = itemsQuery.Count().ToString();
        //    RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
        //    #endregion
        //    RefrishItemsDatagrid(itemsQuery);

        //}

        //#endregion
        //#region Pagination Y
        //Pagination pagination = new Pagination();
        //Button[] btns;
        //public int pageIndex = 1;

        //private void Tb_pageNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //    itemsQuery = items.Where(x => x.isActive == tglItemState);

        //    if (tb_pageNumberSearch.Text.Equals(""))
        //    {
        //        pageIndex = 1;
        //    }
        //    else if (((itemsQuery.Count() - 1) / 9) + 1 < int.Parse(tb_pageNumberSearch.Text))
        //    {
        //        pageIndex = ((itemsQuery.Count() - 1) / 9) + 1;
        //    }
        //    else
        //    {
        //        pageIndex = int.Parse(tb_pageNumberSearch.Text);
        //    }

        //    #region
        //    itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
        //    x.name.ToLower().Contains(txtItemSearch) ||
        //    x.details.ToLower().Contains(txtItemSearch)
        //    ) && x.isActive == tglItemState);
        //    txt_count.Text = itemsQuery.Count().ToString();
        //    RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
        //    #endregion
        //}


        //private void Btn_firstPage_Click(object sender, RoutedEventArgs e)
        //{
        //    pageIndex = 1;
        //    #region
        //    itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
        //    x.name.ToLower().Contains(txtItemSearch) ||
        //    x.details.ToLower().Contains(txtItemSearch)
        //    ) && x.isActive == tglItemState);
        //    txt_count.Text = itemsQuery.Count().ToString();
        //    RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
        //    #endregion
        //}
        //private void Btn_prevPage_Click(object sender, RoutedEventArgs e)
        //{
        //    pageIndex = int.Parse(btn_prevPage.Content.ToString());
        //    #region
        //    itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
        //    x.name.ToLower().Contains(txtItemSearch) ||
        //    x.details.ToLower().Contains(txtItemSearch)
        //    ) && x.isActive == tglItemState);
        //    txt_count.Text = itemsQuery.Count().ToString();
        //    RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
        //    #endregion
        //}
        //private void Btn_activePage_Click(object sender, RoutedEventArgs e)
        //{
        //    pageIndex = int.Parse(btn_activePage.Content.ToString());
        //    #region
        //    itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
        //    x.name.ToLower().Contains(txtItemSearch) ||
        //    x.details.ToLower().Contains(txtItemSearch)
        //    ) && x.isActive == tglItemState);
        //    txt_count.Text = itemsQuery.Count().ToString();
        //    RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
        //    #endregion
        //}
        //private void Btn_nextPage_Click(object sender, RoutedEventArgs e)
        //{
        //    pageIndex = int.Parse(btn_nextPage.Content.ToString());
        //    #region
        //    itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
        //    x.name.ToLower().Contains(txtItemSearch) ||
        //    x.details.ToLower().Contains(txtItemSearch)
        //    ) && x.isActive == tglItemState);
        //    txt_count.Text = itemsQuery.Count().ToString();
        //    RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
        //    #endregion
        //}
        //private void Btn_lastPage_Click(object sender, RoutedEventArgs e)
        //{
        //    itemsQuery = items.Where(x => x.isActive == tglCategoryState);
        //    pageIndex = ((itemsQuery.Count() - 1) / 9) + 1;
        //    #region
        //    itemsQuery = items.Where(x => (x.code.ToLower().Contains(txtItemSearch) ||
        //    x.name.ToLower().Contains(txtItemSearch) ||
        //    x.details.ToLower().Contains(txtItemSearch)
        //    ) && x.isActive == tglItemState);
        //    txt_count.Text = itemsQuery.Count().ToString();
        //    RefrishItemsCard(pagination.refrishPagination(itemsQuery, pageIndex, btns));
        //    #endregion
        //}
        //#endregion
        //#region categoryPathControl Y

        //async void generateTrack(int categorypaPathId)
        //{
        //    grid_categoryControlPath.Children.Clear();
        //    IEnumerable<Category> categoriesPath = await
        //    categoryModel.GetCategoryTreeByID(categorypaPathId);

        //    int count = 0;
        //    foreach (var item in categoriesPath.Reverse())
        //    {
        //        if (categories.Where(x => x.parentId == item.categoryId).Count() != 0)
        //        {
        //            Button b = new Button();
        //            b.Content = " > " + item.name + " ";
        //            b.Padding = new Thickness(0);
        //            b.Margin = new Thickness(0);
        //            b.Background = null;
        //            b.BorderThickness = new Thickness(0);
        //            b.FontFamily = Application.Current.Resources["Font-cairo-light"] as FontFamily;
        //            b.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6e6e6e"));
        //            b.FontSize = 14;
        //            Grid.SetColumn(b, count);
        //            b.DataContext = item;
        //            b.Name = "category" + item.categoryId;
        //            b.Tag = item.categoryId;
        //            b.Click += new RoutedEventHandler(getCategoryIdFromPath);
        //            count++;
        //            grid_categoryControlPath.Children.Add(b);
        //        }
        //    }


        //}
        //private async void getCategoryIdFromPath(object sender, RoutedEventArgs e)
        //{
        //    Button b = (Button)sender;

        //    if (!string.IsNullOrEmpty(b.Tag.ToString()))
        //    {
        //        generateTrack(int.Parse(b.Tag.ToString()));
        //        categoryParentId = int.Parse(b.Tag.ToString());
        //        RefrishCategoriesCard();


        //        category.categoryId = int.Parse(b.Tag.ToString());

        //    }
        //    await RefrishItems();
        //    Txb_searchitems_TextChanged(null, null);

        //}
        //private async void Btn_getAllCategory_Click(object sender, RoutedEventArgs e)
        //{
        //    categoryParentId = 0;
        //    RefrishCategoriesCard();
        //    grid_categoryControlPath.Children.Clear();
        //    category.categoryId = 0;
        //    await RefrishItems();
        //    Txb_searchitems_TextChanged(null, null);
        //}

        //#endregion

        #endregion
        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region validation
        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;

            else
                e.Handled = true;
        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void validateInvoiceValues()
        {
            SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
            SectionData.validateEmptyComboBox(cb_vendor, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip");
            SectionData.validateEmptyTextBox(tb_invoiceNumber, p_errorInvoiceNumber, tt_errorInvoiceNumber, "trErrorEmptyInvNumToolTip");
            SectionData.validateEmptyDatePicker(dp_desrvedDate, p_errorDesrvedDate, tt_errorDesrvedDate,"trErrorEmptyDeservedDate");
        }

        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_invoiceNumber")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorInvoiceNumber, tt_errorInvoiceNumber, "trErrorEmptyInvNumToolTip");
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_branch")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
                if ((sender as ComboBox).Name == "cb_vendor")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip");
            }
            else
            {
                if ((sender as DatePicker).Name == "dp_desrvedDate")
                    SectionData.validateEmptyDatePicker((DatePicker) sender, p_errorDesrvedDate, tt_errorDesrvedDate, "trErrorEmptyDeservedDate");
            }
        }
        #endregion
        #region save invoice

        private async Task addInvoice(string invType)
        {
            if (invoice.invType == "p" && (invType == "pb" || invType =="pbd")) // invoice is purchase and will bebounce purchase  or purchase bounce draft bounce , save another invoice in db
            {
                invoice.invoiceMainId = invoice.invoiceId;
                invoice.invoiceId = 0;
            }

            invoice.invType = invType;

            if (!tb_discount.Text.Equals(""))
                invoice.discountValue = decimal.Parse(tb_discount.Text);

            if (cb_typeDiscount.SelectedIndex != -1)
                invoice.discountType = cb_typeDiscount.SelectedValue.ToString();

            invoice.total = _Sum;
            invoice.totalNet = decimal.Parse(tb_total.Text);

            if(cb_vendor.SelectedIndex != -1)
                invoice.agentId = (int)cb_vendor.SelectedValue;

            Branch store = new Branch();
            if (cb_vendor.SelectedIndex != -1)
                invoice.branchId = (int)cb_vendor.SelectedValue;

            //if(!tb_paid.Text.Equals(""))
            //    invoice.paid = decimal.Parse(tb_paid.Text);
            //if(!tb_deserved.Text.Equals(""))
            //    invoice.deserved = decimal.Parse(tb_deserved.Text);

            invoice.deservedDate = dp_desrvedDate.SelectedDate;
            invoice.vendorInvNum = tb_invoiceNumber.Text;
            invoice.vendorInvDate = dp_invoiceDate.SelectedDate;
            invoice.notes = tb_note.Text;
            invoice.createUserId = MainWindow.userID;
            invoice.updateUserId = MainWindow.userID;

            // build invoice NUM like 1021_PI_sequence
            if (invoice.invNumber == null)
            {
                store = branches.ToList().Find(b => b.branchId == invoice.branchId);
                string storeCode = store.code;
                string invoiceCode = "PI";
                int sequence = await invoiceModel.GetLastNumOfInv("PI");
                sequence++;

                string invoiceNum = storeCode + "_" + invoiceCode + "_" + sequence.ToString();
                invoice.invNumber = invoiceNum;
            }

            // save invoice in DB
            int invoiceId = int.Parse(await invoiceModel.saveInvoice(invoice));

            if (invoiceId != 0)
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            // add invoice details
            invoiceItems = new List<ItemTransfer>();
            ItemTransfer itemT;
            for (int i =0; i < billDetails.Count; i++)
            {
                itemT = new ItemTransfer();

                itemT.invoiceId = invoiceId;
                itemT.quantity = billDetails[i].Count;
                itemT.price = billDetails[i].Price;
                itemT.itemUnitId = billDetails[i].itemUnitId;
                itemT.createUserId = MainWindow.userID;

                invoiceItems.Add(itemT);
            }
            await invoiceModel.saveInvoiceItems(invoiceItems,invoiceId);
           
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            //check mandatory inputs
            validateInvoiceValues();

            if (cb_branch.SelectedIndex != -1 && cb_vendor.SelectedIndex != -1 && !tb_invoiceNumber.Equals("") && billDetails.Count > 0)
            {
                if (_InvoiceType == "pb")
                    await addInvoice("pb"); // bp means purchase bounce
                else//p  purchase invoice
                    await addInvoice("p");

                if(invoice.invoiceId == 0) clearInvoice();
            }
        }
        private async void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {
            //check mandatory inputs
            validateInvoiceValues();

           if (cb_branch.SelectedIndex != -1 && cb_vendor.SelectedIndex != -1 && !tb_invoiceNumber.Equals("") && billDetails.Count > 0)
           {
                if (_InvoiceType == "pb")
                    await addInvoice("pbd"); // bpd means purchase bounce draft
                else//pd draft purchase 
                    await addInvoice("pd");
                            
           }
           
            clearInvoice();
        }
        private void clearInvoice()
        {
            _Sum = 0;
            _SequenceNum = 0;
            _SelectedBranch = -1;
            _InvoiceType = "pd";
            invoice = new Invoice();
            cb_branch.SelectedIndex = -1;
            cb_vendor.SelectedIndex = -1;
            //tb_paid.Clear();
            //tb_deserved.Clear();
            dp_desrvedDate.Text="";
            txt_vendorIvoiceDetails.Text ="";
            tb_invoiceNumber.Clear();
            dp_invoiceDate.Text = "";
            tb_note.Clear();
            billDetails.Clear();
            tb_total.Text = "";
            tb_sum.Text = null;
            refrishBillDetails();
        }
        #endregion
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            Window.GetWindow(this).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            // purchase drafts and purchase bounce drafts
           // string[] typeArr = { "pd","pdbd" };
            w.invoiceType = "pd";  
 
            w.title = MainWindow.resourcemanager.GetString("trDrafts");

            if (w.ShowDialog() == true)
            {
                invoice = w.invoice;
                if (w.invoice != null)
                {
                    this.DataContext = invoice;

                    fillInvoiceInputs(invoice);
                   
                    //get invoice items
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);

                    // build invoice details grid
                    buildInvoiceDetails(invoiceItems);
                }
            }
          //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
          Window.GetWindow(this).Opacity =1;
        }
        private  void  fillInvoiceInputs(Invoice invoice)
        {
            _Sum = (decimal)invoice.total;

            cb_branch.SelectedValue = invoice.branchId;
            cb_vendor.SelectedValue = invoice.agentId;
            dp_desrvedDate.Text = invoice.deservedDate.ToString();
            tb_invoiceNumber.Text = invoice.vendorInvNum;
            dp_invoiceDate.Text = invoice.vendorInvDate.ToString();
            tb_total.Text = Math.Round((double)invoice.totalNet , 2).ToString();

            if (invoice.discountType == "1")
                cb_typeDiscount.SelectedIndex = 0;
            else if (invoice.discountType == "2")
                cb_typeDiscount.SelectedIndex = 1;
           
        }
        private async void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            
            w.title = MainWindow.resourcemanager.GetString("trPurchaseInvoices");
            // purchase invoices
            //string[] typeArr = { "p" };
            w.invoiceType = "p";
            if (w.ShowDialog() == true)
            { 
                if (w.invoice != null)
                {
                    _InvoiceType = "pb";
                    invoice = w.invoice;

                    this.DataContext = invoice;

                    fillInvoiceInputs(invoice);

                    //get invoice items
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);

                    // build invoice details grid
                    buildInvoiceDetails(invoiceItems);

                    inputEditable(_InvoiceType);
                }              
            }
            Window.GetWindow(this).Opacity = 1;
        }
        private void buildInvoiceDetails(List<ItemTransfer> invoiceItems)
        {
            // build invoice details grid
            _SequenceNum = 0;
            billDetails.Clear();
            foreach (ItemTransfer itemT in invoiceItems)
            {
                _SequenceNum++;
                decimal total = (decimal)(itemT.price * itemT.quantity);
                billDetails.Add(new BillDetails()
                {
                    ID = _SequenceNum,
                    Product = itemT.itemName,
                    itemId = (int)itemT.itemId,
                    Unit = itemT.itemUnitId.ToString(),
                    itemUnitId = (int) itemT.itemUnitId,
                    Count = (int)itemT.quantity,
                    Price = (decimal)itemT.price,
                    Total = total,
                });
            }

            tb_barcode.Focus();

            refrishBillDetails();
        }
        private void inputEditable(string invoiceType)
        {
            if (_InvoiceType == "pb") // return invoice
            {
                dg_billDetails.Columns[5].IsReadOnly = true; //make price read only
                dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                cb_vendor.IsReadOnly = true;
                dp_desrvedDate.IsEnabled = false;
                dp_invoiceDate.IsEnabled = false;
                tb_note.IsReadOnly = true;
            }
            else
            {
                dg_billDetails.Columns[5].IsReadOnly = false;
                dg_billDetails.Columns[3].IsReadOnly = false;
                cb_vendor.IsReadOnly = false;
                dp_desrvedDate.IsEnabled = true;
                dp_invoiceDate.IsEnabled = true;
                tb_note.IsReadOnly = false;

            }
        }
        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_uploadImage w = new wd_uploadImage();
            w.ShowDialog();
            Window.GetWindow(this).Opacity =1;
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            _SequenceNum = 0;
            billDetails.Clear();
            foreach (ItemTransfer itemT in invoiceItems)
            {
                _SequenceNum++;
                decimal total = (decimal)(itemT.price * itemT.quantity);
                billDetails.Add(new BillDetails()
                {
                    ID = _SequenceNum,
                    Product = itemT.itemName,
                    itemId = (int)itemT.itemId,
                    Unit = itemT.itemUnitId.ToString(),
                    Count = (int)itemT.quantity,
                    Price = (decimal)itemT.price,
                    Total = total,
                });
            }
            tb_barcode.Focus();

            refrishBillDetails();
        }

        private void Btn_pay_Click(object sender, RoutedEventArgs e)
        {
          //  btn_vendor_Click(null, null);
        }

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 1000 && cb_branch.SelectedIndex != -1 )
            {
                _SelectedBranch = (int)cb_branch.SelectedValue;
            }
            else 
            {
                cb_branch.SelectedValue = _SelectedBranch;
            }           
        }

        private  void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshTotalValue();
        }
        private  void tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            refreshTotalValue();
        }
        private void refreshTotalValue( )
        {
            decimal discountValue = 0;
            if (tb_discount.Text != "." && !tb_discount.Text.Equals(""))
                discountValue = decimal.Parse(tb_discount.Text);

            if (cb_typeDiscount.SelectedIndex != -1 && int.Parse(cb_typeDiscount.SelectedValue.ToString()) == 2) // discount type is rate
            {
                    discountValue = SectionData.calcPercentage(_Sum, discountValue);
            }

            decimal total = _Sum - discountValue;
            tb_sum.Text = _Sum.ToString();
            tb_total.Text = Math.Round( total,2).ToString();
        }
       //private void refreshTotalValue(decimal discountVal)
       // {
       //     decimal discountVal = 0;
       //     if (!tb_discount.Text.Equals(""))
       //     {
       //         if (tb_discount.Text.Equals("."))
       //             discountVal = 0;
       //         else
       //             discountVal = decimal.Parse(tb_discount.Text);
       //     }
       //     decimal total = _Sum - discountVal;
       //     tb_sum.Text = _Sum.ToString();
       //     tb_total.Text = total.ToString();
       // }
       
        #region billdetails
        /*
        List<ItemUnit> GetItemUnits(int itemId)
        {
            List<ItemUnit> itemUnits = new List<ItemUnit>();
            var ItemUnit1 = new ItemUnit { itemUnitId = 35 };
            var ItemUnit2 = new ItemUnit { itemUnitId = 63 };
            var ItemUnit3 = new ItemUnit { itemUnitId = 364 };
            itemUnits.Add(ItemUnit1);
            itemUnits.Add(ItemUnit2);
            itemUnits.Add(ItemUnit3);


            return itemUnits;

        }
        void GenerateComboBox(DataGrid dg)
        {
            var vm = GetItemUnits(1);
            var dataGridTemplateColumn = new DataGridTemplateColumn();
            var dataTemplate = new DataTemplate();
            var comboBox = new FrameworkElementFactory(typeof(ComboBox));
            //comboBox.SetValue(NameProperty, new Binding("cc" + dataGridTemplateColumn.Header));
            comboBox.SetValue(ComboBox.ItemsSourceProperty, vm);//Bind the ObservableCollection list
            comboBox.SetValue(ComboBox.SelectedIndexProperty, 1);
            comboBox.SetValue(ComboBox.DisplayMemberPathProperty, "itemUnitId");
            comboBox.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(ComboBox_SelectionChanged));

            dataTemplate.VisualTree = comboBox;
            dataGridTemplateColumn.CellTemplate = dataTemplate;
            dataGridTemplateColumn.Header = "Unit";
            dg.Columns.Add(dataGridTemplateColumn);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        */
        void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;

            tb_sum.Text = _Sum.ToString();
        }


        // read item from barcode
        private async void HandleKeyPress(object sender, KeyEventArgs e)
        {

            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 1000)
            {
                _barcode.Clear();
                _BarcodeStr = "";
            }

            string digit = "";
            // record keystroke & timestamp 
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                //digit pressed!
                digit = e.Key.ToString().Substring(1);
                // = "1" when D1 is pressed
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                digit = e.Key.ToString().Substring(6); // = "1" when NumPad1 is pressed
            }

            _barcode.Add((char)e.Key);
            _BarcodeStr += digit;
            _lastKeystroke = DateTime.Now;

            // process barcode
            if (e.Key.ToString() == "Return" && _barcode.Count > 0)
            {
                tb_barcode.Text = _BarcodeStr;
                _barcode.Clear();
                _BarcodeStr = "";

                // get item matches barcode
                if (barcodesList != null)
                {
                    ItemUnit unit1 = barcodesList.ToList().Find(c => c.barcode == tb_barcode.Text);

                    // get item matches the barcode
                    if (unit1 != null)
                    {
                        int itemId = (int)unit1.itemId;
                        if (unit1.itemId != 0)
                        {
                            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId).FirstOrDefault());
                            //item doesn't exist in bill
                            if (index == -1)
                            {
                                // get item units
                                itemUnits = await itemUnitModel.GetItemUnits(itemId);
                                //get item from list
                                item = items.ToList().Find(i => i.itemId == itemId);

                                int count = 1;
                                decimal price = 0; //?????
                                decimal total = count * price;
                                addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId,count, price ,total);                                                           
                            }
                            else // item exist prevoiusly in list
                            {
                                billDetails[index].Count++;
                                billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;

                                _Sum += billDetails[index].Price;

                            }
                            refreshTotalValue();
                            refrishBillDetails();
                        }
                    }
                    else
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorItemNotFoundToolTip"), animation: ToasterAnimation.FadeIn);
                    }
                }
                e.Handled = true;
                cb_branch.SelectedValue = _SelectedBranch;
            }
        }

        private  void addRowToBill(string itemName,int itemId,string unitName, int itemUnitId , int count, decimal price, decimal total)
        {            
            // increase sequence for each read
            _SequenceNum++;
               
            billDetails.Add(new BillDetails()
            {
                ID = _SequenceNum,
                Product = item.name,
                itemId = item.itemId,
                Unit = unitName,
                itemUnitId = itemUnitId,
                Count = 1,
                Price = price,
                Total = total,
            });
            _Sum += total;
        }
        #endregion billdetails


        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;
         
            if(dg_billDetails.SelectedIndex != -1)
                billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
        }


        private void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //MessageBox.Show("I'm Here in _CollectionChanged");

            //billDetails
            int count = 0;
            foreach (var item in billDetails)
            {
                if (dg_billDetails.Items.Count != 0)
                {
                    if (dg_billDetails.Items.Count == 1)
                    {

                        var comboBoxlist = FindControls.FindVisualChildren<ComboBox>(dg_billDetails).ToArray();
                        //comboBoxlist[0].SelectedValue = (int)item.itemUnitId;
                        for (int i = 0; i < comboBoxlist.Count(); i++)
                        {
                            if (comboBoxlist[i].Name.ToString() == "cbm_unitItemDetails")
                            {
                                MessageBox.Show("I'm Here");
                            }

                        }

                        //List<ComboBox> comboBoxlist = new List<ComboBox>();
                        //// Find all elements
                        //StaticClass.FindChildGroup<ComboBox>(dg_billDetails, "cbm_unitItemDetails", ref comboBoxlist);


                        //foreach (CheckBox c in checkBoxlist)
                        //{
                        //    if (c.IsChecked)
                        //    {
                        //        //do whatever you want
                        //    }
                        //}
                        //comboBoxlist[0].SelectedValue = (int)item.itemUnitId;

                        /*
                            (dg_billDetails.Items[0] as BillDetails).itemUnitId = (int)item.itemUnitId;
                     var allCells =    dg_billDetails.SelectedCells;
                        
                        foreach (var c in allCells)
                        {
                            MessageBox.Show("HelloWorld!");

                           //MessageBox.Show(c.Column)
                        }
                        //var cp = (ContentPresenter)cell.Content;
                        //var combo = (ComboBox)cp.ContentTemplate.FindName("cbm_unitItemDetails", cp);
                        //combo.SelectedValue = (int)item.itemUnitId;

                        //cbm_unitItemDetails.allcell
                        //cbm_unitItemDetails.se
                        */
                    }
                    else if (dg_billDetails.Items.Count != 1)
                    {
                        var cell = DataGridHelper.GetCell(dg_billDetails, count, 3);
                        if (cell != null)
                        {
                            var cp = (ContentPresenter)cell.Content;
                            var combo = (ComboBox)cp.ContentTemplate.FindName("cbm_unitItemDetails", cp);
                            //var combo = (combo)cell.Content;
                            combo.SelectedValue = (int)item.itemUnitId;
                            count++;
                        }
                    }

                }
            }

        }

        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
            var columnName = e.Column.Header.ToString();

            BillDetails row = e.Row.Item as BillDetails;
            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == row.itemUnitId).FirstOrDefault());

            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds < 100)
            {
                if (columnName == MainWindow.resourcemanager.GetString("trAmount"))
                    t.Text = billDetails[index].Count.ToString();
                else if (columnName == MainWindow.resourcemanager.GetString("trPrice"))
                    t.Text = billDetails[index].Price.ToString();
            }
            else
            {
                int oldCount = 0;
                long newCount = 0;
                decimal oldPrice = 0;
                decimal newPrice = 0;

                //"tb_amont"
                if (columnName == MainWindow.resourcemanager.GetString("trAmount"))
                    newCount = int.Parse(t.Text);
                else
                    newCount = row.Count;

                oldCount = row.Count;

                if (_InvoiceType == "pb")
                {
                    ItemTransfer item = invoiceItems.ToList().Find(i => i.itemUnitId == row.itemUnitId);
                    if (newCount > item.quantity)
                    {
                        // return old value 
                        t.Text = item.quantity.ToString();

                        newCount = (long)item.quantity;
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);

                    }
                }

                if (columnName == MainWindow.resourcemanager.GetString("trPrice"))
                    newPrice = decimal.Parse(t.Text);
                else
                    newPrice = row.Price;

                oldPrice = row.Price;

                // old total for changed item
                decimal total = oldPrice * oldCount;
                _Sum -= total;

                // new total for changed item
                total = newCount * newPrice;
                _Sum += total;

                //refresh total cell
                TextBlock tb = dg_billDetails.Columns[6].GetCellContent(dg_billDetails.Items[index]) as TextBlock;
                tb.Text = total.ToString();

                //  refresh sum and total text box
                refreshTotalValue();

                // update item in billdetails           
                billDetails[index].Count = (int)newCount;
                billDetails[index].Price = newPrice;
                billDetails[index].Total = total;
            }
        }

        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            string addpath = @"\Reports\InvPurReport .rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
            rep.ReportPath = reppath;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItemTransfer", invoiceItems));
           // rep.DataSources.Add(new ReportDataSource("DataSetItemTransfer", data));
            ReportParameter[] paramarr = new ReportParameter[13];
            //String.Format("h \\h m \\m", invoice.invTime)
            paramarr[0] = new ReportParameter("Title", "Purshase Invoice");
            paramarr[12] = new ReportParameter("lang", MainWindow.lang);
            paramarr[1] = new ReportParameter("invNumber", invoice.invNumber);
            paramarr[2] = new ReportParameter("invoiceId", invoice.invoiceId.ToString());
            paramarr[3] = new ReportParameter("invDate", invoice.invDate.ToString());
            paramarr[4] = new ReportParameter("invTime", invoice.invTime.ToString());
            paramarr[5] = new ReportParameter("vendorInvNum", invoice.vendorInvNum.ToString());
            paramarr[6] = new ReportParameter("total", invoice.total.ToString());
            paramarr[7] = new ReportParameter("discountValue", invoice.discountValue.ToString());
            paramarr[8] = new ReportParameter("totalNet", invoice.totalNet.ToString());
            paramarr[9] = new ReportParameter("paid", invoice.paid.ToString());
            paramarr[10] = new ReportParameter("deserved", invoice.deserved.ToString());
            paramarr[11] = new ReportParameter("deservedDate", invoice.deservedDate.ToString());

         

            rep.SetParameters(paramarr);

            rep.Refresh();

            saveFileDialog.Filter = "PDF|*.pdf;";

            if (saveFileDialog.ShowDialog() == true)
            {

                string filepath = saveFileDialog.FileName;
                LocalReportExtensions.ExportToPDF(rep, filepath);

            }
        }
    }

}

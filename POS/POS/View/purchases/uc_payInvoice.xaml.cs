using netoaster;
using POS.Classes;
using POS.View.windows;
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
using static POS.View.uc_categorie;

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
        Category categoryModel = new Category();
        Category category = new Category();
        IEnumerable<Category> categories;
        IEnumerable<Category> categoriesQuery;
        int? categoryParentId = 0;

        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;
        IEnumerable<Item> itemsQuery;
        IEnumerable<Item> invoiceItems;

        Branch branchModel = new Branch();
        IEnumerable<Branch> branches;

        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;

        Bill bill;

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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////
            txt_invoiceHeader.Text = MainWindow.resourcemanager.GetString("trInvoice");
            txt_invoice.Text = MainWindow.resourcemanager.GetString("trInvoice");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trBranchHint"));
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");
            dg_billDetails.Columns[5].Header = MainWindow.resourcemanager.GetString("trPrice");
            dg_billDetails.Columns[6].Header = MainWindow.resourcemanager.GetString("trTotal");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal:");
            btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdfBtn");
            btn_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            btn_cash.Content = MainWindow.resourcemanager.GetString("trCash");
            btn_creditcard.Content = MainWindow.resourcemanager.GetString("trCreditCard");

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
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // for pagination
            btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };

            var window = Window.GetWindow(this);
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
            await RefrishCategories();
            RefrishCategoriesCard();
            Txb_searchitems_TextChanged(null, null);
            configureDiscountType();
            await RefrishBranches();
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
            grid_vendor.Visibility = Visibility.Collapsed;
            tb_sum.Text = _Sum.ToString();
            tb_barcode.Focus();
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
            public int ItemId { get; set; }
            public string Product { get; set; }
            public int Count { get; set; }
            public decimal Price { get; set; }
            public decimal Total { get; set; }
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

                    // calculate new sum
                    _Sum -= row.Total;
                    //get index of item
                    int index = billDetails.IndexOf(billDetails.Where(p => p.ItemId == row.ItemId).FirstOrDefault());
                    // remove item from bill
                    billDetails.RemoveAt(index);

                    ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
                    data.Remove(row);
                    tb_sum.Text = _Sum.ToString();

                    // calculate new total
                    refrishTotalValue();
                }

        }
        #endregion

        
        private void Btn_updateVendor_Click(object sender, RoutedEventArgs e)
        {
            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;

            //if ((((this.Parent as Grid).Parent as Grid).Parent as UserControl) != null)
            //((((this.Parent as Grid).Parent as Grid).Parent as Grid).Parent as UserControl).Opacity = 0.2;
            wd_updateVendor w = new wd_updateVendor();
            //// pass agent id to update windows
            w.agent.agentId = 22;
            //w.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00178DD2"));
            w.ShowDialog();


            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
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
        async Task RefrishBranches()
        {
            branches = await branchModel.GetBranchesActive("all");
            cb_branch.ItemsSource = branches;
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
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
        void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;

            tb_sum.Text = _Sum.ToString();
        }
        async Task fillBarcodeList()
        {
            barcodesList = await itemUnitModel.getAllBarcodes();
        }
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
                            int index = billDetails.IndexOf(billDetails.Where(p => p.ItemId == itemId).FirstOrDefault());
                            //item doesn't exist in bill
                            if (index == -1)
                            {
                                _SequenceNum++;
                                item = items.ToList().Find(i => i.itemId == itemId);
                                int count = 1;
                                decimal price = 1000; //?????
                                decimal total = count * price;
                                billDetails.Add(new BillDetails()
                                {
                                    ID = _SequenceNum,
                                    Product = item.name,
                                    ItemId = item.itemId,
                                    Count = 1,
                                    Price = price,
                                    Total = total,
                                }) ;
                                _Sum += total;
                                refrishTotalValue();
                            }
                            else // item exist prevoiusly in list
                            {                               
                                billDetails[index].Count++;
                                billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;

                                _Sum += billDetails[index].Price;
                                refrishTotalValue();
                            }
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

        private void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            wd_invoice w = new wd_invoice();
            w.ShowDialog();
            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
        }

        private void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {
            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            wd_invoice w = new wd_invoice();
            w.ShowDialog();
            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
        }

        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
             (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            wd_uploadImage w = new wd_uploadImage();
            w.ShowDialog();
            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity =1;
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_pay_Click(object sender, RoutedEventArgs e)
        {
            btn_vendor_Click(null, null);
        }

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 1000)
            {
                _SelectedBranch = (int)cb_branch.SelectedValue;
            }
            else
            {
                cb_branch.SelectedValue = _SelectedBranch;
            }
            
        }

        private void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            calculateDiscountVal();
        }
       private void calculateDiscountVal()
        {
            if (!tb_discount.Text.Equals("") && cb_typeDiscount.SelectedIndex != -1)
            {
                if (int.Parse(cb_typeDiscount.SelectedValue.ToString()) == 1)
                {
                    tb_discountVal.Text = tb_discount.Text;
                }
                else
                {
                    decimal percentage = decimal.Parse(tb_discount.Text);
                    decimal percentageVal = SectionData.calcPercentage(_Sum, percentage);
                    tb_discountVal.Text = percentageVal.ToString();
                }
                refrishTotalValue();
            }
        }
       private void refrishTotalValue()
        {
            decimal discountVal = 0;
            if (!tb_discountVal.Text.Equals(""))
                 discountVal = decimal.Parse( tb_discountVal.Text);
            decimal total = _Sum - discountVal;
            tb_total.Text = total.ToString();
        }

        private void tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateDiscountVal();
        }
        
    }
}

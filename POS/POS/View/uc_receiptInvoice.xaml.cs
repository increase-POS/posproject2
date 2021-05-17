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
using static POS.View.uc_categorie;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_receiptInvoice.xaml
    /// </summary>
    public partial class uc_receiptInvoice : UserControl
    {
        public uc_receiptInvoice()
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
            dg_billDetails.ItemsSource = LoadCollectionData();
            #endregion

        }
        public int CategorieId;
        Category categoryModel = new Category();
        Item itemModel = new Item();
        IEnumerable<Category> categories;
        IEnumerable<Category> categoriesQuery;
        IEnumerable<Item> items;
        IEnumerable<Item> itemsQuery;
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        int selectedItemId = 0;
        private void translate()
        {
            txt_active.Text = MainWindow.resourcemanager.GetString("trActive");
            txt_activeItem.Text = MainWindow.resourcemanager.GetString("trActive");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_searchItemsCard, MainWindow.resourcemanager.GetString("trSearchHint"));


            ////////////////////////////////----invoice----/////////////////////////////////
            txt_invoiceHeader.Text = MainWindow.resourcemanager.GetString("trInvoice");
            txt_returnInvoice.Text = MainWindow.resourcemanager.GetString("trReturnInvoice");
            txt_invoiceToggle.Text = MainWindow.resourcemanager.GetString("trInvoice");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_InvoicenName, MainWindow.resourcemanager.GetString("trInvoiceHint"));

            txt_draft.Text = MainWindow.resourcemanager.GetString("trDraft");
            txt_draftToggle.Text = MainWindow.resourcemanager.GetString("trDraft");
            txt_invoice.Text = MainWindow.resourcemanager.GetString("trInvoice");
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

            ////////////////////////////////----Customer----/////////////////////////////////

            txt_customerHeader.Text = MainWindow.resourcemanager.GetString("trCustomer");
            txt_customer.Text = MainWindow.resourcemanager.GetString("trCustomer");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trCustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_paid, MainWindow.resourcemanager.GetString("trPaidHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_deserved, MainWindow.resourcemanager.GetString("trDeservedHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

            ////////////////////////////////----Delivery----/////////////////////////////////
            txt_deliveryHeader.Text = MainWindow.resourcemanager.GetString("trDelivery");
            txt_delivery.Text = MainWindow.resourcemanager.GetString("trDelivery");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_delivery, MainWindow.resourcemanager.GetString("trDeliveryHint"));
            btn_saveDelivery.Content = MainWindow.resourcemanager.GetString("trSave");


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucReceiptInvoice.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucReceiptInvoice.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            catigoriesAndItemsView.ucReceiptInvoice = this;


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
            grid_customer.Visibility = Visibility.Collapsed;
            grid_delivery.Visibility = Visibility.Collapsed;
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #region Tab
        private void Btn_newInvoice_Click(object sender, RoutedEventArgs e)
        {
            grid_customer.Visibility = grid_delivery.Visibility = Visibility.Collapsed;
            grid_receiptInvoice.Visibility = Visibility.Visible;

            brd_customerTab.BorderBrush = brd_deliveryTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_newInvoiceTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_customer_Click(object sender, RoutedEventArgs e)
        {
            grid_receiptInvoice.Visibility = grid_delivery.Visibility = Visibility.Collapsed;
            grid_customer.Visibility = Visibility.Visible;

            brd_newInvoiceTab.BorderBrush = brd_deliveryTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_customerTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_delivery_Click(object sender, RoutedEventArgs e)
        {
            grid_receiptInvoice.Visibility = grid_customer.Visibility = Visibility.Collapsed;
            grid_delivery.Visibility = Visibility.Visible;

            brd_newInvoiceTab.BorderBrush = brd_customerTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_deliveryTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        #endregion


        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    //var row = (DataGridRow)vis;
                    //var b = (BillDetails)row.Item;


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


        #region Categor and Item 
        #region Refrish Y
        async Task<bool> RefrishCategory()
        {
            categories = await categoryModel.GetAllCategories();
            return true;
        }
        void RefrishCategoryCard(IEnumerable<Category> _categories)
        {
            catigoriesAndItemsView.gridCatigories = Grid_categorie;
            catigoriesAndItemsView.FN_refrishCatalogCard(_categories.ToList(), _categories.Count());
        }
        async Task<bool> RefrishItem()
        {
            items = await itemModel.GetAllItems();
            return true;
        }
        void RefrishItemDatagrid(IEnumerable<Item> _items)
        {
            DG_Items.ItemsSource = _items;
        }
        void RefrishItemCard(IEnumerable<Item> _items)
        {
            catigoriesAndItemsView.gridCatigorieItems = grid_itemCards;
            catigoriesAndItemsView.FN_refrishCatalogItem(_items.ToList(), MainWindow.lang, "sale");
        }
        #endregion
        #region Get Id By Click  Y
        public void ChangeCategorieIdEvent(int categoryId)
        {
            /*
            //////////////
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorParentCategorie.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            //////////////
            this.DataContext = categories.ToList().Find(c => c.categoryId == categoryId);
            */
            MessageBox.Show("you  double click on Category Card");

        }
        public void testChangeCategorieItemsIdEvent()
        {
            MessageBox.Show("you  double click on Items Card");
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
            itemsQuery = items.Where(x => (x.code.Contains(txb_searchItemsDatagrid.Text) ||
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
            itemsQuery = items.Where(x => (x.code.Contains(tb_searchItemsCard.Text) ||
            x.name.Contains(tb_searchItemsCard.Text) ||
            x.details.Contains(tb_searchItemsCard.Text)
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
            else if (((itemsQuery.Count() - 1) / 9) + 1 < int.Parse(tb_pageNumberSearch.Text))
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
        void pageNumberActive(Button btn, int indexContent)
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
        async void paginationSetting(IEnumerable<Item> _items = null)
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
                if (0 >= ((_items.Count() - 1) / 9))
                {
                    btn_activePage.IsEnabled = false;
                }
                if (1 >= ((_items.Count() - 1) / 9))
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

            itemsQuery = _items.Skip((pageIndex - 1) * 9).Take(9);
            RefrishItemCard(itemsQuery);
            //RefrishItemCard(items.Skip(pageIndex - 1 * 9).Take(9));
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
            if (tgl_itemCardIsActive.IsChecked == true)
                b = 1;
            else b = 0;
            itemsQuery = items.Where(x => x.isActive == b);
            pageIndex = ((itemsQuery.Count() - 1) / 9) + 1;
            paginationSetting();
        }
        #endregion

        #endregion

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

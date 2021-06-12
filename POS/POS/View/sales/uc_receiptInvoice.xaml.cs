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
    /// Interaction logic for uc_receiptInvoice.xaml
    /// </summary>
    public partial class uc_receiptInvoice : UserControl
    {
        private static uc_receiptInvoice _instance;
        public static uc_receiptInvoice Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_receiptInvoice();
                return _instance;
            }
        }
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
            //btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            //btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdfBtn");
            

            ////////////////////////////////----Customer----/////////////////////////////////

            txt_customer.Text = MainWindow.resourcemanager.GetString("trCustomer");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trCustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");



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
            SectionData.defaultDatePickerStyle(dp_desrvedDate);
            #endregion
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

     

        #region Categor and Item 
        #region Refrish Y
        async Task<bool> RefrishCategory()
        {
            categories = await categoryModel.GetAllCategories();
            return true;
        }
        void RefrishCategoryCard(IEnumerable<Category> _categories)
        {
           
        }
        async Task<bool> RefrishItem()
        {
            items = await itemModel.GetAllItems();
            return true;
        }
        void RefrishItemDatagrid(IEnumerable<Item> _items)
        {
        }
        void RefrishItemCard(IEnumerable<Item> _items)
        {
            
        }
        #endregion
        #region Get Id By Click  Y
        public void ChangeCategorieIdEvent(int categoryId)
        {
            MessageBox.Show("you  double click on Category Card");
        }
        public void testChangeCategorieItemsIdEvent()
        {
            MessageBox.Show("you  double click on Items Card");
        }
        #endregion

        #endregion

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_draft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_invoiceImages_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_updateCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Tb_discount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {

        }

        private void Dp_desrvedDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void input_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            //items

            Window.GetWindow(this).Opacity = 0.2;
            wd_items w = new wd_items();
            w.ShowDialog();
            if (w.isActive)
            {
                ////// this is ItemId
                //w.selectedItem
                MessageBox.Show(w.selectedItem.ToString());
            }

            Window.GetWindow(this).Opacity  = 1;
        }
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

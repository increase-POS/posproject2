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

namespace POS.View.storage
{
    /// <summary>
    /// Interaction logic for uc_receiptOfPurchaseInvoice.xaml
    /// </summary>
    public partial class uc_receiptOfPurchaseInvoice : UserControl
    {

        private static uc_receiptOfPurchaseInvoice _instance;
        public static uc_receiptOfPurchaseInvoice Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_receiptOfPurchaseInvoice();
                return _instance;
            }
        }
        public uc_receiptOfPurchaseInvoice()
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
            billDetails = LoadCollectionData();
            dg_billDetails.ItemsSource = billDetails;
            #endregion


        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        Category categoryModel = new Category();
        Category category = new Category();
        Item itemModel = new Item();
        Item item = new Item();
        //tglItemState
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////
            //txt_invoiceHeader.Text = MainWindow.resourcemanager.GetString("trInvoice");
            

            //dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            //dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            //dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");
            //txt_saveButton.Text = MainWindow.resourcemanager.GetString("trSave");
        }
        private  void UserControl_Loaded(object sender, RoutedEventArgs e)
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
           

          

        }
        #region bill


        private class Bill
        {
            public int Id { get; set; }
            public int Total { get; set; }

        }
        private class BillDetails
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

      
        
       
        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
        private void Tgl_returnInvoiceDropDown_Checked(object sender, RoutedEventArgs e)
        {
            //grid_returnInvoice.Visibility = Visibility.Visible;
        }
        private void Tgl_returnInvoiceDropDown_Unchecked(object sender, RoutedEventArgs e)
        {
            //grid_returnInvoice.Visibility = Visibility.Collapsed;
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

        private void Dg_invoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tb_search_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_IsActive_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_IsActive_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }
        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            if (name == "TextBox")
            {
            }
            else if (name == "ComboBox")
            {
            }
            else
            {

            }
        }
        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var cmb = sender as ComboBox;

            //if (dg_billDetails.SelectedIndex != -1)
            //    billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;

            else
                e.Handled = true;
        }
        private void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            //items

            Window.GetWindow(this).Opacity = 0.2;
            wd_items w = new wd_items();
            w.ShowDialog();
            if (w.isActive)
            {
                ChangeItemIdEvent(w.selectedItem);
            }

            Window.GetWindow(this).Opacity = 1;
        }
      
       



        #region Get Id By Click  Y

        public async void ChangeCategoryIdEvent(int categoryId)
        {
         
        }


        public async void ChangeItemIdEvent(int itemId)
        {
           
        }


        #endregion

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for uc_itemsImport.xaml
    /// </summary>
    public partial class uc_itemsImport : UserControl
    {
        private static uc_itemsImport _instance;
        public static uc_itemsImport Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_itemsImport();
                return _instance;
            }
        }
        public uc_itemsImport()
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
        //tglItemState
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void translate()
        {
            ////////////////////////////////----Order----/////////////////////////////////
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trBranchHint"));
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trAmount");


        
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // for pagination

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", assembly: Assembly.GetExecutingAssembly());
                grid_ucItemsImport.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucItemsImport.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            catigoriesAndItemsView.ucItemsImport = this;
            

          

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

        #region Button In DataGrid
        void deleteRowFromOrderItems(object sender, RoutedEventArgs e)
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

      

        private void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_draft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_orders_Click(object sender, RoutedEventArgs e)
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
            var cmb = sender as ComboBox;

            //if (dg_billDetails.SelectedIndex != -1)
            //    billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
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
                // MessageBox.Show(w.selectedItem.ToString());
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

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            //for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
            //    if (vis is DataGridRow)
            //    {
            //        BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
            //        int index = dg_billDetails.SelectedIndex;
            //        // calculate new sum
            //        _Sum -= row.Total;

            //        // remove item from bill
            //        billDetails.RemoveAt(index);

            //        ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
            //        data.Remove(row);

            //        // calculate new total
            //        refreshTotalValue();
            //    }
            //_SequenceNum = 0;
            //_Sum = 0;
            //for (int i = 0; i < billDetails.Count; i++)
            //{
            //    _SequenceNum++;
            //    _Sum += billDetails[i].Total;
            //    billDetails[i].ID = _SequenceNum;
            //}
            //refrishBillDetails();

        }
        #endregion

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

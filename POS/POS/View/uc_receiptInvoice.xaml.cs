using POS.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            dg_Bills.ItemsSource = items;
            DG_BillDetails.ItemsSource = LoadCollectionData();
            #endregion

        }
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            catigoriesAndItemsView.ucReceiptInvoice = this;

            #region Generate catigorie
            catigoriesAndItemsView.gridCatigories = Grid_categorie;
            Categorie categorie = new Categorie();
            catigoriesAndItemsView.FN_refrishCatalogCard(categorie.getCategories());
            #endregion


            #region Generate catigorieItems
            catigoriesAndItemsView.gridCatigorieItems = Grid_CategorieItem;
            CategorieItem CategorieItem = new CategorieItem();
            catigoriesAndItemsView.FN_refrishCatalogItem(CategorieItem.getCategorieItems());
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



        #region Tab
        private void Btn_newInvoice_Click(object sender, RoutedEventArgs e)
        {
            //grid_barcode.Visibility = grid_properties.Visibility = Visibility.Collapsed;
            //grid_itemData.Visibility = Visibility.Visible;
            brd_customerTab.BorderBrush = brd_salesManTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_newInvoiceTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_customer_Click(object sender, RoutedEventArgs e)
        {
            //grid_itemData.Visibility = grid_properties.Visibility = Visibility.Collapsed;
            //grid_barcode.Visibility = Visibility.Visible;
            brd_newInvoiceTab.BorderBrush = brd_salesManTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_customerTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_salesMan_Click(object sender, RoutedEventArgs e)
        {
            //grid_itemData.Visibility = grid_barcode.Visibility = Visibility.Collapsed;
            //grid_properties.Visibility = Visibility.Visible;
            brd_newInvoiceTab.BorderBrush = brd_customerTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_salesManTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
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


                    BillDetails row = (BillDetails)DG_BillDetails.SelectedItems[0];
                    ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)DG_BillDetails.ItemsSource;
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
    }
}

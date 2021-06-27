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
using static POS.View.storage.uc_receiptOfPurchaseInvoice;

namespace POS.View.storage
{
    /// <summary>
    /// Interaction logic for uc_itemsStorage.xaml
    /// </summary>
    public partial class uc_itemsStorage : UserControl
    {
        private static uc_itemsStorage _instance;
        public static uc_itemsStorage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_itemsStorage();
                return _instance;
            }
        }
        public uc_itemsStorage()
        {
            InitializeComponent();
            //if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1440)
            //{
            //    txt_deleteButton.Visibility = Visibility.Visible;
            //    txt_addButton.Visibility = Visibility.Visible;
            //    txt_updateButton.Visibility = Visibility.Visible;
            //    txt_add_Icon.Visibility = Visibility.Visible;
            //    txt_update_Icon.Visibility = Visibility.Visible;
            //    txt_delete_Icon.Visibility = Visibility.Visible;
            //}
            //else if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1360)
            //{
            //    txt_add_Icon.Visibility = Visibility.Collapsed;
            //    txt_update_Icon.Visibility = Visibility.Collapsed;
            //    txt_delete_Icon.Visibility = Visibility.Collapsed;
            //    txt_deleteButton.Visibility = Visibility.Visible;
            //    txt_addButton.Visibility = Visibility.Visible;
            //    txt_updateButton.Visibility = Visibility.Visible;

            //}
            //else
            //{
            //    txt_deleteButton.Visibility = Visibility.Collapsed;
            //    txt_addButton.Visibility = Visibility.Collapsed;
            //    txt_updateButton.Visibility = Visibility.Collapsed;
            //    txt_add_Icon.Visibility = Visibility.Visible;
            //    txt_update_Icon.Visibility = Visibility.Visible;
            //    txt_delete_Icon.Visibility = Visibility.Visible;

            //}
        }

        
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucItemsStorage.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucItemsStorage.FlowDirection = FlowDirection.RightToLeft;
            }
            //#region bill
            //List<Bill> items = new List<Bill>();
            //items.Add(new Bill() { Id = 336554944, Total = 255 });
            //items.Add(new Bill() { Id = 336545142, Total = 260 });
            //items.Add(new Bill() { Id = 336556165, Total = 1200 });
            //items.Add(new Bill() { Id = 336551515, Total = 150 });
            //items.Add(new Bill() { Id = 336555162, Total = 840 });
            //items.Add(new Bill() { Id = 336558897, Total = 325 });
            //dg_invoice.ItemsSource = items;
            //billDetails = LoadCollectionData();
            //dg_billDetails.ItemsSource = billDetails;
            //#endregion
            translate();

            #region Style Date
            dp_startDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_startDate.Template.FindName("PART_TextBox", dp_startDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_startDate.Background;
                    textBox1.BorderThickness = dp_startDate.BorderThickness;
                }
            };
            dp_endDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_endDate.Template.FindName("PART_TextBox", dp_endDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_endDate.Background;
                    textBox1.BorderThickness = dp_endDate.BorderThickness;
                }
            };

            #endregion
        }

        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////
            //txt_invoiceToggle.Text = MainWindow.resourcemanager.GetString("trInvoice");
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_InvoicenName, MainWindow.resourcemanager.GetString("trInvoiceHint"));

            //dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            //dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            //dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");
            //dg_invoice.Columns[0].Header = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            //txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            //txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            //txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            //tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            //tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            //tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

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
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
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

        //private void Tgl_invoiceDropDown_Checked(object sender, RoutedEventArgs e)
        //{
        //    grid_invoice.Visibility = Visibility.Visible;
        //}
        //private void Tgl_invoiceDropDown_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    grid_invoice.Visibility = Visibility.Collapsed;
        //}
        //void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        //{
        //    for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
        //        if (vis is DataGridRow)
        //        {
        //            BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
        //            ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
        //            data.Remove(row);
        //        }

        //}
      
        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            dg_collapsed.IsEnabled = false;
            dg_collapsed.Opacity = 0.2;



        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            dg_collapsed.IsEnabled = true;
            dg_collapsed.Opacity = 1;

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_transfer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

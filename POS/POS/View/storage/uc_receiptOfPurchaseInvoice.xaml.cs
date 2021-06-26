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
        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        Category categoryModel = new Category();
        Category category = new Category();
        Item itemModel = new Item();
        Item item = new Item();

        Invoice invoiceModel = new Invoice();
        Invoice invoice = new Invoice();

        List<ItemTransfer> invoiceItems;
        ItemLocation itemLocationModel = new ItemLocation();

        Branch branchModel = new Branch();
        IEnumerable<Branch> branches;
        //for bill details
        static private int _SequenceNum = 0;
        static private string _InvoiceType = "pbd"; // purchase bounce draft
        static private decimal _Sum = 0;
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
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
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

            await RefrishBranches();
            await RefrishBranches();
        }
        async Task RefrishBranches()
        {
            branches = await branchModel.GetBranchesActive("all");
            cb_branch.ItemsSource = branches;
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
        }
        #region bill


        private class Bill
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
                   // refreshTotalValue();
                }
            _SequenceNum = 0;
            _Sum = 0;
            for (int i = 0; i < billDetails.Count; i++)
            {
                _SequenceNum++;
                _Sum += billDetails[i].Total;
                billDetails[i].ID = _SequenceNum;
            }
            refrishBillDetails();
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
            w.CardType = "purchase";
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

        private async void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;

            wd_invoice w = new wd_invoice();

            // sale invoices
            w.invoiceType = "p";

            w.title = MainWindow.resourcemanager.GetString("trPurchaseInvoices");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    this.DataContext = invoice;

                    _InvoiceType = invoice.invType;
                    // set title to bill
                    txt_titleDataGridInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
                    // orange #FFA926 red #D22A17
                    brd_count.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                    await fillInvoiceInputs(invoice);
                }
            }
            Window.GetWindow(this).Opacity = 1;
        }
        private async Task fillInvoiceInputs(Invoice invoice)
        {
            _Sum = (decimal)invoice.total;

            cb_branch.SelectedValue = invoice.branchId;
            //cb_vendor.SelectedValue = invoice.agentId;
            //dp_desrvedDate.Text = invoice.deservedDate.ToString();
            //tb_invoiceNumber.Text = invoice.vendorInvNum;
            //dp_invoiceDate.Text = invoice.vendorInvDate.ToString();
            //tb_total.Text = Math.Round((double)invoice.totalNet, 2).ToString();
            //tb_taxValue.Text = invoice.tax.ToString();
            //tb_note.Text = invoice.notes;
            //tb_sum.Text = invoice.total.ToString();
            //tb_discount.Text = invoice.discountValue.ToString();

            //if (invoice.discountType == "1")
            //    cb_typeDiscount.SelectedIndex = 1;
            //else if (invoice.discountType == "2")
            //    cb_typeDiscount.SelectedIndex = 2;
            //else
            //    cb_typeDiscount.SelectedIndex = 0;
            //get invoice items
            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);

            // build invoice details grid
            buildInvoiceDetails(invoiceItems);
            inputEditable();
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
                    itemUnitId = (int)itemT.itemUnitId,
                    Count = (int)itemT.quantity,
                    Price = (decimal)itemT.price,
                    Total = total,
                });
            }

            tb_barcode.Focus();

            refrishBillDetails();
        }
        void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;

            tb_sum.Text = _Sum.ToString();
        }
        private void inputEditable()
        {
            if (_InvoiceType == "pbd") // return invoice
            {
                //dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                //dg_billDetails.Columns[5].IsReadOnly = true; //make price read only
                //dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                //dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                //cb_vendor.IsEnabled = false;
                //dp_desrvedDate.IsEnabled = false;
                //dp_invoiceDate.IsEnabled = false;
                //tb_note.IsEnabled = false;
                //tb_barcode.IsEnabled = false;
                //cb_branch.IsEnabled = false;
                //tb_discount.IsEnabled = false;
                //cb_typeDiscount.IsEnabled = false;
                //btn_save.IsEnabled = true;
                //btn_updateVendor.IsEnabled = false;
            }
            else if (_InvoiceType == "pd")
            {
                //dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                //dg_billDetails.Columns[5].IsReadOnly = false;
                //dg_billDetails.Columns[3].IsReadOnly = false;
                //dg_billDetails.Columns[4].IsReadOnly = false;
                //cb_vendor.IsEnabled = true;
                //dp_desrvedDate.IsEnabled = true;
                //dp_invoiceDate.IsEnabled = true;
                //tb_note.IsEnabled = true;
                //tb_barcode.IsEnabled = true;
                //cb_branch.IsEnabled = true;
                //tb_discount.IsEnabled = true;
                //cb_typeDiscount.IsEnabled = true;
                //btn_save.IsEnabled = true;
                //btn_updateVendor.IsEnabled = true;
            }
            else if (_InvoiceType == "p")
            {
                //dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                //dg_billDetails.Columns[5].IsReadOnly = true; //make price read only
                //dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                //dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                //cb_vendor.IsEnabled = false;
                //dp_desrvedDate.IsEnabled = false;
                //dp_invoiceDate.IsEnabled = false;
                //tb_note.IsEnabled = false;
                //tb_barcode.IsEnabled = false;
                //cb_branch.IsEnabled = false;
                //tb_discount.IsEnabled = false;
                //cb_typeDiscount.IsEnabled = false;
                //btn_save.IsEnabled = false;
                //btn_updateVendor.IsEnabled = false;
            }
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
        private void validateInvoiceValues()
        {
            SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            //check mandatory inputs
            validateInvoiceValues();

            if (cb_branch.SelectedIndex != -1  && billDetails.Count > 0)
            {
                if (_InvoiceType == "p") //p  purchase invoice
                    await receiptInvoice("p");
            }
        }

        private async Task receiptInvoice(string type)
        {
            await itemLocationModel.recieptInvoice(invoiceItems, MainWindow.branchID.Value,invoice.invoiceId,MainWindow.userID.Value); // increase item quantity in DB
        }
        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

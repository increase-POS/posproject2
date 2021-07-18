using POS.Classes;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_invoice.xaml
    /// </summary>
    public partial class wd_invoice : Window
    {
        public wd_invoice()
        {
            InitializeComponent();
        }
        /// <summary>
        /// for filtering store
        /// </summary>
        public Invoice invoice = new Invoice();
        IEnumerable<Invoice> invoices;
        public int posId { get; set; }
        public int branchId { get; set; }
        public int branchCreatorId { get; set; }
        public int userId { get; set; }
        /// <summary>
        /// for filtering invoice type
        /// </summary>
        public string invoiceType { get; set; }
        public string invoiceStatus { get; set; }
        public string title { get; set; }
        public string condition { get; set; }
        public int duration { get; set; }
        private void Btn_select_Click(object sender, RoutedEventArgs e)
        {
            invoice = dg_Invoice.SelectedItem as Invoice;
            DialogResult = true;
            this.Close();

        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_select_Click(null, null);
            }
        }
        private void Txb_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucInvoice.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucInvoice.FlowDirection = FlowDirection.RightToLeft;
            }
            txt_Invoices.Text = title;

            await refreshInvoices();
        }
        private async Task refreshInvoices()
        {
            if (userId != 0 && (invoiceStatus == "" || invoiceStatus == null))/// to display draft invoices
                invoices = await invoice.GetInvoicesByCreator(invoiceType, userId,duration);
            else if (branchCreatorId != 0)
                invoices = await invoice.getBranchInvoices(invoiceType, branchCreatorId);
            else if (branchId != 0) // get export/ import orders
                invoices = await invoice.GetOrderByType(invoiceType, branchId);
            else if (invoiceStatus != "" && userId != 0) // get sales invoices to get deliver accept on it
                invoices = await invoice.getDeliverOrders(invoiceType, invoiceStatus, userId);
            else
                invoices = await invoice.GetInvoicesByType(invoiceType, branchId);
           

            //if (invoiceType == "pd ,pbd")
            //{
            //    dg_Invoice.ItemsSource = invoices.ToList().Where(x => x.createUserId == userId);
            //}
            //else
                dg_Invoice.ItemsSource = invoices.ToList();
        }
        private void Dg_Invoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            invoice = dg_Invoice.SelectedItem as Invoice;
        }
        private void Dg_Invoice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_select_Click(null,null);
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
           
           // DialogResult = true;
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }

    }
}

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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
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
            try
            {
                invoice = dg_Invoice.SelectedItem as Invoice;
                DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }

        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    Btn_select_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Txb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            { 
                dg_Invoice.ItemsSource = invoices.Where(x => x.invNumber.ToLower().Contains(txb_search.Text)).ToList();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucInvoice);

                #region translate
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
                translat();
                #endregion
                #region hide Total column in grid if invoice is import/export order
                string[] invTypeArray = new string[] { "imd" ,"exd","im","ex" ,"exw" };
                var impExpTypes = invTypeArray.ToList();
                List<string> invTypeL = invoiceType.Split(',').ToList();
                var inCommen = invTypeL.Any(s => impExpTypes.Contains(s));
                if(inCommen)
                    dg_Invoice.Columns[2].Visibility = Visibility.Collapsed; //make total column unvisible
                #endregion
                await refreshInvoices();
                Txb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucInvoice);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucInvoice);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void translat()
        {
            //txt_Invoices.Text = MainWindow.resourcemanager.GetString("trInvoices");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_search, MainWindow.resourcemanager.GetString("trSearchHint"));

            dg_Invoice.Columns[0].Header = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            dg_Invoice.Columns[1].Header = MainWindow.resourcemanager.GetString("trItemsCount");
            dg_Invoice.Columns[2].Header = MainWindow.resourcemanager.GetString("trTotal");

            btn_select.Content = MainWindow.resourcemanager.GetString("trSelect");
        }
        private async Task refreshInvoices()
        {
            if (condition == "orders")
            {
                invoices = await invoice.getUnHandeldOrders(invoiceType,branchCreatorId, branchId);
            }
            else
            {
                if (userId != 0 && (invoiceStatus == "" || invoiceStatus == null))/// to display draft invoices
                    invoices = await invoice.GetInvoicesByCreator(invoiceType, userId, duration);
                else if (branchId != 0 && branchCreatorId != 0) // to get invoices to make return from it
                    invoices = await invoice.getBranchInvoices(invoiceType, branchCreatorId, branchId);
                else if (branchCreatorId != 0)
                    invoices = await invoice.getBranchInvoices(invoiceType, branchCreatorId);
                else if (invoiceStatus != "" && branchId != 0) // get return invoice in storage
                    invoices = await invoice.getBranchInvoices(invoiceType, branchCreatorId, branchId);
                else if (branchId != 0) // get export/ import orders
                    invoices = await invoice.GetOrderByType(invoiceType, branchId);
                else if (invoiceStatus != "" && userId != 0) // get sales invoices to get deliver accept on it
                    invoices = await invoice.getDeliverOrders(invoiceType, invoiceStatus, userId);
                else
                    invoices = await invoice.GetInvoicesByType(invoiceType, branchId);
            }
            

        }
        private void Dg_Invoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                invoice = dg_Invoice.SelectedItem as Invoice;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Dg_Invoice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            { 
                Btn_select_Click(null,null);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }


    }
}

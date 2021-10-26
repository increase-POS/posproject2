using netoaster;
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
    /// Interaction logic for wd_submitOrder.xaml
    /// </summary>
    public partial class wd_submitOrder : Window
    {
        public wd_submitOrder()
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
        public Invoice invoice = new Invoice();
        private void Btn_select_Click(object sender, RoutedEventArgs e)
        {
            try
            {

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
                translat();
                #endregion

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

            //dg_Invoice.Columns[0].Header = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            //dg_Invoice.Columns[1].Header = MainWindow.resourcemanager.GetString("trBranch");
            //dg_Invoice.Columns[2].Header = MainWindow.resourcemanager.GetString("trUser");
            //dg_Invoice.Columns[3].Header = MainWindow.resourcemanager.GetString("trQTR");
            //dg_Invoice.Columns[4].Header = MainWindow.resourcemanager.GetString("trTotal");

            //col_num.Header = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            //col_branch.Header = MainWindow.resourcemanager.GetString("trBranch");
            //col_user.Header = MainWindow.resourcemanager.GetString("trUser");
            //col_count.Header = MainWindow.resourcemanager.GetString("trQTR");
            //col_total.Header = MainWindow.resourcemanager.GetString("trTotal");
            //col_type.Header = MainWindow.resourcemanager.GetString("trType");


            //btn_select.Content = MainWindow.resourcemanager.GetString("trSelect");
        }
        private void Dg_itemOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //invoice = dg_itemOrder.SelectedItem as Invoice;
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
                Btn_select_Click(null, null);
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

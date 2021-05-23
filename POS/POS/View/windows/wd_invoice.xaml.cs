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
        public int posId { get; set; }
        /// <summary>
        /// for filtering invoice type
        /// </summary>
        public string invoiceType { get; set; }
        private void Btn_select_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Txb_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

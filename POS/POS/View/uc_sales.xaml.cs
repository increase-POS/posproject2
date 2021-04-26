using System;
using System.Collections.Generic;
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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_sales.xaml
    /// </summary>
    public partial class uc_sales : UserControl
    {
        public uc_sales()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Btn_receiptInvoice_Click(null, null);
        }

        private void Btn_receiptInvoice_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            uc_receiptInvoice uc = new uc_receiptInvoice();
            grid_main.Children.Add(uc);
        }

      
    }
}

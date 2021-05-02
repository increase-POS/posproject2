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
        void refreashBackground()
        {

            btn_receiptInvoice.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_receiptInvoice.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_statistic.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_statistic.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_coupon.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_coupon.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_offer.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_offer.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
  }

        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        private void Btn_receiptInvoice_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_receiptInvoice);
            grid_main.Children.Clear();
            uc_receiptInvoice uc = new uc_receiptInvoice();
            grid_main.Children.Add(uc);
        }

        private void Btn_statistic_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_statistic);
        }

        private void Btn_coupon_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_coupon);
            grid_main.Children.Clear();
            uc_coupon uc = new uc_coupon();
            grid_main.Children.Add(uc);
        }

        private void Btn_offer_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_offer);
            grid_main.Children.Clear();
            uc_offer uc = new uc_offer();
            grid_main.Children.Add(uc);
        }

         
    }
}

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
    /// Interaction logic for uc_purchases.xaml
    /// </summary>
    public partial class uc_purchases : UserControl
    {
        public uc_purchases()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            btn_payInvoice_Click(null, null);
        }
        void refreashBackground()
        {

            btn_payInvoice.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_payInvoice.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_statistic.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_statistic.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

        }

        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        private void btn_payInvoice_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_payInvoice);
            grid_main.Children.Clear();
            uc_payInvoice uc = new uc_payInvoice();
            grid_main.Children.Add(uc);
        }

        private void Btn_statistic_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_statistic);

        }
    }
}

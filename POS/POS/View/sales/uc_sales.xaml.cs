using POS.Classes;
using POS.View.sales;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_sales.xaml
    /// </summary>
    public partial class uc_sales : UserControl
    {
        private static uc_sales _instance;
        public static uc_sales Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_sales();
                return _instance;
            }
        }
        public uc_sales()
        {
            InitializeComponent();
        }
        private void translate()
        {
            btn_reciptInvoice.Content = MainWindow.resourcemanager.GetString("trInvoice");
            btn_salesStatistic.Content = MainWindow.resourcemanager.GetString("trStatistic");
            btn_coupon.Content = MainWindow.resourcemanager.GetString("trCoupon");
            btn_offer.Content = MainWindow.resourcemanager.GetString("trOffer");
            btn_medals.Content = MainWindow.resourcemanager.GetString("trMedals");

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucSales.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucSales.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            Btn_receiptInvoice_Click(null, null);
            permission();
        }
        void permission()
        {
            foreach (Button button in FindControls.FindVisualChildren<Button>(this))
            {
                if (button.Tag != null)
                    if (MainWindow.groupObject.HasPermission(button.Tag.ToString(), MainWindow.groupObjects))
                        button.Visibility = Visibility.Visible;
                    else button.Visibility = Visibility.Collapsed;
            }
        }
        void refreashBackground()
        {

            btn_reciptInvoice.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_reciptInvoice.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_salesStatistic.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_salesStatistic.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_coupon.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_coupon.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_offer.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_offer.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_package.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_package.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_quotation.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_quotation.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_salesOrders.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_salesOrders.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_medals.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_medals.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_membership.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_membership.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

        }
        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        public void Btn_receiptInvoice_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_reciptInvoice);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_receiptInvoice.Instance);
            //uc_receiptInvoice uc = new uc_receiptInvoice();
            //grid_main.Children.Add(uc);
            //uc_payInvoice1 uc = new uc_payInvoice1();
            //grid_main.Children.Add(uc);

        }
        private void Btn_statistic_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_salesStatistic);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_salesStatistic.Instance);
        }
        private void Btn_coupon_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_coupon);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_coupon.Instance);
            //uc_coupon uc = new uc_coupon();
            //grid_main.Children.Add(uc);
        }
        private void Btn_offer_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_offer);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_offer.Instance);
            //uc_offer uc = new uc_offer();
            //grid_main.Children.Add(uc);
        }
        private void Btn_package_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_package);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_packageOfItems.Instance);
            //uc_packageOfItems uc = new uc_packageOfItems();
            //grid_main.Children.Add(uc);
        }

        private void Btn_quotations_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_quotation);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_quotations.Instance);
        }
        private void Btn_orders_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_salesOrders);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_orders.Instance);
        }

        private void Btn_medals_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_medals);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_medals.Instance);
        }

        private void Btn_membership_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_membership);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_membership.Instance);
        }

        
    }
}

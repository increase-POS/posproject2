using POS.Classes;
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

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for uc_saleReportGeneral.xaml
    /// </summary>
    public partial class uc_saleReportGeneral : UserControl
    {
        public uc_saleReportGeneral()
        {
            InitializeComponent();
        }

        private void Btn_invoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_saleReport uc = new uc_saleReport();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_item_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_saleItems uc = new uc_saleItems();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_bank_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_promotion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_salePromotion uc = new uc_salePromotion();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_saleOrders uc = new uc_saleOrders();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_quotation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_saleQuotation uc = new uc_saleQuotation();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_dailySales_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                us_dailySalesStatistic uc = new us_dailySalesStatistic();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        } 
    }
}

﻿using POS.Classes;
using POS.View.purchases;
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
    /// Interaction logic for uc_purchaseReportGeneral.xaml
    /// </summary>
    public partial class uc_purchaseReportGeneral : UserControl
    {
        public uc_purchaseReportGeneral()
        {
            InitializeComponent();
        }

        private void Btn_invoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_purchaseReport uc = new uc_purchaseReport();
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
                uc_purchaseItem uc = new uc_purchaseItem();
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
                uc_purchaseOrders uc = new uc_purchaseOrders();
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

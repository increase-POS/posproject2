﻿using System;
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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_deliveryReceiptInvoice.xaml
    /// </summary>
    public partial class wd_deliveryReceiptInvoice : Window
    {
        public wd_deliveryReceiptInvoice()
        {
            InitializeComponent();
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Cb_company_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cb_company_LostFocus(object sender, RoutedEventArgs e)
        {

        }
        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }
        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {

            }
            else if (name == "ComboBox")
            {
               
            }
            else if (name == "DatePicker")
            {
               
            }

        }
    }
}

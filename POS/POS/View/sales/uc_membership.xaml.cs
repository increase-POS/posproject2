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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.View.sales
{
    /// <summary>
    /// Interaction logic for uc_membership.xaml
    /// </summary>
    public partial class uc_membership : UserControl
    {

        private static uc_membership _instance;
        public static uc_membership Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_membership();
                return _instance;
            }
        }
        public uc_membership()
        {
            InitializeComponent();
        }


        private void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void validationControl_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dg_membership_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_customers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_subscriptionFees_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
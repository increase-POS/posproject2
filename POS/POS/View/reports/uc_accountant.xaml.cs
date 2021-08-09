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
    public partial class uc_accountant : UserControl
    {
        private static uc_accountant _instance;
        public static uc_accountant Instance
        {
            get
            {
                if (_instance == null) _instance = new uc_accountant();
                return _instance;
            }
        }
        public uc_accountant()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_payments_Click(object sender, RoutedEventArgs e)
        {
            sc_main.Visibility = Visibility.Collapsed;
            main.Children.Add(uc_paymentsReport.Instance);
            btn_closePayments.Visibility = Visibility.Visible;
        }

        private void Btn_recipient_Click(object sender, RoutedEventArgs e)
        {
            sc_main.Visibility = Visibility.Collapsed;
            main.Children.Add(uc_recipientReport.Instance);
            btn_closeRecipts.Visibility = Visibility.Visible;
        }

        private void Btn_bank_Click(object sender, RoutedEventArgs e)
        {
            sc_main.Visibility = Visibility.Collapsed;
            main.Children.Add(uc_banksReport.Instance);
            btn_closeBanks.Visibility = Visibility.Visible;
        }


        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            sc_main.Visibility = Visibility.Visible;
            main.Children.Remove(uc_paymentsReport.Instance);
            btn_closePayments.Visibility = Visibility.Collapsed;
        }

        private void Btn_closeRecipts_Click(object sender, RoutedEventArgs e)
        {
            sc_main.Visibility = Visibility.Visible;
            main.Children.Remove(uc_recipientReport.Instance);
            btn_closeRecipts.Visibility = Visibility.Collapsed;
        }

        private void Btn_closeBanks_Click(object sender, RoutedEventArgs e)
        {
            sc_main.Visibility = Visibility.Visible;
            main.Children.Remove(uc_banksReport.Instance);
            btn_closeBanks.Visibility = Visibility.Collapsed;
        }

        private void Btn_pos_Click(object sender, RoutedEventArgs e)
        {
            sc_main.Visibility = Visibility.Collapsed;
            main.Children.Add(uc_posReports.Instance);
            btn_closePos.Visibility = Visibility.Visible;
        }

        private void Btn_closePos_Click(object sender, RoutedEventArgs e)
        {
            sc_main.Visibility = Visibility.Visible;
            main.Children.Remove(uc_posReports.Instance);
            btn_closePos.Visibility = Visibility.Collapsed;
        }
    }
}

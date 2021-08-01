using POS.Classes;
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

namespace POS.View.accounts
{
    /// <summary>
    /// Interaction logic for uc_accounts.xaml
    /// </summary>
    public partial class uc_accounts : UserControl
    {
        private static uc_accounts _instance;
        public static uc_accounts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_accounts();
                return _instance;
            }
        }
        public uc_accounts()
        {
            InitializeComponent();
            //Btn_pos_Click(null, null);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucAccounts.FlowDirection = FlowDirection.LeftToRight;

            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucAccounts.FlowDirection = FlowDirection.RightToLeft;

            }
            translate();
            permission();
        }
        void permission()
        {
            if (!SectionData.isAdminPermision())
            foreach (Button button in FindControls.FindVisualChildren<Button>(this))
                {
                if (button.Tag != null)
                    if (MainWindow.groupObject.HasPermission(button.Tag.ToString(), MainWindow.groupObjects))
                        button.Visibility = Visibility.Visible;
                    else button.Visibility = Visibility.Collapsed;
            }
        }
        private void translate()
        {

            btn_posAccounting.Content = MainWindow.resourcemanager.GetString("trPOS");
            btn_banksAccounting.Content = MainWindow.resourcemanager.GetString("trBanks");
            btn_payments.Content = MainWindow.resourcemanager.GetString("trPayments");
            btn_received.Content = MainWindow.resourcemanager.GetString("trReceived");
            btn_bonds.Content = MainWindow.resourcemanager.GetString("trBonds");
        }
        void refreashBackground()
        {
            btn_posAccounting.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_posAccounting.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_payments.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_payments.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_received.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_received.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_bonds.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_bonds.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_banksAccounting.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_banksAccounting.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_ordersAccounting.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_ordersAccounting.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));


            btn_subscriptions.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_subscriptions.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_accountsStatistic.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_accountsStatistic.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }
        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        private void Btn_pos_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_posAccounting);


            grid_main.Children.Clear();
            grid_main.Children.Add(uc_posAccounts.Instance);
            //uc_posAccounts uc = new uc_posAccounts();
            //grid_main.Children.Add(uc);
        }
        private void Btn_payments_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_payments);

            grid_main.Children.Clear();
            grid_main.Children.Add(uc_paymentsAccounts.Instance);
            //uc_paymentsAccounts uc = new uc_paymentsAccounts();
            //grid_main.Children.Add(uc);
        }
        private void Btn_received_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_received);

            grid_main.Children.Clear();
            grid_main.Children.Add(uc_receivedAccounts.Instance);
            //uc_receivedAccounts uc = new uc_receivedAccounts();
            //grid_main.Children.Add(uc);
        }
        private void Btn_bonds_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_bonds);

            grid_main.Children.Clear();
            grid_main.Children.Add(uc_bonds.Instance);
        }
        private void Btn_banks_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_banksAccounting);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_banksAccounts.Instance);
            //uc_banksAccounts uc = new uc_banksAccounts();
            //grid_main.Children.Add(uc);
        }
        private void Btn_orders_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_ordersAccounting);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_orderAccounts.Instance);
        }
        private void Btn_subscriptions_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_subscriptions);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_subscriptions.Instance);
        }
        private void Btn_statistic_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}

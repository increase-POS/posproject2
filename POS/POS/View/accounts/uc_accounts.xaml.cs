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
        public uc_accounts()
        {
            InitializeComponent();
            Btn_pos_Click(null, null);
        }
        void refreashBackground()
        {

            btn_customers.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_customers.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_suppliers.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_suppliers.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_users.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_users.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

           
            btn_pos.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_pos.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_banks.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_banks.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));


            btn_bonds.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_bonds.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));


            btn_managerialExpenses.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_managerialExpenses.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_expenditure.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_expenditure.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_statistic.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_statistic.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }

        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        private void Btn_pos_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_pos);


            grid_main.Children.Clear();
            UC_posAccounts uc = new UC_posAccounts();
            grid_main.Children.Add(uc);
        }

        private void Btn_suppliers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_customers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_users_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_banks_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_bonds_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_expenditure_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_managerialExpenses_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_statistic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucAccounts.FlowDirection = FlowDirection.LeftToRight;
                sv_menu.FlowDirection = FlowDirection.RightToLeft;

            }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucAccounts.FlowDirection = FlowDirection.RightToLeft;
                sv_menu.FlowDirection = FlowDirection.LeftToRight;

            }
            translate();
        }

        private void translate()
        {
            btn_customers.Content = MainWindow.resourcemanager.GetString("trCustomers");
            btn_suppliers.Content = MainWindow.resourcemanager.GetString("trSuppliers");
            btn_users.Content = MainWindow.resourcemanager.GetString("trUsers");
            btn_pos.Content = MainWindow.resourcemanager.GetString("trPOS");
            btn_banks.Content = MainWindow.resourcemanager.GetString("trBanks");
        }
    }
}

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
    /// Interaction logic for UC_SectionData.xaml
    /// </summary>
    public partial class UC_SectionData : UserControl
    {
        public UC_SectionData()
        {
            InitializeComponent();

            GRID_Main.Children.Clear();
            UC_Customer uc = new UC_Customer();
            GRID_Main.Children.Add(uc);
        }

        private void BTN_Customers_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_Customer uc = new UC_Customer();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_suppliers_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_vendors uc = new UC_vendors();
            GRID_Main.Children.Add(uc);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucSectionData.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucSectionData.FlowDirection = FlowDirection.RightToLeft; }
            translate();
        }

        private void translate()
        {
            btn_customers.Content = MainWindow.resourcemanager.GetString("trCustomers");
            btn_suppliers.Content = MainWindow.resourcemanager.GetString("trSuppliers");
            btn_users.Content = MainWindow.resourcemanager.GetString("trUsers");
            btn_branches.Content = MainWindow.resourcemanager.GetString("trBranches");
            btn_stores.Content = MainWindow.resourcemanager.GetString("trStores");
            btn_pos.Content = MainWindow.resourcemanager.GetString("trPOS");
            btn_banks.Content = MainWindow.resourcemanager.GetString("trBanks");
            btn_units.Content = MainWindow.resourcemanager.GetString("trUnits");
        }

        private void Btn_users_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_users uc = new UC_users();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_branches_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_branch uc = new UC_branch();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_stores_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_store uc = new UC_store();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_pos_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_pos uc = new UC_pos();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_banks_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_bank uc = new UC_bank();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_units_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_unit uc = new UC_unit();
            GRID_Main.Children.Add(uc);
        }
    }
}

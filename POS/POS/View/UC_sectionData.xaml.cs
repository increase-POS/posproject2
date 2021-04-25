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
        void refreashBackground()
        {

            btn_customers.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_customers.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_suppliers.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_suppliers.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_users.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_users.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_branches.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_branches.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_stores.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_stores.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_pos.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_pos.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_banks.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_banks.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_units.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_units.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }

        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void BTN_Customers_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_Customer uc = new UC_Customer();
            GRID_Main.Children.Add(uc);
            refreashBachgroundClick(btn_customers);
        }

        private void Btn_suppliers_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_suppliers);


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
            refreashBachgroundClick(btn_users);


            GRID_Main.Children.Clear();
            UC_users uc = new UC_users();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_branches_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_branches);


            GRID_Main.Children.Clear();
            UC_branch uc = new UC_branch();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_stores_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_stores);


            GRID_Main.Children.Clear();
            UC_store uc = new UC_store();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_pos_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_pos);


            GRID_Main.Children.Clear();
            UC_pos uc = new UC_pos();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_banks_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_banks);


            GRID_Main.Children.Clear();
            UC_bank uc = new UC_bank();
            GRID_Main.Children.Add(uc);
        }

        private void Btn_units_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_units);


            GRID_Main.Children.Clear();
            UC_unit uc = new UC_unit();
            GRID_Main.Children.Add(uc);
        }
    }
}

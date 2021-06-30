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
using POS.View.sectionData;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_SectionData.xaml
    /// </summary>
    public partial class UC_SectionData : UserControl
    {

        private static UC_SectionData _instance;
        public static UC_SectionData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_SectionData();
                return _instance;
            }
        }
        public UC_SectionData()
        {
            InitializeComponent();

            Btn_suppliers_Click(null, null);
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

            btn_cards.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_cards.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            //btn_shippingCompany.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            //btn_shippingCompany.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }

        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void BTN_Customers_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_customers);

            grid_main.Children.Clear();
            grid_main.Children.Add(UC_Customer.Instance);

            //UC_Customer uc = new UC_Customer();
            //grid_main.Children.Add(uc);
        }

        private void Btn_suppliers_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_suppliers);


            grid_main.Children.Clear();
            grid_main.Children.Add(UC_vendors.Instance);

            //UC_vendors uc = new UC_vendors();
            //grid_main.Children.Add(uc);

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
            //btn_shippingCompany.Content = MainWindow.resourcemanager.GetString("");
        }
        

        private void Btn_users_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_users);


            grid_main.Children.Clear();
            grid_main.Children.Add(UC_users.Instance);

            //UC_users uc = new UC_users();
            //grid_main.Children.Add(uc);
        }

        private void Btn_branches_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_branches);


            grid_main.Children.Clear();
            grid_main.Children.Add(UC_branch.Instance);

            //UC_branch uc = new UC_branch();
            //grid_main.Children.Add(uc);
        }

        private void Btn_stores_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_stores);


            grid_main.Children.Clear();
            grid_main.Children.Add(UC_store.Instance);

            //UC_store uc = new UC_store();
            //grid_main.Children.Add(uc);
        }

        private void Btn_pos_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_pos);


            grid_main.Children.Clear();
            grid_main.Children.Add(UC_posAccounts.Instance);

            //UC_posAccounts uc = new UC_posAccounts();
            //grid_main.Children.Add(uc);
        }

        private void Btn_banks_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_banks);
            grid_main.Children.Clear();
            grid_main.Children.Add(UC_bank.Instance);

            //UC_bank uc = new UC_bank();
            //grid_main.Children.Add(uc);
        }

        private void Btn_cards_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_cards);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_card.Instance);

        }

        //private void Btn_shippingCompany_Click(object sender, RoutedEventArgs e)
        //{
        //    refreashBachgroundClick(btn_shippingCompany);
        //    grid_main.Children.Clear();
        //    grid_main.Children.Add(uc_shippingCompany.Instance);
        //}
    }
}

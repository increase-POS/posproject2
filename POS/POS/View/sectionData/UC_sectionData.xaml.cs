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
using POS.Classes;
using POS.View.sectionData;
using POS.View.windows;

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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
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

            btn_shippingCompany.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_shippingCompany.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }

        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void BTN_Customers_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                refreashBachgroundClick(btn_customers);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_Customer.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_suppliers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_suppliers);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_vendors.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                #region menu state
                string menuState = MainWindow.menuIsOpen;
                if (menuState.Equals("open"))
                    ex.IsExpanded = true;
                else
                    ex.IsExpanded = false;
                #endregion

                #region translate
                if (MainWindow.lang.Equals("en"))
                { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucSectionData.FlowDirection = FlowDirection.LeftToRight; }
                else
                { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucSectionData.FlowDirection = FlowDirection.RightToLeft; }
                translate();
                #endregion

                if (!stopPermission)
                    permission();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        public bool stopPermission;
        void permission()
        {
            bool loadWindow = false;
            if (!SectionData.isAdminPermision())
                foreach (Border border in FindControls.FindVisualChildren<Border>(this))
                {
                    if (border.Tag != null)
                        if (MainWindow.groupObject.HasPermission(border.Tag.ToString(), MainWindow.groupObjects))

                        {
                            border.Visibility = Visibility.Visible;
                            if (!loadWindow)
                            {
                                Button button = FindControls.FindVisualChildren<Button>(this).Where(x => x.Name == "btn_" + border.Tag).FirstOrDefault();
                                button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                loadWindow = true;
                            }
                        }
                        else border.Visibility = Visibility.Collapsed;
                }
            else
                Btn_suppliers_Click(btn_suppliers, null);
            stopPermission = true;
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
            btn_cards.Content = MainWindow.resourcemanager.GetString("trCard");
            btn_shippingCompany.Content = MainWindow.resourcemanager.GetString("trShippingCompanies");
        }


        private void Btn_users_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_users);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_users.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_branches_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_branches);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_branch.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_stores_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_stores);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_store.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_pos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_pos);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_posAccounts.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_banks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_banks);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_bank.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_cards_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_cards);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_card.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_shippingCompany_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_shippingCompany);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_shippingCompany.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private async void Ex_Expanded(object sender, RoutedEventArgs e)
        {
            try
            {
                int oId = await SectionData.getOpenValueId();
                SectionData.saveMenuState(oId);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async void Ex_Collapsed(object sender, RoutedEventArgs e)
        {
            try
            {
                int cId = await SectionData.getCloseValueId();
                SectionData.saveMenuState(cId);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

    }
}

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
            try
            {

                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private  void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           

            try
            {
                #region translate

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
                #endregion
                if(!stopPermission)
                permission();
                #region menu state
                string menuState = MainWindow.menuIsOpen;
                if (menuState.Equals("open"))
                    ex.IsExpanded = true;
                else
                    ex.IsExpanded = false;
                #endregion
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
            //await _loaded(sender);
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
                Btn_pos_Click(btn_posAccounting, null);
            stopPermission = true;
        }
        private void translate()
        {

            btn_posAccounting.Content = MainWindow.resourcemanager.GetString("trTransfers");
            btn_banksAccounting.Content = MainWindow.resourcemanager.GetString("trBanks");
            btn_payments.Content = MainWindow.resourcemanager.GetString("trPayments");
            btn_received.Content = MainWindow.resourcemanager.GetString("trReceived");
            btn_bonds.Content = MainWindow.resourcemanager.GetString("trBonds");
            btn_ordersAccounting.Content = MainWindow.resourcemanager.GetString("trOrders");
            btn_subscriptions.Content = MainWindow.resourcemanager.GetString("trSubscriptions");
            btn_accountsStatistic.Content = MainWindow.resourcemanager.GetString("trStatistic");

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
            try
            {

                refreashBachgroundClick(btn_posAccounting);


                grid_main.Children.Clear();
                grid_main.Children.Add(uc_posAccounts.Instance);
                //uc_posAccounts uc = new uc_posAccounts();
                //grid_main.Children.Add(uc);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_payments_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_payments);

                grid_main.Children.Clear();
                grid_main.Children.Add(uc_paymentsAccounts.Instance);
                //uc_paymentsAccounts uc = new uc_paymentsAccounts();
                //grid_main.Children.Add(uc);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_received_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_received);

                grid_main.Children.Clear();
                grid_main.Children.Add(uc_receivedAccounts.Instance);
                //uc_receivedAccounts uc = new uc_receivedAccounts();
                //grid_main.Children.Add(uc);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_bonds_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_bonds);

                grid_main.Children.Clear();
                grid_main.Children.Add(uc_bonds.Instance);
                //Button button = sender as Button;
                //MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_banks_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_banksAccounting);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_banksAccounts.Instance);
                //uc_banksAccounts uc = new uc_banksAccounts();
                //grid_main.Children.Add(uc);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_orders_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_ordersAccounting);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_orderAccounts.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_subscriptions_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_subscriptions);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_subscriptions.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_statistic_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Ex_Collapsed(object sender, RoutedEventArgs e)
        {
            try
            {
                int cId = await SectionData.getCloseValueId();
                await SectionData.saveMenuState(cId);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Ex_Expanded(object sender, RoutedEventArgs e)
        {
                try
                {
                    int oId = await SectionData.getOpenValueId();
                await SectionData.saveMenuState(oId);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}

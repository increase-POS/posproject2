using POS.View.purchases;
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

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for uc_reports.xaml
    /// </summary>
    public partial class uc_reports : UserControl
    {
        private static uc_reports _instance;
        public static uc_reports Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_reports();
                return _instance;
            }
        }

        private void translate()
        {
            btn_salesReports.Content = MainWindow.resourcemanager.GetString("trSales");
            btn_purchaseReport.Content = MainWindow.resourcemanager.GetString("trPurchases");
            btn_storageReports.Content = MainWindow.resourcemanager.GetString("trStorage");
            btn_accountsReports.Content = MainWindow.resourcemanager.GetString("trAccounts");
            btn_usersReports.Content = MainWindow.resourcemanager.GetString("trUsers");
        }

        public uc_reports()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucReports.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucReports.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            btn_salesReports_Click(null, null);
        }

        void refreashBackground()
        {

            btn_salesReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_salesReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_purchaseReport.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_purchaseReport.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_storageReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_storageReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_accountsReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_accountsReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_usersReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_usersReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_salesReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_salesReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_purchaseReport.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_purchaseReport.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_storageReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_storageReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_accountsReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_accountsReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_usersReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_usersReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

        }
        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_salesReports_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_salesReports);
            grid_main.Children.Clear();
         //   grid_main.Children.Add(uc_.Instance);
        }

        private void btn_purchaseReport_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_purchaseReport);
            grid_main.Children.Clear();
               grid_main.Children.Add(uc_purchaseReport.Instance);
        }

        private void btn_storageReports_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_storageReports);
            grid_main.Children.Clear();
            //   grid_main.Children.Add(uc_.Instance);
        }

        private void btn_accountsReports_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_accountsReports);
            grid_main.Children.Clear();
            //   grid_main.Children.Add(uc_.Instance);
        }

        private void btn_usersReports_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_usersReports);
            grid_main.Children.Clear();
            //   grid_main.Children.Add(uc_.Instance);
        }


    }
}

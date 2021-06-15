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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_purchases.xaml
    /// </summary>
    /// 
    
    public partial class uc_purchases : UserControl
    {
        
        private static uc_purchases _instance;
        public static uc_purchases Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_purchases();
                return _instance;
            }
        }
        public uc_purchases()
        {
            InitializeComponent();
        }
        private void translate()
        {
            btn_payInvoice.Content = MainWindow.resourcemanager.GetString("trInvoice");
            btn_statistic.Content = MainWindow.resourcemanager.GetString("trStatistic");
           

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucPurchases.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucPurchases.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            btn_payInvoice_Click(null, null);

        }
        void refreashBackground()
        {

            btn_payInvoice.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_payInvoice.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_statistic.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_statistic.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

        }

        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        private void btn_payInvoice_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_payInvoice);

            grid_main.Children.Clear();
            grid_main.Children.Add(uc_payInvoice.Instance);
            //uc_payInvoice uc = new uc_payInvoice();
            //grid_main.Children.Add(uc);
        }

        private void Btn_statistic_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_statistic);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_statistic.Instance);



        }


    }
}

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

       

           
            btn_pos.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_pos.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_payments.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_payments.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_banks.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_banks.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));


          

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
            uc_posAccounts uc = new uc_posAccounts();
            grid_main.Children.Add(uc);
        }
        private void Btn_payments_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Btn_banks_Click(object sender, RoutedEventArgs e)
        {

        }

       
     
        private void Btn_statistic_Click(object sender, RoutedEventArgs e)
        {

        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.Key.ToString());
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            var window = Window.GetWindow(this);
            window.KeyDown += HandleKeyPress;




            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucAccounts.FlowDirection = FlowDirection.LeftToRight;

            }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucAccounts.FlowDirection = FlowDirection.RightToLeft;

            }
            translate();
        }

        private void translate()
        {
          
            btn_pos.Content = MainWindow.resourcemanager.GetString("trPOS");
            btn_banks.Content = MainWindow.resourcemanager.GetString("trBanks");
        }

        
    }
}

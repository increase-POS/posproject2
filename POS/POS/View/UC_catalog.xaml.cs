using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for UC_catalog.xaml
    /// </summary>
    public partial class UC_catalog : UserControl
    {
        public UC_catalog()
        {
            InitializeComponent();
           
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Btn_categorie_Click(null, null);
        }

        private void Btn_categorie_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            uc_categorie uc = new uc_categorie();
            grid_main.Children.Add(uc);
        }


        private   void BTN_item_Click(object sender, RoutedEventArgs e)
        {
            grid_main.Children.Clear();
            UC_item uc = new UC_item();
            grid_main.Children.Add(uc);


        }

        
    }
}

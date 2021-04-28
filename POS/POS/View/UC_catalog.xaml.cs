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
    /// Interaction logic for UC_catalog.xaml
    /// </summary>
    public partial class UC_catalog : UserControl
    {
        public UC_catalog()
        {
            InitializeComponent();
           
        }
        private void translate()
        {
            btn_categories.Content = MainWindow.resourcemanager.GetString("trCategories");
            btn_properties.Content = MainWindow.resourcemanager.GetString("trProperties");
            btn_item.Content = MainWindow.resourcemanager.GetString("trItems");
            btn_units.Content = MainWindow.resourcemanager.GetString("trUnits");


        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Btn_categorie_Click(null, null);

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucCatalog.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucCatalog.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
        }

        void refreashBackground()
        {



            btn_units.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_units.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }

        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
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
            UC_item uc= new UC_item();
            grid_main.Children.Add(uc);


        }

        private void Btn_properties_Click(object sender, RoutedEventArgs e)
        { 
            grid_main.Children.Clear();
            UC_porperty uc = new UC_porperty();
            grid_main.Children.Add(uc);
        }

        private void Btn_units_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_units);
            grid_main.Children.Clear();
            UC_unit uc = new UC_unit();
            grid_main.Children.Add(uc);
        }

    }
}

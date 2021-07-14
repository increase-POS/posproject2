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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_catalog.xaml
    /// </summary>
    public partial class UC_catalog : UserControl
    {

        private static UC_catalog _instance;
        public static UC_catalog Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_catalog();
                return _instance;
            }
        }
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
            permission();
        }
        void permission()
        {
            foreach (Button button in FindControls.FindVisualChildren<Button>(this))
            {
                if (button.Tag != null)
                    if (MainWindow.groupObject.HasPermission(button.Tag.ToString(), MainWindow.groupObjects))
                        button.Visibility = Visibility.Visible;
                    else button.Visibility = Visibility.Collapsed;
            }
        }

        void refreashBackground()
        {
            btn_categories.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_categories.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_item.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_item.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_properties.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_properties.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));



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
            refreashBachgroundClick(btn_categories);

            grid_main.Children.Clear();
            uc_categorie uc = new uc_categorie();
            grid_main.Children.Add(uc);
        }


        private   void BTN_item_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_item);

            grid_main.Children.Clear();
            grid_main.Children.Add(UC_item.Instance);

            //UC_item uc = new UC_item();
            //grid_main.Children.Add(uc);


        }

        private void Btn_properties_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_properties);

            grid_main.Children.Clear();
            grid_main.Children.Add(UC_porperty.Instance);
            //UC_porperty uc = new UC_porperty();
            //grid_main.Children.Add(uc);
        }

        private void Btn_units_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_units);
            grid_main.Children.Clear();
            grid_main.Children.Add(UC_unit.Instance);
            //UC_unit uc = new UC_unit();
            //grid_main.Children.Add(uc);
        }

    }
}

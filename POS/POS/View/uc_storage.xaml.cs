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
    /// Interaction logic for uc_storage.xaml
    /// </summary>
    public partial class uc_storage : UserControl
    {
        public uc_storage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucStorage.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucStorage.FlowDirection = FlowDirection.RightToLeft;
            }

            Btn_locations_Click(null, null);
        }
        void refreashBackground()
        {

            btn_locations.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_locations.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_section.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_section.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_itemsImport.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_itemsImport.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_itemsExport.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_itemsExport.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }
        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        private void Btn_locations_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_locations);
            grid_main.Children.Clear();
            uc_locations uc = new uc_locations();
            grid_main.Children.Add(uc);
        }

        private void Btn_section_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_section);
            grid_main.Children.Clear();
            uc_section uc = new uc_section();
            grid_main.Children.Add(uc);
        }
        private void Btn_itemsImport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_itemsExport_Click(object sender, RoutedEventArgs e)
        {

        }

      
       
    }
}

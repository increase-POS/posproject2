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
    /// Interaction logic for UC_porperty.xaml
    /// </summary>
    public partial class UC_porperty : UserControl
    {
        public UC_porperty()
        {
            InitializeComponent();
        }

        private void Tb_propertyName_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_mainPropertyName.Text.Equals(""))
            {
                p_errorPropertyName.Visibility = Visibility.Visible;
                tt_errorPreoertyName.Content = MainWindow.resourcemanager.GetString("trEmptyMainPropNameToolTip");
                tb_mainPropertyName.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorPropertyName.Visibility = Visibility.Collapsed;
                tb_mainPropertyName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }
        private void Tb_propertyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_mainPropertyName.Text.Equals(""))
            {
                p_errorPropertyName.Visibility = Visibility.Visible;
                tt_errorPreoertyName.Content = MainWindow.resourcemanager.GetString("trEmptyMainPropNameToolTip");
                tb_mainPropertyName.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorPropertyName.Visibility = Visibility.Collapsed;
                tb_mainPropertyName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void translate()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectPropertyNameHint"));
            txt_mainProperty.Text = MainWindow.resourcemanager.GetString("trMainProperty");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mainPropertyName, MainWindow.resourcemanager.GetString("trMainPropertyHint"));
            txt_subProperties.Text = MainWindow.resourcemanager.GetString("trSubProperties");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_subPropertyName, MainWindow.resourcemanager.GetString("trSubPropertiesHint"));

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            btn_addSub.Content = MainWindow.resourcemanager.GetString("trAdd");

            dg_property.Columns[0].Header = MainWindow.resourcemanager.GetString("trMainProperty");
            dg_property.Columns[1].Header = MainWindow.resourcemanager.GetString("trSubProperties");

            dg_subProperty.Columns[0].Header = MainWindow.resourcemanager.GetString("trSubProperties");

        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucProperty.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucProperty.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
        }

        private void Dg_subProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Dg_property_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

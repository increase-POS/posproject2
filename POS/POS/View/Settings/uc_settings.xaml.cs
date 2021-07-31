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

namespace POS.View.Settings
{
    /// <summary>
    /// Interaction logic for uc_settings.xaml
    /// </summary>
    public partial class uc_settings : UserControl
    {
        private static uc_settings _instance;
        public static uc_settings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_settings();
                return _instance;
            }
        }
        public uc_settings()
        {
            InitializeComponent();
            btn_general_Click(null, null);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucSettings.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucSettings.FlowDirection = FlowDirection.RightToLeft; }
            translate();
            permission();
        }
        void permission()
        {
            if (!SectionData.isAdminPermision())
                foreach (Button button in FindControls.FindVisualChildren<Button>(this))
            {
                if (button.Tag != null)
                    if (MainWindow.groupObject.HasPermission(button.Tag.ToString(), MainWindow.groupObjects))
                        button.Visibility = Visibility.Visible;
                    else button.Visibility = Visibility.Collapsed;
            }
        }
        private void translate()
        {
            btn_general.Content = MainWindow.resourcemanager.GetString("trGeneral");
            btn_reportsSettings.Content = MainWindow.resourcemanager.GetString("trReports");
            btn_permissions.Content = MainWindow.resourcemanager.GetString("trPermission");

        }
        void refreashBackground()
        {
            btn_general.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_general.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_reportsSettings.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_reportsSettings.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_permissions.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_permissions.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_emails.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_emails.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            
        }

        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        private void btn_general_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_general);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_general.Instance);
        }

        private void btn_reports_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_reportsSettings);
            grid_main.Children.Clear();

        }

        private void btn_permission_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_permissions);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_permissions.Instance);
        }

        private void Btn_emails_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_emails);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_emailsSetting.Instance);
        }
    }
}

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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            #region menu state
            string menuState = MainWindow.menuIsOpen;
            if (menuState.Equals("open"))
                ex.IsExpanded = true;
            else
                ex.IsExpanded = false;
            #endregion

            #region translate
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.lang.Equals("en"))
                { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucSettings.FlowDirection = FlowDirection.LeftToRight; }
                else
                { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucSettings.FlowDirection = FlowDirection.RightToLeft; }
                translate();
            #endregion


                permission();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
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
                btn_general_Click(btn_general, null);
        }
        public void translate()
        {
            btn_general.Content = MainWindow.resourcemanager.GetString("trGeneral");
            btn_reportsSettings.Content = MainWindow.resourcemanager.GetString("trReports");
            btn_permissions.Content = MainWindow.resourcemanager.GetString("trPermission");
            btn_emails.Content = MainWindow.resourcemanager.GetString("trEmail");
            btn_emailTemplates.Content = MainWindow.resourcemanager.GetString("trEmailTemplates");

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

            btn_emailTemplates.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_emailTemplates.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

        }

        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        private void btn_general_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_general);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_general.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void btn_reports_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_reportsSettings);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_reportSetting.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void btn_permission_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_permissions);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_permissions.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_emails_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_emails);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_emailsSetting.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_emailTemplates_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                refreashBachgroundClick(btn_emailTemplates);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_emailTemplates.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async void Ex_Collapsed(object sender, RoutedEventArgs e)
        {
            int cId = await SectionData.getCloseValueId();
            SectionData.saveMenuState(cId);
        }

        private async void Ex_Expanded(object sender, RoutedEventArgs e)
        {
            int oId = await SectionData.getOpenValueId();
            SectionData.saveMenuState(oId);
        }
    }
}

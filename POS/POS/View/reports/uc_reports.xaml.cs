using POS.Classes;
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
            btn_purchaseReports.Content = MainWindow.resourcemanager.GetString("trPurchases");
            btn_storageReports.Content = MainWindow.resourcemanager.GetString("trStorage");
            btn_accountsReports.Content = MainWindow.resourcemanager.GetString("trAccounts");
            btn_usersReports.Content = MainWindow.resourcemanager.GetString("trUsers");
        }

        public uc_reports()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this );
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                #region menu state
                string menuState = MainWindow.menuIsOpen;
            if (menuState.Equals("open"))
                ex.IsExpanded = true;
            else
                ex.IsExpanded = false;
            #endregion

            #region translate
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
            #endregion

            btn_salesReports_Click(null, null);
                //permission();
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
            foreach (Button button in FindControls.FindVisualChildren<Button>(this))
            {
                if (button.Tag != null)
                    if (MainWindow.groupObject.HasPermission(button.Tag.ToString(), MainWindow.groupObjects))
                        button.Visibility = Visibility.Visible;
                    else button.Visibility = Visibility.Collapsed;
            }
        }

        public void refreashBackground()
        {

            btn_salesReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_salesReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_purchaseReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_purchaseReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_storageReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_storageReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_accountsReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_accountsReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_usersReports.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_usersReports.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

        }

      public  void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_salesReports_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_salesReports);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_saleReport.Instance);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void btn_purchaseReport_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    refreashBachgroundClick(btn_purchaseReports);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_purchaseReport.Instance);
                }
                catch (Exception ex)
                {
                    SectionData.ExceptionMessage(ex, this, sender);
                }
            }

        private void btn_storageReports_Click(object sender, RoutedEventArgs e)
        {
                    try
                    {
                        uc_storage uc = new uc_storage();
            refreashBachgroundClick(btn_storageReports);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc);
                    }
                    catch (Exception ex)
                    {
                        SectionData.ExceptionMessage(ex, this, sender);
                    }
                }

        private void btn_accountsReports_Click(object sender, RoutedEventArgs e)
        {
                        try
                        {
                            uc_accountant uc = new uc_accountant();
            refreashBachgroundClick(btn_accountsReports);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc);
                        }
                        catch (Exception ex)
                        {
                            SectionData.ExceptionMessage(ex, this, sender);
                        }
                    }

        private void btn_usersReports_Click(object sender, RoutedEventArgs e)
        {
                            try
                            {
                                refreashBachgroundClick(btn_usersReports);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_usersReport.Instance);
                            }
                            catch (Exception ex)
                            {
                                SectionData.ExceptionMessage(ex, this, sender);
                            }
                        }

        private async void Ex_Collapsed(object sender, RoutedEventArgs e)
        {
                                try
                                {
                                    int cId = await SectionData.getCloseValueId();
                await SectionData.saveMenuState(cId);
                                }
                                catch (Exception ex)
                                {
                                    SectionData.ExceptionMessage(ex, this, sender);
                                }
                            }

        private async void Ex_Expanded(object sender, RoutedEventArgs e)
        {
                                    try
                                    {
                                        int oId = await SectionData.getOpenValueId();
                await SectionData.saveMenuState(oId);
                                    }
                                    catch (Exception ex)
                                    {
                                        SectionData.ExceptionMessage(ex, this, sender);
                                    }
                                }
    }
}

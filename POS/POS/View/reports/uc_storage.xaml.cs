using POS.Classes;
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

namespace POS.View.reports
{
    public partial class uc_storage : UserControl
    {
        private static uc_storage _instance;
        public static uc_storage Instance
        {
            get
            {
                if (_instance == null) _instance = new uc_storage();
                return _instance;
            }
        }
        public uc_storage()
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

        private void Btn_stock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                uc_stock uc = new uc_stock();
                main.Children.Add(uc);
                    Button button = sender as Button;
                    MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 2);

                }
                sc_main.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_external_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    {
                uc_external uc = new uc_external();
                main.Children.Add(uc);
                    Button button = sender as Button;
                    MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 2);
                }
                sc_main.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_internal_Click(object sender, RoutedEventArgs e)
        {
                    try
                    {
                        {
                uc_internal uc = new uc_internal();
                main.Children.Add(uc);
                    Button button = sender as Button;
                    MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 2);
                }
            sc_main.Visibility = Visibility.Collapsed;
                    }
                    catch (Exception ex)
                    {
                        SectionData.ExceptionMessage(ex, this);
                    }
                }

        private void Btn_stocktaking_Click(object sender, RoutedEventArgs e)
        {
                        try
                        {
                            {
                uc_stocktaking uc = new uc_stocktaking();
                main.Children.Add(uc);
                    Button button = sender as Button;
                    MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 2);
                }
            sc_main.Visibility = Visibility.Collapsed;
                        }
                        catch (Exception ex)
                        {
                            SectionData.ExceptionMessage(ex, this);
                        }
                    }

        private void Btn_destroied_Click(object sender, RoutedEventArgs e)
        {
                            try
                            {
                                {
                uc_destroied uc = new uc_destroied();
                main.Children.Add(uc);
                    Button button = sender as Button;
                    MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 2);
                }
            sc_main.Visibility = Visibility.Collapsed;
                            }
                            catch (Exception ex)
                            {
                                SectionData.ExceptionMessage(ex, this);
                            }
                        }

     

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}

﻿using POS.Classes;
using POS.View.catalog;
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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void translate()
        {
            btn_categories.Content = MainWindow.resourcemanager.GetString("trCategories");
            btn_properties.Content = MainWindow.resourcemanager.GetString("trProperties");
            btn_item.Content = MainWindow.resourcemanager.GetString("trItems");
            btn_units.Content = MainWindow.resourcemanager.GetString("trUnits");
            btn_storageCost.Content = MainWindow.resourcemanager.GetString("trStorageCost");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
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
                #endregion

                if (!stopPermission)
                    permission();


            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        public bool stopPermission;
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
                Btn_categorie_Click(btn_categories, null);
            stopPermission = true;
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

            btn_storageCost.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_storageCost.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }

        void refreashBachgroundClick(Button btn)
        {

            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));

        }


        private void Btn_categorie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_categories);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_categorie.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {

                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void BTN_item_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_item);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_item.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_properties_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_properties);

                grid_main.Children.Clear();
                grid_main.Children.Add(UC_porperty.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {

                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_units_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_units);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_unit.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_storageCost_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_storageCost);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_storageCost.Instance);
                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {

                SectionData.ExceptionMessage(ex, this);
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

                SectionData.ExceptionMessage(ex, this);
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

                SectionData.ExceptionMessage(ex, this);
            }
        }
    }
}

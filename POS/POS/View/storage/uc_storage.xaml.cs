﻿using POS.Classes;
using POS.View.storage;
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
        private static uc_storage _instance;
        public static uc_storage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_storage();
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
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void translate()
        {
            btn_locations.Content = MainWindow.resourcemanager.GetString("trLocation");
            btn_section.Content = MainWindow.resourcemanager.GetString("trSection");
            btn_reciptOfInvoice.Content = MainWindow.resourcemanager.GetString("trInvoice");
            btn_itemsStorage.Content = MainWindow.resourcemanager.GetString("trStorage");
            btn_importExport.Content = MainWindow.resourcemanager.GetString("trMovements");
            btn_itemsDestroy.Content = MainWindow.resourcemanager.GetString("trDestructive");
            btn_shortage.Content = MainWindow.resourcemanager.GetString("trShortage");
            btn_inventory.Content = MainWindow.resourcemanager.GetString("trStocktaking");
            btn_storageStatistic.Content = MainWindow.resourcemanager.GetString("trStatistic");
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
                if (sender != null)
                    SectionData.StartAwait(grid_main);

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
                translate();

                #endregion
                if(!stopPermission)
                permission();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        public bool stopPermission;
        void permission()
        {
            bool loadWindow = false;
            if (!SectionData.isAdminPermision())
                foreach (Button button in FindControls.FindVisualChildren<Button>(this))
                {
                    if (button.Tag != null)
                        if (MainWindow.groupObject.HasPermission(button.Tag.ToString(), MainWindow.groupObjects))

                        {
                            button.Visibility = Visibility.Visible;
                            if (!loadWindow)
                            {
                                button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                loadWindow = true;
                            }
                        }
                        else button.Visibility = Visibility.Collapsed;
                }
            else
                Btn_locations_Click(btn_locations, null);
            stopPermission = true;
        }
        void refreashBackground()
        {

            btn_locations.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_locations.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_section.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_section.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_reciptOfInvoice.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_reciptOfInvoice.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_itemsStorage.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_itemsStorage.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));


            //btn_itemsImport.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            //btn_itemsImport.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_importExport.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_importExport.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));


            btn_itemsDestroy.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_itemsDestroy.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

            btn_shortage.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_shortage.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));


            btn_inventory.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686D"));
            btn_inventory.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        }
        void refreashBachgroundClick(Button btn)
        {
            refreashBackground();
            btn.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        private void Btn_locations_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_locations);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_locations.Instance);

                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_section_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_section);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_section.Instance);

                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_receiptOfPurchaseInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_reciptOfInvoice);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_receiptOfPurchaseInvoice.Instance);

                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_itemsStorage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_itemsStorage);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_itemsStorage.Instance);

                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_itemsExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_importExport);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_itemsExport.Instance);

                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_itemsDestroy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_itemsDestroy);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_itemsDestroy.Instance);

                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_shortage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_shortage);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_itemsShortage.Instance);

                Button button = sender as Button;
                MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_inventory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreashBachgroundClick(btn_inventory);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_inventory.Instance);

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

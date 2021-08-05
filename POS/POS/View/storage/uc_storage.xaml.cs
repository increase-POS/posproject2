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
            InitializeComponent();
        }
        private void translate()
        {
            btn_locations.Content = MainWindow.resourcemanager.GetString("trLocation");
            btn_section.Content = MainWindow.resourcemanager.GetString("trSection");
            btn_reciptOfInvoice.Content = MainWindow.resourcemanager.GetString("trInvoice");
            btn_itemsStorage.Content = MainWindow.resourcemanager.GetString("trStorage");
            btn_importExport.Content = MainWindow.resourcemanager.GetString("trMovements");
            btn_itemsDestroy.Content = MainWindow.resourcemanager.GetString("trDestructive");
            btn_inventory.Content = MainWindow.resourcemanager.GetString("trStocktaking");
            btn_storageStatistic.Content = MainWindow.resourcemanager.GetString("trStatistic");
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
            translate();
            permission();
        }
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
            refreashBachgroundClick(btn_locations);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_locations.Instance);
            //uc_locations uc = new uc_locations();
            //grid_main.Children.Add(uc);

            Button button = sender as Button;
            MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
        }
        private void Btn_section_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_section);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_section.Instance);
            //uc_section uc = new uc_section();
            //grid_main.Children.Add(uc);

            Button button = sender as Button;
            MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
        }
        private void Btn_receiptOfPurchaseInvoice_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_reciptOfInvoice);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_receiptOfPurchaseInvoice.Instance);
            //uc_receiptOfPurchaseInvoice uc = new uc_receiptOfPurchaseInvoice();
            //grid_main.Children.Add(uc);

            Button button = sender as Button;
            MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
        }
        private void Btn_itemsStorage_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_itemsStorage);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_itemsStorage.Instance);
            //uc_itemsStorage uc = new uc_itemsStorage();
            //grid_main.Children.Add(uc);

            Button button = sender as Button;
            MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
        }
        //private void Btn_itemsImport_Click(object sender, RoutedEventArgs e)
        //{
        //    //refreashBachgroundClick(btn_itemsImport);
        //    grid_main.Children.Clear();
        //    grid_main.Children.Add(uc_itemsImport.Instance);
        //    //uc_itemsImport uc = new uc_itemsImport();
        //    //grid_main.Children.Add(uc);
        //}
        private void Btn_itemsExport_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_importExport);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_itemsExport.Instance);
            //uc_itemsExport uc = new uc_itemsExport();
            //grid_main.Children.Add(uc);

            Button button = sender as Button;
            MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
        }
        private void Btn_itemsDestroy_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_itemsDestroy);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_itemsDestroy.Instance);
            //uc_itemsDestroy uc = new uc_itemsDestroy();
            //grid_main.Children.Add(uc);

            Button button = sender as Button;
            MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
        }
        private void Btn_shortage_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_shortage);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_itemsShortage.Instance);

            Button button = sender as Button;
            MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
        }
        private void Btn_inventory_Click(object sender, RoutedEventArgs e)
        {
            refreashBachgroundClick(btn_inventory);
            grid_main.Children.Clear();
            grid_main.Children.Add(uc_inventory.Instance);

            Button button = sender as Button;
            MainWindow.mainWindow.initializationMainTrack(button.Tag.ToString(), 1);
        }

        
    }
}

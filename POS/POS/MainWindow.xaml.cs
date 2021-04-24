﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using POS.View;

namespace POS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static ResourceManager resourcemanager;
        bool menuState = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        void FN_tooltipVisibility(Button btn)
        {
            ToolTip T = btn.ToolTip as ToolTip;
            if (T.Visibility == Visibility.Visible)
                T.Visibility = Visibility.Hidden;
            else T.Visibility = Visibility.Visible;
        }

        private void BTN_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTN_Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void translate()
        {
            tt_menu.Content = resourcemanager.GetString("trMenu");
            tt_home.Content = resourcemanager.GetString("trHome");
            txt_home.Text = resourcemanager.GetString("trHome");
            tt_catalog.Content = resourcemanager.GetString("trCatalog");
            txt_catalog.Text = resourcemanager.GetString("trCatalog");
            tt_storage.Content = resourcemanager.GetString("trStorage");
            txt_storage.Text = resourcemanager.GetString("trStorage");
            tt_purchases.Content = resourcemanager.GetString("trPurchases");
            txt_purchases.Text = resourcemanager.GetString("trPurchases");
            tt_sales.Content = resourcemanager.GetString("trSales");
            txt_sales.Text = resourcemanager.GetString("trSales");
            tt_accounting.Content = resourcemanager.GetString("trAccounting");
            txt_accounting.Text = resourcemanager.GetString("trAccounting");
            tt_reports.Content = resourcemanager.GetString("trReports");
            txt_reports.Text = resourcemanager.GetString("trReports");
            tt_sectiondata.Content = resourcemanager.GetString("trSectionData");
            txt_sectiondata.Text = resourcemanager.GetString("trSectionData");
            tt_settings.Content = resourcemanager.GetString("trSettings");
            txt_settings.Text = resourcemanager.GetString("trSettings");
        }

        private void BTN_Menu_Click(object sender, RoutedEventArgs e)
        {
            if (!menuState)
            {
                Storyboard sb = this.FindResource("Storyboard1") as Storyboard;
                sb.Begin();
                menuState = true;


            }
            else
            {
                Storyboard sb = this.FindResource("Storyboard2") as Storyboard;
                sb.Begin();
                menuState = false;
            }

            #region tooltipVisibility
            FN_tooltipVisibility(BTN_menu);
            FN_tooltipVisibility(BTN_home);
            FN_tooltipVisibility(BTN_sectionData);
            #endregion


        }

        private void BTN_Home_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_SectionData_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_SectionData uc = new UC_SectionData();
            GRID_Main.Children.Add(uc);

        }

        private void BTN_catalog_Click(object sender, RoutedEventArgs e)
        {
            GRID_Main.Children.Clear();
            UC_catalog uc = new UC_catalog();
            GRID_Main.Children.Add(uc);
        }

        public static string lang = "en";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (lang.Equals("en"))
            { resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_mainWindow.FlowDirection = FlowDirection.LeftToRight; }
            else
            { resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_mainWindow.FlowDirection = FlowDirection.RightToLeft; }
            translate();

        }
    }
}

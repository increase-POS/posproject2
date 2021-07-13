﻿using POS.Classes;
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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_invoicesList.xaml
    /// </summary>
    public partial class wd_invoicesList : Window
    {
        public wd_invoicesList()
        {
            InitializeComponent();
        }

        public bool isActive;
        List<Invoice> allInvoicesSource = new List<Invoice>();
        public List<Invoice> selectedInvoicesSource = new List<Invoice>();

        List<Invoice> allInvoices = new List<Invoice>();
        public List<Invoice> selectedInvoices = new List<Invoice>();

        Invoice userModel = new Invoice();
        Invoice user = new Invoice();
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            //MessageBox.Show(sectionId.ToString());
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_invoices.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_invoices.FlowDirection = FlowDirection.RightToLeft;
            }
            tb_moneyIcon.Text = MainWindow.Currency;
            translat();
            /*
            allInvoicesSource = await userModel.GetInvoicesAsync();
            var query = allInvoicesSource.Where(i => i.isActive == 1);
            selectedInvoicesSource = query.ToList();

            allInvoices.AddRange(allInvoicesSource);
            selectedInvoices.AddRange(selectedInvoicesSource);

            //remove selected invoices from all invoices
            foreach (var i in selectedInvoices)
            {
                allInvoices.Remove(i);
            }
           

            lst_allInvoices.ItemsSource = allInvoices;
            lst_allInvoices.SelectedValuePath = "fullName";
            lst_allInvoices.DisplayMemberPath = "userId";

            lst_selectedInvoices.ItemsSource = selectedInvoices;
            lst_selectedInvoices.SelectedValuePath = "fullName";
            lst_selectedInvoices.DisplayMemberPath = "userId";
            */
        }

        private void translat()
        {
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_searchitems, MainWindow.resourcemanager.GetString("trSearchHint"));

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

            //lst_allInvoices.Columns[0].Header = MainWindow.resourcemanager.GetString("trInvoice");
            //lst_selectedInvoices.Columns[0].Header = MainWindow.resourcemanager.GetString("trSelectedInvoices");

            //txt_user.Text = MainWindow.resourcemanager.GetString("trInvoice");
            //txt_selectedInvoices.Text = MainWindow.resourcemanager.GetString("trSelectedInvoices");
            //txt_HeaderTitle.Text = MainWindow.resourcemanager.GetString("trSection");
            //tt_searchZ.Content = MainWindow.resourcemanager.GetString("trZ");

            tt_selectAllItem.Content = MainWindow.resourcemanager.GetString("trSelectAllItems");
            tt_unselectAllItem.Content = MainWindow.resourcemanager.GetString("trUnSelectAllItems");
            tt_selectItem.Content = MainWindow.resourcemanager.GetString("trSelectOneItem");
            tt_unselectItem.Content = MainWindow.resourcemanager.GetString("trUnSelectOneItem");

        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            isActive = true;
            this.Close();
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            this.Close();
        }

        private void Lst_allInvoices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Btn_selectedInvoice_Click(null, null);

        }

        private void Lst_selectedInvoices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_unSelectedInvoice_Click(null, null);

        }


        private async void Btn_selectedAll_Click(object sender, RoutedEventArgs e)
        {//select all
            int x = allInvoices.Count;
            for (int i = 0; i < x; i++)
            {
                //MessageBox.Show(i.ToString());
                lst_allInvoices.SelectedIndex = 0;
                Btn_selectedInvoice_Click(null, null);
            }
        }
        private void Btn_selectedInvoice_Click(object sender, RoutedEventArgs e)
        {//select one
            user = lst_allInvoices.SelectedItem as Invoice;
            if (user != null)
            {
                allInvoices.Remove(user);

                selectedInvoices.Add(user);

                lst_allInvoices.ItemsSource = allInvoices;
                lst_selectedInvoices.ItemsSource = selectedInvoices;

                lst_allInvoices.Items.Refresh();
                lst_selectedInvoices.Items.Refresh();
            }

        }


        private void Btn_unSelectedInvoice_Click(object sender, RoutedEventArgs e)
        {//unselect one
            user = lst_selectedInvoices.SelectedItem as Invoice;
            if (user != null)
            {
                selectedInvoices.Remove(user);

                allInvoices.Add(user);

                lst_allInvoices.ItemsSource = allInvoices;
                lst_selectedInvoices.ItemsSource = selectedInvoices;

                lst_allInvoices.Items.Refresh();
                lst_selectedInvoices.Items.Refresh();
            }
        }

        private async void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {//unselect all
            int x = selectedInvoices.Count;
            for (int i = 0; i < x; i++)
            {
                lst_selectedInvoices.SelectedIndex = 0;
                Btn_unSelectedInvoice_Click(null, null);
            }

        }

        private void Txb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lst_allInvoices.ItemsSource = allInvoices.Where(x => (x.fullName.ToLower().Contains(txb_search.Text.ToLower())) && x.isActive == 1);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }
    }
}

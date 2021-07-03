﻿using POS.Classes;
using POS.View.purchases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for winControlPanel.xaml
    /// </summary>
    public partial class winControlPanel : Window
    {
        public ObservableCollection<BoolStringClass> TheList { get; set; }
        List<string> headers;
        uc_statistic uc = new uc_statistic();
        List<string> newHeader = new List<string>();

        public winControlPanel(List<string> _headers)
        {
            InitializeComponent();
            headers = _headers;
            TheList = new ObservableCollection<BoolStringClass>();
        }

        public class BoolStringClass
        {
            public string TheText { get; set; }
            public bool IsSelected { get; set; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < headers.Count; i++)
            {
                if (uc.dgInvoice.Columns[i].Visibility == Visibility.Visible)
                {
                    TheList.Add(new BoolStringClass { IsSelected = true, TheText = headers[i] });
                }
                else
                {
                    TheList.Add(new BoolStringClass { IsSelected = false, TheText = headers[i] });
                }
             

            }
            this.DataContext = this;
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
        public List<string> newHeaderResult
        {
            get { return newHeader; }
        }
        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < headers.Count; i++)
            {
                if (TheList[i].IsSelected == true)
                {
                    newHeader.Add(TheList[i].TheText);
                }
                else
                {
                    newHeader.Add("");
                }
            }
            

            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}

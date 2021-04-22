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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_pos.xaml
    /// </summary>
    public partial class UC_pos : UserControl
    {
        public int posId;
        //Pos pos = new Pos();
        public UC_pos() 
         {
            InitializeComponent();
           // List<Pos> poss = new List<Pos>();

            

            for (int i = 1; i < 50; i++)
            {
                //poss.Add(new Pos()
                //{
                //    Id = i,
                //    name = "branch name " + i,
                //    code = "branch code" + i,
                //    balance  = "balance " + i,
                //    branchName = "branch name "+ i

                //}); ; ;
            }

            //dg_pos.ItemsSource = poss;
        }
        
        private void DG_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Pos pos = new Pos();
            if (dg_pos.SelectedIndex != -1)
            {
                //pos = dg_pos.SelectedItem as Pos;
                //this.DataContext = pos;
                //if (pos != null)
                //{
                //    if (pos.Id != 0)
                //    {
                //        posId = pos.Id;
                //    }
                //}
            }
        }

        private void Tb_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_code.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_code.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorCode.Visibility = Visibility.Collapsed;
                tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_code_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_code.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_code.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorCode.Visibility = Visibility.Collapsed;
                tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_balance_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_balance.Text.Equals(""))
            {
                p_errorBalance.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_balance.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorBalance.Visibility = Visibility.Collapsed;
                tb_balance.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_balance_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_balance.Text.Equals(""))
            {
                p_errorBalance.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_balance.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorBalance.Visibility = Visibility.Collapsed;
                tb_balance.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Cb_branchId_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (cb_branchId.Text.Equals(""))
            {
                p_errorSelectBranch.Visibility = Visibility.Visible;
                tt_errorSelectBranch.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                cb_branchId.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorSelectBranch.Visibility = Visibility.Collapsed;
                cb_branchId.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }
    }
}

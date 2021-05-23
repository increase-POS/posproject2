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

namespace POS.View.accounts
{
    /// <summary>
    /// Interaction logic for uc_posAccounts.xaml
    /// </summary>
    public partial class uc_posAccounts : UserControl
    {
        public uc_posAccounts()
        {
            InitializeComponent();
        }

        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            #region Style Date
            /////////////////////////////////////////////////////////////
            dp_startSearchDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_startSearchDate.Template.FindName("PART_TextBox", dp_startSearchDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_startSearchDate.Background;
                    textBox1.BorderThickness = dp_startSearchDate.BorderThickness;
                }
            };
            /////////////////////////////////////////////////////////////
            dp_endSearchDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_endSearchDate.Template.FindName("PART_TextBox", dp_endSearchDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_endSearchDate.Background;
                    textBox1.BorderThickness = dp_endSearchDate.BorderThickness;
                }
            };
            /////////////////////////////////////////////////////////////
            #endregion
        }

        private void Dg_posAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_Isdone_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_Isdone_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}

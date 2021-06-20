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

namespace POS.View.Settings
{
    /// <summary>
    /// Interaction logic for uc_permissions.xaml
    /// </summary>
    public partial class uc_permissions : UserControl
    {

        private static uc_permissions _instance;
        public static uc_permissions Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_permissions();
                return _instance;
            }
        }
        static private object _Sender;

        public uc_permissions()
        {
            InitializeComponent();
        }

        private void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dg_permissions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dg_groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {

        }
        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            if (name == "TextBox")
            {
               
            }
            else if (name == "ComboBox")
            {
                

            }
        }
        private void Tb_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Sender = sender;
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_addGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_updateGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_deleteGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_addPermission_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_updatePermission_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_deletePermission_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (path_canAdd.Visibility == Visibility.Visible)
            { path_canAdd.Visibility    = Visibility.Collapsed;
                path_cantAdd.Visibility = Visibility.Visible;
            }
            else { path_canAdd.Visibility = Visibility.Visible;
                path_cantAdd.Visibility   = Visibility.Collapsed;
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (path_canUpdate.Visibility == Visibility.Visible)
            {
                path_canUpdate.Visibility = Visibility.Collapsed;
                path_cantUpdate.Visibility = Visibility.Visible;
            }
            else
            {
                path_canUpdate.Visibility  = Visibility.Visible;
                path_cantUpdate.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (path_canDelete.Visibility == Visibility.Visible)
            {
                path_canDelete.Visibility  = Visibility.Collapsed;
                path_cantDelete.Visibility = Visibility.Visible;
            }
            else
            {
                path_canDelete.Visibility   = Visibility.Visible;
                path_cantDelete.Visibility = Visibility.Collapsed;
            }
        }
    }
}

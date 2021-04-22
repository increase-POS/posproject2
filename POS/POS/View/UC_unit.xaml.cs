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
    /// Interaction logic for UC_unit.xaml
    /// </summary>
    public partial class UC_unit : UserControl
    {
        public int unitId;
        //Unit unit = new Unit();
        public UC_unit()
        {
            InitializeComponent();
            //List<Unit> units = new List<Unit>();



            for (int i = 1; i < 50; i++)
            {
                //units.Add(new Unit()
                //{
                //    Id = i,
                //    name = "unit name " + i,
                //    smallestUnitId = i + 1,
                //    isSmallest = true 
                //});
            }

          //  dg_unit.ItemsSource = units;
        }

        private void DG_unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Unit unit = new Unit();
            //if (dg_unit.SelectedIndex != -1)
            //{
            //    unit = dg_unit.SelectedItem as Unit;
            //    this.DataContext = unit;

            //    if (unit != null)
            //    {
            //        if (unit.Id != 0)
            //        {
            //            unitId = unit.Id;
            //        }
            //    }
            //}
        }

        private void Tbtn_isSmallest_Checked(object sender, RoutedEventArgs e)
        {
            cb_smallestUnitId.Visibility = Visibility.Collapsed;
        }

        private void Tbtn_isSmallest_unckecked(object sender, RoutedEventArgs e)
        {
            cb_smallestUnitId.Visibility = Visibility.Visible;
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
    }
}

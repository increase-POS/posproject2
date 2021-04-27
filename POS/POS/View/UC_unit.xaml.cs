using Newtonsoft.Json;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    /// Interaction logic for UC_unit.xaml
    /// </summary>
    public partial class UC_unit : UserControl
    {
        public int UnitId;

        Unit unitModel = new Unit();

        private int smallestUnitId = 0 ;

        int IsSmallest = 0;

        public UC_unit()
        {
            InitializeComponent();
        }

        private void DG_unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
           
            Unit unit = new Unit();
            if (dg_unit.SelectedIndex != -1)
            {
                unit = dg_unit.SelectedItem as Unit;
                this.DataContext = unit;
            }
            if (unit != null)
            {
                if (unit.unitId != 0)
                {
                    UnitId = unit.unitId;
                }

                //if (unit.isSmallest == 0)
                //    tbtn_isSmallest.IsChecked = false;
                //else
                //    tbtn_isSmallest.IsChecked = true;

                //select combo item
                //for (int i = 0; i < ids.Count; i++)
                //    if (ids[i] == unit.smallestId)
                //    { cb_smallestUnitId.SelectedIndex = i;  break; }
                //cb_smallestUnitId.SelectedIndex = ids.IndexOf(unit.smallestId);

            }
        }

        List<int>    ids = new List<int>();
        List<string> names = new List<string>();
        private void fillSmallestUnits()
        {
            Unit unit = new Unit();
            for (int i = 0; i < dg_unit.Items.Count ; i++)
            {
                unit = dg_unit.Items[i] as Unit;
                ids.Add(unit.unitId);
                names.Add(unit.name);
            }
            cb_smallestUnitId.ItemsSource = names;
        }

        private void Tbtn_isSmallest_Checked(object sender, RoutedEventArgs e)
        {
            cb_smallestUnitId.Visibility = Visibility.Collapsed;
            IsSmallest = 1;
        }

        private void Tbtn_isSmallest_unckecked(object sender, RoutedEventArgs e)
        {
            cb_smallestUnitId.Visibility = Visibility.Visible;
            IsSmallest = 0;
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
        private void translate()
        {
            txt_unit.Text = MainWindow.resourcemanager.GetString("trUnit");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelestUnitNameHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trUnitNameHint"));
            tb_isSmallest.Text = MainWindow.resourcemanager.GetString("trIsSmallestHint");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_smallestUnitId, MainWindow.resourcemanager.GetString("trSelectSmallestUnitHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            dg_unit.Columns[0].Header = MainWindow.resourcemanager.GetString("trUnitName");
            //dg_unit.Columns[1].Header = MainWindow.resourcemanager.GetString("trIsSmallest");
            dg_unit.Columns[1].Header = MainWindow.resourcemanager.GetString("trSmallestUnit");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            tb_name.Text = "";
            cb_smallestUnitId.Text = "";
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucUnit.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucUnit.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

            var units = await unitModel.GetUnitsAsync();
            dg_unit.ItemsSource = units;

            //fillSmallestUnits();

            //dg_unit.Items[0]..SetValue("unit2");
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            Unit unit = new Unit
            {
                //unitId
                name         = tb_name.Text,
                //isSmallest   = IsSmallest,
                isSmallest   = 0,
                //smallestId = smallestUnitId ,
                smallestId   = 0,
                createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 1 ,
                updateUserId = 1 ,
                parentid     = 0 //?????????????????
            };

            await unitModel.saveUnit(unit);

            var units = await unitModel.GetUnitsAsync();
            dg_unit.ItemsSource = units;

            //fillSmallestUnits();

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            await unitModel.deleteUnit(UnitId);

            var units = await unitModel.GetUnitsAsync();
            dg_unit.ItemsSource = units;

            fillSmallestUnits();

            //clear textBoxs
            UnitId = 0;
            tb_name.Clear();
            tbtn_isSmallest.IsChecked = false;
            cb_smallestUnitId.SelectedIndex = -1;
            //parentid = 0
        }

        private void Cb_smallestUnitId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //smallestUnitId = ids[cb_smallestUnitId.SelectedIndex];
        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            Unit unit = new Unit
            {
                unitId = UnitId,
                name = tb_name.Text,
                //isSmallest   = IsSmallest,
                isSmallest = 0,
                //smallestId = smallestUnitId ,
                smallestId = 0,
                createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 1,
                updateUserId = 1,
                parentid = 0 //?????????????????
            };

             await unitModel.saveUnit(unit);

            MessageBox.Show(UnitId.ToString());

            var units = await unitModel.GetUnitsAsync();
            dg_unit.ItemsSource = units;

            //fillSmallestUnits();


        }
    }
}

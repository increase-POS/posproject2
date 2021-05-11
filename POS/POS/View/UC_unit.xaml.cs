using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_unit.xaml
    /// </summary>
    public partial class UC_unit : UserControl
    {
        public int UnitId;

        Unit unitModel = new Unit();
        Unit unit = new Unit();

        IEnumerable<Unit> unitsQuery;
        IEnumerable<Unit> units;
        byte tgl_unitState;
        int ParentId = 0;
        string searchText = "";
       
        private int smallestUnitId = 0;

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
                if (unit.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else
                {
                    if (unit.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                    else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
                }
            }
        }

        List<int> ids = new List<int>();
        List<string> names = new List<string>();
        private void fillSmallestUnits()
        {
            Unit unit = new Unit();
            for (int i = 0; i < dg_unit.Items.Count; i++)
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
           // MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelestUnitNameHint"));
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
           // cb_smallestUnitId.Text = "";
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

           
            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
            }

            Unit unit = new Unit
            {
                //unitId
                name = tb_name.Text,
                //isSmallest   = IsSmallest,
                isSmallest = 1,
                //smallestId = smallestUnitId ,
                smallestId = 1,
               // createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
              //  updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = MainWindow.userID,
                updateUserId = MainWindow.userID,
                parentId = ParentId, //?????????????????
                isActive = 1,
            };

            await unitModel.saveUnit(unit);

            var units = await unitModel.GetUnitsAsync();
            unitsQuery = units.Where(s => s.isActive == Convert.ToInt32(tgl_unitIsActive.IsChecked));

            dg_unit.ItemsSource = units;
            MessageBox.Show(units.Count.ToString());
            //fillSmallestUnits();

        }
        private async void activate()
        {//activate
            unit.isActive = 1;

            string s = await unitModel.saveUnit(unit);

            if (s.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

        }
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            //////await unitModel.deleteUnit(UnitId);

            //////var units = await unitModel.GetUnitsAsync();
            //////dg_unit.ItemsSource = units;

            //////fillSmallestUnits();

            ////////clear textBoxs
            //////UnitId = 0;
            //////tb_name.Clear();
            //////tbtn_isSmallest.IsChecked = false;
            //////cb_smallestUnitId.SelectedIndex = -1;
            ////////parentid = 0
            ///
            //delete
            if ((!unit.canDelete) && (unit.isActive == 0))
                activate();
            else
            {
                string popupContent = "";
                if (unit.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                if ((!unit.canDelete) && (unit.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                bool b = await unitModel.deleteUnit(unit.unitId, MainWindow.userID.Value, unit.canDelete);

                if (b) SectionData.popUpResponse("", popupContent);
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            }

            units = await unitModel.GetUnitsAsync();
            unitsQuery = units.Where(s => s.isActive == Convert.ToInt32(tgl_unitIsActive.IsChecked));
            dg_unit.ItemsSource = unitsQuery;
         //   fillSmallestUnits();
            //clear textBoxs
            Btn_clear_Click(sender, e);
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
                createUserId = MainWindow.userID,
                updateUserId = MainWindow.userID,
                parentId = 0 //?????????????????
            };

            await unitModel.saveUnit(unit);

            MessageBox.Show(UnitId.ToString());

            var units = await unitModel.GetUnitsAsync();
          //  unitsQuery = units.Where(s => s.isActive == Convert.ToInt32(tgl_unitIsActive.IsChecked));

            dg_unit.ItemsSource = units;

            //fillSmallestUnits();


        }

        void RefreshUnitView()
        {
            dg_unit.ItemsSource = unitsQuery;
            txt_Count.Text = unitsQuery.Count().ToString();
            ////cb_area.SelectedIndex = 0;
            ////cb_areaPhone.SelectedIndex = 0;
            ////cb_areaPhoneLocal.SelectedIndex = 0;
            ////cb_branch.SelectedIndex = 0;
        }

        private async void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            //search
            var bc = new BrushConverter();

            p_errorName.Visibility = Visibility.Collapsed;
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (units is null)
                await RefreshUnitsList();
            searchText = tb_search.Text;
            unitsQuery = units.Where(s => (s.name.Contains(searchText)))
          //  && s.isActive == tgl_unitState)
                ;
  
            
            RefreshUnitView();
        }
        async Task<IEnumerable<Unit>> RefreshUnitsList()
        {
            units = await unitModel.GetUnitsAsync();
            return units;
        }
        private async  void tgl_unitIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (units is null)
                 await RefreshUnitsList();
            tgl_unitState = 1;
            tb_search_TextChanged(null, null);
        }

        private async void tgl_unitIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (units is null)
                await RefreshUnitsList();
            tgl_unitState = 0;
            tb_search_TextChanged(null, null);
        }

        private void Btn_unitExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });
        }
        void FN_ExportToExcel()
        {
            var QueryExcel = unitsQuery.AsEnumerable().Select(x => new
            {
                
                Name = x.name,
                IsSmallest = x.isSmallest,

            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trIsSmallest");


            ExportToExcel.Export(DTForExcel);

        }
    }
}

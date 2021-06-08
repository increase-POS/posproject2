using POS.Classes;
using netoaster;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading.Tasks;

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
        List<Unit> units = new List<Unit>();
        private static UC_unit _instance;
        public static UC_unit Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_unit();
                return _instance;
            }
        }
        
        public UC_unit()
        {
            InitializeComponent();
            if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1440)
            {
                txt_deleteButton.Visibility = Visibility.Visible;
                txt_addButton.Visibility = Visibility.Visible;
                txt_updateButton.Visibility = Visibility.Visible;
                txt_add_Icon.Visibility = Visibility.Visible;
                txt_update_Icon.Visibility = Visibility.Visible;
                txt_delete_Icon.Visibility = Visibility.Visible;
            }
            else if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1360)
            {
                txt_add_Icon.Visibility = Visibility.Collapsed;
                txt_update_Icon.Visibility = Visibility.Collapsed;
                txt_delete_Icon.Visibility = Visibility.Collapsed;
                txt_deleteButton.Visibility = Visibility.Visible;
                txt_addButton.Visibility = Visibility.Visible;
                txt_updateButton.Visibility = Visibility.Visible;

            }
            else
            {
                txt_deleteButton.Visibility = Visibility.Collapsed;
                txt_addButton.Visibility = Visibility.Collapsed;
                txt_updateButton.Visibility = Visibility.Collapsed;
                txt_add_Icon.Visibility = Visibility.Visible;
                txt_update_Icon.Visibility = Visibility.Visible;
                txt_delete_Icon.Visibility = Visibility.Visible;

            }
        }

        private void DG_unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_unit.SelectedIndex != -1)
            {
                unit = dg_unit.SelectedItem as Unit;
                this.DataContext = unit;
            }
            if (unit != null)
            {
                if (unit.canDelete)
                {
                    txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                    txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                }

                else
                {
                    if (unit.isActive == 0)
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trActive");
                        txt_delete_Icon.Kind =
                         MaterialDesignThemes.Wpf.PackIconKind.Check;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trActive");

                    }
                    else
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trInActive");
                        txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Cancel;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trInActive");

                    }

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
            //cb_smallestUnitId.ItemsSource = names;
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
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trUnitNameHint"));
            //tb_isSmallest.Text = MainWindow.resourcemanager.GetString("trIsSmallestHint");

            //MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_smallestUnitId, MainWindow.resourcemanager.GetString("trSelectSmallestUnitHint"));
            txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");
            dg_unit.Columns[0].Header = MainWindow.resourcemanager.GetString("trUnitName");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            tb_name.Clear();
            tb_notes.Clear();

            unit = new Unit();
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

            refreshUnitsGrid();

        }
        async void refreshUnitsGrid()
        {
            units = await unitModel.GetUnitsAsync();
            dg_unit.ItemsSource = units;
        }
        private void validateEmptyValues()
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            //validate values
            validateEmptyValues();
           
            if (!tb_name.Text.Equals(""))
            {
                // check if new unit doesn't match old units
                var unitObj = units.Find( x => x.name == tb_name.Text);
                if (unitObj is null)
                {
                    unit = new Unit
                    {
                        name = tb_name.Text,
                        notes = tb_notes.Text,
                        createUserId = MainWindow.userID,
                        updateUserId = MainWindow.userID,
                        isActive = 1,
                    };
                    Boolean res = await unitModel.saveUnit(unit);
                    if (res) 
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    refreshUnitsGrid();

                    Btn_clear_Click(null, null);
                }
            }
        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if ((!unit.canDelete) && (unit.isActive == 0))
               await activate();
            else
            {
                string popupContent = "";
                if (unit.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                if ((!unit.canDelete) && (unit.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");
                int userId = (int)MainWindow.userID;
                Boolean res = await unitModel.deleteUnit(unit.unitId, userId, unit.canDelete);

                if (res) 
                    Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                else 
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
            refreshUnitsGrid();

            Btn_clear_Click(sender,e);
        }
        private async Task activate()
        {//activate

            unit.isActive = 1;

            Boolean s = await unitModel.saveUnit(unit);

            if (s) 
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else 
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

        }

        private void Cb_smallestUnitId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //smallestUnitId = ids[cb_smallestUnitId.SelectedIndex];
        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
         //validate values
            validateEmptyValues();

            if (!tb_name.Text.Equals(""))
            {
                // check if new unit doesn't match old units
                var unitObj = units.Find(x => x.name == tb_name.Text);
                if (unitObj is null || unitObj.name == unit.name)
                {
                    unit.name = tb_name.Text;
                    unit.notes = tb_notes.Text;

                    Boolean res = await unitModel.saveUnit(unit);
                    if (res)
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                    else 
                        Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    refreshUnitsGrid();
                }
                else
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorDuplicateUnitNameToolTip"), animation: ToasterAnimation.FadeIn);
                }

            }
        }

        private void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            refreshUnitsGrid();
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

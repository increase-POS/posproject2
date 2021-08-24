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
using POS.View.windows;
using System.Linq;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Threading;
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
        //List<Unit> units = new List<Unit>();
        IEnumerable<Unit> unitsQuery;
        IEnumerable<Unit> units;
        string basicsPermission = "units_basics";
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
            try
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
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this);
            }
        }
        string searchText = "";
        byte tgl_unitState;
        BrushConverter bc = new BrushConverter();
        private void DG_unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
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
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
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
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

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
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
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
            try
            {
                tb_name.Clear();
                tb_notes.Clear();
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                unit = new Unit();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                 if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }

                translate();
                 
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void validateEmptyValues()
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            try
            {

                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                    //validate values
                    validateEmptyValues();

                    if (!tb_name.Text.Equals(""))
                    {
                        // check if new unit doesn't match old units
                        var unitObj = units.ToList().Find(x => x.name == tb_name.Text);
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

                            await RefreshUnitsList();
                            Tb_search_TextChanged(null, null);

                            Btn_clear_Click(null, null);
                        }
                        else
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUnitExist"), animation: ToasterAnimation.FadeIn);
                            p_errorName.Visibility = Visibility.Visible;
                            tt_errorName.Content = MainWindow.resourcemanager.GetString("trPopUnitExist");
                            tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete") || SectionData.isAdminPermision())
                {
                    if ((!unit.canDelete) && (unit.isActive == 0))
                    {
                        #region
                        Window.GetWindow(this).Opacity = 0.2;
                        wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                        w.ShowDialog();
                        Window.GetWindow(this).Opacity = 1;
                        #endregion
                        if (w.isOk)
                            await activate();

                    }
                    else
                    {
                        #region
                        Window.GetWindow(this).Opacity = 0.2;
                        wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                        if (unit.canDelete)
                            w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                        if (!unit.canDelete)
                            w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                        w.ShowDialog();
                        Window.GetWindow(this).Opacity = 1;
                        #endregion
                        if (w.isOk)
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
                    }
                    await RefreshUnitsList();
                    Tb_search_TextChanged(null, null);

                    Btn_clear_Click(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
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

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update") || SectionData.isAdminPermision())
                {
                    //validate values
                    validateEmptyValues();

                    if (!tb_name.Text.Equals(""))
                    {
                        // check if new unit doesn't match old units
                        var unitObj = units.ToList().Find(x => x.name == tb_name.Text);
                        if (unitObj is null || unitObj.name == unit.name)
                        {
                            unit.name = tb_name.Text;
                            unit.notes = tb_notes.Text;

                            Boolean res = await unitModel.saveUnit(unit);
                            if (res)
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                            else
                                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                            await RefreshUnitsList();
                            Tb_search_TextChanged(null, null);
                        }
                        else
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorDuplicateUnitNameToolTip"), animation: ToasterAnimation.FadeIn);
                        }

                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        void refreshUnitsGrid()
        {

            dg_unit.ItemsSource = unitsQuery;
            txt_count.Text = unitsQuery.Count().ToString();

        }
        async Task<IEnumerable<Unit>> RefreshUnitsList()
        {
            units = await unitModel.GetUnitsAsync();
            return units;
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search

            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (units is null)
                    await RefreshUnitsList();
                searchText = tb_search.Text.ToLower();
                unitsQuery = units.Where(s => s.name.ToLower().Contains(searchText) && s.isActive == tgl_unitState);
                refreshUnitsGrid();

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    RefreshUnitsList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private async void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (units is null)
                    await RefreshUnitsList();
                tgl_unitState = 1;
                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private async void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (units is null)
                    await RefreshUnitsList();
                tgl_unitState = 0;
                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    this.Dispatcher.Invoke(() =>
                {
                    Thread t1 = new Thread(FN_ExportToExcel);
                    t1.SetApartmentState(ApartmentState.STA);
                    t1.Start();
                });
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        void FN_ExportToExcel()
        {

            var QueryExcel = unitsQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                Notes = x.notes
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

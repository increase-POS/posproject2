using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using POS.View.windows;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_locations.xaml
    /// </summary>
    public partial class uc_locations : UserControl
    {
        string basicsPermission = "locations_basics";
        string addRangePermission = "locations_addRange";
        private static uc_locations _instance;
        public static uc_locations Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_locations();
                return _instance;
            }
        }
        public uc_locations()
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

        Location locationModel = new Location();
        Location location = new Location();
        IEnumerable<Location> locationsQuery;
        IEnumerable<Location> locations;
        byte tgl_locationState;
        string searchText = "";
        BrushConverter bc = new BrushConverter();
       
        private void translate()
        {
            
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_x, MainWindow.resourcemanager.GetString("trXHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_y, MainWindow.resourcemanager.GetString("trYHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_z, MainWindow.resourcemanager.GetString("trZHint"));

            btn_refresh.ToolTip = MainWindow.resourcemanager.GetString("trRefresh");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");
            txt_location.Text = MainWindow.resourcemanager.GetString("trLocation");
            txt_active.Text = MainWindow.resourcemanager.GetString("trActive");
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_addRange.Content = MainWindow.resourcemanager.GetString("trAddRange");
            txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            tt_x.Content = MainWindow.resourcemanager.GetString("trX");
            tt_y.Content = MainWindow.resourcemanager.GetString("trY");
            tt_z.Content = MainWindow.resourcemanager.GetString("trZ");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

            dg_location.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_location.Columns[1].Header = MainWindow.resourcemanager.GetString("trSection");
            dg_location.Columns[2].Header = MainWindow.resourcemanager.GetString("trNote");
        }

        private  void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucLocation.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucLocation.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

            //btn_addRange.IsEnabled = false;

            Keyboard.Focus(tb_x);

            SectionData.clearValidate(tb_x, p_errorX);

            this.Dispatcher.Invoke(() =>
            {
                Tb_search_TextChanged(null, null);
            });

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_x.Clear();
            tb_y.Clear();
            tb_z.Clear();
            tb_notes.Clear();

            p_errorX.Visibility = Visibility.Collapsed;
            p_errorY.Visibility = Visibility.Collapsed;
            p_errorZ.Visibility = Visibility.Collapsed;

            //btn_addRange.IsEnabled = false;

            tb_x.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_y.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_z.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }
        bool validate(Location location = null)
        {
            //chk empty x
            SectionData.validateEmptyTextBox(tb_x, p_errorX, tt_errorX, "trEmptyError");
            //chk empty x
            SectionData.validateEmptyTextBox(tb_y, p_errorY, tt_errorY, "trEmptyError");
            //chk empty x
            SectionData.validateEmptyTextBox(tb_z, p_errorZ, tt_errorZ, "trEmptyError");

            if ((!tb_x.Text.Equals("")) && (!tb_y.Text.Equals("")) && (!tb_z.Text.Equals("")))
                return true;
            else return false;
        }
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add"))
            {
                location.locationId = 0;
            if (validate(location))
            {
                if (locations.Where(x => x.name == location.name && x.branchId == MainWindow.branchID).Count() == 0)
                {
                    location.x = tb_x.Text;
                    location.y = tb_y.Text;
                    location.z = tb_z.Text;
                    location.note = tb_notes.Text;
                    location.createUserId = MainWindow.userID;
                    location.updateUserId = MainWindow.userID;
                    location.isActive = 1;
                    location.sectionId = null;
                    location.branchId = MainWindow.branchID;

                    string s = await locationModel.saveLocation(location);

                    if (!s.Equals("-1"))
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                        Btn_clear_Click(null, null);
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    await RefreshLocationsList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trDublicateLocation"), animation: ToasterAnimation.FadeIn);
            }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update"))
                {
                    if (validate(location))
            {
                location.x=  tb_x.Text;
                location.y = tb_y.Text;
                location.z = tb_z.Text;
                location.note = tb_notes.Text;
                location.updateUserId = MainWindow.userID;

                string s = await locationModel.saveLocation(location);

                if (!s.Equals("-1")) 
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                else 
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                await RefreshLocationsList();
                Tb_search_TextChanged(null, null);


            }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
            }
            private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
                    if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete"))
                    {
                        if (location.locationId != 0)
            {
                if ((!location.canDelete) && (location.isActive == 0))
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                activate();
                }
                else
                {

                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    if (location.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                    if (!location.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                    {
                        string popupContent = "";
                        if (location.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                        if ((!location.canDelete) && (location.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                        bool b = await locationModel.Delete(location.locationId, MainWindow.userID.Value, location.canDelete);

                        if (b) //SectionData.popUpResponse("", popupContent);
                            Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                        else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }
                await RefreshLocationsList();
                Tb_search_TextChanged(null, null);
            }
            //clear textBoxs
            Btn_clear_Click(sender, e);
                    }
                    else
                        Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                }
                private async void activate()
        {//activate
            location.isActive = 1;

            string s = await locationModel.saveLocation(location);

            if (s.Equals("Location Is Updated Successfully")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshLocationsList();
            Tb_search_TextChanged(null, null);
        }
        private void Dg_location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            p_errorX.Visibility = Visibility.Collapsed;
            p_errorY.Visibility = Visibility.Collapsed;
            p_errorX.Visibility = Visibility.Collapsed;

            tb_x.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_y.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_z.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_location.SelectedIndex != -1)
            {
                location = dg_location.SelectedItem as Location;
                this.DataContext = location;
            }

            if (location != null)
            {
                //btn_addRange.IsEnabled = true;

                #region delete
                if (location.canDelete)
                {
                    txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                    txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                }

                else
                {
                    if (location.isActive == 0)
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
                #endregion 
            }

        }
        private void validationControl_LostFocus(object sender, RoutedEventArgs e)
        {
            if((sender as Control).Name == "tb_x")
            //chk empty name
            SectionData.validateEmptyTextBox(tb_x, p_errorX, tt_errorX, "trEmptyNameToolTip");
           else if((sender as Control).Name == "tb_y")
                //chk empty mobile
                SectionData.validateEmptyTextBox(tb_y, p_errorY, tt_errorY, "trEmptyMobileToolTip");
            else if ((sender as Control).Name == "tb_z")
                //chk empty phone
                SectionData.validateEmptyTextBox(tb_z, p_errorZ, tt_errorZ, "trEmptyPhoneToolTip");
        }
        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Name == "tb_x")
                //chk empty x
                SectionData.validateEmptyTextBox(tb_x, p_errorX, tt_errorX, "trEmptyNameToolTip");
            else if ((sender as TextBox).Name == "tb_y")
                //chk empty y
                SectionData.validateEmptyTextBox(tb_y, p_errorY, tt_errorY, "trEmptyMobileToolTip");
            else if ((sender as TextBox).Name == "tb_z")
                //chk empty z
                SectionData.validateEmptyTextBox(tb_z, p_errorZ, tt_errorZ, "trEmptyPhoneToolTip");
        }
        void handleSpace_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private async void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {
            if (locations is null)
                await RefreshLocationsList();
            tgl_locationState = 1;
            Tb_search_TextChanged(null, null);
        }
        private async void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (locations is null)
                await RefreshLocationsList();
            tgl_locationState = 0;
            Tb_search_TextChanged(null, null);
        }
        async Task<IEnumerable<Location>> RefreshLocationsList()
        {
            MainWindow.mainWindow.StartAwait();
            locations = await locationModel.Get();
            locations = locations.Where(x => x.branchId  == MainWindow.branchID && x.isFreeZone != 1);
            MainWindow.mainWindow.EndAwait();
            return locations;
        }
        void RefreshLocationView()
        {
            dg_location.ItemsSource = locationsQuery;
            txt_count.Text = locationsQuery.Count().ToString();
        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show"))
            {
                if (locations is null)
                await RefreshLocationsList();
            searchText = tb_search.Text.ToLower();
            locationsQuery = locations.Where(s => (s.x.ToLower().Contains(searchText) ||
            s.y.ToLower().Contains(searchText) ||
            s.z.ToLower().Contains(searchText)
            ) && s.isActive == tgl_locationState && s.isFreeZone != 1);
            RefreshLocationView();

            }
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show"))
            {
                RefreshLocationsList();
                Tb_search_TextChanged(null, null);

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report"))
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
        }

        void FN_ExportToExcel()
        {
            
            var QueryExcel = locationsQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                Notes = x.note
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);
        }

        private void Btn_addRange_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(addRangePermission, MainWindow.groupObjects, "one"))
            {
                Window.GetWindow(this).Opacity = 0.2;
            wd_locationAddRange w = new wd_locationAddRange();
            w.ShowDialog();
            Window.GetWindow(this).Opacity = 1;
            Btn_refresh_Click(null, null);
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

    }
}

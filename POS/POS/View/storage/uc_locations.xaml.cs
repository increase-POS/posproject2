using netoaster;
using POS.Classes;
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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_locations.xaml
    /// </summary>
    public partial class uc_locations : UserControl
    {
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
            /*
            txt_location.Text = MainWindow.resourcemanager.GetString("trLocation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trLocationNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_accNumber, MainWindow.resourcemanager.GetString("trAccNumberHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_area, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            txt_moreInformation.Text = MainWindow.resourcemanager.GetString("trAnotherInfomation");
          
            dg_location.Columns[0].Header = MainWindow.resourcemanager.GetString("trLocationName");
            dg_location.Columns[1].Header = MainWindow.resourcemanager.GetString("trAccNumber");
            dg_location.Columns[2].Header = MainWindow.resourcemanager.GetString("trAddress");
            dg_location.Columns[3].Header = MainWindow.resourcemanager.GetString("trMobile");


            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_accNum.Content = MainWindow.resourcemanager.GetString("trAccNumber");
            tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
            tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
            tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            */
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
        }

        private  void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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

            Keyboard.Focus(tb_x);

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

            tb_x.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_y.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_z.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }

        bool validate(Location location = null)
        {
            
            //chk empty name
            SectionData.validateEmptyTextBox(tb_x, p_errorX, tt_errorX, "trEmptyNameToolTip");
            //chk empty mobile
            SectionData.validateEmptyTextBox(tb_y, p_errorY, tt_errorY, "trEmptyMobileToolTip");
            //chk empty phone
            SectionData.validateEmptyTextBox(tb_z, p_errorZ, tt_errorZ, "trEmptyPhoneToolTip");

            if ((!tb_x.Text.Equals("")) && (!tb_y.Text.Equals("")) && (!tb_z.Text.Equals("")))
                return true;
            else return false;
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            location.locationId = 0;
            if (validate(location))
            {
                location.x = tb_x.Text;
                location.y = tb_y.Text;
                location.z = tb_z.Text;
                location.note = tb_notes.Text;
                location.createUserId = MainWindow.userID;
                location.updateUserId = MainWindow.userID;
                location.isActive = 1;

                string s = await locationModel.saveLocation(location);

                if (s.Equals("Location Is Added Successfully")) 
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                await RefreshLocationsList();
                Tb_search_TextChanged(null, null);
            }
        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
           
            if (validate(location))
            {
                location.x=  tb_x.Text;
                location.y = tb_y.Text;
                location.z = tb_x.Text;
                location.note = tb_notes.Text;
                location.updateUserId = MainWindow.userID;

                string s = await locationModel.saveLocation(location);

                if (s.Equals("Location Is Updated Successfully")) 
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                else 
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                await RefreshLocationsList();
                Tb_search_TextChanged(null, null);


            }

        }
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if (location.locationId != 0)
            {
                if ((!location.canDelete) && (location.isActive == 0))
                    activate();
                else
                {
                    string popupContent = "";
                    if (location.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                    if ((!location.canDelete) && (location.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                    bool b = await locationModel.Delete(location.locationId, MainWindow.userID.Value, location.canDelete);

                    if (b) //SectionData.popUpResponse("", popupContent);
                        Toaster.ShowWarning(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                    else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                }
                await RefreshLocationsList();
                Tb_search_TextChanged(null, null);
            }
            //clear textBoxs
            Btn_clear_Click(sender, e);
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
        {
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

                #region delete
                if (location.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else
                {
                    if (location.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                    else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
                }
                #endregion 
            }

        }
        private void validationTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            validate();
        }

        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            validate();
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
            locations = await locationModel.Get();
            return locations;
        }
        void RefreshLocationView()
        {
            dg_location.ItemsSource = locationsQuery;
            txt_count.Text = locationsQuery.Count().ToString();
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search

            if (locations is null)
                await RefreshLocationsList();
            searchText = tb_search.Text;
            locationsQuery = locations.Where(s => (s.x.Contains(searchText) ||
            s.y.Contains(searchText) ||
            s.z.Contains(searchText)
            ) && s.isActive == tgl_locationState);
            RefreshLocationView();
        }
     
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshLocationsList();
            Tb_search_TextChanged(null, null);
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
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
            
            var QueryExcel = locationsQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                AccNumber = x.x,
                Mobile = x.y,
                Phone = x.z,
                //Address = x.sectionName,
                Notes = x.note
            });
            var DTForExcel = QueryExcel.ToDataTable();

            /*
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trAccNum");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trMobile");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trPhone");
            DTForExcel.Columns[5].Caption = MainWindow.resourcemanager.GetString("trAddress");
            DTForExcel.Columns[5].Caption = MainWindow.resourcemanager.GetString("trNote");
            */

            ExportToExcel.Export(DTForExcel);
        }


        
      
     


    }
}

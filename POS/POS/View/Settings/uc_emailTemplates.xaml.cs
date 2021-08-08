using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for uc_emailTemplates.xaml
    /// </summary>
    public partial class uc_emailTemplates : UserControl
    {

        string savePermission = "emailTemplates_save";
        private static uc_emailTemplates _instance;
        public static uc_emailTemplates Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_emailTemplates();
                return _instance;
            }
        }

        public uc_emailTemplates()
        {
            InitializeComponent();
            
        }

        SetValues setValuesModel = new SetValues();
        SetValues setValues = new SetValues();
        IEnumerable<SetValues> setValuessQuery;
        IEnumerable<SetValues> setValuess;
        byte tgl_setValuesState;
        string searchText = "";
        BrushConverter bc = new BrushConverter();

        private void translate()
        {

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));

            btn_refresh.ToolTip = MainWindow.resourcemanager.GetString("trRefresh");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");



            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");


            dg_setValues.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucSetValues.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucSetValues.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

            //btn_addRange.IsEnabled = false;

            Keyboard.Focus(tb_title);

            SectionData.clearValidate(tb_title, p_errorTitle);

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
            //tb_x.Clear();
            //tb_y.Clear();
            //tb_z.Clear();
            //tb_notes.Clear();

            //p_errorX.Visibility = Visibility.Collapsed;
            //p_errorY.Visibility = Visibility.Collapsed;
            //p_errorZ.Visibility = Visibility.Collapsed;

            ////btn_addRange.IsEnabled = false;

            //tb_x.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            //tb_y.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            //tb_z.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }
        //bool validate(SetValues setValues = null)
        //{

            ////chk empty z
            //SectionData.validateEmptyTextBox(tb_z, p_errorZ, tt_errorZ, "trEmptyError");

            //if ((!tb_z.Text.Equals("")) && (!tb_z.Text.Equals("")) && (!tb_z.Text.Equals("")))
            //    return true;
            //else return false;
        //}
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//update

            //if (MainWindow.groupObject.HasPermissionAction(savePermission, MainWindow.groupObjects, "one"))
            //{

            //write here Mr.Naji

            /////


            //}
            //else
            //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

        }
        private void Dg_setValues_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            //p_errorZ.Visibility = Visibility.Collapsed;
            //p_errorZ.Visibility = Visibility.Collapsed;
            //p_errorZ.Visibility = Visibility.Collapsed;

            //tb_z.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            //tb_z.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            //tb_z.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_setValues.SelectedIndex != -1)
            {
                setValues = dg_setValues.SelectedItem as SetValues;
                this.DataContext = setValues;
            }

            if (setValues != null)
            {
                //btn_addRange.IsEnabled = true;


            }

        }
        private void validationControl_LostFocus(object sender, RoutedEventArgs e)
        {
            //if ((sender as Control).Name == "tb_x")
            //    //chk empty name
            //    SectionData.validateEmptyTextBox(tb_x, p_errorX, tt_errorX, "trEmptyNameToolTip");
            //else if ((sender as Control).Name == "tb_y")
            //    //chk empty mobile
            //    SectionData.validateEmptyTextBox(tb_y, p_errorY, tt_errorY, "trEmptyMobileToolTip");
            //else if ((sender as Control).Name == "tb_z")
            //    //chk empty phone
            //    SectionData.validateEmptyTextBox(tb_z, p_errorZ, tt_errorZ, "trEmptyPhoneToolTip");
        }
        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if ((sender as TextBox).Name == "tb_x")
            //    //chk empty x
            //    SectionData.validateEmptyTextBox(tb_x, p_errorX, tt_errorX, "trEmptyNameToolTip");
            //else if ((sender as TextBox).Name == "tb_y")
            //    //chk empty y
            //    SectionData.validateEmptyTextBox(tb_y, p_errorY, tt_errorY, "trEmptyMobileToolTip");
            //else if ((sender as TextBox).Name == "tb_z")
            //    //chk empty z
            //    SectionData.validateEmptyTextBox(tb_z, p_errorZ, tt_errorZ, "trEmptyPhoneToolTip");
        }
        void handleSpace_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private async void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {
            if (setValuess is null)
                await RefreshSetValuessList();
            tgl_setValuesState = 1;
            Tb_search_TextChanged(null, null);
        }
        private async void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (setValuess is null)
                await RefreshSetValuessList();
            tgl_setValuesState = 0;
            Tb_search_TextChanged(null, null);
        }
        async Task<IEnumerable<SetValues>> RefreshSetValuessList()
        {
            MainWindow.mainWindow.StartAwait();
            //setValuess = await setValuesModel.Get();
            MainWindow.mainWindow.EndAwait();
            return setValuess;
        }
        void RefreshSetValuesView()
        {
            dg_setValues.ItemsSource = setValuessQuery;
            //txt_count.Text = setValuessQuery.Count().ToString();
        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            //if (setValuess is null)
            //    await RefreshSetValuessList();
            //searchText = tb_search.Text.ToLower();
            //setValuessQuery = setValuess.Where(s =>
            //s.z.ToLower().Contains(searchText)
            //);
            //RefreshSetValuesView();

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshSetValuessList();
            Tb_search_TextChanged(null, null);

        }


     

    }
}

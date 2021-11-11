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
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        SetValues setValuesModel = new SetValues();
        SetValues setValues = new SetValues();
        IEnumerable<SetValues> setValuessQuery;
        IEnumerable<SetValues> setValuess;

        SettingCls setModel = new SettingCls();
        SettingCls sett = new SettingCls();
        IEnumerable<SettingCls> setQuery;


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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);
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

                //btn_addRange.IsEnabled = false;


                SectionData.clearValidate(tb_title, p_errorTitle);

                setQuery = await setModel.GetByNotes("emailtemp");

                dg_setValues.ItemsSource = setQuery;

                    Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_main);
                Keyboard.Focus(tb_title);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }



        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//update
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(savePermission, MainWindow.groupObjects, "one"))
                {

                    //write here Mr.Naji

                    /////
                   int msg = 0;
                    setValues = setValuessQuery.Where(x => x.notes == "title").FirstOrDefault();
                    setValues.value = tb_title.Text;
                    msg += await setValuesModel.SaveValueByNotes(setValues);
                    //

                    setValues = setValuessQuery.Where(x => x.notes == "text1").FirstOrDefault();
                    setValues.value = tb_text1.Text;

                    msg += await setValuesModel.SaveValueByNotes(setValues);
                    setValues = setValuessQuery.Where(x => x.notes == "text2").FirstOrDefault();
                    setValues.value = tb_text2.Text;
                    msg += await setValuesModel.SaveValueByNotes(setValues);
                    setValues = setValuessQuery.Where(x => x.notes == "link1text").FirstOrDefault();
                    setValues.value = tb_link1text.Text;
                    msg += await setValuesModel.SaveValueByNotes(setValues);
                    setValues = setValuessQuery.Where(x => x.notes == "link2text").FirstOrDefault();
                    setValues.value = tb_link2text.Text;
                    msg += await setValuesModel.SaveValueByNotes(setValues);
                    setValues = setValuessQuery.Where(x => x.notes == "link3text").FirstOrDefault();
                    setValues.value = tb_link3text.Text;
                    msg += await setValuesModel.SaveValueByNotes(setValues);
                    setValues = setValuessQuery.Where(x => x.notes == "link1url").FirstOrDefault();
                    setValues.value = tb_link1url.Text;
                    msg += await setValuesModel.SaveValueByNotes(setValues);
                    setValues = setValuessQuery.Where(x => x.notes == "link2url").FirstOrDefault();
                    setValues.value = tb_link2url.Text;
                    msg += await setValuesModel.SaveValueByNotes(setValues);
                    setValues = setValuessQuery.Where(x => x.notes == "link3url").FirstOrDefault();
                    setValues.value = tb_link3url.Text;
                    msg += await setValuesModel.SaveValueByNotes(setValues);

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
                SectionData.ExceptionMessage(ex, this);
            }

        }
        private async void Dg_setValues_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                if (dg_setValues.SelectedIndex != -1)
                {
                    if (dg_setValues.SelectedIndex != -1)
                    {
                        sett = dg_setValues.SelectedItem as SettingCls;
                        setValuessQuery = await setValuesModel.GetBySetName(sett.name);
                        tb_title.Text = setValuessQuery.Where(x => x.notes == "title").FirstOrDefault() is null ? ""
                        : setValuessQuery.Where(x => x.notes == "title").FirstOrDefault().value.ToString();
                        tb_text1.Text = setValuessQuery.Where(x => x.notes == "text1").FirstOrDefault() is null ? ""
                           : setValuessQuery.Where(x => x.notes == "text1").FirstOrDefault().value.ToString();
                        tb_text2.Text = setValuessQuery.Where(x => x.notes == "text2").FirstOrDefault() is null ? ""
                        : setValuessQuery.Where(x => x.notes == "text2").FirstOrDefault().value.ToString();
                        tb_link1text.Text = setValuessQuery.Where(x => x.notes == "link1text").FirstOrDefault() is null ? ""
                        : setValuessQuery.Where(x => x.notes == "link1text").FirstOrDefault().value.ToString();

                        tb_link2text.Text = setValuessQuery.Where(x => x.notes == "link2text").FirstOrDefault() is null ? ""
                         : setValuessQuery.Where(x => x.notes == "link2text").FirstOrDefault().value.ToString();
                        tb_link3text.Text = setValuessQuery.Where(x => x.notes == "link3text").FirstOrDefault() is null ? ""
                        : setValuessQuery.Where(x => x.notes == "link3text").FirstOrDefault().value.ToString();


                        tb_link1url.Text = setValuessQuery.Where(x => x.notes == "link1url").FirstOrDefault() is null ? ""
                             : setValuessQuery.Where(x => x.notes == "link1url").FirstOrDefault().value.ToString();
                        tb_link2url.Text = setValuessQuery.Where(x => x.notes == "link2url").FirstOrDefault() is null ? ""
                               : setValuessQuery.Where(x => x.notes == "link2url").FirstOrDefault().value.ToString();

                        tb_link3url.Text = setValuessQuery.Where(x => x.notes == "link3url").FirstOrDefault() is null ? ""
                               : setValuessQuery.Where(x => x.notes == "link3url").FirstOrDefault().value.ToString();


                        this.DataContext = setValues;
                    }

                }

                if (setValues != null)
                {
                    //btn_addRange.IsEnabled = true;


                }

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }

        }
        private void validationControl_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {    //if ((sender as Control).Name == "tb_x")
                 //    //chk empty name
                 //    SectionData.validateEmptyTextBox(tb_x, p_errorX, tt_errorX, "trEmptyNameToolTip");
                 //else if ((sender as Control).Name == "tb_y")
                 //    //chk empty mobile
                 //    SectionData.validateEmptyTextBox(tb_y, p_errorY, tt_errorY, "trEmptyMobileToolTip");
                 //else if ((sender as Control).Name == "tb_z")
                 //    //chk empty phone
                 //    SectionData.validateEmptyTextBox(tb_z, p_errorZ, tt_errorZ, "trEmptyPhoneToolTip");
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {   //if ((sender as TextBox).Name == "tb_x")
                //    //chk empty x
                //    SectionData.validateEmptyTextBox(tb_x, p_errorX, tt_errorX, "trEmptyNameToolTip");
                //else if ((sender as TextBox).Name == "tb_y")
                //    //chk empty y
                //    SectionData.validateEmptyTextBox(tb_y, p_errorY, tt_errorY, "trEmptyMobileToolTip");
                //else if ((sender as TextBox).Name == "tb_z")
                //    //chk empty z
                //    SectionData.validateEmptyTextBox(tb_z, p_errorZ, tt_errorZ, "trEmptyPhoneToolTip");
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void handleSpace_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                SectionData.InputJustNumber(ref textBox);
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private   void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (setValuess is null)
                      RefreshSetValuessList();
                tgl_setValuesState = 1;
                Tb_search_TextChanged(null, null);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }

        }
        private   void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (setValuess is null)
                      RefreshSetValuessList();
                tgl_setValuesState = 0;
                Tb_search_TextChanged(null, null);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }

        }
          IEnumerable<SetValues>  RefreshSetValuessList()
        {
            //setValuess = await setValuesModel.Get();
            return setValuess;
        }
        void RefreshSetValuesView()
        {
            dg_setValues.ItemsSource = setValuessQuery;
            //txt_count.Text = setValuessQuery.Count().ToString();
        }

        private   void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                 






                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                RefreshSetValuessList();
                Tb_search_TextChanged(null, null);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            tb_title.Text = 
                tb_text1.Text =
                tb_text2.Text =
                tb_link1text.Text =
                tb_link2text.Text =
                tb_link3text.Text =
                tb_link1url.Text =
                tb_link2url.Text =
                tb_link3url.Text =  "";
            this.DataContext = new SetValues(); 
        }
    }
}

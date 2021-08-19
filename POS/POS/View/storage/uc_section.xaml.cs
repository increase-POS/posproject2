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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using POS.View.windows;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_section.xaml
    /// </summary>
    public partial class uc_section : UserControl
    {
        string basicsPermission = "section_basics";
        string selectLocationPermission = "section_selectLocation";
        private static uc_section _instance;
        public static uc_section Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_section();
                return _instance;
            }
        }
        public uc_section()
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


        Section sectionModel = new Section();
        Section section = new Section();
        IEnumerable<Section> sectionsQuery;
        IEnumerable<Section> sections;
        byte tgl_sectionState;
        string searchText = "";
        BrushConverter bc = new BrushConverter();
        Branch branchModel = new Branch();
        Branch branch = new Branch();

        IEnumerable<Location> location;
        Location locationModel = new Location();
        private void translate()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trBranch/StoreHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            btn_locations.Content = MainWindow.resourcemanager.GetString("trLocation");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            dg_section.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_section.Columns[1].Header = MainWindow.resourcemanager.GetString("trBranch/Store");
            dg_section.Columns[2].Header = MainWindow.resourcemanager.GetString("trRecipientTooltip");

            txt_title.Text = MainWindow.resourcemanager.GetString("trSection");
            txt_active.Text = MainWindow.resourcemanager.GetString("trActive");
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_branch.Content = MainWindow.resourcemanager.GetString("trBranch/Store");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //load
                btn_locations.IsEnabled = false;
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_ucSection.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_ucSection.FlowDirection = FlowDirection.RightToLeft;
                }

                translate();
                SectionData.fillBranches(cb_branch, "bs");
                //fillBranches();
                cb_branch.SelectedIndex = 0;
                Keyboard.Focus(tb_name);

                this.Dispatcher.Invoke(() =>
                {
                    Tb_search_TextChanged(null, null);
                });

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
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
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //clear
                tb_name.Clear();
                tb_note.Clear();
                cb_branch.SelectedIndex = -1;
                cb_branch.SelectedIndex = -1;

                p_errorName.Visibility = Visibility.Collapsed;
                p_errorSelectBranch.Visibility = Visibility.Collapsed;

                btn_locations.IsEnabled = false;

                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                cb_branch.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }

        bool validate(Section section = null)
        {

            //chk empty Name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty Branch
            SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");


            if ((!tb_name.Text.Equals("")) && (!cb_branch.Text.Equals("")))
                return true;
            else return false;
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucSection);

                //add
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                    section.sectionId = 0;
                    if (validate(section))
                    {
                        section.name = tb_name.Text;
                        section.branchId = Convert.ToInt32(cb_branch.SelectedValue);
                        section.note = tb_note.Text;
                        section.createUserId = MainWindow.userID;
                        section.updateUserId = MainWindow.userID;
                        section.isActive = 1;

                        string s = await sectionModel.saveSection(section);

                        if (!s.Equals("-1"))
                        {
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                            Btn_clear_Click(null, null);
                        }
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                        await RefreshSectionsList();
                        Tb_search_TextChanged(null, null);
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                SectionData.EndAwait(grid_ucSection, this);

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucSection);
                //update
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update") || SectionData.isAdminPermision())
                {
                    if (validate(section))
                    {
                        section.name = tb_name.Text;
                        section.branchId = Convert.ToInt32(cb_branch.SelectedValue);
                        section.note = tb_note.Text;
                        section.updateUserId = MainWindow.userID;

                        string s = await sectionModel.saveSection(section);

                        if (!s.Equals("-1"))
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                        await RefreshSectionsList();
                        Tb_search_TextChanged(null, null);


                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                SectionData.EndAwait(grid_ucSection, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucSection);
                //delete
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete") || SectionData.isAdminPermision())
                {
                    if (section.sectionId != 0)
                    {
                        if ((!section.canDelete) && (section.isActive == 0))
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
                            if (section.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                            if (!section.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                            w.ShowDialog();
                            Window.GetWindow(this).Opacity = 1;
                            #endregion
                            if (w.isOk)
                            {
                                string popupContent = "";
                                if (section.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                                if ((!section.canDelete) && (section.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                                bool b = await sectionModel.Delete(section.sectionId, MainWindow.userID.Value, section.canDelete);

                                if (b)
                                    Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                                else
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                            }
                        }
                        await RefreshSectionsList();
                        Tb_search_TextChanged(null, null);
                    }
                    //clear textBoxs
                    Btn_clear_Click(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                SectionData.EndAwait(grid_ucSection, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
        private async void activate()
        {//activate
            section.isActive = 1;

            string s = await sectionModel.saveSection(section);

            if (!s.Equals("-1"))
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshSectionsList();
            Tb_search_TextChanged(null, null);
        }
        private async void Dg_section_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucSection);
                //selection
                p_errorName.Visibility = Visibility.Collapsed;
                p_errorSelectBranch.Visibility = Visibility.Collapsed;

                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                cb_branch.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                if (dg_section.SelectedIndex != -1)
                {
                    section = dg_section.SelectedItem as Section;
                    this.DataContext = section;
                }

                if (section != null)
                {
                    btn_locations.IsEnabled = true;

                    if (section.branchId != 0)
                    {
                        //display branch by id
                        branch = await branchModel.getBranchById(section.branchId.Value);

                        cb_branch.SelectedValue = branch.branchId;
                    }

                    #region delete
                    if (section.canDelete)
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                        txt_delete_Icon.Kind =
                                 MaterialDesignThemes.Wpf.PackIconKind.Delete;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                    }

                    else
                    {
                        if (section.isActive == 0)
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
                SectionData.EndAwait(grid_ucSection, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
        private void validationCompobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if ((sender as ComboBox).Name == "cb_branch")
                    SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
        private void validationControl_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {

                if ((sender as Control).Name == "tb_name")
                    //chk empty name
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                else if ((sender as Control).Name == "cb_branch")
                    //chk empty mobile
                    SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                if ((sender as TextBox).Name == "tb_name")
                    //chk empty x
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");


            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
        void handleSpace_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }

        private async void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucSection);
                if (sections is null)
                    await RefreshSectionsList();
                tgl_sectionState = 1;
                Tb_search_TextChanged(null, null);
                SectionData.EndAwait(grid_ucSection, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
        private async void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucSection);
                if (sections is null)
                    await RefreshSectionsList();
                tgl_sectionState = 0;
                Tb_search_TextChanged(null, null);
                SectionData.EndAwait(grid_ucSection, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
        async Task<IEnumerable<Section>> RefreshSectionsList()
        {
            sections = await sectionModel.getBranchSections(MainWindow.branchID.Value);
            return sections;
        }
        void RefreshSectionView()
        {
            dg_section.ItemsSource = sectionsQuery;
            txt_count.Text = sectionsQuery.Count().ToString();
            cb_branch.SelectedIndex = -1;
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucSection);
                //search
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    if (sections is null)
                        await RefreshSectionsList();
                    searchText = tb_search.Text.ToLower();
                    sectionsQuery = sections.Where(s => (s.name.ToLower().Contains(searchText)
                    ) && s.isActive == tgl_sectionState && s.isFreeZone != 1);
                    RefreshSectionView();
                }
                SectionData.EndAwait(grid_ucSection, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    RefreshSectionsList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {

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
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }

        void FN_ExportToExcel()
        {

            var QueryExcel = sectionsQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                branchName = x.branchName,
                Notes = x.note
            });
            var DTForExcel = QueryExcel.ToDataTable();



            ExportToExcel.Export(DTForExcel);
        }


        private async void Btn_locations_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucSection);
                //locations
                if (MainWindow.groupObject.HasPermissionAction(selectLocationPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {

                    SectionData.clearValidate(tb_name, p_errorName);
                    //location = await locationModel.getLocsBySectionId(section.sectionId);
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_locationsList w = new wd_locationsList();
                    //Pre Locations
                    //w.selectedLocations = await locationModel.getLocsBySectionId(section.sectionId);
                    w.sectionId = section.sectionId;
                    w.ShowDialog();
                    if (w.isActive)
                    {
                        await locationModel.saveLocationsSection(w.selectedLocations, section.sectionId, MainWindow.userLogin.userId);
                        //foreach (var location in w.selectedLocations)
                        //{
                        //    MessageBox.Show(location.name + "\t");
                        //}
                    }
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                SectionData.EndAwait(grid_ucSection, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }

        }
    }
}

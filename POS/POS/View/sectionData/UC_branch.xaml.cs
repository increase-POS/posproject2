using POS.Classes;
using netoaster;
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
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using POS.View.windows;
using POS.View.sectionData.Charts;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_branch.xaml
    /// </summary>
    public partial class UC_branch : UserControl
    {

        Branch branchModel = new Branch();
        Branch branch = new Branch();
        IEnumerable<Branch> branchesQuery;
        IEnumerable<Branch> branches;
        byte tgl_branchState;
        string searchText = "";
        BrushConverter bc = new BrushConverter();
        //phone variabels
        IEnumerable<CountryCode> countrynum;
        IEnumerable<City> citynum;
        IEnumerable<City> citynumofcountry;

        int? countryid;
        Boolean firstchange = false;

        CountryCode countrycodes = new CountryCode();
        City cityCodes = new City();

        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        string basicsPermission = "branches_basics";
        string storesPermission = "branches_branches";
        private static UC_branch _instance;
        public static UC_branch Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_branch();
                return _instance;
            }
        }
        public UC_branch()
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
                SectionData.ExceptionMessage(ex, this);
            }
        }
        //area code methods
        async Task<IEnumerable<CountryCode>> RefreshCountry()
        {

            countrynum = await countrycodes.GetAllCountries();

            return countrynum;
        }
        private async Task fillCountries()
        {

            if (countrynum is null)
                await RefreshCountry();

            cb_areaPhone.ItemsSource = countrynum.ToList();
            cb_areaPhone.SelectedValuePath = "countryId";
            cb_areaPhone.DisplayMemberPath = "code";

            cb_area.ItemsSource = countrynum.ToList();
            cb_area.SelectedValuePath = "countryId";
            cb_area.DisplayMemberPath = "code";


            cb_area.SelectedValue = MainWindow.Region.countryId;
            cb_areaPhone.SelectedValue = MainWindow.Region.countryId;

        }

        async Task<IEnumerable<City>> RefreshCity()
        {

            citynum = await cityCodes.Get();

            return citynum;
        }
        private async Task fillCity()
        {

            if (citynum is null)
                await RefreshCity();


        }
        //end areacod
        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {

                SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }

        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }

        private void translate()
        {

            txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            txt_branch.Text = MainWindow.resourcemanager.GetString("trBranch");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trSelectBranchHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trCodeHint"));
            txt_contentInformatin.Text = MainWindow.resourcemanager.GetString("trMoreInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_area, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));


            dg_branch.Columns[0].Header = MainWindow.resourcemanager.GetString("trCode");
            dg_branch.Columns[1].Header = MainWindow.resourcemanager.GetString("trName");
            dg_branch.Columns[2].Header = MainWindow.resourcemanager.GetString("trAddress");
            dg_branch.Columns[3].Header = MainWindow.resourcemanager.GetString("trNote");

            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            //tt_code.Content = MainWindow.resourcemanager.GetString("trCode");
            //tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            //tt_branch.Content = MainWindow.resourcemanager.GetString("trParentBranch");
            //tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
            //tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
            //tt_email.Content = MainWindow.resourcemanager.GetString("trEmail");
            //tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
            //tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            //tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");
            btn_stores.Content = MainWindow.resourcemanager.GetString("trBranchs/Stores");

        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);
                if (MainWindow.lang.Equals("en"))
                { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_main.FlowDirection = FlowDirection.LeftToRight; }
                else
                { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_main.FlowDirection = FlowDirection.RightToLeft; }

                translate();

                await fillComboBranchParent();

                await fillCountries();
                await fillCity();

                btn_stores.IsEnabled = false;
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                Keyboard.Focus(tb_code);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task fillComboBranchParent()
        {

            var branchesWithMain = await branchModel.GetAll();
            cb_branch.ItemsSource = branchesWithMain.Where(b => b.type == "b" || b.type == "bs");
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
            cb_branch.SelectedIndex = -1;

        }
        private void Dg_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                p_errorBranch.Visibility = Visibility.Collapsed;
                p_errorCode.Visibility = Visibility.Collapsed;
                p_errorName.Visibility = Visibility.Collapsed;
                p_errorMobile.Visibility = Visibility.Collapsed;
                p_errorEmail.Visibility = Visibility.Collapsed;

                cb_branch.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                if (dg_branch.SelectedIndex != -1)
                {
                    branch = dg_branch.SelectedItem as Branch;
                    this.DataContext = branch;
                }

                if (branch != null)
                {
                    SectionData.getMobile(branch.mobile, cb_area, tb_mobile);

                    SectionData.getPhone(branch.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                    btn_stores.IsEnabled = true;

                    //parent branch
                    try
                    {
                        cb_branch.SelectedValue = branch.parentId.Value;
                    }
                    catch
                    {
                        cb_branch.SelectedValue = -1;
                    }
                    //delete
                    if (branch.canDelete)
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                        txt_delete_Icon.Kind =
                                 MaterialDesignThemes.Wpf.PackIconKind.Delete;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                    }

                    else
                    {
                        if (branch.isActive == 0)
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
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                tb_code.Clear();
                tb_name.Clear();
                cb_branch.SelectedIndex = -1;
                tb_address.Clear();
                tb_notes.Clear();
                tb_email.Clear();

                tb_mobile.Clear();
                cb_areaPhone.SelectedIndex = 8;
                cb_area.SelectedIndex = 8;
                tb_phone.Clear();

                cb_area.SelectedValue = MainWindow.Region.countryId;
                cb_areaPhone.SelectedValue = MainWindow.Region.countryId;

                p_errorBranch.Visibility = Visibility.Collapsed;
                p_errorCode.Visibility = Visibility.Collapsed;
                p_errorName.Visibility = Visibility.Collapsed;
                p_errorMobile.Visibility = Visibility.Collapsed;
                p_errorEmail.Visibility = Visibility.Collapsed;

                cb_branch.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                btn_stores.IsEnabled = false;
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
        // Error Here
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            //try
            //{
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                    branch.branchId = 0;

                    #region validate
                    bool iscodeExist = await SectionData.isCodeExist(tb_code.Text, "b", "Branch", 0);
                    //chk empty branch
                    SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
                    //chk empty code
                    SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
                    //chk empty name
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //chk empty mobile
                    SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
                    //validate email
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);

                    string phoneStr = "";
                    if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

                    bool emailError = false;

                    if (!tb_email.Text.Equals(""))
                        if (!SectionData.IsValid(tb_email.Text))
                            emailError = true;
                    #endregion

                    if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")) && (!tb_code.Text.Equals("")) && (!cb_branch.Text.Equals("")))
                    {
                        if ((emailError) || (iscodeExist))
                        {
                            if (emailError)
                                SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                            //duplicate
                            if (iscodeExist)
                                SectionData.validateDuplicateCode(tb_code, p_errorCode, tt_errorCode, "trDuplicateCodeToolTip");
                        }
                        else
                        {
                            branch.code = tb_code.Text;
                            branch.name = tb_name.Text;
                            branch.notes = tb_notes.Text;
                            branch.address = tb_address.Text;
                            branch.email = tb_email.Text;
                            branch.phone = phoneStr;
                            branch.mobile = cb_area.Text + "-" + tb_mobile.Text;
                            branch.createUserId = MainWindow.userID;
                            branch.updateUserId = MainWindow.userID;
                            branch.type = "b";
                            branch.isActive = 1;
                            branch.parentId = Convert.ToInt32(cb_branch.SelectedValue);

                            int s =  await branchModel.save(branch);
                            if (s == -1)// إظهار رسالة الترقية
                                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpgrade"), animation: ToasterAnimation.FadeIn);

                            else if (s == 0) // an error occure
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                            else
                            {
                            fillComboBranchParent();
                            await RefreshBranchesList();
                            tb_search_TextChanged(null, null);

                           await AddFreeThone(s);
                        }
                    }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                //SectionData.ExceptionMessage(ex, this);
            //}
        }
        async Task AddFreeThone(int branchId)
        {

            var section = new Classes.Section();
            section.name = "FreeZone";
            section.branchId = branchId;
            section.note = "";
            section.createUserId = MainWindow.userID;
            section.updateUserId = MainWindow.userID;
            section.isActive = 1;
            section.isFreeZone = 1;
            int sectionId = await section.save(section);
            if (sectionId>0)
            {
                var location = new Classes.Location();
                location.x = location.y = location.z = "0";
                location.note = tb_notes.Text;
                location.createUserId = MainWindow.userID;
                location.updateUserId = MainWindow.userID;
                location.isActive = 1;
                location.sectionId = null;
                location.branchId = branchId;
                location.isFreeZone = 1;
                location.sectionId = sectionId;

                int l = await location.save(location);

                if (l >0)
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);
                }
                else
                {
                    await section.delete(sectionId, MainWindow.userID.Value, true);
                    await branchModel.delete(branchId, MainWindow.userID.Value, true);
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
            }
            else
            {

                await branchModel.delete(branchId, MainWindow.userID.Value, true);
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }

        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update") || SectionData.isAdminPermision())
                {
                    if (branch.branchId > 0)
                    {

                        #region validate
                        bool iscodeExist = await SectionData.isCodeExist(tb_code.Text, "b", "Branch", branch.branchId);

                    //chk empty branch
                    SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
                    //chk empty code
                    SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
                    //chk empty name
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //chk empty mobile
                    SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
                    //validate email
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);

                    string phoneStr = "";
                    if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

                    bool emailError = false;

                    if (!tb_email.Text.Equals(""))
                        if (!SectionData.IsValid(tb_email.Text))
                            emailError = true;
                    #endregion

                    if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")) && (!tb_code.Text.Equals("")) && (!cb_branch.Text.Equals("")))
                    {
                        if ((emailError) || (iscodeExist))
                        {
                            if (emailError)
                                SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                            if (iscodeExist)
                                SectionData.validateDuplicateCode(tb_code, p_errorCode, tt_errorCode, "trDuplicateCodeToolTip");
                        }
                        else
                        {
                            branch.code = tb_code.Text;
                            branch.name = tb_name.Text;
                            branch.notes = tb_notes.Text;
                            branch.address = tb_address.Text;
                            branch.email = tb_email.Text;
                            branch.phone = phoneStr;
                            branch.mobile = cb_area.Text + "-" + tb_mobile.Text;
                            branch.updateUserId = MainWindow.userID;
                            branch.type = "b";
                            //branch.isActive = 1;
                            branch.parentId = Convert.ToInt32(cb_branch.SelectedValue);

                            int s = await branchModel.save(branch);

                            if (s>0)
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                            await RefreshBranchesList();
                            tb_search_TextChanged(null, null);
                            await fillComboBranchParent();

                            cb_branch.SelectedValue = branch.parentId;

                            SectionData.getMobile(branch.mobile, cb_area, tb_mobile);

                            SectionData.getPhone(branch.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);
                        }
                    }
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trSelectItemFirst"), animation: ToasterAnimation.FadeIn);

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

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete") || SectionData.isAdminPermision())
                {
                    if (branch.branchId != 0)
                    {
                        if ((!branch.canDelete) && (branch.isActive == 0))
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
                            if (branch.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                            if (!branch.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                            w.ShowDialog();
                            Window.GetWindow(this).Opacity = 1;
                            #endregion
                            if (w.isOk)
                            {
                                string popupContent = "";
                                if (branch.canDelete)
                                {
                                    popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                                }
                                if ((!branch.canDelete) && (branch.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                                int b = await branchModel.delete(branch.branchId, MainWindow.userID.Value, branch.canDelete);

                                if (b>0)
                                {
                                    branch.branchId = 0;
                                    Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                                }
                                else
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                            }
                        }

                        await RefreshBranchesList();
                        tb_search_TextChanged(null, null);
                        await fillComboBranchParent();

                    }
                    //clear textBoxs
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
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async Task activate()
        {//activate

            branch.isActive = 1;

            int s = await branchModel.save(branch);

            if (s>0)
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshBranchesList();
            tb_search_TextChanged(null, null);

        }

        private async void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    var bc = new BrushConverter();

                    p_errorName.Visibility = Visibility.Collapsed;
                    tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                    if (branches is null)
                        await RefreshBranchesList();
                    searchText = tb_search.Text.ToLower();
                    branchesQuery = branches.Where(s => (s.code.ToLower().Contains(searchText) ||
                    s.name.ToLower().Contains(searchText) ||
                    s.mobile.ToLower().Contains(searchText)
                    ) && s.isActive == tgl_branchState);
                    RefreshBranchView();
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

        private void tb_mobile_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_phone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_mobile_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }

        private void tb_mobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }

        private async void tgl_branchIsActive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (branches is null)
                    await RefreshBranchesList();
                tgl_branchState = 1;
                tb_search_TextChanged(null, null);
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

        private async void tgl_branchIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (branches is null)
                    await RefreshBranchesList();
                tgl_branchState = 0;
                tb_search_TextChanged(null, null);
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

        async Task<IEnumerable<Branch>> RefreshBranchesList()
        {

            branches = await branchModel.GetAllWithoutMain("b");

            return branches;
        }
        void RefreshBranchView()
        {

            dg_branch.ItemsSource = branchesQuery;
            txt_count.Text = branchesQuery.Count().ToString();

            cb_branch.SelectedIndex = -1;

        }

       

        private void tb_code_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }

        private void tb_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }

        private void cb_branch_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }

        private void Cb_areaPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (firstchange == true)
                {
                    if (cb_areaPhone.SelectedValue != null)
                    {
                        if (cb_areaPhone.SelectedIndex >= 0)
                            countryid = int.Parse(cb_areaPhone.SelectedValue.ToString());

                        citynumofcountry = citynum.Where(b => b.countryId == countryid).OrderBy(b => b.cityCode).ToList();

                        cb_areaPhoneLocal.ItemsSource = citynumofcountry;
                        cb_areaPhoneLocal.SelectedValuePath = "cityId";
                        cb_areaPhoneLocal.DisplayMemberPath = "cityCode";
                        if (citynumofcountry.Count() > 0)
                        {

                            cb_areaPhoneLocal.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            cb_areaPhoneLocal.Visibility = Visibility.Collapsed;
                        }

                    }
                }
                else
                {
                    firstchange = true;
                }
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }

        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    await RefreshBranchesList();
                    tb_search_TextChanged(null, null);
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

        void FN_ExportToExcel()
        {

            var QueryExcel = branchesQuery.AsEnumerable().Select(x => new
            {
                Code = x.code,
                Name = x.name,
                Mobile = x.mobile,
                Phone = x.phone,
                Email = x.email,
                Address = x.address,
                Notes = x.notes,

            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trCode");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trMobile");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trPhone");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trEmail");
            DTForExcel.Columns[5].Caption = MainWindow.resourcemanager.GetString("trAddress");
            DTForExcel.Columns[6].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);

        }




        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//excel
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    #region
                    //Thread t1 = new Thread(() =>
                    //{
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\SectionData\Ar\ArBranchReport.rdlc";
                        }
                        else addpath = @"\Reports\SectionData\En\BranchReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
                        ReportCls.checkLang();

                        clsReports.branchReport(branchesQuery, rep, reppath,paramarr);
                        clsReports.setReportLanguage(paramarr);
                        clsReports.Header(paramarr);

                        rep.SetParameters(paramarr);

                        rep.Refresh();
                        this.Dispatcher.Invoke(() =>
                        {
                            saveFileDialog.Filter = "EXCEL|*.xls;";
                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string filepath = saveFileDialog.FileName;
                                LocalReportExtensions.ExportToExcel(rep, filepath);
                            }
                        });


                    //});
                    //t1.Start();
                    #endregion
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
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    #region
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\SectionData\Ar\ArBranchReport.rdlc";
                    }
                    else addpath = @"\Reports\SectionData\En\BranchReport.rdlc";

                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.branchReport(branchesQuery, rep, reppath, paramarr);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);

                    rep.SetParameters(paramarr);

                    rep.Refresh();

                    saveFileDialog.Filter = "PDF|*.pdf;";

                    if (saveFileDialog.ShowDialog() == true)
                    {

                        string filepath = saveFileDialog.FileName;
                        LocalReportExtensions.ExportToPDF(rep, filepath);

                    }
                    #endregion
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
        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    #region
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\SectionData\Ar\ArBranchReport.rdlc";
                    }
                    else addpath = @"\Reports\SectionData\En\BranchReport.rdlc";

                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.branchReport(branchesQuery, rep, reppath, paramarr);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);

                    rep.SetParameters(paramarr);

                    rep.Refresh();
                    LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
                    #endregion
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
        private void btn_pieChart_Click(object sender, RoutedEventArgs e)
        {//pie
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    win_lvc win = new win_lvc(branchesQuery, 4, true);
                    win.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
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

        private void Tb_code_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;

        }

        private void Tb_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
        }

        private void Tb_email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
        }

        private void Btn_stores_Click(object sender, RoutedEventArgs e)
        {//stores
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(storesPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;

                    wd_branchesList w = new wd_branchesList();

                    w.Id = branch.branchId;
                    w.userOrBranch = 'b';
                    w.ShowDialog();
                    if (w.isActive)
                    {

                    }

                    Window.GetWindow(this).Opacity = 1;

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

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(storesPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
            string pdfpath = "";

            List<ReportParameter> paramarr = new List<ReportParameter>();

            //
            pdfpath = @"\Thumb\report\temp.pdf";
            pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\SectionData\Ar\ArBranchReport.rdlc";
            }
            else addpath = @"\Reports\SectionData\En\BranchReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
            ReportCls.checkLang();

                    clsReports.branchReport(branchesQuery, rep, reppath, paramarr);
                    clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();

            LocalReportExtensions.ExportToPDF(rep, pdfpath);
            wd_previewPdf w = new wd_previewPdf();
            w.pdfPath = pdfpath;
            if (!string.IsNullOrEmpty(w.pdfPath))
            {
                w.ShowDialog();
                w.wb_pdfWebViewer.Dispose();


            }
            Window.GetWindow(this).Opacity = 1;
                    #endregion

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
    }
}



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
    /// Interaction logic for UC_store.xaml
    /// </summary>
    public partial class UC_store : UserControl
    {
        Branch storeModel = new Branch();
        Branch branchModel = new Branch();

        Branch store = new Branch();

        IEnumerable<Branch> storesQuery;
        IEnumerable<Branch> stores;
        byte tgl_storeState;
        string searchText = "";

       

        int ParentId = 0;

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

        string basicsPermission = "stores_basics";
        string storesPermission = "stores_branches";

        private static UC_store _instance;
        public static UC_store Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_store();
                return _instance;
            }
        }
        public UC_store()
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
        //area code methods
        async Task<IEnumerable<CountryCode>> RefreshCountry()
        {
            countrynum = await countrycodes.GetAllCountries();
            return countrynum;
        }
        private async void fillCountries()
        {
            if (countrynum is null)
                await RefreshCountry();

            cb_areaPhone.ItemsSource = countrynum.ToList();
            cb_areaPhone.SelectedValuePath = "countryId";
            cb_areaPhone.DisplayMemberPath = "code";

            cb_area.ItemsSource = countrynum.ToList();
            cb_area.SelectedValuePath = "countryId";
            cb_area.DisplayMemberPath = "code";


            cb_area.SelectedIndex = MainWindow.Region.countryId;
            cb_areaPhone.SelectedIndex = MainWindow.Region.countryId;
        }

        async Task<IEnumerable<City>> RefreshCity()
        {
            citynum = await cityCodes.Get();
            return citynum;
        }
        private async void fillCity()
        {
            if (citynum is null)
                await RefreshCity();


        }
        //end areacod
        private void DG_Store_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

            if (dg_store.SelectedIndex != -1)
            {
                store = dg_store.SelectedItem as Branch;
                this.DataContext = store;
            }

            if (store != null)
            {
                SectionData.getMobile(store.mobile, cb_area, tb_mobile);

                SectionData.getPhone(store.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                //parent branch
                try
                {
                    cb_branch.SelectedValue = store.parentId.Value;
                }
                catch
                {
                    cb_branch.SelectedValue = -1;
                }

                btn_stores.IsEnabled = true ;

                //delete
                if (store.canDelete)
                {
                    txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                    txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                }
                else if (store.isActive == 0)
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
    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
    {
        SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
    }
    private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
    {
        SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
    }
    private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
    {
        SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);

    }

    private void translate()
    {
        txt_store.Text = MainWindow.resourcemanager.GetString("trStore");
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
        txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
        txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
        dg_store.Columns[0].Header = MainWindow.resourcemanager.GetString("trCode");
        dg_store.Columns[1].Header = MainWindow.resourcemanager.GetString("trName");
        dg_store.Columns[2].Header = MainWindow.resourcemanager.GetString("trAddress");
        dg_store.Columns[3].Header = MainWindow.resourcemanager.GetString("trNote");

        btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

        tt_code.Content = MainWindow.resourcemanager.GetString("trCode");
        tt_name.Content = MainWindow.resourcemanager.GetString("trName");
        tt_branch.Content = MainWindow.resourcemanager.GetString("trParentBranch");
        tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
        tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
        tt_email.Content = MainWindow.resourcemanager.GetString("trEmail");
        tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
        tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
        tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");

        tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
        tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");
        btn_stores.Content = MainWindow.resourcemanager.GetString("trBranchs/Stores");

        tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
        tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
        tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
        tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

    }

    private void Btn_clear_Click(object sender, RoutedEventArgs e)
    {//clear
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

        btn_stores.IsEnabled = false;

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

    }

    private async void Btn_add_Click(object sender, RoutedEventArgs e)
    {//add
            
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                store.branchId = 0;

        bool iscodeExist = await SectionData.isCodeExist(tb_code.Text, "s", "Branch", 0);
        //chk empty branch
        SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
        //chk empty code
        SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
        //chk empty name
        SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        //chk empty mobile
        SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
        //validate email
        SectionData.validateEmail(tb_email, p_errorEmail, tt_email);

        string phoneStr = "";
        if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

        bool emailError = false;

        if (!tb_email.Text.Equals(""))
            if (!SectionData.IsValid(tb_email.Text))
                emailError = true;

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
                    store.code = tb_code.Text;
                    store.name = tb_name.Text;
                    store.notes = tb_notes.Text;
                    store.address = tb_address.Text;
                    store.email = tb_email.Text;
                    store.phone = phoneStr;
                    store.mobile = cb_area.Text + "-" + tb_mobile.Text;
                    store.createUserId = MainWindow.userID;
                    store.updateUserId = MainWindow.userID;
                    store.type = "s";
                    store.isActive = 1;
                    store.parentId = Convert.ToInt32(cb_branch.SelectedValue);

                    string s = await storeModel.saveBranch(store);
                    if (!s.Equals("-1"))
                    {
                        AddFreeThone(int.Parse(s));
                    }
                    else 
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    await RefreshStoresList();
                    Tb_search_TextChanged(null, null);
                    fillComboBranchParent();
                }
            }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

        }
        async void AddFreeThone(int branchId)
        {
            var section = new Classes.Section();
            section.name = "FreeZone";
            section.branchId = branchId;
            section.note = "";
            section.createUserId = MainWindow.userID;
            section.updateUserId = MainWindow.userID;
            section.isActive = 1;
            section.isFreeZone = 1;
            string sectionId = await section.saveSection(section);
            if (!sectionId.Equals("-1"))
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
                location.sectionId = int.Parse(sectionId);

                string l = await location.saveLocation(location);

                if (!l.Equals("-1"))
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);
                }
                else
                {
                    await section.Delete(int.Parse(sectionId), MainWindow.userID.Value, true);
                    await storeModel.deleteBranch(branchId, MainWindow.userID.Value, true);
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
            }
            else
            {

                await storeModel.deleteBranch(branchId, MainWindow.userID.Value, true);
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
    {//update
            
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update") || SectionData.isAdminPermision())
                {
                bool iscodeExist = await SectionData.isCodeExist(tb_code.Text, "s", "Branch", store.branchId);

        //chk empty branch
        SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
        //chk empty code
        SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
        //chk empty name
        SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        //chk empty mobile
        SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
        //validate email
        SectionData.validateEmail(tb_email, p_errorEmail, tt_email);

        string phoneStr = "";
        if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

        bool emailError = false;

        if (!tb_email.Text.Equals(""))
            if (!SectionData.IsValid(tb_email.Text))
                emailError = true;
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
                //SectionData.genRandomCode("s", "Branch");
                //tb_code.Text = SectionData.code;

                store.code = tb_code.Text;
                store.name = tb_name.Text;
                store.notes = tb_notes.Text;
                store.address = tb_address.Text;
                store.email = tb_email.Text;
                store.phone = phoneStr;
                store.mobile = cb_area.Text + "-" + tb_mobile.Text;
                store.updateUserId = MainWindow.userID;
                store.type = "s";
                store.isActive = 1;
                store.parentId = Convert.ToInt32(cb_branch.SelectedValue);

                string s = await storeModel.saveBranch(store);

                    if (!s.Equals("-1")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                await RefreshStoresList();
                Tb_search_TextChanged(null, null);
                    fillComboBranchParent();
                    cb_branch.SelectedValue = store.parentId;

                SectionData.getMobile(store.mobile, cb_area, tb_mobile);

                SectionData.getPhone(store.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

            }
        }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete") || SectionData.isAdminPermision())
            {
                if (store.branchId != 1 && store.branchId != 2)
                {
                    if (store.branchId != 0)
                    {
                        if ((!store.canDelete) && (store.isActive == 0))
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
                            if (store.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                            if (!store.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                            w.ShowDialog();
                            Window.GetWindow(this).Opacity = 1;
                            #endregion
                            if (w.isOk)
                            {
                                string popupContent = "";
                                if (store.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                                if ((!store.canDelete) && (store.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                                bool b = await storeModel.deleteBranch(store.branchId, MainWindow.userID.Value, store.canDelete);

                                if (b) //SectionData.popUpResponse("", popupContent);
                                    Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                                else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                            }
                        }

                        await RefreshStoresList();
                        Tb_search_TextChanged(null, null);
                        fillComboBranchParent();
                    }

                    else
                        Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trCannotDeleteTheMainPos"), animation: ToasterAnimation.FadeIn);

                    //clear textBoxs
                    Btn_clear_Click(sender, e);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
            }
        }
    private async void activate()
    {//activate
        store.isActive = 1;

        string s = await storeModel.saveBranch(store);

        if (!s.Equals("-1"))  //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
        else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

        await RefreshStoresList();
        Tb_search_TextChanged(null, null);
    }

    private async void UserControl_Loaded(object sender, RoutedEventArgs e)
    {//load
        if (MainWindow.lang.Equals("en"))
        { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucStore.FlowDirection = FlowDirection.LeftToRight; }
        else
        { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucStore.FlowDirection = FlowDirection.RightToLeft; }

        translate();
        //fill combo
        //var branches = await branchModel.GetBranchesAsync("b");
        //cb_branch.ItemsSource = branches;
        fillComboBranchParent();

        cb_area.SelectedIndex = 0;
        cb_areaPhone.SelectedIndex = 0;
        cb_areaPhoneLocal.SelectedIndex = 0;
        //if(cb_branch.Items.Count > 0)
        //    cb_branch.SelectedIndex = 0;
        fillCountries();
        fillCity();

            Keyboard.Focus(tb_code);

            btn_stores.IsEnabled = false;

        //SectionData.genRandomCode("s", "Branch");
        //tb_code.Text = SectionData.code;

            this.Dispatcher.Invoke(() =>
        {
            Tb_search_TextChanged(null, null);
        });
    }
        async void fillComboBranchParent()
        {
            var branchesWithMain = await branchModel.GetAll();
            cb_branch.ItemsSource = branchesWithMain.Where(b => b.type == "b" || b.type == "bs");
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
            cb_branch.SelectedIndex = -1;
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                if (stores is null)
                    await RefreshStoresList();
                searchText = tb_search.Text.ToLower();
                storesQuery = stores.Where(s => (s.code.ToLower().Contains(searchText) ||
                s.name.ToLower().Contains(searchText) ||
                s.mobile.ToLower().Contains(searchText)
                ) && s.isActive == tgl_storeState);
                RefreshStoreView();
            }
        }

    private void cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //try
        //{
        // ParentId = Convert.ToInt32(cb_branch.SelectedValue);
        //}
        //catch 
        //{
        //  ParentId = 0;
        //}
        //MessageBox.Show(ParentId.ToString());
    }

        async Task<IEnumerable<Branch>> RefreshStoresList()
        {

            MainWindow.mainWindow.StartAwait();
            stores = await storeModel.GetBranchesAsync("s");
            MainWindow.mainWindow.EndAwait();
            return stores;
        }
        void RefreshStoreView()
    {
        dg_store.ItemsSource = storesQuery;
        txt_count.Text = storesQuery.Count().ToString();
       
            cb_branch.SelectedIndex = -1;
    }

    private async void tgl_storeIsActive_Checked(object sender, RoutedEventArgs e)
    {
        if (stores is null)
            await RefreshStoresList();
        tgl_storeState = 1;
        Tb_search_TextChanged(null, null);
    }

    private async void tgl_storeIsActive_Unchecked(object sender, RoutedEventArgs e)
    {
        if (stores is null)
            await RefreshStoresList();
        tgl_storeState = 0;
        Tb_search_TextChanged(null, null);
    }

    private void tb_mobile_TextChanged(object sender, TextChangedEventArgs e)
    {
        SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");

    }

    private void tb_mobile_LostFocus(object sender, RoutedEventArgs e)
    {
        SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");

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

    private void tb_code_LostFocus(object sender, RoutedEventArgs e)
    {
        SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
    }

    private void tb_code_TextChanged(object sender, TextChangedEventArgs e)
    {
        SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
    }

    private void cb_branch_LostFocus(object sender, RoutedEventArgs e)
    {
        SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
    }

    private async void Cb_areaPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (firstchange == true)
        {
            if (cb_areaPhone.SelectedValue != null)
            {
                if (cb_areaPhone.SelectedIndex >= 0)
                    countryid = int.Parse(cb_areaPhone.SelectedValue.ToString());
                    if (citynum is null)
                        await RefreshCity();
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

    private void Btn_refresh_Click(object sender, RoutedEventArgs e)
    {
            
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                RefreshStoresList();
                Tb_search_TextChanged(null, null);
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
    }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
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

        void FN_ExportToExcel()
        {
            var QueryExcel = storesQuery.AsEnumerable().Select(x => new
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

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
    {
            
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath;

            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\SectionData\Ar\ArStoreReport.rdlc";
            }
            else addpath = @"\Reports\SectionData\En\StoreReport.rdlc";
          
        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.branchReport(storesQuery, rep, reppath);
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
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
            }

            private void Btn_print_Click(object sender, RoutedEventArgs e)
    {
            
                    if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath;

            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\SectionData\Ar\ArStoreReport.rdlc";
            }
            else addpath = @"\Reports\SectionData\En\StoreReport.rdlc";

            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.branchReport(storesQuery, rep, reppath);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);
            rep.Refresh();
        LocalReportExtensions.PrintToPrinter(rep);
                    }
                    else
                        Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                }
                private void btn_pieChart_Click(object sender, RoutedEventArgs e)
        {
            
                        if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                            Window.GetWindow(this).Opacity = 0.2;
            win_lvc win = new win_lvc(storesQuery, 4, false);
            win.ShowDialog();
            Window.GetWindow(this).Opacity = 1;
                        }
                        else
                            Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                    }
                    private void Tb_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
        if (!regex.IsMatch(e.Text))
            e.Handled = true;
    }

    private void Tb_code_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        e.Handled = e.Key == Key.Space;
    }

    private void Tb_email_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
        if (!regex.IsMatch(e.Text))
            e.Handled = true;
    }

        private void Btn_stores_Click(object sender, RoutedEventArgs e)
        {//stores
            
            if (MainWindow.groupObject.HasPermissionAction(storesPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                Window.GetWindow(this).Opacity = 0.2;

            wd_branchesList w = new wd_branchesList();

            w.Id = store.branchId;
            w.userOrBranch = 's';
            w.ShowDialog();
            if (w.isActive)
            {

            }

            Window.GetWindow(this).Opacity = 1;

            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }


    }
}

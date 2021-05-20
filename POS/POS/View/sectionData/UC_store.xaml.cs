﻿
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
    /// Interaction logic for UC_store.xaml
    /// </summary>
    public partial class UC_store : UserControl
    {
        Branch storeModel  = new Branch();
        Branch branchModel = new Branch();

        Branch store = new Branch();

        IEnumerable<Branch> storesQuery;
        IEnumerable<Branch> stores;
        byte tgl_storeState;
        string searchText = "";

        IEnumerable<Branch> branchesQuery;
        IEnumerable<Branch> branches;

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
        public UC_store()
        {
            InitializeComponent();

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
                //mobile

                if ((store.mobile != null))
                {
                    string area = store.mobile;
                    string[] pharr = area.Split('-');
                    int j = 0;
                    string phone = "";

                    foreach (string strpart in pharr)
                    {
                        if (j == 0)
                        {
                            area = strpart;
                        }
                        else
                        {
                            phone = phone + strpart;
                        }
                        j++;
                    }

                    cb_area.Text = area;

                    tb_mobile.Text = phone.ToString();
                }
                else
                {
                    cb_area.SelectedIndex = -1;
                    tb_mobile.Clear();
                }
                //phone
                if ((store.phone != null))
                {
                    string area = store.phone;
                    string[] pharr = area.Split('-');
                    int j = 0;
                    string phone = "";
                    string areaLocal = "";
                    foreach (string strpart in pharr)
                    {
                        if (j == 0)
                        {
                            area = strpart;

                        }
                        else if (j == 1)
                        {
                            areaLocal = strpart;


                        }
                        else
                        {
                            phone = phone + strpart;

                        }
                        j++;
                    }

                    cb_areaPhone.Text = area;
                    cb_areaPhoneLocal.Text = areaLocal;
                    tb_phone.Text = phone.ToString();
                }
                else
                {
                    cb_areaPhone.SelectedIndex = -1;
                    cb_areaPhoneLocal.SelectedIndex = -1;
                    tb_phone.Clear();
                }
                //parent branch
                try
                {
                    cb_branch.SelectedValue = store.parentId.Value;
                }
                catch
                {
                    cb_branch.SelectedValue = -1;
                }

                if (store.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else
                {
                    if (store.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                    else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
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
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_area, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
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
            cb_area.SelectedIndex = 0;
            tb_mobile.Clear();
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            tb_phone.Clear();

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
                if (emailError)
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                //duplicate
                else if (iscodeExist)
                    SectionData.validateDuplicateCode(tb_code, p_errorCode, tt_errorCode);
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
                    store.parentId = ParentId;

                    string s = await storeModel.saveBranch(store);

                    if (s.Equals("true")) { SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null); }
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                }
            }
           // else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAddValidate"));

            stores = await storeModel.GetBranchesAsync("s");
            storesQuery = stores.Where(s => s.isActive == Convert.ToInt32(tgl_storeIsActive.IsChecked));
            dg_store.ItemsSource = storesQuery;

            
        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
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
                if (emailError)
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                else if (iscodeExist)
                    SectionData.validateDuplicateCode(tb_code, p_errorCode, tt_errorCode);
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
                    store.parentId = ParentId;

                    string s = await storeModel.saveBranch(store);

                    if (s.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                }
            }
            //else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdateValidate"));

            stores = await storeModel.GetBranchesAsync("s");
            storesQuery = stores.Where(s => s.isActive == Convert.ToInt32(tgl_storeIsActive.IsChecked));
            dg_store.ItemsSource = storesQuery;

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if ((!store.canDelete) && (store.isActive == 0))
                activate();
            else
            {
                string popupContent = "";
                if (store.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                if ((!store.canDelete) && (store.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                bool b = await storeModel.deleteBranch(store.branchId, MainWindow.userID.Value, store.canDelete);

                if (b) SectionData.popUpResponse("", popupContent);
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            }

            stores = await storeModel.GetBranchesAsync("s");
            storesQuery = stores.Where(s => s.isActive == Convert.ToInt32(tgl_storeIsActive.IsChecked));
            dg_store.ItemsSource = storesQuery;

            //clear textBoxs
            Btn_clear_Click(sender, e);

        }

        private async void activate()
        {//activate
            store.isActive = 1;

            string s = await storeModel.saveBranch(store);

            if (s.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucStore.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucStore.FlowDirection = FlowDirection.RightToLeft; }

            translate();

            //fill combo
            if (branches == null) branches = await storeModel.GetBranchesAsync("b");
            branchesQuery = branches.Where(s => s.isActive == 1);
            cb_branch.ItemsSource = branchesQuery;
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
            cb_branch.SelectedIndex = -1;

            cb_area.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            //if(cb_branch.Items.Count > 0)
            //    cb_branch.SelectedIndex = 0;
            fillCountries();
            fillCity();
            Keyboard.Focus(tb_code);

            //SectionData.genRandomCode("s", "Branch");
            //tb_code.Text = SectionData.code;

            this.Dispatcher.Invoke(() =>
            {
                tb_search_TextChanged(null, null);
            });

        }

        private async void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            p_errorName.Visibility = Visibility.Collapsed;
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (stores is null)
                await RefreshStoresList();
            searchText = tb_search.Text;
            storesQuery = stores.Where(s => (s.code.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.mobile.Contains(searchText)
            ) && s.isActive == tgl_storeState);
            RefreshStoreView();
        }

        private void cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ParentId = Convert.ToInt32(cb_branch.SelectedValue);
            }
            catch 
            {
                ParentId = 0;
            }
        }

        async Task<IEnumerable<Branch>> RefreshStoresList()
        {
            stores = await storeModel.GetBranchesAsync("s");
            return stores;
        }
        void RefreshStoreView()
        {
            dg_store.ItemsSource = storesQuery;
            txt_Count.Text = storesQuery.Count().ToString();
            cb_area.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            cb_branch.SelectedIndex = -1;
        }

        private async void tgl_storeIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (stores is null)
                await RefreshStoresList();
            tgl_storeState = 1;
            tb_search_TextChanged(null, null);
        }

        private async void tgl_storeIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (stores is null)
                await RefreshStoresList();
            tgl_storeState = 0;
            tb_search_TextChanged(null, null);
        }

        private void tb_mobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");

        }

        private void tb_mobile_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");

        }

        private void btn_exportToExcel_Click(object sender, RoutedEventArgs e)
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

        private void Cb_areaPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                        cb_areaPhoneLocal.Visibility = Visibility.Hidden;
                    }

                }
            }
            else
            {
                firstchange = true;
            }
        }
    }
}
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
    /// Interaction logic for UC_bank.xaml
    /// </summary>
    public partial class UC_bank : UserControl
    {

        Bank bankModel = new Bank();
        Bank bank = new Bank();
        IEnumerable<Bank> banksQuery;
        IEnumerable<Bank> banks;
        byte tgl_bankState;
        string searchText = "";
        //phone variabels
        IEnumerable<CountryCode> countrynum;
        IEnumerable<City> citynum;
        IEnumerable<City> citynumofcountry;

        int? countryid;
        Boolean firstchange = false;

        CountryCode countrycodes = new CountryCode();
        City cityCodes = new City();
        BrushConverter bc = new BrushConverter();
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        string basicsPermission = "banks_basics";
        private static UC_bank _instance;
        public static UC_bank Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_bank();
                return _instance;
            }
        }
        public UC_bank()
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
        private void translate()
        {
            txt_bank.Text = MainWindow.resourcemanager.GetString("trBank");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectBankNameHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trBankNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_accNumber, MainWindow.resourcemanager.GetString("trAccNumberHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_area, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            txt_moreInformation.Text = MainWindow.resourcemanager.GetString("trAnotherInfomation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            dg_bank.Columns[0].Header = MainWindow.resourcemanager.GetString("trBankName");
            dg_bank.Columns[1].Header = MainWindow.resourcemanager.GetString("trAccNumber");
            dg_bank.Columns[2].Header = MainWindow.resourcemanager.GetString("trAddress");
            dg_bank.Columns[3].Header = MainWindow.resourcemanager.GetString("trMobile");

            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_accNum.Content = MainWindow.resourcemanager.GetString("trAccNumber");
            tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
            tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
            tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucBank.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucBank.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();


            fillCountries();
            fillCity();

            Keyboard.Focus(tb_name);

            this.Dispatcher.Invoke(() =>
            {
                Tb_search_TextChanged(null, null);
            });




        }

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }

        private void Tb_accNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_accNumber, p_errorAccNum, tt_errorAccNum, "trEmptyAccNumToolTip");
        }


        private void Tb_accNum_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_accNumber, p_errorAccNum, tt_errorAccNum, "trEmptyAccNumToolTip");

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_name.Clear();
            tb_accNumber.Clear();
            tb_address.Clear();
            tb_notes.Clear();

            tb_mobile.Clear();

            tb_phone.Clear();

            p_errorName.Visibility = Visibility.Collapsed;
            p_errorMobile.Visibility = Visibility.Collapsed;
            p_errorPhone.Visibility = Visibility.Collapsed;
            p_errorAccNum.Visibility = Visibility.Collapsed;

            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_phone.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_accNumber.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            //cb_area.SelectedIndex = 8;
            //cb_areaPhone.SelectedIndex = 8;

        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add"))
            {
                bank.bankId = 0;
                //chk empty name
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                //chk empty mobile
                SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
                //chk empty phone
                SectionData.validateEmptyTextBox(tb_phone, p_errorPhone, tt_errorPhone, "trEmptyPhoneToolTip");
                //chk empty acc
                SectionData.validateEmptyTextBox(tb_accNumber, p_errorAccNum, tt_errorAccNum, "trEmptyAccNumberToolTip");

                string phoneStr = "";
                if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

                if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")) && (!tb_phone.Text.Equals("")) && (!tb_accNumber.Text.Equals("")))
                {
                    bool isBankExist = await chkDuplicateBank();
                    if (isBankExist)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopBankExist"), animation: ToasterAnimation.FadeIn);
                        p_errorName.Visibility = Visibility.Visible;
                        tt_errorName.Content = MainWindow.resourcemanager.GetString("trPopBankExist");
                        tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
                        p_errorAccNum.Visibility = Visibility.Visible;
                        tt_errorAccNum.Content = MainWindow.resourcemanager.GetString("trPopBankExist");
                        tb_accNumber.Background = (Brush)bc.ConvertFrom("#15FF0000");
                    }
                    else
                    {
                        bank.name = tb_name.Text;
                        bank.phone = phoneStr;
                        bank.mobile = cb_area.Text + "-" + tb_mobile.Text;
                        bank.address = tb_address.Text;
                        bank.accNumber = tb_accNumber.Text;
                        bank.notes = tb_notes.Text;
                        bank.createUserId = MainWindow.userID;
                        bank.updateUserId = MainWindow.userID;
                        bank.isActive = 1;

                        string s = await bankModel.saveBank(bank);

                        if (s.Equals("Bank Is Added Successfully")) //{SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null); }
                        {
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                            Btn_clear_Click(null, null);
                        }
                        else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                        await RefreshBanksList();
                        Tb_search_TextChanged(null, null);
                    }
                }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);

        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update"))
            {
                //chk empty name
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                //chk empty mobile
                SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
                //chk empty phone
                SectionData.validateEmptyTextBox(tb_phone, p_errorPhone, tt_errorPhone, "trEmptyPhoneToolTip");
                //chk empty acc
                SectionData.validateEmptyTextBox(tb_accNumber, p_errorAccNum, tt_errorAccNum, "trEmptyPhoneToolTip");
                string phoneStr = "";
                if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

                if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")) && (!tb_phone.Text.Equals("")) && (!tb_accNumber.Text.Equals("")))
                {
                    bool isBankExist = await chkDuplicateBank();
                    if (isBankExist)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopBankExist"), animation: ToasterAnimation.FadeIn);
                        p_errorName.Visibility = Visibility.Visible;
                        tt_errorName.Content = MainWindow.resourcemanager.GetString("trPopBankExist");
                        tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
                        p_errorAccNum.Visibility = Visibility.Visible;
                        tt_errorAccNum.Content = MainWindow.resourcemanager.GetString("trPopBankExist");
                        tb_accNumber.Background = (Brush)bc.ConvertFrom("#15FF0000");
                    }
                    else
                    {

                        bank.name = tb_name.Text;
                        bank.phone = phoneStr;
                        bank.mobile = cb_area.Text + "-" + tb_mobile.Text;
                        bank.address = tb_address.Text;
                        bank.accNumber = tb_accNumber.Text;
                        bank.notes = tb_notes.Text;
                        bank.createUserId = MainWindow.userID;
                        bank.updateUserId = MainWindow.userID;
                        bank.isActive = 1;

                        string s = await bankModel.saveBank(bank);

                        if (s.Equals("Bank Is Updated Successfully")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                        else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                        await RefreshBanksList();
                        Tb_search_TextChanged(null, null);

                        SectionData.getMobile(bank.mobile, cb_area, tb_mobile);

                        SectionData.getPhone(bank.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);
                    }
                }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete"))
            {
                if (bank.bankId != 0)
                {
                    if ((!bank.canDelete) && (bank.isActive == 0))
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
                        if (bank.canDelete)
                            w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                        if (!bank.canDelete)
                            w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                        w.ShowDialog();
                        Window.GetWindow(this).Opacity = 1;
                        #endregion
                        if (w.isOk)
                        {
                            string popupContent = "";
                            if (bank.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                            if ((!bank.canDelete) && (bank.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                            bool b = await bankModel.deleteBank(bank.bankId, MainWindow.userID.Value, bank.canDelete);

                            if (b) //SectionData.popUpResponse("", popupContent);
                                Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                            else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                        }

                    }
                    await RefreshBanksList();
                    Tb_search_TextChanged(null, null);
                }
                //clear textBoxs
                Btn_clear_Click(sender, e);
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);
        }

        private async void activate()
        {//activate
            bank.isActive = 1;

            string s = await bankModel.saveBank(bank);

            if (s.Equals("Bank Is Updated Successfully")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshBanksList();
            Tb_search_TextChanged(null, null);

        }
        private void Dg_bank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorMobile.Visibility = Visibility.Collapsed;
            p_errorPhone.Visibility = Visibility.Collapsed;


            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_phone.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_bank.SelectedIndex != -1)
            {
                bank = dg_bank.SelectedItem as Bank;
                this.DataContext = bank;

            }

            if (bank != null)
            {
                SectionData.getMobile(bank.mobile, cb_area, tb_mobile);

                SectionData.getPhone(bank.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                #region delete
                if (bank.canDelete)
                {
                    txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                    txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                }
                else
                {
                    if (bank.isActive == 0)
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

        private void tb_mobile_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
        }

        private void tb_mobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
        }

        private void tb_phone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_phone, p_errorPhone, tt_errorPhone, "trEmptyPhoneToolTip");
        }

        private void Tb_phone_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_phone, p_errorPhone, tt_errorPhone, "trEmptyPhoneToolTip");
        }

        private void Tb_mobile_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_accNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        void FN_ExportToExcel()
        {
            var QueryExcel = banksQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                AccNumber = x.accNumber,
                Mobile = x.mobile,
                Phone = x.phone,
                Address = x.address,
                Notes = x.notes
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trAccNum");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trMobile");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trPhone");
            DTForExcel.Columns[5].Caption = MainWindow.resourcemanager.GetString("trAddress");
            DTForExcel.Columns[5].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });

        }

        private async void Tgl_bankIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (banks is null)
                await RefreshBanksList();
            tgl_bankState = 1;
            Tb_search_TextChanged(null, null);
        }

        private async void Tgl_bankIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (banks is null)
                await RefreshBanksList();
            tgl_bankState = 0;
            Tb_search_TextChanged(null, null);
        }

        async Task<IEnumerable<Bank>> RefreshBanksList()
        {
            MainWindow.mainWindow.StartAwait();
            banks = await bankModel.GetBanksAsync();
            MainWindow.mainWindow.EndAwait();
            return banks;
        }
        void RefreshBankView()
        {
            dg_bank.ItemsSource = banksQuery;
            txt_count.Text = banksQuery.Count().ToString();

        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show"))
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                if (banks is null)
                    await RefreshBanksList();
                searchText = tb_search.Text.ToLower();
                banksQuery = banks.Where(s => (s.phone.Contains(searchText) ||
                s.name.ToLower().Contains(searchText) ||
                s.mobile.ToLower().Contains(searchText)
                ) && s.isActive == tgl_bankState);
                RefreshBankView();
            }
        }

        private void Cb_areaPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firstchange == true)
            {
                if (cb_areaPhone.SelectedValue != null)
                {
                    if (cb_areaPhone.SelectedIndex >= 0)
                        countryid = int.Parse(cb_areaPhone.SelectedValue.ToString());
                    if (citynum != null)
                    {
                        citynumofcountry = citynum.Where(b => b.countryId == countryid).OrderBy(b => b.cityCode).ToList();

                        cb_areaPhoneLocal.ItemsSource = citynumofcountry;
                        cb_areaPhoneLocal.SelectedValuePath = "cityId";
                        cb_areaPhoneLocal.DisplayMemberPath = "cityCode";
                        //cb_area.Text = "+963";
                        //cb_areaPhone.Text = "+963";
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
            }
            else
            {
                firstchange = true;
            }
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshBanksList();
            Tb_search_TextChanged(null, null);

        }

        private async Task<bool> chkDuplicateBank()
        {
            bool b = false;

            List<Bank> banks = await bankModel.GetBanksAsync();
            Bank bank1 = new Bank();

            for (int i = 0; i < banks.Count(); i++)
            {
                bank1 = banks[i];
                if ((bank1.name.Equals(tb_name.Text.Trim())) &&
                    (bank1.accNumber.Equals(tb_accNumber.Text.Trim())) &&
                    (bank1.bankId != bank.bankId))
                { b = true; break; }
            }

            return b;
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
                Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);
        }


        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report"))
            {
                ReportParameter[] paramarr = new ReportParameter[6];

                string addpath;
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    addpath = @"\Reports\SectionData\Ar\ArBankReport.rdlc";
                }
                else addpath = @"\Reports\SectionData\EN\BankReport.rdlc";
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.bankReport(banksQuery, rep, reppath);
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
                Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);
        }


        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report"))
            {
                ReportParameter[] paramarr = new ReportParameter[6];

                string addpath;
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    addpath = @"\Reports\SectionData\Ar\ArBankReport.rdlc";
                }
                else addpath = @"\Reports\SectionData\EN\BankReport.rdlc";
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                clsReports.bankReport(banksQuery, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();
                LocalReportExtensions.PrintToPrinter(rep);
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);
        }


        private void btn_pieChart_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report"))
            {
                Window.GetWindow(this).Opacity = 0.2;
                win_lvc win = new win_lvc(banksQuery, 2);
                win.ShowDialog();
                Window.GetWindow(this).Opacity = 1;
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: "you don't have permission", animation: ToasterAnimation.FadeIn);
        }

    }
}   

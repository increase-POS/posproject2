﻿using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace POS.View.sectionData
{
    /// <summary>
    /// Interaction logic for uc_shippingCompany.xaml
    /// </summary>
    public partial class uc_shippingCompany : UserControl
    {
        ShippingCompanies shCompany = new ShippingCompanies();
        ShippingCompanies shCompaniesModel = new ShippingCompanies();
        BrushConverter bc = new BrushConverter();
        IEnumerable<ShippingCompanies> shComQuery;
        IEnumerable<ShippingCompanies> shComs;
        byte tgl_shComState;
        string searchText = "";
        string basicsPermission = "shippingCompany_basics";
        private static uc_shippingCompany _instance;

        //phone variabels
        IEnumerable<CountryCode> countrynum;
        IEnumerable<City> citynum;
        IEnumerable<City> citynumofcountry;

        int? countryid;
        Boolean firstchange = false;
        Boolean firstchangefax = false;
        CountryCode countrycodes = new CountryCode();
        City cityCodes = new City();

        public static uc_shippingCompany Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_shippingCompany();
                return _instance;
            }
        }
        public uc_shippingCompany()
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
            { SectionData.ExceptionMessage(ex, this); }
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

            cb_areaMobile.ItemsSource = countrynum.ToList();
            cb_areaMobile.SelectedValuePath = "countryId";
            cb_areaMobile.DisplayMemberPath = "code";

            cb_areaFax.ItemsSource = countrynum.ToList();
            cb_areaFax.SelectedValuePath = "countryId";
            cb_areaFax.DisplayMemberPath = "code";

            cb_areaMobile.SelectedValue = MainWindow.Region.countryId;
            cb_areaPhone.SelectedValue = MainWindow.Region.countryId;
            cb_areaFax.SelectedValue = MainWindow.Region.countryId;

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

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    if (shComs is null)
                        await RefreshShComList();
                    searchText = tb_search.Text.ToLower();
                    shComQuery = shComs.Where(s => (s.name.ToLower().Contains(searchText) ||
                    s.deliveryType.Contains(searchText) ||
                    s.deliveryCost.ToString().ToLower().Contains(searchText) ||
                    s.RealDeliveryCost.ToString().ToLower().Contains(searchText)
                    ) && s.isActive == tgl_shComState);
                    RefreshshComView();
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

        async Task<IEnumerable<ShippingCompanies>> RefreshShComList()
        {
            shComs = await shCompaniesModel.Get();
            return shComs;
        }
        void RefreshshComView()
        {

            dg_shippingCompany.ItemsSource = shComQuery;
            txt_count.Text = shComQuery.Count().ToString();

        }
        private async void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {//active
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (shComs is null)
                    await RefreshShComList();
                tgl_shComState = 1;
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
        {//inactive
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (shComs is null)
                    await RefreshShComList();
                tgl_shComState = 0;
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

        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    await RefreshShComList();
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

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    Thread t1 = new Thread(() =>
                    {
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\SectionData\Ar\ArShippingReport.rdlc";
                        }
                        else addpath = @"\Reports\SectionData\EN\ShippingReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        ReportCls.checkLang();

                        clsReports.shippingReport(shComQuery, rep, reppath);
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


                    });
                    t1.Start();
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

            var QueryExcel = shComQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                RealDeliverCost = x.RealDeliveryCost,
                DeliveryCost = x.deliveryCost,
                DeliverType = x.deliveryType,
                Notes = x.notes
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trRealDeliveryCost");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trDeliveryCost");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trDeliveryType");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                tb_name.Clear();
                tb_realDeliveryCost.Clear();
                tb_deliveryCost.Clear();
                cb_deliveryType.SelectedIndex = -1;
                tb_notes.Clear();
                tb_address.Clear();
                tb_fax.Clear();
                tb_email.Clear();
                tb_mobile.Clear();
                tb_phone.Clear();
                cb_areaMobile.SelectedValue = MainWindow.Region.countryId;
                cb_areaPhone.SelectedIndex = MainWindow.Region.countryId;
                cb_areaFax.SelectedIndex = MainWindow.Region.countryId;


                SectionData.clearValidate(tb_name, p_errorName);
                SectionData.clearValidate(tb_deliveryCost, p_errorDeliveryCost);
                SectionData.clearValidate(tb_realDeliveryCost, p_errorRealDeliveryCost);
                SectionData.clearValidate(tb_email, p_errorEmail);
                SectionData.clearValidate(tb_mobile, p_errorMobile);
                SectionData.clearComboBoxValidate(cb_deliveryType, p_errorDeliveryType);
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

        private void validationControl_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
                var txb = sender as TextBox;
                if ((sender as TextBox).Name == "tb_realDeliveryCost" || (sender as TextBox).Name == "tb_deliveryCost")
                    SectionData.InputJustNumber(ref txb);
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                    #region validate
                    //chk empty name
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //chk empty mobile
                    SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
                    //validate email
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                    //chk empty delivery cost
                    SectionData.validateEmptyTextBox(tb_deliveryCost, p_errorDeliveryCost, tt_errorDeliveryCost, "trEmptyDeliveryCostToolTip");
                    //chk empty real delivery cost
                    SectionData.validateEmptyTextBox(tb_realDeliveryCost, p_errorRealDeliveryCost, tt_errorRealDeliveryCost, "trEmptyRealDeliveryCostToolTip");
                    //chk empty real delivery type
                    SectionData.validateEmptyComboBox(cb_deliveryType, p_errorDeliveryType, tt_errorDeliveryType, "trEmptyDeliveryTypeToolTip");

                    string phoneStr = "";
                    if (!tb_phone.Text.Equals(""))
                        phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;
                    string faxStr = "";
                    if (!tb_fax.Text.Equals(""))
                        faxStr = cb_areaFax.Text + "-" + cb_areaFaxLocal.Text + "-" + tb_fax.Text;
                    bool emailError = false;
                    if (!tb_email.Text.Equals(""))
                        if (!ValidatorExtensions.IsValid(tb_email.Text))
                            emailError = true;
                    #endregion
                    if ((!tb_name.Text.Equals("")) && (!tb_realDeliveryCost.Text.Equals("")) && (!tb_deliveryCost.Text.Equals("")) && (!cb_deliveryType.Text.Equals("")))
                    {
                        if (emailError)
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorEmailToolTip"), animation: ToasterAnimation.FadeIn);
                        else
                        {
                            ShippingCompanies shCom = new ShippingCompanies();

                            shCom.name = tb_name.Text;
                            shCom.RealDeliveryCost = decimal.Parse(tb_realDeliveryCost.Text);
                            shCom.deliveryCost = decimal.Parse(tb_deliveryCost.Text);
                            shCom.deliveryType = cb_deliveryType.SelectedValue.ToString();
                            shCom.balance = 0;
                            shCom.balanceType = 0;
                            shCom.notes = tb_notes.Text;
                            shCom.createUserId = MainWindow.userID;
                            shCom.isActive = 1;
                            shCom.email = tb_email.Text;
                            shCom.phone = phoneStr;
                            shCom.mobile = cb_areaMobile.Text + "-" + tb_mobile.Text;
                            shCom.fax = faxStr;
                            shCom.address = tb_address.Text;

                            string s = await shCompaniesModel.Save(shCom);
                           
                            if (!s.Equals("0"))
                            {
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                                Btn_clear_Click(null, null);

                                await RefreshShComList();
                                Tb_search_TextChanged(null, null);
                            }
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                        }
                    }
                    else
                        Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                    if (sender != null)
                        SectionData.EndAwait(grid_main);
                }
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    #region validate
                    //chk empty name
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //chk empty mobile
                    SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
                    //validate email
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                    //chk empty delivery cost
                    SectionData.validateEmptyTextBox(tb_deliveryCost, p_errorDeliveryCost, tt_errorDeliveryCost, "trEmptyDeliveryCostToolTip");
                    //chk empty real delivery cost
                    SectionData.validateEmptyTextBox(tb_realDeliveryCost, p_errorRealDeliveryCost, tt_errorRealDeliveryCost, "trEmptyRealDeliveryCostToolTip");
                    //chk empty real delivery type
                    SectionData.validateEmptyComboBox(cb_deliveryType, p_errorDeliveryType, tt_errorDeliveryType, "trEmptyDeliveryTypeToolTip");

                    string phoneStr = "";
                    if (!tb_phone.Text.Equals(""))
                        phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;
                    string faxStr = "";
                    if (!tb_fax.Text.Equals(""))
                        faxStr = cb_areaFax.Text + "-" + cb_areaFaxLocal.Text + "-" + tb_fax.Text;
                    bool emailError = false;
                    if (!tb_email.Text.Equals(""))
                        if (!ValidatorExtensions.IsValid(tb_email.Text))
                            emailError = true;

                    #endregion

                    if ((!tb_name.Text.Equals("")) && (!tb_realDeliveryCost.Text.Equals("")) && (!tb_deliveryCost.Text.Equals("")) && (!cb_deliveryType.Text.Equals("")))
                    {
                        if (emailError)
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorEmailToolTip"), animation: ToasterAnimation.FadeIn);
                        else
                        {
                            shCompany.name = tb_name.Text;
                            shCompany.RealDeliveryCost = decimal.Parse(tb_realDeliveryCost.Text);
                            shCompany.deliveryCost = decimal.Parse(tb_deliveryCost.Text);
                            shCompany.deliveryType = cb_deliveryType.SelectedValue.ToString();
                            shCompany.notes = tb_notes.Text;
                            shCompany.createUserId = MainWindow.userID;
                            shCompany.email = tb_email.Text;
                            shCompany.phone = phoneStr;
                            shCompany.mobile = cb_areaMobile.Text + "-" + tb_mobile.Text;
                            shCompany.fax = faxStr;
                            shCompany.address = tb_address.Text;

                            string s = await shCompaniesModel.Save(shCompany);

                            if (!s.Equals("0"))
                            {
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);

                                await RefreshShComList();
                                Tb_search_TextChanged(null, null);
                            }
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
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
                    if (shCompany.shippingCompanyId != 0)
                    {
                        if ((!shCompany.canDelete) && (shCompany.isActive == 0))
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
                            if (shCompany.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                            if (!shCompany.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                            w.ShowDialog();
                            Window.GetWindow(this).Opacity = 1;
                            #endregion

                            if (w.isOk)
                            {
                                string popupContent = "";
                                if (shCompany.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                                if ((!shCompany.canDelete) && (shCompany.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                                string b = await shCompaniesModel.Delete(shCompany.shippingCompanyId, MainWindow.userID.Value, shCompany.canDelete);

                                if (!b.Equals("0"))
                                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopDelete"), animation: ToasterAnimation.FadeIn);

                                else
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                            }
                        }

                        await RefreshShComList();
                        Tb_search_TextChanged(null, null);

                        //clear textBoxs
                        Btn_clear_Click(null, null);
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

        private async void activate()
        {//activate

            shCompany.isActive = 1;

            string s = await shCompaniesModel.Save(shCompany);

            if (!s.Equals("0"))
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshShComList();
            Tb_search_TextChanged(null, null);

        }

        private void Dg_shippingCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.clearValidate(tb_name, p_errorName);
                SectionData.clearValidate(tb_realDeliveryCost, p_errorRealDeliveryCost);
                SectionData.clearValidate(tb_deliveryCost, p_errorDeliveryCost);
                SectionData.clearValidate(tb_mobile , p_errorMobile);
                SectionData.clearValidate(tb_email , p_errorEmail);

                SectionData.clearComboBoxValidate(cb_deliveryType, p_errorDeliveryType);


                if (dg_shippingCompany.SelectedIndex != -1)
                {
                    shCompany = dg_shippingCompany.SelectedItem as ShippingCompanies;
                    this.DataContext = shCompany;

                    if (shCompany != null)
                    {
                        cb_deliveryType.SelectedValue = shCompany.deliveryType;

                        SectionData.getMobile(shCompany.mobile, cb_areaMobile, tb_mobile);

                        SectionData.getPhone(shCompany.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                        SectionData.getPhone(shCompany.fax, cb_areaFax, cb_areaFaxLocal, tb_fax);

                        #region delete
                        if (shCompany.canDelete)
                        {
                            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                            txt_delete_Icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Delete;
                            //tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");
                        }

                        else
                        {
                            if (shCompany.isActive == 0)
                            {
                                txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trActive");
                                txt_delete_Icon.Kind =
                                 MaterialDesignThemes.Wpf.PackIconKind.Check;
                                //tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trActive");
                            }
                            else
                            {
                                txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trInActive");
                                txt_delete_Icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Cancel;
                                //tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trInActive");
                            }
                        }
                        #endregion

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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                #region translate
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

                translat();
                #endregion

                #region fill delivery type
                var typelist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trLocaly")     , Value = "local" },
            new { Text = MainWindow.resourcemanager.GetString("trShippingCompany")   , Value = "com" },
             };
                cb_deliveryType.DisplayMemberPath = "Text";
                cb_deliveryType.SelectedValuePath = "Value";
                cb_deliveryType.ItemsSource = typelist;
                #endregion

                fillCountries();

                fillCity();

                await RefreshShComList();
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

        private void translat()
        {

            txt_active.Text = MainWindow.resourcemanager.GetString("trActive");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            txt_shippingCompany.Text = MainWindow.resourcemanager.GetString("trShippingCompanies");
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_realDeliveryCost, MainWindow.resourcemanager.GetString("trRealDeliveryCostHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_deliveryCost, MainWindow.resourcemanager.GetString("trDeliveryCostHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_deliveryType, MainWindow.resourcemanager.GetString("trDeliveryTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            txt_contactInformation.Text = MainWindow.resourcemanager.GetString("trContactInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            txt_moreInformation.Text = MainWindow.resourcemanager.GetString("trAnotherInfomation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_fax, MainWindow.resourcemanager.GetString("trFaxHint"));

            dg_shippingCompany.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_shippingCompany.Columns[1].Header = MainWindow.resourcemanager.GetString("trRealDeliveryCost");
            dg_shippingCompany.Columns[2].Header = MainWindow.resourcemanager.GetString("trDeliveryCost");
            dg_shippingCompany.Columns[3].Header = MainWindow.resourcemanager.GetString("trDeliveryType");

            //tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            //tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            //tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            //tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");


        }

        private void Tb_PreventSpaces(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;

        }

        private void Tb_Numbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void validateEmpty(string name, object sender)
        {
            try
            {
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_name")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    else if ((sender as TextBox).Name == "tb_realDeliveryCost")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorRealDeliveryCost, tt_errorRealDeliveryCost, "trEmptyRealDeliveryCostToolTip");
                    else if ((sender as TextBox).Name == "tb_deliveryCost")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorDeliveryCost, tt_errorDeliveryCost, "trEmptyDeliveryCostToolTip");
                }
                else if (name == "ComboBox")
                {
                    if ((sender as ComboBox).Name == "cb_deliveryType")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorDeliveryType, tt_errorDeliveryType, "trErrorEmptyDeliveryTypeToolTip");
                }
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\SectionData\Ar\ArShippingReport.rdlc";
                    }
                    else addpath = @"\Reports\SectionData\EN\ShippingReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.shippingReport(shComQuery, rep, reppath);
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

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\SectionData\Ar\ArShippingReport.rdlc";
                    }
                    else addpath = @"\Reports\SectionData\EN\ShippingReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.shippingReport(shComQuery, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();
                    LocalReportExtensions.PrintToPrinter(rep);
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

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
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
                addpath = @"\Reports\SectionData\Ar\ArShippingReport.rdlc";
            }
            else addpath = @"\Reports\SectionData\EN\ShippingReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.shippingReport(shComQuery, rep, reppath);
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
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void tb_phone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Cb_areaFax_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (firstchangefax == true)
                {
                    if (cb_areaFax.SelectedValue != null)
                    {
                        if (cb_areaFax.SelectedIndex >= 0)
                            countryid = int.Parse(cb_areaFax.SelectedValue.ToString());

                        citynumofcountry = citynum.Where(b => b.countryId == countryid).OrderBy(b => b.cityCode).ToList();

                        cb_areaFaxLocal.ItemsSource = citynumofcountry;
                        cb_areaFaxLocal.SelectedValuePath = "cityId";
                        cb_areaFaxLocal.DisplayMemberPath = "cityCode";
                        if (citynumofcountry.Count() > 0)
                        {

                            cb_areaFaxLocal.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            cb_areaFaxLocal.Visibility = Visibility.Collapsed;
                        }

                    }
                }
                else
                {
                    firstchangefax = true;
                }
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tb_fax_PreviewKeyDown(object sender, KeyEventArgs e)
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
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void tb_mobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void tb_mobile_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void tb_email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
    }
}

﻿using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace POS.View.setup
{
    /// <summary>
    /// Interaction logic for uc_FirstPosGeneralSettings.xaml
    /// </summary>
    public partial class uc_FirstPosGeneralSettings : UserControl
    {
        public uc_FirstPosGeneralSettings()
        {
            InitializeComponent();
        }

        private static uc_FirstPosGeneralSettings _instance;
        public static uc_FirstPosGeneralSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_FirstPosGeneralSettings();
                return _instance;
            }
        }
        SetValues setVMobile = new SetValues();
        public string serverUri { get; set; }
        public string activationkey { get; set; }
        static CountryCode region = new CountryCode();
        static CountryCode countryModel = new CountryCode();
        CountryCode countrycodes = new CountryCode();

        IEnumerable<CountryCode> countrynum;

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            #region get default region
            await fillRegions();
            await fillCountries();
            if (region != null)
            {
                //int index = cb_region.Items.IndexOf(region);
                //test.Text = index.ToString();
                cb_region.SelectedValue = region.countryId;
                cb_region.Text = region.name;
            }
            #endregion
            serverUri = activationkey = "";
        }
        private async Task fillRegions()
        {
            cb_region.ItemsSource = await countryModel.GetAllRegion();
            cb_region.DisplayMemberPath = "name";
            cb_region.SelectedValuePath = "countryId";
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

           
            cb_areaMobile.ItemsSource = countrynum.ToList();
            cb_areaMobile.SelectedValuePath = "countryId";
            cb_areaMobile.DisplayMemberPath = "code";
             
        }
        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);

                TextBox textBox = sender as TextBox;
                //if (textBox.Name.Equals("tb_serverUri"))
                //{
                //    serverUri = tb_serverUri.Text;

                //}
                //else if (textBox.Name.Equals("tb_activationkey"))
                //{
                //    activationkey = tb_activationkey.Text;
                //}
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Tb_validateEmptyTextChange(object sender, RoutedEventArgs e)
        {
            try
            {

                string name = sender.GetType().Name;
                validateEmpty(name, sender);

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                //if ((sender as TextBox).Name == "tb_serverUri")
                //    SectionData.validateEmptyTextBox_setupFirstPos(tb_serverUri, p_errorServerUri, tt_errorServerUri, "trEmptyError");
                //else if ((sender as TextBox).Name == "tb_activationkey")
                //    SectionData.validateEmptyTextBox_setupFirstPos(tb_activationkey, p_errorActivationkey, tt_errorActivationkey, "trEmptyError");
            }
            else if (name == "ComboBox")
            {
                //if ((sender as ComboBox).Name == "cb_paymentProcessType")
                //    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                //else if ((sender as ComboBox).Name == "cb_card")
                //    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
            }
        }
        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);

                ////save mobile
                //if (!tb_mobile.Text.Equals(""))
                //{
                //    setVMobile.value = cb_areaMobile.Text + "-" + tb_mobile.Text;
                //    setVMobile.isSystem = 1;
                //    setVMobile.isDefault = 1;
                //    setVMobile.settingId = mobileId;
                //    int sMobile = await valueModel.Save(setVMobile);
                //    if (!sMobile.Equals(0))
                //        MainWindow.Mobile = cb_areaMobile.Text + tb_mobile.Text;
                //}

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void P_showUserPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

                tb_userPassword.Text = pb_userPassword.Password;
                tb_userPassword.Visibility = Visibility.Visible;
                pb_userPassword.Visibility = Visibility.Collapsed;

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void P_showUserPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {


                tb_userPassword.Visibility = Visibility.Collapsed;
                pb_userPassword.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {//decimal
            try
            {
                var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
                if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                    e.Handled = false;

                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void tb_mobile_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //doesn't allow spaces into textbox
            e.Handled = e.Key == Key.Space;
        }

        private void Cb_region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

            region.countryId  = (int)cb_region.SelectedValue;
            cb_areaMobile.SelectedValue = region.countryId;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
    }
}

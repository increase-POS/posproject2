using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using Microsoft.Win32;
using System.Windows.Resources;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Text.RegularExpressions;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_companyInfo.xaml
    /// </summary>
    public partial class wd_companyInfo : Window
    {
        //phone variabels
        IEnumerable<CountryCode> countrynum;
        IEnumerable<City> citynum;
        IEnumerable<City> citynumofcountry;
        string imgFileName = "pic/no-image-icon-125x125.png";
        bool isImgPressed = false;

        int? countryid;
        Boolean firstchange = false;
        Boolean firstchangefax = false;
        CountryCode countrycodes = new CountryCode();
        City cityCodes = new City();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        ImageBrush brush = new ImageBrush();
        BrushConverter bc = new BrushConverter();
        int nameId, addressId, emailId, mobileId, phoneId, faxId , logoId;
        public wd_companyInfo()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            #region translate
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucCompanyInfo.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucCompanyInfo.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            #endregion

            #region get settings Ids
            List<SettingCls> settingsCls = await setModel.GetAll();
            List<SetValues> settingsValues = await valueModel.GetAll();

            SettingCls set = new SettingCls();
            SetValues setV = new SetValues();
            //get company name
            set = settingsCls.Where(s => s.name == "com_name").FirstOrDefault<SettingCls>();
            nameId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == nameId).FirstOrDefault();
            tb_name.Text = setV.value;
            //get company address
            set = settingsCls.Where(s => s.name == "com_address").FirstOrDefault<SettingCls>();
            addressId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == addressId).FirstOrDefault();
            tb_address.Text = setV.value;
            //get company email
            set = settingsCls.Where(s => s.name == "com_email").FirstOrDefault<SettingCls>();
            emailId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == emailId).FirstOrDefault();
            tb_email.Text = setV.value;
            //get company mobile
            set = settingsCls.Where(s => s.name == "com_mobile").FirstOrDefault<SettingCls>();
            mobileId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == mobileId).FirstOrDefault();
            tb_mobile.Text = setV.value;
            //get company phone
            set = settingsCls.Where(s => s.name == "com_phone").FirstOrDefault<SettingCls>();
            phoneId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == phoneId).FirstOrDefault();
            tb_phone.Text = setV.value;
            //get company fax
            set = settingsCls.Where(s => s.name == "com_fax").FirstOrDefault<SettingCls>();
            faxId = set.settingId;
            setV = settingsValues.Where(i => i.settingId == faxId).FirstOrDefault();
            tb_fax.Text = setV.value;
            //get company logo
            set = settingsCls.Where(s => s.name == "com_logo").FirstOrDefault<SettingCls>();
            logoId = set.settingId;
            //setV = settingsValues.Where(i => i.settingId == logoId).FirstOrDefault();
            //tb_fax.Text = setV.value;//getLogo();
            #endregion
        }
        private void translate()
        {
            txt_companyInfo.Text = MainWindow.resourcemanager.GetString("trComInfo");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_fax, MainWindow.resourcemanager.GetString("trFaxHint"));
            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
            tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
            tt_fax.Content = MainWindow.resourcemanager.GetString("trFax");
            tt_email.Content = MainWindow.resourcemanager.GetString("trEmail");
            tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

        }
        private void tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }

        private void tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }
        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
        }
        private void Tb_address_LostFocus(object sender, RoutedEventArgs e)
        {

        }
        private void Tb_mobile_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
        }

        private void tb_mobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
        }
        private void tb_mobile_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //doesn't allow spaces into textbox
            e.Handled = e.Key == Key.Space;
        }

        private void tb_phone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_fax_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void tb_email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void Cb_areaPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show(cb_areaPhone.SelectedValue.ToString());
            if (firstchange == true)
            {
                if (cb_areaPhone.SelectedValue != null)
                {
                    if (cb_areaPhone.SelectedIndex >= 0)
                        countryid = int.Parse(cb_areaPhone.SelectedValue.ToString());
                    // MessageBox.Show(cb_areaPhone.SelectedIndex.ToString());
                    // MessageBox.Show(countryid.ToString());
                    citynumofcountry = citynum.Where(b => b.countryId == countryid).OrderBy(b => b.cityCode).ToList();
                    //MessageBox.Show(citynumofcountry.Count().ToString());
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

            /*
           if (cb_areaPhone.SelectedValue > 0)
            {
                int countryid = (int)cb_areaPhone.SelectedValue;

        //    this.UserControl_Loaded.
                cb_areaPhoneLocal.ItemsSource = citylist.Where(b => b.countryId == countryid).ToList();
            cb_areaPhoneLocal.SelectedValuePath = "cityId";
            cb_areaPhoneLocal.DisplayMemberPath = "cityCode";
            }
            */
            // int countid = (int)cb_areaPhone.SelectedValue;

        }

        private void Cb_areaFax_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show(cb_areaPhone.SelectedValue.ToString());
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
        private void Img_customer_Click(object sender, RoutedEventArgs e)
        {//select image
            isImgPressed = true;
            openFileDialog.Filter = "Images|*.png;*.jpg;*.bmp;*.jpeg;*.jfif";
            if (openFileDialog.ShowDialog() == true)
            {
                brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                img_customer.Background = brush;
                imgFileName = openFileDialog.FileName;
            }
        }
        private void Tb_email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
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

            cb_areaMobile.SelectedIndex = 8;
            cb_areaPhone.SelectedIndex = 8;
            cb_areaFax.SelectedIndex = 8;
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
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //only int
            //Regex regex = new Regex("[^0-9]+");
            //e.Handled = regex.IsMatch(e.Text);

            //decimal
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;

            else
                e.Handled = true;
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }
        SettingCls setModel = new SettingCls();
        SetValues valueModel = new SetValues();
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save

            #region validate
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty address
            SectionData.validateEmptyTextBox(tb_address, p_errorAddress, tt_errorAddress, "trEmptyAddressToolTip");
            //chk empty email
            SectionData.validateEmptyTextBox(tb_email, p_errorEmail, tt_errorEmail, "trEmptyEmailToolTip");
            //chk empty mobile
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
            //chk empty phone
            SectionData.validateEmptyTextBox(tb_phone, p_errorPhone, tt_errorPhone, "trEmptyPhoneToolTip");
            //chk empty fax
            SectionData.validateEmptyTextBox(tb_fax, p_errorFax, tt_errorFax, "trEmptyFaxToolTip");
            #endregion

            #region save
            if ((!tb_name.Text.Equals("")) && (!tb_address.Text.Equals("")) &&
               (!tb_email.Text.Equals("")) && (!tb_mobile.Text.Equals("")) &&
               (!tb_phone.Text.Equals("")) && (!tb_fax.Text.Equals("")))
            {
                //save name
                SetValues valName = new SetValues();
                valName.value = tb_name.Text;
                valName.isSystem = 1;
                valName.settingId = nameId;
                //string sName = await valueModel.Save(valName);
                //MessageBox.Show("name : " + sName);

                //save address
                SetValues valAddress = new SetValues();
                valAddress.value = tb_address.Text;
                valAddress.isSystem = 1;
                valAddress.settingId = addressId;
                //string sAddress = await valueModel.Save(valAddress);
                //MessageBox.Show("address : " + sAddress);

                //save email
                SetValues valEmail = new SetValues();
                valEmail.value = tb_email.Text;
                valEmail.isSystem = 1;
                valEmail.settingId = emailId;
                //string sEmail = await valueModel.Save(valEmail);
                //MessageBox.Show("email : " + sEmail);

                //save mobile
                SetValues valMobile = new SetValues();
                valMobile.value = cb_areaMobile.Text + "-" + tb_mobile.Text;
                valMobile.isSystem = 1;
                valMobile.settingId = mobileId;
                //string sMobile = await valueModel.Save(valMobile);
                //MessageBox.Show("mobile : " + sMobile);

                //save mobile
                SetValues valPhone = new SetValues();
                valPhone.value = cb_areaPhone.Text + "-" + tb_name.Text;
                valPhone.isSystem = 1;
                valPhone.settingId = phoneId;
                //string sPhone = await valueModel.Save(valPhone);
                //MessageBox.Show("phone : " + sPhone);

                //save fax
                SetValues valFax = new SetValues();
                valFax.value = cb_areaFax.Text + "-" + tb_fax.Text;
                valFax.isSystem = 1;
                valFax.settingId = faxId;
                //string sFax = await valueModel.Save(valFax);
                //MessageBox.Show("fax : " + sFax);

                //save logo
                SetValues valLogo = new SetValues();
                valLogo.value = cb_areaFax.Text + "-" + tb_fax.Text;
                valLogo.isSystem = 1;
                valLogo.settingId = logoId;
                string sLogo = await valueModel.Save(valLogo);
                MessageBox.Show("logo : " + sLogo);
            }
            #endregion

        }
    }
}

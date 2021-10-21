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
using netoaster;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls.Primitives;

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
        int nameId = 0, addressId = 0, emailId = 0, mobileId = 0, phoneId = 0, faxId = 0, logoId = 0;
        SettingCls set = new SettingCls();
        SetValues setVName = new SetValues(); SetValues setVAddress = new SetValues(); SetValues setVEmail = new SetValues();
        SetValues setVMobile = new SetValues();
        SetValues setVPhone= new SetValues();
        SetValues setVFax = new SetValues();
        SetValues setVLogo = new SetValues();
        SettingCls setModel = new SettingCls();
        SetValues valueModel = new SetValues();

        public bool isFirstTime = false;
        public wd_companyInfo()
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
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await fillCountries();

                await fillCity();

                List<SettingCls> settingsCls = await setModel.GetAll();
                List<SetValues> settingsValues = await valueModel.GetAll();

                #region get settings Ids

                //get company name id
                set = settingsCls.Where(s => s.name == "com_name").FirstOrDefault<SettingCls>();
                nameId = set.settingId;
                setVName = settingsValues.Where(i => i.settingId == nameId).FirstOrDefault();
                //get company address id
                set = settingsCls.Where(s => s.name == "com_address").FirstOrDefault<SettingCls>();
                addressId = set.settingId;
                setVAddress = settingsValues.Where(i => i.settingId == addressId).FirstOrDefault();
                //get company email id
                set = settingsCls.Where(s => s.name == "com_email").FirstOrDefault<SettingCls>();
                emailId = set.settingId;
                setVEmail = settingsValues.Where(i => i.settingId == emailId).FirstOrDefault();
                //get company mobile id
                set = settingsCls.Where(s => s.name == "com_mobile").FirstOrDefault<SettingCls>();
                mobileId = set.settingId;
                setVMobile = settingsValues.Where(i => i.settingId == mobileId).FirstOrDefault();
                //get company phone id
                set = settingsCls.Where(s => s.name == "com_phone").FirstOrDefault<SettingCls>();
                phoneId = set.settingId;
                setVPhone = settingsValues.Where(i => i.settingId == phoneId).FirstOrDefault();
                //get company fax id
                set = settingsCls.Where(s => s.name == "com_fax").FirstOrDefault<SettingCls>();
                faxId = set.settingId;
                setVFax = settingsValues.Where(i => i.settingId == faxId).FirstOrDefault();
                //get company logo id
                set = settingsCls.Where(s => s.name == "com_logo").FirstOrDefault<SettingCls>();
                logoId = set.settingId;
                setVLogo = settingsValues.Where(i => i.settingId == logoId).FirstOrDefault();
                #endregion

                if (!isFirstTime)
                {
                    #region translate
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
                    #endregion

                    #region get values
                  
                    //get company name
                    tb_name.Text = setVName.value;
                    //get company address
                    tb_address.Text = setVAddress.value;
                    //get company email
                    tb_email.Text = setVEmail.value;
                    //get company mobile
                    SectionData.getMobile(setVMobile.value, cb_areaMobile, tb_mobile);
                    //get company phone
                    SectionData.getPhone(setVPhone.value, cb_areaPhone, cb_areaPhoneLocal, tb_phone);
                    //get company fax
                    SectionData.getPhone(setVFax.value, cb_areaFax, cb_areaFaxLocal, tb_fax);
                    //get company logo
                    await getImg();
                    #endregion

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
        private void translate()
        {
            txt_companyInfo.Text = MainWindow.resourcemanager.GetString("trComInfo");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_fax, MainWindow.resourcemanager.GetString("trFaxHint"));
            //tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            //tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
            //tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
            //tt_fax.Content = MainWindow.resourcemanager.GetString("trFax");
            //tt_email.Content = MainWindow.resourcemanager.GetString("trEmail");
            //tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
        }
      
        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if(isFirstTime)
                    validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                else
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
            }
            catch(Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
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

        private   void Cb_areaPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
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
                        if (citynum != null)
                        {
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
                }
                else
                {
                    firstchangefax = true;
                }
            }
            catch(Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Img_customer_Click(object sender, RoutedEventArgs e)
        {//select image
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                isImgPressed = true;
                openFileDialog.Filter = "Images|*.png;*.jpg;*.bmp;*.jpeg;*.jfif";
                if (openFileDialog.ShowDialog() == true)
                {
                    brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                    img_customer.Background = brush;
                    imgFileName = openFileDialog.FileName;
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
        private async Task fillCountries()
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

            //cb_areaMobile.SelectedIndex = 8;
            //cb_areaPhone.SelectedIndex = 8;
            //cb_areaFax.SelectedIndex = 8;
            cb_areaMobile.SelectedValue = MainWindow.Region.countryId;
            cb_areaPhone.SelectedValue = MainWindow.Region.countryId;
            cb_areaFax.SelectedValue = MainWindow.Region.countryId;
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

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch(Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }

        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch(Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }

        private void validateEmpty(string name, object sender)
        {
            try
            {
                if (!isFirstTime)
            {
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_name")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //else if ((sender as TextBox).Name == "tb_address")
                    //    SectionData.validateEmptyTextBox((TextBox)sender, p_errorAddress, tt_errorAddress, "trEmptyAddress");
                    //else if ((sender as TextBox).Name == "tb_email")
                    //    SectionData.validateEmptyTextBox((TextBox)sender, p_errorEmail, tt_errorEmail, "trEmptyEmailToolTip");
                    //else if ((sender as TextBox).Name == "tb_phone")
                    //    SectionData.validateEmptyTextBox((TextBox)sender, p_errorPhone, tt_errorPhone, "trEmptyPhoneToolTip");
                    else if ((sender as TextBox).Name == "tb_mobile")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
                    //else if ((sender as TextBox).Name == "tb_fax")
                    //    SectionData.validateEmptyTextBox((TextBox)sender, p_errorFax, tt_errorFax, "trEmptyFaxToolTip");
                }
            }
            else
            {
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_name")
                        validateEmptyTextBox((TextBox)sender, p_errorName, tt_errorName, "Name cann't be empty");
                    else if ((sender as TextBox).Name == "tb_mobile")
                        validateEmptyTextBox((TextBox)sender, p_errorMobile, tt_errorMobile, "Mobile number cann't be empty");
                }
            }
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

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
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
        private bool validateEmail(TextBox tb, System.Windows.Shapes.Path p_error, ToolTip tt_error)
        {
            bool isValid = true;
            if (!tb.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb.Text))
                {
                    p_error.Visibility = Visibility.Visible;
                    tt_error.Content = ("Email address is not valid");
                    tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
                    isValid = false;
                }
                else
                {
                    p_error.Visibility = Visibility.Collapsed;
                    tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                    isValid = true;
                }
            }
            return isValid;
        }
        public bool validateEmptyTextBox(TextBox tb, System.Windows.Shapes.Path p_error, ToolTip tt_error, string tr)
        {
            bool isValid = true;
            if (tb.Text.Equals(""))
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = (tr);
                tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
                isValid = false;
            }
            else
            {
                tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;
            }
            return isValid;
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region validate
                bool emailError = false;
                if (!isFirstTime)
                {
                    //chk empty name
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //validate email
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                    if (!tb_email.Text.Equals(""))
                        if (!ValidatorExtensions.IsValid(tb_email.Text))
                            emailError = true;
                    //chk empty mobile
                    SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
                }
                else
                {
                    //chk empty name
                    validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "Name cann't be empty");
                    //validate email
                    validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                    if (!tb_email.Text.Equals(""))
                        if (!ValidatorExtensions.IsValid(tb_email.Text))
                            emailError = true;
                    //chk empty mobile
                    validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "Mobile number cann't be empty");
                }
                #endregion

                #region save
                if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")) && !emailError)
                {
                    //save name
                    if (!tb_name.Text.Equals(""))
                    {
                        setVName.value = tb_name.Text;
                        setVName.isSystem = 1;
                        setVName.isDefault = 1;
                        setVName.settingId = nameId;
                       // string sName = await valueModel.Save(setVName);
                       int sName = await valueModel.Save(setVName);
                        if (!sName.Equals(0))
                            MainWindow.companyName = tb_name.Text;
                    }
                    //save address
                    if (!tb_address.Text.Equals(""))
                    {
                        setVAddress.value = tb_address.Text;
                        setVAddress.isSystem = 1;
                        setVAddress.isDefault = 1;
                        setVAddress.settingId = addressId;
                       int sAddress = await valueModel.Save(setVAddress);
                     //   string sAddress = await valueModel.Save(setVAddress);
                        if (!sAddress.Equals(0))
                            MainWindow.Address = tb_address.Text;
                    }
                    //save email
                    if ((!tb_email.Text.Equals("")) && (!emailError))
                    {
                        setVEmail.value = tb_email.Text;
                        setVEmail.isSystem = 1;
                        setVEmail.settingId = emailId;
                        setVEmail.isDefault = 1;
                      //  string sEmail = await valueModel.Save(setVEmail);
                        int sEmail = await valueModel.Save(setVEmail);
                        if (!sEmail.Equals(0))
                            MainWindow.Email = tb_email.Text;
                    }
                    //save mobile
                    if (!tb_mobile.Text.Equals(""))
                    {
                        setVMobile.value = cb_areaMobile.Text + "-" + tb_mobile.Text;
                        setVMobile.isSystem = 1;
                        setVMobile.isDefault = 1;
                        setVMobile.settingId = mobileId;
                        int sMobile = await valueModel.Save(setVMobile);
                        if (!sMobile.Equals(0))
                            MainWindow.Mobile = cb_areaMobile.Text + tb_mobile.Text;
                    }
                    //save phone
                    if (!tb_phone.Text.Equals(""))
                    {
                        setVPhone.value = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;
                        setVPhone.isSystem = 1;
                        setVPhone.isDefault = 1;
                        setVPhone.settingId = phoneId;
                       int sPhone = await valueModel.Save(setVPhone);
                        if (!sPhone.Equals(0))
                            MainWindow.Phone = cb_areaPhone.Text + cb_areaPhoneLocal.Text + tb_phone.Text;
                    }
                    //save fax
                    if (!tb_fax.Text.Equals(""))
                    {
                        setVFax.value = cb_areaFax.Text + "-" + cb_areaFaxLocal.Text + "-" + tb_fax.Text;
                        setVFax.isSystem = 1;
                        setVFax.isDefault = 1;
                        setVFax.settingId = faxId;
                       int sFax = await valueModel.Save(setVFax);
                        if (!sFax.Equals(0))
                            MainWindow.Fax = cb_areaFax.Text + cb_areaFaxLocal.Text + tb_fax.Text;

                    }
                    //  save logo
                    // image
                  //  string sLogo = "";
                    int sLogo =0;
                    if (isImgPressed)
                    {
                        isImgPressed = false;

                        setVLogo.value = sLogo.ToString();
                        setVLogo.isSystem = 1;
                        setVLogo.isDefault = 1;
                        setVLogo.settingId = logoId;
                        sLogo = await valueModel.Save(setVLogo);
                        if (!sLogo.Equals(0))
                        {
                            MainWindow.logoImage = setVLogo.value;
                            string b = await setVLogo.uploadImage(imgFileName, Md5Encription.MD5Hash("Inc-m" + sLogo), sLogo);
                            setVLogo.value = b;
                            sLogo = await valueModel.Save(setVLogo);
                            await valueModel.getImg(setVLogo.value);
                        }
                    }

                    #endregion
                    if (!isFirstTime)
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                        await Task.Delay(1500);
                    }
                    this.Close();
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
        private async Task getImg()
        {
            try
            {
                if (string.IsNullOrEmpty(setVLogo.value))
                {
                    SectionData.clearImg(img_customer);
                }
                else
                {
                    byte[] imageBuffer = await setVLogo.downloadImage(setVLogo.value); // read this as BLOB from your DB

                    var bitmapImage = new BitmapImage();
                    if (imageBuffer != null)
                    {
                        using (var memoryStream = new MemoryStream(imageBuffer))
                        {
                            bitmapImage.BeginInit();
                            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                            bitmapImage.StreamSource = memoryStream;
                            bitmapImage.EndInit();
                        }

                        img_customer.Background = new ImageBrush(bitmapImage);
                        // configure trmporary path
                        string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        string tmpPath = System.IO.Path.Combine(dir, Global.TMPAgentsFolder);
                        tmpPath = System.IO.Path.Combine(tmpPath, setVLogo.value);
                        openFileDialog.FileName = tmpPath;
                    }
                    else
                        SectionData.clearImg(img_customer);
                }
            }
            catch { }
        }

    }
}

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
        //int nameValueId = 0, addressValueId = 0, emailValueId = 0, mobileValueId = 0, phoneValueId = 0, faxValueId = 0, logoValueId = 0;
        SettingCls set = new SettingCls();
        SetValues setVName = new SetValues(); SetValues setVAddress = new SetValues(); SetValues setVEmail = new SetValues();
        SetValues setVMobile = new SetValues(); SetValues setVPhone= new SetValues(); SetValues setVFax = new SetValues();
        SetValues setVLogo = new SetValues();
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

            fillCountries();

            fillCity();

            #region get settings Ids
            List<SettingCls> settingsCls = await setModel.GetAll();
            List<SetValues> settingsValues = await valueModel.GetAll();

            //get company name
            set = settingsCls.Where(s => s.name == "com_name").FirstOrDefault<SettingCls>();
            nameId = set.settingId;
            setVName = settingsValues.Where(i => i.settingId == nameId).FirstOrDefault();
            tb_name.Text = setVName.value;
            //get company address
            set = settingsCls.Where(s => s.name == "com_address").FirstOrDefault<SettingCls>();
            addressId = set.settingId;
            setVAddress = settingsValues.Where(i => i.settingId == addressId).FirstOrDefault();
            tb_address.Text = setVAddress.value;
            //get company email
            set = settingsCls.Where(s => s.name == "com_email").FirstOrDefault<SettingCls>();
            emailId = set.settingId;
            setVEmail = settingsValues.Where(i => i.settingId == emailId).FirstOrDefault();
            tb_email.Text = setVEmail.value;
            //get company mobile
            set = settingsCls.Where(s => s.name == "com_mobile").FirstOrDefault<SettingCls>();
            mobileId = set.settingId;
            setVMobile = settingsValues.Where(i => i.settingId == mobileId).FirstOrDefault();
            SectionData.getMobile(setVMobile.value, cb_areaMobile, tb_mobile);
            //get company phone
            set = settingsCls.Where(s => s.name == "com_phone").FirstOrDefault<SettingCls>();
            phoneId = set.settingId;
            setVPhone = settingsValues.Where(i => i.settingId == phoneId).FirstOrDefault();
            SectionData.getPhone(setVPhone.value, cb_areaPhone, cb_areaPhoneLocal, tb_phone);
            //get company fax
            set = settingsCls.Where(s => s.name == "com_fax").FirstOrDefault<SettingCls>();
            faxId = set.settingId;
            setVFax = settingsValues.Where(i => i.settingId == faxId).FirstOrDefault();
            SectionData.getPhone(setVFax.value, cb_areaFax, cb_areaFaxLocal, tb_fax);
            //get company logo
            set = settingsCls.Where(s => s.name == "com_logo").FirstOrDefault<SettingCls>();
            logoId = set.settingId;
            setVLogo = settingsValues.Where(i => i.settingId == logoId).FirstOrDefault();
            //tb_fax.Text = setV.value;//getLogo();
          await  getImg();
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
      
        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
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
        private async void Cb_areaPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                    if (citynum != null)
                    {
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
            }
            else
            {
                firstchange = true;
            }

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

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }

        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }

        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_name")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorName, tt_errorName, "trEmptyNameToolTip");
                else if ((sender as TextBox).Name == "tb_address")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorAddress, tt_errorAddress, "trEmptyAddress");
                else if ((sender as TextBox).Name == "tb_email")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorEmail, tt_errorEmail, "trEmptyEmailToolTip");
                else if ((sender as TextBox).Name == "tb_phone")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorPhone, tt_errorPhone, "trEmptyPhoneToolTip");
                else if ((sender as TextBox).Name == "tb_mobile")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
                else if ((sender as TextBox).Name == "tb_fax")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorFax, tt_errorFax, "trEmptyFaxToolTip");
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
            //validate email
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
            bool emailError = false;
            if (!tb_email.Text.Equals(""))
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                    emailError = true;
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
               (!tb_phone.Text.Equals("")) && (!tb_fax.Text.Equals("")) &&
               !emailError)
            {
                //save name
                setVName.value = tb_name.Text;
                setVName.isSystem = 1;
                setVName.isDefault = 1;
                setVName.settingId = nameId;
                string sName = await valueModel.Save(setVName);
                //MessageBox.Show("name : " + sName);

                //save address
                setVAddress.value = tb_address.Text;
                setVAddress.isSystem = 1;
                setVAddress.isDefault = 1;
                setVAddress.settingId = addressId;
                string sAddress = await valueModel.Save(setVAddress);
                //MessageBox.Show("address : " + sAddress);

                //save email
                setVEmail.value = tb_email.Text;
                setVEmail.isSystem = 1;
                setVEmail.settingId = emailId;
                setVEmail.isDefault = 1;
                string sEmail = await valueModel.Save(setVEmail);
                //MessageBox.Show("email : " + sEmail);

                //save mobile
                setVMobile.value = cb_areaMobile.Text + "-" + tb_mobile.Text;
                setVMobile.isSystem = 1;
                setVMobile.isDefault = 1;
                setVMobile.settingId = mobileId;
                string sMobile = await valueModel.Save(setVMobile);
                //MessageBox.Show("mobile : " + sMobile);

                //save phone
                setVPhone.value = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;
                setVPhone.isSystem = 1;
                setVPhone.isDefault = 1;
                setVPhone.settingId = phoneId;
                string sPhone = await valueModel.Save(setVPhone);
                //MessageBox.Show("phone : " + sPhone);

                //save fax
                setVFax.value = cb_areaFax.Text + "-" + cb_areaFaxLocal.Text + "-" + tb_fax.Text;
                setVFax.isSystem = 1;
                setVFax.isDefault = 1;
                setVFax.settingId = faxId;
                string sFax = await valueModel.Save(setVFax);
                //MessageBox.Show("fax : " + sFax);

                //  save logo
                // image
                string sLogo = "";
                if (isImgPressed)
                {
                    int valId = setVLogo.valId;
                    string b = await setVLogo.uploadImage(imgFileName, Md5Encription.MD5Hash("Inc-m" + valId.ToString()), valId);
                    setVLogo.value = b;
                    isImgPressed = false;
                    if (!b.Equals(""))
                    {

                        setVLogo.value = b;
                        setVLogo.isSystem = 1;
                        setVLogo.isDefault = 1;
                        setVLogo.settingId = logoId;
                        sLogo = await valueModel.Save(setVLogo);

                        // brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                        // img_user.Background = brush;
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ في تحميل الصورة");
                    }
                }
                
                //MessageBox.Show("logo : " + sLogo);

                if ((!sName.Equals("0")) && (!sAddress.Equals("0")) && (!sEmail.Equals("0")) && (!sMobile.Equals("0")) && (!sPhone.Equals("")) && (!sFax.Equals("")))
                {
                    MainWindow.companyName = tb_name.Text;
                    MainWindow.Address = tb_address.Text;
                    MainWindow.Mobile = cb_areaMobile.Text + tb_mobile.Text;
                    MainWindow.Email = tb_email.Text;
                    MainWindow.Fax = cb_areaPhone.Text + cb_areaPhoneLocal.Text + tb_phone.Text;
                    MainWindow.Phone = cb_areaPhone.Text + cb_areaPhoneLocal.Text + tb_phone.Text;
                    MainWindow.logoImage = setVLogo.value;
                    await valueModel.getImg(setVLogo.value);

                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                    await Task.Delay(1500);
                    this.Close();
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);


              
            }
            #endregion

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

                        ////////ImageSourceConverter c = new ImageSourceConverter();
                        ////////img_user.Source = (ImageSource)c.ConvertFrom(bitmapImage);

                        ////////////////using (MemoryStream memory = new MemoryStream())
                        ////////////////{
                        ////////////////    //bitmapImage.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                        ////////////////    memory.Position = 0;
                        ////////////////    BitmapImage bitmapimage = new BitmapImage();
                        ////////////////    bitmapimage.BeginInit();
                        ////////////////    bitmapimage.StreamSource = memory;
                        ////////////////    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        ////////////////    bitmapimage.EndInit();
                        ////////////////    img_user.Source = new Uri bitmapimage;
                        ////////////////}
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

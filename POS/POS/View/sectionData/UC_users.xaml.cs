using Microsoft.Win32;
using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
using System.Windows.Resources;
using System.Windows.Shapes;
using Microsoft.Reporting.WinForms;
using POS.View.windows;
using POS.View.sectionData.Charts;
using System.Windows.Interop;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_users.xaml
    /// </summary>
    public partial class UC_users : UserControl
    {
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();

        User userModel = new User();

        User user = new User();

        IEnumerable<User> usersQuery;
        IEnumerable<User> users;
        byte tgl_userState;
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

        OpenFileDialog openFileDialog = new OpenFileDialog();

        ImageBrush brush = new ImageBrush();

        int index = 0;

        string imgFileName = "pic/no-image-icon-125x125.png";

        bool isImgPressed = false;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        private static UC_users _instance;
        public static UC_users Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_users();
                return _instance;
            }
        }
        public UC_users()
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

            cb_areaMobile.ItemsSource = countrynum.ToList();
            cb_areaMobile.SelectedValuePath = "countryId";
            cb_areaMobile.DisplayMemberPath = "code";


            cb_areaMobile.SelectedIndex = 8;
            cb_areaPhone.SelectedIndex = 8;
            //cb_areaFax.SelectedIndex = 8;
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

        private async void fillJobCombo()
        {
            if (users == null) users = await userModel.GetUsersAsync();
            usersQuery = users.Where(s => s.isActive == 1);
            List<User> userList = new List<User>();
            userList.AddRange(usersQuery.ToList());
            for (int i = 0; i < userList.Count(); i++)
                if (!cb_job.Items.Contains(userList[i].job))
                    cb_job.Items.Add(userList[i].job);
        }

        private async Task<bool> chkIfUserNameIsExists(string username , int uId)
        {
            if (users == null) users = await userModel.GetUsersAsync();
            bool b = false;

            //List<User> userList = new List<User>();
            //userList.AddRange(users.ToList());

            //for (int i = 0; i < userList.Count(); i++)
            //    if ((userList[i].username.Equals(username)) && (userList[i].userId != uId))
            //    { b = true; break; }
            if (users.Any(i => i.username == username && i.userId != uId))
                b = true;
            else b = false;

            return b;
        }

        private bool chkPasswordLength(string password)
        {
           bool b = false;
            if (password.Length < 6)
                b = true;
           return b;
        }

        //end areacod
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
     
        private void translate()
        {
            txt_user.Text = MainWindow.resourcemanager.GetString("trUser");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            txt_userInfomration.Text = MainWindow.resourcemanager.GetString("trUserInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_firstName, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_lastName, MainWindow.resourcemanager.GetString("trLastNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(pb_password, MainWindow.resourcemanager.GetString("trPasswordHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            txt_workInformation.Text = MainWindow.resourcemanager.GetString("trWorkInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_job, MainWindow.resourcemanager.GetString("trJobHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_workHours, MainWindow.resourcemanager.GetString("trWorkHoursHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_details, MainWindow.resourcemanager.GetString("trNoteHint"));
            txt_loginInformation.Text = MainWindow.resourcemanager.GetString("trLoginInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_userName, MainWindow.resourcemanager.GetString("trUserNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_password, MainWindow.resourcemanager.GetString("trPasswordHint"));
            txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            dg_users.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            //dg_users.Columns[1].Header = MainWindow.resourcemanager.GetString("trLastName");
            dg_users.Columns[1].Header = MainWindow.resourcemanager.GetString("trJob");
            dg_users.Columns[2].Header = MainWindow.resourcemanager.GetString("trWorkHours");
            dg_users.Columns[3].Header = MainWindow.resourcemanager.GetString("trNote");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_lastName.Content = MainWindow.resourcemanager.GetString("trLastName");
            tt_job.Content = MainWindow.resourcemanager.GetString("trJob");
            tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
            tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
            tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_workHours.Content = MainWindow.resourcemanager.GetString("trWorkHours");
            tt_userName.Content = MainWindow.resourcemanager.GetString("trUserName");
            tt_password.Content = MainWindow.resourcemanager.GetString("trPassword");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear

            user.userId = 0;
            tb_address.Clear();
            tb_password.Clear();
            tb_userName.Clear();
            pb_password.Clear();
            tb_firstName.Clear();
            tb_lastName.Clear();
            cb_job.SelectedIndex = -1;
            tb_workHours.Clear();
            tb_details.Clear();
            tb_phone.Clear();
            cb_areaMobile.SelectedIndex = 8;
            cb_areaPhone.SelectedIndex = 8;
            tb_mobile.Clear();
            tb_email.Clear();
            //clear img
            Uri resourceUri = new Uri("pic/no-image-icon-125x125.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            img_user.Background = brush;
            //img_user.Source = new BitmapImage(new Uri("pic/no-image-icon-125x125.png"));

            btn_stores.IsEnabled = false;

            p_errorFirstName.Visibility = Visibility.Collapsed;
            p_errorLastName.Visibility = Visibility.Collapsed;
            p_errorUserName.Visibility = Visibility.Collapsed;
            p_errorPassword.Visibility = Visibility.Collapsed;
            p_errorJob.Visibility = Visibility.Collapsed;

            tb_firstName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_lastName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_userName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            cb_job.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            SectionData.clearValidate(tb_mobile , p_errorMobile);
            SectionData.clearPasswordValidate(pb_password, p_errorPassword);
            p_showPassword.Visibility = Visibility.Visible;
        }
        private  void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            btn_stores.IsEnabled = false;
            // for pagination onTop Always
            btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            //CreateGridCardContainer();
            catigoriesAndItemsView.ucUsers = this;


            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucUsers.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucUsers.FlowDirection = FlowDirection.RightToLeft; }

            translate();

            Keyboard.Focus(tb_firstName);

            //var users = await userModel.GetUsersAsync();
            //dg_users.ItemsSource = users;

            //fill job combo
            fillJobCombo();
           

           
            fillCountries();

            fillCity();

            this.Dispatcher.Invoke(() =>
            {
                Tb_search_TextChanged(null, null);
            });
        }

        #region Numeric


        private int _numValue = 0;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                tb_workHours.Text = value.ToString();
            }
        }



        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void tb_discountValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_workHours == null)
            {
                return;
            }

            if (!int.TryParse(tb_workHours.Text, out _numValue))
                tb_workHours.Text = _numValue.ToString();
        }

        private void tb_discountValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        #endregion

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            user.userId = 0;

            //chk empty name
            SectionData.validateEmptyTextBox(tb_firstName, p_errorFirstName, tt_errorFirstName, "trEmptyNameToolTip");
            //chk empty last name
            SectionData.validateEmptyTextBox(tb_lastName, p_errorLastName, tt_errorLastName, "trEmptyLastNameToolTip");
            //chk empty job
            SectionData.validateEmptyComboBox(cb_job, p_errorJob, tt_errorJob, "trEmptyJobToolTip");
            //chk empty mobile
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
            //chk empty username
            SectionData.validateEmptyTextBox(tb_userName, p_errorUserName, tt_errorUserName, "trEmptyUserNameToolTip");
            //chk empty password
            //SectionData.validateEmptyTextBox(tb_password, p_errorPassword, tt_errorPassword, "trEmptyPasswordToolTip");
            //if (tb_password.Text.Equals(""))
            //{ p_showPassword.Visibility = Visibility.Collapsed; pb_password.Background = (Brush)bc.ConvertFrom("#15FF0000"); }
            if (pb_password.Password.Equals(""))
            { SectionData.showPasswordValidate(pb_password, p_errorPassword, tt_errorPassword, "trEmptyPasswordToolTip"); p_showPassword.Visibility = Visibility.Collapsed; }
            //validate email
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
            //chk duplicate userName
            bool duplicateUserName = false;
            duplicateUserName = await chkIfUserNameIsExists(tb_userName.Text , 0);
            //chk password length
            bool passLength = false;
            passLength = chkPasswordLength(pb_password.Password);
            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

            bool emailError = false;

            if (!tb_email.Text.Equals(""))
                if (!SectionData.IsValid(tb_email.Text))
                    emailError = true;

            if ((!tb_firstName.Text.Equals("")) && (!tb_lastName.Text.Equals("")) && (!tb_userName.Text.Equals("")) &&
                                                   (!tb_mobile.Text.Equals("")) &&
                                                   (!pb_password.Password.Equals("")) && (!cb_job.Text.Equals("")))
            {
                if ((emailError) || (duplicateUserName) || (passLength))
                {
                    if (emailError)
                        SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                    if (duplicateUserName)
                    {
                        p_errorUserName.Visibility = Visibility.Visible;
                        tt_errorUserName.Content = MainWindow.resourcemanager.GetString("trErrorDuplicateUserNameToolTip");
                        tb_userName.Background = (Brush)bc.ConvertFrom("#15FF0000");
                    }
                    if (passLength)
                    {
                        p_errorPassword.Visibility = Visibility.Visible;
                        p_showPassword.Visibility = Visibility.Collapsed;
                        tt_errorPassword.Content = MainWindow.resourcemanager.GetString("trErrorPasswordLengthToolTip");
                        tb_password.Background = (Brush)bc.ConvertFrom("#15FF0000");
                        pb_password.Background = (Brush)bc.ConvertFrom("#15FF0000");
                    }
                }
                else
                {
                    tb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                    pb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                    user.username = tb_userName.Text;
                    //user.password = pb_password.Password;
                    user.password = Md5Encription.MD5Hash("Inc-m" + pb_password.Password);
                    user.name = tb_firstName.Text;
                    user.lastname = tb_lastName.Text;
                    user.job = cb_job.Text;
                    user.workHours = tb_workHours.Text;
                    user.details = "";
                    user.phone = phoneStr;
                    user.mobile = cb_areaMobile.Text + "-" + tb_mobile.Text;
                    user.email = tb_email.Text;
                    user.address = tb_address.Text;
                    user.isActive = 1;
                    user.createUserId = MainWindow.userID.Value;
                    user.updateUserId = MainWindow.userID.Value;
                    user.notes = tb_details.Text;
                    user.role = "";

                    string s = await userModel.saveUser(user);
                    //if (s.Equals("User Is Added Successfully")) { //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null); }
                    if (!s.Equals("0"))  //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null);  
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                        Btn_clear_Click(null, null);
                    }
                    else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    if (isImgPressed)
                    {
                        int userId = int.Parse(s);
                        bool b = await userModel.uploadImage(imgFileName, Md5Encription.MD5Hash("Inc-m" + userId.ToString()), userId);
                        isImgPressed = false;
                        if (b)
                        {
                            brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                            img_user.Background = brush;
                        }
                        else
                        {
                            MessageBox.Show("حدث خطأ في تحميل الصورة");
                        }
                    }

                    await RefreshUsersList();
                    Tb_search_TextChanged(null, null);

                    fillJobCombo();

                    SectionData.getMobile(user.mobile, cb_areaMobile, tb_mobile);

                    SectionData.getPhone(user.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                }
            }
        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
         //var user1 = new User();
          
            //chk empty name
            SectionData.validateEmptyTextBox(tb_firstName, p_errorFirstName, tt_errorFirstName, "trEmptyNameToolTip");
            //chk empty last name
            SectionData.validateEmptyTextBox(tb_lastName, p_errorLastName, tt_errorLastName, "trEmptyLastNameToolTip");
            //chk empty mobile
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
            //chk empty job
            SectionData.validateEmptyComboBox(cb_job, p_errorJob, tt_errorJob, "trEmptyJobToolTip");
            //chk empty username
            SectionData.validateEmptyTextBox(tb_userName, p_errorUserName, tt_errorUserName, "trEmptyUserNameToolTip");
            //chk empty password
            //SectionData.validateEmptyTextBox(tb_password, p_errorPassword, tt_errorPassword, "trEmptyPasswordToolTip");
            //if (tb_password.Text.Equals(""))
            //{ p_showPassword.Visibility = Visibility.Collapsed; pb_password.Background = (Brush)bc.ConvertFrom("#15FF0000"); }
            if (pb_password.Password.Equals(""))
            { SectionData.showPasswordValidate(pb_password, p_errorPassword, tt_errorPassword, "trEmptyPasswordToolTip"); p_showPassword.Visibility = Visibility.Collapsed; }
            //validate email
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
            //chk duplicate userName
            bool duplicateUserName = false;
            duplicateUserName = await chkIfUserNameIsExists(tb_userName.Text , user.userId);

            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

            bool emailError = false;

            if (!tb_email.Text.Equals(""))
                if (!SectionData.IsValid(tb_email.Text))
                    emailError = true;

            if ((!tb_firstName.Text.Equals("")) && (!tb_lastName.Text.Equals("")) && (!tb_userName.Text.Equals("")) && (!cb_job.Text.Equals("")) && (!tb_mobile.Text.Equals("")))
            {
                if ((emailError) || (duplicateUserName))
                {
                    if (emailError)
                        SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                    if (duplicateUserName)
                    {
                        p_errorUserName.Visibility = Visibility.Visible;
                        tt_errorUserName.Content = MainWindow.resourcemanager.GetString("trErrorDuplicateUserNameToolTip");
                        tb_userName.Background = (Brush)bc.ConvertFrom("#15FF0000");
                    }
                }
                else
                {
                    tb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                    pb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                    user.userId = user.userId;
                    user.username = tb_userName.Text;
                    //user.password = pb_password.Password;//password update is not valid
                    user.name = tb_firstName.Text;
                    user.lastname = tb_lastName.Text;
                    user.job = cb_job.Text;
                    user.workHours = tb_workHours.Text;
                    user.details = "";
                    user.phone = phoneStr;
                    user.mobile = cb_areaMobile.Text + "-" + tb_mobile.Text;
                    user.email = tb_email.Text;
                    user.address = tb_address.Text;
                    user.isActive = 1;
                    user.isOnline = 1;
                    user.createUserId = MainWindow.userID.Value;
                    user.updateUserId = MainWindow.userID.Value;
                    user.notes = tb_details.Text;
                    user.role = "";

                    string s = await userModel.saveUser(user);
                    
                    //if (s.Equals("User Is Updated Successfully")) { //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate")); Btn_clear_Click(null, null); }
                    if (!s.Equals("0"))   //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));   
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                    else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    await RefreshUsersList();
                    Tb_search_TextChanged(null, null);

                    if (isImgPressed)
                    {
                        int userId = int.Parse(s);
                        bool b = await userModel.uploadImage(imgFileName, Md5Encription.MD5Hash("Inc-m" + userId.ToString()), userId);
                        isImgPressed = false;
                        if (b)
                        {
                            //MessageBox.Show("uploaded");
                            //dg_users.Items.Refresh();
                            //brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                            //img_user.Background = brush;
                            getImg();
                        }
                        else
                        {
                            SectionData.clearImg(img_user);
                            MessageBox.Show("حدث خطأ في تحميل الصورة");
                        }
                    }
                   
                    SectionData.getMobile(user.mobile, cb_areaMobile, tb_mobile);

                    SectionData.getPhone(user.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                    fillJobCombo();

                }
            }
        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if (user.userId != 0)
            {

                if ((!user.canDelete) && (user.isActive == 0))
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
                    if (user.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                    if (!user.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                    {
                        string popupContent = "";
                        if (user.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                        if ((!user.canDelete) && (user.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");
                        bool b = await userModel.deleteUser(user.userId, MainWindow.userID.Value, user.canDelete);

                        if (b) //SectionData.popUpResponse("", popupContent);
                            Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                        else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }

                await RefreshUsersList();
                Tb_search_TextChanged(null, null);

                fillJobCombo();
            }

            //clear textBoxs
            Btn_clear_Click(sender, e);
        }

        private async void activate()
        {//activate
            user.isActive = 1;

            string s = await userModel.saveUser(user);

            if (s.Equals("User Is Updated Successfully")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshUsersList();
            Tb_search_TextChanged(null, null);

        }

        private void Tb_userName_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_userName, p_errorUserName, tt_errorUserName, "trEmptyUserNameToolTip");
        }

        private void Tb_userName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_userName, p_errorUserName, tt_errorUserName, "trEmptyUserNameToolTip");
        }
        private void Tb_password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pb_password.Password.Equals(""))
            {
                p_errorPassword.Visibility = Visibility.Visible;
                tt_errorPassword.Content = MainWindow.resourcemanager.GetString("trEmptyPasswordToolTip");
                pb_password.Background = (Brush)bc.ConvertFrom("#15FF0000");
                p_showPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                pb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_errorPassword.Visibility = Visibility.Collapsed;
                p_showPassword.Visibility = Visibility.Visible;
            }
        }

        private void Tb_firstName_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_firstName, p_errorFirstName, tt_errorFirstName, "trEmptyNameToolTip");
        }

        private void Tb_firstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_firstName, p_errorFirstName, tt_errorFirstName, "trEmptyFirstNameToolTip");
        }
        private void Tb_lastName_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_lastName, p_errorLastName, tt_errorLastName, "trEmptyLastNameToolTip");
        }

        private void Tb_lastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_lastName, p_errorLastName, tt_errorLastName, "trEmptyLastNameToolTip");
        }

        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
        }
        private void Cb_job_LostFocus(object sender, RoutedEventArgs e)
        {
            if (x == 0)
                 SectionData.validateEmptyComboBox(cb_job, p_errorJob, tt_errorJob, "trEmptyJobToolTip");
        }
        private void P_showPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_password.Text = pb_password.Password;
            tb_password.Visibility = Visibility.Visible;
            pb_password.Visibility = Visibility.Collapsed;
        }

        private void P_showPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_password.Visibility = Visibility.Collapsed;
            pb_password.Visibility = Visibility.Visible;
        }

        async Task<IEnumerable<User>> RefreshUsersList()
        {
            MainWindow.mainWindow.StartAwait();
            users = await userModel.GetUsersAsync();
            MainWindow.mainWindow.EndAwait();
            return users;
        }
        void RefreshUserView()
        {
            dg_users.ItemsSource = usersQuery;
            txt_count.Text = usersQuery.Count().ToString();
        }

       

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
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
            var QueryExcel = usersQuery.AsEnumerable().Select(x => new
            {
                Name     = x.name,
                LastName = x.lastname,
                Job      = x.job,
                WorkHours= x.workHours,
                Mobile   = x.mobile,
                Phone    = x.phone,
                Address  = x.address,
                Notes    = x.notes,
                UserName = x.username,
                Password = x.password
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trLastName");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trJob");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trWorkHours");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trMobile");
            DTForExcel.Columns[5].Caption = MainWindow.resourcemanager.GetString("trPhone");
            DTForExcel.Columns[6].Caption = MainWindow.resourcemanager.GetString("trAddress");
            DTForExcel.Columns[7].Caption = MainWindow.resourcemanager.GetString("trNote");
            DTForExcel.Columns[8].Caption = MainWindow.resourcemanager.GetString("trUserName");
            DTForExcel.Columns[9].Caption = MainWindow.resourcemanager.GetString("trPassword");

            ExportToExcel.Export(DTForExcel);
        }

        private async void Tgl_userIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (users is null)
                await RefreshUsersList();
            tgl_userState = 1;
            Tb_search_TextChanged(null, null);
        }

        private async void Tgl_userIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (users is null)
                await RefreshUsersList();
            tgl_userState = 0;
            Tb_search_TextChanged(null, null);
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

        private void Img_user_Click(object sender, RoutedEventArgs e)
        {//select image
            isImgPressed = true;
            openFileDialog.Filter = "Images|*.png;*.jpg;*.bmp;*.jpeg;*.jfif";
            if (openFileDialog.ShowDialog() == true)
            {
                brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                img_user.Background = brush;
                imgFileName = openFileDialog.FileName;
            }
            else
            {
                //brush.ImageSource = new BitmapImage(new Uri("pic/no-image-icon-125x125.png", UriKind.Relative));
                //img_user.Background = brush;
            }
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshUsersList();
            Tb_search_TextChanged(null, null);
        }

        private async void getImg()
        {
            try
            {
                if (string.IsNullOrEmpty(user.image))
                {
                    SectionData.clearImg(img_user);
                }
                else
                {
                    byte[] imageBuffer = await userModel.downloadImage(user.image); // read this as BLOB from your DB

                    var bitmapImage = new BitmapImage();

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
                    img_user.Background = new ImageBrush(bitmapImage);

                }
            }
            catch { }
        }

        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (cb_job.Text.Equals(""))
            //{
            //    p_errorJob.Visibility = Visibility.Visible;
            //    tt_errorJob.Content = MainWindow.resourcemanager.GetString("trEmptyJob");
            //    cb_job.Background = (Brush)bc.ConvertFrom("#15FF0000");

            //}
            //else
            //{
            //    cb_job.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            //    p_errorJob.Visibility = Visibility.Collapsed;

            //}
        }

        int x = 0;
        private void Cb_job_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            /////?????????????????
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            ReportParameter[] paramarr = new ReportParameter[6];

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\SectionData\Ar\ArUserReport.rdlc";
            }
            else addpath = @"\Reports\SectionData\En\UserReport.rdlc";

            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.userReport(usersQuery, rep, reppath);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);
            rep.Refresh();
            LocalReportExtensions.PrintToPrinter(rep);

        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            ReportParameter[] paramarr = new ReportParameter[6];

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\SectionData\Ar\ArUserReport.rdlc";
            }
            else addpath = @"\Reports\SectionData\En\UserReport.rdlc";

            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.userReport(usersQuery, rep, reppath);
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

        private void Tb_preventSpaces_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
        }


        private void Cb_job_KeyUp(object sender, KeyEventArgs e)
        {
            ComboBox cbm = sender as ComboBox;
            SectionData.searchInComboBox(cbm);
        }
        #region Categor and Item
        #region Refrish Y
        void RefrishItemsCard(IEnumerable<User> _user)
        {
            grid_containerCard.Children.Clear();
            catigoriesAndItemsView.gridCatigorieItems = grid_containerCard;
            catigoriesAndItemsView.FN_refrishUsers(_user.ToList(), "en","User");
        }
        #endregion
        #region Get Id By Click  Y
        private async void DG_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            p_errorFirstName.Visibility = Visibility.Collapsed;
            p_errorLastName.Visibility = Visibility.Collapsed;
            p_errorUserName.Visibility = Visibility.Collapsed;
            p_errorPassword.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;
            p_errorJob.Visibility = Visibility.Collapsed;

            tb_firstName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_lastName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_userName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            pb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            p_showPassword.Visibility = Visibility.Visible;
            cb_job.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            SectionData.clearValidate(tb_mobile, p_errorMobile);

            if (dg_users.SelectedIndex != -1)
            {
                user = dg_users.SelectedItem as User;
                this.DataContext = user;
            }
            if (user != null)
            {
                btn_stores.IsEnabled = true;

                if (user.userId != 0)
                {
                    pb_password.Password = tb_password.Text.Trim();
                }

                SectionData.getMobile(user.mobile, cb_areaMobile, tb_mobile);

                SectionData.getPhone(user.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                getImg();

                #region delete
                if (user.canDelete)
                {
                    txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                    txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                }

                else
                {
                    if (user.isActive == 0)
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

                index = dg_users.SelectedIndex;
            }

        }
        public void ChangeItemIdEvent(int userId)
        {
            btn_stores.IsEnabled = true;
            #region
            p_errorFirstName.Visibility = Visibility.Collapsed;
            p_errorLastName.Visibility = Visibility.Collapsed;
            p_errorUserName.Visibility = Visibility.Collapsed;
            p_errorPassword.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;
            p_errorJob.Visibility = Visibility.Collapsed;

            tb_firstName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_lastName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_userName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            pb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            cb_job.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            user = users.ToList().Find(c => c.userId == userId);
                this.DataContext = user;

            if (user != null)
            {
                if (user.userId != 0)
                {
                    pb_password.Password = tb_password.Text.Trim();
                }

                SectionData.getMobile(user.mobile, cb_areaMobile, tb_mobile);

                SectionData.getPhone(user.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                getImg();

                #region delete
                if (user.canDelete)
                {
                    txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                    txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                }

                else
                {
                    if (user.isActive == 0)
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
            #endregion
        }
        #endregion
        #region Switch Card/DataGrid Y
        private void Btn_itemsInCards_Click(object sender, RoutedEventArgs e)
        {
            grid_datagrid.Visibility = Visibility.Collapsed;
            grid_pagination.Visibility = Visibility.Visible;
            grid_cards.Visibility = Visibility.Visible;
            path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_itemsInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

            Tb_search_TextChanged(null, null);
        }

        private void Btn_itemsInGrid_Click(object sender, RoutedEventArgs e)
        {
            grid_cards.Visibility = Visibility.Collapsed;
            grid_pagination.Visibility = Visibility.Collapsed;
            grid_datagrid.Visibility = Visibility.Visible;

             path_itemsInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

            Tb_search_TextChanged(null, null);
        }
        #endregion
        #region Search Y


        /// <summary>
        /// Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            p_errorFirstName.Visibility = Visibility.Collapsed;
            tb_firstName.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (users is null)
                await RefreshUsersList();
            searchText = tb_search.Text.ToLower();
            pageIndex = 1;

            #region
            usersQuery = users.Where(s => (s.lastname.ToLower().Contains(searchText) ||
            s.name.ToLower().Contains(searchText) ||
            s.username.ToLower().Contains(searchText) ||
            s.job.ToLower().Contains(searchText)
            ) && s.isActive == tgl_userState);
            //txt_count.Text = usersQuery.Count().ToString();
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(usersQuery, pageIndex, btns));
            #endregion
            RefreshUserView();
        }
       

        #endregion
        #region Pagination Y
        Pagination pagination = new Pagination();
        Button[] btns;
        public int pageIndex = 1;

        private void Tb_pageNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            usersQuery = users.Where(x => x.isActive == tgl_userState);

            if (tb_pageNumberSearch.Text.Equals(""))
            {
                pageIndex = 1;
            }
            else if (((usersQuery.Count() - 1) / 12) + 1 < int.Parse(tb_pageNumberSearch.Text))
            {
                pageIndex = ((usersQuery.Count() - 1) / 12) + 1;
            }
            else
            {
                pageIndex = int.Parse(tb_pageNumberSearch.Text);
            }

            #region
            usersQuery = users.Where(s => (s.lastname.ToLower().Contains(searchText) ||
            s.name.ToLower().Contains(searchText) ||
            s.username.ToLower().Contains(searchText) ||
            s.job.ToLower().Contains(searchText)
            ) && s.isActive == tgl_userState);
            //txt_count.Text = usersQuery.Count().ToString();
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(usersQuery, pageIndex, btns));
            #endregion

        }


        private void Btn_firstPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            #region
            usersQuery = users.Where(s => (s.lastname.ToLower().Contains(searchText) ||
            s.name.ToLower().Contains(searchText) ||
            s.username.ToLower().Contains(searchText) ||
            s.job.ToLower().Contains(searchText)
            ) && s.isActive == tgl_userState);
            //txt_count.Text = usersQuery.Count().ToString();
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(usersQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_prevPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_prevPage.Content.ToString());
            #region
            usersQuery = users.Where(s => (s.lastname.ToLower().Contains(searchText) ||
            s.name.ToLower().Contains(searchText) ||
            s.username.ToLower().Contains(searchText) ||
            s.job.ToLower().Contains(searchText)
            ) && s.isActive == tgl_userState);
            //txt_count.Text = usersQuery.Count().ToString();
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(usersQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_activePage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_activePage.Content.ToString());
            #region
            usersQuery = users.Where(s => (s.lastname.ToLower().Contains(searchText) ||
            s.name.ToLower().Contains(searchText) ||
            s.username.ToLower().Contains(searchText) ||
            s.job.ToLower().Contains(searchText)
            ) && s.isActive == tgl_userState);
            //txt_count.Text = usersQuery.Count().ToString();
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(usersQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_nextPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_nextPage.Content.ToString());
            #region
            usersQuery = users.Where(s => (s.lastname.ToLower().Contains(searchText) ||
            s.name.ToLower().Contains(searchText) ||
            s.username.ToLower().Contains(searchText) ||
            s.job.ToLower().Contains(searchText)
            ) && s.isActive == tgl_userState);
            //txt_count.Text = usersQuery.Count().ToString();
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(usersQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_lastPage_Click(object sender, RoutedEventArgs e)
        {
            usersQuery = users.Where(x => x.isActive == tgl_userState);
            pageIndex = ((usersQuery.Count() - 1) / 12) + 1;
            #region
            usersQuery = users.Where(s => (s.lastname.ToLower().Contains(searchText) ||
            s.name.ToLower().Contains(searchText) ||
            s.username.ToLower().Contains(searchText) ||
            s.job.ToLower().Contains(searchText)
            ) && s.isActive == tgl_userState);
            //txt_count.Text = usersQuery.Count().ToString();
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(usersQuery, pageIndex, btns));
            #endregion
        }
        #endregion

        #endregion
        private void Grid_containerCard_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RefrishItemsCard(pagination.refrishPagination(usersQuery, pageIndex, btns));
        }

        private void btn_pieChart_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            win_lvc win = new win_lvc(usersQuery, 3);
            win.ShowDialog();
            Window.GetWindow(this).Opacity = 1;
        }

        private void Btn_stores_Click(object sender, RoutedEventArgs e)
        {//stores
            Window.GetWindow(this).Opacity = 0.2;

            wd_branchesList w = new wd_branchesList();

            w.Id = user.userId;
            w.userOrBranch = 'u';
            w.ShowDialog();
            if (w.isActive)
            {
               
            }

            Window.GetWindow(this).Opacity = 1;
        }

        private void tb_mobile_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
        }

        private void tb_mobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
        }

        private void Pb_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pb_password.Password.Equals(""))
            {
                SectionData.showPasswordValidate(pb_password, p_errorPassword, tt_errorPassword, "trEmptyPasswordToolTip");
                p_showPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                SectionData.clearPasswordValidate(pb_password, p_errorPassword);
                p_showPassword.Visibility = Visibility.Visible;
            }
        }

        //private void Img_user_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    isImgPressed = false;
        //    if (e.ClickCount >= 1)
        //    {
        //        openFileDialog.Filter = "Images|*.png;*.jpg;*.bmp;*.jpeg;*.jfif";
        //        if (openFileDialog.ShowDialog() == true)
        //        {
        //            //brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
        //            img_user.Source = new BitmapImage(new Uri(openFileDialog.FileName));
        //            isImgPressed = true;
        //        }
        //    }
        //}
    }
}


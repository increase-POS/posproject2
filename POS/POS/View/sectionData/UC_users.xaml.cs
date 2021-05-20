﻿using POS.Classes;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_users.xaml
    /// </summary>
    public partial class UC_users : UserControl
    {

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
        public UC_users()
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

            cb_areaMobile.ItemsSource = countrynum.ToList();
            cb_areaMobile.SelectedValuePath = "countryId";
            cb_areaMobile.DisplayMemberPath = "code";

          

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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DG_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorFirstName.Visibility = Visibility.Collapsed;
            p_errorLastName.Visibility = Visibility.Collapsed;
            p_errorUserName.Visibility = Visibility.Collapsed;
            p_errorPassword.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;

            tb_firstName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_lastName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_userName.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_users.SelectedIndex != -1)
            {
                user = dg_users.SelectedItem as User;
                this.DataContext = user;
            }
            if (user != null)
            {
                if (user.userId != 0)
                {
                    pb_password.Password = tb_password.Text.Trim();
                }
                //mobile
               
                if ((user.mobile != null))
                {
                    string area = user.mobile;
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

                    cb_areaMobile.Text = area;

                    tb_mobile.Text = phone.ToString();
                }
                else
                {
                    cb_areaMobile.SelectedIndex = -1;
                    tb_mobile.Clear();
                }
                //phone
                if ((user.phone != null))
                {
                    string area = user.phone;
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
                if (user.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else
                {
                    if (user.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                    else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
                }

                //MessageBox.Show("det : "+user.details+" "+"pass : "+ user.password+" "+"phone : "+user.phone);
            }

        }

        private void translate()
        {
            txt_user.Text = MainWindow.resourcemanager.GetString("trUser");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            txt_userInfomration.Text = MainWindow.resourcemanager.GetString("trUserInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_firstName, MainWindow.resourcemanager.GetString("trUserNameHint"));
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
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

            dg_users.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_users.Columns[1].Header = MainWindow.resourcemanager.GetString("trLastName");
            dg_users.Columns[2].Header = MainWindow.resourcemanager.GetString("trJob");
            dg_users.Columns[3].Header = MainWindow.resourcemanager.GetString("trWorkHours");
            dg_users.Columns[4].Header = MainWindow.resourcemanager.GetString("trNote");
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
        {
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
            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            tb_mobile.Clear();
            tb_email.Clear();

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

        }
        private  void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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
           

            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            fillCountries();

            fillCity();
            this.Dispatcher.Invoke(() =>
            {
                Tb_search_TextChanged(null, null);
            });
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
            //chk empty username
            SectionData.validateEmptyTextBox(tb_userName, p_errorUserName, tt_errorUserName, "trEmptyUserNameToolTip");
            //chk empty password
            SectionData.validateEmptyTextBox(tb_password, p_errorPassword, tt_errorPassword, "trEmptyPasswordToolTip");
            //validate email
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);


            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

            bool emailError = false;

            if (!tb_email.Text.Equals(""))
                if (!SectionData.IsValid(tb_email.Text))
                    emailError = true;

            if ((!tb_firstName.Text.Equals("")) && (!tb_lastName.Text.Equals("")) && (!tb_userName.Text.Equals("")) && 
                                                   (!pb_password.Password.Equals("")) && (!cb_job.Text.Equals("")))
            {
                if (emailError)
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                else
                {
                    user.username = tb_userName.Text;
                    user.password = pb_password.Password;
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

                    if (s.Equals("User Is Added Successfully")) { SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null); }
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                }
            }

            users = await userModel.GetUsersAsync();
            usersQuery = users.Where(s => s.isActive == Convert.ToInt32(tgl_userIsActive.IsChecked));
            dg_users.ItemsSource = usersQuery;

            fillJobCombo();

        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
         //chk empty name
            SectionData.validateEmptyTextBox(tb_firstName, p_errorFirstName, tt_errorFirstName, "trEmptyNameToolTip");
            //chk empty last name
            SectionData.validateEmptyTextBox(tb_lastName, p_errorLastName, tt_errorLastName, "trEmptyLastNameToolTip");
            //chk empty job
            SectionData.validateEmptyComboBox(cb_job, p_errorJob, tt_errorJob, "trEmptyJobToolTip");
            //chk empty username
            SectionData.validateEmptyTextBox(tb_userName, p_errorUserName, tt_errorUserName, "trEmptyUserNameToolTip");
            //chk empty password
            SectionData.validateEmptyTextBox(tb_password, p_errorPassword, tt_errorPassword, "trEmptyPasswordToolTip");
            //validate email
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);

            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

            bool emailError = false;

            if (!tb_email.Text.Equals(""))
                if (!SectionData.IsValid(tb_email.Text))
                    emailError = true;

            if ((!tb_firstName.Text.Equals("")) && (!tb_lastName.Text.Equals("")) && (!tb_userName.Text.Equals("")) &&
                                                   (!pb_password.Password.Equals("")) && (!cb_job.Text.Equals("")))
            {
                if (emailError)
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                else
                {
                    user.username = tb_userName.Text;
                    user.password = pb_password.Password;
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

                    if (s.Equals("User Is Updated Successfully")) { SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate")); Btn_clear_Click(null, null); }
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                }
            }

            users = await userModel.GetUsersAsync();
            usersQuery = users.Where(s => s.isActive == Convert.ToInt32(tgl_userIsActive.IsChecked));
            dg_users.ItemsSource = usersQuery;

            fillJobCombo();

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if ((!user.canDelete) && (user.isActive == 0))
                activate();
            else
            {
                string popupContent = "";
                if (user.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                if ((!user.canDelete) && (user.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                bool b = await userModel.deleteUser(user.userId, MainWindow.userID.Value, user.canDelete);

                if (b) SectionData.popUpResponse("", popupContent);
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

            }

            users = await userModel.GetUsersAsync();
            usersQuery = users.Where(s => s.isActive == Convert.ToInt32(tgl_userIsActive.IsChecked));
            dg_users.ItemsSource = usersQuery;

            //clear textBoxs
            Btn_clear_Click(sender, e);

            fillJobCombo();

        }

        private async void activate()
        {//activate
            user.isActive = 1;

            string s = await userModel.saveUser(user);

            if (s.Equals("User Is Updated Successfully")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

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
            users = await userModel.GetUsersAsync();
            return users;
        }
        void RefreshUserView()
        {
            dg_users.ItemsSource = usersQuery;
            txt_count.Text = usersQuery.Count().ToString();
            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            p_errorFirstName.Visibility = Visibility.Collapsed;
            tb_firstName.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (users is null)
                await RefreshUsersList();
            searchText = tb_search.Text;
            usersQuery = users.Where(s => (s.lastname.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.username.Contains(searchText) ||
            s.job.Contains(searchText)
            ) && s.isActive == tgl_userState);
            RefreshUserView();
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

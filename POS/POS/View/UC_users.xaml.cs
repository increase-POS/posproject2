

using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Resources;
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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_users.xaml
    /// </summary>
    public partial class UC_users : UserControl
    {

        User userModel = new User();

        public int UserId;
        public UC_users()
        {
            InitializeComponent();
        }

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
            var bc = new BrushConverter();
            tb_firstName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_lastName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_userName.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            User user = new User();
            if (dg_users.SelectedIndex != -1)
            {
                user = dg_users.SelectedItem as User;
                this.DataContext = user;
            }
            if (user != null)
            {
                if (user.userId != 0)
                {
                    UserId = user.userId;
                  
                    pb_password.Password = tb_password.Text.Trim();
                }


                if ((user.mobile != null) && (user.mobile.ToArray().Length > 4))
                {
                    string area = new string(user.mobile.Take(4).ToArray());
                    var mobile = user.mobile.Substring(4, user.mobile.Length - 4);

                    cb_areaMobile.Text = area;
                    tb_mobile.Text = mobile.ToString();
                }
                else
                {
                    cb_areaMobile.SelectedIndex = -1;
                    tb_mobile.Clear();
                }

            }

        }

        private void translate()
        {
            txt_user.Text = MainWindow.resourcemanager.GetString("trUser");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectJobHint"));
            txt_userInfomration.Text = MainWindow.resourcemanager.GetString("trUserInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_firstName, MainWindow.resourcemanager.GetString("trUserNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_lastName, MainWindow.resourcemanager.GetString("trLastNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
          //  MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_areaMobile, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            txt_workInformation.Text = MainWindow.resourcemanager.GetString("trWorkInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_job, MainWindow.resourcemanager.GetString("trJobHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_workHours, MainWindow.resourcemanager.GetString("trWorkHoursHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_details, MainWindow.resourcemanager.GetString("trDetailsHint"));
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
            dg_users.Columns[4].Header = MainWindow.resourcemanager.GetString("trDetails");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            tb_address.Text = "";
            tb_password.Text = "";
            tb_userName.Text = "";
            tb_firstName.Text = "";
            tb_lastName.Text = "";
            cb_job.SelectedIndex = 0;
            tb_workHours.Text = "";
            tb_details.Text = "";
            tb_phone.Text = "";
            cb_areaMobile.Text = "";
            tb_mobile.Text = "";
            tb_email.Text = "";
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucUsers.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucUsers.FlowDirection = FlowDirection.RightToLeft; }

            translate();
            
            
            var users = await userModel.GetUsersAsync();
            dg_users.ItemsSource = users;

            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
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
            User user = new User
            {
                username = tb_userName.Text,
                password     = tb_password.Text,
                name         = tb_firstName.Text,
                lastname     = tb_lastName.Text,
                job          = cb_job.Text,
                workHours    = tb_workHours.Text,
                details      = tb_details.Text,
                phone        = tb_phone.Text,
                mobile       = cb_areaMobile.Text + tb_mobile.Text,
                email        = tb_email.Text,
                address      = tb_address.Text,
                isActive     = 1,
                isOnline     = 1,
                createDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 1,
                updateUserId = 1,
                notes        = "",
                role         = ""
            };

            await userModel.saveUser(user);

            var users = await userModel.GetUsersAsync();
            dg_users.ItemsSource = users;

        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            User user = new User
            {
                userId     = UserId,
                username   = tb_userName.Text,
                password   = tb_password.Text,
                name       = tb_firstName.Text,
                lastname   = tb_lastName.Text,
                job        = cb_job.Text,
                workHours  = tb_workHours.Text,
                details    = tb_details.Text,
                phone      = tb_phone.Text,
                mobile     = cb_areaMobile.Text + tb_mobile.Text,
                email      = tb_email.Text,
                address    = tb_address.Text,
                isActive   = 1,
                isOnline   = 1,
                createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 1,
                updateUserId = 1,
                notes        = "",
                role         = ""
            };

            await userModel.saveUser(user);

            var users = await userModel.GetUsersAsync();
            dg_users.ItemsSource = users;

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            await userModel.deleteUser(UserId);

            var users = await userModel.GetUsersAsync();
            dg_users.ItemsSource = users;

            //clear textBoxs
            tb_userName.Clear();
            tb_password.Clear();
            tb_firstName.Clear();
            tb_lastName.Clear();
            cb_job.SelectedIndex=0;
            tb_workHours.Clear();
            tb_details.Clear();
            tb_phone.Clear();
            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            tb_mobile.Clear();
            tb_email.Clear();
            tb_address.Clear();
        }

        private void Tb_userName_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_userName.Text.Equals(""))
            {
                p_errorUserName.Visibility = Visibility.Visible;
                tt_errorUserName.Content = MainWindow.resourcemanager.GetString("trEmptyUserNameToolTip");
                tb_userName.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorUserName.Visibility = Visibility.Collapsed;
                tb_userName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_password_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_password.Text.Equals(""))
            {
                p_errorPassword.Visibility = Visibility.Visible;
                p_showPassword.Visibility = Visibility.Collapsed;
                tt_errorPassword.Content = MainWindow.resourcemanager.GetString("trEmptyPasswordToolTip");
                tb_password.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorPassword.Visibility = Visibility.Collapsed;
                p_showPassword.Visibility = Visibility.Visible;
                tb_password.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_firstName_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_firstName.Text.Equals(""))
            {
                p_errorFirstName.Visibility = Visibility.Visible;
                tt_errorFirstName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_firstName.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorFirstName.Visibility = Visibility.Collapsed;
                tt_errorFirstName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_lastName_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_lastName.Text.Equals(""))
            {
                p_errorLastName.Visibility = Visibility.Visible;
                tt_errorLastName.Content = MainWindow.resourcemanager.GetString("trEmptyLastNameToolTip");
                tb_lastName.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorLastName.Visibility = Visibility.Collapsed;
                tt_errorLastName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (!tb_email.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                {
                    p_errorEmail.Visibility = Visibility.Visible;
                    tt_errorEmail.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                    tb_email.Background = (Brush)bc.ConvertFrom("#15FF0000");
                }
                else
                {
                    p_errorEmail.Visibility = Visibility.Collapsed;
                    tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                }
            }
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
    }
}


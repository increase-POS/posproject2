using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
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
using System.Text.RegularExpressions;
using System.Net.Mail;
//using Tulpep.NotificationWindow;


namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_Customer.xaml
    /// </summary>
    public partial class UC_Customer : UserControl
    {
        public int AgentId;

        Agent agentModel = new Agent();
        public UC_Customer()
        {
            InitializeComponent();

        }

        private void translate()
        {
            txt_customer.Text = MainWindow.resourcemanager.GetString("trCustomer");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
          //  MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trPamentMethodHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trCodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_company, MainWindow.resourcemanager.GetString("trCompanyHint"));
            txt_contactInformation.Text = MainWindow.resourcemanager.GetString("trContactInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            txt_moreInformation.Text = MainWindow.resourcemanager.GetString("trMoreInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_upperLimit, MainWindow.resourcemanager.GetString("trUpperLimitHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_fax, MainWindow.resourcemanager.GetString("trFaxHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            dg_customer.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_customer.Columns[1].Header = MainWindow.resourcemanager.GetString("trCompany");
            dg_customer.Columns[2].Header = MainWindow.resourcemanager.GetString("trMobile");
            //dg_customer.Columns[3].Header = MainWindow.resourcemanager.GetString("trDetails");
            //dg_customer.Columns[4].Header = MainWindow.resourcemanager.GetString("trBalance");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_code.Text = "";
            tb_address.Text = "";
            tb_fax.Text = "";
            tb_company.Text = "";
            tb_email.Text = "";
            tb_name.Text = "";
            tb_notes.Text = "";
            tb_mobile.Text = "";
            tb_upperLimit.Text = "";
            tb_phone.Text = "";
            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DG_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_fax.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            Agent agent = new Agent();
            if (dg_customer.SelectedIndex != -1)
            {
                agent = dg_customer.SelectedItem as Agent;
                this.DataContext = agent;
            }
            if (agent != null)
            {

                if (agent.agentId != 0)
                {
                    AgentId = agent.agentId;
                }

                //mobile
                if ((agent.mobile != null) && (agent.mobile.ToArray().Length > 4))
                {
                    string area = new string(agent.mobile.Take(4).ToArray());
                    var mobile = agent.mobile.Substring(4, agent.mobile.Length - 4);
                    
                    cb_areaMobile.Text = area;
                    tb_mobile.Text = mobile.ToString();
                }
                else
                {
                    cb_areaMobile.SelectedIndex = -1;
                    tb_mobile.Clear();
                }
                //phone
                if ((agent.phone != null) && (agent.phone.ToArray().Length > 7))
                {
                    string area      = new string(agent.phone.Take(4).ToArray());
                    string areaLocal = new string(agent.phone.Substring(4, agent.phone.Length - 4).Take(3).ToArray());

                    var phone = agent.phone.Substring(7, agent.phone.Length - 7);

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
                //fax
                if ((agent.fax != null) && (agent.fax.ToArray().Length > 7))
                {
                    string area = new string(agent.fax.Take(4).ToArray());
                    string areaLocal = new string(agent.fax.Substring(4, agent.fax.Length - 4).Take(3).ToArray());

                    var fax = agent.fax.Substring(7, agent.fax.Length - 7);

                    cb_areaFax.Text = area;
                    cb_areaFaxLocal.Text = areaLocal;
                    tb_fax.Text = fax.ToString();
                }
                else
                {
                    cb_areaFax.SelectedIndex = -1;
                    cb_areaFaxLocal.SelectedIndex = -1;
                    tb_fax.Clear();
                }
            }
        }

        private async void  Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
            }
            if (tb_mobile.Text.Equals(""))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyMobileToolTip");
            }
            else
            {
                p_errorMobile.Visibility = Visibility.Collapsed;

            }
            if (!tb_email.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                {
                    p_errorEmail.Visibility = Visibility.Visible;
                    tt_errorEmail.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                }
                else
                {
                    p_errorEmail.Visibility = Visibility.Collapsed;
                }
            }
            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + cb_areaPhoneLocal.Text + tb_phone.Text;
            
            string faxStr = "";
            if (!tb_fax.Text.Equals("")) faxStr = cb_areaFax.Text + cb_areaFaxLocal.Text + tb_fax.Text;
            
            bool emailError = false;
            if (!tb_email.Text.Equals(""))
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                    emailError = true;

            decimal maxDeserveValue = 0;
            if (!tb_upperLimit.Text.Equals(""))
                maxDeserveValue = decimal.Parse(tb_upperLimit.Text);

            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")) )
            {
                if (emailError)
                    popUpResponse("", MainWindow.resourcemanager.GetString("trErrorEmailToolTip"));
                else
                {
                    genRandomCode();

                    Agent customer = new Agent
                    {
                        name = tb_name.Text,
                        code = tb_code.Text,
                        company = tb_company.Text,
                        address = tb_address.Text,
                        email = tb_email.Text,
                        phone = phoneStr,
                        mobile = cb_areaMobile.Text + tb_mobile.Text,
                        image = "",
                        type = "c",
                        accType = "",
                        balance = 0,
                        createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                        updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                        createUserId = MainWindow.userID,
                        updateUserId = MainWindow.userID,
                        notes = tb_notes.Text,
                        isActive = 1,
                        fax = faxStr,
                        maxDeserve = maxDeserveValue

                    };

                    string s = await agentModel.saveAgent(customer);

                    if (s.Equals("true")) popUpResponse("", "تمت الإضافة بنجاح");
                    else popUpResponse("", "حدث خطأ");

                    //pass parameter type (V for vendors, C for Clients , B for Both)
                    var agents = await agentModel.GetAgentsAsync("c");
                    dg_customer.ItemsSource = agents;
                }
            }
            else popUpResponse("", "لا يمكن الإضافة بدون الاسم و رقم الجوال");
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            if(MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucCustomer.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucCustomer.FlowDirection = FlowDirection.RightToLeft;
            }
            
            translate();
           
            //pass parameter type (V for vendors, C for Clients , B for Both)
            var agents = await agentModel.GetAgentsAsync("c");
            dg_customer.ItemsSource = agents;
            
            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            cb_areaFax.SelectedIndex = 0;
            cb_areaFaxLocal.SelectedIndex = 0;
            
        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
            }
            if (tb_mobile.Text.Equals(""))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyMobileToolTip");
            }
            else
            {
                p_errorMobile.Visibility = Visibility.Collapsed;

            }
            if (!tb_email.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                {
                    p_errorEmail.Visibility = Visibility.Visible;
                    tt_errorEmail.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                }
                else
                {
                    p_errorEmail.Visibility = Visibility.Collapsed;
                }
            }
            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + cb_areaPhoneLocal.Text + tb_phone.Text;

            string faxStr = "";
            if (!tb_fax.Text.Equals("")) faxStr = cb_areaFax.Text + cb_areaFaxLocal.Text + tb_fax.Text;

            bool emailError = false;
            if (!tb_email.Text.Equals(""))
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                    emailError = true;

            decimal maxDeserveValue = 0;
            if (!tb_upperLimit.Text.Equals(""))
                maxDeserveValue = decimal.Parse(tb_upperLimit.Text);

            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")))
            {
                if (emailError)
                    popUpResponse("", MainWindow.resourcemanager.GetString("trErrorEmailToolTip"));
                else
                {
                    Agent customer = new Agent
                    {
                        agentId = AgentId,
                        name = tb_name.Text,
                        code = tb_code.Text,
                        company = tb_company.Text,
                        address = tb_address.Text,
                        email = tb_email.Text,
                        phone = phoneStr,
                        mobile = cb_areaMobile.Text + tb_mobile.Text,
                        image = "",
                        type = "c",
                        accType = "",
                        balance = 0,
                        createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                        updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                        createUserId = MainWindow.userID,
                        updateUserId = MainWindow.userID,
                        notes = tb_notes.Text,
                        isActive = 1,
                        fax = faxStr,
                        maxDeserve = maxDeserveValue

                    };

                    string s = await agentModel.saveAgent(customer);

                    if (s.Equals("true")) popUpResponse("", "تمت التعديل بنجاح");
                    else popUpResponse("", "حدث خطأ");

                    //pass parameter type (V for vendors, C for Clients , B for Both)
                    var agents = await agentModel.GetAgentsAsync("c");
                    dg_customer.ItemsSource = agents;
                }
            }
            else popUpResponse("", "لا يمكن التعديل بدون الاسم و رقم الجوال");
        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

            bool b = await agentModel.deleteAgent(AgentId);
            MessageBox.Show(b.ToString());
            if(b) popUpResponse("", "تمت الحذف بنجاح");
            else popUpResponse("", "حدث خطأ");

            //pass parameter type(V for vendors, C for Clients, B for Both)
            var agents = await agentModel.GetAgentsAsync("c");
            dg_customer.ItemsSource = agents;

            //clear textBoxs
            AgentId = 0;
            tb_name.Clear();
            tb_company.Clear();
            tb_address.Clear();
            tb_upperLimit.Clear();
            tb_email.Clear();
            tb_phone.Clear();
            tb_mobile.Clear();
            tb_fax.Clear();
            tb_notes.Clear();
           
        }

        private void tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        //private void tb_fax_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    var bc = new BrushConverter();

        //    if (tb_fax.Text.Equals(""))
        //    {
        //        p_errorBalance.Visibility = Visibility.Visible;
        //        tt_errorBalance.Content = MainWindow.resourcemanager.GetString("trEmptyBalanceToolTip");
        //        tb_fax.Background = (Brush)bc.ConvertFrom("#15FF0000");
        //    }
        //    else
        //    {
        //        p_errorBalance.Visibility = Visibility.Collapsed;
        //        tb_fax.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        //    }
        //}

       
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

        public bool IsValid0(string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

       

        private void Tb_mobile_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if ((!tb_mobile.Text.Equals("")) && (cb_areaMobile.Text.Equals("")))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyAreaToolTip");
            }
            else
                p_errorMobile.Visibility = Visibility.Collapsed;


            if ((tb_mobile.Text.Equals("")) && (!cb_areaMobile.Text.Equals("")))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyMobileToolTip");
            }
            else
                p_errorMobile.Visibility = Visibility.Collapsed;

        }
        private long genRandomCode()
        {
            Random rnd = new Random();
            long randomNum = rnd.Next(0, 999999999);
            if (!isCodeExist(randomNum))
                //randomList.Add(randomNum);
                tb_code.Text = randomNum.ToString();
            else genRandomCode();
            
            return randomNum;

        }

        DataGrid dt = new DataGrid();
        private bool isCodeExist(long randomNum)
        {
            bool b = false;
            //dt.ItemsSource = null;
            try
            {
            //    dt.ItemsSource = dg_customer.ItemsSource;
            //    for (int i = 0; i < dt.Items.Count; i++)
            //    {
            //        Agent agent = new Agent();
            //        dt.SelectedIndex = i;
            //        agent = dt.SelectedItem as Agent;
            //        //this.DataContext = agent;

            //        if (agent != null)
            //        {
            //            if (agent.code.Equals(tb_code.Text))
            //            { b = true; break; }

            //        }
            //    }
            }
            catch { }
            return b;
        }

            private void popUpResponse(string title , string content)
        {/*
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = title;
            popup.ContentText =content;
            //popup.ContentPadding = new Padding(0);
            //popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            //popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Popup();// show  */
        }
    }
}
    
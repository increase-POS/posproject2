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

           
            List<Agent> customers = new List<Agent>();
           
           

            //for (int i = 0; i < 50; i++)
            //{
            //    customers.Add(new Agent()
            //    {
            //        agentId = i,
            //        name = "Test name " + i,
            //        address = "Test address" + i,
            //        company = "Test company" + i,
            //        mobile = "Test mobile" + i,
            //        phone = "Test phone" + i,
            //        email = "Test email" + i,
            //        details = "Test details" + i,
            //        accType = "Debt",
            //        balance = 368 * i,
            //        notes = "Test notes" + i,
            //    }); ; ;
            //}
            dg_customer.ItemsSource = customers;
        }

        private void translate()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trPamentMethodHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_company, MainWindow.resourcemanager.GetString("trCompanyHint"));
            txt_contactInformation.Text = MainWindow.resourcemanager.GetString("trContactInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_area, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            txt_anotherInformation.Text = MainWindow.resourcemanager.GetString("trAnotherInfomation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_details, MainWindow.resourcemanager.GetString("trDetailsHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_accType, MainWindow.resourcemanager.GetString("trPamentMethodHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_balance, MainWindow.resourcemanager.GetString("trBalanceHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            dg_customer.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_customer.Columns[1].Header = MainWindow.resourcemanager.GetString("trCompany");
            dg_customer.Columns[2].Header = MainWindow.resourcemanager.GetString("trMobile");
            dg_customer.Columns[3].Header = MainWindow.resourcemanager.GetString("trDetails");
            dg_customer.Columns[4].Header = MainWindow.resourcemanager.GetString("trBalance");
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DG_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorBalance.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_balance.Background = (Brush)bc.ConvertFrom("#f8f8f8");
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

                if (agent.accType != null)
                {
                    if (agent.accType.Equals("c")) cb_accType.SelectedIndex = 0;
                    else if (agent.accType.Equals("d")) cb_accType.SelectedIndex = 1;
                    else cb_accType.SelectedIndex = 0;
                }
                else cb_accType.SelectedIndex = -1;

                if ((agent.mobile != null) && (agent.mobile.ToArray().Length > 4))
                {
                    string area = new string(agent.mobile.Take(4).ToArray());
                    var mobile = agent.mobile.Substring(4, agent.mobile.Length - 4);
                    
                    cb_area.Text = area;
                    tb_mobile.Text = mobile.ToString();
                }
                else
                {
                    cb_area.SelectedIndex = -1;
                    tb_mobile.Clear();
                }

                MessageBox.Show(agent.mobile);

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
            if (tb_balance.Text.Equals(""))
            {
                p_errorBalance.Visibility = Visibility.Visible;
                tt_errorBalance.Content = MainWindow.resourcemanager.GetString("trEmptyBalanceToolTip");
            }
            else
            {
                p_errorBalance.Visibility = Visibility.Collapsed;

            }
            if (!tb_email.Text.Equals(""))
            {
                if(!ValidatorExtensions.IsValid(tb_email.Text))
                {
                    p_errorEmail.Visibility = Visibility.Visible;
                    tt_errorEmail.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                }
                else
                {
                    p_errorEmail.Visibility = Visibility.Collapsed;
                }
            }

            if ((!tb_name.Text.Equals("")) && (!tb_balance.Text.Equals("")) )
            {
                string acc = cb_accType.Text;

                if (acc == "Cash")      acc = "c";
                else if (acc == "Debt") acc = "d";
                else                    acc = "c";
                Agent customer = new Agent {
                    name         = tb_name.Text,
                    code         = "",
                    company      = tb_company.Text,
                    address      = tb_address.Text,
                    details      = tb_details.Text,
                    email        = tb_email.Text,
                    phone        = tb_phone.Text,
                    mobile       = cb_area.Text + tb_mobile.Text,
                    image        = "",
                    type         = "c",
                    accType      = acc,
                    balance      = Single.Parse(tb_balance.Text),
                    isDefault    = 0 ,
                    createDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    updateDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    createUserId = 1,
                    updateUserId = 1,
                    notes        = tb_notes.Text,
                    isActive     = 1,

            };
                await agentModel.saveAgent(customer);
                //pass parameter type (V for vendors, C for Clients , B for Both)
                var agents = await agentModel.GetAgentsAsync("c");
                dg_customer.ItemsSource = agents;
            }
            
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
            if (tb_balance.Text.Equals(""))
            {
                p_errorBalance.Visibility = Visibility.Visible;
                tt_errorBalance.Content = MainWindow.resourcemanager.GetString("trEmptyBalanceToolTip");
            }
            else
            {
                p_errorBalance.Visibility = Visibility.Collapsed;

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

            if ((!tb_name.Text.Equals("")) && (!tb_balance.Text.Equals("")))
            {
                string acc = cb_accType.Text;

                if (acc == "Cash") acc = "c";
                else if (acc == "Debt") acc = "d";
                else acc = "c";

                Agent customer = new Agent
                {
                    agentId = AgentId,
                    name = tb_name.Text,
                    code = "",
                    company = tb_company.Text,
                    address = tb_address.Text,
                    details = tb_details.Text,
                    email = tb_email.Text,
                    phone = tb_phone.Text,
                    mobile = cb_area.Text + tb_mobile.Text,
                    image = "",
                    type = "c",
                    accType = acc,
                    balance = Single.Parse(tb_balance.Text),
                    isDefault = 0,
                    createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    createUserId = 1,
                    updateUserId = 1,
                    notes = tb_notes.Text,
                    isActive = 1,

                };

                await agentModel.saveAgent(customer);
                //MessageBox.Show(cb_area.Text + tb_mobile.Text);

                //pass parameter type (V for vendors, C for Clients , B for Both)
                var agents = await agentModel.GetAgentsAsync("c");
                dg_customer.ItemsSource = agents;
            }
        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

            await agentModel.deleteAgent(AgentId);

            //pass parameter type (V for vendors, C for Clients , B for Both)
            var agents = await agentModel.GetAgentsAsync("c");
            dg_customer.ItemsSource = agents;

            //clear textBoxs
            AgentId = 0;
            tb_name.Clear();
            tb_company.Clear();
            tb_address.Clear();
            tb_details.Clear();
            tb_email.Clear();
            tb_phone.Clear();
            tb_mobile.Clear();
            cb_accType.SelectedIndex = -1;
            tb_balance.Clear();
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

        private void Tb_balance_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_balance.Text.Equals(""))
            {
                p_errorBalance.Visibility = Visibility.Visible;
                tt_errorBalance.Content = MainWindow.resourcemanager.GetString("trEmptyBalanceToolTip");
                tb_balance.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorBalance.Visibility = Visibility.Collapsed;
                tb_balance.Background = (Brush)bc.ConvertFrom("#f8f8f8");
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

            if ((!tb_mobile.Text.Equals("")) && (cb_area.Text.Equals("")))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyAreaToolTip");
            }
            else
                p_errorMobile.Visibility = Visibility.Collapsed;


            if ((tb_mobile.Text.Equals("")) && (!cb_area.Text.Equals("")))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyMobileToolTip");
            }
            else
                p_errorMobile.Visibility = Visibility.Collapsed;


        }
    }
}
    
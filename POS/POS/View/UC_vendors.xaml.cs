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


namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_supplier.xaml
    /// </summary>
    public partial class UC_vendors : UserControl
    {
        public int AgentId;

        Agent agentModel = new Agent();

        public UC_vendors()
        {
            InitializeComponent();

            /* List<Agent> suppliers = new List<Agent>();

             for (int i = 0; i < 50; i++)
             {
                 suppliers.Add(new Agent()
                 {
                     agentId = i,
                     name = "Test supplier name " + i,
                     address = "Test supplier address" + i,
                     company = "Test supplier company" + i,
                     mobile = "Test supplier mobile" + i,
                     phone = "Test supplier phone" + i,
                     email = "Test supplier email" + i,
                     details = "Test supplier details" + i,
                     accType = "Debt",
                     balance = 368 * i,
                     notes = "Test supplier notes" + i,
                 }); ; ;
             }

             Agent ag = new Agent
             {

                 agentId = AgentId,
                 name = tb_name.Text
             };

             dg_vendor.ItemsSource = suppliers;*/
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DG_supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility    = Visibility.Collapsed;
         //   p_errorBalance.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility   = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background    = (Brush)bc.ConvertFrom("#f8f8f8");
          //  tb_balance.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background   = (Brush)bc.ConvertFrom("#f8f8f8");

            Agent agent = new Agent();
            if (dg_vendor.SelectedIndex != -1)
            {
                agent = dg_vendor.SelectedItem as Agent;
                this.DataContext = agent;
            }
            if (agent != null)
            {
                if (agent.agentId != 0)
                {
                    AgentId = agent.agentId;
                }
                //if (agent.accType != null)
                //{
                //    if (agent.accType.Equals("c"))      cb_accType.SelectedIndex = 0;
                //    else if (agent.accType.Equals("d")) cb_accType.SelectedIndex = 1;
                //    else                                cb_accType.SelectedIndex = 0;
                //}
                //else cb_accType.SelectedIndex = -1;

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

                //MessageBox.Show(agent.mobile);
            }
        }

        private void translate()
        {
            txt_vendor.Text = MainWindow.resourcemanager.GetString("trVendor");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trPamentMethodHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_company, MainWindow.resourcemanager.GetString("trCompanyHint"));
            txt_contactInformation.Text = MainWindow.resourcemanager.GetString("trContactInformation");
//          MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_areaMobile, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            txt_moreInformation.Text = MainWindow.resourcemanager.GetString("trAnotherInfomation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_fax, MainWindow.resourcemanager.GetString("trFaxHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            dg_vendor.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_vendor.Columns[1].Header = MainWindow.resourcemanager.GetString("trCompany");
            dg_vendor.Columns[2].Header = MainWindow.resourcemanager.GetString("trMobile");
            dg_vendor.Columns[3].Header = MainWindow.resourcemanager.GetString("trDetails");
            dg_vendor.Columns[4].Header = MainWindow.resourcemanager.GetString("trBalance");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            tb_address.Text = "";
            tb_fax.Text = "";
            tb_company.Text = "";
            tb_email.Text = "";
            tb_name.Text = "";
            tb_notes.Text = "";
            tb_mobile.Text = "";
         //   tb_details.Text = "";
            tb_phone.Text = "";
            cb_areaMobile.Text = "";
            //cb_accType.Text = "";
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucVendor.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucVendor.FlowDirection = FlowDirection.RightToLeft; }

            translate();
            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            cb_areaFax.SelectedIndex = 0;
            cb_areaFaxLocal.SelectedIndex = 0;
            //pass parameter type (V for vendors, C for Clients , B for Both)

            var agents = await agentModel.GetAgentsAsync("v");
            dg_vendor.ItemsSource = agents;

        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
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
            //if (tb_balance.Text.Equals(""))
            //{
            //    p_errorBalance.Visibility = Visibility.Visible;
            //    tt_errorBalance.Content = MainWindow.resourcemanager.GetString("trEmptyBalanceToolTip");
            //}
            //else
            //{
            //    p_errorBalance.Visibility = Visibility.Collapsed;

            //}
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
            //if ((!tb_name.Text.Equals("")) && (!tb_balance.Text.Equals("")))
            //{
            //    string acc = cb_accType.Text;

            //    if (acc == "Cash") acc = "c";
            //    else if (acc == "Debt") acc = "d";
            //    else acc = "c";

                Agent vendor = new Agent
                {
                    name = tb_name.Text,
                    code = "",
                    company = tb_company.Text,
                    address = tb_address.Text,
                  //  details = tb_details.Text,
                    email = tb_email.Text,
                    phone = tb_phone.Text,
                    mobile = cb_areaMobile.Text + tb_mobile.Text,
                    image = "",
                    type = "v",
                    //accType = acc,
                    //balance = Single.Parse(tb_balance.Text),
                    isDefault = 0,
                    createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    createUserId = 1,
                    updateUserId = 1,
                    notes = tb_notes.Text,
                    isActive = 1,
                };
                await agentModel.saveAgent(vendor);

                //pass parameter type (V for vendors, C for Clients , B for Both)
                var agents = await agentModel.GetAgentsAsync("v");
                dg_vendor.ItemsSource = agents;
            }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            //update
            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
            }
            //if (tb_balance.Text.Equals(""))
            //{
            //    p_errorBalance.Visibility = Visibility.Visible;
            //    tt_errorBalance.Content = MainWindow.resourcemanager.GetString("trEmptyBalanceToolTip");
            ////}
            //else
            //{
            //    p_errorBalance.Visibility = Visibility.Collapsed;

            //}
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
            if ((!tb_name.Text.Equals("")) )
            {
                //string acc = cb_accType.Text;

                //if (acc == "Cash") acc = "c";
                //else if (acc == "Debt") acc = "d";
                //else acc = "c";

                Agent vendor = new Agent
                {
                    agentId = AgentId,
                    name = tb_name.Text,
                    code = "",
                    company = tb_company.Text,
                    address = tb_address.Text,
                    email = tb_email.Text,
                    phone = tb_phone.Text,
                    mobile = cb_areaMobile.Text + tb_mobile.Text,
                    image = "",
                    type = "v",
                    isDefault = 0,
                    createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    createUserId = 1,
                    updateUserId = 1,
                    notes = tb_notes.Text,
                    isActive = 1,

                };

             //   await agentModel.saveAgent(vendor);

                //pass parameter type (V for vendors, C for Clients , B for Both)
              //  var agents = await agentModel.GetAgentsAsync("v");
               // dg_vendor.ItemsSource = agents;
            }
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            //delete

          //  await agentModel.deleteAgent(AgentId);

            //pass parameter type (V for vendors, C for Clients , B for Both)
         //   var agents = await agentModel.GetAgentsAsync("v");
          //  dg_vendor.ItemsSource = agents;

            //clear textBoxs
            AgentId = 0;
            tb_name.Clear();
            tb_company.Clear();
            tb_address.Clear();
            tb_fax.Clear();
            tb_email.Clear();
            tb_phone.Clear();
            tb_mobile.Clear();
            //cb_accType.SelectedIndex = -1;
            //tb_balance.Clear();
            tb_notes.Clear();
        }
    

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                //<!--15FF0000-->
                //var bc = new BrushConverter();
                //tt_errorEmail.Background = (Brush)bc.ConvertFrom("#15FF0000");

                //tt_errorEmail.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#082049");

                //tt_errorEmail.Background = new SolidColorBrush(Colors.Red);
                //Use the following code to remove the background you set on it.
                //tb_name.ClearValue(TextBox.BackgroundProperty);
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        //private void Tb_balance_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    var bc = new BrushConverter();

        //    if (tb_balance.Text.Equals(""))
        //    {
        //        p_errorBalance.Visibility = Visibility.Visible;
        //        tt_errorBalance.Content = MainWindow.resourcemanager.GetString("trEmptyBalanceToolTip");
        //        tb_balance.Background = (Brush)bc.ConvertFrom("#15FF0000");
        //    }
        //    else
        //    {
        //        p_errorBalance.Visibility = Visibility.Collapsed;
        //        tb_balance.Background = (Brush)bc.ConvertFrom("#f8f8f8");
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
    }
}

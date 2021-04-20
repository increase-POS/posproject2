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


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DG_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
            }
        }

        private async void  Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            string acc = cb_accType.Text;

            if (acc=="Cash")        acc = "c";
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
                mobile       = tb_mobile.Text,
                image        = "",
                type         = "c",
                accType      = acc,
                balance      = Single.Parse(tb_balance.Text),
                isDefault    = 0 ,
                createDate   = DateTime.Now,
                updateDate   = DateTime.Now,
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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucCustomer.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucCustomer.FlowDirection = FlowDirection.RightToLeft; }

            translate();

            //pass parameter type (V for vendors, C for Clients , B for Both)
            var agents = await agentModel.GetAgentsAsync("c");
            dg_customer.ItemsSource = agents;
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

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

            string acc = cb_accType.Text;

            if (acc == "Cash") acc = "c";
            else if (acc == "Debt") acc = "d";
            else acc = "c";

            Agent customer = new Agent
            {
                agentId      = AgentId,
                name         = tb_name.Text,
                code         = "",
                company      = tb_company.Text,
                address      = tb_address.Text,
                details      = tb_details.Text,
                email        = tb_email.Text,
                phone        = tb_phone.Text,
                mobile       = tb_mobile.Text,
                image        = "",
                type         = "c",
                accType      = acc,
                balance      = Single.Parse(tb_balance.Text),
                isDefault    = 0,
                createDate   = DateTime.Now,
                updateDate   = DateTime.Now,
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
    }
}

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
        {
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
           // tb_search.Text = MainWindow.resourcemanager.GetString("trSearchHint");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            //cb_search.Text = MainWindow.resourcemanager.GetString("trPamentMethodHint");////////////????
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trPamentMethodHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_baseInformation, MainWindow.resourcemanager.GetString("trBaseInformation"));
            //tb_name.Text = MainWindow.resourcemanager.GetString("trNameHint");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            //tb_address.Text = MainWindow.resourcemanager.GetString("trAdressHint");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            //tb_company.Text = MainWindow.resourcemanager.GetString("trCompanyHint");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_company, MainWindow.resourcemanager.GetString("trCompanyHint"));
            txt_contentInformatin.Text = MainWindow.resourcemanager.GetString("trContactInformation");
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_contentInformatin, MainWindow.resourcemanager.GetString("trContactInformation"));
            //cb_area.Text = MainWindow.resourcemanager.GetString("trAreaHint");///////??????????
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_area, MainWindow.resourcemanager.GetString("trAreaHint"));
            //tb_mobile.Text = MainWindow.resourcemanager.GetString("trMobileHint");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            //tb_phone.Text = MainWindow.resourcemanager.GetString("trPhoneHint");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            //tb_email.Text = MainWindow.resourcemanager.GetString("trEmailHint");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            txt_anotherInformation.Text = MainWindow.resourcemanager.GetString("trAnotherInfomation");
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_anotherInformation, MainWindow.resourcemanager.GetString("trAnotherInfomation"));
            //tb_details.Text = MainWindow.resourcemanager.GetString("trDetailsHint");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_details, MainWindow.resourcemanager.GetString("trDetailsHint"));
            //cb_accType.Text = MainWindow.resourcemanager.GetString("trPamentMethodHint");/////??????
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_accType, MainWindow.resourcemanager.GetString("trPamentMethodHint"));
            //tb_balance.Text = MainWindow.resourcemanager.GetString("trBalanceHint");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_balance, MainWindow.resourcemanager.GetString("trBalanceHint"));
            //tb_notes.Text = MainWindow.resourcemanager.GetString("trNoteHint");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
        }
    }
}

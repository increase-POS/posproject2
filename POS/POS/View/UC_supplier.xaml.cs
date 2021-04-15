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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_supplier.xaml
    /// </summary>
    public partial class UC_supplier : UserControl
    {
        public int AgentId;
        public UC_supplier()
        {
            InitializeComponent();
            List<Agent> suppliers = new List<Agent>();

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
                name = TB_name.Text
            };

            DG_supplier.ItemsSource = suppliers;
        }

        private void DG_supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Agent agent = new Agent();
            if (DG_supplier.SelectedIndex != -1)
            {
                agent = DG_supplier.SelectedItem as Agent;
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
    }
}

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

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_customersList.xaml
    /// </summary>
    public partial class wd_customersList : Window
    {
        public wd_customersList()
        {
            InitializeComponent();
        }
        public bool isActive;
        Agent agent = new Agent();
        List<Agent> allAgents = new List<Agent>();
        public List<Agent> selectedAgents = new List<Agent>();
        Agent agentModel = new Agent();
        public string txtAgentSearch;
        /// <summary>
        /// Selcted Items if selectedItems Have Items At the beginning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            allAgents = (await agentModel.GetAgentsAsync("c")).Where(x => x.isActive == 1).ToList();

            foreach (var agent in selectedAgents)
            {
                allAgents.Remove(agent);

            }
            selectedAgents.AddRange(selectedAgents);


            lst_allAgents.ItemsSource = allAgents;
            lst_selectedAgents.ItemsSource = selectedAgents;



            lst_allAgents.SelectedValuePath = "agentId";
            lst_selectedAgents.SelectedValuePath = "agentId";
            lst_allAgents.DisplayMemberPath = "name";
            lst_selectedAgents.DisplayMemberPath = "name";
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }
        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            isActive = true;
            this.Close();
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            this.Close();
        }
        private void Lst_allAgents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Btn_selectedAgent_Click(null, null);

        }
        private void Lst_selectedAgents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_unSelectedAgent_Click(null, null);

        }
        private async void Btn_selectedAll_Click(object sender, RoutedEventArgs e)
        {
            selectedAgents = (await agentModel.GetAgentsAsync("c")).Where(x => x.isActive == 1).ToList();
            allAgents.Clear();
            lst_allAgents.ItemsSource = allAgents;
            lst_selectedAgents.ItemsSource = selectedAgents;
            lst_allAgents.Items.Refresh();
            lst_selectedAgents.Items.Refresh();
        }
        private void Btn_selectedAgent_Click(object sender, RoutedEventArgs e)
        {
            agent = lst_allAgents.SelectedItem as Agent;
            if (agent != null)
            {
                allAgents.Remove(agent);
                selectedAgents.Add(agent);
                lst_allAgents.ItemsSource = allAgents;
                lst_selectedAgents.ItemsSource = selectedAgents;
                lst_allAgents.Items.Refresh();
                lst_selectedAgents.Items.Refresh();
            }

        }
        private void Btn_unSelectedAgent_Click(object sender, RoutedEventArgs e)
        {

            agent = lst_selectedAgents.SelectedItem as Agent;
            if (agent != null)
            {
                selectedAgents.Remove(agent);
                allAgents.Add(agent);

                lst_allAgents.ItemsSource = allAgents;
                lst_allAgents.Items.Refresh();
                lst_selectedAgents.ItemsSource = selectedAgents;
                lst_selectedAgents.Items.Refresh();
            }
        }
        private async void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {
            allAgents = (await agentModel.GetAgentsAsync("c")).Where(x => x.isActive == 1).ToList();
            selectedAgents.Clear();
            lst_allAgents.ItemsSource = allAgents;
            lst_allAgents.Items.Refresh();
            lst_selectedAgents.ItemsSource = selectedAgents;
            lst_selectedAgents.Items.Refresh();

        }
        private void Txb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAgentSearch = txb_search.Text.ToLower();
            lst_allAgents.ItemsSource = allAgents.Where(x => (x.code.ToLower().Contains(txtAgentSearch) ||
            x.name.ToLower().Contains(txtAgentSearch)
            ) && x.isActive == 1);
        }
    }
}

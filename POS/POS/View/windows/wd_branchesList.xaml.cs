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
    /// Interaction logic for wd_branchesList.xaml
    /// </summary>
    public partial class wd_branchesList : Window
    {
        public bool isActive;
        public int Id { get; set; }
        public char userOrBranch { get; set; }

        Branch branchModel = new Branch();
        BranchesUsers branchUserModel = new BranchesUsers();

        List<Branch> allStoresSource = new List<Branch>();
        List<BranchesUsers> selectedStoresByUserSource = new List<BranchesUsers>();

        List<Branch> allStores = new List<Branch>();
        List<BranchesUsers> selectedStoresByUser = new List<BranchesUsers>();

        Branch branch = new Branch();
        BranchesUsers branchUser = new BranchesUsers();

        IEnumerable<Branch> storeQuery;

        string searchText = "";

        public string txtStoreSearch;
        public wd_branchesList()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            translat();
            //MessageBox.Show(Id.ToString());
            allStoresSource = await branchModel.GetAll();////active branch and store 
            //chk user or branch
            if (userOrBranch == 'u')
            {
                selectedStoresByUserSource = await branchUserModel.GetBranchesByUserId(Id);
                selectedStoresByUser.AddRange(selectedStoresByUserSource);
                //remove selected items from all items
                foreach (var i in selectedStoresByUser)
                {
                    branch = allStoresSource.Where(s => s.branchId == i.branchId).FirstOrDefault<Branch>();
                    allStores.Remove(branch);
                }
                dg_selectedStores.ItemsSource = selectedStoresByUser;
                dg_selectedStores.SelectedValuePath = "branchId";
                dg_selectedStores.DisplayMemberPath = "name";
            }
            else if (userOrBranch == 'b')
            { }
            else if (userOrBranch == 's')
            { }

            allStores.AddRange(allStoresSource);

            dg_allStores.ItemsSource = allStores;
            dg_allStores.SelectedValuePath = "branchId";
            dg_allStores.DisplayMemberPath = "name";

          
        }

        private void translat()
        {

        }
        private void Dg_selectedStores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_unSelectedStore_Click(null, null);
        }

        private void Dg_allStores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_selectedStore_Click(null, null);
        }

        private void Btn_selectedAll_Click(object sender, RoutedEventArgs e)
        {//select all
            int x = allStores.Count;
            for (int i = 0; i < x; i++)
            {
                dg_allStores.SelectedIndex = 0;
                Btn_selectedStore_Click(null, null);
            }
        }

        private void Btn_selectedStore_Click(object sender, RoutedEventArgs e)
        {//select one 
            branch = dg_allStores.SelectedItem as Branch;
            if (branch != null)
            {
                allStores.Remove(branch);
                if(userOrBranch == 'u')
                {
                    BranchesUsers bu = new BranchesUsers();
                    bu.branchsUsersId = 0;
                    bu.branchId = branch.branchId;
                    bu.userId = Id;
                    bu.createUserId = MainWindow.userID;
                    selectedStoresByUser.Add(bu);
                    dg_selectedStores.ItemsSource = selectedStoresByUser;

                }

                dg_allStores.ItemsSource = allStores;

                dg_allStores.Items.Refresh();
                dg_selectedStores.Items.Refresh();
            }
        }

        private void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {//unselect all
            int x = 0;
            if (userOrBranch == 'u')
                x = selectedStoresByUser.Count;

            for (int i = 0; i < x; i++)
            {
                dg_selectedStores.SelectedIndex = 0;
                Btn_unSelectedStore_Click(null, null);
            }
        }

        private void Btn_unSelectedStore_Click(object sender, RoutedEventArgs e)
        {//unselect one
            if (userOrBranch == 'u')
            {
                branchUser = dg_selectedStores.SelectedItem as BranchesUsers;
                if (branchUser != null)
                {
                    branch = allStoresSource.Where(s => s.branchId == branchUser.branchId.Value).FirstOrDefault();

                    allStores.Add(branch);

                    selectedStoresByUser.Remove(branchUser);

                    dg_selectedStores.ItemsSource = selectedStoresByUser;
                }
                dg_allStores.ItemsSource = allStores;
                dg_allStores.Items.Refresh();
                dg_selectedStores.Items.Refresh();

            }

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }

        private void Txb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            txtStoreSearch = txb_search.Text.ToLower();

            //if (allStores is null)
            //    allStores = allStoresSource;
            searchText = txb_search.Text;
            storeQuery = allStores.Where(s => s.name.Contains(searchText) );
            dg_allStores.ItemsSource = storeQuery;
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {//close
            isActive = false;
            this.Close();
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }
    }
}

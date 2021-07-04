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
        BranchStore branchStoreModel = new BranchStore();

        List<Branch> allStoresSource = new List<Branch>();
        List<BranchesUsers> selectedStoresByUserSource = new List<BranchesUsers>();
        List<BranchStore> selectedStoresByBranchSource = new List<BranchStore>();

        List<Branch> allStores = new List<Branch>();
        List<BranchesUsers> selectedStoresByUser = new List<BranchesUsers>();
        List<BranchStore> selectedStoresByBranch = new List<BranchStore>();

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
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_branchList.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_branchList.FlowDirection = FlowDirection.RightToLeft; }

            translat();
            //MessageBox.Show(Id.ToString());
            allStoresSource = await branchModel.GetAll();////active branch and store 
            //chk user or branch
            var dgtc = dg_selectedStores.Columns[0] as DataGridTextColumn;

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
                dgtc.Binding = new System.Windows.Data.Binding("bname");

                dg_selectedStores.ItemsSource = selectedStoresByUser;
                dg_selectedStores.SelectedValuePath = "branchId";
                dg_selectedStores.DisplayMemberPath = "bname";
            }
            else
            {
                selectedStoresByBranchSource = await branchStoreModel.GetAll();
                selectedStoresByBranchSource = selectedStoresByBranchSource.Where(s => s.branchId == Id).ToList();
                selectedStoresByBranch.AddRange(selectedStoresByBranchSource);
                //remove selected items from all items
                foreach (var i in selectedStoresByBranch)
                {
                    branch = allStoresSource.Where(s => s.branchId == i.branchId).FirstOrDefault<Branch>();
                    allStores.Remove(branch);
                }
                dgtc.Binding = new System.Windows.Data.Binding("sname");

                dg_selectedStores.ItemsSource = selectedStoresByBranch;
                dg_selectedStores.SelectedValuePath = "branchId";
                dg_selectedStores.DisplayMemberPath = "sname";
            }

            allStores.AddRange(allStoresSource);

            dg_allStores.ItemsSource = allStores;
            dg_allStores.SelectedValuePath = "branchId";
            dg_allStores.DisplayMemberPath = "name";

          
        }

        private void translat()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_search, MainWindow.resourcemanager.GetString("trSearchHint"));

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

            dg_allStores.Columns[0].Header = MainWindow.resourcemanager.GetString("trBranch/Store");
            dg_selectedStores.Columns[0].Header = MainWindow.resourcemanager.GetString("trBranch/Store");

            txt_title.Text = MainWindow.resourcemanager.GetString("trBranchs/Stores");
            txt_stores.Text = MainWindow.resourcemanager.GetString("trBranchs/Stores");
            txt_selectedStores.Text = MainWindow.resourcemanager.GetString("trSelectedBranchs/Stores");

            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_selectAllItem.Content = MainWindow.resourcemanager.GetString("trSelectAllItems");
            tt_unselectAllItem.Content = MainWindow.resourcemanager.GetString("trUnSelectAllItems");
            tt_selectItem.Content = MainWindow.resourcemanager.GetString("trSelectOneItem");
            tt_unselectItem.Content = MainWindow.resourcemanager.GetString("trUnSelectOneItem");
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
                    bu.bname = branch.name;
                    bu.createUserId = MainWindow.userID;

                    selectedStoresByUser.Add(bu);
                    dg_selectedStores.ItemsSource = selectedStoresByUser;

                }
                else
                {
                    BranchStore bs = new BranchStore();
                    bs.id = 0;
                    bs.branchId = Id;
                    bs.storeId = branch.branchId;
                    bs.createUserId = MainWindow.userID;
                    bs.sname = branch.name;
                    bs.isActive = 1;
                    selectedStoresByBranch.Add(bs);
                    dg_selectedStores.ItemsSource = selectedStoresByBranch;
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
            else
                x = selectedStoresByBranch.Count;

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

        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            string s = "";
            if (userOrBranch == 'u')
            {
                s = await branchUserModel.UpdatebranchesByuserId(Id, selectedStoresByUser, MainWindow.userID.Value);
            }
            else
                s = await branchStoreModel.UpdateStoresById(selectedStoresByBranch, Id, MainWindow.userID.Value);

            MessageBox.Show(s);
            isActive = true;
            this.Close();
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

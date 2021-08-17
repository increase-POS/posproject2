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
    /// Interaction logic for wd_usersList.xaml
    /// </summary>
    public partial class wd_usersList : Window
    {
        public wd_usersList()
        {
            InitializeComponent();
        }


        public bool isActive;
       
        List<User> allUsersSource = new List<User>();
        List<User> selectedUsersSource = new List<User>();

        List<User> allUsers = new List<User>();
        List<User> selectedUsers = new List<User>();

        public int groupId = 0;

        User userModel = new User();
        User user = new User();

        Group groupModel = new Group();
        /// <summary>
        /// Selcted Users if selectedUsers Have Users At the beginning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            SectionData.StartAwait(grid_mainGrid);
            #region translate
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_users.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_users.FlowDirection = FlowDirection.RightToLeft; }

            translat();
            #endregion

            allUsersSource = await userModel.GetUsersActive();
            selectedUsersSource = await groupModel.GetUsersByGroupId(groupId);
            foreach(var u in selectedUsersSource)
            {
                u.fullName = u.name + " " + u.lastname;
            }
            allUsers.AddRange(allUsersSource);
            selectedUsers.AddRange(selectedUsersSource);

            //remove selected users from all users
            foreach (var su in selectedUsers)
            {
                for(int i = 0; i < allUsers.Count; i++)
                if (su.userId == allUsers[i].userId)
                {
                    allUsers.Remove(allUsers[i]);
                }
            }

            lst_allUsers.ItemsSource = allUsers;
            lst_allUsers.SelectedValuePath = "fullName";
            lst_allUsers.DisplayMemberPath = "userId";

            lst_selectedUsers.ItemsSource = selectedUsers;
            lst_selectedUsers.SelectedValuePath = "fullName";
            lst_selectedUsers.DisplayMemberPath = "userId";
            SectionData.EndAwait(grid_mainGrid,this);
        }

        private void translat()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_search , MainWindow.resourcemanager.GetString("trSearchHint"));
            txt_user.Text = MainWindow.resourcemanager.GetString("trUsers");
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

            lst_allUsers.Columns[0].Header = MainWindow.resourcemanager.GetString("trUser");
            lst_selectedUsers.Columns[0].Header = MainWindow.resourcemanager.GetString("trUser");

            txt_users.Text = MainWindow.resourcemanager.GetString("trUsers");
            txt_selectedUsers.Text = MainWindow.resourcemanager.GetString("trSelectedUsers");

            tt_selectAllItem.Content = MainWindow.resourcemanager.GetString("trSelectAllItems");
            tt_unselectAllItem.Content = MainWindow.resourcemanager.GetString("trUnSelectAllItems");
            tt_selectItem.Content = MainWindow.resourcemanager.GetString("trSelectOneItem");
            tt_unselectItem.Content = MainWindow.resourcemanager.GetString("trUnSelectOneItem");

        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            //get selcted ids
            List<int> userIds = new List<int>();
            foreach (var u in selectedUsers)
                userIds.Add(u.userId);

            await groupModel.UpdateGroupIdInUsers(groupId, userIds, MainWindow.userID.Value);

            isActive = true;
            this.Close();
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            this.Close();
        }

        private void Lst_allUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Btn_selectedUser_Click(null, null);

        }

        private void Lst_selectedUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_unSelectedUser_Click(null, null);

        }


        private async void Btn_selectedAll_Click(object sender, RoutedEventArgs e)
        {//select all
            int x = allUsers.Count;
            for (int i = 0; i < x; i++)
            {
                //MessageBox.Show(i.ToString());
                lst_allUsers.SelectedIndex = 0;
                Btn_selectedUser_Click(null, null);
            }
        }
        private void Btn_selectedUser_Click(object sender, RoutedEventArgs e)
        {//select one
            user = lst_allUsers.SelectedItem as User;
            if (user != null)
            {
                allUsers.Remove(user);
                selectedUsers.Add(user);

                lst_allUsers.ItemsSource = allUsers;
                lst_selectedUsers.ItemsSource = selectedUsers;

                lst_allUsers.Items.Refresh();
                lst_selectedUsers.Items.Refresh();
            }

        }


        private void Btn_unSelectedUser_Click(object sender, RoutedEventArgs e)
        {//unselect one
            user = lst_selectedUsers.SelectedItem as User;
            if (user != null)
            {
                selectedUsers.Remove(user);

                allUsers.Add(user);

                lst_allUsers.ItemsSource = allUsers;
                lst_selectedUsers.ItemsSource = selectedUsers;

                lst_allUsers.Items.Refresh();
                lst_selectedUsers.Items.Refresh();
            }
        }

        private async void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {//unselect all
            int x = selectedUsers.Count;
            for (int i = 0; i < x; i++)
            {
                lst_selectedUsers.SelectedIndex = 0;
                Btn_unSelectedUser_Click(null, null);
            }

        }

        private void Txb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            lst_allUsers.ItemsSource = allUsers.Where(x => (x.fullName.ToLower().Contains(txb_search.Text.ToLower())) && x.isActive == 1);
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
        private void Grid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //// Have to do this in the unusual case where the border of the cell gets selected.
            //// and causes a crash 'EditItem is not allowed'
            e.Cancel = true;
        }
    }
}

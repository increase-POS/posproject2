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
    /// Interaction logic for UC_users.xaml
    /// </summary>
    public partial class UC_users : UserControl
    {
        public int UsersId;
        public UC_users()
        {
            InitializeComponent();


            //List<Users> users = new List<Users>();



            //for (int i = 1; i < 50; i++)
            //{
            //    users.Add(new Users()
            //    {
            //        userID = i,
            //        password = "test pass"+i ,
            //        firstName = "Test  firstName " + i,
            //        lastName = "Test lastName " + i,
            //        address = "Test address" + i,
            //        userName = "Test userName" + i,
            //        mobile = "Test mobile" + i,
            //        phone = "Test phone" + i,
            //        email = "Test email" + i,
            //        details = "Test details" + i,
            //        job = "job"+i,
            //        workHours = 2*i,
            //    }); 
            //}

            //Users user = new Users
            //{

            //    userID = UsersId,
            //    firstName = TB_firstName.Text
            //};



            //DG_users.ItemsSource = users;
        }

        private void DG_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Users user = new Users();
            //if (DG_users.SelectedIndex != -1)
            //{
            //    user = DG_users.SelectedItem as Users;
            //    this.DataContext = user;
            //}
            //if (user != null)
            //{
            //    if (user.userID != 0)
            //    {
            //        UsersId = user.userID;
            //    }
            //}
        }
    }
}


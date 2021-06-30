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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for winLogIn.xaml
    /// </summary>
    public partial class winLogIn : Window
    {
        public winLogIn()
        {
            InitializeComponent();
        }

        User userModel = new User();
        User user = new User();
        IEnumerable<User> usersQuery;
        IEnumerable<User> users;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) { try { DragMove(); } catch (Exception) { } }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //bdrLogIn.RenderTransform = Animations.borderAnimation(-100, bdrLogIn, true);
        }

        private async void btnLogIn_Click(object sender, RoutedEventArgs e)
        {//login
            users = await userModel.GetUsersActive();
            string password = Md5Encription.MD5Hash("Inc-m" + txtPassword.Password);
            //check if user is exist
            if (users.Any(i => i.username == txtUserName.Text && i.password == password))
            {
                //get user info
                user = users.Where(i => i.username == txtUserName.Text && i.password == password).FirstOrDefault<User>();
                
                //send user info to main window
                MainWindow.userID = user.userId;
                MainWindow.userLogin = user;
              
                //make user online
                user.isOnline = 1;
                //user.isActive = 1;
                string s = await userModel.saveUser(user);

                //create lognin record
                ///////////????????????????????

                //open main window and close this window
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
        }
        private  void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnLogIn_Click(null, null);
            }
        }
    }
}

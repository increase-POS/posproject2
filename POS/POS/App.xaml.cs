using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace POS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {//set startup window
            //user21-6-2021
            //if(somecase)
            //{
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //}
            //else
            //{
            winLogIn logIn = new winLogIn();
            logIn.Show();
            //}

        }
        //protected override void OnStartup(StartupEventArgs e)
        //{

        //}
    }
}

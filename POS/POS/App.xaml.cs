﻿using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Globalization;
using POS.Classes;

namespace POS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
               // if (POS.Properties.Settings.Default.posId == "0")
                if (config.AppSettings.Settings["posId"] == null)
                {
                    //wd_setupOtherPos logIn = new wd_setupOtherPos();
                    //logIn.Show();
                    wd_setupFirstPos logIn = new wd_setupFirstPos();
                    logIn.Show();
                }
                else
                {
                    winLogIn logIn = new winLogIn();
                    logIn.Show();
                }

                //wd_setupOtherPos logIn = new wd_setupOtherPos();
                //logIn.Show();

            }
		 catch (Exception ex)
            {
				SectionData.ExceptionMessage(ex,this);
        }
    }
       
    }
}

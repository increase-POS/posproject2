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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");


            winLogIn logIn = new winLogIn();
            logIn.Show();

        }
		 catch (Exception ex)
            {
				SectionData.ExceptionMessage(ex,this, sender);
        }
    }
       
    }
}

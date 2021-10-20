using POS.Classes;
using POS.View.setup;
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
    /// Interaction logic for wd_setupFirstPos.xaml
    /// </summary>
    public partial class wd_setupFirstPos : Window
    {
        public wd_setupFirstPos()
        {
            InitializeComponent();
        }

        public static ResourceManager resourcemanager;
        public bool isValid = false;
        int pageIndex = 0;
        public class keyValueString
        {
            public string key { get; set; }
            public string value { get; set; }
        }
        static public List<keyValueString> list = new List<keyValueString>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load
            try
            {
                resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());

                if (sender != null)
                    SectionData.StartAwait(grid_mainWindow);
                #region InitializeList
                list.Add(new keyValueString { key = "serverUri", value = "" });
                list.Add(new keyValueString { key = "activationkey", value = "" });

                #endregion

                CallPage(0, btn_next.Tag.ToString());


                if (sender != null)
                    SectionData.EndAwait(grid_mainWindow);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_mainWindow);
                SectionData.ExceptionMessage(ex, this);
            }
        }
         
        void CallPage(int index, string type)
        {
            if(index == 0)
            {
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_serverConfig.Instance);
            }
            else if (index == 1)
            {
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_FirstPosGeneralSettings.Instance);
            }
        }
       
        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            pageIndex--;
            CallPage(pageIndex, (sender as Button).Tag.ToString());
        }
       

        private void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            
            isValid = true;
            // uc_serverConfig
            if (pageIndex == 0)
            {
                foreach (var item in list)
                {
                    if (item.key.Equals("serverUri"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_serverConfig.Instance.serverUri))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                            item.value = uc_serverConfig.Instance.serverUri;
                        
                    }
                    else if (item.key.Equals("activationkey"))
                    {
                        
                        if (string.IsNullOrWhiteSpace(uc_serverConfig.Instance.activationkey ))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                            item.value = uc_serverConfig.Instance.activationkey;
                    }
                }

            }
            else if (pageIndex == 1)
            {

            }

            string s = "";
            foreach (var item in list)
            {
                s+= item.key +" - " + item.value + "\n";
            }
            MessageBox.Show(s + "\n" + isValid);
            if (isValid)
            {
                pageIndex++;
                CallPage(pageIndex, (sender as Button).Tag.ToString());
            }
             
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);

                if (e.Key == Key.Return)
                {
                    Btn_next_Click(btn_next, null);
                }
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
    }
}

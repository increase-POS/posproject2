using netoaster;
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
     
        int _pageIndex;
        int pageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;
                OnPropertyChanged();
            }
        }
        static public int countryId;
        static public string imgFileName = "pic/no-image-icon-125x125.png";
        static public ImageBrush brush = new ImageBrush();

        protected void OnPropertyChanged()
        {
            txt_pageIndex.Text =(_pageIndex+1).ToString();

            if (_pageIndex == 0)
                btn_back.IsEnabled = false;
            else
                btn_back.IsEnabled = true;

            if (_pageIndex == 2)
                btn_next.Content = "Done";
            else
                btn_next.Content = "Next";
        }
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
                pageIndex = 0;
                resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());

                
                #region InitializeList
                list.Add(new keyValueString { key = "serverUri", value = "" });
                list.Add(new keyValueString { key = "activationkey", value = "" });

                list.Add(new keyValueString { key = "countryId", value = "" });
                list.Add(new keyValueString { key = "userName", value = "" });
                list.Add(new keyValueString { key = "userPassword", value = "" });
                list.Add(new keyValueString { key = "branchName", value = "" });
                list.Add(new keyValueString { key = "branchMobile", value = "" });
                list.Add(new keyValueString { key = "posName", value = "" });

                list.Add(new keyValueString { key = "companyName", value = "" });
                list.Add(new keyValueString { key = "address", value = "" });
                list.Add(new keyValueString { key = "email", value = "" });
                list.Add(new keyValueString { key = "mobile", value = "" });
                list.Add(new keyValueString { key = "phone", value = "" });
                list.Add(new keyValueString { key = "fax", value = "" });


        #endregion

        CallPage(0, btn_next.Tag.ToString());

            }
            catch (Exception ex)
            {
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
            else if (index == 2)
            {
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_companyInfo.Instance);
            }
        }
       
        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            pageIndex--;
            CallPage(pageIndex, (sender as Button).Tag.ToString());
        }
       

        private async void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            isValid = true;
            // uc_serverConfig
            if (pageIndex == 0)
            {
                var supsublist = list.Take(2);
                foreach (var item in supsublist)
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
                        {
                            item.value = uc_serverConfig.Instance.serverUri;
                            bool validUrl = setupConfiguration.validateUrl(item.value);
                            if (!validUrl)
                            {
                                Toaster.ShowWarning(Window.GetWindow(this), message: wd_setupFirstPos.resourcemanager.GetString("trErrorWrongUrl"), animation: ToasterAnimation.FadeIn);
                                isValid = false;
                                break;
                            }
                        }
                        
                    }
                    else if (item.key.Equals("activationkey"))
                    {

                        if (string.IsNullOrWhiteSpace(uc_serverConfig.Instance.activationkey))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                        {
                            item.value = uc_serverConfig.Instance.activationkey;
                        }
                    }
                }
                // for watch list
                string s = "";
                foreach (var item in supsublist)
                {
                    s += item.key + " - " + item.value + "\n";
                }
                MessageBox.Show(s + "\n" + isValid);
            }
            else if (pageIndex == 1)
            {
                var supsublist = list.Skip(2).Take(6);
                foreach (var item in supsublist)
                {
                    if (item.key.Equals("countryId"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_FirstPosGeneralSettings.Instance.countryId))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                        {
                            item.value = uc_FirstPosGeneralSettings.Instance.countryId;
                            countryId = int.Parse(item.value);
                        }

                    }
                    else if (item.key.Equals("userName"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_FirstPosGeneralSettings.Instance.userName))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                            item.value = uc_FirstPosGeneralSettings.Instance.userName;

                    }
                    else if (item.key.Equals("userPassword"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_FirstPosGeneralSettings.Instance.userPassword))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                            item.value = uc_FirstPosGeneralSettings.Instance.userPassword;

                    }
                    else if (item.key.Equals("branchName"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_FirstPosGeneralSettings.Instance.branchName))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                            item.value = uc_FirstPosGeneralSettings.Instance.branchName;

                    }
                    else if (item.key.Equals("branchMobile"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_FirstPosGeneralSettings.Instance.branchMobile))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                            item.value = uc_FirstPosGeneralSettings.Instance.branchMobile;

                    }
                    else if (item.key.Equals("posName"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_FirstPosGeneralSettings.Instance.posName))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                            item.value = uc_FirstPosGeneralSettings.Instance.posName;

                    }

                }
                // for watch list
                string s = "";
                foreach (var item in supsublist)
                {
                    s += item.key + " - " + item.value + "\n";
                }
                MessageBox.Show(s + "\n" + isValid);
            }
            else if (pageIndex == 2)
            {
                var supsublist = list.Skip(8).Take(6);
                foreach (var item in supsublist)
                {
                    if (item.key.Equals("companyName"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_companyInfo.Instance.companyName))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                        {
                            item.value = uc_companyInfo.Instance.companyName;
                        }
                    }
                   else if (item.key.Equals("address"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_companyInfo.Instance.address))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                        {
                            item.value = uc_companyInfo.Instance.address;
                         }
                    }
                    else if (item.key.Equals("email"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_companyInfo.Instance.email))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                        {
                            item.value = uc_companyInfo.Instance.email;
                         }
                    }
                    else if (item.key.Equals("mobile"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_companyInfo.Instance.mobile))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                        {
                            item.value = uc_companyInfo.Instance.mobile;
                         }
                    }
                    else if (item.key.Equals("phone"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_companyInfo.Instance.phone))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                        {
                            item.value = uc_companyInfo.Instance.phone;
                         }
                    }
                    else if (item.key.Equals("fax"))
                    {
                        if (string.IsNullOrWhiteSpace(uc_companyInfo.Instance.fax))
                        {
                            item.value = "";
                            isValid = false;
                            break;
                        }
                        else
                        {
                            item.value = uc_companyInfo.Instance.fax;
                         }
                    }
                }


                // for watch list
                string s = "";
                foreach (var item in supsublist)
                {
                    s += item.key + " - " + item.value + "\n";
                }
                MessageBox.Show(s + "\n" + isValid );
                
            }

            

            //if (isValid)
            //{
                if (pageIndex == 0)
                {
                    //dina Work
                    MessageBox.Show("Server Config is done");
                }
                if (pageIndex == 1)
                {
                    //dina Work
                    MessageBox.Show("Setting Config is done");
                }
                if (pageIndex == 2)
                {
                //dina Work
                string url = uc_serverConfig.Instance.serverUri;
                string activationkey = uc_serverConfig.Instance.activationkey;

                string motherCode = setupConfiguration.GetMotherBoardID();
                    string hardCode = setupConfiguration.GetHDDSerialNo();
                    string deviceCode = motherCode + "-" + hardCode;
                    int res = await setupConfiguration.setConfiguration(activationkey,deviceCode);
                    MessageBox.Show("Setup Done");
                    Btn_cancel_Click(btn_cancel, null);
                }
                if(pageIndex < 2)
                {
                    pageIndex++;
                    CallPage(pageIndex, (sender as Button).Tag.ToString());
                }
            //}
            //else
            //    Toaster.ShowWarning(Window.GetWindow(this), message: "Should fill form first", animation: ToasterAnimation.FadeIn);

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

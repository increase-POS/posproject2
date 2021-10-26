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
    /// Interaction logic for wd_setupOtherPos.xaml
    /// </summary>
    public partial class wd_setupOtherPos : Window
    {
        public wd_setupOtherPos()
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
            //txt_pageIndex.Text =(_pageIndex+1).ToString();
            if (_pageIndex == 0)
            {
                path_step1.Visibility = Visibility.Visible;
                path_step2.Visibility = Visibility.Hidden;
            }
            else if (_pageIndex == 1)
            {
                path_step1.Visibility = Visibility.Hidden;
                path_step2.Visibility = Visibility.Visible;
            }
           

            if (_pageIndex == 0)
                btn_back.IsEnabled = false;
            else
                btn_back.IsEnabled = true;

            if (_pageIndex == 1)
                btn_next.Content = "Done";
            else
                btn_next.Content = "Next";
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

                list.Add(new keyValueString { key = "posId", value = "" });
                list.Add(new keyValueString { key = "branchId", value = "" });
                 


                #endregion

                CallPage(0, btn_next.Tag.ToString());

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void CallPage(int index, string type = "")
        {
            if (index == 0)
            {
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_serverConfig.Instance);
            }
            else if (index == 1)
            {
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_selectPos.Instance);
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
                                Toaster.ShowWarning(this, message: "wrong Url", animation: ToasterAnimation.FadeIn);
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
            }
            else if (pageIndex == 1)
            {
                var supsublist = list.Skip(2).Take(2);
                foreach (var item in supsublist)
                {
                    if (item.key.Equals("posId"))
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
                    else if (item.key.Equals("branchId"))
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


                }
            }
          

            //if (isValid)
            //{
            if (pageIndex == 1)
            {
                //server INFO
                string url = uc_serverConfig.Instance.serverUri;
                string activationkey = uc_serverConfig.Instance.activationkey;

                //// user INFO
                //string userName = uc_FirstPosGeneralSettings.Instance.userName;
                //string password = Md5Encription.MD5Hash("Inc-m" + uc_FirstPosGeneralSettings.Instance.userPassword);
                //// branch INFO
                //string branchName = uc_FirstPosGeneralSettings.Instance.branchName;
                //string branchMobile = uc_FirstPosGeneralSettings.Instance.branchMobile;
                //// pos INFO
                //string posName = uc_FirstPosGeneralSettings.Instance.posName;
                //string motherCode = setupConfiguration.GetMotherBoardID();
                //string hardCode = setupConfiguration.GetHDDSerialNo();
                //string deviceCode = motherCode + "-" + hardCode;
                //// company INFO
                //List<SetValues> company = new List<SetValues>();
                //company.Add(new SetValues { name = "com_name", value = uc_companyInfo.Instance.companyName });
                //company.Add(new SetValues { name = "com_address", value = uc_companyInfo.Instance.address });
                //company.Add(new SetValues { name = "com_email", value = uc_companyInfo.Instance.email });
                //company.Add(new SetValues { name = "com_mobile", value = uc_companyInfo.Instance.mobile });
                //company.Add(new SetValues { name = "com_phone", value = uc_companyInfo.Instance.phone });
                //company.Add(new SetValues { name = "com_fax", value = uc_companyInfo.Instance.fax });
                //Global.APIUri = url + "/api/";
                //int res = await setupConfiguration.setConfiguration(activationkey, deviceCode, countryId, userName, password, branchName, branchMobile, posName, company);
                //if (res == -2 || res == -3) // invalid or resrved activation key
                //{
                //    uc_serverConfig.Instance.activationkey = "";
                //    pageIndex = 0;
                //    CallPage(0);
                //    Toaster.ShowWarning(Window.GetWindow(this), message: wd_setupFirstPos.resourcemanager.GetString("trErrorWrongActivation"), animation: ToasterAnimation.FadeIn);
                //    return;
                //}
                //if (res > 0)
                //{
                //    Properties.Settings.Default.APIUri = Global.APIUri;
                //    Properties.Settings.Default.posId = res.ToString();
                //    Properties.Settings.Default.Save();
                //    restartApplication();
                //    //Btn_cancel_Click(btn_cancel, null);
                //}

            }
            if (pageIndex < 1)
            {
                pageIndex++;
                CallPage(pageIndex, (sender as Button).Tag.ToString());
            }
            //}
            //    else
            //        Toaster.ShowWarning(Window.GetWindow(this), message: "Should fill form first", animation: ToasterAnimation.FadeIn);

        }
        private void restartApplication()
        {
            System.Diagnostics.Process.Start("pos.exe");
            Application.Current.Shutdown();
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    Btn_next_Click(btn_next, null);
                }
            }
            catch (Exception ex)
            {
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

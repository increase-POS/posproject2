﻿using POS.Classes;
using netoaster;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Win32;
using System.Windows.Resources;
using System.IO;
using Microsoft.Reporting.WinForms;

using System.Data;
using POS.View.windows;
using POS.View.sectionData.Charts;
using POS.View.sectionData;


namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_updateVendor.xaml
    /// </summary>
    public partial class wd_updateVendor : Window
    {
        public wd_updateVendor()
        {
            InitializeComponent();
        }
        Agent agentModel = new Agent();
        public Agent agent = new Agent();
        IEnumerable<Agent> agentsQuery;
        IEnumerable<Agent> agents;

        OpenFileDialog openFileDialog = new OpenFileDialog();

        string imgFileName = "pic/no-image-icon-125x125.png";

        bool isImgPressed = false;

        ImageBrush brush = new ImageBrush();

        private void translate()
        {
            txt_vendor.Text = MainWindow.resourcemanager.GetString("trVendor");

            //       MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trPamentMethodHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trCodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_company, MainWindow.resourcemanager.GetString("trCompanyHint"));
            txt_contactInformation.Text = MainWindow.resourcemanager.GetString("trContactInformation");
            //          MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_areaMobile, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            txt_moreInformation.Text = MainWindow.resourcemanager.GetString("trAnotherInfomation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_fax, MainWindow.resourcemanager.GetString("trFaxHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));


            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            tt_code.Content = MainWindow.resourcemanager.GetString("trCode");
            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_company.Content = MainWindow.resourcemanager.GetString("trCompany");
            tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
            tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
            tt_fax.Content = MainWindow.resourcemanager.GetString("trFax");
            tt_email.Content = MainWindow.resourcemanager.GetString("trEmail");
            tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_address.Clear();
            tb_fax.Clear();
            tb_company.Clear();
            tb_email.Clear();
            tb_name.Clear();
            tb_notes.Clear();
            tb_mobile.Clear();
            tb_phone.Clear();
            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;

            SectionData.clearImg(img_vendor);

            SectionData.clearValidate(tb_name , p_errorName);
            SectionData.clearValidate(tb_email , p_errorEmail);
            SectionData.clearValidate(tb_mobile , p_errorMobile);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load

            #region translate
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_wdVendor.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_wdVendor.FlowDirection = FlowDirection.RightToLeft; }

            translate();
            #endregion

            agent = await agentModel.getAgentById(agent.agentId);
            if (agent != null)
            {
                this.DataContext = agent;

                tb_code.Text = agent.code;

                SectionData.getMobile(agent.mobile, cb_areaMobile, tb_mobile);

                SectionData.getPhone(agent.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                SectionData.getPhone(agent.fax, cb_areaFax, cb_areaFaxLocal, tb_fax);

                await getImg();
            }

                Keyboard.Focus(tb_name);
        }

        private async Task getImg()
        {
            try
            {
                if (agent.image.Equals(""))
                {
                    SectionData.clearImg(img_vendor);
                }
                else
                {
                    byte[] imageBuffer = await agentModel.downloadImage(agent.image); // read this as BLOB from your DB

                    var bitmapImage = new BitmapImage();
                    if (imageBuffer != null)
                    {
                        using (var memoryStream = new MemoryStream(imageBuffer))
                        {
                            bitmapImage.BeginInit();
                            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                            bitmapImage.StreamSource = memoryStream;
                            bitmapImage.EndInit();
                        }

                        img_vendor.Background = new ImageBrush(bitmapImage);
                        // configure trmporary path
                        string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        string tmpPath = System.IO.Path.Combine(dir, Global.TMPAgentsFolder);
                        tmpPath = System.IO.Path.Combine(tmpPath, agent.image);
                        openFileDialog.FileName = tmpPath;
                    }
                    else
                        SectionData.clearImg(img_vendor);
                }
            }
            catch { }
        }


        #region Validate
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_name_LostFocus(sender, e);
        }
        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (!tb_email.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                {
                    p_errorEmail.Visibility = Visibility.Visible;
                    tt_errorEmail.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                    tb_email.Background = (Brush)bc.ConvertFrom("#15FF0000");
                }
                else
                {
                    p_errorEmail.Visibility = Visibility.Collapsed;
                    tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                }
            }
        }

     

        private void tb_mobile_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_mobile.Text.Equals(""))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyMobileToolTip");
                tb_mobile.Background = (Brush)bc.ConvertFrom("#15FF0000");

            }
            else
            {
                tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_errorMobile.Visibility = Visibility.Collapsed;

            }
        }

        private void tb_mobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_mobile.Text.Equals(""))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyMobileToolTip");
                tb_mobile.Background = (Brush)bc.ConvertFrom("#15FF0000");

            }
            else
            {
                tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_errorMobile.Visibility = Visibility.Collapsed;

            }
        }

        private void tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

       

        private void tb_mobile_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_phone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_fax_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }




        #endregion
        async Task<IEnumerable<Agent>> RefreshVendorsList()
        {
            agents = await agentModel.GetAgentsAsync("v");
            return agents;
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
         //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty mobile
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
            //validate email
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);

            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) 
                phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;
            string faxStr = "";
            if (!tb_fax.Text.Equals("")) 
                faxStr = cb_areaFax.Text + "-" + cb_areaFaxLocal.Text + "-" + tb_fax.Text;
            bool emailError = false;
            if (!tb_email.Text.Equals(""))
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                    emailError = true;

            //decimal maxDeserveValue = 0;

            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")))
            {
                if (emailError)
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorEmailToolTip"), animation: ToasterAnimation.FadeIn);
                else
                {
                    SectionData.genRandomCode("v");
                    //tb_code.Text = SectionData.code;
                    agent.name = tb_name.Text;
                    agent.code = tb_code.Text;
                    agent.company = tb_company.Text;
                    agent.address = tb_address.Text;
                    agent.email = tb_email.Text;
                    agent.phone = phoneStr;
                    agent.mobile = cb_areaMobile.Text + "-" + tb_mobile.Text;
                    agent.image = "";
                    //agent.type = "v";
                    //agent.accType = "";
                    //agent.balance = 0;
                    agent.createUserId = MainWindow.userID;
                    agent.updateUserId = MainWindow.userID;
                    agent.notes = tb_notes.Text;
                    //agent.isActive = 1;
                    agent.fax = faxStr;
                    //agent.maxDeserve = maxDeserveValue;

                    string s = await agentModel.saveAgent(agent);

                    if (!s.Equals("0"))
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                        this.Close();
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    if (isImgPressed)
                    {
                        int agentId = int.Parse(s);
                        string b = await agentModel.uploadImage(imgFileName, Md5Encription.MD5Hash("Inc-m" + agentId.ToString()), agentId);
                        agent.image = b;
                        isImgPressed = false;
                        if (b.Equals(""))
                            MessageBox.Show("حدث خطأ في تحميل الصورة");
                    }

                }
            }
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
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

        private void Img_vendor_Click(object sender, RoutedEventArgs e)
        {//select image
            isImgPressed = true;
            openFileDialog.Filter = "Images|*.png;*.jpg;*.bmp;*.jpeg;*.jfif";
            if (openFileDialog.ShowDialog() == true)
            {
                brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                img_vendor.Background = brush;
                imgFileName = openFileDialog.FileName;
            }

        }
    }
}

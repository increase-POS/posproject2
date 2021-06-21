using POS.Classes;
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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_supplier.xaml
    /// </summary>
    public partial class UC_vendors : UserControl
    {
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        Agent agentModel = new Agent();

        Agent agent = new Agent();

        IEnumerable<Agent> agentsQuery;
        IEnumerable<Agent> agents;
        byte tgl_vendorState;
        string searchText = "";
        //phone variabels
        IEnumerable<CountryCode> countrynum;
        IEnumerable<City> citynum;
        IEnumerable<City> citynumofcountry;

        int? countryid;
        Boolean firstchange = false;
        Boolean firstchangefax = false;
        CountryCode countrycodes = new CountryCode();
        City cityCodes = new City();

        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        ImageBrush brush = new ImageBrush();

        int index = 0;

        string imgFileName = "pic/no-image-icon-125x125.png";

        bool isImgPressed = false;

        private static UC_vendors _instance;
        public static UC_vendors Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_vendors();
                return _instance;
            }
        }
        public UC_vendors()
        {
            InitializeComponent();
            if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1440)
            {
                txt_deleteButton.Visibility = Visibility.Visible;
                txt_addButton.Visibility = Visibility.Visible;
                txt_updateButton.Visibility = Visibility.Visible;
                txt_add_Icon.Visibility = Visibility.Visible;
                txt_update_Icon.Visibility = Visibility.Visible;
                txt_delete_Icon.Visibility = Visibility.Visible;
            }
            else if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1360)
            {
                txt_add_Icon.Visibility = Visibility.Collapsed;
                txt_update_Icon.Visibility = Visibility.Collapsed;
                txt_delete_Icon.Visibility = Visibility.Collapsed;
                txt_deleteButton.Visibility = Visibility.Visible;
                txt_addButton.Visibility = Visibility.Visible;
                txt_updateButton.Visibility = Visibility.Visible;

            }
            else
            {
                txt_deleteButton.Visibility = Visibility.Collapsed;
                txt_addButton.Visibility = Visibility.Collapsed;
                txt_updateButton.Visibility = Visibility.Collapsed;
                txt_add_Icon.Visibility = Visibility.Visible;
                txt_update_Icon.Visibility = Visibility.Visible;
                txt_delete_Icon.Visibility = Visibility.Visible;

            }
        }
        //area code methods
        async Task<IEnumerable<CountryCode>> RefreshCountry()
        {
            countrynum = await countrycodes.GetAllCountries();
            return countrynum;
        }
        private async void fillCountries()
        {

            if (countrynum is null)
                await RefreshCountry();

            cb_areaPhone.ItemsSource = countrynum.ToList();
            cb_areaPhone.SelectedValuePath = "countryId";
            cb_areaPhone.DisplayMemberPath = "code";

            cb_areaMobile.ItemsSource = countrynum.ToList();
            cb_areaMobile.SelectedValuePath = "countryId";
            cb_areaMobile.DisplayMemberPath = "code";

            cb_areaFax.ItemsSource = countrynum.ToList();
            cb_areaFax.SelectedValuePath = "countryId";
            cb_areaFax.DisplayMemberPath = "code";

            cb_areaMobile.SelectedIndex = 8;
            cb_areaPhone.SelectedIndex = 8;
            cb_areaFax.SelectedIndex = 8;

        }

        async Task<IEnumerable<City>> RefreshCity()
        {
            citynum = await cityCodes.Get();
            return citynum;
        }
        private async void fillCity()
        {
            if (citynum is null)
                await RefreshCity();


        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void translate()
        {
            txt_vendor.Text = MainWindow.resourcemanager.GetString("trVendor");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
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
            txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            dg_vendor.Columns[0].Header = MainWindow.resourcemanager.GetString("trCode");
            dg_vendor.Columns[1].Header = MainWindow.resourcemanager.GetString("trName");
            dg_vendor.Columns[2].Header = MainWindow.resourcemanager.GetString("trCompany");
            dg_vendor.Columns[3].Header = MainWindow.resourcemanager.GetString("trMobile");

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
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            SectionData.genRandomCode("v");
            tb_code.Text = SectionData.code;

            agent.agentId = 0;
            tb_address.Clear();
            tb_fax.Clear();
            tb_company.Clear();
            tb_email.Clear();
            tb_name.Clear();
            tb_notes.Clear();
            tb_mobile.Clear();
            tb_phone.Clear();
            cb_areaMobile.SelectedIndex = 8;
            cb_areaPhone.SelectedIndex = 8;
            cb_areaFax.SelectedIndex = 8;
            //clear img
            Uri resourceUri = new Uri("pic/no-image-icon-125x125.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            img_vendor.Background = brush;

            p_errorName.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;
            p_errorMobile.Visibility = Visibility.Collapsed;

            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");

        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // for pagination onTop Always
            btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            //CreateGridCardContainer();
            catigoriesAndItemsView.ucVendors = this;
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucVendor.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucVendor.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

            var agents = await agentModel.GetAgentsAsync("v");
            dg_vendor.ItemsSource = agents;



            this.Dispatcher.Invoke(() =>
            {
                Tb_search_TextChanged(null, null);
            });

            fillCountries();

            fillCity();

            Keyboard.Focus(tb_name);

            SectionData.genRandomCode("v");
            tb_code.Text = SectionData.code;

            //default img
            Uri resourceUri = new Uri("pic/no-image-icon-125x125.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            img_vendor.Background = brush;

        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            agent.agentId = 0;
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty mobile
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
            //validate email
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);

            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) //phoneStr = cb_areaPhone.Text + cb_areaPhoneLocal.Text + tb_phone.Text;
                phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;
            string faxStr = "";
            if (!tb_fax.Text.Equals("")) //faxStr = cb_areaFax.Text + cb_areaFaxLocal.Text + tb_fax.Text;
                faxStr = cb_areaFax.Text + "-" + cb_areaFaxLocal.Text + "-" + tb_fax.Text;
            bool emailError = false;
            if (!tb_email.Text.Equals(""))
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                    emailError = true;

            decimal maxDeserveValue = 0;
            //if (!tb_upperLimit.Text.Equals(""))
            //    maxDeserveValue = decimal.Parse(tb_upperLimit.Text);

            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")))
            {
                if (emailError)
                    //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trErrorEmailToolTip"));
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorEmailToolTip"), animation: ToasterAnimation.FadeIn);
                else
                {
                    SectionData.genRandomCode("v");
                    tb_code.Text = SectionData.code;

                    agent.name = tb_name.Text;
                    agent.code = tb_code.Text;
                    agent.company = tb_company.Text;
                    agent.address = tb_address.Text;
                    agent.email = tb_email.Text;
                    agent.phone = phoneStr;
                    agent.mobile = cb_areaMobile.Text + "-" + tb_mobile.Text;
                    agent.image = "";
                    agent.type = "v";
                    agent.accType = "";
                    agent.balance = 0;
                    agent.createUserId = MainWindow.userID;
                    agent.updateUserId = MainWindow.userID;
                    agent.notes = tb_notes.Text;
                    agent.isActive = 1;
                    agent.fax = faxStr;
                    agent.maxDeserve = maxDeserveValue;

                    string s = await agentModel.saveAgent(agent);

                    if (!s.Equals("0"))   //{SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null);}  
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                        Btn_clear_Click(null, null);
                    }
                    else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    if (isImgPressed)
                    {
                        int agentId = int.Parse(s);
                        bool b = await agentModel.uploadImage(imgFileName, Md5Encription.MD5Hash("Inc-m" + agentId.ToString()), agentId);
                        isImgPressed = false;
                        if (b)
                        {
                            brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                            img_vendor.Background = brush;
                            //getImg();
                        }
                        else
                        {
                            MessageBox.Show("حدث خطأ في تحميل الصورة");
                        }
                    }
                    await RefreshVendorsList();
                    Tb_search_TextChanged(null, null);
                }
            }

        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty mobile
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
            //validate email
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);

            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

            string faxStr = "";
            if (!tb_fax.Text.Equals("")) faxStr = cb_areaFax.Text + "-" + cb_areaFaxLocal.Text + "-" + tb_fax.Text;

            bool emailError = false;
            if (!tb_email.Text.Equals(""))
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                    emailError = true;

            decimal maxDeserveValue = 0;
            //if (!tb_upperLimit.Text.Equals(""))
            //    maxDeserveValue = decimal.Parse(tb_upperLimit.Text);

            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")))
            {
                if (emailError)
                    //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trErrorEmailToolTip"));
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorEmailToolTip"), animation: ToasterAnimation.FadeIn);
                else
                {
                    agent.name = tb_name.Text;
                    agent.code = tb_code.Text;
                    agent.company = tb_company.Text;
                    agent.address = tb_address.Text;
                    agent.email = tb_email.Text;
                    agent.phone = phoneStr;
                    agent.mobile = cb_areaMobile.Text + "-" + tb_mobile.Text;
                    //agent.image = "";
                    agent.updateUserId = MainWindow.userID;
                    agent.notes = tb_notes.Text;
                    agent.fax = faxStr;
                    agent.maxDeserve = maxDeserveValue;

                    string s = await agentModel.saveAgent(agent);

                    if (!s.Equals("0")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                    else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    await RefreshVendorsList();
                    Tb_search_TextChanged(null, null);

                    if (isImgPressed)
                    {
                        int agentId = int.Parse(s);
                        bool b = await agentModel.uploadImage(imgFileName, Md5Encription.MD5Hash("Inc-m" + agentId.ToString()), agentId);
                        isImgPressed = false;
                        if (b)
                        {
                            brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                            img_vendor.Background = brush;
                            getImg();
                        }
                        else
                        {
                            SectionData.clearImg(img_vendor);
                            MessageBox.Show("حدث خطأ في تحميل الصورة");
                        }
                    }

                    SectionData.getMobile(agent.mobile, cb_areaMobile, tb_mobile);

                    SectionData.getPhone(agent.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                    SectionData.getPhone(agent.fax, cb_areaFax, cb_areaFaxLocal, tb_fax);

                    //dg_vendor.UnselectAll();
                    ////Btn_clear_Click(null, null);
                    //dg_vendor.SelectedIndex = index;
                }
            }

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if (agent.agentId != 0)
            {
                if ((!agent.canDelete) && (agent.isActive == 0))
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                        activate();
                }
                else
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    if (agent.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                    if (!agent.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                    {
                        string popupContent = "";
                        if (agent.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                        if ((!agent.canDelete) && (agent.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                        bool b = await agentModel.deleteAgent(agent.agentId, agent.canDelete);

                        if (b) //SectionData.popUpResponse("", popupContent);
                            Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                        else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }

                await RefreshVendorsList();
                Tb_search_TextChanged(null, null);
            }
            //clear textBoxs
            Btn_clear_Click(sender, e);
        }

        private async void activate()
        {//activate
            agent.isActive = 1;

            string s = await agentModel.saveAgent(agent);

            if (s.Equals("true")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshVendorsList();
            Tb_search_TextChanged(null, null);


        }

        private void tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }
        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
        }



        private void tb_mobile_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
        }

        private void tb_mobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
        }

        private void tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }

        async Task<IEnumerable<Agent>> RefreshVendorsList()
        {
            agents = await agentModel.GetAgentsAsync("v");
            return agents;
        }
        void RefreshVendorView()
        {
            dg_vendor.ItemsSource = agentsQuery;
            txt_count.Text = agentsQuery.Count().ToString();

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

        private void btn_vendorExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });
        }

        void FN_ExportToExcel()
        {
            var QueryExcel = agentsQuery.AsEnumerable().Select(x => new
            {
                Code = x.code,
                Name = x.name,
                Company = x.company,
                Mobile = x.mobile,
                Phone = x.phone,
                Fax = x.fax,
                Email = x.email,
                Address = x.address,
                Notes = x.notes,

            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trCode");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trCompany");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trMobile");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trPhone");
            DTForExcel.Columns[5].Caption = MainWindow.resourcemanager.GetString("trFax");
            DTForExcel.Columns[6].Caption = MainWindow.resourcemanager.GetString("trEmail");
            DTForExcel.Columns[7].Caption = MainWindow.resourcemanager.GetString("trAddress");
            DTForExcel.Columns[8].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);

        }

        private async void tgl_vendorIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (agents is null)
                await RefreshVendorsList();
            tgl_vendorState = 1;
            Tb_search_TextChanged(null, null);
        }

        private async void tgl_vendorIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (agents is null)
                await RefreshVendorsList();
            tgl_vendorState = 0;
            Tb_search_TextChanged(null, null);
        }


        private void tb_search_GotFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            p_errorName.Visibility = Visibility.Collapsed;
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            //var bc = new BrushConverter();

            //p_errorName.Visibility = Visibility.Collapsed;
            //tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }

        private void tb_email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Cb_areaPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (firstchange == true)
            {
                if (cb_areaPhone.SelectedValue != null)
                {
                    if (cb_areaPhone.SelectedIndex >= 0)
                        countryid = int.Parse(cb_areaPhone.SelectedValue.ToString());

                    citynumofcountry = citynum.Where(b => b.countryId == countryid).OrderBy(b => b.cityCode).ToList();

                    cb_areaPhoneLocal.ItemsSource = citynumofcountry;
                    cb_areaPhoneLocal.SelectedValuePath = "cityId";
                    cb_areaPhoneLocal.DisplayMemberPath = "cityCode";
                    if (citynumofcountry.Count() > 0)
                    {

                        cb_areaPhoneLocal.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        cb_areaPhoneLocal.Visibility = Visibility.Collapsed;
                    }

                }
            }
            else
            {
                firstchange = true;
            }
        }

        private void Cb_areaFax_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firstchangefax == true)
            {
                if (cb_areaFax.SelectedValue != null)
                {
                    if (cb_areaFax.SelectedIndex >= 0)
                        countryid = int.Parse(cb_areaFax.SelectedValue.ToString());

                    citynumofcountry = citynum.Where(b => b.countryId == countryid).OrderBy(b => b.cityCode).ToList();

                    cb_areaFaxLocal.ItemsSource = citynumofcountry;
                    cb_areaFaxLocal.SelectedValuePath = "cityId";
                    cb_areaFaxLocal.DisplayMemberPath = "cityCode";
                    if (citynumofcountry.Count() > 0)
                    {

                        cb_areaFaxLocal.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        cb_areaFaxLocal.Visibility = Visibility.Collapsed;
                    }

                }
            }
            else
            {
                firstchangefax = true;
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

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshVendorsList();
            Tb_search_TextChanged(null, null);


        }

        private async void getImg()
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
                    using (var memoryStream = new MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    img_vendor.Background = new ImageBrush(bitmapImage);
                }
            }
            catch { }
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            string addpath = @"\Reports\VendorReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
            // MessageBox.Show(path+"=="+pos1.ToString()+"after="+ repPath);


            //  List<Agent> agentlist = new List<Agent>();

            //  rep.SetParameters(new ReportParameter("agentTitle", "Vendors"));
            // D:\gitpos\POS\POS\bin\debug"
            // rep.ReportPath = @"D:\gitpos\POS\POS\Reports\VendorReport.rdlc";
            /*
             string path = Directory.GetCurrentDirectory();

            int pos1 = path.LastIndexOf("\\");
            string path2 = path.Substring(0, pos1);
            pos1 = path2.LastIndexOf("\\");

            path2 = path2.Substring(0, pos1);
            string repPath = path2 + @"\Reports\VendorReport.rdlc";
            // MessageBox.Show(path+"=="+pos1.ToString()+"after="+ repPath);

             * */
            rep.ReportPath = reppath;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("AgentDataSet", agentsQuery));
            ReportParameter[] paramarr = new ReportParameter[6];
            paramarr[0] = new ReportParameter("agentTitle", MainWindow.resourcemanager.GetString("trSuppliers"));
            paramarr[1] = new ReportParameter("trCode", MainWindow.resourcemanager.GetString("trCode"));
            paramarr[2] = new ReportParameter("trName", MainWindow.resourcemanager.GetString("trName"));
            paramarr[3] = new ReportParameter("trCompany", MainWindow.resourcemanager.GetString("trCompany"));
            paramarr[4] = new ReportParameter("trMobile", MainWindow.resourcemanager.GetString("trMobile"));
            paramarr[5] = new ReportParameter("lang", MainWindow.lang);
            rep.SetParameters(paramarr);
            rep.Refresh();
            LocalReportExtensions.PrintToPrinter(rep);

        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            ReportParameter[] paramarr = new ReportParameter[6];

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\SectionData\Ar\ArVendorReport.rdlc";
            }
            else addpath = @"\Reports\SectionData\En\VendorReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
            ReportCls.checkLang();

            rptSectionData.vendorReport(agentsQuery, rep, reppath);
            rptSectionData.setReportLanguage(paramarr);
            rptSectionData.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();

            saveFileDialog.Filter = "PDF|*.pdf;";
            //saveFileDialog.Filter = "WORD|*.doc;";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filepath = saveFileDialog.FileName;
                LocalReportExtensions.ExportToPDF(rep, filepath);
            }


        }

        private void Tb_email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
        }
        #region Categor and Item
        #region Refrish Y
        void RefrishItemsCard(IEnumerable<Agent> _agent)
        {
            grid_containerCard.Children.Clear();
            catigoriesAndItemsView.gridCatigorieItems = grid_containerCard;
            catigoriesAndItemsView.FN_refrishAgents(_agent.ToList(), "en", "Agent");
        }
        #endregion
        #region Get Id By Click  Y
        private async void DG_supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;
            p_errorMobile.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_fax.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_vendor.SelectedIndex != -1)
            {
                agent = dg_vendor.SelectedItem as Agent;
                this.DataContext = agent;
            }
            if (agent != null)
            {
                tb_code.Text = agent.code;

                SectionData.getMobile(agent.mobile, cb_areaMobile, tb_mobile);

                SectionData.getPhone(agent.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);

                SectionData.getPhone(agent.fax, cb_areaFax, cb_areaFaxLocal, tb_fax);

                #region delete
                if (agent.canDelete)
                {
                    txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                    txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                }

                else
                {
                    if (agent.isActive == 0)
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trActive");
                        txt_delete_Icon.Kind =
                         MaterialDesignThemes.Wpf.PackIconKind.Check;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trActive");

                    }
                    else
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trInActive");
                        txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Cancel;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trInActive");

                    }

                }
                #endregion

                getImg();


                index = dg_vendor.SelectedIndex;
            }

        }

        public void ChangeItemIdEvent(int userId)
        {

            #region
            //selection
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;
            p_errorMobile.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_fax.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            agent = agents.ToList().Find(c => c.agentId == userId);
            this.DataContext = agent;
            if (agent != null)
            {
                tb_code.Text = agent.code;
                SectionData.getMobile(agent.mobile, cb_areaMobile, tb_mobile);
                SectionData.getPhone(agent.phone, cb_areaPhone, cb_areaPhoneLocal, tb_phone);
                SectionData.getPhone(agent.fax, cb_areaFax, cb_areaFaxLocal, tb_fax);
                #region delete
                if (agent.canDelete)
                {
                    txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                    txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");
                }
                else
                {
                    if (agent.isActive == 0)
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trActive");
                        txt_delete_Icon.Kind =
                         MaterialDesignThemes.Wpf.PackIconKind.Check;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trActive");
                    }
                    else
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trInActive");
                        txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Cancel;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trInActive");
                    }
                }
                #endregion
                getImg();
            }
            #endregion
        }
        #endregion
        #region Switch Card/DataGrid Y
        private void Btn_itemsInCards_Click(object sender, RoutedEventArgs e)
        {
            grid_datagrid.Visibility = Visibility.Collapsed;
            grid_cards.Visibility = Visibility.Visible;
            path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_itemsInGrid.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

            Tb_search_TextChanged(null, null);
        }

        private void Btn_itemsInGrid_Click(object sender, RoutedEventArgs e)
        {
            grid_cards.Visibility = Visibility.Collapsed;
            grid_datagrid.Visibility = Visibility.Visible;
            path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            path_itemsInCards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));

            Tb_search_TextChanged(null, null);
        }
        #endregion
        #region Search Y


        /// <summary>
        /// Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();
            p_errorName.Visibility = Visibility.Collapsed;
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            if (agents is null)
                await RefreshVendorsList();
            pageIndex = 1;
            searchText = tb_search.Text;
            #region
            agentsQuery = agents.Where(s => (s.code.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.company.Contains(searchText) ||
            s.mobile.Contains(searchText)
            ) && s.isActive == tgl_vendorState);
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(agentsQuery, pageIndex, btns));
            #endregion
            RefreshVendorView();
        }




        #endregion
        #region Pagination Y
        Pagination pagination = new Pagination();
        Button[] btns;
        public int pageIndex = 1;

        private void Tb_pageNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            agentsQuery = agents.Where(x => x.isActive == tgl_vendorState);

            if (tb_pageNumberSearch.Text.Equals(""))
            {
                pageIndex = 1;
            }
            else if (((agentsQuery.Count() - 1) / 12) + 1 < int.Parse(tb_pageNumberSearch.Text))
            {
                pageIndex = ((agentsQuery.Count() - 1) / 12) + 1;
            }
            else
            {
                pageIndex = int.Parse(tb_pageNumberSearch.Text);
            }

            #region
            agentsQuery = agents.Where(s => (s.code.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.company.Contains(searchText) ||
            s.mobile.Contains(searchText)
            ) && s.isActive == tgl_vendorState);
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(agentsQuery, pageIndex, btns));
            #endregion

        }


        private void Btn_firstPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            #region
            agentsQuery = agents.Where(s => (s.code.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.company.Contains(searchText) ||
            s.mobile.Contains(searchText)
            ) && s.isActive == tgl_vendorState);
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(agentsQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_prevPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_prevPage.Content.ToString());
            #region
            agentsQuery = agents.Where(s => (s.code.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.company.Contains(searchText) ||
            s.mobile.Contains(searchText)
            ) && s.isActive == tgl_vendorState);
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(agentsQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_activePage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_activePage.Content.ToString());
            #region
            agentsQuery = agents.Where(s => (s.code.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.company.Contains(searchText) ||
            s.mobile.Contains(searchText)
            ) && s.isActive == tgl_vendorState);
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(agentsQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_nextPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = int.Parse(btn_nextPage.Content.ToString());
            #region
            agentsQuery = agents.Where(s => (s.code.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.company.Contains(searchText) ||
            s.mobile.Contains(searchText)
            ) && s.isActive == tgl_vendorState);
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(agentsQuery, pageIndex, btns));
            #endregion
        }
        private void Btn_lastPage_Click(object sender, RoutedEventArgs e)
        {
            agentsQuery = agents.Where(x => x.isActive == tgl_vendorState);
            pageIndex = ((agentsQuery.Count() - 1) / 12) + 1;
            #region
            agentsQuery = agents.Where(s => (s.code.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.company.Contains(searchText) ||
            s.mobile.Contains(searchText)
            ) && s.isActive == tgl_vendorState);
            if (btns is null)
                btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            RefrishItemsCard(pagination.refrishPagination(agentsQuery, pageIndex, btns));
            #endregion
        }
        #endregion

        #endregion

        private void Grid_containerCard_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (e.PreviousSize.Height != 0)
            //{
            //    if (!(e.PreviousSize.Width -25 < e.NewSize.Width &&
            //      e.NewSize.Width < e.PreviousSize.Width + 25))
            //    {
            RefrishItemsCard(pagination.refrishPagination(agentsQuery, pageIndex, btns));
            //    }
            //}
        }

        private void btn_pieChart_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            win_lvc win = new win_lvc(agentsQuery, 1, false);
            win.ShowDialog();
            Window.GetWindow(this).Opacity = 1;
        }
    }
}

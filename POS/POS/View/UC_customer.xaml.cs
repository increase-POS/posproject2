using POS.Classes;
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
using System.Net.Mail;
using Tulpep.NotificationWindow;
using System.Threading;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_Customer.xaml
    /// </summary>
    public partial class UC_Customer : UserControl
    {
        
        IEnumerable<Agent> agentsQuery;
        IEnumerable<Agent> agents;
        byte tgl_customerState;
        string searchText = "";


        Agent agentModel = new Agent();
        
        Agent agent = new Agent();
        //phone variabels
       IEnumerable<CountryCode> countrynum;
        IEnumerable<City> citynum;
        IEnumerable<City> citynumofcountry;

        int? countryid;
        Boolean firstchange = false;
        Boolean firstchangefax = false;
        CountryCode countrycodes = new CountryCode();
        City cityCodes = new City();
        public UC_Customer()
        {
            InitializeComponent();

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
        //end areacod
        private void translate()
        {
            txt_customer.Text = MainWindow.resourcemanager.GetString("trCustomer");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
          //  MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trPamentMethodHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trCodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_company, MainWindow.resourcemanager.GetString("trCompanyHint"));
            txt_contactInformation.Text = MainWindow.resourcemanager.GetString("trContactInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            txt_moreInformation.Text = MainWindow.resourcemanager.GetString("trMoreInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_upperLimit, MainWindow.resourcemanager.GetString("trUpperLimitHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_fax, MainWindow.resourcemanager.GetString("trFaxHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

            dg_customer.Columns[0].Header = MainWindow.resourcemanager.GetString("trCode");
            dg_customer.Columns[1].Header = MainWindow.resourcemanager.GetString("trName");
            dg_customer.Columns[2].Header = MainWindow.resourcemanager.GetString("trCompany");
            dg_customer.Columns[3].Header = MainWindow.resourcemanager.GetString("trMobile");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            tt_code.Content = MainWindow.resourcemanager.GetString("trCode");
            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_company.Content = MainWindow.resourcemanager.GetString("trCompany");
            tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
            tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
            tt_fax.Content = MainWindow.resourcemanager.GetString("trFax");
            tt_email.Content = MainWindow.resourcemanager.GetString("trEmail");
            tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
            tt_upperLimit.Content = MainWindow.resourcemanager.GetString("trUpperLimit");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");


        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear

            SectionData.genRandomCode("c");
            tb_code.Text = SectionData.code;

            agent.agentId = 0;
            tb_address.Clear();
            tb_fax.Clear();
            tb_company.Clear();
            tb_email.Clear();
            tb_name.Clear();
            tb_notes.Clear();
            tb_mobile.Clear();
            tb_upperLimit.Clear();
            tb_phone.Clear();
            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaFax.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            cb_areaFaxLocal.SelectedIndex = 0;

            p_errorName.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;
            p_errorMobile.Visibility = Visibility.Collapsed;

            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_fax.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //only int
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            //decimal
            //var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            //if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
            //    e.Handled = false;

            //else
            //    e.Handled = true;
        }

        private void DG_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;
            p_errorMobile.Visibility = Visibility.Collapsed;

            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_fax.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_customer.SelectedIndex != -1)
            {
                agent = dg_customer.SelectedItem as Agent;
                this.DataContext = agent;
            }
            if (agent != null)
            {

                //if (agent.agentId != 0)
                //{
                //    AgentId = agent.agentId;
                //    CanDelete = agent.canDelete;
                //    tb_code.Text = agent.code;
                //    // CreateDate = agent.createDate.Value;
                //    // CreateUser = agent.createUserId.Value;
                //}

                //mobile
                if ((agent.mobile != null) )
                {
                    string area = agent.mobile;
                    string[] pharr = area.Split('-');
                    int j = 0;
                    string phone = "";
                    
                    foreach (string strpart in pharr)
                    {
                        if (j == 0)
                        {
                            area = strpart;
                        }                    
                        else
                        {
                            phone = phone + strpart;    
                        }
                        j++;
                    }
                  

                    cb_areaMobile.Text = area;
                    
                    tb_mobile.Text = phone.ToString();
                }
                else
                {
                    cb_areaMobile.SelectedIndex = -1;
                    tb_mobile.Clear();
                }
                //phone
                if ((agent.phone != null))
                {
                    string area = agent.phone;
                    string[] pharr = area.Split('-');
                    int j = 0;
                    string phone = "";
                    string areaLocal = "";
                    foreach (string strpart in pharr)
                    {
                        if (j == 0)
                        {
                            area = strpart;
                            //  MessageBox.Show(area);
                        }
                        else if (j == 1)
                        {
                            areaLocal = strpart;

                            //   MessageBox.Show(areaLocal);
                        }
                        else
                        {
                            phone = phone + strpart;
                            //   MessageBox.Show(phone);
                        }
                        j++;
                    }
                    /*
                    int i = area.IndexOf("-");
                    if (i >= 0)
                    {
                        area = area.Substring(0, i);
                    MessageBox.Show(area);
                    }
                    */


                    //  var phone = agent.phone.Substring(7, agent.phone.Length - 7);

                    cb_areaPhone.Text = area;
                    cb_areaPhoneLocal.Text = areaLocal;
                    tb_phone.Text = phone.ToString();
                }
                else
                {
                    cb_areaPhone.SelectedIndex = -1;
                    cb_areaPhoneLocal.SelectedIndex = -1;
                    tb_phone.Clear();
                }
                //fax
                if ((agent.fax != null))
                {
                    string area = agent.fax;
                    string[] pharr = area.Split('-');
                    int j = 0;
                    string fax = "";
                    string areaLocal = "";
                    foreach (string strpart in pharr)
                    {
                        if (j == 0)
                        {
                            area = strpart;
                            //  MessageBox.Show(area);
                        }
                        else if (j == 1)
                        {
                            areaLocal = strpart;

                            //   MessageBox.Show(areaLocal);
                        }
                        else
                        {
                            fax = fax + strpart;
                            //   MessageBox.Show(fax);
                        }
                        j++;
                    }
                    
                    cb_areaFax.Text = area;
                    cb_areaFaxLocal.Text = areaLocal;
                    tb_fax.Text = fax.ToString();
                }
                else
                {
                    cb_areaFax.SelectedIndex = -1;
                    cb_areaFaxLocal.SelectedIndex = -1;
                    tb_fax.Clear();
                }
                //end fax
                if (agent.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else
                {
                    if (agent.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                    else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
                }
            }
        }

        private async void  Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            agent.agentId = 0;
            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
            }
            if (tb_mobile.Text.Equals(""))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyMobileToolTip");
            }
            else
            {
                p_errorMobile.Visibility = Visibility.Collapsed;

            }
            if (!tb_email.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                {
                    p_errorEmail.Visibility = Visibility.Visible;
                    tt_errorEmail.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                }
                else
                {
                    p_errorEmail.Visibility = Visibility.Collapsed;
                }
            }
            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;
            
            string faxStr = "";
            if (!tb_fax.Text.Equals("")) faxStr = cb_areaFax.Text + "-" + cb_areaFaxLocal.Text + "-" + tb_fax.Text;
            
            bool emailError = false;
            if (!tb_email.Text.Equals(""))
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                    emailError = true;

            decimal maxDeserveValue = 0;
            if (!tb_upperLimit.Text.Equals(""))
                maxDeserveValue = decimal.Parse(tb_upperLimit.Text);

            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")) )
            {
                if (emailError)
                    SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trErrorEmailToolTip"));
                else
                {
                    SectionData.genRandomCode("c");
                    tb_code.Text = SectionData.code;

                    //Agent customer = new Agent
                    //{
                    agent.name = tb_name.Text;
                    agent.code = tb_code.Text;
                    agent.company = tb_company.Text;
                    agent.address = tb_address.Text;
                    agent.email = tb_email.Text;
                    agent.phone = phoneStr;
                    agent.mobile = cb_areaMobile.Text +"-"+ tb_mobile.Text;
                    agent.image = "";
                    agent.type = "c";
                    agent.accType = "";
                    agent.balance = 0;
                    //createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    //updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    agent.createUserId = MainWindow.userID;
                    agent.updateUserId = MainWindow.userID;
                    agent.notes = tb_notes.Text;
                    agent.isActive = 1;
                    agent.fax = faxStr;
                    agent.maxDeserve = maxDeserveValue;

                    //};

                    string s = await agentModel.saveAgent(agent);

                    if (s.Equals("true")) { SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null); }
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                }
            }
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAddValidate"));

            agents = await agentModel.GetAgentsAsync("c");
            agentsQuery = agents.Where(s => s.isActive == Convert.ToInt32(tgl_customerIsActive.IsChecked));
            dg_customer.ItemsSource = agentsQuery;

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            if(MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucCustomer.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucCustomer.FlowDirection = FlowDirection.RightToLeft;
            }
            
            translate();

            //pass parameter type (V for vendors, C for Clients , B for Both)
            //var agents = await agentModel.GetAgentsAsync("c");
            //agentsQuery = agents;
            //dg_customer.ItemsSource = agentsQuery;
            //txt_Count.Text = agentsQuery.Count().ToString();
            //dg_customer.ItemsSource = agents;
            //Dispatcher.BeginInvoke(new Action(() => { GetGridData(null, 0)}));
            //tb_search_TextChanged(null, null);

            this.Dispatcher.Invoke(() =>
            {
                tb_search_TextChanged(null, null);
            });

            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            cb_areaFax.SelectedIndex = 0;
            cb_areaFaxLocal.SelectedIndex = 0;
            fillCountries();
        
            fillCity();
       
            Keyboard.Focus(tb_name);

            SectionData.genRandomCode("c");
            tb_code.Text = SectionData.code;

        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
            }
            if (tb_mobile.Text.Equals(""))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyMobileToolTip");
            }
            else
            {
                p_errorMobile.Visibility = Visibility.Collapsed;

            }
            if (!tb_email.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                {
                    p_errorEmail.Visibility = Visibility.Visible;
                    tt_errorEmail.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                }
                else
                {
                    p_errorEmail.Visibility = Visibility.Collapsed;
                }
            }
            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

            string faxStr = "";
            if (!tb_fax.Text.Equals("")) faxStr = cb_areaFax.Text + "-" + cb_areaFaxLocal.Text + "-" + tb_fax.Text;

            bool emailError = false;
            if (!tb_email.Text.Equals(""))
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                    emailError = true;

            decimal maxDeserveValue = 0;
            if (!tb_upperLimit.Text.Equals(""))
                maxDeserveValue = decimal.Parse(tb_upperLimit.Text);

            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")))
            {
                if (emailError)
                    SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trErrorEmailToolTip"));
                else
                {
                    //Agent customer = new Agent
                    //{
                    //agentId = AgentId,
                    agent.name = tb_name.Text;
                    agent.code = tb_code.Text;
                    agent.company = tb_company.Text;
                    agent.address = tb_address.Text;
                    agent.email = tb_email.Text;
                    agent.phone = phoneStr;
                    agent.mobile = cb_areaMobile.Text + "-" + tb_mobile.Text;
                    agent.image = "";
                    //agent.type = "c";
                    //agent.accType = "";
                    //agent.balance = 0;
                    //createDate = CreateDate,
                    //updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    //createUserId = CreateUser,
                    agent.updateUserId = MainWindow.userID;
                    agent.notes = tb_notes.Text;
                    //isActive = IsActive,
                    agent.fax = faxStr;
                    agent.maxDeserve = maxDeserveValue;

                    //};

                    string s = await agentModel.saveAgent(agent);

                    if (s.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                    tb_search_TextChanged(null, null);
                }
            }
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdateValidate"));

            agents = await agentModel.GetAgentsAsync("c");
            agentsQuery = agents.Where(s => s.isActive == Convert.ToInt32(tgl_customerIsActive.IsChecked));
            dg_customer.ItemsSource = agentsQuery;
        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            MessageBox.Show(agent.canDelete.ToString() + " " + agent.isActive.ToString());
            if ((!agent.canDelete) && (agent.isActive == 0))
                activate();
            else
            {
                string popupContent = "";
                if (agent.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                if ((!agent.canDelete) && (agent.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                bool b = await agentModel.deleteAgent(agent.agentId , agent.canDelete);

                if (b) SectionData.popUpResponse("", popupContent);
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            }


            //pass parameter type(V for vendors, C for Clients, B for Both)
            //var agents = await agentModel.GetAgentsAsync("c");
            //dg_customer.ItemsSource = agents;
            agents = await agentModel.GetAgentsAsync("c");
            agentsQuery = agents;
            dg_customer.ItemsSource = agentsQuery;
            txt_Count.Text = agentsQuery.Count().ToString();
            tb_search_TextChanged(null, null);

            //clear textBoxs
            Btn_clear_Click(sender , e);
           
        }

        private async void activate()
        {//activate

            agent.isActive = 1;

            string s = await agentModel.saveAgent(agent);

            if (s.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

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

        private void tb_name_TextChanged(object sender, TextChangedEventArgs e)
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

        private void Tb_mobile_LostFocus(object sender, RoutedEventArgs e)
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
                tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
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

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });


            //}
            //catch (Exception ex)
            //{
            //AllClasses.Exception1(ex);
            //}
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
                MaxDeserve = x.maxDeserve,
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
            DTForExcel.Columns[8].Caption = MainWindow.resourcemanager.GetString("trUpperLimit");
            DTForExcel.Columns[9].Caption = MainWindow.resourcemanager.GetString("trNote");


            ExportToExcel.Export(DTForExcel);

        }

        private async void Tgl_customerIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (agents is null)
                await RefreshCustomersList();
            tgl_customerState = 1;
            tb_search_TextChanged(null, null);
            
        }

        private async void Tgl_customerIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (agents is null)
                await RefreshCustomersList();
            tgl_customerState = 0;
            tb_search_TextChanged(null, null);
        }
        async Task<IEnumerable<Agent>> RefreshCustomersList()
        {
            agents = await agentModel.GetAgentsAsync("c");
            return agents;
        }
        void RefreshCustomerView()
        {
            dg_customer.ItemsSource = agentsQuery;
            txt_Count.Text = agentsQuery.Count().ToString();
            cb_areaMobile.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            cb_areaFax.SelectedIndex = 0;
            cb_areaFaxLocal.SelectedIndex = 0;
        }
        
        private async void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (agents is null)
                await RefreshCustomersList();
            searchText = tb_search.Text;
            agentsQuery = agents.Where(s => (s.code.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.company.Contains(searchText) ||
            s.mobile.Contains(searchText)
            ) && s.isActive == tgl_customerState);
            RefreshCustomerView();

           
        }

        private void tb_mobile_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //doesn't allow spaces into textbox
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

        private void tb_upperLimit_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_search_GotFocus(object sender, RoutedEventArgs e)
        {
           
            var bc = new BrushConverter();

            p_errorName.Visibility = Visibility.Collapsed;
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
        //    var bc = new BrushConverter();

        //    p_errorName.Visibility = Visibility.Collapsed;
        //    tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }

        private void tb_email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Cb_areaPhone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show(cb_areaPhone.SelectedValue.ToString());
            if (firstchange == true)
            {
                if (cb_areaPhone.SelectedValue != null)
                {
                    if (cb_areaPhone.SelectedIndex >= 0)
                        countryid = int.Parse(cb_areaPhone.SelectedValue.ToString());
                    // MessageBox.Show(cb_areaPhone.SelectedIndex.ToString());
                    // MessageBox.Show(countryid.ToString());
                    citynumofcountry = citynum.Where(b => b.countryId == countryid).OrderBy(b => b.cityCode).ToList();
                    //MessageBox.Show(citynumofcountry.Count().ToString());
                    cb_areaPhoneLocal.ItemsSource = citynumofcountry;
                    cb_areaPhoneLocal.SelectedValuePath = "cityId";
                    cb_areaPhoneLocal.DisplayMemberPath = "cityCode";
                    if (citynumofcountry.Count() > 0)
                    {

                        cb_areaPhoneLocal.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        cb_areaPhoneLocal.Visibility = Visibility.Hidden;
                    }

                }
            }
            else
            {
                firstchange = true;
            }

            /*
           if (cb_areaPhone.SelectedValue > 0)
            {
                int countryid = (int)cb_areaPhone.SelectedValue;

        //    this.UserControl_Loaded.
                cb_areaPhoneLocal.ItemsSource = citylist.Where(b => b.countryId == countryid).ToList();
            cb_areaPhoneLocal.SelectedValuePath = "cityId";
            cb_areaPhoneLocal.DisplayMemberPath = "cityCode";
            }
            */
            // int countid = (int)cb_areaPhone.SelectedValue;

        }

        private void Cb_areaFax_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show(cb_areaPhone.SelectedValue.ToString());
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
                        cb_areaFaxLocal.Visibility = Visibility.Hidden;
                    }

                }
            }
            else
            {
                firstchangefax = true;
            }

         

        }
    }
}
    
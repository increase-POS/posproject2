using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
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

namespace POS.View.Settings
{
    /// <summary>
    /// Interaction logic for uc_general.xaml
    /// </summary>
    public partial class uc_general : UserControl
    {
        static SettingCls setModel = new SettingCls();
        static SetValues valueModel = new SetValues();
        static UserSetValues usValueModel = new UserSetValues();
        static CountryCode countryModel = new CountryCode();

        static SettingCls set = new SettingCls();
        static SetValues language= new SetValues();
        static SetValues tax = new SetValues();
        static SetValues cost = new SetValues();
        static public UserSetValues usLanguage = new UserSetValues();
        static UserSetValues usValue = new UserSetValues();
        static CountryCode region = new CountryCode();
        static List<SetValues> languages = new List<SetValues>();

        static int taxId = 0 , costId = 0;

        private static uc_general _instance;
        public static uc_general Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_general();
                return _instance;
            }
        }
        public uc_general()
        {
            InitializeComponent();
        }

        private void Btn_companyInfo_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_companyInfo w = new wd_companyInfo();
            w.ShowDialog();
            Window.GetWindow(this).Opacity = 1;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            #region translate
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_general.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_general.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            #endregion

            fillRegions();

            #region get default region
            await getDefaultRegion();
            if (region != null)
            {
                //MessageBox.Show(region.countryId.ToString());
                //int index = cb_region.Items.IndexOf(region.name.Trim());
                cb_region.SelectedValue = region.countryId;
                cb_region.Text = region.name;
            }
            #endregion

            fillLanguages();

            #region get default language
            await getDefaultLanguage();
            if(usLanguage != null)
                cb_language.SelectedValue = usLanguage.valId;
            #endregion

            fillCurrencies();

            #region get default currency
            if (region != null)
            {
                //cb_currency.SelectedValue = region.name;
                //int index = cb_currency.Items.IndexOf(region.currency.Trim());
                //cb_currency.SelectedIndex = 0;
                //MessageBox.Show(region.currency);
                //cb_currency.Text = region.currency;
                tb_currency.Text = region.currency;
            }
            #endregion

            #region get default tax
            await getDefaultTax();
            if(tax != null)
            tb_tax.Text = tax.value;
            #endregion

            #region get default cost
            await getDefaultCost();
            if (cost != null)
                tb_storageCost.Text = cost.value;
            #endregion

        }

        public static async Task<SetValues> getDefaultCost()
        {
            List<SettingCls> settingsCls = await setModel.GetAll();
            List<SetValues> settingsValues = await valueModel.GetAll();
            set = settingsCls.Where(s => s.name == "storage_cost").FirstOrDefault<SettingCls>();
            costId = set.settingId;
            cost = settingsValues.Where(i => i.settingId == costId).FirstOrDefault();
            return cost;
        }

        public static async Task<CountryCode> getDefaultRegion()
        {
            List<CountryCode> regions = new List<CountryCode>();
            regions = await countryModel.GetAllRegion();
            region = regions.Where(r => r.isDefault == 1).FirstOrDefault<CountryCode>();
            return region;
        }
        public static async Task<SetValues> getDefaultTax()
        {
            List<SettingCls> settingsCls = await setModel.GetAll();
            List<SetValues> settingsValues = await valueModel.GetAll();
            set = settingsCls.Where(s => s.name == "tax").FirstOrDefault<SettingCls>();
            taxId = set.settingId;
            tax = settingsValues.Where(i => i.settingId == taxId).FirstOrDefault();
            return tax;
        }
        public static async Task<UserSetValues> getDefaultLanguage()
        {
            var lanSettings = await setModel.GetAll();
            set = lanSettings.Where(l => l.name == "language").FirstOrDefault<SettingCls>();
            var lanValues = await valueModel.GetAll();
            languages = lanValues.Where(vl => vl.settingId == set.settingId).ToList<SetValues>();
            List<UserSetValues> usValues = new List<UserSetValues>();
            usValues = await usValueModel.GetAll();
            var curUserValues = usValues.Where(c => c.userId == MainWindow.userID);
            foreach (var l in curUserValues)
                if (languages.Any(c => c.valId == l.valId))
                {
                    usLanguage = l;
                }
            return usLanguage;
        }

        int usValueId = 0;
        private async void fillCurrencies()
        {
            cb_currency.ItemsSource = await countryModel.GetAllRegion();
            cb_currency.DisplayMemberPath = "currency";
            cb_currency.SelectedValuePath = "countryId";
        }

        private async void fillLanguages()
        {
            var lanSettings = await setModel.GetAll();
            set = lanSettings.Where(l => l.name == "language").FirstOrDefault<SettingCls>();
            var lanValues = await valueModel.GetAll();
            languages = lanValues.Where(vl => vl.settingId == set.settingId).ToList<SetValues>();
            foreach (var v in languages)
            {
                if (v.value.ToString().Equals("en"))      v.value = MainWindow.resourcemanager.GetString("trEnglish"); 
                else if (v.value.ToString().Equals("ar")) v.value = MainWindow.resourcemanager.GetString("trArabic");
            }
           
            cb_language.ItemsSource = languages;
            cb_language.DisplayMemberPath = "value";
            cb_language.SelectedValuePath = "valId";

        }

        private async void fillRegions()
        {
            cb_region.ItemsSource = await countryModel.GetAllRegion();
            cb_region.DisplayMemberPath = "name";
            cb_region.SelectedValuePath = "countryId";
        }

        private void translate()
        {
            txt_comInfo.Text = MainWindow.resourcemanager.GetString("trComInfo");
            txt_comHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_region.Text = MainWindow.resourcemanager.GetString("trRegion");
            txt_language.Text = MainWindow.resourcemanager.GetString("trLanguage");
            txt_currency.Text = MainWindow.resourcemanager.GetString("trCurrency");
            txt_tax.Text = MainWindow.resourcemanager.GetString("trTax");
            txt_notification.Text = MainWindow.resourcemanager.GetString("trNotification");
            txt_storageCost.Text = MainWindow.resourcemanager.GetString("trStorageCost");
            txt_notifhint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txtOffers.Text = MainWindow.resourcemanager.GetString("trOffer");
            txt_offerHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_coupon.Text = MainWindow.resourcemanager.GetString("trCoupon");
            txt_couponHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_adminChangePassword.Text = MainWindow.resourcemanager.GetString("trChangePassword");
            txt_adminChangePasswordHint.Text = MainWindow.resourcemanager.GetString("trChangePasswordHint");
            txt_sms.Text = MainWindow.resourcemanager.GetString("trSms");
            txt_smsHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_emails.Text = MainWindow.resourcemanager.GetString("trEmails");
            txt_emailHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_backUp.Text = MainWindow.resourcemanager.GetString("trBackUp/Restore");
            txt_backUpHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_dashBoard.Text = MainWindow.resourcemanager.GetString("trDashBoard");
            txt_dashHint.Text = MainWindow.resourcemanager.GetString("trDashHint");

            tt_region.Content = MainWindow.resourcemanager.GetString("trRegion");
            tt_language.Content = MainWindow.resourcemanager.GetString("trLanguage");
            tt_currency.Content = MainWindow.resourcemanager.GetString("trCurrency");
            tt_tax.Content = MainWindow.resourcemanager.GetString("trTax");
            tt_storageCost.Content = MainWindow.resourcemanager.GetString("trStorageCost");
        }

        private async void Btn_saveRegion_Click(object sender, RoutedEventArgs e)
        {//save region
            string s = "";
            SectionData.validateEmptyComboBox(cb_region , p_errorRegion , tt_errorRegion , "trEmptyRegion");
            if (!cb_region.Text.Equals(""))
            {
                int regionId = Convert.ToInt32(cb_region.SelectedValue);
                if (regionId != 0)
                {
                    s = await countryModel.UpdateIsdefault(regionId);
                    if (!s.Equals("0"))
                    {
                        //update region and currency in main window
                        List<CountryCode> c = await countryModel.GetAllRegion();
                        MainWindow.Region = c.Where(r => r.countryId == int.Parse(s)).FirstOrDefault<CountryCode>();
                        MainWindow.Currency = MainWindow.Region.currency;

                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
            }
        }

        private async void Btn_saveLanguage_Click(object sender, RoutedEventArgs e)
        {//save language
            SectionData.validateEmptyComboBox(cb_language , p_errorLanguage , tt_errorLanguage , "trEmptyLanguage");
            if (!cb_language.Text.Equals(""))
            {
                if (usLanguage == null)
                    usLanguage = new UserSetValues();
                if (Convert.ToInt32(cb_language.SelectedValue) != 0)
                {
                    usLanguage.userId = MainWindow.userID;
                    usLanguage.valId = Convert.ToInt32(cb_language.SelectedValue);
                    usLanguage.createUserId = MainWindow.userID;
                    string s = await usValueModel.Save(usLanguage);
                    if (!s.Equals("0"))
                    {
                        //update language in main window
                        SetValues v = await valueModel.GetByID(Convert.ToInt32(cb_language.SelectedValue));
                        MainWindow.lang = v.value;
                        Properties.Settings.Default.Lang = v.value;

                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    //update languge in main window
                    MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
                    if (parentWindow != null)
                    {
                        //access property of the MainWindow class that exposes the access rights...
                        if (MainWindow.lang.Equals("en"))
                        {
                            MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                            parentWindow.grid_mainWindow.FlowDirection = FlowDirection.LeftToRight;
                        }
                        else
                        {
                            MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                            parentWindow.grid_mainWindow.FlowDirection = FlowDirection.RightToLeft;
                        }

                        parentWindow.translate();

                    }

                }
            }
        }
        private async void Btn_saveTax_Click(object sender, RoutedEventArgs e)
        {//save Tax
            SectionData.validateEmptyTextBox(tb_tax, p_errorTax, tt_errorTax, "trEmptyTax");
            if (!tb_tax.Text.Equals(""))
            {
                if (tax == null)
                    tax = new SetValues();
                tax.value = tb_tax.Text;
                tax.isSystem = 1;
                tax.settingId = taxId;
                string s = await valueModel.Save(tax);
                if (!s.Equals("0"))
                {
                    //update tax in main window
                    MainWindow.tax = decimal.Parse(tax.value);

                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }

        private async void Btn_saveCurrency_Click(object sender, RoutedEventArgs e)
        {//save currency
        }

        private void Cb_region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            region = cb_region.SelectedItem as CountryCode;
            tb_currency.Text = region.currency;
        }

        private void Tb_PreventSpaces(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_decimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { //decimal
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }


        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_tax")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorTax, tt_errorTax, "trEmptyTax");
                else if ((sender as TextBox).Name == "tb_storageCost")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorStorageCost, tt_errorStorageCost, "trEmptyStoreCost");
               
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_region")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorRegion, tt_errorRegion, "trEmptyRegion");
                if ((sender as ComboBox).Name == "cb_language")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorLanguage, tt_errorLanguage, "trEmptyLanguage");
            }
        }

        private void Btn_changePassword_Click(object sender, RoutedEventArgs e)
        {//change password
            Window.GetWindow(this).Opacity = 0.2;
            wd_adminChangePassword w = new wd_adminChangePassword();
            w.ShowDialog();
            Window.GetWindow(this).Opacity = 1;
        }

        private async void Btn_saveStorageCost_Click(object sender, RoutedEventArgs e)
        {//save storage cost
            SectionData.validateEmptyTextBox(tb_storageCost , p_errorStorageCost , tt_errorStorageCost , "trEmptyStoreCost");
            if (!tb_storageCost.Text.Equals(""))
            {
                if (cost == null)
                    cost = new SetValues();
                cost.value = tb_storageCost.Text;
                cost.isSystem = 1;
                cost.settingId = costId;
                string s = await valueModel.Save(cost);

                if (!s.Equals("0"))
                {
                    //update tax in main window
                    MainWindow.StorageCost = decimal.Parse(cost.value);

                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }


    }
}

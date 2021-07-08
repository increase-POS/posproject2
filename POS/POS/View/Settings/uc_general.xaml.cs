using POS.Classes;
using POS.View.windows;
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

namespace POS.View.Settings
{
    /// <summary>
    /// Interaction logic for uc_general.xaml
    /// </summary>
    public partial class uc_general : UserControl
    {
        SettingCls setModel = new SettingCls();
        SetValues valueModel = new SetValues();
        UserSetValues usValueModel = new UserSetValues();
        CountryCode countryModel = new CountryCode();

        SettingCls set = new SettingCls();
        SetValues language= new SetValues();
        SetValues tax = new SetValues();
        UserSetValues usLanguage = new UserSetValues();
        UserSetValues usValue = new UserSetValues();
        CountryCode region = new CountryCode();

        int taxId = 0;

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
            List<CountryCode> regions = new List<CountryCode>();
            regions = await countryModel.GetAllRegion();
            //MessageBox.Show(regions.Count.ToString());
            region = regions.Where(r => r.isDefault == 1).FirstOrDefault<CountryCode>();
            //MessageBox.Show(region.code);
            if (region != null)
            { cb_region.SelectedValue = region.countryId; MessageBox.Show(region.countryId.ToString()); }
            #endregion

            fillLanguages();

            #region get default language
            //List<SettingCls> settings = new List<SettingCls>();//all settings
            //settings = await setModel.GetAll();
            //set = settings.Where(s => s.name=="language").FirstOrDefault();
            //List<UserSetValues> usValues = new List<UserSetValues>();//all values
            //usValues = await usValueModel.GetAll();
            //usValue = usValues.Where(s => s.userId == MainWindow.userID).FirstOrDefault();
            //List<SetValues> setValues = new List<SetValues>();
            //setValues = await valueModel.GetAll();
            //language = setValues.Where(l => l.settingId == set.settingId).ToList<SetValues>();
            //if (language != null)
            //    cb_language.SelectedValue = language.valId;
            #endregion////////////////???????????????

            fillCurrencies();

            #region get default currency
            #endregion

            #region get default tax
            List<SettingCls> settingsCls = await setModel.GetAll();
            List<SetValues> settingsValues = await valueModel.GetAll();
            set = settingsCls.Where(s => s.name == "tax").FirstOrDefault<SettingCls>();
            taxId = set.settingId;
            tax = settingsValues.Where(i => i.settingId == taxId).FirstOrDefault();
            if(tax != null)
            tb_tax.Text = tax.value;
            #endregion

        }

        private async void fillCurrencies()////////////////???????????????
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
            List<SetValues> languages = new List<SetValues>();
            languages = lanValues.Where(vl => vl.settingId == set.settingId).ToList<SetValues>();

            foreach(var v in languages)
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
            txt_notifhint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txtOffers.Text = MainWindow.resourcemanager.GetString("trOffer");
            txt_offerHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_coupon.Text = MainWindow.resourcemanager.GetString("trCoupon");
            txt_couponHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_sms.Text = MainWindow.resourcemanager.GetString("trSms");
            txt_smsHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_emails.Text = MainWindow.resourcemanager.GetString("trEmails");
            txt_emailHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_backUp.Text = MainWindow.resourcemanager.GetString("trBackUp/Restore");
            txt_backUpHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_dashBoard.Text = MainWindow.resourcemanager.GetString("trDashBoard");
            txt_dashHint.Text = MainWindow.resourcemanager.GetString("trDashHint");
        }

        private async void Btn_saveRegion_Click(object sender, RoutedEventArgs e)
        {//save region
            string s = await countryModel.UpdateIsdefault(Convert.ToInt32(cb_region.SelectedValue));
        }

        private async void Btn_saveLanguage_Click(object sender, RoutedEventArgs e)
        {//save language/////////////////////////////????????????????????????????
            //List<UserSetValues> userSetValues = new List<UserSetValues>();
            //userSetValues = await usValueModel.GetAll();
            //usLanguage = userSetValues.Where(l => l.valId == Convert.ToInt32(cb_language.SelectedValue)).FirstOrDefault();
            //usLanguage.id = 0;
            usLanguage.userId = MainWindow.userID;
            usLanguage.valId = Convert.ToInt32(cb_language.SelectedValue);
            usLanguage.createUserId = MainWindow.userID;
            string s = await usValueModel.Save(usLanguage);
            MessageBox.Show(s);
        
        }
        private async void Btn_saveTax_Click(object sender, RoutedEventArgs e)
        {//save Tax
            tax.valId = 0;
            tax.value = tb_tax.Text;
            tax.isSystem = 1;
            tax.settingId = 0;
            string s = await valueModel.Save(tax);
            MessageBox.Show(s);
        }
    }
}

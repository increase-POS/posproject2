using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.Win32;

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
        static SetValues language = new SetValues();
        static SetValues tax = new SetValues();
        static SetValues accuracy = new SetValues();
        static SetValues dateForm = new SetValues();
        static SetValues cost = new SetValues();
        static public UserSetValues usLanguage = new UserSetValues();
        static UserSetValues usValue = new UserSetValues();
        static CountryCode region = new CountryCode();
        static List<SetValues> languages = new List<SetValues>();
        static int taxId = 0, costId = 0, dateFormId, accuracyId;
        string usersSettingsPermission = "general_usersSettings";
        string companySettingsPermission = "general_companySettings";

        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

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
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }



        #region loading
        bool firstLoading = true;
        List<keyValueBool> loadingList;
        async void loading_fillRegions()
        {
            try
            {
                await fillRegions();
                #region get default region
                await getDefaultRegion();
                if (region != null)
                {
                    cb_region.SelectedValue = region.countryId;
                    cb_region.Text = region.name;
                }
                #endregion
            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_fillRegions"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_fillLanguages()
        {
            try
            {
                await fillLanguages();
                #region get default language
                await getDefaultLanguage();
                if (usLanguage != null)
                    cb_language.SelectedValue = usLanguage.valId;
                #endregion
            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_fillLanguages"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_fillCurrencies()
        {
            try
            {
                await fillCurrencies();
                #region get default currency
                if (region != null)
                {
                    tb_currency.Text = region.currency;
                }
                #endregion
            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_fillCurrencies"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_getDefaultTax()
        {
            try
            {
                #region get default tax
                await getDefaultTax();
                if (tax != null)
                    tb_tax.Text = tax.value;
                #endregion
            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getDefaultTax"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_getDefaultDateForm()
        {
            try
            {
                #region fill dateform
                DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
                var date = DateTime.Now;
                var typelist = new[] {
                    new { Text = date.ToString(dtfi.ShortDatePattern), Value = "ShortDatePattern" },
                    new { Text = date.ToString(dtfi.LongDatePattern) , Value = "LongDatePattern" },
                    new { Text =  date.ToString(dtfi.MonthDayPattern), Value = "MonthDayPattern" },
                    new { Text =  date.ToString(dtfi.YearMonthPattern), Value = "YearMonthPattern" },
                     };
                cb_dateForm.DisplayMemberPath = "Text";
                cb_dateForm.SelectedValuePath = "Value";
                cb_dateForm.ItemsSource = typelist;
                #endregion
                #region get default date form
                await getDefaultDateForm();
                if (dateForm != null)
                    cb_dateForm.SelectedValue = dateForm.value;
                else
                    cb_dateForm.SelectedIndex = -1;
                #endregion
            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getDefaultDateForm"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_fillAccuracy()
        {
            try
            {
                fillAccuracy();
                #region get default accracy
                await getDefaultAccuracy();
                if (accuracy != null)
                {
                    cb_accuracy.SelectedValue = accuracy.value;
                }
                #endregion
            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_fillAccuracy"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        #endregion
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }

                translate();
                #endregion

                #region loading
                if (firstLoading)
                {
                    loadingList = new List<keyValueBool>();
                    bool isDone = true;
                    loadingList.Add(new keyValueBool { key = "loading_fillRegions", value = false });
                    loadingList.Add(new keyValueBool { key = "loading_fillLanguages", value = false });
                    loadingList.Add(new keyValueBool { key = "loading_fillCurrencies", value = false });
                    loadingList.Add(new keyValueBool { key = "loading_getDefaultTax", value = false });
                    loadingList.Add(new keyValueBool { key = "loading_getDefaultDateForm", value = false });
                    loadingList.Add(new keyValueBool { key = "loading_fillAccuracy", value = false });
                    loading_fillRegions();
                    loading_fillLanguages();
                    loading_fillCurrencies();
                    loading_getDefaultTax();
                    loading_getDefaultDateForm();
                    loading_fillAccuracy();
                    do
                    {
                        isDone = true;
                        foreach (var item in loadingList)
                        {
                            if (item.value == false)
                            {
                                isDone = false;
                                break;
                            }
                        }
                        if (!isDone)
                        {
                            //MessageBox.Show("not done");
                            //string s = "";
                            //foreach (var item in loadingList)
                            //{
                            //    s += item.name + " - " + item.value + "\n";
                            //}
                            //MessageBox.Show(s);
                            await Task.Delay(0500);
                            //MessageBox.Show("do");
                        }
                    }
                    while (!isDone);
                    fillBackup();
                    firstLoading = false;
                }

                #endregion

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_companyInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_companyInfo w = new wd_companyInfo();
                    w.isFirstTime = false;
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        public static async Task<SetValues> getDefaultAccuracy()
        {
            List<SettingCls> settingsCls = await setModel.GetAll();
            List<SetValues> settingsValues = await valueModel.GetAll();
            set = settingsCls.Where(s => s.name == "accuracy").FirstOrDefault<SettingCls>();
            accuracyId = set.settingId;
            accuracy = settingsValues.Where(i => i.settingId == accuracyId).FirstOrDefault();
            return accuracy;
        }

        private void fillAccuracy()
        {
            var list = new[] {
                new { Text = "0"       , Value = "0" },
                new { Text = "0.0"     , Value = "1" },
                new { Text = "0.00"    , Value = "2" },
                new { Text = "0.000"   , Value = "3" },
                 };
            cb_accuracy.DisplayMemberPath = "Text";
            cb_accuracy.SelectedValuePath = "Value";
            cb_accuracy.ItemsSource = list;
        }
        private void fillBackup()
        {
            cb_backup.DisplayMemberPath = "Text";
            cb_backup.SelectedValuePath = "Value";
            var typelist = new[] {
                 new { Text = MainWindow.resourcemanager.GetString("trBackup")       , Value = "backup" },
                 new { Text = MainWindow.resourcemanager.GetString("trRestore")       , Value = "restore" },
                };
            cb_backup.ItemsSource = typelist;
            cb_backup.SelectedIndex = 0;
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

        public static async Task<SetValues> getDefaultDateForm()
        {
            List<SettingCls> settingsCls = await setModel.GetAll();
            List<SetValues> settingsValues = await valueModel.GetAll();
            set = settingsCls.Where(s => s.name == "dateForm").FirstOrDefault<SettingCls>();
            dateFormId = set.settingId;
            dateForm = settingsValues.Where(i => i.settingId == dateFormId).FirstOrDefault();
            return dateForm;
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
        private async Task fillCurrencies()
        {
            cb_currency.ItemsSource = await countryModel.GetAllRegion();
            cb_currency.DisplayMemberPath = "currency";
            cb_currency.SelectedValuePath = "countryId";
        }

        private async Task fillLanguages()
        {
            var lanSettings = await setModel.GetAll();
            set = lanSettings.Where(l => l.name == "language").FirstOrDefault<SettingCls>();
            var lanValues = await valueModel.GetAll();
            languages = lanValues.Where(vl => vl.settingId == set.settingId).ToList<SetValues>();
            foreach (var v in languages)
            {
                if (v.value.ToString().Equals("en")) v.value = MainWindow.resourcemanager.GetString("trEnglish");
                else if (v.value.ToString().Equals("ar")) v.value = MainWindow.resourcemanager.GetString("trArabic");
            }

            cb_language.ItemsSource = languages;
            cb_language.DisplayMemberPath = "value";
            cb_language.SelectedValuePath = "valId";

        }

        private async Task fillRegions()
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
            txt_dateForm.Text = MainWindow.resourcemanager.GetString("trDateForm");
            txt_accuracy.Text = MainWindow.resourcemanager.GetString("trAccuracy");
            //txt_notification.Text = MainWindow.resourcemanager.GetString("trNotification");
            //txt_storageCost.Text = MainWindow.resourcemanager.GetString("trStorageCost");
            //txt_notifhint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            //txtOffers.Text = MainWindow.resourcemanager.GetString("trOffer");
            //txt_offerHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            //txt_coupon.Text = MainWindow.resourcemanager.GetString("trCoupon");
            //txt_couponHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_adminChangePassword.Text = MainWindow.resourcemanager.GetString("trChangePassword");
            txt_adminChangePasswordHint.Text = MainWindow.resourcemanager.GetString("trChangePasswordHint");
            txt_sms.Text = MainWindow.resourcemanager.GetString("trSms");
            txt_smsHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            //txt_emails.Text = MainWindow.resourcemanager.GetString("trEmails");
            //txt_emailHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            txt_backup.Text = MainWindow.resourcemanager.GetString("trBackUp/Restore");
            //txt_backupHint.Text = MainWindow.resourcemanager.GetString("trSettingHint");
            //txt_dashBoard.Text = MainWindow.resourcemanager.GetString("trDashBoard");
            //txt_dashHint.Text = MainWindow.resourcemanager.GetString("trDashHint");

            tt_region.Content = MainWindow.resourcemanager.GetString("trRegion");
            tt_language.Content = MainWindow.resourcemanager.GetString("trLanguage");
            tt_currency.Content = MainWindow.resourcemanager.GetString("trCurrency");
            tt_tax.Content = MainWindow.resourcemanager.GetString("trTax");
            tt_dateForm.Content = MainWindow.resourcemanager.GetString("trDateForm");
            tt_accuracy.Content = MainWindow.resourcemanager.GetString("trAccuracy");
            //tt_storageCost.Content = MainWindow.resourcemanager.GetString("trStorageCost");
        }

        private async void Btn_saveRegion_Click(object sender, RoutedEventArgs e)
        {//save region
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    // string s = "";
                    int s = 0;
                    SectionData.validateEmptyComboBox(cb_region, p_errorRegion, tt_errorRegion, "trEmptyRegion");
                    if (!cb_region.Text.Equals(""))
                    {
                        int regionId = Convert.ToInt32(cb_region.SelectedValue);
                        if (regionId != 0)
                        {
                            s = await countryModel.UpdateIsdefault(regionId);
                            if (!s.Equals(0))
                            {
                                //update region and currency in main window
                                List<CountryCode> c = await countryModel.GetAllRegion();
                                MainWindow.Region = c.Where(r => r.countryId == s).FirstOrDefault<CountryCode>();
                                MainWindow.Currency = MainWindow.Region.currency;
                                MainWindow.CurrencyId = MainWindow.Region.currencyId;
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                            }
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Btn_saveLanguage_Click(object sender, RoutedEventArgs e)
        {//save language
            try
            {


                if (MainWindow.groupObject.HasPermissionAction(usersSettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    SectionData.validateEmptyComboBox(cb_language, p_errorLanguage, tt_errorLanguage, "trEmptyLanguage");
                    if (!cb_language.Text.Equals(""))
                    {
                        if (usLanguage == null)
                            usLanguage = new UserSetValues();
                        if (Convert.ToInt32(cb_language.SelectedValue) != 0)
                        {
                            if (sender != null)
                                SectionData.StartAwait(grid_main);
                            usLanguage.userId = MainWindow.userID;
                            usLanguage.valId = Convert.ToInt32(cb_language.SelectedValue);
                            usLanguage.createUserId = MainWindow.userID;
                            // string s = await usValueModel.Save(usLanguage);
                            int s = await usValueModel.Save(usLanguage);
                            if (!s.Equals(0))
                            {
                                //update language in main window
                                SetValues v = await valueModel.GetByID(Convert.ToInt32(cb_language.SelectedValue));
                                MainWindow.lang = v.value;
                                //save to user settings
                                Properties.Settings.Default.Lang = v.value;
                                Properties.Settings.Default.Save();

                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                            }
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                            if (sender != null)
                                SectionData.EndAwait(grid_main);
                            uc_settings objUC1 = new uc_settings();
                            //objUC1.UserControl_Loaded(null , null);

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

                                //parentWindow
                                //UserControl_Loaded(null, null);

                                //uc_settings set = new uc_settings();
                                //parentWindow.grid_main.Children.Clear();
                                //parentWindow.grid_main.Children.Add(set);
                                //uc_general g = new uc_general();
                                //set.Content = g;
                                //set.ex.Visibility = Visibility.Visible;
                                //set.UserControl_Loaded(null , null);

                                //this.UserControl_Loaded(null , null);
                                MainWindow.loadingDefaultPath("settings", "general");
                                //MainWindow.mainWindow.SetNotificationsLocation();
                            }
                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_saveTax_Click(object sender, RoutedEventArgs e)
        {//save Tax
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    SectionData.validateEmptyTextBox(tb_tax, p_errorTax, tt_errorTax, "trEmptyTax");
                    if (!tb_tax.Text.Equals(""))
                    {
                        if (tax == null)
                            tax = new SetValues();
                        tax.value = tb_tax.Text;
                        tax.isSystem = 1;
                        tax.settingId = taxId;
                        // string s = await valueModel.Save(tax);
                        int s = await valueModel.Save(tax);
                        if (!s.Equals(0))
                        {
                            //update tax in main window
                            MainWindow.tax = decimal.Parse(tax.value);

                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                        }
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_saveCurrency_Click(object sender, RoutedEventArgs e)
        {//save currency
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                region = cb_region.SelectedItem as CountryCode;
                if (region != null)
                    tb_currency.Text = region.currency;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Tb_PreventSpaces(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Tb_decimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { //decimal
            try
            {
                var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
                if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //string name = sender.GetType().Name;
                //validateEmpty(name, sender);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void validateEmpty(string name, object sender)
        {
            try
            {
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_tax")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorTax, tt_errorTax, "trEmptyTax");
                    //else if ((sender as TextBox).Name == "tb_storageCost")
                    //    SectionData.validateEmptyTextBox((TextBox)sender, p_errorStorageCost, tt_errorStorageCost, "trEmptyStoreCost");

                }
                else if (name == "ComboBox")
                {
                    if ((sender as ComboBox).Name == "cb_region")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorRegion, tt_errorRegion, "trEmptyRegion");
                    if ((sender as ComboBox).Name == "cb_language")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorLanguage, tt_errorLanguage, "trEmptyLanguage");
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        User userModel = new User();
        User user = new User();

        private async void Btn_savedDateForm_Click(object sender, RoutedEventArgs e)
        {//save date form
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    SectionData.validateEmptyComboBox(cb_dateForm, p_errorDateForm, tt_errorDateForm, "trEmptyDateFormat");
                    if (!cb_dateForm.Text.Equals(""))
                    {
                        if (dateForm == null)
                            dateForm = new SetValues();
                        dateForm.value = cb_dateForm.SelectedValue.ToString();
                        dateForm.isSystem = 1;
                        dateForm.settingId = dateFormId;
                        // string s = await valueModel.Save(dateForm);
                        int s = await valueModel.Save(dateForm);
                        if (!s.Equals(0))
                        {
                            //update dateForm in main window
                            MainWindow.dateFormat = dateForm.value;

                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                        }
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_backup_Click(object sender, RoutedEventArgs e)
        {//drag&drop
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_favorite w = new wd_favorite();
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_userPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                //{
                Window.GetWindow(this).Opacity = 0.2;
                wd_userPath w = new wd_userPath();
                w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //decimal num = decimal.Parse(tb_tax.Text);
            //string s = num.ToString();

            //switch (cb_accuracy.SelectedValue.ToString())
            //{
            //    case "0":
            //        //num = (double)Math.Round(num, 1);
            //        //s = String.Format("{0}", num);
            //        s = string.Format("{0:F0}", num);
            //        break;
            //    case "1":
            //        //num = (double)Math.Round(num, 2);
            //        //s = String.Format("{0:0.#}", num);
            //        s = string.Format("{0:F1}", num);
            //        break;
            //    case "2":
            //        //num = (double)Math.Round(num, 3);
            //        //s = String.Format("{0:0.##}", num);
            //        s = string.Format("{0:F2}", num);
            //        break;
            //    case "3":
            //        //num = (double)Math.Round(num, 4);
            //        s = string.Format("{0:F3}", num);
            //        //s = String.Format("{0:0.###}", num);
            //        break;
            //    default:
            //        //num = (double)Math.Round(num, 5);
            //        //s = String.Format("{0:0.#}", num);
            //        s = string.Format("{0:F1}", num);
            //        break;
            //}

            //MessageBox.Show(s);
        }

        private async void Btn_saveBackup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (cb_backup.SelectedValue.ToString() == "backup")
                {
                    BackupCls back = new BackupCls();
                    saveFileDialog.Filter = "INC|*.inc;";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filepath = saveFileDialog.FileName;
                        string message = await back.GetFile(filepath);
                        if (message == "1")
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trBackupDoneSuccessfuly"), animation: ToasterAnimation.FadeIn);
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trBackupNotComplete"), animation: ToasterAnimation.FadeIn);
                    }
                }
                else
                {
                    // restore
                    string filepath = "";
                    openFileDialog.Filter = "INC|*.inc; ";
                    BackupCls back = new BackupCls();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        #region
                        Window.GetWindow(this).Opacity = 0.2;
                        wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                        w.contentText = MainWindow.resourcemanager.GetString("trContinueProcess?");
                        w.ShowDialog();
                        Window.GetWindow(this).Opacity = 1;
                        #endregion
                        if (w.isOk)
                        {
                            // here start restore if user click yes button Mr. Yasin //////////////////////////////////////////////////////
                            filepath = openFileDialog.FileName;
                            string message = await back.uploadFile(filepath);
                            if (message == "1")
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trRestoreDoneSuccessfuly"), animation: ToasterAnimation.FadeIn);
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trRestoreNotComplete"), animation: ToasterAnimation.FadeIn);


                        }
                        else
                        {
                            // here if user click no button

                        }
                    }
                }

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Btn_saveAccuracy_Click(object sender, RoutedEventArgs e)
        {//save accuracy
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    SectionData.validateEmptyComboBox(cb_accuracy, p_errorAccuracy, tt_errorAccuracy, "trEmptyAccuracy");
                    if (!cb_accuracy.Text.Equals(""))
                    {
                        if (accuracy == null)
                            accuracy = new SetValues();
                        accuracy.value = cb_accuracy.SelectedValue.ToString();
                        accuracy.isSystem = 1;
                        accuracy.settingId = accuracyId;
                        //  string s = await valueModel.Save(accuracy);
                        int s = await valueModel.Save(accuracy);
                        if (!s.Equals(0))
                        {
                            //update accuracy in main window
                            MainWindow.accuracy = accuracy.value;

                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                        }
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                wd_setupServer w = new wd_setupServer();
                w.ShowDialog();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }



        private async void Btn_changePassword_Click(object sender, RoutedEventArgs e)
        {//change password
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_adminChangePassword w = new wd_adminChangePassword();
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;

                    //update user in main window
                    user = await userModel.getUserById(w.userID);
                    MainWindow.userLogin = user;

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
    }
}

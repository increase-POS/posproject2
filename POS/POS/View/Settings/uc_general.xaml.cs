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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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
    }
}

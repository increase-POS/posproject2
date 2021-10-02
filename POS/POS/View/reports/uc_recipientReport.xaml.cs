using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
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
using static POS.Classes.Statistics;

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for uc_recipientReport.xaml
    /// </summary>
    public partial class uc_recipientReport : UserControl
    {
        Statistics statisticModel = new Statistics();
        List<CashTransferSts> payments;

        IEnumerable<VendorCombo> vendorCombo;
        IEnumerable<VendorCombo> customerCombo;
        IEnumerable<VendorCombo> userCombo;
        IEnumerable<ShippingCombo> ShippingCombo;

        IEnumerable<PaymentsTypeCombo> payCombo;

        IEnumerable<AccountantCombo> accCombo;
        IEnumerable<AccountantCombo> accCustomerCombo;
        IEnumerable<AccountantCombo> accUserCombo;
        IEnumerable<AccountantCombo> accShippingCombo;

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

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

                payments = await statisticModel.GetReceipt();

                vendorCombo = statisticModel.getVendorCombo(payments, "v");
                customerCombo = statisticModel.getVendorCombo(payments, "c");
                userCombo = statisticModel.getUserAcc(payments, "u");
                ShippingCombo = statisticModel.getShippingCombo(payments);

                payCombo = statisticModel.getPaymentsTypeCombo(payments);

                accCombo = statisticModel.getAccounantCombo(payments, "v");
                accCustomerCombo = statisticModel.getAccounantCombo(payments, "c");
                accUserCombo = statisticModel.getAccounantCombo(payments, "u");
                accShippingCombo = statisticModel.getAccounantCombo(payments, "sh");

                fillVendorCombo(vendorCombo, cb_vendors);
                fillPaymentsTypeCombo(cb_vendorPayType);
                fillAccCombo(accCombo, cb_vendorAccountant);

                fillVendorsEvents();
                hideAllColumn();

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_vendor.Tag.ToString());

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

        private void translate()
        {
            //dgPayments.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            //dgPayments.Columns[1].Header = MainWindow.resourcemanager.GetString("trRecepient");
            //dgPayments.Columns[2].Header = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            //dgPayments.Columns[3].Header = MainWindow.resourcemanager.GetString("trCashTooltip");
        }

        private void fillVendorCombo(IEnumerable<VendorCombo> list, ComboBox cb)
        {
            cb.SelectedValuePath = "VendorId";
            cb.DisplayMemberPath = "VendorName";
            cb.ItemsSource = list;
        }

        private void fillPaymentsTypeCombo(ComboBox cb)
        {
            cb.SelectedValuePath = "PaymentsTypeName";
            cb.DisplayMemberPath = "PaymentsTypeName";
            foreach (var p in payCombo)
            {
                string Text = "";
                switch (p.PaymentsTypeName)
                {
                    case "cash": Text = MainWindow.resourcemanager.GetString("trCash"); break;
                    case "doc": Text = MainWindow.resourcemanager.GetString("trDocument"); break;
                    case "cheque": Text = MainWindow.resourcemanager.GetString("trCheque"); break;
                    case "card": Text = MainWindow.resourcemanager.GetString("trCreditCard"); break;
                    case "inv": Text = MainWindow.resourcemanager.GetString("trInv"); break;
                }

                p.PaymentsTypeName = Text;
            }
            cb.ItemsSource = payCombo;
        }

        private void fillAccCombo(IEnumerable<AccountantCombo> list, ComboBox cb)
        {
            cb.SelectedValuePath = "Accountant";
            cb.DisplayMemberPath = "Accountant";
            cb.ItemsSource = list;
        }
        private void fillSalaryCombo(IEnumerable<VendorCombo> list, ComboBox cb)
        {
            cb.SelectedValuePath = "UserId";
            cb.DisplayMemberPath = "UserAcc";
            cb.ItemsSource = list;
        }
        private void fillShippingCombo(IEnumerable<ShippingCombo> list, ComboBox cb)
        {
            cb.SelectedValuePath = "ShippingId";
            cb.DisplayMemberPath = "ShippingName";
            cb.ItemsSource = list;
        }

        private List<CashTransferSts> fillList(List<CashTransferSts> payments, ComboBox vendor, ComboBox payType, ComboBox accountant
           , DatePicker startDate, DatePicker endDate)
        {

            var selectedItem1 = vendor.SelectedItem as VendorCombo;
            var selectedItem2 = payType.SelectedItem as PaymentsTypeCombo;
            var selectedItem3 = accountant.SelectedItem as AccountantCombo;
            var selectedItem4 = vendor.SelectedItem as VendorCombo;
            var selectedItem5 = vendor.SelectedItem as ShippingCombo;

            var result = payments.Where(x => (
              (vendor.SelectedItem != null ? x.agentId == selectedItem1.VendorId : true)
                        && (payType.SelectedItem != null ? x.processType == selectedItem2.PaymentsTypeName : true)
                        && (accountant.SelectedItem != null ? x.updateUserAcc == selectedItem3.Accountant : true)
                        && (startDate.SelectedDate != null ? x.updateDate >= startDate.SelectedDate : true)
                        && (endDate.SelectedDate != null ? x.updateDate <= endDate.SelectedDate : true)));
            if (selectedTab == 2)
            {
                result = payments.Where(x => (
             (vendor.SelectedItem != null ? x.userId == selectedItem4.UserId : true)
                       && (payType.SelectedItem != null ? x.processType == selectedItem2.PaymentsTypeName : true)
                       && (accountant.SelectedItem != null ? x.updateUserAcc == selectedItem3.Accountant : true)
                       && (startDate.SelectedDate != null ? x.updateDate >= startDate.SelectedDate : true)
                       && (endDate.SelectedDate != null ? x.updateDate <= endDate.SelectedDate : true)));
            }
            if (selectedTab == 6)
            {
                if(selectedItem5 != null)
                    result = payments.Where(x => (
                 (vendor.SelectedItem != null ? x.shippingCompanyId == selectedItem5.ShippingId : true)
                           && (payType.SelectedItem != null    ? x.processType == selectedItem2.PaymentsTypeName : true)
                           && (accountant.SelectedItem != null ? x.updateUserAcc == selectedItem3.Accountant : true)
                           && (startDate.SelectedDate != null  ? x.updateDate >= startDate.SelectedDate : true)
                           && (endDate.SelectedDate != null    ? x.updateDate <= endDate.SelectedDate : true)));
            }
            return result.ToList();
        }

        public uc_recipientReport()
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
        private static uc_recipientReport _instance;
        public static uc_recipientReport Instance
        {
            get
            {
                if (_instance == null) _instance = new uc_recipientReport();
                return _instance;
            }
        }
        /*Vendor*/
        /*********************************************************************************/
        private void Cb_vendors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillVendorsEvents();

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

        private void Cb_vendorPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillVendorsEvents();

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

        private void Cb_vendorAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillVendorsEvents();

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

        private void Dp_vendorStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillVendorsEvents();

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

        private void Dp_vendorEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillVendorsEvents();

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

        private void Chk_allVendors_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_vendors.SelectedItem = null;
                cb_vendors.IsEnabled = false;

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

        private void Chk_allVendors_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_vendors.IsEnabled = true;

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

        private void Chk_allVendorsPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_vendorPayType.SelectedItem = null;
                cb_vendorPayType.IsEnabled = false;

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

        private void Chk_allVendorsPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_vendorPayType.IsEnabled = true;

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

        private void Chk_allVendorsAccountant_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_vendorAccountant.SelectedItem = null;
                cb_vendorAccountant.IsEnabled = false;

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

        private void Chk_allVendorsAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_vendorAccountant.IsEnabled = true;

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
        /*Customer*/
        /*********************************************************************************/
        private void Cb_customerAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillCustomersEvents();

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

        private void Cb_customerPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillCustomersEvents();

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

        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillCustomersEvents();

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

        private void Dp_customerStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillCustomersEvents();

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

        private void Dp_customerEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillCustomersEvents();

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

        private void Chk_allCustomers_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_customer.IsEnabled = false;
                cb_customer.SelectedItem = null;

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

        private void Chk_allCustomers_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_customer.IsEnabled = true;

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

        private void Chk_allCustomersPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_customerPayType.IsEnabled = false;
                cb_customerPayType.SelectedItem = null;

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

        private void Chk_allCustomersPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_customerPayType.IsEnabled = true;

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

        private void Chk_allCustomersAccountant_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_customerAccountant.IsEnabled = false;
                cb_customerAccountant.SelectedItem = null;

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

        private void Chk_allCustomersAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_customerAccountant.IsEnabled = true;

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

        /*User*/
        /*********************************************************************************/
        private void Cb_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillUserEvents();

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

        private void Cb_userPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillUserEvents();

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

        private void Cb_userAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillUserEvents();

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

        private void Dp_userEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillUserEvents();

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

        private void Dp_userStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillUserEvents();

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

        private void Chk_allUsers_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_users.SelectedItem = null;
                cb_users.IsEnabled = false;

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

        private void Chk_allUsers_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_users.IsEnabled = true;

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

        private void Chk_allUsersPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_userPayType.SelectedItem = null;
                cb_userPayType.IsEnabled = false;

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

        private void Chk_allUsersPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_userPayType.IsEnabled = true;

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

        private void Chk_allUsersAccountant_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_userAccountant.SelectedItem = null;
                cb_userAccountant.IsEnabled = false;

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

        private void Chk_allUsersAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_userAccountant.IsEnabled = true;

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
        /*Shipping*/
        /*********************************************************************************/
        private void Cb_shipping_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillShippingEvents();

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

        private void Cb_shippingPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillShippingEvents();

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

        private void Cb_shippingAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillShippingEvents();

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

        private void Dp_shippingStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillShippingEvents();

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

        private void Dp_shippingEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                fillShippingEvents();

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

        private void Chk_allShippings_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_shipping.IsEnabled = false;
                cb_shipping.SelectedItem = null;

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

        private void Chk_allShippings_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_shipping.IsEnabled = true;

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

        private void Chk_allShippingsPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_shippingPayType.IsEnabled = false;
                cb_shippingPayType.SelectedItem = null;

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

        private void Chk_allShippingsPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_shippingPayType.IsEnabled = true;

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

        private void Chk_allShippingsAccountant_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_shippingAccountant.IsEnabled = false;
                cb_shippingAccountant.SelectedItem = null;

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

        private void Chk_allShippingsAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_shippingAccountant.IsEnabled = true;

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
        /*********************************************************************/

        int selectedTab = 0;

        public void paint()
        {

            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            bdr_customer.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_vendor.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_user.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_shipping.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_customer.Fill = Brushes.White;
            path_vendor.Fill = Brushes.White;
            path_user.Fill = Brushes.White;
            path_shipping.Fill = Brushes.White;

            grid_customer.Visibility = Visibility.Hidden;
            grid_vendor.Visibility = Visibility.Hidden;
            grid_user.Visibility = Visibility.Hidden;
            grid_shipping.Visibility = Visibility.Hidden;
        }

        private void isEnabledButtons()
        {
            btn_customer.IsEnabled = true;
            btn_vendor.IsEnabled = true;
            btn_user.IsEnabled = true;
            btn_shipping.IsEnabled = true;
        }

        private void hideAllColumn()
        {
            grid_vendor.Visibility = Visibility.Hidden;
            grid_customer.Visibility = Visibility.Hidden;
            grid_shipping.Visibility = Visibility.Hidden;
            grid_user.Visibility = Visibility.Hidden;

            col_tansNum.Visibility = Visibility.Hidden;
            col_processType.Visibility = Visibility.Hidden;
            col_updateUserAcc.Visibility = Visibility.Hidden;

            col_agentName.Visibility = Visibility.Hidden;
            col_customer.Visibility = Visibility.Hidden;
            col_user.Visibility = Visibility.Hidden;
            col_shipping.Visibility = Visibility.Hidden;

            col_company.Visibility = Visibility.Hidden;
            col_updateDate.Visibility = Visibility.Hidden;
            col_cash.Visibility = Visibility.Hidden;

            if (selectedTab == 0)
            {
                grid_vendor.Visibility = Visibility.Visible;

                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;

                col_agentName.Visibility = Visibility.Visible;

                col_company.Visibility = Visibility.Visible;
                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 1)
            {
                grid_customer.Visibility = Visibility.Visible;

                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;

                col_customer.Visibility = Visibility.Visible;

                col_company.Visibility = Visibility.Visible;
                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 2)
            {
                grid_user.Visibility = Visibility.Visible;

                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;

                col_user.Visibility = Visibility.Visible;

                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 6)
            {
                grid_shipping.Visibility = Visibility.Visible;

                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;

                col_shipping.Visibility = Visibility.Visible;

                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;
            }

        }

        private void Btn_vendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                selectedTab = 0;
                paint();
                bdr_vendor.Background = Brushes.White;
                path_vendor.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                grid_vendor.Visibility = Visibility.Visible;
                isEnabledButtons();
                btn_vendor.IsEnabled = false;
                btn_vendor.Opacity = 1;
                fillVendorsEvents();
                hideAllColumn();
                fillAccCombo(accCombo, cb_vendorAccountant);
                fillPaymentsTypeCombo(cb_vendorPayType);
                fillVendorCombo(vendorCombo, cb_vendors);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

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

        private void Btn_customer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                selectedTab = 1;
                paint();
                bdr_customer.Background = Brushes.White;
                path_customer.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                grid_customer.Visibility = Visibility.Visible;
                isEnabledButtons();
                btn_customer.IsEnabled = false;
                btn_customer.Opacity = 1;
                fillCustomersEvents();
                hideAllColumn();

                fillAccCombo(accCustomerCombo, cb_customerAccountant);
                fillPaymentsTypeCombo(cb_customerPayType);
                fillVendorCombo(customerCombo, cb_customer);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

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

        private void Btn_user_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                selectedTab = 2;
                paint();
                bdr_user.Background = Brushes.White;
                path_user.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                grid_user.Visibility = Visibility.Visible;
                isEnabledButtons();
                btn_user.IsEnabled = false;
                btn_user.Opacity = 1;
                fillUserEvents();
                hideAllColumn();

                fillAccCombo(accUserCombo, cb_userAccountant);
                fillPaymentsTypeCombo(cb_userPayType);
                fillSalaryCombo(userCombo, cb_users);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

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

        private async void Btn_shipping_Click(object sender, RoutedEventArgs e)
        {//shipping
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                selectedTab = 6;

            paint();
                bdr_shipping.Background = Brushes.White;
                path_shipping.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                grid_shipping.Visibility = Visibility.Visible;
                isEnabledButtons();
                btn_shipping.IsEnabled = false;
                btn_shipping.Opacity = 1;
                fillShippingEvents();
                hideAllColumn();

                fillAccCombo(accShippingCombo, cb_shippingAccountant);
                fillPaymentsTypeCombo(cb_shippingPayType);
                fillShippingCombo(ShippingCombo, cb_shipping);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

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

        /*Fill Events*/
        /*********************************************************************************/
        IEnumerable<CashTransferSts> temp = null;
        private void fillVendorsEvents()
        {
            temp = fillList(payments, cb_vendors, cb_vendorPayType, cb_vendorAccountant, dp_vendorStartDate, dp_vendorEndDate).Where(x => x.side == "v" || x.side == "b");
            dgPayments.ItemsSource = temp;
            txt_count.Text = dgPayments.Items.Count.ToString();

            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }

        private void fillCustomersEvents()
        {
            temp = fillList(payments, cb_customer, cb_customerPayType, cb_customerAccountant, dp_customerStartDate, dp_customerEndDate).Where(x => x.side == "c" || x.side == "b");
            dgPayments.ItemsSource = temp;
            txt_count.Text = dgPayments.Items.Count.ToString();

            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }

        private void fillUserEvents()
        {
            temp = fillList(payments, cb_users, cb_userPayType, cb_userAccountant, dp_userStartDate, dp_userEndDate).Where(x => x.side == "u");
            dgPayments.ItemsSource = temp;
            txt_count.Text = dgPayments.Items.Count.ToString();

            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }

        private void fillShippingEvents()
        {
            temp = fillList(payments, cb_shipping, cb_shippingPayType, cb_shippingAccountant, dp_shippingStartDate, dp_shippingEndDate).Where(x => x.side == "sh");
            dgPayments.ItemsSource = temp;
            txt_count.Text = dgPayments.Items.Count.ToString();

            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }


        /*Charts*/
        /*********************************************************************************/

        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            List<int> resultList = new List<int>();
            titles.Clear();
            var temp = fillList(payments, cb_vendors, cb_vendorPayType, cb_vendorAccountant, dp_vendorStartDate, dp_vendorEndDate).Where(x => x.side == "v"); ;
            if (selectedTab == 1)
            {
                temp = fillList(payments, cb_customer, cb_customerPayType, cb_customerAccountant, dp_customerStartDate, dp_customerEndDate).Where(x => x.side == "c"); ;
            }
            else if (selectedTab == 2)
            {
                temp = fillList(payments, cb_users, cb_userPayType, cb_userAccountant, dp_userStartDate, dp_userEndDate).Where(x => x.side == "u");
            }
            else if (selectedTab == 6)
            {
                temp = fillList(payments, cb_shipping, cb_shippingPayType, cb_shippingAccountant, dp_shippingStartDate, dp_shippingEndDate).Where(x => x.side == "sh");
            }

            var result = temp
                .GroupBy(s => new { s.processType })
                .Select(s => new CashTransferSts
                {
                    processTypeCount = s.Count(),
                    processType = s.FirstOrDefault().processType,
                });
            resultList = result.Select(m => m.processTypeCount).ToList();
            titles = result.Select(m => m.processType).ToList();
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < resultList.Count(); i++)
            {
                List<int> final = new List<int>();
                List<string> lable = new List<string>();

                final.Add(resultList.Skip(i).FirstOrDefault());
                lable = titles;
                piechartData.Add(
                  new PieSeries
                  {
                      Values = final.AsChartValues(),
                      Title = lable.Skip(i).FirstOrDefault(),
                      DataLabels = true,
                  }
              );

            }
            chart1.Series = piechartData;
        }

        private void fillColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            List<CashTransferSts> resultList = new List<CashTransferSts>();

            var temp = fillList(payments, cb_vendors, cb_vendorPayType, cb_vendorAccountant, dp_vendorStartDate, dp_vendorEndDate).Where(x => x.side == "v"); ;
            if (selectedTab == 1)
            {
                temp = fillList(payments, cb_customer, cb_customerPayType, cb_customerAccountant, dp_customerStartDate, dp_customerEndDate).Where(x => x.side == "c"); ;
            }
            else if (selectedTab == 2)
            {
                temp = fillList(payments, cb_users, cb_userPayType, cb_userAccountant, dp_userStartDate, dp_userEndDate).Where(x => x.side == "u");
            }
            else if (selectedTab == 6)
            {
                temp = fillList(payments, cb_shipping, cb_shippingPayType, cb_shippingAccountant, dp_shippingStartDate, dp_shippingEndDate).Where(x => x.side == "sh");
            }
            var res = temp.GroupBy(x => new { x.agentId, x.processType }).Select(x => new CashTransferSts
            {
                processType = x.FirstOrDefault().processType,
                agentId = x.FirstOrDefault().agentId,
                agentName = x.FirstOrDefault().agentName,
                cash = x.Sum(g => g.cash),

            });
            resultList = res.GroupBy(x => x.agentId).Select(x => new CashTransferSts
            {
                processType = x.FirstOrDefault().processType,
                cashTotal = x.Where(g => g.processType == "cash").Sum(g => (decimal)g.cash),
                cardTotal = x.Where(g => g.processType == "card").Sum(g => (decimal)g.cash),
                chequeTotal = x.Where(g => g.processType == "cheque").Sum(g => (decimal)g.cash),
                docTotal = x.Where(g => g.processType == "doc").Sum(g => (decimal)g.cash),
                balanceTotal = x.Where(g => g.processType == "balance").Sum(g => (decimal)g.cash),
                agentName = x.FirstOrDefault().agentName,
                agentId = x.FirstOrDefault().agentId,
            }
            ).ToList();

            var tempName = res.GroupBy(s => new { s.agentId }).Select(s => new
            {
                itemName = s.FirstOrDefault().agentName,
            });
            names.AddRange(tempName.Select(nn => nn.itemName));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> cash = new List<decimal>();
            List<decimal> card = new List<decimal>();
            List<decimal> doc = new List<decimal>();
            List<decimal> cheque = new List<decimal>();
            List<decimal> balance = new List<decimal>();


            for (int i = 0; i < resultList.Count(); i++)
            {
                cash.Add(resultList.ToList().Skip(i).FirstOrDefault().cashTotal);
                card.Add(resultList.ToList().Skip(i).FirstOrDefault().cardTotal);
                doc.Add(resultList.ToList().Skip(i).FirstOrDefault().docTotal);
                cheque.Add(resultList.ToList().Skip(i).FirstOrDefault().chequeTotal);
                balance.Add(resultList.ToList().Skip(i).FirstOrDefault().balanceTotal);

                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cash.AsChartValues(),
                DataLabels = true,
                Title = "Cash"
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = card.AsChartValues(),
                DataLabels = true,
                Title = "Card"
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = doc.AsChartValues(),
                DataLabels = true,
                Title = "Document"
            });
            columnChartData.Add(
         new StackedColumnSeries
         {
             Values = cheque.AsChartValues(),
             DataLabels = true,
             Title = "Cheque"
         });
            columnChartData.Add(
         new StackedColumnSeries
         {
             Values = balance.AsChartValues(),
             DataLabels = true,
             Title = "Balance"
         });

            DataContext = this;
            cartesianChart.Series = columnChartData;
        }

        private void fillRowChart()
        {
            int endYear = DateTime.Now.Year;
            int startYear = endYear - 1;
            int startMonth = DateTime.Now.Month;
            int endMonth = startMonth;
            if (dp_vendorStartDate.SelectedDate != null && dp_vendorEndDate.SelectedDate != null)
            {
                startYear = dp_vendorStartDate.SelectedDate.Value.Year;
                endYear = dp_vendorEndDate.SelectedDate.Value.Year;
                startMonth = dp_vendorStartDate.SelectedDate.Value.Month;
                endMonth = dp_vendorEndDate.SelectedDate.Value.Month;
            }


            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            List<CashTransferSts> resultList = new List<CashTransferSts>();

            var temp = fillList(payments, cb_vendors, cb_vendorPayType, cb_vendorAccountant, dp_vendorStartDate, dp_vendorEndDate).Where(x => x.side == "v"); ;
            if (selectedTab == 1)
            {
                temp = fillList(payments, cb_customer, cb_customerPayType, cb_customerAccountant, dp_customerStartDate, dp_customerEndDate).Where(x => x.side == "c"); ;
                if (dp_customerStartDate.SelectedDate != null && dp_customerEndDate.SelectedDate != null)
                {
                    startYear = dp_customerStartDate.SelectedDate.Value.Year;
                    endYear = dp_customerEndDate.SelectedDate.Value.Year;
                    startMonth = dp_customerStartDate.SelectedDate.Value.Month;
                    endMonth = dp_customerEndDate.SelectedDate.Value.Month;
                }
            }
            else if (selectedTab == 2)
            {
                temp = fillList(payments, cb_users, cb_userPayType, cb_userAccountant, dp_userStartDate, dp_userEndDate).Where(x => x.side == "u");
                if (dp_userStartDate.SelectedDate != null && dp_userEndDate.SelectedDate != null)
                {
                    startYear = dp_userStartDate.SelectedDate.Value.Year;
                    endYear = dp_userEndDate.SelectedDate.Value.Year;
                    startMonth = dp_userStartDate.SelectedDate.Value.Month;
                    endMonth = dp_userEndDate.SelectedDate.Value.Month;
                }
            }
            else if (selectedTab == 6)
            {
                temp = fillList(payments, cb_shipping, cb_shippingPayType, cb_shippingAccountant, dp_shippingStartDate, dp_shippingEndDate).Where(x => x.side == "sh");
                if (dp_shippingStartDate.SelectedDate != null && dp_shippingEndDate.SelectedDate != null)
                {
                    startYear = dp_shippingStartDate.SelectedDate.Value.Year;
                    endYear = dp_shippingEndDate.SelectedDate.Value.Year;
                    startMonth = dp_shippingStartDate.SelectedDate.Value.Month;
                    endMonth = dp_shippingEndDate.SelectedDate.Value.Month;
                }
            }


            SeriesCollection rowChartData = new SeriesCollection();
            var tempName = temp.GroupBy(s => new { s.agentId }).Select(s => new
            {
                itemName = s.FirstOrDefault().updateDate,
            });
            names.AddRange(tempName.Select(nn => nn.itemName.ToString()));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> cash = new List<decimal>();
            List<decimal> card = new List<decimal>();
            List<decimal> doc = new List<decimal>();
            List<decimal> cheque = new List<decimal>();
            List<decimal> balance = new List<decimal>();

            if (endYear - startYear <= 1)
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    for (int month = startMonth; month <= 12; month++)
                    {
                        var firstOfThisMonth = new DateTime(year, month, 1);
                        var firstOfNextMonth = firstOfThisMonth.AddMonths(1);
                        var drawCash = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "cash").Count();
                        var drawCard = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "card").Count();
                        var drawDoc = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "doc").Count();
                        var drawCheque = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "cheque").Count();
                        var drawBalance = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "balance").Count();
                        cash.Add(drawCash);
                        card.Add(drawCard);
                        doc.Add(drawDoc);
                        cheque.Add(drawCheque);
                        balance.Add(drawBalance);
                        MyAxis.Labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + "/" + year);

                        if (year == endYear && month == endMonth)
                        {
                            break;
                        }
                        if (month == 12)
                        {
                            startMonth = 1;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    var firstOfThisYear = new DateTime(year, 1, 1);
                    var firstOfNextMYear = firstOfThisYear.AddYears(1);
                    var drawCash = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.processType == "cash").Count();
                    var drawCard = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.processType == "card").Count();
                    var drawDoc = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.processType == "doc").Count();
                    var drawCheque = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.processType == "cheque").Count();
                    var drawBalance = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.processType == "balance").Count();
                    cash.Add(drawCash);
                    card.Add(drawCard);
                    doc.Add(drawDoc);
                    cheque.Add(drawCheque);
                    balance.Add(drawBalance);
                    MyAxis.Labels.Add(year.ToString());
                }
            }
            rowChartData.Add(
          new LineSeries
          {
              Values = cash.AsChartValues(),
              Title = "Cash"
          }); ;
            rowChartData.Add(
         new LineSeries
         {
             Values = card.AsChartValues(),
             Title = "Card"
         });
            rowChartData.Add(
        new LineSeries
        {
            Values = doc.AsChartValues(),
            Title = "Document"

        });
            rowChartData.Add(
            new LineSeries
            {
                Values = cheque.AsChartValues(),
                Title = "Cheque"

            });
            rowChartData.Add(
            new LineSeries
            {
                Values = balance.AsChartValues(),
                Title = "Balance"

            });
            DataContext = this;
            rowChart.Series = rowChartData;
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                txt_search.Text = "";
                if (selectedTab == 0)
                {
                    cb_vendors.SelectedItem = null;
                    cb_vendorPayType.SelectedItem = null;
                    cb_vendorAccountant.SelectedItem = null;
                    chk_allVendors.IsChecked = false;
                    chk_allVendorsAccountant.IsChecked = false;
                    chk_allVendorsPaymentType.IsChecked = false;
                    dp_vendorEndDate.SelectedDate = null;
                    dp_vendorStartDate.SelectedDate = null;
                    fillVendorsEvents();
                }
                else if (selectedTab == 1)
                {
                    cb_customer.SelectedItem = null;
                    cb_customerPayType.SelectedItem = null;
                    cb_customerAccountant.SelectedItem = null;
                    chk_allCustomers.IsChecked = false;
                    chk_allCustomersAccountant.IsChecked = false;
                    chk_allCustomersPaymentType.IsChecked = false;
                    dp_customerEndDate.SelectedDate = null;
                    dp_customerStartDate.SelectedDate = null;
                    fillCustomersEvents();
                }
                else if (selectedTab == 2)
                {
                    cb_users.SelectedItem = null;
                    cb_userPayType.SelectedItem = null;
                    cb_userAccountant.SelectedItem = null;
                    chk_allUsers.IsChecked = false;
                    chk_allUsersAccountant.IsChecked = false;
                    chk_allUsersPaymentType.IsChecked = false;
                    dp_userEndDate.SelectedDate = null;
                    dp_userStartDate.SelectedDate = null;
                    fillUserEvents();
                }
                else if (selectedTab == 3)
                {
                    cb_shipping.SelectedItem = null;
                    cb_shippingPayType.SelectedItem = null;
                    cb_shippingAccountant.SelectedItem = null;
                    chk_allShippings.IsChecked = false;
                    chk_allShippingsAccountant.IsChecked = false;
                    chk_allShippingsPaymentType.IsChecked = false;
                    dp_shippingEndDate.SelectedDate = null;
                    dp_shippingStartDate.SelectedDate = null;
                    fillShippingEvents();
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

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (selectedTab == 0)
                {
                    var temp = fillList(payments, cb_vendors, cb_vendorPayType, cb_vendorAccountant, dp_vendorStartDate, dp_vendorEndDate).Where(x => x.side == "v" || x.side == "b");
                    dgPayments.ItemsSource = temp.Where(obj => (
                    obj.transNum.Contains(txt_search.Text) ||
                    obj.processType.Contains(txt_search.Text) ||
                    obj.updateUserAcc.Contains(txt_search.Text) ||
                    obj.agentCompany.Contains(txt_search.Text) ||
                    obj.agentName.Contains(txt_search.Text)
                    ));
                }
                else if (selectedTab == 1)
                {
                    var temp = fillList(payments, cb_customer, cb_customerPayType, cb_customerAccountant, dp_customerStartDate, dp_customerEndDate).Where(x => x.side == "c" || x.side == "b");

                    dgPayments.ItemsSource = temp.Where(obj => (
                        obj.transNum.Contains(txt_search.Text) ||
                        obj.processType.Contains(txt_search.Text) ||
                        obj.updateUserAcc.Contains(txt_search.Text) ||
                        obj.agentCompany.Contains(txt_search.Text) ||
                        obj.agentName.Contains(txt_search.Text)
                        ));
                }
                else if (selectedTab == 2)
                {
                    var temp = fillList(payments, cb_users, cb_userPayType, cb_userAccountant, dp_userStartDate, dp_userEndDate).Where(x => x.side == "u");
                    dgPayments.ItemsSource = temp.Where(obj => (
                       obj.transNum.Contains(txt_search.Text) ||
                       obj.processType.Contains(txt_search.Text) ||
                       obj.updateUserAcc.Contains(txt_search.Text) ||
                       obj.userAcc.Contains(txt_search.Text)
                       ));
                }
                else if (selectedTab == 6)
                {
                    var temp = fillList(payments, cb_shipping, cb_shippingPayType, cb_shippingAccountant, dp_shippingStartDate, dp_shippingEndDate).Where(x => x.side == "sh");
                    dgPayments.ItemsSource = temp.Where(obj => (
                       obj.transNum.Contains(txt_search.Text) ||
                       obj.processType.Contains(txt_search.Text) ||
                       obj.updateUserAcc.Contains(txt_search.Text) ||
                       obj.shippingCompanyName.Contains(txt_search.Text)
                       ));
                }

                txt_count.Text = dgPayments.Items.Count.ToString();

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
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public void BuildReport()
        {

            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath = "";
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                if (selectedTab == 0)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\Ar\ArVendor.rdlc";
                }
                else if (selectedTab == 1)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\Ar\ArCustomer.rdlc";
                }
                else if (selectedTab == 2)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\Ar\ArUser.rdlc";
                }
                else if (selectedTab == 6)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\Ar\ArShipping.rdlc";
                }
            }
            else
            {
                if (selectedTab == 0)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\En\Vendor.rdlc";
                }
                else if (selectedTab == 1)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\En\Customer.rdlc";
                }
                else if (selectedTab == 2)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\En\User.rdlc";
                }
                else if (selectedTab == 6)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\En\Shipping.rdlc";
                }
            }
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.cashTransferStsRecipient(temp, rep, reppath,paramarr);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();
        }
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region

                BuildReport();
                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
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

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                BuildReport();
                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));

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

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//excel
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                Thread t1 = new Thread(() =>
            {
                BuildReport();
                this.Dispatcher.Invoke(() =>
                {
                    saveFileDialog.Filter = "EXCEL|*.xls;";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filepath = saveFileDialog.FileName;
                        LocalReportExtensions.ExportToExcel(rep, filepath);
                    }
                });


            });
                t1.Start();

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

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                Window.GetWindow(this).Opacity = 0.2;
                string pdfpath = "";



                pdfpath = @"\Thumb\report\temp.pdf";
                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                BuildReport();

                LocalReportExtensions.ExportToPDF(rep, pdfpath);
                wd_previewPdf w = new wd_previewPdf();
                w.pdfPath = pdfpath;
                if (!string.IsNullOrEmpty(w.pdfPath))
                {
                    w.ShowDialog();
                    w.wb_pdfWebViewer.Dispose();
                }
                Window.GetWindow(this).Opacity = 1;

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
    }
}

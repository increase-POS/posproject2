using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
using static POS.Classes.Statistics;

namespace POS.View.reports
{
    public partial class uc_paymentsReport : UserControl
    {
        Statistics statisticModel = new Statistics();
        List<CashTransferSts> payments;

        IEnumerable<VendorCombo> vendorCombo;
        IEnumerable<VendorCombo> customerCombo;
        IEnumerable<VendorCombo> userCombo;
        IEnumerable<VendorCombo> salaryCombo;
        IEnumerable<ShippingCombo> ShippingCombo;

        IEnumerable<PaymentsTypeCombo> payCombo;

        IEnumerable<AccountantCombo> accCombo;
        IEnumerable<AccountantCombo> accCustomerCombo;
        IEnumerable<AccountantCombo> accUserCombo;
        IEnumerable<AccountantCombo> accSalaryCombo;
        IEnumerable<AccountantCombo> accGeneralExpensesCombo;
        IEnumerable<AccountantCombo> accAdministrativePullCombo;
        IEnumerable<AccountantCombo> accShippingCombo;

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            payments = await statisticModel.GetPayments();

            vendorCombo = statisticModel.getVendorCombo(payments, "v");
            customerCombo = statisticModel.getVendorCombo(payments, "c");
            userCombo = statisticModel.getUserAcc(payments, "u");
            salaryCombo = statisticModel.getUserAcc(payments, "s");
            ShippingCombo = statisticModel.getShippingCombo(payments);

            payCombo = statisticModel.getPaymentsTypeCombo(payments);

            accCombo = statisticModel.getAccounantCombo(payments, "v");
            accCustomerCombo = statisticModel.getAccounantCombo(payments, "c");
            accUserCombo = statisticModel.getAccounantCombo(payments, "u");
            accSalaryCombo = statisticModel.getAccounantCombo(payments, "s");
            accGeneralExpensesCombo = statisticModel.getAccounantCombo(payments, "e");
            accAdministrativePullCombo = statisticModel.getAccounantCombo(payments, "m");
            accShippingCombo = statisticModel.getAccounantCombo(payments, "sh");

            fillVendorCombo(vendorCombo, cb_vendors);
            fillPaymentsTypeCombo(cb_vendorPayType);
            fillAccCombo(accCombo, cb_vendorAccountant);

            fillVendorsEvents();
            hideAllColumn();
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
            if (selectedTab == 3 || selectedTab == 2)
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
                result = payments.Where(x => (
             (vendor.SelectedItem != null ? x.shippingCompanyId == selectedItem5.ShippingId : true)
                       && (payType.SelectedItem != null ? x.processType == selectedItem2.PaymentsTypeName : true)
                       && (accountant.SelectedItem != null ? x.updateUserAcc == selectedItem3.Accountant : true)
                       && (startDate.SelectedDate != null ? x.updateDate >= startDate.SelectedDate : true)
                       && (endDate.SelectedDate != null ? x.updateDate <= endDate.SelectedDate : true)));
            }
            return result.ToList();
        }

        public uc_paymentsReport()
        {
            InitializeComponent();
        }

        private static uc_paymentsReport _instance;
        public static uc_paymentsReport Instance
        {
            get
            {
                if (_instance == null) _instance = new uc_paymentsReport();
                return _instance;
            }
        }

        /*Vendor*/
        /*********************************************************************************/
        private void Cb_vendors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillVendorsEvents();
        }

        private void Cb_vendorPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillVendorsEvents();
        }

        private void Cb_vendorAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillVendorsEvents();
        }

        private void Dp_vendorStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillVendorsEvents();
        }

        private void Dp_vendorEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillVendorsEvents();
        }

        private void Chk_allVendors_Checked(object sender, RoutedEventArgs e)
        {
            cb_vendors.SelectedItem = null;
            cb_vendors.IsEnabled = false;
        }

        private void Chk_allVendors_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_vendors.IsEnabled = true;
        }

        private void Chk_allVendorsPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            cb_vendorPayType.SelectedItem = null;
            cb_vendorPayType.IsEnabled = false;
        }

        private void Chk_allVendorsPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_vendorPayType.IsEnabled = true;
        }

        private void Chk_allVendorsAccountant_Checked(object sender, RoutedEventArgs e)
        {
            cb_vendorAccountant.SelectedItem = null;
            cb_vendorAccountant.IsEnabled = false;
        }

        private void Chk_allVendorsAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_vendorAccountant.IsEnabled = true;
        }
        /*Customer*/
        /*********************************************************************************/
        private void Cb_customerAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillCustomersEvents();
        }

        private void Cb_customerPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillCustomersEvents();
        }

        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillCustomersEvents();
        }

        private void Dp_customerStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillCustomersEvents();
        }

        private void Dp_customerEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillCustomersEvents();
        }

        private void Chk_allCustomers_Checked(object sender, RoutedEventArgs e)
        {
            cb_customer.IsEnabled = false;
            cb_customer.SelectedItem = null;
        }

        private void Chk_allCustomers_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_customer.IsEnabled = true;
        }

        private void Chk_allCustomersPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            cb_customerPayType.IsEnabled = false;
            cb_customerPayType.SelectedItem = null;
        }

        private void Chk_allCustomersPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_customerPayType.IsEnabled = true;
        }

        private void Chk_allCustomersAccountant_Checked(object sender, RoutedEventArgs e)
        {
            cb_customerAccountant.IsEnabled = false;
            cb_customerAccountant.SelectedItem = null;
        }

        private void Chk_allCustomersAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_customerAccountant.IsEnabled = true;
        }

        /*User*/
        /*********************************************************************************/
        private void Cb_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillUserEvents();
        }

        private void Cb_userPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillUserEvents();
        }

        private void Cb_userAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillUserEvents();
        }

        private void Dp_userEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillUserEvents();
        }

        private void Dp_userStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillUserEvents();
        }

        private void Chk_allUsers_Checked(object sender, RoutedEventArgs e)
        {
            cb_users.SelectedItem = null;
            cb_users.IsEnabled = false;
        }

        private void Chk_allUsers_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_users.IsEnabled = true;
        }

        private void Chk_allUsersPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            cb_userPayType.SelectedItem = null;
            cb_userPayType.IsEnabled = false;
        }

        private void Chk_allUsersPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_userPayType.IsEnabled = true;
        }

        private void Chk_allUsersAccountant_Checked(object sender, RoutedEventArgs e)
        {
            cb_userAccountant.SelectedItem = null;
            cb_userAccountant.IsEnabled = false;
        }

        private void Chk_allUsersAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_userAccountant.IsEnabled = true;
        }

        /*Salary*/
        /*********************************************************************************/
        private void Cb_salary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillSalaryEvents();
        }

        private void Cb_salaryPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillSalaryEvents();
        }

        private void Cb_salaryAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillSalaryEvents();
        }

        private void Dp_salaryStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillSalaryEvents();
        }

        private void Dp_salaryEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillSalaryEvents();
        }

        private void Chk_allSalaries_Checked(object sender, RoutedEventArgs e)
        {
            cb_salary.SelectedItem = null;
            cb_salary.IsEnabled = false;
        }

        private void Chk_allSalaries_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_salary.IsEnabled = true;
        }

        private void Chk_allSalariesPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            cb_salaryPayType.SelectedItem = null;
            cb_salaryPayType.IsEnabled = false;
        }

        private void Chk_allSalariesPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_salaryPayType.IsEnabled = true;
        }

        private void Chk_allSalariesAccountant_Checked(object sender, RoutedEventArgs e)
        {
            cb_salaryAccountant.SelectedItem = null;
            cb_salaryAccountant.IsEnabled = false;
        }

        private void Chk_allSalariesAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_salaryAccountant.IsEnabled = true;
        }
        /*General Expenses*/
        /*********************************************************************************/
        private void Cb_generalExpenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillGeneralExpensesEvents();
        }

        private void Cb_generalExpensesPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillGeneralExpensesEvents();
        }

        private void Cb_generalExpensesAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillGeneralExpensesEvents();
        }

        private void Dp_generalExpensesStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillGeneralExpensesEvents();
        }

        private void Dp_generalExpensesEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillGeneralExpensesEvents();
        }

        private void Chk_allGeneralExpensesPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            cb_generalExpensesPayType.IsEnabled = false;
            cb_generalExpensesPayType.SelectedItem = null;
        }

        private void Chk_allGeneralExpensesPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_generalExpensesPayType.IsEnabled = true;
        }

        private void Chk_allGeneralExpensesAccountant_Checked(object sender, RoutedEventArgs e)
        {
            cb_generalExpensesAccountant.IsEnabled = false;
            cb_generalExpensesAccountant.SelectedItem = null;
        }

        private void Chk_allGeneralExpensesAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_generalExpensesAccountant.IsEnabled = true;
        }

        /*Administrative Pull*/
        /*********************************************************************************/
        private void Cb_administrativePull_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillAdministrativePullEvents();
        }

        private void Cb_administrativePullPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillAdministrativePullEvents();
        }

        private void Cb_administrativePullAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillAdministrativePullEvents();
        }

        private void Dp_administrativePullStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillAdministrativePullEvents();
        }

        private void Dp_administrativePullEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillAdministrativePullEvents();
        }

        private void Chk_allAdministrativePullPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            cb_administrativePullPayType.IsEnabled = false;
            cb_administrativePullPayType.SelectedItem = null;
        }

        private void Chk_allAdministrativePullPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_administrativePullPayType.IsEnabled = true;
        }

        private void Chk_allAdministrativePullAccountant_Checked(object sender, RoutedEventArgs e)
        {
            cb_administrativePullAccountant.IsEnabled = false;
            cb_administrativePullAccountant.SelectedItem = null;
        }

        private void Chk_allAdministrativePullAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_administrativePullAccountant.IsEnabled = true;
        }
        /*Shipping*/
        /*********************************************************************************/
        private void Cb_shipping_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillShippingEvents();
        }

        private void Cb_shippingPayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillShippingEvents();
        }

        private void Cb_shippingAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillShippingEvents();
        }

        private void Dp_shippingStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillShippingEvents();
        }

        private void Dp_shippingEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillShippingEvents();
        }

        private void Chk_allShippings_Checked(object sender, RoutedEventArgs e)
        {
            cb_shipping.IsEnabled = false;
            cb_shipping.SelectedItem = null;
        }

        private void Chk_allShippings_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_shipping.IsEnabled = true;
        }

        private void Chk_allShippingsPaymentType_Checked(object sender, RoutedEventArgs e)
        {
            cb_shippingPayType.IsEnabled = false;
            cb_shippingPayType.SelectedItem = null;
        }

        private void Chk_allShippingsPaymentType_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_shippingPayType.IsEnabled = true;
        }

        private void Chk_allShippingsAccountant_Checked(object sender, RoutedEventArgs e)
        {
            cb_shippingAccountant.IsEnabled = false;
            cb_shippingAccountant.SelectedItem = null;
        }

        private void Chk_allShippingsAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_shippingAccountant.IsEnabled = true;
        }
        /*********************************************************************/

        int selectedTab = 0;

        public void paint()
        {
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            bdr_customer.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_vendor.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_user.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_salary.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_generalExpenses.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_administrativePull.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_shipping.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_customer.Fill = Brushes.White;
            path_vendor.Fill = Brushes.White;
            path_user.Fill = Brushes.White;
            path_salary.Fill = Brushes.White;
            path_generalExpenses.Fill = Brushes.White;
            path_administrativePull.Fill = Brushes.White;
            path_shipping.Fill = Brushes.White;

            grid_customer.Visibility = Visibility.Hidden;
            grid_vendor.Visibility = Visibility.Hidden;
            grid_user.Visibility = Visibility.Hidden;
            grid_generalExpenses.Visibility = Visibility.Hidden;
            grid_salary.Visibility = Visibility.Hidden;
            grid_administrativePull.Visibility = Visibility.Hidden;
            grid_shipping.Visibility = Visibility.Hidden;
        }

        private void isEnabledButtons()
        {
            btn_customer.IsEnabled = true;
            btn_vendor.IsEnabled = true;
            btn_user.IsEnabled = true;
            btn_salary.IsEnabled = true;
            btn_generalExpenses.IsEnabled = true;
            btn_administrativePull.IsEnabled = true;
            btn_shipping.IsEnabled = true;
        }

        private void hideAllColumn()
        {
            grid_vendor.Visibility = Visibility.Hidden;
            grid_customer.Visibility = Visibility.Hidden;
            grid_salary.Visibility = Visibility.Hidden;
            grid_generalExpenses.Visibility = Visibility.Hidden;
            grid_administrativePull.Visibility = Visibility.Hidden;
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
            else if (selectedTab == 3)
            {
                grid_salary.Visibility = Visibility.Visible;

                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;

                col_user.Visibility = Visibility.Visible;

                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 4)
            {
                grid_generalExpenses.Visibility = Visibility.Visible;

                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;


                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 5)
            {
                grid_administrativePull.Visibility = Visibility.Visible;

                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;


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
        }

        private void Btn_customer_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void Btn_user_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void Btn_salary_Click(object sender, RoutedEventArgs e)
        {
            selectedTab = 3;
            paint();
            bdr_salary.Background = Brushes.White;
            path_salary.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_salary.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_salary.IsEnabled = false;
            btn_salary.Opacity = 1;
            fillSalaryEvents();
            hideAllColumn();

            fillAccCombo(accSalaryCombo, cb_salaryAccountant);
            fillPaymentsTypeCombo(cb_salaryPayType);
            fillSalaryCombo(salaryCombo, cb_salary);
        }

        private void Btn_generalExpenses_Click(object sender, RoutedEventArgs e)
        {
            selectedTab = 4;
            paint();
            bdr_generalExpenses.Background = Brushes.White;
            path_generalExpenses.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_generalExpenses.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_generalExpenses.IsEnabled = false;
            btn_generalExpenses.Opacity = 1;
            fillGeneralExpensesEvents();
            hideAllColumn();
            fillAccCombo(accGeneralExpensesCombo, cb_generalExpensesAccountant);
            fillPaymentsTypeCombo(cb_generalExpensesPayType);
        }

        private void Btn_administrativePull_Click(object sender, RoutedEventArgs e)
        {
            selectedTab = 5;
            paint();
            bdr_administrativePull.Background = Brushes.White;
            path_administrativePull.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_administrativePull.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_administrativePull.IsEnabled = false;
            btn_administrativePull.Opacity = 1;
            fillAdministrativePullEvents();
            hideAllColumn();
            fillAccCombo(accAdministrativePullCombo, cb_administrativePullAccountant);
            fillPaymentsTypeCombo(cb_administrativePullPayType);
        }

        private void Btn_shipping_Click(object sender, RoutedEventArgs e)
        {
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
        }

        /*Fill Events*/
        /*********************************************************************************/

        private void fillVendorsEvents()
        {
            dgPayments.ItemsSource = fillList(payments, cb_vendors, cb_vendorPayType, cb_vendorAccountant, dp_vendorStartDate, dp_vendorEndDate).Where(x => x.side == "v" || x.side == "b");
            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }

        private void fillCustomersEvents()
        {
            dgPayments.ItemsSource = fillList(payments, cb_customer, cb_customerPayType, cb_customerAccountant, dp_customerStartDate, dp_customerEndDate).Where(x => x.side == "c" || x.side == "b");
            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }

        private void fillUserEvents()
        {
            dgPayments.ItemsSource = fillList(payments, cb_users, cb_userPayType, cb_userAccountant, dp_userStartDate, dp_userEndDate).Where(x => x.side == "u");
            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }

        private void fillSalaryEvents()
        {
            dgPayments.ItemsSource = fillList(payments, cb_salary, cb_salaryPayType, cb_salaryAccountant, dp_salaryStartDate, dp_salaryEndDate).Where(x => x.side == "s");
            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }

        private void fillGeneralExpensesEvents()
        {
            dgPayments.ItemsSource = fillList(payments, cb_generalExpenses, cb_generalExpensesPayType, cb_generalExpensesAccountant, dp_generalExpensesStartDate, dp_generalExpensesEndDate).Where(x => x.side == "e");
            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }

        private void fillAdministrativePullEvents()
        {
            dgPayments.ItemsSource = fillList(payments, cb_administrativePull, cb_administrativePullPayType, cb_administrativePullAccountant, dp_administrativePullStartDate, dp_administrativePullEndDate).Where(x => x.side == "m");
            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }

        private void fillShippingEvents()
        {
            dgPayments.ItemsSource = fillList(payments, cb_shipping, cb_shippingPayType, cb_shippingAccountant, dp_shippingStartDate, dp_shippingEndDate).Where(x => x.side == "sh");
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
            else if (selectedTab == 3)
            {
                temp = fillList(payments, cb_salary, cb_salaryPayType, cb_salaryAccountant, dp_salaryStartDate, dp_salaryEndDate).Where(x => x.side == "s");
            }
            else if (selectedTab == 4)
            {
                temp = fillList(payments, cb_generalExpenses, cb_generalExpensesPayType, cb_generalExpensesAccountant, dp_generalExpensesStartDate, dp_generalExpensesEndDate).Where(x => x.side == "e");
            }
            else if (selectedTab == 5)
            {
                temp = fillList(payments, cb_administrativePull, cb_administrativePullPayType, cb_administrativePullAccountant, dp_administrativePullStartDate, dp_administrativePullEndDate).Where(x => x.side == "m");
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
            else if (selectedTab == 3)
            {
                temp = fillList(payments, cb_salary, cb_salaryPayType, cb_salaryAccountant, dp_salaryStartDate, dp_salaryEndDate).Where(x => x.side == "s");
            }
            else if (selectedTab == 4)
            {
                temp = fillList(payments, cb_generalExpenses, cb_generalExpensesPayType, cb_generalExpensesAccountant, dp_generalExpensesStartDate, dp_generalExpensesEndDate).Where(x => x.side == "e");
            }
            else if (selectedTab == 5)
            {
                temp = fillList(payments, cb_administrativePull, cb_administrativePullPayType, cb_administrativePullAccountant, dp_administrativePullStartDate, dp_administrativePullEndDate).Where(x => x.side == "m");
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
                    startYear = dp_customerEndDate.SelectedDate.Value.Year;
                    endYear = dp_userEndDate.SelectedDate.Value.Year;
                    startMonth = dp_customerEndDate.SelectedDate.Value.Month;
                    endMonth = dp_userEndDate.SelectedDate.Value.Month;
                }
            }
            else if (selectedTab == 3)
            {
                temp = fillList(payments, cb_salary, cb_salaryPayType, cb_salaryAccountant, dp_salaryStartDate, dp_salaryEndDate).Where(x => x.side == "s");
                if (dp_salaryStartDate.SelectedDate != null && dp_salaryEndDate.SelectedDate != null)
                {
                    startYear = dp_salaryStartDate.SelectedDate.Value.Year;
                    endYear = dp_salaryEndDate.SelectedDate.Value.Year;
                    startMonth = dp_salaryStartDate.SelectedDate.Value.Month;
                    endMonth = dp_salaryEndDate.SelectedDate.Value.Month;
                }
            }
            else if (selectedTab == 4)
            {
                temp = fillList(payments, cb_generalExpenses, cb_generalExpensesPayType, cb_generalExpensesAccountant, dp_generalExpensesStartDate, dp_generalExpensesEndDate).Where(x => x.side == "e");
                if (dp_generalExpensesStartDate.SelectedDate != null && dp_generalExpensesEndDate.SelectedDate != null)
                {
                    startYear = dp_generalExpensesStartDate.SelectedDate.Value.Year;
                    endYear = dp_generalExpensesEndDate.SelectedDate.Value.Year;
                    startMonth = dp_generalExpensesStartDate.SelectedDate.Value.Month;
                    endMonth = dp_generalExpensesEndDate.SelectedDate.Value.Month;
                }
            }
            else if (selectedTab == 5)
            {
                temp = fillList(payments, cb_administrativePull, cb_administrativePullPayType, cb_administrativePullAccountant, dp_administrativePullStartDate, dp_administrativePullEndDate).Where(x => x.side == "m");
                if (dp_administrativePullStartDate.SelectedDate != null && dp_administrativePullEndDate.SelectedDate != null)
                {
                    startYear = dp_administrativePullStartDate.SelectedDate.Value.Year;
                    endYear = dp_administrativePullEndDate.SelectedDate.Value.Year;
                    startMonth = dp_administrativePullStartDate.SelectedDate.Value.Month;
                    endMonth = dp_administrativePullEndDate.SelectedDate.Value.Month;
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
            if (selectedTab == 0)
            {
                fillVendorsEvents();
            }
           else if (selectedTab == 1)
            {
                fillCustomersEvents();
            }
            else if (selectedTab == 2)
            {
                fillUserEvents();
            }
            else if (selectedTab == 3)
            {
                fillSalaryEvents();
            }
            else if (selectedTab == 4)
            {
                fillGeneralExpensesEvents();
            }
            else if (selectedTab == 5)
            {
                fillAdministrativePullEvents();
            }
            else if (selectedTab == 6)
            {
                fillShippingEvents();
            }
        }

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

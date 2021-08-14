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
    /// <summary>
    /// Interaction logic for uc_accountStatement.xaml
    /// </summary>
    public partial class uc_accountStatement : UserControl
    {
        public uc_accountStatement()
        {
            InitializeComponent();
        }
        Statistics statisticModel = new Statistics();

        List<CashTransferSts> statement;

        IEnumerable<VendorCombo> vendorCombo;
        IEnumerable<VendorCombo> customerCombo;
        IEnumerable<VendorCombo> userCombo;
        IEnumerable<ShippingCombo> ShippingCombo;


        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            statement = await statisticModel.GetStatement();

            vendorCombo = statisticModel.getVendorCombo(statement, "v").Where(x=>x.VendorId!=null);
            customerCombo = statisticModel.getVendorCombo(statement, "c");
            userCombo = statisticModel.getUserAcc(statement, "u");
            ShippingCombo = statisticModel.getShippingCombo(statement);


            fillVendorCombo(vendorCombo, cb_vendors);
            fillDateCombo(cb_vendorsDate);

            fillVendorsEvents();
            hideAllColumn();

        }

        private void fillVendorCombo(IEnumerable<VendorCombo> list, ComboBox cb)
        {
            cb.SelectedValuePath = "VendorId";
            cb.DisplayMemberPath = "VendorName";
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
        private void fillDateCombo(ComboBox cb)
        {
            cb.Items.Clear();
            if (statement.Count()>0)
            {
                int firstYear = statement.Min(obj => obj.updateDate.Value.Year);
                int presentYear = DateTime.Now.Year;
                for (int i = firstYear; i <= presentYear; i++)
                {
                    cb.Items.Add(firstYear);
                    firstYear++;
                }
            }
        

        }

        private List<CashTransferSts> fillList(List<CashTransferSts> payments, ComboBox vendor, ComboBox date)
        {
            var selectedItem1 = vendor.SelectedItem as VendorCombo;
            var selectedItem2 = vendor.SelectedItem as ShippingCombo;
            var selectedItem3 = date.SelectedItem;


            var result = payments.Where(x => (
              (vendor.SelectedItem != null ? x.agentId == selectedItem1.VendorId : false)
                   && (date.SelectedItem != null ? x.updateDate.Value.Year == (int)selectedItem3 : true)));

            if (selectedTab == 2)
            {
                result = payments.Where(x => (
             (vendor.SelectedItem != null ? x.userId == selectedItem1.UserId : false)
                      && (date.SelectedItem != null ? x.updateDate.Value.Year == (int)selectedItem3 : true)));
            }

            if (selectedTab == 6)
            {
                result = payments.Where(x => (
             (vendor.SelectedItem != null ? x.shippingCompanyId == selectedItem2.ShippingId : false)
                             && (date.SelectedItem != null ? x.updateDate.Value.Year == (int)selectedItem3 : true)));
            }
            return result.ToList();
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
            fillVendorsEvents();
        }

        private void Chk_allVendors_Checked(object sender, RoutedEventArgs e)
        {
            cb_vendorsDate.SelectedItem = null;
            cb_vendorsDate.IsEnabled = false;
        }

        private void Chk_allVendors_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_vendorsDate.IsEnabled = true;
        }


        /*Customer*/
        /*********************************************************************************/

        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillCustomersEvents();
        }

        private void Chk_allCustomers_Checked(object sender, RoutedEventArgs e)
        {
            cb_customerDate.IsEnabled = false;
            cb_customerDate.SelectedItem = null;
        }

        private void Chk_allCustomers_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_customerDate.IsEnabled = true;
        }

        /*User*/
        /*********************************************************************************/
        private void Cb_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillUserEvents();
        }

        private void Chk_allUsers_Checked(object sender, RoutedEventArgs e)
        {
            cb_userDate.SelectedItem = null;
            cb_userDate.IsEnabled = false;
        }

        private void Chk_allUsers_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_userDate.IsEnabled = true;
        }

        /*Shipping*/
        /*********************************************************************************/
        private void Cb_shipping_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillShippingEvents();
        }

        private void Chk_allShippings_Checked(object sender, RoutedEventArgs e)
        {
            cb_shippingDate.IsEnabled = false;
            cb_shippingDate.SelectedItem = null;
        }

        private void Chk_allShippings_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_shippingDate.IsEnabled = true;
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

            col_date.Visibility = Visibility.Hidden;

            col_transType.Visibility = Visibility.Hidden;
            col_amount.Visibility = Visibility.Hidden;
            col_total.Visibility = Visibility.Hidden;

            col_proccesType.Visibility = Visibility.Hidden;
            col_invNum.Visibility = Visibility.Hidden;
            col_invType.Visibility = Visibility.Hidden;

            if (selectedTab == 0)
            {
                grid_vendor.Visibility = Visibility.Visible;

                col_date.Visibility = Visibility.Visible;


                col_transType.Visibility = Visibility.Visible;
                col_amount.Visibility = Visibility.Visible;
                col_total.Visibility = Visibility.Visible;

                col_proccesType.Visibility = Visibility.Visible;
                col_invNum.Visibility = Visibility.Visible;
                col_invType.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 1)
            {
                grid_customer.Visibility = Visibility.Visible;

                col_date.Visibility = Visibility.Visible;


                col_transType.Visibility = Visibility.Visible;
                col_amount.Visibility = Visibility.Visible;
                col_total.Visibility = Visibility.Visible;

                col_proccesType.Visibility = Visibility.Visible;
                col_invNum.Visibility = Visibility.Visible;
                col_invType.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 2)
            {
                grid_user.Visibility = Visibility.Visible;

                col_date.Visibility = Visibility.Visible;


                col_transType.Visibility = Visibility.Visible;
                col_amount.Visibility = Visibility.Visible;
                col_total.Visibility = Visibility.Visible;

                col_proccesType.Visibility = Visibility.Visible;
                col_invNum.Visibility = Visibility.Visible;
                col_invType.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 6)
            {
                grid_shipping.Visibility = Visibility.Visible;

                col_date.Visibility = Visibility.Visible;


                col_transType.Visibility = Visibility.Visible;
                col_amount.Visibility = Visibility.Visible;
                col_total.Visibility = Visibility.Visible;

                col_proccesType.Visibility = Visibility.Visible;
                col_invNum.Visibility = Visibility.Visible;
                col_invType.Visibility = Visibility.Visible;
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

            fillDateCombo(cb_vendorsDate);
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

            fillDateCombo(cb_customerDate);
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

            fillDateCombo(cb_userDate);
            fillSalaryCombo(userCombo, cb_users);
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

            fillDateCombo(cb_shippingDate);
            fillShippingCombo(ShippingCombo, cb_shipping);
        }

        /*Fill Events*/
        /*********************************************************************************/
        IEnumerable<CashTransferSts> temp = null;
        private void fillVendorsEvents()
        {
            temp = statisticModel.getstate(fillList(statement, cb_vendors, cb_vendorsDate));
            dgPayments.ItemsSource = temp;
            decimal cashTotal = temp.Select(x=>x.cashTotal).LastOrDefault();
            if (cashTotal>0)
            {
                txt_total.Text = cashTotal.ToString();
                txt_for.Text = "Worthy";
                tb_moneyIcon.Text = MainWindow.Currency;
            }
            else
            {
                cashTotal = -cashTotal;
                txt_total.Text = cashTotal.ToString();
                txt_for.Text = "Required";
                tb_moneyIcon.Text = MainWindow.Currency;
            }

        }

        private void fillCustomersEvents()
        {
            temp = statisticModel.getstate(fillList(statement, cb_customer, cb_customerDate));
            dgPayments.ItemsSource = temp;
            decimal cashTotal = temp.Select(x => x.cashTotal).LastOrDefault();
            if (cashTotal > 0)
            {
                txt_total.Text = cashTotal.ToString();
                txt_for.Text = "Worthy";
            }
            else
            {
                cashTotal = -cashTotal;
                txt_total.Text = cashTotal.ToString();
                txt_for.Text = "Required";
            }
        }

        private void fillUserEvents()
        {
            temp = statisticModel.getstate(fillList(statement, cb_users, cb_userDate));
            dgPayments.ItemsSource = temp;
            decimal cashTotal = temp.Select(x => x.cashTotal).LastOrDefault();
            if (cashTotal > 0)
            {
                txt_total.Text = cashTotal.ToString();
                txt_for.Text = "Worthy";
            }
            else
            {
                cashTotal = -cashTotal;
                txt_total.Text = cashTotal.ToString();
                txt_for.Text = "Required";
            }
        }

        private void fillShippingEvents()
        {
            temp = statisticModel.getstate(fillList(statement, cb_shipping, cb_shippingDate));
            dgPayments.ItemsSource = temp;
            decimal cashTotal = temp.Select(x => x.cashTotal).LastOrDefault();
            if (cashTotal > 0)
            {
                txt_total.Text = cashTotal.ToString();
                txt_for.Text = "Worthy";
            }
            else
            {
                cashTotal = -cashTotal;
                txt_total.Text = cashTotal.ToString();
                txt_for.Text = "Required";
            }
        }


        /*Charts*/
        /*********************************************************************************/


    }
}
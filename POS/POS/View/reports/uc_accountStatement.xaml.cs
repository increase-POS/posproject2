using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using static POS.Classes.Statistics;

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for uc_accountStatement.xaml
    /// </summary>
    public partial class uc_accountStatement : UserControl
    {
        public uc_accountStatement()
        {try
				{
            InitializeComponent();
			}
        catch (Exception ex)
            {
				SectionData.ExceptionMessage(ex,this );
            } }
        Statistics statisticModel = new Statistics();

        List<CashTransferSts> statement;

        IEnumerable<VendorCombo> vendorCombo;
        IEnumerable<VendorCombo> customerCombo;
        IEnumerable<VendorCombo> userCombo;
        IEnumerable<ShippingCombo> ShippingCombo;


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

            statement = await statisticModel.GetStatement();

            vendorCombo = statisticModel.getVendorCombo(statement, "v").Where(x => x.VendorId != null);
            customerCombo = statisticModel.getVendorCombo(statement, "c");
            userCombo = statisticModel.getUserAcc(statement, "u");
            ShippingCombo = statisticModel.getShippingCombo(statement);


            fillVendorCombo(vendorCombo, cb_vendors);
            fillDateCombo(cb_vendorsDate);

            fillVendorsEvents();
            hideAllColumn();

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
            tt_vendor.Content = MainWindow.resourcemanager.GetString("trVendor");
            tt_customer.Content = MainWindow.resourcemanager.GetString("trCustomer");
            tt_user.Content = MainWindow.resourcemanager.GetString("trUser");
            tt_shipping.Content = MainWindow.resourcemanager.GetString("trShippingCompany");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendors, MainWindow.resourcemanager.GetString("trVendorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendorsDate, MainWindow.resourcemanager.GetString("trDateHint"));
            chk_allVendors.Content = MainWindow.resourcemanager.GetString("trAll");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trCustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customerDate, MainWindow.resourcemanager.GetString("trDateHint"));
            chk_allCustomers.Content = MainWindow.resourcemanager.GetString("trAll");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_users, MainWindow.resourcemanager.GetString("trUserHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_userDate, MainWindow.resourcemanager.GetString("trDateHint"));
            chk_allUsers.Content = MainWindow.resourcemanager.GetString("trAll");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_shipping, MainWindow.resourcemanager.GetString("trShippingCompanyHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_shippingDate, MainWindow.resourcemanager.GetString("trDateHint"));
            chk_allShippings.Content = MainWindow.resourcemanager.GetString("trAll");

            dgPayments.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dgPayments.Columns[1].Header = MainWindow.resourcemanager.GetString("trDate");
            dgPayments.Columns[2].Header = MainWindow.resourcemanager.GetString("trDescription");
            dgPayments.Columns[3].Header = MainWindow.resourcemanager.GetString("trPayment");
            dgPayments.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");

            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_settings.Content = MainWindow.resourcemanager.GetString("trSettings");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
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
            if (statement.Count() > 0)
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
					  
            cb_vendorsDate.SelectedItem = null;
            cb_vendorsDate.IsEnabled = false;
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
					    cb_vendorsDate.IsEnabled = true;
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

        private void Chk_allCustomers_Checked(object sender, RoutedEventArgs e)
        {
          
					try
					{
						if (sender != null)
					  SectionData.StartAwait(grid_main);
					    cb_customerDate.IsEnabled = false;
            cb_customerDate.SelectedItem = null;
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
					     cb_customerDate.IsEnabled = true;
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

        private void Chk_allUsers_Checked(object sender, RoutedEventArgs e)
        {
            
					try
					{
						if (sender != null)
					  SectionData.StartAwait(grid_main);
					  cb_userDate.SelectedItem = null;
            cb_userDate.IsEnabled = false;
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
					  
            cb_userDate.IsEnabled = true;
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

        private void Chk_allShippings_Checked(object sender, RoutedEventArgs e)
        {
					try
					{
						if (sender != null)
					  SectionData.StartAwait(grid_main);
					  
            cb_shippingDate.IsEnabled = false;
            cb_shippingDate.SelectedItem = null;
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
					  
            cb_shippingDate.IsEnabled = true;
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

            col_date.Visibility = Visibility.Hidden;

            col_amount.Visibility = Visibility.Hidden;

            col_proccesType.Visibility = Visibility.Hidden;

            if (selectedTab == 0)
            {
                grid_vendor.Visibility = Visibility.Visible;

                col_date.Visibility = Visibility.Visible;


                col_amount.Visibility = Visibility.Visible;

                col_proccesType.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 1)
            {
                grid_customer.Visibility = Visibility.Visible;

                col_date.Visibility = Visibility.Visible;


                col_amount.Visibility = Visibility.Visible;

                col_proccesType.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 2)
            {
                grid_user.Visibility = Visibility.Visible;

                col_date.Visibility = Visibility.Visible;


                col_amount.Visibility = Visibility.Visible;

                col_proccesType.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 6)
            {
                grid_shipping.Visibility = Visibility.Visible;

                col_date.Visibility = Visibility.Visible;


                col_amount.Visibility = Visibility.Visible;

                col_proccesType.Visibility = Visibility.Visible;
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

            fillDateCombo(cb_vendorsDate);
            fillVendorCombo(vendorCombo, cb_vendors);
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

            fillDateCombo(cb_customerDate);
            fillVendorCombo(customerCombo, cb_customer);
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

            fillDateCombo(cb_userDate);
            fillSalaryCombo(userCombo, cb_users);
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

        private void Btn_shipping_Click(object sender, RoutedEventArgs e)
        {
         
					try
					{
						if (sender != null)
					  SectionData.StartAwait(grid_main);
					     cb_vendors.SelectedItem = null;
            selectedTab = 6;
            paint();
            bdr_shipping.Background = Brushes.White;
            path_shipping.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_shipping.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_shipping.IsEnabled = false;
            btn_shipping.Opacity = 1;

            hideAllColumn();

            fillDateCombo(cb_shippingDate);
            fillShippingCombo(ShippingCombo, cb_shipping);
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

        /*Fill Events*/
        /*********************************************************************************/
        IEnumerable<CashTransferSts> temp = null;
        private void fillVendorsEvents()
        {
            temp = statisticModel.getstate(fillList(statement, cb_vendors, cb_vendorsDate));
            dgPayments.ItemsSource = temp;
            decimal cashTotal = temp.Select(x => x.cashTotal).LastOrDefault();
            if (cashTotal > 0)
            {
                txt_total.Text = cashTotal.ToString();
                //txt_for.Text = "Worthy";
                txt_for.Text = MainWindow.resourcemanager.GetString("trWorthy");
                tb_moneyIcon.Text = MainWindow.Currency;

                bdr_email.Visibility = Visibility.Collapsed;
            }
            else
            {
                cashTotal = -cashTotal;
                txt_total.Text = cashTotal.ToString();
                //txt_for.Text = "Required";
                txt_for.Text = MainWindow.resourcemanager.GetString("trRequired");
                tb_moneyIcon.Text = MainWindow.Currency;
                if (cb_vendors.SelectedItem != null)
                {
                    bdr_email.Visibility = Visibility.Visible;
                }
                else
                {
                    bdr_email.Visibility = Visibility.Collapsed;
                }
            }
            fillRowChart();
            fillColumnChart();
            fillPieChart();
        }

        private void fillCustomersEvents()
        {
            temp = statisticModel.getstate(fillList(statement, cb_customer, cb_customerDate));
            dgPayments.ItemsSource = temp;
            decimal cashTotal = temp.Select(x => x.cashTotal).LastOrDefault();
            if (cashTotal > 0)
            {
                txt_total.Text = cashTotal.ToString();
                //txt_for.Text = "Worthy";
                txt_for.Text = MainWindow.resourcemanager.GetString("trWorthy");
                bdr_email.Visibility = Visibility.Collapsed;
            }
            else
            {
                cashTotal = -cashTotal;
                txt_total.Text = cashTotal.ToString();
                //txt_for.Text = "Required";
                txt_for.Text = MainWindow.resourcemanager.GetString("trRequired");
                bdr_email.Visibility = Visibility.Visible;
                if (cb_customer.SelectedItem != null)
                {
                    bdr_email.Visibility = Visibility.Visible;
                }
                else
                {
                    bdr_email.Visibility = Visibility.Collapsed;
                }
            }
            fillRowChart();
            fillColumnChart();
            fillPieChart();
        }

        private void fillUserEvents()
        {
            temp = statisticModel.getstate(fillList(statement, cb_users, cb_userDate));
            dgPayments.ItemsSource = temp;
            decimal cashTotal = temp.Select(x => x.cashTotal).LastOrDefault();
            if (cashTotal > 0)
            {
                txt_total.Text = cashTotal.ToString();
                //txt_for.Text = "Worthy";
                txt_for.Text = MainWindow.resourcemanager.GetString("trWorthy");
                bdr_email.Visibility = Visibility.Collapsed;
            }
            else
            {
                cashTotal = -cashTotal;
                txt_total.Text = cashTotal.ToString();
                //txt_for.Text = "Required";
                txt_for.Text = MainWindow.resourcemanager.GetString("trRequired");
                bdr_email.Visibility = Visibility.Visible;
                if (cb_users.SelectedItem != null)
                {
                    bdr_email.Visibility = Visibility.Visible;
                }
                else
                {
                    bdr_email.Visibility = Visibility.Collapsed;
                }
            }
            fillRowChart();
            fillColumnChart();
            fillPieChart();


        }

        private void fillShippingEvents()
        {
            temp = statisticModel.getstate(fillList(statement, cb_shipping, cb_shippingDate));
            dgPayments.ItemsSource = temp;
            decimal cashTotal = temp.Select(x => x.cashTotal).LastOrDefault();
            if (cashTotal > 0)
            {
                txt_total.Text = cashTotal.ToString();
                //txt_for.Text = "Worthy";
                txt_for.Text = MainWindow.resourcemanager.GetString("trWorthy");
                bdr_email.Visibility = Visibility.Collapsed;
            }
            else
            {
                cashTotal = -cashTotal;
                txt_total.Text = cashTotal.ToString();
                //txt_for.Text = "Required";
                txt_for.Text = MainWindow.resourcemanager.GetString("trRequired");
                bdr_email.Visibility = Visibility.Visible;
                if (cb_shipping.SelectedItem != null)
                {
                    bdr_email.Visibility = Visibility.Visible;
                }
                else
                {
                    bdr_email.Visibility = Visibility.Collapsed;
                }
            }
            fillRowChart();
            fillColumnChart();
            fillPieChart();
        }


        /*Charts*/
        /*********************************************************************************/
        private void fillRowChart()
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>(12);
            List<CashTransferSts> resultList = new List<CashTransferSts>();
            int year = DateTime.Now.Year;
            if (cb_vendorsDate.SelectedItem != null)
            {
                year = (int)cb_vendorsDate.SelectedItem;
            }

            var temp = statisticModel.getstate(fillList(statement, cb_vendors, cb_vendorsDate));
            if (selectedTab == 1)
            {
                temp = statisticModel.getstate(fillList(statement, cb_customer, cb_customerDate));
            }
            else if (selectedTab == 2)
            {
                temp = statisticModel.getstate(fillList(statement, cb_users, cb_userDate));
            }
            else if (selectedTab == 6)
            {
                temp = statisticModel.getstate(fillList(statement, cb_shipping, cb_shippingDate));
            }

            SeriesCollection rowChartData = new SeriesCollection();


            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> cash = new List<decimal>();

            LineSeries l = new LineSeries();
            for (int month = 1; month <= 12; month++)
            {
                var firstOfThisMonth = new DateTime(year, month, 1);
                var firstOfNextMonth = firstOfThisMonth.AddMonths(1);
                var drawCash = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth).Select(x => x.cashTotal).LastOrDefault();
                if (drawCash > 0)
                {
                    //names.Add("Worthy");
                    names.Add(MainWindow.resourcemanager.GetString("trWorthy"));
                    btn_emailMessage.Visibility = Visibility.Collapsed;
                }
                else
                {
                    //names.Add("Required");
                    names.Add(MainWindow.resourcemanager.GetString("trRequired"));
                    btn_emailMessage.Visibility = Visibility.Visible;
                }
                cash.Add(drawCash);


                MyAxis.Labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + "/" + 2021);
            }
            l.Values = cash.AsChartValues();
            rowChartData.Add(l);

            DataContext = this;
            rowChart.Series = rowChartData;
        }

        private void fillColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            List<CashTransferSts> resultList = new List<CashTransferSts>();

            var temp = statisticModel.getstate(fillList(statement, cb_vendors, cb_vendorsDate));
            if (selectedTab == 1)
            {
                temp = statisticModel.getstate(fillList(statement, cb_customer, cb_customerDate));
            }
            else if (selectedTab == 2)
            {
                temp = statisticModel.getstate(fillList(statement, cb_users, cb_userDate));
            }
            else if (selectedTab == 6)
            {
                temp = statisticModel.getstate(fillList(statement, cb_shipping, cb_shippingDate));
            }


            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cash = new List<int>();
            List<int> card = new List<int>();
            List<int> doc = new List<int>();
            List<int> cheque = new List<int>();
            List<int> balance = new List<int>();
            List<int> inv = new List<int>();


            cash.Add(temp.Where(x => x.processType == "cash").Count());
            card.Add(temp.Where(x => x.processType == "card").Count());
            doc.Add(temp.Where(x => x.processType == "doc").Count());
            cheque.Add(temp.Where(x => x.processType == "cheque").Count());
            balance.Add(temp.Where(x => x.processType == "balance").Count());
            inv.Add(temp.Where(x => x.processType == "inv").Count());


            columnChartData.Add(
            new ColumnSeries
            {
                Values = cash.AsChartValues(),
                DataLabels = true,
                //Title = "Cash"
                Title = MainWindow.resourcemanager.GetString("trCash")
            });
            columnChartData.Add(
           new ColumnSeries
           {
               Values = card.AsChartValues(),
               DataLabels = true,
               //Title = "Card"
               Title = MainWindow.resourcemanager.GetString("tr_Card")
           });
            columnChartData.Add(
           new ColumnSeries
           {
               Values = doc.AsChartValues(),
               DataLabels = true,
               //Title = "Document"
               Title = MainWindow.resourcemanager.GetString("trDocument")

           });
            columnChartData.Add(
           new ColumnSeries
           {
               Values = cheque.AsChartValues(),
               DataLabels = true,
               //Title = "Cheque"
               Title = MainWindow.resourcemanager.GetString("trCheque")
           });
            columnChartData.Add(
           new ColumnSeries
           {
               Values = balance.AsChartValues(),
               DataLabels = true,
               //Title = "Balance"
               Title = MainWindow.resourcemanager.GetString("tr_Balance")
           });

            DataContext = this;
            cartesianChart.Series = columnChartData;
        }

        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            List<int> resultList = new List<int>();
            titles.Clear();
            var temp = statisticModel.getstate(fillList(statement, cb_vendors, cb_vendorsDate));
            if (selectedTab == 1)
            {
                temp = statisticModel.getstate(fillList(statement, cb_customer, cb_customerDate));
            }
            else if (selectedTab == 2)
            {
                temp = statisticModel.getstate(fillList(statement, cb_users, cb_userDate));
            }
            else if (selectedTab == 6)
            {
                temp = statisticModel.getstate(fillList(statement, cb_shipping, cb_shippingDate));
            }

            resultList.Add(temp.Where(x => x.processType != "inv" && x.transType == "p").Count());
            resultList.Add(temp.Where(x => x.processType != "inv" && x.transType == "d").Count());
            resultList.Add(temp.Where(x => x.processType == "inv").Count());
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < resultList.Count(); i++)
            {
                List<int> final = new List<int>();
                List<string> lable = new List<string>()
                {
                    //"Payment",
                    MainWindow.resourcemanager.GetString("trOnePayment"),
                    //"Deposite",
                    MainWindow.resourcemanager.GetString("trOneDeposit"),
                    //"Invoice"
                    MainWindow.resourcemanager.GetString("tr_Invoice")
                };
                final.Add(resultList.Skip(i).FirstOrDefault());
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
                cb_vendorsDate.SelectedItem = null;
                chk_allVendors.IsChecked = false;
                fillVendorsEvents();
            }
            else if (selectedTab == 1)
            {
                cb_customer.SelectedItem = null;
                cb_customerDate.SelectedItem = null;
                chk_allCustomers.IsChecked = false;
                fillCustomersEvents();
            }
            else if (selectedTab == 2)
            {
                cb_users.SelectedItem = null;
                cb_userDate.SelectedItem = null;
                chk_allUsers.IsChecked = false;
                fillUserEvents();
            }
            else if (selectedTab == 3)
            {
                cb_shipping.SelectedItem = null;
                cb_shippingDate.SelectedItem = null;
                chk_allShippings.IsChecked = false;
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
                temp = statisticModel.getstate(fillList(statement, cb_vendors, cb_vendorsDate));
                dgPayments.ItemsSource = temp.Where(obj => obj.transNum.Contains(txt_search.Text) ||
                obj.Description.Contains(txt_search.Text) ||
                obj.Description1.Contains(txt_search.Text));
            }
            else if (selectedTab == 1)
            {
                temp = statisticModel.getstate(fillList(statement, cb_customer, cb_customerDate));
                dgPayments.ItemsSource = temp.Where(obj => obj.transNum.Contains(txt_search.Text) ||
                obj.Description.Contains(txt_search.Text) ||
                obj.Description1.Contains(txt_search.Text));
            }
            else if (selectedTab == 2)
            {
                temp = statisticModel.getstate(fillList(statement, cb_users, cb_userDate));
                dgPayments.ItemsSource = temp.Where(obj => obj.transNum.Contains(txt_search.Text) ||
                obj.Description.Contains(txt_search.Text) ||
                obj.Description1.Contains(txt_search.Text));
            }
            else if (selectedTab == 3)
            {
                temp = statisticModel.getstate(fillList(statement, cb_shipping, cb_shippingDate));
                dgPayments.ItemsSource = temp.Where(obj => obj.transNum.Contains(txt_search.Text) ||
                obj.Description.Contains(txt_search.Text) ||
                obj.Description1.Contains(txt_search.Text));
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

        private async void Btn_emailMessage_Click(object sender, RoutedEventArgs e)
        {
           
					try
					{
						if (sender != null)
					  SectionData.StartAwait(grid_main);
					   if (txt_for.Text == "Required")
            {
                // btn_emailMessage.Visibility = Visibility.Visible;

                string total = txt_total.Text;
                SysEmails email = new SysEmails();
                EmailClass mailtosend = new EmailClass();
                // email = await email.GetByBranchIdandSide((int)MainWindow.branchID, "mg");
                Agent toAgent = new Agent();
                User toUser = new User();
                ShippingCompanies toShipCompanies = new ShippingCompanies();
                string emailto = "";
                bool toemailexist = false;
                email = await email.GetByBranchIdandSide((int)MainWindow.branchID, "mg");
                switch (selectedTab)
                {
                    case 0:
                        //vendor
                        var objct0 = cb_vendors.SelectedItem as VendorCombo;

                        int agentId = (int)objct0.VendorId;
                        toAgent = await toAgent.getAgentById(agentId);
                        emailto = toAgent.email;

                        if (emailto is null || emailto == "")
                        {
                            toemailexist = false;

                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTheVendorHasNoEmail"), animation: ToasterAnimation.FadeIn);
                        }
                        else
                        {
                            toemailexist = true;
                        }


                        break;

                    case 1:
                        var objct1 = cb_customer.SelectedItem as VendorCombo;
                        agentId = (int)objct1.VendorId;
                        toAgent = await toAgent.getAgentById(agentId);
                        emailto = toAgent.email;

                        if (emailto is null || emailto == "")
                        {
                            toemailexist = false;
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTheCustomerHasNoEmail"), animation: ToasterAnimation.FadeIn);
                        }
                        else
                        {
                            toemailexist = true;
                        }
                        break;
                    case 2:
                        var objct2 = cb_users.SelectedItem as VendorCombo;
                        int userId = (int)objct2.UserId;
                        toUser = await toUser.getUserById(userId);
                        emailto = toUser.email;

                        if (emailto is null || emailto == "")
                        {
                            toemailexist = false;
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTheUserHasNoEmail"), animation: ToasterAnimation.FadeIn);
                        }
                        else
                        {
                            toemailexist = true;
                        }
                        break;
                    case 6:
                        var objct3 = cb_shipping.SelectedItem as ShippingCombo;
                        int shipId = (int)objct3.ShippingId;

                        toShipCompanies = await toShipCompanies.GetByID(shipId);
                        emailto = toShipCompanies.email;

                        if (emailto is null || emailto == "")
                        {
                            toemailexist = false;
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTheShippingCompaniesHasNoEmail"), animation: ToasterAnimation.FadeIn);
                        }
                        else
                        {
                            toemailexist = true;
                        }

                        break;

                }



                if (email != null)
                {


                    //  int? itemcount = invoiceItems.Count();
                    if (email.emailId == 0)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoEmailForThisDept"), animation: ToasterAnimation.FadeIn);

                    }
                    else
                    {

                        if (toemailexist)
                        {

                            SetValues setvmodel = new SetValues();


                            List<SetValues> setvlist = new List<SetValues>();

                            setvlist = await setvmodel.GetBySetName("required_email_temp");

                            mailtosend = mailtosend.fillRequirdTempData(total, emailto, email, setvlist);
                            //   string pdfpath = await SaveSalepdf();
                            //  mailtosend.AddAttachTolist(pdfpath);
                            string msg = "";
                            msg = mailtosend.Sendmail();// temp comment
                            if (msg == "Failure sending mail.")
                            {

                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoInternetConnection"), animation: ToasterAnimation.FadeIn);
                            }
                            else if (msg == "mailsent")
                            {
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailSent"), animation: ToasterAnimation.FadeIn);

                            }
                            else
                            {
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailNotSent"), animation: ToasterAnimation.FadeIn);

                            }


                        }
                    }
                }
            }
            else
            {
                // btn_emailMessage.Visibility = Visibility.Hidden;
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

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
﻿using LiveCharts;
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

        IEnumerable<PaymentsTypeCombo> payCombo;

        IEnumerable<AccountantCombo> accCombo;

        int selectedTab = 0;

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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
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

                Btn_vendor_Click(btn_vendor , null);

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
            cb.DisplayMemberPath = "PaymentsTypeText";
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
        List<CashTransferSts> recLst;
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
            else if (selectedTab == 3)
            {
                if(selectedItem5 != null)
                    result = payments.Where(x => (
                 (vendor.SelectedItem != null ? x.shippingCompanyId == selectedItem5.ShippingId : true)
                           && (payType.SelectedItem != null    ? x.processType == selectedItem2.PaymentsTypeName : true)
                           && (accountant.SelectedItem != null ? x.updateUserAcc == selectedItem3.Accountant : true)
                           && (startDate.SelectedDate != null  ? x.updateDate >= startDate.SelectedDate : true)
                           && (endDate.SelectedDate != null    ? x.updateDate <= endDate.SelectedDate : true)));
            }
            recLst = result.ToList();
            return result.ToList();
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
        
        /*********************************************************************/


        public void paint()
        {
            //bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            bdr_customer.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_vendor.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_user.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_shipping.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_customer.Fill = Brushes.White;
            path_vendor.Fill = Brushes.White;
            path_user.Fill = Brushes.White;
            path_shipping.Fill = Brushes.White;

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

          
        }

        private void Btn_vendor_Click(object sender, RoutedEventArgs e)
        {//vendors
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendors, MainWindow.resourcemanager.GetString("trVendorHint"));
                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                hideAllColumn();
                selectedTab = 0;
                //view columns
                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;
                col_agentName.Visibility = Visibility.Visible;
                col_company.Visibility = Visibility.Visible;
                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;

                txt_search.Text = "";

                paint();
                bdr_vendor.Background = Brushes.White;
                path_vendor.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                isEnabledButtons();
                btn_vendor.IsEnabled = false;
                btn_vendor.Opacity = 1;

                cb_vendors.Visibility = Visibility.Visible;
                cb_vendors.SelectedItem = null;
                chk_allVendors.Visibility = Visibility.Visible;

                vendorCombo = statisticModel.getVendorCombo(payments, "v");
                fillVendorCombo(vendorCombo, cb_vendors);

                payCombo = statisticModel.getPaymentsTypeComboBySide(payments, "v");
                fillPaymentsTypeCombo(cb_vendorPayType);

                accCombo = statisticModel.getAccounantCombo(payments, "v");
                fillAccCombo(accCombo, cb_vendorAccountant);

                fillEvents("v");

                chk_allVendorsPaymentType.IsChecked = true;
                chk_allVendors.IsChecked = true;
                chk_allVendorsAccountant.IsChecked = true;

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
        {//customers
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendors, MainWindow.resourcemanager.GetString("trCustomerHint"));
                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                hideAllColumn();
                selectedTab = 1;
                //view columns
                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;
                col_customer.Visibility = Visibility.Visible;
                col_company.Visibility = Visibility.Visible;
                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;

                txt_search.Text = "";

                paint();
                bdr_customer.Background = Brushes.White;
                path_customer.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                isEnabledButtons();
                btn_customer.IsEnabled = false;
                btn_customer.Opacity = 1;

                cb_vendors.Visibility = Visibility.Visible;
                cb_vendors.SelectedItem = null;
                chk_allVendors.Visibility = Visibility.Visible;

                vendorCombo = statisticModel.getVendorCombo(payments, "c");
                fillVendorCombo(vendorCombo, cb_vendors);

                payCombo = statisticModel.getPaymentsTypeComboBySide(payments, "c");
                fillPaymentsTypeCombo(cb_vendorPayType);

                accCombo = statisticModel.getAccounantCombo(payments, "c");
                fillAccCombo(accCombo, cb_vendorAccountant);

                fillEvents("c");

                chk_allVendorsPaymentType.IsChecked = true;
                chk_allVendors.IsChecked = true;
                chk_allVendorsAccountant.IsChecked = true;

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
        {//users
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendors, MainWindow.resourcemanager.GetString("trUserHint"));
                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                hideAllColumn();
                selectedTab = 2;
                //view columns
                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;
                col_user.Visibility = Visibility.Visible;
                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;

                txt_search.Text = "";

                paint();
                bdr_user.Background = Brushes.White;
                path_user.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                isEnabledButtons();
                btn_vendor.IsEnabled = false;
                btn_vendor.Opacity = 1;

                cb_vendors.Visibility = Visibility.Visible;
                cb_vendors.SelectedItem = null;
                chk_allVendors.Visibility = Visibility.Visible;

                vendorCombo = statisticModel.getUserAcc(payments, "u");
                fillSalaryCombo(vendorCombo, cb_vendors);

                payCombo = statisticModel.getPaymentsTypeComboBySide(payments, "u");
                fillPaymentsTypeCombo(cb_vendorPayType);

                accCombo = statisticModel.getAccounantCombo(payments, "u");
                fillAccCombo(accCombo, cb_vendorAccountant);

                fillEvents("u");

                chk_allVendorsPaymentType.IsChecked = true;
                chk_allVendors.IsChecked = true;
                chk_allVendorsAccountant.IsChecked = true;


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

                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendors, MainWindow.resourcemanager.GetString("trShippingCompanyHint"));
                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                hideAllColumn();
                selectedTab = 3;
                //view columns
                col_tansNum.Visibility = Visibility.Visible;
                col_processType.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;
                col_shipping.Visibility = Visibility.Visible;
                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;

                txt_search.Text = "";

                paint();
                bdr_shipping.Background = Brushes.White;
                path_shipping.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                isEnabledButtons();
                btn_shipping.IsEnabled = false;
                btn_shipping.Opacity = 1;

                cb_vendors.Visibility = Visibility.Visible;
                cb_vendors.SelectedItem = null;
                chk_allVendors.Visibility = Visibility.Visible;

                var iulist = payments.Where(g => g.shippingCompanyId != null).GroupBy(g => g.shippingCompanyId).Select(g => new ShippingCombo { ShippingId = g.FirstOrDefault().shippingCompanyId, ShippingName = g.FirstOrDefault().shippingCompanyName }).ToList();
                cb_vendors.SelectedValuePath = "ShippingId";
                cb_vendors.DisplayMemberPath = "ShippingName";
                cb_vendors.ItemsSource = iulist;

                payCombo = statisticModel.getPaymentsTypeComboBySide(payments, "sh");
                fillPaymentsTypeCombo(cb_vendorPayType);

                accCombo = statisticModel.getAccounantCombo(payments, "sh");
                fillAccCombo(accCombo, cb_vendorAccountant);

                fillEvents("sh");

                chk_allVendorsPaymentType.IsChecked = true;
                chk_allVendors.IsChecked = true;
                chk_allVendorsAccountant.IsChecked = true;


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
        private void fillEvents(string side)
        {
            temp = fillList(payments, cb_vendors, cb_vendorPayType, cb_vendorAccountant, dp_vendorStartDate, dp_vendorEndDate).Where(x => x.side == side);
            if (selectedTab == 1)
            {
                temp = temp.Where(t => (t.invShippingCompanyId == null && t.shipUserId == null && t.invAgentId != null) ||
                                       (t.invShippingCompanyId != null && t.shipUserId != null && t.invAgentId != null));
            }
            else if (selectedTab == 3)
            {
                temp = temp.Where(t => t.invShippingCompanyId != null && t.shipUserId != null && t.invAgentId == null);
            }
            dgPayments.ItemsSource = temp;
            txt_count.Text = dgPayments.Items.Count.ToString();

            fillColumnChart();
            fillPieChart();
            fillRowChart();
        }

        /*Charts*/
        /*********************************************************************************/

        private void fillPieChart()
        {
            List<string> titles = new List<string>();
            List<int> resultList = new List<int>();
            titles.Clear();

            var result = temp
                .GroupBy(s => new { s.processType })
                .Select(s => new CashTransferSts
                {
                    processTypeCount = s.Count(),
                    processType = s.FirstOrDefault().processType,
                });
            resultList = result.Select(m => m.processTypeCount).ToList();
            titles = result.Select(m => m.processType).ToList();
            for (int t = 0; t < titles.Count; t++)
            {
                string s = "";
                switch (titles[t])
                {
                    case "cash": s = MainWindow.resourcemanager.GetString("trCash"); break;
                    case "doc": s = MainWindow.resourcemanager.GetString("trDocument"); break;
                    case "cheque": s = MainWindow.resourcemanager.GetString("trCheque"); break;
                    case "balance": s = MainWindow.resourcemanager.GetString("trCredit"); break;
                    case "card": s = MainWindow.resourcemanager.GetString("trAnotherPaymentMethods"); break;
                    case "inv": s = MainWindow.resourcemanager.GetString("trInv"); break;
                }
                titles[t] = s;
            }
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

            #region group data by selected tab
            //agent
            if ((selectedTab == 0) || (selectedTab == 1))
            {
                var res = temp.Where(x => x.agentId != null).GroupBy(x => new { x.agentId, x.processType }).Select(x => new CashTransferSts
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
                    invoiceTotal = x.Where(g => g.processType == "inv").Sum(g => (decimal)g.cash),
                    agentName = x.FirstOrDefault().agentName,
                    agentId = x.FirstOrDefault().agentId,
                }
                ).ToList();

                var tempName = res.GroupBy(s => new { s.agentId }).Select(s => new
                {
                    agentName = s.FirstOrDefault().agentName,
                });
                names.AddRange(tempName.Select(nn => nn.agentName));
            }
            //user
            if (selectedTab == 2) 
            {
                var res = temp.GroupBy(x => new { x.userId, x.processType }).Select(x => new CashTransferSts
                {
                    processType = x.FirstOrDefault().processType,
                    userId = x.FirstOrDefault().userId,
                    usersName = x.FirstOrDefault().userAcc,
                    cash = x.Sum(g => g.cash),

                });
                resultList = res.GroupBy(x => x.userId).Select(x => new CashTransferSts
                {
                    processType = x.FirstOrDefault().processType,
                    cashTotal = x.Where(g => g.processType == "cash").Sum(g => (decimal)g.cash),
                    cardTotal = x.Where(g => g.processType == "card").Sum(g => (decimal)g.cash),
                    chequeTotal = x.Where(g => g.processType == "cheque").Sum(g => (decimal)g.cash),
                    docTotal = x.Where(g => g.processType == "doc").Sum(g => (decimal)g.cash),
                    balanceTotal = x.Where(g => g.processType == "balance").Sum(g => (decimal)g.cash),
                    invoiceTotal = x.Where(g => g.processType == "inv").Sum(g => (decimal)g.cash),
                    usersName = x.FirstOrDefault().usersName,
                    userId = x.FirstOrDefault().userId,
                }
                ).ToList();

                var tempName = res.GroupBy(s => new { s.userId }).Select(s => new
                {
                    userName = s.FirstOrDefault().usersName,
                });
                names.AddRange(tempName.Select(nn => nn.userName));
            }
            //shipping
            if (selectedTab == 3)
            {
                var res = temp.Where(x => x.shippingCompanyId != null).GroupBy(x => new { x.shippingCompanyId, x.processType }).Select(x => new CashTransferSts
                {
                    processType = x.FirstOrDefault().processType,
                    shippingCompanyId = x.FirstOrDefault().shippingCompanyId,
                    shippingCompanyName = x.FirstOrDefault().shippingCompanyName,
                    cash = x.Sum(g => g.cash),

                });
                resultList = res.GroupBy(x => x.shippingCompanyId).Select(x => new CashTransferSts
                {
                    processType = x.FirstOrDefault().processType,
                    cashTotal = x.Where(g => g.processType == "cash").Sum(g => (decimal)g.cash),
                    cardTotal = x.Where(g => g.processType == "card").Sum(g => (decimal)g.cash),
                    chequeTotal = x.Where(g => g.processType == "cheque").Sum(g => (decimal)g.cash),
                    docTotal = x.Where(g => g.processType == "doc").Sum(g => (decimal)g.cash),
                    balanceTotal = x.Where(g => g.processType == "balance").Sum(g => (decimal)g.cash),
                    invoiceTotal = x.Where(g => g.processType == "inv").Sum(g => (decimal)g.cash),
                    shippingCompanyName = x.FirstOrDefault().shippingCompanyName,
                    shippingCompanyId = x.FirstOrDefault().shippingCompanyId,
                }
                ).ToList();

                var tempName = res.GroupBy(s => new { s.shippingCompanyId }).Select(s => new
                {
                    shippingCompanyName = s.FirstOrDefault().shippingCompanyName,
                });
                names.AddRange(tempName.Select(nn => nn.shippingCompanyName));
            }
            #endregion

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> cash = new List<decimal>();
            List<decimal> card = new List<decimal>();
            List<decimal> doc = new List<decimal>();
            List<decimal> cheque = new List<decimal>();
            List<decimal> balance = new List<decimal>();
            List<decimal> invoice = new List<decimal>();

            int xCount = 6;
            if (resultList.Count() <= 6)
                xCount = resultList.Count();
            for (int i = 0; i < xCount; i++)
            {
                cash.Add(resultList.ToList().Skip(i).FirstOrDefault().cashTotal);
                card.Add(resultList.ToList().Skip(i).FirstOrDefault().cardTotal);
                doc.Add(resultList.ToList().Skip(i).FirstOrDefault().docTotal);
                cheque.Add(resultList.ToList().Skip(i).FirstOrDefault().chequeTotal);
                invoice.Add(resultList.ToList().Skip(i).FirstOrDefault().invoiceTotal);

                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            if (resultList.Count() > 6)
            {
                decimal cashSum = 0, cardSum = 0, docSum = 0, chequeSum = 0, balanceSum = 0, invoiceSum = 0;
                for (int i = 6; i < resultList.Count; i++)
                {
                    cashSum = cashSum + resultList.ToList().Skip(i).FirstOrDefault().cashTotal;
                    cardSum = cardSum + resultList.ToList().Skip(i).FirstOrDefault().cardTotal;
                    docSum = docSum + resultList.ToList().Skip(i).FirstOrDefault().docTotal;
                    chequeSum = chequeSum + resultList.ToList().Skip(i).FirstOrDefault().chequeTotal;
                    invoiceSum = invoiceSum + resultList.ToList().Skip(i).FirstOrDefault().invoiceTotal;
                }
                if (!((cashSum == 0) && (cardSum == 0) && (docSum == 0) && (chequeSum == 0) && (chequeSum == 0) && (balanceSum == 0) && (invoiceSum == 0)))
                {
                    cash.Add(cashSum);
                    card.Add(cardSum);
                    doc.Add(docSum);
                    cheque.Add(chequeSum);
                    invoice.Add(invoiceSum);

                    axcolumn.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
                }
            }
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cash.AsChartValues(),
                DataLabels = true,
                Title = MainWindow.resourcemanager.GetString("trCash")
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = card.AsChartValues(),
                DataLabels = true,
                Title = MainWindow.resourcemanager.GetString("trAnotherPaymentMethods")
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = doc.AsChartValues(),
                DataLabels = true,
                Title = MainWindow.resourcemanager.GetString("trDocument")
            });
            columnChartData.Add(
         new StackedColumnSeries
         {
             Values = cheque.AsChartValues(),
             DataLabels = true,
             Title = MainWindow.resourcemanager.GetString("trCheque")
         });
            columnChartData.Add(
         new StackedColumnSeries
         {
             Values = invoice.AsChartValues(),
             DataLabels = true,
             Title = MainWindow.resourcemanager.GetString("trInv")
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

            SeriesCollection rowChartData = new SeriesCollection();
            //agent
            if ((selectedTab == 0) || (selectedTab == 1))
            {
                var tempName = temp.GroupBy(s => new { s.agentId }).Select(s => new
                {
                    Name = s.FirstOrDefault().updateDate,
                });
                names.AddRange(tempName.Select(nn => nn.Name.ToString()));
            }//user
            else if (selectedTab == 2)
            {
                var tempName = temp.GroupBy(s => new { s.userId }).Select(s => new
                {
                    Name = s.FirstOrDefault().updateDate,
                });
                names.AddRange(tempName.Select(nn => nn.Name.ToString()));
            }
            else if (selectedTab == 3)
            {
                var tempName = temp.GroupBy(s => new { s.shippingCompanyId }).Select(s => new
                {
                    Name = s.FirstOrDefault().updateDate,
                });
                names.AddRange(tempName.Select(nn => nn.Name.ToString()));
            }
            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<decimal> cash = new List<decimal>();
            List<decimal> card = new List<decimal>();
            List<decimal> doc = new List<decimal>();
            List<decimal> cheque = new List<decimal>();
            List<decimal> invoice = new List<decimal>();

            if (endYear - startYear <= 1)
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    for (int month = startMonth; month <= 12; month++)
                    {
                        var firstOfThisMonth = new DateTime(year, month, 1);
                        var firstOfNextMonth = firstOfThisMonth.AddMonths(1);
                        var drawCash = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "cash").Select(c => c.cash.Value).Sum();
                        var drawCard = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "card").Select(c => c.cash.Value).Sum();
                        var drawDoc = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "doc").Select(c => c.cash.Value).Sum();
                        var drawCheque = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "cheque").Select(c => c.cash.Value).Sum();
                        var drawBalance = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "balance").Select(c => c.cash.Value).Sum();
                        var drawInvoice = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.processType == "inv").Select(c => c.cash.Value).Sum();

                        cash.Add(drawCash);
                        card.Add(drawCard);
                        doc.Add(drawDoc);
                        cheque.Add(drawCheque);
                        invoice.Add(drawInvoice);
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
                    var drawCash = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.processType == "cash").Select(c => c.cash.Value).Sum();
                    var drawCard = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.processType == "card").Select(c => c.cash.Value).Sum();
                    var drawDoc = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.processType == "doc").Select(c => c.cash.Value).Sum();
                    var drawCheque = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.processType == "cheque").Select(c => c.cash.Value).Sum();
                    var drawInvoice = temp.ToList().Where(c => c.updateDate > firstOfThisYear && c.updateDate <= firstOfNextMYear && c.processType == "inv").Select(c => c.cash.Value).Sum();

                    cash.Add(drawCash);
                    card.Add(drawCard);
                    doc.Add(drawDoc);
                    cheque.Add(drawCheque);
                    invoice.Add(drawInvoice);
                    MyAxis.Labels.Add(year.ToString());
                }
            }
            rowChartData.Add(
          new LineSeries
          {
              Values = cash.AsChartValues(),
              Title = MainWindow.resourcemanager.GetString("trCash")
          }); ;
            rowChartData.Add(
         new LineSeries
         {
             Values = card.AsChartValues(),
             Title = MainWindow.resourcemanager.GetString("trAnotherPaymentMethods")
         });
            rowChartData.Add(
        new LineSeries
        {
            Values = doc.AsChartValues(),
            Title = MainWindow.resourcemanager.GetString("trDocument")

        });
            rowChartData.Add(
            new LineSeries
            {
                Values = cheque.AsChartValues(),
                Title = MainWindow.resourcemanager.GetString("trCheque")

            });
            rowChartData.Add(
            new LineSeries
            {
                Values = invoice.AsChartValues(),
                Title = MainWindow.resourcemanager.GetString("trInv")

            });
            DataContext = this;
            rowChart.Series = rowChartData;
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                txt_search.Text = "";

                cb_vendors.SelectedItem = null;
                cb_vendorPayType.SelectedItem = null;
                cb_vendorAccountant.SelectedItem = null;
                chk_allVendors.IsChecked = false;
                chk_allVendorsAccountant.IsChecked = false;
                chk_allVendorsPaymentType.IsChecked = false;
                dp_vendorEndDate.SelectedDate = null;
                dp_vendorStartDate.SelectedDate = null;

                if (selectedTab == 0)
                {
                    fillEvents("v");
                }
                else if (selectedTab == 1)
                {
                    fillEvents("c");
                }
                else if (selectedTab == 2)
                {
                    fillEvents("u");
                }
                else if (selectedTab == 3)
                {
                    fillEvents("sh");
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
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (selectedTab == 0)
                {
                    dgPayments.ItemsSource = recLst.Where(obj => (
                    obj.side == "v" 
                    &&
                    (obj.transNum.Contains(txt_search.Text) ||
                    obj.processType.Contains(txt_search.Text) ||
                    obj.updateUserAcc.Contains(txt_search.Text) ||
                    obj.agentCompany.Contains(txt_search.Text) ||
                    obj.agentName.Contains(txt_search.Text)
                    )));
                }
                if (selectedTab == 1)
                {
                    dgPayments.ItemsSource = recLst.Where(obj => (
                    obj.side == "c"
                    &&
                    (obj.transNum.Contains(txt_search.Text) ||
                    obj.processType.Contains(txt_search.Text) ||
                    obj.updateUserAcc.Contains(txt_search.Text) 
                    //||
                    //(obj.agentCompany == null ? obj.agentCompany.Contains(txt_search.Text) : true)
                    //||
                    //obj.agentName.Contains(txt_search.Text)
                    )));
            }
                else if (selectedTab == 2)
                {
                    dgPayments.ItemsSource = recLst.Where(obj => (
                        obj.side == "u"
                        &&
                        (
                        obj.transNum.Contains(txt_search.Text) ||
                        obj.processType.Contains(txt_search.Text) ||
                        obj.updateUserAcc.Contains(txt_search.Text) ||
                        obj.userAcc.Contains(txt_search.Text)
                        )));
                }
                else if (selectedTab == 3)
                {
                    dgPayments.ItemsSource = recLst.Where(obj => (
                     obj.side == "sh"
                        &&
                        (
                       obj.transNum.Contains(txt_search.Text) ||
                       obj.processType.Contains(txt_search.Text) ||
                       obj.updateUserAcc.Contains(txt_search.Text) ||
                       obj.shippingCompanyName.Contains(txt_search.Text)
                       )));
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
            string firstTitle = "recipientReport";
            string secondTitle = "";
            string subTitle = "";
            string Title = "";
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                if (selectedTab == 0)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\Ar\ArVendor.rdlc";
                    secondTitle = "vendors";
                }
                else if (selectedTab == 1)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\Ar\ArCustomer.rdlc";
                    secondTitle = "customers";
                }
                else if (selectedTab == 2)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\Ar\ArUser.rdlc";
                    secondTitle = "users";
                }
                else if (selectedTab == 6)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\Ar\ArShipping.rdlc";
                    secondTitle = "shipping";
                }
            }
            else
            {
                if (selectedTab == 0)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\En\Vendor.rdlc";
                    secondTitle = "vendors";
                }
                else if (selectedTab == 1)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\En\Customer.rdlc";
                    secondTitle = "customers";
                }
                else if (selectedTab == 2)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\En\User.rdlc";
                    secondTitle = "users";
                }
                else if (selectedTab == 6)
                {
                    addpath = @"\Reports\StatisticReport\Accounts\Recipient\En\Shipping.rdlc";
                    secondTitle = "shipping";
                }
            }
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();
            subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
            Title = MainWindow.resourcemanagerreport.GetString("trAccountantReport") + " / " + subTitle;
            paramarr.Add(new ReportParameter("trTitle", Title));
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

        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillBySide();

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

        private void fillBySide()
        {
            if (selectedTab == 0)
                fillEvents("v");
            else if (selectedTab == 1)
                fillEvents("c");
            else if (selectedTab == 2)
                fillEvents("u");
            else if (selectedTab == 3)
                fillEvents("sh");
        }

        private void Dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                fillBySide();

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

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}

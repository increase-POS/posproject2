using LiveCharts;
using LiveCharts.Wpf;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

using LiveCharts.Helpers;
using POS.View.windows;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.Threading;

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for uc_salePromotion.xaml
    /// </summary>
    public partial class uc_salePromotion : UserControl
    { //prin & pdf
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        private int selectedTab = 0;

        Statistics statisticModel = new Statistics();

        List<ItemTransferInvoice> coupons;
        List<ItemTransferInvoice> Offers;

        //for combo boxes
        /*************************/
        CouponCombo selectedCouon;
        OfferCombo selectedOffer;

        List<CouponCombo> comboCoupon;
        List<OfferCombo> comboOffer;

        ObservableCollection<CouponCombo> comboCouponTemp = new ObservableCollection<CouponCombo>();
        ObservableCollection<OfferCombo> comboOfferTemp = new ObservableCollection<OfferCombo>();

        ObservableCollection<CouponCombo> dynamicComboCoupon;
        ObservableCollection<OfferCombo> dynamicComboOffer;

        Item itemModel = new Item();
        Coupon couponModel = new Coupon();
        Offer offerModel = new Offer();
        /*************************/

        Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        ObservableCollection<int> selectedItemId = new ObservableCollection<int>();
        ObservableCollection<int> selectedcouponId = new ObservableCollection<int>();
        ObservableCollection<int> selectedOfferId = new ObservableCollection<int>();

        private static uc_saleReport _instance;

        public static uc_saleReport Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_saleReport();
                return _instance;
            }
        }
        public uc_salePromotion()
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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            //try
            //{
            //    if (sender != null)
            //        SectionData.StartAwait(grid_main);

                coupons = await statisticModel.GetSalecoupon((int)MainWindow.branchID, (int)MainWindow.userID);

                Offers = await statisticModel.GetPromoOffer((int)MainWindow.branchID, (int)MainWindow.userID);

                comboCoupon = statisticModel.GetCopComboList(coupons);
                comboOffer = statisticModel.GetOfferComboList(Offers);

                dynamicComboCoupon = new ObservableCollection<CouponCombo>(comboCoupon);
                dynamicComboOffer = new ObservableCollection<OfferCombo>(comboOffer);

                fillComboCoupon();
                fillComboOffer();


                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_coupons.Tag.ToString());
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_Coupons, MainWindow.resourcemanager.GetString("trCoponHint"));
                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_coupon);
                path_coupons.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                chk_couponInvoice.IsChecked = true;


            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }

        private void fillComboCoupon()
        {
            cb_Coupons.SelectedValuePath = "Copcid";
            cb_Coupons.DisplayMemberPath = "Copname";
            cb_Coupons.ItemsSource = dynamicComboCoupon;
        }

        private void fillComboOffer()
        {
            cb_Coupons.SelectedValuePath = "OofferId";
            cb_Coupons.DisplayMemberPath = "Oname";
            cb_Coupons.ItemsSource = dynamicComboOffer;
        }
        private static void fillDates(DatePicker startDate, DatePicker endDate, TimePicker startTime, TimePicker endTime)
        {
            if (startDate.SelectedDate != null && startTime.SelectedTime != null)
            {
                string x = startDate.SelectedDate.Value.Date.ToShortDateString();
                string y = startTime.SelectedTime.Value.ToShortTimeString();
                string resultStartTime = x + " " + y;
                startTime.SelectedTime = DateTime.Parse(resultStartTime);
                startDate.SelectedDate = DateTime.Parse(resultStartTime);
            }
            if (endDate.SelectedDate != null && endTime.SelectedTime != null)
            {
                string x = endDate.SelectedDate.Value.Date.ToShortDateString();
                string y = endTime.SelectedTime.Value.ToShortTimeString();
                string resultEndTime = x + " " + y;
                endTime.SelectedTime = DateTime.Parse(resultEndTime);
                endDate.SelectedDate = DateTime.Parse(resultEndTime);
            }
        }
        IEnumerable<ItemTransferInvoice> invLst = null;
        private IEnumerable<ItemTransferInvoice> fillList(IEnumerable<ItemTransferInvoice> Invoices, CheckBox chkInvoice, CheckBox chkReturn, CheckBox chkDraft
           , DatePicker startDate, DatePicker endDate, TimePicker startTime, TimePicker endTime)
        {
            fillDates(startDate, endDate, startTime, endTime);
            var result = Invoices.Where(x => (

               ((chkDraft.IsChecked == true ? (x.invType == "sd" || x.invType == "sbd") : false)
                          || (chkReturn.IsChecked == true ? (x.invType == "sb") : false)
                          || (chkInvoice.IsChecked == true ? (x.invType == "s") : false))
                      && (startDate.SelectedDate != null ? x.invDate >= startDate.SelectedDate : true)
                      && (endDate.SelectedDate != null ? x.invDate <= endDate.SelectedDate : true)
                      && (startTime.SelectedTime != null ? x.invDate >= startTime.SelectedTime : true)
                      && (endTime.SelectedTime != null ? x.invDate <= endTime.SelectedTime : true)));

            invLst = result;
            return result;
        }

        IEnumerable<ItemTransferInvoice> invRowChartLst = null;
        private IEnumerable<ItemTransferInvoice> fillRowChartList(IEnumerable<ItemTransferInvoice> Invoices, CheckBox chkInvoice, CheckBox chkReturn, CheckBox chkDraft
          , DatePicker startDate, DatePicker endDate, TimePicker startTime, TimePicker endTime)
        {
            fillDates(startDate, endDate, startTime, endTime);
            var result = Invoices.Where(x => ((txt_search.Text != null ? x.invNumber.Contains(txt_search.Text)
              || x.invType.Contains(txt_search.Text)
              || x.discountType.Contains(txt_search.Text) : true)
              &&
                         (startDate.SelectedDate != null ? x.invDate >= startDate.SelectedDate : true)
                        && (endDate.SelectedDate != null ? x.invDate <= endDate.SelectedDate : true)
                        && (startTime.SelectedTime != null ? x.invDate >= startTime.SelectedTime : true)
                        && (endTime.SelectedTime != null ? x.invDate <= endTime.SelectedTime : true)));

            invRowChartLst = result;
            return result;
        }

        private void fillPieChart(ObservableCollection<int> stackedButton)
        {
            List<string> titles = new List<string>();
            IEnumerable<int> x = null;

            var temp = invLst;

            if (selectedTab == 0)
            {
                titles.Clear();
                temp = temp.Where(j => (selectedcouponId.Count != 0 ? stackedButton.Contains((int)j.CopcId) : true));
                var titleTemp = temp.GroupBy(m => m.Copname);
                titles.AddRange(titleTemp.Select(jj => jj.Key));
                var result = temp.GroupBy(s => s.CopcId).Select(s => new { CopcId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }

            else if (selectedTab == 1)
            {
                titles.Clear();
                temp = temp.Where(j => (selectedOfferId.Count != 0 ? stackedButton.Contains((int)j.OofferId) : true));
                var titleTemp = temp.GroupBy(m => m.Oname);
                titles.AddRange(titleTemp.Select(jj => jj.Key));
                var result = temp.GroupBy(s => s.OofferId).Select(s => new { OofferId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }

            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < x.Count(); i++)
            {
                List<int> final = new List<int>();

                List<string> lable = new List<string>();
                final.Add(x.ToList().Skip(i).FirstOrDefault());
                piechartData.Add(
                  new PieSeries
                  {
                      Values = final.AsChartValues(),
                      Title = titles.Skip(i).FirstOrDefault(),
                      DataLabels = true,
                  }
              );
            }
            chart1.Series = piechartData;
        }

        private void fillColumnChart(ObservableCollection<int> stackedButton)
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<int> x = null;
            IEnumerable<int> y = null;
            IEnumerable<int> z = null;

            var temp = invLst;

            if (selectedTab == 0)
            {
                temp = temp.Where(j => (selectedcouponId.Count != 0 ? stackedButton.Contains((int)j.CopcId) : true));
                var result = temp.GroupBy(s => s.CopcId).Select(s => new
                {
                    CopcId = s.Key,
                    countP = s.Where(m => m.invType == "s").Count(),
                    countPb = s.Where(m => m.invType == "sb").Count(),
                    countD = s.Where(m => m.invType == "sd" || m.invType == "sbd").Count()

                });
                x = result.Select(m => m.countP);
                y = result.Select(m => m.countPb);
                z = result.Select(m => m.countD);
                var tempName = temp.GroupBy(s => s.Copname).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }

            else if (selectedTab == 1)
            {
                temp = temp.Where(j => (selectedOfferId.Count != 0 ? stackedButton.Contains((int)j.OofferId) : true));
                var result = temp.GroupBy(s => s.OofferId).Select(s => new
                {
                    CopcId = s.Key,
                    countP = s.Where(m => m.invType == "s").Count(),
                    countPb = s.Where(m => m.invType == "sb").Count(),
                    countD = s.Where(m => m.invType == "sd" || m.invType == "sbd").Count()

                });
                x = result.Select(m => m.countP);
                y = result.Select(m => m.countPb);
                z = result.Select(m => m.countD);
                var tempName = temp.GroupBy(s => s.Oname).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();
            List<int> cD = new List<int>();
            List<string> titles = new List<string>()
            {
                MainWindow.resourcemanager.GetString("trSales"),
                MainWindow.resourcemanager.GetString("trReturned"),
                MainWindow.resourcemanager.GetString("trDraft")
            };
            for (int i = 0; i < x.Count(); i++)
            {
                cP.Add(x.ToList().Skip(i).FirstOrDefault());
                cPb.Add(y.ToList().Skip(i).FirstOrDefault());
                cD.Add(z.ToList().Skip(i).FirstOrDefault());
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            //3 فوق بعض
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cP.AsChartValues(),
                Title = titles[0],
                DataLabels = true,
            });
            columnChartData.Add(
           new StackedColumnSeries
           {
               Values = cPb.AsChartValues(),
               Title = titles[1],
               DataLabels = true,
           });
            columnChartData.Add(
           new StackedColumnSeries
           {
               Values = cD.AsChartValues(),
               Title = titles[2],
               DataLabels = true,
           });

            DataContext = this;
            cartesianChart.Series = columnChartData;
        }
       
        public void fillEvent()
        {
            if (selectedTab == 0)
            {
                itemTransfers = fillList(coupons, chk_couponInvoice, chk_couponReturn, chk_couponDrafs, dp_couponStartDate, dp_couponEndDate, dt_couponStartTime, dt_couponEndTime).Where(j => (selectedcouponId.Count != 0 ? selectedcouponId.Contains((int)j.CopcId) : true));
                fillRowChartList(coupons, chk_couponInvoice, chk_couponReturn, chk_couponDrafs, dp_couponStartDate, dp_couponEndDate, dt_couponStartTime, dt_couponEndTime).Where(j => (selectedcouponId.Count != 0 ? selectedcouponId.Contains((int)j.CopcId) : true));
            }
            else if (selectedTab == 1)
            {
                itemTransfers = fillList(Offers, chk_couponInvoice, chk_couponReturn, chk_couponDrafs, dp_couponStartDate, dp_couponEndDate, dt_couponStartTime, dt_couponEndTime).Where(j => (selectedOfferId.Count != 0 ? selectedOfferId.Contains((int)j.OofferId) : true));
                fillRowChartList(coupons, chk_couponInvoice, chk_couponReturn, chk_couponDrafs, dp_couponStartDate, dp_couponEndDate, dt_couponStartTime, dt_couponEndTime).Where(j => (selectedOfferId.Count != 0 ? selectedOfferId.Contains((int)j.OofferId) : true));
            }
            dgInvoice.ItemsSource = itemTransfers;
            txt_count.Text = dgInvoice.Items.Count.ToString();

            fillPieChart(selectedcouponId);
            fillColumnChart(selectedcouponId);
            fillRowChartCoupAndOffer(cb_Coupons, selectedcouponId);
        }

        #region Functions
        private void hideSatacks()
        {
            stk_tagsBranches.Visibility = Visibility.Collapsed;
            stk_tagsItems.Visibility = Visibility.Collapsed;
            stk_tagsPos.Visibility = Visibility.Collapsed;
            stk_tagsUsers.Visibility = Visibility.Collapsed;
            stk_tagsVendors.Visibility = Visibility.Collapsed;
            stk_tagsCoupons.Visibility = Visibility.Collapsed;
            stk_tagsOffers.Visibility = Visibility.Collapsed;
        }

        public void paint()
        {
            //bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            bdr_coupon.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_offers.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_coupons.Fill = Brushes.White;
            path_offers.Fill = Brushes.White;

        }

        #endregion

        #region Events
        #region tabControl
        private void hidAllColumns()
        {
            col_type.Visibility = Visibility.Hidden;
            col_branch.Visibility = Visibility.Hidden;
            col_pos.Visibility = Visibility.Hidden;
            col_vendor.Visibility = Visibility.Hidden;
            col_agentCompany.Visibility = Visibility.Hidden;
            col_user.Visibility = Visibility.Hidden;
            col_item.Visibility = Visibility.Hidden;
            col_discount.Visibility = Visibility.Hidden;
            col_count.Visibility = Visibility.Hidden;
            col_itQuantity.Visibility = Visibility.Hidden;
            col_price.Visibility = Visibility.Hidden;
            col_total.Visibility = Visibility.Hidden;
            col_totalNet.Visibility = Visibility.Hidden;
            col_tax.Visibility = Visibility.Hidden;
            col_coupon.Visibility = Visibility.Hidden;
            col_offers.Visibility = Visibility.Hidden;
            col_coupoValue.Visibility = Visibility.Hidden;
            col_couponType.Visibility = Visibility.Hidden;
            col_offersType.Visibility = Visibility.Hidden;
            col_offersValue.Visibility = Visibility.Hidden;
            col_offersTotalValue.Visibility = Visibility.Hidden;
            col_couponTotalValue.Visibility = Visibility.Hidden;
        }
        
        private void btn_coupons_Click(object sender, RoutedEventArgs e)
        {//copouns
         //try
         //{
         //    if (sender != null)
         //        SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_Coupons, MainWindow.resourcemanager.GetString("trCoponHint"));
                selectedTab = 0;
                txt_search.Text = "";
                hideSatacks();
                stk_tagsCoupons.Visibility = Visibility.Visible;

                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_coupon);
                path_coupons.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                fillEvent();

                hidAllColumns();
                col_coupon.Visibility = Visibility.Visible;
                col_couponType.Visibility = Visibility.Visible;
                col_coupoValue.Visibility = Visibility.Visible;
                col_couponTotalValue.Visibility = Visibility.Visible;

            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }
        private void btn_offers_Click(object sender, RoutedEventArgs e)
        {//offers
         //try
         //{
         //    if (sender != null)
         //        SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_Coupons, MainWindow.resourcemanager.GetString("trOfferHint"));
                selectedTab = 1;
                txt_search.Text = "";
                hideSatacks();
                stk_tagsCoupons.Visibility = Visibility.Visible;

                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_offers);
                path_offers.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                fillEvent();
                hidAllColumns();
                
                col_offers.Visibility = Visibility.Visible;
                col_offersType.Visibility = Visibility.Visible;
                col_offersValue.Visibility = Visibility.Visible;
                col_item.Visibility = Visibility.Visible;
                col_itQuantity.Visibility = Visibility.Visible;
                col_offersTotalValue.Visibility = Visibility.Visible;

            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }
        #endregion

        #region refreshButton
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
               
                cb_Coupons.SelectedItem = null;
                chk_couponDrafs.IsChecked = false;
                chk_couponReturn.IsChecked = false;
                chk_couponInvoice.IsChecked = true;
                dp_couponEndDate.SelectedDate = null;
                dp_couponStartDate.SelectedDate = null;
                dt_couponStartTime.SelectedTime = null;
                dt_couponEndTime.SelectedTime = null;
                chk_allCoupon.IsChecked = false;
                cb_Coupons.IsEnabled = true;

                if (selectedTab == 0)
                {
                    for (int i = 0; i < comboCouponTemp.Count; i++)
                    {
                        dynamicComboCoupon.Add(comboCouponTemp.Skip(i).FirstOrDefault());
                    }
                    comboCouponTemp.Clear();
                    stk_tagsCoupons.Children.Clear();
                    selectedcouponId.Clear();
                    fillEvent();
                }

                else if (selectedTab == 1)
                {
                    for (int i = 0; i < comboOfferTemp.Count; i++)
                    {
                        dynamicComboOffer.Add(comboOfferTemp.Skip(i).FirstOrDefault());
                    }
                    comboOfferTemp.Clear();
                    stk_tagsOffers.Children.Clear();
                    selectedOfferId.Clear();
                    fillEvent();
                }
                txt_search.Text = "";

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
        #endregion

        #region settings
        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                List<string> Headers = new List<string>();
                List<string> Headers1 = new List<string>();
                foreach (var item in dgInvoice.Columns)
                {
                    Headers.Add(item.Header.ToString());
                }

                winControlPanel win = new winControlPanel(Headers);

                if (win.ShowDialog() == false)
                {
                    Headers1.Clear();
                    Headers1.AddRange(win.newHeaderResult);
                }
                for (int i = 0; i < Headers1.Count; i++)
                {
                    if (dgInvoice.Columns[i].Header.ToString() == Headers1[i])
                    {
                        dgInvoice.Columns[i].Visibility = Visibility.Visible;
                    }
                    else
                        dgInvoice.Columns[i].Visibility = Visibility.Hidden;
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

        #endregion

        #endregion

        private void Chip_OnDeleteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                var currentChip = (Chip)sender;
                if (selectedTab == 0)
                {
                    stk_tagsCoupons.Children.Remove(currentChip);
                    var m = comboCouponTemp.Where(j => j.Copcid == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
                    dynamicComboCoupon.Add(m.FirstOrDefault());
                    selectedcouponId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
                    if (selectedcouponId.Count == 0)
                    {
                        cb_Coupons.SelectedItem = null;
                    }
                }
                else if(selectedTab == 1)
                {
                    stk_tagsOffers.Children.Remove(currentChip);
                    var m = comboOfferTemp.Where(j => j.OofferId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
                    dynamicComboOffer.Add(m.FirstOrDefault());
                    selectedOfferId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
                    if (selectedOfferId.Count == 0)
                    {
                        cb_Coupons.SelectedItem = null;
                    }
                }
                fillEvent();

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
      
        private void fillEventCall(object sender)
        {
            //try
            //{
            //    if (sender != null)
            //        SectionData.StartAwait(grid_main);

                fillEvent();

            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }

        private void chk_Checked(object sender, RoutedEventArgs e)
        {
            fillEventCall(sender);
        }

        private void dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEventCall(sender);
        }

        private void dt_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillEventCall(sender);
        }

        private void chk_allCoupon_Click(object sender, RoutedEventArgs e)
        {//all coupons
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (cb_Coupons.IsEnabled == true)
                {
                    cb_Coupons.SelectedItem = null;
                    cb_Coupons.IsEnabled = false;

                    if (selectedTab == 0)
                    {
                        for (int i = 0; i < comboCouponTemp.Count; i++)
                        {
                            dynamicComboCoupon.Add(comboCouponTemp.Skip(i).FirstOrDefault());
                        }
                        comboCouponTemp.Clear();
                        stk_tagsCoupons.Children.Clear();
                        selectedcouponId.Clear();
                    }
                    else if (selectedTab == 1)
                    {
                        for (int i = 0; i < comboOfferTemp.Count; i++)
                        {
                            dynamicComboOffer.Add(comboOfferTemp.Skip(i).FirstOrDefault());
                        }
                        comboOfferTemp.Clear();
                        stk_tagsOffers.Children.Clear();
                        selectedOfferId.Clear();
                    }
                }
                else
                {
                    cb_Coupons.IsEnabled = true;
                }

                fillEvent();

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

        private void cb_Coupons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (cb_Coupons.SelectedItem != null)
                {
                    if(selectedTab == 0)
                    {
                        if (stk_tagsCoupons.Children.Count < 5)
                        {
                            selectedCouon = cb_Coupons.SelectedItem as CouponCombo;
                            var b = new MaterialDesignThemes.Wpf.Chip()
                            {
                                Content = selectedCouon.Copname,
                                Name = "btn" + selectedCouon.Copcid.ToString(),
                                IsDeletable = true,
                                Margin = new Thickness(5, 0, 5, 0)
                            };
                            b.DeleteClick += Chip_OnDeleteClick;
                            stk_tagsCoupons.Children.Add(b);
                            comboCouponTemp.Add(selectedCouon);
                            selectedcouponId.Add(selectedCouon.Copcid);
                            dynamicComboCoupon.Remove(selectedCouon);
                        }
                    }
                    else if (selectedTab == 1)
                    {
                        if (stk_tagsOffers.Children.Count < 5)
                        {
                            selectedOffer = cb_Coupons.SelectedItem as OfferCombo;
                            var b = new MaterialDesignThemes.Wpf.Chip()
                            {
                                Content = selectedOffer.Oname,
                                Name = "btn" + selectedOffer.OofferId.ToString(),
                                IsDeletable = true,
                                Margin = new Thickness(5, 0, 5, 0)
                            };
                            b.DeleteClick += Chip_OnDeleteClick;
                            stk_tagsOffers.Children.Add(b);
                            comboOfferTemp.Add(selectedOffer);
                            selectedOfferId.Add(selectedOffer.OofferId);
                            dynamicComboOffer.Remove(selectedOffer);
                        }
                    }
                    fillEvent();
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
      
        Invoice invoice;
        private async void DgInvoice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                invoice = new Invoice();
                if (dgInvoice.SelectedIndex != -1)
                {
                    ItemTransferInvoice item = dgInvoice.SelectedItem as ItemTransferInvoice;
                    if (item.invoiceId > 0)
                    {
                        invoice = await invoice.getById(item.invoiceId);
                         MainWindow.mainWindow.BTN_sales_Click(MainWindow.mainWindow.btn_sales, null);
                        uc_sales.Instance.Btn_receiptInvoice_Click(uc_sales.Instance.btn_reciptInvoice, null);
                         uc_receiptInvoice.Instance.UserControl_Loaded(null, null);
                        uc_receiptInvoice._InvoiceType = invoice.invType;
                        uc_receiptInvoice.Instance.invoice = invoice;
                        await uc_receiptInvoice.Instance.fillInvoiceInputs(invoice);
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

        private void fillRowChartCoupAndOffer(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<decimal> pTemp = null;

            var temp = invRowChartLst;
            if (selectedTab == 0)
            {
                names.Clear();
                temp = temp.Where(j => (selectedcouponId.Count != 0 ? stackedButton.Contains((int)j.CopcId) : true));
                var result = temp.GroupBy(s => new { s.CopcId }).Select(s => new
                {
                    CopcId = s.FirstOrDefault().CopcId,
                    copName = s.FirstOrDefault().Copname,
                    invId = s.FirstOrDefault().invoiceId,
                    copTotalValue = s.Sum(x => x.couponTotalValue)
                }
                );


                var name = temp.GroupBy(s => s.invoiceId).Select(s => new
                {
                    uUserName = s.FirstOrDefault().Copname
                });
                names.AddRange(name.Select(nn => nn.uUserName));
                pTemp = result.Select(x => (decimal)x.copTotalValue);
            }
            if (selectedTab == 1)
            {
                names.Clear();
                temp = temp.Where(j => (selectedOfferId.Count != 0 ? stackedButton.Contains((int)j.OofferId) : true));
                var result1 = temp.GroupBy(s => new { s.itemId }).Select(s => new
                {
                    offerId = s.FirstOrDefault().OofferId,
                    offerName = s.FirstOrDefault().Oname,
                    itemId = s.FirstOrDefault().itemId,
                    offerTotalValue = s.Sum(x => x.offerTotalValue)
                }
             );

                var name = temp.GroupBy(s => s.itemId).Select(s => new
                {
                    uUserName = s.FirstOrDefault().Oname
                });
                names.AddRange(name.Select(nn => nn.uUserName));
                pTemp = result1.Select(x => (decimal)x.offerTotalValue);
            }

            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            List<string> titles = new List<string>()
            {
                MainWindow.resourcemanager.GetString("trNetSales"),
                MainWindow.resourcemanager.GetString("trTotalReturn"),
                MainWindow.resourcemanager.GetString("trSum"),
            };
            for (int i = 0; i < pTemp.Count(); i++)
            {
                purchase.Add(pTemp.ToList().Skip(i).FirstOrDefault());
                MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            rowChartData.Add(
                  new LineSeries
                  {
                      Values = purchase.AsChartValues(),
                      Title = titles[0]
                  });

            DataContext = this;
            rowChart.Series = rowChartData;
        }
      
        private void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();
            List<ItemTransferInvoice> query = new List<ItemTransferInvoice>();

            string addpath = "";
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                if (selectedTab == 5)
                {
                    addpath = @"\Reports\StatisticReport\Sale\Promotion\Ar\ArCoupons.rdlc";
                }
                else
                {
                    addpath = @"\Reports\StatisticReport\Sale\Promotion\Ar\ArOffers.rdlc";
                }
            }
            else
            {
                //english
                if (selectedTab == 5)
                {
                    addpath = @"\Reports\StatisticReport\Sale\Promotion\En\EnCoupons.rdlc";
                }
                else 
                {
                    addpath = @"\Reports\StatisticReport\Sale\Promotion\En\EnOffers.rdlc";
                }
            }

            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.SalePromoStsReport(itemTransfers, rep, reppath, paramarr);
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
        IEnumerable<ItemTransferInvoice> itemTransfers = null;

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
               
                if (selectedTab == 0)
                {
                    itemTransfers = fillList(coupons, chk_couponInvoice, chk_couponReturn, chk_couponDrafs, dp_couponStartDate, dp_couponEndDate, dt_couponStartTime, dt_couponEndTime).Where(j => (selectedcouponId.Count != 0 ? selectedcouponId.Contains((int)j.CopcId) : true));
                    dgInvoice.ItemsSource = itemTransfers
                        .Where(s => (s.Copname.Contains(txt_search.Text) ||

          s.invNumber.Contains(txt_search.Text)
          ));
                }
                else if (selectedTab == 1)
                {
                    itemTransfers = fillList(Offers, chk_couponInvoice, chk_couponReturn, chk_couponDrafs, dp_couponStartDate, dp_couponStartDate, dt_couponStartTime, dt_couponEndTime).Where(j => (selectedOfferId.Count != 0 ? selectedOfferId.Contains((int)j.OofferId) : true));

                    dgInvoice.ItemsSource = itemTransfers
                        .Where(s => (s.Oname.Contains(txt_search.Text) ||
          s.invNumber.Contains(txt_search.Text)
          ));
                }

                txt_count.Text = dgInvoice.Items.Count.ToString();

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

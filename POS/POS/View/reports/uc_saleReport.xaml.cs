﻿using LiveCharts;
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

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for uc_saleReport.xaml
    /// </summary>
    public partial class uc_saleReport : UserControl
    {
        private int selectedTab = 0;

        Statistics statisticModel = new Statistics();

        List<ItemTransferInvoice> Invoices;
        List<ItemTransferInvoice> Items;
        List<ItemTransferInvoice> coupons;
        List<ItemTransferInvoice> Offers;

        List<ItemTransferInvoice> rowChartInvoice;
        List<ItemTransferInvoice> rowChartItems;
        List<ItemTransferInvoice> rowChartCoupons;
        List<ItemTransferInvoice> rowChartOffers;

        //for combo boxes
        /*************************/
        Branch selectedBranch;
        Pos selectedPos;
        Agent selectedVendor;
        User selectedUser;
        ItemUnitCombo selectedItem;
        CouponCombo selectedCouon;
        OfferCombo selectedOffer;

        List<Branch> comboBranches;
        List<Pos> comboPoss;
        List<Agent> comboVendors;
        List<User> comboUsers;
        List<ItemUnitCombo> itemUnitCombos;
        List<CouponCombo> comboCoupon;
        List<OfferCombo> comboOffer;

        ObservableCollection<Branch> comboBrachTemp = new ObservableCollection<Branch>();
        ObservableCollection<Pos> comboPosTemp = new ObservableCollection<Pos>();
        ObservableCollection<Agent> comboVendorTemp = new ObservableCollection<Agent>();
        ObservableCollection<User> comboUserTemp = new ObservableCollection<User>();
        ObservableCollection<ItemUnitCombo> comboItemTemp = new ObservableCollection<ItemUnitCombo>();
        ObservableCollection<CouponCombo> comboCouponTemp = new ObservableCollection<CouponCombo>();
        ObservableCollection<OfferCombo> comboOfferTemp = new ObservableCollection<OfferCombo>();

        ObservableCollection<Branch> dynamicComboBranches;
        ObservableCollection<Pos> dynamicComboPoss;
        ObservableCollection<Agent> dynamicComboVendors;
        ObservableCollection<User> dynamicComboUsers;
        ObservableCollection<ItemUnitCombo> dynamicComboItem;
        ObservableCollection<CouponCombo> dynamicComboCoupon;
        ObservableCollection<OfferCombo> dynamicComboOffer;

        Branch branchModel = new Branch();
        Pos posModel = new Pos();
        Agent agentModel = new Agent();
        User userModel = new User();
        Item itemModel = new Item();
        Coupon couponModel = new Coupon();
        Offer offerModel = new Offer();
        /*************************/

        Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        ObservableCollection<int> selectedBranchId = new ObservableCollection<int>();
        ObservableCollection<int> selectedPosId = new ObservableCollection<int>();
        ObservableCollection<int> selectedVendorsId = new ObservableCollection<int>();
        ObservableCollection<int> selectedUserId = new ObservableCollection<int>();
        ObservableCollection<int> selectedItemId = new ObservableCollection<int>();
        ObservableCollection<int> selectedcouponId = new ObservableCollection<int>();
        ObservableCollection<int> selectedOfferId = new ObservableCollection<int>();

        public string[] Labels { get; set; }

        public string[] Formatter { get; set; }

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

        public uc_saleReport()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Invoices = await statisticModel.GetSaleitemcount();
            rowChartInvoice = await statisticModel.GetSaleitemcount();

            Items = await statisticModel.GetSaleitem();
            rowChartItems = await statisticModel.GetSaleitem();

            coupons = await statisticModel.GetSalecoupon();
            rowChartCoupons = await statisticModel.GetSalecoupon();

            Offers = await statisticModel.GetSaleOffer();
            rowChartOffers = await statisticModel.GetSaleOffer();

            comboBranches = await branchModel.GetAllWithoutMain("b");
            comboPoss = await posModel.GetPosAsync();
            comboVendors = await agentModel.GetAgentsAsync("c");
            comboUsers = await userModel.GetUsersAsync();
            itemUnitCombos = statisticModel.GetIUComboList(Items);
            comboCoupon = statisticModel.GetCopComboList(coupons);
            comboOffer = statisticModel.GetOfferComboList(Offers);

            dynamicComboBranches = new ObservableCollection<Branch>(comboBranches);
            dynamicComboPoss = new ObservableCollection<Pos>(comboPoss);
            dynamicComboVendors = new ObservableCollection<Agent>(comboVendors);
            dynamicComboUsers = new ObservableCollection<User>(comboUsers);
            dynamicComboItem = new ObservableCollection<ItemUnitCombo>(itemUnitCombos);
            dynamicComboCoupon = new ObservableCollection<CouponCombo>(comboCoupon);
            dynamicComboOffer = new ObservableCollection<OfferCombo>(comboOffer);

            fillComboBranches();
            fillComboPos();
            fillComboUsers();
            fillComboVendors();
            fillComboItems();
            fillComboCoupon();
            fillComboOffer();

            chk_invoice.IsChecked = true;
            chk_posInvoice.IsChecked = true;
            chk_vendorsInvoice.IsChecked = true;
            chk_usersInvoice.IsChecked = true;
            chk_itemInvoice.IsChecked = true;
            chk_couponInvoice.IsChecked = true;
            chk_offersInvoice.IsChecked = true;

            fillBranchEvent();
        }

        private void fillComboBranches()
        {
            cb_branches.SelectedValuePath = "branchId";
            cb_branches.DisplayMemberPath = "name";
            cb_branches.ItemsSource = dynamicComboBranches;
        }

        private void fillComboPos()
        {
            cb_pos.SelectedValuePath = "posId";
            cb_pos.DisplayMemberPath = "name";
            cb_pos.ItemsSource = dynamicComboPoss;
        }

        private void fillComboVendors()
        {
            cb_vendors.SelectedValuePath = "agentId";
            cb_vendors.DisplayMemberPath = "name";
            cb_vendors.ItemsSource = dynamicComboVendors;
        }

        private void fillComboUsers()
        {
            cb_users.SelectedValuePath = "userId";
            cb_users.DisplayMemberPath = "username";
            cb_users.ItemsSource = dynamicComboUsers;
        }

        private void fillComboItems()
        {
            cb_Items.SelectedValuePath = "itemUnitId";
            cb_Items.DisplayMemberPath = "itemUnitName";
            cb_Items.ItemsSource = dynamicComboItem;
        }

        private void fillComboCoupon()
        {
            cb_Coupons.SelectedValuePath = "Copcid";
            cb_Coupons.DisplayMemberPath = "Copname";
            cb_Coupons.ItemsSource = dynamicComboCoupon;
        }

        private void fillComboOffer()
        {
            cb_offers.SelectedValuePath = "OofferId";
            cb_offers.DisplayMemberPath = "Oname";
            cb_offers.ItemsSource = dynamicComboOffer;
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

        private IEnumerable<ItemTransferInvoice> fillList(IEnumerable<ItemTransferInvoice> Invoices, CheckBox chkInvoice, CheckBox chkReturn, CheckBox chkDraft
           , DatePicker startDate, DatePicker endDate, TimePicker startTime, TimePicker endTime)
        {
            fillDates(startDate, endDate, startTime, endTime);
            var result = Invoices.Where(x => (
            (txt_search.Text != null ? x.invNumber.Contains(txt_search.Text)
              || x.invType.Contains(txt_search.Text)
              || x.discountType.Contains(txt_search.Text) : true)
              && ((chkDraft.IsChecked == true ? (x.invType == "sd" || x.invType == "sbd") : false)
                          || (chkReturn.IsChecked == true ? (x.invType == "sb") : false)
                          || (chkInvoice.IsChecked == true ? (x.invType == "s") : false))
                      && (startDate.SelectedDate != null ? x.invDate >= startDate.SelectedDate : true)
                      && (endDate.SelectedDate != null ? x.invDate <= endDate.SelectedDate : true)
                      && (startTime.SelectedTime != null ? x.invDate >= startTime.SelectedTime : true)
                      && (endTime.SelectedTime != null ? x.invDate <= endTime.SelectedTime : true)));
            return result;
        }

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
            return result;
        }

        private void fillPieChart(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            List<string> titles = new List<string>();
            IEnumerable<int> x = null;
            if (selectedTab == 0)
            {
                var temp = fillList(Invoices, chk_invoice, chk_return, chk_drafs, dp_startDate, dp_endDate, dt_startTime, dt_endTime);
                temp = temp.Where(j => (selectedBranchId.Count != 0 ? stackedButton.Contains((int)j.branchCreatorId) : true));
                var titleTemp = temp.GroupBy(m => m.branchCreatorName);
                titles.AddRange(titleTemp.Select(jj => jj.Key));
                var result = temp.GroupBy(s => s.branchCreatorId).Select(s => new { branchCreatorId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }
            else if (selectedTab == 1)
            {
                var temp = fillList(Invoices, chk_posInvoice, chk_posReturn, chk_posDraft, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime);
                temp = temp.Where(j => (selectedPosId.Count != 0 ? stackedButton.Contains((int)j.posId) : true));
                var titleTemp = temp.GroupBy(m => new { m.posName, m.posId });
                titles.AddRange(titleTemp.Select(jj => jj.Key.posName));
                var result = temp.GroupBy(s => s.posId).Select(s => new { posId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }
            else if (selectedTab == 2)
            {
                var temp = fillList(Invoices, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime);
                temp = temp.Where(j => (selectedVendorsId.Count != 0 ? stackedButton.Contains((int)j.agentId) : true));
                var titleTemp = temp.GroupBy(m => m.agentName);
                titles.AddRange(titleTemp.Select(jj => jj.Key));
                var result = temp.GroupBy(s => s.agentId).Select(s => new { agentId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }
            else if (selectedTab == 3)
            {
                var temp = fillList(Invoices, chk_usersInvoice, chk_usersReturn, chk_usersDraft, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime);
                temp = temp.Where(j => (selectedUserId.Count != 0 ? stackedButton.Contains((int)j.updateUserId) : true));
                var titleTemp = temp.GroupBy(m => m.cUserAccName);
                titles.AddRange(titleTemp.Select(jj => jj.Key));
                var result = temp.GroupBy(s => s.updateUserId).Select(s => new { updateUserId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }
            else if (selectedTab == 4)
            {
                titles.Clear();
                var temp = fillList(Items, chk_itemInvoice, chk_itemReturn, chk_itemDrafs, dp_ItemStartDate, dp_ItemEndDate, dt_itemStartTime, dt_ItemEndTime);
                temp = temp.Where(j => (selectedItemId.Count != 0 ? stackedButton.Contains((int)j.ITitemUnitId) : true));
                var titleTemp = temp.GroupBy(jj => jj.ITitemUnitId)
                 .Select(g => new  ItemUnitCombo{ itemUnitId =(int) g.FirstOrDefault().ITitemUnitId, itemUnitName = g.FirstOrDefault().ITitemName + "-"+g.FirstOrDefault().ITunitName }).ToList();
                //var titleTemp = temp.GroupBy(m => m.ITitemName);
                titles.AddRange(titleTemp.Select(jj => jj.itemUnitName));
                var result = temp.GroupBy(s => s.ITitemUnitId).Select(s => new { ITitemUnitId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }

            else if (selectedTab == 5)
            {
                titles.Clear();
                var temp = fillList(coupons, chk_couponInvoice, chk_couponReturn, chk_couponDrafs, dp_couponStartDate, dp_couponEndDate, dt_couponStartTime, dt_couponEndTime);
                temp = temp.Where(j => (selectedcouponId.Count != 0 ? stackedButton.Contains((int)j.CopcId) : true));
                var titleTemp = temp.GroupBy(m => m.Copname);
                titles.AddRange(titleTemp.Select(jj => jj.Key));
                var result = temp.GroupBy(s => s.CopcId).Select(s => new { CopcId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }

            else if (selectedTab == 6)
            {
                titles.Clear();
                var temp = fillList(Offers, chk_offersInvoice, chk_offersReturn, chk_offersDrafs, dp_offersStartDate, dp_offersEndDate, dt_offersStartTime, dt_offersEndTime);
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

        private void fillColumnChart(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<int> x = null;
            IEnumerable<int> y = null;
            IEnumerable<int> z = null;
            if (selectedTab == 0)
            {
                var temp = fillList(Invoices, chk_invoice, chk_return, chk_drafs, dp_startDate, dp_endDate, dt_startTime, dt_endTime);
                temp = temp.Where(j => (selectedBranchId.Count != 0 ? stackedButton.Contains((int)j.branchCreatorId) : true));
                var result = temp.GroupBy(s => s.branchCreatorId).Select(s => new
                {
                    branchCreatorId = s.Key,
                    countP = s.Where(m => m.invType == "s").Count(),
                    countPb = s.Where(m => m.invType == "sb").Count(),
                    countD = s.Where(m => m.invType == "sd" || m.invType == "sbd").Count()
                });
                x = result.Select(m => m.countP);
                y = result.Select(m => m.countPb);
                z = result.Select(m => m.countD);
                var tempName = temp.GroupBy(s => s.branchCreatorName).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }
            else if (selectedTab == 1)
            {
                var temp = fillList(Invoices, chk_posInvoice, chk_posReturn, chk_posDraft, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime);
                temp = temp.Where(j => (selectedPosId.Count != 0 ? stackedButton.Contains((int)j.posId) : true));
                var result = temp.GroupBy(s => s.posId).Select(s => new
                {
                    posId = s.Key,
                    countP = s.Where(m => m.invType == "s").Count(),
                    countPb = s.Where(m => m.invType == "sb").Count(),
                    countD = s.Where(m => m.invType == "sd" || m.invType == "sbd").Count()
                });
                x = result.Select(m => m.countP);
                y = result.Select(m => m.countPb);
                z = result.Select(m => m.countD);
                var tempName = temp.GroupBy(s => s.posName).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }
            else if (selectedTab == 2)
            {
                var temp = fillList(Invoices, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime);
                temp = temp.Where(j => (selectedVendorsId.Count != 0 ? stackedButton.Contains((int)j.agentId) : true));
                var result = temp.GroupBy(s => s.agentId).Select(s => new
                {
                    agentId = s.Key,
                    countP = s.Where(m => m.invType == "s").Count(),
                    countPb = s.Where(m => m.invType == "sb").Count(),
                    countD = s.Where(m => m.invType == "sd" || m.invType == "sbd").Count()

                });
                x = result.Select(m => m.countP);
                y = result.Select(m => m.countPb);
                z = result.Select(m => m.countD);
                var tempName = temp.GroupBy(s => s.agentName).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }
            else if (selectedTab == 3)
            {
                var temp = fillList(Invoices, chk_usersInvoice, chk_usersReturn, chk_usersDraft, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime);
                temp = temp.Where(j => (selectedUserId.Count != 0 ? stackedButton.Contains((int)j.updateUserId) : true));
                var result = temp.GroupBy(s => s.updateUserId).Select(s => new
                {
                    updateUserId = s.Key,
                    countP = s.Where(m => m.invType == "s").Count(),
                    countPb = s.Where(m => m.invType == "sb").Count(),
                    countD = s.Where(m => m.invType == "sd" || m.invType == "sbd").Count()

                });
                x = result.Select(m => m.countP);
                y = result.Select(m => m.countPb);
                z = result.Select(m => m.countD);
                var tempName = temp.GroupBy(s => s.uUserAccName).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }
            else if (selectedTab == 4)
            {
                var temp = fillList(Items, chk_itemInvoice, chk_itemReturn, chk_itemDrafs, dp_ItemStartDate, dp_ItemEndDate, dt_itemStartTime, dt_ItemEndTime);
                temp = temp.Where(j => (selectedItemId.Count != 0 ? stackedButton.Contains((int)j.ITitemUnitId) : true));
                var result = temp.GroupBy(s => s.ITitemUnitId).Select(s => new
                {
                    ITitemUnitId = s.Key,
                    countP = s.Where(m => m.invType == "s").Count(),
                    countPb = s.Where(m => m.invType == "sb").Count(),
                    countD = s.Where(m => m.invType == "sd" || m.invType == "sbd").Count()

                });
                x = result.Select(m => m.countP);
                y = result.Select(m => m.countPb);
                z = result.Select(m => m.countD);
                var tempName = temp.GroupBy(jj => jj.ITitemUnitId)
                 .Select(g => new ItemUnitCombo { itemUnitId = (int)g.FirstOrDefault().ITitemUnitId, itemUnitName = g.FirstOrDefault().ITitemName + "-" + g.FirstOrDefault().ITunitName }).ToList();
                names.AddRange(tempName.Select(nn => nn.itemUnitName));
            }

            else if (selectedTab == 5)
            {
                var temp = fillList(coupons, chk_couponInvoice, chk_couponReturn, chk_couponDrafs, dp_couponStartDate, dp_couponEndDate, dt_couponStartTime, dt_couponEndTime);
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

            else if (selectedTab == 6)
            {
                var temp = fillList(Offers, chk_offersInvoice, chk_offersReturn, chk_offersDrafs, dp_offersStartDate, dp_offersEndDate, dt_offersStartTime, dt_offersEndTime);
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
                "مبيعات","مرتجع","مسودة"
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

        private void fillRowChart(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<decimal> pTemp = null;
            IEnumerable<decimal> pbTemp = null;
            IEnumerable<decimal> resultTemp = null;

            if (selectedTab == 0)
            {
                var temp = fillRowChartList(Invoices, chk_invoice, chk_return, chk_drafs, dp_startDate, dp_endDate, dt_startTime, dt_endTime);
                temp = temp.Where(j => (selectedBranchId.Count != 0 ? stackedButton.Contains((int)j.branchCreatorId) : true));
                var result = temp.GroupBy(s => s.branchCreatorId).Select(s => new
                {
                    branchCreatorId = s.Key,
                    totalP = s.Where(x => x.invType == "s").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "sb").Sum(x => x.totalNet)
                }
                        
             );
                var resultTotal = result.Select(x => new { x.branchCreatorId, total = x.totalP - x.totalPb }).ToList();
                pTemp = result.Select(x => (decimal)x.totalP);
                pbTemp = result.Select(x => (decimal)x.totalPb);
                resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
                var tempName = temp.GroupBy(s => s.branchCreatorName).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }
            if (selectedTab == 1)
            {
                var temp = fillRowChartList(Invoices, chk_posInvoice, chk_posReturn, chk_posDraft, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime);
                temp = temp.Where(j => (selectedPosId.Count != 0 ? stackedButton.Contains((int)j.posId) : true));
                var result = temp.GroupBy(s => s.posId).Select(s => new
                {
                    posId = s.Key,
                    totalP = s.Where(x => x.invType == "s").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "sb").Sum(x => x.totalNet)
                }
             );
                var resultTotal = result.Select(x => new { x.posId, total = x.totalP - x.totalPb }).ToList();
                pTemp = result.Select(x => (decimal)x.totalP);
                pbTemp = result.Select(x => (decimal)x.totalPb);
                resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
                var tempName = temp.GroupBy(s => s.posName).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }
            if (selectedTab == 2)
            {
                var temp = fillRowChartList(Invoices, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime);
                temp = temp.Where(j => (selectedVendorsId.Count != 0 ? stackedButton.Contains((int)j.agentId) : true));
                var result = temp.GroupBy(s => s.agentId).Select(s => new
                {
                    agentId = s.Key,
                    totalP = s.Where(x => x.invType == "s").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "sb").Sum(x => x.totalNet)
                }
             );
                var resultTotal = result.Select(x => new { x.agentId, total = x.totalP - x.totalPb }).ToList();
                pTemp = result.Select(x => (decimal)x.totalP);
                pbTemp = result.Select(x => (decimal)x.totalPb);
                resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
                var tempName = temp.GroupBy(s => s.agentName).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }
            if (selectedTab == 3)
            {
                var temp = fillRowChartList(Invoices, chk_usersInvoice, chk_usersReturn, chk_usersDraft, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime);
                temp = temp.Where(j => (selectedUserId.Count != 0 ? stackedButton.Contains((int)j.updateUserId) : true));
                var result = temp.GroupBy(s => s.updateUserId).Select(s => new
                {
                    updateUserId = s.Key,
                    totalP = s.Where(x => x.invType == "s").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "sb").Sum(x => x.totalNet)
                }
             );
                var resultTotal = result.Select(x => new { x.updateUserId, total = x.totalP - x.totalPb }).ToList();
                pTemp = result.Select(x => (decimal)x.totalP);
                pbTemp = result.Select(x => (decimal)x.totalPb);
                resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
                var tempName = temp.GroupBy(s => s.uUserAccName).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }
            if (selectedTab == 4)
            {
                var temp = fillRowChartList(Items, chk_itemInvoice, chk_itemReturn, chk_itemDrafs, dp_ItemStartDate, dp_ItemEndDate, dt_itemStartTime, dt_ItemEndTime);
                temp = temp.Where(j => (selectedItemId.Count != 0 ? stackedButton.Contains((int)j.ITitemUnitId) : true));
                var result = temp.GroupBy(s => s.ITitemUnitId).Select(s => new
                {
                    ITitemUnitId = s.Key,
                    totalP = s.Where(x => x.invType == "s").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "sb").Sum(x => x.totalNet),
                   
                }
             );
                var resultTotal = result.Select(x => new { x.ITitemUnitId, total = x.totalP - x.totalPb }).ToList();
                pTemp = result.Select(x => (decimal)x.totalP);
                pbTemp = result.Select(x => (decimal)x.totalPb);
                resultTemp = result.Select(x => (decimal)x.totalP-(decimal)x.totalPb);
                var tempName = temp.GroupBy(jj => jj.ITitemUnitId)
                 .Select(g => new ItemUnitCombo { itemUnitId = (int)g.FirstOrDefault().ITitemUnitId, itemUnitName = g.FirstOrDefault().ITitemName + "-" + g.FirstOrDefault().ITunitName }).ToList();
                names.AddRange(tempName.Select(nn => nn.itemUnitName));
            }

            if (selectedTab == 5)
            {
                var temp = fillRowChartList(coupons, chk_couponInvoice, chk_couponReturn, chk_couponDrafs, dp_couponStartDate, dp_couponEndDate, dt_couponStartTime, dt_couponEndTime);
                temp = temp.Where(j => (selectedcouponId.Count != 0 ? stackedButton.Contains((int)j.CopcId) : true));
                var result = temp.GroupBy(s => s.CopcId).Select(s => new
                {
                    CopcId = s.Key,
                    totalP = s.Where(x => x.invType == "s").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "sb").Sum(x => x.totalNet)
                }
             );
                var resultTotal = result.Select(x => new { x.CopcId, total = x.totalP - x.totalPb }).ToList();
                pTemp = result.Select(x => (decimal)x.totalP);
                pbTemp = result.Select(x => (decimal)x.totalPb);
                resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
                var tempName = temp.GroupBy(s => s.Copname).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }

            if (selectedTab == 6)
            {
                var temp = fillRowChartList(Offers, chk_offersInvoice, chk_offersReturn, chk_offersDrafs, dp_offersStartDate, dp_offersEndDate, dt_offersStartTime, dt_offersEndTime);
                temp = temp.Where(j => (selectedOfferId.Count != 0 ? stackedButton.Contains((int)j.OofferId) : true));
                var result = temp.GroupBy(s => s.OofferId).Select(s => new
                {
                    OofferId = s.Key,
                    totalP = s.Where(x => x.invType == "s").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "sb").Sum(x => x.totalNet)
                }
             );
                var resultTotal = result.Select(x => new { x.OofferId, total = x.totalP - x.totalPb }).ToList();
                pTemp = result.Select(x => (decimal)x.totalP);
                pbTemp = result.Select(x => (decimal)x.totalPb);
                resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
                var tempName = temp.GroupBy(s => s.Oname).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }

            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            List<string> titles = new List<string>()
            {
                "اجمالي المبيعات","اجمالي المبيعات","صافي المبيعات"
            };
            for (int i = 0; i < pTemp.Count(); i++)
            {
                purchase.Add(pTemp.ToList().Skip(i).FirstOrDefault());
                returns.Add(pbTemp.ToList().Skip(i).FirstOrDefault());
                sub.Add(resultTemp.ToList().Skip(i).FirstOrDefault());
                MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = purchase.AsChartValues(),
              Title = titles[0]
          });
            rowChartData.Add(
         new LineSeries
         {
             Values = returns.AsChartValues(),
             Title = titles[1]
         });
            rowChartData.Add(
        new LineSeries
        {
            Values = sub.AsChartValues(),
            Title = titles[2]

        });
            DataContext = this;
            rowChart.Series = rowChartData;
        }

        public void fillBranchEvent()
        {
            var temp = fillList(Invoices, chk_invoice, chk_return, chk_drafs, dp_startDate, dp_endDate, dt_startTime, dt_endTime);
            dgInvoice.ItemsSource = temp.Where(j => (selectedBranchId.Count != 0 ? selectedBranchId.Contains((int)j.branchCreatorId) : true));
            fillPieChart(cb_branches, selectedBranchId);
            fillColumnChart(cb_branches, selectedBranchId);
            fillRowChart(cb_branches, selectedBranchId);
        }

        public void fillPosEvent()
        {
            var temp = fillList(Invoices, chk_posInvoice, chk_posReturn, chk_posDraft, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime);
            dgInvoice.ItemsSource = temp.Where(j => (selectedPosId.Count != 0 ? selectedPosId.Contains((int)j.posId) : true));
            fillRowChart(cb_pos, selectedPosId);
            fillPieChart(cb_pos, selectedPosId);
            fillColumnChart(cb_pos, selectedPosId);
        }

        public void fillVendorsEvent()
        {
            var temp = fillList(Invoices, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime);
            dgInvoice.ItemsSource = temp.Where(j => (selectedVendorsId.Count != 0 ? selectedVendorsId.Contains((int)j.agentId) : true));
            fillPieChart(cb_vendors, selectedVendorsId);
            fillColumnChart(cb_vendors, selectedVendorsId);
            fillRowChart(cb_vendors, selectedVendorsId);
        }

        public void fillUsersEvent()
        {
            var temp = fillList(Invoices, chk_usersInvoice, chk_usersReturn, chk_usersDraft, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime);
            dgInvoice.ItemsSource = temp.Where(j => (selectedUserId.Count != 0 ? selectedUserId.Contains((int)j.updateUserId) : true));
            fillPieChart(cb_users, selectedUserId);
            fillColumnChart(cb_users, selectedUserId);
            fillRowChart(cb_users, selectedUserId);
        }

        public void fillItemsEvent()
        {
            var temp = fillList(Items, chk_itemInvoice, chk_itemReturn, chk_itemDrafs, dp_ItemStartDate, dp_ItemEndDate, dt_itemStartTime, dt_ItemEndTime);
            dgInvoice.ItemsSource = temp.Where(j => (selectedItemId.Count != 0 ? selectedItemId.Contains((int)j.ITitemUnitId) : true));
            fillPieChart(cb_Items, selectedItemId);
            fillColumnChart(cb_Items, selectedItemId);
            fillRowChart(cb_Items, selectedItemId);
        }
        public void fillCouponsEvent()
        {
            var temp = fillList(coupons, chk_couponInvoice, chk_couponReturn, chk_couponDrafs, dp_couponStartDate, dp_couponEndDate, dt_couponStartTime, dt_couponEndTime);
            dgInvoice.ItemsSource = temp.Where(j => (selectedcouponId.Count != 0 ? selectedcouponId.Contains((int)j.CopcId) : true));
            fillPieChart(cb_Coupons, selectedcouponId);
            fillColumnChart(cb_Coupons, selectedcouponId);
            fillRowChart(cb_Coupons, selectedcouponId);
        }

        public void fillOffersEvent()
        {
            var temp = fillList(Offers, chk_offersInvoice, chk_offersReturn, chk_offersDrafs, dp_offersStartDate, dp_offersEndDate, dt_offersStartTime, dt_offersEndTime);
            dgInvoice.ItemsSource = temp.Where(j => (selectedOfferId.Count != 0 ? selectedOfferId.Contains((int)j.OofferId) : true));
            fillPieChart(cb_offers, selectedOfferId);
            fillColumnChart(cb_offers, selectedOfferId);
            fillRowChart(cb_offers, selectedOfferId);
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
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            bdr_branch.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_pos.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_vendors.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_users.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_items.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_coupon.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_offers.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_branch.Fill = Brushes.White;
            path_pos.Fill = Brushes.White;
            path_vendors.Fill = Brushes.White;
            path_users.Fill = Brushes.White;
            path_items.Fill = Brushes.White;
            path_coupons.Fill = Brushes.White;
            path_offers.Fill = Brushes.White;

            grid_branch.Visibility = Visibility.Hidden;
            grid_pos.Visibility = Visibility.Hidden;
            grid_vendors.Visibility = Visibility.Hidden;
            grid_users.Visibility = Visibility.Hidden;
            grid_items.Visibility = Visibility.Hidden;
            grid_coupons.Visibility = Visibility.Hidden;
            grid_offers.Visibility = Visibility.Hidden;

            col_branch.Visibility = Visibility.Collapsed;
            col_item.Visibility = Visibility.Collapsed;
            col_pos.Visibility = Visibility.Collapsed;
            col_user.Visibility = Visibility.Collapsed;
            col_vendor.Visibility = Visibility.Collapsed;
            col_coupon.Visibility = Visibility.Collapsed;
            col_offers.Visibility = Visibility.Collapsed;
            col_quantity.Visibility = Visibility.Collapsed;
            col_count.Visibility = Visibility.Visible;
        }

        private void isEnabledButtons()
        {
            btn_branch.IsEnabled = true;
            btn_pos.IsEnabled = true;
            btn_vendors.IsEnabled = true;
            btn_users.IsEnabled = true;
            btn_items.IsEnabled = true;
            btn_coupons.IsEnabled = true;
            btn_offers.IsEnabled = true;
        }
        #endregion

        #region Events
        #region tabControl
        private void btn_branch_Click(object sender, RoutedEventArgs e)
        {
            txt_search.Text = "";
            hideSatacks();
            stk_tagsBranches.Visibility = Visibility.Visible;
            selectedTab = 0;
            paint();
            col_branch.Visibility = Visibility.Visible;
            bdr_branch.Background = Brushes.White;
            path_branch.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_branch.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_branch.IsEnabled = false;
            btn_branch.Opacity = 1;
            fillBranchEvent();
        }

        private void btn_pos_Click(object sender, RoutedEventArgs e)
        {
            txt_search.Text = "";
            hideSatacks();
            stk_tagsPos.Visibility = Visibility.Visible;
            selectedTab = 1;
            paint();
            col_pos.Visibility = Visibility.Visible;
            col_branch.Visibility = Visibility.Visible;
            bdr_pos.Background = Brushes.White;
            path_pos.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_pos.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_pos.IsEnabled = false;
            btn_pos.Opacity = 1;
            fillPosEvent();
        }

        private void btn_vendors_Click(object sender, RoutedEventArgs e)
        {
            txt_search.Text = "";
            hideSatacks();
            stk_tagsVendors.Visibility = Visibility.Visible;
            selectedTab = 2;
            paint();
            col_vendor.Visibility = Visibility.Visible;
            bdr_vendors.Background = Brushes.White;
            path_vendors.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_vendors.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_vendors.IsEnabled = false;
            btn_vendors.Opacity = 1;
            fillVendorsEvent();
        }

        private void btn_users_Click(object sender, RoutedEventArgs e)
        {
            txt_search.Text = "";
            hideSatacks();
            stk_tagsUsers.Visibility = Visibility.Visible;
            selectedTab = 3;
            paint();
            col_user.Visibility = Visibility.Visible;
            bdr_users.Background = Brushes.White;
            path_users.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_users.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_users.IsEnabled = false;
            btn_users.Opacity = 1;
            fillUsersEvent();
        }

        private void btn_items_Click(object sender, RoutedEventArgs e)
        {
            txt_search.Text = "";
            hideSatacks();
            stk_tagsItems.Visibility = Visibility.Visible;
            selectedTab = 4;
            paint();
            col_item.Visibility = Visibility.Visible;
            bdr_items.Background = Brushes.White;
            path_items.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_items.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_items.IsEnabled = false;
            btn_items.Opacity = 1;
            fillItemsEvent();
        }

        private void btn_coupons_Click(object sender, RoutedEventArgs e)
        {
            txt_search.Text = "";
            hideSatacks();
            stk_tagsCoupons.Visibility = Visibility.Visible;
            selectedTab = 5;
            paint();
            col_coupon.Visibility = Visibility.Visible;
            bdr_coupon.Background = Brushes.White;
            path_coupons.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_coupons.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_coupons.IsEnabled = false;
            btn_coupons.Opacity = 1;
            fillCouponsEvent();

        }
        private void btn_offers_Click(object sender, RoutedEventArgs e)
        {
            txt_search.Text = "";
            hideSatacks();
            stk_tagsOffers.Visibility = Visibility.Visible;
            selectedTab = 6;
            paint();
            col_offers.Visibility = Visibility.Visible;
            col_item.Visibility = Visibility.Visible;
            col_quantity.Visibility = Visibility.Visible;
            col_count.Visibility=Visibility.Collapsed;
            bdr_offers.Background = Brushes.White;
            path_offers.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_offers.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_offers.IsEnabled = false;
            btn_offers.Opacity = 1;
            fillOffersEvent();
        }
        #endregion

        #region refreshButton
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTab == 0)
            {
                cb_branches.SelectedItem = null;
                chk_drafs.IsChecked = false;
                chk_return.IsChecked = false;
                chk_invoice.IsChecked = true;
                dp_endDate.SelectedDate = null;
                dp_startDate.SelectedDate = null;
                dt_startTime.SelectedTime = null;
                dt_endTime.SelectedTime = null;
                chk_allBranches.IsChecked = false;
                cb_branches.IsEnabled = true;
                for (int i = 0; i < comboBrachTemp.Count; i++)
                {
                    dynamicComboBranches.Add(comboBrachTemp.Skip(i).FirstOrDefault());
                }
                comboBrachTemp.Clear();
                stk_tagsBranches.Children.Clear();
                selectedBranchId.Clear();
                fillBranchEvent();
            }

            else if (selectedTab == 1)
            {
                cb_pos.SelectedItem = null;
                chk_posDraft.IsChecked = false;
                chk_posReturn.IsChecked = false;
                chk_posInvoice.IsChecked = true;
                dp_posEndDate.SelectedDate = null;
                dp_posStartDate.SelectedDate = null;
                dt_posStartTime.SelectedTime = null;
                dt_posEndTime.SelectedTime = null;
                chk_allPos.IsChecked = false;
                cb_pos.IsEnabled = true;
                for (int i = 0; i < comboPosTemp.Count; i++)
                {
                    dynamicComboPoss.Add(comboPosTemp.Skip(i).FirstOrDefault());
                }
                comboPosTemp.Clear();
                stk_tagsPos.Children.Clear();
                selectedPosId.Clear();
                fillPosEvent();
            }

            else if (selectedTab == 2)
            {
                cb_vendors.SelectedItem = null;
                chk_vendorsDraft.IsChecked = false;
                chk_vendorsReturn.IsChecked = false;
                chk_vendorsInvoice.IsChecked = true;
                dp_vendorsEndDate.SelectedDate = null;
                dp_vendorsStartDate.SelectedDate = null;
                dt_vendorsStartTime.SelectedTime = null;
                dt_vendorsEndTime.SelectedTime = null;
                chk_allVendors.IsChecked = false;
                cb_vendors.IsEnabled = true;
                for (int i = 0; i < comboVendorTemp.Count; i++)
                {
                    dynamicComboVendors.Add(comboVendorTemp.Skip(i).FirstOrDefault());
                }
                comboVendorTemp.Clear();
                stk_tagsVendors.Children.Clear();
                selectedVendorsId.Clear();
                fillVendorsEvent();

            }

            else if (selectedTab == 3)
            {
                cb_users.SelectedItem = null;
                chk_usersDraft.IsChecked = false;
                chk_usersReturn.IsChecked = false;
                chk_usersInvoice.IsChecked = true;
                dp_usersEndDate.SelectedDate = null;
                dp_usersStartDate.SelectedDate = null;
                dt_usersStartTime.SelectedTime = null;
                dt_usersEndTime.SelectedTime = null;
                chk_allUsers.IsChecked = false;
                cb_users.IsEnabled = true;
                for (int i = 0; i < comboUserTemp.Count; i++)
                {
                    dynamicComboUsers.Add(comboUserTemp.Skip(i).FirstOrDefault());
                }
                comboUserTemp.Clear();
                stk_tagsUsers.Children.Clear();
                selectedUserId.Clear();
                fillUsersEvent();

            }
            else if (selectedTab == 4)
            {
                cb_Items.SelectedItem = null;
                chk_itemDrafs.IsChecked = false;
                chk_itemReturn.IsChecked = false;
                chk_itemInvoice.IsChecked = true;
                dp_ItemEndDate.SelectedDate = null;
                dp_ItemStartDate.SelectedDate = null;
                dt_itemStartTime.SelectedTime = null;
                dt_ItemEndTime.SelectedTime = null;
                chk_allItems.IsChecked = false;
                cb_Items.IsEnabled = true;
                for (int i = 0; i < comboItemTemp.Count; i++)
                {
                    dynamicComboItem.Add(comboItemTemp.Skip(i).FirstOrDefault());
                }
                comboItemTemp.Clear();
                stk_tagsItems.Children.Clear();
                selectedItemId.Clear();
                fillItemsEvent();
            }
            else if (selectedTab == 5)
            {
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
                for (int i = 0; i < comboCouponTemp.Count; i++)
                {
                    dynamicComboCoupon.Add(comboCouponTemp.Skip(i).FirstOrDefault());
                }
                comboCouponTemp.Clear();
                stk_tagsCoupons.Children.Clear();
                selectedcouponId.Clear();
                fillCouponsEvent();
            }

            else if (selectedTab == 6)
            {
                cb_offers.SelectedItem = null;
                chk_offersDrafs.IsChecked = false;
                chk_offersReturn.IsChecked = false;
                chk_offersInvoice.IsChecked = true;
                dp_offersEndDate.SelectedDate = null;
                dp_offersStartDate.SelectedDate = null;
                dt_offersStartTime.SelectedTime = null;
                dt_offersEndTime.SelectedTime = null;
                chk_allOffers.IsChecked = false;
                cb_offers.IsEnabled = true;
                for (int i = 0; i < comboOfferTemp.Count; i++)
                {
                    dynamicComboOffer.Add(comboOfferTemp.Skip(i).FirstOrDefault());
                }
                comboOfferTemp.Clear();
                stk_tagsOffers.Children.Clear();
                selectedOfferId.Clear();
                fillOffersEvent();
            }
            txt_search.Text = "";
        }
        #endregion

        #region branchesEvents
        private void chk_invoice_Checked(object sender, RoutedEventArgs e)
        {
            fillBranchEvent();
        }

        private void chk_return_Checked(object sender, RoutedEventArgs e)
        {
            fillBranchEvent();
        }

        private void chk_drafs_Checked(object sender, RoutedEventArgs e)
        {
            fillBranchEvent();
        }

        private void chk_invoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillBranchEvent();
        }

        private void chk_return_Unchecked(object sender, RoutedEventArgs e)
        {
            fillBranchEvent();
        }

        private void chk_drafs_Unchecked(object sender, RoutedEventArgs e)
        {
            fillBranchEvent();
        }

        private void dp_startDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillBranchEvent();
        }

        private void dp_endDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillBranchEvent();
        }

        private void dt_startTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillBranchEvent();
        }

        private void dp_endTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillBranchEvent();
        }


        #endregion

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (selectedTab == 0)
            {
                fillBranchEvent();
            }
            if (selectedTab == 1)
            {
                fillPosEvent();
            }
            if (selectedTab == 2)
            {
                fillVendorsEvent();
            }
            if (selectedTab == 3)
            {
                fillUsersEvent();
            }
            if (selectedTab == 4)
            {
                fillItemsEvent();
            }
            if (selectedTab == 5)
            {
                fillCouponsEvent();
            }
            if (selectedTab == 6)
            {
                fillCouponsEvent();
            }
        }

        #region posEvents
        private void chk_posInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillPosEvent();
        }

        private void chk_posReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillPosEvent();
        }

        private void chk_posDrafs_Checked(object sender, RoutedEventArgs e)
        {
            fillPosEvent();
        }

        private void chk_posInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPosEvent();
        }

        private void chk_posReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPosEvent();
        }

        private void chk_posDrafs_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPosEvent();
        }

        private void dp_posStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPosEvent();
        }

        private void dp_posEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPosEvent();
        }

        private void dt_posStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillPosEvent();
        }

        private void dt_posEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillPosEvent();
        }
        #endregion

        #region vendorsEvents
        private void chk_vendorsInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillVendorsEvent();
        }

        private void chk_vendorsReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillVendorsEvent();
        }

        private void chk_vendorsDraft_Checked(object sender, RoutedEventArgs e)
        {
            fillVendorsEvent();
        }

        private void chk_vendorsInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillVendorsEvent();
        }

        private void chk_vendorsReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillVendorsEvent();
        }

        private void chk_vendorsDraft_Unchecked(object sender, RoutedEventArgs e)
        {
            fillVendorsEvent();
        }

        private void dp_vendorsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillVendorsEvent();
        }

        private void dp_vendorsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillVendorsEvent();
        }

        private void dt_vendorsStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillVendorsEvent();
        }

        private void dt_vendorsEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillVendorsEvent();
        }
        #endregion

        #region usersEvents
        private void chk_usersInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillUsersEvent();
        }

        private void chk_usersReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillUsersEvent();
        }

        private void chk_usersDraft_Checked(object sender, RoutedEventArgs e)
        {
            fillUsersEvent();
        }

        private void chk_usersInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillUsersEvent();
        }

        private void chk_usersReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillUsersEvent();
        }

        private void chk_usersDraft_Unchecked(object sender, RoutedEventArgs e)
        {
            fillUsersEvent();
        }

        private void dp_usersStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillUsersEvent();
        }

        private void dp_usersEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillUsersEvent();
        }



        private void dt_usersEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillUsersEvent();
        }

        private void dt_usersStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillUsersEvent();
        }
        #endregion

        #region settings
        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {
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

        }

        #endregion

        #endregion

        private void Chip_OnDeleteClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            stk_tagsBranches.Children.Remove(currentChip);
            var m = comboBrachTemp.Where(j => j.branchId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
            dynamicComboBranches.Add(m.FirstOrDefault());
            selectedBranchId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedBranchId.Count == 0)
            {
                cb_branches.SelectedItem = null;
            }
            fillBranchEvent();
        }

        private void Chip_OnDeletePosClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            stk_tagsPos.Children.Remove(currentChip);
            var m = comboPosTemp.Where(j => j.posId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
            dynamicComboPoss.Add(m.FirstOrDefault());
            selectedPosId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedPosId.Count == 0)
            {
                cb_pos.SelectedItem = null;
            }
            fillPosEvent();
        }

        private void Chip_OnDeleteVendorClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            stk_tagsVendors.Children.Remove(currentChip);
            var m = comboVendorTemp.Where(j => j.agentId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
            dynamicComboVendors.Add(m.FirstOrDefault());
            selectedVendorsId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedVendorsId.Count == 0)
            {
                cb_vendors.SelectedItem = null;
            }
            fillVendorsEvent();
        }

        private void Chip_OnDeleteUserClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            stk_tagsUsers.Children.Remove(currentChip);
            var m = comboUserTemp.Where(j => j.userId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
            dynamicComboUsers.Add(m.FirstOrDefault());
            selectedUserId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedUserId.Count == 0)
            {
                cb_users.SelectedItem = null;
            }
            fillUsersEvent();
        }

        private void Chip_OnDeleteItemClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            stk_tagsItems.Children.Remove(currentChip);
            var m = comboItemTemp.Where(j => j.itemUnitId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
            dynamicComboItem.Add(m.FirstOrDefault());
            selectedItemId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedItemId.Count == 0)
            {
                cb_Items.SelectedItem = null;
            }
            fillItemsEvent();
        }

        private void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_branches.SelectedItem != null)
            {
                if (stk_tagsBranches.Children.Count < 5)
                {
                    selectedBranch = cb_branches.SelectedItem as Branch;
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = selectedBranch.name,
                        Name = "btn" + selectedBranch.branchId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteClick;
                    stk_tagsBranches.Children.Add(b);
                    comboBrachTemp.Add(selectedBranch);
                    selectedBranchId.Add(selectedBranch.branchId);
                    dynamicComboBranches.Remove(selectedBranch);
                    fillBranchEvent();
                }
            }
        }

        private void cb_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_pos.SelectedItem != null)
            {
                if (stk_tagsPos.Children.Count < 5)
                {
                    selectedPos = cb_pos.SelectedItem as Pos;
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = selectedPos.name,
                        Name = "btn" + selectedPos.posId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeletePosClick;
                    stk_tagsPos.Children.Add(b);
                    comboPosTemp.Add(selectedPos);
                    selectedPosId.Add(selectedPos.posId);
                    dynamicComboPoss.Remove(selectedPos);
                    fillPosEvent();
                }
            }

        }

        private void cb_vendors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_vendors.SelectedItem != null)
            {
                if (stk_tagsVendors.Children.Count < 5)
                {
                    selectedVendor = cb_vendors.SelectedItem as Agent;
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = selectedVendor.name,
                        Name = "btn" + selectedVendor.agentId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteVendorClick;
                    stk_tagsVendors.Children.Add(b);
                    comboVendorTemp.Add(selectedVendor);
                    selectedVendorsId.Add(selectedVendor.agentId);
                    dynamicComboVendors.Remove(selectedVendor);
                    fillVendorsEvent();
                }
            }

        }

     

        private void chk_allBranches_Click(object sender, RoutedEventArgs e)
        {
            if (cb_branches.IsEnabled == true)
            {
                cb_branches.SelectedItem = null;
                cb_branches.IsEnabled = false;
                for (int i = 0; i < comboBrachTemp.Count; i++)
                {
                    dynamicComboBranches.Add(comboBrachTemp.Skip(i).FirstOrDefault());
                }
                comboBrachTemp.Clear();
                stk_tagsBranches.Children.Clear();
                selectedBranchId.Clear();

            }
            else
            {
                cb_branches.IsEnabled = true;
            }
            fillBranchEvent();
        }

        private void chk_allPos_Click(object sender, RoutedEventArgs e)
        {
            if (cb_pos.IsEnabled == true)
            {
                cb_pos.SelectedItem = null;
                cb_pos.IsEnabled = false;
                for (int i = 0; i < comboPosTemp.Count; i++)
                {
                    dynamicComboPoss.Add(comboPosTemp.Skip(i).FirstOrDefault());
                }
                comboPosTemp.Clear();
                stk_tagsPos.Children.Clear();
                selectedPosId.Clear();
            }
            else
            {
                cb_pos.IsEnabled = true;
            }

            fillPosEvent();
        }

        private void chk_allVendors_Click(object sender, RoutedEventArgs e)
        {
            if (cb_vendors.IsEnabled == true)
            {
                cb_vendors.SelectedItem = null;
                cb_vendors.IsEnabled = false;
                for (int i = 0; i < comboVendorTemp.Count; i++)
                {
                    dynamicComboVendors.Add(comboVendorTemp.Skip(i).FirstOrDefault());
                }
                comboVendorTemp.Clear();
                stk_tagsVendors.Children.Clear();
                selectedVendorsId.Clear();
            }
            else
            {
                cb_vendors.IsEnabled = true;
            }

            fillVendorsEvent();
        }

        private void chk_allUsers_Click(object sender, RoutedEventArgs e)
        {
            if (cb_users.IsEnabled == true)
            {
                cb_users.SelectedItem = null;
                cb_users.IsEnabled = false;
                for (int i = 0; i < comboUserTemp.Count; i++)
                {
                    dynamicComboUsers.Add(comboUserTemp.Skip(i).FirstOrDefault());
                }
                comboUserTemp.Clear();
                stk_tagsUsers.Children.Clear();
                selectedUserId.Clear();
            }
            else
            {
                cb_users.IsEnabled = true;
            }

            fillUsersEvent();
        }

        private void cb_Items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cb_Items.SelectedItem != null)
            {
                if (stk_tagsItems.Children.Count < 5)
                {
                    selectedItem = cb_Items.SelectedItem as ItemUnitCombo;
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = selectedItem.itemUnitName,
                        Name = "btn" + selectedItem.itemUnitId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteItemClick;
                    stk_tagsItems.Children.Add(b);
                    comboItemTemp.Add(selectedItem);
                    selectedItemId.Add(selectedItem.itemUnitId);
                    dynamicComboItem.Remove(selectedItem);
                    fillItemsEvent();
                }
            }
        }

        private void chk_allItems_Click(object sender, RoutedEventArgs e)
        {
            if (cb_Items.IsEnabled == true)
            {
                cb_Items.SelectedItem = null;
                cb_Items.IsEnabled = false;
                for (int i = 0; i < comboItemTemp.Count; i++)
                {
                    dynamicComboItem.Add(comboItemTemp.Skip(i).FirstOrDefault());
                }
                comboItemTemp.Clear();
                stk_tagsItems.Children.Clear();
                selectedItemId.Clear();
            }
            else
            {
                cb_Items.IsEnabled = true;
            }

            fillItemsEvent();
        }

        private void chk_itemInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillItemsEvent();
        }

        private void chk_itemInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillItemsEvent();
        }

        private void chk_itemReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillItemsEvent();
        }

        private void chk_itemReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillItemsEvent();
        }

        private void chk_itemDrafs_Checked(object sender, RoutedEventArgs e)
        {
            fillItemsEvent();
        }

        private void chk_itemDrafs_Unchecked(object sender, RoutedEventArgs e)
        {
            fillItemsEvent();
        }

        private void dp_ItemEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillItemsEvent();
        }

        private void dp_ItemStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillItemsEvent();
        }

        private void dt_ItemEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillItemsEvent();
        }

        private void dt_itemStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillItemsEvent();
        }

        private void chk_couponInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillCouponsEvent();
        }

        private void chk_couponInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillCouponsEvent();
        }

        private void chk_couponReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillCouponsEvent();
        }

        private void chk_couponDrafs_Unchecked(object sender, RoutedEventArgs e)
        {
            fillCouponsEvent();
        }

        private void dp_couponEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillCouponsEvent();
        }

        private void dp_couponStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillCouponsEvent();
        }


        private void dt_couponEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillCouponsEvent();
        }

        private void dt_couponStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillCouponsEvent();
        }

        private void Chip_OnDeleteCouponClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            stk_tagsCoupons.Children.Remove(currentChip);
            var m = comboCouponTemp.Where(j => j.Copcid == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
            dynamicComboCoupon.Add(m.FirstOrDefault());
            selectedcouponId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedcouponId.Count == 0)
            {
                cb_Coupons.SelectedItem = null;
            }
            fillCouponsEvent();
        }
      

        private void chk_couponReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillCouponsEvent();
        }

        private void chk_couponDrafs_Checked(object sender, RoutedEventArgs e)
        {
            fillCouponsEvent();
        }


        private void chk_allCoupon_Click(object sender, RoutedEventArgs e)
        {
            if (cb_Coupons.IsEnabled == true)
            {
                cb_Coupons.SelectedItem = null;
                cb_Coupons.IsEnabled = false;
                for (int i = 0; i < comboCouponTemp.Count; i++)
                {
                    dynamicComboCoupon.Add(comboCouponTemp.Skip(i).FirstOrDefault());
                }
                comboCouponTemp.Clear();
                stk_tagsCoupons.Children.Clear();
                selectedcouponId.Clear();
            }
            else
            {
                cb_Coupons.IsEnabled = true;
            }

            fillCouponsEvent();
        }


        private void cb_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_users.SelectedItem != null)
            {
                if (stk_tagsUsers.Children.Count < 5)
                {
                    selectedUser = cb_users.SelectedItem as User;
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = selectedUser.username,
                        Name = "btn" + selectedUser.userId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteUserClick;
                    stk_tagsUsers.Children.Add(b);
                    comboUserTemp.Add(selectedUser);
                    selectedUserId.Add(selectedUser.userId);
                    dynamicComboUsers.Remove(selectedUser);
                    fillUsersEvent();
                }
            }
        }
        private void cb_Coupons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_Coupons.SelectedItem != null)
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
                    b.DeleteClick += Chip_OnDeleteCouponClick;
                    stk_tagsCoupons.Children.Add(b);
                    comboCouponTemp.Add(selectedCouon);
                    selectedcouponId.Add(selectedCouon.Copcid);
                    dynamicComboCoupon.Remove(selectedCouon);
                    fillCouponsEvent();
                }
            }
        }
        private void cb_offers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_offers.SelectedItem != null)
            {
                if (stk_tagsOffers.Children.Count < 5)
                {
                    selectedOffer = cb_offers.SelectedItem as OfferCombo;
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = selectedOffer.Oname,
                        Name = "btn" + selectedOffer.OofferId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteOfferClick;
                    stk_tagsOffers.Children.Add(b);
                    comboOfferTemp.Add(selectedOffer);
                    selectedOfferId.Add(selectedOffer.OofferId);
                    dynamicComboOffer.Remove(selectedOffer);
                    fillOffersEvent();
                }
            }
        }

        private void Chip_OnDeleteOfferClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            stk_tagsOffers.Children.Remove(currentChip);
            var m = comboOfferTemp.Where(j => j.OofferId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
            dynamicComboOffer.Add(m.FirstOrDefault());
            selectedOfferId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedOfferId.Count == 0)
            {
                cb_offers.SelectedItem = null;
            }
            fillOffersEvent();
        }

        private void chk_allOffers_Click(object sender, RoutedEventArgs e)
        {
            if (cb_offers.IsEnabled == true)
            {
                cb_offers.SelectedItem = null;
                cb_offers.IsEnabled = false;
                for (int i = 0; i < comboOfferTemp.Count; i++)
                {
                    dynamicComboOffer.Add(comboOfferTemp.Skip(i).FirstOrDefault());
                }
                comboOfferTemp.Clear();
                stk_tagsOffers.Children.Clear();
                selectedOfferId.Clear();
            }
            else
            {
                cb_offers.IsEnabled = true;
            }

            fillOffersEvent();
        }

        private void chk_offersInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillOffersEvent();
        }

        private void chk_offersInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillOffersEvent();
        }

        private void chk_offersReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillOffersEvent();
        }

        private void chk_offersReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillOffersEvent();
        }

        private void chk_offersDrafs_Unchecked(object sender, RoutedEventArgs e)
        {
            fillOffersEvent();
        }

        private void chk_offersDrafs_Checked(object sender, RoutedEventArgs e)
        {
            fillOffersEvent();
        }

        private void dp_offersEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillOffersEvent();
        }

        private void dp_offersStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillOffersEvent();
        }

       

        private void dt_offersEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillOffersEvent();
        }

        private void dt_offersStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillOffersEvent();
        }
        Invoice invoice;
        private async void DgInvoice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //invoiceId
            invoice = new Invoice();
            if (dgInvoice.SelectedIndex != -1)
            {
                ItemTransferInvoice item = dgInvoice.SelectedItem as ItemTransferInvoice;
                if (item.invoiceId > 0)
                {
                    MainWindow.mainWindow.StartAwait();
                    invoice = await invoice.GetById(item.invoiceId);
                    MainWindow.mainWindow.BTN_sales_Click(null, null);
                    uc_sales.Instance.Btn_receiptInvoice_Click(null, null);
                    uc_receiptInvoice.Instance.UserControl_Loaded(null, null);
                    uc_receiptInvoice._InvoiceType = invoice.invType;
                    uc_receiptInvoice.Instance.invoice = invoice;
                    await uc_receiptInvoice.Instance.fillInvoiceInputs(invoice);
                    MainWindow.mainWindow.EndAwait();


                    
                }
            }
        }
    }
}
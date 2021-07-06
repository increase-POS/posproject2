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

namespace POS.View.purchases
{
    public partial class uc_purchaseReport : UserControl
    {
        private int selectedTab = 0;


        List<Invoice> dgBranches = new List<Invoice>();
        List<Invoice> dgPos = new List<Invoice>();
        List<Invoice> dgVendors = new List<Invoice>();
        List<Invoice> dgUsers = new List<Invoice>();

        Statistics statisticModel = new Statistics();
        Statistics statisticPosModel = new Statistics();
        Statistics statisticVendorsModel = new Statistics();
        Statistics statisticUserModel = new Statistics();

        List<Invoice> pieChart;
        List<Invoice> columnChartList;
        List<Invoice> rowChartInvoice;

        List<Invoice> PospieChart;
        List<Invoice> PoscolumnChartList;
        List<Invoice> PosrowChartInvoice;

        List<Invoice> VendorspieChart;
        List<Invoice> VendorscolumnChartList;
        List<Invoice> VendorsrowChartInvoice;

        List<Invoice> UserspieChart;
        List<Invoice> UserscolumnChartList;
        List<Invoice> UsersrowChartInvoice;

        List<Branch> Branches;
        List<Branch> Poss;
        List<Branch> Vendors;
        List<Branch> Users;

        //for combo boxes
        /*************************/
        List<Branch> comboBranches;
        List<Pos> comboPoss;
        List<Agent> comboVendors;
        List<User> comboUsers;

        Branch branchModel = new Branch();
        Pos posModel = new Pos();
        Agent agentModel = new Agent();
        User userModel = new User();
        /*************************/

        Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        ObservableCollection<int> selectedBranchId = new ObservableCollection<int>();
        ObservableCollection<int> selectedPosId = new ObservableCollection<int>();
        ObservableCollection<int> selectedVendorsId = new ObservableCollection<int>();
        ObservableCollection<int> selectedUserId = new ObservableCollection<int>();

        public string[] Labels { get; set; }
        public string[] Formatter { get; set; }

        private static uc_purchaseReport _instance;
        public static uc_purchaseReport Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_purchaseReport();
                return _instance;
            }
        }


        public uc_purchaseReport()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dgBranches = await statisticModel.GetPurinvwithCount();
            dgPos = await statisticModel.GetPurinvwithCount();
            dgVendors = await statisticModel.GetPurinvwithCount();
            dgUsers = await statisticModel.GetPurinvwithCount();

            comboBranches = await branchModel.GetAllWithoutMain("b");
            comboPoss = await posModel.GetPosAsync();
            comboVendors = await agentModel.GetAgentsAsync("v");
            comboUsers = await userModel.GetUsersAsync();

            pieChart = await statisticModel.GetPurinvwithCount();
            columnChartList = await statisticModel.GetPurinvwithCount();
            rowChartInvoice = await statisticModel.GetPurinvwithCount();

            PospieChart = await statisticModel.GetPurinvwithCount();
            PoscolumnChartList = await statisticModel.GetPurinvwithCount();
            PosrowChartInvoice = await statisticModel.GetPurinvwithCount();

            VendorspieChart = await statisticModel.GetPurinvwithCount();
            VendorscolumnChartList = await statisticModel.GetPurinvwithCount();
            VendorsrowChartInvoice = await statisticModel.GetPurinvwithCount();

            UserspieChart = await statisticModel.GetPurinvwithCount();
            UserscolumnChartList = await statisticModel.GetPurinvwithCount();
            UsersrowChartInvoice = await statisticModel.GetPurinvwithCount();

            fillComboBranches();
            fillComboPos();
            fillComboUsers();
            fillComboVendors();

            chk_invoice.IsChecked = true;
            chk_posInvoice.IsChecked = true;
            chk_vendorsInvoice.IsChecked = true;
            chk_usersInvoice.IsChecked = true;

            fillRowChartBrnaches();
        }

        private void fillComboBranches()
        {
            cb_branches.SelectedValuePath = "branchId";
            cb_branches.DisplayMemberPath = "name";
            cb_branches.ItemsSource = comboBranches;
        }

        private void fillComboPos()
        {
            cb_pos.SelectedValuePath = "posId";
            cb_pos.DisplayMemberPath = "name";
            cb_pos.ItemsSource = comboPoss;
        }

        private void fillComboVendors()
        {
            cb_vendors.SelectedValuePath = "agentId";
            cb_vendors.DisplayMemberPath = "name";
            cb_vendors.ItemsSource = comboVendors;
        }

        private void fillComboUsers()
        {
            cb_users.SelectedValuePath = "userId";
            cb_users.DisplayMemberPath = "username";
            cb_users.ItemsSource = comboUsers;
        }

        private async void fillPieChartBranches()
        {
            Branches = await statisticModel.GetinvInBranch();
            var result = pieChart.Where
                (x => ((chk_drafs.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false)
                || (chk_return.IsChecked == true ? (x.invType == "pb") : false)
                || (chk_invoice.IsChecked == true ? (x.invType == "p") : false))
                && (cb_branches.SelectedItem != null ? selectedBranchId.Contains((int)x.branchId) : true)
                && (dp_startDate.SelectedDate != null ? x.invDate >= dp_startDate.SelectedDate : true)
                && (dp_endDate.SelectedDate != null ? x.invDate <= dp_endDate.SelectedDate : true)
                && (dt_startTime.SelectedTime != null ? x.invDate >= dt_startTime.SelectedTime : true)
                && (dt_endTime.SelectedTime != null ? x.invDate <= dt_endTime.SelectedTime : true)
                && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
                || x.discountType.Contains(txt_search.Text) || x.branchName.Contains(txt_search.Text)) : true))
                .GroupBy(s => s.branchId).Select(s => new { branchId = s.Key, count = s.Count() }
         );
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < result.Count(); i++)
            {
                List<int> final = new List<int>();
                List<string> titles = new List<string>();
                List<string> lable = new List<string>();
                final.Add(result.ToList().Skip(i).FirstOrDefault().count);
                piechartData.Add(
                  new PieSeries
                  {
                      Values = final.AsChartValues(),
                      Title = titles.FirstOrDefault(),
                      DataLabels = true,
                  }

              );
            }
            chart1.Series = piechartData;
        }

        private async void fillPieChartPos()
        {
            Poss = await statisticModel.GetinvInBranch();
            var result = pieChart.Where
                (x => ((chk_posDraft.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false)
                || (chk_posReturn.IsChecked == true ? (x.invType == "pb") : false)
                || (chk_posInvoice.IsChecked == true ? (x.invType == "p") : false))
                && (cb_pos.SelectedItem != null ? selectedPosId.Contains((int)x.posId) : true)
                && (dp_posStartDate.SelectedDate != null ? x.invDate >= dp_posStartDate.SelectedDate : true)
                && (dp_posEndDate.SelectedDate != null ? x.invDate <= dp_posEndDate.SelectedDate : true)
                && (dt_posStartTime.SelectedTime != null ? x.invDate >= dt_posStartTime.SelectedTime : true)
                && (dt_posEndTime.SelectedTime != null ? x.invDate <= dt_posEndTime.SelectedTime : true)
                && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
                || x.discountType.Contains(txt_search.Text) || x.posName.Contains(txt_search.Text)) : true))
                .GroupBy(s => s.posId).Select(s => new { posId = s.Key, count = s.Count() }
         );
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < result.Count(); i++)
            {
                List<int> final = new List<int>();
                List<string> titles = new List<string>();
                List<string> lable = new List<string>();
                final.Add(result.ToList().Skip(i).FirstOrDefault().count);
                piechartData.Add(
                  new PieSeries
                  {
                      Values = final.AsChartValues(),
                      Title = titles.FirstOrDefault(),
                      DataLabels = true,
                  }

              );
            }
            chart1.Series = piechartData;
        }

        private async void fillPieChartVendors()
        {
            Vendors = await statisticModel.GetinvInBranch();
            var result = pieChart.Where
                (x => ((chk_vendorsDraft.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false)
                || (chk_vendorsReturn.IsChecked == true ? (x.invType == "pb") : false)
                || (chk_vendorsInvoice.IsChecked == true ? (x.invType == "p") : false))
                && (cb_vendors.SelectedItem != null ? selectedVendorsId.Contains((int)x.agentId) : true)
                && (dp_vendorsStartDate.SelectedDate != null ? x.invDate >= dp_vendorsStartDate.SelectedDate : true)
                && (dp_vendorsEndDate.SelectedDate != null ? x.invDate <= dp_vendorsEndDate.SelectedDate : true)
                && (dt_vendorsStartTime.SelectedTime != null ? x.invDate >= dt_vendorsStartTime.SelectedTime : true)
                && (dt_vendorsEndTime.SelectedTime != null ? x.invDate <= dt_vendorsEndTime.SelectedTime : true)
                && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
                || x.discountType.Contains(txt_search.Text) || x.agentName.Contains(txt_search.Text)) : true))
                .GroupBy(s => s.agentId).Select(s => new { vendorId = s.Key, count = s.Count() }
         );
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < result.Count(); i++)
            {
                List<int> final = new List<int>();
                List<string> titles = new List<string>();
                List<string> lable = new List<string>();
                final.Add(result.ToList().Skip(i).FirstOrDefault().count);
                piechartData.Add(
                  new PieSeries
                  {
                      Values = final.AsChartValues(),
                      Title = titles.FirstOrDefault(),
                      DataLabels = true,
                  }

              );
            }
            chart1.Series = piechartData;
        }

        private async void fillPieChartUsers()
        {
            Users = await statisticModel.GetinvInBranch();
            var result = pieChart.Where
                (x => ((chk_usersDraft.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false)
                || (chk_usersReturn.IsChecked == true ? (x.invType == "pb") : false)
                || (chk_usersInvoice.IsChecked == true ? (x.invType == "p") : false))
                && (cb_users.SelectedItem != null ? selectedUserId.Contains((int)x.createUserId) : true)
                && (dp_usersStartDate.SelectedDate != null ? x.invDate >= dp_usersStartDate.SelectedDate : true)
                && (dp_usersEndDate.SelectedDate != null ? x.invDate <= dp_usersEndDate.SelectedDate : true)
                && (dt_usersStartTime.SelectedTime != null ? x.invDate >= dt_usersStartTime.SelectedTime : true)
                && (dt_usersEndTime.SelectedTime != null ? x.invDate <= dt_usersEndTime.SelectedTime : true)
                && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
                || x.discountType.Contains(txt_search.Text) || x.cUserAccName.Contains(txt_search.Text)) : true))
                .GroupBy(s => s.createUserId).Select(s => new { userId = s.Key, count = s.Count() }
         );
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < result.Count(); i++)
            {
                List<int> final = new List<int>();
                List<string> titles = new List<string>();
                List<string> lable = new List<string>();
                final.Add(result.ToList().Skip(i).FirstOrDefault().count);
                piechartData.Add(
                  new PieSeries
                  {
                      Values = final.AsChartValues(),
                      Title = titles.FirstOrDefault(),
                      DataLabels = true,
                  }

              );
            }
            chart1.Series = piechartData;
        }

        private async void fillRowChartBrnaches()
        {
            Branches = await statisticModel.GetinvInBranch();

            var result = rowChartInvoice.Where
                (x => ((x.invType == "pb") || (x.invType == "p"))
                && (cb_branches.SelectedItem != null ? selectedBranchId.Contains((int)x.branchId) : true)
                && (dp_startDate.SelectedDate != null ? x.invDate >= dp_startDate.SelectedDate : true)
                && (dp_endDate.SelectedDate != null ? x.invDate <= dp_endDate.SelectedDate : true)
                && (dt_startTime.SelectedTime != null ? x.invDate >= dt_startTime.SelectedTime : true)
                && (dt_endTime.SelectedTime != null ? x.invDate <= dt_endTime.SelectedTime : true)
         && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.branchName.Contains(txt_search.Text)) : true))
                .GroupBy(s => s.branchId).Select(s => new
                {
                    branchId = s.Key,
                    totalP = s.Where(x => x.invType == "p").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "pb").Sum(x => x.totalNet)
                }
         );

            var resultTotal = result.Select(x => new { x.branchId, total = x.totalP - x.totalPb }).ToList();

            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            for (int i = 0; i < result.Count(); i++)
            {
                purchase.Add(decimal.Parse(result.ToList().Skip(i).FirstOrDefault().totalP.ToString()));
                returns.Add(decimal.Parse(result.ToList().Skip(i).FirstOrDefault().totalPb.ToString()));
                sub.Add(decimal.Parse(resultTotal.ToList().Skip(i).FirstOrDefault().total.ToString()));
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = purchase.AsChartValues(),
          });
            rowChartData.Add(
         new LineSeries
         {
             Values = returns.AsChartValues(),
         });
            rowChartData.Add(
        new LineSeries
        {
            Values = sub.AsChartValues(),

        });
            DataContext = this;
            rowChart.Series = rowChartData;

        }

        private async void fillRowChartPos()
        {
            Poss = await statisticModel.GetinvInBranch();
            var result = rowChartInvoice.Where
                (x => ((x.invType == "pb") || (x.invType == "p"))
                && (cb_pos.SelectedItem != null ? selectedPosId.Contains((int)x.posId) : true)
                && (dp_posStartDate.SelectedDate != null ? x.invDate >= dp_posStartDate.SelectedDate : true)
                && (dp_posEndDate.SelectedDate != null ? x.invDate <= dp_posEndDate.SelectedDate : true)
                && (dt_posStartTime.SelectedTime != null ? x.invDate >= dt_posStartTime.SelectedTime : true)
                && (dt_posEndTime.SelectedTime != null ? x.invDate <= dt_posEndTime.SelectedTime : true)
         && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.posName.Contains(txt_search.Text)) : true))
                .GroupBy(s => s.posId).Select(s => new
                {
                    posId = s.Key,
                    totalP = s.Where(x => x.invType == "p").Sum(x => x.totalNet),
                    totalPb = s.Where(x => x.invType == "pb").Sum(x => x.totalNet)
                }
         );

            var resultTotal = result.Select(x => new { x.posId, total = x.totalP - x.totalPb }).ToList();

            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            for (int i = 0; i < result.Count(); i++)
            {
                purchase.Add(decimal.Parse(result.ToList().Skip(i).FirstOrDefault().totalP.ToString()));
                returns.Add(decimal.Parse(result.ToList().Skip(i).FirstOrDefault().totalPb.ToString()));
                sub.Add(decimal.Parse(resultTotal.ToList().Skip(i).FirstOrDefault().total.ToString()));
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = purchase.AsChartValues(),
          });
            rowChartData.Add(
         new LineSeries
         {
             Values = returns.AsChartValues(),
         });
            rowChartData.Add(
        new LineSeries
        {
            Values = sub.AsChartValues(),

        });
            DataContext = this;
            rowChart.Series = rowChartData;

        }

        private async void fillRowChartVendors()
        {
            Vendors = await statisticModel.GetinvInBranch();
            var result = rowChartInvoice.Where
                (x => ((x.invType == "pb") || (x.invType == "p"))
                && (cb_vendors.SelectedItem != null ? selectedVendorsId.Contains((int)x.agentId) : true)
                && (dp_vendorsStartDate.SelectedDate != null ? x.invDate >= dp_vendorsStartDate.SelectedDate : true)
                && (dp_vendorsEndDate.SelectedDate != null ? x.invDate <= dp_vendorsEndDate.SelectedDate : true)
                && (dt_vendorsStartTime.SelectedTime != null ? x.invDate >= dt_vendorsStartTime.SelectedTime : true)
                && (dt_vendorsEndTime.SelectedTime != null ? x.invDate <= dt_vendorsEndTime.SelectedTime : true)
         && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.agentName.Contains(txt_search.Text)) : true))
                .GroupBy(s => s.agentId).Select(s => new
                {
                    agentId = s.Key,
                    totalP = s.Where(x => x.invType == "p").Sum(x => x.totalNet)
                ,
                    totalPb = s.Where(x => x.invType == "pb").Sum(x => x.totalNet)
                }
         );
            var resultTotal = result.Select(x => new { x.agentId, total = x.totalP - x.totalPb }).ToList();

            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            for (int i = 0; i < result.Count(); i++)
            {
                purchase.Add(decimal.Parse(result.ToList().Skip(i).FirstOrDefault().totalP.ToString()));
                returns.Add(decimal.Parse(result.ToList().Skip(i).FirstOrDefault().totalPb.ToString()));
                sub.Add(decimal.Parse(resultTotal.ToList().Skip(i).FirstOrDefault().total.ToString()));
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = purchase.AsChartValues(),
          });
            rowChartData.Add(
         new LineSeries
         {
             Values = returns.AsChartValues(),
         });
            rowChartData.Add(
        new LineSeries
        {
            Values = sub.AsChartValues(),

        });
            DataContext = this;
            rowChart.Series = rowChartData;
        }

        private async void fillRowChartUsers()
        {
            Users = await statisticModel.GetinvInBranch();
            var result = rowChartInvoice.Where
                (x => ((x.invType == "pb") || (x.invType == "p"))
                && (cb_users.SelectedItem != null ? selectedUserId.Contains((int)x.createUserId) : true)
                && (dp_usersStartDate.SelectedDate != null ? x.invDate >= dp_usersStartDate.SelectedDate : true)
                && (dp_usersEndDate.SelectedDate != null ? x.invDate <= dp_usersEndDate.SelectedDate : true)
                && (dt_usersStartTime.SelectedTime != null ? x.invDate >= dt_usersStartTime.SelectedTime : true)
                && (dt_usersEndTime.SelectedTime != null ? x.invDate <= dt_usersEndTime.SelectedTime : true)
         && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.cUserAccName.Contains(txt_search.Text)) : true))
                .GroupBy(s => s.createUserId).Select(s => new
                {
                    userId = s.Key,
                    totalP = s.Where(x => x.invType == "p").Sum(x => x.totalNet)
                ,
                    totalPb = s.Where(x => x.invType == "pb").Sum(x => x.totalNet)
                }
         );

            var resultTotal = result.Select(x => new { x.userId, total = x.totalP - x.totalPb }).ToList();

            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            for (int i = 0; i < result.Count(); i++)
            {
                purchase.Add(decimal.Parse(result.ToList().Skip(i).FirstOrDefault().totalP.ToString()));
                returns.Add(decimal.Parse(result.ToList().Skip(i).FirstOrDefault().totalPb.ToString()));
                sub.Add(decimal.Parse(resultTotal.ToList().Skip(i).FirstOrDefault().total.ToString()));
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = purchase.AsChartValues(),
          });
            rowChartData.Add(
         new LineSeries
         {
             Values = returns.AsChartValues(),
         });
            rowChartData.Add(
        new LineSeries
        {
            Values = sub.AsChartValues(),

        });
            DataContext = this;
            rowChart.Series = rowChartData;

        }

        private async void fillColumnChartBranches()
        {
            Branches = await statisticModel.GetinvInBranch();

            var result = columnChartList.Where
                (x => ((chk_drafs.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false)
                || (chk_return.IsChecked == true ? (x.invType == "pb") : false)
                || (chk_invoice.IsChecked == true ? (x.invType == "p") : false))
                && (cb_branches.SelectedItem != null ? selectedBranchId.Contains((int)x.branchId) : true)
                && (dp_startDate.SelectedDate != null ? x.invDate >= dp_startDate.SelectedDate : true)
                && (dp_endDate.SelectedDate != null ? x.invDate <= dp_endDate.SelectedDate : true)
                && (dt_startTime.SelectedTime != null ? x.invDate >= dt_startTime.SelectedTime : true)
                && (dt_endTime.SelectedTime != null ? x.invDate <= dt_endTime.SelectedTime : true)
                && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.branchName.Contains(txt_search.Text)) : true)
         ).GroupBy(s => s.branchId).Select(s => new
         {
             branchId = s.Key,
             countP = s.Where(x => x.invType == "p").Count(),
             countPb = s.Where(x => x.invType == "pb").Count(),
             countD = s.Where(x => x.invType == "pd" || x.invType == "pbd").Count()
         }
         );

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();
            List<int> cD = new List<int>();
            List<string> titles = new List<string>()
            {
                "مشتريات","مرتجع","هامش"
            };
            for (int i = 0; i < result.Count(); i++)
            {
                cP.Add(result.ToList().Skip(i).FirstOrDefault().countP);
                cPb.Add(result.ToList().Skip(i).FirstOrDefault().countPb);
                cD.Add(result.ToList().Skip(i).FirstOrDefault().countD);
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

        private async void fillColumnChartPos()
        {
            Poss = await statisticModel.GetinvInBranch();

            var result = columnChartList.Where
                (x => ((chk_posDraft.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false)
                || (chk_posReturn.IsChecked == true ? (x.invType == "pb") : false)
                || (chk_posInvoice.IsChecked == true ? (x.invType == "p") : false))
                && (cb_pos.SelectedItem != null ? selectedPosId.Contains((int)x.posId) : true)
                && (dp_posStartDate.SelectedDate != null ? x.invDate >= dp_posStartDate.SelectedDate : true)
                && (dp_posEndDate.SelectedDate != null ? x.invDate <= dp_posEndDate.SelectedDate : true)
                && (dt_posStartTime.SelectedTime != null ? x.invDate >= dt_posStartTime.SelectedTime : true)
                && (dt_posEndTime.SelectedTime != null ? x.invDate <= dt_posEndTime.SelectedTime : true)
                && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.posName.Contains(txt_search.Text)) : true)
         ).GroupBy(s => s.posId).Select(s => new
         {
             posId = s.Key,
             countP = s.Where(x => x.invType == "p").Count(),
             countPb = s.Where(x => x.invType == "pb").Count(),
             countD = s.Where(x => x.invType == "pd" || x.invType == "pbd").Count()
         }
         );

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();
            List<int> cD = new List<int>();
            List<string> titles = new List<string>()
            {
                "مشتريات","مرتجع","هامش"
            };
            for (int i = 0; i < result.Count(); i++)
            {
                cP.Add(result.ToList().Skip(i).FirstOrDefault().countP);
                cPb.Add(result.ToList().Skip(i).FirstOrDefault().countPb);
                cD.Add(result.ToList().Skip(i).FirstOrDefault().countD);
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

        private async void fillColumnChartVendors()
        {
            Vendors = await statisticModel.GetinvInBranch();

            var result = columnChartList.Where
                (x => ((chk_vendorsDraft.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false)
                || (chk_vendorsReturn.IsChecked == true ? (x.invType == "pb") : false)
                || (chk_vendorsInvoice.IsChecked == true ? (x.invType == "p") : false))
                && (cb_vendors.SelectedItem != null ? selectedVendorsId.Contains((int)x.agentId) : true)
                && (dp_vendorsStartDate.SelectedDate != null ? x.invDate >= dp_vendorsStartDate.SelectedDate : true)
                && (dp_vendorsEndDate.SelectedDate != null ? x.invDate <= dp_vendorsEndDate.SelectedDate : true)
                && (dt_vendorsStartTime.SelectedTime != null ? x.invDate >= dt_vendorsStartTime.SelectedTime : true)
                && (dt_vendorsEndTime.SelectedTime != null ? x.invDate <= dt_vendorsEndTime.SelectedTime : true)
                && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.agentName.Contains(txt_search.Text)) : true)
         ).GroupBy(s => s.agentId).Select(s => new
         {
             posId = s.Key,
             countP = s.Where(x => x.invType == "p").Count(),
             countPb = s.Where(x => x.invType == "pb").Count(),
             countD = s.Where(x => x.invType == "pd" || x.invType == "pbd").Count()
         }
         );

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();
            List<int> cD = new List<int>();
            List<string> titles = new List<string>()
            {
                "مشتريات","مرتجع","هامش"
            };
            for (int i = 0; i < result.Count(); i++)
            {
                cP.Add(result.ToList().Skip(i).FirstOrDefault().countP);
                cPb.Add(result.ToList().Skip(i).FirstOrDefault().countPb);
                cD.Add(result.ToList().Skip(i).FirstOrDefault().countD);
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

        private async void fillColumnChartUsers()
        {
            Users = await statisticModel.GetinvInBranch();

            var result = columnChartList.Where
                (x => ((chk_usersDraft.IsChecked == true ? (x.invType == "pd" || x.invType == "pbd") : false)
                || (chk_usersReturn.IsChecked == true ? (x.invType == "pb") : false)
                || (chk_usersInvoice.IsChecked == true ? (x.invType == "p") : false))
                && (cb_users.SelectedItem != null ? selectedUserId.Contains((int)x.createUserId) : true)
                && (dp_usersStartDate.SelectedDate != null ? x.invDate >= dp_usersStartDate.SelectedDate : true)
                && (dp_usersEndDate.SelectedDate != null ? x.invDate <= dp_usersEndDate.SelectedDate : true)
                && (dt_usersStartTime.SelectedTime != null ? x.invDate >= dt_usersStartTime.SelectedTime : true)
                && (dt_usersEndTime.SelectedTime != null ? x.invDate <= dt_usersEndTime.SelectedTime : true)
                && (txt_search.Text != null ? (x.invNumber.Contains(txt_search.Text) || x.invType.Contains(txt_search.Text)
         || x.discountType.Contains(txt_search.Text) || x.cUserAccName.Contains(txt_search.Text)) : true)
         ).GroupBy(s => s.createUserId).Select(s => new
         {
             userId = s.Key,
             countP = s.Where(x => x.invType == "p").Count(),
             countPb = s.Where(x => x.invType == "pb").Count(),
             countD = s.Where(x => x.invType == "pd" || x.invType == "pbd").Count()
         }
         );

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();
            List<int> cD = new List<int>();
            List<string> titles = new List<string>()
            {
                "مشتريات","مرتجع","هامش"
            };
            for (int i = 0; i < result.Count(); i++)
            {
                cP.Add(result.ToList().Skip(i).FirstOrDefault().countP);
                cPb.Add(result.ToList().Skip(i).FirstOrDefault().countPb);
                cD.Add(result.ToList().Skip(i).FirstOrDefault().countD);
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

        #region Functions
        private void hideSatacks()
        {
            stk_tagsBranches.Visibility = Visibility.Collapsed;
            stk_tagsItems.Visibility = Visibility.Collapsed;
            stk_tagsPos.Visibility = Visibility.Collapsed;
            stk_tagsUsers.Visibility = Visibility.Collapsed;
            stk_tagsVendors.Visibility = Visibility.Collapsed;
        }

        public void paint()
        {
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            bdr_branch.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_pos.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_vendors.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_users.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_items.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_branch.Fill = Brushes.White;
            path_pos.Fill = Brushes.White;
            path_vendors.Fill = Brushes.White;
            path_users.Fill = Brushes.White;
            path_items.Fill = Brushes.White;

            grid_branch.Visibility = Visibility.Hidden;
            grid_pos.Visibility = Visibility.Hidden;
            grid_vendors.Visibility = Visibility.Hidden;
            grid_users.Visibility = Visibility.Hidden;
            grid_items.Visibility = Visibility.Hidden;

            col_branch.Visibility = Visibility.Collapsed;
            col_item.Visibility = Visibility.Collapsed;
            col_pos.Visibility = Visibility.Collapsed;
            col_user.Visibility = Visibility.Collapsed;
            col_vendor.Visibility = Visibility.Collapsed;
        }

        private void isEnabledButtons()
        {
            btn_branch.IsEnabled = true;
            btn_pos.IsEnabled = true;
            btn_vendors.IsEnabled = true;
            btn_users.IsEnabled = true;
            btn_items.IsEnabled = true;
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
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChartBranches();
            fillRowChartBrnaches();
        }

        private void btn_pos_Click(object sender, RoutedEventArgs e)
        {
            txt_search.Text = "";
            hideSatacks();
            stk_tagsPos.Visibility = Visibility.Visible;
            selectedTab = 1;
            paint();
            col_pos.Visibility = Visibility.Visible;
            bdr_pos.Background = Brushes.White;
            path_pos.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_pos.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_pos.IsEnabled = false;
            btn_pos.Opacity = 1;
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedPosId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillRowChartPos();
            fillPieChartPos();
            fillColumnChartPos();
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
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartVendors();
            fillColumnChartVendors();
            fillRowChartVendors();
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
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedUserId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartUsers();
            fillColumnChartUsers();
            fillRowChartUsers();
        }

        private void btn_items_Click(object sender, RoutedEventArgs e)
        {
            txt_search.Text = "";
            selectedTab = 4;
            paint();
            col_item.Visibility = Visibility.Visible;
            bdr_items.Background = Brushes.White;
            path_items.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_items.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_items.IsEnabled = false;
            btn_items.Opacity = 1;
        }
        #endregion

        #region refreshButton
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTab==0)
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
                stk_tagsBranches.Children.Clear();
              
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
                stk_tagsPos.Children.Clear();
            
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
                stk_tagsVendors.Children.Clear();
             
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
                stk_tagsUsers.Children.Clear();
           
            }
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChartBranches();
            fillRowChartBrnaches();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedPosId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            fillRowChartPos();
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedBranchId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            fillPieChartVendors();
            fillColumnChartVendors();
            fillRowChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            fillPieChartUsers();
            fillColumnChartUsers();
            fillRowChartUsers();
            txt_search.Text = "";
        }
        #endregion

        #region branchesEvents
        private void chk_invoice_Checked(object sender, RoutedEventArgs e)
        {
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChartBranches();
        }

        private void chk_return_Checked(object sender, RoutedEventArgs e)
        {
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChartBranches();
        }

        private void chk_drafs_Checked(object sender, RoutedEventArgs e)
        {
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChartBranches();
        }

        private void chk_invoice_Unchecked(object sender, RoutedEventArgs e)
        {
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChartBranches();
        }

        private void chk_return_Unchecked(object sender, RoutedEventArgs e)
        {
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChartBranches();
        }

        private void chk_drafs_Unchecked(object sender, RoutedEventArgs e)
        {
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            fillPieChartBranches();
            fillColumnChartBranches();
        }

        private void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        

            var temp = cb_branches.SelectedItem as Branch;

            if (temp != null)
            {
                if (stk_tagsBranches.Children.Count < 5)
                {
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = temp.name,
                        Name = "btn" + temp.branchId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteClick;
                    stk_tagsBranches.Children.Add(b);
                    selectedBranchId.Add(temp.branchId);
                    dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
                    fillPieChartBranches();
                    fillColumnChartBranches();
                    fillRowChartBrnaches();
                }
            }
        }

        private void chk_allBranches_Click(object sender, RoutedEventArgs e)
        {
            if (cb_branches.IsEnabled == true)
            {
                cb_branches.SelectedItem = null;
                cb_branches.IsEnabled = false;
                stk_tagsBranches.Children.Clear();
            }
            else
            {
                cb_branches.IsEnabled = true;
            }
            selectedBranchId.Clear();
            fillPieChartBranches();
            fillColumnChartBranches();
            fillRowChartBrnaches();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
        }

        private void Chip_OnDeleteClick(object sender, RoutedEventArgs e)
        {
            var temp = cb_branches.SelectedItem as Branch;
            var currentChip = (Chip)sender;
            stk_tagsBranches.Children.Remove(currentChip);

            selectedBranchId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedBranchId.Count == 0)
            {
                cb_branches.SelectedItem = null;
            }
            fillPieChartBranches();
            fillColumnChartBranches();
            fillRowChartBrnaches();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
        }

        private void dp_startDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPieChartBranches();
            fillColumnChartBranches();
            fillRowChartBrnaches();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
        }

        private void dp_endDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPieChartBranches();
            fillColumnChartBranches();
            fillRowChartBrnaches();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
        }

        private void dt_startTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillPieChartBranches();
            fillColumnChartBranches();
            fillRowChartBrnaches();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
        }

        private void dp_endTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillPieChartBranches();
            fillColumnChartBranches();
            fillRowChartBrnaches();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            fillPieChartBranches();
            fillColumnChartBranches();
            fillRowChartBrnaches();
            if (selectedTab == 0)
            {
                dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgBranches(dgBranches, selectedBranchId, col_branch, chk_invoice, chk_return, chk_drafs, cb_branches, chk_allBranches, dp_startDate, dp_endDate, dt_startTime, dt_endTime, txt_search);
            }
            else if (selectedTab == 1)
            {
                dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedBranchId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
            }
            else if (selectedTab == 2)
            {
                dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedBranchId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
            }
            else if (selectedTab == 3)
            {
                dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
            }
            else
            {

            }
        }
        #endregion

        #region posEvents
        private void chk_posInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedPosId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void chk_posReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedPosId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void chk_posDrafs_Checked(object sender, RoutedEventArgs e)
        {
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedPosId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void chk_posInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedBranchId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void chk_posReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedBranchId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void chk_posDrafs_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedBranchId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void Chip_OnDeletePosClick(object sender, RoutedEventArgs e)
        {
            var temp = cb_pos.SelectedItem as Pos;
            var currentChip = (Chip)sender;
            stk_tagsPos.Children.Remove(currentChip);

            selectedPosId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedPosId.Count == 0)
            {
                cb_pos.SelectedItem = null;
            }
            fillRowChartPos();
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedPosId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }
        private void cb_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = cb_pos.SelectedItem as Pos;
            if (temp != null)
            {
                if (stk_tagsPos.Children.Count < 5)
                {
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = temp.name,
                        Name = "btn" + temp.posId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeletePosClick;
                    stk_tagsPos.Children.Add(b);
                    selectedPosId.Add(temp.posId);
                }
            }
            fillColumnChartPos();
            fillRowChartPos();
            fillPieChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedPosId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void dp_posStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillRowChartPos();
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedBranchId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void dp_posEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillRowChartPos();
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedBranchId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void chk_allPos_Click(object sender, RoutedEventArgs e)
        {
            if (cb_pos.IsEnabled == true)
            {
                cb_pos.SelectedItem = null;
                cb_pos.IsEnabled = false;
                stk_tagsPos.Children.Clear();
            }
            else
            {
                cb_pos.IsEnabled = true;
            }
            selectedBranchId.Clear();
            fillRowChartPos();
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedBranchId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void dt_posStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillRowChartPos();
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedBranchId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }

        private void dt_posEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillRowChartPos();
            fillPieChartPos();
            fillColumnChartPos();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgPos(dgPos, selectedBranchId, col_branch, chk_posInvoice, chk_posReturn, chk_posDraft, cb_pos, chk_allPos, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime, txt_search);
        }
        #endregion

        #region vendorsEvents
        private void chk_vendorsInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillPieChartBranches();
            fillColumnChartBranches();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void chk_vendorsReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillPieChartVendors();
            fillColumnChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void chk_vendorsDraft_Checked(object sender, RoutedEventArgs e)
        {
            fillPieChartVendors();
            fillColumnChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void chk_vendorsInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPieChartVendors();
            fillColumnChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void chk_vendorsReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPieChartVendors();
            fillColumnChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void chk_vendorsDraft_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPieChartVendors();
            fillColumnChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void dp_vendorsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPieChartVendors();
            fillColumnChartVendors();
            fillRowChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void dp_vendorsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPieChartVendors();
            fillColumnChartVendors();
            fillRowChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void Chip_OnDeleteVendorClick(object sender, RoutedEventArgs e)
        {
            var temp = cb_vendors.SelectedItem as Agent;
            var currentChip = (Chip)sender;
            stk_tagsVendors.Children.Remove(currentChip);

            selectedVendorsId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedVendorsId.Count == 0)
            {
                cb_vendors.SelectedItem = null;
            }
            fillPieChartVendors();
            fillColumnChartVendors();
            fillRowChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void cb_vendors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPieChartVendors();
            fillColumnChartVendors();
            fillRowChartVendors();
            var temp = cb_vendors.SelectedItem as Agent;

            if (temp != null)
            {
                if (stk_tagsVendors.Children.Count < 5)
                {
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = temp.name,
                        Name = "btn" + temp.agentId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteVendorClick;
                    stk_tagsVendors.Children.Add(b);
                    selectedVendorsId.Add(temp.agentId);
                    dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
                }
            }
        }

        private void chk_allVendors_Click(object sender, RoutedEventArgs e)
        {
            if (cb_vendors.IsEnabled == true)
            {
                cb_vendors.SelectedItem = null;
                cb_vendors.IsEnabled = false;
                stk_tagsVendors.Children.Clear();
            }
            else
            {
                cb_vendors.IsEnabled = true;
            }
            selectedVendorsId.Clear();
            fillPieChartVendors();
            fillColumnChartVendors();
            fillRowChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void dt_vendorsStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {

            fillPieChartVendors();
            fillColumnChartVendors();
            fillRowChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }

        private void dt_vendorsEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillPieChartVendors();
            fillColumnChartVendors();
            fillRowChartVendors();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgVendors(dgVendors, selectedVendorsId, col_branch, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, cb_vendors, chk_allVendors, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime, txt_search);
        }
        #endregion

        #region usersEvents
        private void chk_usersInvoice_Checked(object sender, RoutedEventArgs e)
        {
            fillPieChartUsers();
            fillColumnChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void chk_usersReturn_Checked(object sender, RoutedEventArgs e)
        {
            fillPieChartUsers();
            fillColumnChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void chk_usersDraft_Checked(object sender, RoutedEventArgs e)
        {
            fillPieChartUsers();
            fillColumnChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void chk_usersInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPieChartUsers();
            fillColumnChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void chk_usersReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPieChartUsers();
            fillColumnChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void chk_usersDraft_Unchecked(object sender, RoutedEventArgs e)
        {
            fillPieChartUsers();
            fillColumnChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void dp_usersStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPieChartUsers();
            fillColumnChartUsers();
            fillRowChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void dp_usersEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPieChartUsers();
            fillColumnChartUsers();
            fillRowChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void Chip_OnDeleteUserClick(object sender, RoutedEventArgs e)
        {
            var currentChip = (Chip)sender;
            stk_tagsUsers.Children.Remove(currentChip);

            selectedUserId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
            if (selectedUserId.Count == 0)
            {
                cb_users.SelectedItem = null;
            }
            fillPieChartUsers();
            fillColumnChartUsers();
            fillRowChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedUserId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void cb_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            var temp = cb_users.SelectedItem as User;

            if (temp != null)
            {
                if (stk_tagsUsers.Children.Count < 5)
                {
                    var b = new MaterialDesignThemes.Wpf.Chip()
                    {
                        Content = temp.username,
                        Name = "btn" + temp.userId.ToString(),
                        IsDeletable = true,
                        Margin = new Thickness(5, 0, 5, 0)
                    };
                    b.DeleteClick += Chip_OnDeleteUserClick;
                    stk_tagsUsers.Children.Add(b);
                    selectedUserId.Add(temp.userId);
                    dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedUserId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
                    fillPieChartUsers();
                    fillColumnChartUsers();
                    fillRowChartUsers();
                }
            }
        }

        private void chk_allUsers_Click(object sender, RoutedEventArgs e)
        {
            if (cb_users.IsEnabled == true)
            {
                cb_users.SelectedItem = null;
                cb_users.IsEnabled = false;
                stk_tagsUsers.Children.Clear();
            }
            else
            {
                cb_users.IsEnabled = true;
            }
            selectedUserId.Clear();
            fillPieChartUsers();
            fillColumnChartUsers();
            fillRowChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedUserId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void dt_usersEndTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillPieChartUsers();
            fillColumnChartUsers();
            fillRowChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
        }

        private void dt_usersStartTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillPieChartUsers();
            fillColumnChartUsers();
            fillRowChartUsers();
            dgInvoice.ItemsSource = fillPurchaseStatistic.fillDgUsers(dgUsers, selectedBranchId, col_branch, chk_usersInvoice, chk_usersReturn, chk_usersDraft, cb_users, chk_allUsers, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime, txt_search);
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
    }
}


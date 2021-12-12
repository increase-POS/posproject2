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
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.Threading;
using POS.View.purchases;

namespace POS.View.reports
{

    public partial class uc_purchaseOrders : UserControl
    {
        public uc_purchaseOrders()
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
        //prin & pdf
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        private int selectedTab = 0;

        Statistics statisticModel = new Statistics();

        List<ItemTransferInvoice> Invoices;

        //for combo boxes
        /*************************/
        Branch selectedBranch;
        Pos selectedPos;
        Agent selectedVendor;
        User selectedUser;

        List<Branch> comboBranches;
        List<Pos> comboPoss;
        List<Agent> comboVendors;
        List<User> comboUsers;

        ObservableCollection<Branch> comboBrachTemp = new ObservableCollection<Branch>();
        ObservableCollection<Pos> comboPosTemp = new ObservableCollection<Pos>();
        ObservableCollection<Agent> comboVendorTemp = new ObservableCollection<Agent>();
        ObservableCollection<User> comboUserTemp = new ObservableCollection<User>();

        ObservableCollection<Branch> dynamicComboBranches;
        ObservableCollection<Pos> dynamicComboPoss;
        ObservableCollection<Agent> dynamicComboVendors;
        ObservableCollection<User> dynamicComboUsers;

        Branch branchModel = new Branch();
        Pos posModel = new Pos();
        Agent agentModel = new Agent();
        User userModel = new User();

        /*************************/

        ObservableCollection<int> selectedBranchId = new ObservableCollection<int>();
        ObservableCollection<int> selectedPosId = new ObservableCollection<int>();
        ObservableCollection<int> selectedVendorsId = new ObservableCollection<int>();
        ObservableCollection<int> selectedUserId = new ObservableCollection<int>();

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

        private List<ItemTransferInvoice> converter(List<ItemTransferInvoice> query)
        {
            foreach (var item in query)
            {
                if (item.invType == "p")
                {
                    item.invType = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
                }
                else if (item.invType == "pw")
                {
                    item.invType = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
                }
                else if (item.invType == "pb")
                {
                    item.invType = MainWindow.resourcemanager.GetString("trPurchaseReturnInvoice");
                }
                else if (item.invType == "pd")
                {
                    item.invType = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");
                }
                else if (item.invType == "pbd")
                {
                    item.invType = MainWindow.resourcemanager.GetString("trPurchaseReturnDraft");
                }
            }
            return query;

        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                Invoices = await statisticModel.GetPurorderitemcount((int)MainWindow.branchID, (int)MainWindow.userID);

                comboBranches = await branchModel.GetAllWithoutMain("b");
                comboPoss = await posModel.Get();
                comboVendors = await agentModel.Get("v");
                comboUsers = await userModel.Get();

                dynamicComboBranches = new ObservableCollection<Branch>(comboBranches);
                dynamicComboPoss = new ObservableCollection<Pos>(comboPoss);
                dynamicComboVendors = new ObservableCollection<Agent>(comboVendors);
                dynamicComboUsers = new ObservableCollection<User>(comboUsers);

                fillComboBranches();

                fillEvent();

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_branch.Tag.ToString());

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

        private void fillComboBranches()
        {
            cb_branches.SelectedValuePath = "branchId";
            cb_branches.DisplayMemberPath = "name";
            cb_branches.ItemsSource = dynamicComboBranches;
        }

        private void fillComboPos()
        {
            cb_branches.SelectedValuePath = "posId";
            cb_branches.DisplayMemberPath = "name";
            cb_branches.ItemsSource = dynamicComboPoss;
        }

        private void fillComboVendors()
        {
            cb_branches.SelectedValuePath = "agentId";
            cb_branches.DisplayMemberPath = "name";
            cb_branches.ItemsSource = dynamicComboVendors;
        }

        private void fillComboUsers()
        {
            cb_branches.SelectedValuePath = "userId";
            cb_branches.DisplayMemberPath = "username";
            cb_branches.ItemsSource = dynamicComboUsers;
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
        private IEnumerable<ItemTransferInvoice> fillList(IEnumerable<ItemTransferInvoice> Invoices
         , DatePicker startDate, DatePicker endDate, TimePicker startTime, TimePicker endTime)
        {
            fillDates(startDate, endDate, startTime, endTime);
            var result = Invoices.Where(x => (
                       (startDate.SelectedDate != null ? x.invDate >= startDate.SelectedDate : true)
                      && (endDate.SelectedDate != null ? x.invDate <= endDate.SelectedDate : true)
                      && (startTime.SelectedTime != null ? x.invDate >= startTime.SelectedTime : true)
                      && (endTime.SelectedTime != null ? x.invDate <= endTime.SelectedTime : true)));

            invLst = result;
            return result;
        }

        public List<ItemTransferInvoice> filltoprint()
        {
            List<ItemTransferInvoice> xx = new List<ItemTransferInvoice>();
            if (selectedTab == 0)
            {
                xx = fillPdfList(cb_branches, selectedBranchId);
            }
            else if (selectedTab == 1)
            {
                xx = fillPdfList(cb_branches, selectedPosId);
            }
            else if (selectedTab == 2)
            {
                xx = fillPdfList(cb_branches, selectedVendorsId);
            }
            else if (selectedTab == 3)
            {
                xx = fillPdfList(cb_branches, selectedUserId);
            }
            return xx;
        }
        private void fillPieChart(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            List<string> titles = new List<string>();
            IEnumerable<int> x = null;

            var temp = invLst;

            if (selectedTab == 0)
            {
                temp = temp.Where(j => (selectedBranchId.Count != 0 ? stackedButton.Contains((int)j.branchCreatorId) : true));
                var titleTemp = temp.GroupBy(m => m.branchCreatorName);
                titles.AddRange(titleTemp.Select(jj => jj.Key));
                var result = temp.GroupBy(s => s.branchCreatorId).Select(s => new { branchCreatorId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }
            else if (selectedTab == 1)
            {
                temp = temp.Where(j => (selectedPosId.Count != 0 ? stackedButton.Contains((int)j.posId) : true));
                var titleTemp = temp.GroupBy(m => new { m.posName, m.posId });
                titles.AddRange(titleTemp.Select(jj => jj.Key.posName));
                var result = temp.GroupBy(s => s.posId).Select(s => new { posId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }
            else if (selectedTab == 2)
            {
                temp = temp.Where(j => (selectedVendorsId.Count != 0 ? stackedButton.Contains((int)j.agentId) : true));
                var titleTemp = temp.GroupBy(m => m.agentName);
                titles.AddRange(titleTemp.Select(jj => jj.Key));
                var result = temp.GroupBy(s => s.agentId).Select(s => new { agentId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }
            else if (selectedTab == 3)
            {
                temp = temp.Where(j => (selectedUserId.Count != 0 ? stackedButton.Contains((int)j.updateUserId) : true));
                var titleTemp = temp.GroupBy(m => m.cUserAccName);
                titles.AddRange(titleTemp.Select(jj => jj.Key));
                var result = temp.GroupBy(s => s.updateUserId).Select(s => new { updateUserId = s.Key, count = s.Count() });
                x = result.Select(m => m.count);
            }
           
            SeriesCollection piechartData = new SeriesCollection();

            int xCount = 6;
            if (x.Count() <= 6) xCount = x.Count();

            for (int i = 0; i < xCount; i++)
            {
                List<int> final = new List<int>();

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
            if(x.Count() > 6)
            {
                int finalSum = 0;
                for (int i = 6; i < x.Count(); i++)
                {
                    finalSum = finalSum + x.ToList().Skip(i).FirstOrDefault();
                }
                if(finalSum != 0)
                {
                    List<int> final = new List<int>();

                    final.Add(finalSum);
                    piechartData.Add(
                      new PieSeries
                      {
                          Values = final.AsChartValues(),
                          Title = MainWindow.resourcemanager.GetString("trOthers"),
                          DataLabels = true,
                      }
                  );
                }
            }
            chart1.Series = piechartData;
        }

        private void fillColumnChart(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();
            IEnumerable<int> x = null;

            var temp = invLst;

            if (selectedTab == 0)
            {
                temp = temp.Where(j => (selectedBranchId.Count != 0 ? stackedButton.Contains((int)j.branchCreatorId) : true));
                var result = temp.GroupBy(s => s.branchCreatorId).Select(s => new
                {
                    branchCreatorId = s.Key,
                    countP = s.Count(),
                });
                x = result.Select(m => m.countP);
                var tempName = temp.GroupBy(s => s.branchCreatorName).Select(s => new
                {
                    branchName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.branchName));
            }
            else if (selectedTab == 1)
            {
                temp = temp.Where(j => (selectedPosId.Count != 0 ? stackedButton.Contains((int)j.posId) : true));
                var result = temp.GroupBy(s => s.posId).Select(s => new
                {
                    posId = s.Key,
                    countP = s.Count(),
                });
                x = result.Select(m => m.countP);
                var tempName = temp.GroupBy(s => s.posName).Select(s => new
                {
                    posName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.posName));
            }
            else if (selectedTab == 2)
            {
                temp = temp.Where(j => (selectedVendorsId.Count != 0 ? stackedButton.Contains((int)j.agentId) : true));
                var result = temp.GroupBy(s => s.agentId).Select(s => new
                {
                    agentId = s.Key,
                    countP = s.Count(),
                });
                x = result.Select(m => m.countP);
                var tempName = temp.GroupBy(s => s.agentName).Select(s => new
                {
                    vendorName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.vendorName));
            }
            else if (selectedTab == 3)
            {
                temp = temp.Where(j => (selectedUserId.Count != 0 ? stackedButton.Contains((int)j.updateUserId) : true));
                var result = temp.GroupBy(s => s.updateUserId).Select(s => new
                {
                    updateUserId = s.Key,
                    countP = s.Count(),

                });
                x = result.Select(m => m.countP);
                var tempName = temp.GroupBy(s => s.uUserAccName).Select(s => new
                {
                    uUserName = s.Key
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }

            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();

            int xCount = 6;
            if (x.Count() <= 6) xCount = x.Count();
            for (int i = 0; i < xCount; i++)
            {
                cP.Add(x.ToList().Skip(i).FirstOrDefault());
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            if(x.Count() > 6)
            {
                int cPSum = 0;
                for (int i = 6; i < x.Count(); i++)
                {
                    cPSum = cPSum + x.ToList().Skip(i).FirstOrDefault();
                }
                if(cPSum != 0)
                {
                    cP.Add(cPSum);
                    axcolumn.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
                }
            }
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cP.AsChartValues(),
                Title = MainWindow.resourcemanager.GetString("trPurchases"),
                DataLabels = true,
            });
       
            DataContext = this;
            cartesianChart.Series = columnChartData;
           
        }

        private void fillRowChart(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            #region
            //  MyAxis.Labels = new List<string>();
            //  List<string> names = new List<string>();
            //  IEnumerable<decimal> pTemp = null;
            //  IEnumerable<decimal> pbTemp = null;
            //  IEnumerable<decimal> resultTemp = null;

            //  if (selectedTab == 0)
            //  {
            //      var temp = fillRowChartList(Invoices, chk_invoice, chk_return, chk_drafs, dp_startDate, dp_endDate, dt_startTime, dt_endTime);
            //      temp = temp.Where(j => (selectedBranchId.Count != 0 ? stackedButton.Contains((int)j.branchCreatorId) : true));
            //      var result = temp.GroupBy(s => s.branchCreatorId).Select(s => new
            //      {
            //          branchCreatorId = s.Key,
            //          totalP = s.Sum(x => x.totalNet),
            //          totalPb = s.Sum(x => x.totalNet)
            //      }

            //   );
            //      var resultTotal = result.Select(x => new { x.branchCreatorId, total = x.totalP - x.totalPb }).ToList();
            //      pTemp = result.Select(x => (decimal)x.totalP);
            //      pbTemp = result.Select(x => (decimal)x.totalPb);
            //      resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
            //      var tempName = temp.GroupBy(s => s.branchCreatorName).Select(s => new
            //      {
            //          uUserName = s.Key
            //      });
            //      names.AddRange(tempName.Select(nn => nn.uUserName));
            //  }
            //  if (selectedTab == 1)
            //  {
            //      var temp = fillRowChartList(Invoices, chk_posInvoice, chk_posReturn, chk_posDraft, dp_posStartDate, dp_posEndDate, dt_posStartTime, dt_posEndTime);
            //      temp = temp.Where(j => (selectedPosId.Count != 0 ? stackedButton.Contains((int)j.posId) : true));
            //      var result = temp.GroupBy(s => s.posId).Select(s => new
            //      {
            //          posId = s.Key,
            //          totalP = s.Sum(x => x.totalNet),
            //          totalPb = s.Sum(x => x.totalNet)
            //      }
            //   );
            //      var resultTotal = result.Select(x => new { x.posId, total = x.totalP - x.totalPb }).ToList();
            //      pTemp = result.Select(x => (decimal)x.totalP);
            //      pbTemp = result.Select(x => (decimal)x.totalPb);
            //      resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
            //      var tempName = temp.GroupBy(s => s.posName).Select(s => new
            //      {
            //          uUserName = s.Key
            //      });
            //      names.AddRange(tempName.Select(nn => nn.uUserName));
            //  }
            //  if (selectedTab == 2)
            //  {
            //      var temp = fillRowChartList(Invoices, chk_vendorsInvoice, chk_vendorsReturn, chk_vendorsDraft, dp_vendorsStartDate, dp_vendorsEndDate, dt_vendorsStartTime, dt_vendorsEndTime);
            //      temp = temp.Where(j => (selectedVendorsId.Count != 0 ? stackedButton.Contains((int)j.agentId) : true));
            //      var result = temp.GroupBy(s => s.agentId).Select(s => new
            //      {
            //          agentId = s.Key,
            //          totalP = s.Sum(x => x.totalNet),
            //          totalPb = s.Sum(x => x.totalNet)
            //      }
            //   );
            //      var resultTotal = result.Select(x => new { x.agentId, total = x.totalP - x.totalPb }).ToList();
            //      pTemp = result.Select(x => (decimal)x.totalP);
            //      pbTemp = result.Select(x => (decimal)x.totalPb);
            //      resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
            //      var tempName = temp.GroupBy(s => s.agentName).Select(s => new
            //      {
            //          uUserName = s.Key
            //      });
            //      names.AddRange(tempName.Select(nn => nn.uUserName));
            //  }
            //  if (selectedTab == 3)
            //  {
            //      var temp = fillRowChartList(Invoices, chk_usersInvoice, chk_usersReturn, chk_usersDraft, dp_usersStartDate, dp_usersEndDate, dt_usersStartTime, dt_usersEndTime);
            //      temp = temp.Where(j => (selectedUserId.Count != 0 ? stackedButton.Contains((int)j.updateUserId) : true));
            //      var result = temp.GroupBy(s => s.updateUserId).Select(s => new
            //      {
            //          updateUserId = s.Key,
            //          totalP = s.Sum(x => x.totalNet),
            //          totalPb = s.Sum(x => x.totalNet)
            //      }
            //   );
            //      var resultTotal = result.Select(x => new { x.updateUserId, total = x.totalP - x.totalPb }).ToList();
            //      pTemp = result.Select(x => (decimal)x.totalP);
            //      pbTemp = result.Select(x => (decimal)x.totalPb);
            //      resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
            //      var tempName = temp.GroupBy(s => s.uUserAccName).Select(s => new
            //      {
            //          uUserName = s.Key
            //      });
            //      names.AddRange(tempName.Select(nn => nn.uUserName));
            //  }
            //  if (selectedTab == 4)
            //  {
            //      var temp = fillRowChartList(Items, chk_itemInvoice, chk_itemReturn, chk_itemDrafs, dp_ItemStartDate, dp_ItemEndDate, dt_itemStartTime, dt_ItemEndTime);
            //      temp = temp.Where(j => (selectedItemId.Count != 0 ? stackedButton.Contains((int)j.ITitemUnitId) : true));
            //      var result = temp.GroupBy(s => s.ITitemUnitId).Select(s => new
            //      {
            //          ITitemUnitId = s.Key,
            //          totalP = s.Sum(x => x.totalNet),
            //          totalPb = s.Sum(x => x.totalNet),

            //      }
            //   );
            //      var resultTotal = result.Select(x => new { x.ITitemUnitId, total = x.totalP - x.totalPb }).ToList();
            //      pTemp = result.Select(x => (decimal)x.totalP);
            //      pbTemp = result.Select(x => (decimal)x.totalPb);
            //      resultTemp = result.Select(x => (decimal)x.totalP - (decimal)x.totalPb);
            //      var tempName = temp.GroupBy(jj => jj.ITitemUnitId)
            //       .Select(g => new ItemUnitCombo { itemUnitId = (int)g.FirstOrDefault().ITitemUnitId, itemUnitName = g.FirstOrDefault().ITitemName + "-" + g.FirstOrDefault().ITunitName }).ToList();
            //      names.AddRange(tempName.Select(nn => nn.itemUnitName));
            //  }
            //  /********************************************************************************/


            //  SeriesCollection rowChartData = new SeriesCollection();
            //  List<decimal> purchase = new List<decimal>();
            //  List<decimal> returns = new List<decimal>();
            //  List<decimal> sub = new List<decimal>();
            //  List<string> titles = new List<string>()
            //  {
            //      //"اجمالي المبيعات","اجمالي المرتجع","صافي المبيعات"
            //      MainWindow.resourcemanager.GetString("trTotalPurchases"),
            //      MainWindow.resourcemanager.GetString("trTotalReturn"),
            //      MainWindow.resourcemanager.GetString("trNetPurchases")
            //  };
            //  for (int i = 0; i < pTemp.Count(); i++)
            //  {
            //      purchase.Add(pTemp.ToList().Skip(i).FirstOrDefault());
            //      returns.Add(pbTemp.ToList().Skip(i).FirstOrDefault());
            //      sub.Add(resultTemp.ToList().Skip(i).FirstOrDefault());
            //      MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            //  }

            //  rowChartData.Add(
            //new LineSeries
            //{
            //    Values = purchase.AsChartValues(),
            //    Title = titles[0]
            //});

            //  DataContext = this;
            //  rowChart.Series = rowChartData;
            #endregion
        }

        private List<ItemTransferInvoice> fillPdfList(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            List<ItemTransferInvoice> list = new List<ItemTransferInvoice>();

            var temp = fillList(Invoices, dp_startDate, dp_endDate, dt_startTime, dt_endTime);

            if (selectedTab == 0)
            {
                temp = temp.Where(j => (selectedBranchId.Count != 0 ? stackedButton.Contains((int)j.branchCreatorId) : true));
                list = temp.ToList();
            }
            else if (selectedTab == 1)
            {
                temp = temp.Where(j => (selectedPosId.Count != 0 ? stackedButton.Contains((int)j.posId) : true));
                list = temp.ToList();
            }
            else if (selectedTab == 2)
            {
                temp = temp.Where(j => (selectedVendorsId.Count != 0 ? stackedButton.Contains((int)j.agentId) : true));
                list = temp.ToList();
            }
            else if (selectedTab == 3)
            {
                temp = temp.Where(j => (selectedUserId.Count != 0 ? stackedButton.Contains((int)j.updateUserId) : true));
                list = temp.ToList();
            }

            return list;
        }


        IEnumerable<ItemTransferInvoice> itemTransfers = null;

        public void fillEvent()
        {
            dgInvoice.ItemsSource = filltoprint();
            txt_count.Text = dgInvoice.Items.Count.ToString();

            ObservableCollection<int> selected = new ObservableCollection<int>();
            if (selectedTab == 0)
                selected = selectedBranchId;
            if (selectedTab == 1)
                selected = selectedPosId;
            if (selectedTab == 2)
                selected = selectedVendorsId;
            if (selectedTab == 3)
                selected = selectedUserId;

            fillPieChart(cb_branches, selected);
            fillColumnChart(cb_branches, selected);
            //fillRowChart(cb_branches, selected);
        }

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

            path_branch.Fill = Brushes.White;
            path_pos.Fill = Brushes.White;
            path_vendors.Fill = Brushes.White;
            path_users.Fill = Brushes.White;

            col_item.Visibility = Visibility.Collapsed;
            col_branch.Visibility = Visibility.Collapsed;
            col_pos.Visibility = Visibility.Collapsed;
            col_user.Visibility = Visibility.Collapsed;
            col_vendor.Visibility = Visibility.Collapsed;
        }

        private void hideAllColumn()
        {
            col_branch.Visibility = Visibility.Hidden;
            col_pos.Visibility = Visibility.Hidden;
            col_vendor.Visibility = Visibility.Hidden;
            col_agentCompany.Visibility = Visibility.Hidden;
            col_user.Visibility = Visibility.Hidden;
            col_item.Visibility = Visibility.Hidden;
            col_count.Visibility = Visibility.Hidden;
            col_itQuantity.Visibility = Visibility.Hidden;
            col_price.Visibility = Visibility.Hidden;

        }
        private void btn_branch_Click(object sender, RoutedEventArgs e)
        {//branches
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branches, MainWindow.resourcemanager.GetString("trBranchHint"));

                txt_search.Text = "";
                hideSatacks();
                stk_tagsBranches.Visibility = Visibility.Visible;
                selectedTab = 0;

                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_branch);
                path_branch.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                fillComboBranches();
                fillEvent();

                hideAllColumn();
                col_branch.Visibility = Visibility.Visible;
                col_count.Visibility = Visibility.Visible;

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

        private void btn_pos_Click(object sender, RoutedEventArgs e)
        {//pos
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branches, MainWindow.resourcemanager.GetString("trPosHint"));

                txt_search.Text = "";
                hideSatacks();
                stk_tagsPos.Visibility = Visibility.Visible;
                selectedTab = 1;

                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_pos);
                path_pos.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                fillComboPos();
                fillEvent();

                hideAllColumn();
                col_branch.Visibility = Visibility.Visible;
                col_count.Visibility = Visibility.Visible;
                col_pos.Visibility = Visibility.Visible;
            //   col_totalNet.Visibility = Visibility.Visible;

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

        private void btn_vendors_Click(object sender, RoutedEventArgs e)
        {//vendor
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branches, MainWindow.resourcemanager.GetString("trVendorHint"));

                txt_search.Text = "";
                hideSatacks();
                stk_tagsVendors.Visibility = Visibility.Visible;
                selectedTab = 2;

                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_vendors);
                path_vendors.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                fillComboVendors();
                fillEvent();

                hideAllColumn();

                col_branch.Visibility = Visibility.Visible;
                col_vendor.Visibility = Visibility.Visible;
                col_agentCompany.Visibility = Visibility.Visible;
                col_count.Visibility = Visibility.Visible;

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

        private void btn_users_Click(object sender, RoutedEventArgs e)
        {//users
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branches, MainWindow.resourcemanager.GetString("trUserHint"));

                txt_search.Text = "";
                hideSatacks();
                stk_tagsUsers.Visibility = Visibility.Visible;
                selectedTab = 3;

                paint();
                ReportsHelp.paintTabControlBorder(grid_tabControl, bdr_users);
                path_users.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

                fillComboUsers();
                fillEvent();

                hideAllColumn();

                col_branch.Visibility = Visibility.Visible;
                col_pos.Visibility = Visibility.Visible;
                col_user.Visibility = Visibility.Visible;

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

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_branches.SelectedItem = null;
                dp_endDate.SelectedDate = null;
                dp_startDate.SelectedDate = null;
                dt_startTime.SelectedTime = null;
                dt_endTime.SelectedTime = null;
                chk_allBranches.IsChecked = false;
                cb_branches.IsEnabled = true;
                if (selectedTab == 0)
                {
                    for (int i = 0; i < comboBrachTemp.Count; i++)
                    {
                        dynamicComboBranches.Add(comboBrachTemp.Skip(i).FirstOrDefault());
                    }
                    comboBrachTemp.Clear();
                    stk_tagsBranches.Children.Clear();
                    selectedBranchId.Clear();
                }

                else if (selectedTab == 1)
                {
                    for (int i = 0; i < comboPosTemp.Count; i++)
                    {
                        dynamicComboPoss.Add(comboPosTemp.Skip(i).FirstOrDefault());
                    }
                    comboPosTemp.Clear();
                    stk_tagsPos.Children.Clear();
                    selectedPosId.Clear();
                }

                else if (selectedTab == 2)
                {
                    for (int i = 0; i < comboVendorTemp.Count; i++)
                    {
                        dynamicComboVendors.Add(comboVendorTemp.Skip(i).FirstOrDefault());
                    }
                    comboVendorTemp.Clear();
                    stk_tagsVendors.Children.Clear();
                    selectedVendorsId.Clear();
                }

                else if (selectedTab == 3)
                {
                    for (int i = 0; i < comboUserTemp.Count; i++)
                    {
                        dynamicComboUsers.Add(comboUserTemp.Skip(i).FirstOrDefault());
                    }
                    comboUserTemp.Clear();
                    stk_tagsUsers.Children.Clear();
                    selectedUserId.Clear();
                }

                fillEvent();
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

        private void Chip_OnDeleteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                var currentChip = (Chip)sender;
                if (selectedTab == 0)
                {
                    stk_tagsBranches.Children.Remove(currentChip);
                    var m = comboBrachTemp.Where(j => j.branchId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
                    dynamicComboBranches.Add(m.FirstOrDefault());
                    selectedBranchId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
                    if (selectedBranchId.Count == 0)
                    {
                        cb_branches.SelectedItem = null;
                    }
                }
                else if(selectedTab == 1)
                {
                    stk_tagsPos.Children.Remove(currentChip);
                    var m = comboPosTemp.Where(j => j.posId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
                    dynamicComboPoss.Add(m.FirstOrDefault());
                    selectedPosId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
                    if (selectedPosId.Count == 0)
                    {
                        cb_branches.SelectedItem = null;
                    }
                }
                else if (selectedTab == 2)
                {
                    stk_tagsVendors.Children.Remove(currentChip);
                    var m = comboVendorTemp.Where(j => j.agentId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
                    dynamicComboVendors.Add(m.FirstOrDefault());
                    selectedVendorsId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
                    if (selectedVendorsId.Count == 0)
                    {
                        cb_branches.SelectedItem = null;
                    }
                }
                else if (selectedTab == 3)
                {
                    stk_tagsUsers.Children.Remove(currentChip);
                    var m = comboUserTemp.Where(j => j.userId == (Convert.ToInt32(currentChip.Name.Remove(0, 3))));
                    dynamicComboUsers.Add(m.FirstOrDefault());
                    selectedUserId.Remove(Convert.ToInt32(currentChip.Name.Remove(0, 3)));
                    if (selectedUserId.Count == 0)
                    {
                        cb_branches.SelectedItem = null;
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

        private void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select branch
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (cb_branches.SelectedItem != null)
                {
                    if (selectedTab == 0)
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
                        }
                    }
                    else if (selectedTab == 1)
                    {
                    if (stk_tagsPos.Children.Count < 5)
                    {
                        selectedPos = cb_branches.SelectedItem as Pos;
                        var b = new MaterialDesignThemes.Wpf.Chip()
                        {
                            Content = selectedPos.name,
                            Name = "btn" + selectedPos.posId.ToString(),
                            IsDeletable = true,
                            Margin = new Thickness(5, 0, 5, 0)
                        };
                        b.DeleteClick += Chip_OnDeleteClick;
                        stk_tagsPos.Children.Add(b);
                        comboPosTemp.Add(selectedPos);
                        selectedPosId.Add(selectedPos.posId);
                        dynamicComboPoss.Remove(selectedPos);
                    }
                }
                    else if (selectedTab == 2)
                    {
                    if (stk_tagsVendors.Children.Count < 5)
                    {
                        selectedVendor = cb_branches.SelectedItem as Agent;
                        var b = new MaterialDesignThemes.Wpf.Chip()
                        {
                            Content = selectedVendor.name,
                            Name = "btn" + selectedVendor.agentId.ToString(),
                            IsDeletable = true,
                            Margin = new Thickness(5, 0, 5, 0)
                        };
                        
                        b.DeleteClick += Chip_OnDeleteClick;
                        stk_tagsVendors.Children.Add(b);
                        comboVendorTemp.Add(selectedVendor);
                        selectedVendorsId.Add(selectedVendor.agentId);
                        dynamicComboVendors.Remove(selectedVendor);
                    }
                }
                    else if (selectedTab == 3)
                    {
                    if (stk_tagsUsers.Children.Count < 5)
                    {
                        selectedUser = cb_branches.SelectedItem as User;
                        var b = new MaterialDesignThemes.Wpf.Chip()
                        {
                            Content = selectedUser.username,
                            Name = "btn" + selectedUser.userId.ToString(),
                            IsDeletable = true,
                            Margin = new Thickness(5, 0, 5, 0)
                        };
                        b.DeleteClick += Chip_OnDeleteClick;
                        stk_tagsUsers.Children.Add(b);
                        comboUserTemp.Add(selectedUser);
                        selectedUserId.Add(selectedUser.userId);
                        dynamicComboUsers.Remove(selectedUser);
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
       
        bool isClickedAllBranches = false;
        private void chk_allBranches_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if(!isClickedAllBranches)
                {
                    isClickedAllBranches = true;
                    cb_branches.SelectedItem = null;
                    cb_branches.IsEnabled = false;
                    if (selectedTab == 0)
                    {
                        for (int i = 0; i < comboBrachTemp.Count; i++)
                        {
                            dynamicComboBranches.Add(comboBrachTemp.Skip(i).FirstOrDefault());
                        }
                        comboBrachTemp.Clear();
                        stk_tagsBranches.Children.Clear();
                        selectedBranchId.Clear();
                    }
                    else if (selectedTab == 1)
                    {
                        for (int i = 0; i < comboPosTemp.Count; i++)
                        {
                            dynamicComboPoss.Add(comboPosTemp.Skip(i).FirstOrDefault());
                        }
                        comboPosTemp.Clear();
                        stk_tagsPos.Children.Clear();
                        selectedPosId.Clear();
                    }
                    else if (selectedTab == 2)
                    {
                        for (int i = 0; i < comboVendorTemp.Count; i++)
                        {
                            dynamicComboVendors.Add(comboVendorTemp.Skip(i).FirstOrDefault());
                        }
                        comboVendorTemp.Clear();
                        stk_tagsVendors.Children.Clear();
                        selectedVendorsId.Clear();
                    }
                    else if (selectedTab == 3)
                    {
                        for (int i = 0; i < comboUserTemp.Count; i++)
                        {
                            dynamicComboUsers.Add(comboUserTemp.Skip(i).FirstOrDefault());
                        }
                        comboUserTemp.Clear();
                        stk_tagsUsers.Children.Clear();
                        selectedUserId.Clear();
                    }
                }
                else
                {
                    isClickedAllBranches = false;
                    cb_branches.IsEnabled = true;
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
                        invoice = await invoice.GetByInvoiceId(item.invoiceId);
                        MainWindow.mainWindow.BTN_purchases_Click(MainWindow.mainWindow.btn_purchase, null);
                        uc_purchases.Instance.Btn_purchaseOrder_Click(uc_purchases.Instance.btn_purchaseOrder, null);
                        uc_purchaseOrder.Instance.UserControl_Loaded(null, null);
                        uc_purchaseOrder._InvoiceType = invoice.invType;
                        uc_purchaseOrder.Instance.invoice = invoice;
                        uc_purchaseOrder.isFromReport = true;
                        if (item.archived == 0)
                            uc_purchaseOrder.archived = false;
                        else
                            uc_purchaseOrder.archived = true;
                        await uc_purchaseOrder.Instance.fillInvoiceInputs(invoice);
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
        List<ItemTransferInvoice> query = new List<ItemTransferInvoice>();
        public void BuildReport()
        {
  List<ReportParameter> paramarr = new List<ReportParameter>();

        query = converter(filltoprint());

        string addpath = "";
            string firstTitle = "purchaseOrders";
            string secondTitle = "";
            string subTitle = "";
            string Title = "";
            bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    if (selectedTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Purchase\Ar\ArPurSts.rdlc";
                    secondTitle = "branch";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);

                }
                    else if (selectedTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Purchase\Ar\ArPurPosSts.rdlc";
                    secondTitle = "pos";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                    else if (selectedTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Purchase\Ar\ArPurVendorSts.rdlc";
                    secondTitle = "vendors";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                    else if (selectedTab == 3)
                    {
                        addpath = @"\Reports\StatisticReport\Purchase\Ar\ArPurUserSts.rdlc";
                    secondTitle = "users";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                    else
                    {
                        addpath = @"\Reports\StatisticReport\Purchase\Ar\ArPurItemSts.rdlc";
                    secondTitle = "items";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                }
                else
                {
                    //english
                    if (selectedTab == 0)
                    { addpath = @"\Reports\StatisticReport\Purchase\En\EnPurSts.rdlc";
                    secondTitle = "branch";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);

                }
                    else if (selectedTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Purchase\En\EnPurPosSts.rdlc";
                    secondTitle = "pos";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                    else if (selectedTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Purchase\En\EnPurVendorSts.rdlc";
                    secondTitle = "vendors";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                    else if (selectedTab == 3)
                    {
                        addpath = @"\Reports\StatisticReport\Purchase\En\EnPurUserSts.rdlc";
                    secondTitle = "users";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                    else
                    {
                        addpath = @"\Reports\StatisticReport\Purchase\En\EnPurItemSts.rdlc";
                    secondTitle = "items";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                }

                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();
            Title = MainWindow.resourcemanagerreport.GetString("trPurchasesReport") + " / " + subTitle;
            paramarr.Add(new ReportParameter("trTitle", Title));

            clsReports.PurOrderStsReport(query, rep, reppath, paramarr);
        
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
                List<ItemTransferInvoice> query = new List<ItemTransferInvoice>();
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
        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (selectedTab == 0)
                {
                    itemTransfers = invLst.Where(j => (selectedBranchId.Count != 0 ? selectedBranchId.Contains((int)j.branchCreatorId) : true));

                    dgInvoice.ItemsSource = itemTransfers
                        .Where(s => (s.branchCreatorName.Contains(txt_search.Text) ||
          s.invNumber.Contains(txt_search.Text)
          ));
                }
                else if (selectedTab == 1)
                {
                    itemTransfers = invLst
                        .Where(j => (selectedPosId.Count != 0 ? selectedPosId.Contains((int)j.posId) : true));

                    dgInvoice.ItemsSource = itemTransfers
                        .Where(s => (s.branchCreatorName.Contains(txt_search.Text) ||
                       s.posName.Contains(txt_search.Text) ||
          s.invNumber.Contains(txt_search.Text)
          ));
                }

                else if (selectedTab == 2)
                {
                    itemTransfers = invLst
                    .Where(j => (selectedVendorsId.Count != 0 ? selectedVendorsId.Contains((int)j.agentId) : true));

                    dgInvoice.ItemsSource = itemTransfers
                        .Where(s => (s.branchCreatorName.Contains(txt_search.Text) ||
                       s.agentName.Contains(txt_search.Text) ||
                       s.agentCompany.Contains(txt_search.Text) ||
          s.invNumber.Contains(txt_search.Text)
          ));
                }

                else if (selectedTab == 3)
                {
                    itemTransfers = invLst
                    .Where(j => (selectedUserId.Count != 0 ? selectedUserId.Contains((int)j.updateUserId) : true));

                    dgInvoice.ItemsSource = itemTransfers
                        .Where(s => (s.branchCreatorName.Contains(txt_search.Text) ||
                       s.posName.Contains(txt_search.Text)      ||
                       s.uUserAccName.Contains(txt_search.Text) ||
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
 List<ItemTransferInvoice> query = new List<ItemTransferInvoice>();
                #region
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

        private void fillEventsCall(object sender)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

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

        private void dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEventsCall(sender);
        }

        private void dt_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillEventsCall(sender);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}


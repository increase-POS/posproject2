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
using System.Resources;
using System.Reflection;

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for uc_saleReport.xaml
    /// </summary>
    public partial class uc_saleReport : UserControl
    {
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

        ObservableCollection<int> selectedBranchId = new ObservableCollection<int>();
        ObservableCollection<int> selectedPosId = new ObservableCollection<int>();
        ObservableCollection<int> selectedVendorsId = new ObservableCollection<int>();
        ObservableCollection<int> selectedUserId = new ObservableCollection<int>();

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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                Invoices = await statisticModel.GetSaleitemcount((int)MainWindow.branchID, (int)MainWindow.userID);

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

                comboBranches = await branchModel.GetAllWithoutMain("b");
                comboPoss = await posModel.Get();
                comboVendors = await agentModel.Get("c");
                comboUsers = await userModel.Get();

                dynamicComboBranches = new ObservableCollection<Branch>(comboBranches);
                dynamicComboPoss = new ObservableCollection<Pos>(comboPoss);
                dynamicComboVendors = new ObservableCollection<Agent>(comboVendors);
                dynamicComboUsers = new ObservableCollection<User>(comboUsers);

                fillComboBranches();

                chk_invoice.IsChecked = true;
               
             SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_pos.Tag.ToString());

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
            tt_branch.Content = MainWindow.resourcemanager.GetString("trBranches");
            tt_pos.Content = MainWindow.resourcemanager.GetString("trPOSs");
            tt_vendors.Content = MainWindow.resourcemanager.GetString("trCustomers");
            tt_users.Content = MainWindow.resourcemanager.GetString("trUsers");

            chk_invoice.Content = MainWindow.resourcemanager.GetString("tr_Invoice");
            chk_return.Content = MainWindow.resourcemanager.GetString("trReturned");
            chk_drafs.Content = MainWindow.resourcemanager.GetString("trDraft");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branches, MainWindow.resourcemanager.GetString("trBranchHint"));

            chk_allBranches.Content = MainWindow.resourcemanager.GetString("trAll");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_endDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_startDate, MainWindow.resourcemanager.GetString("trStartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dt_endTime, MainWindow.resourcemanager.GetString("trEndTime") + "...");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dt_startTime, MainWindow.resourcemanager.GetString("trStartTime") + "...");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");

            col_No.Header = MainWindow.resourcemanager.GetString("trNo.");
            col_type.Header = MainWindow.resourcemanager.GetString("trType");
            col_date.Header = MainWindow.resourcemanager.GetString("trDate");
            col_branch.Header = MainWindow.resourcemanager.GetString("trBranch");
            col_pos.Header = MainWindow.resourcemanager.GetString("trPOS");
            col_vendor.Header = MainWindow.resourcemanager.GetString("trCustomer");
            col_agentCompany.Header = MainWindow.resourcemanager.GetString("trCompany");
            col_user.Header = MainWindow.resourcemanager.GetString("trUser");
            col_count.Header = MainWindow.resourcemanager.GetString("trQTR");
            col_discount.Header = MainWindow.resourcemanager.GetString("trDiscount");
            col_tax.Header = MainWindow.resourcemanager.GetString("trTax");
            col_totalNet.Header = MainWindow.resourcemanager.GetString("trTotal");

            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

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
            try
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
            catch(Exception ex)
            {
                //SectionData.ExceptionMessage(ex, this);
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
        IEnumerable<ItemTransferInvoice> invLstRowChart = null;
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
                if (finalSum != 0)
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
            IEnumerable<int> y = null;
            IEnumerable<int> z = null;

            var temp = invLst;
            if (selectedTab == 0)
            {
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
                    uUserName = s.Key +"/"+s.FirstOrDefault().branchCreatorName 
                });
                names.AddRange(tempName.Select(nn => nn.uUserName));
            }
            else if (selectedTab == 2)
            {
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

            int xCount = 6;
            if (x.Count() <= 6) xCount = x.Count();

            for (int i = 0; i < xCount; i++)
            {
                cP.Add(x.ToList().Skip(i).FirstOrDefault());
                cPb.Add(y.ToList().Skip(i).FirstOrDefault());
                cD.Add(z.ToList().Skip(i).FirstOrDefault());
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            if(x.Count() > 6)
            {
                int cPSum = 0, cPbSum = 0, cDSum = 0;
                for (int i = 6; i < x.Count(); i++)
                {
                    cPbSum = cPSum + x.ToList().Skip(i).FirstOrDefault();
                    cPbSum = cPbSum + y.ToList().Skip(i).FirstOrDefault();
                    cDSum = cDSum +z.ToList().Skip(i).FirstOrDefault();
                }
                if(!((cPbSum == 0) && (cPbSum == 0) && (cDSum == 0)))
                {
                    cP.Add(cPSum);
                    cPb.Add(cPbSum);
                    cD.Add(cDSum);
                    axcolumn.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
                }
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

            var temp = fillRowChartList(Invoices, chk_invoice, chk_return, chk_drafs, dp_startDate, dp_endDate, dt_startTime, dt_endTime);
            if (selectedTab == 0)
            {
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

            SeriesCollection rowChartData = new SeriesCollection();
            List<decimal> purchase = new List<decimal>();
            List<decimal> returns = new List<decimal>();
            List<decimal> sub = new List<decimal>();
            List<string> titles = new List<string>()
            {
                MainWindow.resourcemanager.GetString("trNetSales"),
                MainWindow.resourcemanager.GetString("trTotalReturn"),
                MainWindow.resourcemanager.GetString("trTotalSales")
            };

            int xCount = 0;
            if (pTemp.Count() <= 6) xCount = pTemp.Count();
            for (int i = 0; i < xCount; i++)
            {
                purchase.Add(pTemp.ToList().Skip(i).FirstOrDefault());
                returns.Add(pbTemp.ToList().Skip(i).FirstOrDefault());
                sub.Add(resultTemp.ToList().Skip(i).FirstOrDefault());
                MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }
            if(pTemp.Count() > 6)
            {
                decimal purchaseSum = 0, returnsSum = 0, subSum = 0;
                for (int i = 6; i < pTemp.Count(); i++)
                {
                    purchaseSum = purchaseSum + pTemp.ToList().Skip(i).FirstOrDefault();
                    returnsSum = returnsSum + pbTemp.ToList().Skip(i).FirstOrDefault();
                    subSum = subSum + resultTemp.ToList().Skip(i).FirstOrDefault();
                }
                if(!((purchaseSum == 0) &&(returnsSum == 0) &&(subSum == 0)))
                {
                    purchase.Add(purchaseSum);
                    returns.Add(returnsSum);
                    sub.Add(subSum);
                    MyAxis.Labels.Add(MainWindow.resourcemanager.GetString("trOthers"));
                }
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

        //
        private List<ItemTransferInvoice> fillPdfList(ComboBox comboBox, ObservableCollection<int> stackedButton)
        {
            List<ItemTransferInvoice> list = new List<ItemTransferInvoice>();

            var temp = invLstRowChart;
            if (selectedTab == 0)
            {
                temp = temp.Where(j => (selectedBranchId.Count != 0 ? stackedButton.Contains((int)j.branchCreatorId) : true));
                list = temp.ToList();
            }
            if (selectedTab == 1)
            {
                temp = temp.Where(j => (selectedPosId.Count != 0 ? stackedButton.Contains((int)j.posId) : true));
                list = temp.ToList();
            }
            if (selectedTab == 3)
            {
                temp = temp.Where(j => (selectedUserId.Count != 0 ? stackedButton.Contains((int)j.updateUserId) : true));
                list = temp.ToList();
            }

            return list;

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

        public void fillEvent()
        {
            itemTransfers = fillList(Invoices, chk_invoice, chk_return, chk_drafs, dp_startDate, dp_endDate, dt_startTime, dt_endTime);

            //hide tax column if region tax equals to 0
            if (!MainWindow.invoiceTax_bool.Value)
                col_tax.Visibility = Visibility.Hidden;
            else
                col_tax.Visibility = Visibility.Visible;

            ObservableCollection<int> selected = new ObservableCollection<int>();
            if (selectedTab == 0)
            {
                selected = selectedBranchId;
                itemTransfers = itemTransfers.Where(j => (selectedBranchId.Count != 0 ? selectedBranchId.Contains((int)j.branchCreatorId) : true));
            }
            if (selectedTab == 1)
            {
                selected = selectedPosId;
                itemTransfers = itemTransfers.Where(j => (selectedPosId.Count != 0 ? selectedPosId.Contains((int)j.posId) : true));
            }
            if (selectedTab == 2)
            {
                selected = selectedVendorsId;
                itemTransfers = itemTransfers.Where(j => (selectedVendorsId.Count != 0 ? selectedVendorsId.Contains((int)j.agentId) : true));
            }
            if (selectedTab == 3)
            {
                selected = selectedUserId;
                itemTransfers = itemTransfers.Where(j => (selectedUserId.Count != 0 ? selectedUserId.Contains((int)j.updateUserId) : true));
            }


            dgInvoice.ItemsSource = itemTransfers;
            txt_count.Text = dgInvoice.Items.Count.ToString();

            fillPieChart(cb_branches, selected);
            fillColumnChart(cb_branches, selected);
            fillRowChart(cb_branches, selected);
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

            path_branch.Fill = Brushes.White;
            path_pos.Fill = Brushes.White;
            path_vendors.Fill = Brushes.White;
            path_users.Fill = Brushes.White;
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
            col_discount.Visibility = Visibility.Hidden;
            col_count.Visibility = Visibility.Hidden;
            col_totalNet.Visibility = Visibility.Hidden;
            col_tax.Visibility = Visibility.Hidden;
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

                hidAllColumns();
                chk_invoice.IsChecked = true;
                chk_drafs.IsChecked = false;
                chk_return.IsChecked = false;
                //show columns
                col_branch.Visibility = Visibility.Visible;
                col_count.Visibility = Visibility.Visible;
                col_totalNet.Visibility = Visibility.Visible;
                col_discount.Visibility = Visibility.Visible;
                col_tax.Visibility = Visibility.Visible;
                col_type.Visibility = Visibility.Visible;

                fillComboBranches();
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

                hidAllColumns();
                chk_invoice.IsChecked = true;
                chk_drafs.IsChecked = false;
                chk_return.IsChecked = false;
                //show columns
                col_branch.Visibility = Visibility.Visible;
                col_count.Visibility = Visibility.Visible;
                col_pos.Visibility = Visibility.Visible;
                col_totalNet.Visibility = Visibility.Visible;
                col_discount.Visibility = Visibility.Visible;
                col_tax.Visibility = Visibility.Visible;
                col_type.Visibility = Visibility.Visible;

                fillComboPos();
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

                hidAllColumns();
                chk_invoice.IsChecked = true;
                chk_drafs.IsChecked = false;
                chk_return.IsChecked = false;
                //show columns
                col_branch.Visibility = Visibility.Visible;
                col_vendor.Visibility = Visibility.Visible;
                col_agentCompany.Visibility = Visibility.Visible;
                col_discount.Visibility = Visibility.Visible;
                col_count.Visibility = Visibility.Visible;
                col_totalNet.Visibility = Visibility.Visible;
                col_tax.Visibility = Visibility.Visible;
                col_type.Visibility = Visibility.Visible;

                fillComboVendors();
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

                hidAllColumns();
                chk_invoice.IsChecked = true;
                chk_drafs.IsChecked = false;
                chk_return.IsChecked = false;
                //show columns
                col_branch.Visibility = Visibility.Visible;
                col_discount.Visibility = Visibility.Visible;
                col_pos.Visibility = Visibility.Visible;
                col_user.Visibility = Visibility.Visible;
                col_totalNet.Visibility = Visibility.Visible;
                col_tax.Visibility = Visibility.Visible;
                col_type.Visibility = Visibility.Visible;

                fillComboUsers();
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

        #endregion

        #region refreshButton
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

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
        #endregion

        #region branchesEvents

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

        private void chk_Checked(object sender, RoutedEventArgs e)
        {
            fillEventsCall(sender);
        }

        private void dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEventsCall(sender);
        }

        private void dt_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            fillEventsCall(sender);
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
                else if(selectedTab == 2)
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
                else if(selectedTab == 3)
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
        {
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
                    else if(selectedTab == 3)
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
                    if (selectedTab == 1)
                    {
                        for (int i = 0; i < comboBrachTemp.Count; i++)
                        {
                            dynamicComboBranches.Add(comboBrachTemp.Skip(i).FirstOrDefault());
                        }
                        comboBrachTemp.Clear();
                        stk_tagsBranches.Children.Clear();
                        selectedBranchId.Clear();
                    }
                    else if(selectedTab == 1)
                    {
                        for (int i = 0; i < comboPosTemp.Count; i++)
                        {
                            dynamicComboPoss.Add(comboPosTemp.Skip(i).FirstOrDefault());
                        }
                        comboPosTemp.Clear();
                        stk_tagsPos.Children.Clear();
                        selectedPosId.Clear();
                    }
                    else if(selectedTab == 2)
                    {
                        for (int i = 0; i < comboVendorTemp.Count; i++)
                        {
                            dynamicComboVendors.Add(comboVendorTemp.Skip(i).FirstOrDefault());
                        }
                        comboVendorTemp.Clear();
                        stk_tagsVendors.Children.Clear();
                        selectedVendorsId.Clear();
                    }
                    else if(selectedTab == 3)
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
                        MainWindow.mainWindow.BTN_sales_Click(MainWindow.mainWindow.btn_sales, null);
                        uc_sales.Instance.UserControl_Loaded(null, null);
                        uc_sales.Instance.Btn_receiptInvoice_Click(uc_sales.Instance.btn_reciptInvoice, null);
                        uc_receiptInvoice.Instance.UserControl_Loaded(null, null);
                        uc_receiptInvoice._InvoiceType = invoice.invType;
                        uc_receiptInvoice.Instance.invoice = invoice;
                        uc_receiptInvoice.isFromReport = true;
                        if (item.archived == 0)
                            uc_receiptInvoice.archived = false;
                        else
                            uc_receiptInvoice.archived = true;
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

        public void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();
            string addpath = "";
            string firstTitle = "invoice";
            string secondTitle = "";
            string subTitle = "";
            string Title = "";
            

            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                if (selectedTab == 0)
                {
                    addpath = @"\Reports\StatisticReport\Sale\Ar\ArPurSts.rdlc";
                    secondTitle = "branch";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                else if (selectedTab == 1)
                {
                    addpath = @"\Reports\StatisticReport\Sale\Ar\ArPurPosSts.rdlc";
                    secondTitle = "pos";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                else if (selectedTab == 2)
                {
                    addpath = @"\Reports\StatisticReport\Sale\Ar\ArPurVendorSts.rdlc";
                    secondTitle = "customers";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);

                }
                else 
                {
                    addpath = @"\Reports\StatisticReport\Sale\Ar\ArPurUserSts.rdlc";
                    secondTitle = "users";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);

                }

            }
            else
            {
                //english
                if (selectedTab == 0)
                {
                    addpath = @"\Reports\StatisticReport\Sale\En\EnPurSts.rdlc";
                    secondTitle = "branch";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                else if (selectedTab == 1)
                {
                    addpath = @"\Reports\StatisticReport\Sale\En\EnPurPosSts.rdlc";
                    secondTitle = "pos";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                else if (selectedTab == 2)
                {
                    addpath = @"\Reports\StatisticReport\Sale\En\EnPurVendorSts.rdlc";
                    secondTitle = "customers";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }
                else 
                {
                    addpath = @"\Reports\StatisticReport\Sale\En\EnPurUserSts.rdlc";
                    secondTitle = "users";
                    subTitle = clsReports.ReportTabTitle(firstTitle, secondTitle);
                }

            }

            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();
            Title = MainWindow.resourcemanagerreport.GetString("trSalesReport") + " / " + subTitle;
            paramarr.Add(new ReportParameter("trTitle", Title));

            clsReports.SaleInvoiceStsReport(itemTransfers, rep, reppath, paramarr);
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
                    itemTransfers = invLst
                        .Where(j => (selectedBranchId.Count != 0 ? selectedBranchId.Contains((int)j.branchCreatorId) : true));

                    dgInvoice.ItemsSource = itemTransfers
                        .Where(s =>
                        (s.branchCreatorName.Contains(txt_search.Text) ||
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
                       s.posName.Contains(txt_search.Text) ||
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

                #region
              //  Thread t1 = new Thread(() =>
              //{

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

              //});
              //  t1.Start();
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

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}

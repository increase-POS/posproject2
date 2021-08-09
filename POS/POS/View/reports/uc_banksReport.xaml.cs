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
    public partial class uc_banksReport : UserControl
    {
        Statistics statisticModel = new Statistics();
        List<CashTransferSts> payments;
        List<CashTransferSts> recipient;
        List<CashTransferSts> BankChart;

        IEnumerable<Bank> bankCombo;
        Bank bankModel = new Bank();

        IEnumerable<VendorCombo> userPaymentsCombo;
        IEnumerable<AccountantCombo> accPaymentsCombo;

        IEnumerable<VendorCombo> userRecipientCombo;
        IEnumerable<AccountantCombo> accRecipientCombo;

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            payments = await statisticModel.GetPayments();// Deposite
            recipient = await statisticModel.GetReceipt();// Pull
            BankChart = await statisticModel.GetBankTrans();

            bankCombo = await bankModel.GetBanksAsync();

            userPaymentsCombo = statisticModel.getUserAcc(payments, "bn");
            accPaymentsCombo = statisticModel.getAccounantCombo(payments, "bn");

            userRecipientCombo = statisticModel.getUserAcc(recipient, "bn");
            accRecipientCombo = statisticModel.getAccounantCombo(recipient, "bn");

            fillPyamentsEvents();
            hideAllColumn();
            fillBanksCombo(cb_paymentsBank);
            fillUserCombo(userPaymentsCombo, cb_paymentsUser);
            fillAccCombo(accPaymentsCombo, cb_paymentsAccountant);
        }

        private void fillBanksCombo(ComboBox cb)
        {
            cb.SelectedValuePath = "bankId";
            cb.DisplayMemberPath = "name";
            cb.ItemsSource = bankCombo;
        }

        private void fillUserCombo(IEnumerable<VendorCombo> list, ComboBox cb)
        {
            cb.SelectedValuePath = "UserId";
            cb.DisplayMemberPath = "UserAcc";
            cb.ItemsSource = list;
        }

        private void fillAccCombo(IEnumerable<AccountantCombo> list, ComboBox cb)
        {
            cb.SelectedValuePath = "Accountant";
            cb.DisplayMemberPath = "Accountant";
            cb.ItemsSource = list;
        }

        private List<CashTransferSts> fillList(List<CashTransferSts> payments, ComboBox vendor, ComboBox payType, ComboBox accountant
           , DatePicker startDate, DatePicker endDate)
        {
            var selectedItem1 = vendor.SelectedItem as Bank;
            var selectedItem2 = payType.SelectedItem as VendorCombo;
            var selectedItem3 = accountant.SelectedItem as AccountantCombo;

            var result = payments.Where(x => (
              (vendor.SelectedItem != null ? x.bankId == selectedItem1.bankId : true)
                        && (payType.SelectedItem != null ? x.userId == selectedItem2.UserId : true)
                        && (accountant.SelectedItem != null ? x.updateUserAcc == selectedItem3.Accountant : true)
                        && (startDate.SelectedDate != null ? x.updateDate >= startDate.SelectedDate : true)
                        && (endDate.SelectedDate != null ? x.updateDate <= endDate.SelectedDate : true)));

            return result.ToList();
        }
        public uc_banksReport()
        {
            InitializeComponent();
        }
        private static uc_banksReport _instance;
        public static uc_banksReport Instance
        {
            get
            {
                if (_instance == null) _instance = new uc_banksReport();
                return _instance;
            }
        }
        /*********************************************************************/

        int selectedTab = 0;

        public void paint()
        {
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            bdr_payments.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_recipient.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_payments.Fill = Brushes.White;
            path_recipient.Fill = Brushes.White;

            grid_payments.Visibility = Visibility.Hidden;
            grid_recipient.Visibility = Visibility.Hidden;
        }

        private void isEnabledButtons()
        {
            btn_payments.IsEnabled = true;
            btn_recipient.IsEnabled = true;
        }

        private void hideAllColumn()
        {
            grid_payments.Visibility = Visibility.Hidden;
            grid_recipient.Visibility = Visibility.Hidden;

            col_tansNum.Visibility = Visibility.Hidden;
            col_Type.Visibility = Visibility.Hidden;
            col_updateUserAcc.Visibility = Visibility.Hidden;


            col_user.Visibility = Visibility.Hidden;



            col_updateDate.Visibility = Visibility.Hidden;
            col_cash.Visibility = Visibility.Hidden;

            if (selectedTab == 0)
            {
                grid_payments.Visibility = Visibility.Visible;

                col_tansNum.Visibility = Visibility.Visible;
                col_Type.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;

                col_user.Visibility = Visibility.Visible;
                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;
            }
            else if (selectedTab == 1)
            {
                grid_recipient.Visibility = Visibility.Visible;

                col_tansNum.Visibility = Visibility.Visible;
                col_Type.Visibility = Visibility.Visible;
                col_updateUserAcc.Visibility = Visibility.Visible;

                col_user.Visibility = Visibility.Visible;
                col_updateDate.Visibility = Visibility.Visible;
                col_cash.Visibility = Visibility.Visible;
            }


        }

        private void Btn_vendor_Click(object sender, RoutedEventArgs e)
        {
            selectedTab = 0;
            paint();
            bdr_payments.Background = Brushes.White;
            path_payments.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_payments.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_payments.IsEnabled = false;
            btn_payments.Opacity = 1;
            fillPyamentsEvents();
            hideAllColumn();
            fillBanksCombo(cb_paymentsBank);
            fillUserCombo(userPaymentsCombo, cb_paymentsUser);
            fillAccCombo(accPaymentsCombo, cb_paymentsAccountant);
        }

        private void Btn_customer_Click(object sender, RoutedEventArgs e)
        {
            selectedTab = 1;
            paint();
            bdr_recipient.Background = Brushes.White;
            path_recipient.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_recipient.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_recipient.IsEnabled = false;
            btn_recipient.Opacity = 1;
            fillRecipientsEvents();
            hideAllColumn();

            fillBanksCombo(cb_recipientBank);
            fillUserCombo(userRecipientCombo, cb_recipientUser);
            fillAccCombo(accRecipientCombo, cb_recipientAccountant);
        }

        /*Fill Events*/
        /*********************************************************************************/

        private void fillPyamentsEvents()
        {
            dgPayments.ItemsSource = fillList(payments, cb_paymentsBank, cb_paymentsUser, cb_paymentsAccountant, dp_paymentsStartDate, dp_paymentsEndDate).Where(s => s.side == "bn" && s.isConfirm == 1);
            fillPieChart();
            fillColumnChart();
            fillRowChart();
        }

        private void fillRecipientsEvents()
        {
            dgPayments.ItemsSource = fillList(recipient, cb_recipientBank, cb_recipientUser, cb_recipientAccountant, dp_recipientStartDate, dp_recipientEndDate).Where(s => s.side == "bn" && s.isConfirm == 1);
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
            var temp = fillList(BankChart, cb_paymentsBank, cb_paymentsUser, cb_paymentsAccountant, dp_paymentsStartDate, dp_paymentsEndDate).Where(s => s.side == "bn");
            if (selectedTab == 1)
            {
                temp = fillList(BankChart, cb_recipientBank, cb_recipientUser, cb_recipientAccountant, dp_recipientStartDate, dp_recipientEndDate).Where(s => s.side == "bn");
            }

            var result = temp
                .GroupBy(s => new { s.transType })
                .Select(s => new CashTransferSts
                {
                    processTypeCount = s.Count(),
                    processType = s.FirstOrDefault().transType,
                });
            resultList = result.Select(m => m.processTypeCount).ToList();
            titles = result.Select(m => m.transType).ToList();
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

            var temp = fillList(BankChart, cb_paymentsBank, cb_paymentsUser, cb_paymentsAccountant, dp_paymentsStartDate, dp_paymentsEndDate).Where(s => s.side == "bn");
            if (selectedTab == 1)
            {
                temp = fillList(BankChart, cb_recipientBank, cb_recipientUser, cb_recipientAccountant, dp_recipientStartDate, dp_recipientEndDate).Where(s => s.side == "bn");
            }

            var res = temp.GroupBy(x => new { x.bankId, x.transType }).Select(x => new CashTransferSts
            {
                bankName = x.FirstOrDefault().bankName,
                transType = x.FirstOrDefault().transType,
                bankId = x.FirstOrDefault().bankId,
                pullCount = x.Where(g => g.transType == "d").Count(),
                depositCount = x.Where(g => g.transType == "p").Count(),
            });
            resultList = res.GroupBy(x => x.bankId).Select(x => new CashTransferSts
            {
                bankName = x.FirstOrDefault().bankName,
                pullCount = x.Sum(g => g.pullCount),
                depositCount = x.Sum(g => g.depositCount),
                bankId = x.FirstOrDefault().bankId,
                transType = x.FirstOrDefault().transType,
            }
            ).ToList();

            var tempName = res.GroupBy(s => new { s.bankId }).Select(s => new
            {
                itemName = s.FirstOrDefault().bankName,
            });
            names.AddRange(tempName.Select(nn => nn.itemName));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> deposite = new List<int>();
            List<int> pull = new List<int>();



            for (int i = 0; i < resultList.Count(); i++)
            {
                deposite.Add(resultList.ToList().Skip(i).FirstOrDefault().depositCount);
                pull.Add(resultList.ToList().Skip(i).FirstOrDefault().pullCount);

                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = deposite.AsChartValues(),
                DataLabels = true,
                Title = "Deposite"
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = pull.AsChartValues(),
                DataLabels = true,
                Title = "Pull"
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
            if (dp_paymentsStartDate.SelectedDate != null && dp_paymentsEndDate.SelectedDate != null)
            {
                startYear = dp_paymentsStartDate.SelectedDate.Value.Year;
                endYear = dp_paymentsEndDate.SelectedDate.Value.Year;
                startMonth = dp_paymentsStartDate.SelectedDate.Value.Month;
                endMonth = dp_paymentsEndDate.SelectedDate.Value.Month;
            }

            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            List<CashTransferSts> resultList = new List<CashTransferSts>();

            var temp = fillList(BankChart, cb_paymentsBank, cb_paymentsUser, cb_paymentsAccountant, dp_paymentsStartDate, dp_paymentsEndDate).Where(s => s.side == "bn");
            if (selectedTab == 1)
            {
                temp = fillList(BankChart, cb_recipientBank, cb_recipientUser, cb_recipientAccountant, dp_recipientStartDate, dp_recipientEndDate).Where(s => s.side == "bn");
                if (dp_recipientStartDate.SelectedDate != null && dp_recipientEndDate.SelectedDate != null)
                {
                    startYear = dp_recipientStartDate.SelectedDate.Value.Year;
                    endYear = dp_recipientEndDate.SelectedDate.Value.Year;
                    startMonth = dp_recipientStartDate.SelectedDate.Value.Month;
                    endMonth = dp_recipientEndDate.SelectedDate.Value.Month;
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

            if (endYear - startYear <= 1)
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    for (int month = startMonth; month <= 12; month++)
                    {
                        var firstOfThisMonth = new DateTime(year, month, 1);
                        var firstOfNextMonth = firstOfThisMonth.AddMonths(1);
                        var drawCash = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.transType=="p").Sum(c=>c.cash);
                        var drawCard = temp.ToList().Where(c => c.updateDate > firstOfThisMonth && c.updateDate <= firstOfNextMonth && c.transType == "d").Sum(c => c.cash);
                        cash.Add((decimal)drawCash);
                        card.Add((decimal)drawCard);

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
                    cash.Add(drawCash);
                    card.Add(drawCard);
                    MyAxis.Labels.Add(year.ToString());
                }
            }
            rowChartData.Add(
          new LineSeries
          {
              Values = cash.AsChartValues(),
              Title = "Deposite",
          }); ;
            rowChartData.Add(
         new LineSeries
         {
             Values = card.AsChartValues(),
             Title = "Pull",
         });

            DataContext = this;
            rowChart.Series = rowChartData;
        }

        private void Cb_banks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPyamentsEvents();
        }

        private void Chk_allBanks_Checked(object sender, RoutedEventArgs e)
        {
            cb_paymentsBank.IsEnabled = false;
            cb_paymentsBank.SelectedItem = null;
        }

        private void Chk_allBanks_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_paymentsBank.IsEnabled = true;
        }

        private void Cb_paymentsUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPyamentsEvents();
        }

        private void Chk_allPyamentsUser_Checked(object sender, RoutedEventArgs e)
        {
            cb_paymentsUser.IsEnabled = false;
            cb_paymentsUser.SelectedItem = null;
        }

        private void Chk_allPyamentsUser_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_paymentsUser.IsEnabled = true;
        }

        private void Dp_paymentsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPyamentsEvents();
        }

        private void Dp_paymentsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPyamentsEvents();
        }

        private void Cb_paymentsAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillPyamentsEvents();
        }

        private void Chk_allpaymentsAccountant_Checked(object sender, RoutedEventArgs e)
        {
            cb_paymentsAccountant.IsEnabled = false;
            cb_paymentsAccountant.SelectedItem = null;
        }

        private void Chk_allpaymentsAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_paymentsAccountant.IsEnabled = true;
        }

        /****************************************************************/

        private void Cb_recipientBank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillRecipientsEvents();
        }

        private void Chk_allRecipientBanks_Checked(object sender, RoutedEventArgs e)
        {
            cb_recipientBank.IsEnabled = false;
            cb_recipientBank.SelectedItem = null;
        }

        private void Chk_allRecipientBanks_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_recipientBank.IsEnabled = true;
        }

        private void Cb_recipientUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillRecipientsEvents();
        }

        private void Chk_allRecipientUsers_Checked(object sender, RoutedEventArgs e)
        {
            cb_recipientUser.IsEnabled = false;
            cb_recipientUser.SelectedItem = null;
        }

        private void Chk_allRecipientUsers_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_recipientUser.IsEnabled = true;
        }

        private void Cb_recipientAccountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillRecipientsEvents();
        }

        private void Chk_allRecipientAccountant_Checked(object sender, RoutedEventArgs e)
        {
            cb_recipientAccountant.IsEnabled = false;
            cb_recipientAccountant.SelectedItem = null;
        }

        private void Chk_allRecipientAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_recipientAccountant.IsEnabled = true;
        }

        private void Dp_recipientEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillRecipientsEvents();
        }

        private void Dp_recipientStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillRecipientsEvents();
        }
    }
}

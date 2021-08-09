using POS.Classes;
using System;
using System.Collections.Generic;
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

namespace POS.View.reports
{
    public partial class uc_posReports : UserControl
    {
        Statistics statisticModel = new Statistics();
        List<CashTransferSts> list;

        IEnumerable<Branch> branches;
        Branch branchModel = new Branch();

        IEnumerable<Pos> fromPos;
        IEnumerable<Pos> toPos;
        Pos posModel = new Pos();

        private static uc_posReports _instance;
        public static uc_posReports Instance
        {
            get
            {
                if (_instance == null) _instance = new uc_posReports();
                return _instance;
            }
        }
        public uc_posReports()
        {
            InitializeComponent();
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            list = await statisticModel.GetPosTrans();
            branches = await branchModel.GetAllWithoutMain("b");
            fromPos = await posModel.GetPosAsync();
            toPos = await posModel.GetPosAsync();
       
            fillComboBranches();
            fillComboFromPos();
            fillComboToPos();

            fillEvents();
        }
        private List<CashTransferSts> fillList(List<CashTransferSts> payments, ComboBox fromBranch, ComboBox toBranch, ComboBox fromPos, ComboBox toPos
       , DatePicker startDate, DatePicker endDate)
        {
            var selectedItem1 = fromBranch.SelectedItem as Branch;
            var selectedItem2 = toBranch.SelectedItem as Branch;
            var selectedItem3 = fromPos.SelectedItem as Pos;
            var selectedItem4 = toPos.SelectedItem as Pos;


            var result = payments.Where(x => (
              (fromBranch.SelectedItem != null ? x.branchId == selectedItem1.branchId : true)
             && (toBranch.SelectedItem != null ? x.branchId == selectedItem2.branchId : true)
             && (fromPos.SelectedItem != null ? x.posId == selectedItem3.posId : true)
             && (toPos.SelectedItem != null ? x.posId == selectedItem4.posId : true)

                        && (startDate.SelectedDate != null ? x.updateDate >= startDate.SelectedDate : true)
                        && (endDate.SelectedDate != null ? x.updateDate <= endDate.SelectedDate : true)));

            return result.ToList();
        }
        private void fillComboBranches()
        {
            cb_formBranch.SelectedValuePath = "branchId";
            cb_formBranch.DisplayMemberPath = "name";
            cb_formBranch.ItemsSource = branches;

            cb_toBranch.SelectedValuePath = "branchId";
            cb_toBranch.DisplayMemberPath = "name";
            cb_toBranch.ItemsSource = branches;
        }
        private void fillComboFromPos()
        {
            cb_formPos.SelectedValuePath = "posId";
            cb_formPos.DisplayMemberPath = "name";
            cb_formPos.ItemsSource = fromPos;
            if (cb_formBranch.SelectedItem != null)
            {
                var temp = cb_formBranch.SelectedItem as Branch;
                cb_formPos.ItemsSource = fromPos.Where(x => x.branchId == temp.branchId);
            }
        }
        private void fillComboToPos()
        {
            cb_toPos.SelectedValuePath = "posId";
            cb_toPos.DisplayMemberPath = "name";
            cb_toPos.ItemsSource = toPos;
            if (cb_toBranch.SelectedItem != null)
            {
                var temp = cb_toPos.SelectedItem as Branch;
                cb_toPos.ItemsSource = toPos.Where(x => x.branchId == temp.branchId);
            }
        }

        private void fillEvents()
        {
           dgPayments.ItemsSource= fillList(list, cb_formBranch, cb_toBranch, cb_formPos, cb_toPos, dp_StartDate, dp_EndDate);
        }

        private void Cb_formBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillComboFromPos();
            fillEvents();
        }

        private void Chk_allFromBranch_Checked(object sender, RoutedEventArgs e)
        {
            cb_formBranch.IsEnabled = false;
            cb_formBranch.SelectedItem = null;
        }

        private void Chk_allFromBranch_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_formBranch.IsEnabled = true;
        }

        private void Chk_allToBranch_Checked(object sender, RoutedEventArgs e)
        {
            cb_toBranch.IsEnabled = false;
            cb_toBranch.SelectedItem = null;
        }

        private void Chk_allToBranch_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_toBranch.IsEnabled = true;
        }

        private void Cb_formPos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEvents();
        }

        private void Chk_allFromPos_Checked(object sender, RoutedEventArgs e)
        {
            cb_formPos.IsEnabled = false;
            cb_formPos.SelectedItem = null;
        }

        private void Chk_allFromPos_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_formPos.IsEnabled = true;
        }

        private void Chk_allToPos_Checked(object sender, RoutedEventArgs e)
        {
            cb_toPos.IsEnabled = false;
            cb_toPos.SelectedItem = null;
        }

        private void Chk_allToPos_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_toPos.IsEnabled = true;
        }

        private void Cb_toBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillComboToPos();
            fillEvents();
        }

        private void Cb_toPos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEvents();
        }

        private void Dp_EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEvents();
        }

        private void Dp_StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEvents();
        }

        private void Cb_Accountant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillEvents();
        }

        private void Chk_allAccountant_Checked(object sender, RoutedEventArgs e)
        {
            cb_Accountant.IsEnabled = false;
            cb_Accountant.SelectedItem = null;
        }

        private void Chk_allAccountant_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_Accountant.IsEnabled = true;
        }


    }
}

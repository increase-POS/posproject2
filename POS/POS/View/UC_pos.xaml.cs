using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_pos.xaml
    /// </summary>
    public partial class UC_pos : UserControl
    {
        Pos posModel = new Pos();

        Branch branchModel = new Branch();

        Pos pos = new Pos();

        Branch branch = new Branch();

        IEnumerable<Pos> possQuery;
        IEnumerable<Pos> poss;
        byte tgl_posState;
        string searchText = "";

        BrushConverter bc = new BrushConverter();
        public UC_pos() 
         {
            InitializeComponent();
        }

        private async void fillBranches()
        {
            var branches = await branchModel.GetBranchesAsync("b");
            cb_branch.ItemsSource = branches;
            cb_branch.SelectedValuePath = "branchId";
            cb_branch.DisplayMemberPath = "name";
            //dt.ItemsSource = branches;
            //Branch branch = new Branch();
            //for (int i = 0; i < branches.Count; i++)
            //{
            //    branch = dt.Items[i] as Branch;
            //    branchIds.Add(branch.branchId);
            //    branchNames.Add(branch.name);
            //}
            ////MessageBox.Show(branches.Count.ToString());
            ////branchNames.Add("first"); branchNames.Add("second");
            //cb_branchId.ItemsSource = branchNames;

        }

        private async void DG_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            p_errorSelectBranch.Visibility = Visibility.Collapsed;

            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorSelectBranch.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_pos.SelectedIndex != -1)
            {
                pos = dg_pos.SelectedItem as Pos;
                this.DataContext = pos;
            }
            if (pos != null)
            {
                if (pos.branchId != 0)
                {
                    //display branch by id
                    branch = await branchModel.getBranchById(pos.branchId.Value);
                    cb_branch.SelectedValue = branch.branchId;
                }

                if (pos.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else
                {
                    if (pos.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                    else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
                }
            }
        }

        private void Tb_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
        }

        private void Tb_code_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
        }

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }

        private void Cb_branchId_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
        }

        private void Cb_branchId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBoxItem typeItem = (ComboBoxItem)cb_branch.SelectedItem;
            //string value = typeItem.Name.ToString();
            //string s = cb_branch.Items.GetItemAt(Convert.ToInt32(cb_branch.SelectedValuePath)).ToString();
            //MessageBox.Show("+"+ s+"+");
            SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
        }
        private void translate()
        {
            txt_pos.Text = MainWindow.resourcemanager.GetString("trPOS");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
         //   MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectPosNameHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trPosNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trPosCodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trSelectPosBranchHint"));

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            dg_pos.Columns[0].Header = MainWindow.resourcemanager.GetString("trPosName");
            dg_pos.Columns[1].Header = MainWindow.resourcemanager.GetString("trPosCode");
            dg_pos.Columns[2].Header = MainWindow.resourcemanager.GetString("trBranchName");
            dg_pos.Columns[3].Header = MainWindow.resourcemanager.GetString("trBalance");

            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_code.Content = MainWindow.resourcemanager.GetString("trCode");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_branch.Content = MainWindow.resourcemanager.GetString("trBranch");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucPos.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucPos.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

            fillBranches();

            Keyboard.Focus(tb_name);

            cb_branch.SelectedIndex = 0;

            this.Dispatcher.Invoke(() =>
            {
                Tb_search_TextChanged(null, null);
            });

            //var poss = await posModel.GetPosAsync();
            //dg_pos.ItemsSource = poss;

            //dg_pos.Columns["MyColumn"]

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            tb_name.Clear();
            tb_code.Clear();
            tb_notes.Clear();
            cb_branch.SelectedIndex = -1;

            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            p_errorSelectBranch.Visibility = Visibility.Collapsed;
            
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            cb_branch.Background = (Brush)bc.ConvertFrom("#f8f8f8");

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            pos.posId = 0;
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty code
            SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
            //chk empty branch
            SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
            if ((!tb_name.Text.Equals("")) && (!tb_code.Text.Equals("")) && (!cb_branch.Text.Equals("")))
            {
                pos.code = tb_code.Text;
                pos.name = tb_name.Text;
                pos.branchId = Convert.ToInt32(cb_branch.SelectedValue);
                pos.createUserId = MainWindow.userID.Value;
                pos.updateUserId = MainWindow.userID.Value;
                pos.isActive = 1;
                pos.note = tb_notes.Text;

                string s = await posModel.savePos(pos);
                MessageBox.Show(s);
                if (s.Equals("Pos Is Added Successfully")) { SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null); }
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            }

            poss = await posModel.GetPosAsync();
            possQuery = poss.Where(s => s.isActive == Convert.ToInt32(tgl_posIsActive.IsChecked));
            dg_pos.ItemsSource = possQuery;

        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty code
            SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
            //chk empty branch
            SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
            if ((!tb_name.Text.Equals("")) && (!tb_code.Text.Equals("")) && (!cb_branch.Text.Equals("")))
            {
                pos.code = tb_code.Text;
                pos.name = tb_name.Text;
                pos.branchId = Convert.ToInt32(cb_branch.SelectedValue);
                pos.updateUserId = MainWindow.userID.Value;
                pos.note = tb_notes.Text;

                string s = await posModel.savePos(pos);

                if (s.Equals("Pos Is Updated Successfully")) { SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate")); Btn_clear_Click(null, null); }
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            }

            poss = await posModel.GetPosAsync();
            possQuery = poss.Where(s => s.isActive == Convert.ToInt32(tgl_posIsActive.IsChecked));
            dg_pos.ItemsSource = possQuery;

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if ((!pos.canDelete) && (pos.isActive == 0))
                activate();
            else
            {
                string popupContent = "";
                if (pos.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                if ((!pos.canDelete) && (pos.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                bool b = await posModel.deletePos(pos.posId, MainWindow.userID.Value, pos.canDelete);

                if (b) SectionData.popUpResponse("", popupContent);
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

            }

            poss = await posModel.GetPosAsync();
            possQuery = poss.Where(s => s.isActive == Convert.ToInt32(tgl_posIsActive.IsChecked));
            dg_pos.ItemsSource = possQuery;

            //clear textBoxs
            Btn_clear_Click(sender, e);

        }

        private async void activate()
        {//activate
            pos.isActive = 1;

            string s = await posModel.savePos(pos);

            if (s.Equals("Pos Is Updated Successfully")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

        }

        async Task<IEnumerable<Pos>> RefreshPosList()
        {
            poss = await posModel.GetPosAsync();
            return poss;
        }
        void RefreshPosView()
        {
            dg_pos.ItemsSource = possQuery;
            txt_count.Text = possQuery.Count().ToString();
            cb_branch.SelectedIndex = -1;
        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            p_errorName.Visibility = Visibility.Collapsed;
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (poss is null)
                await RefreshPosList();
            searchText = tb_search.Text;
            possQuery = poss.Where(s => (s.name.Contains(searchText) ||
            s.code.Contains(searchText)
            ) && s.isActive == tgl_posState);
            RefreshPosView();

        }

        private async void Tgl_posIsActive_Checked(object sender, RoutedEventArgs e)
        {
            //Active
            if (poss is null)
                await RefreshPosList();
            tgl_posState = 1;
            Tb_search_TextChanged(null, null);
        }

        private async void Tgl_posIsActive_Unchecked(object sender, RoutedEventArgs e)
        {//inActive
            if (poss is null)
                await RefreshPosList();
            tgl_posState = 0;
            Tb_search_TextChanged(null, null);
        }

        void FN_ExportToExcel()
        {

            var QueryExcel = possQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                Code = x.code,
                Branch = x.branchName,
                Notes = x.note
            });
            var DTForExcel = QueryExcel.ToDataTable();

            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trCode");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trBranch");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trNote");


            ExportToExcel.Export(DTForExcel);

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });
        }
    }
}

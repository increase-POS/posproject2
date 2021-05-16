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
    /// Interaction logic for UC_branch.xaml
    /// </summary>
    public partial class UC_branch : UserControl
    {

        Branch branchModel = new Branch();

        Branch branch = new Branch();

        IEnumerable<Branch> branchesQuery;
        IEnumerable<Branch> branches;
        byte tgl_branchState;
        string searchText = "";

        int ParentId = 0;

        BrushConverter bc = new BrushConverter();

        public UC_branch()
        {
            InitializeComponent();
        }

        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName,"trEmptyNameToolTip");

        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName , "trEmptyNameToolTip");
        }

        private void translate()
        {
            txt_branch.Text = MainWindow.resourcemanager.GetString("trBranch");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
         //   MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectBranchHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trCodeHint"));
            txt_contentInformatin.Text = MainWindow.resourcemanager.GetString("trMoreInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_area, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            
            dg_branch.Columns[0].Header = MainWindow.resourcemanager.GetString("trCode");
            dg_branch.Columns[1].Header = MainWindow.resourcemanager.GetString("trName");
            dg_branch.Columns[2].Header = MainWindow.resourcemanager.GetString("trAddress");
            dg_branch.Columns[3].Header = MainWindow.resourcemanager.GetString("trNote");

            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            tt_code.Content = MainWindow.resourcemanager.GetString("trCode");
            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_branch.Content = MainWindow.resourcemanager.GetString("trParentBranch");
            tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
            tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
            tt_email.Content = MainWindow.resourcemanager.GetString("trEmail");
            tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucBranch.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucBranch.FlowDirection = FlowDirection.RightToLeft; }

            translate();

            //fill combo
            if (branches == null) branches = await branchModel.GetBranchesAsync("b");
            branchesQuery = branches.Where(s =>  s.isActive == 1);
            cb_branch.ItemsSource = branchesQuery;
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
            cb_branch.SelectedIndex = -1;

            cb_area.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            //if (cb_branch.Items.Count > 0)
            //    cb_branch.SelectedIndex = 0;

            Keyboard.Focus(tb_code);

            //SectionData.genRandomCode("b", "Branch");
            //tb_code.Text = SectionData.code;

            //this.Dispatcher.Invoke(() =>
            //{
            //    tb_search_TextChanged(null, null);
            //});

            //branches = await branchModel.GetAllWithoutMain("b");
            //MessageBox.Show(Convert.ToString(branches.Count()));
            //branches = await branchModel.GetBranchesAsync("b");
            //MessageBox.Show(Convert.ToString(branches.Count()));


        }

        private void Dg_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorBranch.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorMobile.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;

            cb_branch.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_branch.SelectedIndex != -1)
            {
                branch = dg_branch.SelectedItem as Branch;
                this.DataContext = branch;
            }

            if (branch != null)
            {
                //mobile
                if ((branch.mobile != null) && (branch.mobile.ToArray().Length > 4))
                {
                    string area = new string(branch.mobile.Take(4).ToArray());
                    var mobile = branch.mobile.Substring(4, branch.mobile.Length - 4);

                    cb_area.Text = area;
                    tb_mobile.Text = mobile.ToString();
                }
                else
                {
                    cb_area.SelectedIndex = -1;
                    tb_mobile.Clear();
                }
                //phone
                if ((branch.phone != null) && (branch.phone.ToArray().Length > 7))
                {
                    string area = new string(branch.phone.Take(4).ToArray());
                    string areaLocal = new string(branch.phone.Substring(4, branch.phone.Length - 4).Take(3).ToArray());

                    var phone = branch.phone.Substring(7, branch.phone.Length - 7);

                    cb_areaPhone.Text = area;
                    cb_areaPhoneLocal.Text = areaLocal;
                    tb_phone.Text = phone.ToString();
                }
                else
                {
                    cb_areaPhone.SelectedIndex = -1;
                    cb_areaPhoneLocal.SelectedIndex = -1;
                    tb_phone.Clear();
                }
                //parent branch
                try
                {
                    cb_branch.SelectedValue = branch.parentId.Value;
                }
                catch
                {
                    cb_branch.SelectedValue = -1;
                }

                if (branch.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else
                {
                    if (branch.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                    else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
                }
            }

        }

      
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_code.Clear();
            tb_name.Clear();
            cb_branch.SelectedIndex = -1;
            tb_address.Clear();
            tb_notes.Clear();
            tb_email.Clear();
            cb_area.SelectedIndex = 0;
            tb_mobile.Clear();
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            tb_phone.Clear();

            p_errorBranch.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorMobile.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;

            cb_branch.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_mobile.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            //SectionData.genRandomCode("b" ,"Branch");
            //tb_code.Text = SectionData.code;

        }
        // Error Here
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            branch.branchId = 0;
           
            bool iscodeExist = await SectionData.isCodeExist(tb_code.Text, "b", "Branch" , 0);
           //chk empty branch
            SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
            //chk empty code
            SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode , "trEmptyCodeToolTip");
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName , "trEmptyNameToolTip");
            //chk empty mobile
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile , "trEmptyMobileToolTip");
            //validate email
            SectionData.validateEmail(tb_email ,p_errorEmail ,tt_email);
           
            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + cb_areaPhoneLocal.Text + tb_phone.Text;

            bool emailError = false;

            if (!tb_email.Text.Equals(""))
                if (!SectionData.IsValid(tb_email.Text))
                    emailError = true;

            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")) && (!tb_code.Text.Equals("")) && (!cb_branch.Text.Equals("")))
            {
                if (emailError)
                    SectionData.validateEmail(tb_email , p_errorEmail , tt_errorEmail);
                //duplicate
                else if (iscodeExist)
                    SectionData.validateDuplicateCode(tb_code ,  p_errorCode, tt_errorCode);
                else
                {
                    //SectionData.genRandomCode("b", "Branch");
                    //tb_code.Text = SectionData.code;

                    branch.code = tb_code.Text;
                    branch.name = tb_name.Text;
                    branch.notes = tb_notes.Text;
                    branch.address = tb_address.Text;
                    branch.email = tb_email.Text;
                    branch.phone = phoneStr;
                    branch.mobile = cb_area.Text + tb_mobile.Text;
                    branch.createUserId = MainWindow.userID;
                    branch.updateUserId = MainWindow.userID;
                    branch.type = "b";
                    branch.isActive = 1;
                    branch.parentId = ParentId;

                    string s = await branchModel.saveBranch(branch);

                    if (s.Equals("true")) { SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null); }
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                }
            }
            //else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAddValidate"));

            branches = await branchModel.GetAllWithoutMain("b");
            branchesQuery = branches.Where(s => s.isActive == Convert.ToInt32(tgl_branchIsActive.IsChecked));
            dg_branch.ItemsSource = branchesQuery;

        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

            bool iscodeExist = await SectionData.isCodeExist(tb_code.Text, "b", "Branch" , branch.branchId);

            //chk empty branch
            SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
            //chk empty code
            SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty mobile
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile, "trEmptyMobileToolTip");
            //validate email
            SectionData.validateEmail(tb_email, p_errorEmail, tt_email);

            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + cb_areaPhoneLocal.Text + tb_phone.Text;

            bool emailError = false;

            if (!tb_email.Text.Equals(""))
                if (!SectionData.IsValid(tb_email.Text))
                    emailError = true;
            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")) && (!tb_code.Text.Equals("")) && (!cb_branch.Text.Equals("")))
            {
                if (emailError)
                    SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                else if (iscodeExist)
                    SectionData.validateDuplicateCode(tb_code, p_errorCode, tt_errorCode);
                else
                {
                    //SectionData.genRandomCode("b" , "Branch");
                    //tb_code.Text = SectionData.code;

                    branch.code = tb_code.Text;
                    branch.name = tb_name.Text;
                    branch.notes = tb_notes.Text;
                    branch.address = tb_address.Text;
                    branch.email = tb_email.Text;
                    branch.phone = phoneStr;
                    branch.mobile = cb_area.Text + tb_mobile.Text;
                    branch.updateUserId = MainWindow.userID;
                    branch.type = "b";
                    branch.isActive = 1;
                    branch.parentId = ParentId;
                    
                    string s = await branchModel.saveBranch(branch);

                    if (s.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                    //var branches = await branchModel.GetBranchesAsync("b");
                    //dg_branch.ItemsSource = branches;
                }
            }
            //else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdateValidate"));

            branches = await branchModel.GetAllWithoutMain("b");
            branchesQuery = branches.Where(s => s.isActive == Convert.ToInt32(tgl_branchIsActive.IsChecked));
            dg_branch.ItemsSource = branchesQuery;

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if ((!branch.canDelete) && (branch.isActive == 0))
                activate();
            else
            {
                string popupContent = "";
                if (branch.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                if ((!branch.canDelete) && (branch.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                bool b = await branchModel.deleteBranch(branch.branchId, MainWindow.userID.Value ,branch.canDelete);

                if (b) SectionData.popUpResponse("", popupContent);
                else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            }

            branches = await branchModel.GetAllWithoutMain("b");
            branchesQuery = branches.Where(s => s.isActive == Convert.ToInt32(tgl_branchIsActive.IsChecked));
            dg_branch.ItemsSource = branchesQuery;

            //clear textBoxs
            Btn_clear_Click(sender, e);

        }

        private async void activate()
        {//activate
            branch.isActive = 1;

            string s = await branchModel.saveBranch(branch);

            if (s.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

        }

        private async void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            var bc = new BrushConverter();

            p_errorName.Visibility = Visibility.Collapsed;
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (branches is null)
                await RefreshBranchesList();
            searchText = tb_search.Text;
            branchesQuery = branches.Where(s => (s.code.Contains(searchText) ||
            s.name.Contains(searchText) ||
            s.mobile.Contains(searchText)
            ) && s.isActive == tgl_branchState);
            RefreshBranchView();

        }

        private void tb_mobile_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_phone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void tb_mobile_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile , "trEmptyMobileToolTip");
        }

        private void tb_mobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_mobile, p_errorMobile, tt_errorMobile , "trEmptyMobileToolTip");
        }

        private async void tgl_branchIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (branches is null)
                await RefreshBranchesList();
            tgl_branchState = 1;
            tb_search_TextChanged(null, null);
        }

        private async void tgl_branchIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (branches is null)
                await RefreshBranchesList();
            tgl_branchState = 0;
            tb_search_TextChanged(null, null);
        }

        async Task<IEnumerable<Branch>> RefreshBranchesList()
        {
            branches = await branchModel.GetAllWithoutMain("b");
            return branches;
        }
        void RefreshBranchView()
        {
            dg_branch.ItemsSource = branchesQuery;
            txt_Count.Text = branchesQuery.Count().ToString();
            cb_area.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            cb_branch.SelectedIndex = -1;
        }

        private void btn_branchExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });
        }
        
        void FN_ExportToExcel()
        {
            var QueryExcel = branchesQuery.AsEnumerable().Select(x => new
            {
                Code = x.code,
                Name = x.name,
                Mobile = x.mobile,
                Phone = x.phone,
                Email = x.email,
                Address = x.address,
                Notes = x.notes,

            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trCode");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trMobile");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trPhone");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trEmail");
            DTForExcel.Columns[5].Caption = MainWindow.resourcemanager.GetString("trAddress");
            DTForExcel.Columns[6].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);

        }

        private void cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                ParentId = Convert.ToInt32(cb_branch.SelectedValue);
            }
            catch 
            { ParentId = 0; }
        }

        private void tb_code_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode ,"trEmptyCodeToolTip");
        }

        private void tb_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode , "trEmptyCodeToolTip");
        }

        private void cb_branch_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch,"trEmptyBranchToolTip");
        }
    }
}


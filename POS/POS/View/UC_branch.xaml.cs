
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
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

        public int BranchId;

        bool CanDelete = false;

        Branch branchModel = new Branch();

        public UC_branch()
        {
            InitializeComponent();
        }

       
        private void Tb_email_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (!tb_email.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                {
                    p_errorEmail.Visibility = Visibility.Visible;
                    tt_errorEmail.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                    tb_email.Background = (Brush)bc.ConvertFrom("#15FF0000");
                }
                else
                {
                    p_errorEmail.Visibility = Visibility.Collapsed;
                    tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                }
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

   

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        //private void Tb_code_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var bc = new BrushConverter();

        //    if (tb_code.Text.Equals(""))
        //    {
        //        p_errorCode.Visibility = Visibility.Visible;
        //        tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyCodeToolTip");
        //        tb_code.Background = (Brush)bc.ConvertFrom("#15FF0000");
        //    }
        //    else
        //    {
        //        p_errorCode.Visibility = Visibility.Collapsed;
        //        tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        //    }
        //}

        //private void Tb_code_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    var bc = new BrushConverter();

        //    if (tb_code.Text.Equals(""))
        //    {
        //        p_errorCode.Visibility = Visibility.Visible;
        //        tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyCodeToolTip");
        //        tb_code.Background = (Brush)bc.ConvertFrom("#15FF0000");
        //    }
        //    else
        //    {
        //        p_errorCode.Visibility = Visibility.Collapsed;
        //        tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        //    }
        //}

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
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNotesHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            
            dg_branch.Columns[0].Header = MainWindow.resourcemanager.GetString("trCode");
            dg_branch.Columns[1].Header = MainWindow.resourcemanager.GetString("trName");
            dg_branch.Columns[2].Header = MainWindow.resourcemanager.GetString("trAddress");
            dg_branch.Columns[3].Header = MainWindow.resourcemanager.GetString("trNotes");

            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            tt_code.Content = MainWindow.resourcemanager.GetString("trCode");
            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_mobile.Content = MainWindow.resourcemanager.GetString("trMobile");
            tt_phone.Content = MainWindow.resourcemanager.GetString("trPhone");
            tt_email.Content = MainWindow.resourcemanager.GetString("trEmail");
            tt_address.Content = MainWindow.resourcemanager.GetString("trAddress");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");

        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucBranch.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucBranch.FlowDirection = FlowDirection.RightToLeft; }

            translate();

            var branches = await branchModel.GetBranchesAsync("b");
            dg_branch.ItemsSource = branches;

            cb_area.SelectedIndex = 0;
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
        }

        private void Dg_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;

            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            Branch branch = new Branch();

            if (dg_branch.SelectedIndex != -1)
            {
                branch = dg_branch.SelectedItem as Branch;
                this.DataContext = branch;
            }

            if (branch != null)
            {
                if (branch.branchId != 0)
                {
                    BranchId = branch.branchId;
                    CanDelete = branch.canDelete;
                    //MessageBox.Show(BranchId.ToString() +" "+CanDelete.ToString());
                }
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

                    MessageBox.Show(areaLocal);
                }
                else
                {
                    cb_areaPhone.SelectedIndex = -1;
                    cb_areaPhoneLocal.SelectedIndex = -1;
                    tb_phone.Clear();
                }
               
                if (CanDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
            }

        }

      
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_name.Text = "";
            tb_code.Text = "";
            tb_address.Text = "";
            tb_notes.Text = "";
            tb_email.Text = "";
            cb_area.SelectedIndex = 0;
            tb_mobile.Text = "";
            cb_areaPhone.SelectedIndex = 0;
            cb_areaPhoneLocal.SelectedIndex = 0;
            tb_phone.Text = "";

            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;

            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");

        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
            }
            if (tb_mobile.Text.Equals(""))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyMobileToolTip");
            }
            else
            {
                p_errorMobile.Visibility = Visibility.Collapsed;

            }
            if (!tb_email.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                {
                    p_errorEmail.Visibility = Visibility.Visible;
                    tt_errorEmail.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                }
                else
                {
                    p_errorEmail.Visibility = Visibility.Collapsed;
                }
            }
            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + cb_areaPhoneLocal.Text + tb_phone.Text;
            MessageBox.Show(cb_areaPhone.Text +" "+ cb_areaPhoneLocal.Text +" "+ tb_phone.Text);
            bool emailError = false;
            
            if (!tb_email.Text.Equals(""))
                if (!SectionData.IsValid(tb_email.Text))
                    emailError = true;
            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")))
            {
                if (emailError)
                    SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trErrorEmailToolTip"));
                else
                {
                    SectionData.genRandomCode("b", "Branch");

                    tb_code.Text = SectionData.code;
                    Branch branch = new Branch
                    {
                        code = tb_code.Text,
                        name = tb_name.Text,
                        notes = tb_notes.Text,
                        address = tb_address.Text,
                        email = tb_email.Text,
                        phone = phoneStr,
                        mobile = cb_area.Text + tb_mobile.Text,
                        createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                        updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                        createUserId = MainWindow.userID,
                        updateUserId = MainWindow.userID,
                        type = "b",
                        isActive = 1
                    };
                   
                    string s = await branchModel.saveBranch(branch);

                    if (s.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd"));
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                    var agents = await branchModel.GetBranchesAsync("b");
                    dg_branch.ItemsSource = agents;
                }
            }
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAddValidate"));

        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
            }
            if (tb_mobile.Text.Equals(""))
            {
                p_errorMobile.Visibility = Visibility.Visible;
                tt_errorMobile.Content = MainWindow.resourcemanager.GetString("trEmptyMobileToolTip");
            }
            else
            {
                p_errorMobile.Visibility = Visibility.Collapsed;

            }
            if (!tb_email.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb_email.Text))
                {
                    p_errorEmail.Visibility = Visibility.Visible;
                    tt_errorEmail.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                }
                else
                {
                    p_errorEmail.Visibility = Visibility.Collapsed;
                }
            }
            string phoneStr = "";
            if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + cb_areaPhoneLocal.Text + tb_phone.Text;

            bool emailError = false;

            if (!tb_email.Text.Equals(""))
                if (!SectionData.IsValid(tb_email.Text))
                    emailError = true;
            if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")))
            {
                if (emailError)
                    SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trErrorEmailToolTip"));
                else
                {
                    SectionData.genRandomCode("b" , "Branch");
                    tb_code.Text = SectionData.code;
                    Branch branch = new Branch
                    {
                        branchId = BranchId,
                        code = tb_code.Text,
                        name = tb_name.Text,
                        notes = tb_notes.Text,
                        address = tb_address.Text,
                        email = tb_email.Text,
                        phone = phoneStr,
                        mobile = cb_area.Text + tb_mobile.Text,
                        createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                        updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                        createUserId = MainWindow.userID,
                        updateUserId = MainWindow.userID,
                        type = "b",
                        isActive = 1
                    };

                    string s = await branchModel.saveBranch(branch);

                    if (s.Equals("true")) SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
                    else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

                    var branches = await branchModel.GetBranchesAsync("b");
                    dg_branch.ItemsSource = branches;
                }
            }
            else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdateValidate"));

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            string popupContent = "";
            if (CanDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
            else popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

            bool b = await branchModel.deleteBranch(BranchId, CanDelete);

            if (b) SectionData.popUpResponse("", popupContent);
             else SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));

            var agents = await branchModel.GetBranchesAsync("b");
            dg_branch.ItemsSource = agents;

            //clear textBoxs
            Btn_clear_Click(sender ,e );

        }

        private async void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            var branches = await branchModel.SearchBranches("b", tb_search.Text);
            dg_branch.ItemsSource = branches;

        }

        private async void tb_search_LostFocus(object sender, RoutedEventArgs e)
        {
            var branches = await branchModel.GetBranchesAsync("b");
            dg_branch.ItemsSource = branches;
        }
    }
}


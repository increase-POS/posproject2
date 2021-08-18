using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_selectPos.xaml
    /// </summary>
    public partial class wd_selectPos : Window
    {
        public wd_selectPos()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            { SectionData.ExceptionMessage(ex,this); }
        }
        BrushConverter bc = new BrushConverter();
        public int branchID = 0;
        Branch branchModel = new Branch();
        Pos posModel = new Pos();
        Branch branch = new Branch();
        IEnumerable<Branch> branches;
        IEnumerable<Pos> poss;

        SetValues valueModel = new SetValues();
        SettingCls setModel = new SettingCls();
        public int settingsPoSId = 0;
        public int userId;
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                #region translate

                //if (winLogIn.lang.Equals("en"))
                //{
                //    winLogIn.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                //    grid_changePassword.FlowDirection = FlowDirection.LeftToRight;
                //}
                //else
                //{
                //    winLogIn.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                //    grid_changePassword.FlowDirection = FlowDirection.RightToLeft;
                //}

                //translate();
                #endregion

                fillBranch();
            }
            catch(Exception ex)
            { SectionData.ExceptionMessage(ex,this,sender); }
        }

        private async void fillBranch()
        {
            branches = await branchModel.GetBranchesActive("b");
            cb_branch.ItemsSource = branches;
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
            cb_branch.SelectedIndex = -1;
        }

        private void translate()
        {
            txt_title.Text = winLogIn.resourcemanager.GetString("trInstallationSettings");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, winLogIn.resourcemanager.GetString("trBranchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_pos, winLogIn.resourcemanager.GetString("trPosHint"));

            btn_save.Content = winLogIn.resourcemanager.GetString("trSave");
            tt_branch.Content = winLogIn.resourcemanager.GetString("trBranch");
            tt_pos.Content = winLogIn.resourcemanager.GetString("trPosTooltip");
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    Btn_save_Click(null, null);
                }
            }
            catch(Exception ex)
            { SectionData.ExceptionMessage(ex,this,sender); }
        }

        List<SettingCls> set = new List<SettingCls>();
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save

            #region validate
            validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
            validateEmptyComboBox(cb_pos , p_errorPos , tt_errorPos , "trErrorEmptyPosToolTip");
            #endregion

            if (!cb_pos.Text.Equals(""))
            {
                //update pos and branch in main window
                MainWindow.branchID = Convert.ToInt32(cb_branch.SelectedValue);
                MainWindow.posID = Convert.ToInt32(cb_pos.SelectedValue);
                
                //save pos and branch to settings file
                Properties.Settings.Default.pos = cb_pos.SelectedValue.ToString();
                Properties.Settings.Default.Save();

                Window.GetWindow(this).Opacity = 0.2;
                wd_setupGeneralSetting w = new wd_setupGeneralSetting();
                w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;

                this.Close();
            }
            else
            {
            }
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cb_branch.SelectedIndex = -1;
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }



        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }

        private void validateEmpty(string name, object sender)
        {
            if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_branch")
                    validateEmptyComboBox((ComboBox)sender, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
                if ((sender as ComboBox).Name == "cb_pos")
                    validateEmptyComboBox((ComboBox)sender, p_errorBranch, tt_errorBranch, "trErrorEmptyPosToolTip");
            }
        }

        private async void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//select branch
            int bId = Convert.ToInt32(cb_branch.SelectedValue);
            poss = await posModel.GetPosAsync();
            var pos = poss.Where(p => p.branchId == bId);
            cb_pos.ItemsSource = pos;
            cb_pos.DisplayMemberPath = "name";
            cb_pos.SelectedValuePath = "posId";
            cb_pos.SelectedIndex = -1;
        }

        private void validateEmptyComboBox(ComboBox cb, Path p_error, ToolTip tt_error, string tr)
        {
            if (cb.SelectedIndex == -1)
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = winLogIn.resourcemanager.GetString(tr);
                cb.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                cb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;

            }
        }
    }
}

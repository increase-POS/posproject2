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
            InitializeComponent();
        }
        BrushConverter bc = new BrushConverter();
        public int branchID = 0;
        Branch branchModel = new Branch();
        Branch branch = new Branch();

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {//load

            #region translate

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_changePassword.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_changePassword.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            #endregion

            fillBranch();
        }

        private async void fillBranch()
        {
           
        }

        private void translate()
        {
            txt_title.Text = MainWindow.resourcemanager.GetString("trPos");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trBranchHint"));
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
            tt_branch.Content = MainWindow.resourcemanager.GetString("trBranch");
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }

      
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
           
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
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorBranch, tt_errorBranch, "trEmptyBranch");
            }
        }

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

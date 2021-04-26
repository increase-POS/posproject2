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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_pos.xaml
    /// </summary>
    public partial class UC_pos : UserControl
    {
        public int posId;
        //Pos pos = new Pos();
        public UC_pos() 
         {
            InitializeComponent();
           // List<Pos> poss = new List<Pos>();

            

            for (int i = 1; i < 50; i++)
            {
                //poss.Add(new Pos()
                //{
                //    Id = i,
                //    name = "branch name " + i,
                //    code = "branch code" + i,
                //    balance  = "balance " + i,
                //    branchName = "branch name "+ i

                //}); ; ;
            }

            //dg_pos.ItemsSource = poss;
        }
        
        private void DG_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Pos pos = new Pos();
            if (dg_pos.SelectedIndex != -1)
            {
                //pos = dg_pos.SelectedItem as Pos;
                //this.DataContext = pos;
                //if (pos != null)
                //{
                //    if (pos.Id != 0)
                //    {
                //        posId = pos.Id;
                //    }
                //}
            }
        }

        private void Tb_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_code.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyCodeToolTip");
                tb_code.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorCode.Visibility = Visibility.Collapsed;
                tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_code_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_code.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyCodeToolTip");
                tb_code.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorCode.Visibility = Visibility.Collapsed;
                tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
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

        private void Tb_balance_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_balance.Text.Equals(""))
            {
                p_errorBalance.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyBalanceToolTip");
                tb_balance.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorBalance.Visibility = Visibility.Collapsed;
                tb_balance.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_balance_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_balance.Text.Equals(""))
            {
                p_errorBalance.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyBalanceToolTip");
                tb_balance.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorBalance.Visibility = Visibility.Collapsed;
                tb_balance.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Cb_branchId_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (cb_branchId.Text.Equals(""))
            {
                p_errorSelectBranch.Visibility = Visibility.Visible;
                tt_errorSelectBranch.Content = MainWindow.resourcemanager.GetString("trEmptyBalanceToolTip");
                cb_branchId.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorSelectBranch.Visibility = Visibility.Collapsed;
                cb_branchId.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }
        private void translate()
        {
            txt_pos.Text = MainWindow.resourcemanager.GetString("trPOS");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectPosNameHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trPosNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trPosCodeHint"));
            txt_moreInformation.Text = MainWindow.resourcemanager.GetString("trMoreInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branchId, MainWindow.resourcemanager.GetString("trSelectPosBranchHint"));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_balance, MainWindow.resourcemanager.GetString("trBalanceHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            dg_pos.Columns[0].Header = MainWindow.resourcemanager.GetString("trPosName");
            dg_pos.Columns[1].Header = MainWindow.resourcemanager.GetString("trPosCode");
            dg_pos.Columns[2].Header = MainWindow.resourcemanager.GetString("trBranchName");
            dg_pos.Columns[3].Header = MainWindow.resourcemanager.GetString("trBalance");
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

        }


        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
                tb_name.Text = "";
            tb_balance.Text = "";
            tb_code.Text = "";
            cb_branchId.Text = "";
        }
    }
}

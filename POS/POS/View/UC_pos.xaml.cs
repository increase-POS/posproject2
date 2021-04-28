﻿using POS.Classes;
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
    /// Interaction logic for UC_pos.xaml
    /// </summary>
    public partial class UC_pos : UserControl
    {
        public int PosId;

        Pos posModel = new Pos();

        Branch branchModel = new Branch();

        List<int>    branchIds = new List<int>();
        List<string> branchNames = new List<string>();

        int selectedBranchId = 0;

        DataGrid dt = new DataGrid(); 
        public UC_pos() 
         {
            InitializeComponent();
        }

        private async void fillBranches()
        {
            var branches = await branchModel.GetBranchesAsync("b");
            dt.ItemsSource = branches;
            Branch branch = new Branch();
            for (int i = 0; i < branches.Count; i++)
            {
                branch = dt.Items[i] as Branch;
                branchIds.Add(branch.branchId);
                branchNames.Add(branch.name);
            }
            //MessageBox.Show(branches.Count.ToString());
            //branchNames.Add("first"); branchNames.Add("second");
            cb_branchId.ItemsSource = branchNames;

        }

        private void DG_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
           // p_errorBalance.Visibility = Visibility.Collapsed;
            p_errorSelectBranch.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            //tb_balance.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tt_errorSelectBranch.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            Pos pos = new Pos();

            if (dg_pos.SelectedIndex != -1)
            {
                pos = dg_pos.SelectedItem as Pos;
                this.DataContext = pos;
            }
            if (pos != null)
            {
                if (pos.posId != 0)
                {
                    PosId = pos.posId;
                }
                if (pos.branchId != 0)
                {
                    for (int i = 0; i < branchIds.Count; i++)
                        if (branchIds[i] == pos.branchId)
                        { cb_branchId.SelectedIndex = i; break; }
                }

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
         //   MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectPosNameHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trPosNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trPosCodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branchId, MainWindow.resourcemanager.GetString("trSelectPosBranchHint"));

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            dg_pos.Columns[0].Header = MainWindow.resourcemanager.GetString("trPosName");
            dg_pos.Columns[1].Header = MainWindow.resourcemanager.GetString("trPosCode");
            dg_pos.Columns[2].Header = MainWindow.resourcemanager.GetString("trBranchName");
            dg_pos.Columns[3].Header = MainWindow.resourcemanager.GetString("trBalance");
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
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

            var poss = await posModel.GetPosAsync();
            dg_pos.ItemsSource = poss;

            //dg_pos.Columns["MyColumn"]
         
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            tb_name.Text = "";
            tb_code.Text = "";
            cb_branchId.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            Pos pos = new Pos
            {
                code         = tb_code.Text,
                name         = tb_name.Text,
                balance      = 0,
                //balance      = decimal.Parse(tb_balance.Text),
                //branchId     = 1 ,
                branchId = selectedBranchId,
                createDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 2,
                updateUserId = 2,
                isActive     = 1
            };

            await posModel.savePos(pos);

            var poss = await posModel.GetPosAsync();
            dg_pos.ItemsSource = poss;


        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            Pos pos = new Pos
            {
                posId        = PosId,
                code         = tb_code.Text,
                name         = tb_name.Text,
                balance      = 0,
                //balance      = decimal.Parse(tb_balance.Text),
                //branchId     = 1,
                branchId     = selectedBranchId,
                createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 2,
                updateUserId = 2,
                isActive     = 1
            };


            await posModel.savePos(pos);

            var poss = await posModel.GetPosAsync();
            dg_pos.ItemsSource = poss;


        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            await posModel.deletePos(PosId);

            var poss = await posModel.GetPosAsync();
            dg_pos.ItemsSource = poss;

            //clear textBoxs
            Btn_clear_Click(sender, e);
        }

        private void Cb_branchId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBranchId = branchIds[cb_branchId.SelectedIndex];
        }
    }
}

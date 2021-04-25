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
    /// Interaction logic for UC_bank.xaml
    /// </summary>
    public partial class UC_bank : UserControl
    {
        public int bankId;
        Bank bank = new Bank();
        public UC_bank()
        {
            InitializeComponent();
            List<Bank> banks = new List<Bank>();



            for (int i = 1; i < 50; i++)
            {
                banks.Add(new Bank()
                {
                    Id = i,
                    name = "branch name " + i,
                    address = "Test address" + i,
                    mobile = "Test mobile" + i,
                    phone = "Test phone" + i,
                    accNumber = "Test accNumber" + i
                }) ; ; ;
            }

            dg_bank.ItemsSource = banks;
        }

        private void DG_bank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bank bank = new Bank();
            if (dg_bank.SelectedIndex != -1)
            {
                bank = dg_bank.SelectedItem as Bank;
                this.DataContext = bank;
                if (bank != null)
                {
                    if (bank.Id != 0)
                    {
                        bankId = bank.Id;
                    }
                }
            }
        }
      

        private void translate()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectBankNameHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trBankNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_accNumber, MainWindow.resourcemanager.GetString("trAccNumberHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_area, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            txt_moreInformation.Text = MainWindow.resourcemanager.GetString("trAnotherInfomation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            dg_bank.Columns[0].Header = MainWindow.resourcemanager.GetString("trBankName");
            dg_bank.Columns[1].Header = MainWindow.resourcemanager.GetString("trAccNumber");
            dg_bank.Columns[3].Header = MainWindow.resourcemanager.GetString("trAddress");
            dg_bank.Columns[2].Header = MainWindow.resourcemanager.GetString("trMobile");

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucBank.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucBank.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
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

        private void Tb_accNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_accNumber.Text.Equals(""))
            {
                p_errorAccNum.Visibility = Visibility.Visible;
                tt_errorAccNum.Content = MainWindow.resourcemanager.GetString("trEmptyAccNumToolTip");
                tb_accNumber.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorAccNum.Visibility = Visibility.Collapsed;
                tb_accNumber.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }


        private void Tb_accNum_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_accNumber.Text.Equals(""))
            {
                p_errorAccNum.Visibility = Visibility.Visible;
                tt_errorAccNum.Content = MainWindow.resourcemanager.GetString("trEmptyAccNumToolTip");
                tb_accNumber.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorAccNum.Visibility = Visibility.Collapsed;
                tb_accNumber.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //private void translate()
        //{
        //    MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
        //    MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectPosNameHint"));
        //    txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
        //    MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trPosNameHint"));
        //    MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trPosCodeHint"));
        //    txt_moreInformation.Text = MainWindow.resourcemanager.GetString("trMoreInformation");
        //    MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branchId, MainWindow.resourcemanager.GetString("trSelectPosBranchHint"));

        //    MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_balance, MainWindow.resourcemanager.GetString("trBalanceHint"));
        //    btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
        //    btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
        //    btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
        //    dg_pos.Columns[0].Header = MainWindow.resourcemanager.GetString("trPosName");
        //    dg_pos.Columns[1].Header = MainWindow.resourcemanager.GetString("trPosCode");
        //    dg_pos.Columns[2].Header = MainWindow.resourcemanager.GetString("trBranchName");
        //    dg_pos.Columns[3].Header = MainWindow.resourcemanager.GetString("trBalance");
        //}

        //private void UserControl_Loaded(object sender, RoutedEventArgs e) { 
        //{
        //    if (MainWindow.lang.Equals("en"))
        //    {
        //        MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
        //        grid_ucBank.FlowDirection = FlowDirection.LeftToRight;
        //    }
        //    else
        //    {
        //        MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
        //        grid_ucBank.FlowDirection = FlowDirection.RightToLeft;
        //    }

        //    translate();
      //  }
}
}

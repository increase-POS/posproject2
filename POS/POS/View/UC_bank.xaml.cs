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
        Bank bankModel = new Bank();

        public int BankId;

        bool isClear = false;

        public UC_bank()
        {
            InitializeComponent();
        }



        private void translate()
        {
            txt_bank.Text = MainWindow.resourcemanager.GetString("trBank");
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
            dg_bank.Columns[2].Header = MainWindow.resourcemanager.GetString("trAddress");
            dg_bank.Columns[3].Header = MainWindow.resourcemanager.GetString("trMobile");

            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
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

            var banks = await bankModel.GetBanksAsync();
            dg_bank.ItemsSource = banks;
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


        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            isClear = true;

            tb_name.Text = "";
            tb_address.Text = "";
            tb_mobile.Text = "";
            tb_notes.Text = "";
            tb_phone.Text = "";
            tb_accNumber.Text = "";
            cb_area.Text = "";
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            Bank bank = new Bank
            {
                name         = tb_name.Text,
                phone        = tb_phone.Text,
                mobile       = cb_area.Text + tb_mobile.Text,
                address      = tb_address.Text,
                accNumber    = tb_accNumber.Text,
                notes        = tb_notes.Text,
                createDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 1,
                updateUserId = 1,
                isActive     = 1

            };

            await bankModel.saveBank(bank);

            var banks = await bankModel.GetBanksAsync();
            dg_bank.ItemsSource = banks;


        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            Bank bank = new Bank
            {
                bankId       = BankId ,
                name         = tb_name.Text,
                phone        = tb_phone.Text,
                mobile       = cb_area.Text + tb_mobile.Text,
                address      = tb_address.Text,
                accNumber    = tb_accNumber.Text,
                notes        = tb_notes.Text,
                createDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 1,
                updateUserId = 1,
                isActive     = 1

            };

            await bankModel.saveBank(bank);

            var banks = await bankModel.GetBanksAsync();
            dg_bank.ItemsSource = banks;

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            await bankModel.deleteBank(BankId);

            var banks = await bankModel.GetBanksAsync();
            dg_bank.ItemsSource = banks;

            //clear textBoxs
            Btn_clear_Click(sender, e);

        }

        private void Dg_bank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorAccNum.Visibility = Visibility.Collapsed;
        
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_accNumber.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            Bank bank = new Bank();
            if (dg_bank.SelectedIndex != -1)
            {
                bank = dg_bank.SelectedItem as Bank;
                this.DataContext = bank;
            }
            if (bank != null)
            {
                if (bank.bankId != 0)
                {
                    BankId = bank.bankId;
                }


                if ((bank.mobile != null) && (bank.mobile.ToArray().Length > 4))
                {
                    string area = new string(bank.mobile.Take(4).ToArray());
                    var mobile = bank.mobile.Substring(4, bank.mobile.Length - 4);

                    cb_area.Text = area;
                    tb_mobile.Text = mobile.ToString();
                }
                else
                {
                    cb_area.SelectedIndex = -1;
                    tb_mobile.Clear();
                }

            }

        }
    }
}

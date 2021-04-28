
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
    /// Interaction logic for UC_store.xaml
    /// </summary>
    public partial class UC_store : UserControl
    {
        public int StoreId;

        Branch storeModel = new Branch();

        public UC_store()
        {
            InitializeComponent();

        }

        private void DG_Store_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorCode.Visibility = Visibility.Collapsed;
            p_errorEmail.Visibility = Visibility.Collapsed;

            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_email.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            Branch store = new Branch();

            if (dg_store.SelectedIndex != -1)
            {
                store = dg_store.SelectedItem as Branch;
                this.DataContext = store;
            }

            if (store != null)
            {
                if (store.branchId != 0)
                {
                    StoreId = store.branchId;
                }

                if ((store.mobile != null) && (store.mobile.ToArray().Length > 4))
                {
                    string area = new string(store.mobile.Take(4).ToArray());
                    var mobile = store.mobile.Substring(4, store.mobile.Length - 4);

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

        private void Tb_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_code.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
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
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_code.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorCode.Visibility = Visibility.Collapsed;
                tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }


        private void translate()
        {
            txt_store.Text = MainWindow.resourcemanager.GetString("trStore");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectStoreHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trStoreNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trStoreCodeHint"));
            txt_contentInformatin.Text = MainWindow.resourcemanager.GetString("trMoreInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_address, MainWindow.resourcemanager.GetString("trAdressHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_area, MainWindow.resourcemanager.GetString("trAreaHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_mobile, MainWindow.resourcemanager.GetString("trMobileHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_phone, MainWindow.resourcemanager.GetString("trPhoneHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_email, MainWindow.resourcemanager.GetString("trEmailHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_details, MainWindow.resourcemanager.GetString("trDetailsHint"));
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            dg_store.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_store.Columns[1].Header = MainWindow.resourcemanager.GetString("trCode");
            dg_store.Columns[2].Header = MainWindow.resourcemanager.GetString("trAddress");
            dg_store.Columns[3].Header = MainWindow.resourcemanager.GetString("trDetails");

            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            tb_name.Text = "";
            tb_code.Text = "";
            tb_address.Text = "";
            tb_details.Text = "";
            tb_email.Text = "";
            tb_phone.Text = "";
            
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            Branch store = new Branch
            {
                code        = tb_code.Text,
                name         = tb_name.Text,
                details      = tb_details.Text,
                address      = tb_address.Text,
                email        = tb_email.Text,
                phone        = tb_phone.Text,
                mobile       = cb_area.Text + tb_mobile.Text,
                createDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 2,
                updateUserId = 2,
                notes        = "",
                type         = "s"
            };


            await storeModel.saveBranch(store);

            var branches = await storeModel.GetBranchesAsync("s");
            dg_store.ItemsSource = branches;


        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            Branch store = new Branch
            {
                branchId     = StoreId,
                code         = tb_code.Text,
                name         = tb_name.Text,
                details      = tb_details.Text,
                address      = tb_address.Text,
                email        = tb_email.Text,
                phone        = tb_phone.Text,
                mobile       = cb_area.Text + tb_mobile.Text,
                createDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 2,
                updateUserId = 2,
                notes        = "",
                type         = "s"
            };


            await storeModel.saveBranch(store);

            var stores = await storeModel.GetBranchesAsync("s");
            dg_store.ItemsSource = stores;


        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            await storeModel.deleteBranch(StoreId);

            var stores = await storeModel.GetBranchesAsync("s");
            dg_store.ItemsSource = stores;

            //clear textBoxs
            tb_code.Text = "";
            tb_name.Text = "";
            tb_details.Clear();
            tb_address.Clear();
            cb_area.SelectedIndex = -1;
            tb_email.Clear();
            tb_phone.Clear();
            tb_mobile.Clear();
            //tb_notes.Clear();

        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucStore.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucStore.FlowDirection = FlowDirection.RightToLeft; }

            translate();

            var stores = await storeModel.GetBranchesAsync("s");
            dg_store.ItemsSource = stores;
        }
    }
}

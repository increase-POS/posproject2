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
       

        public int BranchId;
        Branch store = new Branch();
        public UC_store()
             {
            InitializeComponent();


            List<Branch> stores = new List<Branch>();



            for (int i = 1; i < 50; i++)
            {
                stores.Add(new Branch()
                {
                    //Id = i,
                    //name = "store name " + i,
                    //address = "store address" + i,
                    //code = "store code" + i,

                    //mobile = "Test mobile" + i,
                    //phone = "Test phone" + i,
                    //email = "Test email" + i,
                    //details = "store details" + i,

                }); ; ;
            }





            dg_store.ItemsSource = stores;
        }

        private void DG_Store_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Branch store = new Branch();
            if (dg_store.SelectedIndex != -1)
            {
                store = dg_store.SelectedItem as Branch;
                this.DataContext = store;

                if (store != null)
                {

                    //if (store.Id != 0)
                    //{
                    //    BranchId = store.Id;
                    //}
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
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_ucStore.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_ucStore.FlowDirection = FlowDirection.RightToLeft; }

            translate();

        }
    }
}

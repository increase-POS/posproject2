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
using netoaster;
using POS.Classes;
namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_coupon.xaml
    /// </summary>
    public partial class uc_coupon : UserControl
    {

        Coupon coupon = new Coupon();
        Coupon couponModel = new Coupon();
        private static uc_coupon _instance;
        public static uc_coupon Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_coupon();
                return _instance;
            }
        }
        public uc_coupon()
        {
            InitializeComponent();
        }
        #region Numeric


        private int _numValue = 0;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                tb_discountValue.Text = value.ToString();
            }
        }



        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void tb_discountValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_discountValue == null)
            {
                return;
            }

            if (!int.TryParse(tb_discountValue.Text, out _numValue))
                tb_discountValue.Text = _numValue.ToString();
        }

        private void tb_discountValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        #endregion
        private void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void translate()
        {
            txt_couponHeader.Text = MainWindow.resourcemanager.GetString("trCoupon");
            txt_active.Text = MainWindow.resourcemanager.GetString("trActive");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));

            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trCodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_barcode, MainWindow.resourcemanager.GetString("trBarcode"));
            txt_isActive.Text = MainWindow.resourcemanager.GetString("trActive");
            txt_details.Text = MainWindow.resourcemanager.GetString("trDetails");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_typeDiscount, MainWindow.resourcemanager.GetString("trTypeDiscountHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discountValue, MainWindow.resourcemanager.GetString("trDiscountValueHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_startDate, MainWindow.resourcemanager.GetString("trStartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_endDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_MinInvoiceValue, MainWindow.resourcemanager.GetString("trMinimumInvoiceValueHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_MaxInvoiceValue, MainWindow.resourcemanager.GetString("trMaximumInvoiceValueHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_remainQuantity, MainWindow.resourcemanager.GetString("trRemainQuantityHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_quantity, MainWindow.resourcemanager.GetString("trQuantityHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");

            dg_coupon.Columns[0].Header = MainWindow.resourcemanager.GetString("trCode");
            dg_coupon.Columns[1].Header = MainWindow.resourcemanager.GetString("trName");
            dg_coupon.Columns[2].Header = MainWindow.resourcemanager.GetString("trValue");
            dg_coupon.Columns[3].Header = MainWindow.resourcemanager.GetString("trQuantity");
            dg_coupon.Columns[4].Header = MainWindow.resourcemanager.GetString("trRemainQuantity");

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
         

            var dislist = new[] {
    new { Text = "Value", Value = "1" },
    new { Text = "Rate", Value = "2" },
  
};
             cb_typeDiscount.DisplayMemberPath = "Text";
            cb_typeDiscount.SelectedValuePath = "Value";
            cb_typeDiscount.ItemsSource= dislist;
           
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucCoupon.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucCoupon.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            tb_discountValue.Text = _numValue.ToString();

            #region Style Date
            /////////////////////////////////////////////////////////////
            dp_startDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_startDate.Template.FindName("PART_TextBox", dp_startDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_startDate.Background;
                    textBox1.BorderThickness = dp_startDate.BorderThickness;
                }
            };
            /////////////////////////////////////////////////////////////
            dp_endDate.Loaded += delegate
            {

                var textBox1 = (TextBox)dp_endDate.Template.FindName("PART_TextBox", dp_endDate);
                if (textBox1 != null)
                {
                    textBox1.Background = dp_endDate.Background;
                    textBox1.BorderThickness = dp_endDate.BorderThickness;
                }
            };
            /////////////////////////////////////////////////////////////
            #endregion
        }

        #region Tab
        /*
        private void Btn_couponTab_Click(object sender, RoutedEventArgs e)
        {
            grid_couponOnItem.Visibility = Visibility.Collapsed;
            grid_coupon.Visibility = Visibility.Visible;
            brd_couponItemsTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_couponTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_couponItems_Click(object sender, RoutedEventArgs e)
        {
            grid_coupon.Visibility = Visibility.Collapsed;
            grid_couponOnItem.Visibility = Visibility.Visible;
            brd_couponTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_couponItemsTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

    */

        #endregion

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            bool codeNotExist = await SectionData.CouponCodeNotExist( tb_code.Text);

            //  MessageBox.Show(codeExist.ToString());


           
            //chk empty code
            SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty name
            SectionData.validateEmptyTextBox(tb_barcode, p_errorBarcode, tt_errorBarcode, "trEmptyBarcodeToolTip");

            //validate email


            /*
                        string phoneStr = "";
                        if (!tb_phone.Text.Equals("")) phoneStr = cb_areaPhone.Text + "-" + cb_areaPhoneLocal.Text + "-" + tb_phone.Text;

                        bool emailError = false;

                        if (!tb_email.Text.Equals(""))
                            if (!SectionData.IsValid(tb_email.Text))
                                emailError = true;

                        if ((!tb_name.Text.Equals("")) && (!tb_mobile.Text.Equals("")) && (!tb_code.Text.Equals("")) && (!cb_branch.Text.Equals("")))
                        {
                            if (emailError)
                                SectionData.validateEmail(tb_email, p_errorEmail, tt_errorEmail);
                            //duplicate
                            else if (iscodeExist)
                                SectionData.validateDuplicateCode(tb_code, p_errorCode, tt_errorCode);
                            else
                            {*/

            if (tb_code.Text != "") {
            }
            #region
            coupon.cId = 0;

            coupon.code = tb_code.Text;
            coupon.name = tb_name.Text;
            coupon.notes = tb_note.Text;
            coupon.barcode = tb_barcode.Text;
            coupon.isActive = Convert.ToByte(tgl_ActiveCoupon.IsChecked);
            coupon.discountType = cb_typeDiscount.SelectedValue.ToString();
            coupon.startDate = DateTime.Parse(dp_startDate.Text);
            coupon.endDate = DateTime.Parse(dp_endDate.Text);
            coupon.discountValue = decimal.Parse(tb_discountValue.Text);
            coupon.invMin = decimal.Parse(tb_MinInvoiceValue.Text);
            coupon.invMax = decimal.Parse(tb_MaxInvoiceValue.Text);
            coupon.quantity = Int32.Parse(tb_quantity.Text);
            coupon.notes = tb_note.Text;
            coupon.createUserId = MainWindow.userID; ;


            string s = await couponModel.Save(coupon);
            if (s.Equals("true")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null); 
            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
            else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            #endregion

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
           
        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

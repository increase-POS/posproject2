using POS.View.windows;
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
    /// Interaction logic for uc_offer.xaml
    /// </summary>
    public partial class uc_offer : UserControl
    {
        public uc_offer()
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
            txt_active.Text = MainWindow.resourcemanager.GetString("trActive");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            ///////////////////////////////////////------OFFER------///////////////////////////////
            txt_offerHeader.Text = MainWindow.resourcemanager.GetString("trOffer");
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trCodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            txt_isActive.Text = MainWindow.resourcemanager.GetString("trActive");
            txt_details.Text = MainWindow.resourcemanager.GetString("trDetails");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_typeDiscount, MainWindow.resourcemanager.GetString("trTypeDiscountHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discountValue, MainWindow.resourcemanager.GetString("trDiscountValueHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_startDate, MainWindow.resourcemanager.GetString("trStartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_endDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");

            dg_offer.Columns[0].Header = MainWindow.resourcemanager.GetString("trCode");
            dg_offer.Columns[1].Header = MainWindow.resourcemanager.GetString("trName");
            dg_offer.Columns[2].Header = MainWindow.resourcemanager.GetString("trValue");
            dg_offer.Columns[3].Header = MainWindow.resourcemanager.GetString("trStartDate");
            dg_offer.Columns[4].Header = MainWindow.resourcemanager.GetString("trEndDate");
            ///////////////////////////////////////------on Item------///////////////////////////////
            ///

            /*
            txt_onItemHeader.Text = MainWindow.resourcemanager.GetString("trOnItems");
            tb_items.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_onItemHeader.Text = MainWindow.resourcemanager.GetString("trOnItems");

            dg_items.Columns[0].Header = MainWindow.resourcemanager.GetString("trCode");
            dg_items.Columns[1].Header = MainWindow.resourcemanager.GetString("trName");
            dg_items.Columns[2].Header = MainWindow.resourcemanager.GetString("trValue");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_item, MainWindow.resourcemanager.GetString("trItem"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_barcode, MainWindow.resourcemanager.GetString("trBarcodeHint"));

            btn_addItem.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_deleteItem.Content = MainWindow.resourcemanager.GetString("trDelete");
            */
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucOffer.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucOffer.FlowDirection = FlowDirection.RightToLeft;
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
        private void Btn_offerTab_Click(object sender, RoutedEventArgs e)
        {
            grid_offerOnItem.Visibility = Visibility.Collapsed;
            grid_offer.Visibility = Visibility.Visible;
            brd_offerItemsTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_offerTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_offerItems_Click(object sender, RoutedEventArgs e)
        {
            grid_offer.Visibility = Visibility.Collapsed;
            grid_offerOnItem.Visibility = Visibility.Visible;
            brd_offerTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
            brd_offerItemsTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }


        */



        #endregion

        private void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            (((this.Parent as Grid).Parent as Grid).Parent as UserControl).Opacity = 0.2;
            //if ((((this.Parent as Grid).Parent as Grid).Parent as UserControl) != null)
            //((((this.Parent as Grid).Parent as Grid).Parent as Grid).Parent as UserControl).Opacity = 0.2;
            wd_itemsList w = new wd_itemsList();
            w.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00178DD2"));
            w.ShowDialog();
            if (w.isActive)
            {
                foreach (var item in w.selectedItems)
                {
                    MessageBox.Show(item.name + "\t");

                }
            }
           
            (((this.Parent as Grid).Parent as Grid).Parent as UserControl).Opacity =1;
        }
    }
}

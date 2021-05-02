using System;
using System.Collections.Generic;
using System.Linq;
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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






        #endregion

     
    }
}

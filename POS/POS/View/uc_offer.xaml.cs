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
            tb_workHour.Text = _numValue.ToString();
        }

        #region Numeric


        private int _numValue = 0;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                tb_workHour.Text = value.ToString();
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

        private void tb_workHour_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_workHour == null)
            {
                return;
            }

            if (!int.TryParse(tb_workHour.Text, out _numValue))
                tb_workHour.Text = _numValue.ToString();
        }

        private void tb_workHour_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        }

       
    }
}

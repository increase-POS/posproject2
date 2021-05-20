using POS.View.windows;
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
    /// Interaction logic for uc_section.xaml
    /// </summary>
    public partial class uc_section : UserControl
    {
        public uc_section()
        {
            InitializeComponent();
        }

        private void Btn_locations_Click(object sender, RoutedEventArgs e)
        {
            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            //if ((((this.Parent as Grid).Parent as Grid).Parent as UserControl) != null)
            //((((this.Parent as Grid).Parent as Grid).Parent as Grid).Parent as UserControl).Opacity = 0.2;
            wd_locationsList w = new wd_locationsList();
            //w.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00178DD2"));
            w.ShowDialog();
            if (w.isActive)
            {
                foreach (var location in w.selectedLocations)
                {
                    MessageBox.Show(location.name + "\t");

                }
            }

            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
        }

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

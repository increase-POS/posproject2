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

namespace POS.View.Settings
{
    /// <summary>
    /// Interaction logic for uc_reportSetting.xaml
    /// </summary>
    public partial class uc_reportSetting : UserControl
    {
        private static uc_reportSetting _instance;
        public static uc_reportSetting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_reportSetting();
                return _instance;
            }
        }
        public uc_reportSetting()
        {
            InitializeComponent();
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
             
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

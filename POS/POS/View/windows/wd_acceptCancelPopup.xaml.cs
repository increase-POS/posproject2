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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_acceptCancelPopup.xaml
    /// </summary>
    public partial class wd_acceptCancelPopup : Window
    {
         
        //public bool isOk { get; set; }
        public bool isOk;
        public wd_acceptCancelPopup()
        {
            InitializeComponent();
            this.DataContext = this;
            //"Do you really want to delete this Item ?"
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_wdAcceptCancelPopup.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_wdAcceptCancelPopup.FlowDirection = FlowDirection.RightToLeft;
            }
        }

        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            isOk = false;
            this.Close();
        }

        private void Btn_ok_Click(object sender, RoutedEventArgs e)
        {
            isOk = true;
            this.Close();
        }

        #region contentText
        public static readonly DependencyProperty contentTextDependencyProperty = DependencyProperty.Register("contentText",
            typeof(string),
            typeof(wd_acceptCancelPopup),
            new PropertyMetadata("DEFAULT"));
        public string contentText
        {
            set
            { SetValue(contentTextDependencyProperty, value); }
            get
            { return (string)GetValue(contentTextDependencyProperty); }
        }
        #endregion

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }
    }
}

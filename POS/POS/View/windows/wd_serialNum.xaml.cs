using POS.Classes;
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
    /// Interaction logic for wd_serialNum.xaml
    /// </summary>
    public partial class wd_serialNum : Window
    {
        public wd_serialNum()
        {
            InitializeComponent();
        }
        BrushConverter bc = new BrushConverter();
        public string serialNum { get; set; }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            serialNum = "";
            DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region translate

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_serialNum.FlowDirection = FlowDirection.LeftToRight;

            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_serialNum.FlowDirection = FlowDirection.RightToLeft;

            }

            translate();
            #endregion
        }

        private void translate()
        {




        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }

        private bool validate()
        {
            bool valid = true;
            SectionData.validateEmptyTextBox(tb_serialNum, p_errorSerialNum, tt_errorSerialNum, "trEmptySerialNumToolTip");
            if (tb_serialNum.Text.Equals(""))
                valid = false;
            return valid;
        }
        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            bool valid = validate();
            if (valid)
            {
                serialNum = tb_serialNum.Text;
                DialogResult = true;
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

     
     
       

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_skip_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

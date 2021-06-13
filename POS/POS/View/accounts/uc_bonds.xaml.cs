using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace POS.View.accounts
{
    /// <summary>
    /// Interaction logic for uc_bonds.xaml
    /// </summary>
    public partial class uc_bonds : UserControl
    {
        private static uc_bonds _instance;
        public static uc_bonds Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_bonds();
                return _instance;
            }
        }
        public uc_bonds()
        {
            InitializeComponent();
        }

        private void Dg_bonds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_pay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tgl_isRecieved_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_isRecieved_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
          
        }
        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
              
            }
            else if (name == "ComboBox")
            {
               
            }
        }


        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            this.Dispatcher.Invoke(() =>
            {
                //await Task.Run(FN_ExportToExcel);
                //var result = await SimLongRunningProcessAsync();
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });

        }
        
        void FN_ExportToExcel()
        {
          

        }
        private void PreventSpaces(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Btn_image_Click(object sender, RoutedEventArgs e)
        {//image
            //if (cashtrans != null || cashtrans.cashTransId != 0)
            //{
            //    //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;

            //    wd_uploadImage w = new wd_uploadImage();

            //    w.tableName = "cashTransfer";
            //    w.tableId = cashtrans.cashTransId;
            //    w.docNum = cashtrans.docNum;
            //    w.ShowDialog();
            //    // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity =1;
            //}
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

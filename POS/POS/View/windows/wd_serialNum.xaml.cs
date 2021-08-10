using netoaster;
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
        public List<string> serialList { get; set; }
        public int itemCount { get; set; }
        public bool valid { get; set; }

        private static int _serialCount = 0;
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {  
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
            fillSerialList();
            translate();
            #endregion
            if(serialList == null)
            serialList = new List<string>();
        }

        private void translate()
        {




        }
        private void fillSerialList()
        {
            _serialCount = 0;
            if (serialList != null)
            {
                for (int i = 0; i < serialList.Count; i++)
                {
                    _serialCount++;
                    lst_serials.Items.Add(serialList[i]);
                }
            }
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
               //Btn_save_Click(null, null);
            }
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (_serialCount <= itemCount)
            {
                if (lst_serials.Items.Count > 0)
                {
                    serialList = new List<string>();
                    for (int i = 0; i < lst_serials.Items.Count; i++)
                        serialList.Add(lst_serials.Items[i].ToString());

                    _serialCount = 0;
                    valid = true;
                    DialogResult = true;
                    this.Close();
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trShouldInputOneSerialNumberAtLeast"), animation: ToasterAnimation.FadeIn);


            }
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorSerialMoreItemCountToolTip"), animation: ToasterAnimation.FadeIn);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

     
     
       
    

        private void Btn_skip_Click(object sender, RoutedEventArgs e)
        {
            valid = true;
            //serialList.Clear();
            if (lst_serials.Items.Count > 0)
            {
                serialList = new List<string>();
                for (int i = 0; i < lst_serials.Items.Count; i++)
                    serialList.Add(lst_serials.Items[i].ToString());

                _serialCount = 0;
            }
            DialogResult = true;
            this.Close();
        }

        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_serialNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string s = tb_serialNum.Text;
                if (!s.Equals(""))
                {
                    int found = lst_serials.Items.IndexOf(s);
                    if (_serialCount == itemCount)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trWarningItemCountIs:") + " " + itemCount, animation: ToasterAnimation.FadeIn);
                    }
                    else if (found == -1)
                    {
                        lst_serials.Items.Add(tb_serialNum.Text);
                        _serialCount++;
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trWarningSerialExists") , animation: ToasterAnimation.FadeIn);

                }
                tb_serialNum.Clear();
            }
        }

        private void Btn_clearSerial_Click(object sender, RoutedEventArgs e)
        {
            _serialCount = 0;
            lst_serials.Items.Clear();
        }
    }
}

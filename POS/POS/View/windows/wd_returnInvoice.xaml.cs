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
    /// Interaction logic for wd_returnInvoice.xaml
    /// </summary>
    public partial class wd_returnInvoice : Window
    {
        public wd_returnInvoice()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_delivery);

              



                DialogResult = true;
                this.Close();
                if (sender != null)
                    SectionData.EndAwait(grid_delivery);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_delivery);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_delivery);

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                }

                translate();
                #endregion


                if (sender != null)
                    SectionData.EndAwait(grid_delivery);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_delivery);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void translate()
        {
            txt_title.Text = MainWindow.resourcemanager.GetString("trReturn");
            btn_save.Content = MainWindow.resourcemanager.GetString("trSelect");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_invoiceNum, MainWindow.resourcemanager.GetString("trInvoiceNumber"));
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            SectionData.InputJustNumber(ref textBox);
            e.Handled = e.Key == Key.Space;
        }
    }
}

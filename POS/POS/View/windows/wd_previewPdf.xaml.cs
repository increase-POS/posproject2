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
using System.Windows.Shapes;
using System.IO;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_previewPdf.xaml
    /// </summary>
    public partial class wd_previewPdf : Window
    {
        public wd_previewPdf()
        {
            InitializeComponent();
        }
        public string pdfPath;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            translate();
            wb_pdfWebViewer.Navigate(new Uri(pdfPath));

          
        }
        private void translate()
        {
            txt_title.Text = MainWindow.resourcemanager.GetString("trPreview");
            
        }
        
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
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                //Btn_save_Click(null, null);
            }
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
           
            DialogResult = true;
            this.Close();
        }

       
    }
}

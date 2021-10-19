using POS.Classes;
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

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_setupFirstPos.xaml
    /// </summary>
    public partial class wd_setupFirstPos : Window
    {
        public wd_setupFirstPos()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_mainWindow);



                if (sender != null)
                    SectionData.EndAwait(grid_mainWindow);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_mainWindow);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);

                if (e.Key == Key.Return)
                {
                    Btn_next_Click(btn_next, null);
                }
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_next_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for wd_userPath.xaml
    /// </summary>
    public partial class wd_userPath : Window
    {
        public wd_userPath()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }
        Classes.Object _object = new Classes.Object();
        IEnumerable<Classes.Object> objects;
        IEnumerable<Classes.Object> firstLevel;
        IEnumerable<Classes.Object> secondLevel;

        BrushConverter bc = new BrushConverter();
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region translate

                if (winLogIn.lang.Equals("en"))
                {
                    winLogIn.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    winLogIn.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }

                //translate();
                #endregion

                objects = await _object.GetAll();
                fillFirstLevel();

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
       
        private async void fillFirstLevel()
        {
            #region fill FirstLevel
            firstLevel = objects.Where(x => string.IsNullOrEmpty( x.parentObjectId.ToString()) && x.objectType == "basic" );
            cb_firstLevel.DisplayMemberPath = "name";
            cb_firstLevel.SelectedValuePath = "objectId";
            cb_firstLevel.ItemsSource = firstLevel;
            #endregion


        }
        private async void Cb_firstLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox combo = sender as ComboBox;
            #region fill secondLevel
            secondLevel = objects.Where(x =>   x.parentObjectId == (int) cb_firstLevel.SelectedValue);
            cb_secondLevel.DisplayMemberPath = "name";
            cb_secondLevel.SelectedValuePath = "objectId";
            cb_secondLevel.ItemsSource = secondLevel;
                #endregion
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void translate()
        {
            txt_title.Text = winLogIn.resourcemanager.GetString("trInstallationSettings");

        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    Btn_save_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        List<SettingCls> set = new List<SettingCls>();

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = true;
                this.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }
         
    }
}

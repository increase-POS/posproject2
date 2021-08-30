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
        List<Classes.Object> newlist = new List<Classes.Object>();
        List<Classes.Object> newlist2 = new List<Classes.Object>();
        BrushConverter bc = new BrushConverter();
        UserSetValues userSetValuesModel = new UserSetValues();
        UserSetValues firstUserSetValue , secondUserSetValue;
        SetValues setValuesModel = new SetValues();
        List<SetValues> pathLst = new List<SetValues>();
        int firstId = 0, secondId = 0;
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

                translate();
                #endregion

                objects = await _object.GetAll();
                cb_secondLevel.IsEnabled = false;

                fillFirstLevel();

               await  getUserPath();

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

        private async Task getUserPath()
        {
            #region get user path
            UserSetValues uSetValueModel = new UserSetValues();
            List<UserSetValues> lst = await uSetValueModel.GetAll();

            SetValues setValueModel = new SetValues();

            List<SetValues> setVLst = await setValueModel.GetBySetName("user_path");
            firstId  = setVLst[0].valId;
            secondId = setVLst[1].valId;
            //string firstPath = "" , secondPath = "";
            try
            {
                firstUserSetValue = lst.Where(u => u.valId == firstId && u.userId == MainWindow.userID).FirstOrDefault();
                secondUserSetValue = lst.Where(u => u.valId == secondId && u.userId == MainWindow.userID).FirstOrDefault();
                
                foreach(var o in newlist)
                {
                    if (o.name.Equals(SectionData.translate(firstUserSetValue.note) ))
                    {
                        cb_firstLevel.SelectedValue = o.objectId;
                        break;
                    }
                }
                foreach (var o in newlist2)
                {
                    if (o.name.Equals(SectionData.translate(secondUserSetValue.note)))
                    {
                        cb_secondLevel.SelectedValue = o.objectId;
                        break;
                    }
                }
                //cb_firstLevel.SelectedValue = cb_firstLevel.Items.IndexOf(firstUserSetValue.note);
            }
            catch { cb_firstLevel.SelectedIndex = -1; }
           
            //MessageBox.Show(firstUserSetValue.note+ "-"+ secondUserSetValue.note);
            #endregion

        }

        private  void fillFirstLevel()
        {
            #region fill FirstLevel
            firstLevel = objects.Where(x => string.IsNullOrEmpty(x.parentObjectId.ToString()) && x.objectType == "basic");
            newlist = new List<Classes.Object>();

            foreach (var row in firstLevel)
            {
                Classes.Object newrow = new Classes.Object();
                        newrow.objectId = row.objectId;
                newrow.name = SectionData.translate(row.name);
                newrow.parentObjectId = row.parentObjectId;
                newlist.Add(newrow);
            }
            //  firstLevel = objects.Where(x => string.IsNullOrEmpty( x.parentObjectId.ToString()) && x.objectType == "basic" );
            cb_firstLevel.DisplayMemberPath = "name";
            cb_firstLevel.SelectedValuePath = "objectId";
            // cb_firstLevel.ItemsSource = firstLevel;
            cb_firstLevel.ItemsSource = newlist.OrderBy(x => x.name);

            #endregion


        }
        private  void Cb_firstLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox combo = sender as ComboBox;
                secondLevel = objects.Where(x => x.parentObjectId == (int)cb_firstLevel.SelectedValue);

                if (secondLevel.Count() > 0)
                {
                    cb_secondLevel.IsEnabled = true;
                    
                    #region fill secondLevel

                    newlist2 = new List<Classes.Object>();
                    foreach (var row in secondLevel)
                    {
                        Classes.Object newrow = new Classes.Object();
                        newrow.objectId = row.objectId;
                        newrow.name = SectionData.translate(row.name);
                        newrow.parentObjectId = row.parentObjectId;
                        newlist2.Add(newrow);
                    }
                    //secondLevel = objects.Where(x => x.parentObjectId == (int)cb_firstLevel.SelectedValue);
                    cb_secondLevel.DisplayMemberPath = "name";
                    cb_secondLevel.SelectedValuePath = "objectId";
                    //cb_secondLevel.ItemsSource = secondLevel;
                    cb_secondLevel.ItemsSource = newlist2.OrderBy(x => x.name);

                    #endregion
                }
                else
                    cb_secondLevel.IsEnabled = false;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void translate()
        {
            txt_title.Text = winLogIn.resourcemanager.GetString("trUserPath");
            btn_save.Content = winLogIn.resourcemanager.GetString("trSave");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_firstLevel, MainWindow.resourcemanager.GetString("trFirstLevel"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_secondLevel, MainWindow.resourcemanager.GetString("trSecondLevel"));
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

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void validateEmpty(string name, object sender)
        {
            if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_firstLevel")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorFirstLevel, tt_errorFirstLevel, "trFirstPath");
                else if ((sender as ComboBox).Name == "cb_secondLevel")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorSecondLevel, tt_errorSecondLevel, "trSecondPath");
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

        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region validate
                SectionData.validateEmptyComboBox(cb_firstLevel , p_errorFirstLevel , tt_errorFirstLevel , "trFirstPath");
                SectionData.validateEmptyComboBox(cb_secondLevel, p_errorSecondLevel, tt_errorSecondLevel, "trSecondPath");
                #endregion
                #region save
                if ((!cb_firstLevel.Text.Equals("")) && (!cb_firstLevel.Text.Equals("")))
                {
                    string first = objects.Where(x => x.objectId == (int)cb_firstLevel.SelectedValue).FirstOrDefault().name.ToString();
                    string second = objects.Where(x => x.objectId == (int)cb_secondLevel.SelectedValue).FirstOrDefault().name.ToString();
               
                    //save first path
                    if(firstUserSetValue == null)
                        firstUserSetValue = new UserSetValues();

                    firstUserSetValue.userId = MainWindow.userID;
                    firstUserSetValue.valId = firstId;
                    firstUserSetValue.note = first;
                    firstUserSetValue.createUserId = MainWindow.userID;
                    firstUserSetValue.updateUserId = MainWindow.userID;
                    string res1 = await userSetValuesModel.Save(firstUserSetValue);

                    //save second path
                    if(secondUserSetValue == null)
                        secondUserSetValue = new UserSetValues();

                    secondUserSetValue.userId = MainWindow.userID;
                    secondUserSetValue.valId = secondId;
                    secondUserSetValue.note = second;
                    secondUserSetValue.createUserId = MainWindow.userID;
                    secondUserSetValue.updateUserId = MainWindow.userID;
                    string res2 = await userSetValuesModel.Save(secondUserSetValue);

                    if ((int.Parse(res1) > 0) && (int.Parse(res2) > 0))
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                        MainWindow.firstPath = first;
                        MainWindow.secondPath = second;
                       // MainWindow.first = res1;
//MainWindow.second = res2;
                        //MessageBox.Show(res1+"-"+res2);
                        await Task.Delay(1500);
                        this.Close();
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
                #endregion
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
            //MessageBox.Show($"First: {objects.Where(x => x.objectId == (int)cb_firstLevel.SelectedValue).FirstOrDefault().name}\n"
            //+ $"Second: {objects.Where(x => x.objectId == (int)cb_secondLevel.SelectedValue).FirstOrDefault().name}");

        }

    }
}

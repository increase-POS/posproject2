using netoaster;
using POS.Classes;
using POS.View.windows;
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
        // preint parameters

        SetValues setvalueModel = new SetValues();
        List<SetValues> replangList = new List<SetValues>();
        SetValues replangrow = new SetValues();

        public class Replang
        {
            public int langId { get; set; }
            public string lang { get; set; }
            public string trlang { get; set; }
            public Nullable<int> isDefault { get; set; }

        }
        List<Replang> langcomboList = new List<Replang>();
        async Task fillRepLang()
        {
            langcomboList = new List<Replang>();
            replangList = await setvalueModel.GetBySetName("report_lang");
            foreach (var reprow in replangList)
            {
                //  trEnglish resourcemanager.GetString("trMenu");
                //trArabic
                Replang comborow = new Replang();
                comborow.langId = reprow.valId;
                comborow.lang = reprow.value;
             
                if (reprow.value == "ar")
                {
                    comborow.trlang = MainWindow.resourcemanager.GetString("trArabic");
                }
                else if (reprow.value == "en")
                {
                    comborow.trlang = MainWindow.resourcemanager.GetString("trEnglish");
                }
                else
                {
                    comborow.trlang = "";
                }

                langcomboList.Add(comborow);
            }
            cb_reportlang.ItemsSource = langcomboList;
            cb_reportlang.DisplayMemberPath = "trlang";
            cb_reportlang.SelectedValuePath = "langId";
            replangrow = replangList.Where(r => r.isDefault == 1).FirstOrDefault();
            cb_reportlang.SelectedValue = replangrow.valId;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);


                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }

                //translate();
                #endregion
                ///naji code
                ///
        await  fillRepLang();


                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void Btn_systmSetting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                //{
                Window.GetWindow(this).Opacity = 0.2;
                wd_reportSystmSetting w = new wd_reportSystmSetting();
                w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_copyCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                //if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                //{
                Window.GetWindow(this).Opacity = 0.2;
                wd_reportCopyCountSetting w = new wd_reportCopyCountSetting();
                w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_printCount_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_printerSetting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                //if (MainWindow.groupObject.HasPermissionAction(companySettingsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                //{
                Window.GetWindow(this).Opacity = 0.2;
                wd_reportPrinterSetting w = new wd_reportPrinterSetting();
                w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Btn_saveReportlang_Click(object sender, RoutedEventArgs e)
        {
          //  string msg = "";
           int msg = 0;
            if (cb_reportlang.SelectedIndex != -1)
            {
                replangrow = replangList.Where(r => r.valId == (int)cb_reportlang.SelectedValue).FirstOrDefault();
                replangrow.isDefault = 1;
                msg = await setvalueModel.Save(replangrow);
                //  replangrow.valId=
                await MainWindow.GetReportlang();
                await fillRepLang();
                if (msg > 0)
                {
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                }
                else
                {
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                }
            }
        }

        
    }
}

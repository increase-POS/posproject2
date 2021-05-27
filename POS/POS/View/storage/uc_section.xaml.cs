using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_section.xaml
    /// </summary>
    public partial class uc_section : UserControl
    {

        private static uc_section _instance;
        public static uc_section Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_section();
                return _instance;
            }
        }
        public uc_section()
        {
            InitializeComponent();
        }
        
        
        Section sectionModel = new Section();
        Section section = new Section();
        IEnumerable<Section> sectionsQuery;
        IEnumerable<Section> sections;
        byte tgl_sectionState;
        string searchText = "";
        BrushConverter bc = new BrushConverter();
        Branch branchModel = new Branch();
        Branch branch = new Branch();
        private void translate()
        {
            
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucSection.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucSection.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            fillBranches();
            cb_branch.SelectedIndex = 0;
            Keyboard.Focus(tb_name);

            this.Dispatcher.Invoke(() =>
            {
                Tb_search_TextChanged(null, null);
            });

        }
    
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_name.Clear();
            tb_note.Clear();
            cb_branch.SelectedIndex = -1;
            cb_branch.SelectedIndex = -1;

            p_errorName.Visibility = Visibility.Collapsed;
            p_errorSelectBranch.Visibility = Visibility.Collapsed;

            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            cb_branch.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }

        bool validate(Section section = null)
        {

            //chk empty Name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty Branch
            SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
           
             
            if ((!tb_name.Text.Equals("")) && (!cb_branch.Text.Equals("")))
                return true;
            else return false;
        }
       
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            section.sectionId = 0;
            if (validate(section))
            {
                section.name = tb_name.Text;
                section.branchId = Convert.ToInt32(cb_branch.SelectedValue);
                section.note = tb_note.Text;
                section.createUserId = MainWindow.userID;
                section.updateUserId = MainWindow.userID;
                section.isActive = 1;

                string s = await sectionModel.saveSection(section);

                if (s.Equals("Section Is Added Successfully"))
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                await RefreshSectionsList();
                Tb_search_TextChanged(null, null);
            }
        }
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

            if (validate(section))
            {
                section.name = tb_name.Text;
                section.branchId = Convert.ToInt32(cb_branch.SelectedValue);
                section.note = tb_note.Text;
                section.updateUserId = MainWindow.userID;

                string s = await sectionModel.saveSection(section);

                if (s.Equals("Section Is Updated Successfully"))
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                await RefreshSectionsList();
                Tb_search_TextChanged(null, null);


            }
        }
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if (section.sectionId != 0)
            {
                if ((!section.canDelete) && (section.isActive == 0))
                    activate();
                else
                {
                    string popupContent = "";
                    if (section.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                    if ((!section.canDelete) && (section.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                    bool b = await sectionModel.Delete(section.sectionId, MainWindow.userID.Value, section.canDelete);

                    if (b) 
                        Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                    else 
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                }
                await RefreshSectionsList();
                Tb_search_TextChanged(null, null);
            }
            //clear textBoxs
            Btn_clear_Click(sender, e);
        }
        private async void activate()
        {//activate
            section.isActive = 1;

            string s = await sectionModel.saveSection(section);

            if (s.Equals("Section Is Updated Successfully"))  
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else  
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshSectionsList();
            Tb_search_TextChanged(null, null);
        }
        private async void Dg_section_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            p_errorSelectBranch.Visibility = Visibility.Collapsed;

            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            cb_branch.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_section.SelectedIndex != -1)
            {
                section = dg_section.SelectedItem as Section;
                this.DataContext = section;
            }

            if (section != null)
            {
                if (section.branchId != 0)
                {
                    //display branch by id
                    branch = await branchModel.getBranchById(section.branchId.Value);

                    cb_branch.SelectedValue = branch.branchId;
                }

                #region delete
                if (section.canDelete) btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");

                else
                {
                    if (section.isActive == 0) btn_delete.Content = MainWindow.resourcemanager.GetString("trActive");
                    else btn_delete.Content = MainWindow.resourcemanager.GetString("trInActive");
                }
                #endregion 
            }
        }
        private void validationCompobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((sender as ComboBox).Name == "cb_branch")
            SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
        }
        private void validationControl_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as Control).Name == "tb_name")
                //chk empty name
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            else if ((sender as Control).Name == "cb_branch")
                //chk empty mobile
                SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");

        }
        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Name == "tb_name")
                //chk empty x
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
         

        }
        void handleSpace_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private async void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {
            if (sections is null)
                await RefreshSectionsList();
            tgl_sectionState = 1;
            Tb_search_TextChanged(null, null);
        }
        private async void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sections is null)
                await RefreshSectionsList();
            tgl_sectionState = 0;
            Tb_search_TextChanged(null, null);
        }
        async Task<IEnumerable<Section>> RefreshSectionsList()
        {
            sections = await sectionModel.Get();
            return sections;
        }
        void RefreshSectionView()
        {
            dg_section.ItemsSource = sectionsQuery;
            txt_count.Text = sectionsQuery.Count().ToString();
            cb_branch.SelectedIndex = -1;
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search

            if (sections is null)
                await RefreshSectionsList();
            searchText = tb_search.Text;
            sectionsQuery = sections.Where(s => (s.name.Contains(searchText) 
            ) && s.isActive == tgl_sectionState);
            RefreshSectionView();
        }
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshSectionsList();
            Tb_search_TextChanged(null, null);
        }
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });
        }
        void FN_ExportToExcel()
        {

            var QueryExcel = sectionsQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                branchName = x.branchName,
                Notes = x.note
            });
            var DTForExcel = QueryExcel.ToDataTable();

          
            //DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            //DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trAccNum");
            //DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trNote");
            
            ExportToExcel.Export(DTForExcel);
        }

        private async void fillBranches()
        {
            var branches = await branchModel.GetBranchesAsync("b");
            //var branches = await branchModel.Get();
            cb_branch.ItemsSource = branches;
            cb_branch.SelectedValuePath = "branchId";
            cb_branch.DisplayMemberPath = "name";
        }
        private void Btn_locations_Click(object sender, RoutedEventArgs e)
        {
            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            //if ((((this.Parent as Grid).Parent as Grid).Parent as UserControl) != null)
            //((((this.Parent as Grid).Parent as Grid).Parent as Grid).Parent as UserControl).Opacity = 0.2;
            wd_locationsList w = new wd_locationsList();
            //w.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00178DD2"));
            w.ShowDialog();
            if (w.isActive)
            {
                foreach (var location in w.selectedLocations)
                {
                    MessageBox.Show(location.name + "\t");

                }
            }
            (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
        }

       
    }
}

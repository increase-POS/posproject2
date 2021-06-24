using netoaster;
using POS.Classes;
using POS.View.windows;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Group = POS.Classes.Group;
using Object = POS.Classes.Object;

namespace POS.View.Settings
{
    /// <summary>
    /// Interaction logic for uc_permissions.xaml
    /// </summary>
    public partial class uc_permissions : UserControl
    {

        private static uc_permissions _instance;
        public static uc_permissions Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_permissions();
                return _instance;
            }
        }
        static private object _Sender;
        Group groupModel = new Group();
        Group group = new Group();
        IEnumerable<Group> groupsQuery;
        IEnumerable<Group> groups;
        byte tgl_groupState;
        string searchGroupText = "";

        GroupObject GroupObject = new GroupObject();
        IEnumerable<GroupObject> groupObjectsQuery;
        IEnumerable<GroupObject> groupObjects;
        string searchText = "";

        Object objectModel = new Object();
        IEnumerable<Object> objects;

        BrushConverter bc = new BrushConverter();

       
        public uc_permissions()
        {
            InitializeComponent();
            if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1440)
            {
                txt_deleteGroupButton.Visibility = Visibility.Visible;
                txt_addGroupButton.Visibility = Visibility.Visible;
                txt_updateGroupButton.Visibility = Visibility.Visible;
                txt_addGroup_Icon.Visibility = Visibility.Visible;
                txt_updateGroup_Icon.Visibility = Visibility.Visible;
                txt_deleteGroup_Icon.Visibility = Visibility.Visible;
            }
            else if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1360)
            {
                txt_addGroup_Icon.Visibility = Visibility.Collapsed;
                txt_updateGroup_Icon.Visibility = Visibility.Collapsed;
                txt_deleteGroup_Icon.Visibility = Visibility.Collapsed;
                txt_deleteGroupButton.Visibility = Visibility.Visible;
                txt_addGroupButton.Visibility = Visibility.Visible;
                txt_updateGroupButton.Visibility = Visibility.Visible;

            }
            else
            {
                txt_deleteGroupButton.Visibility = Visibility.Collapsed;
                txt_addGroupButton.Visibility = Visibility.Collapsed;
                txt_updateGroupButton.Visibility = Visibility.Collapsed;
                txt_addGroup_Icon.Visibility = Visibility.Visible;
                txt_updateGroup_Icon.Visibility = Visibility.Visible;
                txt_deleteGroup_Icon.Visibility = Visibility.Visible;

            }


           
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucPermissions.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucPermissions.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

            Keyboard.Focus(tb_name);

            this.Dispatcher.Invoke(() =>
            {
                Tb_searchGroup_TextChanged(null, null);
            });
        }
        private void translate()
        {

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_searchGroup, MainWindow.resourcemanager.GetString("trSearchHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            btn_refreshGroup.ToolTip = MainWindow.resourcemanager.GetString("trRefresh");
            btn_refresh.ToolTip = MainWindow.resourcemanager.GetString("trRefresh");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");
            //txt_group.Text = MainWindow.resourcemanager.GetString("trGroup");
            //txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            //btn_addRange.Content = MainWindow.resourcemanager.GetString("trAddRange");
            txt_addGroupButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateGroupButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteGroupButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            tt_addGroup_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_updateGroup_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_deleteGroup_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

            dg_group.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_group.Columns[1].Header = MainWindow.resourcemanager.GetString("trNote");
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_name.Clear();
            tb_notes.Clear();

            p_errorName.Visibility = Visibility.Collapsed;

            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }
        bool validate(Group group = null)
        {
           
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "");

            if ((!tb_name.Text.Equals("")))
                return true;
            else return false;
        }
        private async void Btn_addGroup_Click(object sender, RoutedEventArgs e)
        {//add
            group.groupId = 0;
            if (validate(group))
            {
                group.name = tb_name.Text;
                group.notes = tb_notes.Text;
                group.createUserId = MainWindow.userID;
                group.updateUserId = MainWindow.userID;
                group.isActive = 1;
                string s = await groupModel.Save(group);
                if (!s.Equals("-1"))
                {
                    addObjects(int.Parse(s));
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);
                    group.groupId = int.Parse(s);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                
                await RefreshGroupList();
                Tb_searchGroup_TextChanged(null, null);
                await RefreshGroupObjectList();
                Tb_search_TextChanged(null, null);
            }
        }

        #region groupObjects
       
       async void addObjects(int groupId)
        {
            if (objects is null)
                await RefreshObjectList();
            foreach (var item in objects)
            {
                    GroupObject.id = 0;
                    GroupObject.groupId = groupId;
                    GroupObject.objectId = item.objectId;
                    GroupObject.showOb = false;
                    GroupObject.addOb = false;
                    GroupObject.updateOb = false;
                    GroupObject.deleteOb = false;
                    GroupObject.notes ="";
                    GroupObject.createUserId = MainWindow.userID;
                    GroupObject.updateUserId = MainWindow.userID;
                    GroupObject.isActive = 1;
                    string s = await GroupObject.Save(GroupObject);
                    //if (!s.Equals("-1"))
                    //{
                    //    addObjects(int.Parse(s));
                    //    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    //    Btn_clear_Click(null, null);
                    //}
                    //else
                    //    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
        }
        void RefreshGroupObjectsView()
        {
            dg_permissions.ItemsSource = groupObjectsQuery;
            txt_count.Text = groupObjectsQuery.Count().ToString();
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            if (groupObjects is null)
                await RefreshGroupObjectList();
            searchText = tb_searchGroup.Text;
            //groupObjectsQuery = groupObjects.Where(s => (s.name.Contains(searchText)));
            groupObjectsQuery = groupObjects.Where(s => s.groupId == group.groupId );
            RefreshGroupObjectsView();
        }
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshGroupObjectList();
            Tb_search_TextChanged(null, null);

        }
        async Task<IEnumerable<GroupObject>> RefreshGroupObjectList()
        {
            groupObjects = await GroupObject.GetAll();
            return groupObjects;
        }
       
        
        #endregion

        #region object
        async Task<IEnumerable<Object>> RefreshObjectList()
        {
            objects = await objectModel.GetAll();
            return objects;
        }
        #endregion

        private async void Btn_updateGroup_Click(object sender, RoutedEventArgs e)
        {//update

            if (validate(group))
            {
                group.name = tb_name.Text;
                group.notes = tb_notes.Text;
                group.updateUserId = MainWindow.userID;

                string s = await groupModel.Save(group);

                if (s.Equals("Group Is Updated Successfully"))
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                await RefreshGroupList();
                Tb_searchGroup_TextChanged(null, null);


            }
        }
        private async void Btn_deleteGroup_Click(object sender, RoutedEventArgs e)
        {//delete
            if (group.groupId != 0)
            {
                if ((!group.canDelete) && (group.isActive == 0))
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                        activate();
                }
                else
                {

                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    if (group.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                    if (!group.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                    {
                        string popupContent = "";
                        if (group.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                        if ((!group.canDelete) && (group.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                        bool b = await groupModel.Delete(group.groupId, MainWindow.userID.Value, group.canDelete);

                        if (b) //SectionData.popUpResponse("", popupContent);
                            Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                        else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }
                await RefreshGroupList();
                Tb_searchGroup_TextChanged(null, null);
            }
            //clear textBoxs
            Btn_clear_Click(sender, e);
        }
        private async void activate()
        {//activate
            group.isActive = 1;

            string s = await group.Save(group);

            if (!s.Equals("-1")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshGroupList();
            Tb_searchGroup_TextChanged(null, null);
        }
        private void Dg_group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;

            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_group.SelectedIndex != -1)
            {
                group = dg_group.SelectedItem as Group;
                this.DataContext = group;
            }

            if (group != null)
            {

                #region delete
                if (group.canDelete)
                {
                    txt_deleteGroupButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                    txt_deleteGroup_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    tt_deleteGroup_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                }

                else
                {
                    if (group.isActive == 0)
                    {
                        txt_deleteGroupButton.Text = MainWindow.resourcemanager.GetString("trActive");
                        txt_deleteGroup_Icon.Kind =
                         MaterialDesignThemes.Wpf.PackIconKind.Check;
                        tt_deleteGroup_Button.Content = MainWindow.resourcemanager.GetString("trActive");

                    }
                    else
                    {
                        txt_deleteGroupButton.Text = MainWindow.resourcemanager.GetString("trInActive");
                        txt_deleteGroup_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Cancel;
                        tt_deleteGroup_Button.Content = MainWindow.resourcemanager.GetString("trInActive");

                    }
                }
                #endregion 
            }
            Tb_search_TextChanged(null, null);
        }
        private void validationControl_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as Control).Name == "tb_x")
                //chk empty name
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
           
        }
        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Name == "tb_x")
                //chk empty x
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
           
        }
        void handleSpace_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private async void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {
            if (groups is null)
                await RefreshGroupList();
            tgl_groupState = 1;
            Tb_searchGroup_TextChanged(null, null);
        }
        private async void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (groups is null)
                await RefreshGroupList();
            tgl_groupState = 0;
            Tb_searchGroup_TextChanged(null, null);
        }
        async Task<IEnumerable<Group>> RefreshGroupList()
        {
            groups = await groupModel.GetAll();
            return groups;
        }
        void RefreshGroupView()
        {
            dg_group.ItemsSource = groupsQuery;

            //txt_count.Text = groupsQuery.Count().ToString();
        }
        private async void Tb_searchGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (groups is null)
                await RefreshGroupList();
            searchGroupText = tb_searchGroup.Text;
            groupsQuery = groups.Where(s => (s.name.Contains(searchGroupText)) && s.isActive == tgl_groupState);
            RefreshGroupView();
        }
        private void Btn_refreshGroup_Click(object sender, RoutedEventArgs e)
        {
            RefreshGroupList();
            Tb_searchGroup_TextChanged(null, null);
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

            var QueryExcel = groupsQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                Notes = x.notes
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);
        }
        private void Btn_addRange_Click(object sender, RoutedEventArgs e)
        {
            //Window.GetWindow(this).Opacity = 0.2;
            //wd_groupAddRange w = new wd_groupAddRange();
            //w.ShowDialog();
            //Window.GetWindow(this).Opacity = 1;
            //Btn_refresh_Click(null, null);
        }
        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            if (name == "TextBox")
            {
               
            }
            else if (name == "ComboBox")
            {
                

            }
        }
        private void Tb_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Sender = sender;
        }

        
       
 

         
        private void Btn_users_Click(object sender, RoutedEventArgs e)
        {
        }

        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            foreach (var item in groupObjectsQuery)
            {
                 s = await GroupObject.Save(item);
            }
            if (!s.Equals("-1"))
            {
                addObjects(int.Parse(s));
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                Btn_clear_Click(null, null);
            }
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

        }

        private void Btn_categories_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_item_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_properties_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_units_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_locations_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_section_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_receiptOfPurchaseInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_itemsStorage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_itemsExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_itemsDestroy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_inventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_statistic_Click(object sender, RoutedEventArgs e)
        {

        }
        public void fn_ColorIconRefreash(Path p)
        {
            path_catalog.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_storage.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_purchases.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_sales.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_accounting.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_reports.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_sectionData.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            path_settings.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            p.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ti_catalog.IsSelected)
                fn_ColorIconRefreash(path_catalog);
            else if (ti_storage.IsSelected)
                fn_ColorIconRefreash(path_storage);
            else if (ti_purchases.IsSelected)
                    fn_ColorIconRefreash(path_purchases);
            else if (ti_sales.IsSelected)
                     fn_ColorIconRefreash(path_sales);
            else if (ti_accounting.IsSelected)
                fn_ColorIconRefreash(path_accounting);
            else if (ti_reports.IsSelected)
                fn_ColorIconRefreash(path_reports);
            else if (ti_sectionData.IsSelected)
                fn_ColorIconRefreash(path_sectionData);
            else if (ti_settings.IsSelected)
                fn_ColorIconRefreash(path_settings);
        }
        
    }
}

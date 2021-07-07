﻿using netoaster;
using POS.Classes;
using POS.View.windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        private int isCHecked = 1;
        private int index;
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
        //int firstLevelId;
        //int secondLevelId;
        string _parentObjectName;
        GroupObject groupObject = new GroupObject();
        //ObservableCollection<GroupObject> groupObjectsQuery = new ObservableCollection<GroupObject>();
        //ObservableCollection<GroupObject> groupObjects = new ObservableCollection<GroupObject>();
        IEnumerable<GroupObject> groupObjectsQuery;
        IEnumerable<GroupObject> groupObjects;
        List<GroupObject> groupObjectsList;
        string searchText = "";

        Object objectModel = new Object();
        IEnumerable<Object> objects;

        BrushConverter bc = new BrushConverter();


        public uc_permissions()
        {
            InitializeComponent();
            index = isCHecked;
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
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
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
            #region
            //new { Text = MainWindow.resourcemanager.GetString("trPercentageDiscount"), Value = "2" },

            //var levelsList = new[] {
            //new { Text = "المستوى الاول", Value = "1" },
            //new { Text = "المستوى الثاني", Value = "2" },
            //new { Text = "المستوى الثالث", Value = "3" },
            // };
            //cb_level.DisplayMemberPath = "Text";
            //cb_level.SelectedValuePath = "Value";
            //cb_level.ItemsSource = levelsList;
            #endregion
            translate();

            Keyboard.Focus(tb_name);

            this.Dispatcher.Invoke(() =>
            {
                Tb_searchGroup_TextChanged(null, null);
            });

            #region datagridChange
            //CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_permissions.Items);
            //((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
            #endregion
            await RefreshGroupObjectList();
            //dg_permissions.ItemsSource = groupObjectsQuery;
            //dg_permissions.ItemsSource = null;


            //var levelsList = new[] {
            //new { Text = "المستوى الاول", Value = "1" },
            //new { Text = "المستوى الثاني", Value = "2" },
            //new { Text = "المستوى الثالث", Value = "3" },
            // };

            //DataContext = levelsList;
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
                    //Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    //Btn_clear_Click(null, null);
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
            //groupObjectsList = new GroupObject[] { }; 
            groupObjectsList = new List<GroupObject>() ;
            foreach (var item in objects)
            {
                groupObject = new GroupObject();
                //groupObject.id = 0;
                groupObject.groupId = groupId;
                groupObject.objectId = item.objectId;
                if (item.objectType == "add")
                {
                    groupObject.showOb = 0;
                    groupObject.addOb = 2;
                    groupObject.updateOb = 2;
                    groupObject.deleteOb = 2;
                    groupObject.reportOb = 2;

                }
                else
                {
                    groupObject.showOb = 0;
                    groupObject.addOb = 0;
                    groupObject.updateOb = 0;
                    groupObject.deleteOb = 0;
                    groupObject.reportOb = 0;
                }


                groupObject.levelOb = 0;
                groupObject.notes = "";
                groupObject.createUserId = MainWindow.userID;
                groupObject.updateUserId = MainWindow.userID;
                groupObject.isActive = 1;
                groupObjectsList.Add(groupObject);
                //string s = await groupObject.AddGroupObjectList(groupObjectsList);

            }
            string s="";
            for (int i = 0; i <= (groupObjectsList.Count / 15); i++)
            {
                //GetRange (int index, int count);
                if (i < (groupObjectsList.Count / 15))
                {
                    List<GroupObject> list = groupObjectsList.GetRange(i * 15, 15).ToList();
                    s = await groupObject.AddGroupObjectList(list);
                }
                else
                {
                    List<GroupObject> list = groupObjectsList.Skip(i * 15).ToList();
                    s = await groupObject.AddGroupObjectList(list);
                }
                
            }

            if (s.Equals("true"))
            {
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                Btn_clear_Click(null, null);
            }
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

        }


        void RefreshGroupObjectsView()
        {
            dg_permissions.ItemsSource = groupObjectsQuery;
            //txt_count.Text = groupObjectsQuery.Count().ToString();
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            if (groupObjects is null)
                await RefreshGroupObjectList();
            searchText = tb_searchGroup.Text;
            //groupObjectsQuery = groupObjects.Where(s => (s.name.Contains(searchText)));
            groupObjectsQuery = groupObjects.Where(s => s.groupId == group.groupId 
            && s.objectType != "basic" && s.parentObjectName == _parentObjectName);
            //groupObjectsQuery = groupObjects.Where(s => s.groupId == group.groupId && s.parentObjectId == _parentObjectId);

            //if (objects!= null)
            //if(groupObjectsQuery.Where(s =>  s.objectType != "basic").Count() != objects.Count())
            //{
            //    await RefreshGroupObjectList();
            //    Tb_search_TextChanged(null, null);
            //    return;
            //}
            RefreshGroupObjectsView();
        }
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshGroupObjectList();
            Tb_search_TextChanged(null, null);

        }
        async Task<IEnumerable<GroupObject>> RefreshGroupObjectList()
        {
            MainWindow.mainWindow.StartAwait();
            groupObjects = await groupObject.GetAll();
            MainWindow.mainWindow.EndAwait();
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
            MainWindow.mainWindow.StartAwait();
            groups = await groupModel.GetAll();
            MainWindow.mainWindow.EndAwait();
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
        private async void Btn_refreshGroup_Click(object sender, RoutedEventArgs e)
        {
            await RefreshGroupList();
            Tb_searchGroup_TextChanged(null, null);

            await RefreshGroupObjectList();
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
            //users
            //group
            if (group.groupId >0)
            {

            //SectionData.clearValidate(tb_name, p_errorName);
            //location = await locationModel.getLocsBySectionId(section.sectionId);
            Window.GetWindow(this).Opacity = 0.2;
            wd_usersList w = new wd_usersList();
            //Pre users
            //w.selectedUsers = await locationModel.getLocsBySectionId(section.sectionId);
            //w.sectionId = section.sectionId;
            w.ShowDialog();
            if (w.isActive)
            {
                //await locationModel.saveUsersSection(w.selectedUsers, section.sectionId, MainWindow.userLogin.userId);
                foreach (var user in w.selectedUsers)
                {
                    MessageBox.Show(user.name + "\t");
                }
            }
            Window.GetWindow(this).Opacity = 1;
            }

        }

        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            foreach (var item in groupObjectsQuery)
            {
                s = await groupObject.Save(item);
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

        private void btn_secondLevelClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            paintSecondLevel();
            //path_suppliers.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            foreach (Path path in FindControls.FindVisualChildren<Path>(this))
            {
                // do something with tb here
                if (path.Name == "path_" + button.Tag)
                {
                    //MessageBox.Show("Hey i'm in " + "path_" + button.Tag);
                    path.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
                    break;
                }
            }
            //txt_suppliers.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            foreach (TextBlock textBlock in FindControls.FindVisualChildren<TextBlock>(this))
            {
                if (textBlock.Name == "txt_" + button.Tag)
                {
                    textBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
                    break;
                }
            }

            _parentObjectName = button.Tag.ToString();
            Tb_search_TextChanged(null, null);
        }

        /*
        private void Btn_categories_Click(object sender, RoutedEventArgs e)
        {
            paintCatalog();
            path_categories.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_categories.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_item_Click(object sender, RoutedEventArgs e)
        {
            paintCatalog();
            path_item.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_item.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_properties_Click(object sender, RoutedEventArgs e)
        {
            paintCatalog();
            path_properties.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_properties.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_units_Click(object sender, RoutedEventArgs e)
        {
            paintCatalog();
            path_units.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_units.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_locations_Click(object sender, RoutedEventArgs e)
        {
            paintStore();
            path_locations.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_locations.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_section_Click(object sender, RoutedEventArgs e)
        {
            paintStore();
            path_section.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_section.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_receiptOfPurchaseInvoice_Click(object sender, RoutedEventArgs e)
        {
            paintStore();
            path_recipthOfInvoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_reciptOfInvoice.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_itemsStorage_Click(object sender, RoutedEventArgs e)
        {
            paintStore();
            path_itemsStorage.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_itemsStorage.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_itemsExport_Click(object sender, RoutedEventArgs e)
        {
            paintStore();
            path_itemsExport.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_itemsExport.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_itemsDestroy_Click(object sender, RoutedEventArgs e)
        {
            paintStore();
            path_itemsDestroy.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_itemsDestroy.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_inventory_Click(object sender, RoutedEventArgs e)
        {
            paintStore();
            path_inventory.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_inventory.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_statistic_Click(object sender, RoutedEventArgs e)
        {
            paintStore();
            path_statistic.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_statistic.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_payInvoice_Click(object sender, RoutedEventArgs e)
        {
            paintPurchase();
            path_payInvoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_payInvoice.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_purchase_statistic_Click(object sender, RoutedEventArgs e)
        {
            paintPurchase();
            path_purchase_statistic.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_purchase_statistic.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void Btn_receiptInvoice_Click(object sender, RoutedEventArgs e)
        {
            paintSale();
            path_reciptInvoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_reciptInvoice.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_coupon_Click(object sender, RoutedEventArgs e)
        {
            paintSale();
            path_coupon.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_coupon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_offer_Click(object sender, RoutedEventArgs e)
        {
            paintSale();
            path_offer.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_offer.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_package_Click(object sender, RoutedEventArgs e)
        {
            paintSale();
            path_package.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_package.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_quotations_Click(object sender, RoutedEventArgs e)
        {
            paintSale();
            path_quotation.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_quotation.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_medals_Click(object sender, RoutedEventArgs e)
        {
            paintSale();
            path_medals.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_medals.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_sale_statistic_Click(object sender, RoutedEventArgs e)
        {
            paintSale();
            path_sale_statistic.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_sale_statistic.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_pos_Click(object sender, RoutedEventArgs e)
        {
            paintAccounts();
            path_pos.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_pos.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_payments_Click(object sender, RoutedEventArgs e)
        {
            paintAccounts();
            path_payments.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_payments.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_received_Click(object sender, RoutedEventArgs e)
        {
            paintAccounts();
            path_recived.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_recived.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_bonds_Click(object sender, RoutedEventArgs e)
        {
            paintAccounts();
            path_bonds.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_bonds.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_banks_Click(object sender, RoutedEventArgs e)
        {
            paintAccounts();
            path_banks.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_banks.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_accounts_statistic_Click(object sender, RoutedEventArgs e)
        {
            paintAccounts();
            path_accounts_statistic.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_accounts_statistic.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }
        
        private void btn_suppliers_Click(object sender, RoutedEventArgs e)
        {
            paintSectionData();
            path_suppliers.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_suppliers.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            //_parentObjectId = int.Parse(btn_suppliers.Tag.ToString());
            Tb_search_TextChanged(null, null);
        }

        private void btn_customers_Click(object sender, RoutedEventArgs e)
        {
            paintSectionData();
            path_customers.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_customers.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            //_parentObjectId = int.Parse(btn_customers.Tag.ToString());
            Tb_search_TextChanged(null, null);
        }

        private void btn_sd_users_Click(object sender, RoutedEventArgs e)
        {
            paintSectionData();
            path_sd_users.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_sd_users.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            //_parentObjectId = int.Parse(btn_sd_users.Tag.ToString());
            Tb_search_TextChanged(null, null);
        }

        private void btn_branches_Click(object sender, RoutedEventArgs e)
        {
            paintSectionData();
            path_branches.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_branches.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            // _parentObjectId = int.Parse(btn_branches.Tag.ToString());
            Tb_search_TextChanged(null, null);
        }

        private void btn_stores_Click(object sender, RoutedEventArgs e)
        {
            paintSectionData();
            path_stores.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_stores.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            //_parentObjectId = int.Parse(btn_stores.Tag.ToString());
            Tb_search_TextChanged(null, null);
        }

        private void btn_sd_pos_Click(object sender, RoutedEventArgs e)
        {
            paintSectionData();
            path_sd_pos.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_sd_pos.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            //_parentObjectId = int.Parse(btn_sd_pos.Tag.ToString());
            Tb_search_TextChanged(null, null);
        }

        private void btn_sd_banks_Click(object sender, RoutedEventArgs e)
        {
            paintSectionData();
            path_sd_banks.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_sd_banks.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            //_parentObjectId = int.Parse(btn_sd_banks.Tag.ToString());
            Tb_search_TextChanged(null, null);
        }

        private void btn_cards_Click(object sender, RoutedEventArgs e)
        {
            paintSectionData();
            path_cards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_cards.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            //_parentObjectId = int.Parse(btn_cards.Tag.ToString());
            Tb_search_TextChanged(null, null);
        }

        private void btn_shippingCompany_Click(object sender, RoutedEventArgs e)
        {
            paintSectionData();
            path_shippingCompany.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_shippingCompany.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            //_parentObjectId = int.Parse(btn_shippingCompany.Tag.ToString());
            Tb_search_TextChanged(null, null);
        }
        */

        public void paintSecondLevel()
        {
            paintCatalog();
            paintStore();
            paintPurchase();
            paintSale();
            paintAccounts();
            paintSectionData();
            paintSettings();
        }
        public void paintCatalog()
        {
            path_categories.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_item.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_properties.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_units.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));

            txt_categories.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_item.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_properties.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_units.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
        }
        public void paintStore()
        {
            path_locations.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_section.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_recipthOfInvoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_itemsStorage.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_itemsExport.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_itemsDestroy.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_inventory.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_statistic.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));

            txt_locations.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_section.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_reciptOfInvoice.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_itemsStorage.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_itemsExport.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_itemsDestroy.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_inventory.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_statistic.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
        }
        public void paintPurchase()
        {
            path_payInvoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_purchase_statistic.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));

            txt_payInvoice.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_purchase_statistic.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
        }
        public void paintSale()
        {
            path_reciptInvoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_coupon.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_offer.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_package.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_quotation.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_medals.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_sale_statistic.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_membership.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));

            txt_reciptInvoice.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_coupon.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_offer.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_package.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_quotation.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_medals.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_sale_statistic.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_membership.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
        }
        public void paintAccounts()
        {
            path_pos.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_payments.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_recived.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_bonds.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_banks.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_accounts_statistic.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));

            txt_pos.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_payments.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_recived.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_bonds.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_banks.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_accounts_statistic.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
        }
        public void paintSectionData()
        {
            path_suppliers.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_customers.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_sd_users.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_branches.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_stores.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_sd_pos.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_sd_banks.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_cards.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_shippingCompany.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
         

            txt_suppliers.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_customers.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_sd_users.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_branches.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_stores.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_sd_pos.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_sd_banks.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_cards.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_shippingCompany.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
        }
        public void paintSettings()
        {
            path_permissions.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_settings_reports.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            path_general.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));

            txt_permissions.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_settings_reports.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
            txt_general.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#67686d"));
        }



        private void translate()
        {

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_searchGroup, MainWindow.resourcemanager.GetString("trSearchHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            btn_refreshGroup.ToolTip = MainWindow.resourcemanager.GetString("trRefresh");
            //btn_refresh.ToolTip = MainWindow.resourcemanager.GetString("trRefresh");
            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            txt_addGroupButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateGroupButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteGroupButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            tt_addGroup_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_updateGroup_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_deleteGroup_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            //tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

            dg_group.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_group.Columns[1].Header = MainWindow.resourcemanager.GetString("trNote");


            txt_categories.Text = MainWindow.resourcemanager.GetString("trCategories");
            txt_properties.Text = MainWindow.resourcemanager.GetString("trProperties");
            txt_item.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_units.Text = MainWindow.resourcemanager.GetString("trUnits");

            txt_pos.Text = MainWindow.resourcemanager.GetString("trPOS");
            txt_banks.Text = MainWindow.resourcemanager.GetString("trBanks");
            txt_payments.Text = MainWindow.resourcemanager.GetString("trPayments");
            txt_recived.Text = MainWindow.resourcemanager.GetString("trReceived");
            txt_bonds.Text = MainWindow.resourcemanager.GetString("trBonds");

            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trInvoice");
            txt_statistic.Text = MainWindow.resourcemanager.GetString("trStatistic");

            txt_reciptInvoice.Text = MainWindow.resourcemanager.GetString("trInvoice");
            txt_sale_statistic.Text = MainWindow.resourcemanager.GetString("trStatistic");
            txt_coupon.Text = MainWindow.resourcemanager.GetString("trCoupon");
            txt_offer.Text = MainWindow.resourcemanager.GetString("trOffer");

            txt_customers.Text = MainWindow.resourcemanager.GetString("trCustomers");
            txt_suppliers.Text = MainWindow.resourcemanager.GetString("trSuppliers");
            txt_sd_users.Text = MainWindow.resourcemanager.GetString("trUsers");
            txt_branches.Text = MainWindow.resourcemanager.GetString("trBranches");
            txt_stores.Text = MainWindow.resourcemanager.GetString("trStores");
            txt_sd_pos.Text = MainWindow.resourcemanager.GetString("trPOS");
            txt_sd_banks.Text = MainWindow.resourcemanager.GetString("trBanks");

        }
        private void isEnabledButtons()
        {
            btn_home.IsEnabled = true;
            btn_catalog.IsEnabled = true;
            btn_store.IsEnabled = true;
            btn_sale.IsEnabled = true;
            btn_purchase.IsEnabled = true;
            btn_data.IsEnabled = true;
            btn_charts.IsEnabled = true;
            btn_settings.IsEnabled = true;
            btn_account.IsEnabled = true;
        }
        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            paint();
            bdr_home.Background = Brushes.White;
            path_home.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_bank.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_home.IsEnabled = false;
            btn_home.Opacity = 1;
        }



        private void btn_catalog_Click(object sender, RoutedEventArgs e)
        {

            paint();
            bdr_catalog.Background = Brushes.White;
            path_catalog.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_catalog.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_catalog.IsEnabled = false;
            btn_catalog.Opacity = 1;
    
        }

        private void btn_store_Click(object sender, RoutedEventArgs e)
        {
       
            paint();
            bdr_store.Background = Brushes.White;
            path_storage.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_store.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_store.IsEnabled = false;
            btn_store.Opacity = 1;
        }

        private void btn_sale_Click(object sender, RoutedEventArgs e)
        {

            paint();
            bdr_sale.Background = Brushes.White;
            path_sales.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_sales.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_sale.IsEnabled = false;
            btn_sale.Opacity = 1;
        }

        private void btn_purchase_Click(object sender, RoutedEventArgs e)
        {
            paint();
            bdr_purchase.Background = Brushes.White;
            path_purchases.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_purchase.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_purchase.IsEnabled = false;
            btn_purchase.Opacity = 1;
        }

        private void btn_account_Click(object sender, RoutedEventArgs e)
        {
            paint();
            bdr_accounts.Background = Brushes.White;
            path_accounting.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_account.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_account.IsEnabled = false;
            btn_account.Opacity = 1;
        }

        private void btn_charts_Click(object sender, RoutedEventArgs e)
        {
            paint();
            bdr_charts.Background = Brushes.White;
            path_reports.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_charts.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_charts.IsEnabled = false;
            btn_charts.Opacity = 1;
        }

        private void btn_data_Click(object sender, RoutedEventArgs e)
        {
            paint();
            bdr_data.Background = Brushes.White;
            path_sectionData.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_data.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_data.IsEnabled = false;
            btn_data.Opacity = 1;
        }

        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {
            paint();
            bdr_settings.Background = Brushes.White;
            path_settings.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            grid_settings.Visibility = Visibility.Visible;
            isEnabledButtons();
            btn_settings.IsEnabled = false;
            btn_settings.Opacity = 1;
        }
        public void paint()
        {
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            bdr_accounts.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_catalog.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_charts.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_data.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_home.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_purchase.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_sale.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_settings.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_store.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));

            path_home.Fill = Brushes.White;
            path_catalog.Fill = Brushes.White;
            path_storage.Fill = Brushes.White;
            path_purchases.Fill = Brushes.White;
            path_sales.Fill = Brushes.White;
            path_accounting.Fill = Brushes.White;
            path_reports.Fill = Brushes.White;
            path_sectionData.Fill = Brushes.White;
            path_settings.Fill = Brushes.White;

            grid_bank.Visibility = Visibility.Hidden;
            grid_catalog.Visibility = Visibility.Hidden;
            grid_store.Visibility = Visibility.Hidden;
            grid_purchase.Visibility = Visibility.Hidden;
            grid_sales.Visibility = Visibility.Hidden;
            grid_charts.Visibility = Visibility.Hidden;
            grid_data.Visibility = Visibility.Hidden;
            grid_settings.Visibility = Visibility.Hidden;
            grid_account.Visibility = Visibility.Hidden;
        }

        private void btn_general_Click(object sender, RoutedEventArgs e)
        {
            paintSettings();
            path_general.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_general.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_reports_Click(object sender, RoutedEventArgs e)
        {
            paintSettings();
            path_settings_reports.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_settings_reports.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

        private void btn_permission_Click(object sender, RoutedEventArgs e)
        {
            paintSettings();
            path_permissions.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_permissions.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }

      

        private void btn_membership_Click(object sender, RoutedEventArgs e)
        {
            paintSectionData();
            path_membership.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
            txt_membership.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
        }


        //private void Cbm_levelGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var cmb = sender as ComboBox;
        //    if (dg_permissions.SelectedIndex != -1)
        //    {

        //        byte level = byte.Parse(cmb.SelectedValue.ToString());

        //        if (dg_permissions.SelectedIndex != -1)
        //        {
        //            groupObject = dg_permissions.SelectedItem as GroupObject;
        //            groupObject.levelOb = level;
        //        }


        //        //refrishBillDetails();
        //    }
        //}
        //void refrishBillDetails()
        //{
        //    dg_permissions.ItemsSource = null;
        //        dg_permissions.ItemsSource = groupObjectsQuery;
        //}

        //private void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    //billDetails
        //    int count = 0;
        //    foreach (var item in groupObjectsQuery)
        //    {
        //        if (dg_permissions.Items.Count != 0)
        //        {
        //            if (dg_permissions.Items.Count > 1)
        //            {
        //                var cell = DataGridHelper.GetCell(dg_permissions, count, 6);
        //                if (cell != null)
        //                {
        //                    var cp = (ContentPresenter)cell.Content;
        //                    var combo = (ComboBox)cp.ContentTemplate.FindName("cbm_levelGroup", cp);
        //                    combo.SelectedValue = (int)item.levelOb;
        //                    count++;
        //                }
        //            }

        //        }
        //    }
        //    //int Repait = 0;
        //    //if (Repait==0)
        //    //{
        //    //    DataGrid_CollectionChanged(sender, e);
        //    //}
        //    //Repait++;
        //}

       
    }
}

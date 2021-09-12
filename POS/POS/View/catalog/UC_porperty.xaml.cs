using POS.Classes;
using netoaster;
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
using POS.View.windows;
using System.Threading;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.IO;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_porperty.xaml
    /// </summary>
    public partial class UC_porperty : UserControl
    {
        public int PropertyId;
        public int propertyItemId;
        Property property = new Property();
        PropertiesItems propertyItem = new PropertiesItems();
        Property propertyModel = new Property();
        PropertiesItems propertiesItemsModel = new PropertiesItems();
        IEnumerable<Property> propertiesQuery;
        IEnumerable<Property> properties;
        byte tgl_PropertyState;
        string searchText = "";

        string basicsPermission = "properties_basics";
        private static UC_porperty _instance;
        public static UC_porperty Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_porperty();
                return _instance;
            }
        }
        public UC_porperty()
        {
            try
            {
                InitializeComponent();
                if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1440)
                {
                    txt_deleteButton.Visibility = Visibility.Visible;
                    txt_addButton.Visibility = Visibility.Visible;
                    txt_updateButton.Visibility = Visibility.Visible;
                    txt_add_Icon.Visibility = Visibility.Visible;
                    txt_update_Icon.Visibility = Visibility.Visible;
                    txt_delete_Icon.Visibility = Visibility.Visible;

                    txt_deleteValueButton.Visibility = Visibility.Visible;
                    txt_addValueButton.Visibility = Visibility.Visible;
                    txt_updateValueButton.Visibility = Visibility.Visible;
                    txt_addValue_Icon.Visibility = Visibility.Visible;
                    txt_updateValue_Icon.Visibility = Visibility.Visible;
                    txt_deleteValue_Icon.Visibility = Visibility.Visible;
                }
                else if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1360)
                {
                    txt_add_Icon.Visibility = Visibility.Collapsed;
                    txt_update_Icon.Visibility = Visibility.Collapsed;
                    txt_delete_Icon.Visibility = Visibility.Collapsed;
                    txt_deleteButton.Visibility = Visibility.Visible;
                    txt_addButton.Visibility = Visibility.Visible;
                    txt_updateButton.Visibility = Visibility.Visible;

                    txt_deleteValueButton.Visibility = Visibility.Visible;
                    txt_addValueButton.Visibility = Visibility.Visible;
                    txt_updateValueButton.Visibility = Visibility.Visible;
                    txt_addValue_Icon.Visibility = Visibility.Collapsed;
                    txt_updateValue_Icon.Visibility = Visibility.Collapsed;
                    txt_deleteValue_Icon.Visibility = Visibility.Collapsed;

                }
                else
                {
                    txt_deleteButton.Visibility = Visibility.Collapsed;
                    txt_addButton.Visibility = Visibility.Collapsed;
                    txt_updateButton.Visibility = Visibility.Collapsed;
                    txt_add_Icon.Visibility = Visibility.Visible;
                    txt_update_Icon.Visibility = Visibility.Visible;
                    txt_delete_Icon.Visibility = Visibility.Visible;

                    txt_deleteValueButton.Visibility = Visibility.Collapsed;
                    txt_addValueButton.Visibility = Visibility.Collapsed;
                    txt_updateValueButton.Visibility = Visibility.Collapsed;
                    txt_addValue_Icon.Visibility = Visibility.Visible;
                    txt_updateValue_Icon.Visibility = Visibility.Visible;
                    txt_deleteValue_Icon.Visibility = Visibility.Visible;

                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this);
            }
        }

        private void Tb_propertyName_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                
                var bc = new BrushConverter();

                if (tb_name.Text.Equals(""))
                {
                    p_errorName.Visibility = Visibility.Visible;
                    tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyMainPropNameToolTip");
                    tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
                }
                else
                {
                    p_errorName.Visibility = Visibility.Collapsed;
                    tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Tb_propertyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var bc = new BrushConverter();

                if (tb_name.Text.Equals(""))
                {
                    p_errorName.Visibility = Visibility.Visible;
                    tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyMainPropNameToolTip");
                    tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
                }
                else
                {
                    p_errorName.Visibility = Visibility.Collapsed;
                    tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void translate()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            //   MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectPropertyNameHint"));
            txt_property.Text = MainWindow.resourcemanager.GetString("trProperty");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            txt_values.Text = MainWindow.resourcemanager.GetString("trValues");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_valueName, MainWindow.resourcemanager.GetString("trValueHint"));


            txt_header.Text = MainWindow.resourcemanager.GetString("trProperty");
            txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");

            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            txt_updateValueButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_addValueButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_deleteValueButton.Text = MainWindow.resourcemanager.GetString("trDelete");

            dg_property.Columns[0].Header = MainWindow.resourcemanager.GetString("trProperty");
            dg_property.Columns[1].Header = MainWindow.resourcemanager.GetString("trValues");

            dg_subProperty.Columns[0].Header = MainWindow.resourcemanager.GetString("trValues");

        }

        private async void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);
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

                translate();

                await RefreshPropertiesList();
                Tb_search_TextChanged(null, null);
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

        private void Dg_subProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                p_errorName.Visibility = Visibility.Collapsed;
                var bc = new BrushConverter();

                if (dg_subProperty.SelectedIndex != -1)
                {
                    propertyItem = dg_subProperty.SelectedItem as PropertiesItems;

                }
                if (propertyItem != null)
                {
                    tb_valueName.Text = propertyItem.propertyItemName;
                    if (propertyItem.propertyItemId != 0)
                    {
                        propertyItemId = propertyItem.propertyItemId;

                        if (propertyItem.canDelete) btn_deleteValue.Content = MainWindow.resourcemanager.GetString("trDelete");

                        else
                        {
                            if (propertyItem.isActive == 0) btn_deleteValue.Content = MainWindow.resourcemanager.GetString("trActive");
                            else btn_deleteValue.Content = MainWindow.resourcemanager.GetString("trInActive");
                        }
                    }
                }
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
        //************************************************
        //******************* update property***************
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update") || SectionData.isAdminPermision())
                {
                    //update
                    property.name = tb_name.Text;
                    property.createUserId = MainWindow.userID;
                    property.updateUserId = MainWindow.userID;

                    Boolean res = await propertyModel.saveProperty(property);

                    if (res)
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                    else
                        Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    await RefreshPropertiesList();
                    Tb_search_TextChanged(null, null);
                    //var poss = await propertyModel.getProperty();
                    //dg_property.ItemsSource = poss;
                 }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var bc = new BrushConverter();

                tb_name.Clear();
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                dg_subProperty.ItemsSource = null;
                tb_valueName.Clear();
                p_errorNameSub.Visibility = Visibility.Collapsed;
                tb_valueName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                property = new Property();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        //************************************************
        //******************* delete property***************
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete") || SectionData.isAdminPermision())
                {
                    if ((!property.canDelete) && (property.isActive == 0))
                    {
                        #region
                        Window.GetWindow(this).Opacity = 0.2;
                        wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                        w.ShowDialog();
                        Window.GetWindow(this).Opacity = 1;
                        #endregion
                        if (w.isOk)
                            await activateProperty();

                    }
                    else
                    {
                        #region
                        Window.GetWindow(this).Opacity = 0.2;
                        wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                        if (property.canDelete)
                            w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                        if (!property.canDelete)
                            w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                        w.ShowDialog();
                        Window.GetWindow(this).Opacity = 1;
                        #endregion
                        if (w.isOk)
                        {
                            string popupContent = "";
                            if (property.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                            if ((!property.canDelete) && (property.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");
                            int userId = (int)MainWindow.userID;
                            Boolean res = await propertyModel.deleteProperty(property.propertyId, userId, property.canDelete);

                            if (res)
                                Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                            else
                                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                        }
                    }

                    await RefreshPropertiesList();
                    Tb_search_TextChanged(null, null);
                    Btn_clear_Click(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private async Task activateProperty()
        {//activate

            property.isActive = 1;

            Boolean s = await propertyModel.saveProperty(property);

            if (s)
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

        }
        private async Task activatePropertyItem()
        {//activate

            propertyItem.isActive = 1;
            propertyItem.name = propertyItem.propertyItemName;

            Boolean s = await propertiesItemsModel.SavePropertiesItems(propertyItem);

            if (s)
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

        }
        async void Dg_property_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                p_errorName.Visibility = Visibility.Collapsed;
                var bc = new BrushConverter();
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                if (dg_property.SelectedIndex != -1)
                {
                    property = dg_property.SelectedItem as Property;
                    this.DataContext = property;
                }
                if (property != null)
                {
                    if (property.propertyId != 0)
                    {

                        var propItems = await propertiesItemsModel.GetPropertyItems(property.propertyId);
                        dg_subProperty.ItemsSource = propItems;
                    }

                    if (property.canDelete)
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                        txt_delete_Icon.Kind =
                                 MaterialDesignThemes.Wpf.PackIconKind.Delete;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                    }

                    else
                    {
                        if (property.isActive == 0)
                        {
                            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trActive");
                            txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Check;
                            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trActive");

                        }
                        else
                        {
                            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trInActive");
                            txt_delete_Icon.Kind =
                                 MaterialDesignThemes.Wpf.PackIconKind.Cancel;
                            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trInActive");

                        }
                    }
                }
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


        private async void Btn_addValue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //add
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                    var bc = new BrushConverter();
                    if (tb_valueName.Text.Equals(""))
                    {
                        p_errorNameSub.Visibility = Visibility.Visible;
                        tt_errorNameSub.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                        tb_valueName.Background = (Brush)bc.ConvertFrom("#15FF0000");
                    }
                    else
                    {
                        p_errorNameSub.Visibility = Visibility.Collapsed;
                        tb_valueName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                    }
                    if (!tb_valueName.Text.Equals(""))
                    {

                        propertyItem.propertyItemId = 0;
                        propertyItem.name = tb_valueName.Text;
                        propertyItem.propertyId = property.propertyId;
                        propertyItem.createUserId = MainWindow.userID;
                        propertyItem.isActive = 1;

                        Boolean res = await propertiesItemsModel.SavePropertiesItems(propertyItem);

                        if (res)
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                        tb_valueName.Text = null;
                        var properties = await propertyModel.getProperty();
                        dg_property.ItemsSource = properties;

                        var propertiesItemss = await propertiesItemsModel.GetPropertyItems(property.propertyId);
                        dg_subProperty.ItemsSource = propertiesItemss;
                    }

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private async void Btn_deleteValue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete") || SectionData.isAdminPermision())
                {
                    if ((!propertyItem.canDelete) && (propertyItem.isActive == 0))
                        await activatePropertyItem();
                    else
                    {
                        string popupContent = "";
                        if (propertyItem.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                        if ((!propertyItem.canDelete) && (propertyItem.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");
                        int userId = (int)MainWindow.userID;
                        Boolean res = await propertiesItemsModel.DeletePropertiesItems(propertyItem.propertyItemId, userId, propertyItem.canDelete);

                        if (res)
                            Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }

                    var propertiesitems = await propertiesItemsModel.GetPropertyItems(property.propertyId);
                    dg_subProperty.ItemsSource = propertiesitems;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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


        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //add

                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                    var bc = new BrushConverter();
                    if (tb_valueName.Text.Equals(""))
                    {
                        p_errorNameSub.Visibility = Visibility.Visible;
                        tt_errorNameSub.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                        tb_valueName.Background = (Brush)bc.ConvertFrom("#15FF0000");
                    }
                    else
                    {
                        p_errorNameSub.Visibility = Visibility.Collapsed;
                        tb_valueName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                    }
                    if (!tb_valueName.Text.Equals(""))
                    {
                        property = new Property
                        {
                            name = tb_name.Text,
                            createUserId = 2,
                            updateUserId = 2,
                            isActive = 1
                        };

                        Boolean res = await propertyModel.saveProperty(property);

                        if (res)
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                        //tb_name.Text = null;


                        await RefreshPropertiesList();
                        Tb_search_TextChanged(null, null);

                        //var properties = await propertyModel.getProperty();
                        //dg_property.ItemsSource = properties;
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private async void Btn_updateValue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update") || SectionData.isAdminPermision())
                {
                    //check mandatory values
                    var bc = new BrushConverter();
                    if (tb_valueName.Text.Equals(""))
                    {
                        p_errorNameSub.Visibility = Visibility.Visible;
                        tt_errorNameSub.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                        tb_valueName.Background = (Brush)bc.ConvertFrom("#15FF0000");
                    }
                    else
                    {
                        p_errorNameSub.Visibility = Visibility.Collapsed;
                        tb_valueName.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                    }
                    if (!tb_valueName.Text.Equals(""))
                    {
                        propertyItem.name = tb_valueName.Text;
                        propertyItem.updateUserId = MainWindow.userID;

                        Boolean res = await propertiesItemsModel.SavePropertiesItems(propertyItem);

                        if (res)
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                        var propertiesItemss = await propertiesItemsModel.GetPropertyItems(property.propertyId);
                        dg_subProperty.ItemsSource = propertiesItemss;
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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




        void refreshPropertiesGrid()
        {
            dg_property.ItemsSource = propertiesQuery;
            txt_count.Text = propertiesQuery.Count().ToString();
        }

        async Task<IEnumerable<Property>> RefreshPropertiesList()
        {

            properties = await propertyModel.getProperty();
            return properties;
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    if (properties is null)
                        await RefreshPropertiesList();
                    searchText = tb_search.Text.ToLower();
                    propertiesQuery = properties.Where(s => s.name.ToLower().Contains(searchText) && s.isActive == tgl_PropertyState);
                    refreshPropertiesGrid();
                }
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
        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {

                    await RefreshPropertiesList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

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
        private async void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (properties is null)
                    await RefreshPropertiesList();
                tgl_PropertyState = 1;
                Tb_search_TextChanged(null, null);
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
        private async void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (properties is null)
                await RefreshPropertiesList();
            tgl_PropertyState = 0;
            Tb_search_TextChanged(null, null);
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
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    Thread t1 = new Thread(() =>
                    {
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\Catalog\Ar\ArPropertiesReport.rdlc";
                        }
                        else addpath = @"\Reports\Catalog\En\PropertiesReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        ReportCls.checkLang();

                        clsReports.properyReport(propertiesQuery, rep, reppath, paramarr);
                        clsReports.setReportLanguage(paramarr);
                        clsReports.Header(paramarr);

                        rep.SetParameters(paramarr);

                        rep.Refresh();
                        this.Dispatcher.Invoke(() =>
                        {
                            saveFileDialog.Filter = "EXCEL|*.xls;";
                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string filepath = saveFileDialog.FileName;
                                LocalReportExtensions.ExportToExcel(rep, filepath);
                            }
                        });


                    });
                    t1.Start();
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        void FN_ExportToExcel()
        {

            var QueryExcel = propertiesQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                Notes = x.propertyValues
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trProperty");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trValues");

            ExportToExcel.Export(DTForExcel);
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            string pdfpath = "";

            List<ReportParameter> paramarr = new List<ReportParameter>();


            //
            pdfpath = @"\Thumb\report\temp.pdf";
            pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Catalog\Ar\ArPropertiesReport.rdlc";
            }
            else addpath = @"\Reports\Catalog\En\PropertiesReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.properyReport(propertiesQuery, rep, reppath, paramarr);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();

            LocalReportExtensions.ExportToPDF(rep, pdfpath);
            wd_previewPdf w = new wd_previewPdf();
            w.pdfPath = pdfpath;
            if (!string.IsNullOrEmpty(w.pdfPath))
            {
                w.ShowDialog();
                w.wb_pdfWebViewer.Dispose();


            }
            Window.GetWindow(this).Opacity = 1;
        }
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Catalog\Ar\ArPropertiesReport.rdlc";
            }
            else addpath = @"\Reports\Catalog\En\PropertiesReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.properyReport(propertiesQuery, rep, reppath, paramarr);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();

            saveFileDialog.Filter = "PDF|*.pdf;";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filepath = saveFileDialog.FileName;
                LocalReportExtensions.ExportToPDF(rep, filepath);
            }
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Catalog\Ar\ArPropertiesReport.rdlc";
            }
            else addpath = @"\Reports\Catalog\En\PropertiesReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.properyReport(propertiesQuery, rep, reppath, paramarr);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);
            rep.Refresh();
            LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
        }
    }
 } 

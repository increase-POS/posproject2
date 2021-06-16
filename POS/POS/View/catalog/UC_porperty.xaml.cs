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
        PropertiesItems PropertiesItemsModel = new PropertiesItems();

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
            InitializeComponent();
            if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1440)
            {
                txt_deleteButton.Visibility = Visibility.Visible;
                txt_addButton.Visibility = Visibility.Visible;
                txt_updateButton.Visibility = Visibility.Visible;
                txt_add_Icon.Visibility = Visibility.Visible;
                txt_update_Icon.Visibility = Visibility.Visible;
                txt_delete_Icon.Visibility = Visibility.Visible;
            }
            else if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1360)
            {
                txt_add_Icon.Visibility = Visibility.Collapsed;
                txt_update_Icon.Visibility = Visibility.Collapsed;
                txt_delete_Icon.Visibility = Visibility.Collapsed;
                txt_deleteButton.Visibility = Visibility.Visible;
                txt_addButton.Visibility = Visibility.Visible;
                txt_updateButton.Visibility = Visibility.Visible;

            }
            else
            {
                txt_deleteButton.Visibility = Visibility.Collapsed;
                txt_addButton.Visibility = Visibility.Collapsed;
                txt_updateButton.Visibility = Visibility.Collapsed;
                txt_add_Icon.Visibility = Visibility.Visible;
                txt_update_Icon.Visibility = Visibility.Visible;
                txt_delete_Icon.Visibility = Visibility.Visible;

            }

        }

        private void Tb_propertyName_LostFocus(object sender, RoutedEventArgs e)
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
        private void Tb_propertyName_TextChanged(object sender, TextChangedEventArgs e)
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

            btn_deleteValue.Content = MainWindow.resourcemanager.GetString("trDelete");


            dg_property.Columns[0].Header = MainWindow.resourcemanager.GetString("trProperty");
            dg_property.Columns[1].Header = MainWindow.resourcemanager.GetString("trValues");

            dg_subProperty.Columns[0].Header = MainWindow.resourcemanager.GetString("trValues");

        }

        private async void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucProperty.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucProperty.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

            var properties = await propertyModel.getProperty();
            dg_property.ItemsSource = properties;
        }

        private void Dg_subProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
            
        }
        //************************************************
        //******************* update property***************
        private async void Btn_update_Click(object sender, RoutedEventArgs e)
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

            var poss = await propertyModel.getProperty();
            dg_property.ItemsSource = poss;
        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;
            var bc = new BrushConverter();
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            tb_name.Clear();
            dg_subProperty.ItemsSource = null;
            property = new Property();
        }
        //************************************************
        //******************* delete property***************
        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
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

            var prop = await propertyModel.getProperty();
            dg_property.ItemsSource = prop;
            Btn_clear_Click(sender, e);
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

            Boolean s = await PropertiesItemsModel.SavePropertiesItems(propertyItem);

            if (s) 
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else 
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

        }
        async void Dg_property_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
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
                                        
                    var propItems = await PropertiesItemsModel.GetPropertyItems(property.propertyId);
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

        }


        private async void Btn_addValue_Click(object sender, RoutedEventArgs e)
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
                //add
                propertyItem.propertyItemId = 0;
                propertyItem.name = tb_valueName.Text;
                propertyItem.propertyId = property.propertyId;
                propertyItem.createUserId = MainWindow.userID;
                propertyItem.isActive = 1;

                Boolean res = await PropertiesItemsModel.SavePropertiesItems(propertyItem);

                if (res) 
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                else 
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                tb_valueName.Text = null;
                var properties = await propertyModel.getProperty();
                dg_property.ItemsSource = properties;

                var propertiesItemss = await PropertiesItemsModel.GetPropertyItems(property.propertyId);
                dg_subProperty.ItemsSource = propertiesItemss;
            }
            
        }

        private async void Btn_deleteValue_Click(object sender, RoutedEventArgs e)
        {
            if ((!propertyItem.canDelete) && (propertyItem.isActive == 0))
               await activatePropertyItem();
            else
            {
                string popupContent = "";
                if (propertyItem.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                if ((!propertyItem.canDelete) && (propertyItem.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");
                int userId = (int)MainWindow.userID;
                Boolean res = await PropertiesItemsModel.DeletePropertiesItems(propertyItem.propertyItemId, userId, propertyItem.canDelete);

                if (res) 
                    Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                else 
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }

            var propertiesitems = await PropertiesItemsModel.GetPropertyItems(property.propertyId);
            dg_subProperty.ItemsSource = propertiesitems;       
        }

        private async  void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            //add
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

            tb_name.Text = null;
            var properties = await propertyModel.getProperty();
            dg_property.ItemsSource = properties;
        }

        private async void Btn_updateValue_Click(object sender, RoutedEventArgs e)
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
            if(!tb_valueName.Text.Equals(""))
            {
                propertyItem.name = tb_valueName.Text;
                propertyItem.updateUserId = MainWindow.userID;

                Boolean res = await PropertiesItemsModel.SavePropertiesItems(propertyItem);

                if (res) 
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                else 
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                var propertiesItemss = await PropertiesItemsModel.GetPropertyItems(property.propertyId);
                dg_subProperty.ItemsSource = propertiesItemss;
            }
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
 } 

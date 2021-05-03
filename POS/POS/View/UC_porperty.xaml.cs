﻿using POS.Classes;
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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_porperty.xaml
    /// </summary>
    public partial class UC_porperty : UserControl
    {
        public int PropertyId;
        Property propertyModel = new Property();
        PropertiesItems PropertiesItemsModel = new PropertiesItems();
        public UC_porperty()
        {
            InitializeComponent();
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

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            btn_addValue.Content = MainWindow.resourcemanager.GetString("trAdd");
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

            var propertiesItems = await PropertiesItemsModel.Get();
            dg_subProperty.ItemsSource = propertiesItems;
        }

        private void Dg_subProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Dg_property_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


       


            private async void Btn_update_Click(object sender, RoutedEventArgs e)
            {
                //update
                Property property = new Property
                {
                    propertyId = PropertyId,

                    name = tb_name.Text,
                    //balance = 0,
                    //balance      = decimal.Parse(tb_balance.Text),
                    //branchId     = 1,
                    createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                    createUserId = 2,
                    updateUserId = 2,
                    // isActive = 1
                };


                await propertyModel.saveProperty(property);

                var poss = await propertyModel.getProperty();
                dg_property.ItemsSource = poss;


            }
            private void Btn_clear_Click(object sender, RoutedEventArgs e)
            {
                p_errorName.Visibility = Visibility.Collapsed;
                var bc = new BrushConverter();
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_name.Text = "";
            }
            private async void Btn_delete_Click(object sender, RoutedEventArgs e)
            {
                //delete
                await propertyModel.Delete(PropertyId);

                var properties = await propertyModel.getProperty();
                dg_property.ItemsSource = properties;

                //clear textBoxs
                //Btn_clear_Click(sender, e);
            }

            private void Dg_property_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
            {
                p_errorName.Visibility = Visibility.Collapsed;
                // p_errorCode.Visibility = Visibility.Collapsed;
                // p_errorBalance.Visibility = Visibility.Collapsed;
                // p_errorSelectBranch.Visibility = Visibility.Collapsed;
                var bc = new BrushConverter();
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                //  tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                //tb_balance.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                //   tt_errorSelectBranch.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                Property property = new Property();

                if (dg_property.SelectedIndex != -1)
                {
                    property = dg_property.SelectedItem as Property;
                    this.DataContext = property;
                }
                if (property != null)
                {
                    if (property.propertyId != 0)
                    {
                        PropertyId = property.propertyId;
                    }


                }

            }


            private async void Btn_addValue_Click(object sender, RoutedEventArgs e)
                {

                    //add
                    PropertiesItems propertiesItems = new PropertiesItems
                    {
                        name = tb_valueName.Text,
                        propertyId = 1,                       
                        createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                        updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                        createUserId = 2,
                        updateUserId = 2,
                         isActive = 1,
                         isDefault =1
                    };

            //  await PropertiesItemsModel.Save(propertiesItems);
            //MessageBox.Show(PropertyId.ToString());
                     await PropertiesItemsModel.Save(propertiesItems);
                     var propertiesItemss = await PropertiesItemsModel.Get();
                     dg_subProperty.ItemsSource = propertiesItemss;
            
            //get property id
            //getPropertyID(tb_valueName.Text);
                    MessageBox.Show(propertiesItemss.Count.ToString());
                    //add values
                    

                }

                int id = 0;
                private async void getPropertyID(string name)
                {
                    List<string> names = new List<string>();
                    List<int> ids = new List<int>();

                    var props = await propertyModel.getProperty();
                    Property prop = new Property();
                    // MessageBox.Show(props.Count.ToString());
                    for (int i = 0; i < props.Count; i++)
                    {
                        prop = props[i];
                        if (prop.name.Trim().Equals(name.Trim()))
                        {
                            id = prop.propertyId;
                            break;
                        }
                        //names.Add(prop.name);
                        //ids.Add(prop.propertyId);

                    }
                    //for(int i;)
                    //if (names.Contains(name))
                    //    id = 
                    MessageBox.Show(prop.propertyId.ToString());
                }

        private void Btn_deleteValue_Click(object sender, RoutedEventArgs e)
        {

        }

        private async  void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            //add
            Property property = new Property
            {
                name = tb_name.Text,                
                createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                createUserId = 2,
                updateUserId = 2,
                // isActive = 1
            };
            //PropertiesItems propertiesItems = new PropertiesItems
            //{
            //    name = tb_valueName.Text,
            //    createDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
            //    updateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
            //    createUserId = 2,
            //    updateUserId = 2,
            //    // isActive = 1
            //};

            MessageBox.Show( await propertyModel.saveProperty(property));
            //MessageBox.Show(PropertyId.ToString());
            var properties = await propertyModel.getProperty();
            dg_property.ItemsSource = properties;
            //get property id
            //  getPropertyID(tb_valueName.Text);
            MessageBox.Show(properties.Count.ToString());

            //add values
            //  var value = await PropertiesItemsModel.Save(propertiesItems);
            //   dg_subProperty.ItemsSource = value;
        }
    }
 } 

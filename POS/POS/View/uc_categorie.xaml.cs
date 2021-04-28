using POS.Classes;
using POS.controlTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for uc_categorie.xaml
    /// </summary>
    public partial class uc_categorie : UserControl
    {
        public uc_categorie()
        {
            InitializeComponent();
        }
        private void translate()
        {
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_categoryCode, MainWindow.resourcemanager.GetString("trCodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_details, MainWindow.resourcemanager.GetString("trDetailsHint"));
            txt_secondaryInformation.Text = MainWindow.resourcemanager.GetString("trSecondaryInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_parentCategorie, MainWindow.resourcemanager.GetString("trParentCategorieHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_taxes, MainWindow.resourcemanager.GetString("trTaxesHint"));
         //   MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_categorie, MainWindow.resourcemanager.GetString("trCategorie"));
            txt_categorie.Text = MainWindow.resourcemanager.GetString("trCategorie");

            btn_add.Content = MainWindow.resourcemanager.GetString("trAdd");
            btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            catigoriesAndItemsView.ucCategorie = this;
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucCategorie.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucCategorie.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            #region Generate catigorie
            catigoriesAndItemsView.gridCatigories = Grid_categorie;
            Categorie categorie = new Categorie();
            catigoriesAndItemsView.FN_refrishCatalogCard(categorie.getCategories());
            #endregion


            #region Generate catigorieItems
            catigoriesAndItemsView.gridCatigorieItems = Grid_CategorieItem;
            CategorieItem CategorieItem = new CategorieItem();
            catigoriesAndItemsView.FN_refrishCatalogItem(CategorieItem.getCategorieItems() , MainWindow.lang, "sale");

            #region DataGrid
            // code
            // name
            //details

            List<Item> items = new List<Item>();
            items.Add(new Item()
            {
                code = 1,
                name = "ThermalPrinters",
                details = "EPSON-thermal-printer"
            });

            items.Add(new Item()
            {

                code = 2,
                name = "ThermalPrinters",
                details = "EPSON-thermal-printer2",
            });

            items.Add(new Item()
            {

                code = 3,
                name = "ThermalPrinters",
                details = "EPSON-thermal-printer3",
            });
            //dg_items.ItemsSource = items;

            #endregion

            #endregion
        }
        class Item {
            public int code { get; set; }
            public string name { get; set; }
            public string details { get; set; }
        }

        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();

        public void testChangeCategorieIdEvent()
        {
            MessageBox.Show("Hello World!! CategorieId");
        }
        public void testChangeCategorieItemsIdEvent()
        {
            MessageBox.Show("Hello World!!  CategorieItems Id");
        }

        #region Catalog
        public class Categorie
        {
            public int categoryId;
            public string name;
            public string image;

            public List<Categorie> getCategories()
            {
                List<Categorie> categories = new List<Categorie>();
                categories.Add(new Categorie()
                {
                    categoryId = 1,
                    name = "barcode-printer",
                    image = "/pic/barcode-printer/barcode-printer.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 2,
                    name = "BarcodeReader",
                    image = "/pic/BarcodeReader/datalogic-barcode-scanner4.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 3,
                    name = "CashDrawer",
                    image = "/pic/CashDrawer/cash-drawer6.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 4,
                    name = "POS",
                    image = "/pic/POS/POZONE-POS2.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 5,
                    name = "Programs",
                    image = "/pic/Programs/laundry-casheir-program.png"

                });



                categories.Add(new Categorie()
                {
                    categoryId = 6,
                    name = "barcode-printer",
                    image = "/pic/barcode-printer/barcode-printer.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 7,
                    name = "BarcodeReader",
                    image = "/pic/BarcodeReader/datalogic-barcode-scanner4.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 8,
                    name = "CashDrawer",
                    image = "/pic/CashDrawer/cash-drawer6.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 9,
                    name = "POS",
                    image = "/pic/POS/POZONE-POS2.png"

                });
                categories.Add(new Categorie()
                {
                    categoryId = 10,
                    name = "Programs",
                    image = "/pic/Programs/laundry-casheir-program.png"

                });

                return categories;
            }

        }
        #endregion
        #region  Catalog Items
        public class CategorieItem
        {
            public int CategorieItemsId;
            public string title;
            public string subtitle;
            public string price;
            public string New;
            public string isOffer;
            public string image;

            public List<CategorieItem> getCategorieItems()
            {
                List<CategorieItem> CategorieItems = new List<CategorieItem>();
                //Collapsed
                //    Visible
                CategorieItems.Add(new CategorieItem()
                {
                    CategorieItemsId = 1,
                    title = "ThermalPrinters",
                    subtitle = "EPSON-thermal-printer",
                    price = "1050$",
                    New = "Visible",
                    isOffer = "Collapsed",
                    image = "/pic/ThermalPrinters/EPSON-thermal-printer.png"
                });
                CategorieItems.Add(new CategorieItem()
                {
                    CategorieItemsId = 2,
                    title = "ThermalPrinters",
                    subtitle = "EPSON-thermal-printer2",
                    price = "350$",
                    New = "Collapsed",
                    isOffer = "Collapsed",
                    image = "/pic/ThermalPrinters/EPSON-thermal-printer2.png"
                });
                CategorieItems.Add(new CategorieItem()
                {
                    CategorieItemsId = 3,
                    title = "ThermalPrinters",
                    subtitle = "EPSON-thermal-printer3",
                    price = "650$",
                    New = "Visible",
                    isOffer = "Visible",
                    image = "/pic/ThermalPrinters/EPSON-thermal-printer3.png"
                });
                CategorieItems.Add(new CategorieItem()
                {
                    CategorieItemsId = 4,
                    title = "ThermalPrinters",
                    subtitle = "EPSON-thermal-printer4",
                    price = "120$",
                    New = "Visible",
                    isOffer = "Collapsed",
                    image = "/pic/ThermalPrinters/EPSON-thermal-printer4.png"
                });
                CategorieItems.Add(new CategorieItem()
                {
                    CategorieItemsId = 5,
                    title = "ThermalPrinters",
                    subtitle = "POZONE-PP610-USB",
                    price = "240$",
                    New = "Collapsed",
                    isOffer = "Visible",
                    image = "/pic/ThermalPrinters/POZONE-PP610-USB.png"
                });
                CategorieItems.Add(new CategorieItem()
                {
                    CategorieItemsId = 6,
                    title = "ThermalPrinters",
                    subtitle = "POZONE-thermal-printer",
                    price = "995$",
                    New = "Collapsed",
                    isOffer = "Collapsed",
                    image = "/pic/ThermalPrinters/POZONE-thermal-printer.png"
                });
                CategorieItems.Add(new CategorieItem()
                {
                    CategorieItemsId = 7,
                    title = "ThermalPrinters",
                    subtitle = "rio-thermal-printer",
                    price = "335$",
                    New = "Collapsed",
                    isOffer = "Collapsed",
                    image = "/pic/ThermalPrinters/rio-thermal-printer.png"
                });
                CategorieItems.Add(new CategorieItem()
                {
                    CategorieItemsId = 8,
                    title = "ThermalPrinters",
                    subtitle = "Sewoo-thermal-printer",
                    price = "799$",
                    New = "Collapsed",
                    isOffer = "Visible",
                    image = "/pic/ThermalPrinters/Sewoo-thermal-printer.png"
                });
                CategorieItems.Add(new CategorieItem()
                {
                    CategorieItemsId = 9,
                    title = "ThermalPrinters",
                    subtitle = "Zebra-ZD200D",
                    price = "1250$",
                    New = "Visible",
                    isOffer = "Visible",
                    image = "/pic/ThermalPrinters/Zebra-ZD200D.png"
                });

                return CategorieItems;
            }
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_categoryCode_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_categoryCode.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_categoryCode.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                tt_errorCode.Visibility = Visibility.Collapsed;
                tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_categoryCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_categoryCode.Text.Equals(""))
            {
                p_errorCode.Visibility = Visibility.Visible;
                tt_errorCode.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_categoryCode.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                tt_errorCode.Visibility = Visibility.Collapsed;
                tb_categoryCode.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }

        }

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
   var bc = new BrushConverter();

            if (tb_name.Text.Equals(""))
            {
                p_errorName.Visibility = Visibility.Visible;
                tt_errorName.Content = MainWindow.resourcemanager.GetString("trEmptyNameToolTip");
                tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Btn_ItemsInCards_Click(object sender, RoutedEventArgs e)
        {
            grid_itemsDatagrid.Visibility = Visibility.Collapsed;
            grid_ItemsCard.Visibility = Visibility.Visible;
        }

        private void Btn_ItemsInGrid_Click(object sender, RoutedEventArgs e)
        {
            grid_ItemsCard.Visibility = Visibility.Collapsed;
            grid_itemsDatagrid.Visibility = Visibility.Visible;
        }
    }
}

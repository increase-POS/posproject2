using POS.Classes;
using POS.controlTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for uc_categorie.xaml
    /// </summary>
    public partial class uc_categorie : UserControl
    {
        public uc_categorie()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            catigoriesAndItemsView.ucCategorie = this;

            #region Generate catigorie
            catigoriesAndItemsView.gridCatigories = Grid_categorie;
            Categorie categorie = new Categorie();
            catigoriesAndItemsView.FN_refrishCatalogCard(categorie.getCategories());
            #endregion


            #region Generate catigorieItems
            catigoriesAndItemsView.gridCatigorieItems = Grid_CategorieItem;
            CategorieItem CategorieItem = new CategorieItem();
            catigoriesAndItemsView.FN_refrishCatalogItem(CategorieItem.getCategorieItems());
            #endregion
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




    }
}

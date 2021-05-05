using client_app.Classes;
using POS.controlTemplate;
using POS.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static POS.View.uc_categorie;

namespace POS.Classes
{
    public class CatigoriesAndItemsView 
    {

        //public string language  { get; set; }
        public uc_categorie ucCategorie;
        public UC_item ucCategorieItem;
        public uc_payInvoice ucPayInvoice;

        public Grid gridCatigories;
        public Grid gridCatigorieItems;
        private int _idCatigories;
        private int _idCatigorieItems;
        private int _idPayInvoice;
        public int idCatigories
        {
            get => _idCatigories; set
            {

                _idCatigories = value;
                INotifyPropertyChangedIdCatigories();
            }
        }
        public int idCatigorieItems
        {
            get => _idCatigorieItems; set
            {

                _idCatigorieItems = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        public int idPayInvoice
        {
            get => _idPayInvoice; set
            {

                _idPayInvoice = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        private void INotifyPropertyChangedIdCatigories()
        {
            if (ucCategorie != null)
            {
                //ucCategorie.testChangeCategorieIdEvent(_idCatigories);
                ucCategorie.ChangeCategorieIdEvent(idCatigories);

            }
            else if (ucCategorieItem != null)
            {
                ucCategorieItem.testChangeCategorieIdEvent();
            }
            

        }

        
        private void INotifyPropertyChangedIdCatigorieItems()
        {

            if (ucCategorie != null)
            {
                ucCategorie.testChangeCategorieItemsIdEvent();

            }
            else if (ucCategorieItem != null)
            {
                ucCategorieItem.testChangeCategorieItemsIdEvent();
            }   
        }

        #region Catalog
        public int pastCatalogCard = -1;



        /*
        public void FN_refrishCatalogCard(List<Category> categories)
        {
            gridCatigories.Children.Clear();
            int column = 0;
            foreach (var item in categories)
            {
                FN_createCatalogCard(item.categoryId, item.name, item.image, column, 1);
                column++;
            }
        }
        
        public void FN_refrishCatalogCard(List<Category> categories)
        {
            gridCatigories.Children.Clear();
            int row = 0;
            int column = 0;
            foreach (var item in categories)
            {
                FN_createCatalogCard(item.categoryId, item.name, item.image, column, row);

                row++;
                if (row == 3)
                {
                    row = 0;
                    column++;
                }
            }
        }
        */

        public void FN_refrishCatalogCard(List<Category> categories ,int columnCount)
        {
            gridCatigories.Children.Clear();
            int row = 0;
            int column = 0;
            foreach (var item in categories)
            {
                FN_createCatalogCard(item.categoryId, item.name, item.image,  row , column , columnCount);

                //row++;
                //if (row == rowCount)
                //{
                //    row = 0;
                //    column++;
                //}

                //column++;
                //if (column == 3)
                //{
                //    column = 0;
                //    row++;
                //}
                column++;
                if (column == columnCount)
                {
                    column = 0;
                    row++;
                }
            }
        }

        public UC_squareCard FN_createCatalogCard(int id, string name, string image,  int row, int column, int columnCount,   string BorderBrush = "#6e6e6e")
        {
            UC_squareCard uc = new UC_squareCard();
            uc.ContentId = id;
            uc.squareCardText = name;
            uc.squareCardBorderBrush = BorderBrush;
            uc.squareCardImageSource = image;
            uc.Margin = new Thickness(5, 0, 5, 0);
            uc.Tag = "categorie" + id;
            uc.Name = "categorie" + id;
            uc.Row = row;
            uc.Column = column;
            //uc.rowCount = rowCount;
            uc.columnCount = columnCount;
            Grid.SetColumn(uc, column);
            Grid.SetRow(uc, row);
            //uc.Tag = "1";
            gridCatigories.Children.Add(uc);
            uc.MouseDoubleClick += new MouseButtonEventHandler(catalogCard_MouseDoubleClick);
            //uc.MouseEnter += new MouseEventHandler(UserControl_MouseEnter);
            return uc;
        }

        void catalogCard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //FN_refrishCatalogCard();
            UC_squareCard uc = (UC_squareCard)sender;
            uc = gridCatigories.Children.OfType<UC_squareCard>().Where(x => x.Name.ToString() == "categorie" + uc.ContentId).FirstOrDefault();

            gridCatigories.Children.Remove(uc);
            FN_createCatalogCard(uc.ContentId, uc.squareCardText, uc.squareCardImageSource, uc.Row, uc.Column, uc.columnCount,   "#178DD2");


            if (pastCatalogCard != -1 )
            {
                var pastUc = new UC_squareCard() { ContentId = pastCatalogCard };
                pastUc = gridCatigories.Children.OfType<UC_squareCard>().Where(x => x.Name.ToString() == "categorie" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigories.Children.Remove(pastUc);
                    FN_createCatalogCard(pastUc.ContentId, pastUc.squareCardText, pastUc.squareCardImageSource, pastUc.Row, pastUc.Column,
                     pastUc.columnCount, "#6e6e6e");
                }
            }

            pastCatalogCard = uc.ContentId;
            idCatigories = uc.ContentId;
        }
         

        #endregion
        #region Catalog Items


        private int pastCatalogItem = -1;
        internal uc_receiptInvoice ucReceiptInvoice;
    

        public void FN_refrishCatalogItem(List<Item> items, string language, string cardType)
        {
            gridCatigorieItems.Children.Clear();
            int row = 0;
            int column = 0;
            foreach (var item in items)
            {
                //Visible
                //    Collapsed


                if (cardType == "sale")
                {
                    if (language == "ar")
                        FN_createCatalogItem_ar(item.itemId, item.name, item.details
                           , "0$", item.image, row, column, "Collapsed", "Collapsed");
                    else FN_createCatalogItem(item.itemId, item.name, item.details
                           , "0$", item.image, row, column, "Collapsed", "Collapsed");
                }
                else
                {
                    if (language == "ar")
                        FN_createCatalogItemtWithoutPrice_ar(item.itemId, item.name, item.details
                           , "0$", item.image, row, column, "Collapsed", "Collapsed");
                    else
                        FN_createCatalogItemtWithoutPrice(item.itemId, item.name, item.details
                           , "0$", item.image, row, column, "Collapsed", "Collapsed");
                }


                row++;
                if (row == 3)
                {
                    row = 0;
                    column++;
                }
            }




        }
        #region  sale
        #region En
        UC_rectangleCardPrice FN_createCatalogItem(int id, string title, string subtitle, string price, string image, int row, int column,
           string newItem, string offer, string BorderBrush = "#6e6e6e")
        {

            UC_rectangleCardPrice uc = new UC_rectangleCardPrice();
            uc.ContentId = id;
            uc.rectangleCardPriceTitleText = title;
            uc.rectangleCardPriceSubtitleText = subtitle;
            uc.rectangleCardPriceBorderBrush = BorderBrush;
            uc.rectangleCardPricePriceTitle = price;
            uc.rectangleCardPriceImageSource = image;
            uc.rectangleCardPriceNew = newItem;
            uc.rectangleCardPriceOffer = offer;
            uc.Tag = "CategorieItems" + id;
            uc.Name = "CategorieItems" + id;
            uc.Row = row;
            uc.Column = column;
            Grid.SetColumn(uc, column);
            Grid.SetRow(uc, row);
            gridCatigorieItems.Children.Add(uc);
            uc.MouseDoubleClick += new MouseButtonEventHandler(catalogItem_MouseDoubleClick);
            return uc;
        }

        void catalogItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UC_rectangleCardPrice uc = (UC_rectangleCardPrice)sender;
            uc = gridCatigorieItems.Children.OfType<UC_rectangleCardPrice>().Where(x => x.Name.ToString() == "CategorieItems" + uc.ContentId).FirstOrDefault();

            gridCatigorieItems.Children.Remove(uc);
            FN_createCatalogItem(uc.ContentId, uc.rectangleCardPriceTitleText, uc.rectangleCardPriceSubtitleText, uc.rectangleCardPricePriceTitle, uc.rectangleCardPriceImageSource, uc.Row, uc.Column,
               uc.rectangleCardPriceNew, uc.rectangleCardPriceOffer, "#178DD2");
            if (pastCatalogItem != -1)
            {
                var pastUc = new UC_rectangleCardPrice() { ContentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCardPrice>().Where(x => x.Name.ToString() == "CategorieItems" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createCatalogItem(pastUc.ContentId, pastUc.rectangleCardPriceTitleText, pastUc.rectangleCardPriceSubtitleText, pastUc.rectangleCardPricePriceTitle
                        , pastUc.rectangleCardPriceImageSource, pastUc.Row, pastUc.Column, pastUc.rectangleCardPriceNew, pastUc.rectangleCardPriceOffer, "#6e6e6e");
                }
            }
            pastCatalogItem = uc.ContentId;
            idCatigorieItems = uc.ContentId;
        }
        #endregion
        #region Ar
        UC_rectangleCardPrice_ar FN_createCatalogItem_ar(int id, string title, string subtitle, string price, string image, int row, int column,
           string newItem, string offer, string BorderBrush = "#6e6e6e")
        {

            UC_rectangleCardPrice_ar uc = new UC_rectangleCardPrice_ar();
            uc.ContentId = id;
            uc.rectangleCardPriceTitleText_ar = title;
            uc.rectangleCardPriceSubtitleText_ar = subtitle;
            uc.rectangleCardPriceBorderBrush_ar = BorderBrush;
            uc.rectangleCardPricePriceTitle_ar = price;
            uc.rectangleCardPriceImageSource_ar = image;
            uc.rectangleCardPriceNew_ar = newItem;
            uc.rectangleCardPriceOffer_ar = offer;
            uc.Tag = "CategorieItems" + id;
            uc.Name = "CategorieItems" + id;
            uc.Row = row;
            uc.Column = column;
            Grid.SetColumn(uc, column);
            Grid.SetRow(uc, row);
            gridCatigorieItems.Children.Add(uc);
            uc.MouseDoubleClick += new MouseButtonEventHandler(catalogItem_ar_MouseDoubleClick);
            return uc;
        }

        void catalogItem_ar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UC_rectangleCardPrice_ar uc = (UC_rectangleCardPrice_ar)sender;
            uc = gridCatigorieItems.Children.OfType<UC_rectangleCardPrice_ar>().Where(x => x.Name.ToString() == "CategorieItems" + uc.ContentId).FirstOrDefault();

            gridCatigorieItems.Children.Remove(uc);
            FN_createCatalogItem_ar(uc.ContentId, uc.rectangleCardPriceTitleText_ar, uc.rectangleCardPriceSubtitleText_ar, uc.rectangleCardPricePriceTitle_ar,
                uc.rectangleCardPriceImageSource_ar, uc.Row, uc.Column,
               uc.rectangleCardPriceNew_ar, uc.rectangleCardPriceOffer_ar, "#178DD2");
            if (pastCatalogItem != -1)
            {
                var pastUc = new UC_rectangleCardPrice_ar() { ContentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCardPrice_ar>().Where(x => x.Name.ToString() == "CategorieItems" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createCatalogItem_ar(pastUc.ContentId, pastUc.rectangleCardPriceTitleText_ar, pastUc.rectangleCardPriceSubtitleText_ar, pastUc.rectangleCardPricePriceTitle_ar
                        , pastUc.rectangleCardPriceImageSource_ar, pastUc.Row, pastUc.Column, pastUc.rectangleCardPriceNew_ar, pastUc.rectangleCardPriceOffer_ar, "#6e6e6e");
                }
            }
            pastCatalogItem = uc.ContentId;
            idCatigorieItems = uc.ContentId;
        }

        #endregion
        #endregion

        #region purchase

        #region  En
        UC_rectangleCardWithoutPrice FN_createCatalogItemtWithoutPrice(int id, string title, string subtitle, string price, string image, int row, int column,
        string newItem, string offer, string BorderBrush = "#6e6e6e")
        {

            UC_rectangleCardWithoutPrice uc = new UC_rectangleCardWithoutPrice();
            uc.ContentId = id;
            uc.rectangleCardWithoutPriceTitleText = title;
            uc.rectangleCardWithoutPriceSubtitleText = subtitle;
            uc.rectangleCardWithoutPriceBorderBrush = BorderBrush;
            uc.rectangleCardWithoutPriceWithoutPriceTitle = price;
            uc.rectangleCardWithoutPriceImageSource = image;
            uc.rectangleCardWithoutPriceNew = newItem;
            uc.rectangleCardWithoutPriceOffer = offer;
            uc.Tag = "CategorieItems" + id;
            uc.Name = "CategorieItems" + id;
            uc.Row = row;
            uc.Column = column;
            Grid.SetColumn(uc, column);
            Grid.SetRow(uc, row);
            gridCatigorieItems.Children.Add(uc);
            uc.MouseDoubleClick += new MouseButtonEventHandler(catalogItemWithoutPrice_MouseDoubleClick);
            return uc;
        }

        void catalogItemWithoutPrice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UC_rectangleCardWithoutPrice uc = (UC_rectangleCardWithoutPrice)sender;
            uc = gridCatigorieItems.Children.OfType<UC_rectangleCardWithoutPrice>().Where(x => x.Name.ToString() == "CategorieItems" + uc.ContentId).FirstOrDefault();

            gridCatigorieItems.Children.Remove(uc);
            FN_createCatalogItemtWithoutPrice(uc.ContentId, uc.rectangleCardWithoutPriceTitleText, uc.rectangleCardWithoutPriceSubtitleText, uc.rectangleCardWithoutPriceWithoutPriceTitle, uc.rectangleCardWithoutPriceImageSource, uc.Row, uc.Column,
               uc.rectangleCardWithoutPriceNew, uc.rectangleCardWithoutPriceOffer, "#178DD2");
            if (pastCatalogItem != -1)
            {
                var pastUc = new UC_rectangleCardWithoutPrice() { ContentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCardWithoutPrice>().Where(x => x.Name.ToString() == "CategorieItems" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createCatalogItemtWithoutPrice(pastUc.ContentId, pastUc.rectangleCardWithoutPriceTitleText, pastUc.rectangleCardWithoutPriceSubtitleText, pastUc.rectangleCardWithoutPriceWithoutPriceTitle
                        , pastUc.rectangleCardWithoutPriceImageSource, pastUc.Row, pastUc.Column, pastUc.rectangleCardWithoutPriceNew, pastUc.rectangleCardWithoutPriceOffer, "#6e6e6e");
                }
            }
            pastCatalogItem = uc.ContentId;
            idCatigorieItems = uc.ContentId;
        }
        #endregion
        #region  Ar
        UC_rectangleCardWithoutPrice_ar FN_createCatalogItemtWithoutPrice_ar(int id, string title, string subtitle, string price, string image, int row, int column,
        string newItem, string offer, string BorderBrush = "#6e6e6e")
        {

            UC_rectangleCardWithoutPrice_ar uc = new UC_rectangleCardWithoutPrice_ar();
            uc.ContentId = id;
            uc.rectangleCardWithoutPriceTitleText_ar = title;
            uc.rectangleCardWithoutPriceSubtitleText_ar = subtitle;
            uc.rectangleCardWithoutPriceBorderBrush_ar = BorderBrush;
            uc.rectangleCardWithoutPriceWithoutPriceTitle_ar = price;
            uc.rectangleCardWithoutPriceImageSource_ar = image;
            uc.rectangleCardWithoutPriceNew_ar = newItem;
            uc.rectangleCardWithoutPriceOffer_ar = offer;
            uc.Tag = "CategorieItems" + id;
            uc.Name = "CategorieItems" + id;
            uc.Row = row;
            uc.Column = column;
            Grid.SetColumn(uc, column);
            Grid.SetRow(uc, row);
            gridCatigorieItems.Children.Add(uc);
            uc.MouseDoubleClick += new MouseButtonEventHandler(catalogItemWithoutPrice_ar_MouseDoubleClick);
            return uc;
        }

        void catalogItemWithoutPrice_ar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UC_rectangleCardWithoutPrice_ar uc = (UC_rectangleCardWithoutPrice_ar)sender;
            uc = gridCatigorieItems.Children.OfType<UC_rectangleCardWithoutPrice_ar>().Where(x => x.Name.ToString() == "CategorieItems" + uc.ContentId).FirstOrDefault();

            gridCatigorieItems.Children.Remove(uc);
            FN_createCatalogItemtWithoutPrice_ar(uc.ContentId, uc.rectangleCardWithoutPriceTitleText_ar, uc.rectangleCardWithoutPriceSubtitleText_ar, uc.rectangleCardWithoutPriceWithoutPriceTitle_ar, 
                uc.rectangleCardWithoutPriceImageSource_ar, uc.Row, uc.Column,
               uc.rectangleCardWithoutPriceNew_ar, uc.rectangleCardWithoutPriceOffer_ar, "#178DD2");
            if (pastCatalogItem != -1)
            {
                var pastUc = new UC_rectangleCardWithoutPrice_ar() { ContentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCardWithoutPrice_ar>().Where(x => x.Name.ToString() == "CategorieItems" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createCatalogItemtWithoutPrice_ar(pastUc.ContentId, pastUc.rectangleCardWithoutPriceTitleText_ar, pastUc.rectangleCardWithoutPriceSubtitleText_ar,
                        pastUc.rectangleCardWithoutPriceWithoutPriceTitle_ar
                        , pastUc.rectangleCardWithoutPriceImageSource_ar, pastUc.Row, pastUc.Column, pastUc.rectangleCardWithoutPriceNew_ar, pastUc.rectangleCardWithoutPriceOffer_ar, "#6e6e6e");
                }
            }
            pastCatalogItem = uc.ContentId;
            idCatigorieItems = uc.ContentId;
        }
        #endregion


        #endregion

        #endregion



    }
}

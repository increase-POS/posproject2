using POS.Classes;
using POS.controlTemplate;
using POS.View;
using POS.View.storage;
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
        public UC_item ucItem;
        public uc_payInvoice ucPayInvoice;
        public uc_itemsImport ucItemsImport;
        public uc_itemsExport ucItemsExport;
        public uc_itemsDestroy ucItemsDestroy;
        public uc_receiptOfPurchaseInvoice ucreceiptOfPurchaseInvoice;
        public uc_packageOfItems ucPackageOfItems;

        public Grid gridCatigories;
        public Grid gridCatigorieItems;
        private int _idCatigories;
        private int _idItem;
        private int _idPayInvoice;
        private int _idItemsImport;
        private int _idItemsExport;
        private int _idItemsDestroy;
        private int _idReceiptOfPurchaseInvoice;
        private int _idPackageOfItems;
        public int idCatigories
        {
            get => _idCatigories; set
            {

                _idCatigories = value;
                INotifyPropertyChangedIdCatigories();
            }
        }
        public int idItem
        {
            get => _idItem; set
            {

                _idItem = value;
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
        public int idItemsImport
        {
            get => _idItemsImport; set
            {

                _idItemsImport = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        public int idItemsExport
        {
            get => _idItemsExport; set
            {

                _idItemsExport = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        public int idItemsDestroy
        {
            get => _idItemsDestroy; set
            {

                _idItemsDestroy = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        public int idReceiptOfPurchaseInvoice
        {
            get => _idReceiptOfPurchaseInvoice; set
            {

                _idReceiptOfPurchaseInvoice = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        public int idPackageOfItems
        {
            get => _idPackageOfItems; set
            {

                _idPackageOfItems = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        private void INotifyPropertyChangedIdCatigories()
        {
            if (ucCategorie != null)
            {
                ucCategorie.ChangeCategorieIdEvent(idCatigories);

            }
            else if (ucItem != null)
            {
                ucItem.ChangeCategoryIdEvent(idCatigories);
            }
            else  if (ucPayInvoice != null)
            {
                ucPayInvoice.ChangeCategoryIdEvent(idCatigories);

            }
            else if (ucItemsImport != null)
            {
                ucItemsImport.ChangeCategoryIdEvent(idCatigories);

            }
            else if (ucItemsExport != null)
            {
                ucItemsExport.ChangeCategoryIdEvent(idCatigories);

            }
            else if (ucItemsDestroy != null)
            {
                ucItemsDestroy.ChangeCategoryIdEvent(idCatigories);

            }
            else if (ucreceiptOfPurchaseInvoice != null)
            {
                //ucreceiptOfPurchaseInvoice.ChangeCategoryIdEvent(idCatigories);

            }
            else if (ucPackageOfItems != null)
            {
                ucPackageOfItems.ChangeCategoryIdEvent(idCatigories);

            }


        }

        
        private void INotifyPropertyChangedIdCatigorieItems()
        {

             if (ucItem != null)
            {
                ucItem.ChangeItemIdEvent(idItem);
            }
            else if (ucPayInvoice != null)
            {
                ucPayInvoice.ChangeItemIdEvent(idItem);

            }
            else if (ucItemsImport != null)
            {
                ucItemsImport.ChangeItemIdEvent(idItem);

            }
            else if (ucItemsExport != null)
            {
                ucItemsExport.ChangeItemIdEvent(idItem);

            }
            else if (ucreceiptOfPurchaseInvoice != null)
            {
                //ucreceiptOfPurchaseInvoice.ChangeItemIdEvent(idItem);

            }
            else if (ucPackageOfItems != null)
            {
                ucPackageOfItems.ChangeItemIdEvent(idItem);

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
                FN_createCatalogCard( item,  row , column , columnCount);
                if(column != -1)
                {
                    column++;
                    if (column == columnCount)
                    {
                        column = 0;
                        row++;
                    }
                }
                else
                {
                    column++;
                }
              
            }
        }

        public UC_squareCard FN_createCatalogCard( Category category,  int row, int column, int columnCount,   string BorderBrush = "#6e6e6e")
        {
            UC_squareCard uc = new UC_squareCard(category);
            uc.ContentId = category.categoryId;
            uc.squareCardText = category.name;
            uc.squareCardBorderBrush = BorderBrush;
            //uc.squareCardImageSource = image;
            uc.Margin = new Thickness(5, 0, 5, 0);
            uc.Tag = "categorie" + category.categoryId;
            uc.Name = "categorie" + category.categoryId;
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
            UC_squareCard uc = (UC_squareCard)sender;
            uc = gridCatigories.Children.OfType<UC_squareCard>().Where(x => x.Name.ToString() == "categorie" + uc.ContentId).FirstOrDefault();

            gridCatigories.Children.Remove(uc);
            
            FN_createCatalogCard( uc.category, uc.Row, uc.Column, uc.columnCount,   "#178DD2");


            if (pastCatalogCard != -1 && pastCatalogCard != uc.ContentId)
            {
                var pastUc = new UC_squareCard() { ContentId = pastCatalogCard };
                pastUc = gridCatigories.Children.OfType<UC_squareCard>().Where(x => x.Name.ToString() == "categorie" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigories.Children.Remove(pastUc);
                    FN_createCatalogCard( pastUc.category, pastUc.Row, pastUc.Column, pastUc.columnCount,
                     "#6e6e6e");
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
            string isNewString = "";
            foreach (var item in items)
            {
                //Visible
                //    Collapsed
                if (item.isNew == 1)
                    isNewString = "Visible";
                else isNewString = "Collapsed";

                if (cardType == "sale")
                {
                    if (language == "ar")
                        FN_createCatalogItem_ar(item, "0$",  row, column, isNewString, "Collapsed");
                    else FN_createCatalogItem(item  , "0$", row, column, isNewString, "Collapsed");
                }
                else
                {
                    if (language == "ar")
                        FN_createCatalogItemtWithoutPrice_ar(item, "0$", row, column, isNewString, "Collapsed");
                    else
                        FN_createCatalogItemtWithoutPrice(item, "0$",  row, column, isNewString, "Collapsed");
                }

                
                column++;
                if (column == 3)
                {
                    column = 0;
                    row++;
                }
            }




        }
        #region 
        /*
        //UC_rectangleCardPrice
        //UC_rectangleCardPrice_ar
        //UC_rectangleCardWithoutPrice
        //UC_rectangleCardWithoutPrice_ar

        UC_rectangleCardPrice FN_createCatalogItem( int id, string title, string subtitle, string price, string image, int row, int column,
           string newItem, string offer, string cardType, string BorderBrush = "#6e6e6e")
        {
            UC_rectangleCardPrice uc;
            if (cardType == "CatalogItem_ar")
            {
                uc = new UC_rectangleCardPrice();
            }
            else if (cardType == "CatalogItem")
            {
                uc = new UC_rectangleCardPrice();
            }
            else if (cardType == "CatalogItemtWithoutPrice_ar")
            {
                uc = new UC_rectangleCardPrice();
            }
            else
            {
                uc = new UC_rectangleCardPrice();
            }
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
            UC_rectangleCardPrice uc;
            if (sender.GetType().ToString() == "UC_rectangleCardPrice")
            {
                 uc = (UC_rectangleCardPrice)sender;
            }
            uc = gridCatigorieItems.Children.OfType<UC_rectangleCardPrice>().Where(x => x.Name.ToString() == "CategorieItems" + uc.ContentId).FirstOrDefault();

            gridCatigorieItems.Children.Remove(uc);
            FN_createCatalogItem(uc.ContentId, uc.rectangleCardPriceTitleText, uc.rectangleCardPriceSubtitleText, uc.rectangleCardPricePriceTitle, uc.rectangleCardPriceImageSource, uc.Row, uc.Column,
               uc.rectangleCardPriceNew, uc.rectangleCardPriceOffer, "#178DD2");
            if (pastCatalogItem != -1 && pastCatalogItem != uc.ContentId)
            {
                UC_rectangleCardPrice pastUc;
                if (true)
                {
                     pastUc = new UC_rectangleCardPrice() { ContentId = pastCatalogItem };
                }
               
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCardPrice>().Where(x => x.Name.ToString() == "CategorieItems" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createCatalogItem(pastUc.ContentId, pastUc.rectangleCardPriceTitleText, pastUc.rectangleCardPriceSubtitleText, pastUc.rectangleCardPricePriceTitle
                        , pastUc.rectangleCardPriceImageSource, pastUc.Row, pastUc.Column, pastUc.rectangleCardPriceNew, pastUc.rectangleCardPriceOffer, "#6e6e6e");
                }
            }
            pastCatalogItem = uc.ContentId;
            idItem = uc.ContentId;
        }
        */
        #endregion
     
        #region  sale
        #region En
        UC_rectangleCardPrice FN_createCatalogItem(Item item, string price,  int row, int column,
           string newItem, string offer, string BorderBrush = "#6e6e6e")
        {

            UC_rectangleCardPrice uc = new UC_rectangleCardPrice(item);
            uc.ContentId = item.itemId;
            uc.rectangleCardPriceTitleText = item.name;
            uc.rectangleCardPriceSubtitleText = item.details;
            uc.rectangleCardPriceBorderBrush = BorderBrush;
            uc.rectangleCardPricePriceTitle = price;
            uc.rectangleCardPriceNew = newItem;
            uc.rectangleCardPriceOffer = offer;
            uc.Tag = "CategorieItems" + item.itemId; 
            uc.Name = "CategorieItems" + item.itemId;
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
            FN_createCatalogItem(uc.item, uc.rectangleCardPricePriceTitle, uc.Row, uc.Column,
               uc.rectangleCardPriceNew, uc.rectangleCardPriceOffer,  "#178DD2");
            if (pastCatalogItem != -1 && pastCatalogItem != uc.ContentId )
            {
                var pastUc = new UC_rectangleCardPrice() { ContentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCardPrice>().Where(x => x.Name.ToString() == "CategorieItems" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null )
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createCatalogItem(pastUc.item, pastUc.rectangleCardPricePriceTitle
                        ,  pastUc.Row, pastUc.Column, pastUc.rectangleCardPriceNew, pastUc.rectangleCardPriceOffer,  "#6e6e6e");
                }
            }
            pastCatalogItem = uc.ContentId;
            idItem = uc.ContentId;
        }
        #endregion
        #region Ar
        UC_rectangleCardPrice_ar FN_createCatalogItem_ar(Item item, string price, int row, int column,
           string newItem, string offer, string BorderBrush = "#6e6e6e")
        {
        
            UC_rectangleCardPrice_ar uc = new UC_rectangleCardPrice_ar(item);
            uc.ContentId = item.itemId;
            uc.rectangleCardPriceTitleText_ar = item.name;
            uc.rectangleCardPriceSubtitleText_ar = item.details;
            uc.rectangleCardPriceBorderBrush_ar = BorderBrush;
            uc.rectangleCardPricePriceTitle_ar = price;
            uc.rectangleCardPriceNew_ar = newItem;
            uc.rectangleCardPriceOffer_ar = offer;
            uc.Tag = "CategorieItems" + item.itemId;
            uc.Name = "CategorieItems" + item.itemId;
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
            FN_createCatalogItem_ar(uc.item, uc.rectangleCardPricePriceTitle_ar,
                 uc.Row, uc.Column,
               uc.rectangleCardPriceNew_ar, uc.rectangleCardPriceOffer_ar, "#178DD2");
            if (pastCatalogItem != -1 && pastCatalogItem != uc.ContentId)
            {
                var pastUc = new UC_rectangleCardPrice_ar() { ContentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCardPrice_ar>().Where(x => x.Name.ToString() == "CategorieItems" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createCatalogItem_ar(pastUc.item, pastUc.rectangleCardPricePriceTitle_ar
                        , pastUc.Row, pastUc.Column, pastUc.rectangleCardPriceNew_ar, pastUc.rectangleCardPriceOffer_ar, "#6e6e6e");
                }
            }
            pastCatalogItem = uc.ContentId;
            idItem = uc.ContentId;
        }

        #endregion
        #endregion
        #region purchase

        #region  En
        UC_rectangleCardWithoutPrice FN_createCatalogItemtWithoutPrice(Item item, string price, int row, int column,
           string newItem, string offer, string BorderBrush = "#6e6e6e")
        {

        
            UC_rectangleCardWithoutPrice uc = new UC_rectangleCardWithoutPrice(item);
            uc.ContentId = item.itemId;
            uc.rectangleCardWithoutPriceTitleText = item.name;
            uc.rectangleCardWithoutPriceSubtitleText = item.details;
            uc.rectangleCardWithoutPriceBorderBrush = BorderBrush;
            uc.rectangleCardWithoutPriceWithoutPriceTitle = price;
            uc.rectangleCardWithoutPriceNew = newItem;
            uc.rectangleCardWithoutPriceOffer = offer;
            uc.Tag = "CategorieItems" + item.itemId;
            uc.Name = "CategorieItems" + item.itemId;
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
            FN_createCatalogItemtWithoutPrice(uc.item, uc.rectangleCardWithoutPriceWithoutPriceTitle,   uc.Row, uc.Column,
               uc.rectangleCardWithoutPriceNew, uc.rectangleCardWithoutPriceOffer, "#178DD2");
            if (pastCatalogItem != -1 && pastCatalogItem != uc.ContentId)
            {
                var pastUc = new UC_rectangleCardWithoutPrice() { ContentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCardWithoutPrice>().Where(x => x.Name.ToString() == "CategorieItems" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createCatalogItemtWithoutPrice(pastUc.item, pastUc.rectangleCardWithoutPriceWithoutPriceTitle
                        , pastUc.Row, pastUc.Column, pastUc.rectangleCardWithoutPriceNew, pastUc.rectangleCardWithoutPriceOffer, "#6e6e6e");
                }
            }
            pastCatalogItem = uc.ContentId;
            idItem = uc.ContentId;
        }
        #endregion
        #region  Ar
        UC_rectangleCardWithoutPrice_ar FN_createCatalogItemtWithoutPrice_ar(Item item, string price, int row, int column,
           string newItem, string offer, string BorderBrush = "#6e6e6e")
        {
        
            UC_rectangleCardWithoutPrice_ar uc = new UC_rectangleCardWithoutPrice_ar(item);
            uc.ContentId = item.itemId;
            uc.rectangleCardWithoutPriceTitleText_ar = item.name;
            uc.rectangleCardWithoutPriceSubtitleText_ar = item.details;
            uc.rectangleCardWithoutPriceBorderBrush_ar = BorderBrush;
            uc.rectangleCardWithoutPriceWithoutPriceTitle_ar = price;
            uc.rectangleCardWithoutPriceNew_ar = newItem;
            uc.rectangleCardWithoutPriceOffer_ar = offer;
            uc.Tag = "CategorieItems" + item.itemId;
            uc.Name = "CategorieItems" + item.itemId;
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
            FN_createCatalogItemtWithoutPrice_ar(uc.item, uc.rectangleCardWithoutPriceWithoutPriceTitle_ar, 
                uc.Row, uc.Column,
               uc.rectangleCardWithoutPriceNew_ar, uc.rectangleCardWithoutPriceOffer_ar, "#178DD2");
            if (pastCatalogItem != -1 && pastCatalogItem != uc.ContentId)
            {
                var pastUc = new UC_rectangleCardWithoutPrice_ar() { ContentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCardWithoutPrice_ar>().Where(x => x.Name.ToString() == "CategorieItems" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createCatalogItemtWithoutPrice_ar(pastUc.item,pastUc.rectangleCardWithoutPriceWithoutPriceTitle_ar
                       , pastUc.Row, pastUc.Column, pastUc.rectangleCardWithoutPriceNew_ar, pastUc.rectangleCardWithoutPriceOffer_ar, "#6e6e6e");
                }
            }
            pastCatalogItem = uc.ContentId;
            idItem = uc.ContentId;
        }
        #endregion


        #endregion
        
        #endregion



    }
}

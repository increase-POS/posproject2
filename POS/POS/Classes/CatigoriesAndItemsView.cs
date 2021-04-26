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

        public uc_categorie ucCategorie;
        public UC_item ucCategorieItem;
        public uc_payInvoice ucPayInvoice;
        public uc_receiptInvoice ucReceiptInvoice;

        public Grid gridCatigories;
        public Grid gridCatigorieItems;
        private int _idCatigories;
        private int _idCatigorieItems;
        private int _idPayInvoice;
        private int _idReceipInvoice;
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

        public int idReceipInvoice
        {
            get => _idReceipInvoice; set
            {

                _idReceipInvoice = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        private void INotifyPropertyChangedIdCatigories()
        {
            if (ucCategorie != null)
            {
                ucCategorie.testChangeCategorieIdEvent();

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
        


        public void FN_refrishCatalogCard(List<Categorie> categories )
        {
            gridCatigories.Children.Clear();
            int column = 0;
            foreach (var item in categories)
            {
                 FN_createCatalogCard(item.categoryId, item.name, item.image, column, 1);
                column++;
            }
        }
        public UC_squareCard FN_createCatalogCard(int id, string name, string image, int column, int row , string BorderBrush = "#6e6e6e")
        {
            UC_squareCard uc = new UC_squareCard();
            uc.ContentId = id;
            uc.squareCardText = name;
            uc.squareCardBorderBrush = BorderBrush;
            uc.squareCardImageSource = image;
            uc.Margin = new Thickness(5, 0, 5, 0);
            uc.Tag = "categorie" + id;
            uc.Name = "categorie" + id;
            uc.Column = column;
            uc.Row = row;
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
            FN_createCatalogCard(uc.ContentId, uc.squareCardText, uc.squareCardImageSource, uc.Column, 1, "#178DD2");


            if (pastCatalogCard != -1)
            {
                var pastUc = new UC_squareCard() { ContentId = pastCatalogCard };
                pastUc = gridCatigories.Children.OfType<UC_squareCard>().Where(x => x.Name.ToString() == "categorie" + pastUc.ContentId).FirstOrDefault();
                gridCatigories.Children.Remove(pastUc);
                FN_createCatalogCard(pastUc.ContentId, pastUc.squareCardText, pastUc.squareCardImageSource, pastUc.Column, 1, "#6e6e6e");
            }

            pastCatalogCard = uc.ContentId;
            idCatigories = uc.ContentId;
        }
        #endregion
        #region Catalog Items
        private int pastCatalogItem = -1;
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
        public void FN_refrishCatalogItem(List<CategorieItem> CategorieItems)
        {
            gridCatigorieItems.Children.Clear();
            //CategorieItem CategorieItem = new CategorieItem();
            //var CategorieItems = CategorieItem.getCategorieItems();
            int row = 0;
            int column = 0;
            foreach (var item in CategorieItems)
            {
                FN_createCatalogItem(item.CategorieItemsId, item.title, item.subtitle
                   , item.price, item.image, row, column, item.New, item.isOffer);
                row++;
                if (row == 3)
                {
                    row = 0;
                    column++;
                }
            }




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
                gridCatigorieItems.Children.Remove(pastUc);
                FN_createCatalogItem(pastUc.ContentId, pastUc.rectangleCardPriceTitleText, pastUc.rectangleCardPriceSubtitleText, pastUc.rectangleCardPricePriceTitle
                    , pastUc.rectangleCardPriceImageSource, pastUc.Row, pastUc.Column, pastUc.rectangleCardPriceNew, pastUc.rectangleCardPriceOffer, "#6e6e6e");
            }
            pastCatalogItem = uc.ContentId;
            idCatigorieItems = uc.ContentId;
        }
        #endregion



    }
}

using POS.Classes;
using POS.controlTemplate;
using POS.View;
using POS.View.storage;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        //public uc_itemsImport ucItemsImport;
        public uc_itemsExport ucItemsExport;
        public uc_itemsDestroy ucItemsDestroy;
        public uc_receiptOfPurchaseInvoice ucreceiptOfPurchaseInvoice;
        public uc_packageOfItems ucPackageOfItems;
        public UC_users ucUsers;
        public UC_vendors ucVendors;
        public UC_Customer ucCustomer;
        public wd_items wdItems;

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
        private int _idUsers;
        private int _idCustomer;
        private int _idVendors;
        private int _idwdItems;
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
        public int idUsers
        {
            get => _idUsers; set
            {

                _idUsers = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        public int idCustomer
        {
            get => _idCustomer; set
            {

                _idCustomer = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        public int idVendors
        {
            get => _idVendors; set
            {

                _idVendors = value;
                INotifyPropertyChangedIdCatigorieItems();
            }
        }
        public int idwdItems
        {
            get => _idwdItems; set
            {

                _idwdItems = value;
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
            //else if (ucItemsImport != null)
            //{
            //    ucItemsImport.ChangeCategoryIdEvent(idCatigories);

            //}
            else if (ucItemsExport != null)
            {
                ucItemsExport.ChangeCategoryIdEvent(idCatigories);

            }
            else if (ucItemsDestroy != null)
            {
                //ucItemsDestroy.ChangeCategoryIdEvent(idCatigories);

            }
            else if (ucreceiptOfPurchaseInvoice != null)
            {
                //ucreceiptOfPurchaseInvoice.ChangeCategoryIdEvent(idCatigories);

            }
            else if (ucPackageOfItems != null)
            {
                ucPackageOfItems.ChangeCategoryIdEvent(idCatigories);

            }
            else if (wdItems != null)
            {
                wdItems.ChangeCategoryIdEvent(idCatigories);

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
            //else if (ucItemsImport != null)
            //{
            //    ucItemsImport.ChangeItemIdEvent(idItem);

            //}
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
            else if (ucUsers != null)
            {
                ucUsers.ChangeItemIdEvent(idItem);

            }
            else if (ucCustomer != null)
            {
                ucCustomer.ChangeItemIdEvent(idItem);

            }
            else if (ucVendors != null)
            {
                ucVendors.ChangeItemIdEvent(idItem);

            }
            else if (wdItems != null)
            {
                wdItems.ChangeItemIdEvent(idItem);

            }
        }
        #region Catalog
        public int pastCatalogCard = -1;
         /// ////////////////////drag and drop///////////////////////////////////////
        List<Category> newCategories = new List<Category>();
        List<Categoryuser> categoriesUser = new List<Categoryuser>();
        int _columnCount , index = 0 ;
        Category category = new Category();
        Category categoryModel = new Category();
        Categoryuser categorUserModel = new Categoryuser();
        /// ////////////////////////////////////////////////////////////
       
        public void FN_refrishCatalogCard(List<Category> categories ,int columnCount)
        {
            gridCatigories.Children.Clear();
            int row = 0;
            int column = 0;

            //int[] count = categoriesRowColumnCount(1, columnCount);
            //if (columnCount == -1)
            //    count[1] = -1;
                foreach (var item in categories)
            {
                #region
                /* Orginal Cod
               FN_createCatalogCard(item, row, column, columnCount);
               if (column != -1)
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
               */
                #endregion

                CardViewItems itemCardView = new CardViewItems();
                itemCardView.category = item;
                itemCardView.row = row;
                itemCardView.column = column;
                newCategories = categories;
                _columnCount = columnCount;
                FN_createCatalogCard(itemCardView, columnCount);



                if (column != -1)
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

        public UC_squareCard FN_createCatalogCard(CardViewItems categoryCardView, int columnCount,   string BorderBrush = "#DFDFDF")
        {
            UC_squareCard uc = new UC_squareCard(categoryCardView);
            uc.ContentId = categoryCardView.category.categoryId;
            //uc.squareCardText = categoryCardView.category.name;
            uc.squareCardBorderBrush = BorderBrush;
            //uc.squareCardImageSource = image;
            uc.Margin = new Thickness(5, 0, 5, 0);
            //uc.Tag = "categorie" + categoryCardView.category.categoryId;
            uc.Name = "categorie" + categoryCardView.category.categoryId;
            //uc.Row = row;
            //uc.Column = column;
            //uc.rowCount = rowCount;
            uc.columnCount = columnCount;
            Grid.SetColumn(uc, categoryCardView.column);
            Grid.SetRow(uc, categoryCardView.row);
            //uc.Tag = "1";
            gridCatigories.Children.Add(uc);
            uc.MouseDoubleClick += new MouseButtonEventHandler(catalogCard_MouseDoubleClick);
            //uc.MouseEnter += new MouseEventHandler(UserControl_MouseEnter);
            //////////////////darg and drop////////////////////
            uc.AllowDrop = true;
            uc.MouseDown += this.ucMouseDown;
            uc.DragEnter += this.ucDragEnter;
            uc.Drop += this.ucDrop;
            ////////////////////////////////////////////////////
            return uc;
        }
      
        ////////////////darg and drop events/////////////////////
        private async void ucDrop(object sender, DragEventArgs e)
        {

            try
            {
                //get dropped id
                int curIndex = newCategories.FindIndex(c => c.categoryId == (sender as UC_squareCard).ContentId);
            //get dropped category
            category = await categoryModel.GetCategoryByID((sender as UC_squareCard).ContentId);
            //get dragged category
            Category dragedCategory = await categoryModel.GetCategoryByID(Convert.ToInt32(e.Data.GetData(DataFormats.Text , true)));
            //set dropped category
            newCategories[curIndex] = dragedCategory;
            //set dragged category
            newCategories[index] = category;
            FN_refrishCatalogCard(newCategories , _columnCount);
            int i = 0;
            foreach(var c in newCategories)
            {
                i++;
                Categoryuser catUser = new Categoryuser();
                catUser.id = c.id.Value;
                catUser.userId = MainWindow.userID.Value;
                catUser.categoryId = c.categoryId;
                catUser.sequence = i;
                categoriesUser.Add(catUser);
            }
                //await categorUserModel.UpdateCatUserList(MainWindow.userID.Value, categoriesUser);


            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void ucDragEnter(object sender, DragEventArgs e)
            {
                try
                {
                    e.Effects = DragDropEffects.Copy;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
       
        private void ucMouseDown(object sender, MouseButtonEventArgs e)
                {
                    try
                    {
                        if (e.LeftButton == MouseButtonState.Pressed)
            {
                //get dragged id
                index = newCategories.FindIndex(c => c.categoryId == (sender as UC_squareCard).ContentId);
                DragDrop.DoDragDrop(sender as UC_squareCard, (sender as UC_squareCard).ContentId.ToString(), DragDropEffects.All);
              
            }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        ////////////////////////////////////////////////////////////
        void catalogCard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
                    {
                        try
                        {
                            UC_squareCard uc = (UC_squareCard)sender;
            uc = gridCatigories.Children.OfType<UC_squareCard>().Where(x => x.Name.ToString() == "categorie" + uc.categoryCardView.category.categoryId).FirstOrDefault();

            gridCatigories.Children.Remove(uc);
            
            FN_createCatalogCard( uc.categoryCardView, uc.columnCount,   "#178DD2");


            if (pastCatalogCard != -1 && pastCatalogCard != uc.categoryCardView.category.categoryId)
            {
                var pastUc = new UC_squareCard() { ContentId = pastCatalogCard };
                pastUc = gridCatigories.Children.OfType<UC_squareCard>().Where(x => x.Name.ToString() == "categorie" + pastUc.ContentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigories.Children.Remove(pastUc);
                    FN_createCatalogCard( pastUc.categoryCardView, pastUc.columnCount,
                     "#DFDFDF");
                }
            }
            
            pastCatalogCard = uc.categoryCardView.category.categoryId;
            idCatigories = uc.categoryCardView.category.categoryId;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        #endregion
        #region Catalog Items


        private int pastCatalogItem = -1;
        internal uc_receiptInvoice ucReceiptInvoice;

        //static public int[] itemsRowColumnCount(int rowCount, int columnCount)
        //{
        //    //MainWindow.ucControlViewSectionWidth
        //    //MainWindow.ucControlViewSectionHeight

        //    //row
        //    if (MainWindow.windowHeight < 630)
        //        rowCount = 1;
        //    else if(MainWindow.windowHeight < 760)
        //        rowCount = 2;
        //    else if (MainWindow.windowHeight >= 760 || MainWindow.windowHeight.ToString() == "NaN" || MainWindow.windowWidth.ToString() == "ليس رقمًا")
        //        rowCount = 3;
        //    else
        //        rowCount = 1;


        //    // column
        //    if (MainWindow.windowWidth < 970)
        //        columnCount = 1;
        //    else if (MainWindow.windowWidth < 1340)
        //        columnCount = 2;
        //    else if (MainWindow.windowWidth >= 1340 || MainWindow.windowWidth.ToString() == "NaN" || MainWindow.windowWidth.ToString() == "ليس رقمًا")
        //        columnCount = 3;
        //    else
        //        columnCount = 1;



        //    int[] count = { rowCount, columnCount, rowCount * columnCount };
        //    return count;
        //}
        public void  FN_refrishCatalogItem(List<Item> items, string language, string cardType)
        {
            gridCatigorieItems.Children.Clear();
            int row = 0;
            int column = 0;
            foreach (var item in items)
            {

                CardViewItems itemCardView = new CardViewItems();
                itemCardView.item = item;
                itemCardView.cardType = cardType;
                itemCardView.language = language;
                itemCardView.row = row;
                itemCardView.column = column;
                FN_createRectangelCard(itemCardView);
               

                column++;
                if (column == 3)
                {
                    column = 0;
                    row++;
                }
            }
        }
        UC_rectangleCard FN_createRectangelCard(CardViewItems itemCardView, string BorderBrush = "#DFDFDF")
        {
            UC_rectangleCard uc = new UC_rectangleCard(itemCardView);
            uc.rectangleCardBorderBrush = BorderBrush;
            uc.Name = "CardName" + itemCardView.item.itemId;
            Grid.SetRow(uc, itemCardView.row);
            Grid.SetColumn(uc, itemCardView.column);
            gridCatigorieItems.Children.Add(uc);
            uc.MouseDoubleClick += new MouseButtonEventHandler(rectangleCardView_MouseDoubleClick);
            return uc;
        }
        void rectangleCardView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                UC_rectangleCard uc = (UC_rectangleCard)sender;
            uc = gridCatigorieItems.Children.OfType<UC_rectangleCard>().Where(x => x.Name.ToString() == "CardName" + uc.cardViewitem.item.itemId).FirstOrDefault();

            gridCatigorieItems.Children.Remove(uc);
            FN_createRectangelCard(uc.cardViewitem, "#178DD2");
            if (pastCatalogItem != -1 && pastCatalogItem != uc.cardViewitem.item.itemId)
            {
                var pastUc = new UC_rectangleCard() { contentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCard>().Where(x => x.Name.ToString() == "CardName" + pastUc.contentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createRectangelCard(pastUc.cardViewitem, "#DFDFDF");
                }
            }
            pastCatalogItem = uc.cardViewitem.item.itemId;
            idItem = uc.cardViewitem.item.itemId;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        #region User
        public void FN_refrishUsers(List<User> users, string language, string cardType)
        {
            gridCatigorieItems.Children.Clear();
            int row = 0;
            int column = 0;
            foreach (var item in users)
            {

                CardViewItems itemCardView = new CardViewItems();
                itemCardView.user = item;
                itemCardView.cardType = cardType;
                itemCardView.language = language;
                itemCardView.row = row;
                itemCardView.column = column;
                FN_createRectangelCardUsers(itemCardView);


                column++;
                if (column == 3)
                {
                    column = 0;
                    row++;
                }
            }
        }
        UC_rectangleCard FN_createRectangelCardUsers(CardViewItems itemCardView, string BorderBrush = "#DFDFDF")
        {
            UC_rectangleCard uc = new UC_rectangleCard(itemCardView);
            uc.rectangleCardBorderBrush = BorderBrush;
            uc.Name = "CardName" + itemCardView.user.userId;
            Grid.SetRow(uc, itemCardView.row);
            Grid.SetColumn(uc, itemCardView.column);
            gridCatigorieItems.Children.Add(uc);
            uc.MouseDoubleClick += new MouseButtonEventHandler(rectangleCardViewUsers_MouseDoubleClick);
            return uc;
        }
        void rectangleCardViewUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    UC_rectangleCard uc = (UC_rectangleCard)sender;
            uc = gridCatigorieItems.Children.OfType<UC_rectangleCard>().Where(x => x.Name.ToString() == "CardName" + uc.cardViewitem.user.userId).FirstOrDefault();

            gridCatigorieItems.Children.Remove(uc);
            FN_createRectangelCardUsers(uc.cardViewitem, "#178DD2");
            if (pastCatalogItem != -1 && pastCatalogItem != uc.cardViewitem.user.userId)
            {
                var pastUc = new UC_rectangleCard() { contentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCard>().Where(x => x.Name.ToString() == "CardName" + pastUc.contentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createRectangelCardUsers(pastUc.cardViewitem, "#DFDFDF");
                }
            }
            pastCatalogItem = uc.cardViewitem.user.userId;
            idItem = uc.cardViewitem.user.userId;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        #endregion
        #region Agent
        public void FN_refrishAgents(List<Agent> agents, string language, string cardType)
        {
            gridCatigorieItems.Children.Clear();
            int row = 0;
            int column = 0;
            foreach (var item in agents)
            {

                CardViewItems itemCardView = new CardViewItems();
                itemCardView.agent = item;
                itemCardView.cardType = cardType;
                itemCardView.language = language;
                itemCardView.row = row;
                itemCardView.column = column;
                FN_createRectangelCardAgents(itemCardView);


                column++;
                if (column == 3)
                {
                    column = 0;
                    row++;
                }
            }
        }
        UC_rectangleCard FN_createRectangelCardAgents(CardViewItems itemCardView, string BorderBrush = "#DFDFDF")
        {
            UC_rectangleCard uc = new UC_rectangleCard(itemCardView);
            uc.rectangleCardBorderBrush = BorderBrush;
            uc.Name = "CardName" + itemCardView.agent.agentId;
            Grid.SetRow(uc, itemCardView.row);
            Grid.SetColumn(uc, itemCardView.column);
            gridCatigorieItems.Children.Add(uc);
            uc.MouseDoubleClick += new MouseButtonEventHandler(rectangleCardViewAgents_MouseDoubleClick);
            return uc;
        }
        void rectangleCardViewAgents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
                {
                    try
                    {
                        UC_rectangleCard uc = (UC_rectangleCard)sender;
            uc = gridCatigorieItems.Children.OfType<UC_rectangleCard>().Where(x => x.Name.ToString() == "CardName" + uc.cardViewitem.agent.agentId).FirstOrDefault();

            gridCatigorieItems.Children.Remove(uc);
            FN_createRectangelCardAgents(uc.cardViewitem, "#178DD2");
            if (pastCatalogItem != -1 && pastCatalogItem != uc.cardViewitem.agent.agentId)
            {
                var pastUc = new UC_rectangleCard() { contentId = pastCatalogItem };
                pastUc = gridCatigorieItems.Children.OfType<UC_rectangleCard>().Where(x => x.Name.ToString() == "CardName" + pastUc.contentId).FirstOrDefault();
                if (pastUc != null)
                {
                    gridCatigorieItems.Children.Remove(pastUc);
                    FN_createRectangelCardAgents(pastUc.cardViewitem, "#DFDFDF");
                }
            }
            pastCatalogItem = uc.cardViewitem.agent.agentId;
            idItem = uc.cardViewitem.agent.agentId;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        #endregion
        /*
        #region  sale
        #region En
        UC_rectangleCardPrice FN_createCatalogItem(Item item, string price,  int row, int column,
           string newItem, string offer, string BorderBrush = "#DFDFDF")
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
                        ,  pastUc.Row, pastUc.Column, pastUc.rectangleCardPriceNew, pastUc.rectangleCardPriceOffer,  "#DFDFDF");
                }
            }
            pastCatalogItem = uc.ContentId;
            idItem = uc.ContentId;
        }
        #endregion
        #region Ar
        UC_rectangleCardPrice_ar FN_createCatalogItem_ar(Item item, string price, int row, int column,
           string newItem, string offer, string BorderBrush = "#DFDFDF")
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
                        , pastUc.Row, pastUc.Column, pastUc.rectangleCardPriceNew_ar, pastUc.rectangleCardPriceOffer_ar, "#DFDFDF");
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
           string newItem, string offer, string BorderBrush = "#DFDFDF")
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
                        , pastUc.Row, pastUc.Column, pastUc.rectangleCardWithoutPriceNew, pastUc.rectangleCardWithoutPriceOffer, "#DFDFDF");
                }
            }
            pastCatalogItem = uc.ContentId;
            idItem = uc.ContentId;
        }
        #endregion
        #region  Ar
        UC_rectangleCardWithoutPrice_ar FN_createCatalogItemtWithoutPrice_ar(Item item, string price, int row, int column,
           string newItem, string offer, string BorderBrush = "#DFDFDF")
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
                       , pastUc.Row, pastUc.Column, pastUc.rectangleCardWithoutPriceNew_ar, pastUc.rectangleCardWithoutPriceOffer_ar, "#DFDFDF");
                }
            }
            pastCatalogItem = uc.ContentId;
            idItem = uc.ContentId;
        }
        #endregion


        #endregion
        */
        #endregion



    }
}

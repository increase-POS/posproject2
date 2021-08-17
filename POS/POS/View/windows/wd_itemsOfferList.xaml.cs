﻿using POS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_itemsOfferList.xaml
    /// </summary>
    public partial class wd_itemsOfferList : Window
    {
        public wd_itemsOfferList()
        {
            InitializeComponent();
        }
        public bool isActive;

        ItemUnitOffer itemUnitOffer = new ItemUnitOffer();
        ItemUnit itemModel = new ItemUnit();
        ItemUnitOffer itemUnitOfferModel = new ItemUnitOffer();
        Offer offerModel = new Offer();

        List<ItemUnit> allItems = new List<ItemUnit>();
        List<ItemUnitOffer> selectedItems = new List<ItemUnitOffer>();

        List<ItemUnit> allItemsSource = new List<ItemUnit>();
        List<ItemUnitOffer> selectedItemsSource = new List<ItemUnitOffer>();

        ItemUnit itemUnit = new ItemUnit();
        Offer offer = new Offer();

        string searchText = "";

        public string txtItemSearch;

        IEnumerable<ItemUnit> itemUnitQuery;

        public int offerId { get; set; }
        /// <summary>
        /// Selcted Items if selectedItems Have Items At the beginning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            SectionData.StartAwait(grid_mainGrid);
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_offerList.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_offerList.FlowDirection = FlowDirection.RightToLeft; }

            translat();

            offer = await offerModel.getOfferById(offerId);
            
            allItemsSource = await itemModel.Getall();
            selectedItemsSource = await itemUnitOffer.GetItemsByOfferId(offerId);

            allItems.AddRange(allItemsSource);

            foreach (var i in allItems)
            {
                i.itemName = i.itemName + "-" + i.unitName;
            }

            selectedItems.AddRange(selectedItemsSource);
            foreach (var i in selectedItems)
            {
                i.itemName = i.itemName + "-" + i.unitName;
            }
            //remove selected items from all items
            foreach (var i in selectedItems)
            {
                itemUnit = allItemsSource.Where(s => s.itemUnitId == i.iuId).FirstOrDefault<ItemUnit>();
                allItems.Remove(itemUnit);
            }

            dg_allItems.ItemsSource = allItems;
            dg_allItems.SelectedValuePath = "itemUnitId";
            dg_allItems.DisplayMemberPath = "itemName";

            dg_selectedItems.ItemsSource = selectedItems;
            dg_selectedItems.SelectedValuePath = "itemUnitId";
            dg_selectedItems.DisplayMemberPath = "itemName";

            SectionData.EndAwait(grid_mainGrid,this);
        }

        private void translat()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_searchitems, MainWindow.resourcemanager.GetString("trSearchHint"));

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

            dg_allItems.Columns[0].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_selectedItems.Columns[0].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_selectedItems.Columns[1].Header = MainWindow.resourcemanager.GetString("trQuantity");

            txt_title.Text = MainWindow.resourcemanager.GetString("trOffer");
            txt_items.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_selectedItems.Text = MainWindow.resourcemanager.GetString("trSelectedItems");

            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_selectAllItem.Content = MainWindow.resourcemanager.GetString("trSelectAllItems");
            tt_unselectAllItem.Content = MainWindow.resourcemanager.GetString("trUnSelectAllItems");
            tt_selectItem.Content = MainWindow.resourcemanager.GetString("trSelectOneItem");
            tt_unselectItem.Content = MainWindow.resourcemanager.GetString("trUnSelectOneItem");

        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
           
            //DataRowView dataRow = (DataRowView)dg_selectedItems.SelectedItem;
            //int index = dg_selectedItems.CurrentCell.Column.DisplayIndex;
            //string cellValue = dataRow.Row.ItemArray[index].ToString();

            string s = await itemUnitOfferModel.updategroup(offerId, selectedItems, MainWindow.userID.Value);

            isActive = true;
            this.Close();
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            this.Close();
        }
        private void Dg_allItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Btn_selectedItem_Click(null, null);

        }
        private void Dg_selectedItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_unSelectedItem_Click(null, null);

        }
        private async void Btn_selectedAll_Click(object sender, RoutedEventArgs e)
        {//select all
            int x = allItems.Count;
            for (int i = 0; i < x; i++)
            {
                //MessageBox.Show(i.ToString());
                dg_allItems.SelectedIndex = 0;
                Btn_selectedItem_Click(null, null);
            }
        }
        private void Btn_selectedItem_Click(object sender, RoutedEventArgs e)
        {//select item
            itemUnit = dg_allItems.SelectedItem as ItemUnit;
            if (itemUnit != null)
            {
                ItemUnitOffer iUO = new ItemUnitOffer();
                iUO.ioId = 0;
                iUO.iuId = itemUnit.itemUnitId;
                iUO.offerId = offerId;
                iUO.createUserId = MainWindow.userID;
                iUO.quantity = 0;//dg_selectedItems.Columns[1];
                iUO.offerName = offer.name;
                iUO.unitName = itemUnit.unitName;
                iUO.itemName = itemUnit.itemName;
                //iUO.code = offer.code;///////////??????????offer/item
                iUO.itemId = itemUnit.itemId;
                iUO.unitId = itemUnit.unitId;

                allItems.Remove(itemUnit);
                selectedItems.Add(iUO);

                dg_allItems.ItemsSource = allItems;
                dg_selectedItems.ItemsSource = selectedItems;

                dg_allItems.Items.Refresh();
                dg_selectedItems.Items.Refresh();
            }

        }
        private void Btn_unSelectedItem_Click(object sender, RoutedEventArgs e)
        {//unselect item
            itemUnitOffer = dg_selectedItems.SelectedItem as ItemUnitOffer;
            ItemUnit i = new ItemUnit();
            if (itemUnitOffer != null)
            {
                i = allItemsSource.Where(s => s.itemUnitId == itemUnitOffer.iuId.Value).FirstOrDefault();

                allItems.Add(i);

                selectedItems.Remove(itemUnitOffer);

                dg_allItems.ItemsSource = allItems;
                dg_selectedItems.ItemsSource = selectedItems;

                dg_allItems.Items.Refresh();
                dg_selectedItems.Items.Refresh();
            }
        }
        private async void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {//unselect all
            int x = selectedItems.Count;
            for (int i = 0; i < x ; i++)
            {
                dg_selectedItems.SelectedIndex = 0;
                Btn_unSelectedItem_Click(null, null);
            }
            
        }
        private void Txb_searchitems_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            txtItemSearch = txb_searchitems.Text.ToLower();

            //if (allItems is null)
            //    allItems = allItemsSource;
            searchText = txb_searchitems.Text;
            itemUnitQuery = allItems.Where(s => s.itemName.Contains(searchText) || s.unitName.Contains(searchText));
            dg_allItems.ItemsSource = itemUnitQuery;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }

        private void Dg_selectedItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ItemUnitOffer i = dg_selectedItems.SelectedItem as ItemUnitOffer;
            //MessageBox.Show(i.quantity.ToString());
        }
        private void Grid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //// Have to do this in the unusual case where the border of the cell gets selected.
            //// and causes a crash 'EditItem is not allowed'
            e.Cancel = true;
        }
    }
}

using POS.Classes;
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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_itemsUnitList.xaml
    /// </summary>
    public partial class wd_itemsUnitList : Window
    {
        public int itemId = 0 , itemUnitId = 0;

        public bool isActive;

        ItemUnit itemUnit = new ItemUnit();
        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> allItemUnitsSource = new List<ItemUnit>();
        List<ItemUnit> allItemUnits = new List<ItemUnit>();

        Package package = new Package();
        Package packageModel = new Package();
        List<Package> allIPackagesSource = new List<Package>();
        List<Package> allPackages = new List<Package>();

        string searchText = "";

        public string txtItemSearch;

        IEnumerable<ItemUnit> itemUnitQuery;

        public wd_itemsUnitList()
        {
            InitializeComponent();
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load

            #region translate
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_offerList.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_offerList.FlowDirection = FlowDirection.RightToLeft; }

            translat();
            #endregion
            //MessageBox.Show(itemUnitId.ToString());
            allItemUnitsSource = await itemUnitModel.Getall();
            allIPackagesSource = await packageModel.GetChildsByParentId(itemUnitId);
            allItemUnits.AddRange(allItemUnitsSource);
            for(int i = 0; i < allItemUnits.Count; i++)
            {
                //remove parent package itemunit
                if (allItemUnits[i].itemUnitId == itemUnitId)
                { allItemUnits.Remove(allItemUnits[i]);  break; }
                
            }
            foreach (var iu in allItemUnits)
            {
                iu.itemName = iu.itemName + "-" + iu.unitName;
            }
            //remove selected itemunits from source itemunits
            foreach (var p in allIPackagesSource)
            {
                for (int i = 0; i < allItemUnits.Count; i++)
                {
                    //remove saved itemunits
                    if (p.childIUId == allItemUnits[i].itemUnitId)
                    {
                        allItemUnits.Remove(allItemUnits[i]);
                    }
                }
            }
            allPackages.AddRange(allIPackagesSource);
            foreach(var p in allPackages)
            {
                foreach (var iu in allItemUnits)
                    if (p.parentIUId == iu.itemUnitId)
                        p.notes = iu.itemName + "-" + iu.unitName;
            }

            dg_allItems.ItemsSource = allItemUnits;
            dg_allItems.SelectedValuePath = "itemUnitId";
            dg_allItems.DisplayMemberPath = "itemName";

            dg_selectedItems.ItemsSource = allPackages;
            dg_allItems.SelectedValuePath = "packageId";
            dg_allItems.DisplayMemberPath = "notes";
        }

        private void translat()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_searchitems, MainWindow.resourcemanager.GetString("trSearchHint"));

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

            dg_allItems.Columns[0].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_selectedItems.Columns[0].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_selectedItems.Columns[1].Header = MainWindow.resourcemanager.GetString("trQuantity");

            txt_title.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_items.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_selectedItems.Text = MainWindow.resourcemanager.GetString("trSelectedItems");

            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_selectAllItem.Content = MainWindow.resourcemanager.GetString("trSelectAllItems");
            tt_unselectAllItem.Content = MainWindow.resourcemanager.GetString("trUnSelectAllItems");
            tt_selectItem.Content = MainWindow.resourcemanager.GetString("trSelectOneItem");
            tt_unselectItem.Content = MainWindow.resourcemanager.GetString("trUnSelectOneItem");

        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            this.Close();
        }

        private void Txb_searchitems_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            txtItemSearch = txb_searchitems.Text.ToLower();

            //if (allItems is null)
            //    allItems = allItemsSource;
            searchText = txb_searchitems.Text;
            itemUnitQuery = allItemUnits.Where(s => s.itemName.Contains(searchText) || s.unitName.Contains(searchText));
            dg_allItems.ItemsSource = itemUnitQuery;
        }

        private void Dg_allItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_selectedItem_Click(null, null);
        }

        private void Btn_selectedAll_Click(object sender, RoutedEventArgs e)
        {//select all
            int x = allItemUnits.Count;
            for (int i = 0; i < x; i++)
            {
                dg_allItems.SelectedIndex = 0;
                Btn_selectedItem_Click(null, null);
            }
        }

        private void Btn_selectedItem_Click(object sender, RoutedEventArgs e)
        {//select one
            itemUnit = dg_allItems.SelectedItem as ItemUnit;
            if (itemUnit != null)
            {
                Package p = new Package();

                p.parentIUId = itemUnitId;
                p.childIUId = itemUnit.itemUnitId;
                p.quantity = 0;
                p.isActive = 1;
                p.notes = itemUnit.itemName;
                p.createUserId = MainWindow.userID;
             
                allItemUnits.Remove(itemUnit);

                allPackages.Add(p);

                dg_allItems.ItemsSource = allItemUnits;
                dg_selectedItems.ItemsSource = allPackages;

                dg_allItems.Items.Refresh();
                dg_selectedItems.Items.Refresh();
            }

        }

        private void Btn_unSelectedItem_Click(object sender, RoutedEventArgs e)
        {//unselect one
            package = dg_selectedItems.SelectedItem as Package;
            ItemUnit i = new ItemUnit();
            if (package != null)
            {
                i = allItemUnitsSource.Where(s => s.itemUnitId == package.childIUId.Value).FirstOrDefault();

                allItemUnits.Add(i);

                allPackages.Remove(package);

                dg_allItems.ItemsSource = allItemUnits;
                dg_selectedItems.ItemsSource = allPackages;

                
                dg_allItems.Items.Refresh();
                // for solve problem
                this.dg_selectedItems.CancelEdit();
                this.dg_selectedItems.CancelEdit();
                ////////////
                dg_selectedItems.Items.Refresh();
            }
        }

        private void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {//unselect all
            int x = allPackages.Count;
            for (int i = 0; i < x; i++)
            {
                dg_selectedItems.SelectedIndex = 0;
                Btn_unSelectedItem_Click(null, null);
            }
        }

        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            await package.UpdatePackByParentId(itemUnitId , allPackages , MainWindow.userID.Value);

            isActive = false;
            this.Close();
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

        private void Dg_allItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Dg_selectedItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Btn_unSelectedItem_Click(null, null);
        }

        

        private void Dg_selectedItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

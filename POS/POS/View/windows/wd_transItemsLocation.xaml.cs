using netoaster;
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
    /// Interaction logic for wd_transItemsLocation.xaml
    /// </summary>
    public partial class wd_transItemsLocation : Window
    {
        public wd_transItemsLocation()
        {
            InitializeComponent();
        }
        public List<ItemTransfer> orderList { get; set; }
        public List<ItemLocation> selectedItemsLocations { get; set; }

        private List<ItemLocation> itemsLocations;
        private ItemLocation itemLocationModel = new ItemLocation();
        private List<long> _Quantity = new List<long>();

        private void translate()
        {
            ////////////////////////////////----Order----/////////////////////////////////
            dg_itemsStorage.Columns[1].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_itemsStorage.Columns[2].Header = MainWindow.resourcemanager.GetString("trAmount");
            dg_itemsStorage.Columns[3].Header = MainWindow.resourcemanager.GetString("trLocation");
            dg_itemsStorage.Columns[4].Header = MainWindow.resourcemanager.GetString("trStartDate");
            dg_itemsStorage.Columns[5].Header = MainWindow.resourcemanager.GetString("trEndDate");



        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }
        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            //return;
            for(int i=0; i<orderList.Count; i++)
            {
                if (_Quantity[i] < orderList[i].quantity)
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotValidFromToolTip") + itemsLocations[i].itemName, animation: ToasterAnimation.FadeIn);
                    valid = false;
                    break;
                }
            }
            if (valid)
            {
                DialogResult = true;
                this.Close();
            }
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SectionData.StartAwait(grid_mainGrid);

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                dg_itemsStorage.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                dg_itemsStorage.FlowDirection = FlowDirection.RightToLeft;
            }

            await refreshItemsLocations();
            SectionData.EndAwait(grid_mainGrid,this);
        }
        private async Task refreshItemsLocations()
        {
            string strIds = "";
            for(int i=0; i< orderList.Count; i++)
            {
                strIds += orderList[i].itemUnitId.ToString() + ',';
                _Quantity.Add(0);
            }
            selectedItemsLocations = await itemLocationModel.getSpecificItemLocation(strIds, MainWindow.branchID.Value);
            itemsLocations = new List<ItemLocation>();

            itemsLocations.AddRange( selectedItemsLocations);
               
            dg_itemsStorage.ItemsSource = selectedItemsLocations.ToList();
        }
        private void Dg_itemsStorage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FieldDataGridChecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            //long oldQuantity = _Quantity;
            //var index = dg_itemsStorage.SelectedIndex;
            //ItemLocation row = dg_itemsStorage.Items[index] as ItemLocation;
            //TextBlock tb = dg_itemsStorage.Columns[2].GetCellContent(dg_itemsStorage.Items[index]) as TextBlock;

            //selectedItemsLocations[index].isSelected = true;

            //_Quantity += (long) selectedItemsLocations[index].quantity;
            //ItemTransfer Item = orderList.ToList().Find(i => i.itemUnitId == row.itemUnitId);
            //if(_Quantity > Item.quantity)
            //{
            //    _Quantity -= (long)selectedItemsLocations[index].quantity;
            //    selectedItemsLocations[index].quantity = Item.quantity - oldQuantity;          
            //    _Quantity += (long) selectedItemsLocations[index].quantity;
            //    tb.Text = (Item.quantity - oldQuantity).ToString();
            //}
        }

        private void FieldDataGridUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            var index = dg_itemsStorage.SelectedIndex;
            //selectedItemsLocations[index].isSelected = false;
            //_Quantity -= (long) selectedItemsLocations[index].quantity;
        }

        private void Dg_itemsStorage_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBox t = new TextBox();
            CheckBox cb = new CheckBox();
            ItemLocation row = e.Row.Item as ItemLocation;
            var index = e.Row.GetIndex();
            if (dg_itemsStorage.SelectedIndex != -1 &&  index < itemsLocations.Count)
            {
                 t = e.EditingElement as TextBox;
                cb = e.EditingElement as CheckBox;              

               long oldCount = (long) row.quantity;
                long newCount = 0;
                long totalQuantity = 0;
                
                int itemUnitId = row.itemUnitId.Value;
                long basicCount = (long) orderList.ToList().Find(x => x.itemUnitId == itemUnitId).quantity; 
                ItemTransfer Item = orderList.ToList().Find(i => i.itemUnitId == row.itemUnitId);
                int itemIndex = orderList.ToList().FindIndex(i => i.itemUnitId == row.itemUnitId);
                if (cb != null)
                {                  
                    //MessageBox.Show(cb.IsChecked.ToString());
                    if (cb.IsChecked == true)
                    {                        
                        TextBlock tb = dg_itemsStorage.Columns[2].GetCellContent(dg_itemsStorage.Items[index]) as TextBlock;

                        selectedItemsLocations[index].isSelected = true;
                      
                        long oldQuantity = _Quantity[itemIndex];
                        if (_Quantity[itemIndex] != 0)
                            _Quantity[itemIndex] -= (long) row.quantity;
                        _Quantity[itemIndex] += long.Parse(tb.Text);
                        if (_Quantity[itemIndex] > Item.quantity)
                        {
                            _Quantity[itemIndex] -= (long)selectedItemsLocations[index].quantity;
                            selectedItemsLocations[index].quantity = Item.quantity - oldQuantity;
                            _Quantity[itemIndex] += (long)selectedItemsLocations[index].quantity;
                            tb.Text = (Item.quantity - oldQuantity).ToString();
                        }
                    }
                    else
                    {
                        selectedItemsLocations[index].isSelected = false;
                       // _Quantity[itemIndex] -= (long)selectedItemsLocations[index].quantity;
                        _Quantity[itemIndex] -= (long)row.quantity; ;
                    }
                }
               else if (t != null)
                {
                    cb = dg_itemsStorage.Columns[0].GetCellContent(dg_itemsStorage.Items[index]) as CheckBox;
                    newCount = long.Parse(t.Text);
                    if (cb.IsChecked == true)
                    {
                        _Quantity[itemIndex] -= (long) row.quantity;
                        if (newCount > basicCount)
                        {
                            _Quantity[itemIndex] += basicCount;
                            t.Text = basicCount.ToString();
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
                        }
                        else
                        {
                            _Quantity[itemIndex] += newCount;
                            selectedItemsLocations[index].quantity = newCount;
                            // loop on selected itemUnit to calculate total quantity
                            foreach (ItemLocation il in itemsLocations)
                            {
                                if (il.isSelected == true && il.itemUnitId == itemUnitId)
                                {
                                    totalQuantity += (long)il.quantity;
                                }
                            }
                            if (totalQuantity > Item.quantity)
                            {
                                selectedItemsLocations[index].quantity = 0;
                                t.Text = "0";
                            }
                        }
                    }
                    else
                    {
                        selectedItemsLocations[index].quantity = newCount;
                    }
                }
            }

        }
    }
}

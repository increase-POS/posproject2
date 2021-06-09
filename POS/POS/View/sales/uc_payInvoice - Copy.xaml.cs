using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static POS.View.uc_categorie;
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.Globalization;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_payInvoice.xaml
    /// </summary>
    public partial class uc_payInvoice1 : UserControl
    {
        
        public uc_payInvoice1()
        {
            InitializeComponent();

          
            

        }
     
     
       

        private void translate()
        {
            
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

          
        }
        
        private void configureDiscountType()
        {
            var dislist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trValueDiscount"), Value = "1" },
            new { Text = MainWindow.resourcemanager.GetString("trPercentageDiscount"), Value = "2" },
             };

            cb_typeDiscount.DisplayMemberPath = "Text";
            cb_typeDiscount.SelectedValuePath = "Value";
            cb_typeDiscount.ItemsSource = dislist;
            cb_typeDiscount.SelectedIndex = 0;
        }

        #region bill



        public class Bill
        {
            public int Id { get; set; }
            public int Total { get; set; }

        }
        public class BillDetails
        {
            public int ID { get; set; }
            public int itemId { get; set; }
            public int itemUnitId { get; set; }
            public string Product { get; set; }
            public string Unit { get; set; }
            public int Count { get; set; }
            public decimal Price { get; set; }
            public decimal Total { get; set; }
        }

        #endregion
        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
           
        }
        #endregion

        
        private void Btn_updateVendor_Click(object sender, RoutedEventArgs e)
        {
           // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;

            //if ((((this.Parent as Grid).Parent as Grid).Parent as UserControl) != null)
            //((((this.Parent as Grid).Parent as Grid).Parent as Grid).Parent as UserControl).Opacity = 0.2;
            wd_updateVendor w = new wd_updateVendor();
            //// pass agent id to update windows
            w.agent.agentId = 22;
            //w.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00178DD2"));
            w.ShowDialog();


           // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
        }
        #region Categor and Item
        #region Refrish Y
        /// <summary>
        /// Category
        /// </summary>
        /// <returns></returns>
        //async Task<IEnumerable<Category>> RefrishCategories()
        //{
        //    categories = await categoryModel.GetAllCategories();
        //    return categories;
        //}
        async Task RefrishVendors()
        {
           
        }
        async Task RefrishBranches()
        {
           
        }
        async Task RefrishItems()
        {
           
        }
        async Task fillBarcodeList()
        {
        }

      

        #endregion
        #region Get Id By Click  Y

        public async void ChangeCategoryIdEvent(int categoryId)
        {
            //    category = categories.ToList().Find(c => c.categoryId == categoryId);

            //    if (categories.Where(x =>
            //    x.isActive == tglCategoryState && x.parentId == category.categoryId).Count() != 0)
            //    {
            //        categoryParentId = category.categoryId;
            //        RefrishCategoriesCard();
            //    }

            //    generateTrack(categoryId);
            //    await RefrishItems();
            //    Txb_searchitems_TextChanged(null, null);
        }


        public async void ChangeItemIdEvent(int itemId)
        {
           
        }
        
        #endregion
       

        #endregion
        #region Excel
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region validation
        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;

            else
                e.Handled = true;
        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void validateInvoiceValues()
        {
             }

        private void input_LostFocus(object sender, RoutedEventArgs e)
        {   
        }
        #endregion
        #region save invoice

        private async Task addInvoice(string invType)
        {
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
          
        }
        private async void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void clearInvoice()
        {
            
        }
        #endregion
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
           // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            wd_invoice w = new wd_invoice();
            // purchase drafts and purchase bounce drafts
           // string[] typeArr = { "pd","pdbd" };
            w.invoiceType = "pd ,pbd";  
  
 
            w.title = MainWindow.resourcemanager.GetString("trDrafts");

        }
        private  void  fillInvoiceInputs(Invoice invoice)
        {
          
           
        }
        private async void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {
          
        }
        private void buildInvoiceDetails(List<ItemTransfer> invoiceItems)
        {
           
        }
        private void inputEditable()
        {
           
        }
        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_pay_Click(object sender, RoutedEventArgs e)
        {
          //  btn_vendor_Click(null, null);
        }

     
        private  void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshTotalValue();
        }
        private  void tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            refreshTotalValue();
        }
        private void refreshTotalValue( )
        {
            
        }
       //private void refreshTotalValue(decimal discountVal)
       // {
       //     decimal discountVal = 0;
       //     if (!tb_discount.Text.Equals(""))
       //     {
       //         if (tb_discount.Text.Equals("."))
       //             discountVal = 0;
       //         else
       //             discountVal = decimal.Parse(tb_discount.Text);
       //     }
       //     decimal total = _Sum - discountVal;
       //     tb_sum.Text = _Sum.ToString();
       //     tb_total.Text = total.ToString();
       // }
       
        #region billdetails
        /*
        List<ItemUnit> GetItemUnits(int itemId)
        {
            List<ItemUnit> itemUnits = new List<ItemUnit>();
            var ItemUnit1 = new ItemUnit { itemUnitId = 35 };
            var ItemUnit2 = new ItemUnit { itemUnitId = 63 };
            var ItemUnit3 = new ItemUnit { itemUnitId = 364 };
            itemUnits.Add(ItemUnit1);
            itemUnits.Add(ItemUnit2);
            itemUnits.Add(ItemUnit3);


            return itemUnits;

        }
        void GenerateComboBox(DataGrid dg)
        {
            var vm = GetItemUnits(1);
            var dataGridTemplateColumn = new DataGridTemplateColumn();
            var dataTemplate = new DataTemplate();
            var comboBox = new FrameworkElementFactory(typeof(ComboBox));
            //comboBox.SetValue(NameProperty, new Binding("cc" + dataGridTemplateColumn.Header));
            comboBox.SetValue(ComboBox.ItemsSourceProperty, vm);//Bind the ObservableCollection list
            comboBox.SetValue(ComboBox.SelectedIndexProperty, 1);
            comboBox.SetValue(ComboBox.DisplayMemberPathProperty, "itemUnitId");
            comboBox.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(ComboBox_SelectionChanged));

            dataTemplate.VisualTree = comboBox;
            dataGridTemplateColumn.CellTemplate = dataTemplate;
            dataGridTemplateColumn.Header = "Unit";
            dg.Columns.Add(dataGridTemplateColumn);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        */
      

        // read item from barcode

        #endregion billdetails



        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
           

            

        }

        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_updateCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cb_delivery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Dp_desrvedDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}

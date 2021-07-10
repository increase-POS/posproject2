using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static POS.View.uc_categorie;

namespace POS.View.sales
{
    /// <summary>
    /// Interaction logic for uc_orders.xaml
    /// </summary>
    public partial class uc_orders : UserControl
    {
        private static uc_orders _instance;
        public static uc_orders Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_orders();
                return _instance;
            }
        }
        public uc_orders()
        {
            InitializeComponent();
        }

        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;
        Card cardModel = new Card();
        IEnumerable<Card> cards;
        // IEnumerable<Item> itemsQuery;
        Branch branchModel = new Branch();
        Branch branch;
        Agent agentModel = new Agent();
        IEnumerable<Agent> customers;
        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;
        Invoice invoiceModel = new Invoice();
        Invoice invoice = new Invoice();
        Coupon couponModel = new Coupon();
        IEnumerable<Coupon> coupons;
        List<CouponInvoice> selectedCoupons = new List<CouponInvoice>();
        Pos posModel = new Pos();
        Pos pos;
        List<ItemTransfer> invoiceItems;
        ItemLocation itemLocationModel = new ItemLocation();
        #region//to handle barcode characters
        static private int _SelectedCustomer = -1;
        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        static private string _BarcodeStr = "";
        static private object _Sender;
        #endregion
        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;
        //for bill details
        static private int _SequenceNum = 0;
        static private decimal _Sum = 0;
        static private decimal _Tax = 0;
        static private decimal _Discount = 0;
        static private string _InvoiceType = ""; // order draft

        // for report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
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
            public decimal Tax { get; set; }
        }

        #endregion
        private void translate()
        {
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");
            dg_billDetails.Columns[5].Header = MainWindow.resourcemanager.GetString("trPrice");
            dg_billDetails.Columns[6].Header = MainWindow.resourcemanager.GetString("trTotal");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_tax.Text = MainWindow.resourcemanager.GetString("trTax");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal:");
            //btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            //btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdfBtn");


            ////////////////////////////////----Customer----/////////////////////////////////

            txt_customer.Text = MainWindow.resourcemanager.GetString("trCustomer");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trCustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");



        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucOrders.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucOrders.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

            await RefrishItems();
            await RefrishCustomers();
            await fillBarcodeList();
            await fillCouponsList();

            pos = await posModel.getPosById(MainWindow.posID.Value);
            branch = await branchModel.getBranchById((int)pos.branchId);
            #region Style Date
            SectionData.defaultDatePickerStyle(dp_desrvedDate);
            #endregion
            if (MainWindow.isInvTax == 1) // tax is on tatal invoice
            {
                tb_taxValue.Text = MainWindow.tax.ToString();
                tb_taxValue.Text = MainWindow.tax.ToString();
            }
            tb_barcode.Focus();

            #region datagridChange
            CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
            ((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
            #endregion
        }
        async Task RefrishCustomers()
        {
            customers = await agentModel.GetAgentsActive("c");
            cb_customer.ItemsSource = customers;
            cb_customer.DisplayMemberPath = "name";
            cb_customer.SelectedValuePath = "agentId";
        }
        async Task RefrishItems()
        {
            items = await itemModel.GetAllItems();
        }
        async Task fillBarcodeList()
        {
            barcodesList = await itemUnitModel.Getall();
        }
        async Task fillCouponsList()
        {
            coupons = await couponModel.GetCouponsAsync();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
                    int index = dg_billDetails.SelectedIndex;
                    // calculate new sum
                    _Sum -= row.Total;
                    _Tax -= row.Tax;

                    // remove item from bill
                    billDetails.RemoveAt(index);

                    ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
                    data.Remove(row);

                    // calculate new total
                    refreshTotalValue();
                }
            _SequenceNum = 0;
            _Sum = 0;
            _Tax = 0;
            for (int i = 0; i < billDetails.Count; i++)
            {
                _SequenceNum++;
                _Sum += billDetails[i].Total;
                _Tax += billDetails[i].Tax;
                billDetails[i].ID = _SequenceNum;
            }
            refrishBillDetails();
        }
        #endregion
        #region coupon
        private async void Tb_coupon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string s = _BarcodeStr;
                couponModel = coupons.ToList().Find(c => c.code == tb_coupon.Text || c.barcode == tb_coupon.Text);
                if (couponModel != null)
                {
                    s = couponModel.barcode;
                    await dealWithBarcode(s);
                }
                tb_coupon.Clear();
            }
        }
        private async Task dealWithBarcode(string barcode)
        {
            /*
            int codeindex = barcode.IndexOf("-");
            string prefix = "";
            if (codeindex >= 0)
                prefix = barcode.Substring(0, codeindex);
            prefix = prefix.ToLower();
            barcode = barcode.ToLower();
            switch (prefix)
            {
                case "si":// this barcode for invoice

                    Btn_newDraft_Click(null, null);
                    invoice = await invoiceModel.GetInvoicesByNum(barcode);
                    _InvoiceType = invoice.invType;
                    if (_InvoiceType.Equals("qd") || _InvoiceType.Equals("q"))
                    {
                        // set title to bill
                        if (_InvoiceType == "qd")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftQuontaion");
                        }
                        else if (_InvoiceType == "q")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSalesInvoice");
                        }
                        await fillInvoiceInputs(invoice);
                    }
                    break;
                case "cop":// this barcode for coupon
                    {
                        await fillCouponsList();
                        couponModel = coupons.ToList().Find(c => c.barcode == barcode);
                        var exist = selectedCoupons.Find(c => c.couponId == couponModel.cId);
                        if (couponModel != null && exist == null)
                        {
                            if (couponModel.remainQ > 0 && couponModel.endDate >= DateTime.Now && couponModel.startDate <= DateTime.Now)
                            {
                                CouponInvoice ci = new CouponInvoice();
                                ci.couponId = couponModel.cId;
                                ci.discountType = couponModel.discountType;
                                ci.discountValue = couponModel.discountValue;

                                lst_coupons.Items.Add(couponModel.code);
                                selectedCoupons.Add(ci);
                                refreshTotalValue();
                            }
                            else if (couponModel.remainQ == 0)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponQuantity"), animation: ToasterAnimation.FadeIn);
                            else if (couponModel.endDate < DateTime.Now)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponExpire"), animation: ToasterAnimation.FadeIn);
                            else if (couponModel.startDate > DateTime.Now)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponNotActive"), animation: ToasterAnimation.FadeIn);

                        }
                        else
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponExist"), animation: ToasterAnimation.FadeIn);
                        }
                        tb_coupon.Clear();
                    }
                    break;
                case "cus":// this barcode for customer
                    break;
                default: // if barcode for item
                    tb_barcode.Text = barcode;
                    // get item matches barcode
                    if (barcodesList != null)
                    {
                        ItemUnit unit1 = barcodesList.ToList().Find(c => c.barcode == tb_barcode.Text.Trim());

                        // get item matches the barcode
                        if (unit1 != null)
                        {
                            int itemId = (int)unit1.itemId;
                            if (unit1.itemId != 0)
                            {
                                int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId).FirstOrDefault());

                                if (index == -1)//item doesn't exist in bill
                                {
                                    // get item units
                                    itemUnits = await itemUnitModel.GetItemUnits(itemId);
                                    //get item from list
                                    item = items.ToList().Find(i => i.itemId == itemId);

                                    int count = 1;
                                    decimal price = 0;
                                    if (unit1.price != null)
                                        price = (decimal)unit1.price;
                                    decimal total = count * price;
                                    decimal tax = (decimal)(count * item.taxes);
                                    addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count, price, total, tax);
                                }
                                else // item exist prevoiusly in list
                                {
                                    decimal itemTax = 0;
                                    if (item.taxes != null)
                                        itemTax = (decimal)item.taxes;
                                    billDetails[index].Count++;
                                    billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;
                                    billDetails[index].Tax = (decimal)(billDetails[index].Count * itemTax);

                                    _Sum += billDetails[index].Price;
                                    _Tax += billDetails[index].Tax;

                                }
                                refreshTotalValue();
                                refrishBillDetails();
                            }
                        }
                        else
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorItemNotFoundToolTip"), animation: ToasterAnimation.FadeIn);
                        }
                    }
                    break;
            }

            tb_barcode.Clear();
            */
        }
        private void Btn_clearCoupon_Click(object sender, RoutedEventArgs e)
        {
            _Discount = 0;
            selectedCoupons.Clear();
            lst_coupons.Items.Clear();
            tb_coupon.Clear();
            refreshTotalValue();
        }
        #endregion
        #region Categor and Item 
        #region Refrish Y
        //async Task<bool> RefrishCategory()
        //{
        //    categories = await categoryModel.GetAllCategories();
        //    return true;
        //}
        //void RefrishCategoryCard(IEnumerable<Category> _categories)
        //{

        //}
        //async Task<bool> RefrishItem()
        //{
        //    items = await itemModel.GetAllItems();
        //    return true;
        //}
        //void RefrishItemDatagrid(IEnumerable<Item> _items)
        //{
        //}
        //void RefrishItemCard(IEnumerable<Item> _items)
        //{

        //}
        #endregion
        #region Get Id By Click  Y
        public void ChangeCategorieIdEvent(int categoryId)
        {
            MessageBox.Show("you  double click on Category Card");
        }
        public void testChangeCategorieItemsIdEvent()
        {
            MessageBox.Show("you  double click on Items Card");
        }
        #endregion

        #endregion
        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

        }
        private void validateInvoiceValues()
        {
            //SectionData.showTextBoxValidate(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            SectionData.validateEmptyComboBox(cb_customer, p_errorCustomer, tt_errorCustomer, "trEmptyCustomerToolTip");
        }
        private async void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {
            /*
            //check mandatory inputs
            validateInvoiceValues();
            Boolean available = true;
            if (_InvoiceType == "qd")
                available = await checkItemsAmounts();
            if (billDetails.Count > 0 && available && !tb_name.Equals(""))
            {
                await addInvoice(_InvoiceType);
            }
            else if (billDetails.Count == 0)
            {
                clearInvoice();
                _InvoiceType = "qd";
            }
            */
        }
        private void clearInvoice()
        {
            _Sum = 0;
            if (MainWindow.isInvTax == 1) // tax is on tatal invoice
            {
                tb_taxValue.Text = MainWindow.tax.ToString();
                _Tax = (decimal)MainWindow.tax;
            }
            else _Tax = 0;
            _Discount = 0;
            _SequenceNum = 0;
            _SelectedCustomer = -1;
            _InvoiceType = "qd";
            invoice = new Invoice();
            selectedCoupons.Clear();
            tb_barcode.Clear();
            //tb_name.Clear();
            cb_customer.SelectedIndex = -1;
            cb_customer.SelectedItem = "";
            dp_desrvedDate.Text = "";
            tb_note.Clear();
            txt_discount.Text = "";
            billDetails.Clear();
            tb_total.Text = "";
            tb_sum.Text = null;
            if (MainWindow.isInvTax == 1)
                tb_taxValue.Text = MainWindow.tax.ToString();
            else
                tb_taxValue.Text = "0";
            lst_coupons.Items.Clear();
            tb_discount.Text = "0";

            btn_updateCustomer.IsEnabled = false;
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSaleInvoice");
            SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
            //SectionData.clearValidate(tb_name, p_errorName);
            refrishBillDetails();
            tb_barcode.Focus();
            inputEditable();
        }
        private void inputEditable()
        {
            /*
            switch (_InvoiceType)
            {
                case "qd": // quotation draft invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                    dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                    cb_customer.IsEnabled = true;
                    tb_name.IsEnabled = true;
                    dp_desrvedDate.IsEnabled = true;
                    tb_note.IsEnabled = true;
                    tb_barcode.IsEnabled = true;
                    tb_discount.IsEnabled = true;
                    btn_save.IsEnabled = true;
                    btn_updateCustomer.IsEnabled = true;
                    tb_coupon.IsEnabled = true;
                    btn_clearCoupon.IsEnabled = true;
                    break;
                case "q": //quotation invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                    dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                    cb_customer.IsEnabled = false;
                    tb_name.IsEnabled = false;
                    dp_desrvedDate.IsEnabled = false;
                    tb_note.IsEnabled = false;
                    tb_barcode.IsEnabled = false;
                    tb_discount.IsEnabled = false;
                    btn_save.IsEnabled = false;
                    btn_updateCustomer.IsEnabled = false;
                    tb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
                    break;
            }
            */
        }
        private async Task addInvoice(string invType)
        {
            /*
            if (invoice.branchCreatorId == 0 || invoice.branchCreatorId == null)
            {
                invoice.branchCreatorId = MainWindow.branchID.Value;
                invoice.posId = MainWindow.posID.Value;
            }
            invoice.invType = invType;
            invoice.name = tb_name.Text;
            invoice.posId = MainWindow.posID;
            if (!tb_discount.Text.Equals(""))
                invoice.discountValue = decimal.Parse(tb_discount.Text);

            invoice.total = _Sum;
            invoice.totalNet = decimal.Parse(tb_total.Text);

            if (cb_customer.SelectedIndex != -1)
                invoice.agentId = (int)cb_customer.SelectedValue;

            invoice.deservedDate = dp_desrvedDate.SelectedDate;
            invoice.notes = tb_note.Text;

            if (tb_taxValue.Text != "")
                invoice.tax = decimal.Parse(tb_taxValue.Text);
            else
                invoice.tax = 0;

            invoice.createUserId = MainWindow.userID;
            invoice.updateUserId = MainWindow.userID;

            // build invoice NUM like storCode_PI_sequence exp: 123_PI_2
            if (invoice.invNumber == null)
            {
                invoice.invNumber = await invoice.generateInvNumber("si");
            }

            // save invoice in DB
            int invoiceId = int.Parse(await invoiceModel.saveInvoice(invoice));

            if (invoiceId != 0)
            {
                #region save coupns on invoice
                foreach (CouponInvoice ci in selectedCoupons)
                {
                    ci.InvoiceId = invoiceId;
                    ci.createUserId = MainWindow.userID;
                }
                await invoiceModel.saveInvoiceCoupons(selectedCoupons, invoiceId, invoice.invType);
                #endregion
                // add invoice details
                invoiceItems = new List<ItemTransfer>();
                ItemTransfer itemT;
                for (int i = 0; i < billDetails.Count; i++)
                {
                    itemT = new ItemTransfer();

                    itemT.invoiceId = invoiceId;
                    itemT.quantity = billDetails[i].Count;
                    itemT.price = billDetails[i].Price;
                    itemT.itemUnitId = billDetails[i].itemUnitId;
                    itemT.createUserId = MainWindow.userID;

                    invoiceItems.Add(itemT);
                }
                await invoiceModel.saveInvoiceItems(invoiceItems, invoiceId);
            }
            clearInvoice();
            */
        }
        //private async Task<string> generateInvNumber(string invoiceCode)
        //{
        //    string storeCode = "";
        //    string posCode = "";
        //    if (pos != null)
        //    {
        //        storeCode = pos.branchCode;
        //        posCode = pos.code;
        //    }
        //    int sequence = await invoiceModel.GetLastNumOfInv(invoiceCode);
        //    sequence++;

        //    string invoiceNum = invoiceCode + "-" + storeCode + "-" + posCode + "-" + sequence.ToString();
        //    return invoiceNum;
        //}
        #region Get Id By Click  Y
        public async void ChangeItemIdEvent(int itemId)
        {
            if (items != null) item = items.ToList().Find(c => c.itemId == itemId);

            if (item != null)
            {
                //this.DataContext = item;

                // get item units
                itemUnits = await itemUnitModel.GetItemUnits(item.itemId);
                // search for default unit for purchase
                var defaultsaleUnit = itemUnits.ToList().Find(c => c.defaultSale == 1);
                if (defaultsaleUnit != null)
                {
                    decimal itemTax = 0;
                    if (item.taxes != null)
                        itemTax = (decimal)item.taxes;
                    // create new row in bill details data grid
                    addRowToBill(item.name, itemId, defaultsaleUnit.mainUnit, defaultsaleUnit.itemUnitId, 1, (decimal)defaultsaleUnit.price, (decimal)defaultsaleUnit.price, itemTax);

                    refreshTotalValue();
                    refrishBillDetails();
                }
            }
        }
        private void refreshTotalValue()
        {
            #region calculate discount value
            _Discount = 0;
            foreach (CouponInvoice coupon in selectedCoupons)
            {
                string discountType = coupon.discountType.ToString();
                decimal discountValue = (decimal)coupon.discountValue;
                if (discountType == "2")
                    discountValue = SectionData.calcPercentage(_Sum, discountValue);
                _Discount += discountValue;
            }
            tb_discount.Text = _Discount.ToString();
            #endregion
            decimal taxValue = _Tax;
            if (MainWindow.isInvTax == 1)
            {
                taxValue = SectionData.calcPercentage(_Sum, (decimal)MainWindow.tax);
            }
            else
                tb_taxValue.Text = _Tax.ToString();
            decimal total = _Sum - _Discount + taxValue;

            tb_sum.Text = _Sum.ToString();


            tb_total.Text = Math.Round(total, 2).ToString();
        }
        #endregion
        #region billdetails

        void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            if (billDetails.Count == 1)
            {
                BillDetails bd = new BillDetails();
                billDetails.Add(bd);
                dg_billDetails.ItemsSource = billDetails;
                billDetails.Remove(bd);
            }
            else
                dg_billDetails.ItemsSource = billDetails;

            tb_sum.Text = _Sum.ToString();
            if (MainWindow.isInvTax == 0)
                tb_taxValue.Text = _Tax.ToString();
        }


        // read item from barcode
        private async void HandleKeyPress(object sender, KeyEventArgs e)
        {
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 50)
            {
                _BarcodeStr = "";
            }

            string digit = "";
            // record keystroke & timestamp 
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                //digit pressed!         
                digit = e.Key.ToString().Substring(1);
                // = "1" when D1 is pressed
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                digit = e.Key.ToString().Substring(6); // = "1" when NumPad1 is pressed
            }
            else if (e.Key >= Key.A && e.Key <= Key.Z)
                digit = e.Key.ToString();
            else if (e.Key == Key.OemMinus)
            {
                digit = "-";
            }
            _BarcodeStr += digit;
            _lastKeystroke = DateTime.Now;
            // process barcode

            if (e.Key.ToString() == "Return" && _BarcodeStr != "" && _InvoiceType == "qd")
            {
                await dealWithBarcode(_BarcodeStr);
                if (_Sender != null) //clear barcode from inputs
                {
                    DatePicker dt = _Sender as DatePicker;
                    TextBox tb = _Sender as TextBox;
                    if (dt != null)
                    {
                        if (dt.Name == "dp_desrvedDate")
                            _BarcodeStr = _BarcodeStr.Substring(1);
                    }
                    else if (tb != null)
                    {
                        if (tb.Name == "tb_name" || tb.Name == "tb_note")// remove barcode from text box
                        {
                            string tbString = tb.Text;
                            string newStr = "";
                            int startIndex = tbString.IndexOf(_BarcodeStr);
                            if (startIndex != -1)
                                newStr = tbString.Remove(startIndex, _BarcodeStr.Length);

                            tb.Text = newStr;
                        }
                    }
                }
                tb_barcode.Text = _BarcodeStr;
                e.Handled = true;
            }
            _Sender = null;
            _BarcodeStr = "";
        }
        private async void Tb_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string barcode = "";
                if (_BarcodeStr.Length < 13)
                {
                    barcode = tb_barcode.Text;
                    await dealWithBarcode(barcode);
                }
            }
        }

        private void addRowToBill(string itemName, int itemId, string unitName, int itemUnitId, int count, decimal price, decimal total, decimal tax)
        {
            // increase sequence for each read
            _SequenceNum++;

            billDetails.Add(new BillDetails()
            {
                ID = _SequenceNum,
                Product = item.name,
                itemId = item.itemId,
                Unit = unitName,
                itemUnitId = itemUnitId,
                Count = 1,
                Price = price,
                Total = total,
                Tax = tax,
            });
            _Sum += total;
            _Tax += tax;
        }
        #endregion billdetails
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            /*
            // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            w.invoiceType = "qd"; //quontations draft invoices
            w.userId = MainWindow.userLogin.userId;

            w.title = MainWindow.resourcemanager.GetString("trDrafts");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    //this.DataContext = invoice;

                    _InvoiceType = invoice.invType;
                    // set title to bill
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");

                    await fillInvoiceInputs(invoice);
                }
            }
            //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
*/
        }
        private async Task fillInvoiceInputs(Invoice invoice)
        {
            _Sum = (decimal)invoice.total;
            if (invoice.tax != null)
                _Tax = (decimal)invoice.tax;
            //tb_name.Text = invoice.name;
            cb_customer.SelectedValue = invoice.agentId;
            dp_desrvedDate.Text = invoice.deservedDate.ToString();
            if (invoice.totalNet != null)
                tb_total.Text = Math.Round((double)invoice.totalNet, 2).ToString();
            tb_taxValue.Text = invoice.tax.ToString();
            tb_note.Text = invoice.notes;
            tb_sum.Text = invoice.total.ToString();
            tb_discount.Text = invoice.discountValue.ToString();

            tb_barcode.Clear();
            tb_barcode.Focus();

            await getInvoiceCoupons(invoice.invoiceId);
            // build invoice details grid
            await buildInvoiceDetails(invoice.invoiceId);
            inputEditable();
        }
        private async Task getInvoiceCoupons(int invoiceId)
        {
            if (_InvoiceType != "qd")
                selectedCoupons = await invoiceModel.GetInvoiceCoupons(invoiceId);
            else
                selectedCoupons = await invoiceModel.getOriginalCoupons(invoiceId);
            foreach (CouponInvoice invCoupon in selectedCoupons)
            {
                lst_coupons.Items.Add(invCoupon.couponCode);
            }
        }
        private async Task buildInvoiceDetails(int invoiceId)
        {
            //get invoice items
            invoiceItems = await invoiceModel.GetInvoicesItems(invoiceId);
            // build invoice details grid
            _SequenceNum = 0;
            billDetails.Clear();
            foreach (ItemTransfer itemT in invoiceItems)
            {
                _SequenceNum++;
                decimal total = (decimal)(itemT.price * itemT.quantity);
                billDetails.Add(new BillDetails()
                {
                    ID = _SequenceNum,
                    Product = itemT.itemName,
                    itemId = (int)itemT.itemId,
                    Unit = itemT.itemUnitId.ToString(),
                    itemUnitId = (int)itemT.itemUnitId,
                    Count = (int)itemT.quantity,
                    Price = (decimal)itemT.price,
                    Total = total,
                });
            }

            tb_barcode.Focus();

            refrishBillDetails();
        }
        private void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void Btn_orders_Click(object sender, RoutedEventArgs e)
        {
            /*
            // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            // quontations invoices
            w.invoiceType = "q";
            w.branchCreatorId = MainWindow.branchID.Value;
            w.title = MainWindow.resourcemanager.GetString("trSalesInvoices");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    this.DataContext = invoice;

                    _InvoiceType = invoice.invType;
                    // set title to bill
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSaleInvoice");

                    await fillInvoiceInputs(invoice);
                }
            }
            //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 1;
       */
            }
        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;

            if (dg_billDetails.SelectedIndex != -1)
                billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
        }
        private void Cbm_unitItemDetails_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //billDetails
            if (billDetails.Count == 1)
            {
                var cmb = sender as ComboBox;
                cmb.SelectedValue = (int)billDetails[0].itemUnitId;
            }

            //MessageBox.Show("Hello");
        }
        private void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //billDetails
            int count = 0;
            foreach (var item in billDetails)
            {
                if (dg_billDetails.Items.Count != 0)
                {
                    if (dg_billDetails.Items.Count > 1)
                    {
                        var cell = DataGridHelper.GetCell(dg_billDetails, count, 3);
                        if (cell != null)
                        {
                            var cp = (ContentPresenter)cell.Content;
                            var combo = (ComboBox)cp.ContentTemplate.FindName("cbm_unitItemDetails", cp);
                            //var combo = (combo)cell.Content;
                            combo.SelectedValue = (int)item.itemUnitId;
                            count++;
                        }
                    }

                }
            }

        }
        private async void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBlock tb;
            TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
            var columnName = e.Column.Header.ToString();

            BillDetails row = e.Row.Item as BillDetails;
            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == row.itemUnitId).FirstOrDefault());

            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds < 100)
            {
                if (columnName == MainWindow.resourcemanager.GetString("trAmount"))
                    t.Text = billDetails[index].Count.ToString();
                else if (columnName == MainWindow.resourcemanager.GetString("trPrice"))
                    t.Text = billDetails[index].Price.ToString();
            }
            else
            {
                int oldCount = 0;
                long newCount = 0;
                decimal oldPrice = 0;
                decimal newPrice = 0;

                //"tb_amont"
                if (columnName == MainWindow.resourcemanager.GetString("trAmount"))
                    newCount = int.Parse(t.Text);
                else
                    newCount = row.Count;

                oldCount = row.Count;

                int availableAmount = await itemLocationModel.getAmountInBranch(row.itemUnitId, MainWindow.branchID.Value);
                if (availableAmount < newCount)
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableToolTip"), animation: ToasterAnimation.FadeIn);
                    newCount = availableAmount;
                    tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[index]) as TextBlock;
                    tb.Text = newCount.ToString();
                }

                if (columnName == MainWindow.resourcemanager.GetString("trPrice"))
                    newPrice = decimal.Parse(t.Text);
                else
                    newPrice = row.Price;

                oldPrice = row.Price;

                // old total for changed item
                decimal total = oldPrice * oldCount;
                _Sum -= total;


                // new total for changed item
                total = newCount * newPrice;
                _Sum += total;

                decimal itemTax = 0;
                if (item.taxes != null)
                    itemTax = (decimal)item.taxes;
                // old tax for changed item
                decimal tax = (decimal)itemTax * oldCount;
                _Tax -= tax;
                // new tax for changed item
                tax = (decimal)itemTax * newCount;
                _Tax += tax;

                //refresh total cell
                tb = dg_billDetails.Columns[6].GetCellContent(dg_billDetails.Items[index]) as TextBlock;
                tb.Text = total.ToString();

                //  refresh sum and total text box
                refreshTotalValue();

                // update item in billdetails           
                billDetails[index].Count = (int)newCount;
                billDetails[index].Price = newPrice;
                billDetails[index].Total = total;
            }
        }
        private void Btn_invoiceImages_Click(object sender, RoutedEventArgs e)
        {
            if (invoice != null && invoice.invoiceId != 0)
            {
                //  (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;

                wd_uploadImage w = new wd_uploadImage();

                w.tableName = "invoices";
                w.tableId = invoice.invoiceId;
                w.docNum = invoice.invNumber;
                w.ShowDialog();
                // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity =1;
            }
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trChooseInvoiceToolTip"), animation: ToasterAnimation.FadeIn);
        }
        private async Task<Boolean> checkItemsAmounts()
        {
            Boolean available = true;
            for (int i = 0; i < billDetails.Count; i++)
            {
                int availableAmount = await itemLocationModel.getAmountInBranch(billDetails[i].itemUnitId, MainWindow.branchID.Value);
                if (availableAmount < billDetails[i].Count)
                {
                    available = false;
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableFromToolTip") + " " + billDetails[i].Product, animation: ToasterAnimation.FadeIn);
                    return available;
                }
            }
            return available;
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            /*
            //check mandatory inputs
            validateInvoiceValues();
            Boolean available = true;
            if (_InvoiceType == "qd")
                available = await checkItemsAmounts();
            if (billDetails.Count > 0 && available && !tb_name.Equals(""))
            {
                await addInvoice("q");//quontation invoice

                if (invoice.invoiceId == 0) clearInvoice();
            }
            */
        }
        private void Btn_updateCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Tb_discount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {

        }
        private void Dp_desrvedDate_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void input_LostFocus(object sender, RoutedEventArgs e)
        {

        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        private void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            //items

            Window.GetWindow(this).Opacity = 0.2;
            wd_items w = new wd_items();
            w.CardType = "sales";
            w.ShowDialog();
            if (w.isActive)
            {
                ////// this is ItemId
                ChangeItemIdEvent(w.selectedItem);
            }

            Window.GetWindow(this).Opacity = 1;
        }
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

            MainWindow.mainWindow.KeyDown -= HandleKeyPress;
            if (billDetails.Count > 0)
            {
                #region Accept
                MainWindow.mainWindow.Opacity = 0.2;
                wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                //w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                w.contentText = "Do you want save the quotation in drafts?";
                w.ShowDialog();
                MainWindow.mainWindow.Opacity = 1;
                #endregion
                if (w.isOk)
                    Btn_newDraft_Click(null, null);
                else
                    clearInvoice();
            }
        }

        private void Cb_company_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cb_company_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}

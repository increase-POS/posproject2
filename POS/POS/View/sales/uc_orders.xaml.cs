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
        string createPermission = "salesOrders_create";
        string deliveryPermission = "salesOrders_delivery";
        string reportsPermission = "salesOrders_reports";
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
        IEnumerable<Branch> branches;
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
        ShippingCompanies companyModel = new ShippingCompanies();
        List<ShippingCompanies> companies;
        User userModel = new User();
        List<User> users;
        #region//to handle barcode characters
        static private int _SelectedCustomer = -1;
        static private int _SelectedCompany = -1;
        static private int _SelectedUser = -1;
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
        static private decimal _DeliveryCost = 0;
        static private string _InvoiceType = "ord"; // order draft

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
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trQuantity");
            dg_billDetails.Columns[5].Header = MainWindow.resourcemanager.GetString("trPrice");
            dg_billDetails.Columns[6].Header = MainWindow.resourcemanager.GetString("trAmount");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_tax.Text = MainWindow.resourcemanager.GetString("trTax");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal");
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
            MainWindow.mainWindow.StartAwait();

            MainWindow.mainWindow.KeyDown += HandleKeyPress;
            tb_moneyIcon.Text = MainWindow.Currency;

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
            tb_moneyIcon.Text = MainWindow.Currency;
            tb_discountMoneyIcon.Text = MainWindow.Currency;



            translate();
            await RefrishItems();
            await RefrishCustomers();
            await fillBarcodeList();
            await fillCouponsList();
            SectionData.fillBranches(cb_branch, "bs");
            //await fillBranches();
            await fillShippingCompanies();
            await fillUsers();

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
            MainWindow.mainWindow.EndAwait();
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
        //async Task fillBranches()
        //{
        //    branches = await branchModel.GetBranchesActive("all");
        //    cb_branch.ItemsSource = branches;
        //    cb_branch.DisplayMemberPath = "name";
        //    cb_branch.SelectedValuePath = "branchId";
        //}
        async Task fillBarcodeList()
        {
            barcodesList = await itemUnitModel.Getall();
        }
        async Task fillCouponsList()
        {
            coupons = await couponModel.GetCouponsAsync();
        }
        private async Task fillShippingCompanies()
        {
            companies = await companyModel.Get();
            cb_company.ItemsSource = companies;
            cb_company.DisplayMemberPath = "name";
            cb_company.SelectedValuePath = "shippingCompanyId";
        }
        private async Task fillUsers()
        {
            users = await userModel.GetUsersActive();
            cb_user.ItemsSource = users;
            cb_user.DisplayMemberPath = "name";
            cb_user.SelectedValuePath = "userId";
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
        private async Task<bool> validateInvoiceValues()
        {
            bool valid = true;
            SectionData.validateEmptyComboBox(cb_customer, p_errorCustomer, tt_errorCustomer, "trEmptyCustomerToolTip");
            SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
            if (billDetails.Count == 0)
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trAddInvoiceWithoutItems"), animation: ToasterAnimation.FadeIn);

            if (cb_customer.SelectedIndex == -1 || billDetails.Count == 0
                || cb_branch.SelectedIndex == -1)
                valid = false;         
            if(valid)
                 valid = validateItemUnits();
            if (valid == true && _InvoiceType == "ord")
                valid = await checkItemsAmounts();
            return valid;
        }
        private bool validateItemUnits()
        {
            bool valid = true;
            for (int i = 0; i < billDetails.Count; i++)
            {
                if (billDetails[i].itemUnitId == 0)
                {
                    valid = false;
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trItemWithNoUnit"), animation: ToasterAnimation.FadeIn);

                    return valid;
                }
            }
            return valid;
        }
        private async void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {
                Boolean available = true;
                bool valid = validateItemUnits();

                if (billDetails.Count > 0 && available && valid )
            {
                await addInvoice(_InvoiceType);
                    clearInvoice();
                }
            else if (billDetails.Count == 0)
            {
                clearInvoice();
            }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
            _DeliveryCost = 0;
            _SelectedCustomer = -1;
            _InvoiceType = "ord";
            invoice = new Invoice();
            selectedCoupons.Clear();
            tb_barcode.Clear();
            cb_customer.SelectedIndex = -1;
            cb_customer.SelectedItem = "";
            dp_desrvedDate.Text = "";
            tb_note.Clear();
            txt_discount.Text = "";
            billDetails.Clear();
            tb_total.Text = "";
            tb_sum.Text = null;
            cb_company.SelectedIndex = -1;
            cb_company.SelectedItem = "";
            cb_user.SelectedIndex = -1;
            cb_user.SelectedItem = "";

            if (MainWindow.isInvTax == 1)
                tb_taxValue.Text = MainWindow.tax.ToString();
            else
                tb_taxValue.Text = "0";
            lst_coupons.Items.Clear();
            tb_discount.Text = "0";

            //btn_updateCustomer.IsEnabled = false;
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trSaleInvoice");
            SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
            refrishBillDetails();
            tb_barcode.Focus();
            inputEditable();
        }
        private void inputEditable()
        {
            switch (_InvoiceType)
            {
                case "ord": // quotation draft invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                    dg_billDetails.Columns[3].IsReadOnly = false; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                    cb_customer.IsEnabled = true;
                    cb_company.IsEnabled = true;
                    cb_user.IsEnabled = true;
                    dp_desrvedDate.IsEnabled = true;
                    tb_note.IsEnabled = true;
                    tb_barcode.IsEnabled = true;
                    tb_discount.IsEnabled = true;
                    btn_save.IsEnabled = true;
                    //btn_updateCustomer.IsEnabled = true;
                    tb_coupon.IsEnabled = true;
                    btn_clearCoupon.IsEnabled = true;
                    break;
                case "or": //quotation invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                    dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                    cb_customer.IsEnabled = false;
                    cb_company.IsEnabled = false;
                    cb_user.IsEnabled = false;
                    dp_desrvedDate.IsEnabled = false;
                    tb_note.IsEnabled = false;
                    tb_barcode.IsEnabled = false;
                    tb_discount.IsEnabled = false;
                    btn_save.IsEnabled = false;
                    //btn_updateCustomer.IsEnabled = false;
                    tb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
                    break;
                case "s": //sale invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                    dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                    cb_customer.IsEnabled = false;
                    cb_company.IsEnabled = false;
                    cb_user.IsEnabled = false;
                    dp_desrvedDate.IsEnabled = false;
                    tb_note.IsEnabled = false;
                    tb_barcode.IsEnabled = false;
                    tb_discount.IsEnabled = false;
                    btn_save.IsEnabled = true;
                    //btn_updateCustomer.IsEnabled = false;
                    tb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
                    break;
            }
        }
        private async Task addInvoice(string invType)
        {
            if (invoice.branchCreatorId == 0 || invoice.branchCreatorId == null)
            {
                invoice.branchCreatorId = MainWindow.branchID.Value;
                invoice.posId = MainWindow.posID.Value;
            }
            invoice.invType = invType;
            if (!tb_discount.Text.Equals(""))
                invoice.discountValue = decimal.Parse(tb_discount.Text);

            invoice.total = _Sum;
            invoice.totalNet = decimal.Parse(tb_total.Text);

            if (cb_customer.SelectedIndex != -1)
                invoice.agentId = (int)cb_customer.SelectedValue;

            invoice.deservedDate = dp_desrvedDate.SelectedDate;
            invoice.notes = tb_note.Text;

            if (cb_branch.SelectedIndex != -1)
                invoice.branchId = (int)cb_branch.SelectedValue;
            if (tb_taxValue.Text != "")
                invoice.tax = decimal.Parse(tb_taxValue.Text);
            else
                invoice.tax = 0;
            if (cb_company.SelectedIndex != -1)
                invoice.shippingCompanyId = (int)cb_company.SelectedValue;
            if (cb_user.SelectedIndex != -1)
                invoice.shipUserId = (int)cb_user.SelectedValue;
            invoice.createUserId = MainWindow.userID;
            invoice.updateUserId = MainWindow.userID;

            // build invoice NUM like storCode_PI_sequence exp: 123_PI_2
            if (invType == "or")
            {
                invoice.invNumber = await invoice.generateInvNumber("or");
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

                // save order status
               await saveOrderStatus(invoiceId , "pr");
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
            }
            else
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
        }
        private async Task saveOrderStatus(int invoiceId, string status)
        {
            invoiceStatus st = new invoiceStatus();
            st.status = status;
            st.invoiceId = invoiceId;
            st.createUserId = MainWindow.userLogin.userId;
            st.isActive = 1;
            await invoice.saveOrderStatus(st);
        }
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
                    int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == defaultsaleUnit.itemUnitId).FirstOrDefault());
                    decimal itemTax = 0;
                    if (item.taxes != null)
                        itemTax = (decimal)item.taxes;
                    // create new row in bill details data grid
                    if (index == -1)//item doesn't exist in bill
                        addRowToBill(item.name, itemId, defaultsaleUnit.mainUnit, defaultsaleUnit.itemUnitId, 1, (decimal)defaultsaleUnit.price, (decimal)defaultsaleUnit.price, itemTax);
                    else // item exist prevoiusly in list
                    {
                        billDetails[index].Count++;
                        billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;

                        _Sum += billDetails[index].Price;
                    }

                    refreshTotalValue();
                    refrishBillDetails();
                }
                else
                {
                    addRowToBill(item.name, itemId, null, 0, 1, 0, 0, (decimal)item.taxes);
                    //refreshTotalValue();
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
            decimal total = _Sum - _Discount + taxValue + _DeliveryCost;

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
                        if (tb.Name == "tb_note")// remove barcode from text box
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
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {
                // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

                w.invoiceType = "ord"; //draft order
                w.userId = MainWindow.userLogin.userId;
                w.duration = 2; // view drafts which updated during 2 last days 
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
        } else
            Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
		}

    private async Task fillInvoiceInputs(Invoice invoice)
        {
            _Sum = (decimal)invoice.total;
            if (invoice.tax != null)
                _Tax = (decimal)invoice.tax;
            cb_customer.SelectedValue = invoice.agentId;
            dp_desrvedDate.Text = invoice.deservedDate.ToString();
            if (invoice.totalNet != null)
                tb_total.Text = Math.Round((double)invoice.totalNet, 2).ToString();
            tb_taxValue.Text = invoice.tax.ToString();
            tb_note.Text = invoice.notes;
            tb_sum.Text = invoice.total.ToString();
            tb_discount.Text = invoice.discountValue.ToString();
            cb_company.SelectedValue = invoice.shippingCompanyId;
            cb_user.SelectedValue = invoice.shipUserId;
            tb_barcode.Clear();
            tb_barcode.Focus();

            await getInvoiceCoupons(invoice.invoiceId);
            // build invoice details grid
            await buildInvoiceDetails(invoice.invoiceId);
           // refreshTotalValue()
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
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") ||
                MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") ||
                SectionData.isAdminPermision())
            {
                // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

            // quontations invoices
            w.invoiceType = "or";
            w.userId = MainWindow.userLogin.userId;
                w.duration = 1; // view orders which updated during 1 last days 
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
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private async void Btn_waitConfirmUser_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(deliveryPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {
                // (((((((this.Parent as Grid).Parent as Grid).Parent as UserControl)).Parent as Grid).Parent as Grid).Parent as Window).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

            // quontations invoices
            w.invoiceType = "s";
            w.invoiceStatus = "ex";
            w.userId = MainWindow.userLogin.userId;

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
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private async void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;
            TextBlock tb;

            if (dg_billDetails.SelectedIndex != -1 && cmb != null)
            {
                billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;

                int itemUnitId = (int)cmb.SelectedValue;
                billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
                var unit = itemUnits.ToList().Find(x => x.itemUnitId == (int)cmb.SelectedValue);
                int availableAmount = await itemLocationModel.getAmountInBranch(itemUnitId, MainWindow.branchID.Value);

                int oldCount = 0;
                long newCount = 0;
                decimal oldPrice = 0;
                decimal newPrice = (decimal)unit.price;

                //"tb_amont"
                tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[dg_billDetails.SelectedIndex]) as TextBlock;
                tb.Text = availableAmount.ToString();

                oldCount = billDetails[dg_billDetails.SelectedIndex].Count;
                oldPrice = billDetails[dg_billDetails.SelectedIndex].Price;

                if (availableAmount < oldCount)
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableToolTip"), animation: ToasterAnimation.FadeIn);
                    newCount = availableAmount;
                    tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[dg_billDetails.SelectedIndex]) as TextBlock;
                    tb.Text = availableAmount.ToString();
                }
                else
                    newCount = oldCount;

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
                tb = dg_billDetails.Columns[6].GetCellContent(dg_billDetails.Items[dg_billDetails.SelectedIndex]) as TextBlock;
                tb.Text = total.ToString();

                //  refresh sum and total text box
                refreshTotalValue();

                // update item in billdetails           
                billDetails[dg_billDetails.SelectedIndex].Count = (int)newCount;
                billDetails[dg_billDetails.SelectedIndex].Price = newPrice;
                billDetails[dg_billDetails.SelectedIndex].Total = total;
                refrishBillDetails();
            }
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
                if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
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
                if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
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
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") ||
                MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || 
                SectionData.isAdminPermision())
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
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") ||
                SectionData.isAdminPermision())
            {
                //check mandatory inputs
                bool valid = await validateInvoiceValues();
            //Boolean available = true;
           // if (_InvoiceType == "ord") // draft order
                //available = await checkItemsAmounts();
            if (valid)
            {
                if (_InvoiceType == "s")
                    await saveOrderStatus(invoice.invoiceId,"tr");
                else
                    await addInvoice("or");//quontation invoice
                clearInvoice();   
            }
        } else
            Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
		}
    private void Btn_updateCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 100 && cb_customer.SelectedIndex != -1)
            {
                _SelectedCustomer = (int)cb_customer.SelectedValue;
            }
            else
            {
                cb_customer.SelectedValue = _SelectedCustomer;
            }
            //if (cb_customer.SelectedIndex != -1)
            //    btn_updateCustomer.IsEnabled = true;
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
            _Sender = sender;
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
            if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
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
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 100 && cb_company.SelectedIndex != -1)
            {
                _SelectedCompany = (int)cb_company.SelectedValue;
                companyModel = companies.Find(c => c.shippingCompanyId == (int)cb_company.SelectedValue);
                _DeliveryCost = (decimal)companyModel.deliveryCost;
                refreshTotalValue();

                if (companyModel.deliveryType == "local")
                {
                    cb_user.Visibility = Visibility.Visible;
                }
                else
                {
                    cb_user.SelectedIndex = -1;
                    cb_user.Visibility = Visibility.Collapsed;
                }
            }
            else if(cb_company.SelectedIndex == -1)
            {
                cb_company.SelectedItem = "";
            }  
            else
                cb_company.SelectedValue = _SelectedCompany;

        }

        private void Cb_company_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_note_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Sender = sender;
        }

        private void Cb_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 100 && cb_customer.SelectedIndex != -1)
            {
                _SelectedUser = (int)cb_user.SelectedValue;
            }
            else if (cb_customer.SelectedIndex == -1)
                cb_user.SelectedItem = "";
            else
            {
                cb_user.SelectedValue = _SelectedUser;
            }
        }

       

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {



            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {



            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
            {



            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }
       
    }
}

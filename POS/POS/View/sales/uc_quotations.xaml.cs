using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using System.Windows.Threading;
using static POS.View.uc_categorie;

namespace POS.View.sales
{
    /// <summary>
    /// Interaction logic for uc_quotations.xaml
    /// </summary>
    public partial class uc_quotations : UserControl
    {
        string createPermission = "quotation_create";
        string reportsPermission = "quotation_reports";
        private static uc_quotations _instance;
        public static uc_quotations Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_quotations();
                return _instance;
            }
        }
        public uc_quotations()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this);
            }
        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;

        Card cardModel = new Card();
        //IEnumerable<Card> cards;
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
        List<Invoice> invoices;

        Coupon couponModel = new Coupon();
        IEnumerable<Coupon> coupons;
        List<CouponInvoice> selectedCoupons = new List<CouponInvoice>();

        Pos posModel = new Pos();
        Pos pos;
        List<ItemTransfer> invoiceItems;
        ItemLocation itemLocationModel = new ItemLocation();
        public List<Control> controls;
        private static DispatcherTimer timer;

        #region//to handle barcode characters
        static private int _SelectedCustomer = -1;
        static private int _SelectedDiscountType = -1;

        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        static private string _BarcodeStr = "";
        static private object _Sender;
        bool _IsFocused = false;
        #endregion

        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;

        //for bill details
        static private int _SequenceNum = 0;
        static private int _invoiceId;
        static private decimal _Sum = 0;
        static private decimal _Tax = 0;
        static private decimal _Discount = 0;
        static private string _InvoiceType = "qd"; // quotation draft

        // for report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        #region bill
        public class BillDetails
        {
            public int ID { get; set; }
            public int itemId { get; set; }
            public int itemUnitId { get; set; }
            public int? offerId { get; set; }
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

            // MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trQuotations");
            txt_tax.Text = MainWindow.resourcemanager.GetString("trTax");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal");
            txt_coupon.Text = MainWindow.resourcemanager.GetString("trCoupon");
            txt_customer.Text = MainWindow.resourcemanager.GetString("trCustomer");
            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_printInvoice.Text = MainWindow.resourcemanager.GetString("trPrint");
            txt_preview.Text = MainWindow.resourcemanager.GetString("trPreview");
            txt_invoiceImages.Text = MainWindow.resourcemanager.GetString("trImages");
            txt_items.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_quotations.Text = MainWindow.resourcemanager.GetString("trQuotations");
            //txt_drafts.Text = MainWindow.resourcemanager.GetString("trDrafts");
            txt_newDraft.Text = MainWindow.resourcemanager.GetString("trNew");

            tt_error_previous.Content = MainWindow.resourcemanager.GetString("trPrevious");
            tt_error_next.Content = MainWindow.resourcemanager.GetString("trNext");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_barcode, MainWindow.resourcemanager.GetString("trBarcodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_customer, MainWindow.resourcemanager.GetString("trCustomerHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_coupon, MainWindow.resourcemanager.GetString("trCoponHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_typeDiscount, MainWindow.resourcemanager.GetString("trDiscountTypeHint"));

            btn_save.Content = MainWindow.resourcemanager.GetString("trSubmit");



        }
        #region loading

        List<keyValueBool> loadingList;

        async void loading_RefrishItems()
        {
            try
            {
                // your code
        await RefrishItems();
            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_RefrishItems"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_RefrishCustomers()
        {
            try
            {
                // your code
          await RefrishCustomers();
            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_RefrishCustomers"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_fillBarcodeList()
        {
            try
            {
                // your code
        await fillBarcodeList();
            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_fillBarcodeList"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_fillCouponsList()
        {
            try
            {
                // your code
            await fillCouponsList();
            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_fillCouponsList"))
                {
                    item.value = true;
                    break;
                }
            }
        }



        #endregion
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Window parentWin = Window.GetWindow(this);
                MainWindow.mainWindow.Closing += ParentWin_Closing;
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                MainWindow.mainWindow.KeyDown += HandleKeyPress;
                tb_moneyIcon.Text = MainWindow.Currency;
                tb_moneyIconTotal.Text = MainWindow.Currency;
                tb_moneyIconDis.Text = MainWindow.Currency;
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }

                translate();
                configureDiscountType();
                setTimer();
                refreshDraftNotification();

                #region loading
                loadingList = new List<keyValueBool>();
                bool isDone = true;
                loadingList.Add(new keyValueBool { key = "loading_RefrishItems", value = false });
                loadingList.Add(new keyValueBool { key = "loading_RefrishCustomers", value = false });
                loadingList.Add(new keyValueBool { key = "loading_fillBarcodeList", value = false });
                loadingList.Add(new keyValueBool { key = "loading_fillCouponsList", value = false });



                loading_RefrishItems();
                loading_RefrishCustomers();
                loading_fillBarcodeList();
                loading_fillCouponsList();

                do
                {
                    isDone = true;
                    foreach (var item in loadingList)
                    {
                        if (item.value == false)
                        {
                            isDone = false;
                            break;
                        }
                    }
                    if (!isDone)
                    {
                        //MessageBox.Show("not done");
                        //string s = "";
                        //foreach (var item in loadingList)
                        //{
                        //    s += item.name + " - " + item.value + "\n";
                        //}
                        //MessageBox.Show(s);
                        await Task.Delay(0500);
                        //MessageBox.Show("do");
                    }
                }
                while (!isDone);
                #endregion
               

                //pos = await posModel.getById(MainWindow.posID.Value);
                pos = MainWindow.posLogIn;
                //List all the UIElement in the VisualTree
                controls = new List<Control>();
                FindControl(this.grid_main, controls);
                #region Style Date
                //SectionData.defaultDatePickerStyle(dp_desrvedDate);
                #endregion

                //tb_taxValue.Text = MainWindow.tax.ToString();
                //tb_taxValue.Text = SectionData.DecTostring(MainWindow.tax);
                if (MainWindow.tax == 0)
                    sp_tax.Visibility = Visibility.Collapsed;
                else
                {
                    tb_taxValue.Text = SectionData.DecTostring(MainWindow.tax);
                    sp_tax.Visibility = Visibility.Visible;
                }
                #region datagridChange
                //CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
                //((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
                #endregion
                #region print - pdf - send email
                btn_printInvoice.Visibility = Visibility.Collapsed;
                btn_pdf.Visibility = Visibility.Collapsed; 
                #endregion
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                tb_barcode.Focus();
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void ParentWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //isClose = true;
            //UserControl_Unloaded(this, null);
        }
        public void FindControl(DependencyObject root, List<Control> controls)
        {
            controls.Clear();
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var control = current as Control;
                if (control != null && control.IsTabStop)
                {
                    controls.Add(control);
                }
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    if (child != null)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }
        #region timer to refresh notifications
        private void setTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private async void timer_Tick(object sendert, EventArgs et)
        {
            try
            {
                if (invoice.invoiceId != 0)
                    refreshDocCount(invoice.invoiceId);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        #region notifications
        private async void refreshDraftNotification()
        {
            string invoiceType = "qd";
            int duration = 2;
            int draftCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);
            if (_InvoiceType == "qd"  && invoice.invoiceId != 0)
                draftCount--;

            int previouseCount = 0;
            if (md_draft.Badge != null && md_draft.Badge.ToString() != "") previouseCount = int.Parse(md_draft.Badge.ToString());

            if (draftCount != previouseCount)
            {
                if (draftCount > 9)
                {
                    draftCount = 9;
                    md_draft.Badge = "+" + draftCount.ToString();
                }
                else if (draftCount == 0) md_draft.Badge = "";
                else
                    md_draft.Badge = draftCount.ToString();
            }
        }
        private async void refreshDocCount(int invoiceId)
        {
            DocImage doc = new DocImage();
            int docCount = await doc.GetDocCount("Invoices", invoiceId);

            int previouseCount = 0;
            if (md_docImage.Badge != null && md_docImage.Badge.ToString() != "") previouseCount = int.Parse(md_docImage.Badge.ToString());

            if (docCount != previouseCount)
            {
                if (docCount > 9)
                {
                    docCount = 9;
                    md_docImage.Badge = "+" + docCount.ToString();
                }
                else if (docCount == 0) md_docImage.Badge = "";
                else
                    md_docImage.Badge = docCount.ToString();
            }
        }
        #endregion
        private void configureDiscountType()
        {
            var dislist = new[] {
            new { Text = "", Value = -1 },
            new { Text = MainWindow.resourcemanager.GetString("trValueDiscount"), Value = 1 },
            new { Text = MainWindow.resourcemanager.GetString("trPercentageDiscount"), Value = 2 },
             };

            cb_typeDiscount.DisplayMemberPath = "Text";
            cb_typeDiscount.SelectedValuePath = "Value";
            cb_typeDiscount.ItemsSource = dislist;
            cb_typeDiscount.SelectedIndex = 0;
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
           // barcodesList = await itemUnitModel.Getall();
            barcodesList = await itemUnitModel.GetUnitsForSales(MainWindow.branchID.Value);
        }
        async Task fillCouponsList()
        {
            coupons = await couponModel.GetEffictiveCoupons();

            cb_coupon.DisplayMemberPath = "name";
            cb_coupon.SelectedValuePath = "cId";
            cb_coupon.ItemsSource = coupons;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);

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
                //refrishBillDetails();
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        #region coupon
         
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
                case "qt":// this barcode for invoice

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
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trQuotations");
                        }
                        await fillInvoiceInputs(invoice);
                    }
                    break;
                case "cop":// this barcode for coupon
                    {
                        //await fillCouponsList();
                        couponModel = coupons.ToList().Find(c => c.barcode == barcode);
                        var exist = selectedCoupons.Find(c => c.couponId == couponModel.cId);
                        if (couponModel != null && exist == null)
                        {
                            if (couponModel.remainQ > 0 && couponModel.endDate >= DateTime.Now && couponModel.startDate <= DateTime.Now && _Sum >= couponModel.invMin && _Sum <= couponModel.invMax)
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
                            else if (_Sum < couponModel.invMin)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorMinInvToolTip"), animation: ToasterAnimation.FadeIn);
                            else if (_Sum > couponModel.invMax)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorMaxInvToolTip"), animation: ToasterAnimation.FadeIn);
                        }
                        else
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorCouponExist"), animation: ToasterAnimation.FadeIn);
                        }
                        cb_coupon.SelectedIndex = -1;
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
                                      addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count, price, total, tax,item.offerId);
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                _Discount = 0;
                selectedCoupons.Clear();
                lst_coupons.Items.Clear();
                cb_coupon.SelectedIndex = -1;
                refreshTotalValue();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        #region Categor and Item 
        
        #region Get Id By Click  Y
        public void ChangeCategorieIdEvent(int categoryId)
        {
         }
        public void testChangeCategorieItemsIdEvent()
        {
         }
        #endregion

        #endregion
        private   bool  validateInvoiceValues()
        {
            bool valid = true;
            if (!SectionData.validateEmptyComboBox(cb_customer, p_errorCustomer, tt_errorCustomer, "trEmptyCustomerToolTip"))
                exp_customer.IsExpanded = true;
            if (billDetails.Count == 0)
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trAddInvoiceWithoutItems"), animation: ToasterAnimation.FadeIn);

            if (billDetails.Count == 0 || cb_customer.SelectedIndex == -1)
            {
                valid = false;
                 return valid;
            }
            valid = validateItemUnits();
            //if (_InvoiceType == "qd" && valid)
            //    valid = await checkItemsAmounts();
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                
                bool valid = validateItemUnits();
                if (billDetails.Count > 0 )
                {
                    await addInvoice(_InvoiceType);
                }
                else if (billDetails.Count == 0)
                {
                    clearInvoice();
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async Task clearInvoice()
        {
            _Sum = 0;
            txt_invNumber.Text = "";
            _Discount = 0;
            _SequenceNum = 0;
            _SelectedCustomer = -1;
            _SelectedDiscountType = 0;
            _InvoiceType = "qd";
            invoice = new Invoice();
            selectedCoupons.Clear();
            tb_barcode.Clear();
            cb_customer.SelectedIndex = -1;
            cb_customer.SelectedItem = "";
            tb_note.Clear();
            tb_totalDescount.Text = "0";
            billDetails.Clear();
            tb_total.Text = "0";
            tb_sum.Text = "0";
            tb_discount.Clear();
            cb_typeDiscount.SelectedIndex = 0;
            //tb_taxValue.Text = MainWindow.tax.ToString();
            tb_taxValue.Text = SectionData.DecTostring(MainWindow.tax);
            md_docImage.Badge = "";
            tgl_ActiveOffer.IsChecked = false;
            lst_coupons.Items.Clear();
            md_docImage.Badge = "";

            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trQuotations");
            SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);

            refrishBillDetails();
            tb_barcode.Focus();
            inputEditable();
            btn_next.Visibility = Visibility.Collapsed;
            btn_previous.Visibility = Visibility.Collapsed;
            btn_deleteInvoice.Visibility = Visibility.Collapsed;
            await fillCouponsList();
        }
        private void inputEditable()
        {
            switch (_InvoiceType)
            {
                case "qd": // quotation draft invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                    dg_billDetails.Columns[3].IsReadOnly = false; //make unit read only
                    dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                    dg_billDetails.Columns[5].IsReadOnly = false; //make price read only
                    tb_discount.IsEnabled = true;
                    cb_typeDiscount.IsEnabled = true;
                    cb_customer.IsEnabled = true;
                    tb_note.IsEnabled = true;
                    tb_barcode.IsEnabled = true;
                    btn_save.IsEnabled = true;
                    cb_coupon.IsEnabled = true;
                    btn_clearCoupon.IsEnabled = true;
                    tgl_ActiveOffer.IsEnabled = true;
                    btn_deleteInvoice.Visibility = Visibility.Visible;
                    break;
                case "q": //quotation invoice
                    dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                    dg_billDetails.Columns[3].IsReadOnly = true; //خ price read only
                    tb_discount.IsEnabled = false;
                    cb_typeDiscount.IsEnabled = false;
                    cb_customer.IsEnabled = false;
                    tb_note.IsEnabled = false;
                    tb_barcode.IsEnabled = false;
                    btn_save.IsEnabled = false;
                    cb_coupon.IsEnabled = false;
                    btn_clearCoupon.IsEnabled = false;
                    tgl_ActiveOffer.IsEnabled = false;
                    btn_deleteInvoice.Visibility = Visibility.Collapsed;
                    break;
            }
            if (_InvoiceType.Equals("q"))
            {
                #region print - pdf - send email
                btn_printInvoice.Visibility = Visibility.Visible;
                btn_pdf.Visibility = Visibility.Visible;
                #endregion
            }
            else
            {
                #region print - pdf - send email
                btn_printInvoice.Visibility = Visibility.Collapsed;
                btn_pdf.Visibility = Visibility.Collapsed;
                #endregion
            }
            btn_next.Visibility = Visibility.Visible;
            btn_previous.Visibility = Visibility.Visible;
        }
        private async Task addInvoice(string invType)
        {           
            if (invoice.branchCreatorId == 0 || invoice.branchCreatorId == null)
            {
                invoice.branchCreatorId = MainWindow.branchID.Value;
                invoice.posId = MainWindow.posID.Value;
            }
            invoice.invType = invType;
            invoice.discountValue = _Discount;
            invoice.discountType = "1";
            invoice.total = _Sum;
            invoice.totalNet = decimal.Parse(tb_total.Text);
           
            if (cb_customer.SelectedIndex != -1)
                invoice.agentId = (int)cb_customer.SelectedValue;

            invoice.notes = tb_note.Text;

            if (tb_taxValue.Text != "")
                invoice.tax = decimal.Parse(tb_taxValue.Text);
            else
                invoice.tax = 0;
            if (cb_typeDiscount.SelectedIndex != -1)
                invoice.manualDiscountType = cb_typeDiscount.SelectedValue.ToString();
            if (tb_discount.Text != "")
                invoice.manualDiscountValue = decimal.Parse(tb_discount.Text);
            invoice.createUserId = MainWindow.userID;
            invoice.updateUserId = MainWindow.userID;

            // build invoice NUM 
            if (invType == "q")
            {
                invoice.invNumber = await invoice.generateInvNumber("qt", MainWindow.loginBranch.code, MainWindow.branchID.Value);
            }
            else if (invType == "qd" && invoice.invoiceId == 0)
                invoice.invNumber = await invoice.generateInvNumber("qtd", MainWindow.loginBranch.code, MainWindow.branchID.Value);

            byte isApproved = 0;
            if (tgl_ActiveOffer.IsChecked == true)
                isApproved = 1;
            else
                isApproved = 0;
            invoice.isApproved = isApproved;
            // save invoice in DB
            int invoiceId = await invoiceModel.saveInvoice(invoice);

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
                    itemT.offerId = billDetails[i].offerId;
                    invoiceItems.Add(itemT);
                }
                await invoiceModel.saveInvoiceItems(invoiceItems, invoiceId);               
            }
            clearInvoice();
            refreshDraftNotification();
        }

        #region Get Id By Click  Y
        public void ChangeItemIdEvent(int itemId)
        {
            if (items != null) item = items.ToList().Find(c => c.itemId == itemId);

            if (item != null)
            {
                // get item units
               // itemUnits = await itemUnitModel.GetItemUnits(item.itemId);
                itemUnits = MainWindow.InvoiceGlobalItemUnitsList.Where(a => a.itemId == item.itemId).ToList();
                // search for default unit for purchase
                var defaultsaleUnit = itemUnits.ToList().Find(c => c.defaultSale == 1);
                if (defaultsaleUnit != null)
                {
                    decimal itemTax = 0;
                    if (item.taxes != null)
                        itemTax = (decimal)item.taxes;
                    decimal price = (decimal)defaultsaleUnit.price + SectionData.calcPercentage((decimal)defaultsaleUnit.price, itemTax);
                    // create new row in bill details data grid
                    addRowToBill(item.name, itemId, defaultsaleUnit.mainUnit, defaultsaleUnit.itemUnitId, 1, price, (decimal)defaultsaleUnit.price, itemTax,item.offerId);
                }
                else
                {
                      addRowToBill(item.name, itemId, null, 0, 1, 0, 0, (decimal)item.taxes,item.offerId);
                }
                //refreshTotalValue();
                //refrishBillDetails();
            }
        }
        private void refreshTotalValue()
        {
            _Discount = 0;
            decimal manualDiscount = 0;
            decimal totalDiscount = 0;
            if (_Sum > 0)
            {
                #region calculate discount value
                foreach (CouponInvoice coupon in selectedCoupons)
                {
                    string discountType = coupon.discountType.ToString();
                    decimal discountValue = (decimal)coupon.discountValue;
                    if (discountType == "2")
                        discountValue = SectionData.calcPercentage(_Sum, discountValue);
                    _Discount += discountValue;
                }
                #endregion
                #region manaula discount           
                if (cb_typeDiscount.SelectedIndex != -1 && cb_typeDiscount.SelectedIndex != 0 && tb_discount.Text != "")
                {
                    int manualDisType = cb_typeDiscount.SelectedIndex;
                    manualDiscount = decimal.Parse(tb_discount.Text);
                    if (manualDisType == 2)
                        manualDiscount = SectionData.calcPercentage(_Sum, manualDiscount);
                }
                #endregion
                totalDiscount = _Discount + manualDiscount;
            }
                decimal taxValue = _Tax;
            decimal total = _Sum - totalDiscount;
            
            taxValue = SectionData.calcPercentage(total, (decimal)MainWindow.tax);
            
            total += taxValue;
            if (_Sum != 0)
                tb_sum.Text = SectionData.DecTostring(_Sum);
            else
                tb_sum.Text = "0";

            if (total != 0)
                tb_total.Text = SectionData.DecTostring(total);
            else
                tb_total.Text = "0";

            if (totalDiscount != 0)
                tb_totalDescount.Text = SectionData.DecTostring(totalDiscount);
            else
                tb_totalDescount.Text = "0";
        }
        #endregion
        #region billdetails
        bool firstTimeForDatagrid = true;

       async void refrishBillDetails()
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

            if (firstTimeForDatagrid)
            {
                await Task.Delay(1000);
                dg_billDetails.Items.Refresh();
                firstTimeForDatagrid = false;
            }
            DataGrid_CollectionChanged(dg_billDetails, null);
            // tb_sum.Text = _Sum.ToString();
            if (_Sum != 0)
                tb_sum.Text = SectionData.DecTostring(_Sum);
            else tb_sum.Text = "0";

            //if (MainWindow.isInvTax == 0)
            //    //tb_taxValue.Text = _Tax.ToString();
            //    tb_taxValue.Text = SectionData.DecTostring(_Tax);

        }
        void refrishDataGridItems()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;
            dg_billDetails.Items.Refresh();
            DataGrid_CollectionChanged(dg_billDetails, null);
        }

        // read item from barcode
        private async void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (!_IsFocused )
                {
                    Control c = CheckActiveControl();
                    if (c == null)
                        tb_barcode.Focus();
                    _IsFocused = true;
                }
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                
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
                            if (tb.Name == "tb_name" || tb.Name == "tb_note" || tb.Name == "tb_discount")// remove barcode from text box
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
                    _IsFocused = false;
                }
                _Sender = null;
                _BarcodeStr = "";
                
                if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
                {
                    switch (e.Key)
                    {
                        case Key.P:
                            //handle P key
                            Btn_printInvoice_Click(null, null);
                            break;
                        case Key.S:
                            //handle S key
                            Btn_save_Click(btn_save, null);
                            break;
                        case Key.I:
                            //handle S key
                            Btn_items_Click(null, null);
                            break;
                    }
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        public Control CheckActiveControl()
        {
            for (int i = 0; i < controls.Count; i++)
            {
                Control c = controls[i];
                if (c.IsFocused)
                {
                    return c;
                }
            }
            return null;
        }
        private async void Tb_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (e.Key == Key.Return)
                {
                    string barcode = "";
                    if (tb_barcode.Text.Length <= 13)
                    {
                        barcode = tb_barcode.Text;
                        await dealWithBarcode(barcode);
                    }
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private   void addRowToBill(string itemName, int itemId, string unitName, int itemUnitId, int count, decimal price, decimal total, decimal tax, int? offerId)
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
                offerId = offerId,
            });
            _Sum += total;
            _Tax += tax;
        }
        #endregion billdetails
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                Window.GetWindow(this).Opacity = 0.2;

                wd_invoice w = new wd_invoice();
                string invoiceType = "qd";
                int duration = 2;
                w.invoiceType = invoiceType; //quontations draft invoices
                w.userId = MainWindow.userLogin.userId;
                w.duration = duration; // view drafts which updated during 2 last days 
                w.title = MainWindow.resourcemanager.GetString("trDrafts");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;

                        _InvoiceType = invoice.invType;
                        _invoiceId = invoice.invoiceId;
                        refreshDraftNotification();
                        refreshDocCount(invoice.invoiceId);
                        // set title to bill
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trQuotationsDraft");

                        await fillInvoiceInputs(invoice);
                        invoices = await invoice.GetInvoicesByCreator(invoiceType, MainWindow.userID.Value, duration);
                        navigateBtnActivate();
                    }
                }
                Window.GetWindow(this).Opacity = 1;

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async Task fillInvoiceInputs(Invoice invoice)
        {
            _Sum = (decimal)invoice.total;
            txt_invNumber.Text = invoice.invNumber.ToString();
            if (invoice.tax != null)
                _Tax = (decimal)invoice.tax;

            cb_customer.SelectedValue = invoice.agentId;
            if (invoice.totalNet != null)
            {
                //tb_total.Text = Math.Round((double)invoice.totalNet, 2).ToString();
                if ((decimal)invoice.totalNet != 0)
                    tb_total.Text = SectionData.DecTostring((decimal)invoice.totalNet);
                else tb_total.Text = "0";
            }
            //tb_taxValue.Text = invoice.tax.ToString();
            tb_taxValue.Text = SectionData.DecTostring(_Tax);

            tb_note.Text = invoice.notes;
            //tb_sum.Text = invoice.total.ToString();
            if (invoice.total != 0)
                tb_sum.Text = SectionData.DecTostring(invoice.total);
            else
                tb_sum.Text = "0";

            if (invoice.manualDiscountValue != 0)
                tb_discount.Text = SectionData.DecTostring(invoice.manualDiscountValue);
            else
                tb_discount.Text = "0";
            if (invoice.manualDiscountType == "1")
                cb_typeDiscount.SelectedIndex = 1;
            else if (invoice.manualDiscountType == "2")
                cb_typeDiscount.SelectedIndex = 2;

            if (invoice.isApproved == 1)
                tgl_ActiveOffer.IsChecked = true;
            else
                tgl_ActiveOffer.IsChecked = false;

            tb_barcode.Clear();
            tb_barcode.Focus();

            await getInvoiceCoupons(invoice.invoiceId);
            // build invoice details grid
            await buildInvoiceDetails(invoice.invoiceId);
            inputEditable();
            refreshTotalValue();
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
        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                if (name == "ComboBox")
                {
                    if ((sender as ComboBox).Name == "cb_customer")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCustomer, tt_errorCustomer, "trEmptyCustomerToolTip");
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_quotations_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                saveBeforeExit();
                 Window.GetWindow(this).Opacity = 0.2;
                 wd_invoice w = new wd_invoice();

                // quontations invoices
                string invoiceType = "q";
                w.invoiceType = invoiceType;
                int duration = 1;
                w.userId = MainWindow.userLogin.userId;
                w.duration = duration; // view quotations which updated during 1 last days 
                w.title = MainWindow.resourcemanager.GetString("trQuotations");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;

                        _InvoiceType = invoice.invType;
                        refreshDocCount(invoice.invoiceId);
                        // set title to bill
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trQuotations");

                        await fillInvoiceInputs(invoice);
                        invoices = await invoice.GetInvoicesByCreator(invoiceType, MainWindow.userID.Value, duration);
                        navigateBtnActivate();
                    }
                }
                Window.GetWindow(this).Opacity =1;
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);
                var cmb = sender as ComboBox;
                TextBlock tb;

                if (dg_billDetails.SelectedIndex != -1 && cmb != null)
                {
                    int _datagridSelectedIndex = dg_billDetails.SelectedIndex;
                    billDetails[_datagridSelectedIndex].itemUnitId = (int)cmb.SelectedValue;
                    int itemUnitId = (int)cmb.SelectedValue;
                    billDetails[_datagridSelectedIndex].itemUnitId = (int)cmb.SelectedValue;
                    //var unit = itemUnits.ToList().Find(x => x.itemUnitId == (int)cmb.SelectedValue);
                    var unit = await itemUnitModel.GetById((int)cmb.SelectedValue);
                    //int availableAmount = await itemLocationModel.getAmountInBranch(itemUnitId, MainWindow.branchID.Value);

                    int oldCount = 0;
                    long newCount = 0;
                    decimal oldPrice = 0;
                    decimal itemTax = 0;
                    if (item.taxes != null)
                        itemTax = (decimal)item.taxes;
                    decimal price = (decimal)unit.price + SectionData.calcPercentage((decimal)unit.price, itemTax);
                    //decimal newPrice = (decimal)unit.price;
                    decimal newPrice = price;

                    //"tb_amont"
                    tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[_datagridSelectedIndex]) as TextBlock;
                    //tb.Text = availableAmount.ToString();

                    oldCount = billDetails[_datagridSelectedIndex].Count;
                    oldPrice = billDetails[_datagridSelectedIndex].Price;

                    //if (availableAmount < oldCount)
                    //{
                    //    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountNotAvailableToolTip"), animation: ToasterAnimation.FadeIn);
                    //    newCount = availableAmount;
                    //    tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[_datagridSelectedIndex]) as TextBlock;
                    //    tb.Text = availableAmount.ToString();
                    //}
                    //else
                        newCount = oldCount;

                    // old total for changed item
                    decimal total = oldPrice * oldCount;
                    _Sum -= total;


                    // new total for changed item
                    total = newCount * newPrice;
                    _Sum += total;

                   
                    // old tax for changed item
                    decimal tax = (decimal)itemTax * oldCount;
                    _Tax -= tax;
                    // new tax for changed item
                    tax = (decimal)itemTax * newCount;
                    _Tax += tax;


                    //refresh Price cell
                    tb = dg_billDetails.Columns[5].GetCellContent(dg_billDetails.Items[_datagridSelectedIndex]) as TextBlock;
                    tb.Text = newPrice.ToString();

                    //refresh total cell
                    tb = dg_billDetails.Columns[6].GetCellContent(dg_billDetails.Items[_datagridSelectedIndex]) as TextBlock;
                    tb.Text = total.ToString();

                    //  refresh sum and total text box
                    refreshTotalValue();

                    // update item in billdetails           
                    billDetails[_datagridSelectedIndex].Count = (int)newCount;
                    billDetails[_datagridSelectedIndex].Price = newPrice;
                    billDetails[_datagridSelectedIndex].Total = total;
                    //refrishBillDetails();
                }
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Cbm_unitItemDetails_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //billDetails
                if (billDetails.Count == 1)
                {
                    var cmb = sender as ComboBox;
                    cmb.SelectedValue = (int)billDetails[0].itemUnitId;
                }

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                //billDetails
                int count = 0;
                foreach (var item in billDetails)
                {
                    if (dg_billDetails.Items.Count != 0)
                    {
                        if (dg_billDetails.Items.Count > 1)
                        {
                            DataGridCell cell = null;
                            try
                            {
                                cell = DataGridHelper.GetCell(dg_billDetails, count, 3);
                            }
                            catch
                            { }
                            if (cell != null)
                            {
                                var cp = (ContentPresenter)cell.Content;
                                var combo = (ComboBox)cp.ContentTemplate.FindName("cbm_unitItemDetails", cp);
                                //var combo = (combo)cell.Content;
                                combo.SelectedValue = (int)item.itemUnitId;
                            }
                        }

                    }
                count++;
                }

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Dg_billDetails_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (_InvoiceType == "qd" )
                e.Cancel = false;
            else if (_InvoiceType == "q" )
                e.Cancel = true;
        }
        private   void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);
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
                    if (newCount < 0)
                    {
                        newCount = 0;
                        t.Text = "0";
                    }
                    oldCount = row.Count;
                     

                    if (columnName == MainWindow.resourcemanager.GetString("trPrice"))
                        newPrice = decimal.Parse(t.Text);
                    else
                        newPrice = row.Price;
                    if (newPrice < 0)
                    {
                        newPrice = 0;
                        t.Text = "0";
                    }
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
                //refrishDataGridItems();
                }
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_invoiceImages_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (invoice != null && invoice.invoiceId != 0)
                    {
                Window.GetWindow(this).Opacity = 0.2;

                        wd_uploadImage w = new wd_uploadImage();

                        w.tableName = "invoices";
                        w.tableId = invoice.invoiceId;
                        w.docNum = invoice.invNumber;
                        w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trChooseInvoiceToolTip"), animation: ToasterAnimation.FadeIn);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    //check mandatory inputs
                    bool valid =   validateInvoiceValues();

                    if (billDetails.Count > 0 && valid)
                    {
                        string type = "";
                        if (tgl_ActiveOffer.IsChecked == true)
                            type = "q";
                        else
                            type = "qd";
                        //await addInvoice("q");//quontation invoice
                        await addInvoice(type);//quontation invoice

                        if (invoice.invoiceId == 0)
                            clearInvoice();
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

       
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                SectionData.InputJustNumber(ref textBox);
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //items
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_items w = new wd_items();
                    w.CardType = "order";
                    w.ShowDialog();
                    if (w.isActive)
                    {
                        for (int i = 0; i < w.selectedItems.Count; i++)
                        {
                            int itemId = w.selectedItems[i];
                            ChangeItemIdEvent(itemId);
                        }
                        refreshTotalValue();
                        refrishBillDetails();
                    }

                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.KeyDown -= HandleKeyPress;

                saveBeforeExit();
                timer.Stop();
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                //SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void saveBeforeExit()
        {
            if (billDetails.Count > 0 && _InvoiceType == "qd")
            {
                #region Accept
                MainWindow.mainWindow.Opacity = 0.2;
                wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                w.contentText = MainWindow.resourcemanager.GetString("trSaveQuotationNotification");

                w.ShowDialog();
                MainWindow.mainWindow.Opacity = 1;
                #endregion
                if (w.isOk  )
                    Btn_newDraft_Click(null, null);
                else
                {
                    await clearInvoice();
                    refreshDraftNotification();
                }
            }
            else
            {
                await clearInvoice();
                refreshDraftNotification();
            }
        }
        private async void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //await printInvoice();
                ///////////////////////////////////
                Thread t1 = new Thread(() =>
                {
                    printInvoice();
                });
                t1.Start();
                //////////////////////////////////
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }

        }

        Invoice prInvoice = new Invoice();
        public static int itemscount;
        public static int width;
        public static int height;
        public async void printInvoice()
        {

            prInvoice = new Invoice();
            prInvoice = await invoiceModel.GetByInvoiceId(invoice.invoiceId);

            if (prInvoice.invType == "pd" || prInvoice.invType == "sd" || prInvoice.invType == "qd"
                || prInvoice.invType == "sbd" || prInvoice.invType == "pbd"
                || prInvoice.invType == "ord" || prInvoice.invType == "imd" || prInvoice.invType == "exd")
            {
                this.Dispatcher.Invoke(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintDraftInvoice"), animation: ToasterAnimation.FadeIn);
                });
            }
            else
            {

                List<ReportParameter> paramarr = new List<ReportParameter>();

                if (prInvoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(prInvoice.invoiceId);
                    itemscount = invoiceItems.Count();
                    string reppath = reportclass.GetreceiptInvoiceRdlcpath(prInvoice);

                    User employ = new User();
                    employ = await userModel.getUserById((int)prInvoice.updateUserId);
                    prInvoice.uuserName = employ.name;
                    prInvoice.uuserLast = employ.lastname;
                    if (prInvoice.agentId != null)
                    {
                        Agent agentinv = new Agent();

                        agentinv = customers.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();

                        prInvoice.agentCode = agentinv.code;
                        //new lines
                        prInvoice.agentName = agentinv.name;
                        prInvoice.agentCompany = agentinv.company;

                    }
                    else
                    {
                        prInvoice.agentCode = "-";
                        prInvoice.agentName = "-";
                        prInvoice.agentCompany = "-";
                    }
                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)prInvoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        prInvoice.branchName = branch.name;
                    }

                    ReportCls.checkLang();

                    foreach (var i in invoiceItems)
                    {
                        i.price = decimal.Parse(SectionData.DecTostring(i.price));
                    }
                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                    // clsReports.purchaseInvoiceReport(newl, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillSaleInvReport(prInvoice, paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();
                    //this.Dispatcher.Invoke(() =>
                    //{
                    //    if (MainWindow.salePaperSize == "A4")
                    //    {
                    //        LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.sale_printer_name, short.Parse(MainWindow.sale_copy_count));

                    //    }
                    //    else
                    //    {
                    //        LocalReportExtensions.customPrintToPrinter(rep, MainWindow.sale_printer_name, short.Parse(MainWindow.sale_copy_count), width, height);

                    //    }
                    //});
                    this.Dispatcher.Invoke(() =>
                    {
                        LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
                    });

                }
                else
                {

                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintEmptyInvoice"), animation: ToasterAnimation.FadeIn);
                }
            }
        }
        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                
                /////////////////////////////////////
                Thread t1 = new Thread(() =>
                {
                    pdfPurInvoice();
                });
                t1.Start();
                //////////////////////////////////////

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        public async void pdfPurInvoice()
        {
            if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
                         || invoice.invType == "sbd" || invoice.invType == "pbd"
                         || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
            {
                this.Dispatcher.Invoke(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintDraftInvoice"), animation: ToasterAnimation.FadeIn);
                });
            }
            else
            {

                List<ReportParameter> paramarr = new List<ReportParameter>();


                if (invoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);

                    User employ = new User();
                    employ = await userModel.getUserById((int)invoice.updateUserId);
                    invoice.uuserName = employ.name;
                    invoice.uuserLast = employ.lastname;
                    //  agentinv = customers.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                    //  invoice.agentCode = agentinv.code;
                    if (invoice.agentId != null)
                    {
                        Agent agentinv = new Agent();
                        agentinv = customers.Where(X => X.agentId == invoice.agentId).FirstOrDefault();


                        invoice.agentCode = agentinv.code;
                        //new lines
                        invoice.agentName = agentinv.name;
                        invoice.agentCompany = agentinv.company;
                    }
                    else
                    {
                        invoice.agentCode = "-";
                        invoice.agentName = "-";
                        invoice.agentCompany = "-";
                    }
                    string reppath = reportclass.GetreceiptInvoiceRdlcpath(invoice);
                    ReportCls.checkLang();
                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        invoice.branchName = branch.name;
                    }
                    foreach (var i in invoiceItems)
                    {
                        i.price = decimal.Parse(SectionData.DecTostring(i.price));
                    }
                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillSaleInvReport(invoice, paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();
                    this.Dispatcher.Invoke(() =>
                    {
                        saveFileDialog.Filter = "PDF|*.pdf;";

                        if (saveFileDialog.ShowDialog() == true)
                        {

                            string filepath = saveFileDialog.FileName;
                            LocalReportExtensions.ExportToPDF(rep, filepath);
                        }
                    });
                }

            }
        }

        User userModel = new User();
        private async void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    if (invoice.invoiceId > 0)
                    {
                        Window.GetWindow(this).Opacity = 0.2;

                        List<ReportParameter> paramarr = new List<ReportParameter>();
                        string pdfpath;

                        //
                        pdfpath = @"\Thumb\report\temp.pdf";
                        pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                        string reppath = reportclass.GetreceiptInvoiceRdlcpath(invoice);
                        if (invoice.invoiceId > 0)
                        {
                            User employ = new User();
                            employ = await userModel.getUserById((int)invoice.updateUserId);
                            invoice.uuserName = employ.name;
                            invoice.uuserLast = employ.lastname;

                            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                            if (invoice.agentId != null)
                            {
                                Agent agentinv = new Agent();
                                agentinv = customers.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                                invoice.agentCode = agentinv.code;
                                //new lines
                                invoice.agentName = agentinv.name;
                                invoice.agentCompany = agentinv.company;
                            }
                            else
                            {
                                invoice.agentCode = "-";
                                invoice.agentName = "-";
                                invoice.agentCompany = "-";
                            }
                            //branch name
                            Branch branch = new Branch();
                            branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                            if (branch.branchId > 0)
                            {
                                invoice.branchName = branch.name;
                            }

                            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                            ReportCls.checkLang();
                            foreach (var i in invoiceItems)
                            {
                                i.price = decimal.Parse(SectionData.DecTostring(i.price));
                            }
                            clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                            clsReports.setReportLanguage(paramarr);
                            clsReports.Header(paramarr);
                            paramarr = reportclass.fillSaleInvReport(invoice, paramarr);

                            rep.SetParameters(paramarr);
                            rep.Refresh();

                            LocalReportExtensions.ExportToPDF(rep, pdfpath);

                        }

                        wd_previewPdf w = new wd_previewPdf();
                        w.pdfPath = pdfpath;
                        if (!string.IsNullOrEmpty(w.pdfPath))
                        {
                            w.ShowDialog();

                            w.wb_pdfWebViewer.Dispose();

                        }
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: "", animation: ToasterAnimation.FadeIn);

                        Window.GetWindow(this).Opacity = 1;
                    }
                    else
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trSaveInvoiceToPreview"), animation: ToasterAnimation.FadeIn);
                    }
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (invoice != null && invoice.invoiceId != 0)
                {
                    Window.GetWindow(this).Opacity = 0.2;

                    wd_uploadImage w = new wd_uploadImage();

                    w.tableName = "invoices";
                    w.tableId = invoice.invoiceId;
                    w.docNum = invoice.invNumber;
                    w.ShowDialog();
                    refreshDocCount(invoice.invoiceId);
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trChooseInvoiceToolTip"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                _Sender = sender;
                refreshTotalValue();
                e.Handled = true;
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_typeDiscount.SelectedIndex != -1)
                {
                    _SelectedDiscountType = (int)cb_typeDiscount.SelectedValue;
                    refreshTotalValue();
                }
                else
                {
                    cb_typeDiscount.SelectedValue = _SelectedDiscountType;
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Cb_coupon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                string s = _BarcodeStr;
                if (cb_coupon.SelectedIndex != -1)
                {
                    couponModel = coupons.ToList().Find(c => c.cId == (int)cb_coupon.SelectedValue);
                    if (couponModel != null)
                    {
                        s = couponModel.barcode;
                        await dealWithBarcode(s);
                    }
                    cb_coupon.SelectedIndex = -1;
                    cb_coupon.SelectedItem = "";
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Tgl_ActiveOffer_Checked(object sender, RoutedEventArgs e)
        {
            if (tgl_ActiveOffer.IsFocused)
            {
                #region Accept
                if (cb_customer.SelectedIndex != -1)
                {
                    MainWindow.mainWindow.Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    w.contentText = MainWindow.resourcemanager.GetString("trApproveQuotationNotification");

                    w.ShowDialog();
                    if (!w.isOk)
                        tgl_ActiveOffer.IsChecked = false;
                    MainWindow.mainWindow.Opacity = 1;

                }
                #endregion
                else
                {
                    tgl_ActiveOffer.IsChecked = false;
                    SectionData.validateEmptyComboBox(cb_customer, p_errorCustomer, tt_errorCustomer, "trEmptyCustomerToolTip");
                }
            }
        }

        private void Btn_updateCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (cb_customer.SelectedIndex != -1)
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_updateVendor w = new wd_updateVendor();
                    //// pass agent id to update windows
                    w.agent.agentId = (int)cb_customer.SelectedValue;
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #region navigation buttons
        private void navigateBtnActivate()
        {
            int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
            if (index == invoices.Count - 1)
                btn_next.IsEnabled = false;
            else
                btn_next.IsEnabled = true;

            if (index == 0)
                btn_previous.IsEnabled = false;
            else
                btn_previous.IsEnabled = true;
        }
        private async void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
            index++;
            invoice = invoices[index];
            _invoiceId = invoice.invoiceId;
            navigateBtnActivate();
            await fillInvoiceInputs(invoice);
        }
        private async void Btn_previous_Click(object sender, RoutedEventArgs e)
        {
            int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
            index--;
            invoice = invoices[index];
            _invoiceId = invoice.invoiceId;
            navigateBtnActivate();
            await fillInvoiceInputs(invoice);
        }
        #endregion

        private async void Btn_deleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (invoice.invoiceId != 0)
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                    {
                        int res = await invoice.deleteInvoice(invoice.invoiceId);
                        if (res>0)
                        {
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopDelete"), animation: ToasterAnimation.FadeIn);
                            clearInvoice();
                            refreshDraftNotification();
                        }
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            try
            {
                var Sender = sender as Expander;

                foreach (var control in FindControls.FindVisualChildren<Expander>(this))
                {

                    var expander = control as Expander;
                    if (expander.Tag != null && Sender.Tag != null)
                        if (expander.Tag.ToString() != Sender.Tag.ToString())
                            expander.IsExpanded = false;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Cb_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_customer.SelectedIndex != -1)
                {
                    _SelectedCustomer = (int)cb_customer.SelectedValue;
                }
                else
                {
                    cb_customer.SelectedValue = _SelectedCustomer;
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_clearCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                _SelectedCustomer = -1;
                cb_customer.SelectedIndex = -1;
                //dp_desrvedDate.SelectedDate = null;
                tb_note.Clear();

                //btn_updateCustomer.IsEnabled = false;
                SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Cb_customer_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                cb_customer.ItemsSource = customers.Where(x => x.name.Contains(cb_customer.Text));
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Tb_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _Sender = sender;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
                if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                    e.Handled = false;

                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Dg_billDetails_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _IsFocused = true;
        }
    }
}

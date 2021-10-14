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
using System.Windows.Threading;
using System.Threading;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for uc_payInvoice.xaml
    /// </summary>
    public partial class uc_payInvoice : UserControl
    {
        string invoicePermission = "payInvoice_invoice";
        string returnPermission = "payInvoice_return";
        string paymentsPermission = "payInvoice_payments";
        string sendEmailPermission = "payInvoice_sendEmail";
        string openOrderPermission = "payInvoice_openOrder";
        string initializeShortagePermission = "payInvoice_initializeShortage";

        private static uc_payInvoice _instance;
        public static uc_payInvoice Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_payInvoice();
                return _instance;
            }
        }
        public uc_payInvoice()
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
        ItemLocation itemLocationModel = new ItemLocation();

        Branch branchModel = new Branch();
        //IEnumerable<Branch> branches;

        Agent agentModel = new Agent();
        IEnumerable<Agent> vendors;

        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;

        Invoice invoiceModel = new Invoice();
        public Invoice invoice = new Invoice();
        List<Invoice> invoices;
        List<ItemTransfer> invoiceItems;
        List<ItemTransfer> mainInvoiceItems;
        //  Bill bill;
        private static DispatcherTimer timer;
        CashTransfer cashTransfer = new CashTransfer();
        #region //to handle barcode characters
        static private int _SelectedBranch = -1;
        static private int _SelectedVendor = -1;
        static private int _SelectedDiscountType = -1;
        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        static private string _BarcodeStr = "";
        static private object _Sender;
        #endregion

        CatigoriesAndItemsView catigoriesAndItemsView = new CatigoriesAndItemsView();
        //  int? parentCategorieSelctedValue;
        public byte tglCategoryState = 1;
        public byte tglItemState = 1;
        public string txtItemSearch;

        //for bill details
        static private int _SequenceNum = 0;
        static private int _invoiceId;
        static private decimal _Sum = 0;
        static public string _InvoiceType = "pd"; // purchase draft

        // for report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        int prInvoiceId;
        Invoice prInvoice = new Invoice();

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
        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trQuantity");
            dg_billDetails.Columns[5].Header = MainWindow.resourcemanager.GetString("trPrice");
            dg_billDetails.Columns[6].Header = MainWindow.resourcemanager.GetString("trAmount");

            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal");
            txt_tax.Text = MainWindow.resourcemanager.GetString("trTax");
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseBill");
            //txt_barcode.Text = MainWindow.resourcemanager.GetString("trBarcode");
            txt_store.Text = MainWindow.resourcemanager.GetString("trStore/Branch");
            txt_vendor.Text = MainWindow.resourcemanager.GetString("trVendor");
            txt_vendorIvoiceDetails.Text = MainWindow.resourcemanager.GetString("trVendorDetails");

            txt_printInvoice.Text = MainWindow.resourcemanager.GetString("trPrint");
            txt_preview.Text = MainWindow.resourcemanager.GetString("trPreview");
            txt_invoiceImages.Text = MainWindow.resourcemanager.GetString("trImages");
            txt_items.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_drafts.Text = MainWindow.resourcemanager.GetString("trDrafts");
            txt_newDraft.Text = MainWindow.resourcemanager.GetString("trNew");
            txt_payments.Text = MainWindow.resourcemanager.GetString("trPayments");
            txt_returnInvoice.Text = MainWindow.resourcemanager.GetString("trReturn");
            txt_invoices.Text = MainWindow.resourcemanager.GetString("trInvoices");
            txt_purchaseOrder.Text = MainWindow.resourcemanager.GetString("trOrders");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_barcode, MainWindow.resourcemanager.GetString("trBarcodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trBranchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_typeDiscount, MainWindow.resourcemanager.GetString("trDiscountTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trStore/BranchHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_taxValue, MainWindow.resourcemanager.GetString("trTaxHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendor, MainWindow.resourcemanager.GetString("trVendorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_invoiceNumber, MainWindow.resourcemanager.GetString("trInvoiceNumberHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_invoiceDate, MainWindow.resourcemanager.GetString("trInvoiceDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            tt_error_previous.Content = MainWindow.resourcemanager.GetString("trPrevious");
            tt_error_next.Content = MainWindow.resourcemanager.GetString("trNext");

            btn_save.Content = MainWindow.resourcemanager.GetString("trBuy");
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                MainWindow.mainWindow.KeyDown -= HandleKeyPress;
                if (billDetails.Count > 0 && _InvoiceType == "pd")
                {
                    #region Accept
                    MainWindow.mainWindow.Opacity = 0.2;
                    wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                    //w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                    w.contentText = "Do you want save pay invoice in drafts?";
                    w.ShowDialog();
                    MainWindow.mainWindow.Opacity = 1;
                    #endregion
                    if (w.isOk)
                        Btn_newDraft_Click(null, null);
                    else
                    {
                        clearInvoice();
                        _InvoiceType = "pd";
                    }
                }
                else
                {
                    clearInvoice();
                    _InvoiceType = "pd";
                }
                timer.Stop();

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
        public async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                MainWindow.mainWindow.KeyDown += HandleKeyPress;
                tb_moneyIcon.Text = MainWindow.Currency;
                tb_moneyIconTotal.Text = MainWindow.Currency;

                dp_desrvedDate.SelectedDateChanged += this.dp_SelectedDateChanged;
                dp_invoiceDate.SelectedDateChanged += this.dp_SelectedDateChanged;

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
                catigoriesAndItemsView.ucPayInvoice = this;
                setTimer();
                await RefrishItems();
                configureDiscountType();
                await SectionData.fillBranchesWithoutCurrent(cb_branch,MainWindow.branchID.Value, "bs");
                await RefrishVendors();
                await fillBarcodeList();
                setNotifications();
                branchModel = await branchModel.getBranchById(MainWindow.branchID.Value);
                #region Style Date
                SectionData.defaultDatePickerStyle(dp_desrvedDate);
                SectionData.defaultDatePickerStyle(dp_invoiceDate);
                #endregion
                tb_barcode.Focus();
                #region datagridChange
                //CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
                //((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
                #endregion


                #region Permision

                if (MainWindow.groupObject.HasPermissionAction(openOrderPermission, MainWindow.groupObjects, "one"))
                    md_orders.Visibility = Visibility.Visible;
                else
                    md_orders.Visibility = Visibility.Collapsed;

                if (MainWindow.groupObject.HasPermissionAction(returnPermission, MainWindow.groupObjects, "one"))
                    btn_returnInvoice.Visibility = Visibility.Visible;
                else
                    btn_returnInvoice.Visibility = Visibility.Collapsed;

                if (MainWindow.groupObject.HasPermissionAction(paymentsPermission, MainWindow.groupObjects, "one"))
                {
                    md_payments.Visibility = Visibility.Visible;
                    bdr_payments.Visibility = Visibility.Visible;
                }
                else
                {
                    md_payments.Visibility = Visibility.Collapsed;
                    bdr_payments.Visibility = Visibility.Collapsed;
                }

                if (MainWindow.groupObject.HasPermissionAction(sendEmailPermission, MainWindow.groupObjects, "one"))
                {
                    btn_emailMessage.Visibility = Visibility.Visible;
                    bdr_emailMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    btn_emailMessage.Visibility = Visibility.Collapsed;
                    bdr_emailMessage.Visibility = Visibility.Collapsed;
                }


                if (MainWindow.groupObject.HasPermissionAction(initializeShortagePermission, MainWindow.groupObjects, "one"))
                {
                    btn_shortageInvoice.Visibility = Visibility.Visible;
                    bdr_shortageInvoice.Visibility = Visibility.Visible;
                }
                else
                {
                    btn_shortageInvoice.Visibility = Visibility.Collapsed;
                    bdr_shortageInvoice.Visibility = Visibility.Collapsed;
                }

                #endregion
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
            public int OrderId { get; set; }
        }

        #endregion

        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                SectionData.StartAwait(grid_main);

            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
                    int index = dg_billDetails.SelectedIndex;
                    // calculate new sum
                    _Sum -= row.Total;

                    // remove item from bill
                    billDetails.RemoveAt(index);

                    ObservableCollection<BillDetails> data = (ObservableCollection<BillDetails>)dg_billDetails.ItemsSource;
                    data.Remove(row);

                    // calculate new total
                    refreshTotalValue();
                }
            _SequenceNum = 0;
            _Sum = 0;
            for (int i = 0; i < billDetails.Count; i++)
            {
                _SequenceNum++;
                _Sum += billDetails[i].Total;
                billDetails[i].ID = _SequenceNum;
            }
            refrishBillDetails();
            if (sender != null)
                SectionData.EndAwait(grid_main);
        }
            catch (Exception ex)
            {
				if (sender != null)
				SectionData.EndAwait(grid_main);
				SectionData.ExceptionMessage(ex,this);
        }
    }
        #endregion
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
                await refreshOrdersNotification();
            if (invoice.invoiceId != 0)
            {
                     refreshDocCount(invoice.invoiceId);
                if (_InvoiceType == "pw" || _InvoiceType == "p" || _InvoiceType == "pb" || _InvoiceType == "pbw")
                        refreshPaymentsNotification(invoice.invoiceId);
            }
            }
            catch (Exception ex)
            {
                 SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        #region notifications
        private async void setNotifications()
        {
            await refreshDraftNotification();
            await refreshOrdersNotification();
        }
        private async Task refreshDraftNotification()
        {
            string invoiceType = "pd ,pbd";
            int duration = 2;
            int draftCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);
            if ((invoice.invType == "pd" || invoice.invType == "pbd") && invoice.invoiceId != 0)
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
        private async Task refreshOrdersNotification()
        {
            string invoiceType = "po";
            int duration = 0;
            int ordersCount = await invoice.GetCountBranchInvoices(invoiceType, MainWindow.branchID.Value);
            //int ordersCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);
            if (_InvoiceType == "po" && invoice.invoiceId != 0)
                ordersCount--;

            int previouseCount = 0;
            if (md_orders.Badge != null && md_orders.Badge.ToString() != "") previouseCount = int.Parse(md_orders.Badge.ToString());

            if (ordersCount != previouseCount)
            {
                if (ordersCount > 9)
                {
                    ordersCount = 9;
                    md_orders.Badge = "+" + ordersCount.ToString();
                }
                else if (ordersCount == 0) md_orders.Badge = "";
                else
                    md_orders.Badge = ordersCount.ToString();
            }
        }
        private async void refreshDocCount(int invoiceId)
        {
            DocImage doc = new DocImage();
            int docCount = await doc.GetDocCount("Invoices",invoiceId);

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
        private async void refreshPaymentsNotification(int invoiceId)
        {
            int paymentsCount = await cashTransfer.GetCashCount(invoice.invoiceId);
            int previouseCount = 0;
            if (md_payments.Badge != null && md_payments.Badge.ToString() != "") previouseCount = int.Parse(md_payments.Badge.ToString());

            if (paymentsCount != previouseCount)
            {
                if (paymentsCount > 9)
                {
                    paymentsCount = 9;
                    md_payments.Badge = "+" + paymentsCount.ToString();
                }
                else if (paymentsCount == 0) md_payments.Badge = "";

                else
                    md_payments.Badge = paymentsCount.ToString();
            }
        }
#endregion
        private void Btn_updateVendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (cb_vendor.SelectedIndex != -1)
                {

                    Window.GetWindow(this).Opacity = 0.2;
                    wd_updateVendor w = new wd_updateVendor();
                    //// pass agent id to update windows
                    w.agent.agentId = (int)cb_vendor.SelectedValue;
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
        #region Categor and Item
        #region Refrish Y
        /// <summary>
        /// Category
        /// </summary>
        /// <returns></returns>
       
        async Task RefrishVendors()
        {
            vendors = await agentModel.GetAgentsActive("v");
            cb_vendor.ItemsSource = vendors;
            cb_vendor.DisplayMemberPath = "name";
            cb_vendor.SelectedValuePath = "agentId";
        }

        async Task RefrishItems()
        {
            items = await itemModel.GetAllItems();
        }
        async Task fillBarcodeList()
        {
            barcodesList = await itemUnitModel.getAllBarcodes();
        }





        #endregion
        #region Get Id By Click  Y

        public  void ChangeCategoryIdEvent(int categoryId)
        {
        }


        public async Task ChangeItemIdEvent(int itemId)
        {
            item = items.ToList().Find(c => c.itemId == itemId);

            if (item != null)
            {
                this.DataContext = item;

                // get item units
                itemUnits = await itemUnitModel.GetItemUnits(item.itemId);
                // search for default unit for purchase
                var defaultPurUnit = itemUnits.ToList().Find(c => c.defaultPurchase == 1);
                if (defaultPurUnit != null)
                {
                    int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == defaultPurUnit.itemUnitId && p.OrderId == 0).FirstOrDefault());
                    if (index == -1)//item doesn't exist in bill
                    {
                        // create new row in bill details data grid
                          addRowToBill(item.name, itemId, defaultPurUnit.mainUnit, defaultPurUnit.itemUnitId, 1, 0, 0);
                    }
                    else // item exist prevoiusly in list
                    {
                        billDetails[index].Count++;
                        billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;

                        _Sum += billDetails[index].Price;
                    }
                    //refreshTotalValue();
                    //refrishBillDetails();
                }
                else
                {
                      addRowToBill(item.name, itemId, null, 0, 1, 0, 0);
                    //refrishBillDetails();
                }

            }
        }

        #endregion



        #endregion

        #region validation
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


        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_invoiceNumber")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorInvoiceNumber, tt_errorInvoiceNumber, "trErrorEmptyInvNumToolTip");
                }
                else if (name == "ComboBox")
                {
                    if ((sender as ComboBox).Name == "cb_branch")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
                    if ((sender as ComboBox).Name == "cb_vendor")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip");
                }
                else
                {
                    if ((sender as DatePicker).Name == "dp_desrvedDate")
                        SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorDesrvedDate, tt_errorDesrvedDate, "trErrorEmptyDeservedDate");
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        #region save invoice

        private async Task addInvoice(string invType, string invCode)
        {

            if ((invoice.invType == "p" || invoice.invType == "pw") && (invType == "pbw" || invType == "pbd")) // invoice is purchase and will be bounce purchase  or purchase bounce draft , save another invoice in db
            {
                invoice.invoiceMainId = invoice.invoiceId;
                invoice.invoiceId = 0;
                invoice.invNumber = await invoice.generateInvNumber("pb",branchModel.code,MainWindow.branchID.Value);
                invoice.branchCreatorId = MainWindow.branchID.Value;
                invoice.posId = MainWindow.posID.Value;
            }
            else if (invoice.invType == "po")
            {
                invoice.invNumber = await invoice.generateInvNumber("pi", branchModel.code, MainWindow.branchID.Value);
            }
            else if (invType == "pd" && invoice.invoiceId == 0)
                invoice.invNumber = await invoice.generateInvNumber("pd", branchModel.code, MainWindow.branchID.Value);

            if (invoice.branchCreatorId == 0 || invoice.branchCreatorId == null)
            {
                invoice.branchCreatorId = MainWindow.branchID.Value;
                invoice.posId = MainWindow.posID.Value;
            }

            if (invoice.invType != "pw" || invoice.invoiceId == 0)
            {
                invoice.invType = invType;
                if (!tb_discount.Text.Equals(""))
                    invoice.discountValue = decimal.Parse(tb_discount.Text);

                if (cb_typeDiscount.SelectedIndex != -1)
                    invoice.discountType = cb_typeDiscount.SelectedValue.ToString();

                invoice.total = _Sum;
                invoice.totalNet = decimal.Parse(tb_total.Text);
                invoice.paid = 0;
                invoice.deserved = invoice.totalNet;
                if (cb_vendor.SelectedIndex != -1)
                    invoice.agentId = (int)cb_vendor.SelectedValue;

                if (cb_branch.SelectedIndex != -1)
                    invoice.branchId = (int)cb_branch.SelectedValue;
                else
                    invoice.branchId = MainWindow.branchID.Value;

                invoice.deservedDate = dp_desrvedDate.SelectedDate;
                invoice.vendorInvNum = tb_invoiceNumber.Text;
                invoice.vendorInvDate = dp_invoiceDate.SelectedDate;
                invoice.notes = tb_note.Text;
                invoice.taxtype = 2;
                if (tb_taxValue.Text != "")
                    invoice.tax = decimal.Parse(tb_taxValue.Text);
                else
                    invoice.tax = 0;

                invoice.createUserId = MainWindow.userID;
                invoice.updateUserId = MainWindow.userID;
                if (invType == "pw" || invType == "p")
                    invoice.invNumber = await invoice.generateInvNumber("pi", branchModel.code, MainWindow.branchID.Value);

                // save invoice in DB
                int invoiceId = await invoiceModel.saveInvoice(invoice) ;
                prInvoiceId = invoiceId;
                invoice.invoiceId = invoiceId;
                if (invoiceId != 0)
                {
                    if (invType == "pw")
                    {
                        await invoice.recordPosCashTransfer(invoice, "pi");
                        await invoice.recordCashTransfer(invoice, "pi");
                    }
                    //else if (invType == "pb")
                    //    await invoice.recordCashTransfer(invoice,"pb");

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
                        itemT.invoiceId = billDetails[i].OrderId;

                        invoiceItems.Add(itemT);
                    }
                    int s = await invoiceModel.saveInvoiceItems(invoiceItems, invoiceId);
                    
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                }
                else
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            }
            clearInvoice();
            _InvoiceType = "pd";
        }
        private void dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime desrveDate;
                if (dp_desrvedDate.SelectedDate != null)
                {
                    desrveDate = (DateTime)dp_desrvedDate.SelectedDate.Value.Date;
                    if (desrveDate.Date < DateTime.Now.Date)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorInvDateAfterDeserveToolTip"), animation: ToasterAnimation.FadeIn);
                        dp_desrvedDate.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void validateInvoiceValues()
        {
            //bool isValid = true;
            //SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
            if (!SectionData.validateEmptyComboBox(cb_vendor, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip"))
                exp_vendor.IsExpanded = true;
            if (!SectionData.validateEmptyTextBox(tb_invoiceNumber, p_errorInvoiceNumber, tt_errorInvoiceNumber, "trErrorEmptyInvNumToolTip"))
                exp_vendor.IsExpanded = true;
            if (!SectionData.validateEmptyDatePicker(dp_desrvedDate, p_errorDesrvedDate, tt_errorDesrvedDate, "trErrorEmptyDeservedDate"))
                exp_vendor.IsExpanded = true;

            if (decimal.Parse(tb_total.Text) == 0)
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorTotalIsZeroToolTip"), animation: ToasterAnimation.FadeIn);

            //SectionData.validateSmalThanDateNowDatePicker(dp_desrvedDate, p_errorDesrvedDate, tt_errorDesrvedDate, "trErrorEmptyDeservedDate");
            //return isValid;
        }
      
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(invoicePermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())

                {
                   
                        //check mandatory inputs
                        validateInvoiceValues();
                        bool valid = validateItemUnits();
                        TextBox tb = (TextBox)dp_desrvedDate.Template.FindName("PART_TextBox", dp_desrvedDate);
                        if ( cb_vendor.SelectedIndex != -1 && !tb_invoiceNumber.Equals("") && billDetails.Count > 0
                            && !tb.Text.Trim().Equals("") && decimal.Parse(tb_total.Text) > 0 && valid)
                        {                          
                            if (_InvoiceType == "pbd") //pbd means purchase bounse draft
                            {
                                #region notification Object
                                Notification not = new Notification()
                                {
                                    title = "trPurchaseReturnInvoiceAlertTilte",
                                    ncontent = "trPurchaseReturnInvoiceAlertContent",
                                    msgType = "alert",
                                    createUserId = MainWindow.userID.Value,
                                    updateUserId = MainWindow.userID.Value,
                                };
                                await not.save(not, (int)cb_branch.SelectedValue, "storageAlerts_ctreatePurchaseReturnInvoice",branchModel.name);
                                #endregion
                                await addInvoice("pbw", "pb"); // pbw means waiting purchase bounce
                            }
                            //else if (_InvoiceType == "po")//po  purchase order
                            //{
                            //    #region notification Object
                            //    Notification not = new Notification()
                            //    {
                            //        title = "trPurchaseInvoiceAlertTilte",
                            //        ncontent = "trPurchaseInvoiceAlertContent",
                            //        msgType = "alert",
                            //        createUserId = MainWindow.userID.Value,
                            //        updateUserId = MainWindow.userID.Value,
                            //    };
                            //    await not.Save(not, (int)cb_branch.SelectedValue, "storageAlerts_ctreatePurchaseInvoice", cb_branch.Text);
                            //    #endregion
                            //    await addInvoice("pw", "pi");
                            //}
                            else//pw  waiting purchase invoice
                            {                               
                                
                                if(cb_branch.SelectedIndex == -1) // reciept invoice directly
                                {
                                    await addInvoice("p", "pi");
                                    #region notification Object
                                    Notification not = new Notification()
                                    {
                                        title = "trExceedMaxLimitAlertTilte",
                                        ncontent = "trExceedMaxLimitAlertContent",
                                        msgType = "alert",
                                        //createDate = DateTime.Now,
                                        // updateDate = DateTime.Now,
                                        createUserId = MainWindow.userID.Value,
                                        updateUserId = MainWindow.userID.Value,
                                    };
                                    #endregion
                                    await itemLocationModel.recieptInvoice(invoiceItems, MainWindow.branchID.Value, MainWindow.userID.Value, "storageAlerts_minMaxItem", not); // increase item quantity in DB
                                }
                                else
                                {
                                    await addInvoice("pw", "pi");
                                    #region notification Object
                                    Notification not = new Notification()
                                    {
                                        title = "trPurchaseInvoiceAlertTilte",
                                        ncontent = "trPurchaseInvoiceAlertContent",
                                        msgType = "alert",
                                        createUserId = MainWindow.userID.Value,
                                        updateUserId = MainWindow.userID.Value,
                                    };
                                    await not.save(not, (int)cb_branch.SelectedValue, "storageAlerts_ctreatePurchaseInvoice", branchModel.name);
                                    #endregion
                                }
                                clearInvoice();
                                await refreshDraftNotification();
                            }

                            if (invoice.invoiceId == 0)
                            {
                                clearInvoice();
                                _InvoiceType = "pd";
                            }
                            //
                            prInvoice = await invoiceModel.getById(prInvoiceId);
                            ///////////////////////////////////////

                            if (prInvoice.invType == "pw")
                            {
                                Thread t = new Thread(() =>
                                { 
                                    if (MainWindow.print_on_save_pur == "1")
                                {
                                    //Thread t1 = new Thread(() =>
                                    //{
                                    printPurInvoice();
                                    //});
                                    //t1.Start();
                                }
                                if (MainWindow.email_on_save_pur == "1")
                                {
                                    //Thread t2 = new Thread(() =>
                                    //{
                                    sendPurEmail();
                                    //});
                                    //t2.Start();
                                }
                                });
                                t.Start();

                                }
                           
                            /////////////////////////////////////////
                        
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

                if (billDetails.Count > 0 && (_InvoiceType == "pd" || _InvoiceType == "pbd"))
                {
                    bool valid = validateItemUnits();
                if (billDetails.Count > 0 && valid)
                {
                    await addInvoice(_InvoiceType, "pi");                 
                    clearInvoice();
                    refreshDraftNotification();
                    _InvoiceType = "pd";
                }
                else if (billDetails.Count == 0)
                {
                    clearInvoice();
                    _InvoiceType = "pd";
                }
                }
                else
                     clearInvoice();

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
        private void clearInvoice()
        {
            _Sum = 0;
            txt_invNumber.Text = "";
            _SequenceNum = 0;
            _SelectedBranch = -1;
            _SelectedVendor = -1;          
            invoice = new Invoice();
            tb_barcode.Clear();
            cb_branch.SelectedIndex = -1;
            cb_vendor.SelectedIndex = -1;
            cb_vendor.SelectedItem = "";
            cb_typeDiscount.SelectedIndex = 0;
            dp_desrvedDate.Text = "";
            txt_vendorIvoiceDetails.Text = "";
            tb_invoiceNumber.Clear();
            dp_invoiceDate.Text = "";
            tb_note.Clear();
            tb_discount.Clear();
            tb_taxValue.Clear();
            billDetails.Clear();
            tb_total.Text = "0";
            tb_sum.Text = "0";
            if (MainWindow.tax != 0)
                tb_taxValue.Text = SectionData.DecTostring(MainWindow.tax);
            else
                tb_taxValue.Text = "0";

            md_docImage.Badge = "";
            md_payments.Badge = "";

            TextBox tbStartDate = (TextBox)dp_desrvedDate.Template.FindName("PART_TextBox", dp_desrvedDate);
            SectionData.clearValidate(tbStartDate, p_errorDesrvedDate);
            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseBill");
            refrishBillDetails();
            inputEditable();
            btn_next.Visibility = Visibility.Collapsed;
            btn_previous.Visibility = Visibility.Collapsed;
        }
        #endregion
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();
                string invoiceType = "pd ,pbd";
                int duration = 2;
                w.invoiceType = invoiceType;
                w.userId = MainWindow.userLogin.userId;
                w.duration = duration; // view drafts which created during 2 last days 

                w.title = MainWindow.resourcemanager.GetString("trDrafts");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;
                        _InvoiceType = invoice.invType;
                        _invoiceId = invoice.invoiceId;
                        await fillInvoiceInputs(invoice);
                        setNotifications();
                        refreshDocCount(invoice.invoiceId);
                        invoices = await invoice.GetInvoicesByCreator(invoiceType, MainWindow.userID.Value, duration);
                        navigateBtnActivate();
                        md_payments.Badge = "";
                        if (_InvoiceType == "pd")// set title to bill
                        {
                            mainInvoiceItems = invoiceItems;
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                        }
                        if (_InvoiceType == "pbd")
                        {
                            mainInvoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceMainId.Value);
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;

                        }
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
        private async void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

                // purchase invoices
                string invoiceType = "p , pw , pb, pbw";
                int duration = 1;
                w.invoiceType = invoiceType;
                w.userId = MainWindow.userLogin.userId;
                w.duration = duration; // view drafts which created during 1 last days 

                w.title = MainWindow.resourcemanager.GetString("trInvoices");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;

                        _InvoiceType = invoice.invType;
                        _invoiceId = invoice.invoiceId;
                        setNotifications();
                        refreshDocCount(invoice.invoiceId);
                        // set title to bill
                        if (invoice.invType == "p" || invoice.invType == "pw")
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
                        else
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                        txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;

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
        private async void Btn_purchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

                // purchase orders
                string invoiceType = "po";
                w.invoiceType = invoiceType;
                // w.userId = MainWindow.userLogin.userId;
                w.branchCreatorId = MainWindow.branchID.Value;
                w.title = MainWindow.resourcemanager.GetString("trOrders");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;

                        _InvoiceType = invoice.invType;
                        _invoiceId = invoice.invoiceId;
                        // notifications
                        md_payments.Badge = "";
                        setNotifications();
                        refreshDocCount(invoice.invoiceId);

                        // set title to bill
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseOrder");
                        txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                        await fillInvoiceInputs(invoice);
                        invoices = await invoice.GetInvoicesByCreator(invoiceType, MainWindow.userID.Value, 0);
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
        public async Task fillInvoiceInputs(Invoice invoice)
        {
            _Sum = (decimal)invoice.total;
            txt_invNumber.Text = invoice.invNumber.ToString();
            cb_branch.SelectedValue = invoice.branchId;
            cb_vendor.SelectedValue = invoice.agentId;
            dp_desrvedDate.Text = invoice.deservedDate.ToString();
            tb_invoiceNumber.Text = invoice.vendorInvNum;
            dp_invoiceDate.Text = invoice.vendorInvDate.ToString();
            //tb_total.Text = Math.Round((double)invoice.totalNet, 2).ToString();
            if (invoice.totalNet != 0)
                tb_total.Text = SectionData.DecTostring(invoice.totalNet);
            else tb_total.Text = "0";
            //tb_taxValue.Text = invoice.tax.ToString();
            if ((invoice.tax != 0) && (invoice.tax != null))
                tb_taxValue.Text = SectionData.DecTostring(invoice.tax);
            else
                tb_taxValue.Text = "0";
            tb_note.Text = invoice.notes;
            //tb_sum.Text = invoice.total.ToString();
            if (invoice.total != 0)
                tb_sum.Text = SectionData.DecTostring(invoice.total);
            else tb_sum.Text = "0";
            //tb_discount.Text = invoice.discountValue.ToString();
            if ((invoice.discountValue != 0) && (invoice.discountValue != null))
                tb_discount.Text = SectionData.DecTostring(invoice.discountValue);
            else
                tb_discount.Text = "0";
            if (invoice.discountType == "1")
                cb_typeDiscount.SelectedIndex = 1;
            else if (invoice.discountType == "2")
                cb_typeDiscount.SelectedIndex = 2;
            else
                cb_typeDiscount.SelectedIndex = 0;

            // build invoice details grid
            await buildInvoiceDetails();

            inputEditable();
        }
        private async void Btn_returnInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(returnPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_invoice w = new wd_invoice();

                    w.title = MainWindow.resourcemanager.GetString("trReturn");
                    // purchase invoices
                    string invoiceType = "p";
                    w.invoiceType = invoiceType; // invoice type to view in grid
                    //w.branchCreatorId = MainWindow.branchID.Value;
                    //w.branchId = MainWindow.branchID.Value;
                    w.condition = "return";
                    w.userId = MainWindow.userID.Value;
                    if (w.ShowDialog() == true)
                    {
                        if (w.invoice != null)
                        {
                            _InvoiceType = "pbd";
                            invoice = w.invoice;
                            _invoiceId = invoice.invoiceId;
                            // notifications
                            setNotifications();
                            refreshDocCount(invoice.invoiceId);
                            md_payments.Badge = "";

                            await fillInvoiceInputs(invoice);
                            invoices = await invoice.getBranchInvoices(invoiceType, MainWindow.branchID.Value, MainWindow.branchID.Value);
                            navigateBtnActivate();
                            mainInvoiceItems = invoiceItems;
                            
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;  
                         }
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


        private async Task buildInvoiceDetails()
        {
            //get invoice items
            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
            // build invoice details grid
            _SequenceNum = 0;
            billDetails.Clear();
            foreach (ItemTransfer itemT in invoiceItems)
            {
                _SequenceNum++;
                decimal total = (decimal)(itemT.price * itemT.quantity);
                int orderId = 0;
                if (itemT.invoiceId != null)
                    orderId = (int)itemT.invoiceId;
                billDetails.Add(new BillDetails()
                {
                    ID = _SequenceNum,
                    Product = itemT.itemName,
                    itemId = (int)itemT.itemId,
                    Unit = itemT.itemUnitId.ToString(),
                    itemUnitId = (int)itemT.itemUnitId,
                    Count = (int)itemT.quantity,
                    //Price = (decimal)itemT.price,
                    Price = decimal.Parse(SectionData.DecTostring((decimal)itemT.price)),
                    Total = total,
                    OrderId = orderId,
                });
            }

            tb_barcode.Focus();

            refrishBillDetails();
        }
        private void inputEditable()
        {
            if (_InvoiceType == "pbw") // purchase invoice
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                dg_billDetails.Columns[5].IsReadOnly = false; //make price read only
                dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                cb_vendor.IsEnabled = false;
                dp_desrvedDate.IsEnabled = false;
                dp_invoiceDate.IsEnabled = false;
                tb_note.IsEnabled = false;
                tb_barcode.IsEnabled = false;
                cb_branch.IsEnabled = false;
                tb_discount.IsEnabled = false;
                cb_typeDiscount.IsEnabled = false;
                btn_save.IsEnabled = true;
                tb_invoiceNumber.IsEnabled = false;
                tb_taxValue.IsEnabled = false;
            }
            if (_InvoiceType == "pbd") // return invoice
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                dg_billDetails.Columns[5].IsReadOnly = false; //make price read only
                dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                cb_vendor.IsEnabled = false;
                dp_desrvedDate.IsEnabled = false;
                dp_invoiceDate.IsEnabled = false;
                tb_note.IsEnabled = false;
                tb_barcode.IsEnabled = false;
                cb_branch.IsEnabled = true;
                tb_discount.IsEnabled = false;
                cb_typeDiscount.IsEnabled = false;
                btn_save.IsEnabled = true;
                tb_invoiceNumber.IsEnabled = false;
                tb_taxValue.IsEnabled = false;
            }
            else if (_InvoiceType == "pd" || _InvoiceType == "po") // purchase draft or purchase order
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                dg_billDetails.Columns[5].IsReadOnly = false;
                dg_billDetails.Columns[3].IsReadOnly = false;
                dg_billDetails.Columns[4].IsReadOnly = false;
                cb_vendor.IsEnabled = true;
                dp_desrvedDate.IsEnabled = true;
                dp_invoiceDate.IsEnabled = true;
                tb_note.IsEnabled = true;
                tb_barcode.IsEnabled = true;
                cb_branch.IsEnabled = true;
                tb_discount.IsEnabled = true;
                cb_typeDiscount.IsEnabled = true;
                btn_save.IsEnabled = true;
                tb_invoiceNumber.IsEnabled = true;
                tb_taxValue.IsEnabled = true;
            }
            else if (_InvoiceType == "pw" || _InvoiceType == "p")
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                dg_billDetails.Columns[5].IsReadOnly = true; //make price read only
                dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                cb_vendor.IsEnabled = false;
                dp_desrvedDate.IsEnabled = false;
                dp_invoiceDate.IsEnabled = false;
                tb_note.IsEnabled = false;
                tb_barcode.IsEnabled = false;
                cb_branch.IsEnabled = false;
                tb_discount.IsEnabled = false;
                cb_typeDiscount.IsEnabled = false;
                btn_save.IsEnabled = false;
                tb_invoiceNumber.IsEnabled = false;
                tb_taxValue.IsEnabled = false;
            }
            btn_next.Visibility = Visibility.Visible;
            btn_previous.Visibility = Visibility.Visible;
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

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

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
                        Count = (int)itemT.quantity,
                        Price = (decimal)itemT.price,
                        Total = total,
                    });
                }
                tb_barcode.Focus();

                refrishBillDetails();
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
 

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_branch.SelectedIndex != -1)
                {
                    _SelectedBranch = (int)cb_branch.SelectedValue;
                }
                else
                {
                    cb_branch.SelectedValue = _SelectedBranch;
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Cb_vendor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                cb_vendor.ItemsSource = vendors.Where(x => x.name.Contains(cb_vendor.Text));

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Cb_vendor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_vendor.SelectedIndex != -1)
                {
                    _SelectedVendor = (int)cb_vendor.SelectedValue;
                }
                else
                {
                    cb_vendor.SelectedValue = _SelectedVendor;
                }
                
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
        private void tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var txb = sender as TextBox;
                if ((sender as TextBox).Name == "tb_discount")
                    SectionData.InputJustNumber(ref txb);
                if ((sender as TextBox).Name == "tb_taxValue")
                    SectionData.InputJustNumber(ref txb);
                _Sender = sender;
                refreshTotalValue();
                e.Handled = true;


            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void refreshTotalValue()
        {
            decimal discountValue = 0;
            if (tb_discount.Text != "." && !tb_discount.Text.Equals(""))
                discountValue = decimal.Parse(tb_discount.Text);

            if (cb_typeDiscount.SelectedIndex != -1 && int.Parse(cb_typeDiscount.SelectedValue.ToString()) == 2) // discount type is rate
            {
                discountValue = SectionData.calcPercentage(_Sum, discountValue);
            }

            decimal total = _Sum - discountValue;
            decimal taxValue = 0;
            decimal taxInputVal = 0;
            if (!tb_taxValue.Text.Equals(""))
                taxInputVal = decimal.Parse(tb_taxValue.Text);
            if (total != 0)
                taxValue = SectionData.calcPercentage(total, taxInputVal);

            //tb_sum.Text = _Sum.ToString();
            if (_Sum != 0)
                tb_sum.Text = SectionData.DecTostring(_Sum);
            else
                tb_sum.Text = "0";
            total = total + taxValue;
            //tb_total.Text = Math.Round(total, 2).ToString();
            if (total != 0)
                tb_total.Text = SectionData.DecTostring(total);
            else tb_total.Text = "0";

        }


        #region billdetails
        bool firstTimeForDatagrid = true;
        async void refrishBillDetails()
        {
           
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;
            if (firstTimeForDatagrid)
            {
                await Task.Delay(1000);
                dg_billDetails.Items.Refresh();
                firstTimeForDatagrid = false;
            }
            DataGrid_CollectionChanged(dg_billDetails, null);
            //tb_sum.Text = _Sum.ToString();
            if (_Sum != 0)
                tb_sum.Text = SectionData.DecTostring(_Sum);
            else
                tb_sum.Text = "0";

        }
        void refrishDataGridItems()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;
            dg_billDetails.Items.Refresh();
        }

        // read item from barcode
        private async void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
                {
                    switch (e.Key)
                    {
                        case Key.P:
                            //handle P key
                            btn_printInvoice_Click(null, null);
                            break;
                        case Key.S:
                            //handle S key
                            Btn_save_Click(null, null);
                            break;
                        case Key.I:
                            //handle S key
                            Btn_items_Click(null, null);
                            break;
                    }
                }



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

                if (e.Key.ToString() == "Return" && _BarcodeStr != "")
                {
                    await dealWithBarcode(_BarcodeStr);
                    if (_Sender != null)
                    {
                        DatePicker dt = _Sender as DatePicker;
                        TextBox tb = _Sender as TextBox;
                        if (dt != null)
                        {
                            if (dt.Name == "dp_desrvedDate" || dt.Name == "dp_invoiceDate")
                                _BarcodeStr = _BarcodeStr.Substring(1);
                        }
                        else if (tb != null)
                        {
                            if (tb.Name == "tb_invoiceNumber" || tb.Name == "tb_note" || tb.Name == "tb_discount" || tb.Name == "tb_barcode")// remove barcode from text box
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
                    _BarcodeStr = "";

                    e.Handled = true;
                    cb_branch.SelectedValue = _SelectedBranch;
                }
                _Sender = null;
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
                case "pi":// this barcode for invoice               
                    Btn_newDraft_Click(null, null);
                    invoice = await invoiceModel.GetInvoicesByNum(barcode);
                    _InvoiceType = invoice.invType;
                    if (_InvoiceType.Equals("pd") || _InvoiceType.Equals("p") || _InvoiceType.Equals("pbd") || _InvoiceType.Equals("pb"))
                    {
                        // set title to bill
                        if (_InvoiceType == "pd")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                        }
                        else if (_InvoiceType == "p")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseBill");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                        }
                        else if (_InvoiceType == "pbd")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;
                        }
                        else if (_InvoiceType == "pb")
                        {
                           txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;
                        }

                        await fillInvoiceInputs(invoice);
                    }
                    break;

                default: // if barcode for item
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
                                int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId && p.OrderId == 0).FirstOrDefault());

                                if (index == -1)//item doesn't exist in bill
                                {
                                    // get item units
                                    itemUnits = await itemUnitModel.GetItemUnits(itemId);
                                    //get item from list
                                    item = items.ToList().Find(i => i.itemId == itemId);

                                    int count = 1;
                                    decimal price = 0; //?????
                                    decimal total = count * price;
                                      addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count, price, total);
                                }
                                else // item exist prevoiusly in list
                                {
                                    billDetails[index].Count++;
                                    billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;

                                    _Sum += billDetails[index].Price;

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
        private async void Tb_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (e.Key == Key.Return)
                {
                    string barcode = "";
                    if (_BarcodeStr.Length < 13)
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

        private void addRowToBill(string itemName, int itemId, string unitName, int itemUnitId, int count, decimal price, decimal total)
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
            });
            _Sum += total;
        }
        #endregion billdetails

        private void Cbm_unitItemDetails_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                //billDetails
                var cmb = sender as ComboBox;
                cmb.SelectedValue = (int)billDetails[0].itemUnitId;

                if (billDetails[0].OrderId != 0)
                    cmb.IsEnabled = false;
                else
                    cmb.IsEnabled = true;

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var cmb = sender as ComboBox;

                if (dg_billDetails.SelectedIndex != -1 && cmb.SelectedValue != null)
                {
                    billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
                    if (billDetails[dg_billDetails.SelectedIndex].OrderId != 0)
                        cmb.IsEnabled = false;
                    else
                        cmb.IsEnabled = true;
                }
                   
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
                //return;
            }
        }
        private void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
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

                                    if (item.OrderId != 0)
                                        combo.IsEnabled = false;
                                    else
                                        combo.IsEnabled = true;
                            }
                        }
                    }
                    count++;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Dg_billDetails_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (dg_billDetails.SelectedIndex != -1)
                if (billDetails[dg_billDetails.SelectedIndex].OrderId != 0)
                    e.Cancel = true;
        }


        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //if (invoice.invoiceId == 0 && e.Column.DisplayIndex == 3)
                //{

                //}
                //else
                //{
                TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
                    var columnName = e.Column.Header.ToString();

                    BillDetails row = e.Row.Item as BillDetails;
                    int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == row.itemUnitId && p.OrderId == row.OrderId).FirstOrDefault());

                    TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                    if (elapsed.TotalMilliseconds < 100)
                    {
                        if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
                            t.Text = billDetails[index].Count.ToString();
                        else if (columnName == MainWindow.resourcemanager.GetString("trPrice"))
                            t.Text = SectionData.DecTostring(billDetails[index].Price);

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

                        if (_InvoiceType == "pbd" || _InvoiceType == "pbw" || row.OrderId != 0)
                        {
                            ItemTransfer item = mainInvoiceItems.ToList().Find(i => i.itemUnitId == row.itemUnitId && i.invoiceId == row.OrderId);
                            if (newCount > item.quantity)
                            {
                                // return old value 
                                t.Text = item.quantity.ToString();

                                newCount = (long)item.quantity;
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
                            }
                        }

                        if (columnName == MainWindow.resourcemanager.GetString("trPrice") && !t.Text.Equals(""))
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

                        //refresh total cell
                        TextBlock tb = dg_billDetails.Columns[6].GetCellContent(dg_billDetails.Items[index]) as TextBlock;
                        tb.Text = SectionData.DecTostring(total);

                        //  refresh sum and total text box
                        refreshTotalValue();

                        // update item in billdetails           
                        billDetails[index].Count = (int)newCount;
                        billDetails[index].Price = newPrice;
                        billDetails[index].Total = total;
                    }
                refrishDataGridItems();
            //}
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


        private void Dp_date_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                _Sender = sender;
                moveControlToBarcode(sender, e);
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
        private void moveControlToBarcode(object sender, KeyEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                DatePicker dt = sender as DatePicker;
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds < 100)
                {
                    tb_barcode.Focus();
                    HandleKeyPress(sender, e);
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


        //print
        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(paymentsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    ////////////////////////////
                    Thread t1 = new Thread(() =>
                    {
                        pdfPurInvoice();
                    });
                    t1.Start();
                    ////////////////////////////
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

        public async void pdfPurInvoice()
        {
            if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
              || invoice.invType == "sbd" || invoice.invType == "pbd"
              || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
            {
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintDraftInvoice"), animation: ToasterAnimation.FadeIn);
            }
            else
            {

                List<ReportParameter> paramarr = new List<ReportParameter>();

                string reppath = reportclass.GetpayInvoiceRdlcpath(invoice);
                if (invoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                    Agent agentinv = new Agent();
                    agentinv = vendors.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                    invoice.agentCode = agentinv.code;
                    //new lines
                    invoice.agentName = agentinv.name;
                    invoice.agentCompany = agentinv.company;

                    User employ = new User();
                    employ = await employ.getUserById((int)invoice.updateUserId);
                    invoice.uuserName = employ.name;
                    invoice.uuserLast = employ.lastname;


                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        invoice.branchName = branch.name;
                    }


                    ReportCls.checkLang();
                    foreach (var i in invoiceItems)
                    {
                        i.price = decimal.Parse(SectionData.DecTostring(i.price));
                    }
                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillPurInvReport(invoice, paramarr);

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
        public async void previewPurInvoice()
        {
            if (invoice.invoiceId > 0)
            {
                
                 Window.GetWindow(this).Opacity = 0.2;

                List<ReportParameter> paramarr = new List<ReportParameter>();
                string pdfpath;

                //
                pdfpath = @"\Thumb\report\temp.pdf";
                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                string reppath = reportclass.GetpayInvoiceRdlcpath(invoice);
                if (invoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                    if (invoice.agentId != null)
                    {
                        Agent agentinv = new Agent();
                        agentinv = vendors.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                        invoice.agentCode = agentinv.code;
                        //new lines
                        invoice.agentName = agentinv.name;
                        invoice.agentCompany = agentinv.company;
                    }
                    else
                    {

                        invoice.agentCode = "-";
                        //new lines
                        invoice.agentName = "-";
                        invoice.agentCompany = "-";
                    }

                    invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        invoice.branchName = branch.name;
                    }

                    User employ = new User();
                    employ = await employ.getUserById((int)invoice.updateUserId);
                    invoice.uuserName = employ.name;
                    invoice.uuserLast = employ.lastname;

                    ReportCls.checkLang();
                    foreach (var r in invoiceItems)
                    {
                        r.price = decimal.Parse(SectionData.DecTostring(r.price));
                        //r.deserveDate = Convert.ToDateTime(SectionData.DateToString(r.deserveDate));
                    }
                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillPurInvReport(invoice, paramarr);

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
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trSaveInvoiceToPreview"), animation: ToasterAnimation.FadeIn);

            }

        }
        public async void printPurInvoice()
        {

            if (prInvoiceId > 0)
            {
                prInvoice = new Invoice();
                prInvoice = await invoiceModel.getById(prInvoiceId);
                //
                if (prInvoice.invType == "pd" || prInvoice.invType == "sd" || prInvoice.invType == "qd"
                             || prInvoice.invType == "sbd" || prInvoice.invType == "pbd"
                             || prInvoice.invType == "ord" || prInvoice.invType == "imd" || prInvoice.invType == "exd")
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPrintDraftInvoice"), animation: ToasterAnimation.FadeIn);
                }
                else
                {
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string reppath = reportclass.GetpayInvoiceRdlcpath(prInvoice);
                    if (prInvoice.invoiceId > 0)
                    {
                        invoiceItems = await invoiceModel.GetInvoicesItems(prInvoice.invoiceId);
                        Agent agentinv = new Agent();
                        agentinv = vendors.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();

                        User employ = new User();
                        employ = await employ.getUserById((int)prInvoice.updateUserId);
                        prInvoice.uuserName = employ.name;
                        prInvoice.uuserLast = employ.lastname;

                        prInvoice.agentCode = agentinv.code;
                        //new lines
                        prInvoice.agentName = agentinv.name;
                        prInvoice.agentCompany = agentinv.company;

                        invoiceItems = await invoiceModel.GetInvoicesItems(prInvoice.invoiceId);
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
                        clsReports.setReportLanguage(paramarr);
                        clsReports.Header(paramarr);
                        paramarr = reportclass.fillPurInvReport(prInvoice, paramarr);

                        rep.SetParameters(paramarr);
                        rep.Refresh();
                        this.Dispatcher.Invoke(() =>
                        {
                            LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.pur_copy_count));
                        });
                    }
                }

                //
            }

        }

        public async void sendPurEmail()
        {
            //
            if (prInvoiceId > 0)
            {
                prInvoice = new Invoice();
                prInvoice = await invoiceModel.getById(prInvoiceId);

                if (prInvoice.invType == "pd" || prInvoice.invType == "sd" || prInvoice.invType == "qd"
                || prInvoice.invType == "sbd" || prInvoice.invType == "pbd"
                || prInvoice.invType == "ord" || prInvoice.invType == "imd" || prInvoice.invType == "exd")
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trCanNotSendDraftInvoice"), animation: ToasterAnimation.FadeIn);
                }
                else
                {
                    if (prInvoice.invType == "pw")
                    {
                        invoiceItems = await invoiceModel.GetInvoicesItems(prInvoice.invoiceId);
                        SysEmails email = new SysEmails();
                        EmailClass mailtosend = new EmailClass();
                        email = await email.GetByBranchIdandSide((int)MainWindow.branchID, "mg");
                        Agent toAgent = new Agent();


                        toAgent = vendors.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();

                        invoice.agentCode = toAgent.code;
                        //new lines
                        invoice.agentName = toAgent.name;
                        invoice.agentCompany = toAgent.company;
                        if (toAgent == null)
                        {
                            //edit warning message to customer
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTheVendorHasNoEmail"), animation: ToasterAnimation.FadeIn);

                        }
                        else
                        {
                            //  int? itemcount = invoiceItems.Count();
                            if (email.emailId == 0)
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoEmailForThisDept"), animation: ToasterAnimation.FadeIn);
                            else
                            {
                                if (prInvoice.invoiceId == 0)
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trThereIsNoOrderToSen"), animation: ToasterAnimation.FadeIn);
                                else
                                {
                                    if (invoiceItems == null || invoiceItems.Count() == 0)
                                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trThereIsNoItemsToSend"), animation: ToasterAnimation.FadeIn);
                                    else
                                    {

                                        if (toAgent.email.Trim() == "")
                                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTheVendorHasNoEmail"), animation: ToasterAnimation.FadeIn);
                                        else
                                        {
                                            SetValues setvmodel = new SetValues();


                                            List<SetValues> setvlist = new List<SetValues>();
                                            if (prInvoice.invType == "pw")
                                            {
                                                setvlist = await setvmodel.GetBySetName("pur_email_temp");
                                            }
                                            else if (prInvoice.invType == "or")
                                            {
                                                setvlist = await setvmodel.GetBySetName("sale_order_email_temp");
                                            }
                                            foreach(var i in invoiceItems)
                                            {
                                                i.price = decimal.Parse(SectionData.DecTostring(i.price));
                                            }
                                            
                                            mailtosend = mailtosend.fillSaleTempData(prInvoice, invoiceItems, email, toAgent, setvlist);
                                            string pdfpath = await SavePurpdf(); 
                                            //SavePurpdf();
                                            //string pdfpath = emailpdfpath;
                                            mailtosend.AddAttachTolist(pdfpath);
                                            
                                            string msg = "";
                                            this.Dispatcher.Invoke(new Action(() =>
                                            {
                                                msg = mailtosend.Sendmail();// temp comment
                                                if (msg == "Failure sending mail.")
                                                {
                                                    // msg = "No Internet connection";

                                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoInternetConnection"), animation: ToasterAnimation.FadeIn);
                                                }
                                                else if (msg == "mailsent")
                                                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailSent"), animation: ToasterAnimation.FadeIn);
                                                else
                                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailNotSent"), animation: ToasterAnimation.FadeIn);
                                            }));

                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("only purshase invoice");
                    }
                }
                //
            }
            else
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trThereIsNoItemsToSend"), animation: ToasterAnimation.FadeIn);
                }));
            }


            //
        }
        //public async void SavePurpdf()

        public async Task<string> SavePurpdf()
        {
            string pdfpath;
            pdfpath = @"\Thumb\report\File.pdf";
            if (prInvoiceId > 0)
            {
                prInvoice = new Invoice();
                prInvoice = await invoiceModel.getById(prInvoiceId);

                List<ReportParameter> paramarr = new List<ReportParameter>();

                //

                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                string reppath = reportclass.GetpayInvoiceRdlcpath(prInvoice);
                if (prInvoice.invoiceId > 0)
                {
                    invoiceItems = await invoiceModel.GetInvoicesItems(prInvoice.invoiceId);
                    if (prInvoice.agentId != null)
                    {
                        Agent agentinv = new Agent();
                        agentinv = vendors.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();

                        prInvoice.agentCode = agentinv.code;
                        //new lines
                        prInvoice.agentName = agentinv.name;
                        prInvoice.agentCompany = agentinv.company;
                    }
                    else
                    {

                        prInvoice.agentCode = "-";
                        //new lines
                        prInvoice.agentName = "-";
                        prInvoice.agentCompany = "-";
                    }

                    invoiceItems = await invoiceModel.GetInvoicesItems(prInvoice.invoiceId);
                    Branch branch = new Branch();
                    branch = await branchModel.getBranchById((int)prInvoice.branchCreatorId);
                    if (branch.branchId > 0)
                    {
                        prInvoice.branchName = branch.name;
                    }

                    User employ = new User();
                    employ = await employ.getUserById((int)prInvoice.updateUserId);
                    prInvoice.uuserName = employ.name;
                    prInvoice.uuserLast = employ.lastname;

                    ReportCls.checkLang();
                    foreach (var i in invoiceItems)
                    {
                        i.price = decimal.Parse(SectionData.DecTostring(i.price));
                    }
                    clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);
                    paramarr = reportclass.fillPurInvReport(prInvoice, paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        LocalReportExtensions.ExportToPDF(rep, pdfpath);
                    }));
                }
            }
            return pdfpath;
        }
        private  void btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(paymentsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    prInvoiceId = invoice.invoiceId;
              
                    ////////////////////////////
                    Thread t1 = new Thread(() =>
                    {
                        printPurInvoice();

                    });
                    t1.Start();
                    ////////////////////////////
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
        //

        private async void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(paymentsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    /////////////////////
                    previewPurInvoice();
                    /////////////////////
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

        private async void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //items

                Window.GetWindow(this).Opacity = 0.2;
                wd_items w = new wd_items();
                w.CardType = "purchase";
                w.ShowDialog();
                if (w.isActive)
                {

                    ////// w.selectedItem this is ItemId
                    for (int i = 0; i < w.selectedItems.Count; i++)
                    {
                        int itemId = w.selectedItems[i];
                        await ChangeItemIdEvent(itemId);
                    }
                    refreshTotalValue();
                    refrishBillDetails();
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

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                clearInvoice();
                _InvoiceType = "pd";
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


        private void Tb_barcode_TextChanged(object sender, TextChangedEventArgs e)
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

        private void Btn_payments_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (invoice != null && invoice.invoiceId != 0)
                {
                    if (MainWindow.groupObject.HasPermissionAction(paymentsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                    {
                        Window.GetWindow(this).Opacity = 0.2;
                        wd_cashTransfer w = new wd_cashTransfer();

                        w.invId = invoice.invoiceId;
                        w.title = MainWindow.resourcemanager.GetString("trPayments"); 
                        w.ShowDialog();

                        Window.GetWindow(this).Opacity = 1;
                    }
                    else
                        Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private void Btn_emailMessage_Click(object sender, RoutedEventArgs e)
        {//email
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(paymentsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    prInvoiceId = invoice.invoiceId;
                    ///////////////////////////////////
                    Thread t1 = new Thread(() =>
                    {
                        sendPurEmail();
                    });
                    t1.Start();
                    ////////////////////////////////////
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
            clearInvoice();
            invoice = invoices[index];
            _invoiceId = invoice.invoiceId;
            navigateBtnActivate();
            await fillInvoiceInputs(invoice);
        }
        private async void Btn_previous_Click(object sender, RoutedEventArgs e)
        {
            int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
            index--;
            clearInvoice();
            invoice = invoices[index];
            _invoiceId = invoice.invoiceId;
            navigateBtnActivate();
            await fillInvoiceInputs(invoice);
        }
        #endregion

        private async void Btn_shortageInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (invoice.invoiceId != 0)
                clearInvoice();
            await buildShortageInvoiceDetails();
        }
        private async Task buildShortageInvoiceDetails()
        {
            //get invoice items
            invoiceItems = await invoice.getShortageItems(MainWindow.branchID.Value);
            mainInvoiceItems = invoiceItems;
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
                    OrderId = (int)itemT.invoiceId,
                    Price = decimal.Parse(SectionData.DecTostring((decimal)itemT.price)),
                    Total = total,
                });
            }

            tb_barcode.Focus();

            refrishBillDetails();
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

    }
}

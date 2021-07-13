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
    public partial class uc_payInvoice : UserControl
    {
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
            InitializeComponent();
        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        //Category categoryModel = new Category();
        //Category category = new Category();
        //IEnumerable<Category> categories;
        //IEnumerable<Category> categoriesQuery;
        //int? categoryParentId = 0;

        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;
        ItemLocation itemLocationModel = new ItemLocation();

        Branch branchModel = new Branch();
        IEnumerable<Branch> branches;

        Agent agentModel = new Agent();
        IEnumerable<Agent> vendors;

        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;

        Invoice invoiceModel = new Invoice();
        Invoice invoice = new Invoice();

        List<ItemTransfer> invoiceItems;
        List<ItemTransfer> mainInvoiceItems;
        //  Bill bill;

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
        static private decimal _Sum = 0;
        static private string _InvoiceType = "pd"; // purchase draft

        // for report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////
            //txt_invoiceHeader.Text = MainWindow.resourcemanager.GetString("trInvoice");
            //txt_invoice.Text = MainWindow.resourcemanager.GetString("trInvoice");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trBranchHint"));
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trAmount");
            dg_billDetails.Columns[5].Header = MainWindow.resourcemanager.GetString("trPrice");
            dg_billDetails.Columns[6].Header = MainWindow.resourcemanager.GetString("trTotal");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_discount, MainWindow.resourcemanager.GetString("trDiscountHint"));
            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal");
            //btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            //btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdfBtn");
            //btn_printInvoice.Content = MainWindow.resourcemanager.GetString("trPrint");

            ////////////////////////////////----vendor----/////////////////////////////////

            txt_vendor.Text = MainWindow.resourcemanager.GetString("trVendor");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendor, MainWindow.resourcemanager.GetString("trVendorHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_paid, MainWindow.resourcemanager.GetString("trPaidHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_deserved, MainWindow.resourcemanager.GetString("trDeservedHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            txt_vendorIvoiceDetails.Text = MainWindow.resourcemanager.GetString("trVendorInvoiceDetails");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_invoiceNumber, MainWindow.resourcemanager.GetString("trInvoiceNumberHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_invoiceDate, MainWindow.resourcemanager.GetString("trInvoiceDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
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
                w.contentText = "Do you want save pay invoice in drafts?";
                w.ShowDialog();
                MainWindow.mainWindow.Opacity = 1;
                #endregion
                if (w.isOk)
                    Btn_newDraft_Click(null, null);
                else
                    clearInvoice();
            }
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // for pagination
            //btns = new Button[] { btn_firstPage, btn_prevPage, btn_activePage, btn_nextPage, btn_lastPage };
            //MainWindow.mainWindow.RemoveHandler(HandleKeyPress);
            MainWindow.mainWindow.KeyDown += HandleKeyPress;

            //var window = Window.GetWindow(this);
            //window.KeyDown -= HandleKeyPress;
            //window.KeyDown += HandleKeyPress;

            dp_desrvedDate.SelectedDateChanged += this.dp_SelectedDateChanged;
            dp_invoiceDate.SelectedDateChanged += this.dp_SelectedDateChanged;

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucPayInvoice.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucPayInvoice.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();
            catigoriesAndItemsView.ucPayInvoice = this;
            await RefrishItems();
            //await RefrishCategories();
            //RefrishCategoriesCard();
            //Txb_searchitems_TextChanged(null, null);
            configureDiscountType();
            await RefrishBranches();
            await RefrishVendors();
            await fillBarcodeList();

            #region Style Date
            SectionData.defaultDatePickerStyle(dp_desrvedDate);
            SectionData.defaultDatePickerStyle(dp_invoiceDate);
            #endregion

            //tb_taxValue.Text = MainWindow.tax.ToString();
            tb_barcode.Focus();
            #region datagridChange
            CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
            ((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
            #endregion
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
        }

        #endregion
        #region Tab
        /*
         private void btn_payInvoice_Click(object sender, RoutedEventArgs e)
         {
             grid_vendor.Visibility   = Visibility.Collapsed;
             grid_payinvoice.Visibility = Visibility.Visible;
             brd_vendorTab.BorderBrush =  (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
             brd_payInvoiceTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
         }

         private void btn_vendor_Click(object sender, RoutedEventArgs e)
         {
             grid_payinvoice.Visibility = Visibility.Collapsed;
             grid_vendor.Visibility = Visibility.Visible;
             brd_payInvoiceTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4e4e4e"));
             brd_vendorTab.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
         }

         */
        #endregion
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

        }
        #endregion


        private void Btn_updateVendor_Click(object sender, RoutedEventArgs e)
        {
            if (cb_vendor.SelectedIndex != -1)
            {
                Window.GetWindow(this).Opacity = 0.2;

                //if (((( ).Parent as Grid).Parent as UserControl) != null)
                Window.GetWindow(this).Opacity = 0.2;
                wd_updateVendor w = new wd_updateVendor();
                //// pass agent id to update windows
                w.agent.agentId = (int)cb_vendor.SelectedValue;
                //w.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00178DD2"));
                w.ShowDialog();


                Window.GetWindow(this).Opacity = 1;
            }
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
            vendors = await agentModel.GetAgentsActive("v");
            cb_vendor.ItemsSource = vendors;
            cb_vendor.DisplayMemberPath = "name";
            cb_vendor.SelectedValuePath = "agentId";
        }
        async Task RefrishBranches()
        {
            branches = await branchModel.GetBranchesActive("all");
            cb_branch.ItemsSource = branches;
            cb_branch.DisplayMemberPath = "name";
            cb_branch.SelectedValuePath = "branchId";
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
                    // create new row in bill details data grid
                    addRowToBill(item.name, itemId, defaultPurUnit.mainUnit, defaultPurUnit.itemUnitId, 1, 0, 0);

                    refreshTotalValue();
                    refrishBillDetails();
                }
            }
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
        

        private void input_LostFocus(object sender, RoutedEventArgs e)
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
        #endregion
        #region save invoice

        private async Task addInvoice(string invType, string invCode)
        {
            if (invoice.invType == "pw" && (invType == "pb" || invType == "pbd")) // invoice is purchase and will bebounce purchase  or purchase bounce draft bounce , save another invoice in db
            {
                invoice.invoiceMainId = invoice.invoiceId;
                invoice.invoiceId = 0;
                invoice.invNumber = await invoice.generateInvNumber("pb");
            }
            if(invoice.branchCreatorId == 0 || invoice.branchCreatorId == null)
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

                if (cb_vendor.SelectedIndex != -1)
                    invoice.agentId = (int)cb_vendor.SelectedValue;

                if (cb_branch.SelectedIndex != -1)
                    invoice.branchId = (int)cb_branch.SelectedValue;

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

                // calculate deserved and paid (compare vendor balance with totalNet)  
                Agent vendor = vendors.ToList().Find(b => b.agentId == invoice.agentId);
                decimal balance = 0;
                if (vendor != null)
                    balance = (decimal)vendor.balance;
                decimal paid = 0;
                decimal deserved = (decimal)invoice.totalNet;

                if (invType == "pw")
                {
                    invoice.invNumber = await invoice.generateInvNumber(invCode);
                    //deserved = 0;
                    //paid = (decimal)invoice.totalNet;
                    //balance = (decimal)(balance + invoice.totalNet);

                    if (balance >= invoice.totalNet)
                    {
                        paid = (decimal)invoice.totalNet;
                        deserved = 0;
                        balance = (decimal)(balance - invoice.totalNet);
                    }
                    else
                    {
                        paid = balance;
                        deserved = (decimal)(invoice.totalNet - balance);
                        balance = 0;
                    }
                }
                else if (invType == "pb")
                {
                    invoice.invNumber = await invoice.generateInvNumber(invCode);
                    deserved = 0;
                    paid = (decimal)invoice.totalNet;
                    balance = (decimal)(balance + invoice.totalNet);
                    //if (balance >= invoice.totalNet)
                    //{
                    //    paid = (decimal)invoice.totalNet;
                    //    deserved = 0;
                    //    balance = (decimal)(balance - invoice.totalNet);
                    //}
                    //else
                    //{
                    //    paid = balance;
                    //    deserved = (decimal)(invoice.totalNet - balance);
                    //    balance = 0;
                    //}
                }
                invoice.paid = paid;
                invoice.deserved = deserved;

                // save invoice in DB
                int invoiceId = int.Parse(await invoiceModel.saveInvoice(invoice));

                if (invoiceId != 0)
                {
                    // edit vendor balance , add cach transfer
                    if (paid > 0)
                    {
                        CashTransfer cashTrasnfer = new CashTransfer();
                        cashTrasnfer.posId = MainWindow.posID;
                        cashTrasnfer.agentId = invoice.agentId;
                        cashTrasnfer.invId = invoiceId;
                        cashTrasnfer.cash = paid;
                        cashTrasnfer.side = "v"; // vendor
                        cashTrasnfer.createUserId = MainWindow.userID;
                        ///processType 
                        cashTrasnfer.processType = "balance";

                        ///


                        if (invType == "pw")// purchase wait
                        {
                            cashTrasnfer.transType = "p"; //pull
                            cashTrasnfer.transNum = SectionData.generateNumber('p', "v").ToString();
                        }
                        else if (_InvoiceType == "pbw")//purchase bounce
                        {
                            cashTrasnfer.transType = "d"; //deposit
                            cashTrasnfer.transNum = SectionData.generateNumber('d', "v").ToString();

                            //pull items from free zone
                            await itemLocationModel.returnInvoice(invoiceItems, invoice.branchCreatorId.Value, MainWindow.userID.Value); // increase item quantity in DB
                        }
                        await cashTrasnfer.Save(cashTrasnfer); //add cash transfer
                        await agentModel.updateBalance((int)invoice.agentId, balance);//update balance
                    }

                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                }
                else
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);


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
        }
        //private async Task<string> generateInvNumber(string invoiceCode)
        //{
        //    Branch store = branches.ToList().Find(b => b.branchId == invoice.branchId);
        //    string storeCode = "";
        //    if (store != null)
        //        storeCode = store.code;
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
        private void dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //DateTime invoiceDate;
            DateTime desrveDate;
            if ( dp_desrvedDate.SelectedDate != null)
            {
                //invoiceDate = (DateTime)dp_invoiceDate.SelectedDate.Value.Date;
                desrveDate = (DateTime)dp_desrvedDate.SelectedDate.Value.Date;
                if (desrveDate.Date < DateTime.Now.Date)
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorInvDateAfterDeserveToolTip"), animation: ToasterAnimation.FadeIn);
                    dp_desrvedDate.Text = "";
                }
            }
        }
        private void validateInvoiceValues()
        {
            //bool isValid = true;
            SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
            SectionData.validateEmptyComboBox(cb_vendor, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip");
            SectionData.validateEmptyTextBox(tb_invoiceNumber, p_errorInvoiceNumber, tt_errorInvoiceNumber, "trErrorEmptyInvNumToolTip");
            SectionData.validateEmptyDatePicker(dp_desrvedDate, p_errorDesrvedDate, tt_errorDesrvedDate, "trErrorEmptyDeservedDate");
            //SectionData.validateSmalThanDateNowDatePicker(dp_desrvedDate, p_errorDesrvedDate, tt_errorDesrvedDate, "trErrorEmptyDeservedDate");
            //return isValid;
        }
        bool logInProcessing = true;
        void awaitSaveBtn(bool isAwait)
        {
            if (isAwait == true)
            {
                btn_save.IsEnabled = false;
                wait_saveBtn.Visibility = Visibility.Visible;
                wait_saveBtn.IsIndeterminate = true;
            }
            else
            {
                btn_save.IsEnabled = true;
                wait_saveBtn.Visibility = Visibility.Collapsed;
                wait_saveBtn.IsIndeterminate = false;
            }


        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (logInProcessing)
            {
                logInProcessing = false;
                awaitSaveBtn(true);

                //check mandatory inputs
                validateInvoiceValues();
            TextBox tb = (TextBox)dp_desrvedDate.Template.FindName("PART_TextBox", dp_desrvedDate);
                if (cb_branch.SelectedIndex != -1 && cb_vendor.SelectedIndex != -1 && !tb_invoiceNumber.Equals("") && billDetails.Count > 0
                    && !tb.Text.Trim().Equals("")   )
            {
                if (_InvoiceType == "pbd") //pbd means purchase bounse draft
                    await addInvoice("pb", "pb"); // pb means purchase bounce
                else if (_InvoiceType == "pbw")//pbw  purchase invoice
                    await addInvoice("pb", "pb");
                else//pw  waiting purchase invoice
                    await addInvoice("pw", "pi");

                if (invoice.invoiceId == 0) clearInvoice();
            }
                awaitSaveBtn(false);
                logInProcessing = true;
            }
        }
        private async void Btn_newDraft_Click(object sender, RoutedEventArgs e)
        {
            if (billDetails.Count > 0)
            {
                await addInvoice(_InvoiceType, "pi");
            }
            else
            {
                clearInvoice();
            }
        }
        private void clearInvoice()
        {
            _Sum = 0;
            _SequenceNum = 0;
            _SelectedBranch = -1;
            _SelectedVendor = -1;
            _InvoiceType = "pd";
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
            tb_total.Text = "";
            tb_sum.Text = null;
            tb_taxValue.Text = MainWindow.tax.ToString();

            TextBox tbStartDate = (TextBox)dp_desrvedDate.Template.FindName("PART_TextBox", dp_desrvedDate);
            SectionData.clearValidate(tbStartDate, p_errorDesrvedDate);
            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));

            btn_updateVendor.IsEnabled = false;
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseBill");
            refrishBillDetails();
            inputEditable();
        }
        #endregion
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            // purchase drafts and purchase bounce drafts
            // string[] typeArr = { "pd","pdbd" };
            w.invoiceType = "pd ,pbd";
            //w.branchId = int.Parse(MainWindow.branchID.ToString());
            w.userId = MainWindow.userLogin.userId;

            w.title = MainWindow.resourcemanager.GetString("trDrafts");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    //this.DataContext = invoice;
                  //  mainInvoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceMainId.Value);
                    _InvoiceType = invoice.invType;

                   await fillInvoiceInputs(invoice);
                    if (_InvoiceType == "pd")// set title to bill
                    {
                        mainInvoiceItems = invoiceItems;
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");
                        brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                    }
                    if (_InvoiceType == "pbd")
                    {
                        mainInvoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceMainId.Value);
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                        brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));

                    }
                }
            }
            Window.GetWindow(this).Opacity = 1;
        }
        private async void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            // purchase invoices
            //w.invoiceType = "pw";
            w.invoiceType = "p , pw";
            w.branchCreatorId = MainWindow.branchID.Value;
            
            w.title = MainWindow.resourcemanager.GetString("trPurchaseInvoices");

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    
                    this.DataContext = invoice;

                    _InvoiceType = invoice.invType;
                    // set title to bill
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
                    brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                   await fillInvoiceInputs(invoice);

                }
            }
            Window.GetWindow(this).Opacity = 1;
        }
        private async Task fillInvoiceInputs(Invoice invoice)
        {
            _Sum = (decimal)invoice.total;

            cb_branch.SelectedValue = invoice.branchId;
            cb_vendor.SelectedValue = invoice.agentId;
            dp_desrvedDate.Text = invoice.deservedDate.ToString();
            tb_invoiceNumber.Text = invoice.vendorInvNum;
            dp_invoiceDate.Text = invoice.vendorInvDate.ToString();
            tb_total.Text = Math.Round((double)invoice.totalNet, 2).ToString();
            tb_taxValue.Text = invoice.tax.ToString();
            tb_note.Text = invoice.notes;
            tb_sum.Text = invoice.total.ToString();
            tb_discount.Text = invoice.discountValue.ToString();

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
            Window.GetWindow(this).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            w.title = MainWindow.resourcemanager.GetString("trPurchaseInvoices");         
            // purchase invoices
            //w.invoiceType = "pw"; // invoice type to view in grid
            w.invoiceType = "p , pw"; // invoice type to view in grid
            w.branchCreatorId = MainWindow.branchID.Value;

            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    _InvoiceType = "pbd";
                    invoice = w.invoice;

                    this.DataContext = invoice;

                   await fillInvoiceInputs(invoice);
                    mainInvoiceItems = invoiceItems;
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                    brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                }
            }
            Window.GetWindow(this).Opacity = 1;
        }
        private async void Btn_returnWInvoice_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_invoice w = new wd_invoice();

            w.title = MainWindow.resourcemanager.GetString("trPurchaseInvoices");
            w.branchId = MainWindow.branchID.Value;
            // purchase invoices
            w.invoiceType = "pbw"; // invoice type to view in grid
            if (w.ShowDialog() == true)
            {
                if (w.invoice != null)
                {
                    invoice = w.invoice;
                    _InvoiceType = invoice.invType;
                   
                    mainInvoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceMainId.Value);
                    this.DataContext = invoice;

                    await fillInvoiceInputs(invoice);

                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                    brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                }
            }
            Window.GetWindow(this).Opacity = 1;
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
        private void inputEditable()
        {
            if (_InvoiceType == "pbd" || _InvoiceType == "pbw") // return invoice
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
                btn_updateVendor.IsEnabled = false;
                tb_invoiceNumber.IsEnabled = false;
                tb_taxValue.IsEnabled = false;
            }
            else if (_InvoiceType == "pd")
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
                btn_updateVendor.IsEnabled = true;
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
                btn_updateVendor.IsEnabled = false;
                tb_invoiceNumber.IsEnabled = false;
                tb_taxValue.IsEnabled = false;
            }
        }
        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
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

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void Btn_pay_Click(object sender, RoutedEventArgs e)
        {
            //  btn_vendor_Click(null, null);
        }

        private void Cb_branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        private void Cb_vendor_KeyUp(object sender, KeyEventArgs e)
        {
            cb_vendor.ItemsSource = vendors.Where(x => x.name.Contains( cb_vendor.Text));
        }
        private void Cb_vendor_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            if (cb_vendor.SelectedIndex != -1)
                btn_updateVendor.IsEnabled = true;
        }
        private void Tb_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Sender = sender;
        }
        private void Cb_typeDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        private void tb_discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Sender = sender;
            refreshTotalValue();
            e.Handled = true;
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

            tb_sum.Text = _Sum.ToString();
            total = total + taxValue;
            tb_total.Text = Math.Round(total, 2).ToString();
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
        void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;

            tb_sum.Text = _Sum.ToString();
        }


        // read item from barcode
        private async void HandleKeyPress(object sender, KeyEventArgs e)
        {

            if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
            {
                switch (e.Key)
                {
                    case Key.P:
                        //handle D key
                        //MessageBox.Show("You want Print");
                        btn_printInvoice_Click(null, null);
                        break;
                    case Key.S:
                        //handle X key
                        //MessageBox.Show("You want Save");
                        Btn_save_Click(null, null);
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
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        else if (_InvoiceType == "p")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseBill");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                        }
                        else if (_InvoiceType == "pbd")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
                        }
                        else if (_InvoiceType == "pb")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                            // orange #FFA926 red #D22A17
                            brd_total.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D22A17"));
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
                                int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId).FirstOrDefault());

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
            if (e.Key == Key.Return)
            {
                string barcode = "";
                if (_BarcodeStr.Length < 13)
                {
                    barcode = tb_barcode.Text;
                    await dealWithBarcode(barcode);
                }
                //if (barcodesList != null && _BarcodeStr.Length < 13) //_BarcodeStr == "" barcode not from barcode reader
                //{
                //    ItemUnit unit1 = barcodesList.ToList().Find(c => c.barcode == tb_barcode.Text);

                //    // get item matches the barcode
                //    if (unit1 != null)
                //    {
                //        int itemId = (int)unit1.itemId;
                //        if (unit1.itemId != 0)
                //        {
                //            int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == unit1.itemUnitId).FirstOrDefault());
                //            //item doesn't exist in bill
                //            if (index == -1)
                //            {
                //                // get item units
                //                itemUnits = await itemUnitModel.GetItemUnits(itemId);
                //                //get item from list
                //                item = items.ToList().Find(i => i.itemId == itemId);

                //                int count = 1;
                //                decimal price = 0; //?????
                //                decimal total = count * price;
                //                addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count, price, total);
                //            }
                //            else // item exist prevoiusly in list
                //            {
                //                billDetails[index].Count++;
                //                billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;

                //                _Sum += billDetails[index].Price;

                //            }
                //            refreshTotalValue();
                //            refrishBillDetails();
                //        }
                //    }
                //    else
                //    {
                //        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorItemNotFoundToolTip"), animation: ToasterAnimation.FadeIn);
                //    }
                //}
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
            //billDetails
            if (billDetails.Count == 1)
            {
                var cmb = sender as ComboBox;
                cmb.SelectedValue = (int)billDetails[0].itemUnitId;
            }
        }
        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = sender as ComboBox;

            if (dg_billDetails.SelectedIndex != -1)
                billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
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

        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
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

                if (_InvoiceType == "pbd" || _InvoiceType == "pbw")
                {
                    ItemTransfer item = mainInvoiceItems.ToList().Find(i => i.itemUnitId == row.itemUnitId);
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
                tb.Text = total.ToString();

                //  refresh sum and total text box
                refreshTotalValue();

                // update item in billdetails           
                billDetails[index].Count = (int)newCount;
                billDetails[index].Price = newPrice;
                billDetails[index].Total = total;
            }
        }

        //private void Dp_desrvedDate_KeyDown(object sender, KeyEventArgs e)
        //{
        //    moveControlToBarcode(sender , e);          
        //}
        private void Dp_date_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            _Sender = sender;
            moveControlToBarcode(sender, e);
        }
        private void moveControlToBarcode(object sender, KeyEventArgs e)
        {
            DatePicker dt = sender as DatePicker;
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds < 100)
            {
                tb_barcode.Focus();
                HandleKeyPress(sender, e);
            }
        }
        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

            ReportParameter[] paramarr = new ReportParameter[20];

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Purchase\Ar\ArInvPurReport.rdlc";
            }
            else addpath = @"\Reports\Purchase\En\InvPurReport.rdlc";

            //

            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
            if (invoice.invoiceId > 0)
            {
                invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                ReportCls.checkLang();

                clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);
                paramarr = reportclass.fillPurInvReport(invoice, paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();

                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {

                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
                }
            }



        }

        private void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            //items

            Window.GetWindow(this).Opacity = 0.2;
            wd_items w = new wd_items();
            w.CardType = "purchase";
            w.ShowDialog();
            if (w.isActive)
            {
                ////// w.selectedItem this is ItemId
                ChangeItemIdEvent(w.selectedItem);
            }

            Window.GetWindow(this).Opacity = 1;
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            clearInvoice();
        }

        private async void btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {
            ReportParameter[] paramarr = new ReportParameter[20];

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Purchase\Ar\ArInvPurReport.rdlc";
            }
            else addpath = @"\Reports\Purchase\En\InvPurReport.rdlc";

            //

            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
            if (invoice.invoiceId > 0)
            {
                invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                ReportCls.checkLang();

                clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);
                paramarr = reportclass.fillPurInvReport(invoice, paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();



                LocalReportExtensions.PrintToPrinter(rep);
            }
        }

        private void Tb_barcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Sender = sender;
        }

       
    }
}

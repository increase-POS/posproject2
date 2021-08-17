﻿using netoaster;
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
using System.Net.Mail;

namespace POS.View.purchases
{
    /// <summary>
    /// Interaction logic for uc_purchaseOrder.xaml
    /// </summary>
    public partial class uc_purchaseOrder : UserControl
    {
        private static uc_purchaseOrder _instance;
        public static uc_purchaseOrder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_purchaseOrder();
                return _instance;
            }
        }
        public uc_purchaseOrder()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }

        private async void Btn_purchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

                w.invoiceType = "po";
                w.userId = MainWindow.userLogin.userId;
                w.duration = 1; // view purchase orders which created during  last one day 

                w.title = MainWindow.resourcemanager.GetString("trPurchaseOrders");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;
                        _InvoiceType = invoice.invType;

                        await fillInvoiceInputs(invoice);

                        mainInvoiceItems = invoiceItems;
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaceOrder");
                        refreshDocCount(invoice.invoiceId);
                    }
                }
                Window.GetWindow(this).Opacity = 1;
                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        string createPermission = "purchaseOrder_create";
        string reportsPermission = "purchaseOrder_reports";
        string sendEmailPermission = "purchaseOrder_sendEmail";

        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();

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
        public Invoice invoice = new Invoice();

        List<ItemTransfer> invoiceItems;
        List<ItemTransfer> mainInvoiceItems;
        //  Bill bill;

        #region //to handle barcode characters
        static private int _SelectedVendor = -1;
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
        static public string _InvoiceType = "pod"; // purchase order draft
        static private decimal _Count = 0;
        // for report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        private void translate()
        {
            ////////////////////////////////----invoice----/////////////////////////////////
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNum");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trQuantity");

            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaceOrder");
            txt_barcode.Text = MainWindow.resourcemanager.GetString("trBarcode");
            txt_vendor.Text = MainWindow.resourcemanager.GetString("trVendor");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            tb_count.Text = MainWindow.resourcemanager.GetString("trCount:");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_barcode, MainWindow.resourcemanager.GetString("trBarcodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendor, MainWindow.resourcemanager.GetString("trVendorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            txt_items.Text = MainWindow.resourcemanager.GetString("trItems");
            txt_drafts.Text = MainWindow.resourcemanager.GetString("trDrafts");
            txt_newDraft.Text = MainWindow.resourcemanager.GetString("trNewDraft");
            txt_purchaseOrder.Text = MainWindow.resourcemanager.GetString("trPurchaseOrders");
            txt_emailMessage.Text = MainWindow.resourcemanager.GetString("trSendEmail");
            txt_preview.Text = MainWindow.resourcemanager.GetString("trPreview");
            txt_pdf.Text = MainWindow.resourcemanager.GetString("trPdfBtn");
            txt_printInvoice.Text = MainWindow.resourcemanager.GetString("trPrint");
            txt_invoiceImages.Text = MainWindow.resourcemanager.GetString("trImages");

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
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
                        clearInvoice();
                }
                else
                    clearInvoice();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        public async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
                 

                // for pagination
                MainWindow.mainWindow.KeyDown += HandleKeyPress;
                tb_moneyIcon.Text = MainWindow.Currency;
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
                //catigoriesAndItemsView.ucPayInvoice = this;
                refreshDraftNotification();
                await RefrishItems();
                await RefrishVendors();
                await fillBarcodeList();

                tb_barcode.Focus();
                #region datagridChange
                CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
                ((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
                #endregion
                
                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
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
            try
            {
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                    if (vis is DataGridRow)
                    {
                        BillDetails row = (BillDetails)dg_billDetails.SelectedItems[0];
                        int index = dg_billDetails.SelectedIndex;
                        // calculate new sum
                        _Count -= row.Count;
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
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        #endregion

        #region notification
        private async void refreshDraftNotification()
        {
            string invoiceType = "pod";
            int duration = 2;
            int draftCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);

            if (draftCount > 9)
            {
                draftCount = 9;
                md_draft.Badge = "+" + draftCount.ToString();
            }
            else
                md_draft.Badge = draftCount.ToString();
        }
        private async void refreshDocCount(int invoiceId)
        {
            DocImage doc = new DocImage();
            int docCount = await doc.GetDocCount("Invoices", invoiceId);
            
            if (docCount > 9)
            {
                docCount = 9;
                md_docImage.Badge = "+" + docCount.ToString();
            }
            else
                md_docImage.Badge = docCount.ToString();
        }
        #endregion
        private void Btn_updateVendor_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
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
                SectionData.StartAwait(grid_ucPayInvoice);
            vendors = await agentModel.GetAgentsActive("v");
            cb_vendor.ItemsSource = vendors;
            cb_vendor.DisplayMemberPath = "name";
            cb_vendor.SelectedValuePath = "agentId";
                SectionData.EndAwait(grid_ucPayInvoice, this);
        }
        async Task RefrishItems()
        {
                SectionData.StartAwait(grid_ucPayInvoice);
            items = await itemModel.GetAllItems();
                SectionData.EndAwait(grid_ucPayInvoice, this);
        }
        async Task fillBarcodeList()
        {
                SectionData.StartAwait(grid_ucPayInvoice);
            barcodesList = await itemUnitModel.getAllBarcodes();
                SectionData.EndAwait(grid_ucPayInvoice, this);
        }
        #endregion
        #region Get Id By Click  Y

        public async void ChangeCategoryIdEvent(int categoryId)
        {
            SectionData.StartAwait(grid_ucPayInvoice);

                SectionData.EndAwait(grid_ucPayInvoice, this);
        }
        public async Task ChangeItemIdEvent(int itemId)
        {
                SectionData.StartAwait(grid_ucPayInvoice);
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
                    int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == defaultPurUnit.itemUnitId).FirstOrDefault());
                    if (index == -1)//item doesn't exist in bill
                    {
                        // create new row in bill details data grid
                        await addRowToBill(item.name, itemId, defaultPurUnit.mainUnit, defaultPurUnit.itemUnitId, 1, 0, 0);
                    }
                    else // item exist prevoiusly in list
                    {
                        billDetails[index].Count++;
                        billDetails[index].Total = billDetails[index].Count * billDetails[index].Price;


                        _Count += billDetails[index].Count;
                        _Sum += billDetails[index].Price;
                    }
                    refreshTotalValue();
                    refrishBillDetails();
                }
                else
                {
                    await addRowToBill(item.name, itemId, null, 0, 1, 0, 0);
                    refrishBillDetails();
                }
            }
            tb_total.Text = _Count.ToString();
                SectionData.EndAwait(grid_ucPayInvoice, this);
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
                SectionData.ExceptionMessage(ex);
            }
        }
        private void space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }


        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                if (name == "TextBox")
                {
                }
                else if (name == "ComboBox")
                {
                    if ((sender as ComboBox).Name == "cb_vendor")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip");
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        #endregion
        #region save invoice

        private async Task addInvoice(string invType)
        {
                SectionData.StartAwait(grid_ucPayInvoice);
            if (invType == "po")
                invoice.invNumber = await invoice.generateInvNumber(invType);
            else
                invoice.invNumber = "";

            invoice.branchCreatorId = MainWindow.branchID.Value;
            invoice.posId = MainWindow.posID.Value;

            invoice.invType = invType;
            invoice.total = 0;
            invoice.totalNet = 0;

            if (cb_vendor.SelectedIndex != -1)
                invoice.agentId = (int)cb_vendor.SelectedValue;

            invoice.notes = tb_note.Text;
            invoice.taxtype = 2;
            invoice.createUserId = MainWindow.userID;
            invoice.updateUserId = MainWindow.userID;

            // save invoice in DB
            int invoiceId = int.Parse(await invoiceModel.saveInvoice(invoice));
            invoice.invoiceId = invoiceId;
            if (invoiceId != 0)
            {
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
                refreshDraftNotification();
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
            }
            else
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            clearInvoice();
                SectionData.EndAwait(grid_ucPayInvoice, this);
        }
        private bool validateInvoiceValues()
        {
            bool valid = true;
            SectionData.validateEmptyComboBox(cb_vendor, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip");
            if (billDetails.Count == 0)
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trAddInvoiceWithoutItems"), animation: ToasterAnimation.FadeIn);

            if (cb_vendor.SelectedIndex != -1 && billDetails.Count > 0)
                valid = true;
            else
                valid = false;
            if (valid)
                valid = validateItemUnits();
            return valid;
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
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (logInProcessing)
                    {
                        logInProcessing = false;
                        awaitSaveBtn(true);

                        //check mandatory inputs
                        bool valid = validateInvoiceValues();
                        if (valid)
                        {
                            await addInvoice("po"); // po means purchase order

                            clearInvoice();
                        }
                        awaitSaveBtn(false);
                        logInProcessing = true;
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
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
                SectionData.StartAwait(grid_ucPayInvoice);
                bool valid = validateItemUnits();
                if (billDetails.Count > 0 && valid)
                {
                    await addInvoice(_InvoiceType);
                }
                else if (billDetails.Count == 0)
                {
                    clearInvoice();
                }
                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        private void clearInvoice()
        {
            _Sum = 0;
            _Count = 0;
            txt_invNumber.Text = "";
            _SequenceNum = 0;
            _SelectedVendor = -1;
            _InvoiceType = "pod"; // purchase order draft
            invoice = new Invoice();
            tb_barcode.Clear();
            cb_vendor.SelectedIndex = -1;
            cb_vendor.SelectedItem = "";
            tb_note.Clear();
            billDetails.Clear();
            tb_total.Text = "";
            tb_sum.Text = null;
            btn_updateVendor.IsEnabled = false;
            md_docImage.Badge = "";
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseOrder");
            refrishBillDetails();
            inputEditable();

        }
        #endregion
        private async void Btn_draft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

                // purchase drafts and purchase bounce drafts
                w.invoiceType = "pod";
                w.userId = MainWindow.userLogin.userId;
                w.duration = 2; // view drafts which created during 2 last days 

                w.title = MainWindow.resourcemanager.GetString("trDrafts");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;
                        _InvoiceType = invoice.invType;

                        await fillInvoiceInputs(invoice);

                        mainInvoiceItems = invoiceItems;
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaceOrderDraft");
                        refreshDocCount(invoice.invoiceId);
                    }
                }
                Window.GetWindow(this).Opacity = 1;
                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        private async void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

                // purchase invoices
                w.invoiceType = "p , pw";
                w.userId = MainWindow.userLogin.userId;
                w.duration = 1; // view drafts which created during 1 last days 

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
                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        public async Task fillInvoiceInputs(Invoice invoice)
        {
                SectionData.StartAwait(grid_ucPayInvoice);

            txt_invNumber.Text = invoice.invNumber.ToString();
            cb_vendor.SelectedValue = invoice.agentId;
            tb_note.Text = invoice.notes;
            await buildInvoiceDetails();
            inputEditable();
                SectionData.EndAwait(grid_ucPayInvoice, this);
        }

        private async Task buildInvoiceDetails()
        {
                SectionData.StartAwait(grid_ucPayInvoice);

            //get invoice items
            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
            // build invoice details grid
            _SequenceNum = 0;
            billDetails.Clear();
            foreach (ItemTransfer itemT in invoiceItems)
            {
                _Count += (int)itemT.quantity;
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

            tb_count.Text = _Count.ToString();
            tb_barcode.Focus();

            refrishBillDetails();
                SectionData.EndAwait(grid_ucPayInvoice, this);
        }
        private void inputEditable()
        {
            if (_InvoiceType == "pod")
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                dg_billDetails.Columns[3].IsReadOnly = false; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                cb_vendor.IsEnabled = true;
                tb_note.IsEnabled = true;
                tb_barcode.IsEnabled = true;
                btn_save.IsEnabled = true;
            }
            else if (_InvoiceType == "po") // purchase order
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Collapsed; //make delete column unvisible
                dg_billDetails.Columns[3].IsReadOnly = true; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = true; //make count read only
                cb_vendor.IsEnabled = true;
                tb_note.IsEnabled = true;
                tb_barcode.IsEnabled = false;
                btn_save.IsEnabled = true;
            }
        }
        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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
                        refreshDocCount(invoice.invoiceId);
                        Window.GetWindow(this).Opacity = 1;
                    }
                    else
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trChooseInvoiceToolTip"), animation: ToasterAnimation.FadeIn);



                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }

        //private void Btn_pay_Click(object sender, RoutedEventArgs e)
        //{
        //    //  btn_vendor_Click(null, null);
        //}


        private void Cb_vendor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                cb_vendor.ItemsSource = vendors.Where(x => x.name.Contains(cb_vendor.Text));
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
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
                SectionData.ExceptionMessage(ex);
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
                SectionData.ExceptionMessage(ex);
            }
        }


        private void refreshTotalValue()
        {
            decimal total = _Sum;
            decimal taxValue = 0;
            decimal taxInputVal = 0;
            if (total != 0)
                taxValue = SectionData.calcPercentage(total, taxInputVal);

            tb_sum.Text = _Sum.ToString();
        }


        #region billdetails
        void refrishBillDetails()
        {
            dg_billDetails.ItemsSource = null;
            dg_billDetails.ItemsSource = billDetails;
            tb_total.Text = _Count.ToString();
            tb_sum.Text = _Sum.ToString();
        }


        // read item from barcode
        private async void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
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
                }
                _Sender = null;
                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        private async Task dealWithBarcode(string barcode)
        {
                SectionData.StartAwait(grid_ucPayInvoice);
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
                                    await addRowToBill(item.name, item.itemId, unit1.mainUnit, unit1.itemUnitId, count, price, total);
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
                SectionData.EndAwait(grid_ucPayInvoice, this);
        }
        private async void Tb_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
                if (e.Key == Key.Return)
                {
                    string barcode = "";
                    if (_BarcodeStr.Length < 13)
                    {
                        barcode = tb_barcode.Text;
                        await dealWithBarcode(barcode);
                    }

                }
                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }

        private async Task addRowToBill(string itemName, int itemId, string unitName, int itemUnitId, int count, decimal price, decimal total)
        {
                SectionData.StartAwait(grid_ucPayInvoice);
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
            _Count++;
            _Sum += total;
                SectionData.EndAwait(grid_ucPayInvoice, this);
        }
        #endregion billdetails

        private void Cbm_unitItemDetails_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                //billDetails
                if (billDetails.Count == 1)
                {
                    var cmb = sender as ComboBox;
                    cmb.SelectedValue = (int)billDetails[0].itemUnitId;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        private void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var cmb = sender as ComboBox;

                if (dg_billDetails.SelectedIndex != -1 && cmb != null)
                    billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
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
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }

        private void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
                var columnName = e.Column.Header.ToString();

                BillDetails row = e.Row.Item as BillDetails;
                int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == row.itemUnitId).FirstOrDefault());

                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds < 100)
                {
                    if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
                        t.Text = billDetails[index].Count.ToString();
                }
                else
                {
                    int oldCount = 0;
                    long newCount = 0;

                    //"tb_amont"
                    if (columnName == MainWindow.resourcemanager.GetString("trQuantity"))
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


                    _Count -= oldCount;
                    _Count += newCount;
                    tb_total.Text = _Count.ToString();

                    
                    // update item in billdetails           
                    billDetails[index].Count = (int)newCount;
                    
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }


        private void moveControlToBarcode(object sender, KeyEventArgs e)
        {
            try
            {
                DatePicker dt = sender as DatePicker;
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds < 100)
                {
                    tb_barcode.Focus();
                    HandleKeyPress(sender, e);
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }

        public async Task<string> SavePurOrderpdf()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();
            string pdfpath = "";

            //

            if (invoice.invoiceId > 0)
            {
                pdfpath = @"\Thumb\report\File.pdf";
                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                string reppath = reportclass.GetpayInvoiceRdlcpath(invoice);
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

                clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);
                paramarr = reportclass.fillPurInvReport(invoice, paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();

                LocalReportExtensions.ExportToPDF(rep, pdfpath);

            }

            return pdfpath;
        }
        //print
        private async void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
                || invoice.invType == "sbd" || invoice.invType == "pbd"
                || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
                    {
                        MessageBox.Show("can not print Draft Invoice");
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

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
        private async void btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {


                    if (invoice.invType == "pd" || invoice.invType == "sd" || invoice.invType == "qd"
                                 || invoice.invType == "sbd" || invoice.invType == "pbd"
                                 || invoice.invType == "ord" || invoice.invType == "imd" || invoice.invType == "exd")
                    {
                        MessageBox.Show(MainWindow.resourcemanager.GetString("trPrintDraftInvoice"));
                    }
                    else
                    {
                        ReportCls rr = new ReportCls();

                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string reppath = reportclass.GetpayInvoiceRdlcpath(invoice);
                        if (invoice.invoiceId > 0)
                        {
                            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                            Agent agentinv = new Agent();
                            agentinv = vendors.Where(X => X.agentId == invoice.agentId).FirstOrDefault();

                            User employ = new User();
                            employ = await employ.getUserById((int)invoice.updateUserId);
                            invoice.uuserName = employ.name;
                            invoice.uuserLast = employ.lastname;

                            invoice.agentCode = agentinv.code;
                            //new lines
                            invoice.agentName = agentinv.name;
                            invoice.agentCompany = agentinv.company;

                            invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
                            Branch branch = new Branch();
                            branch = await branchModel.getBranchById((int)invoice.branchCreatorId);
                            if (branch.branchId > 0)
                            {
                                invoice.branchName = branch.name;
                            }


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
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }


        private async void Btn_items_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
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
                        MainWindow.mainWindow.StartAwait();
                        int itemId = w.selectedItems[i];
                        await ChangeItemIdEvent(itemId);
                        MainWindow.mainWindow.EndAwait();
                    }
                }

                Window.GetWindow(this).Opacity = 1;
                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clearInvoice();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
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
                SectionData.ExceptionMessage(ex);
            }
        }

        private async void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
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
                            //delete file
                            /*
                            if (File.Exists(pdfpath))
                            { File.Delete(pdfpath);}
                            */
                            //  ClosePDF();
                            w.wb_pdfWebViewer.Dispose();


                        }
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: "", animation: ToasterAnimation.FadeIn);
                        Window.GetWindow(this).Opacity = 1;
                    }
                    else
                    {
                        MessageBox.Show(MainWindow.resourcemanager.GetString("trSaveInvoiceToPreview"));
                    }

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }

        private async void Btn_emailMessage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_ucPayInvoice);
                if (MainWindow.groupObject.HasPermissionAction(sendEmailPermission, MainWindow.groupObjects, "one"))
                {
                    SysEmails email = new SysEmails();
                    EmailClass mailtosend = new EmailClass();
                    email = await email.GetByBranchIdandSide((int)MainWindow.branchID, "mg");
                    Agent toAgent = new Agent();
                    toAgent = vendors.Where(x => x.agentId == invoice.agentId).FirstOrDefault();
                    //  int? itemcount = invoiceItems.Count();
                    if (email.emailId == 0)
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoEmailForThisDept"), animation: ToasterAnimation.FadeIn);
                    else
                    {
                        if (invoice.invoiceId == 0)
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

                                    string pdfpath = await SavePurOrderpdf();
                                    mailtosend.AddAttachTolist(pdfpath);
                                    List<SetValues> setvlist = new List<SetValues>();
                                    setvlist = await setvmodel.GetBySetName("pur_order_email_temp");

                                    mailtosend = mailtosend.fillOrderTempData(invoice, invoiceItems, email, toAgent, setvlist);

                                    string msg = mailtosend.Sendmail();
                                    if (msg == "Failure sending mail.")
                                    {
                                        // msg = "No Internet connection";
                                        //  MessageBox.Show("");
                                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoInternetConnection"), animation: ToasterAnimation.FadeIn);
                                    }
                                    else if (msg == "mailsent")
                                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailSent"), animation: ToasterAnimation.FadeIn);
                                    else
                                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailNotSent"), animation: ToasterAnimation.FadeIn);


                                }
                            }
                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                SectionData.EndAwait(grid_ucPayInvoice, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex);
            }
        }
    }
}

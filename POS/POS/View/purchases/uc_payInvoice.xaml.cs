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
using System.Windows.Resources;


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
        string printCountPermission = "payInvoice_printCount";

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
                SectionData.ExceptionMessage(ex, this);
            }
        }
        ObservableCollection<BillDetails> billDetails = new ObservableCollection<BillDetails>();
        public List<Control> controls;

        public static bool isFromReport = false;
        public static bool archived = false;

        Item itemModel = new Item();
        Item item = new Item();
        IEnumerable<Item> items;
        ItemLocation itemLocationModel = new ItemLocation();

        Branch branchModel = new Branch();

        Agent agentModel = new Agent();
        //List<Agent> vendors;
        List<Agent> vendorsL;

        ItemUnit itemUnitModel = new ItemUnit();
        List<ItemUnit> barcodesList;
        List<ItemUnit> itemUnits;

        Invoice invoiceModel = new Invoice();
        public Invoice invoice = new Invoice();
        List<Invoice> invoices;
        List<ItemTransfer> invoiceItems;
        List<ItemTransfer> mainInvoiceItems;
        Pos pos = new Pos();
        Card cardModel = new Card();
        IEnumerable<Card> cards;
        CashTransfer cashTransfer = new CashTransfer();
        #region //to handle barcode characters
        static private int _SelectedBranch = -1;
        static private int _SelectedVendor = -1;
        static private int _SelectedDiscountType = -1;
        static private string _SelectedPaymentType = "cash";
        static private int _SelectedCard = -1;
        // for barcode
        DateTime _lastKeystroke = new DateTime(0);
        static private string _BarcodeStr = "";
        static private object _Sender;
        bool _IsFocused = false;
        #endregion
        #region for notifications
        private static DispatcherTimer timer;
        int _DraftCount = 0;
        int _InvCount = 0;
        int _DocCount = 0;
        int _OrderCount = 0;
        int _PaymentCount = 0;

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
        static public bool _isLack = false; // for lack invoice

        // for report
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        int prInvoiceId;
        Invoice prInvoice = new Invoice();
        List<PayedInvclass> mailpayedList = new List<PayedInvclass>();
        //bool isClose = false;

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
            dg_billDetails.Columns[1].Header = MainWindow.resourcemanager.GetString("trNo.");
            dg_billDetails.Columns[2].Header = MainWindow.resourcemanager.GetString("trItem");
            dg_billDetails.Columns[3].Header = MainWindow.resourcemanager.GetString("trUnit");
            dg_billDetails.Columns[4].Header = MainWindow.resourcemanager.GetString("trQTR");
            dg_billDetails.Columns[5].Header = MainWindow.resourcemanager.GetString("trPrice");
            dg_billDetails.Columns[6].Header = MainWindow.resourcemanager.GetString("trTotal");

            txt_discount.Text = MainWindow.resourcemanager.GetString("trDiscount");
            txt_sum.Text = MainWindow.resourcemanager.GetString("trSum");
            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal");
            txt_tax.Text = MainWindow.resourcemanager.GetString("trTax");
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
            txt_store.Text = MainWindow.resourcemanager.GetString("trStore/Branch");
            txt_vendor.Text = MainWindow.resourcemanager.GetString("trVendor");
            txt_vendorIvoiceDetails.Text = MainWindow.resourcemanager.GetString("trVendorDetails");

            txt_shortageInvoice.Text = MainWindow.resourcemanager.GetString("trLack");
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
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_vendor, MainWindow.resourcemanager.GetString("trVendorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_desrvedDate, MainWindow.resourcemanager.GetString("trDeservedDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_invoiceNumber, MainWindow.resourcemanager.GetString("trInvoiceNumberHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_invoiceDate, MainWindow.resourcemanager.GetString("trInvoiceDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            tt_error_previous.Content = MainWindow.resourcemanager.GetString("trPrevious");
            tt_error_next.Content = MainWindow.resourcemanager.GetString("trNext");

            btn_save.Content = MainWindow.resourcemanager.GetString("trBuy");
        }
        async private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                MainWindow.mainWindow.KeyDown -= HandleKeyPress;
                saveBeforeExit();
                timer.Stop();
                GC.Collect();
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
        private async Task saveBeforeExit()
        {
            if (billDetails.Count > 0 && (_InvoiceType == "pd" || _InvoiceType == "pbd") && _isLack == false)
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
                {
                    await addInvoice(_InvoiceType, "pi");
                    clearInvoice();
                    _InvoiceType = "pd";
                }
            }
            clearInvoice();

        }
        private async Task saveBeforeTransfer()
        {
            if (billDetails.Count > 0 && _InvoiceType == "pd" && _isLack == false)
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
                {
                    await addInvoice(_InvoiceType, "pi");
                    clearInvoice();
                    _InvoiceType = "pd";
                    setNotifications();
                }
            }
            else
                clearInvoice();

        }
        #region loading

        List<keyValueBool> loadingList;


        async void loading_RefrishItems()
        {
            try
            {
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
        async void loading_fillBranchesWithoutCurrent()
        {
            try
            {
                await SectionData.fillBranchesWithoutCurrent(cb_branch, MainWindow.branchID.Value, "bs");

            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_fillBranchesWithoutCurrent"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        async void loading_refrishVendors()
        {
            try
            {
                await RefrishVendors();

            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_refrishVendors"))
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


        #endregion
        public async void UserControl_Loaded(object sender, RoutedEventArgs e)
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
                //exp_payment.IsExpanded = true;

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
                //List all the UIElement in the VisualTree
                controls = new List<Control>();

                #region loading
                loadingList = new List<keyValueBool>();
                bool isDone = true;
                loadingList.Add(new keyValueBool { key = "loading_RefrishItems", value = false });
                loadingList.Add(new keyValueBool { key = "loading_fillBranchesWithoutCurrent", value = false });
                loadingList.Add(new keyValueBool { key = "loading_refrishVendors", value = false });
                loadingList.Add(new keyValueBool { key = "loading_fillBarcodeList", value = false });


                pos = MainWindow.posLogIn;
                loading_RefrishItems();
                loading_fillBranchesWithoutCurrent();
                loading_refrishVendors();
                loading_fillBarcodeList();
                loading_fillCardCombo();
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
                        await Task.Delay(0500);
                    }
                }
                while (!isDone);
                #endregion

                if (MainWindow.invoiceTax_bool == false)
                    sp_tax.Visibility = Visibility.Collapsed;
                else
                {
                    sp_tax.Visibility = Visibility.Visible;
                    tb_taxValue.Text = SectionData.PercentageDecTostring(MainWindow.invoiceTax_decimal);
                }
                setTimer();
                configureDiscountType();
                configurProcessType();
                setNotifications();
                #region Style Date
                SectionData.defaultDatePickerStyle(dp_desrvedDate);
                SectionData.defaultDatePickerStyle(dp_invoiceDate);
                #endregion

                #region datagridChange
                //CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(dg_billDetails.Items);
                //((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
                #endregion
                //Walk through the VisualTree
                FindControl(this.grid_main, controls);

                #region Permision

                if (MainWindow.groupObject.HasPermissionAction(openOrderPermission, MainWindow.groupObjects, "one"))
                    md_orders.Visibility = Visibility.Visible;
                else
                    md_orders.Visibility = Visibility.Collapsed;

                if (MainWindow.groupObject.HasPermissionAction(returnPermission, MainWindow.groupObjects, "one"))
                {
                    brd_returnInvoice.Visibility = Visibility.Visible;
                }
                else
                {
                    brd_returnInvoice.Visibility = Visibility.Collapsed;
                }

                //if (MainWindow.groupObject.HasPermissionAction(paymentsPermission, MainWindow.groupObjects, "one"))
                //{
                //    md_payments.Visibility = Visibility.Visible;
                //    bdr_payments.Visibility = Visibility.Visible;
                //}
                //else
                //{
                //    md_payments.Visibility = Visibility.Collapsed;
                //    bdr_payments.Visibility = Visibility.Collapsed;
                //}

                //if (MainWindow.groupObject.HasPermissionAction(sendEmailPermission, MainWindow.groupObjects, "one"))
                //{
                //    btn_emailMessage.Visibility = Visibility.Visible;
                //    bdr_emailMessage.Visibility = Visibility.Visible;
                //}
                //else
                //{
                //    btn_emailMessage.Visibility = Visibility.Collapsed;
                //    bdr_emailMessage.Visibility = Visibility.Collapsed;
                //}


                if (MainWindow.groupObject.HasPermissionAction(initializeShortagePermission, MainWindow.groupObjects, "one"))
                {
                    btn_shortageInvoice.Visibility = Visibility.Visible;
                    bdr_shortageInvoice.Visibility = Visibility.Visible;
                    md_shortage.Visibility = Visibility.Visible;
                }
                else
                {
                    btn_shortageInvoice.Visibility = Visibility.Collapsed;
                    bdr_shortageInvoice.Visibility = Visibility.Collapsed;
                    md_shortage.Visibility = Visibility.Collapsed;
                }

                //if (MainWindow.groupObject.HasPermissionAction(printCountPermission, MainWindow.groupObjects, "one"))
                //{
                //    btn_printCount.Visibility = Visibility.Visible;
                //    bdr_printCount.Visibility = Visibility.Visible;
                //}
                //else
                //{
                //    btn_printCount.Visibility = Visibility.Collapsed;
                //    bdr_printCount.Visibility = Visibility.Collapsed;
                //}

                #endregion
                #region print - pdf - send email
                btn_printInvoice.Visibility = Visibility.Collapsed;
                btn_pdf.Visibility = Visibility.Collapsed;
                btn_printCount.Visibility = Visibility.Collapsed;
                btn_emailMessage.Visibility = Visibility.Collapsed;
                bdr_emailMessage.Visibility = Visibility.Collapsed;
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
        private void configurProcessType()
        {
            cb_paymentProcessType.DisplayMemberPath = "Text";
            cb_paymentProcessType.SelectedValuePath = "Value";

            var typelist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
            new { Text = MainWindow.resourcemanager.GetString("trCredit") , Value = "balance" },
            new { Text = MainWindow.resourcemanager.GetString("trAnotherPaymentMethods") , Value = "card" },
            new { Text = MainWindow.resourcemanager.GetString("trMultiplePayment") , Value = "multiple" },
                };

            cb_paymentProcessType.ItemsSource = typelist;
            cb_paymentProcessType.SelectedIndex = 0;
        }
        async void loading_fillCardCombo()
        {
            try
            {
                #region fill card combo
                cards = await cardModel.GetAll();
                InitializeCardsPic(cards);
                #endregion

            }
            catch (Exception)
            { }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_fillCardCombo"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        List<Button> cardBtnList = new List<Button>();
        List<Ellipse> cardEllipseList = new List<Ellipse>();
        bool hasProcessNum = false;

        void InitializeCardsPic(IEnumerable<Card> cards)
        {
            #region cardImageLoad
            dkp_cards.Children.Clear();
            int userCount = 0;
            foreach (var item in cards)
            {
                #region Button
                Button button = new Button();
                //button.DataContext = item.name;
                button.DataContext = item;
                button.Tag = item.cardId;
                button.Padding = new Thickness(0, 0, 0, 0);
                button.Margin = new Thickness(2.5, 5, 2.5, 5);
                button.Background = null;
                button.BorderBrush = null;
                button.Height = 35;
                button.Width = 35;
                button.Click += card_Click;
                //Grid.SetColumn(button, 4);
                #region grid
                Grid grid = new Grid();
                #region 
                Ellipse ellipse = new Ellipse();
                //ellipse.Margin = new Thickness(-5, 0, -5, 0);
                ellipse.StrokeThickness = 1;
                ellipse.Stroke = Application.Current.Resources["MainColorOrange"] as SolidColorBrush;
                ellipse.Height = 35;
                ellipse.Width = 35;
                ellipse.FlowDirection = FlowDirection.LeftToRight;
                ellipse.ToolTip = item.name;
                ellipse.Tag = item.cardId;
                userImageLoad(ellipse, item.image);
                Grid.SetColumn(ellipse, userCount);
                grid.Children.Add(ellipse);
                cardEllipseList.Add(ellipse);
                #endregion
                #endregion
                button.Content = grid;
                #endregion
                dkp_cards.Children.Add(button);
                cardBtnList.Add(button);

            }
            #endregion
        }
        ImageBrush brush = new ImageBrush();
        async void userImageLoad(Ellipse ellipse, string image)
        {
            try
            {
                if (!string.IsNullOrEmpty(image))
                {
                    clearImg(ellipse);

                    byte[] imageBuffer = await cardModel.downloadImage(image); // read this as BLOB from your DB
                    var bitmapImage = new BitmapImage();
                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    ellipse.Fill = new ImageBrush(bitmapImage);
                }
                else
                {
                    clearImg(ellipse);
                }
            }
            catch
            {
                clearImg(ellipse);
            }
        }
        void card_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _SelectedCard = int.Parse(button.Tag.ToString());
            //txt_card.Text = button.DataContext.ToString();
            Card card = button.DataContext as Card;
            txt_card.Text = card.name;
            if (card.hasProcessNum.Value)
            {
                tb_processNum.Visibility = Visibility.Visible;
                hasProcessNum = true;
            }
            else
            {
                tb_processNum.Visibility = Visibility.Collapsed;
                hasProcessNum = false;
            }
            //set border color
            foreach (var el in cardEllipseList)
            {
                if ((int)el.Tag == (int)button.Tag)
                    el.Stroke = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                else
                    el.Stroke = Application.Current.Resources["MainColorOrange"] as SolidColorBrush;
            }
        }
        private void clearImg(Ellipse ellipse)
        {
            Uri resourceUri = new Uri("pic/no-image-icon-90x90.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            ellipse.Fill = brush;
        }
        private void ParentWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //isClose = true;
            //UserControl_Unloaded(this, null);
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
            public string invType { get; set; }
        }

        #endregion

        #region Button In DataGrid
        void deleteRowFromInvoiceItems(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (sender != null)
                //SectionData.StartAwait(grid_main);

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
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
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
                refreshInvNotification();
                refreshLackNotification();
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
        private void setNotifications()
        {
            try
            {
                refreshDraftNotification();
                refreshInvNotification();
                refreshOrdersNotification();
                refreshLackNotification();
            }
            catch { }

        }
        private async Task refreshDraftNotification()
        {
            try
            {
                string invoiceType = "pd ,pbd";
                int duration = 2;
                int draftCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);
                if (invoice != null && (invoice.invType == "pd" || invoice.invType == "pbd") && invoice.invoiceId != 0 && !isFromReport)
                    draftCount--;

                if (draftCount != _DraftCount)
                {
                    if (draftCount > 9)
                        md_draft.Badge = "+9";
                    else if (draftCount == 0) md_draft.Badge = "";
                    else
                        md_draft.Badge = draftCount.ToString();
                }
                _DraftCount = draftCount;
            }
            catch { }
        }
        private async Task refreshInvNotification()
        {
            try
            {
                string invoiceType = "p ,pw ,pb ,pbw";
                int duration = 1;
                int invCount = await invoice.GetCountByCreator(invoiceType, MainWindow.userID.Value, duration);
                if (invoice != null && (invoice.invType == "p" || invoice.invType == "pb" || invoice.invType == "pbw" || invoice.invType == "pw") && !isFromReport)
                    invCount--;

                if (invCount != _InvCount)
                {
                    if (invCount > 9)
                    {
                        md_invoices.Badge = "+9";
                    }
                    else if (invCount == 0) md_invoices.Badge = "";
                    else
                        md_invoices.Badge = invCount.ToString();
                }
                _InvCount = invCount;
            }
            catch { }
        }
        private async Task refreshOrdersNotification()
        {
            try
            {
                string invoiceType = "po";
                int ordersCount = await invoice.GetCountUnHandeledOrders(invoiceType, 0, 0);
                if (invoice != null && _InvoiceType == "po" && invoice != null && invoice.invoiceId != 0)
                    ordersCount--;

                if (ordersCount != _OrderCount)
                {
                    if (ordersCount > 9)
                    {
                        md_orders.Badge = "+9";
                    }
                    else if (ordersCount == 0) md_orders.Badge = "";
                    else
                        md_orders.Badge = ordersCount.ToString();
                }
                _OrderCount = ordersCount;
            }
            catch { }
        }
        private async Task refreshLackNotification()
        {
            try
            {
                string isThereLack = await invoice.isThereLack(MainWindow.branchID.Value);
                if (isThereLack == "yes")
                    md_shortage.Badge = "!";
                else
                    md_shortage.Badge = "";
            }
            catch { }
        }
        private async void refreshDocCount(int invoiceId)
        {
            try
            {
                DocImage doc = new DocImage();
                int docCount = await doc.GetDocCount("Invoices", invoiceId);

                if (docCount != _DocCount)
                {
                    if (docCount > 9)
                        md_docImage.Badge = "+9";
                    else if (docCount == 0) md_docImage.Badge = "";

                    else
                        md_docImage.Badge = docCount.ToString();
                }
                _DocCount = docCount;
            }
            catch { }
        }
        private async void refreshPaymentsNotification(int invoiceId)
        {
            try
            {
                int paymentsCount = await cashTransfer.GetCashCount(invoice.invoiceId);
                if (paymentsCount == 0)
                {
                    bdr_payments.Visibility = Visibility.Collapsed;
                    md_payments.Visibility = Visibility.Collapsed;
                }
                else if (MainWindow.groupObject.HasPermissionAction(paymentsPermission, MainWindow.groupObjects, "one"))
                {
                    bdr_payments.Visibility = Visibility.Visible;
                    md_payments.Visibility = Visibility.Visible;
                    if (paymentsCount != _PaymentCount)
                    {
                        if (paymentsCount > 9)
                            md_payments.Badge = "+9";
                        else if (paymentsCount == 0) md_payments.Badge = "";

                        else
                            md_payments.Badge = paymentsCount.ToString();
                    }
                    _PaymentCount = paymentsCount;
                }
            }
            catch { }
        }
        #endregion

        private async void Btn_addVendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                Window.GetWindow(this).Opacity = 0.2;
                wd_updateVendor w = new wd_updateVendor();
                //// pass agent id to update windows
                w.agent.agentId = 0;
                w.type = "v";
                w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;
                if (w.isOk == true)
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                    await RefrishVendors();
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
        private async void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 100 && cb_paymentProcessType.SelectedIndex != -1)
                {
                    _SelectedPaymentType = cb_paymentProcessType.SelectedValue.ToString();
                }
                else
                {
                    cb_paymentProcessType.SelectedValue = _SelectedPaymentType;
                }

                switch (cb_paymentProcessType.SelectedIndex)
                {
                    case 0://cash
                        //gd_theRest.Visibility = Visibility.Visible;
                        //tb_cashPaid.Text = txt_theRest.Text = "0";
                        gd_card.Visibility = Visibility.Collapsed;
                        tb_processNum.Clear();
                        //cb_card.SelectedIndex = -1;
                        _SelectedCard = -1;
                        txt_card.Text = "";
                        dp_desrvedDate.IsEnabled = false;
                        // SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        //SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        //SectionData.clearValidate(tb_processNum, p_errorCard);
                        break;
                    case 1:// balance
                        //gd_theRest.Visibility = Visibility.Collapsed;
                        //tb_cashPaid.Text = txt_theRest.Text = "0";
                        gd_card.Visibility = Visibility.Collapsed;
                        dp_desrvedDate.IsEnabled = true;
                        tb_processNum.Clear();
                        //cb_card.SelectedIndex = -1;
                        _SelectedCard = -1;
                        //txt_card.Text = "";
                        //SectionData.clearComboBoxValidate(cb_card, p_errorCard);
                        //SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        //SectionData.clearValidate(tb_processNum, p_errorCard);
                        break;
                    case 2://card
                        //gd_theRest.Visibility = Visibility.Collapsed;
                        //tb_cashPaid.Text = txt_theRest.Text = "0";
                        dp_desrvedDate.IsEnabled = false;
                        gd_card.Visibility = Visibility.Visible;
                        // SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        txt_card.Text = "";
                        tb_processNum.Clear();
                        tb_processNum.Visibility = Visibility.Collapsed;
                        foreach (var el in cardEllipseList)
                        {
                            el.Stroke = Application.Current.Resources["MainColorOrange"] as SolidColorBrush;
                        }
                        CashTransfer cashTrasnfer = new CashTransfer();// cach transfer model
                        if (invoice.invoiceId != 0 && invoice.invType == "p")//get payment information          
                        {
                            cashTrasnfer = await cashTrasnfer.GetByInvId(invoice.invoiceId);
                        }
                        if (cashTrasnfer.cardId != null)
                        {
                            Button btn = cardBtnList.Where(c => (int)c.Tag == cashTrasnfer.cardId.Value).FirstOrDefault();
                            card_Click(btn, null);
                        }
                        break;
                    case 3://multiple
                        //gd_theRest.Visibility = Visibility.Collapsed;
                        //tb_cashPaid.Text = txt_theRest.Text = "0";
                        gd_card.Visibility = Visibility.Collapsed;
                        tb_processNum.Clear();
                        _SelectedCard = -1;
                        txt_card.Text = "";
                        dp_desrvedDate.IsEnabled = true;
                        //SectionData.clearComboBoxValidate(cb_customer, p_errorCustomer);
                        //SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        //SectionData.clearValidate(tb_processNum, p_errorCard);
                        break;

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
        private void PreventSpaces(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_updateVendor_Click(object sender, RoutedEventArgs e)
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
                    if (w.isOk == true)
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                        await RefrishVendors();
                    }


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
            vendorsL = await agentModel.GetAgentsActive("v");
            var agent = new Agent();
            agent.agentId = 0;
            agent.name = "-";
            vendorsL.Insert(0, agent);
            // vendors.ToList().AddRange(vendorsL.ToArray());
            cb_vendor.ItemsSource = vendorsL;
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

        public void ChangeCategoryIdEvent(int categoryId)
        {
        }


        public async Task ChangeItemIdEvent(int itemId)
        {
            item = items.ToList().Find(c => c.itemId == itemId);

            if (item != null)
            {
                // get item units
                //itemUnits = await itemUnitModel.GetItemUnits(item.itemId);
                itemUnits = MainWindow.InvoiceGlobalItemUnitsList.Where(a => a.itemId == item.itemId).ToList();
                // search for default unit for purchase
                var defaultPurUnit = itemUnits.ToList().Find(c => c.defaultPurchase == 1);
                if (defaultPurUnit != null)
                {
                    int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == defaultPurUnit.itemUnitId).FirstOrDefault());
                    if (index == -1)//item doesn't exist in bill
                    {
                        // create new row in bill details data grid
                        decimal price = (decimal)defaultPurUnit.cost; //?????
                        decimal total = price;
                        addRowToBill(item.name, itemId, defaultPurUnit.mainUnit, defaultPurUnit.itemUnitId, 1, price, total);
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
                    else if ((sender as TextBox).Name == "tb_processNum")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorProcessNum, tt_errorProcessNum, "trEmptyProcessNumToolTip");
                }
                else if (name == "ComboBox")
                {
                    if ((sender as ComboBox).Name == "cb_branch")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
                    //if ((sender as ComboBox).Name == "cb_vendor")
                    //    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip");
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
                invoice.invNumber = await invoice.generateInvNumber("pb", MainWindow.loginBranch.code, MainWindow.branchID.Value);
                invoice.branchCreatorId = MainWindow.branchID.Value;
                invoice.posId = MainWindow.posID.Value;
            }
            else if (invoice.invType == "po")
            {
                invoice.invNumber = await invoice.generateInvNumber("pi", MainWindow.loginBranch.code, MainWindow.branchID.Value);
            }
            else if (invType == "pd" && invoice.invoiceId == 0)
                invoice.invNumber = await invoice.generateInvNumber("pd", MainWindow.loginBranch.code, MainWindow.branchID.Value);

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
                //invoice.cashReturn = 0;
                if (cb_vendor.SelectedIndex != -1 && cb_vendor.SelectedIndex != 0)
                    invoice.agentId = (int)cb_vendor.SelectedValue;

                if (cb_branch.SelectedIndex != -1 && cb_branch.SelectedIndex != 0)
                    invoice.branchId = (int)cb_branch.SelectedValue;
                else
                    invoice.branchId = MainWindow.branchID.Value;

                invoice.deservedDate = dp_desrvedDate.SelectedDate;
                invoice.vendorInvNum = tb_invoiceNumber.Text;
                invoice.vendorInvDate = dp_invoiceDate.SelectedDate;
                invoice.notes = tb_note.Text;
                invoice.taxtype = 2;
                if (tb_taxValue.Text != "" && MainWindow.invoiceTax_bool == true)
                    invoice.tax = decimal.Parse(tb_taxValue.Text);
                else
                    invoice.tax = 0;

                invoice.createUserId = MainWindow.userID;
                invoice.updateUserId = MainWindow.userID;
                if (invType == "pw" || invType == "p")
                    invoice.invNumber = await invoice.generateInvNumber("pi", MainWindow.loginBranch.code, MainWindow.branchID.Value);

                // save invoice in DB
                int invoiceId = await invoiceModel.saveInvoice(invoice);
                prInvoiceId = invoiceId;
                invoice.invoiceId = invoiceId;
                if (invoiceId != 0)
                {
                    //if (invType == "pw" || invType =="p")
                    //{
                    //    await invoice.recordPosCashTransfer(invoice, "pi");
                    //    if(invoice.agentId != null)
                    //        await invoice.recordCashTransfer(invoice, "pi");
                    //}
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
                        itemT.invoiceId = 0;

                        invoiceItems.Add(itemT);
                    }
                    int s = await invoiceModel.saveInvoiceItems(invoiceItems, invoiceId);

                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    if (invType == "p")
                        invoiceModel.saveAvgPurchasePrice(invoiceItems);
                }
                else
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            }

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
        private bool validateInvoiceValues()
        {
            //bool isValid = true;
            //SectionData.validateEmptyComboBox(cb_branch, p_errorBranch, tt_errorBranch, "trEmptyBranchToolTip");
            //if (!SectionData.validateEmptyComboBox(cb_vendor, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip"))
            //    exp_vendor.IsExpanded = true;
            if (decimal.Parse(tb_total.Text) == 0)
            {
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorTotalIsZeroToolTip"), animation: ToasterAnimation.FadeIn);
                return false;
            }
            if (cb_paymentProcessType.SelectedValue.ToString() == "cash" && (MainWindow.posLogIn.balance < decimal.Parse(tb_total.Text) || MainWindow.posLogIn.balance == null))
            {
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopNotEnoughBalance"), animation: ToasterAnimation.FadeIn);
                return false;
            }
            else if (cb_paymentProcessType.SelectedValue.ToString() == "balance")
            {
                if (!SectionData.validateEmptyComboBox(cb_vendor, p_errorVendor, tt_errorVendor, "trErrorEmptyVendorToolTip"))
                    exp_vendor.IsExpanded = true;
                if (cb_vendor.SelectedIndex < 1)
                    return false;
            }
            else if (cb_paymentProcessType.SelectedValue.ToString() == "card")
            {
                if (_SelectedCard == -1)
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trSelectCreditCard"), animation: ToasterAnimation.FadeIn);
                    return false;
                }
                else
                {
                    var card = cards.Where(x => x.cardId == _SelectedCard).FirstOrDefault();
                    if (card.hasProcessNum.Value && tb_processNum.Text.Equals(""))
                    {
                        SectionData.validateEmptyTextBox(tb_processNum, p_errorProcessNum, tt_errorProcessNum, "trEmptyProcessNumToolTip");
                        return false;
                    }
                }
            }
            //if (cb_vendor.SelectedIndex > 0)
            //{
            //    if (!SectionData.validateEmptyTextBox(tb_invoiceNumber, p_errorInvoiceNumber, tt_errorInvoiceNumber, "trErrorEmptyInvNumToolTip"))
            //        exp_vendor.IsExpanded = true;
            //    if (tb_invoiceNumber.Text.Equals(""))
            //        return false;
            //}
            if (cb_vendor.SelectedIndex > 0 && cb_paymentProcessType.SelectedValue.ToString() != "cash" && cb_paymentProcessType.SelectedValue.ToString() != "card")
            {
                if (!SectionData.validateEmptyDatePicker(dp_desrvedDate, p_errorDesrvedDate, tt_errorDesrvedDate, "trErrorEmptyDeservedDate"))
                    exp_vendor.IsExpanded = true;
                if (!SectionData.validateEmptyTextBox(tb_invoiceNumber, p_errorInvoiceNumber, tt_errorInvoiceNumber, "trErrorEmptyInvNumToolTip"))
                    exp_vendor.IsExpanded = true;
                if (dp_desrvedDate.Text.Equals("") || tb_invoiceNumber.Text.Equals(""))
                    return false;
            }

            return true;
        }

        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(invoicePermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (MainWindow.posLogIn.boxState == "o") // box is open
                    {
                        //check mandatory inputs
                        bool validate = validateInvoiceValues();
                        bool valid = validateItemUnits();
                        TextBox tb = (TextBox)dp_desrvedDate.Template.FindName("PART_TextBox", dp_desrvedDate);

                        if (valid && validate)
                        {
                            bool multipleValid = true;
                            List<CashTransfer> listPayments = new List<CashTransfer>();

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
                                await not.save(not, (int)invoice.branchCreatorId, "storageAlerts_ctreatePurchaseReturnInvoice", MainWindow.loginBranch.name);
                                #endregion
                                await addInvoice("pbw", "pb"); // pbw means waiting purchase bounce
                                clearInvoice();
                                _InvoiceType = "pd";
                            }

                            else//pw  waiting purchase invoice
                            {
                                if (cb_paymentProcessType.SelectedValue.ToString() == "multiple")
                                {
                                    Window.GetWindow(this).Opacity = 0.2;
                                    wd_multiplePayment w = new wd_multiplePayment();
                                    if (cb_vendor.SelectedIndex > 0)
                                        w.hasCredit = true;
                                    else
                                        w.hasCredit = false;
                                    w.isPurchase = true;
                                    w.invoice.invType = _InvoiceType;
                                    w.invoice.totalNet = decimal.Parse(tb_total.Text);
                                    w.cards = cards;
                                    w.ShowDialog();
                                    Window.GetWindow(this).Opacity = 1;
                                    multipleValid = w.isOk;
                                    listPayments = w.listPayments;
                                }
                                if (multipleValid)
                                {
                                    if (cb_paymentProcessType.SelectedValue.ToString() == "cash" && (MainWindow.posLogIn.balance < invoice.totalNet || MainWindow.posLogIn.balance == null))
                                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopNotEnoughBalance"), animation: ToasterAnimation.FadeIn);

                                    else
                                    {
                                        if (cb_branch.SelectedIndex == -1 || cb_branch.SelectedIndex == 0) // reciept invoice directly
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
                                            refreshLackNotification();
                                        }
                                        else
                                        {
                                            await addInvoice("pw", "pi");
                                            #region notification Object
                                            if ((int)cb_branch.SelectedIndex != -1 && (int)cb_branch.SelectedIndex != 0)
                                            {
                                                Notification not = new Notification()
                                                {
                                                    title = "trPurchaseInvoiceAlertTilte",
                                                    ncontent = "trPurchaseInvoiceAlertContent",
                                                    msgType = "alert",
                                                    createUserId = MainWindow.userID.Value,
                                                    updateUserId = MainWindow.userID.Value,
                                                };
                                                await not.save(not, (int)cb_branch.SelectedValue, "storageAlerts_ctreatePurchaseInvoice", MainWindow.loginBranch.name);
                                            }
                                            #endregion
                                        }
                                        refreshDraftNotification();
                                        refreshInvNotification();
                                        ///// cash Transfer
                                        #region
                                        await invoice.recordPosCashTransfer(invoice, "pi");
                                        if (cb_paymentProcessType.SelectedValue.ToString() == "multiple")
                                        {
                                            foreach (var item in listPayments)
                                            {
                                                item.transType = "p"; //pull
                                                item.posId = MainWindow.posID;
                                                item.agentId = invoice.agentId;
                                                item.invId = invoice.invoiceId;
                                                item.transNum = await cashTransfer.generateCashNumber("pv");
                                                item.side = "v"; // vendor
                                                item.createUserId = MainWindow.userID;
                                                await saveConfiguredCashTrans(item);
                                            }
                                        }
                                        else
                                        {
                                            CashTransfer cashTrasnfer = new CashTransfer();
                                            cashTrasnfer.transType = "p"; //pull
                                            cashTrasnfer.posId = MainWindow.posID;
                                            cashTrasnfer.agentId = invoice.agentId;
                                            cashTrasnfer.invId = invoice.invoiceId;
                                            cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("pv");
                                            cashTrasnfer.cash = invoice.totalNet;
                                            cashTrasnfer.side = "v"; // vendor
                                            cashTrasnfer.processType = cb_paymentProcessType.SelectedValue.ToString();
                                            cashTrasnfer.createUserId = MainWindow.userID;
                                            await saveCashTransfer(cashTrasnfer);
                                        }


                                        //if (invoice.agentId != null)
                                        //    await invoice.recordCashTransfer(invoice, "pi");
                                        #endregion
                                        /////

                                        clearInvoice();
                                        _InvoiceType = "pd";

                                    }
                                }

                            }
                            refreshDraftNotification();
                            refreshInvNotification();

                            prInvoice = await invoiceModel.GetByInvoiceId(prInvoiceId);
                            ///////////////////////////////////////

                            if (prInvoice.invType == "pw" || prInvoice.invType == "p")
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
                        await MainWindow.refreshBalance();
                    }
                    else //box is closed
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trBoxIsClosed"), animation: ToasterAnimation.FadeIn);
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
        private async Task saveConfiguredCashTrans(CashTransfer cashTransfer)
        {
            switch (cashTransfer.processType)
            {
                case "cash":// cash: update pos balance  
                    pos = MainWindow.posLogIn;
                    if (MainWindow.posLogIn.balance > 0)
                    {
                        if (MainWindow.posLogIn.balance >= cashTransfer.cash)
                        {
                            MainWindow.posLogIn.balance -= cashTransfer.cash;
                            invoice.paid = cashTransfer.cash;
                            invoice.deserved -= cashTransfer.cash;
                        }
                        else
                        {
                            invoice.paid = MainWindow.posLogIn.balance;
                            cashTransfer.cash = MainWindow.posLogIn.balance;
                            invoice.deserved -= MainWindow.posLogIn.balance;
                            MainWindow.posLogIn.balance = 0;
                        }
                        await pos.save(MainWindow.posLogIn);
                        await cashTransfer.Save(cashTransfer); //add cash transfer  
                        await invoice.saveInvoice(invoice);
                    }
                    break;
                case "balance":// balance: update customer balance
                    await invoice.recordConfiguredAgentCash(invoice, "pi", cashTransfer);
                    // yasin code
                    //invoice.paid += cashTransfer.cash;
                    //invoice.deserved -= cashTransfer.cash;
                    ////
                    await invoice.saveInvoice(invoice);
                    break;
                case "card": // card  
                    cashTransfer.docNum = tb_processNum.Text;
                    await cashTransfer.Save(cashTransfer); //add cash transfer 
                    invoice.paid += cashTransfer.cash;
                    invoice.deserved -= cashTransfer.cash;
                    await invoice.saveInvoice(invoice);
                    break;
            }
        }
        private async Task saveCashTransfer(CashTransfer cashTransfer)
        {
            switch (cb_paymentProcessType.SelectedValue)
            {
                case "cash":// cash: update pos balance
                    pos = MainWindow.posLogIn;
                    if (MainWindow.posLogIn.balance > 0)
                    {
                        if (MainWindow.posLogIn.balance >= invoice.totalNet)
                        {
                            MainWindow.posLogIn.balance -= invoice.totalNet;
                            invoice.paid = cashTransfer.cash = invoice.totalNet;
                            invoice.deserved = 0;
                        }
                        else
                        {
                            invoice.paid = cashTransfer.cash = MainWindow.posLogIn.balance;
                            invoice.deserved -= MainWindow.posLogIn.balance;
                            MainWindow.posLogIn.balance = 0;
                        }
                        await pos.save(MainWindow.posLogIn);
                        await cashTransfer.Save(cashTransfer); //add cash transfer  
                        await invoice.saveInvoice(invoice);
                    }
                    break;
                case "balance":// balance: update vendor balance                
                    await invoice.recordCashTransfer(invoice, "pi");
                    break;
                case "card":
                    cashTransfer.cash = invoice.totalNet;
                    cashTransfer.cardId = _SelectedCard;
                    cashTransfer.docNum = tb_processNum.Text;
                    await cashTransfer.Save(cashTransfer); //add cash transfer  
                    invoice.paid = invoice.totalNet;
                    invoice.deserved = 0;
                    await invoice.saveInvoice(invoice);
                    break;
            }
        }
        private void Tb_EnglishDigit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only english and digits
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
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

                if (billDetails.Count > 0 && _isLack == false && (_InvoiceType == "pd" || _InvoiceType == "pbd"))
                {
                    bool valid = validateItemUnits();
                    if (billDetails.Count > 0 && valid)
                    {
                        #region Accept
                        MainWindow.mainWindow.Opacity = 0.2;
                        wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                        w.contentText = MainWindow.resourcemanager.GetString("trSaveInvoiceNotification");
                        // w.contentText = "Do you want save pay invoice in drafts?";
                        w.ShowDialog();
                        MainWindow.mainWindow.Opacity = 1;
                        #endregion
                        if (w.isOk)
                        {
                            await addInvoice(_InvoiceType, "pi");
                        }
                        clearInvoice();
                        _InvoiceType = "pd";
                        //refreshDraftNotification();
                    }
                    else if (billDetails.Count == 0)
                    {
                        clearInvoice();
                        _InvoiceType = "pd";
                    }
                }
                else
                    clearInvoice();

                setNotifications();

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
            _SelectedCard = -1;
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
            tb_processNum.Clear();
            cb_paymentProcessType.SelectedIndex = 0;
            cb_paymentProcessType.IsEnabled = true;
            gd_card.Visibility = Visibility.Collapsed;
            tb_total.Text = "0";
            tb_sum.Text = "0";
            if (MainWindow.invoiceTax_decimal != 0)
                tb_taxValue.Text = SectionData.PercentageDecTostring(MainWindow.invoiceTax_decimal);
            else
                tb_taxValue.Text = "0";

            isFromReport = false;
            archived = false;
            md_docImage.Badge = "";
            md_payments.Badge = "";

            TextBox tbStartDate = (TextBox)dp_desrvedDate.Template.FindName("PART_TextBox", dp_desrvedDate);
            SectionData.clearValidate(tbStartDate, p_errorDesrvedDate);
            SectionData.clearValidate(tb_processNum, p_errorProcessNum);
            SectionData.clearComboBoxValidate(cb_vendor, p_errorVendor);
            SectionData.clearValidate(tb_invoiceNumber, p_errorInvoiceNumber);
            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseBill");
            btn_save.Content = MainWindow.resourcemanager.GetString("trBuy");

            refrishBillDetails();
            _InvoiceType = "pd";
            _isLack = false;
            inputEditable();
            btn_next.Visibility = Visibility.Collapsed;
            btn_previous.Visibility = Visibility.Collapsed;
        }
        #endregion
        private void clearNavigation()
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
            tb_processNum.Clear();
            cb_paymentProcessType.SelectedIndex = 0;
            cb_paymentProcessType.IsEnabled = true;
            gd_card.Visibility = Visibility.Collapsed;
            tb_total.Text = "0";
            tb_sum.Text = "0";
            if (MainWindow.tax != 0)
                tb_taxValue.Text = SectionData.PercentageDecTostring(MainWindow.invoiceTax_decimal);
            else
                tb_taxValue.Text = "0";

            isFromReport = false;
            archived = false;
            md_docImage.Badge = "";
            md_payments.Badge = "";

            TextBox tbStartDate = (TextBox)dp_desrvedDate.Template.FindName("PART_TextBox", dp_desrvedDate);
            SectionData.clearValidate(tbStartDate, p_errorDesrvedDate);
            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
            refrishBillDetails();
        }
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
                        isFromReport = false;
                        archived = false;
                        await fillInvoiceInputs(invoice);

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
                        setNotifications();
                        refreshDocCount(invoice.invoiceId);
                    }
                }
                Window.GetWindow(this).Opacity = 1;
                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                Window.GetWindow(this).Opacity = 1;
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
                await saveBeforeTransfer();
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
                        isFromReport = false;
                        archived = false;
                        setNotifications();
                        refreshPaymentsNotification(_invoiceId);
                        refreshDocCount(invoice.invoiceId);
                        // set title to bill
                        if (invoice.invType == "p" || invoice.invType == "pw")
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;

                        }
                        else
                        {
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;

                        }
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
                await saveBeforeTransfer();
                Window.GetWindow(this).Opacity = 0.2;
                wd_invoice w = new wd_invoice();

                // purchase orders
                string invoiceType = "po";
                w.invoiceType = invoiceType;
                w.condition = "orders";
                w.branchId = MainWindow.branchID.Value;
                //w.branchCreatorId = MainWindow.branchID.Value;
                w.title = MainWindow.resourcemanager.GetString("trOrders");

                if (w.ShowDialog() == true)
                {
                    if (w.invoice != null)
                    {
                        invoice = w.invoice;

                        _InvoiceType = invoice.invType;
                        _invoiceId = invoice.invoiceId;
                        isFromReport = false;
                        archived = false;
                        // notifications
                        md_payments.Badge = "";
                        setNotifications();
                        refreshDocCount(invoice.invoiceId);

                        // set title to bill
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseOrder");
                        txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;
                        await fillInvoiceInputs(invoice);
                        invoices = await invoice.getUnHandeldOrders(invoiceType, 0, MainWindow.branchID.Value);
                        //invoices = await invoice.GetInvoicesByCreator(invoiceType, MainWindow.userID.Value, 0);
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
            #region payment process
            if (_InvoiceType == "p" || _InvoiceType == "pw" || _InvoiceType == "pbw" || _InvoiceType == "pb")
            {
                //payments
                var cashTransfers = await cashTransfer.GetListByInvId(invoice.invoiceId);
                if (cashTransfers.Count == 1)
                {
                    cb_paymentProcessType.SelectedValue = cashTransfers[0].processType;
                    try
                    {
                        _SelectedCard = (int)cashTransfers[0].cardId;
                        tb_processNum.Text = cashTransfers[0].docNum;

                        if ((int)cashTransfers[0].cardId != 0)
                        {
                            var card = cards.Where(x => x.cardId == (int)cashTransfers[0].cardId).FirstOrDefault();
                            txt_card.Text = card.name;
                            if (card.hasProcessNum.Value)
                                tb_processNum.Visibility = Visibility.Visible;
                            else
                                tb_processNum.Visibility = Visibility.Collapsed;
                        }
                    }
                    catch { }
                }
                else
                    cb_paymentProcessType.SelectedValue = "multiple";

            }
            #endregion
            #region tax
            if (_InvoiceType == "p" || _InvoiceType == "pw" || _InvoiceType == "pd")
            {
                if (invoice.tax != null)
                    tb_taxValue.Text = SectionData.PercentageDecTostring(invoice.tax);
                else
                    tb_taxValue.Text = "0";
            }
            else if (_InvoiceType == "pbw" || _InvoiceType == "pb" || _InvoiceType == "pbd")
            {
                tb_taxValue.Text = "0";
            }
            #endregion
            _Sum = (decimal)invoice.total;
            txt_invNumber.Text = invoice.invNumber.ToString();
            cb_branch.SelectedValue = invoice.branchId;
            cb_vendor.SelectedValue = invoice.agentId;
            dp_desrvedDate.Text = invoice.deservedDate.ToString();
            tb_invoiceNumber.Text = invoice.vendorInvNum;
            dp_invoiceDate.Text = invoice.vendorInvDate.ToString();
            if (invoice.totalNet != 0)
                tb_total.Text = SectionData.DecTostring(invoice.totalNet);
            else tb_total.Text = "0";


            tb_note.Text = invoice.notes;

            if (invoice.total != 0)
                tb_sum.Text = SectionData.DecTostring(invoice.total);
            else tb_sum.Text = "0";

            if ((invoice.discountValue != 0) && (invoice.discountValue != null))
                tb_discount.Text = SectionData.PercentageDecTostring(invoice.discountValue);
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
            refreshTotalValue();
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
                    if (_InvoiceType == "p")
                    {
                        _InvoiceType = "pbd";
                        isFromReport = true;
                        archived = false;
                        await fillInvoiceInputs(invoice);
                        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                        txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;
                        btn_save.Content = MainWindow.resourcemanager.GetString("trReturn");
                        refreshInvNotification();
                    }
                    else
                    {
                        await saveBeforeExit();
                        Window.GetWindow(this).Opacity = 0.2;
                        wd_returnInvoice w = new wd_returnInvoice();
                        w.fromPurchase = true;
                        w.userId = MainWindow.userID.Value;
                        w.invoiceType = "p";
                        if (w.ShowDialog() == true)
                        {
                            _InvoiceType = "pbd";
                            invoice = w.invoice;
                            isFromReport = true;
                            archived = false;
                            await fillInvoiceInputs(invoice);
                            txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                            txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;
                            btn_save.Content = MainWindow.resourcemanager.GetString("trReturn");
                            setNotifications();
                        }
                        //wd_invoice w = new wd_invoice();

                        //w.title = MainWindow.resourcemanager.GetString("trReturn");
                        //// purchase invoices
                        //string invoiceType = "p";
                        //w.invoiceType = invoiceType; // invoice type to view in grid
                        //if (SectionData.isAdminPermision())
                        //    w.condition = "admin";
                        //else
                        //    w.condition = "return";
                        //w.userId = MainWindow.userID.Value;
                        //if (w.ShowDialog() == true)
                        //{
                        //    if (w.invoice != null)
                        //    {
                        //        _InvoiceType = "pbd";
                        //        invoice = w.invoice;
                        //        _invoiceId = invoice.invoiceId;                           
                        //        #region refresh notification
                        //        isFromReport = false;
                        //        archived = false;
                        //        setNotifications();
                        //        refreshPaymentsNotification(_invoiceId);
                        //        refreshDocCount(invoice.invoiceId);
                        //        #endregion
                        //        md_payments.Badge = "";

                        //        await fillInvoiceInputs(invoice);
                        //        //invoices = await invoice.getBranchInvoices(invoiceType, MainWindow.branchID.Value, MainWindow.branchID.Value);
                        //        if (w.condition == "admin")
                        //            invoices = await invoice.GetInvoicesForAdmin(invoiceType, 0);
                        //        else
                        //            invoices = await invoice.getBranchInvoices(invoiceType, MainWindow.branchID.Value, MainWindow.branchID.Value);
                        //        navigateBtnActivate();
                        //        mainInvoiceItems = invoiceItems;

                        //        txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                        //        txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;
                        //    }
                        //}
                        Window.GetWindow(this).Opacity = 1;
                    }
                    mainInvoiceItems = invoiceItems;
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
            # region get invoice items
            if(_InvoiceType == "po")
                invoiceItems = await invoiceModel.GetInvoicesItemsWithCost(invoice.invoiceId);
            else
                invoiceItems = await invoiceModel.GetInvoicesItems(invoice.invoiceId);
            #endregion
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
                    Price = decimal.Parse(SectionData.DecTostring((decimal)itemT.price)),
                    Total = total,
                    OrderId = orderId,
                    invType = invoice.invType,
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
                dg_billDetails.Columns[3].IsReadOnly = false; //make unit read only
                dg_billDetails.Columns[4].IsReadOnly = false; //make count read only
                cb_vendor.IsEnabled = false;
                dp_desrvedDate.IsEnabled = false;
                dp_invoiceDate.IsEnabled = false;
                tb_note.IsEnabled = false;
                tb_barcode.IsEnabled = false;
                cb_branch.IsEnabled = false;
                tb_discount.IsEnabled = false;
                cb_typeDiscount.IsEnabled = false;
                cb_paymentProcessType.IsEnabled = false;
                tb_processNum.IsEnabled = false;
                dkp_cards.IsEnabled = false;
                btn_save.IsEnabled = false;
                tb_invoiceNumber.IsEnabled = false;
                tb_taxValue.IsEnabled = false;

            }
            else if (_InvoiceType == "pbd") // return invoice
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
                btn_items.IsEnabled = false;
                cb_paymentProcessType.IsEnabled = true;
                tb_processNum.IsEnabled = true;
                dkp_cards.IsEnabled = true;
                btn_clear.IsEnabled = true;
                //btn_updateVendor.IsEnabled = true;
                btn_addVendor.IsEnabled = false;
            }
            else if (_InvoiceType == "pd") // purchase draft 
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
                btn_items.IsEnabled = true;
                cb_paymentProcessType.IsEnabled = true;
                dkp_cards.IsEnabled = true;
                tb_processNum.IsEnabled = true;
                btn_clear.IsEnabled = true;
                // btn_updateVendor.IsEnabled = true;
                btn_addVendor.IsEnabled = true;
            }
            else if (_InvoiceType == "po") //  purchase order
            {
                dg_billDetails.Columns[0].Visibility = Visibility.Visible; //make delete column visible
                dg_billDetails.Columns[5].IsReadOnly = false;
                dg_billDetails.Columns[3].IsReadOnly = false;
                dg_billDetails.Columns[4].IsReadOnly = false;
                cb_vendor.IsEnabled = false;
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
                btn_items.IsEnabled = true;
                cb_paymentProcessType.IsEnabled = true;
                dkp_cards.IsEnabled = true;
                tb_processNum.IsEnabled = true;
                btn_clear.IsEnabled = false;
                btn_addVendor.IsEnabled = false;
            }
            else if (_InvoiceType == "pw" || _InvoiceType == "p" || _InvoiceType == "pb" || archived)
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
                btn_items.IsEnabled = false;
                cb_paymentProcessType.IsEnabled = false;
                dkp_cards.IsEnabled = false;
                tb_processNum.IsEnabled = false;
                btn_clear.IsEnabled = false;
                btn_addVendor.IsEnabled = false;
            }

            if (_InvoiceType.Equals("pb") || _InvoiceType.Equals("p"))
            {
                #region print - pdf - send email
                btn_printInvoice.Visibility = Visibility.Visible;
                btn_pdf.Visibility = Visibility.Visible;
                if (MainWindow.groupObject.HasPermissionAction(printCountPermission, MainWindow.groupObjects, "one"))
                {
                    btn_printCount.Visibility = Visibility.Visible;
                    bdr_printCount.Visibility = Visibility.Visible;
                }
                else
                {
                    btn_printCount.Visibility = Visibility.Collapsed;
                    bdr_printCount.Visibility = Visibility.Collapsed;
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
                #endregion
            }
            else
            {
                #region print - pdf - send email
                btn_printInvoice.Visibility = Visibility.Collapsed;
                btn_pdf.Visibility = Visibility.Collapsed;
                btn_printCount.Visibility = Visibility.Collapsed;
                btn_emailMessage.Visibility = Visibility.Collapsed;
                bdr_emailMessage.Visibility = Visibility.Collapsed;
                #endregion
            }
            if (!isFromReport)
            {
                btn_next.Visibility = Visibility.Visible;
                btn_previous.Visibility = Visibility.Visible;
            }
        }
        private void Btn_invoiceImage_Click(object sender, RoutedEventArgs e)
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
                        invType = invoice.invType,
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
                cb_vendor.ItemsSource = vendorsL.Where(x => x.name.Contains(cb_vendor.Text));

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
                if (cb_vendor.IsFocused || _InvoiceType == "pd")
                {
                    TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                    if (elapsed.TotalMilliseconds > 100 && cb_vendor.SelectedIndex != -1)
                    {
                        _SelectedVendor = (int)cb_vendor.SelectedValue;
                        if (_InvoiceType == "pd")
                            btn_updateVendor.IsEnabled = true;
                        var v = vendorsL.Where(x => x.agentId == _SelectedVendor).FirstOrDefault();
                        if (v.payType != null)
                            cb_paymentProcessType.SelectedValue = v.payType;
                        else
                            cb_paymentProcessType.SelectedIndex = 0;

                    }
                    else
                    {
                        cb_vendor.SelectedValue = _SelectedVendor;
                    }
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
                if (txb.IsFocused)
                {
                    if ((sender as TextBox).Name == "tb_discount")
                        SectionData.InputJustNumber(ref txb);
                    if ((sender as TextBox).Name == "tb_taxValue")
                        SectionData.InputJustNumber(ref txb);
                    _Sender = sender;
                    refreshTotalValue();
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void refreshTotalValue()
        {
            decimal discountValue = 0;
            #region calculate discount
            if (_Sum > 0)
            {
                if (tb_discount.Text != "." && !tb_discount.Text.Equals(""))
                    discountValue = decimal.Parse(tb_discount.Text);

                if (cb_typeDiscount.SelectedIndex != -1 && int.Parse(cb_typeDiscount.SelectedValue.ToString()) == 2) // discount type is rate
                {
                    discountValue = SectionData.calcPercentage(_Sum, discountValue);
                }

                tb_totalDescount.Text = SectionData.PercentageDecTostring(discountValue);
            }
            #endregion
            decimal total = _Sum - discountValue;
            decimal taxValue = 0;
            decimal taxInputVal = 0;
            if (!tb_taxValue.Text.Equals(""))
                taxInputVal = decimal.Parse(tb_taxValue.Text);
            if (total != 0)
                taxValue = SectionData.calcPercentage(total, taxInputVal);

            if (_Sum < 0)
                _Sum = 0;

            if (_Sum != 0)
                tb_sum.Text = SectionData.DecTostring(_Sum);
            else
                tb_sum.Text = "0";

            total = total + taxValue;
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
                SectionData.StartAwait(grid_main);
                dg_billDetails.IsEnabled = false;
                await Task.Delay(1000);
                dg_billDetails.Items.Refresh();
                firstTimeForDatagrid = false;
                dg_billDetails.IsEnabled = true;
                SectionData.EndAwait(grid_main);
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
            DataGrid_CollectionChanged(dg_billDetails, null);

        }

        // read item from barcode
        private async void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (!_IsFocused)
                {
                    Control c = CheckActiveControl();
                    if (c == null)
                        tb_barcode.Focus();
                    _IsFocused = true;
                }
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 150)
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
                    if (_Sender != null)
                    {
                        DatePicker dt = _Sender as DatePicker;
                        TextBox tb = _Sender as TextBox;
                        if (dt != null)
                        {
                            if (dt.Name == "dp_desrvedDate" || dt.Name == "dp_invoiceDate")
                            {
                                string br = "";
                                for (int i = 0; i < _BarcodeStr.Length; i++)
                                {
                                    br += _BarcodeStr[i];
                                    i++;
                                }
                                _BarcodeStr = br;
                                //_BarcodeStr = _BarcodeStr.Substring(1);
                            }
                        }
                        else if (tb != null)
                        {
                            if (tb.Name == "tb_invoiceNumber" || tb.Name == "tb_note" || tb.Name == "tb_discount")// remove barcode from text box
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
                    await dealWithBarcode(_BarcodeStr);
                    tb_barcode.Text = _BarcodeStr;
                    _BarcodeStr = "";
                    _IsFocused = false;
                    e.Handled = true;
                    cb_branch.SelectedValue = _SelectedBranch;
                }
                _Sender = null;
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
                        ItemUnit unit1 = barcodesList.ToList().Find(c => c.barcode == barcode.Trim());

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
                                    decimal price = (decimal)unit1.cost; //?????
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
                invType = invoice.invType,
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
                #region enable - disable unit comboBox according to invoice type
                if (_InvoiceType == "p" || _InvoiceType == "pw" || _InvoiceType == "pb" || _InvoiceType == "pbw")
                    cmb.IsEnabled = false;
                else 
                    cmb.IsEnabled = true;
                #endregion

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Cbm_unitItemDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var cmb = sender as ComboBox;

                if (dg_billDetails.SelectedIndex != -1 && cmb.SelectedValue != null)
                {
                    billDetails[dg_billDetails.SelectedIndex].itemUnitId = (int)cmb.SelectedValue;

                    TextBlock tb;

                    int _datagridSelectedIndex = dg_billDetails.SelectedIndex;
                    int itemUnitId = (int)cmb.SelectedValue;
                    int itemId = billDetails[_datagridSelectedIndex].itemId;
                    billDetails[_datagridSelectedIndex].itemUnitId = (int)cmb.SelectedValue;
                    #region Dina

                    dynamic unit;
                    if (MainWindow.InvoiceGlobalItemUnitsList.Count == 0)
                    {
                        unit = new Item();
                        unit = barcodesList.ToList().Find(x => x.itemUnitId == (int)cmb.SelectedValue && x.itemId == billDetails[_datagridSelectedIndex].itemId);
                    }
                    else
                    {
                        unit = new ItemUnit();
                        unit = MainWindow.InvoiceGlobalItemUnitsList.Find(x => x.itemUnitId == (int)cmb.SelectedValue && x.itemId == billDetails[_datagridSelectedIndex].itemId);
                    }

                    int oldCount = 0;
                    long newCount = 0;
                    decimal oldPrice = 0;
                    decimal itemTax = 0;

                    decimal newPrice = 0;
                    oldCount = billDetails[_datagridSelectedIndex].Count;
                    oldPrice = billDetails[_datagridSelectedIndex].Price;
                    newCount = oldCount;
                    #region if return invoice
                    if (_InvoiceType == "pbd" || _InvoiceType == "pbw")
                    {
                        tb = dg_billDetails.Columns[4].GetCellContent(dg_billDetails.Items[_datagridSelectedIndex]) as TextBlock;

                        var itemUnitsIds = barcodesList.Where(x => x.itemId == itemId).Select(x => x.itemUnitId).ToList();

                        #region caculate available amount in this bil
                        int availableAmountInBranch = await itemLocationModel.getAmountInBranch(itemUnitId, MainWindow.branchID.Value);
                        int amountInBill = await getAmountInBill(itemId,itemUnitId, MainWindow.branchID.Value, billDetails[_datagridSelectedIndex].ID);
                        int availableAmount = availableAmountInBranch - amountInBill;
                        #endregion
                        #region calculate amount in purchase invoice
                        var items = mainInvoiceItems.ToList().Where(i => itemUnitsIds.Contains((int)i.itemUnitId));
                        int purchasedAmount = 0;
                        foreach (ItemTransfer it in items)
                        {
                            if (itemUnitId == (int)it.itemUnitId)
                                purchasedAmount += (int)it.quantity;
                            else
                                purchasedAmount += await itemUnitModel.fromUnitToUnitQuantity((int)it.quantity, itemId, (int)it.itemUnitId, itemUnitId);
                        }
                        #endregion
                        if (newCount > (purchasedAmount - amountInBill) || newCount > availableAmount)
                        {
                            // return old value 
                            tb.Text = (purchasedAmount - amountInBill) > availableAmount ? availableAmount.ToString() : (purchasedAmount - amountInBill).ToString();

                            newCount = (purchasedAmount - amountInBill) > availableAmount ? availableAmount : (purchasedAmount - amountInBill);
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
                        }
                    }
                    #endregion
                    

                    newPrice = unit.cost;

                    tb = dg_billDetails.Columns[5].GetCellContent(dg_billDetails.Items[_datagridSelectedIndex]) as TextBlock;
                    tb.Text = newPrice.ToString();

                    // old total for changed item
                    decimal total = oldPrice * oldCount;
                    _Sum -= total;


                    // new total for changed item
                    total = newCount * newPrice;
                    _Sum += total;

                    #region items tax
                    if (item.taxes != null)
                        itemTax = (decimal)item.taxes;
                    #endregion

                    refreshTotalValue();

                    // update item in billdetails           
                    billDetails[_datagridSelectedIndex].Count = (int)newCount;
                    billDetails[_datagridSelectedIndex].Price = newPrice;
                    billDetails[_datagridSelectedIndex].Total = total;
                    refrishBillDetails();
                    #endregion
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

                                //if (item.invType == "p" || item.invType == "pw" || item.invType == "pb" || item.invType == "pbw")
                                //    combo.IsEnabled = false;
                                //else
                                //    combo.IsEnabled = true;
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
            //if (dg_billDetails.SelectedIndex != -1 )
            //    if (billDetails[dg_billDetails.SelectedIndex].invType == "p" || billDetails[dg_billDetails.SelectedIndex].invType == "pw"
            //       || billDetails[dg_billDetails.SelectedIndex].invType == "pb" || billDetails[dg_billDetails.SelectedIndex].invType == "pbw")
            //        e.Cancel = true;

            int column = dg_billDetails.CurrentCell.Column.DisplayIndex;
            if (_InvoiceType == "p" || _InvoiceType == "pw"
                || _InvoiceType == "pb" || _InvoiceType == "pbw"
                || (_InvoiceType == "pbd" && column == 3))
                e.Cancel = true;
        }


        private async void Dg_billDetails_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);
                //if (invoice.invoiceId == 0 && e.Column.DisplayIndex == 3)
                //{

                //}
                //else
                //{
                TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
                var columnName = e.Column.Header.ToString();

                BillDetails row = e.Row.Item as BillDetails;
                int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == row.itemUnitId ).FirstOrDefault());

                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds < 100)
                {
                    if (columnName == MainWindow.resourcemanager.GetString("trQTR"))
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
                    if (columnName == MainWindow.resourcemanager.GetString("trQTR"))
                    {
                        if (!t.Text.Equals(""))
                            newCount = int.Parse(t.Text);
                        else
                            newCount = 0;
                        if (newCount < 0)
                        {
                            newCount = 0;
                            t.Text = "0";
                        }
                    }
                    else
                        newCount = row.Count;

                    oldCount = row.Count;
                    oldPrice = row.Price;
                    #region if return invoice
                    if (_InvoiceType == "pbd" || _InvoiceType == "pbw")
                    {
                        //ItemTransfer item = mainInvoiceItems.ToList().Find(i => i.itemUnitId == row.itemUnitId);
                        //if (newCount > item.quantity)
                        //{
                        //    // return old value 
                        //    t.Text = item.quantity.ToString();

                        //    newCount = (long)item.quantity;
                        //    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
                        //}
                        var selectedItemUnitId = row.itemUnitId;

                        var itemUnitsIds = barcodesList.Where(x => x.itemId == row.itemId).Select(x => x.itemUnitId).ToList();

                        #region caculate available amount in this bil
                        int availableAmountInBranch = await itemLocationModel.getAmountInBranch(row.itemUnitId, MainWindow.branchID.Value);
                        int amountInBill =  await getAmountInBill(row.itemId, row.itemUnitId, MainWindow.branchID.Value, row.ID);
                        int availableAmount = availableAmountInBranch- amountInBill;
                        #endregion
                        #region calculate amount in purchase invoice
                        var items = mainInvoiceItems.ToList().Where(i => itemUnitsIds.Contains((int)i.itemUnitId));
                        int purchasedAmount = 0;
                        foreach (ItemTransfer it in items)
                        {
                            if (selectedItemUnitId == (int)it.itemUnitId)
                                purchasedAmount += (int)it.quantity;
                            else
                                purchasedAmount += await itemUnitModel.fromUnitToUnitQuantity((int)it.quantity,row.itemId,(int)it.itemUnitId, selectedItemUnitId);
                        }
                        #endregion
                        if (newCount > (purchasedAmount-amountInBill) || newCount > availableAmount)
                        {
                            // return old value 
                            t.Text = (purchasedAmount-amountInBill)>availableAmount ? availableAmount.ToString() : (purchasedAmount - amountInBill).ToString();

                            newCount = (purchasedAmount - amountInBill) > availableAmount ? availableAmount : (purchasedAmount - amountInBill);
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trErrorAmountIncreaseToolTip"), animation: ToasterAnimation.FadeIn);
                        }
                    }
                    #endregion

                    if (columnName == MainWindow.resourcemanager.GetString("trPrice") && !t.Text.Equals(""))
                        newPrice = decimal.Parse(t.Text);
                    else
                        newPrice = row.Price;                    

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
                refrishBillDetails();
               //refrishDataGridItems();
                //}
                //if (sender != null)
                //SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async Task<int> getAmountInBill(int itemId, int itemUnitId, int branchId, int ID)
        {
            int quantity = 0;
            var itemUnits = barcodesList.Where(a => a.itemId == itemId).ToList();
            //int availableAmount = await itemLocationModel.getAmountInBranch(itemUnitId, branchId);
            var smallUnits = await itemUnitModel.getSmallItemUnits(itemId, itemUnitId);
            foreach (ItemUnit u in itemUnits)
            {
                var isInBill = billDetails.ToList().Find(x => x.itemUnitId == (int)u.itemUnitId && x.ID != ID); // unit exist in invoice
                if (isInBill != null)
                {
                    var isSmall = smallUnits.Find(x => x.itemUnitId == (int)u.itemUnitId);
                    int unitValue = 0;

                    int index = billDetails.IndexOf(billDetails.Where(p => p.itemUnitId == u.itemUnitId).FirstOrDefault());
                    int count= billDetails[index].Count;
                    if (itemUnitId == u.itemUnitId)
                    {
                        quantity += count;
                    }
                    else if (isSmall != null) // from-unit is bigger than to-unit
                    {
                        unitValue = await itemUnitModel.largeToSmallUnitQuan(itemUnitId, (int)u.itemUnitId);
                        quantity += count / unitValue;
                    }
                    else
                    {
                        unitValue = await itemUnitModel.smallToLargeUnit(itemUnitId, (int)u.itemUnitId);

                        if (unitValue != 0)
                        {
                            quantity += count * unitValue;
                        }
                    }

                }
            }
            return quantity;
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

        public async void multiplePaytable(List<ReportParameter> paramarr)
        {
            if ((prInvoice.invType == "p" || prInvoice.invType == "pw" || prInvoice.invType == "pbd" || prInvoice.invType == "pb"))
            {
                CashTransfer cachModel = new CashTransfer();
                List<PayedInvclass> payedList = new List<PayedInvclass>();
                payedList = await cachModel.GetPayedByInvId(prInvoice.invoiceId);
                mailpayedList = payedList;
                decimal sump = payedList.Sum(x => x.cash).Value;
                decimal deservd = (decimal)prInvoice.totalNet - sump;
                //convertter
                foreach (var p in payedList)
                {
                    p.cash = decimal.Parse(reportclass.DecTostring(p.cash));
                }
                paramarr.Add(new ReportParameter("cashTr", MainWindow.resourcemanagerreport.GetString("trCashType")));

                paramarr.Add(new ReportParameter("sumP", reportclass.DecTostring(sump)));
                paramarr.Add(new ReportParameter("deserved", reportclass.DecTostring(deservd)));
                rep.DataSources.Add(new ReportDataSource("DataSetPayedInvclass", payedList));


            }
        }


        public async void pdfPurInvoice()
        {
            try
            {
                if (invoice.invoiceId > 0)
                {
                    prInvoice = await invoiceModel.GetByInvoiceId(invoice.invoiceId);

                    if (int.Parse(MainWindow.Allow_print_inv_count) <= prInvoice.printedcount)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trYouExceedLimit"), animation: ToasterAnimation.FadeIn);

                        });
                    }
                    else
                    {

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
                                if (prInvoice.agentId != null)
                                {
                                    Agent agentinv = new Agent();
                                    //  agentinv = vendors.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();
                                    agentinv = await agentinv.getAgentById((int)prInvoice.agentId);
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
                                User employ = new User();
                                employ = await employ.getUserById((int)prInvoice.updateUserId);
                                prInvoice.uuserName = employ.name;
                                prInvoice.uuserLast = employ.lastname;


                                Branch branch = new Branch();
                                branch = await branchModel.getBranchById((int)prInvoice.branchCreatorId);
                                if (branch.branchId > 0)
                                {
                                    prInvoice.branchCreatorName = branch.name;
                                }
                                //branch reciver
                                if (prInvoice.branchId != null)
                                {
                                    if (prInvoice.branchId > 0)
                                    {
                                        branch = await branchModel.getBranchById((int)prInvoice.branchId);
                                        prInvoice.branchName = branch.name;
                                    }
                                    else
                                    {
                                        prInvoice.branchName = "-";
                                    }

                                }
                                else
                                {
                                    prInvoice.branchName = "-";
                                }
                                // end branch reciever


                                ReportCls.checkLang();
                                foreach (var i in invoiceItems)
                                {
                                    i.price = decimal.Parse(SectionData.DecTostring(i.price));
                                    i.subTotal = decimal.Parse(SectionData.DecTostring(i.price * i.quantity));
                                }
                                clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                                clsReports.setReportLanguage(paramarr);
                                clsReports.Header(paramarr);
                                paramarr = reportclass.fillPurInvReport(prInvoice, paramarr);

                                multiplePaytable(paramarr);

                                rep.SetParameters(paramarr);
                                rep.Refresh();

                                saveFileDialog.Filter = "PDF|*.pdf;";
                                bool? savdialog = false;
                                this.Dispatcher.Invoke(() =>
                                {
                                    savdialog = saveFileDialog.ShowDialog();

                                });


                                if (savdialog == true)
                                {

                                    string filepath = saveFileDialog.FileName;

                                    //copy count
                                    if (prInvoice.invType == "s" || prInvoice.invType == "sb" || prInvoice.invType == "p" || prInvoice.invType == "pb")
                                    {

                                        paramarr.Add(new ReportParameter("isOrginal", false.ToString()));



                                        rep.SetParameters(paramarr);

                                        rep.Refresh();

                                        if (int.Parse(MainWindow.Allow_print_inv_count) > prInvoice.printedcount)
                                        {

                                            this.Dispatcher.Invoke(() =>
                                            {
                                                LocalReportExtensions.ExportToPDF(rep, filepath);

                                            });


                                            int res = 0;

                                            res = await invoiceModel.updateprintstat(prInvoice.invoiceId, 1, false, true);



                                            prInvoice.printedcount = prInvoice.printedcount + 1;

                                            prInvoice.isOrginal = false;


                                        }
                                        else
                                        {
                                            this.Dispatcher.Invoke(() =>
                                            {
                                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trYouExceedLimit"), animation: ToasterAnimation.FadeIn);

                                            });

                                        }


                                    }
                                    else
                                    {

                                        this.Dispatcher.Invoke(() =>
                                        {

                                            LocalReportExtensions.ExportToPDF(rep, filepath);


                                        });

                                    }
                                    // end copy count

                                    /*
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        saveFileDialog.Filter = "PDF|*.pdf;";

                                        if (saveFileDialog.ShowDialog() == true)
                                        {

                                            string filepath = saveFileDialog.FileName;
                                            LocalReportExtensions.ExportToPDF(rep, filepath);
                                        }
                                    });


                                    */
                                }
                            }

                        }
                    }
                }
            }
            catch
            {
                this.Dispatcher.Invoke(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: "Not completed", animation: ToasterAnimation.FadeIn);

                });
            }
        }
        public async void previewPurInvoice()
        {
            try
            {



                if (invoice.invoiceId > 0)
                {

                    prInvoice = await invoiceModel.GetByInvoiceId(invoice.invoiceId);

                    if (int.Parse(MainWindow.Allow_print_inv_count) <= prInvoice.printedcount)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trYouExceedLimit"), animation: ToasterAnimation.FadeIn);

                    }
                    else
                    {



                        Window.GetWindow(this).Opacity = 0.2;

                        List<ReportParameter> paramarr = new List<ReportParameter>();
                        string pdfpath;

                        //
                        pdfpath = @"\Thumb\report\temp.pdf";
                        pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);
                        string reppath = reportclass.GetpayInvoiceRdlcpath(prInvoice);
                        if (prInvoice.invoiceId > 0)
                        {
                            invoiceItems = await invoiceModel.GetInvoicesItems(prInvoice.invoiceId);
                            if (prInvoice.agentId != null)
                            {
                                Agent agentinv = new Agent();
                                agentinv = await agentinv.getAgentById((int)prInvoice.agentId);
                                // agentinv = vendors.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();

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
                                prInvoice.branchCreatorName = branch.name;
                            }

                            //branch reciver
                            if (prInvoice.branchId != null)
                            {
                                if (prInvoice.branchId > 0)
                                {
                                    branch = await branchModel.getBranchById((int)prInvoice.branchId);
                                    prInvoice.branchName = branch.name;
                                }
                                else
                                {
                                    prInvoice.branchName ="-";
                                }

                            }
                            else
                            {
                                prInvoice.branchName = "-";
                            }
                            // end branch reciever


                            User employ = new User();
                            employ = await employ.getUserById((int)prInvoice.updateUserId);
                            prInvoice.uuserName = employ.name;
                            prInvoice.uuserLast = employ.lastname;

                            ReportCls.checkLang();
                            foreach (var i in invoiceItems)
                            {
                                i.price = decimal.Parse(SectionData.DecTostring(i.price));
                                //r.deserveDate = Convert.ToDateTime(SectionData.DateToString(r.deserveDate));
                                i.subTotal = decimal.Parse(SectionData.DecTostring(i.price * i.quantity));
                            }
                            clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                            clsReports.setReportLanguage(paramarr);
                            clsReports.Header(paramarr);
                            paramarr = reportclass.fillPurInvReport(prInvoice, paramarr);

                            if ((prInvoice.invType == "p" || prInvoice.invType == "pw" || prInvoice.invType == "pbd" || prInvoice.invType == "pb" || prInvoice.invType == "pd"))
                            {
                                CashTransfer cachModel = new CashTransfer();
                                List<PayedInvclass> payedList = new List<PayedInvclass>();
                                payedList = await cachModel.GetPayedByInvId(prInvoice.invoiceId);
                                decimal sump = payedList.Sum(x => x.cash).Value;
                                decimal deservd = (decimal)prInvoice.totalNet - sump;
                                //convertter
                                foreach (var p in payedList)
                                {
                                    p.cash = decimal.Parse(reportclass.DecTostring(p.cash));
                                }
                                paramarr.Add(new ReportParameter("cashTr", MainWindow.resourcemanagerreport.GetString("trCashType")));

                                paramarr.Add(new ReportParameter("sumP", reportclass.DecTostring(sump)));
                                paramarr.Add(new ReportParameter("deserved", reportclass.DecTostring(deservd)));
                                rep.DataSources.Add(new ReportDataSource("DataSetPayedInvclass", payedList));


                            }

                            if (prInvoice.invType == "pd" || prInvoice.invType == "sd" || prInvoice.invType == "qd"
          || prInvoice.invType == "sbd" || prInvoice.invType == "pbd"
          || prInvoice.invType == "ord" || prInvoice.invType == "imd" || prInvoice.invType == "exd")
                            {
                                paramarr.Add(new ReportParameter("isOrginal", true.ToString()));
                            }
                            else
                            {
                                paramarr.Add(new ReportParameter("isOrginal", false.ToString()));
                            }
                            rep.SetParameters(paramarr);
                            rep.Refresh();
                            //copy count
                            if (prInvoice.invType == "s" || prInvoice.invType == "sb" || prInvoice.invType == "p" || prInvoice.invType == "pw" || prInvoice.invType == "pw")
                            {

                                // paramarr.Add(new ReportParameter("isOrginal", prInvoice.isOrginal.ToString()));

                                // update paramarr->isOrginal
                                foreach (var item in paramarr.Where(x => x.Name == "isOrginal").ToList())
                                {
                                    StringCollection myCol = new StringCollection();
                                    myCol.Add(prInvoice.isOrginal.ToString());
                                    item.Values = myCol;


                                }
                                //end update


                                rep.SetParameters(paramarr);

                                rep.Refresh();

                                if (int.Parse(MainWindow.Allow_print_inv_count) > prInvoice.printedcount)
                                {

                                    LocalReportExtensions.ExportToPDF(rep, pdfpath);

                                    int res = 0;

                                    res = await invoiceModel.updateprintstat(prInvoice.invoiceId, 1, false, true);



                                    prInvoice.printedcount = prInvoice.printedcount + 1;

                                    prInvoice.isOrginal = false;


                                }
                                else
                                {
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trYouExceedLimit"), animation: ToasterAnimation.FadeIn);
                                }


                            }
                            else
                            {

                                LocalReportExtensions.ExportToPDF(rep, pdfpath);

                            }
                            // end copy count

                            //   LocalReportExtensions.ExportToPDF(rep, pdfpath);




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
                    //
                }
                else
                {
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trSaveInvoiceToPreview"), animation: ToasterAnimation.FadeIn);

                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: "Not completed", animation: ToasterAnimation.FadeIn);

                });
            }

        }
        public async void printPurInvoice()
        {
            try
            {


                if (prInvoiceId > 0)
                {
                    prInvoice = new Invoice();
                    prInvoice = await invoiceModel.GetByInvoiceId(prInvoiceId);
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


                            // agentinv = vendors.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();

                            User employ = new User();
                            employ = await employ.getUserById((int)prInvoice.updateUserId);
                            prInvoice.uuserName = employ.name;
                            prInvoice.uuserLast = employ.lastname;

                            if (prInvoice.agentId != null)
                            {
                                Agent agentinv = new Agent();
                                //  agentinv = vendors.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();
                                agentinv = await agentinv.getAgentById((int)prInvoice.agentId);
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
                                prInvoice.branchCreatorName = branch.name;
                            }
                            //branch reciver
                            if (prInvoice.branchId != null)
                            {
                                if (prInvoice.branchId > 0)
                                {
                                    branch = await branchModel.getBranchById((int)prInvoice.branchId);
                                    prInvoice.branchName = branch.name;
                                }
                                else
                                {
                                    prInvoice.branchName = "-";
                                }

                            }
                            else
                            {
                                prInvoice.branchName = "-";
                            }
                            // end branch reciever

                            ReportCls.checkLang();
                            foreach (var i in invoiceItems)
                            {
                                i.price = decimal.Parse(SectionData.DecTostring(i.price));
                                i.subTotal = decimal.Parse(SectionData.DecTostring(i.price * i.quantity));
                            }
                            clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                            clsReports.setReportLanguage(paramarr);
                            clsReports.Header(paramarr);
                            paramarr = reportclass.fillPurInvReport(prInvoice, paramarr);
                            multiplePaytable(paramarr);
                            rep.SetParameters(paramarr);
                            rep.Refresh();


                            //copy count
                            if (prInvoice.invType == "s" || prInvoice.invType == "sb" || prInvoice.invType == "p" || prInvoice.invType == "pb" || prInvoice.invType == "pw")
                            {

                                paramarr.Add(new ReportParameter("isOrginal", prInvoice.isOrginal.ToString()));

                                for (int i = 1; i <= short.Parse(MainWindow.pur_copy_count); i++)
                                {
                                    if (i > 1)
                                    {
                                        // update paramarr->isOrginal
                                        foreach (var item in paramarr.Where(x => x.Name == "isOrginal").ToList())
                                        {
                                            StringCollection myCol = new StringCollection();
                                            myCol.Add(prInvoice.isOrginal.ToString());
                                            item.Values = myCol;


                                        }
                                        //end update

                                    }
                                    rep.SetParameters(paramarr);

                                    rep.Refresh();

                                    if (int.Parse(MainWindow.Allow_print_inv_count) > prInvoice.printedcount)
                                    {

                                        this.Dispatcher.Invoke(() =>
                                        {


                                            LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.sale_printer_name, 1);



                                        });


                                        int res = 0;
                                        res = await invoiceModel.updateprintstat(prInvoice.invoiceId, 1, false, true);
                                        prInvoice.printedcount = prInvoice.printedcount + 1;

                                        prInvoice.isOrginal = false;


                                    }
                                    else
                                    {
                                        this.Dispatcher.Invoke(() =>
                                        {
                                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trYouExceedLimit"), animation: ToasterAnimation.FadeIn);
                                        });

                                    }

                                }
                            }
                            else
                            {

                                this.Dispatcher.Invoke(() =>
                                {
                                    LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
                                });

                            }
                            // end copy count

                            /*
                            this.Dispatcher.Invoke(() =>
                            {
                                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, 1);
                            });
                            */


                        }
                    }

                    //
                }
            }
            catch
            {
                this.Dispatcher.Invoke(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: "Not completed", animation: ToasterAnimation.FadeIn);

                });

            }
        }

        public async void sendPurEmail()
        {
            try
            {
                //
                if (prInvoiceId > 0)
                {
                    prInvoice = new Invoice();
                    prInvoice = await invoiceModel.GetByInvoiceId(prInvoiceId);
                    decimal? discountval = 0;
                    string discounttype = "";
                    discountval = prInvoice.discountValue;
                    discounttype = prInvoice.discountType;

                    if (prInvoice.invType == "pd" || prInvoice.invType == "sd" || prInvoice.invType == "qd"
                    || prInvoice.invType == "sbd" || prInvoice.invType == "pbd"
                    || prInvoice.invType == "ord" || prInvoice.invType == "imd" || prInvoice.invType == "exd")
                    {
                        Dispatcher.Invoke(new Action(() =>
                        {
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trCanNotSendDraftInvoice"), animation: ToasterAnimation.FadeIn);
                        }));
                    }
                    else
                    {
                        if (prInvoice.invType == "pw" || prInvoice.invType == "p")
                        {
                            invoiceItems = await invoiceModel.GetInvoicesItems(prInvoice.invoiceId);
                            SysEmails email = new SysEmails();
                            EmailClass mailtosend = new EmailClass();
                            email = await email.GetByBranchIdandSide((int)MainWindow.branchID, "purchase");
                            if (email == null)
                            {
                                this.Dispatcher.Invoke(new Action(() =>
                                {
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoEmailForThisDept"), animation: ToasterAnimation.FadeIn);
                                }));
                            }
                            else
                            {
                                Agent toAgent = new Agent();

                                if (prInvoice.agentId != null)
                                {

                                    //  agentinv = vendors.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();
                                    toAgent = await toAgent.getAgentById((int)prInvoice.agentId);
                                    prInvoice.agentCode = toAgent.code;
                                    //new lines
                                    prInvoice.agentName = toAgent.name;
                                    prInvoice.agentCompany = toAgent.company;
                                }
                                else
                                {

                                    prInvoice.agentCode = "-";
                                    //new lines
                                    prInvoice.agentName = "-";
                                    prInvoice.agentCompany = "-";
                                }
                                if (toAgent == null || toAgent.agentId == 0)
                                {
                                    //edit warning message to customer
                                    Dispatcher.Invoke(new Action(() =>
                                    {
                                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTheVendorHasNoEmail"), animation: ToasterAnimation.FadeIn);
                                    }));
                                }
                                else
                                {
                                    //  int? itemcount = invoiceItems.Count();
                                    if (email.emailId == 0)
                                    {
                                        Dispatcher.Invoke(new Action(() =>
                                        {
                                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoEmailForThisDept"), animation: ToasterAnimation.FadeIn);
                                        }));
                                    }
                                    else
                                    {
                                        if (prInvoice.invoiceId == 0)
                                        {
                                            Dispatcher.Invoke(new Action(() =>
                                            {
                                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trThereIsNoOrderToSen"), animation: ToasterAnimation.FadeIn);
                                            }));
                                        }
                                        else
                                        {
                                            if (invoiceItems == null || invoiceItems.Count() == 0)
                                            {
                                                Dispatcher.Invoke(new Action(() =>
                                                {
                                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trThereIsNoItemsToSend"), animation: ToasterAnimation.FadeIn);
                                                }));
                                            }
                                            else
                                            {

                                                if (toAgent.email.Trim() == "" || toAgent.email.Trim() == null)
                                                {
                                                    Dispatcher.Invoke(new Action(() =>
                                                    {
                                                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trTheVendorHasNoEmail"), animation: ToasterAnimation.FadeIn);
                                                    }));
                                                }

                                                else
                                                {
                                                    SetValues setvmodel = new SetValues();


                                                    List<SetValues> setvlist = new List<SetValues>();
                                                    if (prInvoice.invType == "pw" || prInvoice.invType == "p")
                                                    {
                                                        setvlist = await setvmodel.GetBySetName("pur_email_temp");
                                                    }
                                                    else if (prInvoice.invType == "or" || prInvoice.invType == "ors")
                                                    {
                                                        setvlist = await setvmodel.GetBySetName("sale_order_email_temp");
                                                    }
                                                    foreach (var i in invoiceItems)
                                                    {
                                                        i.price = decimal.Parse(SectionData.DecTostring(i.price));
                                                    }
                                                    string pdfpath = await SavePurpdf();
                                                    prInvoice.discountValue = discountval;
                                                    prInvoice.discountType = discounttype;
                                                    mailtosend = mailtosend.fillSaleTempData(prInvoice, invoiceItems, mailpayedList, email, toAgent, setvlist);

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

                                                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoConnection"), animation: ToasterAnimation.FadeIn);
                                                        }
                                                        else if (msg == "mailsent")
                                                        {
                                                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailSent"), animation: ToasterAnimation.FadeIn);

                                                        }
                                                        else
                                                        {
                                                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trMailNotSent"), animation: ToasterAnimation.FadeIn);

                                                        }
                                                    }));

                                                }
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
            catch
            {
                this.Dispatcher.Invoke(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: "Not completed", animation: ToasterAnimation.FadeIn);

                });
            }
        }
        //public async void SavePurpdf()

        public async Task<string> SavePurpdf()
        {
            string pdfpath;
            pdfpath = @"\Thumb\report\File.pdf";
            try
            {


                if (prInvoiceId > 0)
                {
                    prInvoice = new Invoice();
                    prInvoice = await invoiceModel.GetByInvoiceId(prInvoiceId);

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
                            //  agentinv = vendors.Where(X => X.agentId == prInvoice.agentId).FirstOrDefault();
                            agentinv = await agentinv.getAgentById((int)prInvoice.agentId);
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
                            prInvoice.branchCreatorName = branch.name;
                        }
                        //branch reciver
                        if (prInvoice.branchId != null)
                        {
                            if (prInvoice.branchId > 0)
                            {
                                branch = await branchModel.getBranchById((int)prInvoice.branchId);
                                prInvoice.branchName = branch.name;
                            }
                            else
                            {
                                prInvoice.branchName = "-";
                            }

                        }
                        else
                        {
                            prInvoice.branchName = "-";
                        }
                        // end branch reciever

                        User employ = new User();
                        employ = await employ.getUserById((int)prInvoice.updateUserId);
                        prInvoice.uuserName = employ.name;
                        prInvoice.uuserLast = employ.lastname;

                        ReportCls.checkLang();
                        foreach (var i in invoiceItems)
                        {
                            i.price = decimal.Parse(SectionData.DecTostring(i.price));
                            i.subTotal = decimal.Parse(SectionData.DecTostring(i.price * i.quantity));
                        }
                        clsReports.purchaseInvoiceReport(invoiceItems, rep, reppath);
                        clsReports.setReportLanguage(paramarr);
                        clsReports.Header(paramarr);
                        paramarr = reportclass.fillPurInvReport(prInvoice, paramarr);


                        if ((prInvoice.invType == "p" || prInvoice.invType == "pw" || prInvoice.invType == "pbd" || prInvoice.invType == "pb"))
                        {
                            CashTransfer cachModel = new CashTransfer();
                            List<PayedInvclass> payedList = new List<PayedInvclass>();
                            payedList = await cachModel.GetPayedByInvId(prInvoice.invoiceId);
                            mailpayedList = payedList;
                            decimal sump = payedList.Sum(x => x.cash).Value;
                            decimal deservd = (decimal)prInvoice.totalNet - sump;
                            //convertter
                            foreach (var p in payedList)
                            {
                                p.cash = decimal.Parse(reportclass.DecTostring(p.cash));
                            }
                            paramarr.Add(new ReportParameter("cashTr", MainWindow.resourcemanagerreport.GetString("trCashType")));

                            paramarr.Add(new ReportParameter("sumP", reportclass.DecTostring(sump)));
                            paramarr.Add(new ReportParameter("deserved", reportclass.DecTostring(deservd)));
                            rep.DataSources.Add(new ReportDataSource("DataSetPayedInvclass", payedList));


                        }
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
            catch
            {
                this.Dispatcher.Invoke(() =>
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: "Not completed", animation: ToasterAnimation.FadeIn);

                });
                return pdfpath;
            }
        }
        private void btn_printInvoice_Click(object sender, RoutedEventArgs e)
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
                clearVendor();
                btn_updateVendor.IsEnabled = false;
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void clearVendor()
        {
            cb_vendor.SelectedIndex = -1;
            cb_vendor.Text = "";
            dp_desrvedDate.SelectedDate = null;
            dp_desrvedDate.Text = "";
            tb_invoiceNumber.Text = "";
            dp_invoiceDate.SelectedDate = null;
            dp_invoiceDate.Text = "";
            tb_note.Text = "";
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
        {//payments
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
                        w.invPaid = invoice.paid.Value;
                        w.invTotal = invoice.totalNet.Value;

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
        private async Task navigateInvoice(int index)
        {
            try
            {
                clearNavigation();
                invoice = invoices[index];
                _InvoiceType = invoice.invType;
                _invoiceId = invoice.invoiceId;
                navigateBtnActivate();
                await fillInvoiceInputs(invoice);

                #region title text
                if (_InvoiceType == "pw" || _InvoiceType == "p")
                {
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
                    txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;

                }
                else if (_InvoiceType == "pb" || _InvoiceType == "pbw")
                {
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trReturnedInvoice");
                    txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;

                }
                else if (_InvoiceType == "pd")
                {
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");
                    txt_payInvoice.Foreground = Application.Current.Resources["MainColorBlue"] as SolidColorBrush;

                }
                else if (_InvoiceType == "pbd")
                {
                    txt_payInvoice.Text = MainWindow.resourcemanager.GetString("trDraftBounceBill");
                    txt_payInvoice.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;

                }

                #endregion
                if (_InvoiceType == "pw" || _InvoiceType == "p" || _InvoiceType == "pb" || _InvoiceType == "pbw")
                    refreshPaymentsNotification(invoice.invoiceId);
            }
            catch (Exception ex)
            {
            }
        }
        private async void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
                index++;
                await navigateInvoice(index);
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
        private async void Btn_previous_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                int index = invoices.IndexOf(invoices.Where(x => x.invoiceId == _invoiceId).FirstOrDefault());
                index--;
                //clearInvoice();
                await navigateInvoice(index);
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

        private async void Btn_shortageInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                await saveBeforeTransfer();
                if (invoice.invoiceId != 0)
                    clearInvoice();

                _isLack = true;
                await buildShortageInvoiceDetails();
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
                    //OrderId = (int)itemT.invoiceId,
                    Price = decimal.Parse(SectionData.DecTostring((decimal)itemT.price)),
                    Total = total,
                    invType = invoice.invType,
                });
            }

            tb_barcode.Focus();

            refrishBillDetails();
            dg_billDetails.Columns[5].IsReadOnly = false; //make price read only
            dg_billDetails.Columns[4].IsReadOnly = false; //make quantity read only
            dg_billDetails.Columns[3].IsReadOnly = false; //make quantity read only
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

        private void Dg_billDetails_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _IsFocused = true;
        }

        private async void Btn_printCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                int result = 0;

                if (invoice.invoiceId > 0)
                {
                    result = await invoiceModel.updateprintstat(invoice.invoiceId, -1, true, true);


                    if (result > 0)
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }

                }
                else
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trChooseInvoiceToolTip"), animation: ToasterAnimation.FadeIn);
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
    }
}

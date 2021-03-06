using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using POS.View.sectionData.Charts;
using System.Windows.Resources;

namespace POS.View.accounts
{
    /// <summary>
    /// Interaction logic for uc_receivedAccounts.xaml
    /// </summary>
    public partial class uc_receivedAccounts : UserControl
    {
        private static uc_receivedAccounts _instance;
        CashTransfer cashModel = new CashTransfer();
        CashTransfer cashtrans = new CashTransfer();
        Bonds bondModel = new Bonds();
        Card cardModel = new Card();
        Agent agentModel = new Agent();
        User userModel = new User();
        ShippingCompanies shCompanyModel = new ShippingCompanies();
        Pos posModel = new Pos();
        IEnumerable<Agent> agents;
        IEnumerable<User> users;
        IEnumerable<ShippingCompanies> shCompanies;
        IEnumerable<Card> cards;
        IEnumerable<CashTransfer> cashesQuery;
        IEnumerable<CashTransfer> cashesQueryExcel;
        IEnumerable<CashTransfer> cashes;
        static private int _SelectedCard = -1;

        public List<Invoice> invoicesLst = new List<Invoice>();
        //print
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        string searchText = "";
        string createPermission = "received_create";
        string reportsPermission = "received_reports";

        List<Button> cardBtnList = new List<Button>();
        List<Ellipse> cardEllipseList = new List<Ellipse>();
        bool hasProcessNum = false;

        ImageBrush brush = new ImageBrush();
        public static uc_receivedAccounts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_receivedAccounts();
                return _instance;
            }
        }
        public uc_receivedAccounts()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }
        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {//confirm

        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);

                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_ucReceivedAccounts.FlowDirection = FlowDirection.LeftToRight;

                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_ucReceivedAccounts.FlowDirection = FlowDirection.RightToLeft;

                }
                translate();
                #endregion

                #region Style Date
                /////////////////////////////////////////////////////////////
                SectionData.defaultDatePickerStyle(dp_startSearchDate);
                SectionData.defaultDatePickerStyle(dp_endSearchDate);
                /////////////////////////////////////////////////////////////
                #endregion

                dp_endSearchDate.SelectedDate = DateTime.Now;
                dp_startSearchDate.SelectedDate = DateTime.Now;

                btn_invoices.IsEnabled = false;

                dp_startSearchDate.SelectedDateChanged += this.dp_SelectedStartDateChanged;
                dp_endSearchDate.SelectedDateChanged += this.dp_SelectedEndDateChanged;

                #region fill deposit from combo
                var depositlist = new[] {
                new { Text = MainWindow.resourcemanager.GetString("trVendor")                 , Value = "v" },
                new { Text = MainWindow.resourcemanager.GetString("trCustomer")               , Value = "c" },
                new { Text = MainWindow.resourcemanager.GetString("trUser")                   , Value = "u" },
                new { Text = MainWindow.resourcemanager.GetString("trAdministrativeDeposit")  , Value = "m" },
                new { Text = MainWindow.resourcemanager.GetString("trShippingCompanies")      , Value = "sh" }
                 };
                cb_depositFrom.DisplayMemberPath = "Text";
                cb_depositFrom.SelectedValuePath = "Value";
                cb_depositFrom.ItemsSource = depositlist;
                #endregion

                await fillVendors();

                await fillCustomers();

                await fillUsers();

                await fillShippingCompanies();

                #region fill process type
                var typelist = new[] {
                new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
                new { Text = MainWindow.resourcemanager.GetString("trDocument")   , Value = "doc" },
                new { Text = MainWindow.resourcemanager.GetString("trCheque")     , Value = "cheque" },
                new { Text = MainWindow.resourcemanager.GetString("trAnotherPaymentMethods") , Value = "card" },
                 };
                cb_paymentProcessType.DisplayMemberPath = "Text";
                cb_paymentProcessType.SelectedValuePath = "Value";
                cb_paymentProcessType.ItemsSource = typelist;
                #endregion

                #region fill card combo
                try
                {
                    cards = await cardModel.GetAll();
                    InitializeCardsPic(cards);
                }
                catch { }
                #endregion

                btn_image.IsEnabled = false;

                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void InitializeCardsPic(IEnumerable<Card> cards)
        {
            #region cardImageLoad
            dkp_cards.Children.Clear();
            int userCount = 0;
            foreach (var item in cards)
            {
                #region Button
                Button button = new Button();
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

        void card_Click(object sender, RoutedEventArgs e)
        {
            SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
            SectionData.clearTextBlockValidate(txt_card, p_errorCard);

            var button = sender as Button;
            _SelectedCard = int.Parse(button.Tag.ToString());

            Card card = button.DataContext as Card;

            txt_card.Text = card.name;

            if (card.hasProcessNum.Value)
            {
                tb_docNumCard.Visibility = Visibility.Visible;
                hasProcessNum = true;
            }
            else
            {
                tb_docNumCard.Visibility = Visibility.Collapsed;
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
        private void clearImg(Ellipse ellipse)
        {
            Uri resourceUri = new Uri("pic/no-image-icon-90x90.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            ellipse.Fill = brush;
        }
        private async void dp_SelectedEndDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);

                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void dp_SelectedStartDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);

                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void translate()
        {
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trTransaferDetails");
            txt_received.Text = MainWindow.resourcemanager.GetString("trReceived");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositFrom, MainWindow.resourcemanager.GetString("trDepositFromHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorV, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorC, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorU, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositorSh, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNum, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_docDate, MainWindow.resourcemanager.GetString("trDocDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNumCheque, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNumCard, MainWindow.resourcemanager.GetString("trProcessNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_docDateCheque, MainWindow.resourcemanager.GetString("trDocDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            dg_receivedAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_receivedAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trDepositor");
            dg_receivedAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            dg_receivedAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trDate");
            dg_receivedAccounts.Columns[4].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            tt_startDate.Content = MainWindow.resourcemanager.GetString("trStartDate");
            tt_endDate.Content = MainWindow.resourcemanager.GetString("trEndDate");

            btn_add.Content = MainWindow.resourcemanager.GetString("trSave");
            btn_image.Content = MainWindow.resourcemanager.GetString("trImage");
            btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            btn_printInvoice.Content = MainWindow.resourcemanager.GetString("trPrint");
            btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdfBtn");

        }
        private void Dg_receivedAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);

                #region clear validate
                SectionData.clearComboBoxValidate(cb_depositFrom, p_errorDepositFrom);
                SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                SectionData.clearComboBoxValidate(cb_depositorSh, p_errordepositor);
                SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
                SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                TextBox tbDocDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                SectionData.clearValidate(tb_docNum, p_errorDocNum);
                SectionData.clearValidate(tb_docNumCard , p_errorDocCard);
                SectionData.clearValidate(tb_docNumCheque , p_errorDocNumCheque);
                SectionData.clearValidate(tb_cash, p_errorCash);
                #endregion

                if (dg_receivedAccounts.SelectedIndex != -1)
            {
                cashtrans = dg_receivedAccounts.SelectedItem as CashTransfer;
                this.DataContext = cashtrans;
                if (cashtrans != null)
                {
                    btn_image.IsEnabled = true;
                    ///////////////////////////
                    btn_add.IsEnabled = false;
                    cb_depositFrom.IsEnabled = false;
                    cb_depositorV.IsEnabled = false;
                    cb_depositorC.IsEnabled = false;
                    cb_depositorU.IsEnabled = false;
                    cb_depositorSh.IsEnabled = false;
                    btn_invoices.IsEnabled = false;
                    cb_paymentProcessType.IsEnabled = false;
                    gd_card.IsEnabled = false;
                    tb_docNum.IsEnabled = false;
                    dp_docDate.IsEnabled = false;
                    tb_docNumCheque.IsEnabled = false;
                    tb_docNumCard.IsEnabled = false;
                    dp_docDateCheque.IsEnabled = false;
                    tb_cash.IsEnabled = false;
                    tb_note.IsEnabled = false;
                    //////////////////////////
                    tb_transNum.Text = cashtrans.transNum;

                    tb_cash.Text = SectionData.DecTostring(cashtrans.cash);

                    cb_depositFrom.SelectedValue = cashtrans.side;

                    #region depositor
                    switch (cb_depositFrom.SelectedValue.ToString())
                    {
                        case "v":
                            cb_depositorV.SelectedIndex = -1;
                            try { cb_depositorV.SelectedValue = cashtrans.agentId.Value; }
                            catch { }
                            cb_depositorC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                            cb_depositorU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                            cb_depositorSh.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorSh, p_errordepositor);
                            break;
                        case "c":
                            cb_depositorC.SelectedIndex = -1;
                            try { cb_depositorC.SelectedValue = cashtrans.agentId.Value; }
                            catch { }
                            cb_depositorV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                            cb_depositorU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                            cb_depositorSh.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorSh, p_errordepositor);
                            break;
                        case "u":
                            cb_depositorU.SelectedIndex = -1;
                            try { cb_depositorU.SelectedValue = cashtrans.userId.Value; }
                            catch { }
                            cb_depositorV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                            cb_depositorC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                            cb_depositorSh.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorSh, p_errordepositor);
                            break;
                        case "sh":
                            cb_depositorSh.SelectedIndex = -1;
                            try { cb_depositorSh.SelectedValue = cashtrans.shippingCompanyId.Value; }
                            catch { }
                            cb_depositorV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                            cb_depositorC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                            cb_depositorU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                            break;
                        case "m":
                            cb_depositorV.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                            cb_depositorC.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                            cb_depositorU.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                            cb_depositorSh.Visibility = Visibility.Collapsed; SectionData.clearComboBoxValidate(cb_depositorSh, p_errordepositor);
                            break;
                        }
                    #endregion

                    cb_paymentProcessType.SelectedValue = cashtrans.processType;

                    if (cashtrans.cardId != null)
                    _SelectedCard = (int) cashtrans.cardId;
                }
            }
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);

                await Search();

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        async Task Search()
        {
            try
            {
                if (cashes is null)
                    await RefreshCashesList();
                if (chb_all.IsChecked == false)
                {
                    searchText = tb_search.Text.ToLower();
                    cashesQuery = cashes.Where(s => (s.transNum.ToLower().Contains(searchText)
                    || s.cash.ToString().ToLower().Contains(searchText)
                    )
                    && (s.side == "v" || s.side == "c" || s.side == "u" || s.side == "m" || s.side == "sh")
                    && s.transType == "d"
                    && s.processType != "inv"
                    && s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
                    && s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
                    );
                }
                else
                {
                    searchText = tb_search.Text.ToLower();
                    cashesQuery = cashes.Where(s => (s.transNum.ToLower().Contains(searchText)
                    || s.cash.ToString().ToLower().Contains(searchText)
                    )
                    && (s.side == "v" || s.side == "c" || s.side == "u" || s.side == "m" || s.side == "sh")
                    && s.transType == "d"
                    && s.processType != "inv"
                    );
                }


                cashesQueryExcel = cashesQuery.ToList();
                RefreshCashView();
            }
            catch { }
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);
                //  string s = "0", s1 = "";
                int s = 0;
                int s1 = 0;
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (MainWindow.posLogIn.boxState == "o") // box is open
                    {
                        #region validate

                        //chk empty cash
                        SectionData.validateEmptyTextBox(tb_cash, p_errorCash, tt_errorCash, "trEmptyCashToolTip");

                        //chk empty doc num
                        if (grid_doc.IsVisible)
                        {
                            TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);

                            SectionData.validateEmptyTextBox(tb_docNum, p_errorDocNum, tt_errorDocNum, "trEmptyDocNumToolTip");
                            SectionData.validateEmptyTextBox(dpDate, p_errorDocDate, tt_errorDocDate, "trEmptyDocDateToolTip");
                        }
                        else
                        {
                        }

                        //chk empty cheque num
                        if (grid_cheque.IsVisible)
                        {
                            SectionData.validateEmptyTextBox(tb_docNumCheque, p_errorDocNumCheque, tt_errorDocNumCheque, "trEmptyDocNumToolTip");
                        }
                        else
                        {
                        }
                        ////chk empty process num
                        //if (tb_docNumCard.IsVisible)
                        //{
                        //    SectionData.validateEmptyTextBox(tb_docNumCard, p_errorDocCard, tt_docNumCard, "trEmptyProcessNumToolTip");
                        //}
                        //else
                        //{
                        //    SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                        //}
                        //chk empty deposit from
                        SectionData.validateEmptyComboBox(cb_depositFrom, p_errorDepositFrom, tt_errorDepositFrom, "trErrorEmptyDepositFromToolTip");

                        //chk empty depositor
                        if (cb_depositorV.IsVisible)
                            SectionData.validateEmptyComboBox(cb_depositorV, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                        else
                            SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                        if (cb_depositorC.IsVisible)
                            SectionData.validateEmptyComboBox(cb_depositorC, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                        else
                            SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                        if (cb_depositorU.IsVisible)
                            SectionData.validateEmptyComboBox(cb_depositorU, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                        else
                            SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                        if (cb_depositorSh.IsVisible)
                            SectionData.validateEmptyComboBox(cb_depositorSh, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                        else
                            SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);

                        //chk empty payment type
                        SectionData.validateEmptyComboBox(cb_paymentProcessType, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

                        //chk empty card 
                        if (gd_card.IsVisible)
                        {
                            if (txt_card.Text.Equals(""))
                                SectionData.validateEmptyTextBlock(txt_card, p_errorCard, tt_errorCard, "trSelectCreditCard");
                            else
                            {
                                SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                                if (hasProcessNum)
                                    SectionData.validateEmptyTextBox(tb_docNumCard, p_errorDocCard, tt_errorDocCard, "trEmptyDocNumToolTip");
                                else
                                    SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                            }
                        }

                        #endregion

                        #region save
                        if ((!tb_cash.Text.Equals("")) && (!cb_depositFrom.Text.Equals("")) && (!cb_paymentProcessType.Text.Equals("")) &&
                        (((cb_depositorV.IsVisible) && (!cb_depositorV.Text.Equals(""))) || (!cb_depositorV.IsVisible)) &&
                        (((cb_depositorC.IsVisible) && (!cb_depositorC.Text.Equals(""))) || (!cb_depositorC.IsVisible)) &&
                        (((cb_depositorU.IsVisible) && (!cb_depositorU.Text.Equals(""))) || (!cb_depositorU.IsVisible)) &&
                        (((cb_depositorSh.IsVisible) && (!cb_depositorSh.Text.Equals(""))) || (!cb_depositorSh.IsVisible)) &&
                        (((grid_cheque.IsVisible) && (!tb_docNumCheque.Text.Equals(""))) || (!grid_cheque.IsVisible)) &&
                        (((grid_doc.IsVisible) && (!dp_docDate.Text.Equals("")) && (!tb_docNum.Text.Equals(""))) || (!dp_docDate.IsVisible)) &&
                        (((gd_card.IsVisible) && (!txt_card.Text.Equals("")) && ((!tb_docNumCard.Text.Equals("")) || (!tb_docNumCard.IsVisible))) || (!gd_card.IsVisible)) )
                        {
                            string depositor = cb_depositFrom.SelectedValue.ToString();
                            int agentid = 0;

                            CashTransfer cash = new CashTransfer();

                            cash.transType = "d";
                            cash.posId = MainWindow.posID.Value;
                            cash.transNum = await cashModel.generateCashNumber(cash.transType + cb_depositFrom.SelectedValue.ToString());
                            cash.cash = decimal.Parse(tb_cash.Text);
                            cash.notes = tb_note.Text;
                            cash.createUserId = MainWindow.userID;
                            cash.side = cb_depositFrom.SelectedValue.ToString();
                            cash.processType = cb_paymentProcessType.SelectedValue.ToString();

                            if (cb_depositorV.IsVisible)
                            { cash.agentId = Convert.ToInt32(cb_depositorV.SelectedValue); agentid = Convert.ToInt32(cb_depositorV.SelectedValue); }

                            if (cb_depositorC.IsVisible)
                            {
                                cash.agentId = Convert.ToInt32(cb_depositorC.SelectedValue);
                                agentid = Convert.ToInt32(cb_depositorC.SelectedValue);
                            }

                            if (cb_depositorU.IsVisible)
                                cash.userId = Convert.ToInt32(cb_depositorU.SelectedValue);

                            if (cb_depositorSh.IsVisible)
                                cash.shippingCompanyId = Convert.ToInt32(cb_depositorSh.SelectedValue);

                            if (cb_paymentProcessType.SelectedValue.ToString().Equals("card"))
                            {
                                cash.cardId = _SelectedCard;
                                cash.docNum = tb_docNumCard.Text;
                            }

                            if (cb_paymentProcessType.SelectedValue.ToString().Equals("doc"))
                                cash.docNum = tb_docNum.Text;

                            if (cb_paymentProcessType.SelectedValue.ToString().Equals("cheque"))
                                cash.docNum = tb_docNumCheque.Text;

                            if (cb_paymentProcessType.SelectedValue.ToString().Equals("doc"))
                            {
                                int res = await saveBond(cash.docNum, cash.cash.Value, dp_docDate.SelectedDate.Value, "d");
                                cash.bondId = res;
                            }

                            if (cb_depositorV.IsVisible || cb_depositorC.IsVisible)
                            {
                                if (tb_cash.IsReadOnly)
                                    s1 = await cashModel.PayListOfInvoices(cash.agentId.Value, invoicesLst, "feed", cash);
                                else
                                    s1 = await cashModel.PayByAmmount(cash.agentId.Value, decimal.Parse(tb_cash.Text), "feed", cash);
                            }
                            else if (cb_depositorU.IsVisible)
                            {
                                if (tb_cash.IsReadOnly)
                                    s1 = await cashModel.PayUserListOfInvoices(cash.userId.Value, invoicesLst, "feed", cash);
                                else
                                    s1 = await cashModel.PayUserByAmmount(cash.userId.Value, decimal.Parse(tb_cash.Text), "feed", cash);
                            }
                            else if (cb_depositorSh.IsVisible)
                            {
                                if (tb_cash.IsReadOnly)
                                    s1 = await cashModel.PayShippingCompanyListOfInvoices(cash.shippingCompanyId.Value, invoicesLst, "feed", cash);
                                else
                                    s1 = await cashModel.payShippingCompanyByAmount(cash.shippingCompanyId.Value, decimal.Parse(tb_cash.Text), "feed", cash);
                            }
                            else
                                s = await cashModel.Save(cash);

                            if ((!s.Equals("0")) || (!s1.Equals("")) || (s1.Equals("-1")))
                            {
                                if (cb_paymentProcessType.SelectedValue.ToString().Equals("cash"))
                                {
                                    await calcBalance(cash.cash.Value, depositor, agentid);
                                    await MainWindow.refreshBalance();
                                }

                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                                Btn_clear_Click(null, null);

                                await RefreshCashesList();
                                Tb_search_TextChanged(null, null);
                                await MainWindow.refreshBalance();
                            }
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                        }
                        #endregion
                    }
                    else //box is closed
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trBoxIsClosed"), animation: ToasterAnimation.FadeIn);
                    }

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);

                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async Task<int> saveBond(string num, decimal ammount, Nullable<DateTime> date, string type)
        {
            Bonds bond = new Bonds();
            bond.number = num;
            bond.amount = ammount;
            bond.deserveDate = date;
            bond.type = type;
            bond.isRecieved = 0;
            bond.createUserId = MainWindow.userID.Value;

           int s = await bondModel.Save(bond);

            return s;
        }

        private async Task calcBalance(decimal ammount, string depositor, int agentid)
        {
            int s = 0;
            //increase pos balance
            Pos pos = await posModel.getById(MainWindow.posID.Value);
            pos.balance += ammount;

            s = await pos.save(pos);
        }

        private async Task calcUserBalance(float value, int userId)
        {//balance for user
            User user = await userModel.getUserById(userId);

            if (user.balanceType == 0)
                user.balance += value;
            else
            {
                if (value > user.balance)
                {
                    value -= user.balance;
                    user.balance = value;
                    user.balanceType = 0;
                }
                else
                    user.balance -= value;
            }

            await userModel.save(user);

        }

        private async Task calcShippingComBalance(decimal value, int shippingcompanyId)
        {//balance for shipping company
            ShippingCompanies shCom = await shCompanyModel.GetByID(shippingcompanyId);

            if (shCom.balanceType == 0)
                shCom.balance += value;
            else
            {
                if (value > shCom.balance)
                {
                    value -= shCom.balance;
                    shCom.balance = value;
                    shCom.balanceType = 0;
                }
                else
                    shCom.balance -= value;
            }
         await shCompanyModel.save(shCom);

        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);
                /////////////////////////
                cashtrans = new CashTransfer();
                btn_add.IsEnabled = true;
                btn_invoices.Visibility = Visibility.Collapsed;
                cb_depositFrom.IsEnabled = true;
                cb_depositorV.IsEnabled = true;
                cb_depositorC.IsEnabled = true;
                cb_depositorU.IsEnabled = true;
                cb_depositorSh.IsEnabled = true;
                btn_invoices.IsEnabled = true;
                cb_paymentProcessType.IsEnabled = true;
                gd_card.IsEnabled = true;
                tb_docNum.IsEnabled = true;
                dp_docDate.IsEnabled = true;
                tb_docNumCheque.IsEnabled = true;
                tb_docNumCard.IsEnabled = true;
                dp_docDateCheque.IsEnabled = true;
                tb_cash.IsEnabled = true;
                tb_note.IsEnabled = true;

                btn_image.IsEnabled = false;
                /////////////////////////
                ///
                if (grid_doc.IsVisible)
                {
                    TextBox tbDocDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                    SectionData.clearValidate(tbDocDate, p_errorDocDate);
                    dp_docDate.SelectedDate = null;
                    tb_docNum.Clear();
                    SectionData.clearValidate(tb_docNum, p_errorDocNum);
                }
                if (grid_cheque.IsVisible)
                {
                    tb_docNumCheque.Clear();
                    dp_docDateCheque.SelectedDate = null;
                    SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                }
                cb_depositFrom.SelectedIndex = -1;
                cb_depositorV.Visibility = Visibility.Collapsed;
                cb_depositorC.Visibility = Visibility.Collapsed;
                cb_depositorU.Visibility = Visibility.Collapsed;
                cb_depositorSh.Visibility = Visibility.Collapsed;
                gd_card.Visibility = Visibility.Collapsed;
                _SelectedCard = -1;
                //p_errorDocNumCheque.Visibility = Visibility.Collapsed;
                cb_paymentProcessType.SelectedIndex = -1;
                tb_cash.Clear();
                tb_note.Clear();
                tb_docNumCard.Clear();
                tb_docNum.Clear();
                tb_docNumCheque.Clear();
                tb_docNumCard.Clear();
                tb_transNum.Text = "";
                tb_cash.IsReadOnly = false;
                grid_doc.Visibility = Visibility.Collapsed;
                tb_docNumCard.Visibility = Visibility.Collapsed;
                grid_cheque.Visibility = Visibility.Collapsed;
                tb_docNumCheque.Visibility = Visibility.Collapsed;
                SectionData.clearValidate(tb_cash, p_errorCash);
                SectionData.clearComboBoxValidate(cb_depositFrom, p_errorDepositFrom);
                SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                SectionData.clearComboBoxValidate(cb_depositorSh, p_errordepositor);
                SectionData.clearComboBoxValidate(cb_paymentProcessType, p_errorpaymentProcessType);
                SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                SectionData.clearValidate(tb_docNum, p_errorDocNum);
                SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                SectionData.clearValidate(tb_docNumCheque, p_errorDocNumCheque);
                SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                txt_card.Text = "";
                tb_docNumCard.Visibility = Visibility.Collapsed;
                //set border color
                foreach (var el in cardEllipseList)
                {
                    el.Stroke = Application.Current.Resources["MainColorOrange"] as SolidColorBrush;
                }

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//excel
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    //Thread t1 = new Thread(() =>
                    //{
                        BuildReport();
                        this.Dispatcher.Invoke(() =>
                        {
                            saveFileDialog.Filter = "EXCEL|*.xls;";
                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string filepath = saveFileDialog.FileName;
                                LocalReportExtensions.ExportToExcel(rep, filepath);
                            }
                        });


                    //});
                    //t1.Start();
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        void FN_ExportToExcel()
        {
            var QueryExcel = cashesQueryExcel.AsEnumerable().Select(x => new
            {
                TransNum = x.transNum,
                DepositFrom = x.side,
                Depositor = x.agentName,
                OpperationType = x.processType,
                Cash = x.cash
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trDepositFrom");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trDepositor");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trCashTooltip");

            ExportToExcel.Export(DTForExcel);

        }


        private void Btn_image_Click(object sender, RoutedEventArgs e)
        {//image
            try
            {
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    if (cashtrans != null || cashtrans.cashTransId != 0)
                    {
                        wd_uploadImage w = new wd_uploadImage();

                        w.tableName = "cashTransfer";
                        w.tableId = cashtrans.cashTransId;
                        w.docNum = cashtrans.docNum;
                        w.ShowDialog();
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);

                await RefreshCashesList();
                Tb_search_TextChanged(null, null);

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        async Task<IEnumerable<CashTransfer>> RefreshCashesList()
        {
            //cashes = await cashModel.GetCashTransferAsync("d", "all");
            cashes = await cashModel.GetCashBond("d", "all");
            //cashes = cashes.Where(x => x.processType != "balance");
            cashes = cashes.Where(x => (x.processType != "balance")).GroupBy(x => x.transNum).Select(x => new CashTransfer
            {
                cashTransId = x.FirstOrDefault().cashTransId,
                transType = x.FirstOrDefault().transType,
                posId = x.FirstOrDefault().posId,
                userId = x.FirstOrDefault().userId,
                agentId = x.FirstOrDefault().agentId,
                invId = x.FirstOrDefault().invId,
                transNum = x.FirstOrDefault().transNum,
                createDate = x.FirstOrDefault().createDate,
                updateDate = x.FirstOrDefault().updateDate,
                cash = x.Sum(g => g.cash),
                updateUserId = x.FirstOrDefault().updateUserId,
                createUserId = x.FirstOrDefault().createUserId,
                notes = x.FirstOrDefault().notes,
                posIdCreator = x.FirstOrDefault().posIdCreator,
                isConfirm = x.FirstOrDefault().isConfirm,
                cashTransIdSource = x.FirstOrDefault().cashTransIdSource,
                side = x.FirstOrDefault().side,
                docName = x.FirstOrDefault().docName,
                docNum = x.FirstOrDefault().docNum,
                docImage = x.FirstOrDefault().docImage,
                bankId = x.FirstOrDefault().bankId,
                bankName = x.FirstOrDefault().bankName,
                agentName = x.FirstOrDefault().agentName,
                usersName = x.FirstOrDefault().usersName,// side =u
                posName = x.FirstOrDefault().posName,
                posCreatorName = x.FirstOrDefault().posCreatorName,
                processType = x.FirstOrDefault().processType,
                cardId = x.FirstOrDefault().cardId,
                bondId = x.FirstOrDefault().bondId,
                usersLName = x.FirstOrDefault().usersLName,// side =u
                createUserName = x.FirstOrDefault().createUserName,
                createUserLName = x.FirstOrDefault().createUserLName,
                createUserJob = x.FirstOrDefault().createUserJob,
                cardName = x.FirstOrDefault().cardName,
                bondDeserveDate = x.FirstOrDefault().bondDeserveDate,
                bondIsRecieved = x.FirstOrDefault().bondIsRecieved,
                shippingCompanyId = x.FirstOrDefault().shippingCompanyId,
                shippingCompanyName = x.FirstOrDefault().shippingCompanyName


            });
            return cashes;
        }

        void RefreshCashView()
        {
            dg_receivedAccounts.ItemsSource = cashesQuery;
            txt_count.Text = cashesQuery.Count().ToString();
        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_cash")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
                else if ((sender as TextBox).Name == "tb_docNum")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocNum, tt_errorDocNum, "trEmptyDocNumToolTip");
                else if ((sender as TextBox).Name == "tb_docNumCheque")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocNumCheque, tt_errorDocNumCheque, "trEmptyDocNumToolTip");
                else if ((sender as TextBox).Name == "tb_docNumCard")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDocCard, tt_errorDocCard, "trEmptyProcessNumToolTip");
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_depositFrom")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorDepositFrom, tt_errorDepositFrom, "trErrorEmptyDepositFromToolTip");
                else if ((sender as ComboBox).Name == "cb_depositorV")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                else if ((sender as ComboBox).Name == "cb_depositorC")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                else if ((sender as ComboBox).Name == "cb_depositorU")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                else if ((sender as ComboBox).Name == "cb_depositorSh")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errordepositor, tt_errordepositor, "trErrorEmptyDepositorToolTip");
                else if ((sender as ComboBox).Name == "cb_paymentProcessType")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                else if ((sender as ComboBox).Name == "cb_card")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
            }
            else if (name == "DatePicker")
            {
                if ((sender as DatePicker).Name == "dp_docDate")
                    SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorDocDate, tt_errorDocDate, "trEmptyDocDateToolTip");
                if ((sender as DatePicker).Name == "dp_docDateCheque")
                    SectionData.validateEmptyDatePicker((DatePicker)sender, p_errorDocDateCheque, tt_errorDocDateCheque, "trEmptyDocDateToolTip");
            }
        }

        private void PreventSpaces(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_docNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only int
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Tb_cash_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only decimal
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
                var txb = sender as TextBox;
                if ((sender as TextBox).Name == "tb_cash")
                    SectionData.InputJustNumber(ref txb);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }

        }

        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//type selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);

                switch (cb_paymentProcessType.SelectedIndex)
                {
                    case 0://cash
                        grid_doc.Visibility = Visibility.Collapsed;
                        grid_cheque.Visibility = Visibility.Collapsed;
                        tb_docNumCheque.Visibility = Visibility.Collapsed;
                        gd_card.Visibility = Visibility.Collapsed;
                        tb_docNumCard.Visibility = Visibility.Collapsed;
                         SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                        SectionData.clearValidate(tb_docNum, p_errorDocNum);
                        SectionData.clearValidate(tb_docNumCheque, p_errorDocNum);
                        SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        if (grid_doc.IsVisible)
                        {
                            TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                            SectionData.clearValidate(dpDate, p_errorDocDate);
                        }
                        if (grid_cheque.IsVisible)
                        {
                            TextBox dpDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);
                            SectionData.clearValidate(dpDateCheque, p_errorDocNumCheque);
                        }
                        _SelectedCard = -1;
                        break;

                    case 1://doc
                        grid_doc.Visibility = Visibility.Visible;
                        grid_cheque.Visibility = Visibility.Collapsed;
                        tb_docNumCheque.Visibility = Visibility.Collapsed;
                        gd_card.Visibility = Visibility.Collapsed;
                        tb_docNumCard.Visibility = Visibility.Collapsed;
                        SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                        SectionData.clearValidate(tb_docNumCheque, p_errorDocNum);
                        SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        if (grid_cheque.IsVisible)
                        {
                            TextBox dpDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);
                            SectionData.clearValidate(dpDateCheque, p_errorDocNumCheque);
                        }
                        _SelectedCard = -1;
                        break;

                    case 2://cheque
                        grid_doc.Visibility = Visibility.Collapsed;
                        grid_cheque.Visibility = Visibility.Visible;
                        tb_docNumCheque.Visibility = Visibility.Visible;

                        gd_card.Visibility = Visibility.Collapsed;
                        tb_docNumCard.Visibility = Visibility.Collapsed;
                        SectionData.clearValidate(tb_docNumCard, p_errorDocCard);
                        SectionData.clearValidate(tb_docNum, p_errorDocNum);
                        SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        if (grid_doc.IsVisible)
                        {
                            TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                            SectionData.clearValidate(dpDate, p_errorDocDate);
                        }
                        _SelectedCard = -1;
                        break;

                    case 3://card
                        grid_doc.Visibility = Visibility.Collapsed;
                        grid_cheque.Visibility = Visibility.Collapsed;
                        tb_docNumCheque.Visibility = Visibility.Collapsed;

                        gd_card.Visibility = Visibility.Visible;
                        if (cashtrans.cardId != null)
                        {
                            Button btn = cardBtnList.Where(c => (int)c.Tag == cashtrans.cardId.Value).FirstOrDefault();
                            card_Click(btn, null);
                        }
                        //tb_docNumCard.Visibility = Visibility.Visible;
                        SectionData.clearValidate(tb_docNum, p_errorDocNum);
                        SectionData.clearValidate(tb_docNumCheque, p_errorDocNum);
                        SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        if (grid_doc.IsVisible)
                        {
                            TextBox dpDate = (TextBox)dp_docDate.Template.FindName("PART_TextBox", dp_docDate);
                            SectionData.clearValidate(dpDate, p_errorDocDate);
                        }
                        if (grid_cheque.IsVisible)
                        {
                            TextBox dpDateCheque = (TextBox)dp_docDateCheque.Template.FindName("PART_TextBox", dp_docDateCheque);
                            SectionData.clearValidate(dpDateCheque, p_errorDocNumCheque);
                        }
                        break;
                }
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_depositFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//deposit selection
         //try
         //{
         //    if (sender != null)
         //        SectionData.StartAwait(grid_ucReceivedAccounts);

            btn_invoices.IsEnabled = false;
            switch (cb_depositFrom.SelectedIndex)
            {
                case 0://vendor
                    cb_depositorV.SelectedIndex = -1;
                    cb_depositorV.Visibility = Visibility.Visible;
                    cb_depositorC.Visibility = Visibility.Collapsed;
                    btn_invoices.Visibility = Visibility.Visible;
                    cb_depositorU.Visibility = Visibility.Collapsed;
                    cb_depositorSh.Visibility = Visibility.Collapsed;
                    break;
                case 1://customer
                    cb_depositorC.SelectedIndex = -1;
                    cb_depositorV.Visibility = Visibility.Collapsed;
                    cb_depositorC.Visibility = Visibility.Visible;
                    btn_invoices.Visibility = Visibility.Visible;
                    cb_depositorU.Visibility = Visibility.Collapsed;
                    cb_depositorSh.Visibility = Visibility.Collapsed;
                    break;
                case 2://user
                    cb_depositorU.SelectedIndex = -1;
                    cb_depositorV.Visibility = Visibility.Collapsed;
                    cb_depositorC.Visibility = Visibility.Collapsed;
                    btn_invoices.Visibility = Visibility.Visible;
                    cb_depositorU.Visibility = Visibility.Visible;
                    cb_depositorSh.Visibility = Visibility.Collapsed;
                    break;
                case 3://other
                    cb_depositorV.Visibility = Visibility.Collapsed;
                    cb_depositorC.Visibility = Visibility.Collapsed;
                    btn_invoices.Visibility = Visibility.Collapsed;
                    cb_depositorU.Visibility = Visibility.Collapsed;
                    cb_depositorSh.Visibility = Visibility.Collapsed;
                    SectionData.clearComboBoxValidate(cb_depositorV, p_errordepositor);
                    SectionData.clearComboBoxValidate(cb_depositorC, p_errordepositor);
                    SectionData.clearComboBoxValidate(cb_depositorU, p_errordepositor);
                    SectionData.clearComboBoxValidate(cb_depositorSh, p_errordepositor);
                    cb_depositorV.Text = "";
                    cb_depositorC.Text = "";
                    cb_depositorU.Text = "";
                    cb_depositorSh.Text = "";
                    break;
                case 4://shipping company
                    cb_depositorSh.SelectedIndex = -1;
                    cb_depositorU.SelectedIndex = -1;
                    cb_depositorV.Visibility = Visibility.Collapsed;
                    cb_depositorC.Visibility = Visibility.Collapsed;
                    btn_invoices.Visibility = Visibility.Visible;
                    cb_depositorU.Visibility = Visibility.Collapsed;
                    cb_depositorSh.Visibility = Visibility.Visible;
                    break;
            }

            //    if (sender != null)
            //        SectionData.EndAwait(grid_ucReceivedAccounts);
            //}
            //catch (Exception ex)
            //{
            //    if (sender != null)
            //        SectionData.EndAwait(grid_ucReceivedAccounts);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }

        private async Task fillVendors()
        {
            try
            {
                //agents = await agentModel.GetAgentsActive("v");
                agents = await agentModel.GetActiveForAccount("v" , "d");

                cb_depositorV.ItemsSource = agents;
                cb_depositorV.DisplayMemberPath = "name";
                cb_depositorV.SelectedValuePath = "agentId";
            }
            catch { }
        }

        private async Task fillCustomers()
        {
            try
            {
                //agents = await agentModel.GetAgentsActive("c");
                agents = await agentModel.GetActiveForAccount("c" , "d");

                cb_depositorC.ItemsSource = agents;
                cb_depositorC.DisplayMemberPath = "name";
                cb_depositorC.SelectedValuePath = "agentId";
            }
            catch { }
        }

        private async Task fillUsers()
        {
            try
            {
                //users = await userModel.GetUsersActive();
                users = await userModel.GetActiveForAccount("d");

                cb_depositorU.ItemsSource = users;
                cb_depositorU.DisplayMemberPath = "username";
                cb_depositorU.SelectedValuePath = "userId";
            }
            catch { }
        }

        private async Task fillShippingCompanies()
        {
            try
            {
                //shCompanies = await shCompanyModel.Get();
                shCompanies = await shCompanyModel.GetForAccount("d");
                shCompanies = shCompanies.Where(sh => sh.deliveryType != "local");
                cb_depositorSh.ItemsSource = shCompanies;
                cb_depositorSh.DisplayMemberPath = "name";
                cb_depositorSh.SelectedValuePath = "shippingCompanyId";
            }
            catch { }
        }

        private void Btn_printInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);

                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {

                    if (cashtrans.cashTransId > 0)
                    {
                        BuildvoucherReport();
                        LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));

                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void Btn_invoices_Click(object sender, RoutedEventArgs e)
        {//invoices
            try
            {
                invoicesLst.Clear();

                Window.GetWindow(this).Opacity = 0.2;
                wd_invoicesList w = new wd_invoicesList();

                w.agentId = 0; w.userId = 0; w.shippingCompanyId = 0;

                if (cb_depositFrom.SelectedValue.ToString() == "v")
                    w.agentId = Convert.ToInt32(cb_depositorV.SelectedValue);
                else if (cb_depositFrom.SelectedValue.ToString() == "c")
                    w.agentId = Convert.ToInt32(cb_depositorC.SelectedValue);
                else if (cb_depositFrom.SelectedValue.ToString() == "u")
                    w.userId = Convert.ToInt32(cb_depositorU.SelectedValue);
                else if (cb_depositFrom.SelectedValue.ToString() == "sh")
                    w.shippingCompanyId = Convert.ToInt32(cb_depositorSh.SelectedValue);

                w.invType = "feed";

                w.ShowDialog();
                if (w.isActive)
                {
                    tb_cash.Text = SectionData.DecTostring(w.sum);
                    tb_cash.IsReadOnly = true;
                    invoicesLst.AddRange(w.selectedInvoices);
                }

                Window.GetWindow(this).Opacity = 1;
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        public void BuildvoucherReport()
        {
            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {

                if (MainWindow.docPapersize == "A4")
                {
                    addpath = @"\Reports\Account\Ar\ArReciveReportA4.rdlc";
                }
                else
                {
                    addpath = @"\Reports\Account\Ar\ArReciveReport.rdlc";
                }
            }
            else
            {
                if (MainWindow.docPapersize == "A4")
                {
                    addpath = @"\Reports\Account\En\ReciveReportA4.rdlc";
                }
                else
                {
                    addpath = @"\Reports\Account\En\ReciveReport.rdlc";
                }


            }

            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
            rep.ReportPath = reppath;
            rep.DataSources.Clear();
            rep.EnableExternalImages = true;
            rep.SetParameters(reportclass.fillPayReport(cashtrans));

            rep.Refresh();
        }
        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;

                    string pdfpath;
                    pdfpath = @"\Thumb\report\temp.pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                    //
                    if (cashtrans.cashTransId > 0)
                    {
                        BuildvoucherReport();

                        LocalReportExtensions.ExportToPDF(rep, pdfpath);
                        wd_previewPdf w = new wd_previewPdf();
                        w.pdfPath = pdfpath;
                        if (!string.IsNullOrEmpty(w.pdfPath))
                        {
                            w.ShowDialog();

                            w.wb_pdfWebViewer.Dispose();

                        }
                        else
                            Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                        Window.GetWindow(this).Opacity = 1;
                    }

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);
                if (MainWindow.groupObject.HasPermissionAction(createPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {

                    if (cashtrans.cashTransId > 0)
                    {
                        BuildvoucherReport();

                        saveFileDialog.Filter = "PDF|*.pdf;";

                        if (saveFileDialog.ShowDialog() == true)
                        {
                            string filepath = saveFileDialog.FileName;

                            LocalReportExtensions.ExportToPDF(rep, filepath);

                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_depositorV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((cb_depositorV.SelectedIndex != -1) && (cb_depositorV.IsEnabled))
                    btn_invoices.IsEnabled = true;
                else
                    btn_invoices.IsEnabled = false;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_depositorC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((cb_depositorC.SelectedIndex != -1) && (cb_depositorC.IsEnabled))
                    btn_invoices.IsEnabled = true;
                else
                    btn_invoices.IsEnabled = false;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_depositorU_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cb_depositorU.SelectedIndex != -1) && (cb_depositorU.IsEnabled))
                btn_invoices.IsEnabled = true;
            else
                btn_invoices.IsEnabled = false;
        }

        private void Cb_depositorSh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((cb_depositorSh.SelectedIndex != -1) && (cb_depositorSh.IsEnabled))
                    btn_invoices.IsEnabled = true;
                else
                    btn_invoices.IsEnabled = false;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void Tb_EnglishDigit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only english and digits
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;

        }
        public void BuildReport()
        {
            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Account\Ar\ArReceiptAccReport.rdlc";
            }
            else addpath = @"\Reports\Account\En\ReceiptAccReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            ReportCls.checkLang();

            clsReports.receivedAccReport(cashesQuery, rep, reppath, paramarr);
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);
            clsReports.bankdg(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    BuildReport();

                    saveFileDialog.Filter = "PDF|*.pdf;";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filepath = saveFileDialog.FileName;
                        LocalReportExtensions.ExportToPDF(rep, filepath);
                    }
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    BuildReport();
                    LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_preview1_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    string pdfpath = "";
 
                    //
                    pdfpath = @"\Thumb\report\temp.pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                    BuildReport();

                    LocalReportExtensions.ExportToPDF(rep, pdfpath);
                    wd_previewPdf w = new wd_previewPdf();
                    w.pdfPath = pdfpath;
                    if (!string.IsNullOrEmpty(w.pdfPath))
                    {
                        w.ShowDialog();
                        w.wb_pdfWebViewer.Dispose();
                    }
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_pieChart_Click(object sender, RoutedEventArgs e)
        {//pie
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucReceivedAccounts);
                /////////////////////
                if (MainWindow.groupObject.HasPermissionAction(reportsPermission, MainWindow.groupObjects, "one") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    //cashesQueryExcel = cashesQuery.ToList();
                    win_lvc win = new win_lvc(cashesQueryExcel, 8);
                    win.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                /////////////////////
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucReceivedAccounts);
                SectionData.ExceptionMessage(ex, this);
            }

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }

        private async void Chb_all_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                dp_startSearchDate.IsEnabled =
            dp_endSearchDate.IsEnabled = false;
                Btn_refresh_Click(btn_refresh, null);

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Chb_all_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                dp_startSearchDate.IsEnabled =
                dp_endSearchDate.IsEnabled = true;

                Btn_refresh_Click(btn_refresh, null);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
    }
}

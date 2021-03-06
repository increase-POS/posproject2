using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using netoaster;
using POS.Classes;
using POS.View;
using POS.View.accounts;
using POS.View.delivery;
using POS.View.reports;
using POS.View.Settings;
using POS.View.windows;
using WPFTabTip;

namespace POS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static ResourceManager resourcemanager;
        public static ResourceManager resourcemanagerreport;
        bool menuState = false;
        //ToolTip="{Binding Properties.Settings.Default.Lang}"
        public static string firstPath = "";
        public static string secondPath = "";
        public static string first = "";
        public static string second = "";
        public static string lang;
        public static string Reportlang = "en";
        public static string companyName;
        public static string Email;
        public static string Fax;
        public static string Mobile;
        public static string Address;
        public static CountryCode Region;
        public static string Currency;
        public static int CurrencyId;
        public static string Phone;
        internal static int? userID;
        internal static User userLogin;
        internal static int? userLogInID;
        internal static Pos posLogIn = new Pos();
        internal static int? posID;
        internal static int? branchID;
        public static Branch loginBranch;
        bool isHome = false;
        internal static int? isInvTax;
        internal static decimal? tax;
        //tax
        internal static bool? invoiceTax_bool;
        internal static decimal? invoiceTax_decimal;
        internal static bool? itemsTax_bool;
        internal static decimal? itemsTax_decimal;
        internal static string itemtax_note;
        internal static string sales_invoice_note;

        internal static int? itemCost;
        internal static string dateFormat;
        internal static string accuracy;
        internal static decimal? StorageCost;
        public static int Idletime = 14;
        public static int threadtime = 5;
        public static string menuIsOpen = "close";
        public static List<ItemUnitUser> itemUnitsUsers = new List<ItemUnitUser>();
        public static ItemUnitUser itemUnitsUser = new ItemUnitUser();

        static public GroupObject groupObject = new GroupObject();
        static public List<GroupObject> groupObjects = new List<GroupObject>();
        static SettingCls setModel = new SettingCls();
        static SetValues valueModel = new SetValues();
        static int nameId, addressId, emailId, mobileId, phoneId, faxId, logoId, taxId;
        public static string logoImage;


        ImageBrush myBrush = new ImageBrush();
        NotificationUser notificationUser = new NotificationUser();

        public static DispatcherTimer timer;
        DispatcherTimer idletimer;//  logout timer
        DispatcherTimer threadtimer;//  repeat timer for check other login
        DispatcherTimer notTimer;//  repeat timer for notifications
                                 // print setting
        public static string sale_copy_count;
        public static string pur_copy_count;
        public static string print_on_save_sale;
        public static string print_on_save_pur;
        public static string email_on_save_sale;
        public static string email_on_save_pur;
        public static string rep_printer_name;
        public static string sale_printer_name;
        public static string salePaperSize;
        public static string rep_print_count;
        public static string docPapersize;
        public static string Allow_print_inv_count;
        public static string show_header;
        public static string print_on_save_directentry;
        public static string directentry_copy_count;
        public static Boolean go_out = false;
        public static Boolean go_out_didNotAnyProcess = false;
        static public PosSetting posSetting = new PosSetting();
        internal static List<Pos> posList = new List<Pos>();

        static public List<Item> InvoiceGlobalItemsList = new List<Item>();
        static public List<ItemUnit> InvoiceGlobalItemUnitsList = new List<ItemUnit>();
        static public List<Item> InvoiceGlobalSaleUnitsList = new List<Item>();


        public ItemUnit GlobalItemUnit = new ItemUnit();
        public List<ItemUnit> GlobalItemUnitsList = new List<ItemUnit>();
        public Unit GlobalUnit = new Unit();
        public List<Unit> GlobalUnitsList = new List<Unit>();

        public static int _CachTransfersCount = 0;

        string deliveryPermission = "salesOrders_delivery";

        public static async Task Getprintparameter()
        {
            List<SetValues> printList = new List<SetValues>();
            printList = await valueModel.GetBySetvalNote("print");
            sale_copy_count = printList.Where(X => X.name == "sale_copy_count").FirstOrDefault().value;

            pur_copy_count = printList.Where(X => X.name == "pur_copy_count").FirstOrDefault().value;

            print_on_save_sale = printList.Where(X => X.name == "print_on_save_sale").FirstOrDefault().value;

            print_on_save_pur = printList.Where(X => X.name == "print_on_save_pur").FirstOrDefault().value;

            email_on_save_sale = printList.Where(X => X.name == "email_on_save_sale").FirstOrDefault().value;

            email_on_save_pur = printList.Where(X => X.name == "email_on_save_pur").FirstOrDefault().value;

            sale_copy_count = printList.Where(X => X.name == "sale_copy_count").FirstOrDefault().value;

            pur_copy_count = printList.Where(X => X.name == "pur_copy_count").FirstOrDefault().value;

            rep_print_count = printList.Where(X => X.name == "rep_copy_count").FirstOrDefault().value;

            Allow_print_inv_count = printList.Where(X => X.name == "Allow_print_inv_count").FirstOrDefault().value;
            show_header = printList.Where(X => X.name == "show_header").FirstOrDefault().value;

            if (show_header == null || show_header == "")
            {
                show_header = "1";
            }
            itemtax_note = printList.Where(X => X.name == "itemtax_note").FirstOrDefault().value;
            sales_invoice_note = printList.Where(X => X.name == "sales_invoice_note").FirstOrDefault().value;
            print_on_save_directentry = printList.Where(X => X.name == "print_on_save_directentry").FirstOrDefault().value;
            directentry_copy_count = printList.Where(X => X.name == "directentry_copy_count").FirstOrDefault().value;
        }
        public static async Task GetReportlang()
        {
            List<SetValues> replangList = new List<SetValues>();
            replangList = await valueModel.GetBySetName("report_lang");
            Reportlang = replangList.Where(r => r.isDefault == 1).FirstOrDefault().value;

        }
        public static async Task getPrintersNames()
        {

            posSetting = new PosSetting();

            posSetting = await posSetting.GetByposId((int)MainWindow.posID);
            posSetting = posSetting.MaindefaultPrinterSetting(posSetting);

            if (posSetting.repname is null || posSetting.repname == "")
            {
                rep_printer_name = "";
            }
            else
            {
                rep_printer_name = Encoding.UTF8.GetString(Convert.FromBase64String(posSetting.repname));
            }
            if (posSetting.salname is null || posSetting.salname == "")
            {
                posSetting.salname = "";
            }
            else
            {
                sale_printer_name = Encoding.UTF8.GetString(Convert.FromBase64String(posSetting.salname));
            }

            salePaperSize = posSetting.saleSizeValue;
            docPapersize = posSetting.docPapersize;

        }
        public static async Task getprintSitting()
        {
            await Getprintparameter();
            await GetReportlang();
            await getPrintersNames();
        }
        static public MainWindow mainWindow;
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                mainWindow = this;
                windowFlowDirection();
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }

        }
        void windowFlowDirection()
        {
            #region translate
            if (lang.Equals("en"))
            {
                resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_mainWindow.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_mainWindow.FlowDirection = FlowDirection.RightToLeft;
            }
            #endregion
        }

        #region loading
        static List<keyValueBool> loadingList;
        List<string> catchError = new List<string>();
        int catchErrorCount = 0;
        //loadingThread[] loadingList = new loadingThread[25];

        int reloadingCount_getUserPath = 0;
        async void loading_getUserPath()
        {
            #region get user path
            try
            {
                UserSetValues uSetValueModel = new UserSetValues();
                List<UserSetValues> lst = await uSetValueModel.GetAll();

                SetValues setValueModel = new SetValues();

                List<SetValues> setVLst = await setValueModel.GetBySetName("user_path");
                if (setVLst.Count > 0)
                {
                    int firstId = setVLst[0].valId;
                    int secondId = setVLst[1].valId;
                    firstPath = lst.Where(u => u.valId == firstId && u.userId == userID).FirstOrDefault().note;
                    secondPath = lst.Where(u => u.valId == secondId && u.userId == userID).FirstOrDefault().note;
                }
                else
                {
                    firstPath = "";
                    secondPath = "";
                }
            }
            catch
            {
                //firstPath = "";
                //secondPath = "";
                if(reloadingCount_getUserPath < 2)
                loading_getUserPath();
                reloadingCount_getUserPath++;
                catchError.Add("loading_getUserPath");
                catchErrorCount++;
            }
            #endregion
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getUserPath"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getTax = 0;
        async void loading_getTax()
        {
            //get tax
            try
            {
                //tax = decimal.Parse(await getDefaultTax());
                List<string> taxLst = await getDefaultTaxList();
                invoiceTax_bool = Convert.ToBoolean(taxLst[0]);
                invoiceTax_decimal = decimal.Parse(taxLst[1]);
                itemsTax_bool = Convert.ToBoolean(taxLst[2]);
                itemsTax_decimal = decimal.Parse(taxLst[3]);
            }
            catch
            {
                // invoiceTax_bool = false;
                //invoiceTax_decimal = 0;
                //itemsTax_bool = false;
                //itemsTax_decimal = 0;
                if(reloadingCount_getTax < 2)
                loading_getTax();
                reloadingCount_getTax++;
                catchError.Add("loading_getTax");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getTax"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getItemCost = 0;
        async void loading_getItemCost()
        {
            //get item cost
            try
            {
                itemCost = int.Parse(await getDefaultItemCost());
            }
            catch
            {
                //itemCost = 0;
                if(reloadingCount_getItemCost < 2)
                loading_getItemCost();
                reloadingCount_getItemCost++;
                catchError.Add("loading_getItemCost");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getItemCost"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getPrintCount = 0;
        async void loading_getPrintCount()
        {
            //get print count
            try
            {
                Allow_print_inv_count = await getDefaultPrintCount();
            }
            catch
            {
                //Allow_print_inv_count = "1";
                if(reloadingCount_getPrintCount < 2)
                loading_getPrintCount();
                reloadingCount_getPrintCount++;
                catchError.Add("loading_getPrintCount");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getPrintCount"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getBalance = 0;
        async void loading_getBalance()
        {
            //get print count
            try
            {
                await refreshBalance();
            }
            catch
            {
                if(reloadingCount_getBalance < 2)
                loading_getBalance();
                reloadingCount_getBalance++;
                catchError.Add("loading_getBalance");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getBalance"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getDateForm = 0;
        async void loading_getDateForm()
        {
            //get dateform
            try
            {
                dateFormat = await getDefaultDateForm();
            }
            catch
            {
                //dateFormat = "ShortDatePattern";
                if(reloadingCount_getDateForm < 2)
                loading_getDateForm();
                reloadingCount_getDateForm++;
                catchError.Add("loading_getDateForm");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getDateForm"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getRegionAndCurrency = 0;
        async void loading_getRegionAndCurrency()
        {
            //get region and currency
            try
            {
                CountryCode c = await getDefaultRegion();
                Region = c;
                Currency = c.currency;
                CurrencyId = c.currencyId;
                txt_cashSympol.Text = MainWindow.Currency;

            }
            catch
            {
                if(reloadingCount_getRegionAndCurrency < 2)
                loading_getRegionAndCurrency();
                reloadingCount_getRegionAndCurrency++;
                catchError.Add("loading_getRegionAndCurrency");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getRegionAndCurrency"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getStorageCost = 0;
        async void loading_getStorageCost()
        {
            //get storage cost
            try
            {
                StorageCost = decimal.Parse(await getDefaultStorageCost());
            }
            catch
            {
                //StorageCost = 0;
                if(reloadingCount_getStorageCost < 2)
                loading_getStorageCost();
                reloadingCount_getStorageCost++;
                catchError.Add("loading_getStorageCost");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getStorageCost"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getAccurac = 0;
        async void loading_getAccurac()
        {
            //get accuracy
            try
            {
                accuracy = await getDefaultAccuracy();
            }
            catch
            {
                //accuracy = "1";
                if(reloadingCount_getAccurac < 2)
                loading_getAccurac();
                reloadingCount_getAccurac++;
                catchError.Add("loading_getAccurac");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getAccurac"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getUserPersonalInfo = 0;
        async void loading_getUserPersonalInfo()
        {
            #region user personal info
            txt_userName.Text = userLogin.name;
            txt_userJob.Text = userLogin.job;
            try
            {
                if (!string.IsNullOrEmpty(userLogin.image))
                {
                    byte[] imageBuffer = await userModel.downloadImage(userLogin.image); // read this as BLOB from your DB

                    var bitmapImage = new BitmapImage();

                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }

                    img_userLogin.Fill = new ImageBrush(bitmapImage);
                }
                else
                {
                    clearImg();
                }
            }
            catch
            {
                //clearImg();
                if(reloadingCount_getUserPersonalInfo < 2)
                loading_getUserPersonalInfo();
                reloadingCount_getUserPersonalInfo++;
                catchError.Add("loading_getUserPersonalInfo");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getUserPersonalInfo"))
                {
                    item.value = true;
                    break;
                }
            }
            #endregion
        }

        int reloadingCount_getItemUnitsUsers = 0;
        async void loading_getItemUnitsUsers()
        {
            try
            {
                itemUnitsUsers = await itemUnitsUser.GetByUserId(userLogin.userId);
            }
            catch (Exception)
            {
                if(reloadingCount_getItemUnitsUsers < 2)
                loading_getItemUnitsUsers();
                reloadingCount_getItemUnitsUsers++;
                catchError.Add("loading_getItemUnitsUsers");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getItemUnitsUsers"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getGroupObjects = 0;
        async void loading_getGroupObjects()
        {
            try
            {
                groupObjects = await groupObject.GetUserpermission(userLogin.userId);
            }
            catch (Exception)
            {
                if(reloadingCount_getGroupObjects < 2)
                loading_getGroupObjects();
                reloadingCount_getGroupObjects++;
                catchError.Add("loading_getGroupObjects");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getGroupObjects"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_getTaxDetails = 0;
        async void loading_getTaxDetails()
        {
            try
            {

                // List<SettingCls> settingsCls = await setModel.GetAll();
                //  List<SetValues> settingsValues = await valueModel.GetAll();
                List<SetValues> settingsValues = await valueModel.GetBySetvalNote("tax");
                //    SettingCls set = new SettingCls();
                SetValues setV = new SetValues();

                #region get invoice tax bool
                //get invoice tax bool
                //   set = settingsCls.Where(s => s.name == "invoiceTax_bool").FirstOrDefault<SettingCls>();
                setV = settingsValues.Where(i => i.name == "invoiceTax_bool").FirstOrDefault();
                if (setV != null)
                    invoiceTax_bool = bool.Parse(setV.value);
                else
                    invoiceTax_bool = false;

                #endregion

                #region  get invoice tax decimal
                //get invoice tax decimal
                //  set = settingsCls.Where(s => s.name == "invoiceTax_decimal").FirstOrDefault<SettingCls>();

                setV = settingsValues.Where(i => i.name == "invoiceTax_decimal").FirstOrDefault();
                if (setV != null)
                    invoiceTax_decimal = decimal.Parse(setV.value);
                else
                    invoiceTax_decimal = 0;
                #endregion

                #region  get item tax bool
                //get item tax bool
                //  set = settingsCls.Where(s => s.name == "itemsTax_bool").FirstOrDefault<SettingCls>();// itemsTax_bool
                setV = settingsValues.Where(i => i.name == "itemsTax_bool").FirstOrDefault();
                if (setV != null)
                    itemsTax_bool = bool.Parse(setV.value);
                else
                    itemsTax_bool = false;

                #endregion

                #region get item tax decimal

                ////get item tax decimal
                //set = settingsCls.Where(s => s.name == "itemsTax_decimal").FirstOrDefault<SettingCls>();
                //setV = settingsValues.Where(i => i.settingId == set.settingId).FirstOrDefault();
                //if (setV != null)
                //    itemsTax_decimal = decimal.Parse(setV.value);
                //else
                //    itemsTax_decimal = 0;

                #endregion

            }
            catch (Exception)
            {
                //invoiceTax_bool = false;
                //invoiceTax_decimal = 0;
                //itemsTax_bool = false;
                //itemsTax_decimal = 0;
                if(reloadingCount_getTaxDetails < 2)
                loading_getTaxDetails();
                reloadingCount_getTaxDetails++;
                catchError.Add("loading_getTaxDetails");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getTaxDetails"))
                {
                    item.value = true;
                    break;
                }
            }

        }

        int reloadingCount_getDefaultSystemInfo = 0;
        async void loading_getDefaultSystemInfo()
        {
            try
            {
                List<SettingCls> settingsCls = await setModel.GetAll();
                List<SetValues> settingsValues = await valueModel.GetAll();
                SettingCls set = new SettingCls();
                SetValues setV = new SetValues();
                List<char> charsToRemove = new List<char>() { '@', '_', ',', '.', '-' };
                #region get company name
                Thread t1 = new Thread(() =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        //get company name
                        set = settingsCls.Where(s => s.name == "com_name").FirstOrDefault<SettingCls>();
                        nameId = set.settingId;
                        setV = settingsValues.Where(i => i.settingId == nameId).FirstOrDefault();
                        if (setV != null)
                            companyName = setV.value;

                    });
                });
                t1.Start();
                #endregion

                #region  get company address
                Thread t2 = new Thread(() =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        //get company address
                        set = settingsCls.Where(s => s.name == "com_address").FirstOrDefault<SettingCls>();
                        addressId = set.settingId;
                        setV = settingsValues.Where(i => i.settingId == addressId).FirstOrDefault();
                        if (setV != null)
                            Address = setV.value;
                    });
                });
                t2.Start();
                #endregion

                #region  get company email
                Thread t3 = new Thread(() =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        //get company email
                        set = settingsCls.Where(s => s.name == "com_email").FirstOrDefault<SettingCls>();
                        emailId = set.settingId;
                        setV = settingsValues.Where(i => i.settingId == emailId).FirstOrDefault();
                        if (setV != null)
                            Email = setV.value;
                    });
                });
                t3.Start();
                #endregion

                #region  get company mobile
                Thread t4 = new Thread(() =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        //get company mobile
                        set = settingsCls.Where(s => s.name == "com_mobile").FirstOrDefault<SettingCls>();
                        mobileId = set.settingId;
                        setV = settingsValues.Where(i => i.settingId == mobileId).FirstOrDefault();
                        if (setV != null)
                        {
                            charsToRemove.ForEach(x => setV.value = setV.value.Replace(x.ToString(), String.Empty));
                            Mobile = setV.value;
                        }
                    });
                });
                t4.Start();
                #endregion

                #region  get company phone
                Thread t5 = new Thread(() =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        //get company phone
                        set = settingsCls.Where(s => s.name == "com_phone").FirstOrDefault<SettingCls>();
                        phoneId = set.settingId;
                        setV = settingsValues.Where(i => i.settingId == phoneId).FirstOrDefault();
                        if (setV != null)
                        {
                            charsToRemove.ForEach(x => setV.value = setV.value.Replace(x.ToString(), String.Empty));
                            Phone = setV.value;
                        }
                    });
                });
                t5.Start();
                #endregion

                #region  get company fax
                Thread t6 = new Thread(() =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        //get company fax
                        set = settingsCls.Where(s => s.name == "com_fax").FirstOrDefault<SettingCls>();
                        faxId = set.settingId;
                        setV = settingsValues.Where(i => i.settingId == faxId).FirstOrDefault();
                        if (setV != null)
                        {
                            charsToRemove.ForEach(x => setV.value = setV.value.Replace(x.ToString(), String.Empty));
                            Fax = setV.value;
                        }
                    });
                });
                t6.Start();
                #endregion

                #region   get company logo
                //get company logo
                set = settingsCls.Where(s => s.name == "com_logo").FirstOrDefault<SettingCls>();
                logoId = set.settingId;
                setV = settingsValues.Where(i => i.settingId == logoId).FirstOrDefault();
                if (setV != null)
                {
                    logoImage = setV.value;
                    await setV.getImg(logoImage);
                }
                #endregion
            }
            catch (Exception)
            {
                if(reloadingCount_getDefaultSystemInfo < 2)
                loading_getDefaultSystemInfo();
                reloadingCount_getDefaultSystemInfo++;
                catchError.Add("loading_getDefaultSystemInfo");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getDefaultSystemInfo"))
                {
                    item.value = true;
                    break;
                }
            }

        }

        int reloadingCount_getprintSitting = 0;
        async void loading_getprintSitting()
        {
            try
            {
                await getprintSitting();
            }
            catch (Exception)
            {
                if(reloadingCount_getprintSitting < 2)
                loading_getprintSitting();
                reloadingCount_getprintSitting++;
                catchError.Add("loading_getprintSitting");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_getprintSitting"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_GlobalItemUnitsList = 0;
        async void loading_GlobalItemUnitsList()
        {
            try
            {
                GlobalItemUnitsList = await GlobalItemUnit.GetIU();
            }
            catch (Exception)
            {
                if(reloadingCount_GlobalItemUnitsList < 2)
                loading_GlobalItemUnitsList();
                reloadingCount_GlobalItemUnitsList++;
                catchError.Add("loading_GlobalItemUnitsList");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_GlobalItemUnitsList"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_GlobalUnitsList = 0;
        async void loading_GlobalUnitsList()
        {
            try
            {
                GlobalUnitsList = await GlobalUnit.GetU();
            }
            catch (Exception)
            {
                if(reloadingCount_GlobalUnitsList < 2)
                loading_GlobalUnitsList();
                reloadingCount_GlobalUnitsList++;
                catchError.Add("loading_GlobalUnitsList");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_GlobalUnitsList"))
                {
                    item.value = true;
                    break;
                }
            }
        }

        int reloadingCount_POSList = 0;
        async void loading_POSList()
        {
            try
            {
                posList = await posLogIn.Get();
            }
            catch (Exception)
            {
                if(reloadingCount_POSList < 2)
                loading_POSList();
                reloadingCount_POSList++;
                catchError.Add("loading_POSList");
                catchErrorCount++;
            }
            foreach (var item in loadingList)
            {
                if (item.key.Equals("loading_POSList"))
                {
                    item.value = true;
                    break;
                }
            }
        }
        #endregion
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_mainWindow, "mainWindow_load");

                uc_general.settingsCls = await setModel.GetAll();
                uc_general.settingsValues = await valueModel.GetAll();

                #region bonni
#pragma warning disable CS0436 // Type conflicts with imported type
                TabTipAutomation.IgnoreHardwareKeyboard = HardwareKeyboardIgnoreOptions.IgnoreAll;
#pragma warning restore CS0436 // Type conflicts with imported type
#pragma warning disable CS0436 // Type conflicts with imported type
#pragma warning restore CS0436 // Type conflicts with imported type
#pragma warning disable CS0436 // Type conflicts with imported type
                TabTipAutomation.ExceptionCatched += TabTipAutomationOnTest;
#pragma warning restore CS0436 // Type conflicts with imported type
                this.Height = SystemParameters.MaximizedPrimaryScreenHeight;
                //this.Width = SystemParameters.MaximizedPrimaryScreenHeight;
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();

                // idle timer
                idletimer = new DispatcherTimer();
                idletimer.Interval = TimeSpan.FromMinutes(1);
                idletimer.Tick += timer_Idle;
                idletimer.Start();


                //thread
                threadtimer = new DispatcherTimer();
                threadtimer.Interval = TimeSpan.FromSeconds(threadtime);
                threadtimer.Tick += timer_Thread;
                threadtimer.Start();




                #endregion

                translate();

                #region loading
                loadingList = new List<keyValueBool>();
                bool isDone = true;
                loadingList.Add(new keyValueBool { key = "loading_getUserPath", value = false });
                //loadingList.Add(new keyValueBool { key = "loading_getTax", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getItemCost", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getDateForm", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getRegionAndCurrency", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getStorageCost", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getAccurac", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getUserPersonalInfo", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getDefaultSystemInfo", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getTaxDetails", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getItemUnitsUsers", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getGroupObjects", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getprintSitting", value = false });
                loadingList.Add(new keyValueBool { key = "loading_GlobalItemUnitsList", value = false });
                loadingList.Add(new keyValueBool { key = "loading_GlobalUnitsList", value = false });
                loadingList.Add(new keyValueBool { key = "loading_POSList", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getPrintCount", value = false });
                loadingList.Add(new keyValueBool { key = "loading_getBalance", value = false });

                loading_getUserPath();
                //loading_getTax();
                loading_getItemCost();
                loading_getDateForm();
                loading_getRegionAndCurrency();
                loading_getStorageCost();
                loading_getAccurac();
                loading_getItemUnitsUsers();
                loading_getUserPersonalInfo();
                loading_getDefaultSystemInfo();
                loading_getTaxDetails();
                loading_getGroupObjects();
                loading_getprintSitting();
                loading_GlobalItemUnitsList();
                loading_GlobalUnitsList();
                loading_POSList();
                loading_getPrintCount();
                loading_getBalance();
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
                //MessageBox.Show(catchError + " and count: " + catchErrorCount);
                #endregion

                #region notifications 
                setNotifications();
                setTimer();
                #endregion
                #region Permision
                permission();


                if (MainWindow.groupObject.HasPermissionAction(deliveryPermission, MainWindow.groupObjects, "one"))
                    md_deliveryWaitConfirmUser.Visibility = Visibility.Visible;
                else
                    md_deliveryWaitConfirmUser.Visibility = Visibility.Collapsed;
                #endregion

                //SelectAllText
                EventManager.RegisterClassHandler(typeof(System.Windows.Controls.TextBox), System.Windows.Controls.TextBox.GotKeyboardFocusEvent, new RoutedEventHandler(SelectAllText));


                SetNotificationsLocation();

                #region expire date
                daysremain daysr = await userModel.getRemainDayes();
                if (daysr.expirestate == "e" && daysr.days <= 10)
                {

                    wd_messageBoxWithIcon w = new wd_messageBoxWithIcon();
                    if (daysr.days >= 1)
                    {
                        w.contentText1 = resourcemanager.GetString("trExpireNote1") + " " + daysr.days.ToString() + " " + resourcemanager.GetString("trExpireDays");
                        w.Show();
                    }
                    else if (daysr.days == 0)
                    {


                        if (daysr.hours >= 0 && daysr.hours <= 24)
                        {
                            if (daysr.hours == 0)
                            {
                                if (daysr.minute >= 0)
                                {
                                    w.contentText1 = resourcemanager.GetString("trExpireNote2");
                                    w.Show();
                                }


                            }
                            else
                            {
                                w.contentText1 = resourcemanager.GetString("trExpireNote2");
                                w.Show();
                            }



                        }
                        //else 
                        //{
                        //    w.contentText1 = resourcemanager.GetString("trExpireNote3")+" " + (daysr.days* -1 ).ToString() + " " + resourcemanager.GetString("trAgo");
                        //}
                    }

                }

                #endregion

                if (sender != null)
                    SectionData.EndAwait(grid_mainWindow, "mainWindow_load");
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_mainWindow, "mainWindow_load");
                SectionData.ExceptionMessage(ex, this);
            }
        }
        public void SetNotificationsLocation()
        {
            #region notifications location
            //Point position = BTN_notifications.PointToScreen(new Point(0d, 0d)),
            //controlPosition = this.PointToScreen(new Point(0d, 0d));
            //position.X -= controlPosition.X;
            //position.Y -= controlPosition.Y;
            //position.X -= 100;
            //bdrMain.Margin = new Thickness(0, 70, position.X, 0);
            #endregion
            #region notifications location
            /*
           Point positionBtnMinimize = BTN_Minimize.PointToScreen(new Point(0d, 0d)),
           positionBtnUserImage = btn_userImage.PointToScreen(new Point(0d, 0d)),
           controlPositionBtnMinimize = this.PointToScreen(new Point(0d, 0d)),
           controlPositionBtnUserImage = this.PointToScreen(new Point(0d, 0d));
           positionBtnMinimize.X -= controlPositionBtnMinimize.X;
           positionBtnUserImage.X -= controlPositionBtnUserImage.X;
           Double position;
           if (positionBtnMinimize.X > positionBtnUserImage.X)
           position = positionBtnMinimize.X - positionBtnUserImage.X;
           else 
           position =   positionBtnUserImage.X - positionBtnMinimize.X;
           var thickness = bdrMain.Margin;
           bdrMain.Margin = new Thickness(0, 70, thickness.Right + position - 25, 0);
           //if(lang.Equals("en"))
           //bdrMain.Margin = new Thickness(0, 70, thickness.Right + position - 5 , 0);
           //else
           //  bdrMain.Margin = new Thickness(0, 70, thickness.Right + position - 10, 0);
           */
            #endregion
            #region notifications location
            //Point position = BTN_notifications.PointToScreen(new Point(0d, 0d)),
            //controlPosition = this.PointToScreen(new Point(0d, 0d));
            //position.X -= controlPosition.X;
            //Canvas.SetTop(bdrMain, position.X);
            ////bdrMain.Margin = new Thickness(0, 70, position.X, 0);
            #endregion
            #region notifications location
            var thickness = bdrMain.Margin;
            bdrMain.Margin = new Thickness(0, 70, thickness.Right + stp_userName.ActualWidth, 0);
            #endregion
        }

        void SelectAllText(object sender, RoutedEventArgs e)
        {
            var textBox = sender as System.Windows.Controls.TextBox;
            if (textBox != null)
                if (!textBox.IsReadOnly)
                    textBox.SelectAll();
        }

        public async static Task<bool> loadingDefaultPath(string first, string second)
        {
            bool load = false;
            if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second))
            {
                foreach (Button button in FindControls.FindVisualChildren<Button>(MainWindow.mainWindow))
                {
                    if (button.Tag != null)
                        if (button.Tag.ToString() == first && (MainWindow.groupObject.HasPermission(first, MainWindow.groupObjects) || SectionData.isAdminPermision()))
                        {
                            button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                            load = true;
                            break;
                        }
                }
                await Task.Delay(0500);
                if (first == "home")
                    loadingSecondLevel(second, uc_home.Instance);
                if (first == "catalog")
                    loadingSecondLevel(second, UC_catalog.Instance);
                if (first == "storage")
                    loadingSecondLevel(second, POS.View.uc_storage.Instance);
                if (first == "purchase")
                    loadingSecondLevel(second, uc_purchases.Instance);
                if (first == "sales")
                    loadingSecondLevel(second, uc_sales.Instance);
                if (first == "delivery")
                    loadingSecondLevel(second, uc_delivery.Instance);
                if (first == "accounts")
                    loadingSecondLevel(second, uc_accounts.Instance);
                if (first == "reports")
                    loadingSecondLevel(second, uc_reports.Instance);
                if (first == "sectionData")
                    loadingSecondLevel(second, UC_SectionData.Instance);
                if (first == "settings")
                    loadingSecondLevel(second, uc_settings.Instance);

            }
            return load;
        }

        static void loadingSecondLevel(string second, UserControl userControl)
        {
            userControl.RaiseEvent(new RoutedEventArgs(FrameworkElement.LoadedEvent));
            var button = userControl.FindName("btn_" + second) as Button;
            if (button != null)
                button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
        async void permission()
        {
            bool loadWindow = false;
            loadWindow = await loadingDefaultPath(firstPath, secondPath);
            if (!SectionData.isAdminPermision())
                foreach (Button button in FindControls.FindVisualChildren<Button>(this))
                {
                    if (button.Tag != null)
                        if (MainWindow.groupObject.HasPermission(button.Tag.ToString(), MainWindow.groupObjects))
                        {
                            button.Visibility = Visibility.Visible;
                            if (!loadWindow)
                            {
                                button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                                loadWindow = true;
                            }
                        }
                        else button.Visibility = Visibility.Collapsed;
                }
            else
            {
                if (!loadWindow)
                    BTN_Home_Click(BTN_home, null);
            }
        }
        #region notifications
        Invoice invoice = new Invoice();
        int _OrdersWaitCount = 0;
        int _NotCount = 0;
        private void setTimer()
        {
            notTimer = new DispatcherTimer();
            notTimer.Interval = TimeSpan.FromSeconds(30);
            notTimer.Tick += notTimer_Tick;
            notTimer.Start();
        }
        private void notTimer_Tick(object sendert, EventArgs et)
        {
            try
            {
                setNotifications();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }



        }
        private async void setNotifications()
        {
            try
            {
                await refreshNotificationCount();
                await setCashTransferNotification();
                await refreshOrdersWaitNotification();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async Task refreshNotificationCount()
        {
            int notCount = await notificationUser.GetCountByUserId(userID.Value, "alert", posID.Value);

            //int previouseCount = 0;
            //if (md_notificationCount.Badge != null && md_notificationCount.Badge.ToString() != "") previouseCount = int.Parse(md_notificationCount.Badge.ToString());

            if (notCount != _NotCount)
            {
                if (notCount > 9)
                {
                    notCount = 9;
                    md_notificationCount.Badge = "+" + notCount.ToString();
                }
                else if (notCount == 0) md_notificationCount.Badge = "";
                else
                    md_notificationCount.Badge = notCount.ToString();
            }
            _NotCount = notCount;
        }
        private async Task refreshOrdersWaitNotification()
        {
            try
            {
                string invoiceType = "s";
                int ordersCount = await invoice.getDeliverOrdersCount(invoiceType, "ex", MainWindow.userID.Value);
                //if (invoice != null && _InvoiceType == "s" && invoice.invoiceId != 0 )
                //    ordersCount--;

                if (ordersCount != _OrdersWaitCount)
                {
                    if (ordersCount > 9)
                    {
                        md_deliveryWaitConfirmUser.Badge = "+9";
                    }
                    else if (ordersCount == 0) md_deliveryWaitConfirmUser.Badge = "";
                    else
                        md_deliveryWaitConfirmUser.Badge = ordersCount.ToString();
                }
                _OrdersWaitCount = ordersCount;
            }
            catch { }
        }
        private async Task setCashTransferNotification()
        {
            try
            {
                #region get cachtransfers for current pos
                CashTransfer cashModel = new CashTransfer();
                IEnumerable<CashTransfer> cashesQuery;
                cashesQuery = await cashModel.GetCashTransferForPosById("all", "p", (int)MainWindow.posID);
                cashesQuery = cashesQuery.Where(c => c.posId == MainWindow.posID && c.isConfirm == 0);
                int posCachTransfers = cashesQuery.Count();
                #endregion

                SectionData.refreshNotification(md_transfers, ref _CachTransfersCount, posCachTransfers);
            }
            catch (Exception ex)
            {
                //SectionData.ExceptionMessage(ex, this);
            }
        }
        #endregion
        void timer_Idle(object sender, EventArgs e)
        {

            try
            {
                if (IdleClass.IdleTime.Minutes >= Idletime)
                {
                    go_out_didNotAnyProcess = true;
                    BTN_Close_Click(null, null);
                    idletimer.Stop();
                    //popup here
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }

        }
        async void timer_Thread(object sendert, EventArgs et)
        {
            try
            {
                //  User thruser = new User();
                //UsersLogs thrlog = new UsersLogs();

                //thrlog = await thrlog.GetByID((int)userLogInID);
                // check go_out == true do logout()
                //if (thrlog.sOutDate != null)
                if (go_out)
                {
                    BTN_Close_Click(null, null);
                    threadtimer.Stop();
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
            refreshBalance();
        }

        public static async Task refreshBalance()
        {
            try
            {
                posLogIn = await posLogIn.getById(posID.Value);
                mainWindow.txt_cashValue.Text = SectionData.DecTostring(posLogIn.balance);
                mainWindow.txt_cashSympol.Text = MainWindow.Currency;

                if (posLogIn.boxState == "o")
                    mainWindow.txt_cashTitle.Foreground = Application.Current.Resources["MainColor"] as SolidColorBrush;
                else
                    mainWindow.txt_cashTitle.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, mainWindow);
            }

        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {

                txtTime.Text = DateTime.Now.ToShortTimeString();
                txtDate.Text = DateTime.Now.ToShortDateString();


            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void TabTipAutomationOnTest(Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
        private static List<string> QueryWmiKeyboards()
        {
            using (var searcher = new ManagementObjectSearcher(new SelectQuery("Win32_Keyboard")))
            using (var result = searcher.Get())
            {
                return result
                    .Cast<ManagementBaseObject>()
                    .SelectMany(keyboard =>
                        keyboard.Properties
                            .Cast<PropertyData>()
                            .Where(k => k.Name == "Description")
                            .Select(k => k.Value as string))
                    .ToList();
            }
        }
        void FN_tooltipVisibility(Button btn)
        {
            ToolTip T = btn.ToolTip as ToolTip;
            if (T.Visibility == Visibility.Visible)
                T.Visibility = Visibility.Hidden;
            else T.Visibility = Visibility.Visible;
        }
        //private async void BTN_logOut_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (sender != null)
        //            SectionData.StartAwait(grid_mainWindow);

        //        await close();
        //        Application.Current.Shutdown();
        //        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        //        await Task.Delay(3000);

        //        if (sender != null)
        //            SectionData.EndAwait(grid_mainWindow);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (sender != null)
        //            SectionData.EndAwait(grid_mainWindow);
        //        SectionData.ExceptionMessage(ex, this);
        //    }
        //}
        async Task close()
        {
            //log out
            //update lognin record
            if (!go_out)
            {
                await updateLogninRecord();
            }
            timer.Stop();
            idletimer.Stop();
            threadtimer.Stop();
        }
        private async void BTN_Close_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_mainWindow);
                if (go_out)
                {
                    await close();
                    this.Visibility = Visibility.Hidden;
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_messageBox w = new wd_messageBox();
                    w.contentText2 = MainWindow.resourcemanager.GetString("trUserLoginFromOtherPos");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion

                    Application.Current.Shutdown();
                }
                else if (go_out_didNotAnyProcess)
                {
                    await close();
                    this.Visibility = Visibility.Hidden;
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    wd_messageBoxWithIcon w = new wd_messageBoxWithIcon();
                    w.contentText1 = MainWindow.resourcemanager.GetString("trLoggedOutBecauseDidNotDoneAnyProcess");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion

                    Application.Current.Shutdown();
                }
                else
                {
                    await close();
                    Application.Current.Shutdown();
                }

                if (sender != null)
                    SectionData.EndAwait(grid_mainWindow);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_mainWindow);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void BTN_Minimize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = System.Windows.WindowState.Minimized;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void colorTextRefreash(TextBlock txt)
        {
            txt_home.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_catalog.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_storage.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_purchases.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_sales.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_sales.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_delivery.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_delivery.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_accounting.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_reports.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_sectiondata.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            txt_settings.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));

            txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8E8E8"));
        }
        void fn_ColorIconRefreash(Path p)
        {
            path_iconSettings.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconSectionData.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconReports.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconAccounts.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconSales.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconDelivery.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconPurchases.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconStorage.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconCatalog.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));
            path_iconHome.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9FD7F8"));

            p.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8E8E8"));
        }
        public void translate()
        {
            tt_menu.Content = resourcemanager.GetString("trMenu");
            tt_home.Content = resourcemanager.GetString("trHome");
            txt_home.Text = resourcemanager.GetString("trHome");
            tt_catalog.Content = resourcemanager.GetString("trCatalog");
            txt_catalog.Text = resourcemanager.GetString("trCatalog");
            tt_storage.Content = resourcemanager.GetString("trStore");
            txt_storage.Text = resourcemanager.GetString("trStore");
            tt_purchase.Content = resourcemanager.GetString("trPurchases");
            txt_purchases.Text = resourcemanager.GetString("trPurchases");
            tt_sales.Content = resourcemanager.GetString("trSales");
            txt_sales.Text = resourcemanager.GetString("trSales");
            tt_delivery.Content = resourcemanager.GetString("trDelivery");
            txt_delivery.Text = resourcemanager.GetString("trSales");
            tt_accounts.Content = resourcemanager.GetString("trAccounting");
            txt_accounting.Text = resourcemanager.GetString("trAccounting");
            tt_reports.Content = resourcemanager.GetString("trReports");
            txt_reports.Text = resourcemanager.GetString("trReports");
            tt_sectionData.Content = resourcemanager.GetString("trSectionData");
            txt_sectiondata.Text = resourcemanager.GetString("trSectionData");
            tt_settings.Content = resourcemanager.GetString("trSettings");
            txt_settings.Text = resourcemanager.GetString("trSettings");
            txt_cashTitle.Text = resourcemanager.GetString("trCashBalance");

            mi_changePassword.Header = resourcemanager.GetString("trChangePassword");
            BTN_logOut.Header = resourcemanager.GetString("trLogOut");

            txt_notifications.Text = resourcemanager.GetString("trNotifications");
            txt_noNoti.Text = resourcemanager.GetString("trNoNotifications");
            btn_showAll.Content = resourcemanager.GetString("trShowAll");
        }

        //فتح
        private void BTN_Menu_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (!menuState)
                {
                    Storyboard sb = this.FindResource("Storyboard1") as Storyboard;
                    sb.Begin();
                    menuState = true;
                }
                else
                {
                    Storyboard sb = this.FindResource("Storyboard2") as Storyboard;
                    sb.Begin();
                    menuState = false;
                }


                #region tooltipVisibility
                FN_tooltipVisibility(BTN_menu);
                FN_tooltipVisibility(BTN_home);
                FN_tooltipVisibility(btn_catalog);
                FN_tooltipVisibility(btn_storage);
                FN_tooltipVisibility(btn_purchase);
                FN_tooltipVisibility(btn_sales);
                FN_tooltipVisibility(btn_delivery);
                FN_tooltipVisibility(btn_reports);
                FN_tooltipVisibility(btn_accounts);
                FN_tooltipVisibility(btn_sectionData);
                FN_tooltipVisibility(btn_settings);
                #endregion


            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void fn_pathOpenCollapsed()
        {
            path_openCatalog.Visibility = Visibility.Collapsed;
            path_openStorage.Visibility = Visibility.Collapsed;
            path_openPurchases.Visibility = Visibility.Collapsed;
            path_openSales.Visibility = Visibility.Collapsed;
            path_openDelivery.Visibility = Visibility.Collapsed;
            path_openReports.Visibility = Visibility.Collapsed;
            path_openSectionData.Visibility = Visibility.Collapsed;
            path_openSettings.Visibility = Visibility.Collapsed;
            path_openHome.Visibility = Visibility.Collapsed;
            path_openAccount.Visibility = Visibility.Collapsed;


        }
        void FN_pathVisible(Path p)
        {
            fn_pathOpenCollapsed();
            p.Visibility = Visibility.Visible;
        }




        private void btn_Keyboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (TabTip.Close())
                {
#pragma warning disable CS0436 // Type conflicts with imported type
                    TabTip.OpenUndockedAndStartPoolingForClosedEvent();
#pragma warning restore CS0436 // Type conflicts with imported type
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }

        }

        User userModel = new User();
        UsersLogs userLogsModel = new UsersLogs();

        async Task<bool> updateLogninRecord()
        {

            UsersLogs userLog = new UsersLogs();
            userLog = await userLogsModel.GetByID(userLogInID.Value);
            //update user record
            userLogin.isOnline = 0;
            int s = await userModel.save(userLogin);
            //update lognin record
            s = await userLogsModel.Save(userLog);

            return true;
        }

        private void BTN_SectionData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                colorTextRefreash(txt_sectiondata);
                FN_pathVisible(path_openSectionData);
                fn_ColorIconRefreash(path_iconSectionData);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_SectionData.Instance);

                isHome = true;
                Button button = sender as Button;
                initializationMainTrack(button.Tag.ToString(), 0);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }

        }

        public void initializationMainTrack(string tag, int level)
        {
            if (level == 0)
            {
                txt_secondLevelTrack.Visibility = Visibility.Collapsed;
                txt_thirdLevelTrack.Visibility = Visibility.Collapsed;
                #region  mainWindow
                if (tag == "home")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trHome");
                else if (tag == "catalog")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trCatalog");
                else if (tag == "storage")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trStore");
                else if (tag == "purchase")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trPurchases");
                else if (tag == "sales")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trSales");
                else if (tag == "delivery")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trDelivery");
                else if (tag == "accounts")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trAccounting");
                else if (tag == "reports")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trReports");
                else if (tag == "sectionData")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trSectionData");
                else if (tag == "settings")
                    txt_firstLevelTrack.Text = "> " + resourcemanager.GetString("trSettings");
                #endregion
            }
            else if (level == 1)
            {
                txt_secondLevelTrack.Visibility = Visibility.Visible;
                txt_thirdLevelTrack.Visibility = Visibility.Collapsed;
                #region  storage
                if (tag == "locations")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trLocation");
                else if (tag == "section")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trSection");
                else if (tag == "reciptOfInvoice")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trInvoice");
                else if (tag == "itemsStorage")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStorage");
                else if (tag == "importExport")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trMovements");
                else if (tag == "itemsDestroy")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trDestructive");
                else if (tag == "shortage")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trShortage");
                else if (tag == "inventory")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStocktaking");
                else if (tag == "storageStatistic")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStatistic");
                #endregion
                #region  Account
                else if (tag == "posAccounting")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPOS");
                else if (tag == "payments")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPayments");
                else if (tag == "received")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trReceived");
                else if (tag == "bonds")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trBonds");
                else if (tag == "banksAccounting")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trBanks");
                else if (tag == "ordersAccounting")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trOrders");
                else if (tag == "subscriptions")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trSubscriptions");
                else if (tag == "accountsStatistic")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStatistic");
                #endregion
                #region  catalog
                else if (tag == "categories")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trCategories");
                else if (tag == "item")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trItems");
                else if (tag == "service")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trService");
                else if (tag == "package")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPackage");
                else if (tag == "properties")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trProperties");
                else if (tag == "units")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trUnits");
                else if (tag == "storageCost")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStorageCost");
                #endregion
                #region  purchase
                else if (tag == "payInvoice")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trInvoice");
                else if (tag == "purchaseOrder")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trOrders");
                else if (tag == "purchaseStatistic")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStatistic");
                #endregion
                #region  sales
                else if (tag == "reciptInvoice")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trInvoice");
                else if (tag == "coupon")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trCoupon");
                else if (tag == "offer")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trOffer");
                else if (tag == "quotation")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trQuotations");
                else if (tag == "salesOrders")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trOrders");
                else if (tag == "medals")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trMedals");
                else if (tag == "membership")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trMembership");
                else if (tag == "salesStatistic")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStatistic");
                #endregion
                #region  delivery
                else if (tag == "deliveryManagement")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("management");
                else if (tag == "driversManagement")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("deliveryList");
                #endregion
                #region  sectionData
                else if (tag == "suppliers")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trSuppliers");
                else if (tag == "customers")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trCustomers");
                else if (tag == "users")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trUsers");
                else if (tag == "branches")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trBranches");
                else if (tag == "stores")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStores");
                else if (tag == "pos")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPOS");
                else if (tag == "banks")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trBanks");
                else if (tag == "cards")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPayment1");
                else if (tag == "shippingCompany")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trShippingCompanies");
                #endregion
                #region  settings
                else if (tag == "general")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trGeneral");
                else if (tag == "reportsSettings")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trReports");
                else if (tag == "permissions")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPermission");
                else if (tag == "emailsSetting")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trEmail");
                else if (tag == "emailTemplates")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trEmailTemplates");
                else if (tag == "packageBookSetting")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("packageBookSettings");
                #endregion
                #region  report
                else if (tag == "reports")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trReports");
                else if (tag == "storageReports")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trStorage");
                else if (tag == "purchaseReports")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trPurchases");
                else if (tag == "salesReports")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trSales");
                else if (tag == "deliveryReports")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trDelivery");
                else if (tag == "accountsReports")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trAccounting");
                else if (tag == "usersReports")
                    txt_secondLevelTrack.Text = "> " + resourcemanager.GetString("trUsers");
                #endregion
            }
            else if (level == 2)
            {
                txt_thirdLevelTrack.Visibility = Visibility.Visible;

                #region  report

                if (tag == "invoice")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trInvoice");
                else if (tag == "order")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trOrders");
                else if (tag == "item")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trItems");


                #region  storageReports
                else if (tag == "stock")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trStock");
                else if (tag == "external")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trExternal");
                else if (tag == "internal")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trInternal");
                else if (tag == "stocktaking")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trStocktaking");
                else if (tag == "destroied")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trDestructives");

                #endregion

                #region  salesReports
                else if (tag == "promotion")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trPromotion");
                else if (tag == "quotation")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trQuotations");
                else if (tag == "dailySales")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trDailySales");

                #endregion
                 

                #region  accountsReports
                else if (tag == "payments")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trPayments");
                else if (tag == "recipient")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trRecipientTooltip");
                else if (tag == "received")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trReceived");
                else if (tag == "bank")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trBank");
                else if (tag == "pos")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trPOS");
                else if (tag == "statement")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trAccountStatement");
                else if (tag == "fund")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trCashBalance");
                else if (tag == "profit")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trProfits");
                else if (tag == "closing")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trDailyClosing");
                else if (tag == "tax")
                    txt_thirdLevelTrack.Text = "> " + resourcemanager.GetString("trTax");

                #endregion

                #endregion
            }

        }
        //void initializationMainTrackChildren(string text)
        //{
        //    var titleText = new TextBlock();
        //    titleText.Text = "> " + text;
        //    titleText.FontSize = 14;
        //    titleText.FontWeight = FontWeights.Regular;
        //    titleText.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        //    titleText.Margin = new Thickness(2.5, 1, 2.5, 1);
        //    sp_mainTrack.Children.Add(titleText);
        //}
        private void BTN_Home_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                colorTextRefreash(txt_home);
                FN_pathVisible(path_openHome);
                fn_ColorIconRefreash(path_iconHome);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_home.Instance);
                if (isHome)
                {
                    uc_home.Instance.timerAnimation();
                    isHome = false;
                }
                Button button = sender as Button;
                initializationMainTrack(button.Tag.ToString(), 0);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }

        }

        private void BTN_catalog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                colorTextRefreash(txt_catalog);
                FN_pathVisible(path_openCatalog);
                fn_ColorIconRefreash(path_iconCatalog);
                grid_main.Children.Clear();
                grid_main.Children.Add(UC_catalog.Instance);
                isHome = true;
                Button button = sender as Button;
                initializationMainTrack(button.Tag.ToString(), 0);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_mainWindow);
                await close();
                Application.Current.Shutdown();

                if (sender != null)
                    SectionData.EndAwait(grid_mainWindow);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_mainWindow);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Mi_changePassword_Click(object sender, RoutedEventArgs e)
        {//change password
            try
            {

                Window.GetWindow(this).Opacity = 0.2;
                wd_changePassword w = new wd_changePassword();
                w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;

                //userLogin = await userModel.getUserById(w.userID);

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        SetValues v = new SetValues();

        async Task<string> getDefaultStorageCost()
        {
            v = await uc_general.getDefaultCost();
            if (v != null)
                return v.value;
            else
                return "";
        }

        async Task<string> getDefaultLanguage()
        {
            UserSetValues v = await uc_general.getDefaultLanguage();
            SetValues sVModel = new SetValues();
            SetValues sValue = new SetValues();
            sValue = await sVModel.GetByID(v.valId.Value);
            if (sValue != null)
                return sValue.value;
            else
                return "";
        }

        async Task<string> getDefaultTax()
        {
            v = await uc_general.getDefaultTax();
            if (v != null)
                return v.value;
            else
                return "";
        }

        async Task<List<string>> getDefaultTaxList()
        {
            List<string> taxLst = await uc_general.getDefaultTaxList();
            if (taxLst == null)
                taxLst = new List<string>() { "false", "0", "false", "0" };
            return taxLst;
        }
        async Task<string> getDefaultItemCost()
        {
            v = await uc_general.getDefaultItemCost();
            if (v != null)
                return v.value;
            else
                return "";
        }
        async Task<string> getDefaultPrintCount()
        {
            v = await uc_general.getDefaultPrintCount();
            if (v != null)
                return v.value;
            else
                return "";
        }
        async Task<string> getDefaultAccuracy()
        {
            v = await uc_general.getDefaultAccuracy();
            if (v != null)
                return v.value;
            else
                return "";
        }
        async Task<string> getDefaultDateForm()
        {
            v = await uc_general.getDefaultDateForm();
            if (v != null)
                return v.value;
            else
                return "";
        }
        async Task<CountryCode> getDefaultRegion()
        {
            CountryCode c = await uc_general.getDefaultRegion();
            if (c != null)
                return c;
            else
                return null;
        }
        private void Mi_more_Click(object sender, RoutedEventArgs e)
        {

        }
        public static string GetUntilOrEmpty(string text, string stopAt)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
        List<NotificationUser> notifications;
        private async void BTN_notifications_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bdrMain.Visibility == Visibility.Collapsed)
                {
                    bdrMain.Visibility = Visibility.Visible;
                    bdrMain.RenderTransform = Animations.borderAnimation(-25, bdrMain, true);
                    notifications = await notificationUser.GetByUserId(userID.Value, "alert", posID.Value);
                    IEnumerable<NotificationUser> orderdNotifications = notifications.OrderByDescending(x => x.createDate);
                    await notificationUser.setAsRead(userID.Value, posID.Value, "alert");
                    md_notificationCount.Badge = "";
                    if (notifications.Count == 0)
                    {
                        grd_notifications.Visibility = Visibility.Collapsed;
                        txt_noNoti.Visibility = Visibility.Visible;
                    }

                    else
                    {
                        grd_notifications.Visibility = Visibility.Visible;
                        txt_noNoti.Visibility = Visibility.Collapsed;

                        txt_firstNotiTitle.Text = resourcemanager.GetString(orderdNotifications.Select(obj => obj.title).FirstOrDefault());

                        txt_firstNotiContent.Text = GetUntilOrEmpty(orderdNotifications.Select(obj => obj.ncontent).FirstOrDefault(), ":")
                          + " : " +
                          resourcemanager.GetString(orderdNotifications.Select(obj => obj.ncontent).FirstOrDefault().Substring(orderdNotifications.Select(obj => obj.ncontent).FirstOrDefault().LastIndexOf(':') + 1));

                        txt_firstNotiDate.Text = orderdNotifications.Select(obj => obj.createDate).FirstOrDefault().ToString();

                        if (notifications.Count > 1)
                        {
                            txt_2NotiTitle.Text = resourcemanager.GetString(orderdNotifications.Select(obj => obj.title).Skip(1).FirstOrDefault());
                            txt_2NotiContent.Text = GetUntilOrEmpty(orderdNotifications.Select(obj => obj.ncontent).Skip(1).FirstOrDefault(), ":")
                          + " : " + resourcemanager.GetString(orderdNotifications.Select(obj => obj.ncontent).Skip(1).FirstOrDefault().Substring(orderdNotifications.Select(obj => obj.ncontent).Skip(1).FirstOrDefault().LastIndexOf(':') + 1));

                            txt_2NotiDate.Text = orderdNotifications.Select(obj => obj.createDate).Skip(1).FirstOrDefault().ToString();

                        }
                        if (notifications.Count > 2)
                        {
                            txt_3NotiTitle.Text = resourcemanager.GetString(orderdNotifications.Select(obj => obj.title).Skip(2).FirstOrDefault());
                            txt_3NotiContent.Text = GetUntilOrEmpty(orderdNotifications.Select(obj => obj.ncontent).Skip(2).FirstOrDefault(), ":")
                          + " : " + resourcemanager.GetString(orderdNotifications.Select(obj => obj.ncontent).Skip(2).FirstOrDefault().Substring(orderdNotifications.Select(obj => obj.ncontent).Skip(2).FirstOrDefault().LastIndexOf(':') + 1));

                            txt_3NotiDate.Text = orderdNotifications.Select(obj => obj.createDate).Skip(2).FirstOrDefault().ToString();

                        }
                        if (notifications.Count > 3)
                        {
                            txt_4NotiTitle.Text = resourcemanager.GetString(orderdNotifications.Select(obj => obj.title).Skip(3).FirstOrDefault());
                            txt_4NotiContent.Text = GetUntilOrEmpty(orderdNotifications.Select(obj => obj.ncontent).Skip(3).FirstOrDefault(), ":")
                          + " : " + resourcemanager.GetString(orderdNotifications.Select(obj => obj.ncontent).Skip(3).FirstOrDefault().Substring(orderdNotifications.Select(obj => obj.ncontent).Skip(3).FirstOrDefault().LastIndexOf(':') + 1));

                            txt_4NotiDate.Text = orderdNotifications.Select(obj => obj.createDate).Skip(3).FirstOrDefault().ToString();

                        }
                        if (notifications.Count > 4)
                        {
                            txt_5NotiTitle.Text = resourcemanager.GetString(orderdNotifications.Select(obj => obj.title).Skip(4).FirstOrDefault());
                            txt_5NotiContent.Text = GetUntilOrEmpty(orderdNotifications.Select(obj => obj.ncontent).Skip(4).FirstOrDefault(), ":")
                          + " : " + resourcemanager.GetString(orderdNotifications.Select(obj => obj.ncontent).Skip(4).FirstOrDefault().Substring(orderdNotifications.Select(obj => obj.ncontent).Skip(4).FirstOrDefault().LastIndexOf(':') + 1));

                            txt_5NotiDate.Text = orderdNotifications.Select(obj => obj.createDate).Skip(4).FirstOrDefault().ToString();

                        }
                    }

                }
                else
                {
                    bdrMain.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_showAll_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            wd_notifications w = new wd_notifications();
            w.notifications = notifications;
            w.ShowDialog();
            Window.GetWindow(this).Opacity = 1;
        }
        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

                bdr_showAll.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {

                bdr_showAll.Visibility = Visibility.Hidden;

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                bdrMain.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_info_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window.GetWindow(this).Opacity = 0.2;
                wd_info w = new wd_info();
                w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_userImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window.GetWindow(this).Opacity = 0.2;
                wd_userInfo w = new wd_userInfo();
                w.ShowDialog();
                Window.GetWindow(this).Opacity = 1;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void clearImg()
        {
            Uri resourceUri = new Uri("pic/no-image-icon-90x90.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            myBrush.ImageSource = temp;
            img_userLogin.Fill = myBrush;

        }

        private void Btn_applicationStop_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null)
                SectionData.StartAwait(grid_mainWindow);

            Window.GetWindow(this).Opacity = 0.2;
            wd_applicationStop w = new wd_applicationStop();
            w.ShowDialog();
            if (w.status == "o")
                txt_cashTitle.Foreground = Application.Current.Resources["MainColor"] as SolidColorBrush;
            else
                txt_cashTitle.Foreground = Application.Current.Resources["MainColorRed"] as SolidColorBrush;

            Window.GetWindow(this).Opacity = 1;

            if (sender != null)
                SectionData.EndAwait(grid_mainWindow);
        }
        private void Btn_transfers_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null)
                SectionData.StartAwait(grid_mainWindow);

            Window.GetWindow(this).Opacity = 0.2;
            wd_transfers w = new wd_transfers();
            w.ShowDialog();
            Window.GetWindow(this).Opacity = 1;

            if (sender != null)
                SectionData.EndAwait(grid_mainWindow);
        }
        private void Btn_deliveryWaitConfirmUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null)
                SectionData.StartAwait(grid_mainWindow);

            Window.GetWindow(this).Opacity = 0.2;
            wd_deliveryWaitConfirmUser w = new wd_deliveryWaitConfirmUser();
            w.ShowDialog();
            Window.GetWindow(this).Opacity = 1;

            refreshOrdersWaitNotification();
            if (sender != null)
                SectionData.EndAwait(grid_mainWindow);
        }

       

        public void BTN_purchases_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                colorTextRefreash(txt_purchases);
                FN_pathVisible(path_openPurchases);
                fn_ColorIconRefreash(path_iconPurchases);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_purchases.Instance);
                isHome = true;
                Button button = sender as Button;
                initializationMainTrack(button.Tag.ToString(), 0);

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        public void BTN_sales_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                colorTextRefreash(txt_sales);
                FN_pathVisible(path_openSales);
                fn_ColorIconRefreash(path_iconSales);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_sales.Instance);
                isHome = true;
                Button button = sender as Button;
                initializationMainTrack(button.Tag.ToString(), 0);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void BTN_delivery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                colorTextRefreash(txt_delivery);
                FN_pathVisible(path_openDelivery);
                fn_ColorIconRefreash(path_iconDelivery);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_delivery.Instance);
                isHome = true;
                Button button = sender as Button;
                initializationMainTrack(button.Tag.ToString(), 0);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void BTN_accounts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                colorTextRefreash(txt_accounting);
                FN_pathVisible(path_openAccount);
                fn_ColorIconRefreash(path_iconAccounts);
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_accounts.Instance);
                isHome = true;
                Button button = sender as Button;
                initializationMainTrack(button.Tag.ToString(), 0);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void BTN_reports_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                colorTextRefreash(txt_reports);
                FN_pathVisible(path_openReports);
                fn_ColorIconRefreash(path_iconReports);
                isHome = true;
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_reports.Instance);
                Button button = sender as Button;
                initializationMainTrack(button.Tag.ToString(), 0);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        public void BTN_settings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                colorTextRefreash(txt_settings);
                FN_pathVisible(path_openSettings);
                fn_ColorIconRefreash(path_iconSettings);
                isHome = true;
                grid_main.Children.Clear();
                grid_main.Children.Add(uc_settings.Instance);
                Button button = sender as Button;
                initializationMainTrack(button.Tag.ToString(), 0);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        public void BTN_storage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                initializationMainTrack(button.Tag.ToString(), 0);
                colorTextRefreash(txt_storage);
                FN_pathVisible(path_openStorage);
                fn_ColorIconRefreash(path_iconStorage);
                grid_main.Children.Clear();
                grid_main.Children.Add(View.uc_storage.Instance);
                isHome = true;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }

    }
}

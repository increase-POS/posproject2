using MaterialDesignThemes.Wpf;
using netoaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using Tulpep.NotificationWindow;

namespace POS.Classes
{
    class SectionData
    {
        public static bool iscodeExist = false;

        public static Agent agentModel = new Agent();
        public static Bonds bondModel = new Bonds();
        public static Branch branchModel = new Branch();
        public static Category categoryModel = new Category();
        public static Pos posModel = new Pos();
        public static Offer offerModel = new Offer();
        public static CashTransfer cashModel = new CashTransfer();

        public static Coupon couponModel = new Coupon();

        public static string code;

        public static BrushConverter bc = new BrushConverter();

        public static ImageBrush brush = new ImageBrush();
        /*
        public static void popUpResponse(string title, string content)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = title;
            popup.ContentText = content;
            //popup.ContentPadding = new Padding(0);
            //popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            //popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Popup();// show  
        }
        */
        public static long genRandomCode(string type)
        {
            Random rnd = new Random();
            long randomNum = rnd.Next(0, 999999999);
            isCodeExist(randomNum.ToString(), type);
            if (!iscodeExist)
                code = randomNum.ToString();
            else genRandomCode(type);

            return randomNum;

        }

        public static async void isCodeExist(string randomNum, string type)
        {
            try
            {
                List<Agent> agents = await agentModel.GetAgentsAsync(type);
                Agent agent = new Agent();
                List<string> codes = new List<string>();
                for (int i = 0; i < agents.Count; i++)
                {
                    agent = agents[i];
                    codes.Add(agent.code.Trim());
                }
                if (codes.Contains(randomNum.Trim()))
                    iscodeExist = true;
                else
                    iscodeExist = false;
            }
            catch { }
        }

        public static long genRandomCode(string type, string _class)
        {
            Random rnd = new Random();
            long randomNum = rnd.Next(0, 999999999);
            isCodeExist(randomNum.ToString(), type, _class);
            if (!iscodeExist)
                code = randomNum.ToString();
            else genRandomCode(type, _class);

            return randomNum;

        }

        public static async Task<bool> isCodeExist(string randomNum, string type, string _class, int id)
        {
            iscodeExist = false;
            try
            {
                List<string> codes = new List<string>();

                if (_class.Equals("Agent"))
                {
                    List<Agent> agents = await agentModel.GetAgentsAsync(type);
                    //Agent agent = new Agent();
                    //for (int i = 0; i < agents.Count; i++)
                    //{
                    //    agent = agents[i];
                    //    codes.Add(agent.code.Trim());
                    //}
                    if (agents.Any(a => a.code == randomNum && a.agentId != id))
                        iscodeExist = true;
                    else
                        iscodeExist = false;
                }
                else if (_class.Equals("Branch"))
                {
                    List<Branch> branches = await branchModel.GetBranchesAsync(type);

                    //Branch branch = new Branch();
                    //for (int i = 0; i < branches.Count; i++)
                    //{
                    //    branch = branches[i];
                    //    if (branch.branchId != id)
                    //        codes.Add(branch.code.Trim());
                    //}
                    if (branches.Any(b => b.code == randomNum && b.branchId != id))
                        iscodeExist = true;
                    else
                        iscodeExist = false;
                }
                else if (_class.Equals("Category"))
                {
                    List<Category> categories = await categoryModel.GetAllCategories();

                    //Category category = new Category();
                    //for (int i = 0; i < categories.Count; i++)
                    //{
                    //    category = categories[i];
                    //    if (category.categoryId != id)
                    //        codes.Add(category.categoryCode.Trim());
                    //}
                    if (categories.Any(c => c.categoryCode == randomNum && c.categoryId != id))
                        iscodeExist = true;
                    else
                        iscodeExist = false;
                }
                else if (_class.Equals("Pos"))
                {
                    List<Pos> poss = await posModel.GetPosAsync();

                    //    Pos pos = new Pos();
                    //    for (int i = 0; i < poss.Count; i++)
                    //    {
                    //        pos = poss[i];
                    //        if (pos.posId != id)
                    //            codes.Add(pos.code.Trim());
                    //    }
                    if (poss.Any(p => p.code == randomNum && p.posId != id))
                        iscodeExist = true;
                    else
                        iscodeExist = false;
                }
                //if (codes.Contains(randomNum.Trim()))
                //    iscodeExist = true;
                //else
                //    iscodeExist = false;

            }
            catch { }
            return iscodeExist;
        }
        public static async Task<bool> isCodeExist(string randomNum, string type, string _class)
        {
            iscodeExist = false;
            try
            {
                List<string> codes = new List<string>();

                if (_class.Equals("Agent"))
                {
                    List<Agent> agents = await agentModel.GetAgentsAsync(type);
                    Agent agent = new Agent();
                    for (int i = 0; i < agents.Count; i++)
                    {
                        agent = agents[i];
                        codes.Add(agent.code.Trim());
                    }
                }
                else if (_class.Equals("Branch"))
                {
                    List<Branch> branches = await branchModel.GetBranchesAsync(type);

                    Branch branch = new Branch();
                    for (int i = 0; i < branches.Count; i++)
                    {
                        branch = branches[i];
                        codes.Add(branch.code.Trim());
                    }
                }
                else if (_class.Equals("Offer"))
                {
                    List<Offer> offers = await offerModel.GetOffersAsync();

                    Offer offer = new Offer();
                    for (int i = 0; i < offers.Count; i++)
                    {
                        offer = offers[i];
                        codes.Add(offer.code.Trim());
                    }
                }

                if (codes.Contains(randomNum.Trim()))
                    iscodeExist = true;
                else
                    iscodeExist = false;

            }
            catch { }
            return iscodeExist;
        }
        public static async Task<bool> CouponCodeNotExist(string randomNum, int id)
        {
            try
            {
                Coupon coupon = new Coupon();
                coupon = await couponModel.Existcode(randomNum);
                if ((coupon.code.Trim() == randomNum.Trim()) && (coupon.cId != id))
                {
                    return false;
                }
                else return true;

            }
            catch { return true; }
        }

        public static async Task<bool> chkIfCouponBarCodeIsExist(string randomNum, int id)
        {
            Coupon coupon = new Coupon();
            coupon = await couponModel.getCouponByBarCode(randomNum);
            try
            {
                if ((coupon.barcode.Trim() == randomNum.Trim()) && (coupon.cId != id))
                {
                    return true;
                }
                else return false;
            }
            catch { return false; }
        }


        public static bool IsValid(string txt)
        {//for email
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                   RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool isValidEmail = regex.IsMatch(txt);

            if (!isValidEmail) return false;

            else return true;

        }
        public static void SetError(Control c, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = MainWindow.resourcemanager.GetString(tr);
            c.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }

        public static bool validateEmptyTextBox(TextBox tb, Path p_error, ToolTip tt_error, string tr)
        {
            bool isValid = true;
            if (tb.Text.Equals(""))
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = MainWindow.resourcemanager.GetString(tr);
                tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
                isValid = false;
            }
            else
            {
                tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;
            }
            return isValid;
        }
        public static bool validateEmptyComboBox(ComboBox cb, Path p_error, ToolTip tt_error, string tr)
        {
            bool isValid = true;

            if (cb.SelectedIndex == -1)
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = MainWindow.resourcemanager.GetString(tr);
                cb.Background = (Brush)bc.ConvertFrom("#15FF0000");
                isValid = false;
            }
            else
            {
                cb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;

            }
            return isValid;
        }
        public static bool validateEmptyPassword(PasswordBox pb, Path p_error, ToolTip tt_error, string tr)
        {
            bool isValid = true;

            if (pb.Password.Equals(""))
            {
                SectionData.showPasswordValidate(pb, p_error, tt_error, "trEmptyPasswordToolTip");
                p_error.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                SectionData.clearPasswordValidate(pb, p_error);
                p_error.Visibility = Visibility.Collapsed;
            }
            return isValid;
        }
        public static bool validateEmail(TextBox tb, Path p_error, ToolTip tt_error)
        {
            bool isValid = true;
            if (!tb.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb.Text))
                {
                    p_error.Visibility = Visibility.Visible;
                    tt_error.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                    tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
                isValid = false;
                }
                else
                {
                    p_error.Visibility = Visibility.Collapsed;
                    tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                isValid = true;
                }
            }
            return isValid;
        }
        public static void validateEmptyDatePicker(DatePicker dp, Path p_error, ToolTip tt_error, string tr)
        {
            TextBox tb = (TextBox)dp.Template.FindName("PART_TextBox", dp);
            if (tb.Text.Trim().Equals(""))
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = MainWindow.resourcemanager.GetString(tr);
                tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;
            }
        }
        public static void validateSmalThanDateNowDatePicker(DatePicker dp, Path p_error, ToolTip tt_error, string tr)
        {
            TextBox tb = (TextBox)dp.Template.FindName("PART_TextBox", dp);
            if (dp.SelectedDate < DateTime.Now)
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = MainWindow.resourcemanager.GetString(tr);
                tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;
            }
        }
        public static void clearValidate(TextBox tb , Path p_error)
        {
            tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            p_error.Visibility = Visibility.Collapsed;
        }
        public static void clearPasswordValidate(PasswordBox pb, Path p_error)
        {
            pb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            p_error.Visibility = Visibility.Collapsed;
        }
        public static void clearComboBoxValidate(ComboBox cb, Path p_error)
        {
            cb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            p_error.Visibility = Visibility.Collapsed;
        }
        public static void showTextBoxValidate(TextBox tb, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = MainWindow.resourcemanager.GetString(tr);
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }
        public static void showPasswordValidate(PasswordBox tb, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = MainWindow.resourcemanager.GetString(tr);
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }
        public static void showComboBoxValidate(ComboBox cb, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = MainWindow.resourcemanager.GetString(tr);
            cb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }

        public static void showDatePickerValidate(DatePicker dp, Path p_error, ToolTip tt_error, string tr)
        {
            TextBox tb = (TextBox)dp.Template.FindName("PART_TextBox", dp);

            p_error.Visibility = Visibility.Visible;
            tt_error.Content = MainWindow.resourcemanager.GetString(tr);
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }

        public static void showTimePickerValidate(TimePicker tp, Path p_error, ToolTip tt_error, string tr)
        {
            TextBox tb = (TextBox)tp.Template.FindName("PART_TextBox", tp);

            p_error.Visibility = Visibility.Visible;
            tt_error.Content = MainWindow.resourcemanager.GetString(tr);
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }

       

     

        public static void validateDuplicateCode(TextBox tb, Path p_error, ToolTip tt_error ,string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = MainWindow.resourcemanager.GetString(tr);
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }

        public static void getMobile(string _mobile , ComboBox _area , TextBox _tb)
        {//mobile
            if ((_mobile != null))
            {
                string area = _mobile;
                string[] pharr = area.Split('-');
                int j = 0;
                string phone = "";

                foreach (string strpart in pharr)
                {
                    if (j == 0)
                    {
                        area = strpart;
                    }
                    else
                    {
                        phone = phone + strpart;
                    }
                    j++;
                }

                _area.Text = area;

                _tb.Text = phone.ToString();
            }
            else
            {
                _area.SelectedIndex = -1;
                _tb.Clear();
            }
        }

        public static void getPhone(string _phone , ComboBox _area , ComboBox _areaLocal , TextBox _tb)
        {//phone
            if ((_phone != null))
            {
                string area = _phone;
                string[] pharr = area.Split('-');
                int j = 0;
                string phone = "";
                string areaLocal = "";
                foreach (string strpart in pharr)
                {
                    if (j == 0)
                        area = strpart;
                    else if (j == 1)
                        areaLocal = strpart;
                    else
                        phone = phone + strpart;
                    j++;
                }

                _area.Text = area;
                _areaLocal.Text = areaLocal;
                _tb.Text = phone.ToString();
            }
            else
            {
                _area.SelectedIndex = -1;
                _areaLocal.SelectedIndex = -1;
                _tb.Clear();
            }
        }

        public static async void getImg(string type, string imageUri, Button button)
        {
            try
            {

                //if (string.IsNullOrEmpty(category.image))
                //{
                //    SectionData.clearImg(button);
                //}
                //else
                //{

                if (type.Equals("Category"))
                {
                    Category category = new Category();
                    byte[] imageBuffer = await category.downloadImage(imageUri); // read this as BLOB from your DB
                    var bitmapImage = new BitmapImage();
                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    button.Background = new ImageBrush(bitmapImage);
                }
                else if (type.Equals("Item"))
                {
                    Item item = new Item();
                    byte[] imageBuffer = await item.downloadImage(imageUri); // read this as BLOB from your DB
                    var bitmapImage = new BitmapImage();
                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    button.Background = new ImageBrush(bitmapImage);
                }
                else if (type.Equals("User"))
                {
                    User user = new User();
                    byte[] imageBuffer = await user.downloadImage(imageUri); // read this as BLOB from your DB
                    var bitmapImage = new BitmapImage();
                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    button.Background = new ImageBrush(bitmapImage);
                }
                else if (type.Equals("Agent"))
                {
                    Agent agent = new Agent();
                    byte[] imageBuffer = await agent.downloadImage(imageUri); // read this as BLOB from your DB
                    var bitmapImage = new BitmapImage();
                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    button.Background = new ImageBrush(bitmapImage);
                }

                //}
            }
            catch
            {
                clearImg(button);
            }
        }


        public static void clearImg(Button img)
        {
            Uri resourceUri = new Uri("pic/no-image-icon-125x125.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            img.Background = brush;
        }
        public static decimal calcPercentage(decimal value, decimal percentage)
        {
            decimal percentageVal = (value * percentage) / 100;

            return percentageVal;
        }
        public static void defaultDatePickerStyle(DatePicker dp)
        {
            dp.Loaded += delegate
            {

                var textBox1 = (TextBox)dp.Template.FindName("PART_TextBox", dp);
                if (textBox1 != null)
                {
                    textBox1.Background = dp.Background;
                    textBox1.BorderThickness = dp.BorderThickness;
                }
            };
        }

        public static async Task<string> generateNumber(char opperationType , string side)
        {
            List<CashTransfer> cashes = new List<CashTransfer>();
            Branch b = new Branch();
            b = await branchModel.getBranchById(MainWindow.branchID.Value);

            string str1 = b.code;

            string str2 = opperationType + side; ;

            string str3 = "";
            cashes = await cashModel.GetCashTransferAsync(Convert.ToString(opperationType), side);
            str3 = (cashes.Count()+1).ToString();

            return str1 + str2 + str3;
        }

        public static async Task<string> generateNumberBond(char opperationType, string side)
        {
            IEnumerable<CashTransfer> cashes;
            //IEnumerable<CashTransfer> cashesQuery;

            Branch b = new Branch();
            b = await branchModel.getBranchById(MainWindow.branchID.Value);

            string str1 = b.code;

            string str2 = opperationType + side; 

            string str3 = "";
            cashes = await cashModel.GetCashTransferAsync(Convert.ToString(opperationType), "all");
            cashes = cashes.Where(s => s.processType == "doc");

            str3 = (cashes.Count() + 1).ToString();

            return str1 + str2 + str3;
        }

        static public void searchInComboBox(ComboBox cbm)
        {
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(cbm.Items);
            itemsViewOriginal.Filter = ((o) =>
            {
                if (String.IsNullOrEmpty(cbm.Text)) return true;
                else
                {
                    if (((string)o).Contains(cbm.Text)) return true;
                    else return false;
                }
            });
            itemsViewOriginal.Refresh();
        }
       static public bool isAdminPermision()
        {
            if (MainWindow.userLogin.userId == 1 || MainWindow.userLogin.userId == 2)
                return true;
            return false;
        }

        static List<Branch> branches;
        static public async void fillBranches(ComboBox combo, string type )
        {
            if (isAdminPermision())
            branches = await branchModel.GetAll();
            else
                branches = await branchModel.BranchesByBranchandUser(MainWindow.branchID.Value, MainWindow.userLogin.userId);

            combo.ItemsSource = branches.Where(b => b.type != type && b.branchId != 1);
            combo.SelectedValuePath = "branchId";
            combo.DisplayMemberPath = "name";
            combo.SelectedIndex = -1;
        }
        /// <summary>
        /// لمنع  الصفر بالبداية
        /// </summary>
        /// <param name="txb"></param>
        static public void InputJustNumber(ref TextBox txb)
        {
            if (txb.Text.Count() == 2 && txb.Text == "00")
            {
                string myString = txb.Text;
                myString = Regex.Replace(myString, "00", "0");
                txb.Text = myString;
                txb.Select(txb.Text.Length, 0);
                txb.Focus();
            }
        }
        
        static public void ExceptionMessage(Exception ex ,object window, object sender = null)
        {
            string _window , _sender = "";

            _window = window.GetType().Name;

            if (!string.IsNullOrEmpty(sender.ToString()))
                if (sender.GetType().Name == "TextBox")
                    _sender = (sender as TextBox).Name;
                else if (sender.GetType().Name == "ComboBox")
                    _sender = (sender as ComboBox).Name;
                else if (sender.GetType().Name == "DatePicker")
                    _sender = (sender as DatePicker).Name;
                else if (sender.GetType().Name == "DataGrid")
                    _sender = (sender as DataGrid).Name;
                else if (sender.GetType().Name == "ToggleButton")
                    _sender = (sender as ToggleButton).Name;
                else
                    _sender = sender.GetType().Name;

           

            //Message
            if (ex.HResult == -2146233088)
                Toaster.ShowWarning(MainWindow.mainWindow, message: MainWindow.resourcemanager.GetString("trNoInternetConnection"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowWarning(MainWindow.mainWindow, message: ex.HResult + " || " + ex.Message, animation: ToasterAnimation.FadeIn);
        }
        static public void StartAwait(Grid grid)
        {
            grid.IsEnabled = false;
            grid.Opacity = 0.6;
            MahApps.Metro.Controls.ProgressRing progressRing = new MahApps.Metro.Controls.ProgressRing();
            progressRing.Name = "prg_awaitRing";
            progressRing.Foreground = App.Current.Resources["MainColorBlue"] as Brush;
            progressRing.IsActive = true;
            Grid.SetRowSpan(progressRing, 10);
            Grid.SetColumnSpan(progressRing, 10);
            grid.Children.Add(progressRing);

        }
        static public void EndAwait(Grid grid, Window window)
        {
            grid.IsEnabled = true;
            grid.Opacity = 1;
            MahApps.Metro.Controls.ProgressRing progressRing = FindControls.FindVisualChildren<MahApps.Metro.Controls.ProgressRing>(window)
                .Where(x => x.Name == "prg_awaitRing").FirstOrDefault();
            grid.Children.Remove(progressRing);
        }
        static public void EndAwait(Grid grid, UserControl window)
        {
            grid.IsEnabled = true;
            grid.Opacity = 1;
            MahApps.Metro.Controls.ProgressRing progressRing = FindControls.FindVisualChildren<MahApps.Metro.Controls.ProgressRing>(window)
                .Where(x => x.Name == "prg_awaitRing").FirstOrDefault();
            grid.Children.Remove(progressRing);
        }

    }
}

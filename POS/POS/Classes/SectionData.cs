﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        public static Branch branchModel = new Branch();
        public static Category categoryModel = new Category();
        public static Pos posModel = new Pos();

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
        //public static async Task<bool> chkIfCouponBarCodeIsExist(string randomNum)
        //{
        //    //try
        //    //{
        //    Coupon coupon = new Coupon();
        //    coupon = await couponModel.getCouponByBarCode(randomNum);
        //    if (coupon != null)
        //    {
        //        return true;
        //    }
        //    else return false;

        //    //}
        //    //catch { return false; }

        //}
        public static void validateEmptyDatePicker(DatePicker dp, Path p_error, ToolTip tt_error, string tr)
        {
            TextBox tb = (TextBox)dp.Template.FindName("PART_TextBox", dp);
            if (dp.Text.Equals(""))
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

        public static async Task<bool> isCodeExist(string randomNum, string type, string _class , int id)
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
                        if (branch.branchId != id)
                            codes.Add(branch.code.Trim());
                    }
                }
                else if (_class.Equals("Category"))
                {
                    List<Category> categories = await categoryModel.GetAllCategories();

                    Category category = new Category();
                    for (int i = 0; i < categories.Count; i++)
                    {
                        category = categories[i];
                        if (category.categoryId != id)
                            codes.Add(category.categoryCode.Trim());
                    }
                }
                else if (_class.Equals("Pos"))
                {
                    List<Pos> poss = await posModel.GetPosAsync();

                    Pos pos = new Pos();
                    for (int i = 0; i < poss.Count; i++)
                    {
                        pos = poss[i];
                        if (pos.posId != id)
                            codes.Add(pos.code.Trim());
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

                if (codes.Contains(randomNum.Trim()))
                    iscodeExist = true;
                else
                    iscodeExist = false;

            }
            catch { }
            return iscodeExist;
        }
        public static async Task<bool> CouponCodeNotExist(string randomNum)
        {
            iscodeExist = false;
            try
            {
                Coupon coupon = new Coupon();
                coupon = await couponModel.Existcode(randomNum);
                if (coupon.code == randomNum)
                {
                    return false;
                }
                else return true;

            }
            catch { return true; }
            //return "no";
        }

        public static bool IsValid(string txt)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                   RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool isValidEmail = regex.IsMatch(txt);

            if (!isValidEmail) return false;

            else return true;

        }

        public static void validateEmptyTextBox(TextBox tb , Path p_error , ToolTip tt_error , string tr)
        {
            if (tb.Text.Equals(""))
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

        public static void validateEmptyComboBox(ComboBox cb, Path p_error, ToolTip tt_error, string tr)
        {
            if (cb.SelectedIndex == -1)
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = MainWindow.resourcemanager.GetString(tr);
                cb.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                cb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;

            }
        }

        public static void validateEmail(TextBox tb, Path p_error, ToolTip tt_error)
        {
            if (!tb.Text.Equals(""))
            {
                if (!ValidatorExtensions.IsValid(tb.Text))
                {
                    p_error.Visibility = Visibility.Visible;
                    tt_error.Content = MainWindow.resourcemanager.GetString("trErrorEmailToolTip");
                    tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
                }
                else
                {
                    p_error.Visibility = Visibility.Collapsed;
                    tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                }
            }
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

        #region Image refresh 

        public static async void getImg(string type , string imageUri , Button button)
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
        #endregion
    }
}

﻿using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_userInfo.xaml
    /// </summary>
    public partial class wd_userInfo : Window
    {
        public wd_userInfo()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }
        BrushConverter bc = new BrushConverter();
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region translate

                if (winLogIn.lang.Equals("en"))
                {
                    winLogIn.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    winLogIn.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }

                //translate();
                #endregion

                txt_userName.Text = MainWindow.userLogin.fullName;
                txt_pos.Text = MainWindow.posLogIn.name;
                txt_branch.Text = MainWindow.posLogIn.branchName;
                userImageLoad(bdr_mainImage, MainWindow.userLogin.image);

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
        private void translate()
        {

        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    //Btn_save_Click(null, null);
                }
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }
        List<SettingCls> set = new List<SettingCls>();
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = true;
                this.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        ImageBrush brush = new ImageBrush();
        async void userImageLoad(Border border, string image)
        {
            try
            {
                if (!string.IsNullOrEmpty(image))
                {
                    clearImg(border);

                    byte[] imageBuffer = await MainWindow.userLogin.downloadImage(image); // read this as BLOB from your DB
                    var bitmapImage = new BitmapImage();
                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    border.Background = new ImageBrush(bitmapImage);
                }
                else
                {
                    clearImg(border);
                }
            }
            catch
            {
                clearImg(border);
            }
        }
        private void clearImg(Border border)
        {
            Uri resourceUri = new Uri("/pic/no-image-icon-125x125.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            border.Background = brush;
        }



    }
}

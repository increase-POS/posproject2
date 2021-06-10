﻿using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WIA;
using System.Web.UI.WebControls;
using System.Windows.Resources;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_uploadImage.xaml
    /// </summary>
    public partial class wd_uploadImage : Window
    {
        public string tableName { get; set; }      
        public int tableId { get; set; }
        public string docNum { get; set; }

        private int docId=0;

        DocImage docImgModel = new DocImage();
       List<DocImage> imageList;
       
        ImageBrush brush = new ImageBrush();

        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        public wd_uploadImage()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await refreshImageList();
        }
        private void Img_upload_Click(object sender, RoutedEventArgs e)
        {

            //select image
            openFileDialog.Filter = "Images|*.png;*.jpg;*.bmp;*.jpeg;*.jfif";

            if (openFileDialog.ShowDialog() == true)
            {
                brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                img_upload.Background = brush;
            }
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            docId = 0;
            //docImgModel.tableName = "invoices";
            docImgModel.tableName = tableName;
            docImgModel.tableId = tableId;
            docImgModel.docnum = docNum;
            docImgModel.createUserId = MainWindow.userID;

            string res = await docImgModel.saveDocImage(docImgModel);
            if (!res.Equals("0"))
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            int docImageId = int.Parse(res);

            await docImgModel.uploadImage(openFileDialog.FileName,tableName ,docImageId);

            //refresh image list
             await refreshImageList();
        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (docId != 0)
            {
                Boolean res = await docImgModel.delete(docId);

                if (res)
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                else
                    Toaster.ShowError(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                docId = 0;
                //clear img
                Uri resourceUri = new Uri("/pic/no-image-icon-125x125.png", UriKind.Relative);
                StreamResourceInfo streamInfo = System.Windows.Application.GetResourceStream(resourceUri);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                brush.ImageSource = temp;
                img_upload.Background = brush;

                //refresh images
                await refreshImageList();
            }
        }
       

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async Task refreshImageList()
        {
            int sequence = 0;
            lst_images.Items.Clear();

            imageList = await docImgModel.GetDocImages(tableName, tableId);

            foreach (DocImage doc in imageList)
            {
                sequence++;
                lst_images.Items.Add(sequence);
            }
        }
        private async void getImg(string imageName)
        {
            byte[] imageBuffer = await docImgModel.downloadImage(imageName); // read this as BLOB from your DB

            var bitmapImage = new BitmapImage();
            if (imageBuffer != null)
            {
                using (var memoryStream = new MemoryStream(imageBuffer))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.EndInit();
                }

            img_upload.Background = new ImageBrush(bitmapImage);
            }
        }
        // display image in IMG_customer 
        private void Lst_images_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lst_images.SelectedIndex != -1)
            {
                docId = imageList[lst_images.SelectedIndex].id;
                string imageName = imageList[lst_images.SelectedIndex].image;
                getImg(imageName);
            }
        }
        private void Btn_scan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonDialogClass commonDialogClass = new CommonDialogClass();
                Device scannerDevice = commonDialogClass.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, false, false);
                if (scannerDevice != null)
                {
                    WIA.Item scannnerItem = scannerDevice.Items[1];
                    AdjustScannerSettings(scannnerItem, 600, 0, 0, 1010, 620, 0, 0);
                    object scanResult = commonDialogClass.ShowTransfer(scannnerItem, WIA.FormatID.wiaFormatPNG, false);
                    if (scanResult != null)
                    {
                        ImageFile image = (ImageFile)scanResult;

                        var imageBytes = (byte[])image.FileData.get_BinaryData();// <-- Converts the ImageFile to a byte array
                        var bitmapImage = new BitmapImage();
                        if (imageBytes != null)
                        {
                            using (var memoryStream = new MemoryStream(imageBytes))
                            {
                                bitmapImage.BeginInit();
                                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                                bitmapImage.StreamSource = memoryStream;
                                bitmapImage.EndInit();
                            }

                            img_upload.Background = new ImageBrush(bitmapImage);
                        }
                        // configure trmporery path
                        string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        string tmpPath = System.IO.Path.Combine(dir, Global.ScannedImageLocation);
                        if (System.IO.File.Exists(tmpPath))
                        {
                            System.IO.File.Delete(tmpPath);
                        }
                        SaveImageToJpgFile(image, tmpPath);
                        openFileDialog.FileName = tmpPath;
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                System.Windows.MessageBox.Show("Problem with scanning device. Please ensure that the scanner is properly connected and switched on", "Inweon Grain Management System");
            }
            
        }
        private static void SaveImageToJpgFile(ImageFile image, string fileName)
        {
            WIA.ImageProcess imgProcess = new WIA.ImageProcess();
            object convertFilter = "Convert";
            string convertFilterID = imgProcess.FilterInfos.get_Item(ref convertFilter).FilterID;
            imgProcess.Filters.Add(convertFilterID, 0);
            SetWIAProperty(imgProcess.Filters[imgProcess.Filters.Count].Properties, "FormatID", WIA.FormatID.wiaFormatJPEG);
            image = imgProcess.Apply(image);
            image.SaveFile(fileName);
        }
        private static void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel,
             int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents)
        {
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
            const string WIA_SCAN_BIT_DEPTH = "4104";
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
            //SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BIT_DEPTH, 48);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);
        }
        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
           WIA.Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

        private void Btn_scanner_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Lst_images_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}

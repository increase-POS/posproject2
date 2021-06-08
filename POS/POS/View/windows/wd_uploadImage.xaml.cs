using POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WIA;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_uploadImage.xaml
    /// </summary>
    public partial class wd_uploadImage : Window
    {
        private static int _Resolution = 150;
        private static int _PixelWidth = 1250;
        private static int _PixelHeight = 1700;
        int cmbCMIndex = 0;
        public wd_uploadImage()
        {
            InitializeComponent();
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void Img_upload_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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
                       // SaveImageToJpgFile(image, Constants.ScannedImageLocation);
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Problem with scanning device. Please ensure that the scanner is properly connected and switched on", "Inweon Grain Management System");
            }
            
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
    }
}

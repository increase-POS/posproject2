using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace POS.Classes
{
    class ReportCls
    {

        public string PathUp(string path, int levelnum, string addtopath)
        {
            int pos1 = 0;
            for (int i = 1; i <= levelnum; i++)
            {
                pos1 = path.LastIndexOf("\\");
                path = path.Substring(0, pos1);
            }

            string newPath = path + addtopath;
            return newPath;
        }

        public string TimeToString(TimeSpan?  time)
        {

            TimeSpan ts = TimeSpan.Parse(time.ToString());
            // @"hh\:mm\:ss"
            string stime = ts.ToString(@"hh\:mm");
            return stime;
        }
        public string DateToString(DateTime? date)
        {
            string sdate = "";
           if (date != null)
            {
 DateTime ts = DateTime.Parse(date.ToString());
            // @"hh\:mm\:ss"
            sdate = ts.ToString(@"d/M/yyyy");
            }
           
            return sdate;
        }

        public string DecTostring(decimal? dec)
        {
            string sdc = "0";
            if (dec == null)
            {

            }
            else
            {
  decimal dc = decimal.Parse(dec.ToString());


           sdc = dc.ToString("0.00");
            }
         

            return sdc;
        }

        public string BarcodeToImage(string barcodeStr, string imagename)
        {
            // create encoding object
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            string addpath = @"\Thumb\" + imagename + ".png";
            string imgpath = this.PathUp(Directory.GetCurrentDirectory(), 2, addpath);
            if (File.Exists(imgpath))
            {
                File.Delete(imgpath);
            }
            if (barcodeStr != "")
            {
                System.Drawing.Bitmap serial_bitmap = (System.Drawing.Bitmap)barcode.Draw(barcodeStr, 60);
                // System.Drawing.ImageConverter ic = new System.Drawing.ImageConverter();

                serial_bitmap.Save(imgpath);

                //  generate bitmap
                //  img_barcode.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(serial_bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            else
            {

                imgpath = "";
            }
            if (File.Exists(imgpath))
            {
                return imgpath;
            }
            else
            {
                return "";
            }

        }
    }
}


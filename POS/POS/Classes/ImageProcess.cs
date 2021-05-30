using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    class ImageProcess
    {
        private int allowedFileSizeInByte;
        private string sourcePath;
        private string destinationPath = "Thumb";

        public ImageProcess(int allowedSize, string sourcePath)
        {
            allowedFileSizeInByte = allowedSize;
            this.sourcePath = sourcePath;
        }
        private void SaveImageToFile(MemoryStream ms,string filePath)
        {
            byte[] data = ms.ToArray();      
            using (FileStream fs = new FileStream(filePath, FileMode.Create,FileAccess.ReadWrite))
            {
                fs.Write(data, 0, data.Length);
            }
        }
        

        public Bitmap ScaleImage(Bitmap image)
        {
            int newWidth = (int)(allowedFileSizeInByte);
            int newHeight = (int)(allowedFileSizeInByte);

            Bitmap result = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics g = Graphics.FromImage(result))
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255)))
                {
                    g.FillRectangle(brush, 0, 0, newWidth, newHeight);
                }

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.DrawImage(image, 0, 0, result.Width, result.Height);

               

            }
            
            return result;
        }

        
        public void ScaleImage(string filePath)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                {
                    Bitmap bmp = (Bitmap)Image.FromStream(fs);
                    SaveTemporary(bmp, ms, 100);
                    // while (ms.Length > allowedFileSizeInByte)
                    // {
                    // double scale = Math.Sqrt
                    // ((double)allowedFileSizeInByte / (double)ms.Length);
                    ms.SetLength(0);
                    bmp = ScaleImage(bmp);
                    SaveTemporary(bmp, ms, 100);
                    // }

                    if (bmp != null)
                        bmp.Dispose();
                    SaveImageToFile(ms, filePath);
                }
            }
        }
        private void SaveTemporary(Bitmap bmp, MemoryStream ms, int quality)
        {
            EncoderParameter qualityParam = new EncoderParameter
                (System.Drawing.Imaging.Encoder.Quality, quality);
            var codec = GetImageCodecInfo();
            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            bmp.Save(ms, codec, encoderParams);
        }
        private ImageCodecInfo GetImageCodecInfo()
        {
            FileInfo fi = new FileInfo(sourcePath);

            switch (fi.Extension)
            {
                case ".bmp": return ImageCodecInfo.GetImageEncoders()[0];
                case ".jpg":
                case ".jpeg": return ImageCodecInfo.GetImageEncoders()[1];
                case ".gif": return ImageCodecInfo.GetImageEncoders()[2];
                case ".tiff": return ImageCodecInfo.GetImageEncoders()[3];
                case ".png": return ImageCodecInfo.GetImageEncoders()[4];
                default: return null;
            }
        }
    }
}

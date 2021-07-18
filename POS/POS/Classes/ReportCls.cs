using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Microsoft.Reporting.WinForms;
using System.Resources;
using System.Reflection;

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

        public string TimeToString(TimeSpan? time)
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


        public string BarcodeToImage28(string barcodeStr, string imagename)
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
        public static  bool checkLang()
        {
            bool isArabic;
            if (MainWindow.Reportlang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                isArabic = false;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                isArabic = true;
            }
            return isArabic;
        }

        public List<ReportParameter> fillPayReport(CashTransfer cashtrans)
        {
            checkLang();

            string title = MainWindow.resourcemanager.GetString("trPayVocher");
            string company_name = MainWindow.companyName;
            string comapny_address = MainWindow.Address;
            string company_phone = MainWindow.Address;
            string company_fax = MainWindow.Fax;
            string company_email = MainWindow.Email;
            string company_logo_img = GetLogoImagePath();
            string amount = cashtrans.cash.ToString();
            string voucher_num = cashtrans.transNum.ToString();
            string type = "";
            string isCash = "0";
            string trans_num_txt = "";

            string check_num = cashtrans.docNum;
            string date = cashtrans.createDate.ToString();
            string from = "";
            string amount_in_words = "";
            string purpose = "";
            string recived_by = "";
            string user_name = cashtrans.createUserName + " " + cashtrans.createUserLName;
            string job = "Employee"; //cashtrans.createUserJob;
            string pay_to;

            if (cashtrans.side == "u")
            {
                pay_to = cashtrans.usersName + " " + cashtrans.usersLName;

            }
            else if (cashtrans.side == "v" || cashtrans.side == "c")
            {
                pay_to = cashtrans.agentName;
            }
            else
            {
                pay_to = "";
            }
            if (cashtrans.processType == "cheque")
            {
                type = "Cheque";
                trans_num_txt = "Cheque Num:";

            }
            else if (cashtrans.processType == "card")
            {
                type = cashtrans.cardName;

                trans_num_txt = "Transfer Num:";

                // card name and number
            }
            else if (cashtrans.processType == "cash")
            {
                type = "Cash";
                isCash = "1";

            }
            else if (cashtrans.processType == "doc")
            {
                type = "Document";
                trans_num_txt = "Document Num:";

            }

            //  rep.DataSources.Add(new ReportDataSource("DataSetBank", banksQuery));

            List<ReportParameter> paramarr=null;
            paramarr.Add(new ReportParameter("lang", MainWindow.lang));
            paramarr.Add(new ReportParameter("title", title));
            paramarr.Add( new ReportParameter("company_name", company_name));
            paramarr.Add(new ReportParameter("comapny_address", comapny_address));
          paramarr.Add( new ReportParameter("company_phone", company_phone));
            paramarr.Add( new ReportParameter("company_fax", company_fax));
            paramarr.Add( new ReportParameter("company_email", company_email));
         paramarr.Add( new ReportParameter("company_logo_img", company_logo_img));
            paramarr.Add(new ReportParameter("amount", amount));
            paramarr.Add( new ReportParameter("voucher_num", voucher_num));
            paramarr.Add( new ReportParameter("type", type));
           paramarr.Add( new ReportParameter("check_num", check_num));
         paramarr.Add( new ReportParameter("date", date));
          paramarr.Add(new ReportParameter("from", from));
            paramarr.Add( new ReportParameter("amount_in_words", amount_in_words));
           paramarr.Add( new ReportParameter("purpose", purpose));
           paramarr.Add( new ReportParameter("recived_by", recived_by));
         paramarr.Add( new ReportParameter("purpose", purpose));
            paramarr.Add( new ReportParameter("user_name", user_name));
            paramarr.Add(new ReportParameter("pay_to", pay_to));
          paramarr.Add(new ReportParameter("job", job));
           paramarr.Add( new ReportParameter("isCash", isCash));
           paramarr.Add( new ReportParameter("trans_num_txt", trans_num_txt));
            return paramarr;
        }
        public static string NumberToWordsEN(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWordsEN(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWordsEN(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWordsEN(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWordsEN(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
        public static string NumberToWordsAR(int number)
        {
            if (number == 0)
                return "صفر";

            if (number < 0)
                return "ناقص " + NumberToWordsAR(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWordsAR(number / 1000000) + " مليون ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWordsAR(number / 1000) + " الف ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWordsAR(number / 100) + " مئة ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "و ";

                var unitsMap = new[] { "صفر", "واحد", "اثنان", "ثلاثة", "اربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة", "عشرة", "احدى عشر", "اثنا عشر", "ثلاثة عشر", "اربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
                var tensMap = new[] { "صفر", "عشرة", "عشرون", "ثلاثون", "اربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public string GetLogoImagePath()
        {
            string imageName = MainWindow.logoImage;
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string tmpPath = Path.Combine(dir, @"Thumb\setting");
            tmpPath = Path.Combine(tmpPath, imageName);
            /*
                  
                  
             * */

            //string addpath = @"\Thumb\setting\" ;

            return tmpPath;
        }

        //
        public List<ReportParameter> fillPurInvReport(Invoice invoice ,List<ReportParameter> paramarr)
        {
            checkLang();


           
             //  rep.DataSources.Add(new ReportDataSource("DataSetBank", banksQuery));

           
            paramarr.Add( new ReportParameter("invNumber", invoice.invNumber));//paramarr[6]
            paramarr.Add(new ReportParameter("invoiceId", invoice.invoiceId.ToString()));
             paramarr.Add( new ReportParameter("invDate", DateToString(invoice.invDate)));
            paramarr.Add( new ReportParameter("invTime", TimeToString(invoice.invTime)));
            paramarr.Add( new ReportParameter("vendorInvNum", invoice.vendorInvNum.ToString()));
             paramarr.Add( new ReportParameter("total", DecTostring(invoice.total)));
            paramarr.Add(new ReportParameter("discountValue", DecTostring(invoice.discountValue)));
            paramarr.Add( new ReportParameter("totalNet", DecTostring(invoice.totalNet)));
            paramarr.Add(new ReportParameter("paid", DecTostring(invoice.paid)));
            paramarr.Add( new ReportParameter("deserved", DecTostring(invoice.deserved)));
          paramarr.Add(new ReportParameter("deservedDate", invoice.deservedDate.ToString()));
             paramarr.Add( new ReportParameter("tax", "0"));
            paramarr.Add( new ReportParameter("barcodeimage", "file:\\" + BarcodeToImage(invoice.invNumber.ToString(), "invnum")));
            paramarr.Add( new ReportParameter("Currency",MainWindow.Currency));
            paramarr.Add( new ReportParameter("logoImage", "file:\\" +GetLogoImagePath()));


            return paramarr;
        }
    }
}


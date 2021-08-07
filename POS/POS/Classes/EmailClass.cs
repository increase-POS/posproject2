using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

using System.Net;
using System.IO;
namespace POS.Classes
{
    class MailimageClass
    {
        public string path { get; set; }
        public string imageId { get; set; }
        public string objectId { get; set; }

    }
        class EmailClass
    {
        public string smtpclient { get; set; }
        public string from { get; set; }

        public string password { get; set; }
       public List<string> Toemails=new List<string>();
        public List<string> CCemails = new List<string>();
        public List<string> BCCemails = new List<string>();
        public string subject { get; set; }
        public List<string> attachfiles = new List<string>();
   
        public string body { get; set; }
        public int port { get; set; }
        public bool isSSl { get; set; }

        public static string force_email = "no";
        public AlternateView htmlView;
        


        public string Sendmail()
        {
            string res = "";

            try
            {
          

             
                MailMessage mail = new MailMessage();

                SmtpClient Smtpserver = new SmtpClient(smtpclient);
                mail.From = new MailAddress(from);
            
                if (Toemails != null)
                {
                    foreach (string to in Toemails)
                    {
                        mail.To.Add(to);
                    }
                }
                if (CCemails != null)
                {
                    foreach (string ccto in CCemails)
                    {
                        mail.CC.Add(ccto);
                    }
                }
                if (BCCemails != null)
                {
                    foreach (string bcc in BCCemails)
                    {
                        mail.Bcc.Add(bcc);
                    }
                }
                if (attachfiles != null)
                {
                   
                 
                    foreach (string attachfile in attachfiles)
                    { Attachment attachment = new Attachment(attachfile);
                       
                        mail.Attachments.Add(attachment);
                    }
                }

                // replace placeholder
             

                mail.Subject = subject;
                mail.IsBodyHtml = true;
              //  mail.BodyEncoding = Encoding.UTF8;
               mail.Body = body;

                if (htmlView !=null)
                {
                        mail.AlternateViews.Add(htmlView);
                }
              

                Smtpserver.Port = port;
                Smtpserver.Credentials = new System.Net.NetworkCredential(from, password);
                Smtpserver.EnableSsl = isSSl;
                Smtpserver.Send(mail);
                res = "mail sent";
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }


        // System.Threading.Thread.Sleep(1000);

        }

        public  void AddTolist(string value)
        {
          
            Toemails.Add(value);
            
        }
public void AddrangeTolist(List<string> value)
            {
                
                Toemails.AddRange(value);
            }

        public void AddAttachTolist(string value)
        {
            
            attachfiles.Add(value);

        }
        public void AddAttachrangeTolist(List<string> value)
        {         
            attachfiles.AddRange(value);
        }
        public void AddCCTolist(string value)
        {
            
            CCemails.Add(value);

        }
        public void AddCCrangeTolist(List<string> value)
        {
           
            CCemails.AddRange(value);
        }
        public void AddBCCTolist(string value)
        {
         
            BCCemails.Add(value);

        }
        public void AddBCCrangeTolist(List<string> value)
        {
           
            BCCemails.AddRange(value);
        }
        public void ResetBCClist()
        {
            BCCemails = new List<string>();

        }
        public void ResetCClist()
        {
            CCemails = new List<string>();

        }
        public void ResetTolist()
        {
           Toemails = new List<string>();

        }
        public void Resetattachfileslist()
        {
            attachfiles = new List<string>();

        }

        
        public LinkedResource Linkimage(string path,string ContentId)
        {
           
            LinkedResource LinkedImage = new LinkedResource(@path);
            LinkedImage.ContentId = ContentId;
            //Added the patch for Thunderbird as suggested by Jorge
            LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
            return LinkedImage;
        }



        public EmailClass fillOrderTempData(Invoice invoice,List<ItemTransfer> invoiceItems,SysEmails email,Agent toAgent)
        {
            EmailClass mailtosend = new EmailClass();

            mailtosend.from = email.email;
            mailtosend.smtpclient = email.smtpClient;
            mailtosend.port = (int)email.port;

            mailtosend.password = Encoding.UTF8.GetString(Convert.FromBase64String(email.password));
            mailtosend.isSSl = (bool)email.isSSL;
            mailtosend.AddTolist(toAgent.email);
            mailtosend.subject = "Order" + DateTime.Now.ToString();


            // data
            ReportCls repm = new ReportCls();
            List<MailimageClass> imgs = new List<MailimageClass>();
            MailimageClass img = new MailimageClass();
            string invheader = repm.ReadFile(@"EmailTemplates\ordertemplate\invheader.tmp");
            string invfooter = repm.ReadFile(@"EmailTemplates\ordertemplate\invfooter.tmp");
            string invbody = repm.ReadFile(@"EmailTemplates\ordertemplate\invbody.tmp");
            string invitemtable = repm.ReadFile(@"EmailTemplates\ordertemplate\invitemtable.tmp");
            string invitemrow = repm.ReadFile(@"EmailTemplates\ordertemplate\invitemrow.tmp");

            //header info
            bool isArabic = ReportCls.checkLang();
            invheader = invheader.Replace("[[companyname]]", MainWindow.companyName.Trim());
            invheader = invheader.Replace("[[phone]]", MainWindow.Phone.Trim());
            invheader = invheader.Replace("[[Email]]", MainWindow.Email.Trim());
            invheader = invheader.Replace("[[fax]]", MainWindow.Fax.Trim());
            invheader = invheader.Replace("[[address]]", MainWindow.Address.Trim());
            invheader = invheader.Replace("[[trphone]]", MainWindow.resourcemanager.GetString("trPhone").Trim() + ": ");
            invheader = invheader.Replace("[[trfax]]", MainWindow.resourcemanager.GetString("trFax").Trim() + ": ");
            invheader = invheader.Replace("[[traddress]]", MainWindow.resourcemanager.GetString("trAddress").Trim() + ": ");


            //BODY
            string title = "Purchase Order";
            invheader = invheader.Replace("[[title]]", title.Trim());

            invbody = invbody.Replace("[[thankstitle]]", title);
            string thankstext = "Please provide to us,with a price list,along with your terms and conditions of sale, applicable discounts, shipping dates and additional sales and corporate policies. Should the information you provide be acceptable and competitive. ";

            invbody = invbody.Replace("[[thankstext]]", thankstext);


            if (invoice.invoiceId > 0)
            {
                invbody = invbody.Replace("[[invoicecode]]", invoice.invNumber);
                invbody = invbody.Replace("[[invoicedate]]", repm.DateToString(invoice.invDate));
                invbody = invbody.Replace("[[invoicetotal]]", invoice.total.ToString());
                invbody = invbody.Replace("[[invoicediscount]]", invoice.discountValue.ToString());
                invbody = invbody.Replace("[[invoicetax]]", invoice.tax.ToString());
                invbody = invbody.Replace("[[totalnet]]", invoice.totalNet.ToString());


            }

            //  invoiceItems.

            invitemtable = invitemtable.Replace("[[tritems]]", MainWindow.resourcemanager.GetString("trItem").Trim());
            invitemtable = invitemtable.Replace("[[trunit]]", MainWindow.resourcemanager.GetString("trUnit").Trim());
            invitemtable = invitemtable.Replace("[[trquantity]]", MainWindow.resourcemanager.GetString("trQuantity").Trim());
            invitemtable = invitemtable.Replace("[[trtotalrow]]", MainWindow.resourcemanager.GetString("trSum").Trim());

            invbody = invbody.Replace("[[trinvoicecode]]", MainWindow.resourcemanager.GetString("trInvoiceNumber").Trim() + ": ");
            invbody = invbody.Replace("[[trinvoicedate]]", MainWindow.resourcemanager.GetString("trInvoiceDate").Trim() + ": ");
            invbody = invbody.Replace("[[trinvoicetotal]]", MainWindow.resourcemanager.GetString("trSum").Trim() + ": ");
            invbody = invbody.Replace("[[currency]]", MainWindow.Currency);
            //
            invbody = invbody.Replace("[[trinvoicediscount]]", MainWindow.resourcemanager.GetString("trDiscount").Trim() + ": ");

            invbody = invbody.Replace("[[trinvoicetax]]", MainWindow.resourcemanager.GetString("trTax").Trim() + ": ");

            invbody = invbody.Replace("[[trtotalnet]]", MainWindow.resourcemanager.GetString("trTotal").Trim() + ": ");

            string invoicenote = "Thank you for your cooperation. We have also enclosed our procurement specifications and conditions for your review <br/> Sincerely";
            invbody = invbody.Replace("[[invoicenote]]", invoicenote);

            invfooter = invfooter.Replace("[[supporturl]]", "#");
            invfooter = invfooter.Replace("[[returnpolicyurl]]", "#");
            invfooter = invfooter.Replace("[[aboutusurl]]", "#");

            invfooter = invfooter.Replace("[[support]]", "Support");
            invfooter = invfooter.Replace("[[returnpolicy]]", "Returnpolicy");
            invfooter = invfooter.Replace("[[aboutus]]", "About Us");
            invfooter = invfooter.Replace("[[year]]", DateTime.Now.Year.ToString());


            //  invitemtable
            // foreach
            string datarows = "";
            foreach (ItemTransfer row in invoiceItems)
            {
                string rowhtml = invitemrow;
                rowhtml = rowhtml.Replace("[[col1]]", row.itemName.Trim());
                rowhtml = rowhtml.Replace("[[col2]]", row.unitName.Trim());
                rowhtml = rowhtml.Replace("[[col3]]", row.quantity.ToString());
                rowhtml = rowhtml.Replace("[[col4]]", (row.quantity * row.price).ToString());
                datarows += rowhtml;

            }
            invitemtable = invitemtable.Replace("[[invitemrow]]", datarows);
            // end foreach
            invbody = invbody.Replace("[[invitemtable]]", invitemtable);

            string mailbody = invheader + invbody + invfooter;



            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailbody, null, "text/html");
            string testpath = repm.GetPath(@"EmailTemplates\mail.html");
            //
            if (!File.Exists(testpath))
            {
                // Create a file to write to.
                string createText = mailbody;
                File.WriteAllText(testpath, createText);
            }
            else
            {
                File.Delete(testpath);
                // Create a file to write to.
                string createText = mailbody;
                File.WriteAllText(testpath, createText);
            }



            img.path = repm.GetLogoImagePath();
            img.imageId = "logo";
            imgs.Add(img);
            img = new MailimageClass();
            img.path = repm.GetPath(@"EmailTemplates\images\image-2.gif");
        
            img.imageId = "image-2";
            imgs.Add(img);

            foreach (MailimageClass row in imgs)
            {
                htmlView.LinkedResources.Add(mailtosend.Linkimage(@row.path, row.imageId));
            }

            // 

            mailtosend.htmlView = htmlView;

            
            return mailtosend;
          



        }
    }
}






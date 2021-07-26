using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

using System.Net;
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


                mail.AlternateViews.Add(htmlView);

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
    }
}






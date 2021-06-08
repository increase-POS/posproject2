using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace POS.Classes
{
    class DocImage
    {
        public int id { get; set; }
        public string docName { get; set; }
        public string docnum { get; set; }
        public string image { get; set; }
        public string tableName { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> tableId { get; set; }

        //***********************************************
        public async Task<string> saveDocImage(DocImage docImage)
        {
            string message = "";
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(docImage);

            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri(Global.APIUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
                HttpRequestMessage request = new HttpRequestMessage();
                // encoding parameter to get special characters
                myContent = HttpUtility.UrlEncode(myContent);
                request.RequestUri = new Uri(Global.APIUri + "DocImage/saveImageDoc?docImageObject=" + myContent);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    message = await response.Content.ReadAsStringAsync();
                    message = JsonConvert.DeserializeObject<string>(message);
                }
                return message;
            }
        }
        public async Task<Boolean> uploadImage(string imagePath, string tableName, int docImageId)
        {
            if (imagePath != "")
            {
               string imageName = Md5Encription.MD5Hash(tableName + docImageId.ToString());
                //string imageName = agentId.ToString();
                MultipartFormDataContent form = new MultipartFormDataContent();
                // get file extension
                var ext = imagePath.Substring(imagePath.LastIndexOf('.'));
                var extension = ext.ToLower();
                try
                {
                    // configure trmporery path
                    string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string tmpPath = Path.Combine(dir, Global.TMPFolder);
                    tmpPath = Path.Combine(tmpPath, imageName + extension);
                    if (System.IO.File.Exists(tmpPath))
                    {
                        System.IO.File.Delete(tmpPath);
                    }
                    // resize image
                    ImageProcess imageP = new ImageProcess(150, imagePath);
                    imageP.ScaleImage(tmpPath);

                    // read image file
                    var stream = new FileStream(tmpPath, FileMode.Open, FileAccess.Read);

                    // create http client request
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Global.APIUri);
                        client.Timeout = System.TimeSpan.FromSeconds(3600);
                        string boundary = string.Format("----WebKitFormBoundary{0}", DateTime.Now.Ticks.ToString("x"));
                        HttpContent content = new StreamContent(stream);
                        content.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        content.Headers.Add("client", "true");

                        string fileName = imageName + extension;
                        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            Name = imageName,
                            FileName = fileName
                        };
                        form.Add(content, "fileToUpload");

                        var response = await client.PostAsync(@"DocImage/PostImage", form);
                        if (response.IsSuccessStatusCode)
                        {
                            // save image name in DB
                            DocImage docImage = new DocImage();
                            docImage.id = docImageId;
                            docImage.image = fileName;
                            await updateImage(docImage);
                            //await saveAgent();
                            return true;
                        }
                    }
                    stream.Dispose();
                    //delete tmp image
                    if (System.IO.File.Exists(tmpPath))
                    {
                        System.IO.File.Delete(tmpPath);
                    }
                }
                catch (Exception ex) { return false; }
            }
            return false;
        }

        // update image field in DB
        public async Task<string> updateImage(DocImage docImage)
        {
            string message = "";

            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            string myContent = JsonConvert.SerializeObject(docImage);

            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri(Global.APIUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");

                HttpRequestMessage request = new HttpRequestMessage();

                // encoding parameter to get special characters
                myContent = HttpUtility.UrlEncode(myContent);

                request.RequestUri = new Uri(Global.APIUri + "DocImage/UpdateImage?docImageObject=" + myContent);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    message = await response.Content.ReadAsStringAsync();
                    message = JsonConvert.DeserializeObject<string>(message);
                }
                return message;
            }
        }
    }
}

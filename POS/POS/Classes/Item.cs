﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace POS.Classes
{
    public class Item
    {
        public int itemId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        public string type { get; set; }
        public string image { get; set; }
        public Nullable<decimal> taxes { get; set; }
        public Nullable<byte> isActive { get; set; }
        public Nullable<int> min { get; set; }
        public Nullable<int> max { get; set; }
        public Nullable<int> categoryId { get; set; }
        public string categoryName { get; set; }
        public Nullable<int> parentId { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> minUnitId { get; set; }
        public Nullable<int> maxUnitId { get; set; }
        public Boolean canDelete { get; set; }
        public string parentName { get; set; }
        public string minUnitName { get; set; }
        public string maxUnitName { get; set; }
        public Nullable<int> itemCount { get; set; }
        public Nullable<decimal> avgPurchasePrice { get; set; }
        // new units and offers an is new
        //units
        public Nullable<int> unitId { get; set; }
        public string unitName { get; set; }
        public Nullable<decimal> price { get; set; }
        //offer
        public Nullable<decimal> desPrice { get; set; }
        public Nullable<int> isNew { get; set; }
        public Nullable<int> isOffer { get; set; }
        public string offerName { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public byte? isActiveOffer { get; set; }
        public Nullable<int> itemUnitId { get; set; }
        public Nullable<int> offerId { get; set; }
        public Nullable<decimal> priceTax { get; set; }
        public Nullable<short> defaultSale { get; set; }
        public bool canUpdate { get; set; }

        public async Task<int> saveItem(Item item)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string method = "Items/Save";

            var myContent = JsonConvert.SerializeObject(item);
            parameters.Add("itemObject", myContent);
           return await APIResult.post(method, parameters);
        }
        public async Task<List<Item>> GetAllItems()
        {
            List<Item> items = new List<Item>();

            //########### to pass parameters (optional)
            //Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("itemObject", myContent);
            //IEnumerable<Claim> claims = await APIResult.getList("items/GetAllItems",parameters);
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("items/GetAllItems");

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Item>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Item>> GetSaleOrPurItems(int categoryId, short defaultSale, short defaultPurchase, int branchId)
        {
            List<Item> items = new List<Item>() ;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("categoryId", categoryId.ToString());
            parameters.Add("defaultSale", defaultSale.ToString());
            parameters.Add("defaultPurchase", defaultPurchase.ToString());
            parameters.Add("branchId", branchId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("items/GetSaleOrPurItems",parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Item>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;            
        }
        public async Task<int> deleteItem(int itemId, int userId,Boolean final)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", itemId.ToString());
            parameters.Add("userId", userId.ToString());
            parameters.Add("final", final.ToString());

            string method = "Items/Delete";
           return await APIResult.post(method, parameters);
            //string message = "false";
            //// ... Use HttpClient.
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            //using (var client = new HttpClient())
            //{
            //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //    client.BaseAddress = new Uri(Global.APIUri);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            //    client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
            //    HttpRequestMessage request = new HttpRequestMessage();
            //    request.RequestUri = new Uri(Global.APIUri + "Items/Delete?itemId=" + itemId + "&userId="+userId+"&final="+final);
            //    request.Headers.Add("APIKey", Global.APIKey);
            //    request.Method = HttpMethod.Post;
            //    //set content type
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    var response = await client.SendAsync(request);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        message = await response.Content.ReadAsStringAsync();
            //        message = JsonConvert.DeserializeObject<string>(message);
            //     bool   res = bool.Parse(message);

            //        return res;
            //    }
            //    return bool.Parse(message);   
            // }
        }

        // get codes of all items
        public async Task<List<string>> GetItemsCodes()
        {
            List<string> codes = new List<string>();

            IEnumerable<Claim> claims = await APIResult.getList("items/GetItemsCodes");

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    codes.Add(c.Value.ToString());
                }
            }
            return codes;    
        }
        // get items of type
        public async Task<List<Item>> GetItemsByType(string type)
        {
            List<Item> items = new List<Item>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("type", type);
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("items/GetItemsByType", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Item>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;  
        }
        public async Task<List<Item>> GetSubItems(int itemId)
        {
            List<Item> items = new List<Item>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", itemId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("items/GetSubItems", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Item>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }

        public async Task<Item> GetItemByID(int itemId)
        {
            Item item = new Item();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", itemId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("items/GetItemByID", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = JsonConvert.DeserializeObject<Item>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    break;
                }
            }
            return item;
        }
       
        public async Task<List<Item>> GetItemsWichHasUnits()
        {
            List<Item> items = new List<Item>();

            IEnumerable<Claim> claims = await APIResult.getList("items/GetItemsWichHasUnits");

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Item>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;        
        }
       
        // get items in category and sub
        public async Task<List<Item>> GetItemsInCategoryAndSub(int categoryId)
        {
            List<Item> items = new List<Item>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("categoryId", categoryId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("items/GetItemsInCategoryAndSub", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Item>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }

        #region image
        // update image field in DB
        public async Task<int> updateImage(Item item)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var myContent = JsonConvert.SerializeObject(item);
            parameters.Add("itemObject", myContent);

            string method = "Items/UpdateImage";
           return await APIResult.post(method, parameters); 
        }
        public async Task<Boolean> uploadImage(string imagePath, string imageName, int itemId)
        {
            if (imagePath != "")
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                // get file extension
                var ext = imagePath.Substring(imagePath.LastIndexOf('.'));
                var extension = ext.ToLower();
                try
                {
                    // configure trmporery path
                    string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string tmpPath = Path.Combine(dir, Global.TMPFolder);
                    string[] files = System.IO.Directory.GetFiles(tmpPath, imageName + ".*");
                    foreach (string f in files)
                    {
                        System.IO.File.Delete(f);
                    }
                    tmpPath = Path.Combine(tmpPath, imageName + extension);
                    //if (System.IO.File.Exists(tmpPath))
                    //{
                    //    System.IO.File.Delete(tmpPath);
                    //}
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

                        var response = await client.PostAsync(@"items/PostItemImage", form);
                        if (response.IsSuccessStatusCode)
                        {
                            // save image name in DB
                            Item item = new Item();
                            item.itemId = itemId;
                            item.image = fileName;
                            await updateImage(item);

                        }
                    }
                    stream.Dispose();
                    //delete tmp image
                    //if (System.IO.File.Exists(tmpPath))
                    //{
                    //    System.IO.File.Delete(tmpPath);
                    //}
                    return true;
                }
                catch
                { return false; }
            }
            return false;
        }
        public async Task<byte[]> downloadImage(string imageName)
        {
            Stream jsonString = null;
            byte[] byteImg = null;
            Image img = null;
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri(Global.APIUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri(Global.APIUri + "Items/GetImage?imageName=" + imageName);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStreamAsync();
                    img = Bitmap.FromStream(jsonString);
                    byteImg = await response.Content.ReadAsByteArrayAsync();

                    // configure trmporery path
                    string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string tmpPath = Path.Combine(dir, Global.TMPItemsFolder);
                    if (!Directory.Exists(tmpPath))
                        Directory.CreateDirectory(tmpPath);
                    if (!Directory.Exists(tmpPath))
                        Directory.CreateDirectory(tmpPath);
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(imageName);
                    string[] files = System.IO.Directory.GetFiles(tmpPath, fileName + ".*");
                    foreach (string f in files)
                    {
                        System.IO.File.Delete(f);
                    }
                    tmpPath = Path.Combine(tmpPath, imageName);
                    //if (System.IO.File.Exists(tmpPath))
                    //{
                    //    System.IO.File.Delete(tmpPath);
                    //}
                    using (FileStream fs = new FileStream(tmpPath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        fs.Write(byteImg, 0, byteImg.Length);
                    }
                }
                return byteImg;
            }
        }


        #endregion


        //service

        public async Task<List<Item>> GetAllSrItems()
        {
            List<Item> items = new List<Item>();

            IEnumerable<Claim> claims = await APIResult.getList("items/GetAllSrItems");

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Item>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }


        public async Task<List<Item>> GetSrItemsInCategoryAndSub(int categoryId)
        {
            List<Item> items = new List<Item>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("categoryId", categoryId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("items/GetSrItemsInCategoryAndSub", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Item>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }

    }
}

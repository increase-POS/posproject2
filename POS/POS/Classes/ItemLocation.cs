using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace POS.Classes
{
    public class ItemLocation
    {
        public int sequence { get; set; }
        public int itemsLocId { get; set; }
        public Nullable<int> locationId { get; set; }
        public Nullable<long> quantity { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<int> itemUnitId { get; set; }
        public string note { get; set; }
        public string itemName { get; set; }
        public string location { get; set; }
        public string section { get; set; }
        public string unitName { get; set; }

        public Nullable<int> sectionId { get; set; }
        public Nullable<decimal> storeCost { get; set; }
        public Nullable<byte> isFreeZone { get; set; }
        public string itemType { get; set; }
        public Nullable<bool> isSelected { get; set; }

        //****************************************************
        public async Task<List<ItemLocation>> get(int branchId)
        {
            List<ItemLocation> items = null;
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/Get?branchId=" + branchId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    jsonString = jsonString.Replace("\\", string.Empty);
                    jsonString = jsonString.Trim('"');
                    // fix date format
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter> { new BadDateFixingConverter() },
                        DateParseHandling = DateParseHandling.None
                    };
                    items = JsonConvert.DeserializeObject<List<ItemLocation>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return items;
                }
                else //web api sent error response 
                {
                    items = new List<ItemLocation>();
                }
                return items;
            }
        }
        public async Task<List<ItemLocation>> getAll(int branchId)
        {
            List<ItemLocation> items = null;
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/getAll?branchId=" + branchId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    jsonString = jsonString.Replace("\\", string.Empty);
                    jsonString = jsonString.Trim('"');
                    // fix date format
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter> { new BadDateFixingConverter() },
                        DateParseHandling = DateParseHandling.None
                    };
                    items = JsonConvert.DeserializeObject<List<ItemLocation>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return items;
                }
                else //web api sent error response 
                {
                    items = new List<ItemLocation>();
                }
                return items;
            }
        }
     //public async Task<List<ItemLocation>> getWithSequence(int branchId)
     //   {
     //       List<ItemLocation> items = null;
     //       // ... Use HttpClient.
     //       ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
     //       using (var client = new HttpClient())
     //       {
     //           ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
     //           client.BaseAddress = new Uri(Global.APIUri);
     //           client.DefaultRequestHeaders.Clear();
     //           client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
     //           client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
     //           HttpRequestMessage request = new HttpRequestMessage();
     //           request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/getWithSequence?branchId=" + branchId);
     //           request.Headers.Add("APIKey", Global.APIKey);
     //           request.Method = HttpMethod.Get;
     //           client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
     //           HttpResponseMessage response = await client.SendAsync(request);

     //           if (response.IsSuccessStatusCode)
     //           {
     //               var jsonString = await response.Content.ReadAsStringAsync();
     //               jsonString = jsonString.Replace("\\", string.Empty);
     //               jsonString = jsonString.Trim('"');
     //               // fix date format
     //               JsonSerializerSettings settings = new JsonSerializerSettings
     //               {
     //                   Converters = new List<JsonConverter> { new BadDateFixingConverter() },
     //                   DateParseHandling = DateParseHandling.None
     //               };
     //               items = JsonConvert.DeserializeObject<List<ItemLocation>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
     //               return items;
     //           }
     //           else //web api sent error response 
     //           {
     //               items = new List<ItemLocation>();
     //           }
     //           return items;
     //       }
     //   }
    
        public async Task<List<ItemLocation>> GetFreeZoneItems(int branchId)
        {
            List<ItemLocation> items = null;
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/GetFreeZoneItems?branchId=" + branchId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    jsonString = jsonString.Replace("\\", string.Empty);
                    jsonString = jsonString.Trim('"');
                    // fix date format
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter> { new BadDateFixingConverter() },
                        DateParseHandling = DateParseHandling.None
                    };
                    items = JsonConvert.DeserializeObject<List<ItemLocation>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return items;
                }
                else //web api sent error response 
                {
                    items = new List<ItemLocation>();
                }
                return items;
            }
        }
        public async Task<Boolean> decreaseAmounts(List<ItemTransfer> invoiceItems, int branchId, int userId)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(invoiceItems);

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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/decraseAmounts?itemLocationObject=" + myContent + "&branchId=" + branchId+ "&userId="+userId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<Boolean> unitsConversion(int branchId,int fromItemUnit , int toItemUnt, int fromQuantity,int toQuantity, int userId, ItemUnit smallUnit)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            if (smallUnit == null)
                smallUnit = new ItemUnit();
            var myContent = JsonConvert.SerializeObject(smallUnit);
            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri(Global.APIUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/unitsConversion?branchId=" + branchId+ "&fromItemUnit="+ fromItemUnit + "&toItemUnit="+toItemUnt+
                                                                "&fromQuantity="+fromQuantity + "&toQuantity="+ toQuantity + "&userId=" +userId + "&smallUnit=" + myContent);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<Boolean> decreaseItemLocationQuantity(int itemLocId ,int quantity, int userId)
        {
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/decreaseItemLocationQuantity?itemLocId=" + itemLocId+ "&quantity="+ quantity + "&userId=" + userId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<Boolean> trasnferItem( int itemLocId ,ItemLocation itemLocation)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var myContent = JsonConvert.SerializeObject(itemLocation);
            // 
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/trasnferItem?itemLocId=" + itemLocId + "&itemLocation=" + myContent);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<int> getAmountInBranch(int itemUnitId, int branchId)
        {
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/getAmountInBranch?itemUnitId=" + itemUnitId + "&branchId=" + branchId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var AvailableAmount = await response.Content.ReadAsStringAsync();
                    return int.Parse(AvailableAmount);
                }
                return 0;
            }
        }
        public async Task<int> getAmountInLocation(int itemUnitId, int branchId , int locationId)
        {
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/getAmountInLocation?itemUnitId=" + itemUnitId + "&branchId=" + branchId+ "&locationId="+ locationId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var AvailableAmount = await response.Content.ReadAsStringAsync();
                    return int.Parse(AvailableAmount);
                }
                return 0;
            }
        }
        public async Task<int> getUnitAmount(int itemUnitId, int branchId)
        {
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/getUnitAmount?itemUnitId=" + itemUnitId + "&branchId=" + branchId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var AvailableAmount = await response.Content.ReadAsStringAsync();
                    return int.Parse(AvailableAmount);
                }
                return 0;
            }
        }
        public async Task<int> getAmountByItemLocId(int itemLocId)
        {
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/getAmountByItemLocId?itemLocId=" + itemLocId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var AvailableAmount = await response.Content.ReadAsStringAsync();
                    return int.Parse(AvailableAmount);
                }
                return 0;
            }
        }
        public async Task<Boolean> recieptInvoice(List<ItemTransfer> invoiceItems, int branchId,int userId)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(invoiceItems);

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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/receiptInvoice?itemLocationObject=" + myContent + "&branchId=" + branchId + "&userId=" + userId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<Boolean> recieptOrder(List<ItemLocation> invoiceItems,int toBranch,int userId)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(invoiceItems);

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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/receiptOrder?itemLocationObject=" + myContent +"&toBranch=" + toBranch + "&userId=" + userId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<Boolean> destroyItem(List<ItemLocation> invoiceItems, int userId)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(invoiceItems);

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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/destroyItem?itemLocationObject=" + myContent+ "&userId=" + userId );
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<Boolean> returnInvoice(List<ItemTransfer> invoiceItems, int branchId, int userId)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(invoiceItems);

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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/returnInvoice?itemLocationObject=" + myContent + "&branchId=" + branchId + "&userId=" + userId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<Boolean> transferAmountbetweenUnits(int locationId,int itemLocId,int toItemUnitId,int fromQuantity, int toQuantity, int userId)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 

            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri(Global.APIUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/transferAmountbetweenUnits?" +
                                                            "locationId=" + locationId + "&itemLocId=" + itemLocId + "&toItemUnitId="
                                                            + toItemUnitId+ "&fromQuantity="+fromQuantity + "&toQuantity=" + toQuantity + "&userId=" + userId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<List<ItemLocation>> getSpecificItemLocation(string itemUnitsIds, int branchId)
        {
            List<ItemLocation> items = null;
            var myContent = JsonConvert.SerializeObject(itemUnitsIds);
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsLocations/getSpecificItemLocation?itemUnitsIds=" + myContent+"&branchId= " + branchId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    jsonString = jsonString.Replace("\\", string.Empty);
                    jsonString = jsonString.Trim('"');
                    // fix date format
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter> { new BadDateFixingConverter() },
                        DateParseHandling = DateParseHandling.None
                    };
                    items = JsonConvert.DeserializeObject<List<ItemLocation>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return items;
                }
                else //web api sent error response 
                {
                    items = new List<ItemLocation>();
                }
                return items;
            }
        }
    }
}

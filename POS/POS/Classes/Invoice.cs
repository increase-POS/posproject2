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
    public class ItemTransfer
    {
        public int itemsTransId { get; set; }
        public Nullable<int> itemId { get; set; }
        public string itemName { get; set; }
        public Nullable<long> quantity { get; set; }
        public Nullable<int> invoiceId { get; set; }
        public Nullable<int> inventoryItemLocId { get; set; }
        public string invNumber { get; set; }
        public Nullable<int> locationIdNew { get; set; }
        public Nullable<int> locationIdOld { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public string notes { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> itemUnitId { get; set; }
        public string itemSerial { get; set; }
        public string unitName { get; set; }
        public string barcode { get; set; }    
        public string itemType { get; set; }  

    }
    public  class CouponInvoice
    {
        public int id { get; set; }
        public Nullable<int> couponId { get; set; }
        public Nullable<int> InvoiceId { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<decimal> discountValue { get; set; }
        public Nullable<byte> discountType { get; set; }
        public string couponCode { get; set; }
    }
    public  class invoiceStatus
    {
        public int invStatusId { get; set; }
        public Nullable<int> invoiceId { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public string notes { get; set; }
        public Nullable<byte> isActive { get; set; }
    }
        public class Invoice
    {
        public int invoiceId { get; set; }
        public string invNumber { get; set; }
        public Nullable<int> agentId { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> createUserId { get; set; }
        public string invType { get; set; }
        public string discountType { get; set; }
        public Nullable<decimal> discountValue { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> totalNet { get; set; }
        public Nullable<decimal> paid { get; set; }
        public Nullable<decimal> deserved { get; set; }
        public Nullable<System.DateTime> deservedDate { get; set; }
        public Nullable<System.DateTime> invDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> invoiceMainId { get; set; }
        public string invCase { get; set; }
        public Nullable<System.TimeSpan> invTime { get; set; }
        public string notes { get; set; }
        public string vendorInvNum { get; set; }
        public string name { get; set; }
        public string branchName { get; set; }
        public Nullable<System.DateTime> vendorInvDate { get; set; }
        public Nullable<int> branchId { get; set; }
        public Nullable<int> itemsCount { get; set; }
        public Nullable<decimal> tax { get; set; }
        public Nullable<int> taxtype { get; set; }
        public Nullable<int> posId { get; set; }
        public Nullable<byte> isApproved { get; set; }
        public Nullable<int> branchCreatorId { get; set; }
        public string branchCreatorName { get; set; }
        public Nullable<int> shippingCompanyId { get; set; }
        public Nullable<int> shipUserId { get; set; }
        public string shipUserName { get; set; }
        public string status { get; set; }
        public int invStatusId { get; set; }

        // for report
        public int countP { get; set; }
        public int countS { get; set; }
       public Nullable<decimal> totalS { get; set; }
       public Nullable<decimal> totalNetS { get; set; }
       public Nullable<decimal> totalP { get; set; }
       public Nullable<decimal> totalNetP { get; set; }  
        public string branchType { get; set; }
        public string posName { get; set; }
        public string posCode { get; set; }
        public string agentName { get; set; }
        public string agentCompany { get; set; }
        public string agentCode { get; set; }
        public string cuserName { get; set; }
        public string cuserLast { get; set; }
        public string cUserAccName { get; set; }
        public string uuserName { get; set; }
        public string uuserLast { get; set; }
        public string uUserAccName { get; set; }
        
            public int countPb { get; set; }
        public int countD { get; set; }
       public Nullable<decimal> totalPb{ get; set; }
       public Nullable<decimal> totalD{ get; set; }
       public Nullable<decimal> totalNetPb{ get; set; }
       public Nullable<decimal> totalNetD{ get; set; }
      
      
       public Nullable<decimal> paidPb { get; set; }
       public Nullable<decimal> deservedPb { get; set; }
       public Nullable<decimal> discountValuePb { get; set; }
       public Nullable<decimal> paidD { get; set; }
       public Nullable<decimal> deservedD { get; set; }
       public Nullable<decimal> discountValueD { get; set; }
       

        //*************************************************
        //------------------------------------------------------

        public async Task<string> saveInvoice(Invoice invoice)
        {
            string message = "";
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(invoice);

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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/Save?invoiceObject=" + myContent);
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
        public async Task<string> saveOrderStatus(invoiceStatus status)
        {
            string message = "";
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(status);

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
                request.RequestUri = new Uri(Global.APIUri + "InvoiceStatus/Save?statusObject=" + myContent);
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
        public async Task<string> saveInvoiceItems(List<ItemTransfer> invoiceItems, int invoiceId)
        {
            string message = "";
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsTransfer/Save?itemTransferObject=" + myContent + "&invoiceId=" + invoiceId);
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
        public async Task<string> saveInvoiceCoupons(List<CouponInvoice> invoiceCoupons, int invoiceId, string invType)
        {
            string message = "";
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(invoiceCoupons);

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
                request.RequestUri = new Uri(Global.APIUri + "couponsInvoices/Save?couponsInvoicesObject=" + myContent + "&invoiceId=" + invoiceId+"&invType="+invType);
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

        public async Task<int> GetLastNumOfInv(string invCode)
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/GetLastNumOfInv?invCode=" + invCode);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    message = JsonConvert.DeserializeObject<string>(message);
                    return int.Parse(message);
                }

                return 0;
            }
        }


        public async Task<List<Invoice>> GetInvoicesByType(string invType,int branchId )
        {
            List<Invoice> invoices = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/GetByInvoiceType?invType=" + invType+"&branchId="+branchId);
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
                    invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoices;
                }
                else //web api sent error response 
                {
                    invoices = new List<Invoice>();
                }
                return invoices;
            }
        }
        public async Task<List<Invoice>> getOrdersForPay(int branchId )
        {
            List<Invoice> invoices = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/getOrdersForPay?branchId=" + branchId);
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
                    invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoices;
                }
                else //web api sent error response 
                {
                    invoices = new List<Invoice>();
                }
                return invoices;
            }
        }
        public async Task<List<Invoice>> GetInvoicesByCreator(string invType,int createUserId, int duration )
        {
            List<Invoice> invoices = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/GetInvoicesByCreator?invType=" + invType+ "&createUserId=" + createUserId+"&duration="+duration);
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
                    invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoices;
                }
                else //web api sent error response 
                {
                    invoices = new List<Invoice>();
                }
                return invoices;
            }
        }
        public async Task<int> GetCountByCreator(string invType,int createUserId, int duration )
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/GetCountByCreator?invType=" + invType+ "&createUserId=" + createUserId+"&duration="+duration);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var count = await response.Content.ReadAsStringAsync();
                    return int.Parse(count);
                }
                else //web api sent error response 
                {
                    return 0;
                }             
            }
        }
        public async Task<List<Invoice>> getBranchInvoices(string invType,int branchCreatorId, int branchId = 0 )
        {
            List<Invoice> invoices = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/getBranchInvoices?invType=" + invType+ "&branchCreatorId=" + branchCreatorId + "&branchId="+ branchId);
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
                    invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoices;
                }
                else //web api sent error response 
                {
                    invoices = new List<Invoice>();
                }
                return invoices;
            }
        }
        public async Task<int> GetCountBranchInvoices(string invType,int branchCreatorId, int branchId = 0 )
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/GetCountBranchInvoices?invType=" + invType+ "&branchCreatorId=" + branchCreatorId + "&branchId="+ branchId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var count = await response.Content.ReadAsStringAsync();
                    return int.Parse(count);
                }
               
                return 0;
            }
        }
        public async Task<List<Invoice>> getDeliverOrders(string invType,string status, int userId)
        {
            List<Invoice> invoices = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/getDeliverOrders?invType=" + invType +"&status="+status+ "&shipUserId=" + userId);
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
                    invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoices;
                }
                else //web api sent error response 
                {
                    invoices = new List<Invoice>();
                }
                return invoices;
            }
        }
        public async Task<int> getDeliverOrdersCount(string invType,string status, int userId)
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/getDeliverOrdersCount?invType=" + invType +"&status="+status+ "&shipUserId=" + userId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var count = await response.Content.ReadAsStringAsync();
                    return int.Parse(count);
                }
                else //web api sent error response 
                {
                    return 0;
                }
            }
        }
        public async Task<List<Invoice>> GetOrderByType(string invType,int branchId )
        {
            List<Invoice> invoices = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/GetOrderByType?invType=" + invType+"&branchId="+branchId);
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
                    invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoices;
                }
                else //web api sent error response 
                {
                    invoices = new List<Invoice>();
                }
                return invoices;
            }
        }
        public async Task<Invoice> GetInvoicesByNum(string invNum, int branchId = 0)
        {
            Invoice invoice = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/GetByInvNum?invNum=" + invNum + "&branchId="+branchId);
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
                    invoice = JsonConvert.DeserializeObject<Invoice>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoice;
                }
                else //web api sent error response 
                {
                    invoice = new Invoice();
                }
                return invoice;
            }
        }
        public async Task<Invoice> GetById(int invoiceId)
        {
            Invoice invoice = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/GetById?invoiceId=" + invoiceId);
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
                    invoice = JsonConvert.DeserializeObject<Invoice>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoice;
                }
                else //web api sent error response 
                {
                    invoice = new Invoice();
                }
                return invoice;
            }
        }

        public async Task<List<ItemTransfer>> GetInvoicesItems(int invoiceId)
        {
            List<ItemTransfer> invoiceItems = null;
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
                request.RequestUri = new Uri(Global.APIUri + "ItemsTransfer/Get?invoiceId=" + invoiceId);
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
                    invoiceItems = JsonConvert.DeserializeObject<List<ItemTransfer>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoiceItems;
                }
                else //web api sent error response 
                {
                    invoiceItems = new List<ItemTransfer>();
                }
                return invoiceItems;
            }
        }
        public async Task<decimal> GetAvgItemPrice(int itemUnitId, int itemId)
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
                request.RequestUri = new Uri(Global.APIUri + "invoices/GetAvgItemPrice?itemUnitId=" + itemUnitId+ "&itemId="+ itemId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                  string  message = await response.Content.ReadAsStringAsync();
                    message = JsonConvert.DeserializeObject<string>(message);
                    return decimal.Parse(message);
                }
                return 0;
            }
        }
      
        public async Task<List<CouponInvoice>> GetInvoiceCoupons(int invoiceId)
        {
            List<CouponInvoice> invoiceCoupons = null;
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
                request.RequestUri = new Uri(Global.APIUri + "couponsInvoices/Get?invoiceId=" + invoiceId);
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
                    invoiceCoupons = JsonConvert.DeserializeObject<List<CouponInvoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoiceCoupons;
                }
                else //web api sent error response 
                {
                    invoiceCoupons = new List<CouponInvoice>();
                }
                return invoiceCoupons;
            }
        }
        public async Task<List<CouponInvoice>> getOriginalCoupons(int invoiceId)
        {
            List<CouponInvoice> invoiceCoupons = null;
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
                request.RequestUri = new Uri(Global.APIUri + "couponsInvoices/GetOriginal?invoiceId=" + invoiceId);
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
                    invoiceCoupons = JsonConvert.DeserializeObject<List<CouponInvoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoiceCoupons;
                }
                else //web api sent error response 
                {
                    invoiceCoupons = new List<CouponInvoice>();
                }
                return invoiceCoupons;
            }
        }


        public async Task<List<Invoice>> GetinvCountBydate(string invType, string branchType, DateTime startDate, DateTime endDate)
        {
            List<Invoice> invoices = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/GetinvCountBydate?invType=" + invType + "&branchType=" + branchType + "&startDate=" + startDate + "&endDate=" + endDate);
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
                    invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoices;
                }
                else //web api sent error response 
                {
                    invoices = new List<Invoice>();
                }
                return invoices;
            }
        }

        public async Task<Invoice> getgeneratedInvoice(int mainInvoiceId)
        {
            Invoice invoice = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/getgeneratedInvoice?mainInvoiceId=" + mainInvoiceId);
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
                    invoice = JsonConvert.DeserializeObject<Invoice>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoice;
                }
                else //web api sent error response 
                {
                    invoice = new Invoice();
                }
                return invoice;
            }
        }
        public async Task<string> generateInvNumber(string invoiceCode)
        {
            int sequence = await GetLastNumOfInv(invoiceCode);
            sequence++;
            string strSeq = sequence.ToString();
            if (sequence <= 999999)
                strSeq = sequence.ToString().PadLeft(6, '0');
            string invoiceNum = invoiceCode + "-" + strSeq;
            return invoiceNum;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="invType">pi,pb,si,sb</param>
        /// <returns></returns>
        public async Task<Invoice> recordCashTransfer(Invoice invoice,string invType)
        {
            Agent agent = new Agent();
            float newBalance = 0;
            agent = await agent.getAgentById(invoice.agentId.Value);

            #region pos Cash transfer
            CashTransfer posCash = new CashTransfer();
            posCash.posId = MainWindow.posID;
            posCash.agentId = invoice.agentId;
            posCash.invId = invoice.invoiceId;
            posCash.createUserId = invoice.createUserId;
            posCash.processType = "balance";
            posCash.cash = invoice.totalNet;

            #endregion
            #region agent Cash transfer
            CashTransfer cashTrasnfer = new CashTransfer();
            cashTrasnfer.posId = MainWindow.posID;
            cashTrasnfer.agentId = invoice.agentId;
            cashTrasnfer.invId = invoice.invoiceId;
            cashTrasnfer.createUserId = invoice.createUserId; 
            cashTrasnfer.processType = "balance";
            #endregion
            switch (invType)
            {
                #region purchase
                case "pi"://purchase invoice
                case "sb"://sale bounce
                    posCash.transType = "d";
                    cashTrasnfer.transType = "p";
                    if (invType.Equals("pi"))
                    {
                        posCash.side = "v"; // vendor
                        posCash.transNum = await cashTrasnfer.generateCashNumber("dv");

                        cashTrasnfer.side = "v"; // vendor
                        cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("pv"); 
                    }
                    else
                    {
                        posCash.side = "c"; // vendor
                        posCash.transNum = await cashTrasnfer.generateCashNumber("dc");

                        cashTrasnfer.side = "c"; // vendor                        
                        cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("pc");

                    }
                    await cashTrasnfer.Save(posCash); //add pos cash transfer
                    if (agent.balanceType == 1)
                    {
                        if (invoice.totalNet <= (decimal)agent.balance)
                        {
                            invoice.paid = invoice.totalNet;
                            invoice.deserved = 0;
                            newBalance = agent.balance - (float)invoice.totalNet;
                            agent.balance = newBalance;
                        }
                        else
                        {
                            invoice.paid = (decimal)agent.balance;
                            invoice.deserved = invoice.totalNet - (decimal)agent.balance ;
                            newBalance = (float)invoice.totalNet - agent.balance;
                            agent.balance = newBalance;
                            agent.balanceType = 0;
                        }
                       
                        cashTrasnfer.cash = invoice.paid;
                        cashTrasnfer.transType = "p"; //pull
                       

                        await invoice.saveInvoice(invoice);
                        
                        await cashTrasnfer.Save(cashTrasnfer); //add agent cash transfer
                        await agent.saveAgent(agent);
                    }
                    else if (agent.balanceType == 0)
                    {
                        newBalance = agent.balance + (float)invoice.totalNet;
                        agent.balance = newBalance;
                        await agent.saveAgent(agent);
                    }
                        break;
                #endregion
                #region purchase bounce
                case "pb"://purchase bounce invoice
                case "si"://sale invoice
                    posCash.transType = "p";
                    cashTrasnfer.transType = "d";

                    if (invType.Equals("pb"))
                    {
                        posCash.side = "v"; // vendor
                        posCash.transNum = await cashTrasnfer.generateCashNumber("pv");
                        cashTrasnfer.side = "v"; // vendor
                        cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("dv");

                    }
                    else
                    {
                        posCash.side = "c"; // customer
                        posCash.transNum = await cashTrasnfer.generateCashNumber("pc");
                        cashTrasnfer.side = "c"; // customer
                        cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("dc");
                    }
                    await cashTrasnfer.Save(posCash); //add pos cash transfer
                    if (agent.balanceType == 0)
                    {
                        if (invoice.totalNet <= (decimal)agent.balance)
                        {
                            invoice.paid = invoice.totalNet;
                            invoice.deserved = 0;
                            newBalance = agent.balance - (float)invoice.totalNet;
                            agent.balance = newBalance;
                        }
                        else
                        {
                            invoice.paid = (decimal)agent.balance;
                            invoice.deserved = invoice.totalNet - (decimal)agent.balance;
                            newBalance = (float)invoice.totalNet - agent.balance;
                            agent.balance = newBalance;
                            agent.balanceType = 1;
                        }
                       
                        cashTrasnfer.cash = invoice.paid;
                        cashTrasnfer.transType = "d"; //deposit

                        await invoice.saveInvoice(invoice);
                        if (invoice.paid > 0)
                        {
                            await cashTrasnfer.Save(cashTrasnfer); //add cash transfer     
                        }
                        await agent.saveAgent(agent);
                    }
                    else if (agent.balanceType == 1)
                    {
                        newBalance = agent.balance + (float)invoice.totalNet;
                        agent.balance = newBalance;
                        await agent.saveAgent(agent);
                    }
                    break;
                #endregion  
            }

            return invoice;
        }
        public async Task<Invoice> recordCompanyCashTransfer(Invoice invoice,string invType)
        {
            ShippingCompanies company = new ShippingCompanies();
            decimal newBalance = 0;
            company = await company.GetByID(invoice.shippingCompanyId.Value);

            CashTransfer cashTrasnfer = new CashTransfer();
            cashTrasnfer.posId = MainWindow.posID;
            cashTrasnfer.shippingCompanyId = invoice.shippingCompanyId;
            cashTrasnfer.invId = invoice.invoiceId;
            cashTrasnfer.createUserId = invoice.createUserId; 
            cashTrasnfer.processType = "balance";
            cashTrasnfer.transType = "d"; //deposit
            cashTrasnfer.side = "sh"; // vendor
            cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("dsh");

            if (company.balanceType == 0)
            {
                if (invoice.totalNet <= (decimal)company.balance)
                {
                    invoice.paid = invoice.totalNet;
                    invoice.deserved = 0;
                    newBalance = (decimal) company.balance - (decimal)invoice.totalNet;
                    company.balance = newBalance;
                }
                else
                {
                    invoice.paid = (decimal)company.balance;
                    invoice.deserved = invoice.totalNet - (decimal)company.balance;
                    newBalance = (decimal) invoice.totalNet - company.balance;
                    company.balance = newBalance;
                    company.balanceType = 1;
                }

                cashTrasnfer.cash = invoice.paid;
                cashTrasnfer.transType = "d"; //deposit
                if (invoice.paid > 0)
                {                  
                    await cashTrasnfer.Save(cashTrasnfer); //add cash transfer
                    await invoice.saveInvoice(invoice);
                }             
                await company.Save(company);
            }
            else if (company.balanceType == 1)
            {
                newBalance = (decimal) company.balance + (decimal)invoice.totalNet;
                company.balance = newBalance;
                await company.Save(company);
            }
            return invoice;
        }
        public async Task<List<Invoice>> GetAll()
        {
            List<Invoice> invoicelst = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/Get");
                request.Headers.Add("APIKey", Global.APIKey);
                /*
                request.Headers.Add("type", type);
                request.Headers.Add("side", side);
                */
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
                    invoicelst = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoicelst;
                }
                else //web api sent error response 
                {
                    invoicelst = new List<Invoice>();
                }
                return invoicelst;
            }
        }

        public async Task<List<Invoice>> getAgentInvoices(int branchId , int agentId , string type)
        {
            List<Invoice> invoices = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/getAgentInvoices?branchId=" + branchId +"&agentId="+ agentId + "&type=" + type);
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
                    invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoices;
                }
                else //web api sent error response 
                {
                    invoices = new List<Invoice>();
                }
                return invoices;
            }
        }

        public async Task<List<Invoice>> getShipCompanyInvoices(int branchId , int shippingCompanyId , string type)
        {
            List<Invoice> invoices = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/getShipCompanyInvoices?branchId=" + branchId + "&shippingCompanyId=" + shippingCompanyId + "&type=" + type);
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
                    invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoices;
                }
                else //web api sent error response 
                {
                    invoices = new List<Invoice>();
                }
                return invoices;
            }
        }

        public async Task<List<Invoice>> getUserInvoices(int branchId , int userId , string type)
        {
            List<Invoice> invoices = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Invoices/getUserInvoices?branchId=" + branchId + "&userId=" + userId + "&type=" + type);
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
                    invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return invoices;
                }
                else //web api sent error response 
                {
                    invoices = new List<Invoice>();
                }
                return invoices;
            }
        }

    }
}

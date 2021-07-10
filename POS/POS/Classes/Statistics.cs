using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS;
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
    public class ItemTransferInvoice
    {
        // ItemTransfer
        public int ITitemsTransId { get; set; }
        public Nullable<int> ITitemUnitId { get; set; }
        public Nullable<int> ITitemId { get; set; }
        public Nullable<int> ITunitId { get; set; }
        public string ITitemName { get; set; }
        public string ITunitName { get; set; }
        public Nullable<long> ITquantity { get; set; }
        public Nullable<decimal> ITprice { get; set; }



        public Nullable<System.DateTime> ITcreateDate { get; set; }
        public Nullable<System.DateTime> ITupdateDate { get; set; }
        public Nullable<int> ITcreateUserId { get; set; }
        public Nullable<int> ITupdateUserId { get; set; }
        public string ITnotes { get; set; }

        public string ITbarcode { get; set; }
        public string ITCreateuserName { get; set; }
        public string ITCreateuserLName { get; set; }
        public string ITCreateuserAccName { get; set; }

        public string ITUpdateuserName { get; set; }
        public string ITUpdateuserLName { get; set; }
        public string ITUpdateuserAccName { get; set; }
        //invoice
        public int invoiceId { get; set; }
        public string invNumber { get; set; }
        public Nullable<int> agentId { get; set; }
        public Nullable<int> createUserId { get; set; }
        public string invType { get; set; }
        public string discountType { get; set; }
        public Nullable<decimal> ITdiscountValue { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> totalNet { get; set; }
        public Nullable<decimal> paid { get; set; }
        public Nullable<decimal> deserved { get; set; }
        public Nullable<System.DateTime> deservedDate { get; set; }
        public Nullable<System.DateTime> invDate { get; set; }
        public Nullable<System.DateTime> IupdateDate { get; set; }
        public Nullable<int> IupdateUserId { get; set; }
        public Nullable<int> invoiceMainId { get; set; }
        public string invCase { get; set; }
        public Nullable<System.TimeSpan> invTime { get; set; }
        public string Inotes { get; set; }
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
        public string agentCode { get; set; }
        public string cuserName { get; set; }
        public string cuserLast { get; set; }
        public string cUserAccName { get; set; }
        public string uuserName { get; set; }
        public string uuserLast { get; set; }
        public string uUserAccName { get; set; }

        public int countPb { get; set; }
        public int countD { get; set; }
        public Nullable<decimal> totalPb { get; set; }
        public Nullable<decimal> totalD { get; set; }
        public Nullable<decimal> totalNetPb { get; set; }
        public Nullable<decimal> totalNetD { get; set; }


        public Nullable<decimal> paidPb { get; set; }
        public Nullable<decimal> deservedPb { get; set; }
        public Nullable<decimal> discountValuePb { get; set; }
        public Nullable<decimal> paidD { get; set; }
        public Nullable<decimal> deservedD { get; set; }
        public Nullable<decimal> discountValueD { get; set; }
    }
    class Statistics
    {

        //****************************************************


        public async Task<List<ItemLocation>> GetItemQtyInBranches(int itemId, int UnitId, string BranchType)
        {
            List<ItemLocation> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetItemQtyInBranches?itemId=" + itemId + "&UnitId=" + UnitId + "&BranchType=" + BranchType);
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
                    list = JsonConvert.DeserializeObject<List<ItemLocation>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<ItemLocation>();
                }
                return list;
            }
        }

        // المشتريات
        public async Task<List<Invoice>> GetPurinv()
        {
            List<Invoice> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetPurinv");
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
                    list = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<Invoice>();
                }
                return list;
            }
        }

        // الاصناف في الفواتير

        public async Task<List<ItemTransferInvoice>> GetPuritem()
        {
            List<ItemTransferInvoice> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetPuritem");
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
                    list = JsonConvert.DeserializeObject<List<ItemTransferInvoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<ItemTransferInvoice>();
                }
                return list;
            }
        }


        public async Task<List<Invoice>> GetPurinvwithCount()
        {
            List<Invoice> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetPurinvwithCount");
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
                    list = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<Invoice>();
                }
                return list;
            }
        }

        public async Task<List<Branch>> GetinvInBranch()
        {
            List<Branch> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetinvInBranch");
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
                    list = JsonConvert.DeserializeObject<List<Branch>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<Branch>();
                }
                return list;
            }
        }


        public async Task<List<Invoice>> GetPoswithInvCount()
        {
            List<Invoice> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetPoswithInvCount");
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
                    list = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<Invoice>();
                }
                return list;
            }
        }

        // عرض فواتير كل نقطة بيع

        public async Task<List<Invoice>> GetPoswithInv()
        {
            List<Invoice> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetPoswithInv");
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
                    list = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<Invoice>();
                }
                return list;
            }
        }


        // عدد فواتير المشتريات ومرتجع المشتريات ومسودات كل فرع

        public async Task<List<Invoice>> GetinvCountByBranch()
        {
            List<Invoice> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetinvCountByBranch");
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
                    list = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<Invoice>();
                }
                return list;
            }
        }

        // مبيعات

            // فواتير المبيعات بكل انواعها
        public async Task<List<Invoice>> GetSaleinv()
        {
            List<Invoice> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetSaleinv");
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
                    list = JsonConvert.DeserializeObject<List<Invoice>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<Invoice>();
                }
                return list;
            }
        }

    }
}

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
    public class Storage
    {
        public int min { get; set; }
        public int max { get; set; }

        public Nullable<int> minUnitId { get; set; }
        public Nullable<int> maxUnitId { get; set; }
        public string minUnitName { get; set; }
        public string maxUnitName { get; set; }
        private string minAll;
        private string maxAll;
        public string MinAll { get => minAll = minUnitName + " " + min.ToString(); set => minAll = value; }
        public string MaxAll { get => maxAll = maxUnitName + " " + max.ToString(); set => maxAll = value; }
        // item unit
        public string itemName { get; set; }
        public string unitName { get; set; }
        public int itemUnitId { get; set; }

        public int itemId { get; set; }
        public int unitId { get; set; }

        public string barcode { get; set; }
        //item location
        public string CreateuserName { get; set; }
        public string CreateuserLName { get; set; }
        public string CreateuserAccName { get; set; }
        public string UuserName { get; set; }
        public string UuserLName { get; set; }
        public string UuserAccName { get; set; }

        //
        public string branchName { get; set; }

        public string branchType { get; set; }
        //itemslocations

        public int itemsLocId { get; set; }
        public int locationId { get; set; }
        public Nullable<decimal> quantity { get; set; }

        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }

        public string IULnote { get; set; }
        public Nullable<decimal> storeCost { get; set; }

        public string cuserName { get; set; }
        public string cuserLast { get; set; }
        public string cUserAccName { get; set; }
        public string uuserName { get; set; }
        public string uuserLast { get; set; }
        public string uUserAccName { get; set; }
        // Location
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }
        private string sectionLoactionName;

        public Nullable<byte> LocisActive { get; set; }
        public int sectionId { get; set; }
        public string Locnote { get; set; }
        public int branchId { get; set; }
        public Nullable<byte> LocisFreeZone { get; set; }


        // section

        public string Secname { get; set; }
        public Nullable<byte> SecisActive { get; set; }
        public string Secnote { get; set; }
        public Nullable<byte> SecisFreeZone { get; set; }
        public string SectionLoactionName { get => sectionLoactionName = Secname + x + y + z; set => sectionLoactionName = value; }


        private string itemUnits;
        private string loactionName;
        public string LoactionName { get => loactionName = x + y + z; set => loactionName = value; }
        public string ItemUnits { get => itemUnits = itemName + " - " + unitName; set => itemUnits = value; }

    }

    public class ItemUnitCombo
    {

        public int itemUnitId { get; set; }
        public string itemUnitName { get; set; }

    }
    public class CouponCombo
    {

        public int Copcid { get; set; }
        public string Copname { get; set; }
    }
    public class OfferCombo
    {

        public int OofferId { get; set; }
        public string Oname { get; set; }
    }

    public class ItemTransferInvoice
    {// new properties
        public string itemName { get; set; }
        public string unitName { get; set; }
        public int itemsTransId { get; set; }
        public Nullable<int> itemUnitId { get; set; }

        public Nullable<int> itemId { get; set; }
        public Nullable<int> unitId { get; set; }
        public Nullable<long> quantity { get; set; }


        public Nullable<decimal> price { get; set; }
        public string barcode { get; set; }

        // ItemTransfer
        public int ITitemsTransId { get; set; }
        public Nullable<int> ITitemUnitId { get; set; }
        public Nullable<int> updateUserId { get; set; }
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
        public Nullable<decimal> discountValue { get; set; }
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
        private string invTypeNumber;
        public string InvTypeNumber { get => invTypeNumber = invType + "-" + invNumber; set => invTypeNumber = value; }
        // for report
        public int countP { get; set; }
        public int countS { get; set; }
        public int count { get; set; }

        public Nullable<decimal> totalS { get; set; }
        public Nullable<decimal> totalNetS { get; set; }
        public Nullable<decimal> totalP { get; set; }
        public Nullable<decimal> totalNetP { get; set; }
        public string branchType { get; set; }
        public string posName { get; set; }
        public string posCode { get; set; }
        public string agentName { get; set; }
        public string agentType { get; set; }
        public string agentCode { get; set; }
        public string cuserName { get; set; }
        public string cuserLast { get; set; }
        public string cUserAccName { get; set; }
        public string uuserName { get; set; }
        public string uuserLast { get; set; }
        public string uUserAccName { get; set; }
        private string agentTypeAgent;
        public string AgentTypeAgent { get => agentTypeAgent = agentType + "-" + agentName; set => agentTypeAgent = value; }
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
        // coupon


        public int CopcId { get; set; }
        public string Copname { get; set; }
        public string Copcode { get; set; }
        public Nullable<byte> CopisActive { get; set; }
        public Nullable<byte> CopdiscountType { get; set; }
        public Nullable<decimal> CopdiscountValue { get; set; }
        public Nullable<System.DateTime> CopstartDate { get; set; }
        public Nullable<System.DateTime> CopendDate { get; set; }
        public string Copnotes { get; set; }
        public Nullable<int> Copquantity { get; set; }
        public Nullable<int> CopremainQ { get; set; }
        public Nullable<decimal> CopinvMin { get; set; }
        public Nullable<decimal> CopinvMax { get; set; }
        public Nullable<System.DateTime> CopcreateDate { get; set; }
        public Nullable<System.DateTime> CopupdateDate { get; set; }
        public Nullable<int> CopcreateUserId { get; set; }
        public Nullable<int> CopupdateUserId { get; set; }
        public string Copbarcode { get; set; }
        // offer

        public int OofferId { get; set; }
        public string Oname { get; set; }
        public string Ocode { get; set; }
        public Nullable<byte> OisActive { get; set; }
        public string OdiscountType { get; set; }
        public Nullable<decimal> OdiscountValue { get; set; }
        public Nullable<System.DateTime> OstartDate { get; set; }
        public Nullable<System.DateTime> OendDate { get; set; }
        public Nullable<System.DateTime> OcreateDate { get; set; }
        public Nullable<System.DateTime> OupdateDate { get; set; }
        public Nullable<int> OcreateUserId { get; set; }
        public Nullable<int> OupdateUserId { get; set; }
        public string Onotes { get; set; }
        public Nullable<int> Oquantity { get; set; }
        public int Oitemofferid { get; set; }
        //external
        public int movbranchid { get; set; }
        public string movbranchname { get; set; }
        // internal
        public string exportBranch { get; set; }
        public string importBranch { get; set; }
        public int exportBranchId { get; set; }
        public int importBranchId { get; set; }
        private string itemUnits;
        private int cusCount;
        private int venCount;
        private int pCount;
        private int sCount;
        private int pbCount;
        private int sbCount;
        public string ItemUnits { get => itemUnits = itemName + " - " + unitName; set => itemUnits = value; }
        public int CusCount { get => cusCount; set => cusCount = value; }
        public int VenCount { get => venCount; set => venCount = value; }
        public int PCount { get => pCount; set => pCount = value; }
        public int SCount { get => sCount; set => sCount = value; }
        public int PbCount { get => pbCount; set => pbCount = value; }
        public int SbCount { get => sbCount; set => sbCount = value; }
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

        // عدد الاصناف في الفواتير
        public async Task<List<ItemTransferInvoice>> GetPuritemcount()
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetPuritemcount");
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


        // الفواتير مع العناصر
        public async Task<List<ItemTransferInvoice>> GetSaleitem()
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetSaleitem");
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

        // عدد الاصناف في الفواتير
        public async Task<List<ItemTransferInvoice>> GetSaleitemcount()
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetSaleitemcount");
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

        public List<ItemUnitCombo> GetIUComboList(List<ItemTransferInvoice> ITInvoice)
        {
            List<ItemUnitCombo> iulist = new List<ItemUnitCombo>();

            iulist = ITInvoice.GroupBy(x => x.ITitemUnitId)
                   .Select(g => new ItemUnitCombo { itemUnitId = (int)g.FirstOrDefault().ITitemUnitId, itemUnitName = g.FirstOrDefault().ITitemName + " - " + g.FirstOrDefault().ITunitName }).ToList();
            return iulist;

        }
        public List<CouponCombo> GetCopComboList(List<ItemTransferInvoice> ITInvoice)
        {
            List<CouponCombo> iulist = new List<CouponCombo>();

            iulist = ITInvoice.GroupBy(x => x.CopcId)
                   .Select(g => new CouponCombo { Copcid = g.FirstOrDefault().CopcId, Copname = g.FirstOrDefault().Copname }).ToList();
            return iulist;

        }
        public List<OfferCombo> GetOfferComboList(List<ItemTransferInvoice> ITInvoice)
        {
            List<OfferCombo> iulist = new List<OfferCombo>();

            iulist = ITInvoice.GroupBy(x => x.CopcId)
                   .Select(g => new OfferCombo { OofferId = g.FirstOrDefault().OofferId, Oname = g.FirstOrDefault().Oname }).ToList();
            return iulist;

        }

        //OfferCombo

        // الفواتير  مع الكوبون
        public async Task<List<ItemTransferInvoice>> GetSalecoupon()
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetSalecoupon");
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

        // الفواتير مع العناصر مع الاوفر
        public async Task<List<ItemTransferInvoice>> GetSaleOffer()
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetSaleOffer");
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

        // المخزون 
        #region Storage

        public async Task<List<Storage>> GetStorage()
        {
            List<Storage> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetStorage");
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
                    list = JsonConvert.DeserializeObject<List<Storage>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<Storage>();
                }
                return list;
            }
        }


        // حركة الاصناف التي دخلت الى الفرع
        public async Task<List<ItemTransferInvoice>> GetInItems()
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetInItems");
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
        // حركة الاصناف الخارجية (مع الزبائن والموردين)
        public async Task<List<ItemTransferInvoice>> GetExternalMov()
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetExternalMov");
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

        //حركة الاصناف الداخلية بين الفروع
        public async Task<List<ItemTransferInvoice>> GetInternalMov()
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
                request.RequestUri = new Uri(Global.APIUri + "Statistics/GetInternalMov");
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


        #endregion

        public class itemCombo
        {
            private int itemId;
            private string itemName;
            private int branchId;
            public int ItemId { get => itemId; set => itemId = value; }
            public string ItemName { get => itemName; set => itemName = value; }
            public int BranchId { get => branchId; set => branchId = value; }
        }
        public class ExternalitemCombo
        {
            private int? itemId;
            private string itemName;
            private int? branchId;

            public int? ItemId { get => itemId; set => itemId = value; }
            public string ItemName { get => itemName; set => itemName = value; }
            public int? BranchId { get => branchId; set => branchId = value; }
        }
        public List<itemCombo> getItemCombo(List<Storage> ITInvoice)
        {
            List<itemCombo> iulist = new List<itemCombo>();

            iulist = ITInvoice.Select(g => new itemCombo { ItemId = g.itemId, ItemName = g.itemName, BranchId = g.branchId }).ToList();
            return iulist;

        }

        public List<ExternalitemCombo> getExternalItemCombo(List<ItemTransferInvoice> ITInvoice)
        {
            List<ExternalitemCombo> iulist = new List<ExternalitemCombo>();

            iulist = ITInvoice.Select(g => new ExternalitemCombo { ItemId = g.itemId, ItemName = g.itemName, BranchId = g.branchId }).ToList();
            return iulist;

        }

        public class unitCombo
        {
            private int unitId;
            private string unitName;
            private int itemId;
            private int branchId;
            public int UnitId { get => unitId; set => unitId = value; }
            public string UnitName { get => unitName; set => unitName = value; }
            public int ItemId { get => itemId; set => itemId = value; }
            public int BranchId { get => branchId; set => branchId = value; }
        }
        public class ExternalUnitCombo
        {
            private int? branchId;
            private int? unitId;
            private string unitName;
            private int? itemId;

            public int? UnitId { get => unitId; set => unitId = value; }
            public string UnitName { get => unitName; set => unitName = value; }
            public int? ItemId { get => itemId; set => itemId = value; }
            public int? BranchId { get => branchId; set => branchId = value; }
        }


        public List<unitCombo> getUnitCombo(List<Storage> ITInvoice)
        {
            List<unitCombo> iulist = new List<unitCombo>();
            iulist = ITInvoice.Select(g => new unitCombo { BranchId = g.branchId, UnitId = g.unitId, UnitName = g.unitName, ItemId = g.itemId }).ToList();
            return iulist;
        }

        public List<ExternalUnitCombo> getExternalUnitCombo(List<ItemTransferInvoice> ITInvoice)
        {
            List<ExternalUnitCombo> iulist = new List<ExternalUnitCombo>();
            iulist = ITInvoice.Select(g => new ExternalUnitCombo { BranchId = g.branchId, UnitId = g.unitId, UnitName = g.unitName, ItemId = g.itemId }).ToList();
            return iulist;
        }
        public class sectionCombo
        {
            private int sectionId;
            private string sectionName;
            private int branchId;
            public int SectionId { get => sectionId; set => sectionId = value; }
            public string SectionName { get => sectionName; set => sectionName = value; }
            public int BranchId { get => branchId; set => branchId = value; }
        }

        public List<sectionCombo> getSectionCombo(List<Storage> ITInvoice)
        {
            List<sectionCombo> iulist = new List<sectionCombo>();

            iulist = ITInvoice.Select(g => new sectionCombo { SectionId = (int)g.sectionId, SectionName = g.Secname, BranchId = g.branchId }).ToList();
            return iulist;

        }

        public class locationCombo
        {
            private int locationId;
            private string locationName;
            private int sectionId;
            private int branchId;
            public int LocationId { get => locationId; set => locationId = value; }
            public string LocationName { get => locationName; set => locationName = value; }
            public int SectionId { get => sectionId; set => sectionId = value; }
            public int BranchId { get => branchId; set => branchId = value; }
        }

        public List<locationCombo> getLocationCombo(List<Storage> ITInvoice)
        {
            List<locationCombo> iulist = new List<locationCombo>();

            iulist = ITInvoice.Select(g => new locationCombo { BranchId = g.branchId, LocationId = g.locationId, LocationName = g.LoactionName, SectionId = g.sectionId }).ToList();
            return iulist;

        }


        public class AgentTypeCombo
        {
            private string agentType;
            private int? branchId;

            public int? BranchId { get => branchId; set => branchId = value; }
            public string AgentType { get => agentType; set => agentType = value; }
        }

        public List<AgentTypeCombo> GetExternalAgentTypeCombos(List<ItemTransferInvoice> ITInvoice)
        {
            List<AgentTypeCombo> iulist = new List<AgentTypeCombo>();

            iulist = ITInvoice.Select(g => new AgentTypeCombo {  AgentType = g.agentType, BranchId = g.branchId }).ToList();
            return iulist;

        }

        public class AgentCombo
        {
            private int? agentId;
            private string agentName;
            private int? branchId;
            private string agentType;

            public int? AgentId { get => agentId; set => agentId = value; }
            public int? BranchId { get => branchId; set => branchId = value; }
            public string AgentName { get => agentName; set => agentName = value; }
            public string AgentType { get => agentType; set => agentType = value; }
        }

        public List<AgentCombo> GetExternalAgentCombos(List<ItemTransferInvoice> ITInvoice)
        {
            List<AgentCombo> iulist = new List<AgentCombo>();

            iulist = ITInvoice.Select(g => new AgentCombo { AgentId = g.agentId, AgentName = g.agentName, BranchId = g.branchId, AgentType = g.agentType }).ToList();
            return iulist;

        }

        public class InvTypeCombo
        {
            private string invoiceType;
            private int? branchId;

            public string InvoiceType { get => invoiceType; set => invoiceType = value; }
            public int? BranchId { get => branchId; set => branchId = value; }
        }

        public List<InvTypeCombo> GetExternalInvoiceTypeCombos(List<ItemTransferInvoice> ITInvoice)
        {
            List<InvTypeCombo> iulist = new List<InvTypeCombo>();

            iulist = ITInvoice.Select(g => new InvTypeCombo {  InvoiceType = g.invType, BranchId = g.branchId }).ToList();
            return iulist;

        }
        public class InvCombo
        {
            private int invoiceId;
            private string invoiceNumber;
            private int? branchId;
            private string invoiceType;

            public int InvoiceId { get => invoiceId; set => invoiceId = value; }
            public string InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
            public int? BranchId { get => branchId; set => branchId = value; }
            public string InvoiceType { get => invoiceType; set => invoiceType = value; }
        }

        public List<InvCombo> GetExternalInvoiceCombos(List<ItemTransferInvoice> ITInvoice)
        {
            List<InvCombo> iulist = new List<InvCombo>();

            iulist = ITInvoice.Select(g => new InvCombo { InvoiceId = g.invoiceId, InvoiceNumber = g.invNumber, BranchId = g.branchId, InvoiceType = g.invType }).ToList();
            return iulist;

        }

    }
}

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

    class BranchStoretable
    {
        public int id { get; set; }
        public Nullable<int> branchId { get; set; }
        public Nullable<int> storeId { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> isActive { get; set; }
        public Boolean canDelete { get; set; }

    }
    class BranchStore
    {
        public int id { get; set; }
        public Nullable<int> branchId { get; set; }
        public Nullable<int> storeId { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> isActive { get; set; }
        public Boolean canDelete { get; set; }

        // branch
        public int bbranchId { get; set; }
        public string bcode { get; set; }
        public string bname { get; set; }
        public string baddress { get; set; }
        public string bemail { get; set; }
        public string bphone { get; set; }
        public string bmobile { get; set; }
        public Nullable<System.DateTime> bcreateDate { get; set; }
        public Nullable<System.DateTime> bupdateDate { get; set; }
        public Nullable<int> bcreateUserId { get; set; }
        public Nullable<int> bupdateUserId { get; set; }
        public string bnotes { get; set; }
        public Nullable<int> bparentId { get; set; }
        public Nullable<byte> bisActive { get; set; }
        public string btype { get; set; }

        // store
        public int sbranchId { get; set; }
        public string scode { get; set; }
        public string sname { get; set; }
        public string saddress { get; set; }
        public string semail { get; set; }
        public string sphone { get; set; }
        public string smobile { get; set; }
        public Nullable<System.DateTime> screateDate { get; set; }
        public Nullable<System.DateTime> supdateDate { get; set; }
        public Nullable<int> screateUserId { get; set; }
        public Nullable<int> supdateUserId { get; set; }
        public string snotes { get; set; }
        public Nullable<int> sparentId { get; set; }
        public Nullable<byte> sisActive { get; set; }
        public string stype { get; set; }


        public async Task<List<BranchStore>> GetAll()
        {
            List<BranchStore> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "BranchStore/Get");
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
                    list = JsonConvert.DeserializeObject<List<BranchStore>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<BranchStore>();
                }
                return list;
            }
        }



        public async Task<List<BranchStore>> GetByBranchId(int branchId)
        {
            List<BranchStore> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "BranchStore/GetByBranchId?branchId=" + branchId);
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
                    list = JsonConvert.DeserializeObject<List<BranchStore>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<BranchStore>();
                }
                return list;
            }
        }

        public async Task<List<BranchStoretable>> GetByBranchIdtable(int branchId)
        {
            List<BranchStoretable> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "BranchStore/GetByBranchId?branchId=" + branchId);
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
                    list = JsonConvert.DeserializeObject<List<BranchStoretable>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<BranchStoretable>();
                }
                return list;
            }
        }

        public async Task<string> Save(BranchStore newObject)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(newObject);

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
                request.RequestUri = new Uri(Global.APIUri
                                             + "BranchStore/Save?newObject="
                                             + myContent);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    message = JsonConvert.DeserializeObject<string>(message);
                    return message;
                }
                return "";
            }
        }


        public async Task<BranchStore> GetByID(int Id)
        {
            BranchStore Object = new BranchStore();

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
                request.RequestUri = new Uri(Global.APIUri + "BranchStore/GetByID");
                request.Headers.Add("Id", Id.ToString());
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    Object = JsonConvert.DeserializeObject<BranchStore>(jsonString);

                    return Object;
                }

                return Object;
            }
        }





        public async Task<Boolean> Delete(int Id, int userId, bool final)
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
                request.RequestUri = new Uri(Global.APIUri + "BranchStore/Delete?Id=" + Id + "&userId=" + userId + "&final=" + final);

                request.Headers.Add("APIKey", Global.APIKey);

                request.Method = HttpMethod.Post;

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }


        // get is exist
        public async Task<string> UpdateStoresById(List<BranchStoretable> newList, int branchId, int userId)
        {
            string message = "";
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(newList);

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
                request.RequestUri = new Uri(Global.APIUri + "BranchStore/UpdateStoresById?newList=" + myContent + "&branchId=" + branchId + "&userId=" + userId);
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


//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;
//using POS;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;

//namespace POS.Classes
//{
//    class BranchStore
//    {
//        public int id { get; set; }
//        public Nullable<int> branchId { get; set; }
//        public Nullable<int> storeId { get; set; }
//        public string note { get; set; }
//        public Nullable<System.DateTime> createDate { get; set; }
//        public Nullable<System.DateTime> updateDate { get; set; }
//        public Nullable<int> createUserId { get; set; }
//        public Nullable<int> updateUserId { get; set; }
//        public Nullable<int> isActive { get; set; }
//        public Boolean canDelete { get; set; }

//        // branch
//        public int bbranchId { get; set; }
//        public string bcode { get; set; }
//        public string bname { get; set; }
//        public string baddress { get; set; }
//        public string bemail { get; set; }
//        public string bphone { get; set; }
//        public string bmobile { get; set; }
//        public Nullable<System.DateTime> bcreateDate { get; set; }
//        public Nullable<System.DateTime> bupdateDate { get; set; }
//        public Nullable<int> bcreateUserId { get; set; }
//        public Nullable<int> bupdateUserId { get; set; }
//        public string bnotes { get; set; }
//        public Nullable<int> bparentId { get; set; }
//        public Nullable<byte> bisActive { get; set; }
//        public string btype { get; set; }

//        // store
//        public int sbranchId { get; set; }
//        public string scode { get; set; }
//        public string sname { get; set; }
//        public string saddress { get; set; }
//        public string semail { get; set; }
//        public string sphone { get; set; }
//        public string smobile { get; set; }
//        public Nullable<System.DateTime> screateDate { get; set; }
//        public Nullable<System.DateTime> supdateDate { get; set; }
//        public Nullable<int> screateUserId { get; set; }
//        public Nullable<int> supdateUserId { get; set; }
//        public string snotes { get; set; }
//        public Nullable<int> sparentId { get; set; }
//        public Nullable<byte> sisActive { get; set; }
//        public string stype { get; set; }


//        public async Task<List<BranchStore>> GetAll()
//        {
//            List<BranchStore> list = null;
//            // ... Use HttpClient.
//            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
//            using (var client = new HttpClient())
//            {
//                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
//                client.BaseAddress = new Uri(Global.APIUri);
//                client.DefaultRequestHeaders.Clear();
//                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
//                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
//                HttpRequestMessage request = new HttpRequestMessage();
//                request.RequestUri = new Uri(Global.APIUri + "BranchStore/Get");
//                request.Headers.Add("APIKey", Global.APIKey);
//                request.Method = HttpMethod.Get;
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                HttpResponseMessage response = await client.SendAsync(request);

//                if (response.IsSuccessStatusCode)
//                {
//                    var jsonString = await response.Content.ReadAsStringAsync();
//                    jsonString = jsonString.Replace("\\", string.Empty);
//                    jsonString = jsonString.Trim('"');
//                    // fix date format
//                    JsonSerializerSettings settings = new JsonSerializerSettings
//                    {
//                        Converters = new List<JsonConverter> { new BadDateFixingConverter() },
//                        DateParseHandling = DateParseHandling.None
//                    };
//                    list = JsonConvert.DeserializeObject<List<BranchStore>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
//                    return list;
//                }
//                else //web api sent error response 
//                {
//                    list = new List<BranchStore>();
//                }
//                return list;
//            }
//        }



//        public async Task<List<BranchStore>> GetByBranchId(int branchId)
//        {
//            List<BranchStore> list = null;
//            // ... Use HttpClient.
//            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
//            using (var client = new HttpClient())
//            {
//                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
//                client.BaseAddress = new Uri(Global.APIUri);
//                client.DefaultRequestHeaders.Clear();
//                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
//                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
//                HttpRequestMessage request = new HttpRequestMessage();
//                request.RequestUri = new Uri(Global.APIUri + "BranchStore/GetByBranchId?branchId=" + branchId);
//                request.Headers.Add("APIKey", Global.APIKey);
//                request.Method = HttpMethod.Get;
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                HttpResponseMessage response = await client.SendAsync(request);

//                if (response.IsSuccessStatusCode)
//                {
//                    var jsonString = await response.Content.ReadAsStringAsync();
//                    jsonString = jsonString.Replace("\\", string.Empty);
//                    jsonString = jsonString.Trim('"');
//                    // fix date format
//                    JsonSerializerSettings settings = new JsonSerializerSettings
//                    {
//                        Converters = new List<JsonConverter> { new BadDateFixingConverter() },
//                        DateParseHandling = DateParseHandling.None
//                    };
//                    list = JsonConvert.DeserializeObject<List<BranchStore>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
//                    return list;
//                }
//                else //web api sent error response 
//                {
//                    list = new List<BranchStore>();
//                }
//                return list;
//            }
//        }

//        public async Task<string> Save(BranchStore newObject)
//        {
//            // ... Use HttpClient.
//            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
//            // 
//            var myContent = JsonConvert.SerializeObject(newObject);

//            using (var client = new HttpClient())
//            {
//                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
//                client.BaseAddress = new Uri(Global.APIUri);
//                client.DefaultRequestHeaders.Clear();
//                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
//                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
//                HttpRequestMessage request = new HttpRequestMessage();
//                // encoding parameter to get special characters
//                myContent = HttpUtility.UrlEncode(myContent);
//                request.RequestUri = new Uri(Global.APIUri
//                                             + "BranchStore/Save?newObject="
//                                             + myContent);
//                request.Headers.Add("APIKey", Global.APIKey);
//                request.Method = HttpMethod.Post;
//                //set content type
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                var response = await client.SendAsync(request);

//                if (response.IsSuccessStatusCode)
//                {
//                    var message = await response.Content.ReadAsStringAsync();
//                    message = JsonConvert.DeserializeObject<string>(message);
//                    return message;
//                }
//                return "";
//            }
//        }


//        public async Task<BranchStore> GetByID(int Id)
//        {
//            BranchStore Object = new BranchStore();

//            // ... Use HttpClient.
//            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
//            using (var client = new HttpClient())
//            {
//                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
//                client.BaseAddress = new Uri(Global.APIUri);
//                client.DefaultRequestHeaders.Clear();
//                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
//                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
//                HttpRequestMessage request = new HttpRequestMessage();
//                request.RequestUri = new Uri(Global.APIUri + "BranchStore/GetByID");
//                request.Headers.Add("Id", Id.ToString());
//                request.Headers.Add("APIKey", Global.APIKey);
//                request.Method = HttpMethod.Get;
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                var response = await client.SendAsync(request);

//                if (response.IsSuccessStatusCode)
//                {
//                    var jsonString = await response.Content.ReadAsStringAsync();

//                    Object = JsonConvert.DeserializeObject<BranchStore>(jsonString);

//                    return Object;
//                }

//                return Object;
//            }
//        }





//        public async Task<Boolean> Delete(int Id, int userId, bool final)
//        {
//            // ... Use HttpClient.
//            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

//            using (var client = new HttpClient())
//            {
//                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
//                client.BaseAddress = new Uri(Global.APIUri);
//                client.DefaultRequestHeaders.Clear();
//                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
//                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
//                HttpRequestMessage request = new HttpRequestMessage();
//                request.RequestUri = new Uri(Global.APIUri + "BranchStore/Delete?Id=" + Id + "&userId=" + userId + "&final=" + final);

//                request.Headers.Add("APIKey", Global.APIKey);

//                request.Method = HttpMethod.Post;

//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                var response = await client.SendAsync(request);

//                if (response.IsSuccessStatusCode)
//                {
//                    return true;
//                }
//                return false;
//            }
//        }


//        // get is exist
//        public async Task<string> UpdateStoresById(List<BranchStore> newList, int branchId, int userId)
//        {
//            string message = "";
//            // ... Use HttpClient.
//            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
//            // 
//            var myContent = JsonConvert.SerializeObject(newList);

//            using (var client = new HttpClient())
//            {
//                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
//                client.BaseAddress = new Uri(Global.APIUri);
//                client.DefaultRequestHeaders.Clear();
//                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
//                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
//                HttpRequestMessage request = new HttpRequestMessage();
//                // encoding parameter to get special characters
//                myContent = HttpUtility.UrlEncode(myContent);
//                request.RequestUri = new Uri(Global.APIUri + "BranchStore/UpdateStoresById?newList=" + myContent + "&branchId=" + branchId + "&userId=" + userId);
//                request.Headers.Add("APIKey", Global.APIKey);
//                request.Method = HttpMethod.Post;
//                //set content type
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                var response = await client.SendAsync(request);

//                if (response.IsSuccessStatusCode)
//                {
//                    message = await response.Content.ReadAsStringAsync();
//                    message = JsonConvert.DeserializeObject<string>(message);
//                }
//                return message;
//            }
//        }

//    }
//}


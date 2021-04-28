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
    class Branch
    {
            public int branchId { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string details { get; set; }
            public string address { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string mobile { get; set; }
            public DateTime createDate { get; set; }
            public DateTime updateDate { get; set; }
            public int createUserId { get; set; }
            public int updateUserId { get; set; }
            public string notes { get; set; }
            public int parentId { get; set; }
            public string type { get; set; }

        public async Task<List<Branch>> GetBranchesAsync(string type)
        {
            List<Branch> branches = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Branches/Get?type=" + type);
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
                    branches = JsonConvert.DeserializeObject<List<Branch>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return branches;
                }
                else //web api sent error response 
                {
                    branches = new List<Branch>();
                }
                return branches;
            }
        }

        public async Task<string> saveBranch(Branch branch)
            {
                // ... Use HttpClient.
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                // 
                var myContent = JsonConvert.SerializeObject(branch);

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
                    request.RequestUri = new Uri(Global.APIUri + "Branches/Save?branchObject=" + myContent);
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

        public async Task<Branch> getBranchById(int branchId)
            {
                Branch branch = new Branch();

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
                    request.RequestUri = new Uri(Global.APIUri + "Branches/GetBranchByID");
                    request.Headers.Add("APIKey", Global.APIKey);
                    request.Headers.Add("branchId", branchId.ToString());
                    request.Method = HttpMethod.Get;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();

                        branch = JsonConvert.DeserializeObject<Branch>(jsonString);

                        return branch;
                    }

                    return branch;
                }
            }
            public async Task<string> deleteBranch(int branchId)
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
                    request.RequestUri = new Uri(Global.APIUri + "Branches/Delete");
                    request.Headers.Add("APIKey", Global.APIKey);
                    request.Headers.Add("delBranchId", branchId.ToString());
                    request.Headers.Add("userId", "1");
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
        }
    }


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

namespace POS.Classes
{
     class Agent
    {
        public  int agentId { get; set; }        
        public string name { get; set; }
        public string code { get; set; }
        public string company { get; set; }
        public string address { get; set; }
        public string details { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string image { get; set; }
        public string type { get; set; }
        public string accType { get; set; }
        public float balance { get; set; }
        public int isDefault { get; set; }
        public DateTime createDate = DateTime.Now;
        public DateTime updateDate = DateTime.Now;
        public int createUserId { get; set; }
        public int updateUserId { get; set; }
        public string notes { get; set; }
        public int isActive { get; set; }
        public async Task<List<Agent>> GetAgentsAsync(string type)
        {
            List<Agent> agents = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Agent/Get");
                request.Headers.Add("APIKey", Global.APIKey);
                request.Headers.Add("type", type);
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
//                    jsonString = "[{\"agentId\":1,\"name\":\"Ahmad\",\"code\":\"01\",\"company\":\"a1\",\"address\":\"a12\",\"details\":\"qwer\",\"email\":\"Ahmad@gmail.com\",\"phone\":\"09875641\",\"mobile\":\"032156478\",\"image\":\"a\",\"type\":\"V\",\"accType\":\"S\",\"balance\":12.0000,\"isDefault\":1,\"createDate\":\"2013-01-20T00:00:00Z\",\"updateDate\":\"2013-01-20T00:00:00Z\",\"createUserId\":11,\"updateUserId\":11,\"notes\":\"aa\",\"isActive\":1}]";
                    agents = JsonConvert.DeserializeObject<List<Agent>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });


                    return agents;
                }
                else //web api sent error response 
                {
                    agents = new List<Agent>();
                }
                return agents;
            }

        }
        // adding vendor by calling API metod "saveAgent"
        public async Task<Boolean> saveAgent(Agent agent)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(agent);

            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri(Global.APIUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri(Global.APIUri + "Agent/Save");
                request.Headers.Add("APIKey", Global.APIKey);
                request.Headers.Add("agentObject", myContent);
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

    }


}

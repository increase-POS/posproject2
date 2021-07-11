﻿using Newtonsoft.Json;
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
    public class UserSetValues
    {
        public int id { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> valId { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }



        public async Task<List<UserSetValues>> GetAll()
        {
            List<UserSetValues> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "userSetValues/Get");
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
                    list = JsonConvert.DeserializeObject<List<UserSetValues>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<UserSetValues>();
                }
                return list;
            }
        }




        //
        public async Task<string> Save(UserSetValues obj)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(obj);

            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri(Global.APIUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.Add("Keep-Alive", "3600");
                HttpRequestMessage request = new HttpRequestMessage();
                //    encoding parameter to get special characters
                myContent = HttpUtility.UrlEncode(myContent);
                request.RequestUri = new Uri(Global.APIUri + "userSetValues/Saveu?Object=" + myContent);
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


        //
        public async Task<UserSetValues> GetByID(int id)
        {
            UserSetValues Object = new UserSetValues();

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
                request.RequestUri = new Uri(Global.APIUri + "userSetValues/GetByID");
                request.Headers.Add("Id", id.ToString());
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    Object = JsonConvert.DeserializeObject<UserSetValues>(jsonString);

                    return Object;
                }

                return Object;
            }
        }





        public async Task<Boolean> Delete(int Id)
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
                request.RequestUri = new Uri(Global.APIUri + "userSetValues/Delete?Id=" + Id);

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
//    class UserSetValues
//    {
//        public int id { get; set; }
//        public Nullable<int> userId { get; set; }
//        public Nullable<int> valId { get; set; }
//        public string note { get; set; }
//        public Nullable<System.DateTime> createDate { get; set; }
//        public Nullable<System.DateTime> updateDate { get; set; }
//        public Nullable<int> createUserId { get; set; }
//        public Nullable<int> updateUserId { get; set; }



//        public async Task<List<UserSetValues>> GetAll()
//        {
//            List<UserSetValues> list = null;
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
//                request.RequestUri = new Uri(Global.APIUri + "userSetValues/Get");
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
//                    list = JsonConvert.DeserializeObject<List<UserSetValues>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
//                    return list;
//                }
//                else //web api sent error response 
//                {
//                    list = new List<UserSetValues>();
//                }
//                return list;
//            }
//        }


//        public async Task<string> Save(UserSetValues newObject)
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
//                                             + "userSetValues/Save?newObject="
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


//        public async Task<UserSetValues> GetByID(int id)
//        {
//            UserSetValues Object = new UserSetValues();

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
//                request.RequestUri = new Uri(Global.APIUri + "userSetValues/GetByID");
//                request.Headers.Add("Id", id.ToString());
//                request.Headers.Add("APIKey", Global.APIKey);
//                request.Method = HttpMethod.Get;
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                var response = await client.SendAsync(request);

//                if (response.IsSuccessStatusCode)
//                {
//                    var jsonString = await response.Content.ReadAsStringAsync();

//                    Object = JsonConvert.DeserializeObject<UserSetValues>(jsonString);

//                    return Object;
//                }

//                return Object;
//            }
//        }





//        public async Task<Boolean> Delete(int Id)
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
//                request.RequestUri = new Uri(Global.APIUri + "userSetValues/Delete?Id=" + Id  );

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


//    }
//}


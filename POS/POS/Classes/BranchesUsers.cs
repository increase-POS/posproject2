using Newtonsoft.Json;
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

    public class BranchesUserstable
    {
        public int branchsUsersId { get; set; }
        public Nullable<int> branchId { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
    }

    public class BranchesUsers
    {

        public int branchsUsersId { get; set; }
        public Nullable<int> branchId { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }

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

        // user
        public int uuserId { get; set; }
        public string uusername { get; set; }
        public string upassword { get; set; }
        public string uname { get; set; }
        public string ulastname { get; set; }
        public string ujob { get; set; }
        public string uworkHours { get; set; }
        public DateTime? ucreateDate { get; set; }
        public DateTime? uupdateDate { get; set; }
        public int? ucreateUserId { get; set; }
        public int? uupdateUserId { get; set; }
        public string uphone { get; set; }
        public string umobile { get; set; }
        public string uemail { get; set; }
        public string unotes { get; set; }
        public string uaddress { get; set; }
        public short? uisActive { get; set; }
        public byte? uisOnline { get; set; }
        public Boolean ucanDelete { get; set; }
        public string uimage { get; set; }
        /// <summary>
        /// ///////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        /// 



        public async Task<List<BranchesUsers>> Get()
        {
            List<BranchesUsers> memberships = null;
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
                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/Get");
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    memberships = JsonConvert.DeserializeObject<List<BranchesUsers>>(jsonString);

                    return memberships;
                }
                else //web api sent error response 
                {
                    memberships = new List<BranchesUsers>();
                }
                return memberships;
            }

        }

        public async Task<string> Save(BranchesUsers obj)
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
                // encoding parameter to get special characters
                myContent = HttpUtility.UrlEncode(myContent);
                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/Save?Object=" + myContent);
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

        public async Task<BranchesUsers> GetByID(int branchsUsersId)
        {
            BranchesUsers obj = new BranchesUsers();

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
                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/GetByID?branchsUsersId=" + branchsUsersId);
                request.Headers.Add("APIKey", Global.APIKey);

                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    obj = JsonConvert.DeserializeObject<BranchesUsers>(jsonString);

                    return obj;
                }

                return obj;
            }
        }

        public async Task<string> Delete(int branchsUsersId)
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
                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/Delete?branchsUsersId=" + branchsUsersId);
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


        public async Task<List<BranchesUserstable>> GetBranchesByUserIdtable(int userId)
        {
            List<BranchesUserstable> memberships = null;
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
                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/GetBranchesByUserId?userId=" + userId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    memberships = JsonConvert.DeserializeObject<List<BranchesUserstable>>(jsonString);

                    return memberships;
                }
                else //web api sent error response 
                {
                    memberships = new List<BranchesUserstable>();
                }
                return memberships;
            }

        }

        public async Task<List<BranchesUsers>> GetBranchesByUserId(int userId)
        {
            List<BranchesUsers> memberships = null;
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
                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/GetBranchesByUserId?userId=" + userId);
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    memberships = JsonConvert.DeserializeObject<List<BranchesUsers>>(jsonString);

                    return memberships;
                }
                else //web api sent error response 
                {
                    memberships = new List<BranchesUsers>();
                }
                return memberships;
            }

        }


        public async Task<string> UpdateBranchByUserId(List<BranchesUserstable> newList, int userId, int updateUserId)
        {
            string message = "";
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

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
                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/UpdateBranchByUserId?newList=" + myContent + "&userId=" + userId + "&updateUserId=" + updateUserId);
                request.Headers.Add("APIKey", Global.APIKey);
                // request.Headers.Add("newList", myContent);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);
                //return myContent.ToString();
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
//    public class BranchesUsers
//    {

//        public int branchsUsersId { get; set; }
//        public Nullable<int> branchId { get; set; }
//        public Nullable<int> userId { get; set; }
//        public Nullable<System.DateTime> createDate { get; set; }
//        public Nullable<System.DateTime> updateDate { get; set; }
//        public Nullable<int> createUserId { get; set; }
//        public Nullable<int> updateUserId { get; set; }

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

//        // user
//        public int uuserId { get; set; }
//        public string uusername { get; set; }
//        public string upassword { get; set; }
//        public string uname { get; set; }
//        public string ulastname { get; set; }
//        public string ujob { get; set; }
//        public string uworkHours { get; set; }
//        public DateTime? ucreateDate { get; set; }
//        public DateTime? uupdateDate { get; set; }
//        public int? ucreateUserId { get; set; }
//        public int? uupdateUserId { get; set; }
//        public string uphone { get; set; }
//        public string umobile { get; set; }
//        public string uemail { get; set; }
//        public string unotes { get; set; }
//        public string uaddress { get; set; }
//        public short? uisActive { get; set; }
//        public byte? uisOnline { get; set; }
//        public Boolean ucanDelete { get; set; }
//        public string uimage { get; set; }
//        /// <summary>
//        /// ///////////////////////////////////////
//        /// </summary>
//        /// <returns></returns>
//        /// 

//        public async Task<List<BranchesUsers>> Get()
//        {
//            List<BranchesUsers> memberships = null;
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
//                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/Get");
//                request.Headers.Add("APIKey", Global.APIKey);
//                request.Method = HttpMethod.Get;
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                HttpResponseMessage response = await client.SendAsync(request);

//                if (response.IsSuccessStatusCode)
//                {
//                    var jsonString = await response.Content.ReadAsStringAsync();

//                    memberships = JsonConvert.DeserializeObject<List<BranchesUsers>>(jsonString);

//                    return memberships;
//                }
//                else //web api sent error response 
//                {
//                    memberships = new List<BranchesUsers>();
//                }
//                return memberships;
//            }

//        }

//        public async Task<string> Save(BranchesUsers obj)
//        {
//            // ... Use HttpClient.
//            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
//            // 
//            var myContent = JsonConvert.SerializeObject(obj);

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
//                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/Save?Object=" + myContent);
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

//        public async Task<BranchesUsers> GetByID(int branchsUsersId)
//        {
//            BranchesUsers obj = new BranchesUsers();

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
//                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/GetByID?branchsUsersId=" + branchsUsersId);
//                request.Headers.Add("APIKey", Global.APIKey);

//                request.Method = HttpMethod.Get;
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                var response = await client.SendAsync(request);

//                if (response.IsSuccessStatusCode)
//                {
//                    var jsonString = await response.Content.ReadAsStringAsync();

//                    obj = JsonConvert.DeserializeObject<BranchesUsers>(jsonString);

//                    return obj;
//                }

//                return obj;
//            }
//        }

//        public async Task<string> Delete(int branchsUsersId)
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
//                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/Delete?branchsUsersId=" + branchsUsersId);
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




//        public async Task<List<BranchesUsers>> GetBranchesByUserId(int userId)
//        {
//            List<BranchesUsers> memberships = null;
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
//                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/GetBranchesByUserId?userId=" + userId);
//                request.Headers.Add("APIKey", Global.APIKey);
//                request.Method = HttpMethod.Get;
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                HttpResponseMessage response = await client.SendAsync(request);

//                if (response.IsSuccessStatusCode)
//                {
//                    var jsonString = await response.Content.ReadAsStringAsync();

//                    memberships = JsonConvert.DeserializeObject<List<BranchesUsers>>(jsonString);

//                    return memberships;
//                }
//                else //web api sent error response 
//                {
//                    memberships = new List<BranchesUsers>();
//                }
//                return memberships;
//            }

//        }


//        public async Task<string> UpdatebranchesByuserId(int userId, List<BranchesUsers> newBranchlist, int updateuserId)
//        {
//            string message = "";
//            // ... Use HttpClient.
//            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
//            // 
//            var myContent = JsonConvert.SerializeObject(newBranchlist);

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
//                request.RequestUri = new Uri(Global.APIUri + "BranchesUsers/UpdatebranchesByuserId?newBranchlist=" + myContent);
//                request.Headers.Add("APIKey", Global.APIKey);
//                request.Headers.Add("userId", userId.ToString());
//                request.Headers.Add("updateuserId", updateuserId.ToString());
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

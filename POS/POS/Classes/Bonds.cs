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
    public class Bonds

    {
        public int bondId { get; set; }
        public string number { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<System.DateTime> deserveDate { get; set; }
        public string type { get; set; }
        public Nullable<byte> isRecieved { get; set; }
        public string notes { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Boolean canDelete { get; set; }
        public Nullable<byte> isActive { get; set; }
        public Nullable<int> cashTransId { get; set; }

        // cash trans

        public int ctcashTransId { get; set; }
        public string cttransType { get; set; }
        public Nullable<int> ctposId { get; set; }
        public Nullable<int> ctuserId { get; set; }
        public Nullable<int> ctagentId { get; set; }
        public Nullable<int> ctinvId { get; set; }
        public string cttransNum { get; set; }
        public Nullable<System.DateTime> ctcreateDate { get; set; }
        public Nullable<System.DateTime> ctupdateDate { get; set; }
        public Nullable<decimal> ctcash { get; set; }
        public Nullable<int> ctupdateUserId { get; set; }
        public Nullable<int> ctcreateUserId { get; set; }
        public string ctnotes { get; set; }
        public Nullable<int> ctposIdCreator { get; set; }
        public Nullable<byte> ctisConfirm { get; set; }
        public Nullable<int> ctcashTransIdSource { get; set; }
        public string ctside { get; set; }
        public string ctopSideNum { get; set; }
        public string ctdocName { get; set; }
        public string ctdocNum { get; set; }
        public string ctdocImage { get; set; }
        public Nullable<int> ctbankId { get; set; }
        public string ctbankName { get; set; }
        public string ctagentName { get; set; }
        public string ctusersName { get; set; }
        public string ctusersLName { get; set; }
        public string ctposName { get; set; }
        public string ctposCreatorName { get; set; }
        public Nullable<byte> ctisConfirm2 { get; set; }
        public int ctcashTrans2Id { get; set; }
        public Nullable<int> ctpos2Id { get; set; }

        public string ctpos2Name { get; set; }
        public string ctprocessType { get; set; }
        public Nullable<int> ctcardId { get; set; }
        public Nullable<int> ctbondId { get; set; }
        public string ctcreateUserName { get; set; }
        public string ctcreateUserJob { get; set; }
        public string ctcreateUserLName { get; set; }
        public string ctcardName { get; set; }
        public Nullable<System.DateTime> ctbondDeserveDate { get; set; }
        public Nullable<byte> ctbondIsRecieved { get; set; }
        public Nullable<int> ctshippingCompanyId { get; set; }
        public string ctshippingCompanyName { get; set; }

        public async Task<List<Bonds>> GetAll()
        {
            List<Bonds> bonds = null;
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
                request.RequestUri = new Uri(Global.APIUri + "bonds/Get");
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
                    bonds = JsonConvert.DeserializeObject<List<Bonds>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return bonds;
                }
                else //web api sent error response 
                {
                    bonds = new List<Bonds>();
                }
                return bonds;
            }
        }

        public async Task<List<Bonds>> GetByisActive(byte isActive)
        {
            List<Bonds> bonds = null;
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
                request.RequestUri = new Uri(Global.APIUri + "bonds/GetByisActive?isActive=" + isActive);
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
                    bonds = JsonConvert.DeserializeObject<List<Bonds>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return bonds;
                }
                else //web api sent error response 
                {
                    bonds = new List<Bonds>();
                }
                return bonds;
            }
        }
        public async Task<string> Save(Bonds bond)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(bond);

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
                                             + "bonds/Save?bondObject="
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

       
        public async Task<Bonds> getBondsById(int bondId)
        {
            Bonds bond = new Bonds();

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
                request.RequestUri = new Uri(Global.APIUri + "bonds/GetbondByID");
                request.Headers.Add("bondId", bondId.ToString());
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    bond = JsonConvert.DeserializeObject<Bonds>(jsonString);

                    return bond;
                }

                return bond;
            }
        }

      



        public async Task<Boolean> deleteBonds(int bondId, int userId, bool final)
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
                request.RequestUri = new Uri(Global.APIUri + "bonds/Delete?bondId=" + bondId + "&userId=" + userId + "&final=" + final);

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


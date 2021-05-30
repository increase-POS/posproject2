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
    class Offer
    {
        public int offerId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public Nullable<byte> isActive { get; set; }
        public string discountType { get; set; }
        public Nullable<decimal> discountValue { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public string notes { get; set; }
        public Boolean canDelete { get; set; }

        public async Task<List<Offer>> GetOffersAsync()
        {
            List<Offer> offers = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Offers/Get");
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
                    offers = JsonConvert.DeserializeObject<List<Offer>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return offers;
                }
                else //web api sent error response 
                {
                    offers = new List<Offer>();
                }
                return offers;
            }
        }

        public async Task<string> Save(Offer offer)
        {
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            // 
            var myContent = JsonConvert.SerializeObject(offer);

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
                                             + "Offers/Save?offerObject="
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

        public async Task<Offer> getOfferById(int offerId)
        {
            Offer offer = new Offer();

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
                request.RequestUri = new Uri(Global.APIUri + "Offers/GetOfferByID");
                request.Headers.Add("offerId", offerId.ToString());
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    offer = JsonConvert.DeserializeObject<Offer>(jsonString);

                    return offer;
                }

                return offer;
            }
        }

        public async Task<Boolean> deleteOffer(int offerId, int userId, bool final)
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
                request.RequestUri = new Uri(Global.APIUri + "Offers/Delete?offerId=" + offerId + "&userId=" + userId + "&final=" + final);

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


    }
}

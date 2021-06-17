﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace POS.Classes
{
    public class CashTransfer
    {
        public int cashTransId { get; set; }
        public string transType { get; set; }
        public Nullable<int> posId { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> agentId { get; set; }
        public Nullable<int> invId { get; set; }
        public string transNum { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<decimal> cash { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> createUserId { get; set; }
        public string notes { get; set; }
        public Nullable<int> posIdCreator { get; set; }
        public Nullable<byte> isConfirm { get; set; }
        public Nullable<int> cashTransIdSource { get; set; }
        public string side { get; set; }
        public string docName { get; set; }
        public string docNum { get; set; }
        public string docImage { get; set; }
        public Nullable<int> bankId { get; set; }
        public string bankName { get; set; }
        public string agentName { get; set; }
        public string usersName { get; set; }// side=u
        public string posName { get; set; }
        public string pos2Name { get; set; }
        public Nullable<int> pos2Id { get; set; }
        public string posCreatorName { get; set; }
        public int cashTrans2Id { get; set; }
        public Nullable<byte> isConfirm2 { get; set; }
        public string processType { get; set; }
        public Nullable<int> cardId { get; set; }
        public string createUserName { get; set; }
        public string createUserJob { get; set; }
        public string createUserLName { get; set; }
        public string usersLName { get; set; } // side=u
        public string cardName { get; set; }// processType=card
        public string reciveName { get; set; }
        public async Task<List<CashTransfer>> GetCashTransferAsync(string type, string side)
        {
            List<CashTransfer> cashtransfer = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Cashtransfer/GetBytypeandSide?type=" + type + "&side=" + side);
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
                    cashtransfer = JsonConvert.DeserializeObject<List<CashTransfer>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return cashtransfer;
                }
                else //web api sent error response 
                {
                    cashtransfer = new List<CashTransfer>();
                }
                return cashtransfer;
            }

        }


        // 
        public async Task<CashTransfer> GetByInvId(int invId)
        {
            CashTransfer cashtransfer = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Cashtransfer/GetByInvId?invId=" + invId );
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
                    cashtransfer = JsonConvert.DeserializeObject<CashTransfer>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return cashtransfer;
                }
                else //web api sent error response 
                {
                    cashtransfer = new CashTransfer();
                }
                return cashtransfer;
            }

        }
        public async Task<CashTransfer> GetByID(int cashTransferId)
        {
            CashTransfer casht = new CashTransfer();

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
                request.RequestUri = new Uri(Global.APIUri + "Cashtransfer/GetByID");
                request.Headers.Add("APIKey", Global.APIKey);
                request.Headers.Add("cashTransId", cashTransferId.ToString());
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    casht = JsonConvert.DeserializeObject<CashTransfer>(jsonString);

                    return casht;
                }

                return casht;
            }
        }
        /// ///////////////////////////////////////

        public async Task<string> Save(CashTransfer cashTr)
        {
            string message = "";
            // ... Use HttpClient.
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            string myContent = JsonConvert.SerializeObject(cashTr);

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

                request.RequestUri = new Uri(Global.APIUri + "Cashtransfer/Save?Object=" + myContent);
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



        public async Task<List<CashTransfer>> GetbySourcId(string side, int sourceId)
        {
            List<CashTransfer> cashtransfer = null;
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
                request.RequestUri = new Uri(Global.APIUri + "Cashtransfer/GetbySourcId?sourceId=" + sourceId + "&side=" + side);
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
                    cashtransfer = JsonConvert.DeserializeObject<List<CashTransfer>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return cashtransfer;
                }
                else //web api sent error response 
                {
                    cashtransfer = new List<CashTransfer>();
                }
                return cashtransfer;
            }

        }

        public async Task<string> deletePosTrans(int cashTransId)
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
                request.RequestUri = new Uri(Global.APIUri + "Cashtransfer/Delete?cashTransId=" + cashTransId );
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Post;
                //set content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    message = JsonConvert.DeserializeObject<string>(message);
                    return message;// if message= 0 not deleted because two pos isconfirm==1 
                                   // -if  message= 1 then deleted because one or two of pos isconfirm==0
                }
                return "error";
            }
        }

        public async Task<string> MovePosCash(int cashTransId,int userIdD)
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
                request.RequestUri = new Uri(Global.APIUri + "Cashtransfer/MovePosCash?cashTransId=" + cashTransId+"&useridD="+ userIdD);
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
                    /* message value:
                      Ok = transdone 
                      or
                      nobalanceinpullpos  -pullposnotconfirmed -nopullidornotconfirmed-idnotfound      
                     * */
                }
                return "error";
            }
        }
    }

}


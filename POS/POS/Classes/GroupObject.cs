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
    class GroupObject
    {
        public int id { get; set; }
        public Nullable<int> groupId { get; set; }
        public Nullable<int> objectId { get; set; }
        public Nullable<int> parentObjectId { get; set; }
        public string parentObjectName { get; set; }
        public string notes { get; set; }
        public Nullable<byte> addOb { get; set; }
        public Nullable<byte> updateOb { get; set; }
        public Nullable<byte> deleteOb { get; set; }
        public Nullable<byte> showOb { get; set; }
        public Nullable<byte> reportOb { get; set; }
        public Nullable<byte> levelOb { get; set; }
        public string objectName { get; set; }
        public string objectType { get; set; }
        public string desc { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> isActive { get; set; }
        public Boolean canDelete { get; set; }
        public string GroupName { get; set; }

        public async Task<List<GroupObject>> GetAll()
        {
            List<GroupObject> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "GroupObject/Get");
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
                    list = JsonConvert.DeserializeObject<List<GroupObject>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<GroupObject>();
                }
                return list;
            }
        }

   
        public async Task<string> Save(GroupObject newObject)
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
                                             + "GroupObject/Save?newObject="
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

       
        public async Task<GroupObject> GetByID(int valId)
        {
            GroupObject Object = new GroupObject();

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
                request.RequestUri = new Uri(Global.APIUri + "GroupObject/GetByID");
                request.Headers.Add("Id", valId.ToString());
                request.Headers.Add("APIKey", Global.APIKey);
                request.Method = HttpMethod.Get;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    Object = JsonConvert.DeserializeObject<GroupObject>(jsonString);

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
                request.RequestUri = new Uri(Global.APIUri + "GroupObject/Delete?Id=" + Id + "&userId=" + userId + "&final=" + final);

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

        public async Task<string> AddGroupObjectList(List<GroupObject> newList)
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
                request.RequestUri = new Uri(Global.APIUri + "GroupObject/AddGroupObjectList?newList=" + myContent);
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

        public async Task<List<GroupObject>> GetByGroupId(int groupId)
        {
            List<GroupObject> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "GroupObject/GetByGroupId?groupId=" + groupId);
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
                    list = JsonConvert.DeserializeObject<List<GroupObject>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<GroupObject>();
                }
                return list;
            }
        }

        //
        public async Task<List<GroupObject>> GetUserpermission(int userId)
        {
            List<GroupObject> list = null;
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
                request.RequestUri = new Uri(Global.APIUri + "GroupObject/GetUserpermission?userId=" + userId);
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
                    list = JsonConvert.DeserializeObject<List<GroupObject>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    return list;
                }
                else //web api sent error response 
                {
                    list = new List<GroupObject>();
                }
                return list;
            }
        }


        public bool HasPermission(string objectname, List<GroupObject> GOList)
        {

            List<GroupObject> currlist = new List<GroupObject>();
            currlist = GetObjSons(objectname, GOList);
            currlist = currlist.Where(X => (X.addOb == 1 || X.updateOb == 1 || X.deleteOb == 1 || X.showOb == 1 || X.reportOb == 1)).ToList();
            if (currlist != null)
            {
                if (currlist.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }

        //
        private List<GroupObject> objlist = new List<GroupObject>();
        //

        public List<GroupObject> GetObjSons(string objectName, List<GroupObject> GOList)
        {
            objlist = new List<GroupObject>();
            List<GroupObject> opl = new List<GroupObject>();

            // objlist;
            GroupObject firstelement = new GroupObject();

            firstelement = GOList.Where(X => X.objectName == objectName).FirstOrDefault();
            //  firstelement.objectId = objectId;
            if (firstelement != null)
            {
                objlist.Add(firstelement);
                SonsofObject(objlist, GOList);
                return (objlist);
            }
            else
            {
                return opl;
            }

        }

        private void SonsofObject(List<GroupObject> objlist1, List<GroupObject> mainobjlist)
        {

            List<GroupObject> templist = new List<GroupObject>();
            List<GroupObject> templist2 = new List<GroupObject>();
            if (objlist1.Count > 0)
            {
                foreach (GroupObject row in objlist1.ToList())
                {
                    //   templist = null;
                    if (row != null)
                    {
                        templist = mainobjlist.Where(X => X.parentObjectId == row.objectId).ToList();
                        /*
                                                    templist = (from O in mainobjlist.ToList()
                                                            where O.parentObjectId == row.objectId

                                                            select new GroupObject
                                                            {
                                                                objectId = O.objectId,
                                                                parentObjectId = O.parentObjectId,
                                                            }

                                                            ).ToList();
                                                            */

                    }

                    if (templist.Count > 0)
                    {
                        objlist.AddRange(templist);
                        templist2.AddRange(templist);
                    }


                }
                if (templist2.Count > 0)
                {
                    SonsofObject(templist2, mainobjlist);
                }


            }


        }


        //
    }
}


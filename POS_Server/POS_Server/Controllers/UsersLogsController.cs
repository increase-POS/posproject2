using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{





    [RoutePrefix("api/UsersLogs")]
    public class UsersLogsController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            bool canDelete = false;

            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid) // APIKey is valid
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var List = (from S in  entity.usersLogs                                         
                                         select new UsersLogsModel()
                                         {
                                            logId=S.logId,

                                             sInDate=S.sInDate,
                                             sOutDate=S.sOutDate,
                                             posId=S.posId,
                                             userId=S.userId,
                                     
                                         }).ToList();
                    /*
                     * 
 

    public int logId { get; set; }
            public Nullable<System.DateTime> sInDate { get; set; }
            public Nullable<System.DateTime> sOutDate { get; set; }
            public Nullable<int> posId { get; set; }
            public Nullable<int> userId { get; set; }
            public bool canDelete { get; set; }

logId
sInDate
sOutDate
posId
userId
canDelete


                    */



                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            //else
            return NotFound();
        }


        // get by userId
        [HttpGet]
        [Route("GetByUserId")]
        public IHttpActionResult GetByUserId(int userId)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
         

            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid) // APIKey is valid
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var List = (from S in entity.usersLogs
                                where S.userId== userId
                                select new UsersLogsModel()
                                {
                                    logId = S.logId,

                                    sInDate = S.sInDate,
                                    sOutDate = S.sOutDate,
                                    posId = S.posId,
                                    userId = S.userId,

                                }).ToList();
                    /*
                     * 
 

    public int logId { get; set; }
            public Nullable<System.DateTime> sInDate { get; set; }
            public Nullable<System.DateTime> sOutDate { get; set; }
            public Nullable<int> posId { get; set; }
            public Nullable<int> userId { get; set; }
            public bool canDelete { get; set; }

logId
sInDate
sOutDate
posId
userId
canDelete


                    */



                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            //else
            return NotFound();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetByID")]
        public IHttpActionResult GetByID(int logId)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var row = entity.usersLogs
                   .Where(u => u.logId == logId)
                   .Select(S => new
                   {
                           
                          S.logId,
                          S.sInDate,
                          S.sOutDate,
                          S.posId,
                          S.userId,


                   })
                   .FirstOrDefault();

                    if (row == null)
                        return NotFound();
                    else
                        return Ok(row);
                }
            }
            else
                return NotFound();
        }

        // add or update location
        [HttpPost]
        [Route("Save")]
        public string Save(string Object)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string message = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                Object = Object.Replace("\\", string.Empty);
                Object = Object.Trim('"');
                usersLogs newObject = JsonConvert.DeserializeObject<usersLogs>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                if (newObject.posId == 0 || newObject.posId == null)
                {
                    Nullable<int> id = null;
                    newObject.posId = id;
                }
                if (newObject.userId == 0 || newObject.userId == null)
                {
                    Nullable<int> id = null;
                    newObject.userId = id;
                }

          

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var locationEntity = entity.Set<usersLogs>();
                        if (newObject.logId == 0)
                        {
                            // signIn

                            newObject.sInDate = DateTime.Now;
                         

                            locationEntity.Add(newObject);
                            entity.SaveChanges();
                            message = newObject.logId.ToString();
                        }
                        else
                        {//signOut
                            var tmpObject = entity.usersLogs.Where(p => p.logId == newObject.logId).FirstOrDefault();

                      

                            tmpObject.logId = newObject.logId;
                           //  tmpObject.sInDate=newObject.sInDate;
                             tmpObject.sOutDate= newObject.sOutDate;
                         //    tmpObject.posId=newObject.posId;
                          //  tmpObject.userId = newObject.userId;


                            entity.SaveChanges();

                            message = tmpObject.logId.ToString();
                        }
                      //  entity.SaveChanges();
                    }
                }
                catch
                {
                    message = "-1";
                }
            }
            return message;
        }

        [HttpPost]
        [Route("Delete")]
        public string Delete(int logId, int userId,bool final)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int message = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }

            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            if (valid)
            {
                if (final)
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            usersLogs objectDelete = entity.usersLogs.Find(logId);

                            entity.usersLogs.Remove(objectDelete);
                        message=    entity.SaveChanges();
                          
                            return message.ToString();
                        }
                    }
                    catch
                    { 
                        return "-1";
                    }
                }
                return "-2";
          
            }
            else
                return "-3";
        }



    }
}
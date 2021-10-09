using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POS_Server.Models.VM;
using System.Security.Claims;
using Newtonsoft.Json.Converters;

namespace POS_Server.Controllers
{

    [RoutePrefix("api/UsersLogs")]
    public class UsersLogsController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("Get")]
        public ResponseVM Get()
        {
            // public ResponseVM GetPurinv(string token)

            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {

                try
                {

                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var list = (from S in entity.usersLogs
                                    select new UsersLogsModel()
                                    {
                                        logId = S.logId,

                                        sInDate = S.sInDate,
                                        sOutDate = S.sOutDate,
                                        posId = S.posId,
                                        userId = S.userId,

                                    }).ToList();

                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(list) };

                    }



                }
                catch
                {
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                }


            }

            //            var re = Request;
            //            var headers = re.Headers;
            //            string token = "";
            //            bool canDelete = false;

            //            if (headers.Contains("APIKey"))
            //            {
            //                token = headers.GetValues("APIKey").First();
            //            }
            //            Validation validation = new Validation();
            //            bool valid = validation.CheckApiKey(token);

            //            if (valid) // APIKey is valid
            //            {
            //                using (incposdbEntities entity = new incposdbEntities())
            //                {
            //                    var List = (from S in  entity.usersLogs                                         
            //                                         select new UsersLogsModel()
            //                                         {
            //                                            logId=S.logId,

            //                                             sInDate=S.sInDate,
            //                                             sOutDate=S.sOutDate,
            //                                             posId=S.posId,
            //                                             userId=S.userId,

            //                                         }).ToList();
            //                    /*
            //                     * 


            //    public int logId { get; set; }
            //            public Nullable<System.DateTime> sInDate { get; set; }
            //            public Nullable<System.DateTime> sOutDate { get; set; }
            //            public Nullable<int> posId { get; set; }
            //            public Nullable<int> userId { get; set; }
            //            public bool canDelete { get; set; }

            //logId
            //sInDate
            //sOutDate
            //posId
            //userId
            //canDelete


            //                    */



            //                    if (List == null)
            //                        return NotFound();
            //                    else
            //                        return Ok(List);
            //                }
            //            }
            //            //else
            //            return NotFound();
        }


        // get by userId
        [HttpGet]
        [Route("GetByUserId")]
        public ResponseVM GetByUserId(string token)
        {
            // public ResponseVM GetPurinv(string token)int userId

            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int userId = 0;


                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }


                }


                try
                {

                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var item = (from S in entity.usersLogs
                                    where S.userId == userId
                                    select new UsersLogsModel()
                                    {
                                        logId = S.logId,

                                        sInDate = S.sInDate,
                                        sOutDate = S.sOutDate,
                                        posId = S.posId,
                                        userId = S.userId,

                                    }).ToList();





                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(item) };

                    }

                }
                catch
                {
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                }

            }
            //            var re = Request;
            //            var headers = re.Headers;
            //            string token = "";


            //            if (headers.Contains("APIKey"))
            //            {
            //                token = headers.GetValues("APIKey").First();
            //            }
            //            Validation validation = new Validation();
            //            bool valid = validation.CheckApiKey(token);

            //            if (valid) // APIKey is valid
            //            {
            //                using (incposdbEntities entity = new incposdbEntities())
            //                {
            //                    var List = (from S in entity.usersLogs
            //                                where S.userId== userId
            //                                select new UsersLogsModel()
            //                                {
            //                                    logId = S.logId,

            //                                    sInDate = S.sInDate,
            //                                    sOutDate = S.sOutDate,
            //                                    posId = S.posId,
            //                                    userId = S.userId,

            //                                }).ToList();
            //                    /*
            //                     * 


            //    public int logId { get; set; }
            //            public Nullable<System.DateTime> sInDate { get; set; }
            //            public Nullable<System.DateTime> sOutDate { get; set; }
            //            public Nullable<int> posId { get; set; }
            //            public Nullable<int> userId { get; set; }
            //            public bool canDelete { get; set; }

            //logId
            //sInDate
            //sOutDate
            //posId
            //userId
            //canDelete


            //                    */



            //                    if (List == null)
            //                        return NotFound();
            //                    else
            //                        return Ok(List);
            //                }
            //            }
            //            //else
            //            return NotFound();
        }

        // GET api/<controller> 
        [HttpGet]
        [Route("GetByID")]
        public ResponseVM GetByID(string token)
        {

            // public ResponseVM GetPurinv(string token)int logId

            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int logId = 0;


                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "logId")
                    {
                        logId = int.Parse(c.Value);
                    }
                }
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var item = entity.usersLogs
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
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(item) };
                    }

                }
                catch
                {
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                }

            }

            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid)
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var row = entity.usersLogs
            //       .Where(u => u.logId == logId)
            //       .Select(S => new
            //       {

            //              S.logId,
            //              S.sInDate,
            //              S.sOutDate,
            //              S.posId,
            //              S.userId,


            //       })
            //       .FirstOrDefault();

            //        if (row == null)
            //            return NotFound();
            //        else
            //            return Ok(row);
            //    }
            //}
            //else
            //    return NotFound();
        }


        //checkOtherUser
        [HttpGet]
        [Route("checkOtherUser")]
        public ResponseVM checkOtherUser(string token)
        {

            // public ResponseVM GetPurinv(string token)int userId
            string message = "";
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int userId = 0;


                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                }
                try
                {

                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        List<usersLogs> List = entity.usersLogs.Where(S => S.userId == userId && S.sOutDate == null).ToList();
                        if (List != null)
                        {
                            foreach (usersLogs row in List)
                            {
                                row.sOutDate = DateTime.Now;
                                message = entity.SaveChanges().ToString();
                            }

                            //  message = List.LastOrDefault().sOutDate.ToString();


                            //  return Ok(msg);
                        }
                        else
                        {

                            message = "-1";
                            // return Ok("none");
                        }

                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                    }
                    //  return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(item) };


                }
                catch
                {
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                }

            }
            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //string msg = "";

            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid) // APIKey is valid
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        List<usersLogs> List = entity.usersLogs.Where(S => S.userId == userId && S.sOutDate == null).ToList(); 
            //        if(List !=null)
            //        {
            //            foreach(usersLogs row in List)
            //           {
            //            row.sOutDate = DateTime.Now;
            //            entity.SaveChanges();
            //           }

            //                msg = List.LastOrDefault().sOutDate.ToString();

            //            return Ok(msg);
            //        }
            //        else { return Ok("none"); }


            //    }
            //}
            ////else
            //return Ok("error");
        }


        // add or update location
        [HttpPost]
        [Route("Save")]
        public ResponseVM Save(string token)
        {
            // public ResponseVM Save(string token)
            //string Object string newObject
            string message = "";
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                string Object = "";
                usersLogs newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Object")
                    {
                        Object = c.Value.Replace("\\", string.Empty);
                        Object = Object.Trim('"');
                        newObject = JsonConvert.DeserializeObject<usersLogs>(Object, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
                if (newObject != null)
                {


                    usersLogs tmpObject = null;


                    try
                    {
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
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            var locationEntity = entity.Set<usersLogs>();
                            if (newObject.logId == 0 || newObject.logId == null)
                            {
                                // signIn

                                newObject.sInDate = DateTime.Now;


                                locationEntity.Add(newObject);
                                entity.SaveChanges();
                                message = newObject.logId.ToString();
                                //sign out old user

                                using (incposdbEntities entity2 = new incposdbEntities())
                                {
                                    List<usersLogs> ul = new List<usersLogs>();
                                    List<usersLogs> locationE = entity2.usersLogs.ToList();
                                    ul = locationE.Where(s => s.sOutDate == null &&
                                   ((DateTime.Now - (DateTime)s.sInDate).TotalHours >= 24)).ToList();
                                    if (ul != null)
                                    {
                                        foreach (usersLogs row in ul)
                                        {
                                            row.sOutDate = DateTime.Now;
                                            entity2.SaveChanges();
                                        }
                                    }
                                }

                            }



                            else
                            {//signOut
                                tmpObject = entity.usersLogs.Where(p => p.logId == newObject.logId).FirstOrDefault();



                                tmpObject.logId = newObject.logId;
                                //  tmpObject.sInDate=newObject.sInDate;
                                tmpObject.sOutDate = DateTime.Now;
                                //    tmpObject.posId=newObject.posId;
                                //  tmpObject.userId = newObject.userId;


                                entity.SaveChanges();

                                message = tmpObject.logId.ToString();
                            }
                            //  entity.SaveChanges();
                        }

                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                    }
                    catch
                    {
                        message = "0";
                        return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
                    }


                }

                return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };

            }

            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //string message = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid)
            //{
            //    Object = Object.Replace("\\", string.Empty);
            //    Object = Object.Trim('"');
            //    usersLogs newObject = JsonConvert.DeserializeObject<usersLogs>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            //    if (newObject.posId == 0 || newObject.posId == null)
            //    {
            //        Nullable<int> id = null;
            //        newObject.posId = id;
            //    }
            //    if (newObject.userId == 0 || newObject.userId == null)
            //    {
            //        Nullable<int> id = null;
            //        newObject.userId = id;
            //    }



            //    try
            //    {
            //        using (incposdbEntities entity = new incposdbEntities())
            //        {
            //            var locationEntity = entity.Set<usersLogs>();
            //            if (newObject.logId == 0 || newObject.logId == null)
            //            {
            //                // signIn

            //                newObject.sInDate = DateTime.Now;


            //                locationEntity.Add(newObject);
            //                entity.SaveChanges();
            //                message = newObject.logId.ToString();
            //                //sign out old user

            //                using (incposdbEntities entity2 = new incposdbEntities())
            //                {
            //                    List<usersLogs> ul = new List<usersLogs>();
            //                    List<usersLogs>  locationE = entity2.usersLogs.ToList();
            //                    ul = locationE.Where(s => s.sOutDate == null &&
            //                   ( (DateTime.Now-(DateTime)s.sInDate).TotalHours>=24)).ToList();
            //                    if (ul != null)
            //                    {
            //                        foreach(usersLogs row in ul)
            //                        {
            //                            row.sOutDate = DateTime.Now;
            //                            entity2.SaveChanges();
            //                        }
            //                    }
            //                }

            //                }



            //            else
            //            {//signOut
            //                var tmpObject = entity.usersLogs.Where(p => p.logId == newObject.logId).FirstOrDefault();



            //                tmpObject.logId = newObject.logId;
            //               //  tmpObject.sInDate=newObject.sInDate;
            //                 tmpObject.sOutDate= DateTime.Now;
            //             //    tmpObject.posId=newObject.posId;
            //              //  tmpObject.userId = newObject.userId;


            //                entity.SaveChanges();

            //                message = tmpObject.logId.ToString();
            //            }
            //          //  entity.SaveChanges();
            //        }
            //    }
            //    catch
            //    {
            //        message = "-1";
            //    }
            //}
            //return message;
        }

        [HttpPost]
        [Route("Delete")]
        public ResponseVM Delete(string token)
        {

            // public ResponseVM Delete(string token)int logId, int userId,bool final
            //int Id, int userId
            string message = "";
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int logId = 0;
                int userId = 0;
                bool final = false;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "logId")
                    {
                        logId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                    else if (c.Type == "final")
                    {
                        final = bool.Parse(c.Value);
                    }

                }

                try
                {
                    if (final)
                    {

                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            usersLogs objectDelete = entity.usersLogs.Find(logId);

                            entity.usersLogs.Remove(objectDelete);
                            message = entity.SaveChanges().ToString();

                          //  return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                        }

                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                    }
                    else
                    {
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken("-2") };

                    }

                }
                catch
                {
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                }
            }
            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //int message = 0;
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}

            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);
            //if (valid)
            //{
            //    if (final)
            //    {
            //        try
            //        {
            //            using (incposdbEntities entity = new incposdbEntities())
            //            {
            //                usersLogs objectDelete = entity.usersLogs.Find(logId);

            //                entity.usersLogs.Remove(objectDelete);
            //            message=    entity.SaveChanges();

            //                return message.ToString();
            //            }
            //        }
            //        catch
            //        { 
            //            return "-1";
            //        }
            //    }
            //    return "-2";

            //}
            //else
            //    return "-3";
        }



    }
}
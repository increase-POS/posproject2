using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Migrations;
using POS_Server.Models.VM;
using System.Security.Claims;
using Newtonsoft.Json.Converters;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/userSetValues")]
    public class userSetValuesController : ApiController
    {
        // GET api/<controller> get all userSetValues
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

                        var list = entity.userSetValues

                   .Select(c => new
                   {
                       c.id,
                       c.userId,
                       c.valId,
                       c.note,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,

                   })
                               .ToList();


                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(list) };

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

            //if (valid) // APIKey is valid
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var List = entity.userSetValues

            //       .Select(c => new  {
            //           c.id,
            //           c.userId,
            //           c.valId,
            //           c.note,
            //           c.createDate,
            //           c.updateDate,
            //           c.createUserId,
            //           c.updateUserId,

            //       })
            //       .ToList();



            //        if (List == null)
            //            return NotFound();
            //        else
            //            return Ok(List);
            //    }
            //}
            ////else
            //    return NotFound();
        }



        // GET api/<controller>  Get medal By ID 
        [HttpGet]
        [Route("GetByID")]
        public ResponseVM GetByID(string token)
        {
            // public ResponseVM GetPurinv(string token)int emailId

            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int Id = 0;


                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Id")
                    {
                        Id = int.Parse(c.Value);
                    }


                }

                // DateTime cmpdate = DateTime.Now.AddDays(newdays);
                try
                {


                    using (incposdbEntities entity = new incposdbEntities())
                    {

                        var item = entity.userSetValues
                       .Where(c => c.valId == Id)
                       .Select(c => new
                       {
                           c.id,
                           c.userId,
                           c.valId,
                           c.note,
                           c.createDate,
                           c.updateDate,
                           c.createUserId,
                           c.updateUserId,


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
            //int cId = 0;
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //if (headers.Contains("Id"))
            //{
            //    cId = Convert.ToInt32(headers.GetValues("Id").First());
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid)
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var list = entity.userSetValues
            //       .Where(c => c.valId == cId)
            //       .Select(c => new {
            //           c.id,
            //           c.userId,
            //           c.valId,
            //           c.note,
            //           c.createDate,
            //           c.updateDate,
            //           c.createUserId,
            //           c.updateUserId,


            //       })
            //       .FirstOrDefault();

            //        if (list == null)
            //            return NotFound();
            //        else
            //            return Ok(list);
            //    }
            //}
            //else
            //    return NotFound();
        }



        [HttpPost]
        [Route("Saveu")]
        public ResponseVM Save(string token)
        {

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
                userSetValues newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Object")
                    {
                        Object = c.Value.Replace("\\", string.Empty);
                        Object = Object.Trim('"');
                        newObject = JsonConvert.DeserializeObject<userSetValues>(Object, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
                if (newObject != null)
                {


                    userSetValues tmpObject = null;


                    try
                    {
                        if (newObject.updateUserId == 0 || newObject.updateUserId == null)
                        {
                            Nullable<int> id = null;
                            newObject.updateUserId = id;
                        }
                        if (newObject.createUserId == 0 || newObject.createUserId == null)
                        {
                            Nullable<int> id = null;
                            newObject.createUserId = id;
                        }
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            var locationEntity = entity.Set<userSetValues>();
                            if (newObject.id == 0)
                            {
                                newObject.createDate = DateTime.Now;
                                newObject.updateDate = DateTime.Now;
                                newObject.updateUserId = newObject.createUserId;


                                locationEntity.Add(newObject);
                                entity.SaveChanges();
                                message = newObject.id.ToString();
                            }
                            else
                            {
                              tmpObject = entity.userSetValues.Where(p => p.id == newObject.id).FirstOrDefault();

                                tmpObject.updateDate = DateTime.Now;
                                tmpObject.updateUserId = newObject.updateUserId;

                                tmpObject.valId = newObject.valId;
                                tmpObject.userId = newObject.userId;
                                tmpObject.note = newObject.note;

                                entity.SaveChanges();

                                message = tmpObject.id.ToString();
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
            //    // return Object.ToString();
            //    Object = Object.Replace("\\", string.Empty);
            //    Object = Object.Trim('"');
            //    userSetValues newObject = JsonConvert.DeserializeObject<userSetValues>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            //    if (newObject.updateUserId == 0 || newObject.updateUserId == null)
            //    {
            //        Nullable<int> id = null;
            //        newObject.updateUserId = id;
            //    }
            //    if (newObject.createUserId == 0 || newObject.createUserId == null)
            //    {
            //        Nullable<int> id = null;
            //        newObject.createUserId = id;
            //    }

            //    try
            //    {
            //        using (incposdbEntities entity = new incposdbEntities())
            //        {
            //            var locationEntity = entity.Set<userSetValues>();
            //            if (newObject.id == 0)
            //            {
            //                newObject.createDate = DateTime.Now;
            //                newObject.updateDate = DateTime.Now;
            //                newObject.updateUserId = newObject.createUserId;


            //                locationEntity.Add(newObject);
            //                entity.SaveChanges();
            //                message = newObject.id.ToString();
            //            }
            //            else
            //            {
            //                var tmpObject = entity.userSetValues.Where(p => p.id == newObject.id).FirstOrDefault();

            //                tmpObject.updateDate = DateTime.Now;
            //                tmpObject.updateUserId = newObject.updateUserId;

            //                tmpObject.valId = newObject.valId;
            //                tmpObject.userId = newObject.userId;
            //                tmpObject.note = newObject.note;

            //                entity.SaveChanges();

            //                message = tmpObject.id.ToString();
            //            }
            //            //  entity.SaveChanges();
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

            // public ResponseVM Delete(string token)int Id, int userId
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
                int Id = 0;
                int userId = 0;


                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Id")
                    {
                        Id = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }

                }

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        userSetValues sObj = entity.userSetValues.Find(Id);

                        entity.userSetValues.Remove(sObj);
                    message=    entity.SaveChanges().ToString();


                    }
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
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

            //    try
            //    {
            //        using (incposdbEntities entity = new incposdbEntities())
            //        {
            //            userSetValues sObj = entity.userSetValues.Find(Id);

            //            entity.userSetValues.Remove(sObj);
            //            entity.SaveChanges();

            //            return Ok(" Deleted Successfully");
            //        }
            //    }
            //    catch
            //    {
            //        return NotFound();
            //    }




            //}
            //else
            //    return NotFound();
        }
    }
}
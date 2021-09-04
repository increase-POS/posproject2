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
    [RoutePrefix("api/errorcontroller")]
    public class ErrorController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
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
                    var List = (from S in entity.error
                                select new ErrorModel()
                                {
                                    errorId = S.errorId,

                                    num = S.num,
                                    msg = S.msg,
                                   stackTrace = S.stackTrace,
                                    targetSite = S.targetSite,
                                    posId = S.posId,
                                    branchId = S.branchId,
                                    createDate = S.createDate,
                                    createUserId = S.createUserId,



                                }).ToList();




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
        public IHttpActionResult GetByID(int errorId)
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
                    var row = entity.error
                   .Where(u => u.errorId == errorId)
                   .Select(S => new
                   {
                       S.errorId,

                       S.num,
                       S.msg,
                       S.stackTrace,
                       S.targetSite,
                       S.posId,
                       S.branchId,
                       S.createDate,
                       S.createUserId,


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
                error newObject = JsonConvert.DeserializeObject<error>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            
                if (newObject.createUserId == 0 || newObject.createUserId == null)
                {
                    Nullable<int> id = null;
                    newObject.createUserId = id;
                }
                if (newObject.posId == 0 || newObject.posId == null)
                {
                    Nullable<int> posId = null;
                    newObject.posId = posId;
                }
                if (newObject.branchId == 0 || newObject.branchId == null)
                {
                    Nullable<int> branchId = null;
                    newObject.branchId = branchId;
                }
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var locationEntity = entity.Set<error>();
                        if (newObject.errorId == 0)
                        {
                            newObject.createDate = DateTime.Now;
             
                 

                            locationEntity.Add(newObject);
                            entity.SaveChanges();
                            message = newObject.errorId.ToString();
                        }
                        else
                        {
                            var tmpObject = entity.error.Where(p => p.errorId == newObject.errorId).FirstOrDefault();

                            // newObject.createDate = DateTime.Now;

                            tmpObject.num = newObject.num;
                            tmpObject.msg = newObject.msg;
                            tmpObject.stackTrace = newObject.stackTrace;
                            tmpObject.targetSite = newObject.targetSite;
                            tmpObject.posId = newObject.posId;
                            tmpObject.branchId = newObject.branchId;

                            tmpObject.createUserId = newObject.createUserId;


                            entity.SaveChanges();

                            message = tmpObject.errorId.ToString();
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
        public string Delete(int errorId)
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
               
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            error objectDelete = entity.error.Find(errorId);

                            entity.error.Remove(objectDelete);
                            message = entity.SaveChanges();

                            return message.ToString();
                        }
                    }
                    catch
                    {
                        return "-1";
                    }
              
                
            }
            else
                return "-3";
        }



    }
}
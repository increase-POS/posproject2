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
    [RoutePrefix("api/userSetValues")]
    public class categoryuserController : ApiController
    {
        // GET api/<controller> get all userSetValues
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
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
                    var List = entity.userSetValues
                  
                   .Select(c => new  {
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

                    /*
                     * 
   id 
   userId 
   valId 
   note 
   createDate 
   updateDate 
   createUserId 
   updateUserId 
    
    
                     * */

                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            //else
                return NotFound();
        }



        // GET api/<controller>  Get medal By ID 
        [HttpGet]
        [Route("GetByID")]
        public IHttpActionResult GetByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int cId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("Id"))
            {
                cId = Convert.ToInt32(headers.GetValues("Id").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var list = entity.userSetValues
                   .Where(c => c.valId == cId)
                   .Select(c => new {
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

                    if (list == null)
                        return NotFound();
                    else
                        return Ok(list);
                }
            }
            else
                return NotFound();
        }


        // add or update 
        [HttpPost]
        [Route("Save")]
        public String Save(string newObject)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string message ="";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            
            if (valid)
            {
                newObject = newObject.Replace("\\", string.Empty);
                newObject = newObject.Trim('"');
                userSetValues Object = JsonConvert.DeserializeObject<userSetValues>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    if (Object.userId == 0 || Object.userId == null)
                    {
                        Nullable<int> id = null;
                        Object.userId = id;
                    }
                    if (Object.valId == 0 || Object.valId == null)
                    {
                        Nullable<int> id = null;
                        Object.valId = id;
                    }
                    if (Object.updateUserId == 0 || Object.updateUserId == null)
                    {
                        Nullable<int> id = null;
                        Object.updateUserId = id;
                    }
                    if (Object.createUserId == 0 || Object.createUserId == null)
                    {
                        Nullable<int> id = null;
                        Object.createUserId = id;
                    }
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var sEntity = entity.Set<userSetValues>();
                        if (Object.valId == 0)
                        {
                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            sEntity.Add(Object);
                             message = Object.valId.ToString();
                            entity.SaveChanges();
                        }
                        else
                        {

                            var tmps = entity.userSetValues.Where(p => p.id == Object.id).FirstOrDefault();
                           
                            tmps.id=Object.id;
                       tmps.userId=Object.userId;
                       tmps.valId=Object.valId;
                       tmps.note=Object.note;
                       tmps.createDate=Object.createDate;
                            tmps.updateDate = DateTime.Now;// server current date
                            
                            tmps.updateUserId = Object.updateUserId;
                            entity.SaveChanges();
                            message = tmps.valId.ToString();
                        }
                       
                       
                    }
                    return message; ;
                }

                catch
                {
                    return "-1";
                }
            }
            else
                return "-1";
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int Id, int userId)
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
               
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            userSetValues sObj = entity.userSetValues.Find(Id);
                       
                            entity.userSetValues.Remove(sObj);
                            entity.SaveChanges();

                            return Ok(" Deleted Successfully");
                        }
                    }
                    catch
                    {
                        return NotFound();
                    }
                
                

               
            }
            else
                return NotFound();
        }
    }
}
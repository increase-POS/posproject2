﻿using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Migrations;
namespace POS_Server.Controllers
{
    [RoutePrefix("api/userSetValues")]
    public class userSetValuesController : ApiController
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



        [HttpPost]
        [Route("Saveu")]
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
               // return Object.ToString();
                Object = Object.Replace("\\", string.Empty);
                Object = Object.Trim('"');
                userSetValues newObject = JsonConvert.DeserializeObject<userSetValues>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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

                try
                {
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
                            var tmpObject = entity.userSetValues.Where(p => p.id == newObject.id).FirstOrDefault();

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
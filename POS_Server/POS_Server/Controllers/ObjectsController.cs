﻿using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Object")]
    public class ObjectsController : ApiController
    {
        // GET api/<controller> get all Objects
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
                    var List = entity.objects
                  
                   .Select(c => new ObjectsModel {
                       objectId = c.objectId,
                       name = c.name,
                       note = c.note,
                       createDate = c.createDate,
                       updateDate = c.updateDate,
                       createUserId = c.createUserId,
                       updateUserId = c.updateUserId,

                   })
                   .ToList();
                    if (List.Count > 0)
                    {
                        for (int i = 0; i < List.Count; i++)
                        {
                            canDelete = false;
                            if (List[i].isActive == 1)
                            {
                                int objectId = (int)List[i].objectId;
                                var operationsL = entity.groupObject.Where(x => x.objectId == objectId).Select(b => new { b.id }).FirstOrDefault();

                                if (operationsL is null)
                                    canDelete = true;
                            }
                            List[i].canDelete = canDelete;
                        }
                    }
                    /*
                     * 
   public int objectId { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }

                         objectId
                         name
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
                    var list = entity.objects
                   .Where(c => c.objectId == cId)
                   .Select(c => new {
                       c.objectId,
                       c.name,
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
                objects Object = JsonConvert.DeserializeObject<objects>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    
                   
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
                        var sEntity = entity.Set<objects>();
                        if (Object.objectId == 0)
                        {
                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            sEntity.Add(Object);
                            entity.SaveChanges();
                             message = Object.objectId.ToString();
                        }
                        else
                        {

                            var tmps = entity.objects.Where(p => p.objectId == Object.objectId).FirstOrDefault();
                           
                            tmps.objectId=Object.objectId;
                            tmps.name = Object.name;
                            tmps.note = Object.note;
                            tmps.note=Object.note;

                            tmps.createDate=Object.createDate;
                            tmps.updateDate = DateTime.Now;// server current date
                            
                            tmps.updateUserId = Object.updateUserId;
                            entity.SaveChanges();
                            message = tmps.objectId.ToString();
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
        public IHttpActionResult Delete(int objectId, int userId, bool final)
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

                if (final)
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {

                            objects Deleterow = entity.objects.Find(objectId);
                            entity.objects.Remove(Deleterow);
                            entity.SaveChanges();
                            return Ok("OK");
                        }
                    }
                    catch
                    {
                        return NotFound();
                    }
                }
                else
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {

                            objects Obj = entity.objects.Find(objectId);
                            Obj.isActive = 0;
                            Obj.updateUserId = userId;
                            Obj.updateDate = DateTime.Now;
                            entity.SaveChanges();
                            return Ok("Ok");
                        }
                    }
                    catch
                    {
                        return NotFound();
                    }
                }



            }
            else
                return NotFound();
        }
    }
}
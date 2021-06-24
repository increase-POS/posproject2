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
    [RoutePrefix("api/GroupObject")]
    public class GroupObjectController : ApiController
    {
        // GET api/<controller> get all Group
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
                    var List = entity.groupObject
                  
                   .Select(c => new GroupObjectModel {
                     id=  c.id,
                       groupId = c.groupId,
                       objectId = c.objectId,
                       notes = c.notes,
                       addOb = c.addOb,
                       updateOb = c.updateOb,
                       deleteOb = c.deleteOb,
                       showOb = c.showOb,
                       objectName = c.objects.name,
                       desc = c.objects.note,

                       createDate = c.createDate,
                       updateDate = c.updateDate,
                       createUserId = c.createUserId,
                       updateUserId = c.updateUserId,
                       canDelete=true,
                   })
                   .ToList();
                  
                    /*
                     * 
 
id
groupId
objectId
notes
addOb
updateOb
deleteOb
showOb
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
                    var list = entity.groupObject
                   .Where(c => c.id == cId)
                   .Select(c => new {
                       c.id,
                       c.groupId,
                       c.objectId,
                       c.notes,
                       c.addOb,
                       c.updateOb,
                       c.deleteOb,
                       c.showOb,

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
               groupObject Object = JsonConvert.DeserializeObject<groupObject>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {

                    if (Object.groupId == 0 || Object.groupId == null)
                    {
                        Nullable<int> id = null;
                        Object.groupId = id;
                    }

                    if (Object.objectId == 0 || Object.objectId == null)
                    {
                        Nullable<int> id = null;
                        Object.objectId = id;
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
                        var sEntity = entity.Set<groupObject>();
                        if (Object.id == 0)
                        {
                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                    


                            sEntity.Add(Object);
                             message = Object.groupId.ToString();
                            entity.SaveChanges();
                        }
                        else
                        {

                            var tmps = entity.groupObject.Where(p => p.id == Object.id).FirstOrDefault();
                            tmps.id = Object.id;
                            tmps.groupId = Object.groupId;
                            tmps.objectId = Object.objectId;
                            tmps.notes = Object.notes;
                            tmps.addOb = Object.addOb;
                            tmps.updateOb = Object.updateOb;
                            tmps.deleteOb = Object.deleteOb;
                            tmps.showOb = Object.showOb;
                            //tmps.isActive = Object.isActive;


                            tmps.createDate=Object.createDate;
                            tmps.updateDate = DateTime.Now;// server current date
                            tmps.updateUserId = Object.updateUserId;
                            entity.SaveChanges();
                            message = tmps.id.ToString();
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
        public IHttpActionResult Delete(int Id, int userId, bool final)
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

                            groupObject Deleterow = entity.groupObject.Find(Id);
                            entity.groupObject.Remove(Deleterow);
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

                            groupObject Obj = entity.groupObject.Find(Id);
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
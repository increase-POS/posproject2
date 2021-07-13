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
    [RoutePrefix("api/Group")]
    public class GroupController : ApiController
    {
        // GET api/<controller> get all Group
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
                    var List = entity.groups
                  
                   .Select(c => new GroupModel {
                       groupId=  c.groupId,
                       name= c.name,
                       notes = c.notes,
                       createDate = c.createDate,
                       updateDate = c.updateDate,
                       createUserId = c.createUserId,
                       updateUserId = c.updateUserId,
                       isActive = c.isActive,
                       
                   })
                   .ToList();
                    if (List.Count > 0)
                    {
                        for (int i = 0; i < List.Count; i++)
                        {
                            canDelete = false;
                            if (List[i].isActive == 1)
                            {
                                int groupId = (int)List[i].groupId;
                                var operationsL = entity.groupObject.Where(x => x.groupId == groupId).Select(b => new { b.id }).FirstOrDefault();

                                if (operationsL is null)
                                    canDelete = true;
                            }
                            List[i].canDelete = canDelete;
                        }
                    }
                    /*
                     * 


    
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
                    var list = entity.groups
                   .Where(c => c.groupId == cId)
                   .Select(c => new {
                       c.groupId,
                       c.name,
                       c.notes,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,

                     c.isActive,
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


        // GET api/<controller>  ارجاع قائمة المستخدمين التابعين للمجموعة
        [HttpGet]
        [Route("GetUsersByGroupId")]
        public IHttpActionResult GetUsersByGroupId(int groupId)
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
                    var list = entity.users
                   .Where(c => c.groupId == groupId)
                   .Select(c => new {
                       c.userId,
                       c.groupId,
                       c.name,
                       c.notes,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,

                       c.isActive,
                       c.username,
                       c.password,
                       c.lastname,
                       c.job,
                       c.workHours,
                       c.phone,
                       c.mobile,
                       c.email,
                       c.address,
                       c.isOnline,
                       c.role,
                       c.image,
                       c.balance,
                       c.balanceType,

                   })
                   .ToList();

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
               groups Object = JsonConvert.DeserializeObject<groups>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var sEntity = entity.Set<groups>();
                        if (Object.groupId == 0 || Object.groupId== null)
                        {
                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                    


                            entity.groups.Add(Object);
                             
                            entity.SaveChanges();
message = Object.groupId.ToString();
                        }
                        else
                        {

                            var tmps = entity.groups.Where(p => p.groupId == Object.groupId).FirstOrDefault();
                            tmps.groupId = Object.groupId;
                            tmps.name = Object.name;
                            tmps.notes = Object.notes;
                            tmps.isActive = Object.isActive;
                            tmps.createDate=Object.createDate;
                            tmps.updateDate = DateTime.Now;// server current date
                            tmps.updateUserId = Object.updateUserId;
                            entity.SaveChanges();
                            message = tmps.groupId.ToString();
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
        public IHttpActionResult Delete(int groupId, int userId, Boolean final)
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

                            groups Deleterow = entity.groups.Find(groupId);
                            entity.groups.Remove(Deleterow);
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

                            groups Obj = entity.groups.Find(groupId);
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

        [HttpPost]
        [Route("UpdateGroupIdInUsers")]
        public String UpdateGroupIdInUsers(int groupId, string newList, int userId)
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
                newList = newList.Replace("\\", string.Empty);
                newList = newList.Trim('"');

                List<int> newListObj = JsonConvert.DeserializeObject<List<int>>(newList, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {


                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        // reset old list
                        List<users> oldList = entity.users.Where(x => x.groupId == groupId).ToList();
                        if (oldList.Count > 0)
                        {
                            for (int i = 0; i < oldList.Count; i++)
                            {
                                oldList[i].groupId = null;
                                oldList[i].updateUserId = userId;
                                oldList[i].updateDate = DateTime.Now;


                            }
                            entity.SaveChanges();
                        }

                        //save new list
                        if (newListObj.Count > 0)
                        {
                            foreach (int rowId in newListObj)
                            {
                                users userRow = entity.users.Find(rowId);
                                userRow.updateUserId = userId;
                                userRow.updateDate = DateTime.Now;
                                userRow.groupId = groupId;
                                entity.SaveChanges();
                            }
                        }
                        else
                        {
                            message = "-1";
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

     
        /*
               public static List<int> sintlist = new List<int>();
               public static List<ObjectParent> objlist = new List<ObjectParent>();

               public List<ObjectParent> SonsofObject(List<ObjectParent> objlist1)
               {
                  // sintlist.Add(objectId);
                   List<ObjectParent> templist = null;

                   using (incposdbEntities entity = new incposdbEntities())
                   {
                       foreach (ObjectParent row in objlist1 )
                       {

                            templist = (from O in entity.objects
                                                         where O.parentObjectId == row.objectId
                                                         select new ObjectParent
                                                         {
                                                             objectId = O.objectId,
                                                             parentObjectId = O.parentObjectId,
                                                         }
                            ).ToList();

                       }
                       if (templist.Count > 0)
                       {
                        objlist.AddRange(SonsofObject(templist));
                       }
                       else
                       {
                           return objlist;
                       }



                       // SonsofObject()
                   }

                   return templist;
               }



               [HttpGet]
               [Route("GetSons")]
               public IHttpActionResult GetSons(int objectId)
               {
                   var re = Request;
                   var headers = re.Headers;
                   string token = "";
                   objlist = null;
                   List<ObjectParent> opl=null;
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
         // objlist;
                       ObjectParent firstelement = new ObjectParent();
                       firstelement.objectId = objectId;
                       objlist.Add(firstelement);
                      opl= SonsofObject(objlist);


                       return Ok(opl);
                       }
                       catch
                       {
                           return Ok(opl);
                       }


           }
                   else
                       return NotFound();


               }
               */

    }

    /*
  public class ObjectParent
  {
      public int objectId { get; set; }
      public Nullable<int> parentObjectId { get; set; }
  }
  */
}
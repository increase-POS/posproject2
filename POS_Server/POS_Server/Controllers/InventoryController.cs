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
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        // GET api/<controller> get all Inventory
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(string type)
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
                    var List = entity.Inventory
                  .Where(c => c.inventoryType == type)
                   .Select(c => new InventoryModel {
                       inventoryId=  c.inventoryId,                  
                       num=c.num,
                       notes =c.notes,
                       createDate = c.createDate,
                       updateDate = c.updateDate,
                       createUserId = c.createUserId,
                       updateUserId = c.updateUserId,
                       isActive = c.isActive,
                       inventoryType = c.inventoryType,
                       
                   })
                   .ToList();
                    if (List.Count > 0)
                    {
                        for (int i = 0; i < List.Count; i++)
                        {
                            canDelete = false;
                            if (List[i].isActive == 1)
                            {
                                int inventoryId = (int)List[i].inventoryId;
                                var operationsL = entity.inventoryItemLocation.Where(x => x.inventoryId == inventoryId).Select(b => new { b.id }).FirstOrDefault();

                                if (operationsL is null)
                                    canDelete = true;
                            }
                            List[i].canDelete = canDelete;
                        }
                    }

                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetLastNumOfInv")]
        public IHttpActionResult GetLastNumOfInv()
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
                List<string> numberList;
                int lastNum = 0;
                using (incposdbEntities entity = new incposdbEntities())
                {
                    numberList = entity.Inventory.Select(b => b.num).ToList();

                    for (int i = 0; i < numberList.Count; i++)
                    {
                        string code = numberList[i];
                        string s = code.Substring(code.LastIndexOf("-") + 1);
                        numberList[i] = s;
                    }
                    numberList.Sort();
                    lastNum = int.Parse(numberList[numberList.Count - 1]);
                }
                return Ok(lastNum);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetByCreator")]
        public IHttpActionResult GetByCreator(string inventoryType, int userId)
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
                    var List = entity.Inventory 
                  .Where(c => c.inventoryType.Contains(inventoryType) && c.createUserId == userId)
                   .Select(c => new InventoryModel
                   {
                       inventoryId = c.inventoryId,
                       num = c.num,
                       notes = c.notes,
                       createDate = c.createDate,
                       updateDate = c.updateDate,
                       createUserId = c.createUserId,
                       updateUserId = c.updateUserId,
                       isActive = c.isActive,
                       inventoryType = c.inventoryType,

                   })
                   .ToList();
                   
                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            return NotFound();
        }
         [HttpGet]
        [Route("getByBranch")]
        public IHttpActionResult getByBranch(string inventoryType, int branchId)
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
                    var List = entity.Inventory 
                  .Where(c => c.inventoryType.Contains(inventoryType) && c.branchId == branchId)
                   .Select(c => new InventoryModel
                   {
                       inventoryId = c.inventoryId,
                       num = c.num,
                       notes = c.notes,
                       createDate = c.createDate,
                       updateDate = c.updateDate,
                       createUserId = c.createUserId,
                       updateUserId = c.updateUserId,
                       isActive = c.isActive,
                       inventoryType = c.inventoryType,

                   })
                   .ToList();
                   
                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
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
                    var list = entity.Inventory
                   .Where(c => c.inventoryId == cId)
                   .Select(c => new {
                       c.inventoryId,
                       c.num,
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
               Inventory Object = JsonConvert.DeserializeObject<Inventory>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var sEntity = entity.Set<Inventory>();
                        if (Object.inventoryId == 0 || Object.inventoryId == null)
                        {
                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                    


                            entity.Inventory.Add(Object);
                             
                            entity.SaveChanges();
message = Object.inventoryId.ToString();
                        }
                        else
                        {

                            var tmps = entity.Inventory.Where(p => p.inventoryId == Object.inventoryId).FirstOrDefault();
                            tmps.inventoryId = Object.inventoryId;

                            tmps.num = Object.num;
                            tmps.notes = Object.notes;
                            tmps.isActive = Object.isActive;
                            tmps.createDate=Object.createDate;
                            tmps.updateDate = DateTime.Now;// server current date
                            tmps.updateUserId = Object.updateUserId;
                            entity.SaveChanges();
                            message = tmps.inventoryId.ToString();
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
        public IHttpActionResult Delete(int inventoryId, int userId, bool final)
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

                            Inventory Deleterow = entity.Inventory.Find(inventoryId);
                            entity.Inventory.Remove(Deleterow);
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

                            Inventory Obj = entity.Inventory.Find(inventoryId);
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
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
    [RoutePrefix("api/InventoryItemLocation")]
    public class InventoryItemLocationController : ApiController
    {
        // GET api/<controller> get all InventoryItemLocation
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
                    var List = entity.inventoryItemLocation
                  
                   .Select(c => new InventoryItemLocationModel()
                   {
                             id=  c.id,
                    
                        isDestroyed = c.isDestroyed,
                           amount = c.amount,
                         amountDestroyed = c.amountDestroyed,
                          realAmount = c.realAmount,
                          itemLocationId = c.itemLocationId,
                         inventoryId = c.inventoryId,
                         isActive = c.isActive,
                         notes = c.notes,
                       createDate = c.createDate,
                       updateDate = c.updateDate,
                       createUserId = c.createUserId,
                       updateUserId = c.updateUserId,
                       canDelete = true,

                })
                   .ToList();
                    /*
                    if (List.Count > 0)
                    {
                        for (int i = 0; i < List.Count; i++)
                        {
                            canDelete = false;
                            if (List[i].isActive == 1)
                            {
                                int inventoryId = (int)List[i].id;
                                var operationsL = entity.inventoryItemLocation.Where(x => x.id == inventoryId).Select(b => new { b.id }).FirstOrDefault();

                                if (operationsL is null)
                                    canDelete = true;
                            }
                            List[i].canDelete = canDelete;
                        }
                    }
                    */
                    /*
                     * 

   
id
isDestroyed
amount
amountDestroyed
realAmount
itemLocationId
inventoryId
isActive
notes

createDate
updateDate
createUserId
updateUserId

canDelete
    


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
                    var list = entity.inventoryItemLocation
                   .Where(c => c.id == cId)
                   .Select(c => new {
                       c.id,
                       c.isDestroyed,
                       c.amount,
                       c.amountDestroyed,
                       c.realAmount,
                       c.itemLocationId,
                       c.inventoryId,
                        c.isActive,
                       c.notes,
                     
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
               inventoryItemLocation Object = JsonConvert.DeserializeObject<inventoryItemLocation>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var sEntity = entity.Set<inventoryItemLocation>();
                        if (Object.id == 0 || Object.id == null)
                        {
                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                    


                            entity.inventoryItemLocation.Add(Object);
                             
                            entity.SaveChanges();
message = Object.id.ToString();
                        }
                        else
                        {

                            var tmps = entity.inventoryItemLocation.Where(p => p.id == Object.id).FirstOrDefault();
                            tmps.id = Object.id;

                            tmps.isDestroyed = Object.isDestroyed;
                       tmps.amount=Object.amount;
                       tmps.amountDestroyed=Object.amountDestroyed;
                       tmps.realAmount=Object.realAmount;
                       tmps.itemLocationId=Object.itemLocationId;
                       tmps.inventoryId=Object.inventoryId;
                         
                            tmps.notes = Object.notes;
                            tmps.isActive = Object.isActive;
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
        public IHttpActionResult Delete(int id, int userId, Boolean final)
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

                            inventoryItemLocation Deleterow = entity.inventoryItemLocation.Find(id);
                            entity.inventoryItemLocation.Remove(Deleterow);
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

                            inventoryItemLocation Obj = entity.inventoryItemLocation.Find(id);
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
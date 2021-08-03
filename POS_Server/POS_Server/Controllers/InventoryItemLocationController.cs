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
        public IHttpActionResult Get( int inventoryId)
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
                    var List = (from c in entity.inventoryItemLocation.Where(c => c.inventoryId == inventoryId)
                                join l in entity.itemsLocations on c.itemLocationId equals l.itemsLocId
                                join u in entity.itemsUnits on l.itemUnitId equals u.itemUnitId
                                join un in entity.units on u.unitId equals un.unitId
                                join lo in entity.locations on l.locationId equals lo.locationId
                                select new InventoryItemLocationModel()
                                {
                                    id = c.id,
                                    isDestroyed = c.isDestroyed,
                                    amount = c.amount,
                                    amountDestroyed = c.amountDestroyed,
                                    quantity = c.realAmount,
                                    itemLocationId = c.itemLocationId,
                                    inventoryId = c.inventoryId,
                                    isActive = c.isActive,
                                    notes = c.notes,
                                    createDate = c.createDate,
                                    updateDate = c.updateDate,
                                    createUserId = c.createUserId,
                                    updateUserId = c.updateUserId,
                                    canDelete = true,
                                    itemName = u.items.name,
                                    section = lo.sections.name,
                                    location = lo.x + "-" + lo.y + "-" + lo.z,
                                    unitName = un.name,

                                })
                       .ToList();
                    int sequence = 0;
                    for(int i = 0; i< List.Count; i++)
                    {
                        sequence++;
                        List[i].sequence = sequence;
                    }

                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            //else
                return NotFound();
        }
        [HttpGet]
        [Route("GetItemToDestroy")]
        public IHttpActionResult GetItemToDestroy( int branchId)
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
                    var List = (from c in entity.inventoryItemLocation.Where(c => c.amountDestroyed > 0 && c.isDestroyed == false && c.Inventory.branchId == branchId && c.Inventory.inventoryType =="n")
                                join l in entity.itemsLocations on c.itemLocationId equals l.itemsLocId
                                join u in entity.itemsUnits on l.itemUnitId equals u.itemUnitId
                                join un in entity.units on u.unitId equals un.unitId
                                join lo in entity.locations on l.locationId equals lo.locationId
                                select new InventoryItemLocationModel()
                                {
                                    id = c.id,
                                    isDestroyed = c.isDestroyed,
                                    amount = c.amount,
                                    amountDestroyed = c.amountDestroyed,
                                    quantity = c.realAmount,
                                    itemLocationId = c.itemLocationId,
                                    inventoryId = c.inventoryId,
                                    isActive = c.isActive,
                                    notes = c.notes,
                                    createDate = c.createDate,
                                    updateDate = c.updateDate,
                                    createUserId = c.createUserId,
                                    updateUserId = c.updateUserId,
                                    canDelete = true,
                                    itemId = u.items.itemId,
                                    itemName = u.items.name,
                                    unitId = un.unitId,
                                    itemUnitId = u.itemUnitId,
                                    unitName = un.name,
                                    section = lo.sections.name,
                                    location = lo.x  + lo.y + lo.z,
                                    itemType = u.items.type,
                                    inventoryDate = c.Inventory.createDate,
                                    inventoryNum = c.Inventory.num,
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
        public IHttpActionResult Save(string newObject,int inventoryId)
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
                newObject = newObject.Replace("\\", string.Empty);
                newObject = newObject.Trim('"');
              List<InventoryItemLocationModel> Object = JsonConvert.DeserializeObject<List<InventoryItemLocationModel>>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    List<inventoryItemLocation> items = entity.inventoryItemLocation.Where(x => x.inventoryId == inventoryId).ToList();
 
                    if (items == null || items.Count == 0)// add first time
                    {
                        foreach (InventoryItemLocationModel il in Object)
                        {
                            inventoryItemLocation tmp = new inventoryItemLocation();
                            if (il.createUserId == 0 || il.createUserId == null)
                            {
                                Nullable<int> id = null;
                                tmp.createUserId = id;
                            }
                            if (il.amountDestroyed == 0 || il.amountDestroyed == null)
                            {
                                Nullable<int> id = 0;
                                tmp.amountDestroyed = id;
                            }
                            tmp.inventoryId = inventoryId;
                            tmp.amount = il.amount;
                            tmp.amountDestroyed = il.amountDestroyed;
                            tmp.isDestroyed = il.isDestroyed;
                            tmp.realAmount = il.quantity;
                            tmp.cause = il.cause;
                            tmp.itemLocationId = il.itemLocationId;
                            tmp.createDate = DateTime.Now;
                            tmp.updateDate = DateTime.Now;
                            tmp.updateUserId = il.createUserId;
                            entity.inventoryItemLocation.Add(tmp);
                        }
                       
                    }
                    else // edit saved inventory details
                    {
                        foreach (InventoryItemLocationModel il in Object)
                        {
                            inventoryItemLocation invItem = entity.inventoryItemLocation.Find(il.id);

                            invItem.amount = il.amount;
                            invItem.isDestroyed = il.isDestroyed;
                            invItem.amountDestroyed = il.amountDestroyed;
                            invItem.cause = il.cause;
                            invItem.updateDate = DateTime.Now;
                            invItem.updateUserId = il.updateUserId;
                        }
                    }

                    entity.SaveChanges();
                    return Ok("true");
                }                      
            }
            return Ok("false");
        }
        [HttpPost]
        [Route("distroyItem")]
        public string distroyItem(string newObject)
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
                newObject = newObject.Replace("\\", string.Empty);
                newObject = newObject.Trim('"');
                inventoryItemLocation Object = JsonConvert.DeserializeObject<inventoryItemLocation>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
              
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var unitEntity = entity.Set<pos>();
                        
                        var tmpItem = entity.inventoryItemLocation.Where(p => p.id == Object.id).FirstOrDefault();
                        tmpItem.notes = Object.notes;
                        tmpItem.isDestroyed = true;
                        tmpItem.updateDate = DateTime.Now;
                        tmpItem.updateUserId = Object.updateUserId;
                        tmpItem.cause = Object.cause;
                        message = "Pos Is Updated Successfully";
                      
                        entity.SaveChanges();
                    }
                }
                catch
                {
                    message = "an error ocurred";
                }
            }
            return message;
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
using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/ItemsLocations")]
    public class ItemsLocationsController : ApiController
    {
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
                    var docImageList = entity.itemsLocations
                        .Select(b => new {
                            b.createDate,
                            b.createUserId,
                            b.endDate,
                            b.itemsLocId,
                            b.itemUnitId,
                            b.locationId,
                            b.note,
                            b.quantity,
                            b.startDate,
                            b.storeCost,
                            b.updateDate,
                            b.updateUserId,
                        })
                    .ToList();

                    if (docImageList == null)
                        return NotFound();
                    else
                        return Ok(docImageList);
                }
            }
            //else
            return NotFound();
        }
        [HttpGet]
        [Route("GetByItemUnitId")]
        public IHttpActionResult GetByItemUnitId(int itemUnitId, int locationId)
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
                    var docImageList = entity.itemsLocations
                        .Where(b => b.itemUnitId == itemUnitId && b.locationId == locationId)
                        .Select(b => new {
                            b.createDate,
                            b.createUserId,
                            b.endDate,
                            b.itemsLocId,
                            b.itemUnitId,
                            b.locationId,
                            b.note,
                            b.quantity,
                            b.startDate,
                            b.storeCost,
                            b.updateDate,
                            b.updateUserId,
                        })
                    .ToList();

                    if (docImageList == null)
                        return NotFound();
                    else
                        return Ok(docImageList);
                }
            }
            //else
            return NotFound();
        }


        [HttpPost]
        [Route("save")]
        public Boolean save(string itemLocationObject)
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

            itemLocationObject = itemLocationObject.Replace("\\", string.Empty);
            itemLocationObject = itemLocationObject.Trim('"');

            if (valid)
            {
                List<itemsLocations> itemLocList = JsonConvert.DeserializeObject<List<itemsLocations>>(itemLocationObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                itemsLocations item;
                using (incposdbEntities entity = new incposdbEntities())
                {
                    foreach (itemsLocations itemLoc in itemLocList)
                    {
                        if (itemLoc.updateUserId == 0 || itemLoc.updateUserId == null)
                        {
                            Nullable<int> id = null;
                            itemLoc.updateUserId = id;
                        }
                        if (itemLoc.createUserId == 0 || itemLoc.createUserId == null)
                        {
                            Nullable<int> id = null;
                            itemLoc.createUserId = id;
                        }
                        var itemEntity = entity.Set<itemsLocations>();
                        item = itemEntity.Find(itemLoc.itemUnitId, itemLoc.locationId);
                        if (item == null)
                        {
                            itemLoc.createDate = DateTime.Now;
                            itemLoc.updateDate = DateTime.Now;
                            itemLoc.updateUserId = itemLoc.createUserId;

                            item = itemEntity.Add(itemLoc);
                        }
                        else
                        {
                            item.quantity = itemLoc.quantity;
                            item.startDate = itemLoc.startDate;
                            item.endDate = itemLoc.endDate;
                            item.note = itemLoc.note;
                            item.storeCost = itemLoc.storeCost;
                            item.updateDate = DateTime.Now;
                            item.updateUserId = itemLoc.updateUserId;
                        }
                    }
                    try
                    {
                        entity.SaveChanges();
                        return true;
                    }
                    catch { }
                }
            }
            return false;
        }
        [HttpPost]
        [Route("decraseAmounts")]
        public Boolean decraseAmounts(string itemLocationObject, int branchId)
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

            itemLocationObject = itemLocationObject.Replace("\\", string.Empty);
            itemLocationObject = itemLocationObject.Trim('"');

            if (valid)
            {
                List<itemsTransfer> itemList = JsonConvert.DeserializeObject<List<itemsTransfer>>(itemLocationObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                using (incposdbEntities entity = new incposdbEntities())
                {
                    foreach (itemsTransfer item in itemList)
                    {
                        updateItemQuantity(item.itemUnitId.Value, branchId, (int)item.quantity);      
                    }
                }
            }
            return false;
        }
        [HttpGet]
        [Route("updateItemQuantity")]
        public IHttpActionResult updateItemQuantity(int itemUnitId, int branchId, int requiredAmount)
        {
            using (incposdbEntities entity = new incposdbEntities())
            {
                var itemInLocs = (from b in entity.branches
                                  where b.branchId == branchId
                                  join s in entity.sections on b.branchId equals s.branchId
                                  join l in entity.locations on s.sectionId equals l.sectionId
                                  join il in entity.itemsLocations on l.locationId equals il.locationId
                                  where il.itemUnitId == itemUnitId && il.quantity > 0
                                  select new
                                  {
                                      il.itemsLocId,
                                      il.quantity,
                                      il.itemUnitId,
                                      il.locationId,
                                      s.sectionId,
                                  }).ToList();
                for (int i = 0; i < itemInLocs.Count; i++)
                {
                    int availableAmount = (int)itemInLocs[i].quantity;
                    var itemL = entity.itemsLocations.Find(itemInLocs[i].itemsLocId);
                    itemL.updateDate = DateTime.Now;
                    if (availableAmount >= requiredAmount)
                    {
                        itemL.quantity = availableAmount - requiredAmount;
                        requiredAmount = 0;
                        entity.SaveChanges();
                    }
                    else if (availableAmount > 0)
                    {
                        itemL.quantity = 0;
                        requiredAmount = requiredAmount - availableAmount;
                        entity.SaveChanges();
                    }

                    if (requiredAmount == 0)
                        return Ok();
                }
                if (requiredAmount != 0)
                {
                    int newQuant = checkUpperUnit(itemUnitId, branchId, requiredAmount);
                    var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                    var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                    var item = (from  il in entity.itemsLocations 
                                where il.itemUnitId == itemUnitId
                                select new
                                {
                                    il.itemsLocId,
                                }).FirstOrDefault();
                    var itemloc = entity.itemsLocations.Find(item.itemsLocId);
                    itemloc.quantity = (int)newQuant;
                    entity.SaveChanges();

                }
            }
            return Ok();
        }

        private int checkUpperUnit(int itemUnitId, int branchId, int requiredAmount)
        {
            int remainQuantity = 0;
            int firstRequir = requiredAmount;
            decimal newQuant = 0;
            using (incposdbEntities entity = new incposdbEntities())
            {
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (upperUnit != null)
                {  
                    decimal unitValue = (decimal)upperUnit.unitValue;
                    int breakNum = (int)Math.Ceiling(requiredAmount / unitValue);
                    newQuant = (decimal)(breakNum * upperUnit.unitValue);
                    var itemInLocs1 = (from b in entity.branches
                                       where b.branchId == branchId
                                       join s in entity.sections on b.branchId equals s.branchId
                                       join l in entity.locations on s.sectionId equals l.sectionId
                                       join il in entity.itemsLocations on l.locationId equals il.locationId
                                       where il.itemUnitId == upperUnit.itemUnitId && il.quantity > 0
                                       select new
                                       {
                                           il.itemsLocId,
                                           il.quantity,
                                           il.itemUnitId,
                                           il.locationId,
                                           s.sectionId,
                                       }).ToList();

                    for (int i = 0; i < itemInLocs1.Count; i++)
                    {
                        
                        var itemL = entity.itemsLocations.Find(itemInLocs1[i].itemsLocId);
                        var smallUnitLocId = entity.itemsLocations.Where(x => x.itemUnitId == itemUnitId).
                            Select(x => x.itemsLocId).FirstOrDefault();
                        var smallUnit = entity.itemsLocations.Find(smallUnitLocId);
                        
                        if (breakNum <= itemInLocs1[i].quantity)
                        {
                            itemL.quantity = itemInLocs1[i].quantity - breakNum;
                            entity.SaveChanges();
                            remainQuantity = (int)newQuant - firstRequir;
                            requiredAmount = 0;
                            return (remainQuantity);
                        }
                        else 
                        {
                            itemL.quantity = 0;
                            breakNum = (int)(breakNum - itemInLocs1[i].quantity);
                            requiredAmount = requiredAmount -( (int)itemInLocs1[i].quantity * (int)upperUnit.unitValue);
                            entity.SaveChanges();

                        }
                    }
                    if (breakNum != 0)
                    {
                        remainQuantity = checkUpperUnit(upperUnit.itemUnitId, branchId, breakNum);
                        var item = (from b in entity.branches
                                           where b.branchId == branchId
                                           join s in entity.sections on b.branchId equals s.branchId
                                           join l in entity.locations on s.sectionId equals l.sectionId
                                           join il in entity.itemsLocations on l.locationId equals il.locationId
                                           where il.itemUnitId == upperUnit.itemUnitId
                                           select new
                                           {
                                               il.itemsLocId,
                                           }).FirstOrDefault();
                        var itemloc= entity.itemsLocations.Find(item.itemsLocId);
                        itemloc.quantity =(int) remainQuantity;
                        entity.SaveChanges();
                        remainQuantity = (int)newQuant - firstRequir;
                        return (int)remainQuantity;
                    }
                }
            }
           return 0;
        }
        [HttpGet]
        [Route("getAmountInBranch")]
        public int getAmountInBranch(int itemUnitId, int branchId)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int amount = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                amount += getItemUnitAmount(itemUnitId,branchId);
            }
            return amount;
        }
        private int getItemUnitAmount(int itemUnitId,int branchId)
        {
            int amount = 0;

            using (incposdbEntities entity = new incposdbEntities())
            {
                var itemInLocs = (from b in entity.branches
                                  where b.branchId == branchId
                                  join s in entity.sections on b.branchId equals s.branchId
                                  join l in entity.locations on s.sectionId equals l.sectionId
                                  join il in entity.itemsLocations on l.locationId equals il.locationId
                                  where il.itemUnitId == itemUnitId && il.quantity > 0
                                  select new
                                  {
                                      il.itemsLocId,
                                      il.quantity,
                                      il.itemUnitId,
                                      il.locationId,
                                      s.sectionId,
                                  }).ToList();
                for (int i = 0; i < itemInLocs.Count; i++)
                {
                    amount += (int) itemInLocs[i].quantity;
                }

                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (upperUnit != null)
                    amount += (int)upperUnit.unitValue * getItemUnitAmount(upperUnit.itemUnitId,branchId);
                return amount;
            }    
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
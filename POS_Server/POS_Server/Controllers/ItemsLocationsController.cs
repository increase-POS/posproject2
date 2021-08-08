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
        public IHttpActionResult Get(int branchId)
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
                    var docImageList = (from b in entity.itemsLocations where b.quantity > 0
                                        join u in entity.itemsUnits on b.itemUnitId equals u.itemUnitId
                                        join i in entity.items on u.itemId equals i.itemId
                                        join l in entity.locations on b.locationId equals l.locationId
                                       join s in entity.sections on l.sectionId equals s.sectionId where s.branchId == branchId && s.isFreeZone != 1

                                        select new ItemLocationModel
                                        {
                                            createDate = b.createDate,
                                            createUserId = b.createUserId,
                                            endDate = b.endDate,
                                            itemsLocId = b.itemsLocId,
                                            itemUnitId = b.itemUnitId,
                                            locationId = b.locationId,
                                            note = b.note,
                                            quantity = b.quantity,
                                            startDate = b.startDate,
                                       
                                            updateDate = b.updateDate,
                                            updateUserId = b.updateUserId,
                                            itemName = i.name,
                                            location = l.x+l.y+l.z,
                                            section = s.name,
                                            sectionId = s.sectionId,
                                            itemType = i.type,
                                            unitName = u.units.name,
                                        }).ToList().OrderBy(x => x.location).ToList();

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
        [Route("GetAll")]
        public IHttpActionResult GetAll(int branchId)
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
                    var docImageList = (from b in entity.itemsLocations where b.quantity > 0
                                        join u in entity.itemsUnits on b.itemUnitId equals u.itemUnitId
                                        join i in entity.items on u.itemId equals i.itemId
                                        join l in entity.locations on b.locationId equals l.locationId
                                       join s in entity.sections on l.sectionId equals s.sectionId where s.branchId == branchId

                                        select new ItemLocationModel
                                        {
                                            createDate = b.createDate,
                                            createUserId = b.createUserId,
                                            endDate = b.endDate,
                                            itemsLocId = b.itemsLocId,
                                            itemUnitId = b.itemUnitId,
                                            locationId = b.locationId,
                                            note = b.note,
                                            quantity = b.quantity,
                                            startDate = b.startDate,
                                       
                                            updateDate = b.updateDate,
                                            updateUserId = b.updateUserId,
                                            itemName = i.name,
                                            location = l.x+l.y+l.z,
                                            section = s.name,
                                            sectionId = s.sectionId,
                                            itemType = i.type,
                                            unitName = u.units.name,
                                        }).ToList().OrderBy(x => x.location).ToList();

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
        [Route("getAmountByItemLocId")]
        public IHttpActionResult getAmountByItemLocId(int itemLocId)
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
                    var itemLoc = entity.itemsLocations.Find(itemLocId);

                    if (itemLoc == null)
                        return NotFound();
                    else
                        return Ok(itemLoc.quantity);
                }
            }
            //else
            return NotFound();
        }
        [HttpGet]
        [Route("getWithSequence")]
        public IHttpActionResult getWithSequence(int branchId)
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
                    var itemLocList = (from b in entity.itemsLocations where b.quantity > 0
                                        join u in entity.itemsUnits on b.itemUnitId equals u.itemUnitId
                                        join un in entity.units on u.unitId equals un.unitId
                                        join i in entity.items on u.itemId equals i.itemId
                                        join l in entity.locations on b.locationId equals l.locationId
                                       join s in entity.sections on l.sectionId equals s.sectionId where s.branchId == branchId && s.isFreeZone != 1

                                        select new ItemLocationModel
                                        {
                                            createDate = b.createDate,
                                            createUserId = b.createUserId,
                                            endDate = b.endDate,
                                            itemsLocId = b.itemsLocId,
                                            itemUnitId = b.itemUnitId,
                                            locationId = b.locationId,
                                            note = b.note,
                                            quantity = b.quantity,
                                            startDate = b.startDate,
                                          
                                            updateDate = b.updateDate,
                                            updateUserId = b.updateUserId,
                                            itemName = i.name,
                                            location = l.x+l.y+l.z,
                                            section = s.name,
                                            unitName = un.name,
                                            sectionId = s.sectionId,
                                            itemType = i.type,
                                        }).ToList();
                    int sequence = 1;
                    foreach(ItemLocationModel i in itemLocList)
                    {
                        i.sequence = sequence;
                        sequence++;
                    }

                    if (itemLocList == null)
                        return NotFound();
                    else
                        return Ok(itemLocList);
                }
            }
            //else
            return NotFound();
        }
        [HttpGet]
        [Route("GetFreeZoneItems")]
        public IHttpActionResult GetFreeZoneItems(int branchId)
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
                    var docImageList = (from b in entity.itemsLocations where b.quantity > 0
                                        join u in entity.itemsUnits on b.itemUnitId equals u.itemUnitId
                                        join i in entity.items on u.itemId equals i.itemId
                                        join l in entity.locations on b.locationId equals l.locationId
                                        join s in entity.sections on l.sectionId equals s.sectionId
                                        where s.branchId == branchId && s.isFreeZone == 1

                                        select new ItemLocationModel
                                        {
                                          createDate =  b.createDate,
                                            createUserId = b.createUserId,
                                            endDate = b.endDate,
                                            itemsLocId = b.itemsLocId,
                                            itemUnitId = b.itemUnitId,
                                            locationId = b.locationId,
                                            note = b.note,
                                            quantity = b.quantity,
                                            startDate = b.startDate,
                                          
                                            updateDate = b.updateDate,
                                            updateUserId = b.updateUserId,
                                            itemName = i.name,
                                            sectionId = s.sectionId,
                                            isFreeZone = s.isFreeZone,
                                            itemType = i.type,
                                            location = l.x +l.y+l.z,
                                            section = s.name,
                                            unitName = u.units.name,
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
        [Route("receiptInvoice")]
        public IHttpActionResult receiptInvoice(string itemLocationObject, int branchId,int userId)
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
                    var freeZoneLocation =  (from s in entity.sections.Where(x => x.branchId == branchId && x.isFreeZone==1)
                                     join l in entity.locations on s.sectionId equals l.sectionId
                                     select l.locationId).SingleOrDefault();
                    foreach (itemsTransfer item in itemList)
                    {
                        increaseItemQuantity(item.itemUnitId.Value, freeZoneLocation, (int)item.quantity,userId);      
                    }
                }
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("receiptOrder")]
        public IHttpActionResult receiptOrder(string itemLocationObject, int toBranch, int userId)
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
                List<itemsLocations> itemList = JsonConvert.DeserializeObject<List<itemsLocations>>(itemLocationObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var freeZoneLocation = (from s in entity.sections.Where(x => x.branchId == toBranch && x.isFreeZone == 1)
                                            join l in entity.locations on s.sectionId equals l.sectionId
                                            select l.locationId).SingleOrDefault();
                    foreach (itemsLocations item in itemList)
                    {
                        itemsLocations itemL = new itemsLocations();

                        itemL = entity.itemsLocations.Find(item.itemsLocId);
                        itemL.quantity -= item.quantity;
                        itemL.updateDate = DateTime.Now;
                        itemL.updateUserId = userId;
                        entity.SaveChanges();
                       // decreaseItemQuantity(item.itemUnitId.Value,item.itemsLocId,(int)item.quantity,userId);
                        //decreaseItemQuantity(item.itemUnitId.Value, fromBranch, (int)item.quantity, userId);
                        increaseItemQuantity(item.itemUnitId.Value, freeZoneLocation, (int)item.quantity, userId);
                    }
                }
            }
            return Ok(1);
        }
        [HttpPost]
        [Route("transferAmountbetweenUnits")]
        public IHttpActionResult transferAmountbetweenUnits(int locationId, int itemLocId,int toItemUnitId,int fromQuantity, int toQuantity, int userId)
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
                    decreaseItemLocationQuantity(itemLocId, fromQuantity, userId);
                    increaseItemQuantity(toItemUnitId, locationId, toQuantity, userId); 
                }
            }
            return Ok(1);
        }
        private void  increaseItemQuantity(int itemUnitId,int locationId, int quantity, int userId)
        {
            using (incposdbEntities entity = new incposdbEntities())
            {
                var itemUnit = (from  il in entity.itemsLocations 
                                where il.itemUnitId == itemUnitId && il.locationId == locationId
                                select new { il.itemsLocId }
                                ).FirstOrDefault();
                itemsLocations itemL = new itemsLocations();
                if (itemUnit == null)//add item in new location
                { 
                    itemL.itemUnitId = itemUnitId;
                    itemL.locationId = locationId;
                    itemL.quantity = quantity;
                    itemL.createDate = DateTime.Now;
                    itemL.updateDate = DateTime.Now;
                    itemL.createUserId = userId;
                    itemL.updateUserId = userId;

                    entity.itemsLocations.Add(itemL);
                }
                else
                {
                    itemL = entity.itemsLocations.Find(itemUnit.itemsLocId);
                    itemL.quantity += quantity;
                    itemL.updateDate = DateTime.Now;
                    itemL.updateUserId = userId;
                }
                entity.SaveChanges();
            }
       }
        [HttpPost]
        [Route("trasnferItem")]
        public IHttpActionResult trasnferItem(int itemLocId, string itemLocation)
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
                itemLocation = itemLocation.Replace("\\", string.Empty);
                itemLocation = itemLocation.Trim('"');
                ItemLocationModel itemObject = JsonConvert.DeserializeObject<ItemLocationModel>(itemLocation, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var oldItemL = entity.itemsLocations.Find(itemLocId);
                    int userId = (int)itemObject.updateUserId;
                    long newQuantity =(long) oldItemL.quantity - (long) itemObject.quantity;
                    oldItemL.quantity = (long)newQuantity;
                    oldItemL.updateDate = DateTime.Now;
                   oldItemL.updateUserId = userId;

                    //if (oldItemL.quantity == 0)
                        //entity.itemsLocations.Remove(oldItemL);
                 
                   
                    var newtemLocation = (from il in entity.itemsLocations
                                          where il.itemUnitId == itemObject.itemUnitId && il.locationId == itemObject.locationId
                                          && il.startDate == itemObject.startDate && il.endDate == itemObject.endDate
                                          select new { il.itemsLocId }
                                   ).FirstOrDefault();
                  
                    itemsLocations newItemL;
                    if (newtemLocation == null)//add item in new location
                    {
                        newItemL = new itemsLocations();
                        newItemL.createDate = DateTime.Now;
                        newItemL.createUserId = (int)itemObject.createUserId;
                        if(itemObject.endDate != null)
                            newItemL.endDate = itemObject.endDate;
                        if (itemObject.startDate != null)
                            newItemL.startDate = itemObject.startDate;
                        newItemL.updateDate = DateTime.Now;
                        newItemL.updateUserId = (int)itemObject.createUserId;
                        newItemL.itemUnitId = (int)itemObject.itemUnitId;
                        newItemL.locationId = (int)itemObject.locationId;
                        newItemL.note = itemObject.note;
                        newItemL.quantity = (long) itemObject.quantity;
                        entity.itemsLocations.Add(newItemL);
                    }
                    else
                    {
                        newItemL = new itemsLocations();
                        newItemL = entity.itemsLocations.Find(newtemLocation.itemsLocId);
                        newQuantity = (long) newItemL.quantity + (long)itemObject.quantity;
                        newItemL.quantity = (long) newQuantity;
                        newItemL.updateDate = DateTime.Now;
                        newItemL.updateUserId = (int)itemObject.updateUserId;
                       
                    }
                    entity.SaveChanges();
                    return Ok();
                }
            }
            return NotFound();
           
       }

        [HttpGet]
        [Route("updateItemQuantity")]
        public IHttpActionResult updateItemQuantity(int itemUnitId, int branchId, int requiredAmount, int userId)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
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
                    //int newQuant = checkUpperUnit(itemUnitId, branchId, requiredAmount,userId);
                    dic = checkUpperUnit(itemUnitId, branchId, requiredAmount,userId);

                    var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                    var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                    var item = (from  il in entity.itemsLocations where il.itemUnitId == itemUnitId
                                join l in entity.locations on il.locationId equals l.locationId
                                join s in entity.sections on l.sectionId equals s.sectionId where s.branchId == branchId     
                                select new
                                {
                                    il.itemsLocId,
                                }).FirstOrDefault();

                    if (item != null)
                    {
                        var itemloc = entity.itemsLocations.Find(item.itemsLocId);
                        //itemloc.quantity = (int)newQuant;
                        itemloc.quantity =dic["remainQuantity"];
                        entity.SaveChanges();
                    }
                    else
                    {
                        var locations = entity.locations.Where(x => x.branchId == branchId && x.isActive == 1).Select(x => new { x.locationId }).OrderBy(x => x.locationId).ToList();
                        // if (locations.Count > 0)
                        // {
                        int locationId = dic["locationId"];
                        if (locationId == 0 && locations.Count > 1)
                            locationId = locations[0].locationId; // free zoon
                        itemsLocations itemL = new itemsLocations();
                        itemL.itemUnitId = itemUnitId;
                        itemL.locationId = locationId;
                        itemL.quantity = dic["remainQuantity"];
                        itemL.createDate = DateTime.Now;
                        itemL.updateDate = DateTime.Now;
                        itemL.createUserId = userId;
                        itemL.updateUserId = userId;

                        entity.itemsLocations.Add(itemL);
                        entity.SaveChanges();
                    }

                }
            }
            return Ok();
        }

        private Dictionary<string, int> checkUpperUnit(int itemUnitId, int branchId, int requiredAmount, int userId)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
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
                    var itemInLocs = (from b in entity.branches
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

                    for (int i = 0; i < itemInLocs.Count; i++)
                    {
                        
                        var itemL = entity.itemsLocations.Find(itemInLocs[i].itemsLocId);
                        var smallUnitLocId = entity.itemsLocations.Where(x => x.itemUnitId == itemUnitId).
                            Select(x => x.itemsLocId).FirstOrDefault();
                        //var smallUnit = entity.itemsLocations.Find(smallUnitLocId);
                        
                        if (breakNum <= itemInLocs[i].quantity)
                        {
                            itemL.quantity = itemInLocs[i].quantity - breakNum;
                            entity.SaveChanges();
                            remainQuantity = (int)newQuant - firstRequir;
                            requiredAmount = 0;
                           // return remainQuantity;
                            dic.Add("remainQuantity",remainQuantity);
                            dic.Add("locationId", (int)itemInLocs[i].locationId);
                            return dic;
                        }
                        else 
                        {
                            itemL.quantity = 0;
                            breakNum = (int)(breakNum - itemInLocs[i].quantity);
                            requiredAmount = requiredAmount -( (int)itemInLocs[i].quantity * (int)upperUnit.unitValue);
                            entity.SaveChanges();
                        }
                        if (breakNum == 0)
                            break;
                    }
                    if (breakNum != 0)
                    {
                        dic = new Dictionary<string, int>();
                       // remainQuantity = checkUpperUnit(upperUnit.itemUnitId, branchId, breakNum, userId);
                        dic =  checkUpperUnit(upperUnit.itemUnitId, branchId, breakNum, userId);
                        var item = (from  s in entity.sections where s.branchId == branchId
                                    join l in entity.locations on s.sectionId equals l.sectionId
                                           join il in entity.itemsLocations on l.locationId equals il.locationId
                                           where il.itemUnitId == upperUnit.itemUnitId
                                           select new
                                           {
                                               il.itemsLocId,
                                           }).FirstOrDefault();
                        if (item != null)
                        {
                            var itemloc = entity.itemsLocations.Find(item.itemsLocId);
                            //itemloc.quantity = (int)remainQuantity;
                            itemloc.quantity = dic["remainQuantity"];
                            entity.SaveChanges();
                        }
                        else
                        {
                            var locations = entity.locations.Where(x => x.branchId == branchId && x.isActive == 1).Select(x => new { x.locationId }).OrderBy(x => x.locationId).ToList();
                           // if (locations.Count > 0)
                           // {
                                int locationId = dic["locationId"];
                            if (locationId == 0 && locations.Count > 1)
                                locationId = locations[0].locationId; // free zoon
                            //if (locations.Count > 1)
                            //    locationId = locations[1].locationId;
                            //else
                            //    locationId = locations[0].locationId;
                            itemsLocations itemL = new itemsLocations();
                                itemL.itemUnitId = itemUnitId;
                                itemL.locationId = locationId;
                                itemL.quantity =  dic["remainQuantity"];
                                itemL.createDate = DateTime.Now;
                                itemL.updateDate = DateTime.Now;
                                itemL.createUserId = userId;
                                itemL.updateUserId = userId;

                                entity.itemsLocations.Add(itemL);
                                entity.SaveChanges();
                   
                        }
                        //remainQuantity = (int)newQuant - firstRequir;
                        //return (int)remainQuantity;

                        dic["remainQuantity"] = (int)newQuant - firstRequir;
                        return dic;
                    }
                }
            }
           return dic;
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

                if (upperUnit != null && itemUnitId == upperUnit.itemUnitId)
                    return amount;
                if (upperUnit != null)
                    amount += (int)upperUnit.unitValue * getItemUnitAmount(upperUnit.itemUnitId,branchId);
                
                return amount;
            }    
        }
        [HttpGet]
        [Route("getUnitAmount")]
        public int getUnitAmount(int itemUnitId, int branchId)
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
                    var amount = (from b in entity.branches
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
                                  }).ToList().Sum(x => x.quantity);
                    return (int)amount;
                }
            }
            return 0;
        }
        [HttpGet]
        [Route("getAmountInLocation")]
        public int getAmountInLocation(int itemUnitId, int locationId)
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
                    var amount = (from l in entity.locations where l.locationId == locationId
                                  join il in entity.itemsLocations on l.locationId equals il.locationId
                                  where il.itemUnitId == itemUnitId && il.quantity > 0
                                  select new
                                  {
                                      il.itemsLocId,
                                      il.quantity,
                                  }).ToList().Sum(x => x.quantity);
                    return (int)amount;
                }
            }
            return 0;
        }
        [HttpPost]
        [Route("returnInvoice")]
        public IHttpActionResult returnInvoice(string itemLocationObject, int branchId, int userId)
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
                    var freeZoneLocation = (from s in entity.sections.Where(x => x.branchId == branchId && x.isFreeZone == 1)
                                            join l in entity.locations on s.sectionId equals l.sectionId
                                            select l.locationId).SingleOrDefault();
                    foreach (itemsTransfer item in itemList)
                    {
                        decreaseItemQuantity(item.itemUnitId.Value, freeZoneLocation, (int)item.quantity, userId);
                    }
                }
            }
            return Ok(1);
        }
        [HttpPost]
        [Route("destroyItem")]
        public IHttpActionResult destroyItem(string itemLocationObject,int userId)
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
                List<itemsLocations> itemList = JsonConvert.DeserializeObject<List<itemsLocations>>(itemLocationObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    foreach (itemsLocations item in itemList)
                    {
                        itemsLocations itemL = new itemsLocations();

                        itemL = entity.itemsLocations.Find(item.itemsLocId);
                        itemL.quantity -= item.quantity;
                        itemL.updateDate = DateTime.Now;
                        itemL.updateUserId = userId;
                    }
                    entity.SaveChanges();
                }
            }
            return Ok(1);
        }
        private void decreaseItemQuantity(int itemUnitId, int locationId, int quantity, int userId)
        {
            using (incposdbEntities entity = new incposdbEntities())
            {
                var itemUnit = (from il in entity.itemsLocations
                                where il.itemUnitId == itemUnitId && il.locationId == locationId
                                select new { il.itemsLocId }
                                ).FirstOrDefault();
                itemsLocations itemL = new itemsLocations();

                itemL = entity.itemsLocations.Find(itemUnit.itemsLocId);
                itemL.quantity -= quantity;
                itemL.updateDate = DateTime.Now;
                itemL.updateUserId = userId;
                entity.SaveChanges();
            }
        }
        [HttpPost]
        [Route("decreaseItemLocationQuantity")]
        public void decreaseItemLocationQuantity( int itemLocId, int quantity, int userId)
        {
            using (incposdbEntities entity = new incposdbEntities())
            {
                itemsLocations itemL = new itemsLocations();

                itemL = entity.itemsLocations.Find(itemLocId);
                itemL.quantity -= quantity;
                itemL.updateDate = DateTime.Now;
                itemL.updateUserId = userId;
                entity.SaveChanges();
            }
        }
        [HttpPost]
        [Route("decraseAmounts")]
        public Boolean decraseAmounts(string itemLocationObject, int branchId, int userId)
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
                        updateItemQuantity(item.itemUnitId.Value, branchId, (int)item.quantity, userId);
                    }
                }
                return true;
            }
            else
            return false;
        }
        [HttpPost]
        [Route("unitsConversion")]
        public Boolean unitsConversion(int branchId, int fromItemUnit, int toItemUnit, int fromQuantity,int toQuantity, int userId, string smallUnit)
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
                itemsUnits itemUnit;
                itemUnit = JsonConvert.DeserializeObject<itemsUnits>(smallUnit, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                #region covert from unit (fromItemUnit) is bigger than the last (toItemUnit)
                if (itemUnit.itemUnitId != 0)// covert from unit (fromItemUnit) is bigger than the last (toItemUnit)
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var itemInLocs = (from b in entity.branches
                                          where b.branchId == branchId
                                          join s in entity.sections on b.branchId equals s.branchId
                                          join l in entity.locations on s.sectionId equals l.sectionId
                                          join il in entity.itemsLocations on l.locationId equals il.locationId
                                          where il.itemUnitId == fromItemUnit && il.quantity > 0
                                          select new
                                          {
                                              il.itemsLocId,
                                              il.quantity,
                                              il.itemUnitId,
                                              il.locationId,
                                              s.sectionId,
                                          }).ToList();
                        int unitValue = getUnitValue(fromItemUnit, toItemUnit);

                        for (int i = 0; i < itemInLocs.Count; i++)
                        {
                            int toQuant = 0;
                            int availableAmount = (int)itemInLocs[i].quantity;
                            var itemL = entity.itemsLocations.Find(itemInLocs[i].itemsLocId);
                            itemL.updateDate = DateTime.Now;
                            if (availableAmount >= fromQuantity)
                            {
                                itemL.quantity = availableAmount - fromQuantity;
                                toQuant = fromQuantity * unitValue;
                                fromQuantity = 0;
                                entity.SaveChanges();
                            }
                            else if (availableAmount > 0)
                            {
                                itemL.quantity = 0;
                                fromQuantity = fromQuantity - availableAmount;
                                toQuant = availableAmount * unitValue;
                                entity.SaveChanges();
                            }

                            increaseItemQuantity(toItemUnit, (int)itemInLocs[i].locationId, toQuant, userId);

                            if (fromQuantity == 0)
                                return true;
                        }
                    }
                    return true;
                }
                #endregion
                #region from small to large
                else
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var itemInLocs = (from b in entity.branches
                                          where b.branchId == branchId
                                          join s in entity.sections on b.branchId equals s.branchId
                                          join l in entity.locations on s.sectionId equals l.sectionId
                                          join il in entity.itemsLocations on l.locationId equals il.locationId
                                          where il.itemUnitId == fromItemUnit && il.quantity > 0
                                          select new
                                          {
                                              il.itemsLocId,
                                              il.quantity,
                                              il.itemUnitId,
                                              il.locationId,
                                              s.sectionId,
                                          }).ToList();

                        int unitValue = getUnitValue(toItemUnit, fromItemUnit);
                        int i = 0;
                        for (i=0 ; i < itemInLocs.Count; i++)
                        {
                            int availableAmount = (int)itemInLocs[i].quantity;
                            var itemL = entity.itemsLocations.Find(itemInLocs[i].itemsLocId);
                            itemL.updateDate = DateTime.Now;
                            if (availableAmount >= fromQuantity)
                            {
                                itemL.quantity = availableAmount - fromQuantity;
                                fromQuantity = 0;
                                entity.SaveChanges();
                            }
                            else if (availableAmount > 0)
                            {
                                itemL.quantity = 0;
                                fromQuantity = fromQuantity - availableAmount;
                                entity.SaveChanges();
                            }

                           

                            if (fromQuantity == 0)
                                return true;
                        }
                        increaseItemQuantity(toItemUnit, (int)itemInLocs[i].locationId, toQuantity, userId);
                        return true;
                    }
                    #endregion
                }        
            }
            return false;
        }
        private int getUnitValue(int itemunitId, int smallestItemUnitId)
        {
            int unitValue = 0;
            using (incposdbEntities entity = new incposdbEntities())
            {
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemunitId).Select(x => new { x.subUnitId , x.unitId,x.unitValue, x.itemId}  ).FirstOrDefault();
                int smallUnitId = entity.itemsUnits.Where(x => x.unitId == unit.subUnitId && x.itemId == unit.itemId).Select(x => x.itemUnitId).Single();
                unitValue = (int)unit.unitValue;
                if (itemunitId == smallestItemUnitId)
                    return unitValue;
                else
                {
                    unitValue = unitValue * getUnitValue(smallUnitId, smallestItemUnitId);
                }
            }
            return unitValue;
        }

        [HttpGet]
        [Route("getSpecificItemLocation")]
        public IHttpActionResult getSpecificItemLocation(string itemUnitsIds, int branchId)
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
                itemUnitsIds = JsonConvert.DeserializeObject<string>(itemUnitsIds, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                List<int> ids = new List<int>();
                List<string> strIds =itemUnitsIds.Split(',').ToList();
                for (int i = 0; i < strIds.Count; i++)
                {
                    if(!strIds[i].Equals(""))
                         ids.Add(int.Parse(strIds[i]));
                }
                   
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var locList = (from b in entity.itemsLocations
                                        where b.quantity > 0 && ids.Contains(b.itemUnitId??0)
                                        join u in entity.itemsUnits on b.itemUnitId equals u.itemUnitId
                                        join i in entity.items on u.itemId equals i.itemId
                                        join l in entity.locations on b.locationId equals l.locationId
                                        join s in entity.sections on l.sectionId equals s.sectionId
                                        where s.branchId == branchId 

                                        select new ItemLocationModel
                                        {
                                            createDate = b.createDate,
                                            createUserId = b.createUserId,
                                            endDate = b.endDate,
                                            itemsLocId = b.itemsLocId,
                                            itemUnitId = b.itemUnitId,
                                            locationId = b.locationId,
                                            note = b.note,
                                            quantity = b.quantity,
                                            startDate = b.startDate,
                                       
                                            updateDate = b.updateDate,
                                            updateUserId = b.updateUserId,
                                            itemName = i.name,
                                            sectionId = s.sectionId,
                                            isFreeZone = s.isFreeZone,
                                            itemType = i.type,
                                            location = l.x+"-"+l.y+"-"+l.z,
                                        }).OrderBy(a => a.endDate)
                                    .ToList();

                    if (locList == null)
                        return NotFound();
                    else
                        return Ok(locList);
                }
            }
            //else
            return NotFound();
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
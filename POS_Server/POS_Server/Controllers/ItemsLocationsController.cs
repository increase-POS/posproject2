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
        ItemsUnitsController itemsUnitsController = new ItemsUnitsController();
        GroupObjectController group = new GroupObjectController();
        NotificationController notificationController = new NotificationController();
        notificationUserController notUserController = new notificationUserController();

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
                    var docImageList = (from b in entity.itemsLocations where b.quantity > 0 && b.invoiceId == null
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
                                            invoiceId = b.invoiceId,
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
        [Route("GetLockedItems")]
        public IHttpActionResult GetLockedItems(int branchId)
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
                    var docImageList = (from b in entity.itemsLocations where b.quantity > 0 && b.invoiceId != null
                                        join u in entity.itemsUnits on b.itemUnitId equals u.itemUnitId
                                        join i in entity.items on u.itemId equals i.itemId
                                        join l in entity.locations on b.locationId equals l.locationId where l.sections.branchId == branchId 

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
                                            location = l.x + l.y + l.z,
                                            section = l.sections.name,
                                            sectionId = l.sectionId,
                                            itemType = i.type,
                                            unitName = u.units.name,
                                            invoiceId = b.invoiceId,
                                            invNumber = b.invoices.invNumber,
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
                    var docImageList = (from b in entity.itemsLocations where b.quantity > 0 && b.invoiceId == null
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
                                            invoiceId = b.invoiceId,
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
                    var itemLocList = (from b in entity.itemsLocations where b.quantity > 0 && b.invoiceId == null
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
                    var docImageList = (from b in entity.itemsLocations where b.quantity > 0 && b.invoiceId == null
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
                        .Where(b => b.itemUnitId == itemUnitId && b.locationId == locationId && b.invoiceId == null)
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
                            item.invoiceId = itemLoc.invoiceId;
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
        public IHttpActionResult receiptInvoice(string itemLocationObject, int branchId,int userId, string objectName, string notificationObj)
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
                        var itemId = entity.itemsUnits.Where(x => x.itemUnitId == item.itemUnitId).Select(x => x.itemId).Single();
                        var itemV = entity.items.Find(itemId);

                        if (item.invoiceId == 0 || item.invoiceId == null)
                        increaseItemQuantity(item.itemUnitId.Value, freeZoneLocation, (int)item.quantity,userId);
                        else//for order
                            increaseLockedItem(item.itemUnitId.Value, freeZoneLocation, (int)item.quantity,(int)item.invoiceId, userId);
                       bool isExcedded = isExceddMaxQuantity((int)item.itemUnitId,branchId ,userId );
                        if (isExcedded == true) //add notification
                        {
                            notificationController.addNotifications(objectName,notificationObj, branchId, itemV.name);                        
                        }
                    }
                }
            }
            return Ok(1);
        }

        public bool isExceddMaxQuantity(int itemUnitId, int branchId, int userId)
        {
            bool isExcedded = false;
            try
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var itemId = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => x.itemId).Single();
                    var item = entity.items.Find(itemId);
                    int maxUnitId = (int)item.maxUnitId;
                    int maxQuantity = (int)item.max;
                    var maxUnit = entity.itemsUnits.Where(x => x.itemId == itemId && x.unitId == maxUnitId).FirstOrDefault();
                    if (maxUnit == null)
                        isExcedded = false;
                    else
                    {
                        int itemUnitQuantity = getItemAmount(maxUnit.itemUnitId, branchId);
                        if (itemUnitQuantity >= maxQuantity)
                        {
                            isExcedded = true;
                        }
                        if (isExcedded == false)
                        {
                            int smallestItemUnit = entity.itemsUnits.Where(x => x.itemId == itemId && x.subUnitId == x.unitId).Select(x => x.itemUnitId).Single();
                            int smallUnitQuantity = getLevelItemUnitAmount(smallestItemUnit, maxUnit.itemUnitId, branchId);
                            int unitValue = itemsUnitsController.getLargeUnitConversionQuan(smallestItemUnit, maxUnit.itemUnitId);
                            int quantity = 0;
                            if (unitValue != 0)
                                quantity = smallUnitQuantity / unitValue;

                            quantity += itemUnitQuantity;
                            if (quantity >= maxQuantity)
                            {
                                isExcedded =  true;
                            }
                        }
                      
                    }
                }
            }
            catch
            {
            }
            return isExcedded;
        }
        
        [HttpPost]
        [Route("generatePackage")]
        public IHttpActionResult generatePackage(int packageParentId, int quantity, int locationId, int branchId, int userId)
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
                    var packageIems = (from s in entity.packages.Where(x => x.parentIUId == packageParentId)
                                       select new PackageModel
                                       {
                                           childIUId = s.childIUId,
                                           quantity = s.quantity
                                       }).ToList();
                    foreach (PackageModel item in packageIems)
                    {
                        int itemQuantity = item.quantity * quantity;
                        int itemUnitId = (int)item.childIUId;

                        var itemInLocs = (from b in entity.branches
                                          where b.branchId == branchId
                                          join s in entity.sections on b.branchId equals s.branchId
                                          join l in entity.locations on s.sectionId equals l.sectionId
                                          join il in entity.itemsLocations on l.locationId equals il.locationId
                                          where il.itemUnitId == itemUnitId && il.quantity > 0 && il.invoiceId == null
                                          select new
                                          {
                                              il.itemsLocId,
                                              il.quantity,
                                              il.itemUnitId,
                                              il.locationId,
                                              s.sectionId,
                                          }).ToList();
                        //int unitValue = getUnitValue(fromItemUnit, toItemUnit);

                        for (int i = 0; i < itemInLocs.Count; i++)
                        {
                            int availableAmount = (int)itemInLocs[i].quantity;
                            var itemL = entity.itemsLocations.Find(itemInLocs[i].itemsLocId);
                            itemL.updateDate = DateTime.Now;
                            if (availableAmount >= itemQuantity)
                            {
                                itemL.quantity = availableAmount - itemQuantity;
                                itemQuantity = 0;
                                entity.SaveChanges();
                            }
                            else if (availableAmount > 0)
                            {
                                itemL.quantity = 0;
                                itemQuantity = itemQuantity - availableAmount;
                                entity.SaveChanges();
                            }
                            if (itemQuantity == 0)
                                break;
                        }
                        increaseItemQuantity(packageParentId, locationId, quantity, userId);
                    }
                }
                return Ok(1);
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("receiptOrder")]
        public IHttpActionResult receiptOrder(string itemLocationObject,string orderList, int toBranch, int userId, string objectName, string notificationObj)
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

            orderList = orderList.Replace("\\", string.Empty);
            orderList = orderList.Trim('"');

            if (valid)
            {
                List<itemsLocations> itemList = JsonConvert.DeserializeObject<List<itemsLocations>>(itemLocationObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                List<itemsTransfer> items = JsonConvert.DeserializeObject<List<itemsTransfer>>(orderList, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                
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

                        var itemId = entity.itemsUnits.Where(x => x.itemUnitId == item.itemUnitId).Select(x => x.itemId).Single();
                       
                        var itemV = entity.items.Find(itemId);
                        int quantity = (int)item.quantity;
                        foreach(itemsTransfer it in items)
                        {
                            if (it.itemUnitId == item.itemUnitId && it.invoiceId != 0 && it.invoiceId != null)//for order
                            {
                                int itemQuantity = 0;
                                if (quantity >= item.quantity)
                                {
                                    itemQuantity = (int)item.quantity;
                                    quantity -= (int)item.quantity;
                                    item.quantity = quantity;
                                    it.quantity = 0;
                                }
                                else
                                {
                                    itemQuantity = quantity;
                                    quantity = 0;
                                    it.quantity -= quantity;
                                }
                                increaseLockedItem(item.itemUnitId.Value, freeZoneLocation, itemQuantity, (int)it.invoiceId, userId);
                            }
                        }
                        if(quantity != 0)
                        increaseItemQuantity(item.itemUnitId.Value, freeZoneLocation, quantity, userId);
       
                        bool isExcedded = isExceddMaxQuantity((int)item.itemUnitId, toBranch, userId);
                        if (isExcedded == true) //add notification
                        {
                            notificationController.addNotifications(objectName, notificationObj, toBranch, itemV.name);
                        }
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
                    decreaseItemLocationQuantity(itemLocId, fromQuantity, userId,"","");
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
                                where il.itemUnitId == itemUnitId && il.locationId == locationId && il.invoiceId == null
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
                                          && il.startDate == itemObject.startDate && il.endDate == itemObject.endDate && il.invoiceId == itemObject.invoiceId
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
                        newItemL.invoiceId = itemObject.invoiceId;
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
                                  where il.itemUnitId == itemUnitId && il.quantity > 0 && il.invoiceId == null
                                  select new
                                  {
                                      il.itemsLocId,
                                      il.quantity,
                                      il.itemUnitId,
                                      il.locationId,
                                      il.updateDate,
                                      s.sectionId,
                                  }).ToList().OrderBy(x=> x.updateDate).ToList();
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
                        return Ok(3);
                }
                if (requiredAmount != 0)
                {
                    //int newQuant = checkUpperUnit(itemUnitId, branchId, requiredAmount,userId);
                    dic = checkUpperUnit(itemUnitId, branchId, requiredAmount,userId);

                    var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                    var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                    
                    if (dic["remainQuantity"] > 0)
                    {
                        var item = (from il in entity.itemsLocations
                                    where il.itemUnitId == itemUnitId && il.invoiceId == null
                                    join l in entity.locations on il.locationId equals l.locationId
                                    join s in entity.sections on l.sectionId equals s.sectionId
                                    where s.branchId == branchId
                                    select new
                                    {
                                        il.itemsLocId,
                                    }).FirstOrDefault();
                        if (item != null)
                        {
                            var itemloc = entity.itemsLocations.Find(item.itemsLocId);
                            //itemloc.quantity = (int)newQuant;
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
                    if(dic["requiredQuantity"] >0)
                    {
                        checkLowerUnit(itemUnitId, branchId, dic["requiredQuantity"], userId);
                    }

                }
            }
            return Ok(2);
        }

        private Dictionary<string, int> checkUpperUnit(int itemUnitId, int branchId, int requiredAmount, int userId)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("remainQuantity", 0);
            dic.Add("locationId", 0);
            dic.Add("requiredQuantity", 0);
            dic.Add("isConsumed", 0);
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
                                      where il.itemUnitId == upperUnit.itemUnitId && il.quantity > 0 && il.invoiceId == null
                                      select new
                                      {
                                          il.itemsLocId,
                                          il.quantity,
                                          il.itemUnitId,
                                          il.locationId,
                                          il.updateDate,
                                          s.sectionId,
                                      }).ToList().OrderBy(x => x.updateDate).ToList();

                    for (int i = 0; i < itemInLocs.Count; i++)
                    {
                        dic["isConsumed"] = 1;
                        var itemL = entity.itemsLocations.Find(itemInLocs[i].itemsLocId);
                        var smallUnitLocId = entity.itemsLocations.Where(x => x.itemUnitId == itemUnitId && x.invoiceId == null).
                            Select(x => x.itemsLocId).FirstOrDefault();
                        //var smallUnit = entity.itemsLocations.Find(smallUnitLocId);

                        if (breakNum <= itemInLocs[i].quantity)
                        {
                            itemL.quantity = itemInLocs[i].quantity - breakNum;
                            entity.SaveChanges();
                            remainQuantity = (int)newQuant - firstRequir;
                            requiredAmount = 0;
                            // return remainQuantity;
                            dic["remainQuantity"]= remainQuantity;
                            dic["locationId"]=(int)itemInLocs[i].locationId;
                            dic["requiredQuantity"]= 0;

                            return dic;
                        }
                        else
                        {
                            itemL.quantity = 0;
                            breakNum = (int)(breakNum - itemInLocs[i].quantity);
                            requiredAmount = requiredAmount - ((int)itemInLocs[i].quantity * (int)upperUnit.unitValue);
                            entity.SaveChanges();
                        }
                        if (breakNum == 0)
                            break;
                    }
                    if (breakNum != 0)
                    {
                        dic = new Dictionary<string, int>();
                        // remainQuantity = checkUpperUnit(upperUnit.itemUnitId, branchId, breakNum, userId);
                        dic = checkUpperUnit(upperUnit.itemUnitId, branchId, breakNum, userId);
                        var item = (from s in entity.sections
                                    where s.branchId == branchId
                                    join l in entity.locations on s.sectionId equals l.sectionId
                                    join il in entity.itemsLocations on l.locationId equals il.locationId
                                    where il.itemUnitId == upperUnit.itemUnitId && il.invoiceId == null
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

                            int locationId = dic["locationId"];
                            if (locationId == 0 && locations.Count > 1)
                                locationId = locations[0].locationId; // free zoon

                            itemsLocations itemL = new itemsLocations();
                            //itemL.itemUnitId = itemUnitId;
                            itemL.itemUnitId = upperUnit.itemUnitId;
                            itemL.locationId = locationId;
                            itemL.quantity = dic["remainQuantity"];
                            itemL.createDate = DateTime.Now;
                            itemL.updateDate = DateTime.Now;
                            itemL.createUserId = userId;
                            itemL.updateUserId = userId;

                            entity.itemsLocations.Add(itemL);
                            entity.SaveChanges();

                        }

                        //dic["remainQuantity"] = (int)newQuant - firstRequir;
                        //dic["requiredQuantity"]= breakNum * (int)upperUnit.unitValue;
                        ///////////////////
                         if (dic["isConsumed"] == 0)
                        {
                            dic["requiredQuantity"] = requiredAmount;
                            dic["remainQuantity"] = 0;
                        }
                        else
                        {
                            dic["remainQuantity"] = (int)newQuant - firstRequir;
                            dic["requiredQuantity"] = breakNum * (int)upperUnit.unitValue;
                        }
                        return dic;
                    }
                }
                else
                {
                    dic["remainQuantity"]= 0;
                    dic["requiredQuantity"] = requiredAmount;
                    dic["locationId"]= 0;

                    return dic;
                }
            }
           return dic;
        }
        private Dictionary<string, int> checkLowerUnit(int itemUnitId, int branchId, int requiredAmount, int userId)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int remainQuantity = 0;
            int firstRequir = requiredAmount;
            decimal newQuant = 0;
            using (incposdbEntities entity = new incposdbEntities())
            {
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId, x.subUnitId, x.unitValue }).FirstOrDefault();
                var lowerUnit = entity.itemsUnits.Where(x => x.unitId == unit.subUnitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (lowerUnit != null)
                {  
                    decimal unitValue = (decimal)unit.unitValue;
                    int breakNum = (int)requiredAmount * (int)unitValue;
                    newQuant = (decimal)Math.Ceiling(breakNum /(decimal) lowerUnit.unitValue);
                    var itemInLocs = (from b in entity.branches
                                       where b.branchId == branchId
                                       join s in entity.sections on b.branchId equals s.branchId 
                                       join l in entity.locations on s.sectionId equals l.sectionId
                                       join il in entity.itemsLocations on l.locationId equals il.locationId
                                       where il.itemUnitId == lowerUnit.itemUnitId && il.quantity > 0 && il.invoiceId == null
                                       select new
                                       {
                                           il.itemsLocId,
                                           il.quantity,
                                           il.itemUnitId,
                                           il.locationId,
                                           il.updateDate,
                                           s.sectionId,
                                       }).ToList().OrderBy(x => x.updateDate).ToList();

                    for (int i = 0; i < itemInLocs.Count; i++)
                    {
                        
                        var itemL = entity.itemsLocations.Find(itemInLocs[i].itemsLocId);
                        var smallUnitLocId = entity.itemsLocations.Where(x => x.itemUnitId == itemUnitId && x.invoiceId == null).
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
                            requiredAmount = requiredAmount -( (int)itemInLocs[i].quantity / (int)unit.unitValue);
                            entity.SaveChanges();
                        }
                        if (breakNum == 0)
                            break;
                    }
                    if (itemUnitId == lowerUnit.itemUnitId)
                        return dic;
                    if (breakNum != 0)
                    {
                        dic = new Dictionary<string, int>();
                        dic = checkLowerUnit(lowerUnit.itemUnitId, branchId, breakNum, userId);
                        //var item = (from  s in entity.sections where s.branchId == branchId
                        //            join l in entity.locations on s.sectionId equals l.sectionId
                        //                   join il in entity.itemsLocations on l.locationId equals il.locationId
                        //                   where il.itemUnitId == lowerUnit.itemUnitId
                        //                   select new
                        //                   {
                        //                       il.itemsLocId,
                        //                   }).FirstOrDefault();
                        //if (item != null)
                        //{
                        //    var itemloc = entity.itemsLocations.Find(item.itemsLocId);
                        //    //itemloc.quantity = (int)remainQuantity;
                        //    itemloc.quantity = dic["remainQuantity"];
                        //    entity.SaveChanges();
                        //}
                        //else
                        //{
                        //    var locations = entity.locations.Where(x => x.branchId == branchId && x.isActive == 1).Select(x => new { x.locationId }).OrderBy(x => x.locationId).ToList();
                        //   // if (locations.Count > 0)
                        //   // {
                        //        int locationId = dic["locationId"];
                        //    if (locationId == 0 && locations.Count > 1)
                        //        locationId = locations[0].locationId; // free zoon
                        //    //if (locations.Count > 1)
                        //    //    locationId = locations[1].locationId;
                        //    //else
                        //    //    locationId = locations[0].locationId;
                        //    itemsLocations itemL = new itemsLocations();
                        //        itemL.itemUnitId = itemUnitId;
                        //        itemL.locationId = locationId;
                        //        itemL.quantity =  dic["remainQuantity"];
                        //        itemL.createDate = DateTime.Now;
                        //        itemL.updateDate = DateTime.Now;
                        //        itemL.createUserId = userId;
                        //        itemL.updateUserId = userId;

                        //        entity.itemsLocations.Add(itemL);
                        //        entity.SaveChanges();
                   
                        //}
                        //remainQuantity = (int)newQuant - firstRequir;
                        //return (int)remainQuantity;

                        dic["remainQuantity"] = (int)newQuant - firstRequir;
                        dic["requiredQuantity"] = breakNum;
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
                amount += getItemUnitAmount(itemUnitId, branchId); // from bigger unit
                amount += getSmallItemUnitAmount(itemUnitId, branchId);
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
                                  where il.itemUnitId == itemUnitId && il.quantity > 0 && il.invoiceId == null
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

                if ((upperUnit != null && itemUnitId == upperUnit.itemUnitId ) )
                    return amount;
                if (upperUnit != null)
                    amount += (int)upperUnit.unitValue * getItemUnitAmount(upperUnit.itemUnitId,branchId);
                
                return amount;
            }    
        }
        private int getSmallItemUnitAmount(int itemUnitId, int branchId)
        {
            int amount = 0;

            using (incposdbEntities entity = new incposdbEntities())
            {
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.subUnitId, x.unitId, x.unitValue, x.itemId }).FirstOrDefault();
                
                var smallUnit = entity.itemsUnits.Where(x => x.unitId == unit.subUnitId && x.itemId == unit.itemId).Select(x =>new { x.itemUnitId }).FirstOrDefault();
                if (smallUnit == null || smallUnit.itemUnitId == itemUnitId)
                {
                    return 0;
                }
                else
                {
                    var itemInLocs = (from b in entity.branches
                                      where b.branchId == branchId
                                      join s in entity.sections on b.branchId equals s.branchId
                                      join l in entity.locations on s.sectionId equals l.sectionId
                                      join il in entity.itemsLocations on l.locationId equals il.locationId
                                      where il.itemUnitId == smallUnit.itemUnitId && il.quantity > 0 && il.invoiceId == null
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
                        amount += (int)itemInLocs[i].quantity;
                    }
                    if (unit.unitValue != 0)
                        amount = amount / (int)unit.unitValue;
                    //if (itemUnitId == smallUnit.itemUnitId)
                    //    return amount;
                    else
                        amount += getSmallItemUnitAmount(smallUnit.itemUnitId, branchId) / (int)unit.unitValue;

                    return amount;
                }
            }
        }
        private int getItemAmount(int itemUnitId,int branchId)
        {
            int amount = 0;
        
            using (incposdbEntities entity = new incposdbEntities())
            {
                var itemInLocs = (from b in entity.branches
                                  where b.branchId == branchId
                                  join s in entity.sections on b.branchId equals s.branchId 
                                  join l in entity.locations on s.sectionId equals l.sectionId
                                  join il in entity.itemsLocations on l.locationId equals il.locationId
                                  where il.itemUnitId == itemUnitId && il.quantity > 0 && il.invoiceId == null
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

                if ((upperUnit != null && itemUnitId == upperUnit.itemUnitId ) || upperUnit == null)
                    return amount;
                if (upperUnit != null)
                    amount += (int)upperUnit.unitValue * getItemUnitAmount(upperUnit.itemUnitId,branchId);
                
                return amount;
            }    
        }
        private int getLevelItemUnitAmount(int itemUnitId,int topLevelUnit, int branchId)
        {
            int amount = 0;
        
            using (incposdbEntities entity = new incposdbEntities())
            {
                var itemInLocs = (from b in entity.branches
                                  where b.branchId == branchId
                                  join s in entity.sections on b.branchId equals s.branchId 
                                  join l in entity.locations on s.sectionId equals l.sectionId
                                  join il in entity.itemsLocations on l.locationId equals il.locationId
                                  where il.itemUnitId == itemUnitId && il.quantity > 0 && il.invoiceId == null
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

                if ((upperUnit != null && itemUnitId == upperUnit.itemUnitId ) || upperUnit == null)
                    return amount;
                if (upperUnit != null && upperUnit.itemUnitId != topLevelUnit)
                    amount += (int)upperUnit.unitValue * getLevelItemUnitAmount(upperUnit.itemUnitId, topLevelUnit,branchId);
                
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
                                  where il.itemUnitId == itemUnitId && il.quantity > 0 && il.invoiceId == null
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
                                  where il.itemUnitId == itemUnitId && il.quantity > 0 && il.invoiceId == null
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
                                where il.itemUnitId == itemUnitId && il.locationId == locationId && il.invoiceId == null
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
        public void decreaseItemLocationQuantity( int itemLocId, int quantity, int userId, string objectName, string notificationObj)
        {
            using (incposdbEntities entity = new incposdbEntities())
            {
                itemsLocations itemL = new itemsLocations();

                itemL = entity.itemsLocations.Find(itemLocId);
                itemL.quantity -= quantity;
                itemL.updateDate = DateTime.Now;
                itemL.updateUserId = userId;
                entity.SaveChanges();
                if(objectName != "")
                {
                    var branchId = (from l in entity.itemsLocations
                                    where l.itemsLocId == itemLocId
                                    select l.locations.branchId).Single();
                    bool isExcedded = isExceddMinQuantity((int)itemL.itemUnitId,(int) branchId, userId);
                    if (isExcedded == true) //add notification
                    {
                        var itemId = entity.itemsUnits.Where(x => x.itemUnitId == itemL.itemUnitId).Select(x => x.itemId).Single();
                        var itemV = entity.items.Find(itemId);
                        notificationController.addNotifications(objectName, notificationObj, (int)branchId, itemV.name);
                    }
                }
            }
        }

        public bool isExceddMinQuantity(int itemUnitId, int branchId, int userId)
        {
            bool isExcedded = false;
            try
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var itemId = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => x.itemId).Single();
                    var item = entity.items.Find(itemId);
                    int minUnitId = (int)item.minUnitId;
                    int minQuantity = (int)item.min;
                    var minUnit = entity.itemsUnits.Where(x => x.itemId == itemId && x.unitId == minUnitId).FirstOrDefault();
                    if (minUnit == null)
                        isExcedded = false;
                    else
                    {
                        int itemUnitQuantity = getItemAmount(minUnit.itemUnitId, branchId);
                        if (itemUnitQuantity <= minQuantity)
                        {
                            isExcedded = true;
                        }
                        if (isExcedded == false)
                        {
                            int smallestItemUnit = entity.itemsUnits.Where(x => x.itemId == itemId && x.subUnitId == x.unitId).Select(x => x.itemUnitId).Single();
                            int smallUnitQuantity = getLevelItemUnitAmount(smallestItemUnit, minUnit.itemUnitId, branchId);
                            int unitValue = itemsUnitsController.getLargeUnitConversionQuan(smallestItemUnit, minUnit.itemUnitId);
                            int quantity = 0;
                            if (unitValue != 0)
                                quantity = smallUnitQuantity / unitValue;

                            quantity += itemUnitQuantity;
                            if (quantity <= minQuantity)
                                isExcedded = true;
                        }
                    }
                }
            }
            catch
            {
            }
            return isExcedded;
        }

        [HttpPost]
        [Route("decraseAmounts")]
        public Boolean decraseAmounts(string itemLocationObject, int branchId, int userId, string objectName, string notificationObj)
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
                       
                        bool isExcedded = isExceddMinQuantity((int)item.itemUnitId, (int)branchId, userId);
                        if (isExcedded == true) //add notification
                        {
                            var itemId = entity.itemsUnits.Where(x => x.itemUnitId == item.itemUnitId).Select(x => x.itemId).Single();
                            var itemV = entity.items.Find(itemId);
                            notificationController.addNotifications(objectName, notificationObj, (int)branchId, itemV.name);
                        }
                    }
                }
                return true;
            }
            else
            return false;
        }
        [HttpPost]
        [Route("reserveItems")]
        public Boolean reserveItems(string itemLocationObject,int invoiceId, int branchId, int userId)
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
                        lockItem(item.itemUnitId.Value,invoiceId, branchId, (int)item.quantity, userId);
                    }
                }
                return true;
            }
            else
                return false;
        }
        [HttpGet]
        [Route("lockItem")]
        public IHttpActionResult lockItem(int itemUnitId,int invoiceId, int branchId, int requiredAmount, int userId)
        {
            int locationId = 0;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            using (incposdbEntities entity = new incposdbEntities())
            {
                var itemInLocs = (from  s in entity.sections where s.branchId == branchId
                                  join l in entity.locations on s.sectionId equals l.sectionId
                                  join il in entity.itemsLocations on l.locationId equals il.locationId
                                  where il.itemUnitId == itemUnitId && il.quantity > 0 && il.invoiceId == null
                                  select new
                                  {
                                      il.itemsLocId,
                                      il.quantity,
                                      il.itemUnitId,
                                      il.locationId,
                                      il.updateDate,
                                      s.sectionId,
                                  }).ToList().OrderBy(x => x.updateDate).ToList();
                for (int i = 0; i < itemInLocs.Count; i++)
                {
                    int availableAmount = (int)itemInLocs[i].quantity;
                    int lockedAmount = 0;                  
                    var itemL = entity.itemsLocations.Find(itemInLocs[i].itemsLocId);
                    itemL.updateDate = DateTime.Now;
                    if (availableAmount >= requiredAmount)
                    {
                        itemL.quantity = availableAmount - requiredAmount;
                        lockedAmount = requiredAmount;
                        requiredAmount = 0;                       
                        entity.SaveChanges();
                    }
                    else if (availableAmount > 0)
                    {
                        itemL.quantity = 0;
                        requiredAmount = requiredAmount - availableAmount;
                        lockedAmount = availableAmount;
                        entity.SaveChanges();
                    }
                    if(lockedAmount > 0)
                        increaseLockedItem((int)itemInLocs[i].itemUnitId, (int)itemInLocs[i].locationId, lockedAmount,invoiceId, userId);

                    if (requiredAmount == 0)
                        return Ok(3);
                }

                if (requiredAmount != 0)
                {
                    dic = lockUpperUnit(itemUnitId, branchId, requiredAmount, userId);

                    //var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                    //var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();
                    if (dic["remainQuantity"] > 0)
                    {
                        var item = (from il in entity.itemsLocations
                                    where il.itemUnitId == itemUnitId && il.invoiceId == null
                                    join l in entity.locations on il.locationId equals l.locationId
                                    join s in entity.sections on l.sectionId equals s.sectionId
                                    where s.branchId == branchId 
                                    select new
                                    {
                                        il.itemsLocId,
                                    }).FirstOrDefault();
                        if (item != null)
                        {
                            var itemloc = entity.itemsLocations.Find(item.itemsLocId);
                            itemloc.quantity += dic["remainQuantity"];
                            entity.SaveChanges();
                        }
                        else
                        {
                            var locations = entity.locations.Where(x => x.branchId == branchId && x.isActive == 1).Select(x => new { x.locationId }).OrderBy(x => x.locationId).ToList();
                            locationId = dic["locationId"];
                            if ((locationId == 0 && locationId == null) && locations.Count > 1)
                                locationId = locations[0].locationId; // free zoon
                            itemsLocations itemL = new itemsLocations();
                            itemL.itemUnitId = itemUnitId;
                            itemL.locationId = locationId;
                            itemL.quantity = dic["remainQuantity"];
                            itemL.createDate = DateTime.Now;
                            itemL.updateDate = DateTime.Now;
                            itemL.createUserId = userId;
                            itemL.updateUserId = userId;
                            itemL.invoiceId = null;

                            entity.itemsLocations.Add(itemL);
                            entity.SaveChanges();
                        }
                    }
                   // return Ok(dic["lockedQuantity"] +":"+ dic["remainQuantity"]+ ":"+ dic["requiredQuantity"]);
                    // reserve items
                    if (dic["lockedQuantity"] > 0)
                    {
                        int lockedQuantity = dic["lockedQuantity"] ;
                        if (lockedQuantity > requiredAmount)
                            lockedQuantity = requiredAmount;
                        var item = (from il in entity.itemsLocations
                                    where il.itemUnitId == itemUnitId && il.invoiceId == invoiceId
                                    select new
                                    {
                                        il.itemsLocId,
                                    }).FirstOrDefault();
                        if (item != null)
                        {
                            var itemloc = entity.itemsLocations.Find(item.itemsLocId);
                            locationId = (int)itemloc.locationId;
                        }
                        else
                        {
                            var locations = entity.locations.Where(x => x.branchId == branchId && x.isActive == 1).Select(x => new { x.locationId }).OrderBy(x => x.locationId).ToList();
                            locationId = dic["locationId"];
                            if (locationId == 0 && locations.Count > 1)
                                locationId = locations[0].locationId; // free zoon
                        }
                        
                        increaseLockedItem(itemUnitId, locationId, lockedQuantity, invoiceId, userId);
                    }
                    //return Ok(dic["requiredQuantity"]);
                    if (dic["requiredQuantity"] > 0)
                    {
                        dic = lockLowerUnit(itemUnitId, branchId, dic["requiredQuantity"], userId);
                        if (dic["lockedQuantity"] > 0)
                        {
                            var item = (from il in entity.itemsLocations
                                        where il.itemUnitId == itemUnitId && il.invoiceId == invoiceId
                                        join l in entity.locations on il.locationId equals l.locationId
                                        join s in entity.sections on l.sectionId equals s.sectionId
                                        where s.branchId == branchId
                                        select new
                                        {
                                            il.itemsLocId,
                                        }).FirstOrDefault();
                            if (item != null)
                            {
                                var itemloc = entity.itemsLocations.Find(item.itemsLocId);
                                locationId = (int)itemloc.locationId;
                            }
                            else
                            {
                                var locations = entity.locations.Where(x => x.branchId == branchId && x.isActive == 1).Select(x => new { x.locationId }).OrderBy(x => x.locationId).ToList();
                                locationId = dic["locationId"];
                                if (locationId == 0 && locations.Count > 1)
                                    locationId = locations[0].locationId; // free zoon
                            }
                            increaseLockedItem(itemUnitId, locationId, dic["lockedQuantity"], invoiceId, userId);
                        }
                    }

                }
            }
            return Ok(2);
        }
        private Dictionary<string, int> lockLowerUnit(int itemUnitId, int branchId, int requiredAmount, int userId)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int remainQuantity = 0;
            int firstRequir = requiredAmount;
            int lockedQuantity = 0;
            decimal newQuant = 0;
            dic.Add("lockedQuantity", 0);
            dic.Add("remainQuantity", 0);
            dic.Add("locationId", 0);

            using (incposdbEntities entity = new incposdbEntities())
            {
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId, x.subUnitId, x.unitValue }).FirstOrDefault();
                var lowerUnit = entity.itemsUnits.Where(x => x.unitId == unit.subUnitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (lowerUnit != null && lowerUnit.itemUnitId != itemUnitId)
                {
                    decimal unitValue = (decimal)unit.unitValue;
                    int breakNum = (int)requiredAmount * (int)unitValue;
                    newQuant = (decimal)Math.Ceiling(breakNum / (decimal)unit.unitValue);
                    var itemInLocs = (from b in entity.branches
                                      where b.branchId == branchId
                                      join s in entity.sections on b.branchId equals s.branchId
                                      join l in entity.locations on s.sectionId equals l.sectionId
                                      join il in entity.itemsLocations on l.locationId equals il.locationId
                                      where il.itemUnitId == lowerUnit.itemUnitId && il.quantity > 0 && il.invoiceId == null
                                      select new
                                      {
                                          il.itemsLocId,
                                          il.quantity,
                                          il.itemUnitId,
                                          il.locationId,
                                          il.updateDate,
                                          s.sectionId,
                                      }).ToList().OrderBy(x => x.updateDate).ToList();

                    for (int i = 0; i < itemInLocs.Count; i++)
                    {

                        var itemL = entity.itemsLocations.Find(itemInLocs[i].itemsLocId);

                        if (breakNum <= (int) itemInLocs[i].quantity)
                        {
                            itemL.quantity = itemInLocs[i].quantity - breakNum;
                            entity.SaveChanges();
                            remainQuantity = (int)newQuant - firstRequir;
                            requiredAmount = 0;
                            lockedQuantity = breakNum;
 
                            dic["remainQuantity"]= remainQuantity;
                            dic["locationId"] = (int)itemInLocs[i].locationId;
                            dic["lockedQuantity"] += lockedQuantity/(int) unit.unitValue ;
                            return dic;
                        }
                        else
                        {
                            itemL.quantity = 0;
                            breakNum = (int)(breakNum - itemInLocs[i].quantity);
                            requiredAmount = requiredAmount - ((int)itemInLocs[i].quantity / (int)unit.unitValue);
                            lockedQuantity += (int)itemInLocs[i].quantity / (int)unit.unitValue;
                            entity.SaveChanges();
                            dic["lockedQuantity"] += lockedQuantity;
                        }
                        if (breakNum == 0)
                            break;
                    }
                    if (itemUnitId == lowerUnit.itemUnitId)
                        return dic;
                    if (breakNum != 0)
                    {
                        dic = new Dictionary<string, int>();
                        dic = lockLowerUnit(lowerUnit.itemUnitId, branchId, breakNum, userId);
                        
                        dic["remainQuantity"] = (int)newQuant - firstRequir;
                        dic["requiredQuantity"] = breakNum;
                        dic["lockedQuantity"] += ((int)newQuant - firstRequir) / (int)unit.unitValue;
                        return dic;
                    }
                }
            }
            return dic;
        }
        private Dictionary<string, int> lockUpperUnit(int itemUnitId, int branchId, int requiredAmount, int userId)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("remainQuantity", 0);
            dic.Add("locationId", 0);
            dic.Add("requiredQuantity", 0);
            dic.Add("lockedQuantity", 0);
            dic.Add("isConsumed", 0);

            int remainQuantity = 0;
            int firstRequir = requiredAmount;
            decimal newQuant = 0;
            int lockedAmount = 0;
            int isConsumed = 0;

            using (incposdbEntities entity = new incposdbEntities())
            {
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId,x.unitValue }).FirstOrDefault();
                var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (upperUnit != null && upperUnit.itemUnitId != itemUnitId)
                {
                    decimal unitValue = (decimal)upperUnit.unitValue;
                    int breakNum = (int)Math.Ceiling(requiredAmount / unitValue);
                    newQuant = (decimal)(breakNum * upperUnit.unitValue);
                    var itemInLocs = (from b in entity.branches
                                      where b.branchId == branchId
                                      join s in entity.sections on b.branchId equals s.branchId
                                      join l in entity.locations on s.sectionId equals l.sectionId
                                      join il in entity.itemsLocations on l.locationId equals il.locationId
                                      where il.itemUnitId == upperUnit.itemUnitId && il.quantity > 0 && il.invoiceId == null
                                      select new
                                      {
                                          il.itemsLocId,
                                          il.quantity,
                                          il.itemUnitId,
                                          il.locationId,
                                          il.updateDate,
                                          s.sectionId,
                                      }).ToList().OrderBy(x => x.updateDate).ToList();

                    for (int i = 0; i < itemInLocs.Count; i++)
                    {
                        dic["isConsumed"] = 1;
                        isConsumed = 1;
                        var itemL = entity.itemsLocations.Find(itemInLocs[i].itemsLocId);

                        if (breakNum <= itemInLocs[i].quantity)
                        {
                            itemL.quantity = itemInLocs[i].quantity - breakNum;
                            entity.SaveChanges();
                            remainQuantity = (int)newQuant - firstRequir;
                            
                            // lockedAmount += breakNum * (int)upperUnit.unitValue;
                            //lockedAmount = breakNum ;
                            lockedAmount = firstRequir  ;
                            requiredAmount = 0;
                            // return remainQuantity;
                            dic["remainQuantity"] = remainQuantity;
                            dic["locationId"] = (int)itemInLocs[i].locationId;
                            dic["requiredQuantity"] = 0;
                            //dic["lockedQuantity"] += lockedAmount * (int)upperUnit.unitValue;
                            dic["lockedQuantity"] += lockedAmount;

                            return dic;
                        }
                        else
                        {
                            itemL.quantity = 0;
                            breakNum = (int)(breakNum - itemInLocs[i].quantity);
                            lockedAmount += (int)itemInLocs[i].quantity ;
                          // lockedAmount = (int)itemInLocs[i].quantity;
                            requiredAmount = requiredAmount - ((int)itemInLocs[i].quantity * (int)upperUnit.unitValue);
                            entity.SaveChanges();
                            dic["locationId"] = (int)itemInLocs[i].locationId;
                            dic["requiredQuantity"] = requiredAmount;
                           // dic["lockedQuantity"] += lockedAmount ;


                        }
                        if (breakNum == 0)
                            break;
                    }
                    if (breakNum != 0)
                    {
                        dic = new Dictionary<string, int>();
                        dic = lockUpperUnit(upperUnit.itemUnitId, branchId, breakNum, userId);


                        //if (dic["isConsumed"] == 1)
                        //{
                        int locationId = dic["locationId"];
                        if (locationId == 0)
                        {
                            var locations = entity.locations.Where(x => x.branchId == branchId && x.isActive == 1).Select(x => new { x.locationId }).OrderBy(x => x.locationId).ToList();

                            if (locationId == 0 && locations.Count >= 1)
                                locationId = locations[0].locationId; // free zoon
                        }
                        var item = (from s in entity.sections
                                        where s.branchId == branchId
                                        join l in entity.locations on s.sectionId equals l.sectionId
                                        join il in entity.itemsLocations on l.locationId equals il.locationId
                                        where il.itemUnitId == upperUnit.itemUnitId && il.invoiceId == null
                                        && il.locationId == locationId
                                        select new
                                        {
                                            il.itemsLocId,
                                        }).FirstOrDefault();
                            if (item != null)
                            {
                                var itemloc = entity.itemsLocations.Find(item.itemsLocId);
                                itemloc.quantity += dic["remainQuantity"];
                                entity.SaveChanges();
                            }
                            else
                            {
                               
                                itemsLocations itemL = new itemsLocations();
                                itemL.itemUnitId = upperUnit.itemUnitId;
                                itemL.locationId = locationId;
                                itemL.quantity = dic["remainQuantity"];
                                itemL.createDate = DateTime.Now;
                                itemL.updateDate = DateTime.Now;
                                itemL.createUserId = userId;
                                itemL.updateUserId = userId;

                                entity.itemsLocations.Add(itemL);
                                entity.SaveChanges();

                            }
                        //}
                        //dic["remainQuantity"] = (int)newQuant - firstRequir;
                        // dic["lockedQuantity"] += ((int)newQuant - firstRequir) * (int)upperUnit.unitValue;
                        dic["locationId"] = locationId;
                       if (dic["lockedQuantity"] > 0)
                        {
                            isConsumed = 1;
                            //int locked = dic["lockedQuantity"] ;
                            //if(locked >= breakNum)
                            //    dic["lockedQuantity"] = (int)upperUnit.unitValue * lockedAmount + breakNum ;
                            //else
                            //    dic["lockedQuantity"] = (int)upperUnit.unitValue * lockedAmount + locked;
                            lockedAmount += dic["lockedQuantity"] * (int)upperUnit.unitValue;
                            dic["lockedQuantity"] = lockedAmount;
                        }
                       //else
                       //     dic["lockedQuantity"] = dic["lockedQuantity"] * (int)upperUnit.unitValue;
                       // isConsumed = dic["isConsumed"];
                        if (isConsumed == 0)
                        {
                            dic["requiredQuantity"] = requiredAmount;
                            dic["remainQuantity"] = 0;
                        }
                        else
                        {
                            dic["remainQuantity"] = (int)newQuant - firstRequir;
                           // dic["requiredQuantity"] = breakNum * (int)upperUnit.unitValue;
                            dic["requiredQuantity"] = dic["requiredQuantity"] * (int)upperUnit.unitValue;
                        }                     
                        return dic;
                    }
                }
                else
                {
                    dic["remainQuantity"] = 0;
                    dic["requiredQuantity"] = requiredAmount;
                    dic["locationId"] = 0;
                    dic["lockedQuantity"] = 0;
                    return dic;
                }
            }
            return dic;
        }
        private void increaseLockedItem(int itemUnitId, int locationId, int quantity,int invoiceId, int userId)
        {
            using (incposdbEntities entity = new incposdbEntities())
            {
                var itemUnit = (from il in entity.itemsLocations
                                where il.itemUnitId == itemUnitId && il.locationId == locationId && il.invoiceId == invoiceId
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
                    itemL.invoiceId = invoiceId;

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
                                          where il.itemUnitId == fromItemUnit && il.quantity > 0 && il.invoiceId == null
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
                                          where il.itemUnitId == fromItemUnit && il.quantity > 0 && il.invoiceId == null
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
                                        where b.quantity > 0 && b.invoiceId == null && ids.Contains(b.itemUnitId??0)
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
        [HttpGet]
        [Route("getShortageItems")]
        public IHttpActionResult getShortageItems(int branchId)
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
                InvoicesController c = new InvoicesController();
                var orders = c.getUnhandeledOrdersList("or",0,branchId);

                using (incposdbEntities entity = new incposdbEntities())
                {
                    List<ItemTransferModel> requiredTransfers = new List<ItemTransferModel>();
                    foreach (InvoiceModel invoice in orders)
                    {
                        var itemsTransfer = entity.itemsTransfer.Where(x => x.invoiceId == invoice.invoiceId).ToList();
                        foreach(itemsTransfer tr in itemsTransfer)
                        {
                            var lockedQuantity = entity.itemsLocations
                                .Where(x => x.invoiceId == invoice.invoiceId && x.itemUnitId == tr.itemUnitId)
                                .Select(x => x.quantity).Sum();
                            var availableAmount = getAmountInBranch((int)tr.itemUnitId,branchId);
                            var item = (from i in entity.items
                                        join u in entity.itemsUnits on i.itemId equals u.itemId
                                        where u.itemUnitId == tr.itemUnitId
                                        select new ItemModel()
                                        {
                                            itemId = i.itemId,
                                            name = i.name,
                                            unitName = u.units.name,
                                        }).FirstOrDefault();
                            if (lockedQuantity == null)
                                lockedQuantity = 0;
                            if((lockedQuantity + availableAmount) < tr.quantity) // there is a shortage in order amount
                            {
                                long requiredQuantity = (long)tr.quantity - ((long)lockedQuantity + (long) availableAmount);
                                ItemTransferModel transfer = new ItemTransferModel()
                                {
                                    invNumber = invoice.invNumber,
                                    invoiceId = invoice.invoiceId,
                                    price = 0,
                                    quantity = requiredQuantity,
                                    itemUnitId = tr.itemUnitId,
                                    itemId = item.itemId,
                                    itemName = item.name,
                                    unitName = item.unitName,
                                };
                                requiredTransfers.Add(transfer);
                            }
                            
                        }
                    }
                    return Ok(requiredTransfers);
                }
            }
            return NotFound();
        }
        [HttpPost]
        [Route("unlockItem")]
        public IHttpActionResult unlockItem(string itemLocation)
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
               itemsLocations il = JsonConvert.DeserializeObject<itemsLocations>(itemLocation, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var itemLoc = (from b in entity.itemsLocations
                                        where  b.invoiceId == null && b.itemUnitId == il.itemUnitId && b.locationId == il.locationId 
                                        && b.startDate == il.startDate && b.endDate == il.endDate
                                        select new ItemLocationModel
                                        {
                                            itemsLocId = b.itemsLocId,
                                        }).FirstOrDefault();
                    var orderItem = entity.itemsLocations.Find(il.itemsLocId);
                    if (orderItem.quantity == il.quantity)
                        entity.itemsLocations.Remove(orderItem);
                    else
                        orderItem.quantity -= il.quantity;

                    if (itemLoc == null)
                    {
                        var loc = new itemsLocations()
                        {
                            locationId = il.locationId,
                            quantity = il.quantity,
                            createDate = DateTime.Now,
                            updateDate = DateTime.Now,
                            createUserId = il.createUserId,
                            updateUserId = il.createUserId,
                            startDate = il.startDate,
                            endDate = il.endDate,
                            itemUnitId = il.itemUnitId,
                            note = il.note,
                        };
                        entity.itemsLocations.Add(loc);
                    }
                    else
                    {
                        var loc = entity.itemsLocations.Find(itemLoc.itemsLocId);
                        loc.quantity += il.quantity;
                        loc.updateDate = DateTime.Now;
                        loc.updateUserId = il.updateUserId;
                       
                    }
                    entity.SaveChanges();
                }
                return Ok();
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
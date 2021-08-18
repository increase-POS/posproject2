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
    [RoutePrefix("api/ItemsUnits")]
    public class ItemsUnitsController : ApiController
    {
        List<int> itemUnitsIds = new List<int>();
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int itemId)
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
                    var itemUnitsList = (from IU in entity.itemsUnits
                                         where (IU.itemId == itemId && IU.isActive == 1)
                                         join u in entity.units on IU.unitId equals u.unitId into lj
                                         from v in lj.DefaultIfEmpty()
                                         join u1 in entity.units on IU.subUnitId equals u1.unitId into tj
                                         from v1 in tj.DefaultIfEmpty()
                                         select new ItemUnitModel()
                                         {
                                             itemUnitId = IU.itemUnitId,
                                             unitId = IU.unitId,
                                             mainUnit = v.name,
                                             createDate = IU.createDate,
                                             createUserId = IU.createUserId,
                                             defaultPurchase = IU.defaultPurchase,
                                             defaultSale = IU.defaultSale,
                                             price = IU.price,
                                             subUnitId = IU.subUnitId,
                                             smallUnit = v1.name,
                                             unitValue = IU.unitValue,
                                             barcode = IU.barcode,
                                             updateDate = IU.updateDate,
                                             updateUserId = IU.updateUserId,
                                           storageCostId =IU.storageCostId,

    })
                                         .ToList();

                    if (itemUnitsList == null)
                        return NotFound();
                    else
                        return Ok(itemUnitsList);
                }
            }
            //else
            return NotFound();
        }
        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById(int itemUnitId)
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
                    var itemUnitsList = (from IU in entity.itemsUnits
                                         where (IU.itemUnitId == itemUnitId )
                                         join u in entity.units on IU.unitId equals u.unitId into lj
                                         from v in lj.DefaultIfEmpty()
                                         join u1 in entity.units on IU.subUnitId equals u1.unitId into tj
                                         from v1 in tj.DefaultIfEmpty()
                                         select new ItemUnitModel()
                                         {
                                             itemUnitId = IU.itemUnitId,
                                             unitId = IU.unitId,
                                             itemId = IU.itemId,
                                             createDate = IU.createDate,
                                             createUserId = IU.createUserId,
                                             defaultPurchase = IU.defaultPurchase,
                                             defaultSale = IU.defaultSale,
                                             price = IU.price,
                                             subUnitId = IU.subUnitId,

                                             unitValue = IU.unitValue,
                                             barcode = IU.barcode,
                                             updateDate = IU.updateDate,
                                             updateUserId = IU.updateUserId,
                                           storageCostId =IU.storageCostId,
                                           isActive = IU.isActive,
    })
                                         .FirstOrDefault();

                    if (itemUnitsList == null)
                        return NotFound();
                    else
                        return Ok(itemUnitsList);
                }
            }
            //else
            return NotFound();
        }
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll(int itemId)
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
            Boolean canDelete = false;
            if (valid) // APIKey is valid
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var itemUnitsList = (from IU in entity.itemsUnits
                                         where (IU.itemId == itemId )
                                         join u in entity.units on IU.unitId equals u.unitId into lj
                                         from v in lj.DefaultIfEmpty()
                                         join u1 in entity.units on IU.subUnitId equals u1.unitId into tj
                                         from v1 in tj.DefaultIfEmpty()
                                         select new ItemUnitModel()
                                         {
                                             itemUnitId = IU.itemUnitId,
                                             unitId = IU.unitId,
                                             mainUnit = v.name,
                                             createDate = IU.createDate,
                                             createUserId = IU.createUserId,
                                             defaultPurchase = IU.defaultPurchase,
                                             defaultSale = IU.defaultSale,
                                             price = IU.price,
                                             subUnitId = IU.subUnitId,
                                             smallUnit = v1.name,
                                             unitValue = IU.unitValue,
                                             barcode = IU.barcode,
                                             updateDate = IU.updateDate,
                                             updateUserId = IU.updateUserId,
                                           storageCostId =IU.storageCostId,
                                           isActive = IU.isActive,
    })
                                         .ToList();
                    foreach(ItemUnitModel um in itemUnitsList)
                    {
                        canDelete = false;
                        if (um.isActive == 1)
                        {
                            var purItem = entity.itemsTransfer.Where(x => x.itemUnitId == um.itemUnitId).Select(b => new { b.itemsTransId, b.itemUnitId }).FirstOrDefault();
                            var packages = entity.packages.Where(x => x.childIUId == um.itemUnitId || x.packageId == um.itemUnitId).Select(x => new { x.packageId, x.parentIUId }).FirstOrDefault();
                            if (purItem == null && packages == null)
                                canDelete = true;
                        }
                        um.canDelete = canDelete;
                    }
                    if (itemUnitsList == null)
                        return NotFound();
                    else
                        return Ok(itemUnitsList);
                }
            }
            //else
            return NotFound();
        }
        // add or update item unit
        [HttpPost]
        [Route("Save")]
        public IHttpActionResult Save(string itemsUnitsObject)
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
                itemsUnitsObject = itemsUnitsObject.Replace("\\", string.Empty);
                itemsUnitsObject = itemsUnitsObject.Trim('"');
                itemsUnits newObject = JsonConvert.DeserializeObject<itemsUnits>(itemsUnitsObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var itemUnitEntity = entity.Set<itemsUnits>();
                        if (newObject.itemUnitId == 0)
                        {
                            //create
                            // set the other default sale or purchase to 0 if the new object.default is 1

                            if (newObject.defaultSale == 1)
                            { // get the row with same itemId of newObject
                                itemsUnits defItemUnit = entity.itemsUnits.Where(p => p.itemId == newObject.itemId && p.defaultSale == 1).FirstOrDefault();
                                if (defItemUnit != null)
                                {
                                    defItemUnit.defaultSale = 0;
                                    entity.SaveChanges();
                                }
                            }
                            if (newObject.defaultPurchase == 1)
                            {
                                var defItemUnit = entity.itemsUnits.Where(p => p.itemId == newObject.itemId && p.defaultPurchase == 1).FirstOrDefault();
                                if (defItemUnit != null)
                                {
                                    defItemUnit.defaultPurchase = 0;
                                    entity.SaveChanges();
                                }
                            }
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;
                            newObject.isActive = 1;

                            itemUnitEntity.Add(newObject);
                            message = "Item Unit Is Added Successfully";
                        }
                        else
                        {
                            //update
                            // set the other default sale or purchase to 0 if the new object.default is 1
                            int itemUnitId = newObject.itemUnitId;
                            var tmpItemUnit = entity.itemsUnits.Find(itemUnitId);
                           
                            if (newObject.defaultSale == 1)
                            {
                                itemsUnits saleItemUnit = entity.itemsUnits.Where(p => p.itemId == tmpItemUnit.itemId && p.defaultSale == 1).FirstOrDefault();
                                if (saleItemUnit != null)
                                {
                                    saleItemUnit.defaultSale = 0;
                                    entity.SaveChanges();
                                }
                            }
                            if (newObject.defaultPurchase == 1)
                            {
                                var defItemUnit = entity.itemsUnits.Where(p => p.itemId == tmpItemUnit.itemId && p.defaultPurchase == 1).FirstOrDefault();
                                if (defItemUnit != null)
                                {
                                    defItemUnit.defaultPurchase = 0;
                                    entity.SaveChanges();
                                }
                            }
                            tmpItemUnit.barcode = newObject.barcode;
                           // tmpItemUnit.itemId = newObject.itemId;
                            tmpItemUnit.price = newObject.price;
                            tmpItemUnit.subUnitId = newObject.subUnitId;
                            tmpItemUnit.unitId = newObject.unitId;
                            tmpItemUnit.unitValue = newObject.unitValue;
                            tmpItemUnit.defaultPurchase = newObject.defaultPurchase;
                            tmpItemUnit.defaultSale = newObject.defaultSale;
                            tmpItemUnit.updateDate = DateTime.Now;
                            tmpItemUnit.updateUserId = newObject.updateUserId;
                            tmpItemUnit.storageCostId = newObject.storageCostId;
                            tmpItemUnit.isActive = newObject.isActive;
                            message = "Item Unit Is Updated Successfully";
                        }
                        entity.SaveChanges();
                    }
                }
                catch
                {
                    message = "an error ocurred";
                }
            }
            return Ok( message);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int ItemUnitId,int userId, Boolean final)
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
                        if (final)
                        {
                            itemsUnits itemUnit = entity.itemsUnits.Find(ItemUnitId);

                            entity.itemsUnits.Remove(itemUnit);
                            entity.SaveChanges();

                            return Ok("Item Unit is Deleted Successfully");

                        }
                        else
                        {

                            itemsUnits unitDelete = entity.itemsUnits.Find(ItemUnitId);
                            unitDelete.isActive = 0;
                            unitDelete.updateDate = DateTime.Now;
                            unitDelete.updateUserId = userId;
                            entity.SaveChanges();
                            return Ok("Unit is Deleted Successfully");
                        }
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

        [HttpGet]
        [Route("GetAllBarcodes")]
        public IHttpActionResult GetAllBarcodes()
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
                    var barcods = (from i in entity.itemsUnits
                                   join u in entity.units on i.unitId equals u.unitId

                                   select new ItemUnitModel()
                                   {
                                       itemId = i.itemId,
                                       barcode = i.barcode,
                                       unitId = i.unitId,
                                       itemUnitId = i.itemUnitId,
                                       mainUnit = u.name,
                                   }).ToList();

                    if (barcods == null)
                        return NotFound();
                    else
                        return Ok(barcods);
                }
            }
            //else
            return NotFound();
        }

        [HttpGet]
        [Route("Getall")]
        public IHttpActionResult Getall()
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
                    var itemUnitsList = (from IU in entity.itemsUnits
                                         
                                         join u in entity.units on IU.unitId equals u.unitId 
                                      
                                         join i in entity.items on IU.itemId equals i.itemId 
                                       orderby i.name
                                         select new ItemUnitModel()
                                         {
                                             itemUnitId = IU.itemUnitId,
                                             unitId = IU.unitId,
                                             itemId=IU.itemId,
                                             mainUnit = u.name,
                                             createDate = IU.createDate,
                                             createUserId = IU.createUserId,
                                             defaultPurchase = IU.defaultPurchase,
                                             defaultSale = IU.defaultSale,
                                             price = IU.price,
                                             subUnitId = IU.subUnitId,
                                             
                                             unitValue = IU.unitValue,
                                             barcode = IU.barcode,
                                             updateDate = IU.updateDate,
                                             updateUserId = IU.updateUserId,
                                             itemName=i.name,
                                             itemCode=i.code,
                                             unitName = u.name,
                                            storageCostId = IU.storageCostId,

                                         })
                                         .ToList();

                    if (itemUnitsList == null)
                        return NotFound();
                    else
                        return Ok(itemUnitsList);
                }
            }
            //else
            return NotFound();
        }





        [HttpGet]
        [Route("GetbyOfferId")]
        public IHttpActionResult GetbyOfferId()
        { int offerId = 0;
            var re = Request;
            var headers = re.Headers;
            string token = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("offerId"))
            {
                offerId = Convert.ToInt32(headers.GetValues("offerId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid) // APIKey is valid
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var itemUnitsList = (from IU in entity.itemsUnits
                                         join IO in entity.itemsOffers on IU.itemUnitId equals IO.iuId
                                         join u in entity.units on IU.unitId equals u.unitId

                                         join i in entity.items on IU.itemId equals i.itemId
                                         orderby i.name
                                         where IO.offerId==offerId
                                         select new ItemUnitModel()
                                         {
                                             itemUnitId = IU.itemUnitId,
                                             unitId = IU.unitId,
                                             itemId = IU.itemId,
                                             mainUnit = u.name,
                                             createDate = IU.createDate,
                                             createUserId = IU.createUserId,
                                             defaultPurchase = IU.defaultPurchase,
                                             defaultSale = IU.defaultSale,
                                             price = IU.price,
                                             subUnitId = IU.subUnitId,

                                             unitValue = IU.unitValue,
                                             barcode = IU.barcode,
                                             updateDate = IU.updateDate,
                                             updateUserId = IU.updateUserId,
                                             itemName = i.name,
                                             itemCode = i.code,
                                             unitName = u.name,
                                             storageCostId=IU.storageCostId,

                                         })
                                         .ToList();

                    if (itemUnitsList == null)
                        return NotFound();
                    else
                        return Ok(itemUnitsList);
                }
            }
            //else
            return NotFound();
        }

        [HttpGet]
        [Route("getSmallItemUnits")]
        public IHttpActionResult getSmallItemUnits(int itemId, int itemUnitId)
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
                    // get all sub item units 
                    List<itemsUnits> unitsList = entity.itemsUnits
                     .ToList().Where(x => x.itemId == itemId)
                      .Select(p => new itemsUnits
                      {
                          itemUnitId = p.itemUnitId,
                          unitId = p.unitId,
                          subUnitId = p.subUnitId,
                      })
                     .ToList();

                    var unitId = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => x.unitId).Single();
                    itemUnitsIds = new List<int>();
                    itemUnitsIds.Add(itemUnitId);

                    var result = Recursive(unitsList, (int)unitId);

                    var units = (from iu in entity.itemsUnits.Where(x => x.itemId == itemId)
                                 join  u in entity.units on iu.unitId equals u.unitId
                                 select new ItemUnitModel()
                                 {
                                     unitId = iu.unitId,
                                    itemUnitId = iu.itemUnitId,
                                     subUnitId = iu.subUnitId,
                                     mainUnit = u.name,

                                 }).Where(p => !itemUnitsIds.Contains((int)p.itemUnitId)).ToList();

                    if (units == null)
                        return NotFound();
                    else
                        return Ok(units);
                }

            }
            else
            {
                return NotFound();
            }

        }

        public IEnumerable<itemsUnits> Recursive(List<itemsUnits> unitsList, int smallLevelid)
        {
            List<itemsUnits> inner = new List<itemsUnits>();

            foreach (var t in unitsList.Where(item => item.subUnitId == smallLevelid))
            {
               // if (t.unitId.Value != smallLevelid)
               // {
                    itemUnitsIds.Add(t.itemUnitId);
                    inner.Add(t);
               // }
                if (t.unitId.Value == smallLevelid)
                    return inner;
                inner = inner.Union(Recursive(unitsList, t.unitId.Value)).ToList();
            }

            return inner;
        }
        [HttpGet]
        [Route("largeToSmallUnitQuan")]
        public int largeToSmallUnitQuan(int fromItemUnit, int toItemUnit)
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
                amount += getUnitConversionQuan(fromItemUnit, toItemUnit);
            }
            return amount;
        }
        private int getUnitConversionQuan(int fromItemUnit, int toItemUnit)
        {
            int amount = 0;

            using (incposdbEntities entity = new incposdbEntities())
            {
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == toItemUnit).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();
                if (upperUnit != null)
                    amount = (int)upperUnit.unitValue;
                if (fromItemUnit == upperUnit.itemUnitId)
                    return amount;
                if (upperUnit != null)
                    amount += (int)upperUnit.unitValue * getUnitConversionQuan(fromItemUnit,upperUnit.itemUnitId);

                return amount;
            }
        }
        [HttpGet]
        [Route("smallToLargeUnitQuan")]
        public int smallToLargeUnitQuan(int fromItemUnit, int toItemUnit)
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
                amount = getLargeUnitConversionQuan(fromItemUnit, toItemUnit);
            }
            return amount;
        }
        private int getLargeUnitConversionQuan(int fromItemUnit, int toItemUnit)
        {
            int amount = 0;

            using (incposdbEntities entity = new incposdbEntities())
            {
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == toItemUnit).Select(x => new { x.unitId, x.itemId ,x.subUnitId, x.unitValue}).FirstOrDefault();
                var smallUnit = entity.itemsUnits.Where(x => x.unitId == unit.subUnitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();
             
                if (toItemUnit == smallUnit.itemUnitId)
                {
                    amount = 1;
                    return amount;
                }
              
                if (smallUnit != null)
                    amount += (int)unit.unitValue * getLargeUnitConversionQuan(fromItemUnit, smallUnit.itemUnitId);


                return amount;
            }
        }
    }
}
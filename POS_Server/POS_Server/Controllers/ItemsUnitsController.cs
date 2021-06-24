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
                                         where (IU.itemId == itemId)
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
        // add or update item unit
        [HttpPost]
        [Route("Save")]
        public string Save(string itemsUnitsObject)
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

                            itemUnitEntity.Add(newObject);
                            message = "Item Unit Is Added Successfully";
                        }
                        else
                        {
                            //update
                            // set the other default sale or purchase to 0 if the new object.default is 1
                            var tmpItemUnit = entity.itemsUnits.Where(p => p.itemUnitId == newObject.itemUnitId).FirstOrDefault();
                            if (newObject.defaultSale == 1)
                            {
                                itemsUnits defItemUnit = entity.itemsUnits.Where(p => p.itemId == newObject.itemId && p.defaultSale == 1).FirstOrDefault();

                                defItemUnit.defaultSale = 0;
                                entity.SaveChanges();
                            }
                            if (newObject.defaultPurchase == 1)
                            {
                                var defItemUnit = entity.itemsUnits.Where(p => p.itemId == newObject.itemId && p.defaultPurchase == 1).FirstOrDefault();
                                defItemUnit.defaultPurchase = 0;
                                entity.SaveChanges();
                            }
                            tmpItemUnit.barcode = newObject.barcode;
                            tmpItemUnit.itemId = newObject.itemId;
                            tmpItemUnit.price = newObject.price;
                            tmpItemUnit.subUnitId = newObject.subUnitId;
                            tmpItemUnit.unitId = newObject.unitId;
                            tmpItemUnit.unitValue = newObject.unitValue;
                            tmpItemUnit.defaultPurchase = newObject.defaultPurchase;
                            tmpItemUnit.defaultSale = newObject.defaultSale;
                            tmpItemUnit.updateDate = DateTime.Now;
                            tmpItemUnit.updateUserId = newObject.updateUserId;

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
            return message;
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int ItemUnitId)
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
                        itemsUnits itemUnit = entity.itemsUnits.Find(ItemUnitId);

                        entity.itemsUnits.Remove(itemUnit);
                        entity.SaveChanges();

                        return Ok("Item Unit is Deleted Successfully");
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
    }
}
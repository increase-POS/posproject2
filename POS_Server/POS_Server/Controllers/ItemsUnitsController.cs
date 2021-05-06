using Newtonsoft.Json;
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
                    var itemUnitsList = entity.itemsUnits
                        .Where(IU => IU.itemId == itemId)
                        .Select(IU => new
                        {
                            IU.itemUnitId,
                            IU.unitId,
                            IU.createDate,
                            IU.createUserId,
                            IU.defaultPurchase,
                            IU.defaultSale,
                            IU.price,
                            IU.subUnitId,
                            IU.unitValue,
                            IU.updateDate,
                            IU.updateUserId,
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
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;

                            itemUnitEntity.Add(newObject);
                            message = "Item Unit Is Added Successfully";
                        }
                        else
                        {
                            // set the other default sale or purchase to 0 if the new object.default is 1
                            var tmpItemUnit = entity.itemsUnits.Where(p => p.itemUnitId == newObject.itemUnitId).FirstOrDefault();
                            if (newObject.defaultSale==1)
                            {
                                itemsUnits defItemUnit = entity.itemsUnits.Where(p => p.itemId == newObject.itemId && p.defaultSale== 1 ).FirstOrDefault();

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
    }
}
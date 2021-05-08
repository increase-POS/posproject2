using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using POS_Server.Models;

namespace POS_Server.Controllers
{
  

    [RoutePrefix("api/Items")]
    public class ItemsController : ApiController
    {
        Classes.Calculate Calc = new Classes.Calculate();

        List<int> categoriesId = new List<int>();

        [HttpGet]
        [Route("GetAllItems")]
        public IHttpActionResult GetAllItems()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            Boolean canDelete = false;

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
                    var itemsList = ( from I in entity.items
                                      join c in entity.categories on I.categoryId equals c.categoryId into lj
                                      from x in lj.DefaultIfEmpty()
                                       select new ItemModel(){
                                      itemId = I.itemId,
                                      name = I.name,
                                      code = I.code,
                                      categoryId = I.categoryId,
                                      categoryName = x.name,
                                      max = I.max,
                                      maxUnitId = I.maxUnitId,
                                      minUnitId = I.minUnitId,
                                      min = I.min,
                                      
                                      parentId = I.parentId,
                                    isActive=I.isActive,
                                      image = I.image,
                                      type = I.type,
                                      details = I.details,
                                      taxes = I.taxes,
                                      createDate = I.createDate,
                                      updateDate = I.updateDate,
                                      createUserId = I.createUserId,
                                      updateUserId = I.updateUserId
                                   })
                                   .ToList();

                    if (itemsList.Count > 0)
                    {
                        for (int i = 0; i < itemsList.Count; i++)
                        {
                            if (itemsList[i].isActive == 1)
                            {
                                int itemId = (int)itemsList[i].itemId;
                                var itemsPropL = entity.itemsProp.Where(x => x.itemId == itemId).Select(b => new { b.itemPropId }).FirstOrDefault();
                                var ordersL = entity.orderscontents.Where(x => x.itemId == itemId).Select(b => new { b.orderId }).FirstOrDefault();
                                var itemUnitsL = entity.itemsUnits.Where(x => x.itemId == itemId).Select(b => new { b.itemUnitId }).FirstOrDefault();
                                var itemLocationsL = entity.itemsLocations.Where(x => x.itemId == itemId).Select(b => new { b.itemsLocId }).FirstOrDefault();
                                var itemsMaterials = entity.itemsMaterials.Where(x => x.itemId == itemId).Select(b => new { b.itemMatId }).FirstOrDefault();
                                var serials = entity.serials.Where(x => x.itemId == itemId).Select(b => new { b.serialId }).FirstOrDefault();

                                if ((itemsPropL is null) && (ordersL is null) && (itemUnitsL is null) && (itemLocationsL is null) && (itemsMaterials is null) && (serials is null))
                                    canDelete = true;
                            }
                            itemsList[i].canDelete = canDelete;
                        }
                    }

                    if (itemsList == null)
                        return NotFound();
                    else
                        return Ok(itemsList);
                }
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetItemsInCategory")]
        public IHttpActionResult GetItemsInCategory(int categoryId)
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
                    var itemsList = entity.items
                   .Where(I => I.categoryId == categoryId && I.isActive == 1)
                   .Select(I => new {
                       I.itemId,
                       I.name,
                       I.code,
                       
                       I.max,
                       I.maxUnitId,
                       I.minUnitId,
                       I.min,
                       I.parentId,
                    
                       I.image,
                       I.type,
                       I.details,
                       I.taxes,
                       I.createDate,
                       I.updateDate,
                       I.createUserId,
                       I.updateUserId
                   })
                   .ToList();

                    if (itemsList == null)
                        return NotFound();
                    else
                        return Ok(itemsList);
                }
            }
            else
                return NotFound();
        }


        // GET api/agent/5
        [HttpGet]
        [Route("GetItemByID")]
        public IHttpActionResult GetItemByID(int itemId)
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

                    var item = entity.items
                   .Where(I => I.itemId == itemId)
                   .Select(I => new {
                       I.itemId,
                       I.name,
                       I.code,
                      
                       I.max,
                       I.maxUnitId,
                       I.minUnitId,
                       I.min,
                       I.parentId,
                      
                       I.image,
                       I.type,
                       I.details,
                       I.taxes,
                       I.createDate,
                       I.updateDate,
                       I.createUserId,
                       I.updateUserId
                   })
                   .FirstOrDefault();

                    if (item == null)
                        return NotFound();
                    else
                        return Ok(item);

                }
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetItemByBarcode")]
        public IHttpActionResult GetItemByBarcode(string barcode)
        {
            int itemId = 0;
            using (incposdbEntities entity = new incposdbEntities())
            {
               // itemId = (int)entity.barcodes
                //    .Where(I => I.barcode == barcode)
                //    .Select(I => I.itemId).SingleOrDefault();
            }
            return GetItemByID(itemId);
        }

        // GET api/agent/5
        [HttpGet]
        [Route("GetItemsByType")]
        public IHttpActionResult GetItemsByType(string type)
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

                    var agent = entity.items
                   .Where(I => I.type == type)
                   .Select(I => new {
                       I.itemId,
                       I.name,
                       I.code,
                       
                       I.max,
                       I.maxUnitId,
                       I.minUnitId,
                       I.min,
                       I.parentId,
                       
                       I.image,
                       I.type,
                       I.details,
                       I.isActive,
                       I.taxes,
                       I.createDate,
                       I.updateDate,
                       I.createUserId,
                       I.updateUserId
                   })
                   .ToList();

                    if (agent == null)
                        return NotFound();
                    else
                        return Ok(agent);

                }
            }
            else
                return NotFound();
        }
        // get item in category and all of her sub gategories
        [HttpGet]
        [Route("GetItemsInCategoryAndSub")]
        public IHttpActionResult GetItemsInCategoryAndSub(int categoryId)
        {
            using (incposdbEntities entity = new incposdbEntities())
            {
                // get all sub categories of categoryId
                List<categories> categoriesList = entity.categories
                      .Where(c => c.isActive == 1).ToList()
                      .Select(p => new categories
                      {
                          categoryId = p.categoryId,
                          name = p.name,
                          parentId = p.parentId,
                      })
                     .ToList();

                categoriesId = new List<int>();
                categoriesId.Add(categoryId);

                // get items
                var result = Recursive(categoriesList,categoryId);
                var items = entity.items
                    .Where(t => categoriesId.Contains((int)t.categoryId))
                    .Select(I => new {
                        I.itemId,
                        I.name,
                        I.code,
                        
                        I.max,
                        I.maxUnitId,
                        I.minUnitId,
                        I.min,
                        I.parentId,
                       
                        I.image,
                        I.type,
                        I.details,
                        I.taxes,
                        I.createDate,
                        I.updateDate,
                        I.createUserId,
                        I.updateUserId
                    })
                    .ToList();
                return Ok(items);
            }

        }

        public  IEnumerable<categories> Recursive(List<categories> categoriesList, int toplevelid)
        {
            List<categories> inner = new List<categories>();
            
            foreach (var t in categoriesList.Where(item => item.parentId == toplevelid))
            {
                categoriesId.Add(t.categoryId);
                inner.Add(t);
                inner = inner.Union(Recursive(categoriesList, t.categoryId)).ToList();
            }

            return inner;
        }
        // add or update item
        [HttpPost]
        [Route("Save")]
        public string Save(string itemObject)
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

            itemObject = itemObject.Replace("\\", string.Empty);
            itemObject = itemObject.Trim('"');

            items itemObj = JsonConvert.DeserializeObject<items>(itemObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (itemObj.updateUserId == 0 || itemObj.updateUserId == null)
            {
                Nullable<int> id = null;
                itemObj.updateUserId = id;
            }
            if (itemObj.createUserId == 0 || itemObj.createUserId == null)
            {
                Nullable<int> id = null;
                itemObj.createUserId = id;
            }
            if (itemObj.categoryId == 0 || itemObj.categoryId == null)
            {
                Nullable<int> id = null;
                itemObj.categoryId = id;
            }
            if (itemObj.minUnitId == 0 || itemObj.minUnitId == null)
            {
                Nullable<int> id = null;
                itemObj.minUnitId = id;
            }
            if (itemObj.maxUnitId == 0 || itemObj.maxUnitId == null)
            {
                Nullable<int> id = null;
                itemObj.maxUnitId = id;
            }
            if (valid)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var ItemEntity = entity.Set<items>();
                        if (itemObj.itemId == 0)
                        {

                            itemObj.createDate = DateTime.Now;
                            itemObj.updateDate = DateTime.Now;
                            itemObj.updateUserId = itemObj.createUserId;

                            ItemEntity.Add(itemObj);
                            message = "Item Is Added Successfully";
                        }
                        else
                        {
                            var itemModel = entity.items.Where(p => p.itemId == itemObj.itemId).First();
                            itemModel.code = itemObj.code;
                            itemModel.categoryId = itemObj.categoryId;
                            itemModel.parentId = itemObj.parentId;
                            itemModel.details = itemObj.details;
                            itemModel.image = itemObj.image;
                            itemModel.max = itemObj.max;
                            itemModel.maxUnitId = itemObj.maxUnitId;
                            itemModel.min = itemObj.min;
                            itemModel.minUnitId = itemObj.minUnitId;
                            itemModel.name = itemObj.name;
                            
                            itemModel.taxes = itemObj.taxes;
                            itemModel.type = itemObj.type;
                            itemModel.updateDate = DateTime.Now;
                            itemModel.updateUserId = itemObj.updateUserId;
                            itemModel.isActive = itemObj.isActive;

                            message = "Item Is Updated Successfully";
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
        public IHttpActionResult Delete(int itemId, int userId,Boolean final)
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
                            var tmpItem = entity.items.Where(I => I.itemId == itemId).First();
                            entity.items.Remove(tmpItem);                          
                            entity.SaveChanges();
                            return Ok("Item is Deleted Successfully");
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
                            var tmpItem = entity.items.Where(I => I.itemId == itemId).First();
                            tmpItem.isActive = 0;
                            tmpItem.updateDate = DateTime.Now;
                            tmpItem.updateUserId = userId;

                            entity.SaveChanges();
                            return Ok("Item is Deleted Successfully");
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
        [HttpGet]
        [Route("GetSubItems")]
        public IHttpActionResult GetSubItems(int itemId)
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
                    if (itemId != 0)
                    {
                        var itemsList = entity.items
                       .Where(c => c.parentId == itemId && c.isActive == 1)
                       .Select(I => new {
                           I.itemId,
                           I.name,
                           I.code,
                          
                           I.max,
                           I.maxUnitId,
                           I.minUnitId,
                           I.min,
                           I.parentId,
                          
                           I.image,
                           I.type,
                           I.details,
                           I.isActive,
                           I.taxes,
                           I.createDate,
                           I.updateDate,
                           I.createUserId,
                           I.updateUserId
                       })
                       .ToList();
                        if (itemsList == null)
                            return NotFound();
                        else
                            return Ok(itemsList);
                    }
                    else
                    {
                        var itemsList = entity.items
                       .Where(c => c.parentId == 0 && c.isActive == 1)
                       .Select(I => new {
                           I.itemId,
                           I.name,
                           I.code,
                           
                           I.max,
                           I.maxUnitId,
                           I.minUnitId,
                           I.min,
                           I.parentId,
                         
                           I.image,
                           I.type,
                           I.details,
                           I.isActive,
                           I.taxes,
                           I.createDate,
                           I.updateDate,
                           I.createUserId,
                           I.updateUserId
                       })
                       .ToList();
                        if (itemsList == null)
                            return NotFound();
                        else
                            return Ok(itemsList);
                    }
                }
            }
            else
                return NotFound();
        }


        // get all items where defaultSale is 1 and set isNew=1 if new item  and set isOffer=1 if Has Active Offer 
        int newdays = -15;

        #region
        [HttpGet]
        [Route("GetAllSaleItems")]
        public IHttpActionResult GetAllSaleItems()
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
                    var itemsunit = (from itm in entity.items
                                     join cat in entity.categories on itm.categoryId equals cat.categoryId
                                     //  join itun in entity.itemsUnits on itm.itemId equals itun.itemId 
                                     //   join untb in entity.units on itun.unitId equals untb.unitId

                                     select new ItemModel()
                                     {
                                         itemId = itm.itemId,
                                         name = itm.name,
                                         code = itm.code,
                                         image = itm.image,
                                         details = itm.details,
                                         type = itm.type,
                                         createUserId = itm.createUserId,
                                         updateUserId = itm.updateUserId,
                                         updateDate = itm.updateDate,

                                         categoryId = itm.categoryId,
                                         categoryName = cat.name,

                                         max = itm.max,
                                         maxUnitId = itm.maxUnitId,
                                         minUnitId = itm.minUnitId,
                                         min = itm.min,
                                        
                                         parentId = itm.parentId,
                                         isActive = itm.isActive,
                                         taxes = itm.taxes,
                                         isOffer = 0,
                                         desPrice = 0,
                                         isNew = 0,
                                         offerName = "",
                                         createDate = itm.createDate,

                                     }).ToList();

                    var itemsofferslist = (from off in entity.offers

                                           join itof in entity.itemsOffers on off.offerId equals itof.offerId // itemsOffers and offers 

                                           //  join iu in entity.itemsUnits on itof.iuId  equals  iu.itemUnitId //itemsUnits and itemsOffers
                                           join iu in entity.itemsUnits on itof.iuId equals iu.itemUnitId
                                           //from un in entity.units
                                           select new ItemModel()
                                           {
                                               itemId = iu.itemId,
                                               itemUnitId = itof.iuId,
                                               offerName = off.name,
                                               offerId = off.offerId,
                                               discountValue = off.discountValue,
                                               isNew = 0,
                                               isOffer = 1,
                                               isActiveOffer = off.isActive,
                                               startDate = off.startDate,
                                               endDate = off.endDate,
                                               unitId = iu.unitId,

                                               price = iu.price,
                                               discountType = off.discountType,
                                               desPrice = iu.price,
                                               defaultSale = iu.defaultSale,

                                           }).Where(IO => IO.isActiveOffer == 1 && DateTime.Compare((DateTime)IO.startDate, DateTime.Now) <= 0 && System.DateTime.Compare((DateTime)IO.endDate, DateTime.Now) >= 0 && IO.defaultSale == 1).Distinct().ToList();
                    //.Where(IO => IO.isActiveOffer == 1 && DateTime.Compare(IO.startDate,DateTime.Now)<0 && System.DateTime.Compare(IO.endDate, DateTime.Now) > 0).ToList();

                    // test

                    var unt = (from unitm in entity.itemsUnits
                               join untb in entity.units on unitm.unitId equals untb.unitId
                               join itemtb in entity.items on unitm.itemId equals itemtb.itemId

                               select new ItemModel()
                               {
                                   itemId = itemtb.itemId,
                                   name = itemtb.name,
                                   code = itemtb.code,


                                   max = itemtb.max,
                                   maxUnitId = itemtb.maxUnitId,
                                   minUnitId = itemtb.minUnitId,
                                   min = itemtb.min,
                                
                                   parentId = itemtb.parentId,
                                   isActive = itemtb.isActive,

                                   isOffer = 0,
                                   desPrice = 0,

                                   offerName = "",
                                   createDate = itemtb.createDate,
                                   defaultSale = unitm.defaultSale,
                                   unitName = untb.name,
                                   unitId = untb.unitId,
                                   price = unitm.price,

                               }).Where(a => a.defaultSale == 1).Distinct().ToList();

                    // end test

                    foreach (var iunlist in itemsunit)
                    {

                        foreach (var row in unt)
                        {
                            if (row.itemId == iunlist.itemId)
                            {
                               

                                iunlist.unitName = row.unitName;
                                iunlist.unitId = row.unitId;
                                iunlist.price = row.price;
                                iunlist.priceTax = iunlist.price+ Calc.percentValue(row.price, iunlist.taxes);
                              
                            }
                        }

                        // get set is new

                        DateTime cmpdate = DateTime.Now.AddDays(newdays);

                        int res = DateTime.Compare((DateTime)iunlist.createDate, cmpdate);
                        if (res >= 0)
                        {
                            iunlist.isNew = 1;
                        }
                        // end is new
                        decimal? totaldis = 0;

                        foreach (var itofflist in itemsofferslist)
                        {


                            if (iunlist.itemId == itofflist.itemId)
                            {

                                // get unit name of item that has the offer
                                using (incposdbEntities entitydb = new incposdbEntities())
                                { // put it in item
                                    var un = entitydb.units
                                     .Where(a => a.unitId == itofflist.unitId)
                                        .Select(u => new
                                        {
                                            u.name
                                       ,
                                            u.unitId
                                        }).FirstOrDefault();
                                    iunlist.unitName = un.name;
                                }

                                iunlist.offerName = iunlist.offerName + "- " + itofflist.offerName;
                                iunlist.isOffer = 1;
                                iunlist.startDate = itofflist.startDate;
                                iunlist.endDate = itofflist.endDate;
                                iunlist.itemUnitId = itofflist.itemUnitId;
                                iunlist.offerId = itofflist.offerId;
                                iunlist.isActiveOffer = itofflist.isActiveOffer;

                                iunlist.price = itofflist.price;
                                iunlist.priceTax = iunlist.price + (iunlist.price * iunlist.taxes / 100);
                                iunlist.discountType = itofflist.discountType;
                                iunlist.discountValue = itofflist.discountValue;

                                if (iunlist.discountType == "1") // value
                                {

                                    totaldis = totaldis + iunlist.discountValue;
                                }
                                else if (iunlist.discountType == "2") // percent
                                {

                                    totaldis = totaldis + Calc.percentValue(iunlist.price, iunlist.discountValue);

                                }



                            }
                        }
                        iunlist.desPrice = iunlist.priceTax - totaldis;
                    }

                    //  if (itemsunit == null)
                    //if (itemsofferslist == null)
                    if (itemsunit == null)
                        return NotFound();
                    else
                        return Ok(itemsunit);


                }

            }
            else
            {
                return NotFound();
            }

        }
        #endregion
        // get all items where defaultPurchase is 1 and set isNew=1 if new item
        #region
        [HttpGet]
        [Route("GetAllPurItems")]
        public IHttpActionResult GetAllPurItems()
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
                    var itemsunit = (from itm in entity.items
                                     join cat in entity.categories on itm.categoryId equals cat.categoryId
                                     join itun in entity.itemsUnits on itm.itemId equals itun.itemId
                                     join untb in entity.units on itun.unitId equals untb.unitId
                                     select new ItemModel()
                                     {
                                         itemId = itm.itemId,
                                         name = itm.name,
                                         code = itm.code,
                                         image = itm.image,
                                         details = itm.details,
                                         type = itm.type,
                                         createUserId = itm.createUserId,
                                         updateUserId = itm.updateUserId,
                                         createDate = itm.createDate,
                                         updateDate = itm.updateDate,
                                         max = itm.max,
                                         min = itm.min,
                                         maxUnitId = itm.maxUnitId,
                                         minUnitId = itm.minUnitId,

                                         categoryId = itm.categoryId,
                                         categoryName = cat.name,


                                       
                                         parentId = itm.parentId,
                                         isActive = itm.isActive,
                                         taxes = itm.taxes,
                                         isOffer = 0,
                                         desPrice = 0,
                                         isNew = 0,
                                         offerName = "",

                                         defaultPurchase = itun.defaultPurchase,
                                         unitId = itun.unitId,

                                         price = itun.price,
                                         unitName = untb.name,
                                         itemUnitId = itun.itemUnitId,
                                     }).Where(p => p.defaultPurchase == 1).OrderBy(a => a.itemId).ToList();


                    // end test

                    //  set is new

                    DateTime cmpdate = DateTime.Now.AddDays(newdays);
                    foreach (var iunlist in itemsunit)
                    {

                        int res = DateTime.Compare((DateTime)iunlist.createDate, cmpdate);
                        if (res >= 0)
                        {
                            iunlist.isNew = 1;
                        }



                    }

                    //  if (itemsunit == null)
                    //if (itemsofferslist == null)
                    if (itemsunit == null)
                        return NotFound();
                    else
                        return Ok(itemsunit);


                }

            }
            else
            {
                return NotFound();
            }

        }
        #endregion
    }
}
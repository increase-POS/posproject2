using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using POS_Server.Models;
using System.Web;
using System.IO;
using LinqKit;
using Microsoft.Ajax.Utilities;
using POS_Server.Classes;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Items")]
    public class ItemsController : ApiController
    {
        private Classes.Calculate Calc = new Classes.Calculate();

        List<int> categoriesId = new List<int>();

        [HttpGet]
        [Route("GetAllItems")]
        public IHttpActionResult GetAllItems()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            Boolean canDelete = false;
            DateTime cmpdate = DateTime.Now.AddDays(newdays);
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
                    var  itemsList = (from I in entity.items

                                                 join c in entity.categories on I.categoryId equals c.categoryId into lj
                                                 from x in lj.DefaultIfEmpty()
                                                 select new ItemModel()
                                                 {
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
                                                     isActive = I.isActive,
                                                     image = I.image,
                                                     type = I.type,
                                                     details = I.details,
                                                     taxes = I.taxes,
                                                     createDate = I.createDate,
                                                     updateDate = I.updateDate,
                                                     createUserId = I.createUserId,
                                                     updateUserId = I.updateUserId,
                                                     isNew = 0,
                                                     parentName = entity.items.Where(m => m.itemId == I.parentId).FirstOrDefault().name,
                                                     minUnitName = entity.units.Where(m => m.unitId == I.minUnitId).FirstOrDefault().name,
                                                     maxUnitName = entity.units.Where(m => m.unitId == I.minUnitId).FirstOrDefault().name,


                                                 })
                                   .ToList();


                    if (itemsList.Count > 0)
                    {
                        for (int i = 0; i < itemsList.Count; i++)
                        {
                            canDelete = false;
                            if (itemsList[i].isActive == 1)
                            {
                                int itemId = (int)itemsList[i].itemId;
                                var childItemL = entity.items.Where(x => x.parentId == itemId).Select(b => new { b.itemId }).FirstOrDefault();
                                var itemsPropL = entity.itemsProp.Where(x => x.itemId == itemId).Select(b => new { b.itemPropId }).FirstOrDefault();
                                  var itemUnitsL = entity.itemsUnits.Where(x => x.itemId == itemId).Select(b => new { b.itemUnitId }).FirstOrDefault();
                                string itemType = itemsList[i].type;
                                int isInInvoice = 0;
                                int isInLocation = 0;
                                if (itemType == "p" && itemUnitsL != null)
                                {
                                    isInInvoice = entity.itemsTransfer.Where(x => x.itemUnitId == itemUnitsL.itemUnitId).Select(x => x.itemsTransId).FirstOrDefault();
                                    isInLocation = entity.itemsLocations.Where(x => x.itemUnitId == itemUnitsL.itemUnitId).Select(x => x.itemsLocId).FirstOrDefault();

                                }
                                //var itemLocationsL = entity.itemsLocations.Where(x => x.itemId == itemId).Select(b => new { b.itemsLocId }).FirstOrDefault();
                                var itemsMaterials = entity.itemsMaterials.Where(x => x.itemId == itemId).Select(b => new { b.itemMatId }).FirstOrDefault();
                                var serials = entity.serials.Where(x => x.itemId == itemId).Select(b => new { b.serialId }).FirstOrDefault();
                             

                                if ((childItemL is null)&&(itemsPropL is null)  && ((itemUnitsL is null && !itemType.Equals("p") ) || (isInInvoice == 0 && itemType.Equals("p") && isInLocation == 0))  
                                    && (itemsMaterials is null) && (serials is null))
                                    canDelete = true;
                            }
                            itemsList[i].canDelete = canDelete;

                            // is new
                            
                           

                                int res = DateTime.Compare((DateTime)itemsList[i].createDate, cmpdate);
                                if (res >= 0)
                                {
                                itemsList[i].isNew= 1;
                                }



                            
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
        private int getItemUnitAmount(int itemUnitId, int branchId)
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
                    amount += (int)itemInLocs[i].quantity;
                }

                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (upperUnit != null && itemUnitId == upperUnit.itemUnitId)
                    return amount;
                if (upperUnit != null)
                    amount += (int)upperUnit.unitValue * getItemUnitAmount(upperUnit.itemUnitId, branchId);

                return amount;
            }
        }
        [HttpGet]
        [Route("GetSaleOrPurItems")]
        public IHttpActionResult GetSaleOrPurItems(int categoryId, short defaultSale, short defaultPurchase,int branchId)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            DateTime cmpdate = DateTime.Now.AddDays(newdays);
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
                    var searchPredicate = PredicateBuilder.New<items>();

                    var unitPredicate = PredicateBuilder.New<itemsUnits>();

                    if (categoryId != 0)
                    {
                        List<categories> categoriesList = entity.categories.ToList()
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
                        var result = Recursive(categoriesList, categoryId);
                        searchPredicate = searchPredicate.Or(item => categoriesId.Contains((int)item.categoryId));
                    }
                    else
                        searchPredicate = searchPredicate.Or(item => true);
                    #region items for order
                    if (defaultSale == 0 && defaultPurchase == 0)
                    {
                        var itemsList = (from I in entity.items.Where(searchPredicate)
                                         join u in entity.itemsUnits on I.itemId equals u.itemId
                                         select new ItemSalePurModel()
                                         {
                                             itemId = I.itemId,
                                             name = I.name,
                                             code = I.code,
                                             categoryId = I.categoryId,
                                             categoryName = I.categories.name,
                                             max = I.max,
                                             maxUnitId = I.maxUnitId,
                                             minUnitId = I.minUnitId,
                                             min = I.min,

                                             parentId = I.parentId,
                                             isActive = I.isActive,
                                             image = I.image,
                                             type = I.type,
                                             details = I.details,
                                             taxes = I.taxes,
                                             createDate = I.createDate,
                                             updateDate = I.updateDate,
                                             createUserId = I.createUserId,
                                             updateUserId = I.updateUserId,
                                             isNew = 0,
                                             //price = u.price,

                                         }).DistinctBy(x => x.itemId)
                                      .ToList();
                        var itemsofferslist = (from off in entity.offers

                                               join itof in entity.itemsOffers on off.offerId equals itof.offerId // itemsOffers and offers 

                                               //  join iu in entity.itemsUnits on itof.iuId  equals  iu.itemUnitId //itemsUnits and itemsOffers
                                               join iu in entity.itemsUnits on itof.iuId equals iu.itemUnitId
                                               //from un in entity.units
                                               select new ItemSalePurModel()
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

                                   select new ItemSalePurModel()
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

                        foreach (var iunlist in itemsList)
                        {
                            if (iunlist.itemUnitId != null && iunlist.itemUnitId != 0)
                            {
                                int itemUnitId = (int)iunlist.itemUnitId.Value;
                                int count = getItemUnitAmount(itemUnitId, branchId);
                                iunlist.itemCount = count;
                            }
                            foreach (var row in unt)
                            {
                                if (row.itemId == iunlist.itemId)
                                {


                                    iunlist.unitName = row.unitName;
                                    iunlist.unitId = row.unitId;
                                    iunlist.price = row.price;
                                    iunlist.priceTax = iunlist.price + Calc.percentValue(row.price, iunlist.taxes);

                                }
                            }

                            // get set is new
                            // DateTime cmpdate = DateTime.Now.AddDays(newdays);

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
                        if (itemsList == null)
                            return NotFound();
                        else
                            return Ok(itemsList);
                    }
                    #endregion
                    #region items for sale
                    else if (defaultSale != 0)
                    {
                        unitPredicate = unitPredicate.Or(unit => unit.defaultSale == 1);
                 
                        var itemsList = (from I in entity.items.Where(searchPredicate)
                                         join u in entity.itemsUnits on I.itemId equals u.itemId
                                         join il in entity.itemsLocations on u.itemUnitId equals il.itemUnitId
                                         join l in entity.locations on il.locationId equals l.locationId
                                         join s in entity.sections.Where(x => x.branchId == branchId) on l.sectionId equals s.sectionId
                                         where il.quantity > 0 
                                         select new ItemSalePurModel()
                                         {
                                             itemId = I.itemId,
                                             name = I.name,
                                             code = I.code,
                                             categoryId = I.categoryId,
                                             categoryName = I.categories.name,
                                             max = I.max,
                                             maxUnitId = I.maxUnitId,
                                             minUnitId = I.minUnitId,
                                             min = I.min,

                                             parentId = I.parentId,
                                             isActive = I.isActive,
                                             image = I.image,
                                             type = I.type,
                                             details = I.details,
                                             taxes = I.taxes,
                                             createDate = I.createDate,
                                             updateDate = I.updateDate,
                                             createUserId = I.createUserId,
                                             updateUserId = I.updateUserId,
                                             isNew = 0,
                                            price = I.itemsUnits.Where(iu => iu.itemId == I.itemId && iu.defaultPurchase == 1).Select(iu => iu.price).FirstOrDefault(),
                                            itemUnitId = I.itemsUnits.Where(iu => iu.itemId == I.itemId && iu.defaultPurchase == 1).Select(iu => iu.itemUnitId).FirstOrDefault(),

                                         }).DistinctBy(x => x.itemId)
                                  .ToList();


                        var itemsofferslist = (from off in entity.offers

                                               join itof in entity.itemsOffers on off.offerId equals itof.offerId // itemsOffers and offers 

                                               //  join iu in entity.itemsUnits on itof.iuId  equals  iu.itemUnitId //itemsUnits and itemsOffers
                                               join iu in entity.itemsUnits on itof.iuId equals iu.itemUnitId
                                               //from un in entity.units
                                               select new ItemSalePurModel()
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

                                   select new ItemSalePurModel()
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

                        foreach (var iunlist in itemsList)
                        {
                            if (iunlist.itemUnitId != null && iunlist.itemUnitId != 0)
                            {
                                int itemUnitId = (int)iunlist.itemUnitId.Value;
                                int count = getItemUnitAmount(itemUnitId, branchId);
                                iunlist.itemCount = count;
                            }
                            foreach (var row in unt)
                            {
                                if (row.itemId == iunlist.itemId)
                                {


                                    iunlist.unitName = row.unitName;
                                    iunlist.unitId = row.unitId;
                                    iunlist.price = row.price;
                                    iunlist.priceTax = iunlist.price + Calc.percentValue(row.price, iunlist.taxes);

                                }
                            }

                            // get set is new
                           // DateTime cmpdate = DateTime.Now.AddDays(newdays);

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
                        if (itemsList == null)
                            return NotFound();
                        else
                            return Ok(itemsList);
                    }
                    #endregion
                    #region items for purchase
                    else if (defaultPurchase != 0)
                    {
                        unitPredicate = unitPredicate.Or(unit => unit.defaultPurchase == 1);
                        var itemsList = (from I in entity.items.Where(searchPredicate)
                                         join u in entity.itemsUnits on I.itemId equals u.itemId
                                         select new ItemModel()
                                         {
                                             itemId = I.itemId,
                                             name = I.name,
                                             code = I.code,
                                             categoryId = I.categoryId,
                                             categoryName = I.categories.name,
                                             max = I.max,
                                             maxUnitId = I.maxUnitId,
                                             minUnitId = I.minUnitId,
                                             min = I.min,

                                             parentId = I.parentId,
                                             isActive = I.isActive,
                                             image = I.image,
                                             type = I.type,
                                             details = I.details,
                                             taxes = I.taxes,
                                             createDate = I.createDate,
                                             updateDate = I.updateDate,
                                             createUserId = I.createUserId,
                                             updateUserId = I.updateUserId,
                                             isNew = 0,
                                             //price = u.price,

                                         }).DistinctBy(x => x.itemId)
                                       .ToList();

                        foreach(ItemModel itemL in itemsList)
                        {
                            int res = DateTime.Compare((DateTime)itemL.createDate, cmpdate);
                            if (res >= 0)
                            {
                                itemL.isNew = 1;
                            }
                        }
                        if (itemsList == null)
                            return NotFound();
                        else
                            return Ok(itemsList);
                    }
                    #endregion
                }
                return NotFound();
            }
            else
                return NotFound();
        }
        [HttpGet]
        [Route("GetItemsWichHasUnits")]
        public IHttpActionResult GetItemsWichHasUnits()
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
                    var itemsList = (from I in entity.items
                                        join u in entity.itemsUnits on I.itemId equals u.itemId
                                        select new ItemModel()
                                        {
                                            itemId = I.itemId,
                                            name = I.name,
                                            categoryId = I.categoryId,
                                            max = I.max,
                                            maxUnitId = I.maxUnitId,
                                            minUnitId = I.minUnitId,
                                            min = I.min,

                                            parentId = I.parentId,
                                            isActive = I.isActive,
                                            type = I.type,
                                            taxes = I.taxes,
                                            createDate = I.createDate,
                                            updateDate = I.updateDate,
                                            createUserId = I.createUserId,
                                            updateUserId = I.updateUserId,
                                            isNew = 0,

                                        }).Where(x => x.isActive == 1).Distinct()
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
        [HttpGet]
        [Route("GetItemsCodes")]
        public IHttpActionResult GetItemsCodes()
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
                    var itemsList = entity.items.Select (I =>  I.code ).ToList();

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
                      I.categoryId,
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
                    // get all sub categories of categoryId
                    List<categories> categoriesList = entity.categories
                     .ToList()
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
                    var result = Recursive(categoriesList, categoryId);
                    // end sub cat

                    var items = (from itm in entity.items
                                     join cat in entity.categories on itm.categoryId equals cat.categoryId
                                    
                                     select new ItemSalePurModel()
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

                                         parentName = entity.items.Where(x => x.itemId == itm.parentId).FirstOrDefault().name,
                                         minUnitName = entity.units.Where(x => x.unitId == itm.minUnitId).FirstOrDefault().name,
                                         maxUnitName = entity.units.Where(x => x.unitId == itm.minUnitId).FirstOrDefault().name,


                    isNew = 0,
                                          


    }).Where(p =>  categoriesId.Contains((int)p.categoryId)).ToList();

                    //.Where(t => categoriesId.Contains((int)t.categoryId))
                    // end test

                    //  set is new

                    DateTime cmpdate = DateTime.Now.AddDays(newdays);
                    bool canDelete;
                    foreach (var item in items)
                    {
                        canDelete = false;
                        if (item.isActive == 1)
                        {
                            int itemId = (int)item.itemId;
                            var childItemL = entity.items.Where(x => x.parentId == itemId).Select(b => new { b.itemId }).FirstOrDefault();
                            var itemsPropL = entity.itemsProp.Where(x => x.itemId == itemId).Select(b => new { b.itemPropId }).FirstOrDefault();
                            var itemUnitsL = entity.itemsUnits.Where(x => x.itemId == itemId).Select(b => new { b.itemUnitId }).FirstOrDefault();
                            string itemType = item.type;
                            int isInInvoice = 0;
                            int isInLocation = 0;
                            if (itemType == "p" && itemUnitsL != null)
                            {
                                isInInvoice = entity.itemsTransfer.Where(x => x.itemUnitId == itemUnitsL.itemUnitId).Select(x => x.itemsTransId).FirstOrDefault();
                                isInLocation = entity.itemsLocations.Where(x => x.itemUnitId == itemUnitsL.itemUnitId).Select(x => x.itemsLocId).FirstOrDefault();

                            }
                            //var itemLocationsL = entity.itemsLocations.Where(x => x.itemId == itemId).Select(b => new { b.itemsLocId }).FirstOrDefault();
                            var itemsMaterials = entity.itemsMaterials.Where(x => x.itemId == itemId).Select(b => new { b.itemMatId }).FirstOrDefault();
                            var serials = entity.serials.Where(x => x.itemId == itemId).Select(b => new { b.serialId }).FirstOrDefault();


                            if ((childItemL is null) && (itemsPropL is null) && ((itemUnitsL is null && !itemType.Equals("p")) || (isInInvoice == 0 && itemType.Equals("p") && isInLocation == 0))
                                && (itemsMaterials is null) && (serials is null))
                                canDelete = true;
                        }
                        item.canDelete = canDelete;
                        int res = DateTime.Compare((DateTime)item.createDate, cmpdate);
                        if (res >= 0)
                        {
                            item.isNew = 1;
                        }



                    }

                    //  if (itemsunit == null)
                    //if (itemsofferslist == null)
                    if (items == null)
                        return NotFound();
                    else
                        return Ok(items);


                }

            }
            else
            {
                return NotFound();
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
        public IHttpActionResult Save(string itemObject)
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
                    items itemModel;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var ItemEntity = entity.Set<items>();
                        if (itemObj.itemId == 0)
                        {
                            ProgramInfo programInfo = new ProgramInfo();
                            int itemMaxCount = programInfo.getItemCount();
                            int itemsCount = entity.items.Count();
                            if (itemsCount >= itemMaxCount)
                            {
                                return Ok(-1);
                            }
                            else
                            {
                                itemObj.createDate = DateTime.Now;
                                itemObj.updateDate = DateTime.Now;
                                itemObj.updateUserId = itemObj.createUserId;

                                itemModel = ItemEntity.Add(itemObj);
                                entity.SaveChanges();
                                return Ok(itemObj.itemId);
                            }
                        }
                        else
                        {
                            itemModel = entity.items.Where(p => p.itemId == itemObj.itemId).First();
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
                            entity.SaveChanges();
                            return Ok(itemModel.itemId);
                        }                      
                    }
                }
                catch
                {
                    return Ok(0);
                }
            }
            return NotFound();
        }
        [HttpPost]
        [Route("Delete")]
        public Boolean Delete(int itemId, int userId,Boolean final)
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
                            return true;
                        }
                    }
                    catch
                    {
                        return false;
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
                            return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            else
                return false;
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

        [Route("PostItemImage")]
        public IHttpActionResult PostItemImage()
        {

            try
            {
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    string imageName = postedFile.FileName;
                    string imageWithNoExt = Path.GetFileNameWithoutExtension(postedFile.FileName);

                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png", ".bmp", ".jpeg", ".tiff",".jfif" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();

                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png, .jfif, .bmp , .jpeg ,.tiff");
                            return Ok(message);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {
                            var message = string.Format("Please Upload a file upto 1 mb.");

                            return Ok(message);
                        }
                        else
                        {                           
                            //  check if image exist
                            var pathCheck = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\item"), imageWithNoExt);
                            var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\item"), imageWithNoExt + ".*");
                            if (files.Length > 0)
                            {
                                 File.Delete(files[0]);
                            }

                            //Userimage myfolder name where i want to save my image
                            var filePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\item"), imageName);
                            postedFile.SaveAs(filePath);

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Ok(message1);
                }
                var res = string.Format("Please Upload a image.");

                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");

                return Ok(res);
            }
        }

        [HttpGet]
        [Route("GetImage")]
        public HttpResponseMessage GetImage(string imageName)
        {
            if (String.IsNullOrEmpty(imageName))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            string localFilePath;

            localFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\item"), imageName);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = imageName;

            return response;
        }
        [HttpPost]
        [Route("UpdateImage")]
        public int UpdateImage(string itemObject)
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
            if (valid)
            {
                try
                {
                    items item;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var itemEntity = entity.Set<items>();
                        item = entity.items.Where(p => p.itemId == itemObj.itemId).First();
                        item.image = itemObj.image;
                        entity.SaveChanges();
                    }
                    return item.itemId;
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
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

                                     select new ItemSalePurModel()
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
                                           select new ItemSalePurModel()
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

                               select new ItemSalePurModel()
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
                                iunlist.priceTax = iunlist.price + Calc.percentValue(row.price, iunlist.taxes);

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
                                     select new ItemSalePurModel()
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

        // get all items where defaultSale is 1 and set isNew=1 if new item  and set isOffer=1 if Has Active Offer 
        //by category and its sub categories
        #region
        [HttpGet]
        [Route("GetSaleItemsByCategory")]
        public IHttpActionResult GetSaleItemsByCategory(int categoryId)
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
                    var result = Recursive(categoriesList, categoryId);
                    // end sub cat




                    var itemsunit = (from itm in entity.items
                                     join cat in entity.categories on itm.categoryId equals cat.categoryId
                                     //  join itun in entity.itemsUnits on itm.itemId equals itun.itemId 
                                     //   join untb in entity.units on itun.unitId equals untb.unitId

                                     select new ItemSalePurModel()
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

                                     }).Where(t => categoriesId.Contains((int)t.categoryId)).ToList();

                    var itemsofferslist = (from off in entity.offers

                                           join itof in entity.itemsOffers on off.offerId equals itof.offerId // itemsOffers and offers 

                                           //  join iu in entity.itemsUnits on itof.iuId  equals  iu.itemUnitId //itemsUnits and itemsOffers
                                           join iu in entity.itemsUnits on itof.iuId equals iu.itemUnitId
                                           //from un in entity.units
                                           select new ItemSalePurModel()
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

                               select new ItemSalePurModel()
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
                                iunlist.priceTax = iunlist.price + Calc.percentValue(row.price, iunlist.taxes);

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
        //by category and its sub categories
        #region
        [HttpGet]
        [Route("GetPurItemsByCategory")]
        public IHttpActionResult GetPurItemsByCategory(int categoryId)
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
                    var result = Recursive(categoriesList, categoryId);
                    // end sub cat

                    var itemsunit = (from itm in entity.items
                                     join cat in entity.categories on itm.categoryId equals cat.categoryId
                                     join itun in entity.itemsUnits on itm.itemId equals itun.itemId
                                     join untb in entity.units on itun.unitId equals untb.unitId
                                     select new ItemSalePurModel()
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
                                     }).Where(p => p.defaultPurchase == 1 && categoriesId.Contains((int)p.categoryId)).ToList();

                    //.Where(t => categoriesId.Contains((int)t.categoryId))
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
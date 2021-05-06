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
    [RoutePrefix("api/ItemsOffers")]
    public class ItemsOffersController : ApiController
    {
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
                                     
                                     select new ItemOfferModel()
                                     {
                                         itemId = itm.itemId,
                                         name = itm.name,
                                         code = itm.code,
                                        image = itm.image,
                                        details=itm.details,
                                        type=itm.type,
                                        createUserId=itm.createUserId,
                                        updateUserId=itm.updateUserId,
                                        updateDate=itm.updateDate,

                                         categoryId = itm.categoryId,
                                         categoryName = cat.name,
                                        
                                         max = itm.max,
                                         maxUnitId = itm.maxUnitId,
                                         minUnitId = itm.minUnitId,
                                         min = itm.min,
                                         
                                         parentId = itm.parentId,
                                         isActive = itm.isActive,
                                         taxes=itm.taxes,
                                         isOffer = 0,
                                         desPrice = 0,
                                         isNew=0,
                                         offerName = "",
                                         createDate =  itm.createDate ,
                                         
                                     }).ToList();

                    var itemsofferslist = (from off in entity.offers

                                           join itof in entity.itemsOffers on off.offerId equals itof.offerId // itemsOffers and offers 

                                           //  join iu in entity.itemsUnits on itof.iuId  equals  iu.itemUnitId //itemsUnits and itemsOffers
                                           join iu in entity.itemsUnits on itof.iuId equals iu.itemUnitId
                                           //from un in entity.units
                                           select new ItemOfferModel()
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
                                               defaultSale=iu.defaultSale,

                                           }).Where(IO => IO.isActiveOffer == 1 && DateTime.Compare((DateTime)IO.startDate, DateTime.Now) <= 0 && System.DateTime.Compare((DateTime)IO.endDate, DateTime.Now) >= 0 && IO.defaultSale == 1).Distinct().ToList();
                    //.Where(IO => IO.isActiveOffer == 1 && DateTime.Compare(IO.startDate,DateTime.Now)<0 && System.DateTime.Compare(IO.endDate, DateTime.Now) > 0).ToList();
                    
                    // test

                    var unt = (from unitm in entity.itemsUnits
                               join untb in entity.units on unitm.unitId equals untb.unitId
                               join itemtb in entity.items on unitm.itemId equals itemtb.itemId

                               select new ItemOfferModel()
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
                                   price = unitm.price ,
                                 
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
                                iunlist.priceTax = iunlist.price + ( row.price * iunlist.taxes / 100);
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

                                    totaldis = totaldis + (iunlist.price * iunlist.discountValue / 100);

                                }



                            }
                        }
                        iunlist.desPrice = iunlist.priceTax  - totaldis;
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
                                     select new ItemOfferModel()
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
                                        
                                         defaultPurchase=itun.defaultPurchase,
                                         unitId = itun.unitId,

                                         price=itun.price,
                                       unitName = untb.name,
                                       itemUnitId=itun.itemUnitId,
                                     }).Where(p => p.defaultPurchase==1).OrderBy(a=> a.itemId).ToList();


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
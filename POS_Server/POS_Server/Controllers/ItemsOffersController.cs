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
                    var ioList = entity.itemsOffers

                   .Select(c => new ItemOfferModel() {
                    iuId=   c.iuId,
                       offerId= c.offerId,

                       ioId= c.ioId,
                       createUserId= c.createUserId,
                       updateUserId=  c.updateUserId,
                       createDate=   c.createDate,
                       updateDate=   c.updateDate,


                   })
                   .ToList();

                    if (ioList == null)
                        return NotFound();
                    else
                        return Ok(ioList);
                }
            }
            //else
            return NotFound();
        }
       

        #region
        [HttpPost]
        [Route("UpdateItemsByOfferId")]

        public int UpdateItemsByOfferId( string  newitoflist)
        {
            int offerId = 0;
               var re = Request;
            var headers = re.Headers;
            int res = 0;
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
            newitoflist = newitoflist.Replace("\\", string.Empty);
            newitoflist = newitoflist.Trim('"');
            List<itemsOffers> newitofObj = JsonConvert.DeserializeObject<List<itemsOffers>>(newitoflist, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var iuoffer= entity.itemsOffers.Where(p => p.offerId == offerId);
                 if(iuoffer.Count()> 0)
                    {
                    entity.itemsOffers.RemoveRange(iuoffer);
                    }
                    if (newitofObj.Count() > 0)
                    {
                        foreach (itemsOffers newitofrow in newitofObj)
                        {
                            newitofrow.offerId = offerId;
                            if (newitofrow.createDate == null)
                            {
                            newitofrow.createDate = DateTime.Now;
                            newitofrow.updateDate = DateTime.Now;
                                newitofrow.updateUserId = newitofrow.createUserId;
                            }
                            else
                            {
                                newitofrow.updateDate = DateTime.Now;
                            }
                           
                       


                        }
                        entity.itemsOffers.AddRange(newitofObj);
                    }
                  res  =entity.SaveChanges();
                  
                        return res;
                                    

                }

            }
            else
            {
                return -1;
            }

        }
        #endregion


        #region
        [HttpGet]
        [Route("GetItemsByOfferId")]

        public IHttpActionResult GetItemsByOfferId(int offerId, List<ItemOfferModel> newitoflist)
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
                    var iuoffer = (from itofr in entity.itemsOffers
                                   join itunit in entity.itemsUnits on itofr.iuId equals itunit.itemUnitId
                                   join item in entity.items on itunit.itemId equals item.itemId
                                   join ofr in entity.offers on itofr.offerId equals ofr.offerId
                                   select new ItemOfferModel()
                                   {
                                       offerId = itofr.offerId,
                                    //   offerName = ofr.name,
                                     //  itemUnitId = itunit.itemUnitId,
                                      // itemId = item.itemId,
                                      // unitId = itunit.unitId,
                                       // unitName = itun.name,
                                     //  name = item.name,
                                       //code = item.code,
                                   }).Where(p => p.offerId == offerId).ToList();


                    if (iuoffer == null)
                        return NotFound();
                    else
                        return Ok(iuoffer);


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
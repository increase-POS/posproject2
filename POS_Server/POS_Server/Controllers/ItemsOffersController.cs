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
            int userId=0;
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
            if (headers.Contains("userId"))
            {
                userId = Convert.ToInt32(headers.GetValues("userId").First());
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
                           
                            if (newitofrow.createUserId == null || newitofrow.createUserId ==0 )
                            {
                            newitofrow.createDate = DateTime.Now;
                            newitofrow.updateDate = DateTime.Now;
                            
                                newitofrow.createUserId = userId;
                                newitofrow.updateUserId =userId;
                            }
                            else
                            {
                                newitofrow.updateDate = DateTime.Now;
                                newitofrow.updateUserId = userId;

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

        public IHttpActionResult GetItemsByOfferId( )
        {
            int offerId = 0;
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

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var iuoffer = (from itofr in entity.itemsOffers
                                   join itunit in entity.itemsUnits on itofr.iuId equals itunit.itemUnitId
                                   join item in entity.items on itunit.itemId equals item.itemId
                                   join ofr in entity.offers on itofr.offerId equals ofr.offerId
                                   join un in entity.units on itunit.unitId equals un.unitId
                                   select new ItemOfferModel()
                                   {
                                       offerId = itofr.offerId,
                                       offerName = ofr.name,
                                       
                                       unitId=un.unitId,
                                       unitName = un.name,
                                       itemId = item.itemId,
                                       itemName = item.name,
                                       iuId = itunit.itemUnitId,
                                       quantity= itofr.quantity,
                                       createDate = itofr.createDate,
                                       updateDate= itofr.updateDate,
                                       createUserId= itofr.createUserId,
                                       updateUserId= itofr.updateUserId,
                     
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
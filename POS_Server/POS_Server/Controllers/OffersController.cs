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
    [RoutePrefix("api/Offers")]
    public class OffersController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
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

            if (valid) // APIKey is valid
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var offersList = entity.offers
                    .Select(L => new OfferModel
                    {
                       offerId= L.offerId,
                        name = L.name,
                        code = L.code,
                        isActive=L.isActive,
                        discountType= L.discountType,
                        discountValue= L.discountValue,
                        startDate=L.startDate,
                        endDate= L.endDate,
                        createDate=L.createDate,
                        updateDate=L.updateDate,
                        createUserId=  L.createUserId,
                        updateUserId= L.updateUserId,
                        notes=L.notes,
                    })
                    .ToList();

                    if (offersList.Count > 0)
                    {
                        for (int i = 0; i < offersList.Count; i++)
                        {
                            if (offersList[i].isActive == 1)
                            {
                                int offerId = (int)offersList[i].offerId;
                                var offerItems = entity.itemsOffers.Where(x => x.offerId == offerId).Select(b => new { b.offerId }).FirstOrDefault();
                               
                                if (offerItems is null) 
                                    canDelete = true;
                            }
                            offersList[i].canDelete = canDelete;
                        }
                    }
                    if (offersList == null)
                        return NotFound();
                    else
                        return Ok(offersList);
                }
            }
            //else
            return NotFound();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetOfferByID")]
        public IHttpActionResult GetOfferByID(int offerId)
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
                    var offer = entity.offers
                   .Where(u => u.offerId == offerId)
                   .Select(L => new
                   {
                       L.offerId,
                       L.name,
                       L.code,
                       L.isActive,
                       L.discountType,
                       L.discountValue,
                       L.startDate,
                       L.endDate,
                       L.createDate,
                       L.updateDate,
                       L.createUserId,
                       L.updateUserId,
                       L.notes,
                   })
                   .FirstOrDefault();

                    if (offer == null)
                        return NotFound();
                    else
                        return Ok(offer);
                }
            }
            else
                return NotFound();
        }

        // add or update offer
        [HttpPost]
        [Route("Save")]
        public string Save(string offerObject)
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
                offerObject = offerObject.Replace("\\", string.Empty);
                offerObject = offerObject.Trim('"');
                offers newObject = JsonConvert.DeserializeObject<offers>(offerObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var offerEntity = entity.Set<offers>();
                        if (newObject.offerId == 0)
                        {
                            offerEntity.Add(newObject);
                            message = "Offer Is Added Successfully";
                        }
                        else
                        {
                            var oldObject = entity.offers.Where(p => p.offerId == newObject.offerId).FirstOrDefault();
                            oldObject.name = newObject.name;
                            oldObject.code = newObject.code;
                            oldObject.discountType = newObject.discountType;
                            oldObject.discountValue = newObject.discountValue;
                            oldObject.startDate = newObject.startDate;
                            oldObject.endDate = newObject.endDate;
                            oldObject.updateDate = newObject.updateDate;
                            oldObject.updateUserId = newObject.updateUserId;
                            oldObject.notes = newObject.notes;

                            message = "Offer Is Updated Successfully";
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
        public IHttpActionResult Delete(int offerId, int userId, Boolean final)
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
                            offers offerObj = entity.offers.Find(offerId);

                            entity.offers.Remove(offerObj);
                            entity.SaveChanges();

                            return Ok("Offer is Deleted Successfully");
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
                            offers offerObj = entity.offers.Find(offerId);

                            offerObj.isActive = 0;
                            offerObj.updateUserId = userId;
                            offerObj.updateDate = DateTime.Now;
                            entity.SaveChanges();

                            return Ok("Offer is Deleted Successfully");
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
    }
}
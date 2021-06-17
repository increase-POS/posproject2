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
    [RoutePrefix("api/cards")]
    public class CardController : ApiController
    {
        // GET api/<controller> get all cards
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
                    var cardsList = entity.cards
                  
                   .Select(c => new CardModel() {
                   cardId=c.cardId,
                   name= c.name,
                   notes = c.notes,
                   createDate =c.createDate,
                   updateDate = c.updateDate,
                   createUserId = c.createUserId,
                   updateUserId=  c.updateUserId,
                    isActive=c.isActive,  
                })
                   .ToList();

                    // can delet or not
                    if (cardsList.Count > 0)
                    {
                        foreach(CardModel carditem  in cardsList)
                        {
                            canDelete = false;
                            if (carditem.isActive == 1)
                            {
                                int cId = (int)carditem.cardId;
                                var casht = entity.cashTransfer.Where(x => x.cardId == cId).Select(x => new { x.cardId }).FirstOrDefault();
                      
                                if ((casht is null) )
                                    canDelete = true;
                            }
                            carditem.canDelete = canDelete;
                        }
                    }

                    if (cardsList == null)
                        return NotFound();
                    else
                        return Ok(cardsList);
                }
            }
            //else
                return NotFound();
        }



        // GET api/<controller>  Get card By ID 
        [HttpGet]
        [Route("GetcardByID")]
        public IHttpActionResult GetcardByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int cId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("cardId"))
            {
                cId = Convert.ToInt32(headers.GetValues("cardId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var card = entity.cards
                   .Where(c => c.cardId == cId)
                   .Select(c => new {
                     c.cardId,
                     c.name,
                     c.notes,
                     c.createDate,
                     c.updateDate,
                     c.createUserId,
                     c.updateUserId,
                       c.isActive,
                      
                   })
                   .FirstOrDefault();

                    if (card == null)
                        return NotFound();
                    else
                        return Ok(card);
                }
            }
            else
                return NotFound();
        }

   


    
        // GET api/<controller>  Get card By is active
        [HttpGet]
        [Route("GetByisActive")]
        public IHttpActionResult GetByisActive(byte isActive)
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
                    var card = entity.cards
                   .Where(c => c.isActive == isActive)
                   .Select(c => new {
                       c.cardId,
                       c.name,
                       c.notes,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,
                       c.isActive,
                   })
                   .ToList();

                    if (card == null)
                        return NotFound();
                    else
                        return Ok(card);
                }
            }
            else
                return NotFound();
        }


        // add or update card 
        [HttpPost]
        [Route("Save")]
        public bool Save(string cardObject)
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
                cardObject = cardObject.Replace("\\", string.Empty);
                cardObject = cardObject.Trim('"');
                cards Object = JsonConvert.DeserializeObject<cards>(cardObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var cardEntity = entity.Set<cards>();
                        if (Object.cardId == 0)
                        {

                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            cardEntity.Add(Object);
                          //  message = "card Is Added Successfully";
                        }
                        else
                        {

                            var tmpcard = entity.cards.Where(p => p.cardId == Object.cardId).FirstOrDefault();

                          
                            tmpcard.cardId = Object.cardId;
                            tmpcard.name = Object.name;
                            tmpcard.notes = Object.notes;
                            tmpcard.createDate = Object.createDate;
                            tmpcard.updateDate = Object.updateDate;
                            tmpcard.createUserId = Object.createUserId;
                            tmpcard.updateUserId = Object.updateUserId;
                            tmpcard.isActive = Object.isActive;
                            tmpcard.updateDate = DateTime.Now;// server current date;
                            tmpcard.updateUserId = Object.updateUserId;
                            


                            //message = "card Is Updated Successfully";
                        }
                        entity.SaveChanges();
                    }
                    return true;
                }

                catch
                {
                    return false;
                }
            }
            else
                return false;
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int cardId, int userId, Boolean final)
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
                            cards cardObj = entity.cards.Find(cardId);

                            entity.cards.Remove(cardObj);
                            entity.SaveChanges();

                            return Ok("card is Deleted Successfully");
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
                            cards cardObj = entity.cards.Find(cardId);

                            cardObj.isActive = 0;
                            cardObj.updateUserId = userId;
                            cardObj.updateDate = DateTime.Now;
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
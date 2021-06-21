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
    [RoutePrefix("api/bonds")]
    public class BondsController : ApiController
    {
        // GET api/<controller> get all bonds
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
                    var bondsList = entity.bondes
                  
                   .Select(c => new BondsModel() {
                    bondId=c.bondId,
                    number=c.number,
                    amount=c.amount ,
                    deserveDate=c.deserveDate,
                    type=c.type,
                    isRecieved=c. isRecieved,
                   notes = c.notes,

                   createDate =c.createDate,
                   updateDate = c.updateDate,
                   createUserId = c.createUserId,
                   updateUserId=  c.updateUserId,
                    isActive=c.isActive,
                       cashTransId= c.cashTransId,
                   })
                   .ToList();

                    // can delet or not
                    if (bondsList.Count > 0)
                    {
                        foreach(BondsModel bonditem  in bondsList)
                        {
                            canDelete = false;
                            if (bonditem.isActive == 1)
                            {
                                int cId = (int)bonditem.bondId;
                                var casht = entity.cashTransfer.Where(x => x.bondId == cId).Select(x => new { x.bondId }).FirstOrDefault();
                      
                                if ((casht is null) )
                                    canDelete = true;
                            }
                            bonditem.canDelete = canDelete;
                        }
                    }
                    /*
       * 
bondId 
number 
amount 
deserveDate 
type 
isRecieved 
notes 
createUserId 
updateUserId 
updateDate 
createDate 
canDelete 
       * */
                    if (bondsList == null)
                        return NotFound();
                    else
                        return Ok(bondsList);
                }
            }
            //else
                return NotFound();
        }



        // GET api/<controller>  Get card By ID 
        [HttpGet]
        [Route("GetbondByID")]
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
            if (headers.Contains("bondId"))
            {
                cId = Convert.ToInt32(headers.GetValues("bondId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var bond = entity.bondes
                   .Where(c => c.bondId == cId)
                   .Select(c => new {
                        c.bondId,
                        c.number,
                        c.amount,
                        c.deserveDate,
                        c.type,
                        c.isRecieved,
                        c.notes,
                        c.createDate,
                        c.updateDate,
                        c.createUserId,
                        c.updateUserId,
                        c.isActive,
                      c.cashTransId,

                   })
                   .FirstOrDefault();

      

                    if (bond == null)
                        return NotFound();
                    else
                        return Ok(bond);
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
                    var card = entity.bondes
                   .Where(c => c.isActive == isActive)
                   .Select(c => new {
                       c.bondId,
                       c.number,
                       c.amount,
                       c.deserveDate,
                       c.type,
                       c.isRecieved,
                       c.notes,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,
                       c.isActive,
                     c.cashTransId,
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
        public string Save(string bondObject)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
           string  message = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            
            if (valid)
            {
                bondObject = bondObject.Replace("\\", string.Empty);
                bondObject = bondObject.Trim('"');
                bondes Object = JsonConvert.DeserializeObject<bondes>(bondObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var bondEntity = entity.Set<bondes>();
                        if (Object.bondId == 0 || Object.bondId == null)
                        {

                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            bondEntity.Add(Object);
                            entity.SaveChanges();
                            message = Object.bondId.ToString();
                        }
                        else
                        {

                            var tmpbond = entity.bondes.Where(p => p.bondId == Object.bondId).FirstOrDefault();
              
                    tmpbond.bondId = Object.bondId;
                    tmpbond.number = Object.number;
                    tmpbond.amount = Object.amount ;
                    tmpbond.deserveDate = Object.deserveDate;
                    tmpbond.type = Object.type;
                    tmpbond.isRecieved = Object.isRecieved;
                    tmpbond.notes = Object.notes;
                    tmpbond.createDate = Object.createDate;
                    tmpbond.updateDate = DateTime.Now;// server current date;
                    tmpbond.createUserId = Object.createUserId;
                    tmpbond.updateUserId = Object.updateUserId;
                    tmpbond.isActive = Object.isActive;
                            tmpbond.cashTransId = Object.cashTransId;

                            //message = "card Is Updated Successfully";
                    entity.SaveChanges();
                    message = tmpbond.bondId.ToString();
                  
                        }
                       
                      
                    }
                    return message;
                }

                catch
                {
                    return "-1";
                }
            }
            else
                return "-1";
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int bondId, int userId, Boolean final)
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
                            bondes bondObj = entity.bondes.Find(bondId);

                            entity.bondes.Remove(bondObj);
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
                            bondes Obj = entity.bondes.Find(bondId);

                            Obj.isActive = 0;
                            Obj.updateUserId = userId;
                            Obj.updateDate = DateTime.Now;
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
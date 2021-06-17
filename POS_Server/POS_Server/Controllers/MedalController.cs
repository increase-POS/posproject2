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
    [RoutePrefix("api/medal")]
    public class MedalController : ApiController
    {
        // GET api/<controller> get all medals
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
                    var medalsList = entity.medals
                  
                   .Select(c => new MedalModel() {
                   medalId=c.medalId,
                  
                      name=c.name,
                      isActive=c.isActive,
                      notes=c.notes,
                      createUserId=c.createUserId,
                      updateUserId=c.updateUserId,
                      createDate=c.createDate,
                      updateDate=c.updateDate,
                      
                   })
                   .ToList();

                    /*
                     * 
                      medalId 
                      name 
                      isActive 
                      notes 
                      createUserId 
                      updateUserId 
                      createDate 
                      updateDate
                     * */
                    // can delet or not
                    if (medalsList.Count > 0)
                    {
                        foreach(MedalModel medalitem  in medalsList)
                        {
                            canDelete = false;
                            if (medalitem.isActive == 1)
                            {
                                int cId = (int)medalitem.medalId;
                                var casht = entity.medalAgent.Where(x => x.medalId == cId).Select(x => new { x.medalId }).FirstOrDefault();
                      
                                if ((casht is null) )
                                    canDelete = true;
                            }
                            medalitem.canDelete = canDelete;
                        }
                    }

                    if (medalsList == null)
                        return NotFound();
                    else
                        return Ok(medalsList);
                }
            }
            //else
                return NotFound();
        }



        // GET api/<controller>  Get medal By ID 
        [HttpGet]
        [Route("GetmedalByID")]
        public IHttpActionResult GetmedalByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int cId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("medalId"))
            {
                cId = Convert.ToInt32(headers.GetValues("medalId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var medal = entity.medals
                   .Where(c => c.medalId == cId)
                   .Select(c => new {
                   c.medalId,
                   c.name,
                   c.isActive,
                   c.notes,
                   c.createUserId,
                   c.updateUserId,
                   c.createDate,
                   c.updateDate,
                     

                   })
                   .FirstOrDefault();

                    if (medal == null)
                        return NotFound();
                    else
                        return Ok(medal);
                }
            }
            else
                return NotFound();
        }

   


    
        // GET api/<controller>  Get medal By is active
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
                    var medal = entity.medals
                   .Where(c => c.isActive == isActive)
                   .Select(c => new {
                       c.medalId,
                       c.name,
                       c.isActive,
                       c.notes,
                       c.createUserId,
                       c.updateUserId,
                       c.createDate,
                       c.updateDate,
                   })
                   .ToList();

                    if (medal == null)
                        return NotFound();
                    else
                        return Ok(medal);
                }
            }
            else
                return NotFound();
        }


        // add or update medal 
        [HttpPost]
        [Route("Save")]
        public bool Save(string medalObject)
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
                medalObject = medalObject.Replace("\\", string.Empty);
                medalObject = medalObject.Trim('"');
                medals Object = JsonConvert.DeserializeObject<medals>(medalObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var medalEntity = entity.Set<medals>();
                        if (Object.medalId == 0)
                        {

                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            medalEntity.Add(Object);
                          //  message = "medal Is Added Successfully";
                        }
                        else
                        {

                            var tmpmedal = entity.medals.Where(p => p.medalId == Object.medalId).FirstOrDefault();

                          
                            tmpmedal.medalId = Object.medalId;

                            tmpmedal.name = Object.name;
                    
                            tmpmedal.notes = Object.notes; 
                    

                            tmpmedal.createDate = Object.createDate;
                            tmpmedal.updateDate = Object.updateDate;
                            tmpmedal.createUserId = Object.createUserId;
                            tmpmedal.updateUserId = Object.updateUserId;
                            tmpmedal.isActive = Object.isActive;
                            tmpmedal.updateDate = DateTime.Now;// server current date;
                            tmpmedal.updateUserId = Object.updateUserId;
                            


                            //message = "medal Is Updated Successfully";
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
        public IHttpActionResult Delete(int medalId, int userId, Boolean final)
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
                            medals medalObj = entity.medals.Find(medalId);

                            entity.medals.Remove(medalObj);
                            entity.SaveChanges();

                            return Ok("medal is Deleted Successfully");
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
                            medals medalObj = entity.medals.Find(medalId);

                            medalObj.isActive = 0;
                            medalObj.updateUserId = userId;
                            medalObj.updateDate = DateTime.Now;
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
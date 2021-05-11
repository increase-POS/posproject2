using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/servicesCosts")]
    public class servicesCostsController : ApiController
    {
        // GET api/<controller>
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
                    var servicesList = entity.servicesCosts
                        .Where(S => S.itemId == itemId)
                    .Select(S => new
                    {
                        S.costId,
                        S.name,
                        S.itemId,
                        S.costVal,
                        S.createDate,
                        S.updateDate,
                        S.updateUserId,
                        S.createUserId
                    })
                    .ToList();

                    if (servicesList == null)
                        return NotFound();
                    else
                        return Ok(servicesList);
                }
            }
            //else
            return NotFound();
        }
        // add or update location
        [HttpPost]
        [Route("Save")]
        public string Save(string serviceObject)
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
                serviceObject = serviceObject.Replace("\\", string.Empty);
                serviceObject = serviceObject.Trim('"');
                servicesCosts newObject = JsonConvert.DeserializeObject<servicesCosts>(serviceObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var serviceEntity = entity.Set<servicesCosts>();
                        if (newObject.costId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;

                            serviceEntity.Add(newObject);
                            message = "Service Is Added Successfully";
                        }
                        else
                        {
                            var tmpSerial = entity.servicesCosts.Where(p => p.costId == newObject.costId).FirstOrDefault();
                            tmpSerial.name = newObject.name;
                            tmpSerial.costVal = newObject.costVal;
                            tmpSerial.updateDate = DateTime.Now;
                            tmpSerial.updateUserId = newObject.updateUserId;

                            message = "Service Is Updated Successfully";
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
        public IHttpActionResult Delete(int costId)
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
                        servicesCosts serviceObj = entity.servicesCosts.Find(costId);

                        entity.servicesCosts.Remove(serviceObj);
                        entity.SaveChanges();
                        return Ok("Service is Deleted Successfully");
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
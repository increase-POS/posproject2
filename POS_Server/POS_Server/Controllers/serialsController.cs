using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/serials")]
    public class serialsController : ApiController
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
                    var serialsList = entity.serials
                        .Where(S=> S.itemId == itemId)
                    .Select(S => new
                    {
                        S.serialId,
                        S.itemId,
                        S.serialNum,
                        S.isActive,
                    })
                    .ToList();

                    if (serialsList == null)
                        return NotFound();
                    else
                        return Ok(serialsList);
                }
            }
            //else
            return NotFound();
        }
        // add or update location
        [HttpPost]
        [Route("Save")]
        public string Save(string serialObject)
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
                serialObject = serialObject.Replace("\\", string.Empty);
                serialObject = serialObject.Trim('"');
                serials newObject = JsonConvert.DeserializeObject<serials>(serialObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var serialEntity = entity.Set<serials>();
                        if (newObject.serialId == 0)
                        {


                            serialEntity.Add(newObject);
                            message = "Serial Is Added Successfully";
                        }
                        else
                        {
                            var tmpSerial = entity.serials.Where(p => p.serialId == newObject.serialId).FirstOrDefault();
                            tmpSerial.itemId = newObject.itemId;
                            tmpSerial.serialNum = newObject.serialNum;

                            message = "Serial Is Updated Successfully";
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
        public IHttpActionResult Delete(int serialId)
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
                        serials serialObj = entity.serials.Find(serialId);

                        serialObj.isActive = 0;
                        entity.SaveChanges();

                        return Ok("Serial is Deleted Successfully");
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Properties")]
    public class PropertiesController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
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
                    var propertiesList = entity.properties.Select(p => new {
                        p.propertyId,
                        p.name,
                        p.createDate,
                        p.createUserId,
                        p.updateDate,
                        p.updateUserId,
                    })
                    .ToList();

                    if (propertiesList == null)
                        return NotFound();
                    else
                        return Ok(propertiesList);
                }
            }
            return NotFound();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetPropertyByID")]
        public IHttpActionResult GetPropertyByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int propertyId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("propertyId"))
            {
                propertyId = Convert.ToInt32(headers.GetValues("propertyId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var property = entity.properties
                   .Where(p => p.propertyId == propertyId)
                   .Select(p => new {
                       p.propertyId,
                       p.name,
                       p.createDate,
                       p.createUserId,
                       p.updateDate,
                       p.updateUserId,
                   })
                   .FirstOrDefault();

                    if (property == null)
                        return NotFound();
                    else
                        return Ok(property);
                }
            }
            else
                return NotFound();
        }

        // add or update property
        [HttpPost]
        [Route("Save")]
        public string Save()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string jsonObject = "";
            string message = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("propertyObject"))
            {
                jsonObject = headers.GetValues("propertyObject").First();
                jsonObject = jsonObject.Replace("\\", string.Empty);
                jsonObject = jsonObject.Trim('"');
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            properties propertyObject = JsonConvert.DeserializeObject<properties>(jsonObject);
            if (valid)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var propEntity = entity.Set<properties>();
                        if (propertyObject.propertyId == 0)
                        {
                            propEntity.Add(propertyObject);
                            message = "Property Is Added Successfully";
                        }
                        else
                        {
                            var tmpProperty = entity.properties.Where(p => p.propertyId == propertyObject.propertyId).FirstOrDefault();
                            tmpProperty.name = propertyObject.name;
                            tmpProperty.updateDate = propertyObject.updateDate;
                            tmpProperty.updateUserId = propertyObject.updateUserId;

                            message = "Property Is Updated Successfully";
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
        public IHttpActionResult Delete()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int propertyId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("propertyId"))
            {
                propertyId = Convert.ToInt32(headers.GetValues("propertyId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            if (valid)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {                        
                            properties PropertDelete = entity.properties.Find(propertyId);
                            entity.properties.Remove(PropertDelete);
                            entity.SaveChanges();
                            return Ok("Property is Deleted Successfully");
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
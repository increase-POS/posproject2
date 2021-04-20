using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/propertiesItems")]
    public class propertiesItemsController : ApiController
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
                    var propertiesList = entity.propertiesItems.Select(p => new {
                        p.propertyItemId,
                        p.propertyId,
                        p.name,
                        p.isDefault,
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
        [Route("GetPropItemByID")]
        public IHttpActionResult GetPropItemByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int propItemId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("propertyItemId"))
            {
                propItemId = Convert.ToInt32(headers.GetValues("propertyItemId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var propertyItems = entity.propertiesItems
                   .Where(p => p.propertyItemId == propItemId)
                   .Select(p => new {
                       p.propertyItemId,
                       p.propertyId,
                       p.name,
                       p.isDefault,
                       p.createDate,
                       p.createUserId,
                       p.updateDate,
                       p.updateUserId,
                   })
                   .FirstOrDefault();

                    if (propertyItems == null)
                        return NotFound();
                    else
                        return Ok(propertyItems);
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
            if (headers.Contains("propItemObject"))
            {
                jsonObject = headers.GetValues("propItemObject").First();
                jsonObject = jsonObject.Replace("\\", string.Empty);
                jsonObject = jsonObject.Trim('"');
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            propertiesItems propertyItemObject = JsonConvert.DeserializeObject<propertiesItems>(jsonObject);
            if (valid)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var propItemEntity = entity.Set<propertiesItems>();
                        if (propertyItemObject.propertyItemId == 0)
                        {
                            propItemEntity.Add(propertyItemObject);
                            message = "Property Item Is Added Successfully";
                        }
                        else
                        {
                            var tmpPropertyItem = entity.propertiesItems.Where(p => p.propertyItemId == propertyItemObject.propertyItemId).FirstOrDefault();
                            tmpPropertyItem.name = propertyItemObject.name;
                            tmpPropertyItem.propertyId = propertyItemObject.propertyId;
                            tmpPropertyItem.isDefault = propertyItemObject.isDefault;
                            tmpPropertyItem.updateDate = propertyItemObject.updateDate;
                            tmpPropertyItem.updateUserId = propertyItemObject.updateUserId;

                            message = "Property Item Is Updated Successfully";
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
            int propertyItemId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("propertyItemId"))
            {
                propertyItemId = Convert.ToInt32(headers.GetValues("propertyItemId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            if (valid)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        propertiesItems PropertDelete = entity.propertiesItems.Find(propertyItemId);
                        entity.propertiesItems.Remove(PropertDelete);
                        entity.SaveChanges();
                        return Ok("Property Item is Deleted Successfully");
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
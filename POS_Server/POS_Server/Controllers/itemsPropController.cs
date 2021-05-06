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
    [RoutePrefix("api/itemsProp")]
    public class itemsPropController : ApiController
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
                    var itemPropsList = (from a in entity.itemsProp.Where(i => i.itemId == itemId)
                    join b in entity.propertiesItems on a.propertyItemId equals b.propertyItemId
                    select new itemsPropModel() {
                         itemPropId = a.itemPropId,
                         propertyItemId = a.propertyItemId,
                         itemId = a.itemId,
                         propName = b.name,
                         createDate = a.createDate,
                         updateDate = a.updateDate,
                         createUserId = a.createUserId,
                         updateUserId = a.updateUserId}).ToList();

                    if (itemPropsList == null)
                        return NotFound();
                    else
                        return Ok(itemPropsList);
                }
            }
            return NotFound();
        }


        // add or update items property
        [HttpPost]
        [Route("Save")]
        public string Save(string itemsPropObject)
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
                itemsPropObject = itemsPropObject.Replace("\\", string.Empty);
                itemsPropObject = itemsPropObject.Trim('"');
                itemsProp newObject = JsonConvert.DeserializeObject<itemsProp>(itemsPropObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var itemPropEntity = entity.Set<itemsProp>();
                        if (newObject.itemPropId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;

                            itemPropEntity.Add(newObject);
                            message = "Property Is Added To Item Successfully";
                        }
                        else
                        {
                            var tmpLocation = entity.itemsProp.Where(p => p.itemPropId == newObject.itemPropId).FirstOrDefault();
                            tmpLocation.propertyItemId = newObject.propertyItemId;
                            tmpLocation.updateDate = DateTime.Now;
                            tmpLocation.updateUserId = newObject.updateUserId;

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
        public IHttpActionResult Delete(int itemPropId)
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
                        itemsProp itemPropObject = entity.itemsProp.Find(itemPropId);

                        entity.itemsProp.Remove(itemPropObject);
                        entity.SaveChanges();

                        return Ok("Item Property is Deleted Successfully");
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
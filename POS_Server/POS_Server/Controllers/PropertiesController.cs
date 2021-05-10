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
                    var propertiesList = entity.properties.Select(p => new PropertyModel {
                      propertyId=  p.propertyId,
                        name= p.name,
                        createDate= p.createDate,
                        createUserId= p.createUserId,
                        updateDate= p.updateDate,
                        updateUserId= p.updateUserId,
                        isActive= p.isActive,
                    })
                    .ToList();

                    if (propertiesList.Count > 0)
                    {
                        for (int i = 0; i < propertiesList.Count; i++)
                        {
                            if (propertiesList[i].isActive == 1)
                            {
                                int propertyId = (int)propertiesList[i].propertyId;
                                var propItems = entity.propertiesItems.Where(x => x.propertyId == propertyId).Select(b => new { b.propertyItemId }).FirstOrDefault();

                                if (propItems is null)
                                    canDelete = true;
                            }
                            propertiesList[i].canDelete = canDelete;
                        }
                    }

                    if (propertiesList == null)
                        return NotFound();
                    else
                        return Ok(propertiesList);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetPropertyValues")]
        public IHttpActionResult GetPropertyValues(int propertyId)
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
                    var propertiesList =( from PI in entity.propertiesItems.Where(x => x.propertyId == propertyId)
                                          join P in entity.properties on PI.propertyId equals P.propertyId
                                          select new PropertiesItemModel(){
                                              propertyItemId = PI.propertyItemId,
                                              propertyId = PI.propertyId,
                                           propertyItemName = PI.name,
                                           createDate = PI.createDate,
                                           createUserId = PI.createUserId,
                                           updateDate = PI.updateDate,
                                           updateUserId = PI.updateUserId,
                                           propertyName = P.name,
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

        [HttpGet]
        [Route("GetAllPropertiesValues")]
        public IHttpActionResult GetAllPropertiesValues()
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
                    var propertiesList = (from PI in entity.propertiesItems
                                          join P in entity.properties on PI.propertyId equals P.propertyId
                                          select new PropertiesItemModel()
                                          {
                                              propertyId = PI.propertyId,
                                              propertyItemName = PI.name,
                                              createDate = PI.createDate,
                                              createUserId = PI.createUserId,
                                              updateDate = PI.updateDate,
                                              updateUserId = PI.updateUserId,
                                              propertyName = P.name,
                                          })
                                        .ToList();

                    if (propertiesList.Count > 0)
                    {
                        for (int i = 0; i < propertiesList.Count; i++)
                        {
                            if (propertiesList[i].isActive == 1)
                            {
                                int propertyItemId = (int)propertiesList[i].propertyItemId;
                                var Itemsprop = entity.itemsProp.Where(x => x.propertyItemId == propertyItemId).Select(b => new { b.itemPropId }).FirstOrDefault();

                                if (Itemsprop is null)
                                    canDelete = true;
                            }
                            propertiesList[i].canDelete = canDelete;
                        }
                    }

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
        public IHttpActionResult GetPropertyByID(int propertyId)
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
        public string Save(string propertyObject)
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
                propertyObject = propertyObject.Replace("\\", string.Empty);
                propertyObject = propertyObject.Trim('"');
                properties propertiesObject = JsonConvert.DeserializeObject<properties>(propertyObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                if (propertiesObject.updateUserId == 0 || propertiesObject.updateUserId == null)
                {
                    Nullable<int> id = null;
                    propertiesObject.updateUserId = id;
                }
                if (propertiesObject.createUserId == 0 || propertiesObject.createUserId == null)
                {
                    Nullable<int> id = null;
                    propertiesObject.createUserId = id;
                }
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var propEntity = entity.Set<properties>();
                        if (propertiesObject.propertyId == 0)
                        {
                            propertiesObject.createDate = DateTime.Now;
                            propertiesObject.updateDate = DateTime.Now;
                            propertiesObject.updateUserId = propertiesObject.createUserId;

                            propEntity.Add(propertiesObject);
                            message = "Property Is Added Successfully";
                        }
                        else
                        {
                            var tmpProperty = entity.properties.Where(p => p.propertyId == propertiesObject.propertyId).FirstOrDefault();
                            tmpProperty.name = propertiesObject.name;
                            tmpProperty.updateDate = DateTime.Now;
                            tmpProperty.updateUserId = propertiesObject.updateUserId;

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
        public IHttpActionResult Delete(int propertyId, int userId, Boolean final)
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
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        properties PropertDelete = entity.properties.Find(propertyId);
                        PropertDelete.isActive = 0;
                        PropertDelete.updateDate = DateTime.Now;
                        PropertDelete.updateUserId = userId;
                        entity.SaveChanges();
                        return Ok("Property is Deleted Successfully");
                    }
                }
            }
            else
                return NotFound();
        }
    }
}
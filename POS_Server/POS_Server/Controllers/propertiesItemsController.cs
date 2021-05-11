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
                    var propertiesList = entity.propertiesItems.Select(p => new PropertiesItemModel {
                       propertyItemId= p.propertyItemId,
                        propertyId= p.propertyId,
                        propertyItemName = p.name,
                        isDefault= p.isDefault,
                        createDate=p.createDate,
                        createUserId= p.createUserId,
                        updateDate= p.updateDate,
                        updateUserId=p.updateUserId,
                        isActive = p.isActive,
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

        //********************************************************
        //****************** get values of property
        [HttpGet]
        [Route("GetPropertyItems")]
        public IHttpActionResult GetPropertyItems(int propertyId)
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
                    var propertiesList = entity.propertiesItems.Where(p => p.propertyId == propertyId).Select(p => new PropertiesItemModel
                    {
                        propertyItemId = p.propertyItemId,
                        propertyId = p.propertyId,
                        propertyItemName = p.name,
                        isDefault = p.isDefault,
                        createDate = p.createDate,
                        createUserId = p.createUserId,
                        updateDate = p.updateDate,
                        updateUserId = p.updateUserId,
                        isActive = p.isActive,
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
        public string Save(string propItemObject)
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
                propItemObject = propItemObject.Replace("\\", string.Empty);
                propItemObject = propItemObject.Trim('"');
                propertiesItems propertyItemObject = JsonConvert.DeserializeObject<propertiesItems>(propItemObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                if (propertyItemObject.updateUserId == 0 || propertyItemObject.updateUserId == null)
                {
                    Nullable<int> id = null;
                    propertyItemObject.updateUserId = id;
                }
                if (propertyItemObject.createUserId == 0 || propertyItemObject.createUserId == null)
                {
                    Nullable<int> id = null;
                    propertyItemObject.createUserId = id;
                }
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var propItemEntity = entity.Set<propertiesItems>();
                        if (propertyItemObject.propertyItemId == 0)
                        {
                            propertyItemObject.createDate = DateTime.Now;
                            propertyItemObject.updateDate = DateTime.Now;
                            propertyItemObject.updateUserId = propertyItemObject.createUserId;

                            propItemEntity.Add(propertyItemObject);
                            message = "Property Item Is Added Successfully";
                        }
                        else
                        {
                            var tmpPropertyItem = entity.propertiesItems.Where(p => p.propertyItemId == propertyItemObject.propertyItemId).FirstOrDefault();
                            tmpPropertyItem.name = propertyItemObject.name;
                            tmpPropertyItem.propertyId = propertyItemObject.propertyId;
                            tmpPropertyItem.isDefault = propertyItemObject.isDefault;
                            tmpPropertyItem.updateDate = DateTime.Now;
                            tmpPropertyItem.updateUserId = propertyItemObject.updateUserId;
                            tmpPropertyItem.isActive = propertyItemObject.isActive;
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
        public IHttpActionResult Delete(int propertyItemId,int userId,Boolean final)
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
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            propertiesItems PropertDelete = entity.propertiesItems.Find(propertyItemId);
                            PropertDelete.isActive = 0;
                            PropertDelete.updateUserId = userId;
                            PropertDelete.updateDate = DateTime.Now;
                            entity.SaveChanges();
                            return Ok("Property Item is Deleted Successfully");
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
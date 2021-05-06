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
    [RoutePrefix("api/Locations")]
    public class LocationsController : ApiController
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
                    var locationsList = entity.locations
                    .Select(L => new LocationModel
                    {
                      locationId=  L.locationId,
                       x =  L.x,
                       y = L.y,
                        z = L.z,
                        branchId= L.branchId,
                        createDate=L.createDate,
                        updateDate=L.updateDate,
                        createUserId= L.createUserId,
                        updateUserId=L.updateUserId,
                        isActive=L.isActive,
                    })
                    .ToList();

                    if (locationsList.Count > 0)
                    {
                        for (int i = 0; i < locationsList.Count; i++)
                        {
                            if (locationsList[i].isActive == 1)
                            {
                                int locationId = (int)locationsList[i].locationId;
                                var itemsLocationL = entity.itemsLocations.Where(x => x.locationId == locationId).Select(b => new { b.itemsLocId }).FirstOrDefault();
                                var itemsTransferL = entity.itemsTransfer.Where(x => x.locationIdNew == locationId || x.locationIdOld == locationId).Select(x => new { x.itemsTransId }).FirstOrDefault();
                                
                                if ((itemsLocationL is null) && (itemsTransferL is null) )
                                    canDelete = true;
                            }
                            locationsList[i].canDelete = canDelete;
                        }
                    }

                    if (locationsList == null)
                        return NotFound();
                    else
                        return Ok(locationsList);
                }
            }
            //else
            return NotFound();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetLocationByID")]
        public IHttpActionResult GetLocationByID(int locationId)
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
                    var location = entity.locations
                   .Where(u => u.locationId == locationId)
                   .Select(L => new
                   {
                       L.locationId,
                       L.x,
                       L.y,
                       L.z,
                       L.branchId,
                       L.createDate,
                       L.updateDate,
                       L.createUserId,
                       L.updateUserId,
                       L.isActive,
                   })
                   .FirstOrDefault();

                    if (location == null)
                        return NotFound();
                    else
                        return Ok(location);
                }
            }
            else
                return NotFound();
        }

        // add or update location
        [HttpPost]
        [Route("Save")]
        public string Save(string locationObject)
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
                locationObject = locationObject.Replace("\\", string.Empty);
                locationObject = locationObject.Trim('"');
                locations newObject = JsonConvert.DeserializeObject<locations>(locationObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var locationEntity = entity.Set<locations>();
                        if (newObject.locationId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;

                            locationEntity.Add(newObject);
                            message = "Location Is Added Successfully";
                        }
                        else
                        {
                            var tmpLocation = entity.locations.Where(p => p.locationId == newObject.locationId).FirstOrDefault();
                            tmpLocation.x = newObject.x;
                            tmpLocation.y = newObject.y;
                            tmpLocation.z = newObject.z;
                            tmpLocation.branchId = newObject.branchId;
                            tmpLocation.updateDate = DateTime.Now;
                            tmpLocation.updateUserId = newObject.updateUserId;

                            message = "Location Is Updated Successfully";
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
        public IHttpActionResult Delete(int locationId, int userId,Boolean final)
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
                            locations locationDelete = entity.locations.Find(locationId);

                            entity.locations.Remove(locationDelete);
                            entity.SaveChanges();

                            return Ok("Location is Deleted Successfully");
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
                            locations locationDelete = entity.locations.Find(locationId);

                            locationDelete.isActive = 0;
                            locationDelete.updateUserId = userId;
                            locationDelete.updateDate = DateTime.Now;
                            entity.SaveChanges();

                            return Ok("Location is Deleted Successfully");
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
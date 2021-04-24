using Newtonsoft.Json;
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
                    })
                    .ToList();

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

        // add or update pos
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
                            tmpLocation.updateDate = newObject.updateDate;
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
        public IHttpActionResult Delete(int locationId)
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
                return NotFound();
        }
    }
}
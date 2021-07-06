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
                    var locationsList = (from L in  entity.locations 
                                         join s in entity.sections on L.sectionId equals s.sectionId into lj
                                         from v in lj.DefaultIfEmpty()
                                         select new LocationModel()
                                         {
                                            locationId=  L.locationId,
                                            x =  L.x,
                                            y = L.y,
                                            z = L.z,
                                            createDate = L.createDate,
                                            updateDate = L.updateDate,
                                            createUserId = L.createUserId,
                                            updateUserId=L.updateUserId,
                                            isActive=L.isActive,
                                            isFreeZone=L.isFreeZone,
                                            branchId=L.branchId,
                                             sectionId =L.sectionId,
                                            sectionName = v.name,
                                            note = L.note,
                                        }).ToList();

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
                       L.createDate,
                       L.updateDate,
                       L.createUserId,
                       L.updateUserId,
                       L.isActive,
                       L.isFreeZone,
                       L.branchId,
                       L.sectionId,
                       note = L.note,

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
                if (newObject.sectionId == 0 || newObject.sectionId == null)
                {
                    Nullable<int> id = null;
                    newObject.sectionId = id;
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
                            entity.SaveChanges();
                            message = newObject.locationId.ToString();
                        }
                        else
                        {
                            var tmpLocation = entity.locations.Where(p => p.locationId == newObject.locationId).FirstOrDefault();
                            tmpLocation.x = newObject.x;
                            tmpLocation.y = newObject.y;
                            tmpLocation.z = newObject.z;
                            tmpLocation.branchId = newObject.branchId;
                            tmpLocation.isFreeZone = newObject.isFreeZone;
                            tmpLocation.updateDate = DateTime.Now;
                            tmpLocation.updateUserId = newObject.updateUserId;
                            tmpLocation.sectionId = newObject.sectionId;
                            tmpLocation.note = newObject.note;
                            entity.SaveChanges();

                            message = tmpLocation.locationId.ToString();
                        }
                      //  entity.SaveChanges();
                    }
                }
                catch
                {
                    message = "-1";
                }
            }
            return message;
        }

        [HttpPost]
        [Route("Delete")]
        public bool Delete(int locationId, int userId,Boolean final)
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

                            return true;
                        }
                    }
                    catch
                    {
                        return false;
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

                            return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            else
                return false;
        }

        #region
        [HttpPost]
        [Route("UpdateLocBySecId")]

        public int UpdateLocationBySecId(string newloclist)
        {
            int sectionId = 0;
            var re = Request;
            var headers = re.Headers;
            int res = 0;
            string token = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("sectionId"))
            {
                sectionId = Convert.ToInt32(headers.GetValues("sectionId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            newloclist = newloclist.Replace("\\", string.Empty);
            newloclist = newloclist.Trim('"');
            List<locations> newlocObj = JsonConvert.DeserializeObject<List<locations>>(newloclist, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var oldloc = entity.locations.Where(p => p.sectionId == sectionId);
                    if (oldloc.Count() > 0)
                    {
                        entity.locations.RemoveRange(oldloc);
                    }
                    if (newlocObj.Count() > 0)
                    {
                        foreach (locations newlocrow in newlocObj)
                        {
                            newlocrow.sectionId = sectionId;
                            if (newlocrow.createDate == null)
                            {
                                newlocrow.createDate = DateTime.Now;
                                newlocrow.updateDate = DateTime.Now;
                                newlocrow.updateUserId = newlocrow.createUserId;
                            }
                            else
                            {
                                newlocrow.updateDate = DateTime.Now;
                            }
                        }
                        entity.locations.AddRange(newlocObj);
                    }
                    res = entity.SaveChanges();

                    return res;
                }

            }
            else
            {
                return -1;
            }

        }
        #endregion


        // add or update List of locations
        [HttpPost]
        [Route("AddLocationsToSection")]
        public int AddLocationsToSection(string locationsObject, int sectionId,int userId)
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
                locationsObject = locationsObject.Replace("\\", string.Empty);
                locationsObject = locationsObject.Trim('"');
                List<locations> Object = JsonConvert.DeserializeObject<List<locations>>(locationsObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var oldList = entity.locations.Where(x => x.sectionId == sectionId).Select(x => new { x.locationId }).ToList();
                    for (int i = 0; i < oldList.Count; i++)
                    {
                        int locationId = (int)oldList[i].locationId;
                        var loc = entity.locations.Find(locationId);

                        if (Object != null && Object.Count > 0)
                        {
                            var isExist = Object.Find(x => x.locationId == oldList[i].locationId);
                            if (isExist == null)// unlink location to section
                            {
                                loc.sectionId = null;
                                loc.updateDate = DateTime.Now;
                                loc.updateUserId = userId;
                            }
                            else// edit location info
                            {
                              
                            }
                        }
                        else // clear section from location
                        {
                            loc.sectionId = null;
                            loc.updateDate = DateTime.Now;
                            loc.updateUserId = userId;
                        }
                    }
                    foreach (locations loc in Object)// loop to add new locations
                    {
                        Boolean isInList = false;
                        if (oldList != null)
                        {
                            var old = oldList.ToList().Find(x => x.locationId == loc.locationId);
                            if (old != null)
                            {
                                isInList = true;

                            }

                            if (!isInList)
                            {
                                var loc1 = entity.locations.Find(loc.locationId);
                                if (loc1.updateUserId == 0 || loc1.updateUserId == null)
                                {
                                    Nullable<int> id = null;
                                    loc1.updateUserId = id;
                                }
                                if (loc1.createUserId == 0 || loc1.createUserId == null)
                                {
                                    Nullable<int> id = null;
                                    loc1.createUserId = id;
                                }
                                loc1.updateDate = DateTime.Now;
                                loc1.sectionId = sectionId;
                                loc.updateUserId = userId;
                                //entity.SaveChanges();
                            }
                        }
                        try
                        {
                            entity.SaveChanges();
                        }
                        catch { return 0; }
                    }
                    entity.SaveChanges();
                }
            }
            return 1;
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetLocsByBranchID")]
        public IHttpActionResult GetLocsByBranchID(int branchId)
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
                    var locationsList = (from L in entity.locations
                                         join s in entity.sections on L.sectionId equals s.sectionId into lj
                                         join b in entity.branches on L.branchId equals b.branchId into bj
                                         from v in lj.DefaultIfEmpty()
                                         from bbj in bj.DefaultIfEmpty()
                                         where L.branchId == branchId
                                         select new LocationModel()
                                         {
                                             locationId = L.locationId,
                                             x = L.x,
                                             y = L.y,
                                             z = L.z,
                                             createDate = L.createDate,
                                             updateDate = L.updateDate,
                                             createUserId = L.createUserId,
                                             updateUserId = L.updateUserId,
                                             isActive = L.isActive,
                                             isFreeZone = L.isFreeZone,
                                             branchId = L.branchId,
                                             sectionId = L.sectionId,
                                             sectionName = v.name,
                                             note = L.note,

                                         }).ToList();

                    if (locationsList.Count > 0)
                    {
                        for (int i = 0; i < locationsList.Count; i++)
                        {
                            if (locationsList[i].isActive == 1)
                            {
                                int locationId = (int)locationsList[i].locationId;
                                var itemsLocationL = entity.itemsLocations.Where(x => x.locationId == locationId).Select(b => new { b.itemsLocId }).FirstOrDefault();
                                var itemsTransferL = entity.itemsTransfer.Where(x => x.locationIdNew == locationId || x.locationIdOld == locationId).Select(x => new { x.itemsTransId }).FirstOrDefault();

                                if ((itemsLocationL is null) && (itemsTransferL is null))
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
        [HttpGet]
        [Route("GetLocsBySectionId")]
        public IHttpActionResult GetLocsBySectionId(int sectionId)
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
                    var locationsList = (from L in entity.locations where L.sectionId == sectionId
                                         join s in entity.sections on L.sectionId equals s.sectionId into lj
                                         from v in lj.DefaultIfEmpty()

                                         select new LocationModel()
                                         {
                                             locationId = L.locationId,
                                             x = L.x,
                                             y = L.y,
                                             z = L.z,
                                             createDate = L.createDate,
                                             updateDate = L.updateDate,
                                             createUserId = L.createUserId,
                                             updateUserId = L.updateUserId,
                                             isActive = L.isActive,
                                             isFreeZone = L.isFreeZone,
                                             branchId = L.branchId,
                                             sectionId = L.sectionId,
                                             sectionName = v.name,
                                             note = L.note,

                                         }).ToList();

                    if (locationsList == null)
                        return NotFound();
                    else
                        return Ok(locationsList);
                }
            }
            //else
            return NotFound();
        }

    }
}
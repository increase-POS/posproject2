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
    [RoutePrefix("api/Units")]
    public class UnitsController : ApiController
    {
        List<int> unitsIds = new List<int>();
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
                    var unitsList = (from u in entity.units
                                     join b in entity.units
                                      on new { UnitModel = u.smallestId } equals new { UnitModel = (int?)b.unitId } into lj
                                     from x in lj.DefaultIfEmpty()
                                     select new UnitModel()
                                     {
                                         unitId = u.unitId,
                                         name = u.name,
                                         isSmallest = u.isSmallest,
                                         smallestUnit = x.name,
                                         parentid = u.parentid,
                                         smallestId = u.smallestId,
                                         notes = u.notes,
                                         createDate = u.createDate,
                                         createUserId = u.createUserId,
                                         updateDate = u.updateDate,
                                         updateUserId = u.updateUserId,
                                         isActive = u.isActive,
                                     }).ToList();

                    if (unitsList.Count > 0)
                    {
                        for (int i = 0; i < unitsList.Count; i++)
                        {
                            canDelete = false;
                            if (unitsList[i].isActive == 1)
                            {
                                int unitId = (int)unitsList[i].unitId;
                                var itemsL = entity.items.Where(x => x.minUnitId == unitId).Select(b => new { b.itemId }).ToList();
                                var itemsMatL = entity.itemsMaterials.Where(x => x.unitId == unitId).Select(x => new { x.itemMatId }).FirstOrDefault();
                                var itemsUnitL = entity.itemsUnits.Where(x => x.unitId == unitId).Select(x => new { x.itemUnitId }).FirstOrDefault();
                                var unitsL = entity.units.Where(x => x.parentid == unitId).Select(x => new { x.unitId }).FirstOrDefault();
                                if ((itemsL.Count == 0) && (itemsMatL is null) && (itemsUnitL is null) && (unitsL is null))
                                    canDelete = true;
                            }

                            unitsList[i].canDelete = canDelete;
                        }
                    }
                    if (unitsList == null)
                        return NotFound();
                    else
                        return Ok(unitsList);
                }
            }
            //else
            return NotFound();
        }

        //private IEnumerable<units> Traverse(IEnumerable<itemsUnits> units)
        //{
        //    using (incposdbEntities entity = new incposdbEntities())
        //    {
        //        foreach (var category in units)
        //        {
        //            var subCategories = entity.itemsUnits.Where(x => x.subUnitId == category.unitId).ToList();
        //            category.Children = subCategories;
        //            category.Children = Traverse(category.Children).ToList();
        //        }
        //    }
        //    return categories;
        //}
        [HttpGet]
        [Route("getSmallUnits")]
        public IHttpActionResult getSmallUnits(int itemId, int unitId)
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
                    // get all sub categories of categoryId
                    List<itemsUnits> unitsList = entity.itemsUnits
                     .ToList().Where(x => x.itemId == itemId)
                      .Select(p => new itemsUnits
                      {
                          unitId = p.unitId,
                          //name = p.name,
                          subUnitId = p.subUnitId,
                      })
                     .ToList();

                    unitsIds = new List<int>();
                    // unitsIds.Add(categoryId);

                    // get items
                    var result = Recursive(unitsList, unitId);

                    var units = (from u in entity.units
                                 select new UnitModel()
                                 {
                                     unitId = u.unitId,
                                     name = u.name,
                                     isSmallest = u.isSmallest,
                                     parentid = u.parentid,
                                     smallestId = u.smallestId,
                                     notes = u.notes,
                                     createDate = u.createDate,
                                     createUserId = u.createUserId,
                                     updateDate = u.updateDate,
                                     updateUserId = u.updateUserId,
                                     isActive = u.isActive,

                                 }).Where(p => !unitsIds.Contains((int)p.unitId)).ToList();

                    if (units == null)
                        return NotFound();
                    else
                        return Ok(units);
                }

            }
            else
            {
                return NotFound();
            }

        }

        public IEnumerable<itemsUnits> Recursive(List<itemsUnits> unitsList, int smallLevelid)
        {
            List<itemsUnits> inner = new List<itemsUnits>();

            foreach (var t in unitsList.Where(item => item.subUnitId == smallLevelid))
            {
                unitsIds.Add(t.unitId.Value);
                inner.Add(t);
                if (t.unitId.Value == smallLevelid)
                    return inner;
                inner = inner.Union(Recursive(unitsList, t.unitId.Value)).ToList();
            }

            return inner;
        }

        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string searchWords)
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
                    var unitsList = (from u in entity.units
                                     join b in entity.units
                                      on new { UnitModel = u.smallestId } equals new { UnitModel = (int?)b.unitId } into lj
                                     from x in lj.DefaultIfEmpty()
                                     select new UnitModel()
                                     {
                                         unitId = u.unitId,
                                         name = u.name,
                                         isSmallest = u.isSmallest,
                                         smallestUnit = x.name,
                                         parentid = u.parentid,
                                         smallestId = u.smallestId,
                                         createDate = u.createDate,
                                         createUserId = u.createUserId,
                                         updateDate = u.updateDate,
                                         updateUserId = u.updateUserId,
                                         isActive = u.isActive,
                                         notes = u.notes,
                                     }).Where(f => (f.name.Contains(searchWords) || f.smallestUnit.Contains(searchWords))).ToList();
                    if (unitsList == null)
                        return NotFound();
                    else
                        return Ok(unitsList);
                }
            }
            //else
            return NotFound();
        }

        [HttpGet]
        [Route("GetActive")]
        public IHttpActionResult GetActive()
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
                    var unitsList = entity.units
                        .Where(u => u.isActive == 1)
                        .Select(u => new {
                            u.createDate,
                            u.createUserId,
                            u.isSmallest,
                            u.name,
                            u.parentid,
                            u.smallestId,
                            u.unitId,
                            u.updateDate,
                            u.updateUserId,
                            u.notes,
                        })
                    .ToList();

                    if (unitsList == null)
                        return NotFound();
                    else
                        return Ok(unitsList);
                }
            }
            //else
            return NotFound();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetUnitByID")]
        public IHttpActionResult GetUnitByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int unitId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("unitId"))
            {
                unitId = Convert.ToInt32(headers.GetValues("unitId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var unit = entity.units
                   .Where(u => u.unitId == unitId)
                   .Select(u => new {
                       u.createDate,
                       u.createUserId,
                       u.isSmallest,
                       u.name,
                       u.parentid,
                       u.smallestId,
                       u.unitId,
                       u.updateDate,
                       u.updateUserId,
                       u.notes,
                   })
                   .FirstOrDefault();

                    if (unit == null)
                        return NotFound();
                    else
                        return Ok(unit);
                }
            }
            else
                return NotFound();
        }

        // add or update unit
        [HttpPost]
        [Route("Save")]
        public string Save(string unitObject)
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
                unitObject = unitObject.Replace("\\", string.Empty);
                unitObject = unitObject.Trim('"');
                units Object = JsonConvert.DeserializeObject<units>(unitObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var unitEntity = entity.Set<units>();
                        if (Object.unitId == 0)
                        {
                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;

                            unitEntity.Add(Object);
                            message = "Unit Is Added Successfully";
                        }
                        else
                        {
                            var tmpUnit = entity.units.Where(p => p.unitId == Object.unitId).FirstOrDefault();
                            tmpUnit.name = Object.name;
                            tmpUnit.notes = Object.notes;
                            tmpUnit.isSmallest = Object.isSmallest;
                            tmpUnit.smallestId = Object.smallestId;
                            tmpUnit.updateDate = DateTime.Now;
                            tmpUnit.updateUserId = Object.updateUserId;
                            tmpUnit.parentid = Object.parentid;
                            tmpUnit.isActive = Object.isActive;
                            message = "Unit Is Updated Successfully";
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
        public IHttpActionResult Delete(int unitId, int userId, Boolean final)
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

                            units unitDelete = entity.units.Find(unitId);
                            entity.units.Remove(unitDelete);
                            entity.SaveChanges();
                            return Ok("Unit is Deleted Successfully");
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
                            units unitDelete = entity.units.Find(unitId);
                            unitDelete.isActive = 0;
                            unitDelete.updateDate = DateTime.Now;
                            unitDelete.updateUserId = userId;
                            entity.SaveChanges();
                            return Ok("Unit is Deleted Successfully");
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
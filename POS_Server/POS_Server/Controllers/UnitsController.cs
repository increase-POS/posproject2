using Newtonsoft.Json;
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
                   var unitsList = entity.units.Select(u=> new {
                    u.createDate,
                    u.createUserId,
                    u.isSmallest,
                    u.name,
                    u.parentid,
                    u.smallestId,
                    u.unitId,
                    u.updateDate,
                    u.updateUserId,
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
                       u.updateUserId
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
            if (headers.Contains("unitObject"))
            {
                jsonObject = headers.GetValues("unitObject").First();
                jsonObject = jsonObject.Replace("\\", string.Empty);
                jsonObject = jsonObject.Trim('"');
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            POS_Server.units unitObject = JsonConvert.DeserializeObject<POS_Server.units>(jsonObject);
            if (valid)
            {
               try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var unitEntity = entity.Set<units>();
                        if (unitObject.unitId == 0)
                        {
                            unitEntity.Add(unitObject);
                            message = "Unit Is Added Successfully";
                        }
                        else
                        {
                            var tmpUnit = entity.units.Where(p => p.unitId == unitObject.unitId).FirstOrDefault();
                            tmpUnit.name = unitObject.name;
                            tmpUnit.isSmallest = unitObject.isSmallest;
                            tmpUnit.smallestId = unitObject.smallestId;
                            tmpUnit.updateDate = unitObject.updateDate;
                            tmpUnit.updateUserId = unitObject.updateUserId;
                            tmpUnit.parentid = unitObject.parentid;
                            message = "Unit Is Updated Successfully";
                        }
                        entity.SaveChanges();
                    }  
               }

                catch
                {
                   message ="an error ocurred";
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
               try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var itemUnits = entity.itemsUnits.Where(u => u.unitId == unitId).FirstOrDefault();
                    var relatedUnits = entity.units.Where(u => u.parentid == unitId || u.smallestId == unitId)
                        .Select(u => new { u.unitId } )              
                        .FirstOrDefault();
                        if (itemUnits == null && relatedUnits == null)
                        {
                            units unitDelete = entity.units.Find(unitId);
                            entity.units.Remove(unitDelete);
                            entity.SaveChanges();
                            return Ok("Unit is Deleted Successfully");
                        }
                        else
                            return Ok("Can't Delete This Unit");    
                    }
                }
               catch
               {
                    return NotFound() ;
               }
            }
            else
               return NotFound();
        }
    }
}
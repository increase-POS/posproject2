using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Pos")]
    public class PosController : ApiController
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
                    var posList = entity.pos
                    .Select(p => new
                    {
                        p.posId,
                        p.balance,
                        p.branchId,
                        p.code,
                        p.name,
                        p.createDate,
                        p.updateDate,
                        p.createUserId,
                        p.updateUserId,
                    })
                    .ToList();

                    if (posList == null)
                        return NotFound();
                    else
                        return Ok(posList);
                }
            }
            //else
            return NotFound();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetPosByID")]
        public IHttpActionResult GetPosByID(int posId)
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
                    var pos = entity.pos
                   .Where(u => u.posId == posId)
                   .Select(p => new
                   {
                       p.posId,
                       p.balance,
                       p.branchId,
                       p.code,
                       p.name,
                       p.createDate,
                       p.updateDate,
                       p.createUserId,
                       p.updateUserId,
                   })
                   .FirstOrDefault();

                    if (pos == null)
                        return NotFound();
                    else
                        return Ok(pos);
                }
            }
            else
                return NotFound();
        }

        // add or update pos
        [HttpPost]
        [Route("Save")]
        public string Save(string posObject)
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
                posObject = posObject.Replace("\\", string.Empty);
                posObject = posObject.Trim('"');
                pos newObject = JsonConvert.DeserializeObject<pos>(posObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var unitEntity = entity.Set<pos>();
                        if (newObject.posId == 0)
                        {
                            unitEntity.Add(newObject);
                            message = "Pos Is Added Successfully";
                        }
                        else
                        {
                            var tmpPos = entity.pos.Where(p => p.posId == newObject.posId).FirstOrDefault();
                            tmpPos.name = newObject.name;
                            tmpPos.code = newObject.code;
                            tmpPos.balance = newObject.balance;
                            tmpPos.branchId = newObject.branchId;
                            tmpPos.updateDate = newObject.updateDate;
                            tmpPos.updateUserId = newObject.updateUserId;

                            message = "Pos Is Updated Successfully";
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
        public IHttpActionResult Delete(int posId)
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
                        pos posDelete = entity.pos.Find(posId);

                        entity.pos.Remove(posDelete);
                        entity.SaveChanges();

                        return Ok("Pos is Deleted Successfully");
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
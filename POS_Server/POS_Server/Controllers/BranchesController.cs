using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Branches")]
    public class BranchesController : ApiController
    {
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

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {

                    var branchesList = entity.branches
                   .Select(b => new { b.branchId, b.address, b.createDate, b.createUserId, b.details, b.email, b.mobile, b.name,b.code, b.notes, b.parentId, b.phone,  b.updateDate, b.updateUserId })
                   .ToList();

                    if (branchesList == null)
                        return NotFound();
                    else
                        return Ok(branchesList);

                }
            }
            else
                return NotFound();
        }
        // GET api/branch/5
        [HttpGet]
        [Route("GetBranchByID")]
        public IHttpActionResult GetBranchByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int branchId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("branchId"))
            {
                branchId = Convert.ToInt32(headers.GetValues("branchId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {

                    var branch = entity.branches
                   .Where(b => b.branchId == branchId)
                   .Select(b => new { b.branchId, b.address, b.createDate, b.createUserId, b.details, b.email, b.mobile, b.name, b.code, b.notes, b.parentId, b.phone, b.updateDate, b.updateUserId })
                   .FirstOrDefault();

                    if (branch == null)
                        return NotFound();
                    else
                        return Ok(branch);

                }
            }
            else
                return NotFound();
        }

        // add or update branch
        [HttpPost]
        [Route("Save")]
        public bool Save(string branchObject)
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
                branchObject = branchObject.Replace("\\", string.Empty);
                branchObject = branchObject.Trim('"');
                branches newObject = JsonConvert.DeserializeObject<branches>(branchObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var branchEntity = entity.Set<branches>();
                        if (newObject.branchId == 0)
                        {
                            branchEntity.Add(newObject);
                        }
                        else
                        {
                            var tmpBranch = entity.branches.Where(p => p.branchId == newObject.branchId).First();
                            tmpBranch.address = newObject.address;
                            tmpBranch.details = newObject.details;
                            tmpBranch.code = newObject.code;
                            tmpBranch.email = newObject.email;
                            tmpBranch.name = newObject.name;
                            tmpBranch.mobile = newObject.mobile;
                            tmpBranch.notes = newObject.notes;
                            tmpBranch.phone = newObject.phone;
                            tmpBranch.parentId = newObject.parentId;
                            tmpBranch.updateDate = newObject.updateDate;
                            tmpBranch.updateUserId = newObject.updateUserId;
                        }
                        entity.SaveChanges();
                    }
                    return true;
                }

                catch
                {
                    return false;
                }
            }
            else
                return false;
        }
        [HttpPost]
        [Route("Delete")]
        public bool Delete()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int branchId = 0;

            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("branchId"))
            {
                branchId = Convert.ToInt32(headers.GetValues("branchId").First());
            }

            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            if (valid)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var tmpBranch = entity.branches.Where(p => p.branchId == branchId).First();
                        entity.branches.Remove(tmpBranch);

                        entity.SaveChanges();
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}
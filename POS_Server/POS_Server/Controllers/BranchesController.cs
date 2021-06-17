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
    [RoutePrefix("api/Branches")]
    public class BranchesController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(string type)
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

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {


                    var branchesList = entity.branches
                        .Where(b => b.type == type)
                   .Select(b => new BranchModel{
                      branchId= b.branchId,
                       address=b.address,
                       createDate= b.createDate,
                       createUserId= b.createUserId,
                       email=b.email,
                       mobile= b.mobile,
                       name= b.name,
                       code=b.code,
                       notes=b.notes,
                       parentId= b.parentId,
                       phone=b.phone,
                       updateDate= b.updateDate,
                       updateUserId= b.updateUserId,
                       isActive=b.isActive,
                       type= b.type})
                   .ToList();

                    if (branchesList.Count > 0)
                    {
                        for (int i = 0; i < branchesList.Count; i++)
                        {
                            canDelete = false;
                            if (branchesList[i].isActive == 1)
                            {
                                int branchId = (int)branchesList[i].branchId;
                                var parentBrancheL = entity.branches.Where(x => x.parentId == branchId).Select(x => new { x.branchId }).FirstOrDefault();
                                var posL = entity.pos.Where(x => x.branchId == branchId).Select(b => new { b.posId }).FirstOrDefault();
                               // var locationsL = entity.locations.Where(x => x.branchId == branchId).Select(x => new { x.locationId }).FirstOrDefault();
                                var usersL = entity.branchesUsers.Where(x => x.branchId == branchId).Select(x => new { x.branchsUsersId }).FirstOrDefault();
                                if ((parentBrancheL is null)&&(posL is null)  && (usersL is null))
                                    canDelete = true;
                            }
                            branchesList[i].canDelete = canDelete;
                        }
                    }
                    if (branchesList == null)
                        return NotFound();
                    else
                        return Ok(branchesList);

                }
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string type,string searchWords)
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
                        .Where(b => b.type == type && (b.name.Contains(searchWords) || b.code.Contains(searchWords) || b.address.Contains(searchWords)))
                   .Select(b => new {
                       b.branchId,
                       b.address,
                       b.createDate,
                       b.createUserId,
                       b.email,
                       b.mobile,
                       b.name,
                       b.code,
                       b.notes,
                       b.parentId,
                       b.phone,
                       b.updateDate,
                       b.updateUserId,
                       b.isActive,
                       b.type
                   })
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

        [HttpGet]
        [Route("GetActive")]
        public IHttpActionResult GetActive(string type)
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
                if (!type.Equals("all"))
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {

                        var branchesList = entity.branches
                            .Where(b => b.type == type && b.isActive == 1)
                       .Select(b => new
                       {
                           b.branchId,
                           b.address,
                           b.createDate,
                           b.createUserId,
                           b.email,
                           b.mobile,
                           b.name,
                           b.code,
                           b.notes,
                           b.parentId,
                           b.phone,
                           b.updateDate,
                           b.updateUserId,
                           b.isActive,
                           b.type
                       })
                       .ToList();

                        if (branchesList == null)
                            return NotFound();
                        else
                            return Ok(branchesList);

                    }
                }
                else
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var branchesList = entity.branches.Select(b => new BranchModel
                        {
                            branchId = b.branchId,
                            address = b.address,
                            createDate = b.createDate,
                            createUserId = b.createUserId,
                            email = b.email,
                            mobile = b.mobile,
                            name = b.name,
                            code = b.code,
                            notes = b.notes,
                            parentId = b.parentId,
                            phone = b.phone,
                            updateDate = b.updateDate,
                            updateUserId = b.updateUserId,
                            isActive = b.isActive,
                            type = b.type
                        })
                            .ToList();
                        if (branchesList == null)
                            return NotFound();
                        else
                            return Ok(branchesList);
                    }
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
                   .Select(b => new { b.branchId, b.address, b.createDate, b.createUserId, b.email, b.mobile, b.name, b.code, b.notes, b.parentId, b.phone, b.updateDate, b.updateUserId })
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
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;


                            branchEntity.Add(newObject);
                        }
                        else
                        {
                            var tmpBranch = entity.branches.Where(p => p.branchId == newObject.branchId).First();
                            tmpBranch.address = newObject.address;
                            tmpBranch.code = newObject.code;
                            tmpBranch.email = newObject.email;
                            tmpBranch.name = newObject.name;
                            tmpBranch.mobile = newObject.mobile;
                            tmpBranch.notes = newObject.notes;
                            tmpBranch.phone = newObject.phone;
                            tmpBranch.type = newObject.type;
                            tmpBranch.parentId = newObject.parentId;
                            tmpBranch.updateDate = DateTime.Now;// server current date
                            tmpBranch.updateUserId = newObject.updateUserId;
                            tmpBranch.isActive = newObject.isActive;
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
        public bool Delete(int branchId, int userId,Boolean final)
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
                    //try
                    //{
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            var tmpBranch = entity.branches.Where(p => p.branchId == branchId).First();
                            entity.branches.Remove(tmpBranch);

                            entity.SaveChanges();
                        }

                        return true;
                   // }
                   // catch
                   // {
                   //     return false;
                   // }
                }
                else
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            var tmpBranch = entity.branches.Where(p => p.branchId == branchId).First();
                            tmpBranch.isActive = 0;
                            tmpBranch.updateUserId = userId;
                            tmpBranch.updateDate = DateTime.Now;

                            entity.SaveChanges();
                        }

                        return true;
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

        [HttpGet]
        [Route("GetBranchTreeByID")]
        public IHttpActionResult GetBranchTreeByID(int branchID)
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
            List<branches> treebranch = new List<branches>();
            /*
        p.branchId 
         code 
        name 
         address 
         email 
         phone 
         mobile 
        createDate 
         updateDate 
         createUserId 
        updateUserId 
        notes 
        parentId 
        isActive 
        type 
        canDelete 
             * */
            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    /*
                    var category1 = entity.categories.Where(c => c.categoryId == categoryID)
                    .Select(p => new {
                        //  p.name,
                        p.parentId,

                    }).FirstOrDefault();
                    int parentid = (int)category1.parentId;
                    */
                    int parentid = branchID; // if want to show the last category 
                    while (parentid > 0 )
                    {
                        branches tempbranch = new branches();
                        var branch = entity.branches.Where(c => c.branchId == parentid)
                            .Select(p => new {
                               
                                p.branchId,
                                p.code,
                                p.name,
                                p.address,
                                p.email,
                                p.phone,
                                p.mobile,
                                p.createDate,
                                p.updateDate,
                                p.createUserId,
                                p.updateUserId,
                                p.notes,
                                p.parentId,
                                p.isActive,
                                p.type,

                            }).FirstOrDefault();

                        tempbranch.branchId = branch.branchId;
                        tempbranch.code = branch.code;
                        tempbranch.name = branch.name;
                        tempbranch.address = branch.address;
                        tempbranch.email = branch.email;
                        tempbranch.phone = branch.phone;
                        tempbranch.mobile = branch.mobile;
                        tempbranch.createDate = branch.createDate;
                        tempbranch.updateDate = branch.updateDate;
                        tempbranch.createUserId = branch.createUserId;
                        tempbranch.updateUserId = branch.updateUserId;
                        tempbranch.notes = branch.notes;
                        tempbranch.parentId = branch.parentId;
                        tempbranch.isActive = branch.isActive;
                        tempbranch.type = branch.type;
                        


                        parentid = (int)tempbranch.parentId;

                        treebranch.Add(tempbranch);

                    }
                    if (treebranch == null)
                        return NotFound();
                    else
                        //treebranch.Reverse();
                        return Ok(treebranch);

                }


            }
            else
                return NotFound();
        }

        // get Get All branches or stores by type Without Main branch which has id=1  ;
        #region
        [HttpGet]
        [Route("GetAllWithoutMain")]
        public IHttpActionResult GetAllWithoutMain(string type)
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
                        .Where(b => b.type == type && b.branchId != 1)
                   .Select(b => new {
                       b.branchId,
                       b.address,
                       b.createDate,
                       b.createUserId,
                       b.email,
                       b.mobile,
                       b.name,
                       b.code,
                       b.notes,
                       b.parentId,
                       b.phone,
                       b.updateDate,
                       b.updateUserId,
                       b.isActive,
                       b.type
                   })
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
        #endregion
    }
}
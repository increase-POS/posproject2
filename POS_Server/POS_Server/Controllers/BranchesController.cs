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
                   .Select(b => new BranchModel {
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
                       type = b.type })
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
                                if ((parentBrancheL is null) && (posL is null) && (usersL is null))
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
        [Route("GetAll")]
        public IHttpActionResult GetAll()
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
                   .Select(b => new BranchModel
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
            else
                return NotFound();
        }

        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string type, string searchWords)
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
        public string Save(string branchObject)
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
                            entity.SaveChanges();
                            return newObject.branchId.ToString();
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
                            entity.SaveChanges();
                            return newObject.branchId.ToString();
                        }
                        // entity.SaveChanges();
                    }

                }

                catch
                {
                    return "-1";
                }
            }
            else
                return "-1";
        }

        [HttpPost]
        [Route("Delete")]
        public bool Delete(int branchId, int userId, Boolean final)
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
                    while (parentid > 0)
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
            bool canDelete = false;
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
                        .Where(b => (type == "all" ? true : b.type == type) && b.branchId != 1)
                   .Select(b => new BranchModel
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
                                if ((parentBrancheL is null) && (posL is null) && (usersL is null))
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
        #endregion

        [HttpGet]
        [Route("GetBalance")]
        public IHttpActionResult GetBalance(string type)
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
                    var branchesList = (from p in entity.pos
                                        join b in entity.branches on p.branchId equals b.branchId into Jb
                                        from Jbb in Jb.DefaultIfEmpty()
                                        where type == "all" ? true : Jbb.type == type
                                        group new { p, Jbb } by (Jbb.branchId) into g
                                        select new
                                        {
                                            //DateTime.Compare((DateTime)IO.startDate, DateTime.Now) <= 0
                                            branchId = g.Key,
                                            name = g.Select(t => t.Jbb.name).FirstOrDefault(),
                                            balance = g.Sum(x => x.p.balance)
                                        }).ToList();

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
        [Route("GetJoindBrByBranchId")]
        public IHttpActionResult GetJoindBrByBranchId(int branchId)
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
                    var branchesList = (from b in entity.branches

                                        join S in entity.branchStore on b.branchId equals S.storeId into JS
                                        from JSS in JS.DefaultIfEmpty()
                                        where JSS.branchId == branchId
                                        select new BranchModel
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
            else
                return NotFound();
        }




        [HttpGet]
        [Route("BranchesByBranchandUser")]
        public IHttpActionResult BranchesByBranchandUser(int mainBranchId, int userId)
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
                List<BranchModel> Listb = new List<BranchModel>();
                List<BranchModel> Listu = new List<BranchModel>();
                List<BranchModel> List = new List<BranchModel>();
                Listb = BranchesByBranch(mainBranchId);
                Listu = BranchesByUser(userId);

                List = Listb.Union(Listu).ToList().GroupBy(X => X.branchId).Select(X => new BranchModel
                {
                    branchId = X.FirstOrDefault().branchId,

                    code = X.FirstOrDefault().code,
                    name = X.FirstOrDefault().name,
                    address = X.FirstOrDefault().address,
                    email = X.FirstOrDefault().email,
                    phone = X.FirstOrDefault().phone,
                    mobile = X.FirstOrDefault().mobile,
                    createDate = X.FirstOrDefault().createDate,
                    updateDate = X.FirstOrDefault().updateDate,
                    createUserId = X.FirstOrDefault().createUserId,
                    updateUserId = X.FirstOrDefault().updateUserId,
                    notes = X.FirstOrDefault().notes,
                    parentId = X.FirstOrDefault().parentId,
                    isActive = X.FirstOrDefault().isActive,
                    type = X.FirstOrDefault().type,

                }).ToList();
                if (List == null)
                    return NotFound();
                else
                    return Ok(List);
            }
            else
                return NotFound();

        }


        //
        [HttpGet]
        [Route("GetByBranchStor")]
        public IHttpActionResult GetByBranchStor(int mainBranchId)
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
                var List = BranchesByBranch(mainBranchId);
                if (List == null)
                    return NotFound();
                else
                    return Ok(List);
            }
            else
                return NotFound();

        }


        //
        //
        [HttpGet]
        [Route("GetByBranchUser")]
        public IHttpActionResult GetByBranchUser(int userId)
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
                var List = BranchesByUser(userId);
                if (List == null)
                    return NotFound();
                else
                    return Ok(List);
            }
            else
                return NotFound();

        }
//

        public List<BranchModel> BranchesByBranch(int mainBranchId)
        {
            // List<branches> blist = new List<branches>();

            using (incposdbEntities entity = new incposdbEntities())
            {
                List<BranchModel> List = (from S in entity.branchStore
                                          join B in entity.branches on S.branchId equals B.branchId into JBB
                                          join BB in entity.branches on S.storeId equals BB.branchId into JSB
                                          from JBBR in JBB.DefaultIfEmpty()
                                          from JSBB in JSB.DefaultIfEmpty()
                                          where S.branchId == mainBranchId

                                          select new BranchModel
                                          {


                                              //  isActive = S.isActive,

                                              //store
                                              branchId = JSBB.branchId,//
                                              code = JSBB.code,//
                                              name = JSBB.name,//
                                              address = JSBB.address,//
                                              email = JSBB.email,//
                                              phone = JSBB.phone,//
                                              mobile = JSBB.mobile,//
                                              createDate = JSBB.createDate,//
                                              updateDate = JSBB.updateDate,//
                                              createUserId = JSBB.createUserId,//
                                              updateUserId = JSBB.updateUserId,//
                                              notes = JSBB.notes,//
                                              parentId = JSBB.parentId,//
                                              isActive = JSBB.isActive,//
                                              type = JSBB.type,//

                                          }).ToList();

                return List;

            }

        }


    public List<BranchModel> BranchesByUser(int userId)
    {
        using (incposdbEntities entity = new incposdbEntities())
        {
            List<BranchModel> List = (from S in entity.branchesUsers
                                      join B in entity.branches on S.branchId equals B.branchId into JB
                                      join U in entity.users on S.userId equals U.userId into JU
                                      from JBB in JB.DefaultIfEmpty()
                                      from JUU in JU.DefaultIfEmpty()
                                      where S.userId == userId
                                      select new BranchModel()
                                      {

                                          // branch
                                          branchId = JBB.branchId,
                                          code = JBB.code,
                                          name = JBB.name,
                                          address = JBB.address,
                                          email = JBB.email,
                                          phone = JBB.phone,
                                          mobile = JBB.mobile,
                                          createDate = JBB.createDate,
                                          updateDate = JBB.updateDate,
                                          createUserId = JBB.createUserId,
                                          updateUserId = JBB.updateUserId,
                                          notes = JBB.notes,
                                          parentId = JBB.parentId,
                                          isActive = JBB.isActive,
                                          type = JBB.type,

                                      }).ToList();
            return List;
        }

    }



}
}
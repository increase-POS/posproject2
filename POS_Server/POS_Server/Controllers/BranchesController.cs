using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS_Server.Classes;
using POS_Server.Models;
using POS_Server.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Branches")]
    public class BranchesController : ApiController
    {
        [HttpPost]
        [Route("Get")]
        public string Get(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            string type = "";
            Boolean canDelete = false;
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "type")
                    {
                        type = c.Value;
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {


                    var branchesList = entity.branches
                        .Where(b => b.type == type)
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
                    return TokenManager.GenerateToken(branchesList);
                }
            }
        }
        [HttpPost]
        [Route("GetAll")]
        public string GetAll(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
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
                    return TokenManager.GenerateToken(branchesList);
                }
            }
        }
        [HttpPost]
        [Route("GetActive")]
        public string GetActive(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            string type = "";
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "type")
                    {
                        type = c.Value;
                    }
                }
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
                    return TokenManager.GenerateToken(branchesList);


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
                    return TokenManager.GenerateToken(branchesList);
                    }
                }
            }
        }
        // GET api/branch/5
        [HttpPost]
        [Route("GetBranchByID")]
        public string GetBranchByID(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int branchId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {

                    var branch = entity.branches
                   .Where(b => b.branchId == branchId)
                   .Select(b => new { b.branchId, b.address, b.createDate, b.createUserId, b.email, b.mobile, b.name, b.code, b.notes, b.parentId, b.phone, b.updateDate, b.updateUserId })
                   .FirstOrDefault();
                    return TokenManager.GenerateToken(branch);
                }
            }
        }
        [HttpPost]
        [Route("GetBranchTreeByID")]
        public string GetBranchTreeByID(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);

            List<branches> treebranch = new List<branches>();
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int branchId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    int parentid = branchId; // if want to show the last category 
                    while (parentid > 0)
                    {
                        branches tempbranch = new branches();
                        var branch = entity.branches.Where(c => c.branchId == parentid)
                            .Select(p => new
                            {

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
                    return TokenManager.GenerateToken(treebranch);

                }
            }
        }
        // get Get All branches or stores by type Without Main branch which has id=1  ;
        #region
        [HttpPost]
        [Route("GetAllWithoutMain")]
        public string GetAllWithoutMain(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            string type = "";
            Boolean canDelete = false;
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "type")
                    {
                        type = c.Value;
                    }
                }
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
                    return TokenManager.GenerateToken(branchesList);
                }
            }
        }
        #endregion
        [HttpPost]
        [Route("GetBalance")]
        public string GetBalance(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            string type = "";
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "type")
                    {
                        type = c.Value;
                    }
                }
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
                    return TokenManager.GenerateToken(branchesList);
                }
            }
        }
        [HttpPost]
        [Route("GetJoindBrByBranchId")]
        public string GetJoindBrByBranchId(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int branchId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }
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
                    return TokenManager.GenerateToken(branchesList);

                }
            }
        }

        [HttpPost]
        [Route("BranchesByBranchandUser")]
        public string BranchesByBranchandUser(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int mainBranchId = 0;
                int userId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "mainBranchId")
                    {
                        mainBranchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                }
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
                    return TokenManager.GenerateToken(List);
            }
        }


        //
        [HttpPost]
        [Route("GetByBranchStor")]
        public string GetByBranchStor(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int mainBranchId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "mainBranchId")
                    {
                        mainBranchId = int.Parse(c.Value);
                    }
                }
                var List = BranchesByBranch(mainBranchId);
                    return TokenManager.GenerateToken(List);
            }
        }


        //
        //
        [HttpPost]
        [Route("GetByBranchUser")]
        public string GetByBranchUser(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int userId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                }
                var List = BranchesByUser(userId);
                    return TokenManager.GenerateToken(List);

            }
        }

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

        public List<branches> BrListByBranchandUser(int mainBranchId, int userId)
        {
            List<BranchModel> Listb = new List<BranchModel>();
            List<BranchModel> Listu = new List<BranchModel>();
            List<branches> List = new List<branches>();
            Listb = BranchesByBranch(mainBranchId);
            Listu = BranchesByUser(userId);

            List = Listb.Union(Listu).ToList().GroupBy(X => X.branchId).Select(X => new branches
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

            return List;


        }

        // add or update branch
        [HttpPost]
        [Route("Save")]
        public string Save(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            string message = "";
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {

                string branchObject = "";
                branches newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        branchObject = c.Value.Replace("\\", string.Empty);
                        branchObject = branchObject.Trim('"');
                        newObject = JsonConvert.DeserializeObject<branches>(branchObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
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

                            ProgramInfo programInfo = new ProgramInfo();
                            int branchMaxCount = 0;
                            int branchesCount = 0;
                            if (newObject.type == "b")
                            {
                                branchMaxCount = programInfo.getBranchCount();
                                branchesCount = entity.branches.Where(x => x.type == "b").Count();
                            }
                            else if (newObject.type == "s")
                            {
                                branchMaxCount = programInfo.getStroeCount();
                                branchesCount = entity.branches.Where(x => x.type == "s").Count();
                            }
                            if (branchesCount >= branchMaxCount)
                            {
                                message = "-1";
                    return TokenManager.GenerateToken(message);
                            }
                            else
                            {
                                newObject.createDate = DateTime.Now;
                                newObject.updateDate = DateTime.Now;
                                newObject.updateUserId = newObject.createUserId;

                                branchEntity.Add(newObject);
                                entity.SaveChanges();
                                message = newObject.branchId.ToString();
                            }
                    return TokenManager.GenerateToken(message);

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
                            message = newObject.branchId.ToString();
                    return TokenManager.GenerateToken(message);
                        }
                    }
                }
                catch
                {
                    message = "0";
                    return TokenManager.GenerateToken(message);
                }
            }
        }
        [HttpPost]
        [Route("Delete")]
        public string Delete(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            string message = "";
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int branchId = 0;
                int userId = 0;
                Boolean final = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                    else if (c.Type == "final")
                    {
                        final = bool.Parse(c.Value);
                    }
                }
                if (!final)
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            var tmpBranch = entity.branches.Where(p => p.branchId == branchId).First();
                            tmpBranch.isActive = 0;
                            tmpBranch.updateUserId = userId;
                            tmpBranch.updateDate = DateTime.Now;
                            message = entity.SaveChanges().ToString();
                        }

                    return TokenManager.GenerateToken(message);
                    }
                    catch
                    {
                    return TokenManager.GenerateToken("0");
                    }
                   
                }
                else
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            var tmpBranch = entity.branches.Where(p => p.branchId == branchId).First();
                            entity.branches.Remove(tmpBranch);
                            message = entity.SaveChanges().ToString();
                        }
                    return TokenManager.GenerateToken(message);
                    }
                    catch
                    {
                    return TokenManager.GenerateToken("0");
                    }

                }
            }
        }
    }
}
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

    [RoutePrefix("api/BranchesUsers")]
    public class BranchesUsersController : ApiController
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
                    var List = (from S in  entity.branchesUsers  
                                join B in entity.branches on S.branchId equals B.branchId  into JB
                                join U in entity.users on S.userId equals U.userId into JU
                                from JBB in JB.DefaultIfEmpty()
                                from JUU in JU.DefaultIfEmpty()
                                select new BranchesUsersModel()
                                         {
                                            branchsUsersId=S.branchsUsersId,
                                         
                                             branchId =S.branchId,
                                             userId =S.userId,
                                            createDate = S.createDate,
                                            updateDate = S.updateDate,
                                            createUserId = S.createUserId,
                                            updateUserId=S.updateUserId,
                                            // branch
                                              bbranchId=JBB.branchId,
                                              bcode=JBB.code,
                                              bname=JBB.name,
                                              baddress=JBB.address,
                                              bemail=JBB.email,
                                              bphone=JBB.phone,
                                              bmobile=JBB.mobile,
                                              bcreateDate=JBB.createDate,
                                              bupdateDate=JBB.updateDate,
                                              bcreateUserId=JBB.createUserId,
                                              bupdateUserId=JBB.updateUserId,
                                              bnotes=JBB.notes,
                                              bparentId=JBB.parentId,
                                              bisActive= JBB.isActive,
                                              btype=JBB.type,
                                    // user
                                              uuserId=JUU.userId,
                                              uusername=JUU.username,
                                              upassword=JUU.password,
                                              uname=JUU.name,
                                              ulastname=JUU.lastname,
                                              ujob=JUU.job,
                                              uworkHours=JUU.workHours,
                                              ucreateDate=JUU.createDate,
                                              uupdateDate=JUU.updateDate,
                                              ucreateUserId=JUU.createUserId,
                                              uupdateUserId=JUU.updateUserId,
                                              uphone=JUU.phone,
                                              umobile=JUU.mobile,
                                              uemail=JUU.email,
                                              unotes=JUU.notes,
                                              uaddress=JUU.address,
                                              uisActive=JUU.isActive,
                                              uisOnline=JUU.isOnline,

                                              uimage=JUU.image ,


                                }).ToList();

                    /*
                     * 
bbranchId
bcode
bname
baddress
bemail
bphone
bmobile
bcreateDate
bupdateDate
bcreateUserId
bupdateUserId
bnotes
bparentId
bisActive
btype

           

                      public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string job { get; set; }
        public string workHours { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? updateDate { get; set; }
        public int? createUserId { get; set; }
        public int? updateUserId { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string notes { get; set; }
        public string address { get; set; }
        public short? isActive { get; set; }
        public byte? isOnline { get; set; }
        public Boolean canDelete { get; set; }
        public string image { get; set; }

userId
username
password
name
lastname
job
workHours
createDate
updateDate
createUserId
updateUserId
phone
mobile
email
notes
address
isActive
isOnline

image

                     * */



                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            //else
            return NotFound();
        }

        [HttpGet]
        [Route("GetBranchesByUserId")]
        public IHttpActionResult GetBranchesByUserId(int userId)
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
                    var List = (from S in entity.branchesUsers
                                join B in entity.branches on S.branchId equals B.branchId into JB
                                join U in entity.users on S.userId equals U.userId into JU
                                from JBB in JB.DefaultIfEmpty()
                                from JUU in JU.DefaultIfEmpty()
                                where S.userId == userId
                                select new BranchesUsersModel()
                                {
                                    branchsUsersId = S.branchsUsersId,

                                    branchId = S.branchId,
                                    userId = S.userId,
                                    createDate = S.createDate,
                                    updateDate = S.updateDate,
                                    createUserId = S.createUserId,
                                    updateUserId = S.updateUserId,
                                    // branch
                                    bbranchId = JBB.branchId,
                                    bcode = JBB.code,
                                    bname = JBB.name,
                                    baddress = JBB.address,
                                    bemail = JBB.email,
                                    bphone = JBB.phone,
                                    bmobile = JBB.mobile,
                                    bcreateDate = JBB.createDate,
                                    bupdateDate = JBB.updateDate,
                                    bcreateUserId = JBB.createUserId,
                                    bupdateUserId = JBB.updateUserId,
                                    bnotes = JBB.notes,
                                    bparentId = JBB.parentId,
                                    bisActive = JBB.isActive,
                                    btype = JBB.type,
                                    // user
                                    uuserId = JUU.userId,
                                    uusername = JUU.username,
                                    upassword = JUU.password,
                                    uname = JUU.name,
                                    ulastname = JUU.lastname,
                                    ujob = JUU.job,
                                    uworkHours = JUU.workHours,
                                    ucreateDate = JUU.createDate,
                                    uupdateDate = JUU.updateDate,
                                    ucreateUserId = JUU.createUserId,
                                    uupdateUserId = JUU.updateUserId,
                                    uphone = JUU.phone,
                                    umobile = JUU.mobile,
                                    uemail = JUU.email,
                                    unotes = JUU.notes,
                                    uaddress = JUU.address,
                                    uisActive = JUU.isActive,
                                    uisOnline = JUU.isOnline,

                                    uimage = JUU.image,


                                }).ToList();


                    /*
                     
                     * */


                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            //else
            return NotFound();
        }



        // GET api/<controller>
        [HttpGet]
        [Route("GetByID")]
        public IHttpActionResult GetByID(int branchsUsersId)
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
                    var row = entity.branchesUsers
                   .Where(u => u.branchsUsersId == branchsUsersId)
                   .Select(S => new
                   {
                           S.branchsUsersId,


                       S.branchId,
                        S.userId,
                    
                       S.createDate,
                           S.updateDate,
                           S.createUserId,
                           S.updateUserId,
                         
                      


                   })
                   .FirstOrDefault();

                    if (row == null)
                        return NotFound();
                    else
                        return Ok(row);
                }
            }
            else
                return NotFound();
        }

        // add or update location
        [HttpPost]
        [Route("Save")]
        public string Save(string Object)
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
                Object = Object.Replace("\\", string.Empty);
                Object = Object.Trim('"');
                branchesUsers newObject = JsonConvert.DeserializeObject<branchesUsers>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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

                if (newObject.branchId == 0 || newObject.branchId == null)
                {
                    Nullable<int> id = null;
                    newObject.branchId = id;
                }
                if (newObject.userId == 0 || newObject.userId == null)
                {
                    Nullable<int> id = null;
                    newObject.userId = id;
                }

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var locationEntity = entity.Set<branchesUsers>();
                        if (newObject.branchsUsersId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;
                         
                      
                            locationEntity.Add(newObject);
                            entity.SaveChanges();
                            message = newObject.branchsUsersId.ToString();
                        }
                        else
                        {
                            var tmpObject = entity.branchesUsers.Where(p => p.branchsUsersId == newObject.branchsUsersId).FirstOrDefault();

                            tmpObject.updateDate = DateTime.Now;
                            tmpObject.updateUserId = newObject.updateUserId;
                            tmpObject.branchsUsersId = newObject.branchsUsersId;
                                         
                                            tmpObject.branchId = newObject.branchId;
                            tmpObject.userId = newObject.userId;
                           

                            entity.SaveChanges();

                            message = tmpObject.branchsUsersId.ToString();
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
        public string Delete(int branchsUsersId)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int message = 0;
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
                            branchesUsers objectDelete = entity.branchesUsers.Find(branchsUsersId);

                            entity.branchesUsers.Remove(objectDelete);
                        message=    entity.SaveChanges();
                          
                            return message.ToString();
                        }
                    }
                    catch
                    { 
                        return "-1";
                    }
          
            }
            else
                return "-3";
        }


        //update branches list by userId

        #region
        //
        [HttpPost]
        [Route("UpdateBranchByUserId")]
        public string UpdateBranchByUserId(string newList, int userId, int updateUserId)
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

            newList = newList.Replace("\\", string.Empty);
            newList = newList.Trim('"');
            List<branchesUsers> newListObj = JsonConvert.DeserializeObject<List<branchesUsers>>(newList, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

            if (valid)
            {
                // delete old invoice items
               
                using (incposdbEntities entity = new incposdbEntities())
                {
                    List<branchesUsers> items = entity.branchesUsers.Where(x => x.userId == userId).ToList();
                    entity.branchesUsers.RemoveRange(items);
                    try { entity.SaveChanges(); }
                    catch (Exception ex) { return ex.ToString(); }

                }
               
               
                using (incposdbEntities entity = new incposdbEntities())
                {
                    for (int i = 0; i < newListObj.Count; i++)
                    {
                        if (newListObj[i].updateUserId == 0 || newListObj[i].updateUserId == null)
                        {
                            Nullable<int> id = null;
                            newListObj[i].updateUserId = id;
                        }
                        if (newListObj[i].createUserId == 0 || newListObj[i].createUserId == null)
                        {
                            Nullable<int> id = null;
                            newListObj[i].createUserId = id;
                        }
                        if (newListObj[i].branchId == 0 || newListObj[i].branchId == null)
                        {
                            Nullable<int> id = null;
                            newListObj[i].branchId = id;
                        }
                        if (newListObj[i].userId == 0 || newListObj[i].userId == null)
                        {
                            Nullable<int> id = null;
                            newListObj[i].userId = id;
                        }
                        var branchEntity = entity.Set<branchesUsers>();

                        newListObj[i].createDate = DateTime.Now;
                        newListObj[i].updateDate = DateTime.Now;
                        newListObj[i].updateUserId = updateUserId;
                        newListObj[i].userId = userId;
                        branchEntity.Add(newListObj[i]);

                    }
                    try
                    {
                        entity.SaveChanges();
                    }

                    catch
                    {
                        return "false";
                    }
                }
               
            }

            return "true";
        }

        //
        #endregion

    }
}
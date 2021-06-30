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
                                         select new BranchesUsersModel()
                                         {
                                            branchsUsersId=S.branchsUsersId,
                                         
                                             branchId =S.branchId,
                                             userId =S.userId,
                                            createDate = S.createDate,
                                            updateDate = S.updateDate,
                                            createUserId = S.createUserId,
                                            updateUserId=S.updateUserId,
                                        
                                           
                                         }).ToList();
                 


           

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
                                where S.userId==userId
                                select new BranchesUsersModel()
                                {
                                    branchsUsersId = S.branchsUsersId,

                                    branchId = S.branchId,
                                    userId = S.userId,
                                    createDate = S.createDate,
                                    updateDate = S.updateDate,
                                    createUserId = S.createUserId,
                                    updateUserId = S.updateUserId,


                                }).ToList();





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
        [HttpPost]
        [Route("UpdatebranchesByuserId")]
        public int UpdateItemsByOfferId(string newBranchlist)
        {
            int userId = 0;
           
            var re = Request;
            var headers = re.Headers;
            int res = 0;
            string token = "";
            int updateuserId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("userId"))
            {
                userId = Convert.ToInt32(headers.GetValues("userId").First());
            }
            if (headers.Contains("updateuserId"))
            {
                updateuserId = Convert.ToInt32(headers.GetValues("updateuserId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            newBranchlist = newBranchlist.Replace("\\", string.Empty);
            newBranchlist = newBranchlist.Trim('"');
            List<branchesUsers> newObj = JsonConvert.DeserializeObject<List<branchesUsers>>(newBranchlist, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var oldlist = entity.branchesUsers.Where(p => p.userId == userId);
                    if (oldlist.Count() > 0)
                    {
                        entity.branchesUsers.RemoveRange(oldlist);
                    }
                    if (newObj.Count() > 0)
                    {
                        foreach (branchesUsers row in newObj)
                        {
                           row.userId = userId;

                            if (row.createUserId == null ||row.createUserId == 0)
                            {
                               row.createDate = DateTime.Now;
                               row.updateDate = DateTime.Now;

                               row.createUserId = userId;
                               row.updateUserId = userId;
                            }
                            else
                            {
                               row.updateDate = DateTime.Now;
                               row.updateUserId = userId;

                            }

                        }
                        entity.branchesUsers.AddRange(newObj);
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

    }
}
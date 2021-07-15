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
    [RoutePrefix("api/Package")]
    public class PackageController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
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

            if (valid) // APIKey is valid
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var List = (from S in  entity.packages                                         
                                         select new PackageModel()
                                         {
                                       packageId=S.packageId,
                                       parentIUId=S.parentIUId,
                                       childIUId=S.childIUId,
                                       quantity=S.quantity,
                                       isActive=S.isActive,
                                       notes=S.notes,
                                       createUserId=S.createUserId,
                                       updateUserId=S.updateUserId,
                                       createDate=S.createDate,
                                       updateDate=S.updateDate,
                                       canDelete=true,



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
        public IHttpActionResult GetByID(int packageId)
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
                    var row = entity.packages
                   .Where(u => u.packageId == packageId)
                   .Select(S => new
                   {
                      S.packageId,
                      S.parentIUId,
                      S.childIUId,
                      S.quantity,
                        S.isActive,
                     S.notes,
                      S.createUserId,
                       S.updateUserId,
                      S.createDate,
                     S.updateDate,
                

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
        [Route("Savep")]
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
                packages newObject = JsonConvert.DeserializeObject<packages>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                if (newObject.parentIUId == 0 || newObject.parentIUId == null)
                {
                    Nullable<int> id = null;
                    newObject.parentIUId = id;
                }
                if (newObject.childIUId == 0 || newObject.childIUId == null)
                {
                    Nullable<int> id = null;
                    newObject.childIUId = id;
                }

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var locationEntity = entity.Set<packages>();
                        if (newObject.packageId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;
                         
                      
                            locationEntity.Add(newObject);
                            entity.SaveChanges();
                            message = newObject.packageId.ToString();
                        }
                        else
                        {
                            var tmpObject = entity.packages.Where(p => p.packageId == newObject.packageId).FirstOrDefault();

                            tmpObject.updateDate = DateTime.Now;
                            tmpObject.updateUserId = newObject.updateUserId;

                            tmpObject.packageId = newObject.packageId;
                            tmpObject.parentIUId = newObject.parentIUId;
                            tmpObject.childIUId = newObject.childIUId;
                            tmpObject.quantity = newObject.quantity;

                            tmpObject.notes  =newObject.notes;
                            tmpObject.isActive=newObject.isActive;
                            entity.SaveChanges();

                            message = tmpObject.packageId.ToString();
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
        public string Delete(int packageId, int userId,bool final)
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
                if (final)
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            packages objectDelete = entity.packages.Find(packageId);

                            entity.packages.Remove(objectDelete);
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
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            packages objectDelete = entity.packages.Find(packageId);

                            objectDelete.isActive = 0;
                            objectDelete.updateUserId = userId;
                            objectDelete.updateDate = DateTime.Now;
                            message= entity.SaveChanges();

                            return message.ToString(); ;
                        }
                    }
                    catch
                    {
                        return "-2";
                    }
                }
            }
            else
                return "-3";
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetChildsByParentI")]
        public IHttpActionResult GetChildsByParentI(int parentIUId)
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
                    var list = entity.packages
                   .Where(u => u.parentIUId == parentIUId)
                   .Select(S => new
                   {
                       S.packageId,
                       S.parentIUId,
                       S.childIUId,
                       S.quantity,
                       S.isActive,
                       S.notes,
                       S.createUserId,
                       S.updateUserId,
                       S.createDate,
                       S.updateDate,


                   })
                   .ToList();

                    if (list == null)
                        return NotFound();
                    else
                        return Ok(list);
                }
            }
            else
                return NotFound();
        }

        #region
        [HttpPost]
        [Route("UpdatePackByParentId")]
        public int UpdatePackByParentId(string newplist)
        {
            int userId = 0;
            int parentIUId = 0;
            var re = Request;
            var headers = re.Headers;
            int res = 0;
            string token = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("parentIUId"))
            {
                parentIUId = Convert.ToInt32(headers.GetValues("parentIUId").First());
            }
            if (headers.Contains("userId"))
            {
                userId = Convert.ToInt32(headers.GetValues("userId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            newplist = newplist.Replace("\\", string.Empty);
            newplist = newplist.Trim('"');
            List<packages> newitofObj = JsonConvert.DeserializeObject<List<packages>>(newplist, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var iuoffer = entity.packages.Where(p => p.parentIUId == parentIUId);
                    if (iuoffer.Count() > 0)
                    {
                        entity.packages.RemoveRange(iuoffer);
                    }
                    if (newitofObj.Count() > 0)
                    {
                        foreach (packages newitofrow in newitofObj)
                        {
                            newitofrow.parentIUId = parentIUId;

                            if (newitofrow.createUserId == null || newitofrow.createUserId == 0)
                            {
                                newitofrow.createDate = DateTime.Now;
                                newitofrow.updateDate = DateTime.Now;

                                newitofrow.createUserId = userId;
                                newitofrow.updateUserId = userId;
                            }
                            else
                            {
                                newitofrow.updateDate = DateTime.Now;
                                newitofrow.updateUserId = userId;

                            }

                        }
                        entity.packages.AddRange(newitofObj);
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
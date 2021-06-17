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
    [RoutePrefix("api/Sections")]
    public class SectionController : ApiController
    {
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
                    var sectionList =(from L in entity.sections join b in entity.branches on L.branchId equals b.branchId into lj
                                      from v in lj.DefaultIfEmpty()
                                      select new SectionModel()
                                        {
                                          sectionId=  L.sectionId,
                                            name=   L.name,
                                            isActive=  L.isActive,
                                            branchId=  L.branchId,
                                            note=   L.note,
                                            branchName = v.name,
                                            createDate=  L.createDate,
                                            updateDate=    L.updateDate,
                                            createUserId=  L.createUserId,
                                            updateUserId=  L.updateUserId,
                       
                                        })
                                        .ToList();

                    if (sectionList.Count > 0)
                    {// for each 
                        for (int i = 0; i < sectionList.Count; i++)
                        {
                            if (sectionList[i].isActive == 1)
                            {
                                int sectionId = (int)sectionList[i].sectionId;
                                var LocationL = entity.locations.Where(x => x.sectionId == sectionId).Select(b => new { b.locationId }).FirstOrDefault();
                                //var itemsTransferL = entity.itemsTransfer.Where(x => x.locationIdNew == locationId || x.locationIdOld == locationId).Select(x => new { x.itemsTransId }).FirstOrDefault();
                               
                                if ((LocationL is null)  )
                                    canDelete = true;
                            }
                            sectionList[i].canDelete = canDelete;
                        }
                    }

                    if (sectionList == null)
                        return NotFound();
                    else
                        return Ok(sectionList);
                }
            }
            //else
            return NotFound();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetSectionByID")]
        public IHttpActionResult GetSectionByID(int sectionId)
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
                    var location = entity.sections
                   .Where(u => u.sectionId == sectionId)
                   .Select(L => new SectionModel
                   {
                       sectionId = L.sectionId,
                       name = L.name,
                       isActive = L.isActive,
                       branchId = L.branchId,
                       note = L.note,
                      
                       createDate = L.createDate,
                       updateDate = L.updateDate,
                       createUserId = L.createUserId,
                       updateUserId = L.updateUserId,

                   })
                   .FirstOrDefault();

                    if (location == null)
                        return NotFound();
                    else
                        return Ok(location);
                }
            }
            else
                return NotFound();
        }

        // add or update location
        [HttpPost]
        [Route("Save")]
        public string Save(string sectionObject)
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
                sectionObject = sectionObject.Replace("\\", string.Empty);
                sectionObject = sectionObject.Trim('"');
                sections newObject = JsonConvert.DeserializeObject<sections>(sectionObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var sectionEntity = entity.Set<sections>();
                        if (newObject.sectionId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;

                            sectionEntity.Add(newObject);
                            message = "Section Is Added Successfully";
                        }
                        else
                        {
                            var tmpSection = entity.sections.Where(p => p.sectionId == newObject.sectionId).FirstOrDefault();
                            tmpSection.name = newObject.name;
                            tmpSection.branchId = newObject.branchId;
                            tmpSection.isActive = newObject.isActive;
                            tmpSection.note = newObject.note;
                            tmpSection.updateDate = DateTime.Now;
                            tmpSection.updateUserId = newObject.updateUserId;
                          
                            message = "Section Is Updated Successfully";
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
        public bool Delete(int sectionId, int userId,Boolean final)
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
                            sections sectionDelete = entity.sections.Find(sectionId);

                            entity.sections.Remove(sectionDelete);
                            entity.SaveChanges();

                            return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            sections sectionDelete = entity.sections.Find(sectionId);

                            sectionDelete.isActive = 0;
                            sectionDelete.updateUserId = userId;
                            sectionDelete.updateDate = DateTime.Now;
                            entity.SaveChanges();

                            return true;
                        }
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
    }
}
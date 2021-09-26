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
    [RoutePrefix("api/BranchStore")]
    public class BranchStoreController : ApiController
    {
        // GET api/<controller> get all Objects
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
                    var List = (from S in entity.branchStore
                                 join B in entity.branches on S.branchId equals B.branchId into JBB 
                                 join BB in entity.branches on S.storeId equals BB.branchId into JSB
                                from JBBR in JBB.DefaultIfEmpty()
                                from JSBB in JSB.DefaultIfEmpty()
                                select new BranchStoreModel {
                      id = S.id,
                       branchId = S.branchId,
                       storeId = S.storeId,
                       note = S.note,
                    
                       createDate = S.createDate,
                       updateDate = S.updateDate,
                       createUserId = S.createUserId,
                       updateUserId = S.updateUserId,
                       isActive=S.isActive,
                       canDelete = true,
                                    // branch
                                    bbranchId = JSBB.branchId,
                                    bcode = JBBR.code,
                                    bname = JBBR.name,
                                    baddress = JBBR.address,
                                    bemail = JBBR.email,
                                    bphone = JBBR.phone,
                                    bmobile = JBBR.mobile,
                                    bcreateDate = JBBR.createDate,
                                    bupdateDate = JBBR.updateDate,
                                    bcreateUserId = JBBR.createUserId,
                                    bupdateUserId = JBBR.updateUserId,
                                    bnotes = JBBR.notes,
                                    bparentId = JBBR.parentId,
                                    bisActive = JBBR.isActive,
                                    btype = JBBR.type,
                                    //store
                                    sbranchId = JSBB.branchId,
                                    scode = JSBB.code,
                                    sname = JSBB.name,
                                    saddress = JSBB.address,
                                    semail = JSBB.email,
                                    sphone = JSBB.phone,
                                    smobile = JSBB.mobile,
                                    screateDate = JSBB.createDate,
                                    supdateDate = JSBB.updateDate,
                                    screateUserId = JSBB.createUserId,
                                    supdateUserId = JSBB.updateUserId,
                                    snotes = JSBB.notes,
                                    sparentId = JSBB.parentId,
                                    sisActive = JSBB.isActive,
                                    stype = JSBB.type,

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
        [Route("GetByBranchId")]
        public IHttpActionResult GetByBranchId(int branchId)
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
                    var List = (from S in entity.branchStore
                                join B in entity.branches on S.branchId equals B.branchId into JBB
                                join BB in entity.branches on S.storeId equals BB.branchId into JSB
                                from JBBR in JBB.DefaultIfEmpty()
                                from JSBB in JSB.DefaultIfEmpty()
                                where S.branchId == branchId

                                select new BranchStoreModel
                                {
                                    id = S.id,
                                    branchId = S.branchId,
                                    storeId = S.storeId,
                                    note = S.note,

                                    createDate = S.createDate,
                                    updateDate = S.updateDate,
                                    createUserId = S.createUserId,
                                    updateUserId = S.updateUserId,
                                    isActive = S.isActive,
                                    canDelete = true,
                                    // branch
                                    bbranchId = JSBB.branchId,
                                    bcode = JBBR.code,
                                    bname = JBBR.name,
                                    baddress = JBBR.address,
                                    bemail = JBBR.email,
                                    bphone = JBBR.phone,
                                    bmobile = JBBR.mobile,
                                    bcreateDate = JBBR.createDate,
                                    bupdateDate = JBBR.updateDate,
                                    bcreateUserId = JBBR.createUserId,
                                    bupdateUserId = JBBR.updateUserId,
                                    bnotes = JBBR.notes,
                                    bparentId = JBBR.parentId,
                                    bisActive = JBBR.isActive,
                                    btype = JBBR.type,
                                    //store
                                    sbranchId = JSBB.branchId,
                                    scode = JSBB.code,
                                    sname = JSBB.name,
                                    saddress = JSBB.address,
                                    semail = JSBB.email,
                                    sphone = JSBB.phone,
                                    smobile = JSBB.mobile,
                                    screateDate = JSBB.createDate,
                                    supdateDate = JSBB.updateDate,
                                    screateUserId = JSBB.createUserId,
                                    supdateUserId = JSBB.updateUserId,
                                    snotes = JSBB.notes,
                                    sparentId = JSBB.parentId,
                                    sisActive = JSBB.isActive,
                                    stype = JSBB.type,

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


        // GET api/<controller>  Get medal By ID 
        [HttpGet]
        [Route("GetByID")]
        public IHttpActionResult GetByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int cId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("Id"))
            {
                cId = Convert.ToInt32(headers.GetValues("Id").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var list = entity.branchStore
                   .Where(c => c.id == cId)
                   .Select(c => new {
                    c.id,
                    c.branchId,
                    c.storeId,
                    c.note,
                    c.createDate,
                    c.updateDate,
                    c.createUserId,
                    c.updateUserId,
                    c.isActive,
                   })
                   .FirstOrDefault();

                    if (list == null)
                        return NotFound();
                    else
                        return Ok(list);
                }
            }
            else
                return NotFound();
        }


        // add or update 
        [HttpPost]
        [Route("Save")]
        public String Save(string newObject)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string message ="";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            
            if (valid)
            {
                newObject = newObject.Replace("\\", string.Empty);
                newObject = newObject.Trim('"');
                branchStore Object = JsonConvert.DeserializeObject<branchStore>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    if (Object.branchId == 0 || Object.branchId == null)
                    {
                        Nullable<int> id = null;
                        Object.branchId = id;
                    }

                    if (Object.storeId == 0 || Object.storeId == null)
                    {
                        Nullable<int> id = null;
                        Object.storeId = id;
                    }
                    if (Object.updateUserId == 0 || Object.updateUserId == null)
                    {
                        Nullable<int> id = null;
                        Object.updateUserId = id;
                    }
                    if (Object.createUserId == 0 || Object.createUserId == null)
                    {
                        Nullable<int> id = null;
                        Object.createUserId = id;
                    }
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var sEntity = entity.Set<branchStore>();
                        if (Object.id == 0)
                        {
                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            sEntity.Add(Object);
                             message = Object.id.ToString();
                            entity.SaveChanges();
                        }
                        else
                        {

                            var tmps = entity.branchStore.Where(p => p.id == Object.id).FirstOrDefault();

                            tmps.id = Object.id;
                            tmps.branchId = Object.branchId;
                            tmps.storeId = Object.storeId;
                            tmps.note = Object.note;
                            tmps.isActive = Object.isActive;
                            tmps.note = Object.note;
                            tmps.note=Object.note;
                            tmps.createDate=Object.createDate;
                            tmps.updateDate = DateTime.Now;// server current date
                            
                            tmps.updateUserId = Object.updateUserId;
                            entity.SaveChanges();
                            message = tmps.id.ToString();
                        }
                       
                       
                    }
                    return message; ;
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
        public IHttpActionResult Delete(int Id, int userId, bool final)
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

                            branchStore Deleterow = entity.branchStore.Find(Id);
                            entity.branchStore.Remove(Deleterow);
                            entity.SaveChanges();
                            return Ok("OK");
                        }
                    }
                    catch
                    {
                        return NotFound();
                    }
                }
                else
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {

                            branchStore Obj = entity.branchStore.Find(Id);
                            Obj.isActive = 0;
                            Obj.updateUserId = userId;
                            Obj.updateDate = DateTime.Now;
                            entity.SaveChanges();
                            return Ok("Ok");
                        }
                    }
                    catch
                    {
                        return NotFound();
                    }
                }



            }
            else
                return NotFound();
        }

        //
        [HttpPost]
        [Route("UpdateStoresById")]
        public bool UpdateStoresById(string newList, int branchId,int userId)
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

            List<branchStore> newListObj = JsonConvert.DeserializeObject<List<branchStore>>(newList, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

            if (valid)
            {
                // delete old invoice items
                using (incposdbEntities entity = new incposdbEntities())
                {
                    List<branchStore> items = entity.branchStore.Where(x => x.branchId == branchId).ToList();
                    entity.branchStore.RemoveRange(items);
                    try { entity.SaveChanges(); }
                    catch { }

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
                        if (newListObj[i].storeId == 0 || newListObj[i].storeId == null)
                        {
                            Nullable<int> id = null;
                            newListObj[i].storeId = id;
                        }
                        var branchEntity = entity.Set<branchStore>();

                        newListObj[i].createDate = DateTime.Now;
                        newListObj[i].updateDate = DateTime.Now;
                        newListObj[i].updateUserId = newListObj[i].createUserId;
                        newListObj[i].branchId = branchId;
                        branchEntity.Add(newListObj[i]);

                    }
                    try
                    {
                        entity.SaveChanges();
                    }

                    catch
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        //

    }
}
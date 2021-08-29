using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Migrations;
namespace POS_Server.Controllers
{
    [RoutePrefix("api/categoryuser")]
    public class CategoryuserController : ApiController
    {
        // GET api/<controller> get all categoryuser
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
                    var List = entity.categoryuser

                   .Select(c => new
                   {
                       c.id,
                       c.categoryId,
                       c.userId,
                       c.sequence,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,

                   })
                   .ToList();

                    /*
                     * 
    public int id { get; set; }
        public Nullable<int> categoryId { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> sequence { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
    
    
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
        [Route("GetByUserId")]
        public IHttpActionResult GetByUserId(int userId)
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
                    var List = (from cu in entity.categoryuser
                                join c in entity.categories on cu.categoryId equals c.categoryId
                                where cu.userId == userId

                                select new
                                {
                                    cu.id,

                                    cu.userId,
                                    cu.sequence,
                                    cu.createDate,
                                    cu.updateDate,
                                    cu.createUserId,
                                    cu.updateUserId,
                                    cu.categoryId,
                                    //category

                                    c.name,
                                    c.categoryCode,

                                    c.details,
                                    c.image,
                                    c.notes,
                                    c.parentId,
                                    c.taxes,

                                    c.isActive,
                                })
                   .ToList();



                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            //else
            return NotFound();
        }


        #region
        [HttpPost]
        [Route("UpdateCatByUsrId")]

        public int UpdateCatByUsrId(string newlist)
        {
            int usrId = 0;
            var re = Request;
            var headers = re.Headers;
            int res = 0;
            string token = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("usrId"))
            {
                usrId = Convert.ToInt32(headers.GetValues("usrId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            newlist = newlist.Replace("\\", string.Empty);
            newlist = newlist.Trim('"');
            List<categoryuser> newCatlist = JsonConvert.DeserializeObject<List<categoryuser>>(newlist, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var oldList = entity.categoryuser.Where(p => p.userId == usrId);
                    if (oldList.Count() > 0)
                    {
                        entity.categoryuser.RemoveRange(oldList);
                    }
                    if (newCatlist.Count() > 0)
                    {
                        foreach (categoryuser newcatRow in newCatlist)
                        {
                            newcatRow.userId = usrId;
                            if (newcatRow.createDate == null)
                            {
                                newcatRow.createDate = DateTime.Now;
                                newcatRow.updateDate = DateTime.Now;
                                newcatRow.updateUserId = newcatRow.createUserId;
                            }
                            else
                            {
                                newcatRow.updateDate = DateTime.Now;
                            }




                        }
                        entity.categoryuser.AddRange(newCatlist);
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




        #region
        [HttpPost]
        [Route("UpdateCatUserList")]

        public string UpdateCatUserList(string newlist)
        {
            int userId = 0;
            var re = Request;
            var headers = re.Headers;
            int res = 0;
            string token = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("userId"))
            {
                userId = Convert.ToInt32(headers.GetValues("userId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            newlist = newlist.Replace("\\", string.Empty);
            newlist = newlist.Trim('"');
            List<categoryuser> newCatlist = JsonConvert.DeserializeObject<List<categoryuser>>(newlist, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {

                    if (newCatlist.Count() > 0)
                    {
                        categoryuser oldrow = new categoryuser();

                        foreach (categoryuser newcatRow in newCatlist)
                        {
                            oldrow = entity.categoryuser.ToList()
                                .Where(X => X.id == newcatRow.id).FirstOrDefault();
                            //if(newcatRow.id>0)
                            oldrow.userId = userId;
                            oldrow.categoryId = newcatRow.categoryId;
                            oldrow.sequence = newcatRow.sequence;

                            if (oldrow.createDate == null)
                            {
                                oldrow.createDate = DateTime.Now;
                                oldrow.updateDate = DateTime.Now;
                                oldrow.updateUserId = newcatRow.createUserId;
                            }
                            else
                            {
                                oldrow.updateDate = DateTime.Now;

                            }

                            entity.categoryuser.AddOrUpdate(oldrow);
                            res = entity.SaveChanges();
                        }

                    }


                    return res.ToString();


                }

            }
            else
            {
                return "-1";
            }

        }
        #endregion


        // GET api/<controller>  Get  By ID 
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
                    var list = entity.categoryuser
                   .Where(c => c.id == cId)
                   .Select(c => new
                   {
                       c.id,
                       c.categoryId,
                       c.userId,
                       c.sequence,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,


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
            string message = "";
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
                categoryuser Object = JsonConvert.DeserializeObject<categoryuser>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    if (Object.userId == 0 || Object.userId == null)
                    {
                        Nullable<int> id = null;
                        Object.userId = id;
                    }
                    if (Object.categoryId == 0 || Object.categoryId == null)
                    {
                        Nullable<int> id = null;
                        Object.categoryId = id;
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
                        var sEntity = entity.Set<categoryuser>();
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

                            var tmps = entity.categoryuser.Where(p => p.id == Object.id).FirstOrDefault();

                            tmps.id = Object.id;

                            tmps.categoryId = Object.categoryId;
                            tmps.userId = Object.userId;
                            tmps.sequence = Object.sequence;
                            tmps.createDate = Object.createDate;
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
        public IHttpActionResult Delete(int Id)
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
                        categoryuser sObj = entity.categoryuser.Find(Id);

                        entity.categoryuser.Remove(sObj);
                        entity.SaveChanges();

                        return Ok(" Deleted Successfully");
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

        [HttpGet]
        [Route("GetSubCategoriesSeq")]
        public IHttpActionResult GetSubCategories(int categoryId, int userId)
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
                    if (categoryId != 0)
                    {
                        var categoriesList = (from C in entity.categories
                                              join S in entity.categoryuser on C.categoryId equals S.categoryId into jS
                                              from jSS in jS.DefaultIfEmpty()
                                              select new
                                              {
                                                  C.categoryId,
                                                  C.name,
                                                  C.categoryCode,
                                                  C.createDate,
                                                  C.createUserId,
                                                  C.details,
                                                  C.image,
                                                  C.notes,
                                                  C.parentId,
                                                  C.taxes,
                                                  C.updateDate,
                                                  C.updateUserId,
                                                  C.isActive,
                                                  jSS.sequence,
                                                  jSS.userId,
                                              }


                      ).Where(c => c.parentId == categoryId && c.isActive == 1 && c.userId == userId).OrderBy(c => c.sequence)

                       .ToList();
                        if (categoriesList == null)
                            return NotFound();
                        else
                            return Ok(categoriesList);
                    }
                    else
                    {
                        var categoriesList = (from C in entity.categories
                                              join S in entity.categoryuser on C.categoryId equals S.categoryId into jS
                                              from jSS in jS.DefaultIfEmpty()
                                              select new
                                              {
                                                  C.categoryId,
                                                  C.name,
                                                  C.categoryCode,
                                                  C.createDate,
                                                  C.createUserId,
                                                  C.details,
                                                  C.image,
                                                  C.notes,
                                                  C.parentId,
                                                  C.taxes,
                                                  C.updateDate,
                                                  C.updateUserId,
                                                  C.isActive,
                                                  jSS.sequence,
                                                  jSS.userId,
                                              }


                      ).Where(c => c.parentId == 0 && c.isActive == 1 && c.userId == userId)
                       .ToList();
                        if (categoriesList == null)
                            return NotFound();
                        else
                            return Ok(categoriesList);
                    }
                }
            }
            else
                return NotFound();
        }


        [HttpGet]
        [Route("GetCatTreeByIdSeq")]
        public IHttpActionResult GetCatTreeByIdSeq(int categoryID, int userId)
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
            List<categories> treecat = new List<categories>();

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
                    int parentid = categoryID; // if want to show the last category 
                    while (parentid > 0)
                    {
                        categories tempcate = new categories();
                        var category = (from C in entity.categories
                                        join S in entity.categoryuser on C.categoryId equals S.categoryId into jS
                                        from jSS in jS.DefaultIfEmpty()
                                        select new
                                        {
                                            C.categoryId,
                                            C.name,
                                            C.categoryCode,
                                            C.createDate,
                                            C.createUserId,
                                            C.details,
                                            C.image,
                                            C.notes,
                                            C.parentId,
                                            C.taxes,
                                            C.updateDate,
                                            C.updateUserId,
                                            C.isActive,
                                            jSS.sequence,
                                            jSS.userId,
                                        }


                      ).Where(c => c.categoryId == parentid && c.userId == userId).OrderBy(c => c.sequence)
                          .FirstOrDefault();


                        tempcate.categoryId = category.categoryId;

                        tempcate.name = category.name;
                        tempcate.categoryCode = category.categoryCode;
                        tempcate.createDate = category.createDate;
                        tempcate.createUserId = category.createUserId;
                        tempcate.details = category.details;
                        tempcate.image = category.image;
                        tempcate.notes = category.notes;
                        tempcate.parentId = category.parentId;
                        tempcate.taxes = category.taxes;
                        tempcate.updateDate = category.updateDate;
                        tempcate.updateUserId = category.updateUserId;


                        parentid = (int)tempcate.parentId;

                        treecat.Add(tempcate);

                    }
                    if (treecat == null)
                        return NotFound();
                    else
                        //treecat.Reverse();
                        return Ok(treecat);

                }


            }
            else
                return NotFound();
        }
    }
}
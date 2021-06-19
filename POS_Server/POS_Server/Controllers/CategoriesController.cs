using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        // GET api/category

        [HttpGet]
        [Route("GetAllCategories")]
        public IHttpActionResult GetAllCategories()
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
                    var categoriesList = entity.categories
                    .Select(p => new CategoryModel{
                      categoryId=  p.categoryId,
                        name= p.name,
                        categoryCode= p.categoryCode,
                        createDate=  p.createDate,
                        createUserId=p.createUserId,
                        details= p.details,
                        image=p.image,
                        notes= p.notes,
                        parentId=p.parentId,
                        taxes= p.taxes,
                        updateDate=p.updateDate,
                        updateUserId= p.updateUserId,
                        isActive= p.isActive,
                    })
                    .ToList();

                    if (categoriesList.Count > 0)
                    {
                        for (int i = 0; i < categoriesList.Count; i++)
                        {
                            canDelete = false;
                            if (categoriesList[i].isActive == 1)
                            {
                                int categoryId = (int)categoriesList[i].categoryId;
                                var items = entity.items.Where(x => x.categoryId == categoryId).Select(b => new { b.itemId }).FirstOrDefault();
                                var childCategoryL = entity.categories.Where(x => x.parentId == categoryId).Select(b => new { b.categoryId }).FirstOrDefault();

                                if ((items is null) && (childCategoryL is null))
                                    canDelete = true;
                            }
                            categoriesList[i].canDelete = canDelete;
                        }
                    }
                    if (categoriesList == null)
                        return NotFound();
                    else
                        return Ok(categoriesList);

                }
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetSubCategories")]
        public IHttpActionResult GetSubCategories(int categoryId)
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
                    if (categoryId !=  0)
                    {
                        var categoriesList = entity.categories
                       .Where(c => c.parentId == categoryId && c.isActive == 1)
                       .Select(p => new {
                           p.categoryId,
                           p.name,
                           p.categoryCode,
                           p.createDate,
                           p.createUserId,
                           p.details,
                           p.image,
                           p.notes,
                           p.parentId,
                           p.taxes,
                           p.updateDate,
                           p.updateUserId,
                           })
                       .ToList();
                        if (categoriesList == null)
                            return NotFound();
                        else
                            return Ok(categoriesList);
                    }
                    else
                    {
                        var categoriesList = entity.categories
                       .Where(c => c.parentId == 0 && c.isActive == 1)
                       .Select(p => new {
                           p.categoryId,
                           p.name,
                           p.categoryCode,
                           p.createDate,
                           p.createUserId,
                           p.details,
                           p.image,
                           p.notes,
                           p.parentId,
                           p.taxes,
                           p.updateDate,
                           p.updateUserId,
                       })
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
        // GET api/category/5
        [HttpGet]
        [Route("GetCategoryByID")]
        public IHttpActionResult GetCategoryByID(int categoryId)
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

                    var category = entity.categories
                   .Where(c => c.categoryId == categoryId)
                   .Select(p => new {
                       p.categoryId,
                       p.name,
                       p.categoryCode,
                       p.createDate,
                       p.createUserId,
                       p.details,
                       p.image,
                       p.notes,
                       p.parentId,
                       p.taxes,
                       p.updateDate,
                       p.updateUserId,
                   })
                   .FirstOrDefault();

                    if (category == null)
                        return NotFound();
                    else
                        return Ok(category);

                }
            }
            else
                return NotFound();
        }

        // add or update category
        [HttpPost]
        [Route("Save")]
        public int Save(string categoryObject)
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
                categoryObject = categoryObject.Replace("\\", string.Empty);
                categoryObject = categoryObject.Trim('"');

                categories newObject = JsonConvert.DeserializeObject<categories>(categoryObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                    categories tmpCategory;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var categoryEntity = entity.Set<categories>();                      
                        if (newObject.categoryId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;

                            tmpCategory= categoryEntity.Add(newObject); 
                        }
                        else
                        {
                            tmpCategory = entity.categories.Where(p => p.categoryId == newObject.categoryId).First();
                            tmpCategory.categoryCode = newObject.categoryCode;
                            tmpCategory.details = newObject.details;
                            tmpCategory.name = newObject.name;
                            tmpCategory.notes = newObject.notes;
                            tmpCategory.parentId = newObject.parentId;
                            tmpCategory.taxes = newObject.taxes;
                            tmpCategory.updateDate = DateTime.Now;
                            tmpCategory.updateUserId = newObject.updateUserId;
                            tmpCategory.isActive = newObject.isActive;

                        }
                        entity.SaveChanges();                       
                    }
                    return tmpCategory.categoryId;
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }
        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int categoryId , int userId , Boolean final)
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
                            var childCategories = entity.categories.Where(u => u.parentId == categoryId && u.isActive == 1).FirstOrDefault();

                            if (childCategories == null)
                            {
                                var tmpCategory = entity.categories.Where(p => p.categoryId == categoryId).First();
                                entity.categories.Remove(tmpCategory);

                                entity.SaveChanges();
                                return Ok("Category is Deleted Successfully");
                            }
                            else
                                return Ok("Can't Delete This Category");
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
                            var childCategories = entity.categories.Where(u => u.parentId == categoryId && u.isActive == 1).FirstOrDefault();

                            if (childCategories == null)
                            {
                                var tmpCategory = entity.categories.Where(p => p.categoryId == categoryId).First();
                                tmpCategory.isActive = 0;
                                tmpCategory.updateDate = DateTime.Now;
                                tmpCategory.updateUserId = userId;

                                entity.SaveChanges();
                                return Ok("Category is Deleted Successfully");
                            }
                            else
                                return Ok("Can't Delete This Category");
                        }
                    }
                    catch
                    {
                        return NotFound();
                    }
                }
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetCategoryTreeByID")]
        public IHttpActionResult GetCategoryTreeByID(int categoryID)
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
                    while (parentid > 0 )
                    {
                        categories tempcate = new categories();
                        var category = entity.categories.Where(c => c.categoryId == parentid)
                            .Select(p => new {
                                p.categoryId,
                                p.name,
                                p.categoryCode,
                                p.createDate,
                                p.createUserId,
                                p.details,
                                p.image,
                                p.notes,
                                p.parentId,
                                p.taxes,
                                p.updateDate,
                                p.updateUserId,
                            }).FirstOrDefault();


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

                        //if (tempcate.parentId == null)
                        //{
                        //    Nullable<int> tmpid = null;
                        //    parentid = 0;

                        //}

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

        [Route("PostCategoryImage")]
        public IHttpActionResult PostCategoryImage()
        {

            try
            {
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    string imageName = postedFile.FileName;
                    string imageWithNoExt = Path.GetFileNameWithoutExtension(postedFile.FileName);

                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png", ".bmp", ".jpeg", ".tiff" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();

                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");
                            return Ok(message);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            return Ok(message);
                        }
                        else
                        {
                            //  check if image exist
                            var pathCheck = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\category"), imageWithNoExt);
                            var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\category"), imageWithNoExt + ".*");
                            if (files.Length > 0)
                            {
                                File.Delete(files[0]);
                            }

                            //Userimage myfolder name where i want to save my image
                            var filePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\category"), imageName);
                            postedFile.SaveAs(filePath);

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Ok(message1);
                }
                var res = string.Format("Please Upload a image.");

                return Ok(res);
            }
            catch
            {
                var res = string.Format("some Message");

                return Ok(res);
            }
        }

        [HttpGet]
        [Route("GetImage")]
        public HttpResponseMessage GetImage(string imageName)
        {
            if (String.IsNullOrEmpty(imageName))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            string localFilePath;

            localFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\category"), imageName);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = imageName;

            return response;
        }
        [HttpPost]
        [Route("UpdateImage")]
        public int UpdateImage(string categoryObject)
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

            categoryObject = categoryObject.Replace("\\", string.Empty);
            categoryObject = categoryObject.Trim('"');

            categories catObj = JsonConvert.DeserializeObject<categories>(categoryObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (catObj.updateUserId == 0 || catObj.updateUserId == null)
            {
                Nullable<int> id = null;
                catObj.updateUserId = id;
            }
            if (catObj.createUserId == 0 || catObj.createUserId == null)
            {
                Nullable<int> id = null;
                catObj.createUserId = id;
            }
            if (valid)
            {
                try
                {
                    categories category;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var agentEntity = entity.Set<agents>();
                        category = entity.categories.Where(p => p.categoryId == catObj.categoryId).First();
                        category.image = catObj.image;
                        entity.SaveChanges();
                    }
                    return category.categoryId;
                }

                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }


        [HttpGet]
        [Route("GetSubCategoriesSeq")]
        public IHttpActionResult GetSubCategoriesSeq(int categoryId, int userId)
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

    }
}
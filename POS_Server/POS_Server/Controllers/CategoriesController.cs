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
        public string Save(string categoryObject)
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
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var categoryEntity = entity.Set<categories>();
                        if (newObject.categoryId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;

                            categoryEntity.Add(newObject);
                            message = "Category Is Added Successfully";
                        }
                        else
                        {
                            var tmpCategory = entity.categories.Where(p => p.categoryId == newObject.categoryId).First();
                            tmpCategory.categoryCode = newObject.categoryCode;
                            tmpCategory.details = newObject.details;
                            tmpCategory.image = newObject.image;
                            tmpCategory.name = newObject.name;
                            tmpCategory.notes = newObject.notes;
                            tmpCategory.parentId = newObject.parentId;
                            tmpCategory.taxes = newObject.taxes;
                            tmpCategory.updateDate = DateTime.Now;
                            tmpCategory.updateUserId = newObject.updateUserId;
                            tmpCategory.isActive = newObject.isActive;

                            message = "Category Is Updated Successfully";
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
    }
}
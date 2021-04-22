using Newtonsoft.Json;
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
                            categoryEntity.Add(newObject);
                            message = "Category Is Added Successfully";
                        }
                        else
                        {
                            var tmpCategory = entity.categories.Where(p => p.categoryId == newObject.categoryId).First();
                            tmpCategory.categoryCode= newObject.categoryCode;
                            tmpCategory.details = newObject.details;
                            tmpCategory.image = newObject.image;
                            tmpCategory.name = newObject.name;
                            tmpCategory.notes = newObject.notes;
                            tmpCategory.parentId = newObject.parentId;
                            tmpCategory.taxes = newObject.taxes;
                            tmpCategory.updateDate = newObject.updateDate;
                            tmpCategory.updateUserId = newObject.updateUserId;
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
        public IHttpActionResult Delete(int categoryId , int userId)
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
                        var childCategories = entity.categories.Where(u => u.parentId == categoryId && u.isActive ==1).FirstOrDefault();
  
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
            return NotFound();
        }
    }
}
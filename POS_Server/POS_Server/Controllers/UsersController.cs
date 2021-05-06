using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        //get active users
        [HttpGet]
        [Route("GetActive")]
        public IHttpActionResult GetActive()
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
                    var usersList = entity.users.Where( u => u.isActive == 1)
                    .Select(u => new
                    {
                        u.userId,
                        u.username,
                        u.password,
                        u.name,
                        u.lastname,
                        u.job,
                        u.workHours,
                        u.createDate,
                        u.updateDate,
                        u.createUserId,
                        u.updateUserId,
                        u.phone,
                        u.mobile,
                        u.email,
                        u.notes,
                        u.address,
                        u.isOnline
                    })
                    .ToList();

                    if (usersList == null)
                        return NotFound();
                    else
                        return Ok(usersList);
                }
            }
            //else
            return NotFound();
        }

        // return all users active and inactive
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
                    var usersList = entity.users
                    .Select(u => new
                    {
                        u.userId,
                        u.username,
                        u.password,
                        u.name,
                        u.lastname,
                        u.job,
                        u.workHours,
                        u.createDate,
                        u.updateDate,
                        u.createUserId,
                        u.updateUserId,
                        u.phone,
                        u.mobile,
                        u.email,
                        u.notes,
                        u.address,
                        u.isActive,
                        u.isOnline
                    })
                    .ToList();

                    if (usersList == null)
                        return NotFound();
                    else
                        return Ok(usersList);
                }
            }
            //else
            return NotFound();
        }
        // GET api/<controller>
        [HttpGet]
        [Route("GetUserByID")]
        public IHttpActionResult GetUserByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int userId = 0;
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

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var user = entity.users
                   .Where(u => u.userId == userId)
                   .Select(u => new
                   {
                       u.userId,
                       u.username,
                       u.password,
                       u.name,
                       u.lastname,
                       u.job,
                       u.workHours,
                       u.createDate,
                       u.updateDate,
                       u.createUserId,
                       u.updateUserId,
                       u.phone,
                       u.mobile,
                       u.email,
                       u.notes,
                       u.address,
                       u.isOnline
                   })
                   .FirstOrDefault();

                    if (user == null)
                        return NotFound();
                    else
                        return Ok(user);
                }
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string searchWords)
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
                    var usersList = entity.users
                    .Where(p => p.name.Contains(searchWords) || p.lastname.Contains(searchWords) || p.job.Contains(searchWords) || p.workHours.Contains(searchWords))
                    .Select(u => new
                    {
                        u.userId,
                        u.username,
                        u.password,
                        u.name,
                        u.lastname,
                        u.job,
                        u.workHours,
                        u.createDate,
                        u.updateDate,
                        u.createUserId,
                        u.updateUserId,
                        u.phone,
                        u.mobile,
                        u.email,
                        u.notes,
                        u.address,
                        u.isActive,
                        u.isOnline
                    })
                    .ToList();

                    if (usersList == null)
                        return NotFound();
                    else
                        return Ok(usersList);
                }
            }
            //else
            return NotFound();
        }
        // add or update unit
        [HttpPost]
        [Route("Save")]
        public string Save(string userObject)
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
                userObject = userObject.Replace("\\", string.Empty);
                userObject = userObject.Trim('"');
                users newObject = JsonConvert.DeserializeObject<users>(userObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var unitEntity = entity.Set<users>();
                        if (newObject.userId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;

                            unitEntity.Add(newObject);
                            message = "User Is Added Successfully";
                        }
                        else
                        {
                            var tmpUnit = entity.users.Where(p => p.userId == newObject.userId).FirstOrDefault();
                            tmpUnit.name = newObject.name;
                            tmpUnit.username = newObject.username;
                            tmpUnit.password = newObject.password;
                            tmpUnit.name = newObject.name;
                            tmpUnit.lastname = newObject.lastname;
                            tmpUnit.job = newObject.job;
                            tmpUnit.workHours = newObject.workHours;
                            tmpUnit.updateDate =DateTime.Now;
                            tmpUnit.updateUserId = newObject.updateUserId;
                            tmpUnit.phone = newObject.phone;
                            tmpUnit.mobile = newObject.mobile;
                            tmpUnit.email = newObject.email;
                            tmpUnit.notes = newObject.notes;
                            tmpUnit.address = newObject.address;
                            tmpUnit.isActive = newObject.isActive;
                            message = "User Is Updated Successfully";
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
        public IHttpActionResult Delete()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int userId = 0;
            int delUserId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("delUserId"))
            {
                delUserId = Convert.ToInt32(headers.GetValues("delUserId").First());
            }
            if (headers.Contains("userId"))
            {
                userId = Convert.ToInt32(headers.GetValues("userId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            if (valid)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {                     
                        users userDelete = entity.users.Find(delUserId);
                        
                        userDelete.isActive = 0;
                        userDelete.updateDate = DateTime.Now;
                        userDelete.updateUserId = userId;
                        entity.SaveChanges();

                        return Ok("User is Deleted Successfully");
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
    }
}

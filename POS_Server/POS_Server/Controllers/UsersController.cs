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
                        u.details,
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
                       u.details,
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

        // add or update unit
        [HttpPost]
        [Route("Save")]
        public string Save()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string jsonObject = "";
            string message = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("userObject"))
            {
                jsonObject = headers.GetValues("userObject").First();
                jsonObject = jsonObject.Replace("\\", string.Empty);
                jsonObject = jsonObject.Trim('"');
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            users userObject = JsonConvert.DeserializeObject<users>(jsonObject);
            if (valid)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var unitEntity = entity.Set<users>();
                        if (userObject.userId == 0)
                        {
                            unitEntity.Add(userObject);
                            message = "User Is Added Successfully";
                        }
                        else
                        {
                            var tmpUnit = entity.users.Where(p => p.userId == userObject.userId).FirstOrDefault();
                            tmpUnit.name = userObject.name;
                            tmpUnit.username = userObject.username;
                            tmpUnit.password = userObject.password;
                            tmpUnit.name = userObject.name;
                            tmpUnit.lastname = userObject.lastname;
                            tmpUnit.job = userObject.job;
                            tmpUnit.workHours = userObject.workHours;
                            tmpUnit.details = userObject.details;
                            tmpUnit.updateDate = userObject.updateDate;
                            tmpUnit.updateUserId = userObject.updateUserId;
                            tmpUnit.phone = userObject.phone;
                            tmpUnit.mobile = userObject.mobile;
                            tmpUnit.email = userObject.email;
                            tmpUnit.notes = userObject.notes;
                            tmpUnit.address = userObject.address;

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

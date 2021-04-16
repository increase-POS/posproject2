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
                    var usersList = entity.users.Select(u => new
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
                        var userEntity = entity.Set<users>();
                        if (userObject.userId == 0)
                        {
                            userEntity.Add(userObject);
                            message = "User Is Added Successfully";
                        }
                        else
                        {
                            var tmpUser = entity.users.Where(p => p.userId == userObject.userId).FirstOrDefault();
                            tmpUser.name = userObject.name;
                            tmpUser.username = userObject.username;
                            tmpUser.password = userObject.password;
                            tmpUser.name = userObject.name;
                            tmpUser.lastname = userObject.lastname;
                            tmpUser.job = userObject.job;
                            tmpUser.workHours = userObject.workHours;
                            tmpUser.details = userObject.details;
                            tmpUser.updateDate = userObject.updateDate;
                            tmpUser.updateUserId = userObject.updateUserId;
                            tmpUser.phone = userObject.phone;
                            tmpUser.mobile = userObject.mobile;
                            tmpUser.email = userObject.email;
                            tmpUser.notes = userObject.notes;
                            tmpUser.address = userObject.address;

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
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {                     
                        users userDelete = entity.users.Find(userId);
                        entity.users.Remove(userDelete);
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

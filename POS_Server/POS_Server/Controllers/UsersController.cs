using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
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
                    .Select(u => new UserModel
                    {
                        userId=  u.userId,
                        username =  u.username,
                        password =  u.password,
                        name =  u.name,
                        lastname =  u.lastname,
                        fullName = u.name +" "+ u.lastname,
                        job =  u.job,
                        workHours =  u.workHours,
                        createDate =  u.createDate,
                        updateDate =  u.updateDate,
                        createUserId =  u.createUserId,
                        updateUserId =  u.updateUserId,
                        phone =  u.phone,
                        mobile =  u.mobile,
                        email =  u.email,
                        notes =  u.notes,
                        address =  u.address,
                        isActive =  u.isActive,
                        isOnline =  u.isOnline,
                        image = u.image,
                      
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
                    var usersList = entity.users
                    .Select(u => new UserModel()
                    {
                        userId = u.userId,
                        username = u.username,
                        password = u.password,
                        name = u.name,
                        lastname = u.lastname,
                        job = u.job,
                        workHours = u.workHours,
                        createDate = u.createDate,
                        updateDate = u.updateDate,
                        createUserId = u.createUserId,
                        updateUserId = u.updateUserId,
                        phone = u.phone,
                        mobile = u.mobile,
                        email = u.email,
                        notes = u.notes,
                        address = u.address,
                        isActive = u.isActive,
                        isOnline = u.isOnline,
                        image = u.image,
                        
                    })
                    .ToList();

                    if (usersList.Count > 0)
                    {
                        for (int i = 0; i < usersList.Count; i++)
                        {
                            canDelete = false;
                            if (usersList[i].isActive == 1)
                            {
                                int userId = (int)usersList[i].userId;
                                var usersPos = entity.posUsers.Where(x => x.userId == userId).Select(b => new { b.posUserId }).FirstOrDefault();
                                if (usersPos is null)
                                    canDelete = true;
                            }

                            usersList[i].canDelete = canDelete;
                        }
                    }

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
                       u.isOnline,
                       u.image,
                       u.isActive,
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
                        u.isOnline,
                        u.image,
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
        public int Save(string userObject)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            users tmpUser = new users();
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

                            tmpUser= unitEntity.Add(newObject);
                        }
                        else
                        {
                            tmpUser = entity.users.Where(p => p.userId == newObject.userId).FirstOrDefault();
                            tmpUser.name = newObject.name;
                            tmpUser.username = newObject.username;
                            tmpUser.password = newObject.password;
                            tmpUser.name = newObject.name;
                            tmpUser.lastname = newObject.lastname;
                            tmpUser.job = newObject.job;
                            tmpUser.workHours = newObject.workHours;
                            tmpUser.updateDate = DateTime.Now;
                            tmpUser.updateUserId = newObject.updateUserId;
                            tmpUser.phone = newObject.phone;
                            tmpUser.mobile = newObject.mobile;
                            tmpUser.email = newObject.email;
                            tmpUser.notes = newObject.notes;
                            tmpUser.address = newObject.address;
                            tmpUser.isActive = newObject.isActive;
                        }
                        entity.SaveChanges();
                    }
                }
                catch
                {
                    return 0;
                }
            }
            return tmpUser.userId;
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int delUserId, int userId, bool final)
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

                            users usersDelete = entity.users.Find(delUserId);
                            entity.users.Remove(usersDelete);
                            entity.SaveChanges();
                            return Ok("Deleted Successfully");
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
              
            }
            else
                return NotFound();
        }

        [Route("PostUserImage")]
        public IHttpActionResult PostUserImage()
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
                            var pathCheck = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\user"), imageWithNoExt);
                            var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\user"), imageWithNoExt + ".*");
                            if (files.Length > 0)
                            {
                                File.Delete(files[0]);
                            }

                            //Userimage myfolder name where i want to save my image
                            var filePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\user"), imageName);
                            postedFile.SaveAs(filePath);

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Ok(message1);
                }
                var res = string.Format("Please Upload a image.");

                return Ok(res);
            }
            catch (Exception ex)
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

            localFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\user"), imageName);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = imageName;

            return response;
        }
        [HttpPost]
        [Route("UpdateImage")]
        public int UpdateImage(string userObject)
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

            userObject = userObject.Replace("\\", string.Empty);
            userObject = userObject.Trim('"');

            users userObj = JsonConvert.DeserializeObject<users>(userObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (userObj.updateUserId == 0 || userObj.updateUserId == null)
            {
                Nullable<int> id = null;
                userObj.updateUserId = id;
            }
            if (userObj.createUserId == 0 || userObj.createUserId == null)
            {
                Nullable<int> id = null;
                userObj.createUserId = id;
            }
            if (valid)
            {
                try
                {
                    users user;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var userEntity = entity.Set<users>();
                        user = entity.users.Where(p => p.userId == userObj.userId).First();
                        user.image = userObj.image;
                        entity.SaveChanges();
                    }
                    return user.userId;
                }

                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
    }
}

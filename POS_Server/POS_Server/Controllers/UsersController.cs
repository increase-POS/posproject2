using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS_Server.Classes;
using POS_Server.Models;
using POS_Server.Models.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
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
        public ResponseVM GetActive(string token)
        {
            string type = "";
            Boolean canDelete = false;
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var usersList = entity.users.Where(u => u.isActive == 1)
                    .Select(u => new UserModel
                    {
                        userId = u.userId,
                        username = u.username,
                        password = u.password,
                        name = u.name,
                        lastname = u.lastname,
                        fullName = u.name + " " + u.lastname,
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
                        balance = u.balance,
                        balanceType = u.balanceType,
                    })
                    .ToList();

                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(usersList) };
                }
            }
        }


        [HttpGet]
        [Route("Getloginuser")]
        public ResponseVM Getloginuser(string token)
        {
            List<UserModel> usersList = new List<UserModel>();
            UserModel user = new UserModel();
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                string userName = "";
                string password = "";
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "userName")
                    {
                        userName = c.Value;
                    }
                    else if (c.Type == "password")
                    {
                        password = c.Value;
                    }
                }
                UserModel emptyuser = new UserModel();

                emptyuser.createDate = DateTime.Now;
                emptyuser.updateDate = DateTime.Now;
                emptyuser.username = user.username;
                emptyuser.createUserId = 0;
                emptyuser.updateUserId = 0;
                emptyuser.userId = 0;
                emptyuser.isActive = 0;
                emptyuser.isOnline = 0;
                emptyuser.canDelete = false;
                emptyuser.balance = 0;
                emptyuser.balanceType = 0;


                using (incposdbEntities entity = new incposdbEntities())
                {
                    usersList = entity.users.Where(u => u.isActive == 1 && u.username == userName)
                    .Select(u => new UserModel
                    {
                        userId = u.userId,
                        username = u.username,
                        password = u.password,
                        name = u.name,
                        lastname = u.lastname,
                        fullName = u.name + " " + u.lastname,
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
                        balance = u.balance,
                        balanceType = u.balanceType,
                    })
                    .ToList();
                    if (usersList == null)
                    {
                        user = emptyuser;
                        // rong user
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(user) };
                    }
                    else
                    {
                        user = usersList.Where(i => i.username == userName).FirstOrDefault();
                        if (user.password.Equals(password))
                        {
                            // correct username and pasword
                            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(user) };
                        }
                        else
                        {
                            // rong pass return just username
                            user = emptyuser;
                            user.username = userName;
                            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(user) };

                        }
                    }
                }
            }
        }
        // return all users active and inactive
        [HttpGet]
        [Route("Get")]
        public ResponseVM Get(string token)
        {
            Boolean canDelete = false;
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
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
                        balance = u.balance,
                        balanceType = u.balanceType,

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
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(usersList) };
                }
            }
        }
        // GET api/<controller>
        [HttpGet]
        [Route("GetUserByID")]
        public ResponseVM GetUserByID(string token)
        {
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int userId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                }
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
                       u.balance,
                       u.balanceType,
                   })
                   .FirstOrDefault();
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(user) };
                }
            }
        }
        /*
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
                        u.balance,
                        u.balanceType,
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
        */
        // add or update unit
        [HttpPost]
        [Route("Save")]
        public ResponseVM Save(string token)
        {
            string message = "";
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                string userObject = "";
                users userObj = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        userObject = c.Value.Replace("\\", string.Empty);
                        userObject = userObject.Trim('"');
                        userObj = JsonConvert.DeserializeObject<users>(userObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
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
                        var userEntity = entity.Set<users>();
                        var catEntity = entity.Set<categoryuser>();
                        if (newObject.userId == 0)
                        {
                            ProgramInfo programInfo = new ProgramInfo();
                            int userMaxCount = programInfo.getUserCount();
                            int usersCount = entity.users.Count();
                            if (usersCount >= userMaxCount)
                            {
                                 message = "-1";
                                return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
                            }
                            else
                            {
                                newObject.createDate = DateTime.Now;
                                newObject.updateDate = DateTime.Now;
                                newObject.updateUserId = newObject.createUserId;
                                newObject.balance = 0;
                                newObject.balanceType = 0;
                                userObj = userEntity.Add(newObject);
                                // get all categories
                                var categories = entity.categories.Where(x => x.isActive == 1).Select(x => x.categoryId).ToList();
                                int sequence = 0;
                                for (int i = 0; i < categories.Count; i++)
                                {
                                    sequence++;
                                    int categoryId = categories[i];
                                    categoryuser cu = new categoryuser()
                                    {
                                        categoryId = categoryId,
                                        userId = userObj.userId,
                                        sequence = sequence,
                                        createDate = DateTime.Now,
                                        updateDate = DateTime.Now,
                                        createUserId = newObject.createUserId,
                                        updateUserId = newObject.updateUserId,
                                    };
                                    catEntity.Add(cu);
                                }
                                entity.SaveChanges().ToString();
                                message = userObj.userId.ToString();
                                return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                            }
                        }
                        else
                        {
                            userObj = entity.users.Where(p => p.userId == newObject.userId).FirstOrDefault();
                            userObj.name = newObject.name;
                            userObj.username = newObject.username;
                            userObj.password = newObject.password;
                            userObj.name = newObject.name;
                            userObj.lastname = newObject.lastname;
                            userObj.job = newObject.job;
                            userObj.workHours = newObject.workHours;
                            userObj.updateDate = DateTime.Now;
                            userObj.updateUserId = newObject.updateUserId;
                            userObj.phone = newObject.phone;
                            userObj.mobile = newObject.mobile;
                            userObj.email = newObject.email;
                            userObj.notes = newObject.notes;
                            userObj.address = newObject.address;
                            userObj.isActive = newObject.isActive;
                            userObj.balance = newObject.balance;
                            userObj.balanceType = newObject.balanceType;
                            userObj.isOnline = newObject.isOnline;
                           entity.SaveChanges().ToString();
                            message = userObj.userId.ToString();
                            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                        }
                    }
                }
                catch
                {
                    message = "0";
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
                }
            }
        }

        [HttpPost]
        [Route("Delete")]
        public ResponseVM Delete(string token)
        {
            string message = "";
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int delUserId = 0;
                int userId = 0;
                Boolean final = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "delUserId")
                    {
                        delUserId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                    else if (c.Type == "final")
                    {
                        final = bool.Parse(c.Value);
                    }
                }
                if (final)
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            entity.categoryuser.RemoveRange(entity.categoryuser.Where(x => x.userId == delUserId));

                            users usersDelete = entity.users.Find(delUserId);
                            entity.users.Remove(usersDelete);
                            message = entity.SaveChanges().ToString();
                            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                        }
                    }
                    catch
                    {
                        return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
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
                            message = entity.SaveChanges().ToString();
                            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                        }
                    }
                    catch
                    {
                        return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                    }
                }

            }
           
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

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png", ".bmp", ".jpeg", ".tiff", ".jfif" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();

                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png, .jfif, .bmp , .jpeg ,.tiff");
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
        public ResponseVM UpdateImage(string token)
        {
            string message = "";
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                string userObject = "";
                users userObj = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        userObject = c.Value.Replace("\\", string.Empty);
                        userObject = userObject.Trim('"');
                        userObj = JsonConvert.DeserializeObject<users>(userObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
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
                    message = user.userId.ToString();
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                }

                catch
                {
                    message = "0";
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
                }
            }
        }
    }
}

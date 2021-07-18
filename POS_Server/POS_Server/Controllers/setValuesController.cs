using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using System.Net.Http.Headers;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/setValues")]
    public class setValuesController : ApiController
    {
        // GET api/<controller> get all setValues
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
                    var setValuesList = entity.setValues
                  
                   .Select(c => new  {
                       c.valId,
                      c.value,
                      c.isDefault,
                      c.isSystem,
                      c.notes,
                      c.settingId,

                   })
                   .ToList();

                    /*
                     * 
                      valId 
                      value 
                      isDefault 
                      isSystem 
                      notes 
                      settingId 
                     * */

                    if (setValuesList == null)
                        return NotFound();
                    else
                        return Ok(setValuesList);
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
                    var list = entity.setValues
                   .Where(c => c.valId == cId)
                   .Select(c => new {
                       c.valId,
                       c.value,
                       c.isDefault,
                       c.isSystem,
                       c.notes,
                       c.settingId,


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


        // add or update medal 
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
                setValues Object = JsonConvert.DeserializeObject<setValues>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    if (Object.settingId == 0 || Object.settingId == null)
                    {
                        Nullable<int> id = null;
                        Object.settingId = id;
                    }
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var sEntity = entity.Set<setValues>();
                        setValues defItem = entity.setValues.Where(p => p.settingId == Object.settingId && p.isDefault == 1).FirstOrDefault();
                          
                        if (Object.valId == 0)
                        {     
                            if (Object.isDefault == 1 )
                            { // get the row with same settingId of newObject
                                 if (defItem != null)
                                {
                                    defItem.isDefault = 0;
                                    entity.SaveChanges();
                                }
                            }
                            else //Object.isDefault ==0 
                            {
                                if (defItem == null)//other values isDefault not 1 
                                {
                                    Object.isDefault =1;
                                }

                            }
                                sEntity.Add(Object);
                          message = Object.valId.ToString();
                            entity.SaveChanges();
                        }
                        else
                        {
                            if (Object.isDefault == 1)
                            {
                                defItem.isDefault = 0;//reset the other default to 0 if exist
                            }
                            var tmps = entity.setValues.Where(p => p.valId == Object.valId).FirstOrDefault();
                            tmps.valId = Object.valId;                          
                            tmps.notes = Object.notes;
                            tmps.value = Object.value;
                            tmps.isDefault=Object.isDefault;
                            tmps.isSystem=Object.isSystem;
                            tmps.notes = Object.notes;
                            tmps.settingId=Object.settingId;
                            entity.SaveChanges();
                            message = tmps.valId.ToString();
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
        public IHttpActionResult Delete(int Id, int userId)
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
                            setValues sObj = entity.setValues.Find(Id);
                       
                            entity.setValues.Remove(sObj);
                            entity.SaveChanges();

                            return Ok("medal is Deleted Successfully");
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
// image
        #region Image

        [Route("PostImage")]
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
                            var pathCheck = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\setvalues"), imageWithNoExt);
                            var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\setvalues"), imageWithNoExt + ".*");
                            if (files.Length > 0)
                            {
                                File.Delete(files[0]);
                            }

                            //Userimage myfolder name where i want to save my image
                            var filePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\setvalues"), imageName);
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

            localFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\setvalues"), imageName);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = imageName;

            return response;
        }
        // update database record
        [HttpPost]
        [Route("UpdateImage")]
        public int UpdateImage(string SetValuesObject)
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

            SetValuesObject = SetValuesObject.Replace("\\", string.Empty);
            SetValuesObject = SetValuesObject.Trim('"');

            setValues setvalObj = JsonConvert.DeserializeObject<setValues>(SetValuesObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            /*
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
            */
            if (valid)
            {
                try
                {
                    setValues Setvalue;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var Entity = entity.Set<setValues>();
                        Setvalue = entity.setValues.Where(p => p.valId == setvalObj.valId).First();
                        Setvalue.value = setvalObj.value;
                        entity.SaveChanges();
                    }
                    return Setvalue.valId;
                }

                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }

        #endregion 

    }
}
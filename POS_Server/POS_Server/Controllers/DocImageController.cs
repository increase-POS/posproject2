using Newtonsoft.Json;
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
    [RoutePrefix("api/DocImage")]
    public class DocImageController : ApiController
    {
        [HttpPost]
        [Route("Get")]
        public IHttpActionResult Get(string tableName , int tableId)
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
                    var docImageList = entity.docImages.Where(x => x.tableName == tableName && x.tableId == tableId)
                        .Select(b => new {
                        b.id,
                        b.docName,
                        b.docnum,
                        b.image,
                        b.tableName,
                        b.tableId,
                        b.note,
                        b.createDate,
                        b.updateDate,
                        b.createUserId,
                        b.updateUserId,
                    })
                    .ToList();

                    if (docImageList == null)
                        return NotFound();
                    else
                        return Ok(docImageList);
                }
            }
            //else
            return NotFound();
        }
        [HttpPost]
        [Route("GetCount")]
        public IHttpActionResult GetCount(string tableName , int tableId)
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
                    var docImageCount = entity.docImages.Where(x => x.tableName == tableName && x.tableId == tableId)
                        .Select(b => new {
                        b.id,
                        b.docName,
                        b.docnum,
                        b.image,
                        b.tableName,
                        b.tableId,
                        b.note,
                        b.createDate,
                        b.updateDate,
                        b.createUserId,
                        b.updateUserId,
                    })
                    .ToList().Count;

                    return Ok(docImageCount);
                }
            }
            //else
            return NotFound();
        }
        [Route("PostImage")]
        public IHttpActionResult PostImage()
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

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png", ".bmp", ".jpeg", ".tiff",".jfif" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();

                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png,.jfif,.bmp,.jpeg,.tiff");
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
                            var pathCheck = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\docImage"), imageWithNoExt);
                            var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\docImage"), imageWithNoExt + ".*");
                            if (files.Length > 0)
                            {
                                File.Delete(files[0]);
                            }

                            //Userimage myfolder name where i want to save my image
                            var filePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\docImage"), imageName);
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

        [HttpPost]
        [Route("GetImage")]
        public HttpResponseMessage GetImage( string imageName)
        {
            if (String.IsNullOrEmpty(imageName))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            string localFilePath;

            localFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\docImage"), imageName);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = imageName;

            return response;
        }
        [HttpPost]
        [Route("saveImageDoc")]
        public int saveImageDoc(string docImageObject)
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

            docImageObject = docImageObject.Replace("\\", string.Empty);
            docImageObject = docImageObject.Trim('"');
                    
            if (valid)
            {
                docImages imageDocObj = JsonConvert.DeserializeObject<docImages>(docImageObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                if (imageDocObj.updateUserId == 0 || imageDocObj.updateUserId == null)
                {
                    Nullable<int> id = null;
                    imageDocObj.updateUserId = id;
                }
                if (imageDocObj.createUserId == 0 || imageDocObj.createUserId == null)
                {
                    Nullable<int> id = null;
                    imageDocObj.createUserId = id;
                }
                try
                {
                    docImages docImage;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var imageDocEntity = entity.Set<docImages>();
                        if (imageDocObj.id == 0)
                        {
                            imageDocObj.createDate = DateTime.Now;
                            imageDocObj.updateDate = DateTime.Now;
                            imageDocObj.updateUserId = imageDocObj.createUserId;

                            docImage = imageDocEntity.Add(imageDocObj);
                        }
                        else
                        {
                            docImage = entity.docImages.Where(p => p.id == imageDocObj.id).FirstOrDefault();
                            docImage.docName = imageDocObj.docName;
                            docImage.docnum = imageDocObj.docnum;
                            docImage.image = imageDocObj.image;
                            docImage.note = imageDocObj.note;
                            docImage.updateDate = DateTime.Now;
                            docImage.updateUserId = imageDocObj.updateUserId;

                        }
                        entity.SaveChanges();
                        return docImage.id;
                    }
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        [HttpPost]
        [Route("UpdateImage")]
        public int UpdateImage(string docImageObject)
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

            docImageObject = docImageObject.Replace("\\", string.Empty);
            docImageObject = docImageObject.Trim('"');
          
            if (valid)
            {
                docImages docImageObj = JsonConvert.DeserializeObject<docImages>(docImageObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                if (docImageObj.updateUserId == 0 || docImageObj.updateUserId == null)
                {
                    Nullable<int> id = null;
                    docImageObj.updateUserId = id;
                }
                if (docImageObj.createUserId == 0 || docImageObj.createUserId == null)
                {
                    Nullable<int> id = null;
                    docImageObj.createUserId = id;
                }
                try
                {
                    docImages docImage;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var docImgEntity = entity.Set<docImages>();
                        docImage = entity.docImages.Where(p => p.id == docImageObj.id).First();
                        docImage.image = docImageObj.image;
                        entity.SaveChanges();
                    }
                    return docImage.id;
                }
                catch { return 0; }
            }
            else
                return 0;
        }
        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int docId)
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
                        docImages docImageObj = entity.docImages.Find(docId);

                        entity.docImages.Remove(docImageObj);
                        entity.SaveChanges();

                        // delete image from folder
                        //var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\docImage"), docImageObj.image);
                        string tmpPath = System.IO.Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\docImage"), docImageObj.image);
                        if (File.Exists(tmpPath))
                        {
                            File.Delete(tmpPath);
                        }

                        return Ok("Serial is Deleted Successfully");
                    }
                }
                catch { return NotFound(); }              
            }
            else
                return NotFound();
        }

    }
}
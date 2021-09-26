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
    [RoutePrefix("api/cards")]
    public class CardController : ApiController
    {
        // GET api/<controller> get all cards
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
                    var cardsList = entity.cards
                  
                   .Select(c => new CardModel() {
                   cardId=c.cardId,
                   name= c.name,
                   notes = c.notes,
                   createDate =c.createDate,
                   updateDate = c.updateDate,
                   createUserId = c.createUserId,
                   updateUserId=  c.updateUserId,
                    isActive=c.isActive, 
                    image = c.image
                })
                   .ToList();

                    // can delet or not
                    if (cardsList.Count > 0)
                    {
                        foreach(CardModel carditem  in cardsList)
                        {
                            canDelete = false;
                            if (carditem.isActive == 1)
                            {
                                int cId = (int)carditem.cardId;
                                var casht = entity.cashTransfer.Where(x => x.cardId == cId).Select(x => new { x.cardId }).FirstOrDefault();
                      
                                if ((casht is null) )
                                    canDelete = true;
                            }
                            carditem.canDelete = canDelete;
                        }
                    }

                    if (cardsList == null)
                        return NotFound();
                    else
                        return Ok(cardsList);
                }
            }
            //else
                return NotFound();
        }



        // GET api/<controller>  Get card By ID 
        [HttpGet]
        [Route("GetcardByID")]
        public IHttpActionResult GetcardByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int cId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("cardId"))
            {
                cId = Convert.ToInt32(headers.GetValues("cardId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var card = entity.cards
                   .Where(c => c.cardId == cId)
                   .Select(c => new {
                     c.cardId,
                     c.name,
                     c.notes,
                     c.createDate,
                     c.updateDate,
                     c.createUserId,
                     c.updateUserId,
                       c.isActive,
                       c.image
                      
                   })
                   .FirstOrDefault();

                    if (card == null)
                        return NotFound();
                    else
                        return Ok(card);
                }
            }
            else
                return NotFound();
        }

   


    
        // GET api/<controller>  Get card By is active
        [HttpGet]
        [Route("GetByisActive")]
        public IHttpActionResult GetByisActive(byte isActive)
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
                    var card = entity.cards
                   .Where(c => c.isActive == isActive)
                   .Select(c => new {
                       c.cardId,
                       c.name,
                       c.notes,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,
                       c.isActive,
                       c.image
                   })
                   .ToList();

                    if (card == null)
                        return NotFound();
                    else
                        return Ok(card);
                }
            }
            else
                return NotFound();
        }


        // add or update card 
        [HttpPost]
        [Route("Save")]
        public string Save(string cardObject)
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
                cardObject = cardObject.Replace("\\", string.Empty);
                cardObject = cardObject.Trim('"');
                cards Object = JsonConvert.DeserializeObject<cards>(cardObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var cardEntity = entity.Set<cards>();
                        if (Object.cardId == 0)
                        {

                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            cardEntity.Add(Object);
                            entity.SaveChanges();
                            message = Object.cardId.ToString();
                        }
                        else
                        {

                            var tmpcard = entity.cards.Where(p => p.cardId == Object.cardId).FirstOrDefault();
                          
                            tmpcard.cardId = Object.cardId;
                            tmpcard.name = Object.name;
                            tmpcard.notes = Object.notes;
                            tmpcard.createDate = Object.createDate;
                            tmpcard.updateDate = Object.updateDate;
                            tmpcard.createUserId = Object.createUserId;
                            tmpcard.updateUserId = Object.updateUserId;
                            tmpcard.isActive = Object.isActive;
                            tmpcard.updateDate = DateTime.Now;// server current date;
                            tmpcard.updateUserId = Object.updateUserId;
                            tmpcard.image = Object.image;

                            entity.SaveChanges();

                            message = tmpcard.cardId.ToString();
                        }
                        
                    }
                    //return true;
                    return message;
                }

                catch
                {
                    //return false;
                    return "";
                }
            }
            else
                //return false;
                return "";
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int cardId, int userId, Boolean final)
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
                            cards cardObj = entity.cards.Find(cardId);

                            entity.cards.Remove(cardObj);
                            entity.SaveChanges();

                            return Ok("card is Deleted Successfully");
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
                            cards cardObj = entity.cards.Find(cardId);

                            cardObj.isActive = 0;
                            cardObj.updateUserId = userId;
                            cardObj.updateDate = DateTime.Now;
                            entity.SaveChanges();

                            return Ok("Offer is Deleted Successfully");
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

        [HttpGet]
        [Route("GetImage")]
        public HttpResponseMessage GetImage(string imageName)
        {
            if (String.IsNullOrEmpty(imageName))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            string localFilePath;

            localFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\card"), imageName);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = imageName;

            return response;
        }

        [HttpPost]
        [Route("UpdateImage")]
        public int UpdateImage(string cardObject)
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

            cardObject = cardObject.Replace("\\", string.Empty);
            cardObject = cardObject.Trim('"');

            cards cardObj = JsonConvert.DeserializeObject<cards>(cardObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (cardObj.updateUserId == 0 || cardObj.updateUserId == null)
            {
                Nullable<int> id = null;
                cardObj.updateUserId = id;
            }
            if (cardObj.createUserId == 0 || cardObj.createUserId == null)
            {
                Nullable<int> id = null;
                cardObj.createUserId = id;
            }
            if (valid)
            {
                try
                {
                    cards card;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var userEntity = entity.Set<cards>();
                        card = entity.cards.Where(p => p.cardId == cardObj.cardId).First();
                        card.image = cardObj.image;
                        entity.SaveChanges();
                    }
                    return card.cardId;
                }

                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }

        [Route("PostCardImage")]
        public IHttpActionResult PostCardImage()
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
                            var pathCheck = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\card"), imageWithNoExt);
                            var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\card"), imageWithNoExt + ".*");
                            if (files.Length > 0)
                            {
                                File.Delete(files[0]);
                            }

                            //Userimage myfolder name where i want to save my image
                            var filePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\card"), imageName);
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

    }
}
﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS_Server.Models;
using POS_Server.Models.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
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
                    var cardsList = entity.cards

                   .Select(c => new CardModel()
                   {
                       cardId = c.cardId,
                       name = c.name,
                       notes = c.notes,
                       createDate = c.createDate,
                       updateDate = c.updateDate,
                       createUserId = c.createUserId,
                       updateUserId = c.updateUserId,
                       isActive = c.isActive,
                   })
                   .ToList();

                    // can delet or not
                    if (cardsList.Count > 0)
                    {
                        foreach (CardModel carditem in cardsList)
                        {
                            canDelete = false;
                            if (carditem.isActive == 1)
                            {
                                int cId = (int)carditem.cardId;
                                var casht = entity.cashTransfer.Where(x => x.cardId == cId).Select(x => new { x.cardId }).FirstOrDefault();

                                if ((casht is null))
                                    canDelete = true;
                            }
                            carditem.canDelete = canDelete;
                        }
                    }
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(cardsList) };
                }
            }
        }
        // GET api/<controller>  Get card By ID 
        [HttpGet]
        [Route("GetcardByID")]
        public ResponseVM GetByID(string token)
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
                int cId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        cId = int.Parse(c.Value);
                    }
                }
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
                   })
                   .FirstOrDefault();
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(card) };
                }
            }
        }
        // GET api/<controller>  Get card By is active
        [HttpGet]
        [Route("GetByisActive")]
        public ResponseVM GetByisActive(string token)
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
                int isActive = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "isActive")
                    {
                        isActive = int.Parse(c.Value);
                    }
                }
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
                   })
                   .ToList();
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(card) };
                }
            }
        }
        // add or update card 
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
                string cardObject = "";
                cards Object = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        cardObject = c.Value.Replace("\\", string.Empty);
                        cardObject = cardObject.Trim('"');
                        Object = JsonConvert.DeserializeObject<cards>(cardObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        cards tmpcard = new cards();
                        var cardEntity = entity.Set<cards>();
                        if (Object.cardId == 0)
                        {
                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            tmpcard = cardEntity.Add(Object);
                            entity.SaveChanges();
                            message = tmpcard.cardId.ToString();

                        }
                        else
                        {

                            tmpcard = entity.cards.Where(p => p.cardId == Object.cardId).FirstOrDefault();
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
                            entity.SaveChanges();
                            message = tmpcard.cardId.ToString();
                        }

                    }
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
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
                int cardId = 0;
                int userId = 0;
                Boolean final = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        cardId = int.Parse(c.Value);
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
                            cards cardObj = entity.cards.Find(cardId);
                            entity.cards.Remove(cardObj);
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
                            cards cardObj = entity.cards.Find(cardId);

                            cardObj.isActive = 0;
                            cardObj.updateUserId = userId;
                            cardObj.updateDate = DateTime.Now;
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
                string cardObject = "";
                cards cardObj = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        cardObject = c.Value.Replace("\\", string.Empty);
                        cardObject = cardObject.Trim('"');
                        cardObj = JsonConvert.DeserializeObject<cards>(cardObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
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
                    message = card.cardId.ToString();
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                }
                catch
                {
                    message = "0";
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
                }
            }
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
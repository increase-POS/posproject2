﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS_Server.Classes;
using POS_Server.Models;
using POS_Server.Models.VM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Agent")]
    public class AgentController : ApiController
    {
        // GET api/Agent
        [HttpGet]
        [Route("Get")]
        public ResponseVM Get(string token)
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
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "type")
                    {
                        type = c.Value;
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var agentsList = entity.agents
                   .Where(p => p.type == type)
                   .Select(p => new AgentModel
                   {
                       agentId = p.agentId,
                       name = p.name,
                       code = p.code,
                       company = p.company,
                       address = p.address,
                       email = p.email,
                       phone = p.phone,
                       mobile = p.mobile,
                       image = p.image,
                       type = p.type,
                       accType = p.accType,
                       balance = p.balance,
                       balanceType = p.balanceType,
                       notes = p.notes,
                       isActive = p.isActive,
                       createDate = p.createDate,
                       updateDate = p.updateDate,
                       maxDeserve = p.maxDeserve,
                       fax = p.fax,
                       isLimited = p.isLimited,
                   })
                   .ToList();
                    if (agentsList.Count > 0)
                    {
                        for (int i = 0; i < agentsList.Count; i++)
                        {
                            canDelete = false;
                            if (agentsList[i].isActive == 1)
                            {
                                int agentId = (int)agentsList[i].agentId;
                                var invoicesL = entity.invoices.Where(x => x.agentId == agentId).Select(b => new { b.invoiceId }).FirstOrDefault();
                                var cachTransferL = entity.cashTransfer.Where(x => x.agentId == agentId).Select(x => new { x.cashTransId }).FirstOrDefault();
                                if ((invoicesL is null) && (cachTransferL is null))
                                    canDelete = true;
                            }
                            agentsList[i].canDelete = canDelete;
                        }
                    }
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(agentsList) };

                }
            }
        }
        [HttpGet]
        [Route("GetActive")]
        public ResponseVM GetActive(string token)
        {
            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid)
            string type = "";

            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "type")
                    {
                        type = c.Value;
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {

                    var agentsList = entity.agents
                   .Where(p => p.type == type && p.isActive == 1)
                   .Select(p => new
                   {
                       p.agentId,
                       p.name,
                       p.code,
                       p.company,
                       p.address,
                       p.email,
                       p.phone,
                       p.mobile,
                       p.image,
                       p.type,
                       p.accType,
                       p.balance,
                       p.balanceType,
                       p.notes,
                       p.maxDeserve,
                       p.fax,
                       p.isActive,
                       p.createDate,
                       p.isLimited,
                   })
                   .ToList();

                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(agentsList) };

                }
            }
        }

        [HttpGet]
        [Route("GetAgentByID")]
        public ResponseVM GetAgentByID(string token)
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
                {
                    int agentId = 0;
                    IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                    foreach (Claim c in claims)
                    {
                        if (c.Type == "agentId")
                        {
                            agentId = int.Parse(c.Value);
                        }
                    }
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var agent = entity.agents
                       .Where(p => p.agentId == agentId)
                       .Select(p => new { p.agentId, p.name, p.accType, p.address, p.balance, p.balanceType, p.code, p.company, p.createDate, p.createUserId, p.email, p.mobile, p.notes, p.phone, p.type, p.image, p.maxDeserve, p.fax, p.isActive, p.updateDate, p.updateUserId, p.isLimited })
                       .FirstOrDefault();
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(agent) };
                    }
                }
            }
        }





        // add or update agent
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
                string agentObject = "";
                agents agentObj = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        agentObject = c.Value.Replace("\\", string.Empty);
                        agentObject = agentObject.Trim('"');
                        agentObj = JsonConvert.DeserializeObject<agents>(agentObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
                try
                {
                    agents agent;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var agentEntity = entity.Set<agents>();
                        if (agentObj.agentId == 0)
                        {
                            ProgramInfo programInfo = new ProgramInfo();
                            int agentMaxCount = 0;
                            if (agentObj.type == "c")
                                agentMaxCount = programInfo.getCustomerCount();
                            else if (agentObj.type == "v")
                                agentMaxCount = programInfo.getVendorCount();

                            int agentCount = entity.agents.Where(x => x.type == agentObj.type).Count();
                            if (agentCount >= agentMaxCount)
                            {
                                message = "-1";
                                return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
                            }
                            else
                            {
                                agentObj.createDate = DateTime.Now;
                                agentObj.updateDate = DateTime.Now;
                                agentObj.updateUserId = agentObj.createUserId;
                                agent = agentEntity.Add(agentObj);
                            }
                        }
                        else
                        {
                            agent = entity.agents.Where(p => p.agentId == agentObj.agentId).First();
                            agent.accType = agentObj.accType;
                            agent.address = agentObj.address;
                            agent.code = agentObj.code;
                            agent.company = agentObj.company;
                            agent.email = agentObj.email;
                            agent.image = agentObj.image;
                            agent.mobile = agentObj.mobile;
                            agent.name = agentObj.name;
                            agent.notes = agentObj.notes;
                            agent.phone = agentObj.phone;
                            agent.type = agentObj.type;
                            agent.maxDeserve = agentObj.maxDeserve;
                            agent.fax = agentObj.fax;
                            agent.updateDate = DateTime.Now;// server current date
                            agent.updateUserId = agentObj.updateUserId;
                            agent.isActive = agentObj.isActive;
                            agent.balance = agentObj.balance;
                            agent.balanceType = agentObj.balanceType;
                            agent.isLimited = agentObj.isLimited;
                        }
                        entity.SaveChanges();
                        message = agent.agentId.ToString();

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
                int agentId = 0;
                int userId = 0;
                Boolean final = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        agentId = int.Parse(c.Value);
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
                if (!final)
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            var tmpAgent = entity.agents.Where(p => p.agentId == agentId).First();
                            tmpAgent.isActive = 0;
                            tmpAgent.updateDate = DateTime.Now;
                            tmpAgent.updateUserId = userId;

                            message = entity.SaveChanges().ToString();
                        }
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
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
                            var tmpAgent = entity.agents.Where(p => p.agentId == agentId).First();
                            entity.agents.Remove(tmpAgent);
                            message = entity.SaveChanges().ToString();
                        }
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                    }
                    catch
                    {
                        return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                    }
                }
            }
            
        }

        [Route("PostUserImage")]
        public  IHttpActionResult PostUserImage()
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
                            var pathCheck = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\agent"), imageWithNoExt);
                            var files = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\agent"), imageWithNoExt + ".*");
                            if (files.Length > 0)
                            {
                                File.Delete(files[0]);
                            }

                            //Userimage myfolder name where i want to save my image
                            var filePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\agent"), imageName);
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

            localFilePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~\\images\\agent"), imageName);

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
                string agentObject = "";
                agents agentObj = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        agentObject = c.Value.Replace("\\", string.Empty);
                        agentObject = agentObject.Trim('"');
                        agentObj = JsonConvert.DeserializeObject<agents>(agentObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
                try
                {
                    agents agent;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var agentEntity = entity.Set<agents>();                      
                        agent = entity.agents.Where(p => p.agentId == agentObj.agentId).First();
                        agent.image = agentObj.image;
                        entity.SaveChanges();
                    }
                    message = agent.agentId.ToString();
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
        [Route("UpdateBalance")]
        public ResponseVM UpdateBalance(string token)
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
                int agentId = 0;
                decimal balance = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "agentId")
                    {
                        agentId = int.Parse(c.Value);
                    }
                    else if (c.Type == "balance")
                    {
                        balance = int.Parse(c.Value);
                    }
                }
                try
                {
                    agents agent;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var agentEntity = entity.Set<agents>();
                        agent = entity.agents.Where(p => p.agentId == agentId).First();
                        agent.balance = balance;
                        entity.SaveChanges();
                    }
                    message = agent.agentId.ToString();
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                }

                catch
                {
                    message = "0";
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
                }
            }
        }

        [HttpGet]
        [Route("GetLastNumOfCode")]
        public ResponseVM GetLastNumOfCode(string token)
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
                string type = "";
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "type")
                    {
                        type = c.Value;
                    }
                }
                List<string> numberList;
                int lastNum = 0;
                using (incposdbEntities entity = new incposdbEntities())
                {
                    numberList = entity.agents.Where(b => b.code.Contains(type + "-")).Select(b => b.code).ToList();

                    for (int i = 0; i < numberList.Count; i++)
                    {
                        string code = numberList[i];
                        string s = code.Substring(code.LastIndexOf("-") + 1);
                        numberList[i] = s;
                    }
                    if (numberList.Count > 0)
                    {
                        numberList.Sort();
                        lastNum = int.Parse(numberList[numberList.Count - 1]);
                    }
                }
                message = lastNum.ToString();
                return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
            }
        }

    }
}

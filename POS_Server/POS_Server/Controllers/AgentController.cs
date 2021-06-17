using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public IHttpActionResult Get()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string type = "";
            Boolean canDelete = false;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("type"))
            {
                // type = v mean vendor
                // type = c means Client
                // type = b means both of brevious types
                type = headers.GetValues("type").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var agentsList = entity.agents
                   .Where(p => p.type == type)
                   .Select(p => new AgentModel {
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
                       notes = p.notes,
                       isActive = p.isActive,
                       createDate = p.createDate,
                       updateDate = p.updateDate,
                     maxDeserve = p.maxDeserve,
                       fax = p.fax, })
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
                    if (agentsList == null)
                        return NotFound();
                    else
                        return Ok(agentsList);

                }
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetActive")]
        public IHttpActionResult GetActive(string type)
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

                    var agentsList = entity.agents
                   .Where(p => p.type == type && p.isActive == 1)
                   .Select(p => new {
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
                       p.notes,
                       p.maxDeserve,
                       p.fax,
                       p.isActive,
                       p.createDate })
                   .ToList();

                    if (agentsList == null)
                        return NotFound();
                    else
                        return Ok(agentsList);

                }
            }
            else
                return NotFound();
        }
        // GET api/agent/5
        [HttpGet]
        [Route("GetAgentByID")]
        public IHttpActionResult GetAgentByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int agentID = 0 ;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("agentId"))
            {
                agentID = Convert.ToInt32( headers.GetValues("agentId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {

                    var agent = entity.agents
                   .Where(p => p.agentId == agentID)
                   .Select(p => new { p.agentId, p.name, p.accType, p.address, p.balance, p.code, p.company, p.createDate, p.createUserId,  p.email,  p.mobile, p.notes, p.phone, p.type, p.image, p.maxDeserve, p.fax,p.isActive,p.updateDate,p.updateUserId })
                   .FirstOrDefault();
                   
                    if (agent == null)
                        return NotFound();
                    else
                        return Ok(agent);

                }
            }
            else
                return NotFound();
        }

        // GET api/Agent
        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string type,string searchWords)
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
                    var agentsList = entity.agents
                   .Where( p => (p.type==type) && ( p.name.Contains(searchWords) || p.company.Contains(searchWords) || p.mobile.Contains(searchWords)))
                   .Select(p => new {
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
                       p.notes,
                       p.maxDeserve,
                       p.fax,
                       p.isActive,
                       p.createDate
                   })
                   .ToList();

                    if (agentsList == null)
                        return NotFound();
                    else
                        return Ok(agentsList);

                }
            }
            else
                return NotFound();
        }

        // add or update agent
        [HttpPost]
        [Route("Save")]
        public int Save(string agentObject)
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

            agentObject = agentObject.Replace("\\", string.Empty);
            agentObject = agentObject.Trim('"');

            agents agentObj = JsonConvert.DeserializeObject<agents>(agentObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (agentObj.updateUserId == 0 || agentObj.updateUserId == null)
            {
                Nullable<int> id = null;
                agentObj.updateUserId = id;
            }
            if (agentObj.createUserId == 0 || agentObj.createUserId == null)
            {
                Nullable<int> id = null;
                agentObj.createUserId = id;
            }
            if (valid)
            {
                try
                {
                    agents agent;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var agentEntity = entity.Set<agents>();
                        if (agentObj.agentId == 0)
                        {
                            agentObj.createDate = DateTime.Now;
                            agentObj.updateDate = DateTime.Now;
                            agentObj.updateUserId = agentObj.createUserId;
                           agent = agentEntity.Add(agentObj);
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
                        }
                        entity.SaveChanges();
                    }
                    return agent.agentId;
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
        [Route("Delete")]
        public bool Delete(Boolean final)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int agentId = 0;
            int userId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("agentId"))
            {
                agentId = Convert.ToInt32(headers.GetValues("agentId").First());
            }
            if (headers.Contains("userId"))
            {
                userId = Convert.ToInt32(headers.GetValues("userId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            if (valid)
            {
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

                            entity.SaveChanges();
                        }
                        return true;
                    }
                    catch
                    {
                        return false;
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
                            entity.SaveChanges();
                        }
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            else
                return false;
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

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" ,".bmp", ".jpeg", ".tiff" };
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
        public int UpdateImage(string agentObject)
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

            agentObject = agentObject.Replace("\\", string.Empty);
            agentObject = agentObject.Trim('"');

            agents agentObj = JsonConvert.DeserializeObject<agents>(agentObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (agentObj.updateUserId == 0 || agentObj.updateUserId == null)
            {
                Nullable<int> id = null;
                agentObj.updateUserId = id;
            }
            if (agentObj.createUserId == 0 || agentObj.createUserId == null)
            {
                Nullable<int> id = null;
                agentObj.createUserId = id;
            }
            if (valid)
            {
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
                    return agent.agentId;
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
        [Route("UpdateBalance")]
        public int UpdateBalance(int agentId , decimal balance)
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
                    agents agent;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var agentEntity = entity.Set<agents>();
                        agent = entity.agents.Where(p => p.agentId == agentId).First();
                        agent.balance = balance;
                        entity.SaveChanges();
                    }
                    return agent.agentId;
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

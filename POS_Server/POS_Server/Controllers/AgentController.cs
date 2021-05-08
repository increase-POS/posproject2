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
using System.Text;
using System.Text.Json;
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
                   .Select(p => new { p.agentId, p.name, p.accType, p.address, p.balance, p.cashTransfer, p.code, p.company, p.createDate, p.createUserId,  p.email, p.invoices,  p.mobile, p.notes, p.phone, p.type, p.image, p.maxDeserve, p.fax })
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
        public bool Save(string agentObject)
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
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var agentEntity = entity.Set<agents>();
                        if (agentObj.agentId == 0)
                        {
                            agentObj.createDate = DateTime.Now;
                            agentObj.updateDate = DateTime.Now;
                            agentObj.updateUserId = agentObj.createUserId;
                            agentEntity.Add(agentObj);
                        }
                        else
                        {
                            var tmpAgent = entity.agents.Where(p => p.agentId == agentObj.agentId).First();
                            tmpAgent.accType = agentObj.accType;
                            tmpAgent.address = agentObj.address;
                            tmpAgent.code = agentObj.code;
                            tmpAgent.company = agentObj.company;
                            tmpAgent.email = agentObj.email;
                            tmpAgent.image = agentObj.image;
                            tmpAgent.mobile = agentObj.mobile;
                            tmpAgent.name = agentObj.name;
                            tmpAgent.notes = agentObj.notes;
                            tmpAgent.phone = agentObj.phone;
                            tmpAgent.type = agentObj.type;
                            tmpAgent.maxDeserve = agentObj.maxDeserve;
                            tmpAgent.fax = agentObj.fax;
                            tmpAgent.updateDate = DateTime.Now;// server current date
                            tmpAgent.updateUserId = agentObj.updateUserId; 
                            tmpAgent.isActive = agentObj.isActive; 
                        }
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
                return false;
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

    }
}

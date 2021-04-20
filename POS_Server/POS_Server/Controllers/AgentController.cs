using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                   .Where(p => p.type == type && p.isActive==1)
                   .Select(p => new { p.agentId, p.name, p.code, p.company, p.address, p.details, p.email, p.phone, p.mobile, p.image, p.type, p.accType, p.balance, p.isDefault, p.notes, p.isActive ,p.createDate})
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
                   .Select(p => new { p.agentId, p.name, p.accType, p.address, p.balance, p.cashTransfer, p.code, p.company, p.createDate, p.createUserId, p.details, p.email, p.invoices, p.isDefault, p.mobile, p.notes, p.phone, p.type, p.image })
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

        // add or update agent
        [HttpPost]
        [Route("Save")]
        public bool Save()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string agentObject = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("agentObject"))
            {
                agentObject = headers.GetValues("agentObject").First();
                agentObject = agentObject.Replace("\\", string.Empty);
                agentObject = agentObject.Trim('"');
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            POS_Server.agents agentObj = JsonConvert.DeserializeObject<POS_Server.agents>(agentObject);
            if (valid)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var agentEntity = entity.Set<agents>();
                        if (agentObj.agentId == 0)
                        {
                            agentEntity.Add(agentObj);
                        }
                        else
                        {
                            var tmpAgent = entity.agents.Where(p => p.agentId == agentObj.agentId).First();
                            tmpAgent.accType = agentObj.accType;
                            tmpAgent.address = agentObj.address;
                            tmpAgent.balance = agentObj.balance;
                            tmpAgent.code = agentObj.code;
                            tmpAgent.company = agentObj.company;
                            tmpAgent.details = agentObj.details;
                            tmpAgent.email = agentObj.email;
                            tmpAgent.image = agentObj.image;
                            tmpAgent.isDefault = agentObj.isDefault;
                            tmpAgent.mobile = agentObj.mobile;
                            tmpAgent.name = agentObj.name;
                            tmpAgent.notes = agentObj.notes;
                            tmpAgent.phone = agentObj.phone;
                            tmpAgent.type = agentObj.type;
                            tmpAgent.updateDate = agentObj.updateDate;
                            tmpAgent.updateUserId = agentObj.updateUserId; 
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
        public bool Delete()
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
                return false;
        }
    }
}

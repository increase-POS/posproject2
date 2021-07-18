using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/InvoiceStatus")]
    public class InvoiceStatusController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int invoiceId)
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
                    var invoiceStatus = entity.invoiceStatus.Where(x => x.invoiceId == invoiceId)

                   .Select(c => new InvoiceStatusModel()
                   {
                       invStatusId = c.invStatusId,
                       invoiceId = c.invoiceId,
                       status = c.status,
                       createDate = c.createDate,
                       updateDate = c.updateDate,
                       createUserId = c.createUserId,
                       updateUserId = c.updateUserId,
                       notes = c.notes,
                       isActive = c.isActive,
                   })
                   .ToList();

                    if (invoiceStatus == null)
                        return NotFound();
                    else
                        return Ok(invoiceStatus);
                }
            }
            //else
            return NotFound();
        }
        [HttpPost]
        [Route("Save")]
        public bool Save(string statusObject)
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
                statusObject = statusObject.Replace("\\", string.Empty);
                statusObject = statusObject.Trim('"');
                invoiceStatus Object = JsonConvert.DeserializeObject<invoiceStatus>(statusObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var statusEntity = entity.Set<invoiceStatus>();
                        if (Object.invStatusId == 0)
                        {

                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            statusEntity.Add(Object);
                        }
                        else
                        {
                            var tmpStatus = entity.invoiceStatus.Where(p => p.invStatusId == Object.invStatusId).FirstOrDefault();

                            tmpStatus.notes = Object.notes;
                            tmpStatus.status = Object.status;
                            tmpStatus.createDate = Object.createDate;
                            tmpStatus.updateDate = Object.updateDate;
                            tmpStatus.updateUserId = Object.updateUserId;
                            tmpStatus.isActive = Object.isActive;
                            tmpStatus.updateDate = DateTime.Now;// server current date;

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
        
    }
}
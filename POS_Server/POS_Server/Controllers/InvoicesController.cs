using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Invoices")]
    public class InvoicesController : ApiController
    {
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
                    var banksList = entity.invoices.Select(b => new {
                        b.invoiceId,
                        b.invNumber,
                        b.agentId,
                        b.invType ,
                        b.total ,
                        b.totalNet ,
                        b.paid ,
                        b.deserved ,
                        b.deservedDate,
                        b.invDate ,
                        b.invoiceMainId ,
                        b.invCase ,
                        b.invTime ,
                        b.notes ,
                        b.vendorInvNum ,
                        b.vendorInvDate ,
                        b.createUserId,
                        b.updateDate ,
                        b.updateUserId ,
                })
                    .ToList();

                    if (banksList == null)
                        return NotFound();
                    else
                        return Ok(banksList);
                }
            }
            //else
            return NotFound();
        }
        [HttpGet]
        [Route("GetByInvoiceId")]
        public IHttpActionResult GetByInvoiceId(int invoiceId)
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
                    var banksList = entity.invoices.Where(b => b.invoiceId == invoiceId).Select(b => new {
                        b.invoiceId,
                        b.invNumber,
                        b.agentId,
                        b.invType,
                        b.total,
                        b.totalNet,
                        b.paid,
                        b.deserved,
                        b.deservedDate,
                        b.invDate,
                        b.invoiceMainId,
                        b.invCase,
                        b.invTime,
                        b.notes,
                        b.vendorInvNum,
                        b.vendorInvDate,
                        b.createUserId,
                        b.updateDate,
                        b.updateUserId,
                    })
                    .ToList();

                    if (banksList == null)
                        return NotFound();
                    else
                        return Ok(banksList);
                }
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetByInvoiceType")]
        public IHttpActionResult GetByInvoiceType(string invType)
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
                    var banksList = entity.invoices.Where(b => b.invType == invType).Select(b => new {
                        b.invoiceId,
                        b.invNumber,
                        b.agentId,
                        b.invType,
                        b.total,
                        b.totalNet,
                        b.paid,
                        b.deserved,
                        b.deservedDate,
                        b.invDate,
                        b.invoiceMainId,
                        b.invCase,
                        b.invTime,
                        b.notes,
                        b.vendorInvNum,
                        b.vendorInvDate,
                        b.createUserId,
                        b.updateDate,
                        b.updateUserId,
                    })
                    .ToList();

                    if (banksList == null)
                        return NotFound();
                    else
                        return Ok(banksList);
                }
            }
            return NotFound();
        }
        // add or update bank
        [HttpPost]
        [Route("Save")]
        public string Save(string invoiceObject)
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
                invoiceObject = invoiceObject.Replace("\\", string.Empty);
                invoiceObject = invoiceObject.Trim('"');
                invoices newObject = JsonConvert.DeserializeObject<invoices>(invoiceObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        var bankEntity = entity.Set<invoices>();
                        if (newObject.invoiceId == 0)
                        {
                            newObject.invDate = DateTime.Now;
                            newObject.invTime = DateTime.Now.TimeOfDay;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;

                            bankEntity.Add(newObject);
                            message = "Invoice Is Added Successfully";
                        }
                        else
                        {
                            var tmpInvoice = entity.invoices.Where(p => p.invoiceId == newObject.invoiceId).FirstOrDefault();
                            tmpInvoice.invNumber = newObject.invNumber;
                            tmpInvoice.agentId = newObject.agentId;
                            tmpInvoice.invType = newObject.invType;
                            tmpInvoice.total = newObject.total;
                            tmpInvoice.totalNet = newObject.totalNet;
                            tmpInvoice.paid = newObject.paid;
                            tmpInvoice.deserved = newObject.deserved;
                            tmpInvoice.deservedDate = newObject.deservedDate;
                           // tmpInvoice.invDate = newObject.invDate; //create date must not change
                            tmpInvoice.invoiceMainId = newObject.invoiceMainId;
                            tmpInvoice.invCase = newObject.invCase;
                            //tmpInvoice.invTime = newObject.invTime; //create Time must not change
                            tmpInvoice.notes = newObject.notes;
                            tmpInvoice.vendorInvNum = newObject.vendorInvNum;
                            tmpInvoice.vendorInvDate = newObject.vendorInvDate;
                            tmpInvoice.updateDate = DateTime.Now;
                            tmpInvoice.updateUserId = newObject.updateUserId;

                            message = "Invoice Is Updated Successfully";
                        }
                        entity.SaveChanges();
                    }
                }

                catch
                {
                    message = "an error ocurred";
                }
            }
            return message;
        }
    }
}
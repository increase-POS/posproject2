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
                        b.discountType,
                        b.discountValue,
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
                        b.branchId,
                        b.tax,
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
                        b.branchId,
                        b.discountType,
                        b.discountValue,
                        b.tax,
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
                string[] invTypeArray = invType.Split(',');
                List<string> invTypeL = new List<string>();
                foreach (string s in invTypeArray)
                    invTypeL.Add(s.Trim());

                using (incposdbEntities entity = new incposdbEntities())
                {
                 
                    var invoicesList = entity.invoices.Where(x => invTypeL.Contains(x.invType)) 
                        .Select(b => new InvoiceModel {
                       invoiceId= b.invoiceId,
                            invNumber= b.invNumber,
                            agentId= b.agentId,
                            invType= b.invType,
                            total=b.total,
                            totalNet= b.totalNet,
                            paid= b.paid,
                            deserved= b.deserved,
                            deservedDate= b.deservedDate,
                            invDate= b.invDate,
                            invoiceMainId= b.invoiceMainId,
                            invCase= b.invCase,
                            invTime= b.invTime,
                            notes= b.notes,
                            vendorInvNum= b.vendorInvNum,
                            vendorInvDate= b.vendorInvDate,
                            createUserId= b.createUserId,
                            updateDate= b.updateDate,
                            updateUserId= b.updateUserId,
                            branchId= b.branchId,
                            discountValue = b.discountValue,
                            discountType = b.discountType,
                            tax = b.tax,
                    })
                    .ToList();

                    if (invoicesList != null)
                    {
                        for (int i = 0; i < invoicesList.Count; i++)
                        {
                            int invoiceId = invoicesList[i].invoiceId;
                            int itemCount = entity.itemsTransfer.Where(x => x.invoiceId == invoiceId).Select(x => x.itemsTransId).ToList().Count;
                            invoicesList[i].itemsCount = itemCount;
                        }
                    }
                    if (invoicesList == null)
                        return NotFound();
                    else
                        return Ok(invoicesList);
                }
            }
            return NotFound();
        }
        // add or update bank
        [HttpPost]
        [Route("Save")]
        public int Save(string invoiceObject)
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
                    invoices tmpInvoice;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var invoiceEntity = entity.Set<invoices>();
                        if (newObject.invoiceId == 0)
                        {
                            newObject.invDate = DateTime.Now;
                            newObject.invTime = DateTime.Now.TimeOfDay;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;

                            tmpInvoice = invoiceEntity.Add(newObject);
                        }
                        else
                        {
                            tmpInvoice = entity.invoices.Where(p => p.invoiceId == newObject.invoiceId).FirstOrDefault();
                            tmpInvoice.invNumber = newObject.invNumber;
                            tmpInvoice.agentId = newObject.agentId;
                            tmpInvoice.invType = newObject.invType;
                            tmpInvoice.total = newObject.total;
                            tmpInvoice.totalNet = newObject.totalNet;
                            tmpInvoice.paid = newObject.paid;
                            tmpInvoice.deserved = newObject.deserved;
                            tmpInvoice.deservedDate = newObject.deservedDate;
                            tmpInvoice.invoiceMainId = newObject.invoiceMainId;
                            tmpInvoice.invCase = newObject.invCase;
                            tmpInvoice.notes = newObject.notes;
                            tmpInvoice.vendorInvNum = newObject.vendorInvNum;
                            tmpInvoice.vendorInvDate = newObject.vendorInvDate;
                            tmpInvoice.updateDate = DateTime.Now;
                            tmpInvoice.updateUserId = newObject.updateUserId;
                            tmpInvoice.branchId = newObject.branchId;
                            tmpInvoice.discountType = newObject.discountType;
                            tmpInvoice.discountValue = newObject.discountValue;
                            tmpInvoice.tax = newObject.tax;
                        }
                        entity.SaveChanges();
                        return tmpInvoice.invoiceId;
                    }
                }

                catch
                {
                   return 0;
                }
            }
            return 0;
        }
        [HttpGet]
        [Route("GetLastNumOfInv")]
        public IHttpActionResult GetLastNumOfInv(string invCode)
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
                List<string> numberList;
                int lastNum = 0;
                using (incposdbEntities entity = new incposdbEntities())
                {
                    numberList = entity.invoices.Where(b => b.invNumber.Contains(invCode)).Select(b => b.invNumber).ToList();
                     
                    for(int i=0; i< numberList.Count; i++)
                    {
                        string code = numberList[i];
                        string s = code.Substring(code.LastIndexOf(invCode)+3);
                        numberList[i] = s;
                    }
                    numberList.Sort();
                    lastNum = int.Parse( numberList[numberList.Count - 1]);
                }
                return Ok(lastNum);
            }
            return NotFound();
        }
    }
}
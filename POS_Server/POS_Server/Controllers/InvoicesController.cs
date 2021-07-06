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
                        b.taxtype,
                        b.name,
                        b.isApproved,
                        b.branchCreatorId,
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
                        b.taxtype,
                        b.name,
                        b.isApproved,
                        b.branchCreatorId,
                    })
                    .FirstOrDefault();

                    if (banksList == null)
                        return NotFound();
                    else
                        return Ok(banksList);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getgeneratedInvoice")]
        public IHttpActionResult getgeneratedInvoice(int mainInvoiceId)
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
                    var banksList = entity.invoices.Where(b => b.invoiceMainId == mainInvoiceId).Select(b => new {
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
                        b.taxtype,
                        b.name,
                        b.isApproved,
                        b.branchCreatorId,
                    })
                    .FirstOrDefault();

                    if (banksList == null)
                        return NotFound();
                    else
                        return Ok(banksList);
                }
            }
            return NotFound();
        }
        [HttpGet]
        [Route("getById")]
        public IHttpActionResult GetById(int invoiceId)
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
                        b.taxtype,
                        b.name,
                        b.isApproved,
                        b.branchCreatorId,
                    })
                    .FirstOrDefault();

                    if (banksList == null)
                        return NotFound();
                    else
                        return Ok(banksList);
                }
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetByInvNum")]
        public IHttpActionResult GetByInvNum(string invNum, int branchId)
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
                    if (branchId == 0)
                    {
                        var banksList =(from b in entity.invoices.Where(b => b.invNumber == invNum)
                                        join l in entity.branches on b.branchId equals l.branchId into lj
                                        from x in lj.DefaultIfEmpty()
                                        select new InvoiceModel()
                                        {
                                            invoiceId = b.invoiceId,
                                            invNumber = b.invNumber,
                                            agentId = b.agentId,
                                            invType = b.invType,
                                            total = b.total,
                                            totalNet = b.totalNet,
                                            paid = b.paid,
                                            deserved = b.deserved,
                                            deservedDate = b.deservedDate,
                                            invDate = b.invDate,
                                            invoiceMainId = b.invoiceMainId,
                                            invCase = b.invCase,
                                            invTime = b.invTime,
                                            notes = b.notes,
                                            vendorInvNum = b.vendorInvNum,
                                            vendorInvDate = b.vendorInvDate,
                                            createUserId = b.createUserId,
                                            updateDate = b.updateDate,
                                            updateUserId = b.updateUserId,
                                            branchId = b.branchId,
                                            discountValue = b.discountValue,
                                            discountType = b.discountType,
                                            tax = b.tax,
                                            taxtype = b.taxtype,
                                            name = b.name,
                                            isApproved = b.isApproved,
                                            branchName = x.name,
                                            branchCreatorId=b.branchCreatorId,
                                        })

                               .FirstOrDefault();

                        if (banksList == null)
                            return NotFound();
                        else
                            return Ok(banksList);
                    }
                    else
                    {
                        var banksList = (from b in entity.invoices.Where(b => b.invNumber == invNum && b.branchId == branchId)
                                         join l in entity.branches on b.branchId equals l.branchId into lj
                                         from x in lj.DefaultIfEmpty()
                                         select new InvoiceModel()
                                         {
                                             invoiceId = b.invoiceId,
                                             invNumber = b.invNumber,
                                             agentId = b.agentId,
                                             invType = b.invType,
                                             total = b.total,
                                             totalNet = b.totalNet,
                                             paid = b.paid,
                                             deserved = b.deserved,
                                             deservedDate = b.deservedDate,
                                             invDate = b.invDate,
                                             invoiceMainId = b.invoiceMainId,
                                             invCase = b.invCase,
                                             invTime = b.invTime,
                                             notes = b.notes,
                                             vendorInvNum = b.vendorInvNum,
                                             vendorInvDate = b.vendorInvDate,
                                             createUserId = b.createUserId,
                                             updateDate = b.updateDate,
                                             updateUserId = b.updateUserId,
                                             branchId = b.branchId,
                                             discountValue = b.discountValue,
                                             discountType = b.discountType,
                                             tax = b.tax,
                                             taxtype = b.taxtype,
                                             name = b.name,
                                             isApproved = b.isApproved,
                                             branchName = x.name,
                                             branchCreatorId=b.branchCreatorId,
                                         })

                               .FirstOrDefault();

                        if (banksList == null)
                            return NotFound();
                        else
                            return Ok(banksList);
                    }
                }
            }
            return NotFound();
        }  
        [HttpGet]
        [Route("GetByInvoiceType")]
        public IHttpActionResult GetByInvoiceType(string invType,int branchId)
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
                    if (branchId == 0)
                    {
                        var invoicesList =(from b in entity.invoices.Where(x => invTypeL.Contains(x.invType))
                                           join l in entity.branches on b.branchId equals l.branchId into lj
                                           from x in lj.DefaultIfEmpty()
                                 select new InvoiceModel()
                            {
                                invoiceId = b.invoiceId,
                                invNumber = b.invNumber,
                                agentId = b.agentId,
                                invType = b.invType,
                                total = b.total,
                                totalNet = b.totalNet,
                                paid = b.paid,
                                deserved = b.deserved,
                                deservedDate = b.deservedDate,
                                invDate = b.invDate,
                                invoiceMainId = b.invoiceMainId,
                                invCase = b.invCase,
                                invTime = b.invTime,
                                notes = b.notes,
                                vendorInvNum = b.vendorInvNum,
                                vendorInvDate = b.vendorInvDate,
                                createUserId = b.createUserId,
                                updateDate = b.updateDate,
                                updateUserId = b.updateUserId,
                                branchId = b.branchId,
                                discountValue = b.discountValue,
                                discountType = b.discountType,
                                tax = b.tax,
                                taxtype = b.taxtype,
                                     name = b.name,
                                isApproved = b.isApproved,
                                branchName = x.name,
                                branchCreatorId=b.branchCreatorId,
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
                    else
                    {
                        var invoicesList = (from b in entity.invoices.Where(x => invTypeL.Contains(x.invType) && x.branchId == branchId)
                                            join l in entity.branches on b.branchId equals l.branchId into lj
                                            from x in lj.DefaultIfEmpty()
                                            select new InvoiceModel()
                                            {
                                                invoiceId = b.invoiceId,
                                                invNumber = b.invNumber,
                                                agentId = b.agentId,
                                                invType = b.invType,
                                                total = b.total,
                                                totalNet = b.totalNet,
                                                paid = b.paid,
                                                deserved = b.deserved,
                                                deservedDate = b.deservedDate,
                                                invDate = b.invDate,
                                                invoiceMainId = b.invoiceMainId,
                                                invCase = b.invCase,
                                                invTime = b.invTime,
                                                notes = b.notes,
                                                vendorInvNum = b.vendorInvNum,
                                                vendorInvDate = b.vendorInvDate,
                                                createUserId = b.createUserId,
                                                updateDate = b.updateDate,
                                                updateUserId = b.updateUserId,
                                                branchId = b.branchId,
                                                discountValue = b.discountValue,
                                                discountType = b.discountType,
                                                tax = b.tax,
                                                taxtype = b.taxtype,
                                                name = b.name,
                                                isApproved = b.isApproved,
                                                branchName = x.name,
                                                branchCreatorId=b.branchCreatorId,
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
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetInvoicesByCreator")]
        public IHttpActionResult GetInvoicesByCreator(string invType,int createUserId)
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
                    var invoicesList = (from b in entity.invoices.Where(x => invTypeL.Contains(x.invType) && x.createUserId == createUserId)
                                        join l in entity.branches on b.branchId equals l.branchId into lj
                                        from x in lj.DefaultIfEmpty()
                                        select new InvoiceModel()
                                        {
                                            invoiceId = b.invoiceId,
                                            invNumber = b.invNumber,
                                            agentId = b.agentId,
                                            invType = b.invType,
                                            total = b.total,
                                            totalNet = b.totalNet,
                                            paid = b.paid,
                                            deserved = b.deserved,
                                            deservedDate = b.deservedDate,
                                            invDate = b.invDate,
                                            invoiceMainId = b.invoiceMainId,
                                            invCase = b.invCase,
                                            invTime = b.invTime,
                                            notes = b.notes,
                                            vendorInvNum = b.vendorInvNum,
                                            vendorInvDate = b.vendorInvDate,
                                            createUserId = b.createUserId,
                                            updateDate = b.updateDate,
                                            updateUserId = b.updateUserId,
                                            branchId = b.branchId,
                                            discountValue = b.discountValue,
                                            discountType = b.discountType,
                                            tax = b.tax,
                                            taxtype = b.taxtype,
                                            name = b.name,
                                            isApproved = b.isApproved,
                                            branchName = x.name,
                                            branchCreatorId=b.branchCreatorId,
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
        [HttpGet]
        [Route("getBranchInvoices")]
        public IHttpActionResult getBranchInvoices(string invType,int branchCreatorId)
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
                    var invoicesList = (from b in entity.invoices.Where(x => invTypeL.Contains(x.invType) && x.branchCreatorId == branchCreatorId)
                                        join l in entity.branches on b.branchId equals l.branchId into lj
                                        from x in lj.DefaultIfEmpty()
                                        select new InvoiceModel()
                                        {
                                            invoiceId = b.invoiceId,
                                            invNumber = b.invNumber,
                                            agentId = b.agentId,
                                            invType = b.invType,
                                            total = b.total,
                                            totalNet = b.totalNet,
                                            paid = b.paid,
                                            deserved = b.deserved,
                                            deservedDate = b.deservedDate,
                                            invDate = b.invDate,
                                            invoiceMainId = b.invoiceMainId,
                                            invCase = b.invCase,
                                            invTime = b.invTime,
                                            notes = b.notes,
                                            vendorInvNum = b.vendorInvNum,
                                            vendorInvDate = b.vendorInvDate,
                                            createUserId = b.createUserId,
                                            updateDate = b.updateDate,
                                            updateUserId = b.updateUserId,
                                            branchId = b.branchId,
                                            discountValue = b.discountValue,
                                            discountType = b.discountType,
                                            tax = b.tax,
                                            taxtype = b.taxtype,
                                            name = b.name,
                                            isApproved = b.isApproved,
                                            branchName = x.name,
                                            branchCreatorId=b.branchCreatorId,
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
        [HttpGet]
        [Route("GetOrderByType")]
        public IHttpActionResult GetOrderByType(string invType,int branchId)
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
                    if (branchId == 0)
                    {
                        var invoicesList =(from b in entity.invoices.Where(x => invTypeL.Contains(x.invType) && x.invoiceMainId == null)
                                           join l in entity.branches on b.branchId equals l.branchId into lj
                                           from x in lj.DefaultIfEmpty()
                                 select new InvoiceModel()
                            {
                                invoiceId = b.invoiceId,
                                invNumber = b.invNumber,
                                agentId = b.agentId,
                                invType = b.invType,
                                total = b.total,
                                totalNet = b.totalNet,
                                paid = b.paid,
                                deserved = b.deserved,
                                deservedDate = b.deservedDate,
                                invDate = b.invDate,
                                invoiceMainId = b.invoiceMainId,
                                invCase = b.invCase,
                                invTime = b.invTime,
                                notes = b.notes,
                                vendorInvNum = b.vendorInvNum,
                                vendorInvDate = b.vendorInvDate,
                                createUserId = b.createUserId,
                                updateDate = b.updateDate,
                                updateUserId = b.updateUserId,
                                branchId = b.branchId,
                                discountValue = b.discountValue,
                                discountType = b.discountType,
                                tax = b.tax,
                                taxtype = b.taxtype,
                                     name = b.name,
                                isApproved = b.isApproved,
                                branchName = x.name,
                                     branchCreatorId=b.branchCreatorId,
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
                    else
                    {
                        var invoicesList = (from b in entity.invoices.Where(x => invTypeL.Contains(x.invType) && x.branchId == branchId && x.invoiceMainId == null)
                                            join l in entity.branches on b.branchId equals l.branchId into lj
                                            from x in lj.DefaultIfEmpty()
                                            select new InvoiceModel()
                                            {
                                                invoiceId = b.invoiceId,
                                                invNumber = b.invNumber,
                                                agentId = b.agentId,
                                                invType = b.invType,
                                                total = b.total,
                                                totalNet = b.totalNet,
                                                paid = b.paid,
                                                deserved = b.deserved,
                                                deservedDate = b.deservedDate,
                                                invDate = b.invDate,
                                                invoiceMainId = b.invoiceMainId,
                                                invCase = b.invCase,
                                                invTime = b.invTime,
                                                notes = b.notes,
                                                vendorInvNum = b.vendorInvNum,
                                                vendorInvDate = b.vendorInvDate,
                                                createUserId = b.createUserId,
                                                updateDate = b.updateDate,
                                                updateUserId = b.updateUserId,
                                                branchId = b.branchId,
                                                discountValue = b.discountValue,
                                                discountType = b.discountType,
                                                tax = b.tax,
                                                taxtype = b.taxtype,
                                                name = b.name,
                                                isApproved = b.isApproved,
                                                branchName = x.name,
                                                branchCreatorId=b.branchCreatorId,
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
                            tmpInvoice.taxtype = newObject.taxtype;
                            tmpInvoice.name = newObject.name;
                            tmpInvoice.isApproved = newObject.isApproved;
                            tmpInvoice.branchCreatorId = newObject.branchCreatorId;
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
                    numberList = entity.invoices.Where(b => b.invNumber.Contains(invCode+"-")).Select(b => b.invNumber).ToList();
                     
                    for(int i=0; i< numberList.Count; i++)
                    {
                        string code = numberList[i];
                        string s = code.Substring(code.LastIndexOf("-")+1);
                        numberList[i] = s;
                    }
                    numberList.Sort();
                    lastNum = int.Parse( numberList[numberList.Count - 1]);
                }
                return Ok(lastNum);
            }
            return NotFound();
        }

        // for report
        [HttpGet]
        [Route("GetinvCountBydate")]
        public IHttpActionResult GetinvCountBydate(string branchType, DateTime startDate, DateTime endDate)
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
                    var invListm = (from I in entity.invoices
                                    join B in entity.branches on I.branchId equals B.branchId into JB
                                    from JBB in JB.DefaultIfEmpty()
                                    where //(invtype == "all" ? true : I.invType == invtype)  &&
                                      (branchType == "all" ? true : JBB.type == branchType)
                                    && System.DateTime.Compare((DateTime)startDate, (DateTime)I.invDate) <= 0
                                    && System.DateTime.Compare((DateTime)endDate, (DateTime)I.invDate) >= 0
                                    // I.invType == invtype
                                    //     && branchType == "all" ? true : JBB.type == branchType

                                    //  && startDate <= I.invDate && endDate >= I.invDate
                                    // &&  System.DateTime.Compare((DateTime)startDate,  I.invDate) <= 0 && System.DateTime.Compare((DateTime)endDate, I.invDate) >= 0
                                    group new { I, JBB } by (I.branchId) into g
                                    select new
                                    {
                                        branchId = g.Key,
                                        name = g.Select(t => t.JBB.name).FirstOrDefault(),


                                        countP = g.Where(t => t.I.invType == "p").Count(),
                                        countS = g.Where(t => t.I.invType == "s").Count(),
                                        totalS = g.Where(t => t.I.invType == "s").Sum(S => S.I.total),
                                        totalNetS = g.Where(t => t.I.invType == "s").Sum(S => S.I.totalNet),
                                        totalP = g.Where(t => t.I.invType == "p").Sum(S => S.I.total),
                                        totalNetP = g.Where(t => t.I.invType == "p").Sum(S => S.I.totalNet),
                                        paid = g.Sum(S => S.I.paid),
                                        deserved = g.Sum(S => S.I.deserved),
                                        discountValue = g.Sum(S => S.I.discountType == "1" ? S.I.discountValue : (S.I.discountType == "2" ? (S.I.discountValue / 100) : 0)),

                                        //  I.invoiceId,
                                        //    JBB.name
                                    }).ToList();

                    /*
          if(S.I.discountType == "1")
{
    return S.I.discountValue;
}else if(S.I.discountType == "2")
{
   return (S.I.discountValue / 100);
}
else
{
    return 0;
}
*/



                    if (invListm == null)
                        return NotFound();
                    else
                        return Ok(invListm);
                }

            }

            //else
            return NotFound();
        }


    }
}
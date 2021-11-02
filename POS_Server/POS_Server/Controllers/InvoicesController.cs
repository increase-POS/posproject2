using LinqKit;
using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Core.Objects;
using POS_Server.Models.VM;
using System.Security.Claims;
using Newtonsoft.Json.Converters;
using System.Web;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Invoices")]
    public class InvoicesController : ApiController
    {
        [HttpPost]
        [Route("Get")]
        public string Get(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var banksList = entity.invoices.Select(b => new {
                        b.invoiceId,
                        b.invNumber,
                        b.agentId,
                        b.invType,
                        b.discountType,
                        b.discountValue,
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
                        b.tax,
                        b.taxtype,
                        b.name,
                        b.isApproved,
                        b.branchCreatorId,
                        b.shippingCompanyId,
                        b.shipUserId,
                        b.userId,
                    })
                    .ToList();
                    return TokenManager.GenerateToken(banksList);
                }
            }
        }
        [HttpPost]
        [Route("GetAvgItemPrice")]
        public string GetAvgItemPrice(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            decimal price = 0;
            int totalNum = 0;
            decimal smallUnitPrice = 0;
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int itemUnitId = 0;
                int itemId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemUnitId")
                    {
                        itemUnitId = int.Parse(c.Value);
                    }
                    else if (c.Type == "itemId")
                    {
                        itemId = int.Parse(c.Value);
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var itemUnits = (from i in entity.itemsUnits where (i.itemId == itemId) select (i.itemUnitId)).ToList();

                    price += getItemUnitSumPrice(itemUnits);

                    totalNum = getItemUnitTotalNum(itemUnits);

                    if (totalNum != 0)
                        smallUnitPrice = price / totalNum;

                    var smallestUnitId = (from iu in entity.itemsUnits
                                          where (itemUnits.Contains((int)iu.itemUnitId) && iu.unitId == iu.subUnitId)
                                          select iu.itemUnitId).FirstOrDefault();

                    if (smallestUnitId == null || smallestUnitId == 0)
                    {
                        smallestUnitId = (from u in entity.itemsUnits
                                          where !entity.itemsUnits.Any(y => u.subUnitId == y.unitId)
                                          where (itemUnits.Contains((int)u.itemUnitId))
                                          select u.itemUnitId).FirstOrDefault();
                    }
                    if (itemUnitId == smallestUnitId || smallestUnitId == null || smallestUnitId == 0)
                    return TokenManager.GenerateToken(smallUnitPrice);
                    else
                    {
                        smallUnitPrice = smallUnitPrice * getUpperUnitValue(smallestUnitId, itemUnitId);
                    return TokenManager.GenerateToken(smallUnitPrice);
                    }
                }
            }
        }
        [HttpPost]
        [Route("GetByInvoiceId")]
        public string GetByInvoiceId(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int invoiceId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        invoiceId = int.Parse(c.Value);
                    }
                }
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
                        b.shippingCompanyId,
                        b.shipUserId,
                        b.userId,
                    })
                    .FirstOrDefault();

                  
                    return TokenManager.GenerateToken(banksList);
                }
            }
        }
        [HttpPost]
        [Route("getgeneratedInvoice")]
        public string getgeneratedInvoice(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int mainInvoiceId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        mainInvoiceId = int.Parse(c.Value);
                    }
                }
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
                        b.shippingCompanyId,
                        b.shipUserId,
                        b.userId,
                    })
                    .FirstOrDefault();

                    return TokenManager.GenerateToken(banksList);
                }
            }
        }
        [HttpPost]
        [Route("getById")]
        public string GetById(string token   )
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int invoiceId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        invoiceId = int.Parse(c.Value);
                    }
                }
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
                        b.shippingCompanyId,
                        b.shipUserId,
                        b.userId,
                    })
                    .FirstOrDefault();

                    return TokenManager.GenerateToken(banksList);
                }
            }
        }
        [HttpPost]
        [Route("GetByInvNum")]
        public string GetByInvNum(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invNum = "";
                int branchId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invNum")
                    {
                        invNum = c.Value;
                    }
                    else if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    if (branchId == 0)
                    {
                        var banksList = (from b in entity.invoices.Where(b => b.invNumber == invNum)
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
                                             branchCreatorId = b.branchCreatorId,
                                             shippingCompanyId = b.shippingCompanyId,
                                             shipUserId = b.shipUserId,
                                             userId = b.userId,
                                             manualDiscountType = b.manualDiscountType,
                                             manualDiscountValue = b.manualDiscountValue,
                                         })

                               .FirstOrDefault();
                    return TokenManager.GenerateToken(banksList);
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
                                             branchCreatorId = b.branchCreatorId,
                                             shippingCompanyId = b.shippingCompanyId,
                                             shipUserId = b.shipUserId,
                                             userId = b.userId,
                                             manualDiscountType = b.manualDiscountType,
                                             manualDiscountValue = b.manualDiscountValue,
                                         })

                               .FirstOrDefault();
                    return TokenManager.GenerateToken(banksList);
                    }
                }
            }
        }
        [HttpPost]
        [Route("GetByInvoiceType")]
        public string GetByInvoiceType(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                int branchId = 0;
                List<string> invTypeL = new List<string>();

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                         invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }

               

                using (incposdbEntities entity = new incposdbEntities())
                {
                    if (branchId == 0)
                    {
                        var invoicesList = (from b in entity.invoices.Where(x => invTypeL.Contains(x.invType))
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
                                                branchCreatorId = b.branchCreatorId,
                                                shippingCompanyId = b.shippingCompanyId,
                                                shipUserId = b.shipUserId,
                                                userId = b.userId,
                                                manualDiscountType = b.manualDiscountType,
                                                manualDiscountValue = b.manualDiscountValue,
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
                      
                    return TokenManager.GenerateToken(invoicesList);
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
                                                branchCreatorId = b.branchCreatorId,
                                                shippingCompanyId = b.shippingCompanyId,
                                                shipUserId = b.shipUserId,
                                                userId = b.userId,
                                                manualDiscountType = b.manualDiscountType,
                                                manualDiscountValue = b.manualDiscountValue,
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
                      
                    return TokenManager.GenerateToken(invoicesList);
                    }
                }
            }
        }
        [HttpPost]
        [Route("GetInvoicesByCreator")]
        public string GetInvoicesByCreator(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                int createUserId = 0;
                int duration = 0;
                List<string> invTypeL = new List<string>();

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                            invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "createUserId")
                    {
                        createUserId = int.Parse(c.Value);
                    }
                    else if (c.Type == "duration")
                    {
                        duration = int.Parse(c.Value);
                    }
                }
               

                using (incposdbEntities entity = new incposdbEntities())
                {
                    var searchPredicate = PredicateBuilder.New<invoices>();

                    if (duration > 0)
                    {
                        DateTime dt = Convert.ToDateTime(DateTime.Today.AddDays(-duration).ToShortDateString());
                        searchPredicate = searchPredicate.And(inv => inv.updateDate >= dt);
                    }
                    searchPredicate = searchPredicate.And(inv => invTypeL.Contains(inv.invType));
                    searchPredicate = searchPredicate.And(inv => inv.createUserId == createUserId);
                    searchPredicate = searchPredicate.And(inv => inv.isActive == true);

                    var invoicesList = (from b in entity.invoices.Where(searchPredicate)
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
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
                 
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("GetInvoicesForAdmin")]
        public string GetInvoicesForAdmin(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                int duration = 0;
                List<string> invTypeL = new List<string>();

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                            invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "duration")
                    {
                        duration = int.Parse(c.Value);
                    }
                }

                using (incposdbEntities entity = new incposdbEntities())
                {
                    var searchPredicate = PredicateBuilder.New<invoices>();

                    if (duration > 0)
                    {
                        DateTime dt = Convert.ToDateTime(DateTime.Today.AddDays(-duration).ToShortDateString());
                        searchPredicate = searchPredicate.And(inv => inv.updateDate >= dt);
                    }
                    searchPredicate = searchPredicate.And(inv => invTypeL.Contains(inv.invType));
                    searchPredicate = searchPredicate.And(inv => inv.isActive == true);

                    var invoicesList = (from b in entity.invoices.Where(searchPredicate)
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
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

                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("GetCountByCreator")]
        public string GetCountByCreator(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                int createUserId = 0;
                int duration = 0;
                List<string> invTypeL = new List<string>();

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                            invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "createUserId")
                    {
                        createUserId = int.Parse(c.Value);
                    }
                    else if (c.Type == "duration")
                    {
                        duration = int.Parse(c.Value);
                    }
                }

                using (incposdbEntities entity = new incposdbEntities())
                {
                    var searchPredicate = PredicateBuilder.New<invoices>();

                    if (duration > 0)
                    {
                        DateTime dt = Convert.ToDateTime(DateTime.Today.AddDays(-duration).ToShortDateString());
                        searchPredicate = searchPredicate.And(inv => inv.updateDate >= dt);
                    }
                    searchPredicate = searchPredicate.And(inv => invTypeL.Contains(inv.invType));
                    searchPredicate = searchPredicate.And(inv => inv.createUserId == createUserId);
                    searchPredicate = searchPredicate.And(inv => inv.isActive == true);

                    var invoicesCount = (from b in entity.invoices.Where(searchPredicate)
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
                                        })
                    .ToList().Count;
                    return TokenManager.GenerateToken(invoicesCount);
                }
            }
        }
        [HttpPost]
        [Route("getBranchInvoices")]
        public string getBranchInvoices(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                int branchCreatorId = 0;
                int branchId = 0;
                List<string> invTypeL = new List<string>();

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                            invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "branchCreatorId")
                    {
                        branchCreatorId = int.Parse(c.Value);
                    }
                    else if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }

                using (incposdbEntities entity = new incposdbEntities())
                {
                    var searchPredicate = PredicateBuilder.New<invoices>();
                    if (branchCreatorId != 0)
                        searchPredicate = searchPredicate.And(inv => inv.branchCreatorId == branchCreatorId && inv.isActive == true && invTypeL.Contains(inv.invType));
                    // searchPredicate = searchPredicate.And(inv => invTypeL.Contains(inv.invType));
                    if (branchId != 0)
                        searchPredicate = searchPredicate.Or(inv => inv.branchId == branchId && inv.isActive == true && invTypeL.Contains(inv.invType));

                    var invoicesList = (from b in entity.invoices.Where(searchPredicate)
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
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
                   
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("getInvoicesToReturn")]
        public string getInvoicesToReturn(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                int userId = 0;
                List<string> invTypeL = new List<string>();

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                            invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                }

                using (incposdbEntities entity = new incposdbEntities())
                {
                    var branches = (from S in entity.branchesUsers
                                              join B in entity.branches on S.branchId equals B.branchId into JB
                                              join U in entity.users on S.userId equals U.userId into JU
                                              from JBB in JB.DefaultIfEmpty()
                                              from JUU in JU.DefaultIfEmpty()
                                              where S.userId == userId
                                    select JBB.branchId).ToList();

                    var searchPredicate = PredicateBuilder.New<invoices>();
                    searchPredicate = searchPredicate.Or(inv => branches.Contains((int)inv.branchId) && inv.isActive == true && invTypeL.Contains(inv.invType));

                    var invoicesList = (from b in entity.invoices.Where(searchPredicate)
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
                                            vendorInvNum = b.vendorInvNum,
                                            vendorInvDate = b.vendorInvDate,
                                            branchId = b.branchId,
                                            discountType = b.discountType,
                                            tax = b.tax,
                                            taxtype = b.taxtype,
                                            name = b.name,
                                            isApproved = b.isApproved,
                                            branchName = x.name,
                                            branchCreatorId = b.branchCreatorId,
                                            userId = b.userId,
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
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("getUnHandeldOrders")]
        public string getUnHandeldOrders(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                int branchCreatorId = 0;
                int branchId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                    }
                    else if (c.Type == "branchCreatorId")
                    {
                        branchCreatorId = int.Parse(c.Value);
                    }
                    else if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }
                var invoicesList = getUnhandeledOrdersList(invType,branchCreatorId,branchId);

                    return TokenManager.GenerateToken(invoicesList);
             }
        }
        [HttpPost]
        [Route("GetCountUnHandeledOrders")]
        public string GetCountUnHandeledOrders(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                int branchCreatorId = 0;
                int branchId = 0;
                List<string> invTypeL = new List<string>();
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                            invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "branchCreatorId")
                    {
                        branchCreatorId = int.Parse(c.Value);
                    }
                    else if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }


                using (incposdbEntities entity = new incposdbEntities())
                {
                    var searchPredicate = PredicateBuilder.New<invoices>();
                    if (branchCreatorId != 0)
                        searchPredicate = searchPredicate.And(inv => inv.branchCreatorId == branchCreatorId && inv.isActive == true && invTypeL.Contains(inv.invType));

                    if (branchId != 0)
                        searchPredicate = searchPredicate.Or(inv => inv.branchId == branchId && inv.isActive == true && invTypeL.Contains(inv.invType));
                    var invoicesList = (from b in entity.invoices.Where(searchPredicate)
                                        join l in entity.branches on b.branchId equals l.branchId into lj
                                        from x in lj.DefaultIfEmpty()
                                        where !entity.invoices.Any(y => y.invoiceMainId == b.invoiceId)
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
                                        })
                    .ToList().Count;
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("GetCountBranchInvoices")]
        public string GetCountBranchInvoices(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                int branchCreatorId = 0;
                int branchId = 0;
                List<string> invTypeL = new List<string>();
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                            invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "branchCreatorId")
                    {
                        branchCreatorId = int.Parse(c.Value);
                    }
                    else if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }

                using (incposdbEntities entity = new incposdbEntities())
                {
                    var searchPredicate = PredicateBuilder.New<invoices>();
                    if (branchCreatorId != 0)
                        searchPredicate = searchPredicate.And(inv => inv.branchCreatorId == branchCreatorId && inv.isActive == true && invTypeL.Contains(inv.invType));
                    // searchPredicate = searchPredicate.And(inv => invTypeL.Contains(inv.invType));
                    if (branchId != 0)
                        searchPredicate = searchPredicate.Or(inv => inv.branchId == branchId && inv.isActive == true && invTypeL.Contains(inv.invType));

                    var invoicesCount = (from b in entity.invoices.Where(searchPredicate)
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
                                        })
                    .ToList().Count;
                   
                    return TokenManager.GenerateToken(invoicesCount);
                }
            }
        }
        [HttpPost]
        [Route("getDeliverOrders")]
        public string getDeliverOrders(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                string status = "";
                int shipUserId = 0;
                List<string> invTypeL = new List<string>();
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                            invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "status")
                    {
                        status = c.Value;
                    }
                    else if (c.Type == "userId")
                    {
                        shipUserId = int.Parse(c.Value);
                    }
                }

                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invoicesList = (from b in entity.invoices.Where(x => invTypeL.Contains(x.invType) && x.shipUserId == shipUserId && x.isActive == true)
                                        join s in entity.invoiceStatus on b.invoiceId equals s.invoiceId
                                        where (s.status == status && s.invStatusId == entity.invoiceStatus.Where(x => x.invoiceId == b.invoiceId).Max(x => x.invStatusId))
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
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
                  
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("getDeliverOrdersCount")]
        public string getDeliverOrdersCount(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                string status = "";
                int shipUserId = 0;
                List<string> invTypeL = new List<string>();
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                            invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "status")
                    {
                        status = c.Value;
                    }
                    else if (c.Type == "userId")
                    {
                        shipUserId = int.Parse(c.Value);
                    }
                }

                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invoicesCount = (from b in entity.invoices.Where(x => invTypeL.Contains(x.invType) && x.shipUserId == shipUserId && x.isActive == true)
                                        join s in entity.invoiceStatus on b.invoiceId equals s.invoiceId
                                        where (s.status == status && s.invStatusId == entity.invoiceStatus.Where(x => x.invoiceId == b.invoiceId).Max(x => x.invStatusId))
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
                                        })
                    .ToList().Count;
                  
                    return TokenManager.GenerateToken(invoicesCount);
                }
            }
        }
        [HttpPost]
        [Route("getOrdersForPay")]
        public string getOrdersForPay(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int branchId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }
                List<string> statusL = new List<string>();
                statusL.Add("tr");
                statusL.Add("rc");
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invoicesList = (from b in entity.invoices.Where(x => x.invType == "s" && x.branchCreatorId == branchId && x.shipUserId != null && x.isActive == true)
                                        join s in entity.invoiceStatus on b.invoiceId equals s.invoiceId
                                        join u in entity.users on b.shipUserId equals u.userId into lj
                                        from y in lj.DefaultIfEmpty()
                                        where (statusL.Contains(s.status) && s.invStatusId == entity.invoiceStatus.Where(x => x.invoiceId == b.invoiceId).Max(x => x.invStatusId))
                                        select new InvoiceModel()
                                        {
                                            invStatusId = s.invStatusId,
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            agentName = b.agents.name,
                                            shipUserName = y.username,
                                            status = s.status,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
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
                   
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("getAgentInvoices")]
        public string getAgentInvoices(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int branchId = 0;
                int agentId = 0;
                string type = "";
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "agentId")
                    {
                        agentId = int.Parse(c.Value);
                    }
                    else if (c.Type == "type")
                    {
                        type = c.Value;
                    }
                }

                List<string> typesList = new List<string>();
                if (type.Equals("feed"))
                {
                    typesList.Add("pb");
                    typesList.Add("s");
                }
                else if (type.Equals("pay"))
                {
                    typesList.Add("p");
                    typesList.Add("sb");
                    typesList.Add("pw");
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invoicesList = (from b in entity.invoices.Where(x => x.agentId == agentId && x.shipUserId == null && typesList.Contains(x.invType)
                                        && x.deserved > 0 && x.branchCreatorId == branchId)
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
                                        }).ToList();
                    if (invoicesList != null)
                    {
                        for (int i = 0; i < invoicesList.Count; i++)
                        {
                            int invoiceId = invoicesList[i].invoiceId;
                            int itemCount = entity.itemsTransfer.Where(x => x.invoiceId == invoiceId).Select(x => x.itemsTransId).ToList().Count;
                            invoicesList[i].itemsCount = itemCount;
                        }
                    }
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("getNotPaidAgentInvoices")]
        public string getNotPaidAgentInvoices(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int agentId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        agentId = int.Parse(c.Value);
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invoicesList = (from b in entity.invoices.Where(x => x.agentId == agentId && x.deserved > 0)
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
                                        }).ToList();
                
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("getShipCompanyInvoices")]
        public string getShipCompanyInvoices(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int branchId = 0;
                int shippingCompanyId = 0;
                string type = "";
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "shippingCompanyId")
                    {
                        shippingCompanyId = int.Parse(c.Value);
                    }
                    else if (c.Type == "type")
                    {
                        type = c.Value;
                    }
                }
                List<string> typesList = new List<string>();
                if (type.Equals("feed"))
                {
                    typesList.Add("pb");
                    typesList.Add("s");
                }
                else if (type.Equals("pay"))
                {
                    typesList.Add("p");
                    typesList.Add("sb");
                    typesList.Add("pw");
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invoicesList = (from b in entity.invoices.Where(x => x.shippingCompanyId == shippingCompanyId && typesList.Contains(x.invType)
                                        && x.deserved > 0 && x.branchCreatorId == branchId)
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
                                            branchCreatorId = b.branchCreatorId,
                                            shippingCompanyId = b.shippingCompanyId,
                                            shipUserId = b.shipUserId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
                                        }).ToList();
                    if (invoicesList != null)
                    {
                        for (int i = 0; i < invoicesList.Count; i++)
                        {
                            int invoiceId = invoicesList[i].invoiceId;
                            int itemCount = entity.itemsTransfer.Where(x => x.invoiceId == invoiceId).Select(x => x.itemsTransId).ToList().Count;
                            invoicesList[i].itemsCount = itemCount;
                        }
                    }
                  
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("getUserInvoices")]
        public string getUserInvoices(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int branchId = 0;
                int userId = 0;
                string type = "";
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                    else if (c.Type == "type")
                    {
                        type = c.Value;
                    }
                }
                List<string> typesList = new List<string>();
                if (type.Equals("feed"))
                {
                    typesList.Add("pb");
                    typesList.Add("s");
                }
                else if (type.Equals("pay"))
                {
                    typesList.Add("p");
                    typesList.Add("sb");
                    typesList.Add("pw");
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invoicesList = (from b in entity.invoices.Where(x => x.userId == userId && typesList.Contains(x.invType) &&
                                                                              x.deserved > 0 && x.branchCreatorId == branchId)
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
                                            branchCreatorId = b.branchCreatorId,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
                                        }).ToList();
                    if (invoicesList != null)
                    {
                        for (int i = 0; i < invoicesList.Count; i++)
                        {
                            int invoiceId = invoicesList[i].invoiceId;
                            int itemCount = entity.itemsTransfer.Where(x => x.invoiceId == invoiceId).Select(x => x.itemsTransId).ToList().Count;
                            invoicesList[i].itemsCount = itemCount;
                        }
                    }
                   
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }
        [HttpPost]
        [Route("GetOrderByType")]
        public string GetOrderByType(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                int branchId = 0;
                List<string> invTypeL = new List<string>();

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                        string[] invTypeArray = invType.Split(',');
                        foreach (string s in invTypeArray)
                            invTypeL.Add(s.Trim());
                    }
                    else if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }

                using (incposdbEntities entity = new incposdbEntities())
                {
                    if (branchId == 0)
                    {
                        var invoicesList = (from b in entity.invoices.Where(x => invTypeL.Contains(x.invType) && x.invoiceMainId == null)
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
                                                branchCreatorId = b.branchCreatorId,
                                                shippingCompanyId = b.shippingCompanyId,
                                                shipUserId = b.shipUserId,
                                                userId = b.userId,
                                                manualDiscountType = b.manualDiscountType,
                                                manualDiscountValue = b.manualDiscountValue,
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
                       
                    return TokenManager.GenerateToken(invoicesList);
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
                                                branchCreatorId = b.branchCreatorId,
                                                shippingCompanyId = b.shippingCompanyId,
                                                shipUserId = b.shipUserId,
                                                userId = b.userId,
                                                manualDiscountType = b.manualDiscountType,
                                                manualDiscountValue = b.manualDiscountValue,
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
                        
                    return TokenManager.GenerateToken(invoicesList);
                    }
                }
            }
        }
        [HttpPost]
        [Route("GetLastNumOfInv")]
        public string GetLastNumOfInv(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invCode = "";
                int branchId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invCode")
                    {
                        invCode =c.Value;
                    }
                    else if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                }
                List<string> numberList;
                int lastNum = 0;
                using (incposdbEntities entity = new incposdbEntities())
                {
                    numberList = entity.invoices.Where(b => b.invNumber.Contains(invCode + "-") && b.branchId == branchId).Select(b => b.invNumber).ToList();

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
                    return TokenManager.GenerateToken(lastNum);
            }
        }
        // for report
        [HttpPost]
        [Route("GetinvCountBydate")]
        public string GetinvCountBydate(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invType = "";
                string branchType = "";
                DateTime startDate = DateTime.Now ;
                DateTime endDate = DateTime.Now;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "invType")
                    {
                        invType = c.Value;
                    }
                    else if(c.Type == "branchType")
                    {
                        branchType = c.Value;
                    }
                    else if (c.Type == "startDate")
                    {
                        startDate = DateTime.Parse(c.Value);
                    }
                    else if (c.Type == "endDate")
                    {
                        endDate = DateTime.Parse(c.Value);
                    }
                }
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
                                    }).ToList();
                     
                    return TokenManager.GenerateToken(invListm);
                }

            }
        }
        // add or update bank
        [HttpPost]
        [Route("Save")]
        public string Save(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            string message = "";
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string invoiceObject = "";
                invoices newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        invoiceObject = c.Value.Replace("\\", string.Empty);
                        invoiceObject = invoiceObject.Trim('"');
                        newObject = JsonConvert.DeserializeObject<invoices>(invoiceObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                        break;
                    }
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
                            newObject.isActive = true;
                            tmpInvoice = invoiceEntity.Add(newObject);
                            entity.SaveChanges();
                            message = tmpInvoice.invoiceId.ToString();
                            return TokenManager.GenerateToken(message);

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
                            tmpInvoice.shippingCompanyId = newObject.shippingCompanyId;
                            tmpInvoice.shipUserId = newObject.shipUserId;
                            tmpInvoice.userId = newObject.userId;
                            tmpInvoice.manualDiscountType = newObject.manualDiscountType;
                            tmpInvoice.manualDiscountValue = newObject.manualDiscountValue;
                            entity.SaveChanges();
                            message = tmpInvoice.invoiceId.ToString();
                            return TokenManager.GenerateToken(message);
                        }
                    }
                }

                catch
                {
                    message = "0";
                    return TokenManager.GenerateToken(message);
                }
            }
        }
        [HttpPost]
        [Route("delete")]
        public string delete(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            string message = "";
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                try
                {
                    int invoiceId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        invoiceId = int.Parse(c.Value);
                    }
                }

               
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var inv = entity.invoices.Find(invoiceId);
                        inv.isActive = false;
                        message = entity.SaveChanges().ToString();
                        return TokenManager.GenerateToken(message);
                    }
                }
                catch
                {
                    message = "0";
                    return TokenManager.GenerateToken(message);
                }
            }
        }
        [HttpPost]
        [Route("deleteOrder")]
        public string deleteOrder(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            ItemsLocationsController ilc = new ItemsLocationsController();
            string message = "";
var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {      
                try
                {
                    int invoiceId = 0;
                    IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                    foreach (Claim c in claims)
                    {
                        if (c.Type == "itemId")
                        {
                            invoiceId = int.Parse(c.Value);
                        }
                    }

                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        // desactive invoice
                        var inv = entity.invoices.Find(invoiceId);
                        inv.isActive = false;
                        entity.SaveChanges();

                        // unlockItems
                        var itemsLocations = entity.itemsLocations.Where(x => x.invoiceId == invoiceId).ToList();
                        foreach(itemsLocations il in itemsLocations)
                        {
                            var itemLoc = (from b in entity.itemsLocations
                                           where b.invoiceId == null && b.itemUnitId == il.itemUnitId && b.locationId == il.locationId
                                           && b.startDate == il.startDate && b.endDate == il.endDate
                                           select new ItemLocationModel
                                           {
                                               itemsLocId = b.itemsLocId,
                                           }).FirstOrDefault();
                            var orderItem = entity.itemsLocations.Find(il.itemsLocId);
                            if (orderItem.quantity == il.quantity)
                                entity.itemsLocations.Remove(orderItem);
                            else
                                orderItem.quantity -= il.quantity;

                            if (itemLoc == null)
                            {
                                var loc = new itemsLocations()
                                {
                                    locationId = il.locationId,
                                    quantity = il.quantity,
                                    createDate = DateTime.Now,
                                    updateDate = DateTime.Now,
                                    createUserId = il.createUserId,
                                    updateUserId = il.createUserId,
                                    startDate = il.startDate,
                                    endDate = il.endDate,
                                    itemUnitId = il.itemUnitId,
                                    note = il.note,
                                };
                                entity.itemsLocations.Add(loc);
                            }
                            else
                            {
                                var loc = entity.itemsLocations.Find(itemLoc.itemsLocId);
                                loc.quantity += il.quantity;
                                loc.updateDate = DateTime.Now;
                                loc.updateUserId = il.updateUserId;

                            }
                            entity.SaveChanges();
                        }
                        message = "1";
                        return TokenManager.GenerateToken(message);
                    }
                }
                catch
                {
                    message = "0";
                    return TokenManager.GenerateToken(message);
                }
            }
        }
       


        private int getUpperUnitValue(int itemUnitId, int basicItemUnitId)
        {
            int unitValue = 0;
            using (incposdbEntities entity = new incposdbEntities())
            {

                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (upperUnit == null)
                    return 1;
                if (upperUnit.itemUnitId == basicItemUnitId)
                    return (int)upperUnit.unitValue;
                else
                    unitValue *= getUpperUnitValue(upperUnit.itemUnitId, basicItemUnitId);
                return unitValue;
            }
        }
        private decimal getItemUnitSumPrice(List<int> itemUnits)
        {
            using (incposdbEntities entity = new incposdbEntities())
            {
                var sumPrice = (from b in entity.invoices
                                where b.invType == "p"
                                join s in entity.itemsTransfer.Where(x => itemUnits.Contains((int)x.itemUnitId)) on b.invoiceId equals s.invoiceId
                                select s.quantity * s.price).Sum();

                if (sumPrice != null)
                    return (decimal)sumPrice;
                else
                    return 0;
            }
        }
        private long getItemUnitNum(int itemUnitId)
        {
            using (incposdbEntities entity = new incposdbEntities())
            {
                var sumNum = (from b in entity.invoices
                              where b.invType.Contains("p")
                              join s in entity.itemsTransfer.Where(x => x.itemUnitId == itemUnitId) on b.invoiceId equals s.invoiceId
                              select s.quantity).Sum();

                if (sumNum == null)
                    sumNum = 0;

                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (upperUnit != null)
                    sumNum += (int)upperUnit.unitValue * getItemUnitNum(upperUnit.itemUnitId);

                if (sumNum != null) return (long)sumNum;
                else
                    return 0;
            }
        }
        private int getItemUnitTotalNum(List<int> itemUnits)
        {
            using (incposdbEntities entity = new incposdbEntities())
            {

                var smallestUnitId = (from iu in entity.itemsUnits
                                      where (itemUnits.Contains((int)iu.itemUnitId) && iu.unitId == iu.subUnitId)
                                      select iu.itemUnitId).FirstOrDefault();

                if (smallestUnitId == null || smallestUnitId == 0)
                {
                    smallestUnitId = (from u in entity.itemsUnits
                                      where !entity.itemsUnits.Any(y => u.subUnitId == y.unitId)
                                      where (itemUnits.Contains((int)u.itemUnitId))
                                      select u.itemUnitId).FirstOrDefault();
                }
                var sumNum = (from b in entity.invoices
                              where b.invType == "p"
                              join s in entity.itemsTransfer.Where(x => x.itemUnitId == smallestUnitId) on b.invoiceId equals s.invoiceId
                              select s.quantity).Sum();

                if (sumNum == null)
                    sumNum = 0;

                var unit = entity.itemsUnits.Where(x => x.itemUnitId == smallestUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (upperUnit != null && upperUnit.itemUnitId != smallestUnitId)
                    sumNum += (int)upperUnit.unitValue * getItemUnitNum(upperUnit.itemUnitId);

                if (sumNum != null)
                    return (int)sumNum;
                else
                    return 0;
            }
        }
        public List<InvoiceModel> getUnhandeledOrdersList(string invType, int branchCreatorId, int branchId)
        {
            string[] invTypeArray = invType.Split(',');
            List<string> invTypeL = new List<string>();
            foreach (string s in invTypeArray)
                invTypeL.Add(s.Trim());

            using (incposdbEntities entity = new incposdbEntities())
            {
                var searchPredicate = PredicateBuilder.New<invoices>();
                if (branchCreatorId != 0)
                    searchPredicate = searchPredicate.And(inv => inv.branchCreatorId == branchCreatorId && inv.isActive == true && invTypeL.Contains(inv.invType));
                // searchPredicate = searchPredicate.And(inv => invTypeL.Contains(inv.invType));
                if (branchId != 0)
                    searchPredicate = searchPredicate.Or(inv => inv.branchId == branchId && inv.isActive == true && invTypeL.Contains(inv.invType));
                var invoicesList = (from b in entity.invoices.Where(searchPredicate)
                                    join u in entity.users on b.createUserId equals u.userId
                                    join l in entity.branches on b.branchId equals l.branchId into lj
                                    from x in lj.DefaultIfEmpty()
                                    where !entity.invoices.Any(y => y.invoiceMainId == b.invoiceId)
                                    select new InvoiceModel()
                                    {
                                        invoiceId = b.invoiceId,
                                        invNumber = b.invNumber,
                                        agentId = b.agentId,
                                        invType = b.invType,
                                        tax = b.tax,
                                        taxtype = b.taxtype,
                                        name = b.name,
                                        branchName = x.name,
                                        branchCreatorName = b.branches1.name,
                                        createrUserName = u.name + " " + u.lastname,
                                        totalNet = b.totalNet,
                                        total = b.total,
                                        discountType = b.discountType,
                                        discountValue = b.discountValue,
                                        manualDiscountType = b.manualDiscountType,
                                        manualDiscountValue = b.manualDiscountValue,
                                        updateUserId = b.updateUserId,
                                    })
                .ToList();
                if (invoicesList != null)
                {
                    for (int i = 0; i < invoicesList.Count(); i++)
                    {
                        string complete = "ready";
                        int invoiceId = invoicesList[i].invoiceId;
                        var itemList = entity.itemsTransfer.Where(x => x.invoiceId == invoiceId).ToList();
                        invoicesList[i].itemsCount = itemList.Count;
                        foreach (itemsTransfer tr in itemList)
                        {
                            var lockedQuantity = entity.itemsLocations
                                .Where(x => x.invoiceId == invoiceId && x.itemUnitId == tr.itemUnitId)
                                .Select(x => x.quantity).Sum();
                            if (lockedQuantity < tr.quantity)
                            {
                                complete = "notReady";
                                break;
                            }
                        }
                        invoicesList[i].status = complete;
                    }
                }
                return invoicesList;
            }
        }
        public decimal AvgItemPurPrice(int itemUnitId, int itemId)
        {

            decimal price = 0;
            int totalNum = 0;
            decimal smallUnitPrice = 0;


            using (incposdbEntities entity = new incposdbEntities())
            {
                var itemUnits = (from i in entity.itemsUnits where (i.itemId == itemId) select (i.itemUnitId)).ToList();

                price += getItemUnitSumPrice(itemUnits);

                totalNum = getItemUnitTotalNum(itemUnits);

                if (totalNum != 0)
                    smallUnitPrice = price / totalNum;

                var smallestUnitId = (from iu in entity.itemsUnits
                                      where (itemUnits.Contains((int)iu.itemUnitId) && iu.unitId == iu.subUnitId)
                                      select iu.itemUnitId).FirstOrDefault();

                if (smallestUnitId == null || smallestUnitId == 0)
                {
                    smallestUnitId = (from u in entity.itemsUnits
                                      where !entity.itemsUnits.Any(y => u.subUnitId == y.unitId)
                                      where (itemUnits.Contains((int)u.itemUnitId))
                                      select u.itemUnitId).FirstOrDefault();
                }
                if (itemUnitId == smallestUnitId || smallestUnitId == null || smallestUnitId == 0)
                    return smallUnitPrice;
                else
                {
                    smallUnitPrice = smallUnitPrice * getUpperUnitValue(smallestUnitId, itemUnitId);
                    return smallUnitPrice;
                }
            }


        }
    }
}
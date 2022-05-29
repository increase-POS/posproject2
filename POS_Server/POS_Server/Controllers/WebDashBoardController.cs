﻿using LinqKit;
using POS_Server.Models;
using POS_Server.Models.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/WebDashBoard")]
    public class WebDashBoardController : ApiController
    {
        // GET api/<controller>
        [HttpPost]
        [Route("GetDashBoardInfo")]
        public string GetDashBoardInfo(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                #region params
                int branchId = 0;
                DateTime startDate = DateTime.Now;
               // DateTime? endDate = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                    
                    //else if (c.Type == "startDate")
                    //{
                    //    startDate = DateTime.Parse(c.Value);
                    //    startDate = DateTime.Parse(startDate.ToString().Split(' ')[0]);

                    //}
                    //else if (c.Type == "endDate")
                    //{
                    //    if (c.Value != null && c.Value != "")
                    //    {
                    //        endDate = DateTime.Parse(c.Value);
                    //        endDate = DateTime.Parse(endDate.ToString().Split(' ')[0]);
                    //    }
                    //}
                }
                #endregion
                
                try
                {
                    WebDashBoardModel dashBoardModel = new WebDashBoardModel();
                    dashBoardModel.branchId = branchId;
     
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var searchPredicate = PredicateBuilder.New<invoices>();

                        #region purchases count - vendors
                        searchPredicate = searchPredicate.And(x => x.isActive == true && (x.invType == "p" || x.invType == "pw"));
                        if (branchId != 0)
                            searchPredicate = searchPredicate.And(x => x.branchId == branchId);

                        //if(endDate == null)
                        //    searchPredicate = searchPredicate.And(x => EntityFunctions.TruncateTime(x.updateDate) == startDate);
                        //else
                        //    searchPredicate = searchPredicate.And(x => EntityFunctions.TruncateTime(x.updateDate) >= startDate
                        //                                            && EntityFunctions.TruncateTime(x.updateDate) <= endDate);


                        dashBoardModel.purchasesCount = entity.invoices.Where(searchPredicate).ToList().Count();
   

                        //vendors count
                        searchPredicate = searchPredicate.And(x => x.agentId != null);
                        dashBoardModel.vendorsCount = entity.invoices.Where(searchPredicate).Select(x => x.agentId).ToList().Distinct().Count();
                       

                        #endregion

                        #region sales count
                        searchPredicate = PredicateBuilder.New<invoices>();

                        searchPredicate = searchPredicate.And(x => x.isActive == true && x.invType == "s" );
                        if (branchId != 0)
                            searchPredicate = searchPredicate.And(x => x.branchId == branchId);

                        //if (endDate == null)
                        //    searchPredicate = searchPredicate.And(x => EntityFunctions.TruncateTime(x.updateDate) == startDate);
                        //else
                        //    searchPredicate = searchPredicate.And(x => EntityFunctions.TruncateTime(x.updateDate) >= startDate
                        //                                            && EntityFunctions.TruncateTime(x.updateDate) <= endDate);


                        dashBoardModel.salesCount = entity.invoices.Where(searchPredicate).Count();

                        //customers count
                        searchPredicate = searchPredicate.And(x => x.agentId != null);
                        dashBoardModel.customersCount = entity.invoices.Where(searchPredicate).Select(x => x.agentId).Distinct().Count();
                        #endregion

                        var posSearchPredicat = PredicateBuilder.New<pos>();
                        posSearchPredicat = posSearchPredicat.And(x => x.isActive == 1);

                        if (branchId != 0)
                            posSearchPredicat = posSearchPredicat.And(x => x.branchId == branchId);

                        #region online users
                        dashBoardModel.onLineUsersCount = (from log in entity.usersLogs
                                        join p in entity.pos.Where(posSearchPredicat) on log.posId equals p.posId
                                        join u in entity.users on log.userId equals u.userId

                                        where (log.sOutDate == null && log.users.isOnline == 1)

                                        select new
                                        {
                                            log.userId,

                                        }).Distinct().Count();
                        #endregion

                        #region balance
                        try
                        {
                            dashBoardModel.balance = (decimal)entity.pos.Where(posSearchPredicat).Select(x => x.balance).Sum();
                        }
                        catch
                        {
                            dashBoardModel.balance = 0;

                        }
                        #endregion
                        return TokenManager.GenerateToken(dashBoardModel);

                    }
                }
                catch
                {
                    return TokenManager.GenerateToken(new WebDashBoardModel());
                }
            }
        }

        [HttpPost]
        [Route("getAccuracy")]
        public string getAccuracy(string token)
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
                    var accuracy = entity.setValues.Where(x => x.setting.name == "accuracy").Select(x => x.value).FirstOrDefault();
                    return TokenManager.GenerateToken(accuracy);
                }
                
            }

        }
         [HttpPost]
        [Route("getCurrency")]
        public string getCurrency(string token)
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
                    var currency = entity.countriesCodes
                        .Where(x => x.isDefault == 1)
                        .Select(c => new
                        {
                            c.countryId,
                            c.code,
                            c.currency,
                            c.name,
                            c.isDefault,
                            c.currencyId,

                        }).FirstOrDefault();

                    if(currency != null)
                        return TokenManager.GenerateToken(currency.currency);
                    else
                        return TokenManager.GenerateToken("");

                }

            }

        }
        [HttpPost]
        [Route("getUserLanguage")]
        public string getUserLanguage(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);

            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                #region params
                int userId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                }
                #endregion
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var lang =(from sv in entity.setValues.Where(x => x.setting.name == "language")
                                   join su in entity.userSetValues.Where(x => x.userId == userId) on sv.valId equals su.valId
                        select new setValuesModel() {
                            value = sv.value,
                            name = sv.setting.name,
                        }).FirstOrDefault();

                    if (lang != null)
                        return TokenManager.GenerateToken(lang.value);
                    else
                        return TokenManager.GenerateToken("en");

                }

            }

        }
        [HttpPost]
        [Route("GetCustomerPayments")]
        public string GetCustomerPayments(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                #region params
                int agentId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "agentId")
                    {
                        agentId = int.Parse(c.Value);
                    }
                }
                #endregion
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {

                        List<CashTransferModel> cachlist = (from C in entity.cashTransfer.Where(x => x.agentId == agentId)
                                                            join b in entity.banks on C.bankId equals b.bankId into jb
                                                            join a in entity.agents on C.agentId equals a.agentId into ja
                                                            join p in entity.pos on C.posId equals p.posId into jp
                                                            join pc in entity.pos on C.posIdCreator equals pc.posId into jpcr
                                                            join u in entity.users on C.userId equals u.userId into ju
                                                            join uc in entity.users on C.updateUserId equals uc.userId into juc
                                                            join cr in entity.cards on C.cardId equals cr.cardId into jcr
                                                            join bo in entity.bondes on C.bondId equals bo.bondId into jbo
                                                            from jbb in jb.DefaultIfEmpty()
                                                            from jaa in ja.DefaultIfEmpty()
                                                            from jpp in jp.DefaultIfEmpty()
                                                            from juu in ju.DefaultIfEmpty()
                                                            from jpcc in jpcr.DefaultIfEmpty()
                                                            from jucc in juc.DefaultIfEmpty()
                                                            from jcrd in jcr.DefaultIfEmpty()
                                                            from jbbo in jbo.DefaultIfEmpty()
                                                            where (C.transType == "p" && C.processType != "balance" && C.processType != "inv")
                                                            //&&  (brIds.Contains(jpp.branches.branchId) || brIds.Contains(jpcc.branches.branchId))

                                                            //( C.transType == "p" && C.side==Side)
                                                            select new CashTransferModel()
                                                            {
                                                                //*cashTransId = C.cashTransId,
                                                                transType = C.transType,
                                                                //*posId = C.posId,
                                                                userId = C.userId,
                                                                agentId = C.agentId,
                                                                //*invId = C.invId,
                                                                transNum = C.transNum,
                                                                //*createDate = C.createDate,
                                                                updateDate = C.updateDate,
                                                                cash = C.cash,
                                                                //*updateUserId = C.updateUserId,
                                                                //*createUserId = C.createUserId,
                                                                //*notes = C.notes,
                                                                //*posIdCreator = C.posIdCreator,
                                                                isConfirm = C.isConfirm,
                                                                //*cashTransIdSource = C.cashTransIdSource,
                                                                side = C.side,

                                                                //*docName = C.docName,
                                                                //*docNum = C.docNum,
                                                                //*docImage = C.docImage,
                                                                bankId = C.bankId,
                                                                bankName = jbb.name,
                                                                agentName = jaa.name,

                                                                userAcc = juu.username,// side =u

                                                                processType = C.processType,

                                                                usersLName = juu.lastname,// side =u

                                                                updateUserAcc = jucc.username,
                                                                //*createUserJob = jucc.job,
                                                                cardName = jcrd.name,
                                                                agentCompany = jaa.company,
                                                                shippingCompanyId = C.shippingCompanyId,
                                                                shippingCompanyName = C.shippingCompanies.name,

                                                            }).ToList();

                                 return TokenManager.GenerateToken(cachlist);

                    }

                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }

            }

        }

        [HttpPost]
        [Route("getCustomerDeliverdOrders")]
        public string getCustomerDeliverdOrders(string token)
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
                    if (c.Type == "agentId")
                    {
                        agentId = int.Parse(c.Value);
                    }
                }
                List<string> statusL = new List<string>();
                //statusL.Add("tr");
                statusL.Add("rc");
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invoicesList = (from b in entity.invoices.Where(x => x.invType == "s" && x.agentId == agentId && x.shippingCompanyId != null && x.isActive == true)
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
                                            shipUserName = y.name+ " "+y.lastname,
                                            shipCompanyName = b.shippingCompanies.name,
                                            status = s.status,
                                            userId = b.userId,
                                            manualDiscountType = b.manualDiscountType,
                                            manualDiscountValue = b.manualDiscountValue,
                                            shippingCost = b.shippingCost,
                                            realShippingCost = b.realShippingCost,
                                            payStatus = b.deserved == 0 ? "payed" : (b.deserved == b.totalNet ? "unpayed" : "partpayed"),
                                            branchCreatorName = entity.branches.Where(X => X.branchId == b.branchCreatorId).FirstOrDefault().name,

                                        })
                    .ToList();
                    
                    return TokenManager.GenerateToken(invoicesList);
                }
            }
        }

        [HttpPost]
        [Route("GetStockInfo")]
        public string GetStockInfo(string token)
        {
            //int branchId string token
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

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var searchPredicate = PredicateBuilder.New<sections>();
                        searchPredicate = searchPredicate.And(x => true);
                        if (branchId != 0)
                            searchPredicate = searchPredicate.And(x => x.branchId == branchId);

                        var itemsUnitsList = (from b in entity.itemsLocations
                                            where b.quantity > 0 && b.invoiceId == null
                                            join u in entity.itemsUnits on b.itemUnitId equals u.itemUnitId
                                            join i in entity.items on u.itemId equals i.itemId
                                            join l in entity.locations on b.locationId equals l.locationId
                                            join s in entity.sections.Where(searchPredicate) on l.sectionId equals s.sectionId

                                            select new ItemLocationModel
                                            {
                                                quantity = b.quantity,
                                                itemName = i.name,
                                                unitName = u.units.name,
                                            }).ToList();

                        var res = itemsUnitsList.GroupBy(x => new { x.itemName, x.unitName })
                                                .Select(x => new ItemLocationModel(){itemName = x.FirstOrDefault().itemName,
                                                                   unitName = x.FirstOrDefault().unitName,
                                                                    quantity = x.Sum(a => a.quantity)}).ToList();

                        int sequence = 1;
                        foreach(ItemLocationModel it in res)
                        {
                            it.sequence = sequence;
                            sequence++;
                        }
                        return TokenManager.GenerateToken(res);
                    }
                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
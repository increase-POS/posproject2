using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POS_Server.Classes;
namespace POS_Server.Controllers
{
    [RoutePrefix("api/dash")]
    public class dashController : ApiController
    {
        #region Counts
        // for Dashboard
        //  
        [HttpGet]
        [Route("Getdashsalpur")]
        public IHttpActionResult Getdashsalpur()
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

                                    join BC in entity.branches on I.branchCreatorId equals BC.branchId into JBC

                                    //pbw pb  sb
                                    from JBCC in JBC.DefaultIfEmpty()
                                    where (I.invType == "p" || I.invType == "pw" || I.invType == "s" || I.invType == "pbw" || I.invType == "pb" || I.invType == "sb")

                                    select new
                                    {
                                        I.invoiceId,
                                        // I.invNumber,
                                        //  I.agentId,
                                        //  I.posId,
                                        I.invType,
                                        //  I.total,
                                        //I.totalNet,


                                        //
                                        I.branchCreatorId,
                                        branchCreatorName = JBCC.name,

                                    }).ToList();


                    //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

                    var group2invlist = invListm.GroupBy(g => g.branchCreatorId).Select(g => new
                    {
                        invType = g.FirstOrDefault().invType,
                        branchCreatorId = g.FirstOrDefault().branchCreatorId,
                        branchCreatorName = g.FirstOrDefault().branchCreatorName,
                        purCount = g.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
                        saleCount = g.Where(i => i.invType == "s").Count(),
                        purBackCount = g.Where(i => (i.invType == "pbw" || i.invType == "pb")).Count(),
                        saleBackCount = g.Where(i => i.invType == "sb").Count(),
                    }).ToList();
                    /*
                    .GroupBy(s =>  s.branchCreatorId ).Select(s => new
                    {
                        invType = s.FirstOrDefault().invType,
                        branchCreatorId = s.FirstOrDefault().branchCreatorId,
                        branchCreatorName = s.FirstOrDefault().branchCreatorName,
                        purCount = s.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
                        
                        saleCount = s.Where(i => i.invType == "s").Count(),
                    }
                        ).ToList();
                        */

                    /*
                       var result = temp.GroupBy(s => new { s.updateUserId, s.cUserAccName }).Select(s => new
        {
            updateUserId = s.FirstOrDefault().updateUserId,
            cUserAccName = s.FirstOrDefault().cUserAccName,
            count = s.Count()
        });
                     * */
                    if (group2invlist == null)
                        return NotFound();
                    else
                        return Ok(group2invlist);
                }

            }

            //else
            return NotFound();
        }


        [HttpGet]
        [Route("GetAgentCount")]
        public IHttpActionResult GetAgentCount()
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
                    var invListm = (from A in entity.agents
                                    select new
                                    {
                                        //  A.agentId,                                     
                                        A.type,
                                    }).ToList();


                    //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

                    var grouplist = invListm.GroupBy(g => g.type).Select(g => new
                    {
                        type = g.FirstOrDefault().type,

                        vendorCount = g.Where(i => i.type == "v").Count(),
                        customerCount = g.Where(i => i.type == "c").Count(),
                        grp = 1,
                    }).ToList().GroupBy(g => g.grp).Select(c => new
                    {

                        vendorCount = c.Sum(d => d.vendorCount),
                        customerCount = c.Sum(d => d.customerCount),
                    }).ToList();

                    //g.FirstOrDefault().type=="v"

                    if (grouplist == null)
                        return NotFound();
                    else
                        return Ok(grouplist);
                }

            }

            //else
            return NotFound();
        }



        #endregion

        [HttpGet]
        [Route("Getuseronline")]
        public IHttpActionResult Getuseronline()
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

                    int allUsers = entity.users.ToList().Count();
                    /*
                    // get user count in every branch
                    var listUsersinbranch = entity.branchesUsers.Select(s => new
                    {
                        s.branchId,
                        s.userId
                    }).ToList();
                    
                    var listub = listUsersinbranch.GroupBy(g => g.branchId).Select(g => new
                    {
                        usersAll = g.Count(),
                        g.FirstOrDefault().branchId,

                    }).ToList();
                    */

                    var listPosinbranch = entity.pos.Select(s => new
                {
                    s.branchId,
                    s.posId,
                    s.isActive,
                }).ToList();
                // get Active Pos count in every branch
                var listposb = listPosinbranch.Where(x=>x.isActive==1).GroupBy(g => g.branchId).Select(g => new
                {
                    posAll = g.Count(),
                    g.FirstOrDefault().branchId,

                }).ToList();


                var invListm = (from log in entity.usersLogs

                                join p in entity.pos on log.posId equals p.posId


                                where (log.sOutDate == null && log.users.isOnline == 1)

                                select new
                                {
                                    log.userId,
                                    p.branchId,
                                    branchName = p.branches.name,

                                    //

                                }).ToList();


                //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

                var grouplist = invListm.GroupBy(g => new { g.branchId, g.userId }).Select(g => new
                {
                    g.FirstOrDefault().userId,
                    g.FirstOrDefault().branchId,
                    g.FirstOrDefault().branchName,

                    //saleCount = g.Where(i => i.invType == "s").Count(),
                    //purBackCount = g.Where(i => (i.invType == "pbw" || i.invType == "pb")).Count(),
                    //saleBackCount = g.Where(i => i.invType == "sb").Count(),
                }).ToList();

                List<UserOnlineCount> grop = grouplist.GroupBy(g => g.branchId).Select(g => new UserOnlineCount
                {
                    userOnlineCount = g.Count(),
                    allPos = listposb.Where(b => b.branchId == g.FirstOrDefault().branchId).FirstOrDefault().posAll,
                    offlineUsers = listposb.Where(b => b.branchId == g.FirstOrDefault().branchId).FirstOrDefault().posAll - g.Count(),//offline= all -online
                    branchId = (int)g.FirstOrDefault().branchId,
                    branchName = g.FirstOrDefault().branchName,
                }).ToList();

                /*
                .GroupBy(s =>  s.branchCreatorId ).Select(s => new
                {
                    invType = s.FirstOrDefault().invType,
                    branchCreatorId = s.FirstOrDefault().branchCreatorId,
                    branchCreatorName = s.FirstOrDefault().branchCreatorName,
                    purCount = s.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),

                    saleCount = s.Where(i => i.invType == "s").Count(),
                }
                    ).ToList();
                    */

                    /*
                       var result = temp.GroupBy(s => new { s.updateUserId, s.cUserAccName }).Select(s => new
        {
            updateUserId = s.FirstOrDefault().updateUserId,
            cUserAccName = s.FirstOrDefault().cUserAccName,
            count = s.Count()
        });
                     * */
                    if (grop == null)
                        return NotFound();
                    else
                        return Ok(grop);
                }

            }

            //else
            return NotFound();
        }


        [HttpGet]
        [Route("GetBrachonline")]
        public IHttpActionResult GetBrachonline()
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
                List<BranchOnlineCount> blist = new List<BranchOnlineCount>();

                using (incposdbEntities entity = new incposdbEntities())
                {


                    int allBranches = entity.branches.ToList().Count();
                    var invListm = (from log in entity.usersLogs
                                    join p in entity.pos on log.posId equals p.posId
                                    where (log.sOutDate == null && log.users.isOnline == 1)

                                    select new
                                    {
                                        log.userId,
                                        p.branchId,
                                        branchName = p.branches.name,

                                    }).ToList();


                    var grouplist = invListm.GroupBy(g => new { g.branchId, g.userId }).Select(g => new
                    {
                        g.FirstOrDefault().userId,
                        g.FirstOrDefault().branchId,
                        g.FirstOrDefault().branchName,

                    }).ToList();
                    List<UserOnlineCount> grop = grouplist.GroupBy(g => g.branchId).Select(g => new UserOnlineCount
                    {

                        branchId = (int)g.FirstOrDefault().branchId,
                        branchName = g.FirstOrDefault().branchName,
                    }).ToList();
                    BranchOnlineCount brow = new BranchOnlineCount();
                    brow.branchAll = allBranches;
                    brow.branchOnline = grop.Count();
                    brow.branchOffline = allBranches - grop.Count();


                    blist.Add(brow);



                    // return blist;
                    if (blist == null)
                        return NotFound();
                    else
                        return Ok(blist);
                }
            }
            //else
            return NotFound();
        }

        //عدد الفواتير في اليوم الحالي 
        [HttpGet]
        [Route("GetdashsalpurDay")]
        public IHttpActionResult GetdashsalpurDay()
        {
            Calculate calc = new Calculate();
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
                    var invListmtmp = (from I in entity.invoices

                                    join BC in entity.branches on I.branchCreatorId equals BC.branchId into JBC

                                    //pbw pb  sb
                                    from JBCC in JBC.DefaultIfEmpty()
                                    where (I.invType == "p" || I.invType == "pw" || I.invType == "s" || I.invType == "pbw" || I.invType == "pb" || I.invType == "sb")
                                 //   && I.updateDate==DateTime.Now())
                                    select new
                                    {
                                        I.invoiceId,
                                        // I.invNumber,
                                        //  I.agentId,
                                        //  I.posId,
                                        I.invType,
                                        //  I.total,
                                        //I.totalNet,


                                        //
                                        I.branchCreatorId,
                                        branchCreatorName = JBCC.name,
                                        I.updateDate,
                                    }).ToList();
                  var  invListm=invListmtmp.Where(X => DateTime.Compare(
                    (DateTime)calc.changeDateformat(X.updateDate, "yyyy-MM-dd")
                    , (DateTime)calc.changeDateformat(DateTime.Now, "yyyy-MM-dd")) == 0).ToList();

                    //                invListm.Where(X => DateTime.Compare(
                    //(DateTime)calc.changeDateformat(X.updateDate, "yyyy-MM-dd")
                    //, (DateTime)calc.changeDateformat(date, "yyyy-MM-dd")) == 0).ToList();

                    //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

                    var group2invlist = invListm.GroupBy(g => g.branchCreatorId).Select(g => new
                    {
                        invType = g.FirstOrDefault().invType,
                        branchCreatorId = g.FirstOrDefault().branchCreatorId,
                        branchCreatorName = g.FirstOrDefault().branchCreatorName,
                        purCount = g.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
                        saleCount = g.Where(i => i.invType == "s").Count(),
                        purBackCount = g.Where(i => (i.invType == "pbw" || i.invType == "pb")).Count(),
                        saleBackCount = g.Where(i => i.invType == "sb").Count(),
                    }).ToList();
                    /*
                    .GroupBy(s =>  s.branchCreatorId ).Select(s => new
                    {
                        invType = s.FirstOrDefault().invType,
                        branchCreatorId = s.FirstOrDefault().branchCreatorId,
                        branchCreatorName = s.FirstOrDefault().branchCreatorName,
                        purCount = s.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
                        
                        saleCount = s.Where(i => i.invType == "s").Count(),
                    }
                        ).ToList();
                        */

                    /*
                       var result = temp.GroupBy(s => new { s.updateUserId, s.cUserAccName }).Select(s => new
        {
            updateUserId = s.FirstOrDefault().updateUserId,
            cUserAccName = s.FirstOrDefault().cUserAccName,
            count = s.Count()
        });
                     * */
                    if (group2invlist == null)
                        return NotFound();
                    else
                        return Ok(group2invlist);
                }

            }

            //else
            return NotFound();
        }

        //
        // فواتير المبيعات مع العناصر
        [HttpGet]
        [Route("Getbestseller")]
        public IHttpActionResult Getbestseller()
        {
            Calculate calc = new Calculate();
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
                    var invListmtmp = (from IT in entity.itemsTransfer
                                    from I in entity.invoices.Where(I => I.invoiceId == IT.invoiceId)

                                    from IU in entity.itemsUnits.Where(IU => IU.itemUnitId == IT.itemUnitId)
                                   // join ITCUSER in entity.users on IT.createUserId equals ITCUSER.userId
                                 //   join ITUPUSER in entity.users on IT.updateUserId equals ITUPUSER.userId
                                    join ITEM in entity.items on IU.itemId equals ITEM.itemId
                                    join UNIT in entity.units on IU.unitId equals UNIT.unitId
                                    //    join B in entity.branches on I.branchId equals B.branchId into JB
                                    join BC in entity.branches on I.branchCreatorId equals BC.branchId into JBC
                                  //  join A in entity.agents on I.agentId equals A.agentId into JA
                                  //  join U in entity.users on I.createUserId equals U.userId into JU
                                   // join UPUSR in entity.users on I.updateUserId equals UPUSR.userId into JUPUSR
                                  //  join IM in entity.invoices on I.invoiceMainId equals IM.invoiceId into JIM
                                 //   join P in entity.pos on I.posId equals P.posId into JP

                                    // from JBB in JB
                                    //from JPP in JP.DefaultIfEmpty()
                                  //  from JUU in JU.DefaultIfEmpty()
                                  //  from JUPUS in JUPUSR.DefaultIfEmpty()
                                   // from JIMM in JIM.DefaultIfEmpty()
                                  //  from JAA in JA.DefaultIfEmpty()
                                    from JBCC in JBC.DefaultIfEmpty()
                                    where (I.invType == "s" )

                                    select new
                                    {

                                        itemName = ITEM.name,
                                        unitName = UNIT.name,
                                        itemsTransId = IT.itemsTransId,
                                        itemUnitId = IT.itemUnitId,

                                       itemId = IU.itemId,
                                        unitId = IU.unitId,
                                        quantity = IT.quantity,
                                        price = IT.price,
                                        I.invoiceId,
                                        I.invType,
                                        I.updateDate,
                                        I.branchCreatorId,
                                        branchCreatorName = JBCC.name,
                                       Totalrow = (IT.price * IT.quantity),

                                        //   ITcreateDate = IT.createDate,
                                        ITupdateDate = IT.updateDate,
                                        // ITcreateUserId = IT.createUserId,
                                      //  ITupdateUserId = IT.updateUserId,

                                        //  ITbarcode = IU.barcode,



                                        // I.posId,

                                        //  I.total,
                                        //  I.totalNet,
                                        // I.paid,
                                        // I.deserved,
                                        // I.deservedDate,
                                        // I.invDate,
                                        //  I.invoiceMainId,
                                        // I.invCase,
                                        // I.invTime,
                                        //  I.notes,
                                        // I.vendorInvNum,
                                        // I.vendorInvDate,
                                        //  I.createUserId,

                                        // I.updateUserId,
                                        // I.branchId,
                                        //  discountValue = (I.discountType == "1" || I.discountType == null) ? I.discountValue : (I.discountType == "2" ? (I.discountValue / 100) : 0),
                                        //  I.discountType,
                                        //  I.tax,
                                        //  I.name,
                                        //   I.isApproved,

                                        //

                                        //
                                        //  branchName = JBB.name,

                                        //  branchType = JBB.type,


                                        //username

                                        //  I.invoiceId,
                                        //    JBB.name
                                    }).ToList();

                    var invListm2 = invListmtmp.Where(X => DateTime.Compare(
                   (DateTime)calc.changeDateformat(X.updateDate, "yyyy-MM")
                   , (DateTime)calc.changeDateformat(DateTime.Now, "yyyy-MM")) == 0).ToList();

                    var invListm = invListm2.GroupBy(g => new { g.branchCreatorId, g.itemUnitId })
                        .Select(g => new {
                            itemName =g.FirstOrDefault().itemName,
                            unitName = g.FirstOrDefault().unitName,
                           // itemsTransId = IT.itemsTransId,
                            itemUnitId = g.FirstOrDefault().itemUnitId,

                            itemId = g.FirstOrDefault().itemId,
                            unitId = g.FirstOrDefault().unitId,
                            quantity = g.Sum(s=>s.quantity),

                            price = g.FirstOrDefault().price,
                            //  I.invoiceId,
                            //  I.invType,
                            //    I.updateDate,
                            branchCreatorId=   g.FirstOrDefault().branchCreatorId,
                            branchCreatorName = g.FirstOrDefault().branchCreatorName,
                            subTotal = g.Sum(s=>s.Totalrow),

                        }).OrderByDescending(o=>o.quantity).ToList().Take(10);

                    //.Take(3)

                    if (invListm == null)
                        return NotFound();
                    else
                        return Ok(invListm);
                }

            }

            //else
            return NotFound();
        }

        // كمية العناصر في الفروع
        // عرض الاصناف واماكن تخزينها
        [HttpGet]
        [Route("GetIUStorage")]
        public IHttpActionResult GetIUStorage(string iuList)
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
            iuList = iuList.Replace("\\", string.Empty);
            iuList = iuList.Trim('"');
            List<itemsUnits> newitofObj = JsonConvert.DeserializeObject<List<itemsUnits>>(iuList, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

            if (valid) // APIKey is valid
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    // storageCost storageCostsr = new storageCost();

                    var invListmtemp = (from L in entity.locations
                                        //  from I in entity.invoices.Where(I => I.invoiceId == IT.invoiceId)


                                    join IUL in entity.itemsLocations on L.locationId equals IUL.locationId
                                    join IU in entity.itemsUnits on IUL.itemUnitId equals IU.itemUnitId

                                    //  join ITCUSER in entity.users on IT.createUserId equals ITCUSER.userId
                                    //join ITUPUSER in entity.users on IT.updateUserId equals ITUPUSER.userId
                                    join ITEM in entity.items on IU.itemId equals ITEM.itemId
                                    join UNIT in entity.units on IU.unitId equals UNIT.unitId
                                 //   join S in entity.sections on L.sectionId equals S.sectionId into JS
                                    join B in entity.branches on L.branchId equals B.branchId into JB

                                   // join UPUSR in entity.users on IUL.updateUserId equals UPUSR.userId into JUPUS
                                  //  join U in entity.users on IUL.createUserId equals U.userId into JU

                                    from JBB in JB
                                  //  from JSS in JS.DefaultIfEmpty()
                                   // from JUU in JU.DefaultIfEmpty()
                                   // from JUPUSS in JUPUS.DefaultIfEmpty()
                                    select new
                                    {
                                        // item unit
                                        itemName = ITEM.name,
                                        //ITEM.min,
                                       // ITEM.max,
                                       // ITEM.minUnitId,
                                       // ITEM.maxUnitId,
                                       // minUnitName = entity.units.Where(x => x.unitId == ITEM.minUnitId).FirstOrDefault().name,
                                      //  maxUnitName = entity.units.Where(x => x.unitId == ITEM.maxUnitId).FirstOrDefault().name,
                                        unitName = UNIT.name,
                                        IU.itemUnitId,

                                        IU.itemId,
                                        IU.unitId,
                                       // IU.barcode,
                                        //item location
                                
                                        //
                                        branchName = JBB.name,

                                        branchType = JBB.type,
                                        //itemslocations

                                        IUL.itemsLocId,
                                        IUL.locationId,
                                        IUL.quantity,

                                      //  IUL.startDate,
                                       // IUL.endDate,

                                      //  IULnote = IUL.note,
                                        IU.storageCostId,

                                      //  storageCostName = IU.storageCostId != null ? entity.storageCost.Where(X => X.storageCostId == IU.storageCostId).FirstOrDefault().name : "",
                                      //  storageCostValue = IU.storageCostId != null ?
                                     // entity.storageCost.Where(X => X.storageCostId == IU.storageCostId).FirstOrDefault().cost
                                     // : 0,

                                      
                                        // Location
                                       // L.x,
                                     //   L.y,
                                     //   L.z,

                                        LocisActive = L.isActive,
                                        L.sectionId,
                                      //  Locnote = L.note,
                                        L.branchId,
                                        LocisFreeZone = L.isFreeZone,


                                        // section

                                    //    Secname = JSS.name,
                                    //    SecisActive = JSS.isActive,
                                       // Secnote = JSS.note,
                                     //   SecisFreeZone = JSS.isFreeZone,

                                    }).ToList();

                    var invListm = invListmtemp.GroupBy(g => new { g.branchId, g.itemUnitId })
                        .Select(s => new { }).ToList();



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
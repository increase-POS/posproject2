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
using POS_Server.Models.VM;
using System.Security.Claims;
using System.Web;
using Newtonsoft.Json.Converters;


using System.Web;


namespace POS_Server.Controllers
{
    [RoutePrefix("api/dash")]
    public class dashController : ApiController
    {

        // for Dashboard
        //  
        [HttpPost]
        [Route("Getdashsalpur")]
        public string Getdashsalpur(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)

            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int mainBranchId = 0;
                int userId = 0;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "mainBranchId")
                    {
                        mainBranchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }

                }
                try
                {
                    StatisticsController sts = new StatisticsController();
                    List<int> brIds = sts.AllowedBranchsId(mainBranchId, userId);
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var invListm = (from I in entity.invoices

                                        join BC in entity.branches on I.branchCreatorId equals BC.branchId into JBC

                                        //pbw pb  sb
                                        from JBCC in JBC.DefaultIfEmpty()
                                        where (brIds.Contains(JBCC.branchId) && (I.invType == "p" || I.invType == "pw" || I.invType == "s" || I.invType == "pbw" || I.invType == "pb" || I.invType == "sb"))

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

                        var list = invListm.GroupBy(g => g.branchCreatorId).Select(g => new
                        {
                            invType = g.FirstOrDefault().invType,
                            branchCreatorId = g.FirstOrDefault().branchCreatorId,
                            branchCreatorName = g.FirstOrDefault().branchCreatorName,
                            purCount = g.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
                            saleCount = g.Where(i => i.invType == "s" ).Count(),
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
                        return TokenManager.GenerateToken(list);

                    }

                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }
            }
        }
        [HttpPost]
        [Route("GetAgentCount")]
        public string GetAgentCount(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)




            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                //int mainBranchId = 0;
                //int userId = 0;

                //IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                //foreach (Claim c in claims)
                //{
                //    if (c.Type == "mainBranchId")
                //    {
                //        mainBranchId = int.Parse(c.Value);
                //    }
                //    else if (c.Type == "userId")
                //    {
                //        userId = int.Parse(c.Value);
                //    }

                //}
                try
                {
                    //StatisticsController sts = new StatisticsController();
                    //List<int> brIds = sts.AllowedBranchsId(mainBranchId, userId);
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var invListm = (from A in entity.agents
                                        select new
                                        {
                                            //  A.agentId,                                     
                                            A.type,
                                        }).ToList();


                        //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

                        var list = invListm.GroupBy(g => g.type).Select(g => new
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

                        return TokenManager.GenerateToken(list);

                    }
                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }



            }



        }


        //عدد المستخدمين المتصلين والغير متصلين  حاليا في كل فرع 
        [HttpPost]
        [Route("Getuseronline")]
        public string Getuseronline(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)




            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int mainBranchId = 0;
                int userId = 0;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "mainBranchId")
                    {
                        mainBranchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }

                }
                try
                {
                    StatisticsController sts = new StatisticsController();
                    List<int> brIds = sts.AllowedBranchsId(mainBranchId, userId);
                    using (incposdbEntities entity = new incposdbEntities())
                    {

                        //  int allUsers = entity.users.ToList().Count();
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
                            s.branches.name,
                        }).ToList();
                        // get Active Pos count in every branch
                        var listposb = listPosinbranch.Where(x => x.isActive == 1).GroupBy(g => g.branchId).Select(g => new
                        {
                            posAll = g.Count(),
                            g.FirstOrDefault().branchId,
                            g.FirstOrDefault().name,

                        }).ToList();
                        List<UserOnlineCount> list = new List<UserOnlineCount>();

                        foreach (var row in listposb)
                        {
                            UserOnlineCount newrow = new UserOnlineCount();
                            newrow.allPos = row.posAll;
                            newrow.branchId = (int)row.branchId;
                            newrow.branchName = row.name;
                            newrow.offlineUsers = row.posAll;
                            newrow.userOnlineCount = 0;

                            list.Add(newrow);

                        }

                        var invListm = (from log in entity.usersLogs
                                        join p in entity.pos on log.posId equals p.posId
                                        join u in entity.users on log.userId equals u.userId

                                        where (log.sOutDate == null && log.users.isOnline == 1)

                                        select new
                                        {
                                            log.userId,
                                            p.branchId,
                                            branchName = p.branches.name,
                                            branchisActive = p.branches.isActive,

                                            log.posId,
                                            posName = p.name,
                                            posisActive = p.isActive,
                                            //
                                            //usernameAccount = u.username,
                                            //userName = u.name,
                                            //lastname = u.lastname,

                                            //job = u.job,
                                            //phone = u.phone,
                                            //mobile = u.mobile,
                                            //email = u.email,
                                            //address = u.address,
                                            //userisActive = u.isActive,
                                            //isOnline = u.isOnline,

                                            //image = u.image,

                                            //

                                        }).ToList();


                        //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

                        List<userOnlineInfo> grouplist = invListm.GroupBy(g => new { g.branchId, g.userId }).Select(g => new userOnlineInfo
                        {


                            branchId = g.LastOrDefault().branchId,
                            branchName = g.LastOrDefault().branchName,
                            branchisActive = g.LastOrDefault().branchisActive,

                            posId = g.LastOrDefault().posId,
                            posName = g.LastOrDefault().posName,
                            posisActive = g.LastOrDefault().posisActive,

                            userId = g.LastOrDefault().userId,

                            //usernameAccount = g.LastOrDefault().usernameAccount,
                            //userName = g.LastOrDefault().userName,
                            //lastname = g.LastOrDefault().lastname,
                            //job = g.LastOrDefault().job,
                            //phone = g.LastOrDefault().phone,
                            //mobile = g.LastOrDefault().mobile,
                            //email = g.LastOrDefault().email,
                            //address = g.LastOrDefault().address,
                            //userisActive = g.LastOrDefault().userisActive,
                            //isOnline = g.LastOrDefault().isOnline,
                            //image = g.LastOrDefault().image,



                        }).ToList();

                        List<UserOnlineCount> grop = grouplist.GroupBy(g => g.branchId).Select(g => new UserOnlineCount
                        {
                            userOnlineCount = g.Count(),
                            allPos = listposb.Where(b => b.branchId == g.FirstOrDefault().branchId).FirstOrDefault().posAll,
                            offlineUsers = listposb.Where(b => b.branchId == g.FirstOrDefault().branchId).FirstOrDefault().posAll - g.Count(),//offline= all -online
                            branchId = (int)g.FirstOrDefault().branchId,
                            branchName = g.FirstOrDefault().branchName,
                            //  userOnlinelist = grouplist.Where(b => b.branchId == g.FirstOrDefault().branchId).ToList(),
                            //   userOnlinelist = grouplist.ToList(),
                        }).ToList();
                        list = list.Where(X => brIds.Contains(X.branchId)).ToList();
                        foreach (UserOnlineCount finalrow in list)
                        {
                            UserOnlineCount temp = new UserOnlineCount();
                            temp = grop.Where(x => x.branchId == finalrow.branchId).FirstOrDefault();
                            if (temp != null)
                            {
                                finalrow.offlineUsers = temp.offlineUsers;
                                finalrow.userOnlineCount = temp.userOnlineCount;

                            }
                        }



                        return TokenManager.GenerateToken(list);

                    }


                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }




            }

        }


        [HttpPost]
        [Route("GetuseronlineInfo")]
        public string GetuseronlineInfo(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)




            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int mainBranchId = 0;
                int userId = 0;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "mainBranchId")
                    {
                        mainBranchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }

                }
                try
                {
                    StatisticsController sts = new StatisticsController();
                    List<int> brIds = sts.AllowedBranchsId(mainBranchId, userId);
                    using (incposdbEntities entity = new incposdbEntities())
                    {


                        var invListm = (from log in entity.usersLogs
                                        join p in entity.pos on log.posId equals p.posId
                                        join u in entity.users on log.userId equals u.userId

                                        where (brIds.Contains((int)p.branchId) && (log.sOutDate == null && log.users.isOnline == 1))

                                        select new
                                        {
                                            log.userId,
                                            p.branchId,
                                            branchName = p.branches.name,
                                            branchisActive = p.branches.isActive,

                                            log.posId,
                                            posName = p.name,
                                            posisActive = p.isActive,
                                            //
                                            usernameAccount = u.username,
                                            userName = u.name,
                                            lastname = u.lastname,

                                            job = u.job,
                                            phone = u.phone,
                                            mobile = u.mobile,
                                            email = u.email,
                                            address = u.address,
                                            userisActive = u.isActive,
                                            isOnline = u.isOnline,

                                            image = u.image,

                                            //

                                        }).ToList();

                        List<userOnlineInfo> list = invListm.GroupBy(g => new { g.branchId, g.userId }).Select(g => new userOnlineInfo
                        {

                            branchId = g.FirstOrDefault().branchId,
                            branchName = g.LastOrDefault().branchName,
                            branchisActive = g.LastOrDefault().branchisActive,

                            posId = g.LastOrDefault().posId,
                            posName = g.LastOrDefault().posName,
                            posisActive = g.LastOrDefault().posisActive,

                            userId = g.LastOrDefault().userId,
                            usernameAccount = g.LastOrDefault().usernameAccount,
                            userName = g.LastOrDefault().userName,
                            lastname = g.LastOrDefault().lastname,
                            job = g.LastOrDefault().job,
                            phone = g.LastOrDefault().phone,
                            mobile = g.LastOrDefault().mobile,
                            email = g.LastOrDefault().email,
                            address = g.LastOrDefault().address,
                            userisActive = g.LastOrDefault().userisActive,
                            isOnline = g.LastOrDefault().isOnline,
                            image = g.LastOrDefault().image,
                        }).ToList();

                        return TokenManager.GenerateToken(list);

                    }

                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }



            }


        }


        [HttpPost]
        [Route("GetBrachonline")]
        public string GetBrachonline(string token)
        {

            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)




            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int mainBranchId = 0;
                int userId = 0;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "mainBranchId")
                    {
                        mainBranchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }

                }
                try
                {
                    List<BranchOnlineCount> list = new List<BranchOnlineCount>();
                    StatisticsController sts = new StatisticsController();
                    List<int> brIds = sts.AllowedBranchsId(mainBranchId, userId);
                    using (incposdbEntities entity = new incposdbEntities())
                    {


                        // int allBranches = entity.branches.ToList().Count();
                        var allBranchesList = entity.branches.ToList();
                        int allBranches = allBranchesList
                            .Select(b => new
                            {
                                b.branchId,
                                b.isActive,
                            }).Where(b => (b.branchId != 1 && b.isActive == 1)).ToList().Count();
                        var invListm = (from log in entity.usersLogs
                                        join p in entity.pos on log.posId equals p.posId
                                        where (brIds.Contains((int)p.branchId) && (log.sOutDate == null && log.users.isOnline == 1))

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
                        //brow.branchOffline = allBranches - grop.Count();
                        brow.branchOffline = brIds.Count() - grop.Count();
                        list.Add(brow);

                        return TokenManager.GenerateToken(list);

                    }

                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }


            }


        }

        //عدد الفواتير في اليوم الحالي 
        [HttpPost]
        [Route("GetdashsalpurDay")]
        public string GetdashsalpurDay(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)

            int mainBranchId = 0;
            int userId = 0;



            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "mainBranchId")
                    {
                        mainBranchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }

                }

                Calculate calc = new Calculate();
                try
                {
                    StatisticsController sts = new StatisticsController();
                    List<int> brIds = sts.AllowedBranchsId(mainBranchId, userId);
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var invListmtmp = (from I in entity.invoices

                                           join BC in entity.branches on I.branchCreatorId equals BC.branchId into JBC

                                           //pbw pb  sb
                                           from JBCC in JBC.DefaultIfEmpty()
                                           where (brIds.Contains(JBCC.branchId) && (I.invType == "p" || I.invType == "pw" || I.invType == "s" || I.invType == "pbw" || I.invType == "pb" || I.invType == "sb"))
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
                                               I.invDate,
                                           }).ToList();
                        var invListm = invListmtmp.Where(X => DateTime.Compare(
                           (DateTime)calc.changeDateformat(X.invDate, "yyyy-MM-dd")
                           , (DateTime)calc.changeDateformat(DateTime.Now, "yyyy-MM-dd")) == 0).ToList();


                        var list = invListm.GroupBy(g => g.branchCreatorId).Select(g => new
                        {
                            invType = g.FirstOrDefault().invType,
                            branchCreatorId = g.FirstOrDefault().branchCreatorId,
                            branchCreatorName = g.FirstOrDefault().branchCreatorName,
                            purCount = g.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
                            saleCount = g.Where(i => i.invType == "s").Count(),
                            purBackCount = g.Where(i => (i.invType == "pbw" || i.invType == "pb")).Count(),
                            saleBackCount = g.Where(i => i.invType == "sb").Count(),
                        }).ToList();


                        return TokenManager.GenerateToken(list);

                    }


                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }



            }


        }

        //
        // فواتير المبيعات مع العناصر
        [HttpPost]
        [Route("Getbestseller")]
        public string Getbestseller(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)




            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int mainBranchId = 0;
                int userId = 0;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "mainBranchId")
                    {
                        mainBranchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }

                }
                Calculate calc = new Calculate();
                StatisticsController sts = new StatisticsController();
                List<int> brIds = sts.AllowedBranchsId(mainBranchId, userId);
                try
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

                                           from JBCC in JBC.DefaultIfEmpty()
                                           where (brIds.Contains(JBCC.branchId) && (I.invType == "s"  ))

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
                                               I.invDate,

                                           }).ToList();

                        var invListm2 = invListmtmp.Where(X => DateTime.Compare(
                       (DateTime)calc.changeDateformat(X.invDate, "yyyy-MM")
                       , (DateTime)calc.changeDateformat(DateTime.Now, "yyyy-MM")) == 0).ToList();

                        var list = invListm2.GroupBy(g => new { g.branchCreatorId, g.itemUnitId })
                            .Select(g => new
                            {
                                itemName = g.FirstOrDefault().itemName,
                                unitName = g.FirstOrDefault().unitName,
                                // itemsTransId = IT.itemsTransId,
                                itemUnitId = g.FirstOrDefault().itemUnitId,

                                itemId = g.FirstOrDefault().itemId,
                                unitId = g.FirstOrDefault().unitId,
                                quantity = g.Sum(s => s.quantity),

                                price = g.FirstOrDefault().price,
                                //  I.invoiceId,
                                //  I.invType,
                                //    I.updateDate,
                                branchCreatorId = g.FirstOrDefault().branchCreatorId,
                                branchCreatorName = g.FirstOrDefault().branchCreatorName,
                                subTotal = g.Sum(s => s.Totalrow),

                            }).OrderByDescending(o => o.quantity).ToList().Take(10);

                        //.Take(3)



                        return TokenManager.GenerateToken(list);

                    }


                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }



            }



        }

        // كمية العناصر في الفروع

        //  [HttpPost]
        [HttpPost]
        [Route("GetIUStorage")]
        public string GetIUStorage(string token)
        {
            // public ResponseVM GetPurinv(string token)string IUList

            token = TokenManager.readToken(HttpContext.Current.Request);

            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string IUList = "";
                int mainBranchId = 0;
                int userId = 0;
                List<itemsUnits> newiuObj = new List<itemsUnits>();

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "IUList")
                    {
                        IUList = c.Value.Replace("\\", string.Empty);
                        IUList = IUList.Trim('"');
                        newiuObj = JsonConvert.DeserializeObject<List<itemsUnits>>(IUList, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }

                    else if (c.Type == "mainBranchId")
                    {
                        mainBranchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }




                }

                // DateTime cmpdate = DateTime.Now.AddDays(newdays);
                try
                {
                    StatisticsController sts = new StatisticsController();
                    List<int> brIds = sts.AllowedBranchsId(mainBranchId, userId);
                    List<int> iuIds = new List<int>();
                    List<IUStorage> list = new List<IUStorage>();
                    List<branches> brlist = new List<branches>();
                    using (incposdbEntities entity1 = new incposdbEntities())
                    {
                        // get branches
                        brlist = entity1.branches.ToList();
                        brlist = brlist.Where(x => (x.branchId != 1 && x.isActive == 1)).Select(b => new branches
                        {
                            branchId = b.branchId,
                            name = b.name,
                            isActive = b.isActive,
                        }).ToList();
                        // prepare new list with all branches and all iu.

                        foreach (itemsUnits row in newiuObj)
                        {

                            foreach (branches branchRow in brlist)
                            {
                                IUStorage newrow = new IUStorage();
                                newrow.itemUnitId = row.itemUnitId;
                                newrow.quantity = 0;
                                newrow.branchId = branchRow.branchId;
                                newrow.branchName = branchRow.name;
                                newrow.itemId = entity1.itemsUnits.Find(row.itemUnitId).itemId;
                                newrow.unitId = entity1.itemsUnits.Find(row.itemUnitId).unitId; ;
                                newrow.itemName = entity1.itemsUnits.Find(row.itemUnitId).items.name;
                                newrow.unitName = entity1.itemsUnits.Find(row.itemUnitId).units.name;

                                list.Add(newrow);


                            }

                            //newrow. = 0;
                            iuIds.Add(row.itemUnitId);

                        }

                    }



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
                                            where (brIds.Contains(JBB.branchId) && iuIds.Contains(IU.itemUnitId))
                                            //  from JSS in JS.DefaultIfEmpty()
                                            // from JUU in JU.DefaultIfEmpty()
                                            // from JUPUSS in JUPUS.DefaultIfEmpty()
                                            select new
                                            {
                                                // item unit
                                                itemName = ITEM.name,
                                                unitName = UNIT.name,
                                                IU.itemUnitId,

                                                IU.itemId,
                                                IU.unitId,
                                                branchName = JBB.name,

                                                branchType = JBB.type,
                                                IUL.itemsLocId,
                                                IUL.locationId,
                                                IUL.quantity,
                                                L.branchId,



                                            }).ToList();

                        List<IUStorage> invListm = invListmtemp.GroupBy(g => new { g.branchId, g.itemUnitId })
                              .Select(s => new IUStorage
                              {
                                  itemName = s.FirstOrDefault().itemName,
                                  unitName = s.FirstOrDefault().unitName,
                                  itemUnitId = s.FirstOrDefault().itemUnitId,

                                  itemId = s.FirstOrDefault().itemId,
                                  unitId = s.FirstOrDefault().unitId,
                                  branchName = s.FirstOrDefault().branchName,
                                  branchId = s.FirstOrDefault().branchId,
                                  quantity = s.Sum(q => q.quantity),

                              }).OrderByDescending(x => x.quantity).ToList();
                        // merge two list
                        foreach (IUStorage finalrow in list)
                        {
                            IUStorage temp = new IUStorage();
                            temp = invListm.Where(x => (x.branchId == finalrow.branchId && x.itemUnitId == finalrow.itemUnitId)).FirstOrDefault();
                            if (temp != null)
                            {
                                finalrow.quantity = temp.quantity;
                            }

                        }

                        return TokenManager.GenerateToken(list.OrderByDescending(x => x.quantity));
                        //  return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(list.OrderByDescending(x => x.quantity)) };


                    }


                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }

            }



        }

        // مجموع مبالغ المشتريات والمبيعات اليومي خلال الشهر الحالي لكل فرع
        [HttpPost]
        [Route("GetTotalPurSale")]
        public string GetTotalPurSale(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)




            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {

                Calculate calc = new Calculate();
                int mainBranchId = 0;
                int userId = 0;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "mainBranchId")
                    {
                        mainBranchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }

                }
                try
                {
                    int year;
                    int month;
                    int days;
                    //StatisticsController sts = new StatisticsController();
                    //List<int> brIds = sts.AllowedBranchsId(mainBranchId, userId);
                    List<branches> brlist = new List<branches>();
                    List<TotalPurSale> totalinMonth = new List<TotalPurSale>();
                    List<TotalPurSale> totalinday = new List<TotalPurSale>();
                    List<TotalPurSale> list = new List<TotalPurSale>();
                    TotalPurSale totalAllBranchRow = new TotalPurSale();
                    TotalPurSale totalRowtemp = new TotalPurSale();
                    DateTime currentdate = DateTime.Now;
                    using (incposdbEntities entity = new incposdbEntities())
                    {

                        brlist = entity.branches.ToList();
                        brlist = brlist.Where(x => (x.branchId != 1 && x.isActive == 1)).Select(b => new branches
                        {
                            branchId = b.branchId,
                            name = b.name,
                            isActive = b.isActive,
                        }).ToList();

                    }

                    year = currentdate.Year;
                    month = currentdate.Month;
                    days = calc.getdays(year, month);
                    for (int i = 1; i <= days; i++)
                    {
                        DateTime daydate = new DateTime(year, month, i);
                        totalinday = new List<TotalPurSale>();

                        totalinday = GetTotalPurSaleday(daydate, i, mainBranchId, userId);
                        totalinMonth.AddRange(totalinday);
                    }

                    for (int i = 1; i <= days; i++)
                    {
                        foreach (branches row in brlist)
                        {
                            totalAllBranchRow = new TotalPurSale();
                            totalAllBranchRow.branchCreatorId = row.branchId;
                            totalAllBranchRow.branchCreatorName = row.name;
                            totalAllBranchRow.day = i;
                            totalAllBranchRow.totalPur = 0;
                            totalAllBranchRow.totalSale = 0;
                            totalAllBranchRow.countPur = 0;
                            totalAllBranchRow.countSale = 0;
                            list.Add(totalAllBranchRow);

                        }


                    }

                    foreach (TotalPurSale rowinv in list)
                    {
                        totalRowtemp = new TotalPurSale();
                        totalRowtemp = totalinMonth.Where(b => (b.day == rowinv.day && b.branchCreatorId == rowinv.branchCreatorId)).FirstOrDefault();
                        if (totalRowtemp != null)
                        {
                            rowinv.totalPur = totalRowtemp.totalPur;
                            rowinv.totalSale = totalRowtemp.totalSale;
                            rowinv.countPur = totalRowtemp.countPur;
                            rowinv.countSale = totalRowtemp.countSale;
                        }

                    }


                    return TokenManager.GenerateToken(list);


                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }
            }


        }

        //in day

        public List<TotalPurSale> GetTotalPurSaleday(DateTime dayDate, int number, int mainBranchId, int userId)
        {
            Calculate calc = new Calculate();
            TotalPurSale totalrow = new TotalPurSale();
            List<TotalPurSale> totalList = new List<TotalPurSale>();
            StatisticsController sts = new StatisticsController();
            List<int> brIds = sts.AllowedBranchsId(mainBranchId, userId);
            using (incposdbEntities entity = new incposdbEntities())
            {
                var invListm1 = (from I in entity.invoices

                                 join BC in entity.branches on I.branchCreatorId equals BC.branchId into JBC

                                 //pbw pb  sb
                                 from JBCC in JBC.DefaultIfEmpty()
                                     // where (I.invType == "p" || I.invType == "pw" || I.invType == "s" || I.invType == "pbw" || I.invType == "pb" || I.invType == "sb")
                                 where (brIds.Contains(JBCC.branchId) && (I.invType == "p" || I.invType == "pw" || I.invType == "s") && JBCC.branchId != 1 && JBCC.isActive == 1)

                                 select new
                                 {
                                     I.invoiceId,
                                     // I.invNumber,
                                     //  I.agentId,
                                     //  I.posId,
                                     I.invType,
                                     //  I.total,
                                     I.totalNet,
                                     I.updateDate,
                                     I.invDate,
                                     //
                                     I.branchCreatorId,
                                     branchCreatorName = JBCC.name,

                                 }).ToList();
                var invListm = invListm1.Where(X => DateTime.Compare(
   (DateTime)calc.changeDateformat(X.invDate, "yyyy-MM-dd")
   , (DateTime)calc.changeDateformat(dayDate, "yyyy-MM-dd")) == 0).ToList();

                totalList = invListm.GroupBy(g => g.branchCreatorId).Select(g => new TotalPurSale
                {
                    //  invType = g.FirstOrDefault().invType,
                    branchCreatorId = g.FirstOrDefault().branchCreatorId,
                    branchCreatorName = g.FirstOrDefault().branchCreatorName,
                    totalPur = g.Where(i => (i.invType == "p" || i.invType == "pw")).Sum(s => s.totalNet),
                    totalSale = g.Where(i => i.invType == "s"  ).Sum(s => s.totalNet),
                    countPur = g.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
                    countSale = g.Where(i => i.invType == "s"  ).Count(),
                    //  purBackCount = g.Where(i => (i.invType == "pbw" || i.invType == "pb")).Count(),
                    // saleBackCount = g.Where(i => i.invType == "sb").Count(),
                    day = number,
                }).ToList();



                return totalList;
            }


        }

        public List<BranchModel> GetAllbranches()
        {
            List<BranchModel> brlist = new List<BranchModel>();
            try
            {
                using (incposdbEntities entity = new incposdbEntities())
                {

                    var brlist1 = entity.branches.ToList();
                    brlist = brlist1.Where(x => (x.branchId != 1 && x.isActive == 1)).Select(b => new BranchModel
                    {
                        branchId = b.branchId,
                        name = b.name,
                        isActive = b.isActive,
                        type = b.type,
                    }).ToList();

                }
                return brlist;
            }
            catch
            {
                return brlist;
            }
        }
    }
}
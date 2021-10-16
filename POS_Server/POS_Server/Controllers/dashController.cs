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
      public string   Getdashsalpur(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)

           
            
            
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {

                try
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

            //   
            //    
            //    string token = "";
            //    if (headers.Contains("APIKey"))
            //    {
            //        token = headers.GetValues("APIKey").First();
            //    }
            //    Validation validation = new Validation();
            //    bool valid = validation.CheckApiKey(token);

            //    if (valid) // APIKey is valid
            //    {
            //        using (incposdbEntities entity = new incposdbEntities())
            //        {
            //            var invListm = (from I in entity.invoices

            //                            join BC in entity.branches on I.branchCreatorId equals BC.branchId into JBC

            //                            //pbw pb  sb
            //                            from JBCC in JBC.DefaultIfEmpty()
            //                            where (I.invType == "p" || I.invType == "pw" || I.invType == "s" || I.invType == "pbw" || I.invType == "pb" || I.invType == "sb")

            //                            select new
            //                            {
            //                                I.invoiceId,
            //                                // I.invNumber,
            //                                //  I.agentId,
            //                                //  I.posId,
            //                                I.invType,
            //                                //  I.total,
            //                                //I.totalNet,


            //                                //
            //                                I.branchCreatorId,
            //                                branchCreatorName = JBCC.name,

            //                            }).ToList();


            //            //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

            //            var group2invlist = invListm.GroupBy(g => g.branchCreatorId).Select(g => new
            //            {
            //                invType = g.FirstOrDefault().invType,
            //                branchCreatorId = g.FirstOrDefault().branchCreatorId,
            //                branchCreatorName = g.FirstOrDefault().branchCreatorName,
            //                purCount = g.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
            //                saleCount = g.Where(i => i.invType == "s").Count(),
            //                purBackCount = g.Where(i => (i.invType == "pbw" || i.invType == "pb")).Count(),
            //                saleBackCount = g.Where(i => i.invType == "sb").Count(),
            //            }).ToList();
            //            /*
            //            .GroupBy(s =>  s.branchCreatorId ).Select(s => new
            //            {
            //                invType = s.FirstOrDefault().invType,
            //                branchCreatorId = s.FirstOrDefault().branchCreatorId,
            //                branchCreatorName = s.FirstOrDefault().branchCreatorName,
            //                purCount = s.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),

            //                saleCount = s.Where(i => i.invType == "s").Count(),
            //            }
            //                ).ToList();
            //                */

            //            /*
            //               var result = temp.GroupBy(s => new { s.updateUserId, s.cUserAccName }).Select(s => new
            //{
            //    updateUserId = s.FirstOrDefault().updateUserId,
            //    cUserAccName = s.FirstOrDefault().cUserAccName,
            //    count = s.Count()
            //});
            //             * */
            //            if (group2invlist == null)
            //                return NotFound();
            //            else
            //                return Ok(group2invlist);
            //        }

            //    }

            //    //else
            //    return NotFound();
        }


        [HttpPost]
        [Route("GetAgentCount")]
      public string   GetAgentCount(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)

           
            
            
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {

                try
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
            //   
            //    
            //    string token = "";
            //    if (headers.Contains("APIKey"))
            //    {
            //        token = headers.GetValues("APIKey").First();
            //    }
            //    Validation validation = new Validation();
            //    bool valid = validation.CheckApiKey(token);

            //    if (valid) // APIKey is valid
            //    {
            //        using (incposdbEntities entity = new incposdbEntities())
            //        {
            //            var invListm = (from A in entity.agents
            //                            select new
            //                            {
            //                                //  A.agentId,                                     
            //                                A.type,
            //                            }).ToList();


            //            //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

            //            var grouplist = invListm.GroupBy(g => g.type).Select(g => new
            //            {
            //                type = g.FirstOrDefault().type,

            //                vendorCount = g.Where(i => i.type == "v").Count(),
            //                customerCount = g.Where(i => i.type == "c").Count(),
            //                grp = 1,
            //            }).ToList().GroupBy(g => g.grp).Select(c => new
            //            {

            //                vendorCount = c.Sum(d => d.vendorCount),
            //                customerCount = c.Sum(d => d.customerCount),
            //            }).ToList();

            //            //g.FirstOrDefault().type=="v"

            //            if (grouplist == null)
            //                return NotFound();
            //            else
            //                return Ok(grouplist);
            //        }

            //    }

            //    //else
            //    return NotFound();
            //}




        }


        //عدد المستخدمين المتصلين والغير متصلين  حاليا في كل فرع 
        [HttpPost]
        [Route("Getuseronline")]
      public string   Getuseronline(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)

           
            
            
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {

                try
                {
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
            //   
            //    
            //    string token = "";
            //    if (headers.Contains("APIKey"))
            //    {
            //        token = headers.GetValues("APIKey").First();
            //    }
            //    Validation validation = new Validation();
            //    bool valid = validation.CheckApiKey(token);

            //    if (valid) // APIKey is valid
            //    {
            //        using (incposdbEntities entity = new incposdbEntities())
            //        {

            //            //  int allUsers = entity.users.ToList().Count();
            //            /*
            //            // get user count in every branch
            //            var listUsersinbranch = entity.branchesUsers.Select(s => new
            //            {
            //                s.branchId,
            //                s.userId
            //            }).ToList();

            //            var listub = listUsersinbranch.GroupBy(g => g.branchId).Select(g => new
            //            {
            //                usersAll = g.Count(),
            //                g.FirstOrDefault().branchId,

            //            }).ToList();
            //            */

            //            var listPosinbranch = entity.pos.Select(s => new
            //            {
            //                s.branchId,
            //                s.posId,
            //                s.isActive,
            //                s.branches.name,
            //            }).ToList();
            //            // get Active Pos count in every branch
            //            var listposb = listPosinbranch.Where(x => x.isActive == 1).GroupBy(g => g.branchId).Select(g => new
            //            {
            //                posAll = g.Count(),
            //                g.FirstOrDefault().branchId,
            //                g.FirstOrDefault().name,

            //            }).ToList();
            //            List<UserOnlineCount> allbranchlist = new List<UserOnlineCount>();

            //            foreach (var row in listposb)
            //            {
            //                UserOnlineCount newrow = new UserOnlineCount();
            //                newrow.allPos = row.posAll;
            //                newrow.branchId = (int)row.branchId;
            //                newrow.branchName = row.name;
            //                newrow.offlineUsers = row.posAll;
            //                newrow.userOnlineCount = 0;

            //                allbranchlist.Add(newrow);

            //            }

            //            var invListm = (from log in entity.usersLogs
            //                            join p in entity.pos on log.posId equals p.posId
            //                            join u in entity.users on log.userId equals u.userId

            //                            where (log.sOutDate == null && log.users.isOnline == 1)

            //                            select new
            //                            {
            //                                log.userId,
            //                                p.branchId,
            //                                branchName = p.branches.name,
            //                                branchisActive = p.branches.isActive,

            //                                log.posId,
            //                                posName = p.name,
            //                                posisActive = p.isActive,
            //                                //
            //                                //usernameAccount = u.username,
            //                                //userName = u.name,
            //                                //lastname = u.lastname,

            //                                //job = u.job,
            //                                //phone = u.phone,
            //                                //mobile = u.mobile,
            //                                //email = u.email,
            //                                //address = u.address,
            //                                //userisActive = u.isActive,
            //                                //isOnline = u.isOnline,

            //                                //image = u.image,

            //                                //

            //                            }).ToList();


            //            //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

            //            List<userOnlineInfo> grouplist = invListm.GroupBy(g => new { g.branchId, g.userId }).Select(g => new userOnlineInfo
            //            {


            //                branchId = g.LastOrDefault().branchId,
            //                branchName = g.LastOrDefault().branchName,
            //                branchisActive = g.LastOrDefault().branchisActive,

            //                posId = g.LastOrDefault().posId,
            //                posName = g.LastOrDefault().posName,
            //                posisActive = g.LastOrDefault().posisActive,

            //                userId = g.LastOrDefault().userId,

            //                //usernameAccount = g.LastOrDefault().usernameAccount,
            //                //userName = g.LastOrDefault().userName,
            //                //lastname = g.LastOrDefault().lastname,
            //                //job = g.LastOrDefault().job,
            //                //phone = g.LastOrDefault().phone,
            //                //mobile = g.LastOrDefault().mobile,
            //                //email = g.LastOrDefault().email,
            //                //address = g.LastOrDefault().address,
            //                //userisActive = g.LastOrDefault().userisActive,
            //                //isOnline = g.LastOrDefault().isOnline,
            //                //image = g.LastOrDefault().image,



            //            }).ToList();

            //            List<UserOnlineCount> grop = grouplist.GroupBy(g => g.branchId).Select(g => new UserOnlineCount
            //            {
            //                userOnlineCount = g.Count(),
            //                allPos = listposb.Where(b => b.branchId == g.FirstOrDefault().branchId).FirstOrDefault().posAll,
            //                offlineUsers = listposb.Where(b => b.branchId == g.FirstOrDefault().branchId).FirstOrDefault().posAll - g.Count(),//offline= all -online
            //                branchId = (int)g.FirstOrDefault().branchId,
            //                branchName = g.FirstOrDefault().branchName,
            //                //  userOnlinelist = grouplist.Where(b => b.branchId == g.FirstOrDefault().branchId).ToList(),
            //                //   userOnlinelist = grouplist.ToList(),
            //            }).ToList();

            //            foreach (UserOnlineCount finalrow in allbranchlist)
            //            {
            //                UserOnlineCount temp = new UserOnlineCount();
            //                temp = grop.Where(x => x.branchId == finalrow.branchId).FirstOrDefault();
            //                if (temp != null)
            //                {
            //                    finalrow.offlineUsers = temp.offlineUsers;
            //                    finalrow.userOnlineCount = temp.userOnlineCount;

            //                }
            //            }

            //            /*
            //            .GroupBy(s =>  s.branchCreatorId ).Select(s => new
            //            {
            //                invType = s.FirstOrDefault().invType,
            //                branchCreatorId = s.FirstOrDefault().branchCreatorId,
            //                branchCreatorName = s.FirstOrDefault().branchCreatorName,
            //                purCount = s.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),

            //                saleCount = s.Where(i => i.invType == "s").Count(),
            //            }
            //                ).ToList();
            //                */

            //            /*
            //               var result = temp.GroupBy(s => new { s.updateUserId, s.cUserAccName }).Select(s => new
            //{
            //    updateUserId = s.FirstOrDefault().updateUserId,
            //    cUserAccName = s.FirstOrDefault().cUserAccName,
            //    count = s.Count()
            //});
            //             * */
            //            if (allbranchlist == null)
            //                return NotFound();
            //            else
            //                return Ok(allbranchlist);
            //        }

            //    }

            //    //else
            //    return NotFound();
        }


        [HttpPost]
        [Route("GetuseronlineInfo")]
      public string   GetuseronlineInfo(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)

           
            
            
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {


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

            //var re = Request;
            //
            //string token = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid) // APIKey is valid
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {


            //        var invListm = (from log in entity.usersLogs
            //                        join p in entity.pos on log.posId equals p.posId
            //                        join u in entity.users on log.userId equals u.userId

            //                        where (log.sOutDate == null && log.users.isOnline == 1)

            //                        select new
            //                        {
            //                            log.userId,
            //                            p.branchId,
            //                            branchName = p.branches.name,
            //                            branchisActive = p.branches.isActive,

            //                            log.posId,
            //                            posName = p.name,
            //                            posisActive = p.isActive,
            //                            //
            //                            usernameAccount = u.username,
            //                            userName = u.name,
            //                            lastname = u.lastname,

            //                            job = u.job,
            //                            phone = u.phone,
            //                            mobile = u.mobile,
            //                            email = u.email,
            //                            address = u.address,
            //                            userisActive = u.isActive,
            //                            isOnline = u.isOnline,

            //                            image = u.image,

            //                            //

            //                        }).ToList();



            //        List<userOnlineInfo> grouplist = invListm.GroupBy(g => new { g.branchId, g.userId }).Select(g => new userOnlineInfo
            //        {


            //            branchId = g.FirstOrDefault().branchId,
            //            branchName = g.LastOrDefault().branchName,
            //            branchisActive = g.LastOrDefault().branchisActive,

            //            posId = g.LastOrDefault().posId,
            //            posName = g.LastOrDefault().posName,
            //            posisActive = g.LastOrDefault().posisActive,

            //            userId = g.LastOrDefault().userId,
            //            usernameAccount = g.LastOrDefault().usernameAccount,
            //            userName = g.LastOrDefault().userName,
            //            lastname = g.LastOrDefault().lastname,
            //            job = g.LastOrDefault().job,
            //            phone = g.LastOrDefault().phone,
            //            mobile = g.LastOrDefault().mobile,
            //            email = g.LastOrDefault().email,
            //            address = g.LastOrDefault().address,
            //            userisActive = g.LastOrDefault().userisActive,
            //            isOnline = g.LastOrDefault().isOnline,
            //            image = g.LastOrDefault().image,
            //        }).ToList();


            //        if (grouplist == null)
            //            return NotFound();
            //        else
            //            return Ok(grouplist);
            //    }

            //}

            ////else
            //return NotFound();
        }


        [HttpPost]
        [Route("GetBrachonline")]
      public string   GetBrachonline(string token)
        {

            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)

           
            
            
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {

                try
                {
                    List<BranchOnlineCount> list = new List<BranchOnlineCount>();

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
                        list.Add(brow);

                        return TokenManager.GenerateToken(list);

                    }

                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }


            }


            //var re = Request;
            //
            //string token = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid) // APIKey is valid
            //{
            //    List<BranchOnlineCount> blist = new List<BranchOnlineCount>();

            //    using (incposdbEntities entity = new incposdbEntities())
            //    {


            //        // int allBranches = entity.branches.ToList().Count();
            //        var allBranchesList = entity.branches.ToList();
            //        int allBranches = allBranchesList
            //            .Select(b => new
            //            {
            //                b.branchId,
            //                b.isActive,
            //            }).Where(b => (b.branchId != 1 && b.isActive == 1)).ToList().Count();
            //        var invListm = (from log in entity.usersLogs
            //                        join p in entity.pos on log.posId equals p.posId
            //                        where (log.sOutDate == null && log.users.isOnline == 1)

            //                        select new
            //                        {
            //                            log.userId,
            //                            p.branchId,
            //                            branchName = p.branches.name,

            //                        }).ToList();


            //        var grouplist = invListm.GroupBy(g => new { g.branchId, g.userId }).Select(g => new
            //        {
            //            g.FirstOrDefault().userId,
            //            g.FirstOrDefault().branchId,
            //            g.FirstOrDefault().branchName,

            //        }).ToList();
            //        List<UserOnlineCount> grop = grouplist.GroupBy(g => g.branchId).Select(g => new UserOnlineCount
            //        {

            //            branchId = (int)g.FirstOrDefault().branchId,
            //            branchName = g.FirstOrDefault().branchName,
            //        }).ToList();
            //        BranchOnlineCount brow = new BranchOnlineCount();
            //        brow.branchAll = allBranches;
            //        brow.branchOnline = grop.Count();
            //        brow.branchOffline = allBranches - grop.Count();


            //        blist.Add(brow);



            //        // return blist;
            //        if (blist == null)
            //            return NotFound();
            //        else
            //            return Ok(blist);
            //    }
            //}
            ////else
            //return NotFound();
        }

        //عدد الفواتير في اليوم الحالي 
        [HttpPost]
        [Route("GetdashsalpurDay")]
      public string   GetdashsalpurDay(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)

           
            
            
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                Calculate calc = new Calculate();
                try
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
                        var invListm = invListmtmp.Where(X => DateTime.Compare(
                           (DateTime)calc.changeDateformat(X.updateDate, "yyyy-MM-dd")
                           , (DateTime)calc.changeDateformat(DateTime.Now, "yyyy-MM-dd")) == 0).ToList();

                        //                invListm.Where(X => DateTime.Compare(
                        //(DateTime)calc.changeDateformat(X.updateDate, "yyyy-MM-dd")
                        //, (DateTime)calc.changeDateformat(date, "yyyy-MM-dd")) == 0).ToList();

                        //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

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


        //    Calculate calc = new Calculate();
        //   
        //    
        //    string token = "";
        //    if (headers.Contains("APIKey"))
        //    {
        //        token = headers.GetValues("APIKey").First();
        //    }
        //    Validation validation = new Validation();
        //    bool valid = validation.CheckApiKey(token);

        //    if (valid) // APIKey is valid
        //    {
        //        using (incposdbEntities entity = new incposdbEntities())
        //        {
        //            var invListmtmp = (from I in entity.invoices

        //                               join BC in entity.branches on I.branchCreatorId equals BC.branchId into JBC

        //                               //pbw pb  sb
        //                               from JBCC in JBC.DefaultIfEmpty()
        //                               where (I.invType == "p" || I.invType == "pw" || I.invType == "s" || I.invType == "pbw" || I.invType == "pb" || I.invType == "sb")
        //                               //   && I.updateDate==DateTime.Now())
        //                               select new
        //                               {
        //                                   I.invoiceId,
        //                                   // I.invNumber,
        //                                   //  I.agentId,
        //                                   //  I.posId,
        //                                   I.invType,
        //                                   //  I.total,
        //                                   //I.totalNet,


        //                                   //
        //                                   I.branchCreatorId,
        //                                   branchCreatorName = JBCC.name,
        //                                   I.updateDate,
        //                               }).ToList();
        //            var invListm = invListmtmp.Where(X => DateTime.Compare(
        //               (DateTime)calc.changeDateformat(X.updateDate, "yyyy-MM-dd")
        //               , (DateTime)calc.changeDateformat(DateTime.Now, "yyyy-MM-dd")) == 0).ToList();

        //            //                invListm.Where(X => DateTime.Compare(
        //            //(DateTime)calc.changeDateformat(X.updateDate, "yyyy-MM-dd")
        //            //, (DateTime)calc.changeDateformat(date, "yyyy-MM-dd")) == 0).ToList();

        //            //   var group2invlist = invListm.GroupBy(g => new { g.invType, g.branchCreatorId }).Select(g => new

        //            var group2invlist = invListm.GroupBy(g => g.branchCreatorId).Select(g => new
        //            {
        //                invType = g.FirstOrDefault().invType,
        //                branchCreatorId = g.FirstOrDefault().branchCreatorId,
        //                branchCreatorName = g.FirstOrDefault().branchCreatorName,
        //                purCount = g.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
        //                saleCount = g.Where(i => i.invType == "s").Count(),
        //                purBackCount = g.Where(i => (i.invType == "pbw" || i.invType == "pb")).Count(),
        //                saleBackCount = g.Where(i => i.invType == "sb").Count(),
        //            }).ToList();
        //            /*
        //            .GroupBy(s =>  s.branchCreatorId ).Select(s => new
        //            {
        //                invType = s.FirstOrDefault().invType,
        //                branchCreatorId = s.FirstOrDefault().branchCreatorId,
        //                branchCreatorName = s.FirstOrDefault().branchCreatorName,
        //                purCount = s.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
                        
        //                saleCount = s.Where(i => i.invType == "s").Count(),
        //            }
        //                ).ToList();
        //                */

        //            /*
        //               var result = temp.GroupBy(s => new { s.updateUserId, s.cUserAccName }).Select(s => new
        //{
        //    updateUserId = s.FirstOrDefault().updateUserId,
        //    cUserAccName = s.FirstOrDefault().cUserAccName,
        //    count = s.Count()
        //});
        //             * */
        //            if (group2invlist == null)
        //                return NotFound();
        //            else
        //                return Ok(group2invlist);
        //        }

        //    }

        //    //else
        //    return NotFound();
        }

        //
        // فواتير المبيعات مع العناصر
        [HttpPost]
        [Route("Getbestseller")]
      public string   Getbestseller(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)

           
            
            
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                Calculate calc = new Calculate();
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
                                           where (I.invType == "s")

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


            //Calculate calc = new Calculate();

            //var re = Request;
            //
            //string token = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid) // APIKey is valid
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var invListmtmp = (from IT in entity.itemsTransfer
            //                           from I in entity.invoices.Where(I => I.invoiceId == IT.invoiceId)

            //                           from IU in entity.itemsUnits.Where(IU => IU.itemUnitId == IT.itemUnitId)
            //                               // join ITCUSER in entity.users on IT.createUserId equals ITCUSER.userId
            //                               //   join ITUPUSER in entity.users on IT.updateUserId equals ITUPUSER.userId
            //                           join ITEM in entity.items on IU.itemId equals ITEM.itemId
            //                           join UNIT in entity.units on IU.unitId equals UNIT.unitId
            //                           //    join B in entity.branches on I.branchId equals B.branchId into JB
            //                           join BC in entity.branches on I.branchCreatorId equals BC.branchId into JBC
            //                           //  join A in entity.agents on I.agentId equals A.agentId into JA
            //                           //  join U in entity.users on I.createUserId equals U.userId into JU
            //                           // join UPUSR in entity.users on I.updateUserId equals UPUSR.userId into JUPUSR
            //                           //  join IM in entity.invoices on I.invoiceMainId equals IM.invoiceId into JIM
            //                           //   join P in entity.pos on I.posId equals P.posId into JP

            //                           // from JBB in JB
            //                           //from JPP in JP.DefaultIfEmpty()
            //                           //  from JUU in JU.DefaultIfEmpty()
            //                           //  from JUPUS in JUPUSR.DefaultIfEmpty()
            //                           // from JIMM in JIM.DefaultIfEmpty()
            //                           //  from JAA in JA.DefaultIfEmpty()
            //                           from JBCC in JBC.DefaultIfEmpty()
            //                           where (I.invType == "s")

            //                           select new
            //                           {

            //                               itemName = ITEM.name,
            //                               unitName = UNIT.name,
            //                               itemsTransId = IT.itemsTransId,
            //                               itemUnitId = IT.itemUnitId,

            //                               itemId = IU.itemId,
            //                               unitId = IU.unitId,
            //                               quantity = IT.quantity,
            //                               price = IT.price,
            //                               I.invoiceId,
            //                               I.invType,
            //                               I.updateDate,
            //                               I.branchCreatorId,
            //                               branchCreatorName = JBCC.name,
            //                               Totalrow = (IT.price * IT.quantity),

            //                               //   ITcreateDate = IT.createDate,
            //                               ITupdateDate = IT.updateDate,
            //                               // ITcreateUserId = IT.createUserId,
            //                               //  ITupdateUserId = IT.updateUserId,

            //                               //  ITbarcode = IU.barcode,



            //                               // I.posId,

            //                               //  I.total,
            //                               //  I.totalNet,
            //                               // I.paid,
            //                               // I.deserved,
            //                               // I.deservedDate,
            //                               // I.invDate,
            //                               //  I.invoiceMainId,
            //                               // I.invCase,
            //                               // I.invTime,
            //                               //  I.notes,
            //                               // I.vendorInvNum,
            //                               // I.vendorInvDate,
            //                               //  I.createUserId,

            //                               // I.updateUserId,
            //                               // I.branchId,
            //                               //  discountValue = (I.discountType == "1" || I.discountType == null) ? I.discountValue : (I.discountType == "2" ? (I.discountValue / 100) : 0),
            //                               //  I.discountType,
            //                               //  I.tax,
            //                               //  I.name,
            //                               //   I.isApproved,

            //                               //

            //                               //
            //                               //  branchName = JBB.name,

            //                               //  branchType = JBB.type,


            //                               //username

            //                               //  I.invoiceId,
            //                               //    JBB.name
            //                           }).ToList();

            //        var invListm2 = invListmtmp.Where(X => DateTime.Compare(
            //       (DateTime)calc.changeDateformat(X.updateDate, "yyyy-MM")
            //       , (DateTime)calc.changeDateformat(DateTime.Now, "yyyy-MM")) == 0).ToList();

            //        var invListm = invListm2.GroupBy(g => new { g.branchCreatorId, g.itemUnitId })
            //            .Select(g => new
            //            {
            //                itemName = g.FirstOrDefault().itemName,
            //                unitName = g.FirstOrDefault().unitName,
            //                // itemsTransId = IT.itemsTransId,
            //                itemUnitId = g.FirstOrDefault().itemUnitId,

            //                itemId = g.FirstOrDefault().itemId,
            //                unitId = g.FirstOrDefault().unitId,
            //                quantity = g.Sum(s => s.quantity),

            //                price = g.FirstOrDefault().price,
            //                //  I.invoiceId,
            //                //  I.invType,
            //                //    I.updateDate,
            //                branchCreatorId = g.FirstOrDefault().branchCreatorId,
            //                branchCreatorName = g.FirstOrDefault().branchCreatorName,
            //                subTotal = g.Sum(s => s.Totalrow),

            //            }).OrderByDescending(o => o.quantity).ToList().Take(10);

            //        //.Take(3)

            //        if (invListm == null)
            //            return NotFound();
            //        else
            //            return Ok(invListm);
            //    }

            //}

            ////else
            //return NotFound();
        }

        // كمية العناصر في الفروع

        //  [HttpPost]
        [HttpPost]
          [Route("GetIUStorage")]
      public string   GetIUStorage(string token)
        {
            // public ResponseVM GetPurinv(string token)string IUList

            token = TokenManager.readToken(HttpContext.Current.Request);

          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                string IUList = "";
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


                }

                // DateTime cmpdate = DateTime.Now.AddDays(newdays);
                try
                {

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
                                            where iuIds.Contains(IU.itemUnitId)
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

                                                //ITEM.min,
                                                // ITEM.max,
                                                // ITEM.minUnitId,
                                                // ITEM.maxUnitId,
                                                // minUnitName = entity.units.Where(x => x.unitId == ITEM.minUnitId).FirstOrDefault().name,
                                                //  maxUnitName = entity.units.Where(x => x.unitId == ITEM.maxUnitId).FirstOrDefault().name,

                                                // IU.barcode,
                                                //item location

                                                //

                                                //itemslocations


                                                //  IUL.startDate,
                                                // IUL.endDate,

                                                //  IULnote = IUL.note,
                                                //  IU.storageCostId,

                                                //  storageCostName = IU.storageCostId != null ? entity.storageCost.Where(X => X.storageCostId == IU.storageCostId).FirstOrDefault().name : "",
                                                //  storageCostValue = IU.storageCostId != null ?
                                                // entity.storageCost.Where(X => X.storageCostId == IU.storageCostId).FirstOrDefault().cost
                                                // : 0,


                                                // Location
                                                // L.x,
                                                //   L.y,
                                                //   L.z,

                                                //     LocisActive = L.isActive,
                                                //   L.sectionId,
                                                //  Locnote = L.note,

                                                //  LocisFreeZone = L.isFreeZone,


                                                // section

                                                //    Secname = JSS.name,
                                                //    SecisActive = JSS.isActive,
                                                // Secnote = JSS.note,
                                                //   SecisFreeZone = JSS.isFreeZone,

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


            //var re = Request;
            //
            //string token = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);
            //IUList = IUList.Replace("\\", string.Empty);
            //IUList = IUList.Trim('"');
            //List<itemsUnits> newiuObj = JsonConvert.DeserializeObject<List<itemsUnits>>(IUList, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

            //if (valid) // APIKey is valid
            //{

            //    List<int> iuIds = new List<int>();
            //    List<IUStorage> newlist = new List<IUStorage>();
            //    List<branches> brlist = new List<branches>();
            //    using (incposdbEntities entity1 = new incposdbEntities())
            //    {
            //        // get branches
            //        brlist = entity1.branches.ToList();
            //        brlist = brlist.Where(x => (x.branchId != 1 && x.isActive == 1)).Select(b => new branches
            //        {
            //            branchId = b.branchId,
            //            name = b.name,
            //            isActive = b.isActive,
            //        }).ToList();
            //        // prepare new list with all branches and all iu.
            //        foreach (itemsUnits row in newiuObj)
            //        {



            //            foreach (branches branchRow in brlist)
            //            {
            //                IUStorage newrow = new IUStorage();
            //                newrow.itemUnitId = row.itemUnitId;
            //                newrow.quantity = 0;
            //                newrow.branchId = branchRow.branchId;
            //                newrow.branchName = branchRow.name;
            //                newrow.itemId = entity1.itemsUnits.Find(row.itemUnitId).itemId;
            //                newrow.unitId = entity1.itemsUnits.Find(row.itemUnitId).unitId; ;
            //                newrow.itemName = entity1.itemsUnits.Find(row.itemUnitId).items.name;
            //                newrow.unitName = entity1.itemsUnits.Find(row.itemUnitId).units.name;

            //                newlist.Add(newrow);


            //            }

            //            //newrow. = 0;
            //            iuIds.Add(row.itemUnitId);

            //        }

            //    }



            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        // storageCost storageCostsr = new storageCost();

            //        var invListmtemp = (from L in entity.locations
            //                                //  from I in entity.invoices.Where(I => I.invoiceId == IT.invoiceId)


            //                            join IUL in entity.itemsLocations on L.locationId equals IUL.locationId
            //                            join IU in entity.itemsUnits on IUL.itemUnitId equals IU.itemUnitId

            //                            //  join ITCUSER in entity.users on IT.createUserId equals ITCUSER.userId
            //                            //join ITUPUSER in entity.users on IT.updateUserId equals ITUPUSER.userId
            //                            join ITEM in entity.items on IU.itemId equals ITEM.itemId
            //                            join UNIT in entity.units on IU.unitId equals UNIT.unitId
            //                            //   join S in entity.sections on L.sectionId equals S.sectionId into JS
            //                            join B in entity.branches on L.branchId equals B.branchId into JB

            //                            // join UPUSR in entity.users on IUL.updateUserId equals UPUSR.userId into JUPUS
            //                            //  join U in entity.users on IUL.createUserId equals U.userId into JU

            //                            from JBB in JB
            //                            where iuIds.Contains(IU.itemUnitId)
            //                            //  from JSS in JS.DefaultIfEmpty()
            //                            // from JUU in JU.DefaultIfEmpty()
            //                            // from JUPUSS in JUPUS.DefaultIfEmpty()
            //                            select new
            //                            {
            //                                // item unit
            //                                itemName = ITEM.name,
            //                                unitName = UNIT.name,
            //                                IU.itemUnitId,

            //                                IU.itemId,
            //                                IU.unitId,
            //                                branchName = JBB.name,

            //                                branchType = JBB.type,
            //                                IUL.itemsLocId,
            //                                IUL.locationId,
            //                                IUL.quantity,
            //                                L.branchId,

            //                                //ITEM.min,
            //                                // ITEM.max,
            //                                // ITEM.minUnitId,
            //                                // ITEM.maxUnitId,
            //                                // minUnitName = entity.units.Where(x => x.unitId == ITEM.minUnitId).FirstOrDefault().name,
            //                                //  maxUnitName = entity.units.Where(x => x.unitId == ITEM.maxUnitId).FirstOrDefault().name,

            //                                // IU.barcode,
            //                                //item location

            //                                //

            //                                //itemslocations


            //                                //  IUL.startDate,
            //                                // IUL.endDate,

            //                                //  IULnote = IUL.note,
            //                                //  IU.storageCostId,

            //                                //  storageCostName = IU.storageCostId != null ? entity.storageCost.Where(X => X.storageCostId == IU.storageCostId).FirstOrDefault().name : "",
            //                                //  storageCostValue = IU.storageCostId != null ?
            //                                // entity.storageCost.Where(X => X.storageCostId == IU.storageCostId).FirstOrDefault().cost
            //                                // : 0,


            //                                // Location
            //                                // L.x,
            //                                //   L.y,
            //                                //   L.z,

            //                                //     LocisActive = L.isActive,
            //                                //   L.sectionId,
            //                                //  Locnote = L.note,

            //                                //  LocisFreeZone = L.isFreeZone,


            //                                // section

            //                                //    Secname = JSS.name,
            //                                //    SecisActive = JSS.isActive,
            //                                // Secnote = JSS.note,
            //                                //   SecisFreeZone = JSS.isFreeZone,

            //                            }).ToList();

            //        List<IUStorage> invListm = invListmtemp.GroupBy(g => new { g.branchId, g.itemUnitId })
            //              .Select(s => new IUStorage
            //              {
            //                  itemName = s.FirstOrDefault().itemName,
            //                  unitName = s.FirstOrDefault().unitName,
            //                  itemUnitId = s.FirstOrDefault().itemUnitId,

            //                  itemId = s.FirstOrDefault().itemId,
            //                  unitId = s.FirstOrDefault().unitId,
            //                  branchName = s.FirstOrDefault().branchName,
            //                  branchId = s.FirstOrDefault().branchId,
            //                  quantity = s.Sum(q => q.quantity),

            //              }).OrderByDescending(x => x.quantity).ToList();
            //        // merge two list
            //        foreach (IUStorage finalrow in newlist)
            //        {
            //            IUStorage temp = new IUStorage();
            //            temp = invListm.Where(x => (x.branchId == finalrow.branchId && x.itemUnitId == finalrow.itemUnitId)).FirstOrDefault();
            //            if (temp != null)
            //            {
            //                finalrow.quantity = temp.quantity;
            //            }

            //        }


            //        if (newlist == null)
            //            return NotFound();
            //        else
            //            return Ok(newlist.OrderByDescending(x => x.quantity));
            //    }

            //}

            ////else
            //return NotFound();
        }

        // مجموع مبالغ المشتريات والمبيعات اليومي خلال الشهر الحالي لكل فرع
        [HttpPost]
        [Route("GetTotalPurSale")]
      public string   GetTotalPurSale(string token)
        {
            // public string Get(string token)

            // public ResponseVM GetPurinv(string token)

           
            
            
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                Calculate calc = new Calculate();
                try
                {
                    int year;
                    int month;
                    int days;
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

                        totalinday = GetTotalPurSaleday(daydate, i);
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

            //Calculate calc = new Calculate();
            //var re = Request;
            //
            //string token = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid) // APIKey is valid
            //{
            //    int year;
            //    int month;
            //    int days;
            //    List<branches> brlist = new List<branches>();
            //    List<TotalPurSale> totalinMonth = new List<TotalPurSale>();
            //    List<TotalPurSale> totalinday = new List<TotalPurSale>();
            //    List<TotalPurSale> totalAllBranch = new List<TotalPurSale>();
            //    TotalPurSale totalAllBranchRow = new TotalPurSale();
            //    TotalPurSale totalRowtemp = new TotalPurSale();
            //    DateTime currentdate = DateTime.Now;
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {

            //        brlist = entity.branches.ToList();
            //        brlist = brlist.Where(x => (x.branchId != 1 && x.isActive == 1)).Select(b => new branches
            //        {
            //            branchId = b.branchId,
            //            name = b.name,
            //            isActive = b.isActive,
            //        }).ToList();

            //    }

            //    year = currentdate.Year;
            //    month = currentdate.Month;
            //    days = calc.getdays(year, month);
            //    for (int i = 1; i <= days; i++)
            //    {
            //        DateTime daydate = new DateTime(year, month, i);
            //        totalinday = new List<TotalPurSale>();

            //        totalinday = GetTotalPurSaleday(daydate, i);
            //        totalinMonth.AddRange(totalinday);
            //    }

            //    for (int i = 1; i <= days; i++)
            //    {
            //        foreach (branches row in brlist)
            //        {
            //            totalAllBranchRow = new TotalPurSale();
            //            totalAllBranchRow.branchCreatorId = row.branchId;
            //            totalAllBranchRow.branchCreatorName = row.name;
            //            totalAllBranchRow.day = i;
            //            totalAllBranchRow.totalPur = 0;
            //            totalAllBranchRow.totalSale = 0;
            //            totalAllBranchRow.countPur = 0;
            //            totalAllBranchRow.countSale = 0;
            //            totalAllBranch.Add(totalAllBranchRow);

            //        }


            //    }

            //    foreach (TotalPurSale rowinv in totalAllBranch)
            //    {
            //        totalRowtemp = new TotalPurSale();
            //        totalRowtemp = totalinMonth.Where(b => (b.day == rowinv.day && b.branchCreatorId == rowinv.branchCreatorId)).FirstOrDefault();
            //        if (totalRowtemp != null)
            //        {
            //            rowinv.totalPur = totalRowtemp.totalPur;
            //            rowinv.totalSale = totalRowtemp.totalSale;
            //            rowinv.countPur = totalRowtemp.countPur;
            //            rowinv.countSale = totalRowtemp.countSale;
            //        }

            //    }


            //    if (totalAllBranch == null)
            //        return NotFound();
            //    else
            //        return Ok(totalAllBranch);
            //}

            ////else
            //return NotFound();
        }

        //in day

        public List<TotalPurSale> GetTotalPurSaleday(DateTime dayDate, int number)
        {
            Calculate calc = new Calculate();
            TotalPurSale totalrow = new TotalPurSale();
            List<TotalPurSale> totalList = new List<TotalPurSale>();

            using (incposdbEntities entity = new incposdbEntities())
            {
                var invListm1 = (from I in entity.invoices

                                 join BC in entity.branches on I.branchCreatorId equals BC.branchId into JBC

                                 //pbw pb  sb
                                 from JBCC in JBC.DefaultIfEmpty()
                                     // where (I.invType == "p" || I.invType == "pw" || I.invType == "s" || I.invType == "pbw" || I.invType == "pb" || I.invType == "sb")
                                 where ((I.invType == "p" || I.invType == "pw" || I.invType == "s") && JBCC.branchId != 1 && JBCC.isActive == 1)

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

                                     //
                                     I.branchCreatorId,
                                     branchCreatorName = JBCC.name,

                                 }).ToList();
                var invListm = invListm1.Where(X => DateTime.Compare(
   (DateTime)calc.changeDateformat(X.updateDate, "yyyy-MM-dd")
   , (DateTime)calc.changeDateformat(dayDate, "yyyy-MM-dd")) == 0).ToList();

                totalList = invListm.GroupBy(g => g.branchCreatorId).Select(g => new TotalPurSale
                {
                    //  invType = g.FirstOrDefault().invType,
                    branchCreatorId = g.FirstOrDefault().branchCreatorId,
                    branchCreatorName = g.FirstOrDefault().branchCreatorName,
                    totalPur = g.Where(i => (i.invType == "p" || i.invType == "pw")).Sum(s => s.totalNet),
                    totalSale = g.Where(i => i.invType == "s").Sum(s => s.totalNet),
                    countPur = g.Where(i => (i.invType == "p" || i.invType == "pw")).Count(),
                    countSale = g.Where(i => i.invType == "s").Count(),
                    //  purBackCount = g.Where(i => (i.invType == "pbw" || i.invType == "pb")).Count(),
                    // saleBackCount = g.Where(i => i.invType == "sb").Count(),
                    day = number,
                }).ToList();



                return totalList;
            }


        }

    }
}
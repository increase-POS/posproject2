using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POS_Server.Models.VM;
using System.Security.Claims;
using System.Web;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;
using System.Management;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/ProgramDetails")]
    public class ProgramDetailsController : ApiController
    {


        [HttpPost]
        [Route("getCurrentInfo")]
        public async Task<string> getCurrentInfo(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                try
                {
                    ProgramDetailsModel packrow = new ProgramDetailsModel();
                    packrow = getCurrentInfo();
                
                    return TokenManager.GenerateToken(packrow);
                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }


            }
        }


        public ProgramDetailsModel getCurrentInfo()
        {
        
            ProgramDetailsModel packs = new ProgramDetailsModel();
       

            using (incposdbEntities entity = new incposdbEntities())
            {
           

                packs = (from p in entity.ProgramDetails
                             //  join p in entity.posSetting on S.id equals p.posSerialId
                         select new ProgramDetailsModel
                         {
                             programName = p.programName,

                             branchCount = p.branchCount,
                             posCount = p.posCount,
                             userCount = p.userCount,
                             vendorCount = p.vendorCount,
                             customerCount = p.customerCount,
                             itemCount = p.itemCount,
                             saleinvCount = p.saleinvCount,
                             storeCount = p.storeCount,
                             packageSaleCode = p.packageSaleCode,
                             customerServerCode = p.customerServerCode,
                             expireDate = p.expireDate,
                             isOnlineServer = p.isOnlineServer,
                             
                             updateDate = p.updateDate,
                             isLimitDate = (p.isLimitDate == true) ? true : false,
                        
                           
                             isActive = p.isActive,
                             packageName=p.packageName,
                             versionName=p.versionName,
                             packageNumber=p.packageNumber,

                         }).FirstOrDefault();

                packs.posCountNow=  entity.pos.Count();

                packs.branchCountNow = entity.branches.Where(x => x.type == "b").Count();

                packs.storeCountNow= entity.branches.Where(x => x.type == "s").Count();
                packs.userCountNow = entity.users.Count();
                packs.vendorCountNow  = entity.agents.Where(x => x.type =="v").Count();
                packs.customerCountNow= entity.agents.Where(x => x.type == "c").Count();
                packs.itemCountNow = entity.items.Count();

                packs.saleinvCountNow  = entity.invoices.Where(x => x.invType == "s").Count();
                packs.serverDateNow = DateTime.Now;

            }



            return packs;
        }

    }
}
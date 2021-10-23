using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS_Server.Classes;
using POS_Server.Models;
using POS_Server.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Pos")]
    public class PosController : ApiController
    {
        [HttpGet]
        [Route("checkUri")]
        public string checkUri()
        {
            return "";
        }
        // GET api/<controller>
        [HttpPost]
        [Route("Get")]
        public string Get(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            Boolean canDelete = false;
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var posList = (from p in entity.pos
                                   join b in entity.branches on p.branchId equals b.branchId into lj
                                   from x in lj.DefaultIfEmpty()
                                   select new PosModel() {
                                       posId = p.posId,
                                       balance = p.balance,
                                       branchId = p.branchId,
                                       code = p.code,
                                       name = p.name,
                                       branchName = x.name,
                                       createDate = p.createDate,
                                       updateDate = p.updateDate,
                                       createUserId = p.createUserId,
                                       updateUserId = p.updateUserId,
                                       isActive = p.isActive,
                                      balanceAll=p.balanceAll,
                                       note = p.note,
                                       branchCode = x.code,
                                   }).ToList();

                    if (posList.Count > 0)
                    {
                        for (int i = 0; i < posList.Count; i++)
                        {
                            canDelete = false;
                            if (posList[i].isActive == 1)
                            {
                                int posId = (int)posList[i].posId;
                                var cashTransferL = entity.cashTransfer.Where(x => x.posId == posId).Select(b => new { b.cashTransId }).FirstOrDefault();
                                var posUsersL = entity.posUsers.Where(x => x.posId == posId).Select(x => new { x.posUserId }).FirstOrDefault();
                               
                                if ((cashTransferL is null) && (posUsersL is null))
                                    canDelete = true;
                            }
                           
                            posList[i].canDelete = canDelete;
                        }
                    }
                    return TokenManager.GenerateToken(posList);
                }
            }
          
        }
        // GET api/<controller>
        [HttpPost]
        [Route("GetPosByID")]
        public string GetPosByID(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int posId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        posId = int.Parse(c.Value);
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var pos = (from p in entity.pos where p.posId == posId
                                join b in entity.branches on p.branchId equals b.branchId into lj
                                from x in lj.DefaultIfEmpty()
                                select new PosModel()
                                {
                                    posId = p.posId,
                                    balance = p.balance,
                                    branchId = p.branchId,
                                    code = p.code,
                                    name = p.name,
                                    branchName = x.name,
                                    createDate = p.createDate,
                                    updateDate = p.updateDate,
                                    createUserId = p.createUserId,
                                    updateUserId = p.updateUserId,
                                    isActive = p.isActive,
                                    balanceAll = p.balanceAll,
                                    note = p.note,
                                    branchCode = x.code,
                                }).FirstOrDefault();
                    return TokenManager.GenerateToken(pos);
                }
            }
         }
        // add or update pos
        [HttpPost]
        [Route("Save")]
        public string Save(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            string message = "";
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                string posObject = "";
                pos newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        posObject = c.Value.Replace("\\", string.Empty);
                        posObject = posObject.Trim('"');
                        newObject = JsonConvert.DeserializeObject<pos>(posObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
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
                        pos tmpPos = new pos();
                        var unitEntity = entity.Set<pos>();
                        if (newObject.posId == 0)
                        {
                            ProgramInfo programInfo = new ProgramInfo();
                            int posMaxCount = programInfo.getPosCount();
                            int posCount = entity.pos.Count();
                            if (posCount >= posMaxCount)
                            {
                                message = "-1";
                                return TokenManager.GenerateToken(message);
                            }
                            else
                            {
                                newObject.createDate = DateTime.Now;
                                newObject.updateDate = DateTime.Now;
                                newObject.updateUserId = newObject.createUserId;

                                tmpPos = unitEntity.Add(newObject);
                                entity.SaveChanges();
                                message = tmpPos.posId.ToString();
                            }
                            return TokenManager.GenerateToken(message);
                        }
                        else
                        {
                            tmpPos = entity.pos.Where(p => p.posId == newObject.posId).FirstOrDefault();
                            tmpPos.name = newObject.name;
                            tmpPos.code = newObject.code;
                            tmpPos.branchId = newObject.branchId;
                            tmpPos.note = newObject.note;
                            tmpPos.updateDate = DateTime.Now;
                            tmpPos.updateUserId = newObject.updateUserId;
                            tmpPos.isActive = newObject.isActive;
                            tmpPos.balance = newObject.balance;
                            tmpPos.balanceAll = newObject.balanceAll;
                            entity.SaveChanges();
                            message = tmpPos.posId.ToString();
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
        [Route("Delete")]
        public string Delete(string token)
        {
token = TokenManager.readToken(HttpContext.Current.Request);
            string message = "";
            if (TokenManager.GetPrincipal(token) == null)//invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int posId = 0;
                int userId = 0;
                Boolean final = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        posId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                    else if (c.Type == "final")
                    {
                        final = bool.Parse(c.Value);
                    }
                }
                if (final)
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            pos posDelete = entity.pos.Find(posId);

                            entity.pos.Remove(posDelete);
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
                else
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        pos posDelete = entity.pos.Find(posId);

                        posDelete.isActive = 0;
                        posDelete.updateUserId = userId;
                        posDelete.updateDate = DateTime.Now;
                        message = entity.SaveChanges().ToString();
                        return TokenManager.GenerateToken(message);
                    }
                }
            }
        }
    }
}
﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS_Server.Models;
using POS_Server.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Banks")]
    public class BanksController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("Get")]
        public ResponseVM Get(string token)
        {
            Boolean canDelete = false;
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var banksList = entity.banks.Select(b => new BankModel
                    {
                        accNumber = b.accNumber,
                        address = b.address,
                        bankId = b.bankId,
                        mobile = b.mobile,
                        name = b.name,
                        notes = b.notes,
                        phone = b.phone,
                        createDate = b.createDate,
                        updateDate = b.updateDate,
                        createUserId = b.createUserId,
                        updateUserId = b.updateUserId,
                        isActive = b.isActive,

                    })
                    .ToList();

                    if (banksList.Count > 0)
                    {
                        for (int i = 0; i < banksList.Count; i++)
                        {
                            canDelete = false;
                            if (banksList[i].isActive == 1)
                            {
                                int bankId = (int)banksList[i].bankId;
                                var operationsL = entity.cashTransfer.Where(x => x.bankId == bankId).Select(b => new { b.cashTransId }).FirstOrDefault();

                                if (operationsL is null)
                                    canDelete = true;
                            }
                            banksList[i].canDelete = canDelete;
                        }
                    }
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(banksList) };

                }
            }
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetBankByID")]
        public ResponseVM GetBankByID(string token)
        {
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int bankId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        bankId = int.Parse(c.Value);
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var bank = entity.banks
                   .Where(b => b.bankId == bankId)
                   .Select(b => new
                   {
                       b.accNumber,
                       b.address,
                       b.bankId,
                       b.mobile,
                       b.name,
                       b.notes,
                       b.phone,
                       b.createDate,
                       b.updateDate,
                       b.createUserId,
                       b.updateUserId
                   })
                   .FirstOrDefault();
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(bank) };

                }
            }
        }

        // add or update bank
        [HttpPost]
        [Route("Save")]
        public ResponseVM Save(string token)
        {
            string message = "";
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                string bankId = "";
                banks newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        bankId = c.Value.Replace("\\", string.Empty);
                        bankId = bankId.Trim('"');
                        newObject = JsonConvert.DeserializeObject<banks>(bankId, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
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
                        banks tmpBank = new banks();
                        var bankEntity = entity.Set<banks>();
                        if (newObject.bankId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;
                            tmpBank = bankEntity.Add(newObject);
                            entity.SaveChanges();
                            message = tmpBank.bankId.ToString(); ;
                        }
                        else
                        {
                            tmpBank = entity.banks.Where(p => p.bankId == newObject.bankId).FirstOrDefault();
                            tmpBank.name = newObject.name;
                            tmpBank.accNumber = newObject.accNumber;
                            tmpBank.address = newObject.address;
                            tmpBank.mobile = newObject.mobile;
                            tmpBank.notes = newObject.notes;
                            tmpBank.phone = newObject.phone;
                            tmpBank.updateDate = DateTime.Now;
                            tmpBank.updateUserId = newObject.updateUserId;
                            tmpBank.isActive = newObject.isActive;
                            entity.SaveChanges();
                            message = tmpBank.bankId.ToString();

                        }
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                    }
                }

                catch
                {
                    message = "0";
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
                }
            }
        }

        [HttpPost]
        [Route("Delete")]
        public ResponseVM Delete(string token)
        {
            string message = "";
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int bankId = 0;
                int userId = 0;
                Boolean final = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        bankId = int.Parse(c.Value);
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

                            banks bankDelete = entity.banks.Find(bankId);
                            entity.banks.Remove(bankDelete);
                            message = entity.SaveChanges().ToString();
                            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                        }
                    }
                    catch
                    {
                        return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                    }
                }
                else
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {

                            banks bankObj = entity.banks.Find(bankId);
                            bankObj.isActive = 0;
                            bankObj.updateUserId = userId;
                            bankObj.updateDate = DateTime.Now;
                            message = entity.SaveChanges().ToString();
                            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                        }
                    }
                    catch
                    {
                        return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                    }
                }
            }
        }
    }
}
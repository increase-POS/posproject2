using Newtonsoft.Json;
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
    [RoutePrefix("api/ShippingCompanies")]
    public class ShippingCompaniesController : ApiController
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
                    var List = (from S in entity.shippingCompanies
                                select new ShippingCompaniesModel()
                                {
                                    shippingCompanyId = S.shippingCompanyId,
                                    name = S.name,
                                    RealDeliveryCost = S.RealDeliveryCost,
                                    deliveryCost = S.deliveryCost,
                                    deliveryType = S.deliveryType,
                                    notes = S.notes,
                                    isActive = S.isActive,
                                    createDate = S.createDate,
                                    updateDate = S.updateDate,
                                    createUserId = S.createUserId,
                                    updateUserId = S.updateUserId,
                                    balance = S.balance,
                                    balanceType = S.balanceType,

                                    email = S.email,
                                    phone = S.phone,
                                    mobile = S.mobile,
                                    fax = S.fax,
                                    address = S.address,


                                }).ToList();
                    if (List.Count > 0)
                    {
                        for (int i = 0; i < List.Count; i++)
                        {
                            if (List[i].isActive == 1)
                            {
                                int shippingCompanyId = (int)List[i].shippingCompanyId;
                                var itemsI = entity.invoices.Where(x => x.shippingCompanyId == shippingCompanyId).Select(b => new { b.invoiceId }).FirstOrDefault();

                                if ((itemsI is null))
                                    canDelete = true;
                            }
                            List[i].canDelete = canDelete;
                        }
                    }

                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(List) };

                }
            }
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetByID")]
        public ResponseVM GetByID(string token )
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
                int shippingCompanyId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        shippingCompanyId = int.Parse(c.Value);
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var row = entity.shippingCompanies
                   .Where(u => u.shippingCompanyId == shippingCompanyId)
                   .Select(S => new
                   {
                       S.shippingCompanyId,
                       S.name,
                       S.RealDeliveryCost,
                       S.deliveryCost,
                       S.deliveryType,
                       S.notes,
                       S.createDate,
                       S.updateDate,
                       S.createUserId,
                       S.updateUserId,
                       S.isActive,
                       S.balance,
                       S.balanceType,
                       S.email,
                       S.phone,
                       S.mobile,
                       S.fax,
                       S.address,

                   })
                   .FirstOrDefault();

                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(row) };

                }
            }
        }

        // add or update location
        [HttpPost]
        [Route("Save")]
        public ResponseVM Save(string token  )
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
                string shippingCompaniesObject = "";
                shippingCompanies newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemObject")
                    {
                        shippingCompaniesObject = c.Value.Replace("\\", string.Empty);
                        shippingCompaniesObject = shippingCompaniesObject.Trim('"');
                        newObject = JsonConvert.DeserializeObject<shippingCompanies>(shippingCompaniesObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
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
                        var locationEntity = entity.Set<shippingCompanies>();
                        if (newObject.shippingCompanyId == 0)
                        {
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;


                            locationEntity.Add(newObject);
                            entity.SaveChanges();
                            message = newObject.shippingCompanyId.ToString();
                        }
                        else
                        {
                            var tmpObject = entity.shippingCompanies.Where(p => p.shippingCompanyId == newObject.shippingCompanyId).FirstOrDefault();

                            tmpObject.updateDate = DateTime.Now;
                            tmpObject.updateUserId = newObject.updateUserId;

                            tmpObject.name = newObject.name;
                            tmpObject.RealDeliveryCost = newObject.RealDeliveryCost;
                            tmpObject.deliveryCost = newObject.deliveryCost;
                            tmpObject.deliveryType = newObject.deliveryType;
                            tmpObject.notes = newObject.notes;
                            tmpObject.isActive = newObject.isActive;
                            tmpObject.balance = newObject.balance;
                            tmpObject.balanceType = newObject.balanceType;
                            tmpObject.email = newObject.email;
                            tmpObject.phone = newObject.phone;
                            tmpObject.mobile = newObject.mobile;
                            tmpObject.fax = newObject.fax;
                            tmpObject.address = newObject.address;

                            entity.SaveChanges();

                            message = tmpObject.shippingCompanyId.ToString();
                        }
                        //  entity.SaveChanges();
                    }
                }
                catch
                {
                    message = "-1";
                }
            }
            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
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
                int shippingCompanyId = 0;
                int userId = 0;
                Boolean final = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        shippingCompanyId = int.Parse(c.Value);
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
                            shippingCompanies objectDelete = entity.shippingCompanies.Find(shippingCompanyId);

                            entity.shippingCompanies.Remove(objectDelete);
                            message = entity.SaveChanges().ToString();

                            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                        }
                    }
                    catch
                    {
                        message =  "-1";
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                    }
                }
                else
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            shippingCompanies objectDelete = entity.shippingCompanies.Find(shippingCompanyId);

                            objectDelete.isActive = 0;
                            objectDelete.updateUserId = userId;
                            objectDelete.updateDate = DateTime.Now;
                            message = entity.SaveChanges().ToString();

                            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                        }
                    }
                    catch
                    {
                        message = "-2";
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                    }
                }
            }
        }
    }
}
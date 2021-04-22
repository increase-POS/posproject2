using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Banks")]
    public class BanksController : ApiController
    {
            // GET api/<controller>
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
                        var banksList = entity.banks.Select(b => new {
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

            // GET api/<controller>
            [HttpGet]
            [Route("GetBankByID")]
            public IHttpActionResult GetBankByID()
            {
                var re = Request;
                var headers = re.Headers;
                string token = "";
                int bankId = 0;
                if (headers.Contains("APIKey"))
                {
                    token = headers.GetValues("APIKey").First();
                }
                if (headers.Contains("bankId"))
                {
                bankId = Convert.ToInt32(headers.GetValues("bankId").First());
                }
                Validation validation = new Validation();
                bool valid = validation.CheckApiKey(token);

                if (valid)
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var bank = entity.banks
                       .Where(b => b.bankId == bankId)
                       .Select(b => new {
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

                        if (bank == null)
                            return NotFound();
                        else
                            return Ok(bank);
                    }
                }
                else
                    return NotFound();
            }

            // add or update unit
            [HttpPost]
            [Route("Save")]
            public string Save(string bankObject)
            {
                var re = Request;
                var headers = re.Headers;
                string token = "";
                string message = "";
                if (headers.Contains("APIKey"))
                {
                    token = headers.GetValues("APIKey").First();
                }
                Validation validation = new Validation();
                bool valid = validation.CheckApiKey(token);

                if (valid)
                {
                bankObject = bankObject.Replace("\\", string.Empty);
                bankObject = bankObject.Trim('"');
                banks newObject = JsonConvert.DeserializeObject<banks>(bankObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                            var bankEntity = entity.Set<banks>();
                            if (newObject.bankId == 0)
                            {
                                bankEntity.Add(newObject);
                                message = "Bank Is Added Successfully";
                            }
                            else
                            {
                                var tmpBank = entity.banks.Where(p => p.bankId == newObject.bankId).FirstOrDefault();
                                tmpBank.name = newObject.name;
                                tmpBank.accNumber = newObject.accNumber;
                                tmpBank.address = newObject.address;
                               tmpBank.mobile = newObject.mobile;
                            tmpBank.notes = newObject.notes;
                            tmpBank.phone = newObject.phone;
                            tmpBank.updateDate = newObject.updateDate;
                               tmpBank.updateUserId = newObject.updateUserId;
                              
                                message = "Bank Is Updated Successfully";
                            }
                            entity.SaveChanges();
                        }
                    }

                    catch
                    {
                        message = "an error ocurred";
                    }
                }
                return message;
            }

            [HttpPost]
            [Route("Delete")]
            public IHttpActionResult Delete(int bankId)
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
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            
                                banks bankDelete = entity.banks.Find(bankId);
                                entity.banks.Remove(bankDelete);
                                entity.SaveChanges();
                                return Ok("Bank is Deleted Successfully"); 
                        }
                    }
                    catch
                    {
                        return NotFound();
                    }
                }
                else
                    return NotFound();
            }
        }
}
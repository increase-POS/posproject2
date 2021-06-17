using Newtonsoft.Json;
using POS_Server.Models;
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
            Boolean canDelete = false;

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
                        var banksList = entity.banks.Select(b => new BankModel {
                           accNumber= b.accNumber,
                            address= b.address,
                            bankId= b.bankId,
                            mobile= b.mobile,
                            name=b.name,
                            notes=b.notes,
                            phone=b.phone,
                            createDate=b.createDate,
                            updateDate=b.updateDate,
                            createUserId=b.createUserId,
                            updateUserId=b.updateUserId,
                            isActive=b.isActive,

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
                    if (banksList == null)
                            return NotFound();
                        else
                            return Ok(banksList);
                    }
                }
                //else
                return NotFound();
            }
        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string searchWords)
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
                    var banksList = entity.banks
                        .Where(x =>(x.name.Contains(searchWords) || x.accNumber.Contains(searchWords) || x.address.Contains(searchWords) || x.mobile.Contains(searchWords)))
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

            // add or update bank
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
                            newObject.createDate = DateTime.Now;
                            newObject.updateDate = DateTime.Now;
                            newObject.updateUserId = newObject.createUserId;
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
                            tmpBank.updateDate = DateTime.Now;
                            tmpBank.updateUserId = newObject.updateUserId;
                            tmpBank.isActive = newObject.isActive;

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
            public IHttpActionResult Delete(int bankId , int userId , Boolean final)
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
                if (final)
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
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {

                            banks bankObj = entity.banks.Find(bankId);
                            bankObj.isActive = 0;
                            bankObj.updateUserId = userId;
                            bankObj.updateDate = DateTime.Now;
                            entity.SaveChanges();
                            return Ok("Bank is Deleted Successfully");
                        }
                    }
                    catch
                    {
                        return NotFound();
                    }
                }
                }
                else
                    return NotFound();
            }
        }
}
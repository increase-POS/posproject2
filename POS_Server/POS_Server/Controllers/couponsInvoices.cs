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
    [RoutePrefix("api/couponsInvoices")]
    public class couponsInvoicesController : ApiController
    {
        // GET api/<controller> get all couponsInvoices
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
                    var couponsInvoicesList = entity.couponsInvoices

                   .Select(c => new {
                     c.id 
                    ,c.couponId 
                     ,c.InvoiceId
                    ,c.createDate
                     ,c.updateDate 
                     ,c.createUserId 
                     , c.updateUserId 
            
                 })
                   .ToList();

                    if (couponsInvoicesList == null)
                        return NotFound();
                    else
                        return Ok(couponsInvoicesList);
                }
            }
            //else
                return NotFound();
        }



        // GET api/<controller>  Get couponsInvoices By ID 
        [HttpGet]
        [Route("GetByID")]
        public IHttpActionResult GetByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int id = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("id"))
            {
                id = Convert.ToInt32(headers.GetValues("id").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var couponsInvoices = entity.couponsInvoices
                   .Where(c => c.id == id)
                   .Select(c => new {
                       c.id
                     ,c.couponId
                     ,c.InvoiceId
                     ,c.createDate
                     ,c.updateDate
                     ,c.createUserId
                     ,c.updateUserId
                   })
                   .FirstOrDefault();

                    if (couponsInvoices == null)
                        return NotFound();
                    else
                        return Ok(couponsInvoices);
                }
            }
            else
                return NotFound();
        }





        // add or update couponsInvoices
        [HttpPost]
        [Route("Save")]
        public string Save(string couponsInvoicesObject)
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
                couponsInvoicesObject = couponsInvoicesObject.Replace("\\", string.Empty);
                couponsInvoicesObject = couponsInvoicesObject.Trim('"');
                couponsInvoices Object = JsonConvert.DeserializeObject<couponsInvoices>(couponsInvoicesObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var couponsInvoicesEntity = entity.Set<couponsInvoices>();
                        if (Object.id == 0)
                        {
                            couponsInvoicesEntity.Add(Object);
                            message = "couponsInvoices Is Added Successfully";
                        }
                        else
                        {

                            var tmpcouponsInvoices = entity.couponsInvoices.Where(p => p.id == Object.id).FirstOrDefault();




                            tmpcouponsInvoices.couponId = Object.couponId;
                            tmpcouponsInvoices.InvoiceId = Object.InvoiceId;
                  tmpcouponsInvoices.createDate= Object.createDate;
                    tmpcouponsInvoices.updateDate= Object.updateDate;
                    tmpcouponsInvoices.createUserId= Object.createUserId;
                    tmpcouponsInvoices.updateUserId= Object.updateUserId;

                            message = "coupon Is Updated Successfully";
                        }
                        entity.SaveChanges();
                    }  
               }

                catch
                {
                   message ="an error ocurred";
                }
            }
                return message;
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int couponId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("cId"))
            {
                couponId = Convert.ToInt32(headers.GetValues("cId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            if (valid)
            {
               try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        return NotFound();
                    }
                }
               catch
               {
                    return NotFound() ;
               }
            }
            else
               return NotFound();
        }
    }
}
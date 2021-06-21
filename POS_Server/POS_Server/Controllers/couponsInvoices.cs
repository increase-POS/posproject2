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
        public IHttpActionResult Get(int invoiceId)
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
                 var couponsInvoicesList = (from c in entity.couponsInvoices
                     where c.InvoiceId == invoiceId
                     join b in entity.coupons on c.couponId equals b.cId into lj
                     from x in lj.DefaultIfEmpty()
                     select new CouponInvoiceModel()
                     {
                         id = c.id,
                         couponId = c.couponId,
                         InvoiceId = c.InvoiceId,
                         createDate = c.createDate,
                         updateDate = c.updateDate,
                         createUserId = c.createUserId,
                         updateUserId = c.updateUserId,
                         discountValue = c.discountValue,
                         discountType = c.discountType,
                         couponCode = x.code,
                     }).ToList();
                   

                    if (couponsInvoicesList == null)
                        return NotFound();
                    else
                        return Ok(couponsInvoicesList);
                }
            }
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
        public Boolean Save(string couponsInvoicesObject, int invoiceId)
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
                // delete old invoice items
                using (incposdbEntities entity = new incposdbEntities())
                {
                    List<couponsInvoices> coupons = entity.couponsInvoices.Where(x => x.InvoiceId == invoiceId).ToList();
                    entity.couponsInvoices.RemoveRange(coupons);
                    try { entity.SaveChanges(); }
                    catch { }

                }
                couponsInvoicesObject = couponsInvoicesObject.Replace("\\", string.Empty);
                couponsInvoicesObject = couponsInvoicesObject.Trim('"');
                List<couponsInvoices> Object = JsonConvert.DeserializeObject<List<couponsInvoices>>(couponsInvoicesObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    for (int i = 0; i < Object.Count; i++)
                    {
                        var couponsInvoicesEntity = entity.Set<couponsInvoices>();
                        if (Object[i].updateUserId == 0 || Object[i].updateUserId == null)
                        {
                            Nullable<int> id = null;
                            Object[i].updateUserId = id;
                        }
                        if (Object[i].createUserId == 0 || Object[i].createUserId == null)
                        {
                            Nullable<int> id = null;
                            Object[i].createUserId = id;
                        }
                        Object[i].createDate = DateTime.Now;
                        Object[i].updateDate = DateTime.Now;
                        Object[i].updateUserId = Object[i].createUserId;

                        couponsInvoicesEntity.Add(Object[i]);
                    }
                    try
                    {
                        entity.SaveChanges();
                    }
                    catch { return false; }
                }
            }
            return true;
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
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
        [HttpGet]
        [Route("GetOriginal")]
        public IHttpActionResult GetOriginal(int invoiceId)
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
                     where x.startDate <= DateTime.Now && x.endDate >= DateTime.Now && x.remainQ >0
                     select new CouponInvoiceModel()
                     {
                         id = c.id,
                         couponId = c.couponId,
                         InvoiceId = c.InvoiceId,
                         createDate = c.createDate,
                         updateDate = c.updateDate,
                         createUserId = c.createUserId,
                         updateUserId = c.updateUserId,
                         discountValue = x.discountValue, 
                         discountType = x.discountType,
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
        public int Save(string couponsInvoicesObject, int invoiceId,string invType)
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
                couponsInvoicesObject = couponsInvoicesObject.Replace("\\", string.Empty);
                couponsInvoicesObject = couponsInvoicesObject.Trim('"');
                List<couponsInvoices> Object = JsonConvert.DeserializeObject<List<couponsInvoices>>(couponsInvoicesObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    if (invType == "sd" || invType == "qd")
                    {
                        var oldList = entity.couponsInvoices.Where(p => p.InvoiceId == invoiceId);
                        if (oldList.Count() > 0)
                        {
                            entity.couponsInvoices.RemoveRange(oldList);
                        }
                        if (Object.Count() > 0)
                        {
                            foreach (couponsInvoices coupon  in Object)
                            {
                                //coupon.userId = userId;
                                if (coupon.createDate == null)
                                {
                                    coupon.createDate = DateTime.Now;
                                    coupon.updateDate = DateTime.Now;
                                    coupon.updateUserId = coupon.createUserId;
                                }
                                else
                                {
                                    coupon.updateDate = DateTime.Now;
                                }
                            }
                            entity.couponsInvoices.AddRange(Object);
                        }
                        entity.SaveChanges();
                    }
                    else
                    {
                        var oldList = entity.couponsInvoices.Where(x => x.InvoiceId == invoiceId).Select(x => new { x.couponId, x.id }).ToList();
                        for (int i = 0; i < oldList.Count; i++)// loop to remove not exist coupon
                        {
                            int exist = 0;
                            coupons c = entity.coupons.Find(oldList[i].couponId);

                            int couponId = (int)oldList[i].couponId;
                            var tci = entity.couponsInvoices.Where(x => x.couponId == couponId && x.InvoiceId == invoiceId).FirstOrDefault();
                            couponsInvoices ci = entity.couponsInvoices.Find(tci.id);

                            if (Object != null && Object.Count > 0)
                            {
                                var isExist = Object.Find(x => x.couponId == oldList[i].couponId);
                                if (isExist == null)
                                    exist = 0;
                                else
                                    exist = 1;
                            }
                            //return exist;
                            if (exist == 0)// remove coupon from invoice
                            {
                                c.remainQ++;
                                entity.couponsInvoices.Remove(ci);
                            }
                            else // edit previously added coupons
                            {
                                ci.discountType =c.discountType;
                                ci.discountValue = c.discountValue;
                                ci.updateDate = DateTime.Now;
                            }
                            entity.SaveChanges();
                        }
                        foreach (couponsInvoices coupon in Object)// loop to add new coupons
                        {
                            Boolean isInList = false;
                            if (oldList != null)
                            {
                                var old = oldList.ToList().Find(x => x.couponId == coupon.couponId);
                                if (old != null)
                                    isInList = true;
                            }
                            if (!isInList)
                            {
                                if (coupon.updateUserId == 0 || coupon.updateUserId == null)
                                {
                                    Nullable<int> id = null;
                                    coupon.updateUserId = id;
                                }
                                if (coupon.createUserId == 0 || coupon.createUserId == null)
                                {
                                    Nullable<int> id = null;
                                    coupon.createUserId = id;
                                }
                                coupon.createDate = DateTime.Now;
                                coupon.updateDate = DateTime.Now;
                                coupon.updateUserId = coupon.createUserId;

                                entity.couponsInvoices.Add(coupon);
                                entity.SaveChanges();
                                coupons c = entity.coupons.Find(coupon.couponId);
                                c.remainQ--;
                                entity.SaveChanges();
                            }
                        }
                        try
                        {
                            entity.SaveChanges();
                        }
                        catch { return 0; }
                    }
                }
            }
            return 1;
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
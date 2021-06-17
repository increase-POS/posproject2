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
    [RoutePrefix("api/coupons")]
    public class couponsController : ApiController
    {
        // GET api/<controller> get all coupons
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
                    var couponsList = entity.coupons
                  
                   .Select(c => new CouponModel{
                    cId= c.cId,
                       name =   c.name ,
                       code = c.code,
                       isActive = c.isActive,
                       discountType = c.discountType,
                       discountValue = c.discountValue,
                       startDate =  c.startDate,
                       endDate=c.endDate,
                       notes  =c.notes,
                       quantity  =  c.quantity,
                       remainQ = c.remainQ,
                       invMin  = c.invMin,
                       invMax  = c.invMax ,
                       createDate = c.createDate,
                       updateDate = c.updateDate ,
                       createUserId=  c.createUserId,
                       updateUserId =  c.updateUserId ,
                       barcode = c.barcode,
                   })
                   .ToList();

                    // can delet or not
                    if (couponsList.Count > 0)
                    {
                        foreach(CouponModel couponitem  in couponsList)
                        {
                            canDelete = false;
                            if (couponitem.isActive == 1)
                            {
                                int cId = (int)couponitem.cId;
                                var copinv = entity.couponsInvoices.Where(x => x.couponId == cId).Select(x => new { x.id }).FirstOrDefault();
                      
                                if ((copinv is null) )
                                    canDelete = true;
                            }
                            couponitem.canDelete = canDelete;
                        }
                    }

                    if (couponsList == null)
                        return NotFound();
                    else
                        return Ok(couponsList);
                }
            }
            //else
                return NotFound();
        }



        // GET api/<controller>  Get Coupon By ID 
        [HttpGet]
        [Route("GetCouponByID")]
        public IHttpActionResult GetcouponByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int cId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("cId"))
            {
                cId = Convert.ToInt32(headers.GetValues("cId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var coupon = entity.coupons
                   .Where(c => c.cId == cId)
                   .Select(c => new {
                       c.cId,
                       c.name,
                       c.code,
                       c.isActive,
                       c.discountType,
                       c.discountValue,
                       c.startDate,
                       c.endDate,
                       c.notes,
                       c.quantity,
                       c.remainQ,
                       c.invMin,
                       c.invMax,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,
                       c.barcode,
                   })
                   .FirstOrDefault();

                    if (coupon == null)
                        return NotFound();
                    else
                        return Ok(coupon);
                }
            }
            else
                return NotFound();
        }

        // GET api/<controller>  Get Coupon By Code 
        [HttpGet]
        [Route("GetCouponByCode")]
        public IHttpActionResult GetCouponByCode()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string code = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("code"))
            {
                code = headers.GetValues("code").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var coupon = entity.coupons
                   .Where(c => c.code == code)
                   .Select(c => new {
                       c.cId,
                       c.name,
                       c.code,
                       c.isActive,
                       c.discountType,
                       c.discountValue,
                       c.startDate,
                       c.endDate,
                       c.notes,
                       c.quantity,
                       c.remainQ,
                       c.invMin,
                       c.invMax,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,
                       c.barcode,
                   })
                   .FirstOrDefault();

                    if (coupon == null)
                        return NotFound();
                    else
                        return Ok(coupon);
                }
            }
            else
                return NotFound();
        }

        // GET api/<controller>  Get Coupon By Barcode
        [HttpGet]
        [Route("GetCouponByBarcode")]
        public IHttpActionResult GetcouponByBarcode()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string barcode = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("barcode"))
            {
                barcode = headers.GetValues("barcode").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var coupon = entity.coupons
                   .Where(c => c.barcode == barcode)
                   .Select(c => new {
                       c.cId,
                       c.name,
                       c.code,
                       c.isActive,
                       c.discountType,
                       c.discountValue,
                       c.startDate,
                       c.endDate,
                       c.notes,
                       c.quantity,
                       c.remainQ,
                       c.invMin,
                       c.invMax,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,
                       c.barcode,
                   })
                   .FirstOrDefault();

                    if (coupon == null)
                        return NotFound();
                    else
                        return Ok(coupon);
                }
            }
            else
                return NotFound();
        }

        // GET api/<controller>  Get Coupon By code
        [HttpGet]
        [Route("IsExistcode")]
        public IHttpActionResult IsExistcode(string code)
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
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var coupon = entity.coupons
                   .Where(c => c.code == code)
                   .Select(c => new {
                       c.cId,
                       c.name,
                       c.code,
                   
                       c.barcode,
                   })
                   .FirstOrDefault();

                    if (coupon == null)
                        return NotFound();
                    else
                        return Ok(coupon);
                }
            }
            else
                return NotFound();
        }
        // GET api/<controller>  Get Coupon By is active
        [HttpGet]
        [Route("GetByisActive")]
        public IHttpActionResult GetByisActive()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int isActive = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("isActive"))
            {
                isActive = Convert.ToInt32(headers.GetValues("isActive").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var coupon = entity.coupons
                   .Where(c => c.isActive == isActive)
                   .Select(c => new {
                       c.cId,
                       c.name,
                       c.code,
                       c.isActive,
                       c.discountType,
                       c.discountValue,
                       c.startDate,
                       c.endDate,
                       c.notes,
                       c.quantity,
                       c.remainQ,
                       c.invMin,
                       c.invMax,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,
                   })
                   .ToList();

                    if (coupon == null)
                        return NotFound();
                    else
                        return Ok(coupon);
                }
            }
            else
                return NotFound();
        }


        // add or update coupon 
        [HttpPost]
        [Route("Save")]
        public bool Save(string couponObject)
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
                couponObject = couponObject.Replace("\\", string.Empty);
                couponObject = couponObject.Trim('"');
                coupons Object = JsonConvert.DeserializeObject<coupons>(couponObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var couponEntity = entity.Set<coupons>();
                        if (Object.cId == 0)
                        {

                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            couponEntity.Add(Object);
                          //  message = "coupon Is Added Successfully";
                        }
                        else
                        {

                            var tmpcoupon = entity.coupons.Where(p => p.cId == Object.cId).FirstOrDefault();

                            tmpcoupon.name = Object.name;
                            tmpcoupon.code = Object.code;
                            tmpcoupon.isActive = Object.isActive;
                            tmpcoupon.discountType = Object.discountType;
                            tmpcoupon.discountValue = Object.discountValue;
                            tmpcoupon.startDate = Object.startDate;
                            tmpcoupon.endDate = Object.endDate;
                            tmpcoupon.notes = Object.notes;
                            tmpcoupon.quantity = Object.quantity;
                            tmpcoupon.remainQ = Object.remainQ;
                            tmpcoupon.invMin = Object.invMin;
                            tmpcoupon.invMax = Object.invMax;
                         
                            tmpcoupon.updateDate = DateTime.Now;// server current date;
                           
                            tmpcoupon.updateUserId = Object.updateUserId;
                            tmpcoupon.barcode = Object.barcode;


                            //message = "coupon Is Updated Successfully";
                        }
                        entity.SaveChanges();
                    }
                    return true;
                }

                catch
                {
                    return false;
                }
            }
            else
                return false;
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int couponId, int userId, Boolean final)
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
                            coupons couponObj = entity.coupons.Find(couponId);

                            entity.coupons.Remove(couponObj);
                            entity.SaveChanges();

                            return Ok("Coup is Deleted Successfully");
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
                            coupons coupObj = entity.coupons.Find(couponId);

                            coupObj.isActive = 0;
                            coupObj.updateUserId = userId;
                            coupObj.updateDate = DateTime.Now;
                            entity.SaveChanges();

                            return Ok("Offer is Deleted Successfully");
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
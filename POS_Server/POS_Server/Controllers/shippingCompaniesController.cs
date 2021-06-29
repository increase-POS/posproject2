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
    [RoutePrefix("api/ShippingCompanies")]
    public class ShippingCompaniesController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            bool canDelete = false;

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
                    var List = (from S in  entity.shippingCompanies                                         
                                         select new ShippingCompaniesModel()
                                         {
                                            shippingCompanyId=S.shippingCompanyId,
                                            name=S.name,
                                            RealDeliveryCost=S.RealDeliveryCost,
                                            deliveryCost=S.deliveryCost,
                                            deliveryType=S.deliveryType,
                                            notes=S.notes,
                                            isActive=S.isActive,
                                            createDate = S.createDate,
                                            updateDate = S.updateDate,
                                            createUserId = S.createUserId,
                                            updateUserId=S.updateUserId,
                                            

                                         }).ToList();
                    /*
 public int membershipId { get; set; }
        public string name { get; set; }
        public Nullable<decimal> deliveryDiscount { get; set; }
        public string deliveryDiscountType { get; set; }
        public Nullable<decimal> invoiceDiscount { get; set; }
        public string invoiceDiscountType { get; set; }
        public Nullable<decimal> subscriptionFee { get; set; }
        public string notes { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<byte> isActive { get; set; }
        public bool canDelete { get; set; }


                    */

                    if (List.Count > 0)
                    {
                        for (int i = 0; i < List.Count; i++)
                        {
                            if (List[i].isActive == 1)
                            {
                                int shippingCompanyId = (int)List[i].shippingCompanyId;
                                var itemsI= entity.invoices.Where(x => x.shippingCompanyId == shippingCompanyId).Select(b => new { b.invoiceId }).FirstOrDefault();
                               
                                if ((itemsI is null)  )
                                    canDelete = true;
                            }
                            List[i].canDelete = canDelete;
                        }
                    }

                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            //else
            return NotFound();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetByID")]
        public IHttpActionResult GetByID(int shippingCompanyId)
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
                          

                   })
                   .FirstOrDefault();

                    if (row == null)
                        return NotFound();
                    else
                        return Ok(row);
                }
            }
            else
                return NotFound();
        }

        // add or update location
        [HttpPost]
        [Route("Save")]
        public string Save(string Object)
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
                Object = Object.Replace("\\", string.Empty);
                Object = Object.Trim('"');
                shippingCompanies newObject = JsonConvert.DeserializeObject<shippingCompanies>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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

                            tmpObject.name  =newObject.name;
                            tmpObject.RealDeliveryCost  =newObject.RealDeliveryCost;
                            tmpObject.deliveryCost  =newObject.deliveryCost;
                            tmpObject.deliveryType  =newObject.deliveryType;
                            tmpObject.notes  =newObject.notes;
                            tmpObject.isActive=newObject.isActive;
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
            return message;
        }

        [HttpPost]
        [Route("Delete")]
        public string Delete(int shippingCompanyId, int userId,bool final)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int message = 0;
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
                            shippingCompanies objectDelete = entity.shippingCompanies.Find(shippingCompanyId);

                            entity.shippingCompanies.Remove(objectDelete);
                        message=    entity.SaveChanges();
                          
                            return message.ToString();
                        }
                    }
                    catch
                    {
                        return "-1";
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
                            message= entity.SaveChanges();

                            return message.ToString(); ;
                        }
                    }
                    catch
                    {
                        return "-2";
                    }
                }
            }
            else
                return "-3";
        }



    }
}
using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POS_Server.Models.VM;
using System.Security.Claims;
using System.Web;
using Newtonsoft.Json.Converters;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/ItemsTransfer")]
    public class ItemsTransferController : ApiController
    {
        [HttpPost]
        [Route("Get")]
        public string Get(string token)
        {
            //int invoiceId

            // public string GetUsersByGroupId(string token)
          token = TokenManager.readToken(HttpContext.Current.Request);var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int invoiceId = 0;


                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        invoiceId = int.Parse(c.Value);
                    }


                }

                // DateTime cmpdate = DateTime.Now.AddDays(newdays);
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var transferList = (from t in entity.itemsTransfer.Where(x => x.invoiceId == invoiceId)
                                            join u in entity.itemsUnits on t.itemUnitId equals u.itemUnitId
                                            join i in entity.items on u.itemId equals i.itemId
                                            join un in entity.units on u.unitId equals un.unitId
                                            join inv in entity.invoices on t.invoiceId equals inv.invoiceId
                                            select new ItemTransferModel()
                                            {
                                                itemsTransId = t.itemsTransId,
                                                itemId = i.itemId,
                                                itemName = i.name,
                                                quantity = t.quantity,
                                                invoiceId = entity.invoiceOrder.Where(x => x.itemsTransferId == t.itemsTransId).Select(x => x.orderId).FirstOrDefault(),
                                                invNumber = inv.invNumber,
                                                locationIdNew = t.locationIdNew,
                                                locationIdOld = t.locationIdOld,
                                                createUserId = t.createUserId,
                                                updateUserId = t.updateUserId,
                                                notes = t.notes,
                                                createDate = t.createDate,
                                                updateDate = t.updateDate,
                                                itemUnitId = u.itemUnitId,
                                                price = t.price,
                                                unitName = un.name,
                                                unitId = un.unitId,
                                                barcode = u.barcode,
                                                itemSerial = t.itemSerial,
                                                itemType = i.type,
                                            })
                                            .ToList();

                        return TokenManager.GenerateToken(transferList);
                    }

                    }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }
            }


            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}

            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid)
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var transferList = (from t in entity.itemsTransfer.Where(x => x.invoiceId == invoiceId)
            //                            join u in entity.itemsUnits on t.itemUnitId equals u.itemUnitId
            //                            join i in entity.items on u.itemId equals i.itemId
            //                            join un in entity.units on u.unitId equals un.unitId
            //                            join inv in entity.invoices on t.invoiceId equals inv.invoiceId
            //                            select new ItemTransferModel()
            //                            {
            //                                itemsTransId = t.itemsTransId,
            //                                itemId = i.itemId,
            //                                itemName = i.name,
            //                                quantity = t.quantity,
            //                                invoiceId = entity.invoiceOrder.Where(x=> x.itemsTransferId == t.itemsTransId).Select(x=> x.orderId).FirstOrDefault(),
            //                                invNumber = inv.invNumber,
            //                                locationIdNew = t.locationIdNew,
            //                                locationIdOld = t.locationIdOld,
            //                                createUserId = t.createUserId,
            //                                updateUserId = t.updateUserId,
            //                                notes = t.notes,
            //                                createDate = t.createDate,
            //                                updateDate = t.updateDate,
            //                                itemUnitId = u.itemUnitId,
            //                                price = t.price,
            //                                unitName = un.name,
            //                                unitId = un.unitId,
            //                                barcode = u.barcode,
            //                                itemSerial = t.itemSerial,
            //                                itemType = i.type,
            //                            })
            //                            .ToList();
            //        if (transferList == null)
            //            return NotFound();
            //        else
            //            return Ok(transferList);

            //    }
            //}
            //else
            //    return NotFound();
        }

        // add or update item transfer
        [HttpPost]
        [Route("Save")]
        public string Save(string token)
        {
            string message = "";

          token = TokenManager.readToken(HttpContext.Current.Request); 
 var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int invoiceId = 0;
                string Object = "";
                List<itemsTransfer> newObject = new List<itemsTransfer>();
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemTransferObject")
                    {
                        Object = c.Value.Replace("\\", string.Empty);
                        Object = Object.Trim('"');
                        newObject = JsonConvert.DeserializeObject<List<itemsTransfer>>(Object, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    }
                    else if (c.Type == "invoiceId")
                    {
                        invoiceId = int.Parse(c.Value);
                    }
                }
                if (newObject != null)
                {

                    try
                    {
                        // delete old invoice items
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            List<invoiceOrder> iol = entity.invoiceOrder.Where(x => x.invoiceId == invoiceId).ToList();
                            entity.invoiceOrder.RemoveRange(iol);
                            entity.SaveChanges();

                            List<itemsTransfer> items = entity.itemsTransfer.Where(x => x.invoiceId == invoiceId).ToList();
                            entity.itemsTransfer.RemoveRange(items);
                            entity.SaveChanges();

                            for (int i = 0; i < newObject.Count; i++)
                            {
                                itemsTransfer t;
                                if (newObject[i].updateUserId == 0 || newObject[i].updateUserId == null)
                                {
                                    Nullable<int> id = null;
                                    newObject[i].updateUserId = id;
                                }
                                if (newObject[i].createUserId == 0 || newObject[i].createUserId == null)
                                {
                                    Nullable<int> id = null;
                                    newObject[i].createUserId = id;
                                }
                                if (newObject[i].itemSerial == null)
                                    newObject[i].itemSerial = "";

                                var transferEntity = entity.Set<itemsTransfer>();
                                int orderId = (int)newObject[i].invoiceId;
                                newObject[i].invoiceId = invoiceId;
                                newObject[i].createDate = DateTime.Now;
                                newObject[i].updateDate = DateTime.Now;
                                newObject[i].updateUserId = newObject[i].createUserId;
                      
                            t = entity.itemsTransfer.Add(newObject[i]);
                                entity.SaveChanges();
                                if (orderId != 0)
                                {
                                    invoiceOrder invoiceOrder = new invoiceOrder()
                                    {
                                        invoiceId = invoiceId,
                                        orderId = orderId,
                                        quantity = (int)newObject[i].quantity,
                                        itemsTransferId = t.itemsTransId,
                                    };
                                    entity.invoiceOrder.Add(invoiceOrder);
                                }
                            }
                            //try
                            //{
                            entity.SaveChanges();
                        message = "1";
                            return TokenManager.GenerateToken(message);
                            //}
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
                    return TokenManager.GenerateToken("0");
                }


            }


            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //itemTransferObject = itemTransferObject.Replace("\\", string.Empty);
            //itemTransferObject = itemTransferObject.Trim('"');

            //List< itemsTransfer> transferObj = JsonConvert.DeserializeObject<List<itemsTransfer>>(itemTransferObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

            //if (valid)
            //{
            //    // delete old invoice items
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        List<invoiceOrder> iol = entity.invoiceOrder.Where(x => x.invoiceId == invoiceId).ToList();
            //        entity.invoiceOrder.RemoveRange(iol);
            //        entity.SaveChanges();

            //        List<itemsTransfer> items = entity.itemsTransfer.Where(x => x.invoiceId == invoiceId).ToList();
            //        entity.itemsTransfer.RemoveRange(items);
            //        entity.SaveChanges(); 

            //        for (int i = 0; i < transferObj.Count; i++)
            //        {
            //            itemsTransfer t;
            //            if (transferObj[i].updateUserId == 0 || transferObj[i].updateUserId == null)
            //            {
            //                Nullable<int> id = null;
            //                transferObj[i].updateUserId = id;
            //            }
            //            if (transferObj[i].createUserId == 0 || transferObj[i].createUserId == null)
            //            {
            //                Nullable<int> id = null;
            //                transferObj[i].createUserId = id;
            //            }
            //            if (transferObj[i].itemSerial == null)
            //                transferObj[i].itemSerial = "";

            //            var transferEntity = entity.Set<itemsTransfer>();
            //            int orderId = (int)transferObj[i].invoiceId;
            //            transferObj[i].invoiceId = invoiceId;
            //            transferObj[i].createDate = DateTime.Now;
            //            transferObj[i].updateDate = DateTime.Now;
            //            transferObj[i].updateUserId = transferObj[i].createUserId;

            //           t = entity.itemsTransfer.Add(transferObj[i]);
            //            entity.SaveChanges();
            //            if ( orderId != 0)
            //                {
            //                    invoiceOrder invoiceOrder = new invoiceOrder()
            //                    {
            //                        invoiceId = invoiceId,
            //                        orderId = orderId,
            //                        quantity = (int)transferObj[i].quantity,
            //                        itemsTransferId = t.itemsTransId,
            //                    };
            //                    entity.invoiceOrder.Add(invoiceOrder);
            //                }
            //        }
            //        //try
            //        //{
            //            entity.SaveChanges();
            //        //}

            //        //catch
            //        //{
            //        //    return false;
            //        //}
            //    }

            //}

            //return true;
        }

    }
}
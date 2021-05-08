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
    [RoutePrefix("api/ItemsTransfer")]
    public class ItemsTransferController : ApiController
    {
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

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var transferList = (from t in entity.itemsTransfer.Where(x => x.invoiceId == invoiceId)
                                        join i in entity.items on t.itemId equals i.itemId
                                        join inv in entity.invoices on t.invoiceId  equals inv.invoiceId
                                        select new ItemTransferModel()
                                        {
                                            itemsTransId = t.itemsTransId,
                                            itemId = t.itemId,
                                            itemName = i.name,
                                            quantity = t.quantity,
                                            type = t.type,
                                            invoiceId = t.invoiceId,
                                            invNumber = inv.invNumber,
                                            locationIdNew = t.locationIdNew,
                                            locationIdOld = t.locationIdOld,
                                            createUserId = t.createUserId,
                                            updateUserId = t.updateUserId,
                                            notes = t.notes,
                                            createDate = t.createDate,
                                            updateDate = t.updateDate,
                                        })
                                        .ToList();
                    if (transferList == null)
                        return NotFound();
                    else
                        return Ok(transferList);

                }
            }
            else
                return NotFound();
        }
        // add or update item transfer
        [HttpPost]
        [Route("Save")]
        public bool Save(string itemTransferObject)
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

            itemTransferObject = itemTransferObject.Replace("\\", string.Empty);
            itemTransferObject = itemTransferObject.Trim('"');

            itemsTransfer transferObj = JsonConvert.DeserializeObject<itemsTransfer>(itemTransferObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (transferObj.updateUserId == 0 || transferObj.updateUserId == null)
            {
                Nullable<int> id = null;
                transferObj.updateUserId = id;
            }
            if (transferObj.createUserId == 0 || transferObj.createUserId == null)
            {
                Nullable<int> id = null;
                transferObj.createUserId = id;
            }
            if (valid)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var transferEntity = entity.Set<itemsTransfer>();
                        if (transferObj.itemsTransId == 0)
                        {
                            transferObj.createDate = DateTime.Now;
                            transferObj.updateDate = DateTime.Now;
                            transferObj.updateUserId = transferObj.createUserId;

                            transferEntity.Add(transferObj);
                        }
                        else
                        {
                            var tmpTransfer = entity.itemsTransfer.Where(p => p.itemsTransId == transferObj.itemsTransId).First();
                            tmpTransfer.itemId = transferObj.itemId;
                            tmpTransfer.quantity = transferObj.quantity;
                            tmpTransfer.type = transferObj.type;
                            tmpTransfer.locationIdNew = transferObj.locationIdNew;
                            tmpTransfer.locationIdOld = transferObj.locationIdOld;
                            tmpTransfer.notes = transferObj.notes;
                            tmpTransfer.updateDate = DateTime.Now;
                            tmpTransfer.updateUserId = transferObj.updateUserId;
                            
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
    }
}
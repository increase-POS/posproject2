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
    [RoutePrefix("api/bonds")]
    public class BondsController : ApiController
    {
        // GET api/<controller> get all bonds
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
                List<BondsModel> listb = new List<BondsModel>();
                List<BondsModel> listb2 = new List<BondsModel>();
            
                using (incposdbEntities entity = new incposdbEntities())
                {
                    listb = (// from C in entity.cashTransfer
                       from bo in entity.bondes
                       from C in entity.cashTransfer.Where(c => c.bondId == bo.bondId)
                           // join C in entity.cashTransfer on bo.bondId equals C.bondId into jc
                   join b in entity.banks on C.bankId equals b.bankId into jb
                       join a in entity.agents on C.agentId equals a.agentId into ja
                       join p in entity.pos on C.posId equals p.posId into jp
                       join pc in entity.pos on C.posIdCreator equals pc.posId into jpcr
                       join u in entity.users on C.userId equals u.userId into ju
                       join uc in entity.users on C.createUserId equals uc.userId into juc
                       join cr in entity.cards on C.cardId equals cr.cardId into jcr
                       join sh in entity.shippingCompanies on C.shippingCompanyId equals sh.shippingCompanyId into jsh

                       //  join b in entity.bondes on C.bondId  equals b.bondId  into jb


                       from jbb in jb.DefaultIfEmpty()
                       from jaa in ja.DefaultIfEmpty()
                       from jpp in jp.DefaultIfEmpty()
                       from juu in ju.DefaultIfEmpty()
                       from jpcc in jpcr.DefaultIfEmpty()
                       from jucc in juc.DefaultIfEmpty()
                       from jcrd in jcr.DefaultIfEmpty()
                       from jshd in jsh.DefaultIfEmpty()
                       where (C.side != "bnd")
                   // from jc in C.DefaultIfEmpty()
                   //   where C.bondId==jbbo.bondId 
                   orderby bo.bondId
                       select new BondsModel
                       {

                           bondId = bo.bondId,
                           number = bo.number,
                           amount = bo.amount,
                           deserveDate = bo.deserveDate,
                           type = bo.type,
                           isRecieved = bo.isRecieved,
                           notes = bo.notes,

                           createDate = bo.createDate,
                           updateDate = bo.updateDate,
                           createUserId = bo.createUserId,
                           updateUserId = bo.updateUserId,
                           isActive = bo.isActive,
                           cashTransId = bo.cashTransId,
                       // cash trans

                       ctcashTransId = C.cashTransId,
                           cttransType = C.transType,
                           ctposId = C.posId,
                           ctuserId = C.userId,
                           ctagentId = C.agentId,
                           ctinvId = C.invId,
                           cttransNum = C.transNum,
                           ctcreateDate = C.createDate,
                           ctupdateDate = C.updateDate,
                           ctcash = C.cash,
                           ctupdateUserId = C.updateUserId,
                           ctcreateUserId = C.createUserId,
                           ctnotes = C.notes,
                           ctposIdCreator = C.posIdCreator,
                           ctisConfirm = C.isConfirm,
                           ctcashTransIdSource = C.cashTransIdSource,
                           ctside = C.side,
                           ctdocName = C.docName,
                           ctdocNum = C.docNum,
                           ctdocImage = C.docImage,
                           ctbankId = C.bankId,

                           ctprocessType = C.processType,
                           ctcardId = C.cardId,
                           ctbondId = C.bondId,
                       // other tables

                       ctbankName = jbb.name,
                           ctagentName = jaa.name,
                           ctusersName = juu.name,
                           ctusersLName = jpp.name,
                           ctposName = jpp.name,
                           ctposCreatorName = jpcc.name,

                           ctcreateUserName = jucc.name,
                           ctcreateUserJob = jucc.job,
                           ctcreateUserLName = jucc.lastname,
                           ctcardName = jcrd.name,
                          
                           ctshippingCompanyId = jshd.shippingCompanyId,
                           ctshippingCompanyName = jshd.name
                       }).ToList();


                    // can delet or not
                    if (listb.Count > 0)
                    {
                        foreach (BondsModel bonditem in listb)
                        {
                            canDelete = false;
                            if (bonditem.isActive == 1)
                            {
                                int cId = (int)bonditem.bondId;
                                var casht = entity.cashTransfer.Where(x => x.bondId == cId).Select(x => new { x.bondId }).FirstOrDefault();

                                if ((casht is null))
                                    canDelete = true;
                            }
                            bonditem.canDelete = canDelete;
                        }

                        listb2 = listb.GroupBy(X => X.bondId).Select(x => new BondsModel
                        {
                            bondId = x.FirstOrDefault().bondId,
                            number = x.FirstOrDefault().number,
                            amount = x.FirstOrDefault().amount,
                            deserveDate = x.FirstOrDefault().deserveDate,
                            type = x.FirstOrDefault().type,
                            isRecieved = x.FirstOrDefault().isRecieved,
                            notes = x.FirstOrDefault().notes,

                            createDate = x.FirstOrDefault().createDate,
                            updateDate = x.FirstOrDefault().updateDate,
                            createUserId = x.FirstOrDefault().createUserId,
                            updateUserId = x.FirstOrDefault().updateUserId,
                            isActive = x.FirstOrDefault().isActive,
                            cashTransId = x.FirstOrDefault().cashTransId,
                            // cash trans

                            ctcashTransId = x.FirstOrDefault().ctcashTransId,
                            cttransType = x.FirstOrDefault().cttransType,
                            ctposId = x.FirstOrDefault().ctposId,
                            ctuserId = x.FirstOrDefault().ctuserId,
                            ctagentId = x.FirstOrDefault().ctagentId,
                            ctinvId = x.FirstOrDefault().ctinvId,
                            cttransNum = x.FirstOrDefault().cttransNum,
                            ctcreateDate = x.FirstOrDefault().ctcreateDate,
                            ctupdateDate = x.FirstOrDefault().ctupdateDate,
                            ctcash = x.FirstOrDefault().ctcash,
                            ctupdateUserId = x.FirstOrDefault().ctupdateUserId,
                            ctcreateUserId = x.FirstOrDefault().ctcreateUserId,
                            ctnotes = x.FirstOrDefault().ctnotes,
                            ctposIdCreator = x.FirstOrDefault().ctposIdCreator,
                            ctisConfirm = x.FirstOrDefault().ctisConfirm,
                            ctcashTransIdSource = x.FirstOrDefault().ctcashTransIdSource,
                            ctside = x.FirstOrDefault().ctside,
                            ctdocName = x.FirstOrDefault().ctdocName,
                            ctdocNum = x.FirstOrDefault().ctdocNum,
                            ctdocImage = x.FirstOrDefault().ctdocImage,
                            ctbankId = x.FirstOrDefault().ctbankId,

                            ctprocessType = x.FirstOrDefault().ctprocessType,
                            ctcardId = x.FirstOrDefault().ctcardId,
                            ctbondId = x.FirstOrDefault().ctbondId,
                            // other tables

                            ctbankName = x.FirstOrDefault().ctbankName,
                            ctagentName = x.FirstOrDefault().ctagentName,
                            ctusersName = x.FirstOrDefault().ctusersName,
                            ctusersLName = x.FirstOrDefault().ctusersLName,
                            ctposName = x.FirstOrDefault().ctposName,
                            ctposCreatorName = x.FirstOrDefault().ctposCreatorName,

                            ctcreateUserName = x.FirstOrDefault().ctcreateUserName,
                            ctcreateUserJob = x.FirstOrDefault().ctcreateUserJob,
                            ctcreateUserLName = x.FirstOrDefault().ctcreateUserLName,
                            ctcardName = x.FirstOrDefault().ctcardName,
                            ctshippingCompanyId =  x.FirstOrDefault().ctshippingCompanyId,
                            ctshippingCompanyName = x.FirstOrDefault().ctshippingCompanyName

                        }).ToList();

                    }

                    /*
  

       * */
                    if (listb2 == null)
                        return NotFound();
                    else
                        return Ok(listb2);
                }
            }
            //else
                return NotFound();
        }



        // GET api/<controller>  Get card By ID 
        [HttpGet]
        [Route("GetbondByID")]
        public IHttpActionResult GetcardByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int cId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("bondId"))
            {
                cId = Convert.ToInt32(headers.GetValues("bondId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var bond = entity.bondes
                   .Where(c => c.bondId == cId)
                   .Select(c => new {
                        c.bondId,
                        c.number,
                        c.amount,
                        c.deserveDate,
                        c.type,
                        c.isRecieved,
                        c.notes,
                        c.createDate,
                        c.updateDate,
                        c.createUserId,
                        c.updateUserId,
                        c.isActive,
                      c.cashTransId,

                   })
                   .FirstOrDefault();

      

                    if (bond == null)
                        return NotFound();
                    else
                        return Ok(bond);
                }
            }
            else
                return NotFound();
        }

   


    
        // GET api/<controller>  Get card By is active
        [HttpGet]
        [Route("GetByisActive")]
        public IHttpActionResult GetByisActive(byte isActive)
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
                    var card = entity.bondes
                   .Where(c => c.isActive == isActive)
                   .Select(c => new {
                       c.bondId,
                       c.number,
                       c.amount,
                       c.deserveDate,
                       c.type,
                       c.isRecieved,
                       c.notes,
                       c.createDate,
                       c.updateDate,
                       c.createUserId,
                       c.updateUserId,
                       c.isActive,
                     c.cashTransId,
                   })
                   .ToList();

                    if (card == null)
                        return NotFound();
                    else
                        return Ok(card);
                }
            }
            else
                return NotFound();
        }


        // add or update card 
        [HttpPost]
        [Route("Save")]
        public string Save(string bondObject)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
           string  message = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            
            if (valid)
            {
                bondObject = bondObject.Replace("\\", string.Empty);
                bondObject = bondObject.Trim('"');
                bondes Object = JsonConvert.DeserializeObject<bondes>(bondObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var bondEntity = entity.Set<bondes>();
                        if (Object.bondId == 0 || Object.bondId == null)
                        {

                            Object.createDate = DateTime.Now;
                            Object.updateDate = DateTime.Now;
                            Object.updateUserId = Object.createUserId;
                            bondEntity.Add(Object);
                            entity.SaveChanges();
                            message = Object.bondId.ToString();
                        }
                        else
                        {

                            var tmpbond = entity.bondes.Where(p => p.bondId == Object.bondId).FirstOrDefault();
              
                    tmpbond.bondId = Object.bondId;
                    tmpbond.number = Object.number;
                    tmpbond.amount = Object.amount ;
                    tmpbond.deserveDate = Object.deserveDate;
                    tmpbond.type = Object.type;
                    tmpbond.isRecieved = Object.isRecieved;
                    tmpbond.notes = Object.notes;
                    tmpbond.createDate = Object.createDate;
                    tmpbond.updateDate = DateTime.Now;// server current date;
                    tmpbond.createUserId = Object.createUserId;
                    tmpbond.updateUserId = Object.updateUserId;
                    tmpbond.isActive = Object.isActive;
                            tmpbond.cashTransId = Object.cashTransId;

                            //message = "card Is Updated Successfully";
                    entity.SaveChanges();
                    message = tmpbond.bondId.ToString();
                  
                        }
                       
                      
                    }
                    return message;
                }

                catch
                {
                    return "-1";
                }
            }
            else
                return "-1";
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int bondId, int userId, Boolean final)
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
                            bondes bondObj = entity.bondes.Find(bondId);

                            entity.bondes.Remove(bondObj);
                            entity.SaveChanges();

                            return Ok("card is Deleted Successfully");
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
                            bondes Obj = entity.bondes.Find(bondId);

                            Obj.isActive = 0;
                            Obj.updateUserId = userId;
                            Obj.updateDate = DateTime.Now;
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
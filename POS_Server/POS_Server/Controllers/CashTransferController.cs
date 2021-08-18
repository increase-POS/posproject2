using LinqKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Cashtransfer")]
    public class CashTransferController : ApiController
    {


        [HttpGet]
        [Route("GetBytypeandSide")]
        public IHttpActionResult GetBytypeAndSide(string type, string side)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";

            /*
            string type = "";
            string side = "";
            */
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }



            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            /*
             *   cashTransId = ,
                      transType = ,
                      posId = ,
                      userId = ,
                      agentId = ,
                      invId = ,
                      transNum = ,
                      createDate = ,
                      updateDate = ,
                      cash = ,
                      updateUserId = ,
                      createUserId = ,
                      notes = ,
                      posIdCreator = ,
                     isConfirm = ,
                      cashTransIdSource = ,
                      side = ,
                      opSideNum = ,
                      docName = ,
                      docNum = ,
                      docImage = ,
                      bankId = ,
             * */
            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    /*
                     var cachlist =  entity.cashTransfer

       .Where(C => ((type == "all") ? true : C.transType == type)
              && ((side == "all") ? true : C.side == side))

         .Select(C => new CashTransferModel
                         {                           
           cashTransId = C.cashTransId,
           transType = C.transType,
           posId = C.posId,
           userId =C.userId,
           agentId =C.agentId,
           invId =C.invId,
           transNum =C.transNum,
           createDate = C.createDate,
           updateDate =C.updateDate,
           cash =C.cash,
           updateUserId =C.updateUserId,
           createUserId =C.createUserId,
           notes =C.notes,
           posIdCreator = C.posIdCreator,
          isConfirm =C.isConfirm,
           cashTransIdSource =C.cashTransIdSource,
           side =C.side,
           opSideNum =C.opSideNum,
           docName =C.docName,
           docNum =C.docNum,
           docImage =C.docImage,
           bankId =C.bankId,

     }).ToList();
                     */
                    List<CashTransferModel> cachlist = (from C in entity.cashTransfer
                                                        join b in entity.banks on C.bankId equals b.bankId into jb
                                                        join a in entity.agents on C.agentId equals a.agentId into ja
                                                        join p in entity.pos on C.posId equals p.posId into jp
                                                        join pc in entity.pos on C.posIdCreator equals pc.posId into jpcr
                                                        join u in entity.users on C.userId equals u.userId into ju
                                                        join uc in entity.users on C.createUserId equals uc.userId into juc
                                                        join cr in entity.cards on C.cardId equals cr.cardId into jcr
                                                        join bo in entity.bondes on C.bondId equals bo.bondId into jbo
                                                        join sh in entity.shippingCompanies on C.shippingCompanyId equals sh.shippingCompanyId into jsh
                                                        from jbb in jb.DefaultIfEmpty()
                                                        from jaa in ja.DefaultIfEmpty()
                                                        from jpp in jp.DefaultIfEmpty()
                                                        from juu in ju.DefaultIfEmpty()
                                                        from jpcc in jpcr.DefaultIfEmpty()
                                                        from jucc in juc.DefaultIfEmpty()
                                                        from jcrd in jcr.DefaultIfEmpty()
                                                        from jbbo in jbo.DefaultIfEmpty()
                                                        from jssh in jsh.DefaultIfEmpty()
                                                        select new CashTransferModel()
                                                        {
                                                            cashTransId = C.cashTransId,
                                                            transType = C.transType,
                                                            posId = C.posId,
                                                            userId = C.userId,
                                                            agentId = C.agentId,
                                                            invId = C.invId,
                                                            transNum = C.transNum,
                                                            createDate = C.createDate,
                                                            updateDate = C.updateDate,
                                                            cash = C.cash,
                                                            updateUserId = C.updateUserId,
                                                            createUserId = C.createUserId,
                                                            notes = C.notes,
                                                            posIdCreator = C.posIdCreator,
                                                            isConfirm = C.isConfirm,
                                                            cashTransIdSource = C.cashTransIdSource,
                                                            side = C.side,

                                                            docName = C.docName,
                                                            docNum = C.docNum,
                                                            docImage = C.docImage,
                                                            bankId = C.bankId,
                                                            bankName = jbb.name,
                                                            agentName = jaa.name,
                                                            usersName = juu.name,// side =u

                                                            posName = jpp.name,
                                                            posCreatorName = jpcc.name,
                                                            processType = C.processType,
                                                            cardId = C.cardId,
                                                            bondId = C.bondId,
                                                            usersLName = juu.lastname,// side =u
                                                            createUserName = jucc.name,
                                                            createUserLName = jucc.lastname,
                                                            createUserJob = jucc.job,
                                                            cardName = jcrd.name,
                                                            bondDeserveDate = jbbo.deserveDate,
                                                            bondIsRecieved = jbbo.isRecieved,
                                                            shippingCompanyId = C.shippingCompanyId,
                                                            shippingCompanyName = jssh.name

                                                        }).Where(C => ((type == "all") ? true : C.transType == type)
            && ((side == "all") ? true : C.side == side) && !(C.agentId == null && C.userId == null && C.shippingCompanyId == null)).ToList();

                    if (cachlist.Count > 0 && side == "p")
                    {
                        CashTransferModel tempitem = null;
                        foreach (CashTransferModel cashtItem in cachlist)
                        {
                            tempitem = this.Getpostransmodel(cashtItem.cashTransId)
                                .Where(C => C.cashTransId != cashtItem.cashTransId).FirstOrDefault();
                            cashtItem.cashTrans2Id = tempitem.cashTransId;
                            cashtItem.pos2Id = tempitem.posId;
                            cashtItem.pos2Name = tempitem.posName;
                            cashtItem.isConfirm2 = tempitem.isConfirm;
                            // cashtItem.posCreatorName = tempitem.posName;


                        }

                    }




                    if (cachlist == null)
                        return NotFound();
                    else
                        return Ok(cachlist);

                }
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetBytypeAndSideForPos")]
        public IHttpActionResult GetBytypeAndSideForPos(string type, string side)
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
                    List<CashTransferModel> cachlist = (from C in entity.cashTransfer
                                                        join b in entity.banks on C.bankId equals b.bankId into jb
                                                        join a in entity.agents on C.agentId equals a.agentId into ja
                                                        join p in entity.pos on C.posId equals p.posId into jp
                                                        join pc in entity.pos on C.posIdCreator equals pc.posId into jpcr
                                                        join u in entity.users on C.userId equals u.userId into ju
                                                        join uc in entity.users on C.createUserId equals uc.userId into juc
                                                        join cr in entity.cards on C.cardId equals cr.cardId into jcr
                                                        join bo in entity.bondes on C.bondId equals bo.bondId into jbo
                                                        join sh in entity.shippingCompanies on C.shippingCompanyId equals sh.shippingCompanyId into jsh
                                                        from jbb in jb.DefaultIfEmpty()
                                                        from jaa in ja.DefaultIfEmpty()
                                                        from jpp in jp.DefaultIfEmpty()
                                                        from juu in ju.DefaultIfEmpty()
                                                        from jpcc in jpcr.DefaultIfEmpty()
                                                        from jucc in juc.DefaultIfEmpty()
                                                        from jcrd in jcr.DefaultIfEmpty()
                                                        from jbbo in jbo.DefaultIfEmpty()
                                                        from jssh in jsh.DefaultIfEmpty()
                                                        select new CashTransferModel()
                                                        {
                                                            cashTransId = C.cashTransId,
                                                            transType = C.transType,
                                                            posId = C.posId,
                                                            userId = C.userId,
                                                            agentId = C.agentId,
                                                            invId = C.invId,
                                                            transNum = C.transNum,
                                                            createDate = C.createDate,
                                                            updateDate = C.updateDate,
                                                            cash = C.cash,
                                                            updateUserId = C.updateUserId,
                                                            createUserId = C.createUserId,
                                                            notes = C.notes,
                                                            posIdCreator = C.posIdCreator,
                                                            isConfirm = C.isConfirm,
                                                            cashTransIdSource = C.cashTransIdSource,
                                                            side = C.side,

                                                            docName = C.docName,
                                                            docNum = C.docNum,
                                                            docImage = C.docImage,
                                                            bankId = C.bankId,
                                                            bankName = jbb.name,
                                                            agentName = jaa.name,
                                                            usersName = juu.name,// side =u

                                                            posName = jpp.name,
                                                            posCreatorName = jpcc.name,
                                                            processType = C.processType,
                                                            cardId = C.cardId,
                                                            bondId = C.bondId,
                                                            usersLName = juu.lastname,// side =u
                                                            createUserName = jucc.name,
                                                            createUserLName = jucc.lastname,
                                                            createUserJob = jucc.job,
                                                            cardName = jcrd.name,
                                                            bondDeserveDate = jbbo.deserveDate,
                                                            bondIsRecieved = jbbo.isRecieved,
                                                            shippingCompanyId = C.shippingCompanyId,
                                                            shippingCompanyName = jssh.name

                                                        }).Where(C => ((type == "all") ? true : C.transType == type)
            && ((side == "all") ? true : C.side == side)).ToList();

                    if (cachlist.Count > 0 && side == "p")
                    {
                        CashTransferModel tempitem = null;
                        foreach (CashTransferModel cashtItem in cachlist)
                        {
                            tempitem = this.Getpostransmodel(cashtItem.cashTransId)
                                .Where(C => C.cashTransId != cashtItem.cashTransId).FirstOrDefault();
                            cashtItem.cashTrans2Id = tempitem.cashTransId;
                            cashtItem.pos2Id = tempitem.posId;
                            cashtItem.pos2Name = tempitem.posName;
                            cashtItem.isConfirm2 = tempitem.isConfirm;

                        }

                    }




                    if (cachlist == null)
                        return NotFound();
                    else
                        return Ok(cachlist);

                }
            }
            else
                return NotFound();
        }

        // get by bondId
        [HttpGet]
        [Route("GetBybondId")]
        public IHttpActionResult GetBybondId(int bondId)
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
   
                    List<CashTransferModel> cachlist = (from C in entity.cashTransfer
                                                        where C.bondId==bondId
                                                        select new CashTransferModel()
                                                        {
                                                            cashTransId = C.cashTransId,
                                                            transType = C.transType,
                                                            posId = C.posId,
                                                            userId = C.userId,
                                                            agentId = C.agentId,
                                                            invId = C.invId,
                                                            transNum = C.transNum,
                                                            createDate = C.createDate,
                                                            updateDate = C.updateDate,
                                                            cash = C.cash,
                                                            updateUserId = C.updateUserId,
                                                            createUserId = C.createUserId,
                                                            notes = C.notes,
                                                            posIdCreator = C.posIdCreator,
                                                            isConfirm = C.isConfirm,
                                                            cashTransIdSource = C.cashTransIdSource,
                                                            side = C.side,

                                                            docName = C.docName,
                                                            docNum = C.docNum,
                                                            docImage = C.docImage,
                                                            bankId = C.bankId,
                                                           
                                                            processType = C.processType,
                                                            cardId = C.cardId,
                                                            bondId = C.bondId,
                                                            shippingCompanyId = C.shippingCompanyId,
                                                        }).ToList();





                    if (cachlist == null)
                        return NotFound();
                    else
                        return Ok(cachlist);

                }
            }
            else
                return NotFound();
        }


        // GET api/agent/5
        [HttpGet]
        [Route("GetByID")]
        public IHttpActionResult GetByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int cTId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("cashTransId"))
            {
                cTId = Convert.ToInt32(headers.GetValues("cashTransId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {

                    var cacht = entity.cashTransfer

      .Where(C => C.cashTransId == cTId)

        .Select(C => new CashTransferModel
        {
            cashTransId = C.cashTransId,
            transType = C.transType,
            posId = C.posId,
            userId = C.userId,
            agentId = C.agentId,
            invId = C.invId,
            transNum = C.transNum,
            createDate = C.createDate,
            updateDate = C.updateDate,
            cash = C.cash,
            updateUserId = C.updateUserId,
            createUserId = C.createUserId,
            notes = C.notes,
            posIdCreator = C.posIdCreator,
            isConfirm = C.isConfirm,
            cashTransIdSource = C.cashTransIdSource,
            side = C.side,

            docName = C.docName,
            docNum = C.docNum,
            docImage = C.docImage,
            bankId = C.bankId,
            processType = C.processType,
            cardId = C.cardId,
            bondId = C.bondId,
            shippingCompanyId=C.shippingCompanyId,

        }).FirstOrDefault();

                    if (cacht == null)
                        return NotFound();
                    else
                        return Ok(cacht);

                }
            }
            else
                return NotFound();
        }

        // GET api/Agent
        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string type, string side, string searchwords)
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
                    var cashList = entity.cashTransfer
                   .Where(C => ((type == "all") ? true : C.transType == type)
            && ((side == "all") ? true : C.side == side) &&
             C.transNum.Contains(searchwords) || C.notes.Contains(searchwords)
             || C.docName.Contains(searchwords) || C.docNum.Contains(searchwords))
                   .Select(C => new
                   {
                       C.cashTransId,
                       C.transType,
                       C.posId,
                       C.userId,
                       C.agentId,
                       C.invId,
                       C.transNum,
                       C.createDate,
                       C.updateDate,
                       C.cash,
                       C.updateUserId,
                       C.createUserId,
                       C.notes,
                       C.posIdCreator,
                       C.isConfirm,
                       C.cashTransIdSource,
                       C.side,

                       C.docName,
                       C.docNum,
                       C.docImage,
                       C.bankId,
                       C.processType,
                       C.cardId,
                       C.bondId,
                       C.shippingCompanyId,
                   })
                   .ToList();

                    if (cashList == null)
                        return NotFound();
                    else
                        return Ok(cashList);

                }
            }
            else
                return NotFound();
        }

        // add or update agent
        [HttpPost]
        [Route("Save")]
        public int Save(string Object)
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

            Object = Object.Replace("\\", string.Empty);
            Object = Object.Trim('"');

            cashTransfer Obj = JsonConvert.DeserializeObject<cashTransfer>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            if (Obj.updateUserId == 0 || Obj.updateUserId == null)
            {
                Nullable<int> id = null;
                Obj.updateUserId = id;
            }
            if (Obj.createUserId == 0 || Obj.createUserId == null)
            {
                Nullable<int> id = null;
                Obj.createUserId = id;
            }

            if (Obj.agentId == 0 || Obj.agentId == null)
            {
                Nullable<int> id = null;
                Obj.agentId = id;
            }
            if (Obj.invId == 0 || Obj.invId == null)
            {
                Nullable<int> id = null;
                Obj.invId = id;
            }
            if (Obj.posIdCreator == 0 || Obj.posIdCreator == null)
            {
                Nullable<int> id = null;
                Obj.posIdCreator = id;
            }

            if (Obj.cashTransIdSource == 0 || Obj.cashTransIdSource == null)
            {
                Nullable<int> id = null;
                Obj.cashTransIdSource = id;
            }
            if (Obj.bankId == 0 || Obj.bankId == null)
            {
                Nullable<int> id = null;
                Obj.bankId = id;
            }

            if (valid)
            {
                try
                {
                    cashTransfer cashtr;
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var cEntity = entity.Set<cashTransfer>();
                        if (Obj.cashTransId == 0)
                        {
                            Obj.createDate = DateTime.Now;
                            Obj.updateDate = DateTime.Now;
                            Obj.updateUserId = Obj.createUserId;
                            cashtr = cEntity.Add(Obj);
                        }
                        else
                        {
                            cashtr = entity.cashTransfer.Where(p => p.cashTransId == Obj.cashTransId).First();
                            cashtr.transType = Obj.transType;
                            cashtr.posId = Obj.posId;
                            cashtr.userId = Obj.userId;
                            cashtr.agentId = Obj.agentId;
                            cashtr.invId = Obj.invId;
                            cashtr.transNum = Obj.transNum;
                            cashtr.createDate = Obj.createDate;
                            cashtr.updateDate = DateTime.Now;// server current date
                            cashtr.cash = Obj.cash;
                            cashtr.updateUserId = Obj.updateUserId;
                            // cashtr.createUserId = Obj. ;
                            cashtr.notes = Obj.notes;
                            cashtr.posIdCreator = Obj.posIdCreator;
                            cashtr.isConfirm = Obj.isConfirm;
                            cashtr.cashTransIdSource = Obj.cashTransIdSource;
                            cashtr.side = Obj.side;

                            cashtr.docName = Obj.docName;
                            cashtr.docNum = Obj.docNum;
                            cashtr.docImage = Obj.docImage;
                            cashtr.bankId = Obj.bankId;
                            cashtr.updateDate = DateTime.Now;// server current date
                            cashtr.processType = Obj.processType;
                            cashtr.cardId = Obj.cardId;
                            cashtr.bondId = Obj.bondId;
                            cashtr.shippingCompanyId = Obj.shippingCompanyId;

                        }
                        entity.SaveChanges();
                    }
                    return cashtr.cashTransId;
                }

                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        [HttpPost]
        [Route("Delete")]
        public bool Delete(Boolean final)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int agentId = 0;
            int userId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("agentId"))
            {
                agentId = Convert.ToInt32(headers.GetValues("agentId").First());
            }
            if (headers.Contains("userId"))
            {
                userId = Convert.ToInt32(headers.GetValues("userId").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            if (valid)
            {
                if (!final)
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            var tmpAgent = entity.agents.Where(p => p.agentId == agentId).First();
                            tmpAgent.isActive = 0;
                            tmpAgent.updateDate = DateTime.Now;
                            tmpAgent.updateUserId = userId;

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
                {
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                            var tmpAgent = entity.agents.Where(p => p.agentId == agentId).First();
                            entity.agents.Remove(tmpAgent);
                            entity.SaveChanges();
                        }
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            else
                return false;
        }



        ///
        [HttpGet]
        [Route("GetbySourcId")]
        public IHttpActionResult GetbySourcId(string side, int sourceId)
        {
            string type = "all";

            var re = Request;
            var headers = re.Headers;
            string token = "";
            /*
            string type = "";
            string side = "";
            */
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

                    var cachlist = (from C in entity.cashTransfer
                                    join b in entity.banks on C.bankId equals b.bankId into jb
                                    join a in entity.agents on C.agentId equals a.agentId into ja
                                    join p in entity.pos on C.posId equals p.posId into jp
                                    join u in entity.users on C.userId equals u.userId into ju
                                    from jbb in jb.DefaultIfEmpty()
                                    from jaa in ja.DefaultIfEmpty()
                                    from jpp in jp.DefaultIfEmpty()
                                    from juu in ju.DefaultIfEmpty()

                                    select new CashTransferModel()
                                    {
                                        cashTransId = C.cashTransId,
                                        transType = C.transType,
                                        posId = C.posId,
                                        userId = C.userId,
                                        agentId = C.agentId,
                                        invId = C.invId,
                                        transNum = C.transNum,
                                        createDate = C.createDate,
                                        updateDate = C.updateDate,
                                        cash = C.cash,
                                        updateUserId = C.updateUserId,
                                        createUserId = C.createUserId,
                                        notes = C.notes,
                                        posIdCreator = C.posIdCreator,
                                        isConfirm = C.isConfirm,
                                        cashTransIdSource = C.cashTransIdSource,
                                        side = C.side,

                                        docName = C.docName,
                                        docNum = C.docNum,
                                        docImage = C.docImage,
                                        bankId = C.bankId,
                                        bankName = jbb.name,
                                        agentName = jaa.name,
                                        usersName = juu.username,
                                        posName = jpp.name,
                                        processType = C.processType,
                                        cardId = C.cardId,
                                        bondId = C.bondId,
                                        shippingCompanyId = C.shippingCompanyId,
                                    }).Where(C => ((type == "all") ? true : C.transType == type)
                                && ((side == "all") ? true : C.side == side) && (C.cashTransId == sourceId || C.cashTransIdSource == sourceId)).ToList();


                    // one row mean type=d
                    if (cachlist.Count == 1)
                    {
                        int? pullposcashtransid = cachlist.First().cashTransIdSource;

                        //
                        var cachadd = (from C in entity.cashTransfer
                                       join b in entity.banks on C.bankId equals b.bankId into jb
                                       join a in entity.agents on C.agentId equals a.agentId into ja
                                       join p in entity.pos on C.posId equals p.posId into jp
                                       join u in entity.users on C.userId equals u.userId into ju
                                       from jbb in jb.DefaultIfEmpty()
                                       from jaa in ja.DefaultIfEmpty()
                                       from jpp in jp.DefaultIfEmpty()
                                       from juu in ju.DefaultIfEmpty()

                                       select new CashTransferModel()
                                       {
                                           cashTransId = C.cashTransId,
                                           transType = C.transType,
                                           posId = C.posId,
                                           userId = C.userId,
                                           agentId = C.agentId,
                                           invId = C.invId,
                                           transNum = C.transNum,
                                           createDate = C.createDate,
                                           updateDate = C.updateDate,
                                           cash = C.cash,
                                           updateUserId = C.updateUserId,
                                           createUserId = C.createUserId,
                                           notes = C.notes,
                                           posIdCreator = C.posIdCreator,
                                           isConfirm = C.isConfirm,
                                           cashTransIdSource = C.cashTransIdSource,
                                           side = C.side,

                                           docName = C.docName,
                                           docNum = C.docNum,
                                           docImage = C.docImage,
                                           bankId = C.bankId,
                                           bankName = jbb.name,
                                           agentName = jaa.name,
                                           usersName = juu.username,
                                           posName = jpp.name,
                                           processType = C.processType,
                                           cardId = C.cardId,
                                           bondId = C.bondId,
                                       }).Where(C => ((type == "all") ? true : C.transType == type)
               && ((side == "all") ? true : C.side == side) && (C.cashTransId == pullposcashtransid)).ToList();

                        //

                        if (cachadd.Count > 0)
                        {
                            cachlist.AddRange(cachadd);

                        }
                    }

                    if (cachlist == null)
                        return NotFound();
                    else
                    {

                        return Ok(cachlist);
                    }
                }

            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int cashTransId)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            List<CashTransferModel> delList = null;
            List<CashTransferModel> allList = null;
            cashTransfer cashobject = new cashTransfer();
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
                        allList = this.Getpostransmodel(cashTransId).ToList();
                        delList = allList.Where(C => C.isConfirm == 1).ToList();
                        if (delList != null)
                        {
                            if (delList.Count == 2)
                            {

                                return Ok("0");
                            }
                            else
                            {

                                foreach (CashTransferModel ctitem in allList)
                                {
                                    cashobject = entity.cashTransfer.Where(C => C.cashTransId == ctitem.cashTransId).FirstOrDefault();
                                    entity.cashTransfer.Remove(cashobject);

                                }
                                entity.SaveChanges();


                            }

                        }






                        return Ok("1");
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


        [HttpPost]
        [Route("MovePosCash")]
        public IHttpActionResult MovePosCash(int cashTransId, int userIdD)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            List<CashTransferModel> tempList = null;
            List<CashTransferModel> allList = null;
            CashTransferModel cashobject = new CashTransferModel();
            cashTransfer ctObject = new cashTransfer();

            pos posobject = new pos();
            pos posobjectD = new pos();
            int? posidPull = 0;
            int? posidD = 0;
            decimal? cash = 0;

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
                        allList = this.Getpostransmodel(cashTransId).ToList();
                        if (allList.Count > 0)
                        {
                            //check if first pos is confirm
                            tempList = allList.Where(C => C.transType == "p" && C.isConfirm == 1).ToList();

                            if (tempList != null)
                            {
                                if (tempList.Count >= 1)
                                {
                                    cashobject = tempList.FirstOrDefault();
                                    cash = cashobject.cash;
                                    posidPull = cashobject.posId;
                                    posobject = entity.pos.Where(p => p.posId == posidPull).FirstOrDefault();
                                    if (cashobject.cash <= posobject.balance)
                                    {
                                        //in "d" set confirm to 1
                                        //get row of type d
                                        cashobject = allList.Where(C => C.transType == "d").FirstOrDefault();
                                        ctObject = entity.cashTransfer.Where(C => C.cashTransId == cashobject.cashTransId).FirstOrDefault();
                                        ctObject.isConfirm = 1;
                                        ctObject.updateUserId = userIdD;
                                        ctObject.updateDate = DateTime.Now;
                                        ctObject.userId = userIdD;
                                        // END in "d" set confirm to 1

                                        //START decreas balance from pull pos
                                        posidD = ctObject.posId;
                                        posobject = entity.pos.Where(p => p.posId == posidPull).FirstOrDefault();

                                        posobject.balance = posobject.balance - cash;
                                        posobject.updateUserId = userIdD;
                                        posobject.updateDate = DateTime.Now;
                                        // end
                                        //increase balance from d pos
                                        posobjectD = entity.pos.Where(p => p.posId == posidD).FirstOrDefault();
                                        if (posobjectD.balance == null)
                                        {
                                            posobjectD.balance = 0;
                                        }
                                        posobjectD.balance = posobjectD.balance + cash;
                                        posobjectD.updateUserId = userIdD;
                                        posobjectD.updateDate = DateTime.Now;
                                        entity.SaveChanges();
                                        return Ok("transdone");
                                    }
                                    else
                                    {
                                        return Ok("nobalanceinpullpos");
                                    }


                                }
                                else
                                {
                                    return Ok("pullposnotconfirmed");
                                }
                            }
                            else
                            {
                                return Ok("nopullidornotconfirmed");
                            }
                        }
                        else
                        {
                            return Ok("idnotfound");
                        }

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

        public List<CashTransferModel> Getpostransmodel(int cashTransId)
        {
            string side = "p";
            string type = "all";
            using (incposdbEntities entity = new incposdbEntities())
            {

                var cachlist = (from C in entity.cashTransfer
                                join b in entity.banks on C.bankId equals b.bankId into jb
                                join a in entity.agents on C.agentId equals a.agentId into ja
                                join p in entity.pos on C.posId equals p.posId into jp
                                join u in entity.users on C.userId equals u.userId into ju
                                from jbb in jb.DefaultIfEmpty()
                                from jaa in ja.DefaultIfEmpty()
                                from jpp in jp.DefaultIfEmpty()
                                from juu in ju.DefaultIfEmpty()

                                select new CashTransferModel()
                                {
                                    cashTransId = C.cashTransId,
                                    transType = C.transType,
                                    posId = C.posId,
                                    userId = C.userId,
                                    agentId = C.agentId,
                                    invId = C.invId,
                                    transNum = C.transNum,
                                    createDate = C.createDate,
                                    updateDate = C.updateDate,
                                    cash = C.cash,
                                    updateUserId = C.updateUserId,
                                    createUserId = C.createUserId,
                                    notes = C.notes,
                                    posIdCreator = C.posIdCreator,
                                    isConfirm = C.isConfirm,
                                    cashTransIdSource = C.cashTransIdSource,
                                    side = C.side,

                                    docName = C.docName,
                                    docNum = C.docNum,
                                    docImage = C.docImage,
                                    bankId = C.bankId,
                                    bankName = jbb.name,
                                    agentName = jaa.name,
                                    usersName = juu.username,
                                    posName = jpp.name,
                                    processType = C.processType,
                                    cardId = C.cardId,
                                    bondId = C.bondId,
                                    shippingCompanyId = C.shippingCompanyId,
                                }).Where(C => ((type == "all") ? true : C.transType == type)
        && ((side == "all") ? true : C.side == side) && (C.cashTransId == cashTransId || C.cashTransIdSource == cashTransId)).ToList();


                // one row mean type=d
                if (cachlist.Count == 1)
                {
                    int? pullposcashtransid = cachlist.First().cashTransIdSource;

                    //
                    var cachadd = (from C in entity.cashTransfer
                                   join b in entity.banks on C.bankId equals b.bankId into jb
                                   join a in entity.agents on C.agentId equals a.agentId into ja
                                   join p in entity.pos on C.posId equals p.posId into jp
                                   join u in entity.users on C.userId equals u.userId into ju
                                   from jbb in jb.DefaultIfEmpty()
                                   from jaa in ja.DefaultIfEmpty()
                                   from jpp in jp.DefaultIfEmpty()
                                   from juu in ju.DefaultIfEmpty()

                                   select new CashTransferModel()
                                   {
                                       cashTransId = C.cashTransId,
                                       transType = C.transType,
                                       posId = C.posId,
                                       userId = C.userId,
                                       agentId = C.agentId,
                                       invId = C.invId,
                                       transNum = C.transNum,
                                       createDate = C.createDate,
                                       updateDate = C.updateDate,
                                       cash = C.cash,
                                       updateUserId = C.updateUserId,
                                       createUserId = C.createUserId,
                                       notes = C.notes,
                                       posIdCreator = C.posIdCreator,
                                       isConfirm = C.isConfirm,
                                       cashTransIdSource = C.cashTransIdSource,
                                       side = C.side,

                                       docName = C.docName,
                                       docNum = C.docNum,
                                       docImage = C.docImage,
                                       bankId = C.bankId,
                                       bankName = jbb.name,
                                       agentName = jaa.name,
                                       usersName = juu.username,
                                       posName = jpp.name,
                                       processType = C.processType,
                                       cardId = C.cardId,
                                       bondId = C.bondId,
                                       shippingCompanyId = C.shippingCompanyId,
                                   }).Where(C => ((type == "all") ? true : C.transType == type)
                      && ((side == "all") ? true : C.side == side) && (C.cashTransId == pullposcashtransid)).ToList();

                    //

                    if (cachadd.Count > 0)
                    {
                        cachlist.AddRange(cachadd);

                    }

                }

                return cachlist;
            }
        }


        [HttpGet]
        [Route("GetByInvId")]
        public IHttpActionResult GetByInvId(int invId)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string type = "all";
            string side = "all";
            /*
            string type = "";
            string side = "";
            */
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

                    CashTransferModel cachtrans = (from C in entity.cashTransfer
                                                   join b in entity.banks on C.bankId equals b.bankId into jb
                                                   join a in entity.agents on C.agentId equals a.agentId into ja
                                                   join p in entity.pos on C.posId equals p.posId into jp
                                                   join pc in entity.pos on C.posIdCreator equals pc.posId into jpcr
                                                   join u in entity.users on C.userId equals u.userId into ju
                                                   from jbb in jb.DefaultIfEmpty()
                                                   from jaa in ja.DefaultIfEmpty()
                                                   from jpp in jp.DefaultIfEmpty()
                                                   from juu in ju.DefaultIfEmpty()
                                                   from jpcc in jpcr.DefaultIfEmpty()
                                                   select new CashTransferModel()
                                                   {
                                                       cashTransId = C.cashTransId,
                                                       transType = C.transType,
                                                       posId = C.posId,
                                                       userId = C.userId,
                                                       agentId = C.agentId,
                                                       invId = C.invId,
                                                       transNum = C.transNum,
                                                       createDate = C.createDate,
                                                       updateDate = C.updateDate,
                                                       cash = C.cash,
                                                       updateUserId = C.updateUserId,
                                                       createUserId = C.createUserId,
                                                       notes = C.notes,
                                                       posIdCreator = C.posIdCreator,
                                                       isConfirm = C.isConfirm,
                                                       cashTransIdSource = C.cashTransIdSource,
                                                       side = C.side,

                                                       docName = C.docName,
                                                       docNum = C.docNum,
                                                       docImage = C.docImage,
                                                       bankId = C.bankId,
                                                       bankName = jbb.name,
                                                       agentName = jaa.name,
                                                       usersName = juu.username,
                                                       posName = jpp.name,
                                                       posCreatorName = jpcc.name,
                                                       processType = C.processType,
                                                       cardId = C.cardId,
                                                       bondId = C.bondId,
                                                       shippingCompanyId = C.shippingCompanyId,
                                                   }).Where(C => ((type == "all") ? true : C.transType == type)
                                                                          && ((side == "all") ? true : C.side == side) && C.invId == invId).FirstOrDefault();




                    if (cachtrans == null)
                        return NotFound();
                    else
                        return Ok(cachtrans);

                }
            }
            else
                return NotFound();
        }


        [HttpGet]
        [Route("GetListByInvId")]
        public IHttpActionResult GetListByInvId(int invId)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";

            /*
            string type = "";
            string side = "";
            */
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

                    List<CashTransferModel> cachtrans = (from C in entity.cashTransfer
                                                         join b in entity.banks on C.bankId equals b.bankId into jb
                                                         join a in entity.agents on C.agentId equals a.agentId into ja
                                                         join p in entity.pos on C.posId equals p.posId into jp
                                                         join pc in entity.pos on C.posIdCreator equals pc.posId into jpcr
                                                         join u in entity.users on C.userId equals u.userId into ju
                                                         from jbb in jb.DefaultIfEmpty()
                                                         from jaa in ja.DefaultIfEmpty()
                                                         from jpp in jp.DefaultIfEmpty()
                                                         from juu in ju.DefaultIfEmpty()
                                                         from jpcc in jpcr.DefaultIfEmpty()

                                                         select new CashTransferModel()
                                                         {
                                                             cashTransId = C.cashTransId,
                                                             transType = C.transType,
                                                             posId = C.posId,
                                                             userId = C.userId,
                                                             agentId = C.agentId,
                                                             invId = C.invId,
                                                             transNum = C.transNum,
                                                             createDate = C.createDate,
                                                             updateDate = C.updateDate,
                                                             cash = C.cash,
                                                             updateUserId = C.updateUserId,
                                                             createUserId = C.createUserId,
                                                             notes = C.notes,
                                                             posIdCreator = C.posIdCreator,
                                                             isConfirm = C.isConfirm,
                                                             cashTransIdSource = C.cashTransIdSource,
                                                             side = C.side,

                                                             docName = C.docName,
                                                             docNum = C.docNum,
                                                             docImage = C.docImage,
                                                             bankId = C.bankId,
                                                             bankName = jbb.name,
                                                             agentName = jaa.name,
                                                             usersName = juu.username,
                                                             posName = jpp.name,
                                                             posCreatorName = jpcc.name,
                                                             processType = C.processType,
                                                             cardId = C.cardId,
                                                             bondId = C.bondId,
                                                             shippingCompanyId = C.shippingCompanyId,
                                                         }).Where(C => C.invId == invId && C.processType != "inv").ToList();




                    if (cachtrans == null)
                        return NotFound();
                    else
                        return Ok(cachtrans);

                }
            }
            else
                return NotFound();
        }



        [HttpGet]
        [Route("GetCountByInvId")]
        public IHttpActionResult GetCountByInvId(int invId)
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

                    int cachtrans = entity.cashTransfer.Where(C => C.invId == invId && C.processType != "inv").ToList().Count();

                    if (cachtrans == null)
                        return NotFound();
                    else
                        return Ok(cachtrans);

                }
            }
            else
                return NotFound();
        }
        /// <summary>
        /// /////////////
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="amount"></param>
        /// <param name="payType">{pay,feed}</param>
        /// <param name="cashTransfer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("payByAmount")]
        public IHttpActionResult payByAmount(int agentId, decimal amount, string payType, string cashTransfer)
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
                List<string> typesList = new List<string>();
                string cashIds = "";
                switch (payType)
                {
                    case "pay"://get pw,pi,sb invoices

                        typesList.Add("pw");
                        typesList.Add("p");
                        typesList.Add("sb");
                        break;
                    case "feed": //get si, pb

                        typesList.Add("pb");
                        typesList.Add("s");
                        break;
                }
                cashTransfer cashTr = JsonConvert.DeserializeObject<cashTransfer>(cashTransfer, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invList = (from b in entity.invoices.Where(x => x.agentId == agentId && typesList.Contains(x.invType) && x.deserved > 0)
                                   select new InvoiceModel()
                                   {
                                       invoiceId = b.invoiceId,
                                       invNumber = b.invNumber,
                                       agentId = b.agentId,
                                       invType = b.invType,
                                       total = b.total,
                                       totalNet = b.totalNet,
                                       paid = b.paid,
                                       deserved = b.deserved,
                                       deservedDate = b.deservedDate,
                                       invDate = b.invDate,
                                       invoiceMainId = b.invoiceMainId,
                                       invCase = b.invCase,
                                       invTime = b.invTime,
                                       notes = b.notes,
                                       vendorInvNum = b.vendorInvNum,
                                       vendorInvDate = b.vendorInvDate,
                                       createUserId = b.createUserId,
                                       updateDate = b.updateDate,
                                       updateUserId = b.updateUserId,
                                       branchId = b.branchId,
                                       discountValue = b.discountValue,
                                       discountType = b.discountType,
                                       tax = b.tax,
                                       taxtype = b.taxtype,
                                       name = b.name,
                                       isApproved = b.isApproved,
                                       branchCreatorId = b.branchCreatorId,
                                       shippingCompanyId = b.shippingCompanyId,
                                       shipUserId = b.shipUserId,
                                   }).ToList().OrderBy(b => b.deservedDate);

                    cashTransfer ct;
                    agents agent;
                    if (invList.ToList().Count > 0)
                    {
                        switch (payType)
                        {
                            #region payments
                            case "pay"://get pw,p,sb invoices

                                foreach (InvoiceModel inv in invList)
                                {
                                    decimal paid = 0;
                                    agent = entity.agents.Find(agentId);
                                    decimal agentBalance = (decimal)agent.balance;
                                    var invObj = entity.invoices.Find(inv.invoiceId);
                                    cashTr.invId = inv.invoiceId;
                                    if (amount >= inv.deserved)
                                    {
                                        paid = (decimal)inv.deserved;
                                        invObj.paid += inv.deserved;
                                        invObj.deserved = 0;
                                        amount -= (decimal)inv.deserved;
                                    }
                                    else
                                    {
                                        paid = amount;
                                        invObj.paid = invObj.paid + amount;
                                        invObj.deserved -= amount;
                                        amount = 0;
                                    }
                                    cashTr.cash = paid;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);

                                    // increase agent balance
                                    if (agent.balanceType == 0)
                                    {
                                        if (paid <= (decimal)agent.balance)
                                        {
                                            agent.balance = agentBalance - paid;
                                        }
                                        else
                                        {
                                            agent.balance = paid - agentBalance;
                                            agent.balanceType = 1;
                                        }
                                    }
                                    else
                                    {
                                        agent.balance = agentBalance + paid;
                                    }

                                    entity.SaveChanges();
                                    cashIds += ct.cashTransId + ",";
                                    if (amount == 0)
                                        break;
                                }
                                if (amount > 0) // save remain amount
                                {
                                    agent = entity.agents.Find(agentId);
                                    decimal agentBalance = (decimal)agent.balance;
                                    cashTr.cash = amount;
                                    cashTr.invId = null;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);

                                    // increase agent balance
                                    if (agent.balanceType == 0)
                                    {
                                        if (amount <= (decimal)agent.balance)
                                        {
                                            agent.balance = agentBalance - amount;
                                        }
                                        else
                                        {
                                            agent.balance = amount - agentBalance;
                                            agent.balanceType = 1;
                                        }
                                    }
                                    else
                                    {
                                        agent.balance = agentBalance + amount;
                                    }
                                    entity.SaveChanges();
                                }
                                break;
                            #endregion
                            #region feed
                            case "feed": //get s, pb
                                foreach (InvoiceModel inv in invList)
                                {
                                    agent = entity.agents.Find(agentId);

                                    decimal paid = 0;
                                    var invObj = entity.invoices.Find(inv.invoiceId);
                                    cashTr.invId = inv.invoiceId;
                                    if (amount >= inv.deserved)
                                    {
                                        paid = (decimal)inv.deserved;
                                        invObj.paid = invObj.paid + inv.deserved;
                                        invObj.deserved = 0;
                                        amount -= (decimal)inv.deserved;
                                    }
                                    else
                                    {
                                        paid = amount;
                                        invObj.paid = invObj.paid + amount;
                                        invObj.deserved -= amount;
                                        amount = 0;
                                    }
                                    cashTr.cash = paid;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);

                                    // decrease agent balance
                                    if (agent.balanceType == 1)
                                    {
                                        if (paid <= (decimal)agent.balance)
                                        {
                                            agent.balance -= paid;
                                        }
                                        else
                                        {
                                            agent.balance = paid - agent.balance;
                                            agent.balanceType = 0;
                                        }
                                    }
                                    else
                                    {
                                        agent.balance += paid;
                                    }

                                    entity.SaveChanges();
                                    cashIds += ct.cashTransId + ",";
                                    if (amount == 0)
                                        break;
                                }
                                if (amount > 0) // save remain amount
                                {
                                    agent = entity.agents.Find(agentId);

                                    cashTr.cash = amount;
                                    cashTr.invId = null;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);
                                    // decrease agent balance
                                    if (agent.balanceType == 1)
                                    {
                                        if (amount <= (decimal)agent.balance)
                                        {
                                            agent.balance = agent.balance - amount;
                                        }
                                        else
                                        {
                                            agent.balance = amount - agent.balance;
                                            agent.balanceType = 0;
                                        }
                                    }
                                    else
                                    {
                                        agent.balance += amount;
                                    }

                                    entity.SaveChanges();
                                }
                                break;
                                #endregion
                        }
                        return Ok(cashIds);
                    }
                    else
                    {
                        if (amount > 0) // save remain amount
                        {
                            switch (payType)
                            {
                                case "pay":
                                    agent = entity.agents.Find(agentId);
                                    decimal agentBalance = (decimal)agent.balance;
                                    cashTr.cash = amount;
                                    cashTr.invId = null;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);

                                    // increase agent balance
                                    if (agent.balanceType == 0)
                                    {
                                        if (amount <= (decimal)agent.balance)
                                        {
                                            agent.balance = agentBalance - amount;
                                        }
                                        else
                                        {
                                            agent.balance = amount - agentBalance;
                                            agent.balanceType = 1;
                                        }
                                    }
                                    else
                                    {
                                        agent.balance = agentBalance + amount;
                                    }
                                    entity.SaveChanges();
                                    break;
                                case "feed":
                                    agent = entity.agents.Find(agentId);

                                    cashTr.cash = amount;
                                    cashTr.invId = null;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);
                                    // decrease agent balance
                                    if (agent.balanceType == 1)
                                    {
                                        if (amount <= (decimal)agent.balance)
                                        {
                                            agent.balance = agent.balance - amount;
                                        }
                                        else
                                        {
                                            agent.balance = amount - agent.balance;
                                            agent.balanceType = 0;
                                        }
                                    }
                                    else
                                    {
                                        agent.balance += amount;
                                    }

                                    entity.SaveChanges();
                                    break;
                            }
                        }
                        return Ok("-1");
                    }
                }
            }
            else
                return Ok("false");
        }


        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <param name="payType">{feed}</param>
        /// <param name="cashTransfer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("payUserByAmount")]
        public IHttpActionResult payUserByAmount(int userId, decimal amount, string payType, string cashTransfer)
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
                List<string> typesList = new List<string>();
                string cashIds = "";
                switch (payType)
                {
                    //case "pay"://get pw,pi,sb invoices

                    //    typesList.Add("pw");
                    //    typesList.Add("p");
                    //    typesList.Add("sb");
                    //    break;
                    case "feed": //get si, pb

                        typesList.Add("pb");
                        typesList.Add("s");
                        break;
                }
                cashTransfer cashTr = JsonConvert.DeserializeObject<cashTransfer>(cashTransfer, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invList = (from b in entity.invoices.Where(x => x.userId == userId && typesList.Contains(x.invType) && x.deserved > 0)
                                   select new InvoiceModel()
                                   {
                                       invoiceId = b.invoiceId,
                                       invNumber = b.invNumber,
                                       agentId = b.agentId,
                                       invType = b.invType,
                                       total = b.total,
                                       totalNet = b.totalNet,
                                       paid = b.paid,
                                       deserved = b.deserved,
                                       deservedDate = b.deservedDate,
                                       invDate = b.invDate,
                                       invoiceMainId = b.invoiceMainId,
                                       invCase = b.invCase,
                                       invTime = b.invTime,
                                       notes = b.notes,
                                       vendorInvNum = b.vendorInvNum,
                                       vendorInvDate = b.vendorInvDate,
                                       createUserId = b.createUserId,
                                       updateDate = b.updateDate,
                                       updateUserId = b.updateUserId,
                                       branchId = b.branchId,
                                       discountValue = b.discountValue,
                                       discountType = b.discountType,
                                       tax = b.tax,
                                       taxtype = b.taxtype,
                                       name = b.name,
                                       isApproved = b.isApproved,
                                       branchCreatorId = b.branchCreatorId,
                                       shippingCompanyId = b.shippingCompanyId,
                                       shipUserId = b.shipUserId,
                                       userId = b.userId
                                   }).ToList().OrderBy(b => b.deservedDate);

                    cashTransfer ct;
                    users user;
                    if (invList.ToList().Count > 0)
                    {
                        switch (payType)
                        {
                            #region payments
                            
                            #region feed
                            case "feed": //get s, pb
                                foreach (InvoiceModel inv in invList)
                                {
                                    user = entity.users.Find(userId);

                                    decimal paid = 0;
                                    var invObj = entity.invoices.Find(inv.invoiceId);
                                    cashTr.invId = inv.invoiceId;
                                    if (amount >= inv.deserved)
                                    {
                                        paid = (decimal)inv.deserved;
                                        invObj.paid = invObj.paid + inv.deserved;
                                        invObj.deserved = 0;
                                        amount -= (decimal)inv.deserved;
                                    }
                                    else
                                    {
                                        paid = amount;
                                        invObj.paid = invObj.paid + amount;
                                        invObj.deserved -= amount;
                                        amount = 0;
                                    }
                                    cashTr.cash = paid;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);

                                    // decrease user balance
                                    if (user.balanceType == 1)
                                    {
                                        if (paid <= (decimal)user.balance)
                                        {
                                            user.balance -= paid;
                                        }
                                        else
                                        {
                                            user.balance = paid - user.balance;
                                            user.balanceType = 0;
                                        }
                                    }
                                    else
                                    {
                                        user.balance += paid;
                                    }
                                    

                                    entity.SaveChanges();
                                    cashIds += ct.cashTransId + ",";
                                    if (amount == 0)
                                        break;
                                }
                                if (amount > 0) // save remain amount
                                {
                                    user = entity.users.Find(userId);

                                    cashTr.cash = amount;
                                    cashTr.invId = null;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);
                                    // decrease user balance
                                    if (user.balanceType == 1)
                                    {
                                        if (amount <= (decimal)user.balance)
                                        {
                                            user.balance = user.balance - amount;
                                        }
                                        else
                                        {
                                            user.balance = amount - user.balance;
                                            user.balanceType = 0;
                                        }
                                    }
                                    else
                                    {
                                        user.balance += amount;
                                    }

                                    entity.SaveChanges();
                                }
                                break;
                                #endregion
                        }
                        return Ok(cashIds);
                    }
                    else
                    {
                        if (amount > 0) // save remain amount
                        {
                            switch (payType)
                            {
                                case "feed":
                                    user = entity.users.Find(userId);

                                    cashTr.cash = amount;
                                    cashTr.invId = null;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);
                                    // decrease user balance
                                    if (user.balanceType == 1)
                                    {
                                        if (amount <= (decimal)user.balance)
                                        {
                                            user.balance = user.balance - amount;
                                        }
                                        else
                                        {
                                            user.balance = amount - user.balance;
                                            user.balanceType = 0;
                                        }
                                    }
                                    else
                                    {
                                        user.balance += amount;
                                    }

                                    entity.SaveChanges();
                                    break;
                            }
                        }
                        return Ok("-1");
                    }
                }
            }
            else
                return Ok("false");
        }
        //

        /// </summary>
        /// <param name="shippingCompanyId"></param>
        /// <param name="amount"></param>
        /// <param name="payType">{feed}</param>
        /// <param name="cashTransfer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("payShippingCompanyByAmount")]
        public IHttpActionResult payShippingCompanyByAmount(int shippingCompanyId, decimal amount, string payType, string cashTransfer)
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
                List<string> typesList = new List<string>();
                string cashIds = "";
                switch (payType)
                {
                    //case "pay"://get pw,pi,sb invoices

                    //    typesList.Add("pw");
                    //    typesList.Add("p");
                    //    typesList.Add("sb");
                    //    break;
                    case "feed": //get si, pb

                        typesList.Add("pb");
                        typesList.Add("s");
                        break;
                }
                cashTransfer cashTr = JsonConvert.DeserializeObject<cashTransfer>(cashTransfer, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var invList = (from b in entity.invoices.Where(x => x.shippingCompanyId == shippingCompanyId && typesList.Contains(x.invType) && x.deserved > 0)
                                   select new InvoiceModel()
                                   {
                                       invoiceId = b.invoiceId,
                                       invNumber = b.invNumber,
                                       agentId = b.agentId,
                                       invType = b.invType,
                                       total = b.total,
                                       totalNet = b.totalNet,
                                       paid = b.paid,
                                       deserved = b.deserved,
                                       deservedDate = b.deservedDate,
                                       invDate = b.invDate,
                                       invoiceMainId = b.invoiceMainId,
                                       invCase = b.invCase,
                                       invTime = b.invTime,
                                       notes = b.notes,
                                       vendorInvNum = b.vendorInvNum,
                                       vendorInvDate = b.vendorInvDate,
                                       createUserId = b.createUserId,
                                       updateDate = b.updateDate,
                                       updateUserId = b.updateUserId,
                                       branchId = b.branchId,
                                       discountValue = b.discountValue,
                                       discountType = b.discountType,
                                       tax = b.tax,
                                       taxtype = b.taxtype,
                                       name = b.name,
                                       isApproved = b.isApproved,
                                       branchCreatorId = b.branchCreatorId,
                                       shippingCompanyId = b.shippingCompanyId,
                                       shipUserId = b.shipUserId,
                                       userId = b.userId
                                   }).ToList().OrderBy(b => b.deservedDate);

                    cashTransfer ct;
                    shippingCompanies shippingCompany;
                    if (invList.ToList().Count > 0)
                    {
                        switch (payType)
                        {
                            case "feed": //get s, pb
                                foreach (InvoiceModel inv in invList)
                                {
                                    shippingCompany = entity.shippingCompanies.Find(shippingCompanyId);

                                    decimal paid = 0;
                                    var invObj = entity.invoices.Find(inv.invoiceId);
                                    cashTr.invId = inv.invoiceId;
                                    if (amount >= inv.deserved)
                                    {
                                        paid = (decimal)inv.deserved;
                                        invObj.paid = invObj.paid + inv.deserved;
                                        invObj.deserved = 0;
                                        amount -= (decimal)inv.deserved;
                                    }
                                    else
                                    {
                                        paid = amount;
                                        invObj.paid = invObj.paid + amount;
                                        invObj.deserved -= amount;
                                        amount = 0;
                                    }
                                    cashTr.cash = paid;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);

                                    // decrease shipping balance
                                    if (shippingCompany.balanceType == 1)
                                    {
                                        if (paid <= (decimal)shippingCompany.balance)
                                        {
                                            shippingCompany.balance -= paid;
                                        }
                                        else
                                        {
                                            shippingCompany.balance = paid - shippingCompany.balance;
                                            shippingCompany.balanceType = 0;
                                        }
                                    }
                                    else
                                    {
                                        shippingCompany.balance += paid;
                                    }

                                    entity.SaveChanges();
                                    cashIds += ct.cashTransId + ",";
                                    if (amount == 0)
                                        break;
                                }
                                if (amount > 0) // save remain amount
                                {
                                    shippingCompany = entity.shippingCompanies.Find(shippingCompanyId);

                                    cashTr.cash = amount;
                                    cashTr.invId = null;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);
                                    // decrease shipping balance
                                    if (shippingCompany.balanceType == 1)
                                    {
                                        if (amount <= (decimal)shippingCompany.balance)
                                        {
                                            shippingCompany.balance = shippingCompany.balance - amount;
                                        }
                                        else
                                        {
                                            shippingCompany.balance = amount - shippingCompany.balance;
                                            shippingCompany.balanceType = 0;
                                        }
                                    }
                                    else
                                    {
                                        shippingCompany.balance += amount;
                                    }
                                   
                                    entity.SaveChanges();
                                }
                                break;
                                #endregion
                        }
                        return Ok(cashIds);
                    }
                    else
                    {
                        if (amount > 0) // save remain amount
                        {
                            switch (payType)
                            {
                                case "feed":
                                    shippingCompany = entity.shippingCompanies.Find(shippingCompanyId);

                                    cashTr.cash = amount;
                                    cashTr.invId = null;
                                    cashTr.createDate = DateTime.Now;
                                    cashTr.updateDate = DateTime.Now;
                                    cashTr.updateUserId = cashTr.createUserId;
                                    ct = entity.cashTransfer.Add(cashTr);
                                    // decrease shipping balance
                                    if (shippingCompany.balanceType == 1)
                                    {
                                        if (amount <= (decimal)shippingCompany.balance)
                                        {
                                            shippingCompany.balance = shippingCompany.balance - amount;
                                        }
                                        else
                                        {
                                            shippingCompany.balance = amount - shippingCompany.balance;
                                            shippingCompany.balanceType = 0;
                                        }
                                    }
                                    else
                                    {
                                        shippingCompany.balance += amount;
                                    }

                                    entity.SaveChanges();
                                    break;
                            }
                        }
                        return Ok("-1");
                    }
                }
            }
            else
                return Ok("false");
        }
        /// <summary>
        /// //////////////
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="amount"></param>
        /// <param name="payType">{pay , feed}</param>
        /// <param name="cashTransfer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("payListOfInvoices")]
        public IHttpActionResult payListOfInvoices(int agentId, string invoices, string payType, string cashTransfer)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string cashIds = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                invoices = invoices.Replace("\\", string.Empty);
                invoices = invoices.Trim('"');

               List<invoices> invoiceList = JsonConvert.DeserializeObject<List<invoices>>(invoices, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                cashTransfer cashTr = JsonConvert.DeserializeObject<cashTransfer>(cashTransfer, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                using (incposdbEntities entity = new incposdbEntities())
                {
                    agents agent = entity.agents.Find(agentId);

                    switch (payType)
                    {
                        case "pay"://get pw,p,sb invoices
                            foreach (invoices inv in invoiceList)
                            {
                                decimal paid = 0;
                                cashTransfer ct;
                                var invObj = entity.invoices.Find(inv.invoiceId);
                                cashTr.invId = inv.invoiceId;
                                  
                                paid = (decimal)inv.deserved;
                                invObj.paid = invObj.paid + inv.deserved;
                                invObj.deserved = 0;

                                cashTr.cash = paid;
                                cashTr.createDate = DateTime.Now;
                                cashTr.updateDate = DateTime.Now;
                                cashTr.updateUserId = cashTr.createUserId;
                                ct = entity.cashTransfer.Add(cashTr);
                                cashIds += ct.cashTransId + ",";
                                // increase agent balance
                                if (agent.balanceType == 1)
                                {
                                    if (paid <= (decimal)agent.balance)
                                    {
                                        agent.balance = agent.balance - paid;
                                    }
                                    else
                                    {
                                        agent.balance = paid - agent.balance;
                                        agent.balanceType = 0;
                                    }
                                }
                                else if (agent.balanceType == 0)
                                {
                                    agent.balance += paid;
                                }
                                entity.SaveChanges();
                            }
                            entity.SaveChanges();
                            break;
                        case "feed": //get s, pb
                            foreach (invoices inv in invoiceList)
                            {
                                decimal paid = 0;
                                cashTransfer ct;
                                var invObj = entity.invoices.Find(inv.invoiceId);
                                cashTr.invId = inv.invoiceId;

                                paid = (decimal)inv.deserved;
                                invObj.paid = invObj.paid + inv.deserved;
                                invObj.deserved = 0;

                                cashTr.cash = paid;
                                cashTr.createDate = DateTime.Now;
                                cashTr.updateDate = DateTime.Now;
                                cashTr.updateUserId = cashTr.createUserId;
                               ct = entity.cashTransfer.Add(cashTr);
                                cashIds += ct.cashTransId + ",";
                                // decrease agent balance
                                if (agent.balanceType == 0)
                                {
                                    if (paid <= (decimal)agent.balance)
                                    {
                                        agent.balance = agent.balance - paid;
                                    }
                                    else
                                    {
                                        agent.balance = paid - agent.balance;
                                        agent.balanceType = 1;
                                    }
                                }
                                else if (agent.balanceType == 1)
                                {
                                    agent.balance += paid;
                                }
                                entity.SaveChanges();
                            }
                            entity.SaveChanges();
                            break;      
                    }                     
                    return Ok(cashIds);
                }
            }
            else
                return Ok("false");
           
            }

        /// <summary>
        /// //////////////
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <param name="payType">{feed}</param>
        /// <param name="cashTransfer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("payUserListOfInvoices")]
        public IHttpActionResult payUserListOfInvoices(int userId, string invoices, string payType, string cashTransfer)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string cashIds = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                invoices = invoices.Replace("\\", string.Empty);
                invoices = invoices.Trim('"');

                List<invoices> invoiceList = JsonConvert.DeserializeObject<List<invoices>>(invoices, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                cashTransfer cashTr = JsonConvert.DeserializeObject<cashTransfer>(cashTransfer, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                using (incposdbEntities entity = new incposdbEntities())
                {
                    users user = entity.users.Find(userId);

                    switch (payType)
                    {
                        case "feed": //get s, pb
                            foreach (invoices inv in invoiceList)
                            {
                                decimal paid = 0;
                                cashTransfer ct;
                                var invObj = entity.invoices.Find(inv.invoiceId);
                                cashTr.invId = inv.invoiceId;

                                paid = (decimal)inv.deserved;
                                invObj.paid = invObj.paid + inv.deserved;
                                invObj.deserved = 0;

                                cashTr.cash = paid;
                                cashTr.createDate = DateTime.Now;
                                cashTr.updateDate = DateTime.Now;
                                cashTr.updateUserId = cashTr.createUserId;
                                ct = entity.cashTransfer.Add(cashTr);
                                cashIds += ct.cashTransId + ",";
                                // decrease user balance
                                if (user.balanceType == 0)
                                {
                                    if (paid <= (decimal)user.balance)
                                    {
                                        user.balance = user.balance - paid;
                                    }
                                    else
                                    {
                                        user.balance = paid - user.balance;
                                        user.balanceType = 1;
                                    }
                                }
                                else if (user.balanceType == 1)
                                {
                                    user.balance += paid;
                                }
                                entity.SaveChanges();
                            }
                            entity.SaveChanges();
                            break;
                    }
                    return Ok(cashIds);
                }
            }
            else
                return Ok("false");

        }

        /// <summary>
        /// //////////////
        /// </summary>
        /// <param name="shippingCompanyId"></param>
        /// <param name="amount"></param>
        /// <param name="payType">{feed}</param>
        /// <param name="cashTransfer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("payShippingCompanyListOfInvoices")]
        public IHttpActionResult payShippingCompanyListOfInvoices(int shippingCompanyId, string invoices, string payType, string cashTransfer)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string cashIds = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                invoices = invoices.Replace("\\", string.Empty);
                invoices = invoices.Trim('"');

                List<invoices> invoiceList = JsonConvert.DeserializeObject<List<invoices>>(invoices, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                cashTransfer cashTr = JsonConvert.DeserializeObject<cashTransfer>(cashTransfer, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                using (incposdbEntities entity = new incposdbEntities())
                {
                    shippingCompanies shippingCompany = entity.shippingCompanies.Find(shippingCompanyId);

                    switch (payType)
                    {
                        case "feed": //get s, pb
                            foreach (invoices inv in invoiceList)
                            {
                                decimal paid = 0;
                                cashTransfer ct;
                                var invObj = entity.invoices.Find(inv.invoiceId);
                                cashTr.invId = inv.invoiceId;

                                paid = (decimal)inv.deserved;
                                invObj.paid = invObj.paid + inv.deserved;
                                invObj.deserved = 0;

                                cashTr.cash = paid;
                                cashTr.createDate = DateTime.Now;
                                cashTr.updateDate = DateTime.Now;
                                cashTr.updateUserId = cashTr.createUserId;
                                ct = entity.cashTransfer.Add(cashTr);
                                cashIds += ct.cashTransId + ",";
                                // decrease shippingCompany balance
                                if (shippingCompany.balanceType == 0)
                                {
                                    if (paid <= (decimal)shippingCompany.balance)
                                    {
                                        shippingCompany.balance = shippingCompany.balance - paid;
                                    }
                                    else
                                    {
                                        shippingCompany.balance = paid - shippingCompany.balance;
                                        shippingCompany.balanceType = 1;
                                    }
                                }
                                else if (shippingCompany.balanceType == 1)
                                {
                                    shippingCompany.balance += paid;
                                }
                                entity.SaveChanges();
                            }
                            entity.SaveChanges();
                            break;
                    }
                    return Ok(cashIds);
                }
            }
            else
                return Ok("false");

        }

        //[HttpPost]
        //[Route("payOrderInvoice")]
        //public IHttpActionResult payOrderInvoice(int invoiceId, int invStatusId , decimal amount, string payType, string cashTransfer)
        //{
        //    var re = Request;
        //    var headers = re.Headers;
        //    string token = "";
        //    string cashIds = "";
        //    if (headers.Contains("APIKey"))
        //    {
        //        token = headers.GetValues("APIKey").First();
        //    }
        //    Validation validation = new Validation();
        //    bool valid = validation.CheckApiKey(token);

        //    if (valid)
        //    {
        //        cashTransfer cashTr = JsonConvert.DeserializeObject<cashTransfer>(cashTransfer, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

        //        using (incposdbEntities entity = new incposdbEntities())
        //        {
        //            decimal paid = 0;

        //            invoices inv = entity.invoices.Find(invoiceId);
        //            agents agent = entity.agents.Find(inv.agentId);
        //            invoiceStatus invStatus = entity.invoiceStatus.Find(invStatusId);

        //            invStatus.status = "tr";

        //            cashTr.invId = inv.invoiceId;
        //            cashTr.cash = amount;
        //            cashTr.createDate = DateTime.Now;
        //            cashTr.updateDate = DateTime.Now;
        //            cashTr.updateUserId = cashTr.createUserId;

        //            cashTransfer ct;

        //            switch (payType)
        //            {
        //                case "0":// cash - card

        //                    ct = entity.cashTransfer.Add(cashTr);
        //                    cashIds += ct.cashTransId;
        //                    // decrease agent balance
        //                    if (agent.balanceType == 0)
        //                    {
        //                        if (paid <= (decimal)agent.balance)
        //                        {
        //                            agent.balance = agent.balance - paid;
        //                        }
        //                        else
        //                        {
        //                            agent.balance = paid - agent.balance;
        //                            agent.balanceType = 1;
        //                        }
        //                    }
        //                    else if (agent.balanceType == 1)
        //                    {
        //                        agent.balance += paid;
        //                    }
        //                    entity.SaveChanges();
        //                    break;
        //                case "1":// balance
        //                    decimal newBalance = 0;
        //                    if (agent.balanceType == 0)
        //                    {
        //                        if (amount <= (decimal)agent.balance)
        //                        {
        //                            inv.paid += amount;
        //                            inv.deserved = 0;
        //                            newBalance = (decimal)agent.balance - amount;
        //                            agent.balance = newBalance;
        //                        }
        //                        else
        //                        {
        //                            inv.paid += amount;
        //                            inv.deserved = 0;
        //                            newBalance = (decimal)amount - (decimal)agent.balance;
        //                            agent.balance = newBalance;
        //                            agent.balanceType = 1;
        //                        }

        //                        ct = entity.cashTransfer.Add(cashTr);
        //                        cashIds += ct.cashTransId;
        //                        entity.SaveChanges();
        //                    }
        //                    else if (agent.balanceType == 1)
        //                    {
        //                        newBalance = (decimal)agent.balance + amount;
        //                        agent.balance = newBalance;
        //                        entity.SaveChanges();
        //                    }
        //                    break;
        //            }
        //            return Ok(cashIds);
        //        }
        //    }
        //    else
        //        return Ok("false");

        //}
        [HttpPost]
        [Route("payOrderInvoice")]
        public IHttpActionResult payOrderInvoice(int invoiceId, int invStatusId, decimal amount, string payType, string cashTransfer)
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
                cashTransfer cashTr = JsonConvert.DeserializeObject<cashTransfer>(cashTransfer, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                using (incposdbEntities entity = new incposdbEntities())
                {
                    invoices inv = entity.invoices.Find(invoiceId);
                    agents agent = entity.agents.Find(inv.agentId);
                    invoiceStatus invStatus = entity.invoiceStatus.Find(invStatusId);
                    
                    //update invoice type
                    invStatus.status = "tr";
                    //add cashtransfer
                    cashTr.invId = inv.invoiceId;
                    cashTr.cash = amount;
                    cashTr.createDate = DateTime.Now;
                    cashTr.updateDate = DateTime.Now;
                    cashTr.updateUserId = cashTr.createUserId;

                    cashTransfer ct;
                    //update agent
                    switch (payType)
                    {
                        case "0":// cash - card - cheque - doc
                           
                            //update invoice
                            inv.paid += amount;
                            inv.deserved -= amount;
                            ct = entity.cashTransfer.Add(cashTr);
                           
                            // decrease agent balance
                            if (agent.balanceType == 0)
                            {
                                if (amount <= (decimal)agent.balance)
                                {
                                    agent.balance -= amount;
                                }
                                else
                                {
                                    agent.balance = amount - agent.balance;
                                    agent.balanceType = 1;
                                }
                            }
                            else if (agent.balanceType == 1)
                            {
                                if (amount <= (decimal)agent.balance)
                                {
                                    agent.balance -= amount;
                                }
                                else
                                {
                                    agent.balance = amount - agent.balance;
                                    agent.balanceType = 0;
                                }
                            }
                            break;
                        case "1":// balance
                            decimal newBalance = 0;
                            if (agent.balanceType == 0)
                            {
                                //cash
                                cashTr.transType = "balance";
                                if (amount <= (decimal)agent.balance)
                                {
                                    //invoice
                                    inv.paid += amount;
                                    inv.deserved -= amount;
                                    //agent
                                    newBalance = (decimal)agent.balance - amount;
                                    agent.balance = newBalance;
                                }
                                else
                                {
                                    //invoice
                                    inv.paid += agent.balance;
                                    inv.deserved -= agent.balance;
                                    //agent
                                    newBalance = (decimal)amount - (decimal)agent.balance;
                                    agent.balance = newBalance;
                                    agent.balanceType = 1;
                                    //cash
                                    cashTr.cash = newBalance;
                                }
                                ct = entity.cashTransfer.Add(cashTr);
                            }
                            else if (agent.balanceType == 1)
                            {
                                newBalance = (decimal)agent.balance + amount;
                                agent.balance = newBalance;
                            }
                            break;
                    }
                    entity.SaveChanges();

                    return Ok("true");
                }
            }
            else
                return Ok("false");

        }
        [HttpGet]
        [Route("GetLastNumOfCash")]
        public IHttpActionResult GetLastNumOfCash(string cashCode)
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
                List<string> numberList;
                int lastNum = 0;
                using (incposdbEntities entity = new incposdbEntities())
                {
                    numberList = entity.cashTransfer.Where(b => b.transNum.Contains(cashCode + "-")).Select(b => b.transNum).ToList();

                    for (int i = 0; i < numberList.Count; i++)
                    {
                        string code = numberList[i];
                        string s = code.Substring(code.LastIndexOf("-") + 1);
                        numberList[i] = s;
                    }
                    if (numberList.Count > 0)
                    {
                        numberList.Sort();
                        lastNum = int.Parse(numberList[numberList.Count - 1]);
                    }
                }
                return Ok(lastNum);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetLastNumOfDocNum")]
        public IHttpActionResult GetLastNumOfDocNum(string docNum)
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
                List<string> numberList;
                int lastNum = 0;
                using (incposdbEntities entity = new incposdbEntities())
                {
                    numberList = entity.cashTransfer.Where(b => b.docNum.Contains(docNum + "-")).Select(b => b.docNum).ToList();

                    for (int i = 0; i < numberList.Count; i++)
                    {
                        string code = numberList[i];
                        string s = code.Substring(code.LastIndexOf("-") + 1);
                        numberList[i] = s;
                    }
                    if (numberList.Count > 0)
                    {
                        numberList.Sort();
                        lastNum = int.Parse(numberList[numberList.Count - 1]);
                    }
                }
                return Ok(lastNum);
            }
            return NotFound();
        }

    }
    }


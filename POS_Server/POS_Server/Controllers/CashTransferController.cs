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
                                                        from jbb in jb.DefaultIfEmpty()
                                                        from jaa in ja.DefaultIfEmpty()
                                                        from jpp in jp.DefaultIfEmpty()
                                                        from juu in ju.DefaultIfEmpty()
                                                        from jpcc in jpcr.DefaultIfEmpty()
                                                        from jucc in juc.DefaultIfEmpty()
                                                        from jcrd in jcr.DefaultIfEmpty()
                                                        from jbbo in jbo.DefaultIfEmpty()
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
                                                            createUserName = jucc.name ,
                                                            createUserLName = jucc.lastname,
                                                            createUserJob =jucc.job,
                                                                cardName =jcrd.name,
                                                            bondDeserveDate=jbbo.deserveDate,
                                                            bondIsRecieved=jbbo.isRecieved,
                                                          
                                                        }).Where(C => ((type == "all") ? true : C.transType == type)
            && ((side == "all") ? true : C.side == side)).ToList();
                   
                    if(cachlist.Count>0 && side == "p")
                    {
                        CashTransferModel tempitem = null;
                        foreach ( CashTransferModel cashtItem in cachlist)
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
            bondId=C.bondId,
         
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
                        delList = allList.Where(C=> C.isConfirm==1 ).ToList();
                        if(delList!= null)
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
        public IHttpActionResult MovePosCash(int cashTransId,int userIdD)
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
                                       bondId=C.bondId,
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
                                                        }).Where(C => ((type == "all") ? true : C.transType == type)
                                && ((side == "all") ? true : C.side == side) && C.invId==invId).FirstOrDefault();

                  


                    if (cachtrans == null)
                        return NotFound();
                    else
                        return Ok(cachtrans);

                }
            }
            else
                return NotFound();
        }

    }
}

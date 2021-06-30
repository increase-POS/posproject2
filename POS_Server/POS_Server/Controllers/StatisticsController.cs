using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Statistics")]
    public class StatisticsController : ApiController
    {



        private decimal getupValues(int miniuId,int maxiuId,int itemId)
        {
            decimal val = 1;
            using (incposdbEntities entity = new incposdbEntities())
            {
                var iulist = entity.itemsUnits.Where(I => I.itemId == itemId).Select(I => new { I.unitId, I.itemId, I.subUnitId, I.itemUnitId, I.unitValue, });

                while(miniuId != maxiuId){
                var minitem = iulist.Where(I=> I.itemUnitId== miniuId).FirstOrDefault();

                var upitem = iulist.Where(I => I.subUnitId == minitem.unitId).FirstOrDefault();
                val = val * Convert.ToDecimal( upitem.unitValue);
                miniuId = upitem.itemUnitId;
                }
                if (val != 0)
                {
                val = 1 / val;
                }
                
                                  }
            return val;
        }
        private decimal getItemSubUnitAmount(int itemUnitId, int branchId)
        {
            decimal amount = 0;
            int subUnit = 0;
            int itemId = 0;
            int nextunitID = 0;
            int nextIUid = 0;
           decimal vale = 0;
            if (itemUnitId > 0)
            {




                using (incposdbEntities entity = new incposdbEntities())
                {
                    var nextunit = entity.itemsUnits.Where(I => I.subUnitId == itemUnitId)
                        .Select(x => new { x.itemUnitId, x.subUnitId, x.itemId, x.unitValue, x.unitId }).FirstOrDefault();
                     
                    var itemInLocs = (from b in entity.branches
                                      where b.branchId == branchId
                                      join s in entity.sections on b.branchId equals s.branchId
                                      join l in entity.locations on s.sectionId equals l.sectionId
                                      join il in entity.itemsLocations on l.locationId equals il.locationId
                                      where il.itemUnitId == nextunit.itemUnitId && il.quantity > 0
                                      select new
                                      {
                                          il.itemsLocId,
                                          il.quantity,
                                          il.itemUnitId,
                                          il.locationId,
                                          s.sectionId,
                                      }).ToList();
                    if (itemInLocs.Count > 0)
                    {
                        for (int i = 0; i < itemInLocs.Count; i++)
                        {
                            amount += Convert.ToDecimal(itemInLocs[i].quantity);
                        }

                        vale = getupValues(itemUnitId, nextunit.itemUnitId, (int)nextunit.itemId);
                        amount = amount * vale;

                        var itemunit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.itemUnitId, x.subUnitId ,x.itemId,x.unitValue,x.unitId}).FirstOrDefault();
                        if (itemunit != null)
                        {
                            
                            subUnit = (int)itemunit.unitId;
                            itemId = (int)itemunit.itemId;
                            nextunitID = (int)itemunit.subUnitId;

                        }

                        var nextUnit = entity.itemsUnits.Where(x => x.itemId == itemId && x.unitId == nextunitID).Select(x => new { x.unitId, x.itemId, x.subUnitId, x.itemUnitId, x.unitValue, }).FirstOrDefault();
                       if(nextUnit != null)
                        {
                            nextIUid = nextUnit.itemUnitId;
                        }
                        var downUnit = entity.itemsUnits.Where(x => x.itemId == itemId && x.subUnitId == subUnit).Select(x => new { x.unitId, x.itemId, x.subUnitId ,x.itemUnitId, x.unitValue, }).FirstOrDefault();
                     

                        if (downUnit != null)
                        {
                            if (Convert.ToDecimal(downUnit.unitValue) > 0)
                            {

                                // amount += Convert.ToDecimal(getItemSubUnitAmount(nextIUid, branchId)) / Convert.ToDecimal(downUnit.unitValue);
                                amount = amount+ Convert.ToDecimal(getItemSubUnitAmount(nextIUid, branchId)) / Convert.ToDecimal(downUnit.unitValue);
                            }
                           
                            return amount;
                        }
                        else
                        {
 return 0;
                        }
                       
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        private int getItemUnitAmount(int itemUnitId,int branchId)
        {
         
            int amount = 0;

            using (incposdbEntities entity = new incposdbEntities())
            {
                var itemInLocs = (from b in entity.branches
                                  where b.branchId == branchId
                                  join s in entity.sections on b.branchId equals s.branchId
                                  join l in entity.locations on s.sectionId equals l.sectionId
                                  join il in entity.itemsLocations on l.locationId equals il.locationId
                                  where il.itemUnitId == itemUnitId && il.quantity > 0
                                  select new
                                  {
                                      il.itemsLocId,
                                      il.quantity,
                                      il.itemUnitId,
                                      il.locationId,
                                      s.sectionId,
                                  }).ToList();
                for (int i = 0; i < itemInLocs.Count; i++)
                {
                    amount += (int) itemInLocs[i].quantity;
                }
                //amount  الكمية في الفرع لعنصر ووحدة قياس واحدة
                // جلب معرف الوحدة ومعرف العنصر
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                //جلب الوحدة الاعلى معرف الوحدة الاعلى وقيمتها بالنسبة للوحدة الادنى 
                var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (upperUnit != null)
                    //جلب الكمية للوحدة الاعلى في الفرع وضربها بقيمة الوحدة
                 amount += (int)upperUnit.unitValue * getItemUnitAmount(upperUnit.itemUnitId,branchId);
                return amount;
            }
       
        }

        // item quantity in location GetItemQtyInBranches()
        [HttpGet]
        [Route("GetItemQtyInBranches")]
        public IHttpActionResult GetItemQtyInBranches(int itemId,int UnitId,string BranchType)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int iuId = 0;
            int subUnit = 0;
            int subitemunitId = 0;
            string unitName = "";
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

                    var itemunit = entity.itemsUnits.Where(x => x.itemId == itemId && x.unitId == UnitId).Select(x => new { x.itemUnitId ,x.subUnitId}).FirstOrDefault();
                    if (itemunit != null)
                    {
                         iuId = itemunit.itemUnitId;//ref iuid
                        subUnit =(int)itemunit.subUnitId;
                    }
                    if( subUnit > 0)
                    {
                        var subitemunit = entity.itemsUnits.Where(x => x.itemId == itemId && x.unitId == subUnit).Select(x => new { x.itemUnitId, x.subUnitId }).FirstOrDefault();
                        if (subitemunit!=null)
                        {
                            subitemunitId= subitemunit.itemUnitId;
                        }
                    }
                    var unit = entity.units.Where(x => x.unitId == UnitId ).Select(x => new { x.name }).FirstOrDefault();
                    if (unit != null)
                    {
                        unitName = unit.name;
                    }
                 
                    var brList = (from IL in entity.itemsLocations
                                  from B in entity.branches
                                  from S in entity.sections.Where(x => x.branchId == B.branchId)
                                  from L in entity.locations.Where(x => x.locationId == IL.locationId && x.sectionId == S.sectionId)
                                      //   join L in entity.locations on IL.locationId equals L.locationId into JL
                                  join IU in entity.itemsUnits on IL.itemUnitId equals IU.itemUnitId
                                  join I in entity.items on IU.itemId equals I.itemId
                                  join U in entity.units on IU.unitId equals U.unitId

                                  // join L in entity.locations on S.sectionId equals L.sectionId into JLS
                                  join SS in entity.sections on B.branchId equals SS.branchId


                                  //    from e in db.Emails.Where(x => x.id_contact == c.id).DefaultIfEmpty()

                                  where IU.itemId == itemId
                              group new { IL, S, B, L, IU, I, U, SS } by (B.branchId) into g


                                  select new
                                  {
                                     
                                      itemsLocId = g.Select(i => i.IL.itemsLocId).FirstOrDefault(),
                                      branchName = g.Select(i => i.B.name).FirstOrDefault(),
                                      branchId = g.Select(i => i.B.branchId).FirstOrDefault(),
                                      sectionId= g.Select(i => i.S.sectionId).FirstOrDefault(),
                                    itemName=g.Select(i=> i.I.name).FirstOrDefault(),
                                    unitName= g.Select(i => i.I.name).FirstOrDefault(),
                                      //   quantity = g.Sum(i => i.IL.quantity),
                                      // quantity= getItemUnitAmount(iuId, g.FirstOrDefault().B.branchId),
                                      // quantity = getItemUnitAmount(iuId, 7),
                                      count = g.Count(),
                                      itemUnitId = iuId,
                                   

                                      /*
                                      B.branchId,
                                      B.name,
                                          IL.itemsLocId,
                                          IL.locationId,
                                          IL.itemUnitId,
                                          IU.unitValue,
                                          IU.subUnitId,
                                            IU.itemId,
                                            IU.unitId,
                                         itemName= I.name,
                                         sectionName=S.name,
                                         branchName= B.name,
                                         IL.quantity,
                                        S.sectionId,
                                        */
                                       
                                  }) ;

                    var groupitems = (from item in brList.AsEnumerable()
                                select new
                                {

                                    item.itemsLocId,
                                    item.branchName,
                                    item.branchId,
                                    item.itemName,
                                    item.itemUnitId,
                                    item.count,
                                    unitName,
                                    /*
                                  //  item.count,
                                    item.itemUnitId,
                                    item.subUnitId,
                                    item.unitValue,
                                    item.unitId,
                                    item.itemId,
                                    // item.quantity,
                                    */
                                  //  quantity = getItemUnitAmount(iuId, item.branchId) + getItemSubUnitAmount(subitemunitId, item.branchId),
                                   quantity = getItemSubUnitAmount(iuId, item.branchId),
                                }).ToList();

                    /*
                     var items =  myContext.Select(i => new {
                   Value1 = item.Value1,
                   Value2 = item.Value2
               })
               .AsEnumerable()
               .Select(i => new {
                   Value1 = TweakValue(item.Value1),
                   Value2 = TweakValue(item.Value2)
                });


                    var query = from item in myContext
            where item.Foo == bar
            orderby item.Something
            select new { item.Value1, item.Value2 };

var items = from item in query.AsEnumerable()
            select new {
                Value1 = TweakValue(item.Value1),
                Value2 = TweakValue(item.Value2)
            };

                     * */
                    if (groupitems == null)
                        return NotFound();
                    else
                        return Ok(groupitems);
                }
            }
            //else
            return NotFound();
        }

        // for report 
        //  فواتير المشتريات بكل انواعها بكل فرع
        [HttpGet]
        [Route("GetPurinv")]
        public IHttpActionResult GetPurinv()
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
                    var invListm = (from I in entity.invoices
                                    join B in entity.branches on I.branchId equals B.branchId into JB
                                    join A in entity.agents on I.agentId equals A.agentId into JA
                                    join U in entity.users on I.createUserId equals U.userId into JU
                                    join UPUSR in entity.users on I.updateUserId equals UPUSR.userId into JUPUSR
                                    join IM in entity.invoices on I.invoiceMainId equals IM.invoiceId into JIM
                                    join P in entity.pos on I.posId equals P.posId into JP
                                    from JBB in JB.DefaultIfEmpty()
                                    from JPP in JP.DefaultIfEmpty()
                                    from JUU in JU.DefaultIfEmpty()
                                    from JUPUS in JUPUSR.DefaultIfEmpty()
                                    from JIMM in JIM.DefaultIfEmpty()
                                    from JAA in JA.DefaultIfEmpty()
                                    where (I.invType == "p"|| I.invType == "pb" || I.invType == "pd" || I.invType == "pbd")
                                    // (branchType == "all" ? true : JBB.type == branchType)
                                    //   && System.DateTime.Compare((DateTime)startDate, (DateTime)I.invDate) <= 0
                                    //  && System.DateTime.Compare((DateTime)endDate, (DateTime)I.invDate) >= 0
                                    // I.invType == invtype
                                    //     && branchType == "all" ? true : JBB.type == branchType

                                    //  && startDate <= I.invDate && endDate >= I.invDate
                                    // &&  System.DateTime.Compare((DateTime)startDate,  I.invDate) <= 0 && System.DateTime.Compare((DateTime)endDate, I.invDate) >= 0
                                    //   group new { I, JBB } by (I.branchId) into g
                                    select new
                                    {
                                           I.invoiceId,
                                           I.invNumber,
                                           I.agentId,

                                           I.invType,
                                           I.total,
                                           I.totalNet,
                                           I.paid,
                                           I.deserved,
                                           I.deservedDate,
                                           I.invDate,
                                           I.invoiceMainId,
                                           I.invCase,
                                           I.invTime,
                                           I.notes,
                                           I.vendorInvNum,
                                           I.vendorInvDate,
                                           I.createUserId,
                                           I.updateDate,
                                           I.updateUserId,
                                           I.branchId,
                                           I.discountValue,
                                           I.discountType,
                                           I.tax,
                                           I.name,
                                           I.isApproved,
                                        branchName = JBB.name,
                                        branchType=JBB.type,
                                        posName=JPP.name,
                                        posCode= JPP.code,
                                        agentName =JAA.name,
                                        agentCode=JAA.code,
                                        cuserName= JUU.name,
                                        cuserLast = JUU.lastname,                                     
                                        cUserAccName=JUU.lastname,
                                        uuserName = JUPUS.name,
                                        uuserLast = JUPUS.lastname,
                                        uUserAccName = JUPUS.lastname,
                                        agentCompany=JAA.company,

                                        //username

                                        //  I.invoiceId,
                                        //    JBB.name
                                    }).ToList();

                    /*
          if(S.I.discountType == "1")
{
    return S.I.discountValue;
}else if(S.I.discountType == "2")
{
   return (S.I.discountValue / 100);
}
else
{
    return 0;
}
*/



                    if (invListm == null)
                        return NotFound();
                    else
                        return Ok(invListm);
                }

            }

            //else
            return NotFound();
        }




        // عدد العناصر في كل فاتورة


        [HttpGet]
        [Route("GetPurinvwithCount")]
        public IHttpActionResult GetPurinvwithCount()
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
                    var invListm = (from I in entity.invoices
                                    join B in entity.branches on I.branchId equals B.branchId into JB
                                    join A in entity.agents on I.agentId equals A.agentId into JA
                                    join U in entity.users on I.createUserId equals U.userId into JU
                                    join UPUSR in entity.users on I.updateUserId equals UPUSR.userId into JUPUSR
                                    join IM in entity.invoices on I.invoiceMainId equals IM.invoiceId into JIM
                                    join P in entity.pos on I.posId equals P.posId into JP
                                    join IT in entity.itemsTransfer on I.invoiceId equals IT.invoiceId into JIT
                                    from JBB in JB.DefaultIfEmpty()
                                    from JPP in JP.DefaultIfEmpty()
                                    from JUU in JU.DefaultIfEmpty()
                                    from JUPUS in JUPUSR.DefaultIfEmpty()
                                    from JIMM in JIM.DefaultIfEmpty()
                                    from JAA in JA.DefaultIfEmpty()
                                    from JITT in JIT.DefaultIfEmpty()

                                    where (I.invType == "p" || I.invType == "pb" || I.invType == "pd" || I.invType == "pbd")
                                    // (branchType == "all" ? true : JBB.type == branchType)
                                    //   && System.DateTime.Compare((DateTime)startDate, (DateTime)I.invDate) <= 0
                                    //  && System.DateTime.Compare((DateTime)endDate, (DateTime)I.invDate) >= 0
                                    // I.invType == invtype
                                    //     && branchType == "all" ? true : JBB.type == branchType

                                    //  && startDate <= I.invDate && endDate >= I.invDate
                                    // &&  System.DateTime.Compare((DateTime)startDate,  I.invDate) <= 0 && System.DateTime.Compare((DateTime)endDate, I.invDate) >= 0
                                    group new { I, JBB, JPP, JUU, JUPUS, JIMM, JAA, JITT } by (I.invoiceId) into g
                                    select new
                                    {
                                        countP = g.Select(S => S.JITT.invoiceId).Count(),
                                        invoiceId = g.Select(S => S.I.invoiceId).FirstOrDefault(),
                                        invNumber = g.Select(S => S.I.invNumber).FirstOrDefault(),
                                        agentId = g.Select(S => S.I.agentId).FirstOrDefault(),

                                        invType=g.Select(S=>S.I.invType ).FirstOrDefault(),
                                        total=g.Select(S=>S.I.total).FirstOrDefault(),
                                        totalNet=g.Select(S=>S.I.totalNet).FirstOrDefault(),
                                        paid=g.Select(S=>S.I.paid).FirstOrDefault(),
                                        deserved=g.Select(S=>S.I.deserved).FirstOrDefault(),
                                        deservedDate=g.Select(S=>S.I.deservedDate).FirstOrDefault(),
                                        invDate=g.Select(S=>S.I.invDate).FirstOrDefault(),
                                        invoiceMainId=g.Select(S=> S.I.invoiceMainId).FirstOrDefault(),
                                        invCase=g.Select(S=>S.I.invCase).FirstOrDefault(),
                                        invTime=g.Select(S=>S.I.invTime).FirstOrDefault(),
                                        notes=g.Select(S=>S.I.notes).FirstOrDefault(),
                                        vendorInvNum=g.Select(S=>S.I.vendorInvNum).FirstOrDefault(),
                                        vendorInvDate=g.Select(S=>S.I.vendorInvDate).FirstOrDefault(),
                                        createUserId=g.Select(S=>S.I.createUserId).FirstOrDefault(),
                                        updateDate=g.Select(S=>S.I.updateDate).FirstOrDefault(),
                                        updateUserId=g.Select(S=>S.I.updateUserId).FirstOrDefault(),
                                        branchId=g.Select(S=>S.I.branchId).FirstOrDefault(),
                                        discountValue=g.Select(S=>S.I.discountValue).FirstOrDefault(),
                                        discountType=g.Select(S=>S.I.discountType).FirstOrDefault(),
                                        tax=g.Select(S=>S.I.tax).FirstOrDefault(),
                                        name=g.Select(S=>S.I.name).FirstOrDefault(),
                                        isApproved = g.Select(S => S.I.isApproved).FirstOrDefault(),
                                        branchName = g.Select(S => S.JBB.name).FirstOrDefault(),
                                        branchType = g.Select(S => S.JBB.type).FirstOrDefault(),
                                        posName = g.Select(S => S.JPP.name).FirstOrDefault(),
                                        posCode = g.Select(S => S.JPP.code).FirstOrDefault(),
                                        agentName = g.Select(S => S.JAA.name).FirstOrDefault(),
                                        agentCode = g.Select(S => S.JAA.code).FirstOrDefault(),
                                        cuserName = g.Select(S => S.JUU.name).FirstOrDefault(),
                                        cuserLast = g.Select(S => S.JUU.lastname).FirstOrDefault(),
                                        cUserAccName = g.Select(S => S.JUU.lastname).FirstOrDefault(),
                                        uuserName = g.Select(S => S.JUPUS.name).FirstOrDefault(),
                                        uuserLast = g.Select(S => S.JUPUS.lastname).FirstOrDefault(),
                                        uUserAccName = g.Select(S => S.JUPUS.lastname).FirstOrDefault(),
                                        agentCompany = g.Select(S => S.JAA.company).FirstOrDefault(),
                                        /*
                                        I.invoiceId,
                                        I.invNumber,
                                        I.agentId,

                                        I.invType,
                                        I.total,
                                        I.totalNet,
                                        I.paid,
                                        I.deserved,
                                        I.deservedDate,
                                        I.invDate,
                                        I.invoiceMainId,
                                        I.invCase,
                                        I.invTime,
                                        I.notes,
                                        I.vendorInvNum,
                                        I.vendorInvDate,
                                        I.createUserId,
                                        I.updateDate,
                                        I.updateUserId,
                                        I.branchId,
                                        I.discountValue,
                                        I.discountType,
                                        I.tax,
                                        I.name,
                                        I.isApproved,
                                        branchName = JBB.name,
                                        branchType = JBB.type,
                                        posName = JPP.name,
                                        posCode = JPP.code,
                                        agentName = JAA.name,
                                        agentCode = JAA.code,
                                        cuserName = JUU.name,
                                        cuserLast = JUU.lastname,
                                        cUserAccName = JUU.lastname,
                                        uuserName = JUPUS.name,
                                        uuserLast = JUPUS.lastname,
                                        uUserAccName = JUPUS.lastname,
                                        agentCompany = JAA.company,
                                        */
                                        //username

                                        //  I.invoiceId,
                                        //    JBB.name
                                    }).ToList();

                    /*
          if(S.I.discountType == "1")
{
    return S.I.discountValue;
}else if(S.I.discountType == "2")
{
   return (S.I.discountValue / 100);
}
else
{
    return 0;
}
*/



                    if (invListm == null)
                        return NotFound();
                    else
                        return Ok(invListm);
                }

            }

            //else
            return NotFound();
        }
        // item quantity in location GetItemQtyInBranches()
        // عدد الفواتير في كل فرع
        [HttpGet]
        [Route("GetinvInBranch")]
        public IHttpActionResult GetinvInBranch()
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
                    var invListm = (from B in entity.branches.Distinct()
                                    from I in entity.invoices.Where(x => x.branchId == B.branchId).Distinct()
                                        // from P in entity.pos.Where(x => x.posId == I.posId)


                                   // from IT in entity.itemsTransfer.Where(x => x.invoiceId == I.invoiceId).Distinct()
                                        // from JBB in JB.DefaultIfEmpty()


                                        //    from JIMM in JIM.DefaultIfEmpty()

                                        //  from JITT in JIT.DefaultIfEmpty()

                                    where (I.invType == "p" || I.invType == "pb" || I.invType == "pd" || I.invType == "pbd")
                                      group new { I, B } by (B.branchId) into g
                                    select new
                                    {

                                     
                                        count = g.Select(S=>S.I.invoiceId).Count(),
                                  
                                        invType = g.Select(S => S.I.invType).FirstOrDefault(),
                                        total = g.Sum(S => S.I.total),
                                        totalNet = g.Sum(S => S.I.totalNet),
                                        paid = g.Sum(S => S.I.paid),
                                        deserved = g.Sum(S => S.I.deserved),
                                        
                                        branchId = g.Select(S => S.I.branchId).FirstOrDefault(),
                                        discountValue = g.Select(S => S.I.discountValue).FirstOrDefault(),
                                        discountType = g.Select(S => S.I.discountType).FirstOrDefault(),
                                        tax = g.Select(S => S.I.tax).FirstOrDefault(),
                                
                                     
                                        name = g.Select(S => S.B.name).FirstOrDefault(),
                                        branchType = g.Select(S => S.B.type).FirstOrDefault(),
                                        //posName = g.Select(S => S.P.name).FirstOrDefault(),
                                      //  posCode = g.Select(S => S.P.code).FirstOrDefault(),

                                     
                                   //  count
                             

                                 
                                    }).ToList();




                    if (invListm == null)
                        return NotFound();
                    else
                        return Ok(invListm);
                }

            }

            //else
            return NotFound();
        }



        //  الفواتير بكل نقطة عددPOs
        // 
        [HttpGet]
        [Route("GetPoswithInvCount")]
        public IHttpActionResult GetPoswithInvCount()
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
                    var invListm = (from I in entity.invoices
                                    join B in entity.branches on I.branchId equals B.branchId into JB
                                    join A in entity.agents on I.agentId equals A.agentId into JA
                                    join U in entity.users on I.createUserId equals U.userId into JU
                                    join UPUSR in entity.users on I.updateUserId equals UPUSR.userId into JUPUSR
                                    join IM in entity.invoices on I.invoiceMainId equals IM.invoiceId into JIM
                                    join P in entity.pos on I.posId equals P.posId into JP
                               
                                    from JBB in JB.DefaultIfEmpty()
                                    from JPP in JP.DefaultIfEmpty()
                                    from JUU in JU.DefaultIfEmpty()
                                    from JUPUS in JUPUSR.DefaultIfEmpty()
                                    from JIMM in JIM.DefaultIfEmpty()
                                    from JAA in JA.DefaultIfEmpty()
                                   

                                    where (I.invType == "p" || I.invType == "pb" || I.invType == "pd" || I.invType == "pbd")
                                  
                                    // &&  System.DateTime.Compare((DateTime)startDate,  I.invDate) <= 0 && System.DateTime.Compare((DateTime)endDate, I.invDate) >= 0
                                    group new { I, JBB, JPP, JUU, JUPUS, JIMM, JAA } by (JPP.posId) into g
                                    select new
                                    {
                                        countP = g.Select(S => S.I.invoiceId).Count(),
                                        invoiceId = g.Select(S => S.I.invoiceId).FirstOrDefault(),
                                        invNumber = g.Select(S => S.I.invNumber).FirstOrDefault(),
                                        agentId = g.Select(S => S.I.agentId).FirstOrDefault(),

                                        invType = g.Select(S => S.I.invType).FirstOrDefault(),
                                        total = g.Select(S => S.I.total).FirstOrDefault(),
                                        totalNet = g.Select(S => S.I.totalNet).FirstOrDefault(),
                                        paid = g.Select(S => S.I.paid).FirstOrDefault(),
                                        deserved = g.Select(S => S.I.deserved).FirstOrDefault(),
                                        deservedDate = g.Select(S => S.I.deservedDate).FirstOrDefault(),
                                        invDate = g.Select(S => S.I.invDate).FirstOrDefault(),
                                        invoiceMainId = g.Select(S => S.I.invoiceMainId).FirstOrDefault(),
                                        invCase = g.Select(S => S.I.invCase).FirstOrDefault(),
                                        invTime = g.Select(S => S.I.invTime).FirstOrDefault(),
                                        notes = g.Select(S => S.I.notes).FirstOrDefault(),
                                        vendorInvNum = g.Select(S => S.I.vendorInvNum).FirstOrDefault(),
                                        vendorInvDate = g.Select(S => S.I.vendorInvDate).FirstOrDefault(),
                                        createUserId = g.Select(S => S.I.createUserId).FirstOrDefault(),
                                        updateDate = g.Select(S => S.I.updateDate).FirstOrDefault(),
                                        updateUserId = g.Select(S => S.I.updateUserId).FirstOrDefault(),
                                        branchId = g.Select(S => S.I.branchId).FirstOrDefault(),
                                        discountValue = g.Select(S => S.I.discountValue).FirstOrDefault(),
                                        discountType = g.Select(S => S.I.discountType).FirstOrDefault(),
                                        tax = g.Select(S => S.I.tax).FirstOrDefault(),
                                        name = g.Select(S => S.I.name).FirstOrDefault(),
                                        isApproved = g.Select(S => S.I.isApproved).FirstOrDefault(),
                                        branchName = g.Select(S => S.JBB.name).FirstOrDefault(),
                                        branchType = g.Select(S => S.JBB.type).FirstOrDefault(),
                                        posName = g.Select(S => S.JPP.name).FirstOrDefault(),
                                        posCode = g.Select(S => S.JPP.code).FirstOrDefault(),
                                        agentName = g.Select(S => S.JAA.name).FirstOrDefault(),
                                        agentCode = g.Select(S => S.JAA.code).FirstOrDefault(),
                                        cuserName = g.Select(S => S.JUU.name).FirstOrDefault(),
                                        cuserLast = g.Select(S => S.JUU.lastname).FirstOrDefault(),
                                        cUserAccName = g.Select(S => S.JUU.username).FirstOrDefault(),
                                        uuserName = g.Select(S => S.JUPUS.name).FirstOrDefault(),
                                        uuserLast = g.Select(S => S.JUPUS.lastname).FirstOrDefault(),
                                        uUserAccName = g.Select(S => S.JUPUS.username).FirstOrDefault(),
                                        agentCompany = g.Select(S => S.JAA.company).FirstOrDefault(),
                                        /*
                                
                                        */
                                        //username

                                        //  I.invoiceId,
                                        //    JBB.name
                                    }).ToList();

                    /*
          if(S.I.discountType == "1")
{
    return S.I.discountValue;
}else if(S.I.discountType == "2")
{
   return (S.I.discountValue / 100);
}
else
{
    return 0;
}
*/



                    if (invListm == null)
                        return NotFound();
                    else
                        return Ok(invListm);
                }

            }

            //else
            return NotFound();
        }

        // الفواتير في كل نقطة

        [HttpGet]
        [Route("GetPoswithInv")]
        public IHttpActionResult GetPoswithInv()
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
                    var invListm = (from I in entity.invoices
                                    join B in entity.branches on I.branchId equals B.branchId into JB
                                    join A in entity.agents on I.agentId equals A.agentId into JA
                                    join U in entity.users on I.createUserId equals U.userId into JU
                                    join UPUSR in entity.users on I.updateUserId equals UPUSR.userId into JUPUSR
                                    join IM in entity.invoices on I.invoiceMainId equals IM.invoiceId into JIM
                                    join P in entity.pos on I.posId equals P.posId into JP

                                    from JBB in JB.DefaultIfEmpty()
                                    from JPP in JP.DefaultIfEmpty()
                                    from JUU in JU.DefaultIfEmpty()
                                    from JUPUS in JUPUSR.DefaultIfEmpty()
                                    from JIMM in JIM.DefaultIfEmpty()
                                    from JAA in JA.DefaultIfEmpty()


                                    where (I.invType == "p" || I.invType == "pb" || I.invType == "pd" || I.invType == "pbd")
                                    // (branchType == "all" ? true : JBB.type == branchType)
                                    //   && System.DateTime.Compare((DateTime)startDate, (DateTime)I.invDate) <= 0
                                    //  && System.DateTime.Compare((DateTime)endDate, (DateTime)I.invDate) >= 0
                                    // I.invType == invtype
                                    //     && branchType == "all" ? true : JBB.type == branchType

                                    //  && startDate <= I.invDate && endDate >= I.invDate
                                    // &&  System.DateTime.Compare((DateTime)startDate,  I.invDate) <= 0 && System.DateTime.Compare((DateTime)endDate, I.invDate) >= 0
                                  
                                    select new
                                    {

                                                        I.invoiceId,
                                                        I.invNumber,
                                                        I.agentId,
                                                        I.invType,
                                                        I.total,
                                                        I.totalNet,
                                                        I.paid,
                                                        I.deserved,
                                                        I.deservedDate,
                                                        I.invDate,
                                                        I.invoiceMainId,
                                                        I.invCase,
                                                        I.invTime,
                                                        I.notes,
                                                        I.vendorInvNum,
                                                        I.vendorInvDate,
                                                        I.createUserId,
                                                        I.updateDate,
                                                        I.updateUserId,
                                                        I.branchId,
                                                        I.discountValue,
                                                        I.discountType,
                                                        I.tax,
                                                        I.name,
                                                        I.isApproved,


                                
                                    

                                                        branchName =JBB.name,
                                                        branchType =JBB.type,
                                                       posName  =JPP.name,
                                                       posCode  =JPP.code,
                                                       agentName  =JAA.name,
                                                        agentCode =JAA.code,
                                                        cuserName =JUU.name,
                                                        cuserLast =JUU.lastname,
                                                        cUserAccName =JUU.username,
                                                        uuserName =JUPUS.name,
                                                         uuserLast=JUPUS.lastname,
                                                        uUserAccName =JUPUS.username,
                                                      agentCompany   =JAA.company,

                                      
                                        //username

                                        //  I.invoiceId,
                                        //    JBB.name
                                    }).ToList();

                    /*
          if(S.I.discountType == "1")
{
    return S.I.discountValue;
}else if(S.I.discountType == "2")
{
   return (S.I.discountValue / 100);
}
else
{
    return 0;
}
*/



                    if (invListm == null)
                        return NotFound();
                    else
                        return Ok(invListm);
                }

            }

            //else
            return NotFound();
        }


        // عدد فواتير المشتريات ومرتجع المشتريات ومسودات كل فرع
        [HttpGet]
        [Route("GetinvCountByBranch")]
        public IHttpActionResult GetinvCountByBranch( )
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
                    var invListm = (from I in entity.invoices
                                    join B in entity.branches on I.branchId equals B.branchId into JB
                                    from JBB in JB.DefaultIfEmpty()
                                    where (JBB.branchId != 1)
                                 && (I.invType == "p" || I.invType == "pb" || I.invType == "pd" || I.invType == "pbd")
                                 
                                    // &&  System.DateTime.Compare((DateTime)startDate,  I.invDate) <= 0 && System.DateTime.Compare((DateTime)endDate, I.invDate) >= 0
                                    group new { I, JBB } by (I.branchId) into g
                                    select new
                                    {
                                        branchId = g.Key,
                                        branchName = g.Select(t => t.JBB.name).FirstOrDefault(),
                                       
                                        countP = g.Where(t => t.I.invType == "p").Count(),
                                        countPb = g.Where(t => t.I.invType == "pb").Count(),
                                        //  countS = g.Where(t => t.I.invType == "s").Count(),
                                        countD = g.Where(t => t.I.invType == "pd" || t.I.invType == "pbd").Count(),
                                      //  totalS = g.Where(t => t.I.invType == "s").Sum(S => S.I.total),
                                        //totalNetS = g.Where(t => t.I.invType == "s").Sum(S => S.I.totalNet),
                                        /*
                                        totalP = g.Where(t => t.I.invType == "p").Sum(S => S.I.total),
                                        totalPb = g.Where(t => t.I.invType == "pb").Sum(S => S.I.total),
                                        totalD = g.Where(t => t.I.invType == "pd" || t.I.invType == "pbd").Sum(S => S.I.total),
                                       
                                        totalNetP = g.Where(t => t.I.invType == "p").Sum(S => S.I.totalNet),
                                        totalNetPb = g.Where(t => t.I.invType == "pb").Sum(S => S.I.totalNet),
                                        totalNetD = g.Where(t => t.I.invType == "pd" || t.I.invType == "pbd").Sum(S => S.I.totalNet),
                                      
                                        paid = g.Where(t => t.I.invType == "p").Sum(S => S.I.paid),
                                        deserved = g.Where(t => t.I.invType == "p").Sum(S => S.I.deserved),
                                        discountValue = g.Where(t => t.I.invType == "p").Sum(S => S.I.discountType == "1" ? S.I.discountValue : (S.I.discountType == "2" ? (S.I.discountValue / 100) : 0)),
                                      
                                        paidPb = g.Where(t => t.I.invType == "pb").Sum(S => S.I.paid),
                                        deservedPb = g.Where(t => t.I.invType == "pb").Sum(S => S.I.deserved),
                                        discountValuePb = g.Where(t => t.I.invType == "pb").Sum(S => S.I.discountType == "1" ? S.I.discountValue : (S.I.discountType == "2" ? (S.I.discountValue / 100) : 0)),
                                           */                             
                                    }).ToList();

                    /*
          if(S.I.discountType == "1")
{
    return S.I.discountValue;
}else if(S.I.discountType == "2")
{
   return (S.I.discountValue / 100);
}
else
{
    return 0;
}
*/



                    if (invListm == null)
                        return NotFound();
                    else
                        return Ok(invListm);
                }

            }

            //else
            return NotFound();
        }


        /*
        //  فواتير المشتريات ومرتجع المشتريات ومسودات كل فرع
        [HttpGet]
        [Route("GetinvTypeByBranch")]
        public IHttpActionResult GetinvTypeByBranch()
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
                    var invListm = (from I in entity.invoices
                                    join B in entity.branches on I.branchId equals B.branchId into JB
                                    from JBB in JB.DefaultIfEmpty()
                                    where (JBB.branchId != 1)
                                 && (I.invType == "p" || I.invType == "pb" || I.invType == "pd" || I.invType == "pbd")

                                    // &&  System.DateTime.Compare((DateTime)startDate,  I.invDate) <= 0 && System.DateTime.Compare((DateTime)endDate, I.invDate) >= 0
                                   
                                    select new
                                    {
                                        branchId = g.Key,
                                        branchName = g.Select(t => t.JBB.name).FirstOrDefault(),

                                        countP = g.Where(t => t.I.invType == "p").Count(),
                                        countPb = g.Where(t => t.I.invType == "pb").Count(),
                                        //  countS = g.Where(t => t.I.invType == "s").Count(),
                                        countD = g.Where(t => t.I.invType == "pd" || t.I.invType == "pbd").Count(),
                                        //  totalS = g.Where(t => t.I.invType == "s").Sum(S => S.I.total),
                                        //totalNetS = g.Where(t => t.I.invType == "s").Sum(S => S.I.totalNet),
                                      
                                        totalP = g.Where(t => t.I.invType == "p").Sum(S => S.I.total),
                                        totalPb = g.Where(t => t.I.invType == "pb").Sum(S => S.I.total),
                                        totalD = g.Where(t => t.I.invType == "pd" || t.I.invType == "pbd").Sum(S => S.I.total),
                                       
                                        totalNetP = g.Where(t => t.I.invType == "p").Sum(S => S.I.totalNet),
                                        totalNetPb = g.Where(t => t.I.invType == "pb").Sum(S => S.I.totalNet),
                                        totalNetD = g.Where(t => t.I.invType == "pd" || t.I.invType == "pbd").Sum(S => S.I.totalNet),
                                      
                                        paid = g.Where(t => t.I.invType == "p").Sum(S => S.I.paid),
                                        deserved = g.Where(t => t.I.invType == "p").Sum(S => S.I.deserved),
                                        discountValue = g.Where(t => t.I.invType == "p").Sum(S => S.I.discountType == "1" ? S.I.discountValue : (S.I.discountType == "2" ? (S.I.discountValue / 100) : 0)),
                                       /*
                                        paidPb = g.Where(t => t.I.invType == "pb").Sum(S => S.I.paid),
                                        deservedPb = g.Where(t => t.I.invType == "pb").Sum(S => S.I.deserved),
                                        discountValuePb = g.Where(t => t.I.invType == "pb").Sum(S => S.I.discountType == "1" ? S.I.discountValue : (S.I.discountType == "2" ? (S.I.discountValue / 100) : 0)),
                                         
                                    }).ToList();

                    /*
          if(S.I.discountType == "1")
{
    return S.I.discountValue;
}else if(S.I.discountType == "2")
{
   return (S.I.discountValue / 100);
}
else
{
    return 0;
}




                    if (invListm == null)
                        return NotFound();
                    else
                        return Ok(invListm);
                }

            }

            //else
            return NotFound();
        }
        */
    }
}
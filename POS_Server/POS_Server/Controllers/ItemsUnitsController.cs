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
using System.Data.Entity.SqlServer;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/ItemsUnits")]
    public class ItemsUnitsController : ApiController
    {
        List<int> itemUnitsIds = new List<int>();
        private Classes.Calculate Calc = new Classes.Calculate();
        [HttpPost]
        [Route("Get")]
        public string Get(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request); 
            if (TokenManager.GetPrincipal(token) == null) //int groupId
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int itemId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                        itemId = int.Parse(c.Value);
                }
                try
                {

                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var itemUnitsList = (from IU in entity.itemsUnits
                                             where (IU.itemId == itemId && IU.isActive == 1)
                                             join u in entity.units on IU.unitId equals u.unitId into lj
                                             from v in lj.DefaultIfEmpty()
                                             join u1 in entity.units on IU.subUnitId equals u1.unitId into tj
                                             from v1 in tj.DefaultIfEmpty()
                                             select new ItemUnitModel()
                                             {
                                                 itemUnitId = IU.itemUnitId,
                                                 unitId = IU.unitId,
                                                 mainUnit = v.name,
                                                 createDate = IU.createDate,
                                                 createUserId = IU.createUserId,
                                                 defaultPurchase = IU.defaultPurchase,
                                                 defaultSale = IU.defaultSale,
                                                 price = IU.price,
                                                 subUnitId = IU.subUnitId,
                                                 smallUnit = v1.name,
                                                 unitValue = IU.unitValue,
                                                 barcode = IU.barcode,
                                                 updateDate = IU.updateDate,
                                                 updateUserId = IU.updateUserId,
                                                 storageCostId = IU.storageCostId,

                                             })
                                                         .ToList();
                        return TokenManager.GenerateToken(itemUnitsList);

                    }
                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }
            }

            //        var re = Request;
            //        var headers = re.Headers;
            //        string token = "";
            //        if (headers.Contains("APIKey"))
            //        {
            //            token = headers.GetValues("APIKey").First();
            //        }
            //        Validation validation = new Validation();
            //        bool valid = validation.CheckApiKey(token);

            //        if (valid) // APIKey is valid
            //        {
            //            using (incposdbEntities entity = new incposdbEntities())
            //            {
            //                var itemUnitsList = (from IU in entity.itemsUnits
            //                                     where (IU.itemId == itemId && IU.isActive == 1)
            //                                     join u in entity.units on IU.unitId equals u.unitId into lj
            //                                     from v in lj.DefaultIfEmpty()
            //                                     join u1 in entity.units on IU.subUnitId equals u1.unitId into tj
            //                                     from v1 in tj.DefaultIfEmpty()
            //                                     select new ItemUnitModel()
            //                                     {
            //                                         itemUnitId = IU.itemUnitId,
            //                                         unitId = IU.unitId,
            //                                         mainUnit = v.name,
            //                                         createDate = IU.createDate,
            //                                         createUserId = IU.createUserId,
            //                                         defaultPurchase = IU.defaultPurchase,
            //                                         defaultSale = IU.defaultSale,
            //                                         price = IU.price,
            //                                         subUnitId = IU.subUnitId,
            //                                         smallUnit = v1.name,
            //                                         unitValue = IU.unitValue,
            //                                         barcode = IU.barcode,
            //                                         updateDate = IU.updateDate,
            //                                         updateUserId = IU.updateUserId,
            //                                       storageCostId =IU.storageCostId,

            //})
            //                                     .ToList();

            //                if (itemUnitsList == null)
            //                    return NotFound();
            //                else
            //                    return Ok(itemUnitsList);
            //            }
            //        }
            //        //else
            //        return NotFound();
        }
        [HttpPost]
        [Route("GetById")]
        public string GetById(string token)
        {

            // public string GetUsersByGroupId(string token)int itemUnitId
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //int groupId
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int itemUnitId = 0;


                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemUnitId")
                    {
                        itemUnitId = int.Parse(c.Value);
                    }


                }

                // DateTime cmpdate = DateTime.Now.AddDays(newdays);
                try
                {

                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var itemUnitsList = (from IU in entity.itemsUnits
                                             where (IU.itemUnitId == itemUnitId)
                                             join u in entity.units on IU.unitId equals u.unitId into lj
                                             from v in lj.DefaultIfEmpty()
                                             join u1 in entity.units on IU.subUnitId equals u1.unitId into tj
                                             from v1 in tj.DefaultIfEmpty()
                                             select new ItemUnitModel()
                                             {
                                                 itemUnitId = IU.itemUnitId,
                                                 unitId = IU.unitId,
                                                 itemId = IU.itemId,
                                                 createDate = IU.createDate,
                                                 createUserId = IU.createUserId,
                                                 defaultPurchase = IU.defaultPurchase,
                                                 defaultSale = IU.defaultSale,
                                                 price = IU.price,
                                                 subUnitId = IU.subUnitId,

                                                 unitValue = IU.unitValue,
                                                 barcode = IU.barcode,
                                                 updateDate = IU.updateDate,
                                                 updateUserId = IU.updateUserId,
                                                 storageCostId = IU.storageCostId,
                                                 isActive = IU.isActive,
                                             })
                                                         .FirstOrDefault();
                        return TokenManager.GenerateToken(itemUnitsList);

                    }
                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }
            }

            //        var re = Request;
            //        var headers = re.Headers;
            //        string token = "";
            //        if (headers.Contains("APIKey"))
            //        {
            //            token = headers.GetValues("APIKey").First();
            //        }
            //        Validation validation = new Validation();
            //        bool valid = validation.CheckApiKey(token);

            //        if (valid) // APIKey is valid
            //        {
            //            using (incposdbEntities entity = new incposdbEntities())
            //            {
            //                var itemUnitsList = (from IU in entity.itemsUnits
            //                                     where (IU.itemUnitId == itemUnitId )
            //                                     join u in entity.units on IU.unitId equals u.unitId into lj
            //                                     from v in lj.DefaultIfEmpty()
            //                                     join u1 in entity.units on IU.subUnitId equals u1.unitId into tj
            //                                     from v1 in tj.DefaultIfEmpty()
            //                                     select new ItemUnitModel()
            //                                     {
            //                                         itemUnitId = IU.itemUnitId,
            //                                         unitId = IU.unitId,
            //                                         itemId = IU.itemId,
            //                                         createDate = IU.createDate,
            //                                         createUserId = IU.createUserId,
            //                                         defaultPurchase = IU.defaultPurchase,
            //                                         defaultSale = IU.defaultSale,
            //                                         price = IU.price,
            //                                         subUnitId = IU.subUnitId,

            //                                         unitValue = IU.unitValue,
            //                                         barcode = IU.barcode,
            //                                         updateDate = IU.updateDate,
            //                                         updateUserId = IU.updateUserId,
            //                                       storageCostId =IU.storageCostId,
            //                                       isActive = IU.isActive,
            //})
            //                                     .FirstOrDefault();

            //                if (itemUnitsList == null)
            //                    return NotFound();
            //                else
            //                    return Ok(itemUnitsList);
            //            }
            //        }
            //        //else
            //        return NotFound();
        }
        [HttpPost]
        [Route("GetAll")]
        public string GetAll(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null)
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int itemId = 0;

                bool canDelete = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                        itemId = int.Parse(c.Value);
                }

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                {
                    var itemUnitsList = (from IU in entity.itemsUnits
                                         where (IU.itemId == itemId)
                                         join u in entity.units on IU.unitId equals u.unitId into lj
                                         from v in lj.DefaultIfEmpty()
                                         join u1 in entity.units on IU.subUnitId equals u1.unitId into tj
                                         from v1 in tj.DefaultIfEmpty()
                                         select new ItemUnitModel()
                                         {
                                             itemUnitId = IU.itemUnitId,
                                             unitId = IU.unitId,
                                             mainUnit = v.name,
                                             createDate = IU.createDate,
                                             createUserId = IU.createUserId,
                                             defaultPurchase = IU.defaultPurchase,
                                             defaultSale = IU.defaultSale,
                                             price = IU.price,
                                             subUnitId = IU.subUnitId,
                                             smallUnit = v1.name,
                                             unitValue = IU.unitValue,
                                             barcode = IU.barcode,
                                             updateDate = IU.updateDate,
                                             updateUserId = IU.updateUserId,
                                             storageCostId = IU.storageCostId,
                                             isActive = IU.isActive,
                                         })
                                         .ToList();
                    foreach (ItemUnitModel um in itemUnitsList)
                    {
                        canDelete = false;
                        if (um.isActive == 1)
                        {
                            var purItem = entity.itemsTransfer.Where(x => x.itemUnitId == um.itemUnitId).Select(b => new { b.itemsTransId, b.itemUnitId }).FirstOrDefault();
                            var packages = entity.packages.Where(x => x.childIUId == um.itemUnitId || x.packageId == um.itemUnitId).Select(x => new { x.packageId, x.parentIUId }).FirstOrDefault();
                            if (purItem == null && packages == null)
                                canDelete = true;
                        }
                        um.canDelete = canDelete;
                    }

                    return TokenManager.GenerateToken(itemUnitsList);

                }
                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }
                //}

                //        var re = Request;
                //        var headers = re.Headers;
                //        string token = "";
                //        if (headers.Contains("APIKey"))
                //        {
                //            token = headers.GetValues("APIKey").First();
                //        }
                //        Validation validation = new Validation();
                //        bool valid = validation.CheckApiKey(token);
                //        Boolean canDelete = false;
                //        if (valid) // APIKey is valid
                //        {
                //            using (incposdbEntities entity = new incposdbEntities())
                //            {
                //                var itemUnitsList = (from IU in entity.itemsUnits
                //                                     where (IU.itemId == itemId )
                //                                     join u in entity.units on IU.unitId equals u.unitId into lj
                //                                     from v in lj.DefaultIfEmpty()
                //                                     join u1 in entity.units on IU.subUnitId equals u1.unitId into tj
                //                                     from v1 in tj.DefaultIfEmpty()
                //                                     select new ItemUnitModel()
                //                                     {
                //                                         itemUnitId = IU.itemUnitId,
                //                                         unitId = IU.unitId,
                //                                         mainUnit = v.name,
                //                                         createDate = IU.createDate,
                //                                         createUserId = IU.createUserId,
                //                                         defaultPurchase = IU.defaultPurchase,
                //                                         defaultSale = IU.defaultSale,
                //                                         price = IU.price,
                //                                         subUnitId = IU.subUnitId,
                //                                         smallUnit = v1.name,
                //                                         unitValue = IU.unitValue,
                //                                         barcode = IU.barcode,
                //                                         updateDate = IU.updateDate,
                //                                         updateUserId = IU.updateUserId,
                //                                       storageCostId =IU.storageCostId,
                //                                       isActive = IU.isActive,
                //})
                //                                     .ToList();
                //                foreach(ItemUnitModel um in itemUnitsList)
                //                {
                //                    canDelete = false;
                //                    if (um.isActive == 1)
                //                    {
                //                        var purItem = entity.itemsTransfer.Where(x => x.itemUnitId == um.itemUnitId).Select(b => new { b.itemsTransId, b.itemUnitId }).FirstOrDefault();
                //                        var packages = entity.packages.Where(x => x.childIUId == um.itemUnitId || x.packageId == um.itemUnitId).Select(x => new { x.packageId, x.parentIUId }).FirstOrDefault();
                //                        if (purItem == null && packages == null)
                //                            canDelete = true;
                //                    }
                //                    um.canDelete = canDelete;
                //                }
                //                if (itemUnitsList == null)
                //                    return NotFound();
                //                else
                //                    return Ok(itemUnitsList);
                //            }
                //        }
                //        //else
                //        return NotFound();
                // }
            }
        }
        // add or update item unit
        [HttpPost]
        [Route("Save")]
        public string Save(string token)
        {

            string message = "";

            //string itemsUnitsObject

          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                string Object = "";
                itemsUnits newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Object")
                    {
                        Object = c.Value.Replace("\\", string.Empty);
                        Object = Object.Trim('"');
                        newObject = JsonConvert.DeserializeObject<itemsUnits>(Object, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
                if (newObject != null)
                {

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
                            var itemUnitEntity = entity.Set<itemsUnits>();
                            if (newObject.itemUnitId == 0)
                            {
                                var iu = entity.itemsUnits.Where(x => x.itemId == newObject.itemId).FirstOrDefault();
                                if (iu == null)
                                {
                                    newObject.defaultSale = 1;
                                    newObject.defaultPurchase = 1;
                                }
                                else
                                {
                                    //create
                                    // set the other default sale or purchase to 0 if the new object.default is 1

                                    if (newObject.defaultSale == 1)
                                    { // get the row with same itemId of newObject
                                        itemsUnits defItemUnit = entity.itemsUnits.Where(p => p.itemId == newObject.itemId && p.defaultSale == 1).FirstOrDefault();
                                        if (defItemUnit != null)
                                        {
                                            defItemUnit.defaultSale = 0;
                                            entity.SaveChanges();
                                        }
                                    }
                                    if (newObject.defaultPurchase == 1)
                                    {
                                        var defItemUnit = entity.itemsUnits.Where(p => p.itemId == newObject.itemId && p.defaultPurchase == 1).FirstOrDefault();
                                        if (defItemUnit != null)
                                        {
                                            defItemUnit.defaultPurchase = 0;
                                            entity.SaveChanges();
                                        }
                                    }
                                }
                                newObject.createDate = DateTime.Now;
                                newObject.updateDate = DateTime.Now;
                                newObject.updateUserId = newObject.createUserId;
                                newObject.isActive = 1;

                                itemUnitEntity.Add(newObject);
                                //  message = "Item Unit Is Added Successfully";
                            }
                            else
                            {
                                //update
                                // set the other default sale or purchase to 0 if the new object.default is 1
                                int itemUnitId = newObject.itemUnitId;
                                var tmpItemUnit = entity.itemsUnits.Find(itemUnitId);

                                if (newObject.defaultSale == 1)
                                {
                                    itemsUnits saleItemUnit = entity.itemsUnits.Where(p => p.itemId == tmpItemUnit.itemId && p.defaultSale == 1).FirstOrDefault();
                                    if (saleItemUnit != null)
                                    {
                                        saleItemUnit.defaultSale = 0;
                                        entity.SaveChanges();
                                    }
                                }
                                if (newObject.defaultPurchase == 1)
                                {
                                    var defItemUnit = entity.itemsUnits.Where(p => p.itemId == tmpItemUnit.itemId && p.defaultPurchase == 1).FirstOrDefault();
                                    if (defItemUnit != null)
                                    {
                                        defItemUnit.defaultPurchase = 0;
                                        entity.SaveChanges();
                                    }
                                }
                                tmpItemUnit.barcode = newObject.barcode;
                                // tmpItemUnit.itemId = newObject.itemId;
                                tmpItemUnit.price = newObject.price;
                                tmpItemUnit.subUnitId = newObject.subUnitId;
                                tmpItemUnit.unitId = newObject.unitId;
                                tmpItemUnit.unitValue = newObject.unitValue;
                                tmpItemUnit.defaultPurchase = newObject.defaultPurchase;
                                tmpItemUnit.defaultSale = newObject.defaultSale;
                                tmpItemUnit.updateDate = DateTime.Now;
                                tmpItemUnit.updateUserId = newObject.updateUserId;
                                tmpItemUnit.storageCostId = newObject.storageCostId;
                                tmpItemUnit.isActive = newObject.isActive;
                                //  message = "Item Unit Is Updated Successfully";
                            }
                            message = entity.SaveChanges().ToString();
                            return TokenManager.GenerateToken(message);

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
            //string message = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid)
            //{
            //    itemsUnitsObject = itemsUnitsObject.Replace("\\", string.Empty);
            //    itemsUnitsObject = itemsUnitsObject.Trim('"');
            //    itemsUnits newObject = JsonConvert.DeserializeObject<itemsUnits>(itemsUnitsObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            //    if (newObject.updateUserId == 0 || newObject.updateUserId == null)
            //    {
            //        Nullable<int> id = null;
            //        newObject.updateUserId = id;
            //    }
            //    if (newObject.createUserId == 0 || newObject.createUserId == null)
            //    {
            //        Nullable<int> id = null;
            //        newObject.createUserId = id;
            //    }
            //    try
            //    {
            //        using (incposdbEntities entity = new incposdbEntities())
            //        {
            //            var itemUnitEntity = entity.Set<itemsUnits>();
            //            if (newObject.itemUnitId == 0)
            //            {
            //                //create
            //                // set the other default sale or purchase to 0 if the new object.default is 1

            //                if (newObject.defaultSale == 1)
            //                { // get the row with same itemId of newObject
            //                    itemsUnits defItemUnit = entity.itemsUnits.Where(p => p.itemId == newObject.itemId && p.defaultSale == 1).FirstOrDefault();
            //                    if (defItemUnit != null)
            //                    {
            //                        defItemUnit.defaultSale = 0;
            //                        entity.SaveChanges();
            //                    }
            //                }
            //                if (newObject.defaultPurchase == 1)
            //                {
            //                    var defItemUnit = entity.itemsUnits.Where(p => p.itemId == newObject.itemId && p.defaultPurchase == 1).FirstOrDefault();
            //                    if (defItemUnit != null)
            //                    {
            //                        defItemUnit.defaultPurchase = 0;
            //                        entity.SaveChanges();
            //                    }
            //                }
            //                newObject.createDate = DateTime.Now;
            //                newObject.updateDate = DateTime.Now;
            //                newObject.updateUserId = newObject.createUserId;
            //                newObject.isActive = 1;

            //                itemUnitEntity.Add(newObject);
            //                message = "Item Unit Is Added Successfully";
            //            }
            //            else
            //            {
            //                //update
            //                // set the other default sale or purchase to 0 if the new object.default is 1
            //                int itemUnitId = newObject.itemUnitId;
            //                var tmpItemUnit = entity.itemsUnits.Find(itemUnitId);

            //                if (newObject.defaultSale == 1)
            //                {
            //                    itemsUnits saleItemUnit = entity.itemsUnits.Where(p => p.itemId == tmpItemUnit.itemId && p.defaultSale == 1).FirstOrDefault();
            //                    if (saleItemUnit != null)
            //                    {
            //                        saleItemUnit.defaultSale = 0;
            //                        entity.SaveChanges();
            //                    }
            //                }
            //                if (newObject.defaultPurchase == 1)
            //                {
            //                    var defItemUnit = entity.itemsUnits.Where(p => p.itemId == tmpItemUnit.itemId && p.defaultPurchase == 1).FirstOrDefault();
            //                    if (defItemUnit != null)
            //                    {
            //                        defItemUnit.defaultPurchase = 0;
            //                        entity.SaveChanges();
            //                    }
            //                }
            //                tmpItemUnit.barcode = newObject.barcode;
            //               // tmpItemUnit.itemId = newObject.itemId;
            //                tmpItemUnit.price = newObject.price;
            //                tmpItemUnit.subUnitId = newObject.subUnitId;
            //                tmpItemUnit.unitId = newObject.unitId;
            //                tmpItemUnit.unitValue = newObject.unitValue;
            //                tmpItemUnit.defaultPurchase = newObject.defaultPurchase;
            //                tmpItemUnit.defaultSale = newObject.defaultSale;
            //                tmpItemUnit.updateDate = DateTime.Now;
            //                tmpItemUnit.updateUserId = newObject.updateUserId;
            //                tmpItemUnit.storageCostId = newObject.storageCostId;
            //                tmpItemUnit.isActive = newObject.isActive;
            //                message = "Item Unit Is Updated Successfully";
            //            }
            //            entity.SaveChanges();
            //        }
            //    }
            //    catch
            //    {
            //        message = "an error ocurred";
            //    }
            //}
            //return Ok( message);
        }

        [HttpPost]
        [Route("Delete")]
        public string Delete(string token)
        {


            //int ItemUnitId,int userId, Boolean final)

            string message = "";



          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int ItemUnitId = 0;
                int userId = 0;
                bool final = false;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "ItemUnitId")
                    {
                        ItemUnitId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }
                    else if (c.Type == "final")
                    {
                        final = bool.Parse(c.Value);
                    }

                }

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        if (final)
                        {
                            itemsUnits itemUnit = entity.itemsUnits.Find(ItemUnitId);

                            entity.itemsUnits.Remove(itemUnit);


                            //   return Ok("Item Unit is Deleted Successfully");
                            message = entity.SaveChanges().ToString();
                            return TokenManager.GenerateToken(message);

                        }
                        else
                        {

                            itemsUnits unitDelete = entity.itemsUnits.Find(ItemUnitId);
                            unitDelete.isActive = 0;
                            unitDelete.updateDate = DateTime.Now;
                            unitDelete.updateUserId = userId;

                            message = entity.SaveChanges().ToString();
                            return TokenManager.GenerateToken(message);
                            // return Ok("Unit is Deleted Successfully");

                        }
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
            //    try
            //    {
            //        using (incposdbEntities entity = new incposdbEntities())
            //        {
            //            if (final)
            //            {
            //                itemsUnits itemUnit = entity.itemsUnits.Find(ItemUnitId);

            //                entity.itemsUnits.Remove(itemUnit);
            //                entity.SaveChanges();

            //                return Ok("Item Unit is Deleted Successfully");

            //            }
            //            else
            //            {

            //                itemsUnits unitDelete = entity.itemsUnits.Find(ItemUnitId);
            //                unitDelete.isActive = 0;
            //                unitDelete.updateDate = DateTime.Now;
            //                unitDelete.updateUserId = userId;
            //                entity.SaveChanges();
            //                return Ok("Unit is Deleted Successfully");
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        return NotFound();
            //    }
            //}
            //else
            //    return NotFound();
        }

        [HttpPost]
        [Route("GetAllBarcodes")]
        public string GetAllBarcodes(string token)
        {

          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                // bool canDelete = false;

                //int mainBranchId = 0;
                //int userId = 0;

                //IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                //foreach (Claim c in claims)
                //{
                //    if (c.Type == "mainBranchId")
                //    {
                //        mainBranchId = int.Parse(c.Value);
                //    }
                //    else if (c.Type == "userId")
                //    {
                //        userId = int.Parse(c.Value);
                //    }

                //}


                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var barcods = (from i in entity.itemsUnits
                                       join u in entity.units on i.unitId equals u.unitId

                                       select new ItemUnitModel()
                                       {
                                           itemId = i.itemId,
                                           barcode = i.barcode,
                                           unitId = i.unitId,
                                           itemUnitId = i.itemUnitId,
                                           mainUnit = u.name,
                                       }).ToList();

                        return TokenManager.GenerateToken(barcods);
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

            //if (valid) // APIKey is valid
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var barcods = (from i in entity.itemsUnits
            //                       join u in entity.units on i.unitId equals u.unitId

            //                       select new ItemUnitModel()
            //                       {
            //                           itemId = i.itemId,
            //                           barcode = i.barcode,
            //                           unitId = i.unitId,
            //                           itemUnitId = i.itemUnitId,
            //                           mainUnit = u.name,
            //                       }).ToList();

            //        if (barcods == null)
            //            return NotFound();
            //        else
            //            return Ok(barcods);
            //    }
            //}
            ////else
            //return NotFound();
        }

        [HttpPost]
        [Route("GetallItemsUnits")]
        public string GetallItemsUnits(string token)
        {
            //  public string Getall(string token)
            token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {



                try
                {

                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var itemUnitsList = (from IU in entity.itemsUnits

                                             join u in entity.units on IU.unitId equals u.unitId

                                             join i in entity.items on IU.itemId equals i.itemId
                                             orderby i.name
                                             select new ItemUnitModel()
                                             {
                                                 itemUnitId = IU.itemUnitId,
                                                 unitId = IU.unitId,
                                                 itemId = IU.itemId,
                                                 mainUnit = u.name,
                                                 createDate = IU.createDate,
                                                 createUserId = IU.createUserId,
                                                 defaultPurchase = IU.defaultPurchase,
                                                 defaultSale = IU.defaultSale,
                                                 price = IU.price,
                                                 subUnitId = IU.subUnitId,

                                                 unitValue = IU.unitValue,
                                                 barcode = IU.barcode,
                                                 updateDate = IU.updateDate,
                                                 updateUserId = IU.updateUserId,
                                                 itemName = i.name,
                                                 itemCode = i.code,
                                                 unitName = u.name,
                                                 storageCostId = IU.storageCostId,

                                             })
                                                         .ToList();
                        return TokenManager.GenerateToken(itemUnitsList);
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

            //if (valid) // APIKey is valid
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var itemUnitsList = (from IU in entity.itemsUnits

            //                             join u in entity.units on IU.unitId equals u.unitId

            //                             join i in entity.items on IU.itemId equals i.itemId
            //                             orderby i.name
            //                             select new ItemUnitModel()
            //                             {
            //                                 itemUnitId = IU.itemUnitId,
            //                                 unitId = IU.unitId,
            //                                 itemId = IU.itemId,
            //                                 mainUnit = u.name,
            //                                 createDate = IU.createDate,
            //                                 createUserId = IU.createUserId,
            //                                 defaultPurchase = IU.defaultPurchase,
            //                                 defaultSale = IU.defaultSale,
            //                                 price = IU.price,
            //                                 subUnitId = IU.subUnitId,

            //                                 unitValue = IU.unitValue,
            //                                 barcode = IU.barcode,
            //                                 updateDate = IU.updateDate,
            //                                 updateUserId = IU.updateUserId,
            //                                 itemName = i.name,
            //                                 itemCode = i.code,
            //                                 unitName = u.name,
            //                                 storageCostId = IU.storageCostId,

            //                             })
            //                             .ToList();

            //        if (itemUnitsList == null)
            //            return NotFound();
            //        else
            //            return Ok(itemUnitsList);
            //    }
            //}
            ////else
            //return NotFound();
        }


        [HttpPost]
        [Route("GetUnitsForSales")]
        public string GetUnitsForSales(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
            if (TokenManager.GetPrincipal(token) == null) //invalid authorization
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int branchId = 0;
            IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
            foreach (Claim c in claims)
            {
                if (c.Type == "branchId")
                    branchId = int.Parse(c.Value);
            }
            try
            {
                using (incposdbEntities entity = new incposdbEntities())
                    {
                        var itemUnitsList = (from  u in entity.itemsUnits where u.isActive == 1
                                         join il in entity.itemsLocations on u.itemUnitId equals il.itemUnitId
                                         join l in entity.locations on il.locationId equals l.locationId
                                         join s in entity.sections.Where(x => x.branchId == branchId) on l.sectionId equals s.sectionId
                                         where u.itemId ==(from ux in entity.itemsUnits where u.itemId == ux.itemId
                                                           where ux.isActive == 1
                                                           join il in entity.itemsLocations on ux.itemUnitId equals il.itemUnitId
                                                           join l in entity.locations on il.locationId equals l.locationId
                                                           join s in entity.sections.Where(x => x.branchId == branchId) on l.sectionId equals s.sectionId
                                                           where il.quantity>0
                                                           select ux.itemId).FirstOrDefault()
                                         select new ItemUnitModel()
                                         {
                                             itemId = u.itemId,
                                             barcode = u.barcode,
                                             mainUnit = u.units.name,
                                             itemUnitId = u.itemUnitId,
                                             price = u.price ,
                                             taxes = u.items.taxes,
                                         }).ToList();


                        var itemsofferslist = (from off in entity.offers

                                               join itof in entity.itemsOffers on off.offerId equals itof.offerId // itemsOffers and offers 

                                               //  join iu in entity.itemsUnits on itof.iuId  equals  iu.itemUnitId //itemsUnits and itemsOffers
                                               join iu in entity.itemsUnits on itof.iuId equals iu.itemUnitId
                                               //from un in entity.units
                                               select new ItemSalePurModel()
                                               {
                                                   itemId = iu.itemId,
                                                   itemUnitId = itof.iuId,
                                                   offerName = off.name,
                                                   offerId = off.offerId,
                                                   discountValue = off.discountValue,
                                                   isNew = 0,
                                                   isOffer = 1,
                                                   isActiveOffer = off.isActive,
                                                   startDate = off.startDate,
                                                   endDate = off.endDate,
                                                   unitId = iu.unitId,

                                                   price = iu.price,
                                                   discountType = off.discountType,
                                                   desPrice = iu.price,
                                                   defaultSale = iu.defaultSale,

                                               }).Where(IO => IO.isActiveOffer == 1 && DateTime.Compare((DateTime)IO.startDate, DateTime.Now) <= 0 && System.DateTime.Compare((DateTime)IO.endDate, DateTime.Now) >= 0 && IO.defaultSale == 1).Distinct().ToList();


                        foreach (var iunlist in itemUnitsList)
                        {
                            // end is new
                            decimal? totaldis = 0;
                    iunlist.price = (decimal) iunlist.price + Calc.percentValue(iunlist.price, iunlist.taxes);
                            foreach (var itofflist in itemsofferslist)
                            {


                                if (iunlist.itemUnitId == itofflist.itemUnitId)
                                {
                                    // get unit name of item that has the offer
                                    using (incposdbEntities entitydb = new incposdbEntities())
                                    { // put it in item
                                        var un = entitydb.units
                                         .Where(a => a.unitId == itofflist.unitId)
                                            .Select(u => new
                                            {
                                                u.name
                                           ,
                                                u.unitId
                                            }).FirstOrDefault();
                                        iunlist.unitName = un.name;
                                    }
                                    iunlist.price = itofflist.price;
                                    iunlist.price = iunlist.price + (iunlist.price * iunlist.taxes / 100); 
                                }
                            }
                        }
                        return TokenManager.GenerateToken(itemUnitsList);
                    }
            }
            catch
            {
                return TokenManager.GenerateToken("0");
            }
             }

        }


        [HttpPost]
        [Route("GetbyOfferId")]
        public string GetbyOfferId(string token)
        {

            // public string GetUsersByGroupId(string token)int itemId
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) 
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int offerId = 0;

              //  bool canDelete = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "offerId")
                    {
                        offerId = int.Parse(c.Value);
                    }


                }


                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var itemUnitsList = (from IU in entity.itemsUnits
                                             join IO in entity.itemsOffers on IU.itemUnitId equals IO.iuId
                                             join u in entity.units on IU.unitId equals u.unitId

                                             join i in entity.items on IU.itemId equals i.itemId
                                             orderby i.name
                                             where IO.offerId == offerId
                                             select new ItemUnitModel()
                                             {
                                                 itemUnitId = IU.itemUnitId,
                                                 unitId = IU.unitId,
                                                 itemId = IU.itemId,
                                                 mainUnit = u.name,
                                                 createDate = IU.createDate,
                                                 createUserId = IU.createUserId,
                                                 defaultPurchase = IU.defaultPurchase,
                                                 defaultSale = IU.defaultSale,
                                                 price = IU.price,
                                                 subUnitId = IU.subUnitId,

                                                 unitValue = IU.unitValue,
                                                 barcode = IU.barcode,
                                                 updateDate = IU.updateDate,
                                                 updateUserId = IU.updateUserId,
                                                 itemName = i.name,
                                                 itemCode = i.code,
                                                 unitName = u.name,
                                                 storageCostId = IU.storageCostId,

                                             })
                                                         .ToList();


                        return TokenManager.GenerateToken(itemUnitsList);
                    }

                    }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }
            }

            //int offerId = 0;
            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //if (headers.Contains("offerId"))
            //{
            //    offerId = Convert.ToInt32(headers.GetValues("offerId").First());
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid) // APIKey is valid
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var itemUnitsList = (from IU in entity.itemsUnits
            //                             join IO in entity.itemsOffers on IU.itemUnitId equals IO.iuId
            //                             join u in entity.units on IU.unitId equals u.unitId

            //                             join i in entity.items on IU.itemId equals i.itemId
            //                             orderby i.name
            //                             where IO.offerId == offerId
            //                             select new ItemUnitModel()
            //                             {
            //                                 itemUnitId = IU.itemUnitId,
            //                                 unitId = IU.unitId,
            //                                 itemId = IU.itemId,
            //                                 mainUnit = u.name,
            //                                 createDate = IU.createDate,
            //                                 createUserId = IU.createUserId,
            //                                 defaultPurchase = IU.defaultPurchase,
            //                                 defaultSale = IU.defaultSale,
            //                                 price = IU.price,
            //                                 subUnitId = IU.subUnitId,

            //                                 unitValue = IU.unitValue,
            //                                 barcode = IU.barcode,
            //                                 updateDate = IU.updateDate,
            //                                 updateUserId = IU.updateUserId,
            //                                 itemName = i.name,
            //                                 itemCode = i.code,
            //                                 unitName = u.name,
            //                                 storageCostId = IU.storageCostId,

            //                             })
            //                             .ToList();

            //        if (itemUnitsList == null)
            //            return NotFound();
            //        else
            //            return Ok(itemUnitsList);
            //    }
            //}
            ////else
            //return NotFound();
        }

        [HttpPost]
        [Route("getSmallItemUnits")]
        public string getSmallItemUnits(string token)
        {

            // public string GetUsersByGroupId(string token)//int itemId, int itemUnitId
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) 
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int itemId = 0;
                int itemUnitId = 0;
                //  bool canDelete = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "itemId")
                    {
                        itemId = int.Parse(c.Value);
                    }
                else    if (c.Type == "itemUnitId")
                    {
                        itemUnitId = int.Parse(c.Value);

                    }


                }


                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        // get all sub item units 
                        List<itemsUnits> unitsList = entity.itemsUnits
                         .ToList().Where(x => x.itemId == itemId)
                          .Select(p => new itemsUnits
                          {
                              itemUnitId = p.itemUnitId,
                              unitId = p.unitId,
                              subUnitId = p.subUnitId,
                          })
                         .ToList();

                        var unitId = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => x.unitId).Single();
                        itemUnitsIds = new List<int>();
                        itemUnitsIds.Add(itemUnitId);

                        var result = Recursive(unitsList, (int)unitId);

                        var units = (from iu in entity.itemsUnits.Where(x => x.itemId == itemId)
                                     join u in entity.units on iu.unitId equals u.unitId
                                     select new ItemUnitModel()
                                     {
                                         unitId = iu.unitId,
                                         itemUnitId = iu.itemUnitId,
                                         subUnitId = iu.subUnitId,
                                         mainUnit = u.name,

                                     }).Where(p => !itemUnitsIds.Contains((int)p.itemUnitId)).ToList();

                        return TokenManager.GenerateToken(units);
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
            //        // get all sub item units 
            //        List<itemsUnits> unitsList = entity.itemsUnits
            //         .ToList().Where(x => x.itemId == itemId)
            //          .Select(p => new itemsUnits
            //          {
            //              itemUnitId = p.itemUnitId,
            //              unitId = p.unitId,
            //              subUnitId = p.subUnitId,
            //          })
            //         .ToList();

            //        var unitId = entity.itemsUnits.Where(x => x.itemUnitId == itemUnitId).Select(x => x.unitId).Single();
            //        itemUnitsIds = new List<int>();
            //        itemUnitsIds.Add(itemUnitId);

            //        var result = Recursive(unitsList, (int)unitId);

            //        var units = (from iu in entity.itemsUnits.Where(x => x.itemId == itemId)
            //                     join u in entity.units on iu.unitId equals u.unitId
            //                     select new ItemUnitModel()
            //                     {
            //                         unitId = iu.unitId,
            //                         itemUnitId = iu.itemUnitId,
            //                         subUnitId = iu.subUnitId,
            //                         mainUnit = u.name,

            //                     }).Where(p => !itemUnitsIds.Contains((int)p.itemUnitId)).ToList();

            //        if (units == null)
            //            return NotFound();
            //        else
            //            return Ok(units);
            //    }

            //}
            //else
            //{
            //    return NotFound();
            //}

        }

        public IEnumerable<itemsUnits> Recursive(List<itemsUnits> unitsList, int smallLevelid)
        {
            List<itemsUnits> inner = new List<itemsUnits>();

            foreach (var t in unitsList.Where(item => item.subUnitId == smallLevelid))
            {
                // if (t.unitId.Value != smallLevelid)
                // {
                itemUnitsIds.Add(t.itemUnitId);
                inner.Add(t);
                // }
                if (t.unitId.Value == smallLevelid)
                    return inner;
                inner = inner.Union(Recursive(unitsList, t.unitId.Value)).ToList();
            }

            return inner;
        }

        [HttpPost]
        [Route("largeToSmallUnitQuan")]
        public string largeToSmallUnitQuan(string token)
        {


            // public string GetUsersByGroupId(string token)//int fromItemUnit, int toItemUnit
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) 
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int fromItemUnit = 0;
                int toItemUnit = 0;
                //  bool canDelete = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "fromItemUnit")
                    {
                        fromItemUnit = int.Parse(c.Value);
                    }
                    else if (c.Type == "toItemUnit")
                    {
                        toItemUnit = int.Parse(c.Value);

                    }


                }


                try
                {
                    int amount = 0;
                    amount += getUnitConversionQuan(fromItemUnit, toItemUnit);
                    return TokenManager.GenerateToken(amount.ToString());
                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }
            }


            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //int amount = 0;
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid)
            //{
            //    amount += getUnitConversionQuan(fromItemUnit, toItemUnit);
            //}
            //return amount;
        }



        private int getUnitConversionQuan(int fromItemUnit, int toItemUnit)
        {
            int amount = 0;

            using (incposdbEntities entity = new incposdbEntities())
            {
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == toItemUnit).Select(x => new { x.unitId, x.itemId }).FirstOrDefault();
                var upperUnit = entity.itemsUnits.Where(x => x.subUnitId == unit.unitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();
                if (upperUnit != null)
                    amount = (int)upperUnit.unitValue;
                if (fromItemUnit == upperUnit.itemUnitId)
                    return amount;
                if (upperUnit != null)
                    amount += (int)upperUnit.unitValue * getUnitConversionQuan(fromItemUnit, upperUnit.itemUnitId);

                return amount;
            }
        }


        [HttpPost]
        [Route("smallToLargeUnitQuan")]
        public string smallToLargeUnitQuan(string token)
        {


            // public string GetUsersByGroupId(string token)//int fromItemUnit, int toItemUnit
          token = TokenManager.readToken(HttpContext.Current.Request); 
 if (TokenManager.GetPrincipal(token) == null) 
            {
                return TokenManager.GenerateToken("-7");
            }
            else
            {
                int fromItemUnit = 0;
                int toItemUnit = 0;
                //  bool canDelete = false;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "fromItemUnit")
                    {
                        fromItemUnit = int.Parse(c.Value);
                    }
                    else if (c.Type == "toItemUnit")
                    {
                        toItemUnit = int.Parse(c.Value);

                    }


                }


                try
                {
                    int amount = 0;
                    amount = getLargeUnitConversionQuan(fromItemUnit, toItemUnit);
                    return TokenManager.GenerateToken(amount.ToString());
                }
                catch
                {
                    return TokenManager.GenerateToken("0");
                }
            }


            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //int amount = 0;
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid)
            //{
            //    amount = getLargeUnitConversionQuan(fromItemUnit, toItemUnit);
            //}
            //return amount;
        }



        public int getLargeUnitConversionQuan(int fromItemUnit, int toItemUnit)
        {
            int amount = 0;

            using (incposdbEntities entity = new incposdbEntities())
            {
                var unit = entity.itemsUnits.Where(x => x.itemUnitId == toItemUnit).Select(x => new { x.unitId, x.itemId, x.subUnitId, x.unitValue }).FirstOrDefault();
                var smallUnit = entity.itemsUnits.Where(x => x.unitId == unit.subUnitId && x.itemId == unit.itemId).Select(x => new { x.unitValue, x.itemUnitId }).FirstOrDefault();

                if (toItemUnit == smallUnit.itemUnitId)
                {
                    amount = 1;
                    return amount;
                }

                if (smallUnit != null)
                    amount += (int)unit.unitValue * getLargeUnitConversionQuan(fromItemUnit, smallUnit.itemUnitId);


                return amount;
            }
        }


    }
}
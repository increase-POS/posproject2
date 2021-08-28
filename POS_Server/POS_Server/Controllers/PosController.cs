using Newtonsoft.Json;
using POS_Server.Classes;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Pos")]
    public class PosController : ApiController
    {
        // GET api/<controller>
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
                    var posList = (from p in entity.pos
                                   join b in entity.branches on p.branchId equals b.branchId into lj
                                   from x in lj.DefaultIfEmpty()
                                   select new PosModel() {
                                       posId = p.posId,
                                       balance = p.balance,
                                       branchId = p.branchId,
                                       code = p.code,
                                       name = p.name,
                                       branchName = x.name,
                                       createDate = p.createDate,
                                       updateDate = p.updateDate,
                                       createUserId = p.createUserId,
                                       updateUserId = p.updateUserId,
                                       isActive = p.isActive,
                                      balanceAll=p.balanceAll,
                                       note = p.note,
                                       branchCode = x.code,
                                   }).ToList();

                    if (posList.Count > 0)
                    {
                        for (int i = 0; i < posList.Count; i++)
                        {
                            canDelete = false;
                            if (posList[i].isActive == 1)
                            {
                                int posId = (int)posList[i].posId;
                                var cashTransferL = entity.cashTransfer.Where(x => x.posId == posId).Select(b => new { b.cashTransId }).FirstOrDefault();
                                var posUsersL = entity.posUsers.Where(x => x.posId == posId).Select(x => new { x.posUserId }).FirstOrDefault();
                               
                                if ((cashTransferL is null) && (posUsersL is null))
                                    canDelete = true;
                            }
                           
                            posList[i].canDelete = canDelete;
                        }
                    }

                    if (posList == null)
                        return NotFound();
                    else
                        return Ok(posList);
                }
            }
            //else
            return NotFound();
        }

        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string searchWords)
        {
            var re = Request;
            var headers = re.Headers;
            decimal balance =0;
            string token = "";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            try
            {
                 balance = Convert.ToDecimal(searchWords);
            }
            catch { }
            if (valid) // APIKey is valid
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var posList = (from p in entity.pos
                                   join b in entity.branches on p.branchId equals b.branchId into lj
                                   from x in lj.DefaultIfEmpty()
                                   select new PosModel()
                                   {
                                       posId = p.posId,
                                       balance = p.balance,
                                       branchId = p.branchId,
                                       code = p.code,
                                       name = p.name,
                                       branchName = x.name,
                                       createDate = p.createDate,
                                       updateDate = p.updateDate,
                                       createUserId = p.createUserId,
                                       updateUserId = p.updateUserId,
                                       isActive = p.isActive,
                                       note = p.note,
                                       balanceAll = p.balanceAll,
                                       branchCode = x.code,
                                   })
                                   .Where(p=> (p.name.Contains(searchWords) || p.code.Contains(searchWords) || p.branchName.Contains(searchWords) || p.balance == balance ))
                                   .ToList();

                    if (posList == null)
                        return NotFound();
                    else
                        return Ok(posList);
                }
            }
            //else
            return NotFound();
        }
        // GET api/<controller>
        [HttpGet]
        [Route("GetPosByID")]
        public IHttpActionResult GetPosByID(int posId)
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
                    var pos = (from p in entity.pos where p.posId == posId
                                join b in entity.branches on p.branchId equals b.branchId into lj
                                from x in lj.DefaultIfEmpty()
                                select new PosModel()
                                {
                                    posId = p.posId,
                                    balance = p.balance,
                                    branchId = p.branchId,
                                    code = p.code,
                                    name = p.name,
                                    branchName = x.name,
                                    createDate = p.createDate,
                                    updateDate = p.updateDate,
                                    createUserId = p.createUserId,
                                    updateUserId = p.updateUserId,
                                    isActive = p.isActive,
                                    balanceAll = p.balanceAll,
                                    note = p.note,
                                    branchCode = x.code,
                                }).FirstOrDefault();

                    if (pos == null)
                        return NotFound();
                    else
                        return Ok(pos);
                }
            }
            else
                return NotFound();
        }

        // add or update pos
        [HttpPost]
        [Route("Save")]
        public IHttpActionResult Save(string posObject)
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
                posObject = posObject.Replace("\\", string.Empty);
                posObject = posObject.Trim('"');
                pos newObject = JsonConvert.DeserializeObject<pos>(posObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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
                        pos tmpPos = new pos();
                        var unitEntity = entity.Set<pos>();
                        if (newObject.posId == 0)
                        {
                            ProgramInfo programInfo = new ProgramInfo();
                            int posMaxCount = programInfo.getPosCount();
                            int posCount = entity.pos.Count();
                            if (posCount >= posMaxCount)
                            {
                                return Ok(-1);
                            }
                            else
                            {
                                newObject.createDate = DateTime.Now;
                                newObject.updateDate = DateTime.Now;
                                newObject.updateUserId = newObject.createUserId;

                               tmpPos = unitEntity.Add(newObject);
                                entity.SaveChanges();
                                return Ok(tmpPos.posId);
                            }
                        }
                        else
                        {
                            tmpPos = entity.pos.Where(p => p.posId == newObject.posId).FirstOrDefault();
                            tmpPos.name = newObject.name;
                            tmpPos.code = newObject.code;
                            tmpPos.branchId = newObject.branchId;
                            tmpPos.note = newObject.note;
                            tmpPos.updateDate = DateTime.Now;
                            tmpPos.updateUserId = newObject.updateUserId;
                            tmpPos.isActive = newObject.isActive;
                            tmpPos.balance = newObject.balance;
                            tmpPos.balanceAll = newObject.balanceAll;
                            entity.SaveChanges();
                            return Ok(tmpPos.posId);
                        }
                    }
                }
                catch
                {
                    return Ok(0);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int posId,int userId,Boolean final)
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
                            pos posDelete = entity.pos.Find(posId);

                            entity.pos.Remove(posDelete);
                            entity.SaveChanges();

                            return Ok("Pos is Deleted Successfully");
                        }
                    }
                    catch
                    {
                        return NotFound();
                    }
                }
                else
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        pos posDelete = entity.pos.Find(posId);

                        posDelete.isActive = 0;
                        posDelete.updateUserId = userId;
                        posDelete.updateDate = DateTime.Now;
                        entity.SaveChanges();

                        return Ok("Pos is Deleted Successfully");
                    }
                }
            }
            else
                return NotFound();
        }
    }
}
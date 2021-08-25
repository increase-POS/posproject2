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
    [RoutePrefix("api/notificationUser")]
    public class notificationUserController : ApiController
    {
        [HttpGet]
        [Route("GetByUserId")]
        public IHttpActionResult GetByUserId(int userId, string type, int posId)
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
                    var List = (from S in entity.notificationUser where (S.userId == userId  || S.posId == posId) && S.notification.msgType.Contains(type)
                                select new NotificationUserModel()
                                {
                                    notUserId = S.notUserId,
                                    notId = S.notId,
                                    userId = S.userId,
                                    posId= S.posId,
                                    isRead = S.isRead,
                                    createUserId = S.createUserId,
                                    updateUserId = S.updateUserId,
                                    createDate = S.createDate,
                                    updateDate = S.updateDate,
                                    title = S.notification.title,
                                    ncontent = S.notification.ncontent,
                                    path = S.notification.path,
                                    msgType = S.notification.msgType,
                                    side = S.notification.side,

                                }).ToList();

                    if (List == null)
                        return NotFound();
                    else
                        return Ok(List);
                }
            }
            //else
            return NotFound();
        }

        // add or update notification 
        [HttpPost]
        [Route("Save")]
        public IHttpActionResult Save(string obj)
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
                obj = obj.Replace("\\", string.Empty);
                obj = obj.Trim('"');
                notificationUser Object = JsonConvert.DeserializeObject<notificationUser>(obj, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var notEntity = entity.Set<notificationUser>();

                        Object.createDate = DateTime.Now;
                        Object.updateDate = DateTime.Now;
                        Object.updateUserId = Object.createUserId;
                        
                      notificationUser not = notEntity.Add(Object);
                      entity.SaveChanges();
                        return Ok(not.notUserId);
                    }
                    
                }
                catch
                {
                    return Ok(false);
                }
            }
            else
                return NotFound();
        }
        [HttpPost]
        [Route("setAsRead")]
        public IHttpActionResult setAsRead(int notUserId, int posId, string type)
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
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                       // var notEntity = entity.Set<notificationUser>();

                        var List = (from S in entity.notificationUser
                                    where ((S.userId == notUserId || S.posId == posId) && S.isRead == false && S.notification.msgType.Contains(type) )
                                    select new NotificationUserModel()
                                    {
                                        notUserId = S.notUserId,
                                        notId = S.notId,
                                        userId = S.userId,
                                        posId = S.posId,
                                        isRead = S.isRead,
                                        createUserId = S.createUserId,
                                        updateUserId = S.updateUserId,
                                        createDate = S.createDate,
                                        updateDate = S.updateDate,
                                        title = S.notification.title,
                                        ncontent = S.notification.ncontent,
                                        path = S.notification.path,
                                        msgType = S.notification.msgType,
                                        side = S.notification.side,

                                    }).ToList();

                        //List.ForEach(a => a.isRead = true  );
                        //List.ForEach(a => a.updateDate = DateTime.Now);
                        foreach (NotificationUserModel m in List)
                            {
                           var notEntity = entity.notificationUser.Find(m.notUserId) ;
                            notEntity.isRead = true;
                            notEntity.updateDate = DateTime.Now;
                            entity.SaveChanges();
                        }
                        
                        return Ok(true);
                    }
                    
                }
                catch
                {
                    return Ok(false);
                }
            }
            else
                return NotFound();
        }
        [HttpGet]
        [Route("GetNotUserCount")]
        public IHttpActionResult GetNotUserCount(int userId,string type, int posId)
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
                    var notificationCount = entity.notificationUser
                        .Where(x => (x.userId == userId || x.posId == posId) && x.isRead == false && x.notification.msgType.Contains(type))
                        .ToList().Count;
                    return Ok(notificationCount);
                }
            }
            return NotFound();
        }
    }
}
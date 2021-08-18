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
        [Route("GetNotUserCount")]
        public IHttpActionResult GetNotUserCount(int userId)
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
                    var notificationCount = entity.notificationUser.Where(x => x.userId == userId && x.isRead == false).ToList().Count;
                    return Ok(notificationCount);
                }
            }
            return NotFound();
        }
    }
}
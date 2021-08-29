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
    [RoutePrefix("api/PaperSizeController")]
    public class PaperSizeController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
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
                    var List = (from S in entity.paperSize
                                select new
                                {
                                    S.sizeId,
                                    S.paperSize1,
                                    S.printfor,

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

        // GET api/<controller>
        [HttpGet]
        [Route("GetByID")]
        public IHttpActionResult GetByID(int sizeId)
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
                    var row = entity.paperSize
                   .Where(u => u.sizeId == sizeId)
                   .Select(S => new
                   {
                       S.sizeId,
                       S.paperSize1,
                       S.printfor,
                   })
                   .FirstOrDefault();

                    if (row == null)
                        return NotFound();
                    else
                        return Ok(row);
                }
            }
            else
                return NotFound();
        }

        // add or update location
        [HttpPost]
        [Route("Save")]
        public string Save(string Object)
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
                Object = Object.Replace("\\", string.Empty);
                Object = Object.Trim('"');
                paperSize newObject = JsonConvert.DeserializeObject<paperSize>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
           

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var locationEntity = entity.Set<paperSize>();
                        if (newObject.sizeId == 0)
                        {
                           


                            locationEntity.Add(newObject);
                            entity.SaveChanges();
                            message = newObject.sizeId.ToString();
                        }
                        else
                        {
                            var tmpObject = entity.paperSize.Where(p => p.sizeId == newObject.sizeId).FirstOrDefault();

                         
                            tmpObject.paperSize1 = newObject.paperSize1;
                            tmpObject.printfor  = newObject.printfor;

                            entity.SaveChanges();

                            message = tmpObject.sizeId.ToString();
                        }
                        //  entity.SaveChanges();
                    }
                }
                catch
                {
                    message = "-1";
                }
            }
            return message;
        }

        [HttpPost]
        [Route("Delete")]
        public string Delete(int sizeId)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int message = 0;
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
                            paperSize objectDelete = entity.paperSize.Find(sizeId);

                            entity.paperSize.Remove(objectDelete);
                            message = entity.SaveChanges();

                            return message.ToString();
                        }
                    }
                    catch
                    {
                        return "-1";
                    }
               
            }
            else
                return "-3";
        }



    }
}
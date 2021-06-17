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
    [RoutePrefix("api/setting")]
    public class SettingController : ApiController
    {
        // GET api/<controller> get all setting
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
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
                    var settingList = entity.setting
                  
                   .Select(c => new  {
                     c.settingId ,
                     c.name,
                     c.notes, 

    })
                   .ToList();

                  

                    if (settingList == null)
                        return NotFound();
                    else
                        return Ok(settingList);
                }
            }
            //else
                return NotFound();
        }



        // GET api/<controller>  Get medal By ID 
        [HttpGet]
        [Route("GetByID")]
        public IHttpActionResult GetByID()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            int cId = 0;
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            if (headers.Contains("Id"))
            {
                cId = Convert.ToInt32(headers.GetValues("Id").First());
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);

            if (valid)
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var medal = entity.setting
                   .Where(c => c.settingId == cId)
                   .Select(c => new {
                       c.settingId,
                       c.name,
                       c.notes,


                   })
                   .FirstOrDefault();

                    if (medal == null)
                        return NotFound();
                    else
                        return Ok(medal);
                }
            }
            else
                return NotFound();
        }

   




        // add or update medal 
        [HttpPost]
        [Route("Save")]
        public bool Save(string sObject)
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
                sObject = sObject.Replace("\\", string.Empty);
                sObject = sObject.Trim('"');
                setting Object = JsonConvert.DeserializeObject<setting>(sObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var sEntity = entity.Set<setting>();
                        if (Object.settingId == 0)
                        {

                            sEntity.Add(Object);
                          //  message = "medal Is Added Successfully";
                        }
                        else
                        {

                            var tmps = entity.setting.Where(p => p.settingId == Object.settingId).FirstOrDefault();

                          
                           
                            tmps.settingId = Object.settingId;
                            tmps.name = Object.name;
                       tmps.notes = Object.notes;




                            //message = "medal Is Updated Successfully";
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

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(int Id, int userId)
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
                            setting sObj = entity.setting.Find(Id);
                       
                            entity.setting.Remove(sObj);
                            entity.SaveChanges();

                            return Ok("medal is Deleted Successfully");
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
    }
}
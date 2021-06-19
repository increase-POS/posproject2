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
    [RoutePrefix("api/setValues")]
    public class setValuesController : ApiController
    {
        // GET api/<controller> get all setValues
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
                    var setValuesList = entity.setValues
                  
                   .Select(c => new  {
                       c.valId,
                      c.value,
                      c.isDefault,
                      c.isSystem,
                      c.notes,
                      c.settingId,

                   })
                   .ToList();

                    /*
                     * 
                      valId 
                      value 
                      isDefault 
                      isSystem 
                      notes 
                      settingId 
                     * */

                    if (setValuesList == null)
                        return NotFound();
                    else
                        return Ok(setValuesList);
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
                    var list = entity.setValues
                   .Where(c => c.valId == cId)
                   .Select(c => new {
                       c.valId,
                       c.value,
                       c.isDefault,
                       c.isSystem,
                       c.notes,
                       c.settingId,


                   })
                   .FirstOrDefault();

                    if (list == null)
                        return NotFound();
                    else
                        return Ok(list);
                }
            }
            else
                return NotFound();
        }


        // add or update medal 
        [HttpPost]
        [Route("Save")]
        public String Save(string newObject)
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            string message ="";
            if (headers.Contains("APIKey"))
            {
                token = headers.GetValues("APIKey").First();
            }
            Validation validation = new Validation();
            bool valid = validation.CheckApiKey(token);
            
            if (valid)
            {
                newObject = newObject.Replace("\\", string.Empty);
                newObject = newObject.Trim('"');
                setValues Object = JsonConvert.DeserializeObject<setValues>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                try
                {
                    if (Object.settingId == 0 || Object.settingId == null)
                    {
                        Nullable<int> id = null;
                        Object.settingId = id;
                    }
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var sEntity = entity.Set<setValues>();
                        setValues defItem = entity.setValues.Where(p => p.settingId == Object.settingId && p.isDefault == 1).FirstOrDefault();
                          
                        if (Object.valId == 0)
                        {     
                            if (Object.isDefault == 1 )
                            { // get the row with same settingId of newObject
                                 if (defItem != null)
                                {
                                    defItem.isDefault = 0;
                                    entity.SaveChanges();
                                }
                            }
                            else //Object.isDefault ==0 
                            {
                                if (defItem == null)//other values isDefault not 1 
                                {
                                    Object.isDefault =1;
                                }

                            }
                                sEntity.Add(Object);
                          message = Object.valId.ToString();
                            entity.SaveChanges();
                        }
                        else
                        {
                            if (Object.isDefault == 1)
                            {
                                defItem.isDefault = 0;//reset the other default to 0 if exist
                            }
                            var tmps = entity.setValues.Where(p => p.valId == Object.valId).FirstOrDefault();
                            tmps.valId = Object.valId;                          
                            tmps.notes = Object.notes;
                            tmps.value = Object.value;
                            tmps.isDefault=Object.isDefault;
                            tmps.isSystem=Object.isSystem;
                            tmps.notes = Object.notes;
                            tmps.settingId=Object.settingId;
                            entity.SaveChanges();
                            message = tmps.valId.ToString();
                        }
                       
                       
                    }
                    return message; ;
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
                            setValues sObj = entity.setValues.Find(Id);
                       
                            entity.setValues.Remove(sObj);
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
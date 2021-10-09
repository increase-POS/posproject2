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
using Newtonsoft.Json.Converters;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/setting")]
    public class SettingController : ApiController
    {
        // GET api/<controller> get all setting
        [HttpGet]
        [Route("Get")]
        public ResponseVM Get()
        {

            // public ResponseVM GetPurinv(string token)

            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
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

                // DateTime cmpdate = DateTime.Now.AddDays(newdays);
                try
                {


                    using (incposdbEntities entity = new incposdbEntities())
                    {


                        var list = entity.setting

                           .Select(c => new
                           {
                               c.settingId,
                               c.name,
                               c.notes,

                           })
                                       .ToList();

                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(list) };

                    }

                }
                catch
                {
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
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
            //                var settingList = entity.setting

            //               .Select(c => new  {
            //                 c.settingId ,
            //                 c.name,
            //                 c.notes, 

            //})
            //               .ToList();



            //                if (settingList == null)
            //                    return NotFound();
            //                else
            //                    return Ok(settingList);
            //            }
            //        }
            //        //else
            //            return NotFound();
        }



        // GET api/<controller>  Get medal By ID 
        [HttpGet]
        [Route("GetByID")]
        public ResponseVM GetByID(string token)
        {

            // public ResponseVM GetPurinv(string token)int printerId
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int Id = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Id")
                    {
                        Id = int.Parse(c.Value);
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {

                    var item = entity.setting
                   .Where(c => c.settingId == Id)
                   .Select(c => new
                   {
                       c.settingId,
                       c.name,
                       c.notes,


                   })
                           .FirstOrDefault();
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(item) };
                }
            }


            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //int cId = 0;
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //if (headers.Contains("Id"))
            //{
            //    cId = Convert.ToInt32(headers.GetValues("Id").First());
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid)
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var medal = entity.setting
            //       .Where(c => c.settingId == cId)
            //       .Select(c => new {
            //           c.settingId,
            //           c.name,
            //           c.notes,


            //       })
            //       .FirstOrDefault();

            //        if (medal == null)
            //            return NotFound();
            //        else
            //            return Ok(medal);
            //    }
            //}
            //else
            //    return NotFound();
        }



        // GET api/<controller> get all setting
        [HttpGet]
        [Route("GetByNotes")]
        public ResponseVM GetByNotes(string token)
        {
            // public ResponseVM GetPurinv(string token)string notes
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                string notes ="";
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "notes")
                    {
                        notes = c.Value;
                    }
                }
                using (incposdbEntities entity = new incposdbEntities())
                {

                    List<setting> settingList1 = entity.setting.ToList();
                    var list = settingList1.Where(c => c.notes == notes).Select(c => new setting
                    {
                        settingId = c.settingId,
                        name = c.name,
                        notes = c.notes,
                    }).ToList();

                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(list) };
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
            //        List<setting> settingList1 = entity.setting.ToList();
            //    var    settingList = settingList1.Where(c => c.notes == notes).Select(c => new setting
            //        {
            //            settingId = c.settingId,
            //            name = c.name,
            //            notes = c.notes,
            //        }).ToList();


            //        if (settingList == null)
            //            return NotFound();
            //        else
            //            return Ok(settingList);
            //    }
            //}
            ////else
            //return NotFound();
        }



        // add or update medal 
        [HttpPost]
        [Route("Save")]
        public ResponseVM Save(string token)
        {

            //string Object string newObject
            string message = "";
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                string Object = "";
                setting newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Object")
                    {
                        Object = c.Value.Replace("\\", string.Empty);
                        Object = Object.Trim('"');
                        newObject = JsonConvert.DeserializeObject<setting>(Object, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
                if (newObject != null)
                {


                    setting tmpObject;
              

                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                          
                                var sEntity = entity.Set<setting>();
                                if (newObject.settingId == 0)
                                {

                                    sEntity.Add(newObject);
                                    entity.SaveChanges();
                                    message = newObject.settingId.ToString();
                                }
                                else
                                {

                                tmpObject = entity.setting.Where(p => p.settingId == newObject.settingId).FirstOrDefault();



                                tmpObject.settingId = newObject.settingId;
                                tmpObject.name = newObject.name;
                                tmpObject.notes = newObject.notes;



                                    entity.SaveChanges();
                                    message = tmpObject.settingId.ToString();
                                }


                             
                            }
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                    }
                    catch
                    {
                        message = "0";
                        return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
                    }


                }

                return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };

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
            //    newObject = newObject.Replace("\\", string.Empty);
            //    newObject = newObject.Trim('"');
            //    setting Object = JsonConvert.DeserializeObject<setting>(newObject, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            //    try
            //    {
            //        using (incposdbEntities entity = new incposdbEntities())
            //        {
            //            var sEntity = entity.Set<setting>();
            //            if (Object.settingId == 0)
            //            {

            //                sEntity.Add(Object);
            //                entity.SaveChanges();
            //                message = Object.settingId.ToString();
            //            }
            //            else
            //            {

            //                var tmps = entity.setting.Where(p => p.settingId == Object.settingId).FirstOrDefault();



            //                tmps.settingId = Object.settingId;
            //                tmps.name = Object.name;
            //           tmps.notes = Object.notes;



            //            entity.SaveChanges();
            //               message = tmps.settingId.ToString();
            //            }

            //        }
            //        return message;
            //    }

            //    catch
            //    {
            //        return "-1";
            //    }
            //}
            //else
            //    return "-1";
        }

        [HttpPost]
        [Route("Delete")]
        public ResponseVM Delete(string token)
        {
            // public ResponseVM Delete(string token)
            //int Id, int userId
            string message = "";
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int Id = 0;
                int userId = 0;
           

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Id")
                    {
                        Id = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
                    }

                }

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        setting sObj = entity.setting.Find(Id);

                        entity.setting.Remove(sObj);
                        message = entity.SaveChanges().ToString();

                      //  return Ok("medal is Deleted Successfully");
                    }
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                }
                catch
                {
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
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

            //        try
            //        {
            //            using (incposdbEntities entity = new incposdbEntities())
            //            {
            //                setting sObj = entity.setting.Find(Id);

            //                entity.setting.Remove(sObj);
            //                entity.SaveChanges();

            //                return Ok("medal is Deleted Successfully");
            //            }
            //        }
            //        catch
            //        {
            //            return NotFound();
            //        }




            //}
            //else
            //    return NotFound();
        }
    }
}
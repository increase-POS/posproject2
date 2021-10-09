﻿using Newtonsoft.Json;
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
    [RoutePrefix("api/SysEmails")]
    public class SysEmailsController : ApiController
    {
        // GET api/<controller>
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

                        var list = (from S in entity.sysEmails
                                    join B in entity.branches on S.branchId equals B.branchId
                                    select new SysEmailsModel()
                                    {
                                        emailId = S.emailId,
                                        name = S.name,
                                        email = S.email,
                                        password = S.password,
                                        port = S.port,
                                        isSSL = S.isSSL,
                                        smtpClient = S.smtpClient,
                                        side = S.side,
                                        notes = S.notes,
                                        branchId = S.branchId,
                                        isMajor = S.isMajor,
                                        isActive = S.isActive,
                                        createDate = S.createDate,
                                        updateDate = S.updateDate,
                                        createUserId = S.createUserId,
                                        updateUserId = S.updateUserId,
                                        canDelete = true,
                                        branchName = B.name,

                                    }).ToList();

                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(list) };

                    }

                }
                catch
                {
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                }

            }

            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //bool canDelete = false;

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
            //        var List = (from S in  entity.sysEmails     
            //                    join B in entity.branches  on S.branchId equals B.branchId
            //                             select new  SysEmailsModel()
            //                             {
            //                                emailId=S.emailId,
            //                                name=S.name,
            //                                email=S.email,
            //                                password=S.password,
            //                                port=S.port,
            //                                isSSL=S.isSSL,
            //                                smtpClient=S.smtpClient,
            //                                side=S.side,
            //                                notes=S.notes,
            //                                branchId=S.branchId,
            //                                 isMajor= S.isMajor,
            //                                 isActive =S.isActive,
            //                                createDate = S.createDate,
            //                                updateDate = S.updateDate,
            //                                createUserId = S.createUserId,
            //                                updateUserId=S.updateUserId,
            //                                canDelete=true,
            //                                branchName=B.name,

            //                             }).ToList();



            //        if (List == null)
            //            return NotFound();
            //        else
            //            return Ok(List);
            //    }
            //}
            ////else
            //return NotFound();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetByID")]
        public ResponseVM GetByID(string token)
        {

            // public ResponseVM GetPurinv(string token)int emailId

            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                int emailId = 0;


                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "emailId")
                    {
                        emailId = int.Parse(c.Value);
                    }


                }

                // DateTime cmpdate = DateTime.Now.AddDays(newdays);
                try
                {


                    using (incposdbEntities entity = new incposdbEntities())
                    {

                        var item = entity.sysEmails
                           .Where(u => u.emailId == emailId)
                           .Select(S => new
                           {
                               S.emailId,
                               S.name,
                               S.email,
                               S.password,
                               S.port,
                               S.isSSL,
                               S.smtpClient,
                               S.side,
                               S.notes,
                               S.branchId,
                               S.isMajor,
                               S.isActive,
                               S.createDate,
                               S.updateDate,
                               S.createUserId,
                               S.updateUserId,




                           })
                                       .FirstOrDefault();
                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(item) };

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

            //        if (valid)
            //        {
            //            using (incposdbEntities entity = new incposdbEntities())
            //            {
            //                var row = entity.sysEmails
            //               .Where(u => u.emailId == emailId)
            //               .Select(S => new
            //               {
            //                    S.emailId,
            //                      S.name,
            //                    S.email,
            //                       S.password,
            //                     S.port,
            //                    S.isSSL,
            //                    S.smtpClient,
            //                    S.side,
            //                     S.notes,
            //                    S.branchId,
            //                   S.isMajor,
            //                    S.isActive,
            //                     S.createDate,
            //                     S.updateDate,
            //                     S.createUserId,
            //                  S.updateUserId,




            //})
            //               .FirstOrDefault();

            //                if (row == null)
            //                    return NotFound();
            //                else
            //                    return Ok(row);
            //            }
            //        }
            //        else
            //            return NotFound();
        }

        //
        // get 
        [HttpGet]
        [Route("GetByBranchIdandSide")]
        public ResponseVM GetByBranchIdandSide(string token)
        {
            // public ResponseVM GetPurinv(string token)int branchId,string side

            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
                string side = "";
                int branchId = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "branchId")
                    {
                        branchId = int.Parse(c.Value);
                    }
                    else if (c.Type == "side")
                    {
                        side = c.Value;
                    }


                }

                // DateTime cmpdate = DateTime.Now.AddDays(newdays);
                try
                {


                    using (incposdbEntities entity = new incposdbEntities())
                    {

                        //  return email with same branch and side or
                        // return email with same side and isMajor
                        var row = entity.sysEmails
                       .Where(u => u.branchId == branchId && u.side == side)
                       .Select(S => new
                       {
                           S.emailId,
                           S.name,
                           S.email,
                           S.password,
                           S.port,
                           S.isSSL,
                           S.smtpClient,
                           S.side,
                           S.notes,
                           S.branchId,
                           S.isMajor,
                           S.isActive,
                           S.createDate,
                           S.updateDate,
                           S.createUserId,
                           S.updateUserId,


                       })
                       .FirstOrDefault();

                        if (row == null)
                        {
                            var row2 = entity.sysEmails
                         .Where(u => u.side == side && u.isMajor == true)
                         .Select(S => new
                         {
                             S.emailId,
                             S.name,
                             S.email,
                             S.password,
                             S.port,
                             S.isSSL,
                             S.smtpClient,
                             S.side,
                             S.notes,
                             S.branchId,
                             S.isMajor,
                             S.isActive,
                             S.createDate,
                             S.updateDate,
                             S.createUserId,
                             S.updateUserId,
                         }).FirstOrDefault();
                            if (row2 == null)
                            {
                                return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                            }
                            else
                            {
                                return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(row2) };

                            }
                        }

                        else

                            return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(row) };

                    }

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
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            // return email with same branch and side or 
            //        // return email with same side and isMajor
            //        var row = entity.sysEmails
            //       .Where(u => u.branchId == branchId && u.side==side)
            //       .Select(S => new
            //       {
            //           S.emailId,
            //           S.name,
            //           S.email,
            //           S.password,
            //           S.port,
            //           S.isSSL,
            //           S.smtpClient,
            //           S.side,
            //           S.notes,
            //           S.branchId,
            //           S.isMajor,
            //           S.isActive,
            //           S.createDate,
            //           S.updateDate,
            //           S.createUserId,
            //           S.updateUserId,


            //       })
            //       .FirstOrDefault();

            //        if (row == null)
            //        {
            //            var row2 = entity.sysEmails
            //         .Where(u =>  u.side == side && u.isMajor==true)
            //         .Select(S => new
            //         {
            //             S.emailId,
            //             S.name,
            //             S.email,
            //             S.password,
            //             S.port,
            //             S.isSSL,
            //             S.smtpClient,
            //             S.side,
            //             S.notes,
            //             S.branchId,
            //             S.isMajor,
            //             S.isActive,
            //             S.createDate,
            //             S.updateDate,
            //             S.createUserId,
            //             S.updateUserId,
            //         }).FirstOrDefault();

            //            if (row2 == null)
            //            {
            //                return NotFound();
            //            }
            //            else
            //            {

            //                return Ok(row2);
            //            }
            //        }

            //        else
            //            return Ok(row);
            //    }
            //}
            //else
            //    return NotFound();
        }

        // add or update location
        [HttpPost]
        [Route("Save")]
        public ResponseVM Save(string token)
        {

            //string Object 
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
                sysEmails newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Object")
                    {
                        Object = c.Value.Replace("\\", string.Empty);
                        Object = Object.Trim('"');
                        newObject = JsonConvert.DeserializeObject<sysEmails>(Object, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
                if (newObject != null)
                {


                    sysEmails tmpObject = null;


                    try
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
                        using (incposdbEntities entity = new incposdbEntities())
                        {

                            // check if there is other same side in same branch
                            var sidebranch = entity.sysEmails
                              .Where(e => e.branchId == newObject.branchId && e.side == newObject.side && e.emailId != newObject.emailId).ToList();
                            //if not exist continue save
                            if (sidebranch == null || sidebranch.Count() == 0)
                            {
                                var locationEntity = entity.Set<sysEmails>();
                                if (newObject.emailId == 0)
                                {

                                    newObject.createDate = DateTime.Now;
                                    newObject.updateDate = DateTime.Now;
                                    newObject.updateUserId = newObject.createUserId;
                                    //  string encodedStr = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("inputStr"));
                                    // string inputStr = Encoding.UTF8.GetString(Convert.FromBase64String(encodedStr));
                                    locationEntity.Add(newObject);
                                    entity.SaveChanges();
                                    message = newObject.emailId.ToString();
                                }
                                else
                                {
                                    tmpObject = entity.sysEmails.Where(p => p.emailId == newObject.emailId).FirstOrDefault();

                                    tmpObject.updateDate = DateTime.Now;
                                    tmpObject.updateUserId = newObject.updateUserId;

                                    tmpObject.name = newObject.name;
                                    tmpObject.emailId = newObject.emailId;

                                    tmpObject.email = newObject.email;
                                    tmpObject.password = newObject.password;
                                    tmpObject.port = newObject.port;
                                    tmpObject.isSSL = newObject.isSSL;
                                    tmpObject.smtpClient = newObject.smtpClient;
                                    tmpObject.side = newObject.side;
                                    tmpObject.notes = newObject.notes;
                                    tmpObject.branchId = newObject.branchId;

                                    tmpObject.isActive = newObject.isActive;
                                    tmpObject.isMajor = newObject.isMajor;


                                    entity.SaveChanges();

                                    message = tmpObject.emailId.ToString();
                                }
                                //  entity.SaveChanges();

                                return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                            }
                            else
                            {
                                message = "-4";
                                return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                            }
                        }

                    }
                    catch
                    {
                        message = "0";
                        return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
                    }


                }

                // return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken(message) };
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
            //    Object = Object.Replace("\\", string.Empty);
            //    Object = Object.Trim('"');
            //    sysEmails newObject = JsonConvert.DeserializeObject<sysEmails>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
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

            //            // check if there is other same side in same branch
            //            var sidebranch = entity.sysEmails
            //              .Where(e => e.branchId == newObject.branchId && e.side == newObject.side && e.emailId != newObject.emailId).ToList();
            //            //if not exist continue save
            //            if (sidebranch == null || sidebranch.Count()==0)
            //            { 
            //                var locationEntity = entity.Set<sysEmails>();
            //            if (newObject.emailId == 0)
            //            {

            //                newObject.createDate = DateTime.Now;
            //                newObject.updateDate = DateTime.Now;
            //                newObject.updateUserId = newObject.createUserId;
            //                //  string encodedStr = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("inputStr"));
            //                // string inputStr = Encoding.UTF8.GetString(Convert.FromBase64String(encodedStr));
            //                locationEntity.Add(newObject);
            //                entity.SaveChanges();
            //                message = newObject.emailId.ToString();
            //            }
            //            else
            //            {
            //                var tmpObject = entity.sysEmails.Where(p => p.emailId == newObject.emailId).FirstOrDefault();

            //                tmpObject.updateDate = DateTime.Now;
            //                tmpObject.updateUserId = newObject.updateUserId;

            //                tmpObject.name = newObject.name;
            //                tmpObject.emailId = newObject.emailId;

            //                tmpObject.email = newObject.email;
            //                tmpObject.password = newObject.password;
            //                tmpObject.port = newObject.port;
            //                tmpObject.isSSL = newObject.isSSL;
            //                tmpObject.smtpClient = newObject.smtpClient;
            //                tmpObject.side = newObject.side;
            //                tmpObject.notes = newObject.notes;
            //                tmpObject.branchId = newObject.branchId;

            //                tmpObject.isActive = newObject.isActive;
            //                tmpObject.isMajor = newObject.isMajor;


            //                entity.SaveChanges();

            //                message = tmpObject.emailId.ToString();
            //            }
            //            //  entity.SaveChanges();
            //        }
            //            else
            //            {
            //                message = "-4";
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        message = "-1";
            //    }
            //}
            //return message;
        }

        [HttpPost]
        [Route("Delete")]
        public ResponseVM Delete(string token)
        {
            // public ResponseVM Delete(string token)int emailId, int userId, bool final
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
                int emailId = 0;
                int userId = 0;
                bool final = false;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "emailId")
                    {
                        emailId = int.Parse(c.Value);
                    }
                    else if (c.Type == "userId")
                    {
                        userId = int.Parse(c.Value);
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
                        sysEmails objectDelete = entity.sysEmails.Find(emailId);

                        entity.sysEmails.Remove(objectDelete);
                        message = entity.SaveChanges().ToString();

                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };

                    }
                  //  return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(message) };
                }
                catch
                {
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                }


            }

            //var re = Request;
            //var headers = re.Headers;
            //string token = "";
            //int message = 0;
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}

            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);
            //if (valid)
            //{
            //    if (final)
            //    {
            //        try
            //        {
            //            using (incposdbEntities entity = new incposdbEntities())
            //            {
            //                sysEmails objectDelete = entity.sysEmails.Find(emailId);

            //                entity.sysEmails.Remove(objectDelete);
            //                message = entity.SaveChanges();

            //                return message.ToString();
            //            }
            //        }
            //        catch
            //        {
            //            return "-1";
            //        }
            //    }
            //    else
            //    {
            //        try
            //        {
            //            using (incposdbEntities entity = new incposdbEntities())
            //            {
            //                sysEmails objectDelete = entity.sysEmails.Find(emailId);

            //                objectDelete.isActive = 0;
            //                objectDelete.updateUserId = userId;
            //                objectDelete.updateDate = DateTime.Now;
            //                message = entity.SaveChanges();

            //                return message.ToString(); ;
            //            }
            //        }
            //        catch
            //        {
            //            return "-2";
            //        }
            //    }
            //}
            //else
            //    return "-3";
        }



    }
}
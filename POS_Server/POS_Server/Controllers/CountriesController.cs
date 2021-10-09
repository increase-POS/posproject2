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

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Countries")]
    public class CountriesController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("GetAllCountries")]
        public ResponseVM GetAllCountries()
        {

            // public ResponseVM GetPurinv(string token)

            //int mainBranchId, int userId    DateTime? date=new DateTime?();
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


                        var countrylist = entity.countriesCodes
                         .Select(c => new
                         {
                             c.countryId,
                             c.code,
                         }).ToList();



                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(countrylist) };

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

            //if (valid) // APIKey is valid
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var countrylist = entity.countriesCodes
            //             .Select(c => new {
            //                 c.countryId,
            //                 c.code,
            //             }).ToList();


            //        if (countrylist == null)
            //           return NotFound();
            //        else
            //            return Ok(countrylist);
            //    }
            //}
            //else
            //    return NotFound();


        }


        //[HttpGet]
        //[Route("GetAllCities")]
        //public IHttpActionResult GetAllCities()
        //{
        //    var re = Request;
        //    var headers = re.Headers;
        //    string token = "";

        //    if (headers.Contains("APIKey"))
        //    {
        //        token = headers.GetValues("APIKey").First();
        //    }
        //    Validation validation = new Validation();
        //    bool valid = validation.CheckApiKey(token);

        //    if (valid) // APIKey is valid
        //    {
        //        using (incposdbEntities entity = new incposdbEntities())
        //        {
        //            var countrylist = entity.countriesCodes
        //                 .Select(c => new {
        //                     c.countryId,
        //                     c.code,
        //                     c.isDefault,
        //                 }).ToList();


        //            if (countrylist == null)
        //            { return Ok(countrylist); }
        //            //return ("no");
        //            //return NotFound();
        //            else
        //            { return Ok(countrylist);}
                        
        //        }
        //    }
        //    else
        //        return NotFound();
        //}



        [HttpGet]
        [Route("GetAllRegion")]
        public ResponseVM GetAllRegion()
        {
            // public ResponseVM GetPurinv(string token)

            //int mainBranchId, int userId    DateTime? date=new DateTime?();
            var re = Request;
            var headers = re.Headers;
            var jwt = headers.GetValues("Authorization").First();
            if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
            {
                return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
            }
            else
            {
        
                try
                {


                    using (incposdbEntities entity = new incposdbEntities())
                    {

                        var countrylist = entity.countriesCodes
                         .Select(c => new
                         {
                             c.countryId,
                             c.code,
                             c.currency,
                             c.name,
                             c.isDefault,
                             c.currencyId,

                         }).ToList();


                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(countrylist) };

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

            //if (valid) // APIKey is valid
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var countrylist = entity.countriesCodes
            //             .Select(c => new {
            //                 c.countryId,
            //                 c.code,
            //                 c.currency,
            //                 c.name,
            //                 c.isDefault,
            //                 c.currencyId,

            //             }).ToList();


            //        if (countrylist == null)
            //            return NotFound();
            //        else
            //            return Ok(countrylist);
            //    }
            //}
            //else
            //    return NotFound();
        }

        [HttpPost]
        [Route("UpdateIsdefault")]
        public ResponseVM UpdateIsdefault(string token)
        {
            //int countryId
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
                int countryId = 0;
             
               
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "countryId")
                    {
                        countryId = int.Parse(c.Value);
                    }
                   
                }
                
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                       // reset all to 0
                                    List<countriesCodes> objectlist = entity.countriesCodes.Where(x => x.isDefault == 1).ToList();
                        if (objectlist.Count > 0)
                        {
                            for (int i = 0; i < objectlist.Count; i++)
                            {
                                objectlist[i].isDefault = 0;

                            }
                            entity.SaveChanges();
                        }
                        // set is selected to isdefault=1
                        countriesCodes objectrow = entity.countriesCodes.Find(countryId);

                        if (objectrow != null)
                        {
                            objectrow.isDefault = 1;
                           
       
                           int res=  entity.SaveChanges();
                            if (res > 0)
                            {
                                message = objectrow.countryId.ToString();
                            }
                            else
                            {
                                return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                            }
                        }
                        else
                        {
                            return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                        }
                        //  entity.SaveChanges();



                      


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
            //string message = "";
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
            //            // reset all to 0
            //            List<countriesCodes> objectlist = entity.countriesCodes.Where(x=>x.isDefault==1).ToList();
            //            if (objectlist.Count > 0)
            //            {
            //                for(int i=0;i< objectlist.Count; i++)
            //                {
            //                    objectlist[i].isDefault = 0;

            //                }
            //                entity.SaveChanges();
            //            }
            //            // set is selected to isdefault=1
            //            countriesCodes objectrow = entity.countriesCodes.Find(countryId);

            //            if (objectrow != null)
            //            {
            //                objectrow.isDefault = 1;

            //                message = objectrow.countryId.ToString();
            //                entity.SaveChanges();
            //            }
            //            else
            //            {
            //                message = "-1";
            //            }
            //            //  entity.SaveChanges();
            //        }
            //    }
            //    catch
            //    {
            //        message = "-1";
            //    }
            //}
            //return message;
        }

        [HttpGet]
        [Route("GetByID")]
        public ResponseVM GetByID(string token)
        {

            // public ResponseVM GetPurinv(string token)

            //int mainBranchId, int userId    DateTime? date=new DateTime?();
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
               // int userId = 0;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Id")
                    {
                        Id = int.Parse(c.Value);
                    }
                 

                }

                // DateTime cmpdate = DateTime.Now.AddDays(newdays);
                try
                {


                    using (incposdbEntities entity = new incposdbEntities())
                    {


                        var list = entity.countriesCodes
                   .Where(c => c.countryId == Id)
                   .Select(c => new
                   {
                       c.countryId,
                       c.code,
                       c.currency,
                       c.name,
                       c.isDefault,
                       c.currencyId,
                   })
                   .FirstOrDefault();

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
            //        var list = entity.countriesCodes
            //       .Where(c => c.countryId == cId)
            //       .Select(c => new {
            //           c.countryId,
            //           c.code,
            //           c.currency,
            //           c.name,
            //           c.isDefault,
            //           c.currencyId,
            //       })
            //       .FirstOrDefault();

            //        if (list == null)
            //            return NotFound();
            //        else
            //            return Ok(list);
            //    }
            //}
            //else
            //    return NotFound();
        }

        [HttpGet]
        [Route("GetisDefault")]
        public ResponseVM GetisDefault(string token)
        {

            // public ResponseVM GetPurinv(string token)

            //int mainBranchId, int userId    DateTime? date=new DateTime?();
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
               int isDefault = 0;

                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "isDefault")
                    {
                        isDefault = int.Parse(c.Value);
                    }
               

                }

                // DateTime cmpdate = DateTime.Now.AddDays(newdays);
                try
                {


                    using (incposdbEntities entity = new incposdbEntities())
                    {


                        var list = entity.countriesCodes
                   .Where(c => c.isDefault == isDefault)
                   .Select(c => new
                   {
                       c.countryId,
                       c.code,
                       c.currency,
                       c.name,
                       c.isDefault,
                       c.currencyId,
                   })
                   .FirstOrDefault();


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
            //int cId = 0;
            //if (headers.Contains("APIKey"))
            //{
            //    token = headers.GetValues("APIKey").First();
            //}
            //if (headers.Contains("isDefault"))
            //{
            //    cId = Convert.ToInt32(headers.GetValues("isDefault").First());
            //}
            //Validation validation = new Validation();
            //bool valid = validation.CheckApiKey(token);

            //if (valid)
            //{
            //    using (incposdbEntities entity = new incposdbEntities())
            //    {
            //        var list = entity.countriesCodes
            //       .Where(c => c.isDefault == cId)
            //       .Select(c => new {
            //           c.countryId,
            //           c.code,
            //           c.currency,
            //           c.name,
            //           c.isDefault,
            //           c.currencyId,
            //       })
            //       .FirstOrDefault();

            //        if (list == null)
            //            return NotFound();
            //        else
            //            return Ok(list);
            //    }
            //}
            //else
            //    return NotFound();
        }


    }
}
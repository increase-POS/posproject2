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
    [RoutePrefix("api/city")]
    public class cityController : ApiController
    {
      
        [HttpGet]
        [Route("Get")]
        public ResponseVM Get()
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

                        var cityList = entity.cities

                   .Select(c => new
                   {
                       c.cityId,
                       c.cityCode,
                       c.countryId
                   })
                   .ToList();



                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(cityList) };

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
            //        var cityList = entity.cities
                  
            //       .Select(c => new {
            //        c.cityId,   
            //        c.cityCode,
            //        c.countryId
            //       })
            //       .ToList();

            //        if (cityList == null)
            //            return NotFound();
            //        else
            //            return Ok(cityList);
            //    }
            //}
            ////else
            //    return NotFound();
        }



       
    }
}
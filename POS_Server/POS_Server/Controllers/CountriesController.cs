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
    [RoutePrefix("api/Countries")]
    public class CountriesController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("GetAllCountries")]
        public IHttpActionResult GetAllCountries()
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
                    var countrylist = entity.countriesCodes
                         .Select(c => new {
                             c.countryId,
                             c.code,
                         }).ToList();
                        
                    
                    if (countrylist == null)
                       return NotFound();
                    else
                        return Ok(countrylist);
                }
            }
            else
                return NotFound();
        }


        [HttpGet]
        [Route("GetAllCities")]
        public IHttpActionResult GetAllCities()
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
                    var countrylist = entity.countriesCodes
                         .Select(c => new {
                             c.countryId,
                             c.code,
                         }).ToList();


                    if (countrylist == null)
                    { return Ok(countrylist); }
                    //return ("no");
                    //return NotFound();
                    else
                    { return Ok(countrylist);}
                        
                }
            }
            else
                return NotFound();
        }







    }
}
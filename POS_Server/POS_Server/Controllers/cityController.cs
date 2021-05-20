﻿using Newtonsoft.Json;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/city")]
    public class cityController : ApiController
    {
        // GET api/<controller> get all coupons
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
                    var cityList = entity.cities
                  
                   .Select(c => new {
                    c.cityId,   
                    c.cityCode,
                    c.countryId
                   })
                   .ToList();

                    if (cityList == null)
                        return NotFound();
                    else
                        return Ok(cityList);
                }
            }
            //else
                return NotFound();
        }



       
    }
}
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
    [RoutePrefix("api/PosSetting")]
    public class PosSettingController : ApiController
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
                    var List = (from S in entity.posSetting
                               join psal in entity.printers on S.saleInvPrinterId equals psal.printerId into jsale
                               join prep in entity.printers on S.reportPrinterId equals prep.printerId into jrep
                               join paper in entity.paperSize on S.saleInvPapersizeId equals paper.sizeId into jpaper
                            
                                from jjsale in jsale.DefaultIfEmpty()
                                from jjrep in jrep.DefaultIfEmpty()
                                from jjpaper in jpaper.DefaultIfEmpty()
                            
                                select new PosSettingModel()
                                {
                                    posSettingId = S.posSettingId,

                                    posId = S.posId,
                                    saleInvPrinterId = S.saleInvPrinterId,
                                    reportPrinterId = S.reportPrinterId,
                                    saleInvPapersizeId = S.saleInvPapersizeId,
                                    posSerial = S.posSerial,
                                 
                                    repprinterId = jjrep.printerId,
                                    repname = jjrep.name,
                                    repprintFor = jjrep.printFor,
                                    salprinterId = jjsale.printerId,
                                    salname = jjsale.name,
                                    salprintFor = jjsale.printFor,
                                    sizeId = jjpaper.sizeId,
                                    paperSize1 = jjpaper.paperSize1,                                                                  

                                }).ToList();
                    /*
   public int posSettingId { get; set; }
        public Nullable<int> posId { get; set; }
        public Nullable<int> saleInvPrinterId { get; set; }
        public Nullable<int> reportPrinterId { get; set; }
        public Nullable<int> saleInvPapersize { get; set; }

        public string posSerial { get; set; }

        public int repprinterId { get; set; }
        public string repname { get; set; }
        public string repprintFor { get; set; }

        public int salprinterId { get; set; }
        public string salname { get; set; }
        public string salprintFor { get; set; }

        public int sizeId { get; set; }
        public string paperSize1 { get; set; }

                    */

                  

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
        public IHttpActionResult GetByID(int posSettingId)
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
                    var row = (from S in entity.posSetting
                                join psal in entity.printers on S.saleInvPrinterId equals psal.printerId into jsale
                                join prep in entity.printers on S.reportPrinterId equals prep.printerId into jrep
                                join paper in entity.paperSize on S.saleInvPapersizeId equals paper.sizeId into jpaper

                                from jjsale in jsale.DefaultIfEmpty()
                                from jjrep in jrep.DefaultIfEmpty()
                                from jjpaper in jpaper.DefaultIfEmpty()
                                where S.posSettingId==posSettingId
                                select new PosSettingModel()
                                {
                                    posSettingId = S.posSettingId,

                                    posId = S.posId,
                                    saleInvPrinterId = S.saleInvPrinterId,
                                    reportPrinterId = S.reportPrinterId,
                                    saleInvPapersizeId = S.saleInvPapersizeId,
                                    posSerial = S.posSerial,
                                    repprinterId = jjrep.printerId,
                                    repname = jjrep.name,
                                    repprintFor = jjrep.printFor,
                                    salprinterId = jjsale.printerId,
                                    salname = jjsale.name,
                                    salprintFor = jjsale.printFor,
                                    sizeId = jjpaper.sizeId,
                                    paperSize1 = jjpaper.paperSize1,



                                }).FirstOrDefault();

                    if (row == null)
                        return NotFound();
                    else
                        return Ok(row);
                }
            }
            else
                return NotFound();
        }


        // get by posId
        // GET api/<controller>
        [HttpGet]
        [Route("GetByposId")]
        public IHttpActionResult GetByposId(int posId)
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
                    var row = (from S in entity.posSetting
                               join psal in entity.printers on S.saleInvPrinterId equals psal.printerId into jsale
                               join prep in entity.printers on S.reportPrinterId equals prep.printerId into jrep
                               join paper in entity.paperSize on S.saleInvPapersizeId equals paper.sizeId into jpaper

                               from jjsale in jsale.DefaultIfEmpty()
                               from jjrep in jrep.DefaultIfEmpty()
                               from jjpaper in jpaper.DefaultIfEmpty()
                               where S.posId == posId
                               select new PosSettingModel()
                               {
                                   posSettingId = S.posSettingId,

                                   posId = S.posId,
                                   saleInvPrinterId = S.saleInvPrinterId,
                                   reportPrinterId = S.reportPrinterId,
                                   saleInvPapersizeId = S.saleInvPapersizeId,
                                   posSerial = S.posSerial,
                                   repprinterId = jjrep.printerId,
                                   repname = jjrep.name,
                                   repprintFor = jjrep.printFor,
                                   salprinterId = jjsale.printerId,
                                   salname = jjsale.name,
                                   salprintFor = jjsale.printFor,
                                   sizeId = jjpaper.sizeId,
                                   paperSize1 = jjpaper.paperSize1,



                               }).FirstOrDefault();

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
                posSetting newObject = JsonConvert.DeserializeObject<posSetting>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                if (newObject.posId == 0 || newObject.posId == null)
                {
                    Nullable<int> id = null;
                    newObject.posId = id; 
                }
                if (newObject.reportPrinterId == 0 || newObject.reportPrinterId == null)
                {
                    Nullable<int> id = null;
                    newObject.reportPrinterId = id;
                }
                if (newObject.saleInvPapersizeId == 0 || newObject.saleInvPapersizeId == null)
                {
                    Nullable<int> id = null;
                    newObject.saleInvPapersizeId = id;
                }
                if (newObject.saleInvPrinterId == 0 || newObject.saleInvPrinterId == null)
                {
                    Nullable<int> id = null;
                    newObject.saleInvPrinterId = id;
                }

                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var locationEntity = entity.Set<posSetting>();
                        if (newObject.posSettingId == 0)
                        {
                           


                            locationEntity.Add(newObject);
                            entity.SaveChanges();
                            message = newObject.posSettingId.ToString();
                        }
                        else
                        {
                            var tmpObject = entity.posSetting.Where(p => p.posSettingId == newObject.posSettingId).FirstOrDefault();

                         
                          
                            tmpObject.posSettingId = newObject.posSettingId;

                                    tmpObject.posId = newObject.posId;
                                   tmpObject. saleInvPrinterId = newObject.saleInvPrinterId;
                                    tmpObject.reportPrinterId =newObject.reportPrinterId;
                                    tmpObject.saleInvPapersizeId = newObject.saleInvPapersizeId;
                                  //  tmpObject.posSerial = newObject.posSerial;
                                 
                                  

                       
                            entity.SaveChanges();

                            message = tmpObject.posSettingId.ToString();
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
        public string Delete(int posSettingId)
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
                            posSetting objectDelete = entity.posSetting.Find(posSettingId);

                            entity.posSetting.Remove(objectDelete);
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
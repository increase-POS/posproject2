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
    [RoutePrefix("api/PosSetting")]
    public class PosSettingController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public ResponseVM GetAll()
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


                        var List = (from S in entity.posSetting
                                    join psal in entity.printers on S.saleInvPrinterId equals psal.printerId into jsale
                                    join prep in entity.printers on S.reportPrinterId equals prep.printerId into jrep
                                    join paper in entity.paperSize on S.saleInvPapersizeId equals paper.sizeId into jpaper
                                    join dpaper in entity.paperSize on S.docPapersizeId equals dpaper.sizeId into jdcpaper
                                    from jjsale in jsale.DefaultIfEmpty()
                                    from jjrep in jrep.DefaultIfEmpty()
                                    from jjpaper in jpaper.DefaultIfEmpty()
                                    from jdocpaper in jdcpaper.DefaultIfEmpty()
                                    select new PosSettingModel()
                                    {
                                        posSettingId = S.posSettingId,

                                        posId = S.posId,
                                        saleInvPrinterId = S.saleInvPrinterId,
                                        reportPrinterId = S.reportPrinterId,
                                        saleInvPapersizeId = S.saleInvPapersizeId,
                                        posSerial = S.posSerial,

                                        repprinterId = jjrep.printerId,//printer
                                        repname = jjrep.name,//printer
                                        repprintFor = jjrep.printFor,//printer
                                        salprinterId = jjsale.printerId,//printer
                                        salname = jjsale.name,//printer
                                        salprintFor = jjsale.printFor,//printer
                                        sizeId = jjpaper.sizeId,// paper
                                        paperSize1 = jjpaper.paperSize1,// paper saleInvPapersize
                                        saleSizeValue = jjpaper.sizeValue,// paper sale
                                        docSizeValue = jdocpaper.sizeValue,// paper doc
                                        docPapersize = jdocpaper.paperSize1,// paper
                                        docPapersizeId = S.docPapersizeId,// paper

                                    }).ToList();


                        return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(List) };

                    }

                }
                catch
                {
                    return new ResponseVM { Status = "Fail", Message = TokenManager.GenerateToken("0") };
                }

            }




   //         var re = Request;
   //         var headers = re.Headers;
   //         string token = "";


   //         if (headers.Contains("APIKey"))
   //         {
   //             token = headers.GetValues("APIKey").First();
   //         }
   //         Validation validation = new Validation();
   //         bool valid = validation.CheckApiKey(token);

   //         if (valid) // APIKey is valid
   //         {
   //             using (incposdbEntities entity = new incposdbEntities())
   //             {
   //                 var List = (from S in entity.posSetting
   //                             join psal in entity.printers on S.saleInvPrinterId equals psal.printerId into jsale
   //                             join prep in entity.printers on S.reportPrinterId equals prep.printerId into jrep
   //                             join paper in entity.paperSize on S.saleInvPapersizeId equals paper.sizeId into jpaper
   //                             join dpaper in entity.paperSize on S.docPapersizeId equals dpaper.sizeId into jdcpaper
   //                             from jjsale in jsale.DefaultIfEmpty()
   //                             from jjrep in jrep.DefaultIfEmpty()
   //                             from jjpaper in jpaper.DefaultIfEmpty()
   //                             from jdocpaper in jdcpaper.DefaultIfEmpty()
   //                             select new PosSettingModel()
   //                             {
   //                                 posSettingId = S.posSettingId,

   //                                 posId = S.posId,
   //                                 saleInvPrinterId = S.saleInvPrinterId,
   //                                 reportPrinterId = S.reportPrinterId,
   //                                 saleInvPapersizeId = S.saleInvPapersizeId,
   //                                 posSerial = S.posSerial,

   //                                 repprinterId = jjrep.printerId,//printer
   //                                 repname = jjrep.name,//printer
   //                                 repprintFor = jjrep.printFor,//printer
   //                                 salprinterId = jjsale.printerId,//printer
   //                                 salname = jjsale.name,//printer
   //                                 salprintFor = jjsale.printFor,//printer
   //                                 sizeId = jjpaper.sizeId,// paper
   //                                 paperSize1 = jjpaper.paperSize1,// paper saleInvPapersize
   //                                 saleSizeValue= jjpaper.sizeValue,// paper sale
   //                                 docSizeValue = jdocpaper.sizeValue,// paper doc
   //                                 docPapersize = jdocpaper.paperSize1,// paper
   //                                 docPapersizeId = S.docPapersizeId,// paper

   //                             }).ToList();
   //                 /*
   //public int posSettingId { get; set; }
   //     public Nullable<int> posId { get; set; }
   //     public Nullable<int> saleInvPrinterId { get; set; }
   //     public Nullable<int> reportPrinterId { get; set; }
   //     public Nullable<int> saleInvPapersize { get; set; }

   //     public string posSerial { get; set; }

   //     public int repprinterId { get; set; }
   //     public string repname { get; set; }
   //     public string repprintFor { get; set; }

   //     public int salprinterId { get; set; }
   //     public string salname { get; set; }
   //     public string salprintFor { get; set; }

   //     public int sizeId { get; set; }
   //     public string paperSize1 { get; set; }

   //                 */



   //                 if (List == null)
   //                     return NotFound();
   //                 else
   //                     return Ok(List);
   //             }
   //         }
   //         //else
   //         return NotFound();
        }

    
        //[HttpGet]
        //[Route("GetByID")]
        //public IHttpActionResult GetByID(int posSettingId)
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

        //    if (valid)
        //    {
        //        using (incposdbEntities entity = new incposdbEntities())
        //        {
        //            var row = (from S in entity.posSetting
        //                       join psal in entity.printers on S.saleInvPrinterId equals psal.printerId into jsale
        //                       join prep in entity.printers on S.reportPrinterId equals prep.printerId into jrep
        //                       join paper in entity.paperSize on S.saleInvPapersizeId equals paper.sizeId into jpaper
        //                       join dpaper in entity.paperSize on S.docPapersizeId equals dpaper.sizeId into jdcpaper
        //                       from jdocpaper in jdcpaper.DefaultIfEmpty()

        //                       from jjsale in jsale.DefaultIfEmpty()
        //                       from jjrep in jrep.DefaultIfEmpty()
        //                       from jjpaper in jpaper.DefaultIfEmpty()
        //                       where S.posSettingId == posSettingId
        //                       select new PosSettingModel()
        //                       {
        //                           posSettingId = S.posSettingId,

        //                           posId = S.posId,
        //                           saleInvPrinterId = S.saleInvPrinterId,
        //                           reportPrinterId = S.reportPrinterId,
        //                           saleInvPapersizeId = S.saleInvPapersizeId,
        //                           posSerial = S.posSerial,
        //                           repprinterId = jjrep.printerId,
        //                           repname = jjrep.name,
        //                           repprintFor = jjrep.printFor,
        //                           salprinterId = jjsale.printerId,
        //                           salname = jjsale.name,
        //                           salprintFor = jjsale.printFor,
        //                           sizeId = jjpaper.sizeId,
        //                           paperSize1 = jjpaper.paperSize1,

        //                           docPapersize = jdocpaper.paperSize1,
        //                           docPapersizeId = S.docPapersizeId,
        //                           saleSizeValue = jjpaper.sizeValue,// paper sale
        //                           docSizeValue = jdocpaper.sizeValue,// paper doc
        //                       }).FirstOrDefault();

        //            if (row == null)
        //                return NotFound();
        //            else
        //                return Ok(row);
        //        }
        //    }
        //    else
        //        return NotFound();
        //}


        // get by posId

        [HttpGet]
        [Route("GetByposId")]
        public ResponseVM GetByposId(string token)
        {
            // public ResponseVM GetItemByID(string token)int posId
            // {
            var re = Request;
                var headers = re.Headers;
                var jwt = headers.GetValues("Authorization").First();
                if (TokenManager.GetPrincipal(jwt) == null)//invalid authorization
                {
                    return new ResponseVM { Status = "Fail", Message = "invalid authorization" };
                }
                else
                {
                    int posId = 0;
                    IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                    foreach (Claim c in claims)
                    {
                        if (c.Type == "posId")
                        {
                        posId = int.Parse(c.Value);
                        }
                    }
                    using (incposdbEntities entity = new incposdbEntities())
                    {

                    var item = (from S in entity.posSetting
                               join psal in entity.printers on S.saleInvPrinterId equals psal.printerId into jsale
                               join prep in entity.printers on S.reportPrinterId equals prep.printerId into jrep
                               join paper in entity.paperSize on S.saleInvPapersizeId equals paper.sizeId into jpaper
                               join dpaper in entity.paperSize on S.docPapersizeId equals dpaper.sizeId into jdcpaper
                               from jdocpaper in jdcpaper.DefaultIfEmpty()
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
                                   docPapersize = jdocpaper.paperSize1,
                                   docPapersizeId = S.docPapersizeId,
                                   saleSizeValue = jjpaper.sizeValue,// paper sale
                                   docSizeValue = jdocpaper.sizeValue,// paper doc
                               }).FirstOrDefault();
                    return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(item) };
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
                //        var row = (from S in entity.posSetting
                //                   join psal in entity.printers on S.saleInvPrinterId equals psal.printerId into jsale
                //                   join prep in entity.printers on S.reportPrinterId equals prep.printerId into jrep
                //                   join paper in entity.paperSize on S.saleInvPapersizeId equals paper.sizeId into jpaper
                //                   join dpaper in entity.paperSize on S.docPapersizeId equals dpaper.sizeId into jdcpaper
                //                   from jdocpaper in jdcpaper.DefaultIfEmpty()
                //                   from jjsale in jsale.DefaultIfEmpty()
                //                   from jjrep in jrep.DefaultIfEmpty()
                //                   from jjpaper in jpaper.DefaultIfEmpty()
                //                   where S.posId == posId
                //                   select new PosSettingModel()
                //                   {
                //                       posSettingId = S.posSettingId,

                //                       posId = S.posId,
                //                       saleInvPrinterId = S.saleInvPrinterId,
                //                       reportPrinterId = S.reportPrinterId,
                //                       saleInvPapersizeId = S.saleInvPapersizeId,
                //                       posSerial = S.posSerial,
                //                       repprinterId = jjrep.printerId,
                //                       repname = jjrep.name,
                //                       repprintFor = jjrep.printFor,
                //                       salprinterId = jjsale.printerId,
                //                       salname = jjsale.name,
                //                       salprintFor = jjsale.printFor,
                //                       sizeId = jjpaper.sizeId,
                //                       paperSize1 = jjpaper.paperSize1,
                //                       docPapersize = jdocpaper.paperSize1,
                //                       docPapersizeId=S.docPapersizeId,
                //                       saleSizeValue = jjpaper.sizeValue,// paper sale
                //                       docSizeValue = jdocpaper.sizeValue,// paper doc
                //                   }).FirstOrDefault();

                //        if (row == null)
                //            return NotFound();
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
        public ResponseVM  Save(string token)
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
                posSetting newObject = null;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "Object")
                    {
                        Object = c.Value.Replace("\\", string.Empty);
                        Object = Object.Trim('"');
                        newObject = JsonConvert.DeserializeObject<posSetting>(Object, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                        break;
                    }
                }
                if (newObject != null)
                {


                    posSetting tmpObject;
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
                                tmpObject = entity.posSetting.Where(p => p.posSettingId == newObject.posSettingId).FirstOrDefault();


                                tmpObject.posSettingId = newObject.posSettingId;

                                tmpObject.posId = newObject.posId;
                                tmpObject.saleInvPrinterId = newObject.saleInvPrinterId;
                                tmpObject.reportPrinterId = newObject.reportPrinterId;
                                tmpObject.saleInvPapersizeId = newObject.saleInvPapersizeId;
                                tmpObject.docPapersizeId = newObject.docPapersizeId;
                                //  tmpObject.posSerial = newObject.posSerial;      public Nullable<int> docPapersizeId { get; set; }




                                entity.SaveChanges();

                                message = tmpObject.posSettingId.ToString();
                            }
                            //  entity.SaveChanges();
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
            //    Object = Object.Replace("\\", string.Empty);
            //    Object = Object.Trim('"');
            //    posSetting newObject = JsonConvert.DeserializeObject<posSetting>(Object, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            //    if (newObject.posId == 0 || newObject.posId == null)
            //    {
            //        Nullable<int> id = null;
            //        newObject.posId = id;
            //    }
            //    if (newObject.reportPrinterId == 0 || newObject.reportPrinterId == null)
            //    {
            //        Nullable<int> id = null;
            //        newObject.reportPrinterId = id;
            //    }
            //    if (newObject.saleInvPapersizeId == 0 || newObject.saleInvPapersizeId == null)
            //    {
            //        Nullable<int> id = null;
            //        newObject.saleInvPapersizeId = id;
            //    }
            //    if (newObject.saleInvPrinterId == 0 || newObject.saleInvPrinterId == null)
            //    {
            //        Nullable<int> id = null;
            //        newObject.saleInvPrinterId = id;
            //    }

            //    try
            //    {
            //        using (incposdbEntities entity = new incposdbEntities())
            //        {
            //            var locationEntity = entity.Set<posSetting>();
            //            if (newObject.posSettingId == 0)
            //            {



            //                locationEntity.Add(newObject);
            //                entity.SaveChanges();
            //                message = newObject.posSettingId.ToString();
            //            }
            //            else
            //            {
            //                var tmpObject = entity.posSetting.Where(p => p.posSettingId == newObject.posSettingId).FirstOrDefault();


            //                tmpObject.posSettingId = newObject.posSettingId;

            //                tmpObject.posId = newObject.posId;
            //                tmpObject.saleInvPrinterId = newObject.saleInvPrinterId;
            //                tmpObject.reportPrinterId = newObject.reportPrinterId;
            //                tmpObject.saleInvPapersizeId = newObject.saleInvPapersizeId;
            //                tmpObject.docPapersizeId = newObject.docPapersizeId;
            //                //  tmpObject.posSerial = newObject.posSerial;      public Nullable<int> docPapersizeId { get; set; }




            //                entity.SaveChanges();

            //                message = tmpObject.posSettingId.ToString();
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

        [HttpPost]
        [Route("Delete")]
        public ResponseVM Delete(string token)
        {
            //int posSettingId  Save()
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
                int posSettingId = 0;
             
        
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "posSettingId")
                    {
                        posSettingId = int.Parse(c.Value);
                    }
                
                }
              
                    try
                    {
                        using (incposdbEntities entity = new incposdbEntities())
                        {
                           
                                posSetting objectDelete = entity.posSetting.Find(posSettingId);

                                entity.posSetting.Remove(objectDelete);
                                message = entity.SaveChanges().ToString();


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
            //int message = 0;
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
            //            posSetting objectDelete = entity.posSetting.Find(posSettingId);

            //            entity.posSetting.Remove(objectDelete);
            //            message = entity.SaveChanges();

            //            return message.ToString();
            //        }
            //    }
            //    catch
            //    {
            //        return "-1";
            //    }


            //}
            //else
            //    return "-3";
        }



    }
}
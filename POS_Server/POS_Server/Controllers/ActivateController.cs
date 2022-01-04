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
using System.Web;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;
using System.Management;

namespace POS_Server.Controllers
{
    [RoutePrefix("api/Activate")]
    public class ActivateController : ApiController
    {


        public string ServerID()
        {
            string deviceCode = "";
            // deviceCode = GetMotherBoardID() + "-" + GetHDDSerialNo();
            deviceCode = GetHDDSerialNo();
            return deviceCode;
        }
        public static string GetMotherBoardID()
        {
            string mbInfo = String.Empty;
            ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
            scope.Connect();
            ManagementObject wmiClass = new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions());

            foreach (PropertyData propData in wmiClass.Properties)
            {
                if (propData.Name == "SerialNumber")
                    mbInfo = Convert.ToString(propData.Value);
            }

            return mbInfo;
        }
        public static String GetHDDSerialNo()
        {
            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            string result = "";
            foreach (ManagementObject strt in mcol)
            {
                result += Convert.ToString(strt["VolumeSerialNumber"]);
            }
            return result;
        }
        public async Task<SendDetail> GetSerialsAndDetails(string packageSaleCode, string customerServerCode)
        {
            SendDetail item = new SendDetail();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("packageSaleCode", packageSaleCode);
            parameters.Add("customerServerCode", customerServerCode);

            //#################
            IEnumerable<Claim> claims = await APIResult.getList("packageUser/ActivateServer", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = JsonConvert.DeserializeObject<SendDetail>(c.Value, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });

                }
            }
            return item;

        }
        public List<PosSerialSend> getserialsinfo()
        {
            SendDetail sd = new SendDetail();
            packagesSend packs = new packagesSend();
            List<PosSerialSend> serialsendList = new List<PosSerialSend>();

            using (incposdbEntities entity = new incposdbEntities())
            {
                serialsendList = (from PS in entity.posSetting
                                  join S in entity.posSerials on PS.posSerialId equals S.id
                                  //  join p in entity.posSetting on S.id equals p.posSerialId
                                  where PS.posSerialId!=null
                                  select new PosSerialSend 
                                  {
                                      serial = S.posSerial,
                                      isActive = (S.isActive == true) ? 1 : 0,
                                      // isBooked=true,
                                      posName=PS.pos.name,
                                      branchName=PS.pos.branches.name,
                                      posId=PS.posId,
                                      posSettingId=PS.posSettingId,
                                      //  isBooked = S.posSetting.Where(x => x.posSerialId == S.id).ToList().Count > 0 ? true : false,
                                      isBooked = (PS.posSerialId ==  0 || PS.posSerialId == null) ? false : true,

                                      posDeviceCode = PS.posDeviceCode,
                                  }).ToList();

               
            }
        


            return serialsendList;
        }
        public SendDetail getinfo()
        {
            SendDetail sd = new SendDetail();
            packagesSend packs = new packagesSend();
            List<PosSerialSend> serialsendList = new List<PosSerialSend>();

            using (incposdbEntities entity = new incposdbEntities())
            {
                //serialsendList = (from S in entity.posSerials
                //                      //  join p in entity.posSetting on S.id equals p.posSerialId
                //                  select new PosSerialSend
                //                  {
                //                      serial = S.posSerial,
                //                      isActive = (S.isActive == true) ? 1 : 0,
                //                      // isBooked=true,

                //                      isBooked = S.posSetting.Where(x => x.posSerialId == S.id).ToList().Count > 0 ? true : false,

                //                      posDeviceCode = S.posSetting.Where(x => x.posSerialId == S.id).FirstOrDefault().posDeviceCode,
                //                  }).ToList();
                serialsendList = getserialsinfo();
                packs = (from p in entity.ProgramDetails
                             //  join p in entity.posSetting on S.id equals p.posSerialId
                         select new packagesSend
                         {
                             programName = p.programName,
                             branchCount = p.branchCount,
                             posCount = p.posCount,
                             userCount = p.userCount,
                             vendorCount = p.vendorCount,
                             customerCount = p.customerCount,
                             itemCount = p.itemCount,
                             salesInvCount = p.saleinvCount,
                             storeCount = p.storeCount,
                             packageSaleCode = p.packageSaleCode,
                             customerServerCode = p.customerServerCode,
                             expireDate = p.expireDate,
                             isOnlineServer = p.isOnlineServer,
                             // isOnlineServer = false,
                             //  updateDate = p.updateDate,
                             islimitDate = (p.isLimitDate == true) ? true : false,
                             //islimitDate = false,
                             //  isLimitCount = (bool)p.isLimitCount,
                             isActive = (p.isActive == true) ? 1 : 0,
                             //   isActive =1,
                             canRenew = false,
                             isPayed = true,
                             isServerActivated = true,
                         }).FirstOrDefault();
            }
            sd.packageSend = packs;

            sd.PosSerialSendList = serialsendList;


            return sd;
        }

        public async Task<string> SendCustDetail(SendDetail sdd)
        {
            string message = "";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            //var myContent = JsonConvert.SerializeObject(sd);
            //parameters.Add("pks", myContent);
            //var myContent2 = JsonConvert.SerializeObject(sr);
            //parameters.Add("psr", myContent2);
            var myContent3 = JsonConvert.SerializeObject(sdd);
            parameters.Add("object", myContent3);

            //#################
            IEnumerable<Claim> claims = await APIResult.getList("packageUser/SendCustDetail", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    //    user = JsonConvert.DeserializeObject<User>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    message = c.Value;

                    break;
                }
            }
            return message;
        }
       
        private int SaveProgDetails(packagesSend newObject)
        {
            int message = 0;
            if (newObject != null)
            {

                ProgramDetails tmpObject;


                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        var locationEntity = entity.Set<ProgramDetails>();

                        // List<ProgramDetails> Objectlist = entity.ProgramDetails.ToList();
                        tmpObject = entity.ProgramDetails.FirstOrDefault();

                        if (tmpObject != null)
                        {

                            tmpObject.updateDate = DateTime.Now;
                            tmpObject.programName = newObject.programName;
                            tmpObject.branchCount = newObject.branchCount;
                            tmpObject.posCount = newObject.posCount;
                            tmpObject.userCount = newObject.userCount;
                            tmpObject.vendorCount = newObject.vendorCount;
                            tmpObject.customerCount = newObject.customerCount;
                            tmpObject.itemCount = newObject.itemCount;
                            if (newObject.salesInvCount == -1)
                            {
                                //new is unlimited
                                tmpObject.saleinvCount = newObject.salesInvCount;
                            }
                            else
                            {
                                //new is limited
                                if (tmpObject.saleinvCount==-1)
                                {
                                    //old is unlimited
                                    tmpObject.saleinvCount = newObject.totalsalesInvCount;
                                }
                                else
                                {
                                    //old is limited
                                    tmpObject.saleinvCount += newObject.totalsalesInvCount;
                                }
                               
                            }
                          
                            tmpObject.versionName = newObject.verName;
                            tmpObject.storeCount = newObject.storeCount;

                            tmpObject.packageSaleCode = newObject.packageSaleCode;
                           if( newObject.isServerActivated== false )
                            {
                                tmpObject.customerServerCode = newObject.customerServerCode;// from function

                            }

                            tmpObject.expireDate = newObject.expireDate;
                            tmpObject.isOnlineServer = newObject.isOnlineServer;
                            tmpObject.isLimitDate = newObject.islimitDate;
                            tmpObject.isActive = ( newObject.isActive==1)?true:false;

                            // tmpObject.packageNumber = newObject.packageCode;

                        }
                        else
                        {
                            message = -1;
                        }

                        //  tmpObject.posSerial = newObject.posSerial;      public Nullable<int> docPapersizeId { get; set; }

                        message = entity.SaveChanges();



                        //  entity.SaveChanges();
                        //   return (message);
                    }
                    return (message);

                }
                catch
                {
                    message = -1;
                    return (message);
                    //  return (ex.ToString());
                }

            }
            else
            {
                return (-1);
            }

        }



        //private int SaveposSerials(List<PosSerialSend> newObjectlist)
        //{
        //    int message = 0;
        //    if (newObjectlist != null)
        //    {
        //        List<posSerials> poslist = new List<posSerials>();
        //        List<string> newserial = new List<string>();
        //        List<string> oldserial = new List<string>();
        //        foreach (PosSerialSend sendrow in newObjectlist)
        //        {

        //            newserial.Add(sendrow.serial);

        //            // poslist.Except
        //        }




        //        try
        //        {
        //            using (incposdbEntities entity = new incposdbEntities())
        //            {
        //                //  var locationEntity = entity.Set<posSerials>();
        //                List<posSerials> alllist = entity.posSerials.ToList();

        //                oldserial = alllist.Select(s => s.posSerial).ToList();
        //                List<string> finallist = new List<string>();
        //                // for no duplicate 
        //                finallist = newserial.Except(oldserial).ToList();
        //                foreach (string sendrow in finallist)
        //                {
        //                    posSerials positem = new posSerials();
        //                    positem.posSerial = sendrow;

        //                    poslist.Add(positem);

        //                }


        //                entity.posSerials.AddRange(poslist);


        //                message = entity.SaveChanges();



        //            }
        //            return (message);

        //        }
        //        catch
        //        {
        //            message = -1;
        //            return (message);
        //        }

        //    }
        //    else
        //    {
        //        return (-1);
        //    }

        //}

        private int SaveposSerials(List<PosSerialSend> newObjectlist)
        {
            int message = 0;
            if (newObjectlist != null)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        //  var locationEntity = entity.Set<posSerials>();
                        List<posSerials> alllist = entity.posSerials.ToList();
                        //1-dis activate serials
                        foreach (posSerials oldrow in alllist)
                        {
                            oldrow.isActive = false;
                           
                            message+= entity.SaveChanges();
                        }

                        foreach (PosSerialSend snewrow in newObjectlist)
                        {
                            bool exist = false;
                            foreach (posSerials oldrow in alllist)
                            {
                                if (oldrow.posSerial == snewrow.serial)
                                {
                                    exist = true;
                                    oldrow.isActive = true;
                                }
                            }
                            if (exist == false)
                            {
                                posSerials newsr = new posSerials();
                                newsr.isActive = true;
                                newsr.posSerial = snewrow.serial;
                                entity.posSerials.Add(newsr);

                            }
                            message+= entity.SaveChanges();
                        }

                     //   message += entity.SaveChanges();
                    }
                    return (message);

                }
                catch
                {
                    message = -1;
                    return (message);
                }

            }
            else
            {
                return (-1);
            }

        }

        private int SaveunlimitedSerials(List<PosSerialSend> newObjectlist)
        {
            int message = 0;
            if (newObjectlist != null)
            {
                try
                {
                    using (incposdbEntities entity = new incposdbEntities())
                    {
                        //  var locationEntity = entity.Set<posSerials>();
                        List<posSerials> alllist = entity.posSerials.ToList();
                        //1-dis activate serials
                        foreach (posSerials oldrow in alllist)
                        {
                            oldrow.isActive = false;

                            message += entity.SaveChanges();
                        }

                        // get unlimited serial{
                        PosSerialSend unlimitedser = new PosSerialSend();
                        unlimitedser = newObjectlist.Where(x => x.unLimited == true).First();
                        //get booked pos and serialId
                        if (unlimitedser.serial != null || unlimitedser.serial != "")
                        {
                            int unlimitedserialId = 0;
                          List<PosSerialSend>linkdpos=  getserialsinfo();
                            linkdpos = linkdpos.Where(x => x.isBooked == true).ToList();
                            //add unlimited serial
                            foreach (PosSerialSend snewrow in newObjectlist)
                            {

                                bool exist = false;
                                foreach (posSerials oldrow in alllist)
                                {
                                    if (oldrow.posSerial == snewrow.serial && snewrow.unLimited == true)
                                    {
                                        exist = true;
                                        oldrow.isActive = true;
                                        oldrow.notes = "1";
                                        unlimitedserialId = oldrow.id;

                                    }
                                }
                                if (exist == false)
                                {
                                    posSerials newsr = new posSerials();
                                    newsr.isActive = true;
                                    newsr.posSerial = snewrow.serial;
                                    newsr.notes = "1";
                                    entity.posSerials.Add(newsr);
                                    unlimitedserialId = newsr.id;

                                }
                                message += entity.SaveChanges();
                            }
                            //
                            // change serialId
                            foreach (PosSerialSend newrow in linkdpos)
                            {
                                int? posId= newrow.posId==null?0: newrow.posId;
                                var posdb = entity.posSetting.Where(x => x.posId == posId).FirstOrDefault();
                                posdb.posSerialId = unlimitedserialId;
                                entity.SaveChanges();

                            }
                            //


                        }
                        
                  

                        //   message += entity.SaveChanges();
                    }
                    return (message);

                }
                catch
                {
                    message = -1;
                    return (message);
                }

            }
            else
            {
                return (-1);
            }

        }
        //[HttpPost]
        //[Route("saveserials")]
        //public async Task<string> saveserials(string token)
        //{
        //    token = TokenManager.readToken(HttpContext.Current.Request);
        //    var strP = TokenManager.GetPrincipal(token);
        //    if (strP != "0") //invalid authorization
        //    {
        //        return TokenManager.GenerateToken(strP);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            SendDetail sd = new SendDetail();
        //            sd = getinfo();
        //            PosSerialSend ss = new PosSerialSend();
        //            ss.serial = "dNquBuW1qzgxbvA2";
        //            ss.isActive = 1;
        //            List<PosSerialSend> lsr = new List<PosSerialSend>();
        //            lsr = sd.PosSerialSendList.Skip(5).Take(10).ToList();
        //            lsr.Add(ss);
        //            // int res = sd.packageSend.salesInvCount;
        //            // string res = sd.PosSerialSendList.FirstOrDefault().serial;
        //            int res = SaveposSerials(lsr);
        //            // int res=  await   checkIncServerConn();
        //            return TokenManager.GenerateToken(res.ToString());
        //        }
        //        catch (Exception ex)
        //        {
        //            return TokenManager.GenerateToken(ex.ToString());
        //        }


        //    }
        //}

        // GET api/<controller>



        [HttpPost]
        [Route("checkconn")]
        public string checkconn(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request); var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                {
                    int id = 0;
                    IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                    foreach (Claim c in claims)
                    {
                        if (c.Type == "id")
                        {
                            id = int.Parse(c.Value);
                        }
                    }
                    if (id == 1)
                    {
                        return TokenManager.GenerateToken(2.ToString());
                    }
                    else
                    {
                        return TokenManager.GenerateToken(0.ToString());
                    }

                }
            }
        }



        [HttpPost]
        [Route("Sendserverkey")]
        public async Task<string> Sendserverkey(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                string res1 = "";
                string skey = "";
                string serverId = "";
                SendDetail sendDetailItem = new SendDetail();
                int res = 0;
                int tempres = 0;
                IEnumerable<Claim> claims = TokenManager.getTokenClaims(token);
                foreach (Claim c in claims)
                {
                    if (c.Type == "skey")
                    {
                        skey = c.Value;
                    }
                }
                try
                {
                    //  return TokenManager.GenerateToken("1212".ToString());
                    serverId = ServerID();
                    // serverId = "server13213ascas";


                    int conres = await checkIncServerConn();

                    // check con to increase server
                    if (conres > 0)
                    {
                        // return TokenManager.GenerateToken(conres.ToString());
                        sendDetailItem = await GetSerialsAndDetails(skey, serverId);
                        //update server detail
                      
                        if (sendDetailItem.packageSend.result <= 0)
                        {
                           
                            /*
                             *   // -2 : package not active 
                              
                                 // -3 :serverID not match 
                                 // -4 :not payed 
                                 // -5 :serial not found
                                 //"0" :  catch error


                             * */
                            res = sendDetailItem.packageSend.result;
                        }
                        else
                        {
                            sendDetailItem.packageSend.customerServerCode = serverId;
                            sendDetailItem.packageSend.packageSaleCode = skey;
                            tempres = SaveProgDetails(sendDetailItem.packageSend);
                            //    return TokenManager.GenerateToken(res1);
                            //update serials 
                            if (tempres >= 0)
                            {
                                res += 1;
                                tempres = 0;
                                if (sendDetailItem.packageSend.posCount==-1)
                                {
                                    //unlimited pos
                            
                                    tempres = SaveunlimitedSerials(sendDetailItem.PosSerialSendList);
                                }
                                else
                                {
                                    tempres = SaveposSerials(sendDetailItem.PosSerialSendList);
                                }
                               
                            }
                            if (tempres >= 0)
                            {
                                res += 1;
                            }
                            else
                            {
                                // activation error
                                res = 0;
                            }

                            
                            //here send data to inc server
                            SendDetail sd = new SendDetail();
                            sd = getinfo();

                            string sendres = await SendCustDetail(sd);

                        }
                    }
                    else
                    {
                        // connection error
                        res = -1;
                    }


                

                    return TokenManager.GenerateToken(res);
                }
                catch (Exception ex)
                {
                    // connection error
                    // return TokenManager.GenerateToken(-1);
                    return TokenManager.GenerateToken(ex.ToString());
                }
            }

        }

        public async Task<int> checkIncServerConn()
        {
            int id = 1;
            int item = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("packageUser/checkconn", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = int.Parse(c.Value);
                    break;
                }
            }
            return item;



        }

        int count = 0;
        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                int message = 0;

                ProgramDetails tmpObject = new ProgramDetails();
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var locationEntity = entity.Set<ProgramDetails>();


                    tmpObject = entity.ProgramDetails.FirstOrDefault();

                    if (tmpObject != null)
                    {
                        tmpObject.updateDate = DateTime.Now;
                        count++;
                        tmpObject.itemCount = count;
                    }
                    else
                    {
                        message = -1;
                    }

                    message = entity.SaveChanges();

                }
            }
            catch
            {

            }
        }

        public int periodTimer()
        {

            try
            {
                System.Timers.Timer t = new System.Timers.Timer(10000);

                t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);

                t.Start();

                return 1;

                /*
                 *Global.asax.cs  add next code in  protected void Application_Start()
           //  ActivateController us = new ActivateController();
          //  int s = 0;
          //s=  us.periodTimer();
                 * */
            }

            catch
            {
                return 0;
            }
        }

        [HttpPost]
        [Route("CheckPeriod")]
        public string CheckPeriod(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                int res = CheckPeriod();
                return TokenManager.GenerateToken(res.ToString());

            }
        }


        public int CheckPeriod()
        {
            ProgramDetails tmpObject;
            // 1 :  time not end-
            //  0 : time is end 

            try
            {
                using (incposdbEntities entity = new incposdbEntities())
                {
                    var locationEntity = entity.Set<ProgramDetails>();
                    tmpObject = entity.ProgramDetails.FirstOrDefault();
                    if (tmpObject != null)
                    {
                        if (tmpObject.isLimitDate == false)
                        {
                            return 1;
                        }
                        else
                        {// limited
                            if (tmpObject.expireDate <= DateTime.Now || tmpObject.expireDate == null)
                            {
                                return 0;
                            }
                            else
                            {
                                return 1;
                            }
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }

            }
            catch
            {

                return -1;

            }

        }

        [HttpPost]
        [Route("senddata")]
        public async Task<string> senddata(string token)
        {
            token = TokenManager.readToken(HttpContext.Current.Request);
            var strP = TokenManager.GetPrincipal(token);
            if (strP != "0") //invalid authorization
            {
                return TokenManager.GenerateToken(strP);
            }
            else
            {
                try
                {
                    SendDetail sd = new SendDetail();
                    sd = getinfo();
                    // int res = sd.packageSend.salesInvCount;
                    // string res = sd.PosSerialSendList.FirstOrDefault().serial;
                    string res = await SendCustDetail(sd);
                    // int res=  await   checkIncServerConn();
                    return TokenManager.GenerateToken(res);
                }
                catch (Exception ex)
                {
                    return TokenManager.GenerateToken(ex.ToString());
                }


            }
        }


        //[HttpPost]
        //[Route("sendserials")]
        //public async Task<string> sendserials(string token)
        //{
        //    token = TokenManager.readToken(HttpContext.Current.Request);
        //    var strP = TokenManager.GetPrincipal(token);
        //    if (strP != "0") //invalid authorization
        //    {
        //        return TokenManager.GenerateToken(strP);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            List<PosSerialSend> sd = new List<PosSerialSend>();
        //            sd = getserialsinfo();
        //            // int res = sd.packageSend.salesInvCount;
        //            // string res = sd.PosSerialSendList.FirstOrDefault().serial;
        //          //  string res = await SendCustDetail(sd);
        //            // int res=  await   checkIncServerConn();
        //            return TokenManager.GenerateToken(sd);
        //        }
        //        catch (Exception ex)
        //        {
        //            return TokenManager.GenerateToken(ex.ToString());
        //        }


        //    }
        //}


    }
}
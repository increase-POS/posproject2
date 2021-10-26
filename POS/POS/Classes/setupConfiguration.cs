﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
   public  class setupConfiguration
    {
        public static bool validateUrl(string url)
        {
            url += "/api/pos/checkUri";
           bool valid = ( Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttp);
            if (valid)
            {
                try
                {
                    //Creating the HttpWebRequest
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    //Setting the Request method HEAD, you can also use GET too.
                    request.Method = "GET";
                    //Getting the Web Response.
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    //Returns TRUE if the Status code == 200
                    response.Close();
                    return (response.StatusCode == HttpStatusCode.OK);
                }
                catch
                {
                    return false;
                }
            }
            return valid;
        }
        public async static Task<int> setConfiguration(string activationCode, string deviceCode,int countryId,
                                                       string userName, string password, string branchName, string branchMobile,
                                                       string posName, List<SetValues> company)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string method = "pos/setConfiguration";
            var myContent = JsonConvert.SerializeObject(company);
           parameters.Add("setValues", myContent);
            parameters.Add("activationCode", activationCode);
            parameters.Add("deviceCode", deviceCode);
            parameters.Add("countryId", countryId.ToString());
            parameters.Add("userName", userName);
            parameters.Add("password", password);
            parameters.Add("branchName", branchName);
            parameters.Add("branchMobile", branchMobile);
            parameters.Add("posName", posName);
            return await APIResult.post(method, parameters);
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
    }
}
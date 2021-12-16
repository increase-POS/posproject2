using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Server.Models
{
    public class ActivateModelModel
    {

    }
    public class PosSerialSend
    {

        public string serial { get; set; }
        public string posDeviceCode { get; set; }

        public bool isBooked { get; set; }
        public int isActive { get; set; }
    }


    public class packagesSend
    {

        public string packageName { get; set; }

        public int branchCount { get; set; }
        public int posCount { get; set; }
        public int userCount { get; set; }
        public int vendorCount { get; set; }
        public int customerCount { get; set; }
        public int itemCount { get; set; }
        public int salesInvCount { get; set; }

        public string programName { get; set; }

        public string verName { get; set; }

        public int isActive { get; set; }
        public string packageSaleCode { get; set; }
        public string packageCode { get; set; }
        public int storeCount { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public bool islimitDate { get; set; }
        public Nullable<bool> isOnlineServer { get; set; }
        public string customerServerCode { get; set; }
        public int monthCount { get; set; }
        public bool canRenew { get; set; }
        public bool isBooked { get; set; }



    }
    public class SendDetail
    {
        public List<PosSerialSend> PosSerialSendList;

        public packagesSend packageSend;
    }
}
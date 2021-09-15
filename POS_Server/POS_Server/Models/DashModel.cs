using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Server.Models
{
    public class DashModel 
    {

        

    }
    public class UserOnlineCount
    {

        public int branchId { get; set; }
        public string branchName { get; set; }
        public int userOnlineCount { get; set; }
       
        public int allPos { get; set; }
        public int offlineUsers { get; set; }

    }
    public class BranchOnlineCount
    {

        public int branchOnline { get; set; }
        public int branchAll { get; set; }
        public int branchOffline { get; set; }
       

    }
}
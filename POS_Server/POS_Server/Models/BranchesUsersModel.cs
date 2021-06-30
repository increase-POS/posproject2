using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Server.Models
{
    public class BranchesUsersModel
    {
       
            public int branchsUsersId { get; set; }
            public Nullable<int> branchId { get; set; }
            public Nullable<int> userId { get; set; }
            public Nullable<System.DateTime> createDate { get; set; }
            public Nullable<System.DateTime> updateDate { get; set; }
            public Nullable<int> createUserId { get; set; }
            public Nullable<int> updateUserId { get; set; }

        }
    }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Server.Models
{
    public class ErrorModel
    {
        public int errorId { get; set; }
        public string num { get; set; }
        public string msg { get; set; }
        public string windowName { get; set; }
        public string sender { get; set; }
        public Nullable<int> posId { get; set; }
        public Nullable<int> branchId { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> createUserId { get; set; }

    }
}
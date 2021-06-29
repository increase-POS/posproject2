using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Server.Models
{
    public class GroupObjectModel
    {
        public int id { get; set; }
        public Nullable<int> groupId { get; set; }
        public Nullable<int> objectId { get; set; }
        public string notes { get; set; }
        public bool addOb { get; set; }
        public bool updateOb { get; set; }
        public bool deleteOb { get; set; }
        public bool showOb { get; set; }
        public string objectName { get; set; }
        public string desc { get; set; }
        public Nullable<bool> reportOb { get; set; }
        public Nullable<byte> levelOb { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<byte> isActive { get; set; }
        public Boolean canDelete { get; set; }
    }
}
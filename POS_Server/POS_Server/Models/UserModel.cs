using System;

namespace POS_Server.Models
{
    public class UserModel
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string fullName { get; set; }
        public string job { get; set; }
        public string workHours { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? updateDate { get; set; }
        public int? createUserId { get; set; }
        public int? updateUserId { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string notes { get; set; }
        public string address { get; set; }
        public short? isActive { get; set; }
        public byte? isOnline { get; set; }
        public Boolean canDelete { get; set; }
        public string image { get; set; }
        public Nullable<decimal> balance { get; set; }
        public Nullable<byte> balanceType { get; set; }
    }
}
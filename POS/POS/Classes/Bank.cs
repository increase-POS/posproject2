using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    class Bank
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string accNumber { get; set; }

        public DateTime createDate = DateTime.Now;
        public DateTime updateDate = DateTime.Now;
        public int createUserId { get; set; }
        public int updateUserId { get; set; }

        internal Task GetAgentsAsync(string v)
        {
            throw new NotImplementedException();
        }
    }
}

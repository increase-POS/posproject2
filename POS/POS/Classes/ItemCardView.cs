using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class ItemCardView
    {
        public Item item { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public string language { get; set; }
        public string cardType { get; set; }
    }
}

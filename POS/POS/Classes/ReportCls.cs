using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    class ReportCls
    {

        public string PathUp(string path, int levelnum, string addtopath)
        {
            int pos1 = 0;
            for (int i = 1; i <= levelnum; i++)
            {
                pos1 = path.LastIndexOf("\\");
                path = path.Substring(0, pos1);
            }

            string newPath = path + addtopath;
            return newPath;
        }

        public string TimeToString(TimeSpan?  time)
        {

            TimeSpan ts = TimeSpan.Parse(time.ToString());
            // @"hh\:mm\:ss"
            string stime = ts.ToString(@"hh\:mm");
            return stime;
        }
        public string DateToString(DateTime? date)
        {
           
            DateTime ts = DateTime.Parse(date.ToString());
            // @"hh\:mm\:ss"
            string sdate = ts.ToString(@"d/M/yyyy");
            return sdate;
        }

        public string DecTostring(decimal? dec)
        {
            string sdc = "0";
            if (dec == null)
            {

            }
            else
            {
  decimal dc = decimal.Parse(dec.ToString());


           sdc = dc.ToString("0.00");
            }
         

            return sdc;
        }
    }
}


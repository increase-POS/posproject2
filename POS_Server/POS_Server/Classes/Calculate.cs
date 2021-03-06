using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Server.Classes
{
    public class Calculate
    {
        public decimal percentValue(decimal? value, decimal? percent)
        {
            if (value == null)
            {
                value = 0;
            }
            if (percent == null)
            {
                percent = 0;
            }
            decimal? perval=  (value * percent / 100);
            return (decimal) perval;
        }
        public DateTime? changeDateformat(DateTime? date, string format)
        {//@"d/M/yyyy"
            string sdate = "";
            if (date != null)
            {
                DateTime ts = DateTime.Parse(date.ToString());
                // @"hh\:mm\:ss"
                sdate = ts.ToString(format);
            }

            return DateTime.Parse(sdate);
        }

       public int getdays(DateTime date)
        {
            int year;
            int month;
            int days;

            year = date.Year;
            month = date.Month;

            days = getdays(year, month);



          //  int days = DateTime.DaysInMonth(year, month);

            return days;
        }
       public int getdays(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);

            return days;
        }

    }
}
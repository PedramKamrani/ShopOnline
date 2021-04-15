using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace CorService.ExtinsionMethod
{
   public static class DateTimeEx
    {
       public enum monthpersion{ فرودین = 1, اردیبهشت, خرداد, تیر, مرداد, شهریور, مهر, آبان, آذر, دی, بهمن, اسفند };
        public static string GetMonthPersian( this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            string month = ((monthpersion)pc.GetMonth(dt)).ToString();
            return pc.GetDayOfMonth(dt) + " " + month + " " + pc.GetYear(dt);
        }
    }
}

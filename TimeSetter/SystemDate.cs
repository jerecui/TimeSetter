using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TimeSetter
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemDate
    {
        public ushort _year;
        public ushort _month;
        public ushort _dayOfWeek;
        public ushort _day;
        public ushort _hour;
        public ushort _minute;
        public ushort _mecond;
        public ushort _milliseconds;

        public static SystemDate FromDateTime(DateTime dateTime)
        {
            var time = new SystemDate();

            time._year = (ushort)dateTime.Year;
            time._month = (ushort)dateTime.Month;
            time._dayOfWeek = (ushort)dateTime.DayOfWeek;
            time._day = (ushort)dateTime.Day;
            time._hour = (ushort)dateTime.Hour;
            time._minute = (ushort)dateTime.Minute;
            time._mecond = (ushort)dateTime.Second;
            time._milliseconds = (ushort)dateTime.Millisecond;

            return time;
        }

        public DateTime ToDateTime()
        {
            return new DateTime(_year, _month, _day, _hour, _minute, _mecond);
        }
    }
}

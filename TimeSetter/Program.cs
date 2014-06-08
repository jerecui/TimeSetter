using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace TimeSetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var datetime = GetNetworkDatetime();
            SetSystemTime(datetime);
        }

        public static DateTime GetNetworkDatetime()
        {
            var siteUrl = ConfigurationManager.AppSettings["Site"];
            if (string.IsNullOrEmpty(siteUrl))
            {
                siteUrl = "http://www.google.com";
            }

            var datetime = GetLocalTime();
            var wr = WebRequest.Create(siteUrl);
            var response = wr.GetResponse() as HttpWebResponse;

            if (response != null)
            {
                if (response.Headers.AllKeys.Contains("Date"))
                {
                    var timeString = response.Headers["Date"];

                    IFormatProvider culture = new System.Globalization.CultureInfo("en-US");
                    datetime = DateTime.Parse(timeString, culture).ToUniversalTime();
                }
            }
            response.Close();

            return datetime;
        }

        public static void SetSystemTime(DateTime dt)
        {
           var time = SystemDate.FromDateTime(dt);

           Win32.SetSystemTime(ref time);
        }

        public static DateTime GetLocalTime()
        {
            var time = new SystemDate();
            Win32.GetSystemTime(ref time);

            var dt = time.ToDateTime();

            return dt;
        }

    }
}

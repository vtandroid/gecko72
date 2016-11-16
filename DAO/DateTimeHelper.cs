using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Cache;
using System.IO;
using System.Text.RegularExpressions;
using TestGecko45.Common;
namespace TestGecko45.DAO
{
    class DateTimeHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear, wMonth, wDayOfWeek, wDay,
                   wHour, wMinute, wSecond, wMilliseconds;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);
        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool Win32SetSystemTime(ref SYSTEMTIME sysTime);
        [DllImport("kernel32.dll")]
        public extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);
        public static DateTime GetNistTime()
        {
            DateTime dateTime = DateTime.MinValue;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://nist.time.gov/actualtime.cgi?lzbc=siqm9b");
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore); //No caching
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader stream = new StreamReader(response.GetResponseStream());
                string html = stream.ReadToEnd();//<timestamp time=\"1395772696469995\" delay=\"1395772696469995\"/>
                string time = Regex.Match(html, @"(?<=\btime="")[^""]*").Value;
                double milliseconds = Convert.ToInt64(time) / 1000.0;
                dateTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds);
            }

            return dateTime;
        }
        public static bool ChangeSystemDateTime()
        {
            DateTime now = GetNistTime();
            //now=now.AddHours(Config.utcTimeZone);
            SYSTEMTIME sysT = new SYSTEMTIME();
            sysT.wYear = (short)now.Year;
            sysT.wMonth = (short)now.Month;
            sysT.wDay = (short)now.Day;
            sysT.wHour = (short)now.Hour;
            sysT.wMinute = (short)now.Minute;
            sysT.wSecond = (short)now.Second;
            sysT.wMilliseconds = (short)now.Millisecond;
            
            return SetSystemTime(ref sysT);
        }
    }
}

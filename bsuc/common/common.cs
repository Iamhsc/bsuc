using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsuc.common
{
    public class Common
    {
        /// <summary>
        /// 当前时间戳
        /// </summary>
        /// <returns></returns>
        public static int GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }

        /// <summary>
        /// 时间戳转换时间
        /// </summary>
        /// <param name="timestamp">当前时间戳</param>
        /// <param name="format">转换格式 默认MM-dd</param>
        /// <returns></returns>
        public static string IntToDateTime(int timestamp, string format = "MM-dd")
        {
            var datetime=TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timestamp);
            return datetime.ToString(format);
        }

        /// <summary>  
        /// 获取操作系统版本号  
        /// </summary>  
        /// <returns></returns>  
        public static string GetOSVersion()
        {
            //UserAgent   
            var userAgent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];

            var osVersion = "未知";
            if (userAgent.Contains("NT 10.0"))
            {
                osVersion = "Windows 10";
            }
            if (userAgent.Contains("NT 8.0"))
            {
                osVersion = "Windows 8";
            }
            if (userAgent.Contains("NT 6.1"))
            {
                osVersion = "Windows 7";
            }
            else if (userAgent.Contains("NT 6.0"))
            {
                osVersion = "Windows Vista/Server 2008";
            }
            else if (userAgent.Contains("NT 5.2"))
            {
                osVersion = "Windows Server 2003";
            }
            else if (userAgent.Contains("NT 5.1"))
            {
                osVersion = "Windows XP";
            }
            else if (userAgent.Contains("NT 5"))
            {
                osVersion = "Windows 2000";
            }
            else if (userAgent.Contains("NT 4"))
            {
                osVersion = "Windows NT4";
            }
            else if (userAgent.Contains("Me"))
            {
                osVersion = "Windows Me";
            }
            else if (userAgent.Contains("98"))
            {
                osVersion = "Windows 98";
            }
            else if (userAgent.Contains("95"))
            {
                osVersion = "Windows 95";
            }
            else if (userAgent.Contains("Mac"))
            {
                osVersion = "Mac";
            }
            else if (userAgent.Contains("Unix"))
            {
                osVersion = "UNIX";
            }
            else if (userAgent.Contains("Linux"))
            {
                osVersion = "Linux";
            }
            else if (userAgent.Contains("SunOS"))
            {
                osVersion = "SunOS";
            }
            return osVersion;
        }
    }
}
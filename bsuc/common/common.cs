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
    }
}
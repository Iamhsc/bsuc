using System;
using System.Security.Cryptography;
using System.Text;

namespace bsuc.common
{
    public class Sha1
    {
       
        /// <summary>
        /// 比较密码
        /// </summary>
        /// <param name="pwd">原本密码</param>
        /// <param name="salt">随机字符串</param>
        /// <param name="password">加密后的密码</param>
        /// <returns>boot</returns>
        public static bool comparePassword(string pwd, string salt, string password)
        {
            return SHA1(salt + pwd, Encoding.UTF8) == password;
        }

        /// <summary>
        /// sha1加密
        /// </summary>
        /// <param name="pwd">原密码</param>
        /// <param name="authCode">随机码</param>
        /// <returns></returns>
        public static string sha1_pwd(string pwd, string authCode)
        {
            return SHA1(authCode + pwd, Encoding.UTF8);
        }

        /// <summary>
        /// 随机字符串
        /// </summary>
        /// <param name="len">字符串位数</param>
        /// <returns></returns>
        public static string random_string(int len = 6)
        {
            string[] charArr ={
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k",
        "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v",
        "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G",
        "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R",
        "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2",
        "3", "4", "5", "6", "7", "8", "9"
                           };
            int a = charArr.Length;
            Random rand = new Random();
            string output = "";
            for (int i = 0; i < a; i++)
            {
                int p = rand.Next(a);
                string temp = charArr[p];
                charArr[p] = charArr[i];
                charArr[i] = temp;
            }

            for (int j = 0; j < len; j++)
            {
                output += charArr[rand.Next(a)];
            }
            return output;
        }

        /// <summary>
        /// SHA1 加密，返回大写字符串
        /// </summary>
        /// <param name="content">需要加密字符串</param>
        /// <param name="encode">指定加密编码</param>
        /// <returns>返回40位大写字符串</returns>
        public static string SHA1(string content, Encoding encode)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] bytes_in = encode.GetBytes(content);
                byte[] bytes_out = sha1.ComputeHash(bytes_in);
                sha1.Dispose();
                string result = BitConverter.ToString(bytes_out);
                result = result.Replace("-", "");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace TRECommon
{
    public class MyMD5
    {
        //返回任意字符串，长度32
        //本程序的数据库中Salt字段长度32
        private static string GetSalt()
        {
            Random rnd = new Random();
            Byte[] b = new Byte[32];
            rnd.NextBytes(b);
            return MD5ToHexString(b);
        }

        /// <summary>
        /// 计算密码
        /// </summary>
        /// <param name="strPassword">用户输入的密码,可能空</param>
        /// <param name="salt">salt值</param>
        /// <returns>返回MD5加密后的密码</returns>
        /// <remarks>
        /// 这里主要定义了从salt值以什么方式什么次序计算密码
        /// </remarks>
        public static string Encrypt(string strPassword, string salt)
        {
            if (strPassword == null) strPassword = "";
            if (salt == null) salt = "";

            return GetMD5(strPassword + salt);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static string Encrypt(string strPassword)
        {
            return Encrypt(strPassword, null);
        }
        /// <summary>
        /// MD5 加密，byte[]型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] MD5_Byte(byte[] data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            return md5.ComputeHash(data);
        }
        /// <summary>
        /// MD5 加密，byte[]型加密为string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string MD5ToHexString(byte[] data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string t = "";
            string tTemp = "";
            for (int i = 0; i < result.Length; i++)
            {
                tTemp = Convert.ToString(result[i], 16);
                if (tTemp.Length != 2)
                {
                    switch (tTemp.Length)
                    {
                        case 0: tTemp = "00"; break;
                        case 1: tTemp = "0" + tTemp; break;
                        default: tTemp = tTemp.Substring(0, 2); break;
                    }
                }
                t += tTemp;
            }
            return t;
        }
        /// <summary>
        /// 加密实现
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string GetMD5(string strText)
        {
            //byte[] result = Encoding.Default.GetBytes(strText);    //tbPass为输入密码的文本框
            //MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] output = md5.ComputeHash(result);
            //return BitConverter.ToString(output).Replace("-", "");

            //旧的代码
            byte[] data = System.Text.ASCIIEncoding.Unicode.GetBytes(strText);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string t = "";
            for (int i = 0; i < result.Length; i++)
            {
                t += Convert.ToString(result[i], 16);
            }
            return t;

  

 


        }
        /// <summary>
        /// 返回32位MD5
        /// 2015-01-30 shen
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD532(string str)
        {
            return MyMD5.GetMD5(str);
        }
    }
}

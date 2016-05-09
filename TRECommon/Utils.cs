//======================================================================
// 组织名: Troopsen
// 命名空间名称: Common
// 文件名: Utils
// 创建人: Troopsen
// 创建时间: 2011/3/29 9:25:10
//======================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.Web;

namespace TRECommon
{
    public class Utils
    {
        //正则表达式


        #region 工具 性别

        /// <summary>
        /// 性别 数字 0=女 1=男 2=保密 转换为字符
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="defValue">缺省值</param>
        /// <returns></returns>
        public static string GetSexStrValue(int value, string defValue)
        {
            if (value == 0)
                return "女";
            else if (value == 1)
                return "男";
            else if (value == 2)
                return "保密";

            return defValue;
        }

        /// <summary>
        /// 性别 数字 0=女 1=男 2=保密 转换为字符 默认保密
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static string GetSexStrValue(int value)
        {
            return GetSexStrValue(value, "保密");
        }



        #endregion

        #region 工具 是否

        public static string GetYesNoIntToStr(int value)
        {
            return value == 0 ? "否" : "是";
        }

        public static string GetYesNoBoolToStr(bool value)
        {
            return value == true ? "是" : "否";
        }

        public static int GetYesNoStrToInt(string value)
        {
            return value == "是" ? 1 : 0;
        }
        public static int GetYesNoBoolToInt(bool value)
        {
            return value == true ? 1 : 0;
        }

        public static bool GetYesNoStrToBool(string value)
        {
            return value == "是" ? true : false;
        }
        public static bool GetYesNoIntToBool(int value)
        {
            return value == 0 ? false : true;
        }


        #endregion

        #region 工具 文件

        /// <summary>
        /// 返回文件是否存在
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否存在</returns>
        public static bool FileExists(string filename)
        {
            return System.IO.File.Exists(filename);
        }

        #endregion

        #region 工具 路径

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }


        #endregion

        #region 工具 IP

        /// <summary>
        /// 返回指定IP是否在指定的IP数组所限定的范围内, IP数组内的IP地址可以使用*表示该IP段任意, 例如192.168.1.*
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="iparray"></param>
        /// <returns></returns>
        public static bool InIPArray(string ip, string[] iparray)
        {
            string[] userip = StringOperation.SplitString(ip, @".");

            for (int ipIndex = 0; ipIndex < iparray.Length; ipIndex++)
            {
                string[] tmpip = StringOperation.SplitString(iparray[ipIndex], @".");
                int r = 0;
                for (int i = 0; i < tmpip.Length; i++)
                {
                    if (tmpip[i] == "*")
                        return true;

                    if (userip.Length > i)
                    {
                        if (tmpip[i] == userip[i])
                            r++;
                        else
                            break;
                    }
                    else
                        break;
                }

                if (r == 4)
                    return true;
            }
            return false;
        }

        #endregion

        #region 工具 加密

        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            byte[] b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');

            return ret;
        }

        /// <summary>
        /// SHA256函数
        /// </summary>
        /// /// <param name="str">原始字符串</param>
        /// <returns>SHA256结果</returns>
        public static string SHA256(string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return Convert.ToBase64String(Result);  //返回长度为44字节的字符串
        }


        #endregion

        #region 随机数
        public static string Create2Rond()
        {

            Random rnd = new Random();
            return rnd.Next(9, 100).ToString();
        }

        #endregion

        #region 正则获取图片路径

        public static StringBuilder GetImgUrl(string text)
        {
            StringBuilder str = new StringBuilder();
            string pat = @"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>";

            Regex r = new Regex(pat, RegexOptions.Compiled);

            Match m = r.Match(text.ToLower());
            //int matchCount = 0;
            while (m.Success)
            {
                Group g = m.Groups[2];
                str.Append(g).Append(",");
                m = m.NextMatch();
            }
            return str.Replace("\"", "");
        }



        #endregion

        #region 处理存在数据库中for xml path的数据

        /// <summary>
        /// 返回匹配多个的集合值
        /// </summary>
        /// <param name="start">开始html tag</param>
        /// <param name="end">结束html tag</param>
        /// <param name="html">html</param>
        /// <returns></returns>
        //public static List<string> GetHtmls(string start, string end, string html)
        //{
        //    IList list = new List<string>();
        //    try
        //    {
        //        string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", start, end);//匹配URL的模式,并分组
        //        MatchCollection mc = Regex.Matches(html, pattern);//满足pattern的匹配集合
        //        if (mc.Count != 0)
        //        {
        //            foreach (Match match in mc)
        //            {
        //                GroupCollection gc = match.Groups;
        //                list.Add(gc["g"].Value);
        //            }
        //        }
        //    }
        //    catch { }
        //    return list;
        //}
        //public static string GetHtml(string start, string end, string html)
        //{
        //    string ret = string.Empty;
        //    try
        //    {
        //        string pattern = string.Format("{0}(?<g>(.|[\r\n])+?)?{1}", start, end);//匹配URL的模式,并分组
        //        ret = Regex.Match(html, pattern).Groups["g"].Value;

        //    }
        //    catch { }

        //    return ret;
        //}




        #endregion

        /// <summary>
        /// 支付金额类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static decimal GetPayMentTypes0(string t)
        {
            decimal str = 0;
            switch (t)
            {
                case "1":
                    str = 1500;
                    break;
                case "2":
                    str = 2500;
                    break;
                case "3":
                    str = 5000;
                    break;
                default:
                    str = 5000;
                    break;
            }
            return str;
        }

        /// <summary>
        /// 支付金额类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static decimal GetPayMentTypes1(string t)
        {
            decimal str = 0;
            switch (t)
            {
                case "1":
                    str = 10.01M;
                    break;
                case "2":
                    str = 10.01M;
                    break;
                case "3":
                    str = 5000;
                    break;
                default:
                    str = 5000;
                    break;
            }
            return str;
        }

        /// <summary>
        /// rafer string转换int类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetIntForString(string obj)
        {
            int ret = 0;
            if (string.IsNullOrEmpty(obj))
            {
                ret = 0;
            }
            try
            {
                ret = Convert.ToInt32(obj);
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}

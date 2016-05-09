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
    public class HTMLUtils
    {

        //回车 换行 正则
        private static Regex RegexBr = new Regex("@(\r\n)", RegexOptions.IgnoreCase);


        /// <summary>
        /// 生成指定数量的html空格符号
        /// </summary>
        public static string GetSpacesString(int spacesCount)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < spacesCount; i++)
            {
                sb.Append(" &nbsp;&nbsp;");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 替换回车换行符为html换行符
        /// </summary>
        public static string StrFormat(string str)
        {
            string str2;

            if (str == null)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("\r\n", "<br />");
                str = str.Replace("\n", "<br />");
                str2 = str;
            }
            return str2;
        }

        /// <summary>
        /// 转换为简体中文
        /// </summary>
        public static string ToSChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0);
        }

        /// <summary>
        /// 转换为繁体中文
        /// </summary>
        public static string ToTChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0);
        }

        /// <summary>
        /// 返回 HTML 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        /// <summary>
        /// 返回 HTML 字符串的解码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }


        /// <summary>
        /// 移除 字符中的 空格 回车 换行
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RTrim(string str)
        {
            for (int i = str.Length; i >= 0; i--)
            {
                if (str[i].Equals(" ") || str[i].Equals("\r") || str[i].Equals("\n"))
                {
                    str.Remove(i);
                }
            }
            return str;

        }

        /// <summary>
        /// 移除 回车 换行
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ClearBR(string str)
        {
            Match m = null;
            for (m = RegexBr.Match(str); m.Success; m = m.NextMatch())
            {
                str = str.Replace(m.Groups[0].ToString(), "");
            }
            return str;
        }

        /// <summary>
        /// 从HTML中获取文本,保留br,p,img
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        public static string GetTextFromHTML(string HTML)
        {
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(@"</?(?!br|/?p|img)[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            return regEx.Replace(HTML, "");
        }

        /// <summary>
        /// 将HTML去除
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        public static string GetAllTextFromHTML(string Htmlstring)//将HTML去除
        {
            if (string.IsNullOrEmpty(Htmlstring))
                return "";

             #region
             //删除脚本

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"<script[^>]*?>.*?</script>","",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             //删除HTML

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"<(.[^>]*)>","",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"([/r/n])[/s]+","",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"-->","",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"<!--.*","",System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            
             //Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"<A>.*</A>","");
        
             //Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"<[a-zA-Z]*=/.[a-zA-Z]*/?[a-zA-Z]+=/d&/w=%[a-zA-Z]*|[A-Z0-9]","");

                        

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"&(quot|#34);","/",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"&(amp|#38);","&",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"&(lt|#60);","<",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"&(gt|#62);",">",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"&(nbsp|#160);"," ",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"&(iexcl|#161);","/xa1",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring,@"&(cent|#162);","/xa2",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"&(pound|#163);","/xa3",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"&(copy|#169);","/xa9",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

             Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring, @"&#(/d+);","",System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            
             Htmlstring.Replace("<","");

             Htmlstring.Replace(">","");

             Htmlstring.Replace("/r/n","");

             //Htmlstring=HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
             #endregion
             return Htmlstring;

         }


    }
}

//======================================================================
// 组织名: Troopsen
// 命名空间名称: Utils
// 文件名: Validator
// 创建人: Troopsen
// 创建时间: 2011/3/11 8:21:25
//======================================================================
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;

namespace TRECommon
{
    public class Validator
    {

        #region 验证是否为空
        /// <summary>
        /// 验证字符串是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StrIsNullOrEmpty(string str)
        {
            if (str == null || str.Trim() == string.Empty)
                return true;
            else
                return false;
        }
        #endregion

        /**
        /// <summary>
        /// 是否为整数
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsInt(int source)
        {
            string strPatten="";
            Regex Reg = new Regex(strPatten);
            
        }

        /// <summary>
        /// 是否为小数
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsFloat(string source)
        {

        }

        /// <summary>
        /// 是否为英文字母
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEnglish(string source)
        {

        }


        /// <summary>
        /// 是否为中文字母
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsChinese(string source)
        {

        }




        /// <summary>
        /// 验证邮箱Email
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmail(string source)
        {

        }


        /// <summary>
        /// 是否为电话号码
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string source)
        {

        }

        /// <summary>
        /// 是否为手机号码
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool MobileNumber(string source)
        {

        }

        /// <summary>
        /// 是否为时间
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsDate(string source)
        {

        }

        /// <summary>
        /// 是否为生日
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsBirthday(string source)
        {

        }

        /// <summary>
        /// 是否为年龄
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsAge(int source)
        {

        }

        /// <summary>
        /// 是否为身份证号码
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsIDNumber(int source)
        {
        }

        /// <summary>
        /// 是否为网址
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsWebSite(string source)
        {

        }

        /// <summary>
        /// 是否IP
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsIp(string source)
        {

        }

        /// <summary>
        /// 是否为IP6
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsIp6(string source)
        {

        }


        /// <summary>
        /// 是否为邮编(中国)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsZipCode(int source)
        {

        }

        
        **/

        /// <summary>
        /// 检测是否是正确的Url
        /// </summary>
        /// <param name="strUrl">要验证的Url</param>
        /// <returns>判断结果</returns>
        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="strEmail">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^[\w\.]+([-]\w+)*@[A-Za-z0-9-_]+[\.][A-Za-z0-9-_]");
        }


        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }


        public static string GetEmailHostName(string strEmail)
        {
            if (strEmail.IndexOf("@") < 0)
            {
                return "";
            }
            return strEmail.Substring(strEmail.LastIndexOf("@")).ToLower();
        }

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 检测是否有Sql危险字符(邮箱可以登录)
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlStringMemberLogin(string str)
        {
            return !Regex.IsMatch(str, @"[;|,|\/|\(|\)|\[|\]|\}|\{|%|\*|!|\']");
        }

        /// <summary>
        /// 检测是否有危险的可能用于链接的字符串
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeUserInfoString(string str)
        {
            return !Regex.IsMatch(str, @"^\s*$|^c:\\con\\con$|[%,\*" + "\"" + @"\s\t\<\>\&]|游客|^Guest");
        }


        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static bool IsIPSect(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){2}((2[0-4]\d|25[0-5]|[01]?\d\d?|\*)\.)(2[0-4]\d|25[0-5]|[01]?\d\d?|\*)$");
        }

    }
}




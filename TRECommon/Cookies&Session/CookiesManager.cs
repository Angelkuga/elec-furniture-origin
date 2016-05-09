//======================================================================
// 组织名: Troopsen
// 命名空间名称: WebObject
// 文件名: SessionCookies
// 创建人: Troopsen
// 创建时间: 2011/3/29 13:48:16
//======================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;

namespace TRECommon
{

    public class CookiesHelper
    {
        public static string CookieDomain = ConfigurationManager.AppSettings["CookieUrl"];

        #region 读cookie值
        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            string returnStr = string.Empty;
            if (GetUserTicket() != null)
            {

                switch (strName)
                {
                    case "mid":
                        returnStr = GetUserTicket()[0];
                        break;
                    case "mname":
                        returnStr = GetUserTicket()[1];
                        break;
                    case "mpwd":
                        returnStr = GetUserTicket()[2];
                        break;


                }
            }
            if (strName == "aadmin" || strName == "apwd")
            {
                switch (strName)
                {
                    case "aadmin":
                        if (GetUserTicket("AdminInfo") != null)
                        {
                            returnStr = GetUserTicket("AdminInfo")[0];
                        }
                        break;
                    case "apwd":
                        if (GetUserTicket("AdminInfo") != null)
                        {
                            returnStr = GetUserTicket("AdminInfo")[1];
                        }
                        break;
                }
            }

            return returnStr;

        }
        #endregion

        #region 解密读取cookie中的信息
        /// <summary>
        /// 解密读取cookie中的信息
        /// </summary>
        /// <returns></returns>
        public static string[] GetUserTicket(string strKey)
        {
            if (GetCookiesState(strKey))
            {
                string strUserTicketData = GetCookiesValue(strKey);
                System.Web.Security.FormsAuthenticationTicket Ticket = System.Web.Security.FormsAuthentication.Decrypt(strUserTicketData);
                return Ticket.UserData.Split('|');
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 获取Cookies的值对象
        /// <summary>
        /// 解密读取cookie中的信息
        /// </summary>
        /// <returns></returns>
        public static string[] GetUserTicket()
        {
            if (GetCookiesState("UserInfo"))
            {
                string strUserTicketData = GetCookiesValue("UserInfo");
                System.Web.Security.FormsAuthenticationTicket Ticket = System.Web.Security.FormsAuthentication.Decrypt(strUserTicketData);
                return Ticket.UserData.Split('|');
            }
            else
            {
                return null;
            }
        }
        #region 获取Cookies的值对象
        /// <summary>
        /// 获取Cookies的值
        /// </summary>
        /// <param name="Str">参数,cookie名</param>
        /// <returns>Cookies值</returns>
        public static string GetCookiesValue(string Str)
        {
            return HttpContext.Current.Request.Cookies[Str].Value;
        }
        #endregion 获取Cookies的值

        #region 获取Cookies状态是否存在
        /// <summary>
        /// 获取Cookies状态是否存在
        /// </summary>
        /// <param name="Str">参数,cookie名</param>
        /// <returns>bool值</returns>
        public static bool GetCookiesState(string Str)
        {
            if (HttpContext.Current.Request.Cookies[Str] != null)
            {
                if (HttpContext.Current.Request.Cookies[Str].Value != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion 获取Cookies状态

        #endregion
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312"))];
            if (cookie == null)
            {
                cookie = new HttpCookie(System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312")));
            }
            cookie.Value = System.Web.HttpUtility.UrlEncode(strValue, Encoding.GetEncoding("GB2312"));
            cookie.Domain = CookieDomain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312"))];
            if (cookie == null)
            {
                cookie = new HttpCookie(System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312")));
            }
            cookie[key] = System.Web.HttpUtility.UrlEncode(strValue, Encoding.GetEncoding("GB2312"));
            cookie.Domain = CookieDomain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312"))];
            if (cookie == null)
            {
                cookie = new HttpCookie(System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312")));
            }
            cookie.Value = System.Web.HttpUtility.UrlEncode(strValue, Encoding.GetEncoding("GB2312"));
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            cookie.Domain = CookieDomain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        ///// <summary>
        ///// 读cookie值
        ///// </summary>
        ///// <param name="strName">名称</param>
        ///// <returns>cookie值</returns>
        //public static string GetCookie(string strName)
        //{
        //    if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312"))] != null)
        //        return System.Web.HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312"))].Value.ToString(), Encoding.GetEncoding("GB2312"));

        //    return "";
        //}

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312"))][key] != null)
                return System.Web.HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312"))][key].ToString(), Encoding.GetEncoding("GB2312"));

            return "";
        }

        /// <summary>
        /// 设置Cookie 过期
        /// </summary>
        /// <param name="strName"></param>
        public static void DelCookie(string strName)
        {
            if (GetCookie(strName) != "")
            {
                HttpContext.Current.Request.Cookies[System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312"))].Expires.AddDays(-1);
            }
        }

        /// <summary>
        /// 设置Cookie 过期
        /// </summary>
        /// <param name="strName"></param>
        public static void DelCookie(string strName, string key)
        {
            if (GetCookie(System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312"))) != "")
            {
                HttpContext.Current.Request.Cookies[System.Web.HttpUtility.UrlEncode(strName, Encoding.GetEncoding("GB2312"))].Expires.AddDays(-1);
            }
        }

        /// <summary>
        /// 跨域写入List Cookie
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static void AddUserCookies(string key, string value, string cookiename, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookiename);
                cookie.Domain = domain;
                cookie.Path = "/";

                cookie.Values.Add(key, value);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
            else
            {
                if (HttpContext.Current.Request.Cookies[cookiename].Values[key] != null)
                {
                    cookie.Values.Set(key, value);
                }
                else
                {
                    cookie.Domain = domain;
                    cookie.Path = "/";
                    cookie.Values.Add(key, value);
                    HttpContext.Current.Response.AppendCookie(cookie);
                }
            }
        }
        #region 移除Cookies的值
        /// <summary>
        /// 移除Cookies的值
        /// </summary>
        /// <param name="Str">Cookies名称</param>
        public static void RemoveCookies(string Str)
        {
            if (HttpContext.Current.Request.Cookies[Str] != null)
            {
                HttpContext.Current.Response.Cookies[Str].Expires = DateTime.Now.AddDays(-1);
            }
        }
        #endregion
        /// <summary>
        /// 新增一个Cookie
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cookiename"></param>
        /// <param name="domain"></param>
        public static void AddCookie(string value, string cookiename, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[System.Web.HttpUtility.UrlEncode(cookiename, Encoding.GetEncoding("GB2312"))];
            if (cookie == null)
            {
                cookie = new HttpCookie(System.Web.HttpUtility.UrlEncode(cookiename, Encoding.GetEncoding("GB2312")));
            }
            cookie.Value = System.Web.HttpUtility.UrlEncode(value, Encoding.GetEncoding("GB2312"));
            cookie.Expires = DateTime.Now.AddMinutes(30);
            cookie.Domain = "/";
            HttpContext.Current.Response.AppendCookie(cookie);

        }


        #region wengjie 消费用户cookies
        /// <summary>
        /// 获取消费用户cookies
        /// </summary>
        /// <param name="strName">cid,cname,cpwd</param>
        /// <returns></returns>
        public static string GetCookieCustomer(string strName)
        {
            string returnStr = string.Empty;
            string cookiesKey = "CustomerInfo";
            if (GetUserTicket(cookiesKey) != null)
            {
                switch (strName)
                {
                    case "cid":
                        returnStr = GetUserTicket(cookiesKey)[0];
                        break;
                    case "cname":
                        returnStr = GetUserTicket(cookiesKey)[1];
                        break;
                    case "cpwd":
                        returnStr = GetUserTicket(cookiesKey)[2];
                        break;


                }
            }
            return returnStr;
        }
        #endregion
    }
}

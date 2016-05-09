using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using TRECommon;

namespace TREC.ECommerce
{
    public class UiCommon
    {

        //根据参数或页面名称设置样式
        public static string QueryStringCur(string query, string qvalue, string css, string curcss,char spl)
        {
            spl = spl.ToString()=="" ? ',' : spl;
            string pageName = HttpContext.Current.Request.CurrentExecutionFilePath.Substring(HttpContext.Current.Request.CurrentExecutionFilePath.LastIndexOf("/") + 1);
            if (WebRequest.GetQueryString(query) == "" || query == "pageName")
            {
                if (query == "pageName")
                {
                    if (!string.IsNullOrEmpty(pageName))
                    {
                        foreach (string s in qvalue.Split(spl))
                        {
                            if (pageName.ToLower() == s.ToLower())
                            {
                                return curcss;
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(qvalue))
            {
                foreach (string s in qvalue.Split(spl))
                {
                    if (s != "")
                    {
                        if (WebRequest.GetQueryString(query).ToLower() == qvalue.ToLower())
                        {
                            return curcss;
                        }
                    }
                }
            }

            if (WebRequest.GetQueryString(query) == qvalue)
            {
                return curcss;
            }

            return css;
        }
        public static string QueryStringCur(string query, string qvalue, string css, string curcss)
        {
            return QueryStringCur(query, qvalue, css, curcss, ',');
        }

        #region 提示信息

        /// <summary>
        /// 遮罩提示窗口
        /// </summary>
        /// <param name="w">宽度</param>
        /// <param name="h">高度</param>
        /// <param name="msgtitle">窗口标题</param>
        /// <param name="msgbox">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        public static void JscriptMsg(System.Web.UI.Page curPage, int w, int h, string msgtitle, string msgbox, string url, string msgcss)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "parent.jsmsg(" + w + "," + h + ",\"" + msgtitle + "\",\"" + msgbox + "\",\"" + url + "\",\"" + msgcss + "\")\n";
            msbox += "</script>\n";
            curPage.ClientScript.RegisterClientScriptBlock(curPage.GetType(), "JsMsg", msbox);
        }

        /// <summary>
        /// 遮罩提示窗口
        /// </summary>
        /// <param name="w">宽度</param>
        /// <param name="h">高度</param>
        /// <param name="msgtitle">窗口标题</param>
        /// <param name="msgbox">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        public static void JscriptMsgCurPage(System.Web.UI.Page curPage, int w, int h, string msgtitle, string msgbox, string url, string msgcss)
        {
            string msbox = "";
            //msbox += "<script type=\"text/javascript\">\n";
            msbox += "parent.jsmsgCurPage(" + w + "," + h + ",\"" + msgtitle + "\",\"" + msgbox + "\",\"" + url + "\",\"" + msgcss + "\")\n";
            //msbox += "</script>\n";
            ScriptUtils.RegistScriptAtPageLast(curPage, msbox);
        }


        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        public static void JscriptPrint(System.Web.UI.Page curPage, string msgtitle, string url, string msgcss)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "parent.jsprint(\"" + msgtitle + "\",\"" + url + "\",\"" + msgcss + "\")\n";
            msbox += "</script>\n";
            curPage.ClientScript.RegisterClientScriptBlock(curPage.GetType(), "JsPrint", msbox);
        }

        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        public static void JscriptPrintCurPage(System.Web.UI.Page curPage, string msgtitle, string url, string msgcss)
        {
            string msbox = "";
            //\nmsbox += "<script type='text/javascript'>";
            msbox += "parent.jsprintCurPage('" + msgtitle + "','" + url + "','" + msgcss + "')";
            //msbox += "</script>";
            //curPage.ClientScript.RegisterClientScriptBlock(curPage.GetType(), "JsPrint", msbox);
            ScriptUtils.RegistScriptAtPageLast(curPage, msbox);
        }

        public static void setPDialog(System.Web.UI.Page curPage)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "SetPermission()";
            msbox += "</script>\n";
            curPage.Page.ClientScript.RegisterClientScriptBlock(curPage.Page.GetType(), "SetPermission", msbox);
        }

        #endregion
    }
}

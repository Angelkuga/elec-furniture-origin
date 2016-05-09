using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Data;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Admin.ajax
{
    /// <summary>
    /// adminajax 的摘要说明
    /// </summary>
    public class adminajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = "";
            string value = "";
            string t = "";

            if (context.Request.QueryString["type"] != null)
            {
                type = context.Request.QueryString["type"];
            }
            else
            {
                type = context.Request.Params["type"];
            }

            if (context.Request.QueryString["v"] != null)
            {
                value = context.Request.QueryString["v"];
            }
            else
            {
                value = context.Request.Params["v"];
            }

            if (context.Request.QueryString["t"] != null)
            {
                t = context.Request.QueryString["t"];
            }
            else
            {
                t = context.Request.Params["t"];
            }


            switch (type)
            {
                case "getmodulerootmenu":
                    context.Response.Write(GetModuleRootMenu(value));
                    break;
                case "getconfigtypemarket":
                    context.Response.Write(GetConfigTypeMarket(value,t));
                    break;
                default:
                    context.Response.Write("ajax数据读取错误");
                    break;

            }
            context.Response.End();
        }

        public string GetModuleRootMenu(string value)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"id\":\"0\",\"name\":\"一级菜单\"},");
            foreach (EnMenu m in ECMenu.GetMenuList(" parent=0 and  module=" + value))
            {
                sb.Append("{\"id\":\"" + m.id + "\",\"name\":\"" + m.title + "\"},");
            }
            if (sb.Length > 0)
            {
                return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
            }
            return "";
        }

        //判断类型标识是否存在
        public string GetConfigTypeMarket(string mark,string t)
        {

            if(t!="")
            {
                return "1";
            }

            if (ECConfig.ExitConfigTypeMark(mark) > 0)
            {
                return "0";
            }

            return "1";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
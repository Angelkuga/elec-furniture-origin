using System;
using System.Reflection;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using TRECommon;
using TREC.Entity;
using TREC.ECommerce;
using System.Collections;

namespace TREC.Web.ajax
{
    /// <summary>
    /// ajaxconfig 的摘要说明
    /// </summary>
    public class ajaxconfig : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string module = WebRequest.GetQueryString("module");
            string type = context.Request["type"] == null ? context.Request.Params["type"] == null ? "" : context.Request.Params["type"] : context.Request["type"];

            switch (type.ToLower())
            {
                case "getconfigmoduletype":
                    context.Response.Write(GetConfigModuleType(module));
                    break;
                case "getsumcount":
                    context.Response.Write(getSumCount());
                    break;
                default:
                    context.Response.Write("类型数据错误");
                    break;

            }

            context.Response.End();
        }

        //根据模块获取模块类型
        protected string GetConfigModuleType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            foreach (EnConfigType t in ECConfig.GetConfigTypeList(" type='" + type + "'"))
            {
                sb.Append("{\"id\":\"" + t.id + "\",\"name\":\"" + t.title + "\"},");
            }
            if (sb.Length > 0)
            {
                return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
            }
            return sb.ToString();
        }

        //获取站点数量统计
        protected string getSumCount()
        {
            Hashtable _htb = new Hashtable();//数据统计
            StringBuilder sb = new StringBuilder();
            _htb = ECProduct.GetIndexCount()[0];
            sb.Append("{\"bcount\":\"" + _htb["bcount"] + "\",\"mcount\":\"" + _htb["mcount"] + "\",\"pcount\":\"" + _htb["pcount"] + "\"}");

            return "[" + sb.ToString() + "]";
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
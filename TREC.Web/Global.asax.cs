using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using log4net;
using System.Text;

namespace TREC.Web
{
    public class Global : System.Web.HttpApplication
    {

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.DOMConfigurator.Configure();
            log.Debug("家具快搜启动");


 



        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string acceptTypes = Request.Headers["Accept"];

            if (!string.IsNullOrEmpty(acceptTypes) && acceptTypes.ToLower().Contains("text/vnd.wap.wml"))
            {

                Response.Cache.SetCacheability(HttpCacheability.NoCache);

            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            log.Error(getErrorRequestInfo(), ex);
            //Response.Redirect("/index.aspx");
        }
        public String getErrorRequestInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("错误:");
            if (Request.Headers["x-forwarded-for"] == null)
            {
                if (Request.UrlReferrer != null)
                {
                    sb.AppendLine("UrlReferrer:");
                    sb.AppendLine(Request.UrlReferrer.ToString());
                }
                sb.AppendLine("UserAgent:");
                sb.AppendLine(Request.UserAgent);
                sb.AppendLine("UserHostName:");
                sb.AppendLine(Request.UserHostName);
                sb.AppendLine("UserHostAddress:");
                sb.AppendLine(Request.UserHostAddress);
            }
            else
            {
                if (Request.UrlReferrer != null)
                {
                    sb.AppendLine("UrlReferrer:");
                    sb.AppendLine(Request.UrlReferrer.ToString());
                }
                sb.AppendLine("UserAgent:");
                sb.AppendLine(Request.UserAgent);
                sb.AppendLine("UserHostName:");
                sb.AppendLine(Request.UserHostName);
                sb.AppendLine("UserHostAddress:");
                sb.AppendLine(Request.UserHostAddress);
                sb.AppendLine("ActualRequestIP:");
                sb.AppendLine(Request.Headers["x-forwarded-for"].ToString());
            }
            return sb.ToString();
        }  
        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            log.Debug("家具快搜停止");
        }
    }
}
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Xml;
using TRECommon;
using TREC.Data;
using TREC.Entity;

namespace TREC.ECommerce
{
    public class HttpModule:System.Web.IHttpModule
    {
        static Timer eventTimer;

        /// <summary>
        /// 实现接口的Init方法
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
           
            context.BeginRequest += new EventHandler(ReUrl_BeginRequest);
            context.Error += new EventHandler(Application_OnError);
        }

        public void Application_OnError(Object sender, EventArgs e)
        {
            //string requestUrl = DNTRequest.GetUrl();
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            //if (GeneralConfigs.GetConfig().Installation == 0 && requestUrl.IndexOf("install") == -1)//当该站点未运行过安装并且当前页面不是安装程序目录下的页面时
            //{
            //    context.Server.ClearError();//清除程序异常
            //    HttpContext.Current.Response.Redirect(BaseConfigs.GetForumPath + "install/index.aspx");
            //    return;
            //}

            //context.Response.Write("<html><body style=\"font-size:14px;\">");
            //context.Response.Write("FordioB2B Error:<br />");
            //context.Response.Write("<textarea name=\"errormessage\" style=\"width:80%; height:200px; word-break:break-all\">");
            //context.Response.Write(System.Web.HttpUtility.HtmlEncode(context.Server.GetLastError().ToString()));
            //context.Response.Write("</textarea>");
            //context.Response.Write("</body></html>");
            //context.Response.End();

            //context.Server.ClearError();//清除程序异常
        }

        public void ReUrl_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;


            string requestPath = TRECommon.WebRequest.UrlDecode(context.Request.RawUrl.ToLower());

            if (context.Request.RawUrl.ToLower() == "/")
            {
                requestPath = "/index.aspx";
            }
            if (requestPath.Contains("/ajax/") || requestPath.Contains("/upload/") || requestPath.Contains("/ajaxtools/") || requestPath.Contains("/admin/") || requestPath.Contains("/suppler/") || requestPath.Contains("/resource/") || requestPath.Contains("/common/"))
            {
                context.RewritePath(requestPath);
                return;
            }


            //网站风格
            string templateWeb = "/template/web/default";
            
            foreach (SiteUrls.URLRewrite url in SiteUrls.GetSiteUrls().Urls)
            {
                if (url.Name == "productlistsearch2" || url.Name == "productlistsearch")
                { 
                
                }

                if (Regex.IsMatch(requestPath, url.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase))
                {
                    string newUrl = Regex.Replace(requestPath, url.Pattern, url.QueryString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    newUrl = newUrl == "" ? templateWeb + url.Page : templateWeb + url.Page + "?" + newUrl;
                    context.RewritePath(newUrl);
                    return;
                }
            }


            context.RewritePath(templateWeb+requestPath);

        }

        /// <summary>
        /// 实现接口的Dispose方法
        /// </summary>
        public void Dispose()
        {
            eventTimer = null;
        }

        //////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 站点伪Url信息类
        /// </summary>
        public class SiteUrls
        {
            #region 内部属性和方法
            private static object lockHelper = new object();
            private static volatile SiteUrls instance = null;

            string SiteUrlsFile = HttpContext.Current.Server.MapPath("~/config/urls.config");
            private System.Collections.ArrayList _Urls;
            public System.Collections.ArrayList Urls
            {
                get
                {
                    return _Urls;
                }
                set
                {
                    _Urls = value;
                }
            }

            private System.Collections.Specialized.NameValueCollection _Paths;
            public System.Collections.Specialized.NameValueCollection Paths
            {
                get
                {
                    return _Paths;
                }
                set
                {
                    _Paths = value;
                }
            }

            private SiteUrls()
            {
                Urls = new System.Collections.ArrayList();
                Paths = new System.Collections.Specialized.NameValueCollection();

                XmlDocument xml = new XmlDocument();

                xml.Load(SiteUrlsFile);

                XmlNode root = xml.SelectSingleNode("urls");
                foreach (XmlNode n in root.ChildNodes)
                {
                    if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "rewrite")
                    {
                        XmlAttribute name = n.Attributes["name"];
                        XmlAttribute path = n.Attributes["path"];
                        XmlAttribute page = n.Attributes["page"];
                        XmlAttribute querystring = n.Attributes["querystring"];
                        XmlAttribute pattern = n.Attributes["pattern"];

                        if (name != null && path != null && page != null && querystring != null && pattern != null)
                        {
                            Paths.Add(name.Value, path.Value);
                            Urls.Add(new URLRewrite(name.Value, pattern.Value, page.Value.Replace("^", "&"), querystring.Value.Replace("^", "&")));
                        }
                    }
                }
            }
            #endregion

            public static SiteUrls GetSiteUrls()
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new SiteUrls();
                        }
                    }
                }
                return instance;

            }

            public static void SetInstance(SiteUrls anInstance)
            {
                if (anInstance != null)
                    instance = anInstance;
            }

            public static void SetInstance()
            {
                SetInstance(new SiteUrls());
            }


            /// <summary>
            /// 重写伪地址
            /// </summary>
            public class URLRewrite
            {
                #region 成员变量
                private string _Name;
                public string Name
                {
                    get
                    {
                        return _Name;
                    }
                    set
                    {
                        _Name = value;
                    }
                }

                private string _Pattern;
                public string Pattern
                {
                    get
                    {
                        return _Pattern;
                    }
                    set
                    {
                        _Pattern = value;
                    }
                }

                private string _Page;
                public string Page
                {
                    get
                    {
                        return _Page;
                    }
                    set
                    {
                        _Page = value;
                    }
                }

                private string _QueryString;
                public string QueryString
                {
                    get
                    {
                        return _QueryString;
                    }
                    set
                    {
                        _QueryString = value;
                    }
                }
                #endregion

                #region 构造函数
                public URLRewrite(string name, string pattern, string page, string querystring)
                {
                    _Name = name;
                    _Pattern = pattern;
                    _Page = page;
                    _QueryString = querystring;
                }
                #endregion
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web
{
	public partial class loginuser : System.Web.UI.Page
	{
        protected string pageTitle = "";

        public string getUrlReferrer
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request.UrlReferrer.AbsoluteUri))
                    {
                        return Request.UrlReferrer.AbsoluteUri;
                    }
                    else
                    {
                        return "/";
                    }
                }
                catch
                {
                    return "/";
                }
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            pageTitle = "家具快搜 - 用户登录";
		}
	}
}
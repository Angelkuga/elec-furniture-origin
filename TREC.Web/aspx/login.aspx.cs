using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion
      
      
    public partial class login :WebPageBase
    {
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
            pageTitle = "-会员登陆";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;

namespace TREC.Web.aspx
{
    public partial class loginout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CookiesHelper.RemoveCookies("UserInfo");
            SupplerPageBase.memberInfo = null;
            Response.Redirect("/");
          //  CookiesHelper.WriteCookie("mid", "", -1);
          //  CookiesHelper.WriteCookie("mpwd", "", -1);
           // Response.Redirect(ResolveUrl("~/index.aspx"));
        }
    }
}
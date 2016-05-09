using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;

namespace TREC.Web.Admin
{
    public partial class loginout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CookiesHelper.RemoveCookies("AdminInfo");
            Response.Redirect("/admin/login.aspx");
            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.location.href='/admin/login.aspx';", true);
        }
    }
}
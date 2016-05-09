using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;

namespace TREC.Web
{
	public partial class logoutuser : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            CookiesHelper.RemoveCookies("CustomerInfo");
            Response.Redirect("/");
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.template.web.ascx
{
	public partial class Ucenter : System.Web.UI.UserControl
	{
        public string userName;
		protected void Page_Load(object sender, EventArgs e)
		{
            string CustomerUserId = TRECommon.CookiesHelper.GetCookieCustomer("cid");
            userName = TRECommon.CookiesHelper.GetCookieCustomer("cname");
		}
	}
}
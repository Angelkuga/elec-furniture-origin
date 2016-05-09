using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;

namespace TREC.Web.template.web.Ucenter
{
	public partial class Default : System.Web.UI.Page
	{
        public string userName;

        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
		protected void Page_Load(object sender, EventArgs e)
		{
            string CustomerUserId = TRECommon.CookiesHelper.GetCookieCustomer("cid");
            userName = TRECommon.CookiesHelper.GetCookieCustomer("cname");

            if (CustomerUserId != "")
            {
               //ShoppingAddress
            }
            else
            {
                Response.Redirect("/loginuser.aspx");
            }
		}
	}
}
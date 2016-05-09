using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;

namespace TREC.Web.ajax
{
    public partial class DelStrolleyShopping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["ids"] != null)
            {
                if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != "")
                {
                    string ids = Request.Form["ids"];
                    if (EcShoppingPay.DelShoppingTrolley(ids, Int32.Parse(TRECommon.CookiesHelper.GetCookieCustomer("cid"))))
                    {
                        Response.Write("true");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }
                else
                {
                    Response.Write("nologin");
                }
            }
        }
    }
}
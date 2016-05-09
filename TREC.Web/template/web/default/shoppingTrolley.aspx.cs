using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TREC.ECommerce;

namespace TREC.Web.template.web.default2
{
	public partial class shoppingTrolley : System.Web.UI.Page
	{
        //1.促销价buyprice 2.销售价saleprice 3.市场价 markprice
		protected void Page_Load(object sender, EventArgs e)
		{
            if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != "")
            {
                DataTable dt = new DataTable();
                dt = EcShoppingPay.ShoppingTrolleyList(Int32.Parse(TRECommon.CookiesHelper.GetCookieCustomer("cid")));
                Repeater_shopping.DataSource = dt;
                Repeater_shopping.DataBind();
                 
            }
            else
            {
                Response.Redirect("/loginuser.aspx");
            }
		}
	}
}
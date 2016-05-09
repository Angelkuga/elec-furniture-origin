using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;

namespace TREC.Web.ajax
{
    public partial class STrolleyData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["tpbid"] != null)
            {
                try
                {
                    if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != "")
                    {
                        EcShoppingPay.AddShoppingTrolley(Int32.Parse(TRECommon.CookiesHelper.GetCookieCustomer("cid")), Int32.Parse(Request.Form["tpbid"]));
                        Response.Write("已成功添加到购物车");
                    }
                    else
                    {
                        Response.Write("nologin");

                    }
                }
                catch
                {
                    Response.Write("提交出错，请联系管理员");
                }
            }
        }
    }
}
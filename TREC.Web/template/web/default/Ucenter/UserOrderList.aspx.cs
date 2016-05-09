using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TREC.ECommerce;

namespace TREC.Web.template.web.Ucenter
{
	public partial class UserOrderList : System.Web.UI.Page
	{
        public string noplay = "0";
		protected void Page_Load(object sender, EventArgs e)
		{
            string CustomerUserId = TRECommon.CookiesHelper.GetCookieCustomer("cid");
           

            //string pageindex = Request["pageindex"];
            //DataSet ds = new DataSet();
            //ds = EcShoppingPay.GetOrderList("1", "and customeruserid=" + CustomerUserId + " and orderDel=0 and createtime>=dateAdd(month,-3,getdate()) ','OrderList");//table[2] 总页数
            if (SubmitMeth.getInt(CustomerUserId) > 0)
            {
                DataSet dsnoplay = new DataSet();
                dsnoplay = EcShoppingPay.GetOrderList("1", " and customeruserid=" + CustomerUserId + " and orderDel=0  and result=0 ");
                noplay = dsnoplay.Tables[1].Rows[0][0].ToString();
            }
            else
            {
                Response.Write("/loginuser.aspx");
            }

		}
	}
}
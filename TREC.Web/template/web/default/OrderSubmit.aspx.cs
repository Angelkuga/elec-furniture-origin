using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using System.Data;

namespace TREC.Web.template.web.default2
{
	public partial class OrderSubmit : System.Web.UI.Page
	{
        public string buyCount;//购买数量
        public string allprice;//总价

        public string BuyCount(string id)
        {
            string idsreq = Request.Form["ShoppingIds"].Trim();
            string ids = idsreq.TrimEnd(';');
            Dictionary<int, int> _dic = new Dictionary<int, int>();
            
            foreach (string s in ids.Split(';'))
            {
                _dic.Add(Int32.Parse(s.Split(',')[0]), Int32.Parse(s.Split(',')[1]));
            }

            return _dic.Where(p => p.Key == Int32.Parse(id)).FirstOrDefault().Value.ToString();
        }
        public string idsNumber = string.Empty;
        EcShoppingPay _shoppingPay = new EcShoppingPay();

		protected void Page_Load(object sender, EventArgs e)
		{
            if (Request.Form["ShoppingIds"] != null)
            {
                DataSet ds = new DataSet();

                string ids = Request.Form["ShoppingIds"].Trim();
                idsNumber = _shoppingPay.OrderNumber + "|" + ids.TrimEnd(';');
                if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != "" && ids.Length>1)
                {
                   ds=EcShoppingPay.ShoppingOrder(ids.TrimEnd(';'),Int32.Parse(TRECommon.CookiesHelper.GetCookieCustomer("cid")));
                   buyCount = ds.Tables[0].Rows[0][0].ToString();
                   allprice = ds.Tables[2].Rows[0][0].ToString();
                   Repeater_data.DataSource = ds.Tables[1];
                   Repeater_data.DataBind();
                    //Response.Write(ds.Tables[1].Rows[0][0].ToString());
                }

               // Response.Write(ids);
            }
		}
	}
}
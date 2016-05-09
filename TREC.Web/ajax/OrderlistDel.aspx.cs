using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;
using TREC.ECommerce;

namespace TREC.Web.ajax
{
    public partial class OrderlistDel : System.Web.UI.Page
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        int CustomerUserId = Int32.Parse(TRECommon.CookiesHelper.GetCookieCustomer("cid"));
        protected void Page_Load(object sender, EventArgs e)
        {
            int id=SubmitMeth.getInt(Request["id"]);

            OrderList _order = new OrderList();
            _order = EntityOper.OrderList.Where(p => p.Id == id && p.CustomerUserId == CustomerUserId).FirstOrDefault();
            _order.OrderDel = 1;
            EntityOper.SubmitChanges();
        }
    }
}
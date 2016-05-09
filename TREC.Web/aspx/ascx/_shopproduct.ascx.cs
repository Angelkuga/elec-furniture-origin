using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.aspx.ascx
{
    public partial class _shopproduct : System.Web.UI.UserControl
    {
        public string Procount = "0";
        public string sid
        {
            get
            {
                if (Request["sid"] != null)
                {
                    return Request["sid"];
                }
                else
                {
                    return "0";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int rows=0;
            ECProduct.GetWebProductList(1, 1, " and shopid=" + sid + " AND auditstatus=1 AND linestatus=1  ", "", "", out rows);
            if (rows == 0)
            {
                ECProduct.GetWebProductList(1, 1, " AND auditstatus=1 AND linestatus=1 and brandid in (select brandid from t_shopbrand where shopid=" + sid + ") and   (shopid=0 OR shopid IS NULL) ", "", "", out rows);
            }
            Procount = rows.ToString();
        }
        public string brandid { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler
{
    public partial class index : SupplerPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (memberInfo != null && memberInfo.groupid == 10)
            {
                HttpContext.Current.Response.Redirect("/");
                return;
            }
            if (memberInfo != null && memberInfo.type == 100)
            {
                HttpContext.Current.Response.Redirect(ECommon.WebUrl + "suppler/supplerindex.aspx");
                return;
                
            }
            //  Master.menuName = "";
        }
    }
}
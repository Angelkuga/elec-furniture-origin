using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler
{
    public partial class supplerindex : SupplerPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //new SupplerPageBase().mySupplerPageBase();
                //EnMember memberinfo = SupplerPageBase.memberInfo;
                //if (memberinfo == null)
                //{
                //    Response.Redirect(ECommon.WebUrl + "index.aspx");
                //}
            }
        }
    }
}
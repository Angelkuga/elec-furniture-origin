using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx.market
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion


    public partial class index2 : MarketPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-" + marketInfo.title + "-家具卖场-首页";
        }
    }
}
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


    public partial class about : MarketPageBase
    {
        public List<EnWebMarketStoreyShop> elist = new List<EnWebMarketStoreyShop>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-" + marketInfo.title + "-家具卖场-卖场介绍";

            int pageCount = 0;
            string strWhere = " and storeyid!=0 and brandxml<>'' and (marketid=" + marketInfo.id + ") ";
            elist = ECMarketStoreyShop.GetWebMarketStoreyShopList(1, 5, strWhere, "", "", out pageCount);
        }
    }
}
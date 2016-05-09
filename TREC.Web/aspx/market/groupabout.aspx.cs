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


    public partial class groupabout : MarketPageBase
    {
        //卖场推荐品牌id
        protected string brandidList = "0";
        //卖场推荐品牌
        protected List<EnWebBrand> brandList = new List<EnWebBrand>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-" + marketInfo.title + "-卖场集团首页";

            foreach (EnWebMarket.MarketBrand b in marketInfo.MarketBrandList)
            {
                brandidList += "," + b.id;
            }
            int pc = 0;
            brandList = TREC.ECommerce.ECBrand.GetWebBrandList(1, 8, string.Format(" id in ({0})", brandidList), out pc);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.template.web.market
{
    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using Haojibiz;
    #endregion
    public partial class pavilionAbout : MarketPageBase
	{
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        public List<EnWebMarketStoreyShop> elist = new List<EnWebMarketStoreyShop>();
        public string paid
        {
            get
            {
                if (Request["paid"] != null)
                {
                    return Request["paid"];
                }
                else
                {
                    return "0";
                }
            }
        }
        public string description = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-" + marketInfo.title + "-家具卖场-卖场介绍";

            int pageCount = 0;
            string strWhere = " and storeyid!=0 and brandxml<>'' and (marketid=" + marketInfo.id + ") ";
            elist = ECMarketStoreyShop.GetWebMarketStoreyShopList(1, 5, strWhere, "", "", out pageCount);

            t_Pavilion _pav=new t_Pavilion();
            _pav = EntityOper.t_Pavilion.Where(p=>p.Id==SubmitMeth.getInt(paid)).FirstOrDefault();

            if (_pav != null)
            {
                description = _pav.Description;
            }
        }
	}
}
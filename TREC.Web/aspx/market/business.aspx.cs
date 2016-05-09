using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;
using System.Text;

namespace TREC.Web.aspx.market
{
    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using Haojibiz.Model;
    #endregion

    public partial class business : MarketPageBase
	{
        protected List<Mpromotions> list = new List<Mpromotions>();
        protected Dpromotions dpromotions = new Dpromotions();
        public List<EnWebMarketStoreyShop> elist = new List<EnWebMarketStoreyShop>();
        protected List<Mshop> shoplist = new List<Mshop>();

        protected string NextUrl
        {
            get
            {
                if (pager.CurrentPageIndex == pager.PageCount)
                {
                    return "#";
                }

                string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                return string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, ECommon.QuerySearchDisplay, strqsb, pager.CurrentPageIndex + 1);
            }
        }
        protected string PrvUrl
        {
            get
            {
                if (pager.CurrentPageIndex <= 1)
                {
                    return "#";
                }
                string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);

                return string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, ECommon.QuerySearchDisplay, strqsb, pager.CurrentPageIndex - 1);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
		{
            pageTitle = "-" + marketInfo.title + "-家具卖场-招商信息";

            int pageCount = 0;
            string strWhere = " and storeyid!=0  and brandxml<>'' and (marketid=" + marketInfo.id + ") ";
            elist = ECMarketStoreyShop.GetWebMarketStoreyShopList(1, 5, strWhere, "", "", out pageCount);


            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            var query = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1 && c.attribute == "招商").GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k }).Where(c => c.k.Where(m => m.marketid == marketInfo.id || dpromotions.LinqData<Mmarketstoreyshop>().Where(j => j.marketid == marketInfo.id && j.shopid == m.shopid).Any()).Any());
            list = pager.GetPagedDataSource(query).Select(c => new Mpromotions
            {
                id = c.f.id,
                title = c.f.title,
                startdatetime = c.f.startdatetime,
                enddatetime = c.f.enddatetime,
                membertype = c.f.membertype,
                promotionsrelated = c.k.ToList()
            }).OrderByDescending(c => c.IsTop).OrderByDescending(c => c.enddatetime).ToList();
            pager.EnableUrlRewriting = true;
            pager.UrlRewritePattern = string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, ECommon.QuerySearchDisplay, strqsb, "{0}");

            if (list.Count > 0)
            {
                var shopids = list.SelectMany(c => c.promotionsrelated.Where(m => dpromotions.LinqData<Mmarketstoreyshop>().Where(j => j.marketid == marketInfo.id && j.shopid == m.shopid).Any()).Select(s => s.shopid)).ToArray();
                shoplist = dpromotions.LinqData<Mshop>().Where(c => shopids.Contains(c.id)).ToList();
            }
		}
        protected global::Wuqi.Webdiyer.AspNetPager pager;
	}
}
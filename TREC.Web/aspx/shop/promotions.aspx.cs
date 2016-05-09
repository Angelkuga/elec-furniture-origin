using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;

namespace TREC.Web.aspx.shop
{
    public class promotions : ShopPageBase
    {
        protected Dpromotions dpromotions = new Dpromotions();
        protected List<Mpromotions> list = new List<Mpromotions>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showData();
            }
        }

        void showData()
        {
            var query = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k })
                .Where(c => c.k.Where(s => s.shopid == shopInfo.id).Any());
            list = pager.GetPagedDataSource(query).Select(c => c.f).OrderByDescending(c => c.IsTop).OrderByDescending(c => c.enddatetime).ToList();
            pager.EnableUrlRewriting = true;
            pager.UrlRewritePattern = string.Format(EnUrls.ShopInfoPromotionsSearch, ECommon.QuerySId, "{0}");
        }

        protected global::Wuqi.Webdiyer.AspNetPager pager;
    }
}
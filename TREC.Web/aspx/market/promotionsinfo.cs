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
namespace TREC.Web.aspx.market
{
    public class promotionsinfo : MarketPageBase
    {
        protected Dpromotions dpromotions = new Dpromotions();
        protected Mpromotions mpromotions = new Mpromotions();
        protected int PKID = TRECommon.WebRequest.GetQueryInt("id");
        protected List<Mshop> shoplist = new List<Mshop>();
        protected List<Mmarket> marketlist = new List<Mmarket>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PKID > 0)
            {
                var firstItem = dpromotions.Linq.Where(c => c.id == PKID).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k })
                     .Where(c => c.f.id == PKID).FirstOrDefault();
                if (firstItem != null)
                {
                    mpromotions = firstItem.f;
                    mpromotions.promotionsrelated = firstItem.k.ToList();

                    var shopids = mpromotions.promotionsrelated.Select(c => c.shopid).ToList();
                    if (shopids.Count > 0)
                    {
                        shoplist = dpromotions.LinqData<Mshop>().Where(c => shopids.Contains(c.id)).ToList();
                    }
                    var marketids = mpromotions.promotionsrelated.Select(c => c.marketid).ToList();
                    if (marketids.Count > 0)
                    {
                        marketlist = dpromotions.LinqData<Mmarket>().Where(c => marketids.Contains(c.id)).ToList();
                    }
                }
            }
        }

        private List<EnBrand> brandList = null;
        public List<EnBrand> BrandList
        {
            get
            {
                if (brandList == null)
                {
                    brandList = dpromotions.LinqData<Mbrand>().Where(c => c.linestatus == 1 && dpromotions.LinqData<Mshopbrand>().Where(b => b.brandid == c.id && dpromotions.LinqData<Mmarketstoreyshop>().Where(m => m.shopid == b.shopid && m.marketid == marketInfo.id).Any()).Any()).Select(c => new EnBrand { letter = c.letter, title = c.title }).ToList() ?? new List<EnBrand>();
                }
                return brandList;
            }
        }
    }
}
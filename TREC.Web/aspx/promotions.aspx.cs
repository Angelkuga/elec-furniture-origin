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
using System.Data.Linq;

namespace TREC.Web.aspx
{
    public class promotions : WebPageBase
    {
        protected Dpromotions dpromotions = new Dpromotions();
        protected List<Mpromotions> list = new List<Mpromotions>();
        protected List<Mshop> shoplist = new List<Mshop>();
        protected List<Mmarket> marketlist = new List<Mmarket>();
        protected List<string> arealist = new List<string>();

        public string getListTitle
        {
            get
            {
                string url = Request.Url.ToString();
                if (url.ToLower().Contains("display=brand"))
                {
                    return "品牌促销资讯";
                }
                else if (url.ToLower().Contains("display=market"))
                {
                    return "卖场促销资讯";
                }
                else
                {
                    return "所有资讯";
                }
            }
        }
        protected string NextUrl
        {
            get
            {
                if (ECommon.QueryPageIndex >= pager.PageCount)
                {
                    return "#";
                }
                else
                {
                    string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    return string.Format(EnUrls.PromotionsListSearch, ECommon.QuerySearchDisplay, strqsb, ECommon.QuerySearchMarket, ECommon.QuerySearchArea, ECommon.QueryPageIndex + 1);
                }
            }
        }
        protected string PrvUrl
        {
            get
            {
                if (ECommon.QueryPageIndex <= 1)
                {
                    return "#";
                }
                else
                {
                    string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    return string.Format(EnUrls.PromotionsListSearch, ECommon.QuerySearchDisplay, strqsb, ECommon.QuerySearchMarket, ECommon.QuerySearchArea, ECommon.QueryPageIndex - 1);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-优惠促销";
            if (!IsPostBack)
            {
                showData();
            }
        }

        protected void showData()
        {
            var query = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1);
            if (!string.IsNullOrEmpty(ECommon.QuerySearchKey))
            {
                query = query.Where(c => c.title.Contains(ECommon.QuerySearchKey));
            }
            var query2 = query.GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k });
            if (!string.IsNullOrEmpty(ECommon.QuerySearchArea) && ECommon.QuerySearchArea != "0")
            {
                txtarea.SelectedAreaID = ECommon.QuerySearchArea;
                rows = darea.Select();
                arealist.Add(ECommon.QuerySearchArea);
                froe(arealist, ECommon.QuerySearchArea);
                query2 = query2.Where(c => c.k.Any(j => dpromotions.LinqData<Mshop>().Where(s => arealist.Contains(s.areacode) && s.id == j.shopid).Any() || dpromotions.LinqData<Mmarket>().Where(m => arealist.Contains(m.areacode) && m.id == j.marketid).Any()));
            }
            switch (ECommon.QuerySearchDisplay)
            {
                case "brand":
                    query2 = query2.Where(c => c.k.Any(f => f.membertype == (int)EnumMemberType.工厂企业 || f.membertype == (int)EnumMemberType.经销商));
                    string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                                      strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                                      if (!string.IsNullOrEmpty(strqsb))
                                      {
                                          if (arealist.Count > 0)
                                          {
                                              query2 = query2.Where(c => c.k.Where(j => j.shopid > 0 && dpromotions.LinqData<Mshopbrand>().Where(m => m.shopid == j.shopid && dpromotions.LinqData<Mbrand>().Where(b => b.id == m.brandid && (b.title.Contains(strqsb) || b.letter.Contains(strqsb))).Any() && dpromotions.LinqData<Mshop>().Where(s => s.id == m.shopid && arealist.Contains(s.areacode)).Any()).Any()).Any());
                                          }
                                          else
                                          {
                                              query2 = query2.Where(c => c.k.Where(j => j.shopid > 0 && dpromotions.LinqData<Mshopbrand>().Where(m => m.shopid == j.shopid && dpromotions.LinqData<Mbrand>().Where(b => b.id == m.brandid && (b.title.Contains(strqsb) || b.letter.Contains(strqsb))).Any()).Any()).Any());
                                          }
                                      }
                    break;
                case "market":
                    query2 = query2.Where(c => c.k.Any(f => f.membertype == (int)EnumMemberType.卖场));
                    if (!string.IsNullOrEmpty(ECommon.QuerySearchMarket))
                    {
                        if (arealist.Count > 0)
                        {
                            query2 = query2.Where(c => c.k.Where(j => j.marketid > 0 && dpromotions.LinqData<Mmarket>().Where(m => m.id == j.marketid && (m.title.Contains(ECommon.QuerySearchMarket) || m.letter.Contains(ECommon.QuerySearchMarket)) && arealist.Contains(m.areacode)).Any()).Any());
                        }
                        else
                        {
                            query2 = query2.Where(c => c.k.Where(j => j.marketid > 0 && dpromotions.LinqData<Mmarket>().Where(m => m.id == j.marketid && (m.title.Contains(ECommon.QuerySearchMarket) || m.letter.Contains(ECommon.QuerySearchMarket))).Any()).Any());
                        }
                    }
                    break;
                default:

                    break;
            }
            var query3 = pager.GetPagedDataSource(query2.OrderByDescending(c => c.f.createtime));
            list = query3.Select(c => new Mpromotions
            {
                id = c.f.id,
                title = c.f.title,
                startdatetime = c.f.startdatetime,
                enddatetime = c.f.enddatetime,
                createtime = c.f.createtime,
                membertype = c.f.membertype,
                promotionsrelated = c.k.ToList()
            }).ToList();

            pager.EnableUrlRewriting = true;

            string strqsb1 = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb1 = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);

            pager.UrlRewritePattern = string.Format(EnUrls.PromotionsListSearch, ECommon.QuerySearchDisplay, strqsb1, ECommon.QuerySearchMarket, ECommon.QuerySearchArea, "{0}");

            var shopids = list.SelectMany(c => c.promotionsrelated.Select(f => f.shopid)).Where(c => c > 0).ToArray();
            var marketids = list.SelectMany(c => c.promotionsrelated.Select(f => f.marketid)).Where(c => c > 0).ToArray();

            shoplist = dpromotions.LinqData<Mshop>().Where(c => shopids.Contains(c.id)).ToList();
            marketlist = dpromotions.LinqData<Mmarket>().Where(c => marketids.Contains(c.id)).ToList();
        }
        private List<EnBrand> brandList = null;
        public List<EnBrand> BrandList
        {
            get
            {
                if (brandList == null)
                {
                    brandList = ECBrand.GetBrandList(" linestatus = 1");
                }
                return brandList;
            }
        }
        private List<EnMarket> marketList = null;
        public List<EnMarket> MarketList
        {
            get
            {
                if (marketList == null)
                {
                    marketList = ECMarket.GetMarketList(string.Empty);
                }
                return marketList;
            }
        }
        Haojibiz.DAL.Darea darea = new Haojibiz.DAL.Darea();
        MareaCollection rows = new MareaCollection();
        void froe(List<string> s, string p)
        {
            foreach (var item in rows.Where(c => c.parentcode == p))
            {
                s.Add(item.areacode);
                froe(s, item.areacode);
            }
        }

        private List<Mpromotions> newList = null;
        protected List<Mpromotions> NewList
        {
            get
            {
                if (newList == null)
                {
                    newList = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k }).OrderByDescending(c => c.f.createtime).Take(5).ToList().Select(c => new Mpromotions
                    {
                        id = c.f.id,
                        title = c.f.title,
                        startdatetime = c.f.startdatetime,
                        enddatetime = c.f.enddatetime,
                        createtime = c.f.createtime,
                        membertype = c.f.membertype,
                        promotionsrelated = c.k.ToList()
                    }).ToList();
                }
                return newList;
            }
        }
        protected global::Wuqi.Webdiyer.AspNetPager pager;

        protected global::TREC.Web.aspx.ascx._AreaSelect txtarea;
    }
}
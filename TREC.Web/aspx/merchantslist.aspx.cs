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
    public class merchantslist : WebPageBase
    {
        protected Dpromotions dpromotions = new Dpromotions();
        protected List<Mpromotions> list = new List<Mpromotions>();
        protected List<Mshop> shoplist = new List<Mshop>();
        protected List<Mmarket> marketlist = new List<Mmarket>();
        protected List<string> arealist = new List<string>();
        protected List<EnWebMerchants> _lst = new List<EnWebMerchants>();
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

                    return string.Format(EnUrls.MerchantsSearch, ECommon.QuerySearchStyle, ECommon.QueryPageIndex + 1);
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
                    return string.Format(EnUrls.MerchantsSearch, ECommon.QuerySearchStyle, ECommon.QueryPageIndex - 1);
                }
            }
        }

        public List<EnSearchItem> _Lst = new List<EnSearchItem>();

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
            
            var query3 = pager.GetPagedDataSource(query2.OrderByDescending(c => c.f.createtime));

            string strWhere = "";

            if (ECommon.QuerySearchStyle != "")
            {
                strWhere += " and style=" + ECommon.QuerySearchStyle;
            }

            string orderType = "desc";
            string orderKey = "ID";
            int pageCount = 0;
            _lst = ECMerchants.GetWebMerchantsList(ECommon.QueryPageIndex, pager.PageSize, strWhere, orderKey, orderType, out pageCount);
            _Lst = ECCompany.GetSearchItem();
            //list = query3.Select(c => new Mpromotions
            //{
            //    id = c.f.id,
            //    title = c.f.title,
            //    startdatetime = c.f.startdatetime,
            //    enddatetime = c.f.enddatetime,
            //    createtime = c.f.createtime,
            //    membertype = c.f.membertype,
            //    promotionsrelated = c.k.ToList()
            //}).ToList();
            pager.RecordCount = pageCount;
            pager.EnableUrlRewriting = true;
            pager.UrlRewritePattern = string.Format(EnUrls.MerchantsSearch, ECommon.QuerySearchKey, "{0}");
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
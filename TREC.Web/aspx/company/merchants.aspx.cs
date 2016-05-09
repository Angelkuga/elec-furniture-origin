using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;
using System.Data.Linq;

namespace TREC.Web.aspx.company
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion


    public partial class merchants : CompanyPageBase
    {
        Dpromotions dpromotions = new Dpromotions();
        protected List<Mpromotions> list = new List<Mpromotions>();
        protected List<Mshop> shoplist = new List<Mshop>();
        protected List<string> arealist = new List<string>();
        Haojibiz.DAL.Darea darea = new Haojibiz.DAL.Darea();
        MareaCollection rows = new MareaCollection();

        protected int bid = TRECommon.TypeConverter.StrToInt(((ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand).ToLower().Contains("_b") ? (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand).Substring(0, (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand).Length - 2) : (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand)));
        protected void Page_Load(object sender, EventArgs e)
        {
            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);


            if (string.IsNullOrEmpty(strqsb))
            {
                Response.Redirect(string.Format(EnUrls.CompanyInfoMerchantsSearch, ECommon.QueryCId, companyInfo.CompanyBrandInfo.id, "0", 1));
            }
            pageTitle = "-" + companyInfo.title + "-招商信息";
            if (!IsPostBack)
            {
                showData();
            }
        }
        void showData()
        {
            var query = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1 && c.attribute == "招商" && (c.membertype == (int)EnumMemberType.工厂企业 || c.membertype == (int)EnumMemberType.经销商)).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k });

            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);


            if (!string.IsNullOrEmpty(strqsb))
            {
                query = query.Where(c => c.k.Any(f => dpromotions.LinqData<Mshop>().Where(s => s.id == f.shopid && dpromotions.LinqData<Mshopbrand>().Where(k => k.brandid == bid && k.shopid == s.id).Any()).Any()));
            }
            if (!string.IsNullOrEmpty(ECommon.QuerySearchArea) && ECommon.QuerySearchArea != "0")
            {
                txtarea.SelectedAreaID = ECommon.QuerySearchArea;
                rows = darea.Select();
                arealist.Add(ECommon.QuerySearchArea.Trim());
                froe(arealist, ECommon.QuerySearchArea);
                query = query.Where(c => c.k.Any(j => dpromotions.LinqData<Mshop>().Where(s => arealist.Contains(s.areacode) && s.id == j.shopid && dpromotions.LinqData<Mshopbrand>().Where(k => k.brandid == bid && k.shopid == s.id).Any()).Any()));
            }
            list = pager.GetPagedDataSource(query.Where(c => c.k.Any())).Select(c => new Mpromotions
            {
                id = c.f.id,
                title = c.f.title,
                startdatetime = c.f.startdatetime,
                enddatetime = c.f.enddatetime,
                membertype = c.f.membertype,
                descript = c.f.descript,
                promotionsrelated = c.k.ToList()
            }).OrderByDescending(c => c.IsTop).OrderByDescending(c => c.enddatetime).ToList();
            pager.EnableUrlRewriting = true;
            pager.UrlRewritePattern = string.Format(EnUrls.CompanyInfoPromotionsSearch, ECommon.QueryCid, strqsb, ECommon.QuerySearchArea, "{0}");


            var queryshop = dpromotions.LinqData<Mshop>().AsQueryable();
            if (!string.IsNullOrEmpty(strqsb))
            {
                queryshop = queryshop.Where(c => dpromotions.LinqData<Mshopbrand>().Where(s => s.brandid == bid && s.shopid == c.id).Any());
            }
            if (!string.IsNullOrEmpty(ECommon.QuerySearchArea) && ECommon.QuerySearchArea != "0")
            {
                queryshop = queryshop.Where(c => arealist.Contains(c.areacode));
            }
            if (list.Count > 0)
            {
                queryshop = queryshop.Where(c => list.SelectMany(l => l.promotionsrelated.Select(a => a.shopid)).Contains(c.id));
            }
            shoplist = queryshop.ToList();
        }

        void froe(List<string> s, string p)
        {
            foreach (var item in rows.Where(c => c.parentcode == p))
            {
                s.Add(item.areacode);
                froe(s, item.areacode);
            }
        }
        protected global::TREC.Web.aspx.ascx._AreaSelect txtarea;
        protected global::Wuqi.Webdiyer.AspNetPager pager;
        /// <summary>
        /// 新闻信息类
        /// </summary>
        protected class NewsInfo : Haojibiz.Model.Mnews
        {
            public int companyid { get; set; }
            public string companytitle { get; set; }
        }
    }
}
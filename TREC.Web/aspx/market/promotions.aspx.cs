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
    public class promotions : MarketPageBase
    {
        protected Dpromotions dpromotions = new Dpromotions();
        protected List<Mpromotions> list = new List<Mpromotions>();
        protected List<Mshop> shoplist = new List<Mshop>();
        public string tuijian = "";
        public string shangjia = "";
        public string adv = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showData();
            }
            pageTitle = "-" + marketInfo.title + "-促销信息";

            StringBuilder strb1 = new StringBuilder();
            List<t_advertising> listt_advertising = TREC.ECommerce.ECAdvertisement.AdvertisingList("   AND tg.id IN (37,38,39)  ");
            //卖场首页-右边推荐店铺
            List<t_advertising> list1 = listt_advertising.Where(x => x.categoryid == 39).Take(8).ToList();//"卖场促销资讯页-右边推荐店铺"
            //右边底部广告
            List<t_advertising> list2 = listt_advertising.Where(x => x.categoryid == 38).Take(1).ToList();//"卖场促销资讯页-右边底部广告"
            //卖场首页-右边优质商家
            List<t_advertising> list3 = listt_advertising.Where(x => x.categoryid == 37).Take(1).ToList();//"卖场促销资讯页-右边优质商家"

            int tjcount = 0;
            foreach (t_advertising item in list1)
            {
                tjcount++;
                strb1.Append("<a target='_blank' href='" + item.linkurl + "' >");
                //if (tjcount % 2 == 1)
                    strb1.Append("<img style='width: 196px; height: 70px;' src='" + item.imgurl + "'/></a>&nbsp;&nbsp;");
                //else
                //    strb1.Append("<img style='width: 110px; height: 80px;' src='" + item.imgurl + "'/></a>");
                //if (tjcount % 2 == 0 && tjcount != 0 && tjcount != list1.Count)
                //{
                    strb1.Append("<br />");
                //}

            }
            tuijian = strb1.ToString();


            //轮播广告
            strb1.Length = 0;
            foreach (t_advertising item in list2)
            {
                strb1.Append("<a href='" + item.linkurl + "' target='_blank'><img style='width: 240px; height: 170px;' src='" + item.imgurl + "' /></a>");
            }
            adv = strb1.ToString();

            //优质商家
            //adcode存储产品表id号码  根据id获取商家logo和简介
            strb1.Length = 0;
            if (list3.Count > 0)
            {
                System.Data.DataTable dt = TREC.ECommerce.ECommerce.GetTable(@" SELECT t_product.id,t_brand.companyid,t_company.descript,   t_brand.logo, brandid,t_brand.title as brandtitle,t_product.title
                        ,dbo.t_product.thumb,(SELECT TOP 1 saleprice  FROM t_productattribute WHERE productid = t_product.id  ) AS price  

                          FROM dbo.t_product 
                        INNER JOIN dbo.t_brand ON t_brand.id =  t_product.brandid
                        INNER JOIN dbo.t_company ON t_company.id = t_brand.companyid 
                         WHERE t_product.id= " + list3[0].adcode);

                if (dt.Rows.Count == 1)
                {

                    strb1.Append("<ul class='clearfix'>");
                    strb1.Append("<a target='_blank' href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/productinfo.aspx?id=" + dt.Rows[0]["id"] + "'>");
                    strb1.Append("<img  src='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/upload/product/thumb/" + dt.Rows[0]["id"] + "/" + dt.Rows[0]["thumb"] + "'");
                    strb1.Append("style='width: 223px; height: 165px;' /><br />");
                    strb1.Append("<p>" + dt.Rows[0]["title"] + "</p>");
                    strb1.Append("<p>");
                    strb1.Append("参考价：¥" + dt.Rows[0]["price"] + "</p>");
                    strb1.Append("</a>");
                    strb1.Append("</ul>");
                    strb1.Append("<table style='text-align:center' >");
                    strb1.Append("<tr>");
                    strb1.Append("<td valign='top'>");
                    strb1.Append("<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/company/" + dt.Rows[0]["companyid"] + "/brand-" + dt.Rows[0]["brandid"] + ".aspx' target='_blank'>");
                    strb1.Append("<img src='' style='height: 32px; width: 84px' />");
                    strb1.Append("</a>");
                    strb1.Append("</td>");
                    strb1.Append("<td valign='top'>");
                    strb1.Append("<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/company/" + dt.Rows[0]["companyid"] + "/brand-" + dt.Rows[0]["brandid"] + ".aspx' target='_blank'>");
                    strb1.Append("<label>");
                    strb1.Append(TRECommon.StringOperation.GetString(dt.Rows[0]["descript"].ToString(), 65, "..."));
                    strb1.Append("</label></a>");
                    strb1.Append("</td>");
                    strb1.Append("</tr>");
                    strb1.Append("</table>");
                }
                shangjia = strb1.ToString();
            }




        }
        void showData()
        {
            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);

            var query = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k }).Where(c => c.k.Where(m => m.marketid == marketInfo.id || dpromotions.LinqData<Mmarketstoreyshop>().Where(j => j.marketid == marketInfo.id && j.shopid == m.shopid).Any()).Any());
            if (ECommon.QuerySearchDisplay == "brand")
            {
                if (string.IsNullOrEmpty(ECommon.QuerySearchBrand))
                {
                    query = query.Where(c => c.k.Where(m => dpromotions.LinqData<Mmarketstoreyshop>().Where(j => j.marketid == marketInfo.id && j.shopid == m.shopid).Any()).Any());
                }
                else
                {
                    query = query.Where(c => c.k.Where(m => dpromotions.LinqData<Mmarketstoreyshop>().Where(j => j.marketid == marketInfo.id && j.shopid == m.shopid && dpromotions.LinqData<Mshopbrand>().Where(s => s.shopid == j.shopid && dpromotions.LinqData<Mbrand>().Where(p => p.id == s.brandid && (p.title.Contains(strqsb) || p.letter.Contains(strqsb))).Any()).Any()).Any()).Any());
                }
            }
            if (ECommon.QuerySearchDisplay == "market")
            {
                query = query.Where(c => c.k.Where(m => m.marketid == marketInfo.id).Any());
            }
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

        protected global::Wuqi.Webdiyer.AspNetPager pager;
    }
}
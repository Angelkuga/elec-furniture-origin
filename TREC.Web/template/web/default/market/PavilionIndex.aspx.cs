using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.DAL;
using Haojibiz.Model;
using Haojibiz.Data;
using System.Data.Linq;
using TREC.ECommerce;

namespace TREC.Web.template.web.market
{
    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using System.Text;
    using Haojibiz;
    #endregion

    public partial class PavilionIndex : MarketPageBase
	{
        public string sortTitle = "按&nbsp;名&nbsp;称";
        public string sortDate = "按&nbsp;时&nbsp;间";
        public string sortHot = "推荐店铺";
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        /// <summary>
        /// 下一页连接
        /// </summary>
        public string NextUrl
        {
            get
            {
                if (ECommon.QueryPageIndex == AspNetPager1.PageCount)
                {
                    return "#";

                }
                else
                {
                    return string.Format(EnUrls.MarketInfoBrandList, ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex + 1);
                }
            }
        }

        //上一页连接
        public string PrvUrl
        {
            get
            {
                if (ECommon.QueryPageIndex == 1)
                {
                    return "#";

                }
                else
                {
                    return string.Format(EnUrls.MarketInfoBrandList, ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex - 1);
                }
            }
        }
        public string getCompanyId(string shopid)
        {
            try
            {
                return elist.Where(p => p.shopid == SubmitMeth.getInt(shopid)).FirstOrDefault().BrandInfo.companyid;
            }
            catch
            {
                return "0";
            }
        }
        private List<EnArea> areaList = null;
        public List<EnArea> AreaList
        {
            get
            {
                if (areaList == null)
                {
                    var s = "";
                    foreach (var a in msslist.Select(c => c.shopareacode).Where(c => c != null && c != "").ToArray())
                    {
                        if (s != "")
                        {
                            s += ",";
                        }
                        s += "'" + a + "'";
                    }
                    areaList = ECArea.GetAreaList("areacode in(" + s + ")");
                }
                return areaList;
            }
        }
        public List<string> palist = new List<string>();
        public List<EnWebMarketStoreyShop> msslist = new List<EnWebMarketStoreyShop>();
        public List<EnWebMarketStoreyShop> elist = new List<EnWebMarketStoreyShop>();
        protected Dpromotions edpromotions = new Dpromotions();
        protected List<Mpromotions> epromotionslist = new List<Mpromotions>();

        List<EnWebAggregation> list = new List<EnWebAggregation>();
        public List<EnWebAggregation> searchHotKey = new List<EnWebAggregation>(); //搜索价位
        public List<EnWebAggregation> searchSpreadList = new List<EnWebAggregation>(); //搜索价位
        public List<EnWebAggregation> searchStyleList = new List<EnWebAggregation>(); //搜索价位
        public List<EnWebAggregation> searchMatialList = new List<EnWebAggregation>(); //搜索材质
        public List<EnWebAggregation> searchBrand = new List<EnWebAggregation>(); //搜索品牌
        public List<EnWebAggregation> searchMarket = new List<EnWebAggregation>(); //搜索卖场
        public List<EnWebAggregation> searchMarketPic = new List<EnWebAggregation>(); //搜索场场图文
        public List<EnWebAggregation> hotShopList = new List<EnWebAggregation>(); //关注经销商
        public List<EnWebAggregation> shopList = new List<EnWebAggregation>(); //销销商
        public List<EnWebAggregation> hotMarketList = new List<EnWebAggregation>(); //关注卖场
        public List<EnWebAggregation> marketList = new List<EnWebAggregation>(); //卖场列表 
        public List<EnWebAggregation> hotCompany = new List<EnWebAggregation>(); //关注厂家
        public List<EnWebAggregation> companyPicList = new List<EnWebAggregation>(); //优秀品牌厂家

        public List<Mpromotions> promotionslist = new MpromotionsCollection();
        public Dpromotions dpromotions = new Dpromotions();



        public string tuijian = "";
        public string shangjia = "";
        public string adv = "";
        public string cgdisplay = "";
        public string lcdisplay = "";

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
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            #region
            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);

            pageTitle = "-" + marketInfo.title + "-家具卖场-卖场品牌";

            string strWhere = " and storeyid!=0 and (marketid=" + marketInfo.id + ") and brandxml<>''";
            if (ECommon.QuerySearchMarketStorey != "")
            {
                strWhere += " and storeyid=" + ECommon.QuerySearchMarketStorey;
            }
            string brandname = "";
            if (ECommon.QuerySearchBrand != "")
            {

                strWhere += " and brandxml like '%" + strqsb + "%'";
            }
            else
            {
                if (ECommon.QuerySearchMaterial != "")
                {
                    int material = 0;
                    if (int.TryParse(ECommon.QuerySearchMaterial, out material))
                    {
                        strWhere += " and brandxml like '%<brandsmaterialvalue>" + material + "</brandsmaterialvalue>%'";
                    }
                    else
                    {
                        //foreach (EnBrand c in ECBrand.GetBrandList(" material in (select value from t_config where module=103 and type=4 and title like '%" + ECommon.QuerySearchMaterial + "%')"))
                        //{
                        //    brandname += c.title + ",";
                        //}
                        strWhere += " and brandxml like '%<brandsmaterialtitle>" + ECommon.QuerySearchMaterial + "</brandsmaterialtitle>%'";
                    }
                }
                if (ECommon.QuerySearchStyle != "")
                {
                    int style = 0;
                    if (int.TryParse(ECommon.QuerySearchStyle, out style))
                    {
                        strWhere += " and brandxml like '%<brandsstylevalue>" + style + "</brandsstylevalue>%'";
                    }
                    else
                    {
                        //foreach (EnBrand c in ECBrand.GetBrandList(" style in (select value from t_config where module=103 and type=3 and title like '%" + ECommon.QuerySearchStyle + "%')"))
                        //{
                        //    brandname += c.title + ",";
                        //}
                        strWhere += " and brandxml like '%<brandsstyletitle>" + ECommon.QuerySearchStyle + "</brandsstyletitle>%'";
                    }
                }



                if (brandname != "" && brandname != "" && brandname.Length > 0)
                {
                    strWhere += " and (";
                    string sw2 = "";
                    foreach (string s in brandname.Split(','))
                    {
                        if (s != null && s != "" && !sw2.Contains(" or  brandxml like '%<title>" + s + "</title>%' "))
                        {
                            sw2 += " or  brandxml like '%<title>" + s + "</title>%' ";
                        }
                    }

                    if (sw2.Length > 0)
                    {
                        sw2 = sw2.Substring(3, sw2.Length - 3);
                    }
                    strWhere += sw2;
                    strWhere += ")";
                }
            }

            string orderKey = "";
            string orderType = "";
            int pageCount = 0;
            #region 排序
            switch (ECommon.QuerySearchSort.ToLower())
            {
                case "_t1":
                    orderType = "desc";
                    orderKey = "shoptitle";
                    sortTitle = "名称升序";
                    break;
                case "_t2":
                    orderKey = "shoptitle";
                    orderType = "asc";
                    sortTitle = "名称排序";
                    break;
                case "_d1":
                    orderKey = "lastedittime";
                    orderType = "desc";
                    sortDate = "由近到远";
                    break;
                case "_d2":
                    orderKey = "lastedittime";
                    orderType = "asc";
                    sortDate = "由远到近";
                    break;
                case "_h1":
                    orderKey = "hits";
                    orderType = "desc";
                    sortHot = "由高到低";
                    break;
                case "_h2":
                    orderKey = "hits";
                    orderType = "asc";
                    sortHot = "由低到高";
                    break;
                default:
                    orderKey = "lastedittime";
                    orderType = "desc";
                    break;
            }

            #endregion

            strWhere = strWhere + " and pavilionid=" + paid;

            msslist = ECMarketStoreyShop.GetWebMarketStoreyShopList(1, int.MaxValue, strWhere, orderKey, orderType, out pageCount);
            elist = ECMarketStoreyShop.GetWebMarketStoreyShopList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, out pageCount);

            var shopids = elist.Select(c => c.shopid).ToArray();
            epromotionslist = edpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(edpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k })
                .Where(c => c.k.Where(s => shopids.Contains(s.shopid)).Any()).ToList().Select(c => new Mpromotions
                {
                    id = c.f.id,
                    title = c.f.title,
                    enddatetime = c.f.enddatetime,
                    IsTop = c.f.IsTop,
                    promotionsrelated = c.k.ToList()
                }).OrderByDescending(c => c.IsRecommend).ThenByDescending(c => c.IsTop).ToList();


            AspNetPager1.RecordCount = pageCount;
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern = string.Format(EnUrls.MarketInfoBrandList, ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, "{0}");

            list = ECAggregation.GetWebIndexAggregationListByParentIdList();
            searchHotKey = list.Where(x => x.type == 26).ToList();
            searchSpreadList = list.Where(x => x.type == 18).ToList();
            searchStyleList = list.Where(x => x.type == 19).ToList();
            searchMatialList = list.Where(x => x.type == 20).ToList();
            searchBrand = list.Where(x => x.type == 21).ToList();
            searchMarket = list.Where(x => x.type == 22).ToList();
            searchMarketPic = list.Where(x => x.type == 23).ToList();
            hotShopList = list.Where(x => x.type == 16).ToList();
            shopList = list.Where(x => x.type == 15).ToList();
            hotMarketList = list.Where(x => x.type == 11).ToList();
            marketList = list.Where(x => x.type == 10).ToList();
            hotCompany = list.Where(x => x.type == 8).ToList();
            companyPicList = list.Where(x => x.type == 7).ToList();
            pageTitle = "-" + marketInfo.title + "-家具卖场-首页";

            promotionslist = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1 && c.startdatetime > DateTime.Now && c.enddatetime > DateTime.Now).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>().Where(c => c.marketid == marketInfo.id), c => c.id, c => c.promotionsid, (f, k) => f).ToList();


            #endregion

            #region
            List<t_advertising> listt_advertising = TREC.ECommerce.ECAdvertisement.AdvertisingList("   AND tg.id IN (33,34,35)  ");
            //卖场首页-右边推荐店铺
            List<t_advertising> list1 = listt_advertising.Where(x => x.categoryid == 33).Take(8).ToList();//卖场首页-右边推荐店铺
            //右边底部广告
            List<t_advertising> list2 = listt_advertising.Where(x => x.categoryid == 35).Take(1).ToList();//"卖场首页-右边底部广告"
            //卖场首页-右边优质商家
            List<t_advertising> list3 = listt_advertising.Where(x => x.categoryid == 34).Take(1).ToList();//"卖场首页-右边优质商家"

            StringBuilder strb1 = new StringBuilder();

            int tjcount = 0;
            foreach (t_advertising item in list1)
            {
                tjcount++;
                strb1.Append("<a target='_blank' href='" + item.linkurl + "' >");
                //if(tjcount %2 ==1)
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
                strb1.Append("<a href='" + item.linkurl + "' target='_blank'><img style='width: 250px; height: 170px;' src='" + item.imgurl + "' /></a>");
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
                    strb1.Append("<p style=' padding:0 6px'>" + dt.Rows[0]["title"] + "</p>");
                    strb1.Append("<p style='padding:0 6px'>");
                    strb1.Append("参考价：¥" + dt.Rows[0]["price"] + "</p>");
                    strb1.Append("</a>");
                    strb1.Append("</ul>");
                    strb1.Append("<table style='text-align:center' >");
                    strb1.Append("<tr>");
                    strb1.Append("<td valign='top'   style='vertical-align:top; padding-left:6px;'>");
                    strb1.Append("<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/company/" + dt.Rows[0]["companyid"] + "/brand-" + dt.Rows[0]["brandid"] + ".aspx' target='_blank'>");
                    strb1.Append("<img src='' style='height: 32px; width: 84px' />");
                    strb1.Append("</a>");
                    strb1.Append("</td>");
                    strb1.Append("<td valign='top'   align='left' style=' padding-right6px;'>");
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
            #endregion

            t_Pavilion _pav = new t_Pavilion();
            _pav = EntityOper.t_Pavilion.Where(p => p.Id == SubmitMeth.getInt(paid)).FirstOrDefault();

            if (_pav != null)
            {
                cgimg = _pav.Bannel;
            }
        }

        public string cgimg = string.Empty;

        /// <summary>
        /// AspNetPager1 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
       // protected global::Wuqi.Webdiyer.AspNetPager AspNetPager1;
      
        protected string leftString(string s, int count)
        {
            if (s == null) return s;
            if (s.Length > count)
            {
                s = s.Substring(0, count) + ".";
            }
            return s;
        }
	}
}
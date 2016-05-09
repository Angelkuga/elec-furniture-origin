using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;

namespace TREC.Web.aspx.market
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion


    public partial class brand : MarketPageBase
    {

        public string sortTitle = "按&nbsp;名&nbsp;称";
        public string sortDate = "按&nbsp;时&nbsp;间";
        public string sortHot = "推荐店铺";

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
        public List<EnWebMarketStoreyShop> msslist = new List<EnWebMarketStoreyShop>();
        public List<EnWebMarketStoreyShop> list = new List<EnWebMarketStoreyShop>();
        protected Dpromotions dpromotions = new Dpromotions();
        protected List<Mpromotions> promotionslist = new List<Mpromotions>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);

            pageTitle = "-" + marketInfo.title + "-家具卖场-卖场品牌";

            string strWhere = " and storeyid!=0 and (marketid=" + marketInfo.id + ") ";
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



            msslist = ECMarketStoreyShop.GetWebMarketStoreyShopList(1, int.MaxValue, strWhere, orderKey, orderType, out pageCount);
            list = ECMarketStoreyShop.GetWebMarketStoreyShopList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, out pageCount);

            var shopids = list.Select(c => c.shopid).ToArray();
            promotionslist = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k })
                .Where(c => c.k.Where(s => shopids.Contains(s.shopid)).Any()).ToList().Select(c => new Mpromotions
                {
                    id = c.f.id,
                    title = c.f.title,
                    promotionsrelated = c.k.ToList()
                }).OrderByDescending(c => c.IsRecommend).ThenByDescending(c => c.IsTop).ToList();


            AspNetPager1.RecordCount = pageCount;
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern = string.Format(EnUrls.MarketInfoBrandList, ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, "{0}");
        }


        /// <summary>
        /// AspNetPager1 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::Wuqi.Webdiyer.AspNetPager AspNetPager1;
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
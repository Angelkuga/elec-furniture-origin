using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.Data;
using Haojibiz.DAL;
using Haojibiz.Model;

namespace TREC.Web.aspx
{
    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using System.Data;
    #endregion


    public partial class productlist : WebPageBase
    {
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
                    return string.Format(EnUrls.ProductListSearch, qsb, qss, qsm, ECommon.QuerySearchSpread, qsc, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory);
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
                    return string.Format(EnUrls.ProductListSearch, qsb, qss, qsm, ECommon.QuerySearchSpread, qsc, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex - 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory);
                }
            }
        }

        public string productkeywords = "家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌";
        public string productdescription = "家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！";
        public string productTitle = "";
        public string sortTitle = "按&nbsp;名&nbsp;称";
        public string sortDate = "按&nbsp;时&nbsp;间";
        public string sortHot = "推荐产品";
        public int NewCid = 0;
        public List<EnWebProduct> list = new List<EnWebProduct>();
        public List<EnWebProduct> newList = new List<EnWebProduct>();
        public string qsb = "";
        public string qss = "";
        public string qsm = "";
        public string qsc = "";
        public string sstr = "";
        private List<EnAggregation> recommendBrandList = null;
        public List<EnAggregation> RecommendBrandList
        {
            get
            {
                if (recommendBrandList == null)
                {
                    recommendBrandList = ECAggregation.GetAggregationList("type=40").ToList();
                }
                return recommendBrandList;
            }
        }
        public List<EnSearchItem> _Lst = new List<EnSearchItem>();
        public List<EnSearchItem> _lstP = new List<EnSearchItem>();
        protected LinqDataContext db = new LinqDataContext();
        protected List<Mpromotions> promotionslist = new List<Mpromotions>();
        //新参数
        public string[] letterIndex = { "ABCD", "EFG", "HIJK", "LMN", "OPQ", "RST", "UVW", "XYZ" };
        public string[] priceIndex = { "499以下", "500-1999元", "2000-4999元", "5000-9999元", "10000-29999元", "30000元以上" };
        public DataTable dtBrandLetterIndex = new DataTable();
        public DataTable dtMarketLetterIndex = new DataTable();
        public bool IsShowAllBrand = false;//是否有搜索的开关
        public List<int> brandIdList = new List<int>();
        public List<int> marketIdList = new List<int>();
        public List<int> brandList = new List<int>();
        public bool isfirstshow = false;
        public bool isclickabc = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            string strWhere = "";
            string bstrWhere = "";
            string brstrwhere = "";
            string bidWhere = "";
            bool blBrandSearch = false;
            //bool 

            #region 搜索条件


            string serachstyle = "";
            string bserachstyle = "";
            bool bstyle = false;
            if (ECommon.QuerySearchStyle != "")
            {
                if (ECommon.QuerySearchStyle.ToLower().Contains("_a"))
                {
                    qss = ECommon.QuerySearchStyle.Substring(0, ECommon.QuerySearchStyle.Length - 2);
                    bstyle = true;
                }
                else
                {
                    qss = ECommon.QuerySearchStyle;
                }

                string t = qss.StartsWith("_") ? qss.Substring(1, qss.Length - 1) : qss;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = t.Replace("_", ",");
                //strWhere += " and stylevalue in (" + t + ") ";
                //brstrwhere += " and style in (" + t + ") ";
                serachstyle = " and stylevalue in (" + t + ") ";
                bserachstyle = " and style in (" + t + ") ";
            }

            string serachmaterial = "";
            string bserachmaterial = "";
            bool bmaterial = false;
            if (ECommon.QuerySearchMaterial != "")
            {
                if (ECommon.QuerySearchMaterial.ToLower().Contains("_a"))
                {
                    qsm = ECommon.QuerySearchMaterial.Substring(0, ECommon.QuerySearchMaterial.Length - 2);
                    bmaterial = true;
                }
                else
                {
                    qsm = ECommon.QuerySearchMaterial;
                }

                string t = qsm.StartsWith("_") ? qsm.Substring(1, qsm.Length - 1) : qsm;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = t.Replace("_", ",");
                //strWhere += " and materialvalue in (" + t + ") ";
                //brstrwhere += " and material in (" + t + ") ";
                serachmaterial = " and materialvalue in (" + t + ") ";
                bserachmaterial = " and material in (" + t + ") ";
            }
            if (ECommon.QuerySearchSpread != "")
            {
                //string t = ECommon.QuerySearchSpread.StartsWith("_") ? ECommon.QuerySearchSpread.Substring(1, ECommon.QuerySearchSpread.Length - 1) : ECommon.QuerySearchSpread;
                //t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                //t = "'" + t.Replace("_", "','") + "'";
                //strWhere += " and brandid in ( select id from " + TableName.TBBrand + " where spread in (" + t + ") and linestatus=1) ";
                string[] t = ECommon.QuerySearchSpread.Split('_');
                string minprice = "";
                string maxprice = "";
                if (t.Length == 2)
                {
                    minprice = t[0].ToString();
                    maxprice = t[1].ToString();

                    strWhere += " and minPrice >= " + minprice + " ";
                    if (maxprice != "0")
                        strWhere += " and maxPrice <=" + maxprice + " ";
                }
            }
            if (ECommon.QuerySearchCategory != "")
            {
                NewCid = Convert.ToInt32(ECommon.QuerySearchCategory);
                strWhere += " and categoryid in (" + ECommon.QuerySearchCategory + ")";
                //brstrwhere += " and categoryid in (" + ECommon.QuerySearchCategory + ")";
            }

            if (ECommon.QuerySearchComposing != "" && ECommon.QuerySearchComposing == "recomm")
            {
                strWhere += " and attribute like '%102,%'";
                //brstrwhere += " and attribute like '%102,%'";
            }

            if (ECommon.QuerySearchKey != "")
            {
                string key = ECommon.QuerySearchKey.Replace("abc111", "-").Replace("cba222", "_");
                strWhere += " or (title like '%" + key + "%' or sku like '%" + key + "%' or brandtitle like '%" + key + "%')";
                //brstrwhere += " or (title like '%" + key + "%' or sku like '%" + key + "%' or brandtitle like '%" + key + "%')";
            }

            strWhere = strWhere != "" ? " and ( " + strWhere.Substring(4, strWhere.Length - 4) + " )" : "";

            if (ECommon.QueryType != "")
            {
                string str = "";
                foreach (string s in ECommon.QuerySearchType.Substring(1, ECommon.QuerySearchType.Length - 1).Split('_'))
                {
                    str += " or attributexml like '%<typevalue>" + ECommon.QuerySearchType + "</typevalue>%' ";
                }
                str = str != "" ? " and ( " + str.Substring(4, str.Length - 4) + " )" : "";

                strWhere += str;
                //brstrwhere += str;
            }
            string serachcolor = "";
            string bserachcolor = "";
            bool bcolor = false;
            if (ECommon.QuerySearchColor != "")
            {
                if (ECommon.QuerySearchColor.ToLower().Contains("_a"))
                {
                    qsc = ECommon.QuerySearchColor.Substring(0, ECommon.QuerySearchColor.Length - 2);
                    bcolor = true;
                }
                else
                {
                    qsc = ECommon.QuerySearchColor;
                }


                string t = qsc.Trim('_').Replace('_', ',');
                //strWhere += " and colorvalue  in(" + t + ")";
                //brstrwhere += " and color in (" + t + ") ";
                serachcolor = " and colorvalue  in(" + t + ")";
                bserachcolor = " and color in (" + t + ") ";
            }

            if (ECommon.QuerySearchBrand != "")
            {

                if (ECommon.QuerySearchBrand.ToLower().Contains("_a"))
                {
                    isfirstshow = true;

                    qsb = ECommon.QuerySearchBrand; //.Substring(0, ECommon.QuerySearchBrand.Length - 2);
                    sstr = ECommon.QuerySearchBrand.ToLower().Replace("_a", "").Replace("_", ",");

                }
                else if (ECommon.QuerySearchBrand.ToLower().Contains("_b"))
                {
                    isclickabc = true;
                    qsb = ECommon.QuerySearchBrand;
                    sstr = sstr = ECommon.QuerySearchBrand.ToLower().Replace("_b", "").Replace("_", ",");
                }
                else
                {
                    sstr = qsb = ECommon.QuerySearchBrand;
                    sstr = sstr.Replace("_", ",");
                }

                if (sstr.StartsWith(","))
                {
                    sstr = sstr.Substring(1, sstr.Length-1);
                }

                string t = sstr.StartsWith("_") ? sstr.Substring(1, qsb.Length - 1) : sstr;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = t.Replace("_", ",");
                //strWhere += " and brandid in (" + t + ") ";
                bstrWhere = " and brandid in (" + t + ") ";
                bidWhere = " and id in (" + t + ") ";
                blBrandSearch = true;
            }

            if (bcolor == false && bmaterial == false && bstyle == false)
            {
                strWhere = strWhere + serachstyle + serachmaterial + serachcolor;
                brstrwhere = brstrwhere + bserachstyle + bserachmaterial + bserachcolor;
            }
            if (bcolor == true)
            {
                strWhere = strWhere + serachcolor;
                brstrwhere = brstrwhere + bserachcolor;
            }
            if (bmaterial == true)
            {
                strWhere = strWhere + serachmaterial;
                brstrwhere = brstrwhere + bserachmaterial;
            }
            if (bstyle == true)
            {
                strWhere = strWhere + serachstyle;
                brstrwhere = brstrwhere + bserachstyle;
            }

            IsShowAllBrand = strWhere != "";
            #endregion

            #region 排序
            string orderType = "desc";
            string orderKey = "IsPay DESC,sortstr";
            switch (ECommon.QuerySearchSort.ToLower())
            {
                case "_t1":
                    orderType = "desc";
                    orderKey = "title";
                    sortTitle = "名称升序";
                    break;
                case "_t2":
                    orderKey = "title";
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
                    orderKey = "IsPay DESC,sortstr";
                    orderType = "desc";
                    break;
            }

            #endregion


            brandIdList = null; marketIdList = null;
            brandList = null;
            int pageCount = 0, newPageCount = 0;
            //list = ECProduct.GetWebProductList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, out pageCount);
            list = ECProduct.GetWebProductList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, bstrWhere, brstrwhere, bidWhere, blBrandSearch, isfirstshow, out pageCount, out brandList, out brandIdList, out marketIdList);


            



            var shopids = list.Select(c => Convert.ToInt32(c.ProductShopInfo.id)).ToArray();
            promotionslist = db.promotions.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(db.promotionsrelated, c => c.id, c => c.promotionsid, (f, k) => new { f, k }).Where(c => c.k.Any(f => f.shopid > 0 && shopids.Contains(f.shopid))).ToList()
                .Select(c => new Mpromotions
                {
                    id = c.f.id,
                    title = c.f.title,
                    letter = c.f.letter,
                    sort = c.f.sort,
                    lastedmtime = c.f.lastedmtime,
                    IsRecommend = c.f.IsRecommend,
                    promotionsrelated = c.k.ToList()
                }).OrderByDescending(c => c.IsRecommend).ThenByDescending(c => c.lastedmtime).ToList();

            newList = ECProduct.GetWebProductList(1, 3, string.Empty, "lastedittime", "desc", out newPageCount);
            AspNetPager1.RecordCount = pageCount;
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern = string.Format(EnUrls.ProductListSearch, qsb, qss, qsm, ECommon.QuerySearchSpread, qsc, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, "{0}", ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory);
            productTitle = "家具快搜 - 家具快搜产品频道";
            //SEO 
            if (ECommon.QuerySearchCategory != "")
            {
                EnProductCategory enp = ECProductCategory.GetProductCategoryInfo("where id=" + ECommon.QuerySearchCategory);
                if (enp != null && !string.IsNullOrEmpty(enp.keywords))
                {
                    if (!string.IsNullOrEmpty(enp.pagetitle))//title
                    {
                        productTitle = enp.pagetitle + " - 家具快搜产品频道";
                    }
                    if (!string.IsNullOrEmpty(enp.keywords))//keywords
                    {
                        productkeywords = enp.keywords;
                    }
                    if (!string.IsNullOrEmpty(enp.description))//description
                    {
                        productdescription = enp.description + " - 家具快搜产品频道";
                    }
                }
            }

            _lstP = ECProduct.GetSearchItem();
            _Lst = ECProduct.GetProductSearchTypeItemNew(NewCid);
            dtBrandLetterIndex = ECBrand.GetBrandLetterList();
            dtMarketLetterIndex = ECMarket.GetMarketLetterList();
        }

        /// <summary>
        /// AspNetPager1 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::Wuqi.Webdiyer.AspNetPager AspNetPager1;

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;

namespace TREC.Web.aspx.market
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using Haojibiz;
    #endregion


    public partial class product : MarketPageBase
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
                    return string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory);
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
                    return string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex - 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory);
                }
            }
        }

        public string sortTitle = "按&nbsp;名&nbsp;称";
        public string sortDate = "按&nbsp;时&nbsp;间";
        public string sortHot = "推荐产品";

        public List<EnWebProduct> list = new List<EnWebProduct>();
        public DataTable dtBrandLetterIndex = new DataTable();
        public string[] letterIndex = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };


        protected LinqDataContext db = new LinqDataContext();
        protected List<Mpromotions> promotionslist = new List<Mpromotions>();

        public string qsb="";

        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        public string getShopPosition(string id)
        {
            t_marketstoreyshop _shop = new t_marketstoreyshop();
            _shop = EntityOper.t_marketstoreyshop.Where(p => p.shopid == SubmitMeth.getInt(id)).FirstOrDefault();

            if (_shop != null)
            {
                string po = string.IsNullOrEmpty(_shop.position) ? "" : "<span style='float:right'>店铺位置：" + _shop.position + "</span>";
                return "<span style='float:left'>楼层：" + _shop.storeytitle + "</span>" + po;
            }
            else
            {
                return string.Empty;
            }
        }
        public string getShopTitle(List<ProductShop> _list)
        {
            if (_list == null || _list.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                ProductShop _pro = new ProductShop();

                _pro = _list.Where(p => p.marketid == marketInfo.id.ToString()).FirstOrDefault();

                if (_pro != null)
                {
                    return _pro.title;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int tmpPageCount;
       
            dtBrandLetterIndex = ECBrand.GetMarketBrandLetterList(marketInfo.id);
            string strWhere = " and brandid IN( SELECT brandid FROM t_shopbrand WHERE shopid IN(SELECT id FROM dbo.t_shop  WHERE marketid=" + marketInfo.id + ")) ";

            #region 搜索条件

            if (ECommon.QuerySearchBrand != "")
            {
                if (ECommon.QuerySearchBrand.ToLower().Contains("_a"))
                {
                    qsb = ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2);
                }
                else if (ECommon.QuerySearchBrand.ToLower().Contains("_b"))
                {
                    qsb = ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2);
                }
                else
                {
                    qsb = ECommon.QuerySearchBrand;
                }

                string t = qsb.StartsWith("_") ? qsb.Substring(1, qsb.Length - 1) : qsb;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = t.Replace("_", ",");
                strWhere += " and brandid in (" + t + ") ";
            }
            if (ECommon.QuerySearchStyle != "")
            {
                string t = ECommon.QuerySearchStyle.StartsWith("_") ? ECommon.QuerySearchStyle.Substring(1, ECommon.QuerySearchStyle.Length - 1) : ECommon.QuerySearchStyle;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = t.Replace("_", ",");
                strWhere += " and stylevalue in (" + t + ") ";
            }
            if (ECommon.QuerySearchMaterial != "")
            {
                string t = ECommon.QuerySearchMaterial.StartsWith("_") ? ECommon.QuerySearchMaterial.Substring(1, ECommon.QuerySearchMaterial.Length - 1) : ECommon.QuerySearchMaterial;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = t.Replace("_", ",");
                strWhere += " and materialvalue in (" + t + ") ";
            }
            if (ECommon.QuerySearchSpread != "")
            {
                string t = ECommon.QuerySearchSpread.StartsWith("_") ? ECommon.QuerySearchSpread.Substring(1, ECommon.QuerySearchSpread.Length - 1) : ECommon.QuerySearchSpread;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = "'" + t.Replace("_", "','") + "'";
                strWhere += " and brandid in ( select id from " + TableName.TBBrand + " where spread in (" + t + ") and linestatus=1) ";
            }
            if (ECommon.QuerySearchColor != "")
            {
                string t = ECommon.QuerySearchColor.StartsWith("_") ? ECommon.QuerySearchColor.Substring(1, ECommon.QuerySearchColor.Length - 1) : ECommon.QuerySearchColor;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = "'" + t.Replace("_", "','") + "'";
                strWhere += " and colorvalue in(" + t + ")";
            }
            if (ECommon.QuerySearchCategory != "")
            {
                strWhere += " and categoryid in (" + ECommon.QuerySearchCategory + ")";
            }

            strWhere = strWhere != "" ? " and ( " + strWhere.Substring(4, strWhere.Length - 4) + " )" : "";

            if (ECommon.QuerySearchComposing != "" && ECommon.QuerySearchComposing == "recomm")
            {
                strWhere += " and attribute like '%102,%'";
            }

            if (ECommon.QueryType != "")
            {
                string str = "";
                foreach (string s in ECommon.QuerySearchType.Substring(1, ECommon.QuerySearchType.Length - 1).Split('_'))
                {
                    str += " and attributexml like '%<typevalue>" + s + "</typevalue>%' ";
                }
                str = str != "" ? " and ( " + str.Substring(4, str.Length - 4) + " )" : "";

                strWhere += str;
            }
           // strWhere = strWhere == "" ? " and brandid in (select brandid from  t_shopbrand where shopid in (select shopid from t_marketstoreyshop where marketid=" + marketInfo.id + ") ) " : strWhere + " and brandid in (select brandid from  t_shopbrand where shopid in (select shopid from t_marketstoreyshop where marketid=" + marketInfo.id + ") ) ";


            #endregion

            #region 排序
            string orderType = "";
            string orderKey = "";
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
                    orderKey = "lastedittime";
                    orderType = "desc";
                    break;
            }

            #endregion


            //int pageCount = 0;
            list = ECProduct.GetWebProductList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, out tmpPageCount);

            var shopids = list.Select(c => Convert.ToInt32(c.ProductShopInfo.id)).ToArray();
            promotionslist = db.promotions.Where(c => c.IsRecommend && c.auditstatus == 1 && c.linestatus == 1).GroupJoin(db.promotionsrelated, c => c.id, c => c.promotionsid, (f, k) => new { f, k }).Where(c => c.k.Any(f => f.shopid > 0 && shopids.Contains(f.shopid))).ToList()
                .Select(c => new Mpromotions
                {
                    id = c.f.id,
                    title = c.f.title,
                    letter = c.f.letter,
                    sort = c.f.sort,
                    promotionsrelated = c.k.ToList()
                }).OrderByDescending(c => c.IsTop).ToList();

            AspNetPager1.RecordCount = tmpPageCount;
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern = string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, "{0}", ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory);
            pageTitle = "-" + marketInfo.title + "-全部产品";


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
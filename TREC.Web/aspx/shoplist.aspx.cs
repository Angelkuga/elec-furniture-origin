using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx
{
    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion

    public partial class shoplist :WebPageBase
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
                    string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    return string.Format(EnUrls.ShopListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1);
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
                    string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    return string.Format(EnUrls.ShopListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex - 1);
                }
            }
        }

        public string sortTitle = "按&nbsp;名&nbsp;称";
        public string sortDate = "按&nbsp;时&nbsp;间";
        public string sortHot = "推荐店铺";

        public List<EnWebShop> list = new List<EnWebShop>();


        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-经销商";
            string strWhere = "";
            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            if (strqsb != "")
            {
                foreach (string s in strqsb.Substring(1, strqsb.Length - 1).Split('_'))
                {
                    strWhere += " and brandxml like '%<id>" + s + "</id>%' ";
                }
            }
            if (ECommon.QuerySearchStyle != "")
            {
                foreach (string s in ECommon.QuerySearchStyle.Substring(1, ECommon.QuerySearchStyle.Length - 1).Split('_'))
                {
                    strWhere += " and brandxml like '%<stylevalue>" + s + "</stylevalue>%' ";
                }
            }
            if (ECommon.QuerySearchMaterial != "")
            {
                foreach (string s in ECommon.QuerySearchMaterial.Substring(1, ECommon.QuerySearchMaterial.Length - 1).Split('_'))
                {
                    strWhere += " and brandxml like '%<materialvalue>" + s + "</materialvalue>%' ";
                }
            }
            if (ECommon.QuerySearchSpread != "")
            {
                foreach (string s in ECommon.QuerySearchSpread.Substring(1, ECommon.QuerySearchSpread.Length - 1).Split('_'))
                {
                    strWhere += " and brandxml like '%<spreadvalue>" + s + "</spreadvalue>%' ";
                }
            }
            if (ECommon.QuerySearchStaffsize != "")
            {
                string t = ECommon.QuerySearchStaffsize.StartsWith("_") ? ECommon.QuerySearchStaffsize.Substring(1, ECommon.QuerySearchStaffsize.Length - 1) : ECommon.QuerySearchStaffsize;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = t.Replace("_", ",");
                strWhere += " and staffsize in (" + t + ") ";
            }
            if (ECommon.QuerySearchKey != "")
            {
                strWhere += " and title like '%" + ECommon.QuerySearchKey + "%' ";
            }

            strWhere = strWhere != "" ? " and ( " + strWhere.Substring(4, strWhere.Length - 4) + " )" : "";
            string orderType = "desc";
            string orderKey = "IsPay,sortstr";
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
            }

            list = ECShop.GetWebShopList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, out tmpPageCount);

            AspNetPager1.RecordCount = tmpPageCount;
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern = string.Format(EnUrls.ShopListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, "{0}");

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
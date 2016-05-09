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

    public partial class companybrandlist : WebPageBase
    {
        /// <summary>
        /// 下一页连接
        /// </summary>
        public string NextUrl
        {
            get
            {
                if (ECommon.QueryPageIndex  == AspNetPager1.PageCount)
                {
                    return "#";

                }
                else
                {
                    string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    return string.Format(EnUrls.CompanyBrandListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1);
                }
            }
        }

        //上一页连接
        public string PrvUrl
        {
            get
            {
                if (ECommon.QueryPageIndex==1)
                {
                    return "#";

                }
                else
                {
                    string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
                    return string.Format(EnUrls.CompanyBrandListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex - 1);
                }
            }
        }

        public string sortTitle = "按&nbsp;名&nbsp;称";
        public string sortDate = "按&nbsp;时&nbsp;间";
        public string sortHot = "推荐厂家";

        public List<EnWebCompanyBrand> list = new List<EnWebCompanyBrand>();

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
        public List<EnSearchItem> _Lst = new List<EnSearchItem>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-品牌工厂-按品牌";
            string strWhere = "";

            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);

            if (strqsb != "")
            {
                string t = strqsb.StartsWith("_") ? strqsb.Substring(1, strqsb.Length - 1) : strqsb;
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
                t = t.Replace("_", ",");
                strWhere += " and spreadvalue in (" + t + ") ";
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
                string key = ECommon.QuerySearchKey.Replace("abc111", "-").Replace("cba222", "_");
                strWhere += " and title+brandtitle like '%" + key + "%' ";
            }

            strWhere = strWhere != "" ? " and ( " + strWhere.Substring(4, strWhere.Length - 4) + " )" : "";
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
            _Lst = ECCompany.GetSearchItem();
            list = ECCompany.GetWebCompanyBrandList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, out tmpPageCount);
            AspNetPager1.RecordCount = tmpPageCount;
            AspNetPager1.EnableUrlRewriting = true;

            AspNetPager1.UrlRewritePattern = string.Format(EnUrls.CompanyBrandListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, "{0}");

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
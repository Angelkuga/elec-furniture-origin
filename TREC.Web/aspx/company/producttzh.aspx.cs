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


    public partial class producttzh : CompanyPageBase
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


                    string postname = ECommon.QuerySearchPostName;
                    string brands = ECommon.QuerySearchBrands;
                    if (!string.IsNullOrEmpty(brands))
                    {
                        return string.Format(EnUrls.CompanyInfoProductListBrands, ECommon.QueryCId, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory, postname, brands);
                    }
                    else if (!string.IsNullOrEmpty(postname))
                    {
                        return string.Format(EnUrls.CompanyInfoProductListPost, ECommon.QueryCId, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory, postname);
                    }
                    else
                    {
                        return string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory);
                    }
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


                    string postname = ECommon.QuerySearchPostName;
                    string brands = ECommon.QuerySearchBrands;
                    if (!string.IsNullOrEmpty(brands))
                    {
                        return string.Format(EnUrls.CompanyInfoProductListBrands, ECommon.QueryCId, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory, postname, brands);
                    }
                    else if (!string.IsNullOrEmpty(postname))
                    {
                        return string.Format(EnUrls.CompanyInfoProductListPost, ECommon.QueryCId, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex - 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory, postname);
                    }
                    else
                    {
                        return string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex - 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory);
                    }
                }
            }
        }

        public string sortTitle = "按&nbsp;名&nbsp;称";
        public string sortDate = "按&nbsp;时&nbsp;间";
        public string sortHot = "推荐产品";
        public List<EnWebProduct> list = new List<EnWebProduct>();
        protected LinqDataContext db = new LinqDataContext();
        protected List<Mpromotions> promotionslist = new List<Mpromotions>();
        protected List<EnSearchProductItem> _list = new List<EnSearchProductItem>();

        public System.Data.DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ECommon.QueryCId == "" || ECommon.QueryCId == "0")
            {
                Response.Redirect(ECommon.WebUrl);
            }
            pageTitle = "-" + companyInfo.title + "-家具产品";
            string strWhere = "";
            #region 搜索条件

            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);


            if (strqsb != "")
            {
                string t = strqsb.StartsWith("_") ? strqsb.Substring(1, strqsb.Length - 1) : strqsb;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = t.Replace("_", ",");
                strWhere += " and brandid in (" + t + ") ";
                outstrWhere += " and brandid in (" + t + ") ";
            }
            if (ECommon.QuerySearchStyle != "")
            {
                string t = ECommon.QuerySearchStyle.StartsWith("_") ? ECommon.QuerySearchStyle.Substring(1, ECommon.QuerySearchStyle.Length - 1) : ECommon.QuerySearchStyle;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = t.Replace("_", ",");
                strWhere += "and stylevalue in (" + t + ") ";
                outstrWhere += "and stylevalue in (" + t + ") ";
            }
            if (ECommon.QuerySearchMaterial != "")
            {
                string t = ECommon.QuerySearchMaterial.StartsWith("_") ? ECommon.QuerySearchMaterial.Substring(1, ECommon.QuerySearchMaterial.Length - 1) : ECommon.QuerySearchMaterial;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = t.Replace("_", ",");
                strWhere += " and materialvalue in (" + t + ") ";
                outstrWhere += " and materialvalue in (" + t + ") ";
            }
            if (ECommon.QuerySearchSpread != "")
            {
                string t = ECommon.QuerySearchSpread.StartsWith("_") ? ECommon.QuerySearchSpread.Substring(1, ECommon.QuerySearchSpread.Length - 1) : ECommon.QuerySearchSpread;
                t = t.EndsWith("_") ? t.Substring(0, t.Length - 1) : t;
                t = "'" + t.Replace("_", "','") + "'";
                strWhere += " and brandid in ( select id from " + TableName.TBBrand + " where spread in (" + t + ") and linestatus=1) ";
                outstrWhere += " and brandid in ( select id from " + TableName.TBBrand + " where spread in (" + t + ") and linestatus=1) ";
            }
            CompanyPageBase.setvalue = "-1";
            if (ECommon.QuerySearchCategory != "")
            {
                CompanyPageBase.setvalue = ECommon.QuerySearchCategory;
                strWhere += " and categoryid in (" + ECommon.QuerySearchCategory + ")";
            }

            if (ECommon.QuerySearchPCategory != "")
            {
                strWhere += " and categoryid in (select id from t_productcategory where parentid=" + ECommon.QuerySearchPCategory + ")";
            }

            strWhere = strWhere != "" ? " and ( " + strWhere.Substring(4, strWhere.Length - 4) + " )" : "";
            outstrWhere = outstrWhere != "" ? " and ( " + outstrWhere.Substring(4, outstrWhere.Length - 4) + " )" : "";

            if (ECommon.QuerySearchComposing != "" && ECommon.QuerySearchComposing == "recomm")
            {
                strWhere += " and attribute like '%102,%'";
                outstrWhere += " and attribute like '%102,%'";
            }

            if (ECommon.QueryType != "")
            {
                string str = "";
                foreach (string s in ECommon.QuerySearchType.Substring(1, ECommon.QuerySearchType.Length - 1).Split('_'))
                {
                    str += " or attributexml like '%<typevalue>" + s + "</typevalue>%' ";
                }
                str = str != "" ? " and ( " + str.Substring(3, str.Length - 3) + " )" : "";

                strWhere += str;
                outstrWhere += str;
            }

            //模糊搜索_Post
            string PostName = ECommon.QuerySearchPostName;
            if (!string.IsNullOrEmpty(PostName))
            {
                string _str = " AND (";
                int i_s = 0;
                foreach (string s in PostName.Split('_'))
                {
                    if (string.IsNullOrEmpty(s))
                    {
                        continue;
                    }
                    if (i_s == 0)
                    {
                        _str += " materialname like '%" + s + "%' or brandtitle like '%" + s + "%' or categorytitle like '%" + s + "%' or sku like '%" + s + "%'";
                    }
                    else
                    {
                        _str += " or materialname like '%" + s + "%' or brandtitle like '%" + s + "%' or categorytitle like '%" + s + "%' or sku like '%" + s + "%'";
                    }
                    i_s++;
                }
                _str += ")";
                strWhere += _str;
                outstrWhere += _str;

            }
            string brandids = ECommon.QuerySearchBrands;
            if (!string.IsNullOrEmpty(brandids))
            {
                strWhere += " and brandsid = " + brandids;
                outstrWhere += " and brandsid =" + brandids;
            }
            strWhere = strWhere == " companyid=" + ECommon.QueryCId ? "" : strWhere + " and companyid=" + ECommon.QueryCId;
            outstrWhere = outstrWhere == " companyid=" + ECommon.QueryCId ? "" : outstrWhere + " and companyid=" + ECommon.QueryCId;


            #endregion

            #region 排序
            string orderType = "desc";
            string orderKey = "FID";
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
                    orderKey = "sort desc,lastedittime";
                    orderType = "desc";
                    break;
            }

            #endregion


            //int pageCount = 0;
            list = ECProduct.GetWebProductList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, out tmpPageCount);

            _list = ECProduct.GetProductSearchItemByCompanyIdNew(Utils.GetIntForString(ECommon.QueryCId), "", "").Where(x => x.type == "brand").ToList();

            var shopids = list.Select(c => Convert.ToInt32(c.ProductShopInfo.id)).ToArray();
            promotionslist = db.promotions.Where(c => c.IsRecommend && c.auditstatus == 1 && c.linestatus == 1 && c.startdatetime.Date >= DateTime.Now.Date && c.enddatetime.Date >= DateTime.Now.Date).GroupJoin(db.promotionsrelated.Where(c => shopids.Contains(c.shopid)), c => c.id, c => c.promotionsid, (f, k) => new { f, k }).Where(c => c.k.Any(f => f.shopid > 0 && shopids.Contains(f.shopid))).ToList()
               .Select(c => new Mpromotions
               {
                   id = c.f.id,
                   title = c.f.title,
                   letter = c.f.letter,
                   sort = c.f.sort,
                   promotionsrelated = c.k.ToList()
               }).OrderByDescending(c => c.IsTop).ToList();



            string sql = @"SELECT colorid, ISNULL(sh.title,'') AS shoptitle,gp.gpId,gp.no,gp.Name AS gpname,gp.brandid,gp.thumb
,gp.shopid,gp.companyid,gtype,price,fengge.title AS fgtitle,caizhi.title AS caizhititle,dbo.t_brand.title AS btitle  ,
gp.seriesid ,t_brands.title AS bstitle,sh.address
 FROM dbo.GroupProduct gp 
INNER JOIN dbo.t_config fengge ON fengge.value = gp.styleId AND fengge.type=3 AND fengge.module=103
INNER JOIN dbo.t_config caizhi ON caizhi.value = gp.MaterialId AND caizhi.type=4  AND caizhi.module=103
INNER JOIN dbo.t_config yanse ON yanse.value = gp.ColorId AND yanse.type=12  AND yanse.module=103
INNER JOIN dbo.t_brand ON t_brand.id = gp.brandId AND t_brand.auditstatus =1 
INNER JOIN t_Brands ON t_Brands.id = gp.seriesid
INNER JOIN dbo.t_productcategory tpg2 ON tpg2.id = gp.bigCateId   AND tpg2.linestatus=1
INNER JOIN dbo.t_shop sh ON sh.id = gp.ShopId   AND (sh.auditstatus =1  OR sh.auditstatus IS NULL)  
INNER JOIN dbo.t_company ON t_company.id = gp.companyid AND t_company.auditstatus = 1 
 
WHERE gp.Status =1  
AND gp.companyid =" + ECommon.QueryCId;


             dt = TREC.ECommerce.ECommerce.GetTable(sql);


            //分页



            AspNetPager1.RecordCount = dt.Rows.Count;



            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern = string.Format(EnUrls.CompanyInfoProductListBrandstzh, ECommon.QueryCId, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, "{0}", ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory, ECommon.QuerySearchPostName, brandids);
            pageTitle = "-产品";

            hass.Add("7", ECProduct.GetWebProductList(1, 1, (outstrWhere != "" ? outstrWhere + " and " : "") + " categoryid in(select id from t_productcategory where parentid=7)", "", "", out outi).Count > 0 ? true.ToString() : false.ToString());
            hass.Add("9", ECProduct.GetWebProductList(1, 1, (outstrWhere != "" ? outstrWhere + " and " : "") + " categoryid in(select id from t_productcategory where parentid=9)", "", "", out outi).Count > 0 ? true.ToString() : false.ToString());
            hass.Add("10", ECProduct.GetWebProductList(1, 1, (outstrWhere != "" ? outstrWhere + " and " : "") + " categoryid in(select id from t_productcategory where parentid=10)", "", "", out outi).Count > 0 ? true.ToString() : false.ToString());
            hass.Add("11", ECProduct.GetWebProductList(1, 1, (outstrWhere != "" ? outstrWhere + " and " : "") + " categoryid in(select id from t_productcategory where parentid=11)", "", "", out outi).Count > 0 ? true.ToString() : false.ToString());
            hass.Add("12", ECProduct.GetWebProductList(1, 1, (outstrWhere != "" ? outstrWhere + " and " : "") + " categoryid in(select id from t_productcategory where parentid=12)", "", "", out outi).Count > 0 ? true.ToString() : false.ToString());




        }

       

        /// <summary>
        /// AspNetPager1 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::Wuqi.Webdiyer.AspNetPager AspNetPager1;
        protected int outi = 0;
        protected string outstrWhere = "";
        protected System.Collections.Specialized.NameValueCollection hass = new System.Collections.Specialized.NameValueCollection();
    }
}
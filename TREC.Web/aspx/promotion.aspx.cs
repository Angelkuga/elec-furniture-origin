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


    public partial class promotion : WebPageBase
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
                {//cid=$1^sid=$2^pid=$3^bid=$4^mkid=$5^area=$6^stime=$7^etime=$8^sort=$9^key=$10^page=$11
                    return string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime, ECommon.QuerySearchSort, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1);
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
                    return string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime, ECommon.QuerySearchSort, ECommon.QuerySearchKey, ECommon.QueryPageIndex - 1);
                }
            }
        }

        public string sortTitle = "按&nbsp;名&nbsp;称";
        public string sortDate = "按&nbsp;时&nbsp;间";
        public string sortHot = "推荐活动";
        public List<EnWebPromotion> list = new List<EnWebPromotion>();


        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-活动促销";
            string strWhere = "";
            //if (ECommon.QuerySearchBrand != "")
            //{
            //    foreach (string s in ECommon.QuerySearchBrand.Substring(1, ECommon.QuerySearchBrand.Length - 1).Split('_'))
            //    {
            //        strWhere += " and brandxml like '%<id>" + s + "</id>%' ";
            //    }
            //}
            
            //strWhere = strWhere != "" ? " and ( " + strWhere.Substring(4, strWhere.Length - 4) + " )" : "";


            if (ECommon.QuerySearchKey != "")
            {
                strWhere += " and (title like '%" + ECommon.QuerySearchKey + "%')";
            }

            strWhere = strWhere != "" ? " and ( " + strWhere.Substring(4, strWhere.Length - 4) + " )" : "";
            string orderType = "desc";
            string orderKey = "sort";
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


            int pageCount = 0;
            list = ECPromotion.GetWebPromotionList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, out pageCount);
            AspNetPager1.RecordCount = pageCount;
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern = string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime, ECommon.QuerySearchSort, ECommon.QuerySearchKey, "{0}");

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
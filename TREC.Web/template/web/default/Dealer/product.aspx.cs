using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using System.Text;
using Haojibiz.DAL;
using Haojibiz.Model;
using TREC.Web.Code;

namespace TREC.Web.template.web.Dealer
{
    public partial class product : DealerPageBase
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
                        return string.Format(EnUrls.DealerInfoProductListBrands, getdid, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory, postname, brands);
                    }
                    else if (!string.IsNullOrEmpty(postname))
                    {
                        return string.Format(EnUrls.DealerInfoProductListPost, getdid, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory, postname);
                    }
                    else
                    {
                        return string.Format(EnUrls.DealerInfoProductList, getdid, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory);
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
                        return string.Format(EnUrls.DealerInfoProductListBrands, getdid, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex + 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory, postname, brands);
                    }
                    else if (!string.IsNullOrEmpty(postname))
                    {
                        return string.Format(EnUrls.DealerInfoProductListPost, getdid, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex - 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory, postname);
                    }
                    else
                    {
                        return string.Format(EnUrls.DealerInfoProductList, getdid, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex - 1, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory);
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


        public string getdid
        {
            get
            {
                if (Request["did"] != null)
                {
                    return Request["did"];
                }
                else
                {
                    return "0";
                }
            }
        }
        public string createMid = "0";
        public string getBgcolor(string brandid)
        {
            if (Request["brand"] == brandid)
            {
                return "background-color:#FFE6BD;color:#000000;";
            }
            else
            {
                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (DealerInfor != null)
            {
                createMid = DealerInfor.mid.ToString();
            }
            string strWhere = " and createMid=" + createMid + " and  (ShopID=0 or ShopID is null) ";
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

           // strWhere =" createMid=" + createMid;
            outstrWhere = " and createMid=" + createMid;

            if (Request["tid"] != null)
            {
                strWhere = strWhere + " and id in(SELECT productid FROM t_productattribute WHERE ProductAttributePromotion=" + Request["tid"] + ")";
            }
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


            int tmpPageCount = 0;
            //int pageCount = 0;
            list = ECProduct.GetWebProductList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, orderKey, orderType, out tmpPageCount);

            _list = ECProduct.GetProductSearchItemByCreatemIdNew(SubmitMeth.getInt(createMid), "", "").Where(x => x.type == "brand").ToList();

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

            AspNetPager1.RecordCount = tmpPageCount;
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern = string.Format(EnUrls.DealerInfoProductListBrands, getdid, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, "{0}", ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory, ECommon.QuerySearchPostName, brandids);
        

            hass.Add("7", ECProduct.GetWebProductList(1, 1, (outstrWhere != "" ? outstrWhere + " and " : "") + " categoryid in(select id from t_productcategory where parentid=7)", "", "", out outi).Count > 0 ? true.ToString() : false.ToString());
            hass.Add("9", ECProduct.GetWebProductList(1, 1, (outstrWhere != "" ? outstrWhere + " and " : "") + " categoryid in(select id from t_productcategory where parentid=9)", "", "", out outi).Count > 0 ? true.ToString() : false.ToString());
            hass.Add("10", ECProduct.GetWebProductList(1, 1, (outstrWhere != "" ? outstrWhere + " and " : "") + " categoryid in(select id from t_productcategory where parentid=10)", "", "", out outi).Count > 0 ? true.ToString() : false.ToString());
            hass.Add("11", ECProduct.GetWebProductList(1, 1, (outstrWhere != "" ? outstrWhere + " and " : "") + " categoryid in(select id from t_productcategory where parentid=11)", "", "", out outi).Count > 0 ? true.ToString() : false.ToString());
            hass.Add("12", ECProduct.GetWebProductList(1, 1, (outstrWhere != "" ? outstrWhere + " and " : "") + " categoryid in(select id from t_productcategory where parentid=12)", "", "", out outi).Count > 0 ? true.ToString() : false.ToString());

        }

        /*
         
           _dicprice.Add("市场参考价", double.Parse(dt.Rows[0]["markprice"].ToString()));
                _dicprice.Add("销售价", double.Parse(dt.Rows[0]["saleprice"].ToString()));
                _dicprice.Add("促销价", double.Parse(dt.Rows[0]["buyprice"].ToString())); 
         */
        public string GetPrice(string markprice, string saleprice, string buyprice, string proid)
        {
            double markprice0;
            double saleprice0;
            double buyprice0;

            double.TryParse(markprice, out markprice0);
            double.TryParse(saleprice, out saleprice0);
            double.TryParse(buyprice, out buyprice0);

            StringBuilder _value = new StringBuilder(string.Empty);
            Dictionary<string, double> _dicprice = new Dictionary<string, double>();


            if (markprice0 > 0)
            {
                _dicprice.Add("市场参考价", markprice0);
            }
            if (saleprice0 > 0)
            {
                _dicprice.Add("销售价", saleprice0);
            }
            if (buyprice0 > 0)
            {
                _dicprice.Add(ECProduct.CheckbuypriceName(proid), buyprice0);
            }
            int i = 0;
            string css = string.Empty;
            _value.Append("<div class=\"sycp4\">");
            foreach (var item in _dicprice)
            {
                if (i == 0)
                {
                    _value.Append("" + item.Key + "：¥" + item.Value);
                }
                else if (i == 1)
                {
                    _value.Append("<div>" + item.Key + "：¥" + item.Value + "</div> <br>");
                }
                else if (i == 2)
                {
                    _value.Append("<div style=\"float:left;\">" + item.Key + "：<span>¥" + item.Value + "</span></div>");
                }
                i++;


            }
            _value.Append("</div>");
            //if (_dicprice.Count == 3)
            //{
            //    _value.Append("<div class=\"sycp4\">市场参考价：¥" + _dicprice["市场参考价"] + " <div>市场价：¥" + _dicprice["销售价"] + "</div> <br />   <div style=\"float:left;\">销售价：<span>¥" + _dicprice["促销价"] + "</span></div>  </div>");
            //}

            //if (_dicprice.Count == 2)
            //{
            //    string k="促销价";
            //    if(saleprice0>0)
            //    {
            //       k ="销售价";
            //    }

            //    if (markprice0 > 0)
            //    {
            //        _value.Append("<div class=\"sycp4\">市场参考价：¥" + markprice + "<div>" + k + "：<span>¥" + _dicprice[k] + "</span></div></div>");
            //    }
            //    else
            //    {
            //        _value.Append("<div class=\"sycp4\">销售价：¥" + saleprice + "<div>促销价：<span>¥" + buyprice + "</span></div></div>");
            //    }
            //}

            //if (_dicprice.Count == 1)
            //{
            //    string k = "促销价";
            //    if (saleprice0 > 0)
            //    {
            //        k = "销售价";
            //    }

            //    if (markprice0 > 0)
            //    {
            //        _value.Append("<div class=\"sycp4\">市场参考价：¥" + markprice + "<div><span></span></div></div>");
            //    }
            //    else
            //    {
            //        _value.Append("<div class=\"sycp4\"><div>" + k + "：<span>¥" + _dicprice[k] + "</span></div></div>");
            //    }
            //}

            return _value.ToString();

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
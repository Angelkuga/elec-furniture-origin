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


    public partial class search : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = "";
            string key = "";
            string brand = "";
            string market = "";
            string material = "";
            string style = "";

            if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() != "")
            {
                type = Request.QueryString["type"].ToString();
                type = type.StartsWith("-") ? type.Substring(1, type.Length - 1) : type;
            }

            if (Request.QueryString["key"] != null && Request.QueryString["key"].ToString() != "")
            {
                key = Request.QueryString["key"].ToString();
                key = key.StartsWith("-") ? key.Substring(1, key.Length - 1) : key;
            }

            if (Request.QueryString["hybrand"] != null && Request.QueryString["hybrand"].ToString() != "")
            {
                brand = Request.QueryString["hybrand"].ToString();
                brand = brand.StartsWith("-") ? brand.Substring(1, brand.Length - 1) : brand;
                brand = brand.Replace(" ", "+");
            }
            if (Request.QueryString["hymarket"] != null && Request.QueryString["hymarket"].ToString() != "")
            {
                market = Request.QueryString["hymarket"].ToString();
                market = market.StartsWith("-") ? market.Substring(1, market.Length - 1) : market;
                market = market.Replace(" ", "+");
            }
            if (Request.QueryString["hymaterial"] != null && Request.QueryString["hymaterial"].ToString() != "")
            {
                material = Request.QueryString["hymaterial"].ToString();
                material = material.StartsWith("-") ? material.Substring(1, material.Length - 1) : material;
                material = material.Replace(" ", "+");
            }
            if (Request.QueryString["hystyle"] != null && Request.QueryString["hystyle"].ToString() != "")
            {
                style = Request.QueryString["hystyle"].ToString();
                style = style.StartsWith("-") ? style.Substring(1, style.Length - 1) : style;
                style = style.Replace(" ", "+");
            }
            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            switch (type)
            {
                case "brand": //品牌
                    if (key == "")
                    {
                        key = brand;
                    }
                    key = key.Replace("-", "abc111").Replace("_", "cba222");
                    if (material != "")
                    {
                        var tt = ECConfig.GetConfigInfo("where type = 4 and title = '" + material + "'");
                        if (tt != null)
                        {
                            material = "_" + tt.value;
                        }
                        else
                        {
                            material = "";
                        }
                    }
                    if (style != "")
                    {
                        var tt = ECConfig.GetConfigInfo("where type = 3 and title = '" + style + "'");
                        if (tt != null)
                        {
                            style = "_" + tt.value;
                        }
                        else
                        {
                            style = "";
                        }
                    }
                    Response.Redirect(WebUtils.ResolveUrl("~" + string.Format(EnUrls.CompanyBrandListSearch, strqsb, ECommon.QuerySearchStyle + style, ECommon.QuerySearchMaterial + material, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, key, ECommon.QueryPageIndex)));
                    break;
                case "distributor": //经销商
                    key = key.Replace("-", "abc111").Replace("_", "cba222");
                    Response.Redirect(WebUtils.ResolveUrl("~" + string.Format(EnUrls.ShopListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, key, ECommon.QueryPageIndex)));
                    break;
                case "product": //产品
                    key = key.Replace("-", "abc111").Replace("_", "cba222");
                    Response.Redirect(WebUtils.ResolveUrl("~" + string.Format(EnUrls.ProductListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, key, ECommon.QueryPageIndex, "", ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory)));
                    break;
                case "market": //卖场
                    if (brand == "" && material == "" && style == "")
                    {
                        if (market != "")
                        {
                            var i = market.IndexOf("(");
                            if (i > -1)
                            {
                                var r = market.Substring(i, market.Length - i);
                                market = market.Replace(r, "");
                            }
                        }
                        key = ECommon.QuerySearchKey + market;
                        key = key.Replace("-", "abc111").Replace("_", "cba222");
                        Response.Redirect(WebUtils.ResolveUrl("~" + string.Format(EnUrls.MarketListSearch, strqsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, key, ECommon.QueryPageIndex, ECommon.QuerySearchArea)));
                    }
                    else
                    {
                        int marketid = 0;
                        string strWhere = "";
                        if (int.TryParse(market, out marketid))
                        {
                            strWhere = "where id=" + marketid;
                        }
                        else
                        {
                            strWhere = "where title='" + market + "'";
                        }
                        var tt = ECMarket.GetMarketInfo(strWhere);
                        if (tt != null)
                        {
                            var url = WebUtils.ResolveUrl("~" + HttpContext.Current.Server.UrlDecode(string.Format("/market/brand.aspx?mid={0}&brand={1}&style={2}&material={3}", tt.id, brand, style, material)));
                            Response.Redirect(url);
                        }
                        else
                        {
                            Response.Write("<script>alert('要重写向的路径无法确定！')</script>");
                        }
                    }
                    break;
                case "information": //资讯
                    key = ECommon.QuerySearchKey;
                    key = key.Replace("-", "abc111").Replace("_", "cba222");
                    Response.Redirect(WebUtils.ResolveUrl("~" + string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime, ECommon.QuerySearchSort, key, ECommon.QueryPageIndex)));
                    break;
                case "marketshop":
                    key = key.Replace("-", "abc111").Replace("_", "cba222");
                    Response.Redirect(WebUtils.ResolveUrl("~" + string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, "", "", "", key, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial)));
                    break;
            }
        }
    }
}
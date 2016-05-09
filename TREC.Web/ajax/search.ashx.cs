using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using TREC.Entity;
using TREC.ECommerce;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;

namespace TREC.Web.ajax
{
    /// <summary>
    /// search 的摘要说明
    /// </summary>
    public class search : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("[");
            //context.Response.Write("{value:'奥巴玛',label:' <font class=\"auto_E15A00\">[品牌]</font> 奥巴玛',redirecturl:'http://baidu.com/'}");
            //context.Response.Write(",{value:'爱凡 书桌 田园风格 板式 家具',label:'爱凡 书桌 <font class=\"auto_BDBDBD\">田园风格</font> <font class=\"auto_BDBDBD\">板式</font> <font class=\"auto_BDBDBD\">家具</font><div class=\"auto_BDBDBD auto_item_right\">货号：QY81701A</div>',redirecturl:'http://qq.com/'}");
            //context.Response.Write(",{value:'爱凡 书桌 田园风格 板式 家具',label:'爱凡 书桌 <font class=\"auto_BDBDBD\">田园风格</font> <font class=\"auto_BDBDBD\">板式</font> <font class=\"auto_BDBDBD\">家111具</font><div class=\"auto_BDBDBD auto_item_right\">货号：QY81701A</div>',redirecturl:'http://qq.com/'}");
            //context.Response.Write(",{value:'爱凡 书桌 田园风格 板式 家具',label:'爱凡 书桌 <font class=\"auto_BDBDBD\">田园风格</font> <font class=\"auto_BDBDBD\">板式</font> <font class=\"auto_BDBDBD\">家222222具</font><div class=\"auto_BDBDBD auto_item_right\">货号：QY81701A</div>',redirecturl:'http://qq.com/'}");
            //context.Response.Write(",{value:'爱凡 书桌 田园风格 板式 家具',label:'爱凡 书桌 <font class=\"auto_BDBDBD\">田园风格</font> <font class=\"auto_BDBDBD\">板式</font> <font class=\"auto_BDBDBD\">家具</font><div class=\"auto_BDBDBD auto_item_right\">货号：QY81701A</div>',redirecturl:'http://qq.com/'}");
            //context.Response.Write("]");
            //context.Response.End();
            var key = context.Request.QueryString["key"];
            var type = context.Request.QueryString["type"];
            if (!string.IsNullOrEmpty(key))
            {
                key = key.Replace("%2b", "+").Trim();
            }
            if (!string.IsNullOrEmpty(key))
            {
                type = type.Trim();
            }
            switch (type.ToLower())
            {
                case "product":
                    SearchProduct(key);
                    break;
                case "company":
                    SearchCompany(key);
                    break;
                case "brand":
                    SearchBrand(key);
                    break;
                case "distributor":
                    SearchDistributor(key);
                    break;
                case "market":
                    SearchMarket(key);
                    break;
                case "information":
                    SearchInformation(key);
                    break;
                case "hybrand":
                    SearchhyBrand(key);
                    break;
                case "hymarket":
                    SearchhyMarket(key);
                    break;
                case "hymaterial":
                    SearchhyMaterial(key);
                    break;
                case "hystyle":
                    SearchhyStyle(key);
                    break;
                case "onlybrnad":
                    OnlyBrand(key);
                    break;
                case "onlymarket":
                    OnlyMarket(key);
                    break;
                case "onlymarketshop":
                    OnlyMarketShop(key);
                    break;
                case "getarealist":
                    GetAreaList();
                    break;
              
            }
        }

    
        LinqDataContext db = new LinqDataContext();
        /// <summary>
        /// 作者：李祥
        /// 日期：2012/6/6 21:00
        /// 说明：改用 LinqToSql 方式
        /// </summary>
        /// <param name="key"></param>
        void SearchProduct(string key)
        {
            //List<string> slist = new List<string>();
            //DataTable dtBrand = ExcuteSelect("select top 1 id,companyid,title from t_brand where auditstatus=1 and linestatus=1 and( title='" + key + "' or letter='" + key + "')");
            //if (dtBrand != null && dtBrand.Rows.Count > 0)
            //{
            //    slist.Add("{value:'" + (string)dtBrand.Rows[0]["title"] + "',label:' <font class=\"auto_E15A00\">[品牌]</font> " + ((string)dtBrand.Rows[0]["title"]).Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>") + "',redirecturl:'" + string.Format(EnUrls.CompanyInfoBrandList, dtBrand.Rows[0]["companyid"], dtBrand.Rows[0]["id"]) + "'}");
            //}
            //DataTable dtMateria = ExcuteSelect("select distinct materialvalue,materialname from t_product where auditstatus=1 and linestatus=1 and materialname like '%" + key + "%' order by materialname");
            //if (dtMateria != null && dtMateria.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dtMateria.Rows)
            //    {
            //        slist.Add("{value:'" + (string)dr["materialname"] + "',label:' <font class=\"auto_BDBDBD\">[选材]</font> " + ((string)dr["materialname"]).Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>") + "',redirecturl:'" + string.Format(EnUrls.ProductListSearch, "", "", "_" + dr["materialvalue"], "", "", "", "", "", "1", "", "", "") + "'}");
            //    }
            //}
            //DataTable dtStyle = ExcuteSelect("select distinct stylevalue,stylename from t_product where auditstatus=1 and linestatus=1 and stylename like '%" + key + "%' order by stylename");
            //if (dtStyle != null && dtStyle.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dtStyle.Rows)
            //    {
            //        slist.Add("{value:'" + (string)dr["stylename"] + "',label:' <font class=\"auto_BDBDBD\">[风格]</font> " + ((string)dr["stylename"]).Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>") + "',redirecturl:'" + string.Format(EnUrls.ProductListSearch, "", "_" + dr["stylevalue"], "", "", "", "", "", "", "1", "", "", "") + "'}");
            //    }
            //}
            //DataTable dtProduct = ExcuteSelect("select top 30 id,brandtitle,sku,materialname,categorytitle,stylename from t_product where auditstatus=1 and linestatus=1 and( brandtitle like '%" + key + "%' or categorytitle like '%" + key + "%' or stylename like '%" + key + "%' or materialname like '%" + key + "%' or sku like '%" + key + "%')");
            //if (dtProduct != null && dtProduct.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dtProduct.Rows)
            //    {
            //        var redirecturl = string.Format(EnUrls.ProductInfo, dr["id"]);
            //        var brandtitle = (string)dr["brandtitle"];
            //        var categorytitle = (string)dr["categorytitle"];
            //        var stylename = (string)dr["stylename"];
            //        var materialname = (string)dr["materialname"];
            //        var sku = (string)dr["sku"];
            //        slist.Add("{" + string.Format("value:'{0} {1} {2} {3} 家具',label:'{4} {5} <font class=\"auto_BDBDBD\">{6}</font> <font class=\"auto_BDBDBD\">{7}</font> <font class=\"auto_BDBDBD\">家具</font><div class=\"auto_BDBDBD auto_item_right\">货号：{8}</div>',redirecturl:'{9}'", brandtitle, categorytitle, stylename, materialname, brandtitle.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"), categorytitle.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"), stylename.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"), materialname.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"), sku.Replace(key.ToUpper(), "<strong class=\"auto_BD182D\">" + key.ToUpper() + "</strong>"), redirecturl) + "}");
            //    }
            //}
            //StringBuilder sb = new StringBuilder();
            //foreach (var item in slist)
            //{
            //    sb.Append(item + ",");
            //}
            //Response.Write("[");
            //Response.Write(sb.ToString().Trim(','));
            //Response.Write("]");
            //Response.End();






            var queryB = (db.brand.Where(c => c.auditstatus == 1 && c.linestatus == 1 && (c.title == key || c.letter == key)).Select(c => new
            {
                value = c.title,
                label = " <font class=\"auto_E15A00\">[品牌]</font> " + c.title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"),
                redirecturl = string.Format(EnUrls.CompanyInfoIndex, c.companyid)
            })).ToList();
            var queryM = db.product.Where(c => c.auditstatus == 1 && c.linestatus == 1 && c.materialname.Contains(key)).Distinct().OrderBy(c => c.materialname).Select(c => new
            {
                value = c.materialname,
                label = " <font class=\"auto_BDBDBD\">[选材]</font> " + c.materialname.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"),
                redirecturl = string.Format(EnUrls.ProductListSearch, "", "", "_" + c.materialvalue, "", "", "", "", "", "1", "", "", "")
            }).Distinct().ToList();
            var queryS = db.product.Where(c => c.auditstatus == 1 && c.linestatus == 1 && c.stylename.Contains(key)).Distinct().OrderBy(c => c.stylename).Select(c => new
            {
                value = c.stylename,
                label = " <font class=\"auto_BDBDBD\">[风格]</font> " + c.stylename.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"),
                redirecturl = string.Format(EnUrls.ProductListSearch, "", "_" + c.stylevalue, "", "", "", "", "", "", "1", "", "", "")
            }).Distinct().ToList();
            var queryP = db.product.Where(c => c.auditstatus == 1 && c.linestatus == 1 && (c.brandtitle.Contains(key) || c.categorytitle.Contains(key) || c.stylename.Contains(key) || c.materialname.Contains(key) || c.sku.Contains(key))).Select(c => new
            {
                value = string.Format("{0} {1} {2} {3} 家具", c.brandtitle, c.categorytitle, c.stylename, c.materialname),
                label = string.Format("{0} {1} <font class=\"auto_BDBDBD\">{2}</font> <font class=\"auto_BDBDBD\">{3}</font> <font class=\"auto_BDBDBD\">家具</font><div class=\"auto_BDBDBD auto_item_right\">货号：{4}</div>", c.brandtitle.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"), c.categorytitle.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"), c.stylename.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"), c.materialname.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>"), c.sku.Replace(key.ToUpper(), "<strong class=\"auto_BD182D\">" + key.ToUpper() + "</strong>")),
                redirecturl = string.Format(EnUrls.ProductInfo, c.id)
            }).Distinct().Take(30).ToList();
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            var list = queryB.Union(queryM).Union(queryS).Union(queryP).ToList();
            string s = js.Serialize(list);
            Response.Write(s);
            Response.End();
        }
        /// <summary>
        /// Author:rafer
        /// Date  :2012-5-3
        /// 搜索厂家
        /// </summary>
        /// <param name="key"></param>
        void SearchCompany(string key)
        {
            DataTable dtCompany = ExcuteSelect("select title from t_company where auditstatus=1 and linestatus=1 title like '%" + key + "%' order by title");
            StringBuilder sb = new StringBuilder();
            string temp = "<li class=\"li_Calss\">{0}</li>";
            foreach (DataRow item in dtCompany.Rows)
            {
                sb.Append(string.Format(temp, item["title"].ToString()));
            }
            Response.Write(sb.ToString());
            Response.End();
        }
        void SearchBrand(string key)
        {
            List<string> slist = new List<string>();
            DataTable dtBrand = ExcuteSelect("select id,companyid,title from t_brand where auditstatus=1 and linestatus=1 and (title like '%" + key + "%' or letter like '%" + key + "%')");
            List<int> fullmatchs = new List<int>();
            if (dtBrand.Rows.Count > 0)
            {
                foreach (DataRow dr in dtBrand.Rows)
                {
                    var title = (string)dr["title"];
                    slist.Add("{value:'" + title + "',label:' <font class=\"auto_E15A00\">[品牌]</font> " + title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>") + "',redirecturl:'" + string.Format(EnUrls.CompanyInfoIndex, dr["companyid"]) + "'}");
                    if (key == title)
                    {
                        fullmatchs.Add((int)dr["id"]);
                    }
                }
            }
            if (fullmatchs.Any())
            {
                var brandidjoin = "";
                foreach (int i in fullmatchs)
                    brandidjoin += i.ToString() + ",";
                DataTable dtShopbrand = ExcuteSelect("select t_shop.id,t_shop.template,t_shop.title,t_area.areaname from t_shop left join t_area on t_shop.areacode = t_area.areacode where t_shop.auditstatus=1 and t_shop.linestatus=1 and t_shop.id in (select shopid from t_shopbrand where brandid in (" + brandidjoin.TrimEnd(',') + "))");
                if (dtShopbrand.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtShopbrand.Rows)
                    {
                        var title = (string)dr["title"];
                        var redirecturl = "";
                        if (dr["template"] == null || dr["template"].ToString() == "0")
                        {
                            redirecturl = string.Format(EnUrls.ShopInfoIndex2, dr["id"]);
                        }
                        else
                        {
                            redirecturl = string.Format(EnUrls.ShopInfoIndex, dr["id"]);
                        }
                        slist.Add("{value:'" + title + "',label:' <font class=\"auto_FFC445\">[店铺]</font> " + title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>") + "<div class=\"auto_BDBDBD auto_item_right\">" + dr["areaname"] + "</div>',redirecturl:'" + redirecturl + "'}");
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in slist)
            {
                sb.Append(item + ",");
            }
            Response.Write("[");
            Response.Write(sb.ToString().Trim(','));
            Response.Write("]");
            Response.End();
        }
        void SearchDistributor(string key)
        {
            Response.Write("[");
            Response.Write("]");
            Response.End();
        }
        void SearchMarket(string key)
        {
            List<string> slist = new List<string>();
            DataTable dtMarket = ExcuteSelect("select t_market.id,t_market.template,t_market.title,t_area.areaname from t_market left join t_area on t_market.areacode = t_area.areacode where auditstatus=1 and linestatus=1 and (title like '%" + key + "%' or letter like '%" + key + "%')");
            List<int> fullmatchs = new List<int>();
            if (dtMarket.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMarket.Rows)
                {
                    var title = (string)dr["title"];
                    var redirecturl = "";
                    if (dr["template"] == null || dr["template"].ToString() == "0")
                    {
                        redirecturl = string.Format(EnUrls.MarketInfoIndex2, dr["id"]);
                    }
                    else
                    {
                        redirecturl = string.Format(EnUrls.MarketInfoIndex, dr["id"]);
                    }
                    slist.Add("{value:'" + title + "',label:' <font class=\"auto_1B899D\">[卖场]</font> " + title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>") + "<div class=\"auto_BDBDBD auto_item_right\">" + dr["areaname"] + "</div>',redirecturl:'" + redirecturl + "'}");
                    if (key == title)
                    {
                        fullmatchs.Add((int)dr["id"]);
                    }
                }
            }
            if (fullmatchs.Any())
            {
                var marketidjoin = "";
                foreach (int i in fullmatchs)
                    marketidjoin += i.ToString();
                DataTable dtMarketstoreyshop = ExcuteSelect("select t_shop.id,t_shop.template,t_shop.title,t_area.areaname from t_shop left join t_area on t_shop.areacode = t_area.areacode where t_shop.auditstatus=1 and t_shop.linestatus=1 and t_shop.id in (select shopid from t_marketstoreyshop where marketid in (" + marketidjoin.TrimEnd(',') + "))");
                if (dtMarketstoreyshop.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtMarketstoreyshop.Rows)
                    {
                        var title = (string)dr["title"];
                        var redirecturl = "";
                        if (dr["template"] == null || dr["template"].ToString() == "0")
                        {
                            redirecturl = string.Format(EnUrls.ShopInfoIndex2, dr["id"]);
                        }
                        else
                        {
                            redirecturl = string.Format(EnUrls.ShopInfoIndex, dr["id"]);
                        }
                        slist.Add("{value:'" + title + "',label:' <font class=\"auto_FFC445\">[店铺]</font> " + title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>") + "<div class=\"auto_BDBDBD auto_item_right\">" + dr["areaname"] + "</div>',redirecturl:'" + redirecturl + "'}");
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in slist)
            {
                sb.Append(item + ",");
            }
            Response.Write("[");
            Response.Write(sb.ToString().Trim(','));
            Response.Write("]");
            Response.End();
        }
        void SearchInformation(string key)
        {
            Response.Write("[");
            Response.Write("]");
            Response.End();
        }
        void SearchhyBrand(string key)
        {
            string hybrand = Request.QueryString["hybrand"];
            string hymarket = Request.QueryString["hymarket"];
            string hymaterial = Request.QueryString["hymaterial"];
            string hystyle = Request.QueryString["hystyle"];
            string strSql = "select title,letter from t_brand where auditstatus=1 and linestatus=1 and (title !='' and title like '%" + key + "%' or letter like '%" + key + "%')";
            if (!string.IsNullOrEmpty(hymarket))
            {
                hymarket = hymarket.Replace("%2b", "+");
                string strSql1 = "select brandid from t_shopbrand where shopid in(select shopid from t_marketstoreyshop where markettitle like '%" + hymarket + "%')";
                strSql += " and id in(" + strSql1 + ")";
            }
            if (!string.IsNullOrEmpty(hymaterial))
            {
                hymaterial = hymaterial.Replace("%2b", "+");
                string strSql2 = "select brandid from t_product where auditstatus=1 and linestatus=1 materialname like '%" + hymaterial + "%'";
                strSql += " and id in(" + strSql2 + ")";
            }
            if (!string.IsNullOrEmpty(hystyle))
            {
                hystyle = hystyle.Replace("%2b", "+");
                string strSql3 = "select brandid from t_product where auditstatus=1 and linestatus=1 stylename like '%" + hystyle + "%'";
                strSql += " and id in(" + strSql3 + ")";
            }
            strSql += " order by letter";
            List<string> slist = new List<string>();
            DataTable dtBrand = ExcuteSelect(strSql);
            if (dtBrand.Rows.Count > 0)
            {
                foreach (DataRow dr in dtBrand.Rows)
                {
                    var title = dr["title"].ToString();
                    var letter = dr["letter"].ToString();
                    if (key.Length > 0)
                        title = title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>");
                    if (!string.IsNullOrEmpty(letter))
                        letter = letter.ToUpper()[0].ToString() + " ";
                    slist.Add("{value:'" + dr["title"].ToString() + "',label:'" + " " + letter + title + "'}");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in slist)
            {
                sb.Append(item + ",");
            }
            Response.Write("[");
            Response.Write(sb.ToString().Trim(','));
            Response.Write("]");
            Response.End();
        }
        void SearchhyMarket(string key)
        {
            string hybrand = Request.QueryString["hybrand"];
            string hymarket = Request.QueryString["hymarket"];
            string hymaterial = Request.Params["hymaterial"];
            string hystyle = Request.QueryString["hystyle"];
            string strSqlBrandWhere = "";
            if (!string.IsNullOrEmpty(hybrand))
            {
                hybrand = hybrand.Replace("%2b", "+");
                strSqlBrandWhere += "brandid in (select id from t_brand where auditstatus=1 and linestatus=1 and (title like '%" + hybrand + "%' or letter like '%" + hybrand + "%'))";
            }
            if (!string.IsNullOrEmpty(hymaterial))
            {
                hymaterial = hymaterial.Replace("%2b", "+");
                if (strSqlBrandWhere.Length > 0)
                {
                    strSqlBrandWhere += " and ";
                }
                strSqlBrandWhere += "brandid in (select brandid from t_product where auditstatus=1 and linestatus=1 materialname like '%" + hymaterial + "%')";
            }
            if (!string.IsNullOrEmpty(hystyle))
            {
                hystyle = hystyle.Replace("%2b", "+");
                if (strSqlBrandWhere.Length > 0)
                {
                    strSqlBrandWhere += " and ";
                }
                strSqlBrandWhere += "brandid in (select brandid from t_product where auditstatus=1 and linestatus=1 stylename like '%" + hystyle + "%')";
            }
            string strSql = "select title,letter from t_market where auditstatus=1 and linestatus=1 and title !='' and title like '%" + key + "%'";
            if (!string.IsNullOrEmpty(strSqlBrandWhere))
            {
                strSql += " and id in(select marketid from t_marketstoreyshop where shopid in (select shopid from t_shopbrand where " + strSqlBrandWhere + "))";
            }
            strSql += " order by letter";
            List<string> slist = new List<string>();
            DataTable dtMarket = ExcuteSelect(strSql);
            if (dtMarket.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMarket.Rows)
                {
                    var title = dr["title"].ToString();
                    var letter = dr["letter"].ToString();
                    if (key.Length > 0)
                        title = title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>");
                    if (!string.IsNullOrEmpty(letter))
                        letter = letter.ToUpper()[0].ToString() + " ";
                    slist.Add("{value:'" + dr["title"].ToString() + "',label:'" + " " + letter + title + "'}");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in slist)
            {
                sb.Append(item + ",");
            }
            Response.Write("[");
            Response.Write(sb.ToString().Trim(','));
            Response.Write("]");
            Response.End();
        }
        void SearchhyMaterial(string key)
        {
            string hybrand = Request.QueryString["hybrand"];
            string hymarket = Request.QueryString["hymarket"];
            string hymaterial = Request.QueryString["hymaterial"];
            string hystyle = Request.QueryString["hystyle"];
            string strSql = "select title from t_config where type = 4 and title != '' and title like '%" + key + "%'";
            if (!string.IsNullOrEmpty(hybrand))
            {
                hybrand = hybrand.Replace("%2b", "+");
                strSql += " and value in (select materialvalue from t_product where auditstatus=1 and linestatus=1 exists(select null as [empty] from t_brand where t_brand.id=t_product.brandid and t_brand.auditstatus=1 and t_brand.linestatus=1 and (title like '%" + hybrand + "%' or letter like '%" + hybrand + "%')))";
            }
            if (!string.IsNullOrEmpty(hymarket))
            {
                hymarket = hymarket.Replace("%2b", "+");
                strSql += " and value in (select materialvalue from t_product where auditstatus=1 and linestatus=1 brandid in (select brandid from t_shopbrand where shopid in (select shopid from t_marketstoreyshop where markettitle like '%" + hymarket + "%')))";
            }
            if (!string.IsNullOrEmpty(hystyle))
            {
                hystyle = hystyle.Replace("%2b", "+");
                strSql += " and value in (select materialvalue from t_product where auditstatus=1 and linestatus=1 stylename like '%" + hystyle + "%')";
            }
            List<string> slist = new List<string>();
            DataTable dtMaterial = ExcuteSelect(strSql);
            if (dtMaterial.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMaterial.Rows)
                {
                    var title = dr["title"].ToString();
                    if (key.Length > 0)
                        title = title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>");
                    slist.Add("{value:'" + dr["title"].ToString() + "',label:'" + " " + title + "'}");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in slist)
            {
                sb.Append(item + ",");
            }
            Response.Write("[");
            Response.Write(sb.ToString().Trim(','));
            Response.Write("]");
            Response.End();
        }
        void SearchhyStyle(string key)
        {
            string hybrand = Request.QueryString["hybrand"];
            string hymarket = Request.QueryString["hymarket"];
            string hymaterial = Request.QueryString["hymaterial"];
            string hystyle = Request.QueryString["hystyle"];
            string strSql = "select title from t_config where type = 3 and title != '' and title like '%" + key + "%'";
            if (!string.IsNullOrEmpty(hybrand))
            {
                hybrand = hybrand.Replace("%2b", "+");
                strSql += " and value in (select stylevalue from t_product where auditstatus=1 and linestatus=1 exists(select null as [empty] from t_brand where t_brand.id=t_product.brandid and t_brand.auditstatus=1 and t_brand.linestatus=1 and (title like '%" + hybrand + "%' or letter like '%" + hybrand + "%')))";
            }
            if (!string.IsNullOrEmpty(hymarket))
            {
                hymarket = hymarket.Replace("%2b", "+");
                strSql += " and value in (select stylevalue from t_product where auditstatus=1 and linestatus=1 brandid in (select brandid from t_shopbrand where shopid in (select shopid from t_marketstoreyshop where markettitle like '%" + hymarket + "%')))";
            }
            if (!string.IsNullOrEmpty(hymaterial))
            {
                hymaterial = hymaterial.Replace("%2b", "+");
                strSql += " and value in (select stylevalue from t_product where auditstatus=1 and linestatus=1 materialname like '%" + hymaterial + "%')";
            }

            List<string> slist = new List<string>();
            DataTable dtStyle = ExcuteSelect(strSql);
            if (dtStyle.Rows.Count > 0)
            {
                foreach (DataRow dr in dtStyle.Rows)
                {
                    var title = dr["title"].ToString();
                    if (key.Length > 0)
                        title = title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>");
                    slist.Add("{value:'" + dr["title"].ToString() + "',label:'" + " " + title + "'}");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in slist)
            {
                sb.Append(item + ",");
            }
            Response.Write("[");
            Response.Write(sb.ToString().Trim(','));
            Response.Write("]");
            Response.End();
        }
        void OnlyBrand(string key)
        {
            List<string> slist = new List<string>();
            DataTable dtBrand = ExcuteSelect("select id,title,letter from t_brand where auditstatus=1 and linestatus=1 and (title like '%" + key + "%' or letter like '" + key + "%')");
            List<int> fullmatchs = new List<int>();
            if (dtBrand.Rows.Count > 0)
            {
                foreach (DataRow dr in dtBrand.Rows)
                {
                    var title = dr["title"].ToString();
                    var letter = dr["letter"].ToString();
                    if (letter.Length > 0)
                        letter = letter[0].ToString().ToUpper() + " ";
                    slist.Add("{value:'" + title + "',label:' " + letter + title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>") + "'}");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in slist)
            {
                sb.Append(item + ",");
            }
            Response.Write("[");
            Response.Write(sb.ToString().Trim(','));
            Response.Write("]");
            Response.End();
        }
        void OnlyMarket(string key)
        {
            List<string> slist = new List<string>();
            DataTable dtMarket = ExcuteSelect("select t_market.id,t_market.title,t_market.letter from t_market where auditstatus=1 and linestatus=1 and (title like '%" + key + "%' or letter like '" + key + "%')");
            if (dtMarket.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMarket.Rows)
                {
                    var title = dr["title"].ToString();
                    var letter = dr["letter"].ToString();
                    if (letter.Length > 0)
                        letter = letter[0].ToString().ToUpper() + " ";
                    slist.Add("{value:'" + title + "',label:' " + letter + title.Replace(key, "<strong class=\"auto_BD182D\">" + key + "</strong>") + "'}");
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in slist)
            {
                sb.Append(item + ",");
            }
            Response.Write("[");
            Response.Write(sb.ToString().Trim(','));
            Response.Write("]");
            Response.End();
        }
        void OnlyMarketShop(string key)
        {
            string strWhere = " and (marketid=" + Request.QueryString["mid"] + ") ";
            if (ECommon.QuerySearchMarketStorey != "")
            {
                strWhere += " and storeyid=" + ECommon.QuerySearchMarketStorey;
            }
            string brandname = key;

            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            if (strqsb != "")
            {

                strWhere += " and brandxml like '%" + strqsb + "%'";
            }
            else
            {
                if (ECommon.QuerySearchMaterial != "")
                {
                    foreach (EnBrand c in ECBrand.GetBrandList(" material in (select value from t_config where module=103 and type=4 and title like '%" + ECommon.QuerySearchMaterial + "%')"))
                    {
                        brandname += c.title + ",";
                    }


                }
                if (ECommon.QuerySearchStyle != "")
                {
                    foreach (EnBrand c in ECBrand.GetBrandList(" style in (select value from t_config where module=103 and type=3 and title like '%" + ECommon.QuerySearchStyle + "%')"))
                    {
                        brandname += c.title + ",";
                    }

                }



                if (brandname != "" && brandname != "" && brandname.Length > 0)
                {
                    strWhere += " and (";
                    string sw2 = "";
                    foreach (string s in brandname.Split(','))
                    {
                        if (s != null && s != "" && !sw2.Contains(" or  brandxml like '%" + s + "%' "))
                        {
                            sw2 += " or  brandxml like '%" + s + "%' ";
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

            var list = ECMarketStoreyShop.GetWebMarketStoreyShopList(1, int.MaxValue, strWhere, orderKey, orderType, out pageCount);
            var slist = list.Select(c => new { item = "{\"value\":\"" + c.BrandInfo.title + "\",\"label\":\"" + (c.BrandInfo.letter.Length > 0 ? c.BrandInfo.letter[0].ToString().ToUpper() + " " : "") + c.BrandInfo.title + "\"}" }).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var a in slist)
            {
                sb.Append(a.item + ",");
            }
            Response.Write("[");
            Response.Write(sb.ToString().Trim(','));
            Response.Write("]");
            Response.End();
        }
        void GetAreaList()
        {
            Darea darea = new Darea();
            var parenId = Request.QueryString["areaId"];
            var areaList = darea.Linq.Where(c => c.parentcode == parenId).Select(c => new { c.areaname, c.areacode, haschild = darea.Linq.Any(f => f.parentcode == c.areacode) });
            StringBuilder sb = new StringBuilder();
            foreach (var item in areaList)
            {
                if (sb.Length > 0)
                {
                    sb.Append("|");
                }
                sb.AppendFormat("{0}|{1}${2}", item.areaname, item.areacode, Convert.ToByte(item.haschild).ToString());
            }
            Response.Write(sb.ToString());
        }
        public HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }
        public HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public DataTable ExcuteSelect(string strSql)
        {
            return ExcuteSelect(strSql, null);
        }
        public DataTable ExcuteSelect(string strSql, SqlParameter[] parameter)
        {
            SqlConnection sqlConn = Haojibiz.Data.SqlHelper.NewConnection;
            SqlCommand sqlComm = sqlConn.CreateCommand();
            try
            {
                sqlConn.Open();
                sqlComm.CommandText = strSql;
                if (parameter != null)
                {
                    sqlComm.Parameters.AddRange(parameter);
                }
                DataTable dt = new DataTable();
                using (SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlComm))
                {
                    sqlAdp.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlComm.Parameters.Clear();
                    sqlComm.Dispose();
                    sqlConn.Close();
                }
            }
        }
    }
}
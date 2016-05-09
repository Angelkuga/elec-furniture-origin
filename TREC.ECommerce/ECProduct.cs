using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TREC.Entity;
using TREC.Data;
using TRECommon;
using System.Collections;


namespace TREC.ECommerce
{
    public class ECProduct
    {


        public static int ExitProductSku(string sku)
        {
            return Products.ExitBrandSku(sku);
        }

        public static List<EnSearchProductItem> GetProductSearchItemByCompanyId(int companyid)
        {
            return Products.GetProductSearchItem(" companyid=" + companyid+" ");
        }

        /// <summary>
        /// add: rafer
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
        public static List<EnSearchProductItem> GetProductSearchItemByCompanyIdNew(int companyid, string brandid, string brandsid)
        {
            string sql = " companyid=" + companyid + " and (shopid=0 or shopid is null)";
            if (!string.IsNullOrEmpty(brandid))
            {
                sql += "  and brandid= " + brandid;
            }
            if (!string.IsNullOrEmpty(brandsid))
            {
                sql += "  and brandsid= " + brandsid;
            }
            return Products.GetProductSearchItem(sql);
        }


        public static List<EnSearchProductItem> GetProductSearchItemByCreatemIdNew(int createmid, string brandid, string brandsid)
        {
           // string sql = " createmid=" + createmid;
            string sql = "";
            if (!string.IsNullOrEmpty(brandid))
            {
                sql += "  and brandid= " + brandid;
            }
            if (!string.IsNullOrEmpty(brandsid))
            {
                sql += "  and brandsid= " + brandsid;
            }
            return Products.GetProductSearchItemByCreateMid(sql, createmid.ToString());
        }


          public static List<EnSearchProductItem> GetProductSearchItemByCompanyIdNew2(int companyid, string brandid, string brandsid)
        {
            string sql = " companyid=" + companyid;
            if (!string.IsNullOrEmpty(brandid))
            {
                sql += "  and brandid= " + brandid;
            }
            if (!string.IsNullOrEmpty(brandsid))
            {
                sql += "  and brandsid= " + brandsid;
            }
            return Products.GetProductSearchItem(sql, companyid.ToString());
        }
          

        public static List<EnSearchProductItem> GetProductSearchItemByShopId(int shopId)
        {
            return Products.GetProductSearchItem(" brandid in (select brandid from t_shopbrand where shopid=" + shopId + " )");
        }

        /// <summary>
        /// Add : rafer
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static List<EnSearchProductItem> GetProductSearchItemByShopIdNew(int shopId, string brandid, string brandsid)
        {
            string sql = " brandid in (select brandid from t_shopbrand where shopid=" + shopId + " ) and shopid="+shopId;
            if (!string.IsNullOrEmpty(brandid))
            {
                sql += "  and brandid= " + brandid;
            }
            if (!string.IsNullOrEmpty(brandsid))
            {
                sql += "  and brandsid= " + brandsid;
            }
            List<EnSearchProductItem> _list = new List<EnSearchProductItem>();
            _list = Products.GetProductSearchItem(sql);

            if (_list.Count == 0)
            {
                sql = " brandid in (select brandid from t_shopbrand where shopid=" + shopId + " ) and   (shopid=0 OR shopid IS NULL) ";
                if (!string.IsNullOrEmpty(brandid))
                {
                    sql += "  and brandid= " + brandid;
                }
                if (!string.IsNullOrEmpty(brandsid))
                {
                    sql += "  and brandsid= " + brandsid;
                }
                _list = Products.GetProductSearchItem(sql);
            }
            return _list;

        }

        public static string GetMarketCategoryHtmlToNav(string marketid)
        {
            return GetCategoryHtmlToNav(marketid, "market");
        }


        public static string GetCategoryHtmlToNav()
        {
            return GetCategoryHtmlToNav("", "");
        }

        #region  搜索产品

        public static string GetCategoryHtmlToNav(string value, string type)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dtCateogry = new DataTable();
            if (type == "")
            {
                dtCateogry = Products.GetCategoryAndProductCountList();
            }
            if (type == "market")
            {
                dtCateogry = Products.GetCategoryAndProductCountList(" brandid in (select brandid from  t_shopbrand where shopid in (select shopid from t_marketstoreyshop where marketid=" + value + ") ) ");
            }

            int i = 1;
            DataRow[] parentDr = dtCateogry.Select(" parentid=0");
            string qcategoryid = "";
            if (ECommon.QuerySearchPCategory.Length > 0)
            {
                qcategoryid = ECommon.QuerySearchPCategory;
            }

            for (int index = 0; index < parentDr.Length; index++)
            {
                StringBuilder meun = new StringBuilder();
                DataRow dr = parentDr[index];


                string pname = dr["id"].ToString() == ECommon.QuerySearchPCategory ? "<strong style=\"color:#a20320\">" + dr["title"] + "</strong>" : dr["title"].ToString();

                meun.Append("<p>" + pname + "</p><ul class=\"fix\">");

                bool blmeunselect = false;

                foreach (DataRow subDr in dtCateogry.Select(" parentid=" + dr["id"]))
                {
                    string count = subDr["c"] != null && subDr["c"].ToString() != "" && subDr["c"].ToString() != "0" ? subDr["c"].ToString() : "";
                    if (ECommon.QuerySearchCategory != "")
                    {
                        if (ECommon.QuerySearchCategory == subDr["id"].ToString())
                        {
                            blmeunselect = true;
                            if (type == "market")
                            {
                                meun.Append("<li><a href=\"" + string.Format(EnUrls.MarketInfoProductList, value, "", "", "", "", "", "", "", "", "1", "", subDr["parentid"], subDr["id"]) + "\"  class=\"cut\"><strong>" + subDr["title"] /*+ " " + count*/ + "</strong></a></li>");
                            }
                            else
                            {
                                meun.Append("<li><a href=\"" + string.Format(EnUrls.ProductListSearch, "", "", "", "", "", "", "", "", "1", "", subDr["parentid"], subDr["id"]) + "\"  class=\"cut\"><strong>" + subDr["title"] /*+ " " + count*/ + "</strong></a></li>");
                            }
                        }
                        else
                        {
                            if (type == "market")
                            {
                                meun.Append("<li><a href=\"" + string.Format(EnUrls.MarketInfoProductList, value, "", "", "", "", "", "", "", "", "1", "", subDr["parentid"], subDr["id"]) + "\">" + subDr["title"] /*+ " " + count*/ + "</a></li>");
                            }
                            else
                            {
                                meun.Append("<li><a href=\"" + string.Format(EnUrls.ProductListSearch, "", "", "", "", "", "", "", "", "1", "", subDr["parentid"], subDr["id"]) + "\">" + subDr["title"] + " " /*+ "<span class=\"tcount\">" + count + "</span>"*/ + "</a></li>");
                            }
                        }
                    }
                    else
                    {
                        if (type == "market")
                        {
                            meun.Append("<li><a href=\"" + string.Format(EnUrls.MarketInfoProductList, value, "", "", "", "", "", "", "", "", "1", "", subDr["parentid"], subDr["id"]) + "\">" + subDr["title"] /*+ " " + count*/ + "</a></li>");
                        }
                        else
                        {
                            meun.Append("<li><a href=\"" + string.Format(EnUrls.ProductListSearch, "", "", "", "", "", "", "", "", "1", "", subDr["parentid"], subDr["id"]) + "\">" + subDr["title"] + " " /*+ "<span class=\"tcount\">" + count + "</span>"*/ + "</a></li>");
                        }
                    }
                }
                meun.Append("</ul></div>");
                if (blmeunselect)
                {

                    if (dr["id"].ToString() == ECommon.QuerySearchPCategory)
                    {
                        sb.Append("<div id=\"divmenuTitle" + dr["id"].ToString() + "\" class=\"on\">" + meun);
                    }
                    else if (dr == parentDr[parentDr.Length - 1])
                    {
                        sb.Append("<div id=\"divmenuTitle" + dr["id"].ToString() + "\" class=\"on\" style=\"border:0\">" + meun);
                    }
                    else
                    {
                        sb.Append("<div id=\"divmenuTitle" + dr["id"].ToString() + "\" class=\"on\">" + meun);
                    }

                }
                else
                {
                    if (value == "" && type == "")
                    {
                        if (dr["id"].ToString() == "7" && ECommon.QuerySearchPCategory == "")
                        {
                            sb.Append("<div id=\"divmenuTitle" + dr["id"].ToString() + "\" class=\"on\">" + meun);
                        }
                        else
                        {
                            sb.Append("<div id=\"divmenuTitle" + dr["id"].ToString() + "\" class=\"out\">" + meun);
                        }
                    }
                    else
                    {
                        if (dr["id"].ToString() == ECommon.QuerySearchPCategory)
                        {
                            sb.Append("<div id=\"divmenuTitle" + dr["id"].ToString() + "\" class=\"out\">" + meun);
                        }
                        else if (dr == parentDr[parentDr.Length - 1])
                        {
                            sb.Append("<div id=\"divmenuTitle" + dr["id"].ToString() + "\" class=\"out\" style=\"border:0\">" + meun);
                        }
                        else
                        {
                            sb.Append("<div id=\"divmenuTitle" + dr["id"].ToString() + "\" class=\"out\">" + meun);
                        }
                    }
                }
                blmeunselect = false;
                meun = null;

                i++;
            }
            sb.Append("<script type=\"text/javascript\">");
            sb.Append("$(function(){");

            for (int index = 0; index < parentDr.Length; index++)
            {
                DataRow dr = parentDr[index];

                sb.Append("$('#divmenuTitle" + dr["id"].ToString() + "').click(function(){");
                sb.Append("$('#divmenuTitle" + dr["id"].ToString() + "').addClass (\"on\").removeClass(\"out\");");
                for (int j = 0; j < parentDr.Length; j++)
                {
                    DataRow dri = parentDr[j];
                    if (dr["id"].ToString() != dri["id"].ToString())
                    {
                        sb.Append("$('#divmenuTitle" + dri["id"].ToString() + "').addClass (\"out\").removeClass(\"on\");");
                    }

                }
                sb.Append("});");

            }
            sb.Append("});");
            sb.Append("</script>");
            return sb.ToString();
        }

        public static string GetCategoryHtmlToIndexNav()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dtCateogry = dtCateogry = Products.GetCategoryAndProductCountList();

            int i = 1;
            DataRow[] parentDr = dtCateogry.Select(" parentid=0");
            string qcategoryid = "";
            if (ECommon.QuerySearchPCategory.Length > 0)
            {
                qcategoryid = ECommon.QuerySearchPCategory;
            }
            foreach (DataRow dr in parentDr)
            {
                string pname = dr["id"].ToString() == ECommon.QuerySearchPCategory ? "<strong style=\"color:#a20320\">" + dr["title"] + "</strong>" : dr["title"].ToString();
                sb.Append("<dl class=\"dl" + i + "\"><dt class=\"dt" + i + "\">" + pname + "</dt><dd class=\"dd" + i + "\">");
                foreach (DataRow subDr in dtCateogry.Select(" parentid=" + dr["id"]))
                {
                    string count = subDr["c"] != null && subDr["c"].ToString() != "" && subDr["c"].ToString() != "0" ? subDr["c"].ToString() : "";


                    sb.Append("<a href=\"" + string.Format(EnUrls.ProductListSearch, "", "", "", "", "", "", "", "", "1", "", subDr["parentid"], subDr["id"]) + "\">" + subDr["title"] + " " + count + "</a>");

                }
                sb.Append("</dd></dl>");
                i++;
            }

            return sb.ToString();
        }
        #endregion

        public static EnWebProduct GetWebProducInfo(string strWhere)
        {
            return Products.GetWebProducInfo(strWhere);
        }
        public static string CheckbuypriceName(string proid)
        {
            return Products.CheckbuypriceName(proid);
        }
        public static List<EnWebProduct> GetWebProductList(int PageIndex, int PageSize, string strWhere, string sortkey, string ordertype, out int pageCount)
        {
            return Products.GetWebProductList(PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);
        }

        public static List<EnWebProduct> GetWebProductList(int PageIndex, int PageSize, string strWhere, string sortkey, string ordertype, string bstrWhere, string brstrWhere, string bidWhere, bool blBrandSearch, bool isfirstshow, out int pageCount, out List<int> brandList, out List<int> brandidlist, out List<int> marketList)
        {
            return Products.GetWebProductList(PageIndex, PageSize, strWhere, sortkey, ordertype, bstrWhere, brstrWhere, bidWhere, blBrandSearch, isfirstshow, out pageCount, out brandList, out brandidlist, out marketList);
        }

        public static List<EnSearchItem> GetMarketProductSearchTypeItem(string marketid)
        {
            return GetProductSearchTypeItem("brandid in (select brandid from t_shopbrand where shopid in (select shopid from t_marketstoreyshop where marketid=" + marketid + "))");
        }
        public static List<EnSearchItem> GetProductSearchTypeItem()
        {
            return GetProductSearchTypeItem("");
        }

        /// <summary>
        /// 前台新的搜索
        /// add:rafer
        /// date:2012-5-10
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static List<EnSearchItem> GetProductSearchTypeItemNew(int cid)
        {
            List<EnConfig> enc = new List<EnConfig>();
            List<EnSearchItem> ens = new List<EnSearchItem>();

            string producttypelist = ECPCategoryPTyp.GetProductCategoryTypeValueList(cid);
            enc = ECConfig.GetConfigList(" type=" + (int)EnumConfigByProduct.产品类型 + " and value in(" + producttypelist + ")");
            foreach (EnConfig item in enc)
            {
                EnSearchItem _e = new EnSearchItem();
                if (ECommon.QuerySearchType != "")
                {
                    if (!ECommon.QuerySearchType.Split('_').Contains(item.value))
                    {
                        _e.title = item.title;
                        _e.value = item.value;
                        _e.isCur = false;
                        ens.Add(_e);
                    }
                    else
                    {
                        _e.title = item.title;
                        _e.value = item.value;
                        _e.isCur = true;
                        ens.Add(_e);
                    }
                }
                else
                {
                    _e.title = item.title;
                    _e.value = item.value;
                    _e.isCur = false;
                    ens.Add(_e);
                }
            }
            return ens;
        }
        public static List<EnSearchItem> GetProductSearchTypeItem(string str)
        {
            string strWhere = "";
            string categoryItems = "";
            if (ECommon.QuerySearchCategory != "")
            {
                foreach (string s in ECommon.QuerySearchCategory.Split('_'))
                {
                    categoryItems += s + ",";
                }
                categoryItems = categoryItems.StartsWith(",") ? categoryItems.Substring(1, categoryItems.Length - 1) : categoryItems;
                categoryItems = categoryItems.EndsWith(",") ? categoryItems.Substring(0, categoryItems.Length - 1) : categoryItems;
            }
            if (categoryItems != "")
            {
                strWhere += " categoryid in(" + categoryItems + ")";
            }
            if (str != "")
            {
                strWhere = strWhere != "" ? strWhere + " and " + str : str;
            }

            List<EnSearchItem> list = Products.GetProductSearchTypeItem(strWhere);
            List<EnSearchItem> templist = new List<EnSearchItem>();
            foreach (EnSearchItem item in list)
            {
                if (item.type == "type" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchType != "" && ECommon.QuerySearchType.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        continue;
                    }
                    else
                    {
                        if (templist.Find(x => x.value == "0") == null && item.value == "0")
                        {
                            item.title = "其它类型";
                        }

                        item.isCur = false;
                        templist.Add(item);
                    }
                }
            }

            return templist;

        }

        public static List<EnSearchItem> GetSearchItem()
        {
            List<EnSearchItem> list = new List<EnSearchItem>();
            List<EnSearchItem> itemList = (List<EnSearchItem>)DataCache.GetCache(CacheKey.ProductSearchItemList);

            if (itemList == null)
            {
                itemList = Products.GetProductSearchItem();
                DataCache.SetCache(CacheKey.ProductSearchItemList, itemList);
            }

            foreach (EnSearchItem item in itemList)
            {
                if (item.type == "brand" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchBrand != "" && ECommon.QuerySearchBrand.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                if (item.type == "style" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchStyle != "" && ECommon.QuerySearchStyle.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                if (item.type == "material" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchMaterial != "" && ECommon.QuerySearchMaterial.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                if (item.type == "spread" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchSpread != "" && ECommon.QuerySearchSpread.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }

                if (item.type == "type" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchType != "" && ECommon.QuerySearchType.Split('_').Contains(item.value))
                    {
                        if (list.Find(x => x.value == "0" && x.type == "type") == null && item.value == "0")
                        {
                            item.title = "其它类型";
                            item.value = "0";
                            item.isCur = true;
                            list.Add(item);
                            continue;
                        }
                        if (list.Find(x => x.value == "0" && x.type == "type") != null && item.value == "0")
                        {
                            continue;
                        }
                        item.isCur = true;

                    }
                    else
                    {
                        item.isCur = false;
                    }
                }

                if (item.type == "color" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchColor != "" && ECommon.QuerySearchColor.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }

                list.Add(item);
            }
            return list;
        }
         /// <summary>
        /// ShopBrand.aspx页面店铺数据
        /// </summary>
        /// <returns></returns>
        public static DataSet getShopProduct(int pageIndex, int pagesize, string condiction, string table)
        {
            return Products.getShopProduct(pageIndex, pagesize, condiction, table);
        }
        public static List<EnSearchItem> GetMarketSearchItem(string marketid)
        {

            List<EnSearchItem> list = new List<EnSearchItem>();
            List<EnSearchItem> itemList = (List<EnSearchItem>)DataCache.GetCache(string.Format(CacheKey.MarketProductSearchItemTypeList, marketid));

            if (itemList == null)
            {
                itemList = Products.GetMarketProductSearchItem(marketid);
                DataCache.SetCache(string.Format(CacheKey.MarketProductSearchItemTypeList, marketid), itemList);
            }

            foreach (EnSearchItem item in itemList)
            {
                if (item.type == "brand" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchBrand != "" && ECommon.QuerySearchBrand.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                if (item.type == "style" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchStyle != "" && ECommon.QuerySearchStyle.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                if (item.type == "material" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchMaterial != "" && ECommon.QuerySearchMaterial.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }
                if (item.type == "spread" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchSpread != "" && ECommon.QuerySearchSpread.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }

                if (item.type == "type" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchType != "" && ECommon.QuerySearchType.Split('_').Contains(item.value))
                    {
                        if (list.Find(x => x.value == "0" && x.type == "type") == null && item.value == "0")
                        {
                            item.title = "其它类型";
                            item.value = "0";
                            item.isCur = true;
                            list.Add(item);
                            continue;
                        }
                        if (list.Find(x => x.value == "0" && x.type == "type") != null && item.value == "0")
                        {
                            continue;
                        }
                        item.isCur = true;

                    }
                    else
                    {
                        item.isCur = false;
                    }
                }

                if (item.type == "color" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchColor != "" && ECommon.QuerySearchColor.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }

                list.Add(item);
            }
            return list;
        }

        #region

        #region 删除产品到回收站

        /// <summary>
        /// 删除产品到回收站
        /// </summary>
        /// <param name="pId">产品id</param>
        /// <returns></returns>
        public static bool deleteProduct(string pid)
        {
            return Products.deleteProduct(pid);
        }
        #endregion

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditProduct(EnProduct model)
        {
            return Products.EditProduct(model);
        }

        #region 还原（删除）回收站中产品
        /// <summary>
        /// 还原（删除）回收站中产品
        /// </summary>
        /// <param name="gpId">产品id</param>
        /// <param name="Type">操作类型（revert表示还原；delete表示删除）</param>
        /// <returns></returns>
        public static bool DoRecycleProduct(string pid, string Type)
        {
            return Products.DoRecycleProduct(pid, Type);
        }
        #endregion

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnProduct GetProductInfo(string strWhere)
        {
            return Products.GetProductInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnProduct> GetProductList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Products.GetProductList(PageIndex, PageSize, strWhere, out pageCount);
        }
        /// <summary>
        /// 复制所有店铺数据
        /// </summary>
        /// <returns></returns>
        public static DataTable copyShopproduct(string where)
        {
            return Products.copyShopproduct(where);
        }
        /// <summary>
        /// 获得回收站数据列表
        /// </summary>
        public static List<EnProduct> GetproductrecyclerecycleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Products.GetproductrecyclerecycleList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnProduct> GetProductList(string strWhere, out int pageCount)
        {
            return GetProductList(-1, 0, strWhere, out pageCount);
        }

        /// <summary>
        ///获取数据列表
        /// </summary>
        /// <param name="strWhere">where条件，（ id=11 and uname=..）</param>
        /// <returns></returns>
        public static List<EnProduct> GetProductList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetProductList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetProductListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBProduct, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteProduct(int id)
        {
            return DeleteProduct(" where id=" + id);
        }
        ///删除对象
        public static int DeleteProductByIdList(string idList)
        {
            return DeleteProduct(" where id in (" + idList + ")");
        }

        /// <summary>
        /// 更新上/下线对象
        /// rafer
        /// 5-17
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ModifyProductlinestatusByID(string idList, int values)
        {
            return DataCommon.UpdateValue(TableName.TBProduct, "linestatus", values.ToString(), " where ID in (" + idList + ")");
        }

        /// <summary>
        /// 更新上/下线对象/审核通过不过
        /// rafer
        /// 5-17
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ModifyProductlinestatusByID(string idList, string values, string files)
        {
            return DataCommon.UpdateValue(TableName.TBProduct, files, values, " where ID in (" + idList + ")");
        }

        /// <summary>
        /// 更新上/下线对象/审核通过不过
        /// rafer
        /// 5-17
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ModifyProductByID(string values, string files, string where)
        {
            return DataCommon.UpdateValue(TableName.TBProduct, files, values, where);
        }

        ///删除对象
        public static int DeleteProduct(string strWhere)
        {
            return DataCommon.Delete(TableName.TBProduct, strWhere);
        }

        /// <summary>
        /// 保存产品属性颜色
        /// </summary>
        /// <param name="colorName">颜色名称</param>
        /// <param name="colorDescript">颜色描述</param>
        /// <param name="memberId">会员id</param>
        /// <returns></returns>
        public static bool SaveProductAttributeColorDb(string colorName, string colorDescript, string memberId)
        {
            string Sql = string.Format(@"INSERT INTO [t_config] (title,value,type,module,sort,memberId,ishide,descript) 
                   SELECT '{0}',Cast((MAX(id)+1) as varchar(10)),13,103,0,{1},1,'{2}' FROM t_config ", colorName, memberId, colorDescript);
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }
        #region
        /// <summary>
        /// 保存产品属性类型
        /// </summary>
        /// <param name="colorName">颜色名称</param>
        /// <param name="colorDescript">颜色描述</param>
        /// <param name="memberId">会员id</param>
        /// <returns></returns>
        public static bool SaveProductAttributeTypeDb(string colorName, string colorDescript, string memberId)
        {
            string Sql = string.Format(@"INSERT INTO [t_config] (title,value,type,module,sort,memberId,ishide,descript) 
                   SELECT '{0}',Cast((MAX(id)+1) as varchar(10)),11,103,0,{1},1,'{2}' FROM t_config ", colorName, memberId, colorDescript);
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }
        #endregion

        #region  Method-ProductCon
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditProductCon(EnProductCon model)
        {
            return Products.EditProductCon(model);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnProductCon GetProductConInfo(string strWhere)
        {
            return Products.GetProductConInfo(strWhere);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnProductCon> GetProductConList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Products.GetProductConList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnProductCon> GetProductConList(string strWhere, out int pageCount)
        {
            return GetProductConList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnProductCon> GetProductConList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetProductConList(-1, 0, strWhere, out tmpPageCount);
        }

        ///获取数据列表
        public static List<EnProductCon> GetProductConListByProductid(int productid)
        {
            int tmpPageCount = 0;
            return GetProductConList(-1, 0, " where productid=" + productid, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetProductConListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBProductCon, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeleteProductCon(int id)
        {
            return DeleteProductCon(" where id=" + id);
        }
        ///删除对象
        public static int DeleteProductConByIdList(string idList)
        {
            return DeleteProductCon(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteProductCon(string strWhere)
        {
            return DataCommon.Delete(TableName.TBProductCon, strWhere);
        }
        #endregion


        #region 首页数据统计
        public static List<Hashtable> GetIndexCount()
        {
            return Products.GetIndexCount();
        }
        #endregion

        #region 根据小类ID获取产品大类ID
        /// <summary>
        /// 根据小类ID获取产品大类ID
        /// </summary>
        /// <param name="smallCateId">小类id</param>
        /// <returns></returns>
        public static int GetBigCateBysmallID(int smallCateId)
        {
            //大类
            List<EnProductCategory> catagoryList = ECProductCategory.GetProductCategoryListToDDL("");
            var bigCate = from bc in catagoryList where bc.id == smallCateId select bc.parentid.ToString();
            int myid = 0;
            if (bigCate.ToList<string>().Count > 0)
            {
                int.TryParse(bigCate.ToList<string>()[0], out myid);
            }

            return myid;
        }

        #endregion
        #endregion



        #region 小类对应的属性
        /// <summary>
        /// 小类对应的属性
        /// </summary>
        /// <returns></returns>
        public static List<producttype> GetProductType()
        {

            List<producttype> list = TREC.Data.Products.GetProductType();
             
            TRECommon.DataCache.SetCache("producttype", list, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            return list;
        }

        public static List<producttype> GetProductTypeAll() {
            List<producttype> list = TREC.Data.Products.GetProductTypeAll();

            TRECommon.DataCache.SetCache("producttypeall", list, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            return list;
        }
        #endregion

    }
}

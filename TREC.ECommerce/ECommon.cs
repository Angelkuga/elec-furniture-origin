using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using TREC.Data;
using TRECommon;
using TREC.Entity;
using System.Web;
using System.Web.UI.WebControls;
using TREC.Config;
using System.Data;

namespace TREC.ECommerce
{
    public class ECommon
    {

        ///网站路径
        public static string WebUrl = WebConfigs.GetConfig().WebUrl;
        ///会员网站路径
        public static string WebSupplerUrl = WebConfigs.GetConfig().WebSupplerUrl;
        ///后台网站路径
        public static string WebAdminUrl = WebConfigs.GetConfig().WebAdminUrl;
        public static string AdminDirectory = "admin";
        public static string SupplerDirectory = "suppler";
        ///资源根路径
        public static string WebResourceUrl = WebConfigs.GetConfig().WebUrl + "/resource/";
        ///通道资源根路径
        public static string WebSupplerResourceUrl = WebConfigs.GetConfig().WebSupplerUrl + "/resource/";

        ///后台资源根路径
        public static string WebAdminResourceUrl = WebConfigs.GetConfig().WebAdminUrl + "/resource/";

        ///资源网站前台路径
        public static string WebResourceUrlToWeb = WebConfigs.GetConfig().WebUrl + "/resource/web";
        //通用程序文件路径
        public static string WebCommonUrl = WebUrl + "/common/";
        public static string WebUploadTempUrl = WebConfigs.GetConfig().WebUrl + "/upload/temp/";
        public static int tmpPageCount = 0;

        ///跨域写入Cookie的域名
        public static string CookieUrl = WebConfigs.GetConfig().CookieUrl;
        public static string WebTitle = "家具快搜";

        ///通知客服邮箱
        public static string ServiceMail = WebConfigs.GetConfig().ServiceMail;

        #region QueryString

        //ID
        public static string QueryId
        {
            get
            {
                return WebRequest.GetQueryString("id");
            }
        }
        public static string QueryCid
        {
            get
            {
                return WebRequest.GetQueryString("cid");
            }
        }
        public static string QueryPid
        {
            get
            {
                return WebRequest.GetQueryString("pid");
            }
        }

        //编辑0,增加,1,修改,2删除，默认0
        public static string QueryEdit
        {
            get
            {
                return WebRequest.GetQueryString("edit");
            }
        }

        public static int QueryPageIndex
        {
            get
            {
                string page = WebRequest.GetQueryString("page");
                return page == "" ? 1 : TypeConverter.StrToInt(page);
            }
        }

        public static string QueryModuleId
        {
            get
            {
                return WebRequest.GetQueryString("moduleid");
            }
        }

        public static string QueryRoleId
        {
            get
            {
                return WebRequest.GetQueryString("rid");
            }
        }

        public static string QueryCId
        {
            get
            {
                return WebRequest.GetQueryString("cid");
            }
        }


        public static string QueryBId
        {
            get
            {
                return WebRequest.GetQueryString("bid");
            }
        }

        public static string QueryStime
        {
            get
            {
                return WebRequest.GetQueryString("stime");
            }
        }
        public static string QueryEtime
        {
            get
            {
                return WebRequest.GetQueryString("etime");
            }
        }

        public static string QueryPId
        {
            get
            {
                return WebRequest.GetQueryString("pid");
            }
        }

        public static string QueryType
        {
            get
            {
                return WebRequest.GetQueryString("type");
            }
        }

        public static string QueryValue
        {
            get
            {
                return WebRequest.GetQueryString("value");
            }
        }

        public static string QueryContorl
        {
            get
            {
                return WebRequest.GetQueryString("contorl");
            }
        }

        public static string QueryMid
        {
            get
            {
                return WebRequest.GetQueryString("mid");
            }
        }

        public static string QueryMemberType
        {
            get
            {
                return WebRequest.GetQueryString("mt");
            }
        }



        //ID
        public static string QueryDId
        {
            get
            {
                return WebRequest.GetQueryString("did");
            }
        }

        //OID
        public static string QueryOId
        {
            get
            {
                return WebRequest.GetQueryString("oid");
            }
        }
        //ID
        public static string QuerySId
        {
            get
            {
                return WebRequest.GetQueryString("sid");
            }
        }

        /// <summary>
        /// merchantid
        /// </summary>
        public static string QueryMerchantid
        {
            get
            {
                return WebRequest.GetQueryString("merchantid");
            }
        }

        #endregion

        /// <summary>
        /// 替换路径
        /// </summary>
        /// <param name="con"></param>
        /// <param name="source"></param>
        /// <param name="repStr"></param>
        /// <returns></returns>
        public static string RepFilePathContent(string con, string source, string repStr)
        {
            return con.Replace(source, repStr);
        }

        public static string getMenuUrl(string urlFormat)
        {
            //格式 @web,@admin,@suppler,@shop,@market,@company,@dealer

            string newUrl = urlFormat;
            newUrl = newUrl.Replace("@web", WebUrl);
            newUrl = newUrl.Replace("@admin", AdminDirectory);
            newUrl = newUrl.Replace("@suppler", SupplerDirectory);

            return newUrl;
        }

        /// <summary>
        /// New function
        /// rafer
        /// </summary>
        /// <param name="urlFormat"></param>
        /// <returns></returns>
        public static string getNewMenuUrl(string urlFormat)
        {
            //格式 @web,@admin,@suppler,@shop,@market,@company,@dealer

            string newUrl = urlFormat;
            newUrl = newUrl.Replace("@web", WebAdminUrl);
            newUrl = newUrl.Replace("@admin", AdminDirectory);
            newUrl = newUrl.Replace("@suppler", SupplerDirectory);

            return newUrl;
        }
        /// <summary>
        /// 获取地区数据列表
        /// </summary>
        /// <param name="AreaCode"></param>
        /// <returns></returns>
        public static string getAreaAll(string AreaCode)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DataCommon.getAreaList(AreaCode);
                string v = string.Empty;
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        v = r["areaname"] as string + v;
                    }
                }
                if (!string.IsNullOrEmpty(v))
                {
                    return v;
                }
                else
                {
                    return " ";
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public static List<string> shArea
        {
            get
            {
                List<string> _list = new List<string>();
                _list.Add("310101");
                _list.Add("310104");
                _list.Add("310105");
                _list.Add("310106");
                _list.Add("310107");
                _list.Add("310108");
                _list.Add("310109");
                _list.Add("310110");
                _list.Add("310112");
                _list.Add("310113");
                _list.Add("310114");
                _list.Add("310115");
                _list.Add("310116");
                _list.Add("310117");
                _list.Add("310118");
                _list.Add("310120");
                return _list;
            }
        }

      
        /// <summary>
        /// New function
        /// rafer
        /// </summary>
        /// <param name="urlFormat"></param>
        /// <returns></returns>
        public static string getSupplierMenuUrl(string urlFormat)
        {
            //格式 @web,@admin,@suppler,@shop,@market,@company,@dealer

            string newUrl = urlFormat;
            newUrl = newUrl.Replace("@web", WebSupplerUrl);
            newUrl = newUrl.Replace("@admin", AdminDirectory);
            newUrl = newUrl.Replace("@suppler", SupplerDirectory);

            return newUrl;
        }

        public static void ListBoxBindToProductType(ListBox listbox, string strWhere)
        {
            listbox.Items.Clear();
            listbox.DataSource = ECConfig.GetConfigList(" type=" + (int)EnumConfigByProduct.产品类型 + strWhere);
            listbox.DataTextField = "title";
            listbox.DataValueField = "value";
            listbox.DataBind();
        }

        //检查名称
        public static string CheckName(string name, string name2, string ctype)
        {
            switch (ctype)
            {
                case "m":
                    return DataCommon.Exists(TableName.TBMember, " where username='" + name + "'") > 0 ? "false" : "true";
                case "seek":
                    return DataCommon.Exists(TableName.TBMember, " where username='" + name + "'") > 0 ? "true" : "false";
                case "c":
                    return DataCommon.Exists(TableName.TBCompany, " where title='" + name + "'") > 0 ? "false" : "true";
                case "d":
                    return DataCommon.Exists(TableName.TBDealer, " where title='" + name + "'") > 0 ? "false" : "true";
                case "s":
                    return DataCommon.Exists(TableName.TBShop, " where title='" + name + "'") > 0 ? "false" : "true";
                case "m2":
                    return DataCommon.Exists(TableName.TBMarket, " where title='" + name + "") > 0 ? "false" : "true";
                case "b":
                    return DataCommon.Exists(TableName.TBBrand, " where title='" + name + "'") > 0 ? "false" : "true";
                default:
                    return "false";
            }
        }

        //检查名称
        public static string CheckNameEmail(string name, string email, string ctype)
        {
            switch (ctype)
            {
                case "email":
                    return DataCommon.Exists(TableName.TBMember, " where username='" + name + "' and email='" + email + "'") > 0 ? "true" : "false";
                case "mobliemail":
                    return DataCommon.Exists(TableName.TBMember, " where mobile='" + name + "' or email='" + email + "'") > 0 ? "true" : "false";
                case "mobliname":
                    return DataCommon.Exists(TableName.TBMember, " where mobile='" + name + "' and username='" + email + "'") > 0 ? "true" : "false";
                case "moblie":
                    return DataCommon.Exists(TableName.TBMember, " where mobile='" + name + "'") > 0 ? "true" : "false";

                default:
                    return "false";
            }
        }


        #region searchQuerString

        public static string QuerySearchBrand
        {
            get
            {
                return WebRequest.GetQueryString("brand");
            }
        }

        public static string QuerySearchStyle
        {
            get
            {
                return WebRequest.GetQueryString("style");
            }
        }

        public static string QuerySearchMaterial
        {
            get
            {
                return WebRequest.GetQueryString("material");
            }
        }

        public static string QuerySearchSpread
        {
            get
            {
                return WebRequest.GetQueryString("spread");
            }
        }

        public static string QuerySearchStaffsize
        {
            get
            {
                return WebRequest.GetQueryString("staffsize");
            }
        }

        public static string QuerySearchSort
        {
            get
            {
                return WebRequest.GetQueryString("sort");
            }
        }

        public static string QuerySearchComposing
        {
            get
            {
                return WebRequest.GetQueryString("composing");
            }
        }

        public static string QuerySearchKey
        {
            get
            {
                return WebRequest.GetQueryString("key");
            }
        }

        public static string QuerySearchType
        {
            get
            {
                return WebRequest.GetQueryString("type");
            }
        }

        public static string QuerySearchBrands
        {
            get
            {
                return WebRequest.GetQueryString("brands");
            }
        }
        public static string QuerySearchPCategory
        {
            get
            {
                return WebRequest.GetQueryString("pcategory");
            }
        }
        public static string QuerySearchCategory
        {
            get
            {
                return WebRequest.GetQueryString("category");
            }
        }
        /// <summary>
        /// 模糊搜索
        /// </summary>
        public static string QuerySearchPostName
        {
            get
            {
                return WebRequest.GetQueryString("postname");
            }
        }
        /// <summary>
        /// 套组合名字
        /// </summary>
        public static string QuerySearchty
        {
            get
            {
                return WebRequest.GetQueryString("ty");
            }
        }

        public static string QuerySearchColor
        {
            get
            {
                return WebRequest.GetQueryString("color");
            }

        }
        public static string QuerySearchArea
        {
            get
            {
                return WebRequest.GetQueryString("area");
            }
        }
        public static string QuerySearchMarket
        {
            get
            {
                return WebRequest.GetQueryString("market");
            }
        }
        public static string QuerySearchMarketStorey
        {
            get
            {
                return WebRequest.GetQueryString("msid");
            }
        }

        public static string QuerySearchDisplay
        {
            get
            {
                return WebRequest.GetQueryString("display");
            }
        }
        #endregion

        public static List<EnWebAggregation> GetCompanyListTopBrand()
        {
            return ECAggregation.GetWebCommonAggregationListByParentIdList().Where(x => x.type == 30).ToList();
        }

        public static List<EnWebAggregation> GetCompanyBrandListTopBrand()
        {
            return ECAggregation.GetWebCommonAggregationListByParentIdList().Where(x => x.type == 35).ToList();
        }

        public static List<EnWebAggregation> GetShopBrandListTopBrand()
        {
            return ECAggregation.GetWebCommonAggregationListByParentIdList().Where(x => x.type == 36).ToList();
        }

        public static List<EnWebAggregation> GetShopListTopBrand()
        {
            return ECAggregation.GetWebCommonAggregationListByParentIdList().Where(x => x.type == 31).ToList();
        }
        public static List<EnWebAggregation> GetProductListTopBrand()
        {
            return ECAggregation.GetWebCommonAggregationListByParentIdList().Where(x => x.type == 32).ToList();
        }

        public static List<EnWebAggregation> GetMarketListTopBrand()
        {
            return ECAggregation.GetWebCommonAggregationListByParentIdList().Where(x => x.type == 38).ToList();
        }

        public static string GetConfigName(string modeule, string type, string value, char spl, string tostr)
        {
            if (value == null)
                return "";

            List<EnConfig> list = null;
            if ((List<EnConfig>)DataCache.GetCache(CacheKey.ConfigList) != null)
            {
                list = (List<EnConfig>)DataCache.GetCache(CacheKey.ConfigList);
            }
            else
            {
                list = ECConfig.GetConfigList("");
                DataCache.SetCache(CacheKey.ConfigList, list);
            }
            string tvalue = "";
            List<EnConfig> tmp = list.Where(x => x.module.ToString() == modeule && x.type.ToString() == type).ToList();
            foreach (string s in value.Split(spl))
            {
                if (s != "")
                {
                    foreach (EnConfig c in tmp.Where(j => j.value == s))
                    {
                        tvalue += c.title + tostr;
                    }
                }
            }

            return tvalue;


        }

        public static string GetProAreaName(string areacode)
        {
            string aname = "";
            List<EnArea> list = new List<EnArea>();

            if (DataCache.GetCache(CacheKey.arealist) != null)
            {
                list = (List<EnArea>)DataCache.GetCache(CacheKey.arealist);
            }
            else
            {
                list = ECArea.GetAreaList(" 1=1");
                DataCache.SetCache(CacheKey.arealist, list);
            }

            if (!string.IsNullOrEmpty(areacode) && areacode.Length == 6)
            {
                aname = list.Find(x => x.areacode == areacode.Substring(0, 2) + "0000").areaname;
            }
            return aname;
        }
        public static string GetCityAreaName(string areacode)
        {
            string aname = "";
            List<EnArea> list = new List<EnArea>();

            if (DataCache.GetCache(CacheKey.arealist) != null)
            {
                list = (List<EnArea>)DataCache.GetCache(CacheKey.arealist);
            }
            else
            {
                list = ECArea.GetAreaList(" 1=1");
                DataCache.SetCache(CacheKey.arealist, list);
            }

            if (!string.IsNullOrEmpty(areacode) && areacode.Length == 6)
            {
                aname = list.Find(x => x.areacode == areacode.Substring(0, 4) + "00").areaname;
            }
            return aname;

        }

        public static string GetAreaName(string areacode)
        {
            string aname = "";
            List<EnArea> list = new List<EnArea>();

            if (DataCache.GetCache(CacheKey.arealist) != null)
            {
                list = (List<EnArea>)DataCache.GetCache(CacheKey.arealist);
            }
            else
            {
                list = ECArea.GetAreaList(" 1=1");
                DataCache.SetCache(CacheKey.arealist, list);
            }

            if (!string.IsNullOrEmpty(areacode) && areacode.Length == 6)
            {
                string code = areacode;
                do
                {
                    aname = list.Find(x => x.areacode == code).areaname + aname;
                    code = list.Find(j => j.areacode == code).parentcode;



                }
                while (code != "0" && !string.IsNullOrEmpty(code));
            }
            if (aname != null && aname.Length > 0)
                aname = aname.Replace("市辖区", "");
            return aname;

        }

        public static string GetTrueCodeNameNew(string areacode)
        {
            string aname = areacode;
            //去掉和地址无关的字符，提供给Map.Baidu
            string[] _regex = { "(", "[", "<", "{", "（", "【", "《", "'", "\"" };
            foreach (string item in _regex)
            {
                if (aname.IndexOf(item) != -1)
                {
                    aname = aname.Substring(0, aname.IndexOf(item));
                }
            }
            return aname;


        }

    }
}

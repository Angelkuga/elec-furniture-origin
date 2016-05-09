using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TREC.Entity;
using TRECommon;
using System.Collections;

namespace TREC.Data
{
    public class Shops
    {

        public static int ExitShopTitle(string title)
        {
            SqlParameter[] parames = { 
            new SqlParameter("@title", SqlDbType.VarChar, 30)};
            parames[0].Value = title;
            return DataCommon.Exists(TableName.TBShop, " where title=@title", parames);
        }

        //店铺列表
        public static EnWebShop GetWebShopInfo(string strWhere)
        {
            EnWebShop model = new EnWebShop();
            IDataReader reader = DataCommon.GetDataIReader(TableName.TVShopList, "", strWhere, "");
            while (reader.Read())
            {
                if (reader["brandxml"] != null && reader["brandxml"].ToString() != "")
                {
                    model.brandxml = reader["brandxml"].ToString();
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["productcount"] != null && reader["productcount"].ToString() != "")
                {
                    model.productcount = int.Parse(reader["productcount"].ToString());
                }
                if (reader["mid"] != null && reader["mid"].ToString() != "")
                {
                    model.mid = int.Parse(reader["mid"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["groupid"] != null && reader["groupid"].ToString() != "")
                {
                    model.groupid = int.Parse(reader["groupid"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["industry"] != null && reader["industry"].ToString() != "")
                {
                    model.industry = reader["industry"].ToString();
                }
                if (reader["productcategory"] != null && reader["productcategory"].ToString() != "")
                {
                    model.productcategory = reader["productcategory"].ToString();
                }
                if (reader["vip"] != null && reader["vip"].ToString() != "")
                {
                    model.vip = int.Parse(reader["vip"].ToString());
                }
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
                }
                if (reader["mapapi"] != null && reader["mapapi"].ToString() != "")
                {
                    model.mapapi = reader["mapapi"].ToString();
                }
                if (reader["staffsize"] != null && reader["staffsize"].ToString() != "")
                {
                    model.staffsize = int.Parse(reader["staffsize"].ToString());
                }
                if (reader["regyear"] != null && reader["regyear"].ToString() != "")
                {
                    model.regyear = reader["regyear"].ToString();
                }
                if (reader["regcity"] != null && reader["regcity"].ToString() != "")
                {
                    model.regcity = reader["regcity"].ToString();
                }
                if (reader["buy"] != null && reader["buy"].ToString() != "")
                {
                    model.buy = reader["buy"].ToString();
                }
                if (reader["sell"] != null && reader["sell"].ToString() != "")
                {
                    model.sell = reader["sell"].ToString();
                }
                if (reader["linkman"] != null && reader["linkman"].ToString() != "")
                {
                    model.linkman = reader["linkman"].ToString();
                }
                if (reader["phone"] != null && reader["phone"].ToString() != "")
                {
                    model.phone = reader["phone"].ToString();
                }
                if (reader["mphone"] != null && reader["mphone"].ToString() != "")
                {
                    model.mphone = reader["mphone"].ToString();
                }
                if (reader["fax"] != null && reader["fax"].ToString() != "")
                {
                    model.fax = reader["fax"].ToString();
                }
                if (reader["email"] != null && reader["email"].ToString() != "")
                {
                    model.email = reader["email"].ToString();
                }
                if (reader["postcode"] != null && reader["postcode"].ToString() != "")
                {
                    model.postcode = reader["postcode"].ToString();
                }
                if (reader["homepage"] != null && reader["homepage"].ToString() != "")
                {
                    model.homepage = reader["homepage"].ToString();
                }
                if (reader["domain"] != null && reader["domain"].ToString() != "")
                {
                    model.domain = reader["domain"].ToString();
                }
                if (reader["domainip"] != null && reader["domainip"].ToString() != "")
                {
                    model.domainip = reader["domainip"].ToString();
                }
                if (reader["icp"] != null && reader["icp"].ToString() != "")
                {
                    model.icp = reader["icp"].ToString();
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["logo"] != null && reader["logo"].ToString() != "")
                {
                    model.logo = reader["logo"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["desimage"] != null && reader["desimage"].ToString() != "")
                {
                    model.desimage = reader["desimage"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["keywords"] != null && reader["keywords"].ToString() != "")
                {
                    model.keywords = reader["keywords"].ToString();
                }
                if (reader["template"] != null && reader["template"].ToString() != "")
                {
                    model.template = reader["template"].ToString();
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["marketid"] != null && reader["marketid"].ToString() != "")
                {
                    model.marketid = int.Parse(reader["marketid"].ToString());
                }

                if (reader["marketname"] != null && reader["marketname"].ToString() != "")
                {
                    model.marketname = reader["marketname"].ToString();
                }
                if (reader["cid"] != null && reader["cid"].ToString() != "")
                {
                    model.cid = int.Parse(reader["cid"].ToString());
                }
                if (reader["ctype"] != null && reader["ctype"].ToString() != "")
                {
                    model.ctype = int.Parse(reader["ctype"].ToString());
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["qq"] != null && reader["qq"].ToString() != "")
                {
                    model.qq = reader["qq"].ToString();
                }
            }
            if (!reader.IsClosed)
                reader.Close();
            return model;
        }


        //店铺列表
        public static List<EnWebShop> GetWebShopList(int PageIndex, int PageSize, string strWhere, string sortkey, string ordertype, out int pageCount)
        {
            List<EnWebShop> list = new List<EnWebShop>();
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TVShopList, PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);
            while (reader.Read())
            {
                EnWebShop model = new EnWebShop();
                if (reader["brandxml"] != null && reader["brandxml"].ToString() != "")
                {
                    model.brandxml = reader["brandxml"].ToString();
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["productcount"] != null && reader["productcount"].ToString() != "")
                {
                    model.productcount = int.Parse(reader["productcount"].ToString());
                }
                if (reader["mid"] != null && reader["mid"].ToString() != "")
                {
                    model.mid = int.Parse(reader["mid"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["groupid"] != null && reader["groupid"].ToString() != "")
                {
                    model.groupid = int.Parse(reader["groupid"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["industry"] != null && reader["industry"].ToString() != "")
                {
                    model.industry = reader["industry"].ToString();
                }
                if (reader["productcategory"] != null && reader["productcategory"].ToString() != "")
                {
                    model.productcategory = reader["productcategory"].ToString();
                }
                if (reader["vip"] != null && reader["vip"].ToString() != "")
                {
                    model.vip = int.Parse(reader["vip"].ToString());
                }
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
                }
                if (reader["mapapi"] != null && reader["mapapi"].ToString() != "")
                {
                    model.mapapi = reader["mapapi"].ToString();
                }
                if (reader["staffsize"] != null && reader["staffsize"].ToString() != "")
                {
                    model.staffsize = int.Parse(reader["staffsize"].ToString());
                }
                if (reader["regyear"] != null && reader["regyear"].ToString() != "")
                {
                    model.regyear = reader["regyear"].ToString();
                }
                if (reader["regcity"] != null && reader["regcity"].ToString() != "")
                {
                    model.regcity = reader["regcity"].ToString();
                }
                if (reader["buy"] != null && reader["buy"].ToString() != "")
                {
                    model.buy = reader["buy"].ToString();
                }
                if (reader["sell"] != null && reader["sell"].ToString() != "")
                {
                    model.sell = reader["sell"].ToString();
                }
                if (reader["linkman"] != null && reader["linkman"].ToString() != "")
                {
                    model.linkman = reader["linkman"].ToString();
                }
                if (reader["phone"] != null && reader["phone"].ToString() != "")
                {
                    model.phone = reader["phone"].ToString();
                }
                if (reader["mphone"] != null && reader["mphone"].ToString() != "")
                {
                    model.mphone = reader["mphone"].ToString();
                }
                if (reader["fax"] != null && reader["fax"].ToString() != "")
                {
                    model.fax = reader["fax"].ToString();
                }
                if (reader["email"] != null && reader["email"].ToString() != "")
                {
                    model.email = reader["email"].ToString();
                }
                if (reader["postcode"] != null && reader["postcode"].ToString() != "")
                {
                    model.postcode = reader["postcode"].ToString();
                }
                if (reader["homepage"] != null && reader["homepage"].ToString() != "")
                {
                    model.homepage = reader["homepage"].ToString();
                }
                if (reader["domain"] != null && reader["domain"].ToString() != "")
                {
                    model.domain = reader["domain"].ToString();
                }
                if (reader["domainip"] != null && reader["domainip"].ToString() != "")
                {
                    model.domainip = reader["domainip"].ToString();
                }
                if (reader["icp"] != null && reader["icp"].ToString() != "")
                {
                    model.icp = reader["icp"].ToString();
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["logo"] != null && reader["logo"].ToString() != "")
                {
                    model.logo = reader["logo"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["desimage"] != null && reader["desimage"].ToString() != "")
                {
                    model.desimage = reader["desimage"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["keywords"] != null && reader["keywords"].ToString() != "")
                {
                    model.keywords = reader["keywords"].ToString();
                }
                if (reader["template"] != null && reader["template"].ToString() != "")
                {
                    model.template = reader["template"].ToString();
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["marketid"] != null && reader["marketid"].ToString() != "")
                {
                    model.marketid = int.Parse(reader["marketid"].ToString());
                }
                if (reader["marketname"] != null && reader["marketname"].ToString() != "")
                {
                    model.marketname = reader["marketname"].ToString();
                }
                if (reader["cid"] != null && reader["cid"].ToString() != "")
                {
                    model.cid = int.Parse(reader["cid"].ToString());
                }
                if (reader["ctype"] != null && reader["ctype"].ToString() != "")
                {
                    model.ctype = int.Parse(reader["ctype"].ToString());
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["qq"] != null && reader["qq"].ToString() != "")
                {
                    model.qq = reader["qq"].ToString();
                }
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;
        }

        //品牌店铺
        public static List<EnWebShopBrand> GetWebShopBrandList(int PageIndex, int PageSize, string strWhere, string sortkey, string ordertype, out int pageCount)
        {
            List<EnWebShopBrand> list = new List<EnWebShopBrand>();
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TVShopBrandList, PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);
            while (reader.Read())
            {
                EnWebShopBrand model = new EnWebShopBrand();
                if (reader["shopxml"] != null && reader["shopxml"].ToString() != "")
                {
                    model.shopxml = reader["shopxml"].ToString();
                }
                if (reader["Promotionxml"] != null && reader["Promotionxml"].ToString() != "")
                {
                    model.Promotionxml = reader["Promotionxml"].ToString();
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["companyid"] != null && reader["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(reader["companyid"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["groupid"] != null && reader["groupid"].ToString() != "")
                {
                    model.groupid = int.Parse(reader["groupid"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["productcategory"] != null && reader["productcategory"].ToString() != "")
                {
                    model.productcategory = reader["productcategory"].ToString();
                }
                if (reader["homepage"] != null && reader["homepage"].ToString() != "")
                {
                    model.homepage = reader["homepage"].ToString();
                }
                if (reader["productcount"] != null && reader["productcount"].ToString() != "")
                {
                    model.productcount = int.Parse(reader["productcount"].ToString());
                }
                if (reader["spread"] != null && reader["spread"].ToString() != "")
                {
                    model.spread = reader["spread"].ToString();
                }
                if (reader["material"] != null && reader["material"].ToString() != "")
                {
                    model.material = reader["material"].ToString();
                }
                if (reader["style"] != null && reader["style"].ToString() != "")
                {
                    model.style = reader["style"].ToString();
                }
                if (reader["color"] != null && reader["color"].ToString() != "")
                {
                    model.color = reader["color"].ToString();
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["logo"] != null && reader["logo"].ToString() != "")
                {
                    model.logo = reader["logo"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["desimage"] != null && reader["desimage"].ToString() != "")
                {
                    model.desimage = reader["desimage"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["keywords"] != null && reader["keywords"].ToString() != "")
                {
                    model.keywords = reader["keywords"].ToString();
                }
                if (reader["template"] != null && reader["template"].ToString() != "")
                {
                    model.template = reader["template"].ToString();
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["lasteditid"] != null && reader["lasteditid"].ToString() != "")
                {
                    model.lasteditid = int.Parse(reader["lasteditid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;
        }

        //店铺搜索选项
        public static List<EnSearchItem> GetShopSearchItem()
        {
            List<EnSearchItem> list = new List<EnSearchItem>();
            IDataReader reader = DbHelper.ExecuteReader(" select * from " + TableName.TVShopSearchItem);
            while (reader.Read())
            {
                EnSearchItem model = new EnSearchItem();
                if (reader["t"] != null && reader["t"].ToString() != "")
                {
                    model.type = reader["t"].ToString();
                }
                if (reader["v"] != null && reader["v"].ToString() != "")
                {
                    model.value = reader["v"].ToString();
                }
                if (reader["n"] != null && reader["n"].ToString() != "")
                {
                    model.title = reader["n"].ToString();
                }
                if (reader["c"] != null && reader["c"].ToString() != "")
                {
                    model.count = int.Parse(reader["c"].ToString());
                }
                model.isCur = false;
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;
        }


        #region 店铺品牌


        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditShopBrand(List<EnShopBrand> list)
        {
            List<CommandInfo> cmdList = new List<CommandInfo>();

            //更新前删除
            CommandInfo delShopBrand = new CommandInfo();
            delShopBrand.CommandText = "delete from t_shopbrand where shopid=" + list[0].shopid;
            delShopBrand.EffentNextType = EffentNextType.None;
            cmdList.Add(delShopBrand);


            foreach (EnShopBrand sb in list)
            {
                if (sb.brandid != 0)
                {
                    CommandInfo model = new CommandInfo();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into t_shopbrand(");
                    strSql.Append("shopid,brandid)");
                    strSql.Append(" values (");
                    strSql.Append("@shopid,@brandid)");
                    SqlParameter[] parameters = {
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@brandid", SqlDbType.Int,4)};
                    parameters[0].Value = sb.shopid;
                    parameters[1].Value = sb.brandid;

                    model.CommandText = strSql.ToString();
                    model.Parameters = parameters;
                    model.EffentNextType = EffentNextType.ExcuteEffectRows;
                    cmdList.Add(model);
                }

            }

            return DbHelper.ExecuteSqlTran(cmdList);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShopBrand> GetShopBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnShopBrand> modelList = new List<EnShopBrand>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBShopBrand, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnShopBrand model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnShopBrand();
                    if (dt.Rows[n]["shopid"] != null && dt.Rows[n]["shopid"].ToString() != "")
                    {
                        model.shopid = int.Parse(dt.Rows[n]["shopid"].ToString());
                    }
                    if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
                    {
                        model.brandid = int.Parse(dt.Rows[n]["brandid"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShopBrand> GetShopBrandList(string strWhere)
        {
            List<EnShopBrand> modelList = new List<EnShopBrand>();
            IDataReader reader = DbHelper.ExecuteReader(" select * from " + TableName.TBShopBrand + " " + strWhere);
            while (reader.Read())
            {
                EnShopBrand model = new EnShopBrand();
                if (reader["shopid"] != null && reader["shopid"].ToString() != "")
                {
                    model.shopid = int.Parse(reader["shopid"].ToString());
                }
                if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                {
                    model.brandid = int.Parse(reader["brandid"].ToString());
                }
                modelList.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<Hashtable> GetShopBrandList(int shopid)
        {
            List<Hashtable> modelList = new List<Hashtable>();
            IDataReader reader = DbHelper.ExecuteReader(" select b.id,b.title from " + TableName.TBShopBrand + " a left join " + TableName.TBBrand + "  b on a.brandid=b.id where shopid=" + shopid);
            while (reader.Read())
            {
                Hashtable model = new Hashtable();
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model["BrandName"] = reader["title"].ToString();
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model["BrandId"] = int.Parse(reader["id"].ToString());
                }
                modelList.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return modelList;
        }

        #endregion

        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditShop(EnShop model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_shop(");
                strSql.Append("mid,title,letter,groupid,attribute,industry,productcategory,vip,areacode,address,mapapi,staffsize,regyear,regcity,buy,sell,linkman,phone,mphone,fax,email,postcode,homepage,domain,domainip,icp,surface,logo,thumb,bannel,desimage,descript,keywords,template,hits,sort,marketid,cid,ctype,createmid,lastedid,lastedittime,auditstatus,linestatus,qq,ShopContact,FirstClerkMobile,SecondClerk,SecondClerkMobile,IsPay,isshopshare,PavilionId)");
                strSql.Append(" values (");
                strSql.Append("@mid,@title,@letter,@groupid,@attribute,@industry,@productcategory,@vip,@areacode,@address,@mapapi,@staffsize,@regyear,@regcity,@buy,@sell,@linkman,@phone,@mphone,@fax,@email,@postcode,@homepage,@domain,@domainip,@icp,@surface,@logo,@thumb,@bannel,@desimage,@descript,@keywords,@template,@hits,@sort,@marketid,@cid,@ctype,@createmid,@lastedid,@lastedittime,@auditstatus,@linestatus,@qq,@ShopContact,@FirstClerkMobile,@SecondClerk,@SecondClerkMobile,@IsPay,@isshopshare,@PavilionId)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@attribute", SqlDbType.VarChar,100),
					new SqlParameter("@industry", SqlDbType.VarChar,50),
					new SqlParameter("@productcategory", SqlDbType.VarChar,50),
					new SqlParameter("@vip", SqlDbType.Int,4),
					new SqlParameter("@areacode", SqlDbType.VarChar,10),
					new SqlParameter("@address", SqlDbType.NVarChar,60),
					new SqlParameter("@mapapi", SqlDbType.NVarChar,80),
					new SqlParameter("@staffsize", SqlDbType.Int,4),
					new SqlParameter("@regyear", SqlDbType.VarChar,7),
					new SqlParameter("@regcity", SqlDbType.VarChar,10),
					new SqlParameter("@buy", SqlDbType.NVarChar,300),
					new SqlParameter("@sell", SqlDbType.NVarChar,300),
					new SqlParameter("@linkman", SqlDbType.NVarChar,20),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@mphone", SqlDbType.VarChar,20),
					new SqlParameter("@fax", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@postcode", SqlDbType.VarChar,15),
					new SqlParameter("@homepage", SqlDbType.VarChar,50),
					new SqlParameter("@domain", SqlDbType.VarChar,50),
					new SqlParameter("@domainip", SqlDbType.VarChar,50),
					new SqlParameter("@icp", SqlDbType.NVarChar,50),
					new SqlParameter("@surface", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,40),
					new SqlParameter("@thumb", SqlDbType.VarChar,40),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@desimage", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@template", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@marketid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@ctype", SqlDbType.Int,4),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
                    new SqlParameter("@qq",SqlDbType.VarChar,20),
                    new SqlParameter("@ShopContact",SqlDbType.NVarChar,20),
                    new SqlParameter("@FirstClerkMobile",SqlDbType.VarChar,30),
                    new SqlParameter("@SecondClerk",SqlDbType.NVarChar,20),
                    new SqlParameter("@SecondClerkMobile",SqlDbType.VarChar,30),
                    new SqlParameter("@IsPay",SqlDbType.Int,4),
                    new SqlParameter("@isshopshare",SqlDbType.Int,4),
                    new SqlParameter("@PavilionId",SqlDbType.Int)
                    

                    };
                parameters[0].Value = model.mid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.letter;
                parameters[3].Value = model.groupid;
                parameters[4].Value = model.attribute;
                parameters[5].Value = model.industry;
                parameters[6].Value = model.productcategory;
                parameters[7].Value = model.vip;
                parameters[8].Value = model.areacode;
                parameters[9].Value = model.address;
                parameters[10].Value = model.mapapi;
                parameters[11].Value = model.staffsize;
                parameters[12].Value = model.regyear;
                parameters[13].Value = model.regcity;
                parameters[14].Value = model.buy;
                parameters[15].Value = model.sell;
                parameters[16].Value = model.linkman;
                parameters[17].Value = model.phone;
                parameters[18].Value = model.mphone;
                parameters[19].Value = model.fax;
                parameters[20].Value = model.email;
                parameters[21].Value = model.postcode;
                parameters[22].Value = model.homepage;
                parameters[23].Value = model.domain;
                parameters[24].Value = model.domainip;
                parameters[25].Value = model.icp;
                parameters[26].Value = model.surface;
                parameters[27].Value = model.logo;
                parameters[28].Value = model.thumb;
                parameters[29].Value = model.bannel;
                parameters[30].Value = model.desimage;
                parameters[31].Value = model.descript;
                parameters[32].Value = model.keywords;
                parameters[33].Value = model.template;
                parameters[34].Value = model.hits;
                parameters[35].Value = model.sort;
                parameters[36].Value = model.marketid;
                parameters[37].Value = model.cid;
                parameters[38].Value = model.ctype;
                parameters[39].Value = model.createmid;
                parameters[40].Value = model.lastedid;
                parameters[41].Value = model.lastedittime;
                parameters[42].Value = model.auditstatus;
                parameters[43].Value = model.linestatus;
                parameters[44].Value = model.qq;
                parameters[45].Value = model.ShopContact;
                parameters[46].Value = model.FirstClerkMobile;
                parameters[47].Value = model.SecondClerk;
                parameters[48].Value = model.SecondClerkMobile;
                parameters[49].Value = model.IsPay;
                parameters[50].Value = model.isshopshare;
                parameters[51].Value = model.PavilionId;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_shop set ");
                strSql.Append("mid=@mid,");
                strSql.Append("title=@title,");
                strSql.Append("letter=@letter,");
                strSql.Append("groupid=@groupid,");
                strSql.Append("attribute=@attribute,");
                strSql.Append("industry=@industry,");
                strSql.Append("productcategory=@productcategory,");
                strSql.Append("vip=@vip,");
                strSql.Append("areacode=@areacode,");
                strSql.Append("address=@address,");
                strSql.Append("mapapi=@mapapi,");
                strSql.Append("staffsize=@staffsize,");
                strSql.Append("regyear=@regyear,");
                strSql.Append("regcity=@regcity,");
                strSql.Append("buy=@buy,");
                strSql.Append("sell=@sell,");
                strSql.Append("linkman=@linkman,");
                strSql.Append("phone=@phone,");
                strSql.Append("mphone=@mphone,");
                strSql.Append("fax=@fax,");
                strSql.Append("email=@email,");
                strSql.Append("postcode=@postcode,");
                strSql.Append("homepage=@homepage,");
                strSql.Append("domain=@domain,");
                strSql.Append("domainip=@domainip,");
                strSql.Append("icp=@icp,");
                strSql.Append("surface=@surface,");
                strSql.Append("logo=@logo,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("bannel=@bannel,");
                strSql.Append("desimage=@desimage,");
                strSql.Append("descript=@descript,");
                strSql.Append("keywords=@keywords,");
                strSql.Append("template=@template,");
                strSql.Append("hits=@hits,");
                strSql.Append("sort=@sort,");
                strSql.Append("marketid=@marketid,");
                strSql.Append("cid=@cid,");
                strSql.Append("ctype=@ctype,");
                strSql.Append("createmid=@createmid,");
                strSql.Append("lastedid=@lastedid,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("auditstatus=@auditstatus,");
                strSql.Append("linestatus=@linestatus,");
                strSql.Append("qq=@qq,");
                strSql.Append("ShopContact=@ShopContact,");
                strSql.Append("FirstClerkMobile=@FirstClerkMobile,");
                strSql.Append("SecondClerk=@SecondClerk,");
                strSql.Append("SecondClerkMobile=@SecondClerkMobile,");
                strSql.Append("IsPay=@IsPay,");
                strSql.Append("isshopshare=@isshopshare,");
                strSql.Append("PavilionId=@PavilionId");
                strSql.Append(" where id=@id");

                SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@letter", SqlDbType.VarChar,20),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@attribute", SqlDbType.VarChar,100),
					new SqlParameter("@industry", SqlDbType.VarChar,50),
					new SqlParameter("@productcategory", SqlDbType.VarChar,50),
					new SqlParameter("@vip", SqlDbType.Int,4),
					new SqlParameter("@areacode", SqlDbType.VarChar,10),
					new SqlParameter("@address", SqlDbType.NVarChar,60),
					new SqlParameter("@mapapi", SqlDbType.NVarChar,80),
					new SqlParameter("@staffsize", SqlDbType.Int,4),
					new SqlParameter("@regyear", SqlDbType.VarChar,7),
					new SqlParameter("@regcity", SqlDbType.VarChar,10),
					new SqlParameter("@buy", SqlDbType.NVarChar,300),
					new SqlParameter("@sell", SqlDbType.NVarChar,300),
					new SqlParameter("@linkman", SqlDbType.NVarChar,20),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@mphone", SqlDbType.VarChar,20),
					new SqlParameter("@fax", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@postcode", SqlDbType.VarChar,15),
					new SqlParameter("@homepage", SqlDbType.VarChar,50),
					new SqlParameter("@domain", SqlDbType.VarChar,50),
					new SqlParameter("@domainip", SqlDbType.VarChar,50),
					new SqlParameter("@icp", SqlDbType.NVarChar,50),
					new SqlParameter("@surface", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,40),
					new SqlParameter("@thumb", SqlDbType.VarChar,40),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@desimage", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@template", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@marketid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@ctype", SqlDbType.Int,4),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@qq",SqlDbType.VarChar,20),
                    new SqlParameter("@ShopContact",SqlDbType.NVarChar,20),
                    new SqlParameter("@FirstClerkMobile",SqlDbType.VarChar,30),
                    new SqlParameter("@SecondClerk",SqlDbType.NVarChar,20),
                    new SqlParameter("@SecondClerkMobile",SqlDbType.VarChar,30),
                    new SqlParameter("@IsPay",SqlDbType.Int,4),
                    new SqlParameter("@isshopshare",SqlDbType.Int,4),
                    new SqlParameter("@PavilionId",SqlDbType.Int)
                    };
                parameters[0].Value = model.mid;
                parameters[1].Value = model.title;
                parameters[2].Value = model.letter;
                parameters[3].Value = model.groupid;
                parameters[4].Value = model.attribute;
                parameters[5].Value = model.industry;
                parameters[6].Value = model.productcategory;
                parameters[7].Value = model.vip;
                parameters[8].Value = model.areacode;
                parameters[9].Value = model.address;
                parameters[10].Value = model.mapapi;
                parameters[11].Value = model.staffsize;
                parameters[12].Value = model.regyear;
                parameters[13].Value = model.regcity;
                parameters[14].Value = model.buy;
                parameters[15].Value = model.sell;
                parameters[16].Value = model.linkman;
                parameters[17].Value = model.phone;
                parameters[18].Value = model.mphone;
                parameters[19].Value = model.fax;
                parameters[20].Value = model.email;
                parameters[21].Value = model.postcode;
                parameters[22].Value = model.homepage;
                parameters[23].Value = model.domain;
                parameters[24].Value = model.domainip;
                parameters[25].Value = model.icp;
                parameters[26].Value = model.surface;
                parameters[27].Value = model.logo;
                parameters[28].Value = model.thumb;
                parameters[29].Value = model.bannel;
                parameters[30].Value = model.desimage;
                parameters[31].Value = model.descript;
                parameters[32].Value = model.keywords;
                parameters[33].Value = model.template;
                parameters[34].Value = model.hits;
                parameters[35].Value = model.sort;
                parameters[36].Value = model.marketid;
                parameters[37].Value = model.cid;
                parameters[38].Value = model.ctype;
                parameters[39].Value = model.createmid;
                parameters[40].Value = model.lastedid;
                parameters[41].Value = model.lastedittime;
                parameters[42].Value = model.auditstatus;
                parameters[43].Value = model.linestatus;
                parameters[44].Value = model.id;
                parameters[45].Value = model.qq;
                parameters[46].Value = model.ShopContact;
                parameters[47].Value = model.FirstClerkMobile;
                parameters[48].Value = model.SecondClerk;
                parameters[49].Value = model.SecondClerkMobile;
                parameters[50].Value = model.IsPay;
                parameters[51].Value = model.isshopshare;
                parameters[52].Value = model.PavilionId;
                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.id;
                }
            }

            return 0;

        }
        /// <summary>
        /// 获取品牌推荐店铺
        /// </summary>
        /// <param name="brandTitle"></param>
        /// <returns></returns>
        public static DataSet GetBrandShop(string brandTitle)
        {
            StringBuilder _sql = new StringBuilder("SELECT s.*,CASE WHEN s.ctype=101 THEN '工厂直销' WHEN s.ctype=102 THEN '经销商' END AS ctypename,");
            _sql.Append("(SELECT TOP 1 stylename FROM dbo.t_productrecyclerecycle WHERE stylevalue=tb.style) AS stylename,");
            _sql.Append(" ISNULL((SELECT  TOP 1 CASE WHEN RegEndTime>=GETDATE() THEN 1 ELSE 0 end  FROM dbo.t_member WHERE id=s.createmid),0) AS companyispay,");
            _sql.Append(" (SELECT areaname FROM dbo.t_area WHERE areacode=s.areacode) AS areaname,");
            _sql.Append("(SELECT top 2 promotionstitle,id,'/shop/'+CONVERT(NVARCHAR(100),shopid)+'/promotions/'+CONVERT(NVARCHAR(100),id)+'/info.aspx' AS url FROM t_promotionsrelated WHERE shopid=s.id FOR XML path('type')) AS promotion");
            _sql.Append(" FROM dbo.t_shop s RIGHT join t_shopbrand b ON s.id=b.shopid ");
            _sql.Append(" LEFT JOIN t_brand tb ON b.brandid=tb.id WHERE tb.title=@brandTitle and s.auditstatus=1 and s.linestatus=1  ");

            SqlParameter[] parameters = {
					new SqlParameter("@brandTitle", SqlDbType.NVarChar,20)
                                         };
            parameters[0].Value=brandTitle;

            return DbHelper.ExecuteDataset(CommandType.Text, _sql.ToString(), parameters);
        }
        /// <summary>
        /// 获取厂商信息
        /// </summary>
        /// <param name="brandTitle"></param>
        /// <returns></returns>
        public static DataSet getBrandCompany(string brandTitle)
        {
            StringBuilder _sql = new StringBuilder("SELECT * FROM dbo.t_company WHERE id in (SELECT TOP 1 companyid FROM dbo.t_brand WHERE title=@brandTitle AND companyid>0)");//厂商信息
            _sql.Append(" SELECT * FROM dbo.t_brand WHERE companyid IN(SELECT TOP 1 companyid FROM dbo.t_brand WHERE title=@brandTitle AND companyid>0) ");//厂商下所有品牌

            _sql.Append("  SELECT * FROM dbo.t_dealer  WHERE id IN( SELECT TOP 1 mid FROM dbo.t_brand WHERE title=@brandTitle AND companyid=0) ");//经销商信息
            _sql.Append("  SELECT TOP 1 *,(   SELECT TOP 1 stylename FROM t_productrecyclerecycle WHERE brandid=t_brand.id  ) as stylename,(   SELECT TOP 1 materialname FROM t_productrecyclerecycle WHERE brandid=t_brand.id ) as materialname FROM dbo.t_brand WHERE title=@brandTitle ");//经销商下的品牌


            SqlParameter[] parameters = {
					new SqlParameter("@brandTitle", SqlDbType.NVarChar,20)
                                         };
            parameters[0].Value = brandTitle;

            return DbHelper.ExecuteDataset(CommandType.Text, _sql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnShop GetShopInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  *,(case when IsPay is null then 0 else (cast(IsPay as int)) end) as myIsPay from t_Shop ");
            strSql.Append(strWhere);


            EnShop model = new EnShop();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["mid"] != null && reader["mid"].ToString() != "")
                {
                    model.mid = int.Parse(reader["mid"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["groupid"] != null && reader["groupid"].ToString() != "")
                {
                    model.groupid = int.Parse(reader["groupid"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["industry"] != null && reader["industry"].ToString() != "")
                {
                    model.industry = reader["industry"].ToString();
                }
                if (reader["productcategory"] != null && reader["productcategory"].ToString() != "")
                {
                    model.productcategory = reader["productcategory"].ToString();
                }
                if (reader["vip"] != null && reader["vip"].ToString() != "")
                {
                    model.vip = int.Parse(reader["vip"].ToString());
                }
                if (reader["areacode"] != null && reader["areacode"].ToString() != "")
                {
                    model.areacode = reader["areacode"].ToString();
                }
                if (reader["address"] != null && reader["address"].ToString() != "")
                {
                    model.address = reader["address"].ToString();
                }
                if (reader["mapapi"] != null && reader["mapapi"].ToString() != "")
                {
                    model.mapapi = reader["mapapi"].ToString();
                }
                if (reader["staffsize"] != null && reader["staffsize"].ToString() != "")
                {
                    model.staffsize = int.Parse(reader["staffsize"].ToString());
                }
                if (reader["regyear"] != null && reader["regyear"].ToString() != "")
                {
                    model.regyear = reader["regyear"].ToString();
                }
                if (reader["regcity"] != null && reader["regcity"].ToString() != "")
                {
                    model.regcity = reader["regcity"].ToString();
                }
                if (reader["buy"] != null && reader["buy"].ToString() != "")
                {
                    model.buy = reader["buy"].ToString();
                }
                if (reader["sell"] != null && reader["sell"].ToString() != "")
                {
                    model.sell = reader["sell"].ToString();
                }
                if (reader["linkman"] != null && reader["linkman"].ToString() != "")
                {
                    model.linkman = reader["linkman"].ToString();
                }
                if (reader["phone"] != null && reader["phone"].ToString() != "")
                {
                    model.phone = reader["phone"].ToString();
                }
                if (reader["mphone"] != null && reader["mphone"].ToString() != "")
                {
                    model.mphone = reader["mphone"].ToString();
                }
                if (reader["fax"] != null && reader["fax"].ToString() != "")
                {
                    model.fax = reader["fax"].ToString();
                }
                if (reader["email"] != null && reader["email"].ToString() != "")
                {
                    model.email = reader["email"].ToString();
                }
                if (reader["postcode"] != null && reader["postcode"].ToString() != "")
                {
                    model.postcode = reader["postcode"].ToString();
                }
                if (reader["homepage"] != null && reader["homepage"].ToString() != "")
                {
                    model.homepage = reader["homepage"].ToString();
                }
                if (reader["domain"] != null && reader["domain"].ToString() != "")
                {
                    model.domain = reader["domain"].ToString();
                }
                if (reader["domainip"] != null && reader["domainip"].ToString() != "")
                {
                    model.domainip = reader["domainip"].ToString();
                }
                if (reader["icp"] != null && reader["icp"].ToString() != "")
                {
                    model.icp = reader["icp"].ToString();
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["logo"] != null && reader["logo"].ToString() != "")
                {
                    model.logo = reader["logo"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["desimage"] != null && reader["desimage"].ToString() != "")
                {
                    model.desimage = reader["desimage"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["keywords"] != null && reader["keywords"].ToString() != "")
                {
                    model.keywords = reader["keywords"].ToString();
                }
                if (reader["template"] != null && reader["template"].ToString() != "")
                {
                    model.template = reader["template"].ToString();
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["marketid"] != null && reader["marketid"].ToString() != "")
                {
                    model.marketid = int.Parse(reader["marketid"].ToString());
                }
                if (reader["cid"] != null && reader["cid"].ToString() != "")
                {
                    model.cid = int.Parse(reader["cid"].ToString());
                }
                if (reader["ctype"] != null && reader["ctype"].ToString() != "")
                {
                    model.ctype = int.Parse(reader["ctype"].ToString());
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["qq"] != null && reader["qq"].ToString() != "")
                {
                    model.qq = reader["qq"].ToString();
                }
                if (reader["ShopContact"] != null && reader["ShopContact"].ToString() != "")
                {
                    model.ShopContact = reader["ShopContact"].ToString();
                }
                if (reader["FirstClerkMobile"] != null && reader["FirstClerkMobile"].ToString() != "")
                {
                    model.FirstClerkMobile = reader["FirstClerkMobile"].ToString();
                }
                if (reader["SecondClerk"] != null && reader["SecondClerk"].ToString() != "")
                {
                    model.SecondClerk = reader["SecondClerk"].ToString();
                }
                if (reader["SecondClerkMobile"] != null && reader["SecondClerkMobile"].ToString() != "")
                {
                    model.SecondClerkMobile = reader["SecondClerkMobile"].ToString();
                }
                if (reader["myIsPay"] != null && reader["myIsPay"].ToString() != "")
                {
                    model.IsPay = Convert.ToInt32(reader["myIsPay"].ToString());
                }
                else
                    model.IsPay = 0;

                if (reader["isshopshare"] != null && reader["isshopshare"].ToString() != "")
                {
                    model.isshopshare = Convert.ToInt32(reader["isshopshare"].ToString());
                }
                if (reader["PavilionId"] != null && reader["PavilionId"].ToString() != "")
                {
                    model.PavilionId = Convert.ToInt32(reader["PavilionId"].ToString());
                }
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return model;
            }
            else
            {
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShop> GetShopList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnShop> modelList = new List<EnShop>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBShop, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnShop model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnShop();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["mid"] != null && dt.Rows[n]["mid"].ToString() != "")
                    {
                        model.mid = int.Parse(dt.Rows[n]["mid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["groupid"] != null && dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["industry"] != null && dt.Rows[n]["industry"].ToString() != "")
                    {
                        model.industry = dt.Rows[n]["industry"].ToString();
                    }
                    if (dt.Rows[n]["productcategory"] != null && dt.Rows[n]["productcategory"].ToString() != "")
                    {
                        model.productcategory = dt.Rows[n]["productcategory"].ToString();
                    }
                    if (dt.Rows[n]["vip"] != null && dt.Rows[n]["vip"].ToString() != "")
                    {
                        model.vip = int.Parse(dt.Rows[n]["vip"].ToString());
                    }
                    if (dt.Rows[n]["areacode"] != null && dt.Rows[n]["areacode"].ToString() != "")
                    {
                        model.areacode = dt.Rows[n]["areacode"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["mapapi"] != null && dt.Rows[n]["mapapi"].ToString() != "")
                    {
                        model.mapapi = dt.Rows[n]["mapapi"].ToString();
                    }
                    if (dt.Rows[n]["staffsize"] != null && dt.Rows[n]["staffsize"].ToString() != "")
                    {
                        model.staffsize = int.Parse(dt.Rows[n]["staffsize"].ToString());
                    }
                    if (dt.Rows[n]["regyear"] != null && dt.Rows[n]["regyear"].ToString() != "")
                    {
                        model.regyear = dt.Rows[n]["regyear"].ToString();
                    }
                    if (dt.Rows[n]["regcity"] != null && dt.Rows[n]["regcity"].ToString() != "")
                    {
                        model.regcity = dt.Rows[n]["regcity"].ToString();
                    }
                    if (dt.Rows[n]["buy"] != null && dt.Rows[n]["buy"].ToString() != "")
                    {
                        model.buy = dt.Rows[n]["buy"].ToString();
                    }
                    if (dt.Rows[n]["sell"] != null && dt.Rows[n]["sell"].ToString() != "")
                    {
                        model.sell = dt.Rows[n]["sell"].ToString();
                    }
                    if (dt.Rows[n]["linkman"] != null && dt.Rows[n]["linkman"].ToString() != "")
                    {
                        model.linkman = dt.Rows[n]["linkman"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["mphone"] != null && dt.Rows[n]["mphone"].ToString() != "")
                    {
                        model.mphone = dt.Rows[n]["mphone"].ToString();
                    }
                    if (dt.Rows[n]["fax"] != null && dt.Rows[n]["fax"].ToString() != "")
                    {
                        model.fax = dt.Rows[n]["fax"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["postcode"] != null && dt.Rows[n]["postcode"].ToString() != "")
                    {
                        model.postcode = dt.Rows[n]["postcode"].ToString();
                    }
                    if (dt.Rows[n]["homepage"] != null && dt.Rows[n]["homepage"].ToString() != "")
                    {
                        model.homepage = dt.Rows[n]["homepage"].ToString();
                    }
                    if (dt.Rows[n]["domain"] != null && dt.Rows[n]["domain"].ToString() != "")
                    {
                        model.domain = dt.Rows[n]["domain"].ToString();
                    }
                    if (dt.Rows[n]["domainip"] != null && dt.Rows[n]["domainip"].ToString() != "")
                    {
                        model.domainip = dt.Rows[n]["domainip"].ToString();
                    }
                    if (dt.Rows[n]["icp"] != null && dt.Rows[n]["icp"].ToString() != "")
                    {
                        model.icp = dt.Rows[n]["icp"].ToString();
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["desimage"] != null && dt.Rows[n]["desimage"].ToString() != "")
                    {
                        model.desimage = dt.Rows[n]["desimage"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["keywords"] != null && dt.Rows[n]["keywords"].ToString() != "")
                    {
                        model.keywords = dt.Rows[n]["keywords"].ToString();
                    }
                    if (dt.Rows[n]["template"] != null && dt.Rows[n]["template"].ToString() != "")
                    {
                        model.template = dt.Rows[n]["template"].ToString();
                    }
                    if (dt.Rows[n]["hits"] != null && dt.Rows[n]["hits"].ToString() != "")
                    {
                        model.hits = int.Parse(dt.Rows[n]["hits"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["marketid"] != null && dt.Rows[n]["marketid"].ToString() != "")
                    {
                        model.marketid = int.Parse(dt.Rows[n]["marketid"].ToString());
                    }
                    if (dt.Rows[n]["cid"] != null && dt.Rows[n]["cid"].ToString() != "")
                    {
                        model.cid = int.Parse(dt.Rows[n]["cid"].ToString());
                    }
                    if (dt.Rows[n]["ctype"] != null && dt.Rows[n]["ctype"].ToString() != "")
                    {
                        model.ctype = int.Parse(dt.Rows[n]["ctype"].ToString());
                    }
                    if (dt.Rows[n]["createmid"] != null && dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    if (dt.Rows[n]["lastedid"] != null && dt.Rows[n]["lastedid"].ToString() != "")
                    {
                        model.lastedid = int.Parse(dt.Rows[n]["lastedid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["qq"] != null && dt.Rows[n]["qq"].ToString() != "")
                    {
                        model.qq = dt.Rows[n]["qq"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShop> GetRecycleShopList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnShop> modelList = new List<EnShop>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBRecycleShop, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnShop model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnShop();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["mid"] != null && dt.Rows[n]["mid"].ToString() != "")
                    {
                        model.mid = int.Parse(dt.Rows[n]["mid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["groupid"] != null && dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["industry"] != null && dt.Rows[n]["industry"].ToString() != "")
                    {
                        model.industry = dt.Rows[n]["industry"].ToString();
                    }
                    if (dt.Rows[n]["productcategory"] != null && dt.Rows[n]["productcategory"].ToString() != "")
                    {
                        model.productcategory = dt.Rows[n]["productcategory"].ToString();
                    }
                    if (dt.Rows[n]["vip"] != null && dt.Rows[n]["vip"].ToString() != "")
                    {
                        model.vip = int.Parse(dt.Rows[n]["vip"].ToString());
                    }
                    if (dt.Rows[n]["areacode"] != null && dt.Rows[n]["areacode"].ToString() != "")
                    {
                        model.areacode = dt.Rows[n]["areacode"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["mapapi"] != null && dt.Rows[n]["mapapi"].ToString() != "")
                    {
                        model.mapapi = dt.Rows[n]["mapapi"].ToString();
                    }
                    if (dt.Rows[n]["staffsize"] != null && dt.Rows[n]["staffsize"].ToString() != "")
                    {
                        model.staffsize = int.Parse(dt.Rows[n]["staffsize"].ToString());
                    }
                    if (dt.Rows[n]["regyear"] != null && dt.Rows[n]["regyear"].ToString() != "")
                    {
                        model.regyear = dt.Rows[n]["regyear"].ToString();
                    }
                    if (dt.Rows[n]["regcity"] != null && dt.Rows[n]["regcity"].ToString() != "")
                    {
                        model.regcity = dt.Rows[n]["regcity"].ToString();
                    }
                    if (dt.Rows[n]["buy"] != null && dt.Rows[n]["buy"].ToString() != "")
                    {
                        model.buy = dt.Rows[n]["buy"].ToString();
                    }
                    if (dt.Rows[n]["sell"] != null && dt.Rows[n]["sell"].ToString() != "")
                    {
                        model.sell = dt.Rows[n]["sell"].ToString();
                    }
                    if (dt.Rows[n]["linkman"] != null && dt.Rows[n]["linkman"].ToString() != "")
                    {
                        model.linkman = dt.Rows[n]["linkman"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["mphone"] != null && dt.Rows[n]["mphone"].ToString() != "")
                    {
                        model.mphone = dt.Rows[n]["mphone"].ToString();
                    }
                    if (dt.Rows[n]["fax"] != null && dt.Rows[n]["fax"].ToString() != "")
                    {
                        model.fax = dt.Rows[n]["fax"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["postcode"] != null && dt.Rows[n]["postcode"].ToString() != "")
                    {
                        model.postcode = dt.Rows[n]["postcode"].ToString();
                    }
                    if (dt.Rows[n]["homepage"] != null && dt.Rows[n]["homepage"].ToString() != "")
                    {
                        model.homepage = dt.Rows[n]["homepage"].ToString();
                    }
                    if (dt.Rows[n]["domain"] != null && dt.Rows[n]["domain"].ToString() != "")
                    {
                        model.domain = dt.Rows[n]["domain"].ToString();
                    }
                    if (dt.Rows[n]["domainip"] != null && dt.Rows[n]["domainip"].ToString() != "")
                    {
                        model.domainip = dt.Rows[n]["domainip"].ToString();
                    }
                    if (dt.Rows[n]["icp"] != null && dt.Rows[n]["icp"].ToString() != "")
                    {
                        model.icp = dt.Rows[n]["icp"].ToString();
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["desimage"] != null && dt.Rows[n]["desimage"].ToString() != "")
                    {
                        model.desimage = dt.Rows[n]["desimage"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["keywords"] != null && dt.Rows[n]["keywords"].ToString() != "")
                    {
                        model.keywords = dt.Rows[n]["keywords"].ToString();
                    }
                    if (dt.Rows[n]["template"] != null && dt.Rows[n]["template"].ToString() != "")
                    {
                        model.template = dt.Rows[n]["template"].ToString();
                    }
                    if (dt.Rows[n]["hits"] != null && dt.Rows[n]["hits"].ToString() != "")
                    {
                        model.hits = int.Parse(dt.Rows[n]["hits"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["marketid"] != null && dt.Rows[n]["marketid"].ToString() != "")
                    {
                        model.marketid = int.Parse(dt.Rows[n]["marketid"].ToString());
                    }
                    if (dt.Rows[n]["cid"] != null && dt.Rows[n]["cid"].ToString() != "")
                    {
                        model.cid = int.Parse(dt.Rows[n]["cid"].ToString());
                    }
                    if (dt.Rows[n]["ctype"] != null && dt.Rows[n]["ctype"].ToString() != "")
                    {
                        model.ctype = int.Parse(dt.Rows[n]["ctype"].ToString());
                    }
                    if (dt.Rows[n]["createmid"] != null && dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    if (dt.Rows[n]["lastedid"] != null && dt.Rows[n]["lastedid"].ToString() != "")
                    {
                        model.lastedid = int.Parse(dt.Rows[n]["lastedid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["qq"] != null && dt.Rows[n]["qq"].ToString() != "")
                    {
                        model.qq = dt.Rows[n]["qq"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShop> GetShopList(int PageIndex, int PageSize, string strWhere, out int pageCount, int marketid)
        {
            List<EnShop> modelList = new List<EnShop>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBShop, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                string sql = " where marketid=" + marketid + " AND shopid={0} ";
                EnShop model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnShop();
                    #region 赋值
                    
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["mid"] != null && dt.Rows[n]["mid"].ToString() != "")
                    {
                        model.mid = int.Parse(dt.Rows[n]["mid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["groupid"] != null && dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["industry"] != null && dt.Rows[n]["industry"].ToString() != "")
                    {
                        model.industry = dt.Rows[n]["industry"].ToString();
                    }
                    if (dt.Rows[n]["productcategory"] != null && dt.Rows[n]["productcategory"].ToString() != "")
                    {
                        model.productcategory = dt.Rows[n]["productcategory"].ToString();
                    }
                    if (dt.Rows[n]["vip"] != null && dt.Rows[n]["vip"].ToString() != "")
                    {
                        model.vip = int.Parse(dt.Rows[n]["vip"].ToString());
                    }
                    if (dt.Rows[n]["areacode"] != null && dt.Rows[n]["areacode"].ToString() != "")
                    {
                        model.areacode = dt.Rows[n]["areacode"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["mapapi"] != null && dt.Rows[n]["mapapi"].ToString() != "")
                    {
                        model.mapapi = dt.Rows[n]["mapapi"].ToString();
                    }
                    if (dt.Rows[n]["staffsize"] != null && dt.Rows[n]["staffsize"].ToString() != "")
                    {
                        model.staffsize = int.Parse(dt.Rows[n]["staffsize"].ToString());
                    }
                    if (dt.Rows[n]["regyear"] != null && dt.Rows[n]["regyear"].ToString() != "")
                    {
                        model.regyear = dt.Rows[n]["regyear"].ToString();
                    }
                    if (dt.Rows[n]["regcity"] != null && dt.Rows[n]["regcity"].ToString() != "")
                    {
                        model.regcity = dt.Rows[n]["regcity"].ToString();
                    }
                    if (dt.Rows[n]["buy"] != null && dt.Rows[n]["buy"].ToString() != "")
                    {
                        model.buy = dt.Rows[n]["buy"].ToString();
                    }
                    if (dt.Rows[n]["sell"] != null && dt.Rows[n]["sell"].ToString() != "")
                    {
                        model.sell = dt.Rows[n]["sell"].ToString();
                    }
                    if (dt.Rows[n]["linkman"] != null && dt.Rows[n]["linkman"].ToString() != "")
                    {
                        model.linkman = dt.Rows[n]["linkman"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["mphone"] != null && dt.Rows[n]["mphone"].ToString() != "")
                    {
                        model.mphone = dt.Rows[n]["mphone"].ToString();
                    }
                    if (dt.Rows[n]["fax"] != null && dt.Rows[n]["fax"].ToString() != "")
                    {
                        model.fax = dt.Rows[n]["fax"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["postcode"] != null && dt.Rows[n]["postcode"].ToString() != "")
                    {
                        model.postcode = dt.Rows[n]["postcode"].ToString();
                    }
                    if (dt.Rows[n]["homepage"] != null && dt.Rows[n]["homepage"].ToString() != "")
                    {
                        model.homepage = dt.Rows[n]["homepage"].ToString();
                    }
                    if (dt.Rows[n]["domain"] != null && dt.Rows[n]["domain"].ToString() != "")
                    {
                        model.domain = dt.Rows[n]["domain"].ToString();
                    }
                    if (dt.Rows[n]["domainip"] != null && dt.Rows[n]["domainip"].ToString() != "")
                    {
                        model.domainip = dt.Rows[n]["domainip"].ToString();
                    }
                    if (dt.Rows[n]["icp"] != null && dt.Rows[n]["icp"].ToString() != "")
                    {
                        model.icp = dt.Rows[n]["icp"].ToString();
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["desimage"] != null && dt.Rows[n]["desimage"].ToString() != "")
                    {
                        model.desimage = dt.Rows[n]["desimage"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["keywords"] != null && dt.Rows[n]["keywords"].ToString() != "")
                    {
                        model.keywords = dt.Rows[n]["keywords"].ToString();
                    }
                    if (dt.Rows[n]["template"] != null && dt.Rows[n]["template"].ToString() != "")
                    {
                        model.template = dt.Rows[n]["template"].ToString();
                    }
                    if (dt.Rows[n]["hits"] != null && dt.Rows[n]["hits"].ToString() != "")
                    {
                        model.hits = int.Parse(dt.Rows[n]["hits"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["marketid"] != null && dt.Rows[n]["marketid"].ToString() != "")
                    {
                        model.marketid = int.Parse(dt.Rows[n]["marketid"].ToString());
                    }
                    if (dt.Rows[n]["cid"] != null && dt.Rows[n]["cid"].ToString() != "")
                    {
                        model.cid = int.Parse(dt.Rows[n]["cid"].ToString());
                    }
                    if (dt.Rows[n]["ctype"] != null && dt.Rows[n]["ctype"].ToString() != "")
                    {
                        model.ctype = int.Parse(dt.Rows[n]["ctype"].ToString());
                    }
                    if (dt.Rows[n]["createmid"] != null && dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    if (dt.Rows[n]["lastedid"] != null && dt.Rows[n]["lastedid"].ToString() != "")
                    {
                        model.lastedid = int.Parse(dt.Rows[n]["lastedid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["qq"] != null && dt.Rows[n]["qq"].ToString() != "")
                    {
                        model.qq = dt.Rows[n]["qq"].ToString();
                    }
                    if (dt.Rows[n]["PavilionId"] != null && dt.Rows[n]["PavilionId"].ToString() != "")
                    {
                        model.PavilionId =Int32.Parse(dt.Rows[n]["PavilionId"].ToString());
                    }
                    #endregion

                    DataTable mydt = DataCommon.GetDataTable("t_marketstoreyshop", "position", string.Format(sql, dt.Rows[n]["id"].ToString()), "");
                    if (mydt != null && mydt.Rows.Count>0 )
                    {
                        if (mydt.Rows[0]["position"] != null && mydt.Rows[0]["position"].ToString() != "")
                        {
                            model.position = mydt.Rows[0]["position"].ToString();
                        }
                        else
                            model.position = "";
                    }
                    else
                        model.position = "";
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region 共公模块-组

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditShopGroup(EnShopGroup model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_shopgroup(");
                strSql.Append("title,color,avatar,integral,money,adcount,marketpcount,brandcount,promotioncount,productcount,adrecommend,marketrecommend,brandrecommend,promotionrecommend,productrecommend,permissions,lev,descript,sort)");
                strSql.Append(" values (");
                strSql.Append("@title,@color,@avatar,@integral,@money,@adcount,@marketpcount,@brandcount,@promotioncount,@productcount,@adrecommend,@marketrecommend,@brandrecommend,@promotionrecommend,@productrecommend,@permissions,@lev,@descript,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@color", SqlDbType.Char,7),
					new SqlParameter("@avatar", SqlDbType.VarChar,40),
					new SqlParameter("@integral", SqlDbType.Decimal,9),
					new SqlParameter("@money", SqlDbType.Decimal,9),
					new SqlParameter("@adcount", SqlDbType.Int,4),
					new SqlParameter("@marketpcount", SqlDbType.Int,4),
					new SqlParameter("@brandcount", SqlDbType.Int,4),
					new SqlParameter("@promotioncount", SqlDbType.Int,4),
					new SqlParameter("@productcount", SqlDbType.Int,4),
					new SqlParameter("@adrecommend", SqlDbType.Int,4),
					new SqlParameter("@marketrecommend", SqlDbType.Int,4),
					new SqlParameter("@brandrecommend", SqlDbType.Int,4),
					new SqlParameter("@promotionrecommend", SqlDbType.Int,4),
					new SqlParameter("@productrecommend", SqlDbType.Int,4),
					new SqlParameter("@permissions", SqlDbType.NText),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.color;
                parameters[2].Value = model.avatar;
                parameters[3].Value = model.integral;
                parameters[4].Value = model.money;
                parameters[5].Value = model.adcount;
                parameters[6].Value = model.marketpcount;
                parameters[7].Value = model.brandcount;
                parameters[8].Value = model.promotioncount;
                parameters[9].Value = model.productcount;
                parameters[10].Value = model.adrecommend;
                parameters[11].Value = model.marketrecommend;
                parameters[12].Value = model.brandrecommend;
                parameters[13].Value = model.promotionrecommend;
                parameters[14].Value = model.productrecommend;
                parameters[15].Value = model.permissions;
                parameters[16].Value = model.lev;
                parameters[17].Value = model.descript;
                parameters[18].Value = model.sort;



                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_shopgroup set ");
                strSql.Append("title=@title,");
                strSql.Append("color=@color,");
                strSql.Append("avatar=@avatar,");
                strSql.Append("integral=@integral,");
                strSql.Append("money=@money,");
                strSql.Append("adcount=@adcount,");
                strSql.Append("marketpcount=@marketpcount,");
                strSql.Append("brandcount=@brandcount,");
                strSql.Append("promotioncount=@promotioncount,");
                strSql.Append("productcount=@productcount,");
                strSql.Append("adrecommend=@adrecommend,");
                strSql.Append("marketrecommend=@marketrecommend,");
                strSql.Append("brandrecommend=@brandrecommend,");
                strSql.Append("promotionrecommend=@promotionrecommend,");
                strSql.Append("productrecommend=@productrecommend,");
                strSql.Append("permissions=@permissions,");
                strSql.Append("lev=@lev,");
                strSql.Append("descript=@descript,");
                strSql.Append("sort=@sort");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@color", SqlDbType.Char,7),
					new SqlParameter("@avatar", SqlDbType.VarChar,40),
					new SqlParameter("@integral", SqlDbType.Decimal,9),
					new SqlParameter("@money", SqlDbType.Decimal,9),
					new SqlParameter("@adcount", SqlDbType.Int,4),
					new SqlParameter("@marketpcount", SqlDbType.Int,4),
					new SqlParameter("@brandcount", SqlDbType.Int,4),
					new SqlParameter("@promotioncount", SqlDbType.Int,4),
					new SqlParameter("@productcount", SqlDbType.Int,4),
					new SqlParameter("@adrecommend", SqlDbType.Int,4),
					new SqlParameter("@marketrecommend", SqlDbType.Int,4),
					new SqlParameter("@brandrecommend", SqlDbType.Int,4),
					new SqlParameter("@promotionrecommend", SqlDbType.Int,4),
					new SqlParameter("@productrecommend", SqlDbType.Int,4),
					new SqlParameter("@permissions", SqlDbType.NText),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.color;
                parameters[2].Value = model.avatar;
                parameters[3].Value = model.integral;
                parameters[4].Value = model.money;
                parameters[5].Value = model.adcount;
                parameters[6].Value = model.marketpcount;
                parameters[7].Value = model.brandcount;
                parameters[8].Value = model.promotioncount;
                parameters[9].Value = model.productcount;
                parameters[10].Value = model.adrecommend;
                parameters[11].Value = model.marketrecommend;
                parameters[12].Value = model.brandrecommend;
                parameters[13].Value = model.promotionrecommend;
                parameters[14].Value = model.productrecommend;
                parameters[15].Value = model.permissions;
                parameters[16].Value = model.lev;
                parameters[17].Value = model.descript;
                parameters[18].Value = model.sort;
                parameters[19].Value = model.id;

                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.id;
                }
            }

            return 0;

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnShopGroup GetShopGroupInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_ShopGroup ");
            strSql.Append(strWhere);


            EnShopGroup model = new EnShopGroup();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["color"] != null && reader["color"].ToString() != "")
                {
                    model.color = reader["color"].ToString();
                }
                if (reader["avatar"] != null && reader["avatar"].ToString() != "")
                {
                    model.avatar = reader["avatar"].ToString();
                }
                if (reader["integral"] != null && reader["integral"].ToString() != "")
                {
                    model.integral = decimal.Parse(reader["integral"].ToString());
                }
                if (reader["money"] != null && reader["money"].ToString() != "")
                {
                    model.money = decimal.Parse(reader["money"].ToString());
                }
                if (reader["adcount"] != null && reader["adcount"].ToString() != "")
                {
                    model.adcount = int.Parse(reader["adcount"].ToString());
                }
                if (reader["marketpcount"] != null && reader["marketpcount"].ToString() != "")
                {
                    model.marketpcount = int.Parse(reader["marketpcount"].ToString());
                }
                if (reader["brandcount"] != null && reader["brandcount"].ToString() != "")
                {
                    model.brandcount = int.Parse(reader["brandcount"].ToString());
                }
                if (reader["promotioncount"] != null && reader["promotioncount"].ToString() != "")
                {
                    model.promotioncount = int.Parse(reader["promotioncount"].ToString());
                }
                if (reader["productcount"] != null && reader["productcount"].ToString() != "")
                {
                    model.productcount = int.Parse(reader["productcount"].ToString());
                }
                if (reader["adrecommend"] != null && reader["adrecommend"].ToString() != "")
                {
                    model.adrecommend = int.Parse(reader["adrecommend"].ToString());
                }
                if (reader["marketrecommend"] != null && reader["marketrecommend"].ToString() != "")
                {
                    model.marketrecommend = int.Parse(reader["marketrecommend"].ToString());
                }
                if (reader["brandrecommend"] != null && reader["brandrecommend"].ToString() != "")
                {
                    model.brandrecommend = int.Parse(reader["brandrecommend"].ToString());
                }
                if (reader["promotionrecommend"] != null && reader["promotionrecommend"].ToString() != "")
                {
                    model.promotionrecommend = int.Parse(reader["promotionrecommend"].ToString());
                }
                if (reader["productrecommend"] != null && reader["productrecommend"].ToString() != "")
                {
                    model.productrecommend = int.Parse(reader["productrecommend"].ToString());
                }
                if (reader["permissions"] != null && reader["permissions"].ToString() != "")
                {
                    model.permissions = reader["permissions"].ToString();
                }
                if (reader["lev"] != null && reader["lev"].ToString() != "")
                {
                    model.lev = int.Parse(reader["lev"].ToString());
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }

                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return model;
            }
            else
            {
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShopGroup> GetShopGroupList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnShopGroup> modelList = new List<EnShopGroup>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBShopGroup, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnShopGroup model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnShopGroup();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["color"] != null && dt.Rows[n]["color"].ToString() != "")
                    {
                        model.color = dt.Rows[n]["color"].ToString();
                    }
                    if (dt.Rows[n]["avatar"] != null && dt.Rows[n]["avatar"].ToString() != "")
                    {
                        model.avatar = dt.Rows[n]["avatar"].ToString();
                    }
                    if (dt.Rows[n]["integral"] != null && dt.Rows[n]["integral"].ToString() != "")
                    {
                        model.integral = decimal.Parse(dt.Rows[n]["integral"].ToString());
                    }
                    if (dt.Rows[n]["money"] != null && dt.Rows[n]["money"].ToString() != "")
                    {
                        model.money = decimal.Parse(dt.Rows[n]["money"].ToString());
                    }
                    if (dt.Rows[n]["adcount"] != null && dt.Rows[n]["adcount"].ToString() != "")
                    {
                        model.adcount = int.Parse(dt.Rows[n]["adcount"].ToString());
                    }
                    if (dt.Rows[n]["marketpcount"] != null && dt.Rows[n]["marketpcount"].ToString() != "")
                    {
                        model.marketpcount = int.Parse(dt.Rows[n]["marketpcount"].ToString());
                    }
                    if (dt.Rows[n]["brandcount"] != null && dt.Rows[n]["brandcount"].ToString() != "")
                    {
                        model.brandcount = int.Parse(dt.Rows[n]["brandcount"].ToString());
                    }
                    if (dt.Rows[n]["promotioncount"] != null && dt.Rows[n]["promotioncount"].ToString() != "")
                    {
                        model.promotioncount = int.Parse(dt.Rows[n]["promotioncount"].ToString());
                    }
                    if (dt.Rows[n]["productcount"] != null && dt.Rows[n]["productcount"].ToString() != "")
                    {
                        model.productcount = int.Parse(dt.Rows[n]["productcount"].ToString());
                    }
                    if (dt.Rows[n]["adrecommend"] != null && dt.Rows[n]["adrecommend"].ToString() != "")
                    {
                        model.adrecommend = int.Parse(dt.Rows[n]["adrecommend"].ToString());
                    }
                    if (dt.Rows[n]["marketrecommend"] != null && dt.Rows[n]["marketrecommend"].ToString() != "")
                    {
                        model.marketrecommend = int.Parse(dt.Rows[n]["marketrecommend"].ToString());
                    }
                    if (dt.Rows[n]["brandrecommend"] != null && dt.Rows[n]["brandrecommend"].ToString() != "")
                    {
                        model.brandrecommend = int.Parse(dt.Rows[n]["brandrecommend"].ToString());
                    }
                    if (dt.Rows[n]["promotionrecommend"] != null && dt.Rows[n]["promotionrecommend"].ToString() != "")
                    {
                        model.promotionrecommend = int.Parse(dt.Rows[n]["promotionrecommend"].ToString());
                    }
                    if (dt.Rows[n]["productrecommend"] != null && dt.Rows[n]["productrecommend"].ToString() != "")
                    {
                        model.productrecommend = int.Parse(dt.Rows[n]["productrecommend"].ToString());
                    }
                    if (dt.Rows[n]["permissions"] != null && dt.Rows[n]["permissions"].ToString() != "")
                    {
                        model.permissions = dt.Rows[n]["permissions"].ToString();
                    }
                    if (dt.Rows[n]["lev"] != null && dt.Rows[n]["lev"].ToString() != "")
                    {
                        model.lev = int.Parse(dt.Rows[n]["lev"].ToString());
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion
    }
}

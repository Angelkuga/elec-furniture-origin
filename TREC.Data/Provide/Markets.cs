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
    public class Markets
    {
        /// <summary>
        /// 获取卖场集团
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMarketClique(int pageindex,ref int count)
        {
            string sql = "EXEC  [sp_TablePage_orderby] " + pageindex + ",10,'','V_MarketClique',' orderby desc,id desc '";
            DataSet ds = new DataSet();
            ds = DbHelper.ExecuteDataset(sql);
            count = Int32.Parse(ds.Tables[1].Rows[0][0].ToString());
            return ds.Tables[0];
        }
        public static int ExitMarketLetter(string title)
        {
            SqlParameter[] parames = { 
            new SqlParameter("@letter", SqlDbType.NVarChar, 30)};
            parames[0].Value = title;
            return DataCommon.Exists(TableName.TBMarket, " where letter=@letter", parames);
        }
        public static int ExitMarket(string title)
        {
            SqlParameter[] parames = { 
            new SqlParameter("@title", SqlDbType.NVarChar, 30)};
            parames[0].Value = title;
            return DataCommon.Exists(TableName.TBMarket, " where title=@title", parames);
        }


        public static EnWebMarket GetWebMarketInfo(string strWhere)
        {
            EnWebMarket model = new EnWebMarket();
            IDataReader reader = DataCommon.GetDataIReader(TableName.TVMarket, "", strWhere, "");
            while (reader.Read())
            {
                if (reader["shopcount"] != null && reader["shopcount"].ToString() != "")
                {
                    model.shopcount = int.Parse(reader["shopcount"].ToString());
                }
                if (reader["shopxml"] != null && reader["shopxml"].ToString() != "")
                {
                    model.shopxml = reader["shopxml"].ToString();
                }
                if (reader["brandxml"] != null && reader["brandxml"].ToString() != "")
                {
                    model.brandxml = reader["brandxml"].ToString();
                }
                if (reader["marketstoreyxml"] != null && reader["marketstoreyxml"].ToString() != "")
                {
                    model.marketstoreyxml = reader["marketstoreyxml"].ToString();
                }
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
                if (reader["cbm"] != null && reader["cbm"].ToString() != "")
                {
                    model.cbm = decimal.Parse(reader["cbm"].ToString());
                }
                if (reader["lphone"] != null && reader["lphone"].ToString() != "")
                {
                    model.lphone = reader["lphone"].ToString();
                }
                if (reader["zphone"] != null && reader["zphone"].ToString() != "")
                {
                    model.zphone = reader["zphone"].ToString();
                }
                if (reader["busroute"] != null && reader["busroute"].ToString() != "")
                {
                    model.busroute = reader["busroute"].ToString();
                }
                if (reader["hours"] != null && reader["hours"].ToString() != "")
                {
                    model.hours = reader["hours"].ToString();
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
            }
            reader.Close();
            if (!reader.IsClosed)
            {
                reader.Close();
            }
            return model;
        }

        public static List<EnWebMarket> GetMarketByLetter(string strWhere)
        {
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = " WHERE auditstatus = 1 and linestatus =1 AND letter is not null AND letter <> '' AND " + strWhere;
            else
                strWhere = " WHERE auditstatus = 1 and linestatus =1 AND letter is not null AND letter <> '' ";
            IDataReader reader = DataCommon.GetDataIReader(TableName.TBMarket, "id,title,(case when vip is null then 0 else vip end) as vip,substring(letter,1,1) as myletter", strWhere, " ");
            List<EnWebMarket> MarketList = new List<EnWebMarket>();
            EnWebMarket model = null;
            while (reader.Read())
            {
                model = new EnWebMarket();
                model.id = int.Parse(reader["id"].ToString());
                model.title = reader["title"].ToString();
                model.vip = int.Parse(reader["vip"].ToString());
                model.letter = reader["myletter"].ToString();
                MarketList.Add(model);
                model = null;
            }
            reader.Close();
            if (!reader.IsClosed)
            {
                reader.Close();
            }
            return MarketList;
        }

        //卖场列表
        public static List<EnWebMarket> GetWebMarketList(int PageIndex, int PageSize, string strWhere,string sortkey, string ordertype, out int pageCount)
        {
            List<EnWebMarket> list = new List<EnWebMarket>();
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TVMarket, PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);
            while (reader.Read())
            {
                EnWebMarket model = new EnWebMarket();
                if (reader["shopcount"] != null && reader["shopcount"].ToString() != "")
                {
                    model.shopcount = int.Parse(reader["shopcount"].ToString());
                }
                if (reader["shopxml"] != null && reader["shopxml"].ToString() != "")
                {
                    model.shopxml = reader["shopxml"].ToString();
                }
                if (reader["brandxml"] != null && reader["brandxml"].ToString() != "")
                {
                    model.brandxml = reader["brandxml"].ToString();
                }
                if (reader["marketstoreyxml"] != null && reader["marketstoreyxml"].ToString() != "")
                {
                    model.marketstoreyxml = reader["marketstoreyxml"].ToString();
                }
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
                if (reader["cbm"] != null && reader["cbm"].ToString() != "")
                {
                    model.cbm = decimal.Parse(reader["cbm"].ToString());
                }
                if (reader["lphone"] != null && reader["lphone"].ToString() != "")
                {
                    model.lphone = reader["lphone"].ToString();
                }
                if (reader["zphone"] != null && reader["zphone"].ToString() != "")
                {
                    model.zphone = reader["zphone"].ToString();
                }
                if (reader["busroute"] != null && reader["busroute"].ToString() != "")
                {
                    model.busroute = reader["busroute"].ToString();
                }
                if (reader["hours"] != null && reader["hours"].ToString() != "")
                {
                    model.hours = reader["hours"].ToString();
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
                if (reader["Stitle"] != null && reader["Stitle"].ToString() != "")
                {
                    model.Stitle = reader["Stitle"].ToString();
                }
                if (reader["MarketCliqueName"] != null && reader["MarketCliqueName"].ToString() != "")
                {
                    model.MarketCliqueName = reader["MarketCliqueName"].ToString();
                }
                
                list.Add(model);
            }
            reader.Close();
            if (!reader.IsClosed)
            {
                reader.Close();
            }
            return list;
        }

        public static List<EnSearchItem> GetMarketSearchItem()
        {
            List<EnSearchItem> list = new List<EnSearchItem>();
            IDataReader reader = DbHelper.ExecuteReader(" select * from " + TableName.TVMarketSearchItem);
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
                else
                {
                    model.value = "0";
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
            reader.Close();
            if (!reader.IsClosed)
            {
                reader.Close();
            }
            return list;
        }

        #region 共公模块

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMarket(EnMarket model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_market(");
                strSql.Append("mid,title,letter,groupid,attribute,industry,productcategory,vip,areacode,address,mapapi,staffsize,regyear,regcity,buy,sell,cbm,lphone,zphone,busroute,hours,linkman,phone,mphone,fax,email,postcode,homepage,domain,domainip,icp,surface,logo,thumb,bannel,desimage,descript,keywords,template,hits,sort,createmid,lastedid,lastedittime,auditstatus,linestatus,MarketCliqueName,Stitle)");
                strSql.Append(" values (");
                strSql.Append("@mid,@title,@letter,@groupid,@attribute,@industry,@productcategory,@vip,@areacode,@address,@mapapi,@staffsize,@regyear,@regcity,@buy,@sell,@cbm,@lphone,@zphone,@busroute,@hours,@linkman,@phone,@mphone,@fax,@email,@postcode,@homepage,@domain,@domainip,@icp,@surface,@logo,@thumb,@bannel,@desimage,@descript,@keywords,@template,@hits,@sort,@createmid,@lastedid,@lastedittime,@auditstatus,@linestatus,@MarketCliqueName,@Stitle)");
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
					new SqlParameter("@cbm", SqlDbType.Decimal,9),
					new SqlParameter("@lphone", SqlDbType.VarChar,50),
					new SqlParameter("@zphone", SqlDbType.VarChar,50),
					new SqlParameter("@busroute", SqlDbType.NVarChar,160),
					new SqlParameter("@hours", SqlDbType.NVarChar,160),
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
					new SqlParameter("@logo", SqlDbType.VarChar,200),
					new SqlParameter("@thumb", SqlDbType.VarChar,200),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@desimage", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@template", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
                    new SqlParameter("@MarketCliqueName", SqlDbType.VarChar,200),
                     new SqlParameter("@Stitle", SqlDbType.VarChar,200)
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
                parameters[16].Value = model.cbm;
                parameters[17].Value = model.lphone;
                parameters[18].Value = model.zphone;
                parameters[19].Value = model.busroute;
                parameters[20].Value = model.hours;
                parameters[21].Value = model.linkman;
                parameters[22].Value = model.phone;
                parameters[23].Value = model.mphone;
                parameters[24].Value = model.fax;
                parameters[25].Value = model.email;
                parameters[26].Value = model.postcode;
                parameters[27].Value = model.homepage;
                parameters[28].Value = model.domain;
                parameters[29].Value = model.domainip;
                parameters[30].Value = model.icp;
                parameters[31].Value = model.surface;
                parameters[32].Value = model.logo;
                parameters[33].Value = model.thumb;
                parameters[34].Value = model.bannel;
                parameters[35].Value = model.desimage;
                parameters[36].Value = model.descript;
                parameters[37].Value = model.keywords;
                parameters[38].Value = model.template;
                parameters[39].Value = model.hits;
                parameters[40].Value = model.sort;
                parameters[41].Value = model.createmid;
                parameters[42].Value = model.lastedid;
                parameters[43].Value = model.lastedittime;
                parameters[44].Value = model.auditstatus;
                parameters[45].Value = model.linestatus;
                parameters[46].Value = model.MarketCliqueName;
                parameters[47].Value = model.Stitle;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_market set ");
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
                strSql.Append("cbm=@cbm,");
                strSql.Append("lphone=@lphone,");
                strSql.Append("zphone=@zphone,");
                strSql.Append("busroute=@busroute,");
                strSql.Append("hours=@hours,");
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
                strSql.Append("createmid=@createmid,");
                strSql.Append("lastedid=@lastedid,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("auditstatus=@auditstatus,");
                strSql.Append("linestatus=@linestatus,");
                strSql.Append("MarketCliqueName=@MarketCliqueName,");
                strSql.Append("Stitle=@Stitle");
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
					new SqlParameter("@cbm", SqlDbType.Decimal,9),
					new SqlParameter("@lphone", SqlDbType.VarChar,50),
					new SqlParameter("@zphone", SqlDbType.VarChar,50),
					new SqlParameter("@busroute", SqlDbType.NVarChar,160),
					new SqlParameter("@hours", SqlDbType.NVarChar,160),
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
					new SqlParameter("@logo", SqlDbType.VarChar,200),
					new SqlParameter("@thumb", SqlDbType.VarChar,200),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@desimage", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NText),
					new SqlParameter("@keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@template", SqlDbType.VarChar,50),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@MarketCliqueName", SqlDbType.VarChar,200),
                    new SqlParameter("@Stitle", SqlDbType.VarChar,200)
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
                parameters[16].Value = model.cbm;
                parameters[17].Value = model.lphone;
                parameters[18].Value = model.zphone;
                parameters[19].Value = model.busroute;
                parameters[20].Value = model.hours;
                parameters[21].Value = model.linkman;
                parameters[22].Value = model.phone;
                parameters[23].Value = model.mphone;
                parameters[24].Value = model.fax;
                parameters[25].Value = model.email;
                parameters[26].Value = model.postcode;
                parameters[27].Value = model.homepage;
                parameters[28].Value = model.domain;
                parameters[29].Value = model.domainip;
                parameters[30].Value = model.icp;
                parameters[31].Value = model.surface;
                parameters[32].Value = model.logo;
                parameters[33].Value = model.thumb;
                parameters[34].Value = model.bannel;
                parameters[35].Value = model.desimage;
                parameters[36].Value = model.descript;
                parameters[37].Value = model.keywords;
                parameters[38].Value = model.template;
                parameters[39].Value = model.hits;
                parameters[40].Value = model.sort;
                parameters[41].Value = model.createmid;
                parameters[42].Value = model.lastedid;
                parameters[43].Value = model.lastedittime;
                parameters[44].Value = model.auditstatus;
                parameters[45].Value = model.linestatus;
                parameters[46].Value = model.id;
                parameters[47].Value = model.MarketCliqueName;
                parameters[48].Value = model.Stitle;
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
        public static EnMarket GetMarketInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Market ");
            strSql.Append(strWhere);


            EnMarket model = new EnMarket();
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
                if (reader["cbm"] != null && reader["cbm"].ToString() != "")
                {
                    model.cbm = decimal.Parse(reader["cbm"].ToString());
                }
                if (reader["lphone"] != null && reader["lphone"].ToString() != "")
                {
                    model.lphone = reader["lphone"].ToString();
                }
                if (reader["zphone"] != null && reader["zphone"].ToString() != "")
                {
                    model.zphone = reader["zphone"].ToString();
                }
                if (reader["busroute"] != null && reader["busroute"].ToString() != "")
                {
                    model.busroute = reader["busroute"].ToString();
                }
                if (reader["hours"] != null && reader["hours"].ToString() != "")
                {
                    model.hours = reader["hours"].ToString();
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
                if (reader["MarketCliqueName"] != null && reader["MarketCliqueName"].ToString() != "")
                {
                    model.MarketCliqueName = reader["MarketCliqueName"].ToString();
                }
                else
                {
                    model.MarketCliqueName=string.Empty;
                }

                if (reader["Stitle"] != null && reader["Stitle"].ToString() != "")
                {
                    model.Stitle = reader["Stitle"].ToString();
                }
                else
                {
                    model.Stitle = string.Empty;
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
        public static List<EnMarket> GetMarketList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMarket> modelList = new List<EnMarket>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMarket, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMarket model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMarket();
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
                    if (dt.Rows[n]["cbm"] != null && dt.Rows[n]["cbm"].ToString() != "")
                    {
                        model.cbm = decimal.Parse(dt.Rows[n]["cbm"].ToString());
                    }
                    if (dt.Rows[n]["lphone"] != null && dt.Rows[n]["lphone"].ToString() != "")
                    {
                        model.lphone = dt.Rows[n]["lphone"].ToString();
                    }
                    if (dt.Rows[n]["zphone"] != null && dt.Rows[n]["zphone"].ToString() != "")
                    {
                        model.zphone = dt.Rows[n]["zphone"].ToString();
                    }
                    if (dt.Rows[n]["busroute"] != null && dt.Rows[n]["busroute"].ToString() != "")
                    {
                        model.busroute = dt.Rows[n]["busroute"].ToString();
                    }
                    if (dt.Rows[n]["hours"] != null && dt.Rows[n]["hours"].ToString() != "")
                    {
                        model.hours = dt.Rows[n]["hours"].ToString();
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
                    if (dt.Rows[n]["MarketCliqueName"] != null && dt.Rows[n]["MarketCliqueName"].ToString() != "")
                    {
                        model.MarketCliqueName = dt.Rows[n]["linestatus"].ToString();
                    }
                    else
                    {
                        model.MarketCliqueName = string.Empty;
                    }

                    if (dt.Rows[n]["Stitle"] != null && dt.Rows[n]["Stitle"].ToString() != "")
                    {
                        model.Stitle = dt.Rows[n]["Stitle"].ToString();
                    }
                    else
                    {
                        model.Stitle = string.Empty;
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMarket> GetMarketList(string filed, string strWhere, string sort)
        {
            List<EnMarket> modelList = new List<EnMarket>();
            DataTable dt =DataCommon.GetDataTable(TableName.TBMarket, filed, strWhere, sort);
            if (dt.Rows.Count > 0)
            {
                EnMarket model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMarket();
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
                    if (dt.Rows[n]["cbm"] != null && dt.Rows[n]["cbm"].ToString() != "")
                    {
                        model.cbm = decimal.Parse(dt.Rows[n]["cbm"].ToString());
                    }
                    if (dt.Rows[n]["lphone"] != null && dt.Rows[n]["lphone"].ToString() != "")
                    {
                        model.lphone = dt.Rows[n]["lphone"].ToString();
                    }
                    if (dt.Rows[n]["zphone"] != null && dt.Rows[n]["zphone"].ToString() != "")
                    {
                        model.zphone = dt.Rows[n]["zphone"].ToString();
                    }
                    if (dt.Rows[n]["busroute"] != null && dt.Rows[n]["busroute"].ToString() != "")
                    {
                        model.busroute = dt.Rows[n]["busroute"].ToString();
                    }
                    if (dt.Rows[n]["hours"] != null && dt.Rows[n]["hours"].ToString() != "")
                    {
                        model.hours = dt.Rows[n]["hours"].ToString();
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

                    if (dt.Rows[n]["MarketCliqueName"] != null && dt.Rows[n]["MarketCliqueName"].ToString() != "")
                    {
                        model.MarketCliqueName = dt.Rows[n]["linestatus"].ToString();
                    }
                    else
                    {
                        model.MarketCliqueName = string.Empty;
                    }

                    if (dt.Rows[n]["Stitle"] != null && dt.Rows[n]["Stitle"].ToString() != "")
                    {
                        model.Stitle = dt.Rows[n]["Stitle"].ToString();
                    }
                    else
                    {
                        model.Stitle = string.Empty;
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public static List<EnAggregation> GetIndexMarketRecommandAd(string typeName)
        {
            SqlParameter para =  new SqlParameter("@typeName",SqlDbType.NVarChar,100);
            para.Value = typeName;
            string Sql = "SELECT A.id as id,A.thumb as thumb,A.url as url,A.title as title FROM t_aggregation A JOIN t_aggregationtype B ON B.id=A.type WHERE B.title = @typeName ORDER BY A.sort ";
                        
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text,Sql,para);
            if (reader != null)
            {
                List<EnAggregation> AdList = new List<EnAggregation>();
                EnAggregation model = null;
                while (reader.Read())
                {
                    model = new EnAggregation();
                    model.id = int.Parse(reader["id"].ToString());
                    model.thumb = reader["thumb"].ToString();
                    model.url = reader["url"].ToString();
                    model.title = reader["title"].ToString();
                    AdList.Add(model);
                    model = null;
                }
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return AdList;
            }
            else
                return  null;
        }

        #endregion

        #region 共公模块-组

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMarketGroup(EnMarketGroup model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_marketgroup(");
                strSql.Append("title,color,avatar,integral,money,adcount,shopcount,brandcount,promotioncount,storeycount,storeyshopcount,adrecommend,shoprecommend,brandrecommend,promotionrecommend,lev,permissions,descript,sort)");
                strSql.Append(" values (");
                strSql.Append("@title,@color,@avatar,@integral,@money,@adcount,@shopcount,@brandcount,@promotioncount,@storeycount,@storeyshopcount,@adrecommend,@shoprecommend,@brandrecommend,@promotionrecommend,@lev,@permissions,@descript,@sort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,30),
					new SqlParameter("@color", SqlDbType.Char,7),
					new SqlParameter("@avatar", SqlDbType.VarChar,40),
					new SqlParameter("@integral", SqlDbType.Decimal,9),
					new SqlParameter("@money", SqlDbType.Decimal,9),
					new SqlParameter("@adcount", SqlDbType.Int,4),
					new SqlParameter("@shopcount", SqlDbType.Int,4),
					new SqlParameter("@brandcount", SqlDbType.Int,4),
					new SqlParameter("@promotioncount", SqlDbType.Int,4),
					new SqlParameter("@storeycount", SqlDbType.Int,4),
					new SqlParameter("@storeyshopcount", SqlDbType.Int,4),
					new SqlParameter("@adrecommend", SqlDbType.Int,4),
					new SqlParameter("@shoprecommend", SqlDbType.Int,4),
					new SqlParameter("@brandrecommend", SqlDbType.Int,4),
					new SqlParameter("@promotionrecommend", SqlDbType.Int,4),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@permissions", SqlDbType.NText),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@sort", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.color;
                parameters[2].Value = model.avatar;
                parameters[3].Value = model.integral;
                parameters[4].Value = model.money;
                parameters[5].Value = model.adcount;
                parameters[6].Value = model.shopcount;
                parameters[7].Value = model.brandcount;
                parameters[8].Value = model.promotioncount;
                parameters[9].Value = model.storeycount;
                parameters[10].Value = model.storeyshopcount;
                parameters[11].Value = model.adrecommend;
                parameters[12].Value = model.shoprecommend;
                parameters[13].Value = model.brandrecommend;
                parameters[14].Value = model.promotionrecommend;
                parameters[15].Value = model.lev;
                parameters[16].Value = model.permissions;
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
                strSql.Append("update t_marketgroup set ");
                strSql.Append("title=@title,");
                strSql.Append("color=@color,");
                strSql.Append("avatar=@avatar,");
                strSql.Append("integral=@integral,");
                strSql.Append("money=@money,");
                strSql.Append("adcount=@adcount,");
                strSql.Append("shopcount=@shopcount,");
                strSql.Append("brandcount=@brandcount,");
                strSql.Append("promotioncount=@promotioncount,");
                strSql.Append("storeycount=@storeycount,");
                strSql.Append("storeyshopcount=@storeyshopcount,");
                strSql.Append("adrecommend=@adrecommend,");
                strSql.Append("shoprecommend=@shoprecommend,");
                strSql.Append("brandrecommend=@brandrecommend,");
                strSql.Append("promotionrecommend=@promotionrecommend,");
                strSql.Append("lev=@lev,");
                strSql.Append("permissions=@permissions,");
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
					new SqlParameter("@shopcount", SqlDbType.Int,4),
					new SqlParameter("@brandcount", SqlDbType.Int,4),
					new SqlParameter("@promotioncount", SqlDbType.Int,4),
					new SqlParameter("@storeycount", SqlDbType.Int,4),
					new SqlParameter("@storeyshopcount", SqlDbType.Int,4),
					new SqlParameter("@adrecommend", SqlDbType.Int,4),
					new SqlParameter("@shoprecommend", SqlDbType.Int,4),
					new SqlParameter("@brandrecommend", SqlDbType.Int,4),
					new SqlParameter("@promotionrecommend", SqlDbType.Int,4),
					new SqlParameter("@lev", SqlDbType.Int,4),
					new SqlParameter("@permissions", SqlDbType.NText),
					new SqlParameter("@descript", SqlDbType.NVarChar,300),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.title;
                parameters[1].Value = model.color;
                parameters[2].Value = model.avatar;
                parameters[3].Value = model.integral;
                parameters[4].Value = model.money;
                parameters[5].Value = model.adcount;
                parameters[6].Value = model.shopcount;
                parameters[7].Value = model.brandcount;
                parameters[8].Value = model.promotioncount;
                parameters[9].Value = model.storeycount;
                parameters[10].Value = model.storeyshopcount;
                parameters[11].Value = model.adrecommend;
                parameters[12].Value = model.shoprecommend;
                parameters[13].Value = model.brandrecommend;
                parameters[14].Value = model.promotionrecommend;
                parameters[15].Value = model.lev;
                parameters[16].Value = model.permissions;
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
        public static EnMarketGroup GetMarketGroupInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_MarketGroup ");
            strSql.Append(strWhere);


            EnMarketGroup model = new EnMarketGroup();
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
                if (reader["shopcount"] != null && reader["shopcount"].ToString() != "")
                {
                    model.shopcount = int.Parse(reader["shopcount"].ToString());
                }
                if (reader["brandcount"] != null && reader["brandcount"].ToString() != "")
                {
                    model.brandcount = int.Parse(reader["brandcount"].ToString());
                }
                if (reader["promotioncount"] != null && reader["promotioncount"].ToString() != "")
                {
                    model.promotioncount = int.Parse(reader["promotioncount"].ToString());
                }
                if (reader["storeycount"] != null && reader["storeycount"].ToString() != "")
                {
                    model.storeycount = int.Parse(reader["storeycount"].ToString());
                }
                if (reader["storeyshopcount"] != null && reader["storeyshopcount"].ToString() != "")
                {
                    model.storeyshopcount = int.Parse(reader["storeyshopcount"].ToString());
                }
                if (reader["adrecommend"] != null && reader["adrecommend"].ToString() != "")
                {
                    model.adrecommend = int.Parse(reader["adrecommend"].ToString());
                }
                if (reader["shoprecommend"] != null && reader["shoprecommend"].ToString() != "")
                {
                    model.shoprecommend = int.Parse(reader["shoprecommend"].ToString());
                }
                if (reader["brandrecommend"] != null && reader["brandrecommend"].ToString() != "")
                {
                    model.brandrecommend = int.Parse(reader["brandrecommend"].ToString());
                }
                if (reader["promotionrecommend"] != null && reader["promotionrecommend"].ToString() != "")
                {
                    model.promotionrecommend = int.Parse(reader["promotionrecommend"].ToString());
                }
                if (reader["lev"] != null && reader["lev"].ToString() != "")
                {
                    model.lev = int.Parse(reader["lev"].ToString());
                }
                if (reader["permissions"] != null && reader["permissions"].ToString() != "")
                {
                    model.permissions = reader["permissions"].ToString();
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
        public static List<EnMarketGroup> GetMarketGroupList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnMarketGroup> modelList = new List<EnMarketGroup>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBMarketGroup, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnMarketGroup model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnMarketGroup();
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
                    if (dt.Rows[n]["shopcount"] != null && dt.Rows[n]["shopcount"].ToString() != "")
                    {
                        model.shopcount = int.Parse(dt.Rows[n]["shopcount"].ToString());
                    }
                    if (dt.Rows[n]["brandcount"] != null && dt.Rows[n]["brandcount"].ToString() != "")
                    {
                        model.brandcount = int.Parse(dt.Rows[n]["brandcount"].ToString());
                    }
                    if (dt.Rows[n]["promotioncount"] != null && dt.Rows[n]["promotioncount"].ToString() != "")
                    {
                        model.promotioncount = int.Parse(dt.Rows[n]["promotioncount"].ToString());
                    }
                    if (dt.Rows[n]["storeycount"] != null && dt.Rows[n]["storeycount"].ToString() != "")
                    {
                        model.storeycount = int.Parse(dt.Rows[n]["storeycount"].ToString());
                    }
                    if (dt.Rows[n]["storeyshopcount"] != null && dt.Rows[n]["storeyshopcount"].ToString() != "")
                    {
                        model.storeyshopcount = int.Parse(dt.Rows[n]["storeyshopcount"].ToString());
                    }
                    if (dt.Rows[n]["adrecommend"] != null && dt.Rows[n]["adrecommend"].ToString() != "")
                    {
                        model.adrecommend = int.Parse(dt.Rows[n]["adrecommend"].ToString());
                    }
                    if (dt.Rows[n]["shoprecommend"] != null && dt.Rows[n]["shoprecommend"].ToString() != "")
                    {
                        model.shoprecommend = int.Parse(dt.Rows[n]["shoprecommend"].ToString());
                    }
                    if (dt.Rows[n]["brandrecommend"] != null && dt.Rows[n]["brandrecommend"].ToString() != "")
                    {
                        model.brandrecommend = int.Parse(dt.Rows[n]["brandrecommend"].ToString());
                    }
                    if (dt.Rows[n]["promotionrecommend"] != null && dt.Rows[n]["promotionrecommend"].ToString() != "")
                    {
                        model.promotionrecommend = int.Parse(dt.Rows[n]["promotionrecommend"].ToString());
                    }
                    if (dt.Rows[n]["lev"] != null && dt.Rows[n]["lev"].ToString() != "")
                    {
                        model.lev = int.Parse(dt.Rows[n]["lev"].ToString());
                    }
                    if (dt.Rows[n]["permissions"] != null && dt.Rows[n]["permissions"].ToString() != "")
                    {
                        model.permissions = dt.Rows[n]["permissions"].ToString();
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

        #region 卖场品牌数量的数据统计
        public static List<Hashtable> GetMarkCount(string markid)
        {
            List<Hashtable> list = new List<Hashtable>();
            IDataReader reader = DbHelper.ExecuteReader("select Count(distinct brandid) as BrandCount from t_shopbrand where shopid in(select id from t_shop where marketid=" + markid + ")");
            while (reader.Read())
            {
                Hashtable model = new Hashtable();
                if (reader["BrandCount"] != null && reader["BrandCount"].ToString() != "")
                {
                    model["BrandCount"] = reader["BrandCount"].ToString();
                }
                list.Add(model);
            }
            reader.Close();
            if (!reader.IsClosed)
            {
                reader.Close();
            }
            return list;
        }
        #endregion
    }
}
